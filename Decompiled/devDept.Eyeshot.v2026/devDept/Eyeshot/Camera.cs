using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
using devDept.Eyeshot.Converters;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot;

[Serializable]
[TypeConverter(typeof(CameraConverter))]
public class Camera : ICloneable, ISerializable, INotifyPropertyChanged, IDisposable
{
	private delegate void _0023_003Dz748xQJjL2a1NqeVegg_003D_003D(Entity _0023_003Dzs_0024uS8LA_003D, TraversalParams _0023_003DzmPmPjCPqZ3T3, ref bool _0023_003DzRVoDPs0_003D, ref Point3D _0023_003DzF7v9r2A_003D, ref Point3D _0023_003Dz8dK2uhU_003D);

	internal class CameraSharedData
	{
		public projectionMatrixType CurrProjectionMatrixType;
	}

	internal abstract class ViewAnimator
	{
		protected Point3D oldTarget;

		protected double oldDistance;

		protected double newDistance;

		protected double oldZoomFactor;

		protected double newZoomFactor;

		protected Vector3D diffTarget;

		public int viewportIndex;

		protected double animationDuration;

		protected Timer timer;

		protected TimerCallback myDelegate;

		protected Stopwatch stopWatch;

		protected int frame;

		private double diffDistance;

		private double diffZoomFactor;

		private Plane cameraPlane;

		private Point2D ratioTargetDiff;

		private Vector3D camX;

		private Vector3D camY;

		private IWorkspaceInternal _workspace;

		protected internal Camera Camera;

		public bool IsFinished => (double)stopWatch.ElapsedMilliseconds >= animationDuration;

		public bool isRunning => timer != null;

		public ViewAnimator()
		{
		}

		public ViewAnimator(IViewport viewport, Point3D oldTarget, double oldDistance, double oldZoomFactor, Point3D newTarget, double newDistance, double newZoomFactor, int animationDuration, TimerCallback myDelegate)
		{
			this.animationDuration = animationDuration;
			_workspace = ((IViewportInternal)viewport).parent;
			Camera = (Camera)viewport.Camera.Clone();
			if (oldTarget != null && newTarget != null)
			{
				this.oldTarget = oldTarget;
				diffTarget = Vector3D.Subtract(newTarget, oldTarget);
				this.oldDistance = oldDistance;
				this.oldZoomFactor = oldZoomFactor;
				this.newDistance = newDistance;
				this.newZoomFactor = newZoomFactor;
				diffDistance = newDistance - oldDistance;
				diffZoomFactor = newZoomFactor - oldZoomFactor;
				if (Camera.cameraProjection == projectionType.Orthographic)
				{
					Camera.GetFrame(out var _, out camX, out camY, out var _);
					cameraPlane = new Plane(oldTarget, camX, camY);
					double _0023_003DznYtQKck_003D = Camera._0023_003DznYtQKck_003D;
					double _0023_003DzXmrDMdc_003D = Camera._0023_003DzXmrDMdc_003D;
					Point2D point2D = cameraPlane.Project(newTarget);
					ratioTargetDiff = new Point2D(point2D.X / _0023_003DznYtQKck_003D, point2D.Y / _0023_003DzXmrDMdc_003D);
				}
			}
			this.myDelegate = myDelegate;
		}

		public virtual bool Start(int viewportIndex)
		{
			this.viewportIndex = viewportIndex;
			frame = 0;
			_workspace.RaiseCameraMoveBegin(_workspace.Viewports[viewportIndex]);
			if (oldTarget != null)
			{
				return diffTarget != null;
			}
			return false;
		}

		protected void Activate()
		{
			timer = new Timer(myDelegate, null, 0, 20);
			stopWatch = new Stopwatch();
			stopWatch.Start();
		}

		public void Stop()
		{
			if (isRunning)
			{
				timer.Dispose();
				timer = null;
				stopWatch.Stop();
			}
		}

		public virtual void FinalFrame(IViewport viewport)
		{
			ComputeFrame(viewport.GetViewFrame(), 1.0);
		}

		public void NextFrame(IViewport viewport)
		{
			ComputeFrame(viewport.GetViewFrame(), Math.Min((double)stopWatch.ElapsedMilliseconds / animationDuration, 1.0));
		}

		protected virtual void ComputeFrame(int[] viewFrame, double t)
		{
			if (oldTarget != null)
			{
				Point3D point3D = oldTarget + t * diffTarget;
				double distance = oldDistance + t * diffDistance;
				double zoomFactor = oldZoomFactor + t * diffZoomFactor;
				if (Camera.cameraProjection == projectionType.Orthographic)
				{
					Camera.ZoomFactor = zoomFactor;
					Plane plane = new Plane(point3D, camX, camY);
					Point2D point2D = plane.Project(oldTarget + diffTarget);
					Point2D a = new Point2D(point2D.X / Camera._0023_003DznYtQKck_003D, point2D.Y / Camera._0023_003DzXmrDMdc_003D);
					Point2D b = ratioTargetDiff * (1.0 - t);
					Vector2D vector2D = Vector2D.Subtract(a, b);
					point3D = plane.PointAt(vector2D.X * Camera._0023_003DznYtQKck_003D, vector2D.Y * Camera._0023_003DzXmrDMdc_003D);
					Camera.ZoomFactor = zoomFactor;
				}
				Camera.Target = point3D;
				Camera.Distance = distance;
			}
		}
	}

	internal class ViewOrientationAnimator : ViewAnimator
	{
		private Point3D rotationCenter;

		private Vector2D rotationCenterDifference;

		public Quaternion oldRotation;

		public Quaternion newRotation;

		private double phi;

		private Point2D startRotationCenter2D;

		private Point2D endRotationCenter2D;

		private rotationCenterType rotationCenterMode;

		private viewType view;

		private rotationType _prevRotMode;

		private rotationCenterType _prevRotCentType;

		private Point3D _prevRotCenter;

		public ViewOrientationAnimator(IViewport viewport, viewType view, Quaternion oldRotation, Point3D oldTarget, double oldDistance, double oldZoomFactor, Quaternion newRotation, Point3D newTarget, double newDistance, double newZoomFactor, int animationDuration, TimerCallback myDelegate)
			: base(viewport, oldTarget, oldDistance, oldZoomFactor, newTarget, newDistance, newZoomFactor, animationDuration, myDelegate)
		{
			this.view = view;
			int[] viewFrame = viewport.GetViewFrame();
			rotationCenterMode = viewport.Rotate.RotationCenter;
			PrepareViewOrientationAnimation(((IViewportInternal)viewport).parent);
			this.oldRotation = oldRotation;
			this.newRotation = newRotation;
			double num = oldRotation.X * newRotation.X + oldRotation.Y * newRotation.Y + oldRotation.Z * newRotation.Z + oldRotation.W * newRotation.W;
			if (num < 0.0)
			{
				num *= -1.0;
				this.oldRotation *= -1.0;
			}
			if (num > 1.0)
			{
				num = 1.0;
			}
			else if (num < -1.0)
			{
				num = -1.0;
			}
			phi = Math.Acos(num);
			if (phi != 0.0 && oldTarget != null && newTarget != null)
			{
				Camera.UpdateMatrices();
				rotationCenter = (Point3D)Camera.Target.Clone();
				startRotationCenter2D = Camera.WorldToScreen(rotationCenter.X, rotationCenter.Y, rotationCenter.Z, viewFrame);
				Camera.Target = newTarget;
				Camera.Distance = newDistance;
				Camera.Rotation = newRotation;
				Camera.ZoomFactor = newZoomFactor;
				Camera.UpdateMatrices();
				endRotationCenter2D = Camera.WorldToScreen(rotationCenter.X, rotationCenter.Y, rotationCenter.Z, viewFrame);
				rotationCenterDifference = Vector2D.Subtract(endRotationCenter2D, startRotationCenter2D);
				Camera.Target = oldTarget;
				Camera.Distance = oldDistance;
				Camera.Rotation = oldRotation;
				Camera.ZoomFactor = oldZoomFactor;
				Camera.UpdateMatrices();
			}
		}

		private void PrepareViewOrientationAnimation(IWorkspace viewportLayout)
		{
			IRotateSettings rotate = viewportLayout.ActiveViewport.Rotate;
			_prevRotMode = rotate.RotationMode;
			_prevRotCentType = rotate.RotationCenter;
			_prevRotCenter = rotate.Center;
			rotate.RotationMode = rotationType.Trackball;
			rotate.RotationCenter = rotationCenterType.ViewportCenter;
		}

		public override void FinalFrame(IViewport viewport)
		{
			FinalFrame((IViewportInternal)viewport);
		}

		private void FinalFrame(IViewportInternal viewport)
		{
			base.FinalFrame(viewport);
			viewport.Rotate.RotationMode = _prevRotMode;
			viewport.Rotate.RotationCenter = _prevRotCentType;
			viewport.Rotate.Center = _prevRotCenter;
			viewport.SuspendNavigation(suspend: false);
			viewport.parent.RaiseOnViewChanged(viewport, view);
		}

		public override bool Start(int viewportIndex)
		{
			bool flag = base.Start(viewportIndex);
			if (flag || phi != 0.0)
			{
				Activate();
				flag = true;
			}
			return flag;
		}

		protected override void ComputeFrame(int[] viewFrame, double t)
		{
			base.ComputeFrame(viewFrame, t);
			if (phi == 0.0)
			{
				return;
			}
			bool num = rotationCenter != null;
			if (!num)
			{
				Camera.ApplyCenterOfRotation(viewFrame, rotationCenterMode);
			}
			Camera.Rotation = Math.Sin(phi * (1.0 - t)) / Math.Sin(phi) * oldRotation + Math.Sin(phi * t) / Math.Sin(phi) * newRotation;
			if (num)
			{
				Camera.UpdateMatrices();
				Point3D point3D = Camera.WorldToScreen(rotationCenter.X, rotationCenter.Y, rotationCenter.Z, viewFrame);
				if (point3D.Z > 0.0 && point3D.Z < 1.0)
				{
					Point3D point3D2 = new Point3D(startRotationCenter2D.X + t * rotationCenterDifference.X, startRotationCenter2D.Y + t * rotationCenterDifference.Y, point3D.Z);
					Vector3D vector3D = Vector3D.Subtract(b: Camera.UnProject(Camera.renderContext, viewFrame, point3D2.X, point3D2.Y, point3D2.Z), a: rotationCenter);
					Camera.Target += vector3D;
					Camera.UpdateMatrices();
				}
			}
			if (!num)
			{
				Camera.RemoveOffsetForRotation();
			}
		}
	}

	internal class ViewPositionAnimator : ViewAnimator
	{
		public ViewPositionAnimator()
		{
		}

		public ViewPositionAnimator(IViewport viewport, Point3D oldTarget, double oldDistance, double oldZoomFactor, Point3D newTarget, double newDistance, double newZoomFactor, int animationDuration, TimerCallback myDelegate)
			: base(viewport, oldTarget, oldDistance, oldZoomFactor, newTarget, newDistance, newZoomFactor, animationDuration, myDelegate)
		{
		}

		public override bool Start(int viewportIndex)
		{
			base.Start(viewportIndex);
			Activate();
			return true;
		}
	}

	public enum navigationType
	{
		Examine,
		Walk,
		Fly
	}

	public enum perspectiveFitType
	{
		Quick,
		Accurate
	}

	internal enum projectionMatrixType
	{
		Standard,
		Selected
	}

	[NonSerialized]
	protected internal ZBufferBase ZBufferData;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double[] _0023_003DzvtFBASUBq4SB = new double[16];

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double[] _0023_003DzqyFRddu1_0024vL9 = new double[16];

	[NonSerialized]
	protected internal Point3D cameraLocation;

	protected Point3D cameraTarget = DefaultTarget;

	protected double cameraDistance = 100.0;

	[NonSerialized]
	protected Vector3D upVector = Vector3D.AxisZ;

	internal Quaternion cameraRotation = DefaultRotation;

	protected Transformation sceneTransformation;

	protected Transformation sceneTransformationInverted;

	protected System.Drawing.Point viewportPosition;

	protected internal projectionType cameraProjection = DefaultProjectionMode;

	[NonSerialized]
	protected internal double cameraNear = 1.0;

	[NonSerialized]
	protected internal double cameraFar = 100.0;

	private double focalLength = _0023_003Dz8xUWTAWsNhyV0Yfo5w_003D_003D();

	private double zoomFactor = 8.0;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RenderContextBase _0023_003DzaFJdwkah3EUD;

	internal readonly Quaternion InitialRotation;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal double[] _0023_003Dzxw_0024o022k6AD1 = new double[16];

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dz5F7_i_0024U_003D;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DznYtQKck_003D;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzXmrDMdc_003D;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzeMBeuAQ_003D;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal double _0023_003DzCzIe62JVg98L;

	[NonSerialized]
	internal Point3D projectedMin = Point3D.MaxValue;

	[NonSerialized]
	internal Point3D projectedMax = Point3D.MinValue;

	[NonSerialized]
	internal Point3D centerOfRotation = Point3D.Origin;

	[NonSerialized]
	internal bool allModelInsideFrustum;

	private Size2D _frame = new Size2D(36.0, 24.0);

	internal bool useNearOfFirstShadowSplitForSelected;

	internal double nearOfFirstShadowSplitForSelected;

	private double[] pickMatrix;

	internal bool useProjectionMatrixForSelected = true;

	private double _nearPlaneDistanceFactor = 0.001;

	private Vector3D screenOffsetForRotation = new Vector3D();

	[NonSerialized]
	internal CameraSharedData sharedData = new CameraSharedData();

	private double previousDepth;

	private double minimumDist;

	[CompilerGenerated]
	private Plane _003CReflectionPlane_003Ek__BackingField;

	private Point3D prevTarget;

	private double prevDistance;

	internal double convergenceDistance;

	internal static int ViewportPointSize;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public double[] ModelViewMatrix
	{
		get
		{
			return _0023_003DzvtFBASUBq4SB;
		}
		internal set
		{
			_0023_003DzvtFBASUBq4SB = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public double[] ProjectionMatrix
	{
		get
		{
			return _0023_003DzqyFRddu1_0024vL9;
		}
		internal set
		{
			_0023_003DzqyFRddu1_0024vL9 = value;
		}
	}

	protected internal static Point3D DefaultTarget => new Point3D(0.0, 0.0, 45.0);

	public Vector3D ViewNormal
	{
		get
		{
			Vector3D vector3D = Vector3D.Subtract(cameraLocation, cameraTarget);
			vector3D.Normalize();
			return vector3D;
		}
	}

	protected static Quaternion DefaultRotation => new Quaternion(Vector3D.AxisZ, 60.0) * new Quaternion(Vector3D.AxisY, 20.0);

	protected Size Size
	{
		get
		{
			return ZBufferData.Size;
		}
		set
		{
			ZBufferData.Size = value;
		}
	}

	protected internal static projectionType DefaultProjectionMode => projectionType.Perspective;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	internal Transformation SceneTransformation
	{
		get
		{
			return sceneTransformation;
		}
		set
		{
			sceneTransformation = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	internal Transformation SceneTransformationInverted
	{
		get
		{
			return sceneTransformationInverted;
		}
		set
		{
			sceneTransformationInverted = value;
		}
	}

	protected internal RenderContextBase renderContext => _0023_003DzaFJdwkah3EUD;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Camera aiming point.")]
	public Point3D Target
	{
		get
		{
			return cameraTarget;
		}
		set
		{
			cameraTarget = value;
			UpdateLocation();
			OnPropertyChanged(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952439));
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public Point3D Location
	{
		get
		{
			return cameraLocation;
		}
		set
		{
			cameraLocation = value;
			UpdateTarget();
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Distance between camera and target point.")]
	public double Distance
	{
		get
		{
			return cameraDistance;
		}
		set
		{
			cameraDistance = value;
			UpdateLocation();
			OnPropertyChanged(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952422));
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("3D rotation, supporting both Quaternion and predefined viewType values as string (e.g. Top, Front, Right, etc.).")]
	public Quaternion Rotation
	{
		get
		{
			return cameraRotation;
		}
		set
		{
			cameraRotation = value;
			UpdateLocation();
			OnPropertyChanged(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952403));
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Projection mode.")]
	public projectionType ProjectionMode
	{
		get
		{
			return cameraProjection;
		}
		set
		{
			_0023_003DzOVvv6lKlxgS7(value);
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Focal length, applies only to Perspective projection mode.")]
	public double FocalLength
	{
		get
		{
			return focalLength;
		}
		set
		{
			focalLength = value;
			OnPropertyChanged(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952365));
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Zoom factor, applies only to Orthographic projection mode.")]
	public double ZoomFactor
	{
		get
		{
			return zoomFactor;
		}
		set
		{
			zoomFactor = value;
			Utility.LimitRange(1E-09, ref zoomFactor, 1000000000.0);
			_0023_003DzeMBeuAQ_003D = (double)(-Size.Width) / 2.0 / zoomFactor;
			_0023_003DznYtQKck_003D = 0.0 - _0023_003DzeMBeuAQ_003D;
			_0023_003Dz5F7_i_0024U_003D = (double)(-Size.Height) / 2.0 / zoomFactor;
			_0023_003DzXmrDMdc_003D = 0.0 - _0023_003Dz5F7_i_0024U_003D;
			OnPropertyChanged(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952351));
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public double Near
	{
		get
		{
			return cameraNear;
		}
		internal set
		{
			cameraNear = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public double Far
	{
		get
		{
			return cameraFar;
		}
		internal set
		{
			cameraFar = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public Size2D Frame
	{
		get
		{
			return _frame;
		}
		set
		{
			_frame = value;
		}
	}

	[Browsable(false)]
	public double AngleOfView => Utility.RadToDeg(_0023_003DzT1nv_XGkbFYDaXSDkw_003D_003D());

	internal double HorizontalAngleOfView => Utility.RadToDeg(_0023_003DzerReMoZ5I5sJsXLZBg_003D_003D());

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Anaglyphic 3D.")]
	public bool Anaglyph3D { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Near plane distance factor.")]
	public double NearPlaneDistanceFactor
	{
		get
		{
			return _nearPlaneDistanceFactor;
		}
		set
		{
			if (value <= 0.0)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951999));
			}
			_nearPlaneDistanceFactor = value;
			OnPropertyChanged(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952033));
		}
	}

	public Plane NearPlane
	{
		get
		{
			GetFrame(out var origin, out var _, out var _, out var camZ);
			return new Plane(origin - camZ * Near, camZ);
		}
	}

	public Plane FarPlane
	{
		get
		{
			GetFrame(out var origin, out var _, out var _, out var camZ);
			return new Plane(origin - camZ * Far, camZ);
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	static Camera()
	{
		ViewportPointSize = 3;
		_0023_003DzZEROl_YJ_9b_0024tIOMvw_003D_003D._0023_003DzkhmDvZM_003D _0023_003DzkhmDvZM_003D = (_0023_003DzZEROl_YJ_9b_0024tIOMvw_003D_003D._0023_003DzkhmDvZM_003D)0;
		object[] array = null;
		array = new object[1] { _0023_003DzkhmDvZM_003D };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "T)JZgq\"ac2", array);
	}

	public Camera()
		: this(DefaultTarget, _0023_003DzQ5_0024XO8WebAKY(), DefaultRotation, DefaultProjectionMode, _0023_003Dz8xUWTAWsNhyV0Yfo5w_003D_003D(), _0023_003DzEYTZmPWO5T_p())
	{
	}

	public Camera(Point3D target, viewType view, double zoomFactor)
		: this(target, 100.0, GetViewRotation(view), projectionType.Orthographic, 50.0, zoomFactor, anaglyphic3D: false)
	{
	}

	public Camera(Point3D target, double distance, viewType view, double focalLength)
		: this(target, distance, GetViewRotation(view), projectionType.Perspective, focalLength, 1.0, anaglyphic3D: false)
	{
	}

	public Camera(Point3D target, double distance, Quaternion rotation, projectionType projectionMode, double focalLength, double zoomFactor)
		: this(target, distance, rotation, projectionMode, focalLength, zoomFactor, anaglyphic3D: false)
	{
	}

	public Camera(Point3D target, double distance, Quaternion rotation, projectionType projectionMode, double focalLength, double zoomFactor, bool anaglyphic3D)
		: this(target, distance, rotation, projectionMode, focalLength, zoomFactor, anaglyphic3D, 0.001)
	{
	}

	public Camera(Point3D target, double distance, Quaternion rotation, projectionType projectionMode, double focalLength, double zoomFactor, bool anaglyphic3D, double nearPlaneDistanceFactor)
	{
		cameraTarget = target;
		cameraDistance = distance;
		cameraRotation = rotation;
		_0023_003DziA0Z4SHpE1LT();
		cameraProjection = projectionMode;
		this.focalLength = focalLength;
		this.zoomFactor = zoomFactor;
		UpdateLocation();
		Anaglyph3D = anaglyphic3D;
		NearPlaneDistanceFactor = nearPlaneDistanceFactor;
		UpdateLocation();
		InitialRotation = Rotation;
	}

	protected Camera(Camera another)
		: this()
	{
		cameraTarget = (Point3D)another.cameraTarget.Clone();
		cameraLocation = (Point3D)another.cameraLocation.Clone();
		cameraDistance = another.cameraDistance;
		cameraRotation = (Quaternion)another.cameraRotation.Clone();
		InitialRotation = (Quaternion)another.InitialRotation.Clone();
		cameraProjection = another.cameraProjection;
		focalLength = another.focalLength;
		zoomFactor = another.ZoomFactor;
		_0023_003DzCzIe62JVg98L = another._0023_003DzCzIe62JVg98L;
		cameraNear = another.cameraNear;
		cameraFar = another.cameraFar;
		if (another.projectedMin != null)
		{
			projectedMin = (Point3D)another.projectedMin.Clone();
		}
		if (another.projectedMax != null)
		{
			projectedMax = (Point3D)another.projectedMax.Clone();
		}
		if (another.centerOfRotation != null)
		{
			centerOfRotation = (Point3D)another.centerOfRotation.Clone();
		}
		UpdateLocation();
		ProjectionMatrix = (double[])another.ProjectionMatrix.Clone();
		_0023_003Dzxw_0024o022k6AD1 = (double[])another._0023_003Dzxw_0024o022k6AD1.Clone();
		ModelViewMatrix = (double[])another.ModelViewMatrix.Clone();
		if (another.sceneTransformation != null)
		{
			sceneTransformation = (Transformation)another.sceneTransformation.Clone();
			sceneTransformationInverted = (Transformation)another.sceneTransformationInverted.Clone();
		}
		ZBufferData.ProjectionMatrix = (double[])ProjectionMatrix.Clone();
		viewportPosition = another.viewportPosition;
		Size = another.Size;
		Anaglyph3D = another.Anaglyph3D;
		screenOffsetForRotation = (Vector3D)another.screenOffsetForRotation.Clone();
		_0023_003DzeMBeuAQ_003D = another._0023_003DzeMBeuAQ_003D;
		_0023_003DznYtQKck_003D = another._0023_003DznYtQKck_003D;
		_0023_003DzXmrDMdc_003D = another._0023_003DzXmrDMdc_003D;
		_0023_003Dz5F7_i_0024U_003D = another._0023_003Dz5F7_i_0024U_003D;
		NearPlaneDistanceFactor = another.NearPlaneDistanceFactor;
		SetRenderContext(another.renderContext);
	}

	protected internal Camera(CameraSurrogate surrogate)
		: this(surrogate.Target, surrogate.Distance, surrogate.Rotation, (projectionType)surrogate.ProjectionMode, surrogate.FocalLength, surrogate.ZoomFactor)
	{
	}

	protected Camera(SerializationInfo info, StreamingContext context)
	{
		_0023_003DziA0Z4SHpE1LT();
		Target = (Point3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952439), typeof(Point3D));
		Distance = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952422));
		Rotation = (Quaternion)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952403), typeof(Quaternion));
		InitialRotation = (Quaternion)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952388), typeof(Quaternion));
		ProjectionMode = (projectionType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952378), typeof(projectionType));
		FocalLength = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952365));
		ZoomFactor = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952351));
		Anaglyph3D = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952050));
		NearPlaneDistanceFactor = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952033));
	}

	public void Dispose()
	{
		ZBufferData.Dispose();
	}

	private void _0023_003DziA0Z4SHpE1LT()
	{
		ZBufferData = new ZBufferBase();
		ZBufferData._0023_003DzUFS4ARhBvr2L(_0023_003DzPzO_0024GUk_003D: true);
	}

	public double[] myPerspective(RenderContextBase renderContext, double fovy, double aspect, double zNear, double zFar)
	{
		double num = Utility.DegToRad(fovy / 2.0);
		double num2 = zFar - zNear;
		double num3 = Math.Sin(num);
		if (num2 == 0.0 || num3 == 0.0 || aspect == 0.0)
		{
			return null;
		}
		double num4 = Math.Cos(num) / num3;
		double[] array = new double[16];
		double num5 = zFar / num2;
		if (renderContext == null || !renderContext.IsDirect3D)
		{
			array[0] = num4 / aspect;
			array[5] = num4;
			array[10] = (0.0 - (zFar + zNear)) / num2;
			array[11] = -1.0;
			array[14] = -2.0 * num5 * zNear;
		}
		else
		{
			array[0] = num4 / aspect;
			array[5] = num4;
			array[10] = 0.0 - num5;
			array[11] = -1.0;
			array[14] = (0.0 - num5) * zNear;
		}
		return array;
	}

	public static double[] myOrtho(RenderContextBase renderContext, double myLeft, double myRight, double myBottom, double myTop, double myNear, double myFar)
	{
		double[] array = new double[16];
		double num = myRight - myLeft;
		double num2 = myTop - myBottom;
		double num3 = myFar - myNear;
		double num4 = 1.0 / num3;
		array[0] = 2.0 / num;
		array[5] = 2.0 / num2;
		array[12] = (0.0 - (myRight + myLeft)) / num;
		array[13] = (0.0 - (myTop + myBottom)) / num2;
		array[15] = 1.0;
		if (renderContext == null || !renderContext.IsDirect3D)
		{
			array[10] = -2.0 * num4;
			array[14] = (0.0 - (myFar + myNear)) * num4;
		}
		else
		{
			array[10] = 0.0 - num4;
			array[14] = (0.0 - myNear) * num4;
		}
		return array;
	}

	internal void CheckScreenPointVisibility(int _0023_003DzG8PBei0_003D, short[] _0023_003DzkFiPhp9QI_5j, int _0023_003Dz6_0024CzTNlTaA6J, int[] _0023_003DzqDFBISpCePlj, float _0023_003DzaKqAXuA_003D, float _0023_003DzaQwF_00245U_003D, double _0023_003Dz8GLN4fI_003D, int _0023_003Dz6RzQuL_00245pp_0024n, int _0023_003Dz6PNUVyN5um0U, int _0023_003Dz_duJqf_0024qZ926, int _0023_003Dz_npROhUwuZOb, out bool _0023_003DzaaJHKt4_003D)
	{
		_0023_003DzaaJHKt4_003D = true;
		if (_0023_003DzaKqAXuA_003D < 0f || _0023_003DzaKqAXuA_003D > (float)_0023_003DzqDFBISpCePlj[2] || _0023_003DzaQwF_00245U_003D < 0f || _0023_003DzaQwF_00245U_003D > (float)_0023_003DzqDFBISpCePlj[3])
		{
			return;
		}
		_0023_003DzaKqAXuA_003D = (int)_0023_003DzaKqAXuA_003D;
		_0023_003DzaQwF_00245U_003D = (int)_0023_003DzaQwF_00245U_003D;
		if (_0023_003DzaKqAXuA_003D < (float)_0023_003Dz6RzQuL_00245pp_0024n)
		{
			_0023_003DzaKqAXuA_003D = _0023_003Dz6RzQuL_00245pp_0024n;
		}
		else if (_0023_003DzaKqAXuA_003D > (float)_0023_003Dz6PNUVyN5um0U)
		{
			_0023_003DzaKqAXuA_003D = _0023_003Dz6PNUVyN5um0U;
		}
		if (_0023_003DzaQwF_00245U_003D < (float)_0023_003Dz_duJqf_0024qZ926)
		{
			_0023_003DzaQwF_00245U_003D = _0023_003Dz_duJqf_0024qZ926;
		}
		else if (_0023_003DzaQwF_00245U_003D > (float)_0023_003Dz_npROhUwuZOb)
		{
			_0023_003DzaQwF_00245U_003D = _0023_003Dz_npROhUwuZOb;
		}
		ushort num = (ushort)(_0023_003Dz8GLN4fI_003D * 32767.0);
		int num2 = _0023_003DzG8PBei0_003D / 2;
		int num3 = (int)((_0023_003DzaQwF_00245U_003D - (float)num2) * (float)_0023_003Dz6_0024CzTNlTaA6J + _0023_003DzaKqAXuA_003D - (float)num2);
		for (int i = 0; i < _0023_003DzG8PBei0_003D; i++)
		{
			int num4 = num3 + _0023_003DzG8PBei0_003D;
			for (int j = num3; j < num4; j++)
			{
				short num5 = _0023_003DzkFiPhp9QI_5j[j];
				if (num5 == 0 || num <= num5)
				{
					_0023_003DzaaJHKt4_003D = false;
					break;
				}
			}
			num3 += _0023_003Dz6_0024CzTNlTaA6J;
			if (!_0023_003DzaaJHKt4_003D)
			{
				break;
			}
		}
	}

	protected internal Point3D UnProject(RenderContextBase renderContext, int[] viewFrame, double winx, double winy, double winz)
	{
		return UnProject(renderContext, viewFrame, _0023_003DzvtFBASUBq4SB, _0023_003DzqyFRddu1_0024vL9, winx, winy, winz);
	}

	protected internal bool UnProject(RenderContextBase renderContext, int[] viewFrame, double winx, double winy, double winz, out double x, out double y, out double z)
	{
		return UnProject(renderContext, viewFrame, _0023_003DzvtFBASUBq4SB, _0023_003DzqyFRddu1_0024vL9, winx, winy, winz, out x, out y, out z);
	}

	protected Point3D UnProject(RenderContextBase renderContext, int[] viewFrame, double[] myModelViewMatrix, double[] myProjectionMatrix, double winx, double winy, double winz)
	{
		if (UnProject(renderContext, viewFrame, myModelViewMatrix, myProjectionMatrix, winx, winy, winz, out var objx, out var objy, out var objz))
		{
			return new Point3D(objx, objy, objz);
		}
		return null;
	}

	protected internal bool UnProject(RenderContextBase renderContext, int[] viewFrame, double[] myModelViewMatrix, double[] myProjectionMatrix, double winx, double winy, double winz, out double objx, out double objy, out double objz)
	{
		objx = (objy = (objz = 0.0));
		if (!_0023_003DzY48JWScgTllAem1s3A_003D_003D(myModelViewMatrix, myProjectionMatrix, out var _0023_003DzjuqjeCoj92PE))
		{
			return false;
		}
		return _0023_003Dzui9so0k_003D(renderContext, viewFrame, _0023_003DzjuqjeCoj92PE, winx, winy, winz, out objx, out objy, out objz);
	}

	internal static bool _0023_003DzY48JWScgTllAem1s3A_003D_003D(double[] _0023_003DzvJUSQVQ_gV4J, double[] _0023_003DzI6Ir_0024BRgSG2P, out double[] _0023_003DzjuqjeCoj92PE)
	{
		_0023_003DzjuqjeCoj92PE = Utility.MultMatrixd(_0023_003DzvJUSQVQ_gV4J, _0023_003DzI6Ir_0024BRgSG2P);
		if (!Utility.InvertMatrixd(_0023_003DzjuqjeCoj92PE, _0023_003DzjuqjeCoj92PE))
		{
			return false;
		}
		return true;
	}

	protected internal static Point3D UnProject(RenderContextBase renderContext, int[] viewFrame, double[] inverseMatrix, double winx, double winy, double winz)
	{
		if (_0023_003Dzui9so0k_003D(renderContext, viewFrame, inverseMatrix, winx, winy, winz, out var _0023_003Dzz2rwxLp5KP6A, out var _0023_003DzALC2Z_0024vEE1_h, out var _0023_003DznHYVZ7T5ufgF))
		{
			return new Point3D(_0023_003Dzz2rwxLp5KP6A, _0023_003DzALC2Z_0024vEE1_h, _0023_003DznHYVZ7T5ufgF);
		}
		return null;
	}

	internal static bool _0023_003Dzui9so0k_003D(RenderContextBase _0023_003DzQdnFby4_003D, int[] _0023_003DzqDFBISpCePlj, double[] _0023_003DzjuqjeCoj92PE, double _0023_003Dzm3rc4SA8WtT6, double _0023_003DzOM5CofBvYOXf, double _0023_003Dz_00246VsdVC_0024uVkn, out double _0023_003Dzz2rwxLp5KP6A, out double _0023_003DzALC2Z_0024vEE1_h, out double _0023_003DznHYVZ7T5ufgF)
	{
		double[] array = new double[4];
		_0023_003Dzz2rwxLp5KP6A = (_0023_003DzALC2Z_0024vEE1_h = (_0023_003DznHYVZ7T5ufgF = 0.0));
		array[0] = _0023_003Dzm3rc4SA8WtT6;
		array[1] = _0023_003DzOM5CofBvYOXf;
		array[2] = _0023_003Dz_00246VsdVC_0024uVkn;
		array[3] = 1.0;
		array[0] = (array[0] - (double)_0023_003DzqDFBISpCePlj[0]) / (double)_0023_003DzqDFBISpCePlj[2];
		array[1] = (array[1] - (double)_0023_003DzqDFBISpCePlj[1]) / (double)_0023_003DzqDFBISpCePlj[3];
		array[0] = array[0] * 2.0 - 1.0;
		array[1] = array[1] * 2.0 - 1.0;
		if (_0023_003DzQdnFby4_003D == null || !_0023_003DzQdnFby4_003D.IsDirect3D)
		{
			array[2] = array[2] * 2.0 - 1.0;
		}
		double[] array2 = Utility.MultMatrixVecd(_0023_003DzjuqjeCoj92PE, array);
		if (array2[3] == 0.0)
		{
			return false;
		}
		array2[0] /= array2[3];
		array2[1] /= array2[3];
		array2[2] /= array2[3];
		_0023_003Dzz2rwxLp5KP6A = array2[0];
		_0023_003DzALC2Z_0024vEE1_h = array2[1];
		_0023_003DznHYVZ7T5ufgF = array2[2];
		return true;
	}

	internal static bool _0023_003DzlLK4_00249g_003D(double[] _0023_003DzypMGqyMVO5qA, int[] _0023_003DzqDFBISpCePlj, double _0023_003Dzz2rwxLp5KP6A, double _0023_003DzALC2Z_0024vEE1_h, double _0023_003DznHYVZ7T5ufgF, out double _0023_003Dzm3rc4SA8WtT6, out double _0023_003DzOM5CofBvYOXf)
	{
		double _0023_003Dz_00246VsdVC_0024uVkn;
		return Project(null, _0023_003DzypMGqyMVO5qA, _0023_003DzqDFBISpCePlj, _0023_003Dzz2rwxLp5KP6A, _0023_003DzALC2Z_0024vEE1_h, _0023_003DznHYVZ7T5ufgF, out _0023_003Dzm3rc4SA8WtT6, out _0023_003DzOM5CofBvYOXf, out _0023_003Dz_00246VsdVC_0024uVkn);
	}

	internal static bool Project(RenderContextBase _0023_003DzQdnFby4_003D, double[] _0023_003DzypMGqyMVO5qA, int[] _0023_003DzqDFBISpCePlj, double _0023_003Dzz2rwxLp5KP6A, double _0023_003DzALC2Z_0024vEE1_h, double _0023_003DznHYVZ7T5ufgF, out double _0023_003Dzm3rc4SA8WtT6, out double _0023_003DzOM5CofBvYOXf, out double _0023_003Dz_00246VsdVC_0024uVkn)
	{
		double[] array = new double[4];
		double[] array2 = new double[4];
		array[0] = _0023_003Dzz2rwxLp5KP6A;
		array[1] = _0023_003DzALC2Z_0024vEE1_h;
		array[2] = _0023_003DznHYVZ7T5ufgF;
		array[3] = 1.0;
		array2 = Utility.MultMatrixVecd(_0023_003DzypMGqyMVO5qA, array);
		_0023_003Dzm3rc4SA8WtT6 = (_0023_003DzOM5CofBvYOXf = (_0023_003Dz_00246VsdVC_0024uVkn = 0.0));
		if (array2[3] == 0.0)
		{
			return false;
		}
		array2[0] /= array2[3];
		array2[1] /= array2[3];
		array2[2] /= array2[3];
		array2[0] = array2[0] * 0.5 + 0.5;
		array2[1] = array2[1] * 0.5 + 0.5;
		if (_0023_003DzQdnFby4_003D == null || !_0023_003DzQdnFby4_003D.IsDirect3D)
		{
			array2[2] = array2[2] * 0.5 + 0.5;
		}
		_0023_003Dzm3rc4SA8WtT6 = array2[0] * (double)_0023_003DzqDFBISpCePlj[2] + (double)_0023_003DzqDFBISpCePlj[0];
		_0023_003DzOM5CofBvYOXf = array2[1] * (double)_0023_003DzqDFBISpCePlj[3] + (double)_0023_003DzqDFBISpCePlj[1];
		_0023_003Dz_00246VsdVC_0024uVkn = array2[2];
		return true;
	}

	public double[] GetModelViewProjectionMatrix(bool withCurrentBlockReferenceTransformation = false)
	{
		if (withCurrentBlockReferenceTransformation && sceneTransformation != null)
		{
			return Utility.MultMatrixd(Utility.MultMatrixd(sceneTransformation.MatrixAsVectorByColumn, _0023_003DzvtFBASUBq4SB), _0023_003DzqyFRddu1_0024vL9);
		}
		return Utility.MultMatrixd(_0023_003DzvtFBASUBq4SB, _0023_003DzqyFRddu1_0024vL9);
	}

	internal bool _0023_003DzKWdaQi8_003D(RenderContextBase _0023_003DzQdnFby4_003D, int[] _0023_003DzqDFBISpCePlj, double _0023_003Dzz2rwxLp5KP6A, double _0023_003DzALC2Z_0024vEE1_h, double _0023_003DznHYVZ7T5ufgF, out double _0023_003Dzm3rc4SA8WtT6, out double _0023_003DzOM5CofBvYOXf, out double _0023_003Dz_00246VsdVC_0024uVkn)
	{
		double[] _0023_003DzypMGqyMVO5qA = Utility.MultMatrixd(_0023_003DzvtFBASUBq4SB, _0023_003DzqyFRddu1_0024vL9);
		return Project(_0023_003DzQdnFby4_003D, _0023_003DzypMGqyMVO5qA, _0023_003DzqDFBISpCePlj, _0023_003Dzz2rwxLp5KP6A, _0023_003DzALC2Z_0024vEE1_h, _0023_003DznHYVZ7T5ufgF, out _0023_003Dzm3rc4SA8WtT6, out _0023_003DzOM5CofBvYOXf, out _0023_003Dz_00246VsdVC_0024uVkn);
	}

	internal bool ReadViewportZBufferRange(ref double _0023_003Dz89Mrb8s_003D, ref double _0023_003DzPcIjH6k_003D, bool _0023_003DzpMGfkrQ_003D, int _0023_003DzyB3SKeNM_0024LVQ, int _0023_003DzKiuNLdm9iD7U)
	{
		return ZBufferData.ReadZRange(renderContext, new System.Drawing.Point(viewportPosition.X + (int)Math.Ceiling((double)Size.Width / 2.0), viewportPosition.Y + (int)Math.Ceiling((double)Size.Height / 2.0)), Size.Width, Size.Height, ref _0023_003Dz89Mrb8s_003D, ref _0023_003DzPcIjH6k_003D, _0023_003DzpMGfkrQ_003D, _0023_003DzyB3SKeNM_0024LVQ, _0023_003DzKiuNLdm9iD7U);
	}

	internal bool ReadViewportZBufferRange(System.Drawing.Point _0023_003Dz2XaK0dBvMt7MsAVGuA_003D_003D, bool _0023_003Dzu_0024kNbQmDeTS6, int _0023_003DzTIQpkZcb0vw_0024, int _0023_003Dzr1AzNuQsEtRi, int _0023_003DzyB3SKeNM_0024LVQ, int _0023_003DzKiuNLdm9iD7U)
	{
		double min = 0.0;
		double max = 0.0;
		ZBufferData._0023_003DzUFS4ARhBvr2L(_0023_003DzPzO_0024GUk_003D: false);
		bool flag = false;
		renderContext.BeginCaptureZBufferOnce();
		if (!_0023_003Dzu_0024kNbQmDeTS6 && _0023_003Dz2XaK0dBvMt7MsAVGuA_003D_003D != System.Drawing.Point.Empty)
		{
			flag = ZBufferData.ReadPickBoxZRange(renderContext, _0023_003Dz2XaK0dBvMt7MsAVGuA_003D_003D, _0023_003DzTIQpkZcb0vw_0024, ref min, ref max);
			if (!flag && _0023_003Dzr1AzNuQsEtRi > _0023_003DzTIQpkZcb0vw_0024)
			{
				flag = ZBufferData.ReadPickBoxZRange(renderContext, _0023_003Dz2XaK0dBvMt7MsAVGuA_003D_003D, _0023_003Dzr1AzNuQsEtRi, ref min, ref max);
			}
		}
		if (!flag)
		{
			flag = ReadViewportZBufferRange(ref min, ref max, _0023_003DzpMGfkrQ_003D: true, _0023_003DzyB3SKeNM_0024LVQ, _0023_003DzKiuNLdm9iD7U);
		}
		renderContext.EndCaptureZBufferOnce();
		if (flag)
		{
			ZBufferData.Min = min;
			ZBufferData.Max = max;
		}
		if (flag || !Utility.IsValidMatrix(ZBufferData.ModelViewMatrix))
		{
			ZBufferData.ModelViewMatrix = (double[])_0023_003DzvtFBASUBq4SB.Clone();
			ZBufferData.ProjectionMatrix = (double[])_0023_003DzqyFRddu1_0024vL9.Clone();
			ZBufferData.Location = (Point3D)cameraLocation.Clone();
		}
		return flag;
	}

	internal bool UpdateZBufferRange(System.Drawing.Point _0023_003Dz2XaK0dBvMt7MsAVGuA_003D_003D, int _0023_003DzTIQpkZcb0vw_0024, int _0023_003Dzr1AzNuQsEtRi, int _0023_003DzyB3SKeNM_0024LVQ, int _0023_003DzKiuNLdm9iD7U)
	{
		if (ZBufferData.IsInvalidRange)
		{
			return ReadViewportZBufferRange(_0023_003Dz2XaK0dBvMt7MsAVGuA_003D_003D, _0023_003Dzu_0024kNbQmDeTS6: false, _0023_003DzTIQpkZcb0vw_0024, _0023_003Dzr1AzNuQsEtRi, _0023_003DzyB3SKeNM_0024LVQ, _0023_003DzKiuNLdm9iD7U);
		}
		return false;
	}

	internal void CheckScreenPointVisibility(int _0023_003Dzs3Tbbpix3oL8, Size _0023_003Dz14lzA48_003D, int[] _0023_003DzqDFBISpCePlj, float _0023_003DzaKqAXuA_003D, float _0023_003DzaQwF_00245U_003D, double _0023_003Dz8GLN4fI_003D, int _0023_003Dz6RzQuL_00245pp_0024n, int _0023_003Dz6PNUVyN5um0U, int _0023_003Dz_duJqf_0024qZ926, int _0023_003Dz_npROhUwuZOb, out bool _0023_003DzaaJHKt4_003D)
	{
		_0023_003DzaaJHKt4_003D = true;
		if (_0023_003DzaKqAXuA_003D < 0f || _0023_003DzaKqAXuA_003D > (float)_0023_003DzqDFBISpCePlj[2] || _0023_003DzaQwF_00245U_003D < 0f || _0023_003DzaQwF_00245U_003D > (float)_0023_003DzqDFBISpCePlj[3])
		{
			return;
		}
		if (_0023_003DzaKqAXuA_003D < (float)_0023_003Dz6RzQuL_00245pp_0024n)
		{
			_0023_003DzaKqAXuA_003D = _0023_003Dz6RzQuL_00245pp_0024n;
		}
		else if (_0023_003DzaKqAXuA_003D > (float)_0023_003Dz6PNUVyN5um0U)
		{
			_0023_003DzaKqAXuA_003D = _0023_003Dz6PNUVyN5um0U;
		}
		if (_0023_003DzaQwF_00245U_003D < (float)_0023_003Dz_duJqf_0024qZ926)
		{
			_0023_003DzaQwF_00245U_003D = _0023_003Dz_duJqf_0024qZ926;
		}
		else if (_0023_003DzaQwF_00245U_003D > (float)_0023_003Dz_npROhUwuZOb)
		{
			_0023_003DzaQwF_00245U_003D = _0023_003Dz_npROhUwuZOb;
		}
		ushort num = (ushort)(_0023_003Dz8GLN4fI_003D * 32767.0);
		short[] array = renderContext.ReadDepthValues(new System.Drawing.Point((int)(_0023_003DzaKqAXuA_003D + (float)_0023_003DzqDFBISpCePlj[0]), (int)(_0023_003DzaQwF_00245U_003D + (float)_0023_003DzqDFBISpCePlj[1])), _0023_003Dz14lzA48_003D);
		for (int i = 0; i < array.Length; i++)
		{
			ushort num2 = (ushort)array[i];
			if (num2 == 0 || num <= num2)
			{
				_0023_003DzaaJHKt4_003D = false;
				break;
			}
		}
	}

	protected internal static double[] LookAtInternal(Point3D eye, Point3D center, Vector3D up, Vector3D side)
	{
		Vector3D vector3D = Vector3D.Subtract(center, eye);
		vector3D.Normalize();
		return LookAt(eye, vector3D, side);
	}

	protected internal static double[] LookAt(Point3D eye, Vector3D forward, Vector3D side)
	{
		Vector3D vector3D = Vector3D.Cross(side, forward);
		double[] array = new double[16];
		array[0] = side.X;
		array[4] = side.Y;
		array[8] = side.Z;
		array[1] = vector3D.X;
		array[5] = vector3D.Y;
		array[9] = vector3D.Z;
		array[2] = 0.0 - forward.X;
		array[6] = 0.0 - forward.Y;
		array[10] = 0.0 - forward.Z;
		array[15] = 1.0;
		double[] array2 = new double[16];
		array2[0] = 1.0;
		array2[5] = 1.0;
		array2[10] = 1.0;
		array2[15] = 1.0;
		array2[12] = 0.0 - eye.X;
		array2[13] = 0.0 - eye.Y;
		array2[14] = 0.0 - eye.Z;
		return Utility.MultMatrixd(array2, array);
	}

	public void GetFrame(out Point3D origin, out Vector3D camX, out Vector3D camY, out Vector3D camZ)
	{
		origin = (Point3D)cameraLocation.Clone();
		camZ = ViewNormal;
		camY = (Vector3D)upVector.Clone();
		camX = Vector3D.Cross(camY, camZ);
	}

	internal bool InvalidateZRange(bool _0023_003DzGk93_rs_003D)
	{
		bool isInvalidRange = ZBufferData.IsInvalidRange;
		ZBufferData._0023_003DzUFS4ARhBvr2L(_0023_003DzGk93_rs_003D);
		return isInvalidRange;
	}

	internal static void _0023_003Dzpvu8W3vYS_ck(float _0023_003DzBJFJHwk_003D, float _0023_003Dz40R7bAU_003D, float _0023_003Dz6BGrPgQ_003D, float _0023_003DzmpbNTR0_003D, Size _0023_003Dz4BrWeV0_003D, out double[] _0023_003DzlTrXFNo_003D)
	{
		_0023_003DzlTrXFNo_003D = new double[16];
		_0023_003DzlTrXFNo_003D[0] = (_0023_003DzlTrXFNo_003D[5] = (_0023_003DzlTrXFNo_003D[10] = (_0023_003DzlTrXFNo_003D[15] = 1.0)));
		if (!(_0023_003Dz6BGrPgQ_003D <= 0f) && !(_0023_003DzmpbNTR0_003D <= 0f))
		{
			Utility.Translated(((float)_0023_003Dz4BrWeV0_003D.Width - 2f * _0023_003DzBJFJHwk_003D) / _0023_003Dz6BGrPgQ_003D, ((float)_0023_003Dz4BrWeV0_003D.Height - 2f * _0023_003Dz40R7bAU_003D) / _0023_003DzmpbNTR0_003D, 0.0, ref _0023_003DzlTrXFNo_003D);
			Utility.Scaled((float)_0023_003Dz4BrWeV0_003D.Width / _0023_003Dz6BGrPgQ_003D, (float)_0023_003Dz4BrWeV0_003D.Height / _0023_003DzmpbNTR0_003D, 1.0, ref _0023_003DzlTrXFNo_003D);
		}
	}

	internal static double _0023_003DzQ5_0024XO8WebAKY()
	{
		return 380.0;
	}

	internal static double _0023_003Dz8xUWTAWsNhyV0Yfo5w_003D_003D()
	{
		return 50.0;
	}

	internal static double _0023_003DzEYTZmPWO5T_p()
	{
		return 2.0;
	}

	internal void SetRenderContext(RenderContextBase _0023_003Dz8If0AEk_003D)
	{
		_0023_003DzaFJdwkah3EUD = _0023_003Dz8If0AEk_003D;
		if (_0023_003Dz8If0AEk_003D != null)
		{
			ZBufferBase zBufferBase = _0023_003Dz8If0AEk_003D.CreateZBuffer(ZBufferData);
			zBufferBase._0023_003DzUFS4ARhBvr2L(_0023_003DzPzO_0024GUk_003D: true);
			ZBufferData.Dispose();
			ZBufferData = zBufferBase;
		}
	}

	internal void UpdateTarget()
	{
		Transformation transformation = _0023_003DzMJBp3SIZOfgg(Rotation);
		_0023_003DzeucN51LQK0q4();
		Point3D point3D = new Point3D(0.0 - cameraDistance, 0.0, 0.0);
		Point3D point3D2 = new Point3D(0.0 - cameraDistance, 0.0, cameraDistance);
		point3D = transformation * point3D;
		point3D2 = transformation * point3D2;
		cameraTarget = cameraLocation + point3D;
		Vector3D vector3D = Vector3D.Subtract(point3D2, point3D);
		vector3D.Normalize();
		upVector = vector3D;
	}

	internal static Quaternion ToQuaternion(Transformation _0023_003DzkKfJheA_003D)
	{
		double num;
		Quaternion quaternion;
		if (_0023_003DzkKfJheA_003D[2, 2] < 0.0)
		{
			if (_0023_003DzkKfJheA_003D[0, 0] > _0023_003DzkKfJheA_003D[1, 1])
			{
				num = 1.0 + _0023_003DzkKfJheA_003D[0, 0] - _0023_003DzkKfJheA_003D[1, 1] - _0023_003DzkKfJheA_003D[2, 2];
				quaternion = new Quaternion(num, _0023_003DzkKfJheA_003D[0, 1] + _0023_003DzkKfJheA_003D[1, 0], _0023_003DzkKfJheA_003D[2, 0] + _0023_003DzkKfJheA_003D[0, 2], _0023_003DzkKfJheA_003D[1, 2] - _0023_003DzkKfJheA_003D[2, 1]);
			}
			else
			{
				num = 1.0 - _0023_003DzkKfJheA_003D[0, 0] + _0023_003DzkKfJheA_003D[1, 1] - _0023_003DzkKfJheA_003D[2, 2];
				quaternion = new Quaternion(_0023_003DzkKfJheA_003D[0, 1] + _0023_003DzkKfJheA_003D[1, 0], num, _0023_003DzkKfJheA_003D[1, 2] + _0023_003DzkKfJheA_003D[2, 1], _0023_003DzkKfJheA_003D[2, 0] - _0023_003DzkKfJheA_003D[0, 2]);
			}
		}
		else if (_0023_003DzkKfJheA_003D[0, 0] < 0.0 - _0023_003DzkKfJheA_003D[1, 1])
		{
			num = 1.0 - _0023_003DzkKfJheA_003D[0, 0] - _0023_003DzkKfJheA_003D[1, 1] + _0023_003DzkKfJheA_003D[2, 2];
			quaternion = new Quaternion(_0023_003DzkKfJheA_003D[2, 0] + _0023_003DzkKfJheA_003D[0, 2], _0023_003DzkKfJheA_003D[1, 2] + _0023_003DzkKfJheA_003D[2, 1], num, _0023_003DzkKfJheA_003D[0, 1] - _0023_003DzkKfJheA_003D[1, 0]);
		}
		else
		{
			num = 1.0 + _0023_003DzkKfJheA_003D[0, 0] + _0023_003DzkKfJheA_003D[1, 1] + _0023_003DzkKfJheA_003D[2, 2];
			quaternion = new Quaternion(_0023_003DzkKfJheA_003D[1, 2] - _0023_003DzkKfJheA_003D[2, 1], _0023_003DzkKfJheA_003D[2, 0] - _0023_003DzkKfJheA_003D[0, 2], _0023_003DzkKfJheA_003D[0, 1] - _0023_003DzkKfJheA_003D[1, 0], num);
		}
		return quaternion * (0.5 / Math.Sqrt(num));
	}

	internal void UpdateTarget(Transformation _0023_003DzNDQ_E88_003D)
	{
		cameraRotation = ToQuaternion(_0023_003DzNDQ_E88_003D);
		cameraRotation.Normalize();
		cameraLocation = new Point3D(_0023_003DzNDQ_E88_003D[0, 3], _0023_003DzNDQ_E88_003D[1, 3], _0023_003DzNDQ_E88_003D[2, 3]);
		double num = (_0023_003DzNDQ_E88_003D[2, 3] = 0.0);
		double value = (_0023_003DzNDQ_E88_003D[1, 3] = num);
		_0023_003DzNDQ_E88_003D[0, 3] = value;
		_0023_003DzNDQ_E88_003D[3, 3] = 1.0;
		_0023_003DzeucN51LQK0q4();
		Point3D point3D = new Point3D(0.0 - cameraDistance, 0.0, 0.0);
		Point3D point3D2 = new Point3D(0.0 - cameraDistance, 0.0, cameraDistance);
		point3D = _0023_003DzNDQ_E88_003D * point3D;
		point3D2 = _0023_003DzNDQ_E88_003D * point3D2;
		cameraTarget = cameraLocation + point3D;
		Vector3D vector3D = Vector3D.Subtract(point3D2, point3D);
		vector3D.Normalize();
		upVector = vector3D;
	}

	private bool _0023_003DzK2DXpELaQxbE()
	{
		return Target != DefaultTarget;
	}

	internal void _0023_003DzAv1jivQ_003D()
	{
		Target = DefaultTarget;
	}

	public void UpdateLocation()
	{
		Transformation transformation = _0023_003DzMJBp3SIZOfgg(Rotation);
		_0023_003DzeucN51LQK0q4();
		Point3D point3D = new Point3D(cameraDistance, 0.0, 0.0);
		Point3D point3D2 = new Point3D(cameraDistance, 0.0, cameraDistance);
		point3D = transformation * point3D;
		point3D2 = transformation * point3D2;
		cameraLocation = cameraTarget + point3D;
		Vector3D vector3D = Vector3D.Subtract(point3D2, point3D);
		vector3D.Normalize();
		upVector = vector3D;
	}

	internal static Transformation _0023_003DzMJBp3SIZOfgg(Quaternion _0023_003DzVvkLpZU_003D)
	{
		_0023_003DzVvkLpZU_003D.ToMatrixInverse(out var matrix);
		return new Transformation(matrix);
	}

	private bool _0023_003DzaUHffTwTnUXk()
	{
		return Distance != _0023_003DzQ5_0024XO8WebAKY();
	}

	internal void _0023_003DzkLUB3P8ZzWfk()
	{
		Distance = _0023_003DzQ5_0024XO8WebAKY();
	}

	private void _0023_003DzeucN51LQK0q4()
	{
		if (cameraDistance < Utility._0023_003DzxhnLabVjXjPg)
		{
			cameraDistance = Utility._0023_003DzxhnLabVjXjPg;
		}
	}

	private static double _0023_003Dz7XDBwpU_003D(Point3D _0023_003Dzzo8RvXc_003D, Point3D _0023_003DzCGTSeY0_003D)
	{
		return Vector3D.Subtract(_0023_003DzCGTSeY0_003D, _0023_003Dzzo8RvXc_003D).Length;
	}

	private bool _0023_003DzlHuzxwv2VD06()
	{
		return Rotation != DefaultRotation;
	}

	internal void _0023_003Dzi8CrIfvCvR4_0024()
	{
		Rotation = DefaultRotation;
	}

	public static Quaternion GetViewRotation(viewType view)
	{
		Quaternion result = null;
		switch (view)
		{
		case viewType.Front:
			result = new Quaternion(Vector3D.AxisZ, 90.0);
			break;
		case viewType.Rear:
			result = new Quaternion(Vector3D.AxisZ, -90.0);
			break;
		case viewType.Right:
			result = new Quaternion(Vector3D.AxisZ, 0.0);
			break;
		case viewType.Left:
			result = new Quaternion(Vector3D.AxisZ, 180.0);
			break;
		case viewType.Top:
			result = new Quaternion(Vector3D.AxisZ, 90.0) * new Quaternion(Vector3D.AxisY, 90.0);
			break;
		case viewType.Bottom:
			result = new Quaternion(Vector3D.AxisZ, 90.0) * new Quaternion(Vector3D.AxisY, -90.0);
			break;
		case viewType.Isometric:
		case viewType.vcFrontFaceTopRight:
			result = new Quaternion(Vector3D.AxisZ, 45.0) * new Quaternion(Vector3D.AxisY, 45.0);
			break;
		case viewType.Dimetric:
			result = new Quaternion(Vector3D.AxisZ, 45.0) * new Quaternion(Vector3D.AxisY, 30.0);
			break;
		case viewType.Trimetric:
			result = new Quaternion(Vector3D.AxisZ, 60.0) * new Quaternion(Vector3D.AxisY, 30.0);
			break;
		case viewType.vcFrontFaceBottom:
		case viewType.vcBottomFaceTop:
			result = new Quaternion(Vector3D.AxisZ, 90.0) * new Quaternion(Vector3D.AxisY, -45.0);
			break;
		case viewType.vcFrontFaceRight:
		case viewType.vcRightFaceLeft:
			result = new Quaternion(Vector3D.AxisZ, 45.0);
			break;
		case viewType.vcFrontFaceTop:
		case viewType.vcTopFaceBottom:
			result = new Quaternion(Vector3D.AxisZ, 90.0) * new Quaternion(Vector3D.AxisY, 45.0);
			break;
		case viewType.vcFrontFaceLeft:
		case viewType.vcLeftFaceRight:
			result = new Quaternion(Vector3D.AxisZ, 135.0);
			break;
		case viewType.vcRightFaceBottom:
		case viewType.vcBottomFaceRight:
			result = new Quaternion(Vector3D.AxisY, -45.0);
			break;
		case viewType.vcRightFaceRight:
		case viewType.vcBackFaceLeft:
			result = new Quaternion(Vector3D.AxisZ, -45.0);
			break;
		case viewType.vcRightFaceTop:
		case viewType.vcTopFaceRight:
			result = new Quaternion(Vector3D.AxisY, 45.0);
			break;
		case viewType.vcBackFaceBottom:
		case viewType.vcBottomFaceBottom:
			result = new Quaternion(Vector3D.AxisZ, -90.0) * new Quaternion(Vector3D.AxisY, -45.0);
			break;
		case viewType.vcBackFaceRight:
		case viewType.vcLeftFaceLeft:
			result = new Quaternion(Vector3D.AxisZ, -135.0);
			break;
		case viewType.vcBackFaceTop:
		case viewType.vcTopFaceTop:
			result = new Quaternion(Vector3D.AxisZ, -90.0) * new Quaternion(Vector3D.AxisY, 45.0);
			break;
		case viewType.vcLeftFaceBottom:
		case viewType.vcBottomFaceLeft:
			result = new Quaternion(Vector3D.AxisZ, 180.0) * new Quaternion(Vector3D.AxisY, -45.0);
			break;
		case viewType.vcLeftFaceTop:
		case viewType.vcTopFaceLeft:
			result = new Quaternion(Vector3D.AxisZ, 180.0) * new Quaternion(Vector3D.AxisY, 45.0);
			break;
		case viewType.vcFrontFaceBottomLeft:
			result = new Quaternion(Vector3D.AxisZ, 135.0) * new Quaternion(Vector3D.AxisY, -45.0);
			break;
		case viewType.vcFrontFaceBottomRight:
			result = new Quaternion(Vector3D.AxisZ, 45.0) * new Quaternion(Vector3D.AxisY, -45.0);
			break;
		case viewType.vcFrontFaceTopLeft:
			result = new Quaternion(Vector3D.AxisZ, 135.0) * new Quaternion(Vector3D.AxisY, 45.0);
			break;
		case viewType.vcBackFaceBottomLeft:
			result = new Quaternion(Vector3D.AxisZ, -45.0) * new Quaternion(Vector3D.AxisY, -45.0);
			break;
		case viewType.vcBackFaceBottomRight:
			result = new Quaternion(Vector3D.AxisZ, -135.0) * new Quaternion(Vector3D.AxisY, -45.0);
			break;
		case viewType.vcBackFaceTopLeft:
			result = new Quaternion(Vector3D.AxisZ, -45.0) * new Quaternion(Vector3D.AxisY, 45.0);
			break;
		case viewType.vcBackFaceTopRight:
			result = new Quaternion(Vector3D.AxisZ, -135.0) * new Quaternion(Vector3D.AxisY, 45.0);
			break;
		}
		return result;
	}

	private void _0023_003DzOVvv6lKlxgS7(projectionType _0023_003DzPzO_0024GUk_003D)
	{
		if (cameraProjection == _0023_003DzPzO_0024GUk_003D)
		{
			return;
		}
		if (Size.Width <= 0 || Size.Height <= 0)
		{
			cameraProjection = _0023_003DzPzO_0024GUk_003D;
		}
		else
		{
			SetupModelView(setGraphics: false, reflection: false, CameraEyePosType.Center, applySceneTransformation: true);
			bool flag = false;
			Point3D _0023_003DzFj_0024IqDQ_003D = null;
			Point3D _0023_003DzjdeMMkk_003D = null;
			if (renderContext != null)
			{
				if (ZBufferData.IsInvalidRange)
				{
					ReadViewportZBufferRange(System.Drawing.Point.Empty, _0023_003Dzu_0024kNbQmDeTS6: true, 0, 0, 0, 0);
				}
				int[] array = new int[4] { viewportPosition.X, viewportPosition.Y, Size.Width, Size.Height };
				flag = UnProject(renderContext, array, ModelViewMatrix, ProjectionMatrix, viewportPosition.X, viewportPosition.Y, ZBufferData.Min, out var objx, out var objy, out var objz);
				if (flag)
				{
					_0023_003DzFj_0024IqDQ_003D = new Point3D(objx, objy, objz);
					flag = UnProject(renderContext, array, ModelViewMatrix, ProjectionMatrix, viewportPosition.X + array[2], viewportPosition.Y + array[3], ZBufferData.Min, out objx, out objy, out objz);
					_0023_003DzjdeMMkk_003D = new Point3D(objx, objy, objz);
				}
			}
			cameraProjection = _0023_003DzPzO_0024GUk_003D;
			if (flag)
			{
				AdjustNearAndFarPlanes();
				_0023_003Dz8Ya24fp2yNgMGTZ9WA_003D_003D(_0023_003DzFj_0024IqDQ_003D, _0023_003DzjdeMMkk_003D);
				InvalidateZRange(_0023_003DzGk93_rs_003D: true);
			}
		}
		OnPropertyChanged(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952031));
	}

	private bool _0023_003Dz3n2DEZE4HCZa0rD7XQ_003D_003D()
	{
		return ProjectionMode != DefaultProjectionMode;
	}

	internal void _0023_003Dza89fv_j6tBVe()
	{
		ProjectionMode = DefaultProjectionMode;
	}

	public double GetFocalLengthFromFieldOfView(double fovInDegrees)
	{
		return GetFocalLengthFromFieldOfView(fovInDegrees, _frame);
	}

	public static double GetFocalLengthFromFieldOfView(double fovInDegrees, Size2D frame)
	{
		return frame.Y / (2.0 * Math.Tan(Utility.DegToRad(fovInDegrees) / 2.0));
	}

	private bool _0023_003DzAYY1tM9C2_0024T_0024QvO3Ig_003D_003D()
	{
		return FocalLength != _0023_003Dz8xUWTAWsNhyV0Yfo5w_003D_003D();
	}

	internal void _0023_003DzUyFA7Wa1ZSVH_3H_0024_0024A_003D_003D()
	{
		FocalLength = _0023_003Dz8xUWTAWsNhyV0Yfo5w_003D_003D();
	}

	private bool _0023_003DzycZLSBq8dPNcouxyLQ_003D_003D()
	{
		return ZoomFactor != _0023_003DzEYTZmPWO5T_p();
	}

	internal void _0023_003DzZ7aerJLYnmW2()
	{
		ZoomFactor = _0023_003DzEYTZmPWO5T_p();
	}

	public virtual object Clone()
	{
		return new Camera(this);
	}

	public virtual CameraSurrogate ConvertToSurrogate()
	{
		return new CameraSurrogate(this);
	}

	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952439), Target);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952422), Distance);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952403), Rotation);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952388), InitialRotation);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952378), ProjectionMode);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952365), FocalLength);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952351), ZoomFactor);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952050), Anaglyph3D);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952033), NearPlaneDistanceFactor);
	}

	private static bool _0023_003DzY1rsjShKmMY1mdnDabW967s_003D()
	{
		return false;
	}

	private bool _0023_003Dzop46L1Myy3fwDTbr611tcCU_003D()
	{
		return Anaglyph3D != _0023_003DzY1rsjShKmMY1mdnDabW967s_003D();
	}

	internal void _0023_003DzMspkmSTu6XSouP7xX3FRiF4_003D()
	{
		Anaglyph3D = _0023_003DzY1rsjShKmMY1mdnDabW967s_003D();
	}

	internal void SetupProjection(RectangleF _0023_003DzAYwrzrbXfjgs, bool _0023_003DzbwFGvuI_003D, bool _0023_003Dz5a0lNBR9CWFl, bool _0023_003Dz_OlmZyU_003D, CameraEyePosType _0023_003Dz63YjliBDHRRn8w_jSg_003D_003D, bool _0023_003DzmvwblSEbZYXW4_0024RyrjXdV8s_003D = true)
	{
		if (_0023_003DzbwFGvuI_003D)
		{
			ResetProjectionMatrixStack();
		}
		RecomputeProjection(renderContext, Size, _0023_003DzAYwrzrbXfjgs, _0023_003Dz5a0lNBR9CWFl, _0023_003Dz_OlmZyU_003D, _0023_003Dz63YjliBDHRRn8w_jSg_003D_003D);
	}

	internal void RecomputeProjection(RenderContextBase _0023_003DzB8iS0QA_003D, Size _0023_003Dz14lzA48_003D, RectangleF _0023_003DzAYwrzrbXfjgs, bool _0023_003Dz5a0lNBR9CWFl, bool _0023_003Dz_OlmZyU_003D, CameraEyePosType _0023_003Dz63YjliBDHRRn8w_jSg_003D_003D)
	{
		if (!_0023_003DzAYwrzrbXfjgs.IsEmpty)
		{
			pickMatrix = _0023_003DzB8iS0QA_003D.ComputePickMatrix(_0023_003DzAYwrzrbXfjgs, new Size(_0023_003Dz14lzA48_003D.Width, _0023_003Dz14lzA48_003D.Height), new int[4] { 0, 0, _0023_003Dz14lzA48_003D.Width, _0023_003Dz14lzA48_003D.Height });
			Array.Copy(pickMatrix, ProjectionMatrix, 16);
		}
		else
		{
			pickMatrix = null;
			Array.Clear(ProjectionMatrix, 0, ProjectionMatrix.Length);
			ProjectionMatrix[0] = (ProjectionMatrix[5] = (ProjectionMatrix[10] = (ProjectionMatrix[15] = 1.0)));
		}
		if (_0023_003Dz_OlmZyU_003D)
		{
			ProjectionMatrix[0] *= -1.0;
		}
		_0023_003Dzxw_0024o022k6AD1 = new double[16];
		double offsetForSelection = GetOffsetForSelection();
		double num = LimitNearFor3DAnaglyph(cameraNear);
		double _0023_003DzrsIMbGNqFfcN = num + offsetForSelection;
		double _0023_003DztRtwu_0024oM_KUi = cameraFar + offsetForSelection;
		Array.Copy(ProjectionMatrix, _0023_003Dzxw_0024o022k6AD1, ProjectionMatrix.Length);
		ProjectionMatrix = _0023_003Dzyk_0024NoJO1lOn4(ProjectionMatrix, num, cameraFar, _0023_003Dz63YjliBDHRRn8w_jSg_003D_003D);
		if (useProjectionMatrixForSelected)
		{
			_0023_003Dzxw_0024o022k6AD1 = _0023_003Dzyk_0024NoJO1lOn4(_0023_003Dzxw_0024o022k6AD1, _0023_003DzrsIMbGNqFfcN, _0023_003DztRtwu_0024oM_KUi, _0023_003Dz63YjliBDHRRn8w_jSg_003D_003D);
		}
		else
		{
			_0023_003Dzxw_0024o022k6AD1 = ProjectionMatrix;
		}
	}

	protected internal virtual double GetOffsetForSelection()
	{
		if (cameraProjection == projectionType.Orthographic)
		{
			return 0.001 * (_0023_003DznYtQKck_003D - _0023_003DzeMBeuAQ_003D);
		}
		return Math.Abs((useNearOfFirstShadowSplitForSelected ? nearOfFirstShadowSplitForSelected : cameraNear) / 1000.0);
	}

	internal double LimitNearFor3DAnaglyph(double _0023_003DzrsIMbGNqFfcN)
	{
		if (Anaglyph3D && ProjectionMode == projectionType.Perspective)
		{
			return Math.Max(_0023_003DzrsIMbGNqFfcN, convergenceDistance / 2.0);
		}
		return _0023_003DzrsIMbGNqFfcN;
	}

	internal void GetProjMatricesOutsideRange(bool _0023_003Dz00TfZlw_003D, double _0023_003DzRh5eVqa9nIDP, double _0023_003DzxTpRcoYSAt8D, CameraEyePosType _0023_003Dz63YjliBDHRRn8w_jSg_003D_003D, out double[] _0023_003Dzr35_4FKIK79GtiNQAg_003D_003D, out double[] _0023_003DzOYVoAw2teIxFntsYNg_003D_003D)
	{
		if (_0023_003Dz00TfZlw_003D)
		{
			_0023_003Dzr35_4FKIK79GtiNQAg_003D_003D = GetProjectionMatrix(_0023_003DzRh5eVqa9nIDP, _0023_003DzxTpRcoYSAt8D, _0023_003Dz63YjliBDHRRn8w_jSg_003D_003D);
			_0023_003DzOYVoAw2teIxFntsYNg_003D_003D = null;
			return;
		}
		if (_0023_003DzRh5eVqa9nIDP < cameraNear)
		{
			if (_0023_003DzxTpRcoYSAt8D < cameraNear)
			{
				_0023_003Dzr35_4FKIK79GtiNQAg_003D_003D = GetProjectionMatrix(_0023_003DzRh5eVqa9nIDP, _0023_003DzxTpRcoYSAt8D, _0023_003Dz63YjliBDHRRn8w_jSg_003D_003D);
			}
			else
			{
				_0023_003Dzr35_4FKIK79GtiNQAg_003D_003D = GetProjectionMatrix(_0023_003DzRh5eVqa9nIDP, cameraNear, _0023_003Dz63YjliBDHRRn8w_jSg_003D_003D);
			}
		}
		else
		{
			_0023_003Dzr35_4FKIK79GtiNQAg_003D_003D = null;
		}
		if (_0023_003DzxTpRcoYSAt8D > cameraFar)
		{
			if (_0023_003DzRh5eVqa9nIDP > cameraFar)
			{
				_0023_003DzOYVoAw2teIxFntsYNg_003D_003D = GetProjectionMatrix(_0023_003DzRh5eVqa9nIDP, _0023_003DzxTpRcoYSAt8D, _0023_003Dz63YjliBDHRRn8w_jSg_003D_003D);
			}
			else
			{
				_0023_003DzOYVoAw2teIxFntsYNg_003D_003D = GetProjectionMatrix(cameraFar, _0023_003DzxTpRcoYSAt8D, _0023_003Dz63YjliBDHRRn8w_jSg_003D_003D);
			}
		}
		else
		{
			_0023_003DzOYVoAw2teIxFntsYNg_003D_003D = null;
		}
	}

	internal static double[] ApplyPickMatrix(double[] _0023_003DzmIVCYKprCbgF, double[] _0023_003DzwTc0B2NdlyUi)
	{
		return Utility.MultMatrixd(_0023_003DzwTc0B2NdlyUi, _0023_003DzmIVCYKprCbgF);
	}

	internal static Transformation ApplyPickMatrix(Transformation _0023_003DzmIVCYKprCbgF, Transformation _0023_003DzwTc0B2NdlyUi)
	{
		return _0023_003DzmIVCYKprCbgF * _0023_003DzwTc0B2NdlyUi;
	}

	internal double[] _0023_003Dzyk_0024NoJO1lOn4(double[] _0023_003DzmIVCYKprCbgF, double _0023_003DzrsIMbGNqFfcN, double _0023_003DztRtwu_0024oM_KUi, CameraEyePosType _0023_003Dz63YjliBDHRRn8w_jSg_003D_003D)
	{
		double[] projectionMatrix = GetProjectionMatrix(_0023_003DzrsIMbGNqFfcN, _0023_003DztRtwu_0024oM_KUi, _0023_003Dz63YjliBDHRRn8w_jSg_003D_003D);
		if (projectionMatrix != null)
		{
			return ApplyPickMatrix(_0023_003DzmIVCYKprCbgF, projectionMatrix);
		}
		return _0023_003DzmIVCYKprCbgF;
	}

	protected internal virtual double[] GetProjectionMatrix(double nearDistance, double farDistance, CameraEyePosType cameraEyePos)
	{
		if (cameraProjection == projectionType.Perspective)
		{
			double num = Math.Tan(Utility.DegToRad(AngleOfView) / 2.0) * nearDistance;
			double num2 = _0023_003DzCzIe62JVg98L * num;
			return cameraEyePos switch
			{
				CameraEyePosType.Left => _0023_003Dzjm6XktxtETBnUOck3A_003D_003D(nearDistance, farDistance), 
				CameraEyePosType.Right => _0023_003DzQ8xcAQ0VkIulbAR_fA_003D_003D(nearDistance, farDistance), 
				_ => _0023_003DzlzzycDbFSCnCiv8UTQ_003D_003D(0.0 - num2, num2, 0.0 - num, num, nearDistance, farDistance), 
			};
		}
		return myOrtho(renderContext, _0023_003DzeMBeuAQ_003D, _0023_003DznYtQKck_003D, _0023_003Dz5F7_i_0024U_003D, _0023_003DzXmrDMdc_003D, nearDistance, farDistance);
	}

	protected internal virtual void SetupModelView(bool setGraphics, bool reflection, CameraEyePosType cameraEyePos, bool applySceneTransformation)
	{
		ModelViewMatrix = LookAt(Location, Target, upVector, reflection);
		Transformation transformation = null;
		switch (cameraEyePos)
		{
		case CameraEyePosType.Left:
			transformation = new Translation(_0023_003DzLqukFvnP2fqm() / 2.0, 0.0);
			break;
		case CameraEyePosType.Right:
			transformation = new Translation((0.0 - _0023_003DzLqukFvnP2fqm()) / 2.0, 0.0);
			break;
		}
		if (transformation != null)
		{
			ModelViewMatrix = Utility.MultMatrixd(ModelViewMatrix, transformation.MatrixAsVectorByColumn);
		}
		if (setGraphics && renderContext != null)
		{
			renderContext.SetModelView(this);
			if (applySceneTransformation)
			{
				ApplySceneTransformation();
			}
		}
	}

	internal void ApplySceneTransformation()
	{
		if (sceneTransformation != null)
		{
			renderContext.MultMatrixModelView(sceneTransformation.MatrixAsVectorByColumn);
		}
	}

	protected internal virtual void SetupModelViewProjection(RectangleF zoomRect, bool setGraphics, bool shadowPass, bool reflection, CameraEyePosType cameraEyePos, bool applySceneTransformation)
	{
		SetupProjection(zoomRect, setGraphics, shadowPass, reflection, cameraEyePos, _0023_003DzmvwblSEbZYXW4_0024RyrjXdV8s_003D: false);
		SetupModelView(setGraphics, reflection, cameraEyePos, applySceneTransformation);
	}

	private void _0023_003DzxGN9mFbaPHMG(int[] _0023_003DzqDFBISpCePlj, System.Drawing.Point _0023_003DzFNDApuVLTtJd, out Segment3D _0023_003Dz_0024kyShSmlOifS)
	{
		_0023_003Dz_0024kyShSmlOifS = new Segment3D();
		UnProject(renderContext, _0023_003DzqDFBISpCePlj, ModelViewMatrix, ProjectionMatrix, _0023_003DzFNDApuVLTtJd.X, _0023_003DzFNDApuVLTtJd.Y, 0.0, out var objx, out var objy, out var objz);
		_0023_003Dz_0024kyShSmlOifS.P0.X = objx;
		_0023_003Dz_0024kyShSmlOifS.P0.Y = objy;
		_0023_003Dz_0024kyShSmlOifS.P0.Z = objz;
		UnProject(renderContext, _0023_003DzqDFBISpCePlj, ModelViewMatrix, ProjectionMatrix, _0023_003DzFNDApuVLTtJd.X, _0023_003DzFNDApuVLTtJd.Y, 1.0, out objx, out objy, out objz);
		_0023_003Dz_0024kyShSmlOifS.P1.X = objx;
		_0023_003Dz_0024kyShSmlOifS.P1.Y = objy;
		_0023_003Dz_0024kyShSmlOifS.P1.Z = objz;
	}

	internal PlaneEquation[] GetFrustum(int[] _0023_003DzqDFBISpCePlj, bool _0023_003Dz_OlmZyU_003D)
	{
		Segment3D _0023_003DzwSYRtiF9NfQV;
		Segment3D _0023_003Dz26JkE4mTgRSq;
		Segment3D _0023_003DzODmhfGke69CA;
		Segment3D _0023_003Dzr17r3fruk1Lg;
		return GetFrustum(_0023_003DzqDFBISpCePlj, _0023_003Dz_OlmZyU_003D, new System.Drawing.Point(_0023_003DzqDFBISpCePlj[0], _0023_003DzqDFBISpCePlj[1]), new System.Drawing.Point(_0023_003DzqDFBISpCePlj[0] + _0023_003DzqDFBISpCePlj[2], _0023_003DzqDFBISpCePlj[1] + _0023_003DzqDFBISpCePlj[3]), out _0023_003DzwSYRtiF9NfQV, out _0023_003Dz26JkE4mTgRSq, out _0023_003DzODmhfGke69CA, out _0023_003Dzr17r3fruk1Lg);
	}

	internal PlaneEquation[] GetFrustum(int[] _0023_003DzqDFBISpCePlj, bool _0023_003Dz_OlmZyU_003D, System.Drawing.Point _0023_003DzctILmi4BTxnP, System.Drawing.Point _0023_003Dz8CEpxh5dXoqe, out Segment3D _0023_003DzwSYRtiF9NfQV, out Segment3D _0023_003Dz26JkE4mTgRSq, out Segment3D _0023_003DzODmhfGke69CA, out Segment3D _0023_003Dzr17r3fruk1Lg)
	{
		_0023_003DzxGN9mFbaPHMG(_0023_003DzqDFBISpCePlj, _0023_003DzctILmi4BTxnP, out _0023_003DzwSYRtiF9NfQV);
		_0023_003DzxGN9mFbaPHMG(_0023_003DzqDFBISpCePlj, new System.Drawing.Point(_0023_003Dz8CEpxh5dXoqe.X, _0023_003DzctILmi4BTxnP.Y), out _0023_003Dz26JkE4mTgRSq);
		_0023_003DzxGN9mFbaPHMG(_0023_003DzqDFBISpCePlj, _0023_003Dz8CEpxh5dXoqe, out _0023_003DzODmhfGke69CA);
		_0023_003DzxGN9mFbaPHMG(_0023_003DzqDFBISpCePlj, new System.Drawing.Point(_0023_003DzctILmi4BTxnP.X, _0023_003Dz8CEpxh5dXoqe.Y), out _0023_003Dzr17r3fruk1Lg);
		Vector3D[] array = new Vector3D[12]
		{
			Vector3D.Subtract(_0023_003DzwSYRtiF9NfQV.P0, _0023_003Dz26JkE4mTgRSq.P0),
			Vector3D.Subtract(_0023_003DzODmhfGke69CA.P0, _0023_003Dz26JkE4mTgRSq.P0),
			Vector3D.Subtract(_0023_003DzODmhfGke69CA.P1, _0023_003DzODmhfGke69CA.P0),
			Vector3D.Subtract(_0023_003Dz26JkE4mTgRSq.P0, _0023_003DzODmhfGke69CA.P0),
			Vector3D.Subtract(_0023_003Dzr17r3fruk1Lg.P1, _0023_003Dzr17r3fruk1Lg.P0),
			Vector3D.Subtract(_0023_003DzODmhfGke69CA.P0, _0023_003Dzr17r3fruk1Lg.P0),
			Vector3D.Subtract(_0023_003DzwSYRtiF9NfQV.P1, _0023_003DzwSYRtiF9NfQV.P0),
			Vector3D.Subtract(_0023_003Dzr17r3fruk1Lg.P0, _0023_003DzwSYRtiF9NfQV.P0),
			Vector3D.Subtract(_0023_003Dz26JkE4mTgRSq.P1, _0023_003Dz26JkE4mTgRSq.P0),
			Vector3D.Subtract(_0023_003DzwSYRtiF9NfQV.P0, _0023_003Dz26JkE4mTgRSq.P0),
			Vector3D.Subtract(_0023_003Dz26JkE4mTgRSq.P1, _0023_003DzwSYRtiF9NfQV.P1),
			Vector3D.Subtract(_0023_003Dzr17r3fruk1Lg.P1, _0023_003DzwSYRtiF9NfQV.P1)
		};
		Point3D[] array2 = new Point3D[6] { _0023_003Dz26JkE4mTgRSq.P0, _0023_003DzODmhfGke69CA.P0, _0023_003Dzr17r3fruk1Lg.P0, _0023_003DzwSYRtiF9NfQV.P0, _0023_003Dz26JkE4mTgRSq.P0, _0023_003DzwSYRtiF9NfQV.P1 };
		PlaneEquation[] array3 = new PlaneEquation[6];
		double num = ((!_0023_003Dz_OlmZyU_003D) ? 1 : (-1));
		int num2 = 0;
		int num3 = 0;
		while (num3 < 12)
		{
			array[num3].Normalize();
			array[num3 + 1].Normalize();
			Vector3D vector3D = Vector3D.Cross(array[num3++], array[num3++]);
			array3[num2] = new PlaneEquation();
			if (!array3[num2].Create(array2[num2++], vector3D * num))
			{
				return null;
			}
		}
		return array3;
	}

	public static bool IsInFrustum(Point3D point, PlaneEquation[] frustum)
	{
		return _0023_003DzqtX29XBChOdOLdC8QQ_003D_003D(point.X, point.Y, point.Z, frustum);
	}

	internal static bool _0023_003DzqtX29XBChOdOLdC8QQ_003D_003D(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double _0023_003DzId5C3LA_003D, PlaneEquation[] _0023_003Dzxo6M8jQhcL2n)
	{
		for (int i = 0; i < 6; i++)
		{
			if (_0023_003Dzxo6M8jQhcL2n[i].ValueAt(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, _0023_003DzId5C3LA_003D) < 0.0)
			{
				return false;
			}
		}
		return true;
	}

	protected internal static double[] LookAt(Point3D eye, Point3D center, Vector3D up, bool reflection)
	{
		return LookAtInternal(eye, center, up);
	}

	internal double[] LookAtInternal(Point3D _0023_003DzJyPEWFA_003D, Point3D _0023_003DzbUvT9Pc_003D)
	{
		return LookAtInternal(_0023_003DzJyPEWFA_003D, _0023_003DzbUvT9Pc_003D, upVector);
	}

	internal static double[] LookAtInternal(Point3D _0023_003DzJyPEWFA_003D, Point3D _0023_003DzbUvT9Pc_003D, Vector3D _0023_003DzCBEAoWM_003D)
	{
		Vector3D vector3D = Vector3D.Subtract(_0023_003DzbUvT9Pc_003D, _0023_003DzJyPEWFA_003D);
		vector3D.Normalize();
		Vector3D vector3D2 = Vector3D.Cross(vector3D, _0023_003DzCBEAoWM_003D);
		vector3D2.Normalize();
		return LookAt(_0023_003DzJyPEWFA_003D, vector3D, vector3D2);
	}

	internal double[] GetModelViewCsIcon(double _0023_003DzXMGjKnoZdqec)
	{
		Vector3D vector3D = Vector3D.Subtract(cameraLocation, cameraTarget);
		vector3D.Normalize();
		return LookAt((vector3D * _0023_003DzXMGjKnoZdqec).AsPoint, Point3D.Origin, upVector, reflection: false);
	}

	internal bool UpdateBoundingBox(int[] _0023_003DzqDFBISpCePlj, IList<Entity> _0023_003DzWc9WmS8VMsuA, Document _0023_003DzoPlwCJA_003D, bool _0023_003Dz9rsu4TwhLBvn, bool _0023_003Dz9SYi5hYGMSW6 = false, bool _0023_003Dz63vxlPZEa6VZ = false)
	{
		if (ProjectionMatrix[0] == 0.0)
		{
			SetupModelViewProjection(RectangleF.Empty, setGraphics: true, shadowPass: false, reflection: false, CameraEyePosType.Center, applySceneTransformation: true);
		}
		bool _0023_003DzCpCzW0s6jJmE = true;
		Vector3D _0023_003DzzRaskB_00243uPOQ;
		Vector3D _0023_003DzoqgctgRhDmC;
		Vector3D _0023_003Dz_0024llOZEdbyJnQ;
		Transformation cameraTransform = GetCameraTransform(out _0023_003DzzRaskB_00243uPOQ, out _0023_003DzoqgctgRhDmC, out _0023_003Dz_0024llOZEdbyJnQ);
		projectedMin = Point3D.MaxValue;
		projectedMax = Point3D.MinValue;
		Segment3D _0023_003DzwSYRtiF9NfQV;
		Segment3D _0023_003Dz26JkE4mTgRSq;
		Segment3D _0023_003DzODmhfGke69CA;
		Segment3D _0023_003Dzr17r3fruk1Lg;
		PlaneEquation[] frustum = GetFrustum(_0023_003DzqDFBISpCePlj, _0023_003Dz_OlmZyU_003D: false, new System.Drawing.Point(0, 0), new System.Drawing.Point(_0023_003DzqDFBISpCePlj[2], _0023_003DzqDFBISpCePlj[3]), out _0023_003DzwSYRtiF9NfQV, out _0023_003Dz26JkE4mTgRSq, out _0023_003DzODmhfGke69CA, out _0023_003Dzr17r3fruk1Lg);
		bool result = true;
		IWorkspaceInternal workspace = _0023_003DzoPlwCJA_003D.workspace;
		BlockKeyedCollection _0023_003DzJO1FWlQ_003D = ((workspace != null) ? workspace.GetAllBlocks() : _0023_003DzoPlwCJA_003D.Blocks);
		TraversalParams _0023_003DzmPmPjCPqZ3T = new TraversalParams(_0023_003DzoPlwCJA_003D, _0023_003DzJO1FWlQ_003D, cameraTransform);
		if (frustum != null)
		{
			if (_0023_003Dz63vxlPZEa6VZ)
			{
				Utility.GetBoundingBoxTransformed((SceneTransformationInverted == null) ? cameraTransform : (cameraTransform * SceneTransformationInverted), workspace.BoundingBox.Min, workspace.BoundingBox.Max, out projectedMin, out projectedMax);
			}
			else
			{
				if (_0023_003DzWc9WmS8VMsuA.Count == 0)
				{
					return false;
				}
				if (_0023_003Dz9SYi5hYGMSW6)
				{
					projectedMin = Point3D.MaxValue;
					projectedMax = Point3D.MinValue;
					result = _0023_003DzstCymt1MOYthCmvcA9CRTph7zWPU(_0023_003DzWc9WmS8VMsuA, _0023_003DzmPmPjCPqZ3T, ref projectedMin, ref projectedMax, _0023_003DzoVfqyO97iKZrPd7qhw_003D_003D);
				}
				else
				{
					result = _0023_003Dz5vJTlfQfBy0gCAP37Q_003D_003D(_0023_003DzWc9WmS8VMsuA, _0023_003DzmPmPjCPqZ3T, _0023_003Dz9rsu4TwhLBvn, out projectedMin, out projectedMax, _0023_003DzoVfqyO97iKZrPd7qhw_003D_003D);
				}
			}
		}
		_0023_003DzAZz3Z5sTQkbSyQ3CxQ_003D_003D();
		ComputeCenterOfRotation(_0023_003DzCpCzW0s6jJmE, _0023_003DzzRaskB_00243uPOQ, _0023_003DzoqgctgRhDmC, _0023_003Dz_0024llOZEdbyJnQ);
		return result;
	}

	public void Fit(Size size, Document document, bool selectedOnly = false)
	{
		UpdateSize(size);
		RecomputeViewport(size);
		UpdateBoundingBox(GetViewFrame(new System.Drawing.Point(0, 0), size, size.Height), document.Entities, document, selectedOnly);
		Fit(size, 0);
		UpdateMatrices(_0023_003DzgEkZi75Aakl3: false);
	}

	internal static int[] GetViewFrame(System.Drawing.Point _0023_003DzCGTSeY0_003D, Size _0023_003Dz14lzA48_003D, int _0023_003Dzs3Tbbpix3oL8)
	{
		return new int[4]
		{
			_0023_003DzCGTSeY0_003D.X,
			_0023_003Dzs3Tbbpix3oL8 - _0023_003DzCGTSeY0_003D.Y - _0023_003Dz14lzA48_003D.Height,
			_0023_003Dz14lzA48_003D.Width,
			_0023_003Dz14lzA48_003D.Height
		};
	}

	private bool _0023_003Dz5vJTlfQfBy0gCAP37Q_003D_003D(IList<Entity> _0023_003DzWc9WmS8VMsuA, TraversalParams _0023_003DzmPmPjCPqZ3T3, bool _0023_003Dz9rsu4TwhLBvn, out Point3D _0023_003DzF7v9r2A_003D, out Point3D _0023_003Dz8dK2uhU_003D, _0023_003Dz748xQJjL2a1NqeVegg_003D_003D _0023_003Dz2DIevoITXJpN)
	{
		_0023_003DzF7v9r2A_003D = Point3D.MaxValue;
		_0023_003Dz8dK2uhU_003D = Point3D.MinValue;
		bool _0023_003DzRVoDPs0_003D = true;
		if (_0023_003DzWc9WmS8VMsuA.Count == 1 && _0023_003DzWc9WmS8VMsuA[0] is BlockReference blockReference && blockReference.BlockName == _0023_003DzmPmPjCPqZ3T3.Document.OpenBlock.Name)
		{
			_0023_003Dz2DIevoITXJpN(blockReference, _0023_003DzmPmPjCPqZ3T3, ref _0023_003DzRVoDPs0_003D, ref _0023_003DzF7v9r2A_003D, ref _0023_003Dz8dK2uhU_003D);
		}
		else
		{
			if (_0023_003DzmPmPjCPqZ3T3.Workspace != null)
			{
				_0023_003DzmPmPjCPqZ3T3.Parents = new Stack<BlockReference>(_0023_003DzmPmPjCPqZ3T3.workspaceInternal.Parents.Reverse());
			}
			else
			{
				_0023_003DzmPmPjCPqZ3T3.Parents = new Stack<BlockReference>();
			}
			foreach (Entity item in _0023_003DzWc9WmS8VMsuA)
			{
				if (item.IsVisible(_0023_003DzmPmPjCPqZ3T3.Parents, _0023_003DzmPmPjCPqZ3T3.Document.Layers, _0023_003DzmPmPjCPqZ3T3.Document.AttributeReferenceVisibilityMode) && (!_0023_003Dz9rsu4TwhLBvn || item.Selected))
				{
					_0023_003Dz2DIevoITXJpN(item, _0023_003DzmPmPjCPqZ3T3, ref _0023_003DzRVoDPs0_003D, ref _0023_003DzF7v9r2A_003D, ref _0023_003Dz8dK2uhU_003D);
				}
			}
		}
		return !_0023_003DzRVoDPs0_003D;
	}

	private bool _0023_003DzstCymt1MOYthCmvcA9CRTph7zWPU(IList<Entity> _0023_003DzWc9WmS8VMsuA, TraversalParams _0023_003DzmPmPjCPqZ3T3, ref Point3D _0023_003DzF7v9r2A_003D, ref Point3D _0023_003Dz8dK2uhU_003D, _0023_003Dz748xQJjL2a1NqeVegg_003D_003D _0023_003Dz2DIevoITXJpN)
	{
		bool _0023_003DzRVoDPs0_003D = true;
		_0023_003DzGkDJ2go9f9n4t3zmApMZCOHyOFCb(_0023_003DzWc9WmS8VMsuA, _0023_003DzmPmPjCPqZ3T3, ref _0023_003DzRVoDPs0_003D, ref _0023_003DzF7v9r2A_003D, ref _0023_003Dz8dK2uhU_003D, _0023_003Dz2DIevoITXJpN);
		return !_0023_003DzRVoDPs0_003D;
	}

	private void _0023_003DzGkDJ2go9f9n4t3zmApMZCOHyOFCb(IList<Entity> _0023_003DzWc9WmS8VMsuA, TraversalParams _0023_003DzmPmPjCPqZ3T3, ref bool _0023_003DzRVoDPs0_003D, ref Point3D _0023_003DzF7v9r2A_003D, ref Point3D _0023_003Dz8dK2uhU_003D, _0023_003Dz748xQJjL2a1NqeVegg_003D_003D _0023_003Dz2DIevoITXJpN)
	{
		int count = _0023_003DzWc9WmS8VMsuA.Count;
		List<BlockReference> list = _0023_003DzmPmPjCPqZ3T3.Parents.Reverse().ToList();
		if (_0023_003DzmPmPjCPqZ3T3.Workspace != null)
		{
			foreach (BlockReference parent in _0023_003DzmPmPjCPqZ3T3.workspaceInternal.Parents)
			{
				list.Add(parent);
			}
		}
		Stack<BlockReference> parents = new Stack<BlockReference>(list);
		for (int i = 0; i < count; i++)
		{
			Entity entity = _0023_003DzWc9WmS8VMsuA[i];
			if (entity.IsVisible(parents, _0023_003DzmPmPjCPqZ3T3.Document.Layers, _0023_003DzmPmPjCPqZ3T3.Document.AttributeReferenceVisibilityMode))
			{
				if (entity.IsSelected(_0023_003DzmPmPjCPqZ3T3.Parents, selectionStatusType.Permanent))
				{
					_0023_003Dz2DIevoITXJpN(entity, _0023_003DzmPmPjCPqZ3T3, ref _0023_003DzRVoDPs0_003D, ref _0023_003DzF7v9r2A_003D, ref _0023_003Dz8dK2uhU_003D);
				}
				else if (entity is BlockReference)
				{
					BlockReference blockReference = (BlockReference)entity;
					_0023_003DzmPmPjCPqZ3T3.PushTransformation(blockReference);
					_0023_003DzmPmPjCPqZ3T3.Parents.Push(blockReference);
					_0023_003DzGkDJ2go9f9n4t3zmApMZCOHyOFCb(_0023_003DzmPmPjCPqZ3T3.Blocks[blockReference.BlockName].Entities, _0023_003DzmPmPjCPqZ3T3, ref _0023_003DzRVoDPs0_003D, ref _0023_003DzF7v9r2A_003D, ref _0023_003Dz8dK2uhU_003D, _0023_003Dz2DIevoITXJpN);
					_0023_003DzmPmPjCPqZ3T3.Parents.Pop();
					_0023_003DzmPmPjCPqZ3T3.PopTransformation();
				}
			}
		}
	}

	private void _0023_003DzoVfqyO97iKZrPd7qhw_003D_003D(Entity _0023_003Dzs_0024uS8LA_003D, TraversalParams _0023_003DzmPmPjCPqZ3T3, ref bool _0023_003DzRVoDPs0_003D, ref Point3D _0023_003DzF7v9r2A_003D, ref Point3D _0023_003Dz8dK2uhU_003D)
	{
		Point3D boxMin = null;
		Point3D boxMax = null;
		try
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = _0023_003DzmPmPjCPqZ3T3.Document != null && _0023_003DzmPmPjCPqZ3T3.Workspace != null && _0023_003DzmPmPjCPqZ3T3.workspaceInternal.ZoomFitMode != zoomFitType.Standard;
			if (flag3 && !ParallelConveHull.Instance.IsBusy())
			{
				flag2 = _0023_003Dzs_0024uS8LA_003D.GetAllVertices(_0023_003DzmPmPjCPqZ3T3, out var verticesCoords);
				if (flag2)
				{
					flag = verticesCoords.Count > 0;
					Utility.ComputeBoundingBox(_0023_003DzmPmPjCPqZ3T3.Transformation ?? new Identity(), verticesCoords.ToArray(), verticesCoords.Count, 0, out boxMin, out boxMax);
				}
			}
			if (!flag2)
			{
				flag = _0023_003Dzs_0024uS8LA_003D.ComputeBoundingBox(_0023_003DzmPmPjCPqZ3T3, out boxMin, out boxMax);
				if (flag3)
				{
					ParallelConveHull.Instance.CreateAndStart(_0023_003DzmPmPjCPqZ3T3.workspaceInternal);
				}
			}
			if (flag && boxMin.X <= boxMax.X)
			{
				_0023_003DzNKw2dpKrk09r(boxMin, boxMax, ref _0023_003DzRVoDPs0_003D, ref _0023_003DzF7v9r2A_003D, ref _0023_003Dz8dK2uhU_003D);
			}
		}
		catch (OutOfMemoryException)
		{
			_0023_003DzF7v9r2A_003D.X = double.MaxValue;
		}
	}

	private static void _0023_003DzNKw2dpKrk09r(Point3D _0023_003DzyrHfuju0o3_L, Point3D _0023_003DzzPN6WvHAJnos, ref bool _0023_003DzRVoDPs0_003D, ref Point3D _0023_003DzF7v9r2A_003D, ref Point3D _0023_003Dz8dK2uhU_003D)
	{
		if (_0023_003DzRVoDPs0_003D)
		{
			_0023_003DzRVoDPs0_003D = false;
			Utility.InitializeMinMax(_0023_003DzyrHfuju0o3_L, out _0023_003DzF7v9r2A_003D, out _0023_003Dz8dK2uhU_003D);
			Utility.UpdateMinMaxQuick(_0023_003DzzPN6WvHAJnos, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
		}
		else
		{
			Utility.UpdateMinMaxQuick(_0023_003DzyrHfuju0o3_L, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
			Utility.UpdateMinMaxQuick(_0023_003DzzPN6WvHAJnos, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
		}
	}

	private void _0023_003Dz8hGMhbRxuOwGnC7V0BDbS6E_003D(Entity _0023_003Dzs_0024uS8LA_003D, LayerKeyedCollection _0023_003DzeWJg3NJnk3WA, Transformation _0023_003Dzf_0024yJxyRwqHOdWAuO45jQ3Cw_003D, ref bool _0023_003DzRVoDPs0_003D, ref Point3D _0023_003DzF7v9r2A_003D, ref Point3D _0023_003Dz8dK2uhU_003D)
	{
		if (_0023_003Dzs_0024uS8LA_003D.BoxMin != _0023_003DzF7v9r2A_003D && _0023_003Dzs_0024uS8LA_003D.BoxMax != _0023_003Dz8dK2uhU_003D)
		{
			_0023_003DzNKw2dpKrk09r(_0023_003Dzs_0024uS8LA_003D.BoxMin, _0023_003Dzs_0024uS8LA_003D.BoxMax, ref _0023_003DzRVoDPs0_003D, ref _0023_003DzF7v9r2A_003D, ref _0023_003Dz8dK2uhU_003D);
		}
	}

	internal void ComputeCenterOfRotation(bool _0023_003DzCpCzW0s6jJmE, Vector3D _0023_003DzzRaskB_00243uPOQ, Vector3D _0023_003DzoqgctgRhDmC7, Vector3D _0023_003Dz_0024llOZEdbyJnQ)
	{
		double num = projectedMax.X - projectedMin.X;
		double num2 = projectedMax.Z - projectedMin.Z;
		double num3 = projectedMax.Y - projectedMin.Y;
		if (projectedMin.X != double.MaxValue)
		{
			Point3D point3D = new Point3D();
			point3D.X = projectedMin.X + num / 2.0;
			point3D.Y = projectedMin.Y + num3 / 2.0;
			if (_0023_003DzCpCzW0s6jJmE)
			{
				point3D.Z = projectedMax.Z - num2 / 2.0;
			}
			else if (num2 == 0.0)
			{
				point3D.Z = projectedMax.Z;
			}
			else
			{
				point3D.Z = 0.0 - _0023_003DzIfym_0024Gw_003D(0.0 - projectedMax.Z, 0.0 - projectedMin.Z, 0.5, cameraProjection);
			}
			centerOfRotation = cameraLocation + _0023_003DzzRaskB_00243uPOQ * point3D.X + _0023_003DzoqgctgRhDmC7 * point3D.Y + _0023_003Dz_0024llOZEdbyJnQ * point3D.Z;
		}
	}

	internal Transformation GetCameraTransform(out Vector3D _0023_003DzzRaskB_00243uPOQ, out Vector3D _0023_003DzoqgctgRhDmC7, out Vector3D _0023_003Dz_0024llOZEdbyJnQ, bool _0023_003Dz8_0BNKGtqVk_0024 = true)
	{
		GetFrame(out var origin, out _0023_003DzzRaskB_00243uPOQ, out _0023_003DzoqgctgRhDmC7, out _0023_003Dz_0024llOZEdbyJnQ);
		Plane plane = new Plane(origin, _0023_003DzzRaskB_00243uPOQ, _0023_003DzoqgctgRhDmC7);
		Plane xY = Plane.XY;
		Transformation transformation = new Transformation();
		transformation.Rotation(plane.Origin, plane.AxisX, plane.AxisY, plane.AxisZ, xY.Origin, xY.AxisX, xY.AxisY, xY.AxisZ);
		if (_0023_003Dz8_0BNKGtqVk_0024 && sceneTransformation != null)
		{
			transformation *= sceneTransformation;
		}
		return transformation;
	}

	internal void AdjustPerspectiveFit(IList<Entity> _0023_003Dzv7xH9gk_003D, IWorkspaceInternal _0023_003DzImQx0os_003D, bool _0023_003Dz9rsu4TwhLBvn, int _0023_003DzjqihOlA_003D, bool _0023_003Dz9SYi5hYGMSW6)
	{
		if (cameraProjection == projectionType.Orthographic)
		{
			return;
		}
		UpdateMatrices(_0023_003DzgEkZi75Aakl3: false);
		Vector3D _0023_003DzzRaskB_00243uPOQ;
		Vector3D _0023_003DzoqgctgRhDmC;
		Vector3D _0023_003Dz_0024llOZEdbyJnQ;
		Transformation cameraTransform = GetCameraTransform(out _0023_003DzzRaskB_00243uPOQ, out _0023_003DzoqgctgRhDmC, out _0023_003Dz_0024llOZEdbyJnQ);
		double a = _0023_003DzT1nv_XGkbFYDaXSDkw_003D_003D() / 2.0;
		double a2 = Math.Atan(Math.Tan(a) * _0023_003DzCzIe62JVg98L);
		PointF _0023_003DzBlNmjoc_003D = new PointF((float)Math.Tan(a2), (float)Math.Tan(a));
		PointF _0023_003Dz948_aeQ_003D = new PointF(0f - _0023_003DzBlNmjoc_003D.X, 0f - _0023_003DzBlNmjoc_003D.Y);
		OffsetOnCameraAxesParams offsetOnCameraAxesParams = new OffsetOnCameraAxesParams(cameraTransform, _0023_003DzImQx0os_003D, _0023_003DzBlNmjoc_003D, _0023_003Dz948_aeQ_003D);
		if (_0023_003Dz9SYi5hYGMSW6)
		{
			_0023_003DzE5qHPBTSyIcUyeffDLPzifejZtltAsTr8Q_003D_003D(_0023_003Dzv7xH9gk_003D, offsetOnCameraAxesParams);
		}
		else
		{
			_0023_003DzpTNNseYcpZtdVI8XO1_002403ag_003D(_0023_003Dzv7xH9gk_003D, _0023_003DzImQx0os_003D, _0023_003Dz9rsu4TwhLBvn, offsetOnCameraAxesParams);
		}
		if (offsetOnCameraAxesParams.MinQ._0023_003Dzqh_BTJs_003D() && offsetOnCameraAxesParams.MaxQ._0023_003Dzqh_BTJs_003D() && offsetOnCameraAxesParams.MinQ.X != float.MinValue && offsetOnCameraAxesParams.MinQ.Y != float.MinValue && offsetOnCameraAxesParams.MaxQ.X != float.MaxValue && offsetOnCameraAxesParams.MaxQ.Y != float.MaxValue)
		{
			_0023_003Dzl6Ino_7ANlXn(offsetOnCameraAxesParams.MinQ.Y, offsetOnCameraAxesParams.MaxQ.Y, _0023_003DzBlNmjoc_003D.Y, _0023_003Dz948_aeQ_003D.Y, out var _0023_003Dz40R7bAU_003D, out var _0023_003DzBJFJHwk_003D);
			_0023_003Dzl6Ino_7ANlXn(offsetOnCameraAxesParams.MinQ.X, offsetOnCameraAxesParams.MaxQ.X, _0023_003DzBlNmjoc_003D.X, _0023_003Dz948_aeQ_003D.X, out var _0023_003Dz40R7bAU_003D2, out var _0023_003DzBJFJHwk_003D2);
			if (_0023_003DzBJFJHwk_003D < 0.0)
			{
				_0023_003DzBJFJHwk_003D = 0.0;
			}
			if (_0023_003DzBJFJHwk_003D2 < 0.0)
			{
				_0023_003DzBJFJHwk_003D2 = 0.0;
			}
			double z = 0.0 - Math.Min(_0023_003DzBJFJHwk_003D, _0023_003DzBJFJHwk_003D2);
			Point3D point3D = new Point3D(_0023_003Dz40R7bAU_003D2, _0023_003Dz40R7bAU_003D, z);
			Transformation cameraTransform2 = GetCameraTransform(out _0023_003DzzRaskB_00243uPOQ, out _0023_003DzoqgctgRhDmC, out _0023_003Dz_0024llOZEdbyJnQ, _0023_003Dz8_0BNKGtqVk_0024: false);
			cameraTransform2.Invert();
			Point3D point3D2 = cameraTransform2 * point3D;
			Vector3D v = Vector3D.Subtract(cameraTarget, point3D2);
			Vector3D viewNormal = ViewNormal;
			double num = Vector3D.Dot(viewNormal, v);
			cameraTarget = point3D2 + viewNormal * num;
			double num2 = Math.Tan(a);
			double num3 = (1.0 + (double)_0023_003DzjqihOlA_003D / _0023_003DzXmrDMdc_003D) * num * num2;
			cameraDistance = (0.0 - num3) / num2;
			UpdateLocation();
		}
	}

	private static void _0023_003DzE5qHPBTSyIcUyeffDLPzifejZtltAsTr8Q_003D_003D(IList<Entity> _0023_003Dzv7xH9gk_003D, OffsetOnCameraAxesParams _0023_003DzmPmPjCPqZ3T3)
	{
		int count = _0023_003Dzv7xH9gk_003D.Count;
		for (int i = 0; i < count; i++)
		{
			Entity entity = _0023_003Dzv7xH9gk_003D[i];
			if (entity.IsVisible(_0023_003DzmPmPjCPqZ3T3.Parents, _0023_003DzmPmPjCPqZ3T3.Document.Layers, _0023_003DzmPmPjCPqZ3T3.Document.AttributeReferenceVisibilityMode))
			{
				if (entity.IsSelected(_0023_003DzmPmPjCPqZ3T3.Parents, selectionStatusType.Permanent))
				{
					entity.ComputeOffsetOnCameraAxes(_0023_003DzmPmPjCPqZ3T3);
				}
				else if (entity is BlockReference)
				{
					BlockReference blockReference = (BlockReference)entity;
					_0023_003DzmPmPjCPqZ3T3.PushTransformation(blockReference);
					_0023_003DzmPmPjCPqZ3T3.Parents.Push(blockReference);
					_0023_003DzE5qHPBTSyIcUyeffDLPzifejZtltAsTr8Q_003D_003D(_0023_003DzmPmPjCPqZ3T3.Blocks[blockReference.BlockName].Entities, _0023_003DzmPmPjCPqZ3T3);
					_0023_003DzmPmPjCPqZ3T3.Parents.Pop();
					_0023_003DzmPmPjCPqZ3T3.PopTransformation();
				}
			}
		}
	}

	private static void _0023_003DzpTNNseYcpZtdVI8XO1_002403ag_003D(IList<Entity> _0023_003Dzv7xH9gk_003D, IWorkspaceInternal _0023_003DzImQx0os_003D, bool _0023_003Dz9rsu4TwhLBvn, OffsetOnCameraAxesParams _0023_003DzmPmPjCPqZ3T3)
	{
		int count = _0023_003Dzv7xH9gk_003D.Count;
		if (count == 1 && _0023_003Dzv7xH9gk_003D[0] is BlockReference blockReference && blockReference.BlockName == _0023_003DzmPmPjCPqZ3T3.Document.OpenBlock.Name)
		{
			blockReference.ComputeOffsetOnCameraAxes(_0023_003DzmPmPjCPqZ3T3);
			return;
		}
		_0023_003DzmPmPjCPqZ3T3.Parents = new Stack<BlockReference>(_0023_003DzImQx0os_003D.Parents.Reverse());
		for (int i = 0; i < count; i++)
		{
			Entity entity = _0023_003Dzv7xH9gk_003D[i];
			if (entity.IsVisible(_0023_003DzmPmPjCPqZ3T3.Parents, _0023_003DzImQx0os_003D.Layers, _0023_003DzImQx0os_003D.AttributeReferenceVisibilityMode) && (!_0023_003Dz9rsu4TwhLBvn || entity.Selected))
			{
				entity.ComputeOffsetOnCameraAxes(_0023_003DzmPmPjCPqZ3T3);
			}
		}
	}

	private static void _0023_003Dzl6Ino_7ANlXn(double _0023_003Dz7ZE84gQ_003D, double _0023_003DzYENOV_Q_003D, double _0023_003DzBlNmjoc_003D, double _0023_003Dz948_aeQ_003D, out double _0023_003Dz40R7bAU_003D, out double _0023_003DzBJFJHwk_003D)
	{
		_0023_003Dz40R7bAU_003D = (_0023_003Dz948_aeQ_003D * _0023_003Dz7ZE84gQ_003D - _0023_003DzBlNmjoc_003D * _0023_003DzYENOV_Q_003D) / (_0023_003Dz948_aeQ_003D - _0023_003DzBlNmjoc_003D);
		_0023_003DzBJFJHwk_003D = (_0023_003Dz40R7bAU_003D - _0023_003Dz7ZE84gQ_003D) / _0023_003DzBlNmjoc_003D;
	}

	public static void ComputeOffsetOnCameraAxes(Point3D pt, PointF m1, PointF m2, ref PointF minQ, ref PointF maxQ)
	{
		_0023_003Dz4yR3wJK0ZQDToaQwLg_003D_003D((float)pt.X, (float)pt.Y, (float)pt.Z, m1, m2, ref minQ, ref maxQ);
	}

	internal static void _0023_003Dz4yR3wJK0ZQDToaQwLg_003D_003D(float _0023_003DzitEoid4_003D, float _0023_003DzSA2WXtw_003D, float _0023_003DzwQ_0024Eoi0_003D, PointF _0023_003DzBlNmjoc_003D, PointF _0023_003Dz948_aeQ_003D, ref PointF _0023_003DzG_jDrLY_003D, ref PointF _0023_003DzmexvDmU_003D)
	{
		float num = _0023_003DzwQ_0024Eoi0_003D * -1f;
		float val = _0023_003DzSA2WXtw_003D - _0023_003DzBlNmjoc_003D.Y * num;
		_0023_003DzG_jDrLY_003D.Y = Math.Max(val, _0023_003DzG_jDrLY_003D.Y);
		val = _0023_003DzSA2WXtw_003D - _0023_003Dz948_aeQ_003D.Y * num;
		_0023_003DzmexvDmU_003D.Y = Math.Min(val, _0023_003DzmexvDmU_003D.Y);
		val = _0023_003DzitEoid4_003D - _0023_003DzBlNmjoc_003D.X * num;
		_0023_003DzG_jDrLY_003D.X = Math.Max(val, _0023_003DzG_jDrLY_003D.X);
		val = _0023_003DzitEoid4_003D - _0023_003Dz948_aeQ_003D.X * num;
		_0023_003DzmexvDmU_003D.X = Math.Min(val, _0023_003DzmexvDmU_003D.X);
	}

	internal void Fit(Size _0023_003Dz4BrWeV0_003D, int _0023_003DzjqihOlA_003D)
	{
		Fit(_0023_003Dz4BrWeV0_003D, _0023_003DzjqihOlA_003D, out var _0023_003DzZlu3cB4_003D, out var _0023_003DzxP9oJI8_003D, out var _0023_003Dz2J9tXt3PMj6_0024);
		cameraTarget = _0023_003DzZlu3cB4_003D;
		cameraDistance = _0023_003DzxP9oJI8_003D;
		UpdateLocation();
		ZoomFactor = _0023_003Dz2J9tXt3PMj6_0024;
	}

	internal void Fit(Size _0023_003Dz4BrWeV0_003D, int _0023_003DzjqihOlA_003D, out Point3D _0023_003DzZlu3cB4_003D, out double _0023_003DzxP9oJI8_003D, out double _0023_003Dz2J9tXt3PMj6_0024)
	{
		_0023_003DzZlu3cB4_003D = cameraTarget;
		_0023_003DzxP9oJI8_003D = cameraDistance;
		_0023_003Dz2J9tXt3PMj6_0024 = zoomFactor;
		if (projectedMin.X == double.MaxValue)
		{
			return;
		}
		double _0023_003DzAvn2b38_003D = projectedMax.X - projectedMin.X;
		double _0023_003DzfJFRO2o_003D = projectedMax.Y - projectedMin.Y;
		_0023_003DzfJFRO2o_003D = _0023_003DznpcMNKc82q7c(_0023_003Dz4BrWeV0_003D, _0023_003DzAvn2b38_003D, _0023_003DzfJFRO2o_003D);
		Vector3D vector3D = Vector3D.Subtract(centerOfRotation, cameraTarget);
		_0023_003DzZlu3cB4_003D += vector3D;
		switch (cameraProjection)
		{
		case projectionType.Perspective:
		{
			double num2 = (projectedMax.Z - projectedMin.Z) / 2.0;
			if (_0023_003DzfJFRO2o_003D > 0.0)
			{
				_0023_003DzxP9oJI8_003D = _0023_003DzFH0lSC2cMEDX(_0023_003DzfJFRO2o_003D) + num2;
			}
			break;
		}
		case projectionType.Orthographic:
		{
			_0023_003DzxP9oJI8_003D = Math.Max(projectedMax.Z - projectedMin.Z, 2.0 * GetOffsetForSelection());
			int num = _0023_003Dz4BrWeV0_003D.Height - 2 * _0023_003DzjqihOlA_003D;
			_0023_003Dz2J9tXt3PMj6_0024 = (double)num / _0023_003DzfJFRO2o_003D;
			break;
		}
		}
	}

	private double _0023_003DznpcMNKc82q7c(Size _0023_003Dz4BrWeV0_003D, double _0023_003DzAvn2b38_003D, double _0023_003DzfJFRO2o_003D)
	{
		if (_0023_003DzAvn2b38_003D / _0023_003DzfJFRO2o_003D > (double)_0023_003Dz4BrWeV0_003D.Width / (double)_0023_003Dz4BrWeV0_003D.Height)
		{
			_0023_003DzfJFRO2o_003D = _0023_003DzAvn2b38_003D / _0023_003DzCzIe62JVg98L;
		}
		return _0023_003DzfJFRO2o_003D;
	}

	internal void AdjustNearAndFarPlanes(Point3D[] _0023_003DzrdSL0CI_003D)
	{
		projectedMin = Point3D.MaxValue;
		projectedMax = Point3D.MinValue;
		Point3D[] points = ProjectToCameraPlane(_0023_003DzrdSL0CI_003D);
		UpdateMatrices();
		Utility.UpdateMinMax(null, points, _0023_003DzrdSL0CI_003D.Length, projectedMin, projectedMax);
		_0023_003DzAZz3Z5sTQkbSyQ3CxQ_003D_003D();
		AdjustNearAndFarPlanes();
	}

	private void _0023_003DzAZz3Z5sTQkbSyQ3CxQ_003D_003D()
	{
		if (Utility.InvalidOGLPoint(projectedMin) || Utility.InvalidOGLPoint(projectedMax))
		{
			Utility.ResetBBox(out projectedMin, out projectedMax);
		}
	}

	internal void AdjustNearAndFarPlanes()
	{
		cameraNear = 0.0 - projectedMax.Z;
		cameraFar = 0.0 - projectedMin.Z;
		if (cameraProjection == projectionType.Perspective)
		{
			cameraNear -= Math.Max(1E-07, Math.Abs(cameraNear) * 0.01);
			cameraFar += Math.Max(1E-07, Math.Abs(cameraFar) * 0.01);
			if (projectedMax.Z > 0.0)
			{
				projectedMax.Z = 0.0;
			}
			double minimumDepth = GetMinimumDepth();
			if (cameraNear < minimumDepth)
			{
				cameraNear = minimumDepth;
			}
			if (cameraFar < 0.0)
			{
				cameraFar = cameraNear * 5.0;
			}
			return;
		}
		double offsetForSelection = GetOffsetForSelection();
		cameraNear -= offsetForSelection;
		if (cameraNear < 0.0)
		{
			double num = 0.0 - cameraNear + offsetForSelection;
			projectedMax.Z = 0.0 - offsetForSelection;
			projectedMin.Z += cameraNear;
			cameraLocation += ViewNormal * num;
			cameraFar += num;
			cameraNear = 0.0;
		}
		else
		{
			double num2 = (_0023_003DznYtQKck_003D - _0023_003DzeMBeuAQ_003D) / 2.0;
			cameraNear -= num2;
			cameraFar += num2;
			if (cameraNear < 0.0)
			{
				cameraNear = 0.0;
			}
		}
	}

	private bool _0023_003Dz9SYu8ugMyBcwdKxcUNkOTQY_003D()
	{
		return NearPlaneDistanceFactor != 0.001;
	}

	internal void _0023_003Dz8BuD9UtQHEpqExEeaCP1GJQ_003D()
	{
		NearPlaneDistanceFactor = 0.001;
	}

	internal double GetMinimumDepth()
	{
		return Math.Max((projectedMax.Z - projectedMin.Z) * NearPlaneDistanceFactor, Vector3D.Subtract(projectedMax, projectedMin).Length * Utility._0023_003DzxhnLabVjXjPg);
	}

	internal double _0023_003DzFH0lSC2cMEDX(double _0023_003DzfJFRO2o_003D)
	{
		double num = _0023_003DzT1nv_XGkbFYDaXSDkw_003D_003D();
		return _0023_003DzfJFRO2o_003D / 2.0 / Math.Tan(num / 2.0);
	}

	internal double _0023_003DzY9OAXtr4mZK7(double _0023_003DzAvn2b38_003D)
	{
		double num = _0023_003DzerReMoZ5I5sJsXLZBg_003D_003D();
		return _0023_003DzAvn2b38_003D / 2.0 / Math.Tan(num / 2.0);
	}

	private double _0023_003DzerReMoZ5I5sJsXLZBg_003D_003D()
	{
		return 2.0 * Math.Atan(_frame.X / (2.0 * focalLength));
	}

	internal double _0023_003DzT1nv_XGkbFYDaXSDkw_003D_003D()
	{
		return 2.0 * Math.Atan(_frame.Y / (2.0 * focalLength));
	}

	public Point3D[] ProjectToCameraPlane(Point3D[] points)
	{
		GetFrame(out var _, out var camX, out var camY, out var _);
		Plane plane = new Plane(cameraLocation, camX, camY);
		Transformation transformation = new Transformation();
		transformation.Rotation(plane, Plane.XY);
		int num = points.Length;
		Point3D[] array = new Point3D[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = transformation * points[i];
		}
		return array;
	}

	private static double _0023_003DzIfym_0024Gw_003D(double _0023_003Dz2miLS1cOCKJj, double _0023_003Dzjag_aPU_003D, double _0023_003DzBELCdW0_003D, projectionType _0023_003DzIUYmckw_003D)
	{
		double result = 0.0;
		switch (_0023_003DzIUYmckw_003D)
		{
		case projectionType.Perspective:
			result = (0.0 - 2.0 * _0023_003Dzjag_aPU_003D * _0023_003Dz2miLS1cOCKJj) / (2.0 * (_0023_003Dzjag_aPU_003D - _0023_003Dz2miLS1cOCKJj) * (_0023_003DzBELCdW0_003D - 0.5) - (_0023_003Dzjag_aPU_003D + _0023_003Dz2miLS1cOCKJj));
			break;
		case projectionType.Orthographic:
			result = _0023_003DzBELCdW0_003D * (_0023_003Dzjag_aPU_003D - _0023_003Dz2miLS1cOCKJj) + _0023_003Dz2miLS1cOCKJj;
			break;
		}
		return result;
	}

	internal void _0023_003DzacB01ck_003D(Vector3D _0023_003DzEEncnNQ_003D)
	{
		cameraTarget = new Point3D(cameraTarget.X - _0023_003DzEEncnNQ_003D.X, cameraTarget.Y - _0023_003DzEEncnNQ_003D.Y, cameraTarget.Z - _0023_003DzEEncnNQ_003D.Z);
		cameraLocation = new Point3D(cameraLocation.X - _0023_003DzEEncnNQ_003D.X, cameraLocation.Y - _0023_003DzEEncnNQ_003D.Y, cameraLocation.Z - _0023_003DzEEncnNQ_003D.Z);
	}

	internal void ApplyCenterOfRotation(int[] _0023_003DzqDFBISpCePlj, rotationCenterType _0023_003DzD6EtTAM_003D)
	{
		if (!(centerOfRotation == null) && projectedMin.X != double.MaxValue)
		{
			if (allModelInsideFrustum || _0023_003DzD6EtTAM_003D != rotationCenterType.ViewportCenter)
			{
				Vector3D vector3D = new Vector3D(centerOfRotation.ToArray());
				UnProject(renderContext, _0023_003DzqDFBISpCePlj, ModelViewMatrix, ProjectionMatrix, (double)_0023_003DzqDFBISpCePlj[0] + (double)_0023_003DzqDFBISpCePlj[2] / 2.0, (double)_0023_003DzqDFBISpCePlj[1] + (double)_0023_003DzqDFBISpCePlj[3] / 2.0, 0.0, out var objx, out var objy, out var objz);
				vector3D.X -= objx;
				vector3D.Y -= objy;
				vector3D.Z -= objz;
				GetFrame(out var _, out var camX, out var camY, out var _);
				screenOffsetForRotation = new Vector3D(Vector3D.Dot(vector3D, camX), Vector3D.Dot(vector3D, camY), 0.0);
				Point3D _0023_003Dzzo8RvXc_003D = centerOfRotation.ProjectTo(new Segment3D(cameraLocation, cameraTarget));
				cameraDistance = _0023_003Dz7XDBwpU_003D(_0023_003Dzzo8RvXc_003D, cameraLocation);
				cameraTarget = centerOfRotation;
			}
			else
			{
				cameraTarget = centerOfRotation.ProjectTo(new Segment3D(cameraLocation, cameraTarget));
				cameraDistance = _0023_003Dz7XDBwpU_003D(cameraTarget, cameraLocation);
			}
		}
	}

	internal void SetViewport(int[] _0023_003DzqDFBISpCePlj)
	{
		viewportPosition.X = _0023_003DzqDFBISpCePlj[0];
		viewportPosition.Y = _0023_003DzqDFBISpCePlj[1];
		if (renderContext != null)
		{
			renderContext.SetViewport(_0023_003DzqDFBISpCePlj);
		}
	}

	internal void SetViewport(int[] _0023_003DzqDFBISpCePlj, float _0023_003DztDVgdmywZVL_0024, float _0023_003DzLjbLPTLhEbq2)
	{
		viewportPosition.X = _0023_003DzqDFBISpCePlj[0];
		viewportPosition.Y = _0023_003DzqDFBISpCePlj[1];
		if (renderContext != null)
		{
			renderContext.SetViewport(_0023_003DzqDFBISpCePlj, _0023_003DztDVgdmywZVL_0024, _0023_003DzLjbLPTLhEbq2);
		}
	}

	internal void RecomputeViewport(Size _0023_003Dz14lzA48_003D)
	{
		int _0023_003Dz6tVBpdk_003D = _0023_003Dz14lzA48_003D.Width;
		int _0023_003DzvAxV_0024Ic_003D = _0023_003Dz14lzA48_003D.Height;
		_0023_003Dze6dqceR_xzbS(ref _0023_003Dz6tVBpdk_003D, ref _0023_003DzvAxV_0024Ic_003D);
		_0023_003DzCzIe62JVg98L = (double)_0023_003Dz6tVBpdk_003D / (double)_0023_003DzvAxV_0024Ic_003D;
		_0023_003DzeMBeuAQ_003D = (double)(-_0023_003Dz6tVBpdk_003D) / 2.0;
		_0023_003DznYtQKck_003D = (double)_0023_003Dz6tVBpdk_003D / 2.0;
		_0023_003Dz5F7_i_0024U_003D = (double)(-_0023_003DzvAxV_0024Ic_003D) / 2.0;
		_0023_003DzXmrDMdc_003D = (double)_0023_003DzvAxV_0024Ic_003D / 2.0;
		if (cameraProjection == projectionType.Orthographic)
		{
			_0023_003DzeMBeuAQ_003D /= zoomFactor;
			_0023_003DznYtQKck_003D /= zoomFactor;
			_0023_003Dz5F7_i_0024U_003D /= zoomFactor;
			_0023_003DzXmrDMdc_003D /= zoomFactor;
		}
	}

	internal static void _0023_003Dze6dqceR_xzbS(ref int _0023_003Dz6tVBpdk_003D, ref int _0023_003DzvAxV_0024Ic_003D)
	{
		if (_0023_003Dz6tVBpdk_003D < 2)
		{
			_0023_003Dz6tVBpdk_003D = 2;
		}
		if (_0023_003DzvAxV_0024Ic_003D < 2)
		{
			_0023_003DzvAxV_0024Ic_003D = 2;
		}
	}

	public void Move(double dx, double dy, double dz)
	{
		GetFrame(out var _, out var camX, out var camY, out var camZ);
		cameraTarget += camX * dx + camY * dy + camZ * dz;
		UpdateLocation();
	}

	internal void RotateByAngle(int[] _0023_003DzqDFBISpCePlj, rotationCenterType _0023_003DzyNZquWXQaPzE, Vector3D _0023_003DzCXCsNEAoTIbu, double _0023_003DzN_00244hHJTN8WML, bool _0023_003DzGkQwE7Vh8NHe, bool _0023_003Dz8SfmelQ8rQFg, out Point3D _0023_003DzZlu3cB4_003D, out Quaternion _0023_003DzBKluLAM_003D, out double _0023_003DzxP9oJI8_003D)
	{
		Point3D target = Target;
		double distance = Distance;
		Quaternion rotation = Rotation;
		ApplyCenterOfRotation(_0023_003DzqDFBISpCePlj, _0023_003DzyNZquWXQaPzE);
		if (_0023_003DzGkQwE7Vh8NHe)
		{
			cameraRotation *= new Quaternion(_0023_003DzCXCsNEAoTIbu, _0023_003DzN_00244hHJTN8WML);
		}
		else
		{
			cameraRotation = new Quaternion(_0023_003DzCXCsNEAoTIbu, _0023_003DzN_00244hHJTN8WML) * cameraRotation;
		}
		UpdateLocation();
		RemoveOffsetForRotation();
		_0023_003DzZlu3cB4_003D = Target;
		_0023_003DzBKluLAM_003D = Rotation;
		_0023_003DzxP9oJI8_003D = Distance;
		if (_0023_003Dz8SfmelQ8rQFg)
		{
			cameraTarget = target;
			cameraRotation = rotation;
			cameraDistance = distance;
			UpdateLocation();
		}
		UpdateMatrices();
	}

	internal void RemoveOffsetForRotation()
	{
		if (screenOffsetForRotation.X != 0.0 || screenOffsetForRotation.Y != 0.0)
		{
			GetFrame(out var _, out var camX, out var camY, out var _);
			Vector3D vector3D = new Vector3D(camX.ToArray()) * (0.0 - screenOffsetForRotation.X);
			vector3D += new Vector3D(camY.ToArray()) * (0.0 - screenOffsetForRotation.Y);
			cameraTarget = new Point3D(Target.X + vector3D.X, Target.Y + vector3D.Y, Target.Z + vector3D.Z);
			screenOffsetForRotation.X = 0.0;
			screenOffsetForRotation.Y = 0.0;
			UpdateLocation();
		}
	}

	internal void ResetProjectionMatrixStack()
	{
		if (sharedData.CurrProjectionMatrixType != projectionMatrixType.Standard)
		{
			SetProjectionMatrixType(projectionMatrixType.Standard);
		}
		sharedData.CurrProjectionMatrixType = projectionMatrixType.Standard;
	}

	internal void SetProjectionMatrixType(projectionMatrixType _0023_003DzEKSHIVc_003D)
	{
		if (_0023_003DzEKSHIVc_003D == sharedData.CurrProjectionMatrixType)
		{
			return;
		}
		renderContext.EndDrawBufferedLines();
		if (sharedData.CurrProjectionMatrixType == projectionMatrixType.Standard)
		{
			renderContext.PushProjection();
		}
		else
		{
			renderContext.PopProjection();
			if (_0023_003DzEKSHIVc_003D != projectionMatrixType.Standard)
			{
				renderContext.PushProjection();
			}
		}
		if (_0023_003DzEKSHIVc_003D != projectionMatrixType.Standard)
		{
			renderContext.SetProjectionMatrix(_0023_003Dzxw_0024o022k6AD1);
		}
		sharedData.CurrProjectionMatrixType = _0023_003DzEKSHIVc_003D;
	}

	internal static Quaternion Tilt(Vector3D _0023_003DzCBEAoWM_003D, Vector3D _0023_003DzcDvSOM4_003D, Vector3D _0023_003DzCXCsNEAoTIbu)
	{
		double num = 0.0;
		if (Math.Abs(Math.Abs(Vector3D.Dot(_0023_003DzcDvSOM4_003D, _0023_003DzCXCsNEAoTIbu)) - 1.0) < 1E-05)
		{
			_0023_003DzC6e_6HhyUYcp(_0023_003DzCXCsNEAoTIbu, out var _0023_003DzCBEAoWM_003D2);
			num = Utility.VectorsAngle(_0023_003DzCBEAoWM_003D, _0023_003DzCBEAoWM_003D2, _0023_003DzCXCsNEAoTIbu);
		}
		else
		{
			num = Utility.VectorsAngle(_0023_003DzCBEAoWM_003D, _0023_003DzcDvSOM4_003D, _0023_003DzCXCsNEAoTIbu);
		}
		if (num >= -360.0 && num <= 360.0)
		{
			return new Quaternion(_0023_003DzCXCsNEAoTIbu, num);
		}
		return new Quaternion(0.0, 0.0, 0.0, 1.0);
	}

	public void Tilt(Vector3D newUp)
	{
		GetFrame(out var _, out var _, out var camY, out var camZ);
		Rotation = Tilt(camY, newUp, camZ) * Rotation;
	}

	private void _0023_003DzIjn8IucP1rzj(Vector3D _0023_003DzcDvSOM4_003D)
	{
		GetFrame(out var _, out var _, out var camY, out var camZ);
		cameraRotation = Tilt(camY, _0023_003DzcDvSOM4_003D, camZ) * cameraRotation;
		UpdateLocation();
	}

	public void Roll(double angleInDegrees)
	{
		Quaternion quaternion = new Quaternion((Vector3D)ViewNormal.Clone(), angleInDegrees);
		Rotation = quaternion * Rotation;
	}

	private static void _0023_003DzC6e_6HhyUYcp(Vector3D _0023_003DzxuJqjrs_003D, out Vector3D _0023_003DzCBEAoWM_003D)
	{
		if (_0023_003DzxuJqjrs_003D.X >= _0023_003DzxuJqjrs_003D.Y && _0023_003DzxuJqjrs_003D.X >= _0023_003DzxuJqjrs_003D.Z)
		{
			if (_0023_003DzxuJqjrs_003D.Y < _0023_003DzxuJqjrs_003D.Z)
			{
				_0023_003DzCBEAoWM_003D = new Vector3D(_0023_003DzxuJqjrs_003D.Y, _0023_003DzxuJqjrs_003D.X, _0023_003DzxuJqjrs_003D.Z);
			}
			else
			{
				_0023_003DzCBEAoWM_003D = new Vector3D(_0023_003DzxuJqjrs_003D.Z, _0023_003DzxuJqjrs_003D.Y, _0023_003DzxuJqjrs_003D.X);
			}
		}
		else if (_0023_003DzxuJqjrs_003D.Y >= _0023_003DzxuJqjrs_003D.X && _0023_003DzxuJqjrs_003D.Y >= _0023_003DzxuJqjrs_003D.Z)
		{
			if (_0023_003DzxuJqjrs_003D.X < _0023_003DzxuJqjrs_003D.Z)
			{
				_0023_003DzCBEAoWM_003D = new Vector3D(_0023_003DzxuJqjrs_003D.Y, _0023_003DzxuJqjrs_003D.X, _0023_003DzxuJqjrs_003D.Z);
			}
			else
			{
				_0023_003DzCBEAoWM_003D = new Vector3D(_0023_003DzxuJqjrs_003D.X, _0023_003DzxuJqjrs_003D.Z, _0023_003DzxuJqjrs_003D.Y);
			}
		}
		else if (_0023_003DzxuJqjrs_003D.X < _0023_003DzxuJqjrs_003D.Y)
		{
			_0023_003DzCBEAoWM_003D = new Vector3D(_0023_003DzxuJqjrs_003D.Z, _0023_003DzxuJqjrs_003D.Y, _0023_003DzxuJqjrs_003D.X);
		}
		else
		{
			_0023_003DzCBEAoWM_003D = new Vector3D(_0023_003DzxuJqjrs_003D.X, _0023_003DzxuJqjrs_003D.Z, _0023_003DzxuJqjrs_003D.Y);
		}
	}

	internal void ZoomWindow(int[] _0023_003DzqDFBISpCePlj, Size _0023_003Dz14lzA48_003D, System.Drawing.Point _0023_003Dz6Fveidcfn79x, System.Drawing.Point _0023_003DzbAIYDunpsR_7, int _0023_003DzBySRDc_0024Uc62c, double _0023_003DzvxHPuJA_003D, double _0023_003DzbJ36BxoxsrGP)
	{
		Utility.NormalizeBox(ref _0023_003Dz6Fveidcfn79x, ref _0023_003DzbAIYDunpsR_7);
		int num = _0023_003DzbAIYDunpsR_7.X - _0023_003Dz6Fveidcfn79x.X;
		int num2 = _0023_003DzbAIYDunpsR_7.Y - _0023_003Dz6Fveidcfn79x.Y;
		System.Drawing.Point _0023_003DzpSZEvLzt7eiw = new System.Drawing.Point(_0023_003Dz6Fveidcfn79x.X + num / 2, _0023_003Dz6Fveidcfn79x.Y + num2 / 2);
		System.Drawing.Point _0023_003Dz1YkB2EvkriNc = new System.Drawing.Point(_0023_003DzqDFBISpCePlj[0] + _0023_003Dz14lzA48_003D.Width / 2, _0023_003DzqDFBISpCePlj[1] + _0023_003Dz14lzA48_003D.Height / 2);
		bool flag = projectedMin.X != double.MaxValue;
		if (flag)
		{
			Pan(_0023_003DzqDFBISpCePlj, _0023_003DzpSZEvLzt7eiw, _0023_003Dz1YkB2EvkriNc, _0023_003DzvxHPuJA_003D);
		}
		double num3 = (double)_0023_003Dz14lzA48_003D.Width / (double)num;
		double num4 = (double)_0023_003Dz14lzA48_003D.Height / (double)num2;
		switch (ProjectionMode)
		{
		case projectionType.Perspective:
		{
			if (!flag)
			{
				Zoom(_0023_003DzqDFBISpCePlj, ModelViewMatrix, ProjectionMatrix, Location, new System.Drawing.Point(_0023_003DzqDFBISpCePlj[0] + _0023_003Dz14lzA48_003D.Width / 2, _0023_003DzqDFBISpCePlj[1] + _0023_003Dz14lzA48_003D.Height / 2), _0023_003DzBySRDc_0024Uc62c, _0023_003DzvxHPuJA_003D, _0023_003DzvxHPuJA_003D, _0023_003DzbJ36BxoxsrGP, _0023_003DzMsyfIgFiPcQGlCz8CQ_003D_003D: false);
				break;
			}
			Point3D[] array = ProjectToCameraPlane(new Point3D[2]
			{
				UnProject(renderContext, _0023_003DzqDFBISpCePlj, _0023_003DzqDFBISpCePlj[0], _0023_003DzqDFBISpCePlj[1], _0023_003DzvxHPuJA_003D),
				UnProject(renderContext, _0023_003DzqDFBISpCePlj, _0023_003DzqDFBISpCePlj[0], _0023_003DzqDFBISpCePlj[1] + _0023_003Dz14lzA48_003D.Height, _0023_003DzvxHPuJA_003D)
			});
			double _0023_003DzfJFRO2o_003D = array[1].Y - array[0].Y;
			double num5 = _0023_003DzFH0lSC2cMEDX(_0023_003DzfJFRO2o_003D);
			double num6 = ((!(num3 > num4)) ? (num5 * (double)num / (double)_0023_003Dz14lzA48_003D.Width) : (num5 * (double)num2 / (double)_0023_003Dz14lzA48_003D.Height));
			Move(0.0, 0.0, 0.0 - (num5 - num6));
			break;
		}
		case projectionType.Orthographic:
			if (num3 > num4)
			{
				ZoomFactor *= num4;
			}
			else
			{
				ZoomFactor *= num3;
			}
			break;
		}
	}

	internal void Pan(int[] _0023_003DzqDFBISpCePlj, System.Drawing.Point _0023_003DzpSZEvLzt7eiw, System.Drawing.Point _0023_003Dz1YkB2EvkriNc, double _0023_003DzvxHPuJA_003D)
	{
		Point3D b = UnProject(renderContext, _0023_003DzqDFBISpCePlj, ModelViewMatrix, ProjectionMatrix, _0023_003DzpSZEvLzt7eiw.X, _0023_003DzpSZEvLzt7eiw.Y, _0023_003DzvxHPuJA_003D);
		Vector3D _0023_003DzEEncnNQ_003D = Vector3D.Subtract(UnProject(renderContext, _0023_003DzqDFBISpCePlj, ModelViewMatrix, ProjectionMatrix, _0023_003Dz1YkB2EvkriNc.X, _0023_003Dz1YkB2EvkriNc.Y, _0023_003DzvxHPuJA_003D), b);
		_0023_003DzacB01ck_003D(_0023_003DzEEncnNQ_003D);
	}

	internal void Zoom(int[] _0023_003DzqDFBISpCePlj, double[] _0023_003DzwDnfr_0s4VJe6mh9Pw_003D_003D, double[] _0023_003DzLHNORz9OZ7OfKzsutA_003D_003D, Point3D _0023_003DzjqF0QNf2K4vk, System.Drawing.Point _0023_003Dz_002428NCIRAss_1, double _0023_003DzIrPGUnY_003D, double _0023_003Dzck0TG0Y66jZg, double _0023_003DzQ3XXRwCBncyZ, double _0023_003DzbJ36BxoxsrGP, bool _0023_003DzMsyfIgFiPcQGlCz8CQ_003D_003D)
	{
		_0023_003DzMPg4e2qqEWDr();
		bool _0023_003Dz1qX_0024RudaZKFK = false;
		if (_0023_003Dz_002428NCIRAss_1 == System.Drawing.Point.Empty)
		{
			_0023_003Dz_002428NCIRAss_1 = new System.Drawing.Point(_0023_003DzqDFBISpCePlj[0] + _0023_003DzqDFBISpCePlj[2] / 2, _0023_003DzqDFBISpCePlj[1] + _0023_003DzqDFBISpCePlj[3] / 2);
			_0023_003Dz1qX_0024RudaZKFK = true;
		}
		System.Drawing.Point point = _0023_003Dz_002428NCIRAss_1;
		System.Drawing.Point point2 = new System.Drawing.Point(_0023_003DzqDFBISpCePlj[0] + _0023_003DzqDFBISpCePlj[2] / 2, _0023_003DzqDFBISpCePlj[1] + _0023_003DzqDFBISpCePlj[3] / 2);
		double[] myModelViewMatrix;
		double[] myProjectionMatrix;
		if (ProjectionMode == projectionType.Perspective)
		{
			myModelViewMatrix = _0023_003DzwDnfr_0s4VJe6mh9Pw_003D_003D;
			myProjectionMatrix = _0023_003DzLHNORz9OZ7OfKzsutA_003D_003D;
		}
		else
		{
			myModelViewMatrix = ModelViewMatrix;
			myProjectionMatrix = ProjectionMatrix;
		}
		Point3D point3D = UnProject(renderContext, _0023_003DzqDFBISpCePlj, myModelViewMatrix, myProjectionMatrix, point.X, point.Y, _0023_003DzQ3XXRwCBncyZ);
		Point3D a = UnProject(renderContext, _0023_003DzqDFBISpCePlj, myModelViewMatrix, myProjectionMatrix, point2.X, point2.Y, _0023_003DzQ3XXRwCBncyZ);
		Vector3D vector3D = null;
		if (point3D == null)
		{
			return;
		}
		double num = 0.0;
		if (ProjectionMode == projectionType.Perspective)
		{
			_0023_003DzrGUjrLnuk02s(_0023_003DzqDFBISpCePlj, _0023_003DzwDnfr_0s4VJe6mh9Pw_003D_003D, _0023_003DzLHNORz9OZ7OfKzsutA_003D_003D, _0023_003DzjqF0QNf2K4vk, _0023_003Dz_002428NCIRAss_1, _0023_003DzIrPGUnY_003D, _0023_003DzQ3XXRwCBncyZ, _0023_003DzbJ36BxoxsrGP, _0023_003DzMsyfIgFiPcQGlCz8CQ_003D_003D, point3D, _0023_003Dz1qX_0024RudaZKFK);
			return;
		}
		vector3D = Vector3D.Subtract(a, point3D);
		_0023_003DzacB01ck_003D(vector3D);
		double num2 = ZoomFactor;
		double num3 = 1.0 + Math.Abs(_0023_003DzIrPGUnY_003D) * _0023_003DzbJ36BxoxsrGP / 100.0;
		if (Math.Sign(_0023_003DzIrPGUnY_003D) == 1)
		{
			ZoomFactor *= num3;
		}
		else
		{
			ZoomFactor /= num3;
		}
		num = num2 / ZoomFactor;
		vector3D.Negate();
		vector3D *= num;
		_0023_003DzacB01ck_003D(vector3D);
	}

	private void _0023_003DzrGUjrLnuk02s(int[] _0023_003DzqDFBISpCePlj, double[] _0023_003DzwDnfr_0s4VJe6mh9Pw_003D_003D, double[] _0023_003DzLHNORz9OZ7OfKzsutA_003D_003D, Point3D _0023_003DzjqF0QNf2K4vk, System.Drawing.Point _0023_003Dz_002428NCIRAss_1, double _0023_003DzIrPGUnY_003D, double _0023_003DzQ3XXRwCBncyZ, double _0023_003DzbJ36BxoxsrGP, bool _0023_003DzMsyfIgFiPcQGlCz8CQ_003D_003D, Point3D _0023_003DzifYQnoFNzh6F, bool _0023_003Dz1qX_0024RudaZKFK)
	{
		double num = previousDepth;
		if (_0023_003DzQ3XXRwCBncyZ == 0.0)
		{
			num = Vector3D.Dot(cameraLocation - Point3D.Origin, ViewNormal);
			num = Math.Max(Math.Abs(num), _0023_003DzbJ36BxoxsrGP);
		}
		else if (_0023_003DzQ3XXRwCBncyZ > 0.0 && _0023_003DzQ3XXRwCBncyZ <= 1.0)
		{
			if (!_0023_003DzMsyfIgFiPcQGlCz8CQ_003D_003D)
			{
				num = new Vector3D((UnProject(renderContext, _0023_003DzqDFBISpCePlj, _0023_003DzwDnfr_0s4VJe6mh9Pw_003D_003D, _0023_003DzLHNORz9OZ7OfKzsutA_003D_003D, _0023_003Dz_002428NCIRAss_1.X, _0023_003Dz_002428NCIRAss_1.Y, _0023_003DzQ3XXRwCBncyZ) - _0023_003DzjqF0QNf2K4vk).ToArray()).Length;
			}
		}
		else if (num == 0.0)
		{
			num = new Vector3D((UnProject(renderContext, _0023_003DzqDFBISpCePlj, _0023_003DzwDnfr_0s4VJe6mh9Pw_003D_003D, _0023_003DzLHNORz9OZ7OfKzsutA_003D_003D, _0023_003Dz_002428NCIRAss_1.X, _0023_003Dz_002428NCIRAss_1.Y, 0.5) - _0023_003DzjqF0QNf2K4vk).ToArray()).Length;
		}
		Vector3D vector3D = (_0023_003Dz1qX_0024RudaZKFK ? ViewNormal : Vector3D.Subtract(_0023_003DzjqF0QNf2K4vk, _0023_003DzifYQnoFNzh6F));
		vector3D.Normalize();
		double num2 = (0.0 - _0023_003DzIrPGUnY_003D) * Math.Abs(num) * 0.005 * _0023_003DzbJ36BxoxsrGP;
		if (_0023_003DzMsyfIgFiPcQGlCz8CQ_003D_003D && Math.Abs(num2) < minimumDist)
		{
			num2 = minimumDist * (double)Math.Sign(num2);
		}
		Target += vector3D * num2;
		if (num > 0.0 && !_0023_003DzMsyfIgFiPcQGlCz8CQ_003D_003D)
		{
			previousDepth = num;
			minimumDist = Math.Abs(previousDepth / 500.0);
		}
		previousDepth += num2;
	}

	internal Plane _0023_003Dzcf0CiTCzpYfqRwzzXg_003D_003D()
	{
		return _003CReflectionPlane_003Ek__BackingField;
	}

	internal void _0023_003Dzz4ewQEs8jkatiD_0024PfA_003D_003D(Plane _0023_003DzPzO_0024GUk_003D)
	{
		_003CReflectionPlane_003Ek__BackingField = _0023_003DzPzO_0024GUk_003D;
	}

	internal void Reflect(Plane _0023_003Dzrgqz890sj_0024X9)
	{
		_0023_003Dzz4ewQEs8jkatiD_0024PfA_003D_003D(_0023_003Dzrgqz890sj_0024X9);
		cameraLocation = _0023_003Dzrgqz890sj_0024X9.Reflect(cameraLocation);
		cameraTarget = _0023_003Dzrgqz890sj_0024X9.Reflect(cameraTarget);
		upVector = _0023_003Dzrgqz890sj_0024X9.Reflect(upVector);
	}

	internal void SetCurrent(int[] _0023_003DzqDFBISpCePlj, float _0023_003DztDVgdmywZVL_0024, float _0023_003DzLjbLPTLhEbq2)
	{
		SetViewport(_0023_003DzqDFBISpCePlj, _0023_003DztDVgdmywZVL_0024, _0023_003DzLjbLPTLhEbq2);
		renderContext.SetMatrices(ProjectionMatrix, ModelViewMatrix);
	}

	private void _0023_003Dz8Ya24fp2yNgMGTZ9WA_003D_003D(Point3D _0023_003DzFj_0024IqDQ_003D, Point3D _0023_003DzjdeMMkk_003D)
	{
		UpdateMatrices(_0023_003DzgEkZi75Aakl3: true);
		Line line = new Line(_0023_003DzFj_0024IqDQ_003D, _0023_003DzjdeMMkk_003D);
		Vector3D _0023_003DzzRaskB_00243uPOQ;
		Vector3D _0023_003DzoqgctgRhDmC;
		Vector3D _0023_003Dz_0024llOZEdbyJnQ;
		Transformation cameraTransform = GetCameraTransform(out _0023_003DzzRaskB_00243uPOQ, out _0023_003DzoqgctgRhDmC, out _0023_003Dz_0024llOZEdbyJnQ);
		Point3D point3D = projectedMin;
		Point3D point3D2 = projectedMax;
		TraversalParams data = new TraversalParams(cameraTransform);
		line.ComputeBoundingBox(data, out projectedMin, out projectedMax);
		ComputeCenterOfRotation(_0023_003DzCpCzW0s6jJmE: true, _0023_003DzzRaskB_00243uPOQ, _0023_003DzoqgctgRhDmC, _0023_003Dz_0024llOZEdbyJnQ);
		Fit(Size, 10);
		projectedMin = point3D;
		projectedMax = point3D2;
		UpdateMatrices(_0023_003DzgEkZi75Aakl3: true);
	}

	public void UpdateMatrices()
	{
		UpdateMatrices(_0023_003DzgEkZi75Aakl3: false);
	}

	internal void UpdateMatrices(bool _0023_003DzgEkZi75Aakl3)
	{
		SetupModelViewProjection(RectangleF.Empty, _0023_003DzgEkZi75Aakl3, shadowPass: false, reflection: false, CameraEyePosType.Center, applySceneTransformation: true);
	}

	internal void InitializeGraphicsResources(IViewportInternal _0023_003DzZtHuUKdD4bvU)
	{
		if (_0023_003DzZtHuUKdD4bvU.parent != null)
		{
			SetRenderContext(_0023_003DzZtHuUKdD4bvU.parent.RenderContext);
		}
	}

	public bool ScreenToPlane(System.Drawing.Point mousePos, Plane plane, int controlHeight, int[] viewFrame, out Point3D intPoint)
	{
		return ScreenToPlane(mousePos, plane.Equation, controlHeight, viewFrame, out intPoint);
	}

	public bool ScreenToPlane(System.Drawing.Point mousePos, PlaneEquation pe, int controlHeight, int[] viewFrame, out Point3D intPoint)
	{
		return ScreenToPlaneInternal(mousePos, pe, controlHeight, viewFrame, out intPoint);
	}

	public Point3D[] ScreenToPlane(IList<System.Drawing.Point> mousePointList, PlaneEquation pe, int controlHeight, int[] viewFrame)
	{
		int count = mousePointList.Count;
		Point3D[] array = new Point3D[count];
		for (int i = 0; i < count; i++)
		{
			ScreenToPlaneInternal(mousePointList[i], pe, controlHeight, viewFrame, out array[i]);
		}
		return array;
	}

	internal bool ScreenToPlaneInternal(System.Drawing.Point _0023_003DzFNDApuVLTtJd, PlaneEquation _0023_003Dz79R_0024VZY_003D, int _0023_003Dzs3Tbbpix3oL8, int[] _0023_003DzqDFBISpCePlj, out Point3D _0023_003DzPjm3jErOBm64)
	{
		return _0023_003DzWDEN4JKKoYiWQLji1w_003D_003D(_0023_003DzFNDApuVLTtJd.X, _0023_003DzFNDApuVLTtJd.Y, _0023_003Dz79R_0024VZY_003D, _0023_003Dzs3Tbbpix3oL8, _0023_003DzqDFBISpCePlj, out _0023_003DzPjm3jErOBm64);
	}

	internal bool _0023_003DzWDEN4JKKoYiWQLji1w_003D_003D(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, PlaneEquation _0023_003Dz79R_0024VZY_003D, int _0023_003Dzs3Tbbpix3oL8, int[] _0023_003DzqDFBISpCePlj, out Point3D _0023_003DzPjm3jErOBm64)
	{
		UnProject(renderContext, _0023_003DzqDFBISpCePlj, ModelViewMatrix, ProjectionMatrix, _0023_003DzBJFJHwk_003D, (double)_0023_003Dzs3Tbbpix3oL8 - _0023_003Dz40R7bAU_003D, 0.0, out var objx, out var objy, out var objz);
		Point3D point3D;
		Point3D p;
		if (ProjectionMode == projectionType.Orthographic)
		{
			point3D = new Point3D(objx, objy, objz);
			p = point3D - ViewNormal;
		}
		else
		{
			point3D = Location;
			p = new Point3D(objx, objy, objz);
		}
		return Utility.LinePlaneIntersection(point3D, p, _0023_003Dz79R_0024VZY_003D, out _0023_003DzPjm3jErOBm64);
	}

	public Point3D WorldToScreen(Point3D point, int[] viewFrame)
	{
		return WorldToScreen(point.X, point.Y, point.Z, viewFrame);
	}

	public Point3D WorldToScreen(double x, double y, double z, int[] viewFrame)
	{
		_0023_003DzKWdaQi8_003D(renderContext, viewFrame, x, y, z, out var _0023_003Dzm3rc4SA8WtT, out var _0023_003DzOM5CofBvYOXf, out var _0023_003Dz_00246VsdVC_0024uVkn);
		return new Point3D(_0023_003Dzm3rc4SA8WtT, _0023_003DzOM5CofBvYOXf, _0023_003Dz_00246VsdVC_0024uVkn);
	}

	public Point3D[] WorldToScreen(IList<Point3D> pointList, int[] viewFrame)
	{
		int count = pointList.Count;
		Point3D[] array = new Point3D[count];
		for (int i = 0; i < count; i++)
		{
			Point3D point3D = pointList[i];
			array[i] = WorldToScreen(point3D.X, point3D.Y, point3D.Z, viewFrame);
		}
		return array;
	}

	internal void UpdateSize(Size _0023_003Dz14lzA48_003D)
	{
		ZBufferData.Size = _0023_003Dz14lzA48_003D;
	}

	internal Transformation GetCustomProjectionMatrix(double[] _0023_003DzwTc0B2NdlyUi)
	{
		Transformation transformation = new Transformation(_0023_003DzwTc0B2NdlyUi, byRow: false);
		if (pickMatrix != null)
		{
			transformation = ApplyPickMatrix(new Transformation(pickMatrix, byRow: false), transformation);
		}
		return transformation;
	}

	public bool ShouldSerialize(Camera reference)
	{
		if (!(Target != reference.Target) && Distance == reference.Distance && !(Rotation != reference.Rotation) && ProjectionMode == reference.ProjectionMode && FocalLength == reference.FocalLength && ZoomFactor == reference.ZoomFactor && !Anaglyph3D)
		{
			return NearPlaneDistanceFactor != reference.NearPlaneDistanceFactor;
		}
		return true;
	}

	private void _0023_003DzMPg4e2qqEWDr()
	{
		prevTarget = (Point3D)Target.Clone();
		prevDistance = Distance;
	}

	internal void RestorePreZoom()
	{
		Target = (Point3D)prevTarget.Clone();
		cameraDistance = prevDistance;
	}

	internal bool CheckPlanes()
	{
		GetFrame(out var _, out var camX, out var camY, out var _);
		if (camX.Length == 0.0 || camY.Length == 0.0)
		{
			return false;
		}
		return true;
	}

	internal void Reset()
	{
		cameraTarget = Point3D.Origin;
		Distance = 100.0;
		UpdateLocation();
	}

	private double[] _0023_003Dzjm6XktxtETBnUOck3A_003D_003D(double _0023_003Dz2miLS1cOCKJj, double _0023_003Dzjag_aPU_003D)
	{
		double num = Math.Tan(Utility.DegToRad(AngleOfView) / 2.0);
		double num2 = _0023_003Dz2miLS1cOCKJj * num;
		double num3 = 0.0 - num2;
		double num4 = _0023_003DzLqukFvnP2fqm();
		double num5 = _0023_003DzCzIe62JVg98L * num * convergenceDistance;
		double num6 = num5 - num4 / 2.0;
		double num7 = num5 + num4 / 2.0;
		double num8 = (0.0 - num6) * _0023_003Dz2miLS1cOCKJj / convergenceDistance;
		double num9 = num7 * _0023_003Dz2miLS1cOCKJj / convergenceDistance;
		return _0023_003DzlzzycDbFSCnCiv8UTQ_003D_003D(num8, num9, num3, num2, _0023_003Dz2miLS1cOCKJj, _0023_003Dzjag_aPU_003D);
	}

	private double _0023_003DzLqukFvnP2fqm()
	{
		return convergenceDistance / 30.0;
	}

	private double[] _0023_003DzQ8xcAQ0VkIulbAR_fA_003D_003D(double _0023_003Dz2miLS1cOCKJj, double _0023_003Dzjag_aPU_003D)
	{
		double num = Math.Tan(Utility.DegToRad(AngleOfView) / 2.0);
		double num2 = _0023_003Dz2miLS1cOCKJj * num;
		double num3 = 0.0 - num2;
		double num4 = _0023_003DzCzIe62JVg98L * num * convergenceDistance;
		double num5 = _0023_003DzLqukFvnP2fqm();
		double num6 = num4 - num5 / 2.0;
		double num7 = (0.0 - (num4 + num5 / 2.0)) * _0023_003Dz2miLS1cOCKJj / convergenceDistance;
		double num8 = num6 * _0023_003Dz2miLS1cOCKJj / convergenceDistance;
		return _0023_003DzlzzycDbFSCnCiv8UTQ_003D_003D(num7, num8, num3, num2, _0023_003Dz2miLS1cOCKJj, _0023_003Dzjag_aPU_003D);
	}

	internal void UpdateConvergenceDistance()
	{
		convergenceDistance = (cameraNear + cameraFar) / 2.0;
	}

	private double[] _0023_003DzlzzycDbFSCnCiv8UTQ_003D_003D(double _0023_003DzeMBeuAQ_003D, double _0023_003DznYtQKck_003D, double _0023_003Dz5F7_i_0024U_003D, double _0023_003DzXmrDMdc_003D, double _0023_003Dz2miLS1cOCKJj, double _0023_003Dzjag_aPU_003D)
	{
		double[] array = new double[16];
		double num = _0023_003Dzjag_aPU_003D - _0023_003Dz2miLS1cOCKJj;
		double num2 = _0023_003Dzjag_aPU_003D / num;
		array[0] = 2.0 * _0023_003Dz2miLS1cOCKJj / (_0023_003DznYtQKck_003D - _0023_003DzeMBeuAQ_003D);
		array[5] = 2.0 * _0023_003Dz2miLS1cOCKJj / (_0023_003DzXmrDMdc_003D - _0023_003Dz5F7_i_0024U_003D);
		array[8] = (_0023_003DznYtQKck_003D + _0023_003DzeMBeuAQ_003D) / (_0023_003DznYtQKck_003D - _0023_003DzeMBeuAQ_003D);
		array[9] = (_0023_003DzXmrDMdc_003D + _0023_003Dz5F7_i_0024U_003D) / (_0023_003DzXmrDMdc_003D - _0023_003Dz5F7_i_0024U_003D);
		if (renderContext == null || !renderContext.IsDirect3D)
		{
			array[10] = (0.0 - (_0023_003Dzjag_aPU_003D + _0023_003Dz2miLS1cOCKJj)) / num;
			array[11] = -1.0;
			array[14] = -2.0 * num2 * _0023_003Dz2miLS1cOCKJj;
		}
		else
		{
			array[10] = 0.0 - num2;
			array[11] = -1.0;
			array[14] = (0.0 - num2) * _0023_003Dz2miLS1cOCKJj;
		}
		return array;
	}

	internal void Update(Camera _0023_003Dzl_0024MIsC0_003D)
	{
		cameraProjection = _0023_003Dzl_0024MIsC0_003D.cameraProjection;
		Rotation = (Quaternion)_0023_003Dzl_0024MIsC0_003D.Rotation.Clone();
		Target = (Point3D)_0023_003Dzl_0024MIsC0_003D.Target.Clone();
		Distance = _0023_003Dzl_0024MIsC0_003D.Distance;
		ZoomFactor = _0023_003Dzl_0024MIsC0_003D.ZoomFactor;
		screenOffsetForRotation = (Vector3D)_0023_003Dzl_0024MIsC0_003D.screenOffsetForRotation.Clone();
		Array.Copy(_0023_003Dzl_0024MIsC0_003D.ModelViewMatrix, ModelViewMatrix, 16);
		Array.Copy(_0023_003Dzl_0024MIsC0_003D.ProjectionMatrix, ProjectionMatrix, 16);
	}

	internal bool _0023_003DzowqrsDjYYgq7()
	{
		return ZBufferData.IsInvalidRange;
	}

	internal bool UnProject(int[] _0023_003DzqDFBISpCePlj, double _0023_003Dzm3rc4SA8WtT6, double _0023_003DzOM5CofBvYOXf, double _0023_003Dz_00246VsdVC_0024uVkn, out double _0023_003Dzz2rwxLp5KP6A, out double _0023_003DzALC2Z_0024vEE1_h, out double _0023_003DznHYVZ7T5ufgF)
	{
		return UnProject(renderContext, _0023_003DzqDFBISpCePlj, ModelViewMatrix, ProjectionMatrix, _0023_003Dzm3rc4SA8WtT6 + (double)_0023_003DzqDFBISpCePlj[0], _0023_003DzOM5CofBvYOXf + (double)_0023_003DzqDFBISpCePlj[1], _0023_003Dz_00246VsdVC_0024uVkn, out _0023_003Dzz2rwxLp5KP6A, out _0023_003DzALC2Z_0024vEE1_h, out _0023_003DznHYVZ7T5ufgF);
	}

	internal Point3D[] UnProject(RenderContextBase _0023_003DzQdnFby4_003D, IList<Point3D> _0023_003DzrdSL0CI_003D, int[] _0023_003DzqDFBISpCePlj)
	{
		int count = _0023_003DzrdSL0CI_003D.Count;
		Point3D[] array = new Point3D[count];
		double[] modelViewProjectionMatrix = GetModelViewProjectionMatrix();
		double[] array2 = new double[16];
		if (!Utility.InvertMatrixd(modelViewProjectionMatrix, array2))
		{
			return null;
		}
		for (int i = 0; i < count; i++)
		{
			array[i] = UnProject(_0023_003DzQdnFby4_003D, _0023_003DzqDFBISpCePlj, array2, _0023_003DzrdSL0CI_003D[i].X + (double)_0023_003DzqDFBISpCePlj[0], _0023_003DzrdSL0CI_003D[i].Y + (double)_0023_003DzqDFBISpCePlj[1], _0023_003DzrdSL0CI_003D[i].Z);
		}
		return array;
	}

	internal double ComputeScreenToWorldFactor(RenderContextBase _0023_003DzqHz4Or_0024NPiQ1GNuWuQ_003D_003D, int[] _0023_003DzqDFBISpCePlj)
	{
		return ComputeScreenToWorldFactor(renderContext, ZBufferData.Min, _0023_003DzqDFBISpCePlj);
	}

	internal double ComputeScreenToWorldFactor(RenderContextBase _0023_003DzQdnFby4_003D, double _0023_003DzBELCdW0_003D, int[] _0023_003DzqDFBISpCePlj)
	{
		Point3D[] array = UnProject(_0023_003DzQdnFby4_003D, new Point3D[2]
		{
			new Point3D(_0023_003DzqDFBISpCePlj[0], _0023_003DzqDFBISpCePlj[1], _0023_003DzBELCdW0_003D),
			new Point3D(_0023_003DzqDFBISpCePlj[0] + 1, _0023_003DzqDFBISpCePlj[1], _0023_003DzBELCdW0_003D)
		}, _0023_003DzqDFBISpCePlj);
		if (array == null || array[0] == null || array[1] == null)
		{
			return 1.0;
		}
		return Point3D.Distance(array[0], array[1]);
	}

	internal void SetSceneTransformation(Transformation _0023_003Dz9ZUzIX4xmsyA)
	{
		if (_0023_003Dz9ZUzIX4xmsyA != null)
		{
			sceneTransformation = (Transformation)_0023_003Dz9ZUzIX4xmsyA.Clone();
			sceneTransformationInverted = (Transformation)_0023_003Dz9ZUzIX4xmsyA.Clone();
			sceneTransformationInverted.Invert();
		}
		else
		{
			sceneTransformation = (sceneTransformationInverted = null);
		}
	}

	public void RemoveSceneTransformation()
	{
		if (sceneTransformation != null)
		{
			renderContext.MultMatrixModelView(sceneTransformationInverted.MatrixAsVectorByColumn);
		}
	}

	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
	{
		if (EqualityComparer<T>.Default.Equals(field, value))
		{
			return false;
		}
		field = value;
		OnPropertyChanged(propertyName);
		return true;
	}

	internal static void ComputeScreenPosition(RenderContextBase _0023_003DzQdnFby4_003D, double[] _0023_003DzypMGqyMVO5qA, int[] _0023_003DzqDFBISpCePlj, Point3D _0023_003DzMlCq3wk_003D, out float _0023_003DzBJFJHwk_003D, out float _0023_003Dz40R7bAU_003D, out double _0023_003DzId5C3LA_003D, bool _0023_003DzgDVcxV_0024JJ9hgETWqIg_003D_003D = false)
	{
		Project(_0023_003DzQdnFby4_003D, _0023_003DzypMGqyMVO5qA, _0023_003DzqDFBISpCePlj, _0023_003DzMlCq3wk_003D.X, _0023_003DzMlCq3wk_003D.Y, _0023_003DzMlCq3wk_003D.Z, out var _0023_003Dzm3rc4SA8WtT, out var _0023_003DzOM5CofBvYOXf, out var _0023_003Dz_00246VsdVC_0024uVkn);
		_0023_003Dzm3rc4SA8WtT -= (double)_0023_003DzqDFBISpCePlj[0];
		_0023_003DzOM5CofBvYOXf -= (double)_0023_003DzqDFBISpCePlj[1];
		if ((_0023_003Dz_00246VsdVC_0024uVkn >= 0.0 && _0023_003Dz_00246VsdVC_0024uVkn < 1.0) || _0023_003DzgDVcxV_0024JJ9hgETWqIg_003D_003D)
		{
			_0023_003DzBJFJHwk_003D = (float)_0023_003Dzm3rc4SA8WtT;
			_0023_003Dz40R7bAU_003D = (float)_0023_003DzOM5CofBvYOXf;
			_0023_003DzId5C3LA_003D = _0023_003Dz_00246VsdVC_0024uVkn;
		}
		else
		{
			_0023_003DzBJFJHwk_003D = float.MinValue;
			_0023_003Dz40R7bAU_003D = float.MinValue;
			_0023_003DzId5C3LA_003D = 0.0;
		}
	}
}
