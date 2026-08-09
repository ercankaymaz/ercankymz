using devDept.Eyeshot;
using devDept.Eyeshot.Fem;

namespace devDept.Serialization;

public class FemMaterialBeamHollowRectSurrogate : FemMaterialBeamRectSurrogate
{
	public double Thickness;

	public FemMaterialBeamHollowRectSurrogate(MaterialBeamHollowRect matBeamHollowRect)
		: base(matBeamHollowRect)
	{
	}

	protected override Material ConvertToObject()
	{
		MaterialBeamHollowRect materialBeamHollowRect = new MaterialBeamHollowRect(Name, Diffuse, Young, Poisson, YieldStrength, Density, CoeffOfThermalExp, Width, Height, Thickness);
		CopyDataToObject(materialBeamHollowRect);
		return materialBeamHollowRect;
	}

	protected override void CopyDataFromObject(Material mat)
	{
		MaterialBeamHollowRect materialBeamHollowRect = mat as MaterialBeamHollowRect;
		Thickness = materialBeamHollowRect.Thickness;
		base.CopyDataFromObject(mat);
	}
}
