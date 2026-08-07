// Decompiled with JetBrains decompiler
// Type: buCamera.BaslerCamera.BaslerCamera
// Assembly: buCamera, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 458B46D1-65F2-4D88-8223-244FCE315356
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\Camera\Canon\buCamera.dll

using Basler.Pylon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

#nullable disable
namespace buCamera.BaslerCamera;

public class BaslerCamera
{
  private PixelDataConverter pxConvert = new PixelDataConverter();
  public List<ICameraInfo> deviceList = IpConfigurator.EnumerateAllDevices();
  private ICameraInfo cam_device;
  public static Camera camera;
  public bool GrabOver = false;
  public static bool cameraIsOpen;
  public static bool CameraSucces;
  private bool firstStart = true;

  public event buCamera.BaslerCamera.BaslerCamera.CameraImage CameraImageEvent;

  public void CameraInit(double shutterSpd)
  {
    try
    {
      buCamera.BaslerCamera.BaslerCamera.camera?.Dispose();
      if (this.deviceList == null || this.deviceList.Count == 0)
      {
        int num = (int) MessageBox.Show("No Basler camera detected. Please check the connection.", "Camera Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        buCamera.BaslerCamera.BaslerCamera.camera = new Camera();
        buCamera.BaslerCamera.BaslerCamera.camera.CameraOpened += new EventHandler<EventArgs>(Configuration.AcquireContinuous);
        buCamera.BaslerCamera.BaslerCamera.camera.ConnectionLost += new EventHandler<EventArgs>(this.Camera_ConnectionLost);
        buCamera.BaslerCamera.BaslerCamera.camera.StreamGrabber.GrabStarted += new EventHandler<EventArgs>(this.StreamGrabber_GrabStarted);
        buCamera.BaslerCamera.BaslerCamera.camera.StreamGrabber.ImageGrabbed += new EventHandler<ImageGrabbedEventArgs>(this.StreamGrabber_ImageGrabbed);
        buCamera.BaslerCamera.BaslerCamera.camera.StreamGrabber.GrabStopped += new EventHandler<GrabStopEventArgs>(this.StreamGrabber_GrabStopped);
        buCamera.BaslerCamera.BaslerCamera.camera.Open();
        buCamera.BaslerCamera.BaslerCamera.camera.Parameters[(EnumName) (ParameterListEnum) PLGigECamera.ExposureAuto].SetValue(PLGigECamera.ExposureAuto.Off);
        buCamera.BaslerCamera.BaslerCamera.camera.Parameters[(EnumName) (ParameterListEnum) PLGigECamera.ExposureMode].SetValue(PLGigECamera.ExposureMode.Timed);
        buCamera.BaslerCamera.BaslerCamera.camera.Parameters[(EnumName) (ParameterListEnum) PLCamera.BslExposureTimeMode].SetValue(PLCamera.BslExposureTimeMode.Standard);
        buCamera.BaslerCamera.BaslerCamera.camera.Parameters[PLCamera.ExposureTime].TrySetValue(shutterSpd);
        buCamera.BaslerCamera.BaslerCamera.CameraSucces = true;
        buCamera.BaslerCamera.BaslerCamera.cameraIsOpen = true;
      }
    }
    catch (Exception ex)
    {
      if (this.firstStart)
      {
        this.Ip_Configuration();
        if (this.cam_device != null)
          this.CameraInit(shutterSpd);
      }
      this.Stop();
      buCamera.BaslerCamera.BaslerCamera.camera = (Camera) null;
    }
  }

  private void Ip_Configuration()
  {
    foreach (ICameraInfo device in this.deviceList)
      this.cam_device = device;
    if (this.cam_device == null)
      return;
    string str = this.cam_device[CameraInfoKey.DefaultGateway];
    IpConfigurator.ChangeIpConfiguration(this.cam_device[CameraInfoKey.DeviceMacAddress], IpConfigurationMethod.AutoIP);
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
    buCamera.BaslerCamera.BaslerCamera.DestroyCamera();
    this.firstStart = false;
  }

  public Bitmap FrameShot()
  {
    return this.GrabResult2Bmp(buCamera.BaslerCamera.BaslerCamera.camera.StreamGrabber.GrabOne(10000));
  }

  public void SetContrast(double contrast)
  {
    if (buCamera.BaslerCamera.BaslerCamera.camera == null)
      return;
    if (contrast > 0.0 && contrast < 1.0)
    {
      try
      {
        buCamera.BaslerCamera.BaslerCamera.camera.Parameters[PLCamera.BslContrast].SetValue(contrast);
      }
      catch (Exception ex)
      {
      }
    }
  }

  public void SetSaturation(double saturation)
  {
    if (buCamera.BaslerCamera.BaslerCamera.camera == null || !buCamera.BaslerCamera.BaslerCamera.cameraIsOpen)
      return;
    if (saturation > 0.0 && saturation < 2.0)
    {
      try
      {
        buCamera.BaslerCamera.BaslerCamera.camera.Parameters[PLCamera.BslSaturation].SetValue(saturation);
      }
      catch (Exception ex)
      {
      }
    }
  }

  public double GetSaturation()
  {
    return buCamera.BaslerCamera.BaslerCamera.camera.IsOpen ? buCamera.BaslerCamera.BaslerCamera.camera.Parameters[PLCamera.BslSaturation].GetValue() : 0.0;
  }

  public void SetBlackLevel(double blackLevel)
  {
    if (buCamera.BaslerCamera.BaslerCamera.camera == null || !buCamera.BaslerCamera.BaslerCamera.cameraIsOpen)
      return;
    try
    {
      buCamera.BaslerCamera.BaslerCamera.camera.Parameters[PLCamera.BlackLevel].SetValue(blackLevel);
    }
    catch (Exception ex)
    {
    }
  }

  public double GetBlackLevel()
  {
    return buCamera.BaslerCamera.BaslerCamera.camera.IsOpen ? buCamera.BaslerCamera.BaslerCamera.camera.Parameters[PLCamera.BlackLevel].GetValue() : 0.0;
  }

  public double GetContrast()
  {
    return buCamera.BaslerCamera.BaslerCamera.camera.IsOpen ? buCamera.BaslerCamera.BaslerCamera.camera.Parameters[PLCamera.BslContrast].GetValue() : 0.0;
  }

  public void SetBrightness(double brightness)
  {
    if (!(buCamera.BaslerCamera.BaslerCamera.camera != null & buCamera.BaslerCamera.BaslerCamera.cameraIsOpen))
      return;
    try
    {
      buCamera.BaslerCamera.BaslerCamera.camera.Parameters[PLCamera.BslBrightness].SetValue(brightness);
    }
    catch (Exception ex)
    {
    }
  }

  public double GetBrightness()
  {
    return buCamera.BaslerCamera.BaslerCamera.camera.IsOpen ? buCamera.BaslerCamera.BaslerCamera.camera.Parameters[PLCamera.BslBrightness].GetValue() : 0.0;
  }

  public void SetGain(double gain)
  {
    if (buCamera.BaslerCamera.BaslerCamera.camera == null || !buCamera.BaslerCamera.BaslerCamera.cameraIsOpen)
      return;
    try
    {
      buCamera.BaslerCamera.BaslerCamera.camera.Parameters[PLCamera.Gain].TrySetValue(gain);
    }
    catch (Exception ex)
    {
    }
  }

  public double GetGain()
  {
    return buCamera.BaslerCamera.BaslerCamera.camera.IsOpen ? buCamera.BaslerCamera.BaslerCamera.camera.Parameters[PLCamera.Gain].GetValue() : 0.0;
  }

  public void BlueOffset(double blue)
  {
    if (buCamera.BaslerCamera.BaslerCamera.camera == null || !buCamera.BaslerCamera.BaslerCamera.cameraIsOpen)
      return;
    if (blue >= 0.25)
    {
      try
      {
        buCamera.BaslerCamera.BaslerCamera.camera.Parameters[(EnumName) (ParameterListEnum) PLCamera.BalanceRatioSelector].SetValue(PLCamera.BalanceRatioSelector.Blue);
        buCamera.BaslerCamera.BaslerCamera.camera.Parameters[PLCamera.BalanceRatio].SetValue(blue);
      }
      catch (Exception ex)
      {
      }
    }
  }

  public double GetBlue()
  {
    buCamera.BaslerCamera.BaslerCamera.camera.Parameters[(EnumName) (ParameterListEnum) PLCamera.BalanceRatioSelector].SetValue(PLCamera.BalanceRatioSelector.Blue);
    return buCamera.BaslerCamera.BaslerCamera.camera.IsOpen ? buCamera.BaslerCamera.BaslerCamera.camera.Parameters[PLCamera.BalanceRatio].GetValue() : 0.0;
  }

  public void RedOffset(double red)
  {
    if (buCamera.BaslerCamera.BaslerCamera.camera == null || !buCamera.BaslerCamera.BaslerCamera.cameraIsOpen)
      return;
    if (red >= 0.25)
    {
      try
      {
        buCamera.BaslerCamera.BaslerCamera.camera.Parameters[(EnumName) (ParameterListEnum) PLCamera.BalanceRatioSelector].SetValue(PLCamera.BalanceRatioSelector.Red);
        buCamera.BaslerCamera.BaslerCamera.camera.Parameters[PLCamera.BalanceRatio].SetValue(red);
      }
      catch (Exception ex)
      {
      }
    }
  }

  public double GetRed()
  {
    buCamera.BaslerCamera.BaslerCamera.camera.Parameters[(EnumName) (ParameterListEnum) PLCamera.BalanceRatioSelector].SetValue(PLCamera.BalanceRatioSelector.Red);
    return buCamera.BaslerCamera.BaslerCamera.camera.IsOpen ? buCamera.BaslerCamera.BaslerCamera.camera.Parameters[PLCamera.BalanceRatio].GetValue() : 0.0;
  }

  public void GreenOffset(double green)
  {
    if (buCamera.BaslerCamera.BaslerCamera.camera == null || !buCamera.BaslerCamera.BaslerCamera.cameraIsOpen || green < 0.25)
      return;
    buCamera.BaslerCamera.BaslerCamera.camera.Parameters[(EnumName) (ParameterListEnum) PLCamera.BalanceRatioSelector].SetValue(PLCamera.BalanceRatioSelector.Green);
    buCamera.BaslerCamera.BaslerCamera.camera.Parameters[PLCamera.BalanceRatio].SetValue(green);
  }

  public double GetGreen()
  {
    buCamera.BaslerCamera.BaslerCamera.camera.Parameters[(EnumName) (ParameterListEnum) PLCamera.BalanceRatioSelector].SetValue(PLCamera.BalanceRatioSelector.Green);
    return buCamera.BaslerCamera.BaslerCamera.camera.IsOpen ? buCamera.BaslerCamera.BaslerCamera.camera.Parameters[PLCamera.BalanceRatio].GetValue() : 0.0;
  }

  public void SetExposure(double expTime)
  {
    if (buCamera.BaslerCamera.BaslerCamera.camera == null || !buCamera.BaslerCamera.BaslerCamera.cameraIsOpen)
      return;
    this.Stop();
    try
    {
      if (expTime > 0.0 && expTime <= 14.0)
      {
        buCamera.BaslerCamera.BaslerCamera.camera.Parameters[(EnumName) (ParameterListEnum) PLCamera.BslExposureTimeMode].SetValue(PLCamera.BslExposureTimeMode.UltraShort);
        buCamera.BaslerCamera.BaslerCamera.camera.Parameters[PLCamera.ExposureTime].TrySetValue(expTime);
      }
      else if (expTime >= 19.0 && expTime <= 5000.0)
      {
        buCamera.BaslerCamera.BaslerCamera.camera.Parameters[(EnumName) (ParameterListEnum) PLCamera.BslExposureTimeMode].SetValue(PLCamera.BslExposureTimeMode.Standard);
        buCamera.BaslerCamera.BaslerCamera.camera.Parameters[PLCamera.ExposureTime].TrySetValue(expTime);
      }
    }
    catch (Exception ex)
    {
    }
    this.FrameShot();
  }

  public double GetExposure()
  {
    return buCamera.BaslerCamera.BaslerCamera.camera.IsOpen ? buCamera.BaslerCamera.BaslerCamera.camera.Parameters[PLCamera.ExposureTime].GetValue() : 0.0;
  }

  public void Stop()
  {
    if (buCamera.BaslerCamera.BaslerCamera.camera == null || !buCamera.BaslerCamera.BaslerCamera.cameraIsOpen)
      return;
    buCamera.BaslerCamera.BaslerCamera.camera.StreamGrabber.Stop();
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

  public void KeepShot()
  {
    if (buCamera.BaslerCamera.BaslerCamera.camera == null)
      return;
    buCamera.BaslerCamera.BaslerCamera.camera.Parameters[(EnumName) (ParameterListEnum) PLCamera.AcquisitionMode].SetValue(PLCamera.AcquisitionMode.Continuous);
    buCamera.BaslerCamera.BaslerCamera.camera.StreamGrabber.Start(GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);
    buCamera.BaslerCamera.BaslerCamera.cameraIsOpen = true;
  }

  public static void DestroyCamera()
  {
    try
    {
      if (buCamera.BaslerCamera.BaslerCamera.camera == null)
        return;
      buCamera.BaslerCamera.BaslerCamera.cameraIsOpen = false;
      buCamera.BaslerCamera.BaslerCamera.camera.StreamGrabber.Stop();
      buCamera.BaslerCamera.BaslerCamera.camera.Close();
      buCamera.BaslerCamera.BaslerCamera.camera.Dispose();
      buCamera.BaslerCamera.BaslerCamera.camera = (Camera) null;
      buCamera.BaslerCamera.BaslerCamera.CameraSucces = false;
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("An error occured: " + ex?.ToString());
    }
  }

  public delegate void CameraImage(Bitmap bmp);
}
