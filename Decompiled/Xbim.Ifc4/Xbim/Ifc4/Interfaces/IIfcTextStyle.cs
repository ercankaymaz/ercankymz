using Xbim.Common;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTextStyle : IIfcPresentationStyle, IPersistEntity, IPersist, IfcStyleAssignmentSelect, IIfcStyleAssignmentSelect, IExpressSelectType, IfcPresentationStyleSelect, IIfcPresentationStyleSelect
{
	IIfcTextStyleForDefinedFont TextCharacterAppearance { get; set; }

	IIfcTextStyleTextModel TextStyle { get; set; }

	IIfcTextFontSelect TextFontStyle { get; set; }

	IfcBoolean? ModelOrDraughting { get; set; }
}
