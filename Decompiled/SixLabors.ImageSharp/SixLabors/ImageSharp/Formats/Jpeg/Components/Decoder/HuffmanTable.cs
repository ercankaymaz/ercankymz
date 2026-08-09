using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SixLabors.ImageSharp.Formats.Jpeg.Components.Decoder;

internal struct HuffmanTable
{
	public const int WorkspaceByteSize = 1024;

	public unsafe fixed byte Values[256];

	public unsafe fixed ulong MaxCode[18];

	public unsafe fixed int ValOffset[19];

	public unsafe fixed byte LookaheadSize[256];

	public unsafe fixed byte LookaheadValue[256];

	public unsafe HuffmanTable(ReadOnlySpan<byte> codeLengths, ReadOnlySpan<byte> values, Span<uint> workspace)
	{
		Unsafe.CopyBlockUnaligned(ref Values[0], ref MemoryMarshal.GetReference<byte>(values), (uint)values.Length);
		uint num = 0u;
		int num2 = 1;
		int num3 = 0;
		for (int i = 1; i <= 16; i++)
		{
			int num4 = codeLengths[i];
			for (int j = 0; j < num4; j++)
			{
				workspace[num3++] = num;
				num++;
			}
			if (num >= 1 << num2)
			{
				JpegThrowHelper.ThrowInvalidImageContentException("Bad huffman table.");
			}
			num <<= 1;
			num2++;
		}
		num3 = 0;
		for (int k = 1; k <= 16; k++)
		{
			if (codeLengths[k] != 0)
			{
				ValOffset[k] = num3 - (int)workspace[num3];
				num3 += codeLengths[k];
				MaxCode[k] = workspace[num3 - 1];
				ref ulong reference = ref MaxCode[k];
				reference <<= 64 - k;
				ref ulong reference2 = ref MaxCode[k];
				reference2 |= (ulong)((1L << 64 - k) - 1);
			}
			else
			{
				MaxCode[k] = 0uL;
			}
		}
		ValOffset[18] = 0;
		MaxCode[17] = ulong.MaxValue;
		Unsafe.InitBlockUnaligned(ref LookaheadSize[0], 9, 256u);
		num3 = 0;
		for (int l = 1; l <= 8; l++)
		{
			int num5 = 8 - l;
			int num6 = 1;
			while (num6 <= codeLengths[l])
			{
				int num7 = (int)(workspace[num3] << num5);
				for (int num8 = 1 << 8 - l; num8 > 0; num8--)
				{
					LookaheadSize[num7] = (byte)l;
					LookaheadValue[num7] = Values[num3];
					num7++;
				}
				num6++;
				num3++;
			}
		}
	}
}
