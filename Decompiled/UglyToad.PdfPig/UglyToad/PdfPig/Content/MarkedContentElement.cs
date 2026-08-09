using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Graphics;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Content;

public class MarkedContentElement
{
	public int MarkedContentIdentifier { get; }

	public int Index { get; }

	public string Tag { get; }

	public DictionaryToken Properties { get; }

	public bool IsArtifact { get; }

	public IReadOnlyList<MarkedContentElement> Children { get; }

	public IReadOnlyList<Letter> Letters { get; }

	public IReadOnlyList<PdfPath> Paths { get; }

	public IReadOnlyList<IPdfImage> Images { get; }

	public string? Language { get; }

	public string? ActualText { get; }

	public string? AlternateDescription { get; }

	public string? ExpandedForm { get; }

	public MarkedContentElement(int markedContentIdentifier, NameToken tag, DictionaryToken properties, string? language, string? actualText, string? alternateDescription, string? expandedForm, bool isArtifact, IReadOnlyList<MarkedContentElement> children, IReadOnlyList<Letter> letters, IReadOnlyList<PdfPath> paths, IReadOnlyList<IPdfImage> images, int index)
	{
		MarkedContentIdentifier = markedContentIdentifier;
		Tag = tag;
		Language = language;
		ActualText = actualText;
		AlternateDescription = alternateDescription;
		ExpandedForm = expandedForm;
		Properties = properties ?? new DictionaryToken(new Dictionary<NameToken, IToken>());
		IsArtifact = isArtifact;
		Children = children ?? throw new ArgumentNullException("children");
		Letters = letters ?? throw new ArgumentNullException("letters");
		Paths = paths ?? throw new ArgumentNullException("paths");
		Images = images ?? throw new ArgumentNullException("images");
		Index = index;
	}

	public override string ToString()
	{
		return $"Id={Index}, MCID={MarkedContentIdentifier}, Tag={Tag}, Properties={Properties}, Children={Children.Count}";
	}
}
