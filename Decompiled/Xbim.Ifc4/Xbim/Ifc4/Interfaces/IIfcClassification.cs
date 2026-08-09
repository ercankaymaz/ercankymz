using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcClassification : IIfcExternalInformation, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IfcClassificationReferenceSelect, IIfcClassificationReferenceSelect, IfcClassificationSelect, IIfcClassificationSelect
{
	IfcLabel? Source { get; set; }

	IfcLabel? Edition { get; set; }

	IfcDate? EditionDate { get; set; }

	IfcLabel Name { get; set; }

	IfcText? Description { get; set; }

	IfcURIReference? Location { get; set; }

	IItemSet<IfcIdentifier> ReferenceTokens { get; }

	IEnumerable<IIfcRelAssociatesClassification> ClassificationForObjects { get; }

	IEnumerable<IIfcClassificationReference> HasReferences { get; }
}
