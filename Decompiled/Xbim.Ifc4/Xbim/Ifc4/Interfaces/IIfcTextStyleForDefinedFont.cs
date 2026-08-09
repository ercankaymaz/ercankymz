using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTextStyleForDefinedFont : IIfcPresentationItem, IPersistEntity, IPersist
{
	IIfcColour Colour { get; set; }

	IIfcColour BackgroundColour { get; set; }
}
