using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using SixLabors.ImageSharp.Common.Helpers;
using SixLabors.ImageSharp.Formats.Jpeg.Components;
using SixLabors.ImageSharp.Formats.Jpeg.Components.Decoder;
using SixLabors.ImageSharp.IO;
using SixLabors.ImageSharp.Memory;
using SixLabors.ImageSharp.Metadata;
using SixLabors.ImageSharp.Metadata.Profiles.Exif;
using SixLabors.ImageSharp.Metadata.Profiles.Icc;
using SixLabors.ImageSharp.Metadata.Profiles.Iptc;
using SixLabors.ImageSharp.Metadata.Profiles.Xmp;

namespace SixLabors.ImageSharp.Formats.Jpeg;

internal sealed class JpegDecoderCore : ImageDecoderCore, IRawJpegData, IDisposable
{
	private bool hasExif;

	private byte[] exifData;

	private bool hasIcc;

	private byte[] iccData;

	private bool hasIptc;

	private byte[] iptcData;

	private bool hasXmp;

	private byte[] xmpData;

	private bool hasAdobeMarker;

	private JFifMarker jFif;

	private AdobeMarker adobe;

	private IJpegScanDecoder scanDecoder;

	private List<ArithmeticDecodingTable> arithmeticDecodingTables;

	private int? resetInterval;

	private readonly Configuration configuration;

	private readonly bool skipMetadata;

	private readonly JpegDecoderResizeMode resizeMode;

	private static ReadOnlySpan<byte> SupportedPrecisions => new byte[2] { 8, 12 };

	public JpegFrame Frame { get; private set; }

	public ImageMetadata Metadata { get; private set; }

	public JpegColorSpace ColorSpace { get; private set; }

	public JpegComponent[] Components => Frame.Components;

	JpegComponent[] IRawJpegData.Components => Components;

	public Block8x8F[] QuantizationTables { get; private set; }

	public JpegDecoderCore(JpegDecoderOptions options)
		: base(options.GeneralOptions)
	{
		resizeMode = options.ResizeMode;
		configuration = options.GeneralOptions.Configuration;
		skipMetadata = options.GeneralOptions.SkipMetadata;
	}

	public static JpegFileMarker FindNextFileMarker(BufferedReadStream stream)
	{
		while (true)
		{
			int num = stream.ReadByte();
			switch (num)
			{
			default:
				continue;
			case -1:
				return new JpegFileMarker(217, stream.Length - 2);
			case 255:
				break;
			}
			while (true)
			{
				bool flag;
				switch (num)
				{
				case 255:
					num = stream.ReadByte();
					if (num != -1)
					{
						continue;
					}
					return new JpegFileMarker(217, stream.Length - 2);
				default:
					flag = true;
					goto IL_006b;
				case 0:
				case 208:
				case 209:
				case 210:
				case 211:
				case 212:
				case 213:
				case 214:
				case 215:
					{
						flag = false;
						goto IL_006b;
					}
					IL_006b:
					if (flag)
					{
						return new JpegFileMarker((byte)num, stream.Position - 2);
					}
					break;
				}
				break;
			}
		}
	}

	protected override Image<TPixel> Decode<TPixel>(BufferedReadStream stream, CancellationToken cancellationToken)
	{
		using SpectralConverter<TPixel> spectralConverter = new SpectralConverter<TPixel>(configuration, (resizeMode == JpegDecoderResizeMode.ScaleOnly) ? ((Size?)null) : base.Options.TargetSize);
		ParseStream(stream, spectralConverter, cancellationToken);
		InitExifProfile();
		InitIccProfile();
		InitIptcProfile();
		InitXmpProfile();
		InitDerivedMetadataProperties();
		return new Image<TPixel>(configuration, spectralConverter.GetPixelBuffer(cancellationToken), Metadata);
	}

	protected override ImageInfo Identify(BufferedReadStream stream, CancellationToken cancellationToken)
	{
		ParseStream(stream, null, cancellationToken);
		InitExifProfile();
		InitIccProfile();
		InitIptcProfile();
		InitXmpProfile();
		InitDerivedMetadataProperties();
		Size pixelSize = Frame.PixelSize;
		return new ImageInfo(new PixelTypeInfo(Frame.BitsPerPixel), new Size(pixelSize.Width, pixelSize.Height), Metadata);
	}

	public void LoadTables(byte[] tableBytes, IJpegScanDecoder scanDecoder)
	{
		Metadata = new ImageMetadata();
		QuantizationTables = new Block8x8F[4];
		this.scanDecoder = scanDecoder;
		if (tableBytes.Length < 4)
		{
			JpegThrowHelper.ThrowInvalidImageContentException("Not enough data to read marker");
		}
		using MemoryStream stream = new MemoryStream(tableBytes);
		using BufferedReadStream bufferedReadStream = new BufferedReadStream(configuration, stream);
		Span<byte> span = stackalloc byte[2];
		bufferedReadStream.Read(span);
		if (new JpegFileMarker(span[1], 0L).Marker != 216)
		{
			JpegThrowHelper.ThrowInvalidImageContentException("Missing SOI marker.");
		}
		bufferedReadStream.Read(span);
		JpegFileMarker jpegFileMarker = new JpegFileMarker(span[1], (int)bufferedReadStream.Position - 2);
		while (jpegFileMarker.Marker != 217 || (jpegFileMarker.Marker == 217 && jpegFileMarker.Invalid))
		{
			if (!jpegFileMarker.Invalid)
			{
				int num = ReadUint16(bufferedReadStream, span) - 2;
				if (bufferedReadStream.RemainingBytes < (uint)num)
				{
					JpegThrowHelper.ThrowNotEnoughBytesForMarker(jpegFileMarker.Marker);
				}
				switch (jpegFileMarker.Marker)
				{
				case 196:
					ProcessDefineHuffmanTablesMarker(bufferedReadStream, num);
					break;
				case 219:
					ProcessDefineQuantizationTablesMarker(bufferedReadStream, num);
					break;
				case 221:
					ProcessDefineRestartIntervalMarker(bufferedReadStream, num, span);
					break;
				case 217:
					return;
				}
			}
			if (bufferedReadStream.Read(span) != 2)
			{
				JpegThrowHelper.ThrowInvalidImageContentException("Not enough data to read marker");
			}
			jpegFileMarker = new JpegFileMarker(span[1], 0L);
		}
	}

	internal void ParseStream(BufferedReadStream stream, SpectralConverter spectralConverter, CancellationToken cancellationToken)
	{
		bool flag = spectralConverter == null;
		if (scanDecoder == null)
		{
			scanDecoder = new HuffmanScanDecoder(stream, spectralConverter, cancellationToken);
		}
		Metadata = new ImageMetadata();
		Span<byte> span = stackalloc byte[2];
		stream.Read(span);
		if (new JpegFileMarker(span[1], 0L).Marker != 216)
		{
			JpegThrowHelper.ThrowInvalidImageContentException("Missing SOI marker.");
		}
		JpegFileMarker frameMarker = FindNextFileMarker(stream);
		if (QuantizationTables == null)
		{
			Block8x8F[] array = (QuantizationTables = new Block8x8F[4]);
		}
		while (frameMarker.Marker != 217)
		{
			cancellationToken.ThrowIfCancellationRequested();
			if (!frameMarker.Invalid)
			{
				int num = ReadUint16(stream, span) - 2;
				if (stream.RemainingBytes < (uint)num)
				{
					if ((flag && Metadata != null && Frame != null) || (Metadata != null && Frame != null && spectralConverter.HasPixelBuffer()))
					{
						return;
					}
					JpegThrowHelper.ThrowNotEnoughBytesForMarker(frameMarker.Marker);
				}
				switch (frameMarker.Marker)
				{
				case 192:
				case 193:
				case 194:
					ProcessStartOfFrameMarker(stream, num, in frameMarker, ComponentType.Huffman, flag);
					break;
				case 201:
				case 202:
				case 205:
				case 206:
					scanDecoder = new ArithmeticScanDecoder(stream, spectralConverter, cancellationToken);
					if (resetInterval.HasValue)
					{
						scanDecoder.ResetInterval = resetInterval.Value;
					}
					ProcessStartOfFrameMarker(stream, num, in frameMarker, ComponentType.Arithmetic, flag);
					break;
				case 197:
					JpegThrowHelper.ThrowNotSupportedException("Decoding jpeg files with differential sequential DCT is not supported.");
					break;
				case 198:
					JpegThrowHelper.ThrowNotSupportedException("Decoding jpeg files with differential progressive DCT is not supported.");
					break;
				case 195:
				case 199:
					JpegThrowHelper.ThrowNotSupportedException("Decoding lossless jpeg files is not supported.");
					break;
				case 203:
				case 207:
					JpegThrowHelper.ThrowNotSupportedException("Decoding jpeg files with lossless arithmetic coding is not supported.");
					break;
				case 218:
					if (!flag)
					{
						ProcessStartOfScanMarker(stream, num);
						break;
					}
					return;
				case 196:
					if (flag)
					{
						stream.Skip(num);
					}
					else
					{
						ProcessDefineHuffmanTablesMarker(stream, num);
					}
					break;
				case 219:
					ProcessDefineQuantizationTablesMarker(stream, num);
					break;
				case 221:
					if (flag)
					{
						stream.Skip(num);
					}
					else
					{
						ProcessDefineRestartIntervalMarker(stream, num, span);
					}
					break;
				case 224:
					ProcessApplicationHeaderMarker(stream, num);
					break;
				case 225:
					ProcessApp1Marker(stream, num);
					break;
				case 226:
					ProcessApp2Marker(stream, num);
					break;
				case 227:
				case 228:
				case 229:
				case 230:
				case 231:
				case 232:
				case 233:
				case 234:
				case 235:
				case 236:
					stream.Skip(num);
					break;
				case 237:
					ProcessApp13Marker(stream, num);
					break;
				case 238:
					ProcessApp14Marker(stream, num);
					break;
				case 239:
				case 254:
					stream.Skip(num);
					break;
				case 204:
					if (flag)
					{
						stream.Skip(num);
					}
					else
					{
						ProcessArithmeticTable(stream, num);
					}
					break;
				}
			}
			frameMarker = FindNextFileMarker(stream);
		}
		Metadata.GetJpegMetadata().Interleaved = Frame.Interleaved;
	}

	public void Dispose()
	{
		Frame?.Dispose();
		Frame = null;
		scanDecoder = null;
	}

	internal static JpegColorSpace DeduceJpegColorSpace(byte componentCount, ref AdobeMarker adobeMarker)
	{
		switch (componentCount)
		{
		case 1:
			return JpegColorSpace.Grayscale;
		case 3:
			if (adobeMarker.ColorTransform == 0)
			{
				return JpegColorSpace.RGB;
			}
			return JpegColorSpace.YCbCr;
		case 4:
			if (adobeMarker.ColorTransform == 2)
			{
				return JpegColorSpace.Ycck;
			}
			return JpegColorSpace.Cmyk;
		default:
			JpegThrowHelper.ThrowNotSupportedComponentCount(componentCount);
			return JpegColorSpace.Grayscale;
		}
	}

	internal static JpegColorSpace DeduceJpegColorSpace(byte componentCount)
	{
		switch (componentCount)
		{
		case 1:
			return JpegColorSpace.Grayscale;
		case 3:
			return JpegColorSpace.YCbCr;
		case 4:
			return JpegColorSpace.Cmyk;
		default:
			JpegThrowHelper.ThrowNotSupportedComponentCount(componentCount);
			return JpegColorSpace.Grayscale;
		}
	}

	private JpegEncodingColor DeduceJpegColorType()
	{
		switch (ColorSpace)
		{
		case JpegColorSpace.Grayscale:
			return JpegEncodingColor.Luminance;
		case JpegColorSpace.RGB:
			return JpegEncodingColor.Rgb;
		case JpegColorSpace.YCbCr:
			if (Frame.Components[0].HorizontalSamplingFactor == 1 && Frame.Components[0].VerticalSamplingFactor == 1 && Frame.Components[1].HorizontalSamplingFactor == 1 && Frame.Components[1].VerticalSamplingFactor == 1 && Frame.Components[2].HorizontalSamplingFactor == 1 && Frame.Components[2].VerticalSamplingFactor == 1)
			{
				return JpegEncodingColor.YCbCrRatio444;
			}
			if (Frame.Components[0].HorizontalSamplingFactor == 2 && Frame.Components[0].VerticalSamplingFactor == 1 && Frame.Components[1].HorizontalSamplingFactor == 1 && Frame.Components[1].VerticalSamplingFactor == 1 && Frame.Components[2].HorizontalSamplingFactor == 1 && Frame.Components[2].VerticalSamplingFactor == 1)
			{
				return JpegEncodingColor.YCbCrRatio422;
			}
			if (Frame.Components[0].HorizontalSamplingFactor == 2 && Frame.Components[0].VerticalSamplingFactor == 2 && Frame.Components[1].HorizontalSamplingFactor == 1 && Frame.Components[1].VerticalSamplingFactor == 1 && Frame.Components[2].HorizontalSamplingFactor == 1 && Frame.Components[2].VerticalSamplingFactor == 1)
			{
				return JpegEncodingColor.YCbCrRatio420;
			}
			if (Frame.Components[0].HorizontalSamplingFactor == 4 && Frame.Components[0].VerticalSamplingFactor == 1 && Frame.Components[1].HorizontalSamplingFactor == 1 && Frame.Components[1].VerticalSamplingFactor == 1 && Frame.Components[2].HorizontalSamplingFactor == 1 && Frame.Components[2].VerticalSamplingFactor == 1)
			{
				return JpegEncodingColor.YCbCrRatio411;
			}
			if (Frame.Components[0].HorizontalSamplingFactor == 4 && Frame.Components[0].VerticalSamplingFactor == 2 && Frame.Components[1].HorizontalSamplingFactor == 1 && Frame.Components[1].VerticalSamplingFactor == 1 && Frame.Components[2].HorizontalSamplingFactor == 1 && Frame.Components[2].VerticalSamplingFactor == 1)
			{
				return JpegEncodingColor.YCbCrRatio410;
			}
			return JpegEncodingColor.YCbCrRatio420;
		case JpegColorSpace.Cmyk:
			return JpegEncodingColor.Cmyk;
		case JpegColorSpace.Ycck:
			return JpegEncodingColor.Ycck;
		default:
			return JpegEncodingColor.YCbCrRatio420;
		}
	}

	private void InitExifProfile()
	{
		if (hasExif)
		{
			Metadata.ExifProfile = new ExifProfile(exifData);
		}
	}

	private void InitIccProfile()
	{
		if (hasIcc)
		{
			IccProfile iccProfile = new IccProfile(iccData);
			if (iccProfile.CheckIsValid())
			{
				Metadata.IccProfile = iccProfile;
			}
		}
	}

	private void InitIptcProfile()
	{
		if (hasIptc)
		{
			Metadata.IptcProfile = new IptcProfile(iptcData);
		}
	}

	private void InitXmpProfile()
	{
		if (hasXmp)
		{
			Metadata.XmpProfile = new XmpProfile(xmpData);
		}
	}

	private void InitDerivedMetadataProperties()
	{
		if (jFif.XDensity > 0 && jFif.YDensity > 0)
		{
			Metadata.HorizontalResolution = jFif.XDensity;
			Metadata.VerticalResolution = jFif.YDensity;
			Metadata.ResolutionUnits = jFif.DensityUnits;
		}
		else if (hasExif)
		{
			double exifResolutionValue = GetExifResolutionValue(ExifTag.XResolution);
			double exifResolutionValue2 = GetExifResolutionValue(ExifTag.YResolution);
			if (exifResolutionValue > 0.0 && exifResolutionValue2 > 0.0)
			{
				Metadata.HorizontalResolution = exifResolutionValue;
				Metadata.VerticalResolution = exifResolutionValue2;
				Metadata.ResolutionUnits = UnitConverter.ExifProfileToResolutionUnit(Metadata.ExifProfile);
			}
		}
	}

	private double GetExifResolutionValue(ExifTag<Rational> tag)
	{
		if (Metadata.ExifProfile.TryGetValue(tag, out IExifValue<Rational> exifValue))
		{
			return exifValue.Value.ToDouble();
		}
		return 0.0;
	}

	private static void ExtendProfile(ref byte[] profile, byte[] extension)
	{
		int num = profile.Length;
		Array.Resize(ref profile, num + extension.Length);
		Buffer.BlockCopy(extension, 0, profile, num, extension.Length);
	}

	private void ProcessApplicationHeaderMarker(BufferedReadStream stream, int remaining)
	{
		if (remaining < 13 || !jFif.Equals(default(JFifMarker)))
		{
			stream.Skip(remaining);
			return;
		}
		Span<byte> span = stackalloc byte[128];
		stream.Read(span, 0, 13);
		JFifMarker.TryParse(span, out jFif);
		remaining -= 13;
		if (remaining > 0)
		{
			if (stream.Position + remaining >= stream.Length)
			{
				JpegThrowHelper.ThrowInvalidImageContentException("Bad App0 Marker length.");
			}
			stream.Skip(remaining);
		}
	}

	private void ProcessApp1Marker(BufferedReadStream stream, int remaining)
	{
		if (remaining < 6 || skipMetadata)
		{
			stream.Skip(remaining);
			return;
		}
		if (stream.Position + remaining >= stream.Length)
		{
			JpegThrowHelper.ThrowInvalidImageContentException("Bad App1 Marker length.");
		}
		Span<byte> span = stackalloc byte[128];
		stream.Read(span, 0, 6);
		remaining -= 6;
		if (ProfileResolver.IsProfile(span, ProfileResolver.ExifMarker))
		{
			hasExif = true;
			byte[] array = new byte[remaining];
			stream.Read(array, 0, remaining);
			if (exifData == null)
			{
				exifData = array;
			}
			else
			{
				ExtendProfile(ref exifData, array);
			}
			remaining = 0;
		}
		if (ProfileResolver.IsProfile(span, ProfileResolver.XmpMarker.Slice(0, 6)))
		{
			if (remaining < 23 || skipMetadata)
			{
				stream.Skip(remaining);
				return;
			}
			stream.Read(span, 6, 23);
			remaining -= 23;
			if (ProfileResolver.IsProfile(span, ProfileResolver.XmpMarker))
			{
				hasXmp = true;
				byte[] array2 = new byte[remaining];
				stream.Read(array2, 0, remaining);
				if (xmpData == null)
				{
					xmpData = array2;
				}
				else
				{
					ExtendProfile(ref xmpData, array2);
				}
				remaining = 0;
			}
		}
		stream.Skip(remaining);
	}

	private void ProcessApp2Marker(BufferedReadStream stream, int remaining)
	{
		if (remaining < 14 || skipMetadata)
		{
			stream.Skip(remaining);
			return;
		}
		Span<byte> span = stackalloc byte[14];
		stream.Read(span);
		remaining -= 14;
		if (ProfileResolver.IsProfile(span, ProfileResolver.IccMarker))
		{
			hasIcc = true;
			byte[] array = new byte[remaining];
			stream.Read(array, 0, remaining);
			if (iccData == null)
			{
				iccData = array;
			}
			else
			{
				ExtendProfile(ref iccData, array);
			}
		}
		else
		{
			stream.Skip(remaining);
		}
	}

	private void ProcessApp13Marker(BufferedReadStream stream, int remaining)
	{
		if (remaining < ProfileResolver.AdobePhotoshopApp13Marker.Length || skipMetadata)
		{
			stream.Skip(remaining);
			return;
		}
		Span<byte> span = stackalloc byte[128];
		stream.Read(span, 0, ProfileResolver.AdobePhotoshopApp13Marker.Length);
		remaining -= ProfileResolver.AdobePhotoshopApp13Marker.Length;
		if (ProfileResolver.IsProfile(span, ProfileResolver.AdobePhotoshopApp13Marker))
		{
			Span<byte> span2 = ((remaining > 128) ? ((Span<byte>)new byte[remaining]) : stackalloc byte[remaining]);
			Span<byte> span3 = span2;
			stream.Read(span3);
			while (span3.Length > 12 && ProfileResolver.IsProfile(span3.Slice(0, 4), ProfileResolver.AdobeImageResourceBlockMarker))
			{
				ref Span<byte> reference = ref span3;
				span3 = reference.Slice(4, reference.Length - 4);
				if (ProfileResolver.IsProfile(span3.Slice(0, 2), ProfileResolver.AdobeIptcMarker))
				{
					int num = ReadImageResourceNameLength(span3);
					int num2 = ReadResourceDataLength(span3, num);
					int num3 = 2 + num + 4;
					if (num2 > 0 && span3.Length >= num3 + num2)
					{
						hasIptc = true;
						iptcData = span3.Slice(num3, num2).ToArray();
						break;
					}
					continue;
				}
				int num4 = ReadImageResourceNameLength(span3);
				int num5 = ReadResourceDataLength(span3, num4);
				int num6 = 2 + num4 + 4;
				if (span3.Length >= num6 + num5)
				{
					reference = ref span3;
					int num7 = num6 + num5;
					span3 = reference.Slice(num7, reference.Length - num7);
					continue;
				}
				break;
			}
		}
		else
		{
			stream.Skip(remaining);
		}
	}

	private void ProcessArithmeticTable(BufferedReadStream stream, int remaining)
	{
		if (arithmeticDecodingTables == null)
		{
			arithmeticDecodingTables = new List<ArithmeticDecodingTable>(4);
		}
		while (remaining > 0)
		{
			int num = stream.ReadByte();
			remaining--;
			byte tableClass = (byte)(num >> 4);
			byte identifier = (byte)(num & 0xF);
			byte conditioningTableValue = (byte)stream.ReadByte();
			remaining--;
			ArithmeticDecodingTable arithmeticDecodingTable = new ArithmeticDecodingTable(tableClass, identifier);
			arithmeticDecodingTable.Configure(conditioningTableValue);
			bool flag = false;
			for (int i = 0; i < arithmeticDecodingTables.Count; i++)
			{
				ArithmeticDecodingTable arithmeticDecodingTable2 = arithmeticDecodingTables[i];
				if (arithmeticDecodingTable2.TableClass == arithmeticDecodingTable.TableClass && arithmeticDecodingTable2.Identifier == arithmeticDecodingTable.Identifier)
				{
					arithmeticDecodingTables[i] = arithmeticDecodingTable;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				arithmeticDecodingTables.Add(arithmeticDecodingTable);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int ReadImageResourceNameLength(Span<byte> blockDataSpan)
	{
		byte b = blockDataSpan[2];
		int num = ((b == 0) ? 2 : b);
		if (num % 2 != 0)
		{
			num++;
		}
		return num;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int ReadResourceDataLength(Span<byte> blockDataSpan, int resourceBlockNameLength)
	{
		return BinaryPrimitives.ReadInt32BigEndian((ReadOnlySpan<byte>)blockDataSpan.Slice(2 + resourceBlockNameLength, 4));
	}

	private void ProcessApp14Marker(BufferedReadStream stream, int remaining)
	{
		if (remaining < 12)
		{
			stream.Skip(remaining);
			return;
		}
		Span<byte> span = stackalloc byte[128];
		stream.Read(span, 0, 12);
		remaining -= 12;
		if (AdobeMarker.TryParse(span, out adobe))
		{
			hasAdobeMarker = true;
		}
		if (remaining > 0)
		{
			stream.Skip(remaining);
		}
	}

	private void ProcessDefineQuantizationTablesMarker(BufferedReadStream stream, int remaining)
	{
		JpegMetadata formatMetadata = Metadata.GetFormatMetadata(JpegFormat.Instance);
		Span<byte> buffer = stackalloc byte[128];
		while (remaining > 0)
		{
			int num = stream.ReadByte();
			int num2 = num & 0xF;
			int num3 = num >> 4;
			if (num2 > 3)
			{
				JpegThrowHelper.ThrowBadQuantizationTableIndex(num2);
			}
			remaining--;
			ref Block8x8F reference = ref QuantizationTables[num2];
			switch (num3)
			{
			case 0:
			{
				if (remaining < 64)
				{
					JpegThrowHelper.ThrowBadMarker("DQT", remaining);
				}
				stream.Read(buffer, 0, 64);
				remaining -= 64;
				for (int j = 0; j < 64; j++)
				{
					reference[(int)ZigZag.ZigZagOrder[j]] = (int)buffer[j];
				}
				break;
			}
			case 1:
			{
				if (remaining < 128)
				{
					JpegThrowHelper.ThrowBadMarker("DQT", remaining);
				}
				stream.Read(buffer, 0, 128);
				remaining -= 128;
				for (int i = 0; i < 64; i++)
				{
					reference[(int)ZigZag.ZigZagOrder[i]] = (buffer[2 * i] << 8) | buffer[2 * i + 1];
				}
				break;
			}
			default:
				JpegThrowHelper.ThrowBadQuantizationTablePrecision(num3);
				break;
			}
			switch (num2)
			{
			case 0:
				formatMetadata.LuminanceQuality = Quantization.EstimateLuminanceQuality(ref reference);
				break;
			case 1:
				formatMetadata.ChrominanceQuality = Quantization.EstimateChrominanceQuality(ref reference);
				break;
			}
		}
	}

	private void ProcessStartOfFrameMarker(BufferedReadStream stream, int remaining, in JpegFileMarker frameMarker, ComponentType decodingComponentType, bool metadataOnly)
	{
		if (Frame != null)
		{
			if (metadataOnly)
			{
				return;
			}
			JpegThrowHelper.ThrowInvalidImageContentException("Multiple SOF markers. Only single frame jpegs supported.");
		}
		Span<byte> buffer = stackalloc byte[128];
		if (stream.Read(buffer, 0, 6) != 6)
		{
			JpegThrowHelper.ThrowInvalidImageContentException("SOF marker does not contain enough data.");
		}
		byte b = buffer[0];
		if (MemoryExtensions.IndexOf<byte>(SupportedPrecisions, b) < 0)
		{
			JpegThrowHelper.ThrowInvalidImageContentException("Only 8-Bit and 12-Bit precision is supported.");
		}
		int num = (buffer[1] << 8) | buffer[2];
		int num2 = (buffer[3] << 8) | buffer[4];
		if (num == 0 || num2 == 0)
		{
			JpegThrowHelper.ThrowInvalidImageDimensions(num2, num);
		}
		byte b2 = buffer[5];
		if (b2 > 4)
		{
			JpegThrowHelper.ThrowNotSupportedComponentCount(b2);
		}
		Frame = new JpegFrame(frameMarker, b, num2, num, b2);
		base.Dimensions = new Size(num2, num);
		Metadata.GetJpegMetadata().Progressive = Frame.Progressive;
		remaining -= 6;
		if (remaining != b2 * 3)
		{
			JpegThrowHelper.ThrowBadMarker("SOFn", remaining);
		}
		stream.Read(buffer, 0, remaining);
		Frame.ComponentIds = new byte[b2];
		Frame.ComponentOrder = new byte[b2];
		Frame.Components = new JpegComponent[b2];
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		for (int i = 0; i < Frame.Components.Length; i++)
		{
			byte b3 = buffer[num5];
			byte num6 = buffer[num5 + 1];
			int num7 = (num6 >> 4) & 0xF;
			int num8 = num6 & 0xF;
			if (Numerics.IsOutOfRange(num7, 1, 4))
			{
				JpegThrowHelper.ThrowBadSampling(num7);
			}
			if (Numerics.IsOutOfRange(num8, 1, 4))
			{
				JpegThrowHelper.ThrowBadSampling(num8);
			}
			if (num3 < num7)
			{
				num3 = num7;
			}
			if (num4 < num8)
			{
				num4 = num8;
			}
			byte b4 = buffer[num5 + 2];
			if (b4 > 3)
			{
				JpegThrowHelper.ThrowBadQuantizationTableIndex(b4);
			}
			IJpegComponent jpegComponent = ((decodingComponentType == ComponentType.Huffman) ? new JpegComponent(configuration.MemoryAllocator, Frame, b3, num7, num8, b4, i) : new ArithmeticDecodingComponent(configuration.MemoryAllocator, Frame, b3, num7, num8, b4, i));
			Frame.Components[i] = (JpegComponent)jpegComponent;
			Frame.ComponentIds[i] = b3;
			num5 += 3;
		}
		ColorSpace = (hasAdobeMarker ? DeduceJpegColorSpace(b2, ref adobe) : DeduceJpegColorSpace(b2));
		Metadata.GetJpegMetadata().ColorType = DeduceJpegColorType();
		if (!metadataOnly)
		{
			Frame.Init(num3, num4);
			scanDecoder.InjectFrameData(Frame, this);
		}
	}

	private void ProcessDefineHuffmanTablesMarker(BufferedReadStream stream, int remaining)
	{
		HuffmanScanDecoder huffmanScanDecoder = scanDecoder as HuffmanScanDecoder;
		if (huffmanScanDecoder == null)
		{
			JpegThrowHelper.ThrowInvalidImageContentException("missing huffman table data");
		}
		int num = remaining;
		using IMemoryOwner<byte> buffer = configuration.MemoryAllocator.Allocate<byte>(1297);
		Span<byte> span = buffer.GetSpan();
		Span<byte> span2 = span.Slice(0, 17);
		Span<byte> buffer2 = span.Slice(17, 256);
		Span<uint> workspace = MemoryMarshal.Cast<byte, uint>(span.Slice(273, span.Length - 273));
		int num2 = 2;
		while (num2 < remaining)
		{
			byte num3 = (byte)stream.ReadByte();
			int num4 = num3 >> 4;
			int num5 = num3 & 0xF;
			if (num4 > 1)
			{
				JpegThrowHelper.ThrowInvalidImageContentException($"Bad huffman table type: {num4}.");
			}
			if (num5 > 3)
			{
				JpegThrowHelper.ThrowInvalidImageContentException($"Bad huffman table index: {num5}.");
			}
			stream.Read(span2, 1, 16);
			int num6 = 0;
			for (int i = 1; i < 17; i++)
			{
				num6 += span2[i];
			}
			num -= 17;
			if (num6 > 256 || num6 > num)
			{
				JpegThrowHelper.ThrowInvalidImageContentException("Huffman table has excessive length.");
			}
			stream.Read(buffer2, 0, num6);
			num2 += 17 + num6;
			huffmanScanDecoder.BuildHuffmanTable(num4, num5, span2, buffer2.Slice(0, num6), workspace);
		}
	}

	private void ProcessDefineRestartIntervalMarker(BufferedReadStream stream, int remaining, Span<byte> markerBuffer)
	{
		if (remaining != 2)
		{
			JpegThrowHelper.ThrowBadMarker("DRI", remaining);
		}
		resetInterval = ReadUint16(stream, markerBuffer);
		if (scanDecoder != null)
		{
			scanDecoder.ResetInterval = resetInterval.Value;
		}
	}

	private void ProcessStartOfScanMarker(BufferedReadStream stream, int remaining)
	{
		if (Frame == null)
		{
			JpegThrowHelper.ThrowInvalidImageContentException("No readable SOFn (Start Of Frame) marker found.");
		}
		int num = stream.ReadByte();
		if (num == 0 || num > Frame.ComponentCount)
		{
			JpegThrowHelper.ThrowInvalidImageContentException($"Invalid number of components in scan: {num}.");
		}
		int num2 = num * 2;
		if (remaining != 4 + num2)
		{
			JpegThrowHelper.ThrowBadMarker("SOS", remaining);
		}
		Span<byte> buffer = stackalloc byte[128];
		stream.Read(buffer, 0, num2);
		Frame.Interleaved = Frame.ComponentCount == num;
		for (int i = 0; i < num2; i += 2)
		{
			int num3 = buffer[i];
			int num4 = -1;
			for (int j = 0; j < Frame.ComponentIds.Length; j++)
			{
				byte b = Frame.ComponentIds[j];
				if (num3 == b)
				{
					num4 = j;
					break;
				}
			}
			if (num4 == -1)
			{
				JpegThrowHelper.ThrowInvalidImageContentException($"Unknown component id in scan: {num3}.");
			}
			Frame.ComponentOrder[i / 2] = (byte)num4;
			JpegComponent obj = Frame.Components[num4];
			byte num5 = buffer[i + 1];
			int num6 = num5 >> 4;
			int num7 = num5 & 0xF;
			if (num6 >= 4 || num7 >= 4)
			{
				JpegThrowHelper.ThrowInvalidImageContentException($"Invalid huffman table for component:{num3}: dc={num6}, ac={num7}");
			}
			((IJpegComponent)obj).DcTableId = num6;
			((IJpegComponent)obj).AcTableId = num7;
		}
		if (stream.Read(buffer, 0, 3) != 3)
		{
			JpegThrowHelper.ThrowInvalidImageContentException("Not enough data to read progressive scan decoding data");
		}
		scanDecoder.SpectralStart = buffer[0];
		scanDecoder.SpectralEnd = buffer[1];
		int num8 = buffer[2];
		scanDecoder.SuccessiveHigh = num8 >> 4;
		scanDecoder.SuccessiveLow = num8 & 0xF;
		if (scanDecoder is ArithmeticScanDecoder arithmeticScanDecoder)
		{
			arithmeticScanDecoder.InitDecodingTables(arithmeticDecodingTables);
		}
		scanDecoder.ParseEntropyCodedData(num);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static ushort ReadUint16(BufferedReadStream stream, Span<byte> markerBuffer)
	{
		if (stream.Read(markerBuffer, 0, 2) != 2)
		{
			JpegThrowHelper.ThrowInvalidImageContentException("jpeg stream does not contain enough data, could not read ushort.");
		}
		return BinaryPrimitives.ReadUInt16BigEndian((ReadOnlySpan<byte>)markerBuffer);
	}
}
