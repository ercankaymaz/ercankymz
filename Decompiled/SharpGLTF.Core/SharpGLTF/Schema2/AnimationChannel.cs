using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text.Json;
using SharpGLTF.Collections;
using SharpGLTF.IO;
using SharpGLTF.Reflection;
using SharpGLTF.Transforms;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
[DebuggerDisplay("AnimChannel {TargetPointerPath}")]
public sealed class AnimationChannel : ExtraProperties, IChildOfList<Animation>
{
	public new const string SCHEMANAME = "channel";

	private int _sampler;

	private AnimationChannelTarget _target;

	public int LogicalIndex { get; private set; } = -1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Animation LogicalParent { get; private set; }

	public string TargetPointerPath => _target?.GetPointerPath() ?? null;

	public Node TargetNode
	{
		get
		{
			int num = _target?.GetNodeIndex() ?? (-1);
			if (num < 0)
			{
				return null;
			}
			return LogicalParent.LogicalParent.LogicalNodes[num];
		}
	}

	public PropertyPath TargetNodePath => _target?.GetNodePath() ?? PropertyPath.translation;

	protected override string GetSchemaName()
	{
		return "channel";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "sampler";
		yield return "target";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		if (!(name == "sampler"))
		{
			if (name == "target")
			{
				value = FieldInfo.From("target", this, (AnimationChannel instance) => instance._target);
				return true;
			}
			return base.TryReflectField(name, out value);
		}
		value = FieldInfo.From("sampler", this, (AnimationChannel instance) => instance._sampler);
		return true;
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "sampler", _sampler);
		JsonSerializable.SerializePropertyObject(writer, "target", _target);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		if (!(jsonPropertyName == "sampler"))
		{
			if (jsonPropertyName == "target")
			{
				JsonSerializable.DeserializePropertyValue<AnimationChannel, AnimationChannelTarget>(ref reader, this, out _target);
			}
			else
			{
				base.DeserializeProperty(jsonPropertyName, ref reader);
			}
		}
		else
		{
			JsonSerializable.DeserializePropertyValue<AnimationChannel, int>(ref reader, this, out _sampler);
		}
	}

	internal AnimationChannel()
	{
	}

	internal AnimationChannel(string pointerPath)
	{
		_SetChannelTarget(new AnimationChannelTarget(pointerPath));
		_sampler = -1;
	}

	internal AnimationChannel(Node targetNode, PropertyPath targetPath)
	{
		_SetChannelTarget(new AnimationChannelTarget(targetNode, targetPath));
		_sampler = -1;
	}

	internal void SetSampler(AnimationSampler sampler)
	{
		Guard.NotNull(sampler, "sampler");
		Guard.IsTrue(LogicalParent == sampler.LogicalParent, "sampler");
		_sampler = sampler.LogicalIndex;
	}

	void IChildOfList<Animation>.SetLogicalParent(Animation parent, int index)
	{
		LogicalParent = parent;
		LogicalIndex = index;
	}

	private void _SetChannelTarget(AnimationChannelTarget target)
	{
		new ChildSetter<AnimationChannel>(this).SetProperty(ref _target, target);
	}

	public IAnimationSampler<T> GetSamplerOrNull<T>()
	{
		return _GetSampler() as IAnimationSampler<T>;
	}

	internal AnimationSampler _GetSampler()
	{
		return LogicalParent._Samplers[_sampler];
	}

	public IAnimationSampler<Vector3> GetScaleSampler()
	{
		if (TargetNodePath != PropertyPath.scale)
		{
			return null;
		}
		return _GetSampler();
	}

	public IAnimationSampler<Quaternion> GetRotationSampler()
	{
		if (TargetNodePath != PropertyPath.rotation)
		{
			return null;
		}
		return _GetSampler();
	}

	public IAnimationSampler<Vector3> GetTranslationSampler()
	{
		if (TargetNodePath != PropertyPath.translation)
		{
			return null;
		}
		return _GetSampler();
	}

	public IAnimationSampler<SparseWeight8> GetSparseMorphSampler()
	{
		if (TargetNodePath != PropertyPath.weights)
		{
			return null;
		}
		return _GetSampler();
	}

	public IAnimationSampler<float[]> GetMorphSampler()
	{
		if (TargetNodePath != PropertyPath.weights)
		{
			return null;
		}
		return _GetSampler();
	}

	protected override void OnValidateReferences(ValidationContext validate)
	{
		base.OnValidateReferences(validate);
		validate.IsNullOrIndex("Sampler", _sampler, LogicalParent._Samplers);
	}
}
