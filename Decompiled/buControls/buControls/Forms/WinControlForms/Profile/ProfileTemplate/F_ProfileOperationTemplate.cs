using System.ComponentModel;
using System.Windows.Forms;
using ns27;

namespace buControls.Forms.WinControlForms.Profile.ProfileTemplate;

public class F_ProfileOperationTemplate : Form
{
	private IContainer icontainer_0 = null;

	public TabControl tabControl_profileoperation;

	public TabPage tabPage_circle;

	internal Panel panel_0;

	internal Label label_0;

	public Button btn_depth;

	public TabPage tabPage_rectangle;

	internal Panel panel_1;

	internal Label label_1;

	internal Panel panel_2;

	internal Label label_2;

	internal Panel panel_3;

	internal Label label_3;

	public TabPage tabPage_roundrect;

	internal Panel panel_4;

	internal Label label_4;

	internal Panel panel_5;

	internal Label label_5;

	internal Panel panel_6;

	internal Label label_6;

	internal Panel panel_7;

	internal Label label_7;

	public TabPage tabPage_keyhole;

	internal Panel panel_8;

	internal Label label_8;

	internal Panel panel_9;

	internal Label label_9;

	internal Panel panel_10;

	internal Label label_10;

	internal Panel panel_11;

	internal Label label_11;

	public TabPage tabPage_ellipse;

	internal Panel panel_12;

	internal Label label_12;

	internal Panel panel_13;

	internal Label label_13;

	internal Panel panel_14;

	internal Label label_14;

	public TabPage tabPage_hole;

	internal Panel panel_15;

	internal Label label_15;

	public TabPage tabPage_sawcut;

	internal TabPage tabPage_0;

	internal Panel panel_16;

	internal Label label_16;

	internal Panel panel_17;

	internal Label label_17;

	internal TabPage tabPage_1;

	internal Panel panel_18;

	internal Label label_18;

	internal Panel panel_19;

	internal Label label_19;

	internal Panel panel_20;

	internal Label label_20;

	public TabPage tabPage_freedraw;

	internal Panel panel_21;

	internal Label label_21;

	internal Panel panel_22;

	internal Label label_22;

	internal Panel panel_23;

	internal Label label_23;

	public TabPage tabPage_text;

	internal Panel panel_24;

	internal Label label_24;

	internal Panel panel_25;

	internal Label label_25;

	internal Panel panel_26;

	internal Label label_26;

	internal Panel panel_27;

	internal Label label_27;

	public TabPage tabPage_slot;

	internal Panel panel_28;

	internal Label label_28;

	internal Panel panel_29;

	internal Label label_29;

	internal Panel panel_30;

	internal Label label_30;

	public NumericUpDown spn_circlediameter;

	public NumericUpDown spn_rectangleangle;

	public NumericUpDown spn_rectangleheight;

	public NumericUpDown spn_rectanglewidth;

	public NumericUpDown spn_roundrectradius;

	public NumericUpDown spn_roundrectangle;

	public NumericUpDown spn_roundrectheight;

	public NumericUpDown spn_roundrectwidth;

	public NumericUpDown spn_barrelangle;

	public NumericUpDown spn_barrelwidth;

	public NumericUpDown spn_barreldiameter;

	public NumericUpDown spn_barrellength;

	public NumericUpDown spn_ellipseangle;

	public NumericUpDown spn_ellipseheight;

	public NumericUpDown spn_ellipsewidth;

	public NumericUpDown spn_holediameter;

	public RadioButton radio_kertmeright;

	public RadioButton radio_kertmeleft;

	public RadioButton radio_kertmeLdown;

	public RadioButton radio_kertmeLup;

	public NumericUpDown spn_kertmeLdepth;

	public NumericUpDown spn_kertmeLheight;

	public NumericUpDown spn_kertmeUstart;

	public NumericUpDown spn_kertmeUdepth;

	public NumericUpDown spn_kertmeUheight;

	public RadioButton radio_Freedrawtopright;

	public RadioButton radio_Freedrawcenter;

	public RadioButton radio_Freedrawbottomleft;

	public NumericUpDown spn_freedrawangle;

	public NumericUpDown spn_freedrawheight;

	public NumericUpDown spn_freedrawwidth;

	public TextBox txt_text;

	public RadioButton radio_textcenter;

	public RadioButton radio_textbottomleft;

	public NumericUpDown spn_textangle;

	public NumericUpDown spn_texthegiht;

	public NumericUpDown spn_textwidth;

	public NumericUpDown spn_slotangle;

	public NumericUpDown spn_slotheight;

	public NumericUpDown spn_slotwidth;

	public TabControl tabControl_Notch;

	internal Panel panel_31;

	internal Label label_31;

	public NumericUpDown spn_cutdepth;

	internal Panel panel_32;

	internal Label label_32;

	public NumericUpDown spn_cutangle;

	internal Panel panel_33;

	internal Label label_33;

	public NumericUpDown spn_cutheight;

	internal Panel panel_34;

	internal Label label_34;

	public NumericUpDown spn_cutwidth;

	public TabPage tabPage_cut;

	public F_ProfileOperationTemplate()
	{
		Class76.smethod_306(this);
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
