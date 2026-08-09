using System.Windows.Forms;

namespace DevAge.Windows.Forms;

public class ControlCursor
{
	private Cursor pCursor;

	private Cursor cursor_0;

	private Control control_0;

	public ControlCursor(Cursor pCursor)
	{
		this.pCursor = pCursor;
	}

	public void ApplyCursor(Control control)
	{
		if (control_0 == null)
		{
			control_0 = control;
			cursor_0 = control_0.Cursor;
			control_0.Cursor = pCursor;
		}
	}

	public void ResetCursor()
	{
		if (control_0 != null && control_0.Cursor == pCursor)
		{
			control_0.Cursor = cursor_0;
			control_0 = null;
		}
	}
}
