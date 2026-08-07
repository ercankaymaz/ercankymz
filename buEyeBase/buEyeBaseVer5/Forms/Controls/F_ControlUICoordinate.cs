// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Controls.F_ControlUICoordinate
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.Customer.DincMak;
using buEyeBaseVer5.Forms.Diamaker;
using buEyeBaseVer5.Forms.Foam;
using devDept.Eyeshot.Control;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Controls;

public class F_ControlUICoordinate : Form
{
  public string Path;
  public string FileName;
  public bool KeepRatio;
  public bool MoveEntities;
  public bool MoveReverse;
  public MinMaxType MoveRef;
  public Design viewport;
  public List<string> ExtensionList;
  private List<string> \u0001;
  private int \u0001;
  private int \u0002;
  private string \u0001;
  private bool \u0001;
  private Point3D \u0001;
  private Point3D \u0002;
  private Point3D \u0003;
  internal List<string> \u0002;

  public void Init()
  {
    ((F_DiamakerGrindVShape) this).PropertiesForm.Inited = false;
    if (((F_DiamakerGrindVShape) this).PropertiesForm.Height > 10)
      this.Height = ((F_DiamakerGrindVShape) this).PropertiesForm.Height;
    if (((F_DiamakerGrindVShape) this).PropertiesForm.Width > 10)
      this.Width = ((F_DiamakerGrindVShape) this).PropertiesForm.Width;
    this.TopMost = ((F_DiamakerGrindVShape) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_DiamakerGrindVShape) this).PropertiesForm.FormPosition;
    this.ControlUpdate();
    this.LoadLanguage();
    if (((F_DiamakerGrindVShape) this).SequenceHor == FoamSequenceHor.HorizontalStartThenEnd)
      ((F_DiamakerGrindVShape) this).\u0001.Checked = true;
    else if (((F_DiamakerGrindVShape) this).SequenceHor == FoamSequenceHor.HorizontalStartThenStart)
      ((F_DiamakerGrindVShape) this).\u0002.Checked = true;
    else if (((F_DiamakerGrindVShape) this).SequenceHor == FoamSequenceHor.HorizontalStartThenStartDirect)
      ((F_RectangleShape) this).\u0005.Checked = true;
    if (((F_DiamakerGrindVShape) this).SequenceVer == FoamSequenceVer.VerticalStartThenEnd)
      ((F_RectangleShape) this).\u0004.Checked = true;
    else if (((F_DiamakerGrindVShape) this).SequenceVer == FoamSequenceVer.VerticalStartThenStart)
      ((F_RectangleShape) this).\u0003.Checked = true;
    ((F_DiamakerGrindVShape) this).\u0002.Text = ((DrillCNCSettings) buCall.\u0001).SequenceToExplanation(((F_DiamakerGrindVShape) this).SequenceVer);
    ((F_DiamakerGrindVShape) this).PropertiesForm.Result = DialogResult.None;
    ((F_DiamakerGrindVShape) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (F_DiamakerGrindVShape.Captions.Count >= 9)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  public void ControlUpdate()
  {
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_DiamakerGrindVShape) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_DiamakerGrindVShape) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_DiamakerGrindVShape) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_DiamakerGrindVShape) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
    if (control2.Name == ((F_DiamakerGrindVShape) this).btn_ok.Name)
    {
      this.Apply();
      ((F_DiamakerGrindVShape) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_DiamakerGrindVShape) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_DiamakerGrindVShape) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    else
    {
      if (!(control2.Name == ((F_DiamakerGrindVShape) this).btn_cancel.Name))
        return;
      ((F_DiamakerGrindVShape) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_DiamakerGrindVShape) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_DiamakerGrindVShape) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (((F_DiamakerGrindVShape) this).\u0001.Checked)
    {
      ((F_DiamakerGrindVShape) this).SequenceHor = FoamSequenceHor.HorizontalStartThenEnd;
      ((F_DiamakerGrindVShape) this).\u0001.Text = ((DrillCNCSettings) buCall.\u0001).SequenceToExplanation(((F_DiamakerGrindVShape) this).SequenceHor);
    }
    if (((F_DiamakerGrindVShape) this).\u0002.Checked)
    {
      ((F_DiamakerGrindVShape) this).SequenceHor = FoamSequenceHor.HorizontalStartThenStart;
      ((F_DiamakerGrindVShape) this).\u0001.Text = ((DrillCNCSettings) buCall.\u0001).SequenceToExplanation(((F_DiamakerGrindVShape) this).SequenceHor);
    }
    if (((F_RectangleShape) this).\u0005.Checked)
    {
      ((F_DiamakerGrindVShape) this).SequenceHor = FoamSequenceHor.HorizontalStartThenStartDirect;
      ((F_DiamakerGrindVShape) this).\u0001.Text = ((DrillCNCSettings) buCall.\u0001).SequenceToExplanation(((F_DiamakerGrindVShape) this).SequenceHor);
    }
    if (((F_RectangleShape) this).\u0004.Checked)
    {
      ((F_DiamakerGrindVShape) this).SequenceVer = FoamSequenceVer.VerticalStartThenEnd;
      ((F_DiamakerGrindVShape) this).\u0001.Text = ((DrillCNCSettings) buCall.\u0001).SequenceToExplanation(((F_DiamakerGrindVShape) this).SequenceVer);
    }
    if (!((F_RectangleShape) this).\u0003.Checked)
      return;
    ((F_DiamakerGrindVShape) this).SequenceVer = FoamSequenceVer.VerticalStartThenStart;
    ((F_DiamakerGrindVShape) this).\u0001.Text = ((DrillCNCSettings) buCall.\u0001).SequenceToExplanation(((F_DiamakerGrindVShape) this).SequenceVer);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_DiamakerGrindVShape) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_DiamakerGrindVShape) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_ControlUICoordinate() => F_DiamakerGrindVShape.Captions = new List<string>();

  public F_ControlUICoordinate()
  {
    ((F_RectangleShape) this).PropertiesForm = new FormProperties();
    ((F_RectangleShape) this).Length = 0.0;
    ((F_RectangleShape) this).Angle = 0.0;
    ((F_RectangleShape) this).isLeadIn = true;
    ((F_RectangleShape) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_FoamLeadInOut) this);
  }

  public void Init()
  {
    ((F_RectangleShape) this).PropertiesForm.Inited = false;
    if (((F_RectangleShape) this).PropertiesForm.Height > 10)
      this.Height = ((F_RectangleShape) this).PropertiesForm.Height;
    if (((F_RectangleShape) this).PropertiesForm.Width > 10)
      this.Width = ((F_RectangleShape) this).PropertiesForm.Width;
    this.TopMost = ((F_RectangleShape) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_RectangleShape) this).PropertiesForm.FormPosition;
    ((F_ControlUIGround) this).ControlUpdate();
    ((F_ControlUIGround) this).LoadLanguage();
    if (((F_RectangleShape) this).isLeadIn)
    {
      ((F_RectangleShape) this).\u0007.Visible = false;
      ((F_RectangleShape) this).\u0005.Visible = false;
      ((F_RectangleShape) this).\u0002.Visible = false;
      ((F_RectangleShape) this).\u0004.Visible = false;
      ((F_RectangleShape) this).\u0008.Visible = true;
      ((F_RectangleShape) this).\u0006.Visible = true;
      ((F_RectangleShape) this).\u0001.Visible = true;
      ((F_RectangleShape) this).\u0003.Visible = true;
    }
    else
    {
      ((F_RectangleShape) this).\u0008.Visible = false;
      ((F_RectangleShape) this).\u0006.Visible = false;
      ((F_RectangleShape) this).\u0001.Visible = false;
      ((F_RectangleShape) this).\u0003.Visible = false;
      ((F_RectangleShape) this).\u0007.Visible = true;
      ((F_RectangleShape) this).\u0005.Visible = true;
      ((F_RectangleShape) this).\u0002.Visible = true;
      ((F_RectangleShape) this).\u0004.Visible = true;
    }
    ((F_RectangleShape) this).PropertiesForm.Result = DialogResult.None;
    ((F_RectangleShape) this).PropertiesForm.Inited = true;
  }
}
