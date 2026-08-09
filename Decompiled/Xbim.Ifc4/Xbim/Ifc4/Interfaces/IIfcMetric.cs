using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcMetric : IIfcConstraint, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	IfcBenchmarkEnum Benchmark { get; set; }

	IfcLabel? ValueSource { get; set; }

	IIfcMetricValueSelect DataValue { get; set; }

	IIfcReference ReferencePath { get; set; }
}
