using System.Collections.Generic;
using buClass;

namespace buEyeBaseVer5.Apps;

public class buPrinter3D
{
	public static List<string> LangPrinter3DStatus = new List<string>();

	public static List<string> LangPrinter3DMessage = new List<string>();

	public static List<string> LangPrinter3DCaptions = new List<string>();

	public static List<string> LangPrinter3DCommands = new List<string>();

	public static Printer3DTempVars varTemps = new Printer3DTempVars();

	public static Printer3DSettings varPrinter3DSettings = new Printer3DSettings();

	public static Printer3DRuntimeSettings varPrinter3DRunSettings = new Printer3DRuntimeSettings();

	public buPrinter3D()
	{
		if (!buVector5.smethod_0("buPrinter3D"))
		{
			throw new RegisterException("buPrinter3D");
		}
	}

	public static string LayerToString(Printer3DLayer Layer)
	{
		string text = "";
		return text + Layer.LevelZ.ToString("f2") + " mm";
	}
}
