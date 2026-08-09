using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace devDept.Eyeshot;

public class RegenParams : TraversalParams
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly double _0023_003Dz3tDeP0XPI5JdYrADlw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly double _0023_003DzCwX4mA970fxgnASt2Q_003D_003D = Math.PI / 6.0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzKm6RxpjBoSEs;

	public double Deviation
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz3tDeP0XPI5JdYrADlw_003D_003D;
		}
	}

	public double Angle
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzCwX4mA970fxgnASt2Q_003D_003D;
		}
	}

	public FontDataDictionary FontDefs => base.Document?.fontDefs;

	public TextStyleKeyedCollection TextStyles => base.Document?.TextStyles;

	internal RegenParams(EntityList _0023_003Dzv7xH9gk_003D)
		: this(_0023_003Dzv7xH9gk_003D.Document.GetVisualRefinement().Deviation, _0023_003Dzv7xH9gk_003D.Document)
	{
	}

	internal RegenParams(double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, IWorkspace _0023_003DzImQx0os_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D)
		: this(_0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003DzImQx0os_003D.Document, _0023_003DzJO1FWlQ_003D)
	{
	}

	internal RegenParams(double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, double _0023_003Dz6pajdGM_003D, IWorkspace _0023_003DzImQx0os_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D)
		: this(_0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003Dz6pajdGM_003D, _0023_003DzImQx0os_003D.Document, _0023_003DzJO1FWlQ_003D)
	{
	}

	internal RegenParams(double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, Document _0023_003DzoPlwCJA_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D)
		: base(_0023_003DzoPlwCJA_003D, _0023_003DzJO1FWlQ_003D)
	{
		_0023_003Dz3tDeP0XPI5JdYrADlw_003D_003D = _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D;
	}

	internal RegenParams(double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, double _0023_003Dz6pajdGM_003D, Document _0023_003DzoPlwCJA_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D)
		: base(_0023_003DzoPlwCJA_003D, _0023_003DzJO1FWlQ_003D)
	{
		_0023_003Dz3tDeP0XPI5JdYrADlw_003D_003D = _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D;
		_0023_003DzCwX4mA970fxgnASt2Q_003D_003D = _0023_003Dz6pajdGM_003D;
	}

	internal RegenParams(double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D)
		: base(_0023_003DzJO1FWlQ_003D)
	{
		_0023_003Dz3tDeP0XPI5JdYrADlw_003D_003D = _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D;
	}

	public RegenParams(double deviation, IWorkspace workspace)
		: this(deviation, workspace.Document)
	{
	}

	public RegenParams(double deviation, Document document = null)
		: base(document)
	{
		_0023_003Dz3tDeP0XPI5JdYrADlw_003D_003D = deviation;
	}

	public RegenParams(double deviation, double angle, IWorkspace workspace)
		: this(deviation, angle, workspace.Document)
	{
	}

	public RegenParams(double deviation, double angle, Document document = null)
		: base(document)
	{
		_0023_003Dz3tDeP0XPI5JdYrADlw_003D_003D = deviation;
		_0023_003DzCwX4mA970fxgnASt2Q_003D_003D = angle;
	}
}
