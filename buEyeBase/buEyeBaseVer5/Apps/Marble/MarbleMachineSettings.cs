// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.MarbleMachineSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleMachineSettings : buSerilization5
{
  public bool isDrill;
  public bool isRough;
  public bool isFinish;
  public new bool Visible;
  public Color colorItem;
  public int Transparency;
  public int CamID;
  public int ItemID;
  public int ID;
  public int indexInside;
  public int indexOpen;

  public MarbleMachineSettings(ClamperLeftRightPars data)
  {
    ((MarbleRuntimeSettings) this).LeftMinDis = 0.0;
    ((MarbleRuntimeSettings) this).LeftMaxDis = 0.0;
    ((MarbleRuntimeSettings) this).LeftMinClamperPos = 0.0;
    ((MarbleRuntimeSettings) this).LeftMaxClamperPos = 0.0;
    ((MarbleRuntimeSettings) this).RightMinDis = 0.0;
    ((MarbleRuntimeSettings) this).RightMaxDis = 0.0;
    ((MarbleRuntimeSettings) this).RightMinClamperPos = 0.0;
    ((MarbleRuntimeSettings) this).RightMaxClamperPos = 0.0;
    ((MarbleRuntimeSettings) this).OperationAboveClamper = false;
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

  public override string ToString()
  {
    return $"LeftClpPos(Min - Max): {((MarbleRuntimeSettings) this).LeftMinClamperPos.ToString()} , {((MarbleRuntimeSettings) this).LeftMaxClamperPos.ToString()} - RightClpPos(Min - Max): {((MarbleRuntimeSettings) this).RightMinClamperPos.ToString()} , {((MarbleRuntimeSettings) this).RightMaxClamperPos.ToString()} - LeftMinDis: {((MarbleRuntimeSettings) this).LeftMinDis.ToString()} - RightMinDis: {((MarbleRuntimeSettings) this).RightMinDis.ToString()} - LeftMaxDis: {((MarbleRuntimeSettings) this).LeftMaxDis.ToString()} - RightMaxDis: {((MarbleRuntimeSettings) this).RightMaxDis.ToString()}";
  }

  public abstract void m001EA7();

  public MarbleMachineSettings()
  {
    ((MarbleRuntimeSettings) this).SmallChangeGap = 50.0;
    ((MarbleRuntimeSettings) this).BigChangeGap = 300.0;
    ((MarbleRuntimeSettings) this).LeftDistance = 0.0;
    ((MarbleRuntimeSettings) this).RightDistance = 0.0;
    ((MarbleRuntimeSettings) this).UseBig = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public MarbleMachineSettings(ProfileExistingClamperCompare data)
  {
    ((MarbleRuntimeSettings) this).SmallChangeGap = 50.0;
    ((MarbleRuntimeSettings) this).BigChangeGap = 300.0;
    ((MarbleRuntimeSettings) this).LeftDistance = 0.0;
    ((MarbleRuntimeSettings) this).RightDistance = 0.0;
    ((MarbleRuntimeSettings) this).UseBig = false;
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
}
