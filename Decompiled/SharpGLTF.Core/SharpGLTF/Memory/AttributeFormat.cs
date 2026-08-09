using System;
using System.Diagnostics;
using SharpGLTF.Schema2;

namespace SharpGLTF.Memory;

[DebuggerDisplay("{_GetDebuggerDisplay(),nq}")]
public readonly struct AttributeFormat : IEquatable<AttributeFormat>
{
	public static readonly AttributeFormat Float1;

	public static readonly AttributeFormat Float2;

	public static readonly AttributeFormat Float3;

	public static readonly AttributeFormat Float4;

	public static readonly AttributeFormat Float2x2;

	public static readonly AttributeFormat Float3x3;

	public static readonly AttributeFormat Float4x4;

	public readonly EncodingType Encoding;

	public readonly DimensionType Dimensions;

	public readonly bool Normalized;

	public readonly int ByteSize;

	public int ByteSizePadded => ByteSize.WordPadded();

	internal string _GetDebuggerDisplay()
	{
		string text = $"{Encoding}";
		switch (Dimensions)
		{
		case DimensionType.VEC2:
			text += "2";
			break;
		case DimensionType.VEC3:
			text += "3";
			break;
		case DimensionType.VEC4:
			text += "4";
			break;
		case DimensionType.MAT2:
			text += "2x2";
			break;
		case DimensionType.MAT3:
			text += "3x3";
			break;
		case DimensionType.MAT4:
			text += "4x4";
			break;
		default:
			text += "?";
			break;
		case DimensionType.SCALAR:
			break;
		}
		if (Normalized)
		{
			text += " Normalized";
		}
		return text;
	}

	public static implicit operator AttributeFormat(IndexEncodingType indexer)
	{
		return new AttributeFormat(indexer);
	}

	public static implicit operator AttributeFormat(EncodingType enc)
	{
		return new AttributeFormat(enc);
	}

	public static implicit operator AttributeFormat(DimensionType dim)
	{
		return new AttributeFormat(dim);
	}

	public static implicit operator AttributeFormat((DimensionType dim, EncodingType enc) fmt)
	{
		return new AttributeFormat(fmt.dim, fmt.enc);
	}

	public static implicit operator AttributeFormat((DimensionType dim, EncodingType enc, bool nrm) fmt)
	{
		return new AttributeFormat(fmt.dim, fmt.enc, fmt.nrm);
	}

	public AttributeFormat(IndexEncodingType enc)
	{
		Dimensions = DimensionType.SCALAR;
		Encoding = enc.ToComponent();
		Normalized = false;
		ByteSize = Dimensions.DimCount() * Encoding.ByteLength();
	}

	public AttributeFormat(EncodingType enc)
	{
		Dimensions = DimensionType.SCALAR;
		Encoding = enc;
		Normalized = false;
		ByteSize = Dimensions.DimCount() * Encoding.ByteLength();
	}

	public AttributeFormat(DimensionType dim)
	{
		Dimensions = dim;
		Encoding = EncodingType.FLOAT;
		Normalized = false;
		ByteSize = Dimensions.DimCount() * Encoding.ByteLength();
	}

	public AttributeFormat(DimensionType dim, EncodingType enc)
	{
		Dimensions = dim;
		Encoding = enc;
		Normalized = false;
		ByteSize = Dimensions.DimCount() * Encoding.ByteLength();
	}

	public AttributeFormat(DimensionType dim, EncodingType enc, bool nrm)
	{
		if (nrm)
		{
			Guard.IsFalse(enc == EncodingType.FLOAT, "nrm", "Float encoding must not be normalized");
		}
		Dimensions = dim;
		Encoding = enc;
		Normalized = nrm;
		ByteSize = Dimensions.DimCount() * Encoding.ByteLength();
	}

	public override int GetHashCode()
	{
		int num = Dimensions.GetHashCode() ^ Encoding.GetHashCode();
		bool normalized = Normalized;
		return num ^ normalized.GetHashCode();
	}

	public static bool AreEqual(AttributeFormat a, AttributeFormat b)
	{
		if (a.Encoding != b.Encoding)
		{
			return false;
		}
		if (a.Dimensions != b.Dimensions)
		{
			return false;
		}
		if (a.Normalized != b.Normalized)
		{
			return false;
		}
		return true;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is AttributeFormat b))
		{
			return false;
		}
		return AreEqual(this, b);
	}

	public bool Equals(AttributeFormat other)
	{
		return AreEqual(this, other);
	}

	public static bool operator ==(AttributeFormat a, AttributeFormat b)
	{
		return AreEqual(a, b);
	}

	public static bool operator !=(AttributeFormat a, AttributeFormat b)
	{
		return !AreEqual(a, b);
	}

	static AttributeFormat()
	{
		Float1 = new AttributeFormat(EncodingType.FLOAT);
		Float2 = new AttributeFormat(DimensionType.VEC2, EncodingType.FLOAT);
		Float3 = new AttributeFormat(DimensionType.VEC3, EncodingType.FLOAT);
		Float4 = new AttributeFormat(DimensionType.VEC4, EncodingType.FLOAT);
		Float2x2 = new AttributeFormat(DimensionType.MAT2, EncodingType.FLOAT);
		Float3x3 = new AttributeFormat(DimensionType.MAT3, EncodingType.FLOAT);
		Float4x4 = new AttributeFormat(DimensionType.MAT4, EncodingType.FLOAT);
	}
}
