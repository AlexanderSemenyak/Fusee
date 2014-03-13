/* Generated by JSIL v0.7.8 build 970. See http://jsil.org/ for more information. */ 
var $asm00 = JSIL.DeclareAssembly("Examples.SceneViewer, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null");

JSIL.SetEntryPoint($asm00, $asm00.TypeRef("Examples.SceneViewer.SceneViewer"), "Main", new JSIL.MethodSignature(null, []));

JSIL.DeclareNamespace("Examples");
JSIL.DeclareNamespace("Examples.SceneViewer");
/* class Examples.SceneViewer.SceneViewer */ 

(function SceneViewer$Members () {
  var $, $thisType;
  var $T00 = function () {
    return ($T00 = JSIL.Memoize($asm02.Fusee.Engine.RenderCanvas)) ();
  };
  var $T01 = function () {
    return ($T01 = JSIL.Memoize($asm02.Fusee.Engine.GUIButton)) ();
  };
  var $T02 = function () {
    return ($T02 = JSIL.Memoize($asm01.Fusee.Engine.MouseEventArgs)) ();
  };
  var $T03 = function () {
    return ($T03 = JSIL.Memoize($asm03.Fusee.Math.float4)) ();
  };
  var $T04 = function () {
    return ($T04 = JSIL.Memoize($asm01.Fusee.Engine.CursorType)) ();
  };
  var $T05 = function () {
    return ($T05 = JSIL.Memoize($asm02.Fusee.Engine.GUIHandler)) ();
  };
  var $T06 = function () {
    return ($T06 = JSIL.Memoize($asm02.Fusee.Engine.GUIButtonHandler)) ();
  };
  var $T07 = function () {
    return ($T07 = JSIL.Memoize($asm02.Fusee.Engine.GUIImage)) ();
  };
  var $T08 = function () {
    return ($T08 = JSIL.Memoize($asm02.Fusee.Engine.RenderContext)) ();
  };
  var $T09 = function () {
    return ($T09 = JSIL.Memoize($asm02.Fusee.Engine.GUIText)) ();
  };
  var $T0A = function () {
    return ($T0A = JSIL.Memoize($asm02.Fusee.Engine.GUIElement)) ();
  };
  var $T0B = function () {
    return ($T0B = JSIL.Memoize($asm05.Fusee.Serialization.Serializer)) ();
  };
  var $T0C = function () {
    return ($T0C = JSIL.Memoize($asm06.System.IO.FileStream)) ();
  };
  var $T0D = function () {
    return ($T0D = JSIL.Memoize($asm06.System.IO.File)) ();
  };
  var $T0E = function () {
    return ($T0E = JSIL.Memoize($asm04.Fusee.Serialization.SceneContainer)) ();
  };
  var $T0F = function () {
    return ($T0F = JSIL.Memoize($asm07.ProtoBuf.Meta.TypeModel)) ();
  };
  var $T10 = function () {
    return ($T10 = JSIL.Memoize($asm06.System.IDisposable)) ();
  };
  var $T11 = function () {
    return ($T11 = JSIL.Memoize($asm00.Examples.SceneViewer.SceneRenderer)) ();
  };
  var $T12 = function () {
    return ($T12 = JSIL.Memoize($asm06.System.String)) ();
  };
  var $T13 = function () {
    return ($T13 = JSIL.Memoize($asm06.System.Void)) ();
  };
  var $T14 = function () {
    return ($T14 = JSIL.Memoize($asm02.Fusee.Engine.MoreShaders)) ();
  };
  var $T15 = function () {
    return ($T15 = JSIL.Memoize($asm02.Fusee.Engine.ShaderProgram)) ();
  };
  var $T16 = function () {
    return ($T16 = JSIL.Memoize($asm01.Fusee.Engine.ClearFlags)) ();
  };
  var $T17 = function () {
    return ($T17 = JSIL.Memoize($asm02.Fusee.Engine.Input)) ();
  };
  var $T18 = function () {
    return ($T18 = JSIL.Memoize($asm01.Fusee.Engine.MouseButtons)) ();
  };
  var $T19 = function () {
    return ($T19 = JSIL.Memoize($asm01.Fusee.Engine.InputAxis)) ();
  };
  var $T1A = function () {
    return ($T1A = JSIL.Memoize($asm06.System.Single)) ();
  };
  var $T1B = function () {
    return ($T1B = JSIL.Memoize($asm06.System.Math)) ();
  };
  var $T1C = function () {
    return ($T1C = JSIL.Memoize($asm02.Fusee.Engine.Time)) ();
  };
  var $T1D = function () {
    return ($T1D = JSIL.Memoize($asm01.Fusee.Engine.KeyCodes)) ();
  };
  var $T1E = function () {
    return ($T1E = JSIL.Memoize($asm03.Fusee.Math.float4x4)) ();
  };
  var $T1F = function () {
    return ($T1F = JSIL.Memoize($asm02.Fusee.Engine.Diagnostics)) ();
  };
  var $T20 = function () {
    return ($T20 = JSIL.Memoize($asm06.System.Object)) ();
  };
  var $T21 = function () {
    return ($T21 = JSIL.Memoize($asm04.Fusee.Serialization.MeshContainer)) ();
  };
  var $T22 = function () {
    return ($T22 = JSIL.Memoize($asm03.Fusee.Math.float3)) ();
  };
  var $T23 = function () {
    return ($T23 = JSIL.Memoize($asm06.System.UInt16)) ();
  };
  var $T24 = function () {
    return ($T24 = JSIL.Memoize($asm04.Fusee.Serialization.SceneObjectContainer)) ();
  };
  var $T25 = function () {
    return ($T25 = JSIL.Memoize($asm04.Fusee.Serialization.SceneHeader)) ();
  };
  var $T26 = function () {
    return ($T26 = JSIL.Memoize($asm06.System.Collections.Generic.List$b1.Of($asm04.Fusee.Serialization.SceneObjectContainer))) ();
  };
  var $S00 = function () {
    return ($S00 = JSIL.Memoize(new JSIL.ConstructorSignature($asm03.TypeRef("Fusee.Math.float4"), [
        $asm06.TypeRef("System.Single"), $asm06.TypeRef("System.Single"), 
        $asm06.TypeRef("System.Single"), $asm06.TypeRef("System.Single")
      ]))) ();
  };
  var $S01 = function () {
    return ($S01 = JSIL.Memoize(new JSIL.ConstructorSignature($asm02.TypeRef("Fusee.Engine.GUIHandler"), []))) ();
  };
  var $S02 = function () {
    return ($S02 = JSIL.Memoize(new JSIL.ConstructorSignature($asm02.TypeRef("Fusee.Engine.GUIButton"), [
        $asm06.TypeRef("System.Int32"), $asm06.TypeRef("System.Int32"), 
        $asm06.TypeRef("System.Int32"), $asm06.TypeRef("System.Int32")
      ]))) ();
  };
  var $S03 = function () {
    return ($S03 = JSIL.Memoize(new JSIL.ConstructorSignature($asm02.TypeRef("Fusee.Engine.GUIImage"), [
        $asm06.TypeRef("System.String"), $asm06.TypeRef("System.Int32"), 
        $asm06.TypeRef("System.Int32"), $asm06.TypeRef("System.Int32"), 
        $asm06.TypeRef("System.Int32"), $asm06.TypeRef("System.Int32")
      ]))) ();
  };
  var $S04 = function () {
    return ($S04 = JSIL.Memoize(new JSIL.ConstructorSignature($asm02.TypeRef("Fusee.Engine.GUIText"), [
        $asm06.TypeRef("System.String"), $asm01.TypeRef("Fusee.Engine.IFont"), 
        $asm06.TypeRef("System.Int32"), $asm06.TypeRef("System.Int32")
      ]))) ();
  };
  var $S05 = function () {
    return ($S05 = JSIL.Memoize(new JSIL.MethodSignature($asm06.TypeRef("System.Object"), [
        $asm06.TypeRef("System.IO.Stream"), $asm06.TypeRef("System.Object"), 
        $asm06.TypeRef("System.Type")
      ], []))) ();
  };
  var $S06 = function () {
    return ($S06 = JSIL.Memoize(new JSIL.MethodSignature($asm03.TypeRef("Fusee.Math.float4x4"), [$asm03.TypeRef("Fusee.Math.float4x4"), $asm03.TypeRef("Fusee.Math.float4x4")], []))) ();
  };
  var $S07 = function () {
    return ($S07 = JSIL.Memoize(new JSIL.ConstructorSignature($asm03.TypeRef("Fusee.Math.float3"), [
        $asm06.TypeRef("System.Single"), $asm06.TypeRef("System.Single"), 
        $asm06.TypeRef("System.Single")
      ]))) ();
  };
  var $S08 = function () {
    return ($S08 = JSIL.Memoize(new JSIL.ConstructorSignature($asm06.TypeRef("System.Collections.Generic.List`1", [$asm04.TypeRef("Fusee.Serialization.SceneObjectContainer")]), [$asm06.TypeRef("System.Collections.Generic.IEnumerable`1", [$asm04.TypeRef("Fusee.Serialization.SceneObjectContainer")])]))) ();
  };
  var $S09 = function () {
    return ($S09 = JSIL.Memoize(new JSIL.MethodSignature(null, [$asm06.TypeRef("System.IO.Stream"), $asm06.TypeRef("System.Object")], []))) ();
  };
  var $IM00 = function () {
    return ($IM00 = JSIL.Memoize($asm06.System.IDisposable.Dispose)) ();
  };

  function SceneViewer__ctor () {
    $T00().prototype._ctor.call(this);
  };

  function SceneViewer__guiFuseeLink_OnGUIButtonDown (sender, mea) {
    this.OpenLink("http://fusee3d.org");
  };

  function SceneViewer__guiFuseeLink_OnGUIButtonEnter (sender, mea) {
    (this._guiFuseeLink.ButtonColor = $S00().Construct(0, 0.6, 0.2, 0.4));
    this._guiFuseeLink.set_BorderWidth(1);
    this.SetCursor($T04().Hand);
  };

  function SceneViewer__guiFuseeLink_OnGUIButtonLeave (sender, mea) {
    (this._guiFuseeLink.ButtonColor = $S00().Construct(0, 0, 0, 0));
    this._guiFuseeLink.set_BorderWidth(0);
    this.SetCursor($T04().Standard);
  };

  function SceneViewer_Init () {
    this._guiHandler = $S01().Construct();
    this._guiHandler.AttachToContext(this.get_RC());
    this._guiFuseeLink = $S02().Construct(6, 6, 157, 87);
    (this._guiFuseeLink.ButtonColor = $S00().Construct(0, 0, 0, 0));
    (this._guiFuseeLink.BorderColor = $S00().Construct(0, 0.6, 0.2, 1));
    this._guiFuseeLink.set_BorderWidth(0);
    this._guiFuseeLink.add_OnGUIButtonDown($T06().New(this, $thisType.prototype._guiFuseeLink_OnGUIButtonDown));
    this._guiFuseeLink.add_OnGUIButtonEnter($T06().New(this, $thisType.prototype._guiFuseeLink_OnGUIButtonEnter));
    this._guiFuseeLink.add_OnGUIButtonLeave($T06().New(this, $thisType.prototype._guiFuseeLink_OnGUIButtonLeave));
    this._guiHandler.Add(this._guiFuseeLink);
    this._guiFuseeLogo = $S03().Construct("Assets/FuseeLogo150.png", 10, 10, -5, 150, 80);
    this._guiHandler.Add(this._guiFuseeLogo);
    this._guiLatoBlack = this.get_RC().LoadFont("Assets/Lato-Black.ttf", 14);
    this._guiSubText = $S04().Construct("FUSEE 3D Scene Viewer", this._guiLatoBlack, 100, 100);
    (this._guiSubText.TextColor = $S00().Construct(0.05, 0.25, 0.15, 0.8));
    this._guiHandler.Add(this._guiSubText);
    var ser = new ($T0B())();
    var file = $T0D().OpenRead("Assets/Model.fus");
    try {
      var scene = $T0E().$As($S05().CallVirtual("Deserialize", null, ser, file, null, $T0E().__Type__));
    } finally {
      if (file !== null) {
        $IM00().Call(file, null);
      }
    }
    this._sr = new ($T11())(scene, "Assets");
    this._guiSubText.set_Text("FUSEE 3D Scene");
    if (!((scene.Header.CreatedBy === null) && (scene.Header.CreationDate === null))) {
      var expr_208 = this._guiSubText;
      expr_208.set_Text(JSIL.ConcatString(expr_208.get_Text(), " created"));
      if (scene.Header.CreatedBy !== null) {
        var expr_237 = this._guiSubText;
        expr_237.set_Text((expr_237.get_Text() + " by " + scene.Header.CreatedBy));
      }
      if (scene.Header.CreationDate !== null) {
        var expr_272 = this._guiSubText;
        expr_272.set_Text((expr_272.get_Text() + " on " + scene.Header.CreationDate));
      }
    }
    this._subtextWidth = +$T09().GetTextWidth(this._guiSubText.get_Text(), this._guiLatoBlack);
    this._subtextHeight = +$T09().GetTextHeight(this._guiSubText.get_Text(), this._guiLatoBlack);
    this._sColor = $T14().GetDiffuseColorShader(this.get_RC());
    this.get_RC().SetShader(this._sColor);
    this._colorParam = this._sColor.GetShaderParam("color");
    this.get_RC().SetShaderParam4f(this._colorParam, $S00().Construct(1, 1, 1, 1));
    (this.RenderCanvas$RC.ClearColor = $S00().Construct(1, 1, 1, 1));
  };

  function SceneViewer_Main () {
    var app = new $thisType();
    app.Run();
  };

  function SceneViewer_RenderAFrame () {
    this.get_RC().Clear($T16().$Flags("Color", "Depth"));
    if ($T17().get_Instance().IsButton($T18().Left)) {
      $thisType._angleVelHorz = +(1 * $T17().get_Instance().GetAxis($T19().MouseX));
      $thisType._angleVelVert = +(1 * $T17().get_Instance().GetAxis($T19().MouseY));
    } else {
      var curDamp = +$T1A().$Cast($T1B().Exp((-0.92000001668930054 * $T1C().get_Instance().get_DeltaTime())));
      $thisType._angleVelHorz *= +curDamp;
      $thisType._angleVelVert *= +curDamp;
    }
    $thisType._angleHorz -= +$thisType._angleVelHorz;
    $thisType._angleVert -= +$thisType._angleVelVert;
    if ($T17().get_Instance().IsKey($T1D().Left)) {
      $thisType._angleHorz -= +(1 * $T1A().$Cast($T1C().get_Instance().get_DeltaTime()));
    }
    if ($T17().get_Instance().IsKey($T1D().Right)) {
      $thisType._angleHorz += +(1 * $T1A().$Cast($T1C().get_Instance().get_DeltaTime()));
    }
    if ($T17().get_Instance().IsKey($T1D().Up)) {
      $thisType._angleVert -= +(1 * $T1A().$Cast($T1C().get_Instance().get_DeltaTime()));
    }
    if ($T17().get_Instance().IsKey($T1D().Down)) {
      $thisType._angleVert += +(1 * $T1A().$Cast($T1C().get_Instance().get_DeltaTime()));
    }
    var mtxRot = $S06().CallStatic($T1E(), "op_Multiply", null, 
      $T1E().CreateRotationX($thisType._angleVert), 
      $T1E().CreateRotationY($thisType._angleHorz)
    );
    var mtxCam = $T1E().LookAt(
      0, 
      200, 
      -500, 
      0, 
      0, 
      0, 
      0, 
      1, 
      0
    );
    (this.RenderCanvas$RC.ModelView = $S06().CallStatic($T1E(), "op_Multiply", null, mtxCam, mtxRot).MemberwiseClone());
    this._sr.Render(this.get_RC());
    this._guiHandler.RenderGUI();
    this.Present();
  };

  function SceneViewer_Resize () {
    this.get_RC().Viewport(
      0, 
      0, 
      this.get_Width(), 
      this.get_Height()
    );
    var aspectRatio = +($T1A().$Cast(this.get_Width()) / $T1A().$Cast(this.get_Height()));
    (this.RenderCanvas$RC.Projection = $T1E().CreatePerspectiveFieldOfView(0.7853982, aspectRatio, 1, 10000).MemberwiseClone());
    this._guiSubText.set_PosX(((($T1A().$Cast(this.get_Width()) - this._subtextWidth) / 2) | 0));
    this._guiSubText.set_PosY(((($T1A().$Cast(this.get_Height()) - this._subtextHeight) - 3) | 0));
    this._guiHandler.Refresh();
  };

  function SceneViewer_TestDeserialize () {
    var ser = new ($T0B())();
    var file = $T0D().OpenRead("Assets/Test.fus");
    try {
      var mc2 = $T0E().$As($S05().CallVirtual("Deserialize", null, ser, file, null, $T0E().__Type__));
    } finally {
      if (file !== null) {
        $IM00().Call(file, null);
      }
    }
    $T1F().Log(mc2.toString());
  };

  function SceneViewer_TestSerialize () {
    var aMesh = (new ($T21())()).__Initialize__({
        Vertices: JSIL.Array.New($T22(), [$S07().Construct(-1, -1, -1), $S07().Construct(-1, -1, 1), $S07().Construct(-1, 1, -1), $S07().Construct(1, -1, -1), $S07().Construct(1, 1, 1), $S07().Construct(-1, 1, 1), $S07().Construct(1, -1, 1), $S07().Construct(1, 1, -1)]), 
        Normals: JSIL.Array.New($T22(), [$S07().Construct(-1, -1, -1), $S07().Construct(-1, -1, 1), $S07().Construct(-1, 1, -1), $S07().Construct(1, -1, -1), $S07().Construct(1, 1, 1), $S07().Construct(-1, 1, 1), $S07().Construct(1, -1, 1), $S07().Construct(1, 1, -1)]), 
        Triangles: JSIL.Array.New($T23(), [0, 1, 2, 0, 2, 3, 0, 3, 1, 4, 5, 6, 4, 6, 7, 4, 7, 5])}
    );
    var aChild = (new ($T24())()).__Initialize__({
        Mesh: aMesh, 
        Transform: $T1E().CreateTranslation(0.11, 0.11, 0).MemberwiseClone()}
    );
    var parent = (new ($T0E())()).__Initialize__({
        Header: (new ($T25())()).__Initialize__({
            Version: 1, 
            Generator: "Fusee.SceneViewer", 
            CreatedBy: "FuseeProjetTeam"}
        ), 
        Children: $S08().Construct(JSIL.Array.New($T24(), [aChild, aChild, (new ($T24())()).__Initialize__({
                Mesh: aMesh, 
                Transform: $T1E().CreateTranslation(0.22, 0.22, 0).MemberwiseClone()}
            )]))}
    );
    var ser = new ($T0B())();
    var file = $T0D().Create("Assets/Test.fus");
    try {
      $S09().CallVirtual("Serialize", null, ser, file, parent);
    } finally {
      if (file !== null) {
        $IM00().Call(file, null);
      }
    }
  };

  JSIL.MakeType({
      BaseType: $asm02.TypeRef("Fusee.Engine.RenderCanvas"), 
      Name: "Examples.SceneViewer.SceneViewer", 
      IsPublic: true, 
      IsReferenceType: true, 
      MaximumConstructorArguments: 0, 
    }, function ($interfaceBuilder) {
    $ = $interfaceBuilder;

    $.Method({Static:false, Public:true }, ".ctor", 
      new JSIL.MethodSignature(null, [], []), 
      SceneViewer__ctor
    );

    $.Method({Static:false, Public:false}, "_guiFuseeLink_OnGUIButtonDown", 
      new JSIL.MethodSignature(null, [$asm02.TypeRef("Fusee.Engine.GUIButton"), $asm01.TypeRef("Fusee.Engine.MouseEventArgs")], []), 
      SceneViewer__guiFuseeLink_OnGUIButtonDown
    );

    $.Method({Static:false, Public:false}, "_guiFuseeLink_OnGUIButtonEnter", 
      new JSIL.MethodSignature(null, [$asm02.TypeRef("Fusee.Engine.GUIButton"), $asm01.TypeRef("Fusee.Engine.MouseEventArgs")], []), 
      SceneViewer__guiFuseeLink_OnGUIButtonEnter
    );

    $.Method({Static:false, Public:false}, "_guiFuseeLink_OnGUIButtonLeave", 
      new JSIL.MethodSignature(null, [$asm02.TypeRef("Fusee.Engine.GUIButton"), $asm01.TypeRef("Fusee.Engine.MouseEventArgs")], []), 
      SceneViewer__guiFuseeLink_OnGUIButtonLeave
    );

    $.Method({Static:false, Public:true , Virtual:true }, "Init", 
      new JSIL.MethodSignature(null, [], []), 
      SceneViewer_Init
    );

    $.Method({Static:true , Public:true }, "Main", 
      new JSIL.MethodSignature(null, [], []), 
      SceneViewer_Main
    );

    $.Method({Static:false, Public:true , Virtual:true }, "RenderAFrame", 
      new JSIL.MethodSignature(null, [], []), 
      SceneViewer_RenderAFrame
    );

    $.Method({Static:false, Public:true , Virtual:true }, "Resize", 
      new JSIL.MethodSignature(null, [], []), 
      SceneViewer_Resize
    );

    $.Method({Static:false, Public:false}, "TestDeserialize", 
      new JSIL.MethodSignature(null, [], []), 
      SceneViewer_TestDeserialize
    );

    $.Method({Static:false, Public:false}, "TestSerialize", 
      new JSIL.MethodSignature(null, [], []), 
      SceneViewer_TestSerialize
    );

    $.Constant({Static:true , Public:false}, "RotationSpeed", 1); 
    $.Constant({Static:true , Public:false}, "Damping", 0.92); 
    $.Field({Static:true , Public:false}, "_angleHorz", $.Single); 
    $.Field({Static:true , Public:false}, "_angleVert", $.Single); 
    $.Field({Static:true , Public:false}, "_angleVelHorz", $.Single); 
    $.Field({Static:true , Public:false}, "_angleVelVert", $.Single); 
    $.Field({Static:false, Public:false}, "_subtextWidth", $.Single); 
    $.Field({Static:false, Public:false}, "_subtextHeight", $.Single); 
    $.Field({Static:false, Public:false}, "_meshFace", $asm02.TypeRef("Fusee.Engine.Mesh")); 
    $.Field({Static:false, Public:false}, "_meshTea", $asm02.TypeRef("Fusee.Engine.Mesh")); 
    $.Field({Static:false, Public:false}, "_sr", $asm00.TypeRef("Examples.SceneViewer.SceneRenderer")); 
    $.Field({Static:false, Public:false}, "_sColor", $asm02.TypeRef("Fusee.Engine.ShaderProgram")); 
    $.Field({Static:false, Public:false}, "_colorParam", $asm01.TypeRef("Fusee.Engine.IShaderParam")); 
    $.Field({Static:false, Public:false}, "_guiHandler", $asm02.TypeRef("Fusee.Engine.GUIHandler")); 
    $.Field({Static:false, Public:false}, "_guiFuseeLogo", $asm02.TypeRef("Fusee.Engine.GUIImage")); 
    $.Field({Static:false, Public:false}, "_guiFuseeLink", $asm02.TypeRef("Fusee.Engine.GUIButton")); 
    $.Field({Static:false, Public:false}, "_guiSubText", $asm02.TypeRef("Fusee.Engine.GUIText")); 
    $.Field({Static:false, Public:false}, "_guiLatoBlack", $asm01.TypeRef("Fusee.Engine.IFont")); 
    return function (newThisType) { $thisType = newThisType; }; 
  });

})();

/* class Examples.SceneViewer.SceneRenderer */ 

(function SceneRenderer$Members () {
  var $, $thisType;
  var $T00 = function () {
    return ($T00 = JSIL.Memoize($asm04.Fusee.Serialization.SceneContainer)) ();
  };
  var $T01 = function () {
    return ($T01 = JSIL.Memoize($asm06.System.String)) ();
  };
  var $T02 = function () {
    return ($T02 = JSIL.Memoize($asm02.Fusee.Engine.RenderStateSet)) ();
  };
  var $T03 = function () {
    return ($T03 = JSIL.Memoize($asm01.Fusee.Engine.Blend)) ();
  };
  var $T04 = function () {
    return ($T04 = JSIL.Memoize($asm01.Fusee.Engine.Compare)) ();
  };
  var $T05 = function () {
    return ($T05 = JSIL.Memoize($asm02.Fusee.Engine.RenderContext)) ();
  };
  var $T06 = function () {
    return ($T06 = JSIL.Memoize($asm06.System.Collections.Generic.Dictionary$b2.Of($asm04.Fusee.Serialization.MeshContainer, $asm02.Fusee.Engine.Mesh))) ();
  };
  var $T07 = function () {
    return ($T07 = JSIL.Memoize($asm06.System.Collections.Generic.Dictionary$b2.Of($asm04.Fusee.Serialization.MaterialContainer, $asm00.Examples.SceneViewer.SceneRenderer_SRMaterial))) ();
  };
  var $T08 = function () {
    return ($T08 = JSIL.Memoize($asm02.Fusee.Engine.MoreShaders)) ();
  };
  var $T09 = function () {
    return ($T09 = JSIL.Memoize($asm02.Fusee.Engine.ShaderProgram)) ();
  };
  var $T0A = function () {
    return ($T0A = JSIL.Memoize($asm00.Examples.SceneViewer.SceneRenderer_SRMaterial)) ();
  };
  var $T0B = function () {
    return ($T0B = JSIL.Memoize(System.Array.Of($asm00.Examples.SceneViewer.SceneRenderer_SetParamFunc))) ();
  };
  var $T0C = function () {
    return ($T0C = JSIL.Memoize($asm00.Examples.SceneViewer.SceneRenderer_SetParamFunc)) ();
  };
  var $T0D = function () {
    return ($T0D = JSIL.Memoize($asm06.System.Collections.Generic.List$b1.Of($asm00.Examples.SceneViewer.SceneRenderer_SetParamFunc))) ();
  };
  var $T0E = function () {
    return ($T0E = JSIL.Memoize($asm06.System.Collections.Generic.IEnumerable$b1.Of($asm00.Examples.SceneViewer.SceneRenderer_SetParamFunc))) ();
  };
  var $T0F = function () {
    return ($T0F = JSIL.Memoize($asm04.Fusee.Serialization.MaterialContainer)) ();
  };
  var $T10 = function () {
    return ($T10 = JSIL.Memoize($asm00.Examples.SceneViewer.SceneRenderer_$l$gc__DisplayClass8)) ();
  };
  var $T11 = function () {
    return ($T11 = JSIL.Memoize($asm00.Examples.SceneViewer.SceneRenderer_$l$gc__DisplayClassa)) ();
  };
  var $T12 = function () {
    return ($T12 = JSIL.Memoize($asm06.System.IO.Path)) ();
  };
  var $T13 = function () {
    return ($T13 = JSIL.Memoize($asm01.Fusee.Engine.ImageData)) ();
  };
  var $T14 = function () {
    return ($T14 = JSIL.Memoize($asm04.Fusee.Serialization.SceneObjectContainer)) ();
  };
  var $T15 = function () {
    return ($T15 = JSIL.Memoize($asm02.Fusee.Engine.Mesh)) ();
  };
  var $T16 = function () {
    return ($T16 = JSIL.Memoize($asm03.Fusee.Math.float4x4)) ();
  };
  var $S00 = function () {
    return ($S00 = JSIL.Memoize(new JSIL.ConstructorSignature($asm06.TypeRef("System.Collections.Generic.Dictionary`2", [$asm04.TypeRef("Fusee.Serialization.MeshContainer"), $asm02.TypeRef("Fusee.Engine.Mesh")]), []))) ();
  };
  var $S01 = function () {
    return ($S01 = JSIL.Memoize(new JSIL.ConstructorSignature($asm06.TypeRef("System.Collections.Generic.Dictionary`2", [$asm04.TypeRef("Fusee.Serialization.MaterialContainer"), $asm00.TypeRef("Examples.SceneViewer.SceneRenderer/SRMaterial")]), []))) ();
  };
  var $S02 = function () {
    return ($S02 = JSIL.Memoize(new JSIL.ConstructorSignature($asm03.TypeRef("Fusee.Math.float4"), [
        $asm06.TypeRef("System.Single"), $asm06.TypeRef("System.Single"), 
        $asm06.TypeRef("System.Single"), $asm06.TypeRef("System.Single")
      ]))) ();
  };
  var $S03 = function () {
    return ($S03 = JSIL.Memoize(new JSIL.ConstructorSignature($asm06.TypeRef("System.Collections.Generic.List`1", [$asm00.TypeRef("Examples.SceneViewer.SceneRenderer/SetParamFunc")]), [$asm06.TypeRef("System.Collections.Generic.IEnumerable`1", [$asm00.TypeRef("Examples.SceneViewer.SceneRenderer/SetParamFunc")])]))) ();
  };
  var $S04 = function () {
    return ($S04 = JSIL.Memoize(new JSIL.ConstructorSignature($asm06.TypeRef("System.Collections.Generic.List`1", [$asm00.TypeRef("Examples.SceneViewer.SceneRenderer/SetParamFunc")]), []))) ();
  };
  var $S05 = function () {
    return ($S05 = JSIL.Memoize(new JSIL.MethodSignature(null, [$asm00.TypeRef("Examples.SceneViewer.SceneRenderer/SetParamFunc")], []))) ();
  };
  var $S06 = function () {
    return ($S06 = JSIL.Memoize(new JSIL.MethodSignature($asm03.TypeRef("Fusee.Math.float4x4"), [$asm03.TypeRef("Fusee.Math.float4x4"), $asm03.TypeRef("Fusee.Math.float4x4")], []))) ();
  };

  function SceneRenderer__ctor (sc, scenePathDirectory) {
    this._stateSet = (new ($T02())()).__Initialize__({
        AlphaBlendEnable: false, 
        SourceBlend: $T03().One, 
        DestinationBlend: $T03().Zero, 
        ZEnable: true, 
        ZFunc: $T04().Less}
    );
    this._sc = sc;
    this._scenePathDirectory = scenePathDirectory;
  };

  function SceneRenderer_get_CurMat () {
    return this._curMat;
  };

  function SceneRenderer_InitShaders (rc) {
    if (rc !== this._rc) {
      this._rc = rc;
      this._colorShader = null;
      this._colorParam = null;
      this._textureShader = null;
      this._textureParam = null;
      this._meshMap = $S00().Construct();
      this._matMap = $S01().Construct();
    }
    if (this._colorShader === null) {
      this._colorShader = $T08().GetDiffuseColorShader(rc);
      this._colorParam = this._colorShader.GetShaderParam("color");
      var sRMaterial = new ($T0A())();
      sRMaterial.Shader = this._colorShader;
      var array = JSIL.Array.New($T0C(), 1);
      array[0] = function () {
        this._rc.SetShaderParam4f(this._colorParam, $S02().Construct(0.5, 0.5, 0.5, 1));
      }.bind(this);
      sRMaterial.ParamSetters = $S03().Construct($T0E().$Cast(array));
      var curMat = sRMaterial.MemberwiseClone();
      (this.CurMat = curMat.MemberwiseClone());
    }
    if (this._textureShader === null) {
      this._textureShader = $T08().GetTextureShader(rc);
      this._textureParam = this._textureShader.GetShaderParam("texture1");
    }
    rc.SetShader(this._colorShader);
    rc.SetRenderState(this._stateSet);
  };

  function SceneRenderer_LookupMaterial (mc) {
    var srMat = new JSIL.BoxedVariable(new ($T0A())());
    if (!this._matMap.TryGetValue(mc, /* ref */ srMat)) {
      srMat.set(this.MakeMaterial(mc).MemberwiseClone());
      this._matMap.Add(mc, srMat.get().MemberwiseClone());
    }
    return srMat.get();
  };

  function SceneRenderer_MakeMaterial (mc) {
    var $closure0 = new ($T10())();
    $closure0.mc = mc;
    $closure0.$this = this;
    var ret = new ($T0A())();
    ret.ParamSetters = $S04().Construct();
    if ($closure0.mc.DiffuseTexure === null) {
      ret.Shader = this._colorShader;
      $S05().CallVirtual("Add", null, ret.ParamSetters, function () {
          this.$this._rc.SetShaderParam4f(this.$this._colorParam, $S02().Construct(this.mc.DiffuseColor.x, this.mc.DiffuseColor.y, this.mc.DiffuseColor.z, 1));
        }.bind($closure0));
    } else {
      var $closure1 = new ($T11())();
      $closure1.$locals9 = $closure0;
      ret.Shader = this._textureShader;
      var texturePath = $T12().Combine(this._scenePathDirectory, $closure0.mc.DiffuseTexure);
      var image = this._rc.LoadImage(texturePath).MemberwiseClone();
      $closure1.texHandle = this._rc.CreateTexture(image.MemberwiseClone());
      $S05().CallVirtual("Add", null, ret.ParamSetters, function () {
          this.$locals9.$this._rc.SetShaderParamTexture(this.$locals9.$this._textureParam, this.texHandle);
        }.bind($closure1));
    }
    return ret;
  };

  function SceneRenderer_MakeMesh (soc) {
    return (new ($T15())()).__Initialize__({
        Colors: null, 
        Normals: soc.Mesh.Normals, 
        UVs: soc.Mesh.UVs, 
        Vertices: soc.Mesh.Vertices, 
        Triangles: soc.Mesh.Triangles}
    );
  };

  function SceneRenderer_Render (rc) {
    var $temp00;
    this.InitShaders(rc);

    for (var a$0 = this._sc.Children._items, i$0 = 0, l$0 = this._sc.Children._size; i$0 < l$0; ($temp00 = i$0, 
        i$0 = ((i$0 + 1) | 0), 
        $temp00)) {
      var soc = a$0[i$0];
      this.VisitNode(soc);
    }
  };

  function SceneRenderer_set_CurMat (value) {
    var $temp00;
    if (this._rc !== null) {
      this._rc.SetShader(value.Shader);

      for (var a$0 = value.ParamSetters._items, i$0 = 0, l$0 = value.ParamSetters._size; i$0 < l$0; ($temp00 = i$0, 
          i$0 = ((i$0 + 1) | 0), 
          $temp00)) {
        var paramSetter = a$0[i$0];
        paramSetter();
      }
    }
    this._curMat = value.MemberwiseClone();
  };

  function SceneRenderer_VisitNode (soc) {
    var $temp00;
    var rm = new JSIL.BoxedVariable(null);
    var origMV = this._rc.get_ModelView().MemberwiseClone();
    var origMat = this.get_CurMat().MemberwiseClone();
    if (soc.Material !== null) {
      var srMat = this.LookupMaterial(soc.Material).MemberwiseClone();
      (this.CurMat = srMat.MemberwiseClone());
    }
    (this._rc.ModelView = $S06().CallStatic($T16(), "op_Multiply", null, this._rc.ModelView, soc.Transform).MemberwiseClone());
    if (soc.Mesh !== null) {
      if (!this._meshMap.TryGetValue(soc.Mesh, /* ref */ rm)) {
        rm.set($thisType.MakeMesh(soc));
        this._meshMap.Add(soc.Mesh, rm.get());
      }
      this._rc.Render(rm.get());
    }
    if (soc.Children !== null) {

      for (var a$0 = soc.Children._items, i$0 = 0, l$0 = soc.Children._size; i$0 < l$0; ($temp00 = i$0, 
          i$0 = ((i$0 + 1) | 0), 
          $temp00)) {
        var child = a$0[i$0];
        this.VisitNode(child);
      }
    }
    (this._rc.ModelView = origMV.MemberwiseClone());
    (this.CurMat = origMat.MemberwiseClone());
  };

  JSIL.MakeType({
      BaseType: $asm06.TypeRef("System.Object"), 
      Name: "Examples.SceneViewer.SceneRenderer", 
      IsPublic: true, 
      IsReferenceType: true, 
      MaximumConstructorArguments: 2, 
    }, function ($interfaceBuilder) {
    $ = $interfaceBuilder;

    $.Method({Static:false, Public:true }, ".ctor", 
      new JSIL.MethodSignature(null, [$asm04.TypeRef("Fusee.Serialization.SceneContainer"), $.String], []), 
      SceneRenderer__ctor
    );

    $.Method({Static:false, Public:false}, "get_CurMat", 
      new JSIL.MethodSignature($asm00.TypeRef("Examples.SceneViewer.SceneRenderer/SRMaterial"), [], []), 
      SceneRenderer_get_CurMat
    );

    $.Method({Static:false, Public:true }, "InitShaders", 
      new JSIL.MethodSignature(null, [$asm02.TypeRef("Fusee.Engine.RenderContext")], []), 
      SceneRenderer_InitShaders
    );

    $.Method({Static:false, Public:false}, "LookupMaterial", 
      new JSIL.MethodSignature($asm00.TypeRef("Examples.SceneViewer.SceneRenderer/SRMaterial"), [$asm04.TypeRef("Fusee.Serialization.MaterialContainer")], []), 
      SceneRenderer_LookupMaterial
    );

    $.Method({Static:false, Public:false}, "MakeMaterial", 
      new JSIL.MethodSignature($asm00.TypeRef("Examples.SceneViewer.SceneRenderer/SRMaterial"), [$asm04.TypeRef("Fusee.Serialization.MaterialContainer")], []), 
      SceneRenderer_MakeMaterial
    );

    $.Method({Static:true , Public:false}, "MakeMesh", 
      new JSIL.MethodSignature($asm02.TypeRef("Fusee.Engine.Mesh"), [$asm04.TypeRef("Fusee.Serialization.SceneObjectContainer")], []), 
      SceneRenderer_MakeMesh
    );

    $.Method({Static:false, Public:true }, "Render", 
      new JSIL.MethodSignature(null, [$asm02.TypeRef("Fusee.Engine.RenderContext")], []), 
      SceneRenderer_Render
    );

    $.Method({Static:false, Public:false}, "set_CurMat", 
      new JSIL.MethodSignature(null, [$asm00.TypeRef("Examples.SceneViewer.SceneRenderer/SRMaterial")], []), 
      SceneRenderer_set_CurMat
    );

    $.Method({Static:false, Public:false}, "VisitNode", 
      new JSIL.MethodSignature(null, [$asm04.TypeRef("Fusee.Serialization.SceneObjectContainer")], []), 
      SceneRenderer_VisitNode
    );

    $.Field({Static:false, Public:false}, "_meshMap", $asm06.TypeRef("System.Collections.Generic.Dictionary`2", [$asm04.TypeRef("Fusee.Serialization.MeshContainer"), $asm02.TypeRef("Fusee.Engine.Mesh")])); 
    $.Field({Static:false, Public:false}, "_matMap", $asm06.TypeRef("System.Collections.Generic.Dictionary`2", [$asm04.TypeRef("Fusee.Serialization.MaterialContainer"), $asm00.TypeRef("Examples.SceneViewer.SceneRenderer/SRMaterial")])); 
    $.Field({Static:false, Public:false}, "_sc", $asm04.TypeRef("Fusee.Serialization.SceneContainer")); 
    $.Field({Static:false, Public:false}, "_rc", $asm02.TypeRef("Fusee.Engine.RenderContext")); 
    $.Field({Static:false, Public:false}, "_colorShader", $asm02.TypeRef("Fusee.Engine.ShaderProgram")); 
    $.Field({Static:false, Public:false}, "_colorParam", $asm01.TypeRef("Fusee.Engine.IShaderParam")); 
    $.Field({Static:false, Public:false}, "_textureShader", $asm02.TypeRef("Fusee.Engine.ShaderProgram")); 
    $.Field({Static:false, Public:false}, "_textureParam", $asm01.TypeRef("Fusee.Engine.IShaderParam")); 
    $.Field({Static:false, Public:false}, "_stateSet", $asm02.TypeRef("Fusee.Engine.RenderStateSet")); 
    $.Field({Static:false, Public:false}, "_curMat", $asm00.TypeRef("Examples.SceneViewer.SceneRenderer/SRMaterial")); 
    $.Field({Static:false, Public:false}, "_scenePathDirectory", $.String); 
    $.Property({Static:false, Public:false}, "CurMat", $asm00.TypeRef("Examples.SceneViewer.SceneRenderer/SRMaterial"));

    return function (newThisType) { $thisType = newThisType; }; 
  });

})();

/* delegate Examples.SceneViewer.SceneRenderer/SetParamFunc */ 

JSIL.MakeDelegate("Examples.SceneViewer.SceneRenderer/SetParamFunc", false, []);

/* struct Examples.SceneViewer.SceneRenderer/SRMaterial */ 

(function SRMaterial$Members () {
  var $, $thisType;
  JSIL.MakeType({
      BaseType: $asm06.TypeRef("System.ValueType"), 
      Name: "Examples.SceneViewer.SceneRenderer/SRMaterial", 
      IsPublic: false, 
      IsReferenceType: false, 
      MaximumConstructorArguments: 0, 
    }, function ($interfaceBuilder) {
    $ = $interfaceBuilder;

    $.Field({Static:false, Public:true }, "Shader", $asm02.TypeRef("Fusee.Engine.ShaderProgram")); 
    $.Field({Static:false, Public:true }, "ParamSetters", $asm06.TypeRef("System.Collections.Generic.List`1", [$asm00.TypeRef("Examples.SceneViewer.SceneRenderer/SetParamFunc")])); 
    return function (newThisType) { $thisType = newThisType; }; 
  });

})();

/* class Examples.SceneViewer.SceneRenderer/<>c__DisplayClass8 */ 

(function $l$gc__DisplayClass8$Members () {
  var $, $thisType;
  function $l$gc__DisplayClass8__ctor () {
  };

  JSIL.MakeType({
      BaseType: $asm06.TypeRef("System.Object"), 
      Name: "Examples.SceneViewer.SceneRenderer/<>c__DisplayClass8", 
      IsPublic: false, 
      IsReferenceType: true, 
      MaximumConstructorArguments: 0, 
    }, function ($interfaceBuilder) {
    $ = $interfaceBuilder;

    $.Method({Static:false, Public:true }, ".ctor", 
      new JSIL.MethodSignature(null, [], []), 
      $l$gc__DisplayClass8__ctor
    );

    $.Field({Static:false, Public:true }, "$this", $asm00.TypeRef("Examples.SceneViewer.SceneRenderer")); 
    $.Field({Static:false, Public:true }, "mc", $asm04.TypeRef("Fusee.Serialization.MaterialContainer")); 
    return function (newThisType) { $thisType = newThisType; }; 
  })
    .Attribute($asm06.TypeRef("System.Runtime.CompilerServices.CompilerGeneratedAttribute"));

})();

/* class Examples.SceneViewer.SceneRenderer/<>c__DisplayClassa */ 

(function $l$gc__DisplayClassa$Members () {
  var $, $thisType;
  function $l$gc__DisplayClassa__ctor () {
  };

  JSIL.MakeType({
      BaseType: $asm06.TypeRef("System.Object"), 
      Name: "Examples.SceneViewer.SceneRenderer/<>c__DisplayClassa", 
      IsPublic: false, 
      IsReferenceType: true, 
      MaximumConstructorArguments: 0, 
    }, function ($interfaceBuilder) {
    $ = $interfaceBuilder;

    $.Method({Static:false, Public:true }, ".ctor", 
      new JSIL.MethodSignature(null, [], []), 
      $l$gc__DisplayClassa__ctor
    );

    $.Field({Static:false, Public:true }, "$locals9", $asm00.TypeRef("Examples.SceneViewer.SceneRenderer/<>c__DisplayClass8")); 
    $.Field({Static:false, Public:true }, "texHandle", $asm01.TypeRef("Fusee.Engine.ITexture")); 
    return function (newThisType) { $thisType = newThisType; }; 
  })
    .Attribute($asm06.TypeRef("System.Runtime.CompilerServices.CompilerGeneratedAttribute"));

})();

