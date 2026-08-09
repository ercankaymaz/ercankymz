using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

public class BrepOrientedEdgeSurrogate : Surrogate<Brep.OrientedEdge>
{
	public bool Sense;

	public int CurveIndex;

	public BrepOrientedEdgeSurrogate(Brep.OrientedEdge orientedEdge)
		: base(orientedEdge)
	{
	}

	protected override Brep.OrientedEdge ConvertToObject()
	{
		Brep.OrientedEdge orientedEdge = new Brep.OrientedEdge(CurveIndex, Sense);
		CopyDataToObject(orientedEdge);
		return orientedEdge;
	}

	protected override void CopyDataToObject(Brep.OrientedEdge orientedEdge)
	{
		orientedEdge.Sense = Sense;
	}

	protected override void CopyDataFromObject(Brep.OrientedEdge orientedEdge)
	{
		CurveIndex = orientedEdge.CurveIndex;
		Sense = orientedEdge.Sense;
	}

	public static implicit operator Brep.OrientedEdge(BrepOrientedEdgeSurrogate surrogate)
	{
		return surrogate.ConvertToObject();
	}

	public static implicit operator BrepOrientedEdgeSurrogate(Brep.OrientedEdge source)
	{
		return source.ConvertToSurrogate();
	}
}
