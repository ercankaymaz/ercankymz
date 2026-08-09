using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Actions;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Annotations;

public class Annotation
{
	internal readonly AppearanceStream? normalAppearanceStream;

	internal readonly AppearanceStream? rollOverAppearanceStream;

	internal readonly AppearanceStream? downAppearanceStream;

	internal readonly string? appearanceState;

	public DictionaryToken AnnotationDictionary { get; }

	public AnnotationType Type { get; }

	public PdfRectangle Rectangle { get; }

	public string? Content { get; }

	public string? Name { get; }

	public string? ModifiedDate { get; }

	public AnnotationFlags Flags { get; }

	public AnnotationBorder Border { get; }

	public IReadOnlyList<QuadPointsQuadrilateral> QuadPoints { get; }

	public PdfAction? Action { get; }

	public bool HasNormalAppearance => normalAppearanceStream != null;

	public bool HasRollOverAppearance => rollOverAppearanceStream != null;

	public bool HasDownAppearance => downAppearanceStream != null;

	public Annotation? InReplyTo { get; }

	public Annotation(DictionaryToken annotationDictionary, AnnotationType type, PdfRectangle rectangle, string? content, string? name, string? modifiedDate, AnnotationFlags flags, AnnotationBorder border, IReadOnlyList<QuadPointsQuadrilateral> quadPoints, PdfAction? action, AppearanceStream? normalAppearanceStream, AppearanceStream? rollOverAppearanceStream, AppearanceStream? downAppearanceStream, string? appearanceState, Annotation? inReplyTo)
	{
		AnnotationDictionary = annotationDictionary ?? throw new ArgumentNullException("annotationDictionary");
		Type = type;
		Rectangle = rectangle;
		Content = content;
		Name = name;
		ModifiedDate = modifiedDate;
		Flags = flags;
		Border = border;
		QuadPoints = quadPoints ?? Array.Empty<QuadPointsQuadrilateral>();
		Action = action;
		this.normalAppearanceStream = normalAppearanceStream;
		this.rollOverAppearanceStream = rollOverAppearanceStream;
		this.downAppearanceStream = downAppearanceStream;
		this.appearanceState = appearanceState;
		InReplyTo = inReplyTo;
	}

	public override string ToString()
	{
		return $"{Type} - {Content}";
	}
}
