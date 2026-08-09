using devDept.Eyeshot.Fem;

namespace devDept.Serialization;

public class FemPenta15Surrogate : FemElement3DSurrogate
{
	public FemPenta15Surrogate(Penta15 penta15)
		: base(penta15)
	{
	}

	protected override Element ConvertToObject()
	{
		Penta15 penta = new Penta15(Connection, Material);
		CopyDataToObject(penta);
		return penta;
	}
}
