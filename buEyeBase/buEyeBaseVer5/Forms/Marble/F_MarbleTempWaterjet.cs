// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleTempWaterjet
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleTempWaterjet : Form
{
  public buButton btn_advancesettings;
  public buSpin spn_sawcircularcutspeed;
  public buSpin spn_sawstraightcutfirststep;
  public buSpin spn_sawstraightcutfirstspeed;
  public buSpin spn_millingfirstcutstep;
  public buSpin spn_sawcircularcutfirststep;
  public buSpin spn_sawcircularcutfirstspeed;
  public buSpin spn_millingdrillspeed;
  public buSpin spn_millingheadfirstcutstep;

  public void StrategyMillingToImageIndex()
  {
    if (((MarbleMotionCommands) ((F_MarbleHorizontalCut) this).MenuType).selectedWireframeType == CamWireFrameType.CenterPath)
      ((F_MarbleHorizontalCut) this).btn_strategy.Image = ((F_MarbleHorizontalCut) this).\u0001.Images[0];
    if (((MarbleMotionCommands) ((F_MarbleHorizontalCut) this).MenuType).selectedWireframeType == CamWireFrameType.Chamfer2D)
      ((F_MarbleHorizontalCut) this).btn_strategy.Image = ((F_MarbleHorizontalCut) this).\u0001.Images[1];
    if (((MarbleMotionCommands) ((F_MarbleHorizontalCut) this).MenuType).selectedWireframeType == CamWireFrameType.Contour)
      ((F_MarbleHorizontalCut) this).btn_strategy.Image = ((F_MarbleHorizontalCut) this).\u0001.Images[6];
    if (((MarbleMotionCommands) ((F_MarbleHorizontalCut) this).MenuType).selectedWireframeType == CamWireFrameType.Engrave)
      ((F_MarbleHorizontalCut) this).btn_strategy.Image = ((F_MarbleHorizontalCut) this).\u0001.Images[3];
    if (((MarbleMotionCommands) ((F_MarbleHorizontalCut) this).MenuType).selectedWireframeType == CamWireFrameType.Face)
      ((F_MarbleHorizontalCut) this).btn_strategy.Image = ((F_MarbleHorizontalCut) this).\u0001.Images[4];
    if (((MarbleMotionCommands) ((F_MarbleHorizontalCut) this).MenuType).selectedWireframeType == CamWireFrameType.FloorFinish)
      ((F_MarbleHorizontalCut) this).btn_strategy.Image = ((F_MarbleHorizontalCut) this).\u0001.Images[5];
    if (((MarbleMotionCommands) ((F_MarbleHorizontalCut) this).MenuType).selectedWireframeType == CamWireFrameType.Pocket)
      ((F_MarbleHorizontalCut) this).btn_strategy.Image = ((F_MarbleHorizontalCut) this).\u0001.Images[7];
    if (((MarbleMotionCommands) ((F_MarbleHorizontalCut) this).MenuType).selectedWireframeType == CamWireFrameType.TextEngrave)
      ((F_MarbleHorizontalCut) this).btn_strategy.Image = ((F_MarbleHorizontalCut) this).\u0001.Images[8];
    if (((MarbleMotionCommands) ((F_MarbleHorizontalCut) this).MenuType).selectedWireframeType == CamWireFrameType.Trochoidal)
      ((F_MarbleHorizontalCut) this).btn_strategy.Image = ((F_MarbleHorizontalCut) this).\u0001.Images[9];
    ((F_MarbleHorizontalCut) this).btn_strategy.Text = $"{buLangTranslate.preDef.Cam} : {((MarbleMotionCommands) ((F_MarbleHorizontalCut) this).MenuType).selectedWireframeType.ToString()}";
  }

  public void StrategySawToImageIndex()
  {
    // ISSUE: unable to decompile the method.
  }
}
