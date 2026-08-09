using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Poly2Tri.Utility;

public struct FixedArray3<T> : IEnumerable<T>, IEnumerable where T : IEquatable<T>
{
	[CompilerGenerated]
	private sealed class Class126 : IEnumerable<T>, IEnumerator<T>, IEnumerable, IDisposable, IEnumerator
	{
		private int int_0;

		private T gparam_0;

		private int int_1;

		public FixedArray3<T> fixedArray3_0;

		public FixedArray3<T> fixedArray3_1;

		private int int_2;

		T IEnumerator<T>.Current => gparam_0;

		object IEnumerator.Current => gparam_0;

		public Class126(int int_3)
		{
			int_0 = int_3;
			int_1 = Environment.CurrentManagedThreadId;
		}

		void IDisposable.Dispose()
		{
			int_0 = -2;
		}

		bool IEnumerator.MoveNext()
		{
			int num = int_0;
			if (num == 0)
			{
				int_0 = -1;
				int_2 = 0;
			}
			else
			{
				if (num != 1)
				{
					return false;
				}
				int_0 = -1;
				int num2 = int_2 + 1;
				int_2 = num2;
			}
			if (int_2 < 3)
			{
				gparam_0 = fixedArray3_0[int_2];
				int_0 = 1;
				return true;
			}
			return false;
		}

		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			Class126 @class;
			if (int_0 != -2 || int_1 != Environment.CurrentManagedThreadId)
			{
				@class = new Class126(0);
			}
			else
			{
				int_0 = 0;
				@class = this;
			}
			@class.fixedArray3_0 = fixedArray3_1;
			return @class;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<T>)this).GetEnumerator();
		}
	}

	public T Item0;

	public T Item1;

	public T Item2;

	public T this[int index]
	{
		get
		{
			return index switch
			{
				2 => Item2, 
				0 => Item0, 
				1 => Item1, 
				_ => throw new IndexOutOfRangeException(), 
			};
		}
		set
		{
			switch (index)
			{
			case 2:
				Item2 = value;
				break;
			default:
				throw new IndexOutOfRangeException();
			case 0:
				Item0 = value;
				break;
			case 1:
				Item1 = value;
				break;
			}
		}
	}

	public bool Contains(T value)
	{
		return IndexOf(value) != -1;
	}

	public int IndexOf(T value)
	{
		for (int i = 0; i < 3; i++)
		{
			if (!this[i].Equals(default(T)) && this[i].Equals(value))
			{
				return i;
			}
		}
		return -1;
	}

	public void Clear()
	{
		Item0 = (Item1 = (Item2 = default(T)));
	}

	public void Clear(T value)
	{
		for (int i = 0; i < 3; i++)
		{
			if (this[i].Equals(default(T)) && this[i].Equals(value))
			{
				this[i] = default(T);
			}
		}
	}

	private IEnumerable<T> method_0()
	{
		//yield-return decompiler failed: Method not found
		return new Class126(-2)
		{
			fixedArray3_1 = this
		};
	}

	public IEnumerator<T> GetEnumerator()
	{
		return method_0().GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
