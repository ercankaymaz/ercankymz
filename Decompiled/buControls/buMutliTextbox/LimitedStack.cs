using System;
using System.Runtime.CompilerServices;

namespace buMutliTextbox;

public class LimitedStack<T>
{
	private T[] gparam_0;

	private int int_0;

	private int int_1;

	public int MaxItemCount => gparam_0.Length;

	public int Count => int_0;

	public LimitedStack(int maxItemCount)
	{
		gparam_0 = new T[maxItemCount];
		int_0 = 0;
		int_1 = 0;
	}

	public T Pop()
	{
		if (int_0 == 0)
		{
			throw new Exception("Stack is empty");
		}
		int num = method_0();
		T result = gparam_0[num];
		gparam_0[num] = default(T);
		int_0--;
		return result;
	}

	[SpecialName]
	private int method_0()
	{
		return (int_1 + int_0 - 1) % gparam_0.Length;
	}

	public T Peek()
	{
		if (int_0 != 0)
		{
			return gparam_0[method_0()];
		}
		return default(T);
	}

	public void Push(T item)
	{
		if (int_0 != gparam_0.Length)
		{
			int_0++;
		}
		else
		{
			int_1 = (int_1 + 1) % gparam_0.Length;
		}
		gparam_0[method_0()] = item;
	}

	public void Clear()
	{
		gparam_0 = new T[gparam_0.Length];
		int_0 = 0;
		int_1 = 0;
	}

	public T[] ToArray()
	{
		T[] array = new T[int_0];
		for (int i = 0; i < int_0; i++)
		{
			array[i] = gparam_0[(int_1 + i) % gparam_0.Length];
		}
		return array;
	}
}
