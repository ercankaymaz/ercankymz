using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Reflection;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
[DebuggerDisplay("TextureSampler[{LogicalIndex}] {Name}")]
public sealed class TextureSampler : LogicalChildOfRoot
{
	private class _ContentComparer : IEqualityComparer<TextureSampler>
	{
		public bool Equals(TextureSampler x, TextureSampler y)
		{
			return AreEqualByContent(x, y);
		}

		public int GetHashCode(TextureSampler obj)
		{
			return obj?.GetContentHashCode() ?? 0;
		}
	}

	public new const string SCHEMANAME = "sampler";

	private TextureInterpolationFilter? _magFilter;

	private TextureMipMapFilter? _minFilter;

	private const TextureWrapMode _wrapSDefault = TextureWrapMode.REPEAT;

	private TextureWrapMode? _wrapS = TextureWrapMode.REPEAT;

	private const TextureWrapMode _wrapTDefault = TextureWrapMode.REPEAT;

	private TextureWrapMode? _wrapT = TextureWrapMode.REPEAT;

	public TextureMipMapFilter MinFilter => _minFilter.AsValue(TextureMipMapFilter.DEFAULT);

	public TextureInterpolationFilter MagFilter => _magFilter.AsValue(TextureInterpolationFilter.DEFAULT);

	public TextureWrapMode WrapS => _wrapS.AsValue(TextureWrapMode.REPEAT);

	public TextureWrapMode WrapT => _wrapT.AsValue(TextureWrapMode.REPEAT);

	public static IEqualityComparer<TextureSampler> ContentComparer { get; private set; } = new _ContentComparer();

	protected override string GetSchemaName()
	{
		return "sampler";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "magFilter";
		yield return "minFilter";
		yield return "wrapS";
		yield return "wrapT";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		switch (name)
		{
		case "magFilter":
			value = FieldInfo.From("magFilter", this, (TextureSampler instance) => instance._magFilter);
			return true;
		case "minFilter":
			value = FieldInfo.From("minFilter", this, (TextureSampler instance) => instance._minFilter);
			return true;
		case "wrapS":
			value = FieldInfo.From("wrapS", this, (TextureSampler instance) => instance._wrapS ?? TextureWrapMode.REPEAT);
			return true;
		case "wrapT":
			value = FieldInfo.From("wrapT", this, (TextureSampler instance) => instance._wrapT ?? TextureWrapMode.REPEAT);
			return true;
		default:
			return base.TryReflectField(name, out value);
		}
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializePropertyEnumValue(writer, "magFilter", _magFilter);
		JsonSerializable.SerializePropertyEnumValue(writer, "minFilter", _minFilter);
		JsonSerializable.SerializePropertyEnumValue(writer, "wrapS", _wrapS, TextureWrapMode.REPEAT);
		JsonSerializable.SerializePropertyEnumValue(writer, "wrapT", _wrapT, TextureWrapMode.REPEAT);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		switch (jsonPropertyName)
		{
		case "magFilter":
			_magFilter = JsonSerializable.DeserializePropertyValue<TextureInterpolationFilter>(ref reader);
			break;
		case "minFilter":
			_minFilter = JsonSerializable.DeserializePropertyValue<TextureMipMapFilter>(ref reader);
			break;
		case "wrapS":
			_wrapS = JsonSerializable.DeserializePropertyValue<TextureWrapMode>(ref reader);
			break;
		case "wrapT":
			_wrapT = JsonSerializable.DeserializePropertyValue<TextureWrapMode>(ref reader);
			break;
		default:
			base.DeserializeProperty(jsonPropertyName, ref reader);
			break;
		}
	}

	internal TextureSampler()
	{
	}

	internal TextureSampler(TextureMipMapFilter min, TextureInterpolationFilter mag, TextureWrapMode ws, TextureWrapMode wt)
	{
		_magFilter = mag.AsNullable(TextureInterpolationFilter.DEFAULT);
		_minFilter = min.AsNullable(TextureMipMapFilter.DEFAULT);
		_wrapS = ws.AsNullable(TextureWrapMode.REPEAT);
		_wrapT = wt.AsNullable(TextureWrapMode.REPEAT);
	}

	internal static bool IsDefault(TextureMipMapFilter min, TextureInterpolationFilter mag, TextureWrapMode ws, TextureWrapMode wt)
	{
		if (min != TextureMipMapFilter.DEFAULT)
		{
			return false;
		}
		if (mag != TextureInterpolationFilter.DEFAULT)
		{
			return false;
		}
		if (ws != TextureWrapMode.REPEAT)
		{
			return false;
		}
		if (wt != TextureWrapMode.REPEAT)
		{
			return false;
		}
		return true;
	}

	public static bool AreEqualByContent(TextureSampler x, TextureSampler y)
	{
		if (x == y)
		{
			return true;
		}
		if (x == null)
		{
			return false;
		}
		if (y == null)
		{
			return false;
		}
		if (x._minFilter != y._minFilter)
		{
			return false;
		}
		if (x._magFilter != y._magFilter)
		{
			return false;
		}
		if (x._wrapS != y._wrapS)
		{
			return false;
		}
		if (x._wrapT != y._wrapT)
		{
			return false;
		}
		return true;
	}

	internal bool IsEqualTo(TextureMipMapFilter min, TextureInterpolationFilter mag, TextureWrapMode ws, TextureWrapMode wt)
	{
		if (_minFilter != min)
		{
			return false;
		}
		if (_magFilter != mag)
		{
			return false;
		}
		if (_wrapS != ws)
		{
			return false;
		}
		if (_wrapT != wt)
		{
			return false;
		}
		return true;
	}

	public int GetContentHashCode()
	{
		int num = 0;
		num ^= MinFilter.GetHashCode();
		num ^= MagFilter.GetHashCode();
		num ^= WrapS.GetHashCode();
		return num ^ WrapT.GetHashCode();
	}
}
