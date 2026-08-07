// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Content.CParser
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Internal;
using PdfSharp.Pdf.Content.Objects;
using System.Diagnostics;
using System.IO;

#nullable disable
namespace PdfSharp.Pdf.Content;

public sealed class CParser
{
  private readonly CSequence _operands = new CSequence();
  private PdfPage _page;
  private readonly CLexer _lexer;

  public CParser(PdfPage page)
  {
    this._page = page;
    this._lexer = new CLexer(page.Contents.CreateSingleContent().Stream.Value);
  }

  public CParser(byte[] content) => this._lexer = new CLexer(content);

  public CParser(MemoryStream content) => this._lexer = new CLexer(content.ToArray());

  public CParser(CLexer lexer) => this._lexer = lexer;

  public CSymbol Symbol => this._lexer.Symbol;

  public CSequence ReadContent()
  {
    CSequence sequence = new CSequence();
    this.ParseObject(sequence, CSymbol.Eof);
    return sequence;
  }

  private void ParseObject(CSequence sequence, CSymbol stop)
  {
    CSymbol csymbol;
    while ((csymbol = this.ScanNextToken()) != CSymbol.Eof && csymbol != stop)
    {
      switch (csymbol)
      {
        case CSymbol.Comment:
          continue;
        case CSymbol.Integer:
          this._operands.Add((CObject) new CInteger()
          {
            Value = this._lexer.TokenToInteger
          });
          continue;
        case CSymbol.Real:
          this._operands.Add((CObject) new CReal()
          {
            Value = this._lexer.TokenToReal
          });
          continue;
        case CSymbol.String:
        case CSymbol.HexString:
        case CSymbol.UnicodeString:
        case CSymbol.UnicodeHexString:
          this._operands.Add((CObject) new CString()
          {
            Value = this._lexer.Token
          });
          continue;
        case CSymbol.Name:
          this._operands.Add((CObject) new CName()
          {
            Name = this._lexer.Token
          });
          continue;
        case CSymbol.Operator:
          COperator coperator1 = this.CreateOperator();
          sequence.Add((CObject) coperator1);
          continue;
        case CSymbol.BeginArray:
          CArray sequence1 = new CArray();
          if (this._operands.Count != 0)
            ContentReaderDiagnostics.ThrowContentReaderException("Array within array...");
          this.ParseObject((CSequence) sequence1, CSymbol.EndArray);
          sequence1.Add(this._operands);
          this._operands.Clear();
          this._operands.Add((CObject) sequence1);
          continue;
        case CSymbol.EndArray:
          ContentReaderDiagnostics.HandleUnexpectedCharacter(']');
          continue;
        case CSymbol.Dictionary:
          this._operands.Add((CObject) new CString()
          {
            Value = this._lexer.Token,
            CStringType = CStringType.Dictionary
          });
          COperator coperator2 = this.CreateOperator(OpCodeName.Dictionary);
          sequence.Add((CObject) coperator2);
          continue;
        default:
          Debug.Assert(false);
          continue;
      }
    }
  }

  private COperator CreateOperator()
  {
    return this.CreateOperator(OpCodes.OperatorFromName(this._lexer.Token));
  }

  private COperator CreateOperator(OpCodeName nameop)
  {
    return this.CreateOperator(OpCodes.OperatorFromName(nameop.ToString()));
  }

  private COperator CreateOperator(COperator op)
  {
    if (op.OpCode.OpCodeName == OpCodeName.BI)
    {
      int num = (int) this._lexer.ScanInlineImage();
    }
    if ((op.OpCode.Operands == -1 ? 0 : (op.OpCode.Operands != this._operands.Count ? 1 : 0)) != 0 && op.OpCode.OpCodeName != OpCodeName.ID)
    {
      this.GetType();
      Debug.Assert(false, "Invalid number of operands.");
    }
    op.Operands.Add(this._operands);
    this._operands.Clear();
    return op;
  }

  private CSymbol ScanNextToken() => this._lexer.ScanNextToken();

  private CSymbol ScanNextToken(out string token)
  {
    CSymbol csymbol = this._lexer.ScanNextToken();
    token = this._lexer.Token;
    return csymbol;
  }

  private CSymbol ReadSymbol(CSymbol symbol)
  {
    CSymbol csymbol = this._lexer.ScanNextToken();
    if (symbol != csymbol)
      ContentReaderDiagnostics.ThrowContentReaderException(PSSR.UnexpectedToken(this._lexer.Token));
    return csymbol;
  }
}
