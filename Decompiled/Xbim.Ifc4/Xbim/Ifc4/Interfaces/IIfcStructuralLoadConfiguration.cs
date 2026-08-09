using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcStructuralLoadConfiguration : IIfcStructuralLoad, IPersistEntity, IPersist
{
	IItemSet<IIfcStructuralLoadOrResult> Values { get; }

	IItemSet<IItemSet<IfcLengthMeasure>> Locations { get; }
}
