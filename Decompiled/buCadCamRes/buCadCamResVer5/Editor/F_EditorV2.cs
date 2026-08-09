using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buControls.ClassViewer;
using buControls.Controls;
using buEyeBaseVer5;
using buEyeBaseVer5.Variables;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Graphics;
using ns8;

namespace buCadCamResVer5.Editor;

public class F_EditorV2 : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public Drafting2D viewport = null;

	public int LastPage = 0;

	public List<string> OpenFileExtension = new List<string>();

	internal IContainer icontainer_0 = null;

	public buButton btn_close;

	public buGround buGround1;

	public ImageList IC32;

	public buButton btn_topview;

	public buButton btn_undo;

	public buButton btn_zoomfit;

	public buTab buTab_menu;

	public TabPage tabPage_file;

	internal TabPage tabPage_0;

	internal TabPage tabPage_1;

	public buButton btn_main;

	public buButton btn_drawing;

	public buTab buTab_Items;

	public TabPage tabPage_tree;

	public TabPage tabPage3;

	public buButton buButton5;

	internal buCheckBox buCheckBox_0;

	internal buCheckBox buCheckBox_1;

	internal buCheckBox buCheckBox_2;

	public buButton btn_new;

	public buButton btn_drawline;

	public buButton btn_drawpoint;

	public buButton btn_open;

	public buButton btn_save;

	public buButton btn_drawrect;

	public buButton btn_drawellipse;

	public buButton btn_drawarc3Pnt;

	public buButton btn_drawcircle3Pnt;

	public buButton btn_drawcircle;

	public buButton btn_drawpolygon;

	public buButton btn_drawslot;

	public buButton btn_drawspline;

	internal Panel panel_0;

	public buButton btn_itemtabminmax;

	public TreeView tree_objects;

	public buLabel lbl_y;

	public buLabel lbl_x;

	internal buSeparator buSeparator_0;

	public buButton buButton3;

	internal buSeparator buSeparator_1;

	public buSpin spn_y;

	public buSpin spn_x;

	internal buSeparator buSeparator_2;

	public buButton btn_trim;

	public buButton btn_extend;

	public buButton btn_offset;

	public buButton btn_delete;

	public buButton btn_break;

	public buButton btn_scale;

	public buButton btn_rotate;

	public buButton btn_mirror;

	public buButton btn_move;

	public buButton btn_copy;

	public buButton btn_explode;

	public buButton btn_array;

	public buButton btn_chamfer;

	public buButton btn_fillet;

	public buButton btn_lib_save;

	public buButton btn_lib_open;

	public buButton btn_lib_new;

	public buButton btn_lib_Paralel;

	public buButton btn_lib_onpoint;

	public buButton btn_lib_EQRad;

	public buButton btn_lib_EQLength;

	public buButton btn_lib_jointpoint;

	public buButton btn_lib_fix;

	public buButton btn_lib_perpendicular;

	public buButton btn_lib_tangent;

	public buButton btn_lib_pointpoint;

	public buButton btn_lib_linepoint;

	public buButton btn_lib_length;

	public buButton btn_lib_lineline;

	public buButton btn_lib_vertical;

	public buButton btn_lib_horizontal;

	public buButton btn_lib_redo;

	public buButton btn_lib_undo;

	public buButton btn_drawarc;

	public buButton btn_zoomout;

	public buButton btn_zoomin;

	internal buSeparator buSeparator_3;

	public buLabel lbl_status;

	public buButton btn_drawpolyline;

	internal buSeparator buSeparator_4;

	public buButton btn_settings;

	public buButton btn_rotateCCW;

	public buButton btn_moveymin;

	public buButton btn_movexmay;

	public buButton btn_movexmax;

	public buButton btn_movexmin;

	public buButton btn_rotateCW;

	public buSpin spn_moveval;

	public buButton btn_closeeventpopup;

	internal TabPage tabPage_2;

	public buSpin spn_filletrad;

	internal TabPage tabPage_3;

	public buSpin spn_chamgerlen;

	internal TabPage tabPage_4;

	public buButton btn_eventvalclose;

	public buCheckBox chk_explodeCompositetoEntity;

	public buCheckBox chk_explodearctopolyline;

	public buCheckBox chk_explodeellipsetopolyline;

	public buCheckBox chk_explodecircletopolyline;

	public buCheckBox chk_explodecurvetopolyline;

	public buCheckBox chk_explodepolylinetoLine;

	public buCheckBox chk_explodecircletoarc;

	public buGroup grp_eventmovecmd;

	public buGroup grp_events;

	public buButton btn_eventok;

	internal TabPage tabPage_5;

	public buSpin spn_scaleratio;

	internal TabPage tabPage_6;

	public buSpin spn_extndlen;

	public buTab buTab_EventVals;

	internal TabPage tabPage_7;

	public buCheckBox chk_offsetbymouse;

	public buSpin spn_offset;

	internal TabPage tabPage_8;

	public buButton buButton1;

	public buButton buButton2;

	public buButton buButton6;

	public buButton buButton7;

	public buButton buButton9;

	public buButton btn_marble;

	public buButton btn_library;

	internal buCheckBox buCheckBox_3;

	public buButton btn_libangle;

	public buButton btn_lib_radius;

	public buButton btn_lib_delete;

	public buButton btn_lib_mirror;

	public buButton btn_lib_chamger;

	public buButton btn_lib_fillet;

	public buButton btn_lib_offset;

	public buButton btn_lib_colliniear;

	public F_EditorV2()
	{
		Class5.smethod_83(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			base.Height = PropertiesForm.Height;
		}
		if (PropertiesForm.Width > 10)
		{
			base.Width = PropertiesForm.Width;
		}
		base.TopMost = PropertiesForm.TopMost;
		base.StartPosition = PropertiesForm.FormPosition;
		buTab_EventVals.ItemSize = new Size(1, 1);
		buTab_menu.ItemSize = new Size(1, 1);
		buTab_menu.Tabs.Header.Fonts.ForeColor = Color.Black;
		buTab_menu.Tabs.Header.Border.Visible = false;
		buTab_Items.ItemSize = new Size(1, 1);
		buTab_Items.Tabs.Header.Fonts.ForeColor = Color.Black;
		buTab_Items.Tabs.Header.Border.Visible = false;
		if (viewport == null)
		{
			CreateModelProperties Properties = new CreateModelProperties();
			clsInit.appCommand.EyeParameterToCreateModelProperties(clsVar.varPreviewViewport, clsVar.varMouse, ref Properties);
			Properties.BottomColor = Color.WhiteSmoke;
			Properties.TopColor = Color.Gainsboro;
			Properties.CoordinateSystemIconVisible = false;
			Properties.ViewCubeIconVisible = true;
			Properties.OrigineCaptionVisible = false;
			Properties.ToolBorVisible = false;
			Properties.OriginSymbolVisible = true;
			Properties.OrigineSize = 5;
			Properties.GridVisible = true;
			CreateModelControl(ref viewport, Properties);
			clsInit.appEditor2.GridUpdate();
			panel_0.Controls.Add(viewport);
			viewport.ZoomFit(selectedOnly: true);
		}
		viewport.Selection.Color = clsVar.varEditorSet.colorSelected;
		viewport.SetView(viewType.Top);
		viewport.Invalidate();
		viewport.AssemblySelectionMode = Workspace.assemblySelectionType.Branch;
		buCheckBox_2.Check = clsVar.varEditorSet.OsnapEntity;
		buCheckBox_0.Check = clsVar.varEditorSet.OsnapGrid;
		buCheckBox_1.Check = clsVar.varEditorSet.Ortho;
		buCheckBox_3.Check = clsVar.varEditorRuntimeSet.GridEnable;
		spn_filletrad.Value = clsVar.varEditorRuntimeSet.FilletRadius;
		spn_chamgerlen.Value = clsVar.varEditorRuntimeSet.ChamferLength;
		spn_scaleratio.Value = clsVar.varEditorRuntimeSet.ScaleRatio;
		spn_extndlen.Value = clsVar.varEditorRuntimeSet.ExtendLength;
		spn_offset.Value = clsVar.varEditorRuntimeSet.OffsetValue;
		chk_offsetbymouse.Check = clsVar.varEditorSet.OffsetByMouse;
		chk_explodearctopolyline.Check = clsVar.varEditorRuntimeSet.ExplodeArcToPolyline;
		chk_explodecircletoarc.Check = clsVar.varEditorRuntimeSet.ExplodeCircleToArc;
		chk_explodecircletopolyline.Check = clsVar.varEditorRuntimeSet.ExplodeCircleToPolyline;
		chk_explodeCompositetoEntity.Check = clsVar.varEditorRuntimeSet.ExplodeCompositeCurveToEntities;
		chk_explodecurvetopolyline.Check = clsVar.varEditorRuntimeSet.ExplodeCurveToPolyline;
		chk_explodeellipsetopolyline.Check = clsVar.varEditorRuntimeSet.ExplodeEllipseToPolyline;
		chk_explodepolylinetoLine.Check = clsVar.varEditorRuntimeSet.ExplodePolylineToLine;
		clsItem.frmEditorV2.OpenFileExtension.Clear();
		clsItem.frmEditorV2.OpenFileExtension.Add("Autocad Files (*.dxf)|*.dxf");
		clsItem.frmEditorV2.OpenFileExtension.Add("Autocad Files (*.dwg)|*.dwg");
		clsItem.frmEditorV2.OpenFileExtension.Add("buCadCam Files (*.bucadv5)|*.bucadv5");
		clsItem.frmEditorV2.OpenFileExtension.Add("buTeach Files (*.buteach)|*.buteach");
		if (clsVar.varEditorRuntimeSet.isSketchMode)
		{
			clsInit.appEditor2.NewSketch();
		}
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		LeftTabMinMax(isMin: true);
		MenuButtonColors(LastPage);
		clsInit.appEditor2.UndoBuffer();
		Class5.smethod_140(this);
	}

	public void Apply()
	{
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (PropertiesForm.Result != DialogResult.OK)
		{
			e.Cancel = true;
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	internal void method_1(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape)
		{
			viewport.ClearAllPreviousCommandData();
			viewport.Invalidate();
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		try
		{
			Control control = sender as Control;
			if (control.Name == btn_close.Name)
			{
				PropertiesForm.Result = DialogResult.Cancel;
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					Dispose();
				}
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
				{
					base.Visible = false;
				}
			}
			if (control.Name == btn_undo.Name && clsInit.appEditor2 != null)
			{
				clsInit.appEditor2.UndoGetBack();
			}
			if (control.Name == btn_new.Name)
			{
				clsInit.appEditor2.cmdNew();
			}
			if (control.Name == btn_open.Name)
			{
				clsInit.appEditor2.cmdOpen();
			}
			if (control.Name == btn_save.Name)
			{
				clsInit.appEditor2.cmdSave();
			}
			if (control.Name == buCheckBox_3.Name)
			{
				clsVar.varEditorRuntimeSet.GridEnable = buCheckBox_3.Check;
				clsInit.appEditor2.GridUpdate();
			}
			if (control.Name == btn_settings.Name)
			{
				try
				{
					F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
					f_ClassViewerDialog.FormCaption = buLangTranslate.preDef.Settings;
					f_ClassViewerDialog.Value = clsVar.varEditorSet;
					f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
					f_ClassViewerDialog.Width = 500;
					f_ClassViewerDialog.Height = 750;
					f_ClassViewerDialog.ValuePersentage = 35.0;
					f_ClassViewerDialog.Init();
					f_ClassViewerDialog.ShowDialog();
					if (f_ClassViewerDialog.Result == DialogResult.OK)
					{
						clsVar.varEditorSet = new EditorSettings((EditorSettings)f_ClassViewerDialog.Value);
						clsInit.appEditor2.GridUpdate();
						clsInit.appEditor2.SaveEditorFile(AppPath.MachineSettings + "\\Editor.prm");
						clsInit.appEditor2.JobUpdate();
					}
				}
				catch (Exception)
				{
				}
			}
			if (control.Name == btn_topview.Name)
			{
				viewport.SetView(viewType.Top, fit: false, animate: false);
				viewport.Invalidate();
			}
			if (control.Name == btn_zoomfit.Name)
			{
				viewport.ZoomFit(10);
				viewport.Invalidate();
			}
			if (control.Name == btn_zoomin.Name)
			{
				viewport.ZoomIn(10);
				viewport.Invalidate();
			}
			if (control.Name == btn_zoomout.Name)
			{
				viewport.ZoomOut(10);
				viewport.Invalidate();
			}
			if (control.Name == btn_eventvalclose.Name)
			{
				grp_events.Visible = false;
			}
			if (control.Name == btn_closeeventpopup.Name)
			{
				grp_eventmovecmd.Visible = false;
			}
			if (control.Name == btn_itemtabminmax.Name)
			{
				if (buTab_Items.Width <= 100)
				{
					LeftTabMinMax(isMin: false);
				}
				else
				{
					LeftTabMinMax(isMin: true);
				}
			}
			if (control.Name == btn_main.Name)
			{
				MenuButtonColors(0);
			}
			if (control.Name == btn_drawing.Name)
			{
				MenuButtonColors(1);
			}
			if (control.Name == btn_library.Name)
			{
				MenuButtonColors(2);
			}
			if (control.Name == btn_marble.Name)
			{
				MenuButtonColors(3);
			}
		}
		catch (Exception)
		{
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == btn_drawline.Name)
		{
			clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineFirstPoint, buLangTranslate.preDef.Line);
			Drafting2D.selectionProcess = false;
			clsInit.appEditor2.action = actionTypeBU.drawLine;
		}
		if (control.Name == btn_drawpolyline.Name)
		{
			clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineFirstPoint, buLangTranslate.preDef.Polyline);
			Drafting2D.selectionProcess = false;
			clsInit.appEditor2.action = actionTypeBU.drawPolyline;
		}
		if (control.Name == btn_drawrect.Name)
		{
			clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineFirstPoint, buLangTranslate.preDef.Rectangle);
			Drafting2D.selectionProcess = false;
			clsInit.appEditor2.action = actionTypeBU.drawRectangle;
		}
		if (control.Name == btn_drawpoint.Name)
		{
			clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefinePoint, buLangTranslate.preDef.Point);
			Drafting2D.selectionProcess = false;
			clsInit.appEditor2.action = actionTypeBU.drawPoint;
		}
		if (control.Name == btn_drawpolygon.Name)
		{
			clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineCenterPoint, buLangTranslate.preDef.Polygon);
			Drafting2D.selectionProcess = false;
			clsInit.appEditor2.action = actionTypeBU.drawPolygon;
		}
		if (control.Name == btn_drawslot.Name)
		{
			clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineFirstPoint, buLangTranslate.preDef.Slot);
			Drafting2D.selectionProcess = false;
			clsInit.appEditor2.action = actionTypeBU.drawSlot;
		}
		if (control.Name == btn_drawspline.Name)
		{
			clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineFirstPoint, buLangTranslate.preDef.Spline);
			Drafting2D.selectionProcess = false;
			clsInit.appEditor2.action = actionTypeBU.drawCurve;
		}
		if (control.Name == btn_drawcircle.Name)
		{
			clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineCenterPoint, buLangTranslate.preDef.Cirlce);
			Drafting2D.selectionProcess = false;
			clsInit.appEditor2.action = actionTypeBU.drawCircle;
		}
		if (control.Name == btn_drawcircle3Pnt.Name)
		{
			clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineFirstPoint, buLangTranslate.preDef.Cirlce);
			Drafting2D.selectionProcess = false;
			clsInit.appEditor2.action = actionTypeBU.drawCircle3Point;
		}
		if (control.Name == btn_drawellipse.Name)
		{
			clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineFirstPoint, buLangTranslate.preDef.Ellipse);
			Drafting2D.selectionProcess = false;
			clsInit.appEditor2.action = actionTypeBU.drawEllipse;
		}
		if (control.Name == btn_drawarc3Pnt.Name)
		{
			clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineFirstPoint, buLangTranslate.preDef.Arc);
			Drafting2D.selectionProcess = false;
			clsInit.appEditor2.action = actionTypeBU.drawArc3Point;
		}
		if (control.Name == btn_drawarc.Name)
		{
			clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineCenterPoint, buLangTranslate.preDef.Arc);
			Drafting2D.selectionProcess = false;
			clsInit.appEditor2.action = actionTypeBU.drawArc;
		}
		if (control.Name == btn_eventok.Name)
		{
			clsInit.appEditor2.cmdEventsOk();
		}
		if (control.Name == btn_move.Name)
		{
			clsInit.appEditor2.cmdEventsMove();
		}
		if (control.Name == btn_copy.Name)
		{
			clsInit.appEditor2.cmdEventsCopy();
		}
		if (control.Name == btn_delete.Name)
		{
			clsInit.appEditor2.cmdEventsDelete();
		}
		if (control.Name == btn_mirror.Name)
		{
			clsInit.appEditor2.cmdEventsMirror();
		}
		if (control.Name == btn_rotate.Name)
		{
			clsInit.appEditor2.cmdEventsRotate();
		}
		if (control.Name == btn_scale.Name)
		{
			clsInit.appEditor2.cmdEventsScale();
		}
		if (control.Name == btn_break.Name)
		{
			clsInit.appEditor2.cmdEventsBreak();
		}
		if (control.Name == btn_offset.Name)
		{
			clsInit.appEditor2.cmdEventsOffset();
		}
		if (control.Name == btn_fillet.Name)
		{
			clsInit.appEditor2.cmdEventsFillet();
		}
		if (control.Name == btn_chamfer.Name)
		{
			clsInit.appEditor2.cmdEventsChamfer();
		}
		if (control.Name == btn_extend.Name)
		{
			clsInit.appEditor2.cmdEventsExtend();
		}
		if (control.Name == btn_trim.Name)
		{
			clsInit.appEditor2.cmdEventsTrim();
		}
		if (!(control.Name == btn_array.Name))
		{
		}
		if (!(control.Name == btn_explode.Name))
		{
		}
	}

	public void btn_lib_Click(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == btn_lib_vertical.Name)
		{
			Drafting2D.points.Clear();
			Drafting2D.selectionProcess = false;
			clsInit.appEditor2.action = actionTypeBU.libraryVertical;
		}
		if (control.Name == btn_lib_horizontal.Name)
		{
			Drafting2D.points.Clear();
			Drafting2D.selectionProcess = false;
			clsInit.appEditor2.action = actionTypeBU.libraryHorizontal;
		}
	}

	public void MenuButtonColors(int PageIndex)
	{
		Control.ControlCollection controls = buGround1.Controls;
		controls = hmiUICommands.SetVisualItem(controls);
		buTab_menu.SelectedIndex = PageIndex;
		if (PageIndex == 0)
		{
			btn_main.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
			btn_main.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
			btn_main.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
			btn_main.ButtonDownDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
			btn_main.ButtonDownDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
			btn_main.ButtonOverDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
			btn_main.ButtonOverDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
		}
		if (PageIndex == 1)
		{
			btn_drawing.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
			btn_drawing.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
			btn_drawing.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
			btn_drawing.ButtonDownDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
			btn_drawing.ButtonDownDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
			btn_drawing.ButtonOverDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
			btn_drawing.ButtonOverDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
		}
		if (PageIndex == 2)
		{
			btn_library.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
			btn_library.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
			btn_library.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
			btn_library.ButtonDownDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
			btn_library.ButtonDownDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
			btn_library.ButtonOverDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
			btn_library.ButtonOverDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
		}
		if (PageIndex == 3)
		{
			btn_marble.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
			btn_marble.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
			btn_marble.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
			btn_marble.ButtonDownDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
			btn_marble.ButtonDownDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
			btn_marble.ButtonOverDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
			btn_marble.ButtonOverDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
		}
		LastPage = PageIndex;
	}

	public void LeftTabMinMax(bool isMin)
	{
		if (!isMin)
		{
			buTab_Items.Width = 310;
			panel_0.Left = buTab_Items.Left + buTab_Items.Width + 2;
			viewport.Left = 0;
			panel_0.Width = base.Width - buTab_Items.Left - buTab_Items.Width - 10;
		}
		else
		{
			buTab_Items.Width = 42;
			panel_0.Left = buTab_Items.Width + 2;
			panel_0.Width = base.Width - buTab_Items.Width - 10;
		}
	}

	public void CreateModelControl(ref Drafting2D viewport, CreateModelProperties Properties)
	{
		viewport = new Drafting2D();
		viewport.InitializeViewports();
		viewport.CreateControl();
		viewport.CreateGraphics();
		viewport.Dock = DockStyle.Fill;
		if (Properties.Width > 0)
		{
			viewport.Width = Properties.Width;
		}
		if (Properties.Height > 0)
		{
			viewport.Height = Properties.Height;
		}
		BackgroundSettings background = new BackgroundSettings(backgroundStyleType.LinearGradient, Properties.BottomColor, Properties.MiddleColor, Properties.TopColor, 0.75, null, colorThemeType.Auto, 0.3);
		viewport.Viewports[0].Background = background;
		viewport.ActiveViewport.DisplayMode = Properties.DisplayType;
		viewport.Viewports[0].Pan.MouseButton = new MouseButton(Properties.PanMouseButtons.Button, Properties.PanMouseButtons.ModifierKey);
		viewport.Viewports[0].Rotate.MouseButton = new MouseButton(Properties.RotateMouseButtons.Button, Properties.RotateMouseButtons.ModifierKey);
		viewport.Viewports[0].Zoom.MouseButton = new MouseButton(Properties.ZoomMouseButtons.Button, Properties.ZoomMouseButtons.ModifierKey);
		viewport.Viewports[0].Camera.ProjectionMode = Properties.ProjetionType;
		viewport.Viewports[0].Grid.Visible = Properties.GridVisible;
		viewport.Viewports[0].Grid.Step = Properties.GridStepX;
		viewport.Viewports[0].OriginSymbol.Visible = Properties.OriginSymbolVisible;
		viewport.Viewports[0].Zoom.ReverseMouseWheel = Properties.ReverseMouseWheel;
		viewport.Viewports[0].OriginSymbol.LabelOrigin = "";
		viewport.Viewports[0].OriginSymbol.StyleMode = Properties.OrigineSymbol;
		viewport.Viewports[0].OriginSymbol.Size = Properties.OrigineSize;
		viewport.Viewports[0].OriginSymbol.LabelAxisX = "";
		viewport.Viewports[0].OriginSymbol.LabelAxisY = "";
		viewport.Viewports[0].OriginSymbol.LabelAxisZ = "";
		viewport.Viewports[0].OriginSymbol.EdgeColor = Color.Black;
		viewport.Viewports[0].CoordinateSystemIcon.Visible = Properties.CoordinateSystemIconVisible;
		viewport.Viewports[0].ViewCubeIcon.Visible = Properties.ViewCubeIconVisible;
		viewport.Viewports[0].ToolBar.Visible = Properties.ToolBorVisible;
	}

	internal void method_4(object object_0, bool bool_0)
	{
		Control control = object_0 as Control;
		if (PropertiesForm.Inited)
		{
			if (control.Name == buCheckBox_2.Name)
			{
				clsVar.varEditorSet.OsnapEntity = buCheckBox_2.Check;
				clsInit.appEditor.SaveEditorFile();
			}
			if (control.Name == buCheckBox_0.Name)
			{
				clsVar.varEditorSet.OsnapGrid = buCheckBox_0.Check;
				clsInit.appEditor.SaveEditorFile();
			}
			if (control.Name == buCheckBox_1.Name)
			{
				clsVar.varEditorSet.Ortho = buCheckBox_1.Check;
				clsInit.appEditor.SaveEditorFile();
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
