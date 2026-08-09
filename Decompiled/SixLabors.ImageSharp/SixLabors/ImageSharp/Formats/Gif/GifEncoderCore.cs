using System;
using System.Buffers;
using System.IO;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.Memory;
using SixLabors.ImageSharp.Metadata;
using SixLabors.ImageSharp.Metadata.Profiles.Xmp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Processing.Processors.Quantization;

namespace SixLabors.ImageSharp.Formats.Gif;

internal sealed class GifEncoderCore
{
	private readonly MemoryAllocator memoryAllocator;

	private readonly Configuration configuration;

	private readonly bool skipMetadata;

	private IQuantizer? quantizer;

	private readonly bool hasQuantizer;

	private GifColorTableMode? colorTableMode;

	private readonly IPixelSamplingStrategy pixelSamplingStrategy;

	public GifEncoderCore(Configuration configuration, GifEncoder encoder)
	{
		this.configuration = configuration;
		memoryAllocator = configuration.MemoryAllocator;
		skipMetadata = encoder.SkipMetadata;
		quantizer = encoder.Quantizer;
		hasQuantizer = encoder.Quantizer != null;
		colorTableMode = encoder.ColorTableMode;
		pixelSamplingStrategy = encoder.PixelSamplingStrategy;
	}

	public void Encode<TPixel>(Image<TPixel> image, Stream stream, CancellationToken cancellationToken) where TPixel : unmanaged, IPixel<TPixel>
	{
		Guard.NotNull(image, "image");
		Guard.NotNull(stream, "stream");
		GifMetadata gifMetadata = GetGifMetadata(image);
		GifColorTableMode valueOrDefault = colorTableMode.GetValueOrDefault();
		if (!colorTableMode.HasValue)
		{
			valueOrDefault = gifMetadata.ColorTableMode;
			colorTableMode = valueOrDefault;
		}
		bool flag = colorTableMode == GifColorTableMode.Global;
		IndexedImageFrame<TPixel> indexedImageFrame = null;
		GifFrameMetadata gifFrameMetadata = GetGifFrameMetadata(image.Frames.RootFrame, -1);
		if (this.quantizer == null)
		{
			if (gifMetadata.ColorTableMode == GifColorTableMode.Global)
			{
				ReadOnlyMemory<Color>? globalColorTable = gifMetadata.GlobalColorTable;
				if (globalColorTable.HasValue && globalColorTable.GetValueOrDefault().Length > 0)
				{
					int transparentIndex = GetTransparentIndex(indexedImageFrame, gifFrameMetadata);
					if (transparentIndex >= 0 || gifMetadata.GlobalColorTable.Value.Length < 256)
					{
						this.quantizer = new PaletteQuantizer(gifMetadata.GlobalColorTable.Value, new QuantizerOptions
						{
							Dither = null
						}, transparentIndex);
					}
					else
					{
						this.quantizer = KnownQuantizers.Octree;
					}
					goto IL_012d;
				}
			}
			this.quantizer = KnownQuantizers.Octree;
		}
		goto IL_012d;
		IL_012d:
		using (IQuantizer<TPixel> quantizer = this.quantizer.CreatePixelSpecificQuantizer<TPixel>(configuration))
		{
			if (flag)
			{
				quantizer.BuildPalette(pixelSamplingStrategy, image);
				indexedImageFrame = quantizer.QuantizeFrame(image.Frames.RootFrame, image.Bounds);
			}
			else
			{
				quantizer.BuildPalette(pixelSamplingStrategy, image.Frames.RootFrame);
				indexedImageFrame = quantizer.QuantizeFrame(image.Frames.RootFrame, image.Bounds);
			}
		}
		WriteHeader(stream);
		int transparentIndex2 = GetTransparentIndex(indexedImageFrame, null);
		if (transparentIndex2 >= 0)
		{
			gifFrameMetadata.HasTransparency = true;
			gifFrameMetadata.TransparencyIndex = ClampIndex(transparentIndex2);
		}
		byte backgroundIndex = ((transparentIndex2 >= 0) ? gifFrameMetadata.TransparencyIndex : gifMetadata.BackgroundColorIndex);
		int bitsNeededForColorDepth = ColorNumerics.GetBitsNeededForColorDepth(indexedImageFrame.Palette.Length);
		WriteLogicalScreenDescriptor(image.Metadata, image.Width, image.Height, backgroundIndex, flag, bitsNeededForColorDepth, stream);
		if (flag)
		{
			WriteColorTable(indexedImageFrame, bitsNeededForColorDepth, stream);
		}
		if (!skipMetadata)
		{
			WriteComments(gifMetadata, stream);
			XmpProfile xmpProfile = image.Metadata.XmpProfile ?? image.Frames.RootFrame.Metadata.XmpProfile;
			WriteApplicationExtensions(stream, image.Frames.Count, gifMetadata.RepeatCount, xmpProfile);
		}
		EncodeFirstFrame(stream, gifFrameMetadata, indexedImageFrame);
		TPixel[] array = ((image.Frames.Count == 1) ? Array.Empty<TPixel>() : indexedImageFrame.Palette.ToArray());
		EncodeAdditionalFrames(stream, image, array, transparentIndex2, gifFrameMetadata.DisposalMethod);
		stream.WriteByte(59);
		indexedImageFrame?.Dispose();
	}

	private static GifMetadata GetGifMetadata<TPixel>(Image<TPixel> image) where TPixel : unmanaged, IPixel<TPixel>
	{
		if (image.Metadata.TryGetGifMetadata(out GifMetadata metadata))
		{
			return (GifMetadata)metadata.DeepClone();
		}
		if (image.Metadata.TryGetPngMetadata(out PngMetadata metadata2))
		{
			return GifMetadata.FromAnimatedMetadata(metadata2.ToAnimatedImageMetadata());
		}
		if (image.Metadata.TryGetWebpMetadata(out WebpMetadata metadata3))
		{
			return GifMetadata.FromAnimatedMetadata(metadata3.ToAnimatedImageMetadata());
		}
		return new GifMetadata();
	}

	private static GifFrameMetadata GetGifFrameMetadata<TPixel>(ImageFrame<TPixel> frame, int transparencyIndex) where TPixel : unmanaged, IPixel<TPixel>
	{
		GifFrameMetadata gifFrameMetadata = null;
		PngFrameMetadata metadata2;
		WebpFrameMetadata metadata3;
		if (frame.Metadata.TryGetGifMetadata(out GifFrameMetadata metadata))
		{
			gifFrameMetadata = (GifFrameMetadata)metadata.DeepClone();
		}
		else if (frame.Metadata.TryGetPngMetadata(out metadata2))
		{
			gifFrameMetadata = GifFrameMetadata.FromAnimatedMetadata(metadata2.ToAnimatedImageFrameMetadata());
		}
		else if (frame.Metadata.TryGetWebpFrameMetadata(out metadata3))
		{
			gifFrameMetadata = GifFrameMetadata.FromAnimatedMetadata(metadata3.ToAnimatedImageFrameMetadata());
		}
		if (gifFrameMetadata != null && gifFrameMetadata.ColorTableMode == GifColorTableMode.Global && transparencyIndex > -1)
		{
			gifFrameMetadata.HasTransparency = true;
			gifFrameMetadata.TransparencyIndex = ClampIndex(transparencyIndex);
		}
		return gifFrameMetadata ?? new GifFrameMetadata();
	}

	private void EncodeAdditionalFrames<TPixel>(Stream stream, Image<TPixel> image, ReadOnlyMemory<TPixel> globalPalette, int globalTransparencyIndex, GifDisposalMethod previousDisposalMethod) where TPixel : unmanaged, IPixel<TPixel>
	{
		if (image.Frames.Count == 1)
		{
			return;
		}
		PaletteQuantizer<TPixel> globalPaletteQuantizer = default(PaletteQuantizer<TPixel>);
		bool flag = false;
		ImageFrame<TPixel> imageFrame = image.Frames.RootFrame;
		using ImageFrame<TPixel> encodingFrame = new ImageFrame<TPixel>(imageFrame.Configuration, imageFrame.Size());
		for (int i = 1; i < image.Frames.Count; i++)
		{
			ImageFrame<TPixel> imageFrame2 = image.Frames[i];
			ImageFrame<TPixel> nextFrame = ((i < image.Frames.Count - 1) ? image.Frames[i + 1] : null);
			GifFrameMetadata gifFrameMetadata = GetGifFrameMetadata(imageFrame2, globalTransparencyIndex);
			bool flag2 = colorTableMode == GifColorTableMode.Local || gifFrameMetadata.ColorTableMode == GifColorTableMode.Local;
			if (!flag2 && !flag && i > 0)
			{
				int transparentIndex = (gifFrameMetadata.HasTransparency ? gifFrameMetadata.TransparencyIndex : (-1));
				globalPaletteQuantizer = new PaletteQuantizer<TPixel>(configuration, quantizer.Options, globalPalette, transparentIndex);
				flag = true;
			}
			EncodeAdditionalFrame(stream, imageFrame, imageFrame2, nextFrame, encodingFrame, flag2, gifFrameMetadata, globalPaletteQuantizer, previousDisposalMethod);
			imageFrame = imageFrame2;
			previousDisposalMethod = gifFrameMetadata.DisposalMethod;
		}
		if (flag)
		{
			globalPaletteQuantizer.Dispose();
		}
	}

	private void EncodeFirstFrame<TPixel>(Stream stream, GifFrameMetadata metadata, IndexedImageFrame<TPixel> quantized) where TPixel : unmanaged, IPixel<TPixel>
	{
		WriteGraphicalControlExtension(metadata, stream);
		Buffer2D<byte> pixelBuffer = ((IPixelSource)quantized).PixelBuffer;
		Rectangle rectangle = pixelBuffer.FullRectangle();
		bool flag = colorTableMode == GifColorTableMode.Local || metadata.ColorTableMode == GifColorTableMode.Local;
		int bitsNeededForColorDepth = ColorNumerics.GetBitsNeededForColorDepth(quantized.Palette.Length);
		WriteImageDescriptor(rectangle, flag, bitsNeededForColorDepth, stream);
		if (flag)
		{
			WriteColorTable(quantized, bitsNeededForColorDepth, stream);
		}
		WriteImageData(pixelBuffer, stream, quantized.Palette.Length, metadata.TransparencyIndex);
	}

	private void EncodeAdditionalFrame<TPixel>(Stream stream, ImageFrame<TPixel> previousFrame, ImageFrame<TPixel> currentFrame, ImageFrame<TPixel>? nextFrame, ImageFrame<TPixel> encodingFrame, bool useLocal, GifFrameMetadata metadata, PaletteQuantizer<TPixel> globalPaletteQuantizer, GifDisposalMethod previousDisposal) where TPixel : unmanaged, IPixel<TPixel>
	{
		int transparencyIndex = (metadata.HasTransparency ? metadata.TransparencyIndex : (-1));
		ImageFrame<TPixel> previousFrame2 = ((previousDisposal == GifDisposalMethod.RestoreToBackground) ? null : previousFrame);
		var (hasDuplicates, rectangle) = AnimationUtilities.DeDuplicatePixels(configuration, previousFrame2, currentFrame, nextFrame, encodingFrame, Color.Transparent, blend: true);
		using IndexedImageFrame<TPixel> indexedImageFrame = QuantizeAdditionalFrameAndUpdateMetadata(encodingFrame, rectangle, metadata, useLocal, globalPaletteQuantizer, hasDuplicates, transparencyIndex);
		WriteGraphicalControlExtension(metadata, stream);
		int bitsNeededForColorDepth = ColorNumerics.GetBitsNeededForColorDepth(indexedImageFrame.Palette.Length);
		WriteImageDescriptor(rectangle, useLocal, bitsNeededForColorDepth, stream);
		if (useLocal)
		{
			WriteColorTable(indexedImageFrame, bitsNeededForColorDepth, stream);
		}
		Buffer2D<byte> pixelBuffer = ((IPixelSource)indexedImageFrame).PixelBuffer;
		WriteImageData(pixelBuffer, stream, indexedImageFrame.Palette.Length, metadata.TransparencyIndex);
	}

	private IndexedImageFrame<TPixel> QuantizeAdditionalFrameAndUpdateMetadata<TPixel>(ImageFrame<TPixel> encodingFrame, Rectangle bounds, GifFrameMetadata metadata, bool useLocal, PaletteQuantizer<TPixel> globalPaletteQuantizer, bool hasDuplicates, int transparencyIndex) where TPixel : unmanaged, IPixel<TPixel>
	{
		IndexedImageFrame<TPixel> indexedImageFrame;
		if (useLocal)
		{
			ReadOnlyMemory<Color>? localColorTable = metadata.LocalColorTable;
			if (localColorTable.HasValue && localColorTable.GetValueOrDefault().Length > 0)
			{
				ReadOnlyMemory<Color> value = metadata.LocalColorTable.Value;
				if (hasDuplicates && !metadata.HasTransparency)
				{
					metadata.HasTransparency = true;
					if (value.Length < 256)
					{
						transparencyIndex = value.Length;
						metadata.TransparencyIndex = ClampIndex(transparencyIndex);
						PaletteQuantizer paletteQuantizer = new PaletteQuantizer(value, new QuantizerOptions
						{
							Dither = null
						}, transparencyIndex);
						using IQuantizer<TPixel> quantizer = paletteQuantizer.CreatePixelSpecificQuantizer<TPixel>(configuration, paletteQuantizer.Options);
						indexedImageFrame = quantizer.BuildPaletteAndQuantizeFrame(encodingFrame, bounds);
					}
					else
					{
						IQuantizer quantizer2 = (hasQuantizer ? this.quantizer : KnownQuantizers.Octree);
						using IQuantizer<TPixel> quantizer3 = quantizer2.CreatePixelSpecificQuantizer<TPixel>(configuration, quantizer2.Options);
						indexedImageFrame = quantizer3.BuildPaletteAndQuantizeFrame(encodingFrame, bounds);
						int transparentIndex = GetTransparentIndex(indexedImageFrame, null);
						metadata.TransparencyIndex = ClampIndex(transparentIndex);
					}
				}
				else
				{
					PaletteQuantizer paletteQuantizer2 = new PaletteQuantizer(value, new QuantizerOptions
					{
						Dither = null
					}, transparencyIndex);
					using IQuantizer<TPixel> quantizer4 = paletteQuantizer2.CreatePixelSpecificQuantizer<TPixel>(configuration, paletteQuantizer2.Options);
					indexedImageFrame = quantizer4.BuildPaletteAndQuantizeFrame(encodingFrame, bounds);
				}
			}
			else
			{
				IQuantizer quantizer5 = (hasQuantizer ? this.quantizer : KnownQuantizers.Octree);
				using IQuantizer<TPixel> quantizer6 = quantizer5.CreatePixelSpecificQuantizer<TPixel>(configuration, quantizer5.Options);
				indexedImageFrame = quantizer6.BuildPaletteAndQuantizeFrame(encodingFrame, bounds);
				int num = GetTransparentIndex(indexedImageFrame, null);
				if (num < 0)
				{
					num = indexedImageFrame.Palette.Length;
				}
				metadata.TransparencyIndex = ClampIndex(num);
				if (hasDuplicates)
				{
					metadata.HasTransparency = true;
				}
			}
		}
		else
		{
			if (hasDuplicates && !metadata.HasTransparency)
			{
				metadata.HasTransparency = true;
				transparencyIndex = globalPaletteQuantizer.Palette.Length;
				metadata.TransparencyIndex = ClampIndex(transparencyIndex);
			}
			globalPaletteQuantizer.SetTransparentIndex(transparencyIndex);
			indexedImageFrame = globalPaletteQuantizer.QuantizeFrame(encodingFrame, bounds);
		}
		return indexedImageFrame;
	}

	private static byte ClampIndex(int value)
	{
		return (byte)Numerics.Clamp(value, 0, 255);
	}

	private static int GetTransparentIndex<TPixel>(IndexedImageFrame<TPixel>? quantized, GifFrameMetadata? metadata) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if (metadata != null && metadata.HasTransparency)
		{
			return metadata.TransparencyIndex;
		}
		int result = -1;
		if (quantized != null)
		{
			TPixel other = default(TPixel);
			other.FromScaledVector4(Vector4.Zero);
			ReadOnlySpan<TPixel> span = quantized.Palette.Span;
			for (int num = span.Length - 1; num >= 0; num--)
			{
				if (span[num].Equals(other))
				{
					result = num;
				}
			}
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void WriteHeader(Stream stream)
	{
		stream.Write(GifConstants.MagicNumber);
	}

	private void WriteLogicalScreenDescriptor(ImageMetadata metadata, int width, int height, byte backgroundIndex, bool useGlobalTable, int bitDepth, Stream stream)
	{
		byte packedValue = GifLogicalScreenDescriptor.GetPackedValue(useGlobalTable, bitDepth - 1, sortFlag: false, bitDepth - 1);
		byte pixelAspectRatio = 0;
		if (metadata.ResolutionUnits == PixelResolutionUnit.AspectRatio)
		{
			double horizontalResolution = metadata.HorizontalResolution;
			double verticalResolution = metadata.VerticalResolution;
			if (horizontalResolution != verticalResolution)
			{
				pixelAspectRatio = ((!(horizontalResolution > verticalResolution)) ? ((byte)(1.0 / verticalResolution * 64.0 - 15.0)) : ((byte)(horizontalResolution * 64.0 - 15.0)));
			}
		}
		GifLogicalScreenDescriptor gifLogicalScreenDescriptor = new GifLogicalScreenDescriptor((ushort)width, (ushort)height, packedValue, backgroundIndex, pixelAspectRatio);
		Span<byte> buffer = stackalloc byte[20];
		gifLogicalScreenDescriptor.WriteTo(buffer);
		stream.Write(buffer, 0, 7);
	}

	private void WriteApplicationExtensions(Stream stream, int frameCount, ushort repeatCount, XmpProfile? xmpProfile)
	{
		if (frameCount > 1 && repeatCount != 1)
		{
			GifNetscapeLoopingApplicationExtension extension = new GifNetscapeLoopingApplicationExtension(repeatCount);
			WriteExtension(extension, stream);
		}
		if (xmpProfile != null)
		{
			GifXmpApplicationExtension extension2 = new GifXmpApplicationExtension(xmpProfile.Data);
			WriteExtension(extension2, stream);
		}
	}

	private void WriteComments(GifMetadata metadata, Stream stream)
	{
		if (metadata.Comments.Count == 0)
		{
			return;
		}
		Span<byte> span = stackalloc byte[2];
		for (int i = 0; i < metadata.Comments.Count; i++)
		{
			string text = metadata.Comments[i];
			span[1] = 254;
			span[0] = 33;
			stream.Write(span);
			ReadOnlySpan<char> commentSpan = MemoryExtensions.AsSpan(text);
			int j;
			for (j = 0; j <= text.Length - 255; j += 255)
			{
				WriteCommentSubBlock(stream, commentSpan, j, 255);
			}
			if (j < text.Length)
			{
				int length = text.Length - j;
				WriteCommentSubBlock(stream, commentSpan, j, length);
			}
			stream.WriteByte(0);
		}
	}

	private static void WriteCommentSubBlock(Stream stream, ReadOnlySpan<char> commentSpan, int idx, int length)
	{
		string s = commentSpan.Slice(idx, length).ToString();
		byte[] bytes = GifConstants.Encoding.GetBytes(s);
		stream.WriteByte((byte)length);
		stream.Write(bytes, 0, length);
	}

	private void WriteGraphicalControlExtension(GifFrameMetadata metadata, Stream stream)
	{
		bool hasTransparency = metadata.HasTransparency;
		byte packedValue = GifGraphicControlExtension.GetPackedValue(metadata.DisposalMethod, userInputFlag: false, hasTransparency);
		GifGraphicControlExtension extension = new GifGraphicControlExtension(packedValue, (ushort)metadata.FrameDelay, (byte)(hasTransparency ? metadata.TransparencyIndex : 0));
		WriteExtension(extension, stream);
	}

	private void WriteExtension<TGifExtension>(TGifExtension extension, Stream stream) where TGifExtension : struct, IGifExtension
	{
		int contentLength = extension.ContentLength;
		if (contentLength != 0)
		{
			IMemoryOwner<byte> memoryOwner = null;
			Span<byte> span = default(Span<byte>);
			if (contentLength > 128)
			{
				memoryOwner = memoryAllocator.Allocate<byte>(contentLength + 3);
				span = memoryOwner.GetSpan();
			}
			else
			{
				span = stackalloc byte[contentLength + 3];
			}
			span[0] = 33;
			span[1] = extension.Label;
			extension.WriteTo(span.Slice(2, span.Length - 2));
			span[contentLength + 2] = 0;
			stream.Write(span, 0, contentLength + 3);
			memoryOwner?.Dispose();
		}
	}

	private void WriteImageDescriptor(Rectangle rectangle, bool hasColorTable, int bitDepth, Stream stream)
	{
		byte packedValue = GifImageDescriptor.GetPackedValue(hasColorTable, interfaceFlag: false, sortFlag: false, bitDepth - 1);
		GifImageDescriptor gifImageDescriptor = new GifImageDescriptor((ushort)rectangle.X, (ushort)rectangle.Y, (ushort)rectangle.Width, (ushort)rectangle.Height, packedValue);
		Span<byte> buffer = stackalloc byte[20];
		gifImageDescriptor.WriteTo(buffer);
		stream.Write(buffer, 0, 10);
	}

	private void WriteColorTable<TPixel>(IndexedImageFrame<TPixel> image, int bitDepth, Stream stream) where TPixel : unmanaged, IPixel<TPixel>
	{
		int length = ColorNumerics.GetColorCountForBitDepth(bitDepth) * Unsafe.SizeOf<Rgb24>();
		using IMemoryOwner<byte> buffer = memoryAllocator.Allocate<byte>(length, AllocationOptions.Clean);
		Span<byte> span = buffer.GetSpan();
		PixelOperations<TPixel> instance = PixelOperations<TPixel>.Instance;
		Configuration obj = configuration;
		ReadOnlyMemory<TPixel> palette = image.Palette;
		ReadOnlySpan<TPixel> span2 = palette.Span;
		palette = image.Palette;
		instance.ToRgb24Bytes(obj, span2, span, palette.Length);
		stream.Write(span);
	}

	private void WriteImageData(Buffer2D<byte> indices, Stream stream, int paletteLength, int transparencyIndex)
	{
		int num = ((transparencyIndex >= paletteLength) ? 1 : 0);
		using LzwEncoder lzwEncoder = new LzwEncoder(memoryAllocator, ColorNumerics.GetBitsNeededForColorDepth(paletteLength + num));
		lzwEncoder.Encode(indices, stream);
	}
}
