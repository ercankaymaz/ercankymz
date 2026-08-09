using System;
using System.ComponentModel;
using System.Windows.Forms;
using devDept.Eyeshot.Control.Converters;

namespace devDept.Eyeshot.Control;

[Serializable]
[TypeConverter(typeof(SimulationShortcutKeysSettingsConverter))]
public class SimulationShortcutKeysSettings : ShortcutKeysSettings
{
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Start shortcut.")]
	public Keys Start { get; set; } = _0023_003DzxJO1MJzRJ33X();

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Pause shortcut.")]
	public Keys Pause { get; set; } = _0023_003Dzofgp3j1ZcESq();

	public SimulationShortcutKeysSettings()
		: this(_0023_003DzxJO1MJzRJ33X(), _0023_003Dzofgp3j1ZcESq())
	{
	}

	public SimulationShortcutKeysSettings(Keys start, Keys pause)
	{
		Start = start;
		Pause = pause;
	}

	public SimulationShortcutKeysSettings(Keys selectAll, Keys invertSelection, Keys deleteSelection, Keys zoomFit, Keys zoomIn, Keys zoomOut, Keys copySelection, Keys pasteSelection, Keys cutSelection, Keys groupSelection, Keys ungroupSelection, Keys rotateRight, Keys rotateUp, Keys rotateLeft, Keys rotateDown, Keys panRight, Keys panUp, Keys panLeft, Keys panDown, Keys cancelBackgroundWork, Keys navigationRight, Keys navigationLeft, Keys navigationUp, Keys navigationDown, Keys navigationForward, Keys navigationBackward, Keys start, Keys pause)
		: base(selectAll, invertSelection, deleteSelection, zoomFit, zoomIn, zoomOut, copySelection, pasteSelection, cutSelection, groupSelection, ungroupSelection, rotateRight, rotateUp, rotateLeft, rotateDown, panRight, panUp, panLeft, panDown, cancelBackgroundWork, navigationRight, navigationLeft, navigationUp, navigationDown, navigationForward, navigationBackward)
	{
		Start = start;
		Pause = pause;
	}

	private static Keys _0023_003DzxJO1MJzRJ33X()
	{
		return Keys.Space | Keys.Control;
	}

	private static Keys _0023_003Dzofgp3j1ZcESq()
	{
		return Keys.Space | Keys.Control;
	}

	internal override bool _0023_003Dz4XAvJ5aCRLKs()
	{
		if (Start == _0023_003DzxJO1MJzRJ33X() && Pause == _0023_003Dzofgp3j1ZcESq())
		{
			return base._0023_003Dz4XAvJ5aCRLKs();
		}
		return true;
	}
}
