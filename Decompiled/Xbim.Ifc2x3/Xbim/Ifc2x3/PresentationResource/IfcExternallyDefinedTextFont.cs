using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.ExternalReferenceResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationAppearanceResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc2x3.PresentationResource;

[ExpressType("IfcExternallyDefinedTextFont", 132)]
public class IfcExternallyDefinedTextFont : Xbim.Ifc2x3.ExternalReferenceResource.IfcExternalReference, IIfcExternallyDefinedTextFont, IIfcExternalReference, IPersistEntity, IPersist, IfcLightDistributionDataSourceSelect, IIfcLightDistributionDataSourceSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, Xbim.Ifc4.PresentationAppearanceResource.IfcTextFontSelect, IIfcTextFontSelect, IInstantiableEntity, IfcTextFontSelect, IEquatable<IfcExternallyDefinedTextFont>
{
	internal IfcExternallyDefinedTextFont(IModel model, int label, bool activated)
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

	public bool Equals(IfcExternallyDefinedTextFont other)
	{
		return this == other;
	}
}
