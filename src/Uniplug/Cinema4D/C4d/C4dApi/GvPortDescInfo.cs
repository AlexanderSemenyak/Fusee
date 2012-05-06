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

public class GvPortDescInfo : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal GvPortDescInfo(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(GvPortDescInfo obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~GvPortDescInfo() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          C4dApiPINVOKE.delete_GvPortDescInfo(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public int count {
    set {
      C4dApiPINVOKE.GvPortDescInfo_count_set(swigCPtr, value);
    } 
    get {
      int ret = C4dApiPINVOKE.GvPortDescInfo_count_get(swigCPtr);
      return ret;
    } 
  }

  public SWIGTYPE_p_LONG types {
    set {
      C4dApiPINVOKE.GvPortDescInfo_types_set(swigCPtr, SWIGTYPE_p_LONG.getCPtr(value));
    } 
    get {
      IntPtr cPtr = C4dApiPINVOKE.GvPortDescInfo_types_get(swigCPtr);
      SWIGTYPE_p_LONG ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_LONG(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_ULONG flags {
    set {
      C4dApiPINVOKE.GvPortDescInfo_flags_set(swigCPtr, SWIGTYPE_p_ULONG.getCPtr(value));
    } 
    get {
      IntPtr cPtr = C4dApiPINVOKE.GvPortDescInfo_flags_get(swigCPtr);
      SWIGTYPE_p_ULONG ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_ULONG(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_LONG ids {
    set {
      C4dApiPINVOKE.GvPortDescInfo_ids_set(swigCPtr, SWIGTYPE_p_LONG.getCPtr(value));
    } 
    get {
      IntPtr cPtr = C4dApiPINVOKE.GvPortDescInfo_ids_get(swigCPtr);
      SWIGTYPE_p_LONG ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_LONG(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_LONG name_ids {
    set {
      C4dApiPINVOKE.GvPortDescInfo_name_ids_set(swigCPtr, SWIGTYPE_p_LONG.getCPtr(value));
    } 
    get {
      IntPtr cPtr = C4dApiPINVOKE.GvPortDescInfo_name_ids_get(swigCPtr);
      SWIGTYPE_p_LONG ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_LONG(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_p_String names {
    set {
      C4dApiPINVOKE.GvPortDescInfo_names_set(swigCPtr, SWIGTYPE_p_p_String.getCPtr(value));
    } 
    get {
      IntPtr cPtr = C4dApiPINVOKE.GvPortDescInfo_names_get(swigCPtr);
      SWIGTYPE_p_p_String ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_p_String(cPtr, false);
      return ret;
    } 
  }

  public GvPortDescInfo() : this(C4dApiPINVOKE.new_GvPortDescInfo(), true) {
  }

}

}
