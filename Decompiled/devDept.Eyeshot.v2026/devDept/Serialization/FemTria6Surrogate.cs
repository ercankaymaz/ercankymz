using devDept.Eyeshot.Fem;

namespace devDept.Serialization;

public class FemTria6Surrogate : FemElement2DSurrogate
{
	public FemTria6Surrogate(Tria6 tria6)
		: base(tria6)
	{
	}

	protected override Element ConvertToObject()
	{
		Tria6 tria = new Tria6(Connection, Material);
		CopyDataToObject(tria);
		return tria;
	}
}
