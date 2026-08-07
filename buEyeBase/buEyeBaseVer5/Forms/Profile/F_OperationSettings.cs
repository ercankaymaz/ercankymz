// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Profile.F_OperationSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.Sewing;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Profile;

public class F_OperationSettings : Form
{
  public CheckBox chk_RemoveProfileAngle;
  public CheckBox chk_JobOpenClearAllProfiles;
  public CheckBox chk_UseAlwaysInsideContourForCam;
  internal Label \u0091\u0002;
  internal Label \u0092\u0002;
  internal Label \u0093\u0002;
  internal Label \u0094\u0002;
  internal Label \u0095\u0002;
  public CheckBox chk_UseAlwaysPocketForCam;
  internal TabPage \u0010;
  public CheckBox chk_ShowProfileInfoAtGCode;
  public CheckBox chk_ShowOperationInfoAtGCode;
  public CheckBox chk_ShowSupportBlockInfoAtGCode;
  internal Label \u0096\u0002;
  internal Label \u0097\u0002;

  public F_OperationSettings()
  {
    ((F_Settnigs) this).Properties = new FormProperties();
    ((F_Settnigs) this).SewingTableList = new List<SewingJobItem>();
    ((F_Settnigs) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_SewingTable) this);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CellClicked(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_Settnigs) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_Settnigs) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CellClicked(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_Settnigs) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_Settnigs) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public void Init()
  {
    ((F_Settnigs) this).Properties.Inited = false;
    if (((F_Settnigs) this).Properties.Height > 10)
      this.Height = ((F_Settnigs) this).Properties.Height;
    if (((F_Settnigs) this).Properties.Width > 10)
      this.Width = ((F_Settnigs) this).Properties.Width;
    this.TopMost = ((F_Settnigs) this).Properties.TopMost;
    this.StartPosition = ((F_Settnigs) this).Properties.FormPosition;
    ((F_Settnigs) this).\u0001.Columns.Clear();
    ((F_Settnigs) this).\u0001.Rows.Clear();
    ((F_Settnigs) this).\u0001.Columns.Add(buControlCommands.DataGridViewColumbSet(50, "No", "No"));
    ((F_Settnigs) this).\u0001.Columns.Add(buControlCommands.DataGridViewColumbSet(130, "X Pos", "X Pos"));
    ((F_Settnigs) this).\u0001.Columns.Add(buControlCommands.DataGridViewColumbSet(130, "Y Pos", "Y Pos"));
    ((F_Settnigs) this).\u0001.Columns.Add(buControlCommands.DataGridViewColumbSet(80 /*0x50*/, "Speed", "Speed"));
    ((F_Settnigs) this).\u0001.Columns.Add(buControlCommands.DataGridViewColumbSet(80 /*0x50*/, "FootHeight", "FootHeight"));
    ((F_Settnigs) this).\u0001.Columns.Add(buControlCommands.DataGridViewColumbSet(120, "Type", "Type"));
    ((F_Settnigs) this).\u0001.Columns.Add(buControlCommands.DataGridViewColumbSet(80 /*0x50*/, "Index", "Index"));
    ((F_Settnigs) this).\u0001.Columns.Add(buControlCommands.DataGridViewColumbSet(70, "Code1", "Code1"));
    ((F_Settnigs) this).\u0001.Columns.Add(buControlCommands.DataGridViewColumbSet(70, "Code2", "Code2"));
    ((F_Settnigs) this).\u0001.Columns.Add(buControlCommands.DataGridViewColumbSet(70, "Code3", "Code3"));
    ((F_Settnigs) this).\u0001.Columns.Add(buControlCommands.DataGridViewColumbSet(70, "Code4", "Code4"));
    ((F_Settnigs) this).\u0001.Columns.Add(buControlCommands.DataGridViewColumbSet(70, "Code5", "Code5"));
    ((F_Settnigs) this).\u0001.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
    ((F_Settnigs) this).\u0001.EnableHeadersVisualStyles = true;
    ((F_Settnigs) this).\u0001.RowHeadersVisible = false;
    ((F_Settnigs) this).\u0001.ColumnHeadersVisible = true;
    ((F_Settnigs) this).\u0001.AllowUserToAddRows = false;
    ((F_Settnigs) this).\u0001.AllowUserToResizeColumns = false;
    ((F_Settnigs) this).\u0001.AllowUserToResizeRows = false;
    int num = 0;
    for (int index = 0; index <= ((F_Settnigs) this).SewingTableList.Count - 1; ++index)
    {
      ++num;
      Color white = Color.White;
      string str;
      Color color;
      if (((DrillCNCSettings) ((F_Settnigs) this).SewingTableList[index]).StitchedWay)
      {
        str = "Stich";
        color = Color.LightPink;
      }
      else
      {
        str = "Jump";
        num = 0;
        color = Color.DarkOrange;
      }
      DataGridViewRowCollection rows = ((F_Settnigs) this).\u0001.Rows;
      double positionX = ((DrillCNCSettings) ((F_Settnigs) this).SewingTableList[index]).PositionX;
      double positionY = ((DrillCNCSettings) ((F_Settnigs) this).SewingTableList[index]).PositionY;
      double headSpeed = ((DrillCNCSettings) ((F_Settnigs) this).SewingTableList[index]).HeadSpeed;
      double footHeight = ((DrillCNCSettings) ((F_Settnigs) this).SewingTableList[index]).FootHeight;
      int code1 = ((DrillCNCSettings) ((F_Settnigs) this).SewingTableList[index]).Code1;
      int code2 = ((DrillCNCSettings) ((F_Settnigs) this).SewingTableList[index]).Code2;
      int code3 = ((DrillCNCSettings) ((F_Settnigs) this).SewingTableList[index]).Code3;
      int code4 = ((DrillCNCSettings) ((F_Settnigs) this).SewingTableList[index]).Code4;
      int code5 = ((DrillCNCSettings) ((F_Settnigs) this).SewingTableList[index]).Code5;
      object[] objArray = \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(headSpeed, code5, code4, code3, code2, num, str, positionY, positionX, index + 1, footHeight, code1, (F_SewingTable) this);
      rows.Add(objArray);
      ((F_Settnigs) this).\u0001.Rows[((F_Settnigs) this).\u0001.Rows.Count - 1].Cells[5].Style.BackColor = color;
      if (((DrillCNCSettings) ((F_Settnigs) this).SewingTableList[index]).FootHeight != 0.0)
        ((F_Settnigs) this).\u0001.Rows[((F_Settnigs) this).\u0001.Rows.Count - 1].Cells[4].Style.BackColor = Color.LightGreen;
      if (((DrillCNCSettings) ((F_Settnigs) this).SewingTableList[index]).Code1 != 0)
        ((F_Settnigs) this).\u0001.Rows[((F_Settnigs) this).\u0001.Rows.Count - 1].Cells[7].Style.BackColor = Color.LightGreen;
      if (((DrillCNCSettings) ((F_Settnigs) this).SewingTableList[index]).Code2 != 0)
        ((F_Settnigs) this).\u0001.Rows[((F_Settnigs) this).\u0001.Rows.Count - 1].Cells[8].Style.BackColor = Color.LightGreen;
      if (((DrillCNCSettings) ((F_Settnigs) this).SewingTableList[index]).Code3 != 0)
        ((F_Settnigs) this).\u0001.Rows[((F_Settnigs) this).\u0001.Rows.Count - 1].Cells[9].Style.BackColor = Color.LightGreen;
      if (((DrillCNCSettings) ((F_Settnigs) this).SewingTableList[index]).Code4 != 0)
        ((F_Settnigs) this).\u0001.Rows[((F_Settnigs) this).\u0001.Rows.Count - 1].Cells[10].Style.BackColor = Color.LightGreen;
      if (((DrillCNCSettings) ((F_Settnigs) this).SewingTableList[index]).Code5 != 0)
        ((F_Settnigs) this).\u0001.Rows[((F_Settnigs) this).\u0001.Rows.Count - 1].Cells[11].Style.BackColor = Color.LightGreen;
    }
    ((F_Settnigs) this).Properties.Result = DialogResult.None;
    ((F_Settnigs) this).Properties.Inited = true;
    this.LoadLangueage();
  }

  public void LoadLangueage()
  {
    string callMethod = "ToolDetailed LoadLanguage";
    try
    {
      if (F_Settnigs.Captions.Count >= 1)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_Settnigs) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_Settnigs) this).Properties.Result = DialogResult.Cancel;
    if (((F_Settnigs) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_Settnigs) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }
}
