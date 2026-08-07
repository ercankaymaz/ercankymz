// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Controls.F_ControlUIDataGridView
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buCore;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.File;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using devDept.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Controls;

public class F_ControlUIDataGridView : Form
{
  internal PictureBox \u0003;
  internal buCheckBox \u0001;
  internal buCheckBox \u0002;
  public buSpin spn_mirrordis;
  internal PictureBox \u0004;
  public buSpin spn_copyy;
  public buSpin spn_copyx;
  internal PictureBox \u0005;
  public buSpin spn_rotate;
  internal PictureBox \u0006;
  public buSpin spn_circulararraycount;
  public buSpin spn_circulararrayangle;
  internal PictureBox \u0007;
  public static byte f0032BE;
  public FormProperties PropertiesForm;
  public MaterialBase5 Material;
  public Design viewportLayout;
  public SizeObject Case1;
  public SizeObject Case2;
  public static List<string> Captions;
  private Timer \u0001;
  internal IContainer \u0001;
  internal ImageList \u0001;

  public void Init()
  {
    ((F_ControlUICheck) this).PropertiesForm.Inited = false;
    if (((F_ControlUICheck) this).PropertiesForm.Height > 10)
      this.Height = ((F_ControlUICheck) this).PropertiesForm.Height;
    if (((F_ControlUICheck) this).PropertiesForm.Width > 10)
      this.Width = ((F_ControlUICheck) this).PropertiesForm.Width;
    this.TopMost = ((F_ControlUICheck) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_ControlUICheck) this).PropertiesForm.FormPosition;
    ((F_ControlUIBasic) this).\u0001.Checked = ((F_ControlUICoordinate) this).KeepRatio;
    if (((F_ControlUICoordinate) this).viewport == null)
    {
      EyeCreateProps Properties = (EyeCreateProps) new ShapeEdit();
      ((DiameterDepthPoint) Properties).ShowToolBar = false;
      ((DiameterDepthPoint) Properties).ShowViewCube = true;
      ((MaterialBase5) Properties).ShowCoordinateArrow = true;
      buConversion5.CreateControlsTool(true, Properties, ref ((F_ControlUICoordinate) this).viewport);
      ((F_ControlUICoordinate) this).viewport.Dock = DockStyle.Fill;
      ((F_ControlUIBasic) this).\u0003.Controls.Add((System.Windows.Forms.Control) ((F_ControlUICoordinate) this).viewport);
    }
    ((F_ControlUIBasic) this).grid_files.AllowUserToAddRows = false;
    ((F_ControlUIBasic) this).grid_files.AllowUserToDeleteRows = false;
    ((F_ControlUIBasic) this).grid_files.AllowUserToResizeRows = false;
    ((F_ControlUIBasic) this).grid_files.RowHeadersVisible = false;
    ((F_ControlUIBasic) this).grid_files.Columns.Clear();
    ((F_ControlUIBasic) this).grid_files.Rows.Clear();
    ((F_ControlUIBasic) this).grid_files.Columns.Clear();
    DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
    dataGridViewColumn1.Width = 60;
    dataGridViewColumn1.HeaderText = "No";
    dataGridViewColumn1.Name = "No";
    dataGridViewColumn1.ReadOnly = true;
    dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
    dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
    ((F_ControlUIBasic) this).grid_files.Columns.Add(dataGridViewColumn1);
    DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
    dataGridViewColumn2.Width = 250;
    dataGridViewColumn2.HeaderText = "FileName";
    dataGridViewColumn2.Name = "FileName";
    dataGridViewColumn2.ReadOnly = true;
    dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
    dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
    ((F_ControlUIBasic) this).grid_files.Columns.Add(dataGridViewColumn2);
    ((F_ControlUICoordinate) this).\u0001 = false;
    if (((F_ControlUICoordinate) this).ExtensionList.Count == 0)
    {
      ((F_ControlUICoordinate) this).ExtensionList.Add(".dxf");
      ((F_ControlUICoordinate) this).ExtensionList.Add(".bucadv5");
    }
    ((F_ControlUICoordinate) this).\u0002 = new List<string>();
    for (int index1 = 0; index1 <= ((F_ControlUICoordinate) this).ExtensionList.Count - 1; ++index1)
    {
      List<string> Files = new List<string>();
      buFile.GetFilesInDirectory(((F_ControlUICoordinate) this).Path, ((F_ControlUICoordinate) this).ExtensionList[index1], ref Files);
      for (int index2 = 0; index2 <= Files.Count - 1; ++index2)
        ((F_ControlUICoordinate) this).\u0002.Add(Files[index2]);
    }
    this.LoadLanguage();
    \u0007.\u0001.\u0001((F_AddFromFile) this);
    if (((F_ControlUIGround) this).\u0001 == null)
    {
      ((F_ControlUIGround) this).\u0001 = new Timer();
      ((F_ControlUIGround) this).\u0001.Tick += new EventHandler(this.Init_Tick);
      ((F_ControlUIGround) this).\u0001.Interval = 100;
    }
    ((F_ControlUIGround) this).\u0001.Enabled = true;
    ((F_ControlUICheck) this).PropertiesForm.Result = DialogResult.None;
    ((F_ControlUICheck) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    this.Text = $"{buLangTranslate.preDef.File} {buLangTranslate.preDef.Add}";
    ((F_ControlUIGround) this).\u0002.Text = buLangTranslate.preDef.Files;
    ((F_ControlUIBasic) this).\u0004.Text = buLangTranslate.preDef.Height;
    ((F_ControlUIGround) this).\u0001.Text = buLangTranslate.preDef.Search;
    ((F_ControlUIGround) this).\u0003.Text = buLangTranslate.preDef.Width;
    ((F_ControlUIBasic) this).\u000F.Text = buLangTranslate.preDef.Save;
    ((F_ControlUIGround) this).\u0003.Text = buLangTranslate.preDef.Cancel;
    ((F_ControlUIGround) this).\u0001.Text = buLangTranslate.preDef.Folder;
    ((F_ControlUIGround) this).\u0002.Text = buLangTranslate.preDef.Ok;
    ((F_ControlUIBasic) this).\u000E.Text = $"{buLangTranslate.preDef.Other} {buLangTranslate.preDef.Files}";
    ((F_ControlUIGround) this).\u0008.Text = buLangTranslate.preDef.Delete;
    ((F_ControlUIBasic) this).\u0001.Text = buLangTranslate.preDef.KeepRatio;
  }

  public void Init_Tick(object sender, EventArgs e)
  {
    ((F_ControlUIGround) this).\u0001.Enabled = false;
    if (((F_ControlUICoordinate) this).\u0002.Count <= 0)
      return;
    ((F_ControlUIBasic) this).grid_files.CurrentCell = ((F_ControlUIBasic) this).grid_files.Rows[0].Cells[0];
    ((F_ControlUIGroup) this).\u0001((object) null, new DataGridViewCellEventArgs(0, 0));
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_ControlUICheck) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_ControlUICheck) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_ControlUICheck) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ControlUICheck) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
    if (control2.Name == ((F_ControlUIGround) this).\u0001.Name)
    {
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
      folderBrowserDialog.SelectedPath = ((F_ControlUICoordinate) this).Path;
      if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        ((F_ControlUICoordinate) this).Path = folderBrowserDialog.SelectedPath;
      this.Init();
    }
    if (control2.Name == ((F_ControlUIBasic) this).\u000E.Name)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "All Files |";
      for (int index = 0; index <= ((F_ControlUICoordinate) this).ExtensionList.Count - 1; ++index)
      {
        if (index < ((F_ControlUICoordinate) this).ExtensionList.Count - 1)
          openFileDialog.Filter = $"{openFileDialog.Filter}*{((F_ControlUICoordinate) this).ExtensionList[index]};";
      }
      openFileDialog.InitialDirectory = ((F_ControlUICoordinate) this).Path;
      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
        this.\u0001(openFileDialog.FileName);
        ((F_ControlUICoordinate) this).\u0001 = buFile5.bunesting.getFileNameWithoutExtension(openFileDialog.FileName);
        ((F_ControlUICoordinate) this).Path = buFile5.bunesting.GetPath(openFileDialog.FileName);
        ((F_ControlUICoordinate) this).\u0001.Clear();
        ((F_ControlUICoordinate) this).\u0001 = new List<string>();
        ((F_ControlUICoordinate) this).viewport.Invalidate();
      }
    }
    if (control2.Name == ((F_ControlUIGround) this).\u0008.Name && ((F_ControlUICoordinate) this).\u0002 >= 0)
    {
      FileInfo fileInfo = new FileInfo($"{((F_ControlUICoordinate) this).Path}\\{((F_ControlUIBasic) this).grid_files.Rows[((F_ControlUICoordinate) this).\u0002].Cells[1].Value.ToString()}");
      if (fileInfo.Exists)
      {
        string fileName = buFile.getFileName(fileInfo.FullName);
        if (buString.MessageBoxQuestion($"{AppLanguage.CadCamMessages[107]} : {fileName}") == DialogResult.Yes)
        {
          fileInfo.Delete();
          \u0007.\u0001.\u0001((F_AddFromFile) this);
        }
      }
    }
    if (control2.Name == ((F_ControlUIGround) this).\u0004.Name)
    {
      Point3D MinPoint = new Point3D();
      Point3D MaxPoint = new Point3D();
      Point3D MidPoint = new Point3D();
      if (((F_ControlUIBasic) this).\u0001.Checked)
        ((F_ControlUICoordinate) this).viewport.Entities.Rotate(buString5.DegreeToRadian((double) ((F_ControlUIGround) this).\u0001.Value), new Vector3D(1.0, 0.0, 0.0));
      else if (((F_ControlUIBasic) this).\u0002.Checked)
        ((F_ControlUICoordinate) this).viewport.Entities.Rotate(buString5.DegreeToRadian((double) ((F_ControlUIGround) this).\u0001.Value), new Vector3D(0.0, 1.0, 0.0));
      else
        ((F_ControlUICoordinate) this).viewport.Entities.Rotate(buString5.DegreeToRadian((double) ((F_ControlUIGround) this).\u0001.Value), new Vector3D(0.0, 0.0, 1.0));
      ((F_ControlUICoordinate) this).viewport.Entities.RegenAllCurved();
      buCall.\u0001.BoxSizeCalculate(((F_ControlUICoordinate) this).viewport.Entities, ref MinPoint, ref MidPoint, ref MaxPoint);
      ((F_ControlUICoordinate) this).viewport.Entities.Translate(-MaxPoint.X, -MinPoint.Y, -MinPoint.Z);
      ((F_ControlUICoordinate) this).viewport.Entities.RegenAllCurved();
      ((F_ControlUICoordinate) this).viewport.ZoomFit();
      ((F_ControlUICoordinate) this).viewport.Invalidate();
      ((F_ControlUICheck) this).PropertiesForm.Inited = false;
      ((F_ControlUIBasic) this).\u0002.Value = (Decimal) (MaxPoint.X - MinPoint.X);
      ((F_ControlUIBasic) this).\u0003.Value = (Decimal) (MaxPoint.Y - MinPoint.Y);
      ((F_ControlUICoordinate) this).\u0001.Add("RotateLeft");
      ((F_ControlUICheck) this).PropertiesForm.Inited = true;
    }
    if (control2.Name == ((F_ControlUIGround) this).\u0005.Name)
    {
      Point3D MinPoint = new Point3D();
      Point3D MaxPoint = new Point3D();
      Point3D MidPoint = new Point3D();
      if (((F_ControlUIBasic) this).\u0001.Checked)
        ((F_ControlUICoordinate) this).viewport.Entities.Rotate(buString5.DegreeToRadian((double) ((F_ControlUIGround) this).\u0001.Value), new Vector3D(1.0, 0.0, 0.0));
      else if (((F_ControlUIBasic) this).\u0002.Checked)
        ((F_ControlUICoordinate) this).viewport.Entities.Rotate(buString5.DegreeToRadian((double) ((F_ControlUIGround) this).\u0001.Value), new Vector3D(0.0, 1.0, 0.0));
      else
        ((F_ControlUICoordinate) this).viewport.Entities.Rotate(buString5.DegreeToRadian(-(double) ((F_ControlUIGround) this).\u0001.Value), new Vector3D(0.0, 0.0, 1.0));
      ((F_ControlUICoordinate) this).viewport.Entities.RegenAllCurved();
      buCall.\u0001.BoxSizeCalculate(((F_ControlUICoordinate) this).viewport.Entities, ref MinPoint, ref MidPoint, ref MaxPoint);
      ((F_ControlUICoordinate) this).viewport.Entities.Translate(-MaxPoint.X, -MinPoint.Y, -MinPoint.Z);
      ((F_ControlUICoordinate) this).viewport.Entities.RegenAllCurved();
      ((F_ControlUICoordinate) this).viewport.ZoomFit();
      ((F_ControlUICoordinate) this).viewport.Invalidate();
      ((F_ControlUICheck) this).PropertiesForm.Inited = false;
      ((F_ControlUIBasic) this).\u0002.Value = (Decimal) (MaxPoint.X - MinPoint.X);
      ((F_ControlUIBasic) this).\u0003.Value = (Decimal) (MaxPoint.Y - MinPoint.Y);
      ((F_ControlUICoordinate) this).\u0001.Add("RotateRight");
      ((F_ControlUICheck) this).PropertiesForm.Inited = true;
    }
    if (control2.Name == ((F_ControlUIGround) this).\u0006.Name)
    {
      Point3D MinPoint = new Point3D();
      Point3D MaxPoint = new Point3D();
      Point3D MidPoint = new Point3D();
      for (int index = 0; index <= ((F_ControlUICoordinate) this).viewport.Entities.Count - 1; ++index)
      {
        Mirror xform = new Mirror(new Plane(new Point3D(), new Vector3D(new Point3D(), new Point3D(0.0, 10.0, 0.0)), Plane.XY.AxisZ));
        ((F_ControlUICoordinate) this).viewport.Entities[index].TransformBy((Transformation) xform);
      }
      ((F_ControlUICoordinate) this).viewport.Entities.RegenAllCurved();
      buCall.\u0001.BoxSizeCalculate(((F_ControlUICoordinate) this).viewport.Entities, ref MinPoint, ref MidPoint, ref MaxPoint);
      ((F_ControlUICoordinate) this).viewport.Entities.Translate(-MaxPoint.X, -MinPoint.Y, -MinPoint.Z);
      ((F_ControlUICoordinate) this).viewport.Entities.RegenAllCurved();
      ((F_ControlUICoordinate) this).viewport.ZoomFit();
      ((F_ControlUICoordinate) this).viewport.Invalidate();
      ((F_ControlUICheck) this).PropertiesForm.Inited = false;
      ((F_ControlUIBasic) this).\u0002.Value = (Decimal) (MaxPoint.X - MinPoint.X);
      ((F_ControlUIBasic) this).\u0003.Value = (Decimal) (MaxPoint.Y - MinPoint.Y);
      ((F_ControlUICoordinate) this).\u0001.Add("MirrorHorizontal");
      ((F_ControlUICheck) this).PropertiesForm.Inited = true;
    }
    if (control2.Name == ((F_ControlUIGround) this).\u0007.Name)
    {
      Point3D MinPoint = new Point3D();
      Point3D MaxPoint = new Point3D();
      Point3D MidPoint = new Point3D();
      for (int index = 0; index <= ((F_ControlUICoordinate) this).viewport.Entities.Count - 1; ++index)
      {
        Mirror xform = new Mirror(new Plane(new Point3D(), new Vector3D(new Point3D(), new Point3D(10.0, 0.0, 0.0)), Plane.XY.AxisZ));
        ((F_ControlUICoordinate) this).viewport.Entities[index].TransformBy((Transformation) xform);
      }
      ((F_ControlUICoordinate) this).viewport.Entities.RegenAllCurved();
      buCall.\u0001.BoxSizeCalculate(((F_ControlUICoordinate) this).viewport.Entities, ref MinPoint, ref MidPoint, ref MaxPoint);
      ((F_ControlUICoordinate) this).viewport.Entities.Translate(-MaxPoint.X, -MinPoint.Y, -MinPoint.Z);
      ((F_ControlUICoordinate) this).viewport.Entities.RegenAllCurved();
      ((F_ControlUICoordinate) this).viewport.ZoomFit();
      ((F_ControlUICoordinate) this).viewport.Invalidate();
      ((F_ControlUICheck) this).PropertiesForm.Inited = false;
      ((F_ControlUIBasic) this).\u0002.Value = (Decimal) (MaxPoint.X - MinPoint.X);
      ((F_ControlUIBasic) this).\u0003.Value = (Decimal) (MaxPoint.Y - MinPoint.Y);
      ((F_ControlUICoordinate) this).\u0001.Add("MirrorVertical");
      ((F_ControlUICheck) this).PropertiesForm.Inited = true;
    }
    if (control2.Name == ((F_ControlUIBasic) this).\u000F.Name)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Filter = "All Files |";
      for (int index = 0; index <= ((F_ControlUICoordinate) this).ExtensionList.Count - 1; ++index)
      {
        if (index < ((F_ControlUICoordinate) this).ExtensionList.Count - 1)
          saveFileDialog.Filter = $"{saveFileDialog.Filter}*{((F_ControlUICoordinate) this).ExtensionList[index]};";
      }
      saveFileDialog.InitialDirectory = ((F_ControlUICoordinate) this).Path;
      if (saveFileDialog.ShowDialog() == DialogResult.OK)
      {
        \u0007.\u0001.\u0001((F_AddFromFile) this, saveFileDialog.FileName);
        ((F_ControlUICoordinate) this).\u0001 = buFile5.bunesting.getFileNameWithoutExtension(saveFileDialog.FileName);
        ((F_ControlUICoordinate) this).Path = buFile5.bunesting.GetPath(saveFileDialog.FileName);
        this.Init();
      }
    }
    if (control2.Name == ((F_ControlUIGround) this).\u0003.Name)
    {
      ((F_ControlUICheck) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_ControlUICheck) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_ControlUICheck) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_ControlUIGround) this).\u0002.Name))
      return;
    ((F_ControlUICheck) this).PropertiesForm.Result = DialogResult.OK;
    if (((F_ControlUICheck) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ControlUICheck) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  private void \u0001([In] string obj0)
  {
    try
    {
      ((F_ControlUICoordinate) this).FileName = obj0;
      if (((F_ControlUICheck) this).\u0001 != null)
        ((F_ControlUICheck) this).\u0001((object) obj0, (object) null);
      FileInfo fileInfo1 = new FileInfo(obj0);
      if (fileInfo1.Extension.ToLower() == ".dxf")
        cParameter5.OpenDxfDwg(ref ((F_ControlUICoordinate) this).viewport, obj0);
      if (fileInfo1.Extension.ToLower() == ".dwg")
        cParameter5.OpenDxfDwg(ref ((F_ControlUICoordinate) this).viewport, obj0);
      else if (fileInfo1.Extension.ToLower() == ".stl")
        buVector5.OpenStl(ref ((F_ControlUICoordinate) this).viewport, obj0);
      else if (fileInfo1.Extension.ToLower() == ".step" | fileInfo1.Extension.ToLower() == ".stp")
        buVector5.OpenStep(ref ((F_ControlUICoordinate) this).viewport, obj0);
      else if (fileInfo1.Extension.ToLower() == ".iges" | fileInfo1.Extension.ToLower() == ".igs")
        buVector5.OpenIges(ref ((F_ControlUICoordinate) this).viewport, obj0);
      else if (fileInfo1.Extension.ToLower() == ".obj")
        buVector5.OpenObj(ref ((F_ControlUICoordinate) this).viewport, obj0);
      else if (fileInfo1.Extension == ".bucadv5")
      {
        DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.Base + "\\T");
        if (directoryInfo.Exists)
          directoryInfo.Delete(true);
        buFile.ExtractToFolder(AppPath.Base + "\\T", ((F_ControlUICoordinate) this).FileName);
        List<string> Files = new List<string>();
        buFile.getFiles(AppPath.Base + "\\T", ref Files);
        Files.Reverse();
        foreach (string fileName in Files)
        {
          FileInfo fileInfo2 = new FileInfo(fileName);
          if (fileInfo2.Extension == ".bupage" & fileInfo1.Exists)
          {
            ReadFile readFile = new ReadFile(fileInfo2.FullName, (FileSerializer) new Router3AXCAM(contentType.GeometryAndTessellation));
            readFile.DoWork();
            RegenOptions ro = new RegenOptions();
            if (((F_ControlUICoordinate) this).viewport != null)
            {
              if (((F_ControlUICoordinate) this).viewport.Entities != null)
                ((F_ControlUICoordinate) this).viewport.Entities.Clear();
              readFile.OpenTo((IDesign) ((F_ControlUICoordinate) this).viewport, ro);
            }
          }
        }
      }
      ((F_ControlUICoordinate) this).viewport.Layers[0].Color = Color.Gold;
      if (((F_ControlUICoordinate) this).viewport.Entities.Count > 0)
      {
        for (int index = 0; index <= ((F_ControlUICoordinate) this).viewport.Entities.Count - 1; ++index)
        {
          ((F_ControlUICoordinate) this).viewport.Entities[index].LineWeight = 2f;
          ((F_ControlUICoordinate) this).viewport.Entities[index].LineWeightMethod = colorMethodType.byEntity;
          ((F_ControlUICoordinate) this).viewport.Entities[index].Color = Color.Orange;
          if (((F_ControlUICoordinate) this).viewport.Entities[index] is ICurve)
            ((F_ControlUICoordinate) this).viewport.Entities[index].Color = Color.Black;
          ((F_ControlUICoordinate) this).viewport.Entities[index].ColorMethod = colorMethodType.byEntity;
          if (((F_ControlUICoordinate) this).viewport.Entities[index] is ICurve)
            ;
        }
        Point3D MinPoint = new Point3D();
        Point3D MidPoint = new Point3D();
        Point3D MaxPoint = new Point3D();
        buCall.\u0001.BoxSizeCalculate(((F_ControlUICoordinate) this).viewport.Entities, ref MinPoint, ref MidPoint, ref MaxPoint);
        if (((F_ControlUICoordinate) this).MoveEntities)
        {
          if (((F_ControlUICoordinate) this).MoveRef == MinMaxType.Max)
          {
            if (((F_ControlUICoordinate) this).MoveReverse)
              ((F_ControlUICoordinate) this).viewport.Entities.Translate(-MaxPoint.X, -MinPoint.Y, -MinPoint.Z);
            else
              ((F_ControlUICoordinate) this).viewport.Entities.Translate(MaxPoint.X, MinPoint.Y, MinPoint.Z);
          }
          else if (((F_ControlUICoordinate) this).MoveReverse)
            ((F_ControlUICoordinate) this).viewport.Entities.Translate(MinPoint.X, MinPoint.Y, MinPoint.Z);
          else
            ((F_ControlUICoordinate) this).viewport.Entities.Translate(-MinPoint.X, -MinPoint.Y, -MinPoint.Z);
          ((F_ControlUICoordinate) this).viewport.Entities.RegenAllCurved();
          ((F_ControlUICoordinate) this).viewport.Entities.Regen();
        }
      }
      ((F_ControlUICoordinate) this).viewport.SetView(viewType.Top);
      ((F_ControlUICoordinate) this).viewport.ZoomFit(10);
      ((F_ControlUICoordinate) this).viewport.Invalidate();
      buCall.\u0001.BoxSizeCalculate(((F_ControlUICoordinate) this).viewport.Entities, ref ((F_ControlUICoordinate) this).\u0001, ref ((F_ControlUICoordinate) this).\u0002, ref ((F_ControlUICoordinate) this).\u0003);
      ((F_ControlUIBasic) this).\u0002.Text = buFile.getFileName(obj0);
      ((F_ControlUICheck) this).PropertiesForm.Inited = false;
      ((F_ControlUIBasic) this).\u0002.Value = (Decimal) (((F_ControlUICoordinate) this).\u0003.X - ((F_ControlUICoordinate) this).\u0001.X);
      ((F_ControlUIBasic) this).\u0003.Value = (Decimal) (((F_ControlUICoordinate) this).\u0003.Y - ((F_ControlUICoordinate) this).\u0001.Y);
      ((F_ControlUICheck) this).PropertiesForm.Inited = true;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_ControlUICheck) this).PropertiesForm.Inited)
      return;
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
    double sx = (double) ((F_ControlUIBasic) this).\u0002.Value / (((F_ControlUICoordinate) this).viewport.Entities.BoxMax.X - ((F_ControlUICoordinate) this).viewport.Entities.BoxMin.X);
    double sy = (double) ((F_ControlUIBasic) this).\u0003.Value / (((F_ControlUICoordinate) this).viewport.Entities.BoxMax.Y - ((F_ControlUICoordinate) this).viewport.Entities.BoxMin.Y);
    double sz = 1.0;
    List<Entity> entityList1 = new List<Entity>();
    if (control2.Name == ((F_ControlUIBasic) this).\u0002.Name && sx != 0.0 & sy != 0.0)
    {
      if (((F_ControlUICoordinate) this).KeepRatio)
      {
        sy = sx;
        sz = sx;
        ((F_ControlUICheck) this).PropertiesForm.Inited = false;
        ((F_ControlUIBasic) this).\u0003.Value = Math.Round(((F_ControlUIBasic) this).\u0003.Value * (Decimal) sy);
        ((F_ControlUICheck) this).PropertiesForm.Inited = true;
      }
      if (!((F_ControlUICoordinate) this).KeepRatio & sx != sy)
      {
        List<Entity> copiedEnt1 = new List<Entity>();
        List<Entity> devideEntities = new List<Entity>();
        List<Entity> entityList2 = new List<Entity>();
        for (int index = 0; index <= ((F_ControlUICoordinate) this).viewport.Entities.Count - 1; ++index)
        {
          if (((F_ControlUICoordinate) this).viewport.Entities[index].GetType() != typeof (ICurve))
          {
            Entity copiedEnt2 = (Entity) null;
            buVector5.CopyEntities(((F_ControlUICoordinate) this).viewport.Entities[index], ref copiedEnt2);
            entityList2.Add(copiedEnt2);
          }
        }
        buVector5.CopyEntities(((F_ControlUICoordinate) this).viewport.Entities, ref copiedEnt1);
        EntityDevideData Settings = new EntityDevideData();
        Settings.Arc = true;
        Settings.Circle = true;
        Settings.Ellipse = true;
        Settings.ArcLength = 0.1;
        Settings.CircleLength = 0.1;
        Settings.EllipseLength = 0.1;
        Color color = ((F_ControlUICoordinate) this).viewport.Entities[0].Color;
        buCall.\u0001.EntitiesDevideByLengthAsPolyline(copiedEnt1, Settings, ref devideEntities);
        ((F_ControlUICoordinate) this).viewport.Entities.Clear();
        for (int index = 0; index <= devideEntities.Count - 1; ++index)
        {
          devideEntities[index].Color = color;
          devideEntities[index].ColorMethod = colorMethodType.byEntity;
          ((F_ControlUICoordinate) this).viewport.Entities.Add(devideEntities[index]);
        }
        for (int index = 0; index <= entityList2.Count - 1; ++index)
        {
          if (color == Color.Black)
            color = Color.Gold;
          entityList2[index].Color = color;
          entityList2[index].ColorMethod = colorMethodType.byEntity;
          ((F_ControlUICoordinate) this).viewport.Entities.Add(entityList2[index]);
        }
      }
      ((F_ControlUICoordinate) this).viewport.Entities.Scale(sx, sy, sz);
      ((F_ControlUICoordinate) this).viewport.Entities.RegenAllCurved(0.01);
      ((F_ControlUICoordinate) this).viewport.ZoomFit();
      ((F_ControlUICoordinate) this).viewport.Invalidate();
    }
    if (!(control2.Name == ((F_ControlUIBasic) this).\u0003.Name) || !(sx != 0.0 & sy != 0.0))
      return;
    if (((F_ControlUICoordinate) this).KeepRatio)
    {
      sx = sy;
      ((F_ControlUICheck) this).PropertiesForm.Inited = false;
      ((F_ControlUIBasic) this).\u0002.Value = Math.Round(((F_ControlUIBasic) this).\u0002.Value * (Decimal) sx);
      ((F_ControlUICheck) this).PropertiesForm.Inited = true;
    }
    if (!((F_ControlUICoordinate) this).KeepRatio & sx != sy)
    {
      List<Entity> copiedEnt3 = new List<Entity>();
      List<Entity> devideEntities = new List<Entity>();
      List<Entity> entityList3 = new List<Entity>();
      for (int index = 0; index <= ((F_ControlUICoordinate) this).viewport.Entities.Count - 1; ++index)
      {
        if (((F_ControlUICoordinate) this).viewport.Entities[index].GetType() != typeof (ICurve))
        {
          Entity copiedEnt4 = (Entity) null;
          buVector5.CopyEntities(((F_ControlUICoordinate) this).viewport.Entities[index], ref copiedEnt4);
          entityList3.Add(copiedEnt4);
        }
      }
      buVector5.CopyEntities(((F_ControlUICoordinate) this).viewport.Entities, ref copiedEnt3);
      EntityDevideData Settings = new EntityDevideData();
      Settings.Arc = true;
      Settings.Circle = true;
      Settings.Ellipse = true;
      Settings.ArcLength = 0.1;
      Settings.CircleLength = 0.1;
      Settings.EllipseLength = 0.1;
      Color color = ((F_ControlUICoordinate) this).viewport.Entities[0].Color;
      buCall.\u0001.EntitiesDevideByLengthAsPolyline(copiedEnt3, Settings, ref devideEntities);
      ((F_ControlUICoordinate) this).viewport.Entities.Clear();
      for (int index = 0; index <= devideEntities.Count - 1; ++index)
      {
        devideEntities[index].Color = color;
        devideEntities[index].ColorMethod = colorMethodType.byEntity;
        ((F_ControlUICoordinate) this).viewport.Entities.Add(devideEntities[index]);
      }
      for (int index = 0; index <= entityList3.Count - 1; ++index)
      {
        if (color == Color.Black)
          color = Color.Gold;
        entityList3[index].Color = color;
        entityList3[index].ColorMethod = colorMethodType.byEntity;
        ((F_ControlUICoordinate) this).viewport.Entities.Add(entityList3[index]);
      }
    }
    ((F_ControlUICoordinate) this).viewport.Entities.Scale(sx, sy);
    ((F_ControlUICoordinate) this).viewport.Entities.RegenAllCurved(0.01);
    ((F_ControlUICoordinate) this).viewport.ZoomFit();
    ((F_ControlUICoordinate) this).viewport.Invalidate();
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      int num = 1;
      ((F_ControlUICoordinate) this).\u0001 = true;
      if (((F_ControlUIGround) this).\u0001.Text.Length == 0)
      {
        \u0007.\u0001.\u0001((F_AddFromFile) this);
      }
      else
      {
        ((F_ControlUIBasic) this).grid_files.Rows.Clear();
        for (int index = 0; index <= ((F_ControlUICoordinate) this).\u0002.Count - 1; ++index)
        {
          string fileName = buFile.getFileName(((F_ControlUICoordinate) this).\u0002[index]);
          if (fileName.ToLower().IndexOf(((F_ControlUIGround) this).\u0001.Text.ToLower()) >= 0)
          {
            ((F_ControlUIBasic) this).grid_files.Rows.Add((object) num, (object) fileName);
            ++num;
          }
        }
      }
      ((F_ControlUICoordinate) this).\u0001 = false;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_ControlUICheck) this).PropertiesForm.Inited)
      return;
    ((F_ControlUICoordinate) this).KeepRatio = ((F_ControlUIBasic) this).\u0001.Checked;
  }
}
