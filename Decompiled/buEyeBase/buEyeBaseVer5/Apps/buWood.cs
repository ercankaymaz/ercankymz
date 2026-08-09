using System.Collections.Generic;
using buClass;

namespace buEyeBaseVer5.Apps;

public class buWood
{
	public static List<string> LangWoodStatus = new List<string>();

	public static List<string> LangWoodMessage = new List<string>();

	public static List<string> LangWoodCaptions = new List<string>();

	public static List<string> LangWoodCommands = new List<string>();

	public static WoodTempVars varTemps = new WoodTempVars();

	public static WoodSettings varWoodSettings = new WoodSettings();

	public static WoodRuntimeSettings varWoodRunSettings = new WoodRuntimeSettings();

	public buWood()
	{
		if (!buVector5.smethod_0("buWood"))
		{
			throw new RegisterException("buWood");
		}
	}
}
