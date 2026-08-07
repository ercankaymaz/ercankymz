// Decompiled with JetBrains decompiler
// Type: buControls.ClassViewer.buClassViewer
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.DialogBox;
using buControls.Forms.WinControlForms.ClassForm;
using buCore;
using ns7;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.ClassViewer;

public class buClassViewer : UserControl
{
  public int RowHeight = 30;
  public int RowSpace = 4;
  public int DecimalPlace = 3;
  public int CaptionWidthOffset = 0;
  public Font FontCaptions = new Font("Times New Roman", 12f);
  public Font FontValues = new Font("Times New Roman", 12f);
  public int ValueWidth = 250;
  public bool ColorComboBoxMode = false;
  public bool ShowOkButton = false;
  public bool ShowCancelButton = false;
  public string OkButtonText = "Ok";
  public string CancelButtonText = "Cancel";
  public object ClassObject = (object) null;
  public Form OwnerForm = (Form) null;
  public TouchPadType TouchPayStyle = TouchPadType.buControlStyleBasic;
  public List<string> ParCaptions = new List<string>();
  public List<Control> ControlList = new List<Control>();
  private Label label_0 = new Label();
  private Button button_0 = new Button();
  private Button button_1 = new Button();
  private setColorComboControl setColorComboControl_0 = new setColorComboControl();
  private setDateTimeControl setDateTimeControl_0 = new setDateTimeControl();
  internal setLabelControl setLabelControl_0 = new setLabelControl();
  private setCheckBoxControl setCheckBoxControl_0 = new setCheckBoxControl();
  private setLabelControl setLabelControl_1 = new setLabelControl();
  private setLabelControl setLabelControl_2 = new setLabelControl();
  private setNumericUpDownControl setNumericUpDownControl_0 = new setNumericUpDownControl();
  private setComboBoxControl setComboBoxControl_0 = new setComboBoxControl();
  private setTextBoxControl setTextBoxControl_0 = new setTextBoxControl();
  private PictureBox pictureBox_0 = new PictureBox();
  private IContainer icontainer_0 = (IContainer) null;
  internal Panel panel_0;

  public buClassViewer() => Class39.smethod_171(this);

  public event ClassViewerEventHandler ValueChanged;

  public event EventHandler OkButtonClicked;

  public event EventHandler CancelButtonClicked;

  public void Init()
  {
    List<cParameter> Vars = new List<cParameter>();
    List<string> Captions = new List<string>();
    buSerilization.GetClassVariables(this.ClassObject, ref Vars);
    buSerilization.GetCaptionsOfClass(this.ClassObject, ref Captions);
    this.ControlList.Clear();
    this.ControlList = new List<Control>();
    int num = 0;
    this.panel_0.Controls.Clear();
    for (int index1 = 0; index1 <= Vars.Count - 1; ++index1)
    {
      System.Type type = Vars[index1].Value.GetType();
      this.label_0 = new Label();
      this.label_0.BorderStyle = BorderStyle.FixedSingle;
      this.label_0.Text = Vars[index1].Name;
      if (Captions.Count > 0 & index1 <= Captions.Count - 1)
        this.label_0.Text = Captions[index1];
      if (this.ParCaptions.Count > 0 & index1 <= this.ParCaptions.Count - 1)
        this.label_0.Text = this.ParCaptions[index1];
      this.label_0.Font = this.FontCaptions;
      this.label_0.Size = new Size(this.Width - this.ValueWidth - this.RowSpace * 9 + this.CaptionWidthOffset, this.RowHeight);
      this.label_0.Location = new Point(this.RowSpace, this.RowSpace + num * (this.RowHeight + this.RowSpace));
      if (type == typeof (double) | type == typeof (float))
      {
        Decimal result = 0M;
        Decimal.TryParse(Vars[index1].ValueAsString, out result);
        this.setNumericUpDownControl_0 = new setNumericUpDownControl();
        ref setNumericUpDownControl local = ref this.setNumericUpDownControl_0;
        string name = Vars[index1].Name;
        int decimalPlace = this.DecimalPlace;
        Class39.smethod_565(result, name, ref local, decimalPlace, this);
        this.setNumericUpDownControl_0.Location = new Point(this.label_0.Left + this.label_0.Width + this.RowSpace, this.RowSpace + num * (this.RowHeight + this.RowSpace));
        this.panel_0.Controls.Add((Control) this.label_0);
        this.panel_0.Controls.Add((Control) this.setNumericUpDownControl_0);
        this.ControlList.Add((Control) this.setNumericUpDownControl_0);
        ++num;
      }
      if (type == typeof (int) | type == typeof (byte) | type == typeof (long))
      {
        Decimal result = 0M;
        Decimal.TryParse(Vars[index1].ValueAsString, out result);
        this.setNumericUpDownControl_0 = new setNumericUpDownControl();
        ref setNumericUpDownControl local = ref this.setNumericUpDownControl_0;
        string name = Vars[index1].Name;
        Class39.smethod_565(result, name, ref local, 0, this);
        this.setNumericUpDownControl_0.Location = new Point(this.label_0.Left + this.label_0.Width + this.RowSpace, this.RowSpace + num * (this.RowHeight + this.RowSpace));
        this.panel_0.Controls.Add((Control) this.label_0);
        this.panel_0.Controls.Add((Control) this.setNumericUpDownControl_0);
        this.ControlList.Add((Control) this.setNumericUpDownControl_0);
        ++num;
      }
      if (type == typeof (bool))
      {
        bool result = false;
        bool.TryParse(Vars[index1].ValueAsString, out result);
        this.setCheckBoxControl_0 = new setCheckBoxControl();
        ref setCheckBoxControl local = ref this.setCheckBoxControl_0;
        Class39.smethod_74(Vars[index1].Name, ref local, result, this);
        this.setCheckBoxControl_0.Location = new Point(this.label_0.Left + this.label_0.Width + this.RowSpace, this.RowSpace + num * (this.RowHeight + this.RowSpace));
        this.panel_0.Controls.Add((Control) this.label_0);
        this.panel_0.Controls.Add((Control) this.setCheckBoxControl_0);
        this.ControlList.Add((Control) this.setCheckBoxControl_0);
        ++num;
      }
      if (type == typeof (string))
      {
        bool result = false;
        bool.TryParse(Vars[index1].ValueAsString, out result);
        this.setTextBoxControl_0 = new setTextBoxControl();
        ref setTextBoxControl local = ref this.setTextBoxControl_0;
        string valueAsString = Vars[index1].ValueAsString;
        string name = Vars[index1].Name;
        Class39.smethod_221(valueAsString, ref local, this, name);
        this.setTextBoxControl_0.Location = new Point(this.label_0.Left + this.label_0.Width + this.RowSpace, this.RowSpace + num * (this.RowHeight + this.RowSpace));
        this.panel_0.Controls.Add((Control) this.label_0);
        this.panel_0.Controls.Add((Control) this.setTextBoxControl_0);
        this.ControlList.Add((Control) this.setTextBoxControl_0);
        ++num;
      }
      if (type.IsEnum)
      {
        bool result = false;
        bool.TryParse(Vars[index1].ValueAsString, out result);
        ArrayList arrayList_0 = new ArrayList();
        Array values = Enum.GetValues(type);
        for (int index2 = 0; index2 <= values.Length - 1; ++index2)
          arrayList_0.Add(values.GetValue(index2));
        this.setComboBoxControl_0 = new setComboBoxControl();
        ref setComboBoxControl local = ref this.setComboBoxControl_0;
        string string_1 = Vars[index1].Value.ToString();
        Class39.smethod_58(Vars[index1].Name, this, arrayList_0, string_1, ref local);
        this.setComboBoxControl_0.Location = new Point(this.label_0.Left + this.label_0.Width + this.RowSpace, this.RowSpace + num * (this.RowHeight + this.RowSpace));
        this.panel_0.Controls.Add((Control) this.label_0);
        this.panel_0.Controls.Add((Control) this.setComboBoxControl_0);
        this.ControlList.Add((Control) this.setComboBoxControl_0);
        ++num;
      }
      if (type == typeof (float[]))
      {
        this.setTextBoxControl_0 = new setTextBoxControl();
        string string_0 = "";
        float[] numArray = (float[]) Vars[index1].Value;
        for (int index3 = 0; index3 <= numArray.Length - 1; ++index3)
          string_0 = index3 != 0 ? $"{string_0};{numArray[index3].ToString()}" : numArray[index3].ToString();
        ref setTextBoxControl local = ref this.setTextBoxControl_0;
        string name = Vars[index1].Name;
        Class39.smethod_221(string_0, ref local, this, name);
        this.setTextBoxControl_0.Location = new Point(this.label_0.Left + this.label_0.Width + this.RowSpace, this.RowSpace + num * (this.RowHeight + this.RowSpace));
        this.panel_0.Controls.Add((Control) this.label_0);
        this.panel_0.Controls.Add((Control) this.setTextBoxControl_0);
        this.ControlList.Add((Control) this.setTextBoxControl_0);
        ++num;
      }
      if (type == typeof (double[]))
      {
        this.setTextBoxControl_0 = new setTextBoxControl();
        string string_0 = "";
        double[] numArray = (double[]) Vars[index1].Value;
        for (int index4 = 0; index4 <= numArray.Length - 1; ++index4)
          string_0 = index4 != 0 ? $"{string_0};{numArray[index4].ToString()}" : numArray[index4].ToString();
        ref setTextBoxControl local = ref this.setTextBoxControl_0;
        string name = Vars[index1].Name;
        Class39.smethod_221(string_0, ref local, this, name);
        this.setTextBoxControl_0.Location = new Point(this.label_0.Left + this.label_0.Width + this.RowSpace, this.RowSpace + num * (this.RowHeight + this.RowSpace));
        this.panel_0.Controls.Add((Control) this.label_0);
        this.panel_0.Controls.Add((Control) this.setTextBoxControl_0);
        this.ControlList.Add((Control) this.setTextBoxControl_0);
        ++num;
      }
      if (type == typeof (int[]))
      {
        this.setTextBoxControl_0 = new setTextBoxControl();
        string string_0 = "";
        int[] numArray = (int[]) Vars[index1].Value;
        for (int index5 = 0; index5 <= numArray.Length - 1; ++index5)
          string_0 = index5 != 0 ? $"{string_0};{numArray[index5].ToString()}" : numArray[index5].ToString();
        ref setTextBoxControl local = ref this.setTextBoxControl_0;
        string name = Vars[index1].Name;
        Class39.smethod_221(string_0, ref local, this, name);
        this.setTextBoxControl_0.Location = new Point(this.label_0.Left + this.label_0.Width + this.RowSpace, this.RowSpace + num * (this.RowHeight + this.RowSpace));
        this.panel_0.Controls.Add((Control) this.label_0);
        this.panel_0.Controls.Add((Control) this.setTextBoxControl_0);
        this.ControlList.Add((Control) this.setTextBoxControl_0);
        ++num;
      }
      if (type == typeof (bool[]))
      {
        this.setTextBoxControl_0 = new setTextBoxControl();
        string string_0 = "";
        bool[] flagArray = (bool[]) Vars[index1].Value;
        for (int index6 = 0; index6 <= flagArray.Length - 1; ++index6)
          string_0 = index6 != 0 ? $"{string_0};{flagArray[index6].ToString()}" : flagArray[index6].ToString();
        ref setTextBoxControl local = ref this.setTextBoxControl_0;
        string name = Vars[index1].Name;
        Class39.smethod_221(string_0, ref local, this, name);
        this.setTextBoxControl_0.Location = new Point(this.label_0.Left + this.label_0.Width + this.RowSpace, this.RowSpace + num * (this.RowHeight + this.RowSpace));
        this.panel_0.Controls.Add((Control) this.label_0);
        this.panel_0.Controls.Add((Control) this.setTextBoxControl_0);
        this.ControlList.Add((Control) this.setTextBoxControl_0);
        ++num;
      }
      if (type == typeof (ArrayList))
      {
        this.setTextBoxControl_0 = new setTextBoxControl();
        string string_0 = "";
        ArrayList arrayList = (ArrayList) Vars[index1].Value;
        for (int index7 = 0; index7 <= arrayList.Count - 1; ++index7)
          string_0 = index7 != 0 ? string_0 + Environment.NewLine + arrayList[index7].ToString() : arrayList[index7].ToString();
        ref setTextBoxControl local = ref this.setTextBoxControl_0;
        string name = Vars[index1].Name;
        Class39.smethod_221(string_0, ref local, this, name);
        this.setTextBoxControl_0.Height = this.RowHeight * 3 + this.RowSpace * 2;
        this.setTextBoxControl_0.Multiline = true;
        this.setTextBoxControl_0.ScrollBars = ScrollBars.Both;
        this.setTextBoxControl_0.Location = new Point(this.label_0.Left + this.label_0.Width + this.RowSpace, this.RowSpace + num * (this.RowHeight + this.RowSpace));
        this.panel_0.Controls.Add((Control) this.label_0);
        this.panel_0.Controls.Add((Control) this.setTextBoxControl_0);
        this.ControlList.Add((Control) this.setTextBoxControl_0);
        num = num + 1 + 1 + 1;
      }
      if (type == typeof (Pnt3D))
      {
        Pnt3D pnt3D1 = new Pnt3D();
        Pnt3D pnt3D2 = (Pnt3D) Vars[index1].Value;
        this.setLabelControl_0 = new setLabelControl();
        ref setLabelControl local = ref this.setLabelControl_0;
        string string_1 = pnt3D2.ToString();
        Class39.smethod_293(this.setLabelControl_0.BackColor, Vars[index1].Name, ref local, this, string_1);
        this.setLabelControl_0.DoubleClick += new EventHandler(this.setLabelControl_0_DoubleClick);
        this.setLabelControl_0.Location = new Point(this.label_0.Left + this.label_0.Width + this.RowSpace, this.RowSpace + num * (this.RowHeight + this.RowSpace));
        this.setLabelControl_0.EditValue = Vars[index1].Value;
        this.panel_0.Controls.Add((Control) this.label_0);
        this.panel_0.Controls.Add((Control) this.setLabelControl_0);
        this.ControlList.Add((Control) this.setLabelControl_0);
        ++num;
      }
      if (type == typeof (Pnt2D))
      {
        Pnt2D pnt2D1 = new Pnt2D();
        Pnt2D pnt2D2 = (Pnt2D) Vars[index1].Value;
        this.setLabelControl_0 = new setLabelControl();
        ref setLabelControl local = ref this.setLabelControl_0;
        string string_1 = pnt2D2.ToString();
        Class39.smethod_293(this.setLabelControl_0.BackColor, Vars[index1].Name, ref local, this, string_1);
        this.setLabelControl_0.DoubleClick += new EventHandler(this.setLabelControl_0_DoubleClick);
        this.setLabelControl_0.Location = new Point(this.label_0.Left + this.label_0.Width + this.RowSpace, this.RowSpace + num * (this.RowHeight + this.RowSpace));
        this.setLabelControl_0.EditValue = Vars[index1].Value;
        this.panel_0.Controls.Add((Control) this.label_0);
        this.panel_0.Controls.Add((Control) this.setLabelControl_0);
        this.ControlList.Add((Control) this.setLabelControl_0);
        ++num;
      }
      if (type == typeof (Point))
      {
        Point point = new Point();
        Point S = (Point) Vars[index1].Value;
        this.setLabelControl_0 = new setLabelControl();
        ref setLabelControl local = ref this.setLabelControl_0;
        string string_1 = buConversion.PointToString(S);
        Class39.smethod_293(this.setLabelControl_0.BackColor, Vars[index1].Name, ref local, this, string_1);
        this.setLabelControl_0.DoubleClick += new EventHandler(this.setLabelControl_0_DoubleClick);
        this.setLabelControl_0.Location = new Point(this.label_0.Left + this.label_0.Width + this.RowSpace, this.RowSpace + num * (this.RowHeight + this.RowSpace));
        this.setLabelControl_0.EditValue = Vars[index1].Value;
        this.panel_0.Controls.Add((Control) this.label_0);
        this.panel_0.Controls.Add((Control) this.setLabelControl_0);
        this.ControlList.Add((Control) this.setLabelControl_0);
        ++num;
      }
      if (type == typeof (PointF))
      {
        PointF pointF = new PointF();
        PointF S = (PointF) Vars[index1].Value;
        this.setLabelControl_0 = new setLabelControl();
        ref setLabelControl local = ref this.setLabelControl_0;
        string string_1 = buConversion.PointFToString(S);
        Class39.smethod_293(this.setLabelControl_0.BackColor, Vars[index1].Name, ref local, this, string_1);
        this.setLabelControl_0.DoubleClick += new EventHandler(this.setLabelControl_0_DoubleClick);
        this.setLabelControl_0.Location = new Point(this.label_0.Left + this.label_0.Width + this.RowSpace, this.RowSpace + num * (this.RowHeight + this.RowSpace));
        this.setLabelControl_0.EditValue = Vars[index1].Value;
        this.panel_0.Controls.Add((Control) this.label_0);
        this.panel_0.Controls.Add((Control) this.setLabelControl_0);
        this.ControlList.Add((Control) this.setLabelControl_0);
        ++num;
      }
      if (type == typeof (Size))
      {
        Size size = new Size();
        Size S = (Size) Vars[index1].Value;
        this.setLabelControl_0 = new setLabelControl();
        ref setLabelControl local = ref this.setLabelControl_0;
        string string_1 = buConversion.SizeToString(S);
        Class39.smethod_293(this.setLabelControl_0.BackColor, Vars[index1].Name, ref local, this, string_1);
        this.setLabelControl_0.DoubleClick += new EventHandler(this.setLabelControl_0_DoubleClick);
        this.setLabelControl_0.Location = new Point(this.label_0.Left + this.label_0.Width + this.RowSpace, this.RowSpace + num * (this.RowHeight + this.RowSpace));
        this.setLabelControl_0.EditValue = Vars[index1].Value;
        this.panel_0.Controls.Add((Control) this.label_0);
        this.panel_0.Controls.Add((Control) this.setLabelControl_0);
        this.ControlList.Add((Control) this.setLabelControl_0);
        ++num;
      }
      if (type == typeof (SizeF))
      {
        SizeF sizeF = new SizeF();
        SizeF S = (SizeF) Vars[index1].Value;
        this.setLabelControl_0 = new setLabelControl();
        ref setLabelControl local = ref this.setLabelControl_0;
        string string_1 = buConversion.SizeFToString(S);
        Class39.smethod_293(this.setLabelControl_0.BackColor, Vars[index1].Name, ref local, this, string_1);
        this.setLabelControl_0.DoubleClick += new EventHandler(this.setLabelControl_0_DoubleClick);
        this.setLabelControl_0.Location = new Point(this.label_0.Left + this.label_0.Width + this.RowSpace, this.RowSpace + num * (this.RowHeight + this.RowSpace));
        this.setLabelControl_0.EditValue = Vars[index1].Value;
        this.panel_0.Controls.Add((Control) this.label_0);
        this.panel_0.Controls.Add((Control) this.setLabelControl_0);
        this.ControlList.Add((Control) this.setLabelControl_0);
        ++num;
      }
      if (type == typeof (Color))
      {
        bool result = false;
        bool.TryParse(Vars[index1].ValueAsString, out result);
        if (!this.ColorComboBoxMode)
        {
          this.setLabelControl_1 = new setLabelControl();
          ref setLabelControl local1 = ref this.setLabelControl_1;
          KnownColor knownColor = ((Color) Vars[index1].Value).ToKnownColor();
          ref setLabelControl local2 = ref local1;
          string string_1 = knownColor.ToString();
          string name = Vars[index1].Name;
          Class39.smethod_293((Color) Vars[index1].Value, name, ref local2, this, string_1);
          if ((Color) Vars[index1].Value == Color.Black)
            this.setLabelControl_1.ForeColor = buImage.InvertColor((Color) Vars[index1].Value);
          else
            this.setLabelControl_1.ForeColor = Color.Black;
          this.setLabelControl_1.Location = new Point(this.label_0.Left + this.label_0.Width + this.RowSpace, this.RowSpace + num * (this.RowHeight + this.RowSpace));
          this.setLabelControl_1.Click += new EventHandler(this.setLabelControl_1_Click);
          this.panel_0.Controls.Add((Control) this.label_0);
          this.panel_0.Controls.Add((Control) this.setLabelControl_1);
          this.ControlList.Add((Control) this.setLabelControl_1);
        }
        else
        {
          this.setColorComboControl_0 = new setColorComboControl();
          Class39.smethod_309(ref this.setColorComboControl_0, (Color) Vars[index1].Value, this, Vars[index1].Name, 0);
          this.setColorComboControl_0.Location = new Point(this.label_0.Left + this.label_0.Width + this.RowSpace, this.RowSpace + num * (this.RowHeight + this.RowSpace));
          this.panel_0.Controls.Add((Control) this.label_0);
          this.panel_0.Controls.Add((Control) this.setColorComboControl_0);
          this.ControlList.Add((Control) this.setColorComboControl_0);
        }
        ++num;
      }
      if (type == typeof (Font))
      {
        bool result = false;
        bool.TryParse(Vars[index1].ValueAsString, out result);
        this.setLabelControl_0 = new setLabelControl();
        ref setLabelControl local = ref this.setLabelControl_0;
        string valueAsString = Vars[index1].ValueAsString;
        Class39.smethod_293(this.setLabelControl_0.BackColor, Vars[index1].Name, ref local, this, valueAsString);
        this.setLabelControl_0.Location = new Point(this.label_0.Left + this.label_0.Width + this.RowSpace, this.RowSpace + num * (this.RowHeight + this.RowSpace));
        this.setLabelControl_0.EditValue = Vars[index1].Value;
        this.setLabelControl_0.DoubleClick += new EventHandler(this.setLabelControl_0_DoubleClick);
        this.panel_0.Controls.Add((Control) this.label_0);
        this.panel_0.Controls.Add((Control) this.setLabelControl_0);
        this.ControlList.Add((Control) this.setLabelControl_0);
        ++num;
      }
      if (type == typeof (DateTime))
      {
        DateTime result = DateTime.Now;
        DateTime.TryParse(Vars[index1].ValueAsString, out result);
        this.setDateTimeControl_0 = new setDateTimeControl();
        ref setDateTimeControl local = ref this.setDateTimeControl_0;
        string name = Vars[index1].Name;
        Class39.smethod_396(ref local, 0, this, result, name);
        this.setDateTimeControl_0.Location = new Point(this.label_0.Left + this.label_0.Width + this.RowSpace, this.RowSpace + num * (this.RowHeight + this.RowSpace));
        this.panel_0.Controls.Add((Control) this.label_0);
        this.panel_0.Controls.Add((Control) this.setDateTimeControl_0);
        this.ControlList.Add((Control) this.setDateTimeControl_0);
        ++num;
      }
      if (type == typeof (drawPropertiesType))
      {
        drawPropertiesType drawPropertiesType1 = new drawPropertiesType();
        drawPropertiesType drawPropertiesType2 = (drawPropertiesType) Vars[index1].Value;
        bool result = false;
        bool.TryParse(Vars[index1].ValueAsString, out result);
        this.setLabelControl_0 = new setLabelControl();
        ref setLabelControl local = ref this.setLabelControl_0;
        string string_1 = drawPropertiesType2.ToString();
        string name = Vars[index1].Name;
        Class39.smethod_293(drawPropertiesType2.Color, name, ref local, this, string_1);
        this.setLabelControl_0.DoubleClick += new EventHandler(this.setLabelControl_0_DoubleClick);
        this.setLabelControl_0.Location = new Point(this.label_0.Left + this.label_0.Width + this.RowSpace, this.RowSpace + num * (this.RowHeight + this.RowSpace));
        this.setLabelControl_0.EditValue = Vars[index1].Value;
        this.setLabelControl_0.Font = new Font("Times New Roman", 8f);
        new ToolTip().SetToolTip((Control) this.setLabelControl_0, this.setLabelControl_0.Text);
        this.panel_0.Controls.Add((Control) this.label_0);
        this.panel_0.Controls.Add((Control) this.setLabelControl_0);
        this.ControlList.Add((Control) this.setLabelControl_0);
        ++num;
      }
      if (type == typeof (MouseKeyboardConfigration))
      {
        MouseKeyboardConfigration keyboardConfigration1 = new MouseKeyboardConfigration();
        MouseKeyboardConfigration keyboardConfigration2 = (MouseKeyboardConfigration) Vars[index1].Value;
        bool result = false;
        bool.TryParse(Vars[index1].ValueAsString, out result);
        this.setLabelControl_0 = new setLabelControl();
        ref setLabelControl local = ref this.setLabelControl_0;
        string string_1 = keyboardConfigration2.ToString();
        Class39.smethod_293(this.setLabelControl_0.BackColor, Vars[index1].Name, ref local, this, string_1);
        this.setLabelControl_0.DoubleClick += new EventHandler(this.setLabelControl_0_DoubleClick);
        this.setLabelControl_0.Location = new Point(this.label_0.Left + this.label_0.Width + this.RowSpace, this.RowSpace + num * (this.RowHeight + this.RowSpace));
        this.setLabelControl_0.EditValue = Vars[index1].Value;
        this.setLabelControl_0.Font = new Font("Times New Roman", 8f);
        new ToolTip().SetToolTip((Control) this.setLabelControl_0, this.setLabelControl_0.Text);
        this.panel_0.Controls.Add((Control) this.label_0);
        this.panel_0.Controls.Add((Control) this.setLabelControl_0);
        this.ControlList.Add((Control) this.setLabelControl_0);
        ++num;
      }
      if (type == typeof (EntityResolution))
      {
        EntityResolution entityResolution1 = new EntityResolution();
        EntityResolution entityResolution2 = (EntityResolution) Vars[index1].Value;
        bool result = false;
        bool.TryParse(Vars[index1].ValueAsString, out result);
        this.setLabelControl_0 = new setLabelControl();
        ref setLabelControl local = ref this.setLabelControl_0;
        string string_1 = entityResolution2.ToString();
        Class39.smethod_293(this.setLabelControl_0.BackColor, Vars[index1].Name, ref local, this, string_1);
        this.setLabelControl_0.DoubleClick += new EventHandler(this.setLabelControl_0_DoubleClick);
        this.setLabelControl_0.Font = new Font("Times New Roman", 8f);
        this.setLabelControl_0.Location = new Point(this.label_0.Left + this.label_0.Width + this.RowSpace, this.RowSpace + num * (this.RowHeight + this.RowSpace));
        this.setLabelControl_0.EditValue = Vars[index1].Value;
        new ToolTip() { InitialDelay = 100, ReshowDelay = 100 }.SetToolTip((Control) this.setLabelControl_0, this.setLabelControl_0.Text);
        this.panel_0.Controls.Add((Control) this.label_0);
        this.panel_0.Controls.Add((Control) this.setLabelControl_0);
        this.ControlList.Add((Control) this.setLabelControl_0);
        ++num;
      }
      if (type == typeof (SolidItemDisplay))
      {
        SolidItemDisplay solidItemDisplay1 = new SolidItemDisplay();
        SolidItemDisplay solidItemDisplay2 = (SolidItemDisplay) Vars[index1].Value;
        bool result = false;
        bool.TryParse(Vars[index1].ValueAsString, out result);
        this.setLabelControl_0 = new setLabelControl();
        ref setLabelControl local = ref this.setLabelControl_0;
        string string_1 = solidItemDisplay2.ToString();
        Class39.smethod_293(this.setLabelControl_0.BackColor, Vars[index1].Name, ref local, this, string_1);
        this.setLabelControl_0.DoubleClick += new EventHandler(this.setLabelControl_0_DoubleClick);
        this.setLabelControl_0.Font = new Font("Times New Roman", 8f);
        this.setLabelControl_0.Location = new Point(this.label_0.Left + this.label_0.Width + this.RowSpace, this.RowSpace + num * (this.RowHeight + this.RowSpace));
        this.setLabelControl_0.EditValue = Vars[index1].Value;
        new ToolTip() { InitialDelay = 100, ReshowDelay = 100 }.SetToolTip((Control) this.setLabelControl_0, this.setLabelControl_0.Text);
        this.panel_0.Controls.Add((Control) this.label_0);
        this.panel_0.Controls.Add((Control) this.setLabelControl_0);
        this.ControlList.Add((Control) this.setLabelControl_0);
        ++num;
      }
    }
    if (this.ShowOkButton)
    {
      this.button_0.Location = new Point(this.RowSpace, this.RowSpace + num * (this.RowHeight + this.RowSpace) + 4);
      this.button_0.Height = 40;
      this.button_0.Width = this.Width - this.ValueWidth - this.RowSpace * 9;
      this.button_0.Text = "  Ok";
      this.button_0.Image = (Image) Class39.smethod_655().ToBitmap();
      this.button_0.ImageAlign = ContentAlignment.MiddleLeft;
      if (this.OkButtonText.Length > 0)
        this.button_0.Text = "  " + this.OkButtonText;
      this.button_0.Visible = true;
      this.button_0.Click += new EventHandler(this.button_1_Click);
      this.panel_0.Controls.Add((Control) this.button_0);
    }
    if (!this.ShowCancelButton)
      return;
    this.button_1.Location = new Point(this.Width - (this.ValueWidth - this.RowSpace * 9) - 8, this.RowSpace + num * (this.RowHeight + this.RowSpace) + 4);
    this.button_1.Height = 40;
    this.button_1.Width = this.ValueWidth - this.RowSpace * 9;
    this.button_1.Text = "  Cancel";
    this.button_1.Image = (Image) Class39.smethod_373().ToBitmap();
    this.button_1.ImageAlign = ContentAlignment.MiddleLeft;
    if (this.CancelButtonText.Length > 0)
      this.button_1.Text = "  " + this.CancelButtonText;
    this.button_1.Visible = true;
    this.button_1.Click += new EventHandler(this.button_1_Click);
    this.panel_0.Controls.Add((Control) this.button_1);
  }

  internal void method_0(object sender, EventArgs e) => ((HandledMouseEventArgs) e).Handled = true;

  internal void method_1(object sender, EventArgs e)
  {
    Control control = (Control) sender;
    if (control.GetType() == typeof (setNumericUpDownControl))
    {
      ((setNumericUpDownControl) control).EditValue = (object) (double) ((NumericUpDown) control).Value;
      cParameter cParameter = new cParameter(control.Tag.ToString(), ((setNumericUpDownControl) control).EditValue);
      buSerilization.SetClassVariable(ref this.ClassObject, cParameter);
      // ISSUE: reference to a compiler-generated field
      if (this.classViewerEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.classViewerEventHandler_0((object) this, ((setNumericUpDownControl) control).EditValue, cParameter);
      }
    }
    if (control.GetType() == typeof (setTextBoxControl))
    {
      ((setTextBoxControl) control).EditValue = (object) control.Text;
      cParameter cParameter = new cParameter(control.Tag.ToString(), ((setTextBoxControl) control).EditValue);
      buSerilization.SetClassVariable(ref this.ClassObject, cParameter);
      // ISSUE: reference to a compiler-generated field
      if (this.classViewerEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.classViewerEventHandler_0((object) this, ((setTextBoxControl) control).EditValue, cParameter);
      }
    }
    if (control.GetType() == typeof (setCheckBoxControl))
    {
      ((setCheckBoxControl) control).EditValue = (object) ((CheckBox) control).Checked;
      cParameter cParameter = new cParameter(control.Tag.ToString(), ((setCheckBoxControl) control).EditValue);
      buSerilization.SetClassVariable(ref this.ClassObject, cParameter);
      // ISSUE: reference to a compiler-generated field
      if (this.classViewerEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.classViewerEventHandler_0((object) this, ((setCheckBoxControl) control).EditValue, cParameter);
      }
    }
    if (control.GetType() == typeof (setDateTimeControl))
    {
      ((setDateTimeControl) control).EditValue = (object) ((DateTimePicker) control).Value;
      cParameter cParameter = new cParameter(control.Tag.ToString(), ((setDateTimeControl) control).EditValue);
      buSerilization.SetClassVariable(ref this.ClassObject, cParameter);
      // ISSUE: reference to a compiler-generated field
      if (this.classViewerEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.classViewerEventHandler_0((object) this, ((setDateTimeControl) control).EditValue, cParameter);
      }
    }
    if (!(control.GetType() == typeof (setComboBoxControl)))
      return;
    ((setComboBoxControl) control).EditValue = (object) control.Text;
    cParameter cParameter1 = new cParameter(control.Tag.ToString(), ((setComboBoxControl) control).EditValue);
    buSerilization.SetClassVariable(ref this.ClassObject, cParameter1);
    // ISSUE: reference to a compiler-generated field
    if (this.classViewerEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.classViewerEventHandler_0((object) this, ((setComboBoxControl) control).EditValue, cParameter1);
  }

  internal void method_2(object object_0, Color color_0)
  {
    Control control = (Control) object_0;
    if (!(control.GetType() == typeof (setColorComboControl)))
      return;
    ((setColorComboControl) control).EditValue = (object) color_0;
    cParameter cParameter = new cParameter(control.Tag.ToString(), ((setColorComboControl) control).EditValue);
    buSerilization.SetClassVariable(ref this.ClassObject, cParameter);
    // ISSUE: reference to a compiler-generated field
    if (this.classViewerEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.classViewerEventHandler_0((object) this, ((setColorComboControl) control).EditValue, cParameter);
  }

  private void setLabelControl_1_Click(object sender, EventArgs e)
  {
    Control control = (Control) sender;
    ColorDialogBox colorDialogBox = new ColorDialogBox();
    Color backColor = control.BackColor;
    if (ColorDialogBox.ShowDialog(ref backColor) != DialogResult.OK)
      return;
    control.BackColor = backColor;
    control.Text = backColor.ToKnownColor().ToString();
    buSerilization.SetClassVariable(ref this.ClassObject, new cParameter(control.Tag.ToString(), (object) backColor));
  }

  private void setLabelControl_0_DoubleClick(object sender, EventArgs e)
  {
    Control control = (Control) sender;
    if (control.GetType() == typeof (setNumericUpDownControl))
      ;
    if (control.GetType() == typeof (setTextBoxControl))
      ;
    if (control.GetType() == typeof (setCheckBoxControl))
      ;
    if (control.GetType() == typeof (setComboBoxControl))
      ;
    if (!(control.GetType() == typeof (setLabelControl)))
      return;
    if (((setLabelControl) control).EditValue.GetType() == typeof (drawPropertiesType))
    {
      F_DrawPropertiesType drawPropertiesType = new F_DrawPropertiesType();
      drawPropertiesType.Value = (drawPropertiesType) ((setLabelControl) control).EditValue;
      drawPropertiesType.Init();
      drawPropertiesType.StartPosition = FormStartPosition.CenterParent;
      int num = (int) drawPropertiesType.ShowDialog((IWin32Window) this.Parent);
      ((setLabelControl) control).EditValue = (object) drawPropertiesType.Value;
      control.Text = ((drawPropertiesType) ((setLabelControl) control).EditValue).ToString();
      control.BackColor = ((drawPropertiesType) ((setLabelControl) control).EditValue).Color;
      control.ForeColor = buImage.InvertColor(control.BackColor);
      cParameter cParameter = new cParameter(control.Tag.ToString(), ((setLabelControl) control).EditValue);
      buSerilization.SetClassVariable(ref this.ClassObject, cParameter);
      // ISSUE: reference to a compiler-generated field
      if (this.classViewerEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.classViewerEventHandler_0((object) this, ((setLabelControl) control).EditValue, cParameter);
      }
    }
    if (((setLabelControl) control).EditValue.GetType() == typeof (MouseKeyboardConfigration))
    {
      F_MouseKeyboardConfig mouseKeyboardConfig = new F_MouseKeyboardConfig();
      mouseKeyboardConfig.Value = (MouseKeyboardConfigration) ((setLabelControl) control).EditValue;
      mouseKeyboardConfig.Init();
      mouseKeyboardConfig.StartPosition = FormStartPosition.CenterParent;
      int num = (int) mouseKeyboardConfig.ShowDialog((IWin32Window) this.Parent);
      ((setLabelControl) control).EditValue = (object) mouseKeyboardConfig.Value;
      control.Text = ((MouseKeyboardConfigration) ((setLabelControl) control).EditValue).ToString();
      cParameter cParameter = new cParameter(control.Tag.ToString(), ((setLabelControl) control).EditValue);
      buSerilization.SetClassVariable(ref this.ClassObject, cParameter);
      // ISSUE: reference to a compiler-generated field
      if (this.classViewerEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.classViewerEventHandler_0((object) this, ((setLabelControl) control).EditValue, cParameter);
      }
    }
    if (((setLabelControl) control).EditValue.GetType() == typeof (EntityResolution))
    {
      F_EntitiyResolution entitiyResolution = new F_EntitiyResolution();
      entitiyResolution.Value = (EntityResolution) ((setLabelControl) control).EditValue;
      entitiyResolution.Init();
      entitiyResolution.StartPosition = FormStartPosition.CenterParent;
      int num = (int) entitiyResolution.ShowDialog((IWin32Window) this.Parent);
      ((setLabelControl) control).EditValue = (object) entitiyResolution.Value;
      control.Text = ((EntityResolution) ((setLabelControl) control).EditValue).ToString();
      cParameter cParameter = new cParameter(control.Tag.ToString(), ((setLabelControl) control).EditValue);
      buSerilization.SetClassVariable(ref this.ClassObject, cParameter);
      // ISSUE: reference to a compiler-generated field
      if (this.classViewerEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.classViewerEventHandler_0((object) this, ((setLabelControl) control).EditValue, cParameter);
      }
    }
    if (((setLabelControl) control).EditValue.GetType() == typeof (SolidItemDisplay))
    {
      F_SolidItemDisplay solidItemDisplay = new F_SolidItemDisplay();
      solidItemDisplay.Value = (SolidItemDisplay) ((setLabelControl) control).EditValue;
      solidItemDisplay.Init();
      solidItemDisplay.StartPosition = FormStartPosition.CenterParent;
      int num = (int) solidItemDisplay.ShowDialog((IWin32Window) this.Parent);
      ((setLabelControl) control).EditValue = (object) solidItemDisplay.Value;
      control.Text = ((SolidItemDisplay) ((setLabelControl) control).EditValue).ToString();
      cParameter cParameter = new cParameter(control.Tag.ToString(), ((setLabelControl) control).EditValue);
      buSerilization.SetClassVariable(ref this.ClassObject, cParameter);
      // ISSUE: reference to a compiler-generated field
      if (this.classViewerEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.classViewerEventHandler_0((object) this, ((setLabelControl) control).EditValue, cParameter);
      }
    }
    if (((setLabelControl) control).EditValue.GetType() == typeof (Pnt2D))
    {
      F_Pnt3D fPnt3D = new F_Pnt3D();
      fPnt3D.Mode2D = true;
      fPnt3D.Value = buConversion.Pnt2DToPnt3D((Pnt2D) ((setLabelControl) control).EditValue);
      fPnt3D.Init();
      fPnt3D.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fPnt3D.ShowDialog((IWin32Window) this.Parent);
      ((setLabelControl) control).EditValue = (object) buConversion.Pnt3DToPnt2D(fPnt3D.Value);
      control.Text = ((Pnt2D) ((setLabelControl) control).EditValue).ToString();
      cParameter cParameter = new cParameter(control.Tag.ToString(), ((setLabelControl) control).EditValue);
      buSerilization.SetClassVariable(ref this.ClassObject, cParameter);
      // ISSUE: reference to a compiler-generated field
      if (this.classViewerEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.classViewerEventHandler_0((object) this, ((setLabelControl) control).EditValue, cParameter);
      }
    }
    if (((setLabelControl) control).EditValue.GetType() == typeof (Pnt3D))
    {
      F_Pnt3D fPnt3D = new F_Pnt3D();
      fPnt3D.Value = (Pnt3D) ((setLabelControl) control).EditValue;
      fPnt3D.Init();
      fPnt3D.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fPnt3D.ShowDialog((IWin32Window) this.Parent);
      ((setLabelControl) control).EditValue = (object) fPnt3D.Value;
      control.Text = ((Pnt3D) ((setLabelControl) control).EditValue).ToString();
      cParameter cParameter = new cParameter(control.Tag.ToString(), ((setLabelControl) control).EditValue);
      buSerilization.SetClassVariable(ref this.ClassObject, cParameter);
      // ISSUE: reference to a compiler-generated field
      if (this.classViewerEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.classViewerEventHandler_0((object) this, ((setLabelControl) control).EditValue, cParameter);
      }
    }
    if (((setLabelControl) control).EditValue.GetType() == typeof (Point))
    {
      F_Pnt3D fPnt3D = new F_Pnt3D();
      fPnt3D.IntergerMode = true;
      fPnt3D.Mode2D = true;
      fPnt3D.Value = buConversion.PointToPnt3D((Point) ((setLabelControl) control).EditValue);
      fPnt3D.Init();
      fPnt3D.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fPnt3D.ShowDialog((IWin32Window) this.Parent);
      ((setLabelControl) control).EditValue = (object) buConversion.Pnt3DToPoint(fPnt3D.Value);
      control.Text = buConversion.PointToString((Point) ((setLabelControl) control).EditValue);
      cParameter cParameter = new cParameter(control.Tag.ToString(), ((setLabelControl) control).EditValue);
      buSerilization.SetClassVariable(ref this.ClassObject, cParameter);
      // ISSUE: reference to a compiler-generated field
      if (this.classViewerEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.classViewerEventHandler_0((object) this, ((setLabelControl) control).EditValue, cParameter);
      }
    }
    if (((setLabelControl) control).EditValue.GetType() == typeof (PointF))
    {
      F_Pnt3D fPnt3D = new F_Pnt3D();
      fPnt3D.Mode2D = true;
      fPnt3D.Value = buConversion.PointFToPnt3D((PointF) ((setLabelControl) control).EditValue);
      fPnt3D.Init();
      fPnt3D.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fPnt3D.ShowDialog((IWin32Window) this.Parent);
      ((setLabelControl) control).EditValue = (object) buConversion.Pnt3DToPointF(fPnt3D.Value);
      control.Text = buConversion.PointFToString((PointF) ((setLabelControl) control).EditValue);
      cParameter cParameter = new cParameter(control.Tag.ToString(), ((setLabelControl) control).EditValue);
      buSerilization.SetClassVariable(ref this.ClassObject, cParameter);
      // ISSUE: reference to a compiler-generated field
      if (this.classViewerEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.classViewerEventHandler_0((object) this, ((setLabelControl) control).EditValue, cParameter);
      }
    }
    if (((setLabelControl) control).EditValue.GetType() == typeof (Size))
    {
      F_Size fSize = new F_Size();
      fSize.IntergerMode = true;
      fSize.Value = buConversion.SizeToSizeF((Size) ((setLabelControl) control).EditValue);
      fSize.Init();
      fSize.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fSize.ShowDialog((IWin32Window) this.Parent);
      ((setLabelControl) control).EditValue = (object) buConversion.SizeFToSize(fSize.Value);
      control.Text = buConversion.SizeToString((Size) ((setLabelControl) control).EditValue);
      cParameter cParameter = new cParameter(control.Tag.ToString(), ((setLabelControl) control).EditValue);
      buSerilization.SetClassVariable(ref this.ClassObject, cParameter);
      // ISSUE: reference to a compiler-generated field
      if (this.classViewerEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.classViewerEventHandler_0((object) this, ((setLabelControl) control).EditValue, cParameter);
      }
    }
    if (((setLabelControl) control).EditValue.GetType() == typeof (SizeF))
    {
      F_Size fSize = new F_Size();
      fSize.Value = (SizeF) ((setLabelControl) control).EditValue;
      fSize.Init();
      fSize.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fSize.ShowDialog((IWin32Window) this.Parent);
      ((setLabelControl) control).EditValue = (object) fSize.Value;
      control.Text = buConversion.SizeFToString((SizeF) ((setLabelControl) control).EditValue);
      cParameter cParameter = new cParameter(control.Tag.ToString(), ((setLabelControl) control).EditValue);
      buSerilization.SetClassVariable(ref this.ClassObject, cParameter);
      // ISSUE: reference to a compiler-generated field
      if (this.classViewerEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.classViewerEventHandler_0((object) this, ((setLabelControl) control).EditValue, cParameter);
      }
    }
    if (!(((setLabelControl) control).EditValue.GetType() == typeof (Font)))
      return;
    FontDialog fontDialog = new FontDialog();
    fontDialog.Font = (Font) ((setLabelControl) control).EditValue;
    if (fontDialog.ShowDialog() != DialogResult.OK)
      return;
    ((setLabelControl) control).EditValue = (object) fontDialog.Font;
    control.Text = $"{((Font) ((setLabelControl) control).EditValue).Name} - {((Font) ((setLabelControl) control).EditValue).Size.ToString()}";
    cParameter cParameter1 = new cParameter(control.Tag.ToString(), ((setLabelControl) control).EditValue);
    buSerilization.SetClassVariable(ref this.ClassObject, cParameter1);
    // ISSUE: reference to a compiler-generated field
    if (this.classViewerEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.classViewerEventHandler_0((object) this, ((setLabelControl) control).EditValue, cParameter1);
  }

  internal void method_3(object sender, EventArgs e)
  {
    try
    {
      if (!AppBool.TouchPad)
        return;
      if (sender.GetType() == typeof (TextBox))
      {
        TextBox textBox = new TextBox();
        buControlCommands.ShowKeyPad(this.OwnerForm, (Control) sender, this.TouchPayStyle);
      }
      if (sender.GetType() == typeof (NumericUpDown))
      {
        NumericUpDown numericUpDown = new NumericUpDown();
        buControlCommands.ShowKeyPad(this.OwnerForm, (Control) sender, this.TouchPayStyle);
      }
      if (sender.GetType().BaseType == typeof (NumericUpDown))
      {
        NumericUpDown numericUpDown = new NumericUpDown();
        buControlCommands.ShowKeyPad(this.OwnerForm, (Control) sender, this.TouchPayStyle);
      }
      if (!(sender.GetType().BaseType == typeof (TextBox)))
        return;
      TextBox textBox1 = new TextBox();
      buControlCommands.ShowKeyPad(this.OwnerForm, (Control) sender, this.TouchPayStyle);
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  private void button_1_Click(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_0.Name && this.eventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0((object) this, e);
    }
    // ISSUE: reference to a compiler-generated field
    if (!(control2.Name == this.button_1.Name) || this.eventHandler_1 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.eventHandler_1((object) this, e);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
