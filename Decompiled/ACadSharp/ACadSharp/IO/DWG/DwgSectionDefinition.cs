using System.Collections.Generic;

namespace ACadSharp.IO.DWG;

internal static class DwgSectionDefinition
{
	public const string AcDbObjects = "AcDb:AcDbObjects";

	public const string AppInfo = "AcDb:AppInfo";

	public const string AuxHeader = "AcDb:AuxHeader";

	public const string Header = "AcDb:Header";

	public const string Classes = "AcDb:Classes";

	public const string Handles = "AcDb:Handles";

	public const string ObjFreeSpace = "AcDb:ObjFreeSpace";

	public const string Template = "AcDb:Template";

	public const string SummaryInfo = "AcDb:SummaryInfo";

	public const string FileDepList = "AcDb:FileDepList";

	public const string Preview = "AcDb:Preview";

	public const string RevHistory = "AcDb:RevHistory";

	public static Dictionary<string, byte[]> StartSentinels = new Dictionary<string, byte[]>
	{
		{
			"AcDb:Header",
			new byte[16]
			{
				207, 123, 31, 35, 253, 222, 56, 169, 95, 124,
				104, 184, 78, 109, 51, 95
			}
		},
		{
			"AcDb:Classes",
			new byte[16]
			{
				141, 161, 196, 184, 196, 169, 248, 197, 192, 220,
				244, 95, 231, 207, 182, 138
			}
		},
		{
			"AcDb:Preview",
			new byte[16]
			{
				31, 37, 109, 7, 212, 54, 40, 40, 157, 87,
				202, 63, 157, 68, 16, 43
			}
		}
	};

	public static Dictionary<string, byte[]> EndSentinels = new Dictionary<string, byte[]>
	{
		{
			"AcDb:Header",
			new byte[16]
			{
				48, 132, 224, 220, 2, 33, 199, 86, 160, 131,
				151, 71, 177, 146, 204, 160
			}
		},
		{
			"AcDb:Classes",
			new byte[16]
			{
				114, 94, 59, 71, 59, 86, 7, 58, 63, 35,
				11, 160, 24, 48, 73, 117
			}
		},
		{
			"AcDb:Preview",
			new byte[16]
			{
				224, 218, 146, 248, 43, 201, 215, 215, 98, 168,
				53, 192, 98, 187, 239, 212
			}
		}
	};

	public static int? GetSectionLocatorByName(string name)
	{
		return name switch
		{
			"AcDb:Header" => 0, 
			"AcDb:Classes" => 1, 
			"AcDb:Handles" => 2, 
			"AcDb:ObjFreeSpace" => 3, 
			"AcDb:Template" => 4, 
			"AcDb:AuxHeader" => 5, 
			_ => null, 
		};
	}
}
