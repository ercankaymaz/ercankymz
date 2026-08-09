using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UglyToad.PdfPig.Actions;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Graphics.Colors;
using UglyToad.PdfPig.Graphics.Operations;
using UglyToad.PdfPig.Graphics.Operations.General;
using UglyToad.PdfPig.Graphics.Operations.PathConstruction;
using UglyToad.PdfPig.Graphics.Operations.PathPainting;
using UglyToad.PdfPig.Graphics.Operations.SpecialGraphicsState;
using UglyToad.PdfPig.Graphics.Operations.TextObjects;
using UglyToad.PdfPig.Graphics.Operations.TextPositioning;
using UglyToad.PdfPig.Graphics.Operations.TextShowing;
using UglyToad.PdfPig.Graphics.Operations.TextState;
using UglyToad.PdfPig.Images;
using UglyToad.PdfPig.Images.Png;
using UglyToad.PdfPig.PdfFonts;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Writer.Fonts;

namespace UglyToad.PdfPig.Writer;

public class PdfPageBuilder
{
	public interface IContentStream
	{
		List<IGraphicsStateOperation> Operations { get; }
	}

	internal interface IPageContentStream : IContentStream
	{
		bool ReadOnly { get; }

		bool HasContent { get; }

		TransformationMatrix? GlobalTransform { get; }

		void Add(IGraphicsStateOperation operation);

		IndirectReferenceToken Write(IPdfStreamWriter writer);
	}

	internal class DefaultContentStream : IPageContentStream, IContentStream
	{
		private readonly List<IGraphicsStateOperation> operations;

		public bool ReadOnly => false;

		public bool HasContent => operations.Any();

		public TransformationMatrix? GlobalTransform => null;

		public List<IGraphicsStateOperation> Operations => operations;

		public DefaultContentStream()
			: this(new List<IGraphicsStateOperation>())
		{
		}

		public DefaultContentStream(List<IGraphicsStateOperation> operations)
		{
			this.operations = operations;
		}

		public void Add(IGraphicsStateOperation operation)
		{
			operations.Add(operation);
		}

		public IndirectReferenceToken Write(IPdfStreamWriter writer)
		{
			using MemoryStream memoryStream = new MemoryStream();
			foreach (IGraphicsStateOperation operation in operations)
			{
				operation.Write(memoryStream);
			}
			StreamToken token = DataCompresser.CompressToStream(memoryStream.ToArray());
			return writer.WriteToken(token);
		}
	}

	internal class CopiedContentStream : IPageContentStream, IContentStream
	{
		private readonly IndirectReferenceToken token;

		public bool ReadOnly => true;

		public bool HasContent => true;

		public TransformationMatrix? GlobalTransform { get; }

		public List<IGraphicsStateOperation> Operations
		{
			get
			{
				throw new NotSupportedException("Reading raw operations is not supported from a copied content stream.");
			}
		}

		public CopiedContentStream(IndirectReferenceToken indirectReferenceToken, TransformationMatrix? globalTransform)
		{
			GlobalTransform = globalTransform;
			token = indirectReferenceToken;
		}

		public IndirectReferenceToken Write(IPdfStreamWriter writer)
		{
			return token;
		}

		public void Add(IGraphicsStateOperation operation)
		{
			throw new NotSupportedException("Writing to a copied content stream is not supported.");
		}
	}

	public class AddedImage
	{
		internal Guid Id { get; }

		internal IndirectReference Reference { get; }

		public int Width { get; }

		public int Height { get; }

		internal AddedImage(IndirectReference reference, int width, int height)
		{
			Id = Guid.NewGuid();
			Reference = reference;
			Width = width;
			Height = height;
		}
	}

	private readonly PdfDocumentBuilder documentBuilder;

	internal readonly Dictionary<NameToken, IToken> pageDictionary = new Dictionary<NameToken, IToken>();

	internal readonly List<IPageContentStream> contentStreams;

	private IPageContentStream currentStream;

	internal readonly List<(DictionaryToken token, PdfAction action)>? links;

	private readonly Dictionary<Guid, NameToken> documentFonts = new Dictionary<Guid, NameToken>();

	internal int nextFontId = 1;

	private int textSequence;

	private NameConflictSolver xobjectsNames = new NameConflictSolver("I");

	private NameConflictSolver gStateNames = new NameConflictSolver("GS");

	internal int? rotation;

	internal IReadOnlyDictionary<string, IToken> Resources => pageDictionary.GetOrCreateDict(NameToken.Resources);

	public int PageNumber { get; }

	public PdfRectangle PageSize { get; set; }

	public IContentStream CurrentStream => currentStream;

	public IReadOnlyList<IContentStream> ContentStreams => contentStreams;

	internal PdfPageBuilder(int number, PdfDocumentBuilder documentBuilder)
	{
		this.documentBuilder = documentBuilder ?? throw new ArgumentNullException("documentBuilder");
		PageNumber = number;
		currentStream = new DefaultContentStream();
		contentStreams = new List<IPageContentStream> { currentStream };
	}

	internal PdfPageBuilder(int number, PdfDocumentBuilder documentBuilder, IEnumerable<CopiedContentStream> copied, Dictionary<NameToken, IToken> pageDict, List<(DictionaryToken token, PdfAction action)> links)
	{
		this.documentBuilder = documentBuilder ?? throw new ArgumentNullException("documentBuilder");
		this.links = links;
		PageNumber = number;
		pageDictionary = pageDict;
		contentStreams = new List<IPageContentStream>(copied);
		DefaultContentStream defaultContentStream = new DefaultContentStream();
		if (contentStreams.Count > 0)
		{
			IPageContentStream pageContentStream = contentStreams.LastOrDefault((IPageContentStream x) => x.GlobalTransform.HasValue);
			if (pageContentStream != null && pageContentStream.GlobalTransform.HasValue)
			{
				TransformationMatrix transformationMatrix = pageContentStream.GlobalTransform.Value.Inverse();
				defaultContentStream.Add(new ModifyCurrentTransformationMatrix(new double[6] { transformationMatrix.A, transformationMatrix.B, transformationMatrix.C, transformationMatrix.D, transformationMatrix.E, transformationMatrix.F }));
			}
		}
		currentStream = defaultContentStream;
		contentStreams.Add(currentStream);
	}

	public void NewContentStreamBefore()
	{
		int index = Math.Max(contentStreams.IndexOf(currentStream) - 1, 0);
		currentStream = new DefaultContentStream();
		contentStreams.Insert(index, currentStream);
	}

	public void NewContentStreamAfter()
	{
		int index = Math.Min(contentStreams.IndexOf(currentStream) + 1, contentStreams.Count);
		currentStream = new DefaultContentStream();
		contentStreams.Insert(index, currentStream);
	}

	public void SelectContentStream(int index)
	{
		if (index < 0 || index >= contentStreams.Count)
		{
			throw new IndexOutOfRangeException("index");
		}
		currentStream = contentStreams[index];
	}

	public PdfPageBuilder DrawLine(PdfPoint from, PdfPoint to, double lineWidth = 1.0)
	{
		if (lineWidth != 1.0)
		{
			currentStream.Add(new SetLineWidth(lineWidth));
		}
		currentStream.Add(new BeginNewSubpath(from.X, from.Y));
		currentStream.Add(new AppendStraightLineSegment(to.X, to.Y));
		currentStream.Add(StrokePath.Value);
		if (lineWidth != 1.0)
		{
			currentStream.Add(new SetLineWidth(1.0));
		}
		return this;
	}

	public PdfPageBuilder DrawRectangle(PdfPoint position, double width, double height, double lineWidth = 1.0, bool fill = false)
	{
		if (lineWidth != 1.0)
		{
			currentStream.Add(new SetLineWidth(lineWidth));
		}
		currentStream.Add(new AppendRectangle(position.X, position.Y, width, height));
		if (fill)
		{
			currentStream.Add(FillPathEvenOddRuleAndStroke.Value);
		}
		else
		{
			currentStream.Add(StrokePath.Value);
		}
		if (lineWidth != 1.0)
		{
			currentStream.Add(new SetLineWidth(lineWidth));
		}
		return this;
	}

	public PdfPageBuilder SetRotation(PageRotationDegrees degrees)
	{
		rotation = degrees.Value;
		return this;
	}

	public PdfPageBuilder DrawTriangle(PdfPoint point1, PdfPoint point2, PdfPoint point3, double lineWidth = 1.0, bool fill = false)
	{
		if (lineWidth != 1.0)
		{
			currentStream.Add(new SetLineWidth(lineWidth));
		}
		currentStream.Add(new BeginNewSubpath(point1.X, point1.Y));
		currentStream.Add(new AppendStraightLineSegment(point2.X, point2.Y));
		currentStream.Add(new AppendStraightLineSegment(point3.X, point3.Y));
		currentStream.Add(new AppendStraightLineSegment(point1.X, point1.Y));
		if (fill)
		{
			currentStream.Add(FillPathEvenOddRuleAndStroke.Value);
		}
		else
		{
			currentStream.Add(StrokePath.Value);
		}
		if (lineWidth != 1.0)
		{
			currentStream.Add(new SetLineWidth(lineWidth));
		}
		return this;
	}

	public PdfPageBuilder DrawCircle(PdfPoint center, double diameter, double lineWidth = 1.0, bool fill = false)
	{
		DrawEllipsis(center, diameter, diameter, lineWidth, fill);
		return this;
	}

	public PdfPageBuilder DrawEllipsis(PdfPoint center, double width, double height, double lineWidth = 1.0, bool fill = false)
	{
		width /= 2.0;
		height /= 2.0;
		if (lineWidth != 1.0)
		{
			currentStream.Add(new SetLineWidth(lineWidth));
		}
		currentStream.Add(new BeginNewSubpath(center.X - width, center.Y));
		currentStream.Add(new AppendDualControlPointBezierCurve(center.X - width, center.Y + height * 0.55228474983079, center.X - width * 0.55228474983079, center.Y + height, center.X, center.Y + height));
		currentStream.Add(new AppendDualControlPointBezierCurve(center.X + width * 0.55228474983079, center.Y + height, center.X + width, center.Y + height * 0.55228474983079, center.X + width, center.Y));
		currentStream.Add(new AppendDualControlPointBezierCurve(center.X + width, center.Y - height * 0.55228474983079, center.X + width * 0.55228474983079, center.Y - height, center.X, center.Y - height));
		currentStream.Add(new AppendDualControlPointBezierCurve(center.X - width * 0.55228474983079, center.Y - height, center.X - width, center.Y - height * 0.55228474983079, center.X - width, center.Y));
		if (fill)
		{
			currentStream.Add(FillPathEvenOddRuleAndStroke.Value);
		}
		else
		{
			currentStream.Add(StrokePath.Value);
		}
		if (lineWidth != 1.0)
		{
			currentStream.Add(new SetLineWidth(lineWidth));
		}
		return this;
	}

	public PdfPageBuilder SetStrokeColor(byte r, byte g, byte b)
	{
		currentStream.Add(Push.Value);
		currentStream.Add(new SetStrokeColorDeviceRgb(RgbToDouble(r), RgbToDouble(g), RgbToDouble(b)));
		return this;
	}

	internal PdfPageBuilder SetStrokeColorExact(double r, double g, double b)
	{
		currentStream.Add(Push.Value);
		currentStream.Add(new SetStrokeColorDeviceRgb(CheckRgbDouble(r, "r"), CheckRgbDouble(g, "g"), CheckRgbDouble(b, "b")));
		return this;
	}

	public PdfPageBuilder SetTextAndFillColor(byte r, byte g, byte b)
	{
		currentStream.Add(Push.Value);
		currentStream.Add(new SetNonStrokeColorDeviceRgb(RgbToDouble(r), RgbToDouble(g), RgbToDouble(b)));
		return this;
	}

	public PdfPageBuilder ResetColor()
	{
		currentStream.Add(Pop.Value);
		return this;
	}

	public IReadOnlyList<Letter> MeasureText(string text, double fontSize, PdfPoint position, PdfDocumentBuilder.AddedFont font)
	{
		if (font == null)
		{
			throw new ArgumentNullException("font");
		}
		if (text == null)
		{
			throw new ArgumentNullException("text");
		}
		if (!documentBuilder.Fonts.TryGetValue(font.Id, out PdfDocumentBuilder.FontStored value))
		{
			throw new ArgumentException($"No font has been added to the PdfDocumentBuilder with Id: {font.Id}. " + "Use AddTrueTypeFont to register a font.", "font");
		}
		if (fontSize <= 0.0)
		{
			throw new ArgumentOutOfRangeException("fontSize", "Font size must be greater than 0");
		}
		IWritingFont fontProgram = value.FontProgram;
		TransformationMatrix fontMatrix = fontProgram.GetFontMatrix();
		TransformationMatrix textMatrix = TransformationMatrix.FromValues(1.0, 0.0, 0.0, 1.0, position.X, position.Y);
		return DrawLetters(null, text, fontProgram, in fontMatrix, fontSize, textMatrix);
	}

	public IReadOnlyList<Letter> AddText(string text, double fontSize, PdfPoint position, PdfDocumentBuilder.AddedFont font)
	{
		if (font == null)
		{
			throw new ArgumentNullException("font");
		}
		if (text == null)
		{
			throw new ArgumentNullException("text");
		}
		if (!documentBuilder.Fonts.TryGetValue(font.Id, out PdfDocumentBuilder.FontStored value))
		{
			throw new ArgumentException($"No font has been added to the PdfDocumentBuilder with Id: {font.Id}. " + "Use AddTrueTypeFont to register a font.", "font");
		}
		if (fontSize <= 0.0)
		{
			throw new ArgumentOutOfRangeException("fontSize", "Font size must be greater than 0");
		}
		NameToken addedFont = GetAddedFont(font);
		IWritingFont fontProgram = value.FontProgram;
		TransformationMatrix fontMatrix = fontProgram.GetFontMatrix();
		TransformationMatrix textMatrix = TransformationMatrix.FromValues(1.0, 0.0, 0.0, 1.0, position.X, position.Y);
		List<Letter> result = DrawLetters(addedFont, text, fontProgram, in fontMatrix, fontSize, textMatrix);
		currentStream.Add(BeginText.Value);
		currentStream.Add(new SetFontAndSize(addedFont, fontSize));
		currentStream.Add(new MoveToNextLineWithOffset(position.X, position.Y));
		List<byte> list = new List<byte>();
		foreach (char c in text)
		{
			if (char.IsWhiteSpace(c))
			{
				currentStream.Add(new ShowText(list.ToArray()));
				list.Clear();
			}
			byte valueForCharacter = fontProgram.GetValueForCharacter(c);
			list.Add(valueForCharacter);
		}
		if (list.Count > 0)
		{
			currentStream.Add(new ShowText(list.ToArray()));
		}
		currentStream.Add(EndText.Value);
		return result;
	}

	public PdfPageBuilder SetTextRenderingMode(TextRenderingMode mode)
	{
		currentStream.Add(new SetTextRenderingMode(mode));
		return this;
	}

	private NameToken GetAddedFont(PdfDocumentBuilder.AddedFont font)
	{
		if (!documentFonts.TryGetValue(font.Id, out NameToken value))
		{
			value = NameToken.Create($"F{nextFontId++}");
			Dictionary<string, IToken> orCreateDict = pageDictionary.GetOrCreateDict(NameToken.Resources).GetOrCreateDict(NameToken.Font);
			while (orCreateDict.ContainsKey(value))
			{
				value = NameToken.Create($"F{nextFontId++}");
			}
			documentFonts[font.Id] = value;
			orCreateDict[value] = font.Reference;
		}
		return value;
	}

	public AddedImage AddJpeg(byte[] fileBytes, PdfRectangle placementRectangle)
	{
		using MemoryStream fileStream = new MemoryStream(fileBytes);
		return AddJpeg(fileStream, placementRectangle);
	}

	public AddedImage AddJpeg(Stream fileStream, PdfRectangle placementRectangle = default(PdfRectangle))
	{
		long position = fileStream.Position;
		JpegInformation information = JpegHandler.GetInformation(fileStream);
		if (placementRectangle.Equals(default(PdfRectangle)))
		{
			placementRectangle = new PdfRectangle(0.0, 0.0, information.Width, information.Height);
		}
		byte[] array;
		using (MemoryStream memoryStream = new MemoryStream())
		{
			fileStream.Seek(position, SeekOrigin.Begin);
			fileStream.CopyTo(memoryStream);
			array = memoryStream.ToArray();
		}
		NameToken value = ((information.NumberOfComponents == 1) ? NameToken.Devicegray : ((information.NumberOfComponents != 4) ? NameToken.Devicergb : NameToken.Devicecmyk));
		Dictionary<NameToken, IToken> data = new Dictionary<NameToken, IToken>
		{
			{
				NameToken.Type,
				NameToken.Xobject
			},
			{
				NameToken.Subtype,
				NameToken.Image
			},
			{
				NameToken.Width,
				new NumericToken(information.Width)
			},
			{
				NameToken.Height,
				new NumericToken(information.Height)
			},
			{
				NameToken.BitsPerComponent,
				new NumericToken(information.BitsPerComponent)
			},
			{
				NameToken.ColorSpace,
				value
			},
			{
				NameToken.Filter,
				NameToken.DctDecode
			},
			{
				NameToken.Length,
				new NumericToken(array.Length)
			}
		};
		IndirectReferenceToken indirectReferenceToken = documentBuilder.AddImage(new DictionaryToken(data), array);
		Dictionary<string, IToken> orCreateDict = pageDictionary.GetOrCreateDict(NameToken.Resources).GetOrCreateDict(NameToken.Xobject);
		NameToken nameToken = NameToken.Create(xobjectsNames.NewName());
		orCreateDict[nameToken] = indirectReferenceToken;
		currentStream.Add(Push.Value);
		currentStream.Add(new ModifyCurrentTransformationMatrix(new double[6]
		{
			placementRectangle.Width,
			0.0,
			0.0,
			placementRectangle.Height,
			placementRectangle.BottomLeft.X,
			placementRectangle.BottomLeft.Y
		}));
		currentStream.Add(new InvokeNamedXObject(nameToken));
		currentStream.Add(Pop.Value);
		return new AddedImage(indirectReferenceToken.Data, information.Width, information.Height);
	}

	public void AddJpeg(AddedImage image, PdfRectangle placementRectangle)
	{
		AddImage(image, placementRectangle);
	}

	public void AddImage(AddedImage image, PdfRectangle placementRectangle)
	{
		Dictionary<string, IToken> orCreateDict = pageDictionary.GetOrCreateDict(NameToken.Resources).GetOrCreateDict(NameToken.Xobject);
		NameToken nameToken = NameToken.Create(xobjectsNames.NewName());
		orCreateDict[nameToken] = new IndirectReferenceToken(image.Reference);
		currentStream.Add(Push.Value);
		currentStream.Add(new ModifyCurrentTransformationMatrix(new double[6]
		{
			placementRectangle.Width,
			0.0,
			0.0,
			placementRectangle.Height,
			placementRectangle.BottomLeft.X,
			placementRectangle.BottomLeft.Y
		}));
		currentStream.Add(new InvokeNamedXObject(nameToken));
		currentStream.Add(Pop.Value);
	}

	public AddedImage AddPng(byte[] pngBytes, PdfRectangle placementRectangle)
	{
		using MemoryStream pngStream = new MemoryStream(pngBytes);
		return AddPng(pngStream, placementRectangle);
	}

	public AddedImage AddPng(Stream pngStream, PdfRectangle placementRectangle = default(PdfRectangle))
	{
		Png png = Png.Open(pngStream);
		if (placementRectangle.Equals(default(PdfRectangle)))
		{
			placementRectangle = new PdfRectangle(0.0, 0.0, png.Width, png.Height);
		}
		byte[] array = new byte[png.Width * png.Height * 3];
		int num = 0;
		for (int i = 0; i < png.Height; i++)
		{
			for (int j = 0; j < png.Width; j++)
			{
				Pixel pixel = png.GetPixel(j, i);
				array[num++] = pixel.R;
				array[num++] = pixel.G;
				array[num++] = pixel.B;
			}
		}
		NumericToken value = new NumericToken(png.Width);
		NumericToken value2 = new NumericToken(png.Height);
		IndirectReferenceToken indirectReferenceToken = null;
		if (png.HasAlphaChannel && documentBuilder.ArchiveStandard != PdfAStandard.A1B && documentBuilder.ArchiveStandard != PdfAStandard.A1A)
		{
			byte[] array2 = new byte[array.Length / 3];
			for (int k = 0; k < png.Height; k++)
			{
				for (int l = 0; l < png.Width; l++)
				{
					Pixel pixel2 = png.GetPixel(l, k);
					int num2 = k * png.Width + l;
					array2[num2] = pixel2.A;
				}
			}
			byte[] array3 = DataCompresser.CompressBytes(array2);
			Dictionary<NameToken, IToken> dictionary = new Dictionary<NameToken, IToken>();
			dictionary.Add(NameToken.Type, NameToken.Xobject);
			dictionary.Add(NameToken.Subtype, NameToken.Image);
			dictionary.Add(NameToken.Width, value);
			dictionary.Add(NameToken.Height, value2);
			dictionary.Add(NameToken.ColorSpace, NameToken.Devicegray);
			dictionary.Add(NameToken.BitsPerComponent, new NumericToken(8));
			dictionary.Add(NameToken.Decode, new ArrayToken(new IToken[2]
			{
				new NumericToken(0),
				new NumericToken(1)
			}));
			dictionary.Add(NameToken.Length, new NumericToken(array3.Length));
			dictionary.Add(NameToken.Filter, NameToken.FlateDecode);
			Dictionary<NameToken, IToken> data = dictionary;
			indirectReferenceToken = documentBuilder.AddImage(new DictionaryToken(data), array3);
		}
		byte[] array4 = DataCompresser.CompressBytes(array);
		Dictionary<NameToken, IToken> dictionary2 = new Dictionary<NameToken, IToken>
		{
			{
				NameToken.Type,
				NameToken.Xobject
			},
			{
				NameToken.Subtype,
				NameToken.Image
			},
			{
				NameToken.Width,
				value
			},
			{
				NameToken.Height,
				value2
			},
			{
				NameToken.BitsPerComponent,
				new NumericToken(8)
			},
			{
				NameToken.ColorSpace,
				NameToken.Devicergb
			},
			{
				NameToken.Filter,
				NameToken.FlateDecode
			},
			{
				NameToken.Length,
				new NumericToken(array4.Length)
			}
		};
		if (indirectReferenceToken != null)
		{
			dictionary2.Add(NameToken.Smask, indirectReferenceToken);
		}
		IndirectReferenceToken indirectReferenceToken2 = documentBuilder.AddImage(new DictionaryToken(dictionary2), array4);
		Dictionary<string, IToken> orCreateDict = pageDictionary.GetOrCreateDict(NameToken.Resources).GetOrCreateDict(NameToken.Xobject);
		NameToken nameToken = NameToken.Create(xobjectsNames.NewName());
		orCreateDict[nameToken] = indirectReferenceToken2;
		currentStream.Add(Push.Value);
		currentStream.Add(new ModifyCurrentTransformationMatrix(new double[6]
		{
			placementRectangle.Width,
			0.0,
			0.0,
			placementRectangle.Height,
			placementRectangle.BottomLeft.X,
			placementRectangle.BottomLeft.Y
		}));
		currentStream.Add(new InvokeNamedXObject(nameToken));
		currentStream.Add(Pop.Value);
		return new AddedImage(indirectReferenceToken2.Data, png.Width, png.Height);
	}

	public PdfPageBuilder CopyFrom(Page srcPage)
	{
		if (currentStream.Operations.Count > 0)
		{
			NewContentStreamAfter();
		}
		IPageContentStream pageContentStream = currentStream;
		if (!srcPage.Dictionary.TryGet<DictionaryToken>(NameToken.Resources, srcPage.pdfScanner, out DictionaryToken token))
		{
			pageContentStream.Operations.AddRange(srcPage.Operations);
			return this;
		}
		List<IGraphicsStateOperation> list = new List<IGraphicsStateOperation>(srcPage.Operations);
		Dictionary<string, IToken> orCreateDict = pageDictionary.GetOrCreateDict(NameToken.Resources, srcPage.pdfScanner);
		foreach (KeyValuePair<string, IToken> datum in token.Data)
		{
			NameToken nameToken = NameToken.Create(datum.Key);
			if (!(nameToken == NameToken.Font) && !(nameToken == NameToken.Xobject) && !orCreateDict.ContainsKey(nameToken))
			{
				orCreateDict[nameToken] = documentBuilder.CopyToken(srcPage.pdfScanner, datum.Value);
			}
		}
		if (token.TryGet<DictionaryToken>(NameToken.Font, srcPage.pdfScanner, out DictionaryToken token2))
		{
			Dictionary<string, IToken> orCreateDict2 = orCreateDict.GetOrCreateDict(NameToken.Font, srcPage.pdfScanner);
			foreach (KeyValuePair<string, IToken> datum2 in token2.Data)
			{
				NameToken fontName = NameToken.Create(datum2.Key);
				if (orCreateDict2.ContainsKey(fontName))
				{
					NameToken newName = NameToken.Create($"F{nextFontId++}");
					while (orCreateDict2.ContainsKey(newName))
					{
						newName = NameToken.Create($"F{nextFontId++}");
					}
					list = list.Select(delegate(IGraphicsStateOperation op)
					{
						if (!(op is SetFontAndSize setFontAndSize))
						{
							return op;
						}
						return (setFontAndSize.Font.Data == fontName) ? new SetFontAndSize(newName, setFontAndSize.Size) : op;
					}).ToList();
					fontName = newName;
				}
				if (!(datum2.Value is IndirectReferenceToken token3))
				{
					throw new PdfDocumentFormatException("Expected a IndirectReferenceToken for the font, got a " + datum2.Value.GetType().Name);
				}
				orCreateDict2.Add(fontName, documentBuilder.CopyToken(srcPage.pdfScanner, token3));
			}
		}
		if (token.TryGet<DictionaryToken>(NameToken.Xobject, srcPage.pdfScanner, out DictionaryToken token4))
		{
			Dictionary<string, IToken> orCreateDict3 = orCreateDict.GetOrCreateDict(NameToken.Xobject, srcPage.pdfScanner);
			foreach (KeyValuePair<string, IToken> datum3 in token4.Data)
			{
				string xobjectName = datum3.Key;
				string newName2 = xobjectsNames.FixName(xobjectName);
				if (xobjectName != newName2)
				{
					list = list.Select(delegate(IGraphicsStateOperation op)
					{
						if (!(op is InvokeNamedXObject invokeNamedXObject))
						{
							return op;
						}
						return (invokeNamedXObject.Name.Data == xobjectName) ? new InvokeNamedXObject(NameToken.Create(newName2)) : op;
					}).ToList();
				}
				xobjectName = newName2;
				if (!(datum3.Value is IndirectReferenceToken token5))
				{
					throw new PdfDocumentFormatException("Expected a IndirectReferenceToken for the XObject, got a " + datum3.Value.GetType().Name);
				}
				orCreateDict3[xobjectName] = documentBuilder.CopyToken(srcPage.pdfScanner, token5);
			}
		}
		if (token.TryGet<DictionaryToken>(NameToken.ExtGState, srcPage.pdfScanner, out DictionaryToken token6))
		{
			Dictionary<string, IToken> orCreateDict4 = orCreateDict.GetOrCreateDict(NameToken.ExtGState, srcPage.pdfScanner);
			foreach (KeyValuePair<string, IToken> datum4 in token6.Data)
			{
				string gstateName = datum4.Key;
				string newName3 = gStateNames.FixName(gstateName);
				if (newName3 != gstateName)
				{
					list = list.Select(delegate(IGraphicsStateOperation op)
					{
						if (!(op is SetGraphicsStateParametersFromDictionary setGraphicsStateParametersFromDictionary))
						{
							return op;
						}
						return (setGraphicsStateParametersFromDictionary.Name.Data == gstateName) ? new SetGraphicsStateParametersFromDictionary(NameToken.Create(newName3)) : op;
					}).ToList();
					gstateName = newName3;
				}
				if (datum4.Value is IndirectReferenceToken token7)
				{
					orCreateDict4[gstateName] = documentBuilder.CopyToken(srcPage.pdfScanner, token7);
				}
				else
				{
					orCreateDict4[gstateName] = documentBuilder.CopyToken(srcPage.pdfScanner, datum4.Value);
				}
			}
		}
		TransformationMatrix? globalTransform = PdfContentTransformationReader.GetGlobalTransform(list);
		if (globalTransform.HasValue)
		{
			TransformationMatrix transformationMatrix = globalTransform.Value.Inverse();
			list.Add(new ModifyCurrentTransformationMatrix(new double[6] { transformationMatrix.A, transformationMatrix.B, transformationMatrix.C, transformationMatrix.D, transformationMatrix.E, transformationMatrix.F }));
		}
		pageContentStream.Operations.AddRange(list);
		return this;
	}

	private List<Letter> DrawLetters(NameToken? name, string text, IWritingFont font, in TransformationMatrix fontMatrix, double fontSize, TransformationMatrix textMatrix)
	{
		int num = 1;
		int num2 = 0;
		List<Letter> list = new List<Letter>();
		TransformationMatrix transformationMatrix = TransformationMatrix.FromValues(fontSize * (double)num, 0.0, 0.0, fontSize, 0.0, num2);
		double num3 = 0.0;
		textSequence++;
		for (int i = 0; i < text.Length; i++)
		{
			char c = text[i];
			if (!font.TryGetBoundingBox(c, out var boundingBox))
			{
				throw new InvalidOperationException($"The font does not contain a character: '{c}' (0x{(int)c:X}).");
			}
			if (!font.TryGetAdvanceWidth(c, out var width))
			{
				throw new InvalidOperationException($"The font does not contain a character: {c}.");
			}
			PdfRectangle original = new PdfRectangle(0.0, 0.0, width, 0.0);
			original = textMatrix.Transform(transformationMatrix.Transform(fontMatrix.Transform(original)));
			PdfRectangle pdfRectangle = textMatrix.Transform(transformationMatrix.Transform(fontMatrix.Transform(boundingBox)));
			Letter item = new Letter(c.ToString(), pdfRectangle, pdfRectangle, original.BottomLeft, original.BottomRight, num3, fontSize, FontDetails.GetDefault(name), TextRenderingMode.Fill, GrayColor.Black, GrayColor.Black, fontSize, textSequence);
			list.Add(item);
			double num4 = original.Width * (double)num;
			int num5 = 0;
			TransformationMatrix translationMatrix = TransformationMatrix.GetTranslationMatrix(num4, num5);
			num3 += num4;
			textMatrix = translationMatrix.Multiply(in textMatrix);
		}
		return list;
	}

	private static double RgbToDouble(byte value)
	{
		double val = Math.Max(0.0, (double)(int)value / 255.0);
		return Math.Round(Math.Min(1.0, val), 4);
	}

	private static double CheckRgbDouble(double value, string argument)
	{
		if (value < 0.0)
		{
			throw new ArgumentOutOfRangeException(argument, $"Provided double for RGB color was less than zero: {value}.");
		}
		if (value > 1.0)
		{
			throw new ArgumentOutOfRangeException(argument, $"Provided double for RGB color was greater than one: {value}.");
		}
		return value;
	}
}
