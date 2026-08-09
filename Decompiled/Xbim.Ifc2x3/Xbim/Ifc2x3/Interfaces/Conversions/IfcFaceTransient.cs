using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Ifc2x3.PresentationDefinitionResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.Interfaces.Conversions;

internal class IfcFaceTransient : PersistEntityTransient, IIfcFace, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	private readonly IItemSet<IIfcFaceBound> _faceBounds;

	private IIfcFaceBound _bound;

	public IItemSet<IIfcFaceBound> Bounds => _faceBounds;

	public IEnumerable<IIfcTextureMap> HasTextureMaps => Enumerable.Empty<IIfcTextureMap>();

	public IEnumerable<IIfcPresentationLayerAssignment> LayerAssignment => Enumerable.Empty<IIfcPresentationLayerAssignment>();

	public IEnumerable<IIfcStyledItem> StyledByItem => Enumerable.Empty<IIfcStyledItem>();

	public IfcFaceTransient(IfcVertexBasedTextureMap textureMap)
	{
		_bound = new IfcFaceBoundTransient(textureMap.TexturePoints);
		_faceBounds = new ExtendedSingleSet<IIfcFaceBound, IIfcFaceBound>(() => _bound, delegate(IIfcFaceBound transient)
		{
			_bound = transient;
		}, new ItemSet<IIfcFaceBound>(this, 0, 0), (IIfcFaceBound bound) => bound, (IIfcFaceBound bound) => bound);
	}
}
