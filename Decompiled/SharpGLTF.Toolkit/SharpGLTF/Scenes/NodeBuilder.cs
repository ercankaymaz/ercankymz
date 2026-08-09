using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text.Json.Nodes;
using SharpGLTF.Animations;
using SharpGLTF.Transforms;

namespace SharpGLTF.Scenes;

[DebuggerDisplay("{_GetDebuggerDisplay(),nq}")]
public class NodeBuilder : BaseBuilder
{
	private NodeBuilder _Parent;

	private readonly List<NodeBuilder> _Children = new List<NodeBuilder>();

	private Matrix4x4? _Matrix;

	private AnimatableProperty<Vector3> _Scale;

	private AnimatableProperty<Quaternion> _Rotation;

	private AnimatableProperty<Vector3> _Translation;

	public NodeBuilder Parent => _Parent;

	public NodeBuilder Root
	{
		get
		{
			if (_Parent != null)
			{
				return _Parent.Root;
			}
			return this;
		}
	}

	public IReadOnlyList<NodeBuilder> VisualChildren => _Children;

	public IEnumerable<string> AnimationTracksNames
	{
		get
		{
			IEnumerable<string> enumerable = Enumerable.Empty<string>();
			if (_Scale != null)
			{
				enumerable = enumerable.Concat(_Scale.Tracks.Keys);
			}
			if (_Rotation != null)
			{
				enumerable = enumerable.Concat(_Rotation.Tracks.Keys);
			}
			if (_Translation != null)
			{
				enumerable = enumerable.Concat(_Translation.Tracks.Keys);
			}
			return enumerable.Distinct();
		}
	}

	public bool HasAnimations
	{
		get
		{
			AnimatableProperty<Vector3> scale = _Scale;
			if (scale == null || !scale.IsAnimated)
			{
				AnimatableProperty<Quaternion> rotation = _Rotation;
				if (rotation == null || !rotation.IsAnimated)
				{
					return _Translation?.IsAnimated ?? false;
				}
			}
			return true;
		}
	}

	public AnimatableProperty<Vector3> Scale => _Scale;

	public AnimatableProperty<Quaternion> Rotation => _Rotation;

	public AnimatableProperty<Vector3> Translation => _Translation;

	public Matrix4x4 LocalMatrix
	{
		get
		{
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			return LocalTransform.Matrix;
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			LocalTransform = value;
		}
	}

	public AffineTransform LocalTransform
	{
		get
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			return AffineTransform.CreateFromAny(_Matrix, _Scale?.Value, _Rotation?.Value, _Translation?.Value);
		}
		set
		{
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			SharpGLTF.Guard.IsTrue(value.IsValid, "value");
			if (HasAnimations)
			{
				value = value.GetDecomposed();
			}
			if (value.IsSRT)
			{
				_Matrix = null;
				if (_Scale != null || value.Scale != Vector3.One)
				{
					UseScale().Value = value.Scale;
				}
				if (_Rotation != null || value.Rotation != Quaternion.Identity)
				{
					UseRotation().Value = value.Rotation;
				}
				if (_Translation != null || value.Translation != Vector3.Zero)
				{
					UseTranslation().Value = value.Translation;
				}
			}
			else
			{
				_Matrix = value.Matrix;
				_Scale = null;
				_Rotation = null;
				_Translation = null;
			}
		}
	}

	public Matrix4x4 WorldMatrix
	{
		get
		{
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			NodeBuilder parent = Parent;
			if (parent != null)
			{
				return Matrix4x4Factory.LocalToWorld(parent.WorldMatrix, LocalMatrix);
			}
			return LocalMatrix;
		}
		set
		{
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			NodeBuilder parent = Parent;
			LocalMatrix = ((parent == null) ? value : Matrix4x4Factory.WorldToLocal(parent.WorldMatrix, in value));
		}
	}

	internal Matrix4x4Double LocalMatrixPrecise
	{
		get
		{
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			if (_Matrix.HasValue)
			{
				return new Matrix4x4Double(_Matrix.Value);
			}
			Vector3 val = _Scale?.Value ?? Vector3.One;
			Quaternion q = _Rotation?.Value ?? Quaternion.Identity;
			Vector3 val2 = _Translation?.Value ?? Vector3.Zero;
			return Matrix4x4Double.CreateScale(val.X, val.Y, val.Z) * Matrix4x4Double.CreateFromQuaternion(q.Sanitized()) * Matrix4x4Double.CreateTranslation(val2.X, val2.Y, val2.Z);
		}
	}

	internal Matrix4x4Double WorldMatrixPrecise
	{
		get
		{
			NodeBuilder parent = Parent;
			if (parent != null)
			{
				return LocalMatrixPrecise * parent.WorldMatrixPrecise;
			}
			return LocalMatrixPrecise;
		}
	}

	private string _GetDebuggerDisplay()
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		string text = "NodeBuilder";
		if (!string.IsNullOrWhiteSpace(base.Name))
		{
			text = text + " " + base.Name;
		}
		AffineTransform decomposed = LocalTransform.GetDecomposed();
		if (decomposed.Scale != Vector3.One)
		{
			text += $" \ud835\udc12:{decomposed.Scale}";
		}
		if (decomposed.Rotation != Quaternion.Identity)
		{
			text += $" \ud835\udc11:{decomposed.Rotation}";
		}
		if (decomposed.Translation != Vector3.Zero)
		{
			text += $" \ud835\udebb:{decomposed.Translation}";
		}
		if (VisualChildren.Any())
		{
			text += $" | Children[{VisualChildren.Count}]";
		}
		return text;
	}

	public NodeBuilder()
	{
	}

	public NodeBuilder(string name)
		: base(name)
	{
	}

	public NodeBuilder(string name, JsonNode extras)
		: base(name, extras)
	{
	}

	public Dictionary<NodeBuilder, NodeBuilder> DeepClone()
	{
		Dictionary<NodeBuilder, NodeBuilder> dictionary = new Dictionary<NodeBuilder, NodeBuilder>();
		DeepClone(dictionary);
		return dictionary;
	}

	private NodeBuilder DeepClone(IDictionary<NodeBuilder, NodeBuilder> nodeMap)
	{
		NodeBuilder nodeBuilder = new NodeBuilder();
		nodeBuilder.SetNameAndExtrasFrom(this);
		nodeMap[this] = nodeBuilder;
		nodeBuilder._Matrix = _Matrix;
		nodeBuilder._Scale = _Scale?.Clone();
		nodeBuilder._Rotation = _Rotation?.Clone();
		nodeBuilder._Translation = _Translation?.Clone();
		foreach (NodeBuilder child in _Children)
		{
			nodeBuilder.AddNode(child.DeepClone(nodeMap));
		}
		return nodeBuilder;
	}

	public NodeBuilder CreateNode(string name = null)
	{
		NodeBuilder nodeBuilder = new NodeBuilder();
		nodeBuilder.Name = name;
		AddNode(nodeBuilder);
		return nodeBuilder;
	}

	public void AddNode(NodeBuilder node)
	{
		SharpGLTF.Guard.NotNull(node, "node");
		SharpGLTF.Guard.IsFalse(this == node, "cannot add to itself");
		if (node._Parent != this)
		{
			SharpGLTF.Guard.MustBeNull(node._Parent, "node", "is child of another node.");
			node._Parent = this;
			_Children.Add(node);
		}
	}

	public static bool IsValidArmature(IEnumerable<NodeBuilder> joints)
	{
		if (joints == null)
		{
			return false;
		}
		joints = joints.EnsureList();
		if (!joints.Any())
		{
			return false;
		}
		if (joints.Any((NodeBuilder item) => item == null))
		{
			return false;
		}
		NodeBuilder root = joints.First().Root;
		if (!joints.All((NodeBuilder item) => item.Root == root))
		{
			return false;
		}
		IEnumerable<IGrouping<string, NodeBuilder>> source = from item in Flatten(root)
			where item.Name != null
			group item by item.Name;
		if (source.Any((IGrouping<string, NodeBuilder> group) => group.Count() > 1))
		{
			return false;
		}
		return true;
	}

	public static IEnumerable<NodeBuilder> Flatten(NodeBuilder container)
	{
		if (container == null)
		{
			yield break;
		}
		yield return container;
		foreach (NodeBuilder visualChild in container.VisualChildren)
		{
			IEnumerable<NodeBuilder> enumerable = Flatten(visualChild);
			foreach (NodeBuilder item in enumerable)
			{
				yield return item;
			}
		}
	}

	private void _UseDecomposedTransform()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		AffineTransform localTransform = LocalTransform;
		if (!localTransform.IsSRT)
		{
			localTransform = localTransform.GetDecomposed();
			_Matrix = null;
			UseScale().Value = localTransform.Scale;
			UseRotation().Value = localTransform.Rotation;
			UseTranslation().Value = localTransform.Translation;
		}
	}

	public AnimatableProperty<Vector3> UseScale()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		_UseDecomposedTransform();
		if (_Scale == null)
		{
			_Scale = new AnimatableProperty<Vector3>();
			_Scale.Value = Vector3.One;
		}
		return _Scale;
	}

	public CurveBuilder<Vector3> UseScale(string animationTrack)
	{
		return UseScale().UseTrackBuilder(animationTrack);
	}

	public AnimatableProperty<Quaternion> UseRotation()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		_UseDecomposedTransform();
		if (_Rotation == null)
		{
			_Rotation = new AnimatableProperty<Quaternion>();
			_Rotation.Value = Quaternion.Identity;
		}
		return _Rotation;
	}

	public CurveBuilder<Quaternion> UseRotation(string animationTrack)
	{
		return UseRotation().UseTrackBuilder(animationTrack);
	}

	public AnimatableProperty<Vector3> UseTranslation()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		_UseDecomposedTransform();
		if (_Translation == null)
		{
			_Translation = new AnimatableProperty<Vector3>();
			_Translation.Value = Vector3.Zero;
		}
		return _Translation;
	}

	public CurveBuilder<Vector3> UseTranslation(string animationTrack)
	{
		return UseTranslation().UseTrackBuilder(animationTrack);
	}

	public void SetScaleTrack(string track, ICurveSampler<Vector3> curve)
	{
		UseScale().SetTrack(track, curve);
	}

	public void SetTranslationTrack(string track, ICurveSampler<Vector3> curve)
	{
		UseTranslation().SetTrack(track, curve);
	}

	public void SetRotationTrack(string track, ICurveSampler<Quaternion> curve)
	{
		UseRotation().SetTrack(track, curve);
	}

	public AffineTransform GetLocalTransform(string animationTrack, float time)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		if (animationTrack == null)
		{
			return LocalTransform;
		}
		Vector3? scale = Scale?.GetValueAt(animationTrack, time);
		Quaternion? rotation = Rotation?.GetValueAt(animationTrack, time);
		Vector3? translation = Translation?.GetValueAt(animationTrack, time);
		return new AffineTransform(scale, rotation, translation);
	}

	public Matrix4x4 GetWorldMatrix(string animationTrack, float time)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		if (animationTrack == null)
		{
			return WorldMatrix;
		}
		NodeBuilder parent = Parent;
		Matrix4x4 childLocal = GetLocalTransform(animationTrack, time).Matrix;
		if (parent != null)
		{
			return Matrix4x4Factory.LocalToWorld(parent.GetWorldMatrix(animationTrack, time), in childLocal);
		}
		return childLocal;
	}

	public Matrix4x4 GetInverseBindMatrix(Matrix4x4? meshWorldMatrix = null)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		Matrix4x4Double meshWorldTransform = (Matrix4x4)(((_003F?)meshWorldMatrix) ?? Matrix4x4.Identity);
		return (Matrix4x4)SkinnedTransform.CalculateInverseBinding(meshWorldTransform, WorldMatrixPrecise);
	}

	public void SetLocalTransform(AffineTransform newLocalTransform, bool keepChildrenInPlace)
	{
		if (LocalTransform == newLocalTransform)
		{
			return;
		}
		AffineTransform b = LocalTransform;
		LocalTransform = newLocalTransform;
		if (!keepChildrenInPlace)
		{
			return;
		}
		AffineTransform.TryInvert(in newLocalTransform, out var inverse);
		for (int i = 0; i < VisualChildren.Count; i++)
		{
			NodeBuilder nodeBuilder = VisualChildren[i];
			AffineTransform a = nodeBuilder.LocalTransform;
			bool isSRT = a.IsSRT;
			a = a * b * inverse;
			if (a.IsSRT != isSRT)
			{
				throw new ArgumentException("child transform cannot be preserved due to uneven scale", "keepChildrenInPlace");
			}
			nodeBuilder.LocalTransform = a;
		}
	}

	public NodeBuilder WithLocalTranslation(Vector3 translation)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		UseTranslation().Value = translation;
		return this;
	}

	public NodeBuilder WithLocalScale(Vector3 scale)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		UseScale().Value = scale;
		return this;
	}

	public NodeBuilder WithLocalRotation(Quaternion rotation)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		UseRotation().Value = rotation;
		return this;
	}

	public NodeBuilder WithLocalTranslation(string animTrack, IReadOnlyDictionary<float, Vector3> keyframes)
	{
		SharpGLTF.Guard.NotNull(keyframes, "keyframes");
		IEnumerable<(float, Vector3)> collection = from item in keyframes
			orderby item.Key
			select (Key: item.Key, Value: item.Value);
		UseTranslation().SetTrack(animTrack, collection.CreateSampler());
		return this;
	}

	public NodeBuilder WithLocalRotation(string animTrack, IReadOnlyDictionary<float, Quaternion> keyframes)
	{
		SharpGLTF.Guard.NotNull(keyframes, "keyframes");
		IEnumerable<(float, Quaternion)> collection = from item in keyframes
			orderby item.Key
			select (Key: item.Key, Value: item.Value);
		UseRotation().SetTrack(animTrack, collection.CreateSampler());
		return this;
	}

	public NodeBuilder WithLocalScale(string animTrack, IReadOnlyDictionary<float, Vector3> keyframes)
	{
		SharpGLTF.Guard.NotNull(keyframes, "keyframes");
		IEnumerable<(float, Vector3)> collection = from item in keyframes
			orderby item.Key
			select (Key: item.Key, Value: item.Value);
		UseScale().SetTrack(animTrack, collection.CreateSampler());
		return this;
	}
}
