using Xbim.Common;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTextStyleFontModel : IIfcPreDefinedTextFont, IIfcPreDefinedItem, IIfcPresentationItem, IPersistEntity, IPersist, IfcTextFontSelect, IIfcTextFontSelect, IExpressSelectType
{
	IItemSet<IfcTextFontName> FontFamily { get; }

	IfcFontStyle? FontStyle { get; set; }

	IfcFontVariant? FontVariant { get; set; }

	IfcFontWeight? FontWeight { get; set; }

	IIfcSizeSelect FontSize { get; set; }
}
