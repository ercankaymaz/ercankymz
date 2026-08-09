using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns27;

namespace DevAge.Windows.Forms;

[ToolboxItem(false)]
[DefaultEvent("Click")]
public class ButtonMultiSelection : UserControl, IButtonControl
{
	internal Button button_0;

	internal DropDownButton dropDownButton_0;

	private Container container_0 = null;

	[CompilerGenerated]
	private SubButtonItemEventHandler subButtonItemEventHandler_0;

	private ContextMenu contextMenu_0 = new ContextMenu();

	private SubButtonItemCollection subButtonItemCollection_0 = new SubButtonItemCollection();

	private ButtonMultiSelectionMode buttonMultiSelectionMode_0 = ButtonMultiSelectionMode.InvokeFirstAction;

	[Browsable(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public override string Text
	{
		get
		{
			return button_0.Text;
		}
		set
		{
			button_0.Text = value;
			base.Text = value;
		}
	}

	[Browsable(false)]
	public new Color BackColor
	{
		get
		{
			return base.BackColor;
		}
		set
		{
			base.BackColor = value;
		}
	}

	[Browsable(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public override Color ForeColor
	{
		get
		{
			return base.ForeColor;
		}
		set
		{
			button_0.ForeColor = value;
			dropDownButton_0.ForeColor = value;
			base.ForeColor = value;
		}
	}

	[Browsable(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public override Font Font
	{
		get
		{
			return base.Font;
		}
		set
		{
			button_0.Font = value;
			dropDownButton_0.Font = value;
			base.Font = value;
		}
	}

	[Browsable(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public virtual ContentAlignment TextAlign
	{
		get
		{
			return button_0.TextAlign;
		}
		set
		{
			button_0.TextAlign = value;
		}
	}

	[Browsable(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public virtual Image Image
	{
		get
		{
			return button_0.Image;
		}
		set
		{
			button_0.Image = value;
		}
	}

	[Browsable(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public virtual ContentAlignment ImageAlign
	{
		get
		{
			return button_0.ImageAlign;
		}
		set
		{
			button_0.ImageAlign = value;
		}
	}

	[Browsable(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public virtual DialogResult DialogResult
	{
		get
		{
			return button_0.DialogResult;
		}
		set
		{
			button_0.DialogResult = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public SubButtonItemCollection ButtonsItems
	{
		get
		{
			return subButtonItemCollection_0;
		}
		set
		{
			subButtonItemCollection_0 = value;
		}
	}

	[DefaultValue(ButtonMultiSelectionMode.InvokeFirstAction)]
	public ButtonMultiSelectionMode Mode
	{
		get
		{
			return buttonMultiSelectionMode_0;
		}
		set
		{
			buttonMultiSelectionMode_0 = value;
		}
	}

	public new event SubButtonItemEventHandler Click
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

	public ButtonMultiSelection()
	{
		Class76.smethod_127(this);
		SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
		base.BackColor = Color.Transparent;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && container_0 != null)
		{
			container_0.Dispose();
		}
		base.Dispose(disposing);
	}

	public void PerformClick()
	{
		button_0.PerformClick();
	}

	public void NotifyDefault(bool value)
	{
		button_0.NotifyDefault(value);
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_0(SubButtonItemEventHandler subButtonItemEventHandler_1)
	{
		SubButtonItemEventHandler subButtonItemEventHandler = subButtonItemEventHandler_0;
		SubButtonItemEventHandler subButtonItemEventHandler2;
		do
		{
			subButtonItemEventHandler2 = subButtonItemEventHandler;
			SubButtonItemEventHandler value = (SubButtonItemEventHandler)Delegate.Combine(subButtonItemEventHandler2, subButtonItemEventHandler_1);
			subButtonItemEventHandler = Interlocked.CompareExchange(ref subButtonItemEventHandler_0, value, subButtonItemEventHandler2);
		}
		while ((object)subButtonItemEventHandler != subButtonItemEventHandler2);
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_1(SubButtonItemEventHandler subButtonItemEventHandler_1)
	{
		SubButtonItemEventHandler subButtonItemEventHandler = subButtonItemEventHandler_0;
		SubButtonItemEventHandler subButtonItemEventHandler2;
		do
		{
			subButtonItemEventHandler2 = subButtonItemEventHandler;
			SubButtonItemEventHandler value = (SubButtonItemEventHandler)Delegate.Remove(subButtonItemEventHandler2, subButtonItemEventHandler_1);
			subButtonItemEventHandler = Interlocked.CompareExchange(ref subButtonItemEventHandler_0, value, subButtonItemEventHandler2);
		}
		while ((object)subButtonItemEventHandler != subButtonItemEventHandler2);
	}

	protected virtual void OnClick(SubButtonItemEventArgs e)
	{
		if (e.ButtonItem != null)
		{
			e.ButtonItem.InvokeItemClick(EventArgs.Empty);
		}
		if (subButtonItemEventHandler_0 != null)
		{
			subButtonItemEventHandler_0(this, e);
		}
	}

	internal void method_2(SubButtonItemEventArgs subButtonItemEventArgs_0)
	{
		OnClick(subButtonItemEventArgs_0);
	}

	internal void method_3(object sender, EventArgs e)
	{
		if (buttonMultiSelectionMode_0 != ButtonMultiSelectionMode.InvokeFirstAction)
		{
			method_4(sender, e);
		}
		else if (subButtonItemCollection_0 == null || subButtonItemCollection_0.Count <= 0)
		{
			OnClick(new SubButtonItemEventArgs(null));
		}
		else
		{
			OnClick(new SubButtonItemEventArgs(subButtonItemCollection_0[0]));
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		if (subButtonItemCollection_0 == null || subButtonItemCollection_0.Count <= 0)
		{
			return;
		}
		contextMenu_0.MenuItems.Clear();
		foreach (SubButtonItem item in subButtonItemCollection_0)
		{
			item.Owner = this;
			contextMenu_0.MenuItems.Add(item.menuItem_0);
		}
		contextMenu_0.Show(button_0, new Point(0, button_0.Height));
	}
}
