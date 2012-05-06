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

public class VariableChanged : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal VariableChanged(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(VariableChanged obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~VariableChanged() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          C4dApiPINVOKE.delete_VariableChanged(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public VariableChanged() : this(C4dApiPINVOKE.new_VariableChanged(), true) {
  }

  public int old_cnt {
    set {
      C4dApiPINVOKE.VariableChanged_old_cnt_set(swigCPtr, value);
    } 
    get {
      int ret = C4dApiPINVOKE.VariableChanged_old_cnt_get(swigCPtr);
      return ret;
    } 
  }

  public int new_cnt {
    set {
      C4dApiPINVOKE.VariableChanged_new_cnt_set(swigCPtr, value);
    } 
    get {
      int ret = C4dApiPINVOKE.VariableChanged_new_cnt_get(swigCPtr);
      return ret;
    } 
  }

  public SWIGTYPE_p_LONG map {
    set {
      C4dApiPINVOKE.VariableChanged_map_set(swigCPtr, SWIGTYPE_p_LONG.getCPtr(value));
    } 
    get {
      IntPtr cPtr = C4dApiPINVOKE.VariableChanged_map_get(swigCPtr);
      SWIGTYPE_p_LONG ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_LONG(cPtr, false);
      return ret;
    } 
  }

  public int vc_flags {
    set {
      C4dApiPINVOKE.VariableChanged_vc_flags_set(swigCPtr, value);
    } 
    get {
      int ret = C4dApiPINVOKE.VariableChanged_vc_flags_get(swigCPtr);
      return ret;
    } 
  }

}

}
