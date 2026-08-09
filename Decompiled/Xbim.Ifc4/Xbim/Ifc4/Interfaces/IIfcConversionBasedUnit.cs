using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcConversionBasedUnit : IIfcNamedUnit, IPersistEntity, IPersist, IfcUnit, IIfcUnit, IExpressSelectType, IfcResourceObjectSelect, IIfcResourceObjectSelect
{
	IfcLabel Name { get; set; }

	IIfcMeasureWithUnit ConversionFactor { get; set; }

	IEnumerable<IIfcExternalReferenceRelationship> HasExternalReference { get; }
}
