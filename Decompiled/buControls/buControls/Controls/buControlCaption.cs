using System.ComponentModel;
using System.Windows.Forms;
using ns39;

namespace buControls.Controls;

[TypeConverter(typeof(Class94))]
public class buControlCaption
{
	private bool bool_0 = false;

	private string string_0 = "";

	private int int_0 = 80;

	private double double_0 = 50.0;

	private bool bool_1 = false;

	private buControlDisplay buControlDisplay_0 = new buControlDisplay();

	public Control Parent;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay Display
	{
		get
		{
			return buControlDisplay_0;
		}
		set
		{
			buControlDisplay_0 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(false)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public bool OnTop
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(false)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public bool Visible
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue("")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public string Caption
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(80)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int Width
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(50)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public double HeightPersentage
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	public buControlCaption()
	{
	}

	public buControlCaption(buControlCaption caption)
	{
		Display = new buControlDisplay(caption.Display);
		OnTop = caption.OnTop;
		Visible = caption.Visible;
		Caption = caption.Caption;
		Width = caption.Width;
		HeightPersentage = caption.HeightPersentage;
	}

	public override string ToString()
	{
		return Caption + " Width : " + Width;
	}
}
