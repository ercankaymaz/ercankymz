using System.Collections.Generic;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Content;

public sealed class PageTreeMembers
{
	public MediaBox MediaBox { get; internal set; }

	public int Rotation { get; internal set; }

	public Queue<DictionaryToken> ParentResources { get; } = new Queue<DictionaryToken>();

	internal CropBox GetCropBox()
	{
		return null;
	}
}
