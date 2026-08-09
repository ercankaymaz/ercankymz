using System.ComponentModel;
using System.Windows.Forms;
using ns71;

namespace buEyeBaseVer5.Forms.Holes;

public class F_HolesTemp : Form
{
	private IContainer icontainer_0 = null;

	internal TabControl tabControl_0;

	internal Label label_0;

	internal Label label_1;

	public TabPage tabPage_drill;

	public Label lbl_slotmode1_usemilling;

	public CheckBox chk_slotmode1_usemilling;

	public Label lbl_slotmode_length;

	public NumericUpDown spn_slotmode_length;

	public NumericUpDown spn_slotmode1_x;

	public NumericUpDown spn_slotmode1_y;

	public NumericUpDown spn_slotmode1_depth;

	public Label lbl_slotmode1_width;

	public Label lbl_slotmode1_depth;

	public NumericUpDown spn_slotmode1_width;

	public Label lbl_drillmode1_distancedrill;

	public NumericUpDown spn_drillmode1_distancedrill;

	public Label lbl_drillmode1_drillcount;

	public NumericUpDown spn_drillmode1_drillcount;

	public NumericUpDown spn_drillmode1_holex;

	public Label lbl_drillmode1_holex;

	public NumericUpDown spn_drillmode1_holey;

	public Label lbl_drillmode1_holey;

	public NumericUpDown spn_drillmode1_holez;

	public Label lbl_drillmode1_holez;

	public NumericUpDown spn_drillmode1_holedepth;

	public Label lbl_drillmode1_holediameter;

	public Label lbl_drillmode1_holedepth;

	public NumericUpDown spn_drillmode1_holediameter;

	public Label label22;

	public NumericUpDown spn_rectangleheight;

	public NumericUpDown spn_rectanglex;

	public Label label10;

	public NumericUpDown spn_rectangley;

	public Label label11;

	public NumericUpDown spn_rectanglez;

	public Label label12;

	public NumericUpDown spn_rectangledepth;

	public Label label13;

	public Label label14;

	public NumericUpDown spn_rectanglewidth;

	public Label label21;

	public CheckBox chk_circleisdrill;

	public NumericUpDown spn_circlex;

	public Label label16;

	public NumericUpDown spn_circley;

	public Label label17;

	public NumericUpDown spn_circlez;

	public Label label18;

	public NumericUpDown spn_circledepth;

	public Label label19;

	public Label label20;

	public NumericUpDown spn_circlediameter;

	public NumericUpDown spn_drillmode2_height;

	public Label lbl_drillmode2_height;

	public Label lbl_drillmode2_drilldis;

	public NumericUpDown spn_drillmode2_drilldis;

	public NumericUpDown spn_drillmode2_startdis;

	public Label lbl_drillmode2_startdis;

	public NumericUpDown spn_drillmode2_enddis;

	public Label lbl_drillmode2_enddis;

	public NumericUpDown spn_drillmode2_depth;

	public Label lbl_drillmode2_diameter;

	public Label lbl_drillmode2_depth;

	public NumericUpDown spn_drillmode2_diameter;

	public TabPage tabPage_drillstartenddistance;

	public Label lbl_slotmode2_usemilling;

	public CheckBox chk_slotmode2_usemilling;

	public NumericUpDown spn_slotmode2_height;

	public Label lbl_slotmode2_height;

	public NumericUpDown spn_slotmode2_startdis;

	public Label lbl_slotmode2_startdis;

	public NumericUpDown spn_slotmode2_enddis;

	public Label lbl_slotmode2_enddis;

	public NumericUpDown spn_slotmode2_depth;

	public Label lbl_slotmode2_width;

	public Label lbl_slotmode2_depth;

	public NumericUpDown spn_slotmode2_width;

	public TabPage tabPage_slotdistance;

	public TabPage tabPage_Slot;

	public TabPage tabPage_rectangle;

	public TabPage tabPage_Circle;

	public TabPage tabPage_ellipse;

	public Label label1;

	public NumericUpDown spn_ellipseX;

	public NumericUpDown spn_ellipseZ;

	public NumericUpDown spn_ellipseheight;

	public Label label2;

	public Label label3;

	public NumericUpDown spn_ellipsewidth;

	public NumericUpDown spn_ellipsedepth;

	public Label label4;

	public NumericUpDown spn_ellipseY;

	public Label label5;

	public Label label6;

	public Label label7;

	public NumericUpDown spn_rectangleangle;

	public Label label8;

	public NumericUpDown spn_ellipseangle;

	public Label label15;

	public CheckBox chk_rectanglecatchcenter;

	public Label label9;

	public CheckBox chk_circlecatchcenter;

	public Label label23;

	public CheckBox chk_ellipsecatchcenter;

	public Label lbl_singlecorner_height;

	public NumericUpDown spn_singlecorner_height;

	public NumericUpDown spn_singlecorner_width;

	public NumericUpDown spn_singlecorner_depth;

	public Label lbl_singlecorner_depth;

	public Label lbl_singlecorner_width;

	public TabPage tabPage_singlecorner;

	public Label label24;

	public CheckBox chk_rectanglepocket;

	public Label label25;

	public CheckBox chk_circlepocket;

	public Label label26;

	public CheckBox chk_ellipsepocket;

	public Label label27;

	public CheckBox chk_singlecornerpocket;

	public Label label28;

	public CheckBox chk_drillmode1_usemilling;

	public Label label29;

	public CheckBox chk_polygonispocket;

	public Label label31;

	public NumericUpDown spn_polygonangle;

	public NumericUpDown spn_polygonx;

	public NumericUpDown spn_polygonz;

	public Label label33;

	public Label label34;

	public NumericUpDown spn_polygondiameter;

	public NumericUpDown spn_polygondepth;

	public Label label35;

	public NumericUpDown spn_polygony;

	public Label label36;

	public Label label37;

	public Label label38;

	public NumericUpDown spn_slotshape_angle;

	public Label label39;

	public NumericUpDown spn_slotshape_x;

	public NumericUpDown spn_slotshape_z;

	public NumericUpDown spn_slotshape_height;

	public Label label40;

	public Label label41;

	public NumericUpDown spn_slotshape_width;

	public NumericUpDown spn_slotshape_depth;

	public Label label42;

	public NumericUpDown spn_slotshape_y;

	public Label label43;

	public Label label44;

	public Label label32;

	public NumericUpDown spn_polygonsides;

	public TabPage tabPage_polygon;

	public TabPage tabPage_slotshape;

	internal Label label_2;

	public NumericUpDown spn_slotmode1_z;

	public Label label30;

	public CheckBox chk_slotpocket;

	public Label label51;

	public NumericUpDown spn_slotmode3_angle;

	public NumericUpDown spn_slotmode3_x;

	public NumericUpDown spn_slotmode3_width;

	public Label label45;

	public Label label46;

	public NumericUpDown spn_slotmode3_length;

	public Label label47;

	public NumericUpDown spn_slotmode3_depth;

	internal Label label_3;

	internal Label label_4;

	public NumericUpDown spn_slotmode3_z;

	public NumericUpDown spn_slotmode3_y;

	internal Label label_5;

	public TabPage tabPage_cutfree;

	public NumericUpDown spn_engraving_x;

	public Label label52;

	public NumericUpDown spn_engraving_y;

	public Label label53;

	public TabPage tabPage_engraving;

	public NumericUpDown spn_engraving_z;

	public Label label54;

	public CheckBox chk_engravingfinishoperation;

	public CheckBox chk_engravingroughoperation;

	public NumericUpDown spn_rectanglestepval;

	public Label label55;

	public CheckBox chk_rectanglestepenable;

	public NumericUpDown spn_circlestepval;

	public Label label56;

	public CheckBox chk_circlestepenable;

	public NumericUpDown spn_ellipsestepval;

	public Label label57;

	public CheckBox chk_ellipsestepenable;

	public NumericUpDown spn_polygonstepval;

	public Label label58;

	public CheckBox chk_polygonstepenable;

	public NumericUpDown spn_slotstepval;

	public Label label59;

	public CheckBox chk_slotstepenable;

	public NumericUpDown spn_singlecornerstepval;

	public Label label60;

	public CheckBox chk_singlecornerstep;

	public F_HolesTemp()
	{
		Class186.smethod_786(this);
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
