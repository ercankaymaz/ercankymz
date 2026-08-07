// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Customer.DincMak.F_VShapePocket
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.Diamaker;
using buEyeBaseVer5.Forms.Foam;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Customer.DincMak;

public class F_VShapePocket : Form
{
  public TextBox txt_info;
  internal Label \u0012;
  public Label label29;
  public Panel pnl_controlspattern;
  internal CheckBox \u0001;
  internal CheckBox \u0002;
  public static byte f003234;
  [CompilerGenerated]
  internal OkCommandWithTwoDataEventHandler \u0001;
  public FormProperties PropertiesForm;
  public Image refImage;
  public string Path;
  public string FileName;
  public bool KeepRatio;
  public bool MoveEntities;
  public bool MoveReverse;
  public MinMaxType MoveRef;
  public List<string> ExtensionList;
  private List<string> \u0001;
  private int \u0001;
  private int \u0002;
  private string \u0001;
  private bool \u0001;
  internal List<string> \u0002;
  private System.Windows.Forms.Timer \u0001;
  private IContainer \u0001;
  internal TextBox \u0001;
  internal Label \u0001;
  internal Panel \u0001;
  internal Label \u0002;
  internal Panel \u0002;
  internal Button \u0001;
  internal ImageList \u0001;
  internal Button \u0002;
  internal Button \u0003;
  internal Button \u0004;

  public F_VShapePocket()
  {
    ((F_DiamakerGrindVShape) this).PropertiesForm = new FormProperties();
    ((F_DiamakerGrindVShape) this).FoamSize = new SizeObject();
    ((F_DiamakerGrindVShape) this).ValueChanging = false;
    ((F_DiamakerGrindVShape) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_FoamWaveForm) this);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_DataChanged(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_DiamakerGrindVShape) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_DiamakerGrindVShape) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_DataChanged(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_DiamakerGrindVShape) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_DiamakerGrindVShape) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_ParameterChanged(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_DiamakerGrindVShape) this).\u0002;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_DiamakerGrindVShape) this).\u0002, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_ParameterChanged(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_DiamakerGrindVShape) this).\u0002;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_DiamakerGrindVShape) this).\u0002, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_DataCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_DiamakerGrindVShape) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_DiamakerGrindVShape) this).\u0001, comparand + value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_DataCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_DiamakerGrindVShape) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_DiamakerGrindVShape) this).\u0001, comparand - value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  public void Init()
  {
    ((F_DiamakerGrindVShape) this).PropertiesForm.Inited = false;
    ((F_DiamakerGrindVShape) this).spn_blockheightendoffset.Value = (Decimal) ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternHeightEndOffset;
    ((F_DiamakerGrindVShape) this).spn_blockheightstartoffset.Value = (Decimal) ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternHeightStartOffset;
    ((F_DiamakerGrindVShape) this).spn_blockwidthendoffset.Value = (Decimal) ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternWidthEndOffset;
    ((F_DiamakerGrindVShape) this).spn_blockwidthstartoffset.Value = (Decimal) ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternWidthStartOffset;
    ((F_DiamakerGrindVShape) this).spn_blocktotalwidth.Value = (Decimal) ((DrillMoveOptions) DrillCalcItem.varFoamRunSettings).BlockWidth;
    ((F_DiamakerGrindVShape) this).spn_blocktotalheight.Value = (Decimal) ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).BlockHeight;
    ((F_DiamakerGrindVShape) this).spn_wavewidth.Value = (Decimal) ((DrillMoveOptions) DrillCalcItem.varFoamRunSettings).WaveFormShapeCommonWidth;
    ((F_DiamakerGrindVShape) this).spn_waveheight.Value = (Decimal) ((DrillMoveOptions) DrillCalcItem.varFoamRunSettings).WaveFormShapeCommonHeight;
    ((F_DiamakerGrindVShape) this).spn_wavebaseheight.Value = (Decimal) ((DrillMoveOptions) DrillCalcItem.varFoamRunSettings).WaveFormShapeCommonBaseHeight;
    ((F_DiamakerGrindVShape) this).spn_round.Value = (Decimal) ((DrillMoveOptions) DrillCalcItem.varFoamRunSettings).WaveFormShapeCommonRoundRad;
    ((F_DiamakerGrindVShape) this).spn_chamfer.Value = (Decimal) ((DrillMoveOptions) DrillCalcItem.varFoamRunSettings).WaveFormShapeCommonChamferLen;
    ((F_DiamakerGrindVShape) this).spn_repeatcount.Value = (Decimal) ((DrillMoveOptions) DrillCalcItem.varFoamRunSettings).WaveFormRepeatCount;
    ((F_DiamakerGrindVShape) this).spn_space.Value = (Decimal) ((DrillMoveOptions) DrillCalcItem.varFoamRunSettings).WaveFormSpace;
    ((F_DiamakerGrindVShape) this).\u0001.Text = ((DrillMoveOptions) DrillCalcItem.varFoamRunSettings).BlockName;
    ((F_DiamakerGrindVShape) this).spn_cutvel.Value = (Decimal) ((DrillMove) DrillCalcItem.varFoamSettings).CuttingFeed;
    ((F_DiamakerGrindVShape) this).spn_leadinvel.Value = (Decimal) ((DrillMove) DrillCalcItem.varFoamSettings).EntryFeed;
    ((F_DiamakerGrindVShape) this).spn_leadoutvel.Value = (Decimal) ((DrillMove) DrillCalcItem.varFoamSettings).LeaveFeed;
    ((F_DiamakerGrindVShape) this).spn_connectionvel.Value = (Decimal) ((DrillMove) DrillCalcItem.varFoamSettings).ConnectionFeed;
    ((F_DiamakerGrindVShape) this).\u0004.BackColor = Color.Silver;
    ((F_DiamakerGrindVShape) this).\u0003.BackColor = Color.Silver;
    if (((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).planeNames == FoamPlaneType.XZ)
      ((F_DiamakerGrindVShape) this).\u0004.BackColor = Color.Gold;
    if (((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).planeNames == FoamPlaneType.YZ)
      ((F_DiamakerGrindVShape) this).\u0003.BackColor = Color.Gold;
    ((F_DiamakerGrindVShape) this).PropertiesForm.Inited = true;
  }
}
