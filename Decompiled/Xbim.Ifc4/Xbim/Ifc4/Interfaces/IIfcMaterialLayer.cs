using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MaterialResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcMaterialLayer : IIfcMaterialDefinition, IPersistEntity, IPersist, IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect
{
	IIfcMaterial Material { get; set; }

	IfcNonNegativeLengthMeasure LayerThickness { get; set; }

	IfcLogical? IsVentilated { get; set; }

	IfcLabel? Name { get; set; }

	IfcText? Description { get; set; }

	IfcLabel? Category { get; set; }

	IfcInteger? Priority { get; set; }

	IIfcMaterialLayerSet ToMaterialLayerSet { get; }
}
