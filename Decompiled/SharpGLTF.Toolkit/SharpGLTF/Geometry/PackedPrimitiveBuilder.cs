using System;
using System.Collections.Generic;
using System.Linq;
using SharpGLTF.Geometry.VertexTypes;
using SharpGLTF.Memory;
using SharpGLTF.Schema2;

namespace SharpGLTF.Geometry;

internal sealed class PackedPrimitiveBuilder<TMaterial>
{
	private readonly TMaterial _Material;

	private readonly int _VerticesPerPrimitive;

	private Type _StridedVertexType;

	private MemoryAccessor[] _VertexAccessors;

	private MemoryAccessor _IndexAccessors;

	private readonly List<MemoryAccessor[]> _MorphTargets = new List<MemoryAccessor[]>();

	public PackedPrimitiveBuilder(TMaterial material, int primitiveVertexCount)
	{
		SharpGLTF.Guard.MustBeBetweenOrEqualTo(primitiveVertexCount, 1, 3, "primitiveVertexCount");
		_Material = material;
		_VerticesPerPrimitive = primitiveVertexCount;
	}

	public void SetStridedVertices(IPrimitiveReader<TMaterial> srcPrim, PackedEncoding vertexEncoding)
	{
		SharpGLTF.Guard.NotNull(srcPrim, "srcPrim");
		MemoryAccessor[] array = srcPrim.Vertices.CreateVertexMemoryAccessors(vertexEncoding);
		SharpGLTF.Guard.NotNull(array, "srcPrim");
		_StridedVertexType = srcPrim.VertexType;
		_VertexAccessors = array;
	}

	public void SetStreamedVertices(IPrimitiveReader<TMaterial> srcPrim, PackedEncoding vertexEncoding)
	{
		SharpGLTF.Guard.NotNull(srcPrim, "srcPrim");
		List<string> list = (from item in srcPrim.Vertices[0].GetVertexAttributes(srcPrim.Vertices.Count, vertexEncoding)
			select item.Name).ToList();
		List<MemoryAccessor> list2 = new List<MemoryAccessor>();
		SharpGLTF.GuardAll.MustBeEqualTo(list2.Select((MemoryAccessor item) => item.Attribute.ByteOffset), 0, "vAccessors");
		SharpGLTF.GuardAll.MustBeEqualTo(list2.Select((MemoryAccessor item) => item.Attribute.ByteStride), 0, "vAccessors");
		foreach (string item in list)
		{
			MemoryAccessor memoryAccessor = srcPrim.Vertices.CreateVertexMemoryAccessor(item, vertexEncoding);
			if (memoryAccessor != null)
			{
				list2.Add(memoryAccessor);
			}
		}
		_VertexAccessors = list2.ToArray();
		MemoryAccessor.SanitizeVertexAttributes(_VertexAccessors);
	}

	public void SetIndices(IPrimitiveReader<TMaterial> srcPrim, EncodingType encoding)
	{
		SharpGLTF.Guard.NotNull(srcPrim, "srcPrim");
		MemoryAccessor memoryAccessor = srcPrim.GetIndices().CreateIndexMemoryAccessor(encoding);
		if (_VerticesPerPrimitive == 1)
		{
			SharpGLTF.Guard.MustBeNull(memoryAccessor, "srcPrim");
		}
		else
		{
			SharpGLTF.Guard.NotNull(memoryAccessor, "iAccessor");
		}
		_IndexAccessors = memoryAccessor;
	}

	public void SetMorphTargets(IPrimitiveReader<TMaterial> srcPrim, PackedEncoding vertexEncodings, ISet<string> morphTargetAttributes)
	{
		bool flag = _VertexAccessors.Any((MemoryAccessor item) => item.Attribute.Name == "POSITION");
		bool flag2 = _VertexAccessors.Any((MemoryAccessor item) => item.Attribute.Name == "NORMAL");
		bool flag3 = _VertexAccessors.Any((MemoryAccessor item) => item.Attribute.Name == "TANGENT");
		bool flag4 = _VertexAccessors.Any((MemoryAccessor item) => item.Attribute.Name == "COLOR_0");
		bool flag5 = _VertexAccessors.Any((MemoryAccessor item) => item.Attribute.Name == "COLOR_1");
		bool flag6 = _VertexAccessors.Any((MemoryAccessor item) => item.Attribute.Name == "TEXCOORD_0");
		bool flag7 = _VertexAccessors.Any((MemoryAccessor item) => item.Attribute.Name == "TEXCOORD_1");
		bool flag8 = _VertexAccessors.Any((MemoryAccessor item) => item.Attribute.Name == "TEXCOORD_2");
		bool flag9 = _VertexAccessors.Any((MemoryAccessor item) => item.Attribute.Name == "TEXCOORD_3");
		for (int num = 0; num < srcPrim.MorphTargets.Count; num++)
		{
			(MemoryAccessor Pos, MemoryAccessor Nrm, MemoryAccessor Tgt, MemoryAccessor Col0, MemoryAccessor Col1, MemoryAccessor Tuv0, MemoryAccessor Tuv1, MemoryAccessor Tuv2, MemoryAccessor Tuv3) tuple = srcPrim._GetMorphTargetAccessors(num, vertexEncodings, morphTargetAttributes);
			MemoryAccessor memoryAccessor = tuple.Pos;
			MemoryAccessor memoryAccessor2 = tuple.Nrm;
			MemoryAccessor memoryAccessor3 = tuple.Tgt;
			MemoryAccessor memoryAccessor4 = tuple.Col0;
			MemoryAccessor memoryAccessor5 = tuple.Col1;
			MemoryAccessor memoryAccessor6 = tuple.Tuv0;
			MemoryAccessor memoryAccessor7 = tuple.Tuv1;
			MemoryAccessor memoryAccessor8 = tuple.Rest.Item1;
			MemoryAccessor memoryAccessor9 = tuple.Rest.Item2;
			if (!flag)
			{
				memoryAccessor = null;
			}
			if (!flag2)
			{
				memoryAccessor2 = null;
			}
			if (!flag3)
			{
				memoryAccessor3 = null;
			}
			if (!flag4)
			{
				memoryAccessor4 = null;
			}
			if (!flag5)
			{
				memoryAccessor5 = null;
			}
			if (!flag6)
			{
				memoryAccessor6 = null;
			}
			if (!flag7)
			{
				memoryAccessor7 = null;
			}
			if (!flag8)
			{
				memoryAccessor8 = null;
			}
			if (!flag9)
			{
				memoryAccessor9 = null;
			}
			AddMorphTarget(memoryAccessor, memoryAccessor2, memoryAccessor3, memoryAccessor4, memoryAccessor5, memoryAccessor6, memoryAccessor7, memoryAccessor8, memoryAccessor9);
		}
	}

	private void AddMorphTarget(params MemoryAccessor[] morphTarget)
	{
		morphTarget = (from item in morphTarget
			where item != null
			select _removeDeltaSuffix(item)).ToArray();
		_MorphTargets.Add(morphTarget);
		static MemoryAccessor _removeDeltaSuffix(MemoryAccessor accessor)
		{
			string name = accessor.Attribute.Name;
			if (!name.EndsWith("DELTA", StringComparison.Ordinal))
			{
				throw new InvalidOperationException();
			}
			name = SharpGLTF._Extensions.Replace(name, "DELTA", string.Empty, StringComparison.Ordinal);
			MemoryAccessInfo attribute = accessor.Attribute;
			attribute.Name = name;
			return new MemoryAccessor(accessor.Data, attribute);
		}
	}

	internal void CopyToMesh(Mesh dstMesh, Converter<TMaterial, Material> materialEvaluator)
	{
		if (_VerticesPerPrimitive < 1 || _VerticesPerPrimitive > 3)
		{
			return;
		}
		if (_VerticesPerPrimitive == 1)
		{
			MeshPrimitive dstPrim = dstMesh.CreatePrimitive().WithMaterial(materialEvaluator(_Material)).WithVertexAccessors((IEnumerable<MemoryAccessor>)_VertexAccessors)
				.WithIndicesAutomatic(PrimitiveType.POINTS);
			CopyMorphTargets(dstPrim);
			return;
		}
		PrimitiveType primitiveType = PrimitiveType.LINES;
		if (_VerticesPerPrimitive == 3)
		{
			primitiveType = PrimitiveType.TRIANGLES;
		}
		MeshPrimitive dstPrim2 = dstMesh.CreatePrimitive().WithMaterial(materialEvaluator(_Material)).WithVertexAccessors((IEnumerable<MemoryAccessor>)_VertexAccessors)
			.WithIndicesAccessor(primitiveType, _IndexAccessors);
		CopyMorphTargets(dstPrim2);
	}

	private void CopyMorphTargets(MeshPrimitive dstPrim)
	{
		for (int i = 0; i < _MorphTargets.Count; i++)
		{
			if (_MorphTargets[i] == null || _MorphTargets[i].Length == 0)
			{
				throw new InvalidOperationException("all morph targets must have at least one accessor");
			}
			dstPrim.WithMorphTargetAccessors(i, _MorphTargets[i]);
		}
	}

	public static void MergeBuffers(IEnumerable<PackedPrimitiveBuilder<TMaterial>> primitives)
	{
		try
		{
			_MergeIndices(primitives);
			_MergeStridedVertices(primitives.Where((PackedPrimitiveBuilder<TMaterial> p) => p._StridedVertexType != null));
			_MergeSequentialVertices(from p in primitives
				where p._StridedVertexType == null
				select p._VertexAccessors);
			_MergeSequentialVertices(primitives.SelectMany((PackedPrimitiveBuilder<TMaterial> p) => p._MorphTargets));
		}
		catch (OverflowException innerException)
		{
			throw new ArgumentException("the combined size of all the meshes exceeds the maximum capacity of the buffers, try disabling Buffers merging", innerException);
		}
	}

	private static void _MergeSequentialVertices(IEnumerable<MemoryAccessor[]> primitives)
	{
		Dictionary<(string, int), PackedBuffer> dictionary = new Dictionary<(string, int), PackedBuffer>();
		foreach (MemoryAccessor[] primitive in primitives)
		{
			MemoryAccessor[] array = primitive;
			foreach (MemoryAccessor memoryAccessor in array)
			{
				string name = memoryAccessor.Attribute.Name;
				int paddedByteLength = memoryAccessor.Attribute.PaddedByteLength;
				if (!dictionary.TryGetValue((name, paddedByteLength), out var value))
				{
					value = (dictionary[(name, paddedByteLength)] = new PackedBuffer());
				}
				value.AddAccessors(memoryAccessor);
			}
		}
		foreach (PackedBuffer value2 in dictionary.Values)
		{
			value2.MergeBuffers();
		}
	}

	private static void _MergeStridedVertices(IEnumerable<PackedPrimitiveBuilder<TMaterial>> primitives)
	{
		IEnumerable<IGrouping<Type, PackedPrimitiveBuilder<TMaterial>>> enumerable = from item in primitives.ToList()
			group item by item._StridedVertexType;
		foreach (IGrouping<Type, PackedPrimitiveBuilder<TMaterial>> item in enumerable)
		{
			PackedBuffer packedBuffer = new PackedBuffer();
			foreach (PackedPrimitiveBuilder<TMaterial> item2 in item)
			{
				packedBuffer.AddAccessors(item2._VertexAccessors);
			}
			packedBuffer.MergeBuffers();
		}
	}

	private static void _MergeIndices(IEnumerable<PackedPrimitiveBuilder<TMaterial>> primitives)
	{
		PackedBuffer packedBuffer = new PackedBuffer();
		foreach (PackedPrimitiveBuilder<TMaterial> primitive in primitives)
		{
			packedBuffer.AddAccessors(primitive._IndexAccessors);
		}
		packedBuffer.MergeBuffers();
	}
}
