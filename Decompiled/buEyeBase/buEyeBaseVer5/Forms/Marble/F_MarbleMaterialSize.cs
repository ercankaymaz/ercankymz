using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleMaterialSize : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public MaterialBase5 Mat = new MaterialBase5();

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal buGround buGround_0;

	public buSpin spn_matdepth;

	public buSpin spn_matheight;

	public buSpin spn_matWdith;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal buButton buButton_0;

	internal ImageList imageList_1;

	internal buLabel buLabel_0;

	public buButton btn_importimage;

	internal PictureBox pictureBox_0;

	public F_MarbleMaterialSize()
	{
		Class186.smethod_432(this);
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
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		spn_matheight.Value = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight;
		spn_matWdith.Value = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth;
		spn_matdepth.Value = buMarbleCalc.varOperation.MaterialParameter.MaterialThickness;
		Class186.smethod_44(this);
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
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if (control.Name == btn_ok.Name)
			{
				Class186.smethod_522(this);
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
			if (control.Name == btn_importimage.Name)
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.InitialDirectory = buMarbleCalc.varMarbleRunSettings.pathFromPhoto;
				openFileDialog.Filter = "All Image Files Files (*.Png,*.Jpg,*.Jpeg,*.Bmp)|*.png;*.jpg;*.jpeg;*.bmp|PNG Files (*.png)|*.png|JpegFiles (*.jpeg,*.jpg)|*.jpg;*.jpeg|BMP Files (*.bmp)|*.bmp";
				openFileDialog.FilterIndex = 1;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					buLabel_0.Text = buFile5.getFileName(openFileDialog.FileName);
					pictureBox_0.Image = buImage5.OpenImageAsStream(openFileDialog.FileName);
					Mat.FileNameImage = openFileDialog.FileName;
					Mat.matImage = buImage5.OpenImageAsStream(openFileDialog.FileName);
					buMarbleCalc.varMarbleRunSettings.pathFromPhoto = buFile5.GetPath(openFileDialog.FileName);
				}
			}
			if (control.Name == btn_cancel.Name)
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
		catch (Exception)
		{
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		buSpin buSpin2 = sender as buSpin;
		if (AppBool.TouchPad)
		{
			F_KeyPadNumV1 f_KeyPadNumV = new F_KeyPadNumV1();
			f_KeyPadNumV.StartPosition = FormStartPosition.CenterParent;
			f_KeyPadNumV.Caption = buSpin2.Caption.Caption;
			f_KeyPadNumV.ShowDialog(buSpin2.Value.ToString());
			if (buNumeric5.IsNumeric(f_KeyPadNumV.Value))
			{
				buSpin2.Value = double.Parse(f_KeyPadNumV.Value);
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
