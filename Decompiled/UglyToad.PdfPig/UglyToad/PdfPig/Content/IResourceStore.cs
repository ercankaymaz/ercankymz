using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UglyToad.PdfPig.Graphics.Colors;
using UglyToad.PdfPig.PdfFonts;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Content;

public interface IResourceStore
{
	void LoadResourceDictionary(DictionaryToken resourceDictionary);

	void UnloadResourceDictionary();

	IFont? GetFont(NameToken name);

	bool TryGetXObject(NameToken name, [NotNullWhen(true)] out StreamToken? stream);

	DictionaryToken? GetExtendedGraphicsStateDictionary(NameToken name);

	IFont GetFontDirectly(IndirectReferenceToken fontReferenceToken);

	bool TryGetNamedColorSpace(NameToken name, out ResourceColorSpace namedColorSpace);

	ColorSpaceDetails GetColorSpaceDetails(NameToken? name, DictionaryToken? dictionary);

	DictionaryToken? GetMarkedContentPropertiesDictionary(NameToken name);

	IReadOnlyDictionary<NameToken, PatternColor> GetPatterns();

	Shading GetShading(NameToken name);
}
