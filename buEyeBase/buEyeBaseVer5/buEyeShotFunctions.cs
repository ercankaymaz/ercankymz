// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEyeShotFunctions
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buCore;
using buMutliTextbox;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5;

public class buEyeShotFunctions
{
  public static buLabel hmiToBuLabel(buControlDisplay display, hmiUIPars parameters, buLabel Lbl)
  {
    try
    {
      Lbl.Geometry.ArcDiameter = ((buFile5.PLYToSchematic.\u0001) parameters).GeometryArcDiameer;
      Lbl.Geometry.ShapeMode = ((buFile5.PLYToSchematic.\u0001) parameters).GeometryType;
      Lbl.Display = buControlDisplay.Copy(display, Lbl.Display);
      if (((buFile5.PLYToSchematic.\u0001) parameters).GeometryType != 0)
        Lbl.BackColor = Color.Transparent;
      return Lbl;
    }
    catch (Exception ex)
    {
      return Lbl;
    }
  }

  public static buListBox hmiToBuListBox(hmiUISettings data, buListBox Lst)
  {
    try
    {
      Lst.Geometry.ArcDiameter = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryArcDiameer;
      Lst.Geometry.ShapeMode = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryType;
      Lst.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) data).Display, Lst.Display);
      if (((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryType != 0)
        Lst.BackColor = Color.Transparent;
      return Lst;
    }
    catch (Exception ex)
    {
      return Lst;
    }
  }

  public static buComboBox hmiToBuCombobox(hmiUISettings data, buComboBox Lst)
  {
    try
    {
      Lst.Geometry.ArcDiameter = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryArcDiameer;
      Lst.Geometry.ShapeMode = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryType;
      Lst.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) data).Display, Lst.Display);
      Lst.Caption.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) data).Caption, Lst.Caption.Display);
      Lst.Combo.DropBoxColor = ((buFile5.PLYToSchematic.\u0003) ((buFile5.PLYToSchematic.\u0001) data).Parameters).DropColor;
      Lst.Combo.ArrowColor = ((buFile5.PLYToSchematic.\u0003) ((buFile5.PLYToSchematic.\u0001) data).Parameters).ArrowColor;
      Lst.Combo.ValueColor = ((buFile5.PLYToSchematic.\u0001) data).Display.BackColor;
      Lst.Combo.ArrowLineColor = ((buFile5.PLYToSchematic.\u0002) ((buFile5.PLYToSchematic.\u0001) data).Parameters).LineColor;
      Lst.Combo.ArrowButtonWidth = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).ObjectWidth;
      if (((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryType != 0)
        Lst.BackColor = Color.Transparent;
      return Lst;
    }
    catch (Exception ex)
    {
      return Lst;
    }
  }

  public static DataGridView hmiToDataGridView(hmiUIDataGridView data, DataGridView Dvg)
  {
    try
    {
      Dvg.EnableHeadersVisualStyles = false;
      Dvg.ColumnHeadersDefaultCellStyle.BackColor = ((buFile5.GCodeRead) data).colorHeader;
      Dvg.ColumnHeadersDefaultCellStyle.ForeColor = ((buFile5.GCodeRead) data).colorHeaderFore;
      Dvg.ColumnHeadersDefaultCellStyle.Font = new Font(((buFile5.GCodeRead) data).fontHeader.Name, ((buFile5.GCodeRead) data).fontHeader.Size, ((buFile5.GCodeRead) data).fontHeader.Style);
      Dvg.RowHeadersDefaultCellStyle.ForeColor = ((buFile5.GCodeRead) data).colorHeaderFore;
      Dvg.RowHeadersDefaultCellStyle.BackColor = ((buFile5.GCodeRead) data).colorHeader;
      Dvg.CellBorderStyle = DataGridViewCellBorderStyle.Single;
      Dvg.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      Dvg.GridColor = ((buFile5.GCodeRead) data).colorGrid;
      Dvg.BackgroundColor = ((buFile5.GCodeRead) data).colorBackGround;
      Dvg.DefaultCellStyle.SelectionBackColor = ((buFile5.GCodeRead) data).colorCellSelected;
      Dvg.DefaultCellStyle.SelectionForeColor = ((buFile5.GCodeRead) data).colorFore;
      Dvg.DefaultCellStyle.Font = new Font(((buFile5.GCodeRead) data).fontCell.Name, ((buFile5.GCodeRead) data).fontCell.Size, ((buFile5.GCodeRead) data).fontCell.Style);
      Dvg.DefaultCellStyle.BackColor = ((buFile5.GCodeRead) data).colorCell;
      Dvg.DefaultCellStyle.ForeColor = ((buFile5.GCodeRead) data).colorFore;
      return Dvg;
    }
    catch (Exception ex)
    {
      return Dvg;
    }
  }

  public static RadioButton hmiToRadioButton(hmiUISettings data, RadioButton Radio)
  {
    try
    {
      Radio.BackColor = ((buFile5.PLYToSchematic.\u0001) data).Display.BackColor;
      Radio.ForeColor = ((buFile5.PLYToSchematic.\u0001) data).Display.Fonts.ForeColor;
      Radio.TextAlign = ((buFile5.PLYToSchematic.\u0001) data).Display.Fonts.Alignment;
      if (((buFile5.PLYToSchematic.\u0001) data).Display.Fonts.Font.Name.Trim().Length > 0)
        Radio.Font = new Font(((buFile5.PLYToSchematic.\u0001) data).Display.Fonts.Font.Name, ((buFile5.PLYToSchematic.\u0001) data).Display.Fonts.Font.Size, ((buFile5.PLYToSchematic.\u0001) data).Display.Fonts.Font.Style);
      return Radio;
    }
    catch (Exception ex)
    {
      return Radio;
    }
  }

  public static buSpin hmiToBuSpin(hmiUISettings data, buSpin Spn)
  {
    try
    {
      Spn.Geometry.ArcDiameter = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryArcDiameer;
      Spn.Geometry.ShapeMode = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryType;
      Spn.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) data).Display, Spn.Display);
      Spn.Caption.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) data).Caption, Spn.Caption.Display);
      Spn.ButtonDownDisplay = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) data).ButtonDown, Spn.ButtonDownDisplay);
      Spn.ButtonOverDisplay = buControlDisplay.Copy(((buFile5) data).ButtonOver, Spn.ButtonOverDisplay);
      Spn.ButtonNormalDisplay = buControlDisplay.Copy(((buFile5) data).ButtonNormal, Spn.ButtonNormalDisplay);
      if (((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryType != 0)
        Spn.BackColor = Color.Transparent;
      return Spn;
    }
    catch (Exception ex)
    {
      return Spn;
    }
  }

  public static buTextBox hmiToBuTextBox(hmiUISettings data, buTextBox Txt)
  {
    try
    {
      Txt.Geometry.ArcDiameter = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryArcDiameer;
      Txt.Geometry.ShapeMode = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryType;
      Txt.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) data).Display, Txt.Display);
      Txt.Caption.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) data).Caption, Txt.Caption.Display);
      if (((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryType != 0)
        Txt.BackColor = Color.Transparent;
      return Txt;
    }
    catch (Exception ex)
    {
      return Txt;
    }
  }

  public static buMultiTextBox hmiToBuMultiTextBox(hmiUISettings data, buMultiTextBox Txt)
  {
    try
    {
      Txt.BackColor = ((buFile5.PLYToSchematic.\u0001) data).Display.BackColor;
      return Txt;
    }
    catch (Exception ex)
    {
      return Txt;
    }
  }

  public static buCheckBox hmiToBuCheckbox(hmiUISettings data, buCheckBox Chk)
  {
    try
    {
      Chk.Geometry.ArcDiameter = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryArcDiameer;
      Chk.Geometry.ShapeMode = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryType;
      Chk.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) data).Display, Chk.Display);
      Chk.CheckTick.TickDisplay = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) data).Caption, Chk.CheckTick.TickDisplay);
      Chk.CheckTick.ColorModeDisplay = buControlDisplay.Copy(((buFile5) data).ButtonNormal, Chk.CheckTick.ColorModeDisplay);
      if (((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryType != 0)
        Chk.BackColor = Color.Transparent;
      Chk.CheckTick.Visible = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).CheckBoxVisible;
      Chk.CheckTick.ColorModeEnable = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).CheckColorMode;
      if (((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).CheckBoxSize >= 0)
        Chk.CheckTick.BoxSize = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).CheckBoxSize;
      Chk.CheckTick.Shape = !((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).CheckBoxCheckIsRectangle ? ShapeType.Arc : ShapeType.Rectangle;
      return Chk;
    }
    catch (Exception ex)
    {
      return Chk;
    }
  }

  public static buTrack hmiToBuTrack(
    hmiUISettings data,
    hmiUISettings dataDone,
    hmiUISettings dataDrawer,
    buTrack Track)
  {
    try
    {
      Track.Geometry.ArcDiameter = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryArcDiameer;
      Track.Geometry.ShapeMode = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryType;
      Track.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) data).Display, Track.Display);
      Track.Track.DoneDisplay = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) dataDone).Display, Track.Track.DoneDisplay);
      Track.Track.DrawerDisplay = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) dataDrawer).Display, Track.Track.DrawerDisplay);
      if (((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryType == ShapeType.Arc)
        Track.BackColor = Color.Transparent;
      return Track;
    }
    catch (Exception ex)
    {
      return Track;
    }
  }

  public static buTrack hmiToBuTrack(hmiUISettings data, buTrack Track)
  {
    try
    {
      Track.Geometry.ArcDiameter = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryArcDiameer;
      Track.Geometry.ShapeMode = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryType;
      Track.Caption.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) data).Caption, Track.Display);
      Track.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) data).Display, Track.Display);
      Track.Track.DoneDisplay = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) data).Done, Track.Track.DoneDisplay);
      Track.Track.DrawerDisplay = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) data).Shape, Track.Track.DrawerDisplay);
      Track.Track.ShowPersentage = ((buFile5.PLYToSchematic.\u0002) ((buFile5.PLYToSchematic.\u0001) data).Parameters).ShowPersentage;
      Track.Track.DrawerWidth = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).ObjectWidth;
      if (((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryType == ShapeType.Arc)
        Track.BackColor = Color.Transparent;
      return Track;
    }
    catch (Exception ex)
    {
      return Track;
    }
  }

  public static buProgressBar hmiToBuProgress(hmiUISettings data, buProgressBar Progress)
  {
    try
    {
      Progress.Geometry.ArcDiameter = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryArcDiameer;
      Progress.Geometry.ShapeMode = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryType;
      Progress.Caption.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) data).Caption, Progress.Display);
      Progress.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) data).Display, Progress.Display);
      Progress.ProgressLineer.DoneDisplay = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) data).Done, Progress.ProgressLineer.DoneDisplay);
      Progress.ProgressLineer.ShowPercentage = ((buFile5.PLYToSchematic.\u0002) ((buFile5.PLYToSchematic.\u0001) data).Parameters).ShowPersentage;
      if (((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryType == ShapeType.Arc)
        Progress.BackColor = Color.Transparent;
      return Progress;
    }
    catch (Exception ex)
    {
      return Progress;
    }
  }

  public static buPanel hmiToBuPanel(hmiUISettings data, buPanel Pnl)
  {
    try
    {
      Pnl.Geometry.ArcDiameter = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryArcDiameer;
      Pnl.Geometry.ShapeMode = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryType;
      Pnl.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) data).Display, Pnl.Display);
      return Pnl;
    }
    catch (Exception ex)
    {
      return Pnl;
    }
  }

  public static buGroup hmiToBuGroup(hmiUISettings data, buGroup Group)
  {
    try
    {
      Group.Geometry.ArcDiameter = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryArcDiameer;
      Group.Geometry.ShapeMode = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryType;
      Group.TitleDisplay = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) data).Caption, Group.TitleDisplay);
      Group.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) data).Display, Group.Display);
      Group.TitleHeight = ((buFile5.PLYToSchematic.\u0002) ((buFile5.PLYToSchematic.\u0001) data).Parameters).TopHeight;
      if (((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryType == ShapeType.Arc)
        Group.BackColor = Color.Transparent;
      return Group;
    }
    catch (Exception ex)
    {
      return Group;
    }
  }

  public static buGround hmiToBuGround(
    hmiUISettings data,
    hmiUISettings dataTop,
    hmiUISettings dataBottom,
    buGround Ground)
  {
    try
    {
      Ground.Geometry.ArcDiameter = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryArcDiameer;
      Ground.Geometry.ShapeMode = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryType;
      Ground.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) data).Display, Ground.Display);
      Ground.DisplayTop = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) dataTop).Display, Ground.DisplayTop);
      Ground.DisplayBottom = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) dataBottom).Display, Ground.DisplayBottom);
      return Ground;
    }
    catch (Exception ex)
    {
      return Ground;
    }
  }

  public static buGround hmiToBuGround(hmiUISettings data, buGround Group)
  {
    try
    {
      Group.Geometry.ArcDiameter = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryArcDiameer;
      Group.Geometry.ShapeMode = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryType;
      Group.DisplayTop = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) data).Caption, Group.DisplayTop);
      Group.DisplayBottom = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) data).Shape, Group.DisplayBottom);
      Group.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) data).Display, Group.Display);
      Group.Ground.TopHeight = ((buFile5.PLYToSchematic.\u0002) ((buFile5.PLYToSchematic.\u0001) data).Parameters).TopHeight;
      Group.Ground.BottomHeight = ((buFile5.PLYToSchematic.\u0002) ((buFile5.PLYToSchematic.\u0001) data).Parameters).BottomHeight;
      if (((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryType == ShapeType.Arc)
        Group.BackColor = Color.Transparent;
      return Group;
    }
    catch (Exception ex)
    {
      return Group;
    }
  }

  public static buButton hmiToBuButton(hmiUISettings dataNormal, double ToneChange, buButton Btn)
  {
    try
    {
      Btn.Geometry.ArcDiameter = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) dataNormal).Parameters).GeometryArcDiameer;
      Btn.Geometry.ShapeMode = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) dataNormal).Parameters).GeometryType;
      Btn.Display = buControlDisplay.Copy(((buFile5) dataNormal).ButtonNormal, Btn.Display);
      Btn.ButtonDownDisplay = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) dataNormal).ButtonDown, Btn.ButtonDownDisplay);
      Btn.ButtonOverDisplay = buControlDisplay.Copy(((buFile5) dataNormal).ButtonOver, Btn.ButtonOverDisplay);
      Btn.Display.SelectionColor = ((buFile5.PLYToSchematic.\u0001) dataNormal).Display.SelectionColor;
      Btn.ButtonOverDisplay.BackColor = buFile5.ColorToneChange(((buFile5.PLYToSchematic.\u0001) dataNormal).Display.BackColor, 1.0 + ToneChange);
      Btn.ButtonDownDisplay.BackColor = buFile5.ColorToneChange(((buFile5.PLYToSchematic.\u0001) dataNormal).Display.BackColor, 1.0 + 2.0 * ToneChange);
      Btn.ButtonOverDisplay.LineerGradient.FirstColor = buFile5.ColorToneChange(((buFile5) dataNormal).ButtonNormal.LineerGradient.FirstColor, 1.0 + ToneChange);
      Btn.ButtonOverDisplay.LineerGradient.SecondColor = buFile5.ColorToneChange(((buFile5) dataNormal).ButtonNormal.LineerGradient.SecondColor, 1.0 + ToneChange);
      Btn.ButtonDownDisplay.LineerGradient.FirstColor = buFile5.ColorToneChange(((buFile5) dataNormal).ButtonNormal.LineerGradient.FirstColor, 1.0 + 2.0 * ToneChange);
      Btn.ButtonDownDisplay.LineerGradient.SecondColor = buFile5.ColorToneChange(((buFile5) dataNormal).ButtonNormal.LineerGradient.SecondColor, 1.0 + 2.0 * ToneChange);
      if (((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) dataNormal).Parameters).GeometryType == ShapeType.Arc | ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) dataNormal).Parameters).GeometryType == ShapeType.Ellipse)
        Btn.BackColor = Color.Transparent;
      return Btn;
    }
    catch (Exception ex)
    {
      return Btn;
    }
  }

  public static buButton hmiToBuButton(hmiUISettings dataNormal, buButton Btn)
  {
    try
    {
      Btn.Display = buControlDisplay.Copy(((buFile5) dataNormal).ButtonNormal, Btn.Display, false);
      Btn.ButtonDownDisplay = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) dataNormal).ButtonDown, Btn.ButtonDownDisplay, false);
      Btn.ButtonOverDisplay = buControlDisplay.Copy(((buFile5) dataNormal).ButtonOver, Btn.ButtonOverDisplay, false);
      Btn.Geometry.ArcDiameter = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) dataNormal).Parameters).GeometryArcDiameer;
      Btn.Geometry.ShapeMode = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) dataNormal).Parameters).GeometryType;
      if (((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) dataNormal).Parameters).GeometryType == ShapeType.Arc | ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) dataNormal).Parameters).GeometryType == ShapeType.Ellipse)
        Btn.BackColor = Color.Transparent;
      return Btn;
    }
    catch (Exception ex)
    {
      return Btn;
    }
  }

  public static buButton hmiToBuButton(hmiUIBasicSettings dataNormal, buButton Btn)
  {
    try
    {
      Btn.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) dataNormal).Display, Btn.Display);
      Btn.ButtonDownDisplay = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) dataNormal).Display, Btn.ButtonDownDisplay);
      Btn.ButtonOverDisplay = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) dataNormal).Display, Btn.ButtonOverDisplay);
      Btn.Geometry.ArcDiameter = ((buFile5.Cf2) ((buFile5.PLYToSchematic.\u0001) dataNormal).Parameters).GeometryArcDiameer;
      Btn.Geometry.ShapeMode = ((buFile5.Cf2) ((buFile5.PLYToSchematic.\u0001) dataNormal).Parameters).GeometryType;
      Btn.ImageAlign = ((buFile5.Cf2) ((buFile5.PLYToSchematic.\u0001) dataNormal).Parameters).ImageAlignment;
      if (((buFile5.Cf2) ((buFile5.PLYToSchematic.\u0001) dataNormal).Parameters).GeometryType == ShapeType.Arc | ((buFile5.Cf2) ((buFile5.PLYToSchematic.\u0001) dataNormal).Parameters).GeometryType == ShapeType.Ellipse)
        Btn.BackColor = Color.Transparent;
      return Btn;
    }
    catch (Exception ex)
    {
      return Btn;
    }
  }

  public static buButton hmiToBuButton(
    buControlDisplay display,
    buControlDisplay over,
    buControlDisplay down,
    hmiUIPars parameters,
    buButton Btn)
  {
    try
    {
      Btn.Geometry.ArcDiameter = ((buFile5.PLYToSchematic.\u0001) parameters).GeometryArcDiameer;
      Btn.Geometry.ShapeMode = ((buFile5.PLYToSchematic.\u0001) parameters).GeometryType;
      Btn.Display = buControlDisplay.Copy(display, Btn.Display);
      Btn.ButtonOverDisplay = buControlDisplay.Copy(over, Btn.ButtonOverDisplay);
      Btn.ButtonDownDisplay = buControlDisplay.Copy(down, Btn.ButtonDownDisplay);
      if (((buFile5.PLYToSchematic.\u0001) parameters).GeometryType != 0)
        Btn.BackColor = Color.Transparent;
      return Btn;
    }
    catch (Exception ex)
    {
      return Btn;
    }
  }

  public static void buButtonToHmi(ref hmiUISettings data, buButton Btn)
  {
    try
    {
      ((buFile5) data).ButtonNormal = buControlDisplay.Copy(Btn.Display, ((buFile5) data).ButtonNormal);
      ((buFile5) data).ButtonOver = buControlDisplay.Copy(Btn.Display, ((buFile5) data).ButtonOver);
      ((buFile5.PLYToSchematic.\u0001) data).ButtonDown = buControlDisplay.Copy(Btn.Display, ((buFile5.PLYToSchematic.\u0001) data).ButtonDown);
      ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryArcDiameer = Btn.Geometry.ArcDiameter;
      ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryType = Btn.Geometry.ShapeMode;
    }
    catch (Exception ex)
    {
    }
  }

  public static Control.ControlCollection SetVisualItem(Control.ControlCollection Controls)
  {
    for (int index = 0; index <= Controls.Count - 1; ++index)
    {
      if (Controls[index] is buButton)
      {
        buButton control = Controls[index] as buButton;
        buButton buButton;
        if (control.ControlStyle == ControlStyle.System1)
        {
          if (clsVisualVars.parVisual.hmiButtonSystem1 != null)
            buButton = buEyeShotFunctions.hmiToBuButton(clsVisualVars.parVisual.hmiButtonSystem1, control);
        }
        else if (control.ControlStyle == ControlStyle.System2)
        {
          if (clsVisualVars.parVisual.hmiButtonSystem2 != null)
            buButton = buEyeShotFunctions.hmiToBuButton(clsVisualVars.parVisual.hmiButtonSystem2, control);
        }
        else if (control.ControlStyle == ControlStyle.System3)
        {
          if (clsVisualVars.parVisual.hmiButtonSystem3 != null)
            buButton = buEyeShotFunctions.hmiToBuButton(clsVisualVars.parVisual.hmiButtonSystem3, control);
        }
        else if (control.ControlStyle == ControlStyle.System4)
        {
          if (clsVisualVars.parVisual.hmiButtonSystem4 != null)
            buButton = buEyeShotFunctions.hmiToBuButton(clsVisualVars.parVisual.hmiButtonSystem4, control);
        }
        else if (control.ControlStyle == ControlStyle.Menu1)
        {
          if (clsVisualVars.parVisual.hmiButtonMenu1 != null)
            buButton = buEyeShotFunctions.hmiToBuButton(clsVisualVars.parVisual.hmiButtonMenu1, control);
        }
        else if (control.ControlStyle == ControlStyle.Menu2)
        {
          if (clsVisualVars.parVisual.hmiButtonMenu2 != null)
            buButton = buEyeShotFunctions.hmiToBuButton(clsVisualVars.parVisual.hmiButtonMenu2, control);
        }
        else if (control.ControlStyle == ControlStyle.Menu3)
        {
          if (clsVisualVars.parVisual.hmiButtonMenu3 != null)
            buButton = buEyeShotFunctions.hmiToBuButton(clsVisualVars.parVisual.hmiButtonMenu3, control);
        }
        else if (control.ControlStyle == ControlStyle.Menu4)
        {
          if (clsVisualVars.parVisual.hmiButtonMenu4 != null)
            buButton = buEyeShotFunctions.hmiToBuButton(clsVisualVars.parVisual.hmiButtonMenu4, control);
        }
        else if (control.ControlStyle == ControlStyle.Command1)
        {
          if (clsVisualVars.parVisual.hmiButtonCommand1 != null)
            buButton = buEyeShotFunctions.hmiToBuButton(clsVisualVars.parVisual.hmiButtonCommand1, control);
        }
        else if (control.ControlStyle == ControlStyle.Command2)
        {
          if (clsVisualVars.parVisual.hmiButtonCommand2 != null)
            buButton = buEyeShotFunctions.hmiToBuButton(clsVisualVars.parVisual.hmiButtonCommand2, control);
        }
        else if (control.ControlStyle == ControlStyle.Command3)
        {
          if (clsVisualVars.parVisual.hmiButtonCommand3 != null)
            buButton = buEyeShotFunctions.hmiToBuButton(clsVisualVars.parVisual.hmiButtonCommand3, control);
        }
        else if (control.ControlStyle == ControlStyle.Command4)
        {
          if (clsVisualVars.parVisual.hmiButtonCommand4 != null)
            buButton = buEyeShotFunctions.hmiToBuButton(clsVisualVars.parVisual.hmiButtonCommand4, control);
        }
        else if (control.ControlStyle == ControlStyle.Ok)
        {
          if (clsVisualVars.parVisual.hmiButtonOk != null)
            buButton = buEyeShotFunctions.hmiToBuButton(clsVisualVars.parVisual.hmiButtonOk, control);
        }
        else if (control.ControlStyle == ControlStyle.Cancel)
        {
          if (clsVisualVars.parVisual.hmiButtonCancel != null)
            buButton = buEyeShotFunctions.hmiToBuButton(clsVisualVars.parVisual.hmiButtonCancel, control);
        }
        else if (control.ControlStyle == ControlStyle.FormButton && (control.Parent == null ? 0 : (control.Parent is buGround ? 1 : 0)) != 0)
        {
          buGround parent = control.Parent as buGround;
          control.Display = buControlDisplay.Copy(parent.DisplayTop, control.Display);
          control.ButtonOverDisplay = buControlDisplay.Copy(parent.DisplayTop, control.ButtonOverDisplay, 1.1);
          control.ButtonDownDisplay = buControlDisplay.Copy(parent.DisplayTop, control.ButtonDownDisplay, 0.9);
        }
      }
      if (Controls[index] is buSpin)
      {
        buSpin control = Controls[index] as buSpin;
        buSpin buSpin;
        if (control.ControlStyle == ControlStyle.Base1)
        {
          if (clsVisualVars.parVisual.hmiSpin1 != null)
            buSpin = buEyeShotFunctions.hmiToBuSpin(clsVisualVars.parVisual.hmiSpin1, control);
        }
        else if (control.ControlStyle == ControlStyle.Base2)
        {
          if (clsVisualVars.parVisual.hmiSpin2 != null)
            buSpin = buEyeShotFunctions.hmiToBuSpin(clsVisualVars.parVisual.hmiSpin2, control);
        }
        else if (control.ControlStyle == ControlStyle.Base3)
        {
          if (clsVisualVars.parVisual.hmiSpin3 != null)
            buSpin = buEyeShotFunctions.hmiToBuSpin(clsVisualVars.parVisual.hmiSpin3, control);
        }
        else if (control.ControlStyle == ControlStyle.Base4 && clsVisualVars.parVisual.hmiSpin4 != null)
          buSpin = buEyeShotFunctions.hmiToBuSpin(clsVisualVars.parVisual.hmiSpin4, control);
      }
      if (Controls[index] is buTextBox)
      {
        buTextBox control = Controls[index] as buTextBox;
        buTextBox buTextBox;
        if (control.ControlStyle == ControlStyle.Base1)
        {
          if (clsVisualVars.parVisual.hmiText1 != null)
            buTextBox = buEyeShotFunctions.hmiToBuTextBox(clsVisualVars.parVisual.hmiText1, control);
        }
        else if (control.ControlStyle == ControlStyle.Base2)
        {
          if (clsVisualVars.parVisual.hmiText2 != null)
            buTextBox = buEyeShotFunctions.hmiToBuTextBox(clsVisualVars.parVisual.hmiText2, control);
        }
        else if (control.ControlStyle == ControlStyle.Base3)
        {
          if (clsVisualVars.parVisual.hmiText3 != null)
            buTextBox = buEyeShotFunctions.hmiToBuTextBox(clsVisualVars.parVisual.hmiText3, control);
        }
        else if (control.ControlStyle == ControlStyle.Base4 && clsVisualVars.parVisual.hmiText4 != null)
          buTextBox = buEyeShotFunctions.hmiToBuTextBox(clsVisualVars.parVisual.hmiText4, control);
      }
      if (Controls[index] is buMultiTextBox)
      {
        buMultiTextBox control = Controls[index] as buMultiTextBox;
        buMultiTextBox buMultiTextBox;
        if ((control.Tag == null ? 0 : (control.Tag.ToString().ToLower() == "text1" ? 1 : 0)) != 0)
        {
          if (clsVisualVars.parVisual.hmiText1 != null)
            buMultiTextBox = buEyeShotFunctions.hmiToBuMultiTextBox(clsVisualVars.parVisual.hmiText1, control);
        }
        else if ((control.Tag == null ? 0 : (control.Tag.ToString().ToLower() == "text1" ? 1 : 0)) != 0)
        {
          if (clsVisualVars.parVisual.hmiText2 != null)
            buMultiTextBox = buEyeShotFunctions.hmiToBuMultiTextBox(clsVisualVars.parVisual.hmiText2, control);
        }
        else if ((control.Tag == null ? 0 : (control.Tag.ToString().ToLower() == "text1" ? 1 : 0)) != 0)
        {
          if (clsVisualVars.parVisual.hmiText3 != null)
            buMultiTextBox = buEyeShotFunctions.hmiToBuMultiTextBox(clsVisualVars.parVisual.hmiText3, control);
        }
        else if ((control.Tag == null ? 0 : (control.Tag.ToString().ToLower() == "text1" ? 1 : 0)) != 0 && clsVisualVars.parVisual.hmiText4 != null)
          buMultiTextBox = buEyeShotFunctions.hmiToBuMultiTextBox(clsVisualVars.parVisual.hmiText4, control);
      }
      if (Controls[index] is buCheckBox)
      {
        buCheckBox control = Controls[index] as buCheckBox;
        buCheckBox buCheckbox;
        if (control.ControlStyle == ControlStyle.Base1)
        {
          if (clsVisualVars.parVisual.hmiCheck1 != null)
            buCheckbox = buEyeShotFunctions.hmiToBuCheckbox(clsVisualVars.parVisual.hmiCheck1, control);
        }
        else if (control.ControlStyle == ControlStyle.Base2)
        {
          if (clsVisualVars.parVisual.hmiCheck2 != null)
            buCheckbox = buEyeShotFunctions.hmiToBuCheckbox(clsVisualVars.parVisual.hmiCheck2, control);
        }
        else if (control.ControlStyle == ControlStyle.Base3)
        {
          if (clsVisualVars.parVisual.hmiCheck3 != null)
            buCheckbox = buEyeShotFunctions.hmiToBuCheckbox(clsVisualVars.parVisual.hmiCheck3, control);
        }
        else if (control.ControlStyle == ControlStyle.Base4 && clsVisualVars.parVisual.hmiCheck4 != null)
          buCheckbox = buEyeShotFunctions.hmiToBuCheckbox(clsVisualVars.parVisual.hmiCheck4, control);
      }
      if (Controls[index] is buLabel)
      {
        buLabel control = Controls[index] as buLabel;
        buLabel buLabel;
        if (control.ControlStyle == ControlStyle.Base1)
        {
          if (clsVisualVars.parVisual.hmiLabel1 != null)
            buLabel = buFunctions.hmiToBuLabel(clsVisualVars.parVisual.hmiLabel1, control);
        }
        else if (control.ControlStyle == ControlStyle.Base2)
        {
          if (clsVisualVars.parVisual.hmiLabel2 != null)
            buLabel = buFunctions.hmiToBuLabel(clsVisualVars.parVisual.hmiLabel2, control);
        }
        else if (control.ControlStyle == ControlStyle.Base3)
        {
          if (clsVisualVars.parVisual.hmiLabel3 != null)
            buLabel = buFunctions.hmiToBuLabel(clsVisualVars.parVisual.hmiLabel3, control);
        }
        else if (control.ControlStyle == ControlStyle.Base4 && clsVisualVars.parVisual.hmiLabel4 != null)
          buLabel = buFunctions.hmiToBuLabel(clsVisualVars.parVisual.hmiLabel4, control);
      }
      if (Controls[index] is buListBox)
      {
        buListBox control = Controls[index] as buListBox;
        buListBox buListBox;
        if (control.ControlStyle == ControlStyle.Base1)
        {
          if (clsVisualVars.parVisual.hmiListbox1 != null)
            buListBox = buEyeShotFunctions.hmiToBuListBox(clsVisualVars.parVisual.hmiListbox1, control);
        }
        else if (control.ControlStyle == ControlStyle.Base2)
        {
          if (clsVisualVars.parVisual.hmiListbox1 != null)
            buListBox = buEyeShotFunctions.hmiToBuListBox(clsVisualVars.parVisual.hmiListbox2, control);
        }
        else if (control.ControlStyle == ControlStyle.Base3)
        {
          if (clsVisualVars.parVisual.hmiListbox1 != null)
            buListBox = buEyeShotFunctions.hmiToBuListBox(clsVisualVars.parVisual.hmiListbox3, control);
        }
        else if (control.ControlStyle == ControlStyle.Base4 && clsVisualVars.parVisual.hmiListbox1 != null)
          buListBox = buEyeShotFunctions.hmiToBuListBox(clsVisualVars.parVisual.hmiListbox4, control);
      }
      if (Controls[index] is buComboBox)
      {
        buComboBox control = Controls[index] as buComboBox;
        buComboBox buCombobox;
        if (control.ControlStyle == ControlStyle.Base1)
        {
          if (clsVisualVars.parVisual.hmiCombo1 != null)
            buCombobox = buEyeShotFunctions.hmiToBuCombobox(clsVisualVars.parVisual.hmiCombo1, control);
        }
        else if (control.ControlStyle == ControlStyle.Base2)
        {
          if (clsVisualVars.parVisual.hmiCombo1 != null)
            buCombobox = buEyeShotFunctions.hmiToBuCombobox(clsVisualVars.parVisual.hmiCombo2, control);
        }
        else if (control.ControlStyle == ControlStyle.Base3)
        {
          if (clsVisualVars.parVisual.hmiCombo1 != null)
            buCombobox = buEyeShotFunctions.hmiToBuCombobox(clsVisualVars.parVisual.hmiCombo3, control);
        }
        else if (control.ControlStyle == ControlStyle.Base4 && clsVisualVars.parVisual.hmiCombo1 != null)
          buCombobox = buEyeShotFunctions.hmiToBuCombobox(clsVisualVars.parVisual.hmiCombo4, control);
      }
      if (Controls[index] is DataGridView)
      {
        DataGridView control = Controls[index] as DataGridView;
        DataGridView dataGridView;
        if ((control.Tag == null ? 0 : (control.Tag.ToString().ToLower() == "base1" ? 1 : 0)) != 0)
        {
          if (clsVisualVars.parVisual.hmiDGV1 != null)
            dataGridView = buEyeShotFunctions.hmiToDataGridView(clsVisualVars.parVisual.hmiDGV1, control);
        }
        else if ((control.Tag == null ? 0 : (control.Tag.ToString().ToLower() == "base2" ? 1 : 0)) != 0 && clsVisualVars.parVisual.hmiDGV2 != null)
          dataGridView = buEyeShotFunctions.hmiToDataGridView(clsVisualVars.parVisual.hmiDGV2, control);
      }
      if (Controls[index] is RadioButton)
      {
        RadioButton control = Controls[index] as RadioButton;
        RadioButton radioButton;
        if ((control.Tag == null ? 0 : (control.Tag.ToString().ToLower() == "base1" ? 1 : 0)) != 0)
        {
          if (clsVisualVars.parVisual.hmiRadioButton1 != null)
            radioButton = buEyeShotFunctions.hmiToRadioButton(clsVisualVars.parVisual.hmiRadioButton1, control);
        }
        else if ((control.Tag == null ? 0 : (control.Tag.ToString().ToLower() == "base2" ? 1 : 0)) != 0)
        {
          if (clsVisualVars.parVisual.hmiRadioButton2 != null)
            radioButton = buEyeShotFunctions.hmiToRadioButton(clsVisualVars.parVisual.hmiRadioButton2, control);
        }
        else if ((control.Tag == null ? 0 : (control.Tag.ToString().ToLower() == "base3" ? 1 : 0)) != 0)
        {
          if (clsVisualVars.parVisual.hmiRadioButton3 != null)
            radioButton = buEyeShotFunctions.hmiToRadioButton(clsVisualVars.parVisual.hmiRadioButton3, control);
        }
        else if ((control.Tag == null ? 0 : (control.Tag.ToString().ToLower() == "base4" ? 1 : 0)) != 0 && clsVisualVars.parVisual.hmiRadioButton4 != null)
          radioButton = buEyeShotFunctions.hmiToRadioButton(clsVisualVars.parVisual.hmiRadioButton4, control);
      }
      if (Controls[index] is buTrack)
      {
        buTrack control = Controls[index] as buTrack;
        buTrack buTrack;
        if (control.ControlStyle == ControlStyle.Base1)
        {
          if (clsVisualVars.parVisual.hmiTrack1 != null)
            buTrack = buEyeShotFunctions.hmiToBuTrack(clsVisualVars.parVisual.hmiTrack1, control);
        }
        else if (control.ControlStyle == ControlStyle.Base2 && clsVisualVars.parVisual.hmiTrack2 != null)
          buTrack = buEyeShotFunctions.hmiToBuTrack(clsVisualVars.parVisual.hmiTrack2, control);
      }
      if (Controls[index] is buProgressBar)
      {
        buProgressBar control = Controls[index] as buProgressBar;
        buProgressBar buProgress;
        if (control.ControlStyle == ControlStyle.Base1)
        {
          if (clsVisualVars.parVisual.hmiProgress1 != null)
            buProgress = buEyeShotFunctions.hmiToBuProgress(clsVisualVars.parVisual.hmiProgress1, control);
        }
        else if (control.ControlStyle == ControlStyle.Base1 && clsVisualVars.parVisual.hmiProgress2 != null)
          buProgress = buEyeShotFunctions.hmiToBuProgress(clsVisualVars.parVisual.hmiProgress2, control);
      }
      if (Controls[index] is buPanel)
      {
        buPanel control = Controls[index] as buPanel;
        buPanel buPanel;
        if (control.ControlStyle == ControlStyle.Base1)
        {
          if (clsVisualVars.parVisual.hmiPanel1 != null)
            buPanel = buEyeShotFunctions.hmiToBuPanel(clsVisualVars.parVisual.hmiPanel1, control);
        }
        else if (control.ControlStyle == ControlStyle.Base2 && clsVisualVars.parVisual.hmiPanel2 != null)
          buPanel = buEyeShotFunctions.hmiToBuPanel(clsVisualVars.parVisual.hmiPanel2, control);
      }
      if (Controls[index] is buGroup)
      {
        buGroup control = Controls[index] as buGroup;
        buGroup buGroup;
        if (control.ControlStyle == ControlStyle.Base1)
        {
          if (clsVisualVars.parVisual.hmiGroup1 != null)
            buGroup = buEyeShotFunctions.hmiToBuGroup(clsVisualVars.parVisual.hmiGroup1, control);
        }
        else if (control.ControlStyle == ControlStyle.Base2 && clsVisualVars.parVisual.hmiGroup1 != null)
          buGroup = buEyeShotFunctions.hmiToBuGroup(clsVisualVars.parVisual.hmiGroup2, control);
      }
      if (Controls[index] is buGround)
      {
        buGround control = Controls[index] as buGround;
        buGround buGround;
        if (control.ControlStyle == ControlStyle.Base1)
        {
          if (clsVisualVars.parVisual.hmiGround1 != null)
            buGround = buEyeShotFunctions.hmiToBuGround(clsVisualVars.parVisual.hmiGround1, control);
        }
        else if (control.ControlStyle == ControlStyle.Base2 && clsVisualVars.parVisual.hmiGround2 != null)
          buGround = buEyeShotFunctions.hmiToBuGround(clsVisualVars.parVisual.hmiGround2, control);
      }
      if (Controls[index] is buButton)
      {
        buButton control = Controls[index] as buButton;
        buButton buButton;
        if (control.ControlStyle == ControlStyle.On1)
        {
          if (clsVisualVars.parVisual.hmiOn1 != null)
            buButton = buEyeShotFunctions.hmiToBuButton(clsVisualVars.parVisual.hmiOn1, control);
        }
        else if (control.ControlStyle == ControlStyle.On2)
        {
          if (clsVisualVars.parVisual.hmiOn2 != null)
            buButton = buEyeShotFunctions.hmiToBuButton(clsVisualVars.parVisual.hmiOn2, control);
        }
        else if (control.ControlStyle == ControlStyle.Off1)
        {
          if (clsVisualVars.parVisual.hmiOff1 != null)
            buButton = buEyeShotFunctions.hmiToBuButton(clsVisualVars.parVisual.hmiOff1, control);
        }
        else if (control.ControlStyle == ControlStyle.Off2 && clsVisualVars.parVisual.hmiOff2 != null)
          buButton = buEyeShotFunctions.hmiToBuButton(clsVisualVars.parVisual.hmiOff2, control);
      }
      if (Controls[index] is buLabel)
      {
        buLabel control = Controls[index] as buLabel;
        buLabel buLabel;
        if (control.ControlStyle == ControlStyle.Warning)
        {
          if (clsVisualVars.parVisual.hmiWarning != null)
            buLabel = buPipeBending.hmiToBuLabel(clsVisualVars.parVisual.hmiWarning, control);
        }
        else if (control.ControlStyle == ControlStyle.Error)
        {
          if (clsVisualVars.parVisual.hmiError != null)
            buLabel = buPipeBending.hmiToBuLabel(clsVisualVars.parVisual.hmiError, control);
        }
        else if (control.ControlStyle == ControlStyle.Info)
        {
          if (clsVisualVars.parVisual.hmiInfo != null)
            buLabel = buPipeBending.hmiToBuLabel(clsVisualVars.parVisual.hmiInfo, control);
        }
        else if (control.ControlStyle == ControlStyle.Status && clsVisualVars.parVisual.hmiStatus != null)
          buLabel = buPipeBending.hmiToBuLabel(clsVisualVars.parVisual.hmiStatus, control);
      }
      if (Controls[index] is buLabel)
      {
        buLabel control = Controls[index] as buLabel;
        buLabel buLabel;
        if (control.ControlStyle == ControlStyle.Coordinate1)
        {
          if (clsVisualVars.parVisual.hmiCoords1 != null)
            buLabel = buEyeShotFunctions.hmiToBuLabel(((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCoords1).Display, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCoords1).Parameters, control);
        }
        else if (control.ControlStyle == ControlStyle.Coordinate2)
        {
          if (clsVisualVars.parVisual.hmiCoords2 != null)
            buLabel = buEyeShotFunctions.hmiToBuLabel(((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCoords2).Display, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCoords2).Parameters, control);
        }
        else if (control.ControlStyle == ControlStyle.CoordinateCaption1)
        {
          if (clsVisualVars.parVisual.hmiCoords1 != null)
            buLabel = buEyeShotFunctions.hmiToBuLabel(((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCoords1).Caption, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCoords1).Parameters, control);
        }
        else if (control.ControlStyle == ControlStyle.CoordinateCaption2)
        {
          if (clsVisualVars.parVisual.hmiCoords2 != null)
            buLabel = buEyeShotFunctions.hmiToBuLabel(((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCoords2).Caption, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCoords2).Parameters, control);
        }
        else if (control.ControlStyle == ControlStyle.CoordinateTitle1)
        {
          if (clsVisualVars.parVisual.hmiCoords1 != null)
            control.Display.Fonts.ForeColor = ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCoords1).Display.TitleForeColor;
        }
        else if (control.ControlStyle == ControlStyle.CoordinateTitle2 && clsVisualVars.parVisual.hmiCoords2 != null)
          control.Display.Fonts.ForeColor = ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCoords2).Display.TitleForeColor;
      }
      if (Controls[index] is buLabel)
      {
        buLabel control = Controls[index] as buLabel;
        if (control.ControlStyle == ControlStyle.Speed1 && clsVisualVars.parVisual.hmiSpeed1 != null)
          buEyeShotFunctions.hmiToBuLabel(((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpeed1).Caption, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpeed1).Parameters, control);
      }
      if (Controls[index] is buTrack)
      {
        buTrack control = Controls[index] as buTrack;
        if (control.ControlStyle == ControlStyle.Speed1 && clsVisualVars.parVisual.hmiSpeed1 != null)
          buEyeShotFunctions.hmiToBuTrack(clsVisualVars.parVisual.hmiSpeed1, control);
      }
      if (Controls[index] is buSpin)
      {
        buSpin control = Controls[index] as buSpin;
        if (control.ControlStyle == ControlStyle.Speed1 && clsVisualVars.parVisual.hmiSpeed1 != null)
        {
          control.Display.BackColor = ((buFile5.PLYToSchematic.\u0003) ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpeed1).Parameters).ValueColor;
          control.Display.GradientType = GradientMode.Solid;
        }
      }
      if (Controls[index] is buButton)
      {
        buButton control = Controls[index] as buButton;
        if (control.ControlStyle == ControlStyle.Speed1 && clsVisualVars.parVisual.hmiSpeed1 != null)
          buEyeShotFunctions.hmiToBuButton(((buFile5) clsVisualVars.parVisual.hmiSpeed1).ButtonNormal, ((buFile5) clsVisualVars.parVisual.hmiSpeed1).ButtonOver, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpeed1).ButtonDown, ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpeed1).Parameters, control);
      }
    }
    return Controls;
  }

  public static buButton ColorButtonLinearFromOnOff(
    buButton refButton,
    bool State,
    hmiUISettings OnState,
    hmiUISettings OffState)
  {
    if (State)
    {
      refButton.Display = buControlDisplay.Copy(((buFile5) OnState).ButtonNormal, refButton.Display, 1.0, false);
      refButton.ButtonDownDisplay = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) OnState).ButtonDown, refButton.ButtonDownDisplay, 1.0, false);
      refButton.ButtonOverDisplay = buControlDisplay.Copy(((buFile5) OnState).ButtonOver, refButton.ButtonOverDisplay, 1.0, false);
    }
    else
    {
      refButton.Display = buControlDisplay.Copy(((buFile5) OffState).ButtonNormal, refButton.Display, 1.0, false);
      refButton.ButtonDownDisplay = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) OffState).ButtonDown, refButton.ButtonDownDisplay, 1.0, false);
      refButton.ButtonOverDisplay = buControlDisplay.Copy(((buFile5) OffState).ButtonOver, refButton.ButtonOverDisplay, 1.0, false);
    }
    return refButton;
  }

  public static buButton ColorButtonLinearFromOnOff(
    buButton refButton,
    bool State,
    hmiUIBasicSettings OnState,
    hmiUIBasicSettings OffState)
  {
    if (State)
    {
      refButton.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) OnState).Display, refButton.Display, 1.0, false);
      refButton.ButtonDownDisplay = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) OnState).Display, refButton.ButtonDownDisplay, 0.9, false);
      refButton.ButtonOverDisplay = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) OnState).Display, refButton.ButtonOverDisplay, 0.8, false);
    }
    else
    {
      refButton.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) OffState).Display, refButton.Display, 1.0, false);
      refButton.ButtonDownDisplay = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) OffState).Display, refButton.ButtonDownDisplay, 0.9, false);
      refButton.ButtonOverDisplay = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) OffState).Display, refButton.ButtonOverDisplay, 0.8, false);
    }
    return refButton;
  }

  public static buLabel ColorLabelLinearFromOnOff(
    buLabel refLabel,
    bool State,
    hmiUIBasicSettings OnState,
    hmiUIBasicSettings OffState)
  {
    if (State)
      refLabel.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) OnState).Display, refLabel.Display, 1.0, false);
    else
      refLabel.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) OffState).Display, refLabel.Display, 1.0, false);
    return refLabel;
  }

  public static void OpenApplicationVisualFile(string FileName)
  {
    FileInfo fileInfo = new FileInfo(FileName);
    if (!fileInfo.Exists)
      return;
    ArrayList StringList = new ArrayList();
    buVector5.OpenFromFile(fileInfo.FullName, ref StringList);
    List<string> CalcList1 = new List<string>();
    List<string> stringList = new List<string>();
    List<string> CalcList2 = new List<string>();
    buString.ListToSpecificList("<ApplicationCommonColors>", "</ApplicationCommonColors>", false, StringList, ref CalcList1);
    buString.ListToSpecificList("<ButtonControl>", "</ButtonControl>", false, CalcList1, ref CalcList2);
    if (CalcList2.Count > 0)
    {
      buEyeShotFunctions.DecodeHMI(CalcList2, "ButtonMenu1", clsVisualVars.parVisual.hmiButtonMenu1);
      buEyeShotFunctions.DecodeHMI(CalcList2, "ButtonMenu2", clsVisualVars.parVisual.hmiButtonMenu2);
      buEyeShotFunctions.DecodeHMI(CalcList2, "ButtonMenu3", clsVisualVars.parVisual.hmiButtonMenu3);
      buEyeShotFunctions.DecodeHMI(CalcList2, "ButtonMenu4", clsVisualVars.parVisual.hmiButtonMenu4);
      buEyeShotFunctions.DecodeHMI(CalcList2, "ButtonSystem1", clsVisualVars.parVisual.hmiButtonSystem1);
      buEyeShotFunctions.DecodeHMI(CalcList2, "ButtonSystem2", clsVisualVars.parVisual.hmiButtonSystem2);
      buEyeShotFunctions.DecodeHMI(CalcList2, "ButtonSystem3", clsVisualVars.parVisual.hmiButtonSystem3);
      buEyeShotFunctions.DecodeHMI(CalcList2, "ButtonSystem4", clsVisualVars.parVisual.hmiButtonSystem4);
      buEyeShotFunctions.DecodeHMI(CalcList2, "ButtonCommand1", clsVisualVars.parVisual.hmiButtonCommand1);
      buEyeShotFunctions.DecodeHMI(CalcList2, "ButtonCommand2", clsVisualVars.parVisual.hmiButtonCommand2);
      buEyeShotFunctions.DecodeHMI(CalcList2, "ButtonCommand3", clsVisualVars.parVisual.hmiButtonCommand3);
      buEyeShotFunctions.DecodeHMI(CalcList2, "ButtonCommand4", clsVisualVars.parVisual.hmiButtonCommand4);
      buEyeShotFunctions.DecodeHMI(CalcList2, "ButtonOk", clsVisualVars.parVisual.hmiButtonOk);
      buEyeShotFunctions.DecodeHMI(CalcList2, "ButtonCancel", clsVisualVars.parVisual.hmiButtonCancel);
    }
    CalcList2.Clear();
    buString.ListToSpecificList("<SpinControl>", "</SpinControl>", false, CalcList1, ref CalcList2);
    if (CalcList2.Count > 0)
    {
      buEyeShotFunctions.DecodeHMI(CalcList2, "SpinData1", clsVisualVars.parVisual.hmiSpin1);
      buEyeShotFunctions.DecodeHMI(CalcList2, "SpinData2", clsVisualVars.parVisual.hmiSpin2);
      buEyeShotFunctions.DecodeHMI(CalcList2, "SpinData3", clsVisualVars.parVisual.hmiSpin3);
      buEyeShotFunctions.DecodeHMI(CalcList2, "SpinData4", clsVisualVars.parVisual.hmiSpin4);
    }
    CalcList2.Clear();
    buString.ListToSpecificList("<TextControl>", "</TextControl>", false, CalcList1, ref CalcList2);
    if (CalcList2.Count > 0)
    {
      buEyeShotFunctions.DecodeHMI(CalcList2, "TextData1", clsVisualVars.parVisual.hmiText1);
      buEyeShotFunctions.DecodeHMI(CalcList2, "TextData2", clsVisualVars.parVisual.hmiText2);
      buEyeShotFunctions.DecodeHMI(CalcList2, "TextData3", clsVisualVars.parVisual.hmiText3);
      buEyeShotFunctions.DecodeHMI(CalcList2, "TextData4", clsVisualVars.parVisual.hmiText4);
    }
    CalcList2.Clear();
    buString.ListToSpecificList("<CheckControl>", "</CheckControl>", false, CalcList1, ref CalcList2);
    if (CalcList2.Count > 0)
    {
      buEyeShotFunctions.DecodeHMI(CalcList2, "Checkbox1", clsVisualVars.parVisual.hmiCheck1);
      buEyeShotFunctions.DecodeHMI(CalcList2, "Checkbox2", clsVisualVars.parVisual.hmiCheck2);
      buEyeShotFunctions.DecodeHMI(CalcList2, "Checkbox3", clsVisualVars.parVisual.hmiCheck3);
      buEyeShotFunctions.DecodeHMI(CalcList2, "Checkbox4", clsVisualVars.parVisual.hmiCheck4);
    }
    CalcList2.Clear();
    buString.ListToSpecificList("<LabelControl>", "</LabelControl>", false, CalcList1, ref CalcList2);
    if (CalcList2.Count > 0)
    {
      buEyeShotFunctions.DecodeHMI(CalcList2, "Labelbox1", clsVisualVars.parVisual.hmiLabel1);
      buEyeShotFunctions.DecodeHMI(CalcList2, "Labelbox2", clsVisualVars.parVisual.hmiLabel2);
      buEyeShotFunctions.DecodeHMI(CalcList2, "Labelbox3", clsVisualVars.parVisual.hmiLabel3);
      buEyeShotFunctions.DecodeHMI(CalcList2, "Labelbox4", clsVisualVars.parVisual.hmiLabel4);
    }
    CalcList2.Clear();
    buString.ListToSpecificList("<ListboxControl>", "</ListboxControl>", false, CalcList1, ref CalcList2);
    if (CalcList2.Count > 0)
    {
      buEyeShotFunctions.DecodeHMI(CalcList2, "Listbox1", clsVisualVars.parVisual.hmiListbox1);
      buEyeShotFunctions.DecodeHMI(CalcList2, "Listbox2", clsVisualVars.parVisual.hmiListbox2);
      buEyeShotFunctions.DecodeHMI(CalcList2, "Listbox3", clsVisualVars.parVisual.hmiListbox3);
      buEyeShotFunctions.DecodeHMI(CalcList2, "Listbox4", clsVisualVars.parVisual.hmiListbox4);
    }
    CalcList2.Clear();
    buString.ListToSpecificList("<DataGridViewControl>", "</DataGridViewControl>", false, CalcList1, ref CalcList2);
    if (CalcList2.Count > 0)
    {
      buSerilization.Decode(CalcList2, "DGV1", SerilizationMode.MultiLine, (object) clsVisualVars.parVisual.hmiDGV1);
      buSerilization.Decode(CalcList2, "DGV2", SerilizationMode.MultiLine, (object) clsVisualVars.parVisual.hmiDGV2);
    }
    CalcList2.Clear();
    buString.ListToSpecificList("<RadioButtonControl>", "</RadioButtonControl>", false, CalcList1, ref CalcList2);
    if (CalcList2.Count > 0)
    {
      buEyeShotFunctions.DecodeHMI(CalcList2, "RadioButton1", clsVisualVars.parVisual.hmiRadioButton1);
      buEyeShotFunctions.DecodeHMI(CalcList2, "RadioButton2", clsVisualVars.parVisual.hmiRadioButton2);
      buEyeShotFunctions.DecodeHMI(CalcList2, "RadioButton3", clsVisualVars.parVisual.hmiRadioButton3);
      buEyeShotFunctions.DecodeHMI(CalcList2, "RadioButton4", clsVisualVars.parVisual.hmiRadioButton4);
    }
    CalcList2.Clear();
    buString.ListToSpecificList("<TrackControl>", "</TrackControl>", false, CalcList1, ref CalcList2);
    if (CalcList2.Count > 0)
    {
      buEyeShotFunctions.DecodeHMI(CalcList2, "Track1", clsVisualVars.parVisual.hmiTrack1);
      buEyeShotFunctions.DecodeHMI(CalcList2, "Track2", clsVisualVars.parVisual.hmiTrack2);
    }
    CalcList2.Clear();
    buString.ListToSpecificList("<ProgressControl>", "</ProgressControl>", false, CalcList1, ref CalcList2);
    if (CalcList2.Count > 0)
    {
      buEyeShotFunctions.DecodeHMI(CalcList2, "Progress1", clsVisualVars.parVisual.hmiProgress1);
      buEyeShotFunctions.DecodeHMI(CalcList2, "Progress2", clsVisualVars.parVisual.hmiProgress2);
    }
    CalcList2.Clear();
    buString.ListToSpecificList("<ComboControl>", "</ComboControl>", false, CalcList1, ref CalcList2);
    if (CalcList2.Count > 0)
    {
      buEyeShotFunctions.DecodeHMI(CalcList2, "Combo1", clsVisualVars.parVisual.hmiCombo1);
      buEyeShotFunctions.DecodeHMI(CalcList2, "Combo2", clsVisualVars.parVisual.hmiCombo2);
      buEyeShotFunctions.DecodeHMI(CalcList2, "Combo3", clsVisualVars.parVisual.hmiCombo3);
      buEyeShotFunctions.DecodeHMI(CalcList2, "Combo4", clsVisualVars.parVisual.hmiCombo4);
    }
    CalcList2.Clear();
    buString.ListToSpecificList("<GroupControl>", "</GroupControl>", false, CalcList1, ref CalcList2);
    if (CalcList2.Count > 0)
    {
      buEyeShotFunctions.DecodeHMI(CalcList2, "Group1", clsVisualVars.parVisual.hmiGroup1);
      buEyeShotFunctions.DecodeHMI(CalcList2, "Group2", clsVisualVars.parVisual.hmiGroup2);
    }
    CalcList2.Clear();
    buString.ListToSpecificList("<GroundControl>", "</GroundControl>", false, CalcList1, ref CalcList2);
    if (CalcList2.Count > 0)
    {
      buEyeShotFunctions.DecodeHMI(CalcList2, "Ground1", clsVisualVars.parVisual.hmiGround1);
      buEyeShotFunctions.DecodeHMI(CalcList2, "Ground2", clsVisualVars.parVisual.hmiGround2);
    }
    CalcList2.Clear();
    buString.ListToSpecificList("<PanelControl>", "</PanelControl>", false, CalcList1, ref CalcList2);
    if (CalcList2.Count > 0)
    {
      buEyeShotFunctions.DecodeHMI(CalcList2, "Panel1", clsVisualVars.parVisual.hmiPanel1);
      buEyeShotFunctions.DecodeHMI(CalcList2, "Panel2", clsVisualVars.parVisual.hmiPanel2);
    }
    CalcList2.Clear();
    buString.ListToSpecificList("<SpeedControl>", "</SpeedControl>", false, CalcList1, ref CalcList2);
    if (CalcList2.Count > 0)
      buEyeShotFunctions.DecodeHMI(CalcList2, "Speed1", clsVisualVars.parVisual.hmiSpeed1);
    CalcList2.Clear();
    buString.ListToSpecificList("<SingleControl>", "</SingleControl>", false, CalcList1, ref CalcList2);
    if (CalcList2.Count > 0)
    {
      buEyeShotFunctions.DecodeHMI(CalcList2, "On1", clsVisualVars.parVisual.hmiOn1);
      buEyeShotFunctions.DecodeHMI(CalcList2, "Off1", clsVisualVars.parVisual.hmiOff1);
      buEyeShotFunctions.DecodeHMI(CalcList2, "On2", clsVisualVars.parVisual.hmiOn2);
      buEyeShotFunctions.DecodeHMI(CalcList2, "Off2", clsVisualVars.parVisual.hmiOff2);
      buEyeShotFunctions.DecodeHMI(CalcList2, "Warning", clsVisualVars.parVisual.hmiWarning);
      buEyeShotFunctions.DecodeHMI(CalcList2, "Error", clsVisualVars.parVisual.hmiError);
      buEyeShotFunctions.DecodeHMI(CalcList2, "Info", clsVisualVars.parVisual.hmiInfo);
      buEyeShotFunctions.DecodeHMI(CalcList2, "Status", clsVisualVars.parVisual.hmiStatus);
    }
    CalcList2.Clear();
    buString.ListToSpecificList("<Coordinate>", "</Coordinate>", false, CalcList1, ref CalcList2);
    if (CalcList2.Count > 0)
    {
      buEyeShotFunctions.DecodeHMI(CalcList2, "Coords1", clsVisualVars.parVisual.hmiCoords1);
      buEyeShotFunctions.DecodeHMI(CalcList2, "Coords2", clsVisualVars.parVisual.hmiCoords2);
    }
    StringList.Clear();
    CalcList1.Clear();
    stringList.Clear();
    CalcList2.Clear();
  }

  public static void SaveApplicationVisualFile(string FileName)
  {
    ArrayList StringList = new ArrayList();
    StringList.Add((object) "<ApplicationCommonColors>");
    StringList.Add((object) (new string(' ', 2) + "<ButtonControl>"));
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand1).Caption = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand1).Display = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand1).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand1).Shape = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand2).Caption = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand2).Display = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand2).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand2).Shape = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand3).Caption = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand3).Display = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand3).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand3).Shape = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand4).Caption = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand4).Display = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand4).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCommand4).Shape = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu1).Caption = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu1).Display = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu1).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu1).Shape = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu2).Caption = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu2).Display = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu2).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu2).Shape = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu3).Caption = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu3).Display = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu3).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu3).Shape = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu4).Caption = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu4).Display = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu4).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonMenu4).Shape = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem1).Caption = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem1).Display = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem1).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem1).Shape = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem2).Caption = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem2).Display = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem2).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem2).Shape = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem3).Caption = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem3).Display = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem3).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem3).Shape = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem4).Caption = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem4).Display = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem4).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonSystem4).Shape = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonOk).Caption = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonOk).Display = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonOk).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonOk).Shape = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCancel).Display = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCancel).Display = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCancel).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiButtonCancel).Shape = (buControlDisplay) null;
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiButtonMenu1).ToDefHMI("ButtonMenu1", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiButtonMenu2).ToDefHMI("ButtonMenu2", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiButtonMenu3).ToDefHMI("ButtonMenu3", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiButtonMenu4).ToDefHMI("ButtonMenu4", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiButtonSystem1).ToDefHMI("ButtonSystem1", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiButtonSystem2).ToDefHMI("ButtonSystem2", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiButtonSystem3).ToDefHMI("ButtonSystem3", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiButtonSystem4).ToDefHMI("ButtonSystem4", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiButtonCommand1).ToDefHMI("ButtonCommand1", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiButtonCommand2).ToDefHMI("ButtonCommand2", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiButtonCommand3).ToDefHMI("ButtonCommand3", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiButtonCommand4).ToDefHMI("ButtonCommand4", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiButtonOk).ToDefHMI("ButtonOk", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiButtonCancel).ToDefHMI("ButtonCancel", 4));
    StringList.Add((object) (new string(' ', 2) + "</ButtonControl>"));
    StringList.Add((object) "  <SpinControl>");
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin1).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin1).Shape = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin2).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin2).Shape = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin3).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin3).Shape = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin4).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiSpin4).Shape = (buControlDisplay) null;
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiSpin1).ToDefHMI("SpinData1", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiSpin2).ToDefHMI("SpinData2", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiSpin3).ToDefHMI("SpinData3", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiSpin4).ToDefHMI("SpinData4", 4));
    StringList.Add((object) "  </SpinControl>");
    StringList.Add((object) "  <TextControl>");
    ((buFile5) clsVisualVars.parVisual.hmiText1).ButtonNormal = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText1).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiText1).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText1).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText1).Shape = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiText2).ButtonNormal = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText2).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiText2).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText2).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText2).Shape = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiText3).ButtonNormal = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText3).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiText3).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText3).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText3).Shape = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiText4).ButtonNormal = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText4).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiText4).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText4).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiText4).Shape = (buControlDisplay) null;
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiText1).ToDefHMI("TextData1", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiText2).ToDefHMI("TextData2", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiText3).ToDefHMI("TextData3", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiText4).ToDefHMI("TextData4", 4));
    StringList.Add((object) "  </TextControl>");
    StringList.Add((object) "  <CheckControl>");
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck1).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiCheck1).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck1).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck1).Shape = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck2).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiCheck2).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck2).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck2).Shape = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck3).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiCheck3).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck3).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck3).Shape = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck4).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiCheck4).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck4).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCheck4).Shape = (buControlDisplay) null;
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiCheck1).ToDefHMI("Checkbox1", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiCheck2).ToDefHMI("Checkbox2", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiCheck3).ToDefHMI("Checkbox3", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiCheck4).ToDefHMI("Checkbox4", 4));
    StringList.Add((object) "  </CheckControl>");
    StringList.Add((object) "  <LabelControl>");
    ((buFile5) clsVisualVars.parVisual.hmiLabel1).ButtonNormal = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel1).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiLabel1).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel1).Caption = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel1).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel1).Shape = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiLabel2).ButtonNormal = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel2).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiLabel2).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel2).Caption = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel2).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel2).Shape = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiLabel3).ButtonNormal = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel3).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiLabel3).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel3).Caption = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel3).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel3).Shape = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiLabel4).ButtonNormal = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel4).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiLabel4).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel4).Caption = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel4).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiLabel4).Shape = (buControlDisplay) null;
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiLabel1).ToDefHMI("Labelbox1", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiLabel2).ToDefHMI("Labelbox2", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiLabel3).ToDefHMI("Labelbox3", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiLabel4).ToDefHMI("Labelbox4", 4));
    StringList.Add((object) "  </LabelControl>");
    StringList.Add((object) "  <ListboxControl>");
    ((buFile5) clsVisualVars.parVisual.hmiListbox1).ButtonNormal = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox1).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiListbox1).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox1).Caption = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox1).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox1).Shape = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiListbox2).ButtonNormal = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox2).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiListbox2).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox2).Caption = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox2).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox2).Shape = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiListbox3).ButtonNormal = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox3).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiListbox3).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox3).Caption = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox3).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox3).Shape = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiListbox4).ButtonNormal = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox4).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiListbox4).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox4).Caption = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox4).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiListbox4).Shape = (buControlDisplay) null;
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiListbox1).ToDefHMI("Listbox1", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiListbox2).ToDefHMI("Listbox2", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiListbox3).ToDefHMI("Listbox3", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiListbox4).ToDefHMI("Listbox4", 4));
    StringList.Add((object) "  </ListboxControl>");
    StringList.Add((object) "  <DataGridViewControl>");
    StringList.AddRange((ICollection) clsVisualVars.parVisual.hmiDGV1.ToDefAll("DGV1", 4, SerilizationMode.MultiLine));
    StringList.AddRange((ICollection) clsVisualVars.parVisual.hmiDGV2.ToDefAll("DGV2", 4, SerilizationMode.MultiLine));
    StringList.Add((object) "  </DataGridViewControl>");
    StringList.Add((object) "  <RadioButtonControl>");
    ((buFile5) clsVisualVars.parVisual.hmiRadioButton1).ButtonNormal = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton1).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiRadioButton1).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton1).Caption = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton1).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton1).Shape = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiRadioButton2).ButtonNormal = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton2).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiRadioButton2).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton2).Caption = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton2).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton2).Shape = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiRadioButton3).ButtonNormal = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton3).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiRadioButton3).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton3).Caption = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton3).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton3).Shape = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiRadioButton4).ButtonNormal = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton4).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiRadioButton4).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton4).Caption = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton4).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiRadioButton4).Shape = (buControlDisplay) null;
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiRadioButton1).ToDefHMI("RadioButton1", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiRadioButton2).ToDefHMI("RadioButton2", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiRadioButton3).ToDefHMI("RadioButton3", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiRadioButton4).ToDefHMI("RadioButton4", 4));
    StringList.Add((object) "  </RadioButtonControl>");
    StringList.Add((object) "  <TrackControl>");
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiTrack1).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiTrack1).ButtonNormal = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiTrack1).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiTrack2).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiTrack2).ButtonNormal = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiTrack2).ButtonOver = (buControlDisplay) null;
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiTrack1).ToDefHMI("Track1", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiTrack2).ToDefHMI("Track2", 4));
    StringList.Add((object) "  </TrackControl>");
    StringList.Add((object) "  <ProgressControl>");
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiProgress1).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiProgress1).ButtonNormal = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiProgress1).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiProgress2).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiProgress2).ButtonNormal = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiProgress2).ButtonOver = (buControlDisplay) null;
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiProgress1).ToDefHMI("Progress1", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiProgress2).ToDefHMI("Progress2", 4));
    StringList.Add((object) "  </ProgressControl>");
    StringList.Add((object) "  <ComboControl>");
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCombo1).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiCombo1).ButtonNormal = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiCombo1).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCombo1).Shape = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCombo1).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCombo2).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiCombo2).ButtonNormal = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiCombo2).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCombo2).Shape = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCombo2).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCombo3).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiCombo3).ButtonNormal = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiCombo3).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCombo3).Shape = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCombo3).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCombo4).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiCombo4).ButtonNormal = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiCombo4).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCombo4).Shape = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCombo4).Done = (buControlDisplay) null;
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiCombo1).ToDefHMI("Combo1", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiCombo2).ToDefHMI("Combo", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiCombo3).ToDefHMI("Combo1", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiCombo4).ToDefHMI("Combo", 4));
    StringList.Add((object) "  </ComboControl>");
    StringList.Add((object) "  <GroupControl>");
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiGroup1).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiGroup1).ButtonNormal = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiGroup1).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiGroup1).Shape = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiGroup1).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiGroup2).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiGroup2).ButtonNormal = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiGroup2).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiGroup2).Shape = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiGroup2).Done = (buControlDisplay) null;
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiGroup1).ToDefHMI("Group1", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiGroup2).ToDefHMI("Group2", 4));
    StringList.Add((object) "  </GroupControl>");
    StringList.Add((object) "  <PanelControl>");
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiPanel1).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiPanel1).ButtonNormal = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiPanel1).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiPanel1).Shape = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiPanel1).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiPanel2).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiPanel2).ButtonNormal = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiPanel2).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiPanel2).Shape = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiPanel2).Done = (buControlDisplay) null;
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiGroup1).ToDefHMI("Panel1", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiGroup2).ToDefHMI("Panel2", 4));
    StringList.Add((object) "  </PanelControl>");
    StringList.Add((object) "  <SpeedControl>");
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiSpeed1).ToDefHMI("Speed1", 4));
    StringList.Add((object) "  </SpeedControl>");
    StringList.Add((object) "  <GroundControl>");
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiGround1).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiGround1).ButtonNormal = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiGround1).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiGround1).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiGround2).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiGround2).ButtonNormal = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiGround2).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiGround2).Done = (buControlDisplay) null;
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiGround1).ToDefHMI("Ground1", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiGround2).ToDefHMI("Ground2", 4));
    StringList.Add((object) "  </GroundControl>");
    StringList.Add((object) "  <SingleControl>");
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiOn1).ToDefHMI("On1", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiOff1).ToDefHMI("Off1", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiOn2).ToDefHMI("On2", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiOff2).ToDefHMI("Off2", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiWarning).ToDefHMI("Warning", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiError).ToDefHMI("Error", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiInfo).ToDefHMI("Info", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiStatus).ToDefHMI("Status", 4));
    StringList.Add((object) "  </SingleControl>");
    StringList.Add((object) "  <Coordinate>");
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCoords1).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiCoords1).ButtonNormal = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiCoords1).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCoords1).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCoords1).Shape = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCoords2).ButtonDown = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiCoords2).ButtonNormal = (buControlDisplay) null;
    ((buFile5) clsVisualVars.parVisual.hmiCoords2).ButtonOver = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCoords2).Done = (buControlDisplay) null;
    ((buFile5.PLYToSchematic.\u0001) clsVisualVars.parVisual.hmiCoords2).Shape = (buControlDisplay) null;
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiCoords1).ToDefHMI("Coords1", 4));
    StringList.AddRange((ICollection) ((buEyeShotFunctions) clsVisualVars.parVisual.hmiCoords2).ToDefHMI("Coords2", 4));
    StringList.Add((object) "  </Coordinate>");
    StringList.Add((object) "</ApplicationCommonColors>");
    StringList.Add((object) "");
    buVector5.SaveToFile(StringList, FileName);
  }

  public buEyeShotFunctions()
    : this()
  {
  }

  public abstract void m000391();

  public buEyeShotFunctions()
  {
    ((buFile5) this).ButtonNormal = new buControlDisplay();
    ((buFile5) this).ButtonOver = new buControlDisplay();
    ((buFile5.PLYToSchematic.\u0001) this).ButtonDown = new buControlDisplay();
    ((buFile5.PLYToSchematic.\u0001) this).Display = new buControlDisplay();
    ((buFile5.PLYToSchematic.\u0001) this).Caption = new buControlDisplay();
    ((buFile5.PLYToSchematic.\u0001) this).Done = new buControlDisplay();
    ((buFile5.PLYToSchematic.\u0001) this).Shape = new buControlDisplay();
    ((buFile5.PLYToSchematic.\u0001) this).Parameters = (hmiUIPars) new buKinematic5();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buEyeShotFunctions(hmiUISettings data)
  {
    ((buFile5) this).ButtonNormal = new buControlDisplay();
    ((buFile5) this).ButtonOver = new buControlDisplay();
    ((buFile5.PLYToSchematic.\u0001) this).ButtonDown = new buControlDisplay();
    ((buFile5.PLYToSchematic.\u0001) this).Display = new buControlDisplay();
    ((buFile5.PLYToSchematic.\u0001) this).Caption = new buControlDisplay();
    ((buFile5.PLYToSchematic.\u0001) this).Done = new buControlDisplay();
    ((buFile5.PLYToSchematic.\u0001) this).Shape = new buControlDisplay();
    ((buFile5.PLYToSchematic.\u0001) this).Parameters = (hmiUIPars) new buKinematic5();
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

  public static hmiUISettings DecodeHMI(List<string> SL, string Title, hmiUISettings Obj)
  {
    List<string> CalcList = new List<string>();
    buString.ListToSpecificList($"<{Title}>", $"</{Title}>", false, SL, ref CalcList);
    buSerilization.DecodeProperty(CalcList, "_ButtonNormal", SerilizationMode.MultiLine, (object) ((buFile5) Obj).ButtonNormal);
    buSerilization.DecodeProperty(CalcList, "_ButtonOver", SerilizationMode.MultiLine, (object) ((buFile5) Obj).ButtonOver);
    buSerilization.DecodeProperty(CalcList, "_ButtonDown", SerilizationMode.MultiLine, (object) ((buFile5.PLYToSchematic.\u0001) Obj).ButtonDown);
    buSerilization.DecodeProperty(CalcList, "_Display", SerilizationMode.MultiLine, (object) ((buFile5.PLYToSchematic.\u0001) Obj).Display);
    buSerilization.DecodeProperty(CalcList, "_Caption", SerilizationMode.MultiLine, (object) ((buFile5.PLYToSchematic.\u0001) Obj).Caption);
    buSerilization.DecodeProperty(CalcList, "_Done", SerilizationMode.MultiLine, (object) ((buFile5.PLYToSchematic.\u0001) Obj).Done);
    buSerilization.DecodeProperty(CalcList, "_Shape", SerilizationMode.MultiLine, (object) ((buFile5.PLYToSchematic.\u0001) Obj).Shape);
    buSerilization.Decode(CalcList, "", SerilizationMode.MultiLine, (object) ((buFile5.PLYToSchematic.\u0001) Obj).Parameters);
    return Obj;
  }

  public ArrayList ToDefHMI(string Title, int Space)
  {
    ArrayList defHmi = new ArrayList();
    defHmi.Add((object) $"{new string(' ', Space)}<{Title}>");
    defHmi.Add((object) (new string(' ', Space + 2) + "<buControlDisplayVar>"));
    if (((buFile5) this).ButtonNormal != null)
      defHmi.AddRange((ICollection) ((buFile5) this).ButtonNormal.ToDefAll("_ButtonNormal", Space + 4, SerilizationMode.MultiLine));
    if (((buFile5) this).ButtonOver != null)
      defHmi.AddRange((ICollection) ((buFile5) this).ButtonOver.ToDefAll("_ButtonOver", Space + 4, SerilizationMode.MultiLine));
    if (((buFile5.PLYToSchematic.\u0001) this).ButtonDown != null)
      defHmi.AddRange((ICollection) ((buFile5.PLYToSchematic.\u0001) this).ButtonDown.ToDefAll("_ButtonDown", Space + 4, SerilizationMode.MultiLine));
    if (((buFile5.PLYToSchematic.\u0001) this).Display != null)
      defHmi.AddRange((ICollection) ((buFile5.PLYToSchematic.\u0001) this).Display.ToDefAll("_Display", Space + 4, SerilizationMode.MultiLine));
    if (((buFile5.PLYToSchematic.\u0001) this).Caption != null)
      defHmi.AddRange((ICollection) ((buFile5.PLYToSchematic.\u0001) this).Caption.ToDefAll("_Caption", Space + 4, SerilizationMode.MultiLine));
    if (((buFile5.PLYToSchematic.\u0001) this).Done != null)
      defHmi.AddRange((ICollection) ((buFile5.PLYToSchematic.\u0001) this).Done.ToDefAll("_Done", Space + 4, SerilizationMode.MultiLine));
    if (((buFile5.PLYToSchematic.\u0001) this).Shape != null)
      defHmi.AddRange((ICollection) ((buFile5.PLYToSchematic.\u0001) this).Shape.ToDefAll("_Shape", Space + 4, SerilizationMode.MultiLine));
    defHmi.AddRange((ICollection) ((buFile5.PLYToSchematic.\u0001) this).Parameters.ToDefAll("", Space + 4, SerilizationMode.MultiLine));
    defHmi.Add((object) (new string(' ', Space + 2) + "</buControlDisplayVar>"));
    defHmi.Add((object) $"{new string(' ', Space)}</{Title}>");
    return defHmi;
  }

  public override string ToString() => "";

  public abstract void m000397();

  public buEyeShotFunctions()
  {
    ((buFile5.PLYToSchematic.\u0001) this).Display = new buControlDisplay();
    ((buFile5.PLYToSchematic.\u0001) this).Parameters = (hmiUIBasicPars) new buKinematic5();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buEyeShotFunctions(hmiUIBasicSettings data)
  {
    ((buFile5.PLYToSchematic.\u0001) this).Display = new buControlDisplay();
    ((buFile5.PLYToSchematic.\u0001) this).Parameters = (hmiUIBasicPars) new buKinematic5();
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

  public static hmiUIBasicSettings DecodeHMI(List<string> SL, string Title, hmiUIBasicSettings Obj)
  {
    List<string> CalcList = new List<string>();
    buString.ListToSpecificList($"<{Title}>", $"</{Title}>", false, SL, ref CalcList);
    buSerilization.DecodeProperty(CalcList, "_Display", SerilizationMode.MultiLine, (object) ((buFile5.PLYToSchematic.\u0001) Obj).Display);
    buSerilization.Decode(CalcList, "", SerilizationMode.MultiLine, (object) ((buFile5.PLYToSchematic.\u0001) Obj).Parameters);
    return Obj;
  }

  public ArrayList ToDefHMI(string Title, int Space)
  {
    ArrayList defHmi = new ArrayList();
    defHmi.Add((object) $"{new string(' ', Space)}<{Title}>");
    defHmi.Add((object) (new string(' ', Space + 2) + "<buControlDisplayVar>"));
    if (((buFile5.PLYToSchematic.\u0001) this).Display != null)
      defHmi.AddRange((ICollection) ((buFile5.PLYToSchematic.\u0001) this).Display.ToDefAll("_Display", Space + 4, SerilizationMode.MultiLine));
    defHmi.AddRange((ICollection) ((buFile5.PLYToSchematic.\u0001) this).Parameters.ToDefAll("", Space + 4, SerilizationMode.MultiLine));
    defHmi.Add((object) (new string(' ', Space + 2) + "</buControlDisplayVar>"));
    defHmi.Add((object) $"{new string(' ', Space)}</{Title}>");
    return defHmi;
  }

  public abstract void m00039C();
}
