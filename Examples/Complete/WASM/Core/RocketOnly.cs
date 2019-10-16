using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fusee.Base.Common;
using Fusee.Base.Core;
using Fusee.Base.Imp.WebAsm;
using Fusee.Engine.Common;
using Fusee.Engine.Core;
using Fusee.Engine.GUI;
using Fusee.Examples.UI.Core;
using Fusee.Math.Core;
using Fusee.Serialization;
using Fusee.Xene;
using static Fusee.Engine.Core.Input;
using static Fusee.Engine.Core.Time;

namespace Fusee.Examples.RocketOnly.Core
{
    [FuseeApplication(Name = "FUSEE Rocket Only Example", Description = "An even simpler example.")]
    public class RocketOnly : RenderCanvas
    {
        // angle variables
        private static float _angleHorz = M.PiOver3, _angleVert = -M.PiOver6 * 0.5f, _angleVelHorz, _angleVelVert;

        private const float RotationSpeed = 7;
        private const float Damping = 0.8f;

        private SceneContainer _rocketScene;
        private SceneContainer _scene;
        private SceneRenderer _sceneRenderer;

        private TransformComponent _cubeTransform;
        private const float ZNear = 1f;
        private const float ZFar = 1000;
        private float _fovy = M.PiOver4;

        private SceneRenderer _guiRenderer;

        private bool _keys;

        public string VertexShader = "";
        public string PixelShader = "";
        public ImageData CurrentTex;

        private readonly CanvasRenderMode _canvasRenderMode = CanvasRenderMode.SCREEN;


        private SceneContainer _gui;

        // Init is called on startup. 
        public async override void Init()
        {
            // Set the clear color for the backbuffer to white (100% intensity in all color channels R, G, B, A).
            RC.ClearColor = new float4(1, 1, 1, 1);

            Console.WriteLine("trying to get asset");
            var readVar = await AssetStorage.GetAsync<string>("Assets/LoremIpsum.txt");
            Console.WriteLine(readVar);

            RocketScene = await AssetStorage.GetAsync<SceneContainer>("Assets/FUSEERocket.fus");
            Console.WriteLine(_rocketScene.Children[0].Components[0].Name);
            Console.WriteLine(_rocketScene.Children.Count());

            var x = await AssetStorage.GetAsync<ImageData>("Assets/knight.png");
            Console.WriteLine($"ImageData {x.Height}:{x.Width}");

            var fontLato = await AssetStorage.GetAsync<Font>("Assets/Lato-Black.ttf");
            var guiLatoBlack = new FontMap(fontLato, 18);
            var y = new GUIText(guiLatoBlack, "Hello World");

            Gui = await CreateGui();

            RocketScene.Children.Add(new SceneNodeContainer
            {
                Components = new System.Collections.Generic.List<SceneComponentContainer>
                {
                    new TransformComponent
                    {
                        Rotation = new float3(M.Pi, 0 ,0),
                        Scale = float3.One * 5,
                        Translation = new float3(-5,0,3)
                    },
                    new ShaderEffectComponent
                    {
                        Effect = new ShaderEffect(new EffectPassDeclaration[] {
                            new EffectPassDeclaration
                            {
                                VS = @"#version 300 es 
in vec3 fuVertex;
in vec3 fuNormal;
in vec2 fuUV;

out vec3 vNormal;
out vec2 vUV;

uniform mat4 FUSEE_MVP;


void main(void){

vNormal = normalize(fuNormal);
vUV = fuUV;

gl_Position = FUSEE_MVP * vec4(fuVertex, 1.0);

}",

                                PS = @"#version 300 es 

precision highp float;


in vec3 vNormal;
in vec2 vUV;

uniform sampler2D Texture;


out vec4 oColor;

void main(void)
{
    oColor = texture(Texture, vUV);
}
",
                                StateSet = new RenderStateSet
                                {
                                    AlphaBlendEnable = true,
                                    ZEnable = true
                                }
                            }

                        }, new List<EffectParameterDeclaration>
                        {
                            new EffectParameterDeclaration
                            {
                                Name = "FUSEE_MVP",
                                Value = float4x4.Identity
                            },
                            new EffectParameterDeclaration
                            {
                                Name = "Texture",
                                Value = new Texture(guiLatoBlack.Image)
                            },
                        })

                    },
                    //new Cube(),
                    y
                }
            }); ;

            //RocketScene.Children[RocketScene.Children.Count - 1].GetComponent<ShaderEffectComponent>().Effect.SetEffectParam("Texture", new Texture(x));
        }

        public SceneContainer RocketScene
        {
            get => _rocketScene;
            set
            {
                _rocketScene = value;

                //Add resize delegate
                var projComp = _rocketScene.Children[0].GetComponent<ProjectionComponent>();
                AddResizeDelegate(delegate { projComp.Resize(Width, Height); });
                _sceneRenderer = new SceneRenderer(_rocketScene);
                Diagnostics.Log("Rocket Set");
                projComp.Resize(Width, Height);
            }
        }

        
        

        public SceneContainer Gui
        {
            get => _gui;
            set
            {
                _gui = value;

                //Add resize delegate
                //var projComp = _rocketScene.Children[0].GetComponent<ProjectionComponent>();
                //AddResizeDelegate(delegate { projComp.Resize(Width, Height); });
                _guiRenderer = new SceneRenderer(_gui);
                _gui.Children[0].GetComponent<ProjectionComponent>().Resize(Width, Height);
                Diagnostics.Log("GUI Set");
                //projComp.Resize(Width, Height);
            }
        }


        // RenderAFrame is called once a frame
        public override void RenderAFrame()
        {
            // Clear the backbuffer
            RC.Clear(ClearFlags.Color | ClearFlags.Depth);

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
            RC.View = mtxCam * mtxRot;

            // Render the scene   
            if(_sceneRenderer != null)
                _sceneRenderer.Render(RC);

            if (_gui != null)
                _guiRenderer.Render(RC);

            // Swap buffers: Show the contents of the backbuffer (containing the currently rendered frame) on the front buffer.
            Present();
        }

        // Is called when the window was resized
        public override void Resize(ResizeEventArgs rea)
        {
            // Set the new rendering area to the entire new windows size
            RC.Viewport(0, 0, Width, Height);

            // Create a new projection matrix generating undistorted images on the new aspect ratio.
            var aspectRatio = Width / (float)Height;

            // 0.25*PI Rad -> 45° Opening angle along the vertical direction. Horizontal opening angle is calculated based on the aspect ratio
            // Front clipping happens at 0.01 (Objects nearer than 1 world unit get clipped)
            // Back clipping happens at 200 (Anything further away from the camera than 200 world units gets clipped, polygons will be cut)
            var projection = float4x4.CreatePerspectiveFieldOfView(M.PiOver4, aspectRatio, 0.01f, 200.0f);
            RC.Projection = projection;
        }

        private async Task<SceneContainer> CreateGui()
        {
            var vsTex = await AssetStorage.GetAsync<string>("Assets/texture.vert");
            var psTex = await AssetStorage.GetAsync<string>("Assets/texture.frag");

            var canvasWidth = Width / 100f;
            var canvasHeight = Height / 100f;

            var btnFuseeLogo = new GUIButton
            {
                Name = "Canvas_Button"
            };
            btnFuseeLogo.OnMouseEnter += BtnLogoEnter;
            btnFuseeLogo.OnMouseExit += BtnLogoExit;
            btnFuseeLogo.OnMouseDown += BtnLogoDown;

            var guiFuseeLogo = new Texture(await AssetStorage.GetAsync<ImageData>("Assets/FuseeText.png"));
            var fuseeLogo = new TextureNodeContainer(
                "fuseeLogo",
                vsTex,
                psTex,
                //Set the diffuse texture you want to use.
                guiFuseeLogo,
                //Define anchor points. They are given in percent, seen from the lower left corner, respectively to the width/height of the parent.
                //In this setup the element will stretch horizontally but stay the same vertically if the parent element is scaled.
                UIElementPosition.GetAnchors(AnchorPos.TOP_TOP_LEFT),
                //Define Offset and therefor the size of the element.                
                UIElementPosition.CalcOffsets(AnchorPos.TOP_TOP_LEFT, new float2(0, canvasHeight - 0.5f), canvasHeight, canvasWidth, new float2(1.75f, 0.5f))
                );
            fuseeLogo.AddComponent(btnFuseeLogo);

            var fontLato = await AssetStorage.GetAsync<Font>("Assets/Lato-Black.ttf");
            var guiLatoBlack = new FontMap(fontLato, 18);

            Diagnostics.Log($"~~ {guiLatoBlack.Alphabet} loaded");
            Diagnostics.Log($"~~ {guiLatoBlack.Image.Width} image width");

            var text = new TextNodeContainer(
                "FUSEE Simple Example",
                "ButtonText",
                vsTex,
                psTex,
                UIElementPosition.GetAnchors(AnchorPos.STRETCH_HORIZONTAL),
                UIElementPosition.CalcOffsets(AnchorPos.STRETCH_HORIZONTAL, new float2(canvasWidth / 2 - 4, 0), canvasHeight, canvasWidth, new float2(8, 1)),
                guiLatoBlack,
                ColorUint.Tofloat4(ColorUint.Greenery), 250f);


            var canvas = new CanvasNodeContainer(
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

            var canvasProjComp = new ProjectionComponent(ProjectionMethod.ORTHOGRAPHIC, ZNear, ZFar, _fovy);
            canvas.Components.Insert(0, canvasProjComp);
            AddResizeDelegate(delegate { canvasProjComp.Resize(Width, Height); });

            return new SceneContainer
            {
                Children = new List<SceneNodeContainer>
                {
                    //Add canvas.
                    canvas
                }
            };
        }

        public void BtnLogoEnter(CodeComponent sender)
        {
            _gui.Children.FindNodes(node => node.Name == "fuseeLogo").First().GetComponent<ShaderEffectComponent>().Effect.SetEffectParam("DiffuseColor", new float4(0.8f, 0.8f, 0.8f, 1f));
        }

        public void BtnLogoExit(CodeComponent sender)
        {
            _gui.Children.FindNodes(node => node.Name == "fuseeLogo").First().GetComponent<ShaderEffectComponent>().Effect.SetEffectParam("DiffuseColor", float4.One);
        }

        public void BtnLogoDown(CodeComponent sender)
        {
            OpenLink("http://fusee3d.org");
        }
    }
}

  