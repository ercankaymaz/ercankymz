using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot;

public class HiddenLinesViewSettings
{
	protected internal enum lineType
	{
		Silho,
		Edge,
		Wire
	}

	internal Document document;

	internal hiddenLinesViewType hdlViewMode;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<Tuple<Stack<BlockReference>, Entity>> _0023_003DzDArKSZg_3bZOovms3wWFgzE_003D = new List<Tuple<Stack<BlockReference>, Entity>>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzW_5wvb8fY85e8vj2EdOAk_c_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dzq21sy_st8WxPiSTSx8o_0jQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzVl2H4tTrgyA8wF7U2uTSyE0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzTaHH0MM72E2QBrOqyJoy6zs_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzsEult_92CNWoINbBbK8POzBAs_HO;

	internal RectangleF Window;

	public double newOldViewportRatio;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal MaterialKeyedCollection _0023_003DzXnYgAZR3DgQjnDS1gQ_003D_003D;

	protected internal LayerKeyedCollection Layers;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal BlockKeyedCollection _0023_003DzZbAhroU_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal LineTypeKeyedCollection _0023_003DzAVrMnB8_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal TextStyleKeyedCollection _0023_003DzjWOIYmI_003D;

	protected internal Size ViewportSize;

	protected internal int MaxPatternRepetitions;

	protected internal attributeReferenceVisibilityType AttributeReferenceVisibilityMode;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Camera _0023_003DzGyIsDk_u4amx6yBl9w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal int[] _0023_003DzVYKAyIXbkWOU;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Plane _0023_003DzOXtv5E4RqNjMzantA8yrswU_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal IList<Entity> _0023_003DzpagGO1c_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal List<SilhoWireData> _0023_003DzA8ZfmVFtMUmw;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Dictionary<AssemblyLeaf, List<_0023_003DzOMV8NDKkemw9Bwhd_k_00245Q_kffIIJ>> _0023_003DzGV_0024jjdDDcXbB_xWpqA_003D_003D;

	internal Point2D boxMin;

	internal Point2D boxMax;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzpTfxI0qG0fYIOsQqdOpmHUEEFra7;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz_Bfc0QvNVOIJa7RmzuWXfJQ_003D = true;

	protected internal bool ForceTextsAsTriangles;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz5ymmjWn_HRGoL11aeEfla7o_003D;

	public List<Tuple<Stack<BlockReference>, Entity>> EntitiesToHide
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzDArKSZg_3bZOovms3wWFgzE_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzDArKSZg_3bZOovms3wWFgzE_003D = value;
		}
	}

	public bool KeepHiddenSegments
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzW_5wvb8fY85e8vj2EdOAk_c_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzW_5wvb8fY85e8vj2EdOAk_c_003D = value;
		}
	}

	public bool KeepEntityColor
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzq21sy_st8WxPiSTSx8o_0jQ_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzq21sy_st8WxPiSTSx8o_0jQ_003D = value;
		}
	}

	public bool KeepEntityLineWeight
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzVl2H4tTrgyA8wF7U2uTSyE0_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzVl2H4tTrgyA8wF7U2uTSyE0_003D = value;
		}
	}

	public bool IgnoreTransparency
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzTaHH0MM72E2QBrOqyJoy6zs_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzTaHH0MM72E2QBrOqyJoy6zs_003D = value;
		}
	}

	public bool TreatWhiteAsBlack
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzsEult_92CNWoINbBbK8POzBAs_HO;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzsEult_92CNWoINbBbK8POzBAs_HO = value;
		}
	}

	public Camera Camera
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzGyIsDk_u4amx6yBl9w_003D_003D;
		}
	}

	public int[] ViewBounds => _0023_003DzVYKAyIXbkWOU;

	public Plane SectionPlane
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzOXtv5E4RqNjMzantA8yrswU_003D;
		}
	}

	public double FontAccuracy
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzpTfxI0qG0fYIOsQqdOpmHUEEFra7;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzpTfxI0qG0fYIOsQqdOpmHUEEFra7 = value;
		}
	}

	public bool FillTexts
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz_Bfc0QvNVOIJa7RmzuWXfJQ_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz_Bfc0QvNVOIJa7RmzuWXfJQ_003D = value;
		}
	}

	public bool FillRegions
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz5ymmjWn_HRGoL11aeEfla7o_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz5ymmjWn_HRGoL11aeEfla7o_003D = value;
		}
	}

	public HiddenLinesViewSettings(HiddenLinesViewSettings another)
	{
		_0023_003DzpagGO1c_003D = another._0023_003DzpagGO1c_003D;
		Layers = another.Layers;
		_0023_003DzXnYgAZR3DgQjnDS1gQ_003D_003D = another._0023_003DzXnYgAZR3DgQjnDS1gQ_003D_003D;
		_0023_003DzZbAhroU_003D = another._0023_003DzZbAhroU_003D;
		_0023_003DzAVrMnB8_003D = another._0023_003DzAVrMnB8_003D;
		_0023_003DzjWOIYmI_003D = another._0023_003DzjWOIYmI_003D;
		ViewportSize = another.ViewportSize;
		MaxPatternRepetitions = another.MaxPatternRepetitions;
		AttributeReferenceVisibilityMode = another.AttributeReferenceVisibilityMode;
		KeepEntityColor = another.KeepEntityColor;
		KeepEntityLineWeight = another.KeepEntityLineWeight;
		KeepHiddenSegments = another.KeepHiddenSegments;
		_0023_003DzGyIsDk_u4amx6yBl9w_003D_003D = (Camera)another.Camera.Clone();
		FontAccuracy = another.FontAccuracy;
		hdlViewMode = another.hdlViewMode;
		Window = another.Window;
		_0023_003DzVYKAyIXbkWOU = new int[4]
		{
			another._0023_003DzVYKAyIXbkWOU[0],
			another._0023_003DzVYKAyIXbkWOU[1],
			another._0023_003DzVYKAyIXbkWOU[2],
			another._0023_003DzVYKAyIXbkWOU[3]
		};
		newOldViewportRatio = another.newOldViewportRatio;
		IgnoreTransparency = another.IgnoreTransparency;
		TreatWhiteAsBlack = another.TreatWhiteAsBlack;
		document = another.document;
	}

	public HiddenLinesViewSettings(viewType view, Document document, Size? viewportSize = null)
		: this(new Camera(Point3D.Origin, view, 1.0), document, hiddenLinesViewType.Extents, viewportSize)
	{
	}

	public HiddenLinesViewSettings(Plane sectionPlane, Document document, Size? viewportSize = null)
		: this(SectionView._0023_003Dz2BrQCKOcKev5gM_QVw_003D_003D(sectionPlane), document, hiddenLinesViewType.Extents, viewportSize)
	{
		_0023_003DzPOJsk28mpsMNtfD8Bw_003D_003D(sectionPlane);
	}

	public HiddenLinesViewSettings(Camera camera, Document document, hiddenLinesViewType viewMode, Size? viewportSize = null, RectangleF? window = null)
	{
		this.document = document;
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "%fQD,q\"ac>", array);
		if (document.workspace != null)
		{
			_0023_003DzpagGO1c_003D = document.workspace.GetAllEntities();
			_0023_003DzZbAhroU_003D = document.workspace.GetAllBlocks();
		}
		else
		{
			_0023_003DzpagGO1c_003D = document.Entities;
			_0023_003DzZbAhroU_003D = document.Blocks;
		}
		Layers = document.Layers;
		_0023_003DzXnYgAZR3DgQjnDS1gQ_003D_003D = document.Materials;
		_0023_003DzAVrMnB8_003D = document.LineTypes;
		_0023_003DzjWOIYmI_003D = document.TextStyles;
		ViewportSize = (viewportSize.HasValue ? viewportSize.Value : new Size(5000, 5000));
		MaxPatternRepetitions = document.MaxPatternRepetitions;
		AttributeReferenceVisibilityMode = document.AttributeReferenceVisibilityMode;
		_0023_003DzGyIsDk_u4amx6yBl9w_003D_003D = (Camera)camera.Clone();
		FontAccuracy = document.GetVisualRefinement().Deviation;
		hdlViewMode = viewMode;
		newOldViewportRatio = 1.0 / Math.Ceiling(5000.0 / (double)ViewportSize.Width);
		Window = ((viewMode != hiddenLinesViewType.Window || !window.HasValue) ? ((RectangleF)_0023_003DzclStHcfnvCLN(ViewportSize)) : window.Value);
		Window.Y = (float)ViewportSize.Height - Window.Y - Window.Height;
		_0023_003DzuvFJnrNKDlc7(Camera, viewMode, 1.0 / newOldViewportRatio, ref ViewportSize, ref Window, out _0023_003DzVYKAyIXbkWOU);
		if (viewMode == hiddenLinesViewType.Extents)
		{
			Camera.UpdateBoundingBox(_0023_003DzVYKAyIXbkWOU, _0023_003DzpagGO1c_003D, document, _0023_003Dz9rsu4TwhLBvn: false);
			Camera.Fit(ViewportSize, 0);
			Window = default(RectangleF);
		}
		Camera.UpdateBoundingBox(_0023_003DzVYKAyIXbkWOU, _0023_003DzpagGO1c_003D, document, _0023_003Dz9rsu4TwhLBvn: false);
		Camera.AdjustNearAndFarPlanes();
		Camera.Far += (Camera.Far - Camera.Near) * 0.001;
		Camera.RecomputeViewport(ViewportSize);
		Camera.UpdateMatrices(_0023_003DzgEkZi75Aakl3: false);
	}

	internal static void _0023_003DzuvFJnrNKDlc7(Camera _0023_003Dz10qtbIGWAWjL, hiddenLinesViewType _0023_003Dz3kFqAHsu8XZd, double _0023_003DzoMBKEgY_003D, ref Size _0023_003Dz4BrWeV0_003D, ref RectangleF _0023_003Dzl1cXRIw_003D, out int[] _0023_003DzVYKAyIXbkWOU)
	{
		_0023_003Dz4BrWeV0_003D = new Size((int)((double)_0023_003Dz4BrWeV0_003D.Width * _0023_003DzoMBKEgY_003D), (int)((double)_0023_003Dz4BrWeV0_003D.Height * _0023_003DzoMBKEgY_003D));
		_0023_003Dz10qtbIGWAWjL.ZoomFactor *= _0023_003DzoMBKEgY_003D;
		if (_0023_003Dz3kFqAHsu8XZd == hiddenLinesViewType.Extents)
		{
			if (_0023_003Dz4BrWeV0_003D.Width == 0 || _0023_003Dz4BrWeV0_003D.Height == 0)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986358));
			}
			_0023_003Dzl1cXRIw_003D = new Rectangle(0, 0, _0023_003Dz4BrWeV0_003D.Width, _0023_003Dz4BrWeV0_003D.Height);
		}
		else
		{
			if (_0023_003Dzl1cXRIw_003D.Width == 0f || _0023_003Dzl1cXRIw_003D.Height == 0f)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986331));
			}
			_0023_003Dzl1cXRIw_003D = new RectangleF((float)((double)_0023_003Dzl1cXRIw_003D.X * _0023_003DzoMBKEgY_003D), (float)((double)_0023_003Dzl1cXRIw_003D.Y * _0023_003DzoMBKEgY_003D), (float)((double)_0023_003Dzl1cXRIw_003D.Width * _0023_003DzoMBKEgY_003D), (float)((double)_0023_003Dzl1cXRIw_003D.Height * _0023_003DzoMBKEgY_003D));
		}
		_0023_003Dz10qtbIGWAWjL.UpdateSize(_0023_003Dz4BrWeV0_003D);
		_0023_003Dz10qtbIGWAWjL.RecomputeViewport(_0023_003Dz4BrWeV0_003D);
		_0023_003Dz10qtbIGWAWjL.UpdateMatrices(_0023_003DzgEkZi75Aakl3: false);
		_0023_003DzVYKAyIXbkWOU = _0023_003DziNJ_4d0rqJ74(_0023_003Dz4BrWeV0_003D);
	}

	private static Rectangle _0023_003DzclStHcfnvCLN(Size _0023_003Dz14lzA48_003D)
	{
		int[] array = _0023_003DziNJ_4d0rqJ74(_0023_003Dz14lzA48_003D);
		return new Rectangle(array[0], array[1], array[2], array[3]);
	}

	internal static int[] _0023_003DziNJ_4d0rqJ74(Size _0023_003Dz14lzA48_003D)
	{
		return new int[4] { 0, 0, _0023_003Dz14lzA48_003D.Width, _0023_003Dz14lzA48_003D.Height };
	}

	internal void _0023_003DzPOJsk28mpsMNtfD8Bw_003D_003D(Plane _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzOXtv5E4RqNjMzantA8yrswU_003D = _0023_003DzPzO_0024GUk_003D;
	}

	internal static void _0023_003DzF6xWLztjwz7t(List<SilhoWireAndTriangleData> _0023_003DzUDyVHNIE2d897cDYtxFoKYI_003D, out Point2D _0023_003DzDPcjoBJLcqli, out Point2D _0023_003Dz_0024N_0024yKptW9BoC)
	{
		_0023_003DzDPcjoBJLcqli = Point2D.MaxValue;
		_0023_003Dz_0024N_0024yKptW9BoC = Point2D.MinValue;
		for (int i = 0; i < _0023_003DzUDyVHNIE2d897cDYtxFoKYI_003D.Count; i++)
		{
			SilhoWireAndTriangleData silhoWireAndTriangleData = _0023_003DzUDyVHNIE2d897cDYtxFoKYI_003D[i];
			for (int j = 0; j < silhoWireAndTriangleData.ScreenVertices.GetLength(0); j++)
			{
				double num = silhoWireAndTriangleData.ScreenVertices[j, 0];
				double num2 = silhoWireAndTriangleData.ScreenVertices[j, 1];
				if (num < _0023_003DzDPcjoBJLcqli.X)
				{
					_0023_003DzDPcjoBJLcqli.X = num;
				}
				if (num > _0023_003Dz_0024N_0024yKptW9BoC.X)
				{
					_0023_003Dz_0024N_0024yKptW9BoC.X = num;
				}
				if (num2 < _0023_003DzDPcjoBJLcqli.Y)
				{
					_0023_003DzDPcjoBJLcqli.Y = num2;
				}
				if (num2 > _0023_003Dz_0024N_0024yKptW9BoC.Y)
				{
					_0023_003Dz_0024N_0024yKptW9BoC.Y = num2;
				}
			}
		}
	}

	internal static void _0023_003DzF6xWLztjwz7t<T, Q, V>(List<T> _0023_003DzyIUKu5w_003D, List<Q> _0023_003Dz8jECbYImlLYXoNhrMQ_003D_003D, List<V> _0023_003DzpbkolymgnLli, out Point2D _0023_003DzDPcjoBJLcqli, out Point2D _0023_003Dz_0024N_0024yKptW9BoC) where T : _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D where Q : _0023_003Dzuk2hG_Czem6GbXMxohg8jZ6A_00246QN where V : _0023_003DzjEyXBWtBsIsdFVXgrbBpl67eaIBU
	{
		_0023_003DzDPcjoBJLcqli = Point2D.MaxValue;
		_0023_003Dz_0024N_0024yKptW9BoC = Point2D.MinValue;
		_0023_003Dz1d5Era_0024dE60D(_0023_003DzyIUKu5w_003D, _0023_003Dz8jECbYImlLYXoNhrMQ_003D_003D, _0023_003DzpbkolymgnLli, _0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC);
	}

	internal static void _0023_003Dz1d5Era_0024dE60D<T, Q, V>(List<T> _0023_003DzyIUKu5w_003D, List<Q> _0023_003Dz8jECbYImlLYXoNhrMQ_003D_003D, List<V> _0023_003DzpbkolymgnLli, Point2D _0023_003DzDPcjoBJLcqli, Point2D _0023_003Dz_0024N_0024yKptW9BoC) where T : _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D where Q : _0023_003Dzuk2hG_Czem6GbXMxohg8jZ6A_00246QN where V : _0023_003DzjEyXBWtBsIsdFVXgrbBpl67eaIBU
	{
		List<Point2D> list = new List<Point2D>();
		if (_0023_003DzyIUKu5w_003D != null)
		{
			foreach (T item in _0023_003DzyIUKu5w_003D)
			{
				list.AddRange(_0023_003Dz5qFihJK3ui08U0cFuA_003D_003D(item));
			}
		}
		if (_0023_003Dz8jECbYImlLYXoNhrMQ_003D_003D != null)
		{
			foreach (Q item2 in _0023_003Dz8jECbYImlLYXoNhrMQ_003D_003D)
			{
				foreach (_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT item3 in item2._0023_003DzqPk52tIIDIJe())
				{
					list.AddRange(_0023_003Dz5qFihJK3ui08U0cFuA_003D_003D(item3));
				}
			}
		}
		if (_0023_003DzpbkolymgnLli != null)
		{
			foreach (V item4 in _0023_003DzpbkolymgnLli)
			{
				foreach (_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT item5 in item4._0023_003DzqPk52tIIDIJe())
				{
					list.AddRange(_0023_003Dz5qFihJK3ui08U0cFuA_003D_003D(item5));
				}
			}
		}
		_0023_003DzeElN68b7E_0024CX(list, _0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC);
	}

	protected internal static void UpdateExtents2DForHdlCurves<T>(IList<T> lines, Point2D boxMin, Point2D boxMax) where T : HiddenLinesView.HdlCurve
	{
		List<Point2D> list = new List<Point2D>();
		foreach (T line in lines)
		{
			if (line is HiddenLinesView.HdlLinearPath hdlLinearPath)
			{
				list.AddRange(hdlLinearPath.Vertices);
			}
			else if (line is HiddenLinesView.HdlPoint hdlPoint)
			{
				list.Add(hdlPoint.Vertex);
			}
			else if (line is HiddenLinesView.HdlArc hdlArc)
			{
				list.Add(new Point2D(hdlArc.Center.X + hdlArc.Radius, hdlArc.Center.Y + hdlArc.Radius));
				list.Add(new Point2D(hdlArc.Center.X - hdlArc.Radius, hdlArc.Center.Y - hdlArc.Radius));
			}
		}
		_0023_003DzeElN68b7E_0024CX(list, boxMin, boxMax);
	}

	protected internal static void UpdateExtents2DForHdlEntities<T, Q, V>(IList<T> lines, IList<Q> pictures, IList<V> texts, Point2D boxMin, Point2D boxMax) where T : HiddenLinesView.HdlCurve where Q : HiddenLinesView.HdlPicture where V : HiddenLinesView.HdlText
	{
		List<Point2D> list = new List<Point2D>();
		foreach (T line in lines)
		{
			if (line is HiddenLinesView.HdlLinearPath hdlLinearPath)
			{
				list.AddRange(hdlLinearPath.Vertices);
			}
			else if (line is HiddenLinesView.HdlPoint hdlPoint)
			{
				list.Add(hdlPoint.Vertex);
			}
			else if (line is HiddenLinesView.HdlArc hdlArc)
			{
				list.Add(new Point2D(hdlArc.Center.X + hdlArc.Radius, hdlArc.Center.Y + hdlArc.Radius));
				list.Add(new Point2D(hdlArc.Center.X - hdlArc.Radius, hdlArc.Center.Y - hdlArc.Radius));
			}
		}
		if (pictures != null)
		{
			foreach (Q picture in pictures)
			{
				foreach (_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT item in picture._0023_003DzqPk52tIIDIJe())
				{
					list.AddRange(_0023_003Dz5qFihJK3ui08U0cFuA_003D_003D(item));
				}
			}
		}
		if (texts != null)
		{
			foreach (V text in texts)
			{
				foreach (_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT item2 in text._0023_003DzqPk52tIIDIJe())
				{
					list.AddRange(_0023_003Dz5qFihJK3ui08U0cFuA_003D_003D(item2));
				}
			}
		}
		_0023_003DzeElN68b7E_0024CX(list, boxMin, boxMax);
	}

	internal static void _0023_003DzeElN68b7E_0024CX(List<Point2D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, Point2D _0023_003DzDPcjoBJLcqli, Point2D _0023_003Dz_0024N_0024yKptW9BoC)
	{
		foreach (Point2D item in _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
		{
			if (item.X < _0023_003DzDPcjoBJLcqli.X)
			{
				_0023_003DzDPcjoBJLcqli.X = item.X;
			}
			if (item.X > _0023_003Dz_0024N_0024yKptW9BoC.X)
			{
				_0023_003Dz_0024N_0024yKptW9BoC.X = item.X;
			}
			if (item.Y < _0023_003DzDPcjoBJLcqli.Y)
			{
				_0023_003DzDPcjoBJLcqli.Y = item.Y;
			}
			if (item.Y > _0023_003Dz_0024N_0024yKptW9BoC.Y)
			{
				_0023_003Dz_0024N_0024yKptW9BoC.Y = item.Y;
			}
		}
	}

	internal static Point2D[] _0023_003Dz5qFihJK3ui08U0cFuA_003D_003D(_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT _0023_003DzQ9zpGF0_003D)
	{
		return new Point2D[2]
		{
			new Point2D(_0023_003DzQ9zpGF0_003D._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0], _0023_003DzQ9zpGF0_003D._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[1]),
			new Point2D(_0023_003DzQ9zpGF0_003D._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[3], _0023_003DzQ9zpGF0_003D._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[4])
		};
	}

	protected internal virtual float PenWidth(lineType lineType)
	{
		return 0f;
	}

	public double ViewToWorldConversion()
	{
		if (boxMax == null || boxMin == null)
		{
			return 1.0;
		}
		double[] array = new double[3];
		double[] array2 = new double[3];
		double num = boxMax.X - boxMin.X;
		double num2 = boxMax.Y - boxMin.Y;
		double _0023_003Dzm3rc4SA8WtT = 0.0;
		double _0023_003Dzm3rc4SA8WtT2 = 0.0;
		double _0023_003DzOM5CofBvYOXf = 0.0;
		double _0023_003DzOM5CofBvYOXf2 = 0.0;
		double num3;
		if (num > num2)
		{
			_0023_003Dzm3rc4SA8WtT = boxMin.X;
			_0023_003Dzm3rc4SA8WtT2 = boxMax.X;
			num3 = num;
		}
		else
		{
			_0023_003DzOM5CofBvYOXf = boxMin.Y;
			_0023_003DzOM5CofBvYOXf2 = boxMax.Y;
			num3 = num2;
		}
		Camera.UnProject(_0023_003DzVYKAyIXbkWOU, _0023_003Dzm3rc4SA8WtT, _0023_003DzOM5CofBvYOXf, 0.0, out array[0], out array[1], out array[2]);
		Camera.UnProject(_0023_003DzVYKAyIXbkWOU, _0023_003Dzm3rc4SA8WtT2, _0023_003DzOM5CofBvYOXf2, 0.0, out array2[0], out array2[1], out array2[2]);
		return new Vector3D(array[0] - array2[0], array[1] - array2[1], array[2] - array2[2]).Length / num3;
	}

	internal bool _0023_003Dza5erRGs_0024Kve7()
	{
		if (!FillTexts)
		{
			return FillRegions;
		}
		return true;
	}

	protected internal virtual GfxAttributesWire GetGfxAttributes()
	{
		return new GfxAttributesWire(Color.Black, Layers);
	}
}
