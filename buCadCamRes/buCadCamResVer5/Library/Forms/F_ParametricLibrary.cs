// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Library.Forms.F_ParametricLibrary
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buClass.UserFiles.buCad;
using buControls.DialogBox;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.buEntities;
using devDept;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Control.Labels;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using ns8;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Library.Forms;

public class F_ParametricLibrary : Form
{
  public static List<string> Captions = new List<string>();
  public FormProperties PropertiesForm = new FormProperties();
  public List<EditorCustomData> OpenCustomData = new List<EditorCustomData>();
  public Design viewport = (Design) null;
  internal int int_0 = -1;
  private int int_1 = -1;
  internal List<string> list_0 = new List<string>();
  public List<buEntity> LibraryEntities = new List<buEntity>();
  private Color color_0 = Color.DarkOrange;
  private Color color_1 = Color.Blue;
  private Color color_2 = Color.Black;
  private Timer timer_0 = new Timer();
  private Timer timer_1 = new Timer();
  public Entity selectedEntity = (Entity) null;
  private bool bool_0 = false;
  public setLibrary varLib = new setLibrary();
  private string string_0 = "Name";
  private string string_1 = "Char";
  private string string_2 = "Value";
  internal IContainer icontainer_0 = (IContainer) null;
  internal Panel panel_0;
  internal Panel panel_1;
  internal Panel panel_2;
  internal System.Windows.Forms.Label label_0;
  internal TextBox textBox_0;
  internal DataGridView dataGridView_0;
  internal System.Windows.Forms.Label label_1;
  internal System.Windows.Forms.Label label_2;
  internal ListBox listBox_0;
  internal Button button_0;
  internal Button button_1;
  internal Button button_2;
  internal ImageList imageList_0;
  internal Button button_3;
  internal Button button_4;
  internal Button button_5;
  internal Button button_6;
  internal Button button_7;
  internal Button button_8;

  public F_ParametricLibrary()
  {
    Class5.smethod_103(this);
    this.timer_1.Interval = 100;
    this.timer_1.Tick += new EventHandler(this.timer_1_Tick);
  }

  internal void method_0(object sender, EventArgs e)
  {
    this.timer_0.Interval = 50;
    this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
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

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    this.LoadLanguage();
    if (this.viewport == null)
    {
      CreateModelProperties Properties = new CreateModelProperties();
      clsInit.appCommand.EyeParameterToCreateModelProperties(clsVar.varPreviewViewport, clsVar.varMouse, ref Properties);
      Properties.BottomColor = Color.WhiteSmoke;
      Properties.TopColor = Color.Gainsboro;
      Properties.CoordinateSystemIconVisible = false;
      Properties.ViewCubeIconVisible = false;
      Properties.OrigineCaptionVisible = false;
      Properties.ToolBorVisible = false;
      Properties.OriginSymbolVisible = false;
      clsInit.cVector5.CreateModelControl(ref this.viewport, clsVar.UnlockKey, Properties);
      this.viewport.MouseMove += new MouseEventHandler(this.viewport_MouseMove);
      this.viewport.MouseDown += new MouseEventHandler(this.viewport_MouseDown);
      this.viewport.MouseDoubleClick += new MouseEventHandler(this.viewport_MouseDoubleClick);
      this.viewport.WorkCompleted += new WorkUnit.WorkCompletedEventHandler(this.Desing_WorkCompleted);
      this.viewport.Layers.Add(new Layer("Gen", Color.Blue));
      this.viewport.Layers.RemoveAt(0);
      this.viewport.Selection.Color = Color.DarkOrange;
      this.panel_0.Controls.Add((System.Windows.Forms.Control) this.viewport);
    }
    this.bool_0 = false;
    Class5.smethod_141(this);
    this.LoadLanguage();
    this.dataGridView_0.RowHeadersVisible = false;
    this.dataGridView_0.ColumnHeadersVisible = false;
    this.dataGridView_0.AllowUserToAddRows = false;
    this.dataGridView_0.AllowUserToResizeColumns = false;
    this.dataGridView_0.AllowUserToResizeRows = false;
    this.dataGridView_0.Columns.Clear();
    this.dataGridView_0.Rows.Clear();
    DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
    dataGridViewColumn1.Width = 180;
    dataGridViewColumn1.HeaderText = this.string_0;
    dataGridViewColumn1.Name = this.string_0;
    dataGridViewColumn1.ReadOnly = true;
    dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
    dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
    this.dataGridView_0.Columns.Add(dataGridViewColumn1);
    DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
    dataGridViewColumn2.Width = this.dataGridView_0.Width - dataGridViewColumn1.Width - 10;
    dataGridViewColumn2.HeaderText = this.string_2;
    dataGridViewColumn2.Name = this.string_2;
    dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
    dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
    dataGridViewColumn2.ReadOnly = false;
    this.dataGridView_0.Columns.Add(dataGridViewColumn2);
    this.selectedEntity = (Entity) null;
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
    this.timer_0.Enabled = true;
  }

  public void LoadLanguage()
  {
    try
    {
      if (F_ParametricLibrary.Captions.Count <= 10)
        return;
      this.Text = F_ParametricLibrary.Captions[0];
      this.label_0.Text = F_ParametricLibrary.Captions[1];
      this.string_0 = F_ParametricLibrary.Captions[8];
      this.string_1 = F_ParametricLibrary.Captions[9];
      this.string_2 = F_ParametricLibrary.Captions[10];
    }
    catch (Exception ex)
    {
    }
  }

  private void timer_0_Tick(object sender, EventArgs e)
  {
    if (this.listBox_0.Items.Count > 0)
      this.method_3((object) null, (EventArgs) null);
    this.timer_0.Enabled = false;
  }

  private void timer_1_Tick(object sender, EventArgs e)
  {
    try
    {
      this.timer_1.Enabled = false;
      this.viewport.SetView(viewType.Top);
      this.viewport.Entities.Regen();
      this.viewport.ZoomFit(10);
      this.viewport.UpdateBoundingBox();
      this.viewport.Invalidate();
    }
    catch (Exception ex)
    {
    }
  }

  public void Desing_WorkCompleted(object sender, WorkCompletedEventArgs e)
  {
    if (e.WorkUnit is ReadFileAsync)
    {
      ReadFileAsync workUnit1 = (ReadFileAsync) e.WorkUnit;
      RegenOptions ro = new RegenOptions();
      ReadFile workUnit2 = e.WorkUnit as ReadFile;
      workUnit1.OpenTo((IDesign) this.viewport, ro);
      this.FileOpened();
    }
    if (!(e.WorkUnit is WriteFileAsyncWithTextStyles))
      return;
    clsInit.appEditor.SaveLibraryToZip();
  }

  public void FileOpened()
  {
    this.selectedEntity = (Entity) null;
    if (this.viewport.Entities.Count > 0)
    {
      if (this.viewport.Entities[0] is SketchEntity)
      {
        SketchEntity entity = this.viewport.Entities[0] as SketchEntity;
        if (this.OpenCustomData.Count > 0)
        {
          for (int index = 0; index <= this.OpenCustomData.Count - 1; ++index)
          {
            if (this.OpenCustomData[index].EntityIndex >= 0 & this.OpenCustomData[index].EntityIndex <= entity.CurveList.Count - 1)
              ((Entity) entity.CurveList[this.OpenCustomData[index].EntityIndex]).EntityData = (object) this.OpenCustomData[index];
          }
        }
        entity.Edit((IDesign) this.viewport);
        this.viewport.CurrentSketch.UpdateAndInvalidate();
      }
      foreach (devDept.Eyeshot.Control.Labels.Label label in (EyeshotCollection<devDept.Eyeshot.Control.Labels.Label>) this.viewport.ActiveViewport.Labels)
      {
        if (label is StackedLabel)
          (label as StackedLabel).Visible = false;
      }
      int index1 = 0;
      this.dataGridView_0.Rows.Clear();
      foreach (Entity entity in (EyeshotCollection<Entity>) this.viewport.Entities)
      {
        if (entity is Dimension)
        {
          double result = 0.0;
          double.TryParse(((devDept.Eyeshot.Entities.Text) entity).TextString, out result);
          this.dataGridView_0.Rows.Add(Class5.smethod_25(result, this, buString5.GetAlfabetLetter(index1)));
          ++index1;
        }
      }
    }
    DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.Base + "\\L");
    if (directoryInfo.Exists)
      directoryInfo.Delete(true);
    this.timer_1.Enabled = true;
  }

  internal void method_2(object sender, EventArgs e)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) sender;
    if (control2.Name == this.button_2.Name)
    {
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
      folderBrowserDialog.SelectedPath = this.varLib.pathLibrary;
      if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
      {
        this.varLib.pathLibrary = folderBrowserDialog.SelectedPath;
        this.Init();
      }
    }
    if (control2.Name == this.button_8.Name)
    {
      SketchEntity currentSketch = this.viewport.CurrentSketch;
      this.viewport.CurrentSketch.Exit();
      this.viewport.Entities.Regen();
      this.viewport.Invalidate();
      clsInit.appEditor.cmdSaveLib(this.viewport);
      if (this.viewport.Entities.Count > 0)
        ;
      foreach (devDept.Eyeshot.Control.Labels.Label label in (EyeshotCollection<devDept.Eyeshot.Control.Labels.Label>) this.viewport.ActiveViewport.Labels)
      {
        if (label is StackedLabel)
          (label as StackedLabel).Visible = false;
      }
    }
    if (control2.Name == this.button_4.Name)
    {
      this.viewport.ZoomFit();
      this.viewport.Invalidate();
    }
    if (control2.Name == this.button_5.Name)
    {
      this.viewport.ZoomIn(10);
      this.viewport.Invalidate();
    }
    if (control2.Name == this.button_6.Name)
    {
      this.viewport.ZoomOut(10);
      this.viewport.Invalidate();
    }
    if (control2.Name == this.button_7.Name)
    {
      this.viewport.SetView(viewType.Top);
      this.viewport.Invalidate();
    }
    if (control2.Name == this.button_1.Name)
    {
      this.PropertiesForm.Result = DialogResult.Cancel;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == this.button_0.Name) || !this.viewport.IsHandleCreated | this.viewport.IsBusy || !this.PropertiesForm.Inited)
      return;
    this.PropertiesForm.Result = DialogResult.OK;
    if (this.viewport.Entities.Count > 0 && this.viewport.Entities[0] is SketchEntity)
    {
      clsLibrary.LibraryEntities = new List<buEntity>();
      SketchEntity entity = this.viewport.Entities[0] as SketchEntity;
      entity.Exit();
      this.LibraryEntities = new List<buEntity>();
      for (int index = 0; index <= entity.CurveList.Count - 1; ++index)
      {
        buEntity buEntity = buEntity.Copy((Entity) entity.CurveList[index]);
        if (((Entity) entity.CurveList[index]).EntityData != null && ((Entity) entity.CurveList[index]).EntityData is EditorCustomData)
        {
          EditorCustomData entityData = ((Entity) entity.CurveList[index]).EntityData as EditorCustomData;
          buEntity.Info.Commands = new List<string>();
          buEntity.Info.Commands.AddRange((IEnumerable<string>) entityData.Commands);
        }
        if (buEntity != null)
          clsLibrary.LibraryEntities.Add(buEntity);
      }
    }
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_3(object sender, EventArgs e)
  {
    if (!this.PropertiesForm.Inited || !(this.listBox_0.Items.Count > 0 & this.listBox_0.SelectedIndex >= 0) || !(this.listBox_0.Items[this.listBox_0.SelectedIndex].GetType() == typeof (FileItem)))
      return;
    FileItem fileItem = new FileItem(((FileItem) this.listBox_0.Items[this.listBox_0.SelectedIndex]).FileFullName);
    this.viewport.Clear();
    Class5.smethod_70(fileItem.FileFullName, this);
    this.label_2.Text = $"{AppLanguage.CadCamDynamic[32 /*0x20*/]} {AppLanguage.CadCamDynamic[40]} : {buFile.getFileNameWithoutExtension(fileItem.FileFullName)}";
  }

  internal void method_4(object sender, DataGridViewCellEventArgs e)
  {
    this.int_0 = e.RowIndex;
    this.int_1 = e.ColumnIndex;
    Class5.smethod_122(this);
  }

  internal void method_5(object sender, DataGridViewCellEventArgs e)
  {
    if (!this.PropertiesForm.Inited)
      return;
    Class5.smethod_122(this);
    string s = this.dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
    double result = 0.0;
    double.TryParse(s, out result);
    if (this.selectedEntity == null)
      return;
    ((ValueVisualConstraint) this.viewport.CurrentSketch.GetConstraint(this.selectedEntity)).Value = result;
    this.viewport.CurrentSketch.UpdateAndInvalidate();
  }

  internal void method_6(object sender, DataGridViewCellEventArgs e)
  {
    this.int_0 = e.RowIndex;
    this.int_1 = e.ColumnIndex;
    Class5.smethod_122(this);
  }

  internal void method_7(object sender, EventArgs e)
  {
    try
    {
      int num = 1;
      if (this.textBox_0.Text.Length == 0)
      {
        Class5.smethod_141(this);
      }
      else
      {
        this.listBox_0.Items.Clear();
        for (int index = 0; index <= this.list_0.Count - 1; ++index)
        {
          string withoutExtension = buFile.getFileNameWithoutExtension(this.list_0[index]);
          if (withoutExtension.ToLower().IndexOf(this.textBox_0.Text.ToLower()) >= 0)
          {
            this.listBox_0.Items.Add((object) withoutExtension);
            ++num;
          }
        }
      }
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  private void viewport_MouseMove(object sender, MouseEventArgs e)
  {
    Point3D intPoint = new Point3D();
    this.viewport.ScreenToPlane(e.Location, Plane.XY, out intPoint);
    this.label_1.Text = $"X: {intPoint.X.ToString("f2")} - Y: {intPoint.Y.ToString("f2")}";
  }

  private void viewport_MouseDown(object sender, MouseEventArgs e)
  {
    int[] underMouseCursor = this.viewport.GetAllEntitiesUnderMouseCursor(e.Location);
    if (underMouseCursor == null || underMouseCursor.Length == 0 || !(this.viewport.Entities[underMouseCursor[0]].GetType().BaseType == typeof (Dimension)) || this.viewport.Entities[underMouseCursor[0]].EntityData != null)
      ;
  }

  private void viewport_MouseDoubleClick(object sender, MouseEventArgs e)
  {
    SelectedItem underMouseCursor = this.viewport.GetItemUnderMouseCursor(e.Location, true);
    if (underMouseCursor == null)
      return;
    Entity entity = underMouseCursor.Item as Entity;
    VisualConstraint constraint = this.viewport.CurrentSketch.GetConstraint(entity);
    if (!(constraint is ValueVisualConstraint))
      return;
    DialogBoxInput dialogBoxInput = new DialogBoxInput();
    dialogBoxInput.Value = ((ValueVisualConstraint) constraint).Value;
    dialogBoxInput.StartPosition = FormStartPosition.CenterParent;
    dialogBoxInput.Init();
    dialogBoxInput.SelectAll();
    int num = (int) dialogBoxInput.ShowDialog();
    if (dialogBoxInput.Result == DialogResult.OK)
    {
      ((ValueVisualConstraint) constraint).Value = dialogBoxInput.Value;
      int index1 = 0;
      for (int index2 = 0; index2 <= this.viewport.Entities.Count - 1; ++index2)
      {
        if (this.viewport.Entities[index2] is Dimension)
        {
          if (clsInit.cVector5.isEntitySame(entity, this.viewport.Entities[index2]) && index1 <= this.dataGridView_0.Rows.Count - 1)
          {
            this.PropertiesForm.Inited = false;
            this.dataGridView_0.Rows[index1].Cells[1].Value = (object) dialogBoxInput.Value;
          }
          ++index1;
        }
      }
    }
    this.viewport.CurrentSketch.UpdateAndInvalidate();
    this.PropertiesForm.Inited = true;
  }

  internal void method_8(object sender, MouseEventArgs e)
  {
    if (this.bool_0)
      ;
  }

  internal void method_9(object sender, KeyEventArgs e) => this.bool_0 = e.Control;

  internal void method_10(object sender, KeyEventArgs e) => this.bool_0 = false;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
