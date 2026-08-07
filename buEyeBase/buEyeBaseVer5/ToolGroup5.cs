// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ToolGroup5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class ToolGroup5 : buSerilization5
{
  public bool LeadOutEntitiesEnable;
  public bool MarkEntitiesEnable;

  public ToolGroup5(camLengthFeed data)
  {
    ((ToolBase5) this).MinLength = 0.0;
    ((ToolBase5) this).MaxLength = 0.0;
    ((ToolBase5) this).Feed = 0.0;
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
    return $"Min Len: {((ToolBase5) this).MinLength.ToString("f2")}Max Len: {((ToolBase5) this).MaxLength.ToString("f2")} - Feed: {((ToolBase5) this).Feed.ToString("f2")}";
  }
}
