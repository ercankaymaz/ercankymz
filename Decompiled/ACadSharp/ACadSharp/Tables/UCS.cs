using ACadSharp.Attributes;
using CSMath;

namespace ACadSharp.Tables;

[DxfName("UCS")]
[DxfSubClass("AcDbUCSTableRecord")]
public class UCS : TableEntry
{
	public override ObjectType ObjectType => ObjectType.UCS;

	public override string ObjectName => "UCS";

	public override string SubclassMarker => "AcDbUCSTableRecord";

	[DxfCodeValue(new int[] { 10, 20, 30 })]
	public XYZ Origin { get; set; } = XYZ.Zero;

	[DxfCodeValue(new int[] { 11, 21, 31 })]
	public XYZ XAxis { get; set; } = XYZ.AxisX;

	[DxfCodeValue(new int[] { 12, 22, 32 })]
	public XYZ YAxis { get; set; } = XYZ.AxisY;

	[DxfCodeValue(new int[] { 71 })]
	public OrthographicType OrthographicType { get; set; }

	[DxfCodeValue(new int[] { 79 })]
	public OrthographicType OrthographicViewType { get; set; }

	[DxfCodeValue(new int[] { 146 })]
	public double Elevation { get; set; }

	internal UCS()
	{
	}

	public UCS(string name)
		: base(name)
	{
	}
}
