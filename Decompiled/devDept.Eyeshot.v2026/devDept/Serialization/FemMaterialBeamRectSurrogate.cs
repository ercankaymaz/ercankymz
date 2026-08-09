using devDept.Eyeshot;
using devDept.Eyeshot.Fem;

namespace devDept.Serialization;

public class FemMaterialBeamRectSurrogate : FemMaterialBeamSurrogate
{
	public double Width;

	public double Height;

	public FemMaterialBeamRectSurrogate(MaterialBeamRect matBeamRect)
		: base(matBeamRect)
	{
	}

	protected override Material ConvertToObject()
	{
		MaterialBeamRect materialBeamRect = new MaterialBeamRect(Name, Diffuse, Young, Poisson, YieldStrength, Density, CoeffOfThermalExp, Width, Height);
		CopyDataToObject(materialBeamRect);
		return materialBeamRect;
	}

	protected override void CopyDataFromObject(Material mat)
	{
		MaterialBeamRect materialBeamRect = mat as MaterialBeamRect;
		Width = materialBeamRect.Width;
		Height = materialBeamRect.Height;
		base.CopyDataFromObject(mat);
	}
}
