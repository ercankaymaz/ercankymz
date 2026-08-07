// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.EditorCustomData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class EditorCustomData
{
  public double PolylineLength;
  public double CircleLength;

  public EditorCustomData(string name)
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
    ((DevideEventFormVars) this).Name = name;
  }

  public EditorCustomData(string name, Color color, float thickness, int transparency)
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
    ((DevideEventFormVars) this).Name = name;
    if (transparency > 0 & transparency <= (int) byte.MaxValue)
      ((DevideEventFormVars) this).LayerColor = Color.FromArgb(transparency, color);
    else
      ((DevideEventFormVars) this).LayerColor = Color.FromArgb((int) byte.MaxValue, color);
    ((DevideEventFormVars) this).LayerThickness = thickness;
  }

  public EditorCustomData(LayerBase5 data)
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
    if (((DevideEventFormVars) data).Pattern != null)
      ((DevideEventFormVars) this).Pattern = new drawingPattern(((DevideEventFormVars) data).Pattern);
    if (((DeleteTypeEventFormVars) data).ToolSelected != null)
      ((DeleteTypeEventFormVars) this).ToolSelected = (ToolBase5) new ToolGeometry5(((DeleteTypeEventFormVars) data).ToolSelected);
    if (((DeleteTypeEventFormVars) data).Cam != null)
      ((DeleteTypeEventFormVars) this).Cam = new LayerCam(((DeleteTypeEventFormVars) data).Cam);
    if (((DeleteTypeEventFormVars) data).Tufting != null)
      ((DeleteTypeEventFormVars) this).Tufting = new LayerTuftingProps(((DeleteTypeEventFormVars) data).Tufting);
    if (((DeleteTypeEventFormVars) data).Diemaker != null)
      ((DeleteTypeEventFormVars) this).Diemaker = new LayerDiemakerProps(((DeleteTypeEventFormVars) data).Diemaker);
    if (((DeleteTypeEventFormVars) data).Jewelary != null)
      ((DeleteTypeEventFormVars) this).Jewelary = new LayerJewelProps(((DeleteTypeEventFormVars) data).Jewelary);
    if (((DeleteTypeEventFormVars) data).Router3AX == null)
      return;
    ((DeleteTypeEventFormVars) this).Router3AX = new LayerRouter3XProps(((DeleteTypeEventFormVars) data).Router3AX);
  }
}
