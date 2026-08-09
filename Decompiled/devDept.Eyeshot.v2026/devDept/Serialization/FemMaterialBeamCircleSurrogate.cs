using devDept.Eyeshot;
using devDept.Eyeshot.Fem;

namespace devDept.Serialization;

public class FemMaterialBeamCircleSurrogate : FemMaterialBeamSurrogate
{
	public double Radius;

	public FemMaterialBeamCircleSurrogate(MaterialBeamCircle matBeamCircle)
		: base(matBeamCircle)
	{
	}

	protected override Material ConvertToObject()
	{
		MaterialBeamCircle materialBeamCircle = new MaterialBeamCircle(Name, Diffuse, Young, Poisson, YieldStrength, Density, CoeffOfThermalExp, Radius);
		CopyDataToObject(materialBeamCircle);
		return materialBeamCircle;
	}

	protected override void CopyDataFromObject(Material mat)
	{
		MaterialBeamCircle materialBeamCircle = mat as MaterialBeamCircle;
		Radius = materialBeamCircle.Radius;
		base.CopyDataFromObject(mat);
	}
}
