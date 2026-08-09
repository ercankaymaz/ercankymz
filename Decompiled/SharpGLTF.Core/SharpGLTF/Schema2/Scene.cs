using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Reflection;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
[DebuggerDisplay("Scene[{LogicalIndex}] {Name}")]
public sealed class Scene : LogicalChildOfRoot, IVisualNodeContainer
{
	public new const string SCHEMANAME = "scene";

	private const int _nodesMinItems = 1;

	private List<int> _nodes;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal IReadOnlyList<int> _VisualChildrenIndices => _nodes;

	public IEnumerable<Node> VisualChildren => _nodes.Select((int idx) => base.LogicalParent.LogicalNodes[idx]);

	protected override string GetSchemaName()
	{
		return "scene";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "nodes";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		if (name == "nodes")
		{
			value = FieldInfo.From("nodes", this, (Scene instance) => instance._nodes);
			return true;
		}
		return base.TryReflectField(name, out value);
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "nodes", _nodes, 1);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		if (jsonPropertyName == "nodes")
		{
			JsonSerializable.DeserializePropertyList(ref reader, this, _nodes);
		}
		else
		{
			base.DeserializeProperty(jsonPropertyName, ref reader);
		}
	}

	internal Scene()
	{
		_nodes = new List<int>();
	}

	public Node CreateNode(string name = null)
	{
		Node node = base.LogicalParent._CreateVisualNode(_nodes);
		node.Name = name;
		return node;
	}

	internal bool _ContainsVisualNode(Node node, bool recursive)
	{
		Guard.NotNull(node, "node");
		Guard.MustShareLogicalParent(this, node, "node");
		if (_nodes.Contains(node.LogicalIndex))
		{
			return true;
		}
		if (!recursive)
		{
			return false;
		}
		return VisualChildren.Any((Node item) => item._ContainsVisualNode(node, recursive: true));
	}

	internal void _RemoveVisualNode(Node node)
	{
		Guard.NotNull(node, "node");
		Guard.MustShareLogicalParent(this, node, "node");
		_nodes.Remove(node.LogicalIndex);
	}

	internal void _UseVisualNode(Node node)
	{
		Guard.NotNull(node, "node");
		Guard.MustShareLogicalParent(this, node, "node");
		int logicalIndex = node.LogicalIndex;
		if (!_nodes.Contains(logicalIndex))
		{
			node._RemoveFromVisualParent();
			_nodes.Add(logicalIndex);
		}
	}

	protected override void OnValidateReferences(ValidationContext validate)
	{
		base.OnValidateReferences(validate);
		foreach (int node2 in _nodes)
		{
			validate.IsNullOrIndex("VisualChildren", node2, base.LogicalParent.LogicalNodes);
		}
		foreach (Node node in base.LogicalParent.LogicalNodes)
		{
			if (_nodes.Any((int ridx) => node._HasVisualChild(ridx)))
			{
				validate.GetContext(node)._LinkThrow("Children", "Root nodes cannot be children.");
			}
		}
	}
}
