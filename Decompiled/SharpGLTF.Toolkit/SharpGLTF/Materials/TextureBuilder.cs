using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using SharpGLTF.Schema2;

namespace SharpGLTF.Materials;

[DebuggerDisplay("{_DebuggerDisplay(),nq}")]
public class TextureBuilder : BaseBuilder
{
	private sealed class _ContentComparer : IEqualityComparer<TextureBuilder>
	{
		public static readonly _ContentComparer Default = new _ContentComparer();

		public bool Equals(TextureBuilder x, TextureBuilder y)
		{
			return AreEqualByContent(x, y);
		}

		public int GetHashCode(TextureBuilder obj)
		{
			return GetContentHashCode(obj);
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly ChannelBuilder _Parent;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ImageBuilder _PrimaryImageContent;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ImageBuilder _FallbackImageContent;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextureTransformBuilder _Transform;

	public int CoordinateSet { get; set; }

	public TextureMipMapFilter MinFilter { get; set; }

	public TextureInterpolationFilter MagFilter { get; set; }

	public TextureWrapMode WrapS { get; set; } = TextureWrapMode.REPEAT;

	public TextureWrapMode WrapT { get; set; } = TextureWrapMode.REPEAT;

	public ImageBuilder PrimaryImage
	{
		get
		{
			return _PrimaryImageContent;
		}
		set
		{
			WithPrimaryImage(value);
		}
	}

	public ImageBuilder FallbackImage
	{
		get
		{
			return _FallbackImageContent;
		}
		set
		{
			WithFallbackImage(value);
		}
	}

	public TextureTransformBuilder Transform => _Transform;

	public static IEqualityComparer<TextureBuilder> ContentComparer => _ContentComparer.Default;

	internal string _DebuggerDisplay()
	{
		string text = "Texture ";
		if (CoordinateSet != 0)
		{
			text += $" {CoordinateSet}ˢᵉᵗ";
		}
		if (MinFilter != TextureMipMapFilter.DEFAULT)
		{
			text += $" {MinFilter}ᴹⁱⁿ";
		}
		if (MagFilter != TextureInterpolationFilter.DEFAULT)
		{
			text += $" {MagFilter}ᴹᵃᵍ";
		}
		if (WrapS != TextureWrapMode.REPEAT)
		{
			text += $" {WrapS}↔";
		}
		if (WrapT != TextureWrapMode.REPEAT)
		{
			text += $" {WrapT}↕";
		}
		if (_PrimaryImageContent != null)
		{
			text = text + " " + _PrimaryImageContent.Content.ToDebuggerDisplay();
		}
		if (_FallbackImageContent != null)
		{
			text = text + " => " + _FallbackImageContent.Content.ToDebuggerDisplay();
		}
		return text;
	}

	internal TextureBuilder(ChannelBuilder parent)
	{
		SharpGLTF.Guard.NotNull(parent, "parent");
		_Parent = parent;
	}

	public static bool AreEqualByContent(TextureBuilder x, TextureBuilder y)
	{
		if (x == null || y == null)
		{
			return true;
		}
		if ((x: x, y: y).AreSameReference(out var result))
		{
			return result;
		}
		if (!BaseBuilder.AreEqualByContent(x, y))
		{
			return false;
		}
		if (x.CoordinateSet != y.CoordinateSet)
		{
			return false;
		}
		if (x.MinFilter != y.MinFilter)
		{
			return false;
		}
		if (x.MagFilter != y.MagFilter)
		{
			return false;
		}
		if (x.WrapS != y.WrapS)
		{
			return false;
		}
		if (x.WrapT != y.WrapT)
		{
			return false;
		}
		if (!ImageBuilder.AreEqualByContent(x._PrimaryImageContent, y._PrimaryImageContent))
		{
			return false;
		}
		if (!ImageBuilder.AreEqualByContent(x._FallbackImageContent, y._FallbackImageContent))
		{
			return false;
		}
		if (!TextureTransformBuilder.AreEqualByContent(x._Transform, y._Transform))
		{
			return false;
		}
		return true;
	}

	public static int GetContentHashCode(TextureBuilder x)
	{
		if (x == null)
		{
			return 0;
		}
		int contentHashCode = BaseBuilder.GetContentHashCode(x);
		contentHashCode ^= x.CoordinateSet.GetHashCode();
		contentHashCode ^= x.MinFilter.GetHashCode();
		contentHashCode ^= x.MagFilter.GetHashCode();
		contentHashCode ^= x.WrapS.GetHashCode();
		contentHashCode ^= x.WrapT.GetHashCode();
		contentHashCode ^= ImageBuilder.GetContentHashCode(x._PrimaryImageContent);
		return contentHashCode ^ ImageBuilder.GetContentHashCode(x._FallbackImageContent);
	}

	internal void CopyTo(TextureBuilder other)
	{
		other.SetNameAndExtrasFrom(other);
		other._PrimaryImageContent = _PrimaryImageContent?.Clone();
		other._FallbackImageContent = _FallbackImageContent?.Clone();
		other.CoordinateSet = CoordinateSet;
		other.MinFilter = MinFilter;
		other.MagFilter = MagFilter;
		other.WrapS = WrapS;
		other.WrapT = WrapT;
		TextureTransformBuilder textureTransformBuilder = new TextureTransformBuilder(_Transform);
		other._Transform = (textureTransformBuilder.IsDefault ? null : textureTransformBuilder);
	}

	public TextureBuilder WithCoordinateSet(int cset)
	{
		CoordinateSet = cset;
		return this;
	}

	public TextureBuilder WithPrimaryImage(ImageBuilder image)
	{
		if (image != null)
		{
			SharpGLTF.Guard.IsTrue(ImageBuilder.IsValid(image), "image", "Must be JPG, PNG, DDS, WEBP or KTX2");
		}
		else
		{
			image = null;
		}
		_PrimaryImageContent = image;
		return this;
	}

	public TextureBuilder WithFallbackImage(ImageBuilder image)
	{
		if (image != null)
		{
			SharpGLTF.Guard.IsTrue(image.Content.IsJpg || image.Content.IsPng, "image", "Must be JPG or PNG");
		}
		else
		{
			image = null;
		}
		_FallbackImageContent = image;
		return this;
	}

	public TextureBuilder WithSampler(TextureWrapMode ws, TextureWrapMode wt, TextureMipMapFilter min = TextureMipMapFilter.DEFAULT, TextureInterpolationFilter mag = TextureInterpolationFilter.DEFAULT)
	{
		WrapS = ws;
		WrapT = wt;
		MinFilter = min;
		MagFilter = mag;
		return this;
	}

	public TextureBuilder WithTransform(float offsetX, float offsetY, float scaleX = 1f, float scaleY = 1f, float rotation = 0f, int? coordSetOverride = null)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		return WithTransform(new Vector2(offsetX, offsetY), new Vector2(scaleX, scaleY), rotation, coordSetOverride);
	}

	public TextureBuilder WithTransform(Vector2 offset, Vector2 scale, float rotation = 0f, int? coordSetOverride = null)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		TextureTransformBuilder textureTransformBuilder = new TextureTransformBuilder(offset, scale, rotation, coordSetOverride);
		_Transform = (textureTransformBuilder.IsDefault ? null : textureTransformBuilder);
		return this;
	}
}
