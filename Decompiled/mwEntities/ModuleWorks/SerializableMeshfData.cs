using System;
using System.Collections.Generic;
using System.IO;

namespace ModuleWorks;

[Serializable]
public class SerializableMeshfData
{
	private const int VERTEXSIZE = 12;

	private const int TRIANGLESIZE = 24;

	public List<Trianglef> Triangles { get; set; }

	public List<Vectorf> Vertices { get; set; }

	public Unit Unit { get; set; }

	public SerializableMeshfData()
	{
		Triangles = new List<Trianglef>();
		Vertices = new List<Vectorf>();
	}

	public SerializableMeshfData(int triangleCount, int verticesCount)
	{
		Triangles = new List<Trianglef>(triangleCount);
		Vertices = new List<Vectorf>(verticesCount);
	}

	public void Serialize(Stream stream)
	{
		using BinaryWriter writer = new BinaryWriter(stream);
		Serialize(writer);
	}

	public void Serialize(BinaryWriter writer)
	{
		byte[] bytes = BitConverter.GetBytes((int)Unit);
		writer.Write(bytes);
		bytes = BitConverter.GetBytes(Triangles.Count);
		writer.Write(bytes);
		bytes = BitConverter.GetBytes(Vertices.Count);
		writer.Write(bytes);
		foreach (Trianglef triangle in Triangles)
		{
			triangle.Serialize(writer);
		}
		foreach (Vectorf vertex in Vertices)
		{
			vertex.Serialize(writer);
		}
	}

	public byte[] Serialize()
	{
		byte[] array = new byte[12 + Triangles.Count * 24 + Vertices.Count * 12];
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
		foreach (Trianglef triangle in Triangles)
		{
			num = triangle.Serialize(array, num);
		}
		foreach (Vectorf vertex in Vertices)
		{
			num = vertex.Serialize(array, num);
		}
		return array;
	}

	public static SerializableMeshfData Deserialize(byte[] array, int index)
	{
		return Deserialize(array, ref index);
	}

	public static SerializableMeshfData Deserialize(Stream stream)
	{
		using BinaryReader reader = new BinaryReader(stream);
		return Deserialize(reader);
	}

	public static SerializableMeshfData Deserialize(BinaryReader reader)
	{
		int unit = reader.ReadInt32();
		int num = reader.ReadInt32();
		int num2 = reader.ReadInt32();
		SerializableMeshfData serializableMeshfData = new SerializableMeshfData(num, num2);
		serializableMeshfData.Unit = (Unit)unit;
		for (int i = 0; i < num; i++)
		{
			Trianglef trianglef = new Trianglef();
			trianglef.Load(reader);
			serializableMeshfData.Triangles.Add(trianglef);
		}
		for (int j = 0; j < num2; j++)
		{
			Vectorf vectorf = new Vectorf();
			vectorf.Load(reader);
			serializableMeshfData.Vertices.Add(vectorf);
		}
		return serializableMeshfData;
	}

	[CLSCompliant(false)]
	public static SerializableMeshfData Deserialize(byte[] array, ref int index)
	{
		byte[] array2 = new byte[12];
		Array.Copy(array, index, array2, 0, array2.Length);
		index += array2.Length;
		int num = BitConverter.ToInt32(array2, 4);
		int num2 = BitConverter.ToInt32(array2, 8);
		SerializableMeshfData serializableMeshfData = new SerializableMeshfData(num, num2);
		serializableMeshfData.Unit = (Unit)BitConverter.ToInt32(array2, 0);
		for (int i = 0; i < num; i++)
		{
			Trianglef trianglef = new Trianglef();
			index = trianglef.Load(array, index);
			serializableMeshfData.Triangles.Add(trianglef);
		}
		for (int j = 0; j < num2; j++)
		{
			Vectorf vectorf = new Vectorf();
			index = vectorf.Load(array, index);
			serializableMeshfData.Vertices.Add(vectorf);
		}
		return serializableMeshfData;
	}
}
