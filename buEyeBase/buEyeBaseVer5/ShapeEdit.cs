// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ShapeEdit
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Geometry;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5;

public class ShapeEdit : buSerilization5
{
  public int PreviousSelectedIndex;
  public int FoundCount;
  public Point3D CatchPoint;
  public Point3D PreCatchPoint;
  public Point3D IntersectionPoint;

  public abstract void m0002BD();

  public ShapeEdit()
  {
    ((ViewportDrawOptions) this).BottomColor = Color.DarkGray;
    ((ViewportDrawOptions) this).MiddleColor = Color.White;
    ((ViewportDrawOptions) this).TopColor = Color.White;
    ((ViewportDrawOptions) this).DisplayType = displayType.Rendered;
    ((MaterialBase5) this).ProjetionType = projectionType.Perspective;
    ((MaterialBase5) this).OrigineSymbol = originSymbolStyleType.Ball;
    ((MaterialBase5) this).WaitCursorMode = waitCursorType.Never;
    ((MaterialBase5) this).Dock = DockStyle.Fill;
    ((MaterialBase5) this).ShowProgress = false;
    ((MaterialBase5) this).GridVisible = false;
    ((MaterialBase5) this).GridStepX = 10.0;
    ((MaterialBase5) this).GridStepY = 10.0;
    ((MaterialBase5) this).OriginSymbolVisible = false;
    ((MaterialBase5) this).OrigineCaptionVisible = false;
    ((MaterialBase5) this).OrigineSize = 12;
    ((MaterialBase5) this).ViewCubeIconVisible = true;
    ((MaterialBase5) this).ReverseMouseWheel = false;
    ((MaterialBase5) this).CoordinateSystemIconVisible = true;
    ((MaterialBase5) this).ToolBorVisible = true;
    ((MaterialBase5) this).Width = 0;
    ((MaterialBase5) this).Height = 0;
    ((MaterialBase5) this).PanMouseButtons = new MouseButton(MouseButtons.Middle, modifierKeys.None);
    ((MaterialBase5) this).RotateMouseButtons = new MouseButton(MouseButtons.Middle, modifierKeys.Ctrl);
    ((MaterialBase5) this).ZoomMouseButtons = new MouseButton(MouseButtons.Middle, modifierKeys.Shift);
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public ShapeEdit(ViewportSettings Settings)
  {
    ((ViewportDrawOptions) this).BottomColor = Color.DarkGray;
    ((ViewportDrawOptions) this).MiddleColor = Color.White;
    ((ViewportDrawOptions) this).TopColor = Color.White;
    ((ViewportDrawOptions) this).DisplayType = displayType.Rendered;
    ((MaterialBase5) this).ProjetionType = projectionType.Perspective;
    ((MaterialBase5) this).OrigineSymbol = originSymbolStyleType.Ball;
    ((MaterialBase5) this).WaitCursorMode = waitCursorType.Never;
    ((MaterialBase5) this).Dock = DockStyle.Fill;
    ((MaterialBase5) this).ShowProgress = false;
    ((MaterialBase5) this).GridVisible = false;
    ((MaterialBase5) this).GridStepX = 10.0;
    ((MaterialBase5) this).GridStepY = 10.0;
    ((MaterialBase5) this).OriginSymbolVisible = false;
    ((MaterialBase5) this).OrigineCaptionVisible = false;
    ((MaterialBase5) this).OrigineSize = 12;
    ((MaterialBase5) this).ViewCubeIconVisible = true;
    ((MaterialBase5) this).ReverseMouseWheel = false;
    ((MaterialBase5) this).CoordinateSystemIconVisible = true;
    ((MaterialBase5) this).ToolBorVisible = true;
    ((MaterialBase5) this).Width = 0;
    ((MaterialBase5) this).Height = 0;
    ((MaterialBase5) this).PanMouseButtons = new MouseButton(MouseButtons.Middle, modifierKeys.None);
    ((MaterialBase5) this).RotateMouseButtons = new MouseButton(MouseButtons.Middle, modifierKeys.Ctrl);
    ((MaterialBase5) this).ZoomMouseButtons = new MouseButton(MouseButtons.Middle, modifierKeys.Shift);
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((ViewportDrawOptions) this).BottomColor = ((SortSettings) Settings).BottomColor;
    ((ViewportDrawOptions) this).TopColor = ((SortFilter) Settings).TopColor;
    ((ViewportDrawOptions) this).MiddleColor = ((SortFilter) Settings).IntermediateColor;
    ((MaterialBase5) this).CoordinateSystemIconVisible = ((ShapeCreateParameters) Settings).ShowCoordinateSystemIcon;
    ((MaterialBase5) this).ViewCubeIconVisible = ((ShapeCreateParameters) Settings).ShowCubeIcon;
    ((MaterialBase5) this).GridVisible = ((ShapeCreateParameters) Settings).ShowGrid;
    ((MaterialBase5) this).OrigineCaptionVisible = ((ShapeCreateParameters) Settings).ShowOrigineCaption;
    ((MaterialBase5) this).OriginSymbolVisible = ((ShapeCreateParameters) Settings).ShowOrigineIcon;
    ((MaterialBase5) this).ToolBorVisible = ((ShapeCreateParameters) Settings).ShowToolbar;
    ((ViewportDrawOptions) this).DisplayType = (displayType) Convert.ToInt32((object) ((SortSettings) Settings).DisplayMode);
    ((MaterialBase5) this).ProjetionType = (projectionType) Convert.ToInt32((object) ((SortSettings) Settings).Projection);
    ((MaterialBase5) this).OrigineSymbol = (originSymbolStyleType) Convert.ToInt32((object) ((SortSettings) Settings).OrigineIcon);
    ((MaterialBase5) this).OrigineSize = ((ShapeCreateParameters) Settings).OrigineSize;
    ((MaterialBase5) this).GridStepX = ((ShapeCreateParameters) Settings).GridStepX;
    ((MaterialBase5) this).GridStepY = ((ShapeCreateParameters) Settings).GridStepY;
  }

  public ShapeEdit(CreateModelProperties data)
  {
    ((ViewportDrawOptions) this).BottomColor = Color.DarkGray;
    ((ViewportDrawOptions) this).MiddleColor = Color.White;
    ((ViewportDrawOptions) this).TopColor = Color.White;
    ((ViewportDrawOptions) this).DisplayType = displayType.Rendered;
    ((MaterialBase5) this).ProjetionType = projectionType.Perspective;
    ((MaterialBase5) this).OrigineSymbol = originSymbolStyleType.Ball;
    ((MaterialBase5) this).WaitCursorMode = waitCursorType.Never;
    ((MaterialBase5) this).Dock = DockStyle.Fill;
    ((MaterialBase5) this).ShowProgress = false;
    ((MaterialBase5) this).GridVisible = false;
    ((MaterialBase5) this).GridStepX = 10.0;
    ((MaterialBase5) this).GridStepY = 10.0;
    ((MaterialBase5) this).OriginSymbolVisible = false;
    ((MaterialBase5) this).OrigineCaptionVisible = false;
    ((MaterialBase5) this).OrigineSize = 12;
    ((MaterialBase5) this).ViewCubeIconVisible = true;
    ((MaterialBase5) this).ReverseMouseWheel = false;
    ((MaterialBase5) this).CoordinateSystemIconVisible = true;
    ((MaterialBase5) this).ToolBorVisible = true;
    ((MaterialBase5) this).Width = 0;
    ((MaterialBase5) this).Height = 0;
    ((MaterialBase5) this).PanMouseButtons = new MouseButton(MouseButtons.Middle, modifierKeys.None);
    ((MaterialBase5) this).RotateMouseButtons = new MouseButton(MouseButtons.Middle, modifierKeys.Ctrl);
    ((MaterialBase5) this).ZoomMouseButtons = new MouseButton(MouseButtons.Middle, modifierKeys.Shift);
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
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
    ((MaterialBase5) this).PanMouseButtons = new MouseButton(((MaterialBase5) data).PanMouseButtons.Button, ((MaterialBase5) data).PanMouseButtons.ModifierKey);
    ((MaterialBase5) this).RotateMouseButtons = new MouseButton(((MaterialBase5) data).RotateMouseButtons.Button, ((MaterialBase5) data).RotateMouseButtons.ModifierKey);
    ((MaterialBase5) this).ZoomMouseButtons = new MouseButton(((MaterialBase5) data).ZoomMouseButtons.Button, ((MaterialBase5) data).ZoomMouseButtons.ModifierKey);
  }

  public ShapeEdit()
  {
    ((MaterialBase5) this).BottomColor = Color.DarkGray;
    ((MaterialBase5) this).IntermediateColor = Color.White;
    ((MaterialBase5) this).TopColor = Color.SlateGray;
    ((MaterialBase5) this).DisplayType = displayType.Rendered;
    ((MaterialBase5) this).ProjectionType = projectionType.Orthographic;
    ((MaterialBase5) this).OriginSymbol = originSymbolStyleType.Ball;
    ((MaterialBase5) this).PanMouseButton = new MouseButton(MouseButtons.Middle, modifierKeys.None);
    ((MaterialBase5) this).RotateMouseButton = new MouseButton(MouseButtons.Middle, modifierKeys.Ctrl);
    ((MaterialBase5) this).ZoomMouseButton = new MouseButton(MouseButtons.Middle, modifierKeys.Shift);
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
  }
}
