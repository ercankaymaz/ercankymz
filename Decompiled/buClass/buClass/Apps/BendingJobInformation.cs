using System;
using System.Drawing;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class BendingJobInformation : buSerilization
{
	public int MaxBlockCount;

	public double BladeHeight;

	public int NumberOf;

	public int MirrorOf;

	public double TotalLength;

	public double CalculatedLength = 0.0;

	public string Customer = "";

	public string JobCode = "";

	public string Author = "";

	public string Explanation = "";

	public double BladeThickness;

	public double Pt = 0.0;

	public string FullFileName = "";

	public string FileNameWithoutExtension = "";

	public DateTime Date = default(DateTime);

	public Color Color = Color.Black;

	public BendingJobInformation()
	{
	}

	public BendingJobInformation(BendingJobInformation data)
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

	public override string ToString()
	{
		return "Tot Len: " + TotalLength + " ; Calc Len : " + CalculatedLength + " ; Number of : " + NumberOf + " ; Mirror of : " + MirrorOf + " ; Thickness : " + BladeThickness + " ; Height : " + BladeHeight;
	}
}
