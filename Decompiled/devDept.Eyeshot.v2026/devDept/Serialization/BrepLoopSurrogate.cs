using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

public class BrepLoopSurrogate : Surrogate<Brep.Loop>
{
	public Brep.OrientedEdge[] Segments;

	public bool Sense;

	public BrepLoopSurrogate(Brep.Loop loop)
		: base(loop)
	{
	}

	protected override Brep.Loop ConvertToObject()
	{
		Brep.Loop loop = new Brep.Loop(Segments, Sense);
		CopyDataToObject(loop);
		return loop;
	}

	protected override void CopyDataToObject(Brep.Loop loop)
	{
		loop.Sense = Sense;
	}

	protected override void CopyDataFromObject(Brep.Loop loop)
	{
		Segments = loop.Segments;
		Sense = loop.Sense;
	}

	public static implicit operator Brep.Loop(BrepLoopSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator BrepLoopSurrogate(Brep.Loop source)
	{
		return source?.ConvertToSurrogate();
	}
}
