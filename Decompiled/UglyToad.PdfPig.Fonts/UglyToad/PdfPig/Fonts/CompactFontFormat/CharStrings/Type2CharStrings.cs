using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace UglyToad.PdfPig.Fonts.CompactFontFormat.CharStrings;

internal sealed class Type2CharStrings
{
	public sealed class CommandSequence
	{
		public readonly struct CommandIdentifier
		{
			public int CommandIndex { get; }

			public bool IsMultiByteCommand { get; }

			public byte CommandId { get; }

			public CommandIdentifier(int commandIndex, bool isMultiByteCommand, byte commandId)
			{
				CommandIndex = commandIndex;
				IsMultiByteCommand = isMultiByteCommand;
				CommandId = commandId;
			}
		}

		public IReadOnlyList<float> Values { get; }

		public IReadOnlyList<CommandIdentifier> CommandIdentifiers { get; }

		public CommandSequence(IReadOnlyList<float> values, IReadOnlyList<CommandIdentifier> commandIdentifiers)
		{
			Values = values;
			CommandIdentifiers = commandIdentifiers;
		}

		public IEnumerable<CommandIdentifier> GetCommandsAt(int index)
		{
			foreach (CommandIdentifier commandIdentifier in CommandIdentifiers)
			{
				if (commandIdentifier.CommandIndex == index)
				{
					yield return commandIdentifier;
				}
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = -1; i < Values.Count; i++)
			{
				if (i >= 0)
				{
					stringBuilder.AppendLine(Values[i].ToString("N", CultureInfo.InvariantCulture));
				}
				foreach (CommandIdentifier item in GetCommandsAt(i + 1))
				{
					stringBuilder.AppendLine(Type2CharStringParser.GetCommand(item).Name);
				}
			}
			return stringBuilder.ToString();
		}
	}

	private readonly object locker = new object();

	private readonly Dictionary<string, Type2Glyph> glyphs = new Dictionary<string, Type2Glyph>();

	public IReadOnlyDictionary<string, CommandSequence> CharStrings { get; }

	public Type2CharStrings(IReadOnlyDictionary<string, CommandSequence> charStrings)
	{
		CharStrings = charStrings ?? throw new ArgumentNullException("charStrings");
	}

	public Type2Glyph Generate(string name, double defaultWidthX, double nominalWidthX)
	{
		lock (locker)
		{
			if (glyphs.TryGetValue(name, out Type2Glyph value))
			{
				return value;
			}
			if (!CharStrings.TryGetValue(name, out CommandSequence value2) && !CharStrings.TryGetValue(".notdef", out value2))
			{
				throw new InvalidOperationException("No charstring sequence with the name /" + name + " in this font.");
			}
			try
			{
				Type2Glyph type2Glyph = Run(value2, defaultWidthX, nominalWidthX);
				glyphs[name] = type2Glyph;
				return type2Glyph;
			}
			catch (Exception innerException)
			{
				throw new InvalidOperationException($"Failed to interpret charstring for symbol with name: {name}. Commands: {value2}.", innerException);
			}
		}
	}

	private static Type2Glyph Run(CommandSequence sequence, double defaultWidthX, double nominalWidthX)
	{
		Type2BuildCharContext type2BuildCharContext = new Type2BuildCharContext();
		bool flag = false;
		for (int i = -1; i < sequence.Values.Count; i++)
		{
			if (i >= 0)
			{
				float num = sequence.Values[i];
				type2BuildCharContext.Stack.Push(num);
			}
			foreach (CommandSequence.CommandIdentifier item in sequence.GetCommandsAt(i + 1))
			{
				LazyType2Command command = Type2CharStringParser.GetCommand(item);
				bool flag2 = sequence.Values.Count + sequence.CommandIdentifiers.Count == 1;
				if (!flag)
				{
					flag = true;
					switch (command.Name)
					{
					case "hstem":
					case "vstem":
					case "vstemhm":
					case "hstemhm":
						if (type2BuildCharContext.Stack.Length % 2 != 0)
						{
							type2BuildCharContext.Width = nominalWidthX + type2BuildCharContext.Stack.PopBottom();
						}
						break;
					case "vmoveto":
					case "hmoveto":
						SetWidthFromArgumentsIfPresent(type2BuildCharContext, nominalWidthX, 1);
						break;
					case "rmoveto":
						SetWidthFromArgumentsIfPresent(type2BuildCharContext, nominalWidthX, 2);
						break;
					case "cntrmask":
					case "hintmask":
						SetWidthFromArgumentsIfPresent(type2BuildCharContext, nominalWidthX, 0);
						break;
					case "endchar":
						if (flag2)
						{
							type2BuildCharContext.Width = defaultWidthX;
						}
						else
						{
							SetWidthFromArgumentsIfPresent(type2BuildCharContext, nominalWidthX, 0);
						}
						break;
					default:
						flag = false;
						break;
					}
				}
				command.Run(type2BuildCharContext);
			}
		}
		return new Type2Glyph(type2BuildCharContext.Path, type2BuildCharContext.Width);
	}

	private static void SetWidthFromArgumentsIfPresent(Type2BuildCharContext context, double nomimalWidthX, int expectedArgumentLength)
	{
		if (context.Stack.Length > expectedArgumentLength)
		{
			context.Width = nomimalWidthX + context.Stack.PopBottom();
		}
	}
}
