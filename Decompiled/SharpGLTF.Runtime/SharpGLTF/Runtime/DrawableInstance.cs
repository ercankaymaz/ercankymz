using System.Diagnostics;
using SharpGLTF.Transforms;

namespace SharpGLTF.Runtime;

[DebuggerDisplay("{_ToDebuggerDisplayString(),nq}")]
public readonly struct DrawableInstance
{
	public readonly IDrawableTemplate Template;

	public readonly IGeometryTransform Transform;

	public int InstanceCount
	{
		get
		{
			if (!(Transform is IGeometryInstancing geometryInstancing))
			{
				return 1;
			}
			return geometryInstancing.InstancesCount;
		}
	}

	private string _ToDebuggerDisplayString()
	{
		if (Template == null || Transform == null)
		{
			return "⚠ Empty";
		}
		string text = string.Empty;
		if (Transform.Visible)
		{
			text += "\ud83d\udc41 ";
		}
		text += "[";
		if (Template.NodeName != null)
		{
			text = text + Template.NodeName + " ";
		}
		text += Template.LogicalMeshIndex;
		text += "] ";
		if (Transform is RigidTransform)
		{
			text += "Rigid";
		}
		if (Transform is SkinnedTransform skinnedTransform)
		{
			text += $"Skinned \ud83e\uddb4={skinnedTransform.SkinMatrices.Count}";
		}
		if (Transform is InstancingTransform instancingTransform)
		{
			text += $"Instanced \ud83c\udfe0={instancingTransform.LocalMatrices.Count}";
		}
		return text;
	}

	internal DrawableInstance(IDrawableTemplate t, IGeometryTransform xform)
	{
		Template = t;
		Transform = xform;
	}
}
