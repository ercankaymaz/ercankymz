// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Marble.F_PerpendicularCut
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buClass.Apps;
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

public class F_PerpendicularCut : Form
{
  public static List<string> Captions = new List<string>();
  public marblePerpendicularCut varPerpendicularCut = new marblePerpendicularCut();
  public marbleOperation varOperations = new marbleOperation();
  public List<List<eEntities>> CalculatedEntities = new List<List<eEntities>>();
  public List<Quad3D> QualList = new List<Quad3D>();
  public MaterialBase activeMaterial = new MaterialBase();
  public DialogResult Result = DialogResult.No;
  public bool AskTabChangeQuestions = false;
  public bool ReverseAngleA = false;
  public FormCloseModeType FormCloseMode = FormCloseModeType.Invisible;
  public string pathFiles = Application.StartupPath;
  public bool OfflineMode = false;
  public List<marbleCutItems> listItemsHor = new List<marbleCutItems>();
  public List<marbleCutItems> listItemsVer = new List<marbleCutItems>();
  internal bool bool_0 = false;
  private bool bool_1 = false;
  private bool bool_2 = false;
  public Pnt6D StartPosVer = new Pnt6D();
  public Pnt6D EndPosVer = new Pnt6D();
  public Pnt6D StartPosHor = new Pnt6D();
  public Pnt6D EndPosHor = new Pnt6D();
  private int int_0 = -1;
  private int int_1 = -1;
  private int int_2 = -1;
  private int int_3 = -1;
  internal IContainer icontainer_0 = (IContainer) null;
  internal TabControl tabControl_0;
  internal TabPage tabPage_0;
  internal TabPage tabPage_1;
  internal ImageList imageList_0;
  internal Panel panel_0;
  internal NumericUpDown numericUpDown_0;
  internal Label label_0;
  internal NumericUpDown numericUpDown_1;
  internal Label label_1;
  internal NumericUpDown numericUpDown_2;
  internal Label label_2;
  internal NumericUpDown numericUpDown_3;
  internal Label label_3;
  internal NumericUpDown numericUpDown_4;
  internal Label label_4;
  internal PictureBox pictureBox_0;
  internal Label label_5;
  internal NumericUpDown numericUpDown_5;
  internal PictureBox pictureBox_1;
  internal Button button_0;
  internal Panel panel_1;
  internal Button button_1;
  internal Button button_2;
  internal CheckBox checkBox_0;
  internal Button button_3;
  internal Button button_4;
  internal Button button_5;
  internal Button button_6;
  internal Button button_7;
  internal Button button_8;
  internal Label label_6;
  internal NumericUpDown numericUpDown_6;
  internal Button button_9;
  internal Button button_10;
  internal Panel panel_2;
  internal Label label_7;
  internal NumericUpDown numericUpDown_7;
  internal Label label_8;
  internal NumericUpDown numericUpDown_8;
  internal Label label_9;
  internal NumericUpDown numericUpDown_9;
  internal Label label_10;
  internal NumericUpDown numericUpDown_10;
  internal PictureBox pictureBox_2;
  internal NumericUpDown numericUpDown_11;
  internal NumericUpDown numericUpDown_12;
  internal Button button_11;
  internal Button button_12;
  internal Button button_13;
  internal DataGridView dataGridView_0;
  internal Button button_14;
  internal Label label_11;
  internal NumericUpDown numericUpDown_13;
  internal Button button_15;
  internal Button button_16;
  internal Panel panel_3;
  internal Label label_12;
  internal NumericUpDown numericUpDown_14;
  internal Label label_13;
  internal NumericUpDown numericUpDown_15;
  internal Label label_14;
  internal NumericUpDown numericUpDown_16;
  internal Label label_15;
  internal NumericUpDown numericUpDown_17;
  internal PictureBox pictureBox_3;
  internal NumericUpDown numericUpDown_18;
  internal NumericUpDown numericUpDown_19;
  internal Button button_17;
  internal Button button_18;
  internal Button button_19;
  internal DataGridView dataGridView_1;
  internal CheckBox checkBox_1;
  internal Label label_16;
  internal Label label_17;

  public F_PerpendicularCut() => Class39.smethod_326(this);

  public event MarblePerpendicularModeEventHandler TabChanged;

  public event MarbleSetStartPositionHandler SetStartPositionHor;

  public event MarbleSetStartPositionHandler SetEndPositionHor;

  public event MarbleSetStartPositionHandler SetStartPositionVer;

  public event MarbleSetStartPositionHandler SetEndPositionVer;

  public event EventHandler ShowJogPage;

  public void Init()
  {
    try
    {
      this.bool_0 = false;
      this.bool_1 = false;
      this.bool_2 = false;
      this.button_9.BackColor = Color.Red;
      this.button_8.BackColor = Color.Red;
      this.button_15.BackColor = Color.Red;
      this.button_14.BackColor = Color.Red;
      this.checkBox_1.Checked = this.varOperations.VerticalFirst;
      this.checkBox_0.Checked = this.varOperations.ApplySurfaceReadData;
      this.numericUpDown_5.Value = (Decimal) this.varOperations.TargetZ;
      this.numericUpDown_6.Value = (Decimal) this.varPerpendicularCut.CutHorizontalLength;
      this.numericUpDown_13.Value = (Decimal) this.varPerpendicularCut.CutVerticalLength;
      this.numericUpDown_4.Value = (Decimal) this.varOperations.AxisValues.X;
      this.numericUpDown_3.Value = (Decimal) this.varOperations.AxisValues.Y;
      this.numericUpDown_2.Value = (Decimal) this.varOperations.AxisValues.Z;
      this.numericUpDown_1.Value = (Decimal) this.varOperations.AxisValues.A;
      this.numericUpDown_0.Value = (Decimal) this.varOperations.AxisValues.C;
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
      int count1 = this.listItemsHor.Count;
      for (int index = 0; index <= count1 - 1; ++index)
        Class39.smethod_442(this.listItemsHor[index], false, this);
      this.dataGridView_1.RowHeadersVisible = false;
      this.dataGridView_1.ColumnHeadersVisible = false;
      this.dataGridView_1.AllowUserToAddRows = false;
      this.dataGridView_1.AllowUserToResizeColumns = false;
      this.dataGridView_1.AllowUserToResizeRows = false;
      this.dataGridView_1.Columns.Clear();
      this.dataGridView_1.Rows.Clear();
      DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
      dataGridViewColumn5.Width = 150;
      dataGridViewColumn5.HeaderText = "Length";
      dataGridViewColumn5.Name = "Length";
      dataGridViewColumn5.ReadOnly = false;
      dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 14f, FontStyle.Bold);
      dataGridViewColumn5.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      this.dataGridView_1.Columns.Add(dataGridViewColumn5);
      DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
      dataGridViewColumn6.HeaderText = "Count";
      dataGridViewColumn6.Name = "Count";
      dataGridViewColumn6.Width = 150;
      dataGridViewColumn6.DefaultCellStyle.Font = new Font("Arial", 14f, FontStyle.Bold);
      dataGridViewColumn6.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      this.dataGridView_1.Columns.Add(dataGridViewColumn6);
      DataGridViewColumn dataGridViewColumn7 = new DataGridViewColumn();
      dataGridViewColumn7.HeaderText = "Start Angle";
      dataGridViewColumn7.Name = "Start Angle";
      dataGridViewColumn7.Width = 150;
      dataGridViewColumn7.DefaultCellStyle.Font = new Font("Arial", 14f, FontStyle.Bold);
      dataGridViewColumn7.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      this.dataGridView_1.Columns.Add(dataGridViewColumn7);
      DataGridViewColumn dataGridViewColumn8 = new DataGridViewColumn();
      dataGridViewColumn8.Width = this.dataGridView_1.Width - dataGridViewColumn5.Width - dataGridViewColumn6.Width - dataGridViewColumn7.Width - 25;
      dataGridViewColumn8.HeaderText = "End Angle";
      dataGridViewColumn8.Name = "End Angle";
      dataGridViewColumn8.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn8.DefaultCellStyle.Font = new Font("Arial", 14f, FontStyle.Bold);
      dataGridViewColumn8.ReadOnly = false;
      this.dataGridView_1.Columns.Add(dataGridViewColumn8);
      int count2 = this.listItemsVer.Count;
      for (int index = 0; index <= count2 - 1; ++index)
        Class39.smethod_261(this.listItemsVer[index], false, this);
      Class39.smethod_580(this);
      this.LoadLanguage();
      this.bool_0 = true;
    }
    catch (Exception ex)
    {
      string str = "F_MultiCut";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void LoadLanguage()
  {
    try
    {
      if (F_PerpendicularCut.Captions.Count <= 25)
        return;
      this.Text = F_PerpendicularCut.Captions[0];
      this.button_9.Text = F_PerpendicularCut.Captions[1];
      this.button_15.Text = F_PerpendicularCut.Captions[1];
      this.button_8.Text = F_PerpendicularCut.Captions[2];
      this.button_14.Text = F_PerpendicularCut.Captions[2];
      this.label_6.Text = F_PerpendicularCut.Captions[24];
      this.label_11.Text = F_PerpendicularCut.Captions[24];
      this.label_5.Text = F_PerpendicularCut.Captions[23];
      this.button_6.Text = F_PerpendicularCut.Captions[5];
      this.button_7.Text = F_PerpendicularCut.Captions[6];
      this.button_0.Text = F_PerpendicularCut.Captions[7];
      this.tabPage_0.Text = F_PerpendicularCut.Captions[8];
      this.tabPage_1.Text = F_PerpendicularCut.Captions[9];
      this.label_7.Text = F_PerpendicularCut.Captions[10];
      this.label_12.Text = F_PerpendicularCut.Captions[10];
      this.label_10.Text = F_PerpendicularCut.Captions[11];
      this.label_15.Text = F_PerpendicularCut.Captions[11];
      this.label_9.Text = F_PerpendicularCut.Captions[12];
      this.label_14.Text = F_PerpendicularCut.Captions[12];
      this.label_8.Text = F_PerpendicularCut.Captions[13];
      this.label_13.Text = F_PerpendicularCut.Captions[13];
      this.button_10.Text = F_PerpendicularCut.Captions[14];
      this.button_16.Text = F_PerpendicularCut.Captions[14];
      this.button_4.Text = F_PerpendicularCut.Captions[16 /*0x10*/];
      this.button_5.Text = F_PerpendicularCut.Captions[17];
      this.label_16.Text = F_PerpendicularCut.Captions[18];
      this.label_17.Text = F_PerpendicularCut.Captions[19];
      this.button_2.Text = F_PerpendicularCut.Captions[20];
      this.button_1.Text = F_PerpendicularCut.Captions[21];
      this.checkBox_0.Text = F_PerpendicularCut.Captions[22];
      this.button_3.Text = F_PerpendicularCut.Captions[22];
      this.checkBox_1.Text = F_PerpendicularCut.Captions[25];
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
    if (control2.Name == this.button_4.Name)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.InitialDirectory = this.pathFiles;
      saveFileDialog.Filter = "Marble Item Files (.bumarbleitem)|*.bumarbleitem";
      saveFileDialog.FilterIndex = 1;
      if (saveFileDialog.ShowDialog() == DialogResult.OK)
      {
        this.pathFiles = buFile.GetPath(saveFileDialog.FileName);
        ArrayList StringList = new ArrayList();
        for (int index = 0; index <= this.listItemsHor.Count - 1; ++index)
          StringList.AddRange((ICollection) this.listItemsHor[index].ToDefAll("Horizontal", 2, SerilizationMode.MultiLine).ToArray());
        for (int index = 0; index <= this.listItemsVer.Count - 1; ++index)
          StringList.AddRange((ICollection) this.listItemsVer[index].ToDefAll("Vertical", 2, SerilizationMode.MultiLine).ToArray());
        buFile.SaveToFile(StringList, saveFileDialog.FileName);
      }
    }
    if (control2.Name == this.button_5.Name)
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
        List<List<string>> CalcList1 = new List<List<string>>();
        this.listItemsHor.Clear();
        this.listItemsHor = new List<marbleCutItems>();
        this.listItemsVer.Clear();
        this.listItemsVer = new List<marbleCutItems>();
        buString.ListToSpecificList("<marbleCutItemsHorizontal>", "</marbleCutItemsHorizontal>", true, StringList, ref CalcList1);
        for (int index = 0; index <= CalcList1.Count - 1; ++index)
        {
          marbleCutItems marbleCutItems = new marbleCutItems();
          buSerilization.Decode(CalcList1[index], "Horizontal", SerilizationMode.MultiLine, (object) marbleCutItems);
          this.listItemsHor.Add(marbleCutItems);
        }
        List<List<string>> CalcList2 = new List<List<string>>();
        buString.ListToSpecificList("<marbleCutItemsVertical>", "</marbleCutItemsVertical>", true, StringList, ref CalcList2);
        for (int index = 0; index <= CalcList2.Count - 1; ++index)
        {
          marbleCutItems marbleCutItems = new marbleCutItems();
          buSerilization.Decode(CalcList2[index], "Vertical", SerilizationMode.MultiLine, (object) marbleCutItems);
          this.listItemsVer.Add(marbleCutItems);
        }
        this.Init();
      }
    }
    if (control2.Name == this.button_3.Name)
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
    if (control2.Name == this.button_11.Name && this.int_0 >= 0 & this.int_0 <= this.listItemsHor.Count - 1 && buString.MessageBoxQuestion(buMarbleCalc.LangMarbleMessage[4]) == DialogResult.Yes)
    {
      this.listItemsHor.RemoveAt(this.int_0);
      this.dataGridView_0.Rows.RemoveAt(this.int_0);
      --this.int_0;
      if (this.int_0 < 0)
        this.int_0 = 0;
      if (this.dataGridView_0.Rows.Count == 0)
        this.int_0 = -1;
      Class39.smethod_580(this);
    }
    if (control2.Name == this.button_17.Name && this.int_2 >= 0 & this.int_2 <= this.listItemsVer.Count - 1 && buString.MessageBoxQuestion(buMarbleCalc.LangMarbleMessage[4]) == DialogResult.Yes)
    {
      this.listItemsVer.RemoveAt(this.int_2);
      this.dataGridView_1.Rows.RemoveAt(this.int_2);
      --this.int_2;
      if (this.int_2 < 0)
        this.int_2 = 0;
      if (this.dataGridView_1.Rows.Count == 0)
        this.int_2 = -1;
      Class39.smethod_580(this);
    }
    if (control2.Name == this.button_2.Name)
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
    if (control2.Name == this.button_6.Name && this.eventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0(sender, e);
    }
    if (control2.Name == this.button_7.Name)
    {
      Class39.smethod_52(this);
      if (this.varOperations.TargetZ >= this.varOperations.MaterialThickness)
      {
        buString.MessageBoxWarning(buMarbleCalc.LangMarbleMessage[3]);
        return;
      }
      this.Result = DialogResult.OK;
      if (this.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.button_16.Name)
    {
      if (buString.MessageBoxQuestion(buMarbleCalc.LangMarbleMessage[5]) == DialogResult.Yes)
      {
        for (int index = this.dataGridView_1.Rows.Count - 1; index >= 0; --index)
        {
          this.listItemsVer.RemoveAt(index);
          this.dataGridView_1.Rows.RemoveAt(index);
        }
      }
      this.int_2 = -1;
      Class39.smethod_580(this);
    }
    if (control2.Name == this.button_10.Name)
    {
      if (buString.MessageBoxQuestion(buMarbleCalc.LangMarbleMessage[5]) == DialogResult.Yes)
      {
        for (int index = this.dataGridView_0.Rows.Count - 1; index >= 0; --index)
        {
          this.listItemsHor.RemoveAt(index);
          this.dataGridView_0.Rows.RemoveAt(index);
        }
      }
      this.int_0 = -1;
      Class39.smethod_580(this);
    }
    if (control2.Name == this.button_12.Name && this.int_0 >= 0 & this.int_0 < this.dataGridView_0.Rows.Count - 1)
    {
      if (this.int_1 < 0)
        this.int_1 = 0;
      ++this.int_0;
      this.dataGridView_0.CurrentCell = this.dataGridView_0.Rows[this.int_0].Cells[this.int_1];
    }
    if (control2.Name == this.button_18.Name && this.int_2 >= 0 & this.int_2 < this.dataGridView_1.Rows.Count - 1)
    {
      if (this.int_3 < 0)
        this.int_3 = 0;
      ++this.int_2;
      this.dataGridView_1.CurrentCell = this.dataGridView_1.Rows[this.int_2].Cells[this.int_3];
    }
    if (control2.Name == this.button_13.Name && this.int_0 > 0)
    {
      if (this.int_1 < 0)
        this.int_1 = 0;
      --this.int_0;
      this.dataGridView_0.CurrentCell = this.dataGridView_0.Rows[this.int_0].Cells[this.int_1];
    }
    if (control2.Name == this.button_19.Name && this.int_2 > 0)
    {
      if (this.int_3 < 0)
        this.int_3 = 0;
      --this.int_2;
      this.dataGridView_1.CurrentCell = this.dataGridView_1.Rows[this.int_2].Cells[this.int_3];
    }
    if (control2.Name == this.button_9.Name)
    {
      this.button_9.BackColor = Color.Green;
      this.bool_2 = true;
      this.StartPosHor = new Pnt6D((double) this.numericUpDown_4.Value, (double) this.numericUpDown_3.Value, (double) this.numericUpDown_2.Value, (double) this.numericUpDown_1.Value, 0.0, (double) this.numericUpDown_0.Value);
      // ISSUE: reference to a compiler-generated field
      if (this.marbleSetStartPositionHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.marbleSetStartPositionHandler_0(this.StartPosHor);
      }
    }
    if (control2.Name == this.button_15.Name)
    {
      this.button_15.BackColor = Color.Green;
      this.bool_1 = true;
      this.StartPosVer = new Pnt6D((double) this.numericUpDown_4.Value, (double) this.numericUpDown_3.Value, (double) this.numericUpDown_2.Value, (double) this.numericUpDown_1.Value, 0.0, (double) this.numericUpDown_0.Value);
      // ISSUE: reference to a compiler-generated field
      if (this.marbleSetStartPositionHandler_2 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.marbleSetStartPositionHandler_2(this.StartPosVer);
      }
    }
    if (control2.Name == this.button_8.Name && this.bool_2)
    {
      this.button_8.BackColor = Color.Green;
      this.EndPosHor = new Pnt6D((double) this.numericUpDown_4.Value, (double) this.numericUpDown_3.Value, (double) this.numericUpDown_2.Value, (double) this.numericUpDown_1.Value, 0.0, (double) this.numericUpDown_0.Value);
      this.numericUpDown_6.Value = (Decimal) buControlCoreClass.cVector.Length3D(this.StartPosHor, this.EndPosHor);
      // ISSUE: reference to a compiler-generated field
      if (this.marbleSetStartPositionHandler_1 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.marbleSetStartPositionHandler_1(this.EndPosHor);
      }
    }
    if (!(control2.Name == this.button_14.Name) || !this.bool_1)
      return;
    this.button_14.BackColor = Color.Green;
    this.EndPosVer = new Pnt6D((double) this.numericUpDown_4.Value, (double) this.numericUpDown_3.Value, (double) this.numericUpDown_2.Value, (double) this.numericUpDown_1.Value, 0.0, (double) this.numericUpDown_0.Value);
    this.numericUpDown_13.Value = (Decimal) buControlCoreClass.cVector.Length3D(this.StartPosVer, this.EndPosVer);
    // ISSUE: reference to a compiler-generated field
    if (this.marbleSetStartPositionHandler_3 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.marbleSetStartPositionHandler_3(this.EndPosVer);
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
    if (!(control2.Name == this.numericUpDown_10.Name))
      return;
    marbleCutItems marbleCutItems_0 = new marbleCutItems();
    marbleCutItems_0.Length = (double) this.numericUpDown_7.Value;
    marbleCutItems_0.Count = (int) this.numericUpDown_8.Value;
    marbleCutItems_0.StartAngle = (double) this.numericUpDown_9.Value;
    marbleCutItems_0.EndAngle = (double) this.numericUpDown_10.Value;
    if (!(marbleCutItems_0.Length > 0.0 & marbleCutItems_0.Count > 0))
      return;
    this.bool_0 = false;
    Class39.smethod_442(marbleCutItems_0, true, this);
    this.bool_0 = true;
  }

  internal void method_3(object sender, KeyEventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (!(e.KeyCode == Keys.Return | e.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKey(this.panel_3.Controls, result, e.Shift);
    if (!(control2.Name == this.numericUpDown_17.Name))
      return;
    marbleCutItems marbleCutItems_0 = new marbleCutItems();
    marbleCutItems_0.Length = (double) this.numericUpDown_14.Value;
    marbleCutItems_0.Count = (int) this.numericUpDown_15.Value;
    marbleCutItems_0.StartAngle = (double) this.numericUpDown_16.Value;
    marbleCutItems_0.EndAngle = (double) this.numericUpDown_17.Value;
    if (!(marbleCutItems_0.Length > 0.0 & marbleCutItems_0.Count > 0))
      return;
    this.bool_0 = false;
    Class39.smethod_261(marbleCutItems_0, true, this);
    this.bool_0 = true;
  }

  internal void method_4(object sender, EventArgs e)
  {
    if (!this.AskTabChangeQuestions)
      return;
    if (this.tabControl_0.SelectedIndex == 0)
    {
      if (this.OfflineMode)
        this.numericUpDown_0.Value = 0M;
      // ISSUE: reference to a compiler-generated field
      if (this.marblePerpendicularModeEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.marblePerpendicularModeEventHandler_0(this.tabControl_0.SelectedIndex);
      }
    }
    if (this.tabControl_0.SelectedIndex != 1)
      return;
    if (this.OfflineMode)
      this.numericUpDown_0.Value = 90M;
    // ISSUE: reference to a compiler-generated field
    if (this.marblePerpendicularModeEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.marblePerpendicularModeEventHandler_0(this.tabControl_0.SelectedIndex);
  }

  internal void method_5(object sender, DrawItemEventArgs e)
  {
    switch (e.Index)
    {
      case 0:
        e.Graphics.FillRectangle((Brush) new SolidBrush(Color.Red), e.Bounds);
        break;
      case 1:
        e.Graphics.FillRectangle((Brush) new SolidBrush(Color.Blue), e.Bounds);
        break;
    }
    Rectangle bounds = e.Bounds;
    bounds.Inflate(-2, -2);
    e.Graphics.DrawString(this.tabControl_0.TabPages[e.Index].Text, this.Font, SystemBrushes.HighlightText, (RectangleF) bounds);
  }

  internal void method_6(object sender, DataGridViewCellEventArgs e)
  {
    if (!this.bool_0 || !(this.int_0 >= 0 & this.int_0 <= this.listItemsHor.Count - 1))
      return;
    this.listItemsHor[this.int_0].Length = Convert.ToDouble(this.dataGridView_0.Rows[this.int_0].Cells[0].Value);
    this.listItemsHor[this.int_0].Count = Convert.ToInt32(this.dataGridView_0.Rows[this.int_0].Cells[1].Value);
    this.listItemsHor[this.int_0].StartAngle = Convert.ToDouble(this.dataGridView_0.Rows[this.int_0].Cells[2].Value);
    this.listItemsHor[this.int_0].EndAngle = Convert.ToDouble(this.dataGridView_0.Rows[this.int_0].Cells[3].Value);
    Class39.smethod_580(this);
  }

  internal void method_7(object sender, DataGridViewCellEventArgs e)
  {
    this.int_0 = e.RowIndex;
    this.int_1 = e.ColumnIndex;
  }

  internal void method_8(object sender, DataGridViewCellEventArgs e)
  {
    if (!this.bool_0 || !(this.int_2 >= 0 & this.int_2 <= this.listItemsVer.Count - 1))
      return;
    this.listItemsVer[this.int_2].Length = Convert.ToDouble(this.dataGridView_1.Rows[this.int_2].Cells[0].Value);
    this.listItemsVer[this.int_2].Count = Convert.ToInt32(this.dataGridView_1.Rows[this.int_2].Cells[1].Value);
    this.listItemsVer[this.int_2].StartAngle = Convert.ToDouble(this.dataGridView_1.Rows[this.int_2].Cells[2].Value);
    this.listItemsVer[this.int_2].EndAngle = Convert.ToDouble(this.dataGridView_1.Rows[this.int_2].Cells[3].Value);
    Class39.smethod_580(this);
  }

  internal void method_9(object sender, DataGridViewCellEventArgs e)
  {
    this.int_2 = e.RowIndex;
    this.int_3 = e.ColumnIndex;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
