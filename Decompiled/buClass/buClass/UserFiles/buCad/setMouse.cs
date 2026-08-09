using System.Reflection;

namespace buClass.UserFiles.buCad;

public class setMouse : buSerilization
{
	public MouseKeyboardConfigration RotateConfigration = new MouseKeyboardConfigration(mouseButtons.Middle, modifierKeys.Ctrl);

	public MouseKeyboardConfigration PanConfigration = new MouseKeyboardConfigration(mouseButtons.Middle, modifierKeys.None);

	public MouseKeyboardConfigration ZoomConfigration = new MouseKeyboardConfigration(mouseButtons.Middle, modifierKeys.Shift);

	public OsnapProps Osnap = new OsnapProps();

	public bool ZoomWheelReverseDirection = false;

	public MouseCursorType MouseCursor = MouseCursorType.Arrow;

	public MouseCursorType MouseSelectionCursor = MouseCursorType.Arrow;

	public setMouse()
	{
	}

	public setMouse(setMouse data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
		FieldInfo[] fields = GetType().GetFields();
		if (fields != null)
		{
			for (int i = 0; i <= fields.Length - 1; i++)
			{
				string name = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}
}
