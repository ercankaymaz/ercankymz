using System.Collections.Generic;
using System.Linq;
using SharpGLTF.Animations;

namespace SharpGLTF.Runtime;

internal sealed class AnimatableProperty<T> where T : struct
{
	private List<ICurveSampler<T>> _Curves;

	public T Value { get; private set; }

	public bool IsAnimated
	{
		get
		{
			if (_Curves != null)
			{
				return _Curves.Count > 0;
			}
			return false;
		}
	}

	internal AnimatableProperty(T defval)
	{
		Value = defval;
	}

	public T GetValueAt(int trackLogicalIndex, float offset)
	{
		if (_Curves == null)
		{
			return Value;
		}
		if (trackLogicalIndex < 0 || trackLogicalIndex >= _Curves.Count)
		{
			return Value;
		}
		return _Curves[trackLogicalIndex]?.GetPoint(offset) ?? Value;
	}

	public void SetCurve(int trackLogicalIndex, ICurveSampler<T> curveSampler)
	{
		SharpGLTF.Guard.MustBeGreaterThanOrEqualTo(trackLogicalIndex, 0, "trackLogicalIndex");
		if (curveSampler == null)
		{
			if (_Curves != null && trackLogicalIndex < _Curves.Count)
			{
				_Curves[trackLogicalIndex] = null;
				if (_Curves.All((ICurveSampler<T> item) => item == null))
				{
					_Curves = null;
				}
			}
		}
		else
		{
			if (_Curves == null)
			{
				_Curves = new List<ICurveSampler<T>>();
			}
			while (_Curves.Count <= trackLogicalIndex)
			{
				_Curves.Add(null);
			}
			_Curves[trackLogicalIndex] = curveSampler;
		}
	}
}
