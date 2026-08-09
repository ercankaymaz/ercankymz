using Xbim.Common;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcLightSourceGoniometric : IIfcLightSource, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	IIfcAxis2Placement3D Position { get; set; }

	IIfcColourRgb ColourAppearance { get; set; }

	IfcThermodynamicTemperatureMeasure ColourTemperature { get; set; }

	IfcLuminousFluxMeasure LuminousFlux { get; set; }

	IfcLightEmissionSourceEnum LightEmissionSource { get; set; }

	IIfcLightDistributionDataSourceSelect LightDistributionDataSource { get; set; }
}
