using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DevAge.Runtime.Serialization;

public static class Utilities
{
	public static object BinDeserialize(Stream p_Stream)
	{
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		return binaryFormatter.Deserialize(p_Stream);
	}

	public static void BinSerialize(Stream p_Stream, object p_Object)
	{
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(p_Stream, p_Object);
	}

	public static object BinDeserialize(string p_strFileName)
	{
		object result;
		using (FileStream fileStream = new FileStream(p_strFileName, FileMode.Open, FileAccess.Read))
		{
			result = BinDeserialize(fileStream);
			fileStream.Close();
		}
		return result;
	}

	public static void BinSerialize(string p_strFileName, object p_Object)
	{
		using FileStream fileStream = new FileStream(p_strFileName, FileMode.Create, FileAccess.Write);
		BinSerialize(fileStream, p_Object);
		fileStream.Close();
	}
}
