using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class Picture : PlanarEntity
{
	private bool _showClipped;

	internal IndexTriangle[] indexTriangleMesh;

	private Polygon2D _clippingBoundary;

	private bool _tiling;

	private byte[] _image;

	private int _imageWidth;

	private int _imageHeight;

	private double _width;

	private double _height;

	internal TextureBase _texture;

	private textureFilteringFunctionType _minFunc = textureFilteringFunctionType.Linear;

	private textureFilteringFunctionType _magFunc = textureFilteringFunctionType.Linear;

	private bool _anisotropic = true;

	public bool ShowClipped
	{
		get
		{
			return _showClipped;
		}
		set
		{
			_showClipped = value;
			if (_clippingBoundary != null)
			{
				regenMode = regenType.RegenAndCompile;
			}
		}
	}

	public Polygon2D ClippingBoundary
	{
		get
		{
			return _clippingBoundary;
		}
		set
		{
			_clippingBoundary = value;
			regenMode = regenType.RegenAndCompile;
		}
	}

	public bool Tiling
	{
		get
		{
			return _tiling;
		}
		set
		{
			_tiling = value;
		}
	}

	public bool HasTransparentImage { get; }

	public bool Lighted { get; set; }

	public bool DrawEdge { get; set; }

	public byte[] Image
	{
		get
		{
			return _image;
		}
		set
		{
			_image = value;
			_0023_003DzmCIQAKavM1zm(_image != null && Utility._0023_003DzEZap865nk78Y(_image));
			FilePath = null;
			if (RegenMode == regenType.NotNeeded)
			{
				RegenMode = regenType.CompileOnly;
			}
		}
	}

	public string FilePath { get; set; }

	public bool AnisotropicFiltering
	{
		get
		{
			return _anisotropic;
		}
		set
		{
			_anisotropic = value;
			if (RegenMode == regenType.NotNeeded)
			{
				RegenMode = regenType.CompileOnly;
			}
		}
	}

	public textureFilteringFunctionType MinifyingFunction
	{
		get
		{
			return _minFunc;
		}
		set
		{
			_minFunc = value;
			if (RegenMode == regenType.NotNeeded)
			{
				RegenMode = regenType.CompileOnly;
			}
		}
	}

	public textureFilteringFunctionType MagnifyingFunction
	{
		get
		{
			return _magFunc;
		}
		set
		{
			_magFunc = value;
			if (RegenMode == regenType.NotNeeded)
			{
				RegenMode = regenType.CompileOnly;
			}
		}
	}

	public double Height
	{
		get
		{
			return _height;
		}
		set
		{
			_height = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public double Width
	{
		get
		{
			return _width;
		}
		set
		{
			_width = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	[Obsolete("Use the plane only constructor instead.")]
	public Picture(Plane pln, Point3D basePoint, double width, double height, byte[] image)
		: this(pln, width, height, image)
	{
		base.Plane.Origin = basePoint;
	}

	public Picture(Plane pln, double width, double height, byte[] image, bool tiling = false)
		: base((Plane)pln.Clone())
	{
		if (width <= 0.0)
		{
			throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974317), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974298));
		}
		if (height <= 0.0)
		{
			throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974285), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974298));
		}
		base.entityNature = entityNatureType.Polygon;
		_width = width;
		_height = height;
		_image = image;
		_0023_003DzmCIQAKavM1zm(_image != null && Utility._0023_003DzEZap865nk78Y(_image));
		Lighted = true;
		DrawEdge = true;
		Tiling = tiling;
	}

	protected Picture(Picture another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		_width = another._width;
		_height = another._height;
		_image = (byte[])another._image.Clone();
		_0023_003DzmCIQAKavM1zm(_image != null && Utility._0023_003DzEZap865nk78Y(_image));
		FilePath = another.FilePath;
		_minFunc = another._minFunc;
		_magFunc = another._magFunc;
		_anisotropic = another._anisotropic;
		Lighted = another.Lighted;
		DrawEdge = another.DrawEdge;
		_clippingBoundary = (Polygon2D)(another._clippingBoundary?.Clone());
		_showClipped = another._showClipped;
		Tiling = another.Tiling;
		if (keepTessellation && another.indexTriangleMesh != null)
		{
			indexTriangleMesh = Utility._0023_003DzX42kjXfbzdxuD8Dt7A_003D_003D(another.indexTriangleMesh);
		}
	}

	protected internal Picture(PictureSurrogate surrogate)
		: this(surrogate.Plane, surrogate.Width, surrogate.Height, surrogate.Image?.Data)
	{
	}

	protected Picture(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_width = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974266));
		_height = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974246));
		_image = (byte[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974225), typeof(byte[]));
		_0023_003DzmCIQAKavM1zm(info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974237)));
		_minFunc = (textureFilteringFunctionType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974454), typeof(textureFilteringFunctionType));
		_magFunc = (textureFilteringFunctionType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974418), typeof(textureFilteringFunctionType));
		_tiling = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974413));
		_anisotropic = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974396));
		_showClipped = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974360));
		_clippingBoundary = (Polygon2D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974345), typeof(Polygon2D));
		indexTriangleMesh = (IndexTriangle[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974049), typeof(IndexTriangle[]));
		FilePath = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951005));
		Lighted = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974041));
		DrawEdge = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974023));
	}

	private void _0023_003DzmCIQAKavM1zm(bool _0023_003DzPzO_0024GUk_003D)
	{
		HasTransparentImage = _0023_003DzPzO_0024GUk_003D;
	}

	public override object Clone()
	{
		return new Picture(this);
	}

	public override object CloneWithTessellation()
	{
		return new Picture(this, RegenMode != regenType.RegenAndCompile);
	}

	public override void Dispose()
	{
		_0023_003DzhM3qURBkRYYd();
		base.Dispose();
	}

	internal void _0023_003DzhM3qURBkRYYd()
	{
		if (_texture != null)
		{
			_texture.Dispose();
		}
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnitsType.Unitless, massUnitsType.Unitless, (LayerKeyedCollection)null, (MaterialKeyedCollection)null, (BlockKeyedCollection)null));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974008) + _width);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973989) + _height);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973973) + Lighted);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973960) + DrawEdge);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974201) + _minFunc);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974146) + _magFunc);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974122) + _anisotropic);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974087) + _showClipped);
		return stringBuilder.ToString();
	}

	[SpecialName]
	internal override bool _0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D()
	{
		if (base._0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D())
		{
			if (ShowClipped)
			{
				if (ClippingBoundary != null)
				{
					return indexTriangleMesh != null;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public override void Regen(RegenParams data)
	{
		if (_showClipped && _clippingBoundary != null)
		{
			List<Point3D> list = new List<Point3D>();
			Point2D[] points = _clippingBoundary.Points;
			foreach (Point2D pt in points)
			{
				list.Add(base.Plane.PointAt(pt));
			}
			Mesh mesh = new Region(new LinearPath(list)).ConvertToMesh(0.0, 0.0, Mesh.natureType.RichSmooth, weld: false);
			_vertices = mesh.Vertices;
			indexTriangleMesh = mesh.Triangles;
		}
		else
		{
			_vertices = new Point3D[4]
			{
				base.Plane.PointAt(0.0, 0.0),
				base.Plane.PointAt(_width, 0.0),
				base.Plane.PointAt(_width, _height),
				base.Plane.PointAt(0.0, _height)
			};
		}
		UpdateBoundingBox(data);
		RegenMode = regenType.CompileOnly;
	}

	public Mesh[] GetTessellation()
	{
		Mesh mesh = new Mesh(_vertices, new IndexTriangle[2]
		{
			new IndexTriangle(0, 1, 2),
			new IndexTriangle(0, 2, 3)
		});
		mesh.Normals = new Vector3D[1] { base.Plane.AxisZ };
		mesh.Edges = new IndexLine[4]
		{
			new IndexLine(0, 1),
			new IndexLine(1, 2),
			new IndexLine(2, 3),
			new IndexLine(3, 0)
		};
		return new Mesh[1] { mesh };
	}

	public override void Compile(CompileParams data)
	{
		if (_image != null)
		{
			if (_texture == null)
			{
				_texture = data.RenderContext.CreateTexture2D();
			}
			_texture.Load(data.RenderContext, _image, _minFunc, _magFunc, _anisotropic, repeatX: false, repeatY: false);
			_imageWidth = _texture.BitmapSize.Width;
			_imageHeight = _texture.BitmapSize.Height;
		}
		base.Compile(data);
	}

	private PointF[] _0023_003DzIxYMFJ_0024ROeBIPbiE4A_003D_003D()
	{
		float num = 0f;
		float num2 = 0f;
		if (Tiling)
		{
			num = 0.5f / (float)_imageWidth;
			num2 = 0.5f / (float)_imageHeight;
		}
		return new PointF[4]
		{
			new PointF(num, 1f - num2),
			new PointF(1f - num, 1f - num2),
			new PointF(1f - num, num2),
			new PointF(num, num2)
		};
	}

	protected override void DrawEntity(RenderContextBase context, object myParams)
	{
		if (!_showClipped)
		{
			context.DrawRichPlainQuads(_vertices, new Vector3D[2]
			{
				base.Plane.AxisZ,
				base.Plane.AxisZ
			}, _0023_003DzIxYMFJ_0024ROeBIPbiE4A_003D_003D());
		}
		else if (_clippingBoundary != null)
		{
			Mesh mesh = new Mesh(Mesh.natureType.RichSmooth);
			mesh.Vertices = _vertices;
			mesh.Triangles = new IndexTriangle[indexTriangleMesh.Length];
			for (int i = 0; i < mesh.Triangles.Length; i++)
			{
				mesh.Triangles[i] = new RichSmoothTriangle(indexTriangleMesh[i].V1, indexTriangleMesh[i].V2, indexTriangleMesh[i].V3);
			}
			mesh.ColorMethod = colorMethodType.byEntity;
			mesh.UpdateNormals();
			if (Vector3D.AreOpposite(mesh.Normals[0], base.Plane.AxisZ))
			{
				mesh.FlipNormal();
			}
			mesh.ApplyTextureMapping(textureMappingType.Plate, 1.0, 1.0);
			List<PointF> texCoords = _0023_003DzWAddgO_L10Ei(mesh, Width, Height);
			context.DrawRichSmoothTriangles(mesh.Triangles, mesh.Vertices, mesh.Normals, texCoords);
		}
	}

	private List<PointF> _0023_003DzWAddgO_L10Ei(Mesh _0023_003DzkKfJheA_003D, double _0023_003Dz6tVBpdk_003D, double _0023_003DzvAxV_0024Ic_003D)
	{
		List<PointF> list = new List<PointF>();
		PointF[] array = new PointF[_0023_003DzkKfJheA_003D.Triangles.Length * 3];
		Point3D[] vertices = _0023_003DzkKfJheA_003D.Vertices;
		foreach (Point3D p in vertices)
		{
			Point2D point2D = base.Plane.Project(p);
			_ = base.Plane.Origin;
			float x = (float)((double)Math.Abs((float)point2D.X) / _0023_003Dz6tVBpdk_003D);
			float y = (float)((double)Math.Abs((float)point2D.Y) / _0023_003DzvAxV_0024Ic_003D);
			list.Add(new PointF(x, y));
		}
		for (int j = 0; j < _0023_003DzkKfJheA_003D.Triangles.Length; j++)
		{
			IndexTriangle indexTriangle = _0023_003DzkKfJheA_003D.Triangles[j];
			array[3 * j] = list[indexTriangle.V1];
			array[1 + 3 * j] = list[indexTriangle.V2];
			array[2 + 3 * j] = list[indexTriangle.V3];
		}
		return array.ToList();
	}

	protected internal override void DrawWireframe(DrawParams data)
	{
		if (_showClipped && _clippingBoundary != null)
		{
			data.RenderContext.DrawLineLoop(_vertices);
		}
		else
		{
			data.RenderContext.DrawQuadsOutlines(_vertices);
		}
	}

	protected internal override void DrawFlat(DrawParams data)
	{
		bool texture2D = false;
		bool lighting = false;
		if (data.ShaderParams != null)
		{
			data.RenderContext.PushShader();
			texture2D = data.ShaderParams.Texture2D;
			lighting = data.ShaderParams.Lighting;
			data.ShaderParams.Texture2D = true;
			base.SetShader(data);
		}
		data.RenderContext.SetMaterialFrontAmbient(Color.White);
		data.RenderContext.SetColorWireframe(Color.White);
		DrawInternal(data);
		if (data.ShaderParams != null)
		{
			data.ShaderParams.Texture2D = texture2D;
			data.ShaderParams.Lighting = lighting;
			data.RenderContext.PopShader();
		}
	}

	protected internal override void DrawFlatSelected(DrawParams data)
	{
		data.RenderContext.Draw(drawData);
	}

	protected internal override void DrawSelected(DrawParams data)
	{
		data.RenderContext.Draw(drawData);
	}

	protected internal override void Draw(DrawParams data)
	{
		if (!data.Selected)
		{
			data.RenderContext.SetColorShadedInternal(base.entityNature, Color.White, _0023_003DzNGLWIVQ_003D: false, data.viewportInternal.parent.Backface);
		}
		bool lighting = false;
		if (!Lighted)
		{
			lighting = data.RenderContext.SetLighting(enable: false);
			data.RenderContext.SetColorWireframe(Color.White);
		}
		DrawInternal(data);
		if (!Lighted)
		{
			data.RenderContext.SetLighting(lighting);
		}
	}

	protected internal override void DrawHiddenLinesMaterial(RenderParams data)
	{
		DrawHiddenLines(data);
	}

	protected internal override void DrawHiddenLinesFast(DrawParams data)
	{
		DrawHiddenLines(data);
	}

	protected internal override void DrawHiddenLines(DrawParams data)
	{
		if (data.Selected)
		{
			DrawSelected(data);
			return;
		}
		bool flag = data.viewportInternal.parent.Backface.ColorMethod == backfaceColorMethodType.SingleColor;
		bool lighting = false;
		bool flag2 = data.viewportInternal.parent.HiddenLines.Lighting && !flag && !Lighted;
		bool flag3 = flag && (!data.viewportInternal.parent.HiddenLines.Lighting || !Lighted);
		if (flag2)
		{
			lighting = data.RenderContext.SetLighting(enable: false);
			data.RenderContext.SetColorWireframe(Color.White);
		}
		Color ambient = data.RenderContext.CurrentMaterial.Ambient;
		Color ambient2 = data.RenderContext.CurrentBackMaterial.Ambient;
		bool[] array = null;
		if (flag3)
		{
			data.RenderContext.SetMaterialFrontAmbient(Color.White);
			if (data.viewportInternal.parent.HiddenLines.Lighting)
			{
				data.RenderContext.SetSceneAmbient(new float[4] { 1f, 1f, 1f, 1f });
				data.RenderContext.SetMaterialBackAmbient(data.viewportInternal.parent.Backface.Color);
				array = new bool[data.RenderContext.ActiveLights.Length];
				for (int i = 0; i < data.RenderContext.ActiveLights.Length; i++)
				{
					array[i] = data.RenderContext.ActiveLights[i].Active;
					data.RenderContext.ActiveLights[i].Active = false;
					data.RenderContext.SetLightStatus(i, active: false);
				}
			}
		}
		if (data.ShaderParams != null)
		{
			data.RenderContext.PushShader();
			bool texture2D = data.ShaderParams.Texture2D;
			data.ShaderParams.Texture2D = true;
			bool lighting2 = data.ShaderParams.Lighting;
			if (flag2)
			{
				data.ShaderParams.Lighting = false;
			}
			base.SetShader(data);
			data.RenderContext.UpdateConstantBufferPerFrame(data.ShaderParams);
			data.RenderContext.CurrentShaderTechnique.SetParameters(data.ShaderParams);
			data.ShaderParams.Texture2D = texture2D;
			data.ShaderParams.Lighting = lighting2;
		}
		if (!base.Selected)
		{
			data.RenderContext.SetMaterialFrontDiffuse(Color.White);
			if (!flag)
			{
				data.RenderContext.SetMaterialBackDiffuse(Color.White);
			}
		}
		DrawInternal(data);
		if (data.ShaderParams != null)
		{
			data.RenderContext.PopShader();
		}
		if (flag3)
		{
			data.RenderContext.SetMaterialFrontAmbient(ambient);
			if (data.viewportInternal.parent.HiddenLines.Lighting)
			{
				data.RenderContext.SetMaterialBackAmbient(ambient2);
				data.RenderContext.SetSceneAmbient(Utility.ColorToFloatArray(data.viewportInternal.parent.ambientLight));
				for (int j = 0; j < data.RenderContext.ActiveLights.Length; j++)
				{
					data.RenderContext.ActiveLights[j].Active = array[j];
					data.RenderContext.SetLightStatus(j, array[j]);
				}
			}
		}
		if (flag2)
		{
			data.RenderContext.SetLighting(lighting);
		}
	}

	protected void DrawInternal(DrawParams data)
	{
		data.RenderContext.SetTexture(_texture);
		data.RenderContext.SetTextureGrayscale(data.ForceGray, data.RasterViewForceGrayAlpha);
		data.RenderContext.Draw(drawData);
		data.RenderContext.SetTextureGrayscale(grayscale: false, 0f);
		if (data.ShaderParams != null)
		{
			data.ShaderParams.Texture2D = false;
		}
		data.RenderContext.CloseTexture();
	}

	protected internal override void DrawEdges(DrawParams data)
	{
		if (DrawEdge || base.Selected)
		{
			DrawWireframe(data);
		}
	}

	protected internal override void DrawForSelection(DrawForSelectionParams data)
	{
		if (_showClipped && _clippingBoundary != null)
		{
			data.RenderContext.DrawTrianglesPlanar(Vertices, indexTriangleMesh, base.Plane.AxisZ);
		}
		else
		{
			data.RenderContext.DrawTrianglesFan(_vertices, base.Plane.AxisZ);
		}
	}

	protected internal override bool ThroughTriangle(FrustumParams data)
	{
		if (_showClipped && _clippingBoundary != null)
		{
			if (Entity._0023_003Dzz3lsBX3i0Rg2(data, Vertices, indexTriangleMesh))
			{
				AddSelectedItemLeaf(data);
				return true;
			}
			return false;
		}
		if (Entity.ThroughTriangleQuad(data, _vertices))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool ThroughTriangleScreenPolygon(ScreenPolygonParams data)
	{
		if (_showClipped && _clippingBoundary != null)
		{
			if (Entity._0023_003DzOejNn2S1Lat5_0024X4DHg_003D_003D(Vertices, indexTriangleMesh, data))
			{
				AddSelectedItemLeaf(data);
				return true;
			}
			return false;
		}
		if (Entity.ThroughTriangleScreenPolygonQuad(_vertices, data))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	public void FlipNormal()
	{
		base.Plane.Flip();
		RegenMode = regenType.RegenAndCompile;
	}

	protected internal override void DrawNormals(DrawParams data)
	{
		data.RenderContext.DrawNormals(new Point3D[1] { _vertices[0] }, base.Plane.AxisZ * GetNormalLength());
	}

	protected internal override void DrawForShadow(RenderParams data)
	{
		if (_showClipped && _clippingBoundary != null)
		{
			data.RenderContext.DrawTrianglesPlanar(Vertices, indexTriangleMesh, base.Plane.AxisZ);
		}
		data.RenderContext.DrawTrianglesFan(_vertices, base.Plane.AxisZ);
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode == regenType.RegenAndCompile)
		{
			if (_showClipped && _clippingBoundary != null)
			{
				_clippingBoundary.UpdateBoundingRect();
				return new Point3D[2]
				{
					base.Plane.PointAt(_clippingBoundary.Min),
					base.Plane.PointAt(_clippingBoundary.Max)
				};
			}
			return new Point3D[2]
			{
				base.Plane.PointAt(0.0, 0.0),
				base.Plane.PointAt(_width, _height)
			};
		}
		return new Point3D[2] { base.BoxMin, base.BoxMax };
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new PictureSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974266), _width);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974246), _height);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974225), _image);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974237), HasTransparentImage);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974454), _minFunc);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974418), _magFunc);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974413), _tiling);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974396), _anisotropic);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974360), _showClipped);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974345), _clippingBoundary);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974049), indexTriangleMesh);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951005), FilePath);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974041), Lighted);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974023), DrawEdge);
	}

	protected internal override void SetShader(DrawParams data)
	{
		if (data.ShaderParams != null && !data.Selected)
		{
			data.ShaderParams.Texture2D = true;
			data.ShaderParams.Lighting = Lighted;
		}
		base.SetShader(data);
	}

	public override void TransformBy(Transformation xform)
	{
		Plane pl = (Plane)base.Plane.Clone();
		base.TransformBy(xform);
		double scaleFactor = Math.Abs(xform.ScaleFactorX);
		if (xform.IsScaleFactorUniform() || xform.IsScaleFactorUniformForPlanar(pl, ref scaleFactor))
		{
			_width *= scaleFactor;
			_height *= scaleFactor;
			ClippingBoundary?.TransformBy(new Scaling(scaleFactor));
		}
	}

	public Mesh ConvertToMesh(double deviation = 0.0, double angle = 0.0, Mesh.natureType nature = Mesh.natureType.Plain, bool weld = true)
	{
		Mesh mesh = new Mesh(Utility.DeepCopy(_vertices), new IndexTriangle[2]
		{
			new RichTriangle(0, 1, 2, 0, 1, 2),
			new RichTriangle(0, 2, 3, 0, 2, 3)
		});
		mesh.TextureCoords = new PointF[4]
		{
			new PointF(0f, 0f),
			new PointF(1f, 0f),
			new PointF(1f, 1f),
			new PointF(0f, 1f)
		};
		mesh.CopyAttributes(this);
		mesh.Regen(deviation);
		return mesh;
	}
}
