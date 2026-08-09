using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcUnit : IExpressSelectType, IPersist, IPersistEntity
{
	string FullName { get; }
}
