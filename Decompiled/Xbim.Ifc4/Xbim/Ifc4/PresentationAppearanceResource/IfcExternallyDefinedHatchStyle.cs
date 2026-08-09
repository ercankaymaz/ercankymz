using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.PresentationAppearanceResource;

[ExpressType("IfcExternallyDefinedHatchStyle", 724)]
public class IfcExternallyDefinedHatchStyle : IfcExternalReference, IInstantiableEntity, IPersistEntity, IPersist, IIfcExternallyDefinedHatchStyle, IIfcExternalReference, IfcLightDistributionDataSourceSelect, IIfcLightDistributionDataSourceSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IfcFillStyleSelect, IIfcFillStyleSelect, IEquatable<IfcExternallyDefinedHatchStyle>
{
	internal IfcExternallyDefinedHatchStyle(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 2u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcExternallyDefinedHatchStyle other)
	{
		return this == other;
	}
}
