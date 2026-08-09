using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using SixLabors.ImageSharp.IO;

namespace SixLabors.ImageSharp.Formats.Jpeg.Components.Decoder;

internal class HuffmanScanDecoder : IJpegScanDecoder
{
	private readonly BufferedReadStream stream;

	private JpegFrame frame;

	private IJpegComponent[] components;

	private int scanComponentCount;

	private int restartInterval;

	private int todo;

	private int eobrun;

	private readonly HuffmanTable[] dcHuffmanTables;

	private readonly HuffmanTable[] acHuffmanTables;

	private JpegBitReader scanBuffer;

	private readonly SpectralConverter spectralConverter;

	private readonly CancellationToken cancellationToken;

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

	public HuffmanScanDecoder(BufferedReadStream stream, SpectralConverter converter, CancellationToken cancellationToken)
	{
		this.stream = stream;
		spectralConverter = converter;
		this.cancellationToken = cancellationToken;
		dcHuffmanTables = new HuffmanTable[4];
		acHuffmanTables = new HuffmanTable[4];
	}

	public void ParseEntropyCodedData(int scanComponentCount)
	{
		cancellationToken.ThrowIfCancellationRequested();
		this.scanComponentCount = scanComponentCount;
		scanBuffer = new JpegBitReader(stream);
		frame.AllocateComponents();
		if (!frame.Progressive)
		{
			ParseBaselineData();
		}
		else
		{
			ParseProgressiveData();
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
		spectralConverter.InjectFrameData(frame, jpegData);
	}

	private void ParseBaselineData()
	{
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
					JpegComponent jpegComponent = components[num3] as JpegComponent;
					ref HuffmanTable dcTable = ref dcHuffmanTables[jpegComponent.DcTableId];
					ref HuffmanTable acTable = ref acHuffmanTables[jpegComponent.AcTableId];
					int horizontalSamplingFactor = jpegComponent.HorizontalSamplingFactor;
					int verticalSamplingFactor = jpegComponent.VerticalSamplingFactor;
					for (int l = 0; l < verticalSamplingFactor; l++)
					{
						ref Block8x8 reference2 = ref MemoryMarshal.GetReference<Block8x8>(jpegComponent.SpectralBlocks.DangerousGetRowSpan(l));
						for (int m = 0; m < horizontalSamplingFactor; m++)
						{
							if (reference.NoData)
							{
								spectralConverter.ConvertStrideBaseline();
								return;
							}
							int num4 = num2 * horizontalSamplingFactor + m;
							DecodeBlockBaseline(jpegComponent, ref Unsafe.Add(ref reference2, (uint)num4), ref dcTable, ref acTable);
						}
					}
				}
				num++;
				HandleRestart();
			}
			spectralConverter.ConvertStrideBaseline();
		}
	}

	private void ParseBaselineDataNonInterleaved()
	{
		JpegComponent jpegComponent = components[frame.ComponentOrder[0]] as JpegComponent;
		ref JpegBitReader reference = ref scanBuffer;
		int widthInBlocks = jpegComponent.WidthInBlocks;
		int heightInBlocks = jpegComponent.HeightInBlocks;
		ref HuffmanTable dcTable = ref dcHuffmanTables[jpegComponent.DcTableId];
		ref HuffmanTable acTable = ref acHuffmanTables[jpegComponent.AcTableId];
		for (int i = 0; i < heightInBlocks; i++)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ref Block8x8 reference2 = ref MemoryMarshal.GetReference<Block8x8>(jpegComponent.SpectralBlocks.DangerousGetRowSpan(i));
			for (int j = 0; j < widthInBlocks; j++)
			{
				if (reference.NoData)
				{
					return;
				}
				DecodeBlockBaseline(jpegComponent, ref Unsafe.Add(ref reference2, (uint)j), ref dcTable, ref acTable);
				HandleRestart();
			}
		}
	}

	private void ParseBaselineDataSingleComponent()
	{
		JpegComponent jpegComponent = frame.Components[0];
		int mcusPerColumn = frame.McusPerColumn;
		int widthInBlocks = jpegComponent.WidthInBlocks;
		int height = jpegComponent.SamplingFactors.Height;
		ref HuffmanTable dcTable = ref dcHuffmanTables[jpegComponent.DcTableId];
		ref HuffmanTable acTable = ref acHuffmanTables[jpegComponent.AcTableId];
		ref JpegBitReader reference = ref scanBuffer;
		for (int i = 0; i < mcusPerColumn; i++)
		{
			cancellationToken.ThrowIfCancellationRequested();
			for (int j = 0; j < height; j++)
			{
				ref Block8x8 reference2 = ref MemoryMarshal.GetReference<Block8x8>(jpegComponent.SpectralBlocks.DangerousGetRowSpan(j));
				for (int k = 0; k < widthInBlocks; k++)
				{
					if (reference.NoData)
					{
						spectralConverter.ConvertStrideBaseline();
						return;
					}
					DecodeBlockBaseline(jpegComponent, ref Unsafe.Add(ref reference2, (uint)k), ref dcTable, ref acTable);
					HandleRestart();
				}
			}
			spectralConverter.ConvertStrideBaseline();
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

	private void ParseProgressiveData()
	{
		CheckProgressiveData();
		if (scanComponentCount == 1)
		{
			ParseProgressiveDataNonInterleaved();
		}
		else
		{
			ParseProgressiveDataInterleaved();
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
				int num2 = num / mcusPerLine;
				int num3 = num % mcusPerLine;
				for (int k = 0; k < scanComponentCount; k++)
				{
					int num4 = frame.ComponentOrder[k];
					JpegComponent jpegComponent = components[num4] as JpegComponent;
					ref HuffmanTable dcTable = ref dcHuffmanTables[jpegComponent.DcTableId];
					int horizontalSamplingFactor = jpegComponent.HorizontalSamplingFactor;
					int verticalSamplingFactor = jpegComponent.VerticalSamplingFactor;
					for (int l = 0; l < verticalSamplingFactor; l++)
					{
						int y = num2 * verticalSamplingFactor + l;
						ref Block8x8 reference2 = ref MemoryMarshal.GetReference<Block8x8>(jpegComponent.SpectralBlocks.DangerousGetRowSpan(y));
						for (int m = 0; m < horizontalSamplingFactor; m++)
						{
							if (reference.NoData)
							{
								return;
							}
							int num5 = num3 * horizontalSamplingFactor + m;
							DecodeBlockProgressiveDC(jpegComponent, ref Unsafe.Add(ref reference2, (uint)num5), ref dcTable);
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
		JpegComponent jpegComponent = components[frame.ComponentOrder[0]] as JpegComponent;
		ref JpegBitReader reference = ref scanBuffer;
		int widthInBlocks = jpegComponent.WidthInBlocks;
		int heightInBlocks = jpegComponent.HeightInBlocks;
		if (SpectralStart == 0)
		{
			ref HuffmanTable dcTable = ref dcHuffmanTables[jpegComponent.DcTableId];
			for (int i = 0; i < heightInBlocks; i++)
			{
				cancellationToken.ThrowIfCancellationRequested();
				ref Block8x8 reference2 = ref MemoryMarshal.GetReference<Block8x8>(jpegComponent.SpectralBlocks.DangerousGetRowSpan(i));
				for (int j = 0; j < widthInBlocks; j++)
				{
					if (reference.NoData)
					{
						return;
					}
					DecodeBlockProgressiveDC(jpegComponent, ref Unsafe.Add(ref reference2, (uint)j), ref dcTable);
					HandleRestart();
				}
			}
			return;
		}
		ref HuffmanTable acTable = ref acHuffmanTables[jpegComponent.AcTableId];
		for (int k = 0; k < heightInBlocks; k++)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ref Block8x8 reference3 = ref MemoryMarshal.GetReference<Block8x8>(jpegComponent.SpectralBlocks.DangerousGetRowSpan(k));
			for (int l = 0; l < widthInBlocks; l++)
			{
				if (reference.NoData)
				{
					return;
				}
				DecodeBlockProgressiveAC(ref Unsafe.Add(ref reference3, (uint)l), ref acTable);
				HandleRestart();
			}
		}
	}

	private void DecodeBlockBaseline(JpegComponent component, ref Block8x8 block, ref HuffmanTable dcTable, ref HuffmanTable acTable)
	{
		ref short reference = ref Unsafe.As<Block8x8, short>(ref block);
		ref JpegBitReader reference2 = ref scanBuffer;
		int num = reference2.DecodeHuffman(ref dcTable);
		if (num != 0)
		{
			num = reference2.Receive(num);
		}
		num = (component.DcPredictor = num + component.DcPredictor);
		reference = (short)num;
		int num3 = 1;
		while (num3 < 64)
		{
			int num4 = reference2.DecodeHuffman(ref acTable);
			int num5 = num4 >> 4;
			num4 &= 0xF;
			if (num4 != 0)
			{
				num3 += num5;
				num4 = reference2.Receive(num4);
				Unsafe.Add(ref reference, (int)ZigZag.TransposingOrder[num3++]) = (short)num4;
				continue;
			}
			if (num5 != 0)
			{
				num3 += 16;
				continue;
			}
			break;
		}
	}

	private void DecodeBlockProgressiveDC(JpegComponent component, ref Block8x8 block, ref HuffmanTable dcTable)
	{
		ref short reference = ref Unsafe.As<Block8x8, short>(ref block);
		ref JpegBitReader reference2 = ref scanBuffer;
		if (SuccessiveHigh == 0)
		{
			int num = reference2.DecodeHuffman(ref dcTable);
			if (num != 0)
			{
				num = reference2.Receive(num);
			}
			num = (component.DcPredictor = num + component.DcPredictor);
			reference = (short)(num << SuccessiveLow);
		}
		else
		{
			reference2.CheckBits();
			reference |= (short)(reference2.GetBits(1) << SuccessiveLow);
		}
	}

	private void DecodeBlockProgressiveAC(ref Block8x8 block, ref HuffmanTable acTable)
	{
		ref short reference = ref Unsafe.As<Block8x8, short>(ref block);
		if (SuccessiveHigh == 0)
		{
			if (eobrun != 0)
			{
				eobrun--;
				return;
			}
			ref JpegBitReader reference2 = ref scanBuffer;
			int spectralStart = SpectralStart;
			int spectralEnd = SpectralEnd;
			int successiveLow = SuccessiveLow;
			int num;
			for (num = spectralStart; num <= spectralEnd; num++)
			{
				int num2 = reference2.DecodeHuffman(ref acTable);
				int num3 = num2 >> 4;
				num2 &= 0xF;
				num += num3;
				if (num2 != 0)
				{
					num2 = reference2.Receive(num2);
					Unsafe.Add(ref reference, (int)ZigZag.TransposingOrder[num]) = (short)(num2 << successiveLow);
				}
				else if (num3 != 15)
				{
					eobrun = 1 << num3;
					if (num3 != 0)
					{
						reference2.CheckBits();
						eobrun += reference2.GetBits(num3);
					}
					eobrun--;
					break;
				}
			}
		}
		else
		{
			DecodeBlockProgressiveACRefined(ref reference, ref acTable);
		}
	}

	private void DecodeBlockProgressiveACRefined(ref short blockDataRef, ref HuffmanTable acTable)
	{
		ref JpegBitReader reference = ref scanBuffer;
		int spectralStart = SpectralStart;
		int spectralEnd = SpectralEnd;
		int num = 1 << SuccessiveLow;
		int num2 = -1 << SuccessiveLow;
		int i = spectralStart;
		if (eobrun == 0)
		{
			for (; i <= spectralEnd; i++)
			{
				int num3 = reference.DecodeHuffman(ref acTable);
				int num4 = num3 >> 4;
				num3 &= 0xF;
				if (num3 != 0)
				{
					reference.CheckBits();
					num3 = ((reference.GetBits(1) == 0) ? num2 : num);
				}
				else if (num4 != 15)
				{
					eobrun = 1 << num4;
					if (num4 != 0)
					{
						reference.CheckBits();
						eobrun += reference.GetBits(num4);
					}
					break;
				}
				do
				{
					ref short reference2 = ref Unsafe.Add(ref blockDataRef, (int)ZigZag.TransposingOrder[i]);
					if (reference2 != 0)
					{
						reference.CheckBits();
						if (reference.GetBits(1) != 0 && (reference2 & num) == 0)
						{
							reference2 += (short)((reference2 >= 0) ? num : num2);
						}
					}
					else if (--num4 < 0)
					{
						break;
					}
					i++;
				}
				while (i <= spectralEnd);
				if (num3 != 0 && i < 64)
				{
					Unsafe.Add(ref blockDataRef, (int)ZigZag.TransposingOrder[i]) = (short)num3;
				}
			}
		}
		if (eobrun <= 0)
		{
			return;
		}
		for (; i <= spectralEnd; i++)
		{
			ref short reference3 = ref Unsafe.Add(ref blockDataRef, (int)ZigZag.TransposingOrder[i]);
			if (reference3 != 0)
			{
				reference.CheckBits();
				if (reference.GetBits(1) != 0 && (reference3 & num) == 0)
				{
					reference3 += (short)((reference3 >= 0) ? num : num2);
				}
			}
		}
		eobrun--;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void Reset()
	{
		for (int i = 0; i < components.Length; i++)
		{
			components[i].DcPredictor = 0;
		}
		eobrun = 0;
		scanBuffer.Reset();
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
	public void BuildHuffmanTable(int type, int index, ReadOnlySpan<byte> codeLengths, ReadOnlySpan<byte> values, Span<uint> workspace)
	{
		((type == 0) ? dcHuffmanTables : acHuffmanTables)[index] = new HuffmanTable(codeLengths, values, workspace);
	}
}
