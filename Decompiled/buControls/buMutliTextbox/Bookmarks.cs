using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ns27;

namespace buMutliTextbox;

public class Bookmarks : BaseBookmarks
{
	[CompilerGenerated]
	internal sealed class Class37 : IEnumerator<Bookmark>, IDisposable, IEnumerator
	{
		internal int int_0;

		private Bookmark bookmark_0;

		public Bookmarks bookmarks_0;

		internal List<Bookmark>.Enumerator enumerator_0;

		private Bookmark bookmark_1;

		Bookmark IEnumerator<Bookmark>.Current => bookmark_0;

		object IEnumerator.Current => bookmark_0;

		public Class37(int int_1)
		{
			int_0 = int_1;
		}

		void IDisposable.Dispose()
		{
			int num = int_0;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					Class76.smethod_8(this);
				}
			}
			enumerator_0 = default(List<Bookmark>.Enumerator);
			bookmark_1 = null;
			int_0 = -2;
		}

		bool IEnumerator.MoveNext()
		{
			try
			{
				int num = int_0;
				if (num == 0)
				{
					int_0 = -1;
					enumerator_0 = bookmarks_0.items.GetEnumerator();
					int_0 = -3;
				}
				else
				{
					if (num != 1)
					{
						return false;
					}
					int_0 = -3;
					bookmark_1 = null;
				}
				if (enumerator_0.MoveNext())
				{
					bookmark_1 = enumerator_0.Current;
					bookmark_0 = bookmark_1;
					int_0 = 1;
					return true;
				}
				Class76.smethod_8(this);
				enumerator_0 = default(List<Bookmark>.Enumerator);
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	protected buMultiTextBox tb;

	protected List<Bookmark> items = new List<Bookmark>();

	protected int counter;

	public override int Count => items.Count;

	public override bool IsReadOnly => false;

	public Bookmarks(buMultiTextBox tb)
	{
		this.tb = tb;
		tb.LineInserted += tb_LineInserted;
		tb.LineRemoved += tb_LineRemoved;
	}

	protected virtual void tb_LineRemoved(object sender, LineRemovedEventArgs e)
	{
		for (int i = 0; i < Count; i++)
		{
			if (items[i].LineIndex < e.Index)
			{
				continue;
			}
			if (items[i].LineIndex < e.Index + e.Count)
			{
				bool flag = e.Index <= 0;
				foreach (Bookmark item in items)
				{
					if (item.LineIndex == e.Index - 1)
					{
						flag = true;
					}
				}
				if (!flag)
				{
					items[i].LineIndex = e.Index - 1;
					continue;
				}
				items.RemoveAt(i);
				i--;
			}
			else
			{
				items[i].LineIndex = items[i].LineIndex - e.Count;
			}
		}
	}

	protected virtual void tb_LineInserted(object sender, LineInsertedEventArgs e)
	{
		for (int i = 0; i < Count; i++)
		{
			if (items[i].LineIndex < e.Index)
			{
				if (items[i].LineIndex == e.Index - 1 && e.Count == 1 && tb[e.Index - 1].StartSpacesCount == tb[e.Index - 1].Count)
				{
					items[i].LineIndex = items[i].LineIndex + e.Count;
				}
			}
			else
			{
				items[i].LineIndex = items[i].LineIndex + e.Count;
			}
		}
	}

	public override void Dispose()
	{
		tb.LineInserted -= tb_LineInserted;
		tb.LineRemoved -= tb_LineRemoved;
	}

	[IteratorStateMachine(typeof(Class37))]
	public override IEnumerator<Bookmark> GetEnumerator()
	{
		//yield-return decompiler failed: Method not found
		return new Class37(0)
		{
			bookmarks_0 = this
		};
	}

	public override void Add(int lineIndex, string bookmarkName)
	{
		Add(new Bookmark(tb, bookmarkName ?? ("Bookmark " + counter), lineIndex));
	}

	public override void Add(int lineIndex)
	{
		Add(new Bookmark(tb, "Bookmark " + counter, lineIndex));
	}

	public override void Clear()
	{
		items.Clear();
		counter = 0;
	}

	public override void Add(Bookmark bookmark)
	{
		foreach (Bookmark item in items)
		{
			if (item.LineIndex == bookmark.LineIndex)
			{
				return;
			}
		}
		items.Add(bookmark);
		counter++;
		tb.Invalidate();
	}

	public override bool Contains(Bookmark item)
	{
		return items.Contains(item);
	}

	public override bool Contains(int lineIndex)
	{
		foreach (Bookmark item in items)
		{
			if (item.LineIndex == lineIndex)
			{
				return true;
			}
		}
		return false;
	}

	public override void CopyTo(Bookmark[] array, int arrayIndex)
	{
		items.CopyTo(array, arrayIndex);
	}

	public override bool Remove(Bookmark item)
	{
		tb.Invalidate();
		return items.Remove(item);
	}

	public override bool Remove(int lineIndex)
	{
		bool result = false;
		for (int i = 0; i < Count; i++)
		{
			if (items[i].LineIndex == lineIndex)
			{
				items.RemoveAt(i);
				i--;
				result = true;
			}
		}
		tb.Invalidate();
		return result;
	}

	public override Bookmark GetBookmark(int i)
	{
		return items[i];
	}
}
