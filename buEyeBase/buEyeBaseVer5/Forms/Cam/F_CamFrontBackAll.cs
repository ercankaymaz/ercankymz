// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Cam.F_CamFrontBackAll
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Components;
using buControls.Controls;
using buControls.DialogBox;
using buCore;
using buEyeBaseVer5.Forms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Cam;

public class F_CamFrontBackAll : Form
{
  public buSpin spn_bottomheight;
  internal buControlDisplaySet \u0003;
  public buGround Ground_Ref;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public hmiUIBasicSettings Settings;
  internal IContainer \u0001;
  public buButton btn_close;

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    buLabel buLabel = obj0 as buLabel;
    if (buLabel.Name == ((F_CamTriMeshSettings) this).\u0002.Name)
    {
      Color backColor = buLabel.Display.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
      {
        buLabel.Display.BackColor = backColor;
        buLabel.Text = buImage.GetColorKnownName(backColor);
        ((F_CamTriMeshSettings) this).dgv_ref.BackgroundColor = backColor;
      }
    }
    if (buLabel.Name == ((F_CamTriMeshSettings) this).\u0005.Name)
    {
      Color backColor = buLabel.Display.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
      {
        buLabel.Display.BackColor = backColor;
        buLabel.Text = buImage.GetColorKnownName(backColor);
        ((F_CamTriMeshSettings) this).dgv_ref.GridColor = backColor;
      }
    }
    if (buLabel.Name == ((F_CamTriMeshSettings) this).\u0007.Name)
    {
      Color backColor = buLabel.Display.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
      {
        buLabel.Display.BackColor = backColor;
        buLabel.Text = buImage.GetColorKnownName(backColor);
        ((F_CamTriMeshSettings) this).dgv_ref.DefaultCellStyle.BackColor = backColor;
      }
    }
    if (buLabel.Name == ((F_CamTriMeshSettings) this).\u0008.Name)
    {
      Color backColor = buLabel.Display.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
      {
        buLabel.Display.BackColor = backColor;
        buLabel.Text = buImage.GetColorKnownName(backColor);
        ((F_CamTriMeshSettings) this).dgv_ref.DefaultCellStyle.SelectionBackColor = backColor;
      }
    }
    if (buLabel.Name == ((F_CamTriMeshSettings) this).\u0003.Name)
    {
      Color backColor = buLabel.Display.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
      {
        buLabel.Display.BackColor = backColor;
        buLabel.Text = buImage.GetColorKnownName(backColor);
        ((F_CamTriMeshSettings) this).dgv_ref.DefaultCellStyle.ForeColor = backColor;
        ((F_CamTriMeshSettings) this).dgv_ref.DefaultCellStyle.SelectionForeColor = backColor;
      }
    }
    if (buLabel.Name == ((F_CamTriMeshSettings) this).\u0011.Name)
    {
      Color backColor = buLabel.Display.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
      {
        buLabel.Display.BackColor = backColor;
        buLabel.Text = buImage.GetColorKnownName(backColor);
        ((F_CamTriMeshSettings) this).dgv_ref.ColumnHeadersDefaultCellStyle.BackColor = backColor;
        ((F_CamTriMeshSettings) this).dgv_ref.RowHeadersDefaultCellStyle.BackColor = backColor;
      }
    }
    if (!(buLabel.Name == ((F_CamTriMeshSettings) this).\u000F.Name))
      return;
    Color backColor1 = buLabel.Display.BackColor;
    if (ColorDialogBox.ShowDialog(ref backColor1) != DialogResult.OK)
      return;
    buLabel.Display.BackColor = backColor1;
    buLabel.Text = buImage.GetColorKnownName(backColor1);
    ((F_CamTriMeshSettings) this).dgv_ref.ColumnHeadersDefaultCellStyle.ForeColor = backColor1;
    ((F_CamTriMeshSettings) this).dgv_ref.RowHeadersDefaultCellStyle.ForeColor = backColor1;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_CamTriMeshSettings) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_CamTriMeshSettings) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_CamFrontBackAll() => F_CamTriMeshSettings.Captions = new List<string>();

  public F_CamFrontBackAll()
  {
    ((F_CamTriMeshSettings) this).PropertiesForm = new FormProperties();
    ((F_CamTriMeshSettings) this).Settings = (hmiUISettings) new buEyeShotFunctions();
    ((F_CamTriMeshSettings) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_ControlUIGroup) this);
  }

  public void Init()
  {
    ((F_CamTriMeshSettings) this).PropertiesForm.Inited = false;
    if (((F_CamTriMeshSettings) this).PropertiesForm.Height > 10)
      this.Height = ((F_CamTriMeshSettings) this).PropertiesForm.Height;
    if (((F_CamTriMeshSettings) this).PropertiesForm.Width > 10)
      this.Width = ((F_CamTriMeshSettings) this).PropertiesForm.Width;
    this.TopMost = ((F_CamTriMeshSettings) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_CamTriMeshSettings) this).PropertiesForm.FormPosition;
    ((F_CamTriMeshSettings) this).\u0001.Items.Clear();
    ((F_CamTriMeshSettings) this).\u0001.Items.AddRange(Enum.GetValues(typeof (ContentAlignment)).Cast<object>().ToArray<object>());
    ((F_CamTriMeshSettings) this).\u0002.Items.Clear();
    ((F_CamTriMeshSettings) this).\u0002.Items.AddRange(Enum.GetValues(typeof (ShapeType)).Cast<object>().ToArray<object>());
    ((F_CamTriMeshSettings) this).\u0001.Display = ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Caption;
    ((F_CamTriMeshSettings) this).\u0002.Display = ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Display;
    ((F_CamTriMeshSettings) this).spn_geometryrad.Value = (double) ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).GeometryArcDiameer;
    ((F_CamTriMeshSettings) this).\u0002.SelectedItem = (object) ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).GeometryType;
    ((F_CamTriMeshSettings) this).\u0001.SelectedItem = (object) ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).ImageAlignment;
    ((F_CamTriMeshSettings) this).spn_headerheight.Value = (double) ((buFile5.PLYToSchematic.\u0002) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).TopHeight;
    ((F_CamTriMeshSettings) this).grp_ref.TitleHeight = ((buFile5.PLYToSchematic.\u0002) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).TopHeight;
    ((F_CamTriMeshSettings) this).grp_ref.Geometry.ArcDiameter = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).GeometryArcDiameer;
    ((F_CamTriMeshSettings) this).grp_ref.Geometry.ShapeMode = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).GeometryType;
    ((F_CamTriMeshSettings) this).grp_ref.ImageAlign = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_CamTriMeshSettings) this).Settings).Parameters).ImageAlignment;
    ((F_CamTriMeshSettings) this).grp_ref.Display = ((F_CamTriMeshSettings) this).\u0002.Display;
    ((F_CamTriMeshSettings) this).grp_ref.TitleDisplay = ((F_CamTriMeshSettings) this).\u0001.Display;
    ((F_CamTriMeshSettings) this).\u0001.UpdateControl();
    ((F_CamTriMeshSettings) this).\u0002.UpdateControl();
    ((F_CamTriMeshSettings) this).PropertiesForm.Result = DialogResult.None;
    ((F_CamTriMeshSettings) this).PropertiesForm.Inited = true;
    \u0007.\u0001.\u0001((F_ControlUIGroup) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_CamTriMeshSettings) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_CamTriMeshSettings) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }
}
