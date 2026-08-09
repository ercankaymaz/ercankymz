using System;
using System.Collections.Generic;
using System.Numerics;

namespace SharpGLTF.Transforms;

public class InstancingTransform : RigidTransform, IGeometryInstancing
{
	private readonly Matrix4x4[] _LocalMatrices;

	private Lazy<RigidTransform[]> _WorldTransforms;

	public int InstancesCount => _LocalMatrices.Length;

	public IReadOnlyList<Matrix4x4> LocalMatrices => _LocalMatrices;

	public IReadOnlyList<RigidTransform> WorldTransforms => UpdateInstances();

	public InstancingTransform(AffineTransform[] instances)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		Guard.NotNull(instances, "instances");
		_LocalMatrices = (Matrix4x4[])(object)new Matrix4x4[instances.Length];
		for (int i = 0; i < _LocalMatrices.Length; i++)
		{
			_LocalMatrices[i] = instances[i].Matrix;
		}
		_WorldTransforms = new Lazy<RigidTransform[]>(_CreateTransforms);
	}

	private RigidTransform[] _CreateTransforms()
	{
		RigidTransform[] array = new RigidTransform[_LocalMatrices.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new RigidTransform();
		}
		return array;
	}

	public RigidTransform[] UpdateInstances()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		RigidTransform[] value = _WorldTransforms.Value;
		for (int i = 0; i < value.Length; i++)
		{
			Matrix4x4 matrix = AffineTransform.Multiply((AffineTransform)_LocalMatrices[i], (AffineTransform)base.WorldMatrix).Matrix;
			value[i].Update(matrix);
		}
		return value;
	}

	public static IEnumerable<IGeometryTransform> Evaluate(IGeometryTransform xform)
	{
		if (xform is IGeometryInstancing geometryInstancing)
		{
			foreach (RigidTransform worldTransform in geometryInstancing.WorldTransforms)
			{
				yield return worldTransform;
			}
		}
		else
		{
			yield return xform;
		}
	}
}
