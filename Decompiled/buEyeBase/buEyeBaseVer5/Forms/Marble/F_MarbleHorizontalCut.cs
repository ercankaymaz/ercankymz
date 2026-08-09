using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buControls.Controls;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleHorizontalCut : Form
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

	public buLabel lbl_total;

	public buLabel lbl_totalcounthor;

	public buLabel lbl_totallenhor;

	public buButton btn_save;

	public buButton btn_open;

	public buButton btn_endposHor;

	public buButton btn_startposHor;

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

	public buCheckBox chk_horizotalvertical;

	public buCheckBox chk_verticalhorizontal;

	public buCheckBox chk_onlyhorizontal;

	public buCheckBox chk_onlyvertical;

	public Panel pnl_base;

	public buSpin spn_cvalHor;

	public buCheckBox chk_FromvalueHor;

	public buButton btn_clearallHor;

	public buSpin spn_x;

	public buSpin spn_c;

	public buSpin spn_a;

	public buSpin spn_z;

	public buSpin spn_y;

	public buButton btn_showcoordsHor;

	internal PictureBox pictureBox_0;

	public Panel pnl_coords;

	public Panel pnl_data;

	public F_MarbleHorizontalCut()
	{
		Class186.smethod_468(this);
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
