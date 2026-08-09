using devDept.Eyeshot;
using devDept.Eyeshot.Fem;

namespace devDept.Serialization;

public class FemMaterialBeamHollowCircleSurrogate : FemMaterialBeamCircleSurrogate
{
	public double InnerRadius;

	public FemMaterialBeamHollowCircleSurrogate(MaterialBeamHollowCircle matBeamHollowCircle)
		: base(matBeamHollowCircle)
	{
	}

	protected override Material ConvertToObject()
	{
		double thickness = Radius - InnerRadius;
		MaterialBeamHollowCircle materialBeamHollowCircle = new MaterialBeamHollowCircle(Name, Diffuse, Young, Poisson, YieldStrength, Density, CoeffOfThermalExp, Radius, thickness);
		CopyDataToObject(materialBeamHollowCircle);
		return materialBeamHollowCircle;
	}

	protected override void CopyDataFromObject(Material mat)
	{
		MaterialBeamHollowCircle materialBeamHollowCircle = mat as MaterialBeamHollowCircle;
		InnerRadius = materialBeamHollowCircle.InnerRadius;
		base.CopyDataFromObject(mat);
	}
}
