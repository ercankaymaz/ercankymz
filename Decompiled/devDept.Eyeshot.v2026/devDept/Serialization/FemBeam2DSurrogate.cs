using devDept.Eyeshot.Fem;
using devDept.Geometry;

namespace devDept.Serialization;

public class FemBeam2DSurrogate : FemElement2DSurrogate
{
	public double Temperature;

	public bool HingeStart;

	public bool HingeEnd;

	public int SubdivisionNumber;

	public Point3D[] BeamVerts;

	public FemBeam2DSurrogate(Beam2D beam2D)
		: base(beam2D)
	{
	}

	protected override Element ConvertToObject()
	{
		Beam2D beam2D = new Beam2D(Connection[0], Connection[1], Material as MaterialBeam);
		CopyDataToObject(beam2D);
		return beam2D;
	}

	protected override void CopyDataToObject(Element element)
	{
		Beam2D obj = element as Beam2D;
		obj.Temperature = Temperature;
		obj.HingeStart = HingeStart;
		obj.HingeEnd = HingeEnd;
		obj.SubdivisionNumber = SubdivisionNumber;
		obj.beamVerts = BeamVerts;
		base.CopyDataToObject(element);
	}

	protected override void CopyDataFromObject(Element element)
	{
		Beam2D beam2D = element as Beam2D;
		Temperature = beam2D.Temperature;
		HingeStart = beam2D.HingeStart;
		HingeEnd = beam2D.HingeEnd;
		SubdivisionNumber = beam2D.SubdivisionNumber;
		BeamVerts = beam2D.beamVerts;
		base.CopyDataFromObject(element);
	}
}
