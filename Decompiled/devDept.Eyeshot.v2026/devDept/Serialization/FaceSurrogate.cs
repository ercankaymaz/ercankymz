using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

public class FaceSurrogate : Surrogate<Solid.Face>
{
	public int FirstContour;

	public int FaceLabel;

	public FaceSurrogate(Solid.Face face)
		: base(face)
	{
	}

	protected override Solid.Face ConvertToObject()
	{
		return new Solid.Face(FirstContour, FaceLabel);
	}

	protected override void CopyDataToObject(Solid.Face obj)
	{
	}

	protected override void CopyDataFromObject(Solid.Face face)
	{
		FirstContour = face.FirstContour;
		FaceLabel = face.FaceLabel;
	}

	public static implicit operator Solid.Face(FaceSurrogate surrogate)
	{
		return surrogate.ConvertToObject();
	}

	public static implicit operator FaceSurrogate(Solid.Face source)
	{
		return source._0023_003Dz_0024xHo97pGU7zE();
	}
}
