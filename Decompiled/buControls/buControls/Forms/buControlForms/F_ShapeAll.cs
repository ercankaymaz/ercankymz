using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns27;

namespace buControls.Forms.buControlForms;

public class F_ShapeAll : Form
{
	public Color SpinBaseColor = Color.LightGreen;

	public Color SpinFocusColor = Color.MistyRose;

	public ShapeAllData Data = new ShapeAllData();

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	internal buButton buButton_0;

	public buButton btn_ok;

	public buButton btn_cancel;

	public buTab buTab_shape;

	public TabPage tabPage_rectangle;

	public TabPage tabPage_circle;

	internal PictureBox pictureBox_0;

	internal buLabel buLabel_0;

	public buSpin spn_rotation;

	public buSpin spn_rectheight;

	public buSpin spn_rectwidth;

	public buSpin spn_circlediameter;

	internal PictureBox pictureBox_1;

	public buSpin spn_roundrectrad;

	public buSpin spn_roundrectheight;

	public buSpin spn_roundrectwidth;

	internal PictureBox pictureBox_2;

	public buSpin spn_ellipseheight;

	public buSpin spn_ellipsewidth;

	internal PictureBox pictureBox_3;

	public buSpin spn_polygondiameter;

	public buSpin spn_polygonside;

	internal PictureBox pictureBox_4;

	public buSpin spn_trianglewidth;

	public buSpin spn_triangleheight;

	internal PictureBox pictureBox_5;

	public buSpin spn_trapezlength1;

	public buSpin spn_trapezlength2;

	public buSpin spn_trapezheight;

	internal PictureBox pictureBox_6;

	public TabPage tabPage_roundrect;

	public TabPage tabPage_ellipse;

	public TabPage tabPage_polygon;

	public TabPage tabPage_triangle;

	public TabPage tabPage_trapez;

	internal buCheckBox buCheckBox_0;

	public buSpin spn_slotheight;

	public buSpin spn_slotwidth;

	internal PictureBox pictureBox_7;

	public TabPage tabPage_keyhole;

	public buSpin spn_keyholelength;

	public buSpin spn_keyholediameter;

	public buSpin spn_keyholewidth;

	internal PictureBox pictureBox_8;

	public TabPage tabPage_slot;

	public F_ShapeAll()
	{
		Class76.smethod_166(this);
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
		spn_rectwidth.Value = Data.RectangleWidth;
		spn_rectheight.Value = Data.RectangleHeight;
		spn_circlediameter.Value = Data.CircleDiameter;
		spn_roundrectwidth.Value = Data.RoundRectangleWidth;
		spn_roundrectheight.Value = Data.RoundRectangleHeight;
		spn_roundrectrad.Value = Data.RoundRectangleRadius;
		spn_ellipsewidth.Value = Data.EllipseWidth;
		spn_ellipseheight.Value = Data.EllipseHeight;
		spn_polygondiameter.Value = Data.PolygonRadius;
		spn_polygonside.Value = Data.PolygonSide;
		spn_trianglewidth.Value = Data.TriangleWidth;
		spn_triangleheight.Value = Data.TriangleHeight;
		spn_trapezlength1.Value = Data.TrapezLength1;
		spn_trapezlength2.Value = Data.TrapezLength2;
		spn_trapezheight.Value = Data.TrapezHeight;
		buCheckBox_0.Check = Data.DiagonalCut;
		spn_slotheight.Value = Data.SlotHeight;
		spn_slotwidth.Value = Data.SlotWidth;
		spn_keyholediameter.Value = Data.KeyHoleDiameter;
		spn_keyholelength.Value = Data.KeyHoleLength;
		spn_keyholewidth.Value = Data.KeyHoleWidth;
		spn_rotation.Value = Data.Rotation;
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			if (Captions.Count > 14)
			{
				buGround_0.Text = Captions[0];
				btn_ok.Text = Captions[13];
				btn_cancel.Text = Captions[14];
			}
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

	internal void method_1(object sender, EventArgs e)
	{
		try
		{
			if (AppBool.TouchPad)
			{
				buSpin buSpin2 = new buSpin();
				buSpin2 = (buSpin)sender;
				buControlCommands.ShowKeyPad(this, buSpin2);
			}
		}
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: true);
		}
	}

	public void Apply()
	{
		Data.RectangleWidth = spn_rectwidth.Value;
		Data.RectangleHeight = spn_rectheight.Value;
		Data.CircleDiameter = spn_circlediameter.Value;
		Data.RoundRectangleWidth = spn_roundrectwidth.Value;
		Data.RoundRectangleHeight = spn_roundrectheight.Value;
		Data.RoundRectangleRadius = spn_roundrectrad.Value;
		Data.EllipseWidth = spn_ellipsewidth.Value;
		Data.EllipseHeight = spn_ellipseheight.Value;
		Data.PolygonRadius = spn_polygondiameter.Value;
		Data.PolygonSide = (int)spn_polygonside.Value;
		Data.TriangleWidth = spn_trianglewidth.Value;
		Data.TriangleHeight = spn_triangleheight.Value;
		Data.TrapezLength1 = spn_trapezlength1.Value;
		Data.TrapezLength2 = spn_trapezlength2.Value;
		Data.TrapezHeight = spn_trapezheight.Value;
		Data.SlotHeight = spn_slotheight.Value;
		Data.SlotWidth = spn_slotwidth.Value;
		Data.KeyHoleDiameter = spn_keyholediameter.Value;
		Data.KeyHoleLength = spn_keyholelength.Value;
		Data.KeyHoleWidth = spn_keyholewidth.Value;
		Data.DiagonalCut = buCheckBox_0.Check;
		Data.Rotation = spn_rotation.Value;
	}

	internal void method_2(object sender, EventArgs e)
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

	internal void method_4(object sender, EventArgs e)
	{
		buSpin buSpin2 = (buSpin)sender;
		buSpin2.Display.BackColor = SpinFocusColor;
	}

	internal void method_5(object sender, EventArgs e)
	{
		buSpin buSpin2 = (buSpin)sender;
		buSpin2.Display.BackColor = SpinBaseColor;
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
