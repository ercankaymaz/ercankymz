using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.ConstraintResource;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcAppliedValue : IPersistEntity, IPersist, IfcMetricValueSelect, IIfcMetricValueSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect
{
	IfcLabel? Name { get; set; }

	IfcText? Description { get; set; }

	IIfcAppliedValueSelect AppliedValue { get; set; }

	IIfcMeasureWithUnit UnitBasis { get; set; }

	IfcDate? ApplicableDate { get; set; }

	IfcDate? FixedUntilDate { get; set; }

	IfcLabel? Category { get; set; }

	IfcLabel? Condition { get; set; }

	IfcArithmeticOperatorEnum? ArithmeticOperator { get; set; }

	IEnumerable<IIfcAppliedValue> Components { get; }

	IEnumerable<IIfcExternalReferenceRelationship> HasExternalReference { get; }
}
