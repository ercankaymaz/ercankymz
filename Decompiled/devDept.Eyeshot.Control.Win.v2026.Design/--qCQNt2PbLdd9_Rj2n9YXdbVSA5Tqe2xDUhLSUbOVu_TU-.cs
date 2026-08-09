using System;
using System.Reflection;
using System.Runtime.CompilerServices;

internal sealed class _0023_003DqCQNt2PbLdd9_Rj2n9YXdbVSA5Tqe2xDUhLSUbOVu_TU_003D : _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D
{
	private object _0023_003Dz9jrlnWk_003D;

	public _0023_003DqCQNt2PbLdd9_Rj2n9YXdbVSA5Tqe2xDUhLSUbOVu_TU_003D(object _0023_003Dz9jrlnWk_003D)
		: base(25)
	{
		if (_0023_003Dz9jrlnWk_003D != null && !(_0023_003Dz9jrlnWk_003D is ValueType))
		{
			throw new ArgumentException();
		}
		this._0023_003Dz9jrlnWk_003D = _0023_003Dz9jrlnWk_003D;
	}

	public object _0023_003Dz39zZnN4wvB6luYqBEUduvsXAH_XP()
	{
		return _0023_003Dz9jrlnWk_003D;
	}

	public void _0023_003Dz_0024n0s2w7HZjZNo5xqOmTIQwk_003D(object _0023_003Dz9jrlnWk_003D)
	{
		if (_0023_003Dz9jrlnWk_003D != null && !(_0023_003Dz9jrlnWk_003D is ValueType))
		{
			throw new ArgumentException();
		}
		this._0023_003Dz9jrlnWk_003D = _0023_003Dz9jrlnWk_003D;
	}

	[SpecialName]
	public override object _0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D()
	{
		return _0023_003Dz39zZnN4wvB6luYqBEUduvsXAH_XP();
	}

	[SpecialName]
	public override void _0023_003Dz2BZRDdyC830I_0024QHE7EDcos6_0024Cr2mmsVt68BiG1k4GjsEE14zjUq6ALmAJpU1ti5_3KNno7BueiVKdd3zdlo5X6k_003D(object _0023_003Dz9jrlnWk_003D)
	{
		_0023_003Dz_0024n0s2w7HZjZNo5xqOmTIQwk_003D(_0023_003Dz9jrlnWk_003D);
	}

	private static bool _0023_003DzWzDt9IcIxmJ0qy6LuPpR4FU5o5pX(Type _0023_003Dz9jrlnWk_003D)
	{
		if (_0023_003Dz9jrlnWk_003D.IsGenericType && _0023_003Dz9jrlnWk_003D.Namespace == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312108))
		{
			string name = _0023_003Dz9jrlnWk_003D.Name;
			if (name == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312095) || name == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312066))
			{
				return false;
			}
		}
		return true;
	}

	public override _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzAPlrN6aYwAg5F1LxHYbv_0024wOBB_0024afgbz6XKGgvF_0024QaP3F7Nvwy8DGE80Q1m63nNv21_00240QxzxHCeC2PtE3mw_003D_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003Dz9jrlnWk_003D)
	{
		_0023_003DzsZLDUvjyYZRtLY91huCrFGofhAyP(_0023_003Dz9jrlnWk_003D._0023_003Dz55cfCv82_0024cfWUBDPYd5Wu_0024c_003D());
		switch (_0023_003Dz9jrlnWk_003D._0023_003DzpaPA7AsullYGIwWVv539Gh0dmq_0024uAkWIUvNDrJU_003D())
		{
		case 25:
		{
			object obj = ((_0023_003DqCQNt2PbLdd9_Rj2n9YXdbVSA5Tqe2xDUhLSUbOVu_TU_003D)_0023_003Dz9jrlnWk_003D)._0023_003Dz39zZnN4wvB6luYqBEUduvsXAH_XP();
			object obj2 = _0023_003Dz39zZnN4wvB6luYqBEUduvsXAH_XP();
			if (obj2 != null && obj != null)
			{
				Type type = obj2.GetType();
				if (!type.IsPrimitive && !type.IsEnum && type == obj.GetType() && _0023_003DzWzDt9IcIxmJ0qy6LuPpR4FU5o5pX(type))
				{
					FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					foreach (FieldInfo fieldInfo in fields)
					{
						fieldInfo.SetValue(obj2, fieldInfo.GetValue(obj));
					}
					break;
				}
			}
			_0023_003Dz_0024n0s2w7HZjZNo5xqOmTIQwk_003D(obj);
			break;
		}
		case 7:
			_0023_003Dz_0024n0s2w7HZjZNo5xqOmTIQwk_003D(((_0023_003DqcjmfsaS6dKPuf2kSTqJKWfH_rgkc03gEAn6QEKAtpbA_003D)_0023_003Dz9jrlnWk_003D)._0023_003DzKuvp4FpGZEHp_0024htPxx_00248SXawDH8Tdf_0Y48dwaP_bCrZ());
			break;
		default:
			_0023_003Dz_0024n0s2w7HZjZNo5xqOmTIQwk_003D(_0023_003Dz9jrlnWk_003D._0023_003DzuAfBwg9G6rsQqO5i13srMPxMHCAws7NAjwuGXxSuZfdQVNE1cwHCKe2TmZ_A7SjySV6JYAA_003D());
			break;
		}
		return this;
	}

	public override _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKoX16cQbOMreHQjnH_00248r2Q4_003D _0023_003DzRqSyVpZK2TBKK9sY8BRsK_LOAo2IOUGsrjpuWUR4KGpBSNkJ3BhBNhxCFhqGPqZG8Y5jLLY_m3gD()
	{
		_0023_003DqCQNt2PbLdd9_Rj2n9YXdbVSA5Tqe2xDUhLSUbOVu_TU_003D obj = new _0023_003DqCQNt2PbLdd9_Rj2n9YXdbVSA5Tqe2xDUhLSUbOVu_TU_003D(_0023_003Dz9jrlnWk_003D);
		obj._0023_003DzsZLDUvjyYZRtLY91huCrFGofhAyP(_0023_003Dz55cfCv82_0024cfWUBDPYd5Wu_0024c_003D());
		return obj;
	}
}
