using UglyToad.PdfPig.Outline.Destinations;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Content;

public interface IPageFactory<out TPage>
{
	TPage Create(int number, DictionaryToken dictionary, PageTreeMembers pageTreeMembers, NamedDestinations namedDestinations);
}
