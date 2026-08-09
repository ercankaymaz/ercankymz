using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SharpGLTF.Animations;

internal readonly struct StepSampler<T> : ICurveSampler<T>, IConvertibleCurve<T>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly ISamplerTraits<T> _Traits;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	private readonly IEnumerable<(float Key, T Value)> _Sequence;

	public int MaxDegree => 0;

	public IConvertibleCurve<T> Clone()
	{
		ISamplerTraits<T> traits = _Traits;
		(float, T)[] sequence = _Sequence.Select(((float Key, T Value) pair) => (Key: pair.Key, traits.Clone(pair.Value))).ToArray();
		return new StepSampler<T>(sequence, traits);
	}

	public StepSampler(IEnumerable<(float, T)> sequence, ISamplerTraits<T> traits)
	{
		_Sequence = sequence;
		_Traits = traits;
	}

	public T GetPoint(float offset)
	{
		T item = _Sequence.FindRangeContainingOffset(offset).A;
		return _Traits.Clone(item);
	}

	public IReadOnlyDictionary<float, T> ToStepCurve()
	{
		ISamplerTraits<T> traits = _Traits;
		return _Sequence.ToDictionary(((float Key, T Value) pair) => pair.Key, ((float Key, T Value) pair) => traits.Clone(pair.Value));
	}

	public IReadOnlyDictionary<float, T> ToLinearCurve()
	{
		throw new NotSupportedException(CurveSampler.CurveError(MaxDegree));
	}

	public IReadOnlyDictionary<float, (T TangentIn, T Value, T TangentOut)> ToSplineCurve()
	{
		throw new NotSupportedException(CurveSampler.CurveError(MaxDegree));
	}

	public ICurveSampler<T> ToFastSampler()
	{
		ISamplerTraits<T> traits = _Traits;
		return FastCurveSampler<T>.CreateFrom(_Sequence, ((float, T)[] chunk) => new StepSampler<T>(chunk, traits));
	}
}
