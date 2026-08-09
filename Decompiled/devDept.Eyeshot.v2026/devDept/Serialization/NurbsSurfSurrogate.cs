using devDept.Geometry;

namespace devDept.Serialization;

public class NurbsSurfSurrogate : AnalyticSurfSurrogate
{
	public int DegreeU;

	public double[] KnotVectorU;

	public int DegreeV;

	public double[] KnotVectorV;

	public ProtoArray<Point4D> ControlPoints;

	public NurbsSurfSurrogate(NurbsSurf nurbsSurf)
		: base(nurbsSurf)
	{
	}

	protected override AnalyticSurf ConvertToObject()
	{
		Point4D[,] ctrlPoints = ControlPoints.ToArray() as Point4D[,];
		NurbsSurf nurbsSurf = new NurbsSurf(DegreeU, KnotVectorU, DegreeV, KnotVectorV, ctrlPoints);
		CopyDataToObject(nurbsSurf);
		return nurbsSurf;
	}

	protected override void CopyDataFromObject(AnalyticSurf anSurf)
	{
		NurbsSurf nurbsSurf = (NurbsSurf)anSurf;
		DegreeU = nurbsSurf.DegreeU;
		KnotVectorU = nurbsSurf.KnotVectorU;
		DegreeV = nurbsSurf.DegreeV;
		KnotVectorV = nurbsSurf.KnotVectorV;
		ControlPoints = nurbsSurf.ControlPoints.ToProtoArray<Point4D>();
		base.CopyDataFromObject((AnalyticSurf)nurbsSurf);
	}
}
