#define DEBUG
using System;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteDoubleOverride : GlobalId, IPaletteDouble
{
	private PaletteBackInheritOverride _overrideBack;

	private PaletteBorderInheritOverride _overrideBorder;

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
		}
	}

	public IPaletteBack PaletteBack => _overrideBack;

	public IPaletteBorder PaletteBorder => _overrideBorder;

	public PaletteDoubleOverride(IPaletteDouble normalTriple, IPaletteDouble overrideTriple, PaletteState overrideState)
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
		Apply = false;
		Override = true;
		OverrideState = overrideState;
	}
}
