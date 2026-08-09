using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcSchedulingTime : IPersistEntity, IPersist
{
	IfcLabel? Name { get; set; }

	IfcDataOriginEnum? DataOrigin { get; set; }

	IfcLabel? UserDefinedDataOrigin { get; set; }
}
