using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Zen.Barcode;
using buClass;
using ns71;

namespace buEyeBaseVer5.Forms.BarCodes;

public class F_BarCode : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	private IContainer icontainer_0 = null;

	public Button btn_ok;

	internal TextBox textBox_0;

	public Button btn_cancel;

	public Button btn_save;

	internal ImageList imageList_0;

	internal PictureBox pictureBox_0;

	public F_BarCode()
	{
		Class186.smethod_294(this);
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
		Class186.smethod_324(this);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
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

	internal void method_1(object sender, EventArgs e)
	{
	}

	internal void method_2(object sender, EventArgs e)
	{
		Class186.smethod_593(this);
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

	internal void method_3(object sender, EventArgs e)
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

	internal void method_4(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			Code128BarcodeDraw code128WithChecksum = BarcodeDrawFactory.Code128WithChecksum;
			pictureBox_0.Image = code128WithChecksum.Draw(textBox_0.Text, 100);
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
