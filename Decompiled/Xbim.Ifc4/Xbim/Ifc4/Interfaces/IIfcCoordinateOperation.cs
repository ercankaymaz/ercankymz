using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcCoordinateOperation : IPersistEntity, IPersist
{
	IIfcCoordinateReferenceSystemSelect SourceCRS { get; set; }

	IIfcCoordinateReferenceSystem TargetCRS { get; set; }
}
