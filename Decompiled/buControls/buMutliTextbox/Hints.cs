using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns27;

namespace buMutliTextbox;

public class Hints : IDisposable, IEnumerable, ICollection<Hint>, IEnumerable<Hint>
{
	[CompilerGenerated]
	internal sealed class Class57 : IDisposable, IEnumerator, IEnumerator<Hint>
	{
		internal int int_0;

		private Hint hint_0;

		public Hints hints_0;

		internal List<Hint>.Enumerator enumerator_0;

		private Hint hint_1;

		Hint IEnumerator<Hint>.Current => hint_0;

		object IEnumerator.Current => hint_0;

		public Class57(int int_1)
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
					Class76.smethod_629(this);
				}
			}
			enumerator_0 = default(List<Hint>.Enumerator);
			hint_1 = null;
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
					enumerator_0 = hints_0.list_0.GetEnumerator();
					int_0 = -3;
				}
				else
				{
					if (num != 1)
					{
						return false;
					}
					int_0 = -3;
					hint_1 = null;
				}
				if (enumerator_0.MoveNext())
				{
					hint_1 = enumerator_0.Current;
					hint_0 = hint_1;
					int_0 = 1;
					return true;
				}
				Class76.smethod_629(this);
				enumerator_0 = default(List<Hint>.Enumerator);
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

	internal buMultiTextBox tb;

	private List<Hint> list_0 = new List<Hint>();

	public int Count => list_0.Count;

	public bool IsReadOnly => false;

	public Hints(buMultiTextBox tb)
	{
		this.tb = tb;
		tb.TextChanged += OnTextBoxTextChanged;
		tb.KeyDown += OnTextBoxKeyDown;
		tb.VisibleRangeChanged += method_0;
	}

	protected virtual void OnTextBoxKeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && e.Modifiers == Keys.None)
		{
			Clear();
		}
	}

	protected virtual void OnTextBoxTextChanged(object sender, TextChangedEventArgs e)
	{
		Clear();
	}

	public void Dispose()
	{
		tb.TextChanged -= OnTextBoxTextChanged;
		tb.KeyDown -= OnTextBoxKeyDown;
		tb.VisibleRangeChanged -= method_0;
	}

	private void method_0(object sender, EventArgs e)
	{
		if (list_0.Count == 0)
		{
			return;
		}
		tb.NeedRecalc(forced: true);
		foreach (Hint item in list_0)
		{
			Class76.smethod_508(this, item);
			item.HostPanel.Invalidate();
		}
	}

	[IteratorStateMachine(typeof(Class57))]
	public IEnumerator<Hint> GetEnumerator()
	{
		//yield-return decompiler failed: Method not found
		return new Class57(0)
		{
			hints_0 = this
		};
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void Clear()
	{
		list_0.Clear();
		if (tb.Controls.Count == 0)
		{
			return;
		}
		List<Control> list = new List<Control>();
		foreach (Control control in tb.Controls)
		{
			if (control is UnfocusablePanel)
			{
				list.Add(control);
			}
		}
		foreach (Control item in list)
		{
			tb.Controls.Remove(item);
		}
		for (int i = 0; i < tb.LineInfos.Count; i++)
		{
			LineInfo value = tb.LineInfos[i];
			value.int_0 = 0;
			tb.LineInfos[i] = value;
		}
		tb.NeedRecalc();
		tb.Invalidate();
		tb.Select();
		tb.ActiveControl = null;
	}

	public void Add(Hint hint)
	{
		list_0.Add(hint);
		if (hint.Inline)
		{
			LineInfo value = tb.LineInfos[hint.Range.Start.iLine];
			hint.method_1(value.int_0);
			value.int_0 += hint.HostPanel.Height;
			tb.LineInfos[hint.Range.Start.iLine] = value;
			tb.NeedRecalc(forced: true);
		}
		Class76.smethod_508(this, hint);
		tb.OnVisibleRangeChanged();
		hint.HostPanel.Parent = tb;
		tb.Select();
		tb.ActiveControl = null;
		tb.Invalidate();
	}

	public bool Contains(Hint item)
	{
		return list_0.Contains(item);
	}

	public void CopyTo(Hint[] array, int arrayIndex)
	{
		list_0.CopyTo(array, arrayIndex);
	}

	public bool Remove(Hint item)
	{
		throw new NotImplementedException();
	}
}
