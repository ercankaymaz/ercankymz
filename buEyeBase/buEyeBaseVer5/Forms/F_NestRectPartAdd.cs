// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_NestRectPartAdd
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_NestRectPartAdd : Form
{
  public Button btn_ok;
  public Button btn_add;
  public Button btn_remove;
  public Button btn_down;
  public Button btn_up;
  public Button btn_copy;
  public Button btn_save;
  public Button btn_open;
  public Button btn_update;
  internal Panel \u0001;
  internal Label \u0001;
  internal Label \u0002;
  internal Label \u0003;
  internal NumericUpDown \u0001;
  internal Label \u0004;
  internal NumericUpDown \u0002;
  internal Label \u0005;
  internal ComboBox \u0001;
  internal Label \u0006;
  internal NumericUpDown \u0003;
  internal Label \u0007;
  internal NumericUpDown \u0004;
  internal Label \u0008;
  internal NumericUpDown \u0005;
  internal Label \u000E;
  internal NumericUpDown \u0006;
  internal TextBox \u0001;
  internal Label \u000F;
  public Button btn_orderremove;
  public Button btn_orderadd;
  internal ListBox \u0002;
  internal Panel \u0002;
  public Button btn_namecancel;
  public Button btn_nameok;
  internal Panel \u0003;
  public Button btn_codetypecancel;
  public Button btn_codetypeok;
  internal Label \u0010;
  internal ComboBox \u0002;
  internal Label \u0011;
  internal ComboBox \u0003;
  internal TextBox \u0002;
  internal Label \u0012;
  internal ImageList \u0002;
  internal Label \u0013;
  internal CheckBox \u0001;
  internal Label \u0014;
  internal CheckBox \u0002;

  [CompilerGenerated]
  [SpecialName]
  public void add_PreviewPressed(OkCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithDataEventHandler dataEventHandler = ((F_PanelCutNestSheetPartList) this).\u0001;
    OkCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithDataEventHandler>(ref ((F_PanelCutNestSheetPartList) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_PreviewPressed(OkCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithDataEventHandler dataEventHandler = ((F_PanelCutNestSheetPartList) this).\u0001;
    OkCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithDataEventHandler>(ref ((F_PanelCutNestSheetPartList) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_SendPressed(OkCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithDataEventHandler dataEventHandler = ((F_BendingRotaryDisk) this).\u0002;
    OkCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithDataEventHandler>(ref ((F_BendingRotaryDisk) this).\u0002, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_SendPressed(OkCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithDataEventHandler dataEventHandler = ((F_BendingRotaryDisk) this).\u0002;
    OkCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithDataEventHandler>(ref ((F_BendingRotaryDisk) this).\u0002, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_Applied(OkCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithDataEventHandler dataEventHandler = ((F_BendingRotaryDisk) this).\u0003;
    OkCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithDataEventHandler>(ref ((F_BendingRotaryDisk) this).\u0003, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_Applied(OkCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithDataEventHandler dataEventHandler = ((F_BendingRotaryDisk) this).\u0003;
    OkCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithDataEventHandler>(ref ((F_BendingRotaryDisk) this).\u0003, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_StopPressed(OkCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandEventHandler commandEventHandler = ((F_BendingRotaryDisk) this).\u0001;
    OkCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<OkCommandEventHandler>(ref ((F_BendingRotaryDisk) this).\u0001, comparand + value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_StopPressed(OkCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandEventHandler commandEventHandler = ((F_BendingRotaryDisk) this).\u0001;
    OkCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<OkCommandEventHandler>(ref ((F_BendingRotaryDisk) this).\u0001, comparand - value, comparand);
    }
    while (commandEventHandler != comparand);
  }
}
