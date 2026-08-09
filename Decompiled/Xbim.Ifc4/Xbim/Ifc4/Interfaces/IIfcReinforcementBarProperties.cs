using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcReinforcementBarProperties : IIfcPreDefinedProperties, IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	IfcAreaMeasure TotalCrossSectionArea { get; set; }

	IfcLabel SteelGrade { get; set; }

	IfcReinforcingBarSurfaceEnum? BarSurface { get; set; }

	IfcLengthMeasure? EffectiveDepth { get; set; }

	IfcPositiveLengthMeasure? NominalBarDiameter { get; set; }

	IfcCountMeasure? BarCount { get; set; }
}
