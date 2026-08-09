using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Geometry;
using UglyToad.PdfPig.Graphics.Colors;
using UglyToad.PdfPig.Graphics.Core;
using UglyToad.PdfPig.Graphics.Operations;
using UglyToad.PdfPig.Graphics.Operations.TextPositioning;
using UglyToad.PdfPig.Parser;
using UglyToad.PdfPig.PdfFonts;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.XObjects;

namespace UglyToad.PdfPig.Graphics;

public abstract class BaseStreamProcessor<TPageContent> : IOperationContext
{
	protected readonly IResourceStore ResourceStore;

	protected readonly UserSpaceUnit UserSpaceUnit;

	protected readonly PageRotationDegrees Rotation;

	protected readonly IPdfTokenScanner PdfScanner;

	protected readonly IPageContentParser PageContentParser;

	protected readonly ILookupFilterProvider FilterProvider;

	protected readonly ParsingOptions ParsingOptions;

	protected Stack<CurrentGraphicsState> GraphicsStack = new Stack<CurrentGraphicsState>();

	protected IFont? ActiveExtendedGraphicsStateFont;

	protected InlineImageBuilder? InlineImageBuilder;

	protected int PageNumber;

	protected int TextSequence;

	private readonly Dictionary<XObjectType, List<XObjectContentRecord>> xObjects = new Dictionary<XObjectType, List<XObjectContentRecord>>
	{
		{
			XObjectType.Image,
			new List<XObjectContentRecord>()
		},
		{
			XObjectType.PostScript,
			new List<XObjectContentRecord>()
		}
	};

	public TextMatrices TextMatrices { get; } = new TextMatrices();

	public TransformationMatrix CurrentTransformationMatrix => GetCurrentState().CurrentTransformationMatrix;

	public PdfPoint CurrentPosition { get; set; }

	public int StackSize => GraphicsStack.Count;

	protected BaseStreamProcessor(int pageNumber, IResourceStore resourceStore, IPdfTokenScanner pdfScanner, IPageContentParser pageContentParser, ILookupFilterProvider filterProvider, CropBox cropBox, UserSpaceUnit userSpaceUnit, PageRotationDegrees rotation, in TransformationMatrix initialMatrix, ParsingOptions parsingOptions)
	{
		PageNumber = pageNumber;
		ResourceStore = resourceStore;
		UserSpaceUnit = userSpaceUnit;
		Rotation = rotation;
		PdfScanner = pdfScanner ?? throw new ArgumentNullException("pdfScanner");
		PageContentParser = pageContentParser ?? throw new ArgumentNullException("pageContentParser");
		FilterProvider = filterProvider ?? throw new ArgumentNullException("filterProvider");
		ParsingOptions = parsingOptions;
		GraphicsStack.Push(new CurrentGraphicsState
		{
			CurrentTransformationMatrix = initialMatrix,
			CurrentClippingPath = GetInitialClipping(cropBox),
			ColorSpaceContext = new ColorSpaceContext(GetCurrentState, resourceStore)
		});
	}

	protected static PdfPath GetInitialClipping(CropBox cropBox)
	{
		PdfPath pdfPath = cropBox.Bounds.ToPdfPath();
		pdfPath.SetClipping(FillingRule.EvenOdd);
		return pdfPath;
	}

	public abstract TPageContent Process(int pageNumberCurrent, IReadOnlyList<IGraphicsStateOperation> operations);

	protected void ProcessOperations(IReadOnlyList<IGraphicsStateOperation> operations)
	{
		foreach (IGraphicsStateOperation operation in operations)
		{
			operation.Run(this);
		}
	}

	protected Stack<CurrentGraphicsState> CloneAllStates()
	{
		Stack<CurrentGraphicsState> graphicsStack = GraphicsStack;
		GraphicsStack = new Stack<CurrentGraphicsState>();
		GraphicsStack.Push(graphicsStack.Peek().DeepClone());
		return graphicsStack;
	}

	[DebuggerStepThrough]
	public CurrentGraphicsState GetCurrentState()
	{
		return GraphicsStack.Peek();
	}

	public virtual void PopState()
	{
		if (StackSize > 1)
		{
			GraphicsStack.Pop();
		}
		else
		{
			ParsingOptions.Logger.Error("Cannot execute a pop of the graphics state stack, it would leave the stack empty.");
			if (!ParsingOptions.UseLenientParsing)
			{
				throw new InvalidOperationException("Cannot execute a pop of the graphics state stack, it would leave the stack empty.");
			}
		}
		ActiveExtendedGraphicsStateFont = null;
	}

	public virtual void PushState()
	{
		GraphicsStack.Push(GraphicsStack.Peek().DeepClone());
	}

	public void ShowText(IInputBytes bytes)
	{
		CurrentGraphicsState currentState = GetCurrentState();
		IFont font = (currentState.FontState.FromExtendedGraphicsState ? ActiveExtendedGraphicsStateFont : ResourceStore.GetFont(currentState.FontState.FontName));
		if (font == null)
		{
			if (ParsingOptions.SkipMissingFonts)
			{
				ParsingOptions.Logger.Warn($"Skipping a missing font with name {currentState.FontState.FontName} " + "since it is not present in the document and SkipMissingFonts is set to true. This may result in some text being skipped and not included in the output.");
				return;
			}
			throw new InvalidOperationException($"Could not find the font with name {currentState.FontState.FontName} in the resource store. It has not been loaded yet.");
		}
		double fontSize = currentState.FontState.FontSize;
		double num = currentState.FontState.HorizontalScaling / 100.0;
		double characterSpacing = currentState.FontState.CharacterSpacing;
		double rise = currentState.FontState.Rise;
		TransformationMatrix transformationMatrix = currentState.CurrentTransformationMatrix;
		TransformationMatrix renderingMatrix = TransformationMatrix.FromValues(fontSize * num, 0.0, 0.0, fontSize, 0.0, rise);
		double pointSize = Math.Round(transformationMatrix.Multiply(TextMatrices.TextMatrix).Transform(new PdfRectangle(0.0, 0.0, 1.0, fontSize)).Height, 2);
		while (bytes.MoveNext())
		{
			int codeLength;
			int num2 = font.ReadCharacterCode(bytes, out codeLength);
			if (!font.TryGetUnicode(num2, out string value) || value == null)
			{
				ParsingOptions.Logger.Warn($"We could not find the corresponding character with code {num2} in font {font.Name}.");
				value = new string((char)num2, 1);
			}
			double num3 = 0.0;
			if (num2 == 32 && codeLength == 1)
			{
				num3 += GetCurrentState().FontState.WordSpacing;
			}
			TransformationMatrix textMatrix = TextMatrices.TextMatrix;
			if (font.IsVertical)
			{
				PdfVector positionVector = ((font as IVerticalWritingSupported) ?? throw new InvalidOperationException(string.Format("Font {0} was in vertical writing mode but did not implement {1}.", font.Name, "IVerticalWritingSupported"))).GetPositionVector(num2);
				textMatrix = textMatrix.Translate(positionVector.X, positionVector.Y);
			}
			CharacterBoundingBox boundingBox = font.GetBoundingBox(num2);
			RenderGlyph(font, currentState, fontSize, pointSize, num2, value, bytes.CurrentOffset, in renderingMatrix, in textMatrix, in transformationMatrix, boundingBox);
			double x;
			double y;
			if (font.IsVertical)
			{
				PdfVector displacementVector = ((IVerticalWritingSupported)font).GetDisplacementVector(num2);
				x = 0.0;
				y = displacementVector.Y * fontSize + characterSpacing + num3;
			}
			else
			{
				x = (boundingBox.Width * fontSize + characterSpacing + num3) * num;
				y = 0.0;
			}
			TextMatrices.TextMatrix = TextMatrices.TextMatrix.Translate(x, y);
		}
	}

	public abstract void RenderGlyph(IFont font, CurrentGraphicsState currentState, double fontSize, double pointSize, int code, string unicode, long currentOffset, in TransformationMatrix renderingMatrix, in TransformationMatrix textMatrix, in TransformationMatrix transformationMatrix, CharacterBoundingBox characterBoundingBox);

	public virtual void ShowPositionedText(IReadOnlyList<IToken> tokens)
	{
		TextSequence++;
		CurrentGraphicsState currentState = GetCurrentState();
		CurrentFontState fontState = currentState.FontState;
		double fontSize = fontState.FontSize;
		double num = fontState.HorizontalScaling / 100.0;
		IFont font = ResourceStore.GetFont(fontState.FontName);
		if (font == null)
		{
			if (ParsingOptions.SkipMissingFonts)
			{
				ParsingOptions.Logger.Warn($"Skipping a missing font with name {currentState.FontState.FontName} " + "since it is not present in the document and SkipMissingFonts is set to true. This may result in some text being skipped and not included in the output.");
				return;
			}
			throw new InvalidOperationException($"Could not find the font with name {currentState.FontState.FontName} in the resource store. It has not been loaded yet.");
		}
		bool isVertical = font.IsVertical;
		foreach (IToken token in tokens)
		{
			if (token is NumericToken { Data: var data })
			{
				double tx;
				double ty;
				if (isVertical)
				{
					tx = 0.0;
					ty = (0.0 - data) / 1000.0 * fontSize;
				}
				else
				{
					tx = (0.0 - data) / 1000.0 * fontSize * num;
					ty = 0.0;
				}
				AdjustTextMatrix(tx, ty);
			}
			else
			{
				byte[] array = ((!(token is HexToken { Bytes: var bytes })) ? ((StringToken)token).GetBytes() : bytes.ToArray());
				ShowText(new MemoryInputBytes(array));
			}
		}
	}

	public virtual void ApplyXObject(NameToken xObjectName)
	{
		if (!ResourceStore.TryGetXObject(xObjectName, out StreamToken stream))
		{
			if (!ParsingOptions.SkipMissingFonts)
			{
				throw new PdfDocumentFormatException($"No XObject with name {xObjectName} found on page {PageNumber}.");
			}
			return;
		}
		NameToken nameToken = (NameToken)stream.StreamDictionary.Data[NameToken.Subtype.Data];
		CurrentGraphicsState currentState = GetCurrentState();
		TransformationMatrix currentTransformationMatrix = currentState.CurrentTransformationMatrix;
		if (nameToken.Equals(NameToken.Ps))
		{
			XObjectContentRecord item = new XObjectContentRecord(XObjectType.PostScript, stream, currentTransformationMatrix, currentState.RenderingIntent, currentState.ColorSpaceContext?.CurrentStrokingColorSpace ?? DeviceRgbColorSpaceDetails.Instance);
			xObjects[XObjectType.PostScript].Add(item);
			return;
		}
		if (nameToken.Equals(NameToken.Image))
		{
			XObjectContentRecord xObjectContentRecord = new XObjectContentRecord(XObjectType.Image, stream, currentTransformationMatrix, currentState.RenderingIntent, currentState.ColorSpaceContext?.CurrentStrokingColorSpace ?? DeviceRgbColorSpaceDetails.Instance);
			RenderXObjectImage(xObjectContentRecord);
			return;
		}
		if (nameToken.Equals(NameToken.Form))
		{
			ProcessFormXObject(stream, xObjectName);
			return;
		}
		throw new InvalidOperationException($"XObject encountered with unexpected SubType {nameToken}. {stream.StreamDictionary}.");
	}

	protected abstract void RenderXObjectImage(XObjectContentRecord xObjectContentRecord);

	protected virtual void ProcessFormXObject(StreamToken formStream, NameToken xObjectName)
	{
		if (formStream.StreamDictionary.TryGet<DictionaryToken>(NameToken.Resources, PdfScanner, out DictionaryToken token))
		{
			ResourceStore.LoadResourceDictionary(token);
		}
		PushState();
		CurrentGraphicsState currentState = GetCurrentState();
		if (formStream.StreamDictionary.TryGet<DictionaryToken>(NameToken.Group, PdfScanner, out DictionaryToken token2))
		{
			if (!token2.TryGet<NameToken>(NameToken.S, PdfScanner, out NameToken token3) || token3 != NameToken.Transparency)
			{
				throw new InvalidOperationException($"Invalid Transparency Group XObject, '{NameToken.S}' token is not set or not equal to '{NameToken.Transparency}'.");
			}
			currentState.BlendMode = BlendMode.Normal;
			currentState.SoftMask = null;
			currentState.AlphaConstantNonStroking = 1.0;
			currentState.AlphaConstantStroking = 1.0;
			if (!token2.TryGet<NameToken>(NameToken.Cs, PdfScanner, out NameToken _) && token2.TryGet<ArrayToken>(NameToken.Cs, PdfScanner, out ArrayToken token5))
			{
				_ = token5.Length;
				_ = 0;
			}
			if (token2.TryGet<BooleanToken>(NameToken.I, PdfScanner, out BooleanToken token6))
			{
				_ = token6.Data;
			}
			if (token2.TryGet<BooleanToken>(NameToken.K, PdfScanner, out BooleanToken token7))
			{
				_ = token7.Data;
			}
		}
		TransformationMatrix value = TransformationMatrix.Identity;
		if (formStream.StreamDictionary.TryGet<ArrayToken>(NameToken.Matrix, PdfScanner, out ArrayToken token8))
		{
			value = TransformationMatrix.FromArray((from x in token8.Data.OfType<NumericToken>()
				select x.Double).ToArray());
		}
		ModifyCurrentTransformationMatrix(value);
		Memory<byte> memory = formStream.Decode(FilterProvider, PdfScanner);
		IReadOnlyList<IGraphicsStateOperation> readOnlyList = PageContentParser.Parse(PageNumber, new MemoryInputBytes(memory), ParsingOptions.Logger);
		if (formStream.StreamDictionary.TryGet<ArrayToken>(NameToken.Bbox, PdfScanner, out ArrayToken token9))
		{
			double[] array = (from x in token9.Data.OfType<NumericToken>()
				select x.Double).ToArray();
			PdfRectangle rectangle = new PdfRectangle(array[0], array[1], array[2], array[3]).Normalise();
			ClipToRectangle(rectangle, FillingRule.EvenOdd);
		}
		if (HasFormXObjectCircularReference(formStream, xObjectName, readOnlyList))
		{
			if (!ParsingOptions.UseLenientParsing)
			{
				throw new PdfDocumentFormatException($"An XObject form named '{xObjectName}' is referencing itself which can cause unexpected behaviour.");
			}
			readOnlyList = readOnlyList.Where((IGraphicsStateOperation o) => !(o is InvokeNamedXObject invokeNamedXObject) || invokeNamedXObject.Name != xObjectName).ToArray();
			ParsingOptions.Logger.Warn($"An XObject form named '{xObjectName}' is referencing itself which can cause unexpected behaviour. The self reference was removed from the operations before further processing.");
		}
		ProcessOperations(readOnlyList);
		PopState();
		if (token != null)
		{
			ResourceStore.UnloadResourceDictionary();
		}
	}

	protected virtual bool HasFormXObjectCircularReference(StreamToken formStream, NameToken xObjectName, IReadOnlyList<IGraphicsStateOperation> operations)
	{
		if (xObjectName != null)
		{
			IEnumerable<InvokeNamedXObject> enumerable = operations.OfType<InvokeNamedXObject>();
			if (enumerable != null && enumerable.Any((InvokeNamedXObject o) => o.Name == xObjectName) && ResourceStore.TryGetXObject(xObjectName, out StreamToken stream))
			{
				Memory<byte> data = stream.Data;
				Span<byte> span = data.Span;
				data = formStream.Data;
				return span.SequenceEqual(data.Span);
			}
		}
		return false;
	}

	public abstract void BeginSubpath();

	public abstract PdfPoint? CloseSubpath();

	public abstract void StrokePath(bool close);

	public abstract void FillPath(FillingRule fillingRule, bool close);

	public abstract void FillStrokePath(FillingRule fillingRule, bool close);

	public abstract void MoveTo(double x, double y);

	public abstract void BezierCurveTo(double x2, double y2, double x3, double y3);

	public abstract void BezierCurveTo(double x1, double y1, double x2, double y2, double x3, double y3);

	public abstract void LineTo(double x, double y);

	public abstract void Rectangle(double x, double y, double width, double height);

	public abstract void EndPath();

	public abstract void ClosePath();

	public abstract void ModifyClippingIntersect(FillingRule clippingRule);

	protected abstract void ClipToRectangle(PdfRectangle rectangle, FillingRule clippingRule);

	public virtual void SetNamedGraphicsState(NameToken stateName)
	{
		CurrentGraphicsState currentState = GetCurrentState();
		DictionaryToken extendedGraphicsStateDictionary = ResourceStore.GetExtendedGraphicsStateDictionary(stateName);
		if (extendedGraphicsStateDictionary == null)
		{
			return;
		}
		if (extendedGraphicsStateDictionary.TryGet<NumericToken>(NameToken.Lw, PdfScanner, out NumericToken token))
		{
			currentState.LineWidth = token.Data;
		}
		if (extendedGraphicsStateDictionary.TryGet<NumericToken>(NameToken.Lc, PdfScanner, out NumericToken token2))
		{
			currentState.CapStyle = (LineCapStyle)token2.Int;
		}
		if (extendedGraphicsStateDictionary.TryGet<NumericToken>(NameToken.Lj, PdfScanner, out NumericToken token3))
		{
			currentState.JoinStyle = (LineJoinStyle)token3.Int;
		}
		if (extendedGraphicsStateDictionary.TryGet<ArrayToken>(NameToken.Font, PdfScanner, out ArrayToken token4) && token4.Length == 2 && token4.Data[0] is IndirectReferenceToken fontReferenceToken && token4.Data[1] is NumericToken numericToken)
		{
			currentState.FontState.FromExtendedGraphicsState = true;
			currentState.FontState.FontSize = numericToken.Data;
			ActiveExtendedGraphicsStateFont = ResourceStore.GetFontDirectly(fontReferenceToken);
		}
		if (extendedGraphicsStateDictionary.TryGet<BooleanToken>(NameToken.Ais, PdfScanner, out BooleanToken token5))
		{
			currentState.AlphaSource = token5.Data;
		}
		if (extendedGraphicsStateDictionary.TryGet<NumericToken>(NameToken.Ca, PdfScanner, out NumericToken token6))
		{
			currentState.AlphaConstantStroking = token6.Data;
		}
		if (extendedGraphicsStateDictionary.TryGet<NumericToken>(NameToken.CaNs, PdfScanner, out NumericToken token7))
		{
			currentState.AlphaConstantNonStroking = token7.Data;
		}
		if (extendedGraphicsStateDictionary.TryGet<BooleanToken>(NameToken.Op, PdfScanner, out BooleanToken token8))
		{
			currentState.Overprint = token8.Data;
		}
		if (extendedGraphicsStateDictionary.TryGet<BooleanToken>(NameToken.OpNs, PdfScanner, out BooleanToken token9))
		{
			currentState.NonStrokingOverprint = token9.Data;
		}
		if (extendedGraphicsStateDictionary.TryGet<NumericToken>(NameToken.Opm, PdfScanner, out NumericToken token10))
		{
			currentState.OverprintMode = token10.Data;
		}
		if (extendedGraphicsStateDictionary.TryGet<BooleanToken>(NameToken.Sa, PdfScanner, out BooleanToken token11))
		{
			currentState.StrokeAdjustment = token11.Data;
		}
		ArrayToken token13;
		if (extendedGraphicsStateDictionary.TryGet<NameToken>(NameToken.Bm, PdfScanner, out NameToken token12))
		{
			currentState.BlendMode = token12.Data.ToBlendMode().GetValueOrDefault();
		}
		else if (extendedGraphicsStateDictionary.TryGet<ArrayToken>(NameToken.Bm, PdfScanner, out token13))
		{
			currentState.BlendMode = BlendMode.Normal;
			foreach (NameToken item in token13.Data.OfType<NameToken>())
			{
				BlendMode? blendMode = item.Data.ToBlendMode();
				if (blendMode.HasValue)
				{
					currentState.BlendMode = blendMode.Value;
					break;
				}
			}
		}
		DictionaryToken token15;
		if (extendedGraphicsStateDictionary.TryGet<NameToken>(NameToken.Smask, PdfScanner, out NameToken token14) && token14.Equals(NameToken.None))
		{
			currentState.SoftMask = null;
		}
		else if (extendedGraphicsStateDictionary.TryGet<DictionaryToken>(NameToken.Smask, PdfScanner, out token15))
		{
			currentState.SoftMask = SoftMask.Parse(token15, PdfScanner, FilterProvider);
		}
	}

	public virtual void BeginInlineImage()
	{
		if (InlineImageBuilder != null)
		{
			ParsingOptions.Logger.Error("Begin inline image (BI) command encountered while another inline image was active.");
		}
		InlineImageBuilder = new InlineImageBuilder();
	}

	public virtual void SetInlineImageProperties(IReadOnlyDictionary<NameToken, IToken> properties)
	{
		if (InlineImageBuilder == null)
		{
			ParsingOptions.Logger.Error("Begin inline image data (ID) command encountered without a corresponding begin inline image (BI) command.");
		}
		else
		{
			InlineImageBuilder.Properties = properties;
		}
	}

	public virtual void EndInlineImage(Memory<byte> bytes)
	{
		if (InlineImageBuilder == null)
		{
			ParsingOptions.Logger.Error("End inline image (EI) command encountered without a corresponding begin inline image (BI) command.");
			return;
		}
		InlineImageBuilder.Bytes = bytes;
		InlineImage inlineImage = InlineImageBuilder.CreateInlineImage(CurrentTransformationMatrix, FilterProvider, PdfScanner, GetCurrentState().RenderingIntent, ResourceStore);
		RenderInlineImage(inlineImage);
		InlineImageBuilder = null;
	}

	protected abstract void RenderInlineImage(InlineImage inlineImage);

	public abstract void BeginMarkedContent(NameToken name, NameToken? propertyDictionaryName, DictionaryToken? properties);

	public abstract void EndMarkedContent();

	private void AdjustTextMatrix(double tx, double ty)
	{
		TransformationMatrix translationMatrix = TransformationMatrix.GetTranslationMatrix(tx, ty);
		TextMatrices.TextMatrix = translationMatrix.Multiply(TextMatrices.TextMatrix);
	}

	public virtual void SetFlatnessTolerance(double tolerance)
	{
		GetCurrentState().Flatness = tolerance;
	}

	public virtual void SetLineCap(LineCapStyle cap)
	{
		GetCurrentState().CapStyle = cap;
	}

	public virtual void SetLineDashPattern(LineDashPattern pattern)
	{
		GetCurrentState().LineDashPattern = pattern;
	}

	public virtual void SetLineJoin(LineJoinStyle join)
	{
		GetCurrentState().JoinStyle = join;
	}

	public virtual void SetLineWidth(double width)
	{
		GetCurrentState().LineWidth = width;
	}

	public virtual void SetMiterLimit(double limit)
	{
		GetCurrentState().MiterLimit = limit;
	}

	public virtual void MoveToNextLineWithOffset()
	{
		new MoveToNextLineWithOffset(0.0, -1.0 * GetCurrentState().FontState.Leading).Run(this);
	}

	public virtual void SetFontAndSize(NameToken font, double size)
	{
		CurrentGraphicsState currentState = GetCurrentState();
		currentState.FontState.FontSize = size;
		currentState.FontState.FontName = font;
	}

	public virtual void SetHorizontalScaling(double scale)
	{
		GetCurrentState().FontState.HorizontalScaling = scale;
	}

	public virtual void SetTextLeading(double leading)
	{
		GetCurrentState().FontState.Leading = leading;
	}

	public virtual void SetTextRenderingMode(TextRenderingMode mode)
	{
		GetCurrentState().FontState.TextRenderingMode = mode;
	}

	public virtual void SetTextRise(double rise)
	{
		GetCurrentState().FontState.Rise = rise;
	}

	public virtual void SetWordSpacing(double spacing)
	{
		GetCurrentState().FontState.WordSpacing = spacing;
	}

	public virtual void ModifyCurrentTransformationMatrix(TransformationMatrix value)
	{
		CurrentGraphicsState currentState = GetCurrentState();
		currentState.CurrentTransformationMatrix = value.Multiply(currentState.CurrentTransformationMatrix);
	}

	public virtual void SetCharacterSpacing(double spacing)
	{
		GetCurrentState().FontState.CharacterSpacing = spacing;
	}

	public abstract void PaintShading(NameToken shadingName);
}
