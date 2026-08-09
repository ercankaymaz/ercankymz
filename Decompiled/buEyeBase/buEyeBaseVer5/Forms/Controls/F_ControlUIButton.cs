using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using buClass;
using buControls.Components;
using buControls.Controls;
using ns71;

namespace buEyeBaseVer5.Forms.Controls;

public class F_ControlUIButton : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public buButton refButton = null;

	internal IContainer icontainer_0 = null;

	public buButton btn_close;

	public buGround buGround1;

	public ImageList IC32;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal buControlDisplaySet buControlDisplaySet_0;

	public buButton btn_ref;

	internal buControlDisplaySet buControlDisplaySet_1;

	internal buControlDisplaySet buControlDisplaySet_2;

	internal buComboBox buComboBox_0;

	internal buComboBox buComboBox_1;

	public buSpin spn_geometryrad;

	public buSpin spn_displaytoovertone;

	public buButton btn_displaytoover;

	public buSpin spn_displaytodowntone;

	public buButton btn_displaytodown;

	public F_ControlUIButton()
	{
		Class186.smethod_490(this);
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
		if (refButton != null)
		{
			buControlDisplaySet_0.Display = refButton.Display;
			buControlDisplaySet_1.Display = refButton.ButtonDownDisplay;
			buControlDisplaySet_2.Display = refButton.ButtonOverDisplay;
			spn_geometryrad.Value = refButton.Geometry.ArcDiameter;
			buComboBox_1.SelectedItem = refButton.Geometry.ShapeMode;
			buComboBox_0.SelectedItem = refButton.ImageAlign;
			btn_ref.Display = buControlDisplaySet_0.Display;
			btn_ref.ButtonDownDisplay = buControlDisplaySet_1.Display;
			btn_ref.ButtonOverDisplay = buControlDisplaySet_2.Display;
			buControlDisplaySet_0.UpdateControl();
			buControlDisplaySet_1.UpdateControl();
			buControlDisplaySet_2.UpdateControl();
		}
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		Class186.smethod_84(this);
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
		try
		{
			Control control = sender as Control;
			if (!(control.Name == btn_ok.Name))
			{
				if (!((control.Name == btn_close.Name) | (control.Name == btn_cancel.Name)))
				{
					if (!(control.Name == btn_displaytoover.Name))
					{
						if (control.Name == btn_displaytodown.Name)
						{
							buControlDisplaySet_1.Display.BackColor = buImage5.ColorToneChange(buControlDisplaySet_0.Display.BackColor, spn_displaytodowntone.Value);
							buControlDisplaySet_1.Display.LineerGradient.FirstColor = buImage5.ColorToneChange(buControlDisplaySet_0.Display.LineerGradient.FirstColor, spn_displaytodowntone.Value);
							buControlDisplaySet_1.Display.LineerGradient.SecondColor = buImage5.ColorToneChange(buControlDisplaySet_0.Display.LineerGradient.SecondColor, spn_displaytodowntone.Value);
							buControlDisplaySet_1.Display.PathGradient.CenterColor = buImage5.ColorToneChange(buControlDisplaySet_0.Display.PathGradient.CenterColor, spn_displaytodowntone.Value);
							buControlDisplaySet_1.Display.PathGradient.SurroundColor = buImage5.ColorToneChange(buControlDisplaySet_0.Display.PathGradient.SurroundColor, spn_displaytodowntone.Value);
							buControlDisplaySet_1.Display.PathInterpolatedGradient.FirstColor = buImage5.ColorToneChange(buControlDisplaySet_0.Display.PathInterpolatedGradient.FirstColor, spn_displaytodowntone.Value);
							buControlDisplaySet_1.Display.PathInterpolatedGradient.SecondColor = buImage5.ColorToneChange(buControlDisplaySet_0.Display.PathInterpolatedGradient.SecondColor, spn_displaytodowntone.Value);
							buControlDisplaySet_1.Display.PathInterpolatedGradient.ThirdColor = buImage5.ColorToneChange(buControlDisplaySet_0.Display.PathInterpolatedGradient.ThirdColor, spn_displaytodowntone.Value);
							buControlDisplaySet_1.Display.PathInterpolatedGradient.FourthColor = buImage5.ColorToneChange(buControlDisplaySet_0.Display.PathInterpolatedGradient.FourthColor, spn_displaytodowntone.Value);
							buControlDisplaySet_1.UpdateControl();
							btn_ref.Invalidate();
						}
					}
					else
					{
						buControlDisplaySet_2.Display.BackColor = buImage5.ColorToneChange(buControlDisplaySet_0.Display.BackColor, spn_displaytoovertone.Value);
						buControlDisplaySet_2.Display.LineerGradient.FirstColor = buImage5.ColorToneChange(buControlDisplaySet_0.Display.LineerGradient.FirstColor, spn_displaytoovertone.Value);
						buControlDisplaySet_2.Display.LineerGradient.SecondColor = buImage5.ColorToneChange(buControlDisplaySet_0.Display.LineerGradient.SecondColor, spn_displaytoovertone.Value);
						buControlDisplaySet_2.Display.PathGradient.CenterColor = buImage5.ColorToneChange(buControlDisplaySet_0.Display.PathGradient.CenterColor, spn_displaytoovertone.Value);
						buControlDisplaySet_2.Display.PathGradient.SurroundColor = buImage5.ColorToneChange(buControlDisplaySet_0.Display.PathGradient.SurroundColor, spn_displaytoovertone.Value);
						buControlDisplaySet_2.Display.PathInterpolatedGradient.FirstColor = buImage5.ColorToneChange(buControlDisplaySet_0.Display.PathInterpolatedGradient.FirstColor, spn_displaytoovertone.Value);
						buControlDisplaySet_2.Display.PathInterpolatedGradient.SecondColor = buImage5.ColorToneChange(buControlDisplaySet_0.Display.PathInterpolatedGradient.SecondColor, spn_displaytoovertone.Value);
						buControlDisplaySet_2.Display.PathInterpolatedGradient.ThirdColor = buImage5.ColorToneChange(buControlDisplaySet_0.Display.PathInterpolatedGradient.ThirdColor, spn_displaytoovertone.Value);
						buControlDisplaySet_2.Display.PathInterpolatedGradient.FourthColor = buImage5.ColorToneChange(buControlDisplaySet_0.Display.PathInterpolatedGradient.FourthColor, spn_displaytoovertone.Value);
						buControlDisplaySet_2.UpdateControl();
						btn_ref.Invalidate();
					}
				}
				else
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

	internal void method_2(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == buControlDisplaySet_0.Name)
		{
			btn_ref.Display = buControlDisplaySet_0.Display;
		}
		if (control.Name == buControlDisplaySet_1.Name)
		{
			btn_ref.ButtonDownDisplay = buControlDisplaySet_1.Display;
		}
		if (control.Name == buControlDisplaySet_2.Name)
		{
			btn_ref.ButtonOverDisplay = buControlDisplaySet_2.Display;
		}
		btn_ref.Invalidate();
	}

	internal void method_3(object object_0, double double_0)
	{
		Control control = object_0 as Control;
		if (control.Name == spn_geometryrad.Name)
		{
			btn_ref.Geometry.ArcDiameter = (int)spn_geometryrad.Value;
			refButton.Geometry.ArcDiameter = (int)spn_geometryrad.Value;
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == buComboBox_1.Name)
		{
			Enum.TryParse<ShapeType>(buComboBox_1.SelectedItem.ToString(), out var result);
			btn_ref.Geometry.ShapeMode = result;
			refButton.Geometry.ShapeMode = result;
		}
		if (control.Name == buComboBox_0.Name)
		{
			Enum.TryParse<ContentAlignment>(buComboBox_0.SelectedItem.ToString(), out var result2);
			btn_ref.ImageAlign = result2;
			refButton.ImageAlign = result2;
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
