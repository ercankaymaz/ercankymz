using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot.Translators;

public class WriteParams
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IList<Entity> _0023_003DzirHP2g6iDbM7YBocSw_003D_003D = new List<Entity>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BlockKeyedCollection _0023_003DzF97WMq_0024wP8gY4FUd3g_003D_003D = new BlockKeyedCollection();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private LayerKeyedCollection _0023_003DzSolg7xy8nvImQawkYg_003D_003D = new LayerKeyedCollection();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzP8Ly7pk6GNlWiejV_hvwkZw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dzw_00243RVxXbGKFd8MNwoRb2OjE_003D;

	public IList<Entity> Entities
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzirHP2g6iDbM7YBocSw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzirHP2g6iDbM7YBocSw_003D_003D = value;
		}
	}

	public BlockKeyedCollection Blocks
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzF97WMq_0024wP8gY4FUd3g_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzF97WMq_0024wP8gY4FUd3g_003D_003D = value;
		}
	}

	public LayerKeyedCollection Layers
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzSolg7xy8nvImQawkYg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzSolg7xy8nvImQawkYg_003D_003D = value;
		}
	}

	public bool SelectedOnly
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzP8Ly7pk6GNlWiejV_hvwkZw_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzP8Ly7pk6GNlWiejV_hvwkZw_003D = value;
		}
	}

	protected internal string OpenBlockName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzw_00243RVxXbGKFd8MNwoRb2OjE_003D;
		}
	}

	public WriteParams(IWorkspace workspace, bool selectedOnly = false, bool openBlockOnly = false)
		: this(workspace.Document, selectedOnly, openBlockOnly)
	{
	}

	public WriteParams(Document document, bool selectedOnly = false, bool openBlockOnly = false)
		: this(null, document.Layers, document.Blocks, selectedOnly)
	{
		if (openBlockOnly && !document._0023_003Dzz77R4jydnmt8hZDOvQ_003D_003D())
		{
			_0023_003DzZtTRSqEnW97m(document._0023_003DzLnvwYhzuV1KC().Name);
		}
	}

	public WriteParams(IList<Entity> entities = null, LayerKeyedCollection layers = null, BlockKeyedCollection blocks = null, bool selectedOnly = false)
	{
		if (entities != null)
		{
			Entities = entities;
		}
		if (blocks != null)
		{
			Blocks = blocks;
		}
		if (layers != null)
		{
			Layers = layers;
		}
		SelectedOnly = selectedOnly;
	}

	private void _0023_003DzZtTRSqEnW97m(string _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dzw_00243RVxXbGKFd8MNwoRb2OjE_003D = _0023_003DzPzO_0024GUk_003D;
	}
}
