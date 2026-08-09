using devDept.Eyeshot.Fem;

namespace devDept.Serialization;

public class FemPenta6Surrogate : FemElement3DSurrogate
{
	public FemPenta6Surrogate(Penta6 penta6)
		: base(penta6)
	{
	}

	protected override Element ConvertToObject()
	{
		Penta6 penta = new Penta6(Connection, Material);
		CopyDataToObject(penta);
		return penta;
	}
}
