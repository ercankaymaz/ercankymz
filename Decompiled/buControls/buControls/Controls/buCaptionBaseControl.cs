using System.ComponentModel;

namespace buControls.Controls;

public abstract class buCaptionBaseControl : buControl
{
	private buControlCaption buControlCaption_0 = new buControlCaption();

	private buControlUnit buControlUnit_0 = new buControlUnit();

	private buControlCheckTick buControlCheckTick_0 = new buControlCheckTick();

	private buControlFocus buControlFocus_0 = new buControlFocus();

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlCaption Caption
	{
		get
		{
			return buControlCaption_0;
		}
		set
		{
			buControlCaption_0 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
			Invalidate();
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlUnit Unit
	{
		get
		{
			return buControlUnit_0;
		}
		set
		{
			buControlUnit_0 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlCheckTick CheckTick
	{
		get
		{
			return buControlCheckTick_0;
		}
		set
		{
			buControlCheckTick_0 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlFocus FocusControl
	{
		get
		{
			return buControlFocus_0;
		}
		set
		{
			buControlFocus_0 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}
}
