using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Memory;
using SharpGLTF.Reflection;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
[DebuggerDisplay("Texture[{LogicalIndex}] {Name}")]
public sealed class Texture : LogicalChildOfRoot
{
	public new const string SCHEMANAME = "texture";

	private int? _sampler;

	private int? _source;

	public TextureSampler Sampler
	{
		get
		{
			if (!_sampler.HasValue)
			{
				return null;
			}
			return base.LogicalParent.LogicalTextureSamplers[_sampler.Value];
		}
		set
		{
			if (value != null)
			{
				Guard.MustShareLogicalParent(this, value, "value");
			}
			_sampler = value?.LogicalIndex;
		}
	}

	public Image PrimaryImage => _GetPrimaryImage();

	public Image FallbackImage => _GetFallbackImage();

	protected override string GetSchemaName()
	{
		return "texture";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "sampler";
		yield return "source";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		if (!(name == "sampler"))
		{
			if (name == "source")
			{
				value = FieldInfo.From("source", this, (Texture instance) => instance._source);
				return true;
			}
			return base.TryReflectField(name, out value);
		}
		value = FieldInfo.From("sampler", this, (Texture instance) => instance._sampler);
		return true;
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "sampler", _sampler);
		JsonSerializable.SerializeProperty(writer, "source", _source);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		if (!(jsonPropertyName == "sampler"))
		{
			if (jsonPropertyName == "source")
			{
				JsonSerializable.DeserializePropertyValue<Texture, int?>(ref reader, this, out _source);
			}
			else
			{
				base.DeserializeProperty(jsonPropertyName, ref reader);
			}
		}
		else
		{
			JsonSerializable.DeserializePropertyValue<Texture, int?>(ref reader, this, out _sampler);
		}
	}

	internal Texture()
	{
	}

	private Image _GetPrimaryImage()
	{
		Image image = GetExtension<TextureDDS>()?.Image;
		if (image != null)
		{
			return image;
		}
		Image image2 = GetExtension<TextureWEBP>()?.Image;
		if (image2 != null)
		{
			return image2;
		}
		Image image3 = GetExtension<TextureKTX2>()?.Image;
		if (image3 != null)
		{
			return image3;
		}
		if (!_source.HasValue)
		{
			return null;
		}
		return base.LogicalParent.LogicalImages[_source.Value];
	}

	private Image _GetFallbackImage()
	{
		Image image = (_source.HasValue ? base.LogicalParent.LogicalImages[_source.Value] : null);
		if (_GetPrimaryImage() != image)
		{
			return image;
		}
		return null;
	}

	public void SetImage(Image primaryImage)
	{
		Guard.NotNull(primaryImage, "primaryImage");
		Guard.MustShareLogicalParent(this, primaryImage, "primaryImage");
		if (primaryImage.Content.IsExtendedFormat)
		{
			Image fallbackImage = base.LogicalParent.UseImage(MemoryImage.DefaultPngImage);
			SetImages(primaryImage, fallbackImage);
		}
		else
		{
			ClearImages();
			_source = primaryImage.LogicalIndex;
		}
	}

	public void SetImages(Image primaryImage, Image fallbackImage)
	{
		Guard.NotNull(primaryImage, "primaryImage");
		Guard.NotNull(fallbackImage, "fallbackImage");
		Guard.MustShareLogicalParent(this, primaryImage, "primaryImage");
		Guard.MustShareLogicalParent(this, fallbackImage, "fallbackImage");
		Guard.IsTrue(primaryImage.Content.IsExtendedFormat, "Primary image must be DDS, WEBP or KTX2");
		Guard.IsTrue(fallbackImage.Content.IsJpg || fallbackImage.Content.IsPng, "fallbackImage", "Fallback image must be PNG or JPEG");
		if (primaryImage.Content.IsDds)
		{
			_UseDDSTexture().Image = primaryImage;
		}
		if (primaryImage.Content.IsWebp)
		{
			_UseWEBPTexture().Image = primaryImage;
		}
		if (primaryImage.Content.IsKtx2)
		{
			_UseKTX2Texture().Image = primaryImage;
		}
		_source = fallbackImage.LogicalIndex;
	}

	public void ClearImages()
	{
		_source = null;
		RemoveExtensions<TextureDDS>();
		RemoveExtensions<TextureWEBP>();
		RemoveExtensions<TextureKTX2>();
	}

	private TextureDDS _UseDDSTexture()
	{
		RemoveExtensions<TextureWEBP>();
		RemoveExtensions<TextureKTX2>();
		return UseExtension<TextureDDS>();
	}

	private TextureWEBP _UseWEBPTexture()
	{
		RemoveExtensions<TextureDDS>();
		RemoveExtensions<TextureKTX2>();
		return UseExtension<TextureWEBP>();
	}

	private TextureKTX2 _UseKTX2Texture()
	{
		RemoveExtensions<TextureDDS>();
		RemoveExtensions<TextureWEBP>();
		return UseExtension<TextureKTX2>();
	}

	internal bool _IsEqualentTo(Image primary, Image fallback, TextureSampler sampler)
	{
		if (primary != PrimaryImage)
		{
			return false;
		}
		if (fallback != FallbackImage)
		{
			return false;
		}
		if (sampler != Sampler)
		{
			return false;
		}
		return true;
	}

	protected override void OnValidateReferences(ValidationContext validate)
	{
		base.OnValidateReferences(validate);
		validate.IsNullOrIndex("Source", _source, base.LogicalParent.LogicalImages).IsNullOrIndex("Sampler", _sampler, base.LogicalParent.LogicalTextureSamplers);
	}
}
