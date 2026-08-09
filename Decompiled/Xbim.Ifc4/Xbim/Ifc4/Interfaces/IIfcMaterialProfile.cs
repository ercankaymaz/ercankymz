using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MaterialResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcMaterialProfile : IIfcMaterialDefinition, IPersistEntity, IPersist, IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect
{
	IfcLabel? Name { get; set; }

	IfcText? Description { get; set; }

	IIfcMaterial Material { get; set; }

	IIfcProfileDef Profile { get; set; }

	IfcInteger? Priority { get; set; }

	IfcLabel? Category { get; set; }

	IIfcMaterialProfileSet ToMaterialProfileSet { get; }
}
