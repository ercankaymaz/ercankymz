#define DEBUG
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using PdfSharp.Internal;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Internal;

namespace PdfSharp.Pdf.IO;

internal sealed class Parser
{
	private class ParserState
	{
		public int Position;

		public Symbol Symbol;
	}

	private readonly PdfDocument _document;

	private readonly Lexer _lexer;

	private readonly ShiftStack _stack;

	public Symbol Symbol => _lexer.Symbol;

	public Parser(PdfDocument document, Stream pdf)
	{
		_document = document;
		_lexer = new Lexer(pdf);
		_stack = new ShiftStack();
	}

	public Parser(PdfDocument document)
	{
		_document = document;
		_lexer = document._lexer;
		_stack = new ShiftStack();
	}

	public int MoveToObject(PdfObjectID objectID)
	{
		int position = _document._irefTable[objectID].Position;
		return _lexer.Position = position;
	}

	public PdfObjectID ReadObjectNumber(int position)
	{
		_lexer.Position = position;
		int num = ReadInteger();
		int generationNumber = ReadInteger();
		if (num == 1074)
		{
			GetType();
		}
		return new PdfObjectID(num, generationNumber);
	}

	public PdfObject ReadObject(PdfObject pdfObject, PdfObjectID objectID, bool includeReferences, bool fromObjecStream)
	{
		int objectNumber = objectID.ObjectNumber;
		int generationNumber = objectID.GenerationNumber;
		if (!fromObjecStream)
		{
			MoveToObject(objectID);
			objectNumber = ReadInteger();
			generationNumber = ReadInteger();
		}
		if (fromObjecStream || objectID != new PdfObjectID(objectNumber, generationNumber))
		{
		}
		objectNumber = objectID.ObjectNumber;
		generationNumber = objectID.GenerationNumber;
		if (!fromObjecStream)
		{
			ReadSymbol(Symbol.Obj);
		}
		bool condition = false;
		switch (ScanNextToken())
		{
		case Symbol.BeginArray:
		{
			PdfArray array = ((pdfObject != null) ? ((PdfArray)pdfObject) : new PdfArray(_document));
			pdfObject = ReadArray(array, includeReferences);
			pdfObject.SetObjectID(objectNumber, generationNumber);
			break;
		}
		case Symbol.BeginDictionary:
		{
			PdfDictionary dict = ((pdfObject != null) ? ((PdfDictionary)pdfObject) : new PdfDictionary(_document));
			condition = true;
			pdfObject = ReadDictionary(dict, includeReferences);
			pdfObject.SetObjectID(objectNumber, generationNumber);
			break;
		}
		case Symbol.Null:
			pdfObject = new PdfNullObject(_document);
			pdfObject.SetObjectID(objectNumber, generationNumber);
			if (!fromObjecStream)
			{
				ReadSymbol(Symbol.EndObj);
			}
			return pdfObject;
		case Symbol.EndObj:
			pdfObject = new PdfNullObject(_document);
			pdfObject.SetObjectID(objectNumber, generationNumber);
			return pdfObject;
		case Symbol.Boolean:
			pdfObject = new PdfBooleanObject(_document, string.Compare(_lexer.Token, bool.TrueString, StringComparison.OrdinalIgnoreCase) == 0);
			pdfObject.SetObjectID(objectNumber, generationNumber);
			if (!fromObjecStream)
			{
				ReadSymbol(Symbol.EndObj);
			}
			return pdfObject;
		case Symbol.Integer:
			pdfObject = new PdfIntegerObject(_document, _lexer.TokenToInteger);
			pdfObject.SetObjectID(objectNumber, generationNumber);
			if (!fromObjecStream)
			{
				ReadSymbol(Symbol.EndObj);
			}
			return pdfObject;
		case Symbol.UInteger:
			pdfObject = new PdfUIntegerObject(_document, _lexer.TokenToUInteger);
			pdfObject.SetObjectID(objectNumber, generationNumber);
			if (!fromObjecStream)
			{
				ReadSymbol(Symbol.EndObj);
			}
			return pdfObject;
		case Symbol.Real:
			pdfObject = new PdfRealObject(_document, _lexer.TokenToReal);
			pdfObject.SetObjectID(objectNumber, generationNumber);
			if (!fromObjecStream)
			{
				ReadSymbol(Symbol.EndObj);
			}
			return pdfObject;
		case Symbol.String:
		case Symbol.HexString:
		case Symbol.UnicodeString:
		case Symbol.UnicodeHexString:
			pdfObject = new PdfStringObject(_document, _lexer.Token);
			pdfObject.SetObjectID(objectNumber, generationNumber);
			if (!fromObjecStream)
			{
				ReadSymbol(Symbol.EndObj);
			}
			return pdfObject;
		case Symbol.Name:
			pdfObject = new PdfNameObject(_document, _lexer.Token);
			pdfObject.SetObjectID(objectNumber, generationNumber);
			if (!fromObjecStream)
			{
				ReadSymbol(Symbol.EndObj);
			}
			return pdfObject;
		case Symbol.Keyword:
			ParserDiagnostics.HandleUnexpectedToken(_lexer.Token);
			break;
		default:
			ParserDiagnostics.HandleUnexpectedToken(_lexer.Token);
			break;
		}
		Symbol symbol = ScanNextToken();
		if (symbol == Symbol.BeginStream)
		{
			PdfDictionary pdfDictionary = (PdfDictionary)pdfObject;
			Debug.Assert(condition, "Unexpected stream...");
			int streamLength = GetStreamLength(pdfDictionary);
			byte[] value = _lexer.ReadStream(streamLength);
			PdfDictionary.PdfStream stream = new PdfDictionary.PdfStream(value, pdfDictionary);
			pdfDictionary.Stream = stream;
			ReadSymbol(Symbol.EndStream);
			symbol = ScanNextToken();
		}
		if (!fromObjecStream && symbol != Symbol.EndObj)
		{
			ParserDiagnostics.ThrowParserException(PSSR.UnexpectedToken(_lexer.Token));
		}
		return pdfObject;
	}

	private void ReadStream(PdfDictionary dict)
	{
		Symbol symbol = _lexer.Symbol;
		Debug.Assert(symbol == Symbol.BeginStream);
		int streamLength = GetStreamLength(dict);
		byte[] value = _lexer.ReadStream(streamLength);
		PdfDictionary.PdfStream stream = new PdfDictionary.PdfStream(value, dict);
		Debug.Assert(dict.Stream == null, "Dictionary already has a stream.");
		dict.Stream = stream;
		ReadSymbol(Symbol.EndStream);
		ScanNextToken();
	}

	private int GetStreamLength(PdfDictionary dict)
	{
		if (dict.Elements["/F"] != null)
		{
			throw new NotImplementedException("File streams are not yet implemented.");
		}
		PdfItem pdfItem = dict.Elements["/Length"];
		if (pdfItem is PdfInteger)
		{
			return Convert.ToInt32(pdfItem);
		}
		if (pdfItem is PdfReference pdfReference)
		{
			ParserState state = SaveState();
			object obj = ReadObject(null, pdfReference.ObjectID, includeReferences: false, fromObjecStream: false);
			RestoreState(state);
			int value = ((PdfIntegerObject)obj).Value;
			dict.Elements["/Length"] = new PdfInteger(value);
			return value;
		}
		throw new InvalidOperationException("Cannot retrieve stream length.");
	}

	public PdfArray ReadArray(PdfArray array, bool includeReferences)
	{
		Debug.Assert(Symbol == Symbol.BeginArray);
		if (array == null)
		{
			array = new PdfArray(_document);
		}
		int sP = _stack.SP;
		ParseObject(Symbol.EndArray);
		int num = _stack.SP - sP;
		PdfItem[] array2 = _stack.ToArray(sP, num);
		_stack.Reduce(num);
		for (int i = 0; i < num; i++)
		{
			PdfItem pdfItem = array2[i];
			if (includeReferences && pdfItem is PdfReference)
			{
				pdfItem = ReadReference((PdfReference)pdfItem, includeReferences: true);
			}
			array.Elements.Add(pdfItem);
		}
		return array;
	}

	internal PdfDictionary ReadDictionary(PdfDictionary dict, bool includeReferences)
	{
		Debug.Assert(Symbol == Symbol.BeginDictionary);
		if (dict == null)
		{
			dict = new PdfDictionary(_document);
		}
		DictionaryMeta meta = dict.Meta;
		int sP = _stack.SP;
		ParseObject(Symbol.EndDictionary);
		int num = _stack.SP - sP;
		Debug.Assert(num % 2 == 0);
		PdfItem[] array = _stack.ToArray(sP, num);
		_stack.Reduce(num);
		for (int i = 0; i < num; i += 2)
		{
			PdfItem pdfItem = array[i];
			if (!(pdfItem is PdfName))
			{
				ParserDiagnostics.ThrowParserException("name expected");
			}
			string key = pdfItem.ToString();
			pdfItem = array[i + 1];
			if (includeReferences && pdfItem is PdfReference)
			{
				pdfItem = ReadReference((PdfReference)pdfItem, includeReferences: true);
			}
			dict.Elements[key] = pdfItem;
		}
		return dict;
	}

	private void ParseObject(Symbol stop)
	{
		Symbol symbol;
		while ((symbol = ScanNextToken()) != Symbol.Eof)
		{
			if (symbol == stop)
			{
				return;
			}
			switch (symbol)
			{
			case Symbol.Null:
				_stack.Shift(PdfNull.Value);
				break;
			case Symbol.Boolean:
				_stack.Shift(new PdfBoolean(_lexer.TokenToBoolean));
				break;
			case Symbol.Integer:
				_stack.Shift(new PdfInteger(_lexer.TokenToInteger));
				break;
			case Symbol.UInteger:
				_stack.Shift(new PdfUInteger(_lexer.TokenToUInteger));
				break;
			case Symbol.Real:
				_stack.Shift(new PdfReal(_lexer.TokenToReal));
				break;
			case Symbol.String:
				_stack.Shift(new PdfString(_lexer.Token, PdfStringFlags.RawEncoding));
				break;
			case Symbol.UnicodeString:
				_stack.Shift(new PdfString(_lexer.Token, PdfStringFlags.Unicode));
				break;
			case Symbol.HexString:
				_stack.Shift(new PdfString(_lexer.Token, PdfStringFlags.HexLiteral));
				break;
			case Symbol.UnicodeHexString:
				_stack.Shift(new PdfString(_lexer.Token, PdfStringFlags.Unicode | PdfStringFlags.HexLiteral));
				break;
			case Symbol.Name:
				_stack.Shift(new PdfName(_lexer.Token));
				break;
			case Symbol.R:
			{
				Debug.Assert(_stack.GetItem(-1) is PdfInteger && _stack.GetItem(-2) is PdfInteger);
				PdfObjectID objectID = new PdfObjectID(_stack.GetInteger(-2), _stack.GetInteger(-1));
				PdfReference pdfReference = _document._irefTable[objectID];
				if (pdfReference == null)
				{
					if (_document._irefTable.IsUnderConstruction)
					{
						pdfReference = new PdfReference(objectID, 0);
						_stack.Reduce(pdfReference, 2);
					}
					else
					{
						_stack.Reduce(PdfNull.Value, 2);
					}
				}
				else
				{
					_stack.Reduce(pdfReference, 2);
				}
				break;
			}
			case Symbol.BeginArray:
			{
				PdfArray pdfArray = new PdfArray(_document);
				ReadArray(pdfArray, includeReferences: false);
				_stack.Shift(pdfArray);
				break;
			}
			case Symbol.BeginDictionary:
			{
				PdfDictionary pdfDictionary = new PdfDictionary(_document);
				ReadDictionary(pdfDictionary, includeReferences: false);
				_stack.Shift(pdfDictionary);
				break;
			}
			case Symbol.BeginStream:
				throw new NotImplementedException();
			default:
				ParserDiagnostics.HandleUnexpectedToken(_lexer.Token);
				SkipCharsUntil(stop);
				return;
			case Symbol.Comment:
				break;
			}
		}
		ParserDiagnostics.ThrowParserException("Unexpected end of file.");
	}

	private Symbol ScanNextToken()
	{
		return _lexer.ScanNextToken();
	}

	private Symbol ScanNextToken(out string token)
	{
		Symbol result = _lexer.ScanNextToken();
		token = _lexer.Token;
		return result;
	}

	private Symbol SkipCharsUntil(Symbol stop)
	{
		if (stop == Symbol.EndDictionary)
		{
			return SkipCharsUntil(">>", stop);
		}
		Symbol symbol;
		do
		{
			symbol = ScanNextToken();
		}
		while (symbol != stop && symbol != Symbol.Eof);
		return symbol;
	}

	private Symbol SkipCharsUntil(string text, Symbol stop)
	{
		int length = text.Length;
		int num = 0;
		char c;
		while ((c = _lexer.ScanNextChar(handleCRLF: true)) != '\uffff')
		{
			if (c == text[num])
			{
				if (num + 1 == length)
				{
					_lexer.ScanNextChar(handleCRLF: true);
					return stop;
				}
				num++;
			}
			else
			{
				num = 0;
			}
		}
		return Symbol.Eof;
	}

	private void ReadObjectID(PdfObject obj)
	{
		int objectNumber = ReadInteger();
		int generationNumber = ReadInteger();
		ReadSymbol(Symbol.Obj);
		obj?.SetObjectID(objectNumber, generationNumber);
	}

	private PdfItem ReadReference(PdfReference iref, bool includeReferences)
	{
		throw new NotImplementedException("ReadReference");
	}

	private Symbol ReadSymbol(Symbol symbol)
	{
		if (symbol == Symbol.EndStream)
		{
			while (true)
			{
				char c = _lexer.MoveToNonWhiteSpace();
				if (c == '\uffff')
				{
					ParserDiagnostics.HandleUnexpectedCharacter(c);
				}
				if (c == 'e')
				{
					break;
				}
				_lexer.ScanNextChar(handleCRLF: false);
			}
		}
		Symbol symbol2 = _lexer.ScanNextToken();
		if (symbol != symbol2)
		{
			ParserDiagnostics.HandleUnexpectedToken(_lexer.Token);
		}
		return symbol2;
	}

	private Symbol ReadToken(string token)
	{
		Symbol result = _lexer.ScanNextToken();
		if (token != _lexer.Token)
		{
			ParserDiagnostics.HandleUnexpectedToken(_lexer.Token);
		}
		return result;
	}

	private string ReadName()
	{
		string token;
		Symbol symbol = ScanNextToken(out token);
		if (symbol != Symbol.Name)
		{
			ParserDiagnostics.HandleUnexpectedToken(token);
		}
		return token;
	}

	private int ReadInteger(bool canBeIndirect)
	{
		switch (_lexer.ScanNextToken())
		{
		case Symbol.Integer:
			return _lexer.TokenToInteger;
		case Symbol.R:
		{
			int position = _lexer.Position;
			ReadObjectID(null);
			int result = ReadInteger();
			ReadSymbol(Symbol.EndObj);
			_lexer.Position = position;
			return result;
		}
		default:
			ParserDiagnostics.HandleUnexpectedToken(_lexer.Token);
			return 0;
		}
	}

	private int ReadInteger()
	{
		return ReadInteger(canBeIndirect: false);
	}

	public static PdfObject ReadObject(PdfDocument owner, PdfObjectID objectID)
	{
		if (owner == null)
		{
			throw new ArgumentNullException("owner");
		}
		Parser parser = new Parser(owner);
		return parser.ReadObject(null, objectID, includeReferences: false, fromObjecStream: false);
	}

	internal void ReadIRefsFromCompressedObject(PdfObjectID objectID)
	{
		Debug.Assert(_document._irefTable.ObjectTable.ContainsKey(objectID));
		if (!_document._irefTable.ObjectTable.TryGetValue(objectID, out var value))
		{
			throw new NotImplementedException("This case is not coded or something else went wrong");
		}
		if (value.Value == null)
		{
			try
			{
				Debug.Assert(_document._irefTable.Contains(value.ObjectID));
				PdfDictionary dict = (PdfDictionary)ReadObject(null, value.ObjectID, includeReferences: false, fromObjecStream: false);
				PdfObjectStream pdfObjectStream = new PdfObjectStream(dict);
				Debug.Assert(pdfObjectStream.Reference == value);
				Debug.Assert(pdfObjectStream.Reference.Value != null, "Something went wrong.");
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				throw;
			}
		}
		Debug.Assert(value.Value != null);
		PdfObjectStream pdfObjectStream2 = value.Value as PdfObjectStream;
		if (pdfObjectStream2 == null)
		{
			Debug.Assert(((PdfDictionary)value.Value).Elements.GetName("/Type") == "/ObjStm");
			pdfObjectStream2 = new PdfObjectStream((PdfDictionary)value.Value);
			Debug.Assert(pdfObjectStream2.Reference == value);
			Debug.Assert(pdfObjectStream2.Reference.Value != null, "Something went wrong.");
		}
		Debug.Assert(pdfObjectStream2 != null);
		if (pdfObjectStream2 == null)
		{
			throw new Exception("Something went wrong here.");
		}
		pdfObjectStream2.ReadReferences(_document._irefTable);
	}

	internal PdfReference ReadCompressedObject(PdfObjectID objectID, int index)
	{
		Debug.Assert(_document._irefTable.ObjectTable.ContainsKey(objectID));
		if (!_document._irefTable.ObjectTable.TryGetValue(objectID, out var value))
		{
			throw new NotImplementedException("This case is not coded or something else went wrong");
		}
		if (value.Value == null)
		{
			try
			{
				Debug.Assert(_document._irefTable.Contains(value.ObjectID));
				PdfDictionary dict = (PdfDictionary)ReadObject(null, value.ObjectID, includeReferences: false, fromObjecStream: false);
				PdfObjectStream pdfObjectStream = new PdfObjectStream(dict);
				Debug.Assert(pdfObjectStream.Reference == value);
				Debug.Assert(pdfObjectStream.Reference.Value != null, "Something went wrong.");
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				throw;
			}
		}
		Debug.Assert(value.Value != null);
		PdfObjectStream pdfObjectStream2 = value.Value as PdfObjectStream;
		if (pdfObjectStream2 == null)
		{
			Debug.Assert(((PdfDictionary)value.Value).Elements.GetName("/Type") == "/ObjStm");
			pdfObjectStream2 = new PdfObjectStream((PdfDictionary)value.Value);
			Debug.Assert(pdfObjectStream2.Reference == value);
			Debug.Assert(pdfObjectStream2.Reference.Value != null, "Something went wrong.");
		}
		Debug.Assert(pdfObjectStream2 != null);
		if (pdfObjectStream2 == null)
		{
			throw new Exception("Something went wrong here.");
		}
		return pdfObjectStream2.ReadCompressedObject(index);
	}

	internal PdfReference ReadCompressedObject(int objectNumber, int offset)
	{
		PdfObjectID objectID = new PdfObjectID(objectNumber);
		_lexer.Position = offset;
		PdfObject pdfObject = ReadObject(null, objectID, includeReferences: false, fromObjecStream: true);
		return pdfObject.Reference;
	}

	internal int[][] ReadObjectStreamHeader(int n, int first)
	{
		int[][] array = new int[n][];
		for (int i = 0; i < n; i++)
		{
			int num = ReadInteger();
			if (num == 1074)
			{
				GetType();
			}
			int num2 = ReadInteger() + first;
			array[i] = new int[2] { num, num2 };
		}
		return array;
	}

	internal PdfTrailer ReadTrailer()
	{
		int pdfLength = _lexer.PdfLength;
		int num;
		if (pdfLength < 1030)
		{
			string text = _lexer.ReadRawString(pdfLength - 31, 30);
			num = text.LastIndexOf("startxref", StringComparison.Ordinal);
			_lexer.Position = pdfLength - 31 + num;
		}
		else
		{
			string text2 = _lexer.ReadRawString(pdfLength - 1031, 1030);
			num = text2.LastIndexOf("startxref", StringComparison.Ordinal);
			_lexer.Position = pdfLength - 1031 + num;
		}
		if (num == -1)
		{
			string text3 = _lexer.ReadRawString(0, pdfLength);
			num = text3.LastIndexOf("startxref", StringComparison.Ordinal);
			_lexer.Position = num;
		}
		if (num == -1)
		{
			throw new Exception("The StartXRef table could not be found, the file cannot be opened.");
		}
		ReadSymbol(Symbol.StartXRef);
		_lexer.Position = ReadInteger();
		while (true)
		{
			PdfTrailer pdfTrailer = ReadXRefTableAndTrailer(_document._irefTable);
			if (_document._trailer == null)
			{
				_document._trailer = pdfTrailer;
			}
			int integer = pdfTrailer.Elements.GetInteger("/Prev");
			if (integer == 0)
			{
				break;
			}
			_lexer.Position = integer;
		}
		return _document._trailer;
	}

	private PdfTrailer ReadXRefTableAndTrailer(PdfCrossReferenceTable xrefTable)
	{
		Debug.Assert(xrefTable != null);
		switch (ScanNextToken())
		{
		case Symbol.XRef:
			while (true)
			{
				switch (ScanNextToken())
				{
				case Symbol.Integer:
				{
					int tokenToInteger = _lexer.TokenToInteger;
					int num = ReadInteger();
					for (int i = tokenToInteger; i < tokenToInteger + num; i++)
					{
						int position = ReadInteger();
						int generationNumber = ReadInteger();
						ReadSymbol(Symbol.Keyword);
						string token = _lexer.Token;
						if (i != 0 && !(token != "n"))
						{
							PdfObjectID objectID = new PdfObjectID(i, generationNumber);
							if (!xrefTable.Contains(objectID))
							{
								xrefTable.Add(new PdfReference(objectID, position));
							}
						}
					}
					break;
				}
				case Symbol.Trailer:
				{
					ReadSymbol(Symbol.BeginDictionary);
					PdfTrailer pdfTrailer = new PdfTrailer(_document);
					ReadDictionary(pdfTrailer, includeReferences: false);
					return pdfTrailer;
				}
				default:
					ParserDiagnostics.HandleUnexpectedToken(_lexer.Token);
					break;
				}
			}
		case Symbol.Integer:
			return ReadXRefStream(xrefTable);
		default:
			return null;
		}
	}

	private PdfTrailer ReadXRefStream(PdfCrossReferenceTable xrefTable)
	{
		int tokenToInteger = _lexer.TokenToInteger;
		int num = ReadInteger();
		Debug.Assert(num == 0);
		ReadSymbol(Symbol.Obj);
		ReadSymbol(Symbol.BeginDictionary);
		PdfObjectID objectID = new PdfObjectID(tokenToInteger, num);
		PdfCrossReferenceStream pdfCrossReferenceStream = new PdfCrossReferenceStream(_document);
		ReadDictionary(pdfCrossReferenceStream, includeReferences: false);
		ReadSymbol(Symbol.BeginStream);
		ReadStream(pdfCrossReferenceStream);
		PdfReference pdfReference = new PdfReference(pdfCrossReferenceStream);
		pdfReference.ObjectID = objectID;
		pdfReference.Value = pdfCrossReferenceStream;
		xrefTable.Add(pdfReference);
		Debug.Assert(pdfCrossReferenceStream.Stream != null);
		byte[] unfilteredValue = pdfCrossReferenceStream.Stream.UnfilteredValue;
		byte[] array = unfilteredValue;
		if (pdfCrossReferenceStream.Stream.HasDecodeParams)
		{
			int decodePredictor = pdfCrossReferenceStream.Stream.DecodePredictor;
			int decodeColumns = pdfCrossReferenceStream.Stream.DecodeColumns;
			array = DecodeCrossReferenceStream(unfilteredValue, decodeColumns, decodePredictor);
		}
		int integer = pdfCrossReferenceStream.Elements.GetInteger("/Size");
		PdfArray pdfArray = pdfCrossReferenceStream.Elements.GetValue("/Index") as PdfArray;
		int integer2 = pdfCrossReferenceStream.Elements.GetInteger("/Prev");
		PdfArray pdfArray2 = (PdfArray)pdfCrossReferenceStream.Elements.GetValue("/W");
		int[][] array2 = null;
		int num2 = 0;
		int num3;
		if (pdfArray == null)
		{
			num3 = 1;
			array2 = new int[num3][];
			array2[0] = new int[2] { 0, integer };
			num2 = integer;
		}
		else
		{
			Debug.Assert(pdfArray.Elements.Count % 2 == 0);
			num3 = pdfArray.Elements.Count / 2;
			array2 = new int[num3][];
			for (int i = 0; i < num3; i++)
			{
				array2[i] = new int[2]
				{
					pdfArray.Elements.GetInteger(2 * i),
					pdfArray.Elements.GetInteger(2 * i + 1)
				};
				num2 += array2[i][1];
			}
		}
		Debug.Assert(pdfArray2.Elements.Count == 3);
		int[] array3 = new int[3]
		{
			pdfArray2.Elements.GetInteger(0),
			pdfArray2.Elements.GetInteger(1),
			pdfArray2.Elements.GetInteger(2)
		};
		int num4 = StreamHelper.WSize(array3);
		if (num4 * num2 != array.Length)
		{
			GetType();
		}
		Debug.Assert(num4 * num2 == array.Length, "Check implementation here.");
		int num5 = array2[0][1];
		int[] array4 = array2[0];
		if (PdfDiagnostics.TraceXrefStreams)
		{
			for (int j = 0; j < num5; j++)
			{
				uint num6 = StreamHelper.ReadBytes(array, j * num4, array3[0]);
				uint num7 = StreamHelper.ReadBytes(array, j * num4 + array3[0], array3[1]);
				uint num8 = StreamHelper.ReadBytes(array, j * num4 + array3[0] + array3[1], array3[2]);
				string text = $"{j,2:00}: {num6} {num7,5} {num8}  // ";
				Debug.WriteLine(num6 switch
				{
					0u => text + "Fee list: object number, generation number", 
					1u => text + "Not compresed: offset, generation number", 
					2u => text + "Compressed: object stream object number, index in stream", 
					_ => text + "??? Type undefined", 
				});
			}
		}
		int num9 = -1;
		for (int k = 0; k < num3; k++)
		{
			int num10 = array2[k][1];
			for (int l = 0; l < num10; l++)
			{
				num9++;
				PdfCrossReferenceStream.CrossReferenceStreamEntry item = new PdfCrossReferenceStream.CrossReferenceStreamEntry
				{
					Type = StreamHelper.ReadBytes(array, num9 * num4, array3[0]),
					Field2 = StreamHelper.ReadBytes(array, num9 * num4 + array3[0], array3[1]),
					Field3 = StreamHelper.ReadBytes(array, num9 * num4 + array3[0] + array3[1], array3[2])
				};
				pdfCrossReferenceStream.Entries.Add(item);
				switch (item.Type)
				{
				case 1u:
				{
					int field = (int)item.Field2;
					objectID = ReadObjectNumber(field);
					if (objectID.ObjectNumber == 1074)
					{
						GetType();
					}
					Debug.Assert(objectID.GenerationNumber == item.Field3);
					if (!xrefTable.Contains(objectID))
					{
						GetType();
						xrefTable.Add(new PdfReference(objectID, field));
					}
					break;
				}
				}
			}
		}
		return pdfCrossReferenceStream;
	}

	internal static DateTime ParseDateTime(string date, DateTime errorValue)
	{
		DateTime dateTime = errorValue;
		try
		{
			if (date.StartsWith("D:"))
			{
				int length = date.Length;
				int year = 0;
				int val = 0;
				int day = 0;
				int hour = 0;
				int minute = 0;
				int second = 0;
				int hours = 0;
				int minutes = 0;
				char c = 'Z';
				if (length >= 10)
				{
					year = int.Parse(date.Substring(2, 4));
					val = int.Parse(date.Substring(6, 2));
					day = int.Parse(date.Substring(8, 2));
					if (length >= 16)
					{
						hour = int.Parse(date.Substring(10, 2));
						minute = int.Parse(date.Substring(12, 2));
						second = int.Parse(date.Substring(14, 2));
						if (length >= 23 && (c = date[16]) != 'Z')
						{
							hours = int.Parse(date.Substring(17, 2));
							minutes = int.Parse(date.Substring(20, 2));
						}
					}
				}
				val = Math.Min(Math.Max(val, 1), 12);
				dateTime = new DateTime(year, val, day, hour, minute, second);
				if (c != 'Z')
				{
					TimeSpan value = new TimeSpan(hours, minutes, 0);
					dateTime = ((c != '-') ? dateTime.Subtract(value) : dateTime.Add(value));
				}
				DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
			}
			else
			{
				dateTime = DateTime.Parse(date, CultureInfo.InvariantCulture);
			}
		}
		catch (Exception ex)
		{
			Debug.Assert(condition: false, ex.Message);
		}
		return dateTime;
	}

	private ParserState SaveState()
	{
		ParserState parserState = new ParserState();
		parserState.Position = _lexer.Position;
		parserState.Symbol = _lexer.Symbol;
		return parserState;
	}

	private void RestoreState(ParserState state)
	{
		_lexer.Position = state.Position;
		_lexer.Symbol = state.Symbol;
	}

	private byte[] DecodeCrossReferenceStream(byte[] bytes, int columns, int predictor)
	{
		int num = bytes.Length;
		if (predictor < 10 || predictor > 15)
		{
			throw new ArgumentException("Invalid predictor.", "predictor");
		}
		int num2 = columns + 1;
		if (num % num2 != 0)
		{
			throw new ArgumentException("Columns and size of array do not match.");
		}
		int num3 = num / num2;
		byte[] array = new byte[num3 * columns];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = 88;
		}
		for (int j = 0; j < num3; j++)
		{
			if (bytes[j * num2] != 2)
			{
				throw new ArgumentException("Invalid predictor in array.");
			}
			for (int k = 0; k < columns; k++)
			{
				if (j == 0)
				{
					array[j * columns + k] = bytes[j * num2 + k + 1];
				}
				else
				{
					array[j * columns + k] = (byte)(array[j * columns - columns + k] + bytes[j * num2 + k + 1]);
				}
			}
		}
		return array;
	}
}
