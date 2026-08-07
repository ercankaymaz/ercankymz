// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.MarbleModes
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using System.Reflection;

#nullable disable
namespace buCadCamResVer5;

public class MarbleModes
{
  public bool Enable = false;
  public bool Countertop = false;
  public bool Profile = false;
  public bool ProfileArc = false;
  public bool Engraving3Axis = false;
  public bool Engraving5Axis = false;
  public bool Lathe = false;
  public bool SawMilling = false;
  public bool FileImport = false;
  public bool Camera = false;
  public bool Vacuum = false;
  public bool GCodeImport = false;
  public bool Library = false;
  public bool Columns = false;
  public bool ToolMeasure = false;
  public bool Sweep = false;
  public bool Text = false;
  public bool Hole = false;
  public bool OPMenu = false;
  public double Mode1 = 0.0;
  public double Mode2 = 0.0;
  public string Mode3 = "";
  public string Mode4 = "";
  public string Mode1Exp = "";
  public string Mode2Exp = "";
  public string Mode3Exp = "";
  public string Mode4Exp = "";

  public MarbleModes()
  {
  }

  public MarbleModes(MarbleModes data)
  {
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
}
