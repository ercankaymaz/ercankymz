using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using SharpGLTF.Collections;
using SharpGLTF.Diagnostics;
using SharpGLTF.IO;
using SharpGLTF.Reflection;
using SharpGLTF.Transforms;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
[DebuggerDisplay("{_DebuggerDisplay(),nq}")]
[DebuggerTypeProxy(typeof(_MeshDebugProxy))]
public sealed class Mesh : LogicalChildOfRoot
{
	public new const string SCHEMANAME = "mesh";

	private const int _primitivesMinItems = 1;

	private ChildrenList<MeshPrimitive, Mesh> _primitives;

	private const int _weightsMinItems = 1;

	private List<double> _weights;

	public IEnumerable<Node> VisualParents => Node.FindNodesUsingMesh(this);

	public IReadOnlyList<MeshPrimitive> Primitives => _primitives;

	public IReadOnlyList<float> MorphWeights => GetMorphWeights();

	public bool AllPrimitivesHaveJoints => Primitives.All((MeshPrimitive p) => p.GetVertexAccessor("JOINTS_0") != null);

	protected override string GetSchemaName()
	{
		return "mesh";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "primitives";
		yield return "weights";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		if (!(name == "primitives"))
		{
			if (name == "weights")
			{
				value = FieldInfo.From("weights", this, (Mesh instance) => instance._weights);
				return true;
			}
			return base.TryReflectField(name, out value);
		}
		value = FieldInfo.From("primitives", this, (Mesh instance) => instance._primitives);
		return true;
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "primitives", _primitives, 1);
		JsonSerializable.SerializeProperty(writer, "weights", _weights, 1);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		if (!(jsonPropertyName == "primitives"))
		{
			if (jsonPropertyName == "weights")
			{
				JsonSerializable.DeserializePropertyList(ref reader, this, _weights);
			}
			else
			{
				base.DeserializeProperty(jsonPropertyName, ref reader);
			}
		}
		else
		{
			JsonSerializable.DeserializePropertyList(ref reader, this, _primitives);
		}
	}

	private string _DebuggerDisplay()
	{
		string text = $"Mesh[{base.LogicalIndex}]";
		if (!string.IsNullOrWhiteSpace(base.Name))
		{
			text = text + " " + base.Name;
		}
		return text + $" Primitives[{Primitives.Count}]";
	}

	internal Mesh()
	{
		_primitives = new ChildrenList<MeshPrimitive, Mesh>(this);
		_weights = new List<double>();
	}

	public IReadOnlyList<float> GetMorphWeights()
	{
		if (_weights == null || _weights.Count == 0)
		{
			return Array.Empty<float>();
		}
		return _weights.Select((double item) => (float)item).ToList();
	}

	public void SetMorphWeights(IReadOnlyList<float> weights)
	{
		_weights.SetMorphWeights(weights);
	}

	public void SetMorphWeights(SparseWeight8 weights)
	{
		int maxCount = _primitives.Max((MeshPrimitive item) => item.MorphTargetsCount);
		_weights.SetMorphWeights(maxCount, weights);
	}

	public MeshPrimitive CreatePrimitive()
	{
		MeshPrimitive meshPrimitive = new MeshPrimitive();
		_primitives.Add(meshPrimitive);
		return meshPrimitive;
	}

	protected override void OnValidateReferences(ValidationContext validate)
	{
		validate.IsGreater("Primitives", Primitives.Count, 0).IsSetCollection("Primitives", _primitives);
		base.OnValidateReferences(validate);
	}

	protected override void OnValidateContent(ValidationContext validate)
	{
		int num = -1;
		foreach (MeshPrimitive primitive in Primitives)
		{
			if (num < 0)
			{
				num = primitive.MorphTargetsCount;
			}
			validate.GetContext(primitive).AreEqual("MorphTargets.Count", primitive.MorphTargetsCount, num);
		}
		if (_weights.Count > 0)
		{
			validate.AreEqual("Weights", num, _weights.Count);
		}
		base.OnValidateContent(validate);
	}
}
