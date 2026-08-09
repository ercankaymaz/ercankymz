using System;
using System.ComponentModel;
using System.Windows.Forms;
using devDept.Eyeshot.Control.Converters;

namespace devDept.Eyeshot.Control;

[Serializable]
[TypeConverter(typeof(ManufactureShortcutKeysSettingsConverter))]
public class ManufactureShortcutKeysSettings : ShortcutKeysSettings
{
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Start shortcut.")]
	public Keys Start { get; set; } = _0023_003DzxJO1MJzRJ33X();

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Pause shortcut.")]
	public Keys Pause { get; set; } = _0023_003Dzofgp3j1ZcESq();

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Previous shortcut.")]
	public Keys Previous { get; set; } = _0023_003DzPCIBHsCv71_1();

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Next shortcut.")]
	public Keys Next { get; set; } = _0023_003DzT_3fxNialxQ_0024();

	public ManufactureShortcutKeysSettings()
		: this(_0023_003DzxJO1MJzRJ33X(), _0023_003Dzofgp3j1ZcESq(), _0023_003DzT_3fxNialxQ_0024(), _0023_003DzPCIBHsCv71_1())
	{
	}

	public ManufactureShortcutKeysSettings(Keys start, Keys pause, Keys next, Keys previous)
	{
		Start = start;
		Pause = pause;
		Next = next;
		Previous = previous;
	}

	public ManufactureShortcutKeysSettings(Keys selectAll, Keys invertSelection, Keys deleteSelection, Keys zoomFit, Keys zoomIn, Keys zoomOut, Keys copySelection, Keys pasteSelection, Keys cutSelection, Keys groupSelection, Keys ungroupSelection, Keys rotateRight, Keys rotateUp, Keys rotateLeft, Keys rotateDown, Keys panRight, Keys panUp, Keys panLeft, Keys panDown, Keys cancelBackgroundWork, Keys navigationRight, Keys navigationLeft, Keys navigationUp, Keys navigationDown, Keys navigationForward, Keys navigationBackward, Keys start, Keys pause, Keys next, Keys previous)
		: base(selectAll, invertSelection, deleteSelection, zoomFit, zoomIn, zoomOut, copySelection, pasteSelection, cutSelection, groupSelection, ungroupSelection, rotateRight, rotateUp, rotateLeft, rotateDown, panRight, panUp, panLeft, panDown, cancelBackgroundWork, navigationRight, navigationLeft, navigationUp, navigationDown, navigationForward, navigationBackward)
	{
		Start = start;
		Pause = pause;
		Next = next;
		Previous = previous;
	}

	private static Keys _0023_003DzxJO1MJzRJ33X()
	{
		return Keys.Space | Keys.Control;
	}

	private static Keys _0023_003Dzofgp3j1ZcESq()
	{
		return Keys.Space | Keys.Control;
	}

	private static Keys _0023_003DzPCIBHsCv71_1()
	{
		return Keys.L | Keys.Control;
	}

	private static Keys _0023_003DzT_3fxNialxQ_0024()
	{
		return Keys.R | Keys.Control;
	}

	internal override bool _0023_003Dz4XAvJ5aCRLKs()
	{
		if (Start == _0023_003DzxJO1MJzRJ33X() && Pause == _0023_003Dzofgp3j1ZcESq() && Previous == _0023_003DzPCIBHsCv71_1() && Next == _0023_003DzT_3fxNialxQ_0024())
		{
			return base._0023_003Dz4XAvJ5aCRLKs();
		}
		return true;
	}
}
