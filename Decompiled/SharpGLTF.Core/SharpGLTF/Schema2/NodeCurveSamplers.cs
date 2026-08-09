using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using SharpGLTF.Transforms;

namespace SharpGLTF.Schema2;

[DebuggerDisplay("{_GetDebuggerDisplay(),nq}")]
public readonly struct NodeCurveSamplers : IEquatable<NodeCurveSamplers>
{
	public readonly Node TargetNode;

	public readonly Animation Animation;

	private readonly AnimationSampler _ScaleSampler;

	private readonly AnimationSampler _RotationSampler;

	private readonly AnimationSampler _TranslationSampler;

	private readonly AnimationSampler _MorphSampler;

	public bool HasTransformCurves
	{
		get
		{
			if (_ScaleSampler == null && _RotationSampler == null)
			{
				return _TranslationSampler != null;
			}
			return true;
		}
	}

	public bool HasMorphingCurves => _MorphSampler != null;

	public IAnimationSampler<Vector3> Scale => _ScaleSampler;

	public IAnimationSampler<Quaternion> Rotation => _RotationSampler;

	public IAnimationSampler<Vector3> Translation => _TranslationSampler;

	[Obsolete("Use GetMorphingSampler<T>()", true)]
	public IAnimationSampler<float[]> Morphing => GetMorphingSampler<float[]>();

	[Obsolete("Use GetMorphingSampler<T>()", true)]
	public IAnimationSampler<SparseWeight8> MorphingSparse => GetMorphingSampler<SparseWeight8>();

	private string _GetDebuggerDisplay()
	{
		if (TargetNode == null || Animation == null)
		{
			return "Null";
		}
		string text = $"Node[{TargetNode.LogicalIndex}ᴵᵈˣ]";
		if (!string.IsNullOrWhiteSpace(TargetNode.Name))
		{
			text = text + " " + TargetNode.Name;
		}
		text += " <<< ";
		text += $"Animation[{Animation.LogicalIndex}ᴵᵈˣ]";
		if (!string.IsNullOrWhiteSpace(Animation.Name))
		{
			text = text + " " + Animation.Name;
		}
		return text;
	}

	internal NodeCurveSamplers(Node node, Animation animation)
	{
		TargetNode = node;
		Animation = animation;
		_ScaleSampler = null;
		_RotationSampler = null;
		_TranslationSampler = null;
		_MorphSampler = null;
		foreach (AnimationChannel item in animation.FindChannels(node))
		{
			switch (item.TargetNodePath)
			{
			case PropertyPath.scale:
				_ScaleSampler = item._GetSampler();
				break;
			case PropertyPath.rotation:
				_RotationSampler = item._GetSampler();
				break;
			case PropertyPath.translation:
				_TranslationSampler = item._GetSampler();
				break;
			case PropertyPath.weights:
				_MorphSampler = item._GetSampler();
				break;
			}
		}
	}

	public override int GetHashCode()
	{
		return TargetNode.GetHashCode() ^ Animation.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		return base.Equals(obj);
	}

	public static bool operator ==(in NodeCurveSamplers a, in NodeCurveSamplers b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(in NodeCurveSamplers a, in NodeCurveSamplers b)
	{
		return !a.Equals(b);
	}

	public bool Equals(NodeCurveSamplers other)
	{
		if (TargetNode != other.TargetNode)
		{
			return false;
		}
		if (Animation != other.Animation)
		{
			return false;
		}
		return true;
	}

	public IAnimationSampler<TWeights> GetMorphingSampler<TWeights>()
	{
		return _MorphSampler as IAnimationSampler<TWeights>;
	}

	public AffineTransform GetLocalTransform(float time)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		AffineTransform decomposed = TargetNode.LocalTransform.GetDecomposed();
		Vector3 scale = (Vector3)(((_003F?)Scale?.CreateCurveSampler()?.GetPoint(time)) ?? decomposed.Scale);
		Quaternion rotation = (Quaternion)(((_003F?)Rotation?.CreateCurveSampler()?.GetPoint(time)) ?? decomposed.Rotation);
		Vector3 translation = (Vector3)(((_003F?)Translation?.CreateCurveSampler()?.GetPoint(time)) ?? decomposed.Translation);
		return new AffineTransform(scale, rotation, translation);
	}

	public IReadOnlyList<float> GetMorphingWeights<TWeight>(float time)
	{
		IReadOnlyList<float> readOnlyList = GetMorphingSampler<float[]>()?.CreateCurveSampler()?.GetPoint(time);
		return readOnlyList ?? TargetNode.MorphWeights;
	}

	public SparseWeight8 GetSparseMorphingWeights(float time)
	{
		return GetMorphingSampler<SparseWeight8>()?.CreateCurveSampler()?.GetPoint(time) ?? SparseWeight8.Create(TargetNode.MorphWeights);
	}
}
