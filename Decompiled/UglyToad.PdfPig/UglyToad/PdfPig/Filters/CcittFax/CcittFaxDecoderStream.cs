using System;
using System.IO;
using UglyToad.PdfPig.IO;

namespace UglyToad.PdfPig.Filters.CcittFax;

internal sealed class CcittFaxDecoderStream : StreamWrapper
{
	private sealed class Node
	{
		public Node? Left { get; set; }

		public Node? Right { get; set; }

		public int Value { get; set; }

		public bool CanBeFill { get; set; }

		public bool IsLeaf { get; set; }

		public void Set(bool next, Node node)
		{
			if (!next)
			{
				Left = node;
			}
			else
			{
				Right = node;
			}
		}

		public Node Walk(bool next)
		{
			if (!next)
			{
				return Left;
			}
			return Right;
		}

		public override string ToString()
		{
			return string.Format("[{0}={1}, {2}={3}, {4}={5}]", "IsLeaf", IsLeaf, "Value", Value, "CanBeFill", CanBeFill);
		}
	}

	private sealed class Tree
	{
		public Node Root { get; } = new Node();

		public void Fill(int depth, int path, int value)
		{
			Node node = Root;
			for (int i = 0; i < depth; i++)
			{
				int num = depth - 1 - i;
				bool next = ((path >> num) & 1) == 1;
				Node node2 = node.Walk(next);
				if (node2 == null)
				{
					node2 = new Node();
					if (i == depth - 1)
					{
						node2.Value = value;
						node2.IsLeaf = true;
					}
					if (path == 0)
					{
						node2.CanBeFill = true;
					}
					node.Set(next, node2);
				}
				else if (node2.IsLeaf)
				{
					throw new InvalidOperationException("node is leaf, no other following");
				}
				node = node2;
			}
		}

		public void Fill(int depth, int path, Node node)
		{
			Node node2 = Root;
			for (int i = 0; i < depth; i++)
			{
				int num = depth - 1 - i;
				bool next = ((path >> num) & 1) == 1;
				Node node3 = node2.Walk(next);
				if (node3 == null)
				{
					node3 = ((i != depth - 1) ? new Node() : node);
					if (path == 0)
					{
						node3.CanBeFill = true;
					}
					node2.Set(next, node3);
				}
				else if (node3.IsLeaf)
				{
					throw new InvalidOperationException("node is leaf, no other following");
				}
				node2 = node3;
			}
		}
	}

	private readonly int columns;

	private readonly byte[] decodedRow;

	private readonly bool optionByteAligned;

	private readonly CcittFaxCompressionType type;

	private int decodedLength;

	private int decodedPos;

	private int[] changesReferenceRow;

	private int[] changesCurrentRow;

	private int changesReferenceRowCount;

	private int changesCurrentRowCount;

	private int lastChangingElement;

	private int buffer = -1;

	private int bufferPos = -1;

	private static readonly short[][] BLACK_CODES;

	private static readonly short[][] BLACK_RUN_LENGTHS;

	private static readonly short[][] WHITE_CODES;

	private static readonly short[][] WHITE_RUN_LENGTHS;

	private static readonly Node EOL;

	private static readonly Node FILL;

	private static readonly Tree BlackRunTree;

	private static readonly Tree WhiteRunTree;

	private static readonly Tree EolOnlyTree;

	private static readonly Tree CodeTree;

	private const int VALUE_EOL = -2000;

	private const int VALUE_FILL = -1000;

	private const int VALUE_PASSMODE = -3000;

	private const int VALUE_HMODE = -4000;

	public CcittFaxDecoderStream(Stream stream, int columns, CcittFaxCompressionType type, bool byteAligned)
		: base(stream)
	{
		this.columns = columns;
		this.type = type;
		decodedRow = new byte[(columns + 7) / 8];
		changesReferenceRow = new int[columns + 2];
		changesCurrentRow = new int[columns + 2];
		optionByteAligned = byteAligned;
	}

	private void Fetch()
	{
		if (decodedPos < decodedLength)
		{
			return;
		}
		decodedLength = 0;
		try
		{
			DecodeRow();
		}
		catch (InvalidOperationException)
		{
			if (decodedLength != 0)
			{
				throw;
			}
			decodedLength = -1;
		}
		decodedPos = 0;
	}

	private void Decode1D()
	{
		int num = 0;
		bool flag = true;
		changesCurrentRowCount = 0;
		do
		{
			int num2 = (flag ? DecodeRun(WhiteRunTree) : DecodeRun(BlackRunTree));
			num += num2;
			changesCurrentRow[changesCurrentRowCount++] = num;
			flag = !flag;
		}
		while (num < columns);
	}

	private void Decode2D()
	{
		changesReferenceRowCount = changesCurrentRowCount;
		int[] array = changesCurrentRow;
		changesCurrentRow = changesReferenceRow;
		changesReferenceRow = array;
		bool flag = true;
		int num = 0;
		changesCurrentRowCount = 0;
		while (num < columns)
		{
			Node node = CodeTree.Root;
			while (true)
			{
				node = node.Walk(ReadBit());
				if (node == null)
				{
					break;
				}
				if (node.IsLeaf)
				{
					switch (node.Value)
					{
					case -4000:
					{
						int num3 = DecodeRun(flag ? WhiteRunTree : BlackRunTree);
						num += num3;
						changesCurrentRow[changesCurrentRowCount++] = num;
						num3 = DecodeRun(flag ? BlackRunTree : WhiteRunTree);
						num += num3;
						changesCurrentRow[changesCurrentRowCount++] = num;
						break;
					}
					case -3000:
					{
						int num2 = GetNextChangingElement(num, flag) + 1;
						num = ((num2 < changesReferenceRowCount) ? changesReferenceRow[num2] : columns);
						break;
					}
					default:
					{
						int nextChangingElement = GetNextChangingElement(num, flag);
						num = ((nextChangingElement < changesReferenceRowCount && nextChangingElement != -1) ? (changesReferenceRow[nextChangingElement] + node.Value) : (columns + node.Value));
						changesCurrentRow[changesCurrentRowCount] = num;
						changesCurrentRowCount++;
						flag = !flag;
						break;
					}
					}
					break;
				}
			}
		}
	}

	private int GetNextChangingElement(int a0, bool white)
	{
		int num = (int)(lastChangingElement & 0xFFFFFFFEu) + ((!white) ? 1 : 0);
		if (num > 2)
		{
			num -= 2;
		}
		if (a0 == 0)
		{
			return num;
		}
		for (int i = num; i < changesReferenceRowCount; i += 2)
		{
			if (a0 < changesReferenceRow[i])
			{
				lastChangingElement = i;
				return i;
			}
		}
		return -1;
	}

	private void DecodeRowType2()
	{
		if (optionByteAligned)
		{
			ResetBuffer();
		}
		Decode1D();
	}

	private void DecodeRowType4()
	{
		if (optionByteAligned)
		{
			ResetBuffer();
		}
		while (true)
		{
			Node node = EolOnlyTree.Root;
			while (true)
			{
				node = node.Walk(ReadBit());
				if (node == null)
				{
					break;
				}
				if (node.IsLeaf)
				{
					if (type == CcittFaxCompressionType.Group3_1D || ReadBit())
					{
						Decode1D();
					}
					else
					{
						Decode2D();
					}
					return;
				}
			}
		}
	}

	private void DecodeRowType6()
	{
		if (optionByteAligned)
		{
			ResetBuffer();
		}
		Decode2D();
	}

	private void DecodeRow()
	{
		switch (type)
		{
		case CcittFaxCompressionType.ModifiedHuffman:
			DecodeRowType2();
			break;
		case CcittFaxCompressionType.Group3_1D:
		case CcittFaxCompressionType.Group3_2D:
			DecodeRowType4();
			break;
		case CcittFaxCompressionType.Group4_2D:
			DecodeRowType6();
			break;
		default:
			throw new InvalidOperationException(type.ToString() + " is not a supported compression type.");
		}
		int i = 0;
		bool flag = true;
		lastChangingElement = 0;
		for (int j = 0; j <= changesCurrentRowCount; j++)
		{
			int num = columns;
			if (j != changesCurrentRowCount)
			{
				num = changesCurrentRow[j];
			}
			if (num > columns)
			{
				num = columns;
			}
			int num2 = i / 8;
			for (; i % 8 != 0 && num - i > 0; i++)
			{
				decodedRow[num2] |= (byte)((!flag) ? (1 << 7 - i % 8) : 0);
			}
			if (i % 8 == 0)
			{
				num2 = i / 8;
				byte b = (byte)((!flag) ? 255u : 0u);
				while (num - i > 7)
				{
					decodedRow[num2] = b;
					i += 8;
					num2++;
				}
			}
			for (; num - i > 0; i++)
			{
				if (i % 8 == 0)
				{
					decodedRow[num2] = 0;
				}
				decodedRow[num2] |= (byte)((!flag) ? (1 << 7 - i % 8) : 0);
			}
			flag = !flag;
		}
		if (i != columns)
		{
			throw new InvalidOperationException($"Sum of run-lengths does not equal scan line width: {i} > {columns}");
		}
		decodedLength = (i + 7) / 8;
	}

	private int DecodeRun(Tree tree)
	{
		int num = 0;
		Node node = tree.Root;
		while (true)
		{
			bool next = ReadBit();
			node = node.Walk(next);
			if (node == null)
			{
				throw new InvalidOperationException("Unknown code in Huffman RLE stream");
			}
			if (node.IsLeaf)
			{
				num += node.Value;
				if (node.Value < 64)
				{
					break;
				}
				node = tree.Root;
			}
		}
		if (node.Value >= 0)
		{
			return num;
		}
		return columns;
	}

	private void ResetBuffer()
	{
		bufferPos = -1;
	}

	private bool ReadBit()
	{
		if (bufferPos < 0 || bufferPos > 7)
		{
			buffer = Stream.ReadByte();
			if (buffer == -1)
			{
				throw new InvalidOperationException("Unexpected end of Huffman RLE stream");
			}
			bufferPos = 0;
		}
		bool result = ((buffer >> 7 - bufferPos) & 1) == 1;
		bufferPos++;
		if (bufferPos > 7)
		{
			bufferPos = -1;
		}
		return result;
	}

	public override int ReadByte()
	{
		if (decodedLength < 0)
		{
			return 0;
		}
		if (decodedPos >= decodedLength)
		{
			Fetch();
			if (decodedLength < 0)
			{
				return 0;
			}
		}
		return decodedRow[decodedPos++] & 0xFF;
	}

	public override int Read(byte[] b, int off, int len)
	{
		if (decodedLength < 0)
		{
			b.AsSpan(off, len).Fill(0);
			return len;
		}
		if (decodedPos >= decodedLength)
		{
			Fetch();
			if (decodedLength < 0)
			{
				b.AsSpan(off, len).Fill(0);
				return len;
			}
		}
		int num = Math.Min(decodedLength - decodedPos, len);
		Array.Copy(decodedRow, decodedPos, b, off, num);
		decodedPos += num;
		return num;
	}

	static CcittFaxDecoderStream()
	{
		BLACK_CODES = new short[12][]
		{
			new short[2] { 2, 3 },
			new short[2] { 2, 3 },
			new short[2] { 2, 3 },
			new short[1] { 3 },
			new short[2] { 4, 5 },
			new short[3] { 4, 5, 7 },
			new short[2] { 4, 7 },
			new short[1] { 24 },
			new short[5] { 23, 24, 55, 8, 15 },
			new short[10] { 23, 24, 40, 55, 103, 104, 108, 8, 12, 13 },
			new short[54]
			{
				18, 19, 20, 21, 22, 23, 28, 29, 30, 31,
				36, 39, 40, 43, 44, 51, 52, 53, 55, 56,
				82, 83, 84, 85, 86, 87, 88, 89, 90, 91,
				100, 101, 102, 103, 104, 105, 106, 107, 108, 109,
				200, 201, 202, 203, 204, 205, 210, 211, 212, 213,
				214, 215, 218, 219
			},
			new short[20]
			{
				74, 75, 76, 77, 82, 83, 84, 85, 90, 91,
				100, 101, 108, 109, 114, 115, 116, 117, 118, 119
			}
		};
		BLACK_RUN_LENGTHS = new short[12][]
		{
			new short[2] { 3, 2 },
			new short[2] { 1, 4 },
			new short[2] { 6, 5 },
			new short[1] { 7 },
			new short[2] { 9, 8 },
			new short[3] { 10, 11, 12 },
			new short[2] { 13, 14 },
			new short[1] { 15 },
			new short[5] { 16, 17, 0, 18, 64 },
			new short[10] { 24, 25, 23, 22, 19, 20, 21, 1792, 1856, 1920 },
			new short[54]
			{
				1984, 2048, 2112, 2176, 2240, 2304, 2368, 2432, 2496, 2560,
				52, 55, 56, 59, 60, 320, 384, 448, 53, 54,
				50, 51, 44, 45, 46, 47, 57, 58, 61, 256,
				48, 49, 62, 63, 30, 31, 32, 33, 40, 41,
				128, 192, 26, 27, 28, 29, 34, 35, 36, 37,
				38, 39, 42, 43
			},
			new short[20]
			{
				640, 704, 768, 832, 1280, 1344, 1408, 1472, 1536, 1600,
				1664, 1728, 512, 576, 896, 960, 1024, 1088, 1152, 1216
			}
		};
		WHITE_CODES = new short[9][]
		{
			new short[6] { 7, 8, 11, 12, 14, 15 },
			new short[6] { 18, 19, 20, 27, 7, 8 },
			new short[9] { 23, 24, 42, 43, 3, 52, 53, 7, 8 },
			new short[12]
			{
				19, 23, 24, 36, 39, 40, 43, 3, 55, 4,
				8, 12
			},
			new short[42]
			{
				18, 19, 20, 21, 22, 23, 26, 27, 2, 36,
				37, 40, 41, 42, 43, 44, 45, 3, 50, 51,
				52, 53, 54, 55, 4, 74, 75, 5, 82, 83,
				84, 85, 88, 89, 90, 91, 100, 101, 103, 104,
				10, 11
			},
			new short[16]
			{
				152, 153, 154, 155, 204, 205, 210, 211, 212, 213,
				214, 215, 216, 217, 218, 219
			},
			new short[0],
			new short[3] { 8, 12, 13 },
			new short[10] { 18, 19, 20, 21, 22, 23, 28, 29, 30, 31 }
		};
		WHITE_RUN_LENGTHS = new short[9][]
		{
			new short[6] { 2, 3, 4, 5, 6, 7 },
			new short[6] { 128, 8, 9, 64, 10, 11 },
			new short[9] { 192, 1664, 16, 17, 13, 14, 15, 1, 12 },
			new short[12]
			{
				26, 21, 28, 27, 18, 24, 25, 22, 256, 23,
				20, 19
			},
			new short[42]
			{
				33, 34, 35, 36, 37, 38, 31, 32, 29, 53,
				54, 39, 40, 41, 42, 43, 44, 30, 61, 62,
				63, 0, 320, 384, 45, 59, 60, 46, 49, 50,
				51, 52, 55, 56, 57, 58, 448, 512, 640, 576,
				47, 48
			},
			new short[16]
			{
				1472, 1536, 1600, 1728, 704, 768, 832, 896, 960, 1024,
				1088, 1152, 1216, 1280, 1344, 1408
			},
			new short[0],
			new short[3] { 1792, 1856, 1920 },
			new short[10] { 1984, 2048, 2112, 2176, 2240, 2304, 2368, 2432, 2496, 2560 }
		};
		EOL = new Node
		{
			IsLeaf = true,
			Value = -2000
		};
		FILL = new Node
		{
			Value = -1000
		};
		FILL.Left = FILL;
		FILL.Right = EOL;
		EolOnlyTree = new Tree();
		EolOnlyTree.Fill(12, 0, FILL);
		EolOnlyTree.Fill(12, 1, EOL);
		BlackRunTree = new Tree();
		for (int i = 0; i < BLACK_CODES.Length; i++)
		{
			for (int j = 0; j < BLACK_CODES[i].Length; j++)
			{
				BlackRunTree.Fill(i + 2, BLACK_CODES[i][j], BLACK_RUN_LENGTHS[i][j]);
			}
		}
		BlackRunTree.Fill(12, 0, FILL);
		BlackRunTree.Fill(12, 1, EOL);
		WhiteRunTree = new Tree();
		for (int k = 0; k < WHITE_CODES.Length; k++)
		{
			for (int l = 0; l < WHITE_CODES[k].Length; l++)
			{
				WhiteRunTree.Fill(k + 4, WHITE_CODES[k][l], WHITE_RUN_LENGTHS[k][l]);
			}
		}
		WhiteRunTree.Fill(12, 0, FILL);
		WhiteRunTree.Fill(12, 1, EOL);
		CodeTree = new Tree();
		CodeTree.Fill(4, 1, -3000);
		CodeTree.Fill(3, 1, -4000);
		CodeTree.Fill(1, 1, 0);
		CodeTree.Fill(3, 3, 1);
		CodeTree.Fill(6, 3, 2);
		CodeTree.Fill(7, 3, 3);
		CodeTree.Fill(3, 2, -1);
		CodeTree.Fill(6, 2, -2);
		CodeTree.Fill(7, 2, -3);
	}
}
