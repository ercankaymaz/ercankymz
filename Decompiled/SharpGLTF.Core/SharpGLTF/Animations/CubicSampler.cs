using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SharpGLTF.Animations;

internal readonly struct CubicSampler<T> : ICurveSampler<T>, IConvertibleCurve<T>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly ISamplerTraits<T> _Traits;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	private readonly IEnumerable<(float Key, (T TangentIn, T Value, T TangentOut))> _Sequence;

	public int MaxDegree => 3;

	public IConvertibleCurve<T> Clone()
	{
		ISamplerTraits<T> traits = _Traits;
		(float, (T, T, T))[] sequence = _Sequence.Select(((float Key, (T TangentIn, T Value, T TangentOut)) pair) => (Key: pair.Key, (traits.Clone(pair.Item2.TangentIn), traits.Clone(pair.Item2.Value), traits.Clone(pair.Item2.TangentOut)))).ToArray();
		return new CubicSampler<T>(sequence, traits);
	}

	public CubicSampler(IEnumerable<(float, (T, T, T))> sequence, ISamplerTraits<T> traits)
	{
		_Sequence = sequence;
		_Traits = traits;
	}

	public T GetPoint(float offset)
	{
		var (tuple2, tuple3, amount) = _Sequence.FindRangeContainingOffset(offset);
		return _Traits.InterpolateCubic(tuple2.Item2, tuple2.Item3, tuple3.Item2, tuple3.Item1, amount);
	}

	IReadOnlyDictionary<float, T> IConvertibleCurve<T>.ToStepCurve()
	{
		throw new NotSupportedException("This is a spline curve (MaxDegree = 3), use ToSplineCurve(); instead.");
	}

	IReadOnlyDictionary<float, T> IConvertibleCurve<T>.ToLinearCurve()
	{
		throw new NotSupportedException("This is a spline curve (MaxDegree = 3), use ToSplineCurve(); instead.");
	}

	IReadOnlyDictionary<float, (T TangentIn, T Value, T TangentOut)> IConvertibleCurve<T>.ToSplineCurve()
	{
		ISamplerTraits<T> traits = _Traits;
		return _Sequence.ToDictionary(((float Key, (T TangentIn, T Value, T TangentOut)) pair) => pair.Key, ((float Key, (T TangentIn, T Value, T TangentOut)) pair) => (traits.Clone(pair.Item2.TangentIn), traits.Clone(pair.Item2.Value), traits.Clone(pair.Item2.TangentOut)));
	}

	public ICurveSampler<T> ToFastSampler()
	{
		ISamplerTraits<T> traits = _Traits;
		return FastCurveSampler<T>.CreateFrom(_Sequence, ((float, (T TangentIn, T Value, T TangentOut))[] chunk) => new CubicSampler<T>(chunk, traits));
	}
}
