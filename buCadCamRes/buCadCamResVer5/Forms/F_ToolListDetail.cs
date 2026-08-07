// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Forms.F_ToolListDetail
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buEyeBaseVer5;
using devDept.Eyeshot.Control;
using ns8;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Forms;

public class F_ToolListDetail : Form
{
  public static List<string> Captions = new List<string>();
  public FormProperties PropertiesForm = new FormProperties();
  public List<ToolBase5> Tools = new List<ToolBase5>();
  public ToolBase5 SelectedTool = new ToolBase5();
  public Design Viewport = (Design) null;
  public int SelectedIndex = 0;
  public bool ShowCommand = true;
  public Timer timInit = new Timer();
  internal IContainer icontainer_0 = (IContainer) null;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;
  public Button btn_add;
  public Button btn_remove;
  public Button btn_edit;
  public Button btn_toolsort;
  public Button btn_tooldown;
  public Button btn_toolup;
  internal ImageList imageList_1;
  public TreeView tree_tools;
  public Panel pnl_viewport;
  public TextBox txt_detail;
  public Button btn_toolsave;
  public Button btn_toolsopen;
  internal Panel panel_0;
  internal Panel panel_1;

  public F_ToolListDetail()
  {
    Class5.smethod_27(this);
    this.timInit.Interval = 10;
    this.timInit.Tick += new EventHandler(this.timInit_Tick);
  }

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    if (!this.ShowCommand)
    {
      this.panel_0.Visible = false;
      this.panel_1.Left = this.panel_0.Left;
      this.panel_1.Width = this.Width - this.pnl_viewport.Width - 20;
    }
    else
    {
      this.panel_0.Visible = true;
      this.panel_1.Left = this.panel_0.Left + this.panel_0.Width + 1;
      this.panel_1.Width = this.Width - this.panel_0.Width - this.pnl_viewport.Width - 4;
    }
    Class5.smethod_129(this);
    if (this.SelectedIndex >= 0 & this.SelectedIndex <= this.tree_tools.Nodes.Count - 1)
    {
      this.tree_tools.SelectedNode = this.tree_tools.Nodes[this.SelectedIndex];
      this.tree_tools.Focus();
    }
    this.timInit.Enabled = true;
    this.PropertiesForm.Inited = true;
  }

  private void timInit_Tick(object sender, EventArgs e)
  {
    if (this.SelectedIndex >= 0 & this.SelectedIndex <= this.tree_tools.Nodes.Count - 1)
    {
      this.tree_tools.SelectedNode = this.tree_tools.Nodes[this.SelectedIndex];
      this.tree_tools.Focus();
    }
    this.timInit.Enabled = false;
  }

  internal void method_0(object sender, EventArgs e)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) sender;
    if (control2.Name == this.btn_ok.Name)
    {
      this.btn_ok.Focus();
      Class5.smethod_114(this);
      this.PropertiesForm.Result = DialogResult.OK;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.btn_cancel.Name)
    {
      this.PropertiesForm.Result = DialogResult.Cancel;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.btn_toolup.Name)
      clsInit.appCommand.cmdToolMoveUp();
    if (control2.Name == this.btn_tooldown.Name)
      clsInit.appCommand.cmdToolMoveDown();
    if (control2.Name == this.btn_toolsort.Name)
      clsInit.appCommand.cmdToolSort();
    if (control2.Name == this.btn_toolsopen.Name)
    {
      clsInit.appFiles.OpenToolFile(ref ccVars.Tools);
      clsInit.appCommand.ToolUpdate(true, ccVars.ToolGroupIndex, ccVars.ToolIndex, ref this.tree_tools);
    }
    if (control2.Name == this.btn_toolsave.Name)
      clsInit.appFiles.SaveToolFile(ccVars.Tools);
    if (control2.Name == this.btn_edit.Name)
    {
      ToolBase5 tool = new ToolBase5(ccVars.Tools[ccVars.ToolGroupIndex].Tools[ccVars.ToolIndex]);
      F_Tool fTool = new F_Tool();
      clsInit.cVector5.CreateModelControl(ref fTool.viewportLayout, clsVar.UnlockKey, new CreateModelProperties()
      {
        CoordinateSystemIconVisible = false,
        ViewCubeIconVisible = false,
        OrigineCaptionVisible = false,
        ToolBorVisible = false
      });
      fTool.viewportLayout.Entities.Clear();
      fTool.Properties.FormCloseMode = FormCloseModeType.Invisible;
      fTool.Tool = new ToolBase5(tool);
      fTool.Init();
      fTool.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fTool.ShowDialog();
      if (fTool.Properties.Result == DialogResult.OK)
      {
        ccVars.Tools[ccVars.ToolGroupIndex].Tools[ccVars.ToolIndex] = new ToolBase5(fTool.Tool);
        clsInit.appCommand.ToolUpdate(false, ccVars.ToolGroupIndex, ccVars.ToolIndex, ref this.tree_tools);
        clsInit.appCommand.DrawTool(fTool.Tool, clsVar.varDisplay.ToolPreviewDrawArbor, clsVar.varDisplay.ToolPreviewDrawHolder, ref clsItem.FrmToolList.Viewport);
        clsItem.FrmToolList.txt_detail.Text = clsInit.appCommand.ToolInfo(fTool.Tool, clsVar.varProgram.ToolPanelSettings);
        clsVar.varInterface.pathTool = AppPath.Tool;
        clsVar.varInterface.pathToolHolder = AppPath.ToolHolder;
        clsFiles.SaveParameter();
      }
    }
    if (control2.Name == this.btn_add.Name)
    {
      ToolBase5 tool = new ToolBase5(ccVars.Tools[ccVars.ToolGroupIndex].Tools[ccVars.ToolIndex]);
      F_Tool fTool = new F_Tool();
      clsInit.cVector5.CreateModelControl(ref fTool.viewportLayout, clsVar.UnlockKey, new CreateModelProperties()
      {
        CoordinateSystemIconVisible = false,
        ViewCubeIconVisible = false,
        OrigineCaptionVisible = false,
        ToolBorVisible = false
      });
      fTool.viewportLayout.Entities.Clear();
      fTool.Properties.FormCloseMode = FormCloseModeType.Invisible;
      fTool.Tool = new ToolBase5(tool);
      fTool.Init();
      fTool.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fTool.ShowDialog();
      if (fTool.Properties.Result == DialogResult.OK)
      {
        ccVars.Tools[ccVars.ToolGroupIndex].Tools.Add(new ToolBase5(fTool.Tool));
        clsInit.appCommand.ToolUpdate(true, 0, ccVars.ToolIndex, ref this.tree_tools);
        clsVar.varInterface.pathTool = AppPath.Tool;
        clsVar.varInterface.pathToolHolder = AppPath.ToolHolder;
        clsFiles.SaveParameter();
      }
    }
    if (!(control2.Name == this.btn_remove.Name) || this.SelectedIndex < 0 || buString5.MessageBoxQuestion(AppLanguage.CadCamMessages[10]) != DialogResult.Yes)
      return;
    ccVars.Tools[ccVars.ToolGroupIndex].Tools.RemoveAt(this.SelectedIndex);
    clsInit.appCommand.ToolUpdate(true, 0, ccVars.ToolIndex, ref this.tree_tools);
    clsFiles.SaveParameter();
  }

  internal void method_1(object sender, FormClosingEventArgs e)
  {
    if (this.PropertiesForm.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_2(object sender, EventArgs e) => this.method_0((object) this.btn_edit, e);

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
