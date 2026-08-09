using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buCore;
using buEyeBaseVer5;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Geometry;
using devDept.Graphics;
using ns8;

namespace buCadCamResVer5.Forms;

public class F_Drawing : Form
{
	public ViewportCC viewportcad;

	private ToolStripMenuItem mnu_viewtop = null;

	private ToolStripMenuItem mnu_viewfront = null;

	private ToolStripMenuItem mnu_viewback = null;

	private ToolStripMenuItem mnu_viewleft = null;

	private ToolStripMenuItem mnu_viewright = null;

	private ToolStripMenuItem mnu_viewiso = null;

	private ToolStripMenuItem mnu_viewzoomfit = null;

	private ToolStripMenuItem mnu_viewzoomin = null;

	private ToolStripMenuItem mnu_viewzoomout = null;

	private ToolStripMenuItem mnu_cancel = null;

	private ToolStripMenuItem mnu_properties = null;

	private ToolStripMenuItem mnu_ProfileAddProfile = null;

	private ToolStripMenuItem mnu_ProfileAddOperation = null;

	private ToolStripSeparator mnu_ProfileSeperator = null;

	private ToolStripSeparator mnu_separatorcancel = null;

	private ToolStripSeparator mnu_PropertiesSeperator = null;

	private Timer timer_0 = new Timer();

	internal IContainer icontainer_0 = null;

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
		viewportcad = new ViewportCC();
		viewportcad.InitializeViewports();
		viewportcad.CreateControl();
		viewportcad.CreateGraphics();
		viewportcad.SetView(viewType.Top);
		viewportcad.AllowDrop = true;
		viewportcad.DragOver += viewportcad_DragOver;
		viewportcad.DragEnter += viewportcad_DragEnter;
		viewportcad.DragDrop += viewportcad_DragDrop;
		viewportcad.SelectionChanged += viewportcad_SelectionChanged;
		viewportcad.Leave += viewportcad_Leave;
		viewportcad.ViewChanged += viewportcad_ViewChanged;
		DisplayModeSettingsRendered rendered = new DisplayModeSettingsRendered(showEdges: false, edgeColorMethodType.EntityColor, Color.Black, 1f, 2f, silhouettesDrawingType.LastFrame, showInternalWires: false, shadowType.None, null, environmentMapEnabled: false, planarReflections: false, 0.3f, realisticShadowQualityType.Low);
		DisplayModeSettingsShaded shaded = new DisplayModeSettingsShaded(showEdges: false, edgeColorMethodType.EntityColor, Color.Black, 2f, 2f, silhouettesDrawingType.Never, showInternalWires: false, shadowType.None);
		DisplayModeSettingsFlat flat = new DisplayModeSettingsFlat(showEdges: true, edgeColorMethodType.EntityColor, Color.Black, 2f, 2f, silhouettesDrawingType.Never, showInternalWires: false)
		{
			ShowInternalWires = false,
			ShowEdges = true,
			EdgeColorMethod = edgeColorMethodType.SingleColor
		};
		viewportcad.Rendered.ShowEdges = false;
		viewportcad.Rendered.ShowInternalWires = false;
		viewportcad.Rendered.RealisticShadowQuality = realisticShadowQualityType.Low;
		viewportcad.Shaded.ShowEdges = false;
		viewportcad.Rendered = rendered;
		viewportcad.Shaded = shaded;
		viewportcad.Flat = flat;
		viewportcad.Viewports[0].CoordinateSystemIcon.Lighting = true;
		viewportcad.Viewports[0].ViewCubeIcon.Lighting = true;
		viewportcad.Viewports[0].OriginSymbol.Lighting = true;
		viewportcad.WaitCursorMode = waitCursorType.Never;
		viewportcad.CurrentBlock.Units = linearUnitsType.Millimeters;
		viewportcad.Rendered.ShowEdges = false;
		viewportcad.Rendered.PlanarReflections = false;
		viewportcad.ShortcutKeys.CopySelection = Keys.None;
		viewportcad.ShortcutKeys.CutSelection = Keys.None;
		viewportcad.ShortcutKeys.DeleteSelection = Keys.None;
		viewportcad.ShortcutKeys.GroupSelection = Keys.None;
		viewportcad.ShortcutKeys.InvertSelection = Keys.None;
		viewportcad.ShortcutKeys.NavigationBackward = Keys.None;
		viewportcad.ShortcutKeys.NavigationDown = Keys.None;
		viewportcad.ShortcutKeys.NavigationForward = Keys.None;
		viewportcad.ShortcutKeys.NavigationLeft = Keys.None;
		viewportcad.ShortcutKeys.NavigationRight = Keys.None;
		viewportcad.ShortcutKeys.NavigationUp = Keys.None;
		viewportcad.ShortcutKeys.PanDown = Keys.None;
		viewportcad.ShortcutKeys.PanLeft = Keys.None;
		viewportcad.ShortcutKeys.PanRight = Keys.None;
		viewportcad.ShortcutKeys.PanUp = Keys.None;
		viewportcad.ShortcutKeys.PasteSelection = Keys.None;
		viewportcad.ShortcutKeys.RotateDown = Keys.None;
		viewportcad.ShortcutKeys.RotateLeft = Keys.None;
		viewportcad.ShortcutKeys.RotateRight = Keys.None;
		viewportcad.ShortcutKeys.RotateUp = Keys.None;
		viewportcad.ShortcutKeys.SelectAll = Keys.None;
		viewportcad.ShortcutKeys.UngroupSelection = Keys.None;
		viewportcad.ShortcutKeys.ZoomFit = Keys.None;
		viewportcad.ShortcutKeys.ZoomIn = Keys.None;
		viewportcad.ShortcutKeys.ZoomOut = Keys.None;
		viewportcad.ContextMenuStrip = contextMenu_rightclick;
		viewportcad.CurrentBlock.Units = linearUnitsType.Millimeters;
		viewportcad.ShortcutKeys.CopySelection = Keys.None;
		viewportcad.ShortcutKeys.CutSelection = Keys.None;
		viewportcad.ShortcutKeys.DeleteSelection = Keys.None;
		viewportcad.ShortcutKeys.GroupSelection = Keys.None;
		viewportcad.Dock = DockStyle.Fill;
		mnu_finish.Image = imageList_0.Images[13];
		mnu_closedrawing.Image = imageList_0.Images[14];
		mnu_undo.Image = imageList_0.Images[15];
		mnu_addtolayer.Image = imageList_0.Images[11];
		toolStripMenuItem_0.Image = imageList_0.Images[12];
		mnu_viewtop = new ToolStripMenuItem();
		mnu_viewtop.Text = buLangTranslate.preDef.Top + " " + buLangTranslate.preDef.View;
		mnu_viewtop.Name = "mnu_viewtop";
		mnu_viewtop.Image = imageList_0.Images[0];
		mnu_viewtop.Click += mnu_cancel_Click;
		contextMenu_rightclick.Items.Add(mnu_viewtop);
		mnu_viewfront = new ToolStripMenuItem();
		mnu_viewfront.Text = buLangTranslate.preDef.Front + " " + buLangTranslate.preDef.View;
		mnu_viewfront.Name = "mnu_viewfront";
		mnu_viewfront.Image = imageList_0.Images[2];
		mnu_viewfront.Click += mnu_cancel_Click;
		contextMenu_rightclick.Items.Add(mnu_viewfront);
		mnu_viewback = new ToolStripMenuItem();
		mnu_viewback.Text = buLangTranslate.preDef.Back + " " + buLangTranslate.preDef.View;
		mnu_viewback.Name = "mnu_viewback";
		mnu_viewback.Image = imageList_0.Images[3];
		mnu_viewback.Click += mnu_cancel_Click;
		contextMenu_rightclick.Items.Add(mnu_viewback);
		mnu_viewleft = new ToolStripMenuItem();
		mnu_viewleft.Text = buLangTranslate.preDef.Left + " " + buLangTranslate.preDef.View;
		mnu_viewleft.Name = "mnu_viewleft";
		mnu_viewleft.Image = imageList_0.Images[4];
		mnu_viewleft.Click += mnu_cancel_Click;
		contextMenu_rightclick.Items.Add(mnu_viewleft);
		mnu_viewright = new ToolStripMenuItem();
		mnu_viewright.Text = buLangTranslate.preDef.Top + " " + buLangTranslate.preDef.View;
		mnu_viewright.Name = "mnu_viewright";
		mnu_viewright.Image = imageList_0.Images[5];
		mnu_viewright.Click += mnu_cancel_Click;
		contextMenu_rightclick.Items.Add(mnu_viewright);
		mnu_viewiso = new ToolStripMenuItem();
		mnu_viewiso.Text = buLangTranslate.preDef.Isometric + " " + buLangTranslate.preDef.View;
		mnu_viewiso.Name = "mnu_viewiso";
		mnu_viewiso.Image = imageList_0.Images[6];
		mnu_viewiso.Click += mnu_cancel_Click;
		contextMenu_rightclick.Items.Add(mnu_viewiso);
		mnu_viewzoomfit = new ToolStripMenuItem();
		mnu_viewzoomfit.Text = buLangTranslate.preDef.ZoomFit;
		mnu_viewzoomfit.Name = "mnu_viewzoomfit";
		mnu_viewzoomfit.Image = imageList_0.Images[8];
		mnu_viewzoomfit.Click += mnu_cancel_Click;
		contextMenu_rightclick.Items.Add(mnu_viewzoomfit);
		mnu_viewzoomin = new ToolStripMenuItem();
		mnu_viewzoomin.Text = buLangTranslate.preDef.ZoomIn;
		mnu_viewzoomin.Name = "mnu_viewzoomin";
		mnu_viewzoomin.Image = imageList_0.Images[9];
		mnu_viewzoomin.Click += mnu_cancel_Click;
		contextMenu_rightclick.Items.Add(mnu_viewzoomin);
		mnu_viewzoomout = new ToolStripMenuItem();
		mnu_viewzoomout.Text = buLangTranslate.preDef.ZoomOut;
		mnu_viewzoomout.Name = "mnu_viewzoomout";
		mnu_viewzoomout.Image = imageList_0.Images[10];
		mnu_viewzoomout.Click += mnu_cancel_Click;
		contextMenu_rightclick.Items.Add(mnu_viewzoomout);
		if (clsVar.appModes_0.ProfileMode.Enable)
		{
			mnu_ProfileSeperator = new ToolStripSeparator();
			mnu_ProfileSeperator.Size = new Size(contextMenu_rightclick.Width, 6);
			mnu_ProfileSeperator.Name = "mnu_ProfileSeperator";
			mnu_ProfileAddProfile = new ToolStripMenuItem();
			mnu_ProfileAddProfile.Text = buLangTranslate.preDef.Profile + " " + buLangTranslate.preDef.Add;
			mnu_ProfileAddProfile.Name = "mnu_ProfileAddProfile";
			mnu_ProfileAddProfile.Image = imageList_0.Images[18];
			mnu_ProfileAddProfile.Click += mnu_cancel_Click;
			mnu_ProfileAddOperation = new ToolStripMenuItem();
			mnu_ProfileAddOperation.Text = buLangTranslate.preDef.Operation + " " + buLangTranslate.preDef.Add;
			mnu_ProfileAddOperation.Name = "mnu_ProfileAddOperation";
			mnu_ProfileAddOperation.Image = imageList_0.Images[17];
			mnu_ProfileAddOperation.Click += mnu_cancel_Click;
			contextMenu_rightclick.Items.Add(mnu_ProfileSeperator);
			contextMenu_rightclick.Items.Add(mnu_ProfileAddProfile);
			contextMenu_rightclick.Items.Add(mnu_ProfileAddOperation);
		}
		mnu_PropertiesSeperator = new ToolStripSeparator();
		mnu_PropertiesSeperator.Size = new Size(contextMenu_rightclick.Width, 6);
		mnu_PropertiesSeperator.Name = "mnu_PropertiesSeperator";
		contextMenu_rightclick.Items.Add(mnu_PropertiesSeperator);
		mnu_properties = new ToolStripMenuItem();
		mnu_properties.Text = buLangTranslate.preDef.Properties;
		mnu_properties.Name = "mnu_properties";
		mnu_properties.Image = imageList_0.Images[16];
		mnu_properties.Click += mnu_cancel_Click;
		contextMenu_rightclick.Items.Add(mnu_properties);
		mnu_separatorcancel = new ToolStripSeparator();
		mnu_separatorcancel.Size = new Size(contextMenu_rightclick.Width, 6);
		mnu_separatorcancel.Name = "mnu_separatorcancel";
		contextMenu_rightclick.Items.Add(mnu_separatorcancel);
		mnu_cancel = new ToolStripMenuItem();
		mnu_cancel.Text = buLangTranslate.preDef.Cancel;
		mnu_cancel.Name = "mnu_cancel";
		mnu_cancel.Image = imageList_0.Images[7];
		mnu_cancel.Click += mnu_cancel_Click;
		contextMenu_rightclick.Items.Add(mnu_cancel);
		base.Controls.Add(viewportcad);
		timer_0.Interval = 2000;
		timer_0.Tick += timer_0_Tick;
	}

	public void Init()
	{
		btn_ok.Click += clsInit.appCommand.ViewportButtonsClick;
		btn_cancel.Click += clsInit.appCommand.ViewportButtonsClick;
		btn_undo.Click += clsInit.appCommand.ViewportButtonsClick;
		UpdateForm();
		timer_0.Enabled = true;
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		try
		{
			clsVar.CancelFromQuit = false;
			if (((ccVars.Pages.Count > 0) & (ccVars.PageIndex <= ccVars.Pages.Count - 1) & !clsVar.varFile.DontAskSaveToFileMesssafeWhileClosing) && ccVars.Pages[ccVars.PageIndex].Changed)
			{
				DialogResult dialogResult = buString.MessageBoxQuestionYesNoCancel(ccVars.Pages[ccVars.PageIndex].Form.Text + " - " + AppLanguage.CadCamMessages[4]);
				if (dialogResult == DialogResult.Yes)
				{
					if (ccVars.Pages[ccVars.PageIndex].FileName.Length > 2)
					{
						FileInfo fileInfo = new FileInfo(ccVars.Pages[ccVars.PageIndex].FileName);
						if (!fileInfo.Exists)
						{
							ccVars.Pages[ccVars.PageIndex].FileName = "";
						}
						else if (fileInfo.Extension != ".bucad")
						{
							ccVars.Pages[ccVars.PageIndex].FileName = "";
						}
					}
					clsInit.appCommand.cmdFileSave();
				}
				if (dialogResult == DialogResult.Cancel)
				{
					clsVar.CancelFromQuit = true;
					e.Cancel = true;
				}
				if ((dialogResult == DialogResult.No) & ccVars.MainFormClosing)
				{
					e.Cancel = true;
				}
			}
			GC.Collect();
		}
		catch (Exception)
		{
		}
	}

	internal void method_1(object sender, FormClosedEventArgs e)
	{
		clsInit.appCommand.PageClose(ccVars.PageIndex);
	}

	internal void method_2(object sender, EventArgs e)
	{
		ccVars.PageIndex = Convert.ToInt32(base.Tag);
		clsInit.appCommand.LayersUpdate(ccVars.Pages[ccVars.PageIndex].Layers, FillLayer: true, 0);
		buVector5.baseModel = viewportcad;
	}

	internal void method_3(object sender, EventArgs e)
	{
		spn_val1.KeyDown += clsInit.appCommand.SpinDrawData_KeyDown;
		spn_val1_1.KeyDown += clsInit.appCommand.SpinDrawData_KeyDown;
		spn_val2.KeyDown += clsInit.appCommand.SpinDrawData_KeyDown;
		spn_val3.KeyDown += clsInit.appCommand.SpinDrawData_KeyDown;
		spn_x.KeyDown += clsInit.appCommand.SpinDrawData_KeyDown;
		spn_y.KeyDown += clsInit.appCommand.SpinDrawData_KeyDown;
		spn_z.KeyDown += clsInit.appCommand.SpinDrawData_KeyDown;
		if (clsVar.varView.AddViewButtonsToRightClickMenu)
		{
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
			toolStripMenuItem.Name = "mnu_ViewTop";
			toolStripMenuItem.Text = "View Top";
			toolStripMenuItem.Image = imageList_0.Images[0];
			toolStripMenuItem.Click += mnu_cancel_Click;
			ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem();
			toolStripMenuItem2.Name = "mnu_ViewBottom";
			toolStripMenuItem2.Text = "View Bottom";
			toolStripMenuItem2.Image = imageList_0.Images[1];
			toolStripMenuItem.Click += mnu_cancel_Click;
			ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem();
			toolStripMenuItem3.Name = "mnu_ViewFront";
			toolStripMenuItem3.Text = "View Front";
			toolStripMenuItem3.Image = imageList_0.Images[2];
			toolStripMenuItem3.Click += mnu_cancel_Click;
			ToolStripMenuItem toolStripMenuItem4 = new ToolStripMenuItem();
			toolStripMenuItem4.Name = "mnu_ViewBack";
			toolStripMenuItem4.Text = "View Back";
			toolStripMenuItem4.Image = imageList_0.Images[3];
			toolStripMenuItem4.Click += mnu_cancel_Click;
			ToolStripMenuItem toolStripMenuItem5 = new ToolStripMenuItem();
			toolStripMenuItem5.Name = "mnu_ViewLeft";
			toolStripMenuItem5.Text = "View Left";
			toolStripMenuItem5.Image = imageList_0.Images[4];
			toolStripMenuItem5.Click += mnu_cancel_Click;
			ToolStripMenuItem toolStripMenuItem6 = new ToolStripMenuItem();
			toolStripMenuItem6.Name = "mnu_ViewRight";
			toolStripMenuItem6.Text = "View Right";
			toolStripMenuItem6.Image = imageList_0.Images[5];
			toolStripMenuItem6.Click += mnu_cancel_Click;
			ToolStripMenuItem toolStripMenuItem7 = new ToolStripMenuItem();
			toolStripMenuItem7.Name = "mnu_ViewIso";
			toolStripMenuItem7.Text = "View Iso";
			toolStripMenuItem7.Image = imageList_0.Images[6];
			toolStripMenuItem7.Click += mnu_cancel_Click;
			ToolStripSeparator value = new ToolStripSeparator();
			toolStripMenuItem7.Name = "mnu_Separator1";
			contextMenu_rightclick.Items.Add(value);
			contextMenu_rightclick.Items.Add(toolStripMenuItem);
			contextMenu_rightclick.Items.Add(toolStripMenuItem2);
			contextMenu_rightclick.Items.Add(toolStripMenuItem3);
			contextMenu_rightclick.Items.Add(toolStripMenuItem4);
			contextMenu_rightclick.Items.Add(toolStripMenuItem5);
			contextMenu_rightclick.Items.Add(toolStripMenuItem6);
			contextMenu_rightclick.Items.Add(toolStripMenuItem7);
		}
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (viewportcad != null && viewportcad.IsHandleCreated)
		{
			clsInit.appCommand.UpdateViewportsMouseConfig();
			timer_0.Enabled = false;
		}
	}

	public void UpdateForm()
	{
		try
		{
			viewportcad.AssemblySelectionMode = Workspace.assemblySelectionType.Branch;
			viewportcad.CursorTypes[cursorType.Default] = Cursors.Arrow;
			viewportcad.CursorTypes[cursorType.Pick] = Cursors.Arrow;
			if (clsVar.varMouse.MouseCursor == MouseCursorType.Hand)
			{
				viewportcad.CursorTypes[cursorType.Default] = Cursors.Hand;
			}
			viewportcad.Viewports[0].Background = new BackgroundSettings(backgroundStyleType.LinearGradient, clsVar.varDisplay.ColorViewportBottom, clsVar.varDisplay.ColorViewportIntermediate, clsVar.varDisplay.ColorViewportTop, 0.75, null, colorThemeType.Auto, 0.3);
			viewportcad.Viewports[0].Pan.MouseButton = new MouseButton(buConversion5.MouseButtonConv(clsVar.varMouse.PanConfigration.Button), buConversion5.KeyConv(clsVar.varMouse.PanConfigration.Key));
			viewportcad.Viewports[0].Rotate.MouseButton = new MouseButton(buConversion5.MouseButtonConv(clsVar.varMouse.RotateConfigration.Button), buConversion5.KeyConv(clsVar.varMouse.RotateConfigration.Key));
			viewportcad.Viewports[0].Zoom.MouseButton = new MouseButton(buConversion5.MouseButtonConv(clsVar.varMouse.ZoomConfigration.Button), buConversion5.KeyConv(clsVar.varMouse.ZoomConfigration.Key));
			if (clsVar.varView.Projection != ProjectionModeType.Perspective)
			{
				viewportcad.Viewports[0].Camera.ProjectionMode = projectionType.Orthographic;
			}
			else
			{
				viewportcad.Viewports[0].Camera.ProjectionMode = projectionType.Perspective;
			}
			if (clsVar.varView.DisplayMode != DisplayModeType.Wireframe)
			{
				if (clsVar.varView.DisplayMode != DisplayModeType.HiddenLines)
				{
					if (clsVar.varView.DisplayMode != DisplayModeType.Rendered)
					{
						if (clsVar.varView.DisplayMode != DisplayModeType.Flat)
						{
							if (clsVar.varView.DisplayMode == DisplayModeType.Shaded)
							{
								viewportcad.Viewports[0].DisplayMode = displayType.Shaded;
							}
						}
						else
						{
							viewportcad.Viewports[0].DisplayMode = displayType.Flat;
						}
					}
					else
					{
						viewportcad.Viewports[0].DisplayMode = displayType.Rendered;
					}
				}
				else
				{
					viewportcad.Viewports[0].DisplayMode = displayType.HiddenLines;
				}
			}
			else
			{
				viewportcad.Viewports[0].DisplayMode = displayType.Wireframe;
			}
			viewportcad.Shaded.ShowEdges = clsVar.varView.ShowEdges;
			if (clsVar.varDisplay.SmallSizeRatioMoving < 0.0)
			{
				clsVar.varDisplay.SmallSizeRatioMoving = 0.0;
			}
			viewportcad.Viewports[0].OriginSymbol.Visible = clsVar.varScreen.ShowOrigineIcon;
			viewportcad.Viewports[0].Zoom.ReverseMouseWheel = clsVar.varMouse.ZoomWheelReverseDirection;
			if (!clsVar.varScreen.ShowOrigineCaption)
			{
				viewportcad.Viewports[0].OriginSymbol.LabelOrigin = "";
			}
			else
			{
				viewportcad.Viewports[0].OriginSymbol.LabelOrigin = "Origin";
			}
			if (clsVar.varScreen.OrigineIcon == OriginIconType.Ball)
			{
				viewportcad.Viewports[0].OriginSymbol.StyleMode = originSymbolStyleType.Ball;
			}
			if (clsVar.varScreen.OrigineIcon == OriginIconType.CoordinateSystem)
			{
				viewportcad.Viewports[0].OriginSymbol.StyleMode = originSymbolStyleType.CoordinateSystem;
			}
			viewportcad.Viewports[0].OriginSymbol.Size = clsVar.varScreen.OrigineSize;
			viewportcad.Viewports[0].CoordinateSystemIcon.Visible = clsVar.varScreen.ShowCoordinateSystemIcon;
			viewportcad.Viewports[0].ViewCubeIcon.Visible = clsVar.varScreen.ShowCubeIcon;
			viewportcad.Viewports[0].ToolBar.Visible = clsVar.varScreen.ShowToolbar;
			viewportcad.Flat.EdgeColorMethod = clsVar.varInterface5.FlatViewSettings.EdgeColorMethod;
			viewportcad.Flat.EdgeColor = clsVar.varInterface5.FlatViewSettings.EdgeColor;
			viewportcad.Flat.EdgeThickness = clsVar.varInterface5.FlatViewSettings.EdgeThickness;
			viewportcad.Flat.ShowEdges = clsVar.varInterface5.FlatViewSettings.ShowEdges;
			viewportcad.Flat.ShowInternalWires = clsVar.varInterface5.FlatViewSettings.ShowInternalWires;
			viewportcad.Flat.SilhouetteThickness = clsVar.varInterface5.FlatViewSettings.SilhouetteThickness;
			viewportcad.Flat.SilhouettesDrawingMode = clsVar.varInterface5.FlatViewSettings.SilhouettesDrawingMode;
			GridUpdate();
			viewportcad.Invalidate();
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void GridUpdate()
	{
		try
		{
			viewportcad.Viewports[0].Grid.Visible = clsVar.varView.Grid.Visible;
			viewportcad.Viewports[0].Grid.AlwaysBehind = clsVar.varView.Grid.AlwaysBehind;
			viewportcad.Viewports[0].Grid.AutoSize = clsVar.varView.Grid.AutoSize;
			viewportcad.Viewports[0].Grid.MajorLinesEvery = clsVar.varView.Grid.MajorLineSteps;
			viewportcad.Viewports[0].Grid.Min.X = clsVar.varView.Grid.MinimumValue.X;
			viewportcad.Viewports[0].Grid.Min.Y = clsVar.varView.Grid.MinimumValue.Y;
			viewportcad.Viewports[0].Grid.Max.X = clsVar.varView.Grid.MaximumValue.X;
			viewportcad.Viewports[0].Grid.Max.Y = clsVar.varView.Grid.MaximumValue.Y;
			viewportcad.Viewports[0].Grid.ColorAxisX = clsVar.varView.Grid.AxisXColor;
			viewportcad.Viewports[0].Grid.ColorAxisY = clsVar.varView.Grid.AxisYColor;
			viewportcad.Viewports[0].Grid.BorderColor = clsVar.varView.Grid.BorderColor;
			viewportcad.Viewports[0].Grid.FillColor = clsVar.varView.Grid.FillColor;
			viewportcad.Viewports[0].Grid.LineColor = clsVar.varView.Grid.LineColor;
			viewportcad.Viewports[0].Grid.MajorLineColor = clsVar.varView.Grid.MajorLineColor;
			viewportcad.Viewports[0].Grid.Lighting = clsVar.varView.Grid.Lighting;
			if (clsVar.varView.Grid.GridStepFromSnapXValue)
			{
				viewportcad.Viewports[0].Grid.Step = clsVar.varMouse.Osnap.SnapDistance.X;
			}
			else
			{
				viewportcad.Viewports[0].Grid.Step = clsVar.varView.Grid.Step;
			}
			if (!clsVar.varView.Grid.AutoPlane)
			{
				viewportcad.Viewports[0].Grid.Plane = Plane.XY;
			}
			else if (ccVars.Pages.Count <= 0)
			{
				viewportcad.Viewports[0].Grid.Plane = Plane.XY;
			}
			else
			{
				Plane plane = (Plane)ccVars.Pages[ccVars.PageIndex].Scene[ccVars.Pages[ccVars.PageIndex].SceneIndex].ScenePlane.Clone();
				viewportcad.Viewports[0].Grid.Plane = plane;
			}
			viewportcad.Invalidate();
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	private void viewportcad_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		clsInit.appCommand.viewportSelectionChanged(sender, e);
	}

	private void viewportcad_Leave(object sender, EventArgs e)
	{
		ccVars.HighLightPoints.Clear();
	}

	private void viewportcad_ViewChanged(object sender, Workspace.ViewChangedEventArgs e)
	{
		if (!ViewportCC.ForbiddenAreaClickedView)
		{
			return;
		}
		ViewportCC.ForbiddenAreaClickedView = false;
		if (e.ViewType != viewType.Front)
		{
			if (e.ViewType != viewType.Rear)
			{
				if (e.ViewType != viewType.Left)
				{
					if (e.ViewType != viewType.Right)
					{
						clsInit.appCommand.cmdViewTop(ZoomFit: false, clsVar.varView.SetViewUsePlane, clsVar.varView.SetPlaneAccordingToView);
					}
					else
					{
						clsInit.appCommand.cmdViewRight(ZoomFit: false, clsVar.varView.SetViewUsePlane, clsVar.varView.SetPlaneAccordingToView);
					}
				}
				else
				{
					clsInit.appCommand.cmdViewLeft(ZoomFit: false, clsVar.varView.SetViewUsePlane, clsVar.varView.SetPlaneAccordingToView);
				}
			}
			else
			{
				clsInit.appCommand.cmdViewRear(ZoomFit: false, clsVar.varView.SetViewUsePlane, clsVar.varView.SetPlaneAccordingToView);
			}
		}
		else
		{
			clsInit.appCommand.cmdViewFront(ZoomFit: false, clsVar.varView.SetViewUsePlane, clsVar.varView.SetPlaneAccordingToView);
		}
	}

	private void viewportcad_DragOver(object sender, DragEventArgs e)
	{
		if (e.KeyState == 1)
		{
			e.Effect = DragDropEffects.All;
		}
	}

	private void viewportcad_DragDrop(object sender, DragEventArgs e)
	{
		if (!clsVar.appModes_0.TuftingMode.Enable || ccVars.Pages.Count <= 0)
		{
			FileInfo fileInfo = null;
			Array array = (Array)e.Data.GetData(DataFormats.FileDrop);
			if (array == null)
			{
				return;
			}
			for (int i = 0; i <= array.Length - 1; i++)
			{
				fileInfo = new FileInfo(array.GetValue(i).ToString());
				if (!fileInfo.Exists)
				{
					continue;
				}
				string[] array2 = new string[1] { fileInfo.FullName };
				if (clsVar.varFile.DragDropInsertMode)
				{
					ccVars.Action = actionTypeBU.fileInsert;
					for (int j = 0; j <= array2.Length - 1; j++)
					{
						string[] fileNames = new string[1] { array2[j] };
						clsInit.appCommand.OpenPage(fileNames);
					}
				}
				else
				{
					ccVars.Action = actionTypeBU.fileOpenAsPage;
					clsInit.appCommand.OpenPage(array2);
				}
			}
			ccVars.Action = actionTypeBU.None;
		}
		else
		{
			buString5.MessageBoxWarning(AppLanguage.CadCamMessages[95]);
		}
	}

	private void viewportcad_DragEnter(object sender, DragEventArgs e)
	{
		if (!e.Data.GetDataPresent(DataFormats.FileDrop))
		{
			e.Effect = DragDropEffects.None;
		}
		else
		{
			e.Effect = DragDropEffects.Copy;
		}
	}

	internal void mnu_cancel_Click(object sender, EventArgs e)
	{
		try
		{
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
			toolStripMenuItem = (ToolStripMenuItem)sender;
			if (toolStripMenuItem.Name == mnu_finish.Name)
			{
				clsInit.appCommand.cmdDrawFinish();
			}
			if (toolStripMenuItem.Name == mnu_addtolayer.Name)
			{
				clsInit.appCommand.cmdEditEntitiesToLayer();
			}
			if (toolStripMenuItem.Name == toolStripMenuItem_0.Name)
			{
				clsInit.appCommand.cmdInternalEntitiesToLayer();
			}
			if (toolStripMenuItem.Name == mnu_undo.Name)
			{
				clsInit.appCommand.cmdDrawUndo();
			}
			if (toolStripMenuItem.Name == mnu_closedrawing.Name)
			{
				clsInit.appCommand.cmdDrawClose();
			}
			if (toolStripMenuItem.Name == mnu_properties.Name)
			{
				clsInit.appCommand.cmdEntitiesProperties();
			}
			if (toolStripMenuItem.Name == mnu_viewtop.Name)
			{
				clsInit.appCommand.cmdViewTop(ZoomFit: false, clsVar.varView.SetViewUsePlane, clsVar.varView.SetPlaneAccordingToView);
			}
			if (toolStripMenuItem.Name == mnu_viewfront.Name)
			{
				clsInit.appCommand.cmdViewFront(ZoomFit: false, clsVar.varView.SetViewUsePlane, clsVar.varView.SetPlaneAccordingToView);
			}
			if (toolStripMenuItem.Name == mnu_viewback.Name)
			{
				clsInit.appCommand.cmdViewRear(ZoomFit: false, clsVar.varView.SetViewUsePlane, clsVar.varView.SetPlaneAccordingToView);
			}
			if (toolStripMenuItem.Name == mnu_viewleft.Name)
			{
				clsInit.appCommand.cmdViewLeft(ZoomFit: false, clsVar.varView.SetViewUsePlane, clsVar.varView.SetPlaneAccordingToView);
			}
			if (toolStripMenuItem.Name == mnu_viewright.Name)
			{
				clsInit.appCommand.cmdViewRight(ZoomFit: false, clsVar.varView.SetViewUsePlane, clsVar.varView.SetPlaneAccordingToView);
			}
			if (toolStripMenuItem.Name == mnu_viewiso.Name)
			{
				clsInit.appCommand.cmdViewIsometric(clsVar.varView.SetViewUsePlane);
			}
			if (toolStripMenuItem.Name == mnu_viewzoomfit.Name)
			{
				clsInit.appCommand.cmdViewZoomFit(10);
			}
			if (toolStripMenuItem.Name == mnu_viewzoomin.Name)
			{
				clsInit.appCommand.cmdViewZoomIn();
			}
			if (toolStripMenuItem.Name == mnu_viewzoomout.Name)
			{
				clsInit.appCommand.cmdViewZoomOut();
			}
			if (clsInit.appProfile != null)
			{
				if (toolStripMenuItem.Name == mnu_ProfileAddOperation.Name)
				{
					clsInit.appProfile.cmdOperationMenu();
				}
				if (toolStripMenuItem.Name == mnu_ProfileAddProfile.Name)
				{
					clsInit.appProfile.cmdAddProfile(null);
				}
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	internal void method_4(object sender, CancelEventArgs e)
	{
		e.Cancel = clsVar.ContextMenuCancel;
		if (clsVar.appModes_0.ProfileMode.Enable)
		{
			mnu_closedrawing.Visible = false;
			mnu_finish.Visible = false;
			mnu_undo.Visible = false;
			toolStripSeparator_0.Visible = false;
		}
		if (!(clsVar.SelectedRibbonMenuName == "mnu_file"))
		{
		}
		if (!(clsVar.SelectedRibbonMenuName == "mnu_view"))
		{
		}
		if (clsVar.SelectedRibbonMenuName == "mnu_drawing")
		{
			mnu_closedrawing.Visible = true;
			mnu_finish.Visible = true;
			mnu_undo.Visible = true;
			toolStripSeparator_0.Visible = true;
		}
		if (clsVar.appModes_0.ProfileMode.Enable)
		{
			mnu_ProfileAddOperation.Visible = false;
			mnu_ProfileAddProfile.Visible = false;
			mnu_ProfileSeperator.Visible = false;
			if (clsVar.SelectedRibbonMenuName == "mnu_profile")
			{
				mnu_ProfileAddOperation.Visible = true;
				mnu_ProfileAddProfile.Visible = true;
				mnu_ProfileSeperator.Visible = true;
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
