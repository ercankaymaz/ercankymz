using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SharpGLTF.Schema2;

namespace SharpGLTF.Runtime;

internal class ArmatureTemplate
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly NodeTemplate[] _NodeTemplates;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly MaterialTemplate[] _MaterialTemplates;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly AnimationTrackInfo[] _AnimationTracks;

	public IReadOnlyList<NodeTemplate> Nodes => _NodeTemplates;

	public IReadOnlyList<MaterialTemplate> Materials => _MaterialTemplates;

	public IReadOnlyList<AnimationTrackInfo> Tracks => _AnimationTracks;

	internal static ArmatureTemplate Create(Scene srcScene, RuntimeOptions options)
	{
		SharpGLTF.Guard.NotNull(srcScene, "srcScene");
		Dictionary<Node, int> srcNodes = Node.Flatten(srcScene).Select((Node key, int idx) => (key: key, idx: idx)).ToDictionary(((Node key, int idx) pair) => pair.key, ((Node key, int idx) pair) => pair.idx);
		NodeTemplate[] array = new NodeTemplate[srcNodes.Count];
		foreach (KeyValuePair<Node, int> item in srcNodes)
		{
			int value = item.Value;
			int parentIdx = indexSolver(item.Key.VisualParent);
			int[] childIndices = item.Key.VisualChildren.Select((Node n) => indexSolver(n)).ToArray();
			array[value] = new NodeTemplate(item.Key, parentIdx, childIndices, options);
		}
		MaterialTemplate[] materials = (from prim in (from item in srcNodes.Keys
				select item.Mesh into item
				where item != null
				select item).SelectMany((Mesh mesh) => mesh.Primitives)
			select prim.Material into mat
			where mat != null
			select new MaterialTemplate(mat, options)).ToArray();
		AnimationTrackInfo[] animTracks = srcScene.LogicalParent.LogicalAnimations.Select((Animation item) => new AnimationTrackInfo(item.Name, RuntimeOptions.ConvertExtras(item, options), item.Duration)).ToArray();
		return new ArmatureTemplate(array, materials, animTracks);
		int indexSolver(Node srcNode)
		{
			if (srcNode == null)
			{
				return -1;
			}
			return srcNodes[srcNode];
		}
	}

	private ArmatureTemplate(NodeTemplate[] nodes, MaterialTemplate[] materials, AnimationTrackInfo[] animTracks)
	{
		for (int i = 0; i < nodes.Length; i++)
		{
			NodeTemplate nodeTemplate = nodes[i];
			if (nodeTemplate == null)
			{
				throw new ArgumentNullException("nodes");
			}
			if (nodeTemplate.ParentIndex >= i)
			{
				throw new ArgumentOutOfRangeException("nodes", $"[{i}].ParentIndex must be lower than {i}, but found {nodeTemplate.ParentIndex}");
			}
			for (int j = 0; j < nodeTemplate.ChildIndices.Count; j++)
			{
				int num = nodeTemplate.ChildIndices[j];
				if (num >= nodes.Length)
				{
					throw new ArgumentOutOfRangeException("nodes", $"[{i}].ChildIndices[{j}] must be lower than {nodes.Length}, but found {num}");
				}
				if (num <= i)
				{
					throw new ArgumentOutOfRangeException("nodes", $"[{i}].ChildIndices[{j}] must be heigher than {i}, but found {num}");
				}
			}
		}
		_NodeTemplates = nodes;
		_MaterialTemplates = materials;
		_AnimationTracks = animTracks;
	}
}
