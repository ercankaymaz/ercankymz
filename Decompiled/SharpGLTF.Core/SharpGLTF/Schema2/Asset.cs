using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using SharpGLTF.Collections;
using SharpGLTF.IO;
using SharpGLTF.Reflection;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
[DebuggerDisplay("{Version} {MinVersion} {Generator} {Copyright}")]
public sealed class Asset : ExtraProperties, IChildOf<ModelRoot>
{
	public new const string SCHEMANAME = "asset";

	private string _copyright;

	private string _generator;

	private string _minVersion;

	private string _version;

	private static readonly Version ZEROVERSION = new Version(0, 0);

	private static readonly Version MINVERSION = new Version(2, 0);

	private static readonly Version MAXVERSION = new Version(2, 0);

	public ModelRoot LogicalParent { get; private set; }

	public static string AssemblyInformationalVersion => typeof(Asset).Assembly.GetCustomAttributes(inherit: true).OfType<AssemblyInformationalVersionAttribute>().FirstOrDefault()?.InformationalVersion ?? string.Empty;

	public string Copyright
	{
		get
		{
			return _copyright;
		}
		set
		{
			_copyright = value.AsEmptyNullable();
		}
	}

	public string Generator
	{
		get
		{
			return _generator;
		}
		set
		{
			_generator = value.AsEmptyNullable();
		}
	}

	public Version Version
	{
		get
		{
			if (!Version.TryParse(_version, out Version result))
			{
				return ZEROVERSION;
			}
			return result;
		}
	}

	public Version MinVersion
	{
		get
		{
			if (!Version.TryParse(_minVersion, out Version result))
			{
				return MINVERSION;
			}
			return result;
		}
	}

	protected override string GetSchemaName()
	{
		return "asset";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "copyright";
		yield return "generator";
		yield return "minVersion";
		yield return "version";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out SharpGLTF.Reflection.FieldInfo value)
	{
		switch (name)
		{
		case "copyright":
			value = SharpGLTF.Reflection.FieldInfo.From("copyright", this, (Asset instance) => instance._copyright);
			return true;
		case "generator":
			value = SharpGLTF.Reflection.FieldInfo.From("generator", this, (Asset instance) => instance._generator);
			return true;
		case "minVersion":
			value = SharpGLTF.Reflection.FieldInfo.From("minVersion", this, (Asset instance) => instance._minVersion);
			return true;
		case "version":
			value = SharpGLTF.Reflection.FieldInfo.From("version", this, (Asset instance) => instance._version);
			return true;
		default:
			return base.TryReflectField(name, out value);
		}
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "copyright", _copyright);
		JsonSerializable.SerializeProperty(writer, "generator", _generator);
		JsonSerializable.SerializeProperty(writer, "minVersion", _minVersion);
		JsonSerializable.SerializeProperty(writer, "version", _version);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		switch (jsonPropertyName)
		{
		case "copyright":
			JsonSerializable.DeserializePropertyValue<Asset, string>(ref reader, this, out _copyright);
			break;
		case "generator":
			JsonSerializable.DeserializePropertyValue<Asset, string>(ref reader, this, out _generator);
			break;
		case "minVersion":
			JsonSerializable.DeserializePropertyValue<Asset, string>(ref reader, this, out _minVersion);
			break;
		case "version":
			JsonSerializable.DeserializePropertyValue<Asset, string>(ref reader, this, out _version);
			break;
		default:
			base.DeserializeProperty(jsonPropertyName, ref reader);
			break;
		}
	}

	internal Asset()
	{
	}

	internal static Asset CreateDefault(string copyright)
	{
		string assemblyInformationalVersion = AssemblyInformationalVersion;
		string generator = (string.IsNullOrWhiteSpace(assemblyInformationalVersion) ? "SharpGLTF" : ("SharpGLTF " + assemblyInformationalVersion));
		return new Asset
		{
			_generator = generator,
			_copyright = copyright,
			_version = MINVERSION.ToString(),
			_minVersion = null
		};
	}

	void IChildOf<ModelRoot>.SetLogicalParent(ModelRoot parent)
	{
		LogicalParent = parent;
	}

	protected override void OnValidateReferences(ValidationContext validate)
	{
		base.OnValidateReferences(validate);
		validate.IsTrue("Version", Version.TryParse(_version, out Version _), "Unknown glTF major asset version: " + _version + ".");
		validate.IsGreaterOrEqual("Version", Version, MINVERSION);
	}
}
