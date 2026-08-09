using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg;

internal sealed class JpegPartialScanlineAllocator
{
	private struct ComponentAllocation
	{
		public int HorizontalSubsamplingFactor;

		public int VerticalSubsamplingFactor;

		public int Width;

		public int Height;

		public int ComponentSampleOffset;
	}

	private readonly JpegBlockOutputWriter _writer;

	private readonly MemoryPool<byte> _memoryPool;

	private IMemoryOwner<byte>? _bufferHandle;

	private ComponentAllocation[]? _components;

	internal JpegPartialScanlineAllocator(JpegBlockOutputWriter writer, MemoryPool<byte>? memoryPool = null)
	{
		_writer = writer;
		_memoryPool = memoryPool ?? MemoryPool<byte>.Shared;
		_bufferHandle = null;
		_components = null;
	}

	public void Allocate(JpegFrameHeader frameHeader)
	{
		int num = 1;
		int num2 = 1;
		JpegFrameComponentSpecificationParameters[] components = frameHeader.Components;
		for (int i = 0; i < components.Length; i++)
		{
			JpegFrameComponentSpecificationParameters jpegFrameComponentSpecificationParameters = components[i];
			num = Math.Max(num, jpegFrameComponentSpecificationParameters.HorizontalSamplingFactor);
			num2 = Math.Max(num2, jpegFrameComponentSpecificationParameters.VerticalSamplingFactor);
		}
		ComponentAllocation[] array = (_components = new ComponentAllocation[frameHeader.NumberOfComponents]);
		int num3 = 0;
		components = frameHeader.Components;
		for (int i = 0; i < components.Length; i++)
		{
			JpegFrameComponentSpecificationParameters jpegFrameComponentSpecificationParameters2 = components[i];
			int num4 = num / jpegFrameComponentSpecificationParameters2.HorizontalSamplingFactor;
			int num5 = num2 / jpegFrameComponentSpecificationParameters2.VerticalSamplingFactor;
			int width = (frameHeader.SamplesPerLine + num4 - 1) / num4;
			int height = (frameHeader.NumberOfLines + num5 - 1) / num5;
			array[num3++] = new ComponentAllocation
			{
				Width = width,
				Height = height,
				HorizontalSubsamplingFactor = num4,
				VerticalSubsamplingFactor = num5
			};
		}
		num3 = 0;
		for (int j = 0; j < array.Length; j++)
		{
			array[j].ComponentSampleOffset = num3;
			num3 += array[j].Width * 16;
		}
		int num6 = num3 * Unsafe.SizeOf<short>();
		(_bufferHandle = _memoryPool.Rent(num6)).Memory.Span.Slice(0, num6).Clear();
	}

	public Span<short> GetScanlineSpan(int componentIndex, int y)
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
		if ((uint)y >= (uint)componentAllocation.Height)
		{
			throw new ArgumentOutOfRangeException("y");
		}
		return MemoryMarshal.Cast<byte, short>(_bufferHandle.Memory.Span).Slice(componentAllocation.ComponentSampleOffset).Slice(componentAllocation.Width * (y & 0xF), componentAllocation.Width);
	}

	public void FlushMcu(int componentIndex, int y)
	{
		if (y % 8 == 0 && y != 0)
		{
			y -= 8;
			FlushCore(componentIndex, y, 8);
		}
	}

	public void FlushLastMcu(int componentIndex, int y)
	{
		if (y != 0)
		{
			int num = (y - 1) / 8 * 8;
			FlushCore(componentIndex, num, y - num);
		}
	}

	private void FlushCore(int componentIndex, int y, int writeHeight)
	{
		ComponentAllocation[] components = _components;
		if (components == null)
		{
			return;
		}
		Unsafe.SkipInit<JpegBlock8x8>(out var value);
		JpegBlockOutputWriter writer = _writer;
		ComponentAllocation componentAllocation = components[componentIndex];
		int width = componentAllocation.Width;
		ref short source = ref Unsafe.Add(ref Unsafe.Add(ref Unsafe.As<byte, short>(ref MemoryMarshal.GetReference(_bufferHandle.Memory.Span)), componentAllocation.ComponentSampleOffset), componentAllocation.Width * (y & 0xF));
		for (int i = 0; i < width; i += 8)
		{
			int num = Math.Min(width - i, 8);
			ref short source2 = ref Unsafe.Add(ref source, i);
			ref short source3 = ref Unsafe.As<JpegBlock8x8, short>(ref value);
			if (writeHeight == 8 && num == 8)
			{
				Unsafe.As<short, long>(ref source3) = Unsafe.As<short, long>(ref source2);
				Unsafe.Add(ref Unsafe.As<short, long>(ref source3), 1) = Unsafe.Add(ref Unsafe.As<short, long>(ref source2), 1);
				source2 = ref Unsafe.Add(ref source2, width);
				Unsafe.Add(ref Unsafe.As<short, long>(ref source3), 2) = Unsafe.As<short, long>(ref source2);
				Unsafe.Add(ref Unsafe.As<short, long>(ref source3), 3) = Unsafe.Add(ref Unsafe.As<short, long>(ref source2), 1);
				source2 = ref Unsafe.Add(ref source2, width);
				Unsafe.Add(ref Unsafe.As<short, long>(ref source3), 4) = Unsafe.As<short, long>(ref source2);
				Unsafe.Add(ref Unsafe.As<short, long>(ref source3), 5) = Unsafe.Add(ref Unsafe.As<short, long>(ref source2), 1);
				source2 = ref Unsafe.Add(ref source2, width);
				Unsafe.Add(ref Unsafe.As<short, long>(ref source3), 6) = Unsafe.As<short, long>(ref source2);
				Unsafe.Add(ref Unsafe.As<short, long>(ref source3), 7) = Unsafe.Add(ref Unsafe.As<short, long>(ref source2), 1);
				source2 = ref Unsafe.Add(ref source2, width);
				Unsafe.Add(ref Unsafe.As<short, long>(ref source3), 8) = Unsafe.As<short, long>(ref source2);
				Unsafe.Add(ref Unsafe.As<short, long>(ref source3), 9) = Unsafe.Add(ref Unsafe.As<short, long>(ref source2), 1);
				source2 = ref Unsafe.Add(ref source2, width);
				Unsafe.Add(ref Unsafe.As<short, long>(ref source3), 10) = Unsafe.As<short, long>(ref source2);
				Unsafe.Add(ref Unsafe.As<short, long>(ref source3), 11) = Unsafe.Add(ref Unsafe.As<short, long>(ref source2), 1);
				source2 = ref Unsafe.Add(ref source2, width);
				Unsafe.Add(ref Unsafe.As<short, long>(ref source3), 12) = Unsafe.As<short, long>(ref source2);
				Unsafe.Add(ref Unsafe.As<short, long>(ref source3), 13) = Unsafe.Add(ref Unsafe.As<short, long>(ref source2), 1);
				source2 = ref Unsafe.Add(ref source2, width);
				Unsafe.Add(ref Unsafe.As<short, long>(ref source3), 14) = Unsafe.As<short, long>(ref source2);
				Unsafe.Add(ref Unsafe.As<short, long>(ref source3), 15) = Unsafe.Add(ref Unsafe.As<short, long>(ref source2), 1);
			}
			else
			{
				for (int j = 0; j < writeHeight; j++)
				{
					for (int k = 0; k < num; k++)
					{
						Unsafe.Add(ref source3, k) = Unsafe.Add(ref source2, j * width + k);
					}
					source3 = ref Unsafe.Add(ref source3, 8);
				}
			}
			WriteBlock(writer, in value, componentIndex, componentAllocation.HorizontalSubsamplingFactor * i, componentAllocation.VerticalSubsamplingFactor * y, componentAllocation.HorizontalSubsamplingFactor, componentAllocation.VerticalSubsamplingFactor);
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
