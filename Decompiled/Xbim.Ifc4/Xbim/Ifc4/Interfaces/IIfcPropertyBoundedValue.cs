using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcPropertyBoundedValue : IIfcSimpleProperty, IIfcProperty, IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	IIfcValue UpperBoundValue { get; set; }

	IIfcValue LowerBoundValue { get; set; }

	IIfcUnit Unit { get; set; }

	IIfcValue SetPointValue { get; set; }
}
