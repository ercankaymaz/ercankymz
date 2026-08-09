using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using SharpGLTF.Schema2;
using SharpGLTF.Transforms;

namespace SharpGLTF.Runtime;

[DebuggerDisplay("[{LogicalNodeIndex}] {Name}")]
internal class NodeTemplate
{
	private readonly int _LogicalSourceIndex;

	private readonly int _ParentIndex;

	private readonly int[] _ChildIndices;

	private readonly AffineTransform _LocalTransform;

	private readonly bool _UseAnimatedTransforms;

	private readonly AnimatableProperty<Vector3> _Scale;

	private readonly AnimatableProperty<Quaternion> _Rotation;

	private readonly AnimatableProperty<Vector3> _Translation;

	private readonly AnimatableProperty<SparseWeight8> _Morphing;

	public string Name { get; set; }

	public object Extras { get; set; }

	public int LogicalNodeIndex => _LogicalSourceIndex;

	public int ParentIndex => _ParentIndex;

	public IReadOnlyList<int> ChildIndices => _ChildIndices;

	public Matrix4x4 LocalMatrix => _LocalTransform.Matrix;

	internal NodeTemplate(Node srcNode, int parentIdx, int[] childIndices, RuntimeOptions options)
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		_LogicalSourceIndex = srcNode.LogicalIndex;
		_ParentIndex = parentIdx;
		_ChildIndices = childIndices;
		Name = srcNode.Name;
		Extras = RuntimeOptions.ConvertExtras(srcNode, options);
		_LocalTransform = srcNode.LocalTransform;
		if (_LocalTransform.TryDecompose(out var transform))
		{
			_Scale = new AnimatableProperty<Vector3>(transform.Scale);
			_Rotation = new AnimatableProperty<Quaternion>(transform.Rotation);
			_Translation = new AnimatableProperty<Vector3>(transform.Translation);
		}
		SparseWeight8 defval = SparseWeight8.Create(srcNode.MorphWeights);
		_Morphing = new AnimatableProperty<SparseWeight8>(defval);
		bool isolateMemory = options?.IsolateMemory ?? false;
		foreach (Animation logicalAnimation in srcNode.LogicalParent.LogicalAnimations)
		{
			int logicalIndex = logicalAnimation.LogicalIndex;
			NodeCurveSamplers curveSamplers = srcNode.GetCurveSamplers(logicalAnimation);
			_Scale.SetCurve(logicalIndex, curveSamplers.Scale?.CreateCurveSampler(isolateMemory));
			_Rotation.SetCurve(logicalIndex, curveSamplers.Rotation?.CreateCurveSampler(isolateMemory));
			_Translation.SetCurve(logicalIndex, curveSamplers.Translation?.CreateCurveSampler(isolateMemory));
			_Morphing.SetCurve(logicalIndex, curveSamplers.GetMorphingSampler<SparseWeight8>()?.CreateCurveSampler(isolateMemory));
		}
		_UseAnimatedTransforms = _Scale.IsAnimated | _Rotation.IsAnimated | _Translation.IsAnimated;
		if (!_UseAnimatedTransforms)
		{
			_Scale = null;
			_Rotation = null;
			_Translation = null;
		}
	}

	public SparseWeight8 GetMorphWeights(int trackLogicalIndex, float time)
	{
		if (trackLogicalIndex < 0)
		{
			return _Morphing.Value;
		}
		return _Morphing.GetValueAt(trackLogicalIndex, time);
	}

	public SparseWeight8 GetMorphWeights(ReadOnlySpan<int> track, ReadOnlySpan<float> time, ReadOnlySpan<float> weight)
	{
		if (!_Morphing.IsAnimated)
		{
			return _Morphing.Value;
		}
		Span<SparseWeight8> span = stackalloc SparseWeight8[track.Length];
		for (int i = 0; i < span.Length; i++)
		{
			span[i] = GetMorphWeights(track[i], time[i]);
		}
		return SparseWeight8.Blend(span, weight);
	}

	public AffineTransform GetLocalTransform(int trackLogicalIndex, float time)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		if (!_UseAnimatedTransforms || trackLogicalIndex < 0)
		{
			return _LocalTransform;
		}
		Vector3? scale = _Scale?.GetValueAt(trackLogicalIndex, time);
		Quaternion? rotation = _Rotation?.GetValueAt(trackLogicalIndex, time);
		Vector3? translation = _Translation?.GetValueAt(trackLogicalIndex, time);
		return new AffineTransform(scale, rotation, translation);
	}

	public AffineTransform GetLocalTransform(ReadOnlySpan<int> track, ReadOnlySpan<float> time, ReadOnlySpan<float> weight)
	{
		if (!_UseAnimatedTransforms)
		{
			return _LocalTransform;
		}
		Span<AffineTransform> span = stackalloc AffineTransform[track.Length];
		for (int i = 0; i < span.Length; i++)
		{
			span[i] = GetLocalTransform(track[i], time[i]);
		}
		return AffineTransform.Blend(span, weight);
	}

	public Matrix4x4 GetLocalMatrix(int trackLogicalIndex, float time)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		if (!_UseAnimatedTransforms || trackLogicalIndex < 0)
		{
			return _LocalTransform.Matrix;
		}
		return GetLocalTransform(trackLogicalIndex, time).Matrix;
	}

	public Matrix4x4 GetLocalMatrix(ReadOnlySpan<int> track, ReadOnlySpan<float> time, ReadOnlySpan<float> weight)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		if (!_UseAnimatedTransforms)
		{
			return _LocalTransform.Matrix;
		}
		return GetLocalTransform(track, time, weight).Matrix;
	}
}
