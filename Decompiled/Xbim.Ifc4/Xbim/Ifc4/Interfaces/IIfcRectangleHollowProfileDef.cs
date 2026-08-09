using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRectangleHollowProfileDef : IIfcRectangleProfileDef, IIfcParameterizedProfileDef, IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	IfcPositiveLengthMeasure WallThickness { get; set; }

	IfcNonNegativeLengthMeasure? InnerFilletRadius { get; set; }

	IfcNonNegativeLengthMeasure? OuterFilletRadius { get; set; }
}
