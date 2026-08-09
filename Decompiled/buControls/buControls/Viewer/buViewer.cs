using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buCore;
using ns27;

namespace buControls.Viewer;

public class buViewer : UserControl
{
	private static string string_0;

	private static string string_1;

	private static string string_2;

	private static string string_3;

	private static double double_0;

	private static double double_1;

	public Bitmap Bmp = null;

	private bool bool_0 = false;

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	[CompilerGenerated]
	private EventHandler eventHandler_1;

	[CompilerGenerated]
	private buMouseMoveEventHandler buMouseMoveEventHandler_0;

	[CompilerGenerated]
	private buMouseMoveEventHandler buMouseMoveEventHandler_1;

	[CompilerGenerated]
	private buMouseMoveEventHandler buMouseMoveEventHandler_2;

	public List<eEntities> Entities = new List<eEntities>();

	public List<eEntities> CamEntities = new List<eEntities>();

	public List<eEntities> MaterialEntities = new List<eEntities>();

	public List<eEntities> DimensionEntities = new List<eEntities>();

	public List<eEntities> ArrowEntities = new List<eEntities>();

	public List<Pnt3D> RunTimeDrawingPoints = new List<Pnt3D>();

	public List<eText> Texts = new List<eText>();

	public Image BackImage = null;

	public ProjectionModeType viewProjectionMode = ProjectionModeType.Orthographic;

	public Camera viewCamera = new Camera();

	public AngleVector viewAngle = new AngleVector(0.0, 0.0, 0.0);

	public Pnt3D viewRotateCenter = new Pnt3D();

	public bool ShowMouseCoordinateOnScreen = false;

	public bool ShowContentMenu = false;

	public ContentAlignment TextsAlignment = ContentAlignment.MiddleCenter;

	public bool TextDynamicalHeight = true;

	public int ExecutedLineIndex = -1;

	public double ScreenWidth = 100.0;

	public double ScreenHeight = 100.0;

	public double ScreenTop = 100.0;

	public double ScreenLeft = 0.0;

	public int ClientWidth = 0;

	public int ClientHeight = 0;

	public Image ImageDraw = null;

	public Color ExecutedEntityColor = Color.DarkOrange;

	public Color SelectedEntityColor = Color.Yellow;

	public Color CamEntitiesColor = Color.Red;

	public Color RuntimeDrawingColor = Color.LimeGreen;

	public double SelectedEntityThickness = 1.0;

	public bool MirrorDraw = false;

	public bool Only2D = true;

	public bool DisableMouseWheel = false;

	public double ViewLeft = 0.0;

	public double ViewRight = 0.0;

	public double ViewTop = 0.0;

	public double ViewBottom = 0.0;

	public BoxSize BoxSizeOfEntities = new BoxSize();

	public double AspectRatio = 1.0;

	public Pnt3D ScreenCoordinate = new Pnt3D();

	public SimulationTool SimTool = new SimulationTool();

	private bool bool_1 = false;

	private Pnt3D pnt3D_0 = new Pnt3D();

	private Color color_0 = Color.WhiteSmoke;

	private Pnt3D pnt3D_1 = new Pnt3D(1.0, 1.0, 1.0);

	internal IContainer icontainer_0 = null;

	internal PictureBox pictureBox_0;

	internal ContextMenuStrip contextMenuStrip_0;

	internal ToolStripMenuItem toolStripMenuItem_0;

	[DefaultValue(typeof(Color), "WhiteSmoke")]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public override Color BackColor
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
			DrawEntities();
			Invalidate();
		}
	}

	public event EventHandler Selected
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler DoubleClickSelect
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_1;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_1;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event buMouseMoveEventHandler MouseMovePosition
	{
		[CompilerGenerated]
		add
		{
			buMouseMoveEventHandler buMouseMoveEventHandler2 = buMouseMoveEventHandler_0;
			buMouseMoveEventHandler buMouseMoveEventHandler3;
			do
			{
				buMouseMoveEventHandler3 = buMouseMoveEventHandler2;
				buMouseMoveEventHandler value2 = (buMouseMoveEventHandler)Delegate.Combine(buMouseMoveEventHandler3, value);
				buMouseMoveEventHandler2 = Interlocked.CompareExchange(ref buMouseMoveEventHandler_0, value2, buMouseMoveEventHandler3);
			}
			while ((object)buMouseMoveEventHandler2 != buMouseMoveEventHandler3);
		}
		[CompilerGenerated]
		remove
		{
			buMouseMoveEventHandler buMouseMoveEventHandler2 = buMouseMoveEventHandler_0;
			buMouseMoveEventHandler buMouseMoveEventHandler3;
			do
			{
				buMouseMoveEventHandler3 = buMouseMoveEventHandler2;
				buMouseMoveEventHandler value2 = (buMouseMoveEventHandler)Delegate.Remove(buMouseMoveEventHandler3, value);
				buMouseMoveEventHandler2 = Interlocked.CompareExchange(ref buMouseMoveEventHandler_0, value2, buMouseMoveEventHandler3);
			}
			while ((object)buMouseMoveEventHandler2 != buMouseMoveEventHandler3);
		}
	}

	public event buMouseMoveEventHandler MouseDownPosition
	{
		[CompilerGenerated]
		add
		{
			buMouseMoveEventHandler buMouseMoveEventHandler2 = buMouseMoveEventHandler_1;
			buMouseMoveEventHandler buMouseMoveEventHandler3;
			do
			{
				buMouseMoveEventHandler3 = buMouseMoveEventHandler2;
				buMouseMoveEventHandler value2 = (buMouseMoveEventHandler)Delegate.Combine(buMouseMoveEventHandler3, value);
				buMouseMoveEventHandler2 = Interlocked.CompareExchange(ref buMouseMoveEventHandler_1, value2, buMouseMoveEventHandler3);
			}
			while ((object)buMouseMoveEventHandler2 != buMouseMoveEventHandler3);
		}
		[CompilerGenerated]
		remove
		{
			buMouseMoveEventHandler buMouseMoveEventHandler2 = buMouseMoveEventHandler_1;
			buMouseMoveEventHandler buMouseMoveEventHandler3;
			do
			{
				buMouseMoveEventHandler3 = buMouseMoveEventHandler2;
				buMouseMoveEventHandler value2 = (buMouseMoveEventHandler)Delegate.Remove(buMouseMoveEventHandler3, value);
				buMouseMoveEventHandler2 = Interlocked.CompareExchange(ref buMouseMoveEventHandler_1, value2, buMouseMoveEventHandler3);
			}
			while ((object)buMouseMoveEventHandler2 != buMouseMoveEventHandler3);
		}
	}

	public event buMouseMoveEventHandler MouseUpPosition
	{
		[CompilerGenerated]
		add
		{
			buMouseMoveEventHandler buMouseMoveEventHandler2 = buMouseMoveEventHandler_2;
			buMouseMoveEventHandler buMouseMoveEventHandler3;
			do
			{
				buMouseMoveEventHandler3 = buMouseMoveEventHandler2;
				buMouseMoveEventHandler value2 = (buMouseMoveEventHandler)Delegate.Combine(buMouseMoveEventHandler3, value);
				buMouseMoveEventHandler2 = Interlocked.CompareExchange(ref buMouseMoveEventHandler_2, value2, buMouseMoveEventHandler3);
			}
			while ((object)buMouseMoveEventHandler2 != buMouseMoveEventHandler3);
		}
		[CompilerGenerated]
		remove
		{
			buMouseMoveEventHandler buMouseMoveEventHandler2 = buMouseMoveEventHandler_2;
			buMouseMoveEventHandler buMouseMoveEventHandler3;
			do
			{
				buMouseMoveEventHandler3 = buMouseMoveEventHandler2;
				buMouseMoveEventHandler value2 = (buMouseMoveEventHandler)Delegate.Remove(buMouseMoveEventHandler3, value);
				buMouseMoveEventHandler2 = Interlocked.CompareExchange(ref buMouseMoveEventHandler_2, value2, buMouseMoveEventHandler3);
			}
			while ((object)buMouseMoveEventHandler2 != buMouseMoveEventHandler3);
		}
	}

	public buViewer()
	{
		Class76.smethod_811(this);
		pictureBox_0.MouseWheel += pictureBox_0_MouseWheel;
	}

	internal void method_0(object sender, EventArgs e)
	{
		try
		{
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, e);
			}
		}
		catch (Exception)
		{
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		if (eventHandler_1 != null)
		{
			eventHandler_1(this, e);
		}
	}

	private void pictureBox_0_MouseWheel(object sender, MouseEventArgs e)
	{
		if (!DisableMouseWheel)
		{
			if (e.Delta <= 0)
			{
				ZoomOut();
			}
			else
			{
				ZoomIn();
			}
		}
	}

	internal void method_2(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			bool_1 = true;
			pnt3D_0 = new Pnt3D(PTUx(e.X), PTUy(e.Y));
		}
		if (buMouseMoveEventHandler_1 != null)
		{
			buMouseMoveEventHandler_1(this, e, pnt3D_0);
		}
		pictureBox_0.Focus();
	}

	internal void method_3(object sender, MouseEventArgs e)
	{
		Pnt3D pnt3D = new Pnt3D(PTUx(e.X), PTUy(e.Y));
		ScreenCoordinate = new Pnt3D(PTUx(e.X), PTUy(e.Y));
		ScreenCoordinate.X -= viewRotateCenter.X;
		ScreenCoordinate.Y -= viewRotateCenter.Y;
		if (bool_1)
		{
			Pan(pnt3D_0.X - pnt3D.X, pnt3D_0.Y - pnt3D.Y);
		}
		if (buMouseMoveEventHandler_0 != null)
		{
			buMouseMoveEventHandler_0(this, e, pnt3D_0);
		}
		if (ShowMouseCoordinateOnScreen)
		{
			Redraw();
		}
	}

	internal void method_4(object sender, MouseEventArgs e)
	{
		if (buMouseMoveEventHandler_2 != null)
		{
			buMouseMoveEventHandler_2(this, e, pnt3D_0);
		}
		bool_1 = false;
	}

	internal void method_5(object sender, EventArgs e)
	{
		if (!pictureBox_0.Focused)
		{
		}
	}

	public void Init()
	{
		if (!buControlCommands.smethod_0("buViewerBrooOpen"))
		{
			throw new RegisterException("buViewer");
		}
		Bmp = new Bitmap(pictureBox_0.Width, pictureBox_0.Height);
		bool_0 = true;
	}

	public void Redraw()
	{
		try
		{
			ScreenHeight = ViewTop - ViewBottom;
			ScreenWidth = ViewRight - ViewLeft;
			ScreenLeft = ViewLeft;
			ScreenTop = ViewTop;
			DrawEntities();
			ImageDraw = pictureBox_0.Image;
		}
		catch (Exception)
		{
		}
	}

	public void ZoomFit()
	{
		try
		{
			if ((Entities.Count == 0) & (MaterialEntities.Count == 0) & (DimensionEntities.Count == 0) & (ArrowEntities.Count == 0))
			{
				return;
			}
			double num = 1.0;
			AspectRatio = Convert.ToDouble(pictureBox_0.Width) / Convert.ToDouble(pictureBox_0.Height);
			if (!(BoxSizeOfEntities.Delta.Y > BoxSizeOfEntities.Delta.X))
			{
				num = BoxSizeOfEntities.Delta.X / BoxSizeOfEntities.Delta.Y / AspectRatio;
				if (!(num >= 1.0))
				{
					double num2 = 0.0;
					ViewBottom = BoxSizeOfEntities.MinPoint.Y - BoxSizeOfEntities.Delta.Y * 0.01;
					ViewTop = BoxSizeOfEntities.MinPoint.Y + BoxSizeOfEntities.Delta.Y + BoxSizeOfEntities.Delta.Y * 0.01;
					num2 = (ViewTop - ViewBottom) * AspectRatio;
					ViewLeft = BoxSizeOfEntities.MinPoint.X - (num2 - (BoxSizeOfEntities.Delta.X - 0.0)) / 2.0;
					ViewRight = ViewLeft + num2;
				}
				else
				{
					ViewRight = BoxSizeOfEntities.MinPoint.X + BoxSizeOfEntities.Delta.X + 5.0;
					ViewLeft = BoxSizeOfEntities.MinPoint.X - 5.0;
					ViewTop = (ViewRight - ViewLeft) / AspectRatio;
					ViewBottom = 0.0;
					double num3 = (BoxSizeOfEntities.MinPoint.Y + BoxSizeOfEntities.MaxPoint.Y) / 2.0;
					double num4 = (ViewTop - ViewBottom) / 2.0;
					ViewTop += num3 - num4;
					ViewBottom += num3 - num4;
				}
			}
			else
			{
				num = (BoxSizeOfEntities.MaxPoint.X - BoxSizeOfEntities.MinPoint.X) * 1.0 / (BoxSizeOfEntities.MaxPoint.Y - BoxSizeOfEntities.MinPoint.Y);
				if (!(num >= 1.0))
				{
					double num5 = 0.0;
					ViewBottom = BoxSizeOfEntities.MinPoint.Y - BoxSizeOfEntities.Delta.Y * 0.01;
					ViewTop = BoxSizeOfEntities.MaxPoint.Y + BoxSizeOfEntities.Delta.Y * 0.01;
					num5 = (ViewTop - ViewBottom) * AspectRatio;
					ViewLeft = BoxSizeOfEntities.MinPoint.X - (num5 - (BoxSizeOfEntities.MaxPoint.X - BoxSizeOfEntities.MinPoint.X)) / 2.0;
					ViewRight = ViewLeft + num5;
				}
				else
				{
					double num6 = 0.0;
					double num7 = 0.0;
					ViewRight = BoxSizeOfEntities.MaxPoint.X + BoxSizeOfEntities.Delta.X * 0.01;
					ViewLeft = BoxSizeOfEntities.MinPoint.X - BoxSizeOfEntities.Delta.X * 0.01;
					num6 = (ViewRight - ViewLeft) / AspectRatio;
					num7 = (num6 - (BoxSizeOfEntities.MaxPoint.Y - BoxSizeOfEntities.MinPoint.Y)) / 2.0;
					ViewTop = BoxSizeOfEntities.MaxPoint.Y + num7;
					ViewBottom = BoxSizeOfEntities.MinPoint.Y - num7;
				}
			}
			Redraw();
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void ZoomOut()
	{
		try
		{
			double num = (ViewRight - ViewLeft) * 0.10000000149011612;
			double num2 = 0.0;
			double num3 = 0.0;
			ViewRight += num;
			ViewLeft -= num;
			num2 = (ViewRight - ViewLeft) / AspectRatio;
			num2 /= 2.0;
			num3 = ViewBottom + (ViewTop - ViewBottom) / 2.0;
			ViewTop = num3 + num2;
			ViewBottom = num3 - num2;
			Redraw();
		}
		catch (Exception)
		{
		}
	}

	public void ZoomIn()
	{
		try
		{
			double num = (ViewRight - ViewLeft) * 0.10000000149011612;
			double num2 = 0.0;
			double num3 = 0.0;
			ViewRight -= num;
			ViewLeft += num;
			num2 = (ViewRight - ViewLeft) / AspectRatio;
			num2 /= 2.0;
			num3 = ViewBottom + (ViewTop - ViewBottom) / 2.0;
			ViewTop = num3 + num2;
			ViewBottom = num3 - num2;
			Redraw();
		}
		catch (Exception)
		{
		}
	}

	public void Pan(double X, double Y)
	{
		ViewRight += X;
		ViewLeft += X;
		ViewTop += Y;
		ViewBottom += Y;
		Redraw();
	}

	public void setView(ViewportViewType type)
	{
		if (type == ViewportViewType.Top)
		{
			viewAngle.X = 180.0;
			viewAngle.Y = 180.0;
			viewAngle.Z = 0.0;
		}
		if (type == ViewportViewType.Bottom)
		{
			viewAngle.X = 180.0;
			viewAngle.Y = 0.0;
			viewAngle.Z = 0.0;
		}
		if (type == ViewportViewType.Front)
		{
			viewAngle.X = 90.0;
			viewAngle.Y = 0.0;
			viewAngle.Z = 0.0;
		}
		if (type == ViewportViewType.Back)
		{
			viewAngle.X = -90.0;
			viewAngle.Y = 0.0;
			viewAngle.Z = 0.0;
		}
		if (type == ViewportViewType.Left)
		{
			viewAngle.X = 90.0;
			viewAngle.Y = 90.0;
			viewAngle.Z = 0.0;
		}
		if (type == ViewportViewType.Right)
		{
			viewAngle.X = 90.0;
			viewAngle.Y = -90.0;
			viewAngle.Z = 0.0;
		}
		if (type == ViewportViewType.Isometric)
		{
			viewAngle.X = 225.0;
			viewAngle.Y = 225.0;
			viewAngle.Z = 20.0;
		}
		DrawEntities();
	}

	public void DrawEntities()
	{
		try
		{
			if (!bool_0)
			{
				Init();
			}
			contextMenuStrip_0.Enabled = ShowContentMenu;
			ClientHeight = pictureBox_0.Height;
			ClientWidth = pictureBox_0.Width;
			List<eEntities> CopiedEnt = new List<eEntities>();
			List<eEntities> TargetList = new List<eEntities>();
			List<eEntities> TargetList2 = new List<eEntities>();
			double num = 1.0;
			if (!MirrorDraw)
			{
				eEntities.CopyEntities(Entities, ref CopiedEnt);
				buGeneral.CopyLists(DimensionEntities, ref TargetList);
				buGeneral.CopyLists(ArrowEntities, ref TargetList2);
			}
			else
			{
				eEntities.CopyEntities(Entities, ref CopiedEnt);
				buControlCoreClass.cVector.Mirror(new Pnt3D(), new Pnt3D(1.0, 0.0, 0.0), new WorkPlane(), 0.0, ref CopiedEnt);
				buGeneral.CopyLists(DimensionEntities, ref TargetList);
				buControlCoreClass.cVector.Mirror(new Pnt3D(), new Pnt3D(1.0, 0.0, 0.0), new WorkPlane(), 0.0, ref TargetList);
				buGeneral.CopyLists(ArrowEntities, ref TargetList2);
				buControlCoreClass.cVector.Mirror(new Pnt3D(), new Pnt3D(1.0, 0.0, 0.0), new WorkPlane(), 0.0, ref TargetList2);
				num = -1.0;
			}
			if (!((pictureBox_0.Width == 0) | (pictureBox_0.Height == 0)))
			{
				if (BackImage != null)
				{
					Bmp = new Bitmap(BackImage);
					pictureBox_0.SizeMode = PictureBoxSizeMode.StretchImage;
				}
				Graphics graphics = Graphics.FromImage(Bmp);
				if (BackImage == null)
				{
					graphics.Clear(BackColor);
				}
				Color color = default(Color);
				float num2 = 1f;
				Pnt3D MinPoint = new Pnt3D();
				Pnt3D MaxPoint = new Pnt3D();
				Pnt3D MinPoint2 = new Pnt3D();
				Pnt3D MaxPoint2 = new Pnt3D();
				List<Pnt3D> list = new List<Pnt3D>();
				if (CopiedEnt.Count > 0)
				{
					buControlCoreClass.cVector.BoxSizeCalculate(CopiedEnt, ref MinPoint, ref MaxPoint);
					list.Add(MinPoint);
					list.Add(MaxPoint);
				}
				if (TargetList.Count > 0)
				{
					buControlCoreClass.cVector.BoxSizeCalculate(TargetList, ref MinPoint, ref MaxPoint);
					list.Add(MinPoint);
					list.Add(MaxPoint);
				}
				if (TargetList2.Count > 0)
				{
					buControlCoreClass.cVector.BoxSizeCalculate(TargetList2, ref MinPoint, ref MaxPoint);
					list.Add(MinPoint);
					list.Add(MaxPoint);
				}
				if (MaterialEntities.Count > 0)
				{
					buControlCoreClass.cVector.BoxSizeCalculate(MaterialEntities, ref MinPoint, ref MaxPoint);
					list.Add(MinPoint);
					list.Add(MaxPoint);
				}
				buControlCoreClass.cVector.BoxSizeCalculate(list, ref MinPoint2, ref MaxPoint2);
				BoxSizeOfEntities = new BoxSize(MinPoint2, MaxPoint2);
				BoxSizeOfEntities.Delta = new Vec3D(MaxPoint2.X - MinPoint2.X, MaxPoint2.Y - MinPoint2.Y, MaxPoint2.Z - MinPoint2.Z);
				viewRotateCenter = new Pnt3D();
				if (!Only2D)
				{
					viewRotateCenter = new Pnt3D(buControlCoreClass.cVector.MiddlePointOfLine(BoxSizeOfEntities.MaxPoint, BoxSizeOfEntities.MinPoint));
				}
				pnt3D_1 = new Pnt3D(buControlCoreClass.cVector.MiddlePointOfLine(BoxSizeOfEntities.MaxPoint, BoxSizeOfEntities.MinPoint));
				viewCamera.Location = new Pnt3D(pnt3D_1);
				for (int i = 0; i <= MaterialEntities.Count - 1; i++)
				{
					if (MaterialEntities[i].bVisible)
					{
						color = MaterialEntities[i].dispColor;
						if ((color.A == 0) & (color.B == 0) & (color.G == 0) & (color.R == 0))
						{
							color = Color.Black;
						}
						num2 = MaterialEntities[i].dispThickness;
						if (MaterialEntities[i].bSelected)
						{
							color = SelectedEntityColor;
							num2 = (float)SelectedEntityThickness;
						}
						for (int j = 1; j <= MaterialEntities[i].Vertice.Count - 1; j++)
						{
							Pnt3D pnt3D = new Pnt3D(MaterialEntities[i].Vertice[j - 1]);
							Pnt3D pnt3D2 = new Pnt3D(MaterialEntities[i].Vertice[j]);
							pnt3D.Z *= -1.0;
							pnt3D2.Z *= -1.0;
							PointF pointF = default(PointF);
							PointF pointF2 = default(PointF);
							pointF = ViewportUpdate(pnt3D);
							pointF2 = ViewportUpdate(pnt3D2);
							graphics.DrawLine(new Pen(color, num2), UTPx(pointF.X), UTPy(pointF.Y), UTPx(pointF2.X), UTPy(pointF2.Y));
						}
						if (MaterialEntities[i].Vertice.Count == 1)
						{
							graphics.DrawArc(new Pen(color, num2), UTPx(MaterialEntities[i].Vertice[0].X), UTPy(MaterialEntities[i].Vertice[0].Y), 2, 2, 0, 360);
						}
					}
				}
				for (int k = 0; k <= CopiedEnt.Count - 1; k++)
				{
					if (CopiedEnt[k] != null && CopiedEnt[k].bVisible)
					{
						color = CopiedEnt[k].dispColor;
						if ((color.A == 0) & (color.B == 0) & (color.G == 0) & (color.R == 0))
						{
							color = Color.Black;
						}
						num2 = CopiedEnt[k].dispThickness;
						if (CopiedEnt[k].bSelected)
						{
							color = SelectedEntityColor;
							num2 = (float)SelectedEntityThickness;
						}
						if ((ExecutedLineIndex >= 1) & (k <= ExecutedLineIndex))
						{
							color = ExecutedEntityColor;
						}
						for (int l = 1; l <= CopiedEnt[k].Vertice.Count - 1; l++)
						{
							Pnt3D pnt3D3 = new Pnt3D(CopiedEnt[k].Vertice[l - 1]);
							Pnt3D pnt3D4 = new Pnt3D(CopiedEnt[k].Vertice[l]);
							pnt3D3.Z *= -1.0;
							pnt3D4.Z *= -1.0;
							PointF pointF3 = default(PointF);
							PointF pointF4 = default(PointF);
							pointF3 = ViewportUpdate(pnt3D3);
							pointF4 = ViewportUpdate(pnt3D4);
							graphics.DrawLine(new Pen(color, num2), UTPx(pointF3.X), UTPy(pointF3.Y), UTPx(pointF4.X), UTPy(pointF4.Y));
						}
						if (CopiedEnt[k].Vertice.Count == 1)
						{
							graphics.DrawArc(new Pen(color, num2), UTPx(CopiedEnt[k].Vertice[0].X), UTPy(CopiedEnt[k].Vertice[0].Y), 2, 2, 0, 360);
						}
					}
				}
				if (RunTimeDrawingPoints.Count > 1)
				{
					for (int m = 1; m <= RunTimeDrawingPoints.Count - 1; m++)
					{
						color = RuntimeDrawingColor;
						if ((color.A == 0) & (color.B == 0) & (color.G == 0) & (color.R == 0))
						{
							color = Color.Black;
						}
						num2 = 1f;
						Pnt3D pnt3D5 = new Pnt3D(RunTimeDrawingPoints[m - 1]);
						Pnt3D pnt3D6 = new Pnt3D(RunTimeDrawingPoints[m]);
						pnt3D5.Z *= -1.0;
						pnt3D6.Z *= -1.0;
						PointF pointF5 = default(PointF);
						PointF pointF6 = default(PointF);
						pointF5 = ViewportUpdate(pnt3D5);
						pointF6 = ViewportUpdate(pnt3D6);
						graphics.DrawLine(new Pen(color, num2), UTPx(pointF5.X), UTPy(pointF5.Y), UTPx(pointF6.X), UTPy(pointF6.Y));
					}
				}
				if (ShowMouseCoordinateOnScreen)
				{
					graphics.DrawString("X: " + ScreenCoordinate.X.ToString("f2") + " , Y: " + ScreenCoordinate.Y.ToString("f2"), new Font("Arial", 8f), new SolidBrush(Color.Black), new PointF(10f, 10f));
				}
				for (int n = 0; n <= CamEntities.Count - 1; n++)
				{
					if (CamEntities[n].bVisible)
					{
						color = CamEntities[n].dispColor;
						color = CamEntitiesColor;
						if ((color.A == 0) & (color.B == 0) & (color.G == 0) & (color.R == 0))
						{
							color = Color.Black;
						}
						num2 = CamEntities[n].dispThickness + 2f;
						if (CamEntities[n].bSelected)
						{
							color = SelectedEntityColor;
							num2 = (float)SelectedEntityThickness;
						}
						for (int num3 = 1; num3 <= CamEntities[n].Vertice.Count - 1; num3++)
						{
							Pnt3D refPoint = new Pnt3D(CamEntities[n].Vertice[num3 - 1]);
							Pnt3D refPoint2 = new Pnt3D(CamEntities[n].Vertice[num3]);
							PointF pointF7 = default(PointF);
							PointF pointF8 = default(PointF);
							pointF7 = ViewportUpdate(refPoint);
							pointF8 = ViewportUpdate(refPoint2);
							graphics.DrawLine(new Pen(color, num2), UTPx(pointF7.X), UTPy(pointF7.Y), UTPx(pointF8.X), UTPy(pointF8.Y));
						}
						if (CamEntities[n].Vertice.Count != 1)
						{
						}
					}
				}
				if ((viewAngle.X == 0.0) & (viewAngle.Y == 0.0) & (viewAngle.Z == 0.0))
				{
					for (int num4 = 0; num4 <= TargetList.Count - 1; num4++)
					{
						color = TargetList[num4].dispColor;
						if ((color.A == 0) & (color.B == 0) & (color.G == 0) & (color.R == 0))
						{
							color = Color.Black;
						}
						num2 = TargetList[num4].dispThickness;
						for (int num5 = 1; num5 <= TargetList[num4].Vertice.Count - 1; num5++)
						{
							Pnt3D refPoint3 = new Pnt3D(TargetList[num4].Vertice[num5 - 1]);
							Pnt3D refPoint4 = new Pnt3D(TargetList[num4].Vertice[num5]);
							PointF pointF9 = default(PointF);
							PointF pointF10 = default(PointF);
							pointF9 = ViewportUpdate(refPoint3);
							pointF10 = ViewportUpdate(refPoint4);
							graphics.DrawLine(new Pen(color, num2), UTPx(pointF9.X), UTPy(pointF9.Y), UTPx(pointF10.X), UTPy(pointF10.Y));
						}
						MinPoint2 = buControlCoreClass.cVector.MiddlePointOfLine(TargetList[num4].Vertice[0], TargetList[num4].Vertice[1]);
						graphics.DrawString(TargetList[num4].auxText, new Font("Arial", 12f), new SolidBrush(color), new PointF(UTPx(MinPoint2.X), UTPy(MinPoint2.Y)));
						List<Pnt3D> TriangleVertice = new List<Pnt3D>();
						double num6 = BoxSizeOfEntities.Delta.X * 0.05000000074505806;
						if (num6 < 5.0)
						{
							num6 = 5.0;
						}
						double num7 = buControlCoreClass.cVector.Length3D(TargetList[num4].Vertice[0], TargetList[num4].Vertice[1]);
						bool reverse = false;
						if (num7 < 100.0)
						{
							reverse = true;
						}
						buControlCoreClass.cVector.TriangleAtPointByLineRef(TargetList[num4].Vertice[0], TargetList[num4].Vertice[1], 10.0, num6, new WorkPlane(), reverse, FromBaseLine: false, ref TriangleVertice);
						Point[] array = new Point[TriangleVertice.Count];
						for (int num8 = 0; num8 <= TriangleVertice.Count - 1; num8++)
						{
							Pnt3D refPoint5 = new Pnt3D(TriangleVertice[num8]);
							PointF pointF11 = default(PointF);
							pointF11 = ViewportUpdate(refPoint5);
							array[num8] = new Point(UTPx(pointF11.X), UTPy(pointF11.Y));
						}
						graphics.FillPolygon(new SolidBrush(color), array);
						List<Pnt3D> TriangleVertice2 = new List<Pnt3D>();
						num7 = buControlCoreClass.cVector.Length3D(TargetList[num4].Vertice[0], TargetList[num4].Vertice[1]);
						reverse = false;
						if (num7 < 100.0)
						{
							reverse = true;
						}
						buControlCoreClass.cVector.TriangleAtPointByLineRef(TargetList[num4].Vertice[1], TargetList[num4].Vertice[0], 10.0, num6, new WorkPlane(), reverse, FromBaseLine: false, ref TriangleVertice2);
						Point[] array2 = new Point[TriangleVertice2.Count];
						for (int num9 = 0; num9 <= TriangleVertice2.Count - 1; num9++)
						{
							Pnt3D refPoint6 = new Pnt3D(TriangleVertice2[num9]);
							PointF pointF12 = default(PointF);
							pointF12 = ViewportUpdate(refPoint6);
							array2[num9] = new Point(UTPx(pointF12.X), UTPy(pointF12.Y));
						}
						graphics.FillPolygon(new SolidBrush(color), array2);
					}
					for (int num10 = 0; num10 <= Texts.Count - 1; num10++)
					{
						color = Texts[num10].dispColor;
						if ((color.A == 0) & (color.B == 0) & (color.G == 0) & (color.R == 0))
						{
							color = Color.Black;
						}
						_ = (float)pictureBox_0.Width / 2f;
						_ = (float)pictureBox_0.Height / 2f;
						graphics.ResetTransform();
						SizeF sizeF = default(SizeF);
						sizeF = graphics.MeasureString(Texts[num10].TextString, Texts[num10].TextFont);
						float num11 = sizeF.Width / 2f;
						float num12 = sizeF.Height / 2f;
						if ((TextsAlignment == ContentAlignment.BottomLeft) | (TextsAlignment == ContentAlignment.MiddleLeft) | (TextsAlignment == ContentAlignment.TopLeft))
						{
							num11 = 0f;
						}
						if (Texts[num10].Angle != 0.0)
						{
							num11 = sizeF.Height / 2f;
							num12 = sizeF.Width / -2f;
						}
						graphics.TranslateTransform((float)UTPx(Texts[num10].StartPoint.X * num) - num11, (float)UTPy(Texts[num10].StartPoint.Y) - num12);
						graphics.RotateTransform((float)Texts[num10].Angle * (float)num);
						graphics.DrawString(Texts[num10].TextString, Texts[num10].TextFont, new SolidBrush(color), new PointF(0f, 0f));
					}
					if (Text.Length > 0)
					{
						graphics.DrawString(Text, Font, new SolidBrush(ForeColor), new PointF(1f, 1f));
					}
				}
				if ((viewAngle.X == 0.0) & (viewAngle.Y == 0.0) & (viewAngle.Z == 0.0))
				{
					for (int num13 = 0; num13 <= TargetList2.Count - 1; num13++)
					{
						color = TargetList2[num13].dispColor;
						if ((color.A == 0) & (color.B == 0) & (color.G == 0) & (color.R == 0))
						{
							color = Color.Black;
						}
						num2 = TargetList2[num13].dispThickness;
						for (int num14 = 1; num14 <= TargetList2[num13].Vertice.Count - 1; num14++)
						{
							Pnt3D refPoint7 = new Pnt3D(TargetList2[num13].Vertice[num14 - 1]);
							Pnt3D refPoint8 = new Pnt3D(TargetList2[num13].Vertice[num14]);
							PointF pointF13 = default(PointF);
							PointF pointF14 = default(PointF);
							pointF13 = ViewportUpdate(refPoint7);
							pointF14 = ViewportUpdate(refPoint8);
							graphics.DrawLine(new Pen(color, num2), UTPx(pointF13.X), UTPy(pointF13.Y), UTPx(pointF14.X), UTPy(pointF14.Y));
						}
						MinPoint2 = buControlCoreClass.cVector.MiddlePointOfLine(TargetList2[num13].Vertice[0], TargetList2[num13].Vertice[1]);
						if (TargetList2[num13].auxText == null || TargetList2[num13].auxText.Length > 0)
						{
						}
						new List<Pnt3D>();
						double num15 = ViewRight - ViewLeft;
						double num16 = BoxSizeOfEntities.Delta.X * 0.15 * (num15 / 1000.0);
						if (num16 < 5.0)
						{
							num16 = 5.0;
						}
						List<Pnt3D> TriangleVertice3 = new List<Pnt3D>();
						buControlCoreClass.cVector.TriangleAtPointByLineRef(TargetList2[num13].Vertice[1], TargetList2[num13].Vertice[0], 10.0, num16, new WorkPlane(), Reverse: false, FromBaseLine: false, ref TriangleVertice3);
						Point[] array3 = new Point[TriangleVertice3.Count];
						for (int num17 = 0; num17 <= TriangleVertice3.Count - 1; num17++)
						{
							Pnt3D refPoint9 = new Pnt3D(TriangleVertice3[num17]);
							PointF pointF15 = default(PointF);
							pointF15 = ViewportUpdate(refPoint9);
							array3[num17] = new Point(UTPx(pointF15.X), UTPy(pointF15.Y));
						}
						graphics.FillPolygon(new SolidBrush(color), array3);
					}
				}
				if (SimTool.Visible & (SimTool.Diameter > 0.0))
				{
					List<Pnt3D> Vertices = new List<Pnt3D>();
					List<Pnt3D> Vertices2 = new List<Pnt3D>();
					if (SimTool.Type == SimulationToolType.Milling)
					{
						buControlCoreClass.cVector.PolygonCenter(SimTool.Coordinate, SimTool.Diameter / 2.0, 16, new WorkPlane(), ref Vertices);
						buControlCoreClass.cVector.PolygonCenter(new Pnt3D(SimTool.Coordinate.X, SimTool.Coordinate.Y, SimTool.Coordinate.Z + SimTool.Length), SimTool.Diameter / 2.0, 16, new WorkPlane(), ref Vertices2);
						Point[] array4 = new Point[Vertices.Count];
						Point[] array5 = new Point[Vertices2.Count];
						for (int num18 = 0; num18 <= Vertices.Count - 1; num18++)
						{
							Pnt3D pnt3D7 = new Pnt3D(Vertices[num18]);
							pnt3D7.Z *= -1.0;
							PointF pointF16 = default(PointF);
							pointF16 = ViewportUpdate(pnt3D7);
							array4[num18] = new Point(UTPx(pointF16.X), UTPy(pointF16.Y));
						}
						graphics.FillPolygon(new SolidBrush(SimTool.Color), array4);
						for (int num19 = 0; num19 <= Vertices2.Count - 1; num19++)
						{
							Pnt3D pnt3D8 = new Pnt3D(Vertices2[num19]);
							pnt3D8.Z *= -1.0;
							PointF pointF17 = default(PointF);
							pointF17 = ViewportUpdate(pnt3D8);
							array5[num19] = new Point(UTPx(pointF17.X), UTPy(pointF17.Y));
						}
						graphics.FillPolygon(new SolidBrush(SimTool.Color), array5);
						for (int num20 = 1; num20 <= Vertices2.Count - 1; num20++)
						{
							Point[] array6 = new Point[4];
							Pnt3D pnt3D9 = new Pnt3D(Vertices2[num20 - 1]);
							pnt3D9.Z *= -1.0;
							PointF pointF18 = default(PointF);
							pointF18 = ViewportUpdate(pnt3D9);
							array6[0] = new Point(UTPx(pointF18.X), UTPy(pointF18.Y));
							pnt3D9 = new Pnt3D(Vertices2[num20]);
							pnt3D9.Z *= -1.0;
							pointF18 = default(PointF);
							pointF18 = ViewportUpdate(pnt3D9);
							array6[1] = new Point(UTPx(pointF18.X), UTPy(pointF18.Y));
							pnt3D9 = new Pnt3D(Vertices[num20]);
							pnt3D9.Z *= -1.0;
							pointF18 = default(PointF);
							pointF18 = ViewportUpdate(pnt3D9);
							array6[2] = new Point(UTPx(pointF18.X), UTPy(pointF18.Y));
							pnt3D9 = new Pnt3D(Vertices[num20 - 1]);
							pnt3D9.Z *= -1.0;
							pointF18 = default(PointF);
							pointF18 = ViewportUpdate(pnt3D9);
							array6[3] = new Point(UTPx(pointF18.X), UTPy(pointF18.Y));
							graphics.FillPolygon(new SolidBrush(SimTool.Color), array6);
						}
						graphics.DrawPolygon(new Pen(SimTool.BorderColor), array5);
						graphics.DrawPolygon(new Pen(SimTool.BorderColor), array4);
					}
					if (SimTool.Type == SimulationToolType.Saw)
					{
						if (SimTool.Orientation == LeftMiddleRightLocationType.Middle)
						{
							buControlCoreClass.cVector.PolygonCenter(new Pnt3D(SimTool.Coordinate.X, SimTool.Coordinate.Y - SimTool.Thickness / 2.0, SimTool.Coordinate.Z + SimTool.Diameter / 2.0), SimTool.Diameter / 2.0, 16, new WorkPlane(planeType.XZ, 1), ref Vertices);
							buControlCoreClass.cVector.PolygonCenter(new Pnt3D(SimTool.Coordinate.X, SimTool.Coordinate.Y + SimTool.Thickness / 2.0, SimTool.Coordinate.Z + SimTool.Diameter / 2.0), SimTool.Diameter / 2.0, 16, new WorkPlane(planeType.XZ, 1), ref Vertices2);
							buControlCoreClass.cVector.Rotate(SimTool.Coordinate, SimTool.TangentAngle, new WorkPlane(), ref Vertices);
							buControlCoreClass.cVector.Rotate(SimTool.Coordinate, SimTool.TangentAngle, new WorkPlane(), ref Vertices2);
						}
						if (SimTool.Orientation == LeftMiddleRightLocationType.Left)
						{
							buControlCoreClass.cVector.PolygonCenter(new Pnt3D(SimTool.Coordinate.X, SimTool.Coordinate.Y, SimTool.Coordinate.Z + SimTool.Diameter / 2.0), SimTool.Diameter / 2.0, 16, new WorkPlane(planeType.XZ, 1), ref Vertices);
							buControlCoreClass.cVector.PolygonCenter(new Pnt3D(SimTool.Coordinate.X, SimTool.Coordinate.Y + SimTool.Thickness, SimTool.Coordinate.Z + SimTool.Diameter / 2.0), SimTool.Diameter / 2.0, 16, new WorkPlane(planeType.XZ, 1), ref Vertices2);
							buControlCoreClass.cVector.Rotate(new Pnt3D(SimTool.Coordinate.X, SimTool.Coordinate.Y + SimTool.Thickness / 2.0, SimTool.Coordinate.Z), SimTool.TangentAngle, new WorkPlane(), ref Vertices);
							buControlCoreClass.cVector.Rotate(new Pnt3D(SimTool.Coordinate.X, SimTool.Coordinate.Y + SimTool.Thickness / 2.0, SimTool.Coordinate.Z), SimTool.TangentAngle, new WorkPlane(), ref Vertices2);
						}
						if (SimTool.Orientation == LeftMiddleRightLocationType.Right)
						{
							buControlCoreClass.cVector.PolygonCenter(new Pnt3D(SimTool.Coordinate.X, SimTool.Coordinate.Y - SimTool.Thickness, SimTool.Coordinate.Z + SimTool.Diameter / 2.0), SimTool.Diameter / 2.0, 16, new WorkPlane(planeType.XZ, 1), ref Vertices);
							buControlCoreClass.cVector.PolygonCenter(new Pnt3D(SimTool.Coordinate.X, SimTool.Coordinate.Y, SimTool.Coordinate.Z + SimTool.Diameter / 2.0), SimTool.Diameter / 2.0, 16, new WorkPlane(planeType.XZ, 1), ref Vertices2);
							buControlCoreClass.cVector.Rotate(new Pnt3D(SimTool.Coordinate.X, SimTool.Coordinate.Y - SimTool.Thickness / 2.0, SimTool.Coordinate.Z), SimTool.TangentAngle, new WorkPlane(), ref Vertices);
							buControlCoreClass.cVector.Rotate(new Pnt3D(SimTool.Coordinate.X, SimTool.Coordinate.Y - SimTool.Thickness / 2.0, SimTool.Coordinate.Z), SimTool.TangentAngle, new WorkPlane(), ref Vertices2);
						}
						Point[] array7 = new Point[Vertices.Count];
						Point[] array8 = new Point[Vertices2.Count];
						for (int num21 = 0; num21 <= Vertices.Count - 1; num21++)
						{
							Pnt3D pnt3D10 = new Pnt3D(Vertices[num21]);
							pnt3D10.Z *= -1.0;
							PointF pointF19 = default(PointF);
							pointF19 = ViewportUpdate(pnt3D10);
							array7[num21] = new Point(UTPx(pointF19.X), UTPy(pointF19.Y));
						}
						graphics.FillPolygon(new SolidBrush(SimTool.Color), array7);
						for (int num22 = 0; num22 <= Vertices2.Count - 1; num22++)
						{
							Pnt3D pnt3D11 = new Pnt3D(Vertices2[num22]);
							pnt3D11.Z *= -1.0;
							PointF pointF20 = default(PointF);
							pointF20 = ViewportUpdate(pnt3D11);
							array8[num22] = new Point(UTPx(pointF20.X), UTPy(pointF20.Y));
						}
						graphics.FillPolygon(new SolidBrush(SimTool.Color), array8);
						for (int num23 = 1; num23 <= Vertices2.Count - 1; num23++)
						{
							Point[] array9 = new Point[4];
							Pnt3D pnt3D12 = new Pnt3D(Vertices2[num23 - 1]);
							pnt3D12.Z *= -1.0;
							PointF pointF21 = default(PointF);
							pointF21 = ViewportUpdate(pnt3D12);
							array9[0] = new Point(UTPx(pointF21.X), UTPy(pointF21.Y));
							pnt3D12 = new Pnt3D(Vertices2[num23]);
							pnt3D12.Z *= -1.0;
							pointF21 = default(PointF);
							pointF21 = ViewportUpdate(pnt3D12);
							array9[1] = new Point(UTPx(pointF21.X), UTPy(pointF21.Y));
							pnt3D12 = new Pnt3D(Vertices[num23]);
							pnt3D12.Z *= -1.0;
							pointF21 = default(PointF);
							pointF21 = ViewportUpdate(pnt3D12);
							array9[2] = new Point(UTPx(pointF21.X), UTPy(pointF21.Y));
							pnt3D12 = new Pnt3D(Vertices[num23 - 1]);
							pnt3D12.Z *= -1.0;
							pointF21 = default(PointF);
							pointF21 = ViewportUpdate(pnt3D12);
							array9[3] = new Point(UTPx(pointF21.X), UTPy(pointF21.Y));
							graphics.FillPolygon(new SolidBrush(SimTool.Color), array9);
						}
						graphics.DrawPolygon(new Pen(SimTool.BorderColor), array8);
						graphics.DrawPolygon(new Pen(SimTool.BorderColor), array7);
					}
					if (SimTool.Type == SimulationToolType.Cross)
					{
						Point pt = new Point(UTPx(SimTool.Coordinate.X), UTPy(SimTool.Coordinate.Y));
						graphics.DrawLine(pt2: new Point(UTPx(SimTool.Coordinate.X + SimTool.Diameter / 2.0), pt.Y), pen: new Pen(SimTool.Color, (float)SimTool.Thickness), pt1: pt);
						graphics.DrawLine(pt2: new Point(UTPx(SimTool.Coordinate.X - SimTool.Diameter / 2.0), pt.Y), pen: new Pen(SimTool.Color, (float)SimTool.Thickness), pt1: pt);
						graphics.DrawLine(pt2: new Point(pt.X, UTPy(SimTool.Coordinate.Y + SimTool.Diameter / 2.0)), pen: new Pen(SimTool.Color, (float)SimTool.Thickness), pt1: pt);
						graphics.DrawLine(pt2: new Point(pt.X, UTPy(SimTool.Coordinate.Y - SimTool.Diameter / 2.0)), pen: new Pen(SimTool.Color, (float)SimTool.Thickness), pt1: pt);
					}
				}
				pictureBox_0.Image = Bmp;
				CopiedEnt.Clear();
			}
			else
			{
				CopiedEnt.Clear();
			}
		}
		catch (Exception)
		{
		}
	}

	public void AddEntities(List<eEntities> RefEntities)
	{
		Entities.Clear();
		eEntities.CopyEntities(RefEntities, ref Entities);
	}

	public void SaveScreenToFile(string Filename)
	{
		if (Filename.Length > 0)
		{
			pictureBox_0.Image.Save(Filename);
		}
	}

	public void ClearEntities()
	{
		MaterialEntities.Clear();
		Entities.Clear();
		DimensionEntities.Clear();
		CamEntities.Clear();
		ArrowEntities.Clear();
		DrawEntities();
	}

	public void DrawCamEntities()
	{
		try
		{
			ClientHeight = pictureBox_0.Height;
			ClientWidth = pictureBox_0.Width;
			if ((pictureBox_0.Width == 0) | (pictureBox_0.Height == 0))
			{
				return;
			}
			Bitmap image = new Bitmap(pictureBox_0.Width, pictureBox_0.Height);
			Graphics graphics = Graphics.FromImage(image);
			graphics.Clear(BackColor);
			Color color = default(Color);
			float num = 1f;
			Pnt3D MinPoint = new Pnt3D();
			Pnt3D MaxPoint = new Pnt3D();
			Pnt3D MinPoint2 = new Pnt3D();
			Pnt3D MaxPoint2 = new Pnt3D();
			List<Pnt3D> list = new List<Pnt3D>();
			if (Entities.Count > 0)
			{
				buControlCoreClass.cVector.BoxSizeCalculate(Entities, ref MinPoint, ref MaxPoint);
				list.Add(MinPoint);
				list.Add(MaxPoint);
			}
			if (DimensionEntities.Count > 0)
			{
				buControlCoreClass.cVector.BoxSizeCalculate(DimensionEntities, ref MinPoint, ref MaxPoint);
				list.Add(MinPoint);
				list.Add(MaxPoint);
			}
			if (ArrowEntities.Count > 0)
			{
				buControlCoreClass.cVector.BoxSizeCalculate(ArrowEntities, ref MinPoint, ref MaxPoint);
				list.Add(MinPoint);
				list.Add(MaxPoint);
			}
			if (MaterialEntities.Count > 0)
			{
				buControlCoreClass.cVector.BoxSizeCalculate(MaterialEntities, ref MinPoint, ref MaxPoint);
				list.Add(MinPoint);
				list.Add(MaxPoint);
			}
			buControlCoreClass.cVector.BoxSizeCalculate(list, ref MinPoint2, ref MaxPoint2);
			BoxSizeOfEntities = new BoxSize(MinPoint2, MaxPoint2);
			BoxSizeOfEntities.Delta = new Vec3D(MaxPoint2.X - MinPoint2.X, MaxPoint2.Y - MinPoint2.Y, MaxPoint2.Z - MinPoint2.Z);
			for (int i = 0; i <= Entities.Count - 1; i++)
			{
				if (Entities[i].bVisible)
				{
					color = Entities[i].dispColor;
					if ((color.A == 0) & (color.B == 0) & (color.G == 0) & (color.R == 0))
					{
						color = Color.Black;
					}
					num = Entities[i].dispThickness;
					if (Entities[i].bSelected)
					{
						color = SelectedEntityColor;
						num = (float)SelectedEntityThickness;
					}
					for (int j = 1; j <= Entities[i].Vertice.Count - 1; j++)
					{
						graphics.DrawLine(new Pen(color, num), UTPx(Entities[i].Vertice[j - 1].X), UTPy(Entities[i].Vertice[j - 1].Y), UTPx(Entities[i].Vertice[j].X), UTPy(Entities[i].Vertice[j].Y));
					}
					if (Entities[i].Vertice.Count == 1)
					{
						graphics.DrawArc(new Pen(color, num), UTPx(Entities[i].Vertice[0].X), UTPy(Entities[i].Vertice[0].Y), 2, 2, 0, 360);
					}
				}
			}
			for (int k = 0; k <= CamEntities.Count - 1; k++)
			{
				if (CamEntities[k].bVisible)
				{
					color = CamEntities[k].dispColor;
					color = CamEntitiesColor;
					if ((color.A == 0) & (color.B == 0) & (color.G == 0) & (color.R == 0))
					{
						color = Color.Black;
					}
					num = CamEntities[k].dispThickness + 1f;
					if (CamEntities[k].bSelected)
					{
						color = SelectedEntityColor;
						num = (float)SelectedEntityThickness;
					}
					for (int l = 1; l <= CamEntities[k].Vertice.Count - 1; l++)
					{
						graphics.DrawLine(new Pen(color, num), UTPx(CamEntities[k].Vertice[l - 1].X), UTPy(CamEntities[k].Vertice[l - 1].Y), UTPx(CamEntities[k].Vertice[l].X), UTPy(CamEntities[k].Vertice[l].Y));
					}
					if (CamEntities[k].Vertice.Count == 1)
					{
						graphics.DrawLine(new Pen(color, num), UTPx(CamEntities[k].Vertice[0].X), UTPy(CamEntities[k].Vertice[0].Y), UTPx(CamEntities[k].Vertice[0].X + 0.1), UTPy(CamEntities[k].Vertice[0].Y + 0.1));
					}
				}
			}
			pictureBox_0.Image = image;
		}
		catch (Exception)
		{
		}
	}

	public PointF ViewportUpdate(Pnt3D refPoint)
	{
		PointF result = default(PointF);
		if (!((viewAngle.X == 0.0) & (viewAngle.Y == 0.0) & (viewAngle.Z == 0.0)))
		{
			if (!((viewAngle.X == 180.0) & (viewAngle.Y == 180.0) & (viewAngle.Z == 0.0)))
			{
				if (!Only2D)
				{
					Pnt3D.Offset(ref refPoint, 0.0 - viewRotateCenter.X, 0.0 - viewRotateCenter.Y, 0.0 - viewRotateCenter.Z);
					Quaternion quaternion = default(Quaternion);
					quaternion.FromAxisAngle(new Vec3D(1.0, 0.0, 0.0), viewAngle.X * Math.PI / 180.0);
					quaternion.Rotate(refPoint);
					quaternion.Rotate(viewRotateCenter);
					Quaternion quaternion2 = default(Quaternion);
					quaternion2.FromAxisAngle(new Vec3D(0.0, 1.0, 0.0), viewAngle.Y * Math.PI / 180.0);
					quaternion2.Rotate(refPoint);
					quaternion2.Rotate(viewRotateCenter);
					Quaternion quaternion3 = default(Quaternion);
					quaternion3.FromAxisAngle(new Vec3D(0.0, 0.0, 1.0), viewAngle.Z * Math.PI / 180.0);
					quaternion3.Rotate(refPoint);
					quaternion3.Rotate(viewRotateCenter);
					Pnt3D.Offset(ref refPoint, viewRotateCenter.X, viewRotateCenter.Y, viewRotateCenter.Z);
				}
				if (viewProjectionMode == ProjectionModeType.Orthographic)
				{
					result = Get2D(refPoint);
				}
				if (viewProjectionMode == ProjectionModeType.Perspective)
				{
					result = viewCamera.GetProjection(refPoint);
				}
				return result;
			}
			result.X = (float)refPoint.X;
			result.Y = (float)refPoint.Y;
			return result;
		}
		result.X = (float)refPoint.X;
		result.Y = (float)refPoint.Y;
		return result;
	}

	public PointF Get2D(Pnt3D vec)
	{
		PointF result = default(PointF);
		Pnt3D pnt3D = new Pnt3D();
		pnt3D.X = pnt3D_1.X;
		pnt3D.Y = pnt3D_1.Y;
		pnt3D.Z = pnt3D_1.Z;
		result.X = Convert.ToSingle(pnt3D.X) - Convert.ToSingle(vec.X);
		result.Y = Convert.ToSingle(pnt3D.Y) - Convert.ToSingle(vec.Y);
		return result;
	}

	public static Pnt3D RotateX(Pnt3D point3D, float degrees)
	{
		double num = (double)degrees * (Math.PI / 180.0);
		double num2 = Math.Cos(num);
		double num3 = Math.Sin(num);
		double num4 = point3D.Y * num2 + point3D.Z * num3;
		double z = point3D.Y * (0.0 - num3) + point3D.Z * num2;
		return new Pnt3D(point3D.X, num4, z);
	}

	public static Pnt3D RotateY(Pnt3D point3D, float degrees)
	{
		double num = (double)degrees * (Math.PI / 180.0);
		double num2 = Math.Cos(num);
		double num3 = Math.Sin(num);
		double num4 = point3D.X * num2 + point3D.Z * num3;
		double z = point3D.X * (0.0 - num3) + point3D.Z * num2;
		return new Pnt3D(num4, point3D.Y, z);
	}

	public static Pnt3D RotateZ(Pnt3D point3D, float degrees)
	{
		double num = (double)degrees * (Math.PI / 180.0);
		double num2 = Math.Cos(num);
		double num3 = Math.Sin(num);
		double num4 = point3D.X * num2 + point3D.Y * num3;
		double num5 = point3D.X * (0.0 - num3) + point3D.Y * num2;
		return new Pnt3D(num4, num5, point3D.Z);
	}

	public static Pnt3D Translate(Pnt3D points3D, Pnt3D oldOrigin, Pnt3D newOrigin)
	{
		Pnt3D pnt3D = new Pnt3D(newOrigin.X - oldOrigin.X, newOrigin.Y - oldOrigin.Y, newOrigin.Z - oldOrigin.Z);
		points3D.X += pnt3D.X;
		points3D.Y += pnt3D.Y;
		points3D.Z += pnt3D.Z;
		return points3D;
	}

	public static Pnt3D[] RotateX(Pnt3D[] points3D, float degrees)
	{
		for (int i = 0; i < points3D.Length; i++)
		{
			points3D[i] = RotateX(points3D[i], degrees);
		}
		return points3D;
	}

	public static Pnt3D[] RotateY(Pnt3D[] points3D, float degrees)
	{
		for (int i = 0; i < points3D.Length; i++)
		{
			points3D[i] = RotateY(points3D[i], degrees);
		}
		return points3D;
	}

	public static Pnt3D[] RotateZ(Pnt3D[] points3D, float degrees)
	{
		for (int i = 0; i < points3D.Length; i++)
		{
			points3D[i] = RotateZ(points3D[i], degrees);
		}
		return points3D;
	}

	public static Pnt3D[] Translate(Pnt3D[] points3D, Pnt3D oldOrigin, Pnt3D newOrigin)
	{
		for (int i = 0; i < points3D.Length; i++)
		{
			points3D[i] = Translate(points3D[i], oldOrigin, newOrigin);
		}
		return points3D;
	}

	public double PTUx(int XPixel)
	{
		try
		{
			return ScreenLeft + (double)XPixel * ScreenWidth / (double)ClientWidth;
		}
		catch (Exception)
		{
			return 0.0;
		}
	}

	public double PTUy(int YPixel)
	{
		try
		{
			return ScreenTop + (double)(-1 * YPixel) * ScreenHeight / (double)ClientHeight;
		}
		catch (Exception)
		{
			return 0.0;
		}
	}

	public int UTPx(double XValue)
	{
		try
		{
			if (ScreenWidth == 0.0)
			{
				return 0;
			}
			return Convert.ToInt32((XValue - ScreenLeft) * (double)ClientWidth / ScreenWidth);
		}
		catch (Exception)
		{
			return 0;
		}
	}

	public int UTPy(double YValue)
	{
		try
		{
			if (ScreenHeight == 0.0)
			{
				return 0;
			}
			return Convert.ToInt32((ScreenTop - YValue) * (double)ClientHeight / ScreenHeight);
		}
		catch (Exception)
		{
			return 0;
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

	static buViewer()
	{
		string_0 = "fduyfuFDSGERTHSAF-*05435/&%(hgfdhgfHGFHGFHvxcvcvTREQWEFVFDNB gR E%YT%E";
		string_1 = "QWEFGHLJHGFhjklopoıuygtfc-*098h?=)(/TFDERTYUI)OKNBVFDRErd345678uhgfdXCVBHJ/&%RDW^+%&/()=)(/TRFCVBNYTrEDSX";
		string_2 = "";
		string_3 = "";
		double_0 = 0.0;
		double_1 = 0.0;
	}
}
