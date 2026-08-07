// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Customer.DincMak.F_SlotShape
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.Door;
using buEyeBaseVer5.Forms.Events;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Customer.DincMak;

public class F_SlotShape : Form
{
  public bool ValueChanging;
  internal IContainer \u0001;
  internal Button \u0001;
  internal Button \u0002;
  internal ImageList \u0001;
  internal ImageList \u0002;
  internal Button \u0003;
  internal ImageList \u0003;
  internal Button \u0004;
  public NumericUpDown spn_blockvercount;
  public NumericUpDown spn_blockhorcount;
  public NumericUpDown spn_blocktotalwidth;
  internal Label \u0001;
  public NumericUpDown spn_blocktotalheight;
  internal Label \u0002;
  public NumericUpDown spn_blockwidthstartoffset;
  public NumericUpDown spn_blockwidthendoffset;
  public NumericUpDown spn_blockheightendoffset;
  public NumericUpDown spn_blockheightstartoffset;
  public Label label1;
  public Label label2;
  public Label label3;
  public Label label6;
  public Label label7;
  public NumericUpDown spn_patternheight;
  public NumericUpDown spn_patternwidth;
  internal Label \u0003;
  internal Label \u0004;
  internal Label \u0005;
  public Label label12;
  public Label label13;
  public ListBox lst_idealwidth;
  public ListBox lst_idealheight;
  internal Label \u0006;
  internal TextBox \u0001;
  internal Panel \u0001;

  [CompilerGenerated]
  [SpecialName]
  public void remove_DataChanged(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_EventAll) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_EventAll) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_ParameterChanged(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_EventAll) this).\u0002;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_EventAll) this).\u0002, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_ParameterChanged(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_EventAll) this).\u0002;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_EventAll) this).\u0002, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_DataCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_EventAll) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_EventAll) this).\u0001, comparand + value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_DataCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_EventAll) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_EventAll) this).\u0001, comparand - value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  public void Init()
  {
    ((F_EventAll) this).PropertiesForm.Inited = false;
    ((F_DoorMat) this).spn_blockheightendoffset.Value = (Decimal) ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternHeightEndOffset;
    ((F_DoorMat) this).spn_blockheightstartoffset.Value = (Decimal) ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternHeightStartOffset;
    ((F_DoorMat) this).spn_blockwidthendoffset.Value = (Decimal) ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternWidthEndOffset;
    ((F_EventAll) this).spn_blockwidthstartoffset.Value = (Decimal) ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternWidthStartOffset;
    ((F_EventAll) this).spn_blocktotalwidth.Value = (Decimal) ((DrillMoveOptions) DrillCalcItem.varFoamRunSettings).BlockWidth;
    ((F_EventAll) this).spn_blocktotalheight.Value = (Decimal) ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).BlockHeight;
    ((F_DoorMat) this).spn_waveheight.Value = (Decimal) ((DrillMoveOptions) DrillCalcItem.varFoamRunSettings).SlicesHeight;
    ((F_DoorMat) this).\u0001.Text = ((DrillMoveOptions) DrillCalcItem.varFoamRunSettings).BlockName;
    ((F_DoorMat) this).spn_cutvel.Value = (Decimal) ((DrillMove) DrillCalcItem.varFoamSettings).CuttingFeed;
    ((F_DoorMat) this).spn_leadinvel.Value = (Decimal) ((DrillMove) DrillCalcItem.varFoamSettings).EntryFeed;
    ((F_DoorMat) this).spn_leadoutvel.Value = (Decimal) ((DrillMove) DrillCalcItem.varFoamSettings).LeaveFeed;
    ((F_DoorMat) this).spn_connectionvel.Value = (Decimal) ((DrillMove) DrillCalcItem.varFoamSettings).ConnectionFeed;
    ((F_EventAll) this).\u0004.BackColor = Color.Silver;
    ((F_EventAll) this).\u0003.BackColor = Color.Silver;
    if (((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).planeNames == FoamPlaneType.XZ)
      ((F_EventAll) this).\u0004.BackColor = Color.Gold;
    if (((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).planeNames == FoamPlaneType.YZ)
      ((F_EventAll) this).\u0003.BackColor = Color.Gold;
    ((F_EventAll) this).PropertiesForm.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
  }
}
