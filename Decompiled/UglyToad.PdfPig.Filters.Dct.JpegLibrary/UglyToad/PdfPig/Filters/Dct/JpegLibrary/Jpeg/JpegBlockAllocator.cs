using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg;

internal sealed class JpegBlockAllocator : IDisposable
{
	private struct ComponentAllocation
	{
		public int HorizontalSubsamplingFactor;

		public int VerticalSubsamplingFactor;

		public int HorizontalComponentBlock;

		public int VerticalComponentBlock;

		public int ComponentBlockOffset;
	}

	private readonly MemoryPool<byte> _memoryPool;

	private IMemoryOwner<byte>? _bufferHandle;

	private ComponentAllocation[]? _components;

	public JpegBlockAllocator(MemoryPool<byte>? memoryPool = null)
	{
		_memoryPool = memoryPool ?? MemoryPool<byte>.Shared;
		_bufferHandle = null;
		_components = null;
	}

	public void Allocate(JpegFrameHeader frameHeader)
	{
		if (_bufferHandle != null)
		{
			throw new InvalidOperationException();
		}
		int num = 1;
		int num2 = 1;
		JpegFrameComponentSpecificationParameters[] components = frameHeader.Components;
		for (int i = 0; i < components.Length; i++)
		{
			JpegFrameComponentSpecificationParameters jpegFrameComponentSpecificationParameters = components[i];
			num = Math.Max(num, jpegFrameComponentSpecificationParameters.HorizontalSamplingFactor);
			num2 = Math.Max(num2, jpegFrameComponentSpecificationParameters.VerticalSamplingFactor);
		}
		int num3 = (frameHeader.SamplesPerLine + 7) / 8;
		int num4 = (frameHeader.NumberOfLines + 7) / 8;
		ComponentAllocation[] array = (_components = new ComponentAllocation[frameHeader.NumberOfComponents]);
		int num5 = 0;
		components = frameHeader.Components;
		for (int i = 0; i < components.Length; i++)
		{
			JpegFrameComponentSpecificationParameters jpegFrameComponentSpecificationParameters2 = components[i];
			int num6 = num / jpegFrameComponentSpecificationParameters2.HorizontalSamplingFactor;
			int num7 = num2 / jpegFrameComponentSpecificationParameters2.VerticalSamplingFactor;
			int horizontalComponentBlock = (num3 + num6 - 1) / num6;
			int verticalComponentBlock = (num4 + num7 - 1) / num7;
			array[num5++] = new ComponentAllocation
			{
				HorizontalComponentBlock = horizontalComponentBlock,
				VerticalComponentBlock = verticalComponentBlock,
				HorizontalSubsamplingFactor = num6,
				VerticalSubsamplingFactor = num7
			};
		}
		num5 = 1;
		for (int j = 0; j < array.Length; j++)
		{
			array[j].ComponentBlockOffset = num5;
			num5 += array[j].HorizontalComponentBlock * array[j].VerticalComponentBlock;
		}
		int num8 = num5 * Unsafe.SizeOf<JpegBlock8x8>();
		(_bufferHandle = _memoryPool.Rent(num8)).Memory.Span.Slice(0, num8).Clear();
	}

	public ref JpegBlock8x8 GetBlockReference(int componentIndex, int blockX, int blockY)
	{
		ComponentAllocation[] components = _components;
		if (components == null)
		{
			throw new InvalidOperationException();
		}
		if ((uint)componentIndex >= (uint)components.Length)
		{
			throw new ArgumentOutOfRangeException("componentIndex");
		}
		ComponentAllocation componentAllocation = components[componentIndex];
		ref JpegBlock8x8 reference = ref Unsafe.As<byte, JpegBlock8x8>(ref MemoryMarshal.GetReference(_bufferHandle.Memory.Span));
		if (blockX >= componentAllocation.HorizontalComponentBlock || blockY >= componentAllocation.VerticalComponentBlock)
		{
			return ref reference;
		}
		return ref Unsafe.Add(ref reference, componentAllocation.ComponentBlockOffset + blockY * componentAllocation.HorizontalComponentBlock + blockX);
	}

	public void Flush(JpegBlockOutputWriter outputWriter)
	{
		if (outputWriter == null)
		{
			throw new ArgumentNullException("outputWriter");
		}
		ComponentAllocation[] components = _components;
		if (components == null)
		{
			return;
		}
		for (int i = 0; i < components.Length; i++)
		{
			ComponentAllocation componentAllocation = components[i];
			ref JpegBlock8x8 source = ref Unsafe.Add(ref Unsafe.As<byte, JpegBlock8x8>(ref MemoryMarshal.GetReference(_bufferHandle.Memory.Span)), componentAllocation.ComponentBlockOffset);
			for (int j = 0; j < componentAllocation.VerticalComponentBlock; j++)
			{
				ref JpegBlock8x8 source2 = ref Unsafe.Add(ref source, j * componentAllocation.HorizontalComponentBlock);
				for (int k = 0; k < componentAllocation.HorizontalComponentBlock; k++)
				{
					WriteBlock(outputWriter, in Unsafe.Add(ref source2, k), i, k * componentAllocation.HorizontalSubsamplingFactor * 8, j * componentAllocation.VerticalSubsamplingFactor * 8, componentAllocation.HorizontalSubsamplingFactor, componentAllocation.VerticalSubsamplingFactor);
				}
			}
		}
	}

	private static void WriteBlock(JpegBlockOutputWriter outputWriter, in JpegBlock8x8 block, int componentIndex, int x, int y, int horizontalSamplingFactor, int verticalSamplingFactor)
	{
		ref short reference = ref Unsafe.As<JpegBlock8x8, short>(ref Unsafe.AsRef(in block));
		if (horizontalSamplingFactor == 1 && verticalSamplingFactor == 1)
		{
			outputWriter.WriteBlock(ref reference, componentIndex, x, y);
			return;
		}
		Unsafe.SkipInit<JpegBlock8x8>(out var value);
		int num = JpegMathHelper.Log2((uint)horizontalSamplingFactor);
		int num2 = JpegMathHelper.Log2((uint)verticalSamplingFactor);
		ref short reference2 = ref Unsafe.As<JpegBlock8x8, short>(ref Unsafe.AsRef(in value));
		for (int i = 0; i < verticalSamplingFactor; i++)
		{
			for (int j = 0; j < horizontalSamplingFactor; j++)
			{
				int num3 = 8 * i;
				int num4 = 8 * j;
				for (int k = 0; k < 8; k++)
				{
					ref short source = ref Unsafe.Add(ref reference2, 8 * k);
					ref short source2 = ref Unsafe.Add(ref reference, (num3 + k >> num2) * 8);
					for (int l = 0; l < 8; l++)
					{
						Unsafe.Add(ref source, l) = Unsafe.Add(ref source2, num4 + l >> num);
					}
				}
				outputWriter.WriteBlock(ref reference2, componentIndex, x + 8 * j, y + 8 * i);
			}
		}
	}

	public void Dispose()
	{
		if (_bufferHandle != null)
		{
			_bufferHandle.Dispose();
			_bufferHandle = null;
		}
	}
}
