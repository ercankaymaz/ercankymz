using Xbim.Common;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcPostalAddress : IIfcAddress, IPersistEntity, IPersist, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IExpressSelectType
{
	IfcLabel? InternalLocation { get; set; }

	IItemSet<IfcLabel> AddressLines { get; }

	IfcLabel? PostalBox { get; set; }

	IfcLabel? Town { get; set; }

	IfcLabel? Region { get; set; }

	IfcLabel? PostalCode { get; set; }

	IfcLabel? Country { get; set; }
}
