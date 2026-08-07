// Decompiled with JetBrains decompiler
// Type: buCamera.WebcamHandler.WebcamHandler
// Assembly: buCamera, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 458B46D1-65F2-4D88-8223-244FCE315356
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\Camera\Canon\buCamera.dll

using Accord.Video;
using Accord.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buCamera.WebcamHandler;

public class WebcamHandler
{
  private readonly object cameraLock = new object();
  public FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
  public VideoCaptureDevice videoSource;
  public Dictionary<int, string> webcamMonikerStrings = new Dictionary<int, string>();
  public static readonly object camBmpLock = new object();
  private string imgPath;
  public static Bitmap camBmp = (Bitmap) null;

  public WebcamHandler(string path) => this.imgPath = path;

  public void SelectWebcam(int index)
  {
    if (this.webcamMonikerStrings.ContainsKey(index))
    {
      this.videoSource = new VideoCaptureDevice(this.webcamMonikerStrings[index]);
    }
    else
    {
      int num = (int) MessageBox.Show("Webcam not found or invalid selection.");
    }
  }

  public void StartCamera()
  {
    lock (this.cameraLock)
    {
      if (this.videoDevices.Count == 0)
      {
        int num1 = (int) MessageBox.Show("No video devices found.");
      }
      else
      {
        foreach (VideoCapabilities videoCapability in this.videoSource.VideoCapabilities)
        {
          Size frameSize = videoCapability.FrameSize;
          int num2;
          if (frameSize.Width == 1920)
          {
            frameSize = videoCapability.FrameSize;
            if (frameSize.Height == 1080)
            {
              num2 = videoCapability.AverageFrameRate == 30 ? 1 : 0;
              goto label_8;
            }
          }
          num2 = 0;
label_8:
          if (num2 != 0)
          {
            this.videoSource.VideoResolution = videoCapability;
            break;
          }
        }
        this.videoSource.NewFrame += new NewFrameEventHandler(this.videoSource_NewFrame);
        this.videoSource.Start();
      }
    }
  }

  public void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
  {
    try
    {
      GC.Collect();
      ((Image) eventArgs.Frame.Clone())?.Save(this.imgPath);
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error on getting the frame: " + ex.Message);
    }
  }

  public void StopWebcam()
  {
    lock (this.cameraLock)
    {
      if (this.videoSource == null || !this.videoSource.IsRunning)
        return;
      this.videoSource.SignalToStop();
      this.videoSource.Stop();
      this.videoSource.NewFrame -= new NewFrameEventHandler(this.videoSource_NewFrame);
    }
  }
}
