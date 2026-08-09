using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot.Milling;

[Serializable]
public class MachiningPlane : Picture
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzKra28oc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point2D _0023_003DzFRxYk4OWwbvs;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point2D _0023_003DzYD_Yi5DJJpo_0024;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private contentAlignment _0023_003DzIhkvY7s_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz7yYXX6k_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private linearUnitsType _0023_003DzYgMj3fzgkvQU3G5hkg_003D_003D;

	public linearUnitsType Units
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzYgMj3fzgkvQU3G5hkg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzYgMj3fzgkvQU3G5hkg_003D_003D = value;
		}
	}

	public MachiningPlane(double zHeight, string name, devDept.Eyeshot.Entities.Region reg, Color color, contentAlignment alignment)
		: this(zHeight, name, reg.BoxMin, reg.BoxMax, color, alignment)
	{
	}

	public MachiningPlane(double zHeight, string name, Point2D min, Point2D max, Color color, contentAlignment alignment)
		: base(new Plane(new Point3D(0.0, 0.0, zHeight), Vector3D.AxisX, Vector3D.AxisY), 1.0, 1.0, null)
	{
		ColorMethod = colorMethodType.byEntity;
		Color = Color.FromArgb(31, color);
		_0023_003DzKra28oc_003D = zHeight;
		double val = max.X - min.X;
		double val2 = max.Y - min.Y;
		double num = Math.Max(val, val2) * 0.05;
		_0023_003DzFRxYk4OWwbvs = new Point2D(min.X - num, min.Y - num);
		_0023_003DzYD_Yi5DJJpo_0024 = new Point2D(max.X + num, max.Y + num);
		_0023_003Dz7yYXX6k_003D = name;
		_0023_003DzIhkvY7s_003D = alignment;
		base.Lighted = false;
	}

	protected MachiningPlane(MachiningPlane another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		_0023_003DzKra28oc_003D = another._0023_003DzKra28oc_003D;
		_0023_003DzFRxYk4OWwbvs = (Point2D)another._0023_003DzFRxYk4OWwbvs.Clone();
		_0023_003DzYD_Yi5DJJpo_0024 = (Point2D)another._0023_003DzYD_Yi5DJJpo_0024.Clone();
		_0023_003Dz7yYXX6k_003D = another._0023_003Dz7yYXX6k_003D;
		_0023_003DzIhkvY7s_003D = another._0023_003DzIhkvY7s_003D;
		Units = another.Units;
	}

	protected MachiningPlane(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_0023_003DzKra28oc_003D = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302995156));
		_0023_003DzFRxYk4OWwbvs = (Point2D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302995137), typeof(Point2D));
		_0023_003DzYD_Yi5DJJpo_0024 = (Point2D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302995151), typeof(Point2D));
		_0023_003DzIhkvY7s_003D = (contentAlignment)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302995133), typeof(contentAlignment));
		_0023_003Dz7yYXX6k_003D = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951333));
	}

	public override object Clone()
	{
		return new MachiningPlane(this);
	}

	public override object CloneWithTessellation()
	{
		return new MachiningPlane(this, RegenMode != regenType.RegenAndCompile);
	}

	public Mesh ConvertToMesh()
	{
		Mesh mesh = new Mesh(_0023_003Dza7scAbXema1S_UGq_0024Bbgx3s_003D(), new IndexTriangle[2]
		{
			new IndexTriangle(0, 1, 2),
			new IndexTriangle(0, 2, 3)
		});
		mesh.Normals = new Vector3D[2]
		{
			base.Plane.AxisZ,
			base.Plane.AxisZ
		};
		return mesh;
	}

	public override void Regen(RegenParams data)
	{
		if (data.Document?.workspace == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302995091) + GetType().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302995081));
		}
		string text = _0023_003Dz7yYXX6k_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + _0023_003DzKra28oc_003D.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747));
		if (Units != linearUnitsType.Unitless)
		{
			text = text + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + Machining.GetUnitsAbbreviation(Units);
		}
		base.Image = data.Document.workspace.GetMachiningLabelImage(text, Color.White, Color, IntPtr.Zero, out var size);
		double max = new Size2D(_0023_003DzFRxYk4OWwbvs, _0023_003DzYD_Yi5DJJpo_0024).Max;
		base.Height = max / 40.0;
		base.Width = base.Height * (double)size.Width / (double)size.Height;
		base.Regen(data);
		ComputeBoundingBox(new TraversalParams(), out localMin, out localMax);
		UpdateBoundingBoxSphere();
	}

	protected internal override void Draw(DrawParams data)
	{
		bool lighting = data.RenderContext.SetLighting(enable: false);
		if (!data.Selected)
		{
			data.RenderContext.PushShader();
			data.RenderContext.SetShader(shaderType.Standard);
			data.RenderContext.SetColorDiffuse(Color, Color);
		}
		data.RenderContext.DrawTrianglesPlanar(_0023_003Dza7scAbXema1S_UGq_0024Bbgx3s_003D(), new IndexTriangle[2]
		{
			new IndexTriangle(0, 1, 2),
			new IndexTriangle(0, 2, 3)
		}, base.Plane.AxisZ);
		if (!data.Selected)
		{
			data.RenderContext.PopShader();
		}
		data.RenderContext.PushModelView();
		_0023_003DzacB01ck_003D(data.RenderContext);
		if (!data.Selected)
		{
			data.RenderContext.SetLighting(enable: false);
			data.RenderContext.SetColorWireframe(Color.White);
			blendStateType state = data.RenderContext.SetState(blendStateType.NoBlend);
			DrawInternal(data);
			data.RenderContext.SetState(state);
		}
		else
		{
			blendStateType state2 = data.RenderContext.SetState(blendStateType.NoBlend);
			data.RenderContext.Draw(drawData);
			data.RenderContext.SetState(state2);
		}
		data.RenderContext.PopModelView();
		data.RenderContext.SetLighting(lighting);
	}

	protected internal override void DrawFlatSelected(DrawParams data)
	{
		DrawFlat(data);
	}

	protected internal override void DrawFlat(DrawParams data)
	{
		if (!data.Selected)
		{
			data.RenderContext.SetColorWireframe(Color);
		}
		data.RenderContext.DrawTrianglesPlanar(_0023_003Dza7scAbXema1S_UGq_0024Bbgx3s_003D(), new IndexTriangle[2]
		{
			new IndexTriangle(0, 1, 2),
			new IndexTriangle(0, 2, 3)
		}, base.Plane.AxisZ);
		data.RenderContext.PushModelView();
		_0023_003DzacB01ck_003D(data.RenderContext);
		if (!data.Selected)
		{
			bool flag = false;
			bool flag2 = false;
			data.RenderContext.PushShader();
			flag = data.ShaderParams.Texture2D;
			flag2 = data.ShaderParams.Lighting;
			data.ShaderParams.Texture2D = true;
			SetShader(data);
			data.RenderContext.SetColorWireframe(Color.White);
			blendStateType state = data.RenderContext.SetState(blendStateType.NoBlend);
			DrawInternal(data);
			data.RenderContext.SetState(state);
			data.ShaderParams.Texture2D = flag;
			data.ShaderParams.Lighting = flag2;
			data.RenderContext.PopShader();
		}
		else
		{
			blendStateType state2 = data.RenderContext.SetState(blendStateType.NoBlend);
			data.RenderContext.Draw(drawData);
			data.RenderContext.SetState(state2);
		}
		data.RenderContext.PopModelView();
	}

	protected internal override void DrawHiddenLines(DrawParams data)
	{
		DrawForSelectionParams data2 = new DrawForSelectionParams(data.Viewport, data.Blocks);
		DrawForSelection(data2);
	}

	protected internal override void DrawForSelection(DrawForSelectionParams data)
	{
		data.RenderContext.DrawTrianglesPlanar(_0023_003Dza7scAbXema1S_UGq_0024Bbgx3s_003D(), new IndexTriangle[2]
		{
			new IndexTriangle(0, 1, 2),
			new IndexTriangle(0, 2, 3)
		}, base.Plane.AxisZ);
		data.RenderContext.PushModelView();
		_0023_003DzacB01ck_003D(data.RenderContext);
		data.RenderContext.DrawTrianglesPlanar(_vertices, new IndexTriangle[2]
		{
			new IndexTriangle(0, 1, 2),
			new IndexTriangle(0, 2, 3)
		}, base.Plane.AxisZ);
		data.RenderContext.PopModelView();
	}

	private void _0023_003DzacB01ck_003D(RenderContextBase _0023_003DzQdnFby4_003D)
	{
		Vector3D vector3D = null;
		Vector3D vector3D2 = null;
		switch (_0023_003DzIhkvY7s_003D)
		{
		case contentAlignment.TopRight:
			vector3D = base.Plane.AxisX * (_0023_003DzYD_Yi5DJJpo_0024.X - base.Width);
			vector3D2 = base.Plane.AxisY * _0023_003DzYD_Yi5DJJpo_0024.Y;
			break;
		case contentAlignment.TopLeft:
			vector3D = base.Plane.AxisX * _0023_003DzFRxYk4OWwbvs.X;
			vector3D2 = base.Plane.AxisY * _0023_003DzYD_Yi5DJJpo_0024.Y;
			break;
		case contentAlignment.BottomLeft:
			vector3D = base.Plane.AxisX * _0023_003DzFRxYk4OWwbvs.X;
			vector3D2 = base.Plane.AxisY * (_0023_003DzFRxYk4OWwbvs.Y - base.Height);
			break;
		case contentAlignment.BottomRight:
			vector3D = base.Plane.AxisX * (_0023_003DzYD_Yi5DJJpo_0024.X - base.Width);
			vector3D2 = base.Plane.AxisY * (_0023_003DzFRxYk4OWwbvs.Y - base.Height);
			break;
		}
		Vector3D vector3D3 = vector3D + vector3D2;
		_0023_003DzQdnFby4_003D.TranslateMatrixModelView(vector3D3.X, vector3D3.Y, vector3D3.Z);
	}

	protected internal override void DrawWireframe(DrawParams data)
	{
		if (!data.Selected)
		{
			data.RenderContext.SetColorWireframe(Color.FromArgb(255, Color));
		}
		data.RenderContext.PushRasterizerState();
		data.RenderContext.SetRasterizerState(rasterizerPolygonDrawingType.Line, rasterizerCullFaceType.None);
		data.RenderContext.DrawPlainTriangles(new IndexTriangle[2]
		{
			new IndexTriangle(0, 1, 2),
			new IndexTriangle(0, 2, 3)
		}, _0023_003Dza7scAbXema1S_UGq_0024Bbgx3s_003D(), new Vector3D[2]
		{
			base.Plane.AxisZ,
			base.Plane.AxisZ
		});
		data.RenderContext.PushModelView();
		_0023_003DzacB01ck_003D(data.RenderContext);
		data.RenderContext.Draw(drawData);
		data.RenderContext.PopModelView();
		data.RenderContext.PopRasterizerState();
	}

	protected internal override void DrawForShadow(RenderParams data)
	{
	}

	protected internal override void DrawEdges(DrawParams data)
	{
		if (!data.Selected && data.Viewport.DisplayMode != displayType.HiddenLines)
		{
			data.RenderContext.SetColorWireframe(Color);
		}
		float size = data.RenderContext.SetLineSize(2f);
		data.RenderContext.DrawLineLoop(_0023_003Dza7scAbXema1S_UGq_0024Bbgx3s_003D());
		data.RenderContext.SetLineSize(size);
	}

	protected internal override void DrawVertices(DrawParams data)
	{
		_0023_003DzfytGakPJH0VOucX17g_003D_003D(data.RenderContext, _0023_003Dza7scAbXema1S_UGq_0024Bbgx3s_003D(), _vertices.Length);
	}

	protected internal override bool GetAllVertices(TraversalParams data, out IList<float> verticesCoords)
	{
		Utility._0023_003Dzyx35VoBSR6flPmM7uA_003D_003D(_0023_003DzwDoRd_0024L76oK8i0AH_002428DJ8U_003D(), out var _0023_003DzTbDlaOM_003D);
		verticesCoords = _0023_003DzTbDlaOM_003D;
		return true;
	}

	private Point3D[] _0023_003DzwDoRd_0024L76oK8i0AH_002428DJ8U_003D()
	{
		Point2D[] array = new Point2D[4]
		{
			new Point2D(_0023_003DzFRxYk4OWwbvs.X, _0023_003DzFRxYk4OWwbvs.Y),
			new Point2D(_0023_003DzYD_Yi5DJJpo_0024.X, _0023_003DzFRxYk4OWwbvs.Y),
			new Point2D(_0023_003DzYD_Yi5DJJpo_0024.X, _0023_003DzYD_Yi5DJJpo_0024.Y),
			new Point2D(_0023_003DzFRxYk4OWwbvs.X, _0023_003DzYD_Yi5DJJpo_0024.Y)
		};
		switch (_0023_003DzIhkvY7s_003D)
		{
		case contentAlignment.TopLeft:
		case contentAlignment.TopRight:
			array[2].Y += base.Height;
			array[3].Y += base.Height;
			break;
		case contentAlignment.BottomLeft:
		case contentAlignment.BottomRight:
			array[0].Y -= base.Height;
			array[1].Y -= base.Height;
			break;
		}
		Point3D[] array2 = new Point3D[4];
		for (int i = 0; i < 4; i++)
		{
			array2[i] = base.Plane.PointAt(array[i]);
		}
		return array2;
	}

	internal override bool FindClosestVertex(FindClosestVertexParams _0023_003DzELu0Pss_003D, int _0023_003Dz7xzxLVk_003D)
	{
		return FindClosestVertex(_0023_003DzELu0Pss_003D, _0023_003Dza7scAbXema1S_UGq_0024Bbgx3s_003D(), _vertices.Length, _0023_003Dz7xzxLVk_003D);
	}

	private Point3D[] _0023_003Dza7scAbXema1S_UGq_0024Bbgx3s_003D()
	{
		return new Point3D[4]
		{
			base.Plane.PointAt(_0023_003DzFRxYk4OWwbvs.X, _0023_003DzFRxYk4OWwbvs.Y),
			base.Plane.PointAt(_0023_003DzYD_Yi5DJJpo_0024.X, _0023_003DzFRxYk4OWwbvs.Y),
			base.Plane.PointAt(_0023_003DzYD_Yi5DJJpo_0024.X, _0023_003DzYD_Yi5DJJpo_0024.Y),
			base.Plane.PointAt(_0023_003DzFRxYk4OWwbvs.X, _0023_003DzYD_Yi5DJJpo_0024.Y)
		};
	}

	protected internal override bool ComputeBoundingBox(TraversalParams data, out Point3D boxMin, out Point3D boxMax)
	{
		Utility.ComputeBoundingBox(data.Transformation, _0023_003DzwDoRd_0024L76oK8i0AH_002428DJ8U_003D(), out boxMin, out boxMax);
		return true;
	}

	public override bool IsInFrustum(FrustumParams data, Point3D center, double radius)
	{
		return true;
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302995156), _0023_003DzKra28oc_003D);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302995137), _0023_003DzFRxYk4OWwbvs);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302995151), _0023_003DzYD_Yi5DJJpo_0024);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302995133), _0023_003DzIhkvY7s_003D);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951333), _0023_003Dz7yYXX6k_003D);
	}
}
