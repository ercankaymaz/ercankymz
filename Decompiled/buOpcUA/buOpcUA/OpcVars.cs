using System;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;

namespace buOpcUA;

public class OpcVars
{
	public static string OpcName;

	public static string OpcUrl;

	public static string FirstNode;

	public static string OPCRootName;

	public static OpcClient opcClient;

	public static OpcClient opcClient2;

	public static string pathCodesysGvl;

	public static string pathCodesysPersistent;

	public static string pathCodesysIO;

	public static string pathCodesysCNC;

	public static int Interval;

	public static int ReadCycleCount;

	public static int ReadCounter;

	public static int ErrorCount;

	[NonSerialized]
	internal static GetString _0083;

	static OpcVars()
	{
		do
		{
			Type typeFromHandle = typeof(OpcVars);
			if (0 == 0)
			{
				Strings.CreateGetStringDelegate(typeFromHandle);
			}
		}
		while (4 == 0);
		OpcName = _0083(107396765);
		OpcUrl = _0083(107396756);
		do
		{
			FirstNode = _0083(107396727);
		}
		while (3 == 0);
		OPCRootName = _0083(107396674);
		pathCodesysGvl = _0083(107397085);
		pathCodesysPersistent = _0083(107397032);
		pathCodesysIO = _0083(107396911);
		if (8u != 0)
		{
			if (3 == 0)
			{
				goto IL_00cd;
			}
			pathCodesysCNC = _0083(107396354);
			Interval = 1000;
		}
		ReadCycleCount = 2;
		goto IL_00cd;
		IL_00cd:
		ReadCounter = 0;
		ErrorCount = 0;
	}
}
