using devDept.Eyeshot;
using devDept.Eyeshot.Fem;

namespace devDept.Serialization;

public class FemMaterialBeamTSurrogate : FemMaterialBeamISurrogate
{
	public FemMaterialBeamTSurrogate(MaterialBeamT matBeamT)
		: base(matBeamT)
	{
	}

	protected override Material ConvertToObject()
	{
		MaterialBeamT materialBeamT = new MaterialBeamT(Name, Diffuse, Young, Poisson, YieldStrength, Density, CoeffOfThermalExp, Width, Height, Flange, Web);
		CopyDataToObject(materialBeamT);
		return materialBeamT;
	}
}
