using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Reflection;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
[DebuggerDisplay("Normal LogicalTexture[{_LogicalTextureIndex}] x {Scale}")]
internal sealed class MaterialNormalTextureInfo : TextureInfo
{
	public new const string SCHEMANAME = "normalTextureInfo";

	private const double _scaleDefault = 1.0;

	private double? _scale = 1.0;

	public static float ScaleDefault => 1f;

	public float Scale
	{
		get
		{
			return (float)_scale.AsValue(1.0);
		}
		set
		{
			_scale = _Schema2Extensions.AsNullable(value, 1.0);
		}
	}

	protected override string GetSchemaName()
	{
		return "normalTextureInfo";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "scale";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		if (name == "scale")
		{
			value = FieldInfo.From("scale", this, (MaterialNormalTextureInfo instance) => instance._scale ?? 1.0);
			return true;
		}
		return base.TryReflectField(name, out value);
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "scale", _scale, 1.0);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		if (jsonPropertyName == "scale")
		{
			JsonSerializable.DeserializePropertyValue<MaterialNormalTextureInfo, double?>(ref reader, this, out _scale);
		}
		else
		{
			base.DeserializeProperty(jsonPropertyName, ref reader);
		}
	}
}
