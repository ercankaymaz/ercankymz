using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.Interfaces.Conversions;

internal class IfcFaceBoundTransient : PersistEntityTransient, IIfcFaceBound, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	private readonly IfcPolyLoopTransient _polyLoop;

	public IIfcLoop Bound
	{
		get
		{
			return _polyLoop;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public IfcBoolean Orientation
	{
		get
		{
			return true;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public IEnumerable<IIfcPresentationLayerAssignment> LayerAssignment => Enumerable.Empty<IIfcPresentationLayerAssignment>();

	public IEnumerable<IIfcStyledItem> StyledByItem => Enumerable.Empty<IIfcStyledItem>();

	public IfcFaceBoundTransient(IEnumerable<IfcCartesianPoint> points)
	{
		_polyLoop = new IfcPolyLoopTransient(points);
	}
}
