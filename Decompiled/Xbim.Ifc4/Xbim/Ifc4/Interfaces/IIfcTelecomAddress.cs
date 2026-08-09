using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTelecomAddress : IIfcAddress, IPersistEntity, IPersist, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IExpressSelectType
{
	IItemSet<IfcLabel> TelephoneNumbers { get; }

	IItemSet<IfcLabel> FacsimileNumbers { get; }

	IfcLabel? PagerNumber { get; set; }

	IItemSet<IfcLabel> ElectronicMailAddresses { get; }

	IfcURIReference? WWWHomePageURL { get; set; }

	IItemSet<IfcURIReference> MessagingIDs { get; }
}
