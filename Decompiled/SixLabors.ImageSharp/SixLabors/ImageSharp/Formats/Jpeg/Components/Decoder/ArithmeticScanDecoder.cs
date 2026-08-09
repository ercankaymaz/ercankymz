using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using SixLabors.ImageSharp.IO;

namespace SixLabors.ImageSharp.Formats.Jpeg.Components.Decoder;

internal class ArithmeticScanDecoder : IJpegScanDecoder
{
	private readonly BufferedReadStream stream;

	private int c;

	private int a;

	private int ct;

	private JpegFrame frame;

	private IJpegComponent[] components;

	private int scanComponentCount;

	private int restartInterval;

	private int todo;

	private readonly SpectralConverter spectralConverter;

	private JpegBitReader scanBuffer;

	private ArithmeticDecodingTable[] dcDecodingTables;

	private ArithmeticDecodingTable[] acDecodingTables;

	private readonly byte[] fixedBin = new byte[4] { 113, 0, 0, 0 };

	private readonly CancellationToken cancellationToken;

	private static readonly int[] ArithmeticTable = new int[114]
	{
		Pack(23069, 1, 1, 1),
		Pack(9606, 14, 2, 0),
		Pack(4372, 16, 3, 0),
		Pack(2059, 18, 4, 0),
		Pack(984, 20, 5, 0),
		Pack(474, 23, 6, 0),
		Pack(229, 25, 7, 0),
		Pack(111, 28, 8, 0),
		Pack(54, 30, 9, 0),
		Pack(26, 33, 10, 0),
		Pack(13, 35, 11, 0),
		Pack(6, 9, 12, 0),
		Pack(3, 10, 13, 0),
		Pack(1, 12, 13, 0),
		Pack(23167, 15, 15, 1),
		Pack(16165, 36, 16, 0),
		Pack(11506, 38, 17, 0),
		Pack(8316, 39, 18, 0),
		Pack(6073, 40, 19, 0),
		Pack(4482, 42, 20, 0),
		Pack(3311, 43, 21, 0),
		Pack(2465, 45, 22, 0),
		Pack(1839, 46, 23, 0),
		Pack(1372, 48, 24, 0),
		Pack(1030, 49, 25, 0),
		Pack(771, 51, 26, 0),
		Pack(576, 52, 27, 0),
		Pack(433, 54, 28, 0),
		Pack(324, 56, 29, 0),
		Pack(245, 57, 30, 0),
		Pack(183, 59, 31, 0),
		Pack(138, 60, 32, 0),
		Pack(104, 62, 33, 0),
		Pack(78, 63, 34, 0),
		Pack(59, 32, 35, 0),
		Pack(44, 33, 9, 0),
		Pack(23265, 37, 37, 1),
		Pack(18508, 64, 38, 0),
		Pack(14861, 65, 39, 0),
		Pack(12017, 67, 40, 0),
		Pack(9759, 68, 41, 0),
		Pack(7987, 69, 42, 0),
		Pack(6568, 70, 43, 0),
		Pack(5400, 72, 44, 0),
		Pack(4471, 73, 45, 0),
		Pack(3700, 74, 46, 0),
		Pack(3067, 75, 47, 0),
		Pack(2552, 77, 48, 0),
		Pack(2145, 78, 49, 0),
		Pack(1798, 79, 50, 0),
		Pack(1485, 48, 51, 0),
		Pack(1246, 50, 52, 0),
		Pack(1039, 50, 53, 0),
		Pack(867, 51, 54, 0),
		Pack(724, 52, 55, 0),
		Pack(604, 53, 56, 0),
		Pack(504, 54, 57, 0),
		Pack(420, 55, 58, 0),
		Pack(352, 56, 59, 0),
		Pack(293, 57, 60, 0),
		Pack(246, 58, 61, 0),
		Pack(203, 59, 62, 0),
		Pack(171, 61, 63, 0),
		Pack(143, 61, 32, 0),
		Pack(23314, 65, 65, 1),
		Pack(19716, 80, 66, 0),
		Pack(16684, 81, 67, 0),
		Pack(14296, 82, 68, 0),
		Pack(12264, 83, 69, 0),
		Pack(10556, 84, 70, 0),
		Pack(9081, 86, 71, 0),
		Pack(7903, 87, 72, 0),
		Pack(6825, 87, 73, 0),
		Pack(5966, 72, 74, 0),
		Pack(5156, 72, 75, 0),
		Pack(4508, 74, 76, 0),
		Pack(3947, 74, 77, 0),
		Pack(3409, 75, 78, 0),
		Pack(2998, 77, 79, 0),
		Pack(2624, 77, 48, 0),
		Pack(22578, 80, 81, 1),
		Pack(19740, 88, 82, 0),
		Pack(17294, 89, 83, 0),
		Pack(15325, 90, 84, 0),
		Pack(13550, 91, 85, 0),
		Pack(11950, 92, 86, 0),
		Pack(10650, 93, 87, 0),
		Pack(9494, 86, 71, 0),
		Pack(21872, 88, 89, 1),
		Pack(19625, 95, 90, 0),
		Pack(17625, 96, 91, 0),
		Pack(15906, 97, 92, 0),
		Pack(14372, 99, 93, 0),
		Pack(12980, 99, 94, 0),
		Pack(11799, 93, 86, 0),
		Pack(22184, 95, 96, 1),
		Pack(20294, 101, 97, 0),
		Pack(18405, 102, 98, 0),
		Pack(16847, 103, 99, 0),
		Pack(15421, 104, 100, 0),
		Pack(14174, 99, 93, 0),
		Pack(21041, 105, 102, 0),
		Pack(19471, 106, 103, 0),
		Pack(17977, 107, 104, 0),
		Pack(16734, 103, 99, 0),
		Pack(22055, 105, 106, 1),
		Pack(20711, 108, 107, 0),
		Pack(19333, 109, 103, 0),
		Pack(21911, 110, 109, 0),
		Pack(20559, 111, 107, 0),
		Pack(23056, 110, 111, 1),
		Pack(21794, 112, 109, 0),
		Pack(23019, 112, 111, 1),
		Pack(23069, 113, 113, 0)
	};

	private readonly List<ArithmeticStatistics> statistics = new List<ArithmeticStatistics>();

	public int ResetInterval
	{
		set
		{
			restartInterval = value;
			todo = value;
		}
	}

	public int SpectralStart { get; set; }

	public int SpectralEnd { get; set; }

	public int SuccessiveHigh { get; set; }

	public int SuccessiveLow { get; set; }

	public ArithmeticScanDecoder(BufferedReadStream stream, SpectralConverter converter, CancellationToken cancellationToken)
	{
		this.stream = stream;
		spectralConverter = converter;
		this.cancellationToken = cancellationToken;
		c = 0;
		a = 0;
		ct = -16;
	}

	public void InitDecodingTables(List<ArithmeticDecodingTable> arithmeticDecodingTables)
	{
		for (int i = 0; i < components.Length; i++)
		{
			ArithmeticDecodingComponent arithmeticDecodingComponent = components[i] as ArithmeticDecodingComponent;
			dcDecodingTables[i] = GetArithmeticTable(arithmeticDecodingTables, isDcTable: true, arithmeticDecodingComponent.DcTableId);
			arithmeticDecodingComponent.DcStatistics = CreateOrGetStatisticsBin(dc: true, arithmeticDecodingComponent.DcTableId);
			acDecodingTables[i] = GetArithmeticTable(arithmeticDecodingTables, isDcTable: false, arithmeticDecodingComponent.AcTableId);
			arithmeticDecodingComponent.AcStatistics = CreateOrGetStatisticsBin(dc: false, arithmeticDecodingComponent.AcTableId);
		}
	}

	private ref byte GetFixedBinReference()
	{
		return ref MemoryMarshal.GetArrayDataReference<byte>(fixedBin);
	}

	public void ParseEntropyCodedData(int scanComponentCount)
	{
		cancellationToken.ThrowIfCancellationRequested();
		this.scanComponentCount = scanComponentCount;
		scanBuffer = new JpegBitReader(stream);
		frame.AllocateComponents();
		if (frame.Progressive)
		{
			ParseProgressiveData();
		}
		else
		{
			ParseBaselineData();
		}
		if (scanBuffer.HasBadMarker())
		{
			stream.Position = scanBuffer.MarkerPosition;
		}
	}

	public void InjectFrameData(JpegFrame frame, IRawJpegData jpegData)
	{
		this.frame = frame;
		IJpegComponent[] array = frame.Components;
		components = array;
		dcDecodingTables = new ArithmeticDecodingTable[components.Length];
		acDecodingTables = new ArithmeticDecodingTable[components.Length];
		spectralConverter.InjectFrameData(frame, jpegData);
	}

	private static ArithmeticDecodingTable GetArithmeticTable(List<ArithmeticDecodingTable> arithmeticDecodingTables, bool isDcTable, int identifier)
	{
		int num = ((!isDcTable) ? 1 : 0);
		foreach (ArithmeticDecodingTable arithmeticDecodingTable in arithmeticDecodingTables)
		{
			if (arithmeticDecodingTable.TableClass == num && arithmeticDecodingTable.Identifier == identifier)
			{
				return arithmeticDecodingTable;
			}
		}
		return null;
	}

	private ArithmeticStatistics CreateOrGetStatisticsBin(bool dc, int identifier, bool reset = false)
	{
		foreach (ArithmeticStatistics statistic in statistics)
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
		ArithmeticStatistics arithmeticStatistics = new ArithmeticStatistics(dc, identifier);
		statistics.Add(arithmeticStatistics);
		return arithmeticStatistics;
	}

	private void ParseBaselineData()
	{
		for (int i = 0; i < components.Length; i++)
		{
			ArithmeticDecodingComponent obj = (ArithmeticDecodingComponent)components[i];
			obj.DcPredictor = 0;
			obj.DcContext = 0;
			obj.DcStatistics?.Reset();
			obj.AcStatistics?.Reset();
		}
		Reset();
		if (scanComponentCount != 1)
		{
			spectralConverter.PrepareForDecoding();
			ParseBaselineDataInterleaved();
			spectralConverter.CommitConversion();
		}
		else if (frame.ComponentCount == 1)
		{
			spectralConverter.PrepareForDecoding();
			ParseBaselineDataSingleComponent();
			spectralConverter.CommitConversion();
		}
		else
		{
			ParseBaselineDataNonInterleaved();
		}
	}

	private void ParseProgressiveData()
	{
		CheckProgressiveData();
		IJpegComponent[] array = components;
		for (int i = 0; i < array.Length; i++)
		{
			ArithmeticDecodingComponent arithmeticDecodingComponent = (ArithmeticDecodingComponent)array[i];
			if (SpectralStart == 0 && SuccessiveHigh == 0)
			{
				arithmeticDecodingComponent.DcPredictor = 0;
				arithmeticDecodingComponent.DcContext = 0;
				arithmeticDecodingComponent.DcStatistics?.Reset();
			}
			if (SpectralStart != 0)
			{
				arithmeticDecodingComponent.AcStatistics?.Reset();
			}
		}
		Reset();
		if (scanComponentCount == 1)
		{
			ParseProgressiveDataNonInterleaved();
		}
		else
		{
			ParseProgressiveDataInterleaved();
		}
	}

	private void CheckProgressiveData()
	{
		bool flag = false;
		if (SpectralStart == 0)
		{
			if (SpectralEnd != 0)
			{
				flag = true;
			}
		}
		else
		{
			if (SpectralEnd < SpectralStart || SpectralEnd > 63)
			{
				flag = true;
			}
			if (scanComponentCount != 1)
			{
				flag = true;
			}
		}
		if (SuccessiveHigh != 0 && SuccessiveHigh - 1 != SuccessiveLow)
		{
			flag = true;
		}
		if (SuccessiveLow > 13)
		{
			flag = true;
		}
		if (flag)
		{
			JpegThrowHelper.ThrowBadProgressiveScan(SpectralStart, SpectralEnd, SuccessiveHigh, SuccessiveLow);
		}
	}

	private void ParseBaselineDataInterleaved()
	{
		int num = 0;
		int mcusPerColumn = frame.McusPerColumn;
		int mcusPerLine = frame.McusPerLine;
		ref JpegBitReader reference = ref scanBuffer;
		for (int i = 0; i < mcusPerColumn; i++)
		{
			cancellationToken.ThrowIfCancellationRequested();
			for (int j = 0; j < mcusPerLine; j++)
			{
				int num2 = num % mcusPerLine;
				for (int k = 0; k < scanComponentCount; k++)
				{
					int num3 = frame.ComponentOrder[k];
					ArithmeticDecodingComponent arithmeticDecodingComponent = components[num3] as ArithmeticDecodingComponent;
					ref ArithmeticDecodingTable dcTable = ref dcDecodingTables[arithmeticDecodingComponent.DcTableId];
					ref ArithmeticDecodingTable acTable = ref acDecodingTables[arithmeticDecodingComponent.AcTableId];
					int horizontalSamplingFactor = arithmeticDecodingComponent.HorizontalSamplingFactor;
					int verticalSamplingFactor = arithmeticDecodingComponent.VerticalSamplingFactor;
					int num4 = num2 * horizontalSamplingFactor;
					for (int l = 0; l < verticalSamplingFactor; l++)
					{
						ref Block8x8 reference2 = ref MemoryMarshal.GetReference<Block8x8>(arithmeticDecodingComponent.SpectralBlocks.DangerousGetRowSpan(l));
						for (int m = 0; m < horizontalSamplingFactor; m++)
						{
							if (reference.NoData)
							{
								spectralConverter.ConvertStrideBaseline();
								return;
							}
							int num5 = num4 + m;
							DecodeBlockBaseline(arithmeticDecodingComponent, ref Unsafe.Add(ref reference2, (uint)num5), ref acTable, ref dcTable);
						}
					}
				}
				num++;
				HandleRestart();
			}
			spectralConverter.ConvertStrideBaseline();
		}
	}

	private void ParseBaselineDataSingleComponent()
	{
		ArithmeticDecodingComponent arithmeticDecodingComponent = frame.Components[0] as ArithmeticDecodingComponent;
		int mcusPerColumn = frame.McusPerColumn;
		int widthInBlocks = arithmeticDecodingComponent.WidthInBlocks;
		int height = arithmeticDecodingComponent.SamplingFactors.Height;
		ref ArithmeticDecodingTable dcTable = ref dcDecodingTables[arithmeticDecodingComponent.DcTableId];
		ref ArithmeticDecodingTable acTable = ref acDecodingTables[arithmeticDecodingComponent.AcTableId];
		ref JpegBitReader reference = ref scanBuffer;
		for (int i = 0; i < mcusPerColumn; i++)
		{
			cancellationToken.ThrowIfCancellationRequested();
			for (int j = 0; j < height; j++)
			{
				ref Block8x8 reference2 = ref MemoryMarshal.GetReference<Block8x8>(arithmeticDecodingComponent.SpectralBlocks.DangerousGetRowSpan(j));
				for (int k = 0; k < widthInBlocks; k++)
				{
					if (reference.NoData)
					{
						spectralConverter.ConvertStrideBaseline();
						return;
					}
					DecodeBlockBaseline(arithmeticDecodingComponent, ref Unsafe.Add(ref reference2, (uint)k), ref acTable, ref dcTable);
					HandleRestart();
				}
			}
			spectralConverter.ConvertStrideBaseline();
		}
	}

	private void ParseBaselineDataNonInterleaved()
	{
		ArithmeticDecodingComponent arithmeticDecodingComponent = (ArithmeticDecodingComponent)components[frame.ComponentOrder[0]];
		ref JpegBitReader reference = ref scanBuffer;
		int widthInBlocks = arithmeticDecodingComponent.WidthInBlocks;
		int heightInBlocks = arithmeticDecodingComponent.HeightInBlocks;
		ref ArithmeticDecodingTable dcTable = ref dcDecodingTables[arithmeticDecodingComponent.DcTableId];
		ref ArithmeticDecodingTable acTable = ref acDecodingTables[arithmeticDecodingComponent.AcTableId];
		for (int i = 0; i < heightInBlocks; i++)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ref Block8x8 reference2 = ref MemoryMarshal.GetReference<Block8x8>(arithmeticDecodingComponent.SpectralBlocks.DangerousGetRowSpan(i));
			for (int j = 0; j < widthInBlocks; j++)
			{
				if (reference.NoData)
				{
					return;
				}
				DecodeBlockBaseline(arithmeticDecodingComponent, ref Unsafe.Add(ref reference2, (uint)j), ref acTable, ref dcTable);
				HandleRestart();
			}
		}
	}

	private void ParseProgressiveDataInterleaved()
	{
		int num = 0;
		int mcusPerColumn = frame.McusPerColumn;
		int mcusPerLine = frame.McusPerLine;
		ref JpegBitReader reference = ref scanBuffer;
		for (int i = 0; i < mcusPerColumn; i++)
		{
			for (int j = 0; j < mcusPerLine; j++)
			{
				int result;
				int num2 = Math.DivRem(num, mcusPerLine, out result);
				for (int k = 0; k < scanComponentCount; k++)
				{
					int num3 = frame.ComponentOrder[k];
					ArithmeticDecodingComponent arithmeticDecodingComponent = components[num3] as ArithmeticDecodingComponent;
					ref ArithmeticDecodingTable dcTable = ref dcDecodingTables[arithmeticDecodingComponent.DcTableId];
					int horizontalSamplingFactor = arithmeticDecodingComponent.HorizontalSamplingFactor;
					int verticalSamplingFactor = arithmeticDecodingComponent.VerticalSamplingFactor;
					int num4 = result * horizontalSamplingFactor;
					for (int l = 0; l < verticalSamplingFactor; l++)
					{
						int y = num2 * verticalSamplingFactor + l;
						ref Block8x8 reference2 = ref MemoryMarshal.GetReference<Block8x8>(arithmeticDecodingComponent.SpectralBlocks.DangerousGetRowSpan(y));
						for (int m = 0; m < horizontalSamplingFactor; m++)
						{
							if (reference.NoData)
							{
								return;
							}
							int num5 = num4 + m;
							DecodeBlockProgressiveDc(arithmeticDecodingComponent, ref Unsafe.Add(ref reference2, (uint)num5), ref dcTable);
						}
					}
				}
				num++;
				HandleRestart();
			}
		}
	}

	private void ParseProgressiveDataNonInterleaved()
	{
		ArithmeticDecodingComponent arithmeticDecodingComponent = components[frame.ComponentOrder[0]] as ArithmeticDecodingComponent;
		ref JpegBitReader reference = ref scanBuffer;
		int widthInBlocks = arithmeticDecodingComponent.WidthInBlocks;
		int heightInBlocks = arithmeticDecodingComponent.HeightInBlocks;
		if (SpectralStart == 0)
		{
			ref ArithmeticDecodingTable dcTable = ref dcDecodingTables[arithmeticDecodingComponent.DcTableId];
			for (int i = 0; i < heightInBlocks; i++)
			{
				cancellationToken.ThrowIfCancellationRequested();
				ref Block8x8 reference2 = ref MemoryMarshal.GetReference<Block8x8>(arithmeticDecodingComponent.SpectralBlocks.DangerousGetRowSpan(i));
				for (int j = 0; j < widthInBlocks; j++)
				{
					if (reference.NoData)
					{
						return;
					}
					DecodeBlockProgressiveDc(arithmeticDecodingComponent, ref Unsafe.Add(ref reference2, (uint)j), ref dcTable);
					HandleRestart();
				}
			}
			return;
		}
		ref ArithmeticDecodingTable acTable = ref acDecodingTables[arithmeticDecodingComponent.AcTableId];
		for (int k = 0; k < heightInBlocks; k++)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ref Block8x8 reference3 = ref MemoryMarshal.GetReference<Block8x8>(arithmeticDecodingComponent.SpectralBlocks.DangerousGetRowSpan(k));
			for (int l = 0; l < widthInBlocks; l++)
			{
				if (reference.NoData)
				{
					return;
				}
				DecodeBlockProgressiveAc(arithmeticDecodingComponent, ref Unsafe.Add(ref reference3, (uint)l), ref acTable);
				HandleRestart();
			}
		}
	}

	private void DecodeBlockProgressiveDc(ArithmeticDecodingComponent component, ref Block8x8 block, ref ArithmeticDecodingTable dcTable)
	{
		if (dcTable == null)
		{
			JpegThrowHelper.ThrowInvalidImageContentException("DC table is missing");
		}
		ref JpegBitReader reader = ref scanBuffer;
		ref short reference = ref Unsafe.As<Block8x8, short>(ref block);
		if (SuccessiveHigh == 0)
		{
			ref byte reference2 = ref Unsafe.Add(ref component.DcStatistics.GetReference(), (uint)component.DcContext);
			if (DecodeBinaryDecision(ref reader, ref reference2) == 0)
			{
				component.DcContext = 0;
			}
			else
			{
				int num = DecodeBinaryDecision(ref reader, ref Unsafe.Add(ref reference2, 1));
				reference2 = ref Unsafe.Add(ref reference2, (uint)(2 + num));
				int num2 = DecodeBinaryDecision(ref reader, ref reference2);
				if (num2 != 0)
				{
					reference2 = ref component.DcStatistics.GetReference(20);
					while (DecodeBinaryDecision(ref reader, ref reference2) != 0)
					{
						if ((num2 <<= 1) == 32768)
						{
							JpegThrowHelper.ThrowInvalidImageContentException("Invalid arithmetic code.");
						}
						reference2 = ref Unsafe.Add(ref reference2, 1);
					}
				}
				if (num2 < (int)(1L << dcTable.DcL >> 1))
				{
					component.DcContext = 0;
				}
				else if (num2 > (int)(1L << dcTable.DcU >> 1))
				{
					component.DcContext = 12 + num * 4;
				}
				else
				{
					component.DcContext = 4 + num * 4;
				}
				int num3 = num2;
				reference2 = ref Unsafe.Add(ref reference2, 14);
				while ((num2 >>= 1) != 0)
				{
					if (DecodeBinaryDecision(ref reader, ref reference2) != 0)
					{
						num3 |= num2;
					}
				}
				num3++;
				if (num != 0)
				{
					num3 = -num3;
				}
				component.DcPredictor = (short)(component.DcPredictor + num3);
			}
			reference = (short)(component.DcPredictor << SuccessiveLow);
		}
		else
		{
			reference |= (short)(DecodeBinaryDecision(ref reader, ref GetFixedBinReference()) << SuccessiveLow);
		}
	}

	private void DecodeBlockProgressiveAc(ArithmeticDecodingComponent component, ref Block8x8 block, ref ArithmeticDecodingTable acTable)
	{
		ref JpegBitReader reader = ref scanBuffer;
		ref short reference = ref Unsafe.As<Block8x8, short>(ref block);
		ArithmeticStatistics acStatistics = component.AcStatistics;
		if (acStatistics == null || acTable == null)
		{
			JpegThrowHelper.ThrowInvalidImageContentException("AC table is missing");
		}
		if (SuccessiveHigh == 0)
		{
			int spectralStart = SpectralStart;
			int spectralEnd = SpectralEnd;
			int successiveLow = SuccessiveLow;
			for (int i = spectralStart; i <= spectralEnd; i++)
			{
				ref byte reference2 = ref acStatistics.GetReference(3 * (i - 1));
				if (DecodeBinaryDecision(ref reader, ref reference2) != 0)
				{
					break;
				}
				while (DecodeBinaryDecision(ref reader, ref Unsafe.Add(ref reference2, 1)) == 0)
				{
					reference2 = ref Unsafe.Add(ref reference2, 3);
					i++;
					if (i > 63)
					{
						JpegThrowHelper.ThrowInvalidImageContentException("Invalid arithmetic code.");
					}
				}
				int num = DecodeBinaryDecision(ref reader, ref GetFixedBinReference());
				reference2 = ref Unsafe.Add(ref reference2, 2);
				int num2 = DecodeBinaryDecision(ref reader, ref reference2);
				if (num2 != 0 && DecodeBinaryDecision(ref reader, ref reference2) != 0)
				{
					num2 <<= 1;
					reference2 = ref acStatistics.GetReference((i <= acTable.AcKx) ? 189 : 217);
					while (DecodeBinaryDecision(ref reader, ref reference2) != 0)
					{
						if ((num2 <<= 1) == 32768)
						{
							JpegThrowHelper.ThrowInvalidImageContentException("Invalid arithmetic code.");
						}
						reference2 = ref Unsafe.Add(ref reference2, 1);
					}
				}
				int num3 = num2;
				reference2 = ref Unsafe.Add(ref reference2, 14);
				while ((num2 >>= 1) != 0)
				{
					if (DecodeBinaryDecision(ref reader, ref reference2) != 0)
					{
						num3 |= num2;
					}
				}
				num3++;
				if (num != 0)
				{
					num3 = -num3;
				}
				Unsafe.Add(ref reference, (int)ZigZag.TransposingOrder[i]) = (short)(num3 << successiveLow);
			}
		}
		else
		{
			ReadBlockProgressiveAcRefined(acStatistics, ref reference);
		}
	}

	private void ReadBlockProgressiveAcRefined(ArithmeticStatistics acStatistics, ref short blockDataRef)
	{
		ref JpegBitReader reader = ref scanBuffer;
		int spectralStart = SpectralStart;
		int spectralEnd = SpectralEnd;
		int num = 1 << SuccessiveLow;
		int num2 = -1 << SuccessiveLow;
		int num3 = spectralEnd;
		while (num3 > 0 && Unsafe.Add(ref blockDataRef, (int)ZigZag.TransposingOrder[num3]) == 0)
		{
			num3--;
		}
		for (int i = spectralStart; i <= spectralEnd; i++)
		{
			ref byte reference = ref acStatistics.GetReference(3 * (i - 1));
			if (i > num3 && DecodeBinaryDecision(ref reader, ref reference) != 0)
			{
				break;
			}
			while (true)
			{
				ref short reference2 = ref Unsafe.Add(ref blockDataRef, (int)ZigZag.TransposingOrder[i]);
				if (reference2 != 0)
				{
					if (DecodeBinaryDecision(ref reader, ref Unsafe.Add(ref reference, 2)) != 0)
					{
						reference2 = (short)(reference2 + ((reference2 < 0) ? num2 : num));
					}
					break;
				}
				if (DecodeBinaryDecision(ref reader, ref Unsafe.Add(ref reference, 1)) != 0)
				{
					bool flag = DecodeBinaryDecision(ref reader, ref GetFixedBinReference()) != 0;
					reference2 = (short)(reference2 + (flag ? num2 : num));
					break;
				}
				reference = ref Unsafe.Add(ref reference, 3);
				i++;
				if (i > spectralEnd)
				{
					JpegThrowHelper.ThrowInvalidImageContentException("Invalid arithmetic code.");
				}
			}
		}
	}

	private void DecodeBlockBaseline(ArithmeticDecodingComponent component, ref Block8x8 destinationBlock, ref ArithmeticDecodingTable acTable, ref ArithmeticDecodingTable dcTable)
	{
		if (acTable == null)
		{
			JpegThrowHelper.ThrowInvalidImageContentException("AC table is missing.");
		}
		if (dcTable == null)
		{
			JpegThrowHelper.ThrowInvalidImageContentException("DC table is missing.");
		}
		ref JpegBitReader reader = ref scanBuffer;
		ref short reference = ref Unsafe.As<Block8x8, short>(ref destinationBlock);
		ref byte reference2 = ref Unsafe.Add(ref component.DcStatistics.GetReference(), (uint)component.DcContext);
		if (DecodeBinaryDecision(ref reader, ref reference2) == 0)
		{
			component.DcContext = 0;
		}
		else
		{
			int num = DecodeBinaryDecision(ref reader, ref Unsafe.Add(ref reference2, 1));
			reference2 = ref Unsafe.Add(ref reference2, (uint)(2 + num));
			int num2 = DecodeBinaryDecision(ref reader, ref reference2);
			if (num2 != 0)
			{
				reference2 = ref component.DcStatistics.GetReference(20);
				while (DecodeBinaryDecision(ref reader, ref reference2) != 0)
				{
					if ((num2 <<= 1) == 32768)
					{
						JpegThrowHelper.ThrowInvalidImageContentException("Invalid arithmetic code.");
					}
					reference2 = ref Unsafe.Add(ref reference2, 1);
				}
			}
			if (num2 < (int)(1L << dcTable.DcL >> 1))
			{
				component.DcContext = 0;
			}
			else if (num2 > (int)(1L << dcTable.DcU >> 1))
			{
				component.DcContext = 12 + num * 4;
			}
			else
			{
				component.DcContext = 4 + num * 4;
			}
			int num3 = num2;
			reference2 = ref Unsafe.Add(ref reference2, 14);
			while ((num2 >>= 1) != 0)
			{
				if (DecodeBinaryDecision(ref reader, ref reference2) != 0)
				{
					num3 |= num2;
				}
			}
			num3++;
			if (num != 0)
			{
				num3 = -num3;
			}
			component.DcPredictor = (short)(component.DcPredictor + num3);
		}
		reference = (short)component.DcPredictor;
		ArithmeticStatistics acStatistics = component.AcStatistics;
		for (int i = 1; i <= 63; i++)
		{
			reference2 = ref acStatistics.GetReference(3 * (i - 1));
			if (DecodeBinaryDecision(ref reader, ref reference2) != 0)
			{
				break;
			}
			while (DecodeBinaryDecision(ref reader, ref Unsafe.Add(ref reference2, 1)) == 0)
			{
				reference2 = ref Unsafe.Add(ref reference2, 3);
				i++;
				if (i > 63)
				{
					JpegThrowHelper.ThrowInvalidImageContentException("Invalid arithmetic code.");
				}
			}
			int num4 = DecodeBinaryDecision(ref reader, ref GetFixedBinReference());
			reference2 = ref Unsafe.Add(ref reference2, 2);
			int num5 = DecodeBinaryDecision(ref reader, ref reference2);
			if (num5 != 0 && DecodeBinaryDecision(ref reader, ref reference2) != 0)
			{
				num5 <<= 1;
				reference2 = ref acStatistics.GetReference((i <= acTable.AcKx) ? 189 : 217);
				while (DecodeBinaryDecision(ref reader, ref reference2) != 0)
				{
					if ((num5 <<= 1) == 32768)
					{
						JpegThrowHelper.ThrowInvalidImageContentException("Invalid arithmetic code.");
					}
					reference2 = ref Unsafe.Add(ref reference2, 1);
				}
			}
			int num6 = num5;
			reference2 = ref Unsafe.Add(ref reference2, 14);
			while ((num5 >>= 1) != 0)
			{
				if (DecodeBinaryDecision(ref reader, ref reference2) != 0)
				{
					num6 |= num5;
				}
			}
			num6++;
			if (num4 != 0)
			{
				num6 = -num6;
			}
			Unsafe.Add(ref reference, (int)ZigZag.TransposingOrder[i]) = (short)num6;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private bool HandleRestart()
	{
		if (restartInterval > 0 && --todo == 0)
		{
			if (scanBuffer.Marker == byte.MaxValue && !scanBuffer.FindNextMarker())
			{
				return false;
			}
			todo = restartInterval;
			IJpegComponent[] array = components;
			for (int i = 0; i < array.Length; i++)
			{
				ArithmeticDecodingComponent obj = (ArithmeticDecodingComponent)array[i];
				obj.DcPredictor = 0;
				obj.DcContext = 0;
				obj.DcStatistics?.Reset();
				obj.AcStatistics?.Reset();
			}
			Reset();
			if (scanBuffer.HasRestartMarker())
			{
				Reset();
				return true;
			}
			if (scanBuffer.HasBadMarker())
			{
				stream.Position = scanBuffer.MarkerPosition;
				Reset();
				return true;
			}
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void Reset()
	{
		for (int i = 0; i < components.Length; i++)
		{
			(components[i] as ArithmeticDecodingComponent).DcPredictor = 0;
		}
		c = 0;
		a = 0;
		ct = -16;
		scanBuffer.Reset();
	}

	private int DecodeBinaryDecision(ref JpegBitReader reader, ref byte st)
	{
		while (a < 32768)
		{
			if (--ct < 0)
			{
				reader.CheckBits();
				int bits = reader.GetBits(8);
				c = (c << 8) | bits;
				if ((ct += 8) < 0 && ++ct == 0)
				{
					a = 32768;
				}
			}
			a <<= 1;
		}
		int num = st;
		int num2 = ArithmeticTable[num & 0x7F];
		byte b = (byte)num2;
		num2 >>= 8;
		byte b2 = (byte)num2;
		num2 >>= 8;
		int num3 = (a -= num2) << ct;
		if (c >= num3)
		{
			c -= num3;
			if (a < num2)
			{
				a = num2;
				st = (byte)((num & 0x80) ^ b2);
			}
			else
			{
				a = num2;
				st = (byte)((num & 0x80) ^ b);
				num ^= 0x80;
			}
		}
		else if (a < 32768)
		{
			if (a < num2)
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

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int Pack(int a, int b, int c, int d)
	{
		return (a << 16) | (c << 8) | (d << 7) | b;
	}
}
