using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace devDept.Graphics;

public class VBOParamsTexture : VBOParamsBase
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float[] _0023_003DzDKDNqmqQ9KMWFXwp3_rrgN8_003D;

	public float[] TextureCoordinates
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzDKDNqmqQ9KMWFXwp3_rrgN8_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzDKDNqmqQ9KMWFXwp3_rrgN8_003D = value;
		}
	}

	public override float[] GetData(out int nVertices, out primitiveType topology)
	{
		int num = 0;
		nVertices = vertices.Length / numberOfCoordPerVertex;
		int num2 = ((normals != null) ? normals.Length : (nVertices * 3));
		if (TextureCoordinates.Length != nVertices && TextureCoordinates.Length != 2 * nVertices)
		{
			throw new GraphicsException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663900));
		}
		bool flag = TextureCoordinates.Length == nVertices;
		float[] array = new float[vertices.Length + num2 + TextureCoordinates.Length];
		if (normals != null)
		{
			if (flag)
			{
				int num3 = 0;
				int num4 = 0;
				while (num3 < vertices.Length)
				{
					array[num++] = vertices[num3];
					array[num++] = vertices[num3 + 1];
					array[num++] = vertices[num3 + 2];
					array[num++] = normals[num3];
					array[num++] = normals[num3 + 1];
					array[num++] = normals[num3 + 2];
					array[num++] = TextureCoordinates[num4];
					num3 += 3;
					num4++;
				}
			}
			else
			{
				int i = 0;
				int num5 = 0;
				for (; i < vertices.Length; i += 3)
				{
					array[num++] = vertices[i];
					array[num++] = vertices[i + 1];
					array[num++] = vertices[i + 2];
					array[num++] = normals[i];
					array[num++] = normals[i + 1];
					array[num++] = normals[i + 2];
					array[num++] = TextureCoordinates[num5++];
					array[num++] = TextureCoordinates[num5++];
				}
			}
		}
		else if (flag)
		{
			int num6 = 0;
			int num7 = 0;
			while (num6 < vertices.Length)
			{
				array[num++] = vertices[num6];
				array[num++] = vertices[num6 + 1];
				array[num++] = vertices[num6 + 2];
				num += 3;
				array[num++] = TextureCoordinates[num7];
				num6 += 3;
				num7++;
			}
		}
		else
		{
			int j = 0;
			int num8 = 0;
			for (; j < vertices.Length; j += 3)
			{
				array[num++] = vertices[j];
				array[num++] = vertices[j + 1];
				array[num++] = vertices[j + 2];
				num += 3;
				array[num++] = TextureCoordinates[num8++];
				array[num++] = TextureCoordinates[num8++];
			}
		}
		topology = _0023_003Dzry_09XE_003D();
		return array;
	}
}
