using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using SixLabors.ImageSharp.IO;
using SixLabors.ImageSharp.Memory;
using SixLabors.ImageSharp.Metadata;
using SixLabors.ImageSharp.Metadata.Profiles.Xmp;
using SixLabors.ImageSharp.PixelFormats;

namespace SixLabors.ImageSharp.Formats.Gif;

internal sealed class GifDecoderCore : ImageDecoderCore
{
	private struct ScratchBuffer
	{
		private const int Size = 16;

		private unsafe fixed byte scratch[16];

		public unsafe Span<byte> Span => MemoryMarshal.CreateSpan<byte>(ref scratch[0], 16);
	}

	private ScratchBuffer buffer;

	private IMemoryOwner<byte>? globalColorTable;

	private IMemoryOwner<byte>? currentLocalColorTable;

	private int currentLocalColorTableSize;

	private Rectangle? restoreArea;

	private GifLogicalScreenDescriptor logicalScreenDescriptor;

	private GifGraphicControlExtension graphicsControlExtension;

	private GifImageDescriptor imageDescriptor;

	private readonly Configuration configuration;

	private readonly MemoryAllocator memoryAllocator;

	private readonly uint maxFrames;

	private readonly bool skipMetadata;

	private ImageMetadata? metadata;

	private GifMetadata? gifMetadata;

	public GifDecoderCore(DecoderOptions options)
		: base(options)
	{
		configuration = options.Configuration;
		skipMetadata = options.SkipMetadata;
		maxFrames = options.MaxFrames;
		memoryAllocator = configuration.MemoryAllocator;
	}

	protected override Image<TPixel> Decode<TPixel>(BufferedReadStream stream, CancellationToken cancellationToken)
	{
		uint num = 0u;
		Image<TPixel> image = null;
		ImageFrame<TPixel> previousFrame = null;
		try
		{
			ReadLogicalScreenDescriptorAndGlobalColorTable(stream);
			int num2 = stream.ReadByte();
			do
			{
				switch (num2)
				{
				case 44:
					if (previousFrame != null && ++num == maxFrames)
					{
						goto end_IL_00ca;
					}
					ReadFrame(stream, ref image, ref previousFrame);
					imageDescriptor = default(GifImageDescriptor);
					graphicsControlExtension = default(GifGraphicControlExtension);
					break;
				case 33:
					switch (stream.ReadByte())
					{
					case 249:
						ReadGraphicalControlExtension(stream);
						break;
					case 254:
						ReadComments(stream);
						break;
					case 255:
						ReadApplicationExtension(stream);
						break;
					case 1:
						SkipBlock(stream);
						break;
					}
					break;
				case 0:
				case 59:
					goto end_IL_00ca;
				}
				num2 = stream.ReadByte();
				continue;
				end_IL_00ca:
				break;
			}
			while (num2 != -1);
		}
		finally
		{
			globalColorTable?.Dispose();
			currentLocalColorTable?.Dispose();
		}
		if (image == null)
		{
			GifThrowHelper.ThrowNoData();
		}
		return image;
	}

	protected override ImageInfo Identify(BufferedReadStream stream, CancellationToken cancellationToken)
	{
		uint num = 0u;
		ImageFrameMetadata previousFrame = null;
		List<ImageFrameMetadata> list = new List<ImageFrameMetadata>();
		try
		{
			ReadLogicalScreenDescriptorAndGlobalColorTable(stream);
			int num2 = stream.ReadByte();
			do
			{
				switch (num2)
				{
				case 44:
					if (previousFrame != null && ++num == maxFrames)
					{
						goto end_IL_00cd;
					}
					ReadFrameMetadata(stream, list, ref previousFrame);
					imageDescriptor = default(GifImageDescriptor);
					graphicsControlExtension = default(GifGraphicControlExtension);
					break;
				case 33:
					switch (stream.ReadByte())
					{
					case 249:
						ReadGraphicalControlExtension(stream);
						break;
					case 254:
						ReadComments(stream);
						break;
					case 255:
						ReadApplicationExtension(stream);
						break;
					case 1:
						SkipBlock(stream);
						break;
					}
					break;
				case 0:
				case 59:
					goto end_IL_00cd;
				}
				num2 = stream.ReadByte();
				continue;
				end_IL_00cd:
				break;
			}
			while (num2 != -1);
		}
		finally
		{
			globalColorTable?.Dispose();
			currentLocalColorTable?.Dispose();
		}
		if (logicalScreenDescriptor.Width == 0 && logicalScreenDescriptor.Height == 0)
		{
			GifThrowHelper.ThrowNoHeader();
		}
		return new ImageInfo(new PixelTypeInfo(logicalScreenDescriptor.BitsPerPixel), new Size(logicalScreenDescriptor.Width, logicalScreenDescriptor.Height), metadata, list);
	}

	private void ReadGraphicalControlExtension(BufferedReadStream stream)
	{
		if (stream.Read(buffer.Span, 0, 6) != 6)
		{
			GifThrowHelper.ThrowInvalidImageContentException("Not enough data to read the graphic control extension");
		}
		graphicsControlExtension = GifGraphicControlExtension.Parse(buffer.Span);
	}

	private void ReadImageDescriptor(BufferedReadStream stream)
	{
		if (stream.Read(buffer.Span, 0, 9) != 9)
		{
			GifThrowHelper.ThrowInvalidImageContentException("Not enough data to read the image descriptor");
		}
		imageDescriptor = GifImageDescriptor.Parse(buffer.Span);
		if (imageDescriptor.Height == 0 || imageDescriptor.Width == 0)
		{
			GifThrowHelper.ThrowInvalidImageContentException("Width or height should not be 0");
		}
		base.Dimensions = new Size(imageDescriptor.Width, imageDescriptor.Height);
	}

	private void ReadLogicalScreenDescriptor(BufferedReadStream stream)
	{
		if (stream.Read(buffer.Span, 0, 7) != 7)
		{
			GifThrowHelper.ThrowInvalidImageContentException("Not enough data to read the logical screen descriptor");
		}
		logicalScreenDescriptor = GifLogicalScreenDescriptor.Parse(buffer.Span);
	}

	private void ReadApplicationExtension(BufferedReadStream stream)
	{
		int num = stream.ReadByte();
		long position = stream.Position;
		if (num == 11)
		{
			stream.Read(buffer.Span, 0, 11);
			if (MemoryExtensions.StartsWith<byte>(buffer.Span, GifConstants.XmpApplicationIdentificationBytes) && !skipMetadata)
			{
				GifXmpApplicationExtension gifXmpApplicationExtension = GifXmpApplicationExtension.Read(stream, memoryAllocator);
				if (gifXmpApplicationExtension.Data.Length != 0)
				{
					metadata.XmpProfile = new XmpProfile(gifXmpApplicationExtension.Data);
					return;
				}
				stream.Position = position;
				SkipBlock(stream, num);
				return;
			}
			int num2 = stream.ReadByte();
			if (num2 == 3)
			{
				stream.Read(buffer.Span, 0, 3);
				GifMetadata? obj = gifMetadata;
				Span<byte> span = buffer.Span;
				obj.RepeatCount = GifNetscapeLoopingApplicationExtension.Parse(span.Slice(1, span.Length - 1)).RepeatCount;
				stream.Skip(1);
			}
			else
			{
				SkipBlock(stream, num2);
			}
		}
		else
		{
			SkipBlock(stream, num);
		}
	}

	private static void SkipBlock(BufferedReadStream stream, int blockSize = 0)
	{
		if (blockSize > 0)
		{
			stream.Skip(blockSize);
		}
		int count;
		while ((count = stream.ReadByte()) > 0)
		{
			stream.Skip(count);
		}
	}

	private void ReadComments(BufferedReadStream stream)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num;
		while ((num = stream.ReadByte()) != 0)
		{
			if (num > 255)
			{
				GifThrowHelper.ThrowInvalidImageContentException($"Gif comment length '{num}' exceeds max '{255}' of a comment data block");
			}
			if (skipMetadata)
			{
				stream.Seek(num, SeekOrigin.Current);
				continue;
			}
			using IMemoryOwner<byte> memoryOwner = memoryAllocator.Allocate<byte>(num);
			Span<byte> span = memoryOwner.GetSpan();
			stream.Read(span);
			string value = GifConstants.Encoding.GetString(span);
			stringBuilder.Append(value);
		}
		if (stringBuilder.Length > 0)
		{
			gifMetadata.Comments.Add(stringBuilder.ToString());
		}
	}

	private void ReadFrame<TPixel>(BufferedReadStream stream, ref Image<TPixel>? image, ref ImageFrame<TPixel>? previousFrame) where TPixel : unmanaged, IPixel<TPixel>
	{
		ReadImageDescriptor(stream);
		bool localColorTableFlag = imageDescriptor.LocalColorTableFlag;
		Span<byte> span;
		if (localColorTableFlag)
		{
			int length = (currentLocalColorTableSize = imageDescriptor.LocalColorTableSize * 3);
			if (currentLocalColorTable == null)
			{
				currentLocalColorTable = configuration.MemoryAllocator.Allocate<byte>(768, AllocationOptions.Clean);
			}
			span = currentLocalColorTable.GetSpan();
			stream.Read(span.Slice(0, length));
		}
		Span<byte> span2 = default(Span<byte>);
		if (localColorTableFlag)
		{
			span = currentLocalColorTable.GetSpan();
			span2 = span.Slice(0, currentLocalColorTableSize);
		}
		else if (globalColorTable != null)
		{
			span2 = globalColorTable.GetSpan();
		}
		ReadOnlySpan<Rgb24> colorTable = MemoryMarshal.Cast<byte, Rgb24>(span2);
		ReadFrameColors(stream, ref image, ref previousFrame, colorTable, in imageDescriptor);
		SkipBlock(stream);
	}

	private void ReadFrameColors<TPixel>(BufferedReadStream stream, ref Image<TPixel>? image, ref ImageFrame<TPixel>? previousFrame, ReadOnlySpan<Rgb24> colorTable, in GifImageDescriptor descriptor) where TPixel : unmanaged, IPixel<TPixel>
	{
		int width = logicalScreenDescriptor.Width;
		int height = logicalScreenDescriptor.Height;
		bool transparencyFlag = graphicsControlExtension.TransparencyFlag;
		ImageFrame<TPixel> imageFrame = null;
		ImageFrame<TPixel> imageFrame2 = null;
		ImageFrame<TPixel> imageFrame3;
		if (previousFrame == null)
		{
			if (!transparencyFlag)
			{
				image = new Image<TPixel>(configuration, width, height, Color.Black.ToPixel<TPixel>(), metadata);
			}
			else
			{
				image = new Image<TPixel>(configuration, width, height, metadata);
			}
			SetFrameMetadata(image.Frames.RootFrame.Metadata);
			imageFrame3 = image.Frames.RootFrame;
		}
		else
		{
			if (graphicsControlExtension.DisposalMethod == GifDisposalMethod.RestoreToPrevious)
			{
				imageFrame = previousFrame;
			}
			imageFrame2 = image.Frames.AddFrame(previousFrame);
			SetFrameMetadata(imageFrame2.Metadata);
			imageFrame3 = imageFrame2;
			RestoreToBackground(imageFrame3);
		}
		if (colorTable.Length == 0)
		{
			return;
		}
		int num = 0;
		int num2 = 8;
		int num3 = 0;
		int top = descriptor.Top;
		int num4 = top + descriptor.Height;
		int left = descriptor.Left;
		int num5 = left + descriptor.Width;
		byte transparencyIndex = graphicsControlExtension.TransparencyIndex;
		int num6 = colorTable.Length - 1;
		using IMemoryOwner<byte> memoryOwner = memoryAllocator.Allocate<byte>(descriptor.Width);
		Span<byte> span = memoryOwner.Memory.Span;
		ref byte reference = ref MemoryMarshal.GetReference<byte>(span);
		int minCodeSize = stream.ReadByte();
		if (LzwDecoder.IsValidMinCodeSize(minCodeSize))
		{
			using LzwDecoder lzwDecoder = new LzwDecoder(configuration.MemoryAllocator, stream, minCodeSize);
			for (int i = top; i < num4 && i < height; i++)
			{
				int y;
				if (descriptor.InterlaceFlag)
				{
					if (num3 >= descriptor.Height)
					{
						num++;
						switch (num)
						{
						case 1:
							num3 = 4;
							break;
						case 2:
							num3 = 2;
							num2 = 4;
							break;
						case 3:
							num3 = 1;
							num2 = 2;
							break;
						}
					}
					y = Math.Min(num3 + descriptor.Top, image.Height);
					num3 += num2;
				}
				else
				{
					y = i;
				}
				lzwDecoder.DecodePixelRow(span);
				ref TPixel reference2 = ref MemoryMarshal.GetReference<TPixel>(imageFrame3.PixelBuffer.DangerousGetRowSpan(y));
				if (!transparencyFlag)
				{
					for (int j = left; j < num5 && j < width; j++)
					{
						int index = Numerics.Clamp(Unsafe.Add(ref reference, (uint)(j - left)), 0, num6);
						ref TPixel reference3 = ref Unsafe.Add(ref reference2, (uint)j);
						Rgb24 source = colorTable[index];
						reference3.FromRgb24(source);
					}
					continue;
				}
				for (int k = left; k < num5 && k < width; k++)
				{
					int num7 = Unsafe.Add(ref reference, (uint)(k - left));
					if (num7 <= num6 && num7 != transparencyIndex)
					{
						ref TPixel reference4 = ref Unsafe.Add(ref reference2, (uint)k);
						Rgb24 source2 = colorTable[num7];
						reference4.FromRgb24(source2);
					}
				}
			}
		}
		if (imageFrame != null)
		{
			previousFrame = imageFrame;
			return;
		}
		previousFrame = imageFrame2 ?? image.Frames.RootFrame;
		if (graphicsControlExtension.DisposalMethod == GifDisposalMethod.RestoreToBackground)
		{
			restoreArea = new Rectangle(descriptor.Left, descriptor.Top, descriptor.Width, descriptor.Height);
		}
	}

	private void ReadFrameMetadata(BufferedReadStream stream, List<ImageFrameMetadata> frameMetadata, ref ImageFrameMetadata? previousFrame)
	{
		ReadImageDescriptor(stream);
		if (imageDescriptor.LocalColorTableFlag)
		{
			int length = (currentLocalColorTableSize = imageDescriptor.LocalColorTableSize * 3);
			if (currentLocalColorTable == null)
			{
				currentLocalColorTable = configuration.MemoryAllocator.Allocate<byte>(768, AllocationOptions.Clean);
			}
			stream.Read(currentLocalColorTable.GetSpan().Slice(0, length));
		}
		int minCodeSize = stream.ReadByte();
		if (LzwDecoder.IsValidMinCodeSize(minCodeSize))
		{
			using LzwDecoder lzwDecoder = new LzwDecoder(configuration.MemoryAllocator, stream, minCodeSize);
			lzwDecoder.SkipIndices(imageDescriptor.Width * imageDescriptor.Height);
		}
		ImageFrameMetadata imageFrameMetadata = new ImageFrameMetadata();
		frameMetadata.Add(imageFrameMetadata);
		SetFrameMetadata(imageFrameMetadata);
		previousFrame = imageFrameMetadata;
		SkipBlock(stream);
	}

	private void RestoreToBackground<TPixel>(ImageFrame<TPixel> frame) where TPixel : unmanaged, IPixel<TPixel>
	{
		Rectangle? rectangle = restoreArea;
		if (rectangle.HasValue)
		{
			Rectangle rectangle2 = Rectangle.Intersect(frame.Bounds(), restoreArea.Value);
			frame.PixelBuffer.GetRegion(rectangle2).Clear();
			restoreArea = null;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void SetFrameMetadata(ImageFrameMetadata metadata)
	{
		if (logicalScreenDescriptor.GlobalColorTableFlag && logicalScreenDescriptor.GlobalColorTableSize > 0)
		{
			metadata.GetGifMetadata().ColorTableMode = GifColorTableMode.Global;
		}
		if (imageDescriptor.LocalColorTableFlag && imageDescriptor.LocalColorTableSize > 0)
		{
			GifFrameMetadata gifFrameMetadata = metadata.GetGifMetadata();
			gifFrameMetadata.ColorTableMode = GifColorTableMode.Local;
			Color[] array = new Color[imageDescriptor.LocalColorTableSize];
			ReadOnlySpan<Rgb24> readOnlySpan = MemoryMarshal.Cast<byte, Rgb24>(currentLocalColorTable.GetSpan().Slice(0, currentLocalColorTableSize));
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new Color(readOnlySpan[i]);
			}
			gifFrameMetadata.LocalColorTable = array;
		}
		if (graphicsControlExtension != default(GifGraphicControlExtension))
		{
			GifFrameMetadata gifFrameMetadata2 = metadata.GetGifMetadata();
			gifFrameMetadata2.HasTransparency = graphicsControlExtension.TransparencyFlag;
			gifFrameMetadata2.TransparencyIndex = graphicsControlExtension.TransparencyIndex;
			gifFrameMetadata2.FrameDelay = graphicsControlExtension.DelayTime;
			gifFrameMetadata2.DisposalMethod = graphicsControlExtension.DisposalMethod;
		}
	}

	[MemberNotNull("metadata")]
	[MemberNotNull("gifMetadata")]
	private void ReadLogicalScreenDescriptorAndGlobalColorTable(BufferedReadStream stream)
	{
		stream.Skip(6);
		ReadLogicalScreenDescriptor(stream);
		ImageMetadata imageMetadata = new ImageMetadata();
		if (logicalScreenDescriptor.PixelAspectRatio > 0)
		{
			imageMetadata.ResolutionUnits = PixelResolutionUnit.AspectRatio;
			float num = (float)(logicalScreenDescriptor.PixelAspectRatio + 15) / 64f;
			if (num > 1f)
			{
				imageMetadata.HorizontalResolution = num;
				imageMetadata.VerticalResolution = 1.0;
			}
			else
			{
				imageMetadata.VerticalResolution = 1f / num;
				imageMetadata.HorizontalResolution = 1.0;
			}
		}
		metadata = imageMetadata;
		gifMetadata = imageMetadata.GetGifMetadata();
		gifMetadata.ColorTableMode = ((!logicalScreenDescriptor.GlobalColorTableFlag) ? GifColorTableMode.Local : GifColorTableMode.Global);
		if (logicalScreenDescriptor.GlobalColorTableFlag)
		{
			int num2 = logicalScreenDescriptor.GlobalColorTableSize * 3;
			if (num2 > 0)
			{
				globalColorTable = memoryAllocator.Allocate<byte>(num2, AllocationOptions.Clean);
				Span<byte> span = globalColorTable.GetSpan();
				stream.Read(span);
				Color[] array = new Color[logicalScreenDescriptor.GlobalColorTableSize];
				ReadOnlySpan<Rgb24> readOnlySpan = MemoryMarshal.Cast<byte, Rgb24>(span);
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = new Color(readOnlySpan[i]);
				}
				gifMetadata.GlobalColorTable = array;
			}
		}
		gifMetadata.BackgroundColorIndex = logicalScreenDescriptor.BackgroundColorIndex;
	}
}
