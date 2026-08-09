using System;
using ACadSharp.Attributes;

namespace ACadSharp.Tables;

[DxfName("APPID")]
[DxfSubClass("AcDbRegAppTableRecord")]
public class AppId : TableEntry
{
	public const string BlockRepBTag = "AcDbBlockRepBTag";

	public const string BlockRepETag = "AcDbBlockRepETag";

	public const string DefaultName = "ACAD";

	public static AppId Default => new AppId("ACAD");

	public override string ObjectName => "APPID";

	public override ObjectType ObjectType => ObjectType.APPID;

	public override string SubclassMarker => "AcDbRegAppTableRecord";

	public AppId(string name)
		: base(name)
	{
		if (string.IsNullOrEmpty(name))
		{
			throw new ArgumentNullException("name", "Application id must have a name.");
		}
	}

	internal AppId()
	{
	}
}
