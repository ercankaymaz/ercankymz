using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcAlignment2DVertical : IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	IItemSet<IIfcAlignment2DVerticalSegment> Segments { get; }

	IEnumerable<IIfcAlignmentCurve> ToAlignmentCurve { get; }
}
