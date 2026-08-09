#define DEBUG
using System.Diagnostics;
using System.IO;
using PdfSharp.Internal;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Content.Objects;

namespace PdfSharp.Pdf.Content;

public sealed class CParser
{
	private readonly CSequence _operands = new CSequence();

	private PdfPage _page;

	private readonly CLexer _lexer;

	public CSymbol Symbol => _lexer.Symbol;

	public CParser(PdfPage page)
	{
		_page = page;
		PdfContent pdfContent = page.Contents.CreateSingleContent();
		byte[] value = pdfContent.Stream.Value;
		_lexer = new CLexer(value);
	}

	public CParser(byte[] content)
	{
		_lexer = new CLexer(content);
	}

	public CParser(MemoryStream content)
	{
		_lexer = new CLexer(content.ToArray());
	}

	public CParser(CLexer lexer)
	{
		_lexer = lexer;
	}

	public CSequence ReadContent()
	{
		CSequence cSequence = new CSequence();
		ParseObject(cSequence, CSymbol.Eof);
		return cSequence;
	}

	private void ParseObject(CSequence sequence, CSymbol stop)
	{
		CSymbol cSymbol;
		while ((cSymbol = ScanNextToken()) != CSymbol.Eof && cSymbol != stop)
		{
			switch (cSymbol)
			{
			case CSymbol.Integer:
			{
				CInteger cInteger = new CInteger();
				cInteger.Value = _lexer.TokenToInteger;
				_operands.Add(cInteger);
				break;
			}
			case CSymbol.Real:
			{
				CReal cReal = new CReal();
				cReal.Value = _lexer.TokenToReal;
				_operands.Add(cReal);
				break;
			}
			case CSymbol.String:
			case CSymbol.HexString:
			case CSymbol.UnicodeString:
			case CSymbol.UnicodeHexString:
			{
				CString cString = new CString();
				cString.Value = _lexer.Token;
				_operands.Add(cString);
				break;
			}
			case CSymbol.Dictionary:
			{
				CString cString = new CString();
				cString.Value = _lexer.Token;
				cString.CStringType = CStringType.Dictionary;
				_operands.Add(cString);
				COperator value = CreateOperator(OpCodeName.Dictionary);
				sequence.Add(value);
				break;
			}
			case CSymbol.Name:
			{
				CName cName = new CName();
				cName.Name = _lexer.Token;
				_operands.Add(cName);
				break;
			}
			case CSymbol.Operator:
			{
				COperator value = CreateOperator();
				sequence.Add(value);
				break;
			}
			case CSymbol.BeginArray:
			{
				CArray cArray = new CArray();
				if (_operands.Count != 0)
				{
					ContentReaderDiagnostics.ThrowContentReaderException("Array within array...");
				}
				ParseObject(cArray, CSymbol.EndArray);
				cArray.Add(_operands);
				_operands.Clear();
				_operands.Add((CObject)cArray);
				break;
			}
			case CSymbol.EndArray:
				ContentReaderDiagnostics.HandleUnexpectedCharacter(']');
				break;
			default:
				Debug.Assert(condition: false);
				break;
			case CSymbol.Comment:
				break;
			}
		}
	}

	private COperator CreateOperator()
	{
		string token = _lexer.Token;
		COperator op = OpCodes.OperatorFromName(token);
		return CreateOperator(op);
	}

	private COperator CreateOperator(OpCodeName nameop)
	{
		string name = nameop.ToString();
		COperator op = OpCodes.OperatorFromName(name);
		return CreateOperator(op);
	}

	private COperator CreateOperator(COperator op)
	{
		if (op.OpCode.OpCodeName == OpCodeName.BI)
		{
			_lexer.ScanInlineImage();
		}
		if (op.OpCode.Operands != -1 && op.OpCode.Operands != _operands.Count && op.OpCode.OpCodeName != OpCodeName.ID)
		{
			GetType();
			Debug.Assert(condition: false, "Invalid number of operands.");
		}
		op.Operands.Add(_operands);
		_operands.Clear();
		return op;
	}

	private CSymbol ScanNextToken()
	{
		return _lexer.ScanNextToken();
	}

	private CSymbol ScanNextToken(out string token)
	{
		CSymbol result = _lexer.ScanNextToken();
		token = _lexer.Token;
		return result;
	}

	private CSymbol ReadSymbol(CSymbol symbol)
	{
		CSymbol cSymbol = _lexer.ScanNextToken();
		if (symbol != cSymbol)
		{
			ContentReaderDiagnostics.ThrowContentReaderException(PSSR.UnexpectedToken(_lexer.Token));
		}
		return cSymbol;
	}
}
