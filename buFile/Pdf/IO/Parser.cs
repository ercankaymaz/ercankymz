// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.IO.Parser
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Internal;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Internal;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;

#nullable disable
namespace PdfSharp.Pdf.IO;

internal sealed class Parser
{
  private readonly PdfDocument _document;
  private readonly Lexer _lexer;
  private readonly ShiftStack _stack;

  public Parser(PdfDocument document, Stream pdf)
  {
    this._document = document;
    this._lexer = new Lexer(pdf);
    this._stack = new ShiftStack();
  }

  public Parser(PdfDocument document)
  {
    this._document = document;
    this._lexer = document._lexer;
    this._stack = new ShiftStack();
  }

  public int MoveToObject(PdfObjectID objectID)
  {
    return this._lexer.Position = this._document._irefTable[objectID].Position;
  }

  public Symbol Symbol => this._lexer.Symbol;

  public PdfObjectID ReadObjectNumber(int position)
  {
    this._lexer.Position = position;
    int objectNumber = this.ReadInteger();
    int generationNumber = this.ReadInteger();
    if (objectNumber == 1074)
      this.GetType();
    return new PdfObjectID(objectNumber, generationNumber);
  }

  public PdfObject ReadObject(
    PdfObject pdfObject,
    PdfObjectID objectID,
    bool includeReferences,
    bool fromObjecStream)
  {
    int objectNumber1 = objectID.ObjectNumber;
    int generationNumber1 = objectID.GenerationNumber;
    if (!fromObjecStream)
    {
      this.MoveToObject(objectID);
      objectNumber1 = this.ReadInteger();
      generationNumber1 = this.ReadInteger();
    }
    if ((fromObjecStream ? 0 : (objectID != new PdfObjectID(objectNumber1, generationNumber1) ? 1 : 0)) != 0)
      ;
    int objectNumber2 = objectID.ObjectNumber;
    int generationNumber2 = objectID.GenerationNumber;
    if (!fromObjecStream)
    {
      int num1 = (int) this.ReadSymbol(Symbol.Obj);
    }
    bool condition = false;
    PdfObject pdfObject1;
    switch (this.ScanNextToken())
    {
      case Symbol.Null:
        pdfObject = (PdfObject) new PdfNullObject(this._document);
        pdfObject.SetObjectID(objectNumber2, generationNumber2);
        if (!fromObjecStream)
        {
          int num2 = (int) this.ReadSymbol(Symbol.EndObj);
        }
        pdfObject1 = pdfObject;
        goto label_37;
      case Symbol.Integer:
        pdfObject = (PdfObject) new PdfIntegerObject(this._document, this._lexer.TokenToInteger);
        pdfObject.SetObjectID(objectNumber2, generationNumber2);
        if (!fromObjecStream)
        {
          int num3 = (int) this.ReadSymbol(Symbol.EndObj);
        }
        pdfObject1 = pdfObject;
        goto label_37;
      case Symbol.UInteger:
        pdfObject = (PdfObject) new PdfUIntegerObject(this._document, this._lexer.TokenToUInteger);
        pdfObject.SetObjectID(objectNumber2, generationNumber2);
        if (!fromObjecStream)
        {
          int num4 = (int) this.ReadSymbol(Symbol.EndObj);
        }
        pdfObject1 = pdfObject;
        goto label_37;
      case Symbol.Real:
        pdfObject = (PdfObject) new PdfRealObject(this._document, this._lexer.TokenToReal);
        pdfObject.SetObjectID(objectNumber2, generationNumber2);
        if (!fromObjecStream)
        {
          int num5 = (int) this.ReadSymbol(Symbol.EndObj);
        }
        pdfObject1 = pdfObject;
        goto label_37;
      case Symbol.Boolean:
        pdfObject = (PdfObject) new PdfBooleanObject(this._document, string.Compare(this._lexer.Token, bool.TrueString, StringComparison.OrdinalIgnoreCase) == 0);
        pdfObject.SetObjectID(objectNumber2, generationNumber2);
        if (!fromObjecStream)
        {
          int num6 = (int) this.ReadSymbol(Symbol.EndObj);
        }
        pdfObject1 = pdfObject;
        goto label_37;
      case Symbol.String:
      case Symbol.HexString:
      case Symbol.UnicodeString:
      case Symbol.UnicodeHexString:
        pdfObject = (PdfObject) new PdfStringObject(this._document, this._lexer.Token);
        pdfObject.SetObjectID(objectNumber2, generationNumber2);
        if (!fromObjecStream)
        {
          int num7 = (int) this.ReadSymbol(Symbol.EndObj);
        }
        pdfObject1 = pdfObject;
        goto label_37;
      case Symbol.Name:
        pdfObject = (PdfObject) new PdfNameObject(this._document, this._lexer.Token);
        pdfObject.SetObjectID(objectNumber2, generationNumber2);
        if (!fromObjecStream)
        {
          int num8 = (int) this.ReadSymbol(Symbol.EndObj);
        }
        pdfObject1 = pdfObject;
        goto label_37;
      case Symbol.Keyword:
        ParserDiagnostics.HandleUnexpectedToken(this._lexer.Token);
        break;
      case Symbol.BeginArray:
        pdfObject = (PdfObject) this.ReadArray(pdfObject != null ? (PdfArray) pdfObject : new PdfArray(this._document), includeReferences);
        pdfObject.SetObjectID(objectNumber2, generationNumber2);
        break;
      case Symbol.BeginDictionary:
        PdfDictionary dict = pdfObject != null ? (PdfDictionary) pdfObject : new PdfDictionary(this._document);
        condition = true;
        pdfObject = (PdfObject) this.ReadDictionary(dict, includeReferences);
        pdfObject.SetObjectID(objectNumber2, generationNumber2);
        break;
      case Symbol.EndObj:
        pdfObject = (PdfObject) new PdfNullObject(this._document);
        pdfObject.SetObjectID(objectNumber2, generationNumber2);
        pdfObject1 = pdfObject;
        goto label_37;
      default:
        ParserDiagnostics.HandleUnexpectedToken(this._lexer.Token);
        break;
    }
    Symbol symbol = this.ScanNextToken();
    if (symbol == Symbol.BeginStream)
    {
      PdfDictionary pdfDictionary = (PdfDictionary) pdfObject;
      Debug.Assert(condition, "Unexpected stream...");
      PdfDictionary.PdfStream pdfStream = new PdfDictionary.PdfStream(this._lexer.ReadStream(this.GetStreamLength(pdfDictionary)), pdfDictionary);
      pdfDictionary.Stream = pdfStream;
      int num9 = (int) this.ReadSymbol(Symbol.EndStream);
      symbol = this.ScanNextToken();
    }
    if ((fromObjecStream ? 0 : (symbol != Symbol.EndObj ? 1 : 0)) != 0)
      ParserDiagnostics.ThrowParserException(PSSR.UnexpectedToken(this._lexer.Token));
    pdfObject1 = pdfObject;
label_37:
    return pdfObject1;
  }

  private void ReadStream(PdfDictionary dict)
  {
    Debug.Assert(this._lexer.Symbol == Symbol.BeginStream);
    PdfDictionary.PdfStream pdfStream = new PdfDictionary.PdfStream(this._lexer.ReadStream(this.GetStreamLength(dict)), dict);
    Debug.Assert(dict.Stream == null, "Dictionary already has a stream.");
    dict.Stream = pdfStream;
    int num1 = (int) this.ReadSymbol(Symbol.EndStream);
    int num2 = (int) this.ScanNextToken();
  }

  private int GetStreamLength(PdfDictionary dict)
  {
    PdfItem pdfItem = dict.Elements["/F"] == null ? dict.Elements["/Length"] : throw new NotImplementedException("File streams are not yet implemented.");
    switch (pdfItem)
    {
      case PdfInteger _:
        return Convert.ToInt32((object) pdfItem);
      case PdfReference pdfReference:
        Parser.ParserState state = this.SaveState();
        object obj = (object) this.ReadObject((PdfObject) null, pdfReference.ObjectID, false, false);
        this.RestoreState(state);
        int streamLength = ((PdfIntegerObject) obj).Value;
        dict.Elements["/Length"] = (PdfItem) new PdfInteger(streamLength);
        return streamLength;
      default:
        throw new InvalidOperationException("Cannot retrieve stream length.");
    }
  }

  public PdfArray ReadArray(PdfArray array, bool includeReferences)
  {
    Debug.Assert(this.Symbol == Symbol.BeginArray);
    if (array == null)
      array = new PdfArray(this._document);
    int sp = this._stack.SP;
    this.ParseObject(Symbol.EndArray);
    int num = this._stack.SP - sp;
    PdfItem[] array1 = this._stack.ToArray(sp, num);
    this._stack.Reduce(num);
    for (int index = 0; index < num; ++index)
    {
      PdfItem iref = array1[index];
      if ((!includeReferences ? 0 : (iref is PdfReference ? 1 : 0)) != 0)
        iref = this.ReadReference((PdfReference) iref, true);
      array.Elements.Add(iref);
    }
    return array;
  }

  internal PdfDictionary ReadDictionary(PdfDictionary dict, bool includeReferences)
  {
    Debug.Assert(this.Symbol == Symbol.BeginDictionary);
    if (dict == null)
      dict = new PdfDictionary(this._document);
    DictionaryMeta meta = dict.Meta;
    int sp = this._stack.SP;
    this.ParseObject(Symbol.EndDictionary);
    int num = this._stack.SP - sp;
    Debug.Assert(num % 2 == 0);
    PdfItem[] array = this._stack.ToArray(sp, num);
    this._stack.Reduce(num);
    for (int index = 0; index < num; index += 2)
    {
      PdfItem pdfItem = array[index];
      if (!(pdfItem is PdfName))
        ParserDiagnostics.ThrowParserException("name expected");
      string key = pdfItem.ToString();
      PdfItem iref = array[index + 1];
      if ((!includeReferences ? 0 : (iref is PdfReference ? 1 : 0)) != 0)
        iref = this.ReadReference((PdfReference) iref, true);
      dict.Elements[key] = iref;
    }
    return dict;
  }

  private void ParseObject(Symbol stop)
  {
    Symbol symbol;
    while ((symbol = this.ScanNextToken()) != Symbol.Eof)
    {
      if (symbol == stop)
        return;
      switch (symbol)
      {
        case Symbol.Comment:
          continue;
        case Symbol.Null:
          this._stack.Shift((PdfItem) PdfNull.Value);
          continue;
        case Symbol.Integer:
          this._stack.Shift((PdfItem) new PdfInteger(this._lexer.TokenToInteger));
          continue;
        case Symbol.UInteger:
          this._stack.Shift((PdfItem) new PdfUInteger(this._lexer.TokenToUInteger));
          continue;
        case Symbol.Real:
          this._stack.Shift((PdfItem) new PdfReal(this._lexer.TokenToReal));
          continue;
        case Symbol.Boolean:
          this._stack.Shift((PdfItem) new PdfBoolean(this._lexer.TokenToBoolean));
          continue;
        case Symbol.String:
          this._stack.Shift((PdfItem) new PdfString(this._lexer.Token, PdfStringFlags.RawEncoding));
          continue;
        case Symbol.HexString:
          this._stack.Shift((PdfItem) new PdfString(this._lexer.Token, PdfStringFlags.HexLiteral));
          continue;
        case Symbol.UnicodeString:
          this._stack.Shift((PdfItem) new PdfString(this._lexer.Token, PdfStringFlags.Unicode));
          continue;
        case Symbol.UnicodeHexString:
          this._stack.Shift((PdfItem) new PdfString(this._lexer.Token, PdfStringFlags.Unicode | PdfStringFlags.HexLiteral));
          continue;
        case Symbol.Name:
          this._stack.Shift((PdfItem) new PdfName(this._lexer.Token));
          continue;
        case Symbol.BeginStream:
          throw new NotImplementedException();
        case Symbol.BeginArray:
          PdfArray array = new PdfArray(this._document);
          this.ReadArray(array, false);
          this._stack.Shift((PdfItem) array);
          continue;
        case Symbol.BeginDictionary:
          PdfDictionary dict = new PdfDictionary(this._document);
          this.ReadDictionary(dict, false);
          this._stack.Shift((PdfItem) dict);
          continue;
        case Symbol.R:
          Debug.Assert(this._stack.GetItem(-1) is PdfInteger && this._stack.GetItem(-2) is PdfInteger);
          PdfObjectID objectID = new PdfObjectID(this._stack.GetInteger(-2), this._stack.GetInteger(-1));
          PdfReference pdfReference = this._document._irefTable[objectID];
          if (pdfReference == null)
          {
            if (this._document._irefTable.IsUnderConstruction)
            {
              this._stack.Reduce((PdfItem) new PdfReference(objectID, 0), 2);
              continue;
            }
            this._stack.Reduce((PdfItem) PdfNull.Value, 2);
            continue;
          }
          this._stack.Reduce((PdfItem) pdfReference, 2);
          continue;
        default:
          ParserDiagnostics.HandleUnexpectedToken(this._lexer.Token);
          int num = (int) this.SkipCharsUntil(stop);
          return;
      }
    }
    ParserDiagnostics.ThrowParserException("Unexpected end of file.");
  }

  private Symbol ScanNextToken() => this._lexer.ScanNextToken();

  private Symbol ScanNextToken(out string token)
  {
    Symbol symbol = this._lexer.ScanNextToken();
    token = this._lexer.Token;
    return symbol;
  }

  private Symbol SkipCharsUntil(Symbol stop)
  {
    Symbol symbol1;
    if (stop != Symbol.EndDictionary)
    {
      Symbol symbol2;
      do
      {
        symbol2 = this.ScanNextToken();
      }
      while ((symbol2 == stop ? 0 : (symbol2 != Symbol.Eof ? 1 : 0)) != 0);
      symbol1 = symbol2;
    }
    else
      symbol1 = this.SkipCharsUntil(">>", stop);
    return symbol1;
  }

  private Symbol SkipCharsUntil(string text, Symbol stop)
  {
    int length = text.Length;
    int index = 0;
    char ch;
    Symbol symbol;
    while ((ch = this._lexer.ScanNextChar(true)) != char.MaxValue)
    {
      if ((int) ch == (int) text[index])
      {
        if (index + 1 != length)
        {
          ++index;
        }
        else
        {
          int num = (int) this._lexer.ScanNextChar(true);
          symbol = stop;
          goto label_8;
        }
      }
      else
        index = 0;
    }
    symbol = Symbol.Eof;
label_8:
    return symbol;
  }

  private void ReadObjectID(PdfObject obj)
  {
    int objectNumber = this.ReadInteger();
    int generationNumber = this.ReadInteger();
    int num = (int) this.ReadSymbol(Symbol.Obj);
    obj?.SetObjectID(objectNumber, generationNumber);
  }

  private PdfItem ReadReference(PdfReference iref, bool includeReferences)
  {
    throw new NotImplementedException(nameof (ReadReference));
  }

  private Symbol ReadSymbol(Symbol symbol)
  {
    if (symbol == Symbol.EndStream)
    {
      while (true)
      {
        char nonWhiteSpace = this._lexer.MoveToNonWhiteSpace();
        if (nonWhiteSpace == char.MaxValue)
          goto label_3;
label_1:
        if (nonWhiteSpace != 'e')
        {
          int num = (int) this._lexer.ScanNextChar(false);
          continue;
        }
        break;
label_3:
        ParserDiagnostics.HandleUnexpectedCharacter(nonWhiteSpace);
        goto label_1;
      }
    }
    Symbol symbol1 = this._lexer.ScanNextToken();
    if (symbol != symbol1)
      ParserDiagnostics.HandleUnexpectedToken(this._lexer.Token);
    return symbol1;
  }

  private Symbol ReadToken(string token)
  {
    Symbol symbol = this._lexer.ScanNextToken();
    if (token != this._lexer.Token)
      ParserDiagnostics.HandleUnexpectedToken(this._lexer.Token);
    return symbol;
  }

  private string ReadName()
  {
    string token;
    if (this.ScanNextToken(out token) != Symbol.Name)
      ParserDiagnostics.HandleUnexpectedToken(token);
    return token;
  }

  private int ReadInteger(bool canBeIndirect)
  {
    int num1;
    switch (this._lexer.ScanNextToken())
    {
      case Symbol.Integer:
        num1 = this._lexer.TokenToInteger;
        break;
      case Symbol.R:
        int position = this._lexer.Position;
        this.ReadObjectID((PdfObject) null);
        int num2 = this.ReadInteger();
        int num3 = (int) this.ReadSymbol(Symbol.EndObj);
        this._lexer.Position = position;
        num1 = num2;
        break;
      default:
        ParserDiagnostics.HandleUnexpectedToken(this._lexer.Token);
        num1 = 0;
        break;
    }
    return num1;
  }

  private int ReadInteger() => this.ReadInteger(false);

  public static PdfObject ReadObject(PdfDocument owner, PdfObjectID objectID)
  {
    return owner != null ? new Parser(owner).ReadObject((PdfObject) null, objectID, false, false) : throw new ArgumentNullException(nameof (owner));
  }

  internal void ReadIRefsFromCompressedObject(PdfObjectID objectID)
  {
    Debug.Assert(this._document._irefTable.ObjectTable.ContainsKey(objectID));
    PdfReference pdfReference;
    if (!this._document._irefTable.ObjectTable.TryGetValue(objectID, out pdfReference))
      throw new NotImplementedException("This case is not coded or something else went wrong");
    if (pdfReference.Value == null)
    {
      try
      {
        Debug.Assert(this._document._irefTable.Contains(pdfReference.ObjectID));
        PdfObjectStream pdfObjectStream = new PdfObjectStream((PdfDictionary) this.ReadObject((PdfObject) null, pdfReference.ObjectID, false, false));
        Debug.Assert(pdfObjectStream.Reference == pdfReference);
        Debug.Assert(pdfObjectStream.Reference.Value != null, "Something went wrong.");
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message);
        throw;
      }
    }
    Debug.Assert(pdfReference.Value != null);
    if (!(pdfReference.Value is PdfObjectStream pdfObjectStream1))
    {
      Debug.Assert(((PdfDictionary) pdfReference.Value).Elements.GetName("/Type") == "/ObjStm");
      pdfObjectStream1 = new PdfObjectStream((PdfDictionary) pdfReference.Value);
      Debug.Assert(pdfObjectStream1.Reference == pdfReference);
      Debug.Assert(pdfObjectStream1.Reference.Value != null, "Something went wrong.");
    }
    Debug.Assert(pdfObjectStream1 != null);
    if (pdfObjectStream1 == null)
      throw new Exception("Something went wrong here.");
    pdfObjectStream1.ReadReferences(this._document._irefTable);
  }

  internal PdfReference ReadCompressedObject(PdfObjectID objectID, int index)
  {
    Debug.Assert(this._document._irefTable.ObjectTable.ContainsKey(objectID));
    PdfReference pdfReference;
    if (!this._document._irefTable.ObjectTable.TryGetValue(objectID, out pdfReference))
      throw new NotImplementedException("This case is not coded or something else went wrong");
    if (pdfReference.Value == null)
    {
      try
      {
        Debug.Assert(this._document._irefTable.Contains(pdfReference.ObjectID));
        PdfObjectStream pdfObjectStream = new PdfObjectStream((PdfDictionary) this.ReadObject((PdfObject) null, pdfReference.ObjectID, false, false));
        Debug.Assert(pdfObjectStream.Reference == pdfReference);
        Debug.Assert(pdfObjectStream.Reference.Value != null, "Something went wrong.");
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message);
        throw;
      }
    }
    Debug.Assert(pdfReference.Value != null);
    if (!(pdfReference.Value is PdfObjectStream pdfObjectStream1))
    {
      Debug.Assert(((PdfDictionary) pdfReference.Value).Elements.GetName("/Type") == "/ObjStm");
      pdfObjectStream1 = new PdfObjectStream((PdfDictionary) pdfReference.Value);
      Debug.Assert(pdfObjectStream1.Reference == pdfReference);
      Debug.Assert(pdfObjectStream1.Reference.Value != null, "Something went wrong.");
    }
    Debug.Assert(pdfObjectStream1 != null);
    return pdfObjectStream1 != null ? pdfObjectStream1.ReadCompressedObject(index) : throw new Exception("Something went wrong here.");
  }

  internal PdfReference ReadCompressedObject(int objectNumber, int offset)
  {
    PdfObjectID objectID = new PdfObjectID(objectNumber);
    this._lexer.Position = offset;
    return this.ReadObject((PdfObject) null, objectID, false, true).Reference;
  }

  internal int[][] ReadObjectStreamHeader(int n, int first)
  {
    int[][] numArray = new int[n][];
    for (int index = 0; index < n; ++index)
    {
      int num1 = this.ReadInteger();
      if (num1 == 1074)
        this.GetType();
      int num2 = this.ReadInteger() + first;
      numArray[index] = new int[2]{ num1, num2 };
    }
    return numArray;
  }

  internal PdfTrailer ReadTrailer()
  {
    int pdfLength = this._lexer.PdfLength;
    int num1;
    if (pdfLength < 1030)
    {
      num1 = this._lexer.ReadRawString(pdfLength - 31 /*0x1F*/, 30).LastIndexOf("startxref", StringComparison.Ordinal);
      this._lexer.Position = pdfLength - 31 /*0x1F*/ + num1;
    }
    else
    {
      num1 = this._lexer.ReadRawString(pdfLength - 1031, 1030).LastIndexOf("startxref", StringComparison.Ordinal);
      this._lexer.Position = pdfLength - 1031 + num1;
    }
    if (num1 == -1)
    {
      num1 = this._lexer.ReadRawString(0, pdfLength).LastIndexOf("startxref", StringComparison.Ordinal);
      this._lexer.Position = num1;
    }
    if (num1 == -1)
      throw new Exception("The StartXRef table could not be found, the file cannot be opened.");
    int num2 = (int) this.ReadSymbol(Symbol.StartXRef);
    this._lexer.Position = this.ReadInteger();
    while (true)
    {
      PdfTrailer pdfTrailer = this.ReadXRefTableAndTrailer(this._document._irefTable);
      if (this._document._trailer == null)
        goto label_10;
label_8:
      int integer = pdfTrailer.Elements.GetInteger("/Prev");
      if (integer != 0)
      {
        this._lexer.Position = integer;
        continue;
      }
      break;
label_10:
      this._document._trailer = pdfTrailer;
      goto label_8;
    }
    return this._document._trailer;
  }

  private PdfTrailer ReadXRefTableAndTrailer(PdfCrossReferenceTable xrefTable)
  {
    Debug.Assert(xrefTable != null);
    PdfTrailer pdfTrailer;
    switch (this.ScanNextToken())
    {
      case Symbol.Integer:
        pdfTrailer = this.ReadXRefStream(xrefTable);
        break;
      case Symbol.XRef:
        while (true)
        {
          switch (this.ScanNextToken())
          {
            case Symbol.Integer:
              goto label_2;
            case Symbol.Trailer:
              goto label_9;
            default:
              ParserDiagnostics.HandleUnexpectedToken(this._lexer.Token);
              continue;
          }
        }
label_2:
        int tokenToInteger = this._lexer.TokenToInteger;
        int num1 = this.ReadInteger();
        for (int objectNumber = tokenToInteger; objectNumber < tokenToInteger + num1; ++objectNumber)
        {
          int position = this.ReadInteger();
          int generationNumber = this.ReadInteger();
          int num2 = (int) this.ReadSymbol(Symbol.Keyword);
          string token = this._lexer.Token;
          if (objectNumber != 0 && !(token != "n"))
          {
            PdfObjectID objectID = new PdfObjectID(objectNumber, generationNumber);
            if (!xrefTable.Contains(objectID))
              xrefTable.Add(new PdfReference(objectID, position));
          }
        }
        goto case Symbol.XRef;
label_9:
        int num3 = (int) this.ReadSymbol(Symbol.BeginDictionary);
        PdfTrailer dict = new PdfTrailer(this._document);
        this.ReadDictionary((PdfDictionary) dict, false);
        pdfTrailer = dict;
        break;
      default:
        pdfTrailer = (PdfTrailer) null;
        break;
    }
    return pdfTrailer;
  }

  private PdfTrailer ReadXRefStream(PdfCrossReferenceTable xrefTable)
  {
    int tokenToInteger = this._lexer.TokenToInteger;
    int generationNumber = this.ReadInteger();
    Debug.Assert(generationNumber == 0);
    int num1 = (int) this.ReadSymbol(Symbol.Obj);
    int num2 = (int) this.ReadSymbol(Symbol.BeginDictionary);
    PdfObjectID pdfObjectId = new PdfObjectID(tokenToInteger, generationNumber);
    PdfCrossReferenceStream dict = new PdfCrossReferenceStream(this._document);
    this.ReadDictionary((PdfDictionary) dict, false);
    int num3 = (int) this.ReadSymbol(Symbol.BeginStream);
    this.ReadStream((PdfDictionary) dict);
    xrefTable.Add(new PdfReference((PdfObject) dict)
    {
      ObjectID = pdfObjectId,
      Value = (PdfObject) dict
    });
    Debug.Assert(dict.Stream != null);
    byte[] unfilteredValue = dict.Stream.UnfilteredValue;
    byte[] bytes = unfilteredValue;
    if (dict.Stream.HasDecodeParams)
    {
      int decodePredictor = dict.Stream.DecodePredictor;
      int decodeColumns = dict.Stream.DecodeColumns;
      bytes = this.DecodeCrossReferenceStream(unfilteredValue, decodeColumns, decodePredictor);
    }
    int integer = dict.Elements.GetInteger("/Size");
    PdfArray pdfArray1 = dict.Elements.GetValue("/Index") as PdfArray;
    dict.Elements.GetInteger("/Prev");
    PdfArray pdfArray2 = (PdfArray) dict.Elements.GetValue("/W");
    int num4 = 0;
    int length;
    int[][] numArray;
    if (pdfArray1 == null)
    {
      length = 1;
      numArray = new int[1][]{ new int[2]{ 0, integer } };
      num4 = integer;
    }
    else
    {
      Debug.Assert(pdfArray1.Elements.Count % 2 == 0);
      length = pdfArray1.Elements.Count / 2;
      numArray = new int[length][];
      for (int index = 0; index < length; ++index)
      {
        numArray[index] = new int[2]
        {
          pdfArray1.Elements.GetInteger(2 * index),
          pdfArray1.Elements.GetInteger(2 * index + 1)
        };
        num4 += numArray[index][1];
      }
    }
    Debug.Assert(pdfArray2.Elements.Count == 3);
    int[] w = new int[3]
    {
      pdfArray2.Elements.GetInteger(0),
      pdfArray2.Elements.GetInteger(1),
      pdfArray2.Elements.GetInteger(2)
    };
    int num5 = StreamHelper.WSize(w);
    if (num5 * num4 != bytes.Length)
      this.GetType();
    Debug.Assert(num5 * num4 == bytes.Length, "Check implementation here.");
    int num6 = numArray[0][1];
    if (PdfDiagnostics.TraceXrefStreams)
    {
      for (int index = 0; index < num6; ++index)
      {
        uint num7 = StreamHelper.ReadBytes(bytes, index * num5, w[0]);
        uint num8 = StreamHelper.ReadBytes(bytes, index * num5 + w[0], w[1]);
        uint num9 = StreamHelper.ReadBytes(bytes, index * num5 + w[0] + w[1], w[2]);
        string str = $"{index,2:00}: {num7} {num8,5} {num9}  // ";
        string message;
        switch (num7)
        {
          case 0:
            message = str + "Fee list: object number, generation number";
            break;
          case 1:
            message = str + "Not compresed: offset, generation number";
            break;
          case 2:
            message = str + "Compressed: object stream object number, index in stream";
            break;
          default:
            message = str + "??? Type undefined";
            break;
        }
        Debug.WriteLine(message);
      }
    }
    int num10 = -1;
    for (int index1 = 0; index1 < length; ++index1)
    {
      int num11 = numArray[index1][1];
      for (int index2 = 0; index2 < num11; ++index2)
      {
        ++num10;
        PdfCrossReferenceStream.CrossReferenceStreamEntry referenceStreamEntry = new PdfCrossReferenceStream.CrossReferenceStreamEntry();
        referenceStreamEntry.Type = StreamHelper.ReadBytes(bytes, num10 * num5, w[0]);
        referenceStreamEntry.Field2 = StreamHelper.ReadBytes(bytes, num10 * num5 + w[0], w[1]);
        referenceStreamEntry.Field3 = StreamHelper.ReadBytes(bytes, num10 * num5 + w[0] + w[1], w[2]);
        dict.Entries.Add(referenceStreamEntry);
        switch (referenceStreamEntry.Type)
        {
          case 1:
            int field2 = (int) referenceStreamEntry.Field2;
            PdfObjectID objectID = this.ReadObjectNumber(field2);
            if (objectID.ObjectNumber == 1074)
              this.GetType();
            Debug.Assert((long) objectID.GenerationNumber == (long) referenceStreamEntry.Field3);
            if (!xrefTable.Contains(objectID))
            {
              this.GetType();
              xrefTable.Add(new PdfReference(objectID, field2));
              break;
            }
            break;
        }
      }
    }
    return (PdfTrailer) dict;
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
        int val1 = 0;
        int day = 0;
        int hour = 0;
        int minute = 0;
        int second = 0;
        int hours = 0;
        int minutes = 0;
        char ch = 'Z';
        if (length >= 10)
        {
          year = int.Parse(date.Substring(2, 4));
          val1 = int.Parse(date.Substring(6, 2));
          day = int.Parse(date.Substring(8, 2));
          if (length >= 16 /*0x10*/)
          {
            hour = int.Parse(date.Substring(10, 2));
            minute = int.Parse(date.Substring(12, 2));
            second = int.Parse(date.Substring(14, 2));
            if (length >= 23 && (ch = date[16 /*0x10*/]) != 'Z')
            {
              hours = int.Parse(date.Substring(17, 2));
              minutes = int.Parse(date.Substring(20, 2));
            }
          }
        }
        int month = Math.Min(Math.Max(val1, 1), 12);
        dateTime = new DateTime(year, month, day, hour, minute, second);
        if (ch != 'Z')
        {
          TimeSpan timeSpan = new TimeSpan(hours, minutes, 0);
          dateTime = ch != '-' ? dateTime.Subtract(timeSpan) : dateTime.Add(timeSpan);
        }
        DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
      }
      else
        dateTime = DateTime.Parse(date, (IFormatProvider) CultureInfo.InvariantCulture);
    }
    catch (Exception ex)
    {
      Debug.Assert(false, ex.Message);
    }
    return dateTime;
  }

  private Parser.ParserState SaveState()
  {
    return new Parser.ParserState()
    {
      Position = this._lexer.Position,
      Symbol = this._lexer.Symbol
    };
  }

  private void RestoreState(Parser.ParserState state)
  {
    this._lexer.Position = state.Position;
    this._lexer.Symbol = state.Symbol;
  }

  private byte[] DecodeCrossReferenceStream(byte[] bytes, int columns, int predictor)
  {
    int length = bytes.Length;
    if ((predictor < 10 ? 1 : (predictor > 15 ? 1 : 0)) != 0)
      throw new ArgumentException("Invalid predictor.", nameof (predictor));
    int num1 = columns + 1;
    if (length % num1 != 0)
      throw new ArgumentException("Columns and size of array do not match.");
    int num2 = length / num1;
    byte[] numArray = new byte[num2 * columns];
    for (int index = 0; index < numArray.Length; ++index)
      numArray[index] = (byte) 88;
    for (int index1 = 0; index1 < num2; ++index1)
    {
      if (bytes[index1 * num1] != (byte) 2)
        throw new ArgumentException("Invalid predictor in array.");
      for (int index2 = 0; index2 < columns; ++index2)
        numArray[index1 * columns + index2] = index1 != 0 ? (byte) ((uint) numArray[index1 * columns - columns + index2] + (uint) bytes[index1 * num1 + index2 + 1]) : bytes[index1 * num1 + index2 + 1];
    }
    return numArray;
  }

  private class ParserState
  {
    public int Position;
    public Symbol Symbol;
  }
}
