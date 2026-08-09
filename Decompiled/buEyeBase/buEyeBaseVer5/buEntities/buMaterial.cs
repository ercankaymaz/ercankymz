using devDept.Eyeshot.Entities;

namespace buEyeBaseVer5.buEntities;

public class buMaterial : Brep
{
	public buMaterial(Brep another)
		: base(another)
	{
		if (another is buMaterial)
		{
		}
	}

	public override string ToString()
	{
		string text = "Brep - ";
		if (base.Edges != null)
		{
			text = text + "Edges : " + base.Edges.Length;
		}
		if (base.Faces != null)
		{
			text = text + " Faces : " + base.Faces.Length;
		}
		if (Vertices != null)
		{
			text = text + " Vertices : " + Vertices.Length;
		}
		return text;
	}
}
