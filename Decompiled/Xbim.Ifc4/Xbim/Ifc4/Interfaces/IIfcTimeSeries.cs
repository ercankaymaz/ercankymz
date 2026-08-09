using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.ConstraintResource;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTimeSeries : IPersistEntity, IPersist, IfcMetricValueSelect, IIfcMetricValueSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect
{
	IfcLabel Name { get; set; }

	IfcText? Description { get; set; }

	IfcDateTime StartTime { get; set; }

	IfcDateTime EndTime { get; set; }

	IfcTimeSeriesDataTypeEnum TimeSeriesDataType { get; set; }

	IfcDataOriginEnum DataOrigin { get; set; }

	IfcLabel? UserDefinedDataOrigin { get; set; }

	IIfcUnit Unit { get; set; }

	IEnumerable<IIfcExternalReferenceRelationship> HasExternalReference { get; }
}
