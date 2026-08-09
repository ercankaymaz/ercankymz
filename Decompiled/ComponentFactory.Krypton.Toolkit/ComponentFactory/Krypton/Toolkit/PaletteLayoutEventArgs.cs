namespace ComponentFactory.Krypton.Toolkit;

public class PaletteLayoutEventArgs : NeedLayoutEventArgs
{
	private bool _needColorTable;

	public bool NeedColorTable => _needColorTable;

	public PaletteLayoutEventArgs(bool needLayout, bool needColorTable)
		: base(needLayout)
	{
		_needColorTable = needColorTable;
	}
}
