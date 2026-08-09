using devDept.Eyeshot.Fem;

namespace devDept.Serialization;

public abstract class FemElement3DSurrogate : FemElementSurrogate
{
	public FemElement3DSurrogate(Element3D element3D)
		: base(element3D)
	{
	}
}
