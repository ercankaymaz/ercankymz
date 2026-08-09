using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace buClass;

[Serializable]
public class FileItem : buSerilization
{
	public string FileFullName = Application.StartupPath;

	public string FileName = "";

	public string FileNameWithoutExtension = "";

	public string FileFolder = Application.StartupPath;

	public bool Enable = true;

	public List<FileSubItem> SubFiles = new List<FileSubItem>();

	public FileItem()
	{
	}

	public FileItem(string FullFileName)
	{
		FileFullName = FullFileName;
		FileNameWithoutExtension = Path.GetFileNameWithoutExtension(FullFileName);
		FileName = Path.GetFileName(FullFileName);
	}

	public FileItem(FileItem data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
		{
			FieldInfo[] fields = GetType().GetFields();
			if (fields != null)
			{
				for (int i = 0; i <= fields.Length - 1; i++)
				{
					string name = fields[i].Name;
					object value = fields[i].GetValue(CopiedClass);
					fields[i].SetValue(this, value);
				}
			}
		}
		SubFiles.Clear();
		for (int j = 0; j <= data.SubFiles.Count - 1; j++)
		{
			SubFiles.Add(new FileSubItem(data.SubFiles[j]));
		}
	}

	public override string ToString()
	{
		return FileNameWithoutExtension;
	}
}
