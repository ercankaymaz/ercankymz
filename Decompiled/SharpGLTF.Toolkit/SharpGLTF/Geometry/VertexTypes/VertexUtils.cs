using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using SharpGLTF.Memory;
using SharpGLTF.Schema2;
using SharpGLTF.Transforms;

namespace SharpGLTF.Geometry.VertexTypes;

internal static class VertexUtils
{
	private static readonly char[] _SubscriptNumbers = new char[10] { '₀', '₁', '₂', '₃', '₄', '₅', '₆', '₇', '₈', '₉' };

	public static MemoryAccessor CreateVertexMemoryAccessor<TVertex>(this IReadOnlyList<TVertex> vertices, string attributeName, PackedEncoding vertexEncoding) where TVertex : IVertexBuilder
	{
		if (vertices == null || vertices.Count == 0)
		{
			return null;
		}
		vertexEncoding.AdjustJointEncoding(vertices);
		MemoryAccessInfo[] vertexAttributes = vertices[0].GetVertexAttributes(vertices.Count, vertexEncoding);
		MemoryAccessInfo info = vertexAttributes.FirstOrDefault((MemoryAccessInfo item) => item.Name == attributeName);
		if (info.Name == null)
		{
			return null;
		}
		info.ByteOffset = 0;
		info.ByteStride = 0;
		ArraySegment<byte> data = new ArraySegment<byte>(new byte[info.StepByteLength * vertices.Count]);
		MemoryAccessor memoryAccessor = new MemoryAccessor(data, info);
		memoryAccessor.FillAccessor(vertices);
		return memoryAccessor;
	}

	public static MemoryAccessor[] CreateVertexMemoryAccessors<TVertex>(this IReadOnlyList<TVertex> vertices, PackedEncoding vertexEncoding) where TVertex : IVertexBuilder
	{
		if (vertices == null || vertices.Count == 0)
		{
			return null;
		}
		vertexEncoding.AdjustJointEncoding(vertices);
		MemoryAccessInfo[] vertexAttributes = vertices[0].GetVertexAttributes(vertices.Count, vertexEncoding);
		if (vertexAttributes == null || vertexAttributes.Length == 0)
		{
			throw new InvalidOperationException("unable to retrieve attribute information from the vertex");
		}
		int byteStride = vertexAttributes[0].ByteStride;
		ArraySegment<byte> vbuffer = new ArraySegment<byte>(new byte[byteStride * vertices.Count]);
		MemoryAccessor[] array = (from item in MemoryAccessInfo.Slice(vertexAttributes, 0, vertices.Count)
			select new MemoryAccessor(vbuffer, item)).ToArray();
		MemoryAccessor[] array2 = array;
		foreach (MemoryAccessor dstAccessor in array2)
		{
			dstAccessor.FillAccessor(vertices);
		}
		MemoryAccessor.SanitizeVertexAttributes(array);
		return array;
	}

	private static void FillAccessor<TVertex>(this MemoryAccessor dstAccessor, IReadOnlyList<TVertex> srcVertices) where TVertex : IVertexBuilder
	{
		Converter<IVertexBuilder, object> func = _GetVertexBuilderAttributeFunc(dstAccessor.Attribute.Name);
		if (dstAccessor.Attribute.Dimensions == DimensionType.SCALAR)
		{
			dstAccessor.AsScalarArray().Fill(srcVertices._GetColumn<TVertex, float>(func));
		}
		if (dstAccessor.Attribute.Dimensions == DimensionType.VEC2)
		{
			dstAccessor.AsVector2Array().Fill(srcVertices._GetColumn<TVertex, Vector2>(func));
		}
		if (dstAccessor.Attribute.Dimensions == DimensionType.VEC3)
		{
			dstAccessor.AsVector3Array().Fill(srcVertices._GetColumn<TVertex, Vector3>(func));
		}
		if (dstAccessor.Attribute.Dimensions == DimensionType.VEC4)
		{
			dstAccessor.AsVector4Array().Fill(srcVertices._GetColumn<TVertex, Vector4>(func));
		}
	}

	public static MemoryAccessor CreateIndexMemoryAccessor(this IReadOnlyList<int> indices, EncodingType indexEncoding)
	{
		if (indices == null || indices.Count == 0)
		{
			return null;
		}
		MemoryAccessInfo memoryAccessInfo = new MemoryAccessInfo("INDEX", 0, indices.Count, 0, DimensionType.SCALAR, indexEncoding);
		byte[] array = new byte[indexEncoding.ByteLength() * indices.Count];
		ArraySegment<byte> data = new ArraySegment<byte>(array);
		MemoryAccessor memoryAccessor = new MemoryAccessor(data, memoryAccessInfo.Slice(0, indices.Count));
		memoryAccessor.AsIntegerArray().Fill(indices);
		return memoryAccessor;
	}

	public static MemoryAccessInfo[] GetVertexAttributes(this IVertexBuilder firstVertex, int vertexCount, PackedEncoding vertexEncoding)
	{
		IEnumerable<KeyValuePair<string, AttributeFormat>> encodingAttributes = firstVertex.GetGeometry().GetEncodingAttributes();
		IEnumerable<KeyValuePair<string, AttributeFormat>> encodingAttributes2 = firstVertex.GetMaterial().GetEncodingAttributes();
		IEnumerable<KeyValuePair<string, AttributeFormat>> encodingAttributes3 = firstVertex.GetSkinning().GetEncodingAttributes();
		List<MemoryAccessInfo> list = new List<MemoryAccessInfo>();
		foreach (KeyValuePair<string, AttributeFormat> item2 in encodingAttributes)
		{
			list.Add(new MemoryAccessInfo(item2.Key, 0, 0, 0, item2.Value));
		}
		foreach (KeyValuePair<string, AttributeFormat> item3 in encodingAttributes2)
		{
			MemoryAccessInfo item = new MemoryAccessInfo(item3.Key, 0, 0, 0, item3.Value);
			if (item.Name.StartsWith("COLOR_", StringComparison.OrdinalIgnoreCase) && vertexEncoding.ColorEncoding.HasValue)
			{
				EncodingType value = vertexEncoding.ColorEncoding.Value;
				AttributeFormat newFormat = new AttributeFormat(item.Dimensions, value, value != EncodingType.FLOAT);
				item = item.WithFormat(newFormat);
			}
			list.Add(item);
		}
		foreach (KeyValuePair<string, AttributeFormat> item4 in encodingAttributes3)
		{
			MemoryAccessInfo memoryAccessInfo = new MemoryAccessInfo(item4.Key, 0, 0, 0, item4.Value);
			AttributeFormat newFormat2 = memoryAccessInfo.Format;
			if (memoryAccessInfo.Name.StartsWith("JOINTS_", StringComparison.OrdinalIgnoreCase))
			{
				EncodingType value2 = vertexEncoding.JointsEncoding.Value;
				SharpGLTF.Guard.IsFalse(newFormat2.Normalized, "firstVertex", "indices should not be normalized");
				newFormat2 = (dim: newFormat2.Dimensions, enc: value2, nrm: false);
			}
			if (memoryAccessInfo.Name.StartsWith("WEIGHTS_", StringComparison.OrdinalIgnoreCase))
			{
				EncodingType value3 = vertexEncoding.WeightsEncoding.Value;
				newFormat2 = (dim: newFormat2.Dimensions, enc: value3, nrm: value3 != EncodingType.FLOAT);
			}
			memoryAccessInfo = memoryAccessInfo.WithFormat(newFormat2);
			list.Add(memoryAccessInfo);
		}
		MemoryAccessInfo[] array = list.ToArray();
		MemoryAccessInfo.SetInterleavedInfo(array, 0, vertexCount);
		return array;
	}

	private static Converter<IVertexBuilder, object> _GetVertexBuilderAttributeFunc(string attributeName)
	{
		if (attributeName == "POSITION")
		{
			return (IVertexBuilder v) => v.GetGeometry().GetPosition();
		}
		if (attributeName == "NORMAL")
		{
			return (IVertexBuilder v) => v.GetGeometry().TryGetNormal(out var normal) ? normal : Vector3.Zero;
		}
		if (attributeName == "TANGENT")
		{
			return (IVertexBuilder v) => v.GetGeometry().TryGetTangent(out var tangent) ? tangent : Vector4.Zero;
		}
		if (attributeName == "POSITIONDELTA")
		{
			return (IVertexBuilder v) => v.GetGeometry().GetPosition();
		}
		if (attributeName == "NORMALDELTA")
		{
			return (IVertexBuilder v) => v.GetGeometry().TryGetNormal(out var normal) ? normal : Vector3.Zero;
		}
		if (attributeName == "TANGENTDELTA")
		{
			return (IVertexBuilder v) => (object)(Vector3)(v.GetGeometry().TryGetTangent(out var tangent) ? new Vector3(tangent.X, tangent.Y, tangent.Z) : Vector3.Zero);
		}
		if (attributeName == "COLOR_0")
		{
			return delegate(IVertexBuilder v)
			{
				//IL_0019: Unknown result type (might be due to invalid IL or missing references)
				//IL_0012: Unknown result type (might be due to invalid IL or missing references)
				IVertexMaterial material = v.GetMaterial();
				return (material.MaxColors <= 0) ? Vector4.One : material.GetColor(0);
			};
		}
		if (attributeName == "COLOR_1")
		{
			return delegate(IVertexBuilder v)
			{
				//IL_0019: Unknown result type (might be due to invalid IL or missing references)
				//IL_0012: Unknown result type (might be due to invalid IL or missing references)
				IVertexMaterial material = v.GetMaterial();
				return (material.MaxColors <= 1) ? Vector4.One : material.GetColor(1);
			};
		}
		if (attributeName == "COLOR_2")
		{
			return delegate(IVertexBuilder v)
			{
				//IL_0019: Unknown result type (might be due to invalid IL or missing references)
				//IL_0012: Unknown result type (might be due to invalid IL or missing references)
				IVertexMaterial material = v.GetMaterial();
				return (material.MaxColors <= 2) ? Vector4.One : material.GetColor(2);
			};
		}
		if (attributeName == "COLOR_3")
		{
			return delegate(IVertexBuilder v)
			{
				//IL_0019: Unknown result type (might be due to invalid IL or missing references)
				//IL_0012: Unknown result type (might be due to invalid IL or missing references)
				IVertexMaterial material = v.GetMaterial();
				return (material.MaxColors <= 3) ? Vector4.One : material.GetColor(3);
			};
		}
		if (attributeName == "COLOR_0DELTA")
		{
			return delegate(IVertexBuilder v)
			{
				//IL_0019: Unknown result type (might be due to invalid IL or missing references)
				//IL_0012: Unknown result type (might be due to invalid IL or missing references)
				IVertexMaterial material = v.GetMaterial();
				return (material.MaxColors <= 0) ? Vector4.Zero : material.GetColor(0);
			};
		}
		if (attributeName == "COLOR_1DELTA")
		{
			return delegate(IVertexBuilder v)
			{
				//IL_0019: Unknown result type (might be due to invalid IL or missing references)
				//IL_0012: Unknown result type (might be due to invalid IL or missing references)
				IVertexMaterial material = v.GetMaterial();
				return (material.MaxColors <= 1) ? Vector4.Zero : material.GetColor(1);
			};
		}
		if (attributeName == "COLOR_2DELTA")
		{
			return delegate(IVertexBuilder v)
			{
				//IL_0019: Unknown result type (might be due to invalid IL or missing references)
				//IL_0012: Unknown result type (might be due to invalid IL or missing references)
				IVertexMaterial material = v.GetMaterial();
				return (material.MaxColors <= 2) ? Vector4.Zero : material.GetColor(2);
			};
		}
		if (attributeName == "COLOR_3DELTA")
		{
			return delegate(IVertexBuilder v)
			{
				//IL_0019: Unknown result type (might be due to invalid IL or missing references)
				//IL_0012: Unknown result type (might be due to invalid IL or missing references)
				IVertexMaterial material = v.GetMaterial();
				return (material.MaxColors <= 3) ? Vector4.Zero : material.GetColor(3);
			};
		}
		if (attributeName == "TEXCOORD_0")
		{
			return delegate(IVertexBuilder v)
			{
				//IL_0019: Unknown result type (might be due to invalid IL or missing references)
				//IL_0012: Unknown result type (might be due to invalid IL or missing references)
				IVertexMaterial material = v.GetMaterial();
				return (material.MaxTextCoords <= 0) ? Vector2.Zero : material.GetTexCoord(0);
			};
		}
		if (attributeName == "TEXCOORD_1")
		{
			return delegate(IVertexBuilder v)
			{
				//IL_0019: Unknown result type (might be due to invalid IL or missing references)
				//IL_0012: Unknown result type (might be due to invalid IL or missing references)
				IVertexMaterial material = v.GetMaterial();
				return (material.MaxTextCoords <= 1) ? Vector2.Zero : material.GetTexCoord(1);
			};
		}
		if (attributeName == "TEXCOORD_2")
		{
			return delegate(IVertexBuilder v)
			{
				//IL_0019: Unknown result type (might be due to invalid IL or missing references)
				//IL_0012: Unknown result type (might be due to invalid IL or missing references)
				IVertexMaterial material = v.GetMaterial();
				return (material.MaxTextCoords <= 2) ? Vector2.Zero : material.GetTexCoord(2);
			};
		}
		if (attributeName == "TEXCOORD_3")
		{
			return delegate(IVertexBuilder v)
			{
				//IL_0019: Unknown result type (might be due to invalid IL or missing references)
				//IL_0012: Unknown result type (might be due to invalid IL or missing references)
				IVertexMaterial material = v.GetMaterial();
				return (material.MaxTextCoords <= 3) ? Vector2.Zero : material.GetTexCoord(3);
			};
		}
		if (attributeName == "TEXCOORD_0DELTA")
		{
			return delegate(IVertexBuilder v)
			{
				//IL_0019: Unknown result type (might be due to invalid IL or missing references)
				//IL_0012: Unknown result type (might be due to invalid IL or missing references)
				IVertexMaterial material = v.GetMaterial();
				return (material.MaxTextCoords <= 0) ? Vector2.Zero : material.GetTexCoord(0);
			};
		}
		if (attributeName == "TEXCOORD_1DELTA")
		{
			return delegate(IVertexBuilder v)
			{
				//IL_0019: Unknown result type (might be due to invalid IL or missing references)
				//IL_0012: Unknown result type (might be due to invalid IL or missing references)
				IVertexMaterial material = v.GetMaterial();
				return (material.MaxTextCoords <= 1) ? Vector2.Zero : material.GetTexCoord(1);
			};
		}
		if (attributeName == "TEXCOORD_2DELTA")
		{
			return delegate(IVertexBuilder v)
			{
				//IL_0019: Unknown result type (might be due to invalid IL or missing references)
				//IL_0012: Unknown result type (might be due to invalid IL or missing references)
				IVertexMaterial material = v.GetMaterial();
				return (material.MaxTextCoords <= 2) ? Vector2.Zero : material.GetTexCoord(2);
			};
		}
		if (attributeName == "TEXCOORD_3DELTA")
		{
			return delegate(IVertexBuilder v)
			{
				//IL_0019: Unknown result type (might be due to invalid IL or missing references)
				//IL_0012: Unknown result type (might be due to invalid IL or missing references)
				IVertexMaterial material = v.GetMaterial();
				return (material.MaxTextCoords <= 3) ? Vector2.Zero : material.GetTexCoord(3);
			};
		}
		if (attributeName == "JOINTS_0")
		{
			return (IVertexBuilder v) => v.GetSkinning().JointsLow;
		}
		if (attributeName == "JOINTS_1")
		{
			return (IVertexBuilder v) => v.GetSkinning().JointsHigh;
		}
		if (attributeName == "WEIGHTS_0")
		{
			return (IVertexBuilder v) => v.GetSkinning().WeightsLow;
		}
		if (attributeName == "WEIGHTS_1")
		{
			return (IVertexBuilder v) => v.GetSkinning().WeightsHigh;
		}
		return (IVertexBuilder v) => _GetVertexBuilderCustomAttributeFunc(v.GetMaterial(), attributeName);
	}

	private static object _GetVertexBuilderCustomAttributeFunc(IVertexMaterial vertex, string attributeName)
	{
		if (!(vertex is IVertexCustom vertexCustom))
		{
			return null;
		}
		if (!vertexCustom.TryGetCustomAttribute(attributeName, out var value))
		{
			return null;
		}
		return value;
	}

	private static TColumn[] _GetColumn<TVertex, TColumn>(this IReadOnlyList<TVertex> vertices, Converter<IVertexBuilder, object> func) where TVertex : IVertexBuilder
	{
		TColumn[] array = new TColumn[vertices.Count];
		for (int i = 0; i < array.Length; i++)
		{
			object obj = func(vertices[i]);
			array[i] = ((obj == null) ? default(TColumn) : ((TColumn)obj));
		}
		return array;
	}

	public static (Type BuilderType, Func<IVertexBuilder> BuilderFactory) GetVertexBuilderType(params string[] vertexAttributes)
	{
		bool hasNormals = Enumerable.Contains(vertexAttributes, "NORMAL");
		bool hasTangents = Enumerable.Contains(vertexAttributes, "TANGENT");
		int num = 0;
		if (Enumerable.Contains(vertexAttributes, "COLOR_0"))
		{
			num = Math.Max(num, 1);
		}
		if (Enumerable.Contains(vertexAttributes, "COLOR_1"))
		{
			num = Math.Max(num, 2);
		}
		if (Enumerable.Contains(vertexAttributes, "COLOR_2"))
		{
			num = Math.Max(num, 3);
		}
		if (Enumerable.Contains(vertexAttributes, "COLOR_3"))
		{
			num = Math.Max(num, 4);
		}
		if (Enumerable.Contains(vertexAttributes, "COLOR_4"))
		{
			num = Math.Max(num, 5);
		}
		if (Enumerable.Contains(vertexAttributes, "COLOR_5"))
		{
			num = Math.Max(num, 6);
		}
		if (Enumerable.Contains(vertexAttributes, "COLOR_6"))
		{
			num = Math.Max(num, 7);
		}
		if (Enumerable.Contains(vertexAttributes, "COLOR_7"))
		{
			num = Math.Max(num, 8);
		}
		int num2 = 0;
		if (Enumerable.Contains(vertexAttributes, "TEXCOORD_0"))
		{
			num2 = Math.Max(num2, 1);
		}
		if (Enumerable.Contains(vertexAttributes, "TEXCOORD_1"))
		{
			num2 = Math.Max(num2, 2);
		}
		if (Enumerable.Contains(vertexAttributes, "TEXCOORD_2"))
		{
			num2 = Math.Max(num2, 3);
		}
		if (Enumerable.Contains(vertexAttributes, "TEXCOORD_3"))
		{
			num2 = Math.Max(num2, 4);
		}
		if (Enumerable.Contains(vertexAttributes, "TEXCOORD_4"))
		{
			num2 = Math.Max(num2, 5);
		}
		if (Enumerable.Contains(vertexAttributes, "TEXCOORD_5"))
		{
			num2 = Math.Max(num2, 6);
		}
		if (Enumerable.Contains(vertexAttributes, "TEXCOORD_6"))
		{
			num2 = Math.Max(num2, 7);
		}
		if (Enumerable.Contains(vertexAttributes, "TEXCOORD_7"))
		{
			num2 = Math.Max(num2, 8);
		}
		int num3 = ((Enumerable.Contains(vertexAttributes, "JOINTS_0") && Enumerable.Contains(vertexAttributes, "WEIGHTS_0")) ? 4 : 0);
		num3 = ((Enumerable.Contains(vertexAttributes, "JOINTS_1") && Enumerable.Contains(vertexAttributes, "WEIGHTS_1")) ? 8 : num3);
		return GetVertexBuilderType(hasNormals, hasTangents, num, num2, num3);
	}

	public static TvP ConvertToGeometry<TvP>(this IVertexGeometry src) where TvP : struct, IVertexGeometry
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if (src is TvP)
		{
			return (TvP)src;
		}
		TvP result = default(TvP);
		result.SetPosition(src.GetPosition());
		if (src.TryGetNormal(out var normal))
		{
			result.SetNormal(in normal);
		}
		if (src.TryGetTangent(out var tangent))
		{
			result.SetTangent(in tangent);
		}
		return result;
	}

	public static TvM ConvertToMaterial<TvM>(this IVertexMaterial src) where TvM : struct, IVertexMaterial
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		if (src is TvM)
		{
			return (TvM)src;
		}
		TvM val = default(TvM);
		int i;
		for (i = 0; i < Math.Min(src.MaxColors, val.MaxColors); i++)
		{
			val.SetColor(i, src.GetColor(i));
		}
		for (; i < val.MaxColors; i++)
		{
			val.SetColor(i, Vector4.One);
		}
		for (i = 0; i < Math.Min(src.MaxTextCoords, val.MaxTextCoords); i++)
		{
			val.SetTexCoord(i, src.GetTexCoord(i));
		}
		for (; i < val.MaxTextCoords; i++)
		{
			val.SetTexCoord(i, Vector2.Zero);
		}
		if (src is IVertexCustom vertexCustom && (object)val is IVertexCustom vertexCustom2)
		{
			foreach (string customAttribute in vertexCustom2.CustomAttributes)
			{
				if (vertexCustom.TryGetCustomAttribute(customAttribute, out var value))
				{
					vertexCustom2.SetCustomAttribute(customAttribute, value);
				}
			}
			return (TvM)vertexCustom2;
		}
		return val;
	}

	public static TvS ConvertToSkinning<TvS>(this IVertexSkinning src) where TvS : struct, IVertexSkinning
	{
		if (src is TvS)
		{
			return (TvS)src;
		}
		SparseWeight8 bindings = ((src.MaxBindings > 0) ? src.GetBindings() : default(SparseWeight8));
		TvS result = default(TvS);
		if (result.MaxBindings > 0)
		{
			result.SetBindings(in bindings);
		}
		return result;
	}

	public static (Type BuilderType, Func<IVertexBuilder> BuilderFactory) GetVertexBuilderType(bool hasNormals, bool hasTangents, int numCols, int numUV, int numJoints)
	{
		switch (numJoints)
		{
		case 0:
			switch (numCols)
			{
			case 0:
				switch (numUV)
				{
				case 0:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexEmpty, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexEmpty, VertexEmpty>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexEmpty, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexEmpty, VertexEmpty>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexEmpty, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexEmpty, VertexEmpty>));
				case 1:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexTexture1, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexTexture1, VertexEmpty>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexTexture1, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexTexture1, VertexEmpty>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexTexture1, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexTexture1, VertexEmpty>));
				case 2:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexTexture2, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexTexture2, VertexEmpty>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexTexture2, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexTexture2, VertexEmpty>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexTexture2, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexTexture2, VertexEmpty>));
				case 3:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexTexture3, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexTexture3, VertexEmpty>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexTexture3, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexTexture3, VertexEmpty>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexTexture3, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexTexture3, VertexEmpty>));
				case 4:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexTexture4, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexTexture4, VertexEmpty>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexTexture4, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexTexture4, VertexEmpty>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexTexture4, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexTexture4, VertexEmpty>));
				default:
					throw new ArgumentOutOfRangeException("numUV");
				}
			case 1:
				switch (numUV)
				{
				case 0:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexColor1, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexColor1, VertexEmpty>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexColor1, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexColor1, VertexEmpty>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexColor1, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexColor1, VertexEmpty>));
				case 1:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexColor1Texture1, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexColor1Texture1, VertexEmpty>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexColor1Texture1, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexColor1Texture1, VertexEmpty>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexColor1Texture1, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexColor1Texture1, VertexEmpty>));
				case 2:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexColor1Texture2, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexColor1Texture2, VertexEmpty>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexColor1Texture2, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexColor1Texture2, VertexEmpty>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexColor1Texture2, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexColor1Texture2, VertexEmpty>));
				case 3:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexColor1Texture3, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexColor1Texture3, VertexEmpty>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexColor1Texture3, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexColor1Texture3, VertexEmpty>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexColor1Texture3, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexColor1Texture3, VertexEmpty>));
				case 4:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexColor1Texture4, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexColor1Texture4, VertexEmpty>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexColor1Texture4, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexColor1Texture4, VertexEmpty>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexColor1Texture4, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexColor1Texture4, VertexEmpty>));
				default:
					throw new ArgumentOutOfRangeException("numUV");
				}
			case 2:
				switch (numUV)
				{
				case 0:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexColor2, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexColor2, VertexEmpty>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexColor2, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexColor2, VertexEmpty>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexColor2, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexColor2, VertexEmpty>));
				case 1:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexColor2Texture1, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexColor2Texture1, VertexEmpty>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexColor2Texture1, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexColor2Texture1, VertexEmpty>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexColor2Texture1, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexColor2Texture1, VertexEmpty>));
				case 2:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexColor2Texture2, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexColor2Texture2, VertexEmpty>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexColor2Texture2, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexColor2Texture2, VertexEmpty>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexColor2Texture2, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexColor2Texture2, VertexEmpty>));
				case 3:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexColor2Texture3, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexColor2Texture3, VertexEmpty>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexColor2Texture3, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexColor2Texture3, VertexEmpty>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexColor2Texture3, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexColor2Texture3, VertexEmpty>));
				case 4:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexColor2Texture4, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexColor2Texture4, VertexEmpty>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexColor2Texture4, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexColor2Texture4, VertexEmpty>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexColor2Texture4, VertexEmpty>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexColor2Texture4, VertexEmpty>));
				default:
					throw new ArgumentOutOfRangeException("numUV");
				}
			default:
				throw new ArgumentOutOfRangeException("numCols");
			}
		case 4:
			switch (numCols)
			{
			case 0:
				switch (numUV)
				{
				case 0:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexEmpty, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexEmpty, VertexJoints4>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexEmpty, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexEmpty, VertexJoints4>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexEmpty, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexEmpty, VertexJoints4>));
				case 1:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexTexture1, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexTexture1, VertexJoints4>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexTexture1, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexTexture1, VertexJoints4>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexTexture1, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexTexture1, VertexJoints4>));
				case 2:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexTexture2, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexTexture2, VertexJoints4>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexTexture2, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexTexture2, VertexJoints4>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexTexture2, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexTexture2, VertexJoints4>));
				case 3:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexTexture3, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexTexture3, VertexJoints4>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexTexture3, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexTexture3, VertexJoints4>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexTexture3, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexTexture3, VertexJoints4>));
				case 4:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexTexture4, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexTexture4, VertexJoints4>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexTexture4, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexTexture4, VertexJoints4>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexTexture4, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexTexture4, VertexJoints4>));
				default:
					throw new ArgumentOutOfRangeException("numUV");
				}
			case 1:
				switch (numUV)
				{
				case 0:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexColor1, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexColor1, VertexJoints4>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexColor1, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexColor1, VertexJoints4>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexColor1, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexColor1, VertexJoints4>));
				case 1:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexColor1Texture1, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexColor1Texture1, VertexJoints4>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexColor1Texture1, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexColor1Texture1, VertexJoints4>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexColor1Texture1, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexColor1Texture1, VertexJoints4>));
				case 2:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexColor1Texture2, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexColor1Texture2, VertexJoints4>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexColor1Texture2, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexColor1Texture2, VertexJoints4>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexColor1Texture2, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexColor1Texture2, VertexJoints4>));
				case 3:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexColor1Texture3, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexColor1Texture3, VertexJoints4>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexColor1Texture3, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexColor1Texture3, VertexJoints4>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexColor1Texture3, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexColor1Texture3, VertexJoints4>));
				case 4:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexColor1Texture4, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexColor1Texture4, VertexJoints4>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexColor1Texture4, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexColor1Texture4, VertexJoints4>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexColor1Texture4, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexColor1Texture4, VertexJoints4>));
				default:
					throw new ArgumentOutOfRangeException("numUV");
				}
			case 2:
				switch (numUV)
				{
				case 0:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexColor2, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexColor2, VertexJoints4>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexColor2, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexColor2, VertexJoints4>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexColor2, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexColor2, VertexJoints4>));
				case 1:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexColor2Texture1, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexColor2Texture1, VertexJoints4>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexColor2Texture1, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexColor2Texture1, VertexJoints4>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexColor2Texture1, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexColor2Texture1, VertexJoints4>));
				case 2:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexColor2Texture2, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexColor2Texture2, VertexJoints4>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexColor2Texture2, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexColor2Texture2, VertexJoints4>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexColor2Texture2, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexColor2Texture2, VertexJoints4>));
				case 3:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexColor2Texture3, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexColor2Texture3, VertexJoints4>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexColor2Texture3, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexColor2Texture3, VertexJoints4>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexColor2Texture3, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexColor2Texture3, VertexJoints4>));
				case 4:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexColor2Texture4, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexColor2Texture4, VertexJoints4>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexColor2Texture4, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexColor2Texture4, VertexJoints4>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexColor2Texture4, VertexJoints4>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexColor2Texture4, VertexJoints4>));
				default:
					throw new ArgumentOutOfRangeException("numUV");
				}
			default:
				throw new ArgumentOutOfRangeException("numCols");
			}
		case 8:
			switch (numCols)
			{
			case 0:
				switch (numUV)
				{
				case 0:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexEmpty, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexEmpty, VertexJoints8>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexEmpty, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexEmpty, VertexJoints8>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexEmpty, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexEmpty, VertexJoints8>));
				case 1:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexTexture1, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexTexture1, VertexJoints8>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexTexture1, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexTexture1, VertexJoints8>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexTexture1, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexTexture1, VertexJoints8>));
				case 2:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexTexture2, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexTexture2, VertexJoints8>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexTexture2, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexTexture2, VertexJoints8>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexTexture2, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexTexture2, VertexJoints8>));
				case 3:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexTexture3, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexTexture3, VertexJoints8>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexTexture3, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexTexture3, VertexJoints8>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexTexture3, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexTexture3, VertexJoints8>));
				case 4:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexTexture4, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexTexture4, VertexJoints8>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexTexture4, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexTexture4, VertexJoints8>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexTexture4, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexTexture4, VertexJoints8>));
				default:
					throw new ArgumentOutOfRangeException("numUV");
				}
			case 1:
				switch (numUV)
				{
				case 0:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexColor1, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexColor1, VertexJoints8>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexColor1, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexColor1, VertexJoints8>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexColor1, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexColor1, VertexJoints8>));
				case 1:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexColor1Texture1, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexColor1Texture1, VertexJoints8>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexColor1Texture1, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexColor1Texture1, VertexJoints8>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexColor1Texture1, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexColor1Texture1, VertexJoints8>));
				case 2:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexColor1Texture2, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexColor1Texture2, VertexJoints8>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexColor1Texture2, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexColor1Texture2, VertexJoints8>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexColor1Texture2, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexColor1Texture2, VertexJoints8>));
				case 3:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexColor1Texture3, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexColor1Texture3, VertexJoints8>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexColor1Texture3, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexColor1Texture3, VertexJoints8>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexColor1Texture3, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexColor1Texture3, VertexJoints8>));
				case 4:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexColor1Texture4, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexColor1Texture4, VertexJoints8>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexColor1Texture4, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexColor1Texture4, VertexJoints8>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexColor1Texture4, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexColor1Texture4, VertexJoints8>));
				default:
					throw new ArgumentOutOfRangeException("numUV");
				}
			case 2:
				switch (numUV)
				{
				case 0:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexColor2, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexColor2, VertexJoints8>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexColor2, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexColor2, VertexJoints8>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexColor2, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexColor2, VertexJoints8>));
				case 1:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexColor2Texture1, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexColor2Texture1, VertexJoints8>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexColor2Texture1, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexColor2Texture1, VertexJoints8>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexColor2Texture1, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexColor2Texture1, VertexJoints8>));
				case 2:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexColor2Texture2, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexColor2Texture2, VertexJoints8>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexColor2Texture2, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexColor2Texture2, VertexJoints8>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexColor2Texture2, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexColor2Texture2, VertexJoints8>));
				case 3:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexColor2Texture3, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexColor2Texture3, VertexJoints8>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexColor2Texture3, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexColor2Texture3, VertexJoints8>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexColor2Texture3, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexColor2Texture3, VertexJoints8>));
				case 4:
					if (!hasNormals)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPosition, VertexColor2Texture4, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPosition, VertexColor2Texture4, VertexJoints8>));
					}
					if (!hasTangents)
					{
						return (BuilderType: typeof(VertexBuilder<VertexPositionNormal, VertexColor2Texture4, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormal, VertexColor2Texture4, VertexJoints8>));
					}
					return (BuilderType: typeof(VertexBuilder<VertexPositionNormalTangent, VertexColor2Texture4, VertexJoints8>), BuilderFactory: () => default(VertexBuilder<VertexPositionNormalTangent, VertexColor2Texture4, VertexJoints8>));
				default:
					throw new ArgumentOutOfRangeException("numUV");
				}
			default:
				throw new ArgumentOutOfRangeException("numCols");
			}
		default:
			throw new ArgumentOutOfRangeException("numJoints");
		}
	}

	public static string _GetDebuggerDisplay(IVertexGeometry geo)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		string text = $"\ud835\udc0f:{geo.GetPosition()}";
		if (geo.TryGetNormal(out var normal))
		{
			text += $" \ud835\udeb4:{normal}";
		}
		if (geo.TryGetTangent(out var tangent))
		{
			text += $" \ud835\udebb:{tangent}";
		}
		return text;
	}

	public static string _GetDebuggerDisplay(IVertexMaterial mat)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		string text = string.Empty;
		for (int i = 0; i < mat.MaxColors; i++)
		{
			if (text.Length > 0)
			{
				text += " ";
			}
			text += $"\ud835\udc02{_SubscriptNumbers[i]}:{mat.GetColor(i)}";
		}
		for (int j = 0; j < mat.MaxTextCoords; j++)
		{
			if (text.Length > 0)
			{
				text += " ";
			}
			text += $"\ud835\udc14\ud835\udc15{_SubscriptNumbers[j]}:{mat.GetTexCoord(j)}";
		}
		return text;
	}

	public static string _GetDebuggerDisplay(IVertexSkinning skin)
	{
		string text = string.Empty;
		for (int i = 0; i < skin.MaxBindings; i++)
		{
			var (num, num2) = skin.GetBinding(i);
			if (num2 != 0f)
			{
				if (text.Length != 0)
				{
					text += " ";
				}
				text += $"<\ud835\udc09:{num} \ud835\udc16:{num2}>";
			}
		}
		return text;
	}
}
