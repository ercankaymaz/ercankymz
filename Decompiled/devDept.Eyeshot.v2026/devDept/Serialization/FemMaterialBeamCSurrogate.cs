using devDept.Eyeshot;
using devDept.Eyeshot.Fem;

namespace devDept.Serialization;

public class FemMaterialBeamCSurrogate : FemMaterialBeamISurrogate
{
	public FemMaterialBeamCSurrogate(MaterialBeamC matBeamC)
		: base(matBeamC)
	{
	}

	protected override Material ConvertToObject()
	{
		MaterialBeamC materialBeamC = new MaterialBeamC(Name, Diffuse, Young, Poisson, YieldStrength, Density, CoeffOfThermalExp, Width, Height, Flange, Web);
		CopyDataToObject(materialBeamC);
		return materialBeamC;
	}
}
