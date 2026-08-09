using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using buClass;
using buControls.Components;
using buControls.Controls;
using buControls.DialogBox;
using buCore;
using ns71;

namespace buEyeBaseVer5.Forms.Controls;

public class F_ControlUICombo : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public hmiUISettings Settings = new hmiUISettings();

	internal IContainer icontainer_0 = null;

	public buButton btn_close;

	public buGround buGround1;

	public ImageList IC32;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal buControlDisplaySet buControlDisplaySet_0;

	internal buComboBox buComboBox_0;

	internal buComboBox buComboBox_1;

	public buSpin spn_geometryrad;

	internal buControlDisplaySet buControlDisplaySet_1;

	public buSpin spn_arrowwidth;

	internal buLabel buLabel_0;

	internal buLabel buLabel_1;

	internal buLabel buLabel_2;

	internal buLabel buLabel_3;

	internal buLabel buLabel_4;

	internal buLabel buLabel_5;

	public buComboBox Cmb_Ref;

	public F_ControlUICombo()
	{
		Class186.smethod_107(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			base.Height = PropertiesForm.Height;
		}
		if (PropertiesForm.Width > 10)
		{
			base.Width = PropertiesForm.Width;
		}
		base.TopMost = PropertiesForm.TopMost;
		base.StartPosition = PropertiesForm.FormPosition;
		buComboBox_0.Items.Clear();
		buComboBox_0.Items.AddRange(Enum.GetValues(typeof(ContentAlignment)).Cast<object>().ToArray());
		buComboBox_1.Items.Clear();
		buComboBox_1.Items.AddRange(Enum.GetValues(typeof(ShapeType)).Cast<object>().ToArray());
		buControlDisplaySet_1.Display = Settings.Display;
		buControlDisplaySet_0.Display = Settings.Caption;
		spn_geometryrad.Value = Settings.Parameters.GeometryArcDiameer;
		buComboBox_1.SelectedItem = Settings.Parameters.GeometryType;
		buComboBox_0.SelectedItem = Settings.Parameters.ImageAlignment;
		spn_arrowwidth.Value = Settings.Parameters.ObjectWidth;
		buLabel_1.Display.BackColor = Settings.Parameters.ArrowColor;
		buLabel_5.Display.BackColor = Settings.Parameters.LineColor;
		buLabel_3.Display.BackColor = Settings.Parameters.DropColor;
		Cmb_Ref.Geometry.ShapeMode = Settings.Parameters.GeometryType;
		Cmb_Ref.Geometry.ArcDiameter = Settings.Parameters.GeometryArcDiameer;
		Cmb_Ref.Combo.ArrowButtonWidth = Settings.Parameters.ObjectWidth;
		Cmb_Ref.Combo.ValueColor = buControlDisplaySet_1.Display.BackColor;
		Cmb_Ref.Display = buControlDisplaySet_1.Display;
		Cmb_Ref.Caption.Display = buControlDisplaySet_0.Display;
		Cmb_Ref.Combo.ArrowLineColor = Settings.Parameters.LineColor;
		Cmb_Ref.Combo.ArrowColor = Settings.Parameters.ArrowColor;
		Cmb_Ref.Combo.DropBoxColor = Settings.Parameters.DropColor;
		buControlDisplaySet_0.UpdateControl();
		buControlDisplaySet_1.UpdateControl();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		Class186.smethod_501(this);
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (PropertiesForm.Result != DialogResult.OK)
		{
			e.Cancel = true;
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	public void Apply()
	{
	}

	internal void method_1(object sender, EventArgs e)
	{
		buLabel buLabel2 = sender as buLabel;
		if (buLabel2.Name == buLabel_1.Name)
		{
			Color cColor = buLabel2.Display.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor) == DialogResult.OK)
			{
				buLabel2.Display.BackColor = cColor;
				buLabel2.Text = buImage.GetColorKnownName(cColor);
				Cmb_Ref.Combo.ArrowColor = cColor;
			}
		}
		if (buLabel2.Name == buLabel_5.Name)
		{
			Color cColor2 = buLabel2.Display.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor2) == DialogResult.OK)
			{
				buLabel2.Display.BackColor = cColor2;
				buLabel2.Text = buImage.GetColorKnownName(cColor2);
				Cmb_Ref.Combo.ArrowLineColor = cColor2;
			}
		}
		if (buLabel2.Name == buLabel_3.Name)
		{
			Color cColor3 = buLabel2.Display.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor3) == DialogResult.OK)
			{
				buLabel2.Display.BackColor = cColor3;
				buLabel2.Text = buImage.GetColorKnownName(cColor3);
				Cmb_Ref.Combo.DropBoxColor = cColor3;
			}
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		try
		{
			Control control = sender as Control;
			if (!(control.Name == btn_ok.Name))
			{
				if ((control.Name == btn_close.Name) | (control.Name == btn_cancel.Name))
				{
					PropertiesForm.Result = DialogResult.Cancel;
					if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
					{
						Dispose();
					}
					if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
					{
						base.Visible = false;
					}
				}
			}
			else
			{
				Apply();
				PropertiesForm.Result = DialogResult.OK;
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					Dispose();
				}
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
				{
					base.Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void spn_Leave(object sender, EventArgs e)
	{
	}

	internal void method_3(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == buControlDisplaySet_0.Name)
		{
			Cmb_Ref.Caption.Display = buControlDisplaySet_0.Display;
		}
		if (control.Name == buControlDisplaySet_1.Name)
		{
			Cmb_Ref.Display = buControlDisplaySet_1.Display;
		}
		Cmb_Ref.BackColor = Color.Transparent;
		Cmb_Ref.Combo.ValueColor = Cmb_Ref.Display.BackColor;
		Cmb_Ref.Invalidate();
	}

	internal void method_4(object object_0, double double_0)
	{
		Control control = object_0 as Control;
		if (control.Name == spn_geometryrad.Name)
		{
			Cmb_Ref.Geometry.ArcDiameter = (int)spn_geometryrad.Value;
			Settings.Parameters.GeometryArcDiameer = (int)spn_geometryrad.Value;
		}
		if (control.Name == spn_arrowwidth.Name)
		{
			Cmb_Ref.Combo.ArrowButtonWidth = (int)spn_arrowwidth.Value;
			Settings.Parameters.ObjectWidth = (int)spn_arrowwidth.Value;
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == buComboBox_1.Name)
		{
			Enum.TryParse<ShapeType>(buComboBox_1.SelectedItem.ToString(), out var result);
			Cmb_Ref.Geometry.ShapeMode = result;
			Settings.Parameters.GeometryType = result;
		}
		if (control.Name == buComboBox_0.Name)
		{
			Enum.TryParse<ContentAlignment>(buComboBox_0.SelectedItem.ToString(), out var result2);
			Settings.Parameters.ImageAlignment = result2;
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
