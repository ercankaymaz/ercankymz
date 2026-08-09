using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Annotations;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Content;

public class Hyperlink
{
	public PdfRectangle Bounds { get; }

	public string Text { get; }

	public IReadOnlyList<Letter> Letters { get; }

	public string Uri { get; set; }

	public Annotation Annotation { get; }

	public Hyperlink(PdfRectangle bounds, IReadOnlyList<Letter> letters, string text, string uri, Annotation annotation)
	{
		Bounds = bounds;
		Text = text ?? string.Empty;
		Letters = letters ?? throw new ArgumentNullException("letters");
		Uri = uri ?? string.Empty;
		Annotation = annotation ?? throw new ArgumentNullException("annotation");
	}

	public override string ToString()
	{
		return "Link: " + Text + " (" + Uri + ")";
	}
}
