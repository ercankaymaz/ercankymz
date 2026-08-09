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

public class F_ControlUITrack : Form
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

	internal buControlDisplaySet buControlDisplaySet_1;

	internal buComboBox buComboBox_0;

	internal buComboBox buComboBox_1;

	public buSpin spn_geometryrad;

	internal buControlDisplaySet buControlDisplaySet_2;

	internal buControlDisplaySet buControlDisplaySet_3;

	public buSpin spn_drawerwidth;

	public buTrack track_ref;

	internal buCheckBox buCheckBox_0;

	internal buCheckBox buCheckBox_1;

	public F_ControlUITrack()
	{
		Class186.smethod_333(this);
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
		buControlDisplaySet_0.Display = Settings.Done;
		buControlDisplaySet_3.Display = Settings.Shape;
		buControlDisplaySet_2.Display = Settings.Display;
		buControlDisplaySet_1.Display = Settings.Caption;
		spn_geometryrad.Value = Settings.Parameters.GeometryArcDiameer;
		buComboBox_1.SelectedItem = Settings.Parameters.GeometryType;
		buComboBox_0.SelectedItem = Settings.Parameters.ImageAlignment;
		spn_drawerwidth.Value = Settings.Parameters.ObjectWidth;
		buCheckBox_0.Check = Settings.Parameters.ShowPersentage;
		track_ref.Geometry.ShapeMode = Settings.Parameters.GeometryType;
		track_ref.Geometry.ArcDiameter = Settings.Parameters.GeometryArcDiameer;
		track_ref.ImageAlign = Settings.Parameters.ImageAlignment;
		track_ref.Track.ShowPersentage = Settings.Parameters.ShowPersentage;
		track_ref.Track.DrawerWidth = Settings.Parameters.ObjectWidth;
		track_ref.Display = buControlDisplaySet_2.Display;
		track_ref.Caption.Display = buControlDisplaySet_1.Display;
		track_ref.Track.DoneDisplay = buControlDisplaySet_0.Display;
		track_ref.Track.DrawerDisplay = buControlDisplaySet_3.Display;
		buControlDisplaySet_3.UpdateControl();
		buControlDisplaySet_0.UpdateControl();
		buControlDisplaySet_1.UpdateControl();
		buControlDisplaySet_2.UpdateControl();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		Class186.smethod_329(this);
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
			track_ref.Track.DoneDisplay = buControlDisplaySet_0.Display;
		}
		if (control.Name == buControlDisplaySet_3.Name)
		{
			track_ref.Track.DrawerDisplay = buControlDisplaySet_3.Display;
		}
		if (control.Name == buControlDisplaySet_1.Name)
		{
			track_ref.Caption.Display = buControlDisplaySet_1.Display;
		}
		if (control.Name == buControlDisplaySet_2.Name)
		{
			track_ref.Display = buControlDisplaySet_2.Display;
		}
		track_ref.Invalidate();
	}

	internal void method_3(object object_0, double double_0)
	{
		Control control = object_0 as Control;
		if (control.Name == spn_geometryrad.Name)
		{
			track_ref.Geometry.ArcDiameter = (int)spn_geometryrad.Value;
			Settings.Parameters.GeometryArcDiameer = (int)spn_geometryrad.Value;
		}
		if (control.Name == spn_drawerwidth.Name)
		{
			track_ref.Track.DrawerWidth = (int)spn_drawerwidth.Value;
			Settings.Parameters.ObjectWidth = (int)spn_drawerwidth.Value;
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == buComboBox_1.Name)
		{
			Enum.TryParse<ShapeType>(buComboBox_1.SelectedItem.ToString(), out var result);
			track_ref.Geometry.ShapeMode = result;
			Settings.Parameters.GeometryType = result;
		}
		if (control.Name == buComboBox_0.Name)
		{
			Enum.TryParse<ContentAlignment>(buComboBox_0.SelectedItem.ToString(), out var result2);
			track_ref.ImageAlign = result2;
			Settings.Parameters.ImageAlignment = result2;
		}
	}

	internal void method_5(object object_0, bool bool_0)
	{
		Control control = object_0 as Control;
		if (control.Name == buCheckBox_0.Name)
		{
			Enum.TryParse<ShapeType>(buComboBox_1.SelectedItem.ToString(), out var _);
			track_ref.Track.ShowPersentage = buCheckBox_0.Check;
			Settings.Parameters.ShowPersentage = buCheckBox_0.Check;
		}
		if (control.Name == buCheckBox_1.Name)
		{
			Enum.TryParse<ShapeType>(buComboBox_1.SelectedItem.ToString(), out var _);
			track_ref.Track.DrawerRectangle = buCheckBox_1.Check;
			Settings.Parameters.DrawerRectangle = buCheckBox_1.Check;
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
