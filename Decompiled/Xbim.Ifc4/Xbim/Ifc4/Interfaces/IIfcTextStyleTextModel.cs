using Xbim.Common;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTextStyleTextModel : IIfcPresentationItem, IPersistEntity, IPersist
{
	IIfcSizeSelect TextIndent { get; set; }

	IfcTextAlignment? TextAlign { get; set; }

	IfcTextDecoration? TextDecoration { get; set; }

	IIfcSizeSelect LetterSpacing { get; set; }

	IIfcSizeSelect WordSpacing { get; set; }

	IfcTextTransformation? TextTransform { get; set; }

	IIfcSizeSelect LineHeight { get; set; }
}
