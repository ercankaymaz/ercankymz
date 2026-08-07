// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileOperationDataCut
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileOperationDataCut : buSerilization5
{
  public double ApproxExecution8TimeSec;
  public double ApproxExecution9TimeSec;
  public int MaterialID;
  public string Name;
  public double UsingPersentage;
  public double UsingPersentageFromMaxX;

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern void EndInvoke(IAsyncResult result);

  public override string ToString()
  {
    return "IndexResult : " + ((ProfileTempVars) this).IndexResult.ToString();
  }

  public ProfileOperationDataCut()
  {
    ((ProfileTempVars) this).SendToDraw = nestResultSendType.Job;
    ((ProfileTempVars) this).IndexResult = -1;
    ((ProfileTempVars) this).IndexSheet = -1;
    ((ProfileTempVars) this).IndexPart = -1;
    ((ProfileTempVars) this).NestResult = (buNestedResult) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public abstract void m001D2A();

  public override string ToString() => "Mode : " + ((ProfileTempVars) this).Mode.ToString();

  public ProfileOperationDataCut()
  {
    // ISSUE: unable to decompile the method.
  }
}
