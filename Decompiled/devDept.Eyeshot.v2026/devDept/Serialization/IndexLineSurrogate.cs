using devDept.Geometry;

namespace devDept.Serialization;

public class IndexLineSurrogate : Surrogate<IndexLine>
{
	public int V1;

	public int V2;

	public IndexLineSurrogate(IndexLine indexLine)
		: base(indexLine)
	{
	}

	protected override IndexLine ConvertToObject()
	{
		return new IndexLine(V1, V2);
	}

	protected override void CopyDataToObject(IndexLine obj)
	{
	}

	protected override void CopyDataFromObject(IndexLine indexLine)
	{
		V1 = indexLine.V1;
		V2 = indexLine.V2;
	}

	public static implicit operator IndexLine(IndexLineSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator IndexLineSurrogate(IndexLine source)
	{
		if (!(source == null))
		{
			return source.ConvertToSurrogate();
		}
		return null;
	}
}
