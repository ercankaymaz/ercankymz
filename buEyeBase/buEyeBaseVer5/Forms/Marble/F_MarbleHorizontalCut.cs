// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleHorizontalCut
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleHorizontalCut : Form
{
  internal NumericUpDown \u0002;
  internal Label \u0003;
  internal Panel \u0001;
  internal RadioButton \u0001;
  internal Panel \u0002;
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  internal Label \u0004;
  internal Panel \u0003;
  internal CheckBox \u0001;
  internal Label \u0005;
  internal Panel \u0004;
  internal CheckBox \u0002;
  internal Label \u0006;
  internal Panel \u0005;
  internal RadioButton \u0004;
  internal RadioButton \u0005;
  internal Label \u0007;
  internal Panel \u0006;
  internal Label \u0008;
  internal Label \u000E;
  internal NumericUpDown \u0003;
  internal Label \u000F;
  internal NumericUpDown \u0004;
  internal Label \u0010;
  internal NumericUpDown \u0005;
  internal CheckBox \u0003;
  internal Label \u0011;
  internal NumericUpDown \u0006;
  internal CheckBox \u0004;
  internal CheckBox \u0005;
  internal Label \u0012;
  internal NumericUpDown \u0007;
  internal Label \u0013;
  internal NumericUpDown \u0008;
  internal Label \u0014;
  internal NumericUpDown \u000E;
  internal CheckBox \u0006;
  internal Label \u0015;
  internal NumericUpDown \u000F;
  internal Label \u0016;
  internal NumericUpDown \u0010;
  internal CheckBox \u0007;
  internal Label \u0017;
  internal NumericUpDown \u0011;
  public static byte f002A60;
  public MarbleCountertopTypes CountertopType;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public marbleMenuType MenuType;
  public MarbleItemType ItemType;
  public MarbleContourMenuType ContourType;
  public Color clrLabel;
  public Color clrFormCaption;
  public Color clrFormBackUpper;
  public Color clrFormBackDown;
  public Color clrButtonDisplay;
  public Color clrButtonOver;
  public Color clrButtonDown;
  internal IContainer \u0001;
  public buButton btn_contourmenueditor;
  public buButton btn_contourmenufilelist;
  public buButton btn_contourmenufromfile;
  public buButton btn_close;
  internal buSeparator \u0001;
  internal buSeparator \u0002;
  internal ImageList \u0001;
  internal ImageList \u0002;
  public buButton btn_camsettings;
  public buButton btn_toolsettings;
  public buButton btn_strategy;
  public buButton btn_tool;

  public void StrategyMillingToImageIndex()
  {
    if (((MarbleMotionCommands) ((F_MarbleContourMenu) this).MenuType).selectedWireframeType == CamWireFrameType.CenterPath)
      ((F_MarbleSetAngle) this).btn_strategy.Image = ((F_MarbleSetAngle) this).\u0001.Images[0];
    if (((MarbleMotionCommands) ((F_MarbleContourMenu) this).MenuType).selectedWireframeType == CamWireFrameType.Chamfer2D)
      ((F_MarbleSetAngle) this).btn_strategy.Image = ((F_MarbleSetAngle) this).\u0001.Images[1];
    if (((MarbleMotionCommands) ((F_MarbleContourMenu) this).MenuType).selectedWireframeType == CamWireFrameType.Contour)
      ((F_MarbleSetAngle) this).btn_strategy.Image = ((F_MarbleSetAngle) this).\u0001.Images[6];
    if (((MarbleMotionCommands) ((F_MarbleContourMenu) this).MenuType).selectedWireframeType == CamWireFrameType.Engrave)
      ((F_MarbleSetAngle) this).btn_strategy.Image = ((F_MarbleSetAngle) this).\u0001.Images[3];
    if (((MarbleMotionCommands) ((F_MarbleContourMenu) this).MenuType).selectedWireframeType == CamWireFrameType.Face)
      ((F_MarbleSetAngle) this).btn_strategy.Image = ((F_MarbleSetAngle) this).\u0001.Images[4];
    if (((MarbleMotionCommands) ((F_MarbleContourMenu) this).MenuType).selectedWireframeType == CamWireFrameType.FloorFinish)
      ((F_MarbleSetAngle) this).btn_strategy.Image = ((F_MarbleSetAngle) this).\u0001.Images[5];
    if (((MarbleMotionCommands) ((F_MarbleContourMenu) this).MenuType).selectedWireframeType == CamWireFrameType.Pocket)
      ((F_MarbleSetAngle) this).btn_strategy.Image = ((F_MarbleSetAngle) this).\u0001.Images[7];
    if (((MarbleMotionCommands) ((F_MarbleContourMenu) this).MenuType).selectedWireframeType == CamWireFrameType.TextEngrave)
      ((F_MarbleSetAngle) this).btn_strategy.Image = ((F_MarbleSetAngle) this).\u0001.Images[8];
    if (((MarbleMotionCommands) ((F_MarbleContourMenu) this).MenuType).selectedWireframeType == CamWireFrameType.Trochoidal)
      ((F_MarbleSetAngle) this).btn_strategy.Image = ((F_MarbleSetAngle) this).\u0001.Images[9];
    ((F_MarbleSetAngle) this).btn_strategy.Text = $"{buLangTranslate.preDef.Cam} : {((MarbleMotionCommands) ((F_MarbleContourMenu) this).MenuType).selectedWireframeType.ToString()}";
  }

  public void StrategySawToImageIndex()
  {
    // ISSUE: unable to decompile the method.
  }

  public void StrategyWaterToImageIndex()
  {
    // ISSUE: unable to decompile the method.
  }
}
