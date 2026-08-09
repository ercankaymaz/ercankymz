using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MaterialResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcMaterialLayerWithOffsets : IIfcMaterialLayer, IIfcMaterialDefinition, IPersistEntity, IPersist, IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect
{
	IfcLayerSetDirectionEnum OffsetDirection { get; set; }

	IItemSet<IfcLengthMeasure> OffsetValues { get; }
}
