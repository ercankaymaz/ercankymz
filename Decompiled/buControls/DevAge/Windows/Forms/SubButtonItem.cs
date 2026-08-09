using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns27;

namespace DevAge.Windows.Forms;

public class SubButtonItem
{
	internal MenuItem menuItem_0;

	private object object_0;

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	private ButtonMultiSelection buttonMultiSelection_0;

	public object Tag
	{
		get
		{
			return object_0;
		}
		set
		{
			object_0 = value;
		}
	}

	public string Text
	{
		get
		{
			return menuItem_0.Text;
		}
		set
		{
			menuItem_0.Text = value;
		}
	}

	public ButtonMultiSelection Owner
	{
		get
		{
			return buttonMultiSelection_0;
		}
		set
		{
			buttonMultiSelection_0 = value;
		}
	}

	public event EventHandler Click
	{
		add
		{
			method_0(value);
		}
		remove
		{
			method_1(value);
		}
	}

	public SubButtonItem()
		: this("NewItem")
	{
	}

	public SubButtonItem(string p_Text)
		: this(p_Text, null)
	{
	}

	public SubButtonItem(string p_Text, EventHandler p_Event)
		: this(p_Text, p_Event, null)
	{
	}

	public SubButtonItem(string p_Text, EventHandler p_Event, Image p_Image)
	{
		if (p_Image != null)
		{
			menuItem_0 = new MenuItem();
		}
		else
		{
			menuItem_0 = new MenuItem();
		}
		Class76.smethod_822(this, p_Text, p_Event);
	}

	public SubButtonItem(string p_Text, EventHandler p_Event, ImageList p_ImageList, int p_ImageIndex)
	{
		if (p_ImageList != null)
		{
			menuItem_0 = new MenuItem();
		}
		else
		{
			menuItem_0 = new MenuItem();
		}
		Class76.smethod_822(this, p_Text, p_Event);
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_0(EventHandler eventHandler_1)
	{
		EventHandler eventHandler = eventHandler_0;
		EventHandler eventHandler2;
		do
		{
			eventHandler2 = eventHandler;
			EventHandler value = (EventHandler)Delegate.Combine(eventHandler2, eventHandler_1);
			eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value, eventHandler2);
		}
		while ((object)eventHandler != eventHandler2);
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_1(EventHandler eventHandler_1)
	{
		EventHandler eventHandler = eventHandler_0;
		EventHandler eventHandler2;
		do
		{
			eventHandler2 = eventHandler;
			EventHandler value = (EventHandler)Delegate.Remove(eventHandler2, eventHandler_1);
			eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value, eventHandler2);
		}
		while ((object)eventHandler != eventHandler2);
	}

	public void InvokeItemClick(EventArgs e)
	{
		if (eventHandler_0 != null)
		{
			eventHandler_0(this, e);
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		if (buttonMultiSelection_0 != null)
		{
			buttonMultiSelection_0.method_2(new SubButtonItemEventArgs(this));
		}
	}
}
