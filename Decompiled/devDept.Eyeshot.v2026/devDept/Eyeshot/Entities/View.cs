using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using devDept.Eyeshot.Milling;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public abstract class View : BlockReference
{
	private double _scale = 0.2;

	internal viewType ViewType = viewType.Other;

	internal Size viewportSize;

	private int _dpi = 600;

	private bool _shadow;

	internal Point3D[] boundingFrameVertices;

	private double _x;

	private double _y;

	private List<Point3D> _verticesForDirtyViewMarker;

	public static byte DefaultFreezeAlpha = 128;

	public bool HasChanged { get; } = true;

	public List<Tuple<Stack<BlockReference>, Entity>> EntitiesToHide { get; set; } = new List<Tuple<Stack<BlockReference>, Entity>>();

	public Camera Camera { get; }

	public double Width { get; }

	public double Height { get; }

	public RectangleF Window { get; }

	internal Point3D WindowCenter { get; set; }

	public double X
	{
		get
		{
			return _x;
		}
		set
		{
			_x = value;
			_0023_003DzNAySqYM_003D();
		}
	}

	public double Y
	{
		get
		{
			return _y;
		}
		set
		{
			_y = value;
			_0023_003DzNAySqYM_003D();
		}
	}

	public new virtual double Scale
	{
		get
		{
			return _scale;
		}
		set
		{
			_0023_003DzUBcyrssJEGAK(Width / _scale * value);
			_0023_003DzBEcDMzq6J80l(Height / _scale * value);
			_scale = value;
			_0023_003DzNAySqYM_003D();
		}
	}

	public int Dpi
	{
		get
		{
			return _dpi;
		}
		set
		{
			_dpi = value;
			_0023_003DzDaxeAiK9rC4V(_0023_003DzPzO_0024GUk_003D: true);
		}
	}

	public bool Shadow
	{
		get
		{
			return _shadow;
		}
		set
		{
			_shadow = value;
			_0023_003DzDaxeAiK9rC4V(_0023_003DzPzO_0024GUk_003D: true);
		}
	}

	internal abstract AutodeskProperties.visualStyleType visualStyleMode { get; set; }

	public byte FreezeAlpha { get; set; } = DefaultFreezeAlpha;

	protected View(double x, double y, viewType standardView, double scale, string name, double width = 0.0, double height = 0.0)
		: base(x, y, 0.0, name, 0.0)
	{
		ViewType = standardView;
		Camera _0023_003Dz10qtbIGWAWjL = new Camera(Point3D.Origin, 0.0, Camera.GetViewRotation(standardView), projectionType.Orthographic, 0.0, 1.0);
		_0023_003DztGdcVOA_003D(x, y, _0023_003Dz10qtbIGWAWjL, scale, name, width, height, null, null);
	}

	protected View(double x, double y, Camera camera, double scale, string name, double width = 0.0, double height = 0.0)
		: base(x, y, 0.0, name, 0.0)
	{
		_0023_003DztGdcVOA_003D(x, y, camera, scale, name, width, height, null, null);
	}

	protected View(double x, double y, Camera camera, double scale, string name, Size viewportSize)
		: base(x, y, 0.0, name, 0.0)
	{
		_0023_003DztGdcVOA_003D(x, y, camera, scale, name, 0.0, 0.0, null, viewportSize);
	}

	protected View(double x, double y, Camera camera, double scale, string name, RectangleF window, Size viewportSize)
		: base(x, y, 0.0, name, 0.0)
	{
		_0023_003DztGdcVOA_003D(x, y, camera, scale, name, 0.0, 0.0, window, viewportSize);
	}

	protected View(View another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		_0023_003DzXs_0024UXorrEwQq((Camera)another.Camera.Clone());
		_0023_003DzUBcyrssJEGAK(another.Width);
		_0023_003DzBEcDMzq6J80l(another.Height);
		_0023_003DzBZEKdN8_003D(another.Window);
		WindowCenter = another.WindowCenter;
		_scale = another.Scale;
		X = another.X;
		Y = another.Y;
		_0023_003DzDaxeAiK9rC4V(another.HasChanged);
		_dpi = another._dpi;
		_shadow = another._shadow;
		FreezeAlpha = another.FreezeAlpha;
	}

	protected internal View(ViewSurrogate surrogate)
		: base(surrogate)
	{
	}

	protected View(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_x = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981817));
		_y = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302912525));
		_0023_003DzXs_0024UXorrEwQq((Camera)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982685), typeof(Camera)));
		ViewType = (viewType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982668), typeof(viewType));
		_scale = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956350));
		_0023_003DzUBcyrssJEGAK(info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974266)));
		_0023_003DzBEcDMzq6J80l(info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974246)));
		_0023_003DzBZEKdN8_003D((RectangleF)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982905), typeof(RectangleF)));
		WindowCenter = (Point3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982888), typeof(Point3D));
		_0023_003DzDaxeAiK9rC4V(info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982873)));
		_dpi = info.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982860));
		_shadow = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982838));
		FreezeAlpha = info.GetByte(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982817));
		EntitiesToHide = (List<Tuple<Stack<BlockReference>, Entity>>)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982803), typeof(List<Tuple<Stack<BlockReference>, Entity>>));
	}

	internal void _0023_003DzDaxeAiK9rC4V(bool _0023_003DzPzO_0024GUk_003D)
	{
		HasChanged = _0023_003DzPzO_0024GUk_003D;
	}

	internal bool _0023_003Dz83DhkJo5tfYe()
	{
		return ViewType != viewType.Other;
	}

	internal void _0023_003DzXs_0024UXorrEwQq(Camera _0023_003DzPzO_0024GUk_003D)
	{
		Camera = _0023_003DzPzO_0024GUk_003D;
	}

	internal void _0023_003DzUBcyrssJEGAK(double _0023_003DzPzO_0024GUk_003D)
	{
		Width = _0023_003DzPzO_0024GUk_003D;
	}

	internal void _0023_003DzBEcDMzq6J80l(double _0023_003DzPzO_0024GUk_003D)
	{
		Height = _0023_003DzPzO_0024GUk_003D;
	}

	internal void _0023_003DzBZEKdN8_003D(RectangleF _0023_003DzPzO_0024GUk_003D)
	{
		Window = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003DzNAySqYM_003D()
	{
		RegenMode = regenType.RegenAndCompile;
		base.Transformation = new Translation(_x, _y) * new Scaling(_scale);
	}

	internal float _0023_003DztW86fAgbAiheM10M56ksjfw_003D()
	{
		return Math.Min((float)(int)FreezeAlpha / 255f, 0.9999f);
	}

	private void _0023_003DztGdcVOA_003D(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, Camera _0023_003Dz10qtbIGWAWjL, double _0023_003DzoMBKEgY_003D, string _0023_003DzS_00246o7tc_003D, double _0023_003Dz6tVBpdk_003D, double _0023_003DzvAxV_0024Ic_003D, RectangleF? _0023_003Dzl1cXRIw_003D, Size? _0023_003Dzd_0024jeBII_003D)
	{
		if (_0023_003Dz10qtbIGWAWjL != null && _0023_003Dz10qtbIGWAWjL.ProjectionMode == projectionType.Perspective && !_0023_003Dzd_0024jeBII_003D.HasValue && _0023_003Dz6tVBpdk_003D == 0.0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982794));
		}
		base.BlockName = _0023_003DzS_00246o7tc_003D;
		_x = _0023_003DzBJFJHwk_003D;
		_y = _0023_003Dz40R7bAU_003D;
		_0023_003DzXs_0024UXorrEwQq(_0023_003Dz10qtbIGWAWjL);
		_0023_003DzUBcyrssJEGAK(_0023_003Dz6tVBpdk_003D);
		_0023_003DzBEcDMzq6J80l(_0023_003DzvAxV_0024Ic_003D);
		_0023_003DzBZEKdN8_003D(_0023_003Dzl1cXRIw_003D.HasValue ? _0023_003Dzl1cXRIw_003D.Value : RectangleF.Empty);
		if (_0023_003Dz10qtbIGWAWjL != null && _0023_003Dz10qtbIGWAWjL.ProjectionMode == projectionType.Perspective)
		{
			viewportSize = (_0023_003Dzd_0024jeBII_003D.HasValue ? _0023_003Dzd_0024jeBII_003D.Value : new Size((int)_0023_003Dz6tVBpdk_003D, (int)_0023_003DzvAxV_0024Ic_003D));
		}
		else
		{
			viewportSize = ((_0023_003Dzl1cXRIw_003D.HasValue && _0023_003Dzd_0024jeBII_003D.HasValue) ? _0023_003Dzd_0024jeBII_003D.Value : new Size(5000, 5000));
		}
		_scale = _0023_003DzoMBKEgY_003D;
		_0023_003DzNAySqYM_003D();
	}

	internal Block GetPlaceHolderBlock(string _0023_003DzdQ5Ap5HApqhaN29NLA_003D_003D, string _0023_003DzzHDwAYM4aWbN = null)
	{
		Block block = new Block(base.BlockName);
		block.Entities.Add(new Text(Plane.XY, string.IsNullOrEmpty(_0023_003DzzHDwAYM4aWbN) ? base.BlockName : _0023_003DzzHDwAYM4aWbN, Width * 0.05, Text.alignmentType.MiddleCenter)
		{
			LayerName = _0023_003DzdQ5Ap5HApqhaN29NLA_003D_003D
		});
		block.Entities.Add(new LinearPath((0.0 - Width) / 2.0, (0.0 - Height) / 2.0, Width, Height)
		{
			LayerName = _0023_003DzdQ5Ap5HApqhaN29NLA_003D_003D
		});
		block.Entities.Scale(1.0 / Scale);
		return block;
	}

	protected virtual void DrawMarkerForDirty(DrawParams drawParams)
	{
		if (_verticesForDirtyViewMarker != null)
		{
			for (int i = 0; i < _verticesForDirtyViewMarker.Count; i += 2)
			{
				drawParams.RenderContext.DrawLine(_verticesForDirtyViewMarker[i], _verticesForDirtyViewMarker[i + 1]);
			}
		}
	}

	private void _0023_003Dz8ZvkZsUdBr4Nx9R_0024KJxwxtw_003D(Sheet _0023_003Dzow3wazApPFf_0024)
	{
		_verticesForDirtyViewMarker = new List<Point3D>();
		double num = boundingFrameVertices[1].X - boundingFrameVertices[0].X;
		double num2 = boundingFrameVertices[3].Y - boundingFrameVertices[0].Y;
		List<Point3D> list = boundingFrameVertices.ToList();
		list.Add(list.First());
		LinearPath linearPath = new LinearPath(list);
		double num3 = 0.02 * Math.Max(num, num2);
		ICurve curve = linearPath.Offset(0.0 - num3)[0];
		Region region = new Region(linearPath, curve);
		region.Regen(0.1);
		double _0023_003Dz6pajdGM_003D = Math.PI / 4.0;
		double num4 = _0023_003Dzs3MuAPRjIeXNWinss4aiMzQ_003D(_0023_003Dzow3wazApPFf_0024.Units);
		double num5 = 2.0 / num4;
		double num6 = Math.Sqrt(Math.Pow(num, 2.0) + Math.Pow(num2, 2.0));
		double num7 = Math.Sqrt(Math.Pow(_0023_003Dzow3wazApPFf_0024.Width, 2.0) + Math.Pow(_0023_003Dzow3wazApPFf_0024.Height, 2.0));
		if (num6 > num7)
		{
			num5 *= num6 / num7;
		}
		foreach (List<Line> item in Machining._0023_003DzIBirOvc_003D(region, _0023_003Dz6pajdGM_003D, num5, (Machining._0023_003DzdHAEsWFt2rbg)0, null))
		{
			foreach (Line item2 in item)
			{
				_verticesForDirtyViewMarker.Add(item2.StartPoint);
				_verticesForDirtyViewMarker.Add(item2.EndPoint);
			}
		}
	}

	private double _0023_003Dzs3MuAPRjIeXNWinss4aiMzQ_003D(linearUnitsType _0023_003DzxF_I_0024aLJiht_0024)
	{
		return Utility.GetLinearUnitsConversionFactor(_0023_003DzxF_I_0024aLJiht_0024, linearUnitsType.Millimeters);
	}

	protected internal override void Draw(DrawEntitiesParams myParams, WorkspaceDrawCallback drawCall)
	{
		IWorkspaceInternal workspaceInternal = myParams._0023_003DzHwUoFCUb88ry();
		bool selected = workspaceInternal.IsSelected(myParams.DrawParams.ParentSelected, myParams.DrawParams, this);
		if (workspaceInternal.ShouldDrawAsSelected(selected, myParams.DrawParams))
		{
			DrawParams drawParams = myParams.DrawParams;
			Color currentWireColor = drawParams.RenderContext.CurrentWireColor;
			ushort pattern = 65280;
			float currentLineWidth = drawParams.RenderContext.CurrentLineWidth;
			drawParams.RenderContext.SetColorWireframe(drawParams.IsDrawingForHalo ? RenderContextBase.selectionWithoutHaloColor : drawParams.SelectionColor);
			drawParams.RenderContext.SetLineStipple(1, pattern, drawParams.Viewport.Camera);
			drawParams.RenderContext.SetLineSize(1f);
			drawParams.RenderContext.EnableLineStipple(enable: true);
			drawParams.RenderContext.DrawQuadsOutlines(boundingFrameVertices);
			drawParams.RenderContext.EnableLineStipple(enable: false);
			if (HasChanged)
			{
				DrawMarkerForDirty(drawParams);
			}
			drawParams.RenderContext.SetColorWireframe(currentWireColor);
			drawParams.RenderContext.SetLineSize(currentLineWidth);
		}
		if (myParams.DrawParams.SelectionStatus != selectionStatusType.Temporary)
		{
			base.Draw(myParams, drawCall);
		}
	}

	private void _0023_003DzGD3o0fj4XRxELlVUE7RCVLs_003D()
	{
		int num;
		Point3D point3D;
		if (base.BoxMax != Point3D.MinValue)
		{
			num = ((base.BoxMin != Point3D.MaxValue) ? 1 : 0);
			if (num != 0)
			{
				point3D = Point3D.MidPoint(base.BoxMin, base.BoxMax);
				goto IL_0055;
			}
		}
		else
		{
			num = 0;
		}
		point3D = new Point3D(X, Y, 0.0);
		goto IL_0055;
		IL_0055:
		Point3D point3D2 = point3D;
		double num2 = ((num != 0) ? ((base.BoxMax.X - base.BoxMin.X) / 2.0) : (Width / 2.0));
		double num3 = ((num != 0) ? ((base.BoxMax.Y - base.BoxMin.Y) / 2.0) : (Height / 2.0));
		double num4 = 0.15 * Math.Max(num2, num3);
		num2 += num4;
		num3 += num4;
		boundingFrameVertices = new Point3D[4];
		boundingFrameVertices[0] = new Point3D(point3D2.X - num2, point3D2.Y - num3);
		boundingFrameVertices[1] = new Point3D(point3D2.X + num2, point3D2.Y - num3);
		boundingFrameVertices[2] = new Point3D(point3D2.X + num2, point3D2.Y + num3);
		boundingFrameVertices[3] = new Point3D(point3D2.X - num2, point3D2.Y + num3);
	}

	protected internal override void DrawForSelection(DrawEntitiesParams myParams, WorkspaceDrawForSelectionCallback drawCall)
	{
		if (!((DrawForSelectionParams)myParams.DrawParams).LeafSelection)
		{
			shaderType currentShader = myParams.DrawParams.RenderContext.CurrentShader;
			myParams.DrawParams.RenderContext.SetShader(shaderType.NoLights);
			myParams.DrawParams.RenderContext.DrawTrianglesFan(boundingFrameVertices, Vector3D.AxisZ);
			myParams.DrawParams.RenderContext.SetShader(currentShader);
		}
		base.DrawForSelection(myParams, drawCall);
	}

	internal override bool IntersectEdgeOrIsoline(FrustumParams _0023_003DzELu0Pss_003D)
	{
		return false;
	}

	internal override bool IntersectEdgeOrIsolineScreenPolygon(ScreenPolygonParams _0023_003DzELu0Pss_003D)
	{
		return false;
	}

	protected internal override bool AllVerticesInFrustum(FrustumParams data)
	{
		if (Utility.AllVerticesInFrustum(data, boundingFrameVertices, boundingFrameVertices.Length))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool AllVerticesInScreenPolygon(ScreenPolygonParams data)
	{
		if (Utility.AllVerticesInScreenPolygon(data, boundingFrameVertices, boundingFrameVertices.Length))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool InsideOrCrossingFrustum(FrustumParams data)
	{
		if (Entity.InsideOrCrossingFrustumInternal(data.Frustum, data.Transformation, boundingFrameVertices, boundingFrameVertices.Length, 1))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool InsideOrCrossingScreenPolygon(ScreenPolygonParams data)
	{
		if (Entity.InsideOrCrossingScreenPolygonInternal(data, boundingFrameVertices, boundingFrameVertices.Length, 1))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool ThroughTriangle(FrustumParams data)
	{
		if (Entity.ThroughTriangleQuad(data, boundingFrameVertices))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool ThroughTriangleScreenPolygon(ScreenPolygonParams data)
	{
		if (Entity.ThroughTriangleScreenPolygonQuad(boundingFrameVertices, data))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool ComputeBoundingBox(TraversalParams data, out Point3D boxMin, out Point3D boxMax)
	{
		bool result = base.ComputeBoundingBox(data, out boxMin, out boxMax);
		ComputeRectangleVerticesForSelection(((DrawingDocument)data.Document).ActiveSheet);
		return result;
	}

	public override void Dispose()
	{
		if (boundingFrameVertices != null)
		{
			boundingFrameVertices = null;
		}
		if (_verticesForDirtyViewMarker != null)
		{
			_verticesForDirtyViewMarker = null;
		}
		base.Dispose();
	}

	protected void ComputeRectangleVerticesForSelection(Sheet sheet)
	{
		_0023_003DzGD3o0fj4XRxELlVUE7RCVLs_003D();
		_0023_003Dz8ZvkZsUdBr4Nx9R_0024KJxwxtw_003D(sheet);
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return null;
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981817), _x);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302912525), _y);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982685), Camera);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982668), ViewType);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956350), _scale);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974266), Width);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974246), Height);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982905), Window);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982888), WindowCenter);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982873), HasChanged);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982860), _dpi);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982838), _shadow);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982817), FreezeAlpha);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982803), EntitiesToHide);
	}
}
