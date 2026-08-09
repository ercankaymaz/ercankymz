using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using ns71;

namespace buEyeBaseVer5.Forms.Cam;

public class F_CamStockOffset : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public camParameters5 Settings = new camParameters5();

	private IContainer icontainer_0 = null;

	public buButton btn_close;

	public buGround buGround1;

	public Panel pnl_base;

	public buSpin spn_stockxminusoffset;

	public buButton btn_ok;

	public buSpin spn_stockxplusoffset;

	public buButton btn_cancel;

	public buSpin spn_stocktolorance;

	public buSpin spn_stockoffset;

	public buSpin spn_stockzminusoffset;

	public buSpin spn_stockzplusoffset;

	public buSpin spn_stockyminusoffset;

	public buSpin spn_stockyplusoffset;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal buLabel buLabel_0;

	internal RadioButton radioButton_2;

	internal buLabel buLabel_1;

	internal RadioButton radioButton_3;

	internal RadioButton radioButton_4;

	internal Panel panel_0;

	public F_CamStockOffset()
	{
		Class186.smethod_803(this);
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
		spn_stockxplusoffset.Value = Settings.Options.StockOffsetMax.X;
		spn_stockxminusoffset.Value = Settings.Options.StockOffsetMin.X;
		spn_stockyplusoffset.Value = Settings.Options.StockOffsetMax.Y;
		spn_stockyminusoffset.Value = Settings.Options.StockOffsetMin.Y;
		spn_stockzplusoffset.Value = Settings.Options.StockOffsetMax.Z;
		spn_stockzminusoffset.Value = Settings.Options.StockOffsetMin.Z;
		spn_stocktolorance.Value = Settings.Options.StockTolarance;
		spn_stockoffset.Value = Settings.Options.StockOffset;
		if (Settings.Options.StockOffsetMode != CamStockOffsetMode.SomExpand)
		{
			radioButton_0.Checked = true;
		}
		else
		{
			radioButton_1.Checked = true;
		}
		if (Settings.Options.StockType != CamStockType.StSurfaces)
		{
			if (Settings.Options.StockType != CamStockType.St2dContainment)
			{
				radioButton_4.Checked = true;
			}
			else
			{
				radioButton_2.Checked = true;
			}
		}
		else
		{
			radioButton_3.Checked = true;
		}
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		Class186.smethod_47(this);
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
		Settings.Options.StockOffsetMax.X = spn_stockxplusoffset.Value;
		Settings.Options.StockOffsetMin.X = spn_stockxminusoffset.Value;
		Settings.Options.StockOffsetMax.Y = spn_stockyplusoffset.Value;
		Settings.Options.StockOffsetMin.Y = spn_stockyminusoffset.Value;
		Settings.Options.StockOffsetMax.Z = spn_stockzplusoffset.Value;
		Settings.Options.StockOffsetMin.Z = spn_stockzminusoffset.Value;
		Settings.Options.StockTolarance = spn_stocktolorance.Value;
		Settings.Options.StockOffset = spn_stockoffset.Value;
		if (!radioButton_1.Checked)
		{
			Settings.Options.StockOffsetMode = CamStockOffsetMode.SomShrink;
		}
		else
		{
			Settings.Options.StockOffsetMode = CamStockOffsetMode.SomExpand;
		}
		if (!radioButton_2.Checked)
		{
			if (!radioButton_3.Checked)
			{
				Settings.Options.StockType = CamStockType.StBoundingBox;
			}
			else
			{
				Settings.Options.StockType = CamStockType.StSurfaces;
			}
		}
		else
		{
			Settings.Options.StockType = CamStockType.St2dContainment;
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
		catch (Exception)
		{
		}
	}

	public void spn_Leave(object sender, EventArgs e)
	{
	}

	internal void method_2(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited)
		{
			buSpin buSpin2 = sender as buSpin;
			buSpin2.SelectAll();
		}
	}

	internal void method_3(object sender, EventArgs e)
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
