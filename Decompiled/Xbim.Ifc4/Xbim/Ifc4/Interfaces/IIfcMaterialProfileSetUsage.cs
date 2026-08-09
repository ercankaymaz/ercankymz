using Xbim.Common;
using Xbim.Ifc4.MaterialResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcMaterialProfileSetUsage : IIfcMaterialUsageDefinition, IPersistEntity, IPersist, IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType
{
	IIfcMaterialProfileSet ForProfileSet { get; set; }

	IfcCardinalPointReference? CardinalPoint { get; set; }

	IfcPositiveLengthMeasure? ReferenceExtent { get; set; }
}
