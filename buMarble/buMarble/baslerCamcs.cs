// Decompiled with JetBrains decompiler
// Type: buMarble.baslerCamcs
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using Basler.Pylon;
using buEyeBaseVer5.Apps.Marble;
using buMarble.Forms;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace buMarble;

public class baslerCamcs
{
  private string \u0002;
  public static byte f0002E3;
  public static readonly clsAppMarble.\u003C\u003Ec \u003C\u003E9 = (clsAppMarble.\u003C\u003Ec) new baslerCamcs();
  public static Action \u003C\u003E9__89_0;
  public static Action \u003C\u003E9__90_0;
  public static Action \u003C\u003E9__91_0;

  internal void \u0001()
  {
    buLogMarbleVer5.addToUserLog("DebugCreateCodesysDefault", "Created", "", "", "", "", 0);
  }

  internal void \u0002()
  {
    buLogMarbleVer5.addToUserLog("DebugCreateDefaultIOFile", "Created", "", "", "", "", 0);
  }

  internal void \u0003()
  {
    buLogMarbleVer5.addToUserLog("DebugCreateDefaultIOFile", "Created", "", "", "", "", 0);
  }

  internal void \u0004()
  {
    buLogMarbleVer5.addToUserLog("DebugGetLastBackUpFiles", "Backup", "", "", "", "", 0);
  }

  public event baslerCamcs.CameraImage CameraImageEvent;

  public void CameraInit()
  {
    ((F_MarbleVideoPlayer) this).\u0001 = new Camera();
    ((F_MarbleVideoPlayer) this).\u0001.CameraOpened += new EventHandler<EventArgs>(Configuration.AcquireContinuous);
    ((F_MarbleVideoPlayer) this).\u0001.ConnectionLost += new EventHandler<EventArgs>(this.\u0002);
    ((F_MarbleVideoPlayer) this).\u0001.StreamGrabber.GrabStarted += new EventHandler<EventArgs>(this.\u0001);
    ((F_MarbleVideoPlayer) this).\u0001.StreamGrabber.ImageGrabbed += new EventHandler<ImageGrabbedEventArgs>(this.\u0001);
    ((F_MarbleVideoPlayer) this).\u0001.StreamGrabber.GrabStopped += new EventHandler<GrabStopEventArgs>(this.\u0001);
    ((F_MarbleVideoPlayer) this).\u0001.Open();
  }

  private void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleVideoPlayer) this).\u0001 = true;
  }

  private void \u0001([In] object obj0, [In] ImageGrabbedEventArgs obj1)
  {
    IGrabResult grabResult = obj1.GrabResult;
    if (!grabResult.IsValid || !((F_MarbleVideoPlayer) this).\u0001)
      return;
    // ISSUE: reference to a compiler-generated field
    ((F_MarbleVideoPlayer) ((F_MarbleVideoPlayer) this).\u0001).Invoke(\u0005.\u0003.\u0001(grabResult, this));
  }

  private void \u0001([In] object obj0, [In] GrabStopEventArgs obj1)
  {
    ((F_MarbleVideoPlayer) this).\u0001 = false;
  }

  private void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleVideoPlayer) this).\u0001.StreamGrabber.Stop();
    ((F_MarbleVideoPlayer) this).DestroyCamera();
  }

  public void SetExposureTime(int Val)
  {
    ((F_MarbleVideoPlayer) this).\u0001.Parameters[PLCamera.ExposureTimeAbs].SetValue((double) Val);
  }

  public void SetReverseX(bool Val)
  {
    ((F_MarbleVideoPlayer) this).\u0001.Parameters[PLCamera.ReverseX].SetValue(Val);
  }

  public delegate void CameraImage();
}
