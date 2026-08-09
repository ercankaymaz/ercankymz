using devDept.Eyeshot.Fem;

namespace devDept.Serialization;

public class FemQuad8Surrogate : FemElement2DSurrogate
{
	public FemQuad8Surrogate(Quad8 quad8)
		: base(quad8)
	{
	}

	protected override Element ConvertToObject()
	{
		Quad8 quad = new Quad8(Connection, Material);
		CopyDataToObject(quad);
		return quad;
	}
}
