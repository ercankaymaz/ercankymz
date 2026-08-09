using devDept.Eyeshot.Fem;

namespace devDept.Serialization;

public class FemHexa8Surrogate : FemElement3DSurrogate
{
	public FemHexa8Surrogate(Hexa8 hexa8)
		: base(hexa8)
	{
	}

	protected override Element ConvertToObject()
	{
		Hexa8 hexa = new Hexa8(Connection, Material);
		CopyDataToObject(hexa);
		return hexa;
	}
}
