using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg;

internal sealed class JpegHuffmanEncodingTableBuilder
{
	private struct Symbol
	{
		public long Frequency;

		public short Value;

		public ushort CodeSize;

		public short Others;

		public override string ToString()
		{
			return $"Symbol[{Value}](Frequency={Frequency}, CodeSize={CodeSize})";
		}
	}

	private sealed class SymbolComparer : Comparer<Symbol>
	{
		public static SymbolComparer Instance { get; } = new SymbolComparer();

		public override int Compare(Symbol x, Symbol y)
		{
			if (x.CodeSize > y.CodeSize)
			{
				return 1;
			}
			if (x.CodeSize < y.CodeSize)
			{
				return -1;
			}
			if (x.Frequency > y.Frequency)
			{
				return -1;
			}
			if (x.Frequency < y.Frequency)
			{
				return 1;
			}
			return 0;
		}
	}

	private sealed class Node
	{
		public long Frequency { get; set; }

		public short Index { get; set; }

		public Node? Left { get; set; }

		public Node? Right { get; set; }

		public void Set(short index, long frequency)
		{
			Index = index;
			Frequency = frequency;
		}

		public void Set(Node left, Node right)
		{
			Frequency = left.Frequency + right.Frequency;
			Left = left;
			Right = right;
		}
	}

	private uint[] _frequencies;

	public JpegHuffmanEncodingTableBuilder()
	{
		_frequencies = new uint[256];
	}

	public void IncrementCodeCount(int symbol)
	{
		_frequencies[symbol]++;
	}

	public void Reset()
	{
		_frequencies.AsSpan().Clear();
	}

	public JpegHuffmanEncodingTable Build(bool optimal = false)
	{
		if (!optimal)
		{
			return BuildUsingStandardMethod();
		}
		return BuildUsingPackageMerge();
	}

	private JpegHuffmanEncodingTable BuildUsingStandardMethod()
	{
		int num = 0;
		uint[] frequencies = _frequencies;
		for (int i = 0; i < frequencies.Length; i++)
		{
			if (frequencies[i] != 0)
			{
				num++;
			}
		}
		if (num == 0)
		{
			throw new InvalidOperationException("No symbol is recorded.");
		}
		Symbol[] array = new Symbol[num + 1];
		int num2 = 0;
		for (int j = 0; j < frequencies.Length; j++)
		{
			if (frequencies[j] != 0)
			{
				array[num2++] = new Symbol
				{
					Value = (short)j,
					Frequency = frequencies[j],
					CodeSize = 0,
					Others = -1
				};
			}
		}
		array[num2] = new Symbol
		{
			Value = -1,
			Frequency = 1L,
			CodeSize = 0,
			Others = -1
		};
		FindHuffmanCodeSize(array);
		Span<byte> bits = stackalloc byte[60];
		bits.Clear();
		num2 = 32;
		for (int k = 0; k < array.Length; k++)
		{
			int codeSize = array[k].CodeSize;
			if (codeSize > 0)
			{
				num2 = Math.Max(num2, codeSize);
				bits[codeSize - 1]++;
			}
		}
		while (true)
		{
			if (bits[num2] > 0)
			{
				int num3 = num2 - 1;
				do
				{
					num3--;
				}
				while (bits[num3] == 0);
				bits[num2] -= 2;
				bits[num2 - 1]++;
				bits[num3 + 1] += 2;
				bits[num3] = --bits[num3];
			}
			else
			{
				num2--;
				if (num2 == 15)
				{
					break;
				}
			}
		}
		while (bits[num2] == 0)
		{
			num2--;
		}
		bits[num2]--;
		for (int l = 0; l < array.Length; l++)
		{
			if (array[l].Value == -1)
			{
				array[l].CodeSize = ushort.MaxValue;
			}
		}
		Array.Sort(array, (Symbol x, Symbol y) => x.CodeSize.CompareTo(y.CodeSize));
		return new JpegHuffmanEncodingTable(BuildCanonicalCode(bits, array.AsSpan(0, num)));
	}

	private static void FindHuffmanCodeSize(Span<Symbol> symbols)
	{
		while (true)
		{
			int num = -1;
			int num2 = -1;
			long num3 = -1L;
			long num4 = -1L;
			for (int i = 0; i < symbols.Length; i++)
			{
				long frequency = symbols[i].Frequency;
				if (frequency >= 0 && (num == -1 || frequency < num3))
				{
					num = i;
					num3 = frequency;
				}
			}
			for (int j = 0; j < symbols.Length; j++)
			{
				long frequency2 = symbols[j].Frequency;
				if (frequency2 >= 0 && j != num && (num2 == -1 || frequency2 < num4))
				{
					num2 = j;
					num4 = frequency2;
				}
			}
			if (num2 != -1)
			{
				symbols[num].Frequency += symbols[num2].Frequency;
				symbols[num2].Frequency = -1L;
				symbols[num].CodeSize++;
				while (symbols[num].Others != -1)
				{
					num = symbols[num].Others;
					symbols[num].CodeSize++;
				}
				symbols[num].Others = (short)num2;
				symbols[num2].CodeSize++;
				while (symbols[num2].Others != -1)
				{
					num2 = symbols[num2].Others;
					symbols[num2].CodeSize++;
				}
				continue;
			}
			break;
		}
	}

	private static JpegHuffmanCanonicalCode[] BuildCanonicalCode(Span<byte> bits, ReadOnlySpan<Symbol> symbols)
	{
		JpegHuffmanCanonicalCode[] array = new JpegHuffmanCanonicalCode[symbols.Length];
		int num = 1;
		ref byte reference = ref MemoryMarshal.GetReference(bits);
		for (int i = 0; i < array.Length; i++)
		{
			while (reference == 0)
			{
				reference = ref Unsafe.Add(ref reference, 1);
				num++;
			}
			reference--;
			array[i].Symbol = (byte)symbols[i].Value;
			array[i].CodeLength = (byte)num;
		}
		ushort num2 = (array[0].Code = 0);
		ushort num4 = num2;
		int codeLength = array[0].CodeLength;
		for (int j = 1; j < array.Length; j++)
		{
			ref JpegHuffmanCanonicalCode reference2 = ref array[j];
			if (reference2.CodeLength > codeLength)
			{
				num4++;
				num4 = (reference2.Code = (ushort)(num4 << reference2.CodeLength - codeLength));
				codeLength = reference2.CodeLength;
			}
			else
			{
				num4 = (reference2.Code = (ushort)(num4 + 1));
			}
		}
		return array;
	}

	private JpegHuffmanEncodingTable BuildUsingPackageMerge()
	{
		int num = 0;
		uint[] frequencies = _frequencies;
		for (int i = 0; i < frequencies.Length; i++)
		{
			if (frequencies[i] != 0)
			{
				num++;
			}
		}
		Symbol[] array = new Symbol[num + 1];
		int num2 = 0;
		for (int j = 0; j < frequencies.Length; j++)
		{
			if (frequencies[j] != 0)
			{
				array[num2++] = new Symbol
				{
					Value = (short)j,
					Frequency = frequencies[j],
					CodeSize = 0
				};
			}
		}
		array[num2] = new Symbol
		{
			Value = -1,
			Frequency = 0L,
			CodeSize = 0
		};
		RunPackageMerge(array);
		Array.Sort(array, SymbolComparer.Instance);
		num2 = 0;
		for (int num3 = array.Length - 1; num3 >= 0; num3--)
		{
			if (array[num3].Value == -1)
			{
				num2 = num3;
				break;
			}
		}
		for (int k = num2; k < array.Length - 1; k++)
		{
			array[k] = array[k + 1];
		}
		return new JpegHuffmanEncodingTable(BuildCanonicalCode(array.AsSpan(0, num)));
	}

	private static void RunPackageMerge(Symbol[] symbols)
	{
		Array.Sort(symbols, (Symbol x, Symbol y) => y.Frequency.CompareTo(x.Frequency));
		int num = symbols.Length;
		List<Node>[] array = new List<Node>[16];
		int num2 = array.Length - 1;
		int num3 = num;
		while (num2 >= 0)
		{
			List<Node> list = new List<Node>(num3);
			for (int num4 = 0; num4 < num; num4++)
			{
				Node node = new Node();
				node.Set((short)num4, symbols[num4].Frequency);
				list.Add(node);
			}
			array[num2] = list;
			num2--;
			num3 += num3 / 2;
		}
		for (int num5 = array.Length - 1; num5 > 0; num5--)
		{
			List<Node> list2 = array[num5];
			List<Node> list3 = array[num5 - 1];
			list2.Sort((Node x, Node y) => y.Frequency.CompareTo(x.Frequency));
			for (int count = list2.Count; count >= 2; count = list2.Count)
			{
				Node left = list2[count - 1];
				Node right = list2[count - 2];
				list2.RemoveAt(count - 1);
				list2.RemoveAt(count - 2);
				Node node2 = new Node();
				node2.Set(left, right);
				list3.Add(node2);
			}
		}
		List<Node> list4 = array[0];
		list4.Sort((Node x, Node y) => x.Frequency.CompareTo(y.Frequency));
		int num6 = Math.Max(1, 2 * (num - 1));
		for (int num7 = 0; num7 < num6; num7++)
		{
			TraverseNode(list4[num7], symbols);
		}
		static void TraverseNode(Node? node3, Symbol[] array2)
		{
			if (node3 != null)
			{
				if (node3.Left == null)
				{
					array2[node3.Index].CodeSize++;
				}
				else
				{
					TraverseNode(node3.Left, array2);
					TraverseNode(node3.Right, array2);
				}
			}
		}
	}

	private static JpegHuffmanCanonicalCode[] BuildCanonicalCode(ReadOnlySpan<Symbol> symbols)
	{
		JpegHuffmanCanonicalCode[] array = new JpegHuffmanCanonicalCode[symbols.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Symbol = (byte)symbols[i].Value;
			array[i].CodeLength = (byte)symbols[i].CodeSize;
		}
		ushort num = (array[0].Code = 0);
		ushort num3 = num;
		int codeLength = array[0].CodeLength;
		for (int j = 1; j < array.Length; j++)
		{
			ref JpegHuffmanCanonicalCode reference = ref array[j];
			if (reference.CodeLength > codeLength)
			{
				num3++;
				num3 = (reference.Code = (ushort)(num3 << reference.CodeLength - codeLength));
				codeLength = reference.CodeLength;
			}
			else
			{
				num3 = (reference.Code = (ushort)(num3 + 1));
			}
		}
		return array;
	}
}
