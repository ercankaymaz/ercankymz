using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcDocumentReference : IIfcExternalReference, IPersistEntity, IPersist, IfcLightDistributionDataSourceSelect, IIfcLightDistributionDataSourceSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IfcDocumentSelect, IIfcDocumentSelect
{
	IfcText? Description { get; set; }

	IIfcDocumentInformation ReferencedDocument { get; set; }

	IEnumerable<IIfcRelAssociatesDocument> DocumentRefForObjects { get; }
}
