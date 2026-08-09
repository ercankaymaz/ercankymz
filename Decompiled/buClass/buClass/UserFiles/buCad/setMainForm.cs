using System.Reflection;

namespace buClass.UserFiles.buCad;

public class setMainForm : buSerilization
{
	public int panelExplorerWidth = 300;

	public DockVisible panelExplorerVisible = DockVisible.Visible;

	public int panelRightWidth = 250;

	public DockVisible panelRightVisible = DockVisible.Visible;

	public int panelBottomHeight = 250;

	public DockVisible panelBottomVisible = DockVisible.Visible;

	public int SplitterLeft1YPos = 323;

	public int SplitterLeft2YPos = 603;

	public bool ShowSecondStatusBar = false;

	public setMainForm()
	{
	}

	public setMainForm(setMainForm data)
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
