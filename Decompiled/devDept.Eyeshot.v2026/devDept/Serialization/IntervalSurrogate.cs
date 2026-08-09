using devDept.Geometry;

namespace devDept.Serialization;

public class IntervalSurrogate : Surrogate<Interval>
{
	public double t0;

	public double t1;

	public IntervalSurrogate(Interval interval)
		: base(interval)
	{
	}

	protected override Interval ConvertToObject()
	{
		return new Interval(t0, t1);
	}

	protected override void CopyDataToObject(Interval obj)
	{
	}

	protected override void CopyDataFromObject(Interval interval)
	{
		t0 = interval.t0;
		t1 = interval.t1;
	}

	public static implicit operator Interval(IntervalSurrogate surrogate)
	{
		return surrogate.ConvertToObject();
	}

	public static implicit operator IntervalSurrogate(Interval source)
	{
		return source._0023_003Dz_0024xHo97pGU7zE();
	}
}
