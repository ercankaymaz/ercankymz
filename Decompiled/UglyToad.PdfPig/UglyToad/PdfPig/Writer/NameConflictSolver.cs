using System.Collections.Generic;

namespace UglyToad.PdfPig.Writer;

internal class NameConflictSolver
{
	private readonly string prefix;

	private int key;

	private readonly HashSet<string> xobjectNamesUsed = new HashSet<string>();

	public NameConflictSolver(string prefix)
	{
		this.prefix = prefix;
	}

	private string ExtractPrefix(string? name)
	{
		if (name == null)
		{
			return prefix;
		}
		int i;
		for (i = 0; i < name.Length && (name[i] < '0' || name[i] > '9'); i++)
		{
		}
		if (i == 0)
		{
			return prefix;
		}
		return name.Substring(0, i);
	}

	public string NewName(string? originalName = null)
	{
		string arg = ExtractPrefix(originalName);
		string text = $"{arg}{key}";
		while (xobjectNamesUsed.Contains(text))
		{
			text = $"{arg}{++key}";
		}
		xobjectNamesUsed.Add(text);
		return text;
	}

	public string FixName(string name)
	{
		if (xobjectNamesUsed.Contains(name))
		{
			return NewName(name);
		}
		xobjectNamesUsed.Add(name);
		return name;
	}
}
