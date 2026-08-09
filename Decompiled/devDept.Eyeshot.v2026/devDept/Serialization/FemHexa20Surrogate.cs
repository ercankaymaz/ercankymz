using devDept.Eyeshot.Fem;

namespace devDept.Serialization;

public class FemHexa20Surrogate : FemElement3DSurrogate
{
	public FemHexa20Surrogate(Hexa20 hexa20)
		: base(hexa20)
	{
	}

	protected override Element ConvertToObject()
	{
		Hexa20 hexa = new Hexa20(Connection, Material);
		CopyDataToObject(hexa);
		return hexa;
	}
}
