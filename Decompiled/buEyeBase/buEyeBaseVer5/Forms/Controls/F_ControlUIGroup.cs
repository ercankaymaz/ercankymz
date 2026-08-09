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

public class F_ControlUIGroup : Form
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

	public buSpin spn_headerheight;

	public buGroup grp_ref;

	public F_ControlUIGroup()
	{
		Class186.smethod_480(this);
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
		buControlDisplaySet_0.Display = Settings.Caption;
		buControlDisplaySet_1.Display = Settings.Display;
		spn_geometryrad.Value = Settings.Parameters.GeometryArcDiameer;
		buComboBox_1.SelectedItem = Settings.Parameters.GeometryType;
		buComboBox_0.SelectedItem = Settings.Parameters.ImageAlignment;
		spn_headerheight.Value = Settings.Parameters.TopHeight;
		grp_ref.TitleHeight = Settings.Parameters.TopHeight;
		grp_ref.Geometry.ArcDiameter = Settings.Parameters.GeometryArcDiameer;
		grp_ref.Geometry.ShapeMode = Settings.Parameters.GeometryType;
		grp_ref.ImageAlign = Settings.Parameters.ImageAlignment;
		grp_ref.Display = buControlDisplaySet_1.Display;
		grp_ref.TitleDisplay = buControlDisplaySet_0.Display;
		buControlDisplaySet_0.UpdateControl();
		buControlDisplaySet_1.UpdateControl();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		Class186.smethod_5(this);
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
			grp_ref.TitleDisplay = buControlDisplaySet_0.Display;
		}
		if (control.Name == buControlDisplaySet_1.Name)
		{
			grp_ref.Display = buControlDisplaySet_1.Display;
		}
		grp_ref.Invalidate();
	}

	internal void method_3(object object_0, double double_0)
	{
		Control control = object_0 as Control;
		if (control.Name == spn_geometryrad.Name)
		{
			grp_ref.Geometry.ArcDiameter = (int)spn_geometryrad.Value;
			Settings.Parameters.GeometryArcDiameer = (int)spn_geometryrad.Value;
		}
		if (control.Name == spn_headerheight.Name)
		{
			grp_ref.TitleHeight = (int)spn_headerheight.Value;
			Settings.Parameters.TopHeight = (int)spn_headerheight.Value;
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == buComboBox_1.Name)
		{
			Enum.TryParse<ShapeType>(buComboBox_1.SelectedItem.ToString(), out var result);
			grp_ref.Geometry.ShapeMode = result;
			Settings.Parameters.GeometryType = result;
		}
		if (control.Name == buComboBox_0.Name)
		{
			Enum.TryParse<ContentAlignment>(buComboBox_0.SelectedItem.ToString(), out var result2);
			grp_ref.ImageAlign = result2;
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
