using devDept.Eyeshot.Fem;

namespace devDept.Serialization;

public class FemTetra4Surrogate : FemElement3DSurrogate
{
	public FemTetra4Surrogate(Tetra4 tetra4)
		: base(tetra4)
	{
	}

	protected override Element ConvertToObject()
	{
		Tetra4 tetra = new Tetra4(Connection, Material);
		CopyDataToObject(tetra);
		return tetra;
	}
}
