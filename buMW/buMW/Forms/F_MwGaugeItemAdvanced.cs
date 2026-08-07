// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwGaugeItemAdvanced
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

public class F_MwGaugeItemAdvanced : Form
{
  internal NumericUpDown \u0007;
  internal Panel \u0002;
  internal System.Windows.Forms.Label \u0008;
  public FormProperties Properties = new FormProperties();
  public MachiningParams Par = new MachiningParams(Unit.Metric);
  public int GaugeIndex = 0;
  internal IContainer \u0001 = (IContainer) null;
  internal CheckBox \u0001;
  internal CheckBox \u0002;
  internal System.Windows.Forms.Label \u0001;
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal NumericUpDown \u0002;
  internal CheckBox \u0003;
  internal System.Windows.Forms.Label \u0003;
  internal NumericUpDown \u0003;
  internal CheckBox \u0004;
  internal CheckBox \u0005;
  internal CheckBox \u0006;
  internal ImageList \u0001;

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MwGaugeClearanceForTool) this).UpdateControlFromType();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MwGaugeClearanceForTool) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MwGaugeClearanceForTool) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MwGaugeItemAdvanced() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    if (this.GaugeIndex == 0)
    {
      this.\u0001.Value = (Decimal) this.Par.CollControl.CollCtrlOperations[0].SmoothRetractsDistance;
      this.\u0002.Checked = this.Par.CollControl.CollCtrlOperations[0].SmoothRetractsFlg;
      this.\u0003.Value = (Decimal) this.Par.CollControl.CollCtrlOperations[0].MaxInwardDistance4ProjectTool;
      this.\u0004.Checked = this.Par.CollControl.CollCtrlOperations[0].ProjectToolInwardsFlg;
      this.\u0002.Value = (Decimal) this.Par.CollControl.CollCtrlOperations[0].MaxOutwardDistance4MoveTool;
      this.\u0003.Checked = this.Par.CollControl.CollCtrlOperations[0].MoveToolOutwardsFlg;
      this.\u0006.Checked = this.Par.CollControl.CollCtrlOperations[0].ReverseProjectionDirFlg;
      ((F_MwGaugeCheck) this).\u0007.Checked = this.Par.CollControl.CollCtrlOperations[0].ProjectToolOnDirFlg;
      this.\u0005.Checked = this.Par.CollControl.CollCtrlOperations[0].RemoveAreaWhereToolDropFailFlg;
      this.\u0001.Checked = this.Par.CollControl.CollCtrlOperations[0].DropToolDownFlg;
    }
    if (this.GaugeIndex == 1)
    {
      this.\u0001.Value = (Decimal) this.Par.CollControl.CollCtrlOperations[1].SmoothRetractsDistance;
      this.\u0002.Checked = this.Par.CollControl.CollCtrlOperations[1].SmoothRetractsFlg;
      this.\u0003.Value = (Decimal) this.Par.CollControl.CollCtrlOperations[1].MaxInwardDistance4ProjectTool;
      this.\u0004.Checked = this.Par.CollControl.CollCtrlOperations[1].ProjectToolInwardsFlg;
      this.\u0002.Value = (Decimal) this.Par.CollControl.CollCtrlOperations[1].MaxOutwardDistance4MoveTool;
      this.\u0003.Checked = this.Par.CollControl.CollCtrlOperations[1].MoveToolOutwardsFlg;
      this.\u0006.Checked = this.Par.CollControl.CollCtrlOperations[1].ReverseProjectionDirFlg;
      ((F_MwGaugeCheck) this).\u0007.Checked = this.Par.CollControl.CollCtrlOperations[1].ProjectToolOnDirFlg;
      this.\u0005.Checked = this.Par.CollControl.CollCtrlOperations[1].RemoveAreaWhereToolDropFailFlg;
      this.\u0001.Checked = this.Par.CollControl.CollCtrlOperations[1].DropToolDownFlg;
    }
    if (this.GaugeIndex == 2)
    {
      this.\u0001.Value = (Decimal) this.Par.CollControl.CollCtrlOperations[2].SmoothRetractsDistance;
      this.\u0002.Checked = this.Par.CollControl.CollCtrlOperations[2].SmoothRetractsFlg;
      this.\u0003.Value = (Decimal) this.Par.CollControl.CollCtrlOperations[2].MaxInwardDistance4ProjectTool;
      this.\u0004.Checked = this.Par.CollControl.CollCtrlOperations[2].ProjectToolInwardsFlg;
      this.\u0002.Value = (Decimal) this.Par.CollControl.CollCtrlOperations[2].MaxOutwardDistance4MoveTool;
      this.\u0003.Checked = this.Par.CollControl.CollCtrlOperations[2].MoveToolOutwardsFlg;
      this.\u0006.Checked = this.Par.CollControl.CollCtrlOperations[2].ReverseProjectionDirFlg;
      ((F_MwGaugeCheck) this).\u0007.Checked = this.Par.CollControl.CollCtrlOperations[2].ProjectToolOnDirFlg;
      this.\u0005.Checked = this.Par.CollControl.CollCtrlOperations[2].RemoveAreaWhereToolDropFailFlg;
      this.\u0001.Checked = this.Par.CollControl.CollCtrlOperations[2].DropToolDownFlg;
    }
    if (this.GaugeIndex == 3)
    {
      this.\u0001.Value = (Decimal) this.Par.CollControl.CollCtrlOperations[3].SmoothRetractsDistance;
      this.\u0002.Checked = this.Par.CollControl.CollCtrlOperations[3].SmoothRetractsFlg;
      this.\u0003.Value = (Decimal) this.Par.CollControl.CollCtrlOperations[3].MaxInwardDistance4ProjectTool;
      this.\u0004.Checked = this.Par.CollControl.CollCtrlOperations[3].ProjectToolInwardsFlg;
      this.\u0002.Value = (Decimal) this.Par.CollControl.CollCtrlOperations[3].MaxOutwardDistance4MoveTool;
      this.\u0003.Checked = this.Par.CollControl.CollCtrlOperations[3].MoveToolOutwardsFlg;
      this.\u0006.Checked = this.Par.CollControl.CollCtrlOperations[3].ReverseProjectionDirFlg;
      ((F_MwGaugeCheck) this).\u0007.Checked = this.Par.CollControl.CollCtrlOperations[3].ProjectToolOnDirFlg;
      this.\u0005.Checked = this.Par.CollControl.CollCtrlOperations[3].RemoveAreaWhereToolDropFailFlg;
      this.\u0001.Checked = this.Par.CollControl.CollCtrlOperations[3].DropToolDownFlg;
    }
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
    if (this.GaugeIndex == 0)
    {
      if (this.Par.CollControl.CollCtrlOperations[0].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromContactLine)
      {
        this.\u0001.Enabled = true;
        ((F_MwGaugeCheck) this).\u0007.Enabled = false;
      }
      else
      {
        this.\u0001.Enabled = false;
        ((F_MwGaugeCheck) this).\u0007.Enabled = true;
      }
    }
    if (this.GaugeIndex == 1)
    {
      if (this.Par.CollControl.CollCtrlOperations[1].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromContactLine)
      {
        this.\u0001.Enabled = true;
        ((F_MwGaugeCheck) this).\u0007.Enabled = false;
      }
      else
      {
        this.\u0001.Enabled = false;
        ((F_MwGaugeCheck) this).\u0007.Enabled = true;
      }
    }
    if (this.GaugeIndex == 2)
    {
      if (this.Par.CollControl.CollCtrlOperations[2].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromContactLine)
      {
        this.\u0001.Enabled = true;
        ((F_MwGaugeCheck) this).\u0007.Enabled = false;
      }
      else
      {
        this.\u0001.Enabled = false;
        ((F_MwGaugeCheck) this).\u0007.Enabled = true;
      }
    }
    if (this.GaugeIndex == 3)
    {
      if (this.Par.CollControl.CollCtrlOperations[3].SideRetractDir == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromContactLine)
      {
        this.\u0001.Enabled = true;
        ((F_MwGaugeCheck) this).\u0007.Enabled = false;
      }
      else
      {
        this.\u0001.Enabled = false;
        ((F_MwGaugeCheck) this).\u0007.Enabled = true;
      }
    }
    this.\u0006.Enabled = ((F_MwGaugeCheck) this).\u0007.Checked & ((F_MwGaugeCheck) this).\u0007.Enabled;
    this.\u0005.Enabled = ((F_MwGaugeCheck) this).\u0007.Checked & ((F_MwGaugeCheck) this).\u0007.Enabled | this.\u0001.Checked & this.\u0001.Enabled;
    this.\u0004.Enabled = ((F_MwGaugeCheck) this).\u0007.Checked & ((F_MwGaugeCheck) this).\u0007.Enabled;
    this.\u0003.Enabled = ((F_MwGaugeCheck) this).\u0007.Checked & ((F_MwGaugeCheck) this).\u0007.Enabled;
    this.\u0003.Enabled = ((F_MwGaugeCheck) this).\u0007.Checked & ((F_MwGaugeCheck) this).\u0007.Enabled;
    this.\u0003.Enabled = this.\u0004.Checked & this.\u0004.Enabled;
    this.\u0003.Enabled = this.\u0004.Checked & this.\u0004.Enabled;
    this.\u0002.Enabled = this.\u0003.Checked & this.\u0003.Enabled;
    this.\u0002.Enabled = this.\u0003.Checked & this.\u0003.Enabled;
    this.\u0002.Enabled = this.\u0001.Checked & this.\u0001.Enabled;
    this.\u0001.Enabled = this.\u0001.Checked & this.\u0001.Enabled;
    this.\u0001.Enabled = this.\u0001.Checked & this.\u0001.Enabled;
  }

  public void Apply()
  {
    if (this.GaugeIndex == 0)
    {
      this.Par.CollControl.CollCtrlOperations[0].SmoothRetractsDistance = (double) this.\u0001.Value;
      this.Par.CollControl.CollCtrlOperations[0].SmoothRetractsFlg = this.\u0002.Checked;
      this.Par.CollControl.CollCtrlOperations[0].MaxInwardDistance4ProjectTool = (double) this.\u0003.Value;
      this.Par.CollControl.CollCtrlOperations[0].ProjectToolInwardsFlg = this.\u0004.Checked;
      this.Par.CollControl.CollCtrlOperations[0].MaxOutwardDistance4MoveTool = (double) this.\u0002.Value;
      this.Par.CollControl.CollCtrlOperations[0].MoveToolOutwardsFlg = this.\u0003.Checked;
      this.Par.CollControl.CollCtrlOperations[0].ReverseProjectionDirFlg = this.\u0006.Checked;
      this.Par.CollControl.CollCtrlOperations[0].ProjectToolOnDirFlg = ((F_MwGaugeCheck) this).\u0007.Checked;
      this.Par.CollControl.CollCtrlOperations[0].RemoveAreaWhereToolDropFailFlg = this.\u0005.Checked;
      this.Par.CollControl.CollCtrlOperations[0].DropToolDownFlg = this.\u0001.Checked;
    }
    if (this.GaugeIndex == 1)
    {
      this.Par.CollControl.CollCtrlOperations[1].SmoothRetractsDistance = (double) this.\u0001.Value;
      this.Par.CollControl.CollCtrlOperations[1].SmoothRetractsFlg = this.\u0002.Checked;
      this.Par.CollControl.CollCtrlOperations[1].MaxInwardDistance4ProjectTool = (double) this.\u0003.Value;
      this.Par.CollControl.CollCtrlOperations[1].ProjectToolInwardsFlg = this.\u0004.Checked;
      this.Par.CollControl.CollCtrlOperations[1].MaxOutwardDistance4MoveTool = (double) this.\u0002.Value;
      this.Par.CollControl.CollCtrlOperations[1].MoveToolOutwardsFlg = this.\u0003.Checked;
      this.Par.CollControl.CollCtrlOperations[1].ReverseProjectionDirFlg = this.\u0006.Checked;
      this.Par.CollControl.CollCtrlOperations[1].ProjectToolOnDirFlg = ((F_MwGaugeCheck) this).\u0007.Checked;
      this.Par.CollControl.CollCtrlOperations[1].RemoveAreaWhereToolDropFailFlg = this.\u0005.Checked;
      this.Par.CollControl.CollCtrlOperations[1].DropToolDownFlg = this.\u0001.Checked;
    }
    if (this.GaugeIndex == 2)
    {
      this.Par.CollControl.CollCtrlOperations[2].SmoothRetractsDistance = (double) this.\u0001.Value;
      this.Par.CollControl.CollCtrlOperations[2].SmoothRetractsFlg = this.\u0002.Checked;
      this.Par.CollControl.CollCtrlOperations[2].MaxInwardDistance4ProjectTool = (double) this.\u0003.Value;
      this.Par.CollControl.CollCtrlOperations[2].ProjectToolInwardsFlg = this.\u0004.Checked;
      this.Par.CollControl.CollCtrlOperations[2].MaxOutwardDistance4MoveTool = (double) this.\u0002.Value;
      this.Par.CollControl.CollCtrlOperations[2].MoveToolOutwardsFlg = this.\u0003.Checked;
      this.Par.CollControl.CollCtrlOperations[2].ReverseProjectionDirFlg = this.\u0006.Checked;
      this.Par.CollControl.CollCtrlOperations[2].ProjectToolOnDirFlg = ((F_MwGaugeCheck) this).\u0007.Checked;
      this.Par.CollControl.CollCtrlOperations[2].RemoveAreaWhereToolDropFailFlg = this.\u0005.Checked;
      this.Par.CollControl.CollCtrlOperations[2].DropToolDownFlg = this.\u0001.Checked;
    }
    if (this.GaugeIndex != 3)
      return;
    this.Par.CollControl.CollCtrlOperations[3].SmoothRetractsDistance = (double) this.\u0001.Value;
    this.Par.CollControl.CollCtrlOperations[3].SmoothRetractsFlg = this.\u0002.Checked;
    this.Par.CollControl.CollCtrlOperations[3].MaxInwardDistance4ProjectTool = (double) this.\u0003.Value;
    this.Par.CollControl.CollCtrlOperations[3].ProjectToolInwardsFlg = this.\u0004.Checked;
    this.Par.CollControl.CollCtrlOperations[3].MaxOutwardDistance4MoveTool = (double) this.\u0002.Value;
    this.Par.CollControl.CollCtrlOperations[3].MoveToolOutwardsFlg = this.\u0003.Checked;
    this.Par.CollControl.CollCtrlOperations[3].ReverseProjectionDirFlg = this.\u0006.Checked;
    this.Par.CollControl.CollCtrlOperations[3].ProjectToolOnDirFlg = ((F_MwGaugeCheck) this).\u0007.Checked;
    this.Par.CollControl.CollCtrlOperations[3].RemoveAreaWhereToolDropFailFlg = this.\u0005.Checked;
    this.Par.CollControl.CollCtrlOperations[3].DropToolDownFlg = this.\u0001.Checked;
  }
}
