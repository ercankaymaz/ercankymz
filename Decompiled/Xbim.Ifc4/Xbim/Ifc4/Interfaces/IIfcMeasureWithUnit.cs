using Xbim.Common;
using Xbim.Ifc4.ConstraintResource;
using Xbim.Ifc4.CostResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcMeasureWithUnit : IPersistEntity, IPersist, IfcAppliedValueSelect, IIfcAppliedValueSelect, IExpressSelectType, IfcMetricValueSelect, IIfcMetricValueSelect
{
	IIfcValue ValueComponent { get; set; }

	IIfcUnit UnitComponent { get; set; }
}
