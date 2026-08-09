using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Content;

public class OptionalContentGroupElement
{
	public string Type { get; }

	public string? Name { get; }

	public IReadOnlyList<string>? Intent { get; }

	public IReadOnlyDictionary<string, IToken>? Usage { get; }

	public MarkedContentElement MarkedContent { get; }

	internal OptionalContentGroupElement(MarkedContentElement markedContentElement, IPdfTokenScanner pdfTokenScanner)
	{
		MarkedContent = markedContentElement;
		if (markedContentElement.Properties.TryGet<NameToken>(NameToken.Type, pdfTokenScanner, out NameToken token))
		{
			Type = token.Data;
		}
		else
		{
			if (!markedContentElement.Properties.TryGet<StringToken>(NameToken.Type, pdfTokenScanner, out StringToken token2))
			{
				throw new ArgumentException("Cannot parse optional content's Type from Properties. This is a required field.", "Properties");
			}
			Type = token2.Data;
		}
		string type = Type;
		if (!(type == "OCG"))
		{
			if (type == "OCMD")
			{
				if (markedContentElement.Properties.TryGet<DictionaryToken>(NameToken.Ocgs, pdfTokenScanner, out DictionaryToken _))
				{
					throw new NotImplementedException($"{NameToken.Ocgs}");
				}
				if (markedContentElement.Properties.TryGet<ArrayToken>(NameToken.Ocgs, pdfTokenScanner, out ArrayToken _))
				{
					throw new NotImplementedException($"{NameToken.Ocgs}");
				}
				if (markedContentElement.Properties.TryGet<NameToken>(NameToken.P, pdfTokenScanner, out NameToken _))
				{
					throw new NotImplementedException($"{NameToken.P}");
				}
				if (markedContentElement.Properties.TryGet<ArrayToken>(NameToken.VE, pdfTokenScanner, out ArrayToken _))
				{
					throw new NotImplementedException($"{NameToken.VE}");
				}
				return;
			}
			throw new ArgumentException("Unknown Optional Content of type '" + Type + "' not known.", "Type");
		}
		StringToken token8;
		HexToken token9;
		if (markedContentElement.Properties.TryGet<NameToken>(NameToken.Name, pdfTokenScanner, out NameToken token7))
		{
			Name = token7.Data;
		}
		else if (markedContentElement.Properties.TryGet<StringToken>(NameToken.Name, pdfTokenScanner, out token8))
		{
			Name = token8.Data;
		}
		else if (markedContentElement.Properties.TryGet<HexToken>(NameToken.Name, pdfTokenScanner, out token9))
		{
			Name = token9.Data;
		}
		else
		{
			Name = markedContentElement.Tag;
		}
		StringToken token11;
		ArrayToken token12;
		if (markedContentElement.Properties.TryGet<NameToken>(NameToken.Intent, pdfTokenScanner, out NameToken token10))
		{
			Intent = new _003C_003Ez__ReadOnlySingleElementList<string>(token10.Data);
		}
		else if (markedContentElement.Properties.TryGet<StringToken>(NameToken.Intent, pdfTokenScanner, out token11))
		{
			Intent = new _003C_003Ez__ReadOnlySingleElementList<string>(token11.Data);
		}
		else if (markedContentElement.Properties.TryGet<ArrayToken>(NameToken.Intent, pdfTokenScanner, out token12))
		{
			List<string> list = new List<string>();
			foreach (IToken datum in token12.Data)
			{
				if (datum is NameToken nameToken)
				{
					list.Add(nameToken.Data);
					continue;
				}
				if (datum is StringToken stringToken)
				{
					list.Add(stringToken.Data);
					continue;
				}
				throw new NotImplementedException();
			}
			Intent = list;
		}
		else
		{
			Intent = new _003C_003Ez__ReadOnlySingleElementList<string>("View");
		}
		if (markedContentElement.Properties.TryGet<DictionaryToken>(NameToken.Usage, pdfTokenScanner, out DictionaryToken token13))
		{
			Usage = token13.Data;
		}
	}

	public override string ToString()
	{
		return Type + " - " + Name + " [" + string.Join(",", Intent) + "]: " + MarkedContent;
	}
}
