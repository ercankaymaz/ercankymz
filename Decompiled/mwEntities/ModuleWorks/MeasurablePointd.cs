namespace ModuleWorks;

public class MeasurablePointd : Vectord
{
	public Unit Unit { get; set; }

	public MeasurablePointd(Unit unit, Vectord vector)
	{
		Unit = unit;
		for (int i = 0; i < 3; i++)
		{
			base[i] = vector[i];
		}
	}

	public MeasurablePointd(Unit unit)
	{
		Unit = unit;
	}
}
