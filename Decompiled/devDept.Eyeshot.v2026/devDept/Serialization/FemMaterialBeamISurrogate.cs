using devDept.Eyeshot;
using devDept.Eyeshot.Fem;

namespace devDept.Serialization;

public class FemMaterialBeamISurrogate : FemMaterialBeamRectSurrogate
{
	public double Flange;

	public double Web;

	public FemMaterialBeamISurrogate(MaterialBeamI matBeamI)
		: base(matBeamI)
	{
	}

	protected override Material ConvertToObject()
	{
		MaterialBeamI materialBeamI = new MaterialBeamI(Name, Diffuse, Young, Poisson, YieldStrength, Density, CoeffOfThermalExp, Width, Height, Flange, Web);
		CopyDataToObject(materialBeamI);
		return materialBeamI;
	}

	protected override void CopyDataFromObject(Material mat)
	{
		MaterialBeamI materialBeamI = mat as MaterialBeamI;
		Flange = materialBeamI.Flange;
		Web = materialBeamI.Web;
		base.CopyDataFromObject(mat);
	}
}
