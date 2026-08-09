using Xbim.Common;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcCartesianPointList3D : IIfcCartesianPointList, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	IItemSet<IItemSet<IfcLengthMeasure>> CoordList { get; }

	IItemSet<IfcLabel> TagList { get; }
}
