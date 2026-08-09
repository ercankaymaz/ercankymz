using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MaterialResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcMaterial : IIfcMaterialDefinition, IPersistEntity, IPersist, IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect
{
	IfcLabel Name { get; set; }

	IfcText? Description { get; set; }

	IfcLabel? Category { get; set; }

	IEnumerable<IIfcMaterialDefinitionRepresentation> HasRepresentation { get; }

	IEnumerable<IIfcMaterialRelationship> IsRelatedWith { get; }

	IEnumerable<IIfcMaterialRelationship> RelatesTo { get; }
}
