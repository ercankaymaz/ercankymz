using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcPropertySingleValue : IIfcSimpleProperty, IIfcProperty, IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	IIfcValue NominalValue { get; set; }

	IIfcUnit Unit { get; set; }
}
