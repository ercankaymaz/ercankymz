using System.Collections.Generic;
using System.Linq;

namespace SharpGLTF.Animations;

internal readonly struct FixedSampler<T> : ICurveSampler<T>, IConvertibleCurve<T>
{
	private readonly T _Value;

	public int MaxDegree => 0;

	public static ICurveSampler<T> Create(IEnumerable<(float Key, T Value)> sequence)
	{
		return new FixedSampler<T>(sequence.First().Value);
	}

	public static ICurveSampler<T> Create(IEnumerable<(float Key, (T, T, T) Value)> sequence)
	{
		return new FixedSampler<T>(sequence.First().Value.Item2);
	}

	public IConvertibleCurve<T> Clone()
	{
		return new FixedSampler<T>(_Value);
	}

	private FixedSampler(T value)
	{
		_Value = value;
	}

	public T GetPoint(float offset)
	{
		return _Value;
	}

	public IReadOnlyDictionary<float, T> ToStepCurve()
	{
		return new Dictionary<float, T> { [0f] = _Value };
	}

	public IReadOnlyDictionary<float, T> ToLinearCurve()
	{
		return new Dictionary<float, T> { [0f] = _Value };
	}

	public IReadOnlyDictionary<float, (T TangentIn, T Value, T TangentOut)> ToSplineCurve()
	{
		return new Dictionary<float, (T, T, T)> { [0f] = (default(T), _Value, default(T)) };
	}
}
