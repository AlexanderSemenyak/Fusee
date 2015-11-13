/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 3.0.2
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace C4d {

public class BaseBitmap : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal BaseBitmap(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(BaseBitmap obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          throw new global::System.MethodAccessException("C++ destructor does not have public access");
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public BaseBitmap GetClone() {
    global::System.IntPtr cPtr = C4dApiPINVOKE.BaseBitmap_GetClone(swigCPtr);
    BaseBitmap ret = (cPtr == global::System.IntPtr.Zero) ? null : new BaseBitmap(cPtr, false);
    return ret;
  }

  public BaseBitmap GetClonePart(int x, int y, int w, int h) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.BaseBitmap_GetClonePart(swigCPtr, x, y, w, h);
    BaseBitmap ret = (cPtr == global::System.IntPtr.Zero) ? null : new BaseBitmap(cPtr, false);
    return ret;
  }

  public bool CopyTo(BaseBitmap dst) {
    bool ret = C4dApiPINVOKE.BaseBitmap_CopyTo(swigCPtr, BaseBitmap.getCPtr(dst));
    return ret;
  }

  public void FlushAll() {
    C4dApiPINVOKE.BaseBitmap_FlushAll(swigCPtr);
  }

  public int GetBw() {
    int ret = C4dApiPINVOKE.BaseBitmap_GetBw(swigCPtr);
    return ret;
  }

  public int GetBh() {
    int ret = C4dApiPINVOKE.BaseBitmap_GetBh(swigCPtr);
    return ret;
  }

  public int GetBt() {
    int ret = C4dApiPINVOKE.BaseBitmap_GetBt(swigCPtr);
    return ret;
  }

  public int GetBpz() {
    int ret = C4dApiPINVOKE.BaseBitmap_GetBpz(swigCPtr);
    return ret;
  }

  public COLORMODE GetColorMode() {
    COLORMODE ret = (COLORMODE)C4dApiPINVOKE.BaseBitmap_GetColorMode(swigCPtr);
    return ret;
  }

  public static IMAGERESULT Init(SWIGTYPE_p_p_BaseBitmap res, Filename name, int frame, SWIGTYPE_p_Bool ismovie, SWIGTYPE_p_p_BitmapLoaderPlugin loaderplugin) {
    IMAGERESULT ret = (IMAGERESULT)C4dApiPINVOKE.BaseBitmap_Init__SWIG_0(SWIGTYPE_p_p_BaseBitmap.getCPtr(res), Filename.getCPtr(name), frame, SWIGTYPE_p_Bool.getCPtr(ismovie), SWIGTYPE_p_p_BitmapLoaderPlugin.getCPtr(loaderplugin));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public static IMAGERESULT Init(SWIGTYPE_p_p_BaseBitmap res, Filename name, int frame, SWIGTYPE_p_Bool ismovie) {
    IMAGERESULT ret = (IMAGERESULT)C4dApiPINVOKE.BaseBitmap_Init__SWIG_1(SWIGTYPE_p_p_BaseBitmap.getCPtr(res), Filename.getCPtr(name), frame, SWIGTYPE_p_Bool.getCPtr(ismovie));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public static IMAGERESULT Init(SWIGTYPE_p_p_BaseBitmap res, Filename name, int frame) {
    IMAGERESULT ret = (IMAGERESULT)C4dApiPINVOKE.BaseBitmap_Init__SWIG_2(SWIGTYPE_p_p_BaseBitmap.getCPtr(res), Filename.getCPtr(name), frame);
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public static IMAGERESULT Init(SWIGTYPE_p_p_BaseBitmap res, Filename name) {
    IMAGERESULT ret = (IMAGERESULT)C4dApiPINVOKE.BaseBitmap_Init__SWIG_3(SWIGTYPE_p_p_BaseBitmap.getCPtr(res), Filename.getCPtr(name));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public IMAGERESULT Init(Filename name, int frame, SWIGTYPE_p_Bool ismovie) {
    IMAGERESULT ret = (IMAGERESULT)C4dApiPINVOKE.BaseBitmap_Init__SWIG_4(swigCPtr, Filename.getCPtr(name), frame, SWIGTYPE_p_Bool.getCPtr(ismovie));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public IMAGERESULT Init(Filename name, int frame) {
    IMAGERESULT ret = (IMAGERESULT)C4dApiPINVOKE.BaseBitmap_Init__SWIG_5(swigCPtr, Filename.getCPtr(name), frame);
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public IMAGERESULT Init(Filename name) {
    IMAGERESULT ret = (IMAGERESULT)C4dApiPINVOKE.BaseBitmap_Init__SWIG_6(swigCPtr, Filename.getCPtr(name));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public IMAGERESULT Init(int x, int y, int depth, INITBITMAPFLAGS flags) {
    IMAGERESULT ret = (IMAGERESULT)C4dApiPINVOKE.BaseBitmap_Init__SWIG_7(swigCPtr, x, y, depth, (int)flags);
    return ret;
  }

  public IMAGERESULT Init(int x, int y, int depth) {
    IMAGERESULT ret = (IMAGERESULT)C4dApiPINVOKE.BaseBitmap_Init__SWIG_8(swigCPtr, x, y, depth);
    return ret;
  }

  public IMAGERESULT Init(int x, int y) {
    IMAGERESULT ret = (IMAGERESULT)C4dApiPINVOKE.BaseBitmap_Init__SWIG_9(swigCPtr, x, y);
    return ret;
  }

  public IMAGERESULT Save(Filename name, int format, BaseContainer data, SAVEBIT savebits) {
    IMAGERESULT ret = (IMAGERESULT)C4dApiPINVOKE.BaseBitmap_Save(swigCPtr, Filename.getCPtr(name), format, BaseContainer.getCPtr(data), (int)savebits);
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void SetCMAP(int i, int r, int g, int b) {
    C4dApiPINVOKE.BaseBitmap_SetCMAP(swigCPtr, i, r, g, b);
  }

  public bool SetPixelCnt(int x, int y, int cnt, SWIGTYPE_p_UChar buffer, int inc, COLORMODE srcmode, PIXELCNT flags) {
    bool ret = C4dApiPINVOKE.BaseBitmap_SetPixelCnt(swigCPtr, x, y, cnt, SWIGTYPE_p_UChar.getCPtr(buffer), inc, (int)srcmode, (int)flags);
    return ret;
  }

  public void GetPixelCnt(int x, int y, int cnt, SWIGTYPE_p_UChar buffer, int inc, COLORMODE dstmode, PIXELCNT flags, ColorProfileConvert conversion) {
    C4dApiPINVOKE.BaseBitmap_GetPixelCnt__SWIG_0(swigCPtr, x, y, cnt, SWIGTYPE_p_UChar.getCPtr(buffer), inc, (int)dstmode, (int)flags, ColorProfileConvert.getCPtr(conversion));
  }

  public void GetPixelCnt(int x, int y, int cnt, SWIGTYPE_p_UChar buffer, int inc, COLORMODE dstmode, PIXELCNT flags) {
    C4dApiPINVOKE.BaseBitmap_GetPixelCnt__SWIG_1(swigCPtr, x, y, cnt, SWIGTYPE_p_UChar.getCPtr(buffer), inc, (int)dstmode, (int)flags);
  }

  public void ScaleIt(BaseBitmap dst, int intens, bool sample, bool nprop) {
    C4dApiPINVOKE.BaseBitmap_ScaleIt(swigCPtr, BaseBitmap.getCPtr(dst), intens, sample, nprop);
  }

  public void ScaleBicubic(BaseBitmap dst, int src_xmin, int src_ymin, int src_xmax, int src_ymax, int dst_xmin, int dst_ymin, int dst_xmax, int dst_ymax) {
    C4dApiPINVOKE.BaseBitmap_ScaleBicubic(swigCPtr, BaseBitmap.getCPtr(dst), src_xmin, src_ymin, src_xmax, src_ymax, dst_xmin, dst_ymin, dst_xmax, dst_ymax);
  }

  public void SetPen(int r, int g, int b) {
    C4dApiPINVOKE.BaseBitmap_SetPen(swigCPtr, r, g, b);
  }

  public void Clear(int r, int g, int b) {
    C4dApiPINVOKE.BaseBitmap_Clear__SWIG_0(swigCPtr, r, g, b);
  }

  public void Clear(int x1, int y1, int x2, int y2, int r, int g, int b) {
    C4dApiPINVOKE.BaseBitmap_Clear__SWIG_1(swigCPtr, x1, y1, x2, y2, r, g, b);
  }

  public void Line(int x1, int y1, int x2, int y2) {
    C4dApiPINVOKE.BaseBitmap_Line(swigCPtr, x1, y1, x2, y2);
  }

  public void Arc(int x, int y, double radius, double angle_start, double angle_end, int subdiv) {
    C4dApiPINVOKE.BaseBitmap_Arc__SWIG_0(swigCPtr, x, y, radius, angle_start, angle_end, subdiv);
  }

  public void Arc(int x, int y, double radius, double angle_start, double angle_end) {
    C4dApiPINVOKE.BaseBitmap_Arc__SWIG_1(swigCPtr, x, y, radius, angle_start, angle_end);
  }

  public bool SetPixel(int x, int y, int r, int g, int b) {
    bool ret = C4dApiPINVOKE.BaseBitmap_SetPixel(swigCPtr, x, y, r, g, b);
    return ret;
  }

  public void GetPixel(int x, int y, SWIGTYPE_p_UInt16 r, SWIGTYPE_p_UInt16 g, SWIGTYPE_p_UInt16 b) {
    C4dApiPINVOKE.BaseBitmap_GetPixel(swigCPtr, x, y, SWIGTYPE_p_UInt16.getCPtr(r), SWIGTYPE_p_UInt16.getCPtr(g), SWIGTYPE_p_UInt16.getCPtr(b));
  }

  public BaseBitmap AddChannel(bool arg0, bool straight) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.BaseBitmap_AddChannel(swigCPtr, arg0, straight);
    BaseBitmap ret = (cPtr == global::System.IntPtr.Zero) ? null : new BaseBitmap(cPtr, false);
    return ret;
  }

  public void RemoveChannel(BaseBitmap channel) {
    C4dApiPINVOKE.BaseBitmap_RemoveChannel(swigCPtr, BaseBitmap.getCPtr(channel));
  }

  public void GetAlphaPixel(BaseBitmap channel, int x, int y, SWIGTYPE_p_UInt16 val) {
    C4dApiPINVOKE.BaseBitmap_GetAlphaPixel(swigCPtr, BaseBitmap.getCPtr(channel), x, y, SWIGTYPE_p_UInt16.getCPtr(val));
  }

  public bool SetAlphaPixel(BaseBitmap channel, int x, int y, int val) {
    bool ret = C4dApiPINVOKE.BaseBitmap_SetAlphaPixel(swigCPtr, BaseBitmap.getCPtr(channel), x, y, val);
    return ret;
  }

  public BaseBitmap GetInternalChannel() {
    global::System.IntPtr cPtr = C4dApiPINVOKE.BaseBitmap_GetInternalChannel__SWIG_0(swigCPtr);
    BaseBitmap ret = (cPtr == global::System.IntPtr.Zero) ? null : new BaseBitmap(cPtr, false);
    return ret;
  }

  public int GetChannelCount() {
    int ret = C4dApiPINVOKE.BaseBitmap_GetChannelCount(swigCPtr);
    return ret;
  }

  public BaseBitmap GetChannelNum(int num) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.BaseBitmap_GetChannelNum__SWIG_0(swigCPtr, num);
    BaseBitmap ret = (cPtr == global::System.IntPtr.Zero) ? null : new BaseBitmap(cPtr, false);
    return ret;
  }

  public bool IsMultipassBitmap() {
    bool ret = C4dApiPINVOKE.BaseBitmap_IsMultipassBitmap(swigCPtr);
    return ret;
  }

  public bool SetData(int id, GeData data) {
    bool ret = C4dApiPINVOKE.BaseBitmap_SetData(swigCPtr, id, GeData.getCPtr(data));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public GeData GetData(int id, GeData t_default) {
    GeData ret = new GeData(C4dApiPINVOKE.BaseBitmap_GetData(swigCPtr, id, GeData.getCPtr(t_default)), true);
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public static BaseBitmap Alloc() {
    global::System.IntPtr cPtr = C4dApiPINVOKE.BaseBitmap_Alloc();
    BaseBitmap ret = (cPtr == global::System.IntPtr.Zero) ? null : new BaseBitmap(cPtr, false);
    return ret;
  }

  public static void Free(SWIGTYPE_p_p_BaseBitmap bc) {
    C4dApiPINVOKE.BaseBitmap_Free(SWIGTYPE_p_p_BaseBitmap.getCPtr(bc));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
  }

  public uint GetDirty() {
    uint ret = C4dApiPINVOKE.BaseBitmap_GetDirty(swigCPtr);
    return ret;
  }

  public void SetDirty() {
    C4dApiPINVOKE.BaseBitmap_SetDirty(swigCPtr);
  }

  public bool CopyPartTo(BaseBitmap dst, int x, int y, int w, int h) {
    bool ret = C4dApiPINVOKE.BaseBitmap_CopyPartTo(swigCPtr, BaseBitmap.getCPtr(dst), x, y, w, h);
    return ret;
  }

  public int GetMemoryInfo() {
    int ret = C4dApiPINVOKE.BaseBitmap_GetMemoryInfo(swigCPtr);
    return ret;
  }

  public BaseBitmap GetUpdateRegionBitmap() {
    global::System.IntPtr cPtr = C4dApiPINVOKE.BaseBitmap_GetUpdateRegionBitmap__SWIG_0(swigCPtr);
    BaseBitmap ret = (cPtr == global::System.IntPtr.Zero) ? null : new BaseBitmap(cPtr, false);
    return ret;
  }

  public bool SetColorProfile(ColorProfile profile) {
    bool ret = C4dApiPINVOKE.BaseBitmap_SetColorProfile(swigCPtr, ColorProfile.getCPtr(profile));
    return ret;
  }

  public ColorProfile GetColorProfile() {
    global::System.IntPtr cPtr = C4dApiPINVOKE.BaseBitmap_GetColorProfile(swigCPtr);
    ColorProfile ret = (cPtr == global::System.IntPtr.Zero) ? null : new ColorProfile(cPtr, false);
    return ret;
  }

  public static BaseBitmap AutoBitmap(string /* constString&_cstype */ str) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.BaseBitmap_AutoBitmap__SWIG_0(str);
    BaseBitmap ret = (cPtr == global::System.IntPtr.Zero) ? null : new BaseBitmap(cPtr, false);
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public static BaseBitmap AutoBitmap(int id) {
    global::System.IntPtr cPtr = C4dApiPINVOKE.BaseBitmap_AutoBitmap__SWIG_1(id);
    BaseBitmap ret = (cPtr == global::System.IntPtr.Zero) ? null : new BaseBitmap(cPtr, false);
    return ret;
  }

}

}