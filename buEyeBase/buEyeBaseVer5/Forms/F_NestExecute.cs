// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_NestExecute
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_NestExecute : Form
{
  internal buGroup \u0002;
  internal buGround \u0002;
  public buSpin spn_pipediameter;
  internal buGroup \u0003;
  public buSpin spn_blockwidth;
  public buSpin spn_blcokheight;
  public buSpin spn_blockdepth;
  internal buGroup \u0004;
  public buSpin spn_diskdiameter;
  public buSpin spn_diskblockwidth;
  public buSpin spn_diskHeight;
  public buSpin spn_diskblocklength;
  public buSpin spn_diskthickness;
  public TreeView treeView_bend;
  public buButton btn_open;
  public buButton btn_cancel;
  public buButton btn_ok;
  public buButton btnn_remove;
  public buButton btn_add;
  public buButton btn_save;
  public Panel pnl_viewport;

  [CompilerGenerated]
  [SpecialName]
  public void remove_DrawResult(OkCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithDataEventHandler dataEventHandler = ((F_NestPartAddV2) this).\u0001;
    OkCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithDataEventHandler>(ref ((F_NestPartAddV2) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_Updated(OkCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithDataEventHandler dataEventHandler = ((F_NestPartAddV2) this).\u0002;
    OkCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithDataEventHandler>(ref ((F_NestPartAddV2) this).\u0002, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_Updated(OkCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithDataEventHandler dataEventHandler = ((F_NestPartAddV2) this).\u0002;
    OkCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithDataEventHandler>(ref ((F_NestPartAddV2) this).\u0002, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_Command(ClickSenderDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    ClickSenderDataEventHandler dataEventHandler = ((F_NestPartAddV2) this).\u0001;
    ClickSenderDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<ClickSenderDataEventHandler>(ref ((F_NestPartAddV2) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_Command(ClickSenderDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    ClickSenderDataEventHandler dataEventHandler = ((F_NestPartAddV2) this).\u0001;
    ClickSenderDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<ClickSenderDataEventHandler>(ref ((F_NestPartAddV2) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public void Init()
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_NestPartAddV2) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_NestPartAddV2) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_NestPartAddV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_NestPartAddV2) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] KeyEventArgs obj1)
  {
    ((F_PanelCutNestSheetPartList) this).\u0001 = obj1.Control;
  }

  internal void \u0002([In] object obj0, [In] KeyEventArgs obj1)
  {
    ((F_PanelCutNestSheetPartList) this).\u0001 = false;
  }
}
