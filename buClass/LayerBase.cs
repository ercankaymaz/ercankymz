// Decompiled with JetBrains decompiler
// Type: buClass.LayerBase
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
public class LayerBase : buSerilization
{
  public bool Enable = true;
  public bool Lock = false;
  public bool RealDrawMode = false;
  public string Name = "Layer";
  public string MaterialName = "";
  public string Tag = "";
  public string Option = "";
  public string Note = "";
  public string ShownName = "";
  public int Mode = 0;
  public Color LayerColor = Color.Black;
  public int Transparency = (int) byte.MaxValue;
  public float LayerThickness = 1f;
  public drawingPattern Pattern = new drawingPattern();
  public LayerPurpose LayerPurposes = LayerPurpose.General;
  public ToolBase ToolSelected = new ToolBase();
  public LayerCam Cam = new LayerCam();
  public LayerTuftingProps Tufting = new LayerTuftingProps();
  public LayerDiemakerProps Diemaker = new LayerDiemakerProps();
  public LayerJewelProps Jewelary = new LayerJewelProps();
  public static List<string> Captions = new List<string>();

  public LayerBase()
  {
  }

  public LayerBase(string name) => this.Name = name;

  public LayerBase(LayerBase data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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
    if (data.ToolSelected != null)
      this.ToolSelected = new ToolBase(data.ToolSelected);
    if (data.Cam != null)
      this.Cam = new LayerCam(data.Cam);
    if (data.Tufting != null)
      this.Tufting = new LayerTuftingProps(data.Tufting);
    if (data.Diemaker != null)
      this.Diemaker = new LayerDiemakerProps(data.Diemaker);
    if (data.Jewelary == null)
      return;
    this.Jewelary = new LayerJewelProps(data.Jewelary);
  }

  public static void Copy(List<LayerBase> Base, ref List<LayerBase> Copied)
  {
    Copied.Clear();
    Copied = new List<LayerBase>();
    for (int index = 0; index <= Base.Count - 1; ++index)
      Copied.Add(new LayerBase(Base[index]));
  }

  public override string ToString()
  {
    return $"{this.Name} , Enable = {this.Enable.ToString()} , Color : {this.LayerColor.ToString()} , Thickness : {this.LayerThickness.ToString()}";
  }
}
