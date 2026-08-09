using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcPropertyEnumeratedValue : IIfcSimpleProperty, IIfcProperty, IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	IItemSet<IIfcValue> EnumerationValues { get; }

	IIfcPropertyEnumeration EnumerationReference { get; set; }
}
