using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcLibraryInformation : IIfcExternalInformation, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IfcLibrarySelect, IIfcLibrarySelect
{
	IfcLabel Name { get; set; }

	IfcLabel? Version { get; set; }

	IIfcActorSelect Publisher { get; set; }

	IfcDateTime? VersionDate { get; set; }

	IfcURIReference? Location { get; set; }

	IfcText? Description { get; set; }

	IEnumerable<IIfcRelAssociatesLibrary> LibraryInfoForObjects { get; }

	IEnumerable<IIfcLibraryReference> HasLibraryReferences { get; }
}
