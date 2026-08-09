using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationAppearanceResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcFillAreaStyleTiles : IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcFillStyleSelect, IIfcFillStyleSelect
{
	IEnumerable<IIfcVector> TilingPattern { get; }

	IEnumerable<IIfcStyledItem> Tiles { get; }

	IfcPositiveRatioMeasure TilingScale { get; set; }
}
