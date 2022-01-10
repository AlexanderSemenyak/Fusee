using Fusee.Base.Core;
using Fusee.Engine.Common;
using Fusee.Engine.Core;
using Fusee.Engine.Core.Scene;
using Fusee.Engine.Gui;
using Fusee.Math.Core;
using Fusee.Serialization.V1;
using Fusee.Xene;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

/* Unmerged change from project 'Fusee.Examples.Simple.Core(net6.0)'
Before:
        private readonly float _fovy = M.PiOver4;

        private SceneRendererForward _guiRenderer;
        private SceneContainer _gui;
        private SceneInteractionHandler _sih;
After:
        private readonly SceneContainer _monkeyScene;

        private readonly SceneContainer _speraScene;
        private SceneContainer _kubScene;
*/
        private readonly 
/* Unmerged change from project 'Fusee.Examples.Simple.Core(net6.0)'
Before:
        private bool _keys;

        private async Task Load()
        {
            Console.WriteLine("Loading scene ...");

            _gui = await FuseeGuiHelper.CreateDefaultGuiAsync(this, CanvasRenderMode.Screen, "FUSEE Simple Example");

            // Create the interaction handler
            _sih = new SceneInteractionHandler(_gui);

            // Load the rocket model
            _rocketScene = await AssetStorage.GetAsync<SceneContainer>("RocketFus.fus");

            //������ ������� ������ �� ���� �������
            var sc = new SceneContainer();
            sc.Children.AddRange(_kubScene.Children);

            //���� ������������ Z � _rocketScene - ��������� ����� ����� ����� ������� ��������
            // float maxRocketZ = FindMaxZ(_rocketScene, out var minRocketZ);
            //  float maxMonkeyZ = FindMaxZ(_monkeyScene, out var minMonkeyZ);

            //  float maxRocketY = FindMaxY(_rocketScene, out var minRocketY);
            //   float maxMonkeyY = FindMaxY(_monkeyScene, out var minMonkeyY);
            //������� �������� ���������� ��������
            //1._monkeyScene �������� ���� child � ����, �� ���� ��� ����� ���������, ����� ����� ������ ������

            string namesphera = "PlaneXXX";
            float3 pointSphere = GetZForPointName(_speraScene, namesphera);

            string namekub = "Plane";
            float3 pointkub = GetZForPointName(_kubScene, namekub);

            var delta = pointkub - pointSphere;

            foreach (SceneNode node in _speraScene.Children)
            {
                if (node.Name == namesphera) continue;
                //foreach (SceneNode child in node.Children)
                // {
                //   ������ ��� � ���������, �� ����� ���� � ������ �������. ���� ��������� ��� �������
                // }
                //���������� �� ����������� ������� �����
                //���� �������� ��� ����:
                //1.Transform - �������, ��������, ���������������
                //2.DefaultSurfaceEffect - ��
                //3.Mesh - ����� ���������, ������������ ������

                foreach (var component in node.EnumComponents)
                {

                    if (component is Transform t)
                    {
                        t.Translation += delta;
                        //���������� ���������
                        //  t.Translation = new float3(0, 0, pointSphere.z + 7);
                        //  t.Translation = new float3(0, 0, (maxMonkeyZ - minMonkeyZ) / 2/*��������� �������� �� Z*/ - (maxRocketZ - minRocketZ) / 2/*��������� ������ �� Z*/);
                        // t.Translation = new float3(0, 0, pointSphere.z);
                        continue;

                    }

                    if (component is DefaultSurfaceEffect �)
                    {
                        //DefaultSurfaceEffect - ��
                        continue;
                    }

                    if (component is Mesh m)
                    {
                        //Mesh - ����� ���������, ������������ ������
                        continue;
                    }

                    throw new NotSupportedException();
                }
            }

            sc.Children.AddRange(_speraScene.Children); //�������� �������� �� ������ ������ 

            sc.Header = _kubScene.Header;

            _kubScene = sc;

            // Wrap a SceneRenderer around the model.
            _sceneRendererRocket = new SceneRendererForward(_kubScene);
            //_sceneRendererMonkey = new SceneRendererForward(_monkeyScene);
            _guiRenderer = new SceneRendererForward(_gui);
        }


        private float3 GetZForPointName(SceneContainer sceneContainer, string name)
        {
            foreach (SceneNode node in sceneContainer.Children)
            {
                if (node.Name == name)
                {
                    var mesh = node.GetComponent<Mesh>();
                    var transform = node.GetComponent<Transform>();

                    var matrix = transform.Matrix();
                    var v0 = mesh.Vertices[0];
                    var v0Transformed = matrix * v0;
= v0Transformed * matrix.Invert();

                    var ����������� = matrix.ScaleComponent();
                    var ��������������� = matrix.TranslationComponent();
                    var ������������ = matrix.RotationComponent();


                    return v0Transformed;

                    //� ������� ����� ���� Mesh � DefaultSurfaceEffect - ��� ���������� ���� - ��� �����, ����� ��� � ���� ������������ ���������� z
                    //foreach (SceneComponent component in node.Components)
                    //{

                    //    if (component is Transform t)
                    //    {

                    //    }

                    //    if (component is Mesh m)
                    //    {
                    //        foreach (var point in m.Vertices)
                    //        {
                    //            x = point.x;
                    //            y = point.y;
                    //            z = point.z;
                    //        }
                    //    }
                    //}
                }
            }

            return new float3(0, 0, 0);
        }
After:
        private SceneRendererForward _sceneRendererRocket;
        private readonly SceneRendererForward _sceneRendererMonkey;
*/
SceneContainer _monkeyScene;

        private readonly SceneContainer _speraScene;
        private SceneContainer _kubScene;

        private SceneRendererForward _sceneRendererRocket;
        private readonly SceneRendererForward _sceneRendererMonkey;

        private const float ZNear = 1f;
        private const float ZFar = 1000;
        private readonly float _fovy = M.PiOver4;

        private SceneRendererForward _guiRenderer;
        private SceneContainer _gui;
        private SceneInteractionHandler _sih;

        private bool _keys;

        private async Task Load()
        {
            Console.WriteLine("Loading scene ...");

            _gui = await FuseeGuiHelper.CreateDefaultGuiAsync(this, CanvasRenderMode.Screen, "FUSEE Simple Example");

            // Create the interaction handler
            _sih = new SceneInteractionHandler(_gui);

            // Load the rocket model
            _rocketScene = await AssetStorage.GetAsync<SceneContainer>("RocketFus.fus");

            //������ ������� ������ �� ���� �������
            var sc = new SceneContainer();
            sc.Children.AddRange(_kubScene.Children);

            //���� ������������ Z � _rocketScene - ��������� ����� ����� ����� ������� ��������
            // float maxRocketZ = FindMaxZ(_rocketScene, out var minRocketZ);
            //  float maxMonkeyZ = FindMaxZ(_monkeyScene, out var minMonkeyZ);

            //  float maxRocketY = FindMaxY(_rocketScene, out var minRocketY);
            //   float maxMonkeyY = FindMaxY(_monkeyScene, out var minMonkeyY);
            //������� �������� ���������� ��������
            //1._monkeyScene �������� ���� child � ����, �� ���� ��� ����� ���������, ����� ����� ������ ������

            string namesphera = "PlaneXXX";
            float3 pointSphere = GetZForPointName(_speraScene, namesphera);

            string namekub = "Plane";
            float3 pointkub = GetZForPointName(_kubScene, namekub);

            var delta = pointkub - pointSphere;

            foreach (SceneNode node in _speraScene.Children)
            {
                if (node.Name == namesphera) continue;
                //foreach (SceneNode child in node.Children)
                // {
                //   ������ ��� � ���������, �� ����� ���� � ������ �������. ���� ��������� ��� �������
                // }
                //���������� �� ����������� ������� �����
                //���� �������� ��� ����:
                //1.Transform - �������, ��������, ���������������
                //2.DefaultSurfaceEffect - ��
                //3.Mesh - ����� ���������, ������������ ������

                foreach (var component in node.EnumComponents)
                {

                    if (component is Transform t)
                    {
                        t.Translation += delta;
                        //���������� ���������
                        //  t.Translation = new float3(0, 0, pointSphere.z + 7);
                        //  t.Translation = new float3(0, 0, (maxMonkeyZ - minMonkeyZ) / 2/*��������� �������� �� Z*/ - (maxRocketZ - minRocketZ) / 2/*��������� ������ �� Z*/);
                        // t.Translation = new float3(0, 0, pointSphere.z);
                        continue;

                    }

                    if (component is DefaultSurfaceEffect �)
                    {
                        //DefaultSurfaceEffect - ��
                        continue;
                    }

                    if (component is Mesh m)
                    {
                        //Mesh - ����� ���������, ������������ ������
                        continue;
                    }

                    throw new NotSupportedException();
                }
            }

            sc.Children.AddRange(_speraScene.Children); //�������� �������� �� ������ ������ 

            sc.Header = _kubScene.Header;

            _kubScene = sc;

            // Wrap a SceneRenderer around the model.
            _sceneRendererRocket = new SceneRendererForward(_kubScene);
            //_sceneRendererMonkey = new SceneRendererForward(_monkeyScene);
            _guiRenderer = new SceneRendererForward(_gui);
        }


        private float3 GetZForPointName(SceneContainer sceneContainer, string name)
        {
            foreach (SceneNode node in sceneContainer.Children)
            {
                if (node.Name == name)
                {
                    var mesh = node.GetComponent<Mesh>();
                    var transform = node.GetComponent<Transform>();

                    var matrix = transform.Matrix();
                    var v0 = mesh.Vertices[0];
                    var v0Transformed = matrix * v0;
= v0Transformed * matrix.Invert();

                    var ����������� = matrix.ScaleComponent();
                    var ��������������� = matrix.TranslationComponent();
                    var ������������ = matrix.RotationComponent();


                    return v0Transformed;

                    //� ������� ����� ���� Mesh � DefaultSurfaceEffect - ��� ���������� ���� - ��� �����, ����� ��� � ���� ������������ ���������� z
                    //foreach (SceneComponent component in node.Components)
                    //{

                    //    if (component is Transform t)
                    //    {

                    //    }

                    //    if (component is Mesh m)
                    //    {
                    //        foreach (var point in m.Vertices)
                    //        {
                    //            x = point.x;
                    //            y = point.y;
                    //            z = point.z;
                    //        }
                    //    }
                    //}
                }
            }

            return new float3(0, 0, 0);
        }

        private float FindMaxY(SceneContainer model, out float minY)
        {
            float MaxY(SceneComponent component, float oldMax)
            {
                if (component is Mesh m)
                {
                    foreach (var point in m.Vertices)
                    {
                        oldMax = System.Math.Max(point.y, oldMax); //���� ������������ Z ����� ���� �����
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
                        oldMin = System.Math.Min(point.y, oldMin); //���� ������������ Z ����� ���� �����
                    }
                }

                return oldMin;
            }

            float maxY = float.MinValue;
            minY = float.MaxValue;
            foreach (SceneNode node in model.Children)
            {
                //��� ������ ��������� ������� ����� ��� ������ (�����, �������, �����,....) - �� ������� ���������� � ���� ������������ ���������� Z - ��� � �����
                foreach (SceneNode child in node.Children)
                {
                    //� ������� ����� ���� Mesh � DefaultSurfaceEffect - ��� ���������� ���� - ��� �����, ����� ��� � ���� ������������ ���������� z
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
                        oldMax = System.Math.Max(point.z, oldMax); //���� ������������ Z ����� ���� �����
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
                        oldMin = System.Math.Min(point.z, oldMin); //���� ������������ Z ����� ���� �����
                    }
                }

                return oldMin;
            }

            float maxZ = float.MinValue;
            minZ = float.MaxValue;
            foreach (SceneNode node in model.Children)
            {
                //��� ������ ��������� ������� ����� ��� ������ (�����, �������, �����,....) - �� ������� ���������� � ���� ������������ ���������� Z - ��� � �����
                foreach (SceneNode child in node.Children)
                {
                    //� ������� ����� ���� Mesh � DefaultSurfaceEffect - ��� ���������� ���� - ��� �����, ����� ��� � ���� ������������ ���������� z
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

        public override async Task InitAsync()
        {
            await Load();
            await base.InitAsync();
        }

        // Init is called on startup.
        public override void Init()
        {
            // Set the clear color for the backbuffer to white (100% intensity in all color channels R, G, B, A).
            RC.ClearColor = new float4(1, 1, 1, 1);
        }

        public override void Update()
        {
            // Mouse and keyboard movement
            if (Keyboard.LeftRightAxis != 0 || Keyboard.UpDownAxis != 0)
            {
                _keys = true;
            }

            if (Mouse.LeftButton)
            {
                _keys = false;
                _angleVelHorz = -RotationSpeed * Mouse.XVel * DeltaTimeUpdate * 0.0005f;
                _angleVelVert = -RotationSpeed * Mouse.YVel * DeltaTimeUpdate * 0.0005f;
            }
            else if (Touch != null && Touch.GetTouchActive(TouchPoints.Touchpoint_0))
            {
                _keys = false;
                var touchVel = Touch.GetVelocity(TouchPoints.Touchpoint_0);
                _angleVelHorz = -RotationSpeed * touchVel.x * DeltaTimeUpdate * 0.0005f;
                _angleVelVert = -RotationSpeed * touchVel.y * DeltaTimeUpdate * 0.0005f;
            }
            else
            {
                if (_keys)
                {
                    _angleVelHorz = -RotationSpeed * Keyboard.LeftRightAxis * DeltaTimeUpdate;
                    _angleVelVert = -RotationSpeed * Keyboard.UpDownAxis * DeltaTimeUpdate;
                }
                else
                {
                    var curDamp = (float)System.Math.Exp(-Damping * DeltaTimeUpdate);
                    _angleVelHorz *= curDamp;
                    _angleVelVert *= curDamp;
                }
            }

            _angleHorz += _angleVelHorz;
            _angleVert += _angleVelVert;
        }


        // RenderAFrame is called once a frame
        public override void RenderAFrame()
        {
            // Clear the backbuffer
            RC.Clear(ClearFlags.Color | ClearFlags.Depth);

            RC.Viewport(0, 0, Width, Height);

            // Create the camera matrix and set it as the current ModelView transformation
            var mtxRot = float4x4.CreateRotationX(_angleVert) * float4x4.CreateRotationY(_angleHorz);
            var mtxCam = float4x4.LookAt(0, 2, -10, 0, 2, 0, 0, 1, 0);

            var view = mtxCam * mtxRot;
            var perspective = float4x4.CreatePerspectiveFieldOfView(_fovy, (float)Width / Height, ZNear, ZFar);
            var orthographic = float4x4.CreateOrthographic(Width, Height, ZNear, ZFar);

            // Render the scene loaded in Init()
            RC.View = view;
            RC.Projection = perspective;
            _sceneRendererRocket.Render(RC);

            //���������� � ������������� ������� ���������
            //_sceneRendererMonkey.RenderTransform(new Transform()
            //{
            //    Translation = new float3(20,20,20),
            //    Scale = new float3(1.2f,2,4),
            //});

            //float4x4 mtxOffset = float4x4.CreateTranslation(0, 0, -0.3f); //������������� - ����������� �� 20 ����� �� x,y,z
            //RC.Projection = mtxOffset * RC.Projection; //������� �������� ����� ���������� ������ �������
            //_sceneRendererMonkey.Render(RC);

            //Constantly check for interactive objects.
            RC.View = float4x4.LookAt(0, 0, 1, 0, 0, 0, 0, 1, 0);
            RC.Projection = orthographic;
            if (!Mouse.Desc.Contains("Android"))
                _sih.CheckForInteractiveObjects(RC, Mouse.Position, Width, Height);
            if (Touch != null && Touch.GetTouchActive(TouchPoints.Touchpoint_0) && !Touch.TwoPoint)
            {
                _sih.CheckForInteractiveObjects(RC, Touch.GetPosition(TouchPoints.Touchpoint_0), Width, Height);
            }

            _guiRenderer.Render(RC);

            // Swap buffers: Show the contents of the backbuffer (containing the currently rendered frame) on the front buffer.
            Present();
        }
    }
}