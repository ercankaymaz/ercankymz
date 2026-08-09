using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using SharpGLTF.Geometry.VertexTypes;
using SharpGLTF.Runtime;
using SharpGLTF.Transforms;

namespace SharpGLTF.Geometry;

public class VertexBufferColumns
{
	private readonly struct _NormalTangentAgent(VertexBufferColumns vertices, IEnumerable<(int A, int B, int C)> indices) : SharpGLTF.Runtime.VertexNormalsFactory.IMeshPrimitive, SharpGLTF.Runtime.VertexTangentsFactory.IMeshPrimitive
	{
		private readonly VertexBufferColumns _Vertices = vertices;

		private readonly IEnumerable<(int A, int B, int C)> _Indices = indices;

		public int VertexCount => _Vertices.Positions.Count;

		public IEnumerable<(int A, int B, int C)> GetTriangleIndices()
		{
			return _Indices;
		}

		public Vector3 GetVertexPosition(int idx)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			return _Vertices.Positions[idx];
		}

		public Vector3 GetVertexNormal(int idx)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			return _Vertices.Normals[idx];
		}

		public Vector2 GetVertexTexCoord(int idx)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			return _Vertices.TexCoords0[idx];
		}

		public void SetVertexNormal(int idx, Vector3 normal)
		{
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			VertexBufferColumns vertices = _Vertices;
			if (vertices.Normals == null)
			{
				IList<Vector3> list = (vertices.Normals = (IList<Vector3>)(object)new Vector3[_Vertices.Positions.Count]);
			}
			_Vertices.Normals[idx] = normal;
		}

		public void SetVertexTangent(int idx, Vector4 tangent)
		{
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			VertexBufferColumns vertices = _Vertices;
			if (vertices.Tangents == null)
			{
				IList<Vector4> list = (vertices.Tangents = (IList<Vector4>)(object)new Vector4[_Vertices.Positions.Count]);
			}
			_Vertices.Tangents[idx] = tangent;
		}
	}

	private const string ERR_COLUMNLEN = "Column length mismatch.";

	private List<VertexBufferColumns> _MorphTargets;

	public IList<Vector3> Positions { get; set; }

	public IList<Vector3> Normals { get; set; }

	public IList<Vector4> Tangents { get; set; }

	public IList<Vector4> Colors0 { get; set; }

	public IList<Vector4> Colors1 { get; set; }

	public IList<Vector2> TexCoords0 { get; set; }

	public IList<Vector2> TexCoords1 { get; set; }

	public IList<Vector2> TexCoords2 { get; set; }

	public IList<Vector2> TexCoords3 { get; set; }

	public IList<Vector4> Joints0 { get; set; }

	public IList<Vector4> Joints1 { get; set; }

	public IList<Vector4> Weights0 { get; set; }

	public IList<Vector4> Weights1 { get; set; }

	public IReadOnlyList<VertexBufferColumns> MorphTargets
	{
		get
		{
			IReadOnlyList<VertexBufferColumns> morphTargets = _MorphTargets;
			return morphTargets ?? Array.Empty<VertexBufferColumns>();
		}
	}

	public VertexBufferColumns()
	{
	}

	public VertexBufferColumns(VertexBufferColumns other)
	{
		SharpGLTF.Guard.NotNull(other, "other");
		Positions = other.Positions;
		Normals = other.Normals;
		Tangents = other.Tangents;
		Colors0 = other.Colors0;
		Colors1 = other.Colors1;
		TexCoords0 = other.TexCoords0;
		TexCoords1 = other.TexCoords1;
		TexCoords2 = other.TexCoords2;
		TexCoords3 = other.TexCoords3;
		Joints0 = other.Joints0;
		Joints1 = other.Joints1;
		Weights0 = other.Weights0;
		Weights1 = other.Weights1;
		_MorphTargets = other._MorphTargets;
	}

	private static T[] _IsolateColumn<T>(IList<T> column)
	{
		if (column == null)
		{
			return null;
		}
		T[] array = new T[column.Count];
		column.CopyTo(array, 0);
		return array;
	}

	public void IsolateColumns()
	{
		Positions = _IsolateColumn(Positions);
		Normals = _IsolateColumn(Normals);
		Tangents = _IsolateColumn(Tangents);
		Colors0 = _IsolateColumn(Colors0);
		Colors1 = _IsolateColumn(Colors1);
		TexCoords0 = _IsolateColumn(TexCoords0);
		TexCoords1 = _IsolateColumn(TexCoords1);
		TexCoords2 = _IsolateColumn(TexCoords2);
		TexCoords3 = _IsolateColumn(TexCoords3);
		Joints0 = _IsolateColumn(Joints0);
		Joints1 = _IsolateColumn(Joints1);
		Weights0 = _IsolateColumn(Weights0);
		Weights1 = _IsolateColumn(Weights1);
		if (_MorphTargets == null)
		{
			return;
		}
		foreach (VertexBufferColumns morphTarget in _MorphTargets)
		{
			morphTarget.IsolateColumns();
		}
	}

	public VertexBufferColumns WithTransform(IGeometryTransform transform)
	{
		SharpGLTF.Guard.NotNull(transform, "transform");
		VertexBufferColumns vertexBufferColumns = new VertexBufferColumns(this);
		vertexBufferColumns._ApplyTransform(transform);
		return vertexBufferColumns;
	}

	private void _ApplyTransform(IGeometryTransform transform)
	{
		//IL_0635: Unknown result type (might be due to invalid IL or missing references)
		//IL_063d: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05de: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0579: Unknown result type (might be due to invalid IL or missing references)
		//IL_057e: Unknown result type (might be due to invalid IL or missing references)
		//IL_058f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0594: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_067e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0686: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0721: Unknown result type (might be due to invalid IL or missing references)
		//IL_0728: Unknown result type (might be due to invalid IL or missing references)
		//IL_076b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0772: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0806: Unknown result type (might be due to invalid IL or missing references)
		//IL_0843: Unknown result type (might be due to invalid IL or missing references)
		//IL_084a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0887: Unknown result type (might be due to invalid IL or missing references)
		//IL_088e: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(Positions, "Positions", "Missing Positions column");
		if (Normals != null)
		{
			SharpGLTF.Guard.IsTrue(Positions.Count == Normals.Count, "Normals", "Column length mismatch.");
		}
		if (Tangents != null)
		{
			SharpGLTF.Guard.IsTrue(Positions.Count == Tangents.Count, "Tangents", "Column length mismatch.");
		}
		if (Colors0 != null)
		{
			SharpGLTF.Guard.IsTrue(Positions.Count == Colors0.Count, "Colors0", "Column length mismatch.");
		}
		if (Colors1 != null)
		{
			SharpGLTF.Guard.IsTrue(Positions.Count == Colors1.Count, "Colors1", "Column length mismatch.");
		}
		if (TexCoords0 != null)
		{
			SharpGLTF.Guard.IsTrue(Positions.Count == TexCoords0.Count, "TexCoords0", "Column length mismatch.");
		}
		if (TexCoords1 != null)
		{
			SharpGLTF.Guard.IsTrue(Positions.Count == TexCoords1.Count, "TexCoords1", "Column length mismatch.");
		}
		if (TexCoords2 != null)
		{
			SharpGLTF.Guard.IsTrue(Positions.Count == TexCoords2.Count, "TexCoords2", "Column length mismatch.");
		}
		if (TexCoords3 != null)
		{
			SharpGLTF.Guard.IsTrue(Positions.Count == TexCoords3.Count, "TexCoords3", "Column length mismatch.");
		}
		if (Joints0 != null)
		{
			SharpGLTF.Guard.IsTrue(Positions.Count == Joints0.Count, "Joints0", "Column length mismatch.");
		}
		if (Joints1 != null)
		{
			SharpGLTF.Guard.IsTrue(Positions.Count == Joints1.Count, "Joints1", "Column length mismatch.");
		}
		if (Weights0 != null)
		{
			SharpGLTF.Guard.IsTrue(Positions.Count == Weights0.Count, "Weights0", "Column length mismatch.");
		}
		if (Weights1 != null)
		{
			SharpGLTF.Guard.IsTrue(Positions.Count == Weights1.Count, "Weights1", "Column length mismatch.");
		}
		Positions = _IsolateColumn(Positions);
		Normals = _IsolateColumn(Normals);
		Tangents = _IsolateColumn(Tangents);
		Colors0 = _IsolateColumn(Colors0);
		Colors1 = _IsolateColumn(Colors1);
		TexCoords0 = _IsolateColumn(TexCoords0);
		TexCoords1 = _IsolateColumn(TexCoords1);
		TexCoords2 = _IsolateColumn(TexCoords2);
		TexCoords3 = _IsolateColumn(TexCoords3);
		SparseWeight8 skinWeights = default(SparseWeight8);
		Vector3[] array = null;
		Vector3[] array2 = null;
		Vector3[] array3 = null;
		Vector4[] array4 = null;
		Vector4[] array5 = null;
		Vector2[] array6 = null;
		Vector2[] array7 = null;
		Vector2[] array8 = null;
		Vector2[] array9 = null;
		if (_MorphTargets != null)
		{
			if (_MorphTargets.All((VertexBufferColumns item) => item.Positions != null))
			{
				array = (Vector3[])(object)new Vector3[MorphTargets.Count];
			}
			if (_MorphTargets.All((VertexBufferColumns item) => item.Normals != null))
			{
				array2 = (Vector3[])(object)new Vector3[MorphTargets.Count];
			}
			if (_MorphTargets.All((VertexBufferColumns item) => item.Tangents != null))
			{
				array3 = (Vector3[])(object)new Vector3[MorphTargets.Count];
			}
			if (_MorphTargets.All((VertexBufferColumns item) => item.Colors0 != null))
			{
				array4 = (Vector4[])(object)new Vector4[MorphTargets.Count];
			}
			if (_MorphTargets.All((VertexBufferColumns item) => item.Colors1 != null))
			{
				array5 = (Vector4[])(object)new Vector4[MorphTargets.Count];
			}
			if (_MorphTargets.All((VertexBufferColumns item) => item.TexCoords0 != null))
			{
				array6 = (Vector2[])(object)new Vector2[MorphTargets.Count];
			}
			if (_MorphTargets.All((VertexBufferColumns item) => item.TexCoords1 != null))
			{
				array7 = (Vector2[])(object)new Vector2[MorphTargets.Count];
			}
			if (_MorphTargets.All((VertexBufferColumns item) => item.TexCoords2 != null))
			{
				array8 = (Vector2[])(object)new Vector2[MorphTargets.Count];
			}
			if (_MorphTargets.All((VertexBufferColumns item) => item.TexCoords3 != null))
			{
				array9 = (Vector2[])(object)new Vector2[MorphTargets.Count];
			}
		}
		int count = Positions.Count;
		int i = 0;
		while (i < count)
		{
			if (Joints0 != null)
			{
				skinWeights = ((Joints1 == null) ? SparseWeight8.Create(Joints0[i], Weights0[i]) : SparseWeight8.Create(Joints0[i], Joints1[i], Weights0[i], Weights1[i]));
			}
			if (Positions != null)
			{
				_FillMorphData(array, (VertexBufferColumns vc) => vc.Positions[i]);
				Positions[i] = transform.TransformPosition(Positions[i], array, in skinWeights);
			}
			if (Normals != null)
			{
				_FillMorphData(array2, (VertexBufferColumns vc) => vc.Normals[i]);
				Normals[i] = transform.TransformNormal(Normals[i], array2, in skinWeights);
			}
			if (Tangents != null)
			{
				_FillMorphData(array3, (VertexBufferColumns vc) => vc.Tangents[i]);
				Tangents[i] = transform.TransformTangent(Tangents[i], array3, in skinWeights);
			}
			if (transform is IMaterialTransform materialTransform)
			{
				if (Colors0 != null)
				{
					_FillMorphData(array4, (VertexBufferColumns vc) => vc.Colors0[i]);
					Colors0[i] = materialTransform.MorphColors(Colors0[i], array4);
				}
				if (Colors1 != null)
				{
					_FillMorphData(array5, (VertexBufferColumns vc) => vc.Colors1[i]);
					Colors1[i] = materialTransform.MorphColors(Colors1[i], array5);
				}
				if (TexCoords0 != null)
				{
					_FillMorphData(array6, (VertexBufferColumns vc) => vc.TexCoords0[i]);
					TexCoords0[i] = materialTransform.MorphTexCoord(TexCoords0[i], array6);
				}
				if (TexCoords1 != null)
				{
					_FillMorphData(array7, (VertexBufferColumns vc) => vc.TexCoords1[i]);
					TexCoords1[i] = materialTransform.MorphTexCoord(TexCoords1[i], array7);
				}
				if (TexCoords2 != null)
				{
					_FillMorphData(array8, (VertexBufferColumns vc) => vc.TexCoords2[i]);
					TexCoords1[2] = materialTransform.MorphTexCoord(TexCoords2[i], array8);
				}
				if (TexCoords3 != null)
				{
					_FillMorphData(array9, (VertexBufferColumns vc) => vc.TexCoords3[i]);
					TexCoords3[2] = materialTransform.MorphTexCoord(TexCoords3[i], array9);
				}
			}
			int num = i + 1;
			i = num;
		}
		_MorphTargets = null;
		Joints0 = null;
		Joints1 = null;
		Weights0 = null;
		Weights1 = null;
	}

	private void _FillMorphData(Vector2[] array, Converter<VertexBufferColumns, Vector2> selector)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		if (array != null)
		{
			for (int i = 0; i < _MorphTargets.Count; i++)
			{
				array[i] = selector(_MorphTargets[i]);
			}
		}
	}

	private void _FillMorphData(Vector3[] array, Converter<VertexBufferColumns, Vector3> selector)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		if (array != null)
		{
			for (int i = 0; i < _MorphTargets.Count; i++)
			{
				array[i] = selector(_MorphTargets[i]);
			}
		}
	}

	private void _FillMorphData(Vector3[] array, Converter<VertexBufferColumns, Vector4> selector)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		if (array != null)
		{
			for (int i = 0; i < _MorphTargets.Count; i++)
			{
				Vector4 val = selector(_MorphTargets[i]);
				array[i] = new Vector3(val.X, val.Y, val.Z);
			}
		}
	}

	private void _FillMorphData(Vector4[] array, Converter<VertexBufferColumns, Vector4> selector)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		if (array != null)
		{
			for (int i = 0; i < _MorphTargets.Count; i++)
			{
				array[i] = selector(_MorphTargets[i]);
			}
		}
	}

	public VertexBufferColumns AddMorphTarget()
	{
		if (_MorphTargets == null)
		{
			_MorphTargets = new List<VertexBufferColumns>();
		}
		VertexBufferColumns vertexBufferColumns = new VertexBufferColumns();
		_MorphTargets.Add(vertexBufferColumns);
		return vertexBufferColumns;
	}

	public (Type BuilderType, Func<IVertexBuilder> BuilderFactory) GetCompatibleVertexType()
	{
		bool flag = Normals != null;
		bool hasTangents = flag && Tangents != null;
		int num = 0;
		if (Colors0 != null)
		{
			num = 1;
		}
		if (num == 1 && Colors1 != null)
		{
			num = 2;
		}
		int num2 = 0;
		if (TexCoords0 != null)
		{
			num2 = 1;
		}
		if (num2 == 1 && TexCoords1 != null)
		{
			num2 = 2;
		}
		if (num2 == 2 && TexCoords2 != null)
		{
			num2 = 3;
		}
		if (num2 == 3 && TexCoords3 != null)
		{
			num2 = 4;
		}
		int numJoints = 0;
		if (Joints0 != null)
		{
			numJoints = 4;
		}
		if (Joints0 != null && Joints1 != null)
		{
			numJoints = 8;
		}
		return VertexUtils.GetVertexBuilderType(flag, hasTangents, num, num2, numJoints);
	}

	private TvG GetVertexGeometry<TvG>(int index) where TvG : struct, IVertexGeometry
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		TvG result = default(TvG);
		if (Positions != null)
		{
			result.SetPosition(Positions[index]);
		}
		if (Normals != null)
		{
			result.SetNormal(Normals[index]);
		}
		if (Tangents != null)
		{
			result.SetTangent(Tangents[index]);
		}
		return result;
	}

	private TvM GetVertexMaterial<TvM>(int index) where TvM : struct, IVertexMaterial
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		TvM result = default(TvM);
		if (result.MaxColors > 0)
		{
			result.SetColor(0, (Colors0 == null) ? Vector4.One : Colors0[index]);
		}
		if (result.MaxColors > 1)
		{
			result.SetColor(1, (Colors1 == null) ? Vector4.One : Colors1[index]);
		}
		if (result.MaxTextCoords > 0)
		{
			result.SetTexCoord(0, (TexCoords0 == null) ? Vector2.Zero : TexCoords0[index]);
		}
		if (result.MaxTextCoords > 1)
		{
			result.SetTexCoord(1, (TexCoords1 == null) ? Vector2.Zero : TexCoords1[index]);
		}
		if (result.MaxTextCoords > 2)
		{
			result.SetTexCoord(2, (TexCoords2 == null) ? Vector2.Zero : TexCoords2[index]);
		}
		if (result.MaxTextCoords > 3)
		{
			result.SetTexCoord(3, (TexCoords3 == null) ? Vector2.Zero : TexCoords3[index]);
		}
		return result;
	}

	private TvS GetVertexSkinning<TvS>(int index) where TvS : struct, IVertexSkinning
	{
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		TvS result = default(TvS);
		if (result.MaxBindings == 0)
		{
			return result;
		}
		if (Joints0 != null && Weights0 != null)
		{
			if (Joints1 != null && Weights1 != null)
			{
				result.SetBindings(SparseWeight8.Create(Joints0[index], Joints1[index], Weights0[index], Weights1[index]));
			}
			else
			{
				result.SetBindings(SparseWeight8.Create(Joints0[index], Weights0[index]));
			}
		}
		return result;
	}

	public IVertexBuilder GetVertex(Func<IVertexBuilder> factory, int index)
	{
		VertexPositionNormalTangent vertexGeometry = GetVertexGeometry<VertexPositionNormalTangent>(index);
		VertexColor2Texture2 vertexMaterial = GetVertexMaterial<VertexColor2Texture2>(index);
		VertexJoints8 vertexSkinning = GetVertexSkinning<VertexJoints8>(index);
		return new VertexBuilder(vertexGeometry, vertexMaterial, vertexSkinning).ConvertToType(factory);
	}

	public VertexBuilder<TvG, TvM, VertexEmpty> GetVertex<TvG, TvM>(int index) where TvG : struct, IVertexGeometry where TvM : struct, IVertexMaterial
	{
		return new VertexBuilder<TvG, TvM, VertexEmpty>(GetVertexGeometry<TvG>(index), GetVertexMaterial<TvM>(index));
	}

	public VertexBuilder<TvG, TvM, TvS> GetVertex<TvG, TvM, TvS>(int index) where TvG : struct, IVertexGeometry where TvM : struct, IVertexMaterial where TvS : struct, IVertexSkinning
	{
		return new VertexBuilder<TvG, TvM, TvS>(GetVertexGeometry<TvG>(index), GetVertexMaterial<TvM>(index), GetVertexSkinning<TvS>(index));
	}

	public static void CalculateSmoothNormals(IReadOnlyList<(VertexBufferColumns Vertices, IEnumerable<(int A, int B, int C)> Indices)> primitives)
	{
		SharpGLTF.Guard.NotNull(primitives, "primitives");
		IEnumerable<_NormalTangentAgent> primitives2 = primitives.Select(((VertexBufferColumns Vertices, IEnumerable<(int A, int B, int C)> Indices) item) => new _NormalTangentAgent(item.Vertices, item.Indices));
		SharpGLTF.Runtime.VertexNormalsFactory.CalculateSmoothNormals(primitives2);
	}

	public static void CalculateTangents(IReadOnlyList<(VertexBufferColumns Vertices, IEnumerable<(int A, int B, int C)> Indices)> primitives)
	{
		SharpGLTF.Guard.NotNull(primitives, "primitives");
		IEnumerable<_NormalTangentAgent> primitives2 = primitives.Select(((VertexBufferColumns Vertices, IEnumerable<(int A, int B, int C)> Indices) item) => new _NormalTangentAgent(item.Vertices, item.Indices));
		SharpGLTF.Runtime.VertexTangentsFactory.CalculateTangents(primitives2);
	}
}
