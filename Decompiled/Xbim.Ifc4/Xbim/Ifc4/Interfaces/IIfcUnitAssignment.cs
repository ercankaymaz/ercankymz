using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcUnitAssignment : IPersistEntity, IPersist
{
	IItemSet<IIfcUnit> Units { get; }
}
