using System;
using System.Collections.Generic;
using System.Linq;
using SharpGLTF.Schema2;

namespace SharpGLTF.Runtime;

public class SceneTemplate
{
	private readonly string _Name;

	private readonly object _Extras;

	private readonly ArmatureTemplate _Armature;

	private readonly DrawableTemplate[] _DrawableReferences;

	public string Name => _Name;

	public object Extras => _Extras;

	public IEnumerable<int> LogicalMeshIds => _DrawableReferences.Select((DrawableTemplate item) => item.LogicalMeshIndex).Distinct();

	public static SceneTemplate Create(Scene srcScene, RuntimeOptions options = null)
	{
		SharpGLTF.Guard.NotNull(srcScene, "srcScene");
		if (options == null)
		{
			options = new RuntimeOptions();
		}
		ArmatureTemplate armature = ArmatureTemplate.Create(srcScene, options);
		Dictionary<Node, int> srcNodes = Node.Flatten(srcScene).Select((Node key, int idx) => (key: key, idx: idx)).ToDictionary(((Node key, int idx) pair) => pair.key, ((Node key, int idx) pair) => pair.idx);
		List<Node> list = srcNodes.Keys.Where((Node item) => item.Mesh != null).ToList();
		List<DrawableTemplate> list2 = new List<DrawableTemplate>();
		for (int num = 0; num < list.Count; num++)
		{
			Node node = list[num];
			if (node.Skin != null)
			{
				list2.Add(new SkinnedDrawableTemplate(node, indexSolver));
				continue;
			}
			if (node.GetGpuInstancing() == null)
			{
				list2.Add(new RigidDrawableTemplate(node, indexSolver));
				continue;
			}
			switch (options.GpuMeshInstancing)
			{
			case MeshInstancing.Enabled:
				list2.Add(new InstancedDrawableTemplate(node, indexSolver));
				break;
			case MeshInstancing.SingleMesh:
				list2.Add(new RigidDrawableTemplate(node, indexSolver));
				break;
			default:
				throw new NotImplementedException();
			case MeshInstancing.Discard:
				break;
			}
		}
		object extras = RuntimeOptions.ConvertExtras(srcScene, options);
		return new SceneTemplate(srcScene.Name, extras, armature, list2.ToArray());
		int indexSolver(Node srcNode)
		{
			if (srcNode == null)
			{
				return -1;
			}
			return srcNodes[srcNode];
		}
	}

	private SceneTemplate(string name, object extras, ArmatureTemplate armature, DrawableTemplate[] drawables)
	{
		_Name = name;
		_Extras = extras;
		_Armature = armature;
		_DrawableReferences = drawables;
	}

	public SceneInstance CreateInstance()
	{
		SceneInstance sceneInstance = new SceneInstance(_Armature, _DrawableReferences);
		sceneInstance.Armature.SetPoseTransforms();
		return sceneInstance;
	}
}
