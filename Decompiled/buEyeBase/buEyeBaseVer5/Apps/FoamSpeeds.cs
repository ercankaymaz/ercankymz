using System;
using System.Reflection;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class FoamSpeeds : buSerilization5
{
	public double Cutting = 0.0;

	public double LeadIn = 0.0;

	public double LeadOut = 0.0;

	public double Connection = 0.0;

	public double CRotation = 0.0;

	public FoamSpeeds()
	{
	}

	public FoamSpeeds(double cutting, double leadin, double leadout, double connection, double crotation)
	{
		Cutting = cutting;
		LeadIn = leadin;
		LeadOut = leadout;
		Connection = connection;
		CRotation = crotation;
	}

	public FoamSpeeds(FoamSpeeds data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
		FieldInfo[] fields = GetType().GetFields();
		if (fields != null)
		{
			for (int i = 0; i <= fields.Length - 1; i++)
			{
				_ = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}

	public override string ToString()
	{
		return "Cutting: " + Cutting + " - LeadIn: " + LeadIn + " - LeadOut: " + LeadOut + " - Connection: " + Connection + " - CRotation: " + CRotation;
	}
}
