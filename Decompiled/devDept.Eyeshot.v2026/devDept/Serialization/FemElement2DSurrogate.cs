using devDept.Eyeshot.Fem;

namespace devDept.Serialization;

public abstract class FemElement2DSurrogate : FemElementSurrogate
{
	public Element2D.Edge[] Edges;

	public FemElement2DSurrogate(Element2D element2D)
		: base(element2D)
	{
	}

	protected override void CopyDataToObject(Element element)
	{
		(element as Element2D).elEdges = Edges;
		base.CopyDataToObject(element);
	}

	protected override void CopyDataFromObject(Element element)
	{
		Element2D element2D = element as Element2D;
		Edges = element2D.Edges;
		base.CopyDataFromObject(element);
	}
}
