using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buControls.Controls;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleHorizontalCutV2 : Form
{
	public static List<string> Captions = new List<string>();

	private IContainer icontainer_0 = null;

	public buSpin spn_lengthHor;

	public buSpin spn_itemEA5;

	public buSpin spn_itemSA5;

	public buSpin spn_itemcount5;

	public buSpin spn_itemlen5;

	public buSpin spn_itemEA4;

	public buSpin spn_itemSA4;

	public buSpin spn_itemcount4;

	public buSpin spn_itemlen4;

	public buSpin spn_itemEA3;

	public buSpin spn_itemSA3;

	public buSpin spn_itemcount3;

	public buSpin spn_itemlen3;

	public buSpin spn_itemEA2;

	public buSpin spn_itemSA2;

	public buSpin spn_itemcount2;

	public buSpin spn_itemlen2;

	public buSpin spn_itemEA1;

	public buSpin spn_itemSA1;

	public buSpin spn_itemcount1;

	public buSpin spn_itemlen1;

	public buButton buButton1;

	public buButton btn_maximize;

	public buButton btn_close;

	public buGround buGround1;

	public buButton btn_open;

	public buButton btn_downHor;

	public buButton btn_upHor;

	public buButton btn_okhor;

	public buButton btn_cancel;

	public buLabel lbl_length;

	public buLabel lbl_5;

	public buLabel lbl_4;

	public buLabel lbl_3;

	public buLabel lbl_2;

	public buLabel lbl_1;

	public buLabel lbl_ea;

	public buLabel lbl_sa;

	public buLabel lbl_count;

	public Panel pnl_hor_viewport;

	public buLabel lbl_7;

	public buSpin spn_itemEA7;

	public buSpin spn_itemSA7;

	public buSpin spn_itemcount7;

	public buSpin spn_itemlen7;

	public buLabel lbl_6;

	public buSpin spn_itemEA6;

	public buSpin spn_itemSA6;

	public buSpin spn_itemcount6;

	public buSpin spn_itemlen6;

	public Panel pnl_base;

	public buButton btn_clearallHor;

	internal Panel panel_0;

	public buSpin buSpin1;

	public buButton btn_save;

	public buSpin buSpin2;

	public buSpin buSpin3;

	internal buLabel buLabel_0;

	public TextBox txt_info;

	public F_MarbleHorizontalCutV2()
	{
		Class186.smethod_204(this);
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
