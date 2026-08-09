using System.Collections.Generic;

namespace SharpGLTF.Animations;

public interface IConvertibleCurve<T>
{
	int MaxDegree { get; }

	IConvertibleCurve<T> Clone();

	IReadOnlyDictionary<float, T> ToStepCurve();

	IReadOnlyDictionary<float, T> ToLinearCurve();

	IReadOnlyDictionary<float, (T TangentIn, T Value, T TangentOut)> ToSplineCurve();
}
