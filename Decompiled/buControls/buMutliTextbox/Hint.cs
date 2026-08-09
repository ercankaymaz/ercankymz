using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns27;

namespace buMutliTextbox;

public class Hint
{
	[CompilerGenerated]
	private Range range_0;

	[CompilerGenerated]
	private Control control_0;

	[CompilerGenerated]
	private DockStyle dockStyle_0;

	[CompilerGenerated]
	private UnfocusablePanel unfocusablePanel_0;

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private object object_0;

	[CompilerGenerated]
	private bool bool_0;

	public string Text
	{
		get
		{
			return HostPanel.Text;
		}
		set
		{
			HostPanel.Text = value;
		}
	}

	public Range Range
	{
		[CompilerGenerated]
		get
		{
			return range_0;
		}
		[CompilerGenerated]
		set
		{
			range_0 = value;
		}
	}

	public Color BackColor
	{
		get
		{
			return HostPanel.BackColor;
		}
		set
		{
			HostPanel.BackColor = value;
		}
	}

	public Color BackColor2
	{
		get
		{
			return HostPanel.BackColor2;
		}
		set
		{
			HostPanel.BackColor2 = value;
		}
	}

	public Color BorderColor
	{
		get
		{
			return HostPanel.BorderColor;
		}
		set
		{
			HostPanel.BorderColor = value;
		}
	}

	public Color ForeColor
	{
		get
		{
			return HostPanel.ForeColor;
		}
		set
		{
			HostPanel.ForeColor = value;
		}
	}

	public StringAlignment TextAlignment
	{
		get
		{
			return HostPanel.TextAlignment;
		}
		set
		{
			HostPanel.TextAlignment = value;
		}
	}

	public Font Font
	{
		get
		{
			return HostPanel.Font;
		}
		set
		{
			HostPanel.Font = value;
		}
	}

	public Control InnerControl
	{
		[CompilerGenerated]
		get
		{
			return control_0;
		}
		[CompilerGenerated]
		set
		{
			control_0 = value;
		}
	}

	public DockStyle Dock
	{
		[CompilerGenerated]
		get
		{
			return dockStyle_0;
		}
		[CompilerGenerated]
		set
		{
			dockStyle_0 = value;
		}
	}

	public int Width
	{
		get
		{
			return HostPanel.Width;
		}
		set
		{
			HostPanel.Width = value;
		}
	}

	public int Height
	{
		get
		{
			return HostPanel.Height;
		}
		set
		{
			HostPanel.Height = value;
		}
	}

	public UnfocusablePanel HostPanel
	{
		[CompilerGenerated]
		get
		{
			return unfocusablePanel_0;
		}
		[CompilerGenerated]
		private set
		{
			unfocusablePanel_0 = value;
		}
	}

	public object Tag
	{
		[CompilerGenerated]
		get
		{
			return object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}

	public Cursor Cursor
	{
		get
		{
			return HostPanel.Cursor;
		}
		set
		{
			HostPanel.Cursor = value;
		}
	}

	public bool Inline
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public event EventHandler Click
	{
		add
		{
			HostPanel.Click += value;
		}
		remove
		{
			HostPanel.Click -= value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal int method_0()
	{
		return int_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal void method_1(int int_1)
	{
		int_0 = int_1;
	}

	public virtual void DoVisible()
	{
		Range.tb.DoRangeVisible(Range, tryToCentre: true);
		Class76.smethod_542(Range.tb, HostPanel.Bounds);
		Range.tb.Invalidate();
	}

	private Hint(Range range_1, Control control_1, string string_0, bool bool_1, bool bool_2)
	{
		Range = range_1;
		Inline = bool_1;
		InnerControl = control_1;
		Init();
		Dock = (bool_2 ? DockStyle.Fill : DockStyle.None);
		Text = string_0;
	}

	public Hint(Range range, string text, bool inline, bool dock)
		: this(range, null, text, inline, dock)
	{
	}

	public Hint(Range range, string text)
		: this(range, null, text, bool_1: true, bool_2: true)
	{
	}

	public Hint(Range range, Control innerControl, bool inline, bool dock)
		: this(range, innerControl, null, inline, dock)
	{
	}

	public Hint(Range range, Control innerControl)
		: this(range, innerControl, null, bool_1: true, bool_2: true)
	{
	}

	protected virtual void Init()
	{
		HostPanel = new UnfocusablePanel();
		HostPanel.Click += OnClick;
		Cursor = Cursors.Default;
		BorderColor = Color.Silver;
		BackColor2 = Color.White;
		BackColor = ((InnerControl != null) ? SystemColors.Control : Color.Silver);
		ForeColor = Color.Black;
		TextAlignment = StringAlignment.Near;
		Font = ((Range.tb.Parent != null) ? Range.tb.Parent.Font : Range.tb.Font);
		if (InnerControl == null)
		{
			HostPanel.Height = Range.tb.CharHeight + 5;
			return;
		}
		HostPanel.Controls.Add(InnerControl);
		Size preferredSize = InnerControl.GetPreferredSize(InnerControl.Size);
		HostPanel.Width = preferredSize.Width + 2;
		HostPanel.Height = preferredSize.Height + 2;
		InnerControl.Dock = DockStyle.Fill;
		InnerControl.Visible = true;
		BackColor = SystemColors.Control;
	}

	protected virtual void OnClick(object sender, EventArgs e)
	{
		Range.tb.OnHintClick(this);
	}
}
