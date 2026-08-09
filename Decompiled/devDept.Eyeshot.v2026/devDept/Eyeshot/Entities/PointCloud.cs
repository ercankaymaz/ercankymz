using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class PointCloud : Entity
{
	public enum drawingStyleType : byte
	{
		Points,
		Lines,
		LineStrip,
		PointsAndLines,
		PointsAndLineStrip
	}

	public enum natureType : byte
	{
		Undefined,
		Plain,
		Multicolor
	}

	private EntityGraphicsData _drawSelected;

	public new Point3D[] Vertices
	{
		get
		{
			return _vertices;
		}
		set
		{
			_vertices = value;
			ComputeNature();
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public natureType Nature { get; }

	public drawingStyleType DrawingStyle { get; set; }

	protected PointCloud()
		: base(entityNatureType.Point)
	{
	}

	public PointCloud(IList<Point3D> points)
		: base(entityNatureType.Point)
	{
		_vertices = new Point3D[points.Count];
		points.CopyTo(_vertices, 0);
	}

	public PointCloud(IList<Point3D> points, float pointSize)
		: base(entityNatureType.Point)
	{
		LineWeight = pointSize;
		LineWeightMethod = colorMethodType.byEntity;
		_vertices = new Point3D[points.Count];
		points.CopyTo(_vertices, 0);
	}

	public PointCloud(int numPoints, natureType nature)
		: base(entityNatureType.Point)
	{
		_vertices = new Point3D[numPoints];
		_0023_003DzScoU3aJTt_0024kunjs7lA_003D_003D(nature);
	}

	public PointCloud(int numPoints, natureType nature, float pointSize)
		: base(entityNatureType.Point)
	{
		LineWeight = pointSize;
		LineWeightMethod = colorMethodType.byEntity;
		_0023_003DzScoU3aJTt_0024kunjs7lA_003D_003D(nature);
		_vertices = new Point3D[numPoints];
	}

	protected PointCloud(PointCloud another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		_0023_003DzScoU3aJTt_0024kunjs7lA_003D_003D(another.Nature);
		DrawingStyle = another.DrawingStyle;
		if (another._vertices != null)
		{
			_vertices = new Point3D[another._vertices.Length];
			for (int i = 0; i < another._vertices.Length; i++)
			{
				_vertices[i] = (Point3D)another._vertices[i].Clone();
			}
		}
	}

	protected internal PointCloud(PointCloudSurrogate surrogate)
		: this()
	{
		_vertices = surrogate.GetVertices();
		if (_vertices == null)
		{
			_vertices = new Point3D[0];
		}
	}

	protected PointCloud(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_0023_003DzScoU3aJTt_0024kunjs7lA_003D_003D((natureType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974849), typeof(natureType)));
		_vertices = (Point3D[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958678), typeof(Point3D[]));
		DrawingStyle = (drawingStyleType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968477), typeof(drawingStyleType));
	}

	public override object Clone()
	{
		return new PointCloud(this);
	}

	public override object CloneWithTessellation()
	{
		return new PointCloud(this, RegenMode != regenType.RegenAndCompile);
	}

	private protected override void _0023_003DziiyOI32qB_0024yh69HaXQ_003D_003D(Entity _0023_003Dzb7SPTpc_003D)
	{
	}

	internal void _0023_003DzScoU3aJTt_0024kunjs7lA_003D_003D(natureType _0023_003DzPzO_0024GUk_003D)
	{
		Nature = _0023_003DzPzO_0024GUk_003D;
	}

	public void ComputeNature()
	{
		if (_vertices != null && _vertices.Length != 0 && !(_vertices[0] == null))
		{
			if (_vertices[0] is PointRGB)
			{
				_0023_003DzScoU3aJTt_0024kunjs7lA_003D_003D(natureType.Multicolor);
			}
			else
			{
				_0023_003DzScoU3aJTt_0024kunjs7lA_003D_003D(natureType.Plain);
			}
		}
	}

	public void FitLine(out Point3D p, out Vector3D v)
	{
		Utility.FitLine(_vertices, out p, out v);
	}

	public void FitCircle(out Plane pln, out double radius)
	{
		Utility.FitCircle((IList<Point3D>)_vertices, out pln, out radius);
	}

	public Plane FitPlane()
	{
		return Utility.FitPlane(_vertices);
	}

	public void FitCylinder(bool refineEstimation, out Point3D center, out Vector3D axis, out double radius, out double height)
	{
		Utility.FitCylinder(_vertices, refineEstimation, out center, out axis, out radius, out height);
	}

	public void FitCylinder(bool refineEstimation, out CylindricalSurf cylindrical, out double height)
	{
		Utility.FitCylinder(_vertices, refineEstimation, out var center, out var axis, out var radius, out height);
		Plane plane = new Plane(center, axis);
		cylindrical = new CylindricalSurf(plane, radius);
	}

	public bool FitSphere(out Point3D center, out double radius)
	{
		return Utility.FitSphere(_vertices, out center, out radius);
	}

	public bool FitSphere(out SphericalSurf spherical)
	{
		Point3D center;
		double radius;
		bool result = Utility.FitSphere(_vertices, out center, out radius);
		spherical = new SphericalSurf(center, Vector3D.AxisZ, Vector3D.AxisX, radius);
		return result;
	}

	public void FitCone(out Point3D center, out Vector3D axis, out double halfAngle, out double radius)
	{
		Utility.FitCone(_vertices, out center, out axis, out halfAngle, out radius);
	}

	public void FitCone(out ConicalSurf conical)
	{
		Utility.FitCone(_vertices, out var center, out var axis, out var halfAngle, out var radius);
		Plane plane = new Plane(center, axis);
		conical = new ConicalSurf(plane, radius, 0.0 - Math.Abs(halfAngle));
	}

	public bool FitTorus(out Point3D center, out Vector3D axis, out double majorRadius, out double minorRadius)
	{
		return Utility.FitTorus(_vertices, out center, out axis, out majorRadius, out minorRadius);
	}

	public bool FitTorus(out ToroidalSurf toroidal)
	{
		Point3D center;
		Vector3D axis;
		double majorRadius;
		double minorRadius;
		bool result = Utility.FitTorus(_vertices, out center, out axis, out majorRadius, out minorRadius);
		Plane plane = new Plane(center, axis);
		toroidal = new ToroidalSurf(plane, majorRadius, minorRadius);
		return result;
	}

	public override void Regen(RegenParams data)
	{
		ComputeNature();
		base.Regen(data);
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new PointCloudSurrogate(this);
	}

	[SpecialName]
	internal override bool _0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D()
	{
		return Nature != natureType.Undefined;
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974849), Nature);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958678), _vertices);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968477), DrawingStyle);
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode != regenType.RegenAndCompile)
		{
			return new Point3D[2] { base.BoxMin, base.BoxMax };
		}
		return Utility.GetSampling(_vertices);
	}

	protected override void InitGraphicsData(RenderContextBase renderContext)
	{
		base.InitGraphicsData(renderContext);
		if (_drawSelected == null)
		{
			_drawSelected = renderContext.CreateEntityGraphicsData(this);
		}
	}

	public override void Dispose()
	{
		base.Dispose();
		_drawSelected?.Dispose();
	}

	protected internal override void Draw(DrawParams data)
	{
		_0023_003DzE6BhEyCW20ng(data, Nature, DrawingStyle, drawData, _drawSelected, this);
	}

	protected internal override void DrawSelected(DrawParams data)
	{
		_0023_003DzPvMAdL67h0nj(data, Nature, DrawingStyle, drawData, _drawSelected);
	}

	protected internal override void DrawWireframeSelected(DrawParams data)
	{
		_0023_003DzPvMAdL67h0nj(data, Nature, DrawingStyle, drawData, _drawSelected);
	}

	protected internal override void DrawForShadow(RenderParams data)
	{
	}

	protected internal override bool InsideOrCrossingFrustum(FrustumParams data)
	{
		int num = _vertices.Length;
		Transformation transformation = data.Transformation;
		PlaneEquation[] frustum = data.Frustum;
		switch (DrawingStyle)
		{
		case drawingStyleType.Points:
		{
			if (transformation == null)
			{
				for (int k = 0; k < num; k++)
				{
					if (Camera.IsInFrustum(_vertices[k], frustum))
					{
						AddSelectedItemLeaf(data);
						return true;
					}
				}
				break;
			}
			for (int l = 0; l < num; l++)
			{
				if (Camera.IsInFrustum(transformation * _vertices[l], frustum))
				{
					AddSelectedItemLeaf(data);
					return true;
				}
			}
			break;
		}
		case drawingStyleType.Lines:
		case drawingStyleType.PointsAndLines:
		{
			if (transformation == null)
			{
				for (int m = 0; m < num - 1; m += 2)
				{
					Segment3D segment = new Segment3D(_vertices[m], _vertices[m + 1]);
					if (Utility.IsSegmentInsideOrCrossing(frustum, segment))
					{
						AddSelectedItemLeaf(data);
						return true;
					}
				}
				break;
			}
			for (int n = 0; n < num - 1; n += 2)
			{
				Segment3D segment = new Segment3D(transformation * _vertices[n], transformation * _vertices[n + 1]);
				if (Utility.IsSegmentInsideOrCrossing(frustum, segment))
				{
					AddSelectedItemLeaf(data);
					return true;
				}
			}
			break;
		}
		case drawingStyleType.LineStrip:
		case drawingStyleType.PointsAndLineStrip:
		{
			if (transformation == null)
			{
				for (int i = 0; i < num - 1; i++)
				{
					Segment3D segment = new Segment3D(_vertices[i], _vertices[i + 1]);
					if (Utility.IsSegmentInsideOrCrossing(frustum, segment))
					{
						AddSelectedItemLeaf(data);
						return true;
					}
				}
				break;
			}
			for (int j = 0; j < num - 1; j++)
			{
				Segment3D segment = new Segment3D(transformation * _vertices[j], transformation * _vertices[j + 1]);
				if (Utility.IsSegmentInsideOrCrossing(frustum, segment))
				{
					AddSelectedItemLeaf(data);
					return true;
				}
			}
			break;
		}
		}
		return false;
	}

	protected internal override bool InsideOrCrossingScreenPolygon(ScreenPolygonParams data)
	{
		int num = _vertices.Length;
		switch (DrawingStyle)
		{
		case drawingStyleType.Points:
		{
			if (data.Transformation == null)
			{
				for (int k = 0; k < num; k++)
				{
					if (Utility._0023_003Dz_0024yfURu187RMm(data.Workspace.RenderContext, _vertices[k], data.ScreenPolygon, data.ModelViewProj, data.ViewFrame))
					{
						AddSelectedItemLeaf(data);
						return true;
					}
				}
				break;
			}
			for (int l = 0; l < num; l++)
			{
				if (Utility._0023_003Dz_0024yfURu187RMm(data.Workspace.RenderContext, data.Transformation * _vertices[l], data.ScreenPolygon, data.ModelViewProj, data.ViewFrame))
				{
					AddSelectedItemLeaf(data);
					return true;
				}
			}
			break;
		}
		case drawingStyleType.Lines:
		case drawingStyleType.PointsAndLines:
		{
			if (data.Transformation == null)
			{
				for (int m = 0; m < num - 1; m += 2)
				{
					if (Utility._0023_003DzCDHgZnw5jGnjOTqKdaPcrb3mQArQ(_vertices[m], _vertices[m + 1], data))
					{
						AddSelectedItemLeaf(data);
						return true;
					}
				}
				break;
			}
			for (int n = 0; n < num - 1; n += 2)
			{
				if (Utility._0023_003DzCDHgZnw5jGnjOTqKdaPcrb3mQArQ(data.Transformation * _vertices[n], data.Transformation * _vertices[n + 1], data))
				{
					AddSelectedItemLeaf(data);
					return true;
				}
			}
			break;
		}
		case drawingStyleType.LineStrip:
		case drawingStyleType.PointsAndLineStrip:
		{
			if (data.Transformation == null)
			{
				for (int i = 0; i < num - 1; i++)
				{
					if (Utility._0023_003DzCDHgZnw5jGnjOTqKdaPcrb3mQArQ(_vertices[i], _vertices[i + 1], data))
					{
						AddSelectedItemLeaf(data);
						return true;
					}
				}
				break;
			}
			for (int j = 0; j < num - 1; j++)
			{
				if (Utility._0023_003DzCDHgZnw5jGnjOTqKdaPcrb3mQArQ(data.Transformation * _vertices[j], data.Transformation * _vertices[j + 1], data))
				{
					AddSelectedItemLeaf(data);
					return true;
				}
			}
			break;
		}
		}
		return false;
	}

	protected internal override void DrawForSelection(DrawForSelectionParams data)
	{
		_0023_003DzPvMAdL67h0nj(data, Nature, DrawingStyle, drawData, _drawSelected);
	}

	protected internal override void SetShader(DrawParams data)
	{
		bool multicolor = data.ShaderParams.Multicolor;
		if (!data.Selected && Nature == natureType.Multicolor && !data.ShaderParams.ColorsModulatedByIntensity)
		{
			data.ShaderParams.Multicolor = true;
		}
		base.SetShader(data);
		data.ShaderParams.Multicolor = multicolor;
	}

	internal static void _0023_003DzE6BhEyCW20ng(DrawParams _0023_003DzELu0Pss_003D, natureType _0023_003DzqHYocffeD0Qdcx1U2A_003D_003D, drawingStyleType _0023_003DzT8nhzjQtDkJY, EntityGraphicsData _0023_003Dzgv_pSOc_003D, EntityGraphicsData _0023_003DzLrLnblTcrxMH, Entity _0023_003DzLGos1_Q_003D)
	{
		float currentLineWidth = _0023_003DzELu0Pss_003D.RenderContext.CurrentLineWidth;
		switch (_0023_003DzqHYocffeD0Qdcx1U2A_003D_003D)
		{
		case natureType.Plain:
			switch (_0023_003DzT8nhzjQtDkJY)
			{
			case drawingStyleType.Points:
				_0023_003DzELu0Pss_003D.RenderContext.DrawIndeterminateAsPoints(_0023_003Dzgv_pSOc_003D);
				break;
			case drawingStyleType.Lines:
				_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(_0023_003DzELu0Pss_003D.RenderContext.CurrentPointSize);
				_0023_003DzELu0Pss_003D.RenderContext.DrawIndeterminateAsLineList(_0023_003Dzgv_pSOc_003D);
				break;
			case drawingStyleType.LineStrip:
				_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(_0023_003DzELu0Pss_003D.RenderContext.CurrentPointSize);
				_0023_003DzELu0Pss_003D.RenderContext.DrawIndeterminateAsLineStrip(_0023_003Dzgv_pSOc_003D);
				break;
			case drawingStyleType.PointsAndLines:
				_0023_003DzELu0Pss_003D.RenderContext.DrawIndeterminateAsPoints(_0023_003Dzgv_pSOc_003D);
				_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(1f);
				_0023_003DzELu0Pss_003D.RenderContext.DrawIndeterminateAsLineList(_0023_003Dzgv_pSOc_003D);
				break;
			case drawingStyleType.PointsAndLineStrip:
				_0023_003DzELu0Pss_003D.RenderContext.DrawIndeterminateAsPoints(_0023_003Dzgv_pSOc_003D);
				_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(1f);
				_0023_003DzELu0Pss_003D.RenderContext.DrawIndeterminateAsLineStrip(_0023_003Dzgv_pSOc_003D);
				break;
			}
			break;
		case natureType.Multicolor:
			_0023_003DzELu0Pss_003D.RenderContext.PushShader();
			_0023_003DzLGos1_Q_003D?.SetShader(_0023_003DzELu0Pss_003D);
			switch (_0023_003DzT8nhzjQtDkJY)
			{
			case drawingStyleType.Points:
				_0023_003DzELu0Pss_003D.RenderContext.DrawIndeterminateAsPoints(_0023_003Dzgv_pSOc_003D);
				break;
			case drawingStyleType.Lines:
				_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(_0023_003DzELu0Pss_003D.RenderContext.CurrentPointSize);
				_0023_003DzELu0Pss_003D.RenderContext.DrawIndeterminateAsLineList(_0023_003Dzgv_pSOc_003D);
				break;
			case drawingStyleType.LineStrip:
				_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(_0023_003DzELu0Pss_003D.RenderContext.CurrentPointSize);
				_0023_003DzELu0Pss_003D.RenderContext.DrawIndeterminateAsLineStrip(_0023_003Dzgv_pSOc_003D);
				break;
			case drawingStyleType.PointsAndLines:
				_0023_003DzELu0Pss_003D.RenderContext.DrawIndeterminateAsPoints(_0023_003Dzgv_pSOc_003D);
				_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(1f);
				_0023_003DzELu0Pss_003D.RenderContext.DrawIndeterminateAsLineList(_0023_003Dzgv_pSOc_003D);
				break;
			case drawingStyleType.PointsAndLineStrip:
				_0023_003DzELu0Pss_003D.RenderContext.DrawIndeterminateAsPoints(_0023_003Dzgv_pSOc_003D);
				_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(1f);
				_0023_003DzELu0Pss_003D.RenderContext.DrawIndeterminateAsLineStrip(_0023_003Dzgv_pSOc_003D);
				break;
			}
			if (_0023_003DzqHYocffeD0Qdcx1U2A_003D_003D == natureType.Multicolor)
			{
				_0023_003DzELu0Pss_003D.RenderContext.SetColorWireframe(Color.Black, force: true);
			}
			_0023_003DzELu0Pss_003D.RenderContext.PopShader();
			break;
		}
		_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(currentLineWidth, setShader: false);
	}

	internal static void _0023_003DzPvMAdL67h0nj(DrawParams _0023_003DzELu0Pss_003D, natureType _0023_003DzqHYocffeD0Qdcx1U2A_003D_003D, drawingStyleType _0023_003DzT8nhzjQtDkJY, EntityGraphicsData _0023_003Dzgv_pSOc_003D, EntityGraphicsData _0023_003DzLrLnblTcrxMH)
	{
		switch (_0023_003DzqHYocffeD0Qdcx1U2A_003D_003D)
		{
		case natureType.Plain:
			_0023_003DzE6BhEyCW20ng(_0023_003DzELu0Pss_003D, _0023_003DzqHYocffeD0Qdcx1U2A_003D_003D, _0023_003DzT8nhzjQtDkJY, _0023_003Dzgv_pSOc_003D, _0023_003DzLrLnblTcrxMH, null);
			break;
		case natureType.Multicolor:
		{
			float currentLineWidth = _0023_003DzELu0Pss_003D.RenderContext.CurrentLineWidth;
			switch (_0023_003DzT8nhzjQtDkJY)
			{
			case drawingStyleType.Points:
				_0023_003DzELu0Pss_003D.RenderContext.DrawIndeterminateAsPoints(_0023_003DzLrLnblTcrxMH);
				break;
			case drawingStyleType.Lines:
				_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(_0023_003DzELu0Pss_003D.RenderContext.CurrentPointSize);
				_0023_003DzELu0Pss_003D.RenderContext.DrawIndeterminateAsLineList(_0023_003DzLrLnblTcrxMH);
				break;
			case drawingStyleType.LineStrip:
				_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(_0023_003DzELu0Pss_003D.RenderContext.CurrentPointSize);
				_0023_003DzELu0Pss_003D.RenderContext.DrawIndeterminateAsLineStrip(_0023_003DzLrLnblTcrxMH);
				break;
			case drawingStyleType.PointsAndLines:
				_0023_003DzELu0Pss_003D.RenderContext.DrawIndeterminateAsPoints(_0023_003DzLrLnblTcrxMH);
				_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(1f);
				_0023_003DzELu0Pss_003D.RenderContext.DrawIndeterminateAsLineList(_0023_003DzLrLnblTcrxMH);
				break;
			case drawingStyleType.PointsAndLineStrip:
				_0023_003DzELu0Pss_003D.RenderContext.DrawIndeterminateAsPoints(_0023_003DzLrLnblTcrxMH);
				_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(1f);
				_0023_003DzELu0Pss_003D.RenderContext.DrawIndeterminateAsLineStrip(_0023_003DzLrLnblTcrxMH);
				break;
			}
			_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(currentLineWidth, setShader: false);
			break;
		}
		}
	}

	public override void Compile(CompileParams data)
	{
		base.Compile(data);
		if (Nature == natureType.Multicolor)
		{
			data.RenderContext.Compile(_drawSelected, _0023_003Dz98HbA5UMZagp, null);
		}
	}

	private void _0023_003Dz98HbA5UMZagp(RenderContextBase _0023_003DzB8iS0QA_003D, object _0023_003DzmPmPjCPqZ3T3)
	{
		_0023_003DzB8iS0QA_003D.DrawPointsIndeterminate(_vertices);
	}

	protected override void DrawEntity(RenderContextBase context, object myParams)
	{
		switch (Nature)
		{
		case natureType.Plain:
			context.DrawPointsIndeterminate(_vertices);
			break;
		case natureType.Multicolor:
			context.DrawPointsRGBIndeterminate(_vertices);
			break;
		}
	}

	internal override void _0023_003Dz_0024_0024rGbexgW9YV(IList<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003Dza_SABTbwi5q2, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, ref int _0023_003DzyzK8swU_003D)
	{
		_0023_003DzCvMCt05pVvqGJGI368UlSvv09UP9pWWmRo3Qh0YGOXCU obj = new _0023_003DzCvMCt05pVvqGJGI368UlSvv09UP9pWWmRo3Qh0YGOXCU(_vertices, _0023_003Dzy2VY7ExflvP_: false, ColorMethod == colorMethodType.byEntity, LayerName, Color);
		obj._0023_003DzqkDCo38_003D(ref _0023_003DzyzK8swU_003D, LayerName);
		obj._0023_003DzsxCTpik_003D(ref _0023_003DzyzK8swU_003D);
		obj._0023_003Dzu9FtIMXgxSrQ(_0023_003Dza_SABTbwi5q2);
	}

	internal override bool AvoidSmallSizeCulling()
	{
		if (_vertices != null)
		{
			return _vertices.Length == 1;
		}
		return false;
	}

	protected internal override void DrawHiddenLines(DrawParams data)
	{
		if (data.viewportInternal.parent.HiddenLines.WireColorMethod == edgeColorMethodType.SingleColor || data.Selected)
		{
			_0023_003DzPvMAdL67h0nj(data, Nature, DrawingStyle, drawData, _drawSelected);
		}
		else
		{
			base.DrawHiddenLines(data);
		}
	}

	protected internal override void DrawHiddenLinesMaterial(RenderParams data)
	{
		DrawHiddenLines(data);
	}

	public FastPointCloud ConvertToFastPointCloud()
	{
		FastPointCloud fastPointCloud = null;
		if (_vertices != null)
		{
			float[] array = new float[_vertices.Length * 3];
			bool flag = _vertices[0] is PointRGB;
			byte[] array2 = null;
			if (flag)
			{
				array2 = new byte[_vertices.Length * 3];
			}
			int num = 0;
			Point3D[] vertices = _vertices;
			foreach (Point3D point3D in vertices)
			{
				array[num] = Convert.ToSingle(point3D.X);
				array[num + 1] = Convert.ToSingle(point3D.Y);
				array[num + 2] = Convert.ToSingle(point3D.Z);
				if (flag)
				{
					PointRGB pointRGB = point3D as PointRGB;
					array2[num] = pointRGB.R;
					array2[num + 1] = pointRGB.G;
					array2[num + 2] = pointRGB.B;
				}
				num += 3;
			}
			fastPointCloud = new FastPointCloud(array, array2);
			fastPointCloud.CopyAttributes(this);
		}
		return fastPointCloud;
	}

	internal override shaderPrimitiveType GetPrimitiveTypeForWireframe(DrawParams _0023_003DzELu0Pss_003D)
	{
		switch (DrawingStyle)
		{
		case drawingStyleType.Lines:
		case drawingStyleType.LineStrip:
			return shaderPrimitiveType.Line;
		case drawingStyleType.Points:
			return shaderPrimitiveType.Point;
		default:
			return shaderPrimitiveType.Point;
		}
	}

	public void CentroidDownsampling(double voxelSize)
	{
		_0023_003DzNoa0CChjZouipNjRMNpaOGI_003D(voxelSize, _0023_003Dzie_0024bpnq3s7I1Lr3RNA_003D_003D: true);
	}

	public void CenterDownsampling(double voxelSize)
	{
		_0023_003DzNoa0CChjZouipNjRMNpaOGI_003D(voxelSize, _0023_003Dzie_0024bpnq3s7I1Lr3RNA_003D_003D: false);
	}

	private void _0023_003DzNoa0CChjZouipNjRMNpaOGI_003D(double _0023_003DzHvAfpUm5f0OK, bool _0023_003Dzie_0024bpnq3s7I1Lr3RNA_003D_003D)
	{
		if (_vertices == null || _vertices.Length == 0)
		{
			return;
		}
		ComputeNature();
		Utility.ComputeBoundingBox(new Identity(), _vertices, out var boxMin, out var boxMax);
		Size3D size3D = new Size3D(boxMin, boxMax);
		int num = (int)(size3D.X / _0023_003DzHvAfpUm5f0OK) + 1;
		int num2 = (int)(size3D.Y / _0023_003DzHvAfpUm5f0OK) + 1;
		int num3 = (int)(size3D.Z / _0023_003DzHvAfpUm5f0OK) + 1;
		List<int>[,,] array = new List<int>[num, num2, num3];
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				for (int k = 0; k < num3; k++)
				{
					array[i, j, k] = new List<int>();
				}
			}
		}
		for (int l = 0; l < _vertices.Length; l++)
		{
			double x = _vertices[l].X;
			double y = _vertices[l].Y;
			double z = _vertices[l].Z;
			array[(int)((x - boxMin.X) / _0023_003DzHvAfpUm5f0OK), (int)((y - boxMin.Y) / _0023_003DzHvAfpUm5f0OK), (int)((z - boxMin.Z) / _0023_003DzHvAfpUm5f0OK)].Add(l);
		}
		List<Point3D> list = new List<Point3D>();
		for (int m = 0; m < num; m++)
		{
			for (int n = 0; n < num2; n++)
			{
				for (int num4 = 0; num4 < num3; num4++)
				{
					List<int> list2 = array[m, n, num4];
					int count = list2.Count;
					if (count <= 0)
					{
						continue;
					}
					int num5 = list2[0];
					if (_0023_003Dzie_0024bpnq3s7I1Lr3RNA_003D_003D)
					{
						double num6 = 0.0;
						double num7 = 0.0;
						double num8 = 0.0;
						foreach (int item in list2)
						{
							num6 += _vertices[item].X;
							num7 += _vertices[item].Y;
							num8 += _vertices[item].Z;
						}
						Point3D point3D = null;
						if (Nature == natureType.Multicolor)
						{
							PointRGB pointRGB = (PointRGB)_vertices[num5];
							Color color = Color.FromArgb(pointRGB.R, pointRGB.G, pointRGB.B);
							point3D = new PointRGB(num6 / (double)count, num7 / (double)count, num8 / (double)count, color);
						}
						else
						{
							point3D = new Point3D(num6 / (double)count, num7 / (double)count, num8 / (double)count);
						}
						list.Add(point3D);
					}
					else
					{
						double x2 = boxMin.X + (double)m * _0023_003DzHvAfpUm5f0OK + _0023_003DzHvAfpUm5f0OK / 2.0;
						double y2 = boxMin.Y + (double)n * _0023_003DzHvAfpUm5f0OK + _0023_003DzHvAfpUm5f0OK / 2.0;
						double z2 = boxMin.Z + (double)num4 * _0023_003DzHvAfpUm5f0OK + _0023_003DzHvAfpUm5f0OK / 2.0;
						Point3D point3D2 = null;
						if (Nature == natureType.Multicolor)
						{
							PointRGB pointRGB2 = (PointRGB)_vertices[num5];
							Color color2 = Color.FromArgb(pointRGB2.R, pointRGB2.G, pointRGB2.B);
							point3D2 = new PointRGB(x2, y2, z2, color2);
						}
						else
						{
							point3D2 = new Point3D(x2, y2, z2);
						}
						list.Add(point3D2);
					}
				}
			}
		}
		_vertices = list.ToArray();
	}
}
