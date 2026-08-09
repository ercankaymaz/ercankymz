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
public struct VertexColor2Texture4 : IVertexMaterial, IVertexReflection, IEquatable<VertexColor2Texture4>
{
	public Vector4 Color0;

	public Vector4 Color1;

	public Vector2 TexCoord0;

	public Vector2 TexCoord1;

	public Vector2 TexCoord2;

	public Vector2 TexCoord3;

	public readonly int MaxColors => 2;

	public readonly int MaxTextCoords => 4;

	private readonly string _GetDebuggerDisplay()
	{
		return VertexUtils._GetDebuggerDisplay(this);
	}

	public VertexColor2Texture4(Vector4 color0, Vector4 color1, Vector2 texcoord0, Vector2 texcoord1, Vector2 texcoord2, Vector2 texcoord3)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		Color0 = color0;
		Color1 = color1;
		TexCoord0 = texcoord0;
		TexCoord1 = texcoord1;
		TexCoord2 = texcoord2;
		TexCoord3 = texcoord3;
	}

	public VertexColor2Texture4(IVertexMaterial src)
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
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(src, "src");
		Color0 = ((0 < src.MaxColors) ? src.GetColor(0) : Vector4.One);
		Color1 = ((1 < src.MaxColors) ? src.GetColor(1) : Vector4.One);
		TexCoord0 = ((0 < src.MaxTextCoords) ? src.GetTexCoord(0) : Vector2.Zero);
		TexCoord1 = ((1 < src.MaxTextCoords) ? src.GetTexCoord(1) : Vector2.Zero);
		TexCoord2 = ((2 < src.MaxTextCoords) ? src.GetTexCoord(2) : Vector2.Zero);
		TexCoord3 = ((3 < src.MaxTextCoords) ? src.GetTexCoord(3) : Vector2.Zero);
	}

	IEnumerable<KeyValuePair<string, AttributeFormat>> IVertexReflection.GetEncodingAttributes()
	{
		yield return new KeyValuePair<string, AttributeFormat>("COLOR_0", new AttributeFormat(DimensionType.VEC4, EncodingType.UNSIGNED_BYTE, nrm: true));
		yield return new KeyValuePair<string, AttributeFormat>("COLOR_1", new AttributeFormat(DimensionType.VEC4, EncodingType.UNSIGNED_BYTE, nrm: true));
		yield return new KeyValuePair<string, AttributeFormat>("TEXCOORD_0", new AttributeFormat(DimensionType.VEC2));
		yield return new KeyValuePair<string, AttributeFormat>("TEXCOORD_1", new AttributeFormat(DimensionType.VEC2));
		yield return new KeyValuePair<string, AttributeFormat>("TEXCOORD_2", new AttributeFormat(DimensionType.VEC2));
		yield return new KeyValuePair<string, AttributeFormat>("TEXCOORD_3", new AttributeFormat(DimensionType.VEC2));
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
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		return ((object)Color0/*cast due to constrained. prefix*/).GetHashCode() + ((object)Color1/*cast due to constrained. prefix*/).GetHashCode() + ((object)TexCoord0/*cast due to constrained. prefix*/).GetHashCode() + ((object)TexCoord1/*cast due to constrained. prefix*/).GetHashCode() + ((object)TexCoord2/*cast due to constrained. prefix*/).GetHashCode() + ((object)TexCoord3/*cast due to constrained. prefix*/).GetHashCode();
	}

	public override readonly bool Equals(object obj)
	{
		if (!(obj is VertexColor2Texture4 other))
		{
			return false;
		}
		return Equals(other);
	}

	public readonly bool Equals(VertexColor2Texture4 other)
	{
		return AreEqual(this, in other);
	}

	public static bool operator ==(in VertexColor2Texture4 a, in VertexColor2Texture4 b)
	{
		return AreEqual(in a, in b);
	}

	public static bool operator !=(in VertexColor2Texture4 a, in VertexColor2Texture4 b)
	{
		return !AreEqual(in a, in b);
	}

	public static bool AreEqual(in VertexColor2Texture4 a, in VertexColor2Texture4 b)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
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
		if (a.TexCoord2 != b.TexCoord2)
		{
			return false;
		}
		if (a.TexCoord3 != b.TexCoord3)
		{
			return false;
		}
		return true;
	}

	public readonly VertexMaterialDelta Subtract(IVertexMaterial baseValue)
	{
		return new VertexMaterialDelta((VertexColor2Texture4)(object)baseValue, this);
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
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		Color0 += delta.Color0Delta;
		Color1 += delta.Color1Delta;
		TexCoord0 += delta.TexCoord0Delta;
		TexCoord1 += delta.TexCoord1Delta;
		TexCoord2 += delta.TexCoord2Delta;
		TexCoord3 += delta.TexCoord3Delta;
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
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		if (index == 0)
		{
			TexCoord0 = coord;
		}
		if (index == 1)
		{
			TexCoord1 = coord;
		}
		if (index == 2)
		{
			TexCoord2 = coord;
		}
		if (index == 3)
		{
			TexCoord3 = coord;
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
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		return (Vector2)(index switch
		{
			0 => TexCoord0, 
			1 => TexCoord1, 
			2 => TexCoord2, 
			3 => TexCoord3, 
			_ => throw new ArgumentOutOfRangeException("index"), 
		});
	}

	void IVertexMaterial.Add(in VertexMaterialDelta delta)
	{
		Add(in delta);
	}
}
