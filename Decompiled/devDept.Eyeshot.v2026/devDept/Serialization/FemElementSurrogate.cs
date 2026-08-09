using devDept.Eyeshot;
using devDept.Eyeshot.Fem;

namespace devDept.Serialization;

public class FemElementSurrogate : Surrogate<Element>
{
	public int[] Connection;

	public Material Material;

	public double[] DistLoad;

	public Element.Face[] Faces;

	public FemElementSurrogate(Element element)
		: base(element)
	{
	}

	protected override Element ConvertToObject()
	{
		WriteLog(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302670771), GetType()));
		return null;
	}

	protected override void CopyDataToObject(Element element)
	{
		element.Connection = Connection;
		element.Material = Material;
		element.distLoad = DistLoad;
		if (Faces != null)
		{
			element.elFaces = Faces;
		}
	}

	protected override void CopyDataFromObject(Element element)
	{
		Connection = element.Connection;
		Material = element.Material;
		DistLoad = element.distLoad;
		Faces = element.Faces;
	}

	public static implicit operator Element(FemElementSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator FemElementSurrogate(Element source)
	{
		return source?.ConvertToSurrogate();
	}
}
