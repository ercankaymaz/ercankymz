using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

public class EdgeDataSurrogate : Surrogate<Solid.EdgeData>
{
	public int BeginVertex;

	public int EndVertex;

	public int Type;

	public int NextFace;

	public int NextEdge;

	public int PreviousFace;

	public int PreviousEdge;

	public float Angle;

	public EdgeDataSurrogate(Solid.EdgeData edge)
		: base(edge)
	{
	}

	protected override Solid.EdgeData ConvertToObject()
	{
		return new Solid.EdgeData(BeginVertex, EndVertex, Type, PreviousEdge, NextEdge, PreviousFace, NextFace, Angle);
	}

	protected override void CopyDataToObject(Solid.EdgeData obj)
	{
	}

	protected override void CopyDataFromObject(Solid.EdgeData edge)
	{
		BeginVertex = edge.BeginVertex;
		EndVertex = edge.EndVertex;
		Type = edge.Type;
		NextFace = edge.NextFace;
		PreviousFace = edge.PreviousFace;
		NextEdge = edge.NextEdge;
		PreviousEdge = edge.PreviousEdge;
		Angle = edge.Angle;
	}

	public static implicit operator Solid.EdgeData(EdgeDataSurrogate surrogate)
	{
		return surrogate.ConvertToObject();
	}

	public static implicit operator EdgeDataSurrogate(Solid.EdgeData source)
	{
		return source._0023_003Dz_0024xHo97pGU7zE();
	}
}
