using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Xbim.Common;

public class XbimAssemblyInfo
{
	private readonly Assembly _assembly;

	public string OverrideLocation;

	public string AssemblyLocation
	{
		get
		{
			if (!string.IsNullOrEmpty(OverrideLocation))
			{
				return OverrideLocation;
			}
			return _assembly.Location;
		}
	}

	public Version AssemblyVersion => _assembly.GetName().Version;

	public string FileVersion
	{
		get
		{
			if (string.IsNullOrEmpty(AssemblyLocation))
			{
				return "";
			}
			return FileVersionInfo.GetVersionInfo(AssemblyLocation).FileVersion;
		}
	}

	public FileInfo FileInfo
	{
		get
		{
			if (!_assembly.IsDynamic)
			{
				return new FileInfo(new Uri(_assembly.CodeBase).LocalPath);
			}
			return new FileInfo("");
		}
	}

	public DateTime CompilationTime
	{
		get
		{
			DateTime minValue = DateTime.MinValue;
			if (FileVersion == null)
			{
				return minValue;
			}
			string[] array = FileVersion.Split(new string[1] { "." }, StringSplitOptions.None);
			if (array.Length != 4)
			{
				return DateTime.MinValue;
			}
			try
			{
				int year = 2000 + Convert.ToInt32(array[2].Substring(0, 2));
				int month = Convert.ToInt32(array[2].Substring(2, 2));
				int day = Convert.ToInt32(array[3].Substring(0, 2));
				int num = Convert.ToInt32(array[3].Substring(2)) * 2;
				int minute = num % 60;
				int hour = num / 60;
				return new DateTime(year, month, day, hour, minute, 0);
			}
			catch (Exception)
			{
				return FileInfo.CreationTimeUtc;
			}
		}
	}

	public static string AssemblyInformation(Assembly theAssembly)
	{
		XbimAssemblyInfo xbimAssemblyInfo = new XbimAssemblyInfo(theAssembly);
		return $"{theAssembly.GetName().Name}\t{xbimAssemblyInfo.AssemblyVersion}\t{xbimAssemblyInfo.FileVersion}\t{xbimAssemblyInfo.CompilationTime}\r\n";
	}

	public XbimAssemblyInfo(Assembly assembly)
	{
		_assembly = assembly;
	}

	public XbimAssemblyInfo(Type type)
	{
		_assembly = type.GetTypeInfo().Assembly;
	}
}
