namespace ModuleWorks;

public class MeasurablePointf : Vectorf
{
	public Unit Unit { get; set; }

	public MeasurablePointf(Unit unit, Vectorf vector)
	{
		Unit = unit;
		for (int i = 0; i < 3; i++)
		{
			base[i] = vector[i];
		}
	}

	public MeasurablePointf(Unit unit)
	{
		Unit = unit;
	}
}
