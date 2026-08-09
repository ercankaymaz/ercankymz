using System;
using System.Collections.Generic;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg.ScanDecoder;

internal abstract class JpegArithmeticScanDecoder : JpegScanDecoder
{
	private int _c;

	private int _a;

	private int _ct;

	private byte[] _fixedBin = new byte[4] { 113, 0, 0, 0 };

	private List<JpegArithmeticStatistics> _statistics = new List<JpegArithmeticStatistics>();

	private static readonly int[] s_arithmeticTable = new int[114]
	{
		Pack(0, 23069, 1, 1, 1),
		Pack(1, 9606, 14, 2, 0),
		Pack(2, 4372, 16, 3, 0),
		Pack(3, 2059, 18, 4, 0),
		Pack(4, 984, 20, 5, 0),
		Pack(5, 474, 23, 6, 0),
		Pack(6, 229, 25, 7, 0),
		Pack(7, 111, 28, 8, 0),
		Pack(8, 54, 30, 9, 0),
		Pack(9, 26, 33, 10, 0),
		Pack(10, 13, 35, 11, 0),
		Pack(11, 6, 9, 12, 0),
		Pack(12, 3, 10, 13, 0),
		Pack(13, 1, 12, 13, 0),
		Pack(14, 23167, 15, 15, 1),
		Pack(15, 16165, 36, 16, 0),
		Pack(16, 11506, 38, 17, 0),
		Pack(17, 8316, 39, 18, 0),
		Pack(18, 6073, 40, 19, 0),
		Pack(19, 4482, 42, 20, 0),
		Pack(20, 3311, 43, 21, 0),
		Pack(21, 2465, 45, 22, 0),
		Pack(22, 1839, 46, 23, 0),
		Pack(23, 1372, 48, 24, 0),
		Pack(24, 1030, 49, 25, 0),
		Pack(25, 771, 51, 26, 0),
		Pack(26, 576, 52, 27, 0),
		Pack(27, 433, 54, 28, 0),
		Pack(28, 324, 56, 29, 0),
		Pack(29, 245, 57, 30, 0),
		Pack(30, 183, 59, 31, 0),
		Pack(31, 138, 60, 32, 0),
		Pack(32, 104, 62, 33, 0),
		Pack(33, 78, 63, 34, 0),
		Pack(34, 59, 32, 35, 0),
		Pack(35, 44, 33, 9, 0),
		Pack(36, 23265, 37, 37, 1),
		Pack(37, 18508, 64, 38, 0),
		Pack(38, 14861, 65, 39, 0),
		Pack(39, 12017, 67, 40, 0),
		Pack(40, 9759, 68, 41, 0),
		Pack(41, 7987, 69, 42, 0),
		Pack(42, 6568, 70, 43, 0),
		Pack(43, 5400, 72, 44, 0),
		Pack(44, 4471, 73, 45, 0),
		Pack(45, 3700, 74, 46, 0),
		Pack(46, 3067, 75, 47, 0),
		Pack(47, 2552, 77, 48, 0),
		Pack(48, 2145, 78, 49, 0),
		Pack(49, 1798, 79, 50, 0),
		Pack(50, 1485, 48, 51, 0),
		Pack(51, 1246, 50, 52, 0),
		Pack(52, 1039, 50, 53, 0),
		Pack(53, 867, 51, 54, 0),
		Pack(54, 724, 52, 55, 0),
		Pack(55, 604, 53, 56, 0),
		Pack(56, 504, 54, 57, 0),
		Pack(57, 420, 55, 58, 0),
		Pack(58, 352, 56, 59, 0),
		Pack(59, 293, 57, 60, 0),
		Pack(60, 246, 58, 61, 0),
		Pack(61, 203, 59, 62, 0),
		Pack(62, 171, 61, 63, 0),
		Pack(63, 143, 61, 32, 0),
		Pack(64, 23314, 65, 65, 1),
		Pack(65, 19716, 80, 66, 0),
		Pack(66, 16684, 81, 67, 0),
		Pack(67, 14296, 82, 68, 0),
		Pack(68, 12264, 83, 69, 0),
		Pack(69, 10556, 84, 70, 0),
		Pack(70, 9081, 86, 71, 0),
		Pack(71, 7903, 87, 72, 0),
		Pack(72, 6825, 87, 73, 0),
		Pack(73, 5966, 72, 74, 0),
		Pack(74, 5156, 72, 75, 0),
		Pack(75, 4508, 74, 76, 0),
		Pack(76, 3947, 74, 77, 0),
		Pack(77, 3409, 75, 78, 0),
		Pack(78, 2998, 77, 79, 0),
		Pack(79, 2624, 77, 48, 0),
		Pack(80, 22578, 80, 81, 1),
		Pack(81, 19740, 88, 82, 0),
		Pack(82, 17294, 89, 83, 0),
		Pack(83, 15325, 90, 84, 0),
		Pack(84, 13550, 91, 85, 0),
		Pack(85, 11950, 92, 86, 0),
		Pack(86, 10650, 93, 87, 0),
		Pack(87, 9494, 86, 71, 0),
		Pack(88, 21872, 88, 89, 1),
		Pack(89, 19625, 95, 90, 0),
		Pack(90, 17625, 96, 91, 0),
		Pack(91, 15906, 97, 92, 0),
		Pack(92, 14372, 99, 93, 0),
		Pack(93, 12980, 99, 94, 0),
		Pack(94, 11799, 93, 86, 0),
		Pack(95, 22184, 95, 96, 1),
		Pack(96, 20294, 101, 97, 0),
		Pack(97, 18405, 102, 98, 0),
		Pack(98, 16847, 103, 99, 0),
		Pack(99, 15421, 104, 100, 0),
		Pack(100, 14174, 99, 93, 0),
		Pack(101, 21041, 105, 102, 0),
		Pack(102, 19471, 106, 103, 0),
		Pack(103, 17977, 107, 104, 0),
		Pack(104, 16734, 103, 99, 0),
		Pack(105, 22055, 105, 106, 1),
		Pack(106, 20711, 108, 107, 0),
		Pack(107, 19333, 109, 103, 0),
		Pack(108, 21911, 110, 109, 0),
		Pack(109, 20559, 111, 107, 0),
		Pack(110, 23056, 110, 111, 1),
		Pack(111, 21794, 112, 109, 0),
		Pack(112, 23019, 112, 111, 1),
		Pack(113, 23069, 113, 113, 0)
	};

	protected JpegDecoder Decoder { get; private set; }

	public JpegArithmeticScanDecoder(JpegDecoder decoder)
	{
		Decoder = decoder;
		Reset();
	}

	protected ref byte GetFixedBinReference()
	{
		return ref _fixedBin[0];
	}

	private JpegArithmeticStatistics CreateOrGetStatisticsBin(bool dc, byte identifier, bool reset = false)
	{
		foreach (JpegArithmeticStatistics statistic in _statistics)
		{
			if (statistic.IsDcStatistics == dc && statistic.Identifier == identifier)
			{
				if (reset)
				{
					statistic.Reset();
				}
				return statistic;
			}
		}
		JpegArithmeticStatistics jpegArithmeticStatistics = new JpegArithmeticStatistics(dc, identifier);
		_statistics.Add(jpegArithmeticStatistics);
		return jpegArithmeticStatistics;
	}

	protected int InitDecodeComponents(JpegFrameHeader frameHeader, JpegScanHeader scanHeader, Span<JpegArithmeticDecodingComponent> components)
	{
		int num = 1;
		int num2 = 1;
		JpegFrameComponentSpecificationParameters[] components2 = frameHeader.Components;
		for (int i = 0; i < components2.Length; i++)
		{
			JpegFrameComponentSpecificationParameters jpegFrameComponentSpecificationParameters = components2[i];
			num = Math.Max(num, jpegFrameComponentSpecificationParameters.HorizontalSamplingFactor);
			num2 = Math.Max(num2, jpegFrameComponentSpecificationParameters.VerticalSamplingFactor);
		}
		if (components.Length < scanHeader.NumberOfComponents)
		{
			throw new InvalidOperationException();
		}
		for (int j = 0; j < scanHeader.NumberOfComponents; j++)
		{
			JpegScanComponentSpecificationParameters jpegScanComponentSpecificationParameters = scanHeader.Components[j];
			int componentIndex = 0;
			JpegFrameComponentSpecificationParameters? jpegFrameComponentSpecificationParameters2 = null;
			for (int k = 0; k < frameHeader.NumberOfComponents; k++)
			{
				JpegFrameComponentSpecificationParameters value = frameHeader.Components[k];
				if (jpegScanComponentSpecificationParameters.ScanComponentSelector == value.Identifier)
				{
					componentIndex = k;
					jpegFrameComponentSpecificationParameters2 = value;
				}
			}
			if (!jpegFrameComponentSpecificationParameters2.HasValue)
			{
				JpegScanDecoder.ThrowInvalidDataException("The specified component is missing.");
			}
			JpegArithmeticDecodingComponent jpegArithmeticDecodingComponent = components[j];
			if (jpegArithmeticDecodingComponent == null)
			{
				jpegArithmeticDecodingComponent = (components[j] = new JpegArithmeticDecodingComponent());
			}
			JpegArithmeticDecodingTable arithmeticTable = Decoder.GetArithmeticTable(isDcTable: true, jpegScanComponentSpecificationParameters.DcEntropyCodingTableSelector);
			JpegArithmeticDecodingTable arithmeticTable2 = Decoder.GetArithmeticTable(isDcTable: false, jpegScanComponentSpecificationParameters.AcEntropyCodingTableSelector);
			jpegArithmeticDecodingComponent.ComponentIndex = componentIndex;
			jpegArithmeticDecodingComponent.HorizontalSamplingFactor = jpegFrameComponentSpecificationParameters2.GetValueOrDefault().HorizontalSamplingFactor;
			jpegArithmeticDecodingComponent.VerticalSamplingFactor = jpegFrameComponentSpecificationParameters2.GetValueOrDefault().VerticalSamplingFactor;
			jpegArithmeticDecodingComponent.DcTable = arithmeticTable;
			jpegArithmeticDecodingComponent.AcTable = arithmeticTable2;
			jpegArithmeticDecodingComponent.QuantizationTable = Decoder.GetQuantizationTable(jpegFrameComponentSpecificationParameters2.GetValueOrDefault().QuantizationTableSelector);
			jpegArithmeticDecodingComponent.HorizontalSubsamplingFactor = num / jpegArithmeticDecodingComponent.HorizontalSamplingFactor;
			jpegArithmeticDecodingComponent.VerticalSubsamplingFactor = num2 / jpegArithmeticDecodingComponent.VerticalSamplingFactor;
			jpegArithmeticDecodingComponent.DcPredictor = 0;
			jpegArithmeticDecodingComponent.DcContext = 0;
			jpegArithmeticDecodingComponent.DcStatistics = ((arithmeticTable == null) ? null : CreateOrGetStatisticsBin(dc: true, arithmeticTable.Identifier));
			jpegArithmeticDecodingComponent.AcStatistics = ((arithmeticTable2 == null) ? null : CreateOrGetStatisticsBin(dc: false, arithmeticTable2.Identifier));
		}
		return scanHeader.NumberOfComponents;
	}

	protected JpegArithmeticDecodingComponent[] InitDecodeComponents(JpegFrameHeader frameHeader, JpegScanHeader scanHeader)
	{
		JpegArithmeticDecodingComponent[] array = new JpegArithmeticDecodingComponent[scanHeader.NumberOfComponents];
		InitDecodeComponents(frameHeader, scanHeader, array);
		return array;
	}

	protected int DecodeBinaryDecision(ref JpegBitReader reader, ref byte st)
	{
		while (_a < 32768)
		{
			if (--_ct < 0)
			{
				reader.TryReadBits(8, out var bits, out var _);
				_c = (_c << 8) | bits;
				if ((_ct += 8) < 0 && ++_ct == 0)
				{
					_a = 32768;
				}
			}
			_a <<= 1;
		}
		int num = st;
		int num2 = s_arithmeticTable[num & 0x7F];
		byte b = (byte)num2;
		num2 >>= 8;
		byte b2 = (byte)num2;
		num2 >>= 8;
		int num3 = (_a -= num2) << _ct;
		if (_c >= num3)
		{
			_c -= num3;
			if (_a < num2)
			{
				_a = num2;
				st = (byte)((num & 0x80) ^ b2);
			}
			else
			{
				_a = num2;
				st = (byte)((num & 0x80) ^ b);
				num ^= 0x80;
			}
		}
		else if (_a < 32768)
		{
			if (_a < num2)
			{
				st = (byte)((num & 0x80) ^ b);
				num ^= 0x80;
			}
			else
			{
				st = (byte)((num & 0x80) ^ b2);
			}
		}
		return num >> 7;
	}

	protected void Reset()
	{
		_c = 0;
		_a = 0;
		_ct = -16;
	}

	private static int Pack(int i, int a, int b, int c, int d)
	{
		return (a << 16) | (c << 8) | (d << 7) | b;
	}
}
