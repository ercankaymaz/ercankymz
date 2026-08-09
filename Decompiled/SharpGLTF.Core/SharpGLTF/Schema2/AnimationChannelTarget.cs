using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using SharpGLTF.Collections;
using SharpGLTF.IO;
using SharpGLTF.Reflection;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
internal sealed class AnimationChannelTarget : ExtraProperties, IChildOf<AnimationChannel>
{
	public new const string SCHEMANAME = "target";

	private int? _node;

	private PropertyPath _path;

	private AnimationChannel _Parent;

	AnimationChannel IChildOf<AnimationChannel>.LogicalParent => _Parent;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal PropertyPath _NodePath => _path;

	protected override string GetSchemaName()
	{
		return "target";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "node";
		yield return "path";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		if (!(name == "node"))
		{
			if (name == "path")
			{
				value = FieldInfo.From("path", this, (AnimationChannelTarget instance) => instance._path);
				return true;
			}
			return base.TryReflectField(name, out value);
		}
		value = FieldInfo.From("node", this, (AnimationChannelTarget instance) => instance._node);
		return true;
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "node", _node);
		JsonSerializable.SerializePropertyEnumSymbol<PropertyPath>(writer, "path", _path);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		if (!(jsonPropertyName == "node"))
		{
			if (jsonPropertyName == "path")
			{
				_path = JsonSerializable.DeserializePropertyValue<PropertyPath>(ref reader);
			}
			else
			{
				base.DeserializeProperty(jsonPropertyName, ref reader);
			}
		}
		else
		{
			JsonSerializable.DeserializePropertyValue<AnimationChannelTarget, int?>(ref reader, this, out _node);
		}
	}

	internal AnimationChannelTarget()
	{
	}

	internal AnimationChannelTarget(Node targetNode, PropertyPath targetPath)
	{
		_node = targetNode.LogicalIndex;
		_path = targetPath;
	}

	internal AnimationChannelTarget(string pointer)
	{
		if (AnimationPointer.TryParseNodeTransform(pointer, out var nodeIndex, out var property))
		{
			_node = nodeIndex;
			_path = property;
			RemoveExtensions<AnimationPointer>();
		}
		else
		{
			_node = null;
			_path = PropertyPath.pointer;
			AnimationPointer animationPointer = UseExtension<AnimationPointer>();
			animationPointer.Pointer = pointer;
		}
	}

	void IChildOf<AnimationChannel>.SetLogicalParent(AnimationChannel parent)
	{
		_Parent = parent;
	}

	public int GetNodeIndex()
	{
		if (_node.HasValue)
		{
			return _node.Value;
		}
		if (_NodePath == PropertyPath.pointer)
		{
			AnimationPointer extension = GetExtension<AnimationPointer>();
			if (extension != null && AnimationPointer.TryParseNodeIndex(extension.Pointer, out var nodeIndex))
			{
				return nodeIndex;
			}
		}
		return -1;
	}

	public PropertyPath GetNodePath()
	{
		if (_NodePath == PropertyPath.pointer)
		{
			AnimationPointer extension = GetExtension<AnimationPointer>();
			if (extension != null && AnimationPointer.TryParseNodeTransform(extension.Pointer, out var _, out var property))
			{
				return property;
			}
		}
		return _NodePath;
	}

	public string GetPointerPath()
	{
		AnimationPointer extension = GetExtension<AnimationPointer>();
		if (extension != null)
		{
			return extension.Pointer;
		}
		if (!_node.HasValue || _node.Value < 0)
		{
			return null;
		}
		return $"/nodes/{_node.Value}/{_NodePath}";
	}

	protected override void OnValidateReferences(ValidationContext validate)
	{
		base.OnValidateReferences(validate);
		validate.IsNullOrIndex("Node", _node, validate.Root.LogicalNodes);
		AnimationPointer extension = GetExtension<AnimationPointer>();
	}
}
