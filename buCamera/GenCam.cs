// Decompiled with JetBrains decompiler
// Type: buCamera.GenCam.GenCam
// Assembly: buCamera, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 458B46D1-65F2-4D88-8223-244FCE315356
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\Camera\Canon\buCamera.dll

using MvCameraControl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buCamera.GenCam;

public class GenCam
{
  private List<IDeviceInfo> deviceInfoList = new List<IDeviceInfo>();
  private readonly DeviceTLayerType enumTLayerType = DeviceTLayerType.MvGigEDevice | DeviceTLayerType.MvUsbDevice | DeviceTLayerType.MvGenTLGigEDevice | DeviceTLayerType.MvGenTLCameraLinkDevice | DeviceTLayerType.MvGenTLCXPDevice | DeviceTLayerType.MvGenTLXoFDevice;
  private IDevice device = (IDevice) null;
  private bool isGrabbing = false;
  private bool isRecord = false;
  private Thread receiveThread = (Thread) null;
  private readonly object saveImageLock = new object();
  private IFrameOut frameOutLocal;
  public static string imgFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");

  private void RefreshDeviceList()
  {
    int errorCode = DeviceEnumerator.EnumDevices(this.enumTLayerType, out this.deviceInfoList);
    if (errorCode == 0)
      return;
    this.ShowErrorMsg("Enumerate devices fail!", errorCode);
  }

  private async void OpenGenCam(PictureBox pbox)
  {
    IDeviceInfo deviceInfo;
    if (this.deviceInfoList.Count == 0)
    {
      this.ShowErrorMsg("No device detected", 0);
      deviceInfo = (IDeviceInfo) null;
    }
    else
    {
      deviceInfo = this.deviceInfoList[0];
      try
      {
        this.device = DeviceFactory.CreateDevice(deviceInfo);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Create Device fail!" + ex.Message);
        deviceInfo = (IDeviceInfo) null;
        return;
      }
      int result = this.device.Open();
      if (result != 0)
      {
        this.ShowErrorMsg("Open Device fail!", result);
        deviceInfo = (IDeviceInfo) null;
      }
      else
      {
        if (this.device is IGigEDevice)
        {
          IGigEDevice gigEDevice = this.device as IGigEDevice;
          int optionPacketSize;
          result = gigEDevice.GetOptimalPacketSize(out optionPacketSize);
          if (result != 0)
          {
            this.ShowErrorMsg("Warning: Get Packet Size failed!", result);
          }
          else
          {
            result = this.device.Parameters.SetIntValue("GevSCPSPacketSize", (long) optionPacketSize);
            if (result != 0)
              this.ShowErrorMsg("Warning: Set Packet Size failed!", result);
          }
          gigEDevice = (IGigEDevice) null;
        }
        this.device.Parameters.SetEnumValueByString("AcquisitionMode", "Continuous");
        this.device.Parameters.SetEnumValueByString("TriggerMode", "Off");
        this.GetCamParam();
        this.device.Parameters.SetEnumValueByString("TriggerMode", "On");
        this.device.Parameters.SetEnumValueByString("TriggerSource", "Software");
        this.StartGrabCam(pbox);
        deviceInfo = (IDeviceInfo) null;
      }
    }
  }

  private void GetCamParam()
  {
    this.GetTriggerMode();
    IFloatValue floatValue;
    if (this.device.Parameters.GetFloatValue("ExposureTime", out floatValue) != 0)
      ;
    if (this.device.Parameters.GetFloatValue("Gain", out floatValue) != 0)
      ;
    if (this.device.Parameters.GetFloatValue("ResultingFrameRate", out floatValue) != 0)
      ;
    IEnumValue enumValue;
    if (this.device.Parameters.GetEnumValue("PixelFormat", out enumValue) != 0)
      return;
    foreach (IEnumEntry supportEnumEntry in enumValue.SupportEnumEntries)
      ;
  }

  private void GetTriggerMode()
  {
    IEnumValue enumValue;
    if (this.device.Parameters.GetEnumValue("TriggerMode", out enumValue) != 0 || !(enumValue.CurEnumEntry.Symbolic == "On") || this.device.Parameters.GetEnumValue("TriggerSource", out enumValue) != 0 || !(enumValue.CurEnumEntry.Symbolic == "TriggerSoftware"))
      ;
  }

  public void ReceiveThreadProcess(PictureBox pbox)
  {
    while (this.isGrabbing)
    {
      if (this.device.StreamGrabber.GetImageBuffer(1000U, out this.frameOutLocal) == 0)
      {
        try
        {
          this.device.ImageRender.DisplayOneFrame(pbox.Handle, this.frameOutLocal.Image);
          lock (this.saveImageLock)
          {
            try
            {
              int errorCode = this.SaveImage(new ImageFormatInfo()
              {
                FormatType = ImageFormatType.Png
              }, Path.Combine(buCamera.GenCam.GenCam.imgFile, "Original.png"));
              if (errorCode != 0)
              {
                this.ShowErrorMsg("Save Image Fail!", errorCode);
                break;
              }
            }
            catch (Exception ex)
            {
              int num = (int) MessageBox.Show("Save Image Failed, " + ex.Message);
              break;
            }
          }
        }
        finally
        {
          this.device.StreamGrabber.FreeImageBuffer(this.frameOutLocal);
        }
      }
      else
        Thread.Sleep(5);
    }
  }

  private int SaveImage(ImageFormatInfo imageFormatInfo, string imagePath)
  {
    if (this.frameOutLocal == null)
      throw new Exception("No vaild image");
    lock (this.saveImageLock)
      return this.device.ImageSaver.SaveImageToFile(imagePath, this.frameOutLocal.Image, imageFormatInfo, CFAMethod.Equilibrated);
  }

  private void StartGrabCam(PictureBox pbox)
  {
    try
    {
      this.isGrabbing = true;
      this.receiveThread = new Thread((ThreadStart) (() => this.ReceiveThreadProcess(pbox)));
      this.receiveThread.Start();
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Start thread failed!, " + ex.Message);
      throw;
    }
    int errorCode = this.device.StreamGrabber.StartGrabbing();
    if (errorCode == 0)
      return;
    this.isGrabbing = false;
    this.receiveThread.Join();
    this.ShowErrorMsg("Start Grabbing Fail!", errorCode);
  }

  private void StopGrabCam()
  {
    this.isGrabbing = false;
    this.receiveThread.Join();
    int errorCode = this.device.StreamGrabber.StopGrabbing();
    if (errorCode == 0)
      return;
    this.ShowErrorMsg("Stop Grabbing Fail!", errorCode);
  }

  private void CloseGenCam()
  {
    if (this.isGrabbing)
      this.StopGrabCam();
    if (this.device == null)
      return;
    this.device.Close();
  }

  private void VideoMode()
  {
    this.device.Parameters.SetEnumValueByString("AcquisitionMode", "Continuous");
    this.device.Parameters.SetEnumValueByString("TriggerMode", "Off");
    int errorCode = this.device.Parameters.SetFloatValue("AcquisitionFrameRate", 30f);
    if (errorCode == 0)
      return;
    this.ShowErrorMsg("Set Frame Rate Fail!", errorCode);
  }

  private void ShowErrorMsg(string message, int errorCode)
  {
    string text = errorCode != 0 ? $"{message}: Error ={$"{errorCode:X}"}" : message;
    switch (errorCode)
    {
      case int.MinValue:
        text += " Error or invalid handle ";
        break;
      case -2147483647 /*0x80000001*/:
        text += " Not supported function ";
        break;
      case -2147483646 /*0x80000002*/:
        text += " Cache is full ";
        break;
      case -2147483645 /*0x80000003*/:
        text += " Function calling order error ";
        break;
      case -2147483644 /*0x80000004*/:
        text += " Incorrect parameter ";
        break;
      case -2147483642 /*0x80000006*/:
        text += " Applying resource failed ";
        break;
      case -2147483641 /*0x80000007*/:
        text += " No data ";
        break;
      case -2147483640 /*0x80000008*/:
        text += " Precondition error, or running environment changed ";
        break;
      case -2147483639 /*0x80000009*/:
        text += " Version mismatches ";
        break;
      case -2147483638 /*0x8000000A*/:
        text += " Insufficient memory ";
        break;
      case -2147483393 /*0x800000FF*/:
        text += " Unknown error ";
        break;
      case -2147483392 /*0x80000100*/:
        text += " General error ";
        break;
      case -2147483386 /*0x80000106*/:
        text += " Node accessing condition error ";
        break;
      case -2147483133 /*0x80000203*/:
        text += " No permission ";
        break;
      case -2147483132 /*0x80000204*/:
        text += " Device is busy, or network disconnected ";
        break;
      case -2147483130 /*0x80000206*/:
        text += " Network error ";
        break;
    }
    int num = (int) MessageBox.Show(text, "PROMPT");
  }
}
