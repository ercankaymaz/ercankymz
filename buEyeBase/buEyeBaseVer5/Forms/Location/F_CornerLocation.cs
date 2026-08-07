// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Location.F_CornerLocation
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls;
using buControls.Controls;
using buCore;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Forms.Marble;
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Location;

public class F_CornerLocation : Form
{
  public buSpin spn_flatlandrapiddis;
  public buSpin spn_flatlandplungevel;
  public buSpin spn_flatlandcuttingvel;
  internal buLabel \u0005;
  public buSpin spn_pencilsafedis;
  public buSpin spn_pencilrapiddis;
  public buSpin spn_pencilplungevel;
  public buSpin spn_pencilcuttingvel;
  public buSpin spn_roughtoolpersentage;
  public buSpin spn_finishtoolpersentage;
  public buSpin spn_flatlandtoolpersentage;
  internal buLabel \u0006;
  internal buLabel \u0007;
  public buCheckBox chk_spiral;
  public buCheckBox chk_zigzag;
  public buCheckBox chk_oneway;
  public buCheckBox chk_level;
  public buCheckBox chk_region;
  internal buLabel \u0008;
  public buCheckBox chk_silhouettepartend;
  public buCheckBox chk_silhouettepart;
  public buCheckBox chk_silhouettenone;
  public buCheckBox chk_silhouettetoolcontact;

  public void LoadLanguage()
  {
    try
    {
      if (F_MarbleSawContourSettings.Captions.Count <= 14)
        return;
      ((F_MarbleProfileSettings) this).\u0001.Text = F_MarbleSawContourSettings.Captions[0];
      ((F_MarbleProfileSettings) this).spn_fwdvel.Caption.Caption = F_MarbleSawContourSettings.Captions[1];
      ((F_MarbleProfileSettings) this).spn_bwdvel.Caption.Caption = F_MarbleSawContourSettings.Captions[2];
      ((F_MarbleProfileSettings) this).spn_plungevel.Caption.Caption = F_MarbleSawContourSettings.Captions[5];
      ((F_MarbleProfileSettings) this).spn_leavevel.Caption.Caption = F_MarbleSawContourSettings.Captions[6];
      ((F_MarbleProfileSettings) this).spn_forwardcutstep.Caption.Caption = F_MarbleSawContourSettings.Captions[7];
      ((F_MarbleProfileSettings) this).spn_backwardcutstep.Caption.Caption = F_MarbleSawContourSettings.Captions[8];
      ((F_MarbleProfileSettings) this).spn_matthickness.Caption.Caption = F_MarbleSawContourSettings.Captions[9];
      ((F_MarbleProfileSettings) this).spn_safedistance.Caption.Caption = F_MarbleSawContourSettings.Captions[10];
      ((F_MarbleProfileSettings) this).cmb_cutdir.Caption.Caption = F_MarbleSawContourSettings.Captions[12];
      ((F_MarbleProfileSettings) this).\u0002.Text = F_MarbleSawContourSettings.Captions[13];
      ((F_MarbleProfileSettings) this).\u0003.Text = F_MarbleSawContourSettings.Captions[14];
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleSawContourSettings) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleSawContourSettings) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleSawContourSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleSawContourSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] KeyEventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!(obj1.KeyCode == Keys.Return | obj1.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKey(((F_MarbleProfileSettings) this).\u0001.Controls, result, obj1.Shift);
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      if (!AppBool.TouchPad)
        return;
      buSpin buSpin = new buSpin();
      buControlCommands.ShowKeyPad((Form) this, (Control) obj0);
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((marbleEdgeItem) ((MarbleMachineSimultionSettings) ((F_MarbleSawContourSettings) this).Settings).settingMarbleCam).SawBackwardCuttingVelocity = ((F_MarbleProfileSettings) this).spn_bwdvel.Value;
    ((marbleEdgeItem) ((MarbleMachineSimultionSettings) ((F_MarbleSawContourSettings) this).Settings).settingMarbleCam).SawForwardCuttingVelocity = ((F_MarbleProfileSettings) this).spn_fwdvel.Value;
    ((marbleCollapseItem) ((MarbleMachineSimultionSettings) ((F_MarbleSawContourSettings) this).Settings).settingMarbleCam).SawPlungeVelocity = ((F_MarbleProfileSettings) this).spn_plungevel.Value;
    ((MarbleCamType) ((MarbleMachineSimultionSettings) ((F_MarbleSawContourSettings) this).Settings).MaterialParameter).MaterialThickness = ((F_MarbleProfileSettings) this).spn_matthickness.Value;
    ((marbleEdgeItem) ((MarbleMachineSimultionSettings) ((F_MarbleSawContourSettings) this).Settings).settingMarbleCam).SawForwardStepDownDistance = ((F_MarbleProfileSettings) this).spn_forwardcutstep.Value;
    ((marbleEdgeItem) ((MarbleMachineSimultionSettings) ((F_MarbleSawContourSettings) this).Settings).settingMarbleCam).SawBackwardStepDownDistance = ((F_MarbleProfileSettings) this).spn_backwardcutstep.Value;
    ((marbleCollapseItem) ((MarbleMachineSimultionSettings) ((F_MarbleSawContourSettings) this).Settings).settingMarbleCam).SawSafeDistance = ((F_MarbleProfileSettings) this).spn_safedistance.Value;
    ((marbleSlatPars) ((MarbleMachineSimultionSettings) ((F_MarbleSawContourSettings) this).Settings).settingMarbleCam).CuttingDirection = (CamCuttingDirectionType) buGeneral.EnumValueFromInt((object) ((marbleSlatPars) ((MarbleMachineSimultionSettings) ((F_MarbleSawContourSettings) this).Settings).settingMarbleCam).CuttingDirection, ((F_MarbleProfileSettings) this).cmb_cutdir.SelectedIndex);
    ((F_MarbleSawContourSettings) this).PropertiesForm.Result = DialogResult.OK;
    if (((F_MarbleSawContourSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleSawContourSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }
}
