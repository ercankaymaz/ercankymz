using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Graphics;
using UglyToad.PdfPig.Graphics.Operations;
using UglyToad.PdfPig.Graphics.Operations.InlineImages;
using UglyToad.PdfPig.Graphics.Operations.TextObjects;
using UglyToad.PdfPig.Logging;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Parser;

public sealed class PageContentParser : IPageContentParser
{
	private readonly IGraphicsStateOperationFactory operationFactory;

	private readonly bool useLenientParsing;

	public PageContentParser(IGraphicsStateOperationFactory operationFactory, bool useLenientParsing = false)
	{
		this.operationFactory = operationFactory;
		this.useLenientParsing = useLenientParsing;
	}

	public IReadOnlyList<IGraphicsStateOperation> Parse(int pageNumber, IInputBytes inputBytes, ILog log)
	{
		CoreTokenScanner coreTokenScanner = new CoreTokenScanner(inputBytes, usePdfDocEncoding: false, ScannerScope.None, null, useLenientParsing);
		List<IToken> list = new List<IToken>();
		List<IGraphicsStateOperation> list2 = new List<IGraphicsStateOperation>();
		long? num = null;
		while (coreTokenScanner.MoveNext())
		{
			IToken currentToken = coreTokenScanner.CurrentToken;
			if (currentToken is InlineImageDataToken inlineImageDataToken)
			{
				Dictionary<NameToken, IToken> dictionary = new Dictionary<NameToken, IToken>();
				for (int i = 0; i < list.Count - 1; i++)
				{
					if (list[i] is NameToken key)
					{
						i++;
						dictionary[key] = list[i];
					}
				}
				list2.Add(new BeginInlineImageData(dictionary));
				list2.Add(new EndInlineImage(inlineImageDataToken.Data));
				num = coreTokenScanner.CurrentPosition - 2;
				list.Clear();
			}
			else if (currentToken is OperatorToken operatorToken)
			{
				Memory<byte> imageData;
				int num4;
				if (operatorToken.Data == "EI")
				{
					IGraphicsStateOperation graphicsStateOperation = ((list2.Count > 0) ? list2[list2.Count - 1] : null);
					if (!num.HasValue || graphicsStateOperation == null || !(graphicsStateOperation is EndInlineImage endInlineImage))
					{
						throw new PdfDocumentFormatException("Encountered End Image token outside an inline image on " + $"page {pageNumber} at offset in content: {coreTokenScanner.CurrentPosition}.");
					}
					long num2 = coreTokenScanner.CurrentPosition - 3;
					log.Warn($"End inline image (EI) encountered after previous EI, attempting recovery at {num2}.");
					int num3 = (int)(num2 - num).Value;
					long currentOffset = inputBytes.CurrentOffset;
					inputBytes.Seek(num.Value);
					byte[] array = new byte[num3];
					if (inputBytes.Read(array) != num3)
					{
						throw new InvalidOperationException($"Failed to read expected buffer length {num3} on page {pageNumber} " + $"when reading inline image at offset in content: {num.Value}.");
					}
					list2.Remove(endInlineImage);
					imageData = endInlineImage.ImageData;
					Span<byte> span = imageData.Span;
					Span<byte> span2 = array.AsSpan();
					num4 = 0;
					byte[] array2 = new byte[span.Length + span2.Length];
					span.CopyTo(new Span<byte>(array2).Slice(num4, span.Length));
					num4 += span.Length;
					span2.CopyTo(new Span<byte>(array2).Slice(num4, span2.Length));
					num4 += span2.Length;
					list2.Add(new EndInlineImage(array2));
					num = num2;
					inputBytes.Seek(currentOffset);
				}
				else
				{
					IGraphicsStateOperation graphicsStateOperation2;
					try
					{
						graphicsStateOperation2 = operationFactory.Create(operatorToken, list);
					}
					catch (Exception ex)
					{
						log.Error($"Failed reading operation at offset {inputBytes.CurrentOffset} for page {pageNumber}, data: '{operatorToken.Data}'", ex);
						if (!TryGetLastEndImage(list2, out EndInlineImage _, out num4) && !useLenientParsing)
						{
							throw;
						}
						graphicsStateOperation2 = null;
					}
					if (graphicsStateOperation2 != null)
					{
						list2.Add(graphicsStateOperation2);
					}
					else if (list2.Count > 0)
					{
						if (TryGetLastEndImage(list2, out EndInlineImage endImage2, out int index) && num.HasValue)
						{
							log.Warn($"Operator {operatorToken.Data} was not understood following end of inline image data at {num}, " + "attempting recovery.");
							IReadOnlyList<byte> readOnlyList = coreTokenScanner.RecoverFromIncorrectEndImage(num.Value);
							list2.RemoveRange(index, list2.Count - index);
							imageData = endImage2.ImageData;
							Span<byte> span2 = imageData.Span;
							IReadOnlyList<byte> readOnlyList2 = readOnlyList;
							num4 = 0;
							byte[] array2 = new byte[span2.Length + readOnlyList2.Count];
							span2.CopyTo(new Span<byte>(array2).Slice(num4, span2.Length));
							num4 += span2.Length;
							foreach (byte item2 in readOnlyList2)
							{
								array2[num4] = item2;
								num4++;
							}
							EndInlineImage item = new EndInlineImage(array2);
							list2.Add(item);
							num = coreTokenScanner.CurrentPosition - 3;
						}
						else
						{
							if (operatorToken.Data == "inf")
							{
								list.Add(NumericToken.Zero);
								continue;
							}
							log.Warn("Operator which was not understood encountered. Values was " + operatorToken.Data + ". Ignoring.");
						}
					}
				}
				list.Clear();
			}
			else if (!(currentToken is CommentToken))
			{
				list.Add(currentToken);
			}
		}
		return list2;
	}

	private static bool TryGetLastEndImage(List<IGraphicsStateOperation> graphicsStateOperations, [NotNullWhen(true)] out EndInlineImage? endImage, out int index)
	{
		index = -1;
		endImage = null;
		if (graphicsStateOperations.Count == 0)
		{
			return false;
		}
		for (int num = graphicsStateOperations.Count - 1; num >= 0; num--)
		{
			IGraphicsStateOperation graphicsStateOperation = graphicsStateOperations[num];
			if (graphicsStateOperation is EndInlineImage endInlineImage)
			{
				endImage = endInlineImage;
				index = num;
				return true;
			}
			if ((graphicsStateOperation is EndText || graphicsStateOperation is BeginInlineImageData) ? true : false)
			{
				break;
			}
		}
		return false;
	}
}
