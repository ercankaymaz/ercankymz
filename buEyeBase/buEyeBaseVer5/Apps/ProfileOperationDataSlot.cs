// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileOperationDataSlot
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Reflection;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileOperationDataSlot : buSerilization5
{
  public double ApproxExecution3TimeSec;
  public double ApproxExecution4TimeSec;
  public double ApproxExecution5TimeSec;
  public double ApproxExecution6TimeSec;
  public double ApproxExecution7TimeSec;

  public ProfileOperationDataSlot()
  {
    ((ProfileTempVars) this).layerSheet = "Panel";
    ((ProfileTempVars) this).layerPart = "Operation";
    ((ProfileTempVars) this).layerWireframe = "General";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public ProfileOperationDataSlot(buNestingTempVars data)
  {
    ((ProfileTempVars) this).layerSheet = "Panel";
    ((ProfileTempVars) this).layerPart = "Operation";
    ((ProfileTempVars) this).layerWireframe = "General";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public abstract void m001D23();

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public extern ProfileOperationDataSlot(object @object, IntPtr method);

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern void Invoke(buNestedResultEventArg NestResult);

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern IAsyncResult BeginInvoke(
    buNestedResultEventArg NestResult,
    AsyncCallback callback,
    object @object);
}
