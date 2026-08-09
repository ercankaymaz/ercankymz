using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTessellatedFaceSet : IIfcTessellatedItem, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcBooleanOperand, IIfcBooleanOperand
{
	IIfcCartesianPointList3D Coordinates { get; set; }

	IEnumerable<IIfcIndexedColourMap> HasColours { get; }

	IEnumerable<IIfcIndexedTextureMap> HasTextures { get; }
}
