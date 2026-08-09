using System;
using devDept.Serialization;

namespace buEyeBaseVer5.buEntities;

public class MyFileSerializer : FileSerializer
{
	public static string CustomTag = "1.2";

	public static int Version = 0;

	public MyFileSerializer()
	{
	}

	public MyFileSerializer(contentType contentType)
		: base(contentType)
	{
	}

	protected override void FillModel()
	{
		base.FillModel();
	}

	protected override Type GetTypeForObject(string typeName)
	{
		Type type = Type.GetType(typeName, throwOnError: false, ignoreCase: true);
		if (!(type != null))
		{
			return base.GetTypeForObject(typeName);
		}
		return type;
	}
}
