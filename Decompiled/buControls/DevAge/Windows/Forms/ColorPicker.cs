using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns27;

namespace DevAge.Windows.Forms;

[ToolboxItem(false)]
public class ColorPicker : EditableControlBase
{
	internal Button button_0;

	internal Panel panel_0;

	internal Label label_0;

	private Container container_2 = null;

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	public virtual Color SelectedColor
	{
		get
		{
			return panel_0.BackColor;
		}
		set
		{
			panel_0.BackColor = value;
		}
	}

	public new Color ForeColor
	{
		get
		{
			return label_0.ForeColor;
		}
		set
		{
			label_0.ForeColor = value;
		}
	}

	public event EventHandler SelectedColorChanged
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

	public ColorPicker()
	{
		Class76.smethod_780(this);
		SelectedColor = Color.Black;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && container_2 != null)
		{
			container_2.Dispose();
		}
		base.Dispose(disposing);
	}

	internal void method_0(object sender, EventArgs e)
	{
		label_0.Text = panel_0.BackColor.Name;
		if (eventHandler_0 != null)
		{
			eventHandler_0(this, e);
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		try
		{
			using ColorDialog colorDialog = new ColorDialog();
			colorDialog.Color = SelectedColor;
			if (colorDialog.ShowDialog(this) == DialogResult.OK)
			{
				SelectedColor = colorDialog.Color;
			}
		}
		catch (Exception)
		{
		}
	}
}
