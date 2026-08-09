using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;
using SixLabors.ImageSharp.Memory;

namespace SixLabors.ImageSharp.Formats.Jpeg.Components.Encoder;

internal class ComponentProcessor : IDisposable
{
	private readonly Size blockAreaSize;

	private readonly Component component;

	private Block8x8F quantTable;

	public Buffer2D<float> ColorBuffer { get; }

	public ComponentProcessor(MemoryAllocator memoryAllocator, Component component, Size postProcessorBufferSize, Block8x8F quantTable)
	{
		this.component = component;
		this.quantTable = quantTable;
		this.component = component;
		blockAreaSize = component.SubSamplingDivisors * 8;
		ColorBuffer = memoryAllocator.Allocate2DOveraligned<float>(postProcessorBufferSize.Width, postProcessorBufferSize.Height, 8, AllocationOptions.Clean);
	}

	public void CopyColorBufferToBlocks(int spectralStep)
	{
		Buffer2D<Block8x8> spectralBlocks = component.SpectralBlocks;
		int width = ColorBuffer.Width;
		int num = spectralStep * component.SamplingFactors.Height;
		Block8x8F block = default(Block8x8F);
		Size subSamplingDivisors = component.SubSamplingDivisors;
		if (subSamplingDivisors.Width != 1 || subSamplingDivisors.Height != 1)
		{
			PackColorBuffer();
		}
		int height = component.SamplingFactors.Height;
		for (int i = 0; i < height; i++)
		{
			int y = i * blockAreaSize.Height;
			Span<float> span = ColorBuffer.DangerousGetRowSpan(y);
			Span<Block8x8> span2 = spectralBlocks.DangerousGetRowSpan(num + i);
			for (int j = 0; j < spectralBlocks.Width; j++)
			{
				int index = j * 8;
				block.ScaledCopyFrom(ref span[index], width);
				block.AddInPlace(-128f);
				FloatingPointDCT.TransformFDCT(ref block);
				Block8x8F.Quantize(ref block, ref span2[j], ref quantTable);
			}
		}
	}

	public Span<float> GetColorBufferRowSpan(int row)
	{
		return ColorBuffer.DangerousGetRowSpan(row);
	}

	public void Dispose()
	{
		ColorBuffer.Dispose();
	}

	private void PackColorBuffer()
	{
		Size subSamplingDivisors = component.SubSamplingDivisors;
		int length = ColorBuffer.Width / subSamplingDivisors.Width;
		float multiplier = 1f / (float)(subSamplingDivisors.Width * subSamplingDivisors.Height);
		for (int i = 0; i < ColorBuffer.Height; i += subSamplingDivisors.Height)
		{
			Span<float> target = ColorBuffer.DangerousGetRowSpan(i);
			for (int j = 1; j < subSamplingDivisors.Height; j++)
			{
				SumVertical(target, ColorBuffer.DangerousGetRowSpan(i + j));
			}
			SumHorizontal(target, subSamplingDivisors.Width);
			MultiplyToAverage(target, multiplier);
			target.Slice(0, length).CopyTo(ColorBuffer.DangerousGetRowSpan(i / subSamplingDivisors.Height));
		}
		static void MultiplyToAverage(Span<float> span, float num2)
		{
			if (Avx.IsSupported)
			{
				ref Vector256<float> source = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(span));
				nuint num = span.Vector256Count<float>();
				Vector256<float> right = Vector256.Create(num2);
				for (nuint num3 = 0u; num3 < num; num3++)
				{
					Unsafe.Add(ref source, num3) = Avx.Multiply(Unsafe.Add(ref source, num3), right);
				}
			}
			else if (AdvSimd.IsSupported)
			{
				ref Vector128<float> source2 = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(span));
				nuint num4 = span.Vector128Count<float>();
				Vector128<float> right2 = Vector128.Create(num2);
				for (nuint num5 = 0u; num5 < num4; num5++)
				{
					Unsafe.Add(ref source2, num5) = AdvSimd.Multiply(Unsafe.Add(ref source2, num5), right2);
				}
			}
			else
			{
				ref Vector<float> source3 = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(span));
				nuint num6 = span.VectorCount<float>();
				Vector<float> vector = new Vector<float>(num2);
				for (nuint num7 = 0u; num7 < num6; num7++)
				{
					Unsafe.Add(ref source3, num7) *= vector;
				}
				ref float reference = ref MemoryMarshal.GetReference<float>(span);
				for (nuint num8 = num6 * (uint)Vector<float>.Count; num8 < (uint)span.Length; num8++)
				{
					Unsafe.Add(ref reference, num8) *= num2;
				}
			}
		}
		static void SumHorizontal(Span<float> span2, int factor)
		{
			Span<float> span = span2;
			if (Avx2.IsSupported)
			{
				ref Vector256<float> source = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(span2));
				uint num = (uint)factor / 2u;
				int num2 = span2.Length % (Vector<float>.Count * factor);
				int num3 = span2.Length - num2;
				span = span.Slice(num3);
				span2 = span2.Slice(num3 / factor);
				nuint num4 = Numerics.Vector256Count<float>(num3);
				for (uint num5 = 0u; num5 < num; num5++)
				{
					num4 /= 2;
					for (nuint num6 = 0u; num6 < num4; num6++)
					{
						nuint num7 = num6 * 2;
						nuint elementOffset = num7 + 1;
						Vector256<float> vector = Avx.HorizontalAdd(Unsafe.Add(ref source, num7), Unsafe.Add(ref source, elementOffset));
						Unsafe.Add(ref source, num6) = Avx2.Permute4x64(vector.AsDouble(), 216).AsSingle();
					}
				}
			}
			for (int k = 0; k < span.Length / factor; k++)
			{
				span2[k] = span[k * factor];
				for (int l = 1; l < factor; l++)
				{
					span2[k] += span[k * factor + l];
				}
			}
		}
		static void SumVertical(Span<float> span, Span<float> source)
		{
			if (Avx.IsSupported)
			{
				ref Vector256<float> source2 = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(span));
				ref Vector256<float> source3 = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(source));
				nuint num = source.Vector256Count<float>();
				for (nuint num2 = 0u; num2 < num; num2++)
				{
					Unsafe.Add(ref source2, num2) = Avx.Add(Unsafe.Add(ref source2, num2), Unsafe.Add(ref source3, num2));
				}
			}
			else if (AdvSimd.IsSupported)
			{
				ref Vector128<float> source4 = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(span));
				ref Vector128<float> source5 = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(source));
				nuint num3 = source.Vector128Count<float>();
				for (nuint num4 = 0u; num4 < num3; num4++)
				{
					Unsafe.Add(ref source4, num4) = AdvSimd.Add(Unsafe.Add(ref source4, num4), Unsafe.Add(ref source5, num4));
				}
			}
			else
			{
				ref Vector<float> source6 = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(span));
				ref Vector<float> source7 = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(source));
				nuint num5 = source.VectorCount<float>();
				for (nuint num6 = 0u; num6 < num5; num6++)
				{
					Unsafe.Add(ref source6, num6) += Unsafe.Add(ref source7, num6);
				}
				ref float reference = ref MemoryMarshal.GetReference<float>(span);
				ref float reference2 = ref MemoryMarshal.GetReference<float>(source);
				for (nuint num7 = num5 * (uint)Vector<float>.Count; num7 < (uint)source.Length; num7++)
				{
					Unsafe.Add(ref reference, num7) += Unsafe.Add(ref reference2, num7);
				}
			}
		}
	}
}
