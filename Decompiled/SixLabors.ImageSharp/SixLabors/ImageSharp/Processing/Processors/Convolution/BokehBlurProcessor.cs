using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Memory;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing.Processors.Convolution.Parameters;

namespace SixLabors.ImageSharp.Processing.Processors.Convolution;

public sealed class BokehBlurProcessor : IImageProcessor
{
	internal readonly struct SecondPassConvolutionRowOperation(Rectangle bounds, Buffer2D<Vector4> targetValues, Buffer2D<ComplexVector4> sourceValues, KernelSamplingMap map, Complex64[] kernel, float z, float w) : IRowOperation
	{
		private readonly Rectangle bounds = bounds;

		private readonly Buffer2D<Vector4> targetValues = targetValues;

		private readonly Buffer2D<ComplexVector4> sourceValues = sourceValues;

		private readonly KernelSamplingMap map = map;

		private readonly Complex64[] kernel = kernel;

		private readonly float z = z;

		private readonly float w = w;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Invoke(int y)
		{
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			int x = bounds.X;
			int width = bounds.Width;
			int num = kernel.Length;
			ref int reference = ref Unsafe.Add(ref MemoryMarshal.GetReference<int>(map.GetRowOffsetSpan()), (uint)((y - bounds.Y) * num));
			ref Vector4 elementUnsafe = ref targetValues.GetElementUnsafe(x, y);
			ref Complex64 reference2 = ref MemoryMarshal.GetArrayDataReference<Complex64>(kernel);
			ref Complex64 right = ref Unsafe.Add(ref reference2, (uint)num);
			while (Unsafe.IsAddressLessThan(ref reference2, ref right))
			{
				ref ComplexVector4 reference3 = ref sourceValues.GetElementUnsafe(0, reference);
				ref ComplexVector4 right2 = ref Unsafe.Add(ref reference3, (uint)width);
				ref Vector4 reference4 = ref elementUnsafe;
				Complex64 complex = reference2;
				while (Unsafe.IsAddressLessThan(ref reference3, ref right2))
				{
					ComplexVector4 complexVector = complex * reference3;
					reference4 += complexVector.WeightedSum(z, w);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 1);
				}
				reference2 = ref Unsafe.Add(ref reference2, 1);
				reference = ref Unsafe.Add(ref reference, 1);
			}
		}
	}

	public const int DefaultRadius = 32;

	public const int DefaultComponents = 2;

	public const float DefaultGamma = 3f;

	public int Radius { get; }

	public int Components { get; }

	public float Gamma { get; }

	public BokehBlurProcessor()
	{
		Radius = 32;
		Components = 2;
		Gamma = 3f;
	}

	public BokehBlurProcessor(int radius, int components, float gamma)
	{
		Guard.MustBeGreaterThan(radius, 0, "radius");
		Guard.MustBeBetweenOrEqualTo(components, 1, 6, "components");
		Guard.MustBeGreaterThanOrEqualTo(gamma, 1f, "gamma");
		Radius = radius;
		Components = components;
		Gamma = gamma;
	}

	public IImageProcessor<TPixel> CreatePixelSpecificProcessor<TPixel>(Configuration configuration, Image<TPixel> source, Rectangle sourceRectangle) where TPixel : unmanaged, IPixel<TPixel>
	{
		return new BokehBlurProcessor<TPixel>(configuration, this, source, sourceRectangle);
	}
}
internal class BokehBlurProcessor<TPixel> : ImageProcessor<TPixel> where TPixel : unmanaged, IPixel<TPixel>
{
	private readonly struct FirstPassConvolutionRowOperation(Rectangle bounds, Buffer2D<ComplexVector4> targetValues, Buffer2D<TPixel> sourcePixels, KernelSamplingMap map, Complex64[] kernel, Configuration configuration) : IRowOperation<Vector4>
	{
		private readonly Rectangle bounds = bounds;

		private readonly Buffer2D<ComplexVector4> targetValues = targetValues;

		private readonly Buffer2D<TPixel> sourcePixels = sourcePixels;

		private readonly KernelSamplingMap map = map;

		private readonly Complex64[] kernel = kernel;

		private readonly Configuration configuration = configuration;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetRequiredBufferLength(Rectangle bounds)
		{
			return bounds.Width;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Invoke(int y, Span<Vector4> span)
		{
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			int x = bounds.X;
			int width = bounds.Width;
			int num = kernel.Length;
			Span<ComplexVector4> span2 = targetValues.DangerousGetRowSpan(y);
			span2.Clear();
			Span<TPixel> span3 = sourcePixels.DangerousGetRowSpan(y).Slice(x, width);
			PixelOperations<TPixel>.Instance.ToVector4(configuration, span3, span);
			ref Vector4 reference = ref MemoryMarshal.GetReference<Vector4>(span);
			ref ComplexVector4 reference2 = ref MemoryMarshal.GetReference<ComplexVector4>(span2);
			ref ComplexVector4 right = ref Unsafe.Add(ref reference2, (uint)span.Length);
			ref Complex64 arrayDataReference = ref MemoryMarshal.GetArrayDataReference<Complex64>(kernel);
			ref Complex64 right2 = ref Unsafe.Add(ref arrayDataReference, (uint)num);
			ref int reference3 = ref MemoryMarshal.GetReference<int>(map.GetColumnOffsetSpan());
			while (Unsafe.IsAddressLessThan(ref reference2, ref right))
			{
				ref Complex64 reference4 = ref arrayDataReference;
				ref int reference5 = ref reference3;
				while (Unsafe.IsAddressLessThan(ref reference4, ref right2))
				{
					Vector4 val = Unsafe.Add(ref reference, (uint)(reference5 - x));
					reference2.Sum(reference4 * val);
					reference4 = ref Unsafe.Add(ref reference4, 1);
					reference5 = ref Unsafe.Add(ref reference5, 1);
				}
				reference3 = ref Unsafe.Add(ref reference3, (uint)num);
				reference2 = ref Unsafe.Add(ref reference2, 1);
			}
		}
	}

	private readonly struct ApplyGammaExposureRowOperation(Rectangle bounds, Buffer2D<TPixel> targetPixels, Configuration configuration, float gamma) : IRowOperation<Vector4>
	{
		private readonly Rectangle bounds = bounds;

		private readonly Buffer2D<TPixel> targetPixels = targetPixels;

		private readonly Configuration configuration = configuration;

		private readonly float gamma = gamma;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetRequiredBufferLength(Rectangle bounds)
		{
			return bounds.Width;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Invoke(int y, Span<Vector4> span)
		{
			Span<TPixel> span2 = targetPixels.DangerousGetRowSpan(y);
			int x = bounds.X;
			Span<TPixel> destinationPixels = span2.Slice(x, span2.Length - x);
			PixelOperations<TPixel>.Instance.ToVector4(configuration, destinationPixels.Slice(0, span.Length), span, PixelConversionModifiers.Premultiply);
			ref Vector4 reference = ref MemoryMarshal.GetReference<Vector4>(span);
			for (int i = 0; i < bounds.Width; i++)
			{
				ref Vector4 reference2 = ref Unsafe.Add(ref reference, (uint)i);
				reference2.X = MathF.Pow(reference2.X, gamma);
				reference2.Y = MathF.Pow(reference2.Y, gamma);
				reference2.Z = MathF.Pow(reference2.Z, gamma);
			}
			PixelOperations<TPixel>.Instance.FromVector4Destructive(configuration, span, destinationPixels);
		}
	}

	private readonly struct ApplyGamma3ExposureRowOperation(Rectangle bounds, Buffer2D<TPixel> targetPixels, Configuration configuration) : IRowOperation<Vector4>
	{
		private readonly Rectangle bounds = bounds;

		private readonly Buffer2D<TPixel> targetPixels = targetPixels;

		private readonly Configuration configuration = configuration;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetRequiredBufferLength(Rectangle bounds)
		{
			return bounds.Width;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Invoke(int y, Span<Vector4> span)
		{
			Span<TPixel> span2 = targetPixels.DangerousGetRowSpan(y);
			int x = bounds.X;
			Span<TPixel> destinationPixels = span2.Slice(x, span2.Length - x);
			PixelOperations<TPixel>.Instance.ToVector4(configuration, destinationPixels.Slice(0, span.Length), span, PixelConversionModifiers.Premultiply);
			Numerics.CubePowOnXYZ(span);
			PixelOperations<TPixel>.Instance.FromVector4Destructive(configuration, span, destinationPixels);
		}
	}

	private readonly struct ApplyInverseGammaExposureRowOperation(Rectangle bounds, Buffer2D<TPixel> targetPixels, Buffer2D<Vector4> sourceValues, Configuration configuration, float inverseGamma) : IRowOperation
	{
		private readonly Rectangle bounds = bounds;

		private readonly Buffer2D<TPixel> targetPixels = targetPixels;

		private readonly Buffer2D<Vector4> sourceValues = sourceValues;

		private readonly Configuration configuration = configuration;

		private readonly float inverseGamma = inverseGamma;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Invoke(int y)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0005: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			Vector4 zero = Vector4.Zero;
			Vector4 max = default(Vector4);
			((Vector4)(ref max))._002Ector(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
			Span<TPixel> span = targetPixels.DangerousGetRowSpan(y);
			int x = bounds.X;
			Span<TPixel> destinationPixels = span.Slice(x, span.Length - x);
			Span<Vector4> span2 = sourceValues.DangerousGetRowSpan(y);
			x = bounds.X;
			Span<Vector4> span3 = span2.Slice(x, span2.Length - x);
			ref Vector4 reference = ref MemoryMarshal.GetReference<Vector4>(span3);
			for (int i = 0; i < bounds.Width; i++)
			{
				ref Vector4 reference2 = ref Unsafe.Add(ref reference, (uint)i);
				Vector4 val = Numerics.Clamp(reference2, zero, max);
				reference2.X = MathF.Pow(val.X, inverseGamma);
				reference2.Y = MathF.Pow(val.Y, inverseGamma);
				reference2.Z = MathF.Pow(val.Z, inverseGamma);
			}
			PixelOperations<TPixel>.Instance.FromVector4Destructive(configuration, span3.Slice(0, bounds.Width), destinationPixels, PixelConversionModifiers.Premultiply);
		}
	}

	private readonly struct ApplyInverseGamma3ExposureRowOperation(Rectangle bounds, Buffer2D<TPixel> targetPixels, Buffer2D<Vector4> sourceValues, Configuration configuration) : IRowOperation
	{
		private readonly Rectangle bounds = bounds;

		private readonly Buffer2D<TPixel> targetPixels = targetPixels;

		private readonly Buffer2D<Vector4> sourceValues = sourceValues;

		private readonly Configuration configuration = configuration;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Invoke(int y)
		{
			Span<Vector4> span = sourceValues.DangerousGetRowSpan(y).Slice(bounds.X, bounds.Width);
			MemoryMarshal.GetReference<Vector4>(span);
			Numerics.Clamp(MemoryMarshal.Cast<Vector4, float>(span), 0f, float.PositiveInfinity);
			Numerics.CubeRootOnXYZ(span);
			Span<TPixel> span2 = targetPixels.DangerousGetRowSpan(y);
			int x = bounds.X;
			Span<TPixel> destinationPixels = span2.Slice(x, span2.Length - x);
			PixelOperations<TPixel>.Instance.FromVector4Destructive(configuration, span.Slice(0, bounds.Width), destinationPixels, PixelConversionModifiers.Premultiply);
		}
	}

	private readonly float gamma;

	private readonly int kernelSize;

	private readonly Vector4[] kernelParameters;

	private readonly Complex64[][] kernels;

	public IReadOnlyList<Complex64[]> Kernels => kernels;

	public IReadOnlyList<Vector4> KernelParameters => kernelParameters;

	public BokehBlurProcessor(Configuration configuration, BokehBlurProcessor definition, Image<TPixel> source, Rectangle sourceRectangle)
		: base(configuration, source, sourceRectangle)
	{
		gamma = definition.Gamma;
		kernelSize = definition.Radius * 2 + 1;
		BokehBlurKernelData bokehBlurKernelData = BokehBlurKernelDataProvider.GetBokehBlurKernelData(definition.Radius, kernelSize, definition.Components);
		kernelParameters = bokehBlurKernelData.Parameters;
		kernels = bokehBlurKernelData.Kernels;
	}

	protected override void OnFrameApply(ImageFrame<TPixel> source)
	{
		Rectangle rectangle = Rectangle.Intersect(base.SourceRectangle, source.Bounds());
		if (gamma == 3f)
		{
			ApplyGamma3ExposureRowOperation operation = new ApplyGamma3ExposureRowOperation(rectangle, source.PixelBuffer, base.Configuration);
			ParallelRowIterator.IterateRows<ApplyGamma3ExposureRowOperation, Vector4>(base.Configuration, rectangle, in operation);
		}
		else
		{
			ApplyGammaExposureRowOperation operation2 = new ApplyGammaExposureRowOperation(rectangle, source.PixelBuffer, base.Configuration, gamma);
			ParallelRowIterator.IterateRows<ApplyGammaExposureRowOperation, Vector4>(base.Configuration, rectangle, in operation2);
		}
		using Buffer2D<Vector4> buffer2D = base.Configuration.MemoryAllocator.Allocate2D<Vector4>(source.Size(), AllocationOptions.Clean);
		OnFrameApplyCore(source, rectangle, base.Configuration, buffer2D);
		if (gamma == 3f)
		{
			ApplyInverseGamma3ExposureRowOperation operation3 = new ApplyInverseGamma3ExposureRowOperation(rectangle, source.PixelBuffer, buffer2D, base.Configuration);
			ParallelRowIterator.IterateRows(base.Configuration, rectangle, in operation3);
		}
		else
		{
			ApplyInverseGammaExposureRowOperation operation4 = new ApplyInverseGammaExposureRowOperation(rectangle, source.PixelBuffer, buffer2D, base.Configuration, 1f / gamma);
			ParallelRowIterator.IterateRows(base.Configuration, rectangle, in operation4);
		}
	}

	private void OnFrameApplyCore(ImageFrame<TPixel> source, Rectangle sourceRectangle, Configuration configuration, Buffer2D<Vector4> processingBuffer)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		using (Buffer2D<ComplexVector4> buffer2D = configuration.MemoryAllocator.Allocate2D<ComplexVector4>(source.Size()))
		{
			using KernelSamplingMap kernelSamplingMap = new KernelSamplingMap(configuration.MemoryAllocator);
			kernelSamplingMap.BuildSamplingOffsetMap(kernelSize, kernelSize, sourceRectangle);
			ref Complex64[] reference = ref MemoryMarshal.GetReference<Complex64[]>(MemoryExtensions.AsSpan<Complex64[]>(kernels));
			ref Vector4 reference2 = ref MemoryMarshal.GetReference<Vector4>(MemoryExtensions.AsSpan<Vector4>(kernelParameters));
			for (int i = 0; i < kernels.Length; i++)
			{
				Complex64[] kernel = Unsafe.Add(ref reference, (uint)i);
				Vector4 val = Unsafe.Add(ref reference2, (uint)i);
				ParallelRowIterator.IterateRows<FirstPassConvolutionRowOperation, Vector4>(configuration, sourceRectangle, in ILSpyHelper_AsRefReadOnly(new FirstPassConvolutionRowOperation(sourceRectangle, buffer2D, source.PixelBuffer, kernelSamplingMap, kernel, configuration)));
				ParallelRowIterator.IterateRows<BokehBlurProcessor.SecondPassConvolutionRowOperation>(configuration, sourceRectangle, new BokehBlurProcessor.SecondPassConvolutionRowOperation(sourceRectangle, processingBuffer, buffer2D, kernelSamplingMap, kernel, val.Z, val.W));
			}
		}
		static ref readonly T ILSpyHelper_AsRefReadOnly<T>(in T temp)
		{
			//ILSpy generated this function to help ensure overload resolution can pick the overload using 'in'
			return ref temp;
		}
	}
}
