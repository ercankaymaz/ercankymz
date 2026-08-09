#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteTrackBarStatesOverride : GlobalId
{
	private PaletteBack _back;

	private PaletteElementColorInheritOverride _overrideTickState;

	private PaletteElementColorInheritOverride _overrideTrackState;

	private PaletteElementColorInheritOverride _overridePositionState;

	public bool Apply
	{
		get
		{
			return _overrideTickState.Apply;
		}
		set
		{
			_overrideTickState.Apply = value;
			_overrideTrackState.Apply = value;
			_overridePositionState.Apply = value;
		}
	}

	public bool Override
	{
		get
		{
			return _overrideTickState.Override;
		}
		set
		{
			_overrideTickState.Override = value;
			_overrideTrackState.Override = value;
			_overridePositionState.Override = value;
		}
	}

	public PaletteState OverrideState
	{
		get
		{
			return _overrideTickState.OverrideState;
		}
		set
		{
			_overrideTickState.OverrideState = value;
			_overrideTrackState.OverrideState = value;
			_overridePositionState.OverrideState = value;
		}
	}

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining background appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteBack Back => _back;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining tick appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteElementColorInheritOverride Tick => _overrideTickState;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining track appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteElementColorInheritOverride Track => _overrideTrackState;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining position appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteElementColorInheritOverride Position => _overridePositionState;

	public PaletteTrackBarStatesOverride(PaletteTrackBarRedirect normalStates, PaletteTrackBarStates overrideStates, PaletteState overrideState)
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
		_back = normalStates.Back;
		_overrideTickState = new PaletteElementColorInheritOverride(normalStates.Tick, overrideStates.Tick);
		_overrideTrackState = new PaletteElementColorInheritOverride(normalStates.Track, overrideStates.Track);
		_overridePositionState = new PaletteElementColorInheritOverride(normalStates.Position, overrideStates.Position);
		Apply = false;
		Override = true;
		OverrideState = overrideState;
	}

	public void SetPalettes(PaletteTrackBarRedirect normalStates, PaletteTrackBarStates overrideStates)
	{
		_overrideTickState.SetPalettes(normalStates.Tick, overrideStates.Tick);
		_overrideTrackState.SetPalettes(normalStates.Track, overrideStates.Track);
		_overridePositionState.SetPalettes(normalStates.Position, overrideStates.Position);
	}
}
