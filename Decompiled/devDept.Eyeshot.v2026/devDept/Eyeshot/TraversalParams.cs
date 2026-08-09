using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot;

public class TraversalParams : IIsolateParams
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzlVfkB344HnlGhuCmUA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly BlockKeyedCollection _0023_003DzF97WMq_0024wP8gY4FUd3g_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Stack<Transformation> _0023_003DzsJ9pkIj9pPNuV3JRSyJ_wFY_003D = new Stack<Transformation>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Document _0023_003Dz_i1p8wE1ysPPh1ibUA_003D_003D;

	public readonly IWorkspace Workspace;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzNtIn_0024WLIzGUl;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Stack<BlockReference> _0023_003DzojrRmr8_003D = new Stack<BlockReference>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzPD5TPmaVKZ9W;

	public BlockKeyedCollection Blocks
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzF97WMq_0024wP8gY4FUd3g_003D_003D;
		}
	}

	public Transformation Transformation => _0023_003DzsJ9pkIj9pPNuV3JRSyJ_wFY_003D.Peek();

	public Document Document
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz_i1p8wE1ysPPh1ibUA_003D_003D;
		}
	}

	internal IWorkspaceInternal workspaceInternal => (IWorkspaceInternal)Workspace;

	public bool SkipTexts
	{
		get
		{
			return _0023_003DzNtIn_0024WLIzGUl;
		}
		set
		{
			_0023_003DznkEI83gHh_l7();
			_0023_003DzNtIn_0024WLIzGUl = value;
		}
	}

	public Stack<BlockReference> Parents
	{
		get
		{
			return _0023_003DzojrRmr8_003D;
		}
		set
		{
			_0023_003DznkEI83gHh_l7();
			_0023_003DzojrRmr8_003D = value;
		}
	}

	public bool ParentIsolated
	{
		get
		{
			return _0023_003DzPD5TPmaVKZ9W;
		}
		set
		{
			_0023_003DznkEI83gHh_l7();
			_0023_003DzPD5TPmaVKZ9W = value;
		}
	}

	public TraversalParams(Transformation transform = null)
	{
		_0023_003DzsJ9pkIj9pPNuV3JRSyJ_wFY_003D.Push(transform);
	}

	public TraversalParams(IWorkspace workspace, Transformation transform = null)
		: this(workspace.Document, transform)
	{
	}

	public TraversalParams(Document document, Transformation transform = null)
	{
		_0023_003Dz_i1p8wE1ysPPh1ibUA_003D_003D = document;
		Workspace = document?.workspace;
		_0023_003DzsJ9pkIj9pPNuV3JRSyJ_wFY_003D.Push(transform);
		if (document != null)
		{
			_0023_003DzF97WMq_0024wP8gY4FUd3g_003D_003D = document.Blocks;
		}
	}

	internal TraversalParams(IWorkspace _0023_003DzImQx0os_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, Transformation _0023_003Dzptomndc_003D = null)
		: this(_0023_003DzImQx0os_003D.Document, _0023_003DzJO1FWlQ_003D, _0023_003Dzptomndc_003D)
	{
	}

	internal TraversalParams(Document _0023_003DzoPlwCJA_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, Transformation _0023_003Dzptomndc_003D = null)
		: this(_0023_003DzJO1FWlQ_003D, _0023_003Dzptomndc_003D)
	{
		_0023_003Dz_i1p8wE1ysPPh1ibUA_003D_003D = _0023_003DzoPlwCJA_003D;
		Workspace = _0023_003DzoPlwCJA_003D?.workspace;
	}

	public TraversalParams(BlockKeyedCollection blocks, Transformation transform = null)
	{
		_0023_003DzsJ9pkIj9pPNuV3JRSyJ_wFY_003D.Push(transform);
		_0023_003DzF97WMq_0024wP8gY4FUd3g_003D_003D = blocks;
	}

	public TraversalParams(BlockReference blockRef, BlockKeyedCollection blocks, IWorkspace workspace)
		: this(blockRef, blocks, workspace.Document)
	{
	}

	public TraversalParams(BlockReference blockRef, BlockKeyedCollection blocks, Document document)
	{
		_0023_003Dz_i1p8wE1ysPPh1ibUA_003D_003D = document;
		Workspace = document?.workspace;
		BlockKeyedCollection parentBlocks = workspaceInternal?.ParentBlocks;
		_0023_003DzsJ9pkIj9pPNuV3JRSyJ_wFY_003D.Push(blockRef.GetFullTransformation(blocks, parentBlocks));
		_0023_003DzF97WMq_0024wP8gY4FUd3g_003D_003D = blocks;
	}

	public void PushTransformation(BlockReference blockReference)
	{
		BlockKeyedCollection parentBlocks = workspaceInternal?.ParentBlocks;
		PushTransformation(blockReference?.GetFullTransformation(Blocks, parentBlocks));
	}

	public virtual void PushTransformation(Transformation transform = null)
	{
		_0023_003DznkEI83gHh_l7();
		_0023_003DzsJ9pkIj9pPNuV3JRSyJ_wFY_003D.Push(_0023_003Dz0v5zcfYmTwCF(transform));
	}

	internal Transformation _0023_003Dz0v5zcfYmTwCF(Transformation _0023_003Dzptomndc_003D)
	{
		if (_0023_003Dzptomndc_003D != null)
		{
			Transformation transformation = _0023_003DzsJ9pkIj9pPNuV3JRSyJ_wFY_003D.Peek();
			if (transformation != null)
			{
				return transformation * _0023_003Dzptomndc_003D;
			}
		}
		return _0023_003Dzptomndc_003D;
	}

	public virtual void PopTransformation()
	{
		_0023_003DznkEI83gHh_l7();
		_0023_003DzsJ9pkIj9pPNuV3JRSyJ_wFY_003D.Pop();
	}

	private protected void _0023_003DznkEI83gHh_l7()
	{
		if (_0023_003DzlVfkB344HnlGhuCmUA_003D_003D)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015627));
		}
	}
}
