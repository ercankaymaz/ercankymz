using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using SharpGLTF.Memory;
using SharpGLTF.Schema2;

namespace SharpGLTF.Geometry.VertexTypes;

[GeneratedCode("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
[DebuggerDisplay("{_GetDebuggerDisplay(),nq}")]
public struct VertexColor2Texture2 : IVertexMaterial, IVertexReflection, IEquatable<VertexColor2Texture2>
{
	public Vector4 Color0;

	public Vector4 Color1;

	public Vector2 TexCoord0;

	public Vector2 TexCoord1;

	public readonly int MaxColors => 2;

	public readonly int MaxTextCoords => 2;

	public static implicit operator VertexColor2Texture2((Vector4 Color0, Vector4 Color1, Vector2 Tex0, Vector2 Tex1) tuple)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		return new VertexColor2Texture2(tuple.Color0, tuple.Color1, tuple.Tex0, tuple.Tex1);
	}

	private readonly string _GetDebuggerDisplay()
	{
		return VertexUtils._GetDebuggerDisplay(this);
	}

	public VertexColor2Texture2(Vector4 color0, Vector4 color1, Vector2 texcoord0, Vector2 texcoord1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		Color0 = color0;
		Color1 = color1;
		TexCoord0 = texcoord0;
		TexCoord1 = texcoord1;
	}

	public VertexColor2Texture2(IVertexMaterial src)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(src, "src");
		Color0 = ((0 < src.MaxColors) ? src.GetColor(0) : Vector4.One);
		Color1 = ((1 < src.MaxColors) ? src.GetColor(1) : Vector4.One);
		TexCoord0 = ((0 < src.MaxTextCoords) ? src.GetTexCoord(0) : Vector2.Zero);
		TexCoord1 = ((1 < src.MaxTextCoords) ? src.GetTexCoord(1) : Vector2.Zero);
	}

	IEnumerable<KeyValuePair<string, AttributeFormat>> IVertexReflection.GetEncodingAttributes()
	{
		yield return new KeyValuePair<string, AttributeFormat>("COLOR_0", new AttributeFormat(DimensionType.VEC4, EncodingType.UNSIGNED_BYTE, nrm: true));
		yield return new KeyValuePair<string, AttributeFormat>("COLOR_1", new AttributeFormat(DimensionType.VEC4, EncodingType.UNSIGNED_BYTE, nrm: true));
		yield return new KeyValuePair<string, AttributeFormat>("TEXCOORD_0", new AttributeFormat(DimensionType.VEC2));
		yield return new KeyValuePair<string, AttributeFormat>("TEXCOORD_1", new AttributeFormat(DimensionType.VEC2));
	}

	public override readonly int GetHashCode()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		return ((object)Color0/*cast due to constrained. prefix*/).GetHashCode() + ((object)Color1/*cast due to constrained. prefix*/).GetHashCode() + ((object)TexCoord0/*cast due to constrained. prefix*/).GetHashCode() + ((object)TexCoord1/*cast due to constrained. prefix*/).GetHashCode();
	}

	public override readonly bool Equals(object obj)
	{
		if (!(obj is VertexColor2Texture2 other))
		{
			return false;
		}
		return Equals(other);
	}

	public readonly bool Equals(VertexColor2Texture2 other)
	{
		return AreEqual(this, in other);
	}

	public static bool operator ==(in VertexColor2Texture2 a, in VertexColor2Texture2 b)
	{
		return AreEqual(in a, in b);
	}

	public static bool operator !=(in VertexColor2Texture2 a, in VertexColor2Texture2 b)
	{
		return !AreEqual(in a, in b);
	}

	public static bool AreEqual(in VertexColor2Texture2 a, in VertexColor2Texture2 b)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		if (a.Color0 != b.Color0)
		{
			return false;
		}
		if (a.Color1 != b.Color1)
		{
			return false;
		}
		if (a.TexCoord0 != b.TexCoord0)
		{
			return false;
		}
		if (a.TexCoord1 != b.TexCoord1)
		{
			return false;
		}
		return true;
	}

	public readonly VertexMaterialDelta Subtract(IVertexMaterial baseValue)
	{
		return new VertexMaterialDelta((VertexColor2Texture2)(object)baseValue, this);
	}

	public void Add(in VertexMaterialDelta delta)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		Color0 += delta.Color0Delta;
		Color1 += delta.Color1Delta;
		TexCoord0 += delta.TexCoord0Delta;
		TexCoord1 += delta.TexCoord1Delta;
	}

	void IVertexMaterial.SetColor(int index, Vector4 color)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		if (index == 0)
		{
			Color0 = color;
		}
		if (index == 1)
		{
			Color1 = color;
		}
	}

	void IVertexMaterial.SetTexCoord(int index, Vector2 coord)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		if (index == 0)
		{
			TexCoord0 = coord;
		}
		if (index == 1)
		{
			TexCoord1 = coord;
		}
	}

	public readonly Vector4 GetColor(int index)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		return (Vector4)(index switch
		{
			0 => Color0, 
			1 => Color1, 
			_ => throw new ArgumentOutOfRangeException("index"), 
		});
	}

	public readonly Vector2 GetTexCoord(int index)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		return (Vector2)(index switch
		{
			0 => TexCoord0, 
			1 => TexCoord1, 
			_ => throw new ArgumentOutOfRangeException("index"), 
		});
	}

	void IVertexMaterial.Add(in VertexMaterialDelta delta)
	{
		Add(in delta);
	}
}
