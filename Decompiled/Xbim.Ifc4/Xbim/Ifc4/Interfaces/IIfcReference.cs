using Xbim.Common;
using Xbim.Ifc4.ConstraintResource;
using Xbim.Ifc4.CostResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcReference : IPersistEntity, IPersist, IfcAppliedValueSelect, IIfcAppliedValueSelect, IExpressSelectType, IfcMetricValueSelect, IIfcMetricValueSelect
{
	IfcIdentifier? TypeIdentifier { get; set; }

	IfcIdentifier? AttributeIdentifier { get; set; }

	IfcLabel? InstanceName { get; set; }

	IItemSet<IfcInteger> ListPositions { get; }

	IIfcReference InnerReference { get; set; }
}
