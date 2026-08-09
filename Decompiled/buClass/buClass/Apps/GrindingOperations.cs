using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class GrindingOperations : buSerilization
{
	public bool SawRampEnable = false;

	public double SawRampLenght = 50.0;

	public double SawRampHeight = 10.0;

	public CamZRampType SawRampType = CamZRampType.Circular;

	public double SawDevideLength = 0.5;

	public bool InsideOperationHoleEnable = false;

	public double IndiseOperationHoleDistance = 100.0;

	public int IndieOperationHoleTool = 0;

	public double VacuumDiameter = 50.0;

	public double VacuumHeight = 0.0;

	public double VacuumThickness = 10.0;

	public double PinDiameter = 50.0;

	public double PinHeight = 0.0;

	public double PinThickness = 10.0;

	public int VacuumLayerIndex = 4;

	public int PinLayerIndex = 4;

	public bool UseGeometryCalculation = false;

	public double GlassThickness = 0.0;

	public GrindingOperations()
	{
	}

	public GrindingOperations(GrindingOperations data)
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
