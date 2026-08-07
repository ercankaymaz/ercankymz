// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Marble.F_MultiCut
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buClass.Apps;
using buControls.Controls;
using buControls.Forms.buControlForms.Marble;
using buCore;
using buCore.AppCalc;
using ns7;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Marble;

public class F_MultiCut : Form
{
  public static List<string> Captions = new List<string>();
  public marbleMultiCut varMutliCut = new marbleMultiCut();
  public marbleOperation varOperations = new marbleOperation();
  public List<List<eEntities>> CalculatedEntities = new List<List<eEntities>>();
  public List<Quad3D> QualList = new List<Quad3D>();
  public MaterialBase activeMaterial = new MaterialBase();
  public DialogResult Result = DialogResult.No;
  public bool VerticalCut = false;
  public bool ReverseAngleA = false;
  public FormCloseModeType FormCloseMode = FormCloseModeType.Invisible;
  public bool AskTabChangeQuestions = false;
  public string pathFiles = Application.StartupPath;
  public bool OfflineMode = false;
  public List<marbleCutItems> listItems = new List<marbleCutItems>();
  internal bool bool_0 = false;
  private bool bool_1 = false;
  private Pnt6D pnt6D_0 = new Pnt6D();
  private Pnt6D pnt6D_1 = new Pnt6D();
  private int int_0 = -1;
  private int int_1 = -1;
  internal IContainer icontainer_0 = (IContainer) null;
  internal DataGridView dataGridView_0;
  internal Button button_0;
  internal NumericUpDown numericUpDown_0;
  internal Label label_0;
  internal Button button_1;
  internal Button button_2;
  internal Button button_3;
  internal Button button_4;
  internal Button button_5;
  internal Button button_6;
  internal ImageList imageList_0;
  internal Panel panel_0;
  internal Button button_7;
  internal Button button_8;
  internal Button button_9;
  internal Button button_10;
  internal Button button_11;
  internal Button button_12;
  internal CheckBox checkBox_0;
  internal Button button_13;
  internal Label label_1;
  internal NumericUpDown numericUpDown_1;
  internal NumericUpDown numericUpDown_2;
  internal NumericUpDown numericUpDown_3;
  internal PictureBox pictureBox_0;
  internal PictureBox pictureBox_1;
  internal Panel panel_1;
  internal NumericUpDown numericUpDown_4;
  internal Label label_2;
  internal NumericUpDown numericUpDown_5;
  internal Label label_3;
  internal NumericUpDown numericUpDown_6;
  internal Label label_4;
  internal NumericUpDown numericUpDown_7;
  internal Label label_5;
  internal NumericUpDown numericUpDown_8;
  internal Label label_6;
  internal PictureBox pictureBox_2;
  internal NumericUpDown numericUpDown_9;
  internal NumericUpDown numericUpDown_10;
  internal NumericUpDown numericUpDown_11;
  internal NumericUpDown numericUpDown_12;
  internal Label label_7;
  internal Label label_8;
  internal Label label_9;
  internal Label label_10;
  internal PictureBox pictureBox_3;
  internal Panel panel_2;
  internal Button button_14;
  internal Button button_15;

  public event MarblePerpendicularModeEventHandler TabChanged;

  public event MarbleSetStartPositionHandler SetStartPosition;

  public event MarbleSetStartPositionHandler SetEndPosition;

  public event EventHandler ShowJogPage;

  public F_MultiCut() => Class39.smethod_659(this);

  public void Init()
  {
    try
    {
      this.bool_0 = false;
      this.bool_1 = false;
      this.button_0.BackColor = Color.Red;
      this.button_1.BackColor = Color.Red;
      if (this.varOperations.isVertical)
        this.VerticalCut = true;
      this.dataGridView_0.RowHeadersVisible = false;
      this.dataGridView_0.ColumnHeadersVisible = false;
      this.dataGridView_0.AllowUserToAddRows = false;
      this.dataGridView_0.AllowUserToResizeColumns = false;
      this.dataGridView_0.AllowUserToResizeRows = false;
      this.dataGridView_0.Columns.Clear();
      this.dataGridView_0.Rows.Clear();
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.Width = 150;
      dataGridViewColumn1.HeaderText = "Length";
      dataGridViewColumn1.Name = "Length";
      dataGridViewColumn1.ReadOnly = false;
      dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 14f, FontStyle.Bold);
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      this.dataGridView_0.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.HeaderText = "Count";
      dataGridViewColumn2.Name = "Count";
      dataGridViewColumn2.Width = 150;
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 14f, FontStyle.Bold);
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      this.dataGridView_0.Columns.Add(dataGridViewColumn2);
      DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
      dataGridViewColumn3.HeaderText = "Start Angle";
      dataGridViewColumn3.Name = "Start Angle";
      dataGridViewColumn3.Width = 150;
      dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 14f, FontStyle.Bold);
      dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      this.dataGridView_0.Columns.Add(dataGridViewColumn3);
      DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
      dataGridViewColumn4.Width = this.dataGridView_0.Width - dataGridViewColumn1.Width - dataGridViewColumn2.Width - dataGridViewColumn3.Width - 25;
      dataGridViewColumn4.HeaderText = "End Angle";
      dataGridViewColumn4.Name = "End Angle";
      dataGridViewColumn4.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 14f, FontStyle.Bold);
      dataGridViewColumn4.ReadOnly = false;
      this.dataGridView_0.Columns.Add(dataGridViewColumn4);
      if (this.VerticalCut)
      {
        this.button_2.BackColor = Color.PaleTurquoise;
        this.button_3.BackColor = Color.Red;
      }
      else
      {
        this.button_2.BackColor = Color.Red;
        this.button_3.BackColor = Color.PaleTurquoise;
      }
      this.numericUpDown_1.Value = (Decimal) this.varOperations.TargetZ;
      this.numericUpDown_0.Value = (Decimal) this.varOperations.CutLength;
      this.checkBox_0.Checked = this.varOperations.ApplySurfaceReadData;
      this.numericUpDown_8.Value = (Decimal) this.varOperations.AxisValues.X;
      this.numericUpDown_7.Value = (Decimal) this.varOperations.AxisValues.Y;
      this.numericUpDown_6.Value = (Decimal) this.varOperations.AxisValues.Z;
      this.numericUpDown_5.Value = (Decimal) this.varOperations.AxisValues.A;
      this.numericUpDown_4.Value = (Decimal) this.varOperations.AxisValues.C;
      int count = this.listItems.Count;
      for (int index = 0; index <= count - 1; ++index)
        Class39.smethod_616(false, this.listItems[index], this);
      Class39.smethod_262(this);
      this.LoadLanguage();
      this.bool_0 = true;
    }
    catch (Exception ex)
    {
      string str = nameof (F_MultiCut);
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void LoadLanguage()
  {
    try
    {
      if (F_MultiCut.Captions.Count <= 22)
        return;
      this.Text = F_MultiCut.Captions[0];
      this.button_0.Text = F_MultiCut.Captions[1];
      this.button_1.Text = F_MultiCut.Captions[2];
      this.label_0.Text = F_MultiCut.Captions[22];
      this.label_1.Text = F_MultiCut.Captions[21];
      this.button_9.Text = F_MultiCut.Captions[5];
      this.button_8.Text = F_MultiCut.Captions[6];
      this.button_12.Text = F_MultiCut.Captions[7];
      this.button_3.Text = F_MultiCut.Captions[8];
      this.button_2.Text = F_MultiCut.Captions[9];
      this.label_7.Text = F_MultiCut.Captions[10];
      this.label_8.Text = F_MultiCut.Captions[11];
      this.label_9.Text = F_MultiCut.Captions[12];
      this.label_10.Text = F_MultiCut.Captions[13];
      this.button_6.Text = F_MultiCut.Captions[14];
      this.button_11.Text = F_MultiCut.Captions[16 /*0x10*/];
      this.button_7.Text = F_MultiCut.Captions[17];
      this.button_13.Text = F_MultiCut.Captions[18];
      this.button_15.Text = F_MultiCut.Captions[19];
      this.button_10.Text = F_MultiCut.Captions[20];
      this.checkBox_0.Text = F_MultiCut.Captions[20];
    }
    catch (Exception ex)
    {
    }
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
    if (control2.Name == this.button_11.Name)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.InitialDirectory = this.pathFiles;
      saveFileDialog.Filter = "Marble Item Files (.bumarbleitem)|*.bumarbleitem";
      saveFileDialog.FilterIndex = 1;
      if (saveFileDialog.ShowDialog() == DialogResult.OK)
      {
        this.pathFiles = buFile.GetPath(saveFileDialog.FileName);
        ArrayList StringList = new ArrayList();
        for (int index = 0; index <= this.listItems.Count - 1; ++index)
          StringList.AddRange((ICollection) this.listItems[index].ToDefAll("", 2, SerilizationMode.MultiLine).ToArray());
        buFile.SaveToFile(StringList, saveFileDialog.FileName);
      }
    }
    if (control2.Name == this.button_7.Name)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.InitialDirectory = this.pathFiles;
      openFileDialog.Filter = "Marble Item Files (.bumarbleitem)|*.bumarbleitem";
      openFileDialog.FilterIndex = 1;
      openFileDialog.Multiselect = false;
      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
        ArrayList StringList = new ArrayList();
        this.pathFiles = buFile.GetPath(openFileDialog.FileName);
        buFile.OpenFromFile(openFileDialog.FileName, ref StringList);
        List<List<string>> CalcList = new List<List<string>>();
        this.listItems.Clear();
        this.listItems = new List<marbleCutItems>();
        buString.ListToSpecificList("<marbleCutItems>", "</marbleCutItems>", true, StringList, ref CalcList);
        for (int index = 0; index <= CalcList.Count - 1; ++index)
        {
          marbleCutItems marbleCutItems = new marbleCutItems();
          buSerilization.Decode(CalcList[index], "", SerilizationMode.MultiLine, (object) marbleCutItems);
          this.listItems.Add(marbleCutItems);
        }
        this.Init();
      }
    }
    if (control2.Name == this.button_10.Name)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.InitialDirectory = this.pathFiles;
      openFileDialog.Filter = "Surface Data File (*.csv)|*.csv";
      openFileDialog.FilterIndex = 1;
      openFileDialog.Multiselect = false;
      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
        List<Pnt3D> pntTeachList = new List<Pnt3D>();
        buFile.OpenSurfaceReadFile(openFileDialog.FileName, ref pntTeachList);
        if (pntTeachList.Count > 2)
        {
          buCamCalc.pntTeachGrids.Clear();
          buControlCoreClass.cVector.CreateSurfaceGridFromTeachFile(new SurfaceReadGridData()
          {
            GridDistance = new Pnt3D(1.0, 1.0)
          }, pntTeachList, ref buCamCalc.pntTeachGrids);
        }
      }
    }
    if (control2.Name == this.button_6.Name && this.int_0 >= 0 & this.int_0 <= this.listItems.Count - 1 && buString.MessageBoxQuestion(buMarbleCalc.LangMarbleMessage[4]) == DialogResult.Yes)
    {
      this.listItems.RemoveAt(this.int_0);
      this.dataGridView_0.Rows.RemoveAt(this.int_0);
      --this.int_0;
      if (this.int_0 < 0)
        this.int_0 = 0;
      if (this.dataGridView_0.Rows.Count == 0)
        this.int_0 = -1;
      Class39.smethod_262(this);
    }
    if (control2.Name == this.button_3.Name)
    {
      this.button_2.BackColor = Color.Red;
      this.button_3.BackColor = Color.PaleTurquoise;
      this.VerticalCut = false;
      if (this.OfflineMode)
        this.numericUpDown_4.Value = 0M;
      // ISSUE: reference to a compiler-generated field
      if (this.AskTabChangeQuestions && this.marblePerpendicularModeEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.marblePerpendicularModeEventHandler_0(0);
      }
    }
    if (control2.Name == this.button_2.Name)
    {
      this.button_2.BackColor = Color.PaleTurquoise;
      this.button_3.BackColor = Color.Red;
      this.VerticalCut = true;
      if (this.OfflineMode)
        this.numericUpDown_4.Value = 90M;
      // ISSUE: reference to a compiler-generated field
      if (this.AskTabChangeQuestions && this.marblePerpendicularModeEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.marblePerpendicularModeEventHandler_0(1);
      }
    }
    if (control2.Name == this.button_13.Name)
    {
      F_ItemCutCamParameters cutCamParameters = new F_ItemCutCamParameters();
      cutCamParameters.Value = new marbleOperation(this.varOperations);
      cutCamParameters.Init();
      cutCamParameters.StartPosition = FormStartPosition.CenterParent;
      int num = (int) cutCamParameters.ShowDialog((IWin32Window) this);
      if (cutCamParameters.Result == DialogResult.OK)
        this.varOperations = new marbleOperation(cutCamParameters.Value);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_9.Name && this.eventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0(sender, e);
    }
    if (control2.Name == this.button_15.Name)
      ;
    if (control2.Name == this.button_8.Name)
    {
      if (this.OfflineMode)
        this.varOperations.AxisValues = new Pnt6D((double) this.numericUpDown_8.Value, (double) this.numericUpDown_7.Value, (double) this.numericUpDown_6.Value, (double) this.numericUpDown_5.Value, 0.0, (double) this.numericUpDown_4.Value);
      if (Math.Abs(this.varOperations.AxisValues.C) > 45.0 & Math.Abs(this.varOperations.AxisValues.C) < 135.0 && !this.VerticalCut && buString.MessageBoxQuestion(buMarbleCalc.LangMarbleMessage[2]) == DialogResult.Yes)
        this.VerticalCut = true;
      if (Math.Abs(this.varOperations.AxisValues.C) > 225.0 & Math.Abs(this.varOperations.AxisValues.C) < 315.0 && !this.VerticalCut && buString.MessageBoxQuestion(buMarbleCalc.LangMarbleMessage[2]) == DialogResult.Yes)
        this.VerticalCut = true;
      Class39.smethod_121(this);
      this.varOperations.isVertical = this.VerticalCut;
      if (this.varOperations.TargetZ >= this.varOperations.MaterialThickness)
      {
        buString.MessageBoxWarning(buMarbleCalc.LangMarbleMessage[3]);
        return;
      }
      Pnt3D EndPnt = new Pnt3D();
      if (this.bool_1)
      {
        this.varOperations.AxisValues.X = this.pnt6D_0.X;
        this.varOperations.AxisValues.Y = this.pnt6D_0.Y;
      }
      buControlCoreClass.cVector.LineWithLengthAndAngle(new Pnt3D(this.varOperations.AxisValues.X, this.varOperations.AxisValues.Y, this.varOperations.AxisValues.Z), this.varOperations.CutLength, this.varOperations.AxisValues.C, new WorkPlane(), ref EndPnt);
      this.Result = DialogResult.OK;
      this.bool_1 = false;
      if (this.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.button_12.Name)
    {
      this.Result = DialogResult.Cancel;
      this.bool_1 = false;
      if (this.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.button_14.Name)
    {
      if (buString.MessageBoxQuestion(buMarbleCalc.LangMarbleMessage[5]) == DialogResult.Yes)
      {
        for (int index = this.dataGridView_0.Rows.Count - 1; index >= 0; --index)
        {
          this.listItems.RemoveAt(index);
          this.dataGridView_0.Rows.RemoveAt(index);
        }
      }
      this.int_0 = -1;
      Class39.smethod_262(this);
    }
    if (control2.Name == this.button_5.Name && this.int_0 >= 0 & this.int_0 < this.dataGridView_0.Rows.Count - 1)
    {
      if (this.int_1 < 0)
        this.int_1 = 0;
      ++this.int_0;
      this.dataGridView_0.CurrentCell = this.dataGridView_0.Rows[this.int_0].Cells[this.int_1];
    }
    if (control2.Name == this.button_4.Name && this.int_0 > 0)
    {
      if (this.int_1 < 0)
        this.int_1 = 0;
      --this.int_0;
      this.dataGridView_0.CurrentCell = this.dataGridView_0.Rows[this.int_0].Cells[this.int_1];
    }
    if (control2.Name == this.button_0.Name)
    {
      this.button_0.BackColor = Color.Green;
      this.bool_1 = true;
      this.pnt6D_0 = new Pnt6D((double) this.numericUpDown_8.Value, (double) this.numericUpDown_7.Value, (double) this.numericUpDown_6.Value, (double) this.numericUpDown_5.Value, 0.0, (double) this.numericUpDown_4.Value);
      // ISSUE: reference to a compiler-generated field
      if (this.marbleSetStartPositionHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.marbleSetStartPositionHandler_0(this.pnt6D_0);
      }
    }
    if (!(control2.Name == this.button_1.Name) || !this.bool_1)
      return;
    this.button_1.BackColor = Color.Green;
    this.pnt6D_1 = new Pnt6D((double) this.numericUpDown_8.Value, (double) this.numericUpDown_7.Value, (double) this.numericUpDown_6.Value, (double) this.numericUpDown_5.Value, 0.0, (double) this.numericUpDown_4.Value);
    this.numericUpDown_0.Value = (Decimal) buControlCoreClass.cVector.Length3D(this.pnt6D_0, this.pnt6D_1);
    // ISSUE: reference to a compiler-generated field
    if (this.marbleSetStartPositionHandler_1 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.marbleSetStartPositionHandler_1(this.pnt6D_1);
  }

  internal void method_2(object sender, KeyEventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (!(e.KeyCode == Keys.Return | e.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKey(this.panel_2.Controls, result, e.Shift);
    if (!(control2.Name == this.numericUpDown_12.Name))
      return;
    marbleCutItems marbleCutItems_0 = new marbleCutItems();
    marbleCutItems_0.Length = (double) this.numericUpDown_9.Value;
    marbleCutItems_0.Count = (int) this.numericUpDown_10.Value;
    marbleCutItems_0.StartAngle = (double) this.numericUpDown_11.Value;
    marbleCutItems_0.EndAngle = (double) this.numericUpDown_12.Value;
    if (!(marbleCutItems_0.Length > 0.0 & marbleCutItems_0.Count > 0))
      return;
    this.bool_0 = false;
    Class39.smethod_616(true, marbleCutItems_0, this);
    this.bool_0 = true;
  }

  internal void method_3(object sender, EventArgs e)
  {
    try
    {
      if (!AppBool.TouchPad)
        return;
      buSpin buSpin = new buSpin();
      buControlCommands.ShowKeyPad((Form) this, (Control) sender);
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  internal void method_4(object sender, DataGridViewCellEventArgs e)
  {
    if (!this.bool_0 || !(this.int_0 >= 0 & this.int_0 <= this.listItems.Count - 1))
      return;
    this.listItems[this.int_0].Length = Convert.ToDouble(this.dataGridView_0.Rows[this.int_0].Cells[0].Value);
    this.listItems[this.int_0].Count = Convert.ToInt32(this.dataGridView_0.Rows[this.int_0].Cells[1].Value);
    this.listItems[this.int_0].StartAngle = Convert.ToDouble(this.dataGridView_0.Rows[this.int_0].Cells[2].Value);
    this.listItems[this.int_0].EndAngle = Convert.ToDouble(this.dataGridView_0.Rows[this.int_0].Cells[3].Value);
    Class39.smethod_262(this);
  }

  internal void method_5(object sender, DataGridViewCellEventArgs e)
  {
    this.int_0 = e.RowIndex;
    this.int_1 = e.ColumnIndex;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
