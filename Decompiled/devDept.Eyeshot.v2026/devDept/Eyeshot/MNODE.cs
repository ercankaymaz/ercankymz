using System;
using devDept.Geometry;

namespace devDept.Eyeshot;

[Serializable]
internal sealed class MNODE : Point3D
{
	public int num;

	public MNODE()
	{
	}

	public MNODE(Point3D _0023_003DzlY77YgY_003D, int _0023_003DzkXQ_IWk_003D)
		: base(_0023_003DzlY77YgY_003D.X, _0023_003DzlY77YgY_003D.Y, _0023_003DzlY77YgY_003D.Z)
	{
		num = _0023_003DzkXQ_IWk_003D;
	}

	public MNODE(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double _0023_003DzId5C3LA_003D, int _0023_003DzkXQ_IWk_003D)
		: base(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, _0023_003DzId5C3LA_003D)
	{
		num = _0023_003DzkXQ_IWk_003D;
	}

	protected MNODE(MNODE _0023_003DzySgeilxprQOK)
		: base(_0023_003DzySgeilxprQOK)
	{
		num = _0023_003DzySgeilxprQOK.num;
	}

	public override object Clone()
	{
		return new MNODE(this);
	}

	public bool _0023_003Dza0ku3fI_003D(MNODE _0023_003Dzl_0024MIsC0_003D)
	{
		if ((object)_0023_003Dzl_0024MIsC0_003D == null)
		{
			return false;
		}
		if ((object)this == _0023_003Dzl_0024MIsC0_003D)
		{
			return true;
		}
		if (Equals(_0023_003Dzl_0024MIsC0_003D))
		{
			return _0023_003Dzl_0024MIsC0_003D.num == num;
		}
		return false;
	}

	public override bool Equals(object _0023_003DzCX9Hbao_003D)
	{
		if (_0023_003DzCX9Hbao_003D == null)
		{
			return false;
		}
		if (this == _0023_003DzCX9Hbao_003D)
		{
			return true;
		}
		return _0023_003Dza0ku3fI_003D(_0023_003DzCX9Hbao_003D as MNODE);
	}

	public override int GetHashCode()
	{
		return (base.GetHashCode() * 397) ^ num;
	}

	public static bool operator ==(MNODE _0023_003DzeMBeuAQ_003D, MNODE _0023_003DznYtQKck_003D)
	{
		return object.Equals(_0023_003DzeMBeuAQ_003D, _0023_003DznYtQKck_003D);
	}

	public static bool operator !=(MNODE _0023_003DzeMBeuAQ_003D, MNODE _0023_003DznYtQKck_003D)
	{
		return !object.Equals(_0023_003DzeMBeuAQ_003D, _0023_003DznYtQKck_003D);
	}
}
