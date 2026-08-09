namespace devDept.Graphics;

public class VBOParams : VBOParamsBase
{
	public byte[] colors;

	public override float[] GetData(out int nVertices, out primitiveType topology)
	{
		int num = ((colors != null) ? colors.Length : 0);
		if (num == 0)
		{
			return base.GetData(out nVertices, out topology);
		}
		int num2 = 0;
		nVertices = vertices.Length / numberOfCoordPerVertex;
		int num3 = num / nVertices;
		if (num3 == 3)
		{
			num = nVertices * 4;
		}
		int num4 = ((normals != null) ? normals.Length : 0);
		float[] array = new float[vertices.Length + num4 + num];
		if (num4 > 0)
		{
			switch (num3)
			{
			case 1:
			{
				int num7 = 0;
				int num8 = 0;
				while (num7 < vertices.Length)
				{
					array[num2++] = vertices[num7];
					array[num2++] = vertices[num7 + 1];
					array[num2++] = vertices[num7 + 2];
					array[num2++] = normals[num7];
					array[num2++] = normals[num7 + 1];
					array[num2++] = normals[num7 + 2];
					array[num2++] = (float)(int)colors[num8] / 255f;
					num7 += 3;
					num8++;
				}
				break;
			}
			case 3:
			{
				for (int i = 0; i < vertices.Length; i += 3)
				{
					array[num2++] = vertices[i];
					array[num2++] = vertices[i + 1];
					array[num2++] = vertices[i + 2];
					array[num2++] = normals[i];
					array[num2++] = normals[i + 1];
					array[num2++] = normals[i + 2];
					array[num2++] = (float)(int)colors[i] / 255f;
					array[num2++] = (float)(int)colors[i + 1] / 255f;
					array[num2++] = (float)(int)colors[i + 2] / 255f;
					array[num2++] = 1f;
				}
				break;
			}
			case 4:
			{
				int num5 = 0;
				int num6 = 0;
				while (num5 < vertices.Length)
				{
					array[num2++] = vertices[num5];
					array[num2++] = vertices[num5 + 1];
					array[num2++] = vertices[num5 + 2];
					array[num2++] = normals[num5];
					array[num2++] = normals[num5 + 1];
					array[num2++] = normals[num5 + 2];
					array[num2++] = (float)(int)colors[num6] / 255f;
					array[num2++] = (float)(int)colors[num6 + 1] / 255f;
					array[num2++] = (float)(int)colors[num6 + 2] / 255f;
					array[num2++] = (float)(int)colors[num6 + 3] / 255f;
					num5 += 3;
					num6 += 4;
				}
				break;
			}
			default:
				throw new GraphicsException(num3 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663711));
			}
		}
		else
		{
			switch (num3)
			{
			case 1:
			{
				int num11 = 0;
				int num12 = 0;
				while (num11 < vertices.Length)
				{
					array[num2++] = vertices[num11];
					array[num2++] = vertices[num11 + 1];
					array[num2++] = vertices[num11 + 2];
					array[num2++] = (float)(int)colors[num12] / 255f;
					num11 += 3;
					num12++;
				}
				break;
			}
			case 3:
			{
				for (int j = 0; j < vertices.Length; j += 3)
				{
					array[num2++] = vertices[j];
					array[num2++] = vertices[j + 1];
					array[num2++] = vertices[j + 2];
					array[num2++] = (float)(int)colors[j] / 255f;
					array[num2++] = (float)(int)colors[j + 1] / 255f;
					array[num2++] = (float)(int)colors[j + 2] / 255f;
					array[num2++] = 1f;
				}
				break;
			}
			case 4:
			{
				int num9 = 0;
				int num10 = 0;
				while (num9 < vertices.Length)
				{
					array[num2++] = vertices[num9];
					array[num2++] = vertices[num9 + 1];
					array[num2++] = vertices[num9 + 2];
					array[num2++] = (float)(int)colors[num10] / 255f;
					array[num2++] = (float)(int)colors[num10 + 1] / 255f;
					array[num2++] = (float)(int)colors[num10 + 2] / 255f;
					array[num2++] = (float)(int)colors[num10 + 3] / 255f;
					num9 += 3;
					num10 += 4;
				}
				break;
			}
			default:
				throw new GraphicsException(num3 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663711));
			}
		}
		topology = _0023_003Dzry_09XE_003D();
		return array;
	}
}
