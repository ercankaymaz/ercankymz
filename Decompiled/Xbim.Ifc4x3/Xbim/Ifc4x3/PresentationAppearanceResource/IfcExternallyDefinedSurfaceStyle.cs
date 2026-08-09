using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationAppearanceResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.PropertyResource;
using Xbim.Ifc4x3.ExternalReferenceResource;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

[ExpressType("IfcExternallyDefinedSurfaceStyle", 318)]
public class IfcExternallyDefinedSurfaceStyle : Xbim.Ifc4x3.ExternalReferenceResource.IfcExternalReference, IIfcExternallyDefinedSurfaceStyle, IIfcExternalReference, IPersistEntity, IPersist, IfcLightDistributionDataSourceSelect, IIfcLightDistributionDataSourceSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, Xbim.Ifc4.ExternalReferenceResource.IfcResourceObjectSelect, IIfcResourceObjectSelect, Xbim.Ifc4.PresentationAppearanceResource.IfcSurfaceStyleElementSelect, IIfcSurfaceStyleElementSelect, IInstantiableEntity, IfcSurfaceStyleElementSelect, IEquatable<IfcExternallyDefinedSurfaceStyle>
{
	internal IfcExternallyDefinedSurfaceStyle(IModel model, int label, bool activated)
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

	public bool Equals(IfcExternallyDefinedSurfaceStyle other)
	{
		return this == other;
	}
}
