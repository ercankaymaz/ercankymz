using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Fonts.CompactFontFormat.Charsets;

namespace UglyToad.PdfPig.Fonts.CompactFontFormat.CharStrings;

internal static class Type2CharStringParser
{
	private const byte HstemByte = 1;

	private const byte VstemByte = 3;

	private const byte HstemhmByte = 18;

	private const byte HintmaskByte = 19;

	private const byte CntrmaskByte = 20;

	private const byte VstemhmByte = 23;

	private static readonly HashSet<byte> HintingCommandBytes = new HashSet<byte> { 1, 3, 18, 23 };

	private static readonly IReadOnlyDictionary<byte, LazyType2Command> SingleByteCommandStore = new Dictionary<byte, LazyType2Command>
	{
		{
			1,
			new LazyType2Command("hstem", 2, delegate(Type2BuildCharContext ctx)
			{
				int num = ctx.Stack.Length / 2;
				(double, double)[] array = new(double, double)[num];
				double num2 = ctx.Stack.PopBottom();
				double num3 = num2 + ctx.Stack.PopBottom();
				array[0] = (num2, num3);
				double num4 = num3;
				for (int i = 1; i < num; i++)
				{
					double num5 = ctx.Stack.PopBottom();
					double num6 = ctx.Stack.PopBottom();
					array[i] = (num4 + num5, num4 + num5 + num6);
					num4 = num4 + num5 + num6;
				}
				ctx.AddHorizontalStemHints(array);
				ctx.Stack.Clear();
			})
		},
		{
			3,
			new LazyType2Command("vstem", 2, delegate(Type2BuildCharContext ctx)
			{
				int num = ctx.Stack.Length / 2;
				(double, double)[] array = new(double, double)[num];
				double num2 = ctx.Stack.PopBottom();
				double num3 = num2 + ctx.Stack.PopBottom();
				array[0] = (num2, num3);
				double num4 = num3;
				for (int i = 1; i < num; i++)
				{
					double num5 = ctx.Stack.PopBottom();
					double num6 = ctx.Stack.PopBottom();
					array[i] = (num4 + num5, num4 + num5 + num6);
					num4 = num4 + num5 + num6;
				}
				ctx.AddVerticalStemHints(array);
				ctx.Stack.Clear();
			})
		},
		{
			4,
			new LazyType2Command("vmoveto", 1, delegate(Type2BuildCharContext ctx)
			{
				double dy = ctx.Stack.PopBottom();
				ctx.AddVerticallMoveTo(dy);
				ctx.Stack.Clear();
			})
		},
		{
			5,
			new LazyType2Command("rlineto", 2, delegate(Type2BuildCharContext ctx)
			{
				int num = ctx.Stack.Length / 2;
				for (int i = 0; i < num; i++)
				{
					double dx = ctx.Stack.PopBottom();
					double dy = ctx.Stack.PopBottom();
					ctx.AddRelativeLine(dx, dy);
				}
				ctx.Stack.Clear();
			})
		},
		{
			6,
			new LazyType2Command("hlineto", 1, delegate(Type2BuildCharContext ctx)
			{
				bool flag = ctx.Stack.Length % 2 != 0;
				int num = ctx.Stack.Length - (flag ? 1 : 0);
				if (flag)
				{
					double dx = ctx.Stack.PopBottom();
					ctx.AddRelativeHorizontalLine(dx);
					for (int i = 0; i < num; i += 2)
					{
						ctx.AddRelativeVerticalLine(ctx.Stack.PopBottom());
						ctx.AddRelativeHorizontalLine(ctx.Stack.PopBottom());
					}
				}
				else
				{
					for (int j = 0; j < num; j += 2)
					{
						ctx.AddRelativeHorizontalLine(ctx.Stack.PopBottom());
						ctx.AddRelativeVerticalLine(ctx.Stack.PopBottom());
					}
				}
				ctx.Stack.Clear();
			})
		},
		{
			7,
			new LazyType2Command("vlineto", 1, delegate(Type2BuildCharContext ctx)
			{
				bool flag = ctx.Stack.Length % 2 != 0;
				int num = ctx.Stack.Length - (flag ? 1 : 0);
				if (flag)
				{
					double dy = ctx.Stack.PopBottom();
					ctx.AddRelativeVerticalLine(dy);
					for (int i = 0; i < num; i += 2)
					{
						ctx.AddRelativeHorizontalLine(ctx.Stack.PopBottom());
						ctx.AddRelativeVerticalLine(ctx.Stack.PopBottom());
					}
				}
				else
				{
					for (int j = 0; j < num; j += 2)
					{
						ctx.AddRelativeVerticalLine(ctx.Stack.PopBottom());
						ctx.AddRelativeHorizontalLine(ctx.Stack.PopBottom());
					}
				}
				ctx.Stack.Clear();
			})
		},
		{
			8,
			new LazyType2Command("rrcurveto", 6, delegate(Type2BuildCharContext ctx)
			{
				int num = ctx.Stack.Length / 6;
				for (int i = 0; i < num; i++)
				{
					ctx.AddRelativeBezierCurve(ctx.Stack.PopBottom(), ctx.Stack.PopBottom(), ctx.Stack.PopBottom(), ctx.Stack.PopBottom(), ctx.Stack.PopBottom(), ctx.Stack.PopBottom());
				}
				ctx.Stack.Clear();
			})
		},
		{
			10,
			new LazyType2Command("callsubr", 1, delegate
			{
			})
		},
		{
			11,
			new LazyType2Command("return", 0, delegate
			{
			})
		},
		{
			14,
			new LazyType2Command("endchar", 0, delegate(Type2BuildCharContext ctx)
			{
				ctx.Stack.Clear();
			})
		},
		{
			18,
			new LazyType2Command("hstemhm", 2, delegate(Type2BuildCharContext ctx)
			{
				int num = ctx.Stack.Length / 2;
				(double, double)[] array = new(double, double)[num];
				double num2 = ctx.Stack.PopBottom();
				double num3 = num2 + ctx.Stack.PopBottom();
				array[0] = (num2, num3);
				double num4 = num3;
				for (int i = 1; i < num; i++)
				{
					double num5 = ctx.Stack.PopBottom();
					double num6 = ctx.Stack.PopBottom();
					array[i] = (num4 + num5, num4 + num5 + num6);
					num4 = num4 + num5 + num6;
				}
				ctx.AddHorizontalStemHints(array);
				ctx.Stack.Clear();
			})
		},
		{
			19,
			new LazyType2Command("hintmask", 0, delegate(Type2BuildCharContext ctx)
			{
				ctx.Stack.Clear();
			})
		},
		{
			20,
			new LazyType2Command("cntrmask", 0, delegate(Type2BuildCharContext ctx)
			{
				ctx.Stack.Clear();
			})
		},
		{
			21,
			new LazyType2Command("rmoveto", 2, delegate(Type2BuildCharContext ctx)
			{
				double dx = ctx.Stack.PopBottom();
				double dy = ctx.Stack.PopBottom();
				ctx.AddRelativeMoveTo(dx, dy);
				ctx.Stack.Clear();
			})
		},
		{
			22,
			new LazyType2Command("hmoveto", 1, delegate(Type2BuildCharContext ctx)
			{
				double dx = ctx.Stack.PopBottom();
				ctx.AddHorizontalMoveTo(dx);
				ctx.Stack.Clear();
			})
		},
		{
			23,
			new LazyType2Command("vstemhm", 2, delegate(Type2BuildCharContext ctx)
			{
				int num = ctx.Stack.Length / 2;
				(double, double)[] array = new(double, double)[num];
				double num2 = ctx.Stack.PopBottom();
				double num3 = num2 + ctx.Stack.PopBottom();
				array[0] = (num2, num3);
				double num4 = num3;
				for (int i = 1; i < num; i++)
				{
					double num5 = ctx.Stack.PopBottom();
					double num6 = ctx.Stack.PopBottom();
					array[i] = (num4 + num5, num4 + num5 + num6);
					num4 = num4 + num5 + num6;
				}
				ctx.AddVerticalStemHints(array);
				ctx.Stack.Clear();
			})
		},
		{
			24,
			new LazyType2Command("rcurveline", 8, delegate(Type2BuildCharContext ctx)
			{
				int num = (ctx.Stack.Length - 2) / 6;
				for (int i = 0; i < num; i++)
				{
					ctx.AddRelativeBezierCurve(ctx.Stack.PopBottom(), ctx.Stack.PopBottom(), ctx.Stack.PopBottom(), ctx.Stack.PopBottom(), ctx.Stack.PopBottom(), ctx.Stack.PopBottom());
				}
				ctx.AddRelativeLine(ctx.Stack.PopBottom(), ctx.Stack.PopBottom());
				ctx.Stack.Clear();
			})
		},
		{
			25,
			new LazyType2Command("rlinecurve", 8, delegate(Type2BuildCharContext ctx)
			{
				int num = (ctx.Stack.Length - 6) / 2;
				for (int i = 0; i < num; i++)
				{
					ctx.AddRelativeLine(ctx.Stack.PopBottom(), ctx.Stack.PopBottom());
				}
				ctx.AddRelativeBezierCurve(ctx.Stack.PopBottom(), ctx.Stack.PopBottom(), ctx.Stack.PopBottom(), ctx.Stack.PopBottom(), ctx.Stack.PopBottom(), ctx.Stack.PopBottom());
				ctx.Stack.Clear();
			})
		},
		{
			26,
			new LazyType2Command("vvcurveto", 4, delegate(Type2BuildCharContext ctx)
			{
				bool flag = ctx.Stack.Length % 4 != 0;
				int num = ctx.Stack.Length / 4;
				for (int i = 0; i < num; i++)
				{
					double dx = 0.0;
					if (i == 0 && flag)
					{
						dx = ctx.Stack.PopBottom();
					}
					double dy = ctx.Stack.PopBottom();
					double dx2 = ctx.Stack.PopBottom();
					double dy2 = ctx.Stack.PopBottom();
					double dy3 = ctx.Stack.PopBottom();
					ctx.AddRelativeBezierCurve(dx, dy, dx2, dy2, 0.0, dy3);
				}
				ctx.Stack.Clear();
			})
		},
		{
			27,
			new LazyType2Command("hhcurveto", 4, delegate(Type2BuildCharContext ctx)
			{
				if (ctx.Stack.Length % 4 != 0)
				{
					double dy = ctx.Stack.PopBottom();
					double dx = ctx.Stack.PopBottom();
					double dx2 = ctx.Stack.PopBottom();
					double dy2 = ctx.Stack.PopBottom();
					double dx3 = ctx.Stack.PopBottom();
					ctx.AddRelativeBezierCurve(dx, dy, dx2, dy2, dx3, 0.0);
				}
				int num = ctx.Stack.Length / 4;
				for (int i = 0; i < num; i++)
				{
					double dx4 = ctx.Stack.PopBottom();
					double dx5 = ctx.Stack.PopBottom();
					double dy3 = ctx.Stack.PopBottom();
					double dx6 = ctx.Stack.PopBottom();
					ctx.AddRelativeBezierCurve(dx4, 0.0, dx5, dy3, dx6, 0.0);
				}
				ctx.Stack.Clear();
			})
		},
		{
			29,
			new LazyType2Command("callgsubr", 1, delegate
			{
			})
		},
		{
			30,
			new LazyType2Command("vhcurveto", 4, delegate(Type2BuildCharContext ctx)
			{
				int num = ctx.Stack.Length % 8;
				if (num <= 1)
				{
					int num2 = (ctx.Stack.Length - num) / 8;
					for (int i = 0; i < num2; i++)
					{
						double dy = ctx.Stack.PopBottom();
						double dx = ctx.Stack.PopBottom();
						double dy2 = ctx.Stack.PopBottom();
						double dx2 = ctx.Stack.PopBottom();
						ctx.AddRelativeBezierCurve(0.0, dy, dx, dy2, dx2, 0.0);
						double dx3 = ctx.Stack.PopBottom();
						double dx4 = ctx.Stack.PopBottom();
						double dy3 = ctx.Stack.PopBottom();
						double dy4 = ctx.Stack.PopBottom();
						double dx5 = 0.0;
						if (i == num2 - 1 && num == 1)
						{
							dx5 = ctx.Stack.PopBottom();
						}
						ctx.AddRelativeBezierCurve(dx3, 0.0, dx4, dy3, dx5, dy4);
					}
				}
				else
				{
					if (num != 4 && num != 5)
					{
						throw new InvalidOperationException($"Unexpected number of arguments for vhcurve to: {ctx.Stack.Length}.");
					}
					int num3 = (ctx.Stack.Length - num) / 8;
					double dy5 = ctx.Stack.PopBottom();
					double dx6 = ctx.Stack.PopBottom();
					double dy6 = ctx.Stack.PopBottom();
					double dx7 = ctx.Stack.PopBottom();
					double dy7 = ((ctx.Stack.Length == 1) ? ctx.Stack.PopBottom() : 0.0);
					ctx.AddRelativeBezierCurve(0.0, dy5, dx6, dy6, dx7, dy7);
					for (int j = 0; j < num3; j++)
					{
						double dx8 = ctx.Stack.PopBottom();
						double dx9 = ctx.Stack.PopBottom();
						double dy8 = ctx.Stack.PopBottom();
						double dy9 = ctx.Stack.PopBottom();
						ctx.AddRelativeBezierCurve(dx8, 0.0, dx9, dy8, 0.0, dy9);
						double dy10 = ctx.Stack.PopBottom();
						double dx10 = ctx.Stack.PopBottom();
						double dy11 = ctx.Stack.PopBottom();
						double dx11 = ctx.Stack.PopBottom();
						double dy12 = 0.0;
						if (j == num3 - 1 && num == 5)
						{
							dy12 = ctx.Stack.PopBottom();
						}
						ctx.AddRelativeBezierCurve(0.0, dy10, dx10, dy11, dx11, dy12);
					}
				}
				ctx.Stack.Clear();
			})
		},
		{
			31,
			new LazyType2Command("hvcurveto", 4, delegate(Type2BuildCharContext ctx)
			{
				int num = ctx.Stack.Length % 8;
				if (num <= 1)
				{
					int num2 = (ctx.Stack.Length - num) / 8;
					for (int i = 0; i < num2; i++)
					{
						double dx = ctx.Stack.PopBottom();
						double dx2 = ctx.Stack.PopBottom();
						double dy = ctx.Stack.PopBottom();
						double dy2 = ctx.Stack.PopBottom();
						ctx.AddRelativeBezierCurve(dx, 0.0, dx2, dy, 0.0, dy2);
						double dy3 = ctx.Stack.PopBottom();
						double dx3 = ctx.Stack.PopBottom();
						double dy4 = ctx.Stack.PopBottom();
						double dx4 = ctx.Stack.PopBottom();
						double dy5 = 0.0;
						if (i == num2 - 1 && num == 1)
						{
							dy5 = ctx.Stack.PopBottom();
						}
						ctx.AddRelativeBezierCurve(0.0, dy3, dx3, dy4, dx4, dy5);
					}
				}
				else
				{
					if (num != 4 && num != 5)
					{
						throw new InvalidOperationException($"Unexpected number of arguments for hvcurve to: {ctx.Stack.Length}.");
					}
					int num3 = (ctx.Stack.Length - num) / 8;
					double dx5 = ctx.Stack.PopBottom();
					double dx6 = ctx.Stack.PopBottom();
					double dy6 = ctx.Stack.PopBottom();
					double dy7 = ctx.Stack.PopBottom();
					double dx7 = ((ctx.Stack.Length == 1) ? ctx.Stack.PopBottom() : 0.0);
					ctx.AddRelativeBezierCurve(dx5, 0.0, dx6, dy6, dx7, dy7);
					for (int j = 0; j < num3; j++)
					{
						double dy8 = ctx.Stack.PopBottom();
						double dx8 = ctx.Stack.PopBottom();
						double dy9 = ctx.Stack.PopBottom();
						double dx9 = ctx.Stack.PopBottom();
						ctx.AddRelativeBezierCurve(0.0, dy8, dx8, dy9, dx9, 0.0);
						double dx10 = ctx.Stack.PopBottom();
						double dx11 = ctx.Stack.PopBottom();
						double dy10 = ctx.Stack.PopBottom();
						double dy11 = ctx.Stack.PopBottom();
						double dx12 = 0.0;
						if (j == num3 - 1 && num == 5)
						{
							dx12 = ctx.Stack.PopBottom();
						}
						ctx.AddRelativeBezierCurve(dx10, 0.0, dx11, dy10, dx12, dy11);
					}
				}
				ctx.Stack.Clear();
			})
		},
		{
			byte.MaxValue,
			new LazyType2Command("unknown", -1, delegate
			{
			})
		}
	};

	private static readonly IReadOnlyDictionary<byte, LazyType2Command> TwoByteCommandStore = new Dictionary<byte, LazyType2Command>
	{
		{
			3,
			new LazyType2Command("and", 2, delegate(Type2BuildCharContext ctx)
			{
				ctx.Stack.Push((ctx.Stack.PopTop() != 0.0 && ctx.Stack.PopTop() != 0.0) ? 1 : 0);
			})
		},
		{
			4,
			new LazyType2Command("or", 2, delegate(Type2BuildCharContext ctx)
			{
				double num = ctx.Stack.PopTop();
				double num2 = ctx.Stack.PopTop();
				ctx.Stack.Push((num != 0.0 || num2 != 0.0) ? 1 : 0);
			})
		},
		{
			5,
			new LazyType2Command("not", 1, delegate(Type2BuildCharContext ctx)
			{
				ctx.Stack.Push((ctx.Stack.PopTop() == 0.0) ? 1 : 0);
			})
		},
		{
			9,
			new LazyType2Command("abs", 1, delegate(Type2BuildCharContext ctx)
			{
				ctx.Stack.Push(Math.Abs(ctx.Stack.PopTop()));
			})
		},
		{
			10,
			new LazyType2Command("add", 2, delegate(Type2BuildCharContext ctx)
			{
				ctx.Stack.Push(ctx.Stack.PopTop() + ctx.Stack.PopTop());
			})
		},
		{
			11,
			new LazyType2Command("sub", 2, delegate(Type2BuildCharContext ctx)
			{
				double num = ctx.Stack.PopTop();
				double num2 = ctx.Stack.PopTop();
				ctx.Stack.Push(num2 - num);
			})
		},
		{
			12,
			new LazyType2Command("div", 2, delegate(Type2BuildCharContext ctx)
			{
				ctx.Stack.Push(ctx.Stack.PopTop() / ctx.Stack.PopTop());
			})
		},
		{
			14,
			new LazyType2Command("neg", 1, delegate(Type2BuildCharContext ctx)
			{
				ctx.Stack.Push(-1.0 * Math.Abs(ctx.Stack.PopTop()));
			})
		},
		{
			15,
			new LazyType2Command("eq", 2, delegate(Type2BuildCharContext ctx)
			{
				ctx.Stack.Push((ctx.Stack.PopTop() == ctx.Stack.PopTop()) ? 1 : 0);
			})
		},
		{
			18,
			new LazyType2Command("drop", 1, delegate(Type2BuildCharContext ctx)
			{
				ctx.Stack.PopTop();
			})
		},
		{
			20,
			new LazyType2Command("put", 2, delegate(Type2BuildCharContext ctx)
			{
				ctx.AddToTransientArray(ctx.Stack.PopTop(), (int)ctx.Stack.PopTop());
			})
		},
		{
			21,
			new LazyType2Command("get", 1, delegate(Type2BuildCharContext ctx)
			{
				ctx.Stack.Push(ctx.GetFromTransientArray((int)ctx.Stack.PopTop()));
			})
		},
		{
			22,
			new LazyType2Command("ifelse", 4, delegate
			{
			})
		},
		{
			23,
			new LazyType2Command("random", 0, delegate(Type2BuildCharContext ctx)
			{
				ctx.Stack.Push(0.5);
			})
		},
		{
			24,
			new LazyType2Command("mul", 2, delegate(Type2BuildCharContext ctx)
			{
				ctx.Stack.Push(ctx.Stack.PopTop() * ctx.Stack.PopTop());
			})
		},
		{
			26,
			new LazyType2Command("sqrt", 1, delegate(Type2BuildCharContext ctx)
			{
				ctx.Stack.Push(Math.Sqrt(ctx.Stack.PopTop()));
			})
		},
		{
			27,
			new LazyType2Command("dup", 1, delegate(Type2BuildCharContext ctx)
			{
				double value = ctx.Stack.PopTop();
				ctx.Stack.Push(value);
				ctx.Stack.Push(value);
			})
		},
		{
			28,
			new LazyType2Command("exch", 2, delegate(Type2BuildCharContext ctx)
			{
				double value = ctx.Stack.PopTop();
				double value2 = ctx.Stack.PopTop();
				ctx.Stack.Push(value);
				ctx.Stack.Push(value2);
			})
		},
		{
			29,
			new LazyType2Command("index", 2, delegate(Type2BuildCharContext ctx)
			{
				double num = ctx.Stack.PopTop();
				double value = ctx.Stack.CopyElementAt((int)num);
				ctx.Stack.Push(value);
			})
		},
		{
			30,
			new LazyType2Command("roll", 3, delegate
			{
			})
		},
		{
			34,
			new LazyType2Command("hflex", 7, delegate(Type2BuildCharContext ctx)
			{
				double dx = ctx.Stack.PopBottom();
				double dx2 = ctx.Stack.PopBottom();
				double num = ctx.Stack.PopBottom();
				double dx3 = ctx.Stack.PopBottom();
				double dx4 = ctx.Stack.PopBottom();
				double dx5 = ctx.Stack.PopBottom();
				double dx6 = ctx.Stack.PopBottom();
				ctx.AddRelativeBezierCurve(dx, 0.0, dx2, num, dx3, 0.0);
				ctx.AddRelativeBezierCurve(dx4, 0.0, dx5, 0.0 - num, dx6, 0.0);
				ctx.Stack.Clear();
			})
		},
		{
			35,
			new LazyType2Command("flex", 13, delegate(Type2BuildCharContext ctx)
			{
				ctx.AddRelativeBezierCurve(ctx.Stack.PopBottom(), ctx.Stack.PopBottom(), ctx.Stack.PopBottom(), ctx.Stack.PopBottom(), ctx.Stack.PopBottom(), ctx.Stack.PopBottom());
				ctx.AddRelativeBezierCurve(ctx.Stack.PopBottom(), ctx.Stack.PopBottom(), ctx.Stack.PopBottom(), ctx.Stack.PopBottom(), ctx.Stack.PopBottom(), ctx.Stack.PopBottom());
				ctx.Stack.PopBottom();
				ctx.Stack.Clear();
			})
		},
		{
			36,
			new LazyType2Command("hflex1", 9, delegate(Type2BuildCharContext ctx)
			{
				double dx = ctx.Stack.PopBottom();
				double num = ctx.Stack.PopBottom();
				double dx2 = ctx.Stack.PopBottom();
				double num2 = ctx.Stack.PopBottom();
				double dx3 = ctx.Stack.PopBottom();
				double dx4 = ctx.Stack.PopBottom();
				double dx5 = ctx.Stack.PopBottom();
				double num3 = ctx.Stack.PopBottom();
				double dx6 = ctx.Stack.PopBottom();
				ctx.AddRelativeBezierCurve(dx, num, dx2, num2, dx3, 0.0);
				ctx.AddRelativeBezierCurve(dx4, 0.0, dx5, num3, dx6, 0.0 - num3 - num2 - num);
				ctx.Stack.Clear();
			})
		},
		{
			37,
			new LazyType2Command("flex1", 11, delegate(Type2BuildCharContext ctx)
			{
				double num = ctx.Stack.PopBottom();
				double num2 = ctx.Stack.PopBottom();
				double num3 = ctx.Stack.PopBottom();
				double num4 = ctx.Stack.PopBottom();
				double num5 = ctx.Stack.PopBottom();
				double num6 = ctx.Stack.PopBottom();
				double num7 = ctx.Stack.PopBottom();
				double num8 = ctx.Stack.PopBottom();
				double num9 = ctx.Stack.PopBottom();
				double num10 = ctx.Stack.PopBottom();
				double num11 = ctx.Stack.PopBottom();
				double value = num + num3 + num5 + num7 + num9;
				double value2 = num2 + num4 + num6 + num8 + num10;
				bool flag = Math.Abs(value) > Math.Abs(value2);
				ctx.AddRelativeBezierCurve(num, num2, num3, num4, num5, num6);
				ctx.AddRelativeBezierCurve(num7, num8, num9, num10, flag ? num11 : 0.0, flag ? 0.0 : num11);
				ctx.Stack.Clear();
			})
		}
	};

	public static LazyType2Command GetCommand(Type2CharStrings.CommandSequence.CommandIdentifier identifier)
	{
		if (identifier.IsMultiByteCommand)
		{
			return TwoByteCommandStore[identifier.CommandId];
		}
		return SingleByteCommandStore[identifier.CommandId];
	}

	public static Type2CharStrings Parse(IReadOnlyList<ReadOnlyMemory<byte>> charStringBytes, CompactFontFormatSubroutinesSelector subroutinesSelector, ICompactFontFormatCharset charset)
	{
		if (charStringBytes == null)
		{
			throw new ArgumentNullException("charStringBytes");
		}
		if (subroutinesSelector == null)
		{
			throw new ArgumentNullException("subroutinesSelector");
		}
		Dictionary<string, Type2CharStrings.CommandSequence> dictionary = new Dictionary<string, Type2CharStrings.CommandSequence>();
		for (int i = 0; i < charStringBytes.Count; i++)
		{
			ReadOnlyMemory<byte> readOnlyMemory = charStringBytes[i];
			string nameByGlyphId = charset.GetNameByGlyphId(i);
			(CompactFontFormatIndex global, CompactFontFormatIndex local) subroutines = subroutinesSelector.GetSubroutines(i);
			CompactFontFormatIndex item = subroutines.global;
			CompactFontFormatIndex item2 = subroutines.local;
			ReadOnlySpan<byte> span = readOnlyMemory.Span;
			List<byte> list = new List<byte>(span.Length);
			ReadOnlySpan<byte>.Enumerator enumerator = span.GetEnumerator();
			while (enumerator.MoveNext())
			{
				byte current = enumerator.Current;
				list.Add(current);
			}
			Type2CharStrings.CommandSequence value = ParseSingle(list, item2, item);
			dictionary[nameByGlyphId] = value;
		}
		return new Type2CharStrings(dictionary);
	}

	private static Type2CharStrings.CommandSequence ParseSingle(List<byte> bytes, CompactFontFormatIndex localSubroutines, CompactFontFormatIndex globalSubroutines)
	{
		List<float> list = new List<float>();
		List<Type2CharStrings.CommandSequence.CommandIdentifier> list2 = new List<Type2CharStrings.CommandSequence.CommandIdentifier>();
		for (int i = 0; i < bytes.Count; i++)
		{
			byte b = bytes[i];
			if (b <= 31 && b != 28)
			{
				Type2CharStrings.CommandSequence.CommandIdentifier? command = GetCommand(b, bytes, list, list2, localSubroutines, globalSubroutines, ref i);
				if (command.HasValue)
				{
					list2.Add(command.Value);
				}
			}
			else
			{
				float item = InterpretNumber(b, bytes, ref i);
				list.Add(item);
			}
		}
		list.TrimExcess();
		return new Type2CharStrings.CommandSequence(list, list2);
	}

	private static float InterpretNumber(byte b, IReadOnlyList<byte> bytes, ref int i)
	{
		if (b == 28)
		{
			return (short)((bytes[++i] << 8) | bytes[++i]);
		}
		if (b >= 32 && b <= 246)
		{
			return b - 139;
		}
		if (b >= 247 && b <= 250)
		{
			byte b2 = bytes[++i];
			return (b - 247) * 256 + b2 + 108;
		}
		if (b >= 251 && b <= 254)
		{
			byte b3 = bytes[++i];
			return -((b - 251) * 256) - b3 - 108;
		}
		int num = (short)(bytes[++i] << 8) + bytes[++i];
		int num2 = (bytes[++i] << 8) + bytes[++i];
		return (float)num + (float)num2 / 65535f;
	}

	private static Type2CharStrings.CommandSequence.CommandIdentifier? GetCommand(byte b, List<byte> bytes, List<float> precedingValues, List<Type2CharStrings.CommandSequence.CommandIdentifier> precedingCommands, CompactFontFormatIndex localSubroutines, CompactFontFormatIndex globalSubroutines, ref int i)
	{
		switch (b)
		{
		case 12:
		{
			byte b2 = bytes[++i];
			if (TwoByteCommandStore.ContainsKey(b2))
			{
				return new Type2CharStrings.CommandSequence.CommandIdentifier(precedingValues.Count, isMultiByteCommand: true, b2);
			}
			return new Type2CharStrings.CommandSequence.CommandIdentifier(precedingValues.Count, isMultiByteCommand: false, byte.MaxValue);
		}
		case 10:
		case 29:
		{
			bool num2 = b == 10;
			int num3 = (int)precedingValues[precedingValues.Count - 1];
			int num4 = Type2BuildCharContext.CountToBias(num2 ? localSubroutines.Count : globalSubroutines.Count);
			int index = num3 + num4;
			ReadOnlyMemory<byte> readOnlyMemory = (num2 ? localSubroutines[index] : globalSubroutines[index]);
			bytes.RemoveRange(i - 1, 2);
			bytes.InsertRange(i - 1, new _003C_003Ez__ReadOnlyArray<byte>(readOnlyMemory.Span.ToArray()));
			precedingValues.RemoveAt(precedingValues.Count - 1);
			i -= 2;
			return null;
		}
		case 19:
		case 20:
		{
			int num = CalculatePrecedingHintBytes(precedingValues, precedingCommands);
			i += num;
			break;
		}
		}
		if (SingleByteCommandStore.ContainsKey(b))
		{
			if (b == 11)
			{
				return null;
			}
			return new Type2CharStrings.CommandSequence.CommandIdentifier(precedingValues.Count, isMultiByteCommand: false, b);
		}
		return new Type2CharStrings.CommandSequence.CommandIdentifier(precedingValues.Count, isMultiByteCommand: false, byte.MaxValue);
	}

	private static int CalculatePrecedingHintBytes(List<float> precedingValues, List<Type2CharStrings.CommandSequence.CommandIdentifier> precedingCommands)
	{
		int num = 0;
		int num2 = 0;
		bool flag = false;
		for (int i = -1; i < precedingValues.Count; i++)
		{
			if (i >= 0)
			{
				num2++;
			}
			for (int j = 0; j < precedingCommands.Count; j++)
			{
				Type2CharStrings.CommandSequence.CommandIdentifier commandIdentifier = precedingCommands[j];
				if (commandIdentifier.CommandIndex == i + 1)
				{
					if (!commandIdentifier.IsMultiByteCommand && (commandIdentifier.CommandId == 19 || commandIdentifier.CommandId == 20) && !flag)
					{
						flag = true;
						num += SafeStemCount(num2);
					}
					else if (!commandIdentifier.IsMultiByteCommand && !HintingCommandBytes.Contains(commandIdentifier.CommandId))
					{
						num2 = 0;
					}
					else if (commandIdentifier.IsMultiByteCommand && commandIdentifier.CommandId > 35)
					{
						num2 = 0;
					}
					else
					{
						num += SafeStemCount(num2);
						num2 = 0;
					}
					if (flag)
					{
						break;
					}
				}
			}
			if (flag)
			{
				break;
			}
		}
		int num3 = num;
		if (num2 > 0 && !flag)
		{
			num3 += SafeStemCount(num2);
		}
		return (int)Math.Ceiling((double)num3 / 8.0);
		static int SafeStemCount(int counts)
		{
			if (counts % 2 == 0)
			{
				return counts / 2;
			}
			return (counts - 1) / 2;
		}
	}
}
