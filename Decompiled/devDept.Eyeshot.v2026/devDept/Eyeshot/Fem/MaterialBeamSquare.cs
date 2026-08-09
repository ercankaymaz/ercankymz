using System;
using System.Drawing;
using System.Runtime.Serialization;
using devDept.Serialization;

namespace devDept.Eyeshot.Fem;

[Serializable]
public class MaterialBeamSquare : MaterialBeam
{
	public double Side;

	public MaterialBeamSquare(string name, Color diffuse, double young, double poisson, double yield, double density, double coeffOfThermExp, double sideLen)
		: base(name, diffuse, young, poisson, yield, density, coeffOfThermExp)
	{
		Side = sideLen;
		_0023_003Dz_0024Mg15tugQleDUdFhwtOr4qg_003D(sideLen);
	}

	public MaterialBeamSquare(Material mat, double sideLen)
		: base(mat.Name, mat.Diffuse, mat.Young, mat.Poisson, mat.YieldStrength, mat.Density, mat.CoeffOfThermalExp)
	{
		Side = sideLen;
		_0023_003Dz_0024Mg15tugQleDUdFhwtOr4qg_003D(sideLen);
	}

	protected MaterialBeamSquare(MaterialBeamSquare another)
		: base(another)
	{
		Side = another.Side;
	}

	[Obsolete("Use the constructor that accepts the name as first parameter instead.")]
	public MaterialBeamSquare(Color diffuse, double young, double poisson, double yield, double density, double coeffOfThermExp, double sideLen)
		: this(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984815), MaterialBeam._0023_003Dz5KguOoA_003D++), diffuse, young, poisson, yield, density, coeffOfThermExp, sideLen)
	{
	}

	protected MaterialBeamSquare(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		Side = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984918));
	}

	private void _0023_003Dz_0024Mg15tugQleDUdFhwtOr4qg_003D(double _0023_003DzhucLgaHx0bw6)
	{
		double num = _0023_003DzhucLgaHx0bw6 * _0023_003DzhucLgaHx0bw6;
		double num2 = num * num;
		base.SectionArea = num;
		double iv = (base.Iw = num2 / 12.0);
		base.Iv = iv;
		base.TorsionK = 9.0 / 64.0 * num2;
		base._0023_003DzTrLVFlqX2Sem = _0023_003DzhucLgaHx0bw6 / 2.0;
	}

	public override object Clone()
	{
		return new MaterialBeamSquare(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984918), Side);
	}

	public override MaterialSurrogate ConvertToSurrogate()
	{
		return new FemMaterialBeamSquareSurrogate(this);
	}
}
