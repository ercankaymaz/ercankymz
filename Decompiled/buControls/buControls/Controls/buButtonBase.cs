using System.ComponentModel;

namespace buControls.Controls;

public abstract class buButtonBase : buControl
{
	private buControlDisplay buControlDisplay_1 = new buControlDisplay();

	private buControlDisplay buControlDisplay_2 = new buControlDisplay();

	private bool bool_0 = false;

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue("")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public bool ButtonCopy
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
			if (value)
			{
				ButtonDownDisplay = new buControlDisplay(base.Display);
				ButtonOverDisplay = new buControlDisplay(base.Display);
				value = false;
				bool_0 = false;
			}
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay ButtonOverDisplay
	{
		get
		{
			return buControlDisplay_1;
		}
		set
		{
			buControlDisplay_1 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay ButtonDownDisplay
	{
		get
		{
			return buControlDisplay_2;
		}
		set
		{
			buControlDisplay_2 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}
}
