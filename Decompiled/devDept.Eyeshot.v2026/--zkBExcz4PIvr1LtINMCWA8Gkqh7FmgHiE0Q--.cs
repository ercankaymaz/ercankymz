using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using devDept.Eyeshot;
using devDept.Geometry;
using devDept.Graphics;

internal sealed class _0023_003DzkBExcz4PIvr1LtINMCWA8Gkqh7FmgHiE0Q_003D_003D : TraversalParams
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzSyU3S2DW2g7Nw7XncMtnt1k_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal GfxAttributesRendered _0023_003DzqP5lTto_003D = new GfxAttributesRendered();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public StringBuilder _0023_003DzgyYoHow_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public LayerKeyedCollection _0023_003DzeWJg3NJnk3WA;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public MaterialKeyedCollection _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public double _0023_003Dzm0CYiiE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public double _0023_003Dz0mZ4_0024fFWxsTX;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Dictionary<Material, int> _0023_003DzCQx6woK2STqH2wgQXQ_003D_003D;

	public _0023_003DzkBExcz4PIvr1LtINMCWA8Gkqh7FmgHiE0Q_003D_003D(StringBuilder _0023_003DzgyYoHow_003D, Transformation _0023_003Dz9ZUzIX4xmsyA, LayerKeyedCollection _0023_003DzeWJg3NJnk3WA, MaterialKeyedCollection _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D, double _0023_003Dzm0CYiiE_003D, double _0023_003Dz0mZ4_0024fFWxsTX, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, Dictionary<Material, int> _0023_003DzlvRIFqHkFvta17MBYg_003D_003D)
		: base(_0023_003DzJO1FWlQ_003D, _0023_003Dz9ZUzIX4xmsyA)
	{
		this._0023_003DzgyYoHow_003D = _0023_003DzgyYoHow_003D;
		this._0023_003DzeWJg3NJnk3WA = _0023_003DzeWJg3NJnk3WA;
		this._0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D = _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D;
		this._0023_003Dzm0CYiiE_003D = _0023_003Dzm0CYiiE_003D;
		this._0023_003Dz0mZ4_0024fFWxsTX = _0023_003Dz0mZ4_0024fFWxsTX;
		_0023_003DzCQx6woK2STqH2wgQXQ_003D_003D = _0023_003DzlvRIFqHkFvta17MBYg_003D_003D;
	}

	internal bool _0023_003DzyZN9fhDsHlGQ()
	{
		return _0023_003DzSyU3S2DW2g7Nw7XncMtnt1k_003D;
	}

	internal void _0023_003DzSiTufa33KU54(bool _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzSyU3S2DW2g7Nw7XncMtnt1k_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public Material _0023_003Dzjl5IbJ4_003D()
	{
		if (!string.IsNullOrEmpty(_0023_003DzqP5lTto_003D.MaterialName))
		{
			return _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D[_0023_003DzqP5lTto_003D.MaterialName];
		}
		return ControlData.DefaultMaterialShaded;
	}

	public Color _0023_003Dz_8C3BH8_003D()
	{
		if (!string.IsNullOrEmpty(_0023_003DzqP5lTto_003D.MaterialName))
		{
			return _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D[_0023_003DzqP5lTto_003D.MaterialName].Diffuse;
		}
		return _0023_003DzqP5lTto_003D.Color;
	}
}
