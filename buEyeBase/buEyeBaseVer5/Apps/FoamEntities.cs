// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.FoamEntities
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class FoamEntities : buSerilization5
{
  public string FileNameFull;

  public FoamEntities()
  {
    ((FoamPattern) this).TopBottomCylinderDistance = 19.5;
    ((FoamPattern) this).LeftCylinderAngle = 20.0;
    ((FoamPattern) this).RightCylinderAngle = 20.0;
    ((FoamPattern) this).LeftCylinderDiameter = 140.0;
    ((FoamPattern) this).RightCylinderDiameter = 140.0;
    ((FoamPattern) this).UpCylinderDiameter = 160.0;
    ((FoamPattern) this).DownCylinderDiameter = 160.0;
    ((FoamPattern) this).LeftCylinderXOffset = -178.0;
    ((FoamPattern) this).LeftCylinderZOffset = 10.0;
    ((FoamPattern) this).RightCylinderXOffset = 178.0;
    ((FoamPattern) this).RightCylinderZOffset = 10.0;
    ((FoamPattern) this).SimulationIntervalMs = 40;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public FoamEntities(RollerBendSettings data)
  {
    ((FoamPattern) this).TopBottomCylinderDistance = 19.5;
    ((FoamPattern) this).LeftCylinderAngle = 20.0;
    ((FoamPattern) this).RightCylinderAngle = 20.0;
    ((FoamPattern) this).LeftCylinderDiameter = 140.0;
    ((FoamPattern) this).RightCylinderDiameter = 140.0;
    ((FoamPattern) this).UpCylinderDiameter = 160.0;
    ((FoamPattern) this).DownCylinderDiameter = 160.0;
    ((FoamPattern) this).LeftCylinderXOffset = -178.0;
    ((FoamPattern) this).LeftCylinderZOffset = 10.0;
    ((FoamPattern) this).RightCylinderXOffset = 178.0;
    ((FoamPattern) this).RightCylinderZOffset = 10.0;
    ((FoamPattern) this).SimulationIntervalMs = 40;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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

  public FoamEntities()
  {
    if (!buVector5.\u0001("buRouter3AX"))
      throw new RegisterException("buRouter3AX");
  }
}
