using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace buMutliTextbox;

public class LinesAccessor : IEnumerable, IList<string>, ICollection<string>, IEnumerable<string>
{
	[CompilerGenerated]
	private sealed class Class60 : IDisposable, IEnumerator, IEnumerator<string>
	{
		private int int_0;

		private string string_0;

		public LinesAccessor linesAccessor_0;

		private int int_1;

		string IEnumerator<string>.Current => string_0;

		object IEnumerator.Current => string_0;

		public Class60(int int_2)
		{
			int_0 = int_2;
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
				int_1 = 0;
			}
			else
			{
				if (num != 1)
				{
					return false;
				}
				int_0 = -1;
				int_1++;
			}
			if (int_1 < linesAccessor_0.ts.Count)
			{
				string_0 = linesAccessor_0.ts[int_1].Text;
				int_0 = 1;
				return true;
			}
			return false;
		}

		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	private IList<Line> ts;

	public string this[int index]
	{
		get
		{
			return ts[index].Text;
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public int Count => ts.Count;

	public bool IsReadOnly => true;

	public LinesAccessor(IList<Line> ts)
	{
		this.ts = ts;
	}

	public int IndexOf(string item)
	{
		for (int i = 0; i < ts.Count; i++)
		{
			if (ts[i].Text == item)
			{
				return i;
			}
		}
		return -1;
	}

	public void Insert(int index, string item)
	{
		throw new NotImplementedException();
	}

	public void RemoveAt(int index)
	{
		throw new NotImplementedException();
	}

	public void Add(string item)
	{
		throw new NotImplementedException();
	}

	public void Clear()
	{
		throw new NotImplementedException();
	}

	public bool Contains(string item)
	{
		for (int i = 0; i < ts.Count; i++)
		{
			if (ts[i].Text == item)
			{
				return true;
			}
		}
		return false;
	}

	public void CopyTo(string[] array, int arrayIndex)
	{
		for (int i = 0; i < ts.Count; i++)
		{
			array[i + arrayIndex] = ts[i].Text;
		}
	}

	public bool Remove(string item)
	{
		throw new NotImplementedException();
	}

	[IteratorStateMachine(typeof(Class60))]
	public IEnumerator<string> GetEnumerator()
	{
		//yield-return decompiler failed: Method not found
		return new Class60(0)
		{
			linesAccessor_0 = this
		};
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
