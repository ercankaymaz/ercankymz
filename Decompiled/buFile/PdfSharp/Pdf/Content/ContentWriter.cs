#define DEBUG
using System.Diagnostics;
using System.IO;
using PdfSharp.Pdf.Internal;

namespace PdfSharp.Pdf.Content;

internal class ContentWriter
{
	private enum CharCat
	{
		NewLine,
		Character,
		Delimiter
	}

	protected int _indent = 2;

	protected int _writeIndent = 0;

	private CharCat _lastCat;

	private Stream _stream;

	public int Position => (int)_stream.Position;

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

	public ContentWriter(Stream contentStream)
	{
		_stream = contentStream;
	}

	public void Close(bool closeUnderlyingStream)
	{
		if (_stream != null && closeUnderlyingStream)
		{
			_stream.Close();
			_stream = null;
		}
	}

	public void Close()
	{
		Close(closeUnderlyingStream: true);
	}

	public void Write(bool value)
	{
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

	public void WriteLineRaw(string rawString)
	{
		if (!string.IsNullOrEmpty(rawString))
		{
			byte[] bytes = PdfEncoders.RawEncoding.GetBytes(rawString);
			_stream.Write(bytes, 0, bytes.Length);
			_stream.Write(new byte[1] { 10 }, 0, 1);
			_lastCat = GetCategory((char)bytes[bytes.Length - 1]);
		}
	}

	public void WriteRaw(char ch)
	{
		Debug.Assert(ch < 'Ā', "Raw character greater than 255 detected.");
		_stream.WriteByte((byte)ch);
		_lastCat = GetCategory(ch);
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
		CharCat lastCat = _lastCat;
		CharCat charCat = lastCat;
		if (charCat == CharCat.Delimiter)
		{
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
		return CharCat.Character;
	}
}
