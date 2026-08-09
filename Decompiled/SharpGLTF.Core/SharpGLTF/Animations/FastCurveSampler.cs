using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SharpGLTF.Animations;

internal readonly struct FastCurveSampler<T> : ICurveSampler<T>
{
	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	private readonly ICurveSampler<T>[] _Samplers;

	public static ICurveSampler<T> CreateFrom<TKey>(IEnumerable<(float, TKey)> sequence, Func<(float, TKey)[], ICurveSampler<T>> chunkFactory)
	{
		if (!sequence.Skip(3).Any())
		{
			return null;
		}
		IEnumerable<ICurveSampler<T>> samplers = (from item in sequence.SplitByTime()
			select chunkFactory(item)).Cast<ICurveSampler<T>>();
		return new FastCurveSampler<T>(samplers);
	}

	private FastCurveSampler(IEnumerable<ICurveSampler<T>> samplers)
	{
		_Samplers = samplers.ToArray();
	}

	public T GetPoint(float offset)
	{
		if (offset < 0f)
		{
			offset = 0f;
		}
		int num = (int)offset;
		if (num >= _Samplers.Length)
		{
			num = _Samplers.Length - 1;
		}
		return _Samplers[num].GetPoint(offset);
	}
}
