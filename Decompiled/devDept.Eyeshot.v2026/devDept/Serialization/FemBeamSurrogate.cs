using devDept.Eyeshot.Fem;
using devDept.Geometry;

namespace devDept.Serialization;

public class FemBeamSurrogate : FemElement3DSurrogate
{
	public double Temperature;

	public bool HingeStart;

	public bool HingeEnd;

	public int SubdivisionNumber;

	public Point3D[] BeamVerts;

	public Vector3D V;

	public FemBeamSurrogate(Beam beam)
		: base(beam)
	{
	}

	protected override Element ConvertToObject()
	{
		Beam beam = new Beam(Connection[0], Connection[1], Material as MaterialBeam);
		CopyDataToObject(beam);
		return beam;
	}

	protected override void CopyDataToObject(Element element)
	{
		Beam obj = element as Beam;
		obj.Temperature = Temperature;
		obj.HingeStart = HingeStart;
		obj.HingeEnd = HingeEnd;
		obj.SubdivisionNumber = SubdivisionNumber;
		obj.beamVerts = BeamVerts;
		obj.v = V;
		base.CopyDataToObject(element);
	}

	protected override void CopyDataFromObject(Element element)
	{
		Beam beam = element as Beam;
		Temperature = beam.Temperature;
		HingeStart = beam.HingeStart;
		HingeEnd = beam.HingeEnd;
		SubdivisionNumber = beam.SubdivisionNumber;
		BeamVerts = beam.beamVerts;
		V = beam.v;
		base.CopyDataFromObject(element);
	}
}
