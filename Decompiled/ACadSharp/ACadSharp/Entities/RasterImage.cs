using System;
using ACadSharp.Attributes;
using ACadSharp.Objects;

namespace ACadSharp.Entities;

[DxfName("IMAGE")]
[DxfSubClass("AcDbRasterImage")]
public class RasterImage : CadWipeoutBase
{
	public override string ObjectName => "IMAGE";

	public override ObjectType ObjectType => ObjectType.UNLISTED;

	public override string SubclassMarker => "AcDbRasterImage";

	public override ImageDefinition Definition
	{
		get
		{
			return base.Definition;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			base.Definition = value;
		}
	}

	public RasterImage(ImageDefinition definition)
	{
		Definition = definition;
	}

	internal RasterImage()
	{
	}
}
