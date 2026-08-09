using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SharpGLTF.Schema2;

namespace SharpGLTF.Animations;

public abstract class CurveBuilder<T> : ICurveSampler<T>, IConvertibleCurve<T> where T : struct
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SortedDictionary<float, _CurveNode<T>> _Keys = new SortedDictionary<float, _CurveNode<T>>();

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	internal IReadOnlyDictionary<float, _CurveNode<T>> _DebugKeys => _Keys;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public IReadOnlyCollection<float> Keys => _Keys.Keys;

	public int MaxDegree
	{
		get
		{
			if (_Keys.Count != 0)
			{
				return _Keys.Values.Max((_CurveNode<T> item) => item.Degree);
			}
			return 0;
		}
	}

	protected CurveBuilder()
	{
	}

	protected CurveBuilder(CurveBuilder<T> other)
	{
		if (other == null)
		{
			return;
		}
		foreach (KeyValuePair<float, _CurveNode<T>> key in other._Keys)
		{
			_Keys[key.Key] = key.Value.Clone(CloneValue);
		}
	}

	IConvertibleCurve<T> IConvertibleCurve<T>.Clone()
	{
		return Clone();
	}

	public abstract CurveBuilder<T> Clone();

	protected abstract bool AreEqual(T left, T right);

	protected abstract T CloneValue(T value);

	protected abstract T CreateValue(IReadOnlyList<float> values);

	public abstract T GetPoint(float offset);

	protected abstract T GetTangent(T fromValue, T toValue);

	public void Clear()
	{
		_Keys.Clear();
	}

	public void RemoveKey(float offset)
	{
		_Keys.Remove(offset);
	}

	public void SetPoint(float offset, bool isLinear, params float[] elements)
	{
		SetPoint(offset, CreateValue(elements), isLinear);
	}

	public void SetPoint(float offset, T value, bool isLinear = true)
	{
		value = CloneValue(value);
		if (_Keys.TryGetValue(offset, out var value2))
		{
			value2.Point = value;
		}
		else
		{
			value2 = new _CurveNode<T>(value, isLinear);
		}
		_Keys[offset] = value2;
	}

	public void SetIncomingTangent(float offset, T tangent)
	{
		SharpGLTF.Guard.IsTrue(_Keys.ContainsKey(offset), "offset");
		tangent = CloneValue(tangent);
		offset -= float.Epsilon;
		var (num, num2, _) = CurveSampler.FindRangeContainingOffset(_Keys.Keys, offset);
		if (num == num2)
		{
			_CurveNode<T> value = _Keys[num];
			value.Degree = 3;
			value.IncomingTangent = tangent;
			_Keys[num] = value;
			return;
		}
		_CurveNode<T> value2 = _Keys[num];
		_CurveNode<T> value3 = _Keys[num2];
		if (value2.Degree == 1)
		{
			value2.OutgoingTangent = GetTangent(value2.Point, value3.Point);
		}
		value2.Degree = 3;
		value3.IncomingTangent = tangent;
		_Keys[num] = value2;
		_Keys[num2] = value3;
	}

	public void SetOutgoingTangent(float offset, T tangent)
	{
		SharpGLTF.Guard.IsTrue(_Keys.ContainsKey(offset), "offset");
		tangent = CloneValue(tangent);
		var (num, num2, _) = CurveSampler.FindRangeContainingOffset(_Keys.Keys, offset);
		if (num == num2)
		{
			_CurveNode<T> value = _Keys[num];
			value.Degree = 3;
			value.OutgoingTangent = tangent;
			_Keys[num] = value;
			return;
		}
		_CurveNode<T> value2 = _Keys[num];
		_CurveNode<T> value3 = _Keys[num2];
		if (num != num2)
		{
			if (value2.Degree == 1)
			{
				value3.IncomingTangent = GetTangent(value2.Point, value3.Point);
			}
			_Keys[num2] = value3;
		}
		value2.Degree = 3;
		value2.OutgoingTangent = tangent;
		_Keys[num] = value2;
	}

	private protected (_CurveNode<T> A, _CurveNode<T> B, float Amount) FindSample(float offset)
	{
		if (_Keys.Count == 0)
		{
			return (A: default(_CurveNode<T>), B: default(_CurveNode<T>), Amount: 0f);
		}
		var (key, key2, item) = CurveSampler.FindRangeContainingOffset(_Keys.Keys, offset);
		return (A: _Keys[key], B: _Keys[key2], Amount: item);
	}

	public void SetCurve(ICurveSampler<T> curve)
	{
		if (curve is IConvertibleCurve<T> curve2)
		{
			SetCurve(curve2);
			return;
		}
		throw new NotImplementedException();
	}

	public void SetCurve(IConvertibleCurve<T> convertible)
	{
		SharpGLTF.Guard.NotNull(convertible, "convertible");
		if (convertible.MaxDegree == 0)
		{
			IReadOnlyDictionary<float, T> readOnlyDictionary = convertible.ToStepCurve();
			{
				foreach (KeyValuePair<float, T> item in readOnlyDictionary)
				{
					SetPoint(item.Key, item.Value, isLinear: false);
				}
				return;
			}
		}
		if (convertible.MaxDegree == 1)
		{
			IReadOnlyDictionary<float, T> readOnlyDictionary2 = convertible.ToLinearCurve();
			{
				foreach (KeyValuePair<float, T> item2 in readOnlyDictionary2)
				{
					SetPoint(item2.Key, item2.Value);
				}
				return;
			}
		}
		if (convertible.MaxDegree != 3)
		{
			return;
		}
		IReadOnlyDictionary<float, (T, T, T)> readOnlyDictionary3 = convertible.ToSplineCurve();
		foreach (KeyValuePair<float, (T, T, T)> item3 in readOnlyDictionary3)
		{
			SetPoint(item3.Key, item3.Value.Item2);
			SetIncomingTangent(item3.Key, item3.Value.Item1);
			SetOutgoingTangent(item3.Key, item3.Value.Item3);
		}
	}

	public void SetCurve(IAnimationSampler<T> curve)
	{
		SharpGLTF.Guard.NotNull(curve, "curve");
		switch (curve.InterpolationMode)
		{
		case AnimationInterpolationMode.LINEAR:
		case AnimationInterpolationMode.STEP:
		{
			bool isLinear = curve.InterpolationMode == AnimationInterpolationMode.LINEAR;
			{
				foreach (var (offset2, value) in curve.GetLinearKeys())
				{
					SetPoint(offset2, value, isLinear);
				}
				break;
			}
		}
		case AnimationInterpolationMode.CUBICSPLINE:
		{
			foreach (var (offset, tuple2) in curve.GetCubicKeys())
			{
				SetPoint(offset, tuple2.Item2);
				SetIncomingTangent(offset, tuple2.Item1);
				SetOutgoingTangent(offset, tuple2.Item3);
			}
			break;
		}
		default:
			throw new NotImplementedException();
		}
	}

	public CurveBuilder<T> WithPoint(float offset, T value, bool isLinear = true)
	{
		SetPoint(offset, value, isLinear);
		return this;
	}

	public CurveBuilder<T> WithIncomingTangent(float offset, T tangent)
	{
		SetIncomingTangent(offset, tangent);
		return this;
	}

	public CurveBuilder<T> WithOutgoingTangent(float offset, T tangent)
	{
		SetOutgoingTangent(offset, tangent);
		return this;
	}

	public CurveBuilder<T> WithPoint(float offset, params float[] values)
	{
		return WithPoint(offset, CreateValue(values));
	}

	public CurveBuilder<T> WithOutgoingTangent(float offset, params float[] values)
	{
		return WithOutgoingTangent(offset, CreateValue(values));
	}

	public CurveBuilder<T> WithIncomingTangent(float offset, params float[] values)
	{
		return WithIncomingTangent(offset, CreateValue(values));
	}

	IReadOnlyDictionary<float, T> IConvertibleCurve<T>.ToStepCurve()
	{
		if (MaxDegree != 0)
		{
			throw new NotSupportedException();
		}
		if (_Keys.Count == 0)
		{
			return new Dictionary<float, T>();
		}
		return _Keys.ToDictionary((KeyValuePair<float, _CurveNode<T>> item) => item.Key, (KeyValuePair<float, _CurveNode<T>> item) => CloneValue(item.Value.Point));
	}

	IReadOnlyDictionary<float, T> IConvertibleCurve<T>.ToLinearCurve()
	{
		if (_Keys.Count == 0)
		{
			return new Dictionary<float, T>();
		}
		if (_Keys.All((KeyValuePair<float, _CurveNode<T>> item) => item.Value.Degree == 1))
		{
			return _Keys.ToDictionary((KeyValuePair<float, _CurveNode<T>> item) => item.Key, (KeyValuePair<float, _CurveNode<T>> item) => CloneValue(item.Value.Point));
		}
		Dictionary<float, T> dictionary = new Dictionary<float, T>();
		if (_Keys.Count == 0)
		{
			return dictionary;
		}
		if (Keys.Count == 1)
		{
			KeyValuePair<float, _CurveNode<T>> keyValuePair = _Keys.First();
			dictionary[keyValuePair.Key] = keyValuePair.Value.Point;
			return dictionary;
		}
		List<float> list = _Keys.Keys.ToList();
		for (int num = 0; num < list.Count - 1; num++)
		{
			float num2 = list[num];
			float num3 = list[num + 1];
			_CurveNode<T> curveNode = _Keys[num2];
			_CurveNode<T> curveNode2 = _Keys[num3];
			switch (curveNode.Degree)
			{
			case 0:
				dictionary[num2] = curveNode.Point;
				dictionary[num3 - float.Epsilon] = curveNode.Point;
				dictionary[num3] = curveNode2.Point;
				break;
			case 1:
				dictionary[num2] = curveNode.Point;
				dictionary[num3] = curveNode2.Point;
				break;
			case 3:
			{
				for (float num4 = num2; num4 < num3; num4 += 1f / 30f)
				{
					dictionary[num4] = GetPoint(num4);
				}
				break;
			}
			default:
				throw new NotImplementedException();
			}
		}
		return dictionary;
	}

	IReadOnlyDictionary<float, (T TangentIn, T Value, T TangentOut)> IConvertibleCurve<T>.ToSplineCurve()
	{
		if (_Keys.Count == 0)
		{
			return new Dictionary<float, (T, T, T)>();
		}
		if (_Keys.All((KeyValuePair<float, _CurveNode<T>> item) => item.Value.Degree == 3))
		{
			return _Keys.ToDictionary((KeyValuePair<float, _CurveNode<T>> item) => item.Key, (KeyValuePair<float, _CurveNode<T>> item) => (IncomingTangent: item.Value.IncomingTangent, Point: item.Value.Point, OutgoingTangent: item.Value.OutgoingTangent));
		}
		Dictionary<float, (T, T, T)> dictionary = new Dictionary<float, (T, T, T)>();
		List<float> list = _Keys.Keys.ToList();
		for (int num = 0; num < list.Count - 1; num++)
		{
			float key = list[num];
			float num2 = list[num + 1];
			_CurveNode<T> curveNode = _Keys[key];
			_CurveNode<T> curveNode2 = _Keys[num2];
			if (!dictionary.TryGetValue(key, out var value))
			{
				value = default((T, T, T));
			}
			if (!dictionary.TryGetValue(num2, out var value2))
			{
				value2 = default((T, T, T));
			}
			value.Item2 = curveNode.Point;
			value2.Item2 = curveNode2.Point;
			T tangent = GetTangent(value.Item2, value2.Item2);
			switch (curveNode.Degree)
			{
			case 0:
				value.Item3 = default(T);
				dictionary[num2 - float.Epsilon] = (default(T), curveNode.Point, tangent);
				value2.Item1 = tangent;
				break;
			case 1:
				value.Item3 = (value2.Item1 = tangent);
				break;
			case 3:
				value.Item3 = curveNode.OutgoingTangent;
				value2.Item1 = curveNode2.IncomingTangent;
				break;
			default:
				throw new NotImplementedException();
			}
			dictionary[key] = value;
			dictionary[num2] = value2;
		}
		return dictionary;
	}
}
