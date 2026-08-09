using System.Collections.Generic;
using System.Linq;
using SharpGLTF.Geometry.VertexTypes;
using SharpGLTF.Memory;
using SharpGLTF.Schema2;

namespace SharpGLTF.Geometry;

internal static class _PackedPrimitiveHelpers
{
	public static void _GatherMorphTargetAttributes<TMaterial>(this IPrimitiveReader<TMaterial> srcPrim, HashSet<string> attributes)
	{
		PackedEncoding packedEncoding = new PackedEncoding();
		packedEncoding.ColorEncoding = EncodingType.FLOAT;
		for (int i = 0; i < srcPrim.MorphTargets.Count; i++)
		{
			(MemoryAccessor, MemoryAccessor, MemoryAccessor, MemoryAccessor, MemoryAccessor, MemoryAccessor, MemoryAccessor, MemoryAccessor, MemoryAccessor) tuple = srcPrim._GetMorphTargetAccessors(i, packedEncoding, new HashSet<string>());
			if (tuple.Item1 != null)
			{
				attributes.Add("POSITIONDELTA");
			}
			if (tuple.Item2 != null)
			{
				attributes.Add("NORMALDELTA");
			}
			if (tuple.Item3 != null)
			{
				attributes.Add("TANGENTDELTA");
			}
			if (tuple.Item4 != null)
			{
				attributes.Add("COLOR_0DELTA");
			}
			if (tuple.Item5 != null)
			{
				attributes.Add("COLOR_1DELTA");
			}
			if (tuple.Item6 != null)
			{
				attributes.Add("TEXCOORD_0DELTA");
			}
			if (tuple.Item7 != null)
			{
				attributes.Add("TEXCOORD_1DELTA");
			}
			if (tuple.Rest.Item1 != null)
			{
				attributes.Add("TEXCOORD_2DELTA");
			}
			if (tuple.Rest.Item2 != null)
			{
				attributes.Add("TEXCOORD_3DELTA");
			}
		}
	}

	public static (MemoryAccessor Pos, MemoryAccessor Nrm, MemoryAccessor Tgt, MemoryAccessor Col0, MemoryAccessor Col1, MemoryAccessor Tuv0, MemoryAccessor Tuv1, MemoryAccessor Tuv2, MemoryAccessor Tuv3) _GetMorphTargetAccessors<TMaterial>(this IPrimitiveReader<TMaterial> srcPrim, int morphTargetIdx, PackedEncoding vertexEncodings, ISet<string> requiredAttributes)
	{
		VertexBuilder<VertexGeometryDelta, VertexMaterialDelta, VertexEmpty>[] mtv = srcPrim.MorphTargets[morphTargetIdx].GetMorphTargetVertices(srcPrim.Vertices.Count);
		MemoryAccessor item = _createAccessor("POSITIONDELTA");
		MemoryAccessor item2 = _createAccessor("NORMALDELTA");
		MemoryAccessor item3 = _createAccessor("TANGENTDELTA");
		MemoryAccessor item4 = _createAccessor("COLOR_0DELTA");
		MemoryAccessor item5 = _createAccessor("COLOR_1DELTA");
		MemoryAccessor item6 = _createAccessor("TEXCOORD_0DELTA");
		MemoryAccessor item7 = _createAccessor("TEXCOORD_1DELTA");
		MemoryAccessor item8 = _createAccessor("TEXCOORD_2DELTA");
		MemoryAccessor item9 = _createAccessor("TEXCOORD_3DELTA");
		return (Pos: item, Nrm: item2, Tgt: item3, Col0: item4, Col1: item5, Tuv0: item6, Tuv1: item7, Tuv2: item8, Tuv3: item9);
		MemoryAccessor _createAccessor(string attributeName)
		{
			MemoryAccessor memoryAccessor = mtv.CreateVertexMemoryAccessor(attributeName, vertexEncodings);
			if (memoryAccessor == null)
			{
				return null;
			}
			if (requiredAttributes.Contains(attributeName))
			{
				return memoryAccessor;
			}
			if (!memoryAccessor.Data.All((byte b) => b == 0))
			{
				return memoryAccessor;
			}
			return null;
		}
	}
}
