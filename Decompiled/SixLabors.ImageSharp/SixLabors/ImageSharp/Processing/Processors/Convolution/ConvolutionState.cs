using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SixLabors.ImageSharp.Processing.Processors.Convolution;

internal readonly ref struct ConvolutionState(in DenseMatrix<float> kernel, KernelSamplingMap map)
{
	private readonly Span<int> rowOffsetMap = map.GetRowOffsetSpan();

	private readonly Span<int> columnOffsetMap = map.GetColumnOffsetSpan();

	private readonly uint kernelHeight = (uint)kernel.Rows;

	private readonly uint kernelWidth = (uint)kernel.Columns;

	public ReadOnlyKernel Kernel
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get;
	} = new ReadOnlyKernel(kernel);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public ref int GetSampleRow(uint row)
	{
		return ref Unsafe.Add(ref MemoryMarshal.GetReference<int>(rowOffsetMap), row * kernelHeight);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public ref int GetSampleColumn(uint column)
	{
		return ref Unsafe.Add(ref MemoryMarshal.GetReference<int>(columnOffsetMap), column * kernelWidth);
	}
}
