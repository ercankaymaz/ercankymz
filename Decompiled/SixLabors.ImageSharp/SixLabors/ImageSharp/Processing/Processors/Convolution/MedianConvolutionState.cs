using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SixLabors.ImageSharp.Processing.Processors.Convolution;

internal readonly ref struct MedianConvolutionState(in DenseMatrix<Vector4> kernel, KernelSamplingMap map)
{
	private readonly Span<int> rowOffsetMap = map.GetRowOffsetSpan();

	private readonly Span<int> columnOffsetMap = map.GetColumnOffsetSpan();

	private readonly int kernelHeight = kernel.Rows;

	private readonly int kernelWidth = kernel.Columns;

	public Kernel<Vector4> Kernel
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get;
	} = new Kernel<Vector4>(kernel);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public ref int GetSampleRow(int row)
	{
		return ref Unsafe.Add(ref MemoryMarshal.GetReference<int>(rowOffsetMap), (uint)(row * kernelHeight));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public ref int GetSampleColumn(int column)
	{
		return ref Unsafe.Add(ref MemoryMarshal.GetReference<int>(columnOffsetMap), (uint)(column * kernelWidth));
	}
}
