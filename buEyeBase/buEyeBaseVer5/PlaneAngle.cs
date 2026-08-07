// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.PlaneAngle
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class PlaneAngle : buSerilization5
{
  public bool ForcePlaneXY;
  public static byte f000587;
  public KinematicBase5 Kinematic;

  public abstract void m000228();

  public PlaneAngle()
  {
    ((EntitiesCopySettings) this).FindProblems = true;
    ((EntitiesCopySettings) this).FixProblems = false;
    ((EntitiesCopySettings) this).isSameMoreThanOneCheck = true;
    ((EntitiesCopySettings) this).isEntityLengthSmall = true;
    ((EntitiesCopySettings) this).isSmallGap = false;
    ((EntitiesCopySettings) this).isClosedEntities = false;
    ((EntitiesCopySettings) this).IntersectionEntities = false;
    ((EntitiesCopySettings) this).SmallGapMinDistance = 0.001;
    ((EntitiesCopySettings) this).SmallGapMaxDistance = 0.05;
    ((EntitiesCopySettings) this).EntityLengthLimit = 0.01;
    ((EntitiesCopySettings) this).IntersectionGap = 0.1;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public PlaneAngle(AnalyseEntitiesSetting data)
  {
    ((EntitiesCopySettings) this).FindProblems = true;
    ((EntitiesCopySettings) this).FixProblems = false;
    ((EntitiesCopySettings) this).isSameMoreThanOneCheck = true;
    ((EntitiesCopySettings) this).isEntityLengthSmall = true;
    ((EntitiesCopySettings) this).isSmallGap = false;
    ((EntitiesCopySettings) this).isClosedEntities = false;
    ((EntitiesCopySettings) this).IntersectionEntities = false;
    ((EntitiesCopySettings) this).SmallGapMinDistance = 0.001;
    ((EntitiesCopySettings) this).SmallGapMaxDistance = 0.05;
    ((EntitiesCopySettings) this).EntityLengthLimit = 0.01;
    ((EntitiesCopySettings) this).IntersectionGap = 0.1;
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
