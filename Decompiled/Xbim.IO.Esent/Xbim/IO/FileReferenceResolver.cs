using System;
using System.Collections.Generic;
using System.IO;

namespace Xbim.IO;

internal class FileReferenceResolver
{
	internal static string EvaluateRelativePath(string mainDirPath, string absoluteFilePath)
	{
		string[] array = mainDirPath.Trim(new char[1] { Path.DirectorySeparatorChar }).Split(new char[1] { Path.DirectorySeparatorChar });
		string[] array2 = absoluteFilePath.Trim(new char[1] { Path.DirectorySeparatorChar }).Split(new char[1] { Path.DirectorySeparatorChar });
		int num = 0;
		for (int i = 0; i < Math.Min(array.Length, array2.Length) && array[i].ToLower().Equals(array2[i].ToLower()); i++)
		{
			num++;
		}
		if (num == 0)
		{
			return absoluteFilePath;
		}
		string text = string.Empty;
		for (int j = num; j < array.Length; j++)
		{
			if (j > num)
			{
				string text2 = text;
				char directorySeparatorChar = Path.DirectorySeparatorChar;
				text = text2 + directorySeparatorChar;
			}
			text += "..";
		}
		if (text.Length == 0)
		{
			text = ".";
		}
		for (int k = num; k < array2.Length; k++)
		{
			string text3 = text;
			char directorySeparatorChar = Path.DirectorySeparatorChar;
			text = text3 + directorySeparatorChar;
			text += array2[k];
		}
		return text;
	}

	internal static List<string> ResourceAlternatives(string ResFileName, string ProjFilePrev, string ProjFileCurr)
	{
		List<string> list = new List<string>();
		if (File.Exists(ResFileName))
		{
			list.Add(ResFileName);
		}
		try
		{
			string directoryName = Path.GetDirectoryName(ProjFileCurr);
			string directoryName2 = Path.GetDirectoryName(ProjFilePrev);
			if (directoryName == directoryName2)
			{
				return list;
			}
			string path = EvaluateRelativePath(directoryName2, ResFileName);
			string fullPath = Path.GetFullPath(Path.Combine(directoryName, path));
			if (fullPath == ResFileName || !File.Exists(fullPath))
			{
				return list;
			}
			list.Add(fullPath);
		}
		catch
		{
		}
		return list;
	}
}
