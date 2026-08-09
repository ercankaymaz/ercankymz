using System.Reflection;

namespace buClass.UserFiles.buCad;

public class setCommunication : buSerilization
{
	public string IPNumber = "192.168.0.34";

	public string FtpUser = "CNCPC";

	public string FtpPassword = "2016";

	public int FtpPort = 21;

	public string FtpPath = "\\FtpFiles";

	public setCommunication()
	{
	}

	public setCommunication(setCommunication data)
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
