using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns27;

namespace buMutliTextbox;

[Browsable(false)]
public class AutocompleteMenu : ToolStripDropDown, IDisposable
{
	internal AutocompleteListView autocompleteListView_0;

	public ToolStripControlHost host;

	[CompilerGenerated]
	private Range range_0;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	internal EventHandler<SelectingEventArgs> eventHandler_0;

	[CompilerGenerated]
	private EventHandler<SelectedEventArgs> eventHandler_1;

	[CompilerGenerated]
	internal EventHandler<CancelEventArgs> eventHandler_2;

	public Range Fragment
	{
		[CompilerGenerated]
		get
		{
			return range_0;
		}
		[CompilerGenerated]
		internal set
		{
			range_0 = value;
		}
	}

	public string SearchPattern
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public int MinFragmentLength
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public bool AllowTabKey
	{
		get
		{
			return autocompleteListView_0.method_0();
		}
		set
		{
			autocompleteListView_0.method_1(value);
		}
	}

	public int AppearInterval
	{
		get
		{
			return Class76.smethod_465(autocompleteListView_0);
		}
		set
		{
			Class76.smethod_11(value, autocompleteListView_0);
		}
	}

	public Size MaxTooltipSize
	{
		get
		{
			return autocompleteListView_0.method_4();
		}
		set
		{
			autocompleteListView_0.method_5(value);
		}
	}

	public bool AlwaysShowTooltip
	{
		get
		{
			return Class76.smethod_572(autocompleteListView_0);
		}
		set
		{
			Class76.smethod_794(autocompleteListView_0, value);
		}
	}

	[DefaultValue(typeof(Color), "Orange")]
	public Color SelectedColor
	{
		get
		{
			return autocompleteListView_0.SelectedColor;
		}
		set
		{
			autocompleteListView_0.SelectedColor = value;
		}
	}

	[DefaultValue(typeof(Color), "Red")]
	public Color HoveredColor
	{
		get
		{
			return autocompleteListView_0.HoveredColor;
		}
		set
		{
			autocompleteListView_0.HoveredColor = value;
		}
	}

	public new Font Font
	{
		get
		{
			return autocompleteListView_0.Font;
		}
		set
		{
			autocompleteListView_0.Font = value;
		}
	}

	public new AutocompleteListView Items => autocompleteListView_0;

	public new Size MinimumSize
	{
		get
		{
			return Items.MinimumSize;
		}
		set
		{
			Items.MinimumSize = value;
		}
	}

	public new ImageList ImageList
	{
		get
		{
			return Items.ImageList;
		}
		set
		{
			Items.ImageList = value;
		}
	}

	public int ToolTipDuration
	{
		get
		{
			return Items.method_2();
		}
		set
		{
			Items.method_3(value);
		}
	}

	public ToolTip ToolTip
	{
		get
		{
			return Items.toolTip_0;
		}
		set
		{
			Items.toolTip_0 = value;
		}
	}

	public event EventHandler<SelectingEventArgs> Selecting
	{
		[CompilerGenerated]
		add
		{
			EventHandler<SelectingEventArgs> eventHandler = eventHandler_0;
			EventHandler<SelectingEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<SelectingEventArgs> value2 = (EventHandler<SelectingEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<SelectingEventArgs> eventHandler = eventHandler_0;
			EventHandler<SelectingEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<SelectingEventArgs> value2 = (EventHandler<SelectingEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<SelectedEventArgs> Selected
	{
		[CompilerGenerated]
		add
		{
			EventHandler<SelectedEventArgs> eventHandler = eventHandler_1;
			EventHandler<SelectedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<SelectedEventArgs> value2 = (EventHandler<SelectedEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<SelectedEventArgs> eventHandler = eventHandler_1;
			EventHandler<SelectedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<SelectedEventArgs> value2 = (EventHandler<SelectedEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public new event EventHandler<CancelEventArgs> Opening
	{
		[CompilerGenerated]
		add
		{
			EventHandler<CancelEventArgs> eventHandler = eventHandler_2;
			EventHandler<CancelEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<CancelEventArgs> value2 = (EventHandler<CancelEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<CancelEventArgs> eventHandler = eventHandler_2;
			EventHandler<CancelEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<CancelEventArgs> value2 = (EventHandler<CancelEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public AutocompleteMenu(buMultiTextBox tb)
	{
		base.AutoClose = false;
		AutoSize = false;
		base.Margin = Padding.Empty;
		base.Padding = Padding.Empty;
		base.BackColor = Color.White;
		autocompleteListView_0 = new AutocompleteListView(tb);
		host = new ToolStripControlHost(autocompleteListView_0);
		host.Margin = new Padding(2, 2, 2, 2);
		host.Padding = Padding.Empty;
		host.AutoSize = false;
		host.AutoToolTip = false;
		Class76.smethod_294(this);
		base.Items.Add(host);
		autocompleteListView_0.Parent = this;
		SearchPattern = "[\\w\\.]";
		MinFragmentLength = 2;
	}

	public new void Close()
	{
		autocompleteListView_0.toolTip_0.Hide(autocompleteListView_0);
		base.Close();
	}

	public virtual void OnSelecting()
	{
		autocompleteListView_0.vmethod_0();
	}

	public void SelectNext(int shift)
	{
		autocompleteListView_0.SelectNext(shift);
	}

	public void OnSelected(SelectedEventArgs args)
	{
		if (eventHandler_1 != null)
		{
			eventHandler_1(this, args);
		}
	}

	public void Show(bool forced)
	{
		Class76.smethod_645(Items, forced);
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
		if (autocompleteListView_0 != null && !autocompleteListView_0.IsDisposed)
		{
			autocompleteListView_0.Dispose();
		}
	}
}
