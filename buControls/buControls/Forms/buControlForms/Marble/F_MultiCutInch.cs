// Decompiled with JetBrains decompiler
// Type: buControls.Forms.buControlForms.Marble.F_MultiCutInch
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

public class F_MultiCutInch : Form
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
  public List<marbleCutItems> listItems = new List<marbleCutItems>();
  internal marbleCutItems[] marbleCutItems_0 = new marbleCutItems[100];
  internal int int_0 = 0;
  internal bool bool_0 = false;
  internal bool bool_1 = false;
  private bool bool_2 = false;
  private Pnt6D pnt6D_0 = new Pnt6D();
  private Pnt6D pnt6D_1 = new Pnt6D();
  private IContainer icontainer_0 = (IContainer) null;
  internal buGround buGround_0;
  internal PictureBox pictureBox_0;
  internal buLabel buLabel_0;
  internal buButton buButton_0;
  internal buButton buButton_1;
  internal buButton buButton_2;
  internal buButton buButton_3;
  internal PictureBox pictureBox_1;
  internal PictureBox pictureBox_2;
  internal PictureBox pictureBox_3;
  internal PictureBox pictureBox_4;
  internal buLabel buLabel_1;
  internal buLabel buLabel_2;
  internal buLabel buLabel_3;
  internal buLabel buLabel_4;
  internal buLabel buLabel_5;
  internal buLabel buLabel_6;
  internal buLabel buLabel_7;
  internal buLabel buLabel_8;
  internal buLabel buLabel_9;
  internal buButton buButton_4;
  internal buButton buButton_5;
  internal buButton buButton_6;
  internal buButton buButton_7;
  internal buSeparator buSeparator_0;
  internal buButton buButton_8;
  internal buButton buButton_9;
  public buSpin spn_c;
  public buSpin spn_a;
  public buSpin spn_z;
  public buSpin spn_y;
  public buSpin spn_x;
  internal buButton buButton_10;
  public buSpin spn_itemEA5;
  public buSpin spn_itemSA5;
  public buSpin spn_itemcount5;
  public buSpin spn_itemEA4;
  public buSpin spn_itemSA4;
  public buSpin spn_itemcount4;
  public buSpin spn_itemEA3;
  public buSpin spn_itemSA3;
  public buSpin spn_itemcount3;
  public buSpin spn_itemEA2;
  public buSpin spn_itemSA2;
  public buSpin spn_itemcount2;
  public buSpin spn_itemEA1;
  public buSpin spn_itemSA1;
  public buSpin spn_itemcount1;
  internal buButton buButton_11;
  internal buButton buButton_12;
  internal buSeparator buSeparator_1;
  internal buButton buButton_13;
  internal buButton buButton_14;
  internal buSeparator buSeparator_2;
  internal buButton buButton_15;
  internal buLabel buLabel_10;
  internal buLabel buLabel_11;
  internal buLabel buLabel_12;
  internal buLabel buLabel_13;
  internal TextBox textBox_0;
  internal TextBox textBox_1;
  internal buTextBox buTextBox_0;
  internal buTextBox buTextBox_1;
  internal buTextBox buTextBox_2;
  internal buTextBox buTextBox_3;
  internal buTextBox buTextBox_4;

  public F_MultiCutInch()
  {
    Class39.smethod_584(this);
    this.textBox_1.Click += new EventHandler(this.textBox_0_Click);
    this.spn_itemcount1.Click += new EventHandler(this.textBox_0_Click);
    this.spn_itemcount2.Click += new EventHandler(this.textBox_0_Click);
    this.spn_itemcount3.Click += new EventHandler(this.textBox_0_Click);
    this.spn_itemcount4.Click += new EventHandler(this.textBox_0_Click);
    this.spn_itemcount5.Click += new EventHandler(this.textBox_0_Click);
    this.spn_itemEA1.Click += new EventHandler(this.textBox_0_Click);
    this.spn_itemEA2.Click += new EventHandler(this.textBox_0_Click);
    this.spn_itemEA3.Click += new EventHandler(this.textBox_0_Click);
    this.spn_itemEA4.Click += new EventHandler(this.textBox_0_Click);
    this.spn_itemEA5.Click += new EventHandler(this.textBox_0_Click);
    this.buTextBox_0.Click += new EventHandler(this.textBox_0_Click);
    this.buTextBox_4.Click += new EventHandler(this.textBox_0_Click);
    this.buTextBox_3.Click += new EventHandler(this.textBox_0_Click);
    this.buTextBox_2.Click += new EventHandler(this.textBox_0_Click);
    this.buTextBox_1.Click += new EventHandler(this.textBox_0_Click);
    this.spn_itemSA1.Click += new EventHandler(this.textBox_0_Click);
    this.spn_itemSA2.Click += new EventHandler(this.textBox_0_Click);
    this.spn_itemSA3.Click += new EventHandler(this.textBox_0_Click);
    this.spn_itemSA4.Click += new EventHandler(this.textBox_0_Click);
    this.spn_itemSA5.Click += new EventHandler(this.textBox_0_Click);
    this.textBox_0.Click += new EventHandler(this.textBox_0_Click);
  }

  public event MarblePerpendicularModeEventHandler TabChanged;

  public event MarbleSetStartPositionHandler SetStartPosition;

  public event MarbleSetStartPositionHandler SetEndPosition;

  public event EventHandler ShowJogPage;

  public void Init()
  {
    try
    {
      this.bool_1 = false;
      this.bool_2 = false;
      this.buButton_9.Display.BackColor = Color.Red;
      this.buButton_8.Display.BackColor = Color.Red;
      for (int index = 0; index <= 99; ++index)
        this.marbleCutItems_0[index] = new marbleCutItems();
      for (int index = 0; index <= this.listItems.Count - 1; ++index)
        this.marbleCutItems_0[index] = new marbleCutItems(this.listItems[index]);
      if (this.VerticalCut)
      {
        this.buButton_12.Display.BackColor = Color.Green;
        this.buButton_12.ButtonOverDisplay.BackColor = Color.Green;
        this.buButton_12.ButtonDownDisplay.BackColor = Color.Green;
        this.buButton_11.Display.BackColor = Color.Red;
        this.buButton_11.ButtonOverDisplay.BackColor = Color.Red;
        this.buButton_11.ButtonDownDisplay.BackColor = Color.Red;
      }
      else
      {
        this.buButton_12.Display.BackColor = Color.Red;
        this.buButton_12.ButtonOverDisplay.BackColor = Color.Red;
        this.buButton_12.ButtonDownDisplay.BackColor = Color.Red;
        this.buButton_11.Display.BackColor = Color.Green;
        this.buButton_11.ButtonOverDisplay.BackColor = Color.Green;
        this.buButton_11.ButtonDownDisplay.BackColor = Color.Green;
      }
      this.textBox_1.Text = buString.InchValueToString(this.varOperations.TargetZ, 16 /*0x10*/);
      this.textBox_0.Text = buString.InchValueToString(this.varOperations.CutLength, 16 /*0x10*/);
      this.spn_x.Value = this.varOperations.AxisValues.X;
      this.spn_y.Value = this.varOperations.AxisValues.Y;
      this.spn_z.Value = this.varOperations.AxisValues.Z;
      this.spn_a.Value = this.varOperations.AxisValues.A;
      this.spn_c.Value = this.varOperations.AxisValues.C;
      Class39.smethod_627(this);
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
      if (F_MultiCutInch.Captions.Count <= 18)
        return;
      this.buGround_0.Text = F_MultiCutInch.Captions[0];
      this.buButton_9.Text = F_MultiCutInch.Captions[1];
      this.buButton_8.Text = F_MultiCutInch.Captions[2];
      this.buLabel_0.Text = F_MultiCutInch.Captions[4];
      this.buButton_10.Text = F_MultiCutInch.Captions[5];
      this.buButton_2.Text = F_MultiCutInch.Captions[6];
      this.buButton_3.Text = F_MultiCutInch.Captions[7];
      this.buButton_11.Text = F_MultiCutInch.Captions[8];
      this.buButton_12.Text = F_MultiCutInch.Captions[9];
      this.buLabel_1.Text = F_MultiCutInch.Captions[10];
      this.buLabel_9.Text = F_MultiCutInch.Captions[11];
      this.buLabel_8.Text = F_MultiCutInch.Captions[12];
      this.buLabel_7.Text = F_MultiCutInch.Captions[13];
      this.buButton_15.Text = F_MultiCutInch.Captions[14];
      this.buLabel_10.Text = F_MultiCutInch.Captions[15];
      this.buButton_13.Text = F_MultiCutInch.Captions[16 /*0x10*/];
      this.buButton_14.Text = F_MultiCutInch.Captions[17];
      this.buButton_7.Text = F_MultiCutInch.Captions[18];
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
    if (control2.Name == this.buButton_5.Name | control2.Name == this.buButton_3.Name)
    {
      this.Result = DialogResult.Cancel;
      this.bool_2 = false;
      if (this.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == this.buButton_4.Name))
      return;
    this.Result = DialogResult.Cancel;
    this.WindowState = FormWindowState.Minimized;
  }

  internal void method_2(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.buButton_13.Name)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.InitialDirectory = this.pathFiles;
      saveFileDialog.Filter = "Marble Item Files (.bumarbleitem)|*.bumarbleitem";
      saveFileDialog.FilterIndex = 1;
      if (saveFileDialog.ShowDialog() == DialogResult.OK)
      {
        this.pathFiles = buFile.GetPath(saveFileDialog.FileName);
        Class39.smethod_648(this);
        ArrayList StringList = new ArrayList();
        for (int index = 0; index <= this.listItems.Count - 1; ++index)
          StringList.AddRange((ICollection) this.listItems[index].ToDefAll("", 2, SerilizationMode.MultiLine).ToArray());
        buFile.SaveToFile(StringList, saveFileDialog.FileName);
      }
    }
    if (control2.Name == this.buButton_14.Name)
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
    if (control2.Name == this.buButton_15.Name)
    {
      for (int index = 0; index <= 99; ++index)
        this.marbleCutItems_0[index] = new marbleCutItems();
      this.spn_itemcount1.Value = 0.0;
      this.spn_itemcount2.Value = 0.0;
      this.spn_itemcount3.Value = 0.0;
      this.spn_itemcount4.Value = 0.0;
      this.spn_itemcount5.Value = 0.0;
      this.spn_itemEA1.Value = 0.0;
      this.spn_itemEA2.Value = 0.0;
      this.spn_itemEA3.Value = 0.0;
      this.spn_itemEA4.Value = 0.0;
      this.spn_itemEA5.Value = 0.0;
      this.spn_itemSA1.Value = 0.0;
      this.spn_itemSA2.Value = 0.0;
      this.spn_itemSA3.Value = 0.0;
      this.spn_itemSA4.Value = 0.0;
      this.spn_itemSA5.Value = 0.0;
      this.buTextBox_0.Text = "0";
      this.buTextBox_4.Text = "0";
      this.buTextBox_3.Text = "0";
      this.buTextBox_2.Text = "0";
      this.buTextBox_1.Text = "0";
    }
    if (control2.Name == this.buButton_11.Name)
    {
      this.buButton_12.Display.BackColor = Color.Red;
      this.buButton_12.ButtonOverDisplay.BackColor = Color.Red;
      this.buButton_12.ButtonDownDisplay.BackColor = Color.Red;
      this.buButton_11.Display.BackColor = Color.Green;
      this.buButton_11.ButtonOverDisplay.BackColor = Color.Green;
      this.buButton_11.ButtonDownDisplay.BackColor = Color.Green;
      this.VerticalCut = false;
      // ISSUE: reference to a compiler-generated field
      if (this.AskTabChangeQuestions && this.marblePerpendicularModeEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.marblePerpendicularModeEventHandler_0(0);
      }
    }
    if (control2.Name == this.buButton_12.Name)
    {
      this.buButton_12.Display.BackColor = Color.Green;
      this.buButton_12.ButtonOverDisplay.BackColor = Color.Green;
      this.buButton_12.ButtonDownDisplay.BackColor = Color.Green;
      this.buButton_11.Display.BackColor = Color.Red;
      this.buButton_11.ButtonOverDisplay.BackColor = Color.Red;
      this.buButton_11.ButtonDownDisplay.BackColor = Color.Red;
      this.VerticalCut = true;
      // ISSUE: reference to a compiler-generated field
      if (this.AskTabChangeQuestions && this.marblePerpendicularModeEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.marblePerpendicularModeEventHandler_0(1);
      }
    }
    if (control2.Name == this.buButton_7.Name)
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
    if (control2.Name == this.buButton_10.Name && this.eventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0(sender, e);
    }
    if (control2.Name == this.buButton_2.Name)
    {
      Class39.smethod_648(this);
      if (Math.Abs(this.varOperations.AxisValues.C) > 45.0 & Math.Abs(this.varOperations.AxisValues.C) < 135.0 && !this.VerticalCut && buString.MessageBoxQuestion(buMarbleCalc.LangMarbleMessage[2]) == DialogResult.Yes)
        this.VerticalCut = true;
      if (Math.Abs(this.varOperations.AxisValues.C) > 225.0 & Math.Abs(this.varOperations.AxisValues.C) < 315.0 && !this.VerticalCut && buString.MessageBoxQuestion(buMarbleCalc.LangMarbleMessage[2]) == DialogResult.Yes)
        this.VerticalCut = true;
      Class39.smethod_361(this);
      if (this.varOperations.TargetZ >= this.varOperations.MaterialThickness)
      {
        buString.MessageBoxWarning(buMarbleCalc.LangMarbleMessage[3]);
        return;
      }
      Pnt3D EndPnt = new Pnt3D();
      if (this.bool_2)
      {
        this.varOperations.AxisValues.X = this.pnt6D_0.X;
        this.varOperations.AxisValues.Y = this.pnt6D_0.Y;
      }
      buControlCoreClass.cVector.LineWithLengthAndAngle(new Pnt3D(this.varOperations.AxisValues.X, this.varOperations.AxisValues.Y, this.varOperations.AxisValues.Z), this.varOperations.CutLength, this.varOperations.AxisValues.C, new WorkPlane(), ref EndPnt);
      this.Result = DialogResult.OK;
      this.bool_2 = false;
      if (this.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.buButton_6.Name && buString.MessageBoxQuestion(AppLanguage.SystemMessages[0]) == DialogResult.Yes)
    {
      for (int index = 0; index <= 99; ++index)
        this.marbleCutItems_0[index] = new marbleCutItems();
      this.int_0 = 0;
      Class39.smethod_627(this);
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
      Class39.smethod_627(this);
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
      Class39.smethod_627(this);
    }
    if (control2.Name == this.buButton_9.Name)
    {
      this.buButton_9.Display.BackColor = Color.Green;
      this.bool_2 = true;
      this.pnt6D_0 = new Pnt6D(this.spn_x.Value, this.spn_y.Value, this.spn_z.Value, this.spn_a.Value, 0.0, this.spn_c.Value);
      // ISSUE: reference to a compiler-generated field
      if (this.marbleSetStartPositionHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.marbleSetStartPositionHandler_0(this.pnt6D_0);
      }
    }
    if (!(control2.Name == this.buButton_8.Name) || !this.bool_2)
      return;
    this.buButton_8.Display.BackColor = Color.Green;
    this.pnt6D_1 = new Pnt6D(this.spn_x.Value, this.spn_y.Value, this.spn_z.Value, this.spn_a.Value, 0.0, this.spn_c.Value);
    this.textBox_0.Text = buString.InchValueToString(buControlCoreClass.cVector.Length3D(this.pnt6D_0, this.pnt6D_1), 16 /*0x10*/);
    // ISSUE: reference to a compiler-generated field
    if (this.marbleSetStartPositionHandler_1 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.marbleSetStartPositionHandler_1(this.pnt6D_1);
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
    this.buLabel_12.Text = num1.ToString("f1");
    this.buLabel_11.Text = num2.ToString("f1");
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
    this.buLabel_12.Text = num1.ToString("f1");
    this.buLabel_11.Text = num2.ToString("f1");
  }

  internal void method_5(object sender, KeyEventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (!(e.KeyCode == Keys.Return | e.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKey(this.buGround_0.Controls, result, e.Shift);
  }

  private void textBox_0_Click(object sender, EventArgs e)
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

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
