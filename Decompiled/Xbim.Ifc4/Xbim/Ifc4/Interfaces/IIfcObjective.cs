using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcObjective : IIfcConstraint, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	IItemSet<IIfcConstraint> BenchmarkValues { get; }

	IfcLogicalOperatorEnum? LogicalAggregator { get; set; }

	IfcObjectiveEnum ObjectiveQualifier { get; set; }

	IfcLabel? UserDefinedQualifier { get; set; }
}
