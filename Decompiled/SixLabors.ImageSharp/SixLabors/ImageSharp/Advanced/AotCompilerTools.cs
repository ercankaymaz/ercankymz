using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Bmp;
using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Jpeg.Components;
using SixLabors.ImageSharp.Formats.Jpeg.Components.Decoder;
using SixLabors.ImageSharp.Formats.Pbm;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats.Qoi;
using SixLabors.ImageSharp.Formats.Tga;
using SixLabors.ImageSharp.Formats.Tiff;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.Memory;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Processing.Processors;
using SixLabors.ImageSharp.Processing.Processors.Binarization;
using SixLabors.ImageSharp.Processing.Processors.Convolution;
using SixLabors.ImageSharp.Processing.Processors.Dithering;
using SixLabors.ImageSharp.Processing.Processors.Drawing;
using SixLabors.ImageSharp.Processing.Processors.Effects;
using SixLabors.ImageSharp.Processing.Processors.Filters;
using SixLabors.ImageSharp.Processing.Processors.Normalization;
using SixLabors.ImageSharp.Processing.Processors.Overlays;
using SixLabors.ImageSharp.Processing.Processors.Quantization;
using SixLabors.ImageSharp.Processing.Processors.Transforms;

namespace SixLabors.ImageSharp.Advanced;

[ExcludeFromCodeCoverage]
internal static class AotCompilerTools
{
	[Preserve]
	private static void SeedPixelFormats()
	{
		try
		{
			Unsafe.SizeOf<long>();
			Unsafe.SizeOf<short>();
			Unsafe.SizeOf<float>();
			Unsafe.SizeOf<double>();
			Unsafe.SizeOf<byte>();
			Unsafe.SizeOf<int>();
			Unsafe.SizeOf<bool>();
			Unsafe.SizeOf<Block8x8>();
			Unsafe.SizeOf<Vector4>();
			Seed<A8>();
			Seed<Argb32>();
			Seed<Abgr32>();
			Seed<Bgr24>();
			Seed<Bgr565>();
			Seed<Bgra32>();
			Seed<Bgra4444>();
			Seed<Bgra5551>();
			Seed<Byte4>();
			Seed<L16>();
			Seed<L8>();
			Seed<La16>();
			Seed<La32>();
			Seed<HalfSingle>();
			Seed<HalfVector2>();
			Seed<HalfVector4>();
			Seed<NormalizedByte2>();
			Seed<NormalizedByte4>();
			Seed<NormalizedShort2>();
			Seed<NormalizedShort4>();
			Seed<Rg32>();
			Seed<Rgb24>();
			Seed<Rgb48>();
			Seed<Rgba1010102>();
			Seed<Rgba32>();
			Seed<Rgba64>();
			Seed<RgbaVector>();
			Seed<Short2>();
			Seed<Short4>();
		}
		catch
		{
		}
		throw new InvalidOperationException("This method is used for AOT code generation only. Do not call it at runtime.");
	}

	[Preserve]
	private static void Seed<TPixel>() where TPixel : unmanaged, IPixel<TPixel>
	{
		AotCompileImage<TPixel>();
		AotCompileImageProcessingContextFactory<TPixel>();
		AotCompileImageEncoderInternals<TPixel>();
		AotCompileImageDecoderInternals<TPixel>();
		AotCompileImageEncoders<TPixel>();
		AotCompileImageDecoders<TPixel>();
		AotCompileSpectralConverter<TPixel>();
		AotCompileImageProcessors<TPixel>();
		AotCompileGenericImageProcessors<TPixel>();
		AotCompileResamplers<TPixel>();
		AotCompileQuantizers<TPixel>();
		AotCompilePixelSamplingStrategys<TPixel>();
		AotCompileDithers<TPixel>();
		AotCompileMemoryManagers<TPixel>();
		Unsafe.SizeOf<TPixel>();
	}

	[Preserve]
	private static void AotCompileImage<TPixel>() where TPixel : unmanaged, IPixel<TPixel>
	{
		((Image<TPixel>)null).CloneAs<A8>((Configuration)null);
		((Image<TPixel>)null).CloneAs<Argb32>((Configuration)null);
		((Image<TPixel>)null).CloneAs<Abgr32>((Configuration)null);
		((Image<TPixel>)null).CloneAs<Bgr24>((Configuration)null);
		((Image<TPixel>)null).CloneAs<Bgr565>((Configuration)null);
		((Image<TPixel>)null).CloneAs<Bgra32>((Configuration)null);
		((Image<TPixel>)null).CloneAs<Bgra4444>((Configuration)null);
		((Image<TPixel>)null).CloneAs<Bgra5551>((Configuration)null);
		((Image<TPixel>)null).CloneAs<Byte4>((Configuration)null);
		((Image<TPixel>)null).CloneAs<L16>((Configuration)null);
		((Image<TPixel>)null).CloneAs<L8>((Configuration)null);
		((Image<TPixel>)null).CloneAs<La16>((Configuration)null);
		((Image<TPixel>)null).CloneAs<La32>((Configuration)null);
		((Image<TPixel>)null).CloneAs<HalfSingle>((Configuration)null);
		((Image<TPixel>)null).CloneAs<HalfVector2>((Configuration)null);
		((Image<TPixel>)null).CloneAs<HalfVector4>((Configuration)null);
		((Image<TPixel>)null).CloneAs<NormalizedByte2>((Configuration)null);
		((Image<TPixel>)null).CloneAs<NormalizedByte4>((Configuration)null);
		((Image<TPixel>)null).CloneAs<NormalizedShort2>((Configuration)null);
		((Image<TPixel>)null).CloneAs<NormalizedShort4>((Configuration)null);
		((Image<TPixel>)null).CloneAs<Rg32>((Configuration)null);
		((Image<TPixel>)null).CloneAs<Rgb24>((Configuration)null);
		((Image<TPixel>)null).CloneAs<Rgb48>((Configuration)null);
		((Image<TPixel>)null).CloneAs<Rgba1010102>((Configuration)null);
		((Image<TPixel>)null).CloneAs<Rgba32>((Configuration)null);
		((Image<TPixel>)null).CloneAs<Rgba64>((Configuration)null);
		((Image<TPixel>)null).CloneAs<RgbaVector>((Configuration)null);
		((Image<TPixel>)null).CloneAs<Short2>((Configuration)null);
		((Image<TPixel>)null).CloneAs<Short4>((Configuration)null);
		ImageFrame.LoadPixelData(null, default(ReadOnlySpan<TPixel>), 0, 0);
		ImageFrame.LoadPixelData<TPixel>(null, default(ReadOnlySpan<byte>), 0, 0);
	}

	[Preserve]
	private static void AotCompileImageProcessingContextFactory<TPixel>() where TPixel : unmanaged, IPixel<TPixel>
	{
		((DefaultImageOperationsProviderFactory)null).CreateImageProcessingContext((Configuration)null, (Image<TPixel>)null, false);
	}

	[Preserve]
	private static void AotCompileImageEncoderInternals<TPixel>() where TPixel : unmanaged, IPixel<TPixel>
	{
		((BmpEncoderCore)null).Encode((Image<TPixel>)null, (Stream)null, default(CancellationToken));
		((GifEncoderCore)null).Encode((Image<TPixel>)null, (Stream)null, default(CancellationToken));
		((JpegEncoderCore)null).Encode((Image<TPixel>)null, (Stream)null, default(CancellationToken));
		((PbmEncoderCore)null).Encode((Image<TPixel>)null, (Stream)null, default(CancellationToken));
		((PngEncoderCore)null).Encode((Image<TPixel>)null, (Stream)null, default(CancellationToken));
		((QoiEncoderCore)null).Encode((Image<TPixel>)null, (Stream)null, default(CancellationToken));
		((TgaEncoderCore)null).Encode((Image<TPixel>)null, (Stream)null, default(CancellationToken));
		((TiffEncoderCore)null).Encode((Image<TPixel>)null, (Stream)null, default(CancellationToken));
		((WebpEncoderCore)null).Encode((Image<TPixel>)null, (Stream)null, default(CancellationToken));
	}

	[Preserve]
	private static void AotCompileImageDecoderInternals<TPixel>() where TPixel : unmanaged, IPixel<TPixel>
	{
		((ImageDecoderCore)null).Decode<TPixel>((Configuration)null, (Stream)null, default(CancellationToken));
		((ImageDecoderCore)null).Decode<TPixel>((Configuration)null, (Stream)null, default(CancellationToken));
		((ImageDecoderCore)null).Decode<TPixel>((Configuration)null, (Stream)null, default(CancellationToken));
		((ImageDecoderCore)null).Decode<TPixel>((Configuration)null, (Stream)null, default(CancellationToken));
		((ImageDecoderCore)null).Decode<TPixel>((Configuration)null, (Stream)null, default(CancellationToken));
		((ImageDecoderCore)null).Decode<TPixel>((Configuration)null, (Stream)null, default(CancellationToken));
		((ImageDecoderCore)null).Decode<TPixel>((Configuration)null, (Stream)null, default(CancellationToken));
		((ImageDecoderCore)null).Decode<TPixel>((Configuration)null, (Stream)null, default(CancellationToken));
		((ImageDecoderCore)null).Decode<TPixel>((Configuration)null, (Stream)null, default(CancellationToken));
	}

	[Preserve]
	private static void AotCompileImageEncoders<TPixel>() where TPixel : unmanaged, IPixel<TPixel>
	{
		AotCompileImageEncoder<TPixel, WebpEncoder>();
		AotCompileImageEncoder<TPixel, BmpEncoder>();
		AotCompileImageEncoder<TPixel, GifEncoder>();
		AotCompileImageEncoder<TPixel, JpegEncoder>();
		AotCompileImageEncoder<TPixel, PbmEncoder>();
		AotCompileImageEncoder<TPixel, PngEncoder>();
		AotCompileImageEncoder<TPixel, TgaEncoder>();
		AotCompileImageEncoder<TPixel, TiffEncoder>();
	}

	[Preserve]
	private static void AotCompileImageDecoders<TPixel>() where TPixel : unmanaged, IPixel<TPixel>
	{
		AotCompileImageDecoder<TPixel, WebpDecoder>();
		AotCompileImageDecoder<TPixel, BmpDecoder>();
		AotCompileImageDecoder<TPixel, GifDecoder>();
		AotCompileImageDecoder<TPixel, JpegDecoder>();
		AotCompileImageDecoder<TPixel, PbmDecoder>();
		AotCompileImageDecoder<TPixel, PngDecoder>();
		AotCompileImageDecoder<TPixel, TgaDecoder>();
		AotCompileImageDecoder<TPixel, TiffDecoder>();
	}

	[Preserve]
	private static void AotCompileSpectralConverter<TPixel>() where TPixel : unmanaged, IPixel<TPixel>
	{
		((SpectralConverter<TPixel>)null).GetPixelBuffer(default(CancellationToken));
		((SpectralConverter<TPixel>)null).GetPixelBuffer(default(CancellationToken));
		((SpectralConverter<TPixel>)null).GetPixelBuffer(default(CancellationToken));
		((SpectralConverter<TPixel>)null).GetPixelBuffer(default(CancellationToken));
		((SpectralConverter<TPixel>)null).GetPixelBuffer(default(CancellationToken));
	}

	[Preserve]
	private static void AotCompileImageEncoder<TPixel, TEncoder>() where TPixel : unmanaged, IPixel<TPixel> where TEncoder : class, IImageEncoder
	{
		((IImageEncoder)null).Encode((Image<TPixel>)null, (Stream)null);
		((IImageEncoder)null).EncodeAsync((Image<TPixel>)null, (Stream)null, default(CancellationToken));
	}

	[Preserve]
	private static void AotCompileImageDecoder<TPixel, TDecoder>() where TPixel : unmanaged, IPixel<TPixel> where TDecoder : class, IImageDecoder
	{
		((IImageDecoder)null).Decode<TPixel>((DecoderOptions)null, (Stream)null);
	}

	[Preserve]
	private static void AotCompileImageProcessors<TPixel>() where TPixel : unmanaged, IPixel<TPixel>
	{
		AotCompileImageProcessor<TPixel, CloningImageProcessor>();
		AotCompileImageProcessor<TPixel, CropProcessor>();
		AotCompileImageProcessor<TPixel, AffineTransformProcessor>();
		AotCompileImageProcessor<TPixel, ProjectiveTransformProcessor>();
		AotCompileImageProcessor<TPixel, RotateProcessor>();
		AotCompileImageProcessor<TPixel, SkewProcessor>();
		AotCompileImageProcessor<TPixel, ResizeProcessor>();
		AotCompileImageProcessor<TPixel, EntropyCropProcessor>();
		AotCompileImageProcessor<TPixel, AutoOrientProcessor>();
		AotCompileImageProcessor<TPixel, FlipProcessor>();
		AotCompileImageProcessor<TPixel, QuantizeProcessor>();
		AotCompileImageProcessor<TPixel, BackgroundColorProcessor>();
		AotCompileImageProcessor<TPixel, GlowProcessor>();
		AotCompileImageProcessor<TPixel, VignetteProcessor>();
		AotCompileImageProcessor<TPixel, AdaptiveHistogramEqualizationProcessor>();
		AotCompileImageProcessor<TPixel, AdaptiveHistogramEqualizationSlidingWindowProcessor>();
		AotCompileImageProcessor<TPixel, GlobalHistogramEqualizationProcessor>();
		AotCompileImageProcessor<TPixel, AchromatomalyProcessor>();
		AotCompileImageProcessor<TPixel, AchromatopsiaProcessor>();
		AotCompileImageProcessor<TPixel, BlackWhiteProcessor>();
		AotCompileImageProcessor<TPixel, BrightnessProcessor>();
		AotCompileImageProcessor<TPixel, ContrastProcessor>();
		AotCompileImageProcessor<TPixel, DeuteranomalyProcessor>();
		AotCompileImageProcessor<TPixel, DeuteranopiaProcessor>();
		AotCompileImageProcessor<TPixel, FilterProcessor>();
		AotCompileImageProcessor<TPixel, GrayscaleBt601Processor>();
		AotCompileImageProcessor<TPixel, GrayscaleBt709Processor>();
		AotCompileImageProcessor<TPixel, HueProcessor>();
		AotCompileImageProcessor<TPixel, InvertProcessor>();
		AotCompileImageProcessor<TPixel, KodachromeProcessor>();
		AotCompileImageProcessor<TPixel, LightnessProcessor>();
		AotCompileImageProcessor<TPixel, LomographProcessor>();
		AotCompileImageProcessor<TPixel, OpacityProcessor>();
		AotCompileImageProcessor<TPixel, PolaroidProcessor>();
		AotCompileImageProcessor<TPixel, ProtanomalyProcessor>();
		AotCompileImageProcessor<TPixel, ProtanopiaProcessor>();
		AotCompileImageProcessor<TPixel, SaturateProcessor>();
		AotCompileImageProcessor<TPixel, SepiaProcessor>();
		AotCompileImageProcessor<TPixel, TritanomalyProcessor>();
		AotCompileImageProcessor<TPixel, TritanopiaProcessor>();
		AotCompileImageProcessor<TPixel, OilPaintingProcessor>();
		AotCompileImageProcessor<TPixel, PixelateProcessor>();
		AotCompileImageProcessor<TPixel, PixelRowDelegateProcessor>();
		AotCompileImageProcessor<TPixel, PositionAwarePixelRowDelegateProcessor>();
		AotCompileImageProcessor<TPixel, DrawImageProcessor>();
		AotCompileImageProcessor<TPixel, PaletteDitherProcessor>();
		AotCompileImageProcessor<TPixel, BokehBlurProcessor>();
		AotCompileImageProcessor<TPixel, BoxBlurProcessor>();
		AotCompileImageProcessor<TPixel, EdgeDetector2DProcessor>();
		AotCompileImageProcessor<TPixel, EdgeDetectorCompassProcessor>();
		AotCompileImageProcessor<TPixel, EdgeDetectorProcessor>();
		AotCompileImageProcessor<TPixel, GaussianBlurProcessor>();
		AotCompileImageProcessor<TPixel, GaussianSharpenProcessor>();
		AotCompileImageProcessor<TPixel, AdaptiveThresholdProcessor>();
		AotCompileImageProcessor<TPixel, BinaryThresholdProcessor>();
		AotCompilerCloningImageProcessor<TPixel, CloningImageProcessor>();
		AotCompilerCloningImageProcessor<TPixel, CropProcessor>();
		AotCompilerCloningImageProcessor<TPixel, AffineTransformProcessor>();
		AotCompilerCloningImageProcessor<TPixel, ProjectiveTransformProcessor>();
		AotCompilerCloningImageProcessor<TPixel, RotateProcessor>();
		AotCompilerCloningImageProcessor<TPixel, SkewProcessor>();
		AotCompilerCloningImageProcessor<TPixel, ResizeProcessor>();
	}

	[Preserve]
	private static void AotCompileImageProcessor<TPixel, TProc>() where TPixel : unmanaged, IPixel<TPixel> where TProc : class, IImageProcessor
	{
		((IImageProcessor)null).CreatePixelSpecificProcessor((Configuration)null, (Image<TPixel>)null, default(Rectangle));
	}

	[Preserve]
	private static void AotCompilerCloningImageProcessor<TPixel, TProc>() where TPixel : unmanaged, IPixel<TPixel> where TProc : class, ICloningImageProcessor
	{
		((ICloningImageProcessor)null).CreatePixelSpecificCloningProcessor((Configuration)null, (Image<TPixel>)null, default(Rectangle));
	}

	[Preserve]
	private static void AotCompileGenericImageProcessors<TPixel>() where TPixel : unmanaged, IPixel<TPixel>
	{
		AotCompileGenericCloningImageProcessor<TPixel, CropProcessor<TPixel>>();
		AotCompileGenericCloningImageProcessor<TPixel, AffineTransformProcessor<TPixel>>();
		AotCompileGenericCloningImageProcessor<TPixel, ProjectiveTransformProcessor<TPixel>>();
		AotCompileGenericCloningImageProcessor<TPixel, ResizeProcessor<TPixel>>();
		AotCompileGenericCloningImageProcessor<TPixel, RotateProcessor<TPixel>>();
	}

	[Preserve]
	private static void AotCompileGenericCloningImageProcessor<TPixel, TProc>() where TPixel : unmanaged, IPixel<TPixel> where TProc : class, ICloningImageProcessor<TPixel>
	{
		((ICloningImageProcessor<TPixel>)null).CloneAndExecute();
	}

	[Preserve]
	private static void AotCompileResamplers<TPixel>() where TPixel : unmanaged, IPixel<TPixel>
	{
		AotCompileResampler<TPixel, BicubicResampler>();
		AotCompileResampler<TPixel, BoxResampler>();
		AotCompileResampler<TPixel, CubicResampler>();
		AotCompileResampler<TPixel, LanczosResampler>();
		AotCompileResampler<TPixel, NearestNeighborResampler>();
		AotCompileResampler<TPixel, TriangleResampler>();
		AotCompileResampler<TPixel, WelchResampler>();
	}

	[Preserve]
	private static void AotCompileResampler<TPixel, TResampler>() where TPixel : unmanaged, IPixel<TPixel> where TResampler : struct, IResampler
	{
		default(TResampler).ApplyTransform<TPixel>(null);
		((AffineTransformProcessor<TPixel>)null).ApplyTransform<TResampler>(default(TResampler));
		((ProjectiveTransformProcessor<TPixel>)null).ApplyTransform<TResampler>(default(TResampler));
		((ResizeProcessor<TPixel>)null).ApplyTransform<TResampler>(default(TResampler));
		((AffineTransformProcessor<TPixel>)null).ApplyTransform<TResampler>(default(TResampler));
	}

	[Preserve]
	private static void AotCompileQuantizers<TPixel>() where TPixel : unmanaged, IPixel<TPixel>
	{
		AotCompileQuantizer<TPixel, OctreeQuantizer>();
		AotCompileQuantizer<TPixel, PaletteQuantizer>();
		AotCompileQuantizer<TPixel, WebSafePaletteQuantizer>();
		AotCompileQuantizer<TPixel, WernerPaletteQuantizer>();
		AotCompileQuantizer<TPixel, WuQuantizer>();
	}

	[Preserve]
	private static void AotCompileQuantizer<TPixel, TQuantizer>() where TPixel : unmanaged, IPixel<TPixel> where TQuantizer : class, IQuantizer
	{
		((IQuantizer)null).CreatePixelSpecificQuantizer<TPixel>((Configuration)null);
		((IQuantizer)null).CreatePixelSpecificQuantizer<TPixel>((Configuration)null, (QuantizerOptions)null);
	}

	[Preserve]
	private static void AotCompilePixelSamplingStrategys<TPixel>() where TPixel : unmanaged, IPixel<TPixel>
	{
		((DefaultPixelSamplingStrategy)null).EnumeratePixelRegions((Image<TPixel>)null);
		((DefaultPixelSamplingStrategy)null).EnumeratePixelRegions((ImageFrame<TPixel>)null);
		((ExtensivePixelSamplingStrategy)null).EnumeratePixelRegions((Image<TPixel>)null);
		((ExtensivePixelSamplingStrategy)null).EnumeratePixelRegions((ImageFrame<TPixel>)null);
	}

	[Preserve]
	private static void AotCompileDithers<TPixel>() where TPixel : unmanaged, IPixel<TPixel>
	{
		AotCompileDither<TPixel, ErrorDither>();
		AotCompileDither<TPixel, OrderedDither>();
	}

	[Preserve]
	private static void AotCompileDither<TPixel, TDither>() where TPixel : unmanaged, IPixel<TPixel> where TDither : struct, IDither
	{
		OctreeQuantizer<TPixel> quantizer = default(OctreeQuantizer<TPixel>);
		default(TDither).ApplyQuantizationDither<OctreeQuantizer<TPixel>, TPixel>(ref quantizer, null, null, default(Rectangle));
		PaletteQuantizer<TPixel> quantizer2 = default(PaletteQuantizer<TPixel>);
		default(TDither).ApplyQuantizationDither<PaletteQuantizer<TPixel>, TPixel>(ref quantizer2, null, null, default(Rectangle));
		WuQuantizer<TPixel> quantizer3 = default(WuQuantizer<TPixel>);
		default(TDither).ApplyQuantizationDither<WuQuantizer<TPixel>, TPixel>(ref quantizer3, null, null, default(Rectangle));
		default(TDither).ApplyPaletteDither<PaletteDitherProcessor<TPixel>.DitherProcessor, TPixel>(default(PaletteDitherProcessor<TPixel>.DitherProcessor), null, default(Rectangle));
	}

	[Preserve]
	private static void AotCompileMemoryManagers<TPixel>() where TPixel : unmanaged, IPixel<TPixel>
	{
		AotCompileMemoryManager<TPixel, UniformUnmanagedMemoryPoolMemoryAllocator>();
		AotCompileMemoryManager<TPixel, SimpleGcMemoryAllocator>();
	}

	[Preserve]
	private static void AotCompileMemoryManager<TPixel, TBuffer>() where TPixel : unmanaged, IPixel<TPixel> where TBuffer : MemoryAllocator
	{
		((MemoryAllocator)null).Allocate<long>(0, AllocationOptions.None);
		((MemoryAllocator)null).Allocate<short>(0, AllocationOptions.None);
		((MemoryAllocator)null).Allocate<float>(0, AllocationOptions.None);
		((MemoryAllocator)null).Allocate<double>(0, AllocationOptions.None);
		((MemoryAllocator)null).Allocate<byte>(0, AllocationOptions.None);
		((MemoryAllocator)null).Allocate<int>(0, AllocationOptions.None);
		((MemoryAllocator)null).Allocate<bool>(0, AllocationOptions.None);
		((MemoryAllocator)null).Allocate<decimal>(0, AllocationOptions.None);
		((MemoryAllocator)null).Allocate<Block8x8>(0, AllocationOptions.None);
		((MemoryAllocator)null).Allocate<Vector4>(0, AllocationOptions.None);
		((MemoryAllocator)null).Allocate<TPixel>(0, AllocationOptions.None);
	}
}
