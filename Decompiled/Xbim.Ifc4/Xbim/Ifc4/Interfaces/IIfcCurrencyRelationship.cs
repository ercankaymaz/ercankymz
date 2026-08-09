using Xbim.Common;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcCurrencyRelationship : IIfcResourceLevelRelationship, IPersistEntity, IPersist
{
	IIfcMonetaryUnit RelatingMonetaryUnit { get; set; }

	IIfcMonetaryUnit RelatedMonetaryUnit { get; set; }

	IfcPositiveRatioMeasure ExchangeRate { get; set; }

	IfcDateTime? RateDateTime { get; set; }

	IIfcLibraryInformation RateSource { get; set; }
}
