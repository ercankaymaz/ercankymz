using System.Numerics;

namespace SixLabors.ImageSharp.Processing.Processors.Convolution.Parameters;

internal readonly struct BokehBlurKernelData(Vector4[] parameters, Complex64[][] kernels)
{
	public readonly Vector4[] Parameters = parameters;

	public readonly Complex64[][] Kernels = kernels;
}
