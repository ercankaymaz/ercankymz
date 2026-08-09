using devDept.Eyeshot.Fem;
using devDept.Geometry;

namespace devDept.Serialization;

public class FemFaceSurrogate : Surrogate<Element.Face>
{
	public byte[] Indices;

	public bool Visible;

	public Node Centroid;

	public Vector3D[] CornerNormals;

	public SmoothTriangle[] Triangles;

	public double NormalPressure;

	public double[] Pressure;

	public FemFaceSurrogate(Element.Face face)
		: base(face)
	{
	}

	protected override Element.Face ConvertToObject()
	{
		Element.Face face = new Element.Face(Indices);
		CopyDataToObject(face);
		return face;
	}

	protected override void CopyDataToObject(Element.Face face)
	{
		face.Visible = Visible;
		face.Centroid = Centroid;
		face.CornerNormals = CornerNormals;
		face.Triangles = Triangles;
		face.NormalPressure = NormalPressure;
		face.Pressure = Pressure;
	}

	protected override void CopyDataFromObject(Element.Face face)
	{
		Indices = face.Indices;
		Visible = face.Visible;
		Centroid = face.Centroid;
		CornerNormals = face.CornerNormals;
		Triangles = face.Triangles;
		NormalPressure = face.NormalPressure;
		Pressure = face.Pressure;
	}

	public static implicit operator Element.Face(FemFaceSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator FemFaceSurrogate(Element.Face source)
	{
		return source?.ConvertToSurrogate();
	}
}
