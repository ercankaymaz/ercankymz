using ACadSharp.Attributes;
using CSMath;

namespace ACadSharp.Entities;

[DxfName("OLE2FRAME")]
[DxfSubClass("AcDbOle2Frame")]
public class Ole2Frame : Entity
{
	[DxfCodeValue(new int[] { 310 })]
	public byte[] BinaryData { get; set; }

	[DxfCodeValue(new int[] { 72 })]
	public bool IsPaperSpace { get; set; }

	[DxfCodeValue(new int[] { 11, 21, 31 })]
	public XYZ LowerRightCorner { get; set; } = XYZ.Zero;

	public override string ObjectName => "OLE2FRAME";

	public override ObjectType ObjectType => ObjectType.OLE2FRAME;

	[DxfCodeValue(new int[] { 71 })]
	public OleObjectType OleObjectType { get; set; } = OleObjectType.Embedded;

	[DxfCodeValue(new int[] { 3 })]
	public string SourceApplication { get; set; }

	public override string SubclassMarker => "AcDbOle2Frame";

	[DxfCodeValue(new int[] { 10, 20, 30 })]
	public XYZ UpperLeftCorner { get; set; } = new XYZ(1.0, 1.0, 0.0);

	[DxfCodeValue(new int[] { 70 })]
	public short Version { get; internal set; } = 2;

	public override void ApplyTransform(Transform transform)
	{
		UpperLeftCorner = transform.ApplyTranslation(UpperLeftCorner);
		LowerRightCorner = transform.ApplyTranslation(LowerRightCorner);
	}

	public override BoundingBox GetBoundingBox()
	{
		return BoundingBox.FromPoints(new _003C_003Ez__ReadOnlyArray<XYZ>(new XYZ[2] { LowerRightCorner, UpperLeftCorner }));
	}
}
