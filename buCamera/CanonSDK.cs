// Decompiled with JetBrains decompiler
// Type: buCamera.Canoncamera.CanonSDK
// Assembly: buCamera, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 458B46D1-65F2-4D88-8223-244FCE315356
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\Camera\Canon\buCamera.dll

using EDSDKLib;
using System;

#nullable disable
namespace buCamera.Canoncamera;

public class CanonSDK
{
  private uint _sdkHandle;

  public CanonSDK()
  {
    this._sdkHandle = EDSDK.EdsInitializeSDK();
    if (this._sdkHandle > 0U)
      throw new Exception("Failed to initialize Canon SDK");
  }

  public void Terminate()
  {
    int num = (int) EDSDK.EdsTerminateSDK();
  }
}
