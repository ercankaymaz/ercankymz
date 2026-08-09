using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buControls.Controls;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleCutting : Form
{
	public static List<string> Captions = new List<string>();

	private IContainer icontainer_0 = null;

	public buButton ntn_minimize;

	public buButton btn_maximize;

	public buButton btn_close;

	public buGround buGround1;

	public Panel pnl_base;

	public Panel pnl_cutting_viewport;

	public buButton btn_scale;

	public TabPage tabPage_alignment;

	public buButton btn_alignmentleft;

	public buButton btn_alignmenttop;

	public buButton btn_alignmentcenter;

	public buButton btn_alignmentright;

	public buButton btn_alignmentbottom;

	public PictureBox pictureBox1;

	public buPanel buPanel2;

	public buTab buTab_commands;

	public TabPage tabPage_shape;

	public buButton btn_rectangle;

	public buButton btn_polygon;

	public buButton btn_circle;

	public buButton btn_trapez;

	public buButton btn_triangle;

	public buButton btn_ellipse;

	public TabPage tabPage_drawing;

	public buButton btn_line;

	public buButton btn_arc;

	public buButton btn_spline;

	public TabPage tabPage_events;

	public buButton btn_copy;

	public buButton btn_mirror;

	public buButton btn_rotate;

	public buButton btn_lineararray;

	public buButton btn_circulararray;

	public buPanel buPanel1;

	public buButton btn_events;

	public buButton btn_import;

	public buButton btn_vacuum;

	public buButton btn_bench;

	public buButton btn_alignments;

	public buButton btn_shape;

	public buButton btn_drawings;

	public buButton btn_roundrect;

	public buButton btn_keyhole;

	public buButton btn_slot;

	public buButton btn_profiling;

	public buButton btn_engraving;

	public buButton btn_sweep;

	public buButton btn_drill;

	public buButton btn_text;

	public F_MarbleCutting()
	{
		Class186.smethod_590(this);
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
