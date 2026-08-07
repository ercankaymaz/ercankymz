// Decompiled with JetBrains decompiler
// Type: MarbleCNC.baslerCamcs
// Assembly: CMDMarbleCNC, Version=3.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: 99805DCC-380E-4FBC-B708-84554BBCD25B
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\CMDMarbleCNC.exe

using Basler.Pylon;
using System;
using System.Drawing;
using System.Drawing.Imaging;

#nullable disable
namespace MarbleCNC;

public class baslerCamcs
{
  public int CameraNumber = 0;
  public static bool isCameraStarted;
  private Camera camera;
  private PixelDataConverter pxConvert = new PixelDataConverter();
  private bool GrabOver = false;

  public event baslerCamcs.CameraImage CameraImageEvent;

  public void CameraInit()
  {
    this.camera = new Camera();
    this.camera.CameraOpened += new EventHandler<EventArgs>(Configuration.AcquireContinuous);
    this.camera.ConnectionLost += new EventHandler<EventArgs>(this.Camera_ConnectionLost);
    this.camera.StreamGrabber.GrabStarted += new EventHandler<EventArgs>(this.StreamGrabber_GrabStarted);
    this.camera.StreamGrabber.ImageGrabbed += new EventHandler<ImageGrabbedEventArgs>(this.StreamGrabber_ImageGrabbed);
    this.camera.StreamGrabber.GrabStopped += new EventHandler<GrabStopEventArgs>(this.StreamGrabber_GrabStopped);
    this.camera.Open();
  }

  private void StreamGrabber_GrabStarted(object sender, EventArgs e) => this.GrabOver = true;

  private void StreamGrabber_ImageGrabbed(object sender, ImageGrabbedEventArgs e)
  {
    IGrabResult grabResult = e.GrabResult;
    if (!grabResult.IsValid || !this.GrabOver)
      return;
    this.CameraImageEvent(this.GrabResult2Bmp(grabResult));
  }

  private void StreamGrabber_GrabStopped(object sender, GrabStopEventArgs e)
  {
    this.GrabOver = false;
  }

  private void Camera_ConnectionLost(object sender, EventArgs e)
  {
    this.camera.StreamGrabber.Stop();
    this.DestroyCamera();
  }

  public void SetExposureTime(int Val)
  {
    this.camera.Parameters[PLCamera.ExposureTimeAbs].SetValue((double) Val);
  }

  public void SetReverseX(bool Val) => this.camera.Parameters[PLCamera.ReverseX].SetValue(Val);

  public void SetReverseY(bool Val) => this.camera.Parameters[PLCamera.ReverseY].SetValue(Val);

  public void OneShot()
  {
    if (this.camera == null)
      return;
    this.camera.Parameters[(EnumName) (ParameterListEnum) PLCamera.AcquisitionMode].SetValue(PLCamera.AcquisitionMode.SingleFrame);
    this.camera.StreamGrabber.Start(1L, GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);
  }

  public void KeepShot()
  {
    if (this.camera == null)
      return;
    this.camera.Parameters[(EnumName) (ParameterListEnum) PLCamera.AcquisitionMode].SetValue(PLCamera.AcquisitionMode.Continuous);
    this.camera.StreamGrabber.Start(GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);
    baslerCamcs.isCameraStarted = true;
  }

  public void Stop()
  {
    if (this.camera == null)
      return;
    this.camera.StreamGrabber.Stop();
    baslerCamcs.isCameraStarted = false;
  }

  private Bitmap GrabResult2Bmp(IGrabResult grabResult)
  {
    Bitmap bitmap = new Bitmap(grabResult.Width, grabResult.Height, PixelFormat.Format32bppRgb);
    BitmapData bitmapdata = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
    this.pxConvert.OutputPixelFormat = PixelType.BGRA8packed;
    this.pxConvert.Convert(bitmapdata.Scan0, (long) (bitmapdata.Stride * bitmap.Height), (IImage) grabResult);
    bitmap.UnlockBits(bitmapdata);
    return bitmap;
  }

  public void DestroyCamera()
  {
    if (this.camera == null)
      return;
    this.camera.Close();
    this.camera.Dispose();
    this.camera = (Camera) null;
  }

  public delegate void CameraImage(Bitmap bmp);
}
