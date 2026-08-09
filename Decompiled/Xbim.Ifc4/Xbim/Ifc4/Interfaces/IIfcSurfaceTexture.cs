using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcSurfaceTexture : IIfcPresentationItem, IPersistEntity, IPersist
{
	IfcBoolean RepeatS { get; set; }

	IfcBoolean RepeatT { get; set; }

	IfcIdentifier? Mode { get; set; }

	IIfcCartesianTransformationOperator2D TextureTransform { get; set; }

	IItemSet<IfcIdentifier> Parameter { get; }

	IEnumerable<IIfcTextureCoordinate> IsMappedBy { get; }

	IEnumerable<IIfcSurfaceStyleWithTextures> UsedInStyles { get; }
}
