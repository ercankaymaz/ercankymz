using System.Linq;
using ACadSharp.Attributes;
using CSUtilities.Extensions;

namespace ACadSharp.Objects;

[DxfName("DBCOLOR")]
[DxfSubClass("AcDbColor")]
public class BookColor : NonGraphicalObject
{
	public override ObjectType ObjectType => ObjectType.UNLISTED;

	public override string ObjectName => "DBCOLOR";

	public override string SubclassMarker => "AcDbColor";

	public override string Name
	{
		get
		{
			if (ColorName.IsNullOrEmpty())
			{
				return string.Empty;
			}
			return BookName + "$" + ColorName;
		}
		set
		{
			if (value.Contains('$'))
			{
				base.Name = value;
				BookName = value.Split('$').First();
				ColorName = value.Split('$').Last();
			}
			else
			{
				ColorName = value;
			}
		}
	}

	public string ColorName { get; set; }

	public string BookName { get; set; }

	[DxfCodeValue(new int[] { 62, 420 })]
	public Color Color { get; set; }

	public BookColor()
	{
	}

	public BookColor(string name)
		: base(name)
	{
	}

	public BookColor(string name, string bookName)
	{
		Name = name;
		BookName = bookName;
	}
}
