using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class Write3DPdfParams : WritePrcParams
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Size _0023_003DzXhoOUovzujfdi4qfYhdIJow_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Rectangle _0023_003DzaIKRUdewv2PmlAvCuQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzLLT_0024XzauvxIbfAriUSLElHp3gDn3;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzitiUulbkUTYGrFrr2sOtn2I_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dzol4Tj_A20FnlzSDDHQqkSpc_003D = 2;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Write3DPDF.renderMode _0023_003DztdrnjldLb0QHpQ8x_0024ncQ9v0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzpcXw7AMT6e3qmJAqrIqbd4U_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzQky1kjR5IdbuJ_0024OlNvNY4Ak_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dzhd6BNFFPPXA32OZegE_0024Kb1k_003D;

	public Size PaperSize
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzXhoOUovzujfdi4qfYhdIJow_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzXhoOUovzujfdi4qfYhdIJow_003D = value;
		}
	}

	public Rectangle ViewRect
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzaIKRUdewv2PmlAvCuQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzaIKRUdewv2PmlAvCuQ_003D_003D = value;
		}
	}

	public Color BackGroundColor
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzLLT_0024XzauvxIbfAriUSLElHp3gDn3;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzLLT_0024XzauvxIbfAriUSLElHp3gDn3 = value;
		}
	}

	public bool TransparentBackground
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzitiUulbkUTYGrFrr2sOtn2I_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzitiUulbkUTYGrFrr2sOtn2I_003D = value;
		}
	}

	public int ViewBorderWidth
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzol4Tj_A20FnlzSDDHQqkSpc_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzol4Tj_A20FnlzSDDHQqkSpc_003D = value;
		}
	}

	public Write3DPDF.renderMode RenderMode
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DztdrnjldLb0QHpQ8x_0024ncQ9v0_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DztdrnjldLb0QHpQ8x_0024ncQ9v0_003D = value;
		}
	}

	public bool ToolbarVisibility
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzpcXw7AMT6e3qmJAqrIqbd4U_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzpcXw7AMT6e3qmJAqrIqbd4U_003D = value;
		}
	}

	public string JavaScript
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzQky1kjR5IdbuJ_0024OlNvNY4Ak_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzQky1kjR5IdbuJ_0024OlNvNY4Ak_003D = value;
		}
	}

	public bool ModelTreeVisibility
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzhd6BNFFPPXA32OZegE_0024Kb1k_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzhd6BNFFPPXA32OZegE_0024Kb1k_003D = value;
		}
	}

	public Write3DPdfParams(DesignDocument design, bool selectedOnly = false, bool openBlockOnly = false)
		: this(design, new Size(842, 595), new Rectangle(10, 10, 822, 575), selectedOnly, openBlockOnly)
	{
	}

	public Write3DPdfParams(DesignDocument design, Size paperSize, Rectangle viewRect, bool selectedOnly = false, bool openBlockOnly = false)
		: base(design, selectedOnly, openBlockOnly)
	{
		PaperSize = paperSize;
		ViewRect = viewRect;
		BackGroundColor = Color.White;
	}

	public Write3DPdfParams(IList<Entity> entities = null, LayerKeyedCollection layers = null, BlockKeyedCollection blocks = null, MaterialKeyedCollection materials = null, TextStyleKeyedCollection textStyles = null, LineTypeKeyedCollection lineTypes = null, linearUnitsType units = linearUnitsType.Meters, bool selectedOnly = false, HatchPatternKeyedCollection hatchPatterns = null)
		: base(entities, layers, blocks, materials, textStyles, lineTypes, units, selectedOnly, hatchPatterns)
	{
		PaperSize = new Size(842, 595);
		ViewRect = new Rectangle(10, 10, 822, 575);
	}
}
