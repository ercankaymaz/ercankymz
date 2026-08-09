using System;
using System.Collections.Generic;
using System.Linq;
using SharpGLTF.Schema2;

namespace SharpGLTF.Geometry;

internal class PackedEncoding
{
	public EncodingType? ColorEncoding;

	public EncodingType? JointsEncoding;

	public EncodingType? WeightsEncoding;

	public void AdjustJointEncoding<TVertex>(IReadOnlyList<TVertex> vertices) where TVertex : IVertexBuilder
	{
		if (!JointsEncoding.HasValue)
		{
			IEnumerable<int> source = vertices.Select((TVertex item) => item.GetSkinning().GetBindings().MaxIndex);
			int num = source.Aggregate(0, (int a, int b) => Math.Max(a, b));
			JointsEncoding = ((num < 256) ? EncodingType.UNSIGNED_BYTE : EncodingType.UNSIGNED_SHORT);
		}
	}
}
