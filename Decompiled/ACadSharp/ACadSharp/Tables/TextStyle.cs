using ACadSharp.Attributes;
using ACadSharp.Entities;

namespace ACadSharp.Tables;

[DxfName("STYLE")]
[DxfSubClass("AcDbTextStyleTableRecord")]
public class TextStyle : TableEntry
{
	public const string DefaultName = "Standard";

	public override ObjectType ObjectType => ObjectType.STYLE;

	public override string ObjectName => "STYLE";

	public override string SubclassMarker => "AcDbTextStyleTableRecord";

	public static TextStyle Default => new TextStyle("Standard");

	public new StyleFlags Flags
	{
		get
		{
			return (StyleFlags)base.Flags;
		}
		set
		{
			base.Flags = (StandardFlags)value;
		}
	}

	[DxfCodeValue(new int[] { 3 })]
	public string Filename { get; set; } = string.Empty;

	[DxfCodeValue(new int[] { 4 })]
	public string BigFontFilename { get; set; }

	[DxfCodeValue(new int[] { 40 })]
	public double Height { get; set; }

	[DxfCodeValue(new int[] { 41 })]
	public double Width { get; set; } = 1.0;

	[DxfCodeValue(new int[] { 42 })]
	public double LastHeight { get; set; }

	[DxfCodeValue(DxfReferenceType.IsAngle, new int[] { 50 })]
	public double ObliqueAngle { get; set; }

	[DxfCodeValue(new int[] { 71 })]
	public TextMirrorFlag MirrorFlag { get; set; }

	[DxfCodeValue(DxfReferenceType.Optional, new int[] { 1071 })]
	public FontFlags TrueType { get; set; }

	public bool IsShapeFile => Flags.HasFlag(StyleFlags.IsShape);

	internal TextStyle()
	{
	}

	public TextStyle(string name)
		: base(name)
	{
	}
}
