using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcExternalReference : IPersistEntity, IPersist, IfcLightDistributionDataSourceSelect, IIfcLightDistributionDataSourceSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect
{
	IfcURIReference? Location { get; set; }

	IfcIdentifier? Identification { get; set; }

	IfcLabel? Name { get; set; }

	IEnumerable<IIfcExternalReferenceRelationship> ExternalReferenceForResources { get; }
}
