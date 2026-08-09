using System;
using System.Numerics;
using SharpGLTF.Schema2;
using SharpGLTF.Transforms;

namespace SharpGLTF.Runtime;

internal sealed class SkinnedDrawableTemplate : DrawableTemplate
{
	private readonly int _MorphNodeIndex;

	private readonly int[] _JointsNodeIndices;

	private readonly Matrix4x4[] _BindMatrices;

	internal SkinnedDrawableTemplate(Node node, Func<Node, int> indexFunc)
		: base(node)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		Skin skin = node.Skin;
		_MorphNodeIndex = indexFunc(node);
		_JointsNodeIndices = new int[skin.JointsCount];
		_BindMatrices = (Matrix4x4[])(object)new Matrix4x4[skin.JointsCount];
		for (int i = 0; i < _JointsNodeIndices.Length; i++)
		{
			var (arg, val) = skin.GetJoint(i);
			_JointsNodeIndices[i] = indexFunc(arg);
			_BindMatrices[i] = val;
		}
	}

	public override IGeometryTransform CreateGeometryTransform()
	{
		return new SkinnedTransform();
	}

	public override void UpdateGeometryTransform(IGeometryTransform skinnedTransform, ArmatureInstance armature)
	{
		SkinnedTransform skinnedTransform2 = (SkinnedTransform)skinnedTransform;
		skinnedTransform2.Update(_JointsNodeIndices.Length, (int idx) => _BindMatrices[idx], (int idx) => armature.LogicalNodes[_JointsNodeIndices[idx]].ModelMatrix);
		skinnedTransform2.Update(armature.LogicalNodes[_MorphNodeIndex].MorphWeights);
	}
}
