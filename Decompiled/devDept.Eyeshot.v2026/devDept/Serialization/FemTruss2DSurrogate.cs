using devDept.Eyeshot.Fem;

namespace devDept.Serialization;

public class FemTruss2DSurrogate : FemElement2DSurrogate
{
	public double SecArea;

	public FemTruss2DSurrogate(Truss2D truss2D)
		: base(truss2D)
	{
	}

	protected override Element ConvertToObject()
	{
		Truss2D truss2D = new Truss2D(Connection[0], Connection[1], Material, SecArea);
		CopyDataToObject(truss2D);
		return truss2D;
	}

	protected override void CopyDataFromObject(Element element)
	{
		Truss2D truss2D = element as Truss2D;
		SecArea = truss2D.secArea;
		base.CopyDataFromObject(element);
	}
}
