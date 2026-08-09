using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MaterialResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcMaterialDefinition : IPersistEntity, IPersist, IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect
{
	IEnumerable<IIfcRelAssociatesMaterial> AssociatedTo { get; }

	IEnumerable<IIfcExternalReferenceRelationship> HasExternalReferences { get; }

	IEnumerable<IIfcMaterialProperties> HasProperties { get; }
}
