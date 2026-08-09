using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.Forms.WinControlForms.ClassForm;
using buCore;
using buEyeBaseVer5.Forms.ClassForm;
using ns71;

namespace buEyeBaseVer5.ClassViewer;

public class buClassViewerColor5 : UserControl
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

	public buClassViewerColor5()
	{
		Class186.smethod_315(this);
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
			if (type == typeof(ColorType))
			{
				ColorType colorType = new ColorType();
				colorType = (ColorType)Vars[i].Value;
				bool result = false;
				bool.TryParse(Vars[i].ValueAsString, out result);
				setLabelControl_0 = new setLabelControl();
				ref setLabelControl reference = ref setLabelControl_0;
				string string_ = colorType.ToString();
				string name = Vars[i].Name;
				Color color = colorType.Color;
				Class186.smethod_166(ref reference, this, string_, color, name);
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
			if (type == typeof(ColorDrawType))
			{
				ColorDrawType colorDrawType = new ColorDrawType();
				colorDrawType = (ColorDrawType)Vars[i].Value;
				bool result2 = false;
				bool.TryParse(Vars[i].ValueAsString, out result2);
				setLabelControl_0 = new setLabelControl();
				ref setLabelControl reference = ref setLabelControl_0;
				string string_ = colorDrawType.ToString();
				string name = Vars[i].Name;
				Color color = colorDrawType.Color;
				Class186.smethod_166(ref reference, this, string_, color, name);
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
