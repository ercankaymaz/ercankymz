using Xbim.Common;
using Xbim.Ifc4.MaterialResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcMaterialLayerSetUsage : IIfcMaterialUsageDefinition, IPersistEntity, IPersist, IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType
{
	IIfcMaterialLayerSet ForLayerSet { get; set; }

	IfcLayerSetDirectionEnum LayerSetDirection { get; set; }

	IfcDirectionSenseEnum DirectionSense { get; set; }

	IfcLengthMeasure OffsetFromReferenceLine { get; set; }

	IfcPositiveLengthMeasure? ReferenceExtent { get; set; }
}
