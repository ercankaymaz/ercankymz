using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SixLabors.ImageSharp.Processing.Processors.Convolution;

internal readonly ref struct Convolution2DState(in DenseMatrix<float> kernelY, in DenseMatrix<float> kernelX, KernelSamplingMap map)
{
	private readonly Span<int> rowOffsetMap = map.GetRowOffsetSpan();

	private readonly Span<int> columnOffsetMap = map.GetColumnOffsetSpan();

	private readonly uint kernelHeight = (uint)kernelY.Rows;

	private readonly uint kernelWidth = (uint)kernelY.Columns;

	public ReadOnlyKernel KernelY
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get;
	} = new ReadOnlyKernel(kernelY);

	public ReadOnlyKernel KernelX
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get;
	} = new ReadOnlyKernel(kernelX);

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
