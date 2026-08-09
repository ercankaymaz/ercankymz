using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.XObjects;

namespace UglyToad.PdfPig.Graphics;

internal class MarkedContentStack
{
	private class MarkedContentElementActiveBuilder
	{
		private readonly int number;

		private readonly NameToken name;

		private readonly DictionaryToken properties;

		private readonly List<Letter> letters = new List<Letter>();

		private readonly List<PdfPath> paths = new List<PdfPath>();

		private readonly List<IPdfImage> images = new List<IPdfImage>();

		public List<MarkedContentElement> Children { get; } = new List<MarkedContentElement>();

		public MarkedContentElementActiveBuilder(int number, NameToken name, DictionaryToken properties)
		{
			this.number = number;
			this.name = name;
			this.properties = properties ?? new DictionaryToken(new Dictionary<NameToken, IToken>());
		}

		public void AddLetter(Letter letter)
		{
			letters.Add(letter);
		}

		public void AddImage(IPdfImage image)
		{
			images.Add(image);
		}

		public void AddPath(PdfPath path)
		{
			paths.Add(path);
		}

		public MarkedContentElement Build(IPdfTokenScanner pdfScanner)
		{
			int markedContentIdentifier = -1;
			if (properties.TryGet<NumericToken>(NameToken.Mcid, pdfScanner, out NumericToken token))
			{
				markedContentIdentifier = token.Int;
			}
			string optional = GetOptional(NameToken.Lang, pdfScanner);
			string optional2 = GetOptional(NameToken.ActualText, pdfScanner);
			string optional3 = GetOptional(NameToken.Alternate, pdfScanner);
			string optional4 = GetOptional(NameToken.E, pdfScanner);
			if (name != NameToken.Artifact)
			{
				return new MarkedContentElement(markedContentIdentifier, name, properties, optional, optional2, optional3, optional4, isArtifact: false, Children, letters, paths, images, number);
			}
			ArtifactMarkedContentElement.ArtifactType artifactType = ArtifactMarkedContentElement.ArtifactType.Unknown;
			if (properties.TryGet<IDataToken<string>>(NameToken.Type, pdfScanner, out IDataToken<string> token2) && Enum.TryParse<ArtifactMarkedContentElement.ArtifactType>(token2.Data, ignoreCase: true, out var result))
			{
				artifactType = result;
			}
			string optional5 = GetOptional(NameToken.Subtype, pdfScanner);
			string optional6 = GetOptional(NameToken.O, pdfScanner);
			PdfRectangle? boundingBox = null;
			if (properties.TryGet<ArrayToken>(NameToken.Bbox, pdfScanner, out ArrayToken token3))
			{
				NumericToken numericToken = null;
				NumericToken numericToken2 = null;
				NumericToken numericToken3 = null;
				NumericToken numericToken4 = null;
				if (token3.Length == 4)
				{
					numericToken = token3[0] as NumericToken;
					numericToken2 = token3[1] as NumericToken;
					numericToken3 = token3[2] as NumericToken;
					numericToken4 = token3[3] as NumericToken;
				}
				else if (token3.Length == 6)
				{
					numericToken = token3[2] as NumericToken;
					numericToken2 = token3[3] as NumericToken;
					numericToken3 = token3[4] as NumericToken;
					numericToken4 = token3[5] as NumericToken;
				}
				if (numericToken != null && numericToken2 != null && numericToken3 != null && numericToken4 != null)
				{
					boundingBox = new PdfRectangle(numericToken.Double, numericToken2.Double, numericToken3.Double, numericToken4.Double);
				}
			}
			List<NameToken> list = new List<NameToken>();
			if (properties.TryGet(NameToken.Attached, out ArrayToken token4))
			{
				foreach (IToken datum in token4.Data)
				{
					if (datum is NameToken item)
					{
						list.Add(item);
					}
				}
			}
			return new ArtifactMarkedContentElement(markedContentIdentifier, name, properties, optional, optional2, optional3, optional4, artifactType, optional5, optional6, boundingBox, list, Children, letters, paths, images, number);
		}

		private string? GetOptional(NameToken optionName, IPdfTokenScanner pdfScanner)
		{
			string result = null;
			if (properties.TryGet<IDataToken<string>>(optionName, pdfScanner, out IDataToken<string> token))
			{
				result = token.Data;
			}
			return result;
		}
	}

	private readonly Stack<MarkedContentElementActiveBuilder> builderStack = new Stack<MarkedContentElementActiveBuilder>();

	private int number = -1;

	private MarkedContentElementActiveBuilder? top;

	public bool CanPop => top != null;

	public void Push(NameToken name, DictionaryToken properties)
	{
		if (builderStack.Count == 0)
		{
			number++;
		}
		top = new MarkedContentElementActiveBuilder(number, name, properties);
		builderStack.Push(top);
	}

	public MarkedContentElement? Pop(IPdfTokenScanner pdfScanner)
	{
		MarkedContentElement markedContentElement = builderStack.Pop().Build(pdfScanner);
		if (builderStack.Count > 0)
		{
			top = builderStack.Peek();
			top.Children.Add(markedContentElement);
			return null;
		}
		top = null;
		return markedContentElement;
	}

	public void AddLetter(Letter letter)
	{
		top?.AddLetter(letter);
	}

	public void AddPath(PdfPath path)
	{
		top?.AddPath(path);
	}

	public void AddImage(IPdfImage image)
	{
		top?.AddImage(image);
	}

	public void AddXObject(XObjectContentRecord xObject, IPdfTokenScanner scanner, ILookupFilterProvider filterProvider, IResourceStore resourceStore)
	{
		if (top != null && xObject.Type == XObjectType.Image)
		{
			XObjectImage image = XObjectFactory.ReadImage(xObject, scanner, filterProvider, resourceStore);
			top?.AddImage(image);
		}
	}
}
