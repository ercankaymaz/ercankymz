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

public class F_ControlUICheck : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public buCheckBox refCheck = null;

	internal IContainer icontainer_0 = null;

	public buButton btn_close;

	public buGround buGround1;

	public ImageList IC32;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal buControlDisplaySet buControlDisplaySet_0;

	internal buControlDisplaySet buControlDisplaySet_1;

	internal buControlDisplaySet buControlDisplaySet_2;

	internal buComboBox buComboBox_0;

	internal buComboBox buComboBox_1;

	public buSpin spn_geometryrad;

	internal buCheckBox buCheckBox_0;

	internal buCheckBox buCheckBox_1;

	public buSpin spn_iconsize;

	internal buCheckBox buCheckBox_2;

	internal buCheckBox buCheckBox_3;

	public F_ControlUICheck()
	{
		Class186.smethod_206(this);
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
		if (refCheck != null)
		{
			buControlDisplaySet_0.Display = refCheck.Display;
			buControlDisplaySet_1.Display = refCheck.CheckTick.TickDisplay;
			buControlDisplaySet_2.Display = refCheck.CheckTick.ColorModeDisplay;
			spn_geometryrad.Value = refCheck.Geometry.ArcDiameter;
			buComboBox_1.SelectedItem = refCheck.Geometry.ShapeMode;
			buComboBox_0.SelectedItem = refCheck.ImageAlign;
			buCheckBox_0.Display = buControlDisplaySet_0.Display;
			buCheckBox_0.CheckTick.TickDisplay = buControlDisplaySet_1.Display;
			buCheckBox_0.CheckTick.ColorModeDisplay = buControlDisplaySet_2.Display;
			buCheckBox_1.Check = refCheck.CheckTick.ColorModeEnable;
			buCheckBox_0.CheckTick.ColorModeEnable = refCheck.CheckTick.ColorModeEnable;
			buCheckBox_2.Check = refCheck.CheckTick.Visible;
			buCheckBox_0.CheckTick.Visible = refCheck.CheckTick.Visible;
			if (refCheck.CheckTick.Shape != ShapeType.Rectangle)
			{
				buCheckBox_3.Check = false;
			}
			else
			{
				buCheckBox_3.Check = true;
			}
			buCheckBox_0.CheckTick.Shape = refCheck.CheckTick.Shape;
			buCheckBox_0.CheckTick.BoxSize = refCheck.CheckTick.BoxSize;
			if (refCheck.CheckTick.BoxSize > 0)
			{
				spn_iconsize.Value = refCheck.CheckTick.BoxSize;
			}
			buControlDisplaySet_0.UpdateControl();
			buControlDisplaySet_1.UpdateControl();
			buControlDisplaySet_2.UpdateControl();
		}
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		Class186.smethod_564(this);
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

	internal void method_2(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == buControlDisplaySet_0.Name)
		{
			buCheckBox_0.Display = buControlDisplaySet_0.Display;
		}
		if (control.Name == buControlDisplaySet_1.Name)
		{
			buCheckBox_0.CheckTick.TickDisplay = buControlDisplaySet_1.Display;
		}
		if (control.Name == buControlDisplaySet_2.Name)
		{
			buCheckBox_0.CheckTick.ColorModeDisplay = buControlDisplaySet_2.Display;
		}
		buCheckBox_0.Invalidate();
	}

	internal void method_3(object object_0, double double_0)
	{
		Control control = object_0 as Control;
		if (control.Name == spn_geometryrad.Name)
		{
			buCheckBox_0.Geometry.ArcDiameter = (int)spn_geometryrad.Value;
			refCheck.Geometry.ArcDiameter = (int)spn_geometryrad.Value;
		}
		if (control.Name == spn_iconsize.Name)
		{
			buCheckBox_0.CheckTick.BoxSize = (int)spn_iconsize.Value;
			refCheck.CheckTick.BoxSize = (int)spn_iconsize.Value;
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == buComboBox_1.Name)
		{
			Enum.TryParse<ShapeType>(buComboBox_1.SelectedItem.ToString(), out var result);
			buCheckBox_0.Geometry.ShapeMode = result;
			refCheck.Geometry.ShapeMode = result;
		}
		if (control.Name == buComboBox_0.Name)
		{
			Enum.TryParse<ContentAlignment>(buComboBox_0.SelectedItem.ToString(), out var result2);
			buCheckBox_0.ImageAlign = result2;
			refCheck.ImageAlign = result2;
		}
	}

	internal void method_5(object object_0, bool bool_0)
	{
		Control control = object_0 as Control;
		if (control.Name == buCheckBox_1.Name)
		{
			buCheckBox_0.CheckTick.ColorModeEnable = buCheckBox_1.Check;
			refCheck.CheckTick.ColorModeEnable = buCheckBox_1.Check;
		}
		if (control.Name == buCheckBox_2.Name)
		{
			buCheckBox_0.CheckTick.Visible = buCheckBox_1.Check;
			refCheck.CheckTick.Visible = buCheckBox_1.Check;
		}
		if (control.Name == buCheckBox_3.Name)
		{
			if (!buCheckBox_3.Check)
			{
				buCheckBox_0.CheckTick.Shape = ShapeType.Arc;
				refCheck.CheckTick.Shape = ShapeType.Arc;
			}
			else
			{
				buCheckBox_0.CheckTick.Shape = ShapeType.Rectangle;
				refCheck.CheckTick.Shape = ShapeType.Rectangle;
			}
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
