using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ScintillaNET;

public static class HelperMethods
{
	private static readonly Dictionary<int, Color> knownColorMap;

	static HelperMethods()
	{
		knownColorMap = new Dictionary<int, Color>();
		foreach (KnownColor item in from KnownColor k in Enum.GetValues(typeof(KnownColor))
			where k >= KnownColor.Transparent && k < KnownColor.ButtonFace
			select k)
		{
			Color color = Color.FromKnownColor(item);
			knownColorMap[ToWin32Color(color)] = color;
		}
	}

	public static Color FromWin32Color(int color)
	{
		if ((color & 0xFF000000u) == 0L)
		{
			return Color.Transparent;
		}
		if (knownColorMap.TryGetValue(color, out var value))
		{
			return value;
		}
		return Color.FromArgb((color >> 24) & 0xFF, color & 0xFF, (color >> 8) & 0xFF, (color >> 16) & 0xFF);
	}

	public static int ToWin32Color(Color color)
	{
		return (color.A << 24) | color.R | (color.G << 8) | (color.B << 16);
	}

	public static Color FromWin32ColorOpaque(int color)
	{
		color |= -16777216;
		if (knownColorMap.TryGetValue(color, out var value))
		{
			return value;
		}
		return Color.FromArgb(color & 0xFF, (color >> 8) & 0xFF, (color >> 16) & 0xFF);
	}

	public static int ToWin32ColorOpaque(Color color)
	{
		return -16777216 | color.R | (color.G << 8) | (color.B << 16);
	}

	public static string GetFoldingState(this Scintilla scintilla, string separator = ";")
	{
		return string.Join(separator, (from f in scintilla.Lines
			where !f.Expanded
			select f.Index into f
			orderby f
			select f).ToArray());
	}

	public static void SetFoldingState(this Scintilla scintilla, string foldingState, string separator = ";")
	{
		scintilla.FoldAll(FoldAction.Expand);
		foreach (int item in foldingState.Split(new string[1] { separator }, StringSplitOptions.None).Select(int.Parse))
		{
			if (item >= 0 && item < scintilla.Lines.Count)
			{
				scintilla.Lines[item].ToggleFold();
			}
		}
	}
}
