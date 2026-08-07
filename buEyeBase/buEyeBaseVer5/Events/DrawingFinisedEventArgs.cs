// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Events.DrawingFinisedEventArgs
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Graphics;
using System;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Events;

[Serializable]
public class DrawingFinisedEventArgs
{
  public static Design baseModel;
  public static screenInfo ScreenInfo;

  public void UpdateModelControl(ref Design viewport, CreateModelProperties Properties)
  {
    if (((MaterialBase5) Properties).Width > 0)
      viewport.Width = ((MaterialBase5) Properties).Width;
    if (((MaterialBase5) Properties).Height > 0)
      viewport.Height = ((MaterialBase5) Properties).Height;
    BackgroundSettings backgroundSettings = new BackgroundSettings(backgroundStyleType.LinearGradient, ((ViewportDrawOptions) Properties).BottomColor, ((ViewportDrawOptions) Properties).MiddleColor, ((ViewportDrawOptions) Properties).TopColor, 0.75, (Image) null, colorThemeType.Auto, 0.3);
    viewport.Viewports[0].Background = backgroundSettings;
    viewport.ActiveViewport.DisplayMode = ((ViewportDrawOptions) Properties).DisplayType;
    viewport.Viewports[0].Pan.MouseButton = new MouseButton(((MaterialBase5) Properties).PanMouseButtons.Button, ((MaterialBase5) Properties).PanMouseButtons.ModifierKey);
    viewport.Viewports[0].Rotate.MouseButton = new MouseButton(((MaterialBase5) Properties).RotateMouseButtons.Button, ((MaterialBase5) Properties).RotateMouseButtons.ModifierKey);
    viewport.Viewports[0].Zoom.MouseButton = new MouseButton(((MaterialBase5) Properties).ZoomMouseButtons.Button, ((MaterialBase5) Properties).ZoomMouseButtons.ModifierKey);
    viewport.Viewports[0].Camera.ProjectionMode = ((MaterialBase5) Properties).ProjetionType;
    viewport.Viewports[0].Grid.Visible = ((MaterialBase5) Properties).GridVisible;
    viewport.Viewports[0].OriginSymbol.Visible = ((MaterialBase5) Properties).OriginSymbolVisible;
    viewport.Viewports[0].Zoom.ReverseMouseWheel = ((MaterialBase5) Properties).ReverseMouseWheel;
    viewport.Viewports[0].OriginSymbol.LabelOrigin = "";
    viewport.Viewports[0].OriginSymbol.StyleMode = ((MaterialBase5) Properties).OrigineSymbol;
    viewport.Viewports[0].OriginSymbol.Size = ((MaterialBase5) Properties).OrigineSize;
    viewport.Viewports[0].OriginSymbol.LabelAxisX = "";
    viewport.Viewports[0].OriginSymbol.LabelAxisY = "";
    viewport.Viewports[0].OriginSymbol.LabelAxisZ = "";
    viewport.Viewports[0].OriginSymbol.EdgeColor = Color.Black;
    viewport.Viewports[0].CoordinateSystemIcon.Visible = ((MaterialBase5) Properties).CoordinateSystemIconVisible;
    viewport.Viewports[0].ViewCubeIcon.Visible = ((MaterialBase5) Properties).ViewCubeIconVisible;
    viewport.Viewports[0].ToolBar.Visible = ((MaterialBase5) Properties).ToolBorVisible;
    viewport.Dock = ((MaterialBase5) Properties).Dock;
    viewport.ProgressBar.Visible = ((MaterialBase5) Properties).ShowProgress;
    viewport.WaitCursorMode = ((MaterialBase5) Properties).WaitCursorMode;
  }
}
