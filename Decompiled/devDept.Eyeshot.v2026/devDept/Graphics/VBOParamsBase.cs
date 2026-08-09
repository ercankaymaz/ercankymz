namespace devDept.Graphics;

public class VBOParamsBase
{
	public int[] indices;

	public float[] vertices;

	public float[] normals;

	public int numberOfCoordPerVertex = 3;

	public primitiveType primitiveMode;

	public virtual float[] GetData(out int nVertices, out primitiveType topology)
	{
		int num = 0;
		nVertices = vertices.Length / numberOfCoordPerVertex;
		int num2 = ((normals != null) ? normals.Length : 0);
		float[] array = new float[vertices.Length + num2];
		if (num2 > 0)
		{
			for (int i = 0; i < vertices.Length; i += 3)
			{
				array[num++] = vertices[i];
				array[num++] = vertices[i + 1];
				array[num++] = vertices[i + 2];
				array[num++] = normals[i];
				array[num++] = normals[i + 1];
				array[num++] = normals[i + 2];
			}
		}
		else
		{
			for (int j = 0; j < vertices.Length; j += 3)
			{
				array[num++] = vertices[j];
				array[num++] = vertices[j + 1];
				array[num++] = vertices[j + 2];
			}
		}
		topology = _0023_003Dzry_09XE_003D();
		return array;
	}

	private protected primitiveType _0023_003Dzry_09XE_003D()
	{
		primitiveType primitiveType2 = primitiveMode;
		if ((uint)(primitiveType2 - 1) <= 1u || primitiveType2 == primitiveType.TriangleList)
		{
			return primitiveMode;
		}
		throw new GraphicsException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663916) + primitiveMode.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996547));
	}
}
