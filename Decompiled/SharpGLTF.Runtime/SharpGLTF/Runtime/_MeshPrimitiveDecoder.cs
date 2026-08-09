using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using SharpGLTF.Schema2;
using SharpGLTF.Transforms;

namespace SharpGLTF.Runtime;

[DebuggerDisplay("{_GetDebugString(),nq}")]
internal sealed class _MeshPrimitiveDecoder<TMaterial> : _MeshPrimitiveDecoder, IMeshPrimitiveDecoder<TMaterial>, IMeshPrimitiveDecoder where TMaterial : class
{
	private readonly TMaterial _Material;

	public TMaterial Material => _Material;

	internal _MeshPrimitiveDecoder(MeshPrimitive srcPrim)
		: base(srcPrim)
	{
		_Material = srcPrim.Material as TMaterial;
	}
}
[DebuggerDisplay("{_GetDebugString(),nq}")]
internal class _MeshPrimitiveDecoder : IMeshPrimitiveDecoder
{
	private readonly PrimitiveType _PrimitiveType;

	private readonly IReadOnlyList<uint> _PrimitiveIndices;

	internal readonly _MeshGeometryDecoder _Geometry;

	internal readonly List<_MorphTargetDecoder> _MorphTargets = new List<_MorphTargetDecoder>();

	private readonly IReadOnlyList<Vector4> _Color0;

	private readonly IReadOnlyList<Vector4> _Color1;

	private readonly int _ColorsCount;

	private readonly IReadOnlyList<Vector2> _TexCoord0;

	private readonly IReadOnlyList<Vector2> _TexCoord1;

	private readonly IReadOnlyList<Vector2> _TexCoord2;

	private readonly IReadOnlyList<Vector2> _TexCoord3;

	private readonly int _TexCoordCount;

	private readonly IReadOnlyList<Vector4> _Joints0;

	private readonly IReadOnlyList<Vector4> _Joints1;

	private readonly IReadOnlyList<Vector4> _Weights0;

	private readonly IReadOnlyList<Vector4> _Weights1;

	private readonly int _JointsWeightsCount;

	private readonly object _Extras;

	public int VertexCount => _Geometry.VertexCount;

	public int ColorsCount => _ColorsCount;

	public int TexCoordsCount => _TexCoordCount;

	public int JointsWeightsCount => _JointsWeightsCount;

	public int MorphTargetsCount => _MorphTargets.Count;

	public bool IsPointIndices => _PrimitiveType.GetPrimitiveVertexSize() == 1;

	public IEnumerable<(int A, int B)> LineIndices
	{
		get
		{
			if (_PrimitiveType.GetPrimitiveVertexSize() != 2)
			{
				return Enumerable.Empty<(int, int)>();
			}
			if (_PrimitiveIndices == null)
			{
				return _PrimitiveType.GetLinesIndices(VertexCount);
			}
			return _PrimitiveType.GetLinesIndices(_PrimitiveIndices);
		}
	}

	public IEnumerable<(int A, int B, int C)> TriangleIndices
	{
		get
		{
			if (_PrimitiveType.GetPrimitiveVertexSize() != 3)
			{
				return Enumerable.Empty<(int, int, int)>();
			}
			if (_PrimitiveIndices == null)
			{
				return _PrimitiveType.GetTrianglesIndices(VertexCount);
			}
			return _PrimitiveType.GetTrianglesIndices(_PrimitiveIndices);
		}
	}

	protected virtual string _GetDebugString()
	{
		int vertexCount = _Geometry.VertexCount;
		int num = TriangleIndices.Count();
		return $"Primitive Vertices:{vertexCount} Triangles:{num}";
	}

	internal _MeshPrimitiveDecoder(MeshPrimitive srcPrim)
	{
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0342: Unknown result type (might be due to invalid IL or missing references)
		//IL_0347: Unknown result type (might be due to invalid IL or missing references)
		_Extras = srcPrim.Extras;
		_PrimitiveType = srcPrim.DrawPrimitiveType;
		_PrimitiveIndices = srcPrim.GetIndices() as IReadOnlyList<uint>;
		_Geometry = new _MeshGeometryDecoder(this, srcPrim);
		for (int i = 0; i < srcPrim.MorphTargetsCount; i++)
		{
			_MorphTargetDecoder item = new _MorphTargetDecoder(_Geometry, srcPrim, i);
			_MorphTargets.Add(item);
		}
		_Color0 = srcPrim.GetVertexAccessor("COLOR_0")?.AsColorArray();
		_Color1 = srcPrim.GetVertexAccessor("COLOR_1")?.AsColorArray();
		_ColorsCount = ((_Color0 != null) ? 1 : 0) + ((_Color1 != null) ? 1 : 0);
		_TexCoord0 = srcPrim.GetVertexAccessor("TEXCOORD_0")?.AsVector2Array();
		_TexCoord1 = srcPrim.GetVertexAccessor("TEXCOORD_1")?.AsVector2Array();
		_TexCoord2 = srcPrim.GetVertexAccessor("TEXCOORD_2")?.AsVector2Array();
		_TexCoord3 = srcPrim.GetVertexAccessor("TEXCOORD_3")?.AsVector2Array();
		_TexCoordCount = ((_TexCoord0 != null) ? 1 : 0) + ((_TexCoord1 != null) ? 1 : 0) + ((_TexCoord2 != null) ? 1 : 0) + ((_TexCoord3 != null) ? 1 : 0);
		_Joints0 = srcPrim.GetVertexAccessor("JOINTS_0")?.AsVector4Array();
		_Joints1 = srcPrim.GetVertexAccessor("JOINTS_1")?.AsVector4Array();
		_Weights0 = srcPrim.GetVertexAccessor("WEIGHTS_0")?.AsVector4Array();
		_Weights1 = srcPrim.GetVertexAccessor("WEIGHTS_1")?.AsVector4Array();
		if (_Joints0 == null || _Weights0 == null)
		{
			_Joints0 = (_Joints1 = (_Weights0 = (_Weights1 = null)));
		}
		if (_Joints1 == null || _Weights1 == null)
		{
			_Joints1 = (_Weights1 = null);
		}
		_JointsWeightsCount = ((_Joints0 != null) ? 4 : 0) + ((_Joints1 != null) ? 4 : 0);
		if (_Weights0 != null && _Weights1 == null)
		{
			Vector4[] array = _Weights0.ToArray();
			for (int j = 0; j < array.Length; j++)
			{
				float num = Vector4.Dot(array[j], Vector4.One);
				ref Vector4 reference = ref array[j];
				reference /= num;
			}
			_Weights0 = array;
		}
		if (_Weights0 != null && _Weights1 != null)
		{
			Vector4[] array2 = _Weights0.ToArray();
			Vector4[] array3 = _Weights1.ToArray();
			for (int k = 0; k < array2.Length; k++)
			{
				float num2 = Vector4.Dot(array2[k], Vector4.One) + Vector4.Dot(array3[k], Vector4.One);
				ref Vector4 reference2 = ref array2[k];
				reference2 /= num2;
				ref Vector4 reference3 = ref array3[k];
				reference3 /= num2;
			}
			_Weights0 = array2;
			_Weights1 = array3;
		}
	}

	public Vector3 GetPosition(int vertexIndex)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return _Geometry.GetPosition(vertexIndex);
	}

	public IReadOnlyList<Vector3> GetPositionDeltas(int vertexIndex)
	{
		if (MorphTargetsCount <= 0)
		{
			return Array.Empty<Vector3>();
		}
		return new _MorphTargetPositionSlice(_MorphTargets, vertexIndex);
	}

	public Vector3 GetNormal(int vertexIndex)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return _Geometry.GetNormal(vertexIndex);
	}

	public IReadOnlyList<Vector3> GetNormalDeltas(int vertexIndex)
	{
		if (MorphTargetsCount <= 0)
		{
			return Array.Empty<Vector3>();
		}
		return new _MorphTargetNormalSlice(_MorphTargets, vertexIndex);
	}

	public Vector4 GetTangent(int vertexIndex)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return _Geometry.GetTangent(vertexIndex);
	}

	public IReadOnlyList<Vector3> GetTangentDeltas(int vertexIndex)
	{
		if (MorphTargetsCount <= 0)
		{
			return Array.Empty<Vector3>();
		}
		return new _MorphTargetTangentSlice(_MorphTargets, vertexIndex);
	}

	public Vector2 GetTextureCoord(int vertexIndex, int set)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		if (set == 0 && _TexCoord0 != null)
		{
			return _TexCoord0[vertexIndex];
		}
		if (set == 1 && _TexCoord1 != null)
		{
			return _TexCoord1[vertexIndex];
		}
		if (set == 2 && _TexCoord2 != null)
		{
			return _TexCoord2[vertexIndex];
		}
		if (set == 3 && _TexCoord3 != null)
		{
			return _TexCoord3[vertexIndex];
		}
		return Vector2.Zero;
	}

	public IReadOnlyList<Vector2> GetTextureCoordDeltas(int vertexIndex, int texCoordSet)
	{
		if (MorphTargetsCount <= 0)
		{
			return Array.Empty<Vector2>();
		}
		return new _MorphTargetTexCoordSlice(_MorphTargets, vertexIndex, texCoordSet);
	}

	public Vector4 GetColor(int vertexIndex, int set)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		if (set == 0 && _Color0 != null)
		{
			return _Color0[vertexIndex];
		}
		if (set == 1 && _Color1 != null)
		{
			return _Color1[vertexIndex];
		}
		return Vector4.One;
	}

	public IReadOnlyList<Vector4> GetColorDeltas(int vertexIndex, int colorSet)
	{
		if (MorphTargetsCount <= 0)
		{
			return Array.Empty<Vector4>();
		}
		return new _MorphTargetColorSlice(_MorphTargets, vertexIndex, colorSet);
	}

	public SparseWeight8 GetSkinWeights(int vertexIndex)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		if (_Weights0 == null)
		{
			return default(SparseWeight8);
		}
		return SparseWeight8.CreateUnchecked(_Joints0[vertexIndex], (_Joints1 == null) ? Vector4.Zero : _Joints1[vertexIndex], _Weights0[vertexIndex], (_Weights1 == null) ? Vector4.Zero : _Weights1[vertexIndex]);
	}
}
