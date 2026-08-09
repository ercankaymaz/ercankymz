using devDept.Eyeshot.Fem;

namespace devDept.Serialization;

public class FemTria3Surrogate : FemElement2DSurrogate
{
	public FemTria3Surrogate(Tria3 tria3)
		: base(tria3)
	{
	}

	protected override Element ConvertToObject()
	{
		Tria3 tria = new Tria3(Connection, Material);
		CopyDataToObject(tria);
		return tria;
	}
}
