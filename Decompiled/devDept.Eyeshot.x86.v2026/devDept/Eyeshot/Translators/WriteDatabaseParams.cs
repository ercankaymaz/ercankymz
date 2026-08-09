using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class WriteDatabaseParams : WriteParamsWithDrawing
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzYUNlfKt1ahG4Q5g1gw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private attributeReferenceVisibilityType _0023_003Dz_LB3At_zzMT0HzTTkof9Ctw_003D = attributeReferenceVisibilityType.Normal;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private lineWeightUnitsType _0023_003Dzlg6SeyP6ObQxI9OaB2wlSJ0_003D = lineWeightUnitsType.Millimeters;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IViewport _0023_003DzNCJP3_VodFwPrPdKuw_003D_003D;

	public bool Purge
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzYUNlfKt1ahG4Q5g1gw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzYUNlfKt1ahG4Q5g1gw_003D_003D = value;
		}
	}

	public attributeReferenceVisibilityType AttributeReferenceVisibilityMode
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz_LB3At_zzMT0HzTTkof9Ctw_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz_LB3At_zzMT0HzTTkof9Ctw_003D = value;
		}
	}

	public lineWeightUnitsType LineWeightUnits
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzlg6SeyP6ObQxI9OaB2wlSJ0_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzlg6SeyP6ObQxI9OaB2wlSJ0_003D = value;
		}
	}

	public IViewport Viewport
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzNCJP3_VodFwPrPdKuw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzNCJP3_VodFwPrPdKuw_003D_003D = value;
		}
	}

	public WriteDatabaseParams(Document document, DrawingDocument drawing, bool selectedOnly = false, bool openBlockOnly = false)
		: base(document, drawing, selectedOnly, openBlockOnly)
	{
		AttributeReferenceVisibilityMode = document.AttributeReferenceVisibilityMode;
	}

	public WriteDatabaseParams(IList<Entity> entities = null, LayerKeyedCollection layers = null, BlockKeyedCollection blocks = null, MaterialKeyedCollection materials = null, TextStyleKeyedCollection textStyles = null, LineTypeKeyedCollection lineTypes = null, linearUnitsType units = linearUnitsType.Meters, bool selectedOnly = false, DrawingDocument drawing = null, HatchPatternKeyedCollection hatchPatterns = null)
		: base(entities, layers, blocks, materials, textStyles, lineTypes, units, selectedOnly, drawing, hatchPatterns)
	{
	}
}
