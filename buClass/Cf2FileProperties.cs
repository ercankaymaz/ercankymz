// Decompiled with JetBrains decompiler
// Type: buClass.Cf2FileProperties
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class Cf2FileProperties : buSerilization
{
  public double PtIndex = 0.0;
  public double PtRealValue = 0.0;
  public double Cf2CodeMatchType = 0.0;
  public DiemakerType CodeType = DiemakerType.None;
  public string Explanation = "";
  public bool Selectable = true;
  public bool Visible = true;
  public Color MatchColor = Color.Black;
  public Color Color = Color.Black;
  public Color SelectedColor = Color.Black;
  public double Thickness = 1.0;
  public double SelectedThickness = 1.0;
  public int LayerIndex = 0;
  public int ToolNo = 1;

  public Cf2FileProperties()
  {
  }

  public Cf2FileProperties(Cf2FileProperties data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
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

  public static void Copy(Cf2FileProperties Base, ref Cf2FileProperties Copied)
  {
    Copied = new Cf2FileProperties(Base);
  }

  public static void Copy(List<Cf2FileProperties> Base, ref List<Cf2FileProperties> Copied)
  {
    Copied.Clear();
    Copied = new List<Cf2FileProperties>();
    for (int index = 0; index <= Base.Count - 1; ++index)
      Copied.Add(new Cf2FileProperties(Base[index]));
  }

  public override string ToString()
  {
    return $"Pt Index: {this.PtIndex.ToString()} - Pt Real: {this.PtRealValue.ToString()} - Type: {this.CodeType.ToString()} - Color: {this.Color.ToString()}";
  }
}
