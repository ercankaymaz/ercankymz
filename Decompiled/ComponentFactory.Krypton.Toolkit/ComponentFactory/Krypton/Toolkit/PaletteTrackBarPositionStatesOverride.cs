#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteTrackBarPositionStatesOverride : GlobalId
{
	private PaletteElementColorInheritOverride _overridePositionState;

	public bool Apply
	{
		get
		{
			return _overridePositionState.Apply;
		}
		set
		{
			_overridePositionState.Apply = value;
		}
	}

	public bool Override
	{
		get
		{
			return _overridePositionState.Override;
		}
		set
		{
			_overridePositionState.Override = value;
		}
	}

	public PaletteState OverrideState
	{
		get
		{
			return _overridePositionState.OverrideState;
		}
		set
		{
			_overridePositionState.OverrideState = value;
		}
	}

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining position appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteElementColorInheritOverride Position => _overridePositionState;

	public PaletteTrackBarPositionStatesOverride(PaletteTrackBarRedirect normalStates, PaletteTrackBarPositionStates overrideStates, PaletteState overrideState)
	{
		Debug.Assert(normalStates != null);
		Debug.Assert(overrideStates != null);
		if (normalStates == null)
		{
			throw new ArgumentNullException("normalStates");
		}
		if (overrideStates == null)
		{
			throw new ArgumentNullException("overrideStates");
		}
		_overridePositionState = new PaletteElementColorInheritOverride(normalStates.Position, overrideStates.Position);
		Apply = false;
		Override = true;
		OverrideState = overrideState;
	}

	public void SetPalettes(PaletteTrackBarRedirect normalStates, PaletteTrackBarPositionStates overrideStates)
	{
		_overridePositionState.SetPalettes(normalStates.Position, overrideStates.Position);
	}
}
