using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ns71;

namespace buEyeBaseVer5.Forms.Materials;

public class F_Material3D : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public MaterialBase5 Material = new MaterialBase5();

	public Design viewportLayout;

	public List<Entity> OptionEntity = null;

	public Entity EntClamper = null;

	public bool DrawDimension = false;

	public static List<string> Captions;

	private Timer timer_0 = new Timer();

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal ComboBox comboBox_0;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_1;

	internal Label label_2;

	internal NumericUpDown numericUpDown_1;

	internal Label label_3;

	internal NumericUpDown numericUpDown_2;

	internal Label label_4;

	internal NumericUpDown numericUpDown_3;

	internal Label label_5;

	internal NumericUpDown numericUpDown_4;

	public Panel pnl_model;

	public F_Material3D()
	{
		Class186.smethod_4(this);
		timer_0.Tick += timer_0_Tick;
	}

	public void Init(MaterialBase5 material)
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
		btn_ok.Enabled = false;
		comboBox_0.Items.Clear();
		comboBox_0.Items.Add(AppLanguage.CadCamDynamic[62]);
		comboBox_0.Items.Add(AppLanguage.CadCamDynamic[51]);
		comboBox_0.Items.Add(AppLanguage.CadCamDynamic[54]);
		comboBox_0.Items.Add(AppLanguage.CadCamDynamic[63]);
		comboBox_0.Items.Add(AppLanguage.CadCamDynamic[64]);
		if (material != null)
		{
			Material = new MaterialBase5(material);
		}
		ControlUpdate();
		LoadLanguage();
		TypeToControl();
		PropertiesForm.Inited = false;
		if (Material.Shapes == MaterialShapes.Rectangle)
		{
			comboBox_0.SelectedIndex = 0;
			label_1.Text = buLangTranslate.preDef.Width + " (X) ";
			label_2.Text = buLangTranslate.preDef.Height + " (Y) ";
			label_3.Text = buLangTranslate.preDef.Depth + " (Z) ";
		}
		if (Material.Shapes == MaterialShapes.Circle)
		{
			comboBox_0.SelectedIndex = 1;
		}
		if (Material.Shapes == MaterialShapes.Ellipse)
		{
			comboBox_0.SelectedIndex = 2;
		}
		if (Material.Shapes == MaterialShapes.RectangleRound)
		{
			comboBox_0.SelectedIndex = 3;
		}
		if (Material.Shapes == MaterialShapes.RectangleChamfer)
		{
			comboBox_0.SelectedIndex = 4;
		}
		timer_0.Interval = 100;
		timer_0.Enabled = true;
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		string callMethod = "LoadLanguage";
		try
		{
			if (Captions.Count >= 9)
			{
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
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
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_ok.Name)
		{
			Material.Entities.Clear();
			for (int i = 0; i <= viewportLayout.Entities.Count - 1; i++)
			{
				Entity copiedEnt = null;
				buVector5.CopyEntities(viewportLayout.Entities[i], ref copiedEnt);
				CustomData entityData = new CustomData();
				copiedEnt.EntityData = entityData;
				Material.Entities.Add(copiedEnt);
			}
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

	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (viewportLayout.IsHandleCreated)
		{
			method_2();
			btn_ok.Enabled = true;
			timer_0.Enabled = false;
		}
	}

	public void TypeToControl()
	{
		label_1.Visible = false;
		label_2.Visible = false;
		label_3.Visible = false;
		label_4.Visible = false;
		label_5.Visible = false;
		numericUpDown_0.Visible = false;
		numericUpDown_1.Visible = false;
		numericUpDown_2.Visible = false;
		numericUpDown_3.Visible = false;
		numericUpDown_4.Visible = false;
		PropertiesForm.Inited = false;
		if (Material.Shapes == MaterialShapes.Rectangle)
		{
			label_1.Text = AppLanguage.CadCamDynamic[15] + " (X) ";
			label_2.Text = AppLanguage.CadCamDynamic[16] + " (Y) ";
			label_3.Text = AppLanguage.CadCamDynamic[113] + " (Z) ";
			label_4.Text = AppLanguage.CadCamDynamic[2];
			numericUpDown_0.Value = (decimal)Material.Size.Width;
			numericUpDown_1.Value = (decimal)Material.Size.Height;
			numericUpDown_2.Value = (decimal)Material.Size.Depth;
			numericUpDown_3.Value = (decimal)Material.Angle;
			label_1.Visible = true;
			label_2.Visible = true;
			label_3.Visible = true;
			label_4.Visible = true;
			numericUpDown_0.Visible = true;
			numericUpDown_1.Visible = true;
			numericUpDown_2.Visible = true;
			numericUpDown_3.Visible = true;
		}
		if (Material.Shapes == MaterialShapes.Circle)
		{
			label_1.Text = AppLanguage.CadCamDynamic[57];
			label_2.Text = AppLanguage.CadCamDynamic[113];
			numericUpDown_0.Value = (decimal)Material.Diameter;
			numericUpDown_1.Value = (decimal)Material.Size.Depth;
			label_1.Visible = true;
			label_2.Visible = true;
			numericUpDown_0.Visible = true;
			numericUpDown_1.Visible = true;
		}
		if (Material.Shapes == MaterialShapes.Ellipse)
		{
			label_1.Text = AppLanguage.CadCamDynamic[20];
			label_2.Text = AppLanguage.CadCamDynamic[21];
			label_3.Text = AppLanguage.CadCamDynamic[113];
			label_4.Text = AppLanguage.CadCamDynamic[2];
			numericUpDown_0.Value = (decimal)Material.MajorRadius;
			numericUpDown_1.Value = (decimal)Material.MinorRadius;
			numericUpDown_2.Value = (decimal)Material.Size.Depth;
			numericUpDown_3.Value = (decimal)Material.Angle;
			label_1.Visible = true;
			label_2.Visible = true;
			label_3.Visible = true;
			label_4.Visible = true;
			numericUpDown_0.Visible = true;
			numericUpDown_1.Visible = true;
			numericUpDown_2.Visible = true;
			numericUpDown_3.Visible = true;
		}
		if (Material.Shapes == MaterialShapes.RectangleRound)
		{
			label_1.Text = AppLanguage.CadCamDynamic[20];
			label_2.Text = AppLanguage.CadCamDynamic[21];
			label_3.Text = AppLanguage.CadCamDynamic[19];
			label_4.Text = AppLanguage.CadCamDynamic[113];
			label_5.Text = AppLanguage.CadCamDynamic[2];
			numericUpDown_0.Value = (decimal)Material.Size.Width;
			numericUpDown_1.Value = (decimal)Material.Size.Height;
			numericUpDown_2.Value = (decimal)Material.Radius;
			numericUpDown_3.Value = (decimal)Material.Size.Depth;
			numericUpDown_4.Value = (decimal)Material.Angle;
			label_1.Visible = true;
			label_2.Visible = true;
			label_3.Visible = true;
			label_4.Visible = true;
			label_5.Visible = true;
			numericUpDown_0.Visible = true;
			numericUpDown_1.Visible = true;
			numericUpDown_2.Visible = true;
			numericUpDown_3.Visible = true;
			numericUpDown_4.Visible = true;
		}
		if (Material.Shapes == MaterialShapes.RectangleChamfer)
		{
			label_1.Text = AppLanguage.CadCamDynamic[20];
			label_2.Text = AppLanguage.CadCamDynamic[21];
			label_3.Text = AppLanguage.CadCamDynamic[65];
			label_4.Text = AppLanguage.CadCamDynamic[113];
			label_5.Text = AppLanguage.CadCamDynamic[2];
			numericUpDown_0.Value = (decimal)Material.Size.Width;
			numericUpDown_1.Value = (decimal)Material.Size.Height;
			numericUpDown_2.Value = (decimal)Material.ChamferLength;
			numericUpDown_3.Value = (decimal)Material.Size.Depth;
			numericUpDown_4.Value = (decimal)Material.Angle;
			label_1.Visible = true;
			label_2.Visible = true;
			label_3.Visible = true;
			label_4.Visible = true;
			label_5.Visible = true;
			numericUpDown_0.Visible = true;
			numericUpDown_1.Visible = true;
			numericUpDown_2.Visible = true;
			numericUpDown_3.Visible = true;
			numericUpDown_4.Visible = true;
		}
		PropertiesForm.Inited = true;
	}

	public void ControlUpdate()
	{
	}

	public void Apply()
	{
	}

	private void method_2()
	{
		if (!PropertiesForm.Inited)
		{
			return;
		}
		viewportLayout.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
		viewportLayout.Entities.Clear();
		if (Material.Shapes != MaterialShapes.Rectangle)
		{
			if (Material.Shapes != MaterialShapes.Circle)
			{
				if (Material.Shapes != MaterialShapes.Ellipse)
				{
					if (Material.Shapes != MaterialShapes.Irregular)
					{
						if (Material.Shapes != MaterialShapes.RectangleRound)
						{
							if (Material.Shapes == MaterialShapes.RectangleChamfer)
							{
								buCall.buVector5_0.RectangleChamfer(new Point3D(), new Point3D(Material.Size.Width, Material.Size.Height), Material.ChamferLength, Plane.XY, ref Material.Points);
								LinearPath outters = new LinearPath(Material.Points);
								Entity entSurface = null;
								if (Material.Points.Count >= 3)
								{
									buCall.buVector5_0.surfaceFromOutterInner(outters, null, Material.Size.Depth, ref entSurface);
									entSurface.Color = Material.Display.SkinColor;
									entSurface.ColorMethod = colorMethodType.byEntity;
									entSurface.Rotate(buConversion5.DegreeToRadian(Material.Angle), Vector3D.AxisZ);
									viewportLayout.Entities.Add(entSurface);
								}
							}
						}
						else
						{
							CompositeCurve compositeCurve = CompositeCurve.CreateRoundedRectangle(Material.Size.Width, Material.Size.Height, Material.Radius);
							compositeCurve.Regen(0.01);
							Entity entSurface2 = null;
							buCall.buVector5_0.surfaceFromOutterInner(compositeCurve, null, Material.Size.Depth, ref entSurface2);
							entSurface2.Color = Material.Display.SkinColor;
							entSurface2.ColorMethod = colorMethodType.byEntity;
							entSurface2.Rotate(buConversion5.DegreeToRadian(Material.Angle), Vector3D.AxisZ);
							viewportLayout.Entities.Add(entSurface2);
						}
					}
					else
					{
						LinearPath outters2 = new LinearPath(Material.Points);
						Entity entSurface3 = null;
						if (Material.Points.Count >= 3)
						{
							buCall.buVector5_0.surfaceFromOutterInner(outters2, null, Material.Size.Depth, ref entSurface3);
							entSurface3.Color = Material.Display.SkinColor;
							entSurface3.ColorMethod = colorMethodType.byEntity;
							entSurface3.Rotate(buConversion5.DegreeToRadian(Material.Angle), Vector3D.AxisZ);
							viewportLayout.Entities.Add(entSurface3);
						}
					}
				}
				else
				{
					Ellipse ellipse = new Ellipse(new Point3D(), Material.MajorRadius, Material.MinorRadius);
					ellipse.Translate(Material.MajorRadius, Material.MinorRadius);
					Entity entSurface4 = null;
					buCall.buVector5_0.surfaceFromOutterInner(ellipse, null, Material.Size.Depth, ref entSurface4);
					entSurface4.Color = Material.Display.SkinColor;
					entSurface4.ColorMethod = colorMethodType.byEntity;
					entSurface4.Rotate(buConversion5.DegreeToRadian(Material.Angle), Vector3D.AxisZ);
					viewportLayout.Entities.Add(entSurface4);
				}
			}
			else
			{
				Circle circle = new Circle(new Point3D(), Material.Diameter / 2.0);
				circle.Translate(Material.Diameter / 2.0, Material.Diameter / 2.0);
				Entity entSurface5 = null;
				buCall.buVector5_0.surfaceFromOutterInner(circle, null, Material.Size.Depth, ref entSurface5);
				entSurface5.Color = Material.Display.SkinColor;
				entSurface5.ColorMethod = colorMethodType.byEntity;
				viewportLayout.Entities.Add(entSurface5);
			}
		}
		else
		{
			CompositeCurve outters3 = CompositeCurve.CreateRectangle(Material.Size.Width, Material.Size.Height);
			Entity entSurface6 = null;
			buCall.buVector5_0.surfaceFromOutterInner(outters3, null, Material.Size.Depth, ref entSurface6);
			entSurface6.Color = Material.Display.SkinColor;
			entSurface6.ColorMethod = colorMethodType.byEntity;
			entSurface6.Rotate(buConversion5.DegreeToRadian(Material.Angle), Vector3D.AxisZ);
			viewportLayout.Entities.Add(entSurface6);
			if (DrawDimension)
			{
				LinearDim linearDim = new LinearDim(Plane.XY, new Point3D(), new Point3D(Material.Size.Width, 0.0, 0.0), new Point3D(Material.Size.Width / 2.0, -200.0, 0.0), 100.0);
				linearDim.TextOverride = buLangTranslate.preDef.Width + ": " + linearDim.Distance;
				viewportLayout.Entities.Add(linearDim);
				Plane drawingPlane = null;
				buCall.buVector5_0.LinearDimCalculate(new Point3D(0.0, 0.0), new Point3D(0.0, Material.Size.Height), new Point3D(-200.0, Material.Size.Height / 2.0), 100.0, Plane.XY, ref drawingPlane);
				LinearDim linearDim2 = new LinearDim(drawingPlane, new Point3D(), new Point3D(0.0, Material.Size.Height, 0.0), new Point3D(-200.0, Material.Size.Height / 2.0, 0.0), 100.0);
				linearDim2.TextOverride = buLangTranslate.preDef.Height + ": " + linearDim2.Distance;
				viewportLayout.Entities.Add(linearDim2);
				buCall.buVector5_0.LinearDimCalculate(new Point3D(0.0, 0.0, 0.0), new Point3D(0.0, 0.0, Material.Size.Depth), new Point3D(-200.0, 0.0, Material.Size.Depth / 2.0), 100.0, Plane.XZ, ref drawingPlane);
				LinearDim linearDim3 = new LinearDim(drawingPlane, new Point3D(0.0, 0.0, 0.0), new Point3D(0.0, 0.0, Material.Size.Depth), new Point3D(-200.0, 0.0, Material.Size.Depth / 2.0), 100.0);
				linearDim3.TextOverride = buLangTranslate.preDef.Depth + ": " + linearDim3.Distance;
				viewportLayout.Entities.Add(linearDim3);
			}
		}
		if (OptionEntity != null)
		{
			for (int i = 0; i <= OptionEntity.Count - 1; i++)
			{
				viewportLayout.Entities.Add(OptionEntity[i]);
			}
		}
		if (EntClamper != null)
		{
			EntClamper.Regen(0.01);
			double clamperLength = EntClamper.BoxMax.X - EntClamper.BoxMin.X;
			double X = 0.0;
			double X2 = 0.0;
			FindFirstClamperPositions(Material.Size.Width, clamperLength, ref X, ref X2);
			Entity copiedEntity = null;
			Entity copiedEntity2 = null;
			buEntity.Copy(EntClamper, ref copiedEntity);
			copiedEntity.Rotate(Math.PI, Vector3D.AxisZ);
			copiedEntity.Translate(X, 0.0);
			copiedEntity.LayerName = "Default";
			copiedEntity.Color = Color.Gray;
			copiedEntity.ColorMethod = colorMethodType.byEntity;
			buEntity.Copy(EntClamper, ref copiedEntity2);
			copiedEntity2.Rotate(Math.PI, Vector3D.AxisZ);
			copiedEntity2.Translate(X2, 0.0);
			copiedEntity2.LayerName = "Default";
			copiedEntity2.Color = Color.Gray;
			copiedEntity2.ColorMethod = colorMethodType.byEntity;
			viewportLayout.Entities.Add(copiedEntity);
			viewportLayout.Entities.Add(copiedEntity2);
		}
		viewportLayout.ActiveViewport.OriginSymbol.StyleMode = originSymbolStyleType.Ball;
		if (EntClamper == null)
		{
			viewportLayout.SetView(viewType.Top, fit: true, animate: false);
			viewportLayout.ActiveViewport.RotateCamera(Vector3D.AxisX, -45.0, trackBall: false);
			viewportLayout.ActiveViewport.RotateCamera(Vector3D.AxisZ, 20.0, trackBall: false);
		}
		else
		{
			viewportLayout.SetView(viewType.Top, fit: true, animate: false);
			viewportLayout.ActiveViewport.RotateCamera(Vector3D.AxisZ, 180.0, trackBall: false);
			viewportLayout.ActiveViewport.RotateCamera(Vector3D.AxisX, 45.0, trackBall: false);
		}
		viewportLayout.ZoomFit(10);
		viewportLayout.Invalidate();
	}

	internal void method_3(object sender, EventArgs e)
	{
		new Control();
		if (PropertiesForm.Inited)
		{
			if (Material.Shapes == MaterialShapes.Rectangle)
			{
				Material.Size.Width = (double)numericUpDown_0.Value;
				Material.Size.Height = (double)numericUpDown_1.Value;
				Material.Size.Depth = (double)numericUpDown_2.Value;
				Material.Angle = (double)numericUpDown_3.Value;
				method_2();
			}
			if (Material.Shapes == MaterialShapes.Circle)
			{
				Material.Diameter = (double)numericUpDown_0.Value;
				Material.Size.Depth = (double)numericUpDown_1.Value;
				method_2();
			}
			if (Material.Shapes == MaterialShapes.Ellipse)
			{
				Material.MajorRadius = (double)numericUpDown_0.Value;
				Material.MinorRadius = (double)numericUpDown_1.Value;
				Material.Size.Depth = (double)numericUpDown_2.Value;
				Material.Angle = (double)numericUpDown_3.Value;
				method_2();
			}
			if (Material.Shapes == MaterialShapes.RectangleRound)
			{
				Material.Size.Width = (double)numericUpDown_0.Value;
				Material.Size.Height = (double)numericUpDown_1.Value;
				Material.Radius = (double)numericUpDown_2.Value;
				Material.Size.Depth = (double)numericUpDown_3.Value;
				Material.Angle = (double)numericUpDown_4.Value;
				method_2();
			}
			if (Material.Shapes == MaterialShapes.RectangleChamfer)
			{
				Material.Size.Width = (double)numericUpDown_0.Value;
				Material.Size.Height = (double)numericUpDown_1.Value;
				Material.ChamferLength = (double)numericUpDown_2.Value;
				Material.Size.Depth = (double)numericUpDown_3.Value;
				Material.Angle = (double)numericUpDown_4.Value;
				method_2();
			}
			PropertiesForm.Inited = true;
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited)
		{
			if (comboBox_0.SelectedIndex == 0)
			{
				Material.Shapes = MaterialShapes.Rectangle;
				TypeToControl();
				method_2();
			}
			if (comboBox_0.SelectedIndex == 1)
			{
				Material.Shapes = MaterialShapes.Circle;
				TypeToControl();
				method_2();
			}
			if (comboBox_0.SelectedIndex == 2)
			{
				Material.Shapes = MaterialShapes.Ellipse;
				TypeToControl();
				method_2();
			}
			if (comboBox_0.SelectedIndex == 3)
			{
				Material.Shapes = MaterialShapes.RectangleRound;
				TypeToControl();
				method_2();
			}
			if (comboBox_0.SelectedIndex == 4)
			{
				Material.Shapes = MaterialShapes.RectangleChamfer;
				TypeToControl();
				method_2();
			}
		}
	}

	public void FindFirstClamperPositions(double Width, double ClamperLength, ref double X1, ref double X2)
	{
		X2 = ClamperLength / 2.0;
		X1 = Width - ClamperLength / 2.0;
		if (X1 - X2 < ClamperLength + 10.0)
		{
			double num = ClamperLength + 10.0 - (X1 - X2);
			if (num > 0.0)
			{
				X2 += num / 2.0;
				X1 -= num / 2.0;
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

	static F_Material3D()
	{
		Captions = new List<string>();
	}
}
