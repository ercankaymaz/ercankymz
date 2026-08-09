using Xbim.Common;
using Xbim.Ifc4x3.ConstraintResource;
using Xbim.Ifc4x3.CostResource;

namespace Xbim.Ifc4x3.MeasureResource;

public interface IfcMeasureValue : IfcValue, IfcAppliedValueSelect, IExpressSelectType, IPersist, IfcMetricValueSelect, IExpressValueType
{
}
