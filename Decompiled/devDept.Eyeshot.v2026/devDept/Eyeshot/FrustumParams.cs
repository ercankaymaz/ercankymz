using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using devDept.Geometry;

namespace devDept.Eyeshot;

public class FrustumParams : TraversalParams
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzAJNq8lq51i9dcRXmn4ngNFA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz4hqwTKnzXLGLYm_0024KttSMhTY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzEXGvbDFPQb8ERyzpxVgO9KE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<SelectedItem> _0023_003DzktehcZTsYnUoKQU_0024e2n56U4_003D = new List<SelectedItem>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Segment3D[] _0023_003Dz5teYOreKA_IuIrQ1nrFVb_0024o_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PlaneEquation[] _0023_003Dzs16JoVzx6hHD8V_0024qZUVntFA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private displayType _0023_003Dzea823PHN2M4oRxTsEwIJMOI_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003Dz5hvjIaw5Covl2QLPOJgAbCI_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private LineType _0023_003DzuQHb8Mf2MfljJdJ4oQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private LineType _0023_003DzpqAeUMYYRGKrca9xbg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzLcpV1jsZxM6yrbTXv4iw8j7dPQDoGBPftA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal IList<Point3D> _0023_003DzrdSL0CI_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal int _0023_003Dzfsn580w_003D;

	public bool Quick;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dz4Hk5qhjhN3KuCR849Q_003D_003D = 1.0;

	public bool IsLeafSelection
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzAJNq8lq51i9dcRXmn4ngNFA_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzAJNq8lq51i9dcRXmn4ngNFA_003D = value;
		}
	}

	public bool ForceSkipLeafAdd
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz4hqwTKnzXLGLYm_0024KttSMhTY_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz4hqwTKnzXLGLYm_0024KttSMhTY_003D = value;
		}
	}

	public bool FirstOnly
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzEXGvbDFPQb8ERyzpxVgO9KE_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzEXGvbDFPQb8ERyzpxVgO9KE_003D = value;
		}
	}

	public List<SelectedItem> LeafSelectionInfo
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzktehcZTsYnUoKQU_0024e2n56U4_003D;
		}
	}

	public Segment3D[] SelectionEdges
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz5teYOreKA_IuIrQ1nrFVb_0024o_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz5teYOreKA_IuIrQ1nrFVb_0024o_003D = value;
		}
	}

	public PlaneEquation[] Frustum
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzs16JoVzx6hHD8V_0024qZUVntFA_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzs16JoVzx6hHD8V_0024qZUVntFA_003D = value;
		}
	}

	public displayType DisplayMode
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzea823PHN2M4oRxTsEwIJMOI_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzea823PHN2M4oRxTsEwIJMOI_003D = value;
		}
	}

	public float ScreenToWorld
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz5hvjIaw5Covl2QLPOJgAbCI_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz5hvjIaw5Covl2QLPOJgAbCI_003D = value;
		}
	}

	public LineType LineType
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzuQHb8Mf2MfljJdJ4oQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzuQHb8Mf2MfljJdJ4oQ_003D_003D = value;
		}
	}

	public LineType ParentLineType
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzpqAeUMYYRGKrca9xbg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzpqAeUMYYRGKrca9xbg_003D_003D = value;
		}
	}

	public int MaxPatternRepetitions
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzLcpV1jsZxM6yrbTXv4iw8j7dPQDoGBPftA_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzLcpV1jsZxM6yrbTXv4iw8j7dPQDoGBPftA_003D_003D = value;
		}
	}

	public double Scale
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz4Hk5qhjhN3KuCR849Q_003D_003D;
		}
	}

	public FrustumParams(PlaneEquation[] frustum, Segment3D[] selectionEdges, displayType displayMode, float screenToWorld, LineType lineType, int maxPatternRepetitions, IWorkspace workspace, Transformation transformation)
		: base(workspace, transformation)
	{
		Frustum = frustum;
		DisplayMode = displayMode;
		ScreenToWorld = screenToWorld;
		LineType = lineType;
		MaxPatternRepetitions = maxPatternRepetitions;
		SelectionEdges = selectionEdges;
		Quick = workspace.IsInFrustumMode == Camera.perspectiveFitType.Quick;
		_0023_003DzV4Qp5BU_003D();
	}

	public FrustumParams(PlaneEquation[] frustum, IWorkspace workspace, BlockKeyedCollection blocks)
		: base(workspace, blocks, workspace.CurrentTransformation)
	{
		Quick = workspace.IsInFrustumMode == Camera.perspectiveFitType.Quick;
		Frustum = frustum;
		_0023_003DzV4Qp5BU_003D();
	}

	public FrustumParams(PlaneEquation[] frustum, IWorkspace workspace)
		: this(frustum, workspace.IsInFrustumMode == Camera.perspectiveFitType.Quick, workspace)
	{
	}

	public FrustumParams(PlaneEquation[] frustum, bool quick, IWorkspace workspace)
		: this(frustum, quick, workspace.Document)
	{
	}

	internal FrustumParams(PlaneEquation[] _0023_003Dzxo6M8jQhcL2n, bool _0023_003DzrYojqqg_003D, Document _0023_003DzoPlwCJA_003D)
		: base(_0023_003DzoPlwCJA_003D, _0023_003DzoPlwCJA_003D.workspace?.CurrentTransformation)
	{
		Quick = _0023_003DzrYojqqg_003D;
		Frustum = _0023_003Dzxo6M8jQhcL2n;
		_0023_003DzV4Qp5BU_003D();
	}

	private void _0023_003Dzs3UA0O9Rtek_0024(List<SelectedItem> _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzktehcZTsYnUoKQU_0024e2n56U4_003D = _0023_003DzPzO_0024GUk_003D;
	}

	internal void _0023_003DzrOsPVhJgUXUe(double _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dz4Hk5qhjhN3KuCR849Q_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public override void PushTransformation(Transformation transform = null)
	{
		base.PushTransformation(transform);
		_0023_003DzV4Qp5BU_003D();
	}

	public override void PopTransformation()
	{
		base.PopTransformation();
		_0023_003DzV4Qp5BU_003D();
	}

	private void _0023_003DzV4Qp5BU_003D()
	{
		if (base.Transformation != null)
		{
			double val = Math.Abs(base.Transformation.ScaleFactorX);
			double val2 = Math.Abs(base.Transformation.ScaleFactorY);
			double val3 = Math.Abs(base.Transformation.ScaleFactorZ);
			_0023_003DzrOsPVhJgUXUe(Math.Max(Math.Max(val, val2), val3));
		}
		else
		{
			_0023_003DzrOsPVhJgUXUe(1.0);
		}
	}
}
