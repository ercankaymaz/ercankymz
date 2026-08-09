using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using buApplication3D.UserInterfaces;
using buClass;
using devDept;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using devDept.Graphics;

namespace buEyeBaseVer5;

public class buEyeShotFunctions
{
	public static void DisposeAll()
	{
		if (buEyeItems.viewportCadCam != null)
		{
			buEyeItems.viewportCadCam.Dispose();
		}
		if (buEyeItems.viewportCNC != null)
		{
			buEyeItems.viewportCNC.Dispose();
		}
		if (buEyeItems.viewportDialogs != null)
		{
			buEyeItems.viewportDialogs.Dispose();
		}
	}

	public static void ExchangeTwoVaues(ref Point3D Val1, ref Point3D Val2)
	{
		Point3D point3D = new Point3D(Val1.X, Val1.Y, Val1.Z);
		Val1 = new Point3D(Val2.X, Val2.Y, Val2.Z);
		Val2 = point3D;
	}

	public static void CreateControlsTool(bool FirstCreate, EyeCreateProps Properties, ref Design viewport)
	{
		if (FirstCreate)
		{
			viewport = new Design();
			viewport.InitializeViewports();
			viewport.CreateControl();
			viewport.CreateGraphics();
			viewport.Dock = DockStyle.Fill;
		}
		BackgroundSettings background = new BackgroundSettings(backgroundStyleType.LinearGradient, Properties.BottomColor, Properties.IntermediateColor, Properties.TopColor, 0.75, null, colorThemeType.Auto, 0.3);
		viewport.Viewports[0].Background = background;
		viewport.ActiveViewport.DisplayMode = Properties.DisplayType;
		viewport.Viewports[0].Pan.MouseButton = new MouseButton(Properties.PanMouseButton.Button, Properties.PanMouseButton.ModifierKey);
		viewport.Viewports[0].Rotate.MouseButton = new MouseButton(Properties.RotateMouseButton.Button, Properties.RotateMouseButton.ModifierKey);
		viewport.Viewports[0].Zoom.MouseButton = new MouseButton(Properties.ZoomMouseButton.Button, Properties.ZoomMouseButton.ModifierKey);
		viewport.Viewports[0].Camera.ProjectionMode = Properties.ProjectionType;
		viewport.Viewports[0].Grid.Visible = Properties.ShowGrid;
		viewport.Viewports[0].OriginSymbol.Visible = Properties.ShowOrigin;
		viewport.Viewports[0].Zoom.ReverseMouseWheel = Properties.ReverseMouseWheel;
		viewport.Viewports[0].OriginSymbol.LabelOrigin = Properties.OriginString;
		viewport.Viewports[0].OriginSymbol.StyleMode = Properties.OriginSymbol;
		viewport.Viewports[0].OriginSymbol.Size = Properties.OrigineSize;
		viewport.Viewports[0].CoordinateSystemIcon.Visible = Properties.ShowCoordinateArrow;
		viewport.Viewports[0].ViewCubeIcon.Visible = Properties.ShowViewCube;
		viewport.Viewports[0].ToolBar.Visible = Properties.ShowToolBar;
		viewport.Viewports[0].OriginSymbol.Visible = Properties.ShowOrigin;
		viewport.ActiveViewport.ToolBar.Visible = Properties.ShowToolBar;
		viewport.ActiveViewport.OriginSymbol.Visible = Properties.ShowOrigin;
		viewport.ActiveViewport.CoordinateSystemIcon.Visible = Properties.ShowCoordinateArrow;
		if (Properties.Width > 0)
		{
			viewport.Width = Properties.Width;
		}
		if (Properties.Height > 0)
		{
			viewport.Height = Properties.Height;
		}
	}

	public static Design CreateControlsTool(bool FirstCreate, EyeCreateProps Properties)
	{
		Design viewport = null;
		CreateControlsTool(FirstCreate, Properties, ref viewport);
		return viewport;
	}

	public static bool isTextStyleAvailable(Design Viewport, string TextStyleName)
	{
		if (Viewport != null && Viewport.TextStyles != null)
		{
			for (int i = 0; i <= Viewport.TextStyles.Count - 1; i++)
			{
				if (Viewport.TextStyles[i].Name == TextStyleName)
				{
					return true;
				}
			}
		}
		return false;
	}

	public static bool isBlockAvailable(Design Viewport, string BlockName)
	{
		if (Viewport != null && Viewport.Blocks != null)
		{
			for (int i = 0; i <= Viewport.Blocks.Count - 1; i++)
			{
				if (Viewport.Blocks[i].Name == BlockName)
				{
					return true;
				}
			}
		}
		return false;
	}

	public static bool isHatchAvailable(Design Viewport, string HatchName)
	{
		if (Viewport != null && Viewport.HatchPatterns != null)
		{
			for (int i = 0; i <= Viewport.HatchPatterns.Count - 1; i++)
			{
				if (Viewport.HatchPatterns[i].Name == HatchName)
				{
					return true;
				}
			}
		}
		return false;
	}

	public static bool isLineTypeAvailable(Design Viewport, string LineTypeName)
	{
		if (Viewport != null && Viewport.LineTypes != null)
		{
			for (int i = 0; i <= Viewport.LineTypes.Count - 1; i++)
			{
				if (Viewport.LineTypes[i].Name == LineTypeName)
				{
					return true;
				}
			}
		}
		return false;
	}

	public static bool isLayerAvailable(Design Viewport, string LayerName)
	{
		if (Viewport != null && Viewport.Layers != null)
		{
			for (int i = 0; i <= Viewport.Layers.Count - 1; i++)
			{
				if (Viewport.Layers[i].Name == LayerName)
				{
					return true;
				}
			}
		}
		return false;
	}

	public static void ShowViewportViewBox(ref Design Viewport, bool Show)
	{
		Viewport.ActiveViewport.ViewCubeIcon.Visible = Show;
	}

	public static void ShowViewportToolbar(ref Design Viewport, bool Show)
	{
		Viewport.ActiveViewport.ToolBar.Visible = Show;
	}

	public static void ZoomFit(ref Design Viewport)
	{
		if (Viewport.Entities.Count > 0)
		{
			Viewport.ZoomFit();
			Viewport.Invalidate();
		}
	}

	public static void ViewTop(ref Design Viewport, bool isZoomFit)
	{
		if (Viewport.Entities.Count > 0)
		{
			Viewport.SetView(viewType.Top);
			if (isZoomFit)
			{
				Viewport.ZoomFit();
			}
			Viewport.Invalidate();
		}
	}

	public static void Viewfront(ref Design Viewport, bool isZoomFit)
	{
		if (Viewport.Entities.Count > 0)
		{
			Viewport.SetView(viewType.Front);
			if (isZoomFit)
			{
				Viewport.ZoomFit();
			}
			Viewport.Invalidate();
		}
	}

	public static void ViewBack(ref Design Viewport, bool isZoomFit)
	{
		if (Viewport.Entities.Count > 0)
		{
			Viewport.SetView(viewType.Rear);
			if (isZoomFit)
			{
				Viewport.ZoomFit();
			}
			Viewport.Invalidate();
		}
	}

	public static void ViewBottom(ref Design Viewport, bool isZoomFit)
	{
		if (Viewport.Entities.Count > 0)
		{
			Viewport.SetView(viewType.Bottom);
			if (isZoomFit)
			{
				Viewport.ZoomFit();
			}
			Viewport.Invalidate();
		}
	}

	public static void ViewRight(ref Design Viewport, bool isZoomFit)
	{
		if (Viewport.Entities.Count > 0)
		{
			Viewport.SetView(viewType.Right);
			if (isZoomFit)
			{
				Viewport.ZoomFit();
			}
			Viewport.Invalidate();
		}
	}

	public static void ViewLeft(ref Design Viewport, bool isZoomFit)
	{
		if (Viewport.Entities.Count > 0)
		{
			Viewport.SetView(viewType.Left);
			if (isZoomFit)
			{
				Viewport.ZoomFit();
			}
			Viewport.Invalidate();
		}
	}

	public static void ViewIso(ref Design Viewport, bool isZoomFit)
	{
		if (Viewport.Entities.Count > 0)
		{
			Viewport.SetView(viewType.Isometric);
			if (isZoomFit)
			{
				Viewport.ZoomFit();
			}
			Viewport.Invalidate();
		}
	}

	public static void ViewTrimetric(ref Design Viewport, bool isZoomFit)
	{
		if (Viewport.Entities.Count > 0)
		{
			Viewport.SetView(viewType.Trimetric);
			if (isZoomFit)
			{
				Viewport.ZoomFit();
			}
			Viewport.Invalidate();
		}
	}

	public static void ViewProfile(ref Design Viewport, bool isZoomFit)
	{
		if (Viewport.Entities.Count > 0)
		{
			Viewport.SetView(viewType.vcFrontFaceTopLeft);
			if (isZoomFit)
			{
				Viewport.ZoomFit();
			}
			Viewport.Invalidate();
		}
	}

	public static void ViewPan(ref Design Viewport)
	{
		if (Viewport.Entities.Count > 0)
		{
			if (Viewport.ActionMode == actionType.Pan)
			{
				Viewport.ActionMode = actionType.None;
			}
			else
			{
				Viewport.ActionMode = actionType.Pan;
			}
		}
	}

	public static void ViewRotate(ref Design Viewport)
	{
		if (Viewport.Entities.Count > 0)
		{
			if (Viewport.ActionMode == actionType.Rotate)
			{
				Viewport.ActionMode = actionType.None;
			}
			else
			{
				Viewport.ActionMode = actionType.Rotate;
			}
		}
	}

	public static void ViewZoomIn(ref Design Viewport)
	{
		if (Viewport.Entities.Count > 0)
		{
			Viewport.ZoomCamera(10);
			Viewport.Invalidate();
		}
	}

	public static void ViewZoomOut(ref Design Viewport)
	{
		if (Viewport.Entities.Count > 0)
		{
			Viewport.ZoomCamera(-10);
			Viewport.Invalidate();
		}
	}

	public static void ViewZoomNormal(ref Design Viewport)
	{
		if (Viewport.Entities.Count > 0)
		{
			Viewport.ZoomFit();
			Viewport.Invalidate();
		}
	}

	public static void ViewZoomWindow(ref Design Viewport)
	{
		if (Viewport.Entities.Count > 0)
		{
			if (Viewport.ActionMode == actionType.ZoomWindow)
			{
				Viewport.ActionMode = actionType.None;
			}
			else
			{
				Viewport.ActionMode = actionType.ZoomWindow;
			}
		}
	}

	public static void ShowProgressBar(ref Design Viewport, bool Show)
	{
		Viewport.ProgressBar.Visible = Show;
	}

	public static void EnableWaitCursor(ref Design Viewport, bool Enable)
	{
		if (Enable)
		{
			Viewport.WaitCursorMode = waitCursorType.RegenAndBoundingBox;
		}
		else
		{
			Viewport.WaitCursorMode = waitCursorType.Never;
		}
	}

	public static void CopyView(Design refViewport, ref Design copiedViewport)
	{
		refViewport.SaveView(out var saved);
		copiedViewport.RestoreView(saved);
		copiedViewport.Invalidate();
	}

	public static void CreateBoxWithCenter(Point3D CenterPoint, double Width, double Height, double Depth, bool isZCenter, ref Mesh entMesh)
	{
		entMesh = new Mesh();
		entMesh = Mesh.CreateBox(Width, Height, Depth);
		double num = 0.0;
		if (isZCenter)
		{
			num = Depth / 2.0;
		}
		entMesh.Translate(CenterPoint.X - Width / 2.0, CenterPoint.Y - Height / 2.0, CenterPoint.Z - num);
	}

	public static void CreateCylinderWithCenter(Point3D CenterPoint, double Radius, double Length, double RotationAngle, ref Mesh entMesh)
	{
		entMesh = new Mesh();
		entMesh = Mesh.CreateCylinder(Radius, Length, 40);
		entMesh.Translate(CenterPoint.X, CenterPoint.Y, CenterPoint.Z);
		if (RotationAngle != 0.0)
		{
			entMesh.Rotate(buConversion5.DegreeToRadian(RotationAngle), new Vector3D(1.0, 0.0, 0.0));
		}
	}

	public static void CreateConeWithCenter(Point3D CenterPoint, double BottomRadius, double TopRadius, double Length, double RotationAngle, ref Mesh entMesh)
	{
		entMesh = new Mesh();
		entMesh = Mesh.CreateCone(BottomRadius, TopRadius, Length, 40);
		entMesh.Translate(CenterPoint.X, CenterPoint.Y, CenterPoint.Z);
		if (RotationAngle != 0.0)
		{
			entMesh.Rotate(buConversion5.DegreeToRadian(RotationAngle), new Vector3D(1.0, 0.0, 0.0));
		}
	}

	public static void CreateArrow(Point3D BasePoint, Point3D TipPoint, double BottomRadius, double ArrowHeadRadius, double TotalLength, double ArrowHeadLenght, Color color, ref Mesh entMesh)
	{
		entMesh = new Mesh();
		Vector3D direction = new Vector3D(TipPoint.X - BasePoint.X, TipPoint.Y - BasePoint.Y, TipPoint.Z - BasePoint.Z);
		entMesh = Mesh.CreateArrow(BasePoint, direction, BottomRadius, TotalLength, ArrowHeadRadius, ArrowHeadLenght, 40, Mesh.natureType.Smooth, Mesh.edgeStyleType.Sharp);
		entMesh.Color = color;
	}

	public static void CreateSphere(Point3D BasePoint, double Radius, Color color, ref Mesh entMesh)
	{
		entMesh = new Mesh();
		entMesh = Mesh.CreateSphere(Radius, 10, 10, Mesh.natureType.Smooth);
		entMesh.Color = color;
		entMesh.Translate(BasePoint.X, BasePoint.Y, BasePoint.Z);
	}

	public static void CreateQuad(Quad3D quad, Color color, ref Mesh entMesh)
	{
		List<Point3D> list = new List<Point3D>();
		ClockDirectionType clockDirectionType = ClockDirectionType.CW;
		List<List<Pnt3D>> list2 = new List<List<Pnt3D>>();
		Plane pln = new Plane();
		list.Add(buVector5.ToPoint3D(quad.FirstPoint));
		list.Add(buVector5.ToPoint3D(quad.SecondPoint));
		list.Add(buVector5.ToPoint3D(quad.ThirdPoint));
		list.Add(buVector5.ToPoint3D(quad.FourthPoint));
		list.Add(buVector5.ToPoint3D(quad.FirstPoint));
		if (buCall.buVector5_0.GetClockDirection(list) != ClockDirectionType.CCW)
		{
			list.Reverse();
		}
		List<Point3D> list3 = new List<Point3D>();
		for (int i = 0; i <= list.Count - 1; i++)
		{
			list3.Add(new Point3D(list[i].X, list[i].Y, list[i].Z));
		}
		List<ICurve> list4 = new List<ICurve>();
		ICurve item = Curve.GlobalInterpolation(list3, 1);
		list4.Add(item);
		if (list2.Count > 0)
		{
			for (int j = 0; j <= list2.Count - 1; j++)
			{
				list3 = new List<Point3D>();
				for (int k = 0; k <= list2[j].Count - 1; k++)
				{
					list3.Add(new Point3D(list2[j][k].X, list2[j][k].Y, list2[j][k].Z));
				}
				ICurve item2 = Curve.GlobalInterpolation(list3, 1);
				list4.Add(item2);
			}
		}
		devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(list4, pln);
		entMesh = region.ExtrudeAsMesh(0.01, 0.01, Mesh.natureType.Plain);
		entMesh.Color = color;
	}

	public static void SurfaceRevolveFromCurve(List<Point3D> Points, double StartAngle, double EndAngle, Vector3D vecDir, Point3D pntCenter, Color color, ref Mesh entMesh)
	{
		List<Point3D> list = new List<Point3D>();
		for (int i = 0; i <= Points.Count - 1; i++)
		{
			list.Add(new Point3D(Points[i].X, Points[i].Y, Points[i].Z));
		}
		ICurve curve = Curve.GlobalInterpolation(list, 1);
		entMesh = curve.RevolveAsMesh(StartAngle, EndAngle - StartAngle, vecDir, pntCenter, 20, 0.1, Mesh.natureType.Smooth);
		entMesh.Color = color;
	}

	public static bool GetLayerColorFromName(string LayerName, ref Color colorLayer)
	{
		if (buCall.list_0 != null)
		{
			for (int i = 0; i <= buCall.list_0.Count - 1; i++)
			{
				if (buCall.list_0[i].Name == LayerName)
				{
					colorLayer = buCall.list_0[i].LayerColor;
					return true;
				}
			}
		}
		return false;
	}

	public void SketchWorkCompleted(object sender, WorkCompletedEventArgs e)
	{
		if (e.WorkUnit is ReadFileAsync)
		{
			ReadFileAsync readFileAsync = (ReadFileAsync)e.WorkUnit;
			RegenOptions ro = new RegenOptions();
			_ = e.WorkUnit is ReadFile;
			readFileAsync.OpenTo(buUserControls.desingSketch, ro);
		}
	}
}
