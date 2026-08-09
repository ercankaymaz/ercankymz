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
public class FastMesh : Entity, IFace, ICloneable
{
	private float[] _pointArray;

	private float[] _normalArray;

	private int[] _triangleArray;

	private byte[] _rgbArray;

	private float[] _textureCoordsArray;

	public bool Dynamic { get; }

	public float[] PointArray
	{
		get
		{
			return _pointArray;
		}
		set
		{
			_pointArray = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public float[] NormalArray
	{
		get
		{
			return _normalArray;
		}
		set
		{
			_normalArray = value;
			if (RegenMode == regenType.NotNeeded)
			{
				RegenMode = regenType.CompileOnly;
			}
		}
	}

	public int[] TriangleArray
	{
		get
		{
			return _triangleArray;
		}
		set
		{
			_triangleArray = value;
			if (RegenMode == regenType.NotNeeded)
			{
				RegenMode = regenType.CompileOnly;
			}
		}
	}

	public byte[] ColorArray
	{
		get
		{
			return _rgbArray;
		}
		set
		{
			_rgbArray = value;
			if (RegenMode == regenType.NotNeeded)
			{
				RegenMode = regenType.CompileOnly;
			}
		}
	}

	public float[] TextureCoordsArray
	{
		get
		{
			return _textureCoordsArray;
		}
		set
		{
			_textureCoordsArray = value;
			if (RegenMode == regenType.NotNeeded)
			{
				RegenMode = regenType.CompileOnly;
			}
		}
	}

	public FastMesh()
		: base(entityNatureType.Polygon)
	{
	}

	public FastMesh(float[] points, int[] triangles, float[] normals, bool dynamic = false)
		: base(entityNatureType.Polygon)
	{
		_pointArray = points;
		_triangleArray = triangles;
		_normalArray = normals;
		_0023_003DzO1QRfLc1l2pY(dynamic);
	}

	public FastMesh(float[] points, int[] triangles, float[] normals, byte[] colors, bool dynamic = false)
		: this(points, triangles, normals, dynamic)
	{
		_rgbArray = colors;
	}

	public FastMesh(float[] points, int[] triangles, float[] normals, float[] texCoords, bool dynamic = false)
		: this(points, triangles, normals, dynamic)
	{
		_textureCoordsArray = texCoords;
		base.entityNature = entityNatureType.RichPolygon;
	}

	internal FastMesh(IList<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, IList<IndexTriangle> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, IList<Vector3D> _0023_003DzztJY0_0024dXEFMk = null, bool _0023_003DzJUyp8Vk_003D = false)
		: base(entityNatureType.Polygon)
	{
		_pointArray = new float[_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count * 3];
		_triangleArray = new int[_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Count * 3];
		for (int i = 0; i < _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count; i++)
		{
			int num = 3 * i;
			_pointArray[num] = (float)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i].X;
			_pointArray[num + 1] = (float)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i].Y;
			_pointArray[num + 2] = (float)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i].Z;
		}
		for (int j = 0; j < _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Count; j++)
		{
			int num2 = 3 * j;
			_triangleArray[num2] = _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[j].V1;
			_triangleArray[num2 + 1] = _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[j].V2;
			_triangleArray[num2 + 2] = _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[j].V3;
		}
		if (_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.FirstOrDefault() is PointNormalUv)
		{
			_normalArray = new float[_pointArray.Length];
			for (int k = 0; k < _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count; k++)
			{
				int num3 = 3 * k;
				PointNormalUv pointNormalUv = (PointNormalUv)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[k];
				_normalArray[num3] = (float)pointNormalUv.Nx;
				_normalArray[num3 + 1] = (float)pointNormalUv.Ny;
				_normalArray[num3 + 2] = (float)pointNormalUv.Nz;
			}
		}
		else if (_0023_003DzztJY0_0024dXEFMk != null)
		{
			_normalArray = new float[_0023_003DzztJY0_0024dXEFMk.Count * 3];
			for (int l = 0; l < _0023_003DzztJY0_0024dXEFMk.Count; l++)
			{
				int num4 = 3 * l;
				_normalArray[num4] = (float)_0023_003DzztJY0_0024dXEFMk[l].X;
				_normalArray[num4 + 1] = (float)_0023_003DzztJY0_0024dXEFMk[l].Y;
				_normalArray[num4 + 2] = (float)_0023_003DzztJY0_0024dXEFMk[l].Z;
			}
		}
		_0023_003DzO1QRfLc1l2pY(_0023_003DzJUyp8Vk_003D);
	}

	protected FastMesh(FastMesh another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		int num = another._pointArray.Length;
		_pointArray = new float[num];
		Array.Copy(another._pointArray, _pointArray, num);
		if (another._triangleArray != null)
		{
			int num2 = another._triangleArray.Length;
			_triangleArray = new int[num2];
			Array.Copy(another._triangleArray, _triangleArray, num2);
		}
		if (another._normalArray != null)
		{
			int num3 = another._normalArray.Length;
			_normalArray = new float[num3];
			Array.Copy(another._normalArray, _normalArray, num3);
		}
		if (another._rgbArray != null)
		{
			int num4 = another._rgbArray.Length;
			_rgbArray = new byte[num4];
			Array.Copy(another._rgbArray, _rgbArray, num4);
		}
		if (another._textureCoordsArray != null)
		{
			int num5 = another._textureCoordsArray.Length;
			_textureCoordsArray = new float[num5];
			Array.Copy(another._textureCoordsArray, _textureCoordsArray, num5);
		}
		_0023_003DzO1QRfLc1l2pY(another.Dynamic);
	}

	protected FastMesh(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_pointArray = (float[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968402), typeof(float[]));
		_triangleArray = (int[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968413), typeof(int[]));
		_normalArray = (float[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968397), typeof(float[]));
		_rgbArray = (byte[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968379), typeof(byte[]));
		_textureCoordsArray = (float[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968362), typeof(float[]));
		_0023_003DzO1QRfLc1l2pY(info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968324)));
	}

	protected internal FastMesh(FastMeshSurrogate surrogate)
		: this(surrogate.PointArray, surrogate.TriangleArray, surrogate.NormalArray, surrogate.Dynamic)
	{
	}

	internal void _0023_003DzO1QRfLc1l2pY(bool _0023_003DzPzO_0024GUk_003D)
	{
		Dynamic = _0023_003DzPzO_0024GUk_003D;
	}

	[SpecialName]
	internal override bool _0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D()
	{
		return true;
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode != regenType.RegenAndCompile)
		{
			return new Point3D[2] { base.BoxMin, base.BoxMax };
		}
		return Utility.GetSampling(_pointArray);
	}

	public override object Clone()
	{
		return new FastMesh(this);
	}

	public override object CloneWithTessellation()
	{
		return new FastMesh(this, RegenMode != regenType.RegenAndCompile);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968402), _pointArray);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968413), _triangleArray);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968397), _normalArray);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968379), _rgbArray);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968362), _textureCoordsArray);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968324), Dynamic);
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump());
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967837) + _pointArray.Length / 3);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956197) + ((_triangleArray != null) ? (_triangleArray.Length / 3) : 0));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968562) + _normalArray.Length / 3);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968555) + ((_rgbArray != null) ? (_rgbArray.Length / 3) : 0));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968517) + ((_textureCoordsArray != null) ? (_textureCoordsArray.Length / 3) : 0));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968494) + Dynamic);
		return stringBuilder.ToString();
	}

	protected override void InitGraphicsData(RenderContextBase renderContext)
	{
		base.InitGraphicsData(renderContext);
	}

	public override void Compile(CompileParams data)
	{
		InitGraphicsData(data.RenderContext);
		base.Compiling = true;
		bool num = !string.IsNullOrEmpty(MaterialName) && data.Materials[MaterialName].Texture != null && _textureCoordsArray != null;
		VBOParamsBase vBOParamsBase = null;
		if (num)
		{
			float[] array = new float[_textureCoordsArray.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = ((i % 2 == 0) ? _textureCoordsArray[i] : (1f - _textureCoordsArray[i]));
			}
			vBOParamsBase = new VBOParamsTexture
			{
				indices = _triangleArray,
				vertices = _pointArray,
				normals = _normalArray,
				TextureCoordinates = array,
				primitiveMode = primitiveType.TriangleList
			};
		}
		else
		{
			vBOParamsBase = new VBOParams
			{
				indices = _triangleArray,
				vertices = _pointArray,
				normals = _normalArray,
				colors = _rgbArray,
				primitiveMode = primitiveType.TriangleList
			};
		}
		if (!drawData.IsValid() || !Dynamic)
		{
			data.RenderContext.CompileVBO(drawData, _0023_003Dzk4gdANb5RPhgx1kcm62dIlw_003D, vBOParamsBase, Dynamic);
		}
		else
		{
			data.RenderContext.UpdateVBO(drawData, _0023_003Dzk4gdANb5RPhgx1kcm62dIlw_003D, vBOParamsBase);
		}
		base.Compiling = false;
		RegenMode = regenType.NotNeeded;
	}

	private void _0023_003DzwNpJQPn9NtkE(RenderContextBase _0023_003DzQdnFby4_003D, object _0023_003DzmPmPjCPqZ3T3)
	{
		_0023_003DzQdnFby4_003D.DrawIndexLines(((Mesh.DrawEdgesInternalParams)_0023_003DzmPmPjCPqZ3T3).lines, _pointArray);
	}

	public override void Regen(RegenParams data)
	{
		base.Regen(data);
	}

	internal override bool FindClosestVertex(FindClosestVertexParams _0023_003DzELu0Pss_003D, int _0023_003Dz7xzxLVk_003D)
	{
		return _0023_003DzyI0wuvHQi9AG(_0023_003DzELu0Pss_003D, _pointArray, _pointArray.Length, _0023_003Dz7xzxLVk_003D);
	}

	protected internal override bool GetAllVertices(TraversalParams data, out IList<float> verticesCoords)
	{
		verticesCoords = _pointArray;
		return true;
	}

	internal override void FindClosestVertices(FindClosestVerticesParams _0023_003DzELu0Pss_003D, int _0023_003Dz7xzxLVk_003D)
	{
		_0023_003DzZmXx2DpbugLKXntdQQPZMqY_003D(_0023_003DzELu0Pss_003D, _pointArray, _pointArray.Length, _0023_003Dz7xzxLVk_003D);
	}

	private void _0023_003Dzk4gdANb5RPhgx1kcm62dIlw_003D(RenderContextBase _0023_003DzQdnFby4_003D, object _0023_003DzmPmPjCPqZ3T3)
	{
		if (_0023_003DzmPmPjCPqZ3T3 is VBOParams)
		{
			_0023_003DzQdnFby4_003D.DrawIndexedTriangles((VBOParams)_0023_003DzmPmPjCPqZ3T3);
		}
		else
		{
			_0023_003DzQdnFby4_003D.DrawIndexedTriangles((VBOParamsTexture)_0023_003DzmPmPjCPqZ3T3);
		}
	}

	protected internal override void DrawIsocurves(DrawParams data)
	{
		DrawSelected(data);
	}

	protected internal override void DrawWireframe(DrawParams drawParams)
	{
	}

	protected internal override void SetShader(DrawParams data)
	{
		if (data.RenderContext.Shaders != null)
		{
			ShaderParameters shaderParams = data.ShaderParams;
			bool texture2D = shaderParams.Texture2D;
			bool multicolor = shaderParams.Multicolor;
			bool withNormals = shaderParams.WithNormals;
			if (_rgbArray != null && (!data.ForceGray & !data.Selected))
			{
				shaderParams.Texture2D = false;
				shaderParams.Multicolor = true;
				shaderParams.WithNormals = true;
			}
			base.SetShader(data);
			if (_rgbArray != null && (!data.ForceGray & !data.Selected))
			{
				shaderParams.Texture2D = texture2D;
				shaderParams.Multicolor = multicolor;
				shaderParams.WithNormals = withNormals;
			}
		}
	}

	protected internal override void DrawFlat(DrawParams data)
	{
		int num;
		int num2;
		if (ColorArray != null)
		{
			num = ((ColorArray.Length != 0) ? 1 : 0);
			if (num != 0)
			{
				num2 = ((!base.Selected) ? 1 : 0);
				goto IL_0024;
			}
		}
		else
		{
			num = 0;
		}
		num2 = 0;
		goto IL_0024;
		IL_0024:
		bool flag = (byte)num2 != 0;
		if (flag)
		{
			SetShader(data);
		}
		if (num != 0)
		{
			if (data.viewportInternal.parent.Backface.ColorMethod == backfaceColorMethodType.SingleColor)
			{
				data.RenderContext.ColorMaterialMode = colorMaterialType.FrontFaceAmbient;
			}
			else
			{
				data.RenderContext.ColorMaterialMode = colorMaterialType.FrontAndBackFaceDiffuse;
			}
			data.RenderContext.Draw(drawData);
			data.RenderContext.ColorMaterialMode = colorMaterialType.Disabled;
		}
		else
		{
			data.RenderContext.Draw(drawData);
		}
		if (flag)
		{
			data.RenderContext.ResetColorDiffuse();
		}
	}

	protected internal override void DrawHiddenLines(DrawParams data)
	{
		if (data.viewportInternal.parent.HiddenLines.ColorMethod == hiddenLinesColorMethodType.SingleColor || data.Selected)
		{
			DrawSelected(data);
		}
		else
		{
			base.DrawHiddenLines(data);
		}
	}

	protected internal override void DrawForSelection(DrawForSelectionParams data)
	{
		DrawSelected(data);
	}

	protected internal override void DrawForShadow(RenderParams data)
	{
		DrawSelected(data);
	}

	protected internal override void DrawSelected(DrawParams drawParams)
	{
		drawParams.RenderContext.DrawSelected(drawData, primitiveType.TriangleList);
	}

	protected internal override bool ComputeBoundingBox(TraversalParams data, out Point3D boxMin, out Point3D boxMax)
	{
		return Entity.ComputeBoundingBox(data, _pointArray, 0, out boxMin, out boxMax);
	}

	public override void TransformBy(Transformation xform)
	{
		if (_pointArray != null)
		{
			float[,] floatMatrix = xform.GetFloatMatrix();
			for (int i = 0; i < _pointArray.Length; i += 3)
			{
				float[] array = Transformation.ActOnLeftOne(_pointArray[i], _pointArray[i + 1], _pointArray[i + 2], floatMatrix);
				_pointArray[i] = array[0];
				_pointArray[i + 1] = array[1];
				_pointArray[i + 2] = array[2];
			}
		}
		if (_normalArray != null)
		{
			float[,] floatMatrix2 = xform.GetFloatMatrix();
			for (int j = 0; j < _normalArray.Length; j += 3)
			{
				float[] array2 = Transformation.ActOnLeftZero(_normalArray[j], _normalArray[j + 1], _normalArray[j + 2], floatMatrix2);
				_normalArray[j] = array2[0];
				_normalArray[j + 1] = array2[1];
				_normalArray[j + 2] = array2[2];
			}
		}
		base.TransformBy(xform);
	}

	protected internal override void ComputeOffsetOnCameraAxes(OffsetOnCameraAxesParams data)
	{
		PointF minQ = data.MinQ._0023_003Dzx9P_oXY_003D();
		PointF maxQ = data.MaxQ._0023_003Dzx9P_oXY_003D();
		Entity.ComputeOffsetOnCameraAxes(data.Transformation, _pointArray, _pointArray.Length, data.m1, data.m2, ref minQ, ref maxQ, 0);
		data.MinQ = minQ;
		data.MaxQ = maxQ;
	}

	protected internal override void DrawSilhouettes(DrawSilhouettesParams drawSilhouettesParams)
	{
		if (_triangleArray != null)
		{
			if (sharedEdgesForSilhouettesDraw == null)
			{
				sharedEdgesForSilhouettesDraw = Utility.GetEdgesWithoutDuplicates(_triangleArray, _pointArray.Length / 3);
			}
			HiddenLinesView._0023_003DzY9TYF9sTjnZYO51HtXX26S0_003D(this, drawSilhouettesParams);
		}
	}

	internal override SilhoWireData _0023_003DzEt1XHB_xc_BLLBoMbJmskWU_003D(PreProcessSilhouettesParams _0023_003DzELu0Pss_003D)
	{
		Mesh mesh = ConvertToMesh(0.0, 0.0, Mesh.natureType.Plain, weld: false);
		mesh.ComputeEdges();
		return HiddenLinesView._0023_003DzeWZNZhCW691ciXKd0w_003D_003D(this, _0023_003DzELu0Pss_003D.Parents, mesh.Vertices, mesh.Triangles, mesh.Edges, _0023_003DzbErHvVw_003D: false, 0.0);
	}

	protected internal override bool InsideOrCrossingFrustum(FrustumParams data)
	{
		Point3D point3D = new Point3D();
		Point3D point3D2 = new Point3D();
		Point3D point3D3 = new Point3D();
		if (data.Transformation == null || data.Transformation.IsIdentity())
		{
			if (_triangleArray != null)
			{
				int _0023_003Dz8iljnAs_003D = 0;
				while (_0023_003Dz8iljnAs_003D < _triangleArray.Length)
				{
					_0023_003DzyI7ZDn0DW7bnrFpXuw_003D_003D(point3D, point3D2, point3D3, ref _0023_003Dz8iljnAs_003D);
					if (Utility.InsideOrCrossingFrustum(point3D, point3D2, point3D3, data.Frustum))
					{
						AddSelectedItemLeaf(data);
						return true;
					}
				}
			}
			else
			{
				int _0023_003Dz8iljnAs_003D2 = 0;
				while (_0023_003Dz8iljnAs_003D2 < _pointArray.Length)
				{
					_0023_003DzyI7ZDn0DW7bnrFpXuw_003D_003D(point3D, point3D2, point3D3, ref _0023_003Dz8iljnAs_003D2);
					if (Utility.InsideOrCrossingFrustum(point3D, point3D2, point3D3, data.Frustum))
					{
						AddSelectedItemLeaf(data);
						return true;
					}
				}
			}
		}
		else if (_triangleArray != null)
		{
			int _0023_003Dz8iljnAs_003D3 = 0;
			while (_0023_003Dz8iljnAs_003D3 < _triangleArray.Length)
			{
				_0023_003DzyI7ZDn0DW7bnrFpXuw_003D_003D(point3D, point3D2, point3D3, ref _0023_003Dz8iljnAs_003D3);
				if (Utility.InsideOrCrossingFrustum(data.Transformation * point3D, data.Transformation * point3D2, data.Transformation * point3D3, data.Frustum))
				{
					AddSelectedItemLeaf(data);
					return true;
				}
			}
		}
		else
		{
			int _0023_003Dz8iljnAs_003D4 = 0;
			while (_0023_003Dz8iljnAs_003D4 < _pointArray.Length)
			{
				_0023_003DzyI7ZDn0DW7bnrFpXuw_003D_003D(point3D, point3D2, point3D3, ref _0023_003Dz8iljnAs_003D4);
				if (Utility.InsideOrCrossingFrustum(data.Transformation * point3D, data.Transformation * point3D2, data.Transformation * point3D3, data.Frustum))
				{
					AddSelectedItemLeaf(data);
					return true;
				}
			}
		}
		return false;
	}

	private void _0023_003DzyI7ZDn0DW7bnrFpXuw_003D_003D(Point3D _0023_003DzMEwtr_A_003D, Point3D _0023_003DzW7Zyxfc_003D, Point3D _0023_003DzCYi5MWk_003D, ref int _0023_003Dz8iljnAs_003D)
	{
		if (TriangleArray != null)
		{
			int num = _triangleArray[_0023_003Dz8iljnAs_003D++] * 3;
			int num2 = _triangleArray[_0023_003Dz8iljnAs_003D++] * 3;
			int num3 = _triangleArray[_0023_003Dz8iljnAs_003D++] * 3;
			_0023_003DzMEwtr_A_003D.X = _pointArray[num];
			_0023_003DzMEwtr_A_003D.Y = _pointArray[num + 1];
			_0023_003DzMEwtr_A_003D.Z = _pointArray[num + 2];
			_0023_003DzW7Zyxfc_003D.X = _pointArray[num2];
			_0023_003DzW7Zyxfc_003D.Y = _pointArray[num2 + 1];
			_0023_003DzW7Zyxfc_003D.Z = _pointArray[num2 + 2];
			_0023_003DzCYi5MWk_003D.X = _pointArray[num3];
			_0023_003DzCYi5MWk_003D.Y = _pointArray[num3 + 1];
			_0023_003DzCYi5MWk_003D.Z = _pointArray[num3 + 2];
		}
		else
		{
			_0023_003DzMEwtr_A_003D.X = _pointArray[_0023_003Dz8iljnAs_003D++];
			_0023_003DzMEwtr_A_003D.Y = _pointArray[_0023_003Dz8iljnAs_003D++];
			_0023_003DzMEwtr_A_003D.Z = _pointArray[_0023_003Dz8iljnAs_003D++];
			_0023_003DzW7Zyxfc_003D.X = _pointArray[_0023_003Dz8iljnAs_003D++];
			_0023_003DzW7Zyxfc_003D.Y = _pointArray[_0023_003Dz8iljnAs_003D++];
			_0023_003DzW7Zyxfc_003D.Z = _pointArray[_0023_003Dz8iljnAs_003D++];
			_0023_003DzCYi5MWk_003D.X = _pointArray[_0023_003Dz8iljnAs_003D++];
			_0023_003DzCYi5MWk_003D.Y = _pointArray[_0023_003Dz8iljnAs_003D++];
			_0023_003DzCYi5MWk_003D.Z = _pointArray[_0023_003Dz8iljnAs_003D++];
		}
	}

	protected internal override bool InsideOrCrossingScreenPolygon(ScreenPolygonParams data)
	{
		Point3D point3D = new Point3D();
		Point3D point3D2 = new Point3D();
		Point3D point3D3 = new Point3D();
		if (data.Transformation == null || data.Transformation.IsIdentity())
		{
			if (_triangleArray != null)
			{
				int _0023_003Dz8iljnAs_003D = 0;
				while (_0023_003Dz8iljnAs_003D < _triangleArray.Length)
				{
					_0023_003DzyI7ZDn0DW7bnrFpXuw_003D_003D(point3D, point3D2, point3D3, ref _0023_003Dz8iljnAs_003D);
					if (Utility.InsideOrCrossingScreenPolygon(point3D, point3D2, point3D3, data))
					{
						AddSelectedItemLeaf(data);
						return true;
					}
				}
			}
			else
			{
				int _0023_003Dz8iljnAs_003D2 = 0;
				while (_0023_003Dz8iljnAs_003D2 < _pointArray.Length)
				{
					_0023_003DzyI7ZDn0DW7bnrFpXuw_003D_003D(point3D, point3D2, point3D3, ref _0023_003Dz8iljnAs_003D2);
					if (Utility.InsideOrCrossingScreenPolygon(point3D, point3D2, point3D3, data))
					{
						AddSelectedItemLeaf(data);
						return true;
					}
				}
			}
		}
		else if (_triangleArray != null)
		{
			int _0023_003Dz8iljnAs_003D3 = 0;
			while (_0023_003Dz8iljnAs_003D3 < _triangleArray.Length)
			{
				_0023_003DzyI7ZDn0DW7bnrFpXuw_003D_003D(point3D, point3D2, point3D3, ref _0023_003Dz8iljnAs_003D3);
				if (Utility.InsideOrCrossingScreenPolygon(data.Transformation * point3D, data.Transformation * point3D2, data.Transformation * point3D3, data))
				{
					AddSelectedItemLeaf(data);
					return true;
				}
			}
		}
		else
		{
			int _0023_003Dz8iljnAs_003D4 = 0;
			while (_0023_003Dz8iljnAs_003D4 < _pointArray.Length)
			{
				_0023_003DzyI7ZDn0DW7bnrFpXuw_003D_003D(point3D, point3D2, point3D3, ref _0023_003Dz8iljnAs_003D4);
				if (Utility.InsideOrCrossingScreenPolygon(data.Transformation * point3D, data.Transformation * point3D2, data.Transformation * point3D3, data))
				{
					AddSelectedItemLeaf(data);
					return true;
				}
			}
		}
		return false;
	}

	protected internal override bool AllVerticesInFrustum(FrustumParams data)
	{
		Point3D point3D = new Point3D();
		if (data.Transformation == null || data.Transformation.IsIdentity())
		{
			int num = 0;
			while (num < _pointArray.Length)
			{
				point3D.X = _pointArray[num++];
				point3D.Y = _pointArray[num++];
				point3D.Z = _pointArray[num++];
				if (!Camera.IsInFrustum(point3D, data.Frustum))
				{
					return false;
				}
			}
		}
		else
		{
			int num2 = 0;
			while (num2 < _pointArray.Length)
			{
				point3D.X = _pointArray[num2++];
				point3D.Y = _pointArray[num2++];
				point3D.Z = _pointArray[num2++];
				if (!Camera.IsInFrustum(data.Transformation * point3D, data.Frustum))
				{
					return false;
				}
			}
		}
		AddSelectedItemLeaf(data);
		return true;
	}

	protected internal override bool AllVerticesInScreenPolygon(ScreenPolygonParams data)
	{
		if (Utility._0023_003DzmNbBfJeObfba6gfTR6lLqbg_003D(data.ViewFrame, data.ModelViewProj, data.Transformation, data.ScreenPolygon, data.Min, data.Max, _pointArray, _pointArray.Length))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool ThroughTriangle(FrustumParams data)
	{
		Point3D point3D = new Point3D();
		Point3D point3D2 = new Point3D();
		Point3D point3D3 = new Point3D();
		if (data.Transformation == null)
		{
			if (_triangleArray != null)
			{
				int _0023_003Dz8iljnAs_003D = 0;
				while (_0023_003Dz8iljnAs_003D < _triangleArray.Length)
				{
					_0023_003DzyI7ZDn0DW7bnrFpXuw_003D_003D(point3D, point3D2, point3D3, ref _0023_003Dz8iljnAs_003D);
					if (Entity.FrustumEdgesTriangleIntersection(data.SelectionEdges, point3D, point3D2, point3D3))
					{
						AddSelectedItemLeaf(data);
						return true;
					}
				}
			}
			else
			{
				int _0023_003Dz8iljnAs_003D2 = 0;
				while (_0023_003Dz8iljnAs_003D2 < _pointArray.Length)
				{
					_0023_003DzyI7ZDn0DW7bnrFpXuw_003D_003D(point3D, point3D2, point3D3, ref _0023_003Dz8iljnAs_003D2);
					if (Entity.FrustumEdgesTriangleIntersection(data.SelectionEdges, point3D, point3D2, point3D3))
					{
						AddSelectedItemLeaf(data);
						return true;
					}
				}
			}
		}
		else if (_triangleArray != null)
		{
			int _0023_003Dz8iljnAs_003D3 = 0;
			while (_0023_003Dz8iljnAs_003D3 < _triangleArray.Length)
			{
				_0023_003DzyI7ZDn0DW7bnrFpXuw_003D_003D(point3D, point3D2, point3D3, ref _0023_003Dz8iljnAs_003D3);
				if (Entity.FrustumEdgesTriangleIntersection(data.SelectionEdges, data.Transformation * point3D, data.Transformation * point3D2, data.Transformation * point3D3))
				{
					AddSelectedItemLeaf(data);
					return true;
				}
			}
		}
		else
		{
			int _0023_003Dz8iljnAs_003D4 = 0;
			while (_0023_003Dz8iljnAs_003D4 < _pointArray.Length)
			{
				_0023_003DzyI7ZDn0DW7bnrFpXuw_003D_003D(point3D, point3D2, point3D3, ref _0023_003Dz8iljnAs_003D4);
				if (Entity.FrustumEdgesTriangleIntersection(data.SelectionEdges, data.Transformation * point3D, data.Transformation * point3D2, data.Transformation * point3D3))
				{
					AddSelectedItemLeaf(data);
					return true;
				}
			}
		}
		return false;
	}

	protected internal override bool ThroughTriangleScreenPolygon(ScreenPolygonParams data)
	{
		Point3D point3D = new Point3D();
		Point3D point3D2 = new Point3D();
		Point3D point3D3 = new Point3D();
		if (data.Transformation == null)
		{
			if (_triangleArray != null)
			{
				int _0023_003Dz8iljnAs_003D = 0;
				while (_0023_003Dz8iljnAs_003D < _triangleArray.Length)
				{
					_0023_003DzyI7ZDn0DW7bnrFpXuw_003D_003D(point3D, point3D2, point3D3, ref _0023_003Dz8iljnAs_003D);
					if (Entity.ThroughTriangleScreenPolygon(point3D, point3D2, point3D3, data))
					{
						AddSelectedItemLeaf(data);
						return true;
					}
				}
			}
			else
			{
				int _0023_003Dz8iljnAs_003D2 = 0;
				while (_0023_003Dz8iljnAs_003D2 < _pointArray.Length)
				{
					_0023_003DzyI7ZDn0DW7bnrFpXuw_003D_003D(point3D, point3D2, point3D3, ref _0023_003Dz8iljnAs_003D2);
					if (Entity.ThroughTriangleScreenPolygon(point3D, point3D2, point3D3, data))
					{
						AddSelectedItemLeaf(data);
						return true;
					}
				}
			}
		}
		else if (_triangleArray != null)
		{
			int _0023_003Dz8iljnAs_003D3 = 0;
			while (_0023_003Dz8iljnAs_003D3 < _triangleArray.Length)
			{
				_0023_003DzyI7ZDn0DW7bnrFpXuw_003D_003D(point3D, point3D2, point3D3, ref _0023_003Dz8iljnAs_003D3);
				if (Entity.ThroughTriangleScreenPolygon(data.Transformation * point3D, data.Transformation * point3D2, data.Transformation * point3D3, data))
				{
					AddSelectedItemLeaf(data);
					return true;
				}
			}
		}
		else
		{
			int _0023_003Dz8iljnAs_003D4 = 0;
			while (_0023_003Dz8iljnAs_003D4 < _pointArray.Length)
			{
				_0023_003DzyI7ZDn0DW7bnrFpXuw_003D_003D(point3D, point3D2, point3D3, ref _0023_003Dz8iljnAs_003D4);
				if (Entity.ThroughTriangleScreenPolygon(data.Transformation * point3D, data.Transformation * point3D2, data.Transformation * point3D3, data))
				{
					AddSelectedItemLeaf(data);
					return true;
				}
			}
		}
		return false;
	}

	protected internal override void DrawVertices(DrawParams data)
	{
		data.RenderContext.DrawPoints(_pointArray);
	}

	protected internal override void DrawNormals(DrawParams data)
	{
		float _0023_003Dz736ekIs_003D = (float)GetNormalLength();
		_0023_003Dz7OF2rTbBn_00246AbUdMn_T8bDg_003D(data, _0023_003Dz736ekIs_003D);
	}

	internal void _0023_003Dz7OF2rTbBn_00246AbUdMn_T8bDg_003D(DrawParams _0023_003DzELu0Pss_003D, float _0023_003Dz736ekIs_003D)
	{
		for (int i = 0; i < _pointArray.Length; i += 3)
		{
			float num = _pointArray[i];
			float num2 = _pointArray[i + 1];
			float num3 = _pointArray[i + 2];
			float num4 = _normalArray[i];
			float num5 = _normalArray[i + 1];
			float num6 = _normalArray[i + 2];
			_0023_003DzELu0Pss_003D.RenderContext.DrawLine(num, num2, num3, num + num4 * _0023_003Dz736ekIs_003D, num2 + num5 * _0023_003Dz736ekIs_003D, num3 + num6 * _0023_003Dz736ekIs_003D);
		}
	}

	public virtual double GetArea(out Point3D centroid)
	{
		AreaProperties areaProperties = new AreaProperties();
		areaProperties.Add(GetTessellation());
		centroid = areaProperties.Centroid;
		return areaProperties.Area;
	}

	public virtual double GetVolume(out Point3D centroid)
	{
		VolumeProperties volumeProperties = new VolumeProperties();
		volumeProperties.Add(GetTessellation());
		centroid = volumeProperties.Centroid;
		return volumeProperties.Volume;
	}

	public virtual void GetPrincipalAxes(out Vector3D axisX, out Vector3D axisY, out Vector3D axisZ, out double ix, out double iy, out double iz)
	{
		VolumeProperties volumeProperties = new VolumeProperties();
		volumeProperties.Add(GetTessellation());
		volumeProperties.GetPrincipalAxes(volumeProperties.Volume, volumeProperties.Centroid, out axisX, out axisY, out axisZ, out ix, out iy, out iz);
	}

	public virtual void GetPrincipalAxes(out Vector3D axisX, out Vector3D axisY, out Vector3D axisZ)
	{
		GetPrincipalAxes(out axisX, out axisY, out axisZ, out var _, out var _, out var _);
	}

	public double GetMass(Material material, linearUnitsType linearUnits, massUnitsType massUnits, out double convertedDensity)
	{
		Point3D centroid;
		return Utility._0023_003DzaWhFDDP5nQ_0024L(material, MaterialName, massUnits, linearUnits, GetVolume(out centroid), out convertedDensity);
	}

	public void FlipNormal()
	{
		for (int i = 0; i < _triangleArray.Length; i += 3)
		{
			int num = _triangleArray[i + 1];
			_triangleArray[i + 1] = _triangleArray[i + 2];
			_triangleArray[i + 2] = num;
		}
		for (int j = 0; j < _normalArray.Length; j++)
		{
			_normalArray[j] = 0f - _normalArray[j];
		}
	}

	public virtual Mesh ConvertToMesh(double deviation = 0.0, double angle = 0.0, Mesh.natureType nature = Mesh.natureType.Smooth, bool weld = true)
	{
		if (_pointArray == null)
		{
			return new Mesh();
		}
		Point3D[] array = new Point3D[_pointArray.Length / 3];
		for (int i = 0; i < _pointArray.Length; i += 3)
		{
			if (nature == Mesh.natureType.MulticolorPlain || nature == Mesh.natureType.MulticolorSmooth)
			{
				if (_rgbArray != null)
				{
					array[i / 3] = new PointRGB(_pointArray[i], _pointArray[i + 1], _pointArray[i + 2], _rgbArray[i], _rgbArray[i + 1], _rgbArray[i + 2]);
				}
				else
				{
					array[i / 3] = new Point3D(_pointArray[i], _pointArray[i + 1], _pointArray[i + 2]);
				}
			}
			else
			{
				array[i / 3] = new Point3D(_pointArray[i], _pointArray[i + 1], _pointArray[i + 2]);
			}
		}
		IndexTriangle[] array2;
		if (_triangleArray != null)
		{
			array2 = new IndexTriangle[_triangleArray.Length / 3];
			for (int j = 0; j < _triangleArray.Length; j += 3)
			{
				int num = _triangleArray[j];
				int num2 = _triangleArray[j + 1];
				int num3 = _triangleArray[j + 2];
				array2[j / 3] = new SmoothTriangle(num, num2, num3, num, num2, num3);
			}
		}
		else
		{
			array2 = new IndexTriangle[array.Length / 3];
			for (int k = 0; k < array2.Length; k++)
			{
				int num4 = k * 3;
				int num5 = k * 3 + 1;
				int num6 = k * 3 + 2;
				array2[k] = new SmoothTriangle(num4, num5, num6, num4, num5, num6);
			}
		}
		Vector3D[] array3 = null;
		if (_normalArray != null)
		{
			array3 = new Vector3D[_normalArray.Length / 3];
			for (int l = 0; l < _normalArray.Length; l += 3)
			{
				double x = _normalArray[l];
				double y = _normalArray[l + 1];
				double z = _normalArray[l + 2];
				int num7 = l / 3;
				array3[num7] = new Vector3D(x, y, z);
				array3[num7].Normalize();
			}
		}
		Mesh mesh = new Mesh(array, array2)
		{
			Normals = array3
		};
		if (_triangleArray == null && weld)
		{
			mesh.Weld();
		}
		mesh.ComputeEdges();
		if (localMin != null && localMax != null)
		{
			mesh.localMin = (Point3D)localMin.Clone();
			mesh.localMax = (Point3D)localMax.Clone();
			mesh.UpdateBoundingBoxSphere();
			mesh.RegenMode = regenType.CompileOnly;
		}
		mesh.CopyAttributes(this);
		return mesh;
	}

	public Brep ConvertToBrep(bool mergeFaces = true, bool mergeEdges = true)
	{
		return ConvertToMesh().ConvertToBrep(mergeFaces, mergeEdges);
	}

	public IList<HitTriangle> FindClosestTriangle(Transformation transf, Segment3D seg)
	{
		return ConvertToMesh(0.0, 0.0, Mesh.natureType.Plain, weld: false).FindClosestTriangle(transf, seg);
	}

	public ICurve[] Section(Plane pln, double tol)
	{
		return ConvertToMesh(0.0, 0.0, Mesh.natureType.Plain, weld: false).Section(pln, tol);
	}

	public virtual Mesh[] GetTessellation()
	{
		return new Mesh[1] { ConvertToMesh(0.0, 0.0, Mesh.natureType.Plain, weld: false) };
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new FastMeshSurrogate(this);
	}

	public IndexTriangle[] GetTriangles()
	{
		IndexTriangle[] array = new IndexTriangle[_triangleArray.Length / 3];
		int num = 0;
		int num2 = 0;
		while (num2 < _triangleArray.Length)
		{
			array[num] = new IndexTriangle(_triangleArray[num2], _triangleArray[num2 + 1], _triangleArray[num2 + 2]);
			num2 += 3;
			num++;
		}
		return array;
	}

	public Point3D[] GetPoints()
	{
		Point3D[] array = new Point3D[_pointArray.Length / 3];
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		while (num3 < _pointArray.Length)
		{
			if (_normalArray != null && _normalArray.Length == _pointArray.Length)
			{
				array[num] = new PointNormalUv(_pointArray[num3], _pointArray[num3 + 1], _pointArray[num3 + 2], _normalArray[num3], _normalArray[num3 + 1], _normalArray[num3 + 2]);
				if (_textureCoordsArray != null)
				{
					((PointNormalUv)array[num]).U = _textureCoordsArray[num2];
					((PointNormalUv)array[num]).V = _textureCoordsArray[num2 + 1];
				}
			}
			else
			{
				array[num] = new Point3D(_pointArray[num3], _pointArray[num3 + 1], _pointArray[num3 + 2]);
			}
			num3 += 3;
			num++;
			num2 += 2;
		}
		return array;
	}

	internal void _0023_003Dz7OF2rTbBn_00246AbUdMn_T8bDg_003D(DrawParams _0023_003DzELu0Pss_003D, double _0023_003Dz736ekIs_003D)
	{
		_0023_003DzELu0Pss_003D.RenderContext.DrawSurfaceNormals(GetPoints(), _0023_003Dz736ekIs_003D);
	}

	public void MergeWith(FastMesh mesh)
	{
		int num = _pointArray.Length;
		int num2 = mesh._pointArray.Length;
		Array.Resize(ref _pointArray, num + num2);
		Array.Copy(mesh._pointArray, 0, _pointArray, num, num2);
		int num3 = 0;
		if (_normalArray != null && mesh._normalArray != null)
		{
			num3 = _normalArray.Length;
			int num4 = mesh._normalArray.Length;
			Array.Resize(ref _normalArray, num3 + num4);
			Array.Copy(mesh._normalArray, 0, _normalArray, num3, num4);
		}
		else
		{
			_normalArray = null;
		}
		int num5 = 0;
		if (_textureCoordsArray != null && _textureCoordsArray.Length != 0)
		{
			int num6 = mesh._textureCoordsArray.Length;
			if (mesh._textureCoordsArray != null && num6 > 0)
			{
				if (_textureCoordsArray == null)
				{
					_textureCoordsArray = new float[num6];
				}
				else
				{
					num5 = _textureCoordsArray.Length;
					Array.Resize(ref _textureCoordsArray, num5 + num6);
				}
				Array.Copy(mesh._textureCoordsArray, 0, _textureCoordsArray, num5, num6);
			}
		}
		int num7 = _triangleArray.Length;
		Array.Resize(ref _triangleArray, num7 + mesh._triangleArray.Length);
		int num8 = num / 3;
		for (int i = 0; i < mesh._triangleArray.Length; i++)
		{
			int num9 = i + num7;
			_triangleArray[num9] = mesh._triangleArray[i] + num8;
		}
		RegenMode = regenType.RegenAndCompile;
	}

	private bool _0023_003DzLk5zDeuuLkza(int _0023_003DzKWuGKXbpDxkEh4GAfA_003D_003D, int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D)
	{
		int num = 3 * _0023_003DzKWuGKXbpDxkEh4GAfA_003D_003D;
		int num2 = _triangleArray[num];
		int num3 = _triangleArray[num + 1];
		int num4 = _triangleArray[num + 2];
		if (_0023_003DzffqPLNQ_003D == num2 && _0023_003Dz5Azd7L8_003D == num3)
		{
			return false;
		}
		if (_0023_003DzffqPLNQ_003D == num3 && _0023_003Dz5Azd7L8_003D == num4)
		{
			return false;
		}
		if (_0023_003DzffqPLNQ_003D == num4 && _0023_003Dz5Azd7L8_003D == num2)
		{
			return false;
		}
		return true;
	}

	internal Vector3D[] _0023_003Dz9PT4tNs9owGLO14COg_003D_003D()
	{
		Vector3D[] array = new Vector3D[_triangleArray.Length / 3];
		int num = 0;
		int num2 = 0;
		while (num2 < _triangleArray.Length)
		{
			int num3 = _triangleArray[num2];
			int num4 = _triangleArray[num2 + 1];
			int num5 = _triangleArray[num2 + 2];
			int num6 = 3 * num3;
			float num7 = _pointArray[num6];
			float num8 = _pointArray[num6 + 1];
			float num9 = _pointArray[num6 + 2];
			int num10 = 3 * num4;
			float num11 = _pointArray[num10];
			float num12 = _pointArray[num10 + 1];
			float num13 = _pointArray[num10 + 2];
			int num14 = 3 * num5;
			float num15 = _pointArray[num14];
			float num16 = _pointArray[num14 + 1];
			float num17 = _pointArray[num14 + 2];
			float[] array2 = new float[3]
			{
				num7 - num15,
				num8 - num16,
				num9 - num17
			};
			float[] array3 = new float[3]
			{
				num11 - num7,
				num12 - num8,
				num13 - num9
			};
			array[num] = new Vector3D(array2[1] * array3[2] - array2[2] * array3[1], array2[2] * array3[0] - array2[0] * array3[2], array2[0] * array3[1] - array2[1] * array3[0]);
			if (!array[num].Normalize())
			{
				array[num] = Vector3D.AxisX;
			}
			num2 += 3;
			num++;
		}
		return array;
	}

	internal override bool _0023_003Dz1owWudHkrMNo9ZKfxq18_OA_003D(TraversalParams _0023_003DzELu0Pss_003D, out Point2D[] _0023_003DzrdSL0CI_003D, out bool _0023_003DzD5Gs7jmmc9uK, out int _0023_003DzHhJEwwk_003D, bool _0023_003DzjZRgeJk_003D = false)
	{
		Point2D[] array = new Point3D[0];
		_0023_003DzrdSL0CI_003D = array;
		_0023_003DzD5Gs7jmmc9uK = false;
		_0023_003DzHhJEwwk_003D = 1;
		if (_pointArray != null)
		{
			if (_pointArray.Length == 0)
			{
				_localOB = new OrientedBoundingBox(localMin, Vector3D.AxisX, Vector3D.AxisY, 0.0, 0.0, 0.0);
				return true;
			}
			array = GetPoints();
			_0023_003DzrdSL0CI_003D = array;
		}
		if (_localOB != null && !_localOB._0023_003DziQOhVy0_003D && (RegenMode == regenType.NotNeeded || _0023_003DzjZRgeJk_003D))
		{
			return true;
		}
		if (_0023_003DzrdSL0CI_003D.Length != 0)
		{
			_localOB = new OrientedBoundingBox(_0023_003DzrdSL0CI_003D);
			return true;
		}
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968689));
	}

	internal override bool _0023_003Dzx8kz5PbHANjMBSWqdAepaxo_003D(TraversalParams _0023_003DzELu0Pss_003D, out Point2D[] _0023_003DzrdSL0CI_003D, out bool _0023_003DzD5Gs7jmmc9uK, out int _0023_003DzHhJEwwk_003D, bool _0023_003DzjZRgeJk_003D = false)
	{
		_0023_003DzrdSL0CI_003D = new Point2D[0];
		_0023_003DzD5Gs7jmmc9uK = false;
		_0023_003DzHhJEwwk_003D = 1;
		if (_pointArray != null)
		{
			if (_pointArray.Length == 0)
			{
				_localOB = new OrientedBoundingRect(localMin, Vector2D.AxisX, Vector2D.AxisY, 0.0, 0.0);
				return true;
			}
			Point3D[] points = GetPoints();
			_0023_003DzrdSL0CI_003D = new Point2D[points.Length];
			for (int i = 0; i < points.Length; i++)
			{
				_0023_003DzrdSL0CI_003D[i] = new Point2D(points[i].X, points[i].Y);
			}
		}
		if (_localOB != null && !_localOB._0023_003DziQOhVy0_003D && (RegenMode == regenType.NotNeeded || _0023_003DzjZRgeJk_003D))
		{
			return true;
		}
		if (_0023_003DzrdSL0CI_003D.Length != 0)
		{
			_localOB = new OrientedBoundingRect(_0023_003DzrdSL0CI_003D);
			return true;
		}
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968689));
	}

	public void GetTightBBox(out Point3D boxMin, out Point3D boxMax)
	{
		ComputeBoundingBox(null, out boxMin, out boxMax);
	}
}
