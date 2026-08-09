using Xbim.Common;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcMappedItem : IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	IIfcRepresentationMap MappingSource { get; set; }

	IIfcCartesianTransformationOperator MappingTarget { get; set; }
}
