using devDept.Eyeshot.Fem;

namespace devDept.Serialization;

public class FemEdgeSurrogate : Surrogate<Element2D.Edge>
{
	public byte[] Indices;

	public double NormalPressure;

	public double[] Pressure;

	public FemEdgeSurrogate(Element2D.Edge edge)
		: base(edge)
	{
	}

	protected override Element2D.Edge ConvertToObject()
	{
		Element2D.Edge edge = new Element2D.Edge(Indices);
		CopyDataToObject(edge);
		return edge;
	}

	protected override void CopyDataToObject(Element2D.Edge edge)
	{
		edge.NormalPressure = NormalPressure;
		edge.Pressure = Pressure;
	}

	protected override void CopyDataFromObject(Element2D.Edge edge)
	{
		Indices = edge.Indices;
		NormalPressure = edge.NormalPressure;
		Pressure = edge.Pressure;
	}

	public static implicit operator Element2D.Edge(FemEdgeSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator FemEdgeSurrogate(Element2D.Edge source)
	{
		return source?.ConvertToSurrogate();
	}
}
