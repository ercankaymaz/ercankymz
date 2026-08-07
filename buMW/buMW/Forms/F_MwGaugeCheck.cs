// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwGaugeCheck
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMW.Forms;

public class F_MwGaugeCheck : Form
{
  public Button btn_cancel;
  public Button btn_ok;
  internal CheckBox \u0007;
  public FormProperties Properties = new FormProperties();
  public MachiningParams Par = new MachiningParams(Unit.Metric);
  internal IContainer \u0001 = (IContainer) null;
  internal PictureBox \u0001;
  internal PictureBox \u0002;
  internal PictureBox \u0003;
  internal PictureBox \u0004;
  internal PictureBox \u0005;
  internal PictureBox \u0006;
  internal PictureBox \u0007;
  internal PictureBox \u0008;
  internal PictureBox \u000E;
  internal PictureBox \u000F;
  internal PictureBox \u0010;
  internal PictureBox \u0011;
  internal PictureBox \u0012;
  internal PictureBox \u0013;
  internal PictureBox \u0014;
  internal PictureBox \u0015;
  internal Panel \u0001;
  internal PictureBox \u0016;
  internal PictureBox \u0017;
  internal System.Windows.Forms.Label \u0001;
  internal CheckBox \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal System.Windows.Forms.Label \u0003;
  internal System.Windows.Forms.Label \u0004;
  internal System.Windows.Forms.Label \u0005;
  internal System.Windows.Forms.Label \u0006;
  internal CheckBox \u0002;
  internal CheckBox \u0003;
  internal CheckBox \u0004;
  internal CheckBox \u0005;
  public ComboBox combo_move1;
  public ComboBox combo_action1;
  internal Panel \u0002;
  internal CheckBox \u0006;
  internal CheckBox \u0007;
  internal PictureBox \u0018;
  internal Panel \u0003;
  internal Panel \u0004;
  internal PictureBox \u0019;
  internal System.Windows.Forms.Label \u0007;
  internal Button \u0001;
  internal System.Windows.Forms.Label \u0008;
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u000E;
  internal NumericUpDown \u0002;
  internal System.Windows.Forms.Label \u000F;
  internal System.Windows.Forms.Label \u0010;
  internal System.Windows.Forms.Label \u0011;
  internal Panel \u0005;
  internal Panel \u0006;
  internal System.Windows.Forms.Label \u0012;
  internal NumericUpDown \u0003;
  internal System.Windows.Forms.Label \u0013;
  internal CheckBox \u0008;
  internal NumericUpDown \u0004;
  internal CheckBox \u000E;
  internal PictureBox \u001A;
  internal Panel \u0007;
  internal CheckBox \u000F;
  internal System.Windows.Forms.Label \u0014;
  internal CheckBox \u0010;
  internal System.Windows.Forms.Label \u0015;
  internal CheckBox \u0011;
  internal System.Windows.Forms.Label \u0016;
  internal CheckBox \u0012;
  internal System.Windows.Forms.Label \u0017;
  internal Panel \u0008;
  internal PictureBox \u001B;
  internal Button \u0002;
  public ComboBox combo_action2;
  public ComboBox combo_move2;
  internal PictureBox \u001C;
  internal PictureBox \u001D;
  internal System.Windows.Forms.Label \u0018;
  internal CheckBox \u0013;
  internal System.Windows.Forms.Label \u0019;
  internal Panel \u000E;
  internal Panel \u000F;
  internal System.Windows.Forms.Label \u001A;
  internal NumericUpDown \u0005;
  internal System.Windows.Forms.Label \u001B;
  internal CheckBox \u0014;
  internal NumericUpDown \u0006;
  internal CheckBox \u0015;
  internal PictureBox \u001E;
  internal Panel \u0010;
  internal PictureBox \u001F;
  internal CheckBox \u0016;
  internal PictureBox \u007F;
  internal System.Windows.Forms.Label \u001C;
  internal PictureBox \u0080;
  internal CheckBox \u0017;
  internal PictureBox \u0081;
  internal PictureBox \u0082;
  internal System.Windows.Forms.Label \u001D;
  internal PictureBox \u0083;
  internal CheckBox \u0018;
  internal PictureBox \u0084;
  internal System.Windows.Forms.Label \u001E;
  internal CheckBox \u0019;
  internal PictureBox \u0086;
  internal System.Windows.Forms.Label \u001F;
  internal Panel \u0011;
  internal PictureBox \u0087;
  internal Button \u0003;
  public ComboBox combo_action4;
  public ComboBox combo_move4;
  internal PictureBox \u0088;
  internal PictureBox \u0089;
  internal System.Windows.Forms.Label \u007F;
  internal CheckBox \u001A;
  internal System.Windows.Forms.Label \u0080;
  internal Panel \u0012;
  internal Panel \u0013;
  internal System.Windows.Forms.Label \u0081;
  internal NumericUpDown \u0007;
  internal System.Windows.Forms.Label \u0082;
  internal CheckBox \u001B;
  internal NumericUpDown \u0008;
  internal CheckBox \u001C;
  internal PictureBox \u008A;
  internal Panel \u0014;
  internal CheckBox \u001D;
  internal System.Windows.Forms.Label \u0083;
  internal CheckBox \u001E;
  internal System.Windows.Forms.Label \u0084;
  internal CheckBox \u001F;
  internal System.Windows.Forms.Label \u0086;
  internal CheckBox \u007F;
  internal System.Windows.Forms.Label \u0087;
  internal PictureBox \u008B;
  internal PictureBox \u008C;
  internal PictureBox \u008D;
  internal PictureBox \u008E;
  internal PictureBox \u008F;
  internal PictureBox \u0090;
  internal PictureBox \u0091;
  internal PictureBox \u0092;
  internal Panel \u0015;
  internal PictureBox \u0093;
  internal Button \u0004;
  public ComboBox combo_action3;
  public ComboBox combo_move3;
  internal PictureBox \u0094;
  internal PictureBox \u0095;
  internal System.Windows.Forms.Label \u0088;
  internal CheckBox \u0080;
  internal System.Windows.Forms.Label \u0089;
  internal Button \u0005;
  internal Button \u0006;
  internal Button \u0007;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  public ComboBox combo_relink1;
  public ComboBox combo_relink2;
  public ComboBox combo_relink4;
  public ComboBox combo_relink3;
  internal Button \u0008;

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_MwGaugeItemAdvanced) this).Properties.Inited)
      return;
    ((F_MwGaugeItemAdvanced) this).Properties.Inited = false;
    ((F_MwGaugeItemAdvanced) this).Apply();
    ((F_MwGaugeItemAdvanced) this).UpdateControlFromType();
    ((F_MwGaugeItemAdvanced) this).Properties.Inited = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MwGaugeItemAdvanced) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MwGaugeItemAdvanced) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MwGaugeCheck() => F_MwTriMUpDownAdvanced.\u0001(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.\u0007.Checked = this.Par.CollControl.CollCtrlOperations[0].CheckMachiningSurfaces;
    this.\u0006.Checked = this.Par.CollControl.CollCtrlOperations[0].CheckSurfaces;
    this.\u0001.Value = (Decimal) this.Par.CollControl.CollCtrlOperations[0].CheckSurfTolerance;
    this.\u0002.Value = (Decimal) this.Par.CollControl.CollCtrlOperations[0].StockToLeave;
    this.\u0002.Checked = this.Par.CollControl.CollCtrlOperations[0].CheckHolder;
    this.\u0003.Checked = this.Par.CollControl.CollCtrlOperations[0].CheckArbor;
    this.\u0005.Checked = this.Par.CollControl.CollCtrlOperations[0].CheckToolTip;
    this.\u0004.Checked = this.Par.CollControl.CollCtrlOperations[0].CheckToolShaft;
    this.\u0001.Checked = this.Par.CollControl.CollCtrlOperations[0].Status;
    if (this.Par.CollControl.CollCtrlOperations[0].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromContactLine)
      this.combo_move1.SelectedIndex = 0;
    else if (this.Par.CollControl.CollCtrlOperations[0].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZ)
      this.combo_relink1.SelectedIndex = 1;
    else if (this.Par.CollControl.CollCtrlOperations[0].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXy)
      this.combo_relink1.SelectedIndex = 2;
    else if (this.Par.CollControl.CollCtrlOperations[0].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXz)
      this.combo_relink1.SelectedIndex = 3;
    else if (this.Par.CollControl.CollCtrlOperations[0].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYz)
      this.combo_relink1.SelectedIndex = 4;
    else if (this.Par.CollControl.CollCtrlOperations[0].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZMin)
      this.combo_relink1.SelectedIndex = 5;
    else if (this.Par.CollControl.CollCtrlOperations[0].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInX)
      this.combo_relink1.SelectedIndex = 6;
    else if (this.Par.CollControl.CollCtrlOperations[0].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXMin)
      this.combo_relink1.SelectedIndex = 7;
    else if (this.Par.CollControl.CollCtrlOperations[0].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInY)
      this.combo_relink1.SelectedIndex = 8;
    else if (this.Par.CollControl.CollCtrlOperations[0].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYMin)
      this.combo_relink1.SelectedIndex = 9;
    else if (this.Par.CollControl.CollCtrlOperations[0].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongSurfNorm)
      this.combo_relink1.SelectedIndex = 10;
    else if (this.Par.CollControl.CollCtrlOperations[0].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromOrigin)
      this.combo_relink1.SelectedIndex = 11;
    else if (this.Par.CollControl.CollCtrlOperations[0].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractMoveToCenterOfCont)
      this.combo_relink1.SelectedIndex = 12;
    else if (this.Par.CollControl.CollCtrlOperations[0].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXy)
      this.combo_relink1.SelectedIndex = 13;
    else if (this.Par.CollControl.CollCtrlOperations[0].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXz)
      this.combo_relink1.SelectedIndex = 14;
    else if (this.Par.CollControl.CollCtrlOperations[0].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInYz)
      this.combo_relink1.SelectedIndex = 15;
    else if (this.Par.CollControl.CollCtrlOperations[0].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInCustomDir)
      this.combo_relink1.SelectedIndex = 16 /*0x10*/;
    else if (this.Par.CollControl.CollCtrlOperations[0].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolContactLine)
      this.combo_relink1.SelectedIndex = 17;
    else if (this.Par.CollControl.CollCtrlOperations[0].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolBottomPlane)
      this.combo_relink1.SelectedIndex = 18;
    else
      this.combo_relink1.SelectedIndex = 0;
    if (this.Par.CollControl.CollCtrlOperations[0].CollLeaveOutPntsType == CollCtrlOpParamsCollLeaveOutPointsType.LopDontTrimTp)
      this.combo_relink1.SelectedIndex = 0;
    else if (this.Par.CollControl.CollCtrlOperations[0].CollLeaveOutPntsType == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterFirstCol)
      this.combo_relink1.SelectedIndex = 1;
    else if (this.Par.CollControl.CollCtrlOperations[0].CollLeaveOutPntsType == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeLastCol)
      this.combo_relink1.SelectedIndex = 2;
    else if (this.Par.CollControl.CollCtrlOperations[0].CollLeaveOutPntsType == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBetwFirstAndLastCol)
      this.combo_relink1.SelectedIndex = 3;
    else if (this.Par.CollControl.CollCtrlOperations[0].CollLeaveOutPntsType == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeFirstCol)
      this.combo_relink1.SelectedIndex = 4;
    else if (this.Par.CollControl.CollCtrlOperations[0].CollLeaveOutPntsType == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterLastCol)
      this.combo_relink1.SelectedIndex = 5;
    else
      this.combo_relink1.SelectedIndex = 0;
    if (this.Par.CollControl.CollCtrlOperations[0].Strategy == CollCtrlOpBaseParamsCollStrategy.CsMoveToolAlongVector)
      this.combo_action1.SelectedIndex = 0;
    else if (this.Par.CollControl.CollCtrlOperations[0].Strategy == CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPoints)
      this.combo_action1.SelectedIndex = 1;
    else if (this.Par.CollControl.CollCtrlOperations[0].Strategy == CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPlanes)
      this.combo_action1.SelectedIndex = 2;
    else if (this.Par.CollControl.CollCtrlOperations[0].Strategy == CollCtrlOpBaseParamsCollStrategy.CsReportCollisions)
      this.combo_action1.SelectedIndex = 3;
    else
      this.combo_action1.SelectedIndex = 0;
    this.\u000E.Checked = this.Par.CollControl.CollCtrlOperations[1].CheckMachiningSurfaces;
    this.\u0008.Checked = this.Par.CollControl.CollCtrlOperations[1].CheckSurfaces;
    this.\u0003.Value = (Decimal) this.Par.CollControl.CollCtrlOperations[1].CheckSurfTolerance;
    this.\u0004.Value = (Decimal) this.Par.CollControl.CollCtrlOperations[1].StockToLeave;
    this.\u0012.Checked = this.Par.CollControl.CollCtrlOperations[1].CheckHolder;
    this.\u0011.Checked = this.Par.CollControl.CollCtrlOperations[1].CheckArbor;
    this.\u000F.Checked = this.Par.CollControl.CollCtrlOperations[1].CheckToolTip;
    this.\u0010.Checked = this.Par.CollControl.CollCtrlOperations[1].CheckToolShaft;
    this.\u0013.Checked = this.Par.CollControl.CollCtrlOperations[1].Status;
    if (this.Par.CollControl.CollCtrlOperations[1].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromContactLine)
      this.combo_move2.SelectedIndex = 0;
    else if (this.Par.CollControl.CollCtrlOperations[1].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZ)
      this.combo_relink2.SelectedIndex = 1;
    else if (this.Par.CollControl.CollCtrlOperations[1].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXy)
      this.combo_relink2.SelectedIndex = 2;
    else if (this.Par.CollControl.CollCtrlOperations[1].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXz)
      this.combo_relink2.SelectedIndex = 3;
    else if (this.Par.CollControl.CollCtrlOperations[1].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYz)
      this.combo_relink2.SelectedIndex = 4;
    else if (this.Par.CollControl.CollCtrlOperations[1].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZMin)
      this.combo_relink2.SelectedIndex = 5;
    else if (this.Par.CollControl.CollCtrlOperations[1].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInX)
      this.combo_relink2.SelectedIndex = 6;
    else if (this.Par.CollControl.CollCtrlOperations[1].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXMin)
      this.combo_relink2.SelectedIndex = 7;
    else if (this.Par.CollControl.CollCtrlOperations[1].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInY)
      this.combo_relink2.SelectedIndex = 8;
    else if (this.Par.CollControl.CollCtrlOperations[1].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYMin)
      this.combo_relink2.SelectedIndex = 9;
    else if (this.Par.CollControl.CollCtrlOperations[1].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongSurfNorm)
      this.combo_relink2.SelectedIndex = 10;
    else if (this.Par.CollControl.CollCtrlOperations[1].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromOrigin)
      this.combo_relink2.SelectedIndex = 11;
    else if (this.Par.CollControl.CollCtrlOperations[1].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractMoveToCenterOfCont)
      this.combo_relink2.SelectedIndex = 12;
    else if (this.Par.CollControl.CollCtrlOperations[1].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXy)
      this.combo_relink2.SelectedIndex = 13;
    else if (this.Par.CollControl.CollCtrlOperations[1].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXz)
      this.combo_relink2.SelectedIndex = 14;
    else if (this.Par.CollControl.CollCtrlOperations[1].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInYz)
      this.combo_relink2.SelectedIndex = 15;
    else if (this.Par.CollControl.CollCtrlOperations[1].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInCustomDir)
      this.combo_relink2.SelectedIndex = 16 /*0x10*/;
    else if (this.Par.CollControl.CollCtrlOperations[1].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolContactLine)
      this.combo_relink2.SelectedIndex = 17;
    else if (this.Par.CollControl.CollCtrlOperations[1].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolBottomPlane)
      this.combo_relink2.SelectedIndex = 18;
    else
      this.combo_relink2.SelectedIndex = 0;
    if (this.Par.CollControl.CollCtrlOperations[1].CollLeaveOutPntsType == CollCtrlOpParamsCollLeaveOutPointsType.LopDontTrimTp)
      this.combo_relink2.SelectedIndex = 0;
    else if (this.Par.CollControl.CollCtrlOperations[1].CollLeaveOutPntsType == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterFirstCol)
      this.combo_relink2.SelectedIndex = 1;
    else if (this.Par.CollControl.CollCtrlOperations[1].CollLeaveOutPntsType == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeLastCol)
      this.combo_relink2.SelectedIndex = 2;
    else if (this.Par.CollControl.CollCtrlOperations[1].CollLeaveOutPntsType == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBetwFirstAndLastCol)
      this.combo_relink2.SelectedIndex = 3;
    else if (this.Par.CollControl.CollCtrlOperations[1].CollLeaveOutPntsType == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeFirstCol)
      this.combo_relink2.SelectedIndex = 4;
    else if (this.Par.CollControl.CollCtrlOperations[1].CollLeaveOutPntsType == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterLastCol)
      this.combo_relink2.SelectedIndex = 5;
    else
      this.combo_relink2.SelectedIndex = 0;
    if (this.Par.CollControl.CollCtrlOperations[1].Strategy == CollCtrlOpBaseParamsCollStrategy.CsMoveToolAlongVector)
      this.combo_action2.SelectedIndex = 0;
    else if (this.Par.CollControl.CollCtrlOperations[1].Strategy == CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPoints)
      this.combo_action2.SelectedIndex = 1;
    else if (this.Par.CollControl.CollCtrlOperations[1].Strategy == CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPlanes)
      this.combo_action2.SelectedIndex = 2;
    else if (this.Par.CollControl.CollCtrlOperations[1].Strategy == CollCtrlOpBaseParamsCollStrategy.CsReportCollisions)
      this.combo_action2.SelectedIndex = 3;
    else
      this.combo_action2.SelectedIndex = 0;
    this.\u001C.Checked = this.Par.CollControl.CollCtrlOperations[2].CheckMachiningSurfaces;
    this.\u001B.Checked = this.Par.CollControl.CollCtrlOperations[2].CheckSurfaces;
    this.\u0007.Value = (Decimal) this.Par.CollControl.CollCtrlOperations[2].CheckSurfTolerance;
    this.\u0008.Value = (Decimal) this.Par.CollControl.CollCtrlOperations[2].StockToLeave;
    this.\u007F.Checked = this.Par.CollControl.CollCtrlOperations[2].CheckHolder;
    this.\u001F.Checked = this.Par.CollControl.CollCtrlOperations[2].CheckArbor;
    this.\u001D.Checked = this.Par.CollControl.CollCtrlOperations[2].CheckToolTip;
    this.\u001E.Checked = this.Par.CollControl.CollCtrlOperations[2].CheckToolShaft;
    this.\u0080.Checked = this.Par.CollControl.CollCtrlOperations[2].Status;
    if (this.Par.CollControl.CollCtrlOperations[2].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromContactLine)
      this.combo_move3.SelectedIndex = 0;
    else if (this.Par.CollControl.CollCtrlOperations[2].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZ)
      this.combo_relink3.SelectedIndex = 1;
    else if (this.Par.CollControl.CollCtrlOperations[2].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXy)
      this.combo_relink3.SelectedIndex = 2;
    else if (this.Par.CollControl.CollCtrlOperations[2].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXz)
      this.combo_relink3.SelectedIndex = 3;
    else if (this.Par.CollControl.CollCtrlOperations[2].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYz)
      this.combo_relink3.SelectedIndex = 4;
    else if (this.Par.CollControl.CollCtrlOperations[2].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZMin)
      this.combo_relink3.SelectedIndex = 5;
    else if (this.Par.CollControl.CollCtrlOperations[2].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInX)
      this.combo_relink3.SelectedIndex = 6;
    else if (this.Par.CollControl.CollCtrlOperations[2].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXMin)
      this.combo_relink3.SelectedIndex = 7;
    else if (this.Par.CollControl.CollCtrlOperations[2].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInY)
      this.combo_relink3.SelectedIndex = 8;
    else if (this.Par.CollControl.CollCtrlOperations[2].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYMin)
      this.combo_relink3.SelectedIndex = 9;
    else if (this.Par.CollControl.CollCtrlOperations[2].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongSurfNorm)
      this.combo_relink3.SelectedIndex = 10;
    else if (this.Par.CollControl.CollCtrlOperations[2].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromOrigin)
      this.combo_relink3.SelectedIndex = 11;
    else if (this.Par.CollControl.CollCtrlOperations[2].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractMoveToCenterOfCont)
      this.combo_relink3.SelectedIndex = 12;
    else if (this.Par.CollControl.CollCtrlOperations[2].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXy)
      this.combo_relink3.SelectedIndex = 13;
    else if (this.Par.CollControl.CollCtrlOperations[2].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXz)
      this.combo_relink3.SelectedIndex = 14;
    else if (this.Par.CollControl.CollCtrlOperations[2].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInYz)
      this.combo_relink3.SelectedIndex = 15;
    else if (this.Par.CollControl.CollCtrlOperations[2].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInCustomDir)
      this.combo_relink3.SelectedIndex = 16 /*0x10*/;
    else if (this.Par.CollControl.CollCtrlOperations[2].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolContactLine)
      this.combo_relink3.SelectedIndex = 17;
    else if (this.Par.CollControl.CollCtrlOperations[2].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolBottomPlane)
      this.combo_relink3.SelectedIndex = 18;
    else
      this.combo_relink3.SelectedIndex = 0;
    if (this.Par.CollControl.CollCtrlOperations[2].CollLeaveOutPntsType == CollCtrlOpParamsCollLeaveOutPointsType.LopDontTrimTp)
      this.combo_relink3.SelectedIndex = 0;
    else if (this.Par.CollControl.CollCtrlOperations[2].CollLeaveOutPntsType == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterFirstCol)
      this.combo_relink3.SelectedIndex = 1;
    else if (this.Par.CollControl.CollCtrlOperations[2].CollLeaveOutPntsType == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeLastCol)
      this.combo_relink3.SelectedIndex = 2;
    else if (this.Par.CollControl.CollCtrlOperations[2].CollLeaveOutPntsType == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBetwFirstAndLastCol)
      this.combo_relink3.SelectedIndex = 3;
    else if (this.Par.CollControl.CollCtrlOperations[2].CollLeaveOutPntsType == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeFirstCol)
      this.combo_relink3.SelectedIndex = 4;
    else if (this.Par.CollControl.CollCtrlOperations[2].CollLeaveOutPntsType == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterLastCol)
      this.combo_relink3.SelectedIndex = 5;
    else
      this.combo_relink3.SelectedIndex = 0;
    if (this.Par.CollControl.CollCtrlOperations[2].Strategy == CollCtrlOpBaseParamsCollStrategy.CsMoveToolAlongVector)
      this.combo_action3.SelectedIndex = 0;
    else if (this.Par.CollControl.CollCtrlOperations[2].Strategy == CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPoints)
      this.combo_action3.SelectedIndex = 1;
    else if (this.Par.CollControl.CollCtrlOperations[2].Strategy == CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPlanes)
      this.combo_action3.SelectedIndex = 2;
    else if (this.Par.CollControl.CollCtrlOperations[2].Strategy == CollCtrlOpBaseParamsCollStrategy.CsReportCollisions)
      this.combo_action3.SelectedIndex = 3;
    else
      this.combo_action3.SelectedIndex = 0;
    this.\u0015.Checked = this.Par.CollControl.CollCtrlOperations[3].CheckMachiningSurfaces;
    this.\u0014.Checked = this.Par.CollControl.CollCtrlOperations[3].CheckSurfaces;
    this.\u0005.Value = (Decimal) this.Par.CollControl.CollCtrlOperations[3].CheckSurfTolerance;
    this.\u0006.Value = (Decimal) this.Par.CollControl.CollCtrlOperations[3].StockToLeave;
    this.\u0019.Checked = this.Par.CollControl.CollCtrlOperations[3].CheckHolder;
    this.\u0018.Checked = this.Par.CollControl.CollCtrlOperations[3].CheckArbor;
    this.\u0016.Checked = this.Par.CollControl.CollCtrlOperations[3].CheckToolTip;
    this.\u0017.Checked = this.Par.CollControl.CollCtrlOperations[3].CheckToolShaft;
    this.\u001A.Checked = this.Par.CollControl.CollCtrlOperations[3].Status;
    if (this.Par.CollControl.CollCtrlOperations[3].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromContactLine)
      this.combo_move4.SelectedIndex = 0;
    else if (this.Par.CollControl.CollCtrlOperations[3].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZ)
      this.combo_relink4.SelectedIndex = 1;
    else if (this.Par.CollControl.CollCtrlOperations[3].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXy)
      this.combo_relink4.SelectedIndex = 2;
    else if (this.Par.CollControl.CollCtrlOperations[3].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXz)
      this.combo_relink4.SelectedIndex = 3;
    else if (this.Par.CollControl.CollCtrlOperations[3].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYz)
      this.combo_relink4.SelectedIndex = 4;
    else if (this.Par.CollControl.CollCtrlOperations[3].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZMin)
      this.combo_relink4.SelectedIndex = 5;
    else if (this.Par.CollControl.CollCtrlOperations[3].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInX)
      this.combo_relink4.SelectedIndex = 6;
    else if (this.Par.CollControl.CollCtrlOperations[3].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXMin)
      this.combo_relink4.SelectedIndex = 7;
    else if (this.Par.CollControl.CollCtrlOperations[3].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInY)
      this.combo_relink4.SelectedIndex = 8;
    else if (this.Par.CollControl.CollCtrlOperations[3].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYMin)
      this.combo_relink4.SelectedIndex = 9;
    else if (this.Par.CollControl.CollCtrlOperations[3].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongSurfNorm)
      this.combo_relink4.SelectedIndex = 10;
    else if (this.Par.CollControl.CollCtrlOperations[3].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromOrigin)
      this.combo_relink4.SelectedIndex = 11;
    else if (this.Par.CollControl.CollCtrlOperations[3].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractMoveToCenterOfCont)
      this.combo_relink4.SelectedIndex = 12;
    else if (this.Par.CollControl.CollCtrlOperations[3].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXy)
      this.combo_relink4.SelectedIndex = 13;
    else if (this.Par.CollControl.CollCtrlOperations[3].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXz)
      this.combo_relink4.SelectedIndex = 14;
    else if (this.Par.CollControl.CollCtrlOperations[3].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInYz)
      this.combo_relink4.SelectedIndex = 15;
    else if (this.Par.CollControl.CollCtrlOperations[3].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInCustomDir)
      this.combo_relink4.SelectedIndex = 16 /*0x10*/;
    else if (this.Par.CollControl.CollCtrlOperations[3].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolContactLine)
      this.combo_relink4.SelectedIndex = 17;
    else if (this.Par.CollControl.CollCtrlOperations[3].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolBottomPlane)
      this.combo_relink4.SelectedIndex = 18;
    else
      this.combo_relink4.SelectedIndex = 0;
    if (this.Par.CollControl.CollCtrlOperations[3].CollLeaveOutPntsType == CollCtrlOpParamsCollLeaveOutPointsType.LopDontTrimTp)
      this.combo_relink4.SelectedIndex = 0;
    else if (this.Par.CollControl.CollCtrlOperations[3].CollLeaveOutPntsType == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterFirstCol)
      this.combo_relink4.SelectedIndex = 1;
    else if (this.Par.CollControl.CollCtrlOperations[3].CollLeaveOutPntsType == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeLastCol)
      this.combo_relink4.SelectedIndex = 2;
    else if (this.Par.CollControl.CollCtrlOperations[3].CollLeaveOutPntsType == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBetwFirstAndLastCol)
      this.combo_relink4.SelectedIndex = 3;
    else if (this.Par.CollControl.CollCtrlOperations[3].CollLeaveOutPntsType == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeFirstCol)
      this.combo_relink4.SelectedIndex = 4;
    else if (this.Par.CollControl.CollCtrlOperations[3].CollLeaveOutPntsType == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterLastCol)
      this.combo_relink4.SelectedIndex = 5;
    else
      this.combo_relink4.SelectedIndex = 0;
    if (this.Par.CollControl.CollCtrlOperations[3].Strategy == CollCtrlOpBaseParamsCollStrategy.CsMoveToolAlongVector)
      this.combo_action4.SelectedIndex = 0;
    else if (this.Par.CollControl.CollCtrlOperations[3].Strategy == CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPoints)
      this.combo_action4.SelectedIndex = 1;
    else if (this.Par.CollControl.CollCtrlOperations[3].Strategy == CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPlanes)
      this.combo_action4.SelectedIndex = 2;
    else if (this.Par.CollControl.CollCtrlOperations[3].Strategy == CollCtrlOpBaseParamsCollStrategy.CsReportCollisions)
      this.combo_action4.SelectedIndex = 3;
    else
      this.combo_action4.SelectedIndex = 0;
    this.UpdateControlFromType();
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (this.Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    this.Apply();
    this.Properties.Result = DialogResult.OK;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void UpdateControlFromType()
  {
    this.\u0003.Enabled = this.\u0001.Checked;
    this.\u0002.Enabled = this.\u0001.Checked;
    this.\u0004.Enabled = this.\u0001.Checked;
    this.\u0001.Visible = !this.\u0005.Checked;
    this.\u0002.Visible = this.\u0005.Checked;
    this.\u0003.Visible = !this.\u0004.Checked;
    this.\u0008.Visible = this.\u0004.Checked;
    this.\u0005.Visible = !this.\u0003.Checked;
    this.\u0007.Visible = this.\u0003.Checked;
    this.\u0004.Visible = !this.\u0002.Checked;
    this.\u0006.Visible = this.\u0002.Checked;
    if (this.combo_action1.SelectedIndex == 0)
    {
      this.combo_move1.Enabled = true;
      this.combo_relink1.Enabled = false;
      this.\u0001.Enabled = true;
    }
    else if (this.combo_action1.SelectedIndex == 1)
    {
      this.combo_move1.Enabled = false;
      this.combo_relink1.Enabled = true;
      this.\u0001.Enabled = false;
    }
    else if (this.combo_action1.SelectedIndex == 1)
    {
      this.combo_move1.Enabled = false;
      this.combo_relink1.Enabled = false;
      this.\u0001.Enabled = false;
    }
    else
    {
      this.combo_move1.Enabled = false;
      this.combo_relink1.Enabled = false;
      this.\u0001.Enabled = false;
    }
    this.\u000E.Enabled = !this.\u0007.Checked;
    this.\u0002.Enabled = !this.\u0007.Checked;
    this.\u0008.Enabled = !this.\u0007.Checked;
    this.\u0001.Enabled = !this.\u0007.Checked;
    this.\u0007.Enabled = this.\u0013.Checked;
    this.\u0006.Enabled = this.\u0013.Checked;
    this.\u0008.Enabled = this.\u0013.Checked;
    this.\u0015.Visible = !this.\u000F.Checked;
    this.\u0014.Visible = this.\u000F.Checked;
    this.\u0013.Visible = !this.\u0010.Checked;
    this.\u0010.Visible = this.\u0010.Checked;
    this.\u0012.Visible = !this.\u0011.Checked;
    this.\u000F.Visible = this.\u0011.Checked;
    this.\u0011.Visible = !this.\u0012.Checked;
    this.\u000E.Visible = this.\u0012.Checked;
    if (this.combo_action2.SelectedIndex == 0)
    {
      this.combo_move2.Enabled = true;
      this.combo_relink2.Enabled = false;
      this.\u0002.Enabled = true;
    }
    else if (this.combo_action2.SelectedIndex == 1)
    {
      this.combo_move2.Enabled = false;
      this.combo_relink2.Enabled = true;
      this.\u0002.Enabled = false;
    }
    else if (this.combo_action2.SelectedIndex == 1)
    {
      this.combo_move2.Enabled = false;
      this.combo_relink2.Enabled = false;
      this.\u0002.Enabled = false;
    }
    else
    {
      this.combo_move2.Enabled = false;
      this.combo_relink2.Enabled = false;
      this.\u0002.Enabled = false;
    }
    this.\u0013.Enabled = !this.\u000E.Checked;
    this.\u0004.Enabled = !this.\u000E.Checked;
    this.\u0012.Enabled = !this.\u000E.Checked;
    this.\u0003.Enabled = !this.\u000E.Checked;
    this.\u0014.Enabled = this.\u0080.Checked;
    this.\u0013.Enabled = this.\u0080.Checked;
    this.\u0015.Enabled = this.\u0080.Checked;
    this.\u008C.Visible = !this.\u001D.Checked;
    this.\u0091.Visible = this.\u001D.Checked;
    this.\u008E.Visible = !this.\u001E.Checked;
    this.\u008F.Visible = this.\u001E.Checked;
    this.\u0090.Visible = !this.\u001F.Checked;
    this.\u008D.Visible = this.\u001F.Checked;
    this.\u0092.Visible = !this.\u007F.Checked;
    this.\u008B.Visible = this.\u007F.Checked;
    if (this.combo_action3.SelectedIndex == 0)
    {
      this.combo_move3.Enabled = true;
      this.combo_relink3.Enabled = false;
      this.\u0004.Enabled = true;
    }
    else if (this.combo_action3.SelectedIndex == 1)
    {
      this.combo_move3.Enabled = false;
      this.combo_relink3.Enabled = true;
      this.\u0004.Enabled = false;
    }
    else if (this.combo_action3.SelectedIndex == 1)
    {
      this.combo_move3.Enabled = false;
      this.combo_relink3.Enabled = false;
      this.\u0004.Enabled = false;
    }
    else
    {
      this.combo_move3.Enabled = false;
      this.combo_relink3.Enabled = false;
      this.\u0004.Enabled = false;
    }
    this.\u0082.Enabled = !this.\u001C.Checked;
    this.\u0008.Enabled = !this.\u001C.Checked;
    this.\u0081.Enabled = !this.\u001C.Checked;
    this.\u0007.Enabled = !this.\u001C.Checked;
    this.\u0010.Enabled = this.\u001A.Checked;
    this.\u000F.Enabled = this.\u001A.Checked;
    this.\u0011.Enabled = this.\u001A.Checked;
    this.\u0086.Visible = !this.\u0016.Checked;
    this.\u0081.Visible = this.\u0016.Checked;
    this.\u0084.Visible = !this.\u0017.Checked;
    this.\u0080.Visible = this.\u0017.Checked;
    this.\u0083.Visible = !this.\u0018.Checked;
    this.\u007F.Visible = this.\u0018.Checked;
    this.\u0082.Visible = !this.\u0019.Checked;
    this.\u001F.Visible = this.\u0019.Checked;
    if (this.combo_action4.SelectedIndex == 0)
    {
      this.combo_move4.Enabled = true;
      this.combo_relink4.Enabled = false;
      this.\u0003.Enabled = true;
    }
    else if (this.combo_action4.SelectedIndex == 1)
    {
      this.combo_move4.Enabled = false;
      this.combo_relink4.Enabled = true;
      this.\u0003.Enabled = false;
    }
    else if (this.combo_action4.SelectedIndex == 1)
    {
      this.combo_move4.Enabled = false;
      this.combo_relink4.Enabled = false;
      this.\u0003.Enabled = false;
    }
    else
    {
      this.combo_move4.Enabled = false;
      this.combo_relink4.Enabled = false;
      this.\u0003.Enabled = false;
    }
    this.\u001B.Enabled = !this.\u0015.Checked;
    this.\u0006.Enabled = !this.\u0015.Checked;
    this.\u001A.Enabled = !this.\u0015.Checked;
    this.\u0005.Enabled = !this.\u0015.Checked;
    this.\u0005.Enabled = this.\u0001.Checked | this.\u0013.Checked | this.\u0080.Checked | this.\u001A.Checked;
  }

  public void Apply()
  {
    this.Par.CollControl.CollCtrlOperations[0].CheckSurfaces = this.\u0006.Checked;
    this.Par.CollControl.CollCtrlOperations[0].CheckMachiningSurfaces = this.\u0007.Checked;
    this.Par.CollControl.CollCtrlOperations[0].CheckSurfTolerance = (double) this.\u0001.Value;
    this.Par.CollControl.CollCtrlOperations[0].StockToLeave = (double) this.\u0002.Value;
    this.Par.CollControl.CollCtrlOperations[0].CheckHolder = this.\u0002.Checked;
    this.Par.CollControl.CollCtrlOperations[0].CheckArbor = this.\u0003.Checked;
    this.Par.CollControl.CollCtrlOperations[0].CheckToolTip = this.\u0005.Checked;
    this.Par.CollControl.CollCtrlOperations[0].CheckToolShaft = this.\u0004.Checked;
    this.Par.CollControl.CollCtrlOperations[0].Status = this.\u0001.Checked;
    if (this.combo_move1.SelectedIndex == 0)
      this.Par.CollControl.CollCtrlOperations[0].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromContactLine;
    else if (this.combo_move1.SelectedIndex == 1)
      this.Par.CollControl.CollCtrlOperations[0].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZ;
    else if (this.combo_move1.SelectedIndex == 2)
      this.Par.CollControl.CollCtrlOperations[0].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXy;
    else if (this.combo_move1.SelectedIndex == 3)
      this.Par.CollControl.CollCtrlOperations[0].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXz;
    else if (this.combo_move1.SelectedIndex == 4)
      this.Par.CollControl.CollCtrlOperations[0].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYz;
    else if (this.combo_move1.SelectedIndex == 5)
      this.Par.CollControl.CollCtrlOperations[0].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZMin;
    else if (this.combo_move1.SelectedIndex == 6)
      this.Par.CollControl.CollCtrlOperations[0].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInX;
    else if (this.combo_move1.SelectedIndex == 7)
      this.Par.CollControl.CollCtrlOperations[0].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXMin;
    else if (this.combo_move1.SelectedIndex == 8)
      this.Par.CollControl.CollCtrlOperations[0].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInY;
    else if (this.combo_move1.SelectedIndex == 9)
      this.Par.CollControl.CollCtrlOperations[0].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYMin;
    else if (this.combo_move1.SelectedIndex == 10)
      this.Par.CollControl.CollCtrlOperations[0].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongSurfNorm;
    else if (this.combo_move1.SelectedIndex == 11)
      this.Par.CollControl.CollCtrlOperations[0].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromOrigin;
    else if (this.combo_move1.SelectedIndex == 12)
      this.Par.CollControl.CollCtrlOperations[0].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractMoveToCenterOfCont;
    else if (this.combo_move1.SelectedIndex == 13)
      this.Par.CollControl.CollCtrlOperations[0].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXy;
    else if (this.combo_move1.SelectedIndex == 14)
      this.Par.CollControl.CollCtrlOperations[0].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXz;
    else if (this.combo_move1.SelectedIndex == 15)
      this.Par.CollControl.CollCtrlOperations[0].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInYz;
    else if (this.combo_move1.SelectedIndex == 16 /*0x10*/)
      this.Par.CollControl.CollCtrlOperations[0].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInCustomDir;
    else if (this.combo_move1.SelectedIndex == 17)
      this.Par.CollControl.CollCtrlOperations[0].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolContactLine;
    else if (this.combo_move1.SelectedIndex == 18)
      this.Par.CollControl.CollCtrlOperations[0].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolBottomPlane;
    if (this.combo_relink1.SelectedIndex == 0)
      this.Par.CollControl.CollCtrlOperations[0].CollLeaveOutPntsType = CollCtrlOpParamsCollLeaveOutPointsType.LopDontTrimTp;
    else if (this.combo_relink1.SelectedIndex == 1)
      this.Par.CollControl.CollCtrlOperations[0].CollLeaveOutPntsType = CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterFirstCol;
    else if (this.combo_relink1.SelectedIndex == 2)
      this.Par.CollControl.CollCtrlOperations[0].CollLeaveOutPntsType = CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeLastCol;
    else if (this.combo_relink1.SelectedIndex == 3)
      this.Par.CollControl.CollCtrlOperations[0].CollLeaveOutPntsType = CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBetwFirstAndLastCol;
    else if (this.combo_relink1.SelectedIndex == 4)
      this.Par.CollControl.CollCtrlOperations[0].CollLeaveOutPntsType = CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeFirstCol;
    else if (this.combo_relink1.SelectedIndex == 5)
      this.Par.CollControl.CollCtrlOperations[0].CollLeaveOutPntsType = CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterLastCol;
    if (this.combo_action1.SelectedIndex == 0)
      this.Par.CollControl.CollCtrlOperations[0].Strategy = CollCtrlOpBaseParamsCollStrategy.CsMoveToolAlongVector;
    else if (this.combo_action1.SelectedIndex == 1)
      this.Par.CollControl.CollCtrlOperations[0].Strategy = CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPoints;
    else if (this.combo_action1.SelectedIndex == 2)
      this.Par.CollControl.CollCtrlOperations[0].Strategy = CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPlanes;
    else if (this.combo_action1.SelectedIndex == 3)
      this.Par.CollControl.CollCtrlOperations[0].Strategy = CollCtrlOpBaseParamsCollStrategy.CsReportCollisions;
    this.Par.CollControl.CollCtrlOperations[1].CheckSurfaces = this.\u0008.Checked;
    this.Par.CollControl.CollCtrlOperations[1].CheckMachiningSurfaces = this.\u000E.Checked;
    this.Par.CollControl.CollCtrlOperations[1].CheckSurfTolerance = (double) this.\u0003.Value;
    this.Par.CollControl.CollCtrlOperations[1].StockToLeave = (double) this.\u0004.Value;
    this.Par.CollControl.CollCtrlOperations[1].CheckHolder = this.\u0012.Checked;
    this.Par.CollControl.CollCtrlOperations[1].CheckArbor = this.\u0011.Checked;
    this.Par.CollControl.CollCtrlOperations[1].CheckToolTip = this.\u000F.Checked;
    this.Par.CollControl.CollCtrlOperations[1].CheckToolShaft = this.\u0010.Checked;
    this.Par.CollControl.CollCtrlOperations[1].Status = this.\u0013.Checked;
    if (this.combo_move2.SelectedIndex == 0)
      this.Par.CollControl.CollCtrlOperations[1].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromContactLine;
    else if (this.combo_move2.SelectedIndex == 1)
      this.Par.CollControl.CollCtrlOperations[1].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZ;
    else if (this.combo_move2.SelectedIndex == 2)
      this.Par.CollControl.CollCtrlOperations[1].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXy;
    else if (this.combo_move2.SelectedIndex == 3)
      this.Par.CollControl.CollCtrlOperations[1].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXz;
    else if (this.combo_move2.SelectedIndex == 4)
      this.Par.CollControl.CollCtrlOperations[1].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYz;
    else if (this.combo_move2.SelectedIndex == 5)
      this.Par.CollControl.CollCtrlOperations[1].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZMin;
    else if (this.combo_move2.SelectedIndex == 6)
      this.Par.CollControl.CollCtrlOperations[1].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInX;
    else if (this.combo_move2.SelectedIndex == 7)
      this.Par.CollControl.CollCtrlOperations[1].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXMin;
    else if (this.combo_move2.SelectedIndex == 8)
      this.Par.CollControl.CollCtrlOperations[1].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInY;
    else if (this.combo_move2.SelectedIndex == 9)
      this.Par.CollControl.CollCtrlOperations[1].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYMin;
    else if (this.combo_move2.SelectedIndex == 10)
      this.Par.CollControl.CollCtrlOperations[1].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongSurfNorm;
    else if (this.combo_move2.SelectedIndex == 11)
      this.Par.CollControl.CollCtrlOperations[1].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromOrigin;
    else if (this.combo_move2.SelectedIndex == 12)
      this.Par.CollControl.CollCtrlOperations[1].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractMoveToCenterOfCont;
    else if (this.combo_move2.SelectedIndex == 13)
      this.Par.CollControl.CollCtrlOperations[1].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXy;
    else if (this.combo_move2.SelectedIndex == 14)
      this.Par.CollControl.CollCtrlOperations[1].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXz;
    else if (this.combo_move2.SelectedIndex == 15)
      this.Par.CollControl.CollCtrlOperations[1].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInYz;
    else if (this.combo_move2.SelectedIndex == 16 /*0x10*/)
      this.Par.CollControl.CollCtrlOperations[1].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInCustomDir;
    else if (this.combo_move2.SelectedIndex == 17)
      this.Par.CollControl.CollCtrlOperations[1].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolContactLine;
    else if (this.combo_move2.SelectedIndex == 18)
      this.Par.CollControl.CollCtrlOperations[1].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolBottomPlane;
    if (this.combo_relink2.SelectedIndex == 0)
      this.Par.CollControl.CollCtrlOperations[1].CollLeaveOutPntsType = CollCtrlOpParamsCollLeaveOutPointsType.LopDontTrimTp;
    else if (this.combo_relink2.SelectedIndex == 1)
      this.Par.CollControl.CollCtrlOperations[1].CollLeaveOutPntsType = CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterFirstCol;
    else if (this.combo_relink2.SelectedIndex == 2)
      this.Par.CollControl.CollCtrlOperations[1].CollLeaveOutPntsType = CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeLastCol;
    else if (this.combo_relink2.SelectedIndex == 3)
      this.Par.CollControl.CollCtrlOperations[1].CollLeaveOutPntsType = CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBetwFirstAndLastCol;
    else if (this.combo_relink2.SelectedIndex == 4)
      this.Par.CollControl.CollCtrlOperations[1].CollLeaveOutPntsType = CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeFirstCol;
    else if (this.combo_relink2.SelectedIndex == 5)
      this.Par.CollControl.CollCtrlOperations[1].CollLeaveOutPntsType = CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterLastCol;
    if (this.combo_action2.SelectedIndex == 0)
      this.Par.CollControl.CollCtrlOperations[1].Strategy = CollCtrlOpBaseParamsCollStrategy.CsMoveToolAlongVector;
    else if (this.combo_action2.SelectedIndex == 1)
      this.Par.CollControl.CollCtrlOperations[1].Strategy = CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPoints;
    else if (this.combo_action2.SelectedIndex == 2)
      this.Par.CollControl.CollCtrlOperations[1].Strategy = CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPlanes;
    else if (this.combo_action2.SelectedIndex == 3)
      this.Par.CollControl.CollCtrlOperations[1].Strategy = CollCtrlOpBaseParamsCollStrategy.CsReportCollisions;
    this.Par.CollControl.CollCtrlOperations[2].CheckSurfaces = this.\u001B.Checked;
    this.Par.CollControl.CollCtrlOperations[2].CheckMachiningSurfaces = this.\u001C.Checked;
    this.Par.CollControl.CollCtrlOperations[2].CheckSurfTolerance = (double) this.\u0007.Value;
    this.Par.CollControl.CollCtrlOperations[2].StockToLeave = (double) this.\u0008.Value;
    this.Par.CollControl.CollCtrlOperations[2].CheckHolder = this.\u007F.Checked;
    this.Par.CollControl.CollCtrlOperations[2].CheckArbor = this.\u001F.Checked;
    this.Par.CollControl.CollCtrlOperations[2].CheckToolTip = this.\u001D.Checked;
    this.Par.CollControl.CollCtrlOperations[2].CheckToolShaft = this.\u001E.Checked;
    this.Par.CollControl.CollCtrlOperations[2].Status = this.\u0080.Checked;
    if (this.combo_move3.SelectedIndex == 0)
      this.Par.CollControl.CollCtrlOperations[2].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromContactLine;
    else if (this.combo_move3.SelectedIndex == 1)
      this.Par.CollControl.CollCtrlOperations[2].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZ;
    else if (this.combo_move3.SelectedIndex == 2)
      this.Par.CollControl.CollCtrlOperations[2].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXy;
    else if (this.combo_move3.SelectedIndex == 3)
      this.Par.CollControl.CollCtrlOperations[2].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXz;
    else if (this.combo_move3.SelectedIndex == 4)
      this.Par.CollControl.CollCtrlOperations[2].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYz;
    else if (this.combo_move3.SelectedIndex == 5)
      this.Par.CollControl.CollCtrlOperations[2].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZMin;
    else if (this.combo_move3.SelectedIndex == 6)
      this.Par.CollControl.CollCtrlOperations[2].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInX;
    else if (this.combo_move3.SelectedIndex == 7)
      this.Par.CollControl.CollCtrlOperations[2].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXMin;
    else if (this.combo_move3.SelectedIndex == 8)
      this.Par.CollControl.CollCtrlOperations[2].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInY;
    else if (this.combo_move3.SelectedIndex == 9)
      this.Par.CollControl.CollCtrlOperations[2].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYMin;
    else if (this.combo_move3.SelectedIndex == 10)
      this.Par.CollControl.CollCtrlOperations[2].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongSurfNorm;
    else if (this.combo_move3.SelectedIndex == 11)
      this.Par.CollControl.CollCtrlOperations[2].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromOrigin;
    else if (this.combo_move3.SelectedIndex == 12)
      this.Par.CollControl.CollCtrlOperations[2].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractMoveToCenterOfCont;
    else if (this.combo_move3.SelectedIndex == 13)
      this.Par.CollControl.CollCtrlOperations[2].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXy;
    else if (this.combo_move3.SelectedIndex == 14)
      this.Par.CollControl.CollCtrlOperations[2].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXz;
    else if (this.combo_move3.SelectedIndex == 15)
      this.Par.CollControl.CollCtrlOperations[2].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInYz;
    else if (this.combo_move3.SelectedIndex == 16 /*0x10*/)
      this.Par.CollControl.CollCtrlOperations[2].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInCustomDir;
    else if (this.combo_move3.SelectedIndex == 17)
      this.Par.CollControl.CollCtrlOperations[2].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolContactLine;
    else if (this.combo_move3.SelectedIndex == 18)
      this.Par.CollControl.CollCtrlOperations[2].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolBottomPlane;
    if (this.combo_relink3.SelectedIndex == 0)
      this.Par.CollControl.CollCtrlOperations[2].CollLeaveOutPntsType = CollCtrlOpParamsCollLeaveOutPointsType.LopDontTrimTp;
    else if (this.combo_relink3.SelectedIndex == 1)
      this.Par.CollControl.CollCtrlOperations[2].CollLeaveOutPntsType = CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterFirstCol;
    else if (this.combo_relink3.SelectedIndex == 2)
      this.Par.CollControl.CollCtrlOperations[2].CollLeaveOutPntsType = CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeLastCol;
    else if (this.combo_relink3.SelectedIndex == 3)
      this.Par.CollControl.CollCtrlOperations[2].CollLeaveOutPntsType = CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBetwFirstAndLastCol;
    else if (this.combo_relink3.SelectedIndex == 4)
      this.Par.CollControl.CollCtrlOperations[2].CollLeaveOutPntsType = CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeFirstCol;
    else if (this.combo_relink3.SelectedIndex == 5)
      this.Par.CollControl.CollCtrlOperations[2].CollLeaveOutPntsType = CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterLastCol;
    if (this.combo_action3.SelectedIndex == 0)
      this.Par.CollControl.CollCtrlOperations[2].Strategy = CollCtrlOpBaseParamsCollStrategy.CsMoveToolAlongVector;
    else if (this.combo_action3.SelectedIndex == 1)
      this.Par.CollControl.CollCtrlOperations[2].Strategy = CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPoints;
    else if (this.combo_action3.SelectedIndex == 2)
      this.Par.CollControl.CollCtrlOperations[2].Strategy = CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPlanes;
    else if (this.combo_action3.SelectedIndex == 3)
      this.Par.CollControl.CollCtrlOperations[2].Strategy = CollCtrlOpBaseParamsCollStrategy.CsReportCollisions;
    this.Par.CollControl.CollCtrlOperations[3].CheckSurfaces = this.\u0014.Checked;
    this.Par.CollControl.CollCtrlOperations[3].CheckMachiningSurfaces = this.\u0015.Checked;
    this.Par.CollControl.CollCtrlOperations[3].CheckSurfTolerance = (double) this.\u0005.Value;
    this.Par.CollControl.CollCtrlOperations[3].StockToLeave = (double) this.\u0006.Value;
    this.Par.CollControl.CollCtrlOperations[3].CheckHolder = this.\u0019.Checked;
    this.Par.CollControl.CollCtrlOperations[3].CheckArbor = this.\u0018.Checked;
    this.Par.CollControl.CollCtrlOperations[3].CheckToolTip = this.\u0016.Checked;
    this.Par.CollControl.CollCtrlOperations[3].CheckToolShaft = this.\u0017.Checked;
    this.Par.CollControl.CollCtrlOperations[3].Status = this.\u001A.Checked;
    if (this.combo_move4.SelectedIndex == 0)
      this.Par.CollControl.CollCtrlOperations[3].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromContactLine;
    else if (this.combo_move4.SelectedIndex == 1)
      this.Par.CollControl.CollCtrlOperations[3].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZ;
    else if (this.combo_move4.SelectedIndex == 2)
      this.Par.CollControl.CollCtrlOperations[3].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXy;
    else if (this.combo_move4.SelectedIndex == 3)
      this.Par.CollControl.CollCtrlOperations[3].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXz;
    else if (this.combo_move4.SelectedIndex == 4)
      this.Par.CollControl.CollCtrlOperations[3].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYz;
    else if (this.combo_move4.SelectedIndex == 5)
      this.Par.CollControl.CollCtrlOperations[3].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZMin;
    else if (this.combo_move4.SelectedIndex == 6)
      this.Par.CollControl.CollCtrlOperations[3].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInX;
    else if (this.combo_move4.SelectedIndex == 7)
      this.Par.CollControl.CollCtrlOperations[3].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXMin;
    else if (this.combo_move4.SelectedIndex == 8)
      this.Par.CollControl.CollCtrlOperations[3].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInY;
    else if (this.combo_move4.SelectedIndex == 9)
      this.Par.CollControl.CollCtrlOperations[3].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYMin;
    else if (this.combo_move4.SelectedIndex == 10)
      this.Par.CollControl.CollCtrlOperations[3].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongSurfNorm;
    else if (this.combo_move4.SelectedIndex == 11)
      this.Par.CollControl.CollCtrlOperations[3].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromOrigin;
    else if (this.combo_move4.SelectedIndex == 12)
      this.Par.CollControl.CollCtrlOperations[3].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractMoveToCenterOfCont;
    else if (this.combo_move4.SelectedIndex == 13)
      this.Par.CollControl.CollCtrlOperations[3].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXy;
    else if (this.combo_move4.SelectedIndex == 14)
      this.Par.CollControl.CollCtrlOperations[3].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXz;
    else if (this.combo_move4.SelectedIndex == 15)
      this.Par.CollControl.CollCtrlOperations[3].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInYz;
    else if (this.combo_move4.SelectedIndex == 16 /*0x10*/)
      this.Par.CollControl.CollCtrlOperations[3].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInCustomDir;
    else if (this.combo_move4.SelectedIndex == 17)
      this.Par.CollControl.CollCtrlOperations[3].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolContactLine;
    else if (this.combo_move4.SelectedIndex == 18)
      this.Par.CollControl.CollCtrlOperations[3].SideRetractDir = CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolBottomPlane;
    if (this.combo_relink4.SelectedIndex == 0)
      this.Par.CollControl.CollCtrlOperations[3].CollLeaveOutPntsType = CollCtrlOpParamsCollLeaveOutPointsType.LopDontTrimTp;
    else if (this.combo_relink4.SelectedIndex == 1)
      this.Par.CollControl.CollCtrlOperations[3].CollLeaveOutPntsType = CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterFirstCol;
    else if (this.combo_relink4.SelectedIndex == 2)
      this.Par.CollControl.CollCtrlOperations[3].CollLeaveOutPntsType = CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeLastCol;
    else if (this.combo_relink4.SelectedIndex == 3)
      this.Par.CollControl.CollCtrlOperations[3].CollLeaveOutPntsType = CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBetwFirstAndLastCol;
    else if (this.combo_relink4.SelectedIndex == 4)
      this.Par.CollControl.CollCtrlOperations[3].CollLeaveOutPntsType = CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeFirstCol;
    else if (this.combo_relink4.SelectedIndex == 5)
      this.Par.CollControl.CollCtrlOperations[3].CollLeaveOutPntsType = CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterLastCol;
    if (this.combo_action4.SelectedIndex == 0)
      this.Par.CollControl.CollCtrlOperations[3].Strategy = CollCtrlOpBaseParamsCollStrategy.CsMoveToolAlongVector;
    else if (this.combo_action4.SelectedIndex == 1)
      this.Par.CollControl.CollCtrlOperations[3].Strategy = CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPoints;
    else if (this.combo_action4.SelectedIndex == 2)
    {
      this.Par.CollControl.CollCtrlOperations[3].Strategy = CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPlanes;
    }
    else
    {
      if (this.combo_action4.SelectedIndex != 3)
        return;
      this.Par.CollControl.CollCtrlOperations[3].Strategy = CollCtrlOpBaseParamsCollStrategy.CsReportCollisions;
    }
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!this.Properties.Inited)
      return;
    this.Properties.Inited = false;
    this.Apply();
    this.UpdateControlFromType();
    this.Properties.Inited = true;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!this.Properties.Inited)
      return;
    this.Properties.Inited = false;
    this.Apply();
    this.UpdateControlFromType();
    this.Properties.Inited = true;
  }
}
