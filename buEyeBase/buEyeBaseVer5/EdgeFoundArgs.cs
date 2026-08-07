// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.EdgeFoundArgs
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class EdgeFoundArgs : buSerilization5
{
  public string M;
  public string S;
  public string R;

  public EdgeFoundArgs(ColorDrawType data)
  {
    ((hmiUIDataGridView) this).Color = Color.DarkGray;
    ((hmiUIDataGridView) this).Transperancy = (int) byte.MaxValue;
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

  public EdgeFoundArgs(Color color, int transperancy, double thickness)
  {
    ((hmiUIDataGridView) this).Color = Color.DarkGray;
    ((hmiUIDataGridView) this).Transperancy = (int) byte.MaxValue;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((hmiUIDataGridView) this).Color = color;
    ((hmiUIDataGridView) this).Transperancy = transperancy;
    ((hmiUIDataGridView) this).Thickess = thickness;
  }
}
