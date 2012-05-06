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

public class GvAnimHook : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal GvAnimHook(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(GvAnimHook obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~GvAnimHook() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          C4dApiPINVOKE.delete_GvAnimHook(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public GvAnimHook() : this(C4dApiPINVOKE.new_GvAnimHook(), true) {
  }

  public BaseDocument document {
    set {
      C4dApiPINVOKE.GvAnimHook_document_set(swigCPtr, BaseDocument.getCPtr(value));
    } 
    get {
      IntPtr cPtr = C4dApiPINVOKE.GvAnimHook_document_get(swigCPtr);
      BaseDocument ret = (cPtr == IntPtr.Zero) ? null : new BaseDocument(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_void user {
    set {
      C4dApiPINVOKE.GvAnimHook_user_set(swigCPtr, SWIGTYPE_p_void.getCPtr(value));
    } 
    get {
      IntPtr cPtr = C4dApiPINVOKE.GvAnimHook_user_get(swigCPtr);
      SWIGTYPE_p_void ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_void(cPtr, false);
      return ret;
    } 
  }

  public GvCalcTime time {
    set {
      C4dApiPINVOKE.GvAnimHook_time_set(swigCPtr, GvCalcTime.getCPtr(value));
    } 
    get {
      IntPtr cPtr = C4dApiPINVOKE.GvAnimHook_time_get(swigCPtr);
      GvCalcTime ret = (cPtr == IntPtr.Zero) ? null : new GvCalcTime(cPtr, false);
      return ret;
    } 
  }

}

}
