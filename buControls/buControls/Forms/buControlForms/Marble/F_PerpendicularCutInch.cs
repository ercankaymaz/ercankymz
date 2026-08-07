// Decompiled with JetBrains decompiler
// Type: buControls.Forms.buControlForms.Marble.F_PerpendicularCutInch
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buClass.Apps;
using buControls.Controls;
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
namespace buControls.Forms.buControlForms.Marble;

public class F_PerpendicularCutInch : Form
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
  public List<marbleCutItems> listItemsHor = new List<marbleCutItems>();
  internal marbleCutItems[] marbleCutItems_0 = new marbleCutItems[100];
  internal int int_0 = 0;
  public List<marbleCutItems> listItemsVer = new List<marbleCutItems>();
  internal marbleCutItems[] marbleCutItems_1 = new marbleCutItems[100];
  internal int int_1 = 0;
  internal bool bool_0 = false;
  internal bool bool_1 = false;
  private bool bool_2 = false;
  private bool bool_3 = false;
  public Pnt6D StartPosVer = new Pnt6D();
  public Pnt6D EndPosVer = new Pnt6D();
  public Pnt6D StartPosHor = new Pnt6D();
  public Pnt6D EndPosHor = new Pnt6D();
  private IContainer icontainer_0 = (IContainer) null;
  internal buGround buGround_0;
  internal buLabel buLabel_0;
  internal buButton buButton_0;
  internal buButton buButton_1;
  internal buButton buButton_2;
  internal buButton buButton_3;
  internal PictureBox pictureBox_0;
  internal PictureBox pictureBox_1;
  internal PictureBox pictureBox_2;
  internal PictureBox pictureBox_3;
  internal buLabel buLabel_1;
  internal buLabel buLabel_2;
  internal buLabel buLabel_3;
  internal buLabel buLabel_4;
  internal buLabel buLabel_5;
  internal buLabel buLabel_6;
  internal buLabel buLabel_7;
  internal buLabel buLabel_8;
  internal buLabel buLabel_9;
  internal buLabel buLabel_10;
  internal buLabel buLabel_11;
  internal buButton buButton_4;
  internal PictureBox pictureBox_4;
  internal PictureBox pictureBox_5;
  internal PictureBox pictureBox_6;
  internal PictureBox pictureBox_7;
  internal buLabel buLabel_12;
  internal buLabel buLabel_13;
  internal buLabel buLabel_14;
  internal buLabel buLabel_15;
  internal buLabel buLabel_16;
  internal buLabel buLabel_17;
  internal buLabel buLabel_18;
  internal buLabel buLabel_19;
  internal buLabel buLabel_20;
  internal buButton buButton_5;
  internal buButton buButton_6;
  internal buButton buButton_7;
  internal buButton buButton_8;
  internal buButton buButton_9;
  internal buButton buButton_10;
  internal buLabel buLabel_21;
  internal buLabel buLabel_22;
  internal buLabel buLabel_23;
  internal buLabel buLabel_24;
  internal buLabel buLabel_25;
  internal buLabel buLabel_26;
  internal buSeparator buSeparator_0;
  internal buTab buTab_0;
  internal TabPage tabPage_0;
  internal TabPage tabPage_1;
  internal buSeparator buSeparator_1;
  internal buButton buButton_11;
  internal buButton buButton_12;
  internal buSeparator buSeparator_2;
  internal buButton buButton_13;
  internal buButton buButton_14;
  public buSpin spn_c;
  public buSpin spn_a;
  public buSpin spn_z;
  public buSpin spn_y;
  public buSpin spn_x;
  internal buButton buButton_15;
  public buSpin spn_itemEA5_hor;
  public buSpin spn_itemSA5_hor;
  public buSpin spn_itemcount5_hor;
  public buSpin spn_itemEA4_hor;
  public buSpin spn_itemSA4_hor;
  public buSpin spn_itemcount4_hor;
  public buSpin spn_itemEA3_hor;
  public buSpin spn_itemSA3_hor;
  public buSpin spn_itemcount3_hor;
  public buSpin spn_itemEA2_hor;
  public buSpin spn_itemSA2_hor;
  public buSpin spn_itemcount2_hor;
  public buSpin spn_itemEA1_hor;
  public buSpin spn_itemSA1_hor;
  public buSpin spn_itemEA5_ver;
  public buSpin spn_itemSA5_ver;
  public buSpin spn_itemcount5_ver;
  public buSpin spn_itemEA4_ver;
  public buSpin spn_itemSA4_ver;
  public buSpin spn_itemcount4_ver;
  public buSpin spn_itemEA3_ver;
  public buSpin spn_itemSA3_ver;
  public buSpin spn_itemcount3_ver;
  public buSpin spn_itemEA2_ver;
  public buSpin spn_itemSA2_ver;
  public buSpin spn_itemcount2_ver;
  public buSpin spn_itemEA1_ver;
  public buSpin spn_itemSA1_ver;
  public buSpin spn_itemcount1_ver;
  public buSpin spn_itemcount1_hor;
  internal buButton buButton_16;
  internal buButton buButton_17;
  public CheckBox chk_verticalfisrt;
  internal TextBox textBox_0;
  internal TextBox textBox_1;
  internal TextBox textBox_2;
  internal buTextBox buTextBox_0;
  internal buTextBox buTextBox_1;
  internal buTextBox buTextBox_2;
  internal buTextBox buTextBox_3;
  internal buTextBox buTextBox_4;
  internal buTextBox buTextBox_5;
  internal buTextBox buTextBox_6;
  internal buTextBox buTextBox_7;
  internal buTextBox buTextBox_8;
  internal buTextBox buTextBox_9;

  public F_PerpendicularCutInch()
  {
    Class39.smethod_681(this);
    this.textBox_1.Click += new EventHandler(this.textBox_2_Click);
    this.spn_itemcount1_hor.Click += new EventHandler(this.textBox_2_Click);
    this.spn_itemcount2_hor.Click += new EventHandler(this.textBox_2_Click);
    this.spn_itemcount3_hor.Click += new EventHandler(this.textBox_2_Click);
    this.spn_itemcount4_hor.Click += new EventHandler(this.textBox_2_Click);
    this.spn_itemcount5_hor.Click += new EventHandler(this.textBox_2_Click);
    this.spn_itemcount1_ver.Click += new EventHandler(this.textBox_2_Click);
    this.spn_itemcount2_ver.Click += new EventHandler(this.textBox_2_Click);
    this.spn_itemcount3_ver.Click += new EventHandler(this.textBox_2_Click);
    this.spn_itemcount4_ver.Click += new EventHandler(this.textBox_2_Click);
    this.spn_itemcount5_ver.Click += new EventHandler(this.textBox_2_Click);
    this.spn_itemEA1_hor.Click += new EventHandler(this.textBox_2_Click);
    this.spn_itemEA2_hor.Click += new EventHandler(this.textBox_2_Click);
    this.spn_itemEA3_hor.Click += new EventHandler(this.textBox_2_Click);
    this.spn_itemEA4_hor.Click += new EventHandler(this.textBox_2_Click);
    this.spn_itemEA5_hor.Click += new EventHandler(this.textBox_2_Click);
    this.spn_itemEA1_ver.Click += new EventHandler(this.textBox_2_Click);
    this.spn_itemEA2_ver.Click += new EventHandler(this.textBox_2_Click);
    this.spn_itemEA3_ver.Click += new EventHandler(this.textBox_2_Click);
    this.spn_itemEA4_ver.Click += new EventHandler(this.textBox_2_Click);
    this.spn_itemEA5_ver.Click += new EventHandler(this.textBox_2_Click);
    this.buTextBox_4.Click += new EventHandler(this.textBox_2_Click);
    this.buTextBox_3.Click += new EventHandler(this.textBox_2_Click);
    this.buTextBox_2.Click += new EventHandler(this.textBox_2_Click);
    this.buTextBox_1.Click += new EventHandler(this.textBox_2_Click);
    this.buTextBox_0.Click += new EventHandler(this.textBox_2_Click);
    this.buTextBox_9.Click += new EventHandler(this.textBox_2_Click);
    this.buTextBox_8.Click += new EventHandler(this.textBox_2_Click);
    this.buTextBox_7.Click += new EventHandler(this.textBox_2_Click);
    this.buTextBox_6.Click += new EventHandler(this.textBox_2_Click);
    this.buTextBox_5.Click += new EventHandler(this.textBox_2_Click);
    this.spn_itemSA1_hor.Click += new EventHandler(this.textBox_2_Click);
    this.spn_itemSA2_hor.Click += new EventHandler(this.textBox_2_Click);
    this.spn_itemSA3_hor.Click += new EventHandler(this.textBox_2_Click);
    this.spn_itemSA4_hor.Click += new EventHandler(this.textBox_2_Click);
    this.spn_itemSA5_hor.Click += new EventHandler(this.textBox_2_Click);
    this.spn_itemSA1_ver.Click += new EventHandler(this.textBox_2_Click);
    this.spn_itemSA2_ver.Click += new EventHandler(this.textBox_2_Click);
    this.spn_itemSA3_ver.Click += new EventHandler(this.textBox_2_Click);
    this.spn_itemSA4_ver.Click += new EventHandler(this.textBox_2_Click);
    this.spn_itemSA5_ver.Click += new EventHandler(this.textBox_2_Click);
    this.textBox_0.Click += new EventHandler(this.textBox_2_Click);
    this.textBox_2.Click += new EventHandler(this.textBox_2_Click);
  }

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
      this.bool_1 = false;
      this.bool_2 = false;
      this.bool_3 = false;
      this.buButton_14.Display.BackColor = Color.Red;
      this.buButton_13.Display.BackColor = Color.Red;
      this.buButton_12.Display.BackColor = Color.Red;
      this.buButton_11.Display.BackColor = Color.Red;
      for (int index = 0; index <= 99; ++index)
      {
        this.marbleCutItems_0[index] = new marbleCutItems();
        this.marbleCutItems_1[index] = new marbleCutItems();
      }
      for (int index = 0; index <= this.listItemsHor.Count - 1; ++index)
        this.marbleCutItems_0[index] = new marbleCutItems(this.listItemsHor[index]);
      for (int index = 0; index <= this.listItemsVer.Count - 1; ++index)
        this.marbleCutItems_1[index] = new marbleCutItems(this.listItemsVer[index]);
      this.chk_verticalfisrt.Checked = this.varOperations.VerticalFirst;
      this.textBox_1.Text = buString.InchValueToString(this.varOperations.TargetZ, 16 /*0x10*/);
      this.textBox_0.Text = buString.InchValueToString(this.varPerpendicularCut.CutHorizontalLength, 16 /*0x10*/);
      this.textBox_2.Text = buString.InchValueToString(this.varPerpendicularCut.CutVerticalLength, 16 /*0x10*/);
      this.spn_x.Value = this.varOperations.AxisValues.X;
      this.spn_y.Value = this.varOperations.AxisValues.Y;
      this.spn_z.Value = this.varOperations.AxisValues.Z;
      this.spn_a.Value = this.varOperations.AxisValues.A;
      this.spn_c.Value = this.varOperations.AxisValues.C;
      Class39.smethod_529(this);
      Class39.smethod_613(this);
      this.LoadLanguage();
      this.bool_1 = true;
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
      if (F_PerpendicularCutInch.Captions.Count <= 20)
        return;
      this.buGround_0.Text = F_PerpendicularCutInch.Captions[0];
      this.buButton_12.Text = F_PerpendicularCutInch.Captions[1];
      this.buButton_14.Text = F_PerpendicularCutInch.Captions[1];
      this.buButton_11.Text = F_PerpendicularCutInch.Captions[2];
      this.buButton_13.Text = F_PerpendicularCutInch.Captions[2];
      this.buLabel_0.Text = F_PerpendicularCutInch.Captions[4];
      this.buButton_15.Text = F_PerpendicularCutInch.Captions[5];
      this.buButton_2.Text = F_PerpendicularCutInch.Captions[6];
      this.buButton_3.Text = F_PerpendicularCutInch.Captions[7];
      this.tabPage_0.Text = F_PerpendicularCutInch.Captions[8];
      this.tabPage_1.Text = F_PerpendicularCutInch.Captions[9];
      this.buLabel_1.Text = F_PerpendicularCutInch.Captions[10];
      this.buLabel_12.Text = F_PerpendicularCutInch.Captions[10];
      this.buLabel_9.Text = F_PerpendicularCutInch.Captions[11];
      this.buLabel_20.Text = F_PerpendicularCutInch.Captions[11];
      this.buLabel_8.Text = F_PerpendicularCutInch.Captions[12];
      this.buLabel_19.Text = F_PerpendicularCutInch.Captions[12];
      this.buLabel_7.Text = F_PerpendicularCutInch.Captions[13];
      this.buLabel_18.Text = F_PerpendicularCutInch.Captions[13];
      this.buButton_6.Text = F_PerpendicularCutInch.Captions[14];
      this.buButton_4.Text = F_PerpendicularCutInch.Captions[14];
      this.buLabel_24.Text = F_PerpendicularCutInch.Captions[15];
      this.buLabel_21.Text = F_PerpendicularCutInch.Captions[15];
      this.buButton_16.Text = F_PerpendicularCutInch.Captions[16 /*0x10*/];
      this.buButton_17.Text = F_PerpendicularCutInch.Captions[17];
      this.buLabel_10.Text = F_PerpendicularCutInch.Captions[18];
      this.buLabel_11.Text = F_PerpendicularCutInch.Captions[19];
      this.buButton_5.Text = F_PerpendicularCutInch.Captions[20];
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
    if (control2.Name == this.buButton_8.Name | control2.Name == this.buButton_3.Name)
    {
      this.Result = DialogResult.Cancel;
      this.bool_2 = false;
      this.bool_3 = false;
      if (this.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == this.buButton_7.Name))
      return;
    this.Result = DialogResult.Cancel;
    this.WindowState = FormWindowState.Minimized;
  }

  internal void method_2(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.buButton_16.Name)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.InitialDirectory = this.pathFiles;
      saveFileDialog.Filter = "Marble Item Files (.bumarbleitem)|*.bumarbleitem";
      saveFileDialog.FilterIndex = 1;
      if (saveFileDialog.ShowDialog() == DialogResult.OK)
      {
        this.pathFiles = buFile.GetPath(saveFileDialog.FileName);
        Class39.smethod_774(this);
        Class39.smethod_337(this);
        ArrayList StringList = new ArrayList();
        for (int index = 0; index <= this.listItemsHor.Count - 1; ++index)
          StringList.AddRange((ICollection) this.listItemsHor[index].ToDefAll("Horizontal", 2, SerilizationMode.MultiLine).ToArray());
        for (int index = 0; index <= this.listItemsVer.Count - 1; ++index)
          StringList.AddRange((ICollection) this.listItemsVer[index].ToDefAll("Vertical", 2, SerilizationMode.MultiLine).ToArray());
        buFile.SaveToFile(StringList, saveFileDialog.FileName);
      }
    }
    if (control2.Name == this.buButton_17.Name)
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
    if (control2.Name == this.buButton_5.Name)
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
    if (control2.Name == this.buButton_15.Name && this.eventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0(sender, e);
    }
    if (control2.Name == this.buButton_2.Name)
    {
      Class39.smethod_774(this);
      Class39.smethod_337(this);
      Class39.smethod_402(this);
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
    if (control2.Name == this.buButton_4.Name && buString.MessageBoxQuestion(AppLanguage.SystemMessages[5]) == DialogResult.Yes)
    {
      for (int index = 0; index <= 99; ++index)
        this.marbleCutItems_1[index] = new marbleCutItems();
      this.int_1 = 0;
      Class39.smethod_613(this);
    }
    if (control2.Name == this.buButton_6.Name && buString.MessageBoxQuestion(AppLanguage.SystemMessages[5]) == DialogResult.Yes)
    {
      for (int index = 0; index <= 99; ++index)
        this.marbleCutItems_0[index] = new marbleCutItems();
      this.int_0 = 0;
      Class39.smethod_529(this);
    }
    int num1;
    if (control2.Name == this.buButton_0.Name)
    {
      buGeneral.ArrayIndexIncrease(ref this.int_0, 100, 1, 5);
      buLabel buLabel6 = this.buLabel_6;
      num1 = this.int_0 + 1;
      string str1 = num1.ToString();
      buLabel6.Text = str1;
      buLabel buLabel5 = this.buLabel_5;
      num1 = this.int_0 + 2;
      string str2 = num1.ToString();
      buLabel5.Text = str2;
      buLabel buLabel4 = this.buLabel_4;
      num1 = this.int_0 + 3;
      string str3 = num1.ToString();
      buLabel4.Text = str3;
      buLabel buLabel3 = this.buLabel_3;
      num1 = this.int_0 + 4;
      string str4 = num1.ToString();
      buLabel3.Text = str4;
      buLabel buLabel2 = this.buLabel_2;
      num1 = this.int_0 + 5;
      string str5 = num1.ToString();
      buLabel2.Text = str5;
      Class39.smethod_529(this);
    }
    if (control2.Name == this.buButton_1.Name)
    {
      buGeneral.ArrayIndexDecrease(ref this.int_0, 0, 1, 5);
      buLabel buLabel6 = this.buLabel_6;
      num1 = this.int_0 + 1;
      string str6 = num1.ToString();
      buLabel6.Text = str6;
      buLabel buLabel5 = this.buLabel_5;
      num1 = this.int_0 + 2;
      string str7 = num1.ToString();
      buLabel5.Text = str7;
      buLabel buLabel4 = this.buLabel_4;
      num1 = this.int_0 + 3;
      string str8 = num1.ToString();
      buLabel4.Text = str8;
      buLabel buLabel3 = this.buLabel_3;
      num1 = this.int_0 + 4;
      string str9 = num1.ToString();
      buLabel3.Text = str9;
      buLabel buLabel2 = this.buLabel_2;
      num1 = this.int_0 + 5;
      string str10 = num1.ToString();
      buLabel2.Text = str10;
      Class39.smethod_529(this);
    }
    if (control2.Name == this.buButton_12.Name)
    {
      this.buButton_12.Display.BackColor = Color.Green;
      this.bool_3 = true;
      this.StartPosHor = new Pnt6D(this.spn_x.Value, this.spn_y.Value, this.spn_z.Value, this.spn_a.Value, 0.0, this.spn_c.Value);
      // ISSUE: reference to a compiler-generated field
      if (this.marbleSetStartPositionHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.marbleSetStartPositionHandler_0(this.StartPosHor);
      }
    }
    if (control2.Name == this.buButton_11.Name && this.bool_3)
    {
      this.buButton_11.Display.BackColor = Color.Green;
      this.EndPosHor = new Pnt6D(this.spn_x.Value, this.spn_y.Value, this.spn_z.Value, this.spn_a.Value, 0.0, this.spn_c.Value);
      this.textBox_0.Text = buString.InchValueToString(buControlCoreClass.cVector.Length3D(this.StartPosHor, this.EndPosHor), 16 /*0x10*/);
      // ISSUE: reference to a compiler-generated field
      if (this.marbleSetStartPositionHandler_1 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.marbleSetStartPositionHandler_1(this.EndPosHor);
      }
    }
    if (control2.Name == this.buButton_14.Name)
    {
      this.buButton_14.Display.BackColor = Color.Green;
      this.bool_2 = true;
      this.StartPosVer = new Pnt6D(this.spn_x.Value, this.spn_y.Value, this.spn_z.Value, this.spn_a.Value, 0.0, this.spn_c.Value);
      // ISSUE: reference to a compiler-generated field
      if (this.marbleSetStartPositionHandler_2 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.marbleSetStartPositionHandler_2(this.StartPosVer);
      }
    }
    if (control2.Name == this.buButton_13.Name && this.bool_2)
    {
      this.buButton_13.Display.BackColor = Color.Green;
      this.EndPosVer = new Pnt6D(this.spn_x.Value, this.spn_y.Value, this.spn_z.Value, this.spn_a.Value, 0.0, this.spn_c.Value);
      this.textBox_2.Text = buString.InchValueToString(buControlCoreClass.cVector.Length3D(this.StartPosVer, this.EndPosVer), 16 /*0x10*/);
      // ISSUE: reference to a compiler-generated field
      if (this.marbleSetStartPositionHandler_1 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.marbleSetStartPositionHandler_3(this.EndPosVer);
      }
    }
    if (control2.Name == this.buButton_9.Name)
    {
      buGeneral.ArrayIndexIncrease(ref this.int_1, 100, 1, 5);
      buLabel buLabel17 = this.buLabel_17;
      num1 = this.int_1 + 1;
      string str11 = num1.ToString();
      buLabel17.Text = str11;
      buLabel buLabel16 = this.buLabel_16;
      num1 = this.int_1 + 2;
      string str12 = num1.ToString();
      buLabel16.Text = str12;
      buLabel buLabel15 = this.buLabel_15;
      num1 = this.int_1 + 3;
      string str13 = num1.ToString();
      buLabel15.Text = str13;
      buLabel buLabel14 = this.buLabel_14;
      num1 = this.int_1 + 4;
      string str14 = num1.ToString();
      buLabel14.Text = str14;
      buLabel buLabel13 = this.buLabel_13;
      num1 = this.int_1 + 5;
      string str15 = num1.ToString();
      buLabel13.Text = str15;
      Class39.smethod_613(this);
    }
    if (!(control2.Name == this.buButton_10.Name))
      return;
    buGeneral.ArrayIndexDecrease(ref this.int_1, 0, 1, 5);
    buLabel buLabel17_1 = this.buLabel_17;
    num1 = this.int_1 + 1;
    string str16 = num1.ToString();
    buLabel17_1.Text = str16;
    buLabel buLabel16_1 = this.buLabel_16;
    num1 = this.int_1 + 2;
    string str17 = num1.ToString();
    buLabel16_1.Text = str17;
    buLabel buLabel15_1 = this.buLabel_15;
    num1 = this.int_1 + 3;
    string str18 = num1.ToString();
    buLabel15_1.Text = str18;
    buLabel buLabel14_1 = this.buLabel_14;
    num1 = this.int_1 + 4;
    string str19 = num1.ToString();
    buLabel14_1.Text = str19;
    buLabel buLabel13_1 = this.buLabel_13;
    num1 = this.int_1 + 5;
    string str20 = num1.ToString();
    buLabel13_1.Text = str20;
    Class39.smethod_613(this);
  }

  internal void method_3(object object_0, double double_0)
  {
    if (this.bool_0)
      return;
    buSpin buSpin1 = new buSpin();
    buSpin buSpin2 = (buSpin) object_0;
    if (buSpin2.Aux.Explanation == "Len")
      this.marbleCutItems_0[this.int_0 + buSpin2.Aux.ValInt].Length = buSpin2.Value;
    if (buSpin2.Aux.Explanation == "Cnt")
      this.marbleCutItems_0[this.int_0 + buSpin2.Aux.ValInt].Count = (int) buSpin2.Value;
    if (buSpin2.Aux.Explanation == "SA")
      this.marbleCutItems_0[this.int_0 + buSpin2.Aux.ValInt].StartAngle = buSpin2.Value;
    if (buSpin2.Aux.Explanation == "EA")
      this.marbleCutItems_0[this.int_0 + buSpin2.Aux.ValInt].EndAngle = buSpin2.Value;
    double num1 = 0.0;
    int num2 = 0;
    for (int index = 0; index <= this.marbleCutItems_0.Length - 1; ++index)
    {
      num1 += this.marbleCutItems_0[index].Length * (double) this.marbleCutItems_0[index].Count;
      num2 += this.marbleCutItems_0[index].Count;
    }
    this.buLabel_26.Text = num1.ToString("f1");
    this.buLabel_25.Text = num2.ToString("f1");
    Class39.smethod_435(this);
  }

  internal void method_4(object sender, EventArgs e)
  {
    if (this.bool_0)
      return;
    buTextBox buTextBox1 = new buTextBox();
    buTextBox buTextBox2 = (buTextBox) sender;
    if (buTextBox2.Aux.Explanation.ToString() == "Len")
      this.marbleCutItems_0[this.int_0 + buTextBox2.Aux.ValInt].Length = buString.StringToInchValue(buTextBox2.Text, 16 /*0x10*/);
    double num1 = 0.0;
    int num2 = 0;
    for (int index = 0; index <= this.marbleCutItems_0.Length - 1; ++index)
    {
      num1 += this.marbleCutItems_0[index].Length * (double) this.marbleCutItems_0[index].Count;
      num2 += this.marbleCutItems_0[index].Count;
    }
    this.buLabel_26.Text = num1.ToString("f1");
    this.buLabel_25.Text = num2.ToString("f1");
  }

  internal void method_5(object sender, EventArgs e)
  {
    if (this.bool_0)
      return;
    buTextBox buTextBox1 = new buTextBox();
    buTextBox buTextBox2 = (buTextBox) sender;
    if (buTextBox2.Aux.Explanation.ToString() == "Len")
      this.marbleCutItems_1[this.int_1 + buTextBox2.Aux.ValInt].Length = buString.StringToInchValue(buTextBox2.Text, 16 /*0x10*/);
    double num1 = 0.0;
    int num2 = 0;
    for (int index = 0; index <= this.marbleCutItems_1.Length - 1; ++index)
    {
      num1 += this.marbleCutItems_1[index].Length * (double) this.marbleCutItems_1[index].Count;
      num2 += this.marbleCutItems_1[index].Count;
    }
    this.buLabel_23.Text = num1.ToString("f1");
    this.buLabel_22.Text = num2.ToString("f1");
  }

  internal void method_6(object object_0, double double_0)
  {
    if (this.bool_0)
      return;
    buSpin buSpin1 = new buSpin();
    buSpin buSpin2 = (buSpin) object_0;
    if (buSpin2.Aux.Explanation == "Len")
      this.marbleCutItems_1[this.int_1 + buSpin2.Aux.ValInt].Length = buSpin2.Value;
    if (buSpin2.Aux.Explanation == "Cnt")
      this.marbleCutItems_1[this.int_1 + buSpin2.Aux.ValInt].Count = (int) buSpin2.Value;
    if (buSpin2.Aux.Explanation == "SA")
      this.marbleCutItems_1[this.int_1 + buSpin2.Aux.ValInt].StartAngle = buSpin2.Value;
    if (buSpin2.Aux.Explanation == "EA")
      this.marbleCutItems_1[this.int_1 + buSpin2.Aux.ValInt].EndAngle = buSpin2.Value;
    double num1 = 0.0;
    int num2 = 0;
    for (int index = 0; index <= this.marbleCutItems_1.Length - 1; ++index)
    {
      num1 += this.marbleCutItems_1[index].Length * (double) this.marbleCutItems_1[index].Count;
      num2 += this.marbleCutItems_1[index].Count;
    }
    this.buLabel_23.Text = num1.ToString("f1");
    this.buLabel_22.Text = num2.ToString("f1");
    Class39.smethod_435(this);
  }

  internal void method_7(object sender, KeyEventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (!(e.KeyCode == Keys.Return | e.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKey(this.tabPage_0.Controls, result, e.Shift);
  }

  internal void method_8(object sender, KeyEventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (!(e.KeyCode == Keys.Return | e.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKey(this.tabPage_1.Controls, result, e.Shift);
  }

  private void textBox_2_Click(object sender, EventArgs e)
  {
    try
    {
      if (!AppBool.TouchPad)
        return;
      if (sender.GetType() == typeof (buSpin))
      {
        buSpin buSpin = new buSpin();
        buControlCommands.ShowKeyPad((Form) this, (Control) sender);
      }
      if (!(sender.GetType() == typeof (TextBox)))
        return;
      TextBox textBox = new TextBox();
      buControlCommands.ShowKeyPad((Form) this, (Control) sender);
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  internal void method_9(object sender, EventArgs e)
  {
    if (!this.AskTabChangeQuestions)
      return;
    // ISSUE: reference to a compiler-generated field
    if (this.buTab_0.SelectedIndex == 0 && this.marblePerpendicularModeEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.marblePerpendicularModeEventHandler_0(this.buTab_0.SelectedIndex);
    }
    // ISSUE: reference to a compiler-generated field
    if (this.buTab_0.SelectedIndex != 1 || this.marblePerpendicularModeEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.marblePerpendicularModeEventHandler_0(this.buTab_0.SelectedIndex);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
