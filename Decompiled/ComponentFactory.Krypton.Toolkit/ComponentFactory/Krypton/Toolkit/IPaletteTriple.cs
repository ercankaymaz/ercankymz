namespace ComponentFactory.Krypton.Toolkit;

public interface IPaletteTriple
{
	IPaletteBack PaletteBack { get; }

	IPaletteBorder PaletteBorder { get; }

	IPaletteContent PaletteContent { get; }
}
