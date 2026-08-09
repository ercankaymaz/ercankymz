using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text.Json;
using SharpGLTF.Collections;
using SharpGLTF.IO;
using SharpGLTF.Reflection;
using SharpGLTF.Transforms;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
[DebuggerDisplay("Animation[{LogicalIndex}] {Name}")]
public sealed class Animation : LogicalChildOfRoot
{
	public new const string SCHEMANAME = "animation";

	private const int _channelsMinItems = 1;

	private ChildrenList<AnimationChannel, Animation> _channels;

	private const int _samplersMinItems = 1;

	private ChildrenList<AnimationSampler, Animation> _samplers;

	internal IReadOnlyList<AnimationSampler> _Samplers => _samplers;

	public IReadOnlyList<AnimationChannel> Channels => _channels;

	public float Duration => _samplers.Select((AnimationSampler item) => item.Duration).Max();

	protected override string GetSchemaName()
	{
		return "animation";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "channels";
		yield return "samplers";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		if (!(name == "channels"))
		{
			if (name == "samplers")
			{
				value = FieldInfo.From("samplers", this, (Animation instance) => instance._samplers);
				return true;
			}
			return base.TryReflectField(name, out value);
		}
		value = FieldInfo.From("channels", this, (Animation instance) => instance._channels);
		return true;
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "channels", _channels, 1);
		JsonSerializable.SerializeProperty(writer, "samplers", _samplers, 1);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		if (!(jsonPropertyName == "channels"))
		{
			if (jsonPropertyName == "samplers")
			{
				JsonSerializable.DeserializePropertyList(ref reader, this, _samplers);
			}
			else
			{
				base.DeserializeProperty(jsonPropertyName, ref reader);
			}
		}
		else
		{
			JsonSerializable.DeserializePropertyList(ref reader, this, _channels);
		}
	}

	internal Animation()
	{
		_channels = new ChildrenList<AnimationChannel, Animation>(this);
		_samplers = new ChildrenList<AnimationSampler, Animation>(this);
	}

	public IEnumerable<AnimationChannel> FindChannels(string rootPath)
	{
		if (string.IsNullOrWhiteSpace(rootPath))
		{
			throw new ArgumentNullException("rootPath");
		}
		if (rootPath[0] != '/')
		{
			throw new ArgumentException("invalid path: " + rootPath, "rootPath");
		}
		if (rootPath.EndsWith("/"))
		{
			return Channels.Where((AnimationChannel item) => item.TargetPointerPath.StartsWith(rootPath));
		}
		return Channels.Where((AnimationChannel item) => item.TargetPointerPath == rootPath);
	}

	public IEnumerable<AnimationChannel> FindChannels(Node node)
	{
		Guard.NotNull(node, "node");
		Guard.MustShareLogicalParent(this, node, "node");
		return Channels.Where((AnimationChannel item) => item.TargetNode == node);
	}

	public AnimationChannel FindScaleChannel(Node node)
	{
		return _FindChannel(node, PropertyPath.scale);
	}

	public AnimationChannel FindRotationChannel(Node node)
	{
		return _FindChannel(node, PropertyPath.rotation);
	}

	public AnimationChannel FindTranslationChannel(Node node)
	{
		return _FindChannel(node, PropertyPath.translation);
	}

	public AnimationChannel FindMorphChannel(Node node)
	{
		return _FindChannel(node, PropertyPath.weights);
	}

	private AnimationChannel _FindChannel(Node node, PropertyPath path)
	{
		return FindChannels(node).FirstOrDefault((AnimationChannel item) => item.TargetNodePath == path);
	}

	private AnimationSampler _CreateSampler(AnimationInterpolationMode interpolation)
	{
		AnimationSampler animationSampler = new AnimationSampler(interpolation);
		_samplers.Add(animationSampler);
		return animationSampler;
	}

	private AnimationChannel _UseChannel(Node node, PropertyPath path)
	{
		Guard.NotNull(node, "node");
		Guard.MustShareLogicalParent(this, node, "node");
		AnimationChannel animationChannel = _channels.FirstOrDefault((AnimationChannel item) => item.TargetNode == node && item.TargetNodePath == path);
		if (animationChannel != null)
		{
			return animationChannel;
		}
		animationChannel = new AnimationChannel(node, path);
		_channels.Add(animationChannel);
		return animationChannel;
	}

	private AnimationChannel _UseChannel(string pointerPath)
	{
		AnimationChannel animationChannel = new AnimationChannel(pointerPath);
		_channels.Add(animationChannel);
		return animationChannel;
	}

	public void CreateMaterialPropertyChannel<T>(Material material, string propertyName, IReadOnlyDictionary<float, T> keyframes, bool linear = true)
	{
		Guard.NotNull(material, "material");
		Guard.MustShareLogicalParent(this, material, "material");
		Guard.NotNullOrEmpty(propertyName, "propertyName");
		Guard.NotNullOrEmpty(keyframes, "keyframes");
		DangerousCreatePointerChannel($"/materials/{material.LogicalIndex}/{propertyName}", keyframes, linear);
	}

	public void DangerousCreatePointerChannel<T>(string pointerPath, IReadOnlyDictionary<float, T> keyframes, bool linear = true, bool verifyBackingFieldExists = true)
	{
		Guard.NotNullOrEmpty(keyframes, "keyframes");
		if (verifyBackingFieldExists)
		{
			FieldInfo.Verify(base.LogicalParent, pointerPath);
		}
		AnimationSampler animationSampler = _CreateSampler((!linear) ? AnimationInterpolationMode.STEP : AnimationInterpolationMode.LINEAR);
		if (!(keyframes is IReadOnlyDictionary<float, float> keys))
		{
			if (!(keyframes is IReadOnlyDictionary<float, Vector2> keys2))
			{
				if (!(keyframes is IReadOnlyDictionary<float, Vector3> keys3))
				{
					if (!(keyframes is IReadOnlyDictionary<float, Vector4> keys4))
					{
						if (!(keyframes is IReadOnlyDictionary<float, Quaternion> keys5))
						{
							throw new NotSupportedException(typeof(T).Name);
						}
						animationSampler.SetKeys(keys5);
					}
					else
					{
						animationSampler.SetKeys(keys4);
					}
				}
				else
				{
					animationSampler.SetKeys(keys3);
				}
			}
			else
			{
				animationSampler.SetKeys(keys2);
			}
		}
		else
		{
			animationSampler.SetKeys(keys);
		}
		_UseChannel(pointerPath).SetSampler(animationSampler);
	}

	public void CreateScaleChannel(Node node, IReadOnlyDictionary<float, Vector3> keyframes, bool linear = true)
	{
		Guard.NotNull(node, "node");
		Guard.MustShareLogicalParent(this, node, "node");
		Guard.NotNullOrEmpty(keyframes, "keyframes");
		AnimationSampler animationSampler = _CreateSampler((!linear) ? AnimationInterpolationMode.STEP : AnimationInterpolationMode.LINEAR);
		animationSampler.SetKeys(keyframes);
		_UseChannel(node, PropertyPath.scale).SetSampler(animationSampler);
	}

	public void CreateScaleChannel(Node node, IReadOnlyDictionary<float, (Vector3 TangentIn, Vector3 Value, Vector3 TangentOut)> keyframes)
	{
		Guard.NotNull(node, "node");
		Guard.MustShareLogicalParent(this, node, "node");
		Guard.NotNullOrEmpty(keyframes, "keyframes");
		AnimationSampler animationSampler = _CreateSampler(AnimationInterpolationMode.CUBICSPLINE);
		animationSampler.SetCubicKeys(keyframes);
		_UseChannel(node, PropertyPath.scale).SetSampler(animationSampler);
	}

	public void CreateRotationChannel(Node node, IReadOnlyDictionary<float, Quaternion> keyframes, bool linear = true)
	{
		Guard.NotNull(node, "node");
		Guard.MustShareLogicalParent(this, node, "node");
		Guard.NotNullOrEmpty(keyframes, "keyframes");
		AnimationSampler animationSampler = _CreateSampler((!linear) ? AnimationInterpolationMode.STEP : AnimationInterpolationMode.LINEAR);
		animationSampler.SetKeys(keyframes);
		_UseChannel(node, PropertyPath.rotation).SetSampler(animationSampler);
	}

	public void CreateRotationChannel(Node node, IReadOnlyDictionary<float, (Quaternion TangentIn, Quaternion Value, Quaternion TangentOut)> keyframes)
	{
		Guard.NotNull(node, "node");
		Guard.MustShareLogicalParent(this, node, "node");
		Guard.NotNullOrEmpty(keyframes, "keyframes");
		AnimationSampler animationSampler = _CreateSampler(AnimationInterpolationMode.CUBICSPLINE);
		animationSampler.SetCubicKeys(keyframes);
		_UseChannel(node, PropertyPath.rotation).SetSampler(animationSampler);
	}

	public void CreateTranslationChannel(Node node, IReadOnlyDictionary<float, Vector3> keyframes, bool linear = true)
	{
		Guard.NotNull(node, "node");
		Guard.MustShareLogicalParent(this, node, "node");
		Guard.NotNullOrEmpty(keyframes, "keyframes");
		AnimationSampler animationSampler = _CreateSampler((!linear) ? AnimationInterpolationMode.STEP : AnimationInterpolationMode.LINEAR);
		animationSampler.SetKeys(keyframes);
		_UseChannel(node, PropertyPath.translation).SetSampler(animationSampler);
	}

	public void CreateTranslationChannel(Node node, IReadOnlyDictionary<float, (Vector3 TangentIn, Vector3 Value, Vector3 TangentOut)> keyframes)
	{
		Guard.NotNull(node, "node");
		Guard.MustShareLogicalParent(this, node, "node");
		Guard.NotNullOrEmpty(keyframes, "keyframes");
		AnimationSampler animationSampler = _CreateSampler(AnimationInterpolationMode.CUBICSPLINE);
		animationSampler.SetCubicKeys(keyframes);
		_UseChannel(node, PropertyPath.translation).SetSampler(animationSampler);
	}

	public void CreateMorphChannel<TWeights>(Node node, IReadOnlyDictionary<float, TWeights> keyframes, int morphCount, bool linear = true) where TWeights : IReadOnlyList<float>
	{
		Guard.NotNull(node, "node");
		Guard.MustShareLogicalParent(this, node, "node");
		Guard.NotNullOrEmpty(keyframes, "keyframes");
		AnimationSampler animationSampler = _CreateSampler((!linear) ? AnimationInterpolationMode.STEP : AnimationInterpolationMode.LINEAR);
		animationSampler.SetKeys(keyframes, morphCount);
		_UseChannel(node, PropertyPath.weights).SetSampler(animationSampler);
	}

	public void CreateMorphChannel<TWeights>(Node node, IReadOnlyDictionary<float, (TWeights TangentIn, TWeights Value, TWeights TangentOut)> keyframes, int morphCount) where TWeights : IReadOnlyList<float>
	{
		Guard.NotNull(node, "node");
		Guard.MustShareLogicalParent(this, node, "node");
		Guard.NotNullOrEmpty(keyframes, "keyframes");
		AnimationSampler animationSampler = _CreateSampler(AnimationInterpolationMode.CUBICSPLINE);
		animationSampler.SetCubicKeys(keyframes, morphCount);
		_UseChannel(node, PropertyPath.weights).SetSampler(animationSampler);
	}

	public void CreateMorphChannel(Node node, IReadOnlyDictionary<float, SparseWeight8> keyframes, int morphCount, bool linear = true)
	{
		Guard.NotNull(node, "node");
		Guard.MustShareLogicalParent(this, node, "node");
		Guard.NotNullOrEmpty(keyframes, "keyframes");
		AnimationSampler animationSampler = _CreateSampler((!linear) ? AnimationInterpolationMode.STEP : AnimationInterpolationMode.LINEAR);
		animationSampler.SetKeys(keyframes, morphCount);
		_UseChannel(node, PropertyPath.weights).SetSampler(animationSampler);
	}

	public void CreateMorphChannel(Node node, IReadOnlyDictionary<float, (SparseWeight8 TangentIn, SparseWeight8 Value, SparseWeight8 TangentOut)> keyframes, int morphCount)
	{
		Guard.NotNull(node, "node");
		Guard.MustShareLogicalParent(this, node, "node");
		Guard.NotNullOrEmpty(keyframes, "keyframes");
		AnimationSampler animationSampler = _CreateSampler(AnimationInterpolationMode.CUBICSPLINE);
		animationSampler.SetCubicKeys(keyframes, morphCount);
		_UseChannel(node, PropertyPath.weights).SetSampler(animationSampler);
	}

	protected override void OnValidateReferences(ValidationContext validate)
	{
		validate.IsSetCollection("Samplers", _samplers).IsSetCollection("Channels", _channels);
		base.OnValidateReferences(validate);
	}

	protected override void OnValidateContent(ValidationContext validate)
	{
		base.OnValidateContent(validate);
	}
}
