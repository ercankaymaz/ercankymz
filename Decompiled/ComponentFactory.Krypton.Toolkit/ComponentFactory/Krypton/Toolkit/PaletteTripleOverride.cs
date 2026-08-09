#define DEBUG
using System;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteTripleOverride : GlobalId, IPaletteTriple
{
	private PaletteBackInheritOverride _overrideBack;

	private PaletteBorderInheritOverride _overrideBorder;

	private PaletteContentInheritOverride _overrideContent;

	public bool Apply
	{
		get
		{
			return _overrideBack.Apply;
		}
		set
		{
			_overrideBack.Apply = value;
			_overrideBorder.Apply = value;
			_overrideContent.Apply = value;
		}
	}

	public bool Override
	{
		get
		{
			return _overrideBack.Override;
		}
		set
		{
			_overrideBack.Override = value;
			_overrideBorder.Override = value;
			_overrideContent.Override = value;
		}
	}

	public PaletteState OverrideState
	{
		get
		{
			return _overrideBack.OverrideState;
		}
		set
		{
			_overrideBack.OverrideState = value;
			_overrideBorder.OverrideState = value;
			_overrideContent.OverrideState = value;
		}
	}

	public IPaletteBack PaletteBack => _overrideBack;

	public IPaletteBorder PaletteBorder => _overrideBorder;

	public IPaletteContent PaletteContent => _overrideContent;

	public PaletteTripleOverride(IPaletteTriple normalTriple, IPaletteTriple overrideTriple, PaletteState overrideState)
	{
		Debug.Assert(normalTriple != null);
		Debug.Assert(overrideTriple != null);
		if (normalTriple == null)
		{
			throw new ArgumentNullException("normalTriple");
		}
		if (overrideTriple == null)
		{
			throw new ArgumentNullException("overrideTriple");
		}
		_overrideBack = new PaletteBackInheritOverride(normalTriple.PaletteBack, overrideTriple.PaletteBack);
		_overrideBorder = new PaletteBorderInheritOverride(normalTriple.PaletteBorder, overrideTriple.PaletteBorder);
		_overrideContent = new PaletteContentInheritOverride(normalTriple.PaletteContent, overrideTriple.PaletteContent);
		Apply = false;
		Override = true;
		OverrideState = overrideState;
	}

	public void SetPalettes(IPaletteTriple normalTriple, IPaletteTriple overrideTriple)
	{
		_overrideBack.SetPalettes(normalTriple.PaletteBack, overrideTriple.PaletteBack);
		_overrideBorder.SetPalettes(normalTriple.PaletteBorder, overrideTriple.PaletteBorder);
		_overrideContent.SetPalettes(normalTriple.PaletteContent, overrideTriple.PaletteContent);
	}
}
