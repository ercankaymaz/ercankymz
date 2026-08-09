using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls;
using buControls.Forms.WinControlForms.ClassForm;
using buCore;
using buEyeBaseVer5.Forms.ClassForm;
using ns71;

namespace buEyeBaseVer5.ClassViewer;

public class buClassViewer5 : UserControl
{
	public delegate void ClassViewerEventHandler5(object sender, object Value, cParameter5 Parameter);

	public int RowHeight = 30;

	public int RowSpace = 4;

	public int DecimalPlace = 3;

	public Font FontCaptions = new Font("Times New Roman", 12f);

	public Font FontValues = new Font("Times New Roman", 12f);

	public int ValueWidth = 250;

	public bool ShowOkButton = false;

	public bool ShowCancelButton = false;

	public string OkButtonText = "Ok";

	public string CancelButtonText = "Cancel";

	public object ClassObject = null;

	public Form OwnerForm = null;

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

	[CompilerGenerated]
	private ClassViewerEventHandler5 classViewerEventHandler5_0;

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	[CompilerGenerated]
	private EventHandler eventHandler_1;

	private IContainer icontainer_0 = null;

	internal Panel panel_0;

	public event ClassViewerEventHandler5 ValueChanged
	{
		[CompilerGenerated]
		add
		{
			ClassViewerEventHandler5 classViewerEventHandler = classViewerEventHandler5_0;
			ClassViewerEventHandler5 classViewerEventHandler2;
			do
			{
				classViewerEventHandler2 = classViewerEventHandler;
				ClassViewerEventHandler5 value2 = (ClassViewerEventHandler5)Delegate.Combine(classViewerEventHandler2, value);
				classViewerEventHandler = Interlocked.CompareExchange(ref classViewerEventHandler5_0, value2, classViewerEventHandler2);
			}
			while ((object)classViewerEventHandler != classViewerEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ClassViewerEventHandler5 classViewerEventHandler = classViewerEventHandler5_0;
			ClassViewerEventHandler5 classViewerEventHandler2;
			do
			{
				classViewerEventHandler2 = classViewerEventHandler;
				ClassViewerEventHandler5 value2 = (ClassViewerEventHandler5)Delegate.Remove(classViewerEventHandler2, value);
				classViewerEventHandler = Interlocked.CompareExchange(ref classViewerEventHandler5_0, value2, classViewerEventHandler2);
			}
			while ((object)classViewerEventHandler != classViewerEventHandler2);
		}
	}

	public event EventHandler OkButtonClicked
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler CancelButtonClicked
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_1;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_1;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public buClassViewer5()
	{
		Class186.smethod_75(this);
	}

	public void Init()
	{
		List<cParameter5> Vars = new List<cParameter5>();
		List<string> Captions = new List<string>();
		buSerilization5.GetClassVariables(ClassObject, ref Vars);
		buSerilization5.GetCaptionsOfClass(ClassObject, ref Captions);
		ControlList.Clear();
		ControlList = new List<Control>();
		int num = 0;
		panel_0.Controls.Clear();
		for (int i = 0; i <= Vars.Count - 1; i++)
		{
			Type type = Vars[i].Value.GetType();
			label_0 = new Label();
			label_0.BorderStyle = BorderStyle.FixedSingle;
			label_0.Text = Vars[i].Name;
			if ((Captions.Count > 0) & (i <= Captions.Count - 1))
			{
				label_0.Text = Captions[i];
			}
			if ((ParCaptions.Count > 0) & (i <= ParCaptions.Count - 1))
			{
				label_0.Text = ParCaptions[i];
			}
			label_0.Font = FontCaptions;
			label_0.Size = new Size(base.Width - ValueWidth - RowSpace * 9, RowHeight);
			label_0.Location = new Point(RowSpace, RowSpace + num * (RowHeight + RowSpace));
			if ((type == typeof(double)) | (type == typeof(float)))
			{
				decimal result = default(decimal);
				decimal.TryParse(Vars[i].ValueAsString, out result);
				setNumericUpDownControl_0 = new setNumericUpDownControl();
				ref setNumericUpDownControl reference = ref setNumericUpDownControl_0;
				string name = Vars[i].Name;
				int decimalPlace = DecimalPlace;
				Class186.smethod_398(name, this, ref reference, decimalPlace, result);
				setNumericUpDownControl_0.Location = new Point(label_0.Left + label_0.Width + RowSpace, RowSpace + num * (RowHeight + RowSpace));
				panel_0.Controls.Add(label_0);
				panel_0.Controls.Add(setNumericUpDownControl_0);
				ControlList.Add(setNumericUpDownControl_0);
				num++;
			}
			if ((type == typeof(int)) | (type == typeof(byte)) | (type == typeof(long)))
			{
				decimal result2 = default(decimal);
				decimal.TryParse(Vars[i].ValueAsString, out result2);
				setNumericUpDownControl_0 = new setNumericUpDownControl();
				ref setNumericUpDownControl reference = ref setNumericUpDownControl_0;
				string name = Vars[i].Name;
				Class186.smethod_398(name, this, ref reference, 0, result2);
				setNumericUpDownControl_0.Location = new Point(label_0.Left + label_0.Width + RowSpace, RowSpace + num * (RowHeight + RowSpace));
				panel_0.Controls.Add(label_0);
				panel_0.Controls.Add(setNumericUpDownControl_0);
				ControlList.Add(setNumericUpDownControl_0);
				num++;
			}
			if (type == typeof(bool))
			{
				bool result3 = false;
				bool.TryParse(Vars[i].ValueAsString, out result3);
				setCheckBoxControl_0 = new setCheckBoxControl();
				ref setCheckBoxControl reference2 = ref setCheckBoxControl_0;
				string name2 = Vars[i].Name;
				Class186.smethod_491(name2, ref reference2, result3, this);
				setCheckBoxControl_0.Location = new Point(label_0.Left + label_0.Width + RowSpace, RowSpace + num * (RowHeight + RowSpace));
				panel_0.Controls.Add(label_0);
				panel_0.Controls.Add(setCheckBoxControl_0);
				ControlList.Add(setCheckBoxControl_0);
				num++;
			}
			if (type == typeof(string))
			{
				bool result4 = false;
				bool.TryParse(Vars[i].ValueAsString, out result4);
				setTextBoxControl_0 = new setTextBoxControl();
				ref setTextBoxControl reference3 = ref setTextBoxControl_0;
				string valueAsString = Vars[i].ValueAsString;
				string name3 = Vars[i].Name;
				Class186.smethod_20(valueAsString, ref reference3, name3, this);
				setTextBoxControl_0.Location = new Point(label_0.Left + label_0.Width + RowSpace, RowSpace + num * (RowHeight + RowSpace));
				panel_0.Controls.Add(label_0);
				panel_0.Controls.Add(setTextBoxControl_0);
				ControlList.Add(setTextBoxControl_0);
				num++;
			}
			if (type.IsEnum)
			{
				bool result5 = false;
				bool.TryParse(Vars[i].ValueAsString, out result5);
				ArrayList arrayList = new ArrayList();
				Array array = null;
				array = Enum.GetValues(type);
				for (int j = 0; j <= array.Length - 1; j++)
				{
					arrayList.Add(array.GetValue(j));
				}
				setComboBoxControl_0 = new setComboBoxControl();
				ref setComboBoxControl reference4 = ref setComboBoxControl_0;
				string string_ = Vars[i].Value.ToString();
				string name4 = Vars[i].Name;
				Class186.smethod_320(name4, this, arrayList, ref reference4, string_);
				setComboBoxControl_0.Location = new Point(label_0.Left + label_0.Width + RowSpace, RowSpace + num * (RowHeight + RowSpace));
				panel_0.Controls.Add(label_0);
				panel_0.Controls.Add(setComboBoxControl_0);
				ControlList.Add(setComboBoxControl_0);
				num++;
			}
			if (type == typeof(float[]))
			{
				setTextBoxControl_0 = new setTextBoxControl();
				string text = "";
				float[] array2 = (float[])Vars[i].Value;
				for (int k = 0; k <= array2.Length - 1; k++)
				{
					text = ((k == 0) ? array2[k].ToString() : (text + ";" + array2[k]));
				}
				ref setTextBoxControl reference3 = ref setTextBoxControl_0;
				string name3 = Vars[i].Name;
				Class186.smethod_20(text, ref reference3, name3, this);
				setTextBoxControl_0.Location = new Point(label_0.Left + label_0.Width + RowSpace, RowSpace + num * (RowHeight + RowSpace));
				panel_0.Controls.Add(label_0);
				panel_0.Controls.Add(setTextBoxControl_0);
				ControlList.Add(setTextBoxControl_0);
				num++;
			}
			if (type == typeof(double[]))
			{
				setTextBoxControl_0 = new setTextBoxControl();
				string text2 = "";
				double[] array3 = (double[])Vars[i].Value;
				for (int l = 0; l <= array3.Length - 1; l++)
				{
					text2 = ((l == 0) ? array3[l].ToString() : (text2 + ";" + array3[l]));
				}
				ref setTextBoxControl reference3 = ref setTextBoxControl_0;
				string name3 = Vars[i].Name;
				Class186.smethod_20(text2, ref reference3, name3, this);
				setTextBoxControl_0.Location = new Point(label_0.Left + label_0.Width + RowSpace, RowSpace + num * (RowHeight + RowSpace));
				panel_0.Controls.Add(label_0);
				panel_0.Controls.Add(setTextBoxControl_0);
				ControlList.Add(setTextBoxControl_0);
				num++;
			}
			if (type == typeof(int[]))
			{
				setTextBoxControl_0 = new setTextBoxControl();
				string text3 = "";
				int[] array4 = (int[])Vars[i].Value;
				for (int m = 0; m <= array4.Length - 1; m++)
				{
					text3 = ((m == 0) ? array4[m].ToString() : (text3 + ";" + array4[m]));
				}
				ref setTextBoxControl reference3 = ref setTextBoxControl_0;
				string name3 = Vars[i].Name;
				Class186.smethod_20(text3, ref reference3, name3, this);
				setTextBoxControl_0.Location = new Point(label_0.Left + label_0.Width + RowSpace, RowSpace + num * (RowHeight + RowSpace));
				panel_0.Controls.Add(label_0);
				panel_0.Controls.Add(setTextBoxControl_0);
				ControlList.Add(setTextBoxControl_0);
				num++;
			}
			if (type == typeof(bool[]))
			{
				setTextBoxControl_0 = new setTextBoxControl();
				string text4 = "";
				bool[] array5 = (bool[])Vars[i].Value;
				for (int n = 0; n <= array5.Length - 1; n++)
				{
					text4 = ((n == 0) ? array5[n].ToString() : (text4 + ";" + array5[n]));
				}
				ref setTextBoxControl reference3 = ref setTextBoxControl_0;
				string name3 = Vars[i].Name;
				Class186.smethod_20(text4, ref reference3, name3, this);
				setTextBoxControl_0.Location = new Point(label_0.Left + label_0.Width + RowSpace, RowSpace + num * (RowHeight + RowSpace));
				panel_0.Controls.Add(label_0);
				panel_0.Controls.Add(setTextBoxControl_0);
				ControlList.Add(setTextBoxControl_0);
				num++;
			}
			if (type == typeof(ArrayList))
			{
				setTextBoxControl_0 = new setTextBoxControl();
				string text5 = "";
				ArrayList arrayList2 = (ArrayList)Vars[i].Value;
				for (int num2 = 0; num2 <= arrayList2.Count - 1; num2++)
				{
					text5 = ((num2 == 0) ? arrayList2[num2].ToString() : (text5 + Environment.NewLine + arrayList2[num2].ToString()));
				}
				ref setTextBoxControl reference3 = ref setTextBoxControl_0;
				string name3 = Vars[i].Name;
				Class186.smethod_20(text5, ref reference3, name3, this);
				setTextBoxControl_0.Height = RowHeight * 3 + RowSpace * 2;
				setTextBoxControl_0.Multiline = true;
				setTextBoxControl_0.ScrollBars = ScrollBars.Both;
				setTextBoxControl_0.Location = new Point(label_0.Left + label_0.Width + RowSpace, RowSpace + num * (RowHeight + RowSpace));
				panel_0.Controls.Add(label_0);
				panel_0.Controls.Add(setTextBoxControl_0);
				ControlList.Add(setTextBoxControl_0);
				num++;
				num++;
				num++;
			}
			if (type == typeof(Pnt3D))
			{
				Pnt3D pnt3D = new Pnt3D();
				pnt3D = (Pnt3D)Vars[i].Value;
				setLabelControl_0 = new setLabelControl();
				ref setLabelControl reference5 = ref setLabelControl_0;
				string string_2 = pnt3D.ToString();
				string name5 = Vars[i].Name;
				Color backColor = setLabelControl_0.BackColor;
				Class186.smethod_13(name5, this, ref reference5, backColor, string_2);
				setLabelControl_0.DoubleClick += setLabelControl_0_DoubleClick;
				setLabelControl_0.Location = new Point(label_0.Left + label_0.Width + RowSpace, RowSpace + num * (RowHeight + RowSpace));
				setLabelControl_0.EditValue = Vars[i].Value;
				panel_0.Controls.Add(label_0);
				panel_0.Controls.Add(setLabelControl_0);
				ControlList.Add(setLabelControl_0);
				num++;
			}
			if (type == typeof(Pnt2D))
			{
				Pnt2D pnt2D = new Pnt2D();
				pnt2D = (Pnt2D)Vars[i].Value;
				setLabelControl_0 = new setLabelControl();
				ref setLabelControl reference5 = ref setLabelControl_0;
				string string_2 = pnt2D.ToString();
				string name5 = Vars[i].Name;
				Color backColor = setLabelControl_0.BackColor;
				Class186.smethod_13(name5, this, ref reference5, backColor, string_2);
				setLabelControl_0.DoubleClick += setLabelControl_0_DoubleClick;
				setLabelControl_0.Location = new Point(label_0.Left + label_0.Width + RowSpace, RowSpace + num * (RowHeight + RowSpace));
				setLabelControl_0.EditValue = Vars[i].Value;
				panel_0.Controls.Add(label_0);
				panel_0.Controls.Add(setLabelControl_0);
				ControlList.Add(setLabelControl_0);
				num++;
			}
			if (type == typeof(Point))
			{
				Point point = default(Point);
				point = (Point)Vars[i].Value;
				setLabelControl_0 = new setLabelControl();
				ref setLabelControl reference5 = ref setLabelControl_0;
				string string_2 = buConversion.PointToString(point);
				string name5 = Vars[i].Name;
				Color backColor = setLabelControl_0.BackColor;
				Class186.smethod_13(name5, this, ref reference5, backColor, string_2);
				setLabelControl_0.DoubleClick += setLabelControl_0_DoubleClick;
				setLabelControl_0.Location = new Point(label_0.Left + label_0.Width + RowSpace, RowSpace + num * (RowHeight + RowSpace));
				setLabelControl_0.EditValue = Vars[i].Value;
				panel_0.Controls.Add(label_0);
				panel_0.Controls.Add(setLabelControl_0);
				ControlList.Add(setLabelControl_0);
				num++;
			}
			if (type == typeof(PointF))
			{
				PointF pointF = default(PointF);
				pointF = (PointF)Vars[i].Value;
				setLabelControl_0 = new setLabelControl();
				ref setLabelControl reference5 = ref setLabelControl_0;
				string string_2 = buConversion.PointFToString(pointF);
				string name5 = Vars[i].Name;
				Color backColor = setLabelControl_0.BackColor;
				Class186.smethod_13(name5, this, ref reference5, backColor, string_2);
				setLabelControl_0.DoubleClick += setLabelControl_0_DoubleClick;
				setLabelControl_0.Location = new Point(label_0.Left + label_0.Width + RowSpace, RowSpace + num * (RowHeight + RowSpace));
				setLabelControl_0.EditValue = Vars[i].Value;
				panel_0.Controls.Add(label_0);
				panel_0.Controls.Add(setLabelControl_0);
				ControlList.Add(setLabelControl_0);
				num++;
			}
			if (type == typeof(Size))
			{
				Size size = default(Size);
				size = (Size)Vars[i].Value;
				setLabelControl_0 = new setLabelControl();
				ref setLabelControl reference5 = ref setLabelControl_0;
				string string_2 = buConversion.SizeToString(size);
				string name5 = Vars[i].Name;
				Color backColor = setLabelControl_0.BackColor;
				Class186.smethod_13(name5, this, ref reference5, backColor, string_2);
				setLabelControl_0.DoubleClick += setLabelControl_0_DoubleClick;
				setLabelControl_0.Location = new Point(label_0.Left + label_0.Width + RowSpace, RowSpace + num * (RowHeight + RowSpace));
				setLabelControl_0.EditValue = Vars[i].Value;
				panel_0.Controls.Add(label_0);
				panel_0.Controls.Add(setLabelControl_0);
				ControlList.Add(setLabelControl_0);
				num++;
			}
			if (type == typeof(SizeF))
			{
				SizeF sizeF = default(SizeF);
				sizeF = (SizeF)Vars[i].Value;
				setLabelControl_0 = new setLabelControl();
				ref setLabelControl reference5 = ref setLabelControl_0;
				string string_2 = buConversion.SizeFToString(sizeF);
				string name5 = Vars[i].Name;
				Color backColor = setLabelControl_0.BackColor;
				Class186.smethod_13(name5, this, ref reference5, backColor, string_2);
				setLabelControl_0.DoubleClick += setLabelControl_0_DoubleClick;
				setLabelControl_0.Location = new Point(label_0.Left + label_0.Width + RowSpace, RowSpace + num * (RowHeight + RowSpace));
				setLabelControl_0.EditValue = Vars[i].Value;
				panel_0.Controls.Add(label_0);
				panel_0.Controls.Add(setLabelControl_0);
				ControlList.Add(setLabelControl_0);
				num++;
			}
			if (type == typeof(Color))
			{
				bool result6 = false;
				bool.TryParse(Vars[i].ValueAsString, out result6);
				setColorComboControl_0 = new setColorComboControl();
				ref setColorComboControl reference6 = ref setColorComboControl_0;
				Color color_ = (Color)Vars[i].Value;
				string name6 = Vars[i].Name;
				Class186.smethod_711(color_, name6, ref reference6, 0, this);
				setColorComboControl_0.Location = new Point(label_0.Left + label_0.Width + RowSpace, RowSpace + num * (RowHeight + RowSpace));
				panel_0.Controls.Add(label_0);
				panel_0.Controls.Add(setColorComboControl_0);
				ControlList.Add(setColorComboControl_0);
				num++;
			}
			if (type == typeof(Font))
			{
				bool result7 = false;
				bool.TryParse(Vars[i].ValueAsString, out result7);
				setLabelControl_0 = new setLabelControl();
				ref setLabelControl reference5 = ref setLabelControl_0;
				string string_2 = Vars[i].ValueAsString;
				string name5 = Vars[i].Name;
				Color backColor = setLabelControl_0.BackColor;
				Class186.smethod_13(name5, this, ref reference5, backColor, string_2);
				setLabelControl_0.Location = new Point(label_0.Left + label_0.Width + RowSpace, RowSpace + num * (RowHeight + RowSpace));
				setLabelControl_0.EditValue = Vars[i].Value;
				setLabelControl_0.DoubleClick += setLabelControl_0_DoubleClick;
				panel_0.Controls.Add(label_0);
				panel_0.Controls.Add(setLabelControl_0);
				ControlList.Add(setLabelControl_0);
				num++;
			}
			if (type == typeof(DateTime))
			{
				DateTime result8 = DateTime.Now;
				DateTime.TryParse(Vars[i].ValueAsString, out result8);
				setDateTimeControl_0 = new setDateTimeControl();
				ref setDateTimeControl reference7 = ref setDateTimeControl_0;
				string name7 = Vars[i].Name;
				Class186.smethod_337(ref reference7, result8, 0, name7, this);
				setDateTimeControl_0.Location = new Point(label_0.Left + label_0.Width + RowSpace, RowSpace + num * (RowHeight + RowSpace));
				panel_0.Controls.Add(label_0);
				panel_0.Controls.Add(setDateTimeControl_0);
				ControlList.Add(setDateTimeControl_0);
				num++;
			}
			if (type == typeof(drawPropertiesType))
			{
				drawPropertiesType drawPropertiesType2 = new drawPropertiesType();
				drawPropertiesType2 = (drawPropertiesType)Vars[i].Value;
				bool result9 = false;
				bool.TryParse(Vars[i].ValueAsString, out result9);
				setLabelControl_0 = new setLabelControl();
				ref setLabelControl reference5 = ref setLabelControl_0;
				string string_2 = drawPropertiesType2.ToString();
				string name5 = Vars[i].Name;
				Color backColor = drawPropertiesType2.Color;
				Class186.smethod_13(name5, this, ref reference5, backColor, string_2);
				setLabelControl_0.DoubleClick += setLabelControl_0_DoubleClick;
				setLabelControl_0.Location = new Point(label_0.Left + label_0.Width + RowSpace, RowSpace + num * (RowHeight + RowSpace));
				setLabelControl_0.EditValue = Vars[i].Value;
				setLabelControl_0.Font = new Font("Times New Roman", 8f);
				ToolTip toolTip = new ToolTip();
				toolTip.SetToolTip(setLabelControl_0, setLabelControl_0.Text);
				panel_0.Controls.Add(label_0);
				panel_0.Controls.Add(setLabelControl_0);
				ControlList.Add(setLabelControl_0);
				num++;
			}
			if (type == typeof(ColorType))
			{
				ColorType colorType = new ColorType();
				colorType = (ColorType)Vars[i].Value;
				bool result10 = false;
				bool.TryParse(Vars[i].ValueAsString, out result10);
				setLabelControl_0 = new setLabelControl();
				ref setLabelControl reference5 = ref setLabelControl_0;
				string string_2 = colorType.ToString();
				string name5 = Vars[i].Name;
				Color backColor = colorType.Color;
				Class186.smethod_13(name5, this, ref reference5, backColor, string_2);
				setLabelControl_0.DoubleClick += setLabelControl_0_DoubleClick;
				setLabelControl_0.Location = new Point(label_0.Left + label_0.Width + RowSpace, RowSpace + num * (RowHeight + RowSpace));
				setLabelControl_0.EditValue = Vars[i].Value;
				setLabelControl_0.Font = new Font("Times New Roman", 8f);
				ToolTip toolTip2 = new ToolTip();
				toolTip2.SetToolTip(setLabelControl_0, setLabelControl_0.Text);
				panel_0.Controls.Add(label_0);
				panel_0.Controls.Add(setLabelControl_0);
				ControlList.Add(setLabelControl_0);
				num++;
			}
			if (type == typeof(ColorDrawType))
			{
				ColorDrawType colorDrawType = new ColorDrawType();
				colorDrawType = (ColorDrawType)Vars[i].Value;
				bool result11 = false;
				bool.TryParse(Vars[i].ValueAsString, out result11);
				setLabelControl_0 = new setLabelControl();
				ref setLabelControl reference5 = ref setLabelControl_0;
				string string_2 = colorDrawType.ToString();
				string name5 = Vars[i].Name;
				Color backColor = colorDrawType.Color;
				Class186.smethod_13(name5, this, ref reference5, backColor, string_2);
				setLabelControl_0.DoubleClick += setLabelControl_0_DoubleClick;
				setLabelControl_0.Location = new Point(label_0.Left + label_0.Width + RowSpace, RowSpace + num * (RowHeight + RowSpace));
				setLabelControl_0.EditValue = Vars[i].Value;
				setLabelControl_0.Font = new Font("Times New Roman", 8f);
				ToolTip toolTip3 = new ToolTip();
				toolTip3.SetToolTip(setLabelControl_0, setLabelControl_0.Text);
				panel_0.Controls.Add(label_0);
				panel_0.Controls.Add(setLabelControl_0);
				ControlList.Add(setLabelControl_0);
				num++;
			}
			if (type == typeof(MouseKeyboardConfigration))
			{
				MouseKeyboardConfigration mouseKeyboardConfigration = new MouseKeyboardConfigration();
				mouseKeyboardConfigration = (MouseKeyboardConfigration)Vars[i].Value;
				bool result12 = false;
				bool.TryParse(Vars[i].ValueAsString, out result12);
				setLabelControl_0 = new setLabelControl();
				ref setLabelControl reference5 = ref setLabelControl_0;
				string string_2 = mouseKeyboardConfigration.ToString();
				string name5 = Vars[i].Name;
				Color backColor = setLabelControl_0.BackColor;
				Class186.smethod_13(name5, this, ref reference5, backColor, string_2);
				setLabelControl_0.DoubleClick += setLabelControl_0_DoubleClick;
				setLabelControl_0.Location = new Point(label_0.Left + label_0.Width + RowSpace, RowSpace + num * (RowHeight + RowSpace));
				setLabelControl_0.EditValue = Vars[i].Value;
				setLabelControl_0.Font = new Font("Times New Roman", 8f);
				ToolTip toolTip4 = new ToolTip();
				toolTip4.SetToolTip(setLabelControl_0, setLabelControl_0.Text);
				panel_0.Controls.Add(label_0);
				panel_0.Controls.Add(setLabelControl_0);
				ControlList.Add(setLabelControl_0);
				num++;
			}
			if (type == typeof(EntityResolution))
			{
				EntityResolution entityResolution = new EntityResolution();
				entityResolution = (EntityResolution)Vars[i].Value;
				bool result13 = false;
				bool.TryParse(Vars[i].ValueAsString, out result13);
				setLabelControl_0 = new setLabelControl();
				ref setLabelControl reference5 = ref setLabelControl_0;
				string string_2 = entityResolution.ToString();
				string name5 = Vars[i].Name;
				Color backColor = setLabelControl_0.BackColor;
				Class186.smethod_13(name5, this, ref reference5, backColor, string_2);
				setLabelControl_0.DoubleClick += setLabelControl_0_DoubleClick;
				setLabelControl_0.Font = new Font("Times New Roman", 8f);
				setLabelControl_0.Location = new Point(label_0.Left + label_0.Width + RowSpace, RowSpace + num * (RowHeight + RowSpace));
				setLabelControl_0.EditValue = Vars[i].Value;
				ToolTip toolTip5 = new ToolTip();
				toolTip5.InitialDelay = 100;
				toolTip5.ReshowDelay = 100;
				toolTip5.SetToolTip(setLabelControl_0, setLabelControl_0.Text);
				panel_0.Controls.Add(label_0);
				panel_0.Controls.Add(setLabelControl_0);
				ControlList.Add(setLabelControl_0);
				num++;
			}
			if (type == typeof(SolidItemDisplay))
			{
				SolidItemDisplay solidItemDisplay = new SolidItemDisplay();
				solidItemDisplay = (SolidItemDisplay)Vars[i].Value;
				bool result14 = false;
				bool.TryParse(Vars[i].ValueAsString, out result14);
				setLabelControl_0 = new setLabelControl();
				ref setLabelControl reference5 = ref setLabelControl_0;
				string string_2 = solidItemDisplay.ToString();
				string name5 = Vars[i].Name;
				Color backColor = setLabelControl_0.BackColor;
				Class186.smethod_13(name5, this, ref reference5, backColor, string_2);
				setLabelControl_0.DoubleClick += setLabelControl_0_DoubleClick;
				setLabelControl_0.Font = new Font("Times New Roman", 8f);
				setLabelControl_0.Location = new Point(label_0.Left + label_0.Width + RowSpace, RowSpace + num * (RowHeight + RowSpace));
				setLabelControl_0.EditValue = Vars[i].Value;
				ToolTip toolTip6 = new ToolTip();
				toolTip6.InitialDelay = 100;
				toolTip6.ReshowDelay = 100;
				toolTip6.SetToolTip(setLabelControl_0, setLabelControl_0.Text);
				panel_0.Controls.Add(label_0);
				panel_0.Controls.Add(setLabelControl_0);
				ControlList.Add(setLabelControl_0);
				num++;
			}
		}
		if (ShowOkButton)
		{
			button_0.Location = new Point(RowSpace, RowSpace + num * (RowHeight + RowSpace) + 4);
			button_0.Height = 40;
			button_0.Width = base.Width - ValueWidth - RowSpace * 9;
			button_0.Text = "  Ok";
			button_0.ImageAlign = ContentAlignment.MiddleLeft;
			if (OkButtonText.Length > 0)
			{
				button_0.Text = "  " + OkButtonText;
			}
			button_0.Visible = true;
			button_0.Click += button_1_Click;
			panel_0.Controls.Add(button_0);
		}
		if (ShowCancelButton)
		{
			button_1.Location = new Point(base.Width - (ValueWidth - RowSpace * 9) - 8, RowSpace + num * (RowHeight + RowSpace) + 4);
			button_1.Height = 40;
			button_1.Width = ValueWidth - RowSpace * 9;
			button_1.Text = "  Cancel";
			button_1.ImageAlign = ContentAlignment.MiddleLeft;
			if (CancelButtonText.Length > 0)
			{
				button_1.Text = "  " + CancelButtonText;
			}
			button_1.Visible = true;
			button_1.Click += button_1_Click;
			panel_0.Controls.Add(button_1);
		}
	}

	internal void method_0(object sender, EventArgs e)
	{
		HandledMouseEventArgs e2 = (HandledMouseEventArgs)e;
		e2.Handled = true;
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = (Control)sender;
		if (control.GetType() == typeof(setNumericUpDownControl))
		{
			((setNumericUpDownControl)control).EditValue = (double)((setNumericUpDownControl)control).Value;
			cParameter5 cParameter6 = new cParameter5(control.Tag.ToString(), ((setNumericUpDownControl)control).EditValue);
			buSerilization5.SetClassVariable(ref ClassObject, cParameter6);
			if (classViewerEventHandler5_0 != null)
			{
				classViewerEventHandler5_0(this, ((setNumericUpDownControl)control).EditValue, cParameter6);
			}
		}
		if (control.GetType() == typeof(setTextBoxControl))
		{
			((setTextBoxControl)control).EditValue = ((setTextBoxControl)control).Text;
			cParameter5 cParameter7 = new cParameter5(control.Tag.ToString(), ((setTextBoxControl)control).EditValue);
			buSerilization5.SetClassVariable(ref ClassObject, cParameter7);
			if (classViewerEventHandler5_0 != null)
			{
				classViewerEventHandler5_0(this, ((setTextBoxControl)control).EditValue, cParameter7);
			}
		}
		if (control.GetType() == typeof(setCheckBoxControl))
		{
			((setCheckBoxControl)control).EditValue = ((setCheckBoxControl)control).Checked;
			cParameter5 cParameter8 = new cParameter5(control.Tag.ToString(), ((setCheckBoxControl)control).EditValue);
			buSerilization5.SetClassVariable(ref ClassObject, cParameter8);
			if (classViewerEventHandler5_0 != null)
			{
				classViewerEventHandler5_0(this, ((setCheckBoxControl)control).EditValue, cParameter8);
			}
		}
		if (control.GetType() == typeof(setDateTimeControl))
		{
			((setDateTimeControl)control).EditValue = ((setDateTimeControl)control).Value;
			cParameter5 cParameter9 = new cParameter5(control.Tag.ToString(), ((setDateTimeControl)control).EditValue);
			buSerilization5.SetClassVariable(ref ClassObject, cParameter9);
			if (classViewerEventHandler5_0 != null)
			{
				classViewerEventHandler5_0(this, ((setDateTimeControl)control).EditValue, cParameter9);
			}
		}
		if (control.GetType() == typeof(setComboBoxControl))
		{
			((setComboBoxControl)control).EditValue = ((setComboBoxControl)control).Text;
			cParameter5 cParameter10 = new cParameter5(control.Tag.ToString(), ((setComboBoxControl)control).EditValue);
			buSerilization5.SetClassVariable(ref ClassObject, cParameter10);
			if (classViewerEventHandler5_0 != null)
			{
				classViewerEventHandler5_0(this, ((setComboBoxControl)control).EditValue, cParameter10);
			}
		}
	}

	internal void method_2(object object_0, Color color_0)
	{
		Control control = (Control)object_0;
		if (control.GetType() == typeof(setColorComboControl))
		{
			((setColorComboControl)control).EditValue = color_0;
			cParameter5 cParameter6 = new cParameter5(control.Tag.ToString(), ((setColorComboControl)control).EditValue);
			buSerilization5.SetClassVariable(ref ClassObject, cParameter6);
			if (classViewerEventHandler5_0 != null)
			{
				classViewerEventHandler5_0(this, ((setColorComboControl)control).EditValue, cParameter6);
			}
		}
	}

	private void setLabelControl_0_DoubleClick(object sender, EventArgs e)
	{
		Control control = (Control)sender;
		if (!(control.GetType() == typeof(setNumericUpDownControl)))
		{
		}
		if (!(control.GetType() == typeof(setTextBoxControl)))
		{
		}
		if (!(control.GetType() == typeof(setCheckBoxControl)))
		{
		}
		if (!(control.GetType() == typeof(setComboBoxControl)))
		{
		}
		if (!(control.GetType() == typeof(setLabelControl)))
		{
			return;
		}
		if (((setLabelControl)control).EditValue.GetType() == typeof(drawPropertiesType))
		{
			F_DrawPropertiesType f_DrawPropertiesType = new F_DrawPropertiesType();
			f_DrawPropertiesType.Value = (drawPropertiesType)((setLabelControl)control).EditValue;
			f_DrawPropertiesType.Init();
			f_DrawPropertiesType.StartPosition = FormStartPosition.CenterParent;
			f_DrawPropertiesType.ShowDialog(base.Parent);
			((setLabelControl)control).EditValue = f_DrawPropertiesType.Value;
			((setLabelControl)control).Text = ((drawPropertiesType)((setLabelControl)control).EditValue).ToString();
			((setLabelControl)control).BackColor = ((drawPropertiesType)((setLabelControl)control).EditValue).Color;
			((setLabelControl)control).ForeColor = buImage.InvertColor(((setLabelControl)control).BackColor);
			cParameter5 cParameter6 = new cParameter5(control.Tag.ToString(), ((setLabelControl)control).EditValue);
			buSerilization5.SetClassVariable(ref ClassObject, cParameter6);
			if (classViewerEventHandler5_0 != null)
			{
				classViewerEventHandler5_0(this, ((setLabelControl)control).EditValue, cParameter6);
			}
		}
		if (((setLabelControl)control).EditValue.GetType() == typeof(ColorType))
		{
			F_ColorType f_ColorType = new F_ColorType();
			f_ColorType.Value = (ColorType)((setLabelControl)control).EditValue;
			f_ColorType.Init();
			f_ColorType.StartPosition = FormStartPosition.CenterParent;
			f_ColorType.ShowDialog(base.Parent);
			((setLabelControl)control).EditValue = f_ColorType.Value;
			((setLabelControl)control).Text = ((ColorType)((setLabelControl)control).EditValue).ToString();
			((setLabelControl)control).BackColor = ((ColorType)((setLabelControl)control).EditValue).Color;
			((setLabelControl)control).ForeColor = buImage.InvertColor(((setLabelControl)control).BackColor);
			cParameter5 cParameter7 = new cParameter5(control.Tag.ToString(), ((setLabelControl)control).EditValue);
			buSerilization5.SetClassVariable(ref ClassObject, cParameter7);
			if (classViewerEventHandler5_0 != null)
			{
				classViewerEventHandler5_0(this, ((setLabelControl)control).EditValue, cParameter7);
			}
		}
		if (((setLabelControl)control).EditValue.GetType() == typeof(ColorDrawType))
		{
			F_ColorDrawType f_ColorDrawType = new F_ColorDrawType();
			f_ColorDrawType.Value = (ColorDrawType)((setLabelControl)control).EditValue;
			f_ColorDrawType.Init();
			f_ColorDrawType.StartPosition = FormStartPosition.CenterParent;
			f_ColorDrawType.ShowDialog(base.Parent);
			((setLabelControl)control).EditValue = f_ColorDrawType.Value;
			((setLabelControl)control).Text = ((ColorDrawType)((setLabelControl)control).EditValue).ToString();
			((setLabelControl)control).BackColor = ((ColorDrawType)((setLabelControl)control).EditValue).Color;
			((setLabelControl)control).ForeColor = buImage.InvertColor(((setLabelControl)control).BackColor);
			cParameter5 cParameter8 = new cParameter5(control.Tag.ToString(), ((setLabelControl)control).EditValue);
			buSerilization5.SetClassVariable(ref ClassObject, cParameter8);
			if (classViewerEventHandler5_0 != null)
			{
				classViewerEventHandler5_0(this, ((setLabelControl)control).EditValue, cParameter8);
			}
		}
		if (((setLabelControl)control).EditValue.GetType() == typeof(MouseKeyboardConfigration))
		{
			F_MouseKeyboardConfig f_MouseKeyboardConfig = new F_MouseKeyboardConfig();
			f_MouseKeyboardConfig.Value = (MouseKeyboardConfigration)((setLabelControl)control).EditValue;
			f_MouseKeyboardConfig.Init();
			f_MouseKeyboardConfig.StartPosition = FormStartPosition.CenterParent;
			f_MouseKeyboardConfig.ShowDialog(base.Parent);
			((setLabelControl)control).EditValue = f_MouseKeyboardConfig.Value;
			((setLabelControl)control).Text = ((MouseKeyboardConfigration)((setLabelControl)control).EditValue).ToString();
			cParameter5 cParameter9 = new cParameter5(control.Tag.ToString(), ((setLabelControl)control).EditValue);
			buSerilization5.SetClassVariable(ref ClassObject, cParameter9);
			if (classViewerEventHandler5_0 != null)
			{
				classViewerEventHandler5_0(this, ((setLabelControl)control).EditValue, cParameter9);
			}
		}
		if (((setLabelControl)control).EditValue.GetType() == typeof(EntityResolution))
		{
			F_EntitiyResolution f_EntitiyResolution = new F_EntitiyResolution();
			f_EntitiyResolution.Value = (EntityResolution)((setLabelControl)control).EditValue;
			f_EntitiyResolution.Init();
			f_EntitiyResolution.StartPosition = FormStartPosition.CenterParent;
			f_EntitiyResolution.ShowDialog(base.Parent);
			((setLabelControl)control).EditValue = f_EntitiyResolution.Value;
			((setLabelControl)control).Text = ((EntityResolution)((setLabelControl)control).EditValue).ToString();
			cParameter5 cParameter10 = new cParameter5(control.Tag.ToString(), ((setLabelControl)control).EditValue);
			buSerilization5.SetClassVariable(ref ClassObject, cParameter10);
			if (classViewerEventHandler5_0 != null)
			{
				classViewerEventHandler5_0(this, ((setLabelControl)control).EditValue, cParameter10);
			}
		}
		if (((setLabelControl)control).EditValue.GetType() == typeof(SolidItemDisplay))
		{
			F_SolidItemDisplay f_SolidItemDisplay = new F_SolidItemDisplay();
			f_SolidItemDisplay.Value = (SolidItemDisplay)((setLabelControl)control).EditValue;
			f_SolidItemDisplay.Init();
			f_SolidItemDisplay.StartPosition = FormStartPosition.CenterParent;
			f_SolidItemDisplay.ShowDialog(base.Parent);
			((setLabelControl)control).EditValue = f_SolidItemDisplay.Value;
			((setLabelControl)control).Text = ((SolidItemDisplay)((setLabelControl)control).EditValue).ToString();
			cParameter5 cParameter11 = new cParameter5(control.Tag.ToString(), ((setLabelControl)control).EditValue);
			buSerilization5.SetClassVariable(ref ClassObject, cParameter11);
			if (classViewerEventHandler5_0 != null)
			{
				classViewerEventHandler5_0(this, ((setLabelControl)control).EditValue, cParameter11);
			}
		}
		if (((setLabelControl)control).EditValue.GetType() == typeof(Pnt2D))
		{
			F_Pnt3D f_Pnt3D = new F_Pnt3D();
			f_Pnt3D.Mode2D = true;
			f_Pnt3D.Value = buConversion.Pnt2DToPnt3D((Pnt2D)((setLabelControl)control).EditValue);
			f_Pnt3D.Init();
			f_Pnt3D.StartPosition = FormStartPosition.CenterParent;
			f_Pnt3D.ShowDialog(base.Parent);
			((setLabelControl)control).EditValue = buConversion.Pnt3DToPnt2D(f_Pnt3D.Value);
			((setLabelControl)control).Text = ((Pnt2D)((setLabelControl)control).EditValue).ToString();
			cParameter5 cParameter12 = new cParameter5(control.Tag.ToString(), ((setLabelControl)control).EditValue);
			buSerilization5.SetClassVariable(ref ClassObject, cParameter12);
			if (classViewerEventHandler5_0 != null)
			{
				classViewerEventHandler5_0(this, ((setLabelControl)control).EditValue, cParameter12);
			}
		}
		if (((setLabelControl)control).EditValue.GetType() == typeof(Pnt3D))
		{
			F_Pnt3D f_Pnt3D2 = new F_Pnt3D();
			f_Pnt3D2.Value = (Pnt3D)((setLabelControl)control).EditValue;
			f_Pnt3D2.Init();
			f_Pnt3D2.StartPosition = FormStartPosition.CenterParent;
			f_Pnt3D2.ShowDialog(base.Parent);
			((setLabelControl)control).EditValue = f_Pnt3D2.Value;
			((setLabelControl)control).Text = ((Pnt3D)((setLabelControl)control).EditValue).ToString();
			cParameter5 cParameter13 = new cParameter5(control.Tag.ToString(), ((setLabelControl)control).EditValue);
			buSerilization5.SetClassVariable(ref ClassObject, cParameter13);
			if (classViewerEventHandler5_0 != null)
			{
				classViewerEventHandler5_0(this, ((setLabelControl)control).EditValue, cParameter13);
			}
		}
		if (((setLabelControl)control).EditValue.GetType() == typeof(Point))
		{
			F_Pnt3D f_Pnt3D3 = new F_Pnt3D();
			f_Pnt3D3.IntergerMode = true;
			f_Pnt3D3.Mode2D = true;
			f_Pnt3D3.Value = buConversion.PointToPnt3D((Point)((setLabelControl)control).EditValue);
			f_Pnt3D3.Init();
			f_Pnt3D3.StartPosition = FormStartPosition.CenterParent;
			f_Pnt3D3.ShowDialog(base.Parent);
			((setLabelControl)control).EditValue = buConversion.Pnt3DToPoint(f_Pnt3D3.Value);
			((setLabelControl)control).Text = buConversion.PointToString((Point)((setLabelControl)control).EditValue);
			cParameter5 cParameter14 = new cParameter5(control.Tag.ToString(), ((setLabelControl)control).EditValue);
			buSerilization5.SetClassVariable(ref ClassObject, cParameter14);
			if (classViewerEventHandler5_0 != null)
			{
				classViewerEventHandler5_0(this, ((setLabelControl)control).EditValue, cParameter14);
			}
		}
		if (((setLabelControl)control).EditValue.GetType() == typeof(PointF))
		{
			F_Pnt3D f_Pnt3D4 = new F_Pnt3D();
			f_Pnt3D4.Mode2D = true;
			f_Pnt3D4.Value = buConversion.PointFToPnt3D((PointF)((setLabelControl)control).EditValue);
			f_Pnt3D4.Init();
			f_Pnt3D4.StartPosition = FormStartPosition.CenterParent;
			f_Pnt3D4.ShowDialog(base.Parent);
			((setLabelControl)control).EditValue = buConversion.Pnt3DToPointF(f_Pnt3D4.Value);
			((setLabelControl)control).Text = buConversion.PointFToString((PointF)((setLabelControl)control).EditValue);
			cParameter5 cParameter15 = new cParameter5(control.Tag.ToString(), ((setLabelControl)control).EditValue);
			buSerilization5.SetClassVariable(ref ClassObject, cParameter15);
			if (classViewerEventHandler5_0 != null)
			{
				classViewerEventHandler5_0(this, ((setLabelControl)control).EditValue, cParameter15);
			}
		}
		if (((setLabelControl)control).EditValue.GetType() == typeof(Size))
		{
			F_Size f_Size = new F_Size();
			f_Size.IntergerMode = true;
			f_Size.Value = buConversion.SizeToSizeF((Size)((setLabelControl)control).EditValue);
			f_Size.Init();
			f_Size.StartPosition = FormStartPosition.CenterParent;
			f_Size.ShowDialog(base.Parent);
			((setLabelControl)control).EditValue = buConversion.SizeFToSize(f_Size.Value);
			((setLabelControl)control).Text = buConversion.SizeToString((Size)((setLabelControl)control).EditValue);
			cParameter5 cParameter16 = new cParameter5(control.Tag.ToString(), ((setLabelControl)control).EditValue);
			buSerilization5.SetClassVariable(ref ClassObject, cParameter16);
			if (classViewerEventHandler5_0 != null)
			{
				classViewerEventHandler5_0(this, ((setLabelControl)control).EditValue, cParameter16);
			}
		}
		if (((setLabelControl)control).EditValue.GetType() == typeof(SizeF))
		{
			F_Size f_Size2 = new F_Size();
			f_Size2.Value = (SizeF)((setLabelControl)control).EditValue;
			f_Size2.Init();
			f_Size2.StartPosition = FormStartPosition.CenterParent;
			f_Size2.ShowDialog(base.Parent);
			((setLabelControl)control).EditValue = f_Size2.Value;
			((setLabelControl)control).Text = buConversion.SizeFToString((SizeF)((setLabelControl)control).EditValue);
			cParameter5 cParameter17 = new cParameter5(control.Tag.ToString(), ((setLabelControl)control).EditValue);
			buSerilization5.SetClassVariable(ref ClassObject, cParameter17);
			if (classViewerEventHandler5_0 != null)
			{
				classViewerEventHandler5_0(this, ((setLabelControl)control).EditValue, cParameter17);
			}
		}
		if (!(((setLabelControl)control).EditValue.GetType() == typeof(Font)))
		{
			return;
		}
		FontDialog fontDialog = new FontDialog();
		fontDialog.Font = (Font)((setLabelControl)control).EditValue;
		if (fontDialog.ShowDialog() == DialogResult.OK)
		{
			((setLabelControl)control).EditValue = fontDialog.Font;
			((setLabelControl)control).Text = ((Font)((setLabelControl)control).EditValue).Name + " - " + ((Font)((setLabelControl)control).EditValue).Size;
			cParameter5 cParameter18 = new cParameter5(control.Tag.ToString(), ((setLabelControl)control).EditValue);
			buSerilization5.SetClassVariable(ref ClassObject, cParameter18);
			if (classViewerEventHandler5_0 != null)
			{
				classViewerEventHandler5_0(this, ((setLabelControl)control).EditValue, cParameter18);
			}
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		try
		{
			if (AppBool.TouchPad)
			{
				if (sender.GetType() == typeof(TextBox))
				{
					TextBox textBox = new TextBox();
					textBox = (TextBox)sender;
					buControlCommands.ShowKeyPad(OwnerForm, textBox, TouchPayStyle);
				}
				if (sender.GetType() == typeof(NumericUpDown))
				{
					NumericUpDown numericUpDown = new NumericUpDown();
					numericUpDown = (NumericUpDown)sender;
					buControlCommands.ShowKeyPad(OwnerForm, numericUpDown, TouchPayStyle);
				}
				if (sender.GetType().BaseType == typeof(NumericUpDown))
				{
					NumericUpDown numericUpDown2 = new NumericUpDown();
					numericUpDown2 = (NumericUpDown)sender;
					buControlCommands.ShowKeyPad(OwnerForm, numericUpDown2, TouchPayStyle);
				}
				if (sender.GetType().BaseType == typeof(TextBox))
				{
					TextBox textBox2 = new TextBox();
					textBox2 = (TextBox)sender;
					buControlCommands.ShowKeyPad(OwnerForm, textBox2, TouchPayStyle);
				}
			}
		}
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: true);
		}
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == button_0.Name && eventHandler_0 != null)
		{
			eventHandler_0(this, e);
		}
		if (control.Name == button_1.Name && eventHandler_1 != null)
		{
			eventHandler_1(this, e);
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
