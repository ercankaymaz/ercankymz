using System.ComponentModel;
using System.Windows.Forms;
using ns38;

namespace buControls.Controls;

[TypeConverter(typeof(Class102))]
public class buControlTrack
{
	private buControlDisplay buControlDisplay_0 = new buControlDisplay();

	private buControlDisplay buControlDisplay_1 = new buControlDisplay();

	private buControlDisplay buControlDisplay_2 = new buControlDisplay();

	private int int_0 = 40;

	private bool bool_0 = true;

	private bool bool_1 = true;

	private string string_0 = "%";

	private bool bool_2 = true;

	private int int_1 = 10;

	public Control Parent;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay DrawerDisplay
	{
		get
		{
			return buControlDisplay_2;
		}
		set
		{
			buControlDisplay_2 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay DoneDisplay
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

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay ValueDisplay
	{
		get
		{
			return buControlDisplay_1;
		}
		set
		{
			buControlDisplay_1 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[DefaultValue(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public bool ValueShow
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

	[DefaultValue(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public bool ShowPersentage
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

	[DefaultValue(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public bool DrawerRectangle
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	[DefaultValue("%")]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public string PersentageChar
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

	[DefaultValue(40)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int ValueWidth
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

	[DefaultValue(10)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int DrawerWidth
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
			if (Parent != null)
			{
				Parent.Invalidate();
			}
		}
	}

	public buControlTrack()
	{
	}

	public buControlTrack(buControlTrack track)
	{
		DrawerDisplay = new buControlDisplay(track.DrawerDisplay);
		ValueDisplay = new buControlDisplay(track.ValueDisplay);
		DoneDisplay = new buControlDisplay(track.DoneDisplay);
		DrawerWidth = track.DrawerWidth;
		ValueShow = track.ValueShow;
		ShowPersentage = track.ShowPersentage;
		ValueWidth = track.ValueWidth;
	}

	public override string ToString()
	{
		return "Trackbar";
	}
}
