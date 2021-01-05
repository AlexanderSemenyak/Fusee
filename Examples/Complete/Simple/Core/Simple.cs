using Fusee.Base.Common;
using Fusee.Base.Core;
using Fusee.Engine.Common;
using Fusee.Engine.Core;
using Fusee.Engine.Core.Effects;
using Fusee.Engine.Core.Scene;
using Fusee.Engine.Core.ShaderShards;
using Fusee.Engine.GUI;
using Fusee.Math.Core;
using Fusee.Serialization.V1;
using Fusee.Xene;
using System;
using System.Collections.Generic;
using System.Linq;
using static Fusee.Engine.Core.Input;
using static Fusee.Engine.Core.Time;
using CanvasRenderMode = Fusee.Engine.Core.Scene.CanvasRenderMode;

namespace Fusee.Examples.Simple.Core
{
    [FuseeApplication(Name = "FUSEE Simple Example", Description = "A very simple example.")]
    public class Simple : RenderCanvas
    {
        // angle variables
        private static float _angleHorz = M.PiOver3, _angleVert = -M.PiOver6 * 0.5f, _angleVelHorz, _angleVelVert;

        private const float RotationSpeed = 7;
        private const float Damping = 0.8f;

        private SceneContainer _rocketScene;
        private SceneContainer _monkeyScene;

        private SceneContainer _speraScene;
        private SceneContainer _kubScene;

        private SceneRendererForward _sceneRendererRocket;
        private SceneRendererForward _sceneRendererMonkey;

        private const float ZNear = 1f;
        private const float ZFar = 1000;
        private readonly float _fovy = M.PiOver4;

        private SceneRendererForward _guiRenderer;
        private SceneContainer _gui;
        private SceneInteractionHandler _sih;
        private readonly CanvasRenderMode _canvasRenderMode = CanvasRenderMode.Screen;

        private bool _keys;

        // Init is called on startup.
        public override void Init()
        {
            _gui = CreateGui();

            // Create the interaction handler
            _sih = new SceneInteractionHandler(_gui);

            // Set the clear color for the backbuffer to white (100% intensity in all color channels R, G, B, A).
            RC.ClearColor = new float4(1, 1, 1, 1);

            // Load the rocket model
            _kubScene = AssetStorage.Get<SceneContainer>("PAker.fus");
            _speraScene = AssetStorage.Get<SceneContainer>("МРГ.fus");

            //делаем едлиную модель из двух моделей
            var sc = new SceneContainer();
            sc.Children.AddRange(_kubScene.Children);

            //ищем максимальный Z у _rocketScene - обезьянку прямо точно перед ракетов поставим
            // float maxRocketZ = FindMaxZ(_rocketScene, out var minRocketZ);
            //  float maxMonkeyZ = FindMaxZ(_monkeyScene, out var minMonkeyZ);

            //  float maxRocketY = FindMaxY(_rocketScene, out var minRocketY);
            //   float maxMonkeyY = FindMaxY(_monkeyScene, out var minMonkeyY);
            //пробуем сместить координаты обезьяны
            //1._monkeyScene содержит один child у себя, но цикл все равно прогоняем, вдруг будет больше одного

            string namesphera = "PlaneXXX";
            float3 pointSphere = GetZForPointName(_speraScene, namesphera);

            string namekub = "Plane";
            float3 pointkub= GetZForPointName(_kubScene, namekub);

            foreach (SceneNode node in _speraScene.Children)
            {
             //   if (node.Name == namesphera) continue;
                //foreach (SceneNode child in node.Children)
               // {
                    //   чилдов нет у обезьянки, но могут быть в других моделях. пока оставляем для отладки
               // }
                //проходимся по компонентам каждого чилда
                //пока заметили три вида:
                //1.Transform - перенос, вращение, масштабирование
                //2.DefaultSurfaceEffect - ХЗ
                //3.Mesh - набор полигонов, составляющих объект

                foreach (var component in node.EnumComponents)
                {
                   
                    if (component is Transform t)
                    {
                        //переместим обезьянку
                        t.Translation = new float3(0, 0, pointSphere.z +7);
                        //  t.Translation = new float3(0, 0, (maxMonkeyZ - minMonkeyZ) / 2/*половинка обезьяны по Z*/ - (maxRocketZ - minRocketZ) / 2/*половинка ракеты по Z*/);
                       // t.Translation = new float3(0, 0, pointSphere.z);
                        continue;
                      
                    }

                    if (component is DefaultSurfaceEffect в)
                    {
                        //DefaultSurfaceEffect - ХЗ
                        continue;
                    }

                    if (component is Mesh m)
                    {
                        //Mesh - набор полигонов, составляющих объект
                        continue;
                    }

                    throw new NotSupportedException();
                }
            }
         
            sc.Children.AddRange(_speraScene.Children); //обезьяне надеваем на голову ракету 

            sc.Header = _kubScene.Header;

            _kubScene = sc;

            // Wrap a SceneRenderer around the model.
            _sceneRendererRocket = new SceneRendererForward(_kubScene);
            //_sceneRendererMonkey = new SceneRendererForward(_monkeyScene);
            _guiRenderer = new SceneRendererForward(_gui);
        }

  
        private float3 GetZForPointName(SceneContainer sceneContainer, string name)
        {
            float x = 0;
            float y = 0;
            float z = 0;
            foreach (SceneNode node in sceneContainer.Children)
            {
                if (node.Name == name)
                {
                        //у каждого чилда есть Mesh и DefaultSurfaceEffect - нас интересуют меши - там точки, среди них и ищем максимальную координату z
                        foreach (SceneComponent component in node.Components)
                        {
                            if (component is Mesh m)
                            {
                                foreach (var point in m.Vertices)
                                {
                                 x = point.x;
                                 y = point.y;
                                  z = point.z;
                                }
                            }
                        }
                }
            }

            return new float3(x, y, z);
        }

        private float FindMaxY(SceneContainer model, out float minY)
        {
            float MaxY(SceneComponent component, float oldMax)
            {
                if (component is Mesh m)
                {
                    foreach (var point in m.Vertices)
                    {
                        oldMax = System.Math.Max(point.y, oldMax); //ищем максимальный Z среди всех точек
                    }
                }

                return oldMax;
            }



            float MinY(SceneComponent component, float oldMin)
            {
                if (component is Mesh m)
                {
                    foreach (var point in m.Vertices)
                    {
                        oldMin = System.Math.Min(point.y, oldMin); //ищем максимальный Z среди всех точек
                    }
                }

                return oldMin;
            }

            float maxY = float.MinValue;
            minY = float.MaxValue;
            foreach (SceneNode node in model.Children)
            {
                //три набора элементов разного цвета для ракеты (серый, зеленый, белый,....) - по каждому проходимся и ищем максимальную координату Z - она в мэшах
                foreach (SceneNode child in node.Children)
                {
                    //у каждого чилда есть Mesh и DefaultSurfaceEffect - нас интересуют меши - там точки, среди них и ищем максимальную координату z
                    foreach (SceneComponent component in child.Components)
                    {
                        maxY = MaxY(component, maxY);
                        minY = MinY(component, minY);
                    }
                }

                foreach (SceneComponent component in node.Components)
                {
                    maxY = MaxY(component, maxY);
                    minY = MinY(component, minY);
                }
            }

            return maxY;

        }

        private float FindMaxZ(SceneContainer model, out float minZ)
        {
            float MaxZ(SceneComponent component, float oldMax)
            {
                if (component is Mesh m)
                {
                    foreach (var point in m.Vertices)
                    {
                        oldMax = System.Math.Max(point.z, oldMax); //ищем максимальный Z среди всех точек
                    }
                }

                return oldMax;
            }

            

                float MinZ(SceneComponent component, float oldMin)
                {
                    if (component is Mesh m)
                    {
                        foreach (var point in m.Vertices)
                        {
                            oldMin = System.Math.Min(point.z, oldMin); //ищем максимальный Z среди всех точек
                        }
                    }

                    return oldMin;
                }

                float maxZ = float.MinValue;
                minZ = float.MaxValue;
                foreach (SceneNode node in model.Children)
                {
                    //три набора элементов разного цвета для ракеты (серый, зеленый, белый,....) - по каждому проходимся и ищем максимальную координату Z - она в мэшах
                    foreach (SceneNode child in node.Children)
                    {
                        //у каждого чилда есть Mesh и DefaultSurfaceEffect - нас интересуют меши - там точки, среди них и ищем максимальную координату z
                        foreach (SceneComponent component in child.Components)
                        {
                            maxZ = MaxZ(component, maxZ);
                            minZ = MinZ(component, minZ);
                        }
                    }

                    foreach (SceneComponent component in node.Components)
                    {
                        maxZ = MaxZ(component, maxZ);
                        minZ = MinZ(component, minZ);
                    }
                }

                return maxZ;
            
        }

        // RenderAFrame is called once a frame
        public override void RenderAFrame()
        {
            // Clear the backbuffer
            RC.Clear(ClearFlags.Color | ClearFlags.Depth);

            RC.Viewport(0, 0, Width, Height);

            // Mouse and keyboard movement
            if (Keyboard.LeftRightAxis != 0 || Keyboard.UpDownAxis != 0)
            {
                _keys = true;
            }

            if (Mouse.LeftButton)
            {
                _keys = false;
                _angleVelHorz = -RotationSpeed * Mouse.XVel * DeltaTime * 0.0005f;
                _angleVelVert = -RotationSpeed * Mouse.YVel * DeltaTime * 0.0005f;
            }
            else if (Touch.GetTouchActive(TouchPoints.Touchpoint_0))
            {
                _keys = false;
                var touchVel = Touch.GetVelocity(TouchPoints.Touchpoint_0);
                _angleVelHorz = -RotationSpeed * touchVel.x * DeltaTime * 0.0005f;
                _angleVelVert = -RotationSpeed * touchVel.y * DeltaTime * 0.0005f;
            }
            else
            {
                if (_keys)
                {
                    _angleVelHorz = -RotationSpeed * Keyboard.LeftRightAxis * DeltaTime;
                    _angleVelVert = -RotationSpeed * Keyboard.UpDownAxis * DeltaTime;
                }
                else
                {
                    var curDamp = (float)System.Math.Exp(-Damping * DeltaTime);
                    _angleVelHorz *= curDamp;
                    _angleVelVert *= curDamp;
                }
            }

            _angleHorz += _angleVelHorz;
            _angleVert += _angleVelVert;

            // Create the camera matrix and set it as the current ModelView transformation
            var mtxRot = float4x4.CreateRotationX(_angleVert) * float4x4.CreateRotationY(_angleHorz);
            var mtxCam = float4x4.LookAt(0, +2, -10, 0, +2, 0, 0, 1, 0);

            var view = mtxCam * mtxRot;
            var perspective = float4x4.CreatePerspectiveFieldOfView(_fovy, (float)Width / Height, ZNear, ZFar);
            var orthographic = float4x4.CreateOrthographic(Width, Height, ZNear, ZFar);

            // Render the scene loaded in Init()
            RC.View = view;
            RC.Projection = perspective;
            _sceneRendererRocket.Render(RC);

            //переместим и смасштабируем головоу обезьянки
            //_sceneRendererMonkey.RenderTransform(new Transform()
            //{
            //    Translation = new float3(20,20,20),
            //    Scale = new float3(1.2f,2,4),
            //});

            //float4x4 mtxOffset = float4x4.CreateTranslation(0, 0, -0.3f); //трансофрмация - перемещение по 20 точек по x,y,z
            //RC.Projection = mtxOffset * RC.Projection; //сместим проекцию перед отрисовкой нового объекта
            //_sceneRendererMonkey.Render(RC);

            //Constantly check for interactive objects.

            RC.Projection = orthographic;
            if (!Mouse.Desc.Contains("Android"))
                _sih.CheckForInteractiveObjects(RC, Mouse.Position, Width, Height);
            if (Touch.GetTouchActive(TouchPoints.Touchpoint_0) && !Touch.TwoPoint)
            {
                _sih.CheckForInteractiveObjects(RC, Touch.GetPosition(TouchPoints.Touchpoint_0), Width, Height);
            }

            _guiRenderer.Render(RC);

            // Swap buffers: Show the contents of the backbuffer (containing the currently rendered frame) on the front buffer.
            Present();
        }

        private SceneContainer CreateGui()
        {
            var vsTex = AssetStorage.Get<string>("texture.vert");
            var psTex = AssetStorage.Get<string>("texture.frag");
            var psText = AssetStorage.Get<string>("text.frag");

            var canvasWidth = Width / 100f;
            var canvasHeight = Height / 100f;

            var btnFuseeLogo = new GUIButton
            {
                Name = "Canvas_Button"
            };
            btnFuseeLogo.OnMouseEnter += BtnLogoEnter;
            btnFuseeLogo.OnMouseExit += BtnLogoExit;
            btnFuseeLogo.OnMouseDown += BtnLogoDown;

            var guiFuseeLogo = new Texture(AssetStorage.Get<ImageData>("FuseeText.png"));
            var fuseeLogo = new TextureNode(
                "fuseeLogo",
                vsTex,
                psTex,
                //Set the albedo texture you want to use.
                guiFuseeLogo,
                //Define anchor points. They are given in percent, seen from the lower left corner, respectively to the width/height of the parent.
                //In this setup the element will stretch horizontally but stay the same vertically if the parent element is scaled.
                UIElementPosition.GetAnchors(AnchorPos.TopTopLeft),
                //Define Offset and therefor the size of the element.
                UIElementPosition.CalcOffsets(AnchorPos.TopTopLeft, new float2(0, canvasHeight - 0.5f), canvasHeight, canvasWidth, new float2(1.75f, 0.5f)),
                float2.One
                );
            fuseeLogo.AddComponent(btnFuseeLogo);

            var fontLato = AssetStorage.Get<Font>("Lato-Black.ttf");
            var guiLatoBlack = new FontMap(fontLato, 24);

            var text = new TextNode(
                "FUSEE Simple Example",
                "ButtonText",
                vsTex,
                psText,
                UIElementPosition.GetAnchors(AnchorPos.StretchHorizontal),
                UIElementPosition.CalcOffsets(AnchorPos.StretchHorizontal, new float2(canvasWidth / 2 - 4, 0), canvasHeight, canvasWidth, new float2(8, 1)),
                guiLatoBlack,
                (float4)ColorUint.Greenery,
                HorizontalTextAlignment.Center,
                VerticalTextAlignment.Center);

            var canvas = new CanvasNode(
                "Canvas",
                _canvasRenderMode,
                new MinMaxRect
                {
                    Min = new float2(-canvasWidth / 2, -canvasHeight / 2f),
                    Max = new float2(canvasWidth / 2, canvasHeight / 2f)
                })
            {
                Children = new ChildList()
                {
                    //Simple Texture Node, contains the fusee logo.
                    fuseeLogo,
                    text
                }
            };

            return new SceneContainer
            {
                Children = new List<SceneNode>
                {
                    //Add canvas.
                    canvas
                }
            };
        }

        public void BtnLogoEnter(CodeComponent sender)
        {
            var effect = _gui.Children.FindNodes(node => node.Name == "fuseeLogo").First().GetComponent<Effect>();
            effect.SetFxParam(UniformNameDeclarations.Albedo, (float4)ColorUint.Black);
            effect.SetFxParam(UniformNameDeclarations.AlbedoMix, 0.8f);
        }

        public void BtnLogoExit(CodeComponent sender)
        {
            var effect = _gui.Children.FindNodes(node => node.Name == "fuseeLogo").First().GetComponent<Effect>();
            effect.SetFxParam(UniformNameDeclarations.Albedo, float4.One);
            effect.SetFxParam(UniformNameDeclarations.AlbedoMix, 1f);
        }

        public void BtnLogoDown(CodeComponent sender)
        {
            OpenLink("http://fusee3d.org");
        }
    }
}