using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcPhysicalComplexQuantity : IIfcPhysicalQuantity, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	IItemSet<IIfcPhysicalQuantity> HasQuantities { get; }

	IfcLabel Discrimination { get; set; }

	IfcLabel? Quality { get; set; }

	IfcLabel? Usage { get; set; }
}
