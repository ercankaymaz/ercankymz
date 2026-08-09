using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcSite : IIfcSpatialStructureElement, IIfcSpatialElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	IfcCompoundPlaneAngleMeasure? RefLatitude { get; set; }

	IfcCompoundPlaneAngleMeasure? RefLongitude { get; set; }

	IfcLengthMeasure? RefElevation { get; set; }

	IfcLabel? LandTitleNumber { get; set; }

	IIfcPostalAddress SiteAddress { get; set; }

	IEnumerable<IIfcBuilding> Buildings { get; }
}
