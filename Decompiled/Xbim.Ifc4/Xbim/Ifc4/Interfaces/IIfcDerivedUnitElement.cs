using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcDerivedUnitElement : IPersistEntity, IPersist
{
	IIfcNamedUnit Unit { get; set; }

	long Exponent { get; set; }
}
