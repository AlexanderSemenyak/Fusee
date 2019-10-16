using System.Collections.Generic;
using System.IO;
using Fusee.Base.Common;
using Fusee.Base.Core;
using Fusee.Math.Core;
using System.Runtime.InteropServices;
using FontFace = SharpFont_mngd.FontFace;
using SharpFont_mngd;
using System;

namespace Fusee.Base.Imp.WebAsm
{
    /// <summary>
    /// Font implementation using SharpFont
    /// https://github.com/MikePopoloski/SharpFont
    /// this is NOT the SharpFont freetype wrapper but a C# native library
    /// </summary>
    public class FontImp : IFontImp
    {

        internal FontFace _face;
        private bool _useKerning;
        private uint _pixelHeight;

        public FontImp(Stream stream)
        {
            _face = new FontFace(stream);
            _pixelHeight = 18;
            UseKerning = false;
        }

        public bool UseKerning
        {
            get { return _useKerning; }
            set
            {
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

        public Curve GetGlyphCurve(uint c)
        {
            var glyph = _face.GetGlyph(new CodePoint((char)c), PixelHeight);

            var curve = new Curve
            {
                CurveParts = new List<CurvePart>
          { new CurvePart
          {
              CurveSegments = new List<CurveSegment>
              {
                  new BezierConicSegment
                  {
                      Vertices = new List<float3>
                      {
                          new float3(1,0,0),
                          new float3(2,0,0),
                          new float3(3,0,0)
                      }

                  },
                   new BezierConicSegment
                  {
                      Vertices = new List<float3>
                      {
                          new float3(1,0,0),
                          new float3(2,0,0),
                          new float3(3,0,0)
                      }

                  }
              }
          }
          }
            };


            return curve;
        }

        /// <summary>
        /// Get glyph info from letter
        /// </summary>
        /// <param name="c">letter char</param>
        /// <returns></returns>
        public GlyphInfo GetGlyphInfo(uint c)
        {
            GlyphInfo ret;

            var cp = new CodePoint((char)c);
            var glyph = _face.GetGlyph(cp, _pixelHeight);

            if (glyph == null)
            {
                return new GlyphInfo
                { Height = 1, Width = 1 };
            }

            ret.CharCode = c;
            ret.AdvanceX = glyph.HorizontalMetrics.Advance;
            ret.AdvanceY = glyph.VerticalMetrics.Advance;

            ret.Width = glyph.Width;
            ret.Height = glyph.Height;

            return ret;
        }

        public float GetKerning(uint leftC, uint rightC)
        {
            var kern = _face.GetKerning(new CodePoint((char)leftC), new CodePoint((char)rightC), PixelHeight);
            Diagnostics.Log($"Get kerning {kern}");
            return kern;

        }

        public float GetUnscaledAdvance(uint c)
        {
            var unscaledAdv = _face.GetGlyph(new CodePoint((char)c), 1).HorizontalMetrics.Advance;
            Diagnostics.Log($"Get advance {unscaledAdv}");
            return unscaledAdv;

        }

        public float GetUnscaledKerning(uint leftC, uint rightC)
        {
            // TODO: ?
            return _face.GetKerning(new CodePoint((char)leftC), new CodePoint((char)rightC), PixelHeight);
        }

        public IImageData RenderGlyph(uint c, out int bitmapLeft, out int bitmapTop)
        {
            var surface = RenderGlyph(_face, (char)c);
            var glyph = _face.GetGlyph(new CodePoint((char)c), PixelHeight);
            var metric = _face.GetFaceMetrics(PixelHeight);

            var ret = new ImageData(new byte[surface.Height * surface.Width], surface.Width, surface.Height, new ImagePixelFormat(ColorFormat.Intensity));

            bitmapLeft = 0;
            bitmapTop = 0;

            if (surface.Bits == IntPtr.Zero) return ret;

            var imgBytes = new byte[surface.Height * surface.Width];

            unsafe
            {
                var idx = 0;

                for (int y = 0; y < surface.Height; y++)
                {
                    var src = (byte*)surface.Bits + (y * surface.Pitch);

                    for (int x = 0; x < surface.Width; x++)
                    {
                        imgBytes[idx++] = *src++;
                    }
                }
            }

            ret.PixelData = imgBytes;

            bitmapTop = (int)(glyph.Height + glyph.VerticalMetrics.Bearing.Y);
            bitmapLeft = 0;


            return ret;
        }

        private unsafe Surface RenderGlyph(FontFace typeface, char c)
        {
            var glyph = typeface.GetGlyph(c, PixelHeight);
            if (glyph == null)
            {
                return new Surface
                {
                    Height = 1,
                    Width = 1
                };
            }

            var surface = new Surface
            {
                Bits = Marshal.AllocHGlobal(glyph.RenderWidth * glyph.RenderHeight),
                Width = glyph.RenderWidth,
                Height = glyph.RenderHeight,
                Pitch = glyph.RenderWidth
            };

            var stuff = (byte*)surface.Bits;

            for (int i = 0; i < surface.Width * surface.Height; i++)
                *stuff++ = 0;

            glyph.RenderTo(surface);

            return surface;
        }

    }
}
