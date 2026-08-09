using System.Reflection;

namespace buClass;

public class ImageProcessSize : buSerilization
{
	public int newWidth = 0;

	public int newHeight = 0;

	public int newLeft = 0;

	public int newTop = 0;

	public float Ratio = 1f;

	public ImageProcessSize()
	{
	}

	public ImageProcessSize(ImageProcessSize data)
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
