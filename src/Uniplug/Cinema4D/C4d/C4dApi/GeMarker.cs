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

public class GeMarker : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal GeMarker(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(GeMarker obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          throw new MethodAccessException("C++ destructor does not have public access");
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public bool Content() {
    bool ret = C4dApiPINVOKE.GeMarker_Content(swigCPtr);
    return ret;
  }

  public bool IsEqual(GeMarker m) {
    bool ret = C4dApiPINVOKE.GeMarker_IsEqual(swigCPtr, GeMarker.getCPtr(m));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int Compare(GeMarker m) {
    int ret = C4dApiPINVOKE.GeMarker_Compare(swigCPtr, GeMarker.getCPtr(m));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void Set(GeMarker m) {
    C4dApiPINVOKE.GeMarker_Set(swigCPtr, GeMarker.getCPtr(m));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
  }

  public bool Read(SWIGTYPE_p_HyperFile hf) {
    bool ret = C4dApiPINVOKE.GeMarker_Read(swigCPtr, SWIGTYPE_p_HyperFile.getCPtr(hf));
    return ret;
  }

  public bool Write(SWIGTYPE_p_HyperFile hf) {
    bool ret = C4dApiPINVOKE.GeMarker_Write(swigCPtr, SWIGTYPE_p_HyperFile.getCPtr(hf));
    return ret;
  }

  public void GetMemory(SWIGTYPE_p_p_void data, SWIGTYPE_p_LONG size) {
    C4dApiPINVOKE.GeMarker_GetMemory(swigCPtr, SWIGTYPE_p_p_void.getCPtr(data), SWIGTYPE_p_LONG.getCPtr(size));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
  }

  public static GeMarker Alloc() {
    IntPtr cPtr = C4dApiPINVOKE.GeMarker_Alloc();
    GeMarker ret = (cPtr == IntPtr.Zero) ? null : new GeMarker(cPtr, false);
    return ret;
  }

  public static void Free(SWIGTYPE_p_p_GeMarker obj) {
    C4dApiPINVOKE.GeMarker_Free(SWIGTYPE_p_p_GeMarker.getCPtr(obj));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
  }

}

}
