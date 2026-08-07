// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Profile.F_ProfileAdd
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buClass.Apps;
using buControls.ColorPicker;
using buControls.Controls;
using buControls.Viewer;
using buCore;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Profile;

public class F_ProfileAdd : Form
{
  public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;
  public DialogResult Result = DialogResult.None;
  public List<eEntities> EntitiesOriginal = new List<eEntities>();
  public List<eEntities> EntitiesTransformed = new List<eEntities>();
  public List<LayerBase> Layers = new List<LayerBase>();
  public List<MaterialSkin> Materials = new List<MaterialSkin>();
  public int MaterialIndex = 0;
  public ProfileItem Profile = new ProfileItem();
  public ProfileSettings ProfileSet = new ProfileSettings();
  public ProfileRuntimeSettings ProfileRunTimeSet = new ProfileRuntimeSettings();
  public double SupportBlockY1Thickness = 0.0;
  public double SupportBlockY2Thickness = 0.0;
  public double SupportBlockZThickness = 0.0;
  public string strDelete = "Do You Want to Delete This File";
  public string pathProfile = Application.StartupPath;
  private int int_0 = -1;
  private int int_1 = -1;
  private bool bool_0 = false;
  internal Pnt3D pnt3D_0 = new Pnt3D();
  internal Pnt3D pnt3D_1 = new Pnt3D();
  internal List<string> list_0 = new List<string>();
  private IContainer icontainer_0 = (IContainer) null;
  internal TextBox textBox_0;
  internal Label label_0;
  internal buGrid buGrid_0;
  internal Panel panel_0;
  internal Label label_1;
  internal buViewer buViewer_0;
  internal Panel panel_1;
  internal Button button_0;
  internal ImageList imageList_0;
  internal Button button_1;
  internal Button button_2;
  internal Panel panel_2;
  internal Label label_2;
  internal buViewer buViewer_1;
  internal Button button_3;
  internal Button button_4;
  internal Button button_5;
  internal Button button_6;
  internal NumericUpDown numericUpDown_0;
  internal Button button_7;
  internal Label label_3;
  internal buColorComboBox buColorComboBox_0;
  internal ComboBox comboBox_0;
  internal Label label_4;
  internal ComboBox comboBox_1;
  internal Label label_5;
  internal TextBox textBox_1;
  internal Label label_6;
  internal TextBox textBox_2;
  internal Label label_7;
  internal Label label_8;
  internal Label label_9;
  internal TextBox textBox_3;
  internal NumericUpDown numericUpDown_1;
  internal Label label_10;
  internal NumericUpDown numericUpDown_2;
  internal Label label_11;
  internal Label label_12;
  internal NumericUpDown numericUpDown_3;
  internal Label label_13;
  internal Button button_8;
  internal Label label_14;
  internal NumericUpDown numericUpDown_4;
  internal Label label_15;
  internal buColorComboBox buColorComboBox_1;
  internal NumericUpDown numericUpDown_5;
  internal NumericUpDown numericUpDown_6;
  internal Label label_16;
  internal NumericUpDown numericUpDown_7;

  public F_ProfileAdd() => Class39.smethod_75(this);

  public void Init()
  {
    this.buGrid_0.AllowUserToAddRows = false;
    this.buGrid_0.AllowUserToDeleteRows = false;
    this.buGrid_0.AllowUserToResizeRows = false;
    this.buGrid_0.RowHeadersVisible = false;
    this.buGrid_0.customColumbs.Clear();
    ColumbProperties columbProperties = new ColumbProperties();
    this.buGrid_0.customColumbs.Add(new ColumbProperties("No", 50, false, System.Type.GetType("System.Int")));
    this.buGrid_0.customColumbs.Add(new ColumbProperties("File Name", 250, false, System.Type.GetType("System.String")));
    this.buGrid_0.Creat();
    this.numericUpDown_1.Value = (Decimal) this.ProfileSet.MaterialTranspancy;
    this.buColorComboBox_0.Color = this.Profile.Color;
    this.buColorComboBox_1.Color = this.ProfileSet.SupportBlockZColor;
    this.bool_0 = false;
    this.comboBox_1.Items.Clear();
    this.comboBox_1.Items.Add((object) 100);
    this.comboBox_1.Items.Add((object) 500);
    this.comboBox_1.Items.Add((object) 800);
    this.comboBox_1.Items.Add((object) 1000);
    this.comboBox_1.Items.Add((object) 1200);
    this.comboBox_1.Items.Add((object) 1500);
    this.comboBox_1.Items.Add((object) 2000);
    this.comboBox_1.Items.Add((object) 3000);
    this.comboBox_1.Items.Add((object) 4000);
    this.comboBox_1.Items.Add((object) 5000);
    this.comboBox_1.Items.Add((object) 6000);
    this.comboBox_1.Text = this.ProfileRunTimeSet.ProfileLength.ToString();
    this.comboBox_0.Items.Clear();
    for (int index = 0; index <= this.Materials.Count - 1; ++index)
      this.comboBox_0.Items.Add((object) this.Materials[index].Name);
    if (this.MaterialIndex >= 0 & this.MaterialIndex <= this.comboBox_0.Items.Count - 1)
      this.comboBox_0.SelectedIndex = this.MaterialIndex;
    this.numericUpDown_2.Value = (Decimal) this.SupportBlockY1Thickness;
    this.numericUpDown_4.Value = (Decimal) this.SupportBlockY2Thickness;
    this.numericUpDown_3.Value = (Decimal) this.SupportBlockZThickness;
    this.numericUpDown_7.Value = (Decimal) this.ProfileRunTimeSet.ProfileMaxClamper;
    this.list_0 = new List<string>();
    List<string> Files1 = new List<string>();
    buFile.GetFilesInDirectory(AppPath.Profiles, ".dxf", ref Files1);
    for (int index = 0; index <= Files1.Count - 1; ++index)
      this.list_0.Add(Files1[index]);
    List<string> Files2 = new List<string>();
    buFile.GetFilesInDirectory(AppPath.Profiles, ".bucad", ref Files2);
    for (int index = 0; index <= Files2.Count - 1; ++index)
      this.list_0.Add(Files2[index]);
    Class39.smethod_235(this);
  }

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.Result = DialogResult.Cancel;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_1(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.button_0.Name)
    {
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
      folderBrowserDialog.SelectedPath = this.pathProfile;
      if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        this.pathProfile = folderBrowserDialog.SelectedPath;
      this.Init();
    }
    if (control2.Name == this.button_8.Name)
    {
      F_NewProfile fNewProfile = new F_NewProfile();
      fNewProfile.txt_name.Text = this.textBox_2.Text;
      fNewProfile.cmb_length.Text = this.comboBox_1.Text;
      fNewProfile.ItemHeight = this.ProfileRunTimeSet.NewProfileHeight;
      fNewProfile.ItemWidth = this.ProfileRunTimeSet.NewProfileWidth;
      fNewProfile.ItemThickness = this.ProfileRunTimeSet.NewProfileThickness;
      fNewProfile.Init();
      fNewProfile.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fNewProfile.ShowDialog();
      if (fNewProfile.Result == DialogResult.OK)
      {
        this.ProfileRunTimeSet.NewProfileHeight = fNewProfile.ItemHeight;
        this.ProfileRunTimeSet.NewProfileWidth = fNewProfile.ItemWidth;
        this.ProfileRunTimeSet.NewProfileThickness = fNewProfile.ItemThickness;
        this.textBox_2.Text = fNewProfile.ItemName;
        if (fNewProfile.ItemLength.Length > 0)
          this.comboBox_1.Text = fNewProfile.ItemLength;
        this.EntitiesTransformed.Clear();
        eEntities.CopyEntities(fNewProfile.PreviewEnts, ref this.EntitiesTransformed);
        this.method_1((object) this.button_1, e);
        return;
      }
    }
    if (control2.Name == this.button_7.Name && this.int_1 >= 0)
    {
      FileInfo fileInfo = new FileInfo($"{AppPath.Profiles}\\{this.buGrid_0.Rows[this.int_1].Cells[1].Value.ToString()}");
      if (fileInfo.Exists && buString.MessageBoxQuestion($"{this.strDelete} : {buFile.getFileName(fileInfo.FullName)}") == DialogResult.Yes)
      {
        fileInfo.Delete();
        Class39.smethod_235(this);
      }
    }
    if (control2.Name == this.button_3.Name)
    {
      Pnt3D MinPoint = new Pnt3D();
      Pnt3D MaxPoint = new Pnt3D();
      Pnt3D MidPoint = new Pnt3D();
      buControlCoreClass.cVector.BoxSizeCalculate(this.EntitiesTransformed, ref MinPoint, ref MidPoint, ref MaxPoint);
      buControlCoreClass.cVector.Rotate(MidPoint, (double) this.numericUpDown_0.Value, ClockDirectionType.CCW, new WorkPlane(), ref this.EntitiesTransformed);
      buControlCoreClass.cVector.BoxSizeCalculate(this.EntitiesTransformed, ref MinPoint, ref MidPoint, ref MaxPoint);
      this.numericUpDown_5.Value = (Decimal) (MaxPoint.X - MinPoint.X);
      this.numericUpDown_6.Value = (Decimal) (MaxPoint.Y - MinPoint.Y);
      this.buViewer_1.AddEntities(this.EntitiesTransformed);
      this.buViewer_1.DrawEntities();
      this.buViewer_1.ZoomFit();
      this.buViewer_1.ZoomOut();
    }
    if (control2.Name == this.button_4.Name)
    {
      Pnt3D MinPoint = new Pnt3D();
      Pnt3D MaxPoint = new Pnt3D();
      Pnt3D MidPoint = new Pnt3D();
      buControlCoreClass.cVector.BoxSizeCalculate(this.EntitiesTransformed, ref MinPoint, ref MidPoint, ref MaxPoint);
      buControlCoreClass.cVector.Rotate(MidPoint, (double) this.numericUpDown_0.Value * -1.0, ClockDirectionType.CCW, new WorkPlane(), ref this.EntitiesTransformed);
      buControlCoreClass.cVector.BoxSizeCalculate(this.EntitiesTransformed, ref MinPoint, ref MidPoint, ref MaxPoint);
      this.numericUpDown_5.Value = (Decimal) (MaxPoint.X - MinPoint.X);
      this.numericUpDown_6.Value = (Decimal) (MaxPoint.Y - MinPoint.Y);
      this.buViewer_1.AddEntities(this.EntitiesTransformed);
      this.buViewer_1.DrawEntities();
      this.buViewer_1.ZoomFit();
      this.buViewer_1.ZoomOut();
    }
    if (control2.Name == this.button_5.Name)
    {
      Pnt3D MinPoint = new Pnt3D();
      Pnt3D MaxPoint = new Pnt3D();
      Pnt3D MidPoint = new Pnt3D();
      buControlCoreClass.cVector.BoxSizeCalculate(this.EntitiesTransformed, ref MinPoint, ref MidPoint, ref MaxPoint);
      buControlCoreClass.cVector.Mirror(MidPoint, new Pnt3D(MidPoint.X, MidPoint.Y + 10.0), new WorkPlane(), 0.0, ref this.EntitiesTransformed);
      buControlCoreClass.cVector.BoxSizeCalculate(this.EntitiesTransformed, ref MinPoint, ref MidPoint, ref MaxPoint);
      this.numericUpDown_5.Value = (Decimal) (MaxPoint.X - MinPoint.X);
      this.numericUpDown_6.Value = (Decimal) (MaxPoint.Y - MinPoint.Y);
      this.buViewer_1.AddEntities(this.EntitiesTransformed);
      this.buViewer_1.DrawEntities();
      this.buViewer_1.ZoomFit();
      this.buViewer_1.ZoomOut();
    }
    if (control2.Name == this.button_6.Name)
    {
      Pnt3D MinPoint = new Pnt3D();
      Pnt3D MaxPoint = new Pnt3D();
      Pnt3D MidPoint = new Pnt3D();
      buControlCoreClass.cVector.BoxSizeCalculate(this.EntitiesTransformed, ref MinPoint, ref MidPoint, ref MaxPoint);
      buControlCoreClass.cVector.Mirror(MidPoint, new Pnt3D(MidPoint.X + 10.0, MidPoint.Y), new WorkPlane(), 0.0, ref this.EntitiesTransformed);
      buControlCoreClass.cVector.BoxSizeCalculate(this.EntitiesTransformed, ref MinPoint, ref MidPoint, ref MaxPoint);
      this.numericUpDown_5.Value = (Decimal) (MaxPoint.X - MinPoint.X);
      this.numericUpDown_6.Value = (Decimal) (MaxPoint.Y - MinPoint.Y);
      this.buViewer_1.AddEntities(this.EntitiesTransformed);
      this.buViewer_1.DrawEntities();
      this.buViewer_1.ZoomFit();
      this.buViewer_1.ZoomOut();
    }
    if (control2.Name == this.button_2.Name)
    {
      this.Result = DialogResult.Cancel;
      if (this.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == this.button_1.Name))
      return;
    this.Profile = new ProfileItem();
    this.ProfileSet.MaterialTranspancy = (int) this.numericUpDown_1.Value;
    this.ProfileSet.SupportBlockZColor = this.buColorComboBox_1.Color;
    this.Profile.ItemName = this.textBox_2.Text;
    double result = 0.0;
    double.TryParse(this.comboBox_1.Text, out result);
    this.ProfileRunTimeSet.ProfileLength = result;
    this.ProfileRunTimeSet.ProfileMaxClamper = (int) this.numericUpDown_7.Value;
    this.SupportBlockY1Thickness = (double) this.numericUpDown_2.Value;
    this.SupportBlockY2Thickness = (double) this.numericUpDown_4.Value;
    this.SupportBlockZThickness = (double) this.numericUpDown_3.Value;
    if (this.SupportBlockY1Thickness < 0.0)
      this.SupportBlockY1Thickness = 0.0;
    if (this.SupportBlockY2Thickness < 0.0)
      this.SupportBlockY2Thickness = 0.0;
    if (this.SupportBlockZThickness < 0.0)
      this.SupportBlockZThickness = 0.0;
    this.Profile.Length = result;
    this.Profile.Skin = new MaterialSkin(this.Materials[this.comboBox_0.SelectedIndex]);
    this.Profile.Color = this.buColorComboBox_0.Color;
    this.Profile.Transparency = (int) this.numericUpDown_1.Value;
    List<eEntities> eEntitiesList = new List<eEntities>();
    List<Pnt3D> pnt3DList = new List<Pnt3D>();
    Pnt3D MinPoint1 = new Pnt3D();
    Pnt3D MaxPoint1 = new Pnt3D();
    buControlCoreClass.cVector.BoxSizeCalculate(this.EntitiesTransformed, ref MinPoint1, ref MaxPoint1);
    this.Profile.Width = Math.Round(MaxPoint1.X - MinPoint1.X, 3);
    this.Profile.Height = Math.Round(MaxPoint1.Y - MinPoint1.Y, 3);
    double RatioX = (double) this.numericUpDown_5.Value / this.Profile.Width;
    double RatioY = (double) this.numericUpDown_6.Value / this.Profile.Height;
    if (!buCompare.EQ(RatioX, 1.0, 0.001) | !buCompare.EQ(RatioY, 1.0, 0.001))
      buControlCoreClass.cVector.Scale(MinPoint1, RatioX, RatioY, 1.0, true, true, false, new WorkPlane(), ref this.EntitiesTransformed);
    buControlCoreClass.cSort.FindOutsideEntitiesFromAllEntities(new Pnt3D(), this.EntitiesTransformed, new WorkPlane(), ref this.Profile.OutterEntitites, ref this.Profile.OutterPoints);
    if (this.SupportBlockZThickness > 0.0)
    {
      this.Profile.SupportBlockZLength = result;
      this.Profile.SupportBlockZWidth = this.Profile.Width;
      this.Profile.SupportBlockZHeight = this.SupportBlockZThickness;
    }
    if (this.SupportBlockY1Thickness > 0.0)
    {
      this.Profile.SupportBlockY1Length = result;
      this.Profile.SupportBlockY1Width = this.SupportBlockY1Thickness;
      this.Profile.SupportBlockY1Height = this.Profile.Height;
    }
    if (this.SupportBlockY2Thickness > 0.0)
    {
      this.Profile.SupportBlockY2Length = result;
      this.Profile.SupportBlockY2Width = this.SupportBlockY2Thickness;
      this.Profile.SupportBlockY2Height = this.Profile.Height;
    }
    List<List<eEntities>> eEntitiesListList = new List<List<eEntities>>();
    List<List<eEntities>> NotClosedEntities = new List<List<eEntities>>();
    buControlCoreClass.cSort.FindInternalEntitiesAtClosedContour(this.Profile.OutterPoints, this.EntitiesTransformed, new WorkPlane(), ref this.Profile.InnerEntities, ref NotClosedEntities);
    for (int index = 0; index <= this.Profile.InnerEntities.Count - 1; ++index)
    {
      List<Pnt3D> Points = new List<Pnt3D>();
      buControlCoreClass.cVector.EntityToPoint(this.Profile.InnerEntities[index], buSystem.EntitiesResolution, ref Points);
      this.Profile.InnerPoints.Add(Points);
    }
    this.Result = DialogResult.OK;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_2(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    double num1 = this.pnt3D_1.X - this.pnt3D_0.X;
    double num2 = this.pnt3D_1.Y - this.pnt3D_0.Y;
    double RatioX = (double) this.numericUpDown_5.Value / num1;
    double RatioY = (double) this.numericUpDown_6.Value / num2;
    List<eEntities> CalcEntities = new List<eEntities>();
    if (control2.Name == this.numericUpDown_5.Name)
    {
      buControlCoreClass.cVector.Scale(new Pnt3D(), RatioX, RatioY, 1.0, true, true, false, new WorkPlane(), this.EntitiesOriginal, ref CalcEntities);
      this.buViewer_1.Entities.Clear();
      this.buViewer_1.AddEntities(CalcEntities);
      this.buViewer_1.DrawEntities();
      this.buViewer_1.ZoomFit();
      this.buViewer_1.ZoomOut();
    }
    if (!(control2.Name == this.numericUpDown_6.Name))
      return;
    buControlCoreClass.cVector.Scale(new Pnt3D(), RatioX, RatioY, 1.0, true, true, false, new WorkPlane(), this.EntitiesOriginal, ref CalcEntities);
    this.buViewer_1.Entities.Clear();
    this.buViewer_1.AddEntities(CalcEntities);
    this.buViewer_1.DrawEntities();
    this.buViewer_1.ZoomFit();
    this.buViewer_1.ZoomOut();
  }

  internal void method_3(object sender, EventArgs e)
  {
    try
    {
      int Val1 = 1;
      this.bool_0 = true;
      if (this.textBox_0.Text.Length == 0)
      {
        Class39.smethod_235(this);
      }
      else
      {
        this.buGrid_0.Dt.Clear();
        for (int index = 0; index <= this.list_0.Count - 1; ++index)
        {
          string fileName = buFile.getFileName(this.list_0[index]);
          if (fileName.ToLower().IndexOf(this.textBox_0.Text.ToLower()) >= 0)
          {
            this.buGrid_0.AddNewRow((object) Val1, (object) fileName);
            ++Val1;
          }
        }
      }
      this.bool_0 = false;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_4(object sender, DataGridViewCellEventArgs e)
  {
    this.int_0 = e.ColumnIndex;
    this.int_1 = e.RowIndex;
    if (this.int_1 < 0)
      return;
    Class39.smethod_418($"{AppPath.Profiles}\\{this.buGrid_0.Rows[this.int_1].Cells[1].Value.ToString()}", this);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
