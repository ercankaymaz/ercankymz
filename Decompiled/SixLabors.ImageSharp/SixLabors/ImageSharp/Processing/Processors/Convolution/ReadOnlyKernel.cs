using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SixLabors.ImageSharp.Processing.Processors.Convolution;

internal readonly ref struct ReadOnlyKernel(DenseMatrix<float> matrix)
{
	private readonly ReadOnlySpan<float> values = matrix.Span;

	public uint Columns
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get;
	} = (uint)matrix.Columns;

	public uint Rows
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get;
	} = (uint)matrix.Rows;

	public float this[uint row, uint column]
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return Unsafe.Add(ref MemoryMarshal.GetReference<float>(values), row * Columns + column);
		}
	}

	[Conditional("DEBUG")]
	private void CheckCoordinates(uint row, uint column)
	{
		if (row >= Rows)
		{
			throw new ArgumentOutOfRangeException("row", row, $"{row} is outwith the matrix bounds.");
		}
		if (column >= Columns)
		{
			throw new ArgumentOutOfRangeException("column", column, $"{column} is outwith the matrix bounds.");
		}
	}
}
