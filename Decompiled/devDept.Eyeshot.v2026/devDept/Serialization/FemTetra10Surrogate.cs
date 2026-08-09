using devDept.Eyeshot.Fem;

namespace devDept.Serialization;

public class FemTetra10Surrogate : FemElement3DSurrogate
{
	public FemTetra10Surrogate(Tetra10 tetra10)
		: base(tetra10)
	{
	}

	protected override Element ConvertToObject()
	{
		Tetra10 tetra = new Tetra10(Connection, Material);
		CopyDataToObject(tetra);
		return tetra;
	}
}
