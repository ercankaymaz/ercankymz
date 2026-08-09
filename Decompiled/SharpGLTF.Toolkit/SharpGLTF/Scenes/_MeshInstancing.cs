using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Nodes;
using SharpGLTF.Schema2;
using SharpGLTF.Transforms;

namespace SharpGLTF.Scenes;

[DebuggerDisplay("_MeshInstancing Node[{_DebugName,nq}] = GpuMeshInstances[{_Children.Count}]")]
internal readonly struct _MeshInstancing : Schema2SceneBuilder.IOperator<Scene>
{
	private readonly NodeBuilder _ParentNode;

	private readonly IReadOnlyList<FixedTransformer> _Children;

	private readonly int _GpuMinCount;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _DebugName => _ParentNode?.Name ?? "*";

	public static IEnumerable<Schema2SceneBuilder.IOperator<Scene>> CreateFrom(IEnumerable<FixedTransformer> instances, int gpuMinCount)
	{
		List<FixedTransformer> renderables = instances.Where((FixedTransformer item) => item.HasRenderableContent).ToList();
		IEnumerable<IGrouping<IRenderableContent, FixedTransformer>> enumerable = from item in renderables
			where item.ParentNode == null
			group item by (IRenderableContent)item.Content;
		foreach (IGrouping<IRenderableContent, FixedTransformer> item in enumerable)
		{
			yield return new _MeshInstancing(null, item, gpuMinCount);
		}
		IEnumerable<IGrouping<NodeBuilder, FixedTransformer>> enumerable2 = from item in renderables
			where item.ParentNode != null
			group item by item.ParentNode;
		foreach (IGrouping<NodeBuilder, FixedTransformer> sameParent in enumerable2)
		{
			IEnumerable<IGrouping<IRenderableContent, FixedTransformer>> enumerable3 = from item in sameParent
				group item by (IRenderableContent)item.Content;
			foreach (IGrouping<IRenderableContent, FixedTransformer> item2 in enumerable3)
			{
				yield return new _MeshInstancing(sameParent.Key, item2, gpuMinCount);
			}
		}
	}

	private _MeshInstancing(NodeBuilder parentNode, IEnumerable<FixedTransformer> children, int gpuMinCount)
	{
		SharpGLTF.Guard.NotNull(children, "children");
		_ParentNode = parentNode;
		_Children = children.ToList();
		_GpuMinCount = gpuMinCount;
	}

	public void ApplyTo(Scene dstScene, Schema2SceneBuilder context)
	{
		if (_ParentNode == null)
		{
			_AddInstances(dstScene, context);
			return;
		}
		Node node = context.GetNode(_ParentNode);
		if (Schema2SceneBuilder.HasContent(node))
		{
			node = node.CreateNode();
		}
		_AddInstances(node, context);
	}

	private void _AddInstances(IVisualNodeContainer dst, Schema2SceneBuilder context)
	{
		if (_Children.Count < _GpuMinCount)
		{
			foreach (FixedTransformer child in _Children)
			{
				if (child.Content is Schema2SceneBuilder.IOperator<Node> obj)
				{
					Node node = dst.CreateNode();
					node.Name = child.Name;
					node.Extras = child.Extras?.DeepClone();
					node.LocalTransform = child.ChildTransform;
					obj.ApplyTo(node, context);
				}
			}
			return;
		}
		if (_Children[0].Content is Schema2SceneBuilder.IOperator<Node> obj2)
		{
			List<AffineTransform> transforms = _Children.Select((FixedTransformer item) => item.ChildTransform).ToList();
			List<JsonNode> list = _Children.Select((FixedTransformer item) => item.Extras).ToList();
			if (!list.All((JsonNode item) => item is JsonObject))
			{
				list = null;
			}
			Node node2 = dst as Node;
			if (node2 == null)
			{
				node2 = dst.CreateNode();
			}
			obj2.ApplyTo(node2, context);
			MeshGpuInstancing instancing = node2.UseGpuInstancing().WithInstanceAccessors(transforms);
			if (list != null)
			{
				instancing.WithInstanceCustomAccessors(list);
			}
		}
	}
}
