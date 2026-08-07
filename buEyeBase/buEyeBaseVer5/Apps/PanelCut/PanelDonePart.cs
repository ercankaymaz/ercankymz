// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.PanelCut.PanelDonePart
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.PanelCut;

[Serializable]
public class PanelDonePart : buSerilization5
{
  public static byte f004536;
  public double CutWidth;
  public double CutHeigth;
  public double CutDepth;

  public PanelDonePart()
  {
    ((ProfileSettings) this).Name = "Job";
    ((ProfileSettings) this).Items = new List<ProfileItem>();
    ((ProfileSettings) this).Station = 0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public PanelDonePart(ProfileJob data)
  {
    ((ProfileSettings) this).Name = "Job";
    ((ProfileSettings) this).Items = new List<ProfileItem>();
    ((ProfileSettings) this).Station = 0;
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
    for (int index = 0; index <= ((ProfileSettings) data).Items.Count - 1; ++index)
      ((ProfileSettings) this).Items.Add((ProfileItem) new PanelCutRuntimeSettings(((ProfileSettings) data).Items[index]));
  }
}
