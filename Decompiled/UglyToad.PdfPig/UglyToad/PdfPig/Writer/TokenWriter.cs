using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Graphics.Operations;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Writer;

public class TokenWriter : ITokenWriter
{
	private class XrefSeries
	{
		public class OffsetAndGeneration
		{
			public long Offset { get; }

			public long Generation { get; }

			public OffsetAndGeneration(long offset, long generation)
			{
				Offset = offset;
				Generation = generation;
			}
		}

		public long First { get; }

		public IReadOnlyList<OffsetAndGeneration?> Offsets { get; }

		public XrefSeries(long first, IReadOnlyList<OffsetAndGeneration?> offsets)
		{
			First = first;
			Offsets = offsets;
		}
	}

	private const byte ArrayStart = 91;

	private const byte ArrayEnd = 93;

	private const byte Comment = 37;

	private static readonly byte HexStart = 60;

	private static readonly byte HexEnd = 62;

	private const byte InUseEntry = 110;

	private const byte NameStart = 47;

	private const byte RByte = 82;

	private const byte StringStart = 40;

	private const byte StringEnd = 41;

	private const byte Whitespace = 32;

	private static readonly HashSet<char> DelimiterChars = new HashSet<char> { '(', ')', '<', '>', '[', ']', '{', '}', '/', '%' };

	private static readonly int[] EscapeNeeded = new int[6] { 13, 10, 9, 8, 12, 92 };

	private static readonly int[] Escaped = new int[6] { 114, 110, 116, 98, 102, 92 };

	private static ReadOnlySpan<byte> DictionaryStart => "<<"u8;

	private static ReadOnlySpan<byte> DictionaryEnd => ">>"u8;

	private static ReadOnlySpan<byte> Eof => "%%EOF"u8;

	private static ReadOnlySpan<byte> FalseBytes => "false"u8;

	private static ReadOnlySpan<byte> Null => "null"u8;

	private static ReadOnlySpan<byte> ObjStart => "obj"u8;

	private static ReadOnlySpan<byte> ObjEnd => "endobj"u8;

	private static ReadOnlySpan<byte> StartXref => "startxref"u8;

	protected static ReadOnlySpan<byte> StreamStart => "stream"u8;

	protected static ReadOnlySpan<byte> StreamEnd => "endstream"u8;

	private static ReadOnlySpan<byte> Trailer => "trailer"u8;

	private static ReadOnlySpan<byte> TrueBytes => "true"u8;

	private static ReadOnlySpan<byte> Xref => "xref"u8;

	public static TokenWriter Instance { get; } = new TokenWriter();

	public bool WritingPageContents { get; set; }

	public void WriteToken(IToken token, Stream outputStream)
	{
		if (token == null)
		{
			WriteNullToken(outputStream);
		}
		else if (!(token is ArrayToken array))
		{
			if (!(token is BooleanToken boolean))
			{
				if (!(token is CommentToken comment))
				{
					if (!(token is DictionaryToken dictionary))
					{
						if (!(token is HexToken hex))
						{
							if (!(token is IndirectReferenceToken reference))
							{
								if (!(token is NameToken name))
								{
									if (!(token is NullToken))
									{
										if (!(token is NumericToken number))
										{
											if (!(token is ObjectToken objectToken))
											{
												if (!(token is StreamToken streamToken))
												{
													if (!(token is StringToken stringToken))
													{
														throw new PdfDocumentFormatException($"Attempted to write token type of {token.GetType()} but was not known.");
													}
													WriteString(stringToken, outputStream);
												}
												else
												{
													WriteStream(streamToken, outputStream);
												}
											}
											else
											{
												WriteObject(objectToken, outputStream);
											}
										}
										else
										{
											WriteNumber(number, outputStream);
										}
									}
									else
									{
										outputStream.Write(Null);
										WriteWhitespace(outputStream);
									}
								}
								else
								{
									WriteName(name, outputStream);
								}
							}
							else
							{
								WriteIndirectReference(reference, outputStream);
							}
						}
						else
						{
							WriteHex(hex, outputStream);
						}
					}
					else
					{
						WriteDictionary(dictionary, outputStream);
					}
				}
				else
				{
					WriteComment(comment, outputStream);
				}
			}
			else
			{
				WriteBoolean(boolean, outputStream);
			}
		}
		else
		{
			WriteArray(array, outputStream);
		}
	}

	public void WriteCrossReferenceTable(IReadOnlyDictionary<IndirectReference, long> objectOffsets, IndirectReference catalogToken, Stream outputStream, IndirectReference? documentInformationReference)
	{
		if (objectOffsets.Count == 0)
		{
			throw new InvalidOperationException("Could not write empty cross reference table.");
		}
		WriteLineBreak(outputStream);
		long position = outputStream.Position;
		outputStream.Write(Xref);
		WriteLineBreak(outputStream);
		List<XrefSeries> list = new List<XrefSeries>();
		List<KeyValuePair<IndirectReference, long>> list2 = objectOffsets.OrderBy((KeyValuePair<IndirectReference, long> x) => x.Key.ObjectNumber).ToList();
		long first = 0L;
		long num = 0L;
		List<XrefSeries.OffsetAndGeneration> list3 = new List<XrefSeries.OffsetAndGeneration> { null };
		foreach (KeyValuePair<IndirectReference, long> item in list2)
		{
			if (item.Key.ObjectNumber - num == 1)
			{
				num = item.Key.ObjectNumber;
				list3.Add(new XrefSeries.OffsetAndGeneration(item.Value, item.Key.Generation));
				continue;
			}
			list.Add(new XrefSeries(first, list3));
			list3 = new List<XrefSeries.OffsetAndGeneration>
			{
				new XrefSeries.OffsetAndGeneration(item.Value, item.Key.Generation)
			};
			num = item.Key.ObjectNumber;
			first = item.Key.ObjectNumber;
		}
		if (list3.Count > 0)
		{
			list.Add(new XrefSeries(first, list3));
		}
		foreach (XrefSeries item2 in list)
		{
			WriteLong(item2.First, outputStream);
			WriteWhitespace(outputStream);
			WriteLong(item2.Offsets.Count, outputStream);
			WriteWhitespace(outputStream);
			WriteLineBreak(outputStream);
			foreach (XrefSeries.OffsetAndGeneration offset in item2.Offsets)
			{
				if (offset != null)
				{
					byte[] bytes = Encoding.ASCII.GetBytes(offset.Offset.ToString("D10", CultureInfo.InvariantCulture));
					outputStream.Write(bytes);
					outputStream.WriteWhiteSpace();
					byte[] bytes2 = Encoding.ASCII.GetBytes(offset.Generation.ToString("D5", CultureInfo.InvariantCulture));
					outputStream.Write(bytes2);
					WriteWhitespace(outputStream);
					outputStream.WriteByte(110);
					WriteWhitespace(outputStream);
					WriteLineBreak(outputStream);
				}
				else
				{
					WriteFirstXrefEmptyEntry(outputStream);
				}
			}
		}
		outputStream.Write(Trailer);
		WriteLineBreak(outputStream);
		ArrayToken value = new ArrayToken(new IToken[2]
		{
			new HexToken(Guid.NewGuid().ToString("N").AsSpan()),
			new HexToken(Guid.NewGuid().ToString("N").AsSpan())
		});
		Dictionary<NameToken, IToken> dictionary = new Dictionary<NameToken, IToken>
		{
			{
				NameToken.Size,
				new NumericToken(objectOffsets.Count + 1)
			},
			{
				NameToken.Root,
				new IndirectReferenceToken(catalogToken)
			},
			{
				NameToken.Id,
				value
			}
		};
		if (documentInformationReference.HasValue)
		{
			dictionary[NameToken.Info] = new IndirectReferenceToken(documentInformationReference.Value);
		}
		DictionaryToken dictionary2 = new DictionaryToken(dictionary);
		WriteDictionary(dictionary2, outputStream);
		WriteLineBreak(outputStream);
		outputStream.Write(StartXref);
		WriteLineBreak(outputStream);
		WriteLong(position, outputStream);
		WriteLineBreak(outputStream);
		outputStream.Write(Eof);
	}

	public void WriteObject(long objectNumber, int generation, byte[] data, Stream outputStream)
	{
		WriteLong(objectNumber, outputStream);
		outputStream.WriteWhiteSpace();
		WriteInt(generation, outputStream);
		outputStream.WriteWhiteSpace();
		outputStream.Write(ObjStart);
		WriteLineBreak(outputStream);
		outputStream.Write(data, 0, data.Length);
		WriteLineBreak(outputStream);
		outputStream.Write(ObjEnd);
		WriteLineBreak(outputStream);
	}

	protected void WriteHex(HexToken hex, Stream stream)
	{
		stream.WriteByte(HexStart);
		stream.WriteText(hex.GetHexString());
		stream.WriteByte(HexEnd);
	}

	protected void WriteArray(ArrayToken array, Stream outputStream)
	{
		outputStream.WriteByte(91);
		outputStream.WriteWhiteSpace();
		for (int i = 0; i < array.Data.Count; i++)
		{
			IToken token = array.Data[i];
			WriteToken(token, outputStream);
		}
		outputStream.WriteByte(93);
		outputStream.WriteWhiteSpace();
	}

	protected void WriteBoolean(BooleanToken boolean, Stream outputStream)
	{
		ReadOnlySpan<byte> data = (boolean.Data ? TrueBytes : FalseBytes);
		outputStream.Write(data);
		outputStream.WriteWhiteSpace();
	}

	protected void WriteComment(CommentToken comment, Stream outputStream)
	{
		outputStream.WriteByte(37);
		outputStream.WriteText(comment.Data);
		WriteLineBreak(outputStream);
	}

	protected void WriteNullToken(Stream outputStream)
	{
		outputStream.Write("null"u8);
		outputStream.WriteWhiteSpace();
	}

	protected void WriteDictionary(DictionaryToken dictionary, Stream outputStream)
	{
		outputStream.Write(DictionaryStart);
		foreach (KeyValuePair<string, IToken> datum in dictionary.Data)
		{
			WriteName(datum.Key, outputStream);
			if (datum.Value == null)
			{
				WriteToken(NullToken.Instance, outputStream);
			}
			else
			{
				WriteToken(datum.Value, outputStream);
			}
		}
		outputStream.Write(DictionaryEnd);
	}

	protected virtual void WriteIndirectReference(IndirectReferenceToken reference, Stream outputStream)
	{
		WriteLong(reference.Data.ObjectNumber, outputStream);
		outputStream.WriteWhiteSpace();
		WriteInt(reference.Data.Generation, outputStream);
		outputStream.WriteWhiteSpace();
		outputStream.WriteByte(82);
		outputStream.WriteWhiteSpace();
	}

	protected virtual void WriteName(NameToken name, Stream outputStream)
	{
		WriteName(name.Data, outputStream);
	}

	private void WriteName(string name, Stream outputStream)
	{
		using ArrayPoolBufferWriter<byte> arrayPoolBufferWriter = new ArrayPoolBufferWriter<byte>(name.Length * 2 + 1);
		Span<byte> span = stackalloc byte[2];
		foreach (char c in name)
		{
			if (c < '!' || c > '~' || DelimiterChars.Contains(c))
			{
				Hex.GetUtf8Chars(new ReadOnlySpan<byte>(new byte[1] { (byte)c }), span);
				arrayPoolBufferWriter.Write(35);
				arrayPoolBufferWriter.Write(span);
			}
			else
			{
				arrayPoolBufferWriter.Write((byte)c);
			}
		}
		outputStream.WriteByte(47);
		outputStream.Write(arrayPoolBufferWriter.WrittenSpan);
		outputStream.WriteWhiteSpace();
	}

	protected virtual void WriteNumber(NumericToken number, Stream outputStream)
	{
		if (!number.HasDecimalPlaces)
		{
			WriteInt(number.Int, outputStream);
		}
		else
		{
			outputStream.WriteDouble(number.Data);
		}
		WriteWhitespace(outputStream);
	}

	protected virtual void WriteObject(ObjectToken objectToken, Stream outputStream)
	{
		WriteLong(objectToken.Number.ObjectNumber, outputStream);
		outputStream.WriteWhiteSpace();
		WriteInt(objectToken.Number.Generation, outputStream);
		outputStream.WriteWhiteSpace();
		outputStream.Write(ObjStart);
		WriteLineBreak(outputStream);
		WriteToken(objectToken.Data, outputStream);
		WriteLineBreak(outputStream);
		outputStream.Write(ObjEnd);
		WriteLineBreak(outputStream);
	}

	protected virtual void WriteStream(StreamToken streamToken, Stream outputStream)
	{
		WriteDictionary(streamToken.StreamDictionary, outputStream);
		WriteLineBreak(outputStream);
		outputStream.Write(StreamStart);
		WriteLineBreak(outputStream);
		outputStream.Write(streamToken.Data.Span);
		WriteLineBreak(outputStream);
		outputStream.Write(StreamEnd);
	}

	protected virtual void WriteString(StringToken stringToken, Stream outputStream)
	{
		outputStream.WriteByte(40);
		if (stringToken.EncodedWith == StringToken.Encoding.Iso88591 || stringToken.EncodedWith == StringToken.Encoding.PdfDocEncoding)
		{
			char[] array = stringToken.Data.ToCharArray();
			if (array.Any((char x) => x > 'ÿ'))
			{
				array = (from b in new StringToken(stringToken.Data, StringToken.Encoding.Utf16BE).GetBytes()
					select (char)b).ToArray();
			}
			foreach (int num2 in array)
			{
				int num3;
				if (num2 == 40 || num2 == 41)
				{
					outputStream.WriteByte(92);
					outputStream.WriteByte((byte)num2);
				}
				else if ((num3 = Array.IndexOf(EscapeNeeded, num2)) > -1)
				{
					outputStream.WriteByte(92);
					outputStream.WriteByte((byte)Escaped[num3]);
				}
				else if (num2 < 32 || num2 > 126)
				{
					int num4 = num2 / 64;
					int num5 = (num2 - num4 * 64) / 8;
					int num6 = num2 % 8;
					outputStream.WriteByte(92);
					outputStream.WriteByte((byte)(num4 + 48));
					outputStream.WriteByte((byte)(num5 + 48));
					outputStream.WriteByte((byte)(num6 + 48));
				}
				else
				{
					outputStream.WriteByte((byte)num2);
				}
			}
		}
		else
		{
			byte[] bytes = stringToken.GetBytes();
			outputStream.Write(bytes);
		}
		outputStream.WriteByte(41);
		outputStream.WriteWhiteSpace();
	}

	protected virtual void WriteInt(int value, Stream outputStream)
	{
		Span<byte> destination = stackalloc byte[10];
		Utf8Formatter.TryFormat(value, destination, out var bytesWritten);
		outputStream.Write(destination.Slice(0, bytesWritten));
	}

	protected virtual void WriteLineBreak(Stream outputStream)
	{
		outputStream.WriteNewLine();
	}

	protected virtual void WriteLong(long value, Stream outputStream)
	{
		Span<byte> destination = stackalloc byte[20];
		Utf8Formatter.TryFormat(value, destination, out var bytesWritten);
		outputStream.Write(destination.Slice(0, bytesWritten));
	}

	protected virtual void WriteWhitespace(Stream outputStream)
	{
		outputStream.WriteByte(32);
	}

	private void WriteFirstXrefEmptyEntry(Stream outputStream)
	{
		outputStream.WriteText(new string('0', 10));
		outputStream.WriteWhiteSpace();
		outputStream.WriteText("65535"u8);
		outputStream.WriteWhiteSpace();
		outputStream.WriteText("f"u8);
		outputStream.WriteWhiteSpace();
		outputStream.WriteNewLine();
	}
}
