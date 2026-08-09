using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcApplication : IPersistEntity, IPersist
{
	IIfcOrganization ApplicationDeveloper { get; set; }

	IfcLabel Version { get; set; }

	IfcLabel ApplicationFullName { get; set; }

	IfcIdentifier ApplicationIdentifier { get; set; }
}
