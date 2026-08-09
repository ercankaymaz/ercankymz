using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MaterialResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcMaterialConstituent : IIfcMaterialDefinition, IPersistEntity, IPersist, IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect
{
	IfcLabel? Name { get; set; }

	IfcText? Description { get; set; }

	IIfcMaterial Material { get; set; }

	IfcNormalisedRatioMeasure? Fraction { get; set; }

	IfcLabel? Category { get; set; }

	IIfcMaterialConstituentSet ToMaterialConstituentSet { get; }
}
