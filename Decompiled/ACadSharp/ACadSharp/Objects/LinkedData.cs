using ACadSharp.Attributes;

namespace ACadSharp.Objects;

[DxfSubClass("AcDbLinkedData")]
public abstract class LinkedData : NonGraphicalObject
{
	public override string SubclassMarker => "AcDbLinkedData";

	[DxfCodeValue(new int[] { 1 })]
	public override string Name
	{
		get
		{
			return base.Name;
		}
		set
		{
			base.Name = value;
		}
	}

	[DxfCodeValue(new int[] { 300 })]
	public string Description { get; set; }
}
