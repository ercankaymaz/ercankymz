using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleShapeAll : Form
{
	public Color SpinBaseColor = Color.LightGreen;

	public Color SpinFocusColor = Color.MistyRose;

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	public buButton btn_ok;

	public buButton btn_cancel;

	public buTab buTab_shape;

	public TabPage tabPage_circle;

	public buSpin spn_rotation;

	public buSpin spn_circlediameter;

	internal PictureBox pictureBox_0;

	public buSpin spn_roundrectrad;

	public buSpin spn_roundrectheight;

	public buSpin spn_roundrectwidth;

	internal PictureBox pictureBox_1;

	public buSpin spn_ellipseheight;

	public buSpin spn_ellipsewidth;

	internal PictureBox pictureBox_2;

	public buSpin spn_polygondiameter;

	public buSpin spn_polygonside;

	internal PictureBox pictureBox_3;

	public buSpin spn_trianglewidth;

	public buSpin spn_triangleheight;

	internal PictureBox pictureBox_4;

	public buSpin spn_trapezlength1;

	public buSpin spn_trapezlength2;

	public buSpin spn_trapezheight;

	internal PictureBox pictureBox_5;

	public TabPage tabPage_roundrect;

	public TabPage tabPage_ellipse;

	public TabPage tabPage_polygon;

	public TabPage tabPage_triangle;

	public TabPage tabPage_trapez;

	public buSpin spn_slotheight;

	public buSpin spn_slotwidth;

	internal PictureBox pictureBox_6;

	public TabPage tabPage_slot;

	public buSpin spn_archeight;

	public buSpin spn_arcthickns;

	internal PictureBox pictureBox_7;

	public buSpin spn_arcoutsidelength;

	public TabPage tabPage_arc;

	public buButton btn_close;

	public buSpin spn_roundrectangle;

	public buSpin spn_circleangle;

	public buSpin spn_ellipseangle;

	public buSpin spn_polygonangle;

	public buSpin spn_trianglecrossagnle;

	public buSpin spn_trianglebottomagnle;

	public buSpin spn_triangleleftangle;

	public buSpin spn_trapezbottomangle;

	public buSpin spn_trapezrightangle;

	public buSpin spn_trapezleftangle;

	public buSpin spn_trapeztopangle;

	public buSpin spn_slotangl;

	internal TabPage tabPage_0;

	internal TabPage tabPage_1;

	internal TabPage tabPage_2;

	internal TabPage tabPage_3;

	internal TabPage tabPage_4;

	public buSpin spn_rectbottomangle;

	public buSpin spn_rectrightangle;

	public buSpin spn_rectleftangle;

	public buSpin spn_recttopangle;

	public buSpin spn_rectheight;

	public buSpin spn_rectwidth;

	internal PictureBox pictureBox_8;

	public buSpin spn_chamferrectangle;

	public buSpin spn_chamferrectlength;

	public buSpin spn_chamferrectheight;

	public buSpin spn_chamferrectwidth;

	internal PictureBox pictureBox_9;

	public buSpin spn_crossrectbottomangle;

	public buSpin spn_crossrectrightangl;

	public buSpin spn_crossrectleftangle;

	public buSpin spn_crossrecttopangle;

	public buSpin spn_crossrectheight;

	public buSpin spn_crossrectwidth;

	internal PictureBox pictureBox_10;

	public buSpin spn_arcpieangle;

	public buSpin spn_arcpieradius;

	internal PictureBox pictureBox_11;

	public buSpin spn_shiipnosebottomangl;

	public buSpin spn_shiipnoserightangle;

	public buSpin spn_shiipnoseleftangle;

	public buSpin spn_shiipnosetopangle;

	public buSpin spn_shiipnoseheight;

	public buSpin spn_shiipnosewidth;

	internal PictureBox pictureBox_12;

	public buSpin spn_arcpiesweepangle;

	internal buPanel buPanel_0;

	public buSpin spn_yoffset;

	public buSpin spn_ycount;

	public buSpin spn_xoffset;

	public buSpin spn_xcount;

	internal buLabel buLabel_0;

	public buCheckBox chk_copyenable;

	public buButton btn_closeevent;

	public buButton btn_events;

	internal TabPage tabPage_5;

	public buSpin spn_ellipsearcheight;

	public buSpin spn_ellipsearcsweepangle;

	public buSpin spn_ellipsearcangle;

	public buSpin spn_ellipsearcwidth;

	internal PictureBox pictureBox_13;

	public buSpin spn_shiipnosearcydis;

	public buSpin spn_shiipnosearcxdis;

	internal buLabel buLabel_1;

	public buButton btn_applyAngleA;

	internal buLabel buLabel_2;

	public buSpin spn_angleA;

	public buSpin spn_shiipnoseradius;

	public F_MarbleShapeAll()
	{
		Class186.smethod_184(this);
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
		base.Width = 585;
		base.Height = 660;
		base.TopMost = PropertiesForm.TopMost;
		base.StartPosition = PropertiesForm.FormPosition;
		buTab_shape.ItemSize = new Size(1, 1);
		LoadLanguage();
		buPanel_0.Visible = false;
		buLabel_1.Visible = false;
		if (buMarbleCalc.varMarbleRunSettings.ShapeLinearArrayEnable | !buCompare5.EQ(buMarbleCalc.varMarbleRunSettings.ShapeRotation, 0.0))
		{
			buLabel_1.Visible = true;
			buLabel_1.Text = "";
			if (buMarbleCalc.varMarbleRunSettings.ShapeLinearArrayEnable)
			{
				buLabel_1.Text = buLabel_1.Text + buLangTranslate.preSentencesMarble.LinearCopyEnable + Environment.NewLine;
			}
			if (!buCompare5.EQ(buMarbleCalc.varMarbleRunSettings.ShapeRotation, 0.0))
			{
				buLabel_1.Text += buLangTranslate.preSentencesMarble.RotationAngleDifferentThen0;
			}
		}
		spn_rectwidth.Value = buMarbleCalc.varMarbleRunSettings.ShapeRectangleWidth;
		spn_rectheight.Value = buMarbleCalc.varMarbleRunSettings.ShapeRectangleHeight;
		spn_recttopangle.Value = buMarbleCalc.varMarbleRunSettings.ShapeRectangleTopAngle;
		spn_rectbottomangle.Value = buMarbleCalc.varMarbleRunSettings.ShapeRectangleBottomAngle;
		spn_rectleftangle.Value = buMarbleCalc.varMarbleRunSettings.ShapeRectangleLeftAngle;
		spn_rectrightangle.Value = buMarbleCalc.varMarbleRunSettings.ShapeRectangleRightAngle;
		spn_roundrectwidth.Value = buMarbleCalc.varMarbleRunSettings.ShapeRectangleRoundWidth;
		spn_roundrectheight.Value = buMarbleCalc.varMarbleRunSettings.ShapeRectangleRoundHeight;
		spn_roundrectrad.Value = buMarbleCalc.varMarbleRunSettings.ShapeRectangleRoundRadius;
		spn_roundrectangle.Value = buMarbleCalc.varMarbleRunSettings.ShapeRectangleRoundAngle;
		spn_chamferrectwidth.Value = buMarbleCalc.varMarbleRunSettings.ShapeRectangleChamferWidth;
		spn_chamferrectheight.Value = buMarbleCalc.varMarbleRunSettings.ShapeRectangleChamferHeight;
		spn_chamferrectlength.Value = buMarbleCalc.varMarbleRunSettings.ShapeRectangleChamferLength;
		spn_chamferrectangle.Value = buMarbleCalc.varMarbleRunSettings.ShapeRectangleChamferAngle;
		spn_crossrectwidth.Value = buMarbleCalc.varMarbleRunSettings.ShapeRectangleCrossWidth;
		spn_crossrectheight.Value = buMarbleCalc.varMarbleRunSettings.ShapeRectangleCrossHeight;
		spn_crossrecttopangle.Value = buMarbleCalc.varMarbleRunSettings.ShapeRectangleCrossTopAngle;
		spn_crossrectbottomangle.Value = buMarbleCalc.varMarbleRunSettings.ShapeRectangleCrossBottomAngle;
		spn_crossrectleftangle.Value = buMarbleCalc.varMarbleRunSettings.ShapeRectangleCrossLeftAngle;
		spn_crossrectrightangl.Value = buMarbleCalc.varMarbleRunSettings.ShapeRectangleCrossRightAngle;
		spn_circlediameter.Value = buMarbleCalc.varMarbleRunSettings.ShapeCircleDiameter;
		spn_circleangle.Value = buMarbleCalc.varMarbleRunSettings.ShapeCircleAngle;
		spn_arcpieradius.Value = buMarbleCalc.varMarbleRunSettings.ShapeArcPieRadius;
		spn_arcpieangle.Value = buMarbleCalc.varMarbleRunSettings.ShapeArcPieAngle;
		spn_arcpiesweepangle.Value = buMarbleCalc.varMarbleRunSettings.ShapeArcPieSweepAngle;
		spn_ellipsewidth.Value = buMarbleCalc.varMarbleRunSettings.ShapeEllipseWidth;
		spn_ellipseheight.Value = buMarbleCalc.varMarbleRunSettings.ShapeEllipseHeight;
		spn_ellipseangle.Value = buMarbleCalc.varMarbleRunSettings.ShapeEllipseAngle;
		spn_polygondiameter.Value = buMarbleCalc.varMarbleRunSettings.ShapePolygonRadius;
		spn_polygonside.Value = buMarbleCalc.varMarbleRunSettings.ShapePolygonSide;
		spn_polygonangle.Value = buMarbleCalc.varMarbleRunSettings.ShapePolygonAngle;
		spn_trianglewidth.Value = buMarbleCalc.varMarbleRunSettings.ShapeTriangleWidth;
		spn_triangleheight.Value = buMarbleCalc.varMarbleRunSettings.ShapeTriangleHeight;
		spn_triangleleftangle.Value = buMarbleCalc.varMarbleRunSettings.ShapeTriangleLeftAngle;
		spn_trianglebottomagnle.Value = buMarbleCalc.varMarbleRunSettings.ShapeTriangleBottomAngle;
		spn_trianglecrossagnle.Value = buMarbleCalc.varMarbleRunSettings.ShapeTriangleCrossAngle;
		spn_trapezlength1.Value = buMarbleCalc.varMarbleRunSettings.ShapeTrapezLength1;
		spn_trapezlength2.Value = buMarbleCalc.varMarbleRunSettings.ShapeTrapezLength2;
		spn_trapezheight.Value = buMarbleCalc.varMarbleRunSettings.ShapeTrapezHeight;
		spn_trapeztopangle.Value = buMarbleCalc.varMarbleRunSettings.ShapeTrapezTopAngle;
		spn_trapezbottomangle.Value = buMarbleCalc.varMarbleRunSettings.ShapeTrapezBottomAngle;
		spn_trapezleftangle.Value = buMarbleCalc.varMarbleRunSettings.ShapeTrapezLeftAngle;
		spn_trapezrightangle.Value = buMarbleCalc.varMarbleRunSettings.ShapeTrapezRightAngle;
		spn_slotheight.Value = buMarbleCalc.varMarbleRunSettings.ShapeSlotHeight;
		spn_slotwidth.Value = buMarbleCalc.varMarbleRunSettings.ShapeSlotWidth;
		spn_slotangl.Value = buMarbleCalc.varMarbleRunSettings.ShapeSlotAngle;
		spn_archeight.Value = buMarbleCalc.varMarbleRunSettings.ShapeArcHeight;
		spn_arcthickns.Value = buMarbleCalc.varMarbleRunSettings.ShapeArcThickness;
		spn_arcoutsidelength.Value = buMarbleCalc.varMarbleRunSettings.ShapeArcOutsideLength;
		spn_shiipnosewidth.Value = buMarbleCalc.varMarbleRunSettings.ShapeShipNoseWidth;
		spn_shiipnoseheight.Value = buMarbleCalc.varMarbleRunSettings.ShapeShipNoseHeight;
		spn_shiipnosetopangle.Value = buMarbleCalc.varMarbleRunSettings.ShapeShipNoseTopAngle;
		spn_shiipnosebottomangl.Value = buMarbleCalc.varMarbleRunSettings.ShapeShipNoseBottomAngle;
		spn_shiipnoseleftangle.Value = buMarbleCalc.varMarbleRunSettings.ShapeShipNoseLeftAngle;
		spn_shiipnoserightangle.Value = buMarbleCalc.varMarbleRunSettings.ShapeShipNoseRightAngle;
		spn_shiipnosearcxdis.Value = buMarbleCalc.varMarbleRunSettings.ShapeShipNoseArcXDistance;
		spn_shiipnosearcydis.Value = buMarbleCalc.varMarbleRunSettings.ShapeShipNoseArcYDistance;
		spn_shiipnoseradius.Value = buMarbleCalc.varMarbleRunSettings.ShapeShipNoseRadius;
		spn_ellipsearcwidth.Value = buMarbleCalc.varMarbleRunSettings.ShapeEllipsePieWidth;
		spn_ellipsearcheight.Value = buMarbleCalc.varMarbleRunSettings.ShapeEllipsePieHeight;
		spn_ellipsearcangle.Value = buMarbleCalc.varMarbleRunSettings.ShapeEllipsePieAngle;
		spn_ellipsearcsweepangle.Value = buMarbleCalc.varMarbleRunSettings.ShapeEllipsePieSweepAngle;
		spn_rotation.Value = buMarbleCalc.varMarbleRunSettings.ShapeRotation;
		spn_xcount.Value = buMarbleCalc.varMarbleRunSettings.ShapeLinearArrayXCount;
		spn_xoffset.Value = buMarbleCalc.varMarbleRunSettings.ShapeLinearArrayXDistance;
		spn_ycount.Value = buMarbleCalc.varMarbleRunSettings.ShapeLinearArrayYCount;
		spn_yoffset.Value = buMarbleCalc.varMarbleRunSettings.ShapeLinearArrayYDistance;
		chk_copyenable.Check = buMarbleCalc.varMarbleRunSettings.ShapeLinearArrayEnable;
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			buGround_0.Text = buLangTranslate.preDef.Shape;
			btn_ok.Text = buLangTranslate.preDef.Ok;
			btn_cancel.Text = buLangTranslate.preDef.Cancel;
			tabPage_circle.Text = buLangTranslate.preDef.Cirlce;
			tabPage_ellipse.Text = buLangTranslate.preDef.Ellipse;
			tabPage_polygon.Text = buLangTranslate.preDef.Polygon;
			tabPage_roundrect.Text = buLangTranslate.preDef.RectangleRound;
			tabPage_slot.Text = buLangTranslate.preDef.Slot;
			tabPage_trapez.Text = buLangTranslate.preDef.Trapezoid;
			tabPage_triangle.Text = buLangTranslate.preDef.Triangle;
			spn_circlediameter.Caption.Caption = buLangTranslate.preDef.Diameter;
			spn_circleangle.Caption.Caption = buLangTranslate.preDef.Angle;
			spn_ellipseheight.Caption.Caption = buLangTranslate.preDef.Diameter + " X";
			spn_ellipsewidth.Caption.Caption = buLangTranslate.preDef.Diameter + " Y";
			spn_ellipseangle.Caption.Caption = buLangTranslate.preDef.Angle;
			spn_polygondiameter.Caption.Caption = buLangTranslate.preDef.Diameter;
			spn_polygonside.Caption.Caption = buLangTranslate.preDef.Side;
			spn_polygonangle.Caption.Caption = buLangTranslate.preDef.Angle;
			spn_rectheight.Caption.Caption = buLangTranslate.preDef.Height;
			spn_rectwidth.Caption.Caption = buLangTranslate.preDef.Width;
			spn_rectbottomangle.Caption.Caption = buLangTranslate.preDef.Bottom + " " + buLangTranslate.preDef.Angle;
			spn_recttopangle.Caption.Caption = buLangTranslate.preDef.Top + " " + buLangTranslate.preDef.Angle;
			spn_rectleftangle.Caption.Caption = buLangTranslate.preDef.Left + " " + buLangTranslate.preDef.Angle;
			spn_rectrightangle.Caption.Caption = buLangTranslate.preDef.Right + " " + buLangTranslate.preDef.Angle;
			spn_roundrectheight.Caption.Caption = buLangTranslate.preDef.Height;
			spn_roundrectrad.Caption.Caption = buLangTranslate.preDef.Radius;
			spn_roundrectangle.Caption.Caption = buLangTranslate.preDef.Angle;
			spn_roundrectwidth.Caption.Caption = buLangTranslate.preDef.Width;
			spn_chamferrectangle.Caption.Caption = buLangTranslate.preDef.Angle;
			spn_chamferrectheight.Caption.Caption = buLangTranslate.preDef.Height;
			spn_chamferrectlength.Caption.Caption = buLangTranslate.preDef.Length;
			spn_chamferrectwidth.Caption.Caption = buLangTranslate.preDef.Width;
			spn_crossrectheight.Caption.Caption = buLangTranslate.preDef.Height;
			spn_crossrectwidth.Caption.Caption = buLangTranslate.preDef.Width;
			spn_crossrectbottomangle.Caption.Caption = buLangTranslate.preDef.Bottom + " " + buLangTranslate.preDef.Angle;
			spn_crossrecttopangle.Caption.Caption = buLangTranslate.preDef.Top + " " + buLangTranslate.preDef.Angle;
			spn_crossrectleftangle.Caption.Caption = buLangTranslate.preDef.Left + " " + buLangTranslate.preDef.Angle;
			spn_crossrectrightangl.Caption.Caption = buLangTranslate.preDef.Right + " " + buLangTranslate.preDef.Angle;
			spn_slotheight.Caption.Caption = buLangTranslate.preDef.Height;
			spn_slotwidth.Caption.Caption = buLangTranslate.preDef.Width;
			spn_slotangl.Caption.Caption = buLangTranslate.preDef.Angle;
			spn_arcpieangle.Caption.Caption = buLangTranslate.preDef.Angle;
			spn_arcpieradius.Caption.Caption = buLangTranslate.preDef.Radius;
			spn_arcpiesweepangle.Caption.Caption = buLangTranslate.preDef.SweepAngle;
			spn_ellipsearcangle.Caption.Caption = buLangTranslate.preDef.Angle;
			spn_ellipsearcheight.Caption.Caption = buLangTranslate.preDef.Height;
			spn_ellipsearcsweepangle.Caption.Caption = buLangTranslate.preDef.SweepAngle;
			spn_ellipsearcwidth.Caption.Caption = buLangTranslate.preDef.Width;
			spn_shiipnosearcxdis.Caption.Caption = buLangTranslate.preDef.Arc + " X " + buLangTranslate.preDef.Distance;
			spn_shiipnosearcydis.Caption.Caption = buLangTranslate.preDef.Arc + " Y " + buLangTranslate.preDef.Distance;
			spn_shiipnoseheight.Caption.Caption = buLangTranslate.preDef.Width;
			spn_shiipnosewidth.Caption.Caption = buLangTranslate.preDef.Height;
			spn_shiipnosebottomangl.Caption.Caption = buLangTranslate.preDef.Bottom + " " + buLangTranslate.preDef.Angle;
			spn_shiipnoseleftangle.Caption.Caption = buLangTranslate.preDef.Left + " " + buLangTranslate.preDef.Angle;
			spn_shiipnoserightangle.Caption.Caption = buLangTranslate.preDef.Right + " " + buLangTranslate.preDef.Angle;
			spn_shiipnosetopangle.Caption.Caption = buLangTranslate.preDef.Top + " " + buLangTranslate.preDef.Angle;
			spn_shiipnoseradius.Caption.Caption = buLangTranslate.preDef.Radius;
			spn_trapezheight.Caption.Caption = buLangTranslate.preDef.Height;
			spn_trapezlength1.Caption.Caption = buLangTranslate.preDef.Top + " " + buLangTranslate.preDef.Length;
			spn_trapezlength2.Caption.Caption = buLangTranslate.preDef.Bottom + " " + buLangTranslate.preDef.Length;
			spn_trapezbottomangle.Caption.Caption = buLangTranslate.preDef.Bottom + " " + buLangTranslate.preDef.Angle;
			spn_trapezleftangle.Caption.Caption = buLangTranslate.preDef.Left + " " + buLangTranslate.preDef.Angle;
			spn_trapezrightangle.Caption.Caption = buLangTranslate.preDef.Right + " " + buLangTranslate.preDef.Angle;
			spn_trapeztopangle.Caption.Caption = buLangTranslate.preDef.Top + " " + buLangTranslate.preDef.Angle;
			spn_triangleheight.Caption.Caption = buLangTranslate.preDef.Height;
			spn_trianglewidth.Caption.Caption = buLangTranslate.preDef.Width;
			spn_trianglebottomagnle.Caption.Caption = buLangTranslate.preDef.Bottom + " " + buLangTranslate.preDef.Angle;
			spn_trianglecrossagnle.Caption.Caption = buLangTranslate.preDef.Cross + " " + buLangTranslate.preDef.Angle;
			spn_triangleleftangle.Caption.Caption = buLangTranslate.preDef.Left + " " + buLangTranslate.preDef.Angle;
			spn_rotation.Caption.Caption = buLangTranslate.preDef.Rotate;
			spn_archeight.Caption.Caption = buLangTranslate.preDef.Height;
			spn_arcthickns.Caption.Caption = buLangTranslate.preDef.Thickness;
			spn_arcoutsidelength.Caption.Caption = buLangTranslate.preDef.Length;
			chk_copyenable.Text = buLangTranslate.preDef.Copy;
			buLabel_0.Text = buLangTranslate.preDef.Rotate;
			buLabel_2.Text = "A " + buLangTranslate.preDef.Angle;
			btn_applyAngleA.Text = buLangTranslate.preDef.Apply;
			spn_xcount.Caption.Caption = "X " + buLangTranslate.preDef.Count;
			spn_ycount.Caption.Caption = "Y " + buLangTranslate.preDef.Count;
			spn_xoffset.Caption.Caption = "X " + buLangTranslate.preDef.Offset;
			spn_yoffset.Caption.Caption = "Y " + buLangTranslate.preDef.Offset;
			spn_angleA.Caption.Caption = "A " + buLangTranslate.preDef.Angle;
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
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: true);
		}
	}

	public void Apply()
	{
		buMarbleCalc.varMarbleRunSettings.ShapeRectangleWidth = spn_rectwidth.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeRectangleHeight = spn_rectheight.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeRectangleTopAngle = spn_recttopangle.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeRectangleBottomAngle = spn_rectbottomangle.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeRectangleLeftAngle = spn_rectleftangle.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeRectangleRightAngle = spn_rectrightangle.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeRectangleRoundWidth = spn_roundrectwidth.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeRectangleRoundHeight = spn_roundrectheight.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeRectangleRoundRadius = spn_roundrectrad.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeRectangleRoundAngle = spn_roundrectangle.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeRectangleChamferWidth = spn_chamferrectwidth.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeRectangleChamferHeight = spn_chamferrectheight.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeRectangleChamferLength = spn_chamferrectlength.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeRectangleChamferAngle = spn_chamferrectangle.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeRectangleCrossWidth = spn_crossrectwidth.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeRectangleCrossHeight = spn_crossrectheight.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeRectangleCrossTopAngle = spn_crossrecttopangle.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeRectangleCrossBottomAngle = spn_crossrectbottomangle.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeRectangleCrossLeftAngle = spn_crossrectleftangle.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeRectangleCrossRightAngle = spn_crossrectrightangl.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeCircleDiameter = spn_circlediameter.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeCircleAngle = spn_circleangle.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeArcPieRadius = spn_arcpieradius.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeArcPieAngle = spn_arcpieangle.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeArcPieSweepAngle = spn_arcpiesweepangle.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeEllipseWidth = spn_ellipsewidth.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeEllipseHeight = spn_ellipseheight.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeEllipseAngle = spn_ellipseangle.Value;
		buMarbleCalc.varMarbleRunSettings.ShapePolygonRadius = spn_polygondiameter.Value;
		buMarbleCalc.varMarbleRunSettings.ShapePolygonSide = (int)spn_polygonside.Value;
		buMarbleCalc.varMarbleRunSettings.ShapePolygonAngle = spn_polygonangle.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeTriangleWidth = spn_trianglewidth.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeTriangleHeight = spn_triangleheight.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeTriangleLeftAngle = spn_triangleleftangle.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeTriangleBottomAngle = spn_trianglebottomagnle.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeTriangleCrossAngle = spn_trianglecrossagnle.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeTrapezLength1 = spn_trapezlength1.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeTrapezLength2 = spn_trapezlength2.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeTrapezHeight = spn_trapezheight.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeTrapezTopAngle = spn_trapeztopangle.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeTrapezBottomAngle = spn_trapezbottomangle.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeTrapezLeftAngle = spn_trapezleftangle.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeTrapezRightAngle = spn_trapezrightangle.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeSlotHeight = spn_slotheight.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeSlotWidth = spn_slotwidth.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeSlotAngle = spn_slotangl.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeArcHeight = spn_archeight.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeArcThickness = spn_arcthickns.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeArcOutsideLength = spn_arcoutsidelength.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeShipNoseWidth = spn_shiipnosewidth.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeShipNoseHeight = spn_shiipnoseheight.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeShipNoseTopAngle = spn_shiipnosetopangle.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeShipNoseBottomAngle = spn_shiipnosebottomangl.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeShipNoseLeftAngle = spn_shiipnoseleftangle.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeShipNoseRightAngle = spn_shiipnoserightangle.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeShipNoseArcXDistance = spn_shiipnosearcxdis.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeShipNoseArcYDistance = spn_shiipnosearcydis.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeShipNoseRadius = spn_shiipnoseradius.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeEllipsePieWidth = spn_ellipsearcwidth.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeEllipsePieHeight = spn_ellipsearcheight.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeEllipsePieAngle = spn_ellipsearcangle.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeEllipsePieSweepAngle = spn_ellipsearcsweepangle.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeRotation = spn_rotation.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeLinearArrayXCount = spn_xcount.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeLinearArrayXDistance = spn_xoffset.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeLinearArrayYCount = spn_ycount.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeLinearArrayYDistance = spn_yoffset.Value;
		buMarbleCalc.varMarbleRunSettings.ShapeLinearArrayEnable = chk_copyenable.Check;
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

	internal void method_6(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == btn_events.Name)
		{
			if (buPanel_0.Visible)
			{
				buPanel_0.Visible = false;
			}
			else
			{
				buPanel_0.Visible = true;
			}
			buLabel_1.Visible = false;
			if (chk_copyenable.Check | !buCompare5.EQ(spn_rotation.Value, 0.0))
			{
				buLabel_1.Visible = true;
				buLabel_1.Text = "";
				if (chk_copyenable.Check)
				{
					buLabel_1.Text = buLabel_1.Text + buLangTranslate.preSentencesMarble.LinearCopyEnable + Environment.NewLine;
				}
				if (!buCompare5.EQ(spn_rotation.Value, 0.0))
				{
					buLabel_1.Text += buLangTranslate.preSentencesMarble.RotationAngleDifferentThen0;
				}
			}
		}
		if (control.Name == btn_closeevent.Name)
		{
			buPanel_0.Visible = false;
			buLabel_1.Visible = false;
			if (chk_copyenable.Check | !buCompare5.EQ(spn_rotation.Value, 0.0))
			{
				buLabel_1.Visible = true;
				buLabel_1.Text = "";
				if (chk_copyenable.Check)
				{
					buLabel_1.Text = buLabel_1.Text + buLangTranslate.preSentencesMarble.LinearCopyEnable + Environment.NewLine;
				}
				if (!buCompare5.EQ(spn_rotation.Value, 0.0))
				{
					buLabel_1.Text += buLangTranslate.preSentencesMarble.RotationAngleDifferentThen0;
				}
			}
		}
		if (!(control.Name == btn_applyAngleA.Name))
		{
			return;
		}
		if (buTab_shape.SelectedIndex != 0)
		{
			if (buTab_shape.SelectedIndex != 1)
			{
				if (buTab_shape.SelectedIndex != 2)
				{
					if (buTab_shape.SelectedIndex != 3)
					{
						if (buTab_shape.SelectedIndex != 4)
						{
							if (buTab_shape.SelectedIndex != 5)
							{
								if (buTab_shape.SelectedIndex != 6)
								{
									if (buTab_shape.SelectedIndex != 7)
									{
										if (buTab_shape.SelectedIndex != 8)
										{
											if (buTab_shape.SelectedIndex != 9)
											{
												if (buTab_shape.SelectedIndex != 10)
												{
													if (buTab_shape.SelectedIndex == 11)
													{
														return;
													}
													if (buTab_shape.SelectedIndex != 12)
													{
														if (buTab_shape.SelectedIndex == 13)
														{
															spn_ellipsearcangle.Value = spn_angleA.Value;
														}
													}
													else
													{
														spn_shiipnosebottomangl.Value = spn_angleA.Value;
														spn_shiipnoseleftangle.Value = spn_angleA.Value;
														spn_shiipnoserightangle.Value = spn_angleA.Value;
														spn_shiipnosetopangle.Value = spn_angleA.Value;
													}
												}
												else
												{
													spn_slotangl.Value = spn_angleA.Value;
												}
											}
											else
											{
												spn_trapezrightangle.Value = spn_angleA.Value;
												spn_trapezleftangle.Value = spn_angleA.Value;
												spn_trapeztopangle.Value = spn_angleA.Value;
												spn_trapezbottomangle.Value = spn_angleA.Value;
											}
										}
										else
										{
											spn_trianglebottomagnle.Value = spn_angleA.Value;
											spn_trianglecrossagnle.Value = spn_angleA.Value;
											spn_triangleleftangle.Value = spn_angleA.Value;
										}
									}
									else
									{
										spn_polygonangle.Value = spn_angleA.Value;
									}
								}
								else
								{
									spn_ellipseangle.Value = spn_angleA.Value;
								}
							}
							else
							{
								spn_arcpieangle.Value = spn_angleA.Value;
							}
						}
						else
						{
							spn_circleangle.Value = spn_angleA.Value;
						}
					}
					else
					{
						spn_crossrectbottomangle.Value = spn_angleA.Value;
						spn_crossrectleftangle.Value = spn_angleA.Value;
						spn_crossrectrightangl.Value = spn_angleA.Value;
						spn_crossrecttopangle.Value = spn_angleA.Value;
					}
				}
				else
				{
					spn_chamferrectangle.Value = spn_angleA.Value;
				}
			}
			else
			{
				spn_roundrectangle.Value = spn_angleA.Value;
			}
		}
		else
		{
			spn_rectbottomangle.Value = spn_angleA.Value;
			spn_recttopangle.Value = spn_angleA.Value;
			spn_rectleftangle.Value = spn_angleA.Value;
			spn_rectrightangle.Value = spn_angleA.Value;
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
