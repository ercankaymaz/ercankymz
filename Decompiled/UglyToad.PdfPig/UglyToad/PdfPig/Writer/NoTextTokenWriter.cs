using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Graphics;
using UglyToad.PdfPig.Graphics.Operations;
using UglyToad.PdfPig.Logging;
using UglyToad.PdfPig.Parser;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Writer;

internal sealed class NoTextTokenWriter : TokenWriter
{
	internal int Page { get; set; }

	protected override void WriteStream(StreamToken streamToken, Stream outputStream)
	{
		StreamToken outputStreamToken;
		if (!base.WritingPageContents && !IsFormStream(streamToken))
		{
			outputStreamToken = streamToken;
		}
		else if (!TryGetStreamWithoutText(streamToken, out outputStreamToken))
		{
			outputStreamToken = streamToken;
		}
		WriteDictionary(outputStreamToken.StreamDictionary, outputStream);
		WriteLineBreak(outputStream);
		outputStream.Write(TokenWriter.StreamStart);
		WriteLineBreak(outputStream);
		outputStream.Write(outputStreamToken.Data.Span);
		WriteLineBreak(outputStream);
		outputStream.Write(TokenWriter.StreamEnd);
	}

	private static bool IsFormStream(StreamToken streamToken)
	{
		if (streamToken.StreamDictionary.TryGet(NameToken.Subtype, out NameToken token))
		{
			return token.Equals(NameToken.Form);
		}
		return false;
	}

	private bool TryGetStreamWithoutText(StreamToken streamToken, [NotNullWhen(true)] out StreamToken? outputStreamToken)
	{
		FilterProviderWithLookup filterProvider = new FilterProviderWithLookup(DefaultFilterProvider.Instance);
		ReadOnlyMemory<byte> memory;
		try
		{
			memory = streamToken.Decode(filterProvider);
		}
		catch
		{
			outputStreamToken = null;
			return false;
		}
		PageContentParser pageContentParser = new PageContentParser(ReflectionGraphicsStateOperationFactory.Instance);
		IReadOnlyList<IGraphicsStateOperation> readOnlyList;
		try
		{
			readOnlyList = pageContentParser.Parse(Page, new MemoryInputBytes(memory), new NoOpLog());
		}
		catch (Exception)
		{
			outputStreamToken = null;
			return false;
		}
		using MemoryStream memoryStream = new MemoryStream();
		bool flag = false;
		foreach (IGraphicsStateOperation item in readOnlyList)
		{
			if (item.Operator == "Tj" || item.Operator == "TJ" || item.Operator == "'")
			{
				flag = true;
			}
			else
			{
				item.Write(memoryStream);
			}
		}
		if (!flag)
		{
			outputStreamToken = null;
			return false;
		}
		memoryStream.Seek(0L, SeekOrigin.Begin);
		byte[] array = DataCompresser.CompressBytes(memoryStream.ToArray());
		Dictionary<NameToken, IToken> dictionary = new Dictionary<NameToken, IToken>
		{
			{
				NameToken.Length,
				new NumericToken(array.Length)
			},
			{
				NameToken.Filter,
				NameToken.FlateDecode
			}
		};
		foreach (KeyValuePair<string, IToken> datum in streamToken.StreamDictionary.Data)
		{
			NameToken key = NameToken.Create(datum.Key);
			if (!dictionary.ContainsKey(key))
			{
				dictionary[key] = datum.Value;
			}
		}
		outputStreamToken = new StreamToken(new DictionaryToken(dictionary), array);
		return true;
	}
}
