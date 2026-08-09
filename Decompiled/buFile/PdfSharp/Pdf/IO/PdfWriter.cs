#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Internal;
using PdfSharp.Pdf.Security;

namespace PdfSharp.Pdf.IO;

internal class PdfWriter
{
	private enum CharCat
	{
		NewLine,
		Character,
		Delimiter
	}

	private class StackItem
	{
		public readonly PdfObject Object;

		public bool HasStream;

		public StackItem(PdfObject value)
		{
			Object = value;
		}
	}

	private PdfWriterLayout _layout;

	private PdfWriterOptions _options;

	private int _indent = 2;

	private int _writeIndent;

	private CharCat _lastCat;

	private Stream _stream;

	private PdfStandardSecurityHandler _securityHandler;

	private readonly List<StackItem> _stack = new List<StackItem>();

	private int _commentPosition;

	public int Position => (int)_stream.Position;

	public PdfWriterLayout Layout
	{
		get
		{
			return _layout;
		}
		set
		{
			_layout = value;
		}
	}

	public PdfWriterOptions Options
	{
		get
		{
			return _options;
		}
		set
		{
			_options = value;
		}
	}

	internal int Indent
	{
		get
		{
			return _indent;
		}
		set
		{
			_indent = value;
		}
	}

	private string IndentBlanks => new string(' ', _writeIndent);

	internal Stream Stream => _stream;

	internal PdfStandardSecurityHandler SecurityHandler
	{
		get
		{
			return _securityHandler;
		}
		set
		{
			_securityHandler = value;
		}
	}

	public PdfWriter(Stream pdfStream, PdfStandardSecurityHandler securityHandler)
	{
		_stream = pdfStream;
		_securityHandler = securityHandler;
		_layout = PdfWriterLayout.Verbose;
	}

	public void Close(bool closeUnderlyingStream)
	{
		if (_stream != null && closeUnderlyingStream)
		{
			_stream.Close();
		}
		_stream = null;
	}

	public void Close()
	{
		Close(closeUnderlyingStream: true);
	}

	public void Write(bool value)
	{
		WriteSeparator(CharCat.Character);
		WriteRaw(value ? bool.TrueString : bool.FalseString);
		_lastCat = CharCat.Character;
	}

	public void Write(PdfBoolean value)
	{
		WriteSeparator(CharCat.Character);
		WriteRaw(value.Value ? "true" : "false");
		_lastCat = CharCat.Character;
	}

	public void Write(int value)
	{
		WriteSeparator(CharCat.Character);
		WriteRaw(value.ToString(CultureInfo.InvariantCulture));
		_lastCat = CharCat.Character;
	}

	public void Write(uint value)
	{
		WriteSeparator(CharCat.Character);
		WriteRaw(value.ToString(CultureInfo.InvariantCulture));
		_lastCat = CharCat.Character;
	}

	public void Write(PdfInteger value)
	{
		WriteSeparator(CharCat.Character);
		_lastCat = CharCat.Character;
		WriteRaw(value.Value.ToString(CultureInfo.InvariantCulture));
	}

	public void Write(PdfUInteger value)
	{
		WriteSeparator(CharCat.Character);
		_lastCat = CharCat.Character;
		WriteRaw(value.Value.ToString(CultureInfo.InvariantCulture));
	}

	public void Write(double value)
	{
		WriteSeparator(CharCat.Character);
		WriteRaw(value.ToString("0.#######", CultureInfo.InvariantCulture));
		_lastCat = CharCat.Character;
	}

	public void Write(PdfReal value)
	{
		WriteSeparator(CharCat.Character);
		WriteRaw(value.Value.ToString("0.#######", CultureInfo.InvariantCulture));
		_lastCat = CharCat.Character;
	}

	public void Write(PdfString value)
	{
		WriteSeparator(CharCat.Delimiter);
		PdfStringEncoding encoding = (PdfStringEncoding)(value.Flags & PdfStringFlags.EncodingMask);
		string rawString = (((value.Flags & PdfStringFlags.HexLiteral) == 0) ? PdfEncoders.ToStringLiteral(value.Value, encoding, SecurityHandler) : PdfEncoders.ToHexStringLiteral(value.Value, encoding, SecurityHandler));
		WriteRaw(rawString);
		_lastCat = CharCat.Delimiter;
	}

	public void Write(PdfName value)
	{
		WriteSeparator(CharCat.Delimiter, '/');
		string value2 = value.Value;
		StringBuilder stringBuilder = new StringBuilder("/");
		for (int i = 1; i < value2.Length; i++)
		{
			char c = value2[i];
			Debug.Assert(c < 'Ā');
			if (c > ' ')
			{
				switch (c)
				{
				default:
					stringBuilder.Append(value2[i]);
					continue;
				case '#':
				case '%':
				case '(':
				case ')':
				case '/':
				case '<':
				case '>':
					break;
				}
			}
			stringBuilder.AppendFormat("#{0:X2}", (int)value2[i]);
		}
		WriteRaw(stringBuilder.ToString());
		_lastCat = CharCat.Character;
	}

	public void Write(PdfLiteral value)
	{
		WriteSeparator(CharCat.Character);
		WriteRaw(value.Value);
		_lastCat = CharCat.Character;
	}

	public void Write(PdfRectangle rect)
	{
		WriteSeparator(CharCat.Delimiter, '/');
		WriteRaw(PdfEncoders.Format("[{0:0.###} {1:0.###} {2:0.###} {3:0.###}]", rect.X1, rect.Y1, rect.X2, rect.Y2));
		_lastCat = CharCat.Delimiter;
	}

	public void Write(PdfReference iref)
	{
		WriteSeparator(CharCat.Character);
		WriteRaw(iref.ToString());
		_lastCat = CharCat.Character;
	}

	public void WriteDocString(string text, bool unicode)
	{
		WriteSeparator(CharCat.Delimiter);
		byte[] bytes = (unicode ? PdfEncoders.UnicodeEncoding.GetBytes(text) : PdfEncoders.DocEncoding.GetBytes(text));
		bytes = PdfEncoders.FormatStringLiteral(bytes, unicode, prefix: true, hex: false, _securityHandler);
		Write(bytes);
		_lastCat = CharCat.Delimiter;
	}

	public void WriteDocString(string text)
	{
		WriteSeparator(CharCat.Delimiter);
		byte[] bytes = PdfEncoders.DocEncoding.GetBytes(text);
		bytes = PdfEncoders.FormatStringLiteral(bytes, unicode: false, prefix: false, hex: false, _securityHandler);
		Write(bytes);
		_lastCat = CharCat.Delimiter;
	}

	public void WriteDocStringHex(string text)
	{
		WriteSeparator(CharCat.Delimiter);
		byte[] bytes = PdfEncoders.DocEncoding.GetBytes(text);
		bytes = PdfEncoders.FormatStringLiteral(bytes, unicode: false, prefix: false, hex: true, _securityHandler);
		_stream.Write(bytes, 0, bytes.Length);
		_lastCat = CharCat.Delimiter;
	}

	public void WriteBeginObject(PdfObject obj)
	{
		bool isIndirect = obj.IsIndirect;
		if (isIndirect)
		{
			WriteObjectAddress(obj);
			if (_securityHandler != null)
			{
				_securityHandler.SetHashKey(obj.ObjectID);
			}
		}
		_stack.Add(new StackItem(obj));
		if (isIndirect)
		{
			if (obj is PdfArray)
			{
				WriteRaw("[\n");
			}
			else if (obj is PdfDictionary)
			{
				WriteRaw("<<\n");
			}
			_lastCat = CharCat.NewLine;
		}
		else if (obj is PdfArray)
		{
			WriteSeparator(CharCat.Delimiter);
			WriteRaw('[');
			_lastCat = CharCat.Delimiter;
		}
		else if (obj is PdfDictionary)
		{
			NewLine();
			WriteSeparator(CharCat.Delimiter);
			WriteRaw("<<\n");
			_lastCat = CharCat.NewLine;
		}
		if (_layout == PdfWriterLayout.Verbose)
		{
			IncreaseIndent();
		}
	}

	public void WriteEndObject()
	{
		int count = _stack.Count;
		Debug.Assert(count > 0, "PdfWriter stack underflow.");
		StackItem stackItem = _stack[count - 1];
		_stack.RemoveAt(count - 1);
		PdfObject pdfObject = stackItem.Object;
		bool isIndirect = pdfObject.IsIndirect;
		if (_layout == PdfWriterLayout.Verbose)
		{
			DecreaseIndent();
		}
		if (pdfObject is PdfArray)
		{
			if (isIndirect)
			{
				WriteRaw("\n]\n");
				_lastCat = CharCat.NewLine;
			}
			else
			{
				WriteRaw("]");
				_lastCat = CharCat.Delimiter;
			}
		}
		else if (pdfObject is PdfDictionary)
		{
			if (isIndirect)
			{
				if (!stackItem.HasStream)
				{
					WriteRaw((_lastCat == CharCat.NewLine) ? ">>\n" : " >>\n");
				}
			}
			else
			{
				Debug.Assert(!stackItem.HasStream, "Direct object with stream??");
				WriteSeparator(CharCat.NewLine);
				WriteRaw(">>\n");
				_lastCat = CharCat.NewLine;
			}
		}
		if (isIndirect)
		{
			NewLine();
			WriteRaw("endobj\n");
			if (_layout == PdfWriterLayout.Verbose)
			{
				WriteRaw("%--------------------------------------------------------------------------------------------------\n");
			}
		}
	}

	public void WriteStream(PdfDictionary value, bool omitStream)
	{
		StackItem stackItem = _stack[_stack.Count - 1];
		Debug.Assert(stackItem.Object is PdfDictionary);
		Debug.Assert(stackItem.Object.IsIndirect);
		stackItem.HasStream = true;
		WriteRaw((_lastCat == CharCat.NewLine) ? ">>\nstream\n" : " >>\nstream\n");
		if (omitStream)
		{
			WriteRaw("  «...stream content omitted...»\n");
		}
		else
		{
			byte[] array = value.Stream.Value;
			if (array.Length != 0)
			{
				if (_securityHandler != null)
				{
					array = (byte[])array.Clone();
					array = _securityHandler.EncryptBytes(array);
				}
				Write(array);
				if (_lastCat != CharCat.NewLine)
				{
					WriteRaw('\n');
				}
			}
		}
		WriteRaw("endstream\n");
	}

	public void WriteRaw(string rawString)
	{
		if (!string.IsNullOrEmpty(rawString))
		{
			byte[] bytes = PdfEncoders.RawEncoding.GetBytes(rawString);
			_stream.Write(bytes, 0, bytes.Length);
			_lastCat = GetCategory((char)bytes[bytes.Length - 1]);
		}
	}

	public void WriteRaw(char ch)
	{
		Debug.Assert(ch < 'Ā', "Raw character greater than 255 detected.");
		_stream.WriteByte((byte)ch);
		_lastCat = GetCategory(ch);
	}

	public void Write(byte[] bytes)
	{
		if (bytes != null && bytes.Length != 0)
		{
			_stream.Write(bytes, 0, bytes.Length);
			_lastCat = GetCategory((char)bytes[bytes.Length - 1]);
		}
	}

	private void WriteObjectAddress(PdfObject value)
	{
		if (_layout == PdfWriterLayout.Verbose)
		{
			WriteRaw($"{value.ObjectID.ObjectNumber} {value.ObjectID.GenerationNumber} obj   % {value.GetType().FullName}\n");
		}
		else
		{
			WriteRaw($"{value.ObjectID.ObjectNumber} {value.ObjectID.GenerationNumber} obj\n");
		}
	}

	public void WriteFileHeader(PdfDocument document)
	{
		StringBuilder stringBuilder = new StringBuilder("%PDF-");
		int version = document._version;
		stringBuilder.Append((version / 10).ToString(CultureInfo.InvariantCulture) + "." + (version % 10).ToString(CultureInfo.InvariantCulture) + "\n%ÓôÌá\n");
		WriteRaw(stringBuilder.ToString());
		if (_layout == PdfWriterLayout.Verbose)
		{
			WriteRaw(string.Format("% PDFsharp Version {0} (verbose mode)\n", "1.50.4740.0"));
			_commentPosition = (int)_stream.Position + 2;
			WriteRaw("%                                                \n");
			WriteRaw("%                                                \n");
			WriteRaw("%                                                \n");
			WriteRaw("%                                                \n");
			WriteRaw("%                                                \n");
			WriteRaw("%--------------------------------------------------------------------------------------------------\n");
		}
	}

	public void WriteEof(PdfDocument document, int startxref)
	{
		WriteRaw("startxref\n");
		WriteRaw(startxref.ToString(CultureInfo.InvariantCulture));
		WriteRaw("\n%%EOF\n");
		int num = (int)_stream.Position;
		if (_layout == PdfWriterLayout.Verbose)
		{
			TimeSpan timeSpan = DateTime.Now - document._creation;
			_stream.Position = _commentPosition;
			WriteRaw("Creation date: " + document._creation.ToString("G", CultureInfo.InvariantCulture));
			_stream.Position = _commentPosition + 50;
			WriteRaw("Creation time: " + timeSpan.TotalSeconds.ToString("0.000", CultureInfo.InvariantCulture) + " seconds");
			_stream.Position = _commentPosition + 100;
			WriteRaw("File size: " + num.ToString(CultureInfo.InvariantCulture) + " bytes");
			_stream.Position = _commentPosition + 150;
			WriteRaw("Pages: " + document.Pages.Count.ToString(CultureInfo.InvariantCulture));
			_stream.Position = _commentPosition + 200;
			WriteRaw("Objects: " + document._irefTable.ObjectTable.Count.ToString(CultureInfo.InvariantCulture));
		}
	}

	private void IncreaseIndent()
	{
		_writeIndent += _indent;
	}

	private void DecreaseIndent()
	{
		_writeIndent -= _indent;
	}

	private void WriteIndent()
	{
		WriteRaw(IndentBlanks);
	}

	private void WriteSeparator(CharCat cat, char ch)
	{
		switch (_lastCat)
		{
		case CharCat.NewLine:
			if (_layout == PdfWriterLayout.Verbose)
			{
				WriteIndent();
			}
			break;
		case CharCat.Delimiter:
			break;
		case CharCat.Character:
			if (_layout == PdfWriterLayout.Verbose)
			{
				_stream.WriteByte(32);
			}
			else if (cat == CharCat.Character)
			{
				_stream.WriteByte(32);
			}
			break;
		}
	}

	private void WriteSeparator(CharCat cat)
	{
		WriteSeparator(cat, '\0');
	}

	public void NewLine()
	{
		if (_lastCat != CharCat.NewLine)
		{
			WriteRaw('\n');
		}
	}

	private CharCat GetCategory(char ch)
	{
		if (Lexer.IsDelimiter(ch))
		{
			return CharCat.Delimiter;
		}
		if (ch == '\n')
		{
			return CharCat.NewLine;
		}
		return CharCat.Character;
	}
}
