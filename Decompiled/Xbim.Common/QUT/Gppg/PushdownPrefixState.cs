using System;

namespace QUT.Gppg;

public class PushdownPrefixState<T>
{
	private T[] array = new T[8];

	private int tos;

	public T this[int index] => array[index];

	public int Depth => tos;

	internal void Push(T value)
	{
		if (tos >= array.Length)
		{
			T[] destinationArray = new T[array.Length * 2];
			Array.Copy(array, destinationArray, tos);
			array = destinationArray;
		}
		array[tos++] = value;
	}

	internal T Pop()
	{
		T result = array[--tos];
		array[tos] = default(T);
		return result;
	}

	internal T TopElement()
	{
		return array[tos - 1];
	}

	internal bool IsEmpty()
	{
		return tos == 0;
	}

	internal void Clear()
	{
		array = new T[8];
		tos = 0;
	}
}
