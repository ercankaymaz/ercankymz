using System;
using System.Buffers.Binary;
using System.IO;
using System.Linq;
using System.Threading;
using SixLabors.ImageSharp.Common.Helpers;
using SixLabors.ImageSharp.Formats.Jpeg.Components;
using SixLabors.ImageSharp.Formats.Jpeg.Components.Decoder;
using SixLabors.ImageSharp.Formats.Jpeg.Components.Encoder;
using SixLabors.ImageSharp.Metadata;
using SixLabors.ImageSharp.Metadata.Profiles.Exif;
using SixLabors.ImageSharp.Metadata.Profiles.Icc;
using SixLabors.ImageSharp.Metadata.Profiles.Iptc;
using SixLabors.ImageSharp.Metadata.Profiles.Xmp;
using SixLabors.ImageSharp.PixelFormats;

namespace SixLabors.ImageSharp.Formats.Jpeg;

internal sealed class JpegEncoderCore
{
	private static readonly JpegFrameConfig[] FrameConfigs = CreateFrameConfigs();

	private readonly JpegEncoder encoder;

	private Stream outputStream;

	public Block8x8F[] QuantizationTables { get; } = new Block8x8F[4];

	public JpegEncoderCore(JpegEncoder encoder)
	{
		this.encoder = encoder;
	}

	public void Encode<TPixel>(Image<TPixel> image, Stream stream, CancellationToken cancellationToken) where TPixel : unmanaged, IPixel<TPixel>
	{
		Guard.NotNull(image, "image");
		Guard.NotNull(stream, "stream");
		if (image.Width >= 65535 || image.Height >= 65535)
		{
			JpegThrowHelper.ThrowDimensionsTooLarge(image.Width, image.Height);
		}
		cancellationToken.ThrowIfCancellationRequested();
		outputStream = stream;
		Span<byte> span = stackalloc byte[20];
		ImageMetadata metadata = image.Metadata;
		JpegMetadata jpegMetadata = metadata.GetJpegMetadata();
		JpegFrameConfig frameConfig = GetFrameConfig(jpegMetadata);
		bool interleaved = encoder.Interleaved ?? jpegMetadata.Interleaved ?? true;
		using SixLabors.ImageSharp.Formats.Jpeg.Components.Encoder.JpegFrame jpegFrame = new SixLabors.ImageSharp.Formats.Jpeg.Components.Encoder.JpegFrame(image, frameConfig, interleaved);
		WriteStartOfImage(span);
		if (!frameConfig.AdobeColorTransformMarkerFlag.HasValue)
		{
			WriteJfifApplicationHeader(metadata, span);
		}
		else
		{
			WriteApp14Marker(frameConfig.AdobeColorTransformMarkerFlag.Value, span);
		}
		WriteProfiles(metadata, span);
		WriteStartOfFrame(image.Width, image.Height, frameConfig, span);
		HuffmanScanEncoder scanEncoder = new HuffmanScanEncoder(jpegFrame.BlocksPerMcu, stream);
		WriteDefineHuffmanTables(frameConfig.HuffmanTables, scanEncoder, span);
		WriteDefineQuantizationTables(frameConfig.QuantizationTables, encoder.Quality, jpegMetadata, span);
		using SixLabors.ImageSharp.Formats.Jpeg.Components.Encoder.SpectralConverter<TPixel> spectralConverter = new SixLabors.ImageSharp.Formats.Jpeg.Components.Encoder.SpectralConverter<TPixel>(jpegFrame, image, QuantizationTables);
		WriteHuffmanScans(jpegFrame, frameConfig, spectralConverter, scanEncoder, span, cancellationToken);
		WriteEndOfImageMarker(span);
		stream.Flush();
	}

	private void WriteStartOfImage(Span<byte> buffer)
	{
		buffer[1] = 216;
		buffer[0] = byte.MaxValue;
		outputStream.Write(buffer, 0, 2);
	}

	private void WriteJfifApplicationHeader(ImageMetadata meta, Span<byte> buffer)
	{
		buffer[10] = 1;
		buffer[0] = byte.MaxValue;
		buffer[1] = 224;
		buffer[2] = 0;
		buffer[3] = 16;
		buffer[4] = 74;
		buffer[5] = 70;
		buffer[6] = 73;
		buffer[7] = 70;
		buffer[8] = 0;
		buffer[9] = 1;
		Span<byte> span = buffer.Slice(12, 2);
		Span<byte> span2 = buffer.Slice(14, 2);
		if (meta.ResolutionUnits == PixelResolutionUnit.PixelsPerMeter)
		{
			buffer[11] = 1;
			BinaryPrimitives.WriteInt16BigEndian(span, (short)Math.Round(UnitConverter.MeterToInch(meta.HorizontalResolution)));
			BinaryPrimitives.WriteInt16BigEndian(span2, (short)Math.Round(UnitConverter.MeterToInch(meta.VerticalResolution)));
		}
		else
		{
			buffer[11] = (byte)meta.ResolutionUnits;
			BinaryPrimitives.WriteInt16BigEndian(span, (short)Math.Round(meta.HorizontalResolution));
			BinaryPrimitives.WriteInt16BigEndian(span2, (short)Math.Round(meta.VerticalResolution));
		}
		buffer[17] = 0;
		buffer[16] = 0;
		outputStream.Write(buffer, 0, 18);
	}

	private void WriteDefineHuffmanTables(JpegHuffmanTableConfig[] tableConfigs, HuffmanScanEncoder scanEncoder, Span<byte> buffer)
	{
		if (tableConfigs == null)
		{
			throw new ArgumentNullException("tableConfigs");
		}
		int num = 2;
		for (int i = 0; i < tableConfigs.Length; i++)
		{
			num += 17 + tableConfigs[i].Table.Values.Length;
		}
		WriteMarkerHeader(196, num, buffer);
		foreach (JpegHuffmanTableConfig jpegHuffmanTableConfig in tableConfigs)
		{
			int num2 = (jpegHuffmanTableConfig.Class << 4) | jpegHuffmanTableConfig.DestinationIndex;
			outputStream.WriteByte((byte)num2);
			outputStream.Write(jpegHuffmanTableConfig.Table.Count);
			outputStream.Write(jpegHuffmanTableConfig.Table.Values);
			scanEncoder.BuildHuffmanTable(jpegHuffmanTableConfig);
		}
	}

	private void WriteApp14Marker(byte colorTransform, Span<byte> buffer)
	{
		WriteMarkerHeader(238, 14, buffer);
		buffer[4] = 101;
		buffer[0] = 65;
		buffer[1] = 100;
		buffer[2] = 111;
		buffer[3] = 98;
		BinaryPrimitives.WriteInt16BigEndian(buffer.Slice(5, 2), (short)100);
		BinaryPrimitives.WriteInt16BigEndian(buffer.Slice(7, 2), (short)0);
		BinaryPrimitives.WriteInt16BigEndian(buffer.Slice(9, 2), (short)0);
		buffer[11] = colorTransform;
		outputStream.Write(buffer.Slice(0, 12));
	}

	private void WriteExifProfile(ExifProfile exifProfile, Span<byte> buffer)
	{
		if (exifProfile == null || exifProfile.Values.Count == 0)
		{
			return;
		}
		byte[] array = exifProfile.ToByteArray();
		if (array.Length != 0)
		{
			int length = ProfileResolver.ExifMarker.Length;
			int num = length + array.Length;
			int num2 = ((num > 65533) ? 65533 : num);
			int app1Length = num2 + 2;
			WriteApp1Header(app1Length, buffer);
			outputStream.Write(ProfileResolver.ExifMarker);
			outputStream.Write(array, 0, num2 - length);
			num -= num2;
			for (int i = 65527; i < array.Length; i += 65527)
			{
				num2 = ((num > 65527) ? 65527 : num);
				app1Length = num2 + 2 + length;
				WriteApp1Header(app1Length, buffer);
				outputStream.Write(ProfileResolver.ExifMarker);
				outputStream.Write(array, i, num2);
				num -= num2;
			}
		}
	}

	private void WriteIptcProfile(IptcProfile iptcProfile, Span<byte> buffer)
	{
		if (iptcProfile == null || !iptcProfile.Values.Any())
		{
			return;
		}
		iptcProfile.UpdateData();
		byte[] data = iptcProfile.Data;
		if (data.Length != 0)
		{
			if (data.Length > 65533)
			{
				throw new ImageFormatException($"Iptc profile size exceeds limit of {65533} bytes");
			}
			int length = 2 + ProfileResolver.AdobePhotoshopApp13Marker.Length + ProfileResolver.AdobeImageResourceBlockMarker.Length + ProfileResolver.AdobeIptcMarker.Length + 2 + 4 + data.Length;
			WriteAppHeader(length, 237, buffer);
			outputStream.Write(ProfileResolver.AdobePhotoshopApp13Marker);
			outputStream.Write(ProfileResolver.AdobeImageResourceBlockMarker);
			outputStream.Write(ProfileResolver.AdobeIptcMarker);
			outputStream.WriteByte(0);
			outputStream.WriteByte(0);
			BinaryPrimitives.WriteInt32BigEndian(buffer, data.Length);
			outputStream.Write(buffer, 0, 4);
			outputStream.Write(data, 0, data.Length);
		}
	}

	private void WriteXmpProfile(XmpProfile xmpProfile, Span<byte> buffer)
	{
		if (xmpProfile == null)
		{
			return;
		}
		byte[] data = xmpProfile.Data;
		if (data == null || data.Length == 0)
		{
			return;
		}
		int num = data.Length;
		int num2 = 0;
		while (num > 0)
		{
			int num3 = num;
			if (num3 > 65504)
			{
				num3 = 65504;
			}
			num -= num3;
			int app1Length = 2 + ProfileResolver.XmpMarker.Length + num3;
			WriteApp1Header(app1Length, buffer);
			outputStream.Write(ProfileResolver.XmpMarker);
			outputStream.Write(data, num2, num3);
			num2 += num3;
		}
	}

	private void WriteApp1Header(int app1Length, Span<byte> buffer)
	{
		WriteAppHeader(app1Length, 225, buffer);
	}

	private void WriteAppHeader(int length, byte appMarker, Span<byte> buffer)
	{
		buffer[0] = byte.MaxValue;
		buffer[1] = appMarker;
		buffer[2] = (byte)((length >> 8) & 0xFF);
		buffer[3] = (byte)(length & 0xFF);
		outputStream.Write(buffer, 0, 4);
	}

	private void WriteIccProfile(IccProfile iccProfile, Span<byte> buffer)
	{
		if (iccProfile == null)
		{
			return;
		}
		byte[] array = iccProfile.ToByteArray();
		if (array == null || array.Length == 0)
		{
			return;
		}
		int num = array.Length;
		int num2 = num / 65519;
		if (num2 * 65519 != num)
		{
			num2++;
		}
		int num3 = 1;
		int num4 = 0;
		while (num > 0)
		{
			int num5 = num;
			if (num5 > 65519)
			{
				num5 = 65519;
			}
			num -= num5;
			buffer[0] = byte.MaxValue;
			buffer[1] = 226;
			int num6 = num5 + 16;
			buffer[2] = (byte)((num6 >> 8) & 0xFF);
			buffer[3] = (byte)(num6 & 0xFF);
			outputStream.Write(buffer, 0, 4);
			buffer[13] = (byte)num2;
			buffer[12] = (byte)num3;
			buffer[11] = 0;
			buffer[0] = 73;
			buffer[1] = 67;
			buffer[2] = 67;
			buffer[3] = 95;
			buffer[4] = 80;
			buffer[5] = 82;
			buffer[6] = 79;
			buffer[7] = 70;
			buffer[8] = 73;
			buffer[9] = 76;
			buffer[10] = 69;
			outputStream.Write(buffer, 0, 14);
			outputStream.Write(array, num4, num5);
			num3++;
			num4 += num5;
		}
	}

	private void WriteProfiles(ImageMetadata metadata, Span<byte> buffer)
	{
		if (metadata != null)
		{
			metadata.SyncProfiles();
			WriteExifProfile(metadata.ExifProfile, buffer);
			WriteXmpProfile(metadata.XmpProfile, buffer);
			WriteIccProfile(metadata.IccProfile, buffer);
			WriteIptcProfile(metadata.IptcProfile, buffer);
		}
	}

	private void WriteStartOfFrame(int width, int height, JpegFrameConfig frame, Span<byte> buffer)
	{
		JpegComponentConfig[] components = frame.Components;
		int length = 8 + 3 * components.Length;
		WriteMarkerHeader(192, length, buffer);
		buffer[5] = (byte)components.Length;
		buffer[0] = 8;
		buffer[1] = (byte)(height >> 8);
		buffer[2] = (byte)(height & 0xFF);
		buffer[3] = (byte)(width >> 8);
		buffer[4] = (byte)(width & 0xFF);
		for (int i = 0; i < components.Length; i++)
		{
			int num = 3 * i;
			Span<byte> span = buffer.Slice(num + 6, 3);
			span[2] = (byte)components[i].QuantizatioTableIndex;
			int num2 = (components[i].HorizontalSampleFactor << 4) | components[i].VerticalSampleFactor;
			span[1] = (byte)num2;
			span[0] = components[i].Id;
		}
		outputStream.Write(buffer, 0, 3 * (components.Length - 1) + 9);
	}

	private void WriteStartOfScan(Span<JpegComponentConfig> components, Span<byte> buffer)
	{
		buffer[1] = 218;
		buffer[0] = byte.MaxValue;
		int num = 6 + 2 * components.Length;
		buffer[4] = (byte)components.Length;
		buffer[3] = (byte)num;
		buffer[2] = 0;
		for (int i = 0; i < components.Length; i++)
		{
			int num2 = 2 * i;
			buffer[num2 + 5] = components[i].Id;
			int num3 = (components[i].DcTableSelector << 4) | components[i].AcTableSelector;
			buffer[num2 + 6] = (byte)num3;
		}
		buffer[num - 1] = 0;
		buffer[num] = 63;
		buffer[num + 1] = 0;
		outputStream.Write(buffer, 0, num + 2);
	}

	private void WriteEndOfImageMarker(Span<byte> buffer)
	{
		buffer[1] = 217;
		buffer[0] = byte.MaxValue;
		outputStream.Write(buffer, 0, 2);
	}

	private void WriteHuffmanScans<TPixel>(SixLabors.ImageSharp.Formats.Jpeg.Components.Encoder.JpegFrame frame, JpegFrameConfig frameConfig, SixLabors.ImageSharp.Formats.Jpeg.Components.Encoder.SpectralConverter<TPixel> spectralConverter, HuffmanScanEncoder encoder, Span<byte> buffer, CancellationToken cancellationToken) where TPixel : unmanaged, IPixel<TPixel>
	{
		if (frame.Components.Length == 1)
		{
			frame.AllocateComponents(fullScan: false);
			WriteStartOfScan(frameConfig.Components, buffer);
			encoder.EncodeScanBaselineSingleComponent(frame.Components[0], spectralConverter, cancellationToken);
			return;
		}
		if (frame.Interleaved)
		{
			frame.AllocateComponents(fullScan: false);
			WriteStartOfScan(frameConfig.Components, buffer);
			encoder.EncodeScanBaselineInterleaved(frameConfig.EncodingColor, frame, spectralConverter, cancellationToken);
			return;
		}
		frame.AllocateComponents(fullScan: true);
		spectralConverter.ConvertFull();
		Span<JpegComponentConfig> span = frameConfig.Components;
		for (int i = 0; i < frame.Components.Length; i++)
		{
			WriteStartOfScan(span.Slice(i, 1), buffer);
			encoder.EncodeScanBaseline(frame.Components[i], cancellationToken);
		}
	}

	private void WriteMarkerHeader(byte marker, int length, Span<byte> buffer)
	{
		buffer[3] = (byte)(length & 0xFF);
		buffer[2] = (byte)(length >> 8);
		buffer[1] = marker;
		buffer[0] = byte.MaxValue;
		outputStream.Write(buffer, 0, 4);
	}

	private void WriteDefineQuantizationTables(JpegQuantizationTableConfig[] configs, int? optionsQuality, JpegMetadata metadata, Span<byte> tmpBuffer)
	{
		int num = configs.Length * 65;
		int length = 2 + num;
		WriteMarkerHeader(219, length, tmpBuffer);
		Span<byte> span = ((num > 256) ? ((Span<byte>)new byte[num]) : stackalloc byte[num]);
		Span<byte> span2 = span;
		int num2 = 0;
		Block8x8F quantTable = default(Block8x8F);
		foreach (JpegQuantizationTableConfig jpegQuantizationTableConfig in configs)
		{
			Block8x8 source = Quantization.ScaleQuantizationTable(GetQualityForTable(jpegQuantizationTableConfig.DestinationIndex, optionsQuality, metadata), jpegQuantizationTableConfig.Table);
			span2[num2++] = (byte)jpegQuantizationTableConfig.DestinationIndex;
			for (int j = 0; j < 64; j++)
			{
				span2[num2++] = (byte)source[ZigZag.ZigZagOrder[j]];
			}
			quantTable.LoadFrom(ref source);
			FloatingPointDCT.AdjustToFDCT(ref quantTable);
			QuantizationTables[jpegQuantizationTableConfig.DestinationIndex] = quantTable;
		}
		outputStream.Write(span2);
		static int GetQualityForTable(int destIndex, int? encoderQuality, JpegMetadata jpegMetadata)
		{
			return destIndex switch
			{
				0 => encoderQuality ?? jpegMetadata.LuminanceQuality ?? 75, 
				1 => encoderQuality ?? jpegMetadata.ChrominanceQuality ?? 75, 
				_ => encoderQuality ?? jpegMetadata.Quality, 
			};
		}
	}

	private JpegFrameConfig GetFrameConfig(JpegMetadata metadata)
	{
		JpegEncodingColor color = encoder.ColorType ?? metadata.ColorType.GetValueOrDefault();
		return Array.Find(FrameConfigs, (JpegFrameConfig cfg) => cfg.EncodingColor == color) ?? throw new ArgumentException("color");
	}

	private static JpegFrameConfig[] CreateFrameConfigs()
	{
		JpegHuffmanTableConfig jpegHuffmanTableConfig = new JpegHuffmanTableConfig(0, 0, HuffmanSpec.LuminanceDC);
		JpegHuffmanTableConfig jpegHuffmanTableConfig2 = new JpegHuffmanTableConfig(1, 0, HuffmanSpec.LuminanceAC);
		JpegHuffmanTableConfig jpegHuffmanTableConfig3 = new JpegHuffmanTableConfig(0, 1, HuffmanSpec.ChrominanceDC);
		JpegHuffmanTableConfig jpegHuffmanTableConfig4 = new JpegHuffmanTableConfig(1, 1, HuffmanSpec.ChrominanceAC);
		JpegQuantizationTableConfig jpegQuantizationTableConfig = new JpegQuantizationTableConfig(0, Quantization.LuminanceTable);
		JpegQuantizationTableConfig jpegQuantizationTableConfig2 = new JpegQuantizationTableConfig(1, Quantization.ChrominanceTable);
		JpegHuffmanTableConfig[] huffmanTables = new JpegHuffmanTableConfig[4] { jpegHuffmanTableConfig, jpegHuffmanTableConfig2, jpegHuffmanTableConfig3, jpegHuffmanTableConfig4 };
		JpegQuantizationTableConfig[] quantTables = new JpegQuantizationTableConfig[2] { jpegQuantizationTableConfig, jpegQuantizationTableConfig2 };
		return new JpegFrameConfig[9]
		{
			new JpegFrameConfig(JpegColorSpace.YCbCr, JpegEncodingColor.YCbCrRatio444, new JpegComponentConfig[3]
			{
				new JpegComponentConfig(1, 1, 1, 0, 0, 0),
				new JpegComponentConfig(2, 1, 1, 1, 1, 1),
				new JpegComponentConfig(3, 1, 1, 1, 1, 1)
			}, huffmanTables, quantTables),
			new JpegFrameConfig(JpegColorSpace.YCbCr, JpegEncodingColor.YCbCrRatio422, new JpegComponentConfig[3]
			{
				new JpegComponentConfig(1, 2, 1, 0, 0, 0),
				new JpegComponentConfig(2, 1, 1, 1, 1, 1),
				new JpegComponentConfig(3, 1, 1, 1, 1, 1)
			}, huffmanTables, quantTables),
			new JpegFrameConfig(JpegColorSpace.YCbCr, JpegEncodingColor.YCbCrRatio420, new JpegComponentConfig[3]
			{
				new JpegComponentConfig(1, 2, 2, 0, 0, 0),
				new JpegComponentConfig(2, 1, 1, 1, 1, 1),
				new JpegComponentConfig(3, 1, 1, 1, 1, 1)
			}, huffmanTables, quantTables),
			new JpegFrameConfig(JpegColorSpace.YCbCr, JpegEncodingColor.YCbCrRatio411, new JpegComponentConfig[3]
			{
				new JpegComponentConfig(1, 4, 1, 0, 0, 0),
				new JpegComponentConfig(2, 1, 1, 1, 1, 1),
				new JpegComponentConfig(3, 1, 1, 1, 1, 1)
			}, huffmanTables, quantTables),
			new JpegFrameConfig(JpegColorSpace.YCbCr, JpegEncodingColor.YCbCrRatio410, new JpegComponentConfig[3]
			{
				new JpegComponentConfig(1, 4, 2, 0, 0, 0),
				new JpegComponentConfig(2, 1, 1, 1, 1, 1),
				new JpegComponentConfig(3, 1, 1, 1, 1, 1)
			}, huffmanTables, quantTables),
			new JpegFrameConfig(JpegColorSpace.Grayscale, JpegEncodingColor.Luminance, new JpegComponentConfig[1]
			{
				new JpegComponentConfig(0, 1, 1, 0, 0, 0)
			}, new JpegHuffmanTableConfig[2] { jpegHuffmanTableConfig, jpegHuffmanTableConfig2 }, new JpegQuantizationTableConfig[1] { jpegQuantizationTableConfig }),
			new JpegFrameConfig(JpegColorSpace.RGB, JpegEncodingColor.Rgb, new JpegComponentConfig[3]
			{
				new JpegComponentConfig(82, 1, 1, 0, 0, 0),
				new JpegComponentConfig(71, 1, 1, 0, 0, 0),
				new JpegComponentConfig(66, 1, 1, 0, 0, 0)
			}, new JpegHuffmanTableConfig[2] { jpegHuffmanTableConfig, jpegHuffmanTableConfig2 }, new JpegQuantizationTableConfig[1] { jpegQuantizationTableConfig })
			{
				AdobeColorTransformMarkerFlag = 0
			},
			new JpegFrameConfig(JpegColorSpace.Cmyk, JpegEncodingColor.Cmyk, new JpegComponentConfig[4]
			{
				new JpegComponentConfig(1, 1, 1, 0, 0, 0),
				new JpegComponentConfig(2, 1, 1, 0, 0, 0),
				new JpegComponentConfig(3, 1, 1, 0, 0, 0),
				new JpegComponentConfig(4, 1, 1, 0, 0, 0)
			}, new JpegHuffmanTableConfig[2] { jpegHuffmanTableConfig, jpegHuffmanTableConfig2 }, new JpegQuantizationTableConfig[1] { jpegQuantizationTableConfig })
			{
				AdobeColorTransformMarkerFlag = 0
			},
			new JpegFrameConfig(JpegColorSpace.Ycck, JpegEncodingColor.Ycck, new JpegComponentConfig[4]
			{
				new JpegComponentConfig(1, 1, 1, 0, 0, 0),
				new JpegComponentConfig(2, 1, 1, 0, 0, 0),
				new JpegComponentConfig(3, 1, 1, 0, 0, 0),
				new JpegComponentConfig(4, 1, 1, 0, 0, 0)
			}, new JpegHuffmanTableConfig[2] { jpegHuffmanTableConfig, jpegHuffmanTableConfig2 }, new JpegQuantizationTableConfig[1] { jpegQuantizationTableConfig })
			{
				AdobeColorTransformMarkerFlag = 2
			}
		};
	}
}
