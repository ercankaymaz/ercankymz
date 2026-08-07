// Decompiled with JetBrains decompiler
// Type: buCamera.DahnegCamera.DahengCamera
// Assembly: buCamera, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 458B46D1-65F2-4D88-8223-244FCE315356
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\Camera\Canon\buCamera.dll

using GxIAPINET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

#nullable disable
namespace buCamera.DahnegCamera;

public class DahengCamera
{
  public static volatile bool threadState;
  public static IGXFeatureControl m_remoteFeatureControl;

  public bool CaptureSingleFrame(string savePath)
  {
    IGXDevice igxDevice = (IGXDevice) null;
    IGXStream igxStream = (IGXStream) null;
    try
    {
      IGXFactory.GetInstance().Init();
      List<IGXDeviceInfo> listDeviceInfo = new List<IGXDeviceInfo>();
      IGXFactory.GetInstance().UpdateAllDeviceList(300U, listDeviceInfo);
      if (listDeviceInfo.Count < 1)
      {
        Console.WriteLine("No camera found.");
        return false;
      }
      string sn = listDeviceInfo[0].GetSN();
      igxDevice = IGXFactory.GetInstance().OpenDeviceBySN(sn, GX_ACCESS_MODE.GX_ACCESS_CONTROL);
      IGXFeatureControl remoteFeatureControl = igxDevice.GetRemoteFeatureControl();
      remoteFeatureControl.GetEnumFeature("UserSetSelector").SetValue("Default");
      remoteFeatureControl.GetCommandFeature("UserSetLoad").Execute();
      igxStream = igxDevice.OpenStream(0U);
      igxStream.StartGrab();
      remoteFeatureControl.GetCommandFeature("AcquisitionStart").Execute();
      IFrameData frameData = igxStream.DQBuf(1000U);
      if (frameData.GetStatus() != 0)
      {
        Console.WriteLine("Failed to capture frame.");
        return false;
      }
      int width = (int) frameData.GetWidth();
      int height = (int) frameData.GetHeight();
      IntPtr buffer = frameData.GetBuffer();
      GX_PIXEL_FORMAT_ENTRY pixelFormat = frameData.GetPixelFormat();
      PixelFormat format;
      switch (pixelFormat)
      {
        case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_MONO8:
          format = PixelFormat.Format8bppIndexed;
          break;
        case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_RGB8:
          format = PixelFormat.Format24bppRgb;
          break;
        default:
          Console.WriteLine($"Unsupported pixel format: {pixelFormat}");
          return false;
      }
      using (Bitmap bitmap = new Bitmap(width, height, format))
      {
        if (format == PixelFormat.Format8bppIndexed)
        {
          ColorPalette palette = bitmap.Palette;
          for (int index = 0; index < 256 /*0x0100*/; ++index)
            palette.Entries[index] = Color.FromArgb(index, index, index);
          bitmap.Palette = palette;
        }
        BitmapData bitmapdata = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, format);
        int stride = bitmapdata.Stride;
        IntPtr scan0 = bitmapdata.Scan0;
        int num = format == PixelFormat.Format24bppRgb ? 3 : 1;
        int length = width * num;
        for (int index = 0; index < height; ++index)
        {
          IntPtr source = buffer + index * length;
          IntPtr destination = scan0 + index * stride;
          byte[] numArray = new byte[length];
          Marshal.Copy(source, numArray, 0, length);
          Marshal.Copy(numArray, 0, destination, length);
        }
        bitmap.UnlockBits(bitmapdata);
        bitmap.Save(savePath, ImageFormat.Png);
      }
      igxStream.QBuf(frameData);
      remoteFeatureControl.GetCommandFeature("AcquisitionStop").Execute();
      igxStream.StopGrab();
      return true;
    }
    catch (CGalaxyException ex)
    {
      Console.WriteLine("GalaxyException: " + ex.Message);
      return false;
    }
    catch (Exception ex)
    {
      Console.WriteLine("Exception: " + ex.Message);
      return false;
    }
    finally
    {
      igxStream?.Close();
      igxDevice?.Close();
      IGXFactory.GetInstance().Uninit();
    }
  }
}
