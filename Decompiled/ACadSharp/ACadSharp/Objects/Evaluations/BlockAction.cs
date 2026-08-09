using System.Collections.Generic;
using ACadSharp.Attributes;
using ACadSharp.Entities;
using CSMath;

namespace ACadSharp.Objects.Evaluations;

[DxfSubClass("AcDbBlockAction")]
public abstract class BlockAction : BlockElement
{
	public override string SubclassMarker => "AcDbBlockAction";

	[DxfCodeValue(new int[] { 17 })]
	public short Value70 { get; set; }

	[DxfCodeValue(DxfReferenceType.Count, new int[] { 71 })]
	[DxfCollectionCodeValue(DxfReferenceType.Handle, new int[] { 330 })]
	public List<Entity> Entities { get; } = new List<Entity>();

	[DxfCodeValue(new int[] { 1010, 1020, 1030 })]
	public XYZ ActionPoint { get; set; }
}
