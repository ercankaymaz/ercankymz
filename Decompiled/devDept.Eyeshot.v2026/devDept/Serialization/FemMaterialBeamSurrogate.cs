using devDept.Eyeshot;
using devDept.Eyeshot.Fem;

namespace devDept.Serialization;

public class FemMaterialBeamSurrogate : MaterialSurrogate
{
	public double SectionArea;

	public double Iw;

	public double Iv;

	public double TorsionK;

	public double MaxHalfSection;

	public FemMaterialBeamSurrogate(MaterialBeam matBeam)
		: base(matBeam)
	{
	}

	protected override Material ConvertToObject()
	{
		MaterialBeam materialBeam = new MaterialBeam(Name, Diffuse, Young, Poisson, YieldStrength, Density, CoeffOfThermalExp, SectionArea, Iw);
		CopyDataToObject(materialBeam);
		return materialBeam;
	}

	protected override void CopyDataToObject(Material mat)
	{
		MaterialBeam materialBeam = mat as MaterialBeam;
		materialBeam.Iv = Iv;
		materialBeam.TorsionK = TorsionK;
		materialBeam._0023_003DzTrLVFlqX2Sem = MaxHalfSection;
		base.CopyDataToObject((Material)materialBeam);
	}

	protected override void CopyDataFromObject(Material mat)
	{
		MaterialBeam materialBeam = mat as MaterialBeam;
		SectionArea = materialBeam.SectionArea;
		Iv = materialBeam.Iv;
		Iw = materialBeam.Iw;
		TorsionK = materialBeam.TorsionK;
		MaxHalfSection = materialBeam._0023_003DzTrLVFlqX2Sem;
		base.CopyDataFromObject(mat);
	}
}
