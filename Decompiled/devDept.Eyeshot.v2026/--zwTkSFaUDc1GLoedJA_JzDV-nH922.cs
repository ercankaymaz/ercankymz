using System.Collections.Generic;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

internal sealed class _0023_003DzwTkSFaUDc1GLoedJA_JzDV_0024nH922
{
	public Transformation _0023_003Dz6pP4S297j_0024SN;

	public IList<Entity> _0023_003DzWc9WmS8VMsuA;

	public GfxAttributes _0023_003DzqP5lTto_003D;

	public bool _0023_003DzQdIz9Cklm60v;

	public bool _0023_003Dz0yA2GLvAE1AwnLOeAg_003D_003D;

	public bool _0023_003Dzl7d7EUJ0QNge;

	public bool _0023_003Dzw4CKXDpZhtw4;

	public bool _0023_003Dz4mEOnvdgjJv0;

	public bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D;

	public float _0023_003DzWW9Us5CBetmY;

	public bool _0023_003DzO87UHyI_003D;

	public _0023_003DzwTkSFaUDc1GLoedJA_JzDV_0024nH922(DrawEntitiesParams _0023_003DzySgeilxprQOK)
	{
		_0023_003DzO87UHyI_003D = _0023_003DzySgeilxprQOK.InScope;
		_0023_003Dz6pP4S297j_0024SN = _0023_003DzySgeilxprQOK.DrawParams.Transformation;
		_0023_003DzWc9WmS8VMsuA = _0023_003DzySgeilxprQOK.entList;
		_0023_003DzqP5lTto_003D = (GfxAttributes)_0023_003DzySgeilxprQOK.DrawParams.Attributes.Clone();
		_0023_003DzQdIz9Cklm60v = _0023_003DzySgeilxprQOK.DrawParams.ParentSelected;
		_0023_003Dz0yA2GLvAE1AwnLOeAg_003D_003D = _0023_003DzySgeilxprQOK.DrawParams.ParentClippable;
		_0023_003Dzl7d7EUJ0QNge = _0023_003DzySgeilxprQOK.DrawParams.ParentIsolated;
		_0023_003Dzw4CKXDpZhtw4 = _0023_003DzySgeilxprQOK.DrawParams.ParentForceGray;
		_0023_003Dz4mEOnvdgjJv0 = _0023_003DzySgeilxprQOK.DrawParams.ForceGray;
		_0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D = _0023_003DzySgeilxprQOK.simplify;
		_0023_003DzWW9Us5CBetmY = _0023_003DzySgeilxprQOK.DrawParams.ScreenToWorld;
	}

	public void _0023_003Dz4q7Sk_A_003D(DrawEntitiesParams _0023_003DzySgeilxprQOK)
	{
		_0023_003DzySgeilxprQOK.InScope = _0023_003DzO87UHyI_003D;
		_0023_003DzySgeilxprQOK.DrawParams.Transformation = _0023_003Dz6pP4S297j_0024SN;
		_0023_003DzySgeilxprQOK.DrawParams.ParentSelected = _0023_003DzQdIz9Cklm60v;
		_0023_003DzySgeilxprQOK.DrawParams.ParentClippable = _0023_003Dz0yA2GLvAE1AwnLOeAg_003D_003D;
		_0023_003DzySgeilxprQOK.DrawParams.ParentIsolated = _0023_003Dzl7d7EUJ0QNge;
		_0023_003DzySgeilxprQOK.DrawParams.ParentForceGray = _0023_003Dzw4CKXDpZhtw4;
		_0023_003DzySgeilxprQOK.DrawParams.ForceGray = _0023_003Dz4mEOnvdgjJv0;
		_0023_003DzySgeilxprQOK.entList = _0023_003DzWc9WmS8VMsuA;
		_0023_003DzySgeilxprQOK.DrawParams.Attributes = _0023_003DzqP5lTto_003D;
		_0023_003DzySgeilxprQOK.simplify = _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D;
		_0023_003DzySgeilxprQOK.DrawParams.ScreenToWorld = _0023_003DzWW9Us5CBetmY;
	}
}
