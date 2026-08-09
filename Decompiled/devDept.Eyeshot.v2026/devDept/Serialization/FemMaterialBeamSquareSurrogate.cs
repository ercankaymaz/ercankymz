using devDept.Eyeshot;
using devDept.Eyeshot.Fem;

namespace devDept.Serialization;

public class FemMaterialBeamSquareSurrogate : FemMaterialBeamSurrogate
{
	public double Side;

	public FemMaterialBeamSquareSurrogate(MaterialBeamSquare matBeamSquare)
		: base(matBeamSquare)
	{
	}

	protected override Material ConvertToObject()
	{
		MaterialBeamSquare materialBeamSquare = new MaterialBeamSquare(Name, Diffuse, Young, Poisson, YieldStrength, Density, CoeffOfThermalExp, Side);
		CopyDataToObject(materialBeamSquare);
		return materialBeamSquare;
	}

	protected override void CopyDataFromObject(Material mat)
	{
		MaterialBeamSquare materialBeamSquare = mat as MaterialBeamSquare;
		Side = materialBeamSquare.Side;
		base.CopyDataFromObject(mat);
	}
}
