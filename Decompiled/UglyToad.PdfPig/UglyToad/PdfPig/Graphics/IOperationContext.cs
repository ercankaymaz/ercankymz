using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Graphics.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Graphics;

public interface IOperationContext
{
	PdfPoint CurrentPosition { get; set; }

	TextMatrices TextMatrices { get; }

	int StackSize { get; }

	CurrentGraphicsState GetCurrentState();

	void PopState();

	void PushState();

	void ShowText(IInputBytes bytes);

	void ShowPositionedText(IReadOnlyList<IToken> tokens);

	void ApplyXObject(NameToken xObjectName);

	void BeginSubpath();

	PdfPoint? CloseSubpath();

	void StrokePath(bool close);

	void FillPath(FillingRule fillingRule, bool close);

	void FillStrokePath(FillingRule fillingRule, bool close);

	void MoveTo(double x, double y);

	void BezierCurveTo(double x1, double y1, double x2, double y2, double x3, double y3);

	void BezierCurveTo(double x2, double y2, double x3, double y3);

	void LineTo(double x, double y);

	void Rectangle(double x, double y, double width, double height);

	void EndPath();

	void ClosePath();

	void BeginMarkedContent(NameToken name, NameToken? propertyDictionaryName, DictionaryToken? properties);

	void EndMarkedContent();

	void SetNamedGraphicsState(NameToken stateName);

	void BeginInlineImage();

	void SetInlineImageProperties(IReadOnlyDictionary<NameToken, IToken> properties);

	void EndInlineImage(Memory<byte> bytes);

	void ModifyClippingIntersect(FillingRule clippingRule);

	void SetFlatnessTolerance(double tolerance);

	void SetLineCap(LineCapStyle cap);

	void SetLineDashPattern(LineDashPattern pattern);

	void SetLineJoin(LineJoinStyle join);

	void SetLineWidth(double width);

	void SetMiterLimit(double limit);

	void MoveToNextLineWithOffset();

	void SetFontAndSize(NameToken font, double size);

	void SetHorizontalScaling(double scale);

	void SetTextLeading(double leading);

	void SetTextRenderingMode(TextRenderingMode mode);

	void SetTextRise(double rise);

	void SetWordSpacing(double spacing);

	void ModifyCurrentTransformationMatrix(TransformationMatrix value);

	void SetCharacterSpacing(double spacing);

	void PaintShading(NameToken shading);
}
