using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcMonetaryUnit : IPersistEntity, IPersist, IfcUnit, IIfcUnit, IExpressSelectType
{
	IfcLabel Currency { get; set; }
}
