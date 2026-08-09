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
public struct VertexColor2Texture1 : IVertexMaterial, IVertexReflection, IEquatable<VertexColor2Texture1>
{
	public Vector4 Color0;

	public Vector4 Color1;

	public Vector2 TexCoord;

	public readonly int MaxColors => 2;

	public readonly int MaxTextCoords => 1;

	public static implicit operator VertexColor2Texture1((Vector4 Color0, Vector4 Color1, Vector2 Tex) tuple)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		return new VertexColor2Texture1(tuple.Color0, tuple.Color1, tuple.Tex);
	}

	private readonly string _GetDebuggerDisplay()
	{
		return VertexUtils._GetDebuggerDisplay(this);
	}

	public VertexColor2Texture1(Vector4 color0, Vector4 color1, Vector2 texcoord)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		Color0 = color0;
		Color1 = color1;
		TexCoord = texcoord;
	}

	public VertexColor2Texture1(IVertexMaterial src)
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
		SharpGLTF.Guard.NotNull(src, "src");
		Color0 = ((0 < src.MaxColors) ? src.GetColor(0) : Vector4.One);
		Color1 = ((1 < src.MaxColors) ? src.GetColor(1) : Vector4.One);
		TexCoord = ((0 < src.MaxTextCoords) ? src.GetTexCoord(0) : Vector2.Zero);
	}

	IEnumerable<KeyValuePair<string, AttributeFormat>> IVertexReflection.GetEncodingAttributes()
	{
		yield return new KeyValuePair<string, AttributeFormat>("COLOR_0", new AttributeFormat(DimensionType.VEC4, EncodingType.UNSIGNED_BYTE, nrm: true));
		yield return new KeyValuePair<string, AttributeFormat>("COLOR_1", new AttributeFormat(DimensionType.VEC4, EncodingType.UNSIGNED_BYTE, nrm: true));
		yield return new KeyValuePair<string, AttributeFormat>("TEXCOORD_0", new AttributeFormat(DimensionType.VEC2));
	}

	public override readonly int GetHashCode()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		return ((object)Color0/*cast due to constrained. prefix*/).GetHashCode() + ((object)Color1/*cast due to constrained. prefix*/).GetHashCode() + ((object)TexCoord/*cast due to constrained. prefix*/).GetHashCode();
	}

	public override readonly bool Equals(object obj)
	{
		if (!(obj is VertexColor2Texture1 other))
		{
			return false;
		}
		return Equals(other);
	}

	public readonly bool Equals(VertexColor2Texture1 other)
	{
		return AreEqual(this, in other);
	}

	public static bool operator ==(in VertexColor2Texture1 a, in VertexColor2Texture1 b)
	{
		return AreEqual(in a, in b);
	}

	public static bool operator !=(in VertexColor2Texture1 a, in VertexColor2Texture1 b)
	{
		return !AreEqual(in a, in b);
	}

	public static bool AreEqual(in VertexColor2Texture1 a, in VertexColor2Texture1 b)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		if (a.Color0 != b.Color0)
		{
			return false;
		}
		if (a.Color1 != b.Color1)
		{
			return false;
		}
		if (a.TexCoord != b.TexCoord)
		{
			return false;
		}
		return true;
	}

	public readonly VertexMaterialDelta Subtract(IVertexMaterial baseValue)
	{
		return new VertexMaterialDelta((VertexColor2Texture1)(object)baseValue, this);
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
		Color0 += delta.Color0Delta;
		Color1 += delta.Color1Delta;
		TexCoord += delta.TexCoord0Delta;
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
		if (index == 0)
		{
			TexCoord = coord;
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
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		if (index == 0)
		{
			return TexCoord;
		}
		throw new ArgumentOutOfRangeException("index");
	}

	void IVertexMaterial.Add(in VertexMaterialDelta delta)
	{
		Add(in delta);
	}
}
