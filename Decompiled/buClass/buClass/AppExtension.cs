using System;
using System.Collections;

namespace buClass;

[Serializable]
public class AppExtension : buSerilization
{
	public static ArrayList OpenFileExtension = new ArrayList();

	public static ArrayList SaveFileExtension = new ArrayList();

	public static ArrayList GCodeFileExtension = new ArrayList();

	public static ArrayList ImportFileExtension = new ArrayList();

	public static ArrayList ExportFileExtension = new ArrayList();
}
