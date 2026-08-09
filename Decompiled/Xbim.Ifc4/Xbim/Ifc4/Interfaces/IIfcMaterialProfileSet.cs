using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MaterialResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcMaterialProfileSet : IIfcMaterialDefinition, IPersistEntity, IPersist, IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect
{
	IfcLabel? Name { get; set; }

	IfcText? Description { get; set; }

	IItemSet<IIfcMaterialProfile> MaterialProfiles { get; }

	IIfcCompositeProfileDef CompositeProfile { get; set; }
}
