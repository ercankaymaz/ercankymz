using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Graphics;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Content;

public class ArtifactMarkedContentElement : MarkedContentElement
{
	public enum ArtifactType
	{
		Unknown,
		Pagination,
		Layout,
		Page,
		Background
	}

	public ArtifactType Type { get; }

	public string? SubType { get; }

	public string? AttributeOwners { get; }

	public PdfRectangle? BoundingBox { get; }

	public IReadOnlyList<NameToken> Attached { get; set; }

	public bool IsTopAttached => IsAttached(NameToken.Top);

	public bool IsBottomAttached => IsAttached(NameToken.Bottom);

	public bool IsLeftAttached => IsAttached(NameToken.Left);

	public bool IsRightAttached => IsAttached(NameToken.Right);

	internal ArtifactMarkedContentElement(int markedContentIdentifier, NameToken tag, DictionaryToken properties, string? language, string? actualText, string? alternateDescription, string? expandedForm, ArtifactType artifactType, string? subType, string? attributeOwners, PdfRectangle? boundingBox, IReadOnlyList<NameToken> attached, IReadOnlyList<MarkedContentElement> children, IReadOnlyList<Letter> letters, IReadOnlyList<PdfPath> paths, IReadOnlyList<IPdfImage> images, int index)
		: base(markedContentIdentifier, tag, properties, language, actualText, alternateDescription, expandedForm, isArtifact: true, children, letters, paths, images, index)
	{
		Type = artifactType;
		SubType = subType;
		AttributeOwners = attributeOwners;
		BoundingBox = boundingBox;
		Attached = attached ?? Array.Empty<NameToken>();
	}

	private bool IsAttached(NameToken edge)
	{
		foreach (NameToken item in Attached)
		{
			if (item == edge)
			{
				return true;
			}
		}
		return false;
	}
}
