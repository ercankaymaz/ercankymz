using ACadSharp.Attributes;

namespace ACadSharp.Objects;

[DxfName("DICTIONARYVAR")]
[DxfSubClass("DictionaryVariables")]
public class DictionaryVariable : NonGraphicalObject
{
	public const string CurrentAnnotationScale = "CANNOSCALE";

	public const string CurrentMultiLeaderStyle = "CMLEADERSTYLE";

	public const string CurrentTableStyle = "CTABLESTYLE";

	public const string WipeoutFrame = "WIPEOUTFRAME";

	public override string ObjectName => "DICTIONARYVAR";

	[DxfCodeValue(new int[] { 280 })]
	public int ObjectSchemaNumber { get; internal set; }

	public override ObjectType ObjectType => ObjectType.UNLISTED;

	public override string SubclassMarker => "DictionaryVariables";

	[DxfCodeValue(new int[] { 1 })]
	public string Value { get; set; }

	public DictionaryVariable()
	{
	}

	public DictionaryVariable(string name, string value)
		: base(name)
	{
		Value = value;
	}
}
