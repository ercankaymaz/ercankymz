namespace ModuleWorks;

public class MeasurableAxis<T>
{
	public Axis Axis { get; set; }

	public T Value { get; set; }

	public Unit Unit { get; private set; }

	public MeasurableAxis(Axis axis, Unit unit)
	{
		Axis = axis;
		Unit = unit;
		Value = default(T);
	}

	public MeasurableAxis(Axis axis, T value, Unit unit)
	{
		Axis = axis;
		Value = value;
		Unit = unit;
	}
}
