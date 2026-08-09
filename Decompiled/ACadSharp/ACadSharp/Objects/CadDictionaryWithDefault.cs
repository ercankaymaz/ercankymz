using ACadSharp.Attributes;

namespace ACadSharp.Objects;

[DxfName("ACDBDICTIONARYWDFLT")]
[DxfSubClass("AcDbDictionaryWithDefault")]
public class CadDictionaryWithDefault : CadDictionary
{
	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 340 })]
	public CadObject DefaultEntry { get; set; }

	public override string ObjectName => "ACDBDICTIONARYWDFLT";

	public override ObjectType ObjectType => ObjectType.UNLISTED;

	public override string SubclassMarker => "AcDbDictionaryWithDefault";

	public CadDictionaryWithDefault()
	{
	}

	public CadDictionaryWithDefault(string name, CadObject defaultEntry)
		: base(name)
	{
		DefaultEntry = defaultEntry;
	}
}
