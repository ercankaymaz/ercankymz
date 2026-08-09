using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Jewellary;

public class F_JewelServiceMenu : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	private IContainer icontainer_0 = null;

	public Button btn_tooladvanced;

	public Button btn_absoluteset;

	public Button btn_g54;

	public Button btn_gcode;

	public Button btn_close;

	public Button btn_settings;

	public Button btn_debug;

	public Button btn_password;

	public Button btn_test;

	public Button btn_watchpars;

	public Button btn_shotdown;

	public F_JewelServiceMenu()
	{
		Class76.smethod_238(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		if (Properties.Height > 10)
		{
			base.Height = Properties.Height;
		}
		if (Properties.Width > 10)
		{
			base.Width = Properties.Width;
		}
		base.TopMost = Properties.TopMost;
		base.StartPosition = Properties.FormPosition;
		base.AutoScaleMode = Properties.ScaleFromMode;
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
