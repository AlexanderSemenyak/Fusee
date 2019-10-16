﻿using Fusee.Base.Common;
using Fusee.Base.Core;
using Fusee.Base.Imp.WebAsm;
using Fusee.Engine.Core;
using Fusee.Engine.Imp.Graphics.WebAsm;
using Fusee.Serialization;
using SkiaSharp;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using Typography.OpenFont;
//using Typography.TextLayout;
using FileMode = Fusee.Base.Common.FileMode;
using Path = Fusee.Base.Common.Path;


namespace Fusee.Examples.RocketOnly.Main
{
    internal static class Program
    {
        public static void Main()
        {
            // This method takes care of everything
            WebAsmProgram.Start(new Main());
        }
    }

    public class Main : WebAsmBase
    {
        private RenderCanvasImp _canvasImp;
        private Core.RocketOnly _app;

        public override void Run()
        {
            base.Run();

            // Inject Fusee.Engine.Base InjectMe dependencies
            IO.IOImp = new Fusee.Base.Imp.WebAsm.IOImp();

            var fap = new Fusee.Base.Imp.WebAsm.AssetProvider();
            fap.RegisterTypeHandler(
                new AssetHandler
                {
                    ReturnedType = typeof(Font),
                    DecoderAsync = async (string id, object storage) =>
                    {
                        if (Path.GetExtension(id).IndexOf("ttf", System.StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            var font = new Font
                            {
                                _fontImp = new FontImp((Stream)storage)
                            };

                            return font;
                        }

                        return null;
                    },
                    Checker = (string id) =>
                    {
                        return Path.GetExtension(id).IndexOf("ttf", System.StringComparison.OrdinalIgnoreCase) >= 0;
                    }
                });
            
            fap.RegisterTypeHandler(
                new AssetHandler
                {
                    ReturnedType = typeof(SceneContainer),
                    DecoderAsync = async (string id, object storage) => // ignore the lack of await
                    {
                        if (Path.GetExtension(id).IndexOf("fus", System.StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            var storageStream = (Stream)storage;
                            var ser = new Serializer();
                            return new ConvertSceneGraph().Convert(ser.Deserialize(storageStream, null, typeof(SceneContainer)) as SceneContainer);
                        }
                        return null;
                    },
                    Checker = (string id) =>
                    {
                        return Path.GetExtension(id).IndexOf("fus", System.StringComparison.OrdinalIgnoreCase) >= 0;
                    }
                });

            // Image handler
            fap.RegisterTypeHandler(new AssetHandler
            {
                ReturnedType = typeof(Base.Core.ImageData),
                DecoderAsync = async (string id, object storage) =>
                {
                    var ext = Path.GetExtension(id).ToLower();
                    switch (ext)
                    {
                        //case ".jpg": // not possible YET!
                       // case ".jpeg":
                        case ".png":
                        case ".bmp":
                            // handle file
                            Console.WriteLine("Found image, processing");

                            using (var bitmap = SKBitmap.Decode((Stream)storage))
                            {
                                var rotated = new SKBitmap(bitmap.Width, bitmap.Height, true);
                                //rotated.ColorType = bitmap.ColorType;
                                //rotated.AlphaType = bitmap.AlphaType;

                                using (var surface = new SKCanvas(rotated))
                                {
                                    surface.Clear();                                    
                                    surface.Scale(1, -1, 0, bitmap.Height / 2.0f); // this mirrors the image within its' x-axis
                                    surface.DrawBitmap(bitmap, 0, 0);
                                }
                                Console.WriteLine($"Found image, {rotated.Width}, {rotated.Height}");

                                var data = new Base.Core.ImageData(rotated.Width, rotated.Height)
                                {
                                    PixelData = rotated.Bytes
                                };

                                return data;
                            }
                    }
                    return null;
                },
                Checker = (string id) =>
                {
                    var ext = Path.GetExtension(id).ToLower();
                    switch (ext)
                    {
                       // case ".jpg":
                       // case ".jpeg":
                        case ".png":
                        case ".bmp":
                            return true;
                    }
                    return false;
                }
            });

            AssetStorage.RegisterProvider(fap);

            _app = new Core.RocketOnly();

            // Inject Fusee.Engine InjectMe dependencies (hard coded)
            _canvasImp = new RenderCanvasImp(canvas, gl, canvasWidth, canvasHeight);
            _app.CanvasImplementor = _canvasImp;
            _app.ContextImplementor = new RenderContextImp(_app.CanvasImplementor);
            Input.AddDriverImp(new RenderCanvasInputDriverImp(_app.CanvasImplementor));

            // Start the app
            _app.Run();

            LoadRocket();

        }

        private async void LoadRocket()
        {
            //var stream = await WasmResourceLoader.LoadAsync("Assets/FUSEERocket.fus", WasmResourceLoader.GetLocalAddress());
           // var seri = new Serializer();
           // _app.RocketScene = new ConvertSceneGraph().Convert(seri.Deserialize(stream, null, typeof(SceneContainer)) as SceneContainer);

        }

        public override void Update(double elapsedMilliseconds)
        {
            if (_canvasImp != null)
                _canvasImp.DeltaTime = (float)(elapsedMilliseconds / 1000.0);
        }

        public override void Draw()
        {
            _canvasImp?.DoRender();
        }

        public override void Resize(int width, int height)
        {
            base.Resize(width, height);
            _canvasImp.DoResize(width, height);
        }
    }
}
