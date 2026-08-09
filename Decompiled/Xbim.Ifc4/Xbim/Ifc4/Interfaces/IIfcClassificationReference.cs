using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcClassificationReference : IIfcExternalReference, IPersistEntity, IPersist, IfcLightDistributionDataSourceSelect, IIfcLightDistributionDataSourceSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IfcClassificationReferenceSelect, IIfcClassificationReferenceSelect, IfcClassificationSelect, IIfcClassificationSelect
{
	IIfcClassificationReferenceSelect ReferencedSource { get; set; }

	IfcText? Description { get; set; }

	IfcIdentifier? Sort { get; set; }

	IEnumerable<IIfcRelAssociatesClassification> ClassificationRefForObjects { get; }

	IEnumerable<IIfcClassificationReference> HasReferences { get; }
}
