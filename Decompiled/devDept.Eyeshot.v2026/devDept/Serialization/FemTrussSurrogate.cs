using devDept.Eyeshot.Fem;

namespace devDept.Serialization;

public class FemTrussSurrogate : FemElement3DSurrogate
{
	public double SecArea;

	public double Temperature;

	public FemTrussSurrogate(Truss truss)
		: base(truss)
	{
	}

	protected override Element ConvertToObject()
	{
		Truss truss = new Truss(Connection[0], Connection[1], Material, SecArea);
		CopyDataToObject(truss);
		return truss;
	}

	protected override void CopyDataToObject(Element element)
	{
		(element as Truss).temperature = Temperature;
		base.CopyDataToObject(element);
	}

	protected override void CopyDataFromObject(Element element)
	{
		Truss truss = element as Truss;
		SecArea = truss.SectionArea;
		Temperature = truss.temperature;
		base.CopyDataFromObject(element);
	}
}
