using System;
using System.Diagnostics;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

internal class _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D : Mesh
{
	public enum _0023_003DzemvFlrg_003D
	{

	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public _0023_003DzemvFlrg_003D _0023_003DzGpFd0Ls_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D _0023_003DzcJIdS_jd32ls;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Transformation _0023_003DzndAYios_003D;

	public _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D(string _0023_003DzD8mZsz8_003D, natureType _0023_003Dz5iRcFgagQUUy, double _0023_003DzW_Mwciw_003D, double _0023_003Dz8DKA0oD3cgK0, Vector3D _0023_003DzURBEAMYs10Da, _0023_003DzemvFlrg_003D _0023_003DzemvFlrg_003D)
		: base(_0023_003Dz5iRcFgagQUUy)
	{
		LayerName = _0023_003DzD8mZsz8_003D;
		base.EdgeStyle = edgeStyleType.Sharp;
		_0023_003DzndAYios_003D = new Rotation(Utility.DegToRad(_0023_003Dz8DKA0oD3cgK0), _0023_003DzURBEAMYs10Da) * new Scaling(_0023_003DzW_Mwciw_003D, _0023_003DzW_Mwciw_003D, _0023_003DzW_Mwciw_003D);
		_0023_003DzGpFd0Ls_003D = _0023_003DzemvFlrg_003D;
		RegenMode = regenType.NotNeeded;
	}

	public override void Dispose()
	{
		if (_0023_003DzcJIdS_jd32ls == null)
		{
			base.Dispose();
		}
	}

	protected internal override void Render(RenderParams _0023_003Dzt5jpbHs_003D)
	{
		_0023_003Dz2ZCJqwY_003D(_0023_003Dzt5jpbHs_003D);
		if (_0023_003DzcJIdS_jd32ls != null)
		{
			_0023_003DzcJIdS_jd32ls._0023_003Dzvbn4T_LPoI9t(_0023_003Dzt5jpbHs_003D);
		}
		else
		{
			_0023_003Dzvbn4T_LPoI9t(_0023_003Dzt5jpbHs_003D);
		}
		_0023_003DzJSK5VY0_003D(_0023_003Dzt5jpbHs_003D);
	}

	private void _0023_003Dz2ZCJqwY_003D(DrawParams _0023_003Dzt5jpbHs_003D)
	{
		_0023_003Dzt5jpbHs_003D.RenderContext.PushMatrices();
		_0023_003Dzt5jpbHs_003D.RenderContext.MultMatrixModelView(_0023_003DzndAYios_003D);
	}

	private static void _0023_003DzJSK5VY0_003D(DrawParams _0023_003Dzt5jpbHs_003D)
	{
		_0023_003Dzt5jpbHs_003D.RenderContext.PopMatrices();
	}

	protected internal override void Draw(DrawParams _0023_003Dzt5jpbHs_003D)
	{
		_0023_003Dz2ZCJqwY_003D(_0023_003Dzt5jpbHs_003D);
		if (_0023_003DzcJIdS_jd32ls != null)
		{
			_0023_003DzcJIdS_jd32ls._0023_003DzCr91__0024HyQlKJ(_0023_003Dzt5jpbHs_003D);
		}
		else
		{
			_0023_003DzCr91__0024HyQlKJ(_0023_003Dzt5jpbHs_003D);
		}
		_0023_003DzJSK5VY0_003D(_0023_003Dzt5jpbHs_003D);
	}

	protected internal override void DrawForSelection(DrawForSelectionParams _0023_003Dzt5jpbHs_003D)
	{
		Draw(_0023_003Dzt5jpbHs_003D);
	}

	protected virtual void _0023_003Dzvbn4T_LPoI9t(RenderParams _0023_003Dzt5jpbHs_003D)
	{
		base.Render(_0023_003Dzt5jpbHs_003D);
	}

	protected virtual void _0023_003DzCr91__0024HyQlKJ(DrawParams _0023_003Dzt5jpbHs_003D)
	{
		base.Draw(_0023_003Dzt5jpbHs_003D);
	}

	protected internal override bool ComputeBoundingBox(TraversalParams _0023_003Dzt5jpbHs_003D, out Point3D _0023_003DzpV4_U8o4JR26, out Point3D _0023_003DzkokL1qtcIMpB)
	{
		Point3D[] points = ((_0023_003DzcJIdS_jd32ls != null) ? _0023_003DzcJIdS_jd32ls.Vertices : Vertices);
		Utility.ComputeBoundingBox((_0023_003Dzt5jpbHs_003D.Transformation ?? new Identity()) * _0023_003DzndAYios_003D, points, out _0023_003DzpV4_U8o4JR26, out _0023_003DzkokL1qtcIMpB);
		return true;
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection _0023_003Dz9W2nj9A_003D, LayerKeyedCollection _0023_003DzjDdbnzc6miMJ)
	{
		throw new NotImplementedException();
	}

	public override object Clone()
	{
		throw new NotImplementedException();
	}

	protected override void CompileSelected(CompileParams _0023_003Dzt5jpbHs_003D)
	{
		if (base.MeshNature == natureType.RichSmooth)
		{
			base.CompileSelected(_0023_003Dzt5jpbHs_003D);
		}
	}

	protected internal override void DrawSilhouettes(DrawSilhouettesParams _0023_003Dzt5jpbHs_003D)
	{
		_0023_003Dz2ZCJqwY_003D(_0023_003Dzt5jpbHs_003D);
		_0023_003Dzt5jpbHs_003D.Transformation = _0023_003DzndAYios_003D;
		if (_0023_003DzcJIdS_jd32ls != null)
		{
			_0023_003DzcJIdS_jd32ls._0023_003Dz2yL_00244o_0024PQBJVv2EcmdS9KG8_003D(_0023_003Dzt5jpbHs_003D);
		}
		else
		{
			base.DrawSilhouettes(_0023_003Dzt5jpbHs_003D);
		}
		_0023_003DzJSK5VY0_003D(_0023_003Dzt5jpbHs_003D);
	}

	protected internal void _0023_003Dz2yL_00244o_0024PQBJVv2EcmdS9KG8_003D(DrawSilhouettesParams _0023_003Dzt5jpbHs_003D)
	{
		base.DrawSilhouettes(_0023_003Dzt5jpbHs_003D);
	}

	protected internal override void DrawEdges(DrawParams _0023_003Dzt5jpbHs_003D)
	{
		_0023_003Dz2ZCJqwY_003D(_0023_003Dzt5jpbHs_003D);
		if (_0023_003DzcJIdS_jd32ls != null)
		{
			_0023_003DzcJIdS_jd32ls._0023_003DzhQVQrz7U1C9Q(_0023_003Dzt5jpbHs_003D);
		}
		else
		{
			base.DrawEdges(_0023_003Dzt5jpbHs_003D);
		}
		_0023_003DzJSK5VY0_003D(_0023_003Dzt5jpbHs_003D);
	}

	protected internal void _0023_003DzhQVQrz7U1C9Q(DrawParams _0023_003Dzt5jpbHs_003D)
	{
		base.DrawEdges(_0023_003Dzt5jpbHs_003D);
	}
}
