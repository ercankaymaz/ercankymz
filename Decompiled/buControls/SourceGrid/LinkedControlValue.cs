using System.Windows.Forms;

namespace SourceGrid;

public class LinkedControlValue
{
	private Control control;

	private Position position;

	private bool bool_0;

	private LinkedControlScrollMode linkedControlScrollMode_0;

	public Control Control => control;

	public Position Position
	{
		get
		{
			return position;
		}
		set
		{
			position = value;
		}
	}

	public bool UseCellBorder
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public LinkedControlScrollMode ScrollMode
	{
		get
		{
			return linkedControlScrollMode_0;
		}
		set
		{
			linkedControlScrollMode_0 = value;
		}
	}

	public LinkedControlValue(Control control, Position position)
	{
		this.control = control;
		this.position = position;
		bool_0 = true;
		linkedControlScrollMode_0 = LinkedControlScrollMode.BasedOnPosition;
	}

	public override string ToString()
	{
		return Position.ToString();
	}
}
