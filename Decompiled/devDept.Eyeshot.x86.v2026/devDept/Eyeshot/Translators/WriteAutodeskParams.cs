using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class WriteAutodeskParams : WriteDatabaseParams
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private autodeskVersionType _0023_003DziDEmoNxbWhvzWDD5lw_003D_003D = autodeskVersionType.Acad2007;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzxWei8_u_0024vmvryE6vYw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzlKbmHFHkLoL7x53R2iI5chrYwnhX;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzeX95G209RWwrGYMYtQ_003D_003D = string.Empty;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private WriteAutodesk.formatType _0023_003Dz_Oo1Bz9g9pmeYSktNg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz9USXgL1qOXxR67VD4mlXVH7J4HNi;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzPsRIoAMv9gF55LoKySYFquc_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzCGlwdRrPyP6i = Color.White;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzC34RfKpFObHWLaDL5oXOD_0024Q_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<KeyValuePair<short, object>> _0023_003Dzk0Abw9AKbx_0024AKtVVsA_003D_003D;

	public autodeskVersionType Version
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DziDEmoNxbWhvzWDD5lw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DziDEmoNxbWhvzWDD5lw_003D_003D = value;
		}
	}

	public double Deviation
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzxWei8_u_0024vmvryE6vYw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzxWei8_u_0024vmvryE6vYw_003D_003D = value;
		}
	}

	public bool ExplodeViews
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzlKbmHFHkLoL7x53R2iI5chrYwnhX;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzlKbmHFHkLoL7x53R2iI5chrYwnhX = value;
		}
	}

	public string Password
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzeX95G209RWwrGYMYtQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzeX95G209RWwrGYMYtQ_003D_003D = value;
		}
	}

	public WriteAutodesk.formatType Format
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz_Oo1Bz9g9pmeYSktNg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz_Oo1Bz9g9pmeYSktNg_003D_003D = value;
		}
	}

	public bool CurveAsFitSpline
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz9USXgL1qOXxR67VD4mlXVH7J4HNi;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz9USXgL1qOXxR67VD4mlXVH7J4HNi = value;
		}
	}

	public bool AciColors
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzPsRIoAMv9gF55LoKySYFquc_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzPsRIoAMv9gF55LoKySYFquc_003D = value;
		}
	}

	public Color ForegroundColor
	{
		get
		{
			return _0023_003DzCGlwdRrPyP6i;
		}
		set
		{
			if (value.ToArgb() != Color.White.ToArgb() && value.ToArgb() != Color.Black.ToArgb())
			{
				throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526864));
			}
			_0023_003DzCGlwdRrPyP6i = value;
		}
	}

	public string TextureImagesPath
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzC34RfKpFObHWLaDL5oXOD_0024Q_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzC34RfKpFObHWLaDL5oXOD_0024Q_003D = value;
		}
	}

	public List<KeyValuePair<short, object>> ModelXData
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzk0Abw9AKbx_0024AKtVVsA_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzk0Abw9AKbx_0024AKtVVsA_003D_003D = value;
		}
	}

	public WriteAutodeskParams(DesignDocument design)
		: base(design, null)
	{
	}

	public WriteAutodeskParams(DesignDocument design, DrawingDocument drawing = null, bool selectedOnly = false, bool explodeViews = false, double deviation = 1.0, bool openBlockOnly = false)
		: base(design, drawing, selectedOnly, openBlockOnly)
	{
		ExplodeViews = explodeViews;
		Deviation = deviation;
	}

	public WriteAutodeskParams(DrawingDocument drawing, bool selectedOnly = false, double deviation = 1.0, bool openBlockOnly = false)
		: base(drawing, null, selectedOnly, openBlockOnly)
	{
		base.Units = drawing.ActiveSheet.Units;
		ExplodeViews = true;
		Deviation = deviation;
	}

	public WriteAutodeskParams(IList<Entity> entities = null, LayerKeyedCollection layers = null, BlockKeyedCollection blocks = null, MaterialKeyedCollection materials = null, TextStyleKeyedCollection textStyles = null, LineTypeKeyedCollection lineTypes = null, linearUnitsType units = linearUnitsType.Millimeters, bool selectedOnly = false, DrawingDocument drawing = null, bool explodeViews = false, double deviation = 1.0, HatchPatternKeyedCollection hatchPatterns = null)
		: base(entities, layers, blocks, materials, textStyles, lineTypes, units, selectedOnly, drawing, hatchPatterns)
	{
		ExplodeViews = explodeViews;
		Deviation = deviation;
	}
}
