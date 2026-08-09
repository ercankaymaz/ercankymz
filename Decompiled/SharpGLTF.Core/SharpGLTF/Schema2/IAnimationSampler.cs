using System.Collections.Generic;
using SharpGLTF.Animations;

namespace SharpGLTF.Schema2;

public interface IAnimationSampler<T>
{
	AnimationInterpolationMode InterpolationMode { get; }

	IEnumerable<(float Key, T Value)> GetLinearKeys();

	IEnumerable<(float Key, (T TangentIn, T Value, T TangentOut) Value)> GetCubicKeys();

	ICurveSampler<T> CreateCurveSampler(bool isolateMemory = false);
}
