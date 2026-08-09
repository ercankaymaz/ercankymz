using System;
using System.Diagnostics;
using System.IO;
using Aladdin.HASP;

namespace HEDS;

internal class HedsFile
{
	public enum heds_status
	{
		HEDS_STATUS_OK = 0,
		HEDS_SIGNATURE_BROKEN = -1,
		HEDS_GENERATION_NOT_FOUND = -2,
		HEDS_FILE_NOT_FOUND = -3
	}

	public string strFileName;

	public HedsCrypt hedsCrypt;

	private HedsSign hedsSign;

	public string CheckFile(string str)
	{
		string text = str;
		if (!text.EndsWith("\\"))
		{
			text += "\\";
		}
		text += strFileName;
		if (File.Exists(text))
		{
			return text;
		}
		return null;
	}

	public string FindFile(string additionalPath)
	{
		try
		{
			string text = CheckFile(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName));
			if (text != null)
			{
				return text;
			}
			text = CheckFile(Path.GetFullPath(Environment.CurrentDirectory));
			if (text != null)
			{
				return text;
			}
			text = CheckFile(Path.GetFullPath(Environment.SystemDirectory));
			if (text != null)
			{
				return text;
			}
			text = CheckFile(Path.GetFullPath(Environment.GetEnvironmentVariable("windir") + "\\system"));
			if (text != null)
			{
				return text;
			}
			text = CheckFile(Path.GetFullPath(Environment.GetEnvironmentVariable("windir")));
			if (text != null)
			{
				return text;
			}
			if (additionalPath != null)
			{
				text = CheckFile(additionalPath);
				if (text != null)
				{
					return text;
				}
			}
			string[] array = Environment.GetEnvironmentVariable("path").Split(';');
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != null && array[i].Length > 0)
				{
					text = CheckFile(Path.GetFullPath(array[i]));
					if (text != null)
					{
						return text;
					}
				}
			}
		}
		catch (FileNotFoundException)
		{
		}
		return null;
	}

	public heds_status CheckSignature(string strFile, int iGeneration)
	{
		try
		{
			if (strFile == null)
			{
				return heds_status.HEDS_FILE_NOT_FOUND;
			}
			hedsSign = new HedsSign();
			FileStream fileStream = new FileStream(strFile, FileMode.Open, FileAccess.Read);
			fileStream.Seek(-4L, SeekOrigin.End);
			BinaryReader binaryReader = new BinaryReader(fileStream);
			int num = binaryReader.ReadInt32();
			if (num > 0 && num < fileStream.Length)
			{
				fileStream.Seek(num, SeekOrigin.Begin);
				if (hedsSign.LoadSignature(fileStream))
				{
					int count = num;
					fileStream.Seek(0L, SeekOrigin.Begin);
					byte[] bSource = binaryReader.ReadBytes(count);
					byte[] signature = hedsSign.GetSignature(iGeneration);
					if (signature != null)
					{
						if (hedsCrypt.VerifyData(bSource, signature))
						{
							return heds_status.HEDS_STATUS_OK;
						}
						return heds_status.HEDS_SIGNATURE_BROKEN;
					}
				}
			}
		}
		catch (DllBrokenException)
		{
			return heds_status.HEDS_SIGNATURE_BROKEN;
		}
		return heds_status.HEDS_GENERATION_NOT_FOUND;
	}
}
