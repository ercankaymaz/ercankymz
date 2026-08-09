using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using ns71;

namespace buEyeBaseVer5.Forms.Shape;

public class F_ShapeEdit : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public bool ShowPolar = true;

	public planeBoxNames refPlane = planeBoxNames.Top;

	private Color color_0 = Color.LightBlue;

	private Color color_1 = Color.Gainsboro;

	public ShapeEdit Edit = new ShapeEdit();

	internal IContainer icontainer_0 = null;

	public Button btn_polararray;

	public Button btn_lineararray;

	public Button btn_mirrorver;

	public Button btn_mirrorhor;

	internal ImageList imageList_0;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal CheckBox checkBox_0;

	internal Panel panel_0;

	internal Panel panel_1;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_1;

	internal Label label_2;

	internal NumericUpDown numericUpDown_2;

	internal Label label_3;

	internal NumericUpDown numericUpDown_3;

	internal CheckBox checkBox_1;

	internal Panel panel_2;

	internal Label label_4;

	internal NumericUpDown numericUpDown_4;

	public Button btn_rotate;

	internal Panel panel_3;

	internal Label label_5;

	internal NumericUpDown numericUpDown_5;

	internal Label label_6;

	internal NumericUpDown numericUpDown_6;

	internal CheckBox checkBox_2;

	public Button btn_ok;

	internal ImageList imageList_1;

	public Button btn_cancel;

	internal Panel panel_4;

	internal RadioButton radioButton_2;

	internal RadioButton radioButton_3;

	internal Panel panel_5;

	internal Panel panel_6;

	internal RadioButton radioButton_4;

	internal RadioButton radioButton_5;

	internal NumericUpDown numericUpDown_7;

	internal Label label_7;

	internal RadioButton radioButton_6;

	internal Panel panel_7;

	public F_ShapeEdit()
	{
		Class186.smethod_706(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		Properties.Result = DialogResult.None;
		base.TopMost = Properties.TopMost;
		base.StartPosition = Properties.FormPosition;
		base.AutoScaleMode = Properties.ScaleFromMode;
		if (Properties.Height > 10)
		{
			base.Height = Properties.Height;
		}
		if (Properties.Width > 10)
		{
			base.Width = Properties.Width;
		}
		numericUpDown_4.Value = (decimal)Edit.RotateDegree;
		numericUpDown_3.Value = Edit.ArrayData.LineerXCount;
		numericUpDown_2.Value = (decimal)Edit.ArrayData.LineerXDistance;
		numericUpDown_1.Value = Edit.ArrayData.LineerYCount;
		numericUpDown_0.Value = (decimal)Edit.ArrayData.LineerYDistance;
		numericUpDown_6.Value = Edit.ArrayData.CircularCount;
		numericUpDown_5.Value = (decimal)Edit.ArrayData.CircularAngle;
		checkBox_1.Checked = Edit.ArrayData.LineerEnable;
		checkBox_2.Checked = Edit.ArrayData.CircularEnable;
		checkBox_0.Checked = Edit.MirrorData.MirrorEnable;
		panel_3.Visible = ShowPolar;
		if (!ShowPolar)
		{
			checkBox_2.Checked = false;
		}
		if (Edit.MirrorData.MirrorAxis != MirrorAxisXYType.X)
		{
			radioButton_0.Checked = true;
		}
		else
		{
			radioButton_1.Checked = true;
		}
		if (Edit.MirrorData.MirrorLocation != MinCenterMaxType.Min)
		{
			if (Edit.MirrorData.MirrorLocation != MinCenterMaxType.Center)
			{
				if (Edit.MirrorData.MirrorLocation == MinCenterMaxType.Max)
				{
					radioButton_4.Checked = false;
					radioButton_5.Checked = false;
					radioButton_6.Checked = true;
				}
			}
			else
			{
				radioButton_4.Checked = false;
				radioButton_5.Checked = true;
				radioButton_6.Checked = false;
			}
		}
		else
		{
			radioButton_4.Checked = true;
			radioButton_5.Checked = false;
			radioButton_6.Checked = false;
		}
		if (Edit.MirrorData.MirrorMode != MirrorModeType.FromCenter)
		{
			radioButton_2.Checked = false;
			radioButton_3.Checked = true;
		}
		else
		{
			radioButton_2.Checked = true;
			radioButton_3.Checked = false;
		}
		LangueageSet();
		Class186.smethod_826(this);
		Properties.Inited = true;
	}

	public void LangueageSet()
	{
		Text = buLangTranslate.preDef.Edit;
		label_4.Text = buLangTranslate.preDef.Degree;
		if ((refPlane == planeBoxNames.Top) | (refPlane == planeBoxNames.Bottom) | (refPlane == planeBoxNames.Free))
		{
			label_3.Text = "X " + buLangTranslate.preDef.Count;
			label_2.Text = "X " + buLangTranslate.preDef.Distance;
			label_1.Text = "Y " + buLangTranslate.preDef.Count;
			label_0.Text = "Y " + buLangTranslate.preDef.Distance;
		}
		if ((refPlane == planeBoxNames.Front) | (refPlane == planeBoxNames.Back))
		{
			label_3.Text = "X " + buLangTranslate.preDef.Count;
			label_2.Text = "X " + buLangTranslate.preDef.Distance;
			label_1.Text = "Z " + buLangTranslate.preDef.Count;
			label_0.Text = "Z " + buLangTranslate.preDef.Distance;
		}
		if ((refPlane == planeBoxNames.Left) | (refPlane == planeBoxNames.Right))
		{
			label_3.Text = "Y " + buLangTranslate.preDef.Count;
			label_2.Text = "Y " + buLangTranslate.preDef.Distance;
			label_1.Text = "Z " + buLangTranslate.preDef.Count;
			label_0.Text = "Z " + buLangTranslate.preDef.Distance;
		}
		label_7.Text = buLangTranslate.preDef.Distance;
		label_6.Text = buLangTranslate.preDef.Count;
		label_5.Text = buLangTranslate.preDef.Degree;
		radioButton_2.Text = buLangTranslate.preDef.Center;
		radioButton_3.Text = buLangTranslate.preDef.Free;
		radioButton_1.Text = buLangTranslate.preDef.Horizontal;
		radioButton_6.Text = buLangTranslate.preDef.Max;
		radioButton_5.Text = buLangTranslate.preDef.Mid;
		radioButton_4.Text = buLangTranslate.preDef.Min;
		radioButton_0.Text = buLangTranslate.preDef.Vertical;
		checkBox_1.Text = buLangTranslate.preDef.Linear + " " + buLangTranslate.preDef.Array;
		checkBox_0.Text = buLangTranslate.preDef.Mirror;
		checkBox_2.Text = buLangTranslate.preDef.Polar + " " + buLangTranslate.preDef.Array;
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (Properties.Result != DialogResult.OK)
		{
			e.Cancel = true;
			Properties.Result = DialogResult.Cancel;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	public void Apply()
	{
		Edit.RotateDegree = (double)numericUpDown_4.Value;
		Edit.ArrayData.LineerXCount = (int)numericUpDown_3.Value;
		Edit.ArrayData.LineerXDistance = (double)numericUpDown_2.Value;
		Edit.ArrayData.LineerYCount = (int)numericUpDown_1.Value;
		Edit.ArrayData.LineerYDistance = (double)numericUpDown_0.Value;
		Edit.ArrayData.CircularCount = (int)numericUpDown_6.Value;
		Edit.ArrayData.CircularAngle = (double)numericUpDown_5.Value;
		Edit.ArrayData.LineerEnable = checkBox_1.Checked;
		Edit.ArrayData.CircularEnable = checkBox_2.Checked;
		Edit.MirrorData.MirrorEnable = checkBox_0.Checked;
		if (!radioButton_3.Checked)
		{
			Edit.MirrorData.MirrorMode = MirrorModeType.FromCenter;
		}
		else
		{
			Edit.MirrorData.MirrorMode = MirrorModeType.FreeMirror;
		}
		if (!radioButton_1.Checked)
		{
			Edit.MirrorData.MirrorAxis = MirrorAxisXYType.X;
		}
		else
		{
			Edit.MirrorData.MirrorAxis = MirrorAxisXYType.Y;
		}
		if (!radioButton_4.Checked)
		{
			if (!radioButton_5.Checked)
			{
				Edit.MirrorData.MirrorLocation = MinCenterMaxType.Max;
			}
			else
			{
				Edit.MirrorData.MirrorLocation = MinCenterMaxType.Center;
			}
		}
		else
		{
			Edit.MirrorData.MirrorLocation = MinCenterMaxType.Min;
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_mirrorhor.Name)
		{
			Edit.MirrorData.MirrorAxis = MirrorAxisXYType.X;
			if (Edit.MirrorData.MirrorAxis != MirrorAxisXYType.X)
			{
				radioButton_0.Checked = true;
			}
			else
			{
				radioButton_1.Checked = true;
			}
		}
		if (control.Name == btn_mirrorver.Name)
		{
			Edit.MirrorData.MirrorAxis = MirrorAxisXYType.Y;
			if (Edit.MirrorData.MirrorAxis != MirrorAxisXYType.X)
			{
				radioButton_0.Checked = true;
			}
			else
			{
				radioButton_1.Checked = true;
			}
		}
		if (control.Name == btn_lineararray.Name)
		{
			if (checkBox_1.Checked)
			{
				Edit.ArrayData.LineerEnable = false;
				checkBox_1.Checked = false;
			}
			else
			{
				Edit.ArrayData.LineerEnable = true;
				checkBox_1.Checked = true;
			}
		}
		if (control.Name == btn_polararray.Name)
		{
			if (checkBox_2.Checked)
			{
				Edit.ArrayData.CircularEnable = false;
				checkBox_2.Checked = false;
			}
			else
			{
				Edit.ArrayData.CircularEnable = true;
				checkBox_2.Checked = true;
			}
		}
		if (control.Name == btn_ok.Name)
		{
			Apply();
			Properties.Result = DialogResult.OK;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (control.Name == btn_cancel.Name)
		{
			Properties.Result = DialogResult.Cancel;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		Class186.smethod_826(this);
	}

	internal void method_3(object sender, EventArgs e)
	{
		Class186.smethod_826(this);
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
