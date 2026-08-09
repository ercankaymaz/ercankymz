using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts.Type1.CharStrings.Commands;

namespace UglyToad.PdfPig.Fonts.Type1.CharStrings;

internal class Type1CharStrings
{
	public class CommandSequence
	{
		public IReadOnlyList<Union<double, LazyType1Command>> Commands { get; }

		public CommandSequence(IReadOnlyList<Union<double, LazyType1Command>> commands)
		{
			Commands = commands ?? throw new ArgumentNullException("commands");
		}

		public override string ToString()
		{
			return string.Join(", ", Commands.Select((Union<double, LazyType1Command> x) => x.ToString()));
		}
	}

	private readonly IReadOnlyDictionary<int, string> charStringIndexToName;

	private readonly object locker = new object();

	private readonly Dictionary<string, IReadOnlyList<PdfSubpath>> glyphs = new Dictionary<string, IReadOnlyList<PdfSubpath>>();

	public IReadOnlyDictionary<string, CommandSequence> CharStrings { get; }

	public IReadOnlyDictionary<int, CommandSequence> Subroutines { get; }

	public Type1CharStrings(IReadOnlyDictionary<string, CommandSequence> charStrings, IReadOnlyDictionary<int, string> charStringIndexToName, IReadOnlyDictionary<int, CommandSequence> subroutines)
	{
		this.charStringIndexToName = charStringIndexToName ?? throw new ArgumentNullException("charStringIndexToName");
		CharStrings = charStrings ?? throw new ArgumentNullException("charStrings");
		Subroutines = subroutines ?? throw new ArgumentNullException("subroutines");
	}

	public bool TryGenerate(string name, out IReadOnlyList<PdfSubpath> path)
	{
		path = new List<PdfSubpath>();
		lock (locker)
		{
			if (glyphs.TryGetValue(name, out path))
			{
				return true;
			}
			if (!CharStrings.TryGetValue(name, out CommandSequence value))
			{
				return false;
			}
			try
			{
				path = Run(value);
				glyphs[name] = path;
			}
			catch
			{
				return false;
			}
		}
		return true;
	}

	private IReadOnlyList<PdfSubpath> Run(CommandSequence sequence)
	{
		Type1BuildCharContext type1BuildCharContext = new Type1BuildCharContext(Subroutines, delegate(int i)
		{
			if (!charStringIndexToName.TryGetValue(i, out string value))
			{
				throw new InvalidOperationException($"Tried to retrieve Type 1 charstring by index {i} which did not exist.");
			}
			if (glyphs.TryGetValue(value, out IReadOnlyList<PdfSubpath> value2))
			{
				return value2;
			}
			if (!CharStrings.TryGetValue(value, out CommandSequence value3))
			{
				throw new InvalidOperationException($"Tried to retrieve Type 1 charstring by index {i} which mapped to name {value} but was not found in the charstrings.");
			}
			IReadOnlyList<PdfSubpath> readOnlyList = Run(value3);
			glyphs[value] = readOnlyList;
			return readOnlyList;
		}, delegate(string s)
		{
			if (glyphs.TryGetValue(s, out IReadOnlyList<PdfSubpath> value))
			{
				return value;
			}
			if (!CharStrings.TryGetValue(s, out CommandSequence value2))
			{
				throw new InvalidOperationException("Tried to retrieve Type 1 charstring by name " + s + " but it was not found in the charstrings.");
			}
			IReadOnlyList<PdfSubpath> readOnlyList = Run(value2);
			glyphs[s] = readOnlyList;
			return readOnlyList;
		});
		foreach (Union<double, LazyType1Command> command in sequence.Commands)
		{
			LazyType1Command b;
			if (command.TryGetFirst(out var a))
			{
				type1BuildCharContext.Stack.Push(a);
			}
			else if (command.TryGetSecond(out b))
			{
				b.Run(type1BuildCharContext);
			}
		}
		return type1BuildCharContext.Path;
	}
}
