using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

public class CycleSurrogate : Surrogate<Solid.Cycle>
{
	public int FirstEdge;

	public int NextContour;

	public CycleSurrogate(Solid.Cycle cycle)
		: base(cycle)
	{
	}

	protected override Solid.Cycle ConvertToObject()
	{
		return new Solid.Cycle(FirstEdge, NextContour);
	}

	protected override void CopyDataToObject(Solid.Cycle obj)
	{
	}

	protected override void CopyDataFromObject(Solid.Cycle cycle)
	{
		FirstEdge = cycle.FirstEdge;
		NextContour = cycle.NextContour;
	}

	public static implicit operator Solid.Cycle(CycleSurrogate surrogate)
	{
		return surrogate.ConvertToObject();
	}

	public static implicit operator CycleSurrogate(Solid.Cycle source)
	{
		return source._0023_003Dz_0024xHo97pGU7zE();
	}
}
