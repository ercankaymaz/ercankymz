using Xbim.Common;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcCartesianPointList : IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	IfcDimensionCount Dim { get; }
}
