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

public class F_MarbleCountertopEdge : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public marbleEdgeItem Edge = new marbleEdgeItem();

	private IContainer icontainer_0 = null;

	public buButton btn_close;

	public buGround buGround1;

	public Panel pnl_base;

	public buSpin spn_slatstartangle;

	public buButton btn_okVer;

	public buSpin spn_topchamferstartheight;

	public buSpin spn_topchamferstartangle;

	public buSpin spn_slatwidth;

	public buButton btn_cancel;

	public buCheckBox chk_topchamferstartenable;

	public buCheckBox chk_slatenable;

	public buSpin spn_slatendangle;

	public buCheckBox chk_topchamferendenable;

	public buSpin spn_topchamferendheight;

	public buSpin spn_topchamferendangle;

	public buCheckBox chk_bottomchamfer;

	public buCheckBox chk_topchamfer;

	public buSpin spn_chamferbottomheiht;

	public buSpin spn_chamferbottomangle;

	public buSpin spn_chamfertopheight;

	public buSpin spn_chamfertopangle;

	public buLabel lbl_chamfer;

	public buLabel lbl_slat;

	public buLabel lbl_edge;

	public buCheckBox chk_reverse;

	public buSpin spn_edgeangle;

	public F_MarbleCountertopEdge()
	{
		Class186.smethod_343(this);
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
		chk_slatenable.Check = Edge.Slat.DataSlat.Enable;
		chk_topchamferendenable.Check = Edge.Slat.EndChamfer.DataChamfer.TopEnable;
		chk_topchamferstartenable.Check = Edge.Slat.StartChamfer.DataChamfer.TopEnable;
		spn_slatstartangle.Value = Edge.Slat.DataSlat.StartAngle;
		spn_slatendangle.Value = Edge.Slat.DataSlat.EndAngle;
		spn_slatwidth.Value = Edge.Slat.DataSlat.Width;
		spn_topchamferstartheight.Value = Edge.Slat.StartChamfer.DataChamfer.TopHeight;
		spn_topchamferstartangle.Value = Edge.Slat.StartChamfer.DataChamfer.TopAngle;
		spn_topchamferendheight.Value = Edge.Slat.EndChamfer.DataChamfer.TopHeight;
		spn_topchamferendangle.Value = Edge.Slat.EndChamfer.DataChamfer.TopAngle;
		spn_chamferbottomangle.Value = Edge.Chamfer.DataChamfer.BottomAngle;
		spn_chamferbottomheiht.Value = Edge.Chamfer.DataChamfer.BottomHeight;
		spn_chamfertopangle.Value = Edge.Chamfer.DataChamfer.TopAngle;
		spn_chamfertopheight.Value = Edge.Chamfer.DataChamfer.TopHeight;
		chk_bottomchamfer.Check = Edge.Chamfer.DataChamfer.BottomEnable;
		chk_topchamfer.Check = Edge.Chamfer.DataChamfer.TopEnable;
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		Class186.smethod_370(this);
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
		Edge.Slat.DataSlat.Enable = chk_slatenable.Check;
		Edge.Slat.EndChamfer.DataChamfer.TopEnable = chk_topchamferendenable.Check;
		Edge.Slat.StartChamfer.DataChamfer.TopEnable = chk_topchamferstartenable.Check;
		Edge.Slat.DataSlat.StartAngle = spn_slatstartangle.Value;
		Edge.Slat.DataSlat.EndAngle = spn_slatendangle.Value;
		Edge.Slat.DataSlat.Width = spn_slatwidth.Value;
		Edge.Slat.StartChamfer.DataChamfer.TopHeight = spn_topchamferstartheight.Value;
		Edge.Slat.StartChamfer.DataChamfer.TopAngle = spn_topchamferstartangle.Value;
		Edge.Slat.EndChamfer.DataChamfer.TopHeight = spn_topchamferendheight.Value;
		Edge.Slat.EndChamfer.DataChamfer.TopAngle = spn_topchamferendangle.Value;
		Edge.Chamfer.DataChamfer.BottomAngle = spn_chamferbottomangle.Value;
		Edge.Chamfer.DataChamfer.BottomHeight = spn_chamferbottomheiht.Value;
		Edge.Chamfer.DataChamfer.TopAngle = spn_chamfertopangle.Value;
		Edge.Chamfer.DataChamfer.TopHeight = spn_chamfertopheight.Value;
		Edge.Chamfer.DataChamfer.BottomEnable = chk_bottomchamfer.Check;
		Edge.Chamfer.DataChamfer.TopEnable = chk_topchamfer.Check;
	}

	internal void method_1(object sender, EventArgs e)
	{
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if (control.Name == btn_okVer.Name)
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
			buSpin2.Display.BackColor = buEyeVars.parVisual.colorDataFocus;
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
