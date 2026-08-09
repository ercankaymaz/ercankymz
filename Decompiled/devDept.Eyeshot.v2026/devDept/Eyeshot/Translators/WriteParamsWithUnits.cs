using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class WriteParamsWithUnits : WriteParams
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private linearUnitsType _0023_003DzYgMj3fzgkvQU3G5hkg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dzthm2Q35IG0_e_DHakg_003D_003D = string.Empty;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzyBRP4053wGoTJUgRTg_003D_003D = string.Empty;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzWmRFJUwQumqOA7mR0ncjhIo_003D = string.Empty;

	public linearUnitsType Units
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzYgMj3fzgkvQU3G5hkg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzYgMj3fzgkvQU3G5hkg_003D_003D = value;
		}
	}

	public string Author
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzthm2Q35IG0_e_DHakg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzthm2Q35IG0_e_DHakg_003D_003D = value;
		}
	}

	public string Organization
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzyBRP4053wGoTJUgRTg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzyBRP4053wGoTJUgRTg_003D_003D = value;
		}
	}

	public string OriginatingSystem
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzWmRFJUwQumqOA7mR0ncjhIo_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzWmRFJUwQumqOA7mR0ncjhIo_003D = value;
		}
	}

	public WriteParamsWithUnits(IWorkspace workspace, bool selectedOnly = false, bool openBlockOnly = false)
		: this(workspace.Document, selectedOnly, openBlockOnly)
	{
	}

	public WriteParamsWithUnits(Document document, bool selectedOnly = false, bool openBlockOnly = false)
		: base(document, selectedOnly, openBlockOnly)
	{
		Units = document.Units;
	}

	public WriteParamsWithUnits(IList<Entity> entities = null, LayerKeyedCollection layers = null, BlockKeyedCollection blocks = null, linearUnitsType units = linearUnitsType.Meters, bool selectedOnly = false)
		: base(entities, layers, blocks, selectedOnly)
	{
		Units = units;
	}
}
