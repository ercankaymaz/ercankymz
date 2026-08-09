using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcPhysicalQuantity : IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	IfcLabel Name { get; set; }

	IfcText? Description { get; set; }

	IEnumerable<IIfcExternalReferenceRelationship> HasExternalReferences { get; }

	IEnumerable<IIfcPhysicalComplexQuantity> PartOfComplex { get; }
}
