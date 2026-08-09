using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Memory;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing.Processors.Filters;

namespace SixLabors.ImageSharp.Processing.Processors.Convolution;

public sealed class EdgeDetectorCompassProcessor : IImageProcessor
{
	public EdgeDetectorCompassKernel Kernel { get; }

	public bool Grayscale { get; }

	public EdgeDetectorCompassProcessor(EdgeDetectorCompassKernel kernel, bool grayscale)
	{
		Kernel = kernel;
		Grayscale = grayscale;
	}

	public IImageProcessor<TPixel> CreatePixelSpecificProcessor<TPixel>(Configuration configuration, Image<TPixel> source, Rectangle sourceRectangle) where TPixel : unmanaged, IPixel<TPixel>
	{
		return new EdgeDetectorCompassProcessor<TPixel>(configuration, this, source, sourceRectangle);
	}
}
internal class EdgeDetectorCompassProcessor<TPixel> : ImageProcessor<TPixel> where TPixel : unmanaged, IPixel<TPixel>
{
	private readonly struct RowOperation(Buffer2D<TPixel> targetPixels, Buffer2D<TPixel> passPixels, Rectangle bounds) : IRowOperation
	{
		private readonly Buffer2D<TPixel> targetPixels = targetPixels;

		private readonly Buffer2D<TPixel> passPixels = passPixels;

		private readonly uint minX = (uint)bounds.X;

		private readonly uint maxX = (uint)bounds.Right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Invoke(int y)
		{
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			ref TPixel reference = ref MemoryMarshal.GetReference<TPixel>(passPixels.DangerousGetRowSpan(y));
			ref TPixel reference2 = ref MemoryMarshal.GetReference<TPixel>(targetPixels.DangerousGetRowSpan(y));
			for (nuint num = minX; num < maxX; num++)
			{
				ref TPixel reference3 = ref Unsafe.Add(ref reference, num);
				ref TPixel reference4 = ref Unsafe.Add(ref reference2, num);
				Vector4 vector = Vector4.Max(reference3.ToVector4(), reference4.ToVector4());
				reference4.FromVector4(vector);
			}
		}
	}

	private readonly DenseMatrix<float>[] kernels;

	private readonly bool grayscale;

	internal EdgeDetectorCompassProcessor(Configuration configuration, EdgeDetectorCompassProcessor definition, Image<TPixel> source, Rectangle sourceRectangle)
		: base(configuration, source, sourceRectangle)
	{
		grayscale = definition.Grayscale;
		kernels = definition.Kernel.Flatten();
	}

	protected override void BeforeImageApply()
	{
		using (IImageProcessor<TPixel> imageProcessor = new OpaqueProcessor<TPixel>(base.Configuration, base.Source, base.SourceRectangle))
		{
			imageProcessor.Execute();
		}
		if (grayscale)
		{
			new GrayscaleBt709Processor(1f).Execute(base.Configuration, base.Source, base.SourceRectangle);
		}
		base.BeforeImageApply();
	}

	protected override void OnFrameApply(ImageFrame<TPixel> source)
	{
		Rectangle rectangle = Rectangle.Intersect(base.SourceRectangle, source.Bounds());
		using ImageFrame<TPixel> imageFrame = source.Clone();
		using (ConvolutionProcessor<TPixel> convolutionProcessor = new ConvolutionProcessor<TPixel>(base.Configuration, in kernels[0], preserveAlpha: true, base.Source, rectangle))
		{
			convolutionProcessor.Apply(source);
		}
		if (kernels.Length == 1)
		{
			return;
		}
		for (int i = 1; i < kernels.Length; i++)
		{
			using ImageFrame<TPixel> imageFrame2 = imageFrame.Clone();
			using (ConvolutionProcessor<TPixel> convolutionProcessor2 = new ConvolutionProcessor<TPixel>(base.Configuration, in kernels[i], preserveAlpha: true, base.Source, rectangle))
			{
				convolutionProcessor2.Apply(imageFrame2);
			}
			RowOperation operation = new RowOperation(source.PixelBuffer, imageFrame2.PixelBuffer, rectangle);
			ParallelRowIterator.IterateRows(base.Configuration, rectangle, in operation);
		}
	}
}
