using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace SharpGLTF.Runtime;

public class ArmatureInstance
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly IReadOnlyList<NodeTemplate> _NodeTemplates;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly IReadOnlyList<NodeInstance> _NodeInstances;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly IReadOnlyList<MaterialTemplate> _MaterialTemplates;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly IReadOnlyList<AnimationTrackInfo> _AnimationTracks;

	public IReadOnlyList<NodeInstance> LogicalNodes => _NodeInstances;

	public IEnumerable<NodeInstance> VisualNodes => _NodeInstances.Where((NodeInstance item) => item.VisualParent == null);

	public IReadOnlyList<AnimationTrackInfo> AnimationTracks => _AnimationTracks;

	internal ArmatureInstance(ArmatureTemplate template)
	{
		_NodeTemplates = template.Nodes;
		NodeInstance[] array = new NodeInstance[_NodeTemplates.Count];
		for (int i = 0; i < array.Length; i++)
		{
			NodeTemplate nodeTemplate = _NodeTemplates[i];
			NodeInstance parent = ((nodeTemplate.ParentIndex < 0) ? null : array[nodeTemplate.ParentIndex]);
			array[i] = new NodeInstance(nodeTemplate, parent);
		}
		_NodeInstances = array;
		_MaterialTemplates = template.Materials;
		_AnimationTracks = template.Tracks;
	}

	public void SetLocalMatrix(string name, Matrix4x4 localMatrix)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		NodeInstance nodeInstance = LogicalNodes.FirstOrDefault((NodeInstance item) => item.Name == name);
		if (nodeInstance == null)
		{
			throw new ArgumentException(name + " not found", "name");
		}
		nodeInstance.LocalMatrix = localMatrix;
	}

	public void SetModelMatrix(string name, Matrix4x4 modelMatrix)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		NodeInstance nodeInstance = LogicalNodes.FirstOrDefault((NodeInstance item) => item.Name == name);
		if (nodeInstance == null)
		{
			throw new ArgumentException(name + " not found", "name");
		}
		nodeInstance.ModelMatrix = modelMatrix;
	}

	public void SetPoseTransforms()
	{
		foreach (NodeInstance nodeInstance in _NodeInstances)
		{
			nodeInstance.SetPoseTransform();
		}
	}

	public void SetAnimationFrame(int trackLogicalIndex, float time, bool looped = true)
	{
		if (looped)
		{
			float duration = AnimationTracks[trackLogicalIndex].Duration;
			if (duration > 0f)
			{
				time %= duration;
			}
		}
		foreach (NodeInstance nodeInstance in _NodeInstances)
		{
			nodeInstance.SetAnimationFrame(trackLogicalIndex, time);
		}
	}

	public void SetAnimationFrame(params (int TrackIdx, float Time, float Weight)[] blended)
	{
		SetAnimationFrame(_NodeInstances, blended);
	}

	public static void SetAnimationFrame(IEnumerable<NodeInstance> nodes, params (int TrackIdx, float Time, float Weight)[] blended)
	{
		SharpGLTF.Guard.NotNull(nodes, "nodes");
		SharpGLTF.Guard.NotNull(blended, "blended");
		Span<int> span = stackalloc int[blended.Length];
		Span<float> span2 = stackalloc float[blended.Length];
		Span<float> span3 = stackalloc float[blended.Length];
		float num = blended.Sum(((int TrackIdx, float Time, float Weight) item) => item.Weight);
		num = ((num == 0f) ? 1f : (1f / num));
		for (int num2 = 0; num2 < blended.Length; num2++)
		{
			span[num2] = blended[num2].TrackIdx;
			span2[num2] = blended[num2].Time;
			span3[num2] = blended[num2].Weight * num;
		}
		foreach (NodeInstance node in nodes)
		{
			node.SetAnimationFrame(span, span2, span3);
		}
	}
}
