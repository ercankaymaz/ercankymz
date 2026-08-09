using Xbim.Common;
using Xbim.Ifc4.ConstraintResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcCostValue : IIfcAppliedValue, IPersistEntity, IPersist, IfcMetricValueSelect, IIfcMetricValueSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect
{
}
