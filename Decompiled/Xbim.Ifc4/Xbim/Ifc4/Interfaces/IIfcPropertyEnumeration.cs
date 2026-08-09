using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcPropertyEnumeration : IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	IfcLabel Name { get; set; }

	IItemSet<IIfcValue> EnumerationValues { get; }

	IIfcUnit Unit { get; set; }
}
