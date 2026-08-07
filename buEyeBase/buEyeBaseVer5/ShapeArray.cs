// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ShapeArray
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class ShapeArray : buSerilization5
{
  public Point3D FirstPoint;
  public Point3D LastPoint;
  public SortingResultType ResultType;
  public SortbuFilter Filter;
  public SortbuOptions Option;
  public SortbuCamData CamData;
  public MostClosestPointOption ClosestPoint;
  public List<buEntity> NotSelectEntities;

  public ShapeArray(bool Visible)
  {
    ((MaterialBase5) this).BottomColor = Color.DarkGray;
    ((MaterialBase5) this).IntermediateColor = Color.White;
    ((MaterialBase5) this).TopColor = Color.SlateGray;
    ((MaterialBase5) this).DisplayType = displayType.Rendered;
    ((MaterialBase5) this).ProjectionType = projectionType.Orthographic;
    ((MaterialBase5) this).OriginSymbol = originSymbolStyleType.Ball;
    ((MaterialBase5) this).PanMouseButton = new MouseButton(MouseButtons.Middle, devDept.Eyeshot.Control.modifierKeys.None);
    ((MaterialBase5) this).RotateMouseButton = new MouseButton(MouseButtons.Middle, devDept.Eyeshot.Control.modifierKeys.Ctrl);
    ((MaterialBase5) this).ZoomMouseButton = new MouseButton(MouseButtons.Middle, devDept.Eyeshot.Control.modifierKeys.Shift);
    ((MaterialBase5) this).ShowGrid = false;
    ((MaterialBase5) this).ShowOrigin = true;
    ((MaterialBase5) this).ShowOriginCaption = false;
    ((MaterialBase5) this).ShowCoordinateArrow = true;
    ((DiameterDepthPoint) this).ShowViewCube = true;
    ((DiameterDepthPoint) this).ShowToolBar = true;
    ((DiameterDepthPoint) this).ReverseMouseWheel = false;
    ((ShapeCreateParameters) this).OrigineSize = 2;
    ((ShapeCreateParameters) this).OriginString = "";
    ((ShapeCreateParameters) this).Width = 0;
    ((ShapeCreateParameters) this).Height = 0;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((MaterialBase5) this).ShowCoordinateArrow = Visible;
    ((MaterialBase5) this).ShowGrid = Visible;
    ((MaterialBase5) this).ShowOrigin = Visible;
    ((MaterialBase5) this).ShowOriginCaption = Visible;
    ((DiameterDepthPoint) this).ShowToolBar = Visible;
    ((DiameterDepthPoint) this).ShowViewCube = Visible;
  }

  public ShapeArray(EyeCreateProps data)
  {
    ((MaterialBase5) this).BottomColor = Color.DarkGray;
    ((MaterialBase5) this).IntermediateColor = Color.White;
    ((MaterialBase5) this).TopColor = Color.SlateGray;
    ((MaterialBase5) this).DisplayType = displayType.Rendered;
    ((MaterialBase5) this).ProjectionType = projectionType.Orthographic;
    ((MaterialBase5) this).OriginSymbol = originSymbolStyleType.Ball;
    ((MaterialBase5) this).PanMouseButton = new MouseButton(MouseButtons.Middle, devDept.Eyeshot.Control.modifierKeys.None);
    ((MaterialBase5) this).RotateMouseButton = new MouseButton(MouseButtons.Middle, devDept.Eyeshot.Control.modifierKeys.Ctrl);
    ((MaterialBase5) this).ZoomMouseButton = new MouseButton(MouseButtons.Middle, devDept.Eyeshot.Control.modifierKeys.Shift);
    ((MaterialBase5) this).ShowGrid = false;
    ((MaterialBase5) this).ShowOrigin = true;
    ((MaterialBase5) this).ShowOriginCaption = false;
    ((MaterialBase5) this).ShowCoordinateArrow = true;
    ((DiameterDepthPoint) this).ShowViewCube = true;
    ((DiameterDepthPoint) this).ShowToolBar = true;
    ((DiameterDepthPoint) this).ReverseMouseWheel = false;
    ((ShapeCreateParameters) this).OrigineSize = 2;
    ((ShapeCreateParameters) this).OriginString = "";
    ((ShapeCreateParameters) this).Width = 0;
    ((ShapeCreateParameters) this).Height = 0;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
    if (this.GetType() == CopiedClass.GetType())
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
    ((MaterialBase5) this).PanMouseButton = new MouseButton(((MaterialBase5) data).PanMouseButton.Button, ((MaterialBase5) data).PanMouseButton.ModifierKey);
    ((MaterialBase5) this).RotateMouseButton = new MouseButton(((MaterialBase5) data).RotateMouseButton.Button, ((MaterialBase5) data).RotateMouseButton.ModifierKey);
    ((MaterialBase5) this).ZoomMouseButton = new MouseButton(((MaterialBase5) data).ZoomMouseButton.Button, ((MaterialBase5) data).ZoomMouseButton.ModifierKey);
  }

  public abstract void m0002C4();
}
