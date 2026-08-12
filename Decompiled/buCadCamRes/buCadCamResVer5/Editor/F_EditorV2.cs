// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Editor.F_EditorV2
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buControls.ClassViewer;
using buControls.Controls;
using buEyeBaseVer5;
using buEyeBaseVer5.Variables;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Graphics;
using devDept.Geometry;
using ns8;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Editor;

public class F_EditorV2 : Form
{
  public FormProperties PropertiesForm = new FormProperties();
  public Drafting2D viewport = (Drafting2D) null;
  public int LastPage = 0;
  public bool LibraryPointJoinMode = false;
  public bool LibraryJoinEndpointsMode = false;
  public List<string> OpenFileExtension = new List<string>();
  internal IContainer icontainer_0 = (IContainer) null;
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
    this.WireEditorShortcutButtons();
  }

  private void WireEditorShortcutButtons()
  {
    this.btn_movexmin.Click += new EventHandler(this.btn_editor_transform_Click);
    this.btn_movexmax.Click += new EventHandler(this.btn_editor_transform_Click);
    this.btn_moveymin.Click += new EventHandler(this.btn_editor_transform_Click);
    this.btn_movexmay.Click += new EventHandler(this.btn_editor_transform_Click);
    this.btn_rotateCW.Click += new EventHandler(this.btn_editor_transform_Click);
    this.btn_rotateCCW.Click += new EventHandler(this.btn_editor_transform_Click);
    this.btn_closeeventpopup.Click += new EventHandler(this.method_2);
    this.buButton5.Click += new EventHandler(this.method_2);
    this.buButton3.Click += new EventHandler(this.btn_editor_go_Click);
  }

  private void btn_editor_transform_Click(object sender, EventArgs e)
  {
    System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;
    if (control == null || this.viewport == null || clsInit.appEditor2 == null)
      return;
    try
    {
      List<devDept.Eyeshot.Entities.Entity> selected = new List<devDept.Eyeshot.Entities.Entity>();
      foreach (devDept.Eyeshot.Entities.Entity entity in this.viewport.Entities)
      {
        if (entity.Selected)
          selected.Add(entity);
      }
      if (selected.Count == 0)
      {
        clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.SelectEntities, "Quick transform");
        return;
      }
      double value = Math.Abs(this.spn_moveval.Value);
      if (value <= 1E-09)
      {
        clsInit.appEditor2.StatusUpdate("Enter a value greater than zero", "Quick transform");
        return;
      }
      clsInit.appEditor2.UndoBuffer();
      if (control.Name == this.btn_movexmin.Name || control.Name == this.btn_movexmax.Name ||
          control.Name == this.btn_moveymin.Name || control.Name == this.btn_movexmay.Name)
      {
        double x = control.Name == this.btn_movexmin.Name ? -value : control.Name == this.btn_movexmax.Name ? value : 0.0;
        double y = control.Name == this.btn_moveymin.Name ? -value : control.Name == this.btn_movexmay.Name ? value : 0.0;
        Vector3D translation = new Vector3D(x, y, 0.0);
        for (int index = 0; index < selected.Count; ++index)
          selected[index].Translate(translation);
      }
      else
      {
        clsInit.cVector5.BoxSizeCalculateSelected(this.viewport.Entities, ref Drafting2D.boxMin, ref Drafting2D.boxMid, ref Drafting2D.boxMax);
        double angle = value * Math.PI / 180.0;
        if (control.Name == this.btn_rotateCW.Name)
          angle = -angle;
        for (int index = 0; index < selected.Count; ++index)
          selected[index].Rotate(angle, Vector3D.AxisZ, Drafting2D.boxMid);
      }
      this.viewport.Entities.Regen();
      this.viewport.Entities.UpdateBoundingBox();
      this.viewport.Invalidate();
      clsInit.appEditor2.JobUpdate();
    }
    catch (Exception ex)
    {
      this.ReportEditorError(ex, control.Name);
    }
  }

  private void btn_editor_go_Click(object sender, EventArgs e)
  {
    if (this.viewport == null || clsInit.appEditor2 == null)
      return;
    try
    {
      List<devDept.Eyeshot.Entities.Entity> selected = new List<devDept.Eyeshot.Entities.Entity>();
      foreach (devDept.Eyeshot.Entities.Entity entity in this.viewport.Entities)
      {
        if (entity.Selected)
          selected.Add(entity);
      }
      if (selected.Count == 0)
      {
        clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.SelectEntities, "Move to X/Y");
        return;
      }
      clsInit.cVector5.BoxSizeCalculateSelected(this.viewport.Entities, ref Drafting2D.boxMin, ref Drafting2D.boxMid, ref Drafting2D.boxMax);
      Vector3D translation = new Vector3D(this.spn_x.Value - Drafting2D.boxMid.X, this.spn_y.Value - Drafting2D.boxMid.Y, 0.0);
      if (Math.Abs(translation.X) + Math.Abs(translation.Y) + Math.Abs(translation.Z) <= 1E-09)
        return;
      clsInit.appEditor2.UndoBuffer();
      for (int index = 0; index < selected.Count; ++index)
        selected[index].Translate(translation);
      this.viewport.Entities.Regen();
      this.viewport.Entities.UpdateBoundingBox();
      this.viewport.Invalidate();
      clsInit.appEditor2.JobUpdate();
    }
    catch (Exception ex)
    {
      this.ReportEditorError(ex, "Move to X/Y");
    }
  }

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (clsInit.appEditor2 == null)
      clsInit.appEditor2 = new clsEditorV2();
    clsInit.appEditor2.Init();
    string machineEditorSettings = AppPath.MachineSettings + "\\Editor.prm";
    string globalEditorSettings = AppPath.Settings + "\\Editor.prm";
    if (clsInit.appEditor2 != null)
    {
      if (File.Exists(machineEditorSettings))
        clsInit.appEditor2.OpenEditorFile(machineEditorSettings);
      else if (File.Exists(globalEditorSettings))
        clsInit.appEditor2.OpenEditorFile(globalEditorSettings);
    }
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    this.buTab_EventVals.ItemSize = new Size(1, 1);
    this.buTab_menu.ItemSize = new Size(1, 1);
    this.buTab_menu.Tabs.Header.Fonts.ForeColor = Color.Black;
    this.buTab_menu.Tabs.Header.Border.Visible = false;
    this.buTab_Items.ItemSize = new Size(1, 1);
    this.buTab_Items.Tabs.Header.Fonts.ForeColor = Color.Black;
    this.buTab_Items.Tabs.Header.Border.Visible = false;
    this.btn_marble.Visible = false;
    if (this.viewport == null)
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
      this.CreateModelControl(ref this.viewport, Properties);
      clsInit.appEditor2.GridUpdate();
      this.panel_0.Controls.Add((System.Windows.Forms.Control) this.viewport);
      this.viewport.ZoomFit(true);
    }
    this.viewport.Selection.Color = clsVar.varEditorSet.colorSelected;
    this.viewport.SetView(viewType.Top);
    this.viewport.Invalidate();
    this.viewport.AssemblySelectionMode = Workspace.assemblySelectionType.Branch;
    this.buCheckBox_2.Check = clsVar.varEditorSet.OsnapEntity;
    this.buCheckBox_0.Check = clsVar.varEditorSet.OsnapGrid;
    this.buCheckBox_1.Check = clsVar.varEditorSet.Ortho;
    this.buCheckBox_3.Check = clsVar.varEditorRuntimeSet.GridEnable;
    this.spn_filletrad.Value = clsVar.varEditorRuntimeSet.FilletRadius;
    this.spn_chamgerlen.Value = clsVar.varEditorRuntimeSet.ChamferLength;
    this.spn_scaleratio.Value = clsVar.varEditorRuntimeSet.ScaleRatio;
    this.spn_extndlen.Value = clsVar.varEditorRuntimeSet.ExtendLength;
    this.spn_offset.Value = clsVar.varEditorRuntimeSet.OffsetValue;
    if (this.spn_moveval.Value <= 0.0)
      this.spn_moveval.Value = 1.0;
    this.chk_offsetbymouse.Check = clsVar.varEditorSet.OffsetByMouse;
    this.chk_explodearctopolyline.Check = clsVar.varEditorRuntimeSet.ExplodeArcToPolyline;
    this.chk_explodecircletoarc.Check = clsVar.varEditorRuntimeSet.ExplodeCircleToArc;
    this.chk_explodecircletopolyline.Check = clsVar.varEditorRuntimeSet.ExplodeCircleToPolyline;
    this.chk_explodeCompositetoEntity.Check = clsVar.varEditorRuntimeSet.ExplodeCompositeCurveToEntities;
    this.chk_explodecurvetopolyline.Check = clsVar.varEditorRuntimeSet.ExplodeCurveToPolyline;
    this.chk_explodeellipsetopolyline.Check = clsVar.varEditorRuntimeSet.ExplodeEllipseToPolyline;
    this.chk_explodepolylinetoLine.Check = clsVar.varEditorRuntimeSet.ExplodePolylineToLine;
    clsItem.frmEditorV2.OpenFileExtension.Clear();
    clsItem.frmEditorV2.OpenFileExtension.Add("Autocad Files (*.dxf)|*.dxf");
    clsItem.frmEditorV2.OpenFileExtension.Add("Autocad Files (*.dwg)|*.dwg");
    clsItem.frmEditorV2.OpenFileExtension.Add("buCadCam Files (*.bucadv5)|*.bucadv5");
    clsItem.frmEditorV2.OpenFileExtension.Add("buTeach Files (*.buteach)|*.buteach");
    if (clsVar.varEditorRuntimeSet.isSketchMode)
      clsInit.appEditor2.NewSketch();
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
    this.LeftTabMinMax(true);
    this.MenuButtonColors(this.LastPage);
    clsInit.appEditor2.UndoBuffer();
    Class5.smethod_140(this);
  }

  public void Apply()
  {
  }

  internal void method_0(object sender, FormClosingEventArgs e)
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

  internal void method_1(object sender, KeyEventArgs e)
  {
    if (e.KeyCode != Keys.Escape)
      return;
    this.viewport.ClearAllPreviousCommandData();
    this.viewport.Invalidate();
  }

  internal void method_2(object sender, EventArgs e)
  {
    try
    {
      System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;
      if (control == null)
        return;
      if (control.Name == this.btn_close.Name)
      {
        this.PropertiesForm.Result = DialogResult.Cancel;
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control.Name == this.btn_undo.Name && clsInit.appEditor2 != null)
        clsInit.appEditor2.UndoGetBack();
      if (control.Name == this.btn_new.Name)
        clsInit.appEditor2.cmdNew();
      if (control.Name == this.btn_open.Name)
        clsInit.appEditor2.cmdOpen();
      if (control.Name == this.btn_save.Name)
        clsInit.appEditor2.cmdSave();
      if (control.Name == this.buCheckBox_3.Name)
      {
        clsVar.varEditorRuntimeSet.GridEnable = this.buCheckBox_3.Check;
        clsInit.appEditor2.GridUpdate();
        clsInit.appEditor2.SaveEditorFile(AppPath.MachineSettings + "\\Editor.prm");
      }
      if (control.Name == this.btn_settings.Name)
      {
        try
        {
          F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
          classViewerDialog.FormCaption = buLangTranslate.preDef.Settings;
          classViewerDialog.Value = (object) clsVar.varEditorSet;
          classViewerDialog.StartPosition = FormStartPosition.CenterParent;
          classViewerDialog.Width = 500;
          classViewerDialog.Height = 750;
          classViewerDialog.ValuePersentage = 35.0;
          classViewerDialog.Init();
          int num = (int) classViewerDialog.ShowDialog();
          if (classViewerDialog.Result == DialogResult.OK)
          {
            clsVar.varEditorSet = new EditorSettings((EditorSettings) classViewerDialog.Value);
            clsInit.appEditor2.GridUpdate();
            clsInit.appEditor2.SaveEditorFile(AppPath.MachineSettings + "\\Editor.prm");
            clsInit.appEditor2.JobUpdate();
          }
        }
        catch (Exception ex)
        {
          this.ReportEditorError(ex, "Editor settings");
        }
      }
      if (control.Name == this.btn_topview.Name)
      {
        this.viewport.SetView(viewType.Top, false, false);
        this.viewport.Invalidate();
      }
      if (control.Name == this.btn_zoomfit.Name)
      {
        this.viewport.ZoomFit(10);
        this.viewport.Invalidate();
      }
      if (control.Name == this.btn_zoomin.Name)
      {
        this.viewport.ZoomIn(10);
        this.viewport.Invalidate();
      }
      if (control.Name == this.btn_zoomout.Name)
      {
        this.viewport.ZoomOut(10);
        this.viewport.Invalidate();
      }
      if (control.Name == this.btn_eventvalclose.Name)
        this.grp_events.Visible = false;
      if (control.Name == this.btn_closeeventpopup.Name)
        this.grp_eventmovecmd.Visible = false;
      if (control.Name == this.btn_itemtabminmax.Name || control.Name == this.buButton5.Name)
      {
        if (this.buTab_Items.Width > 100)
          this.LeftTabMinMax(true);
        else
          this.LeftTabMinMax(false);
      }
      if (control.Name == this.btn_main.Name)
        this.MenuButtonColors(0);
      if (control.Name == this.btn_drawing.Name)
        this.MenuButtonColors(1);
      if (control.Name == this.btn_library.Name)
        this.MenuButtonColors(2);
      if (!(control.Name == this.btn_marble.Name))
        return;
      this.MenuButtonColors(3);
    }
    catch (Exception ex)
    {
      this.ReportEditorError(ex, "Editor command");
    }
  }

  internal void method_3(object sender, EventArgs e)
  {
    System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;
    if (control == null)
      return;
    try
    {
      bool drawingCommand = control.Name == this.btn_drawline.Name ||
                            control.Name == this.btn_drawpolyline.Name ||
                            control.Name == this.btn_drawrect.Name ||
                            control.Name == this.btn_drawpoint.Name ||
                            control.Name == this.btn_drawpolygon.Name ||
                            control.Name == this.btn_drawslot.Name ||
                            control.Name == this.btn_drawspline.Name ||
                            control.Name == this.btn_drawcircle.Name ||
                            control.Name == this.btn_drawcircle3Pnt.Name ||
                            control.Name == this.btn_drawellipse.Name ||
                            control.Name == this.btn_drawarc3Pnt.Name ||
                            control.Name == this.btn_drawarc.Name;
      if (drawingCommand && this.viewport != null)
        this.viewport.ClearAllPreviousCommandData();
    if (control.Name == this.btn_drawline.Name)
    {
      clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineFirstPoint, buLangTranslate.preDef.Line);
      Drafting2D.selectionProcess = false;
      clsInit.appEditor2.action = actionTypeBU.drawLine;
    }
    if (control.Name == this.btn_drawpolyline.Name)
    {
      clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineFirstPoint, buLangTranslate.preDef.Polyline);
      Drafting2D.selectionProcess = false;
      clsInit.appEditor2.action = actionTypeBU.drawPolyline;
    }
    if (control.Name == this.btn_drawrect.Name)
    {
      clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineFirstPoint, buLangTranslate.preDef.Rectangle);
      Drafting2D.selectionProcess = false;
      clsInit.appEditor2.action = actionTypeBU.drawRectangle;
    }
    if (control.Name == this.btn_drawpoint.Name)
    {
      clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefinePoint, buLangTranslate.preDef.Point);
      Drafting2D.selectionProcess = false;
      clsInit.appEditor2.action = actionTypeBU.drawPoint;
    }
    if (control.Name == this.btn_drawpolygon.Name)
    {
      clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineCenterPoint, buLangTranslate.preDef.Polygon);
      Drafting2D.selectionProcess = false;
      clsInit.appEditor2.action = actionTypeBU.drawPolygon;
    }
    if (control.Name == this.btn_drawslot.Name)
    {
      clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineFirstPoint, buLangTranslate.preDef.Slot);
      Drafting2D.selectionProcess = false;
      clsInit.appEditor2.action = actionTypeBU.drawSlot;
    }
    if (control.Name == this.btn_drawspline.Name)
    {
      clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineFirstPoint, buLangTranslate.preDef.Spline);
      Drafting2D.selectionProcess = false;
      clsInit.appEditor2.action = actionTypeBU.drawCurve;
    }
    if (control.Name == this.btn_drawcircle.Name)
    {
      clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineCenterPoint, buLangTranslate.preDef.Cirlce);
      Drafting2D.selectionProcess = false;
      clsInit.appEditor2.action = actionTypeBU.drawCircle;
    }
    if (control.Name == this.btn_drawcircle3Pnt.Name)
    {
      clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineFirstPoint, buLangTranslate.preDef.Cirlce);
      Drafting2D.selectionProcess = false;
      clsInit.appEditor2.action = actionTypeBU.drawCircle3Point;
    }
    if (control.Name == this.btn_drawellipse.Name)
    {
      clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineFirstPoint, buLangTranslate.preDef.Ellipse);
      Drafting2D.selectionProcess = false;
      clsInit.appEditor2.action = actionTypeBU.drawEllipse;
    }
    if (control.Name == this.btn_drawarc3Pnt.Name)
    {
      clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineFirstPoint, buLangTranslate.preDef.Arc);
      Drafting2D.selectionProcess = false;
      clsInit.appEditor2.action = actionTypeBU.drawArc3Point;
    }
    if (control.Name == this.btn_drawarc.Name)
    {
      clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.DefineCenterPoint, buLangTranslate.preDef.Arc);
      Drafting2D.selectionProcess = false;
      clsInit.appEditor2.action = actionTypeBU.drawArc;
    }
    if (control.Name == this.btn_eventok.Name)
      clsInit.appEditor2.cmdEventsOk();
    if (control.Name == this.btn_move.Name)
      clsInit.appEditor2.cmdEventsMove();
    if (control.Name == this.btn_copy.Name)
      clsInit.appEditor2.cmdEventsCopy();
    if (control.Name == this.btn_delete.Name)
      clsInit.appEditor2.cmdEventsDelete();
    if (control.Name == this.btn_mirror.Name)
      clsInit.appEditor2.cmdEventsMirror();
    if (control.Name == this.btn_rotate.Name)
      clsInit.appEditor2.cmdEventsRotate();
    if (control.Name == this.btn_scale.Name)
      clsInit.appEditor2.cmdEventsScale();
    if (control.Name == this.btn_break.Name)
      clsInit.appEditor2.cmdEventsBreak();
    if (control.Name == this.btn_offset.Name)
      clsInit.appEditor2.cmdEventsOffset();
    if (control.Name == this.btn_fillet.Name)
      clsInit.appEditor2.cmdEventsFillet();
    if (control.Name == this.btn_chamfer.Name)
      clsInit.appEditor2.cmdEventsChamfer();
    if (control.Name == this.btn_extend.Name)
      clsInit.appEditor2.cmdEventsExtend();
    if (control.Name == this.btn_trim.Name)
      clsInit.appEditor2.cmdEventsTrim();
    if (control.Name == this.btn_array.Name)
      clsInit.appEditor2.cmdEventsLinearArray();
    if (control.Name == this.btn_explode.Name)
      clsInit.appEditor2.cmdEventsExplode();
    }
    catch (Exception ex)
    {
      this.ReportEditorError(ex, control.Name);
    }
  }

  public void btn_lib_Click(object sender, EventArgs e)
  {
    System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;
    if (control == null)
      return;
    try
    {
      if (this.viewport != null)
        this.viewport.ClearAllPreviousCommandData();
      this.LibraryPointJoinMode = false;
      this.LibraryJoinEndpointsMode = false;
      if (control.Name == this.btn_lib_new.Name)
      {
        clsInit.appEditor2.NewSketch();
        return;
      }
      if (control.Name == this.btn_lib_open.Name)
      {
        clsInit.appEditor2.cmdOpenLib();
        return;
      }
      if (control.Name == this.btn_lib_save.Name)
      {
        clsInit.appEditor2.cmdSaveLib((Design) this.viewport);
        return;
      }
      if (control.Name == this.btn_lib_undo.Name)
      {
        clsInit.appEditor2.cmdUndo();
        return;
      }
      if (control.Name == this.btn_lib_redo.Name)
      {
        clsInit.appEditor2.cmdRedo();
        return;
      }
      if (control.Name == this.btn_lib_offset.Name)
      {
        clsInit.appEditor2.cmdEventsOffset();
        return;
      }
      if (control.Name == this.btn_lib_mirror.Name)
      {
        clsInit.appEditor2.cmdEventsMirror();
        return;
      }
      actionTypeBU action = actionTypeBU.None;
      if (control.Name == this.btn_lib_vertical.Name)
        action = actionTypeBU.libraryVertical;
      else if (control.Name == this.btn_lib_horizontal.Name)
        action = actionTypeBU.libraryHorizontal;
      else if (control.Name == this.btn_lib_length.Name)
        action = actionTypeBU.libraryLength;
      else if (control.Name == this.btn_lib_fix.Name)
        action = actionTypeBU.libraryFixPoint;
      else if (control.Name == this.btn_lib_EQRad.Name)
        action = actionTypeBU.libraryEqualRadius;
      else if (control.Name == this.btn_lib_EQLength.Name)
        action = actionTypeBU.libraryEqualLength;
      else if (control.Name == this.btn_lib_Paralel.Name)
        action = actionTypeBU.libraryParalel;
      else if (control.Name == this.btn_lib_perpendicular.Name)
        action = actionTypeBU.libraryPerpendiculat;
      else if (control.Name == this.btn_lib_fillet.Name)
        action = actionTypeBU.libraryFillet;
      else if (control.Name == this.btn_lib_chamger.Name)
        action = actionTypeBU.libraryChamfer;
      else if (control.Name == this.btn_lib_lineline.Name)
        action = actionTypeBU.libraryLineLine;
      else if (control.Name == this.btn_lib_linepoint.Name)
        action = actionTypeBU.libraryLinePoint;
      else if (control.Name == this.btn_lib_pointpoint.Name)
        action = actionTypeBU.libraryPointPoint;
      else if (control.Name == this.btn_libangle.Name)
        action = actionTypeBU.libraryAngle;
      else if (control.Name == this.btn_lib_radius.Name)
        action = actionTypeBU.libraryRadius;
      else if (control.Name == this.btn_lib_colliniear.Name)
        action = actionTypeBU.libraryCollinear;
      else if (control.Name == this.btn_lib_tangent.Name)
        action = actionTypeBU.libraryTangent;
      else if (control.Name == this.btn_lib_delete.Name)
        action = actionTypeBU.libraryDeleteEntity;
      else if (control.Name == this.btn_lib_onpoint.Name)
      {
        action = actionTypeBU.libraryPointPoint;
        this.LibraryPointJoinMode = true;
      }
      else if (control.Name == this.btn_lib_jointpoint.Name)
      {
        action = actionTypeBU.libraryPointPoint;
        this.LibraryJoinEndpointsMode = true;
      }
      if (action == actionTypeBU.None)
        return;
      Drafting2D.points.Clear();
      Drafting2D.selectionProcess = false;
      Drafting2D.entitiesSelected.Clear();
      clsInit.appEditor2.action = action;
      clsInit.appEditor2.StatusUpdate(buLangTranslate.preSentences.SelectEntities, control.Text);
    }
    catch (Exception ex)
    {
      this.ReportEditorError(ex, control.Name);
    }
  }

  private void ReportEditorError(Exception ex, string command)
  {
    string message = ex == null ? "Unknown editor error" : ex.Message;
    if (this.lbl_status != null)
      this.lbl_status.Text = command + " : " + message;
    buLog.addLog("", "Not Ok: " + message, command);
  }

  public void MenuButtonColors(int PageIndex)
  {
    hmiUICommands.SetVisualItem(this.buGround1.Controls);
    this.buTab_menu.SelectedIndex = PageIndex;
    if (PageIndex == 0)
    {
      this.btn_main.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
      this.btn_main.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
      this.btn_main.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
      this.btn_main.ButtonDownDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
      this.btn_main.ButtonDownDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
      this.btn_main.ButtonOverDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
      this.btn_main.ButtonOverDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 1)
    {
      this.btn_drawing.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
      this.btn_drawing.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
      this.btn_drawing.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
      this.btn_drawing.ButtonDownDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
      this.btn_drawing.ButtonDownDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
      this.btn_drawing.ButtonOverDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
      this.btn_drawing.ButtonOverDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 2)
    {
      this.btn_library.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
      this.btn_library.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
      this.btn_library.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
      this.btn_library.ButtonDownDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
      this.btn_library.ButtonDownDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
      this.btn_library.ButtonOverDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
      this.btn_library.ButtonOverDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 3)
    {
      this.btn_marble.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
      this.btn_marble.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
      this.btn_marble.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
      this.btn_marble.ButtonDownDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
      this.btn_marble.ButtonDownDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
      this.btn_marble.ButtonOverDisplay.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
      this.btn_marble.ButtonOverDisplay.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal.SelectionColor;
    }
    this.LastPage = PageIndex;
  }

  public void LeftTabMinMax(bool isMin)
  {
    if (isMin)
    {
      this.buTab_Items.Width = 42;
      this.panel_0.Left = this.buTab_Items.Width + 2;
      this.panel_0.Width = this.Width - this.buTab_Items.Width - 10;
    }
    else
    {
      this.buTab_Items.Width = 310;
      this.panel_0.Left = this.buTab_Items.Left + this.buTab_Items.Width + 2;
      this.viewport.Left = 0;
      this.panel_0.Width = this.Width - this.buTab_Items.Left - this.buTab_Items.Width - 10;
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
      viewport.Width = Properties.Width;
    if (Properties.Height > 0)
      viewport.Height = Properties.Height;
    BackgroundSettings backgroundSettings = new BackgroundSettings(backgroundStyleType.LinearGradient, Properties.BottomColor, Properties.MiddleColor, Properties.TopColor, 0.75, (Image) null, colorThemeType.Auto, 0.3);
    viewport.Viewports[0].Background = backgroundSettings;
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
    System.Windows.Forms.Control control = object_0 as System.Windows.Forms.Control;
    if (!this.PropertiesForm.Inited || control == null || clsInit.appEditor2 == null)
      return;
    if (control.Name == this.buCheckBox_2.Name)
    {
      clsVar.varEditorSet.OsnapEntity = this.buCheckBox_2.Check;
      clsInit.appEditor2.SaveEditorFile(AppPath.MachineSettings + "\\Editor.prm");
    }
    if (control.Name == this.buCheckBox_0.Name)
    {
      clsVar.varEditorSet.OsnapGrid = this.buCheckBox_0.Check;
      clsInit.appEditor2.SaveEditorFile(AppPath.MachineSettings + "\\Editor.prm");
    }
    if (!(control.Name == this.buCheckBox_1.Name))
      return;
    clsVar.varEditorSet.Ortho = this.buCheckBox_1.Check;
    clsInit.appEditor2.SaveEditorFile(AppPath.MachineSettings + "\\Editor.prm");
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
