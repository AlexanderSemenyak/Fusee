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

public class BitmapLoaderPlugin : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal BitmapLoaderPlugin(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(BitmapLoaderPlugin obj) {
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

  public bool BmIdentify(SWIGTYPE_p_Filename name, SWIGTYPE_p_UCHAR probe, int size) {
    bool ret = C4dApiPINVOKE.BitmapLoaderPlugin_BmIdentify(swigCPtr, SWIGTYPE_p_Filename.getCPtr(name), SWIGTYPE_p_UCHAR.getCPtr(probe), size);
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public IMAGERESULT BmLoad(SWIGTYPE_p_Filename name, BaseBitmap bm, int frame) {
    IMAGERESULT ret = (IMAGERESULT)C4dApiPINVOKE.BitmapLoaderPlugin_BmLoad(swigCPtr, SWIGTYPE_p_Filename.getCPtr(name), BaseBitmap.getCPtr(bm), frame);
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int BmGetSaver() {
    int ret = C4dApiPINVOKE.BitmapLoaderPlugin_BmGetSaver(swigCPtr);
    return ret;
  }

  public bool BmGetInformation(SWIGTYPE_p_Filename name, SWIGTYPE_p_LONG frames, SWIGTYPE_p_Real fps) {
    bool ret = C4dApiPINVOKE.BitmapLoaderPlugin_BmGetInformation(swigCPtr, SWIGTYPE_p_Filename.getCPtr(name), SWIGTYPE_p_LONG.getCPtr(frames), SWIGTYPE_p_Real.getCPtr(fps));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public IMAGERESULT BmLoadAnimated(SWIGTYPE_p_BitmapLoaderAnimatedData bd, SWIGTYPE_p_BITMAPLOADERACTION action, BaseBitmap bm, int frame) {
    IMAGERESULT ret = (IMAGERESULT)C4dApiPINVOKE.BitmapLoaderPlugin_BmLoadAnimated(swigCPtr, SWIGTYPE_p_BitmapLoaderAnimatedData.getCPtr(bd), SWIGTYPE_p_BITMAPLOADERACTION.getCPtr(action), BaseBitmap.getCPtr(bm), frame);
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public IMAGERESULT BmExtractSound(SWIGTYPE_p_BitmapLoaderAnimatedData bd, SWIGTYPE_p_BaseSound snd) {
    IMAGERESULT ret = (IMAGERESULT)C4dApiPINVOKE.BitmapLoaderPlugin_BmExtractSound(swigCPtr, SWIGTYPE_p_BitmapLoaderAnimatedData.getCPtr(bd), SWIGTYPE_p_BaseSound.getCPtr(snd));
    return ret;
  }

}

}
