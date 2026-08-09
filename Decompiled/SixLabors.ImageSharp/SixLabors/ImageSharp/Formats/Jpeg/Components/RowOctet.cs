using System;
using System.Runtime.CompilerServices;
using SixLabors.ImageSharp.Memory;

namespace SixLabors.ImageSharp.Formats.Jpeg.Components;

internal ref struct RowOctet<T> where T : struct
{
	private Span<T> row0;

	private Span<T> row1;

	private Span<T> row2;

	private Span<T> row3;

	private Span<T> row4;

	private Span<T> row5;

	private Span<T> row6;

	private Span<T> row7;

	public Span<T> this[int y]
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return y switch
			{
				0 => row0, 
				1 => row1, 
				2 => row2, 
				3 => row3, 
				4 => row4, 
				5 => row5, 
				6 => row6, 
				7 => row7, 
				_ => ThrowIndexOutOfRangeException(), 
			};
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private set
		{
			switch (y)
			{
			case 0:
				row0 = value;
				break;
			case 1:
				row1 = value;
				break;
			case 2:
				row2 = value;
				break;
			case 3:
				row3 = value;
				break;
			case 4:
				row4 = value;
				break;
			case 5:
				row5 = value;
				break;
			case 6:
				row6 = value;
				break;
			default:
				row7 = value;
				break;
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Update(Buffer2D<T> buffer, int startY)
	{
		int num = startY;
		int num2 = Math.Min(num + 8, buffer.Height);
		int num3 = 0;
		while (num < num2)
		{
			this[num3++] = buffer.DangerousGetRowSpan(num++);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Span<T> ThrowIndexOutOfRangeException()
	{
		throw new IndexOutOfRangeException();
	}
}
