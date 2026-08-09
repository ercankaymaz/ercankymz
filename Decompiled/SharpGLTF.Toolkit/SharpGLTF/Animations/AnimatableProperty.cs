using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using SharpGLTF.Collections;
using SharpGLTF.Transforms;

namespace SharpGLTF.Animations;

public class AnimatableProperty<T> where T : struct
{
	private Dictionary<string, ICurveSampler<T>> _Tracks;

	public T Value { get; set; }

	public bool IsAnimated => Tracks.Count > 0;

	public IReadOnlyDictionary<string, ICurveSampler<T>> Tracks
	{
		get
		{
			if (_Tracks != null)
			{
				return _Tracks;
			}
			return EmptyDictionary<string, ICurveSampler<T>>.Instance;
		}
	}

	internal AnimatableProperty()
	{
	}

	internal AnimatableProperty(AnimatableProperty<T> other)
	{
		if (other == null)
		{
			return;
		}
		if (other._Tracks != null)
		{
			_Tracks = new Dictionary<string, ICurveSampler<T>>();
			foreach (KeyValuePair<string, ICurveSampler<T>> track in other._Tracks)
			{
				_Tracks[track.Key] = CurveFactory.CreateCurveBuilder(track.Value);
			}
		}
		Value = other.Value;
	}

	public AnimatableProperty<T> Clone()
	{
		return new AnimatableProperty<T>(this);
	}

	public void RemoveTrack(string track)
	{
		if (_Tracks != null)
		{
			_Tracks.Remove(track);
			if (_Tracks.Count == 0)
			{
				_Tracks = null;
			}
		}
	}

	public T GetValueAt(string track, float offset)
	{
		if (_Tracks == null)
		{
			return Value;
		}
		if (!_Tracks.TryGetValue(track, out var value))
		{
			return Value;
		}
		return value.GetPoint(offset);
	}

	public void SetTrack(string track, ICurveSampler<T> curve)
	{
		SharpGLTF.Guard.NotNullOrEmpty(track, "track");
		if (curve == null)
		{
			if (_Tracks != null)
			{
				_Tracks.Remove(track);
				if (_Tracks.Count == 0)
				{
					_Tracks = null;
				}
			}
			return;
		}
		SharpGLTF.Guard.IsFalse(curve is CurveBuilder<T>, "Use UseTrackBuilder() instead");
		IConvertibleCurve<T> convertibleCurve = curve as IConvertibleCurve<T>;
		curve = convertibleCurve.Clone() as ICurveSampler<T>;
		curve.GetPoint(0f);
		SharpGLTF.Guard.NotNull(curve, "Provided ICurveSampler curve must implement IConvertibleCurve interface.");
		if (_Tracks == null)
		{
			_Tracks = new Dictionary<string, ICurveSampler<T>>();
		}
		_Tracks[track] = curve;
	}

	public CurveBuilder<T> UseTrackBuilder(string track)
	{
		SharpGLTF.Guard.NotNullOrEmpty(track, "track");
		if (_Tracks == null)
		{
			_Tracks = new Dictionary<string, ICurveSampler<T>>();
		}
		if (!_Tracks.TryGetValue(track, out var value))
		{
			value = CurveFactory.CreateCurveBuilder<T>();
			_Tracks[track] = value;
		}
		if (value is CurveBuilder<T> result)
		{
			return result;
		}
		CurveBuilder<T> curveBuilder = CurveFactory.CreateCurveBuilder(value);
		_Tracks[track] = curveBuilder;
		return curveBuilder;
	}

	public void SetValue(params float[] elements)
	{
		SharpGLTF.Guard.NotNull(elements, "elements");
		Value = _Convert(elements);
	}

	private static T _Convert(float[] elements)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		if (typeof(T) == typeof(Vector3))
		{
			return (T)(object)new Vector3(elements[0], elements[1], elements[2]);
		}
		if (typeof(T) == typeof(Vector4))
		{
			return (T)(object)new Vector4(elements[0], elements[1], elements[2], elements[3]);
		}
		if (typeof(T) == typeof(Quaternion))
		{
			return (T)(object)new Quaternion(elements[0], elements[1], elements[2], elements[3]);
		}
		if (typeof(T) == typeof(float[]))
		{
			return (T)(ValueType)(object)Enumerable.ToArray(new ArraySegment<float>(elements));
		}
		if (typeof(T) == typeof(ArraySegment<float>))
		{
			return (T)(object)new ArraySegment<float>(elements.CloneArray());
		}
		if (typeof(T) == typeof(SparseWeight8))
		{
			return (T)(object)SparseWeight8.Create(elements);
		}
		throw new NotSupportedException();
	}
}
