using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class IdSurrogate : Surrogate<Id>
{
	public long value;

	public long second;

	public IdSurrogate(Id id)
		: base(id)
	{
	}

	protected override Id ConvertToObject()
	{
		return new Id(value, second);
	}

	protected override void CopyDataToObject(Id obj)
	{
	}

	protected override void CopyDataFromObject(Id interval)
	{
		value = interval.value;
		second = interval.second;
	}

	public static implicit operator Id(IdSurrogate surrogate)
	{
		return surrogate.ConvertToObject();
	}

	public static implicit operator IdSurrogate(Id source)
	{
		return source._0023_003Dz_0024xHo97pGU7zE();
	}
}
