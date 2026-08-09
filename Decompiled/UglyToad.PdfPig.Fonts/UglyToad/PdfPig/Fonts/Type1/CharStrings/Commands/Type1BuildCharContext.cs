using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.Type1.CharStrings.Commands;

internal class Type1BuildCharContext
{
	private readonly Func<int, IReadOnlyList<PdfSubpath>> characterByIndexFactory;

	private readonly Func<string, IReadOnlyList<PdfSubpath>> characterByNameFactory;

	public IReadOnlyDictionary<int, Type1CharStrings.CommandSequence> Subroutines { get; }

	public double WidthX { get; set; }

	public double WidthY { get; set; }

	public double LeftSideBearingX { get; set; }

	public double LeftSideBearingY { get; set; }

	public bool IsFlexing { get; set; }

	public List<PdfSubpath> Path { get; private set; } = new List<PdfSubpath>();

	public PdfPoint CurrentPosition { get; set; }

	public CharStringStack Stack { get; } = new CharStringStack();

	public CharStringStack PostscriptStack { get; } = new CharStringStack();

	public List<PdfPoint> FlexPoints { get; } = new List<PdfPoint>();

	public Type1BuildCharContext(IReadOnlyDictionary<int, Type1CharStrings.CommandSequence> subroutines, Func<int, IReadOnlyList<PdfSubpath>> characterByIndexFactory, Func<string, IReadOnlyList<PdfSubpath>> characterByNameFactory)
	{
		this.characterByIndexFactory = characterByIndexFactory ?? throw new ArgumentNullException("characterByIndexFactory");
		this.characterByNameFactory = characterByNameFactory ?? throw new ArgumentNullException("characterByNameFactory");
		Subroutines = subroutines ?? throw new ArgumentNullException("subroutines");
	}

	public void AddFlexPoint(PdfPoint point)
	{
		FlexPoints.Add(point);
	}

	public IReadOnlyList<PdfSubpath> GetCharacter(int characterCode)
	{
		return characterByIndexFactory(characterCode);
	}

	public IReadOnlyList<PdfSubpath> GetCharacter(string characterName)
	{
		return characterByNameFactory(characterName);
	}

	public void SetPath(IReadOnlyList<PdfSubpath> path)
	{
		Path = path.ToList() ?? throw new ArgumentNullException("path");
	}

	public void ClearFlexPoints()
	{
		FlexPoints.Clear();
	}
}
