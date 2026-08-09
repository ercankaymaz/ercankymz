using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text.Json;
using SharpGLTF.Collections;
using SharpGLTF.IO;
using SharpGLTF.Reflection;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
[DebuggerDisplay("LogicalTexture[{_LogicalTextureIndex}]")]
public class TextureInfo : ExtraProperties, IChildOf<Material>
{
	public new const string SCHEMANAME = "textureInfo";

	private int _index;

	private const int _texCoordDefault = 0;

	private const int _texCoordMinimum = 0;

	private int? _texCoord = 0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Material LogicalParent { get; private set; }

	public int LogicalTextureIndex
	{
		get
		{
			return _index;
		}
		protected internal set
		{
			_index = value;
		}
	}

	public int TextureCoordinate
	{
		get
		{
			return _texCoord.AsValue(0);
		}
		set
		{
			_texCoord = value.AsNullable(0, 0, int.MaxValue);
		}
	}

	public TextureTransform Transform => GetExtension<TextureTransform>();

	protected override string GetSchemaName()
	{
		return "textureInfo";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "index";
		yield return "texCoord";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		if (!(name == "index"))
		{
			if (name == "texCoord")
			{
				value = FieldInfo.From("texCoord", this, (TextureInfo instance) => instance._texCoord.GetValueOrDefault());
				return true;
			}
			return base.TryReflectField(name, out value);
		}
		value = FieldInfo.From("index", this, (TextureInfo instance) => instance._index);
		return true;
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "index", _index);
		JsonSerializable.SerializeProperty(writer, "texCoord", _texCoord, 0);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		if (!(jsonPropertyName == "index"))
		{
			if (jsonPropertyName == "texCoord")
			{
				JsonSerializable.DeserializePropertyValue<TextureInfo, int?>(ref reader, this, out _texCoord);
			}
			else
			{
				base.DeserializeProperty(jsonPropertyName, ref reader);
			}
		}
		else
		{
			JsonSerializable.DeserializePropertyValue<TextureInfo, int>(ref reader, this, out _index);
		}
	}

	void IChildOf<Material>.SetLogicalParent(Material parent)
	{
		LogicalParent = parent;
	}

	public void SetTransform(Vector2 offset, Vector2 scale, float rotation, int? texCoordOverride = null)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		TextureTransform textureTransform = new TextureTransform(this)
		{
			TextureCoordinateOverride = texCoordOverride,
			Offset = offset,
			Scale = scale,
			Rotation = rotation
		};
		if (textureTransform.IsDefault)
		{
			RemoveExtensions<TextureTransform>();
		}
		else
		{
			SetExtension(textureTransform);
		}
	}

	protected override void OnValidateReferences(ValidationContext validate)
	{
		validate.IsNullOrIndex("Index", _index, validate.Root.LogicalTextures);
		base.OnValidateReferences(validate);
	}
}
