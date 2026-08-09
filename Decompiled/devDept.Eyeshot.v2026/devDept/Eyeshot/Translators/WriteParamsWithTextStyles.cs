using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class WriteParamsWithTextStyles : WriteParamsWithMaterials
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private LineTypeKeyedCollection _0023_003DzDuFrfh82AJ9_0024N05F5w_003D_003D = new LineTypeKeyedCollection();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003DzO36PKpaF4knnuUUxHLXY5y8_003D = 1f;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private HatchPatternKeyedCollection _0023_003DzvIp358N6rMgkJ7PYLL0OJ9c_003D = new HatchPatternKeyedCollection();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextStyleKeyedCollection _0023_003DzOdpS5s330wsiSi_tbQ_003D_003D = new TextStyleKeyedCollection();

	public LineTypeKeyedCollection LineTypes
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzDuFrfh82AJ9_0024N05F5w_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzDuFrfh82AJ9_0024N05F5w_003D_003D = value;
		}
	}

	public float LineTypeScale
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzO36PKpaF4knnuUUxHLXY5y8_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzO36PKpaF4knnuUUxHLXY5y8_003D = value;
		}
	}

	public HatchPatternKeyedCollection HatchPatterns
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzvIp358N6rMgkJ7PYLL0OJ9c_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzvIp358N6rMgkJ7PYLL0OJ9c_003D = value;
		}
	}

	public TextStyleKeyedCollection TextStyles
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzOdpS5s330wsiSi_tbQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzOdpS5s330wsiSi_tbQ_003D_003D = value;
		}
	}

	public WriteParamsWithTextStyles(IWorkspace workspace, bool selectedOnly = false, bool openBlockOnly = false)
		: this(workspace.Document, selectedOnly, openBlockOnly)
	{
	}

	public WriteParamsWithTextStyles(Document document, bool selectedOnly = false, bool openBlockOnly = false)
		: base(document, selectedOnly, openBlockOnly)
	{
		if (document.LineTypes != null)
		{
			LineTypes = document.LineTypes;
		}
		if (document.HatchPatterns != null)
		{
			HatchPatterns = document.HatchPatterns;
		}
		if (document.TextStyles != null)
		{
			TextStyles = document.TextStyles;
		}
		LineTypeScale = document.LineTypeScale;
	}

	public WriteParamsWithTextStyles(IList<Entity> entities = null, LayerKeyedCollection layers = null, BlockKeyedCollection blocks = null, MaterialKeyedCollection materials = null, TextStyleKeyedCollection textStyles = null, LineTypeKeyedCollection lineTypes = null, linearUnitsType units = linearUnitsType.Meters, bool selectedOnly = false, HatchPatternKeyedCollection hatchPatterns = null)
		: base(entities, layers, blocks, materials, units, selectedOnly)
	{
		if (lineTypes != null)
		{
			LineTypes = lineTypes;
		}
		if (hatchPatterns != null)
		{
			HatchPatterns = hatchPatterns;
		}
		if (textStyles != null)
		{
			TextStyles = textStyles;
		}
	}
}
