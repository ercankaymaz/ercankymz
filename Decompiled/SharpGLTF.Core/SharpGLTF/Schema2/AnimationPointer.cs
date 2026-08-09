using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Reflection;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
internal sealed class AnimationPointer : ExtraProperties
{
	public new const string SCHEMANAME = "KHR_animation_pointer";

	private string _pointer;

	private AnimationChannelTarget _LogicalParent;

	public string Pointer
	{
		get
		{
			return _pointer;
		}
		set
		{
			_pointer = value;
		}
	}

	protected override string GetSchemaName()
	{
		return "KHR_animation_pointer";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "pointer";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		if (name == "pointer")
		{
			value = FieldInfo.From("pointer", this, (AnimationPointer instance) => instance._pointer);
			return true;
		}
		return base.TryReflectField(name, out value);
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "pointer", _pointer);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		if (jsonPropertyName == "pointer")
		{
			JsonSerializable.DeserializePropertyValue<AnimationPointer, string>(ref reader, this, out _pointer);
		}
		else
		{
			base.DeserializeProperty(jsonPropertyName, ref reader);
		}
	}

	public AnimationPointer(AnimationChannelTarget parent)
	{
		_LogicalParent = parent;
	}

	public static bool TryParseNodeTransform(string pointerPath, out int nodeIndex, out PropertyPath property)
	{
		property = PropertyPath.pointer;
		if (!TryParseNodeIndex(pointerPath, out nodeIndex))
		{
			return false;
		}
		pointerPath = pointerPath.Substring(7);
		int num = _Extensions.IndexOf(pointerPath, '/', StringComparison.Ordinal);
		if (num < 0)
		{
			return false;
		}
		switch (pointerPath.Substring(num + 1))
		{
		case "scale":
			property = PropertyPath.scale;
			return true;
		case "rotation":
			property = PropertyPath.rotation;
			return true;
		case "translation":
			property = PropertyPath.translation;
			return true;
		case "weights":
			property = PropertyPath.weights;
			return true;
		default:
			return false;
		}
	}

	public static bool TryParseNodeIndex(string pointerPath, out int nodeIndex)
	{
		nodeIndex = -1;
		if (pointerPath == null || !pointerPath.StartsWith("/nodes/"))
		{
			return false;
		}
		pointerPath = pointerPath.Substring(7);
		int num = _Extensions.IndexOf(pointerPath, '/', StringComparison.Ordinal);
		if (num < 0)
		{
			num = pointerPath.Length;
		}
		return int.TryParse(pointerPath.Substring(0, num), NumberStyles.Integer, CultureInfo.InvariantCulture, out nodeIndex);
	}
}
