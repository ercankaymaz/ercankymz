using System;
using System.Collections.Generic;

namespace ModuleWorks;

[Serializable]
public class SerializableMeshdData
{
	private const int VERTEXSIZE = 24;

	private const int TRIANGLESIZE = 36;

	public List<Triangled> Triangles { get; set; }

	public List<Vectord> Vertices { get; set; }

	public Unit Unit { get; set; }

	public SerializableMeshdData()
	{
		Triangles = new List<Triangled>();
		Vertices = new List<Vectord>();
	}

	public SerializableMeshdData(int triangleCount, int verticesCount)
	{
		Triangles = new List<Triangled>(triangleCount);
		Vertices = new List<Vectord>(verticesCount);
	}

	public byte[] Serialize()
	{
		byte[] array = new byte[12 + Triangles.Count * 36 + Vertices.Count * 24];
		int num = 0;
		byte[] bytes = BitConverter.GetBytes((int)Unit);
		Array.Copy(bytes, 0, array, num, bytes.Length);
		num += bytes.Length;
		bytes = BitConverter.GetBytes(Triangles.Count);
		Array.Copy(bytes, 0, array, num, bytes.Length);
		num += bytes.Length;
		bytes = BitConverter.GetBytes(Vertices.Count);
		Array.Copy(bytes, 0, array, num, bytes.Length);
		num += bytes.Length;
		foreach (Triangled triangle in Triangles)
		{
			num = triangle.Serialize(array, num);
		}
		foreach (Vectord vertex in Vertices)
		{
			num = vertex.Serialize(array, num);
		}
		return array;
	}

	public static SerializableMeshdData Deserialize(byte[] array, int index)
	{
		return Deserialize(array, ref index);
	}

	[CLSCompliant(false)]
	public static SerializableMeshdData Deserialize(byte[] array, ref int index)
	{
		byte[] array2 = new byte[12];
		Array.Copy(array, index, array2, 0, array2.Length);
		index += array2.Length;
		int num = BitConverter.ToInt32(array2, 4);
		int num2 = BitConverter.ToInt32(array2, 8);
		SerializableMeshdData serializableMeshdData = new SerializableMeshdData(num, num2);
		serializableMeshdData.Unit = (Unit)BitConverter.ToInt32(array2, 0);
		for (int i = 0; i < num; i++)
		{
			Triangled triangled = new Triangled();
			index = triangled.Load(array, index);
			serializableMeshdData.Triangles.Add(triangled);
		}
		for (int j = 0; j < num2; j++)
		{
			Vectord vectord = new Vectord();
			index = vectord.Load(array, index);
			serializableMeshdData.Vertices.Add(vectord);
		}
		return serializableMeshdData;
	}
}
