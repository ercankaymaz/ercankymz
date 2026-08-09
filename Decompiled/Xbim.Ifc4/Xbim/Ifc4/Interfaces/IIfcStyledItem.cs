using Xbim.Common;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcStyledItem : IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	IIfcRepresentationItem Item { get; set; }

	IItemSet<IIfcStyleAssignmentSelect> Styles { get; }

	IfcLabel? Name { get; set; }
}
