using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Reflection;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
[DebuggerDisplay("Occlusion LogicalTexture[{_LogicalTextureIndex}] x {Strength}")]
internal sealed class MaterialOcclusionTextureInfo : TextureInfo
{
	public new const string SCHEMANAME = "occlusionTextureInfo";

	private const double _strengthDefault = 1.0;

	private const double _strengthMinimum = 0.0;

	private const double _strengthMaximum = 1.0;

	private double? _strength = 1.0;

	public static float StrengthDefault => 1f;

	public float Strength
	{
		get
		{
			return (float)_strength.AsValue(1.0);
		}
		set
		{
			_strength = _Schema2Extensions.AsNullable(value, 1.0, 0.0, 1.0);
		}
	}

	protected override string GetSchemaName()
	{
		return "occlusionTextureInfo";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "strength";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		if (name == "strength")
		{
			value = FieldInfo.From("strength", this, (MaterialOcclusionTextureInfo instance) => instance._strength ?? 1.0);
			return true;
		}
		return base.TryReflectField(name, out value);
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "strength", _strength, 1.0);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		if (jsonPropertyName == "strength")
		{
			JsonSerializable.DeserializePropertyValue<MaterialOcclusionTextureInfo, double?>(ref reader, this, out _strength);
		}
		else
		{
			base.DeserializeProperty(jsonPropertyName, ref reader);
		}
	}
}
