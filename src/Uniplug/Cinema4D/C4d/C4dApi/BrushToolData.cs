/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 0.0.1
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace C4d {

using System;
using System.Runtime.InteropServices;

public class BrushToolData : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal BrushToolData(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(BrushToolData obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~BrushToolData() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          C4dApiPINVOKE.delete_BrushToolData(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public BrushBase m_pBrushBase {
    set {
      C4dApiPINVOKE.BrushToolData_m_pBrushBase_set(swigCPtr, BrushBase.getCPtr(value));
    } 
    get {
      IntPtr cPtr = C4dApiPINVOKE.BrushToolData_m_pBrushBase_get(swigCPtr);
      BrushBase ret = (cPtr == IntPtr.Zero) ? null : new BrushBase(cPtr, false);
      return ret;
    } 
  }

  public virtual bool InitTool(BaseDocument doc, BaseContainer data, BaseThread bt) {
    bool ret = (SwigDerivedClassHasMethod("InitTool", swigMethodTypes0) ? C4dApiPINVOKE.BrushToolData_InitToolSwigExplicitBrushToolData(swigCPtr, BaseDocument.getCPtr(doc), BaseContainer.getCPtr(data), BaseThread.getCPtr(bt)) : C4dApiPINVOKE.BrushToolData_InitTool(swigCPtr, BaseDocument.getCPtr(doc), BaseContainer.getCPtr(data), BaseThread.getCPtr(bt)));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual void FreeTool(BaseDocument doc, BaseContainer data) {
    if (SwigDerivedClassHasMethod("FreeTool", swigMethodTypes1)) C4dApiPINVOKE.BrushToolData_FreeToolSwigExplicitBrushToolData(swigCPtr, BaseDocument.getCPtr(doc), BaseContainer.getCPtr(data)); else C4dApiPINVOKE.BrushToolData_FreeTool(swigCPtr, BaseDocument.getCPtr(doc), BaseContainer.getCPtr(data));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void InitDefaultSettings(BaseDocument doc, BaseContainer data) {
    if (SwigDerivedClassHasMethod("InitDefaultSettings", swigMethodTypes2)) C4dApiPINVOKE.BrushToolData_InitDefaultSettingsSwigExplicitBrushToolData(swigCPtr, BaseDocument.getCPtr(doc), BaseContainer.getCPtr(data)); else C4dApiPINVOKE.BrushToolData_InitDefaultSettings(swigCPtr, BaseDocument.getCPtr(doc), BaseContainer.getCPtr(data));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual bool GetDEnabling(BaseDocument doc, BaseContainer data, DescID id, GeData t_data, DESCFLAGS_ENABLE flags, BaseContainer itemdesc) {
    bool ret = (SwigDerivedClassHasMethod("GetDEnabling", swigMethodTypes3) ? C4dApiPINVOKE.BrushToolData_GetDEnablingSwigExplicitBrushToolData(swigCPtr, BaseDocument.getCPtr(doc), BaseContainer.getCPtr(data), DescID.getCPtr(id), GeData.getCPtr(t_data), (int)flags, BaseContainer.getCPtr(itemdesc)) : C4dApiPINVOKE.BrushToolData_GetDEnabling(swigCPtr, BaseDocument.getCPtr(doc), BaseContainer.getCPtr(data), DescID.getCPtr(id), GeData.getCPtr(t_data), (int)flags, BaseContainer.getCPtr(itemdesc)));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool SetDParameter(BaseDocument doc, BaseContainer data, DescID id, GeData t_data, SWIGTYPE_p_DESCFLAGS_SET flags) {
    bool ret = (SwigDerivedClassHasMethod("SetDParameter", swigMethodTypes4) ? C4dApiPINVOKE.BrushToolData_SetDParameterSwigExplicitBrushToolData(swigCPtr, BaseDocument.getCPtr(doc), BaseContainer.getCPtr(data), DescID.getCPtr(id), GeData.getCPtr(t_data), SWIGTYPE_p_DESCFLAGS_SET.getCPtr(flags)) : C4dApiPINVOKE.BrushToolData_SetDParameter(swigCPtr, BaseDocument.getCPtr(doc), BaseContainer.getCPtr(data), DescID.getCPtr(id), GeData.getCPtr(t_data), SWIGTYPE_p_DESCFLAGS_SET.getCPtr(flags)));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool GetDDescription(BaseDocument doc, BaseContainer data, Description description, SWIGTYPE_p_DESCFLAGS_DESC flags) {
    bool ret = (SwigDerivedClassHasMethod("GetDDescription", swigMethodTypes5) ? C4dApiPINVOKE.BrushToolData_GetDDescriptionSwigExplicitBrushToolData(swigCPtr, BaseDocument.getCPtr(doc), BaseContainer.getCPtr(data), Description.getCPtr(description), SWIGTYPE_p_DESCFLAGS_DESC.getCPtr(flags)) : C4dApiPINVOKE.BrushToolData_GetDDescription(swigCPtr, BaseDocument.getCPtr(doc), BaseContainer.getCPtr(data), Description.getCPtr(description), SWIGTYPE_p_DESCFLAGS_DESC.getCPtr(flags)));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool Message(BaseDocument doc, BaseContainer data, int type, SWIGTYPE_p_void t_data) {
    bool ret = (SwigDerivedClassHasMethod("Message", swigMethodTypes6) ? C4dApiPINVOKE.BrushToolData_MessageSwigExplicitBrushToolData(swigCPtr, BaseDocument.getCPtr(doc), BaseContainer.getCPtr(data), type, SWIGTYPE_p_void.getCPtr(t_data)) : C4dApiPINVOKE.BrushToolData_Message(swigCPtr, BaseDocument.getCPtr(doc), BaseContainer.getCPtr(data), type, SWIGTYPE_p_void.getCPtr(t_data)));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool GetCursorInfo(BaseDocument doc, BaseContainer data, BaseDraw bd, double x, double y, BaseContainer bc) {
    bool ret = (SwigDerivedClassHasMethod("GetCursorInfo", swigMethodTypes7) ? C4dApiPINVOKE.BrushToolData_GetCursorInfoSwigExplicitBrushToolData(swigCPtr, BaseDocument.getCPtr(doc), BaseContainer.getCPtr(data), BaseDraw.getCPtr(bd), x, y, BaseContainer.getCPtr(bc)) : C4dApiPINVOKE.BrushToolData_GetCursorInfo(swigCPtr, BaseDocument.getCPtr(doc), BaseContainer.getCPtr(data), BaseDraw.getCPtr(bd), x, y, BaseContainer.getCPtr(bc)));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool MouseInput(BaseDocument doc, BaseContainer data, BaseDraw bd, SWIGTYPE_p_EditorWindow win, BaseContainer msg) {
    bool ret = (SwigDerivedClassHasMethod("MouseInput", swigMethodTypes8) ? C4dApiPINVOKE.BrushToolData_MouseInputSwigExplicitBrushToolData(swigCPtr, BaseDocument.getCPtr(doc), BaseContainer.getCPtr(data), BaseDraw.getCPtr(bd), SWIGTYPE_p_EditorWindow.getCPtr(win), BaseContainer.getCPtr(msg)) : C4dApiPINVOKE.BrushToolData_MouseInput(swigCPtr, BaseDocument.getCPtr(doc), BaseContainer.getCPtr(data), BaseDraw.getCPtr(bd), SWIGTYPE_p_EditorWindow.getCPtr(win), BaseContainer.getCPtr(msg)));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool MouseInputStart(BaseDocument doc, BaseContainer data, BaseDraw bd, SWIGTYPE_p_EditorWindow win, BaseContainer msg, SWIGTYPE_p_LONG flags) {
    bool ret = (SwigDerivedClassHasMethod("MouseInputStart", swigMethodTypes9) ? C4dApiPINVOKE.BrushToolData_MouseInputStartSwigExplicitBrushToolData(swigCPtr, BaseDocument.getCPtr(doc), BaseContainer.getCPtr(data), BaseDraw.getCPtr(bd), SWIGTYPE_p_EditorWindow.getCPtr(win), BaseContainer.getCPtr(msg), SWIGTYPE_p_LONG.getCPtr(flags)) : C4dApiPINVOKE.BrushToolData_MouseInputStart(swigCPtr, BaseDocument.getCPtr(doc), BaseContainer.getCPtr(data), BaseDraw.getCPtr(bd), SWIGTYPE_p_EditorWindow.getCPtr(win), BaseContainer.getCPtr(msg), SWIGTYPE_p_LONG.getCPtr(flags)));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool MouseInputDrag(BaseDocument doc, BaseContainer data, BaseDraw bd, SWIGTYPE_p_EditorWindow win, BaseContainer msg, BrushVertexData vdata, int vcnt, double x, double y, SWIGTYPE_p_LONG flags) {
    bool ret = (SwigDerivedClassHasMethod("MouseInputDrag", swigMethodTypes10) ? C4dApiPINVOKE.BrushToolData_MouseInputDragSwigExplicitBrushToolData(swigCPtr, BaseDocument.getCPtr(doc), BaseContainer.getCPtr(data), BaseDraw.getCPtr(bd), SWIGTYPE_p_EditorWindow.getCPtr(win), BaseContainer.getCPtr(msg), BrushVertexData.getCPtr(vdata), vcnt, x, y, SWIGTYPE_p_LONG.getCPtr(flags)) : C4dApiPINVOKE.BrushToolData_MouseInputDrag(swigCPtr, BaseDocument.getCPtr(doc), BaseContainer.getCPtr(data), BaseDraw.getCPtr(bd), SWIGTYPE_p_EditorWindow.getCPtr(win), BaseContainer.getCPtr(msg), BrushVertexData.getCPtr(vdata), vcnt, x, y, SWIGTYPE_p_LONG.getCPtr(flags)));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool MouseInputEnd(BaseDocument doc, BaseContainer data, BaseDraw bd, SWIGTYPE_p_EditorWindow win, BaseContainer msg) {
    bool ret = (SwigDerivedClassHasMethod("MouseInputEnd", swigMethodTypes11) ? C4dApiPINVOKE.BrushToolData_MouseInputEndSwigExplicitBrushToolData(swigCPtr, BaseDocument.getCPtr(doc), BaseContainer.getCPtr(data), BaseDraw.getCPtr(bd), SWIGTYPE_p_EditorWindow.getCPtr(win), BaseContainer.getCPtr(msg)) : C4dApiPINVOKE.BrushToolData_MouseInputEnd(swigCPtr, BaseDocument.getCPtr(doc), BaseContainer.getCPtr(data), BaseDraw.getCPtr(bd), SWIGTYPE_p_EditorWindow.getCPtr(win), BaseContainer.getCPtr(msg)));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private void SwigDirectorConnect() {
    if (SwigDerivedClassHasMethod("InitTool", swigMethodTypes0))
      swigDelegate0 = new SwigDelegateBrushToolData_0(SwigDirectorInitTool);
    if (SwigDerivedClassHasMethod("FreeTool", swigMethodTypes1))
      swigDelegate1 = new SwigDelegateBrushToolData_1(SwigDirectorFreeTool);
    if (SwigDerivedClassHasMethod("InitDefaultSettings", swigMethodTypes2))
      swigDelegate2 = new SwigDelegateBrushToolData_2(SwigDirectorInitDefaultSettings);
    if (SwigDerivedClassHasMethod("GetDEnabling", swigMethodTypes3))
      swigDelegate3 = new SwigDelegateBrushToolData_3(SwigDirectorGetDEnabling);
    if (SwigDerivedClassHasMethod("SetDParameter", swigMethodTypes4))
      swigDelegate4 = new SwigDelegateBrushToolData_4(SwigDirectorSetDParameter);
    if (SwigDerivedClassHasMethod("GetDDescription", swigMethodTypes5))
      swigDelegate5 = new SwigDelegateBrushToolData_5(SwigDirectorGetDDescription);
    if (SwigDerivedClassHasMethod("Message", swigMethodTypes6))
      swigDelegate6 = new SwigDelegateBrushToolData_6(SwigDirectorMessage);
    if (SwigDerivedClassHasMethod("GetCursorInfo", swigMethodTypes7))
      swigDelegate7 = new SwigDelegateBrushToolData_7(SwigDirectorGetCursorInfo);
    if (SwigDerivedClassHasMethod("MouseInput", swigMethodTypes8))
      swigDelegate8 = new SwigDelegateBrushToolData_8(SwigDirectorMouseInput);
    if (SwigDerivedClassHasMethod("MouseInputStart", swigMethodTypes9))
      swigDelegate9 = new SwigDelegateBrushToolData_9(SwigDirectorMouseInputStart);
    if (SwigDerivedClassHasMethod("MouseInputDrag", swigMethodTypes10))
      swigDelegate10 = new SwigDelegateBrushToolData_10(SwigDirectorMouseInputDrag);
    if (SwigDerivedClassHasMethod("MouseInputEnd", swigMethodTypes11))
      swigDelegate11 = new SwigDelegateBrushToolData_11(SwigDirectorMouseInputEnd);
    C4dApiPINVOKE.BrushToolData_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11);
  }

  private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes) {
    System.Reflection.MethodInfo methodInfo = this.GetType().GetMethod(methodName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance, null, methodTypes, null);
    bool hasDerivedMethod = methodInfo.DeclaringType.IsSubclassOf(typeof(BrushToolData));
    return hasDerivedMethod;
  }

  private bool SwigDirectorInitTool(IntPtr doc, IntPtr data, IntPtr bt) {
    return InitTool((doc == IntPtr.Zero) ? null : new BaseDocument(doc, false), new BaseContainer(data, false), (bt == IntPtr.Zero) ? null : new BaseThread(bt, false));
  }

  private void SwigDirectorFreeTool(IntPtr doc, IntPtr data) {
    FreeTool((doc == IntPtr.Zero) ? null : new BaseDocument(doc, false), new BaseContainer(data, false));
  }

  private void SwigDirectorInitDefaultSettings(IntPtr doc, IntPtr data) {
    InitDefaultSettings((doc == IntPtr.Zero) ? null : new BaseDocument(doc, false), new BaseContainer(data, false));
  }

  private bool SwigDirectorGetDEnabling(IntPtr doc, IntPtr data, IntPtr id, IntPtr t_data, int flags, IntPtr itemdesc) {
    return GetDEnabling((doc == IntPtr.Zero) ? null : new BaseDocument(doc, false), new BaseContainer(data, false), new DescID(id, false), new GeData(t_data, false), (DESCFLAGS_ENABLE)flags, (itemdesc == IntPtr.Zero) ? null : new BaseContainer(itemdesc, false));
  }

  private bool SwigDirectorSetDParameter(IntPtr doc, IntPtr data, IntPtr id, IntPtr t_data, IntPtr flags) {
    return SetDParameter((doc == IntPtr.Zero) ? null : new BaseDocument(doc, false), new BaseContainer(data, false), new DescID(id, false), new GeData(t_data, false), new SWIGTYPE_p_DESCFLAGS_SET(flags, false));
  }

  private bool SwigDirectorGetDDescription(IntPtr doc, IntPtr data, IntPtr description, IntPtr flags) {
    return GetDDescription((doc == IntPtr.Zero) ? null : new BaseDocument(doc, false), new BaseContainer(data, false), (description == IntPtr.Zero) ? null : new Description(description, false), new SWIGTYPE_p_DESCFLAGS_DESC(flags, false));
  }

  private bool SwigDirectorMessage(IntPtr doc, IntPtr data, int type, IntPtr t_data) {
    return Message((doc == IntPtr.Zero) ? null : new BaseDocument(doc, false), new BaseContainer(data, false), type, (t_data == IntPtr.Zero) ? null : new SWIGTYPE_p_void(t_data, false));
  }

  private bool SwigDirectorGetCursorInfo(IntPtr doc, IntPtr data, IntPtr bd, double x, double y, IntPtr bc) {
    return GetCursorInfo((doc == IntPtr.Zero) ? null : new BaseDocument(doc, false), new BaseContainer(data, false), (bd == IntPtr.Zero) ? null : new BaseDraw(bd, false), x, y, new BaseContainer(bc, false));
  }

  private bool SwigDirectorMouseInput(IntPtr doc, IntPtr data, IntPtr bd, IntPtr win, IntPtr msg) {
    return MouseInput((doc == IntPtr.Zero) ? null : new BaseDocument(doc, false), new BaseContainer(data, false), (bd == IntPtr.Zero) ? null : new BaseDraw(bd, false), (win == IntPtr.Zero) ? null : new SWIGTYPE_p_EditorWindow(win, false), new BaseContainer(msg, false));
  }

  private bool SwigDirectorMouseInputStart(IntPtr doc, IntPtr data, IntPtr bd, IntPtr win, IntPtr msg, IntPtr flags) {
    return MouseInputStart((doc == IntPtr.Zero) ? null : new BaseDocument(doc, false), new BaseContainer(data, false), (bd == IntPtr.Zero) ? null : new BaseDraw(bd, false), (win == IntPtr.Zero) ? null : new SWIGTYPE_p_EditorWindow(win, false), new BaseContainer(msg, false), new SWIGTYPE_p_LONG(flags, false));
  }

  private bool SwigDirectorMouseInputDrag(IntPtr doc, IntPtr data, IntPtr bd, IntPtr win, IntPtr msg, IntPtr vdata, int vcnt, double x, double y, IntPtr flags) {
    return MouseInputDrag((doc == IntPtr.Zero) ? null : new BaseDocument(doc, false), new BaseContainer(data, false), (bd == IntPtr.Zero) ? null : new BaseDraw(bd, false), (win == IntPtr.Zero) ? null : new SWIGTYPE_p_EditorWindow(win, false), new BaseContainer(msg, false), (vdata == IntPtr.Zero) ? null : new BrushVertexData(vdata, false), vcnt, x, y, new SWIGTYPE_p_LONG(flags, false));
  }

  private bool SwigDirectorMouseInputEnd(IntPtr doc, IntPtr data, IntPtr bd, IntPtr win, IntPtr msg) {
    return MouseInputEnd((doc == IntPtr.Zero) ? null : new BaseDocument(doc, false), new BaseContainer(data, false), (bd == IntPtr.Zero) ? null : new BaseDraw(bd, false), (win == IntPtr.Zero) ? null : new SWIGTYPE_p_EditorWindow(win, false), new BaseContainer(msg, false));
  }

  public delegate bool SwigDelegateBrushToolData_0(IntPtr doc, IntPtr data, IntPtr bt);
  public delegate void SwigDelegateBrushToolData_1(IntPtr doc, IntPtr data);
  public delegate void SwigDelegateBrushToolData_2(IntPtr doc, IntPtr data);
  public delegate bool SwigDelegateBrushToolData_3(IntPtr doc, IntPtr data, IntPtr id, IntPtr t_data, int flags, IntPtr itemdesc);
  public delegate bool SwigDelegateBrushToolData_4(IntPtr doc, IntPtr data, IntPtr id, IntPtr t_data, IntPtr flags);
  public delegate bool SwigDelegateBrushToolData_5(IntPtr doc, IntPtr data, IntPtr description, IntPtr flags);
  public delegate bool SwigDelegateBrushToolData_6(IntPtr doc, IntPtr data, int type, IntPtr t_data);
  public delegate bool SwigDelegateBrushToolData_7(IntPtr doc, IntPtr data, IntPtr bd, double x, double y, IntPtr bc);
  public delegate bool SwigDelegateBrushToolData_8(IntPtr doc, IntPtr data, IntPtr bd, IntPtr win, IntPtr msg);
  public delegate bool SwigDelegateBrushToolData_9(IntPtr doc, IntPtr data, IntPtr bd, IntPtr win, IntPtr msg, IntPtr flags);
  public delegate bool SwigDelegateBrushToolData_10(IntPtr doc, IntPtr data, IntPtr bd, IntPtr win, IntPtr msg, IntPtr vdata, int vcnt, double x, double y, IntPtr flags);
  public delegate bool SwigDelegateBrushToolData_11(IntPtr doc, IntPtr data, IntPtr bd, IntPtr win, IntPtr msg);

  private SwigDelegateBrushToolData_0 swigDelegate0;
  private SwigDelegateBrushToolData_1 swigDelegate1;
  private SwigDelegateBrushToolData_2 swigDelegate2;
  private SwigDelegateBrushToolData_3 swigDelegate3;
  private SwigDelegateBrushToolData_4 swigDelegate4;
  private SwigDelegateBrushToolData_5 swigDelegate5;
  private SwigDelegateBrushToolData_6 swigDelegate6;
  private SwigDelegateBrushToolData_7 swigDelegate7;
  private SwigDelegateBrushToolData_8 swigDelegate8;
  private SwigDelegateBrushToolData_9 swigDelegate9;
  private SwigDelegateBrushToolData_10 swigDelegate10;
  private SwigDelegateBrushToolData_11 swigDelegate11;

  private static Type[] swigMethodTypes0 = new Type[] { typeof(BaseDocument), typeof(BaseContainer), typeof(BaseThread) };
  private static Type[] swigMethodTypes1 = new Type[] { typeof(BaseDocument), typeof(BaseContainer) };
  private static Type[] swigMethodTypes2 = new Type[] { typeof(BaseDocument), typeof(BaseContainer) };
  private static Type[] swigMethodTypes3 = new Type[] { typeof(BaseDocument), typeof(BaseContainer), typeof(DescID), typeof(GeData), typeof(DESCFLAGS_ENABLE), typeof(BaseContainer) };
  private static Type[] swigMethodTypes4 = new Type[] { typeof(BaseDocument), typeof(BaseContainer), typeof(DescID), typeof(GeData), typeof(SWIGTYPE_p_DESCFLAGS_SET) };
  private static Type[] swigMethodTypes5 = new Type[] { typeof(BaseDocument), typeof(BaseContainer), typeof(Description), typeof(SWIGTYPE_p_DESCFLAGS_DESC) };
  private static Type[] swigMethodTypes6 = new Type[] { typeof(BaseDocument), typeof(BaseContainer), typeof(int), typeof(SWIGTYPE_p_void) };
  private static Type[] swigMethodTypes7 = new Type[] { typeof(BaseDocument), typeof(BaseContainer), typeof(BaseDraw), typeof(double), typeof(double), typeof(BaseContainer) };
  private static Type[] swigMethodTypes8 = new Type[] { typeof(BaseDocument), typeof(BaseContainer), typeof(BaseDraw), typeof(SWIGTYPE_p_EditorWindow), typeof(BaseContainer) };
  private static Type[] swigMethodTypes9 = new Type[] { typeof(BaseDocument), typeof(BaseContainer), typeof(BaseDraw), typeof(SWIGTYPE_p_EditorWindow), typeof(BaseContainer), typeof(SWIGTYPE_p_LONG) };
  private static Type[] swigMethodTypes10 = new Type[] { typeof(BaseDocument), typeof(BaseContainer), typeof(BaseDraw), typeof(SWIGTYPE_p_EditorWindow), typeof(BaseContainer), typeof(BrushVertexData), typeof(int), typeof(double), typeof(double), typeof(SWIGTYPE_p_LONG) };
  private static Type[] swigMethodTypes11 = new Type[] { typeof(BaseDocument), typeof(BaseContainer), typeof(BaseDraw), typeof(SWIGTYPE_p_EditorWindow), typeof(BaseContainer) };
}

}
