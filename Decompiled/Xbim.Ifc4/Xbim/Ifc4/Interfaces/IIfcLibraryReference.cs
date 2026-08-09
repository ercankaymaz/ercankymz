using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcLibraryReference : IIfcExternalReference, IPersistEntity, IPersist, IfcLightDistributionDataSourceSelect, IIfcLightDistributionDataSourceSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IfcLibrarySelect, IIfcLibrarySelect
{
	IfcText? Description { get; set; }

	IfcLanguageId? Language { get; set; }

	IIfcLibraryInformation ReferencedLibrary { get; set; }

	IEnumerable<IIfcRelAssociatesLibrary> LibraryRefForObjects { get; }
}
