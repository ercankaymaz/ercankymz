using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using SharpGLTF.IO;
using SharpGLTF.Memory;
using SharpGLTF.Schema2;
using SharpGLTF.Transforms;

namespace SharpGLTF.Validation;

[StructLayout(LayoutKind.Auto)]
[DebuggerDisplay("{_Current}")]
[DebuggerStepThrough]
public readonly struct ValidationContext
{
	private readonly ModelRoot _Root;

	private readonly ValidationMode _Mode;

	private readonly JsonSerializable _Current;

	public ModelRoot Root => _Root;

	public bool TryFix => _Mode == ValidationMode.TryFix;

	public ValidationContext(ValidationResult result)
	{
		Guard.NotNull(result, "result");
		_Root = result.Root;
		_Mode = result.Mode;
		_Current = null;
	}

	internal ValidationContext(ValidationContext context, JsonSerializable target)
	{
		_Root = context._Root;
		_Mode = context._Mode;
		_Current = target;
	}

	public ValidationContext GetContext(JsonSerializable target)
	{
		return new ValidationContext(this, target);
	}

	[DebuggerStepThrough]
	internal void _SchemaThrow(ValueLocation pname, string msg)
	{
		throw new SchemaException(_Current, $"{pname}: {msg}");
	}

	public ValidationContext IsTrue(ValueLocation parameterName, bool value, string msg)
	{
		if (!value)
		{
			_SchemaThrow(parameterName, msg);
		}
		return this;
	}

	public ValidationContext NotNull(ValueLocation parameterName, object target)
	{
		if (target == null)
		{
			_SchemaThrow(parameterName, "must not be null.");
		}
		return this;
	}

	public ValidationContext MustBeNull(ValueLocation parameterName, object target)
	{
		if (target != null)
		{
			_SchemaThrow(parameterName, "must be null.");
		}
		return this;
	}

	public ValidationContext IsDefined<T>(ValueLocation parameterName, T value) where T : class
	{
		if (value == null)
		{
			_SchemaThrow(parameterName, "must be defined.");
		}
		return this;
	}

	public ValidationContext IsDefined<T>(ValueLocation parameterName, T? value) where T : struct
	{
		if (!value.HasValue)
		{
			_SchemaThrow(parameterName, "must be defined.");
		}
		return this;
	}

	public ValidationContext IsUndefined<T>(ValueLocation parameterName, T value) where T : class
	{
		if (value != null)
		{
			_SchemaThrow(parameterName, "must NOT be defined.");
		}
		return this;
	}

	public ValidationContext IsUndefined<T>(ValueLocation parameterName, T? value) where T : struct
	{
		if (value.HasValue)
		{
			_SchemaThrow(parameterName, "must NOT be defined.");
		}
		return this;
	}

	public ValidationContext AreSameReference<TRef>(ValueLocation parameterName, TRef value, TRef expected) where TRef : class
	{
		if (value != expected)
		{
			_SchemaThrow(parameterName, $"{value} and {expected} must be the same.");
		}
		return this;
	}

	public ValidationContext AreEqual<TValue>(ValueLocation parameterName, TValue value, TValue expected) where TValue : IEquatable<TValue>
	{
		if (!value.Equals(expected))
		{
			_SchemaThrow(parameterName, $"{value} must be equal to {expected}.");
		}
		return this;
	}

	public ValidationContext IsLess<TValue>(ValueLocation parameterName, TValue value, TValue max) where TValue : IComparable<TValue>
	{
		if (value.CompareTo(max) >= 0)
		{
			_SchemaThrow(parameterName, $"{value} must be less than {max}.");
		}
		return this;
	}

	public ValidationContext IsLessOrEqual<TValue>(ValueLocation parameterName, TValue value, TValue max) where TValue : IComparable<TValue>
	{
		if (value.CompareTo(max) > 0)
		{
			_SchemaThrow(parameterName, $"{value} must be less or equal to {max}.");
		}
		return this;
	}

	public ValidationContext IsGreater<TValue>(ValueLocation parameterName, TValue value, TValue min) where TValue : IComparable<TValue>
	{
		if (value.CompareTo(min) <= 0)
		{
			_SchemaThrow(parameterName, $"{value} must be greater than {min}.");
		}
		return this;
	}

	public ValidationContext IsDefaultOrWithin<TValue>(ValueLocation parameterName, TValue? value, TValue minInclusive, TValue maxInclusive) where TValue : unmanaged, IComparable<TValue>
	{
		if (!value.HasValue)
		{
			return this;
		}
		if (value.Value.CompareTo(minInclusive) < 0)
		{
			_SchemaThrow(parameterName, $"{value} must be greater or equal to {minInclusive}.");
		}
		if (value.Value.CompareTo(maxInclusive) > 0)
		{
			_SchemaThrow(parameterName, $"{value} must be less or equal to {maxInclusive}.");
		}
		return this;
	}

	public ValidationContext IsGreaterOrEqual<TValue>(ValueLocation parameterName, TValue value, TValue min) where TValue : IComparable<TValue>
	{
		if (value.CompareTo(min) < 0)
		{
			_SchemaThrow(parameterName, $"{value} must be greater or equal to {min}.");
		}
		return this;
	}

	public ValidationContext IsMultipleOf(ValueLocation parameterName, int value, int multiple)
	{
		if (value % multiple != 0)
		{
			_SchemaThrow(parameterName, $"Value {value} is not a multiple of {multiple}.");
		}
		return this;
	}

	public ValidationContext NonNegative(ValueLocation parameterName, int? value)
	{
		if (value.GetValueOrDefault() < 0)
		{
			_SchemaThrow(parameterName, "must be a non-negative integer.");
		}
		return this;
	}

	public ValidationContext IsNullOrValidURI(ValueLocation parameterName, string gltfURI, params string[] validHeaders)
	{
		if (gltfURI == null)
		{
			return this;
		}
		return IsValidURI(parameterName, gltfURI, validHeaders);
	}

	public ValidationContext IsValidURI(ValueLocation parameterName, string gltfURI, params string[] validHeaders)
	{
		Guard.NotNull(validHeaders, "validHeaders");
		try
		{
			Guard.IsValidURI(parameterName, gltfURI, validHeaders);
			return this;
		}
		catch (ArgumentException ex)
		{
			_SchemaThrow(parameterName, ex.Message);
		}
		return this;
	}

	[DebuggerStepThrough]
	internal void _LinkThrow(ValueLocation pname, string msg)
	{
		throw new LinkException(_Current, $"{pname}: {msg}");
	}

	public ValidationContext EnumsAreEqual<TValue>(ValueLocation parameterName, TValue value, TValue expected) where TValue : Enum
	{
		if (!value.Equals(expected))
		{
			_LinkThrow(parameterName, $"{value} must be equal to {expected}.");
		}
		return this;
	}

	public ValidationContext IsNullOrIndex<T>(ValueLocation parameterName, int? index, IReadOnlyList<T> array)
	{
		return IsNullOrInRange(parameterName, index, 1, array);
	}

	public ValidationContext IsNullOrInRange<T>(ValueLocation parameterName, int? offset, int length, IReadOnlyList<T> array)
	{
		if (!offset.HasValue)
		{
			return this;
		}
		NonNegative($"{parameterName}.offset", offset.Value);
		IsGreater($"{parameterName}.length", length, 0);
		if (array == null)
		{
			_LinkThrow(parameterName, $".{offset} exceeds the number of available items (null).");
			return this;
		}
		if (offset > array.Count - length)
		{
			if (length == 1)
			{
				_LinkThrow(parameterName, $".{offset} exceeds the number of available items ({array.Count}).");
			}
			else
			{
				_LinkThrow(parameterName, $".{offset}+{length} exceeds the number of available items ({array.Count}).");
			}
		}
		return this;
	}

	public ValidationContext IsAnyOf<T>(ValueLocation parameterName, T value, params T[] values)
	{
		string separator = " ";
		if (!Enumerable.Contains(values, value))
		{
			_LinkThrow(parameterName, $"value {value} is not one of [{string.Join(separator, values)}].");
		}
		return this;
	}

	public ValidationContext IsAnyOf(ValueLocation parameterName, AttributeFormat value, params AttributeFormat[] values)
	{
		string separator = " ";
		if (!Enumerable.Contains(values, value))
		{
			_LinkThrow(parameterName, "value " + value._GetDebuggerDisplay() + " is not one of [" + string.Join(separator, values.Select((AttributeFormat item) => item._GetDebuggerDisplay())) + "].");
		}
		return this;
	}

	public ValidationContext IsSetCollection<T>(ValueLocation parameterName, IEnumerable<T> collection) where T : class
	{
		int num = 0;
		if (collection == null)
		{
			_LinkThrow(parameterName, "must not be null.");
			return this;
		}
		HashSet<T> hashSet = new HashSet<T>();
		foreach (T item in collection)
		{
			if (item == null)
			{
				_LinkThrow((name: parameterName, index: num), "Is NULL.");
			}
			if (hashSet.Contains(item))
			{
				_LinkThrow((name: parameterName, index: num), "Is duplicated.");
			}
			hashSet.Add(item);
			num++;
		}
		return this;
	}

	[DebuggerStepThrough]
	private void _DataThrow(ValueLocation pname, string msg)
	{
		throw new DataException(_Current, $"{pname}: {msg}");
	}

	public ValidationContext IsInRange<T>(ValueLocation pname, T value, T minInclusive, T maxInclusive) where T : IComparable<T>
	{
		if (value.CompareTo(minInclusive) == -1)
		{
			_DataThrow(pname, $"is below minimum {minInclusive} value: {value}");
		}
		if (value.CompareTo(maxInclusive) == 1)
		{
			_DataThrow(pname, $"is above maximum {maxInclusive} value: {value}");
		}
		return this;
	}

	public ValidationContext IsNullOrMatrix(ValueLocation pname, Matrix4x4? matrix, bool mustInvert = true, bool mustDecompose = true)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		if (!matrix.HasValue)
		{
			return this;
		}
		return IsMatrix(pname, matrix.Value, mustInvert, mustDecompose);
	}

	public ValidationContext IsNullOrMatrix4x3(ValueLocation pname, Matrix4x4? matrix, bool mustInvert = true, bool mustDecompose = true)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		if (!matrix.HasValue)
		{
			return this;
		}
		return IsMatrix4x3(pname, matrix.Value, mustInvert, mustDecompose);
	}

	public ValidationContext IsPosition(ValueLocation pname, in Vector3 position)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		if (!position._IsFinite())
		{
			_DataThrow(pname, "Invalid Position");
		}
		return this;
	}

	public ValidationContext IsNormal(ValueLocation pname, in Vector3 normal)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		if (!normal.IsNormalized())
		{
			_DataThrow(pname, "Invalid Normal");
		}
		return this;
	}

	public ValidationContext IsRotation(ValueLocation pname, in Quaternion rotation)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		if (!rotation.IsNormalized())
		{
			_DataThrow(pname, "Invalid Rotation");
		}
		return this;
	}

	public ValidationContext IsMatrix(ValueLocation pname, in Matrix4x4 matrix, bool mustInvert = true, bool mustDecompose = true)
	{
		Matrix4x4Factory.MatrixCheck matrixCheck = Matrix4x4Factory.MatrixCheck.NonZero;
		if (mustInvert)
		{
			matrixCheck |= Matrix4x4Factory.MatrixCheck.Invertible;
		}
		if (mustDecompose)
		{
			matrixCheck |= Matrix4x4Factory.MatrixCheck.Decomposable;
		}
		if (!matrix.IsValid(matrixCheck))
		{
			_DataThrow(pname, "Invalid Matrix");
		}
		return this;
	}

	public ValidationContext IsMatrix4x3(ValueLocation pname, in Matrix4x4 matrix, bool mustInvert = true, bool mustDecompose = true)
	{
		Matrix4x4Factory.MatrixCheck matrixCheck = Matrix4x4Factory.MatrixCheck.IdentityColumn4;
		if (mustInvert)
		{
			matrixCheck |= Matrix4x4Factory.MatrixCheck.Invertible;
		}
		if (mustDecompose)
		{
			matrixCheck |= Matrix4x4Factory.MatrixCheck.Decomposable;
		}
		if (!matrix.IsValid(matrixCheck))
		{
			_DataThrow(pname, "Invalid Matrix");
		}
		return this;
	}

	public ValidationContext ArePositions(ValueLocation pname, IReadOnlyList<Vector3> positions)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		Guard.NotNull(positions, "positions");
		for (int i = 0; i < positions.Count; i++)
		{
			IsPosition((name: pname, index: i), positions[i]);
		}
		return this;
	}

	public ValidationContext AreNormals(ValueLocation pname, IReadOnlyList<Vector3> normals)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		Guard.NotNull(normals, "normals");
		for (int i = 0; i < normals.Count; i++)
		{
			IsNormal((name: pname, index: i), normals[i]);
		}
		return this;
	}

	public ValidationContext AreTangents(ValueLocation pname, IReadOnlyList<Vector4> tangents)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		Guard.NotNull(tangents, "tangents");
		for (int i = 0; i < tangents.Count; i++)
		{
			if (!tangents[i].IsValidTangent())
			{
				_DataThrow((name: pname, index: i), "Invalid Tangent");
			}
		}
		return this;
	}

	public ValidationContext AreRotations(ValueLocation pname, IReadOnlyList<Quaternion> rotations)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		Guard.NotNull(rotations, "rotations");
		for (int i = 0; i < rotations.Count; i++)
		{
			if (!rotations[i].IsNormalized())
			{
				_DataThrow((name: pname, index: i), "Invalid Rotation");
			}
		}
		return this;
	}

	public ValidationContext AreJoints(ValueLocation pname, IReadOnlyList<Vector4> joints, int skinsMaxJointCount)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		Guard.NotNull(joints, "joints");
		for (int i = 0; i < joints.Count; i++)
		{
			Vector4 v = joints[i];
			if (!v._IsFinite())
			{
				_DataThrow((name: pname, index: i), "Is not finite");
			}
			if (v.X < 0f || v.X >= (float)skinsMaxJointCount)
			{
				_DataThrow((name: pname, index: i), "Is out of bounds");
			}
			if (v.Y < 0f || v.Y >= (float)skinsMaxJointCount)
			{
				_DataThrow((name: pname, index: i), "Is out of bounds");
			}
			if (v.Z < 0f || v.Z >= (float)skinsMaxJointCount)
			{
				_DataThrow((name: pname, index: i), "Is out of bounds");
			}
			if (v.W < 0f || v.W >= (float)skinsMaxJointCount)
			{
				_DataThrow((name: pname, index: i), "Is out of bounds");
			}
		}
		return this;
	}

	public ValidationContext That(Action action)
	{
		Guard.NotNull(action, "action");
		try
		{
			action();
		}
		catch (ArgumentException ex)
		{
			_DataThrow(ex.ParamName, ex.Message);
		}
		return this;
	}

	public ValidationContext That(bool result, string paramName, string msg)
	{
		if (!result)
		{
			_DataThrow(paramName, msg);
		}
		return this;
	}
}
