using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using ns27;

namespace buMutliTextbox;

[ToolboxItem(false)]
public class AutocompleteListView : UserControl, IDisposable
{
	[CompilerGenerated]
	private EventHandler eventHandler_0;

	internal List<AutocompleteItem> list_0;

	internal IEnumerable<AutocompleteItem> ienumerable_0 = new List<AutocompleteItem>();

	private int int_0 = 0;

	private int int_1 = -1;

	internal int int_2 = 0;

	internal buMultiTextBox buMultiTextBox_0;

	internal ToolTip toolTip_0 = new ToolTip();

	internal System.Windows.Forms.Timer timer_0 = new System.Windows.Forms.Timer();

	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private ImageList imageList_0;

	[CompilerGenerated]
	private int int_3;

	[CompilerGenerated]
	private Size size_0;

	[CompilerGenerated]
	private Color color_0;

	[CompilerGenerated]
	private Color color_1;

	public ImageList ImageList
	{
		[CompilerGenerated]
		get
		{
			return imageList_0;
		}
		[CompilerGenerated]
		set
		{
			imageList_0 = value;
		}
	}

	public Color SelectedColor
	{
		[CompilerGenerated]
		get
		{
			return color_0;
		}
		[CompilerGenerated]
		set
		{
			color_0 = value;
		}
	}

	public Color HoveredColor
	{
		[CompilerGenerated]
		get
		{
			return color_1;
		}
		[CompilerGenerated]
		set
		{
			color_1 = value;
		}
	}

	public int FocussedItemIndex
	{
		get
		{
			return int_0;
		}
		set
		{
			if (int_0 != value)
			{
				int_0 = value;
				if (eventHandler_0 != null)
				{
					eventHandler_0(this, EventArgs.Empty);
				}
			}
		}
	}

	public AutocompleteItem FocussedItem
	{
		get
		{
			if (FocussedItemIndex < 0 || int_0 >= list_0.Count)
			{
				return null;
			}
			return list_0[int_0];
		}
		set
		{
			FocussedItemIndex = list_0.IndexOf(value);
		}
	}

	public int Count => list_0.Count;

	public event EventHandler FocussedItemIndexChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal bool method_0()
	{
		return bool_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal void method_1(bool bool_1)
	{
		bool_0 = bool_1;
	}

	[SpecialName]
	[CompilerGenerated]
	internal int method_2()
	{
		return int_3;
	}

	[SpecialName]
	[CompilerGenerated]
	internal void method_3(int int_4)
	{
		int_3 = int_4;
	}

	[SpecialName]
	[CompilerGenerated]
	internal Size method_4()
	{
		return size_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal void method_5(Size size_1)
	{
		size_0 = size_1;
	}

	internal AutocompleteListView(buMultiTextBox buMultiTextBox_1)
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		base.Font = new Font(FontFamily.GenericSansSerif, 9f);
		list_0 = new List<AutocompleteItem>();
		base.VerticalScroll.SmallChange = Class76.smethod_86(this);
		MaximumSize = new Size(base.Size.Width, 180);
		toolTip_0.ShowAlways = false;
		Class76.smethod_11(500, this);
		timer_0.Tick += timer_0_Tick;
		SelectedColor = Color.Orange;
		HoveredColor = Color.Red;
		method_3(3000);
		toolTip_0.Popup += toolTip_0_Popup;
		buMultiTextBox_0 = buMultiTextBox_1;
		buMultiTextBox_1.KeyDown += method_8;
		buMultiTextBox_1.SelectionChanged += method_7;
		buMultiTextBox_1.KeyPressed += method_6;
		Form form = buMultiTextBox_1.FindForm();
		if (form != null)
		{
			form.LocationChanged += delegate
			{
				Class76.smethod_170(this);
			};
			form.ResizeBegin += delegate
			{
				Class76.smethod_170(this);
			};
			form.FormClosing += delegate
			{
				Class76.smethod_170(this);
			};
			form.LostFocus += delegate
			{
				Class76.smethod_170(this);
			};
		}
		buMultiTextBox_1.LostFocus += delegate
		{
			if (Class76.smethod_169(this) != null && !Class76.smethod_169(this).IsDisposed && !Class76.smethod_169(this).Focused)
			{
				Class76.smethod_170(this);
			}
		};
		buMultiTextBox_1.Scroll += delegate
		{
			Class76.smethod_170(this);
		};
		base.VisibleChanged += delegate
		{
			if (base.Visible)
			{
				Class76.smethod_114(this);
			}
		};
	}

	private void toolTip_0_Popup(object sender, PopupEventArgs e)
	{
		if (method_4().Height > 0 && method_4().Width > 0)
		{
			e.ToolTipSize = method_4();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (toolTip_0 != null)
		{
			toolTip_0.Popup -= toolTip_0_Popup;
			toolTip_0.Dispose();
		}
		if (buMultiTextBox_0 != null)
		{
			buMultiTextBox_0.KeyDown -= method_8;
			buMultiTextBox_0.KeyPress -= method_6;
			buMultiTextBox_0.SelectionChanged -= method_7;
		}
		if (timer_0 != null)
		{
			timer_0.Stop();
			timer_0.Tick -= timer_0_Tick;
			timer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void method_6(object sender, KeyPressEventArgs e)
	{
		bool flag = e.KeyChar == '\b' || e.KeyChar == 'ÿ';
		if (!Class76.smethod_169(this).Visible || flag)
		{
			Class76.smethod_315(this, timer_0);
		}
		else
		{
			Class76.smethod_645(this, false);
		}
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		timer_0.Stop();
		Class76.smethod_645(this, false);
	}

	private void method_7(object sender, EventArgs e)
	{
		if (!Class76.smethod_169(this).Visible)
		{
			return;
		}
		bool flag = false;
		if (buMultiTextBox_0.Selection.IsEmpty)
		{
			if (!Class76.smethod_169(this).Fragment.Contains(buMultiTextBox_0.Selection.Start))
			{
				if (buMultiTextBox_0.Selection.Start.iLine != Class76.smethod_169(this).Fragment.End.iLine || buMultiTextBox_0.Selection.Start.iChar != Class76.smethod_169(this).Fragment.End.iChar + 1)
				{
					flag = true;
				}
				else if (!Regex.IsMatch(buMultiTextBox_0.Selection.CharBeforeStart.ToString(), Class76.smethod_169(this).SearchPattern))
				{
					flag = true;
				}
			}
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			Class76.smethod_169(this).Close();
		}
	}

	private void method_8(object sender, KeyEventArgs e)
	{
		buMultiTextBox buMultiTextBox2 = sender as buMultiTextBox;
		if (Class76.smethod_169(this).Visible)
		{
			Keys keyCode = e.KeyCode;
			Keys modifiers = e.Modifiers;
			if (Class76.smethod_705(modifiers, keyCode, this))
			{
				e.Handled = true;
			}
		}
		if (Class76.smethod_169(this).Visible)
		{
			return;
		}
		if (!buMultiTextBox2.HotkeysMapping.ContainsKey(e.KeyData) || buMultiTextBox2.HotkeysMapping[e.KeyData] != FCTBAction.AutocompleteMenu)
		{
			if (e.KeyCode == Keys.Escape && timer_0.Enabled)
			{
				timer_0.Stop();
			}
		}
		else
		{
			Class76.smethod_690(this);
			e.Handled = true;
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Class76.smethod_148(this);
		int num = Class76.smethod_86(this);
		int val = base.VerticalScroll.Value / num - 1;
		int val2 = (base.VerticalScroll.Value + base.ClientSize.Height) / num + 1;
		val = Math.Max(val, 0);
		val2 = Math.Min(val2, list_0.Count);
		int num2 = 0;
		int num3 = 18;
		for (int i = val; i < val2; i++)
		{
			num2 = i * num - base.VerticalScroll.Value;
			AutocompleteItem autocompleteItem = list_0[i];
			if (autocompleteItem.BackColor != Color.Transparent)
			{
				using SolidBrush brush = new SolidBrush(autocompleteItem.BackColor);
				e.Graphics.FillRectangle(brush, 1, num2, base.ClientSize.Width - 1 - 1, num - 1);
			}
			if (ImageList != null && list_0[i].ImageIndex >= 0)
			{
				e.Graphics.DrawImage(ImageList.Images[autocompleteItem.ImageIndex], 1, num2);
			}
			if (i == FocussedItemIndex)
			{
				using LinearGradientBrush brush2 = new LinearGradientBrush(new Point(0, num2 - 3), new Point(0, num2 + num), Color.Transparent, SelectedColor);
				using Pen pen = new Pen(SelectedColor);
				e.Graphics.FillRectangle(brush2, num3, num2, base.ClientSize.Width - 1 - num3, num - 1);
				e.Graphics.DrawRectangle(pen, num3, num2, base.ClientSize.Width - 1 - num3, num - 1);
			}
			if (i == int_1)
			{
				using Pen pen2 = new Pen(HoveredColor);
				e.Graphics.DrawRectangle(pen2, num3, num2, base.ClientSize.Width - 1 - num3, num - 1);
			}
			using SolidBrush brush3 = new SolidBrush((!(autocompleteItem.ForeColor != Color.Transparent)) ? ForeColor : autocompleteItem.ForeColor);
			e.Graphics.DrawString(autocompleteItem.ToString(), Font, brush3, num3, num2);
		}
	}

	protected override void OnScroll(ScrollEventArgs se)
	{
		base.OnScroll(se);
		Invalidate();
	}

	protected override void OnMouseClick(MouseEventArgs e)
	{
		base.OnMouseClick(e);
		if (e.Button == MouseButtons.Left)
		{
			FocussedItemIndex = Class76.smethod_505(this, e.Location);
			Class76.smethod_114(this);
			Invalidate();
		}
	}

	protected override void OnMouseDoubleClick(MouseEventArgs e)
	{
		base.OnMouseDoubleClick(e);
		FocussedItemIndex = Class76.smethod_505(this, e.Location);
		Invalidate();
		vmethod_0();
	}

	internal virtual void vmethod_0()
	{
		if (FocussedItemIndex < 0 || FocussedItemIndex >= list_0.Count)
		{
			return;
		}
		buMultiTextBox_0.TextSource.Manager.BeginAutoUndoCommands();
		try
		{
			AutocompleteItem focussedItem = FocussedItem;
			SelectingEventArgs e = new SelectingEventArgs
			{
				Item = focussedItem,
				SelectedIndex = FocussedItemIndex
			};
			Class76.smethod_146(Class76.smethod_169(this), e);
			if (!e.Cancel)
			{
				if (!e.Handled)
				{
					Range fragment = Class76.smethod_169(this).Fragment;
					Class76.smethod_519(fragment, focussedItem, this);
				}
				Class76.smethod_169(this).Close();
				SelectedEventArgs e2 = new SelectedEventArgs
				{
					Item = focussedItem,
					Tb = Class76.smethod_169(this).Fragment.tb
				};
				focussedItem.OnSelected(Class76.smethod_169(this), e2);
				Class76.smethod_169(this).OnSelected(e2);
			}
			else
			{
				FocussedItemIndex = e.SelectedIndex;
				Invalidate();
			}
		}
		finally
		{
			buMultiTextBox_0.TextSource.Manager.EndAutoUndoCommands();
		}
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		Class76.smethod_705(Keys.None, keyData, this);
		return base.ProcessCmdKey(ref msg, keyData);
	}

	public void SelectNext(int shift)
	{
		FocussedItemIndex = Math.Max(0, Math.Min(FocussedItemIndex + shift, list_0.Count - 1));
		Class76.smethod_114(this);
		Invalidate();
	}

	public void SetAutocompleteItems(ICollection<string> items)
	{
		List<AutocompleteItem> list = new List<AutocompleteItem>(items.Count);
		foreach (string item in items)
		{
			list.Add(new AutocompleteItem(item));
		}
		SetAutocompleteItems(list);
	}

	public void SetAutocompleteItems(IEnumerable<AutocompleteItem> items)
	{
		ienumerable_0 = items;
	}

	[CompilerGenerated]
	private void method_9(object sender, EventArgs e)
	{
		Class76.smethod_170(this);
	}

	[CompilerGenerated]
	private void method_10(object sender, EventArgs e)
	{
		Class76.smethod_170(this);
	}

	[CompilerGenerated]
	private void method_11(object sender, FormClosingEventArgs e)
	{
		Class76.smethod_170(this);
	}

	[CompilerGenerated]
	private void method_12(object sender, EventArgs e)
	{
		Class76.smethod_170(this);
	}

	[CompilerGenerated]
	private void method_13(object sender, EventArgs e)
	{
		if (Class76.smethod_169(this) != null && !Class76.smethod_169(this).IsDisposed && !Class76.smethod_169(this).Focused)
		{
			Class76.smethod_170(this);
		}
	}

	[CompilerGenerated]
	private void method_14(object sender, ScrollEventArgs e)
	{
		Class76.smethod_170(this);
	}

	[CompilerGenerated]
	private void AutocompleteListView_VisibleChanged(object sender, EventArgs e)
	{
		if (base.Visible)
		{
			Class76.smethod_114(this);
		}
	}
}
