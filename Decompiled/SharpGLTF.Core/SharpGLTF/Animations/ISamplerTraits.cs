namespace SharpGLTF.Animations;

internal interface ISamplerTraits<T>
{
	T Clone(T value);

	T InterpolateLinear(T left, T right, float amount);

	T InterpolateCubic(T start, T outgoingTangent, T end, T incomingTangent, float amount);
}
