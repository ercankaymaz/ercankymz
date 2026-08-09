using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.AcroForms.Fields;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Parser.Parts;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.AcroForms;

internal class AcroFormFactory
{
	private static readonly HashSet<NameToken> InheritableFields = new HashSet<NameToken>
	{
		NameToken.Ft,
		NameToken.Ff,
		NameToken.V,
		NameToken.Dv,
		NameToken.Aa
	};

	private readonly IPdfTokenScanner tokenScanner;

	private readonly ILookupFilterProvider filterProvider;

	private readonly IReadOnlyDictionary<IndirectReference, long> objectOffsets;

	public AcroFormFactory(IPdfTokenScanner tokenScanner, ILookupFilterProvider filterProvider, IReadOnlyDictionary<IndirectReference, long> objectOffsets)
	{
		this.tokenScanner = tokenScanner ?? throw new ArgumentNullException("tokenScanner");
		this.filterProvider = filterProvider ?? throw new ArgumentNullException("filterProvider");
		this.objectOffsets = objectOffsets;
	}

	public AcroForm? GetAcroForm(Catalog catalog)
	{
		if (!catalog.CatalogDictionary.TryGet(NameToken.AcroForm, out var token))
		{
			return null;
		}
		if (!DirectObjectFinder.TryGet<DictionaryToken>(token, tokenScanner, out DictionaryToken tokenResult))
		{
			List<IndirectReferenceToken> list = new List<IndirectReferenceToken>();
			foreach (IndirectReference key in objectOffsets.Keys)
			{
				IndirectReferenceToken indirectReferenceToken = new IndirectReferenceToken(key);
				if (DirectObjectFinder.TryGet<DictionaryToken>(indirectReferenceToken, tokenScanner, out DictionaryToken tokenResult2) && tokenResult2.TryGet<ArrayToken>(NameToken.Kids, tokenScanner, out ArrayToken _) && tokenResult2.TryGet<StringToken>(NameToken.T, tokenScanner, out StringToken _))
				{
					list.Add(indirectReferenceToken);
				}
			}
			if (list.Count == 0)
			{
				return null;
			}
			tokenResult = new DictionaryToken(new Dictionary<NameToken, IToken> { 
			{
				NameToken.Fields,
				new ArrayToken(list)
			} });
		}
		SignatureFlags signatureFlags = (SignatureFlags)0;
		if (tokenResult.TryGetOptionalTokenDirect<NumericToken>(NameToken.SigFlags, tokenScanner, out NumericToken result))
		{
			signatureFlags = (SignatureFlags)result.Int;
		}
		bool needAppearances = false;
		if (tokenResult.TryGetOptionalTokenDirect<BooleanToken>(NameToken.NeedAppearances, tokenScanner, out BooleanToken result2))
		{
			needAppearances = result2.Data;
		}
		tokenResult.TryGetOptionalTokenDirect<ArrayToken>(NameToken.Co, tokenScanner, out ArrayToken _);
		DictionaryToken result4 = null;
		tokenResult.TryGetOptionalTokenDirect<DictionaryToken>(NameToken.Dr, tokenScanner, out result4);
		HexToken result6;
		if (tokenResult.TryGetOptionalTokenDirect<StringToken>(NameToken.Da, tokenScanner, out StringToken result5))
		{
			_ = result5.Data;
		}
		else if (tokenResult.TryGetOptionalTokenDirect<HexToken>(NameToken.Da, tokenScanner, out result6))
		{
			_ = result6.Data;
		}
		if (tokenResult.TryGetOptionalTokenDirect<NumericToken>(NameToken.Q, tokenScanner, out NumericToken result7))
		{
			_ = result7.Int;
		}
		if (!tokenResult.TryGet<ArrayToken>(NameToken.Fields, tokenScanner, out ArrayToken token4))
		{
			return null;
		}
		Dictionary<IndirectReference, AcroFieldBase> dictionary = new Dictionary<IndirectReference, AcroFieldBase>(token4.Length);
		foreach (IToken datum in token4.Data)
		{
			if (!(datum is IndirectReferenceToken indirectReferenceToken2))
			{
				throw new PdfDocumentFormatException($"The fields array should only contain indirect references, instead got: {datum}.");
			}
			DictionaryToken fieldDictionary = DirectObjectFinder.Get<DictionaryToken>(datum, tokenScanner);
			AcroFieldBase acroField = GetAcroField(fieldDictionary, catalog, new List<DictionaryToken>(0));
			dictionary[indirectReferenceToken2.Data] = acroField;
		}
		return new AcroForm(tokenResult, signatureFlags, needAppearances, dictionary);
	}

	private AcroFieldBase GetAcroField(DictionaryToken fieldDictionary, Catalog catalog, IReadOnlyList<DictionaryToken> parentDictionaries)
	{
		(DictionaryToken dictionary, bool inheritsValue) tuple = CreateInheritedDictionary(fieldDictionary, parentDictionaries);
		DictionaryToken item = tuple.dictionary;
		bool item2 = tuple.inheritsValue;
		fieldDictionary = item;
		fieldDictionary.TryGet<NameToken>(NameToken.Ft, tokenScanner, out NameToken token);
		fieldDictionary.TryGet<NumericToken>(NameToken.Ff, tokenScanner, out NumericToken token2);
		List<(bool, DictionaryToken)> list = new List<(bool, DictionaryToken)>();
		if (fieldDictionary.TryGetOptionalTokenDirect<ArrayToken>(NameToken.Kids, tokenScanner, out ArrayToken result))
		{
			foreach (IToken datum in result.Data)
			{
				if (!(datum is IndirectReferenceToken indirectReferenceToken))
				{
					throw new PdfDocumentFormatException($"AcroForm kids should only contain indirect reference, instead got: {datum}.");
				}
				ObjectToken objectToken = tokenScanner.Get(indirectReferenceToken.Data);
				if (objectToken == null)
				{
					throw new InvalidOperationException($"Could not find the object with reference: {indirectReferenceToken.Data}.");
				}
				if (objectToken.Data is DictionaryToken dictionaryToken)
				{
					IndirectReferenceToken token3;
					bool item3 = dictionaryToken.TryGet(NameToken.Parent, out token3);
					list.Add((item3, dictionaryToken));
					continue;
				}
				throw new PdfDocumentFormatException($"Unexpected type of kid in AcroForm field. Expected dictionary but got: {objectToken.Data}.");
			}
		}
		fieldDictionary.TryGetOptionalStringDirect(NameToken.T, tokenScanner, out string result2);
		fieldDictionary.TryGetOptionalStringDirect(NameToken.Tu, tokenScanner, out string result3);
		fieldDictionary.TryGetOptionalStringDirect(NameToken.Tm, tokenScanner, out string result4);
		fieldDictionary.TryGet(NameToken.Parent, out IndirectReferenceToken token4);
		AcroFieldCommonInformation information = new AcroFieldCommonInformation(token4?.Data, result2, result3, result4);
		int? pageNumber = null;
		if (fieldDictionary.TryGet<IndirectReferenceToken>(NameToken.P, tokenScanner, out IndirectReferenceToken token5))
		{
			pageNumber = catalog.Pages.GetPageByReference(token5.Data)?.PageNumber;
		}
		PdfRectangle? bounds = null;
		if (fieldDictionary.TryGet<ArrayToken>(NameToken.Rect, tokenScanner, out ArrayToken token6) && token6.Length == 4)
		{
			bounds = token6.ToRectangle(tokenScanner);
		}
		List<DictionaryToken> parentDictionaries2 = new List<DictionaryToken>(parentDictionaries) { fieldDictionary };
		List<AcroFieldBase> list2 = new List<AcroFieldBase>(list.Count);
		foreach (var item4 in list)
		{
			if (item4.Item1)
			{
				list2.Add(GetAcroField(item4.Item2, catalog, parentDictionaries2));
			}
		}
		uint num = (uint)(token2?.Long ?? 0);
		if ((object)token == null)
		{
			return new AcroNonTerminalField(fieldDictionary, "Non-Terminal Field", num, information, AcroFieldType.Unknown, list2);
		}
		if (token == NameToken.Btn)
		{
			AcroButtonFieldFlags acroButtonFieldFlags = (AcroButtonFieldFlags)num;
			if (acroButtonFieldFlags.HasFlag(AcroButtonFieldFlags.Radio))
			{
				if (list2.Count > 0)
				{
					return new AcroRadioButtonsField(fieldDictionary, token, acroButtonFieldFlags, information, list2);
				}
				var (isSelected, currentValue) = GetCheckedState(fieldDictionary, item2);
				return new AcroRadioButtonField(fieldDictionary, token, acroButtonFieldFlags, information, pageNumber, bounds, currentValue, isSelected);
			}
			if (acroButtonFieldFlags.HasFlag(AcroButtonFieldFlags.PushButton))
			{
				return new AcroPushButtonField(fieldDictionary, token, acroButtonFieldFlags, information, pageNumber, bounds);
			}
			if (list2.Count > 0)
			{
				return new AcroCheckboxesField(fieldDictionary, token, acroButtonFieldFlags, information, list2);
			}
			var (isChecked, currentValue2) = GetCheckedState(fieldDictionary, item2);
			return new AcroCheckboxField(fieldDictionary, token, acroButtonFieldFlags, information, currentValue2, isChecked, pageNumber, bounds);
		}
		if (token == NameToken.Tx)
		{
			return GetTextField(fieldDictionary, token, num, information, pageNumber, bounds);
		}
		if (token == NameToken.Ch)
		{
			return GetChoiceField(fieldDictionary, token, num, information, pageNumber, bounds);
		}
		if (token == NameToken.Sig)
		{
			return new AcroSignatureField(fieldDictionary, token, num, information, pageNumber, bounds);
		}
		throw new PdfDocumentFormatException($"Unexpected type for field in AcroForm: {token}.");
	}

	private AcroFieldBase GetTextField(DictionaryToken fieldDictionary, NameToken fieldType, uint fieldFlags, AcroFieldCommonInformation information, int? pageNumber, PdfRectangle? bounds)
	{
		string value = null;
		if (fieldDictionary.TryGet(NameToken.V, out var token))
		{
			HexToken tokenResult2;
			StreamToken tokenResult3;
			if (DirectObjectFinder.TryGet<StringToken>(token, tokenScanner, out StringToken tokenResult))
			{
				value = tokenResult.Data;
			}
			else if (DirectObjectFinder.TryGet<HexToken>(token, tokenScanner, out tokenResult2))
			{
				value = tokenResult2.Data;
			}
			else if (DirectObjectFinder.TryGet<StreamToken>(token, tokenScanner, out tokenResult3))
			{
				value = OtherEncodings.BytesAsLatin1String(tokenResult3.Decode(filterProvider, tokenScanner).Span);
			}
		}
		int? maxLength = null;
		if (fieldDictionary.TryGetOptionalTokenDirect<NumericToken>(NameToken.MaxLen, tokenScanner, out NumericToken result))
		{
			maxLength = result.Int;
		}
		return new AcroTextField(fieldDictionary, fieldType, (AcroTextFieldFlags)fieldFlags, information, value, maxLength, pageNumber, bounds);
	}

	private AcroFieldBase GetChoiceField(DictionaryToken fieldDictionary, NameToken fieldType, uint fieldFlags, AcroFieldCommonInformation information, int? pageNumber, PdfRectangle? bounds)
	{
		string[] array = Array.Empty<string>();
		if (fieldDictionary.TryGet(NameToken.V, out var token))
		{
			HexToken tokenResult2;
			ArrayToken tokenResult3;
			if (DirectObjectFinder.TryGet<StringToken>(token, tokenScanner, out StringToken tokenResult))
			{
				array = new string[1] { tokenResult.Data };
			}
			else if (DirectObjectFinder.TryGet<HexToken>(token, tokenScanner, out tokenResult2))
			{
				array = new string[1] { tokenResult2.Data };
			}
			else if (DirectObjectFinder.TryGet<ArrayToken>(token, tokenScanner, out tokenResult3))
			{
				array = new string[tokenResult3.Length];
				for (int i = 0; i < tokenResult3.Length; i++)
				{
					IToken token2 = tokenResult3.Data[i];
					HexToken tokenResult5;
					if (DirectObjectFinder.TryGet<StringToken>(token2, tokenScanner, out StringToken tokenResult4))
					{
						array[i] = tokenResult4.Data;
					}
					else if (DirectObjectFinder.TryGet<HexToken>(token2, tokenScanner, out tokenResult5))
					{
						array[i] = tokenResult5.Data;
					}
				}
			}
		}
		int[] array2 = null;
		if (fieldDictionary.TryGetOptionalTokenDirect<ArrayToken>(NameToken.I, tokenScanner, out ArrayToken result))
		{
			array2 = new int[result.Length];
			for (int j = 0; j < result.Data.Count; j++)
			{
				NumericToken numericToken = DirectObjectFinder.Get<NumericToken>(result.Data[j], tokenScanner);
				array2[j] = numericToken.Int;
			}
		}
		List<AcroChoiceOption> list = new List<AcroChoiceOption>();
		if (fieldDictionary.TryGetOptionalTokenDirect<ArrayToken>(NameToken.Opt, tokenScanner, out ArrayToken result2))
		{
			for (int k = 0; k < result2.Data.Count; k++)
			{
				IToken token3 = result2.Data[k];
				if (DirectObjectFinder.TryGet<StringToken>(token3, tokenScanner, out StringToken tokenResult6))
				{
					string data = tokenResult6.Data;
					bool isSelected = IsChoiceSelected(array, array2, k, data);
					list.Add(new AcroChoiceOption(k, isSelected, tokenResult6.Data));
					continue;
				}
				if (DirectObjectFinder.TryGet<HexToken>(token3, tokenScanner, out HexToken tokenResult7))
				{
					string data2 = tokenResult7.Data;
					bool isSelected2 = IsChoiceSelected(array, array2, k, data2);
					list.Add(new AcroChoiceOption(k, isSelected2, tokenResult7.Data));
					continue;
				}
				if (DirectObjectFinder.TryGet<ArrayToken>(token3, tokenScanner, out ArrayToken tokenResult8))
				{
					if (tokenResult8.Length != 2)
					{
						throw new PdfDocumentFormatException($"An option array containing array elements should contain 2 strings, instead got: {tokenResult8.Length}.");
					}
					string data3;
					if (DirectObjectFinder.TryGet<StringToken>(tokenResult8.Data[0], tokenScanner, out StringToken tokenResult9))
					{
						data3 = tokenResult9.Data;
					}
					else
					{
						if (!DirectObjectFinder.TryGet<HexToken>(tokenResult8.Data[0], tokenScanner, out HexToken tokenResult10))
						{
							throw new PdfDocumentFormatException($"An option array array element's first value should be the export value string, instead got: {tokenResult8.Data[0]}.");
						}
						data3 = tokenResult10.Data;
					}
					string data4;
					if (DirectObjectFinder.TryGet<StringToken>(tokenResult8.Data[1], tokenScanner, out StringToken tokenResult11))
					{
						data4 = tokenResult11.Data;
					}
					else
					{
						if (!DirectObjectFinder.TryGet<HexToken>(tokenResult8.Data[1], tokenScanner, out HexToken tokenResult12))
						{
							throw new PdfDocumentFormatException($"An option array array element's second value should be the option name string, instead got: {tokenResult8.Data[1]}.");
						}
						data4 = tokenResult12.Data;
					}
					bool isSelected3 = IsChoiceSelected(array, array2, k, data4);
					list.Add(new AcroChoiceOption(k, isSelected3, data4, data3));
					continue;
				}
				throw new PdfDocumentFormatException($"An option array should contain either strings or 2 element arrays, instead got: {token3}.");
			}
		}
		if (((AcroChoiceFieldFlags)fieldFlags).HasFlag(AcroChoiceFieldFlags.Combo))
		{
			return new AcroComboBoxField(fieldDictionary, fieldType, (AcroChoiceFieldFlags)fieldFlags, information, list, array, array2, pageNumber, bounds);
		}
		int? topIndex = null;
		if (fieldDictionary.TryGetOptionalTokenDirect<NumericToken>(NameToken.Ti, tokenScanner, out NumericToken result3))
		{
			topIndex = result3.Int;
		}
		return new AcroListBoxField(fieldDictionary, fieldType, (AcroChoiceFieldFlags)fieldFlags, information, list, array, array2, topIndex, pageNumber, bounds);
	}

	private (bool isChecked, NameToken stateName) GetCheckedState(DictionaryToken fieldDictionary, bool inheritsValue)
	{
		bool item = false;
		NameToken token;
		if (!fieldDictionary.TryGetOptionalTokenDirect<NameToken>(NameToken.V, tokenScanner, out NameToken result))
		{
			if (fieldDictionary.TryGetOptionalTokenDirect<NameToken>(NameToken.As, tokenScanner, out NameToken result2) && fieldDictionary.TryGetOptionalTokenDirect<DictionaryToken>(NameToken.Ap, tokenScanner, out DictionaryToken _))
			{
				item = !string.Equals(result2.Data, NameToken.Off, StringComparison.OrdinalIgnoreCase);
				result = result2;
				return (isChecked: item, stateName: result);
			}
			result = NameToken.Off;
		}
		else if (inheritsValue && fieldDictionary.TryGet<NameToken>(NameToken.As, tokenScanner, out token))
		{
			item = token.Equals(result);
			result = token;
		}
		else
		{
			item = !string.Equals(result.Data, NameToken.Off, StringComparison.OrdinalIgnoreCase);
		}
		return (isChecked: item, stateName: result);
	}

	private static (DictionaryToken dictionary, bool inheritsValue) CreateInheritedDictionary(DictionaryToken fieldDictionary, IReadOnlyList<DictionaryToken> parents)
	{
		if (parents.Count == 0)
		{
			return (dictionary: fieldDictionary, inheritsValue: false);
		}
		bool item = false;
		Dictionary<NameToken, IToken> dictionary = new Dictionary<NameToken, IToken>();
		foreach (DictionaryToken parent in parents)
		{
			foreach (KeyValuePair<string, IToken> datum in parent.Data)
			{
				NameToken nameToken = NameToken.Create(datum.Key);
				if (InheritableFields.Contains(nameToken))
				{
					dictionary[nameToken] = datum.Value;
					if (NameToken.V.Equals(nameToken))
					{
						item = true;
					}
				}
			}
		}
		foreach (KeyValuePair<string, IToken> datum2 in fieldDictionary.Data)
		{
			NameToken nameToken2 = NameToken.Create(datum2.Key);
			dictionary[nameToken2] = datum2.Value;
			if (NameToken.V.Equals(nameToken2))
			{
				item = false;
			}
		}
		return (dictionary: new DictionaryToken(dictionary), inheritsValue: item);
	}

	private static bool IsChoiceSelected(IReadOnlyList<string> selectedOptionNames, IReadOnlyList<int>? selectedOptionIndices, int index, string name)
	{
		if (selectedOptionNames.Count == 0)
		{
			return false;
		}
		for (int i = 0; i < selectedOptionNames.Count; i++)
		{
			if (!(selectedOptionNames[i] != name))
			{
				if (selectedOptionIndices == null)
				{
					return true;
				}
				if (selectedOptionIndices.Contains(index))
				{
					return true;
				}
				return false;
			}
		}
		return false;
	}
}
