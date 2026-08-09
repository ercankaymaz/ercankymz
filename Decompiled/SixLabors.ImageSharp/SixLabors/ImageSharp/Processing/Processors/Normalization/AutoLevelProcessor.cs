using System;
using System.Buffers;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Memory;
using SixLabors.ImageSharp.PixelFormats;

namespace SixLabors.ImageSharp.Processing.Processors.Normalization;

public class AutoLevelProcessor : HistogramEqualizationProcessor
{
	public bool SyncChannels { get; }

	public AutoLevelProcessor(int luminanceLevels, bool clipHistogram, int clipLimit, bool syncChannels)
		: base(luminanceLevels, clipHistogram, clipLimit)
	{
		SyncChannels = syncChannels;
	}

	public override IImageProcessor<TPixel> CreatePixelSpecificProcessor<TPixel>(Configuration configuration, Image<TPixel> source, Rectangle sourceRectangle)
	{
		return new AutoLevelProcessor<TPixel>(configuration, base.LuminanceLevels, base.ClipHistogram, base.ClipLimit, SyncChannels, source, sourceRectangle);
	}
}
internal class AutoLevelProcessor<TPixel> : HistogramEqualizationProcessor<TPixel> where TPixel : unmanaged, IPixel<TPixel>
{
	private readonly struct SynchronizedChannelsRowOperation(Configuration configuration, Rectangle bounds, IMemoryOwner<int> cdfBuffer, Buffer2D<TPixel> source, int luminanceLevels, float numberOfPixelsMinusCdfMin) : IRowOperation<Vector4>
	{
		private readonly Configuration configuration = configuration;

		private readonly Rectangle bounds = bounds;

		private readonly IMemoryOwner<int> cdfBuffer = cdfBuffer;

		private readonly Buffer2D<TPixel> source = source;

		private readonly int luminanceLevels = luminanceLevels;

		private readonly float numberOfPixelsMinusCdfMin = numberOfPixelsMinusCdfMin;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetRequiredBufferLength(Rectangle bounds)
		{
			return bounds.Width;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Invoke(int y, Span<Vector4> span)
		{
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			Span<Vector4> span2 = span.Slice(0, bounds.Width);
			ref Vector4 reference = ref MemoryMarshal.GetReference<Vector4>(span2);
			ref int reference2 = ref MemoryMarshal.GetReference<int>(cdfBuffer.GetSpan());
			PixelAccessor<TPixel> pixelAccessor = new PixelAccessor<TPixel>(source);
			int num = luminanceLevels;
			float num2 = numberOfPixelsMinusCdfMin;
			Span<TPixel> span3 = pixelAccessor.GetRowSpan(y).Slice(bounds.X, bounds.Width);
			PixelOperations<TPixel>.Instance.ToVector4(configuration, span3, span2);
			Vector4 val = default(Vector4);
			for (int i = 0; i < bounds.Width; i++)
			{
				Vector4 vector = Unsafe.Add(ref reference, (uint)i);
				int bT709Luminance = ColorNumerics.GetBT709Luminance(ref vector, num);
				float num3 = (float)Unsafe.Add(ref reference2, (uint)bT709Luminance) / num2 * (float)num / (float)bT709Luminance;
				((Vector4)(ref val))._002Ector(num3 * vector.X, num3 * vector.Y, num3 * vector.Z, vector.W);
				Unsafe.Add(ref reference, (uint)i) = val;
			}
			PixelOperations<TPixel>.Instance.FromVector4Destructive(configuration, span2, span3);
		}
	}

	private readonly struct SeperateChannelsRowOperation(Configuration configuration, Rectangle bounds, IMemoryOwner<int> cdfBuffer, Buffer2D<TPixel> source, int luminanceLevels, float numberOfPixelsMinusCdfMin) : IRowOperation<Vector4>
	{
		private readonly Configuration configuration = configuration;

		private readonly Rectangle bounds = bounds;

		private readonly IMemoryOwner<int> cdfBuffer = cdfBuffer;

		private readonly Buffer2D<TPixel> source = source;

		private readonly int luminanceLevels = luminanceLevels;

		private readonly float numberOfPixelsMinusCdfMin = numberOfPixelsMinusCdfMin;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetRequiredBufferLength(Rectangle bounds)
		{
			return bounds.Width;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Invoke(int y, Span<Vector4> span)
		{
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			Span<Vector4> span2 = span.Slice(0, bounds.Width);
			ref Vector4 reference = ref MemoryMarshal.GetReference<Vector4>(span2);
			ref int reference2 = ref MemoryMarshal.GetReference<int>(cdfBuffer.GetSpan());
			PixelAccessor<TPixel> pixelAccessor = new PixelAccessor<TPixel>(source);
			int num = luminanceLevels - 1;
			float num2 = numberOfPixelsMinusCdfMin;
			Span<TPixel> rowSpan = pixelAccessor.GetRowSpan(y);
			PixelOperations<TPixel>.Instance.ToVector4(configuration, rowSpan, span2);
			for (int i = 0; i < bounds.Width; i++)
			{
				Vector4 val = Unsafe.Add(ref reference, (uint)i) * (float)num;
				uint num3 = (uint)MathF.Round(val.X);
				float num4 = (float)Unsafe.Add(ref reference2, num3) / num2;
				uint num5 = (uint)MathF.Round(val.Y);
				float num6 = (float)Unsafe.Add(ref reference2, num5) / num2;
				uint num7 = (uint)MathF.Round(val.Z);
				float num8 = (float)Unsafe.Add(ref reference2, num7) / num2;
				Unsafe.Add(ref reference, (uint)i) = new Vector4(num4, num6, num8, val.W);
			}
			PixelOperations<TPixel>.Instance.FromVector4Destructive(configuration, span2, rowSpan);
		}
	}

	private bool SyncChannels { get; }

	public AutoLevelProcessor(Configuration configuration, int luminanceLevels, bool clipHistogram, int clipLimit, bool syncChannels, Image<TPixel> source, Rectangle sourceRectangle)
		: base(configuration, luminanceLevels, clipHistogram, clipLimit, source, sourceRectangle)
	{
		SyncChannels = syncChannels;
	}

	protected override void OnFrameApply(ImageFrame<TPixel> source)
	{
		MemoryAllocator memoryAllocator = base.Configuration.MemoryAllocator;
		int num = source.Width * source.Height;
		Rectangle rectangle = Rectangle.Intersect(base.SourceRectangle, source.Bounds());
		using IMemoryOwner<int> memoryOwner = memoryAllocator.Allocate<int>(base.LuminanceLevels, AllocationOptions.Clean);
		GrayscaleLevelsRowOperation<TPixel> operation = new GrayscaleLevelsRowOperation<TPixel>(base.Configuration, rectangle, memoryOwner, source.PixelBuffer, base.LuminanceLevels);
		ParallelRowIterator.IterateRows<GrayscaleLevelsRowOperation<TPixel>, Vector4>(base.Configuration, rectangle, in operation);
		Span<int> span = memoryOwner.GetSpan();
		if (base.ClipHistogramEnabled)
		{
			ClipHistogram(span, base.ClipLimit);
		}
		using IMemoryOwner<int> memoryOwner2 = memoryAllocator.Allocate<int>(base.LuminanceLevels, AllocationOptions.Clean);
		int num2 = HistogramEqualizationProcessor<TPixel>.CalculateCdf(ref MemoryMarshal.GetReference<int>(memoryOwner2.GetSpan()), ref MemoryMarshal.GetReference<int>(span), span.Length - 1);
		float numberOfPixelsMinusCdfMin = num - num2;
		if (SyncChannels)
		{
			SynchronizedChannelsRowOperation operation2 = new SynchronizedChannelsRowOperation(base.Configuration, rectangle, memoryOwner2, source.PixelBuffer, base.LuminanceLevels, numberOfPixelsMinusCdfMin);
			ParallelRowIterator.IterateRows<SynchronizedChannelsRowOperation, Vector4>(base.Configuration, rectangle, in operation2);
		}
		else
		{
			SeperateChannelsRowOperation operation3 = new SeperateChannelsRowOperation(base.Configuration, rectangle, memoryOwner2, source.PixelBuffer, base.LuminanceLevels, numberOfPixelsMinusCdfMin);
			ParallelRowIterator.IterateRows<SeperateChannelsRowOperation, Vector4>(base.Configuration, rectangle, in operation3);
		}
	}
}
