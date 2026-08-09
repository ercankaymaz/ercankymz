using devDept.Eyeshot.Fem;

namespace devDept.Serialization;

public class FemQuad4Surrogate : FemElement2DSurrogate
{
	public FemQuad4Surrogate(Quad4 quad4)
		: base(quad4)
	{
	}

	protected override Element ConvertToObject()
	{
		Quad4 quad = new Quad4(Connection, Material);
		CopyDataToObject(quad);
		return quad;
	}
}
