// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.SketchAnalyseData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class SketchAnalyseData : buSerilization5
{
  public double ArcLength;
  public double EllipseLength;

  public SketchAnalyseData(LayerBase data)
  {
    ((ScaleEventFormVars) this).Enable = true;
    ((ScaleEventFormVars) this).Lock = false;
    ((ScaleEventFormVars) this).RealDrawMode = false;
    ((DevideEventFormVars) this).Selectable = true;
    ((DevideEventFormVars) this).Name = "Layer";
    ((DevideEventFormVars) this).NameExtra = "";
    ((DevideEventFormVars) this).MaterialName = "";
    ((DevideEventFormVars) this).Tag = "";
    ((DevideEventFormVars) this).Option = "";
    ((DevideEventFormVars) this).Note = "";
    ((DevideEventFormVars) this).ShownName = "";
    ((DevideEventFormVars) this).Defination = "";
    ((DevideEventFormVars) this).Mode = 0;
    ((DevideEventFormVars) this).LayerColor = Color.Black;
    ((DevideEventFormVars) this).Transparency = (int) byte.MaxValue;
    ((DevideEventFormVars) this).LayerThickness = 1f;
    ((DevideEventFormVars) this).Pattern = (drawingPattern) null;
    ((DevideEventFormVars) this).LayerPurposes = LayerPurpose.General;
    ((DeleteTypeEventFormVars) this).ToolSelected = (ToolBase5) null;
    ((DeleteTypeEventFormVars) this).Cam = (LayerCam) null;
    ((DeleteTypeEventFormVars) this).Tufting = (LayerTuftingProps) null;
    ((DeleteTypeEventFormVars) this).Diemaker = (LayerDiemakerProps) null;
    ((DeleteTypeEventFormVars) this).Jewelary = (LayerJewelProps) null;
    ((DeleteTypeEventFormVars) this).Router3AX = (LayerRouter3XProps) null;
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
    if (data.ToolSelected != null)
      ((DeleteTypeEventFormVars) this).ToolSelected = (ToolBase5) new ToolGeometry5(data.ToolSelected);
    if (data.Cam != null)
      ((DeleteTypeEventFormVars) this).Cam = new LayerCam(data.Cam);
    if (data.Tufting != null)
      ((DeleteTypeEventFormVars) this).Tufting = new LayerTuftingProps(data.Tufting);
    if (data.Diemaker != null)
      ((DeleteTypeEventFormVars) this).Diemaker = new LayerDiemakerProps(data.Diemaker);
    if (data.Jewelary == null)
      return;
    ((DeleteTypeEventFormVars) this).Jewelary = new LayerJewelProps(data.Jewelary);
  }

  public static ArrayList ToDef(LayerBase5 Layer)
  {
    return new ArrayList()
    {
      (object) buSerilization5.ClassToString((object) Layer)
    };
  }

  public static void Decode(ArrayList AL, ref LayerBase5 Layer)
  {
    Layer = (LayerBase5) new EntityShapeInfo();
    if (AL.Count < 1)
      return;
    object ObjPar = (object) Layer;
    buSerilization5.StringToClass(ref ObjPar, AL[0].ToString());
  }
}
