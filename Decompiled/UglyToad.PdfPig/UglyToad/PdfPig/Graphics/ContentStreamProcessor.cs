using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Geometry;
using UglyToad.PdfPig.Graphics.Operations;
using UglyToad.PdfPig.Parser;
using UglyToad.PdfPig.PdfFonts;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Graphics;

internal class ContentStreamProcessor : BaseStreamProcessor<PageContent>
{
	private readonly List<Letter> letters = new List<Letter>();

	private readonly List<PdfPath> paths = new List<PdfPath>();

	private readonly List<Union<XObjectContentRecord, InlineImage>> images = new List<Union<XObjectContentRecord, InlineImage>>();

	private readonly List<MarkedContentElement> markedContents = new List<MarkedContentElement>();

	private readonly MarkedContentStack markedContentStack = new MarkedContentStack();

	public PdfSubpath CurrentSubpath { get; private set; }

	public PdfPath CurrentPath { get; private set; }

	public ContentStreamProcessor(int pageNumber, IResourceStore resourceStore, IPdfTokenScanner pdfScanner, IPageContentParser pageContentParser, ILookupFilterProvider filterProvider, CropBox cropBox, UserSpaceUnit userSpaceUnit, PageRotationDegrees rotation, TransformationMatrix initialMatrix, ParsingOptions parsingOptions)
		: base(pageNumber, resourceStore, pdfScanner, pageContentParser, filterProvider, cropBox, userSpaceUnit, rotation, in initialMatrix, parsingOptions)
	{
	}

	public override PageContent Process(int pageNumberCurrent, IReadOnlyList<IGraphicsStateOperation> operations)
	{
		PageNumber = pageNumberCurrent;
		CloneAllStates();
		ProcessOperations(operations);
		return new PageContent(operations, letters, paths, images, markedContents, PdfScanner, FilterProvider, ResourceStore);
	}

	public override void RenderGlyph(IFont font, CurrentGraphicsState currentState, double fontSize, double pointSize, int code, string unicode, long currentOffset, in TransformationMatrix renderingMatrix, in TransformationMatrix textMatrix, in TransformationMatrix transformationMatrix, CharacterBoundingBox characterBoundingBox)
	{
		PdfRectangle pdfRectangle = PerformantRectangleTransformer.Transform(in renderingMatrix, in textMatrix, in transformationMatrix, characterBoundingBox.GlyphBounds);
		if (ParsingOptions.ClipPaths)
		{
			PdfPath currentClippingPath = currentState.CurrentClippingPath;
			if (currentClippingPath != null && !currentClippingPath.IntersectsWith(pdfRectangle))
			{
				return;
			}
		}
		Letter letter = null;
		if (Diacritics.IsInCombiningDiacriticRange(unicode) && currentOffset > 0 && letters.Count > 0)
		{
			Letter letter2 = letters[letters.Count - 1];
			if (letter2.TextSequence == TextSequence && Diacritics.TryCombineDiacriticWithPreviousLetter(unicode, letter2.Value, out string result))
			{
				letters.Remove(letter2);
				letter = new Letter(result, letter2.GlyphRectangle, letter2.GlyphRectangleLoose, letter2.StartBaseLine, letter2.EndBaseLine, letter2.Width, letter2.FontSize, letter2.GetFont(), letter2.RenderingMode, letter2.StrokeColor, letter2.FillColor, letter2.PointSize, letter2.TextSequence);
			}
		}
		bool flag = pdfRectangle.Width > double.Epsilon || pdfRectangle.Height > double.Epsilon;
		if (letter == null)
		{
			PdfRectangle pdfRectangle2 = PerformantRectangleTransformer.Transform(in renderingMatrix, in textMatrix, in transformationMatrix, new PdfRectangle(0.0, 0.0, characterBoundingBox.Width, UserSpaceUnit.PointMultiples));
			PdfRectangle glyphRectangleLoose = PerformantRectangleTransformer.Transform(in renderingMatrix, in textMatrix, in transformationMatrix, new PdfRectangle(0.0, font.GetDescent(), characterBoundingBox.Width, font.GetAscent()));
			letter = new Letter(unicode, flag ? pdfRectangle : pdfRectangle2, glyphRectangleLoose, pdfRectangle2.BottomLeft, pdfRectangle2.BottomRight, pdfRectangle2.Width, fontSize, font, currentState.FontState.TextRenderingMode, currentState.CurrentStrokingColor, currentState.CurrentNonStrokingColor, pointSize, TextSequence);
		}
		letters.Add(letter);
		markedContentStack.AddLetter(letter);
	}

	protected override void RenderXObjectImage(XObjectContentRecord xObjectContentRecord)
	{
		images.Add(Union<XObjectContentRecord, InlineImage>.One(xObjectContentRecord));
		markedContentStack.AddXObject(xObjectContentRecord, PdfScanner, FilterProvider, ResourceStore);
	}

	public override void BeginSubpath()
	{
		if (CurrentPath == null)
		{
			CurrentPath = new PdfPath();
		}
		AddCurrentSubpath();
		CurrentSubpath = new PdfSubpath();
	}

	public override PdfPoint? CloseSubpath()
	{
		if (CurrentSubpath == null)
		{
			return null;
		}
		if (!(CurrentSubpath.Commands[0] is PdfSubpath.Move { Location: var location }))
		{
			throw new ArgumentException("CloseSubpath(): first command not Move.");
		}
		CurrentSubpath.CloseSubpath();
		AddCurrentSubpath();
		return location;
	}

	private void AddCurrentSubpath()
	{
		if (CurrentSubpath != null)
		{
			CurrentPath.Add(CurrentSubpath);
			CurrentSubpath = null;
		}
	}

	public override void StrokePath(bool close)
	{
		if (CurrentPath != null)
		{
			CurrentPath.SetStroked();
			if (close)
			{
				CurrentSubpath?.CloseSubpath();
			}
			ClosePath();
		}
	}

	public override void FillPath(FillingRule fillingRule, bool close)
	{
		if (CurrentPath != null)
		{
			CurrentPath.SetFilled(fillingRule);
			if (close)
			{
				CurrentSubpath?.CloseSubpath();
			}
			ClosePath();
		}
	}

	public override void FillStrokePath(FillingRule fillingRule, bool close)
	{
		if (CurrentPath != null)
		{
			CurrentPath.SetFilled(fillingRule);
			CurrentPath.SetStroked();
			if (close)
			{
				CurrentSubpath?.CloseSubpath();
			}
			ClosePath();
		}
	}

	public override void MoveTo(double x, double y)
	{
		BeginSubpath();
		PdfPoint pdfPoint = (base.CurrentPosition = base.CurrentTransformationMatrix.Transform(new PdfPoint(x, y)));
		CurrentSubpath.MoveTo(pdfPoint.X, pdfPoint.Y);
	}

	public override void BezierCurveTo(double x2, double y2, double x3, double y3)
	{
		if (CurrentSubpath != null)
		{
			PdfPoint pdfPoint = base.CurrentTransformationMatrix.Transform(new PdfPoint(x2, y2));
			PdfPoint currentPosition = base.CurrentTransformationMatrix.Transform(new PdfPoint(x3, y3));
			CurrentSubpath.BezierCurveTo(base.CurrentPosition.X, base.CurrentPosition.Y, pdfPoint.X, pdfPoint.Y, currentPosition.X, currentPosition.Y);
			base.CurrentPosition = currentPosition;
		}
	}

	public override void BezierCurveTo(double x1, double y1, double x2, double y2, double x3, double y3)
	{
		if (CurrentSubpath != null)
		{
			PdfPoint pdfPoint = base.CurrentTransformationMatrix.Transform(new PdfPoint(x1, y1));
			PdfPoint pdfPoint2 = base.CurrentTransformationMatrix.Transform(new PdfPoint(x2, y2));
			PdfPoint currentPosition = base.CurrentTransformationMatrix.Transform(new PdfPoint(x3, y3));
			CurrentSubpath.BezierCurveTo(pdfPoint.X, pdfPoint.Y, pdfPoint2.X, pdfPoint2.Y, currentPosition.X, currentPosition.Y);
			base.CurrentPosition = currentPosition;
		}
	}

	public override void LineTo(double x, double y)
	{
		if (CurrentSubpath != null)
		{
			PdfPoint currentPosition = base.CurrentTransformationMatrix.Transform(new PdfPoint(x, y));
			CurrentSubpath.LineTo(currentPosition.X, currentPosition.Y);
			base.CurrentPosition = currentPosition;
		}
	}

	public override void Rectangle(double x, double y, double width, double height)
	{
		BeginSubpath();
		PdfPoint pdfPoint = base.CurrentTransformationMatrix.Transform(new PdfPoint(x, y));
		PdfPoint pdfPoint2 = base.CurrentTransformationMatrix.Transform(new PdfPoint(x + width, y + height));
		CurrentSubpath.Rectangle(pdfPoint.X, pdfPoint.Y, pdfPoint2.X - pdfPoint.X, pdfPoint2.Y - pdfPoint.Y);
		AddCurrentSubpath();
	}

	public override void EndPath()
	{
		if (CurrentPath == null)
		{
			return;
		}
		AddCurrentSubpath();
		if (CurrentPath.IsClipping)
		{
			if (!ParsingOptions.ClipPaths)
			{
				paths.Add(CurrentPath);
				markedContentStack.AddPath(CurrentPath);
			}
			CurrentPath = null;
		}
		else
		{
			paths.Add(CurrentPath);
			markedContentStack.AddPath(CurrentPath);
			CurrentPath = null;
		}
	}

	public override void ClosePath()
	{
		AddCurrentSubpath();
		if (CurrentPath.IsClipping)
		{
			EndPath();
			return;
		}
		CurrentGraphicsState currentState = GetCurrentState();
		if (CurrentPath.IsStroked)
		{
			CurrentPath.SetStrokeDetails(currentState);
		}
		if (CurrentPath.IsFilled)
		{
			CurrentPath.SetFillDetails(currentState);
		}
		if (ParsingOptions.ClipPaths)
		{
			PdfPath pdfPath = currentState.CurrentClippingPath.Clip(CurrentPath, ParsingOptions.Logger);
			if (pdfPath != null)
			{
				paths.Add(pdfPath);
				markedContentStack.AddPath(pdfPath);
			}
		}
		else
		{
			paths.Add(CurrentPath);
			markedContentStack.AddPath(CurrentPath);
		}
		CurrentPath = null;
	}

	public override void ModifyClippingIntersect(FillingRule clippingRule)
	{
		if (CurrentPath == null)
		{
			return;
		}
		AddCurrentSubpath();
		CurrentPath.SetClipping(clippingRule);
		if (ParsingOptions.ClipPaths)
		{
			CurrentGraphicsState currentState = GetCurrentState();
			PdfPath currentClippingPath = currentState.CurrentClippingPath;
			currentClippingPath.SetClipping(clippingRule);
			PdfPath pdfPath = CurrentPath.Clip(currentClippingPath, ParsingOptions.Logger);
			if (pdfPath == null)
			{
				ParsingOptions.Logger.Warn("Empty clipping path found. Clipping path not updated.");
			}
			else
			{
				currentState.CurrentClippingPath = pdfPath;
			}
		}
	}

	protected override void ClipToRectangle(PdfRectangle rectangle, FillingRule clippingRule)
	{
		CurrentGraphicsState currentState = GetCurrentState();
		rectangle = currentState.CurrentTransformationMatrix.Transform(rectangle).Normalise();
		PdfPath pdfPath = rectangle.ToPdfPath();
		pdfPath.SetClipping(clippingRule);
		PdfPath currentClippingPath = currentState.CurrentClippingPath;
		currentClippingPath.SetClipping(clippingRule);
		PdfPath pdfPath2 = pdfPath.Clip(currentClippingPath, ParsingOptions.Logger);
		if (pdfPath2 == null)
		{
			ParsingOptions.Logger.Warn("Empty clipping path found. Clipping path not updated.");
		}
		else
		{
			currentState.CurrentClippingPath = pdfPath2;
		}
	}

	protected override void RenderInlineImage(InlineImage inlineImage)
	{
		images.Add(Union<XObjectContentRecord, InlineImage>.Two(inlineImage));
		markedContentStack.AddImage(inlineImage);
	}

	public override void BeginMarkedContent(NameToken name, NameToken propertyDictionaryName, DictionaryToken properties)
	{
		if (propertyDictionaryName != null)
		{
			properties = ResourceStore.GetMarkedContentPropertiesDictionary(propertyDictionaryName) ?? properties;
		}
		markedContentStack.Push(name, properties);
	}

	public override void EndMarkedContent()
	{
		if (markedContentStack.CanPop)
		{
			MarkedContentElement markedContentElement = markedContentStack.Pop(PdfScanner);
			if (markedContentElement != null)
			{
				markedContents.Add(markedContentElement);
			}
		}
	}

	public override void PaintShading(NameToken shadingName)
	{
	}
}
