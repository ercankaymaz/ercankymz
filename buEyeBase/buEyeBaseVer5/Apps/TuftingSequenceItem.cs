// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.TuftingSequenceItem
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class TuftingSequenceItem : buSerilization
{
  public double ClamperCatchWidth;
  public double ClamperSlotCatchWidth;
  public double ClamperCatchWidthForBottom;

  public TuftingSequenceItem(FoamEntities data)
  {
    ((DrillItem) this).GroupEntity = new buEntitiesGroup();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
    {
      FieldInfo[] fields = this.GetType().GetFields();
      if (fields != null)
      {
        for (int index = 0; index <= fields.Length - 1; ++index)
        {
          string name = fields[index].Name;
          object obj = fields[index].GetValue(CopiedClass);
          fields[index].SetValue((object) this, obj);
        }
      }
    }
    ((DrillItem) this).GroupEntity = new buEntitiesGroup(((DrillItem) data).GroupEntity);
  }

  public static void Copy(List<FoamEntities> refEntities, ref List<FoamEntities> copyEntities)
  {
    copyEntities = new List<FoamEntities>();
    for (int index = 0; index <= refEntities.Count - 1; ++index)
      copyEntities.Add((FoamEntities) new TuftingSequenceItem(refEntities[index]));
  }
}
