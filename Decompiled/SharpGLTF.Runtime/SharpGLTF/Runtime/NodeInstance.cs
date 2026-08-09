using System;
using System.Diagnostics;
using System.Numerics;
using SharpGLTF.Transforms;

namespace SharpGLTF.Runtime;

[DebuggerDisplay("{Name}")]
public sealed class NodeInstance
{
	private readonly NodeTemplate _Template;

	private readonly NodeInstance _Parent;

	private Matrix4x4 _LocalMatrix;

	private Matrix4x4? _WorldMatrix;

	private SparseWeight8 _MorphWeights;

	public string Name => _Template.Name;

	public object Extras => _Template.Extras;

	public NodeInstance VisualParent => _Parent;

	public SparseWeight8 MorphWeights
	{
		get
		{
			return _MorphWeights;
		}
		set
		{
			_MorphWeights = value;
		}
	}

	public Matrix4x4 LocalMatrix
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _LocalMatrix;
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			_LocalMatrix = value;
			_WorldMatrix = null;
		}
	}

	public Matrix4x4 ModelMatrix
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _GetModelMatrix();
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			_SetModelMatrix(value);
		}
	}

	private bool TransformChainIsDirty
	{
		get
		{
			if (!_WorldMatrix.HasValue)
			{
				return true;
			}
			if (_Parent != null)
			{
				return _Parent.TransformChainIsDirty;
			}
			return false;
		}
	}

	internal NodeInstance(NodeTemplate template, NodeInstance parent)
	{
		_Template = template;
		_Parent = parent;
	}

	private Matrix4x4 _GetModelMatrix()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		if (!TransformChainIsDirty)
		{
			return _WorldMatrix.Value;
		}
		_WorldMatrix = ((_Parent == null) ? _LocalMatrix : Matrix4x4.Multiply(_LocalMatrix, _Parent.ModelMatrix));
		return _WorldMatrix.Value;
	}

	private void _SetModelMatrix(Matrix4x4 xform)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		if (_Parent == null)
		{
			LocalMatrix = xform;
			return;
		}
		Matrix4x4 val = default(Matrix4x4);
		Matrix4x4.Invert(_Parent._GetModelMatrix(), ref val);
		LocalMatrix = Matrix4x4.Multiply(xform, val);
	}

	public void SetPoseTransform()
	{
		SetAnimationFrame(-1, 0f);
	}

	public void SetAnimationFrame(int trackLogicalIndex, float time)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		MorphWeights = _Template.GetMorphWeights(trackLogicalIndex, time);
		LocalMatrix = _Template.GetLocalMatrix(trackLogicalIndex, time);
	}

	public void SetAnimationFrame(ReadOnlySpan<int> track, ReadOnlySpan<float> time, ReadOnlySpan<float> weight)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		MorphWeights = _Template.GetMorphWeights(track, time, weight);
		LocalMatrix = _Template.GetLocalMatrix(track, time, weight);
	}
}
