using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Fusee.Base.Common;
using Fusee.Base.Core;
using Fusee.Math.Core;
using SkiaSharp;
using Typography.OpenFont;
using Typography.TextLayout;

namespace Fusee.Base.Imp.WebAsm
{
    /// <summary>
    /// Font implementation using Typography
    /// https://github.com/LayoutFarm/Typography
    /// </summary>
    public class FontImp : IFontImp
    {
        public bool UseKerning
        {
            get { return _useKerning; }
            set
            {
                //TODO has kerning?
                _useKerning = value;
            }
        }


        public uint PixelHeight
        {
            get
            {
                return _pixelHeight;
            }
            set
            {
                _pixelHeight = value;
            }
        }

        private GlyphLayout _glyphLayout;

        private bool _useKerning;
        private uint _pixelHeight;

        private int FontAscendingPx;
        private short FontDescedingPx;
        private short FontLineGapPx;
        private short FontLineSpacingPx;

        public FontImp(Stream stream)
        {
            var _typeface = SKTypeface.FromStream(stream);


        }

        public Curve GetGlyphCurve(uint c)
        {
            var curve = new Curve();

            //_face.LoadChar(c, LoadFlags.NoScale, LoadTarget.Normal);
            var glyph = _glyphLayout.Typeface.GetGlyphByIndex((ushort)c);

            curve.CurveParts = new List<CurvePart>();
            var orgPointCoords = glyph.GlyphPoints;
            var pointTags = glyph.GlyphClass;
            if (orgPointCoords == null) return curve;

            //Freetype contours are defined by their end points.
            var curvePartEndPoints = glyph.EndPoints;

            var partTags = new List<byte>();
            var partVerts = new List<float3>();

            //Writes points of a freetyp contour into a CurvePart,
            for (var i = 0; i <= orgPointCoords.Length; i++)
            {
                //If a certain index of outline points is in array of contour end points - create new CurvePart and add it to Curve.CurveParts
                if (!curvePartEndPoints.ToList().Contains((ushort)i)) continue;

                partVerts.Clear();
                partTags.Clear();

                //var part = SplitToCurvePartHelper.CreateCurvePart(orgPointCoords, pointTags, curvePartEndPoints, i,
                //    partVerts, partTags); // TODO
                //curve.CurveParts.Add(part);

                //var segments = SplitToCurveSegmentHelper.SplitPartIntoSegments(part, partTags, partVerts);
                //SplitToCurveSegmentHelper.CombineCurveSegmentsAndAddThemToCurvePart(segments, part);
            }
            return curve;
        }

        public GlyphInfo GetGlyphInfo(uint c)
        {
            GlyphInfo ret;
            var res = _glyphLayout.Typeface.GetGlyphByIndex((ushort)c);

            ret.CharCode = c;

            ret.AdvanceX = 0; // TODO
            ret.AdvanceY = res.OriginalAdvanceWidth;

            ret.Width = res.Bounds.XMax;
            ret.Height = res.Bounds.YMax;

            return ret;
        }

        public float GetKerning(uint leftC, uint rightC)
        {
            return _glyphLayout.Typeface.GetKernDistance((ushort)leftC, (ushort)rightC);
        }

        public float GetUnscaledAdvance(uint c)
        {
            var glyph = _glyphLayout.Typeface.GetGlyphByIndex((ushort)c);

            return glyph.HasOriginalAdvancedWidth ? glyph.OriginalAdvanceWidth : 0;
        }

        public float GetUnscaledKerning(uint leftC, uint rightC)
        {
            return _glyphLayout.Typeface.GetKernDistance((ushort)leftC, (ushort)rightC);
        }

        public IImageData RenderGlyph(uint c, out int bitmapLeft, out int bitmapTop)
        {
            var glyph = _glyphLayout.Typeface.GetGlyphByIndex((ushort)c);
            bitmapLeft = glyph.Bounds.XMin;
            bitmapTop = glyph.Bounds.XMin;

            var xSize = glyph.Bounds.XMax - glyph.Bounds.XMin;
            var ySize = glyph.Bounds.YMax - glyph.Bounds.YMin;

            var bitmap = new SKBitmap(xSize, ySize, SKImageInfo.PlatformColorType, SKAlphaType.Premul);

            var surface = SKSurface.Create(bitmap.Info);

            var canvas = surface.Canvas;
            canvas.Clear(SKColors.White);


            var paint = new SKPaint();
            paint.TextSize = 24;
            paint.Color = SKColors.Yellow;
            //paint.Typeface = SKTypeface.FromTypeface(); <--- TODO!
            
            canvas.DrawText("Fancy Text", 30, 30, paint);

            var image = SKImage.FromBitmap(bitmap);
            var data = surface.Snapshot().Encode();
            MemoryStream ms = new MemoryStream();
            data.SaveTo(ms);
            var bytes = ms.ToArray();        

            ImageData ret = new ImageData(bytes, image.Width, image.Height,
               new ImagePixelFormat(ColorFormat.Intensity));
          
            return ret;
        }

        internal class SplitToCurvePartHelper
        {
            #region Methodes
            public static void CurvePartVertice(CurvePart cp, int j, GlyphPointF[] orgPointCoords, List<float3> partVerts)
            {
                var vert = new float3(orgPointCoords[j].X, orgPointCoords[j].Y, 0);
                partVerts.Add(vert);
            }

            public static CurvePart CreateCurvePart(GlyphPointF[] orgPointCoords, byte[] pointTags, ushort[] curvePartEndPoints, int i, List<float3> partVerts, List<byte> partTags)
            {
                var index = Array.IndexOf(curvePartEndPoints, (short)i);
                var cp = new CurvePart
                {
                    IsClosed = true,
                    CurveSegments = new List<CurveSegment>()
                };

                //Marginal case - first contour ( 0 to contours[0] ). 
                if (index == 0)
                {
                    for (var j = 0; j <= i; j++)
                    {
                        CurvePartVertice(cp, j, orgPointCoords, partVerts);
                        partTags.Add(pointTags[j]);
                    }
                    //The start point is the first point in the outline.Points array.
                    cp.StartPoint = new float3(orgPointCoords[0].X, orgPointCoords[0].Y, 0);
                }

                //contours[0]+1 to contours[1]
                else
                {
                    for (var j = curvePartEndPoints[index - 1] + 1; j <= curvePartEndPoints[index]; j++)
                    {
                        CurvePartVertice(cp, j, orgPointCoords, partVerts);
                        partTags.Add(pointTags[j]);
                    }

                    //The index in outline.Points which describes the start point is given by the index of the foregone outline.contours index +1.
                    cp.StartPoint = new float3(orgPointCoords[curvePartEndPoints[index - 1] + 1].X, orgPointCoords[curvePartEndPoints[index - 1] + 1].Y, 0);
                }
                return cp;
            }
            #endregion
        }
    }
}
