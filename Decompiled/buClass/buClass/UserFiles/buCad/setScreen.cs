using System.Reflection;

namespace buClass.UserFiles.buCad;

public class setScreen : buSerilization
{
	public bool ShowCoordinateSystemIcon = true;

	public bool ShowOrigineIcon = true;

	public bool ShowOrigineCaption = true;

	public int OrigineSize = 5;

	public OriginIconType OrigineIcon = OriginIconType.Ball;

	public bool ShowCubeIcon = true;

	public bool ShowToolbar = true;

	public setScreen()
	{
	}

	public setScreen(setScreen data)
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
