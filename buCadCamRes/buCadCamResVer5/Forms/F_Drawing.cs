// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Forms.F_Drawing
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Geometry;
using devDept.Graphics;
using ns8;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Forms;

public class F_Drawing : Form
{
  public ViewportCC viewportcad;
  private ToolStripMenuItem mnu_viewtop = (ToolStripMenuItem) null;
  private ToolStripMenuItem mnu_viewfront = (ToolStripMenuItem) null;
  private ToolStripMenuItem mnu_viewback = (ToolStripMenuItem) null;
  private ToolStripMenuItem mnu_viewleft = (ToolStripMenuItem) null;
  private ToolStripMenuItem mnu_viewright = (ToolStripMenuItem) null;
  private ToolStripMenuItem mnu_viewiso = (ToolStripMenuItem) null;
  private ToolStripMenuItem mnu_viewzoomfit = (ToolStripMenuItem) null;
  private ToolStripMenuItem mnu_viewzoomin = (ToolStripMenuItem) null;
  private ToolStripMenuItem mnu_viewzoomout = (ToolStripMenuItem) null;
  private ToolStripMenuItem mnu_cancel = (ToolStripMenuItem) null;
  private ToolStripMenuItem mnu_properties = (ToolStripMenuItem) null;
  private ToolStripMenuItem mnu_ProfileAddProfile = (ToolStripMenuItem) null;
  private ToolStripMenuItem mnu_ProfileAddOperation = (ToolStripMenuItem) null;
  private ToolStripSeparator mnu_ProfileSeperator = (ToolStripSeparator) null;
  private ToolStripSeparator mnu_separatorcancel = (ToolStripSeparator) null;
  private ToolStripSeparator mnu_PropertiesSeperator = (ToolStripSeparator) null;
  private Timer timer_0 = new Timer();
  internal IContainer icontainer_0 = (IContainer) null;
  public ContextMenuStrip contextMenu_rightclick;
  public ToolStripMenuItem mnu_finish;
  public ToolStripMenuItem mnu_undo;
  public ToolStripMenuItem mnu_closedrawing;
  internal ToolStripSeparator toolStripSeparator_0;
  public ToolStripMenuItem mnu_addtolayer;
  public Panel pnl_val1;
  public Label lbl_val1_1;
  public Label lbl_val1;
  public Label lbl_information;
  public Label lbl_tooltip;
  public Panel pnl_val3;
  public Label lbl_val3;
  public Panel pnl_val2;
  public Label lbl_val2;
  public Panel pnl_coords;
  public Label lbl_z;
  public Label lbl_y;
  public Label lbl_x;
  public Panel pnl_buttons;
  public Button btn_undo;
  public Button btn_cancel;
  public Button btn_ok;
  public NumericUpDown spn_val1_1;
  public NumericUpDown spn_val1;
  public NumericUpDown spn_val3;
  public NumericUpDown spn_val2;
  public NumericUpDown spn_z;
  public NumericUpDown spn_y;
  public NumericUpDown spn_x;
  internal ImageList imageList_0;
  internal ToolStripMenuItem toolStripMenuItem_0;
  internal ToolStripSeparator toolStripSeparator_1;

  public F_Drawing()
  {
    Class5.smethod_32(this);
    this.viewportcad = new ViewportCC();
    this.viewportcad.InitializeViewports();
    this.viewportcad.CreateControl();
    this.viewportcad.CreateGraphics();
    this.viewportcad.SetView(viewType.Top);
    this.viewportcad.AllowDrop = true;
    this.viewportcad.DragOver += new DragEventHandler(this.viewportcad_DragOver);
    this.viewportcad.DragEnter += new DragEventHandler(this.viewportcad_DragEnter);
    this.viewportcad.DragDrop += new DragEventHandler(this.viewportcad_DragDrop);
    this.viewportcad.SelectionChanged += new Workspace.SelectionChangedEventHandler(this.viewportcad_SelectionChanged);
    this.viewportcad.Leave += new EventHandler(this.viewportcad_Leave);
    this.viewportcad.ViewChanged += new Workspace.ViewChangedEventHandler(this.viewportcad_ViewChanged);
    DisplayModeSettingsRendered settingsRendered = new DisplayModeSettingsRendered(false, edgeColorMethodType.EntityColor, Color.Black, 1f, 2f, silhouettesDrawingType.LastFrame, false, shadowType.None, (Image) null, false, false, 0.3f, realisticShadowQualityType.Low);
    DisplayModeSettingsShaded modeSettingsShaded = new DisplayModeSettingsShaded(false, edgeColorMethodType.EntityColor, Color.Black, 2f, 2f, silhouettesDrawingType.Never, false, shadowType.None);
    DisplayModeSettingsFlat modeSettingsFlat = new DisplayModeSettingsFlat(true, edgeColorMethodType.EntityColor, Color.Black, 2f, 2f, silhouettesDrawingType.Never, false);
    modeSettingsFlat.ShowInternalWires = false;
    modeSettingsFlat.ShowEdges = true;
    modeSettingsFlat.EdgeColorMethod = edgeColorMethodType.SingleColor;
    this.viewportcad.Rendered.ShowEdges = false;
    this.viewportcad.Rendered.ShowInternalWires = false;
    this.viewportcad.Rendered.RealisticShadowQuality = realisticShadowQualityType.Low;
    this.viewportcad.Shaded.ShowEdges = false;
    this.viewportcad.Rendered = settingsRendered;
    this.viewportcad.Shaded = modeSettingsShaded;
    this.viewportcad.Flat = modeSettingsFlat;
    this.viewportcad.Viewports[0].CoordinateSystemIcon.Lighting = true;
    this.viewportcad.Viewports[0].ViewCubeIcon.Lighting = true;
    this.viewportcad.Viewports[0].OriginSymbol.Lighting = true;
    this.viewportcad.WaitCursorMode = waitCursorType.Never;
    this.viewportcad.CurrentBlock.Units = linearUnitsType.Millimeters;
    this.viewportcad.Rendered.ShowEdges = false;
    this.viewportcad.Rendered.PlanarReflections = false;
    this.viewportcad.ShortcutKeys.CopySelection = Keys.None;
    this.viewportcad.ShortcutKeys.CutSelection = Keys.None;
    this.viewportcad.ShortcutKeys.DeleteSelection = Keys.None;
    this.viewportcad.ShortcutKeys.GroupSelection = Keys.None;
    this.viewportcad.ShortcutKeys.InvertSelection = Keys.None;
    this.viewportcad.ShortcutKeys.NavigationBackward = Keys.None;
    this.viewportcad.ShortcutKeys.NavigationDown = Keys.None;
    this.viewportcad.ShortcutKeys.NavigationForward = Keys.None;
    this.viewportcad.ShortcutKeys.NavigationLeft = Keys.None;
    this.viewportcad.ShortcutKeys.NavigationRight = Keys.None;
    this.viewportcad.ShortcutKeys.NavigationUp = Keys.None;
    this.viewportcad.ShortcutKeys.PanDown = Keys.None;
    this.viewportcad.ShortcutKeys.PanLeft = Keys.None;
    this.viewportcad.ShortcutKeys.PanRight = Keys.None;
    this.viewportcad.ShortcutKeys.PanUp = Keys.None;
    this.viewportcad.ShortcutKeys.PasteSelection = Keys.None;
    this.viewportcad.ShortcutKeys.RotateDown = Keys.None;
    this.viewportcad.ShortcutKeys.RotateLeft = Keys.None;
    this.viewportcad.ShortcutKeys.RotateRight = Keys.None;
    this.viewportcad.ShortcutKeys.RotateUp = Keys.None;
    this.viewportcad.ShortcutKeys.SelectAll = Keys.None;
    this.viewportcad.ShortcutKeys.UngroupSelection = Keys.None;
    this.viewportcad.ShortcutKeys.ZoomFit = Keys.None;
    this.viewportcad.ShortcutKeys.ZoomIn = Keys.None;
    this.viewportcad.ShortcutKeys.ZoomOut = Keys.None;
    this.viewportcad.ContextMenuStrip = this.contextMenu_rightclick;
    this.viewportcad.CurrentBlock.Units = linearUnitsType.Millimeters;
    this.viewportcad.ShortcutKeys.CopySelection = Keys.None;
    this.viewportcad.ShortcutKeys.CutSelection = Keys.None;
    this.viewportcad.ShortcutKeys.DeleteSelection = Keys.None;
    this.viewportcad.ShortcutKeys.GroupSelection = Keys.None;
    this.viewportcad.Dock = DockStyle.Fill;
    this.mnu_finish.Image = this.imageList_0.Images[13];
    this.mnu_closedrawing.Image = this.imageList_0.Images[14];
    this.mnu_undo.Image = this.imageList_0.Images[15];
    this.mnu_addtolayer.Image = this.imageList_0.Images[11];
    this.toolStripMenuItem_0.Image = this.imageList_0.Images[12];
    this.mnu_viewtop = new ToolStripMenuItem();
    this.mnu_viewtop.Text = $"{buLangTranslate.preDef.Top} {buLangTranslate.preDef.View}";
    this.mnu_viewtop.Name = nameof (mnu_viewtop);
    this.mnu_viewtop.Image = this.imageList_0.Images[0];
    this.mnu_viewtop.Click += new EventHandler(this.mnu_cancel_Click);
    this.contextMenu_rightclick.Items.Add((ToolStripItem) this.mnu_viewtop);
    this.mnu_viewfront = new ToolStripMenuItem();
    this.mnu_viewfront.Text = $"{buLangTranslate.preDef.Front} {buLangTranslate.preDef.View}";
    this.mnu_viewfront.Name = nameof (mnu_viewfront);
    this.mnu_viewfront.Image = this.imageList_0.Images[2];
    this.mnu_viewfront.Click += new EventHandler(this.mnu_cancel_Click);
    this.contextMenu_rightclick.Items.Add((ToolStripItem) this.mnu_viewfront);
    this.mnu_viewback = new ToolStripMenuItem();
    this.mnu_viewback.Text = $"{buLangTranslate.preDef.Back} {buLangTranslate.preDef.View}";
    this.mnu_viewback.Name = nameof (mnu_viewback);
    this.mnu_viewback.Image = this.imageList_0.Images[3];
    this.mnu_viewback.Click += new EventHandler(this.mnu_cancel_Click);
    this.contextMenu_rightclick.Items.Add((ToolStripItem) this.mnu_viewback);
    this.mnu_viewleft = new ToolStripMenuItem();
    this.mnu_viewleft.Text = $"{buLangTranslate.preDef.Left} {buLangTranslate.preDef.View}";
    this.mnu_viewleft.Name = nameof (mnu_viewleft);
    this.mnu_viewleft.Image = this.imageList_0.Images[4];
    this.mnu_viewleft.Click += new EventHandler(this.mnu_cancel_Click);
    this.contextMenu_rightclick.Items.Add((ToolStripItem) this.mnu_viewleft);
    this.mnu_viewright = new ToolStripMenuItem();
    this.mnu_viewright.Text = $"{buLangTranslate.preDef.Top} {buLangTranslate.preDef.View}";
    this.mnu_viewright.Name = nameof (mnu_viewright);
    this.mnu_viewright.Image = this.imageList_0.Images[5];
    this.mnu_viewright.Click += new EventHandler(this.mnu_cancel_Click);
    this.contextMenu_rightclick.Items.Add((ToolStripItem) this.mnu_viewright);
    this.mnu_viewiso = new ToolStripMenuItem();
    this.mnu_viewiso.Text = $"{buLangTranslate.preDef.Isometric} {buLangTranslate.preDef.View}";
    this.mnu_viewiso.Name = nameof (mnu_viewiso);
    this.mnu_viewiso.Image = this.imageList_0.Images[6];
    this.mnu_viewiso.Click += new EventHandler(this.mnu_cancel_Click);
    this.contextMenu_rightclick.Items.Add((ToolStripItem) this.mnu_viewiso);
    this.mnu_viewzoomfit = new ToolStripMenuItem();
    this.mnu_viewzoomfit.Text = buLangTranslate.preDef.ZoomFit;
    this.mnu_viewzoomfit.Name = nameof (mnu_viewzoomfit);
    this.mnu_viewzoomfit.Image = this.imageList_0.Images[8];
    this.mnu_viewzoomfit.Click += new EventHandler(this.mnu_cancel_Click);
    this.contextMenu_rightclick.Items.Add((ToolStripItem) this.mnu_viewzoomfit);
    this.mnu_viewzoomin = new ToolStripMenuItem();
    this.mnu_viewzoomin.Text = buLangTranslate.preDef.ZoomIn;
    this.mnu_viewzoomin.Name = nameof (mnu_viewzoomin);
    this.mnu_viewzoomin.Image = this.imageList_0.Images[9];
    this.mnu_viewzoomin.Click += new EventHandler(this.mnu_cancel_Click);
    this.contextMenu_rightclick.Items.Add((ToolStripItem) this.mnu_viewzoomin);
    this.mnu_viewzoomout = new ToolStripMenuItem();
    this.mnu_viewzoomout.Text = buLangTranslate.preDef.ZoomOut;
    this.mnu_viewzoomout.Name = nameof (mnu_viewzoomout);
    this.mnu_viewzoomout.Image = this.imageList_0.Images[10];
    this.mnu_viewzoomout.Click += new EventHandler(this.mnu_cancel_Click);
    this.contextMenu_rightclick.Items.Add((ToolStripItem) this.mnu_viewzoomout);
    if (clsVar.appModes_0.ProfileMode.Enable)
    {
      this.mnu_ProfileSeperator = new ToolStripSeparator();
      this.mnu_ProfileSeperator.Size = new Size(this.contextMenu_rightclick.Width, 6);
      this.mnu_ProfileSeperator.Name = nameof (mnu_ProfileSeperator);
      this.mnu_ProfileAddProfile = new ToolStripMenuItem();
      this.mnu_ProfileAddProfile.Text = $"{buLangTranslate.preDef.Profile} {buLangTranslate.preDef.Add}";
      this.mnu_ProfileAddProfile.Name = nameof (mnu_ProfileAddProfile);
      this.mnu_ProfileAddProfile.Image = this.imageList_0.Images[18];
      this.mnu_ProfileAddProfile.Click += new EventHandler(this.mnu_cancel_Click);
      this.mnu_ProfileAddOperation = new ToolStripMenuItem();
      this.mnu_ProfileAddOperation.Text = $"{buLangTranslate.preDef.Operation} {buLangTranslate.preDef.Add}";
      this.mnu_ProfileAddOperation.Name = nameof (mnu_ProfileAddOperation);
      this.mnu_ProfileAddOperation.Image = this.imageList_0.Images[17];
      this.mnu_ProfileAddOperation.Click += new EventHandler(this.mnu_cancel_Click);
      this.contextMenu_rightclick.Items.Add((ToolStripItem) this.mnu_ProfileSeperator);
      this.contextMenu_rightclick.Items.Add((ToolStripItem) this.mnu_ProfileAddProfile);
      this.contextMenu_rightclick.Items.Add((ToolStripItem) this.mnu_ProfileAddOperation);
    }
    this.mnu_PropertiesSeperator = new ToolStripSeparator();
    this.mnu_PropertiesSeperator.Size = new Size(this.contextMenu_rightclick.Width, 6);
    this.mnu_PropertiesSeperator.Name = nameof (mnu_PropertiesSeperator);
    this.contextMenu_rightclick.Items.Add((ToolStripItem) this.mnu_PropertiesSeperator);
    this.mnu_properties = new ToolStripMenuItem();
    this.mnu_properties.Text = buLangTranslate.preDef.Properties;
    this.mnu_properties.Name = nameof (mnu_properties);
    this.mnu_properties.Image = this.imageList_0.Images[16 /*0x10*/];
    this.mnu_properties.Click += new EventHandler(this.mnu_cancel_Click);
    this.contextMenu_rightclick.Items.Add((ToolStripItem) this.mnu_properties);
    this.mnu_separatorcancel = new ToolStripSeparator();
    this.mnu_separatorcancel.Size = new Size(this.contextMenu_rightclick.Width, 6);
    this.mnu_separatorcancel.Name = nameof (mnu_separatorcancel);
    this.contextMenu_rightclick.Items.Add((ToolStripItem) this.mnu_separatorcancel);
    this.mnu_cancel = new ToolStripMenuItem();
    this.mnu_cancel.Text = buLangTranslate.preDef.Cancel;
    this.mnu_cancel.Name = nameof (mnu_cancel);
    this.mnu_cancel.Image = this.imageList_0.Images[7];
    this.mnu_cancel.Click += new EventHandler(this.mnu_cancel_Click);
    this.contextMenu_rightclick.Items.Add((ToolStripItem) this.mnu_cancel);
    this.Controls.Add((System.Windows.Forms.Control) this.viewportcad);
    this.timer_0.Interval = 2000;
    this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
  }

  public void Init()
  {
    this.btn_ok.Click += new EventHandler(clsInit.appCommand.ViewportButtonsClick);
    this.btn_cancel.Click += new EventHandler(clsInit.appCommand.ViewportButtonsClick);
    this.btn_undo.Click += new EventHandler(clsInit.appCommand.ViewportButtonsClick);
    this.UpdateForm();
    this.timer_0.Enabled = true;
  }

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    try
    {
      clsVar.CancelFromQuit = false;
      if (ccVars.Pages.Count > 0 & ccVars.PageIndex <= ccVars.Pages.Count - 1 & !clsVar.varFile.DontAskSaveToFileMesssafeWhileClosing && ccVars.Pages[ccVars.PageIndex].Changed)
      {
        DialogResult dialogResult = buString.MessageBoxQuestionYesNoCancel($"{ccVars.Pages[ccVars.PageIndex].Form.Text} - {AppLanguage.CadCamMessages[4]}");
        if (dialogResult == DialogResult.Yes)
        {
          if (ccVars.Pages[ccVars.PageIndex].FileName.Length > 2)
          {
            FileInfo fileInfo = new FileInfo(ccVars.Pages[ccVars.PageIndex].FileName);
            if (fileInfo.Exists)
            {
              if (fileInfo.Extension != ".bucad")
                ccVars.Pages[ccVars.PageIndex].FileName = "";
            }
            else
              ccVars.Pages[ccVars.PageIndex].FileName = "";
          }
          clsInit.appCommand.cmdFileSave();
        }
        if (dialogResult == DialogResult.Cancel)
        {
          clsVar.CancelFromQuit = true;
          e.Cancel = true;
        }
        if (dialogResult == DialogResult.No & ccVars.MainFormClosing)
          e.Cancel = true;
      }
      GC.Collect();
    }
    catch (Exception ex)
    {
    }
  }

  internal void method_1(object sender, FormClosedEventArgs e)
  {
    clsInit.appCommand.PageClose(ccVars.PageIndex);
  }

  internal void method_2(object sender, EventArgs e)
  {
    ccVars.PageIndex = Convert.ToInt32(this.Tag);
    clsInit.appCommand.LayersUpdate(ccVars.Pages[ccVars.PageIndex].Layers, true, 0);
    buVector5.baseModel = (Design) this.viewportcad;
  }

  internal void method_3(object sender, EventArgs e)
  {
    this.spn_val1.KeyDown += new KeyEventHandler(clsInit.appCommand.SpinDrawData_KeyDown);
    this.spn_val1_1.KeyDown += new KeyEventHandler(clsInit.appCommand.SpinDrawData_KeyDown);
    this.spn_val2.KeyDown += new KeyEventHandler(clsInit.appCommand.SpinDrawData_KeyDown);
    this.spn_val3.KeyDown += new KeyEventHandler(clsInit.appCommand.SpinDrawData_KeyDown);
    this.spn_x.KeyDown += new KeyEventHandler(clsInit.appCommand.SpinDrawData_KeyDown);
    this.spn_y.KeyDown += new KeyEventHandler(clsInit.appCommand.SpinDrawData_KeyDown);
    this.spn_z.KeyDown += new KeyEventHandler(clsInit.appCommand.SpinDrawData_KeyDown);
    if (!clsVar.varView.AddViewButtonsToRightClickMenu)
      return;
    ToolStripMenuItem toolStripMenuItem1 = new ToolStripMenuItem();
    toolStripMenuItem1.Name = "mnu_ViewTop";
    toolStripMenuItem1.Text = "View Top";
    toolStripMenuItem1.Image = this.imageList_0.Images[0];
    toolStripMenuItem1.Click += new EventHandler(this.mnu_cancel_Click);
    ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem();
    toolStripMenuItem2.Name = "mnu_ViewBottom";
    toolStripMenuItem2.Text = "View Bottom";
    toolStripMenuItem2.Image = this.imageList_0.Images[1];
    toolStripMenuItem1.Click += new EventHandler(this.mnu_cancel_Click);
    ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem();
    toolStripMenuItem3.Name = "mnu_ViewFront";
    toolStripMenuItem3.Text = "View Front";
    toolStripMenuItem3.Image = this.imageList_0.Images[2];
    toolStripMenuItem3.Click += new EventHandler(this.mnu_cancel_Click);
    ToolStripMenuItem toolStripMenuItem4 = new ToolStripMenuItem();
    toolStripMenuItem4.Name = "mnu_ViewBack";
    toolStripMenuItem4.Text = "View Back";
    toolStripMenuItem4.Image = this.imageList_0.Images[3];
    toolStripMenuItem4.Click += new EventHandler(this.mnu_cancel_Click);
    ToolStripMenuItem toolStripMenuItem5 = new ToolStripMenuItem();
    toolStripMenuItem5.Name = "mnu_ViewLeft";
    toolStripMenuItem5.Text = "View Left";
    toolStripMenuItem5.Image = this.imageList_0.Images[4];
    toolStripMenuItem5.Click += new EventHandler(this.mnu_cancel_Click);
    ToolStripMenuItem toolStripMenuItem6 = new ToolStripMenuItem();
    toolStripMenuItem6.Name = "mnu_ViewRight";
    toolStripMenuItem6.Text = "View Right";
    toolStripMenuItem6.Image = this.imageList_0.Images[5];
    toolStripMenuItem6.Click += new EventHandler(this.mnu_cancel_Click);
    ToolStripMenuItem toolStripMenuItem7 = new ToolStripMenuItem();
    toolStripMenuItem7.Name = "mnu_ViewIso";
    toolStripMenuItem7.Text = "View Iso";
    toolStripMenuItem7.Image = this.imageList_0.Images[6];
    toolStripMenuItem7.Click += new EventHandler(this.mnu_cancel_Click);
    ToolStripSeparator toolStripSeparator = new ToolStripSeparator();
    toolStripMenuItem7.Name = "mnu_Separator1";
    this.contextMenu_rightclick.Items.Add((ToolStripItem) toolStripSeparator);
    this.contextMenu_rightclick.Items.Add((ToolStripItem) toolStripMenuItem1);
    this.contextMenu_rightclick.Items.Add((ToolStripItem) toolStripMenuItem2);
    this.contextMenu_rightclick.Items.Add((ToolStripItem) toolStripMenuItem3);
    this.contextMenu_rightclick.Items.Add((ToolStripItem) toolStripMenuItem4);
    this.contextMenu_rightclick.Items.Add((ToolStripItem) toolStripMenuItem5);
    this.contextMenu_rightclick.Items.Add((ToolStripItem) toolStripMenuItem6);
    this.contextMenu_rightclick.Items.Add((ToolStripItem) toolStripMenuItem7);
  }

  private void timer_0_Tick(object sender, EventArgs e)
  {
    if ((this.viewportcad == null ? 0 : (this.viewportcad.IsHandleCreated ? 1 : 0)) == 0)
      return;
    clsInit.appCommand.UpdateViewportsMouseConfig();
    this.timer_0.Enabled = false;
  }

  public void UpdateForm()
  {
    try
    {
      this.viewportcad.AssemblySelectionMode = Workspace.assemblySelectionType.Branch;
      this.viewportcad.CursorTypes[cursorType.Default] = Cursors.Arrow;
      this.viewportcad.CursorTypes[cursorType.Pick] = Cursors.Arrow;
      if (clsVar.varMouse.MouseCursor == MouseCursorType.Hand)
        this.viewportcad.CursorTypes[cursorType.Default] = Cursors.Hand;
      this.viewportcad.Viewports[0].Background = new BackgroundSettings(backgroundStyleType.LinearGradient, clsVar.varDisplay.ColorViewportBottom, clsVar.varDisplay.ColorViewportIntermediate, clsVar.varDisplay.ColorViewportTop, 0.75, (Image) null, colorThemeType.Auto, 0.3);
      this.viewportcad.Viewports[0].Pan.MouseButton = new MouseButton(buConversion5.MouseButtonConv(clsVar.varMouse.PanConfigration.Button), buConversion5.KeyConv(clsVar.varMouse.PanConfigration.Key));
      this.viewportcad.Viewports[0].Rotate.MouseButton = new MouseButton(buConversion5.MouseButtonConv(clsVar.varMouse.RotateConfigration.Button), buConversion5.KeyConv(clsVar.varMouse.RotateConfigration.Key));
      this.viewportcad.Viewports[0].Zoom.MouseButton = new MouseButton(buConversion5.MouseButtonConv(clsVar.varMouse.ZoomConfigration.Button), buConversion5.KeyConv(clsVar.varMouse.ZoomConfigration.Key));
      if (clsVar.varView.Projection == ProjectionModeType.Perspective)
        this.viewportcad.Viewports[0].Camera.ProjectionMode = projectionType.Perspective;
      else
        this.viewportcad.Viewports[0].Camera.ProjectionMode = projectionType.Orthographic;
      if (clsVar.varView.DisplayMode == DisplayModeType.Wireframe)
        this.viewportcad.Viewports[0].DisplayMode = displayType.Wireframe;
      else if (clsVar.varView.DisplayMode == DisplayModeType.HiddenLines)
        this.viewportcad.Viewports[0].DisplayMode = displayType.HiddenLines;
      else if (clsVar.varView.DisplayMode == DisplayModeType.Rendered)
        this.viewportcad.Viewports[0].DisplayMode = displayType.Rendered;
      else if (clsVar.varView.DisplayMode == DisplayModeType.Flat)
        this.viewportcad.Viewports[0].DisplayMode = displayType.Flat;
      else if (clsVar.varView.DisplayMode == DisplayModeType.Shaded)
        this.viewportcad.Viewports[0].DisplayMode = displayType.Shaded;
      this.viewportcad.Shaded.ShowEdges = clsVar.varView.ShowEdges;
      if (clsVar.varDisplay.SmallSizeRatioMoving < 0.0)
        clsVar.varDisplay.SmallSizeRatioMoving = 0.0;
      this.viewportcad.Viewports[0].OriginSymbol.Visible = clsVar.varScreen.ShowOrigineIcon;
      this.viewportcad.Viewports[0].Zoom.ReverseMouseWheel = clsVar.varMouse.ZoomWheelReverseDirection;
      if (clsVar.varScreen.ShowOrigineCaption)
        this.viewportcad.Viewports[0].OriginSymbol.LabelOrigin = "Origin";
      else
        this.viewportcad.Viewports[0].OriginSymbol.LabelOrigin = "";
      if (clsVar.varScreen.OrigineIcon == OriginIconType.Ball)
        this.viewportcad.Viewports[0].OriginSymbol.StyleMode = originSymbolStyleType.Ball;
      if (clsVar.varScreen.OrigineIcon == OriginIconType.CoordinateSystem)
        this.viewportcad.Viewports[0].OriginSymbol.StyleMode = originSymbolStyleType.CoordinateSystem;
      this.viewportcad.Viewports[0].OriginSymbol.Size = clsVar.varScreen.OrigineSize;
      this.viewportcad.Viewports[0].CoordinateSystemIcon.Visible = clsVar.varScreen.ShowCoordinateSystemIcon;
      this.viewportcad.Viewports[0].ViewCubeIcon.Visible = clsVar.varScreen.ShowCubeIcon;
      this.viewportcad.Viewports[0].ToolBar.Visible = clsVar.varScreen.ShowToolbar;
      this.viewportcad.Flat.EdgeColorMethod = clsVar.varInterface5.FlatViewSettings.EdgeColorMethod;
      this.viewportcad.Flat.EdgeColor = clsVar.varInterface5.FlatViewSettings.EdgeColor;
      this.viewportcad.Flat.EdgeThickness = clsVar.varInterface5.FlatViewSettings.EdgeThickness;
      this.viewportcad.Flat.ShowEdges = clsVar.varInterface5.FlatViewSettings.ShowEdges;
      this.viewportcad.Flat.ShowInternalWires = clsVar.varInterface5.FlatViewSettings.ShowInternalWires;
      this.viewportcad.Flat.SilhouetteThickness = clsVar.varInterface5.FlatViewSettings.SilhouetteThickness;
      this.viewportcad.Flat.SilhouettesDrawingMode = clsVar.varInterface5.FlatViewSettings.SilhouettesDrawingMode;
      this.GridUpdate();
      this.viewportcad.Invalidate();
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void GridUpdate()
  {
    try
    {
      this.viewportcad.Viewports[0].Grid.Visible = clsVar.varView.Grid.Visible;
      this.viewportcad.Viewports[0].Grid.AlwaysBehind = clsVar.varView.Grid.AlwaysBehind;
      this.viewportcad.Viewports[0].Grid.AutoSize = clsVar.varView.Grid.AutoSize;
      this.viewportcad.Viewports[0].Grid.MajorLinesEvery = clsVar.varView.Grid.MajorLineSteps;
      this.viewportcad.Viewports[0].Grid.Min.X = clsVar.varView.Grid.MinimumValue.X;
      this.viewportcad.Viewports[0].Grid.Min.Y = clsVar.varView.Grid.MinimumValue.Y;
      this.viewportcad.Viewports[0].Grid.Max.X = clsVar.varView.Grid.MaximumValue.X;
      this.viewportcad.Viewports[0].Grid.Max.Y = clsVar.varView.Grid.MaximumValue.Y;
      this.viewportcad.Viewports[0].Grid.ColorAxisX = clsVar.varView.Grid.AxisXColor;
      this.viewportcad.Viewports[0].Grid.ColorAxisY = clsVar.varView.Grid.AxisYColor;
      this.viewportcad.Viewports[0].Grid.BorderColor = clsVar.varView.Grid.BorderColor;
      this.viewportcad.Viewports[0].Grid.FillColor = clsVar.varView.Grid.FillColor;
      this.viewportcad.Viewports[0].Grid.LineColor = clsVar.varView.Grid.LineColor;
      this.viewportcad.Viewports[0].Grid.MajorLineColor = clsVar.varView.Grid.MajorLineColor;
      this.viewportcad.Viewports[0].Grid.Lighting = clsVar.varView.Grid.Lighting;
      if (!clsVar.varView.Grid.GridStepFromSnapXValue)
        this.viewportcad.Viewports[0].Grid.Step = clsVar.varView.Grid.Step;
      else
        this.viewportcad.Viewports[0].Grid.Step = clsVar.varMouse.Osnap.SnapDistance.X;
      if (clsVar.varView.Grid.AutoPlane)
      {
        if (ccVars.Pages.Count > 0)
          this.viewportcad.Viewports[0].Grid.Plane = (Plane) ccVars.Pages[ccVars.PageIndex].Scene[ccVars.Pages[ccVars.PageIndex].SceneIndex].ScenePlane.Clone();
        else
          this.viewportcad.Viewports[0].Grid.Plane = Plane.XY;
      }
      else
        this.viewportcad.Viewports[0].Grid.Plane = Plane.XY;
      this.viewportcad.Invalidate();
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  private void viewportcad_SelectionChanged(object sender, SelectionChangedEventArgs e)
  {
    clsInit.appCommand.viewportSelectionChanged(sender, e);
  }

  private void viewportcad_Leave(object sender, EventArgs e) => ccVars.HighLightPoints.Clear();

  private void viewportcad_ViewChanged(object sender, Workspace.ViewChangedEventArgs e)
  {
    if (!ViewportCC.ForbiddenAreaClickedView)
      return;
    ViewportCC.ForbiddenAreaClickedView = false;
    if (e.ViewType == viewType.Front)
      clsInit.appCommand.cmdViewFront(false, clsVar.varView.SetViewUsePlane, clsVar.varView.SetPlaneAccordingToView);
    else if (e.ViewType == viewType.Rear)
      clsInit.appCommand.cmdViewRear(false, clsVar.varView.SetViewUsePlane, clsVar.varView.SetPlaneAccordingToView);
    else if (e.ViewType == viewType.Left)
      clsInit.appCommand.cmdViewLeft(false, clsVar.varView.SetViewUsePlane, clsVar.varView.SetPlaneAccordingToView);
    else if (e.ViewType == viewType.Right)
      clsInit.appCommand.cmdViewRight(false, clsVar.varView.SetViewUsePlane, clsVar.varView.SetPlaneAccordingToView);
    else
      clsInit.appCommand.cmdViewTop(false, clsVar.varView.SetViewUsePlane, clsVar.varView.SetPlaneAccordingToView);
  }

  private void viewportcad_DragOver(object sender, DragEventArgs e)
  {
    if (e.KeyState != 1)
      return;
    e.Effect = DragDropEffects.All;
  }

  private void viewportcad_DragDrop(object sender, DragEventArgs e)
  {
    if (clsVar.appModes_0.TuftingMode.Enable && ccVars.Pages.Count > 0)
    {
      buString5.MessageBoxWarning(AppLanguage.CadCamMessages[95]);
    }
    else
    {
      Array data = (Array) e.Data.GetData(DataFormats.FileDrop);
      if (data == null)
        return;
      for (int index1 = 0; index1 <= data.Length - 1; ++index1)
      {
        FileInfo fileInfo = new FileInfo(data.GetValue(index1).ToString());
        if (fileInfo.Exists)
        {
          string[] FileNames1 = new string[1]
          {
            fileInfo.FullName
          };
          if (!clsVar.varFile.DragDropInsertMode)
          {
            ccVars.Action = actionTypeBU.fileOpenAsPage;
            clsInit.appCommand.OpenPage(FileNames1);
          }
          else
          {
            ccVars.Action = actionTypeBU.fileInsert;
            for (int index2 = 0; index2 <= FileNames1.Length - 1; ++index2)
            {
              string[] FileNames2 = new string[1]
              {
                FileNames1[index2]
              };
              clsInit.appCommand.OpenPage(FileNames2);
            }
          }
        }
      }
      ccVars.Action = actionTypeBU.None;
    }
  }

  private void viewportcad_DragEnter(object sender, DragEventArgs e)
  {
    if (e.Data.GetDataPresent(DataFormats.FileDrop))
      e.Effect = DragDropEffects.Copy;
    else
      e.Effect = DragDropEffects.None;
  }

  internal void mnu_cancel_Click(object sender, EventArgs e)
  {
    try
    {
      ToolStripMenuItem toolStripMenuItem1 = new ToolStripMenuItem();
      ToolStripMenuItem toolStripMenuItem2 = (ToolStripMenuItem) sender;
      if (toolStripMenuItem2.Name == this.mnu_finish.Name)
        clsInit.appCommand.cmdDrawFinish();
      if (toolStripMenuItem2.Name == this.mnu_addtolayer.Name)
        clsInit.appCommand.cmdEditEntitiesToLayer();
      if (toolStripMenuItem2.Name == this.toolStripMenuItem_0.Name)
        clsInit.appCommand.cmdInternalEntitiesToLayer();
      if (toolStripMenuItem2.Name == this.mnu_undo.Name)
        clsInit.appCommand.cmdDrawUndo();
      if (toolStripMenuItem2.Name == this.mnu_closedrawing.Name)
        clsInit.appCommand.cmdDrawClose();
      if (toolStripMenuItem2.Name == this.mnu_properties.Name)
        clsInit.appCommand.cmdEntitiesProperties();
      if (toolStripMenuItem2.Name == this.mnu_viewtop.Name)
        clsInit.appCommand.cmdViewTop(false, clsVar.varView.SetViewUsePlane, clsVar.varView.SetPlaneAccordingToView);
      if (toolStripMenuItem2.Name == this.mnu_viewfront.Name)
        clsInit.appCommand.cmdViewFront(false, clsVar.varView.SetViewUsePlane, clsVar.varView.SetPlaneAccordingToView);
      if (toolStripMenuItem2.Name == this.mnu_viewback.Name)
        clsInit.appCommand.cmdViewRear(false, clsVar.varView.SetViewUsePlane, clsVar.varView.SetPlaneAccordingToView);
      if (toolStripMenuItem2.Name == this.mnu_viewleft.Name)
        clsInit.appCommand.cmdViewLeft(false, clsVar.varView.SetViewUsePlane, clsVar.varView.SetPlaneAccordingToView);
      if (toolStripMenuItem2.Name == this.mnu_viewright.Name)
        clsInit.appCommand.cmdViewRight(false, clsVar.varView.SetViewUsePlane, clsVar.varView.SetPlaneAccordingToView);
      if (toolStripMenuItem2.Name == this.mnu_viewiso.Name)
        clsInit.appCommand.cmdViewIsometric(clsVar.varView.SetViewUsePlane);
      if (toolStripMenuItem2.Name == this.mnu_viewzoomfit.Name)
        clsInit.appCommand.cmdViewZoomFit(10);
      if (toolStripMenuItem2.Name == this.mnu_viewzoomin.Name)
        clsInit.appCommand.cmdViewZoomIn();
      if (toolStripMenuItem2.Name == this.mnu_viewzoomout.Name)
        clsInit.appCommand.cmdViewZoomOut();
      if (clsInit.appProfile == null)
        return;
      if (toolStripMenuItem2.Name == this.mnu_ProfileAddOperation.Name)
        clsInit.appProfile.cmdOperationMenu();
      if (!(toolStripMenuItem2.Name == this.mnu_ProfileAddProfile.Name))
        return;
      clsInit.appProfile.cmdAddProfile((ProfileItem) null);
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  internal void method_4(object sender, CancelEventArgs e)
  {
    e.Cancel = clsVar.ContextMenuCancel;
    if (clsVar.appModes_0.ProfileMode.Enable)
    {
      this.mnu_closedrawing.Visible = false;
      this.mnu_finish.Visible = false;
      this.mnu_undo.Visible = false;
      this.toolStripSeparator_0.Visible = false;
    }
    if (clsVar.SelectedRibbonMenuName == "mnu_file")
      ;
    if (clsVar.SelectedRibbonMenuName == "mnu_view")
      ;
    if (clsVar.SelectedRibbonMenuName == "mnu_drawing")
    {
      this.mnu_closedrawing.Visible = true;
      this.mnu_finish.Visible = true;
      this.mnu_undo.Visible = true;
      this.toolStripSeparator_0.Visible = true;
    }
    if (!clsVar.appModes_0.ProfileMode.Enable)
      return;
    this.mnu_ProfileAddOperation.Visible = false;
    this.mnu_ProfileAddProfile.Visible = false;
    this.mnu_ProfileSeperator.Visible = false;
    if (!(clsVar.SelectedRibbonMenuName == "mnu_profile"))
      return;
    this.mnu_ProfileAddOperation.Visible = true;
    this.mnu_ProfileAddProfile.Visible = true;
    this.mnu_ProfileSeperator.Visible = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
