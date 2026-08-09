using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Components.Marble;
using buControls.Controls;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleJobOPListV1 : Form
{
	private string string_0 = "F_MarbleCoordinatesV1";

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal ImageList imageList_1;

	public buPanel pnl_base;

	public buMarbleOPItem Op16;

	public buMarbleOPItem Op15;

	public buMarbleOPItem Op14;

	public buMarbleOPItem Op13;

	public buMarbleOPItem Op12;

	public buMarbleOPItem Op11;

	public buMarbleOPItem Op10;

	public buMarbleOPItem Op9;

	public buMarbleOPItem Op8;

	public buMarbleOPItem Op7;

	public buMarbleOPItem Op6;

	public buMarbleOPItem Op5;

	public buMarbleOPItem Op4;

	public buMarbleOPItem Op3;

	public buMarbleOPItem Op2;

	public buMarbleOPItem Op1;

	public buMarbleOPItem Op18;

	public buMarbleOPItem Op17;

	public F_MarbleJobOPListV1()
	{
		Class186.smethod_393(this);
	}

	public void UpdateVisuals()
	{
		string text = "UpdateVisuals";
		try
		{
			if (buEyeVars.parVisual != null)
			{
				LoadLanguage();
			}
		}
		catch (Exception ex)
		{
			buLogVer5.addToLog(string_0, text, "Exception", ex.Message, ex.Data.ToString(), 0.0, 0.0, AddException: true);
			buException.throwException(ex, text, ShowMessageBox: true, "");
		}
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
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
		}
		catch (Exception)
		{
		}
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
