using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.Interfaces.Conversions;

internal class IfcPolyLoopTransient : PersistEntityTransient, IIfcPolyLoop, IIfcLoop, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	private readonly IItemSet<IIfcCartesianPoint> _points;

	public IItemSet<IIfcCartesianPoint> Polygon => _points;

	public IEnumerable<IIfcPresentationLayerAssignment> LayerAssignment => Enumerable.Empty<IIfcPresentationLayerAssignment>();

	public IEnumerable<IIfcStyledItem> StyledByItem => Enumerable.Empty<IIfcStyledItem>();

	public IfcPolyLoopTransient(IEnumerable<IfcCartesianPoint> points)
	{
		ItemSet<IIfcCartesianPoint> itemSet = new ItemSet<IIfcCartesianPoint>(this, 0, 0);
		foreach (IfcCartesianPoint point in points)
		{
			itemSet.InternalAdd(point);
		}
		_points = itemSet;
	}
}
