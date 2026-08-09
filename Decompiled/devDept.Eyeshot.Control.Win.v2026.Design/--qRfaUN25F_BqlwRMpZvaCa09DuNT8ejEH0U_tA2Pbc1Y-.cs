using System;

internal static class _0023_003DqRfaUN25F_BqlwRMpZvaCa09DuNT8ejEH0U_tA2Pbc1Y_003D
{
	public static bool _0023_003DzKhkB9_0024rX28FSnG8KONbzBBSPB2ZO(Type _0023_003Dz9jrlnWk_003D, Type _0023_003DzBxpHhQ0_003D, out int _0023_003Dztgqm2r4_003D)
	{
		_0023_003Dztgqm2r4_003D = 0;
		if (_0023_003Dz9jrlnWk_003D == _0023_003DzBxpHhQ0_003D)
		{
			_0023_003Dztgqm2r4_003D = 1;
			return true;
		}
		if (_0023_003Dz9jrlnWk_003D == null || _0023_003DzBxpHhQ0_003D == null)
		{
			return false;
		}
		if (_0023_003Dz9jrlnWk_003D.IsByRef)
		{
			if (!_0023_003DzBxpHhQ0_003D.IsByRef)
			{
				return false;
			}
			return _0023_003DzKhkB9_0024rX28FSnG8KONbzBBSPB2ZO(_0023_003Dz9jrlnWk_003D.GetElementType(), _0023_003DzBxpHhQ0_003D.GetElementType(), out _0023_003Dztgqm2r4_003D);
		}
		if (_0023_003DzBxpHhQ0_003D.IsByRef)
		{
			return false;
		}
		if (_0023_003Dz9jrlnWk_003D.IsPointer)
		{
			if (!_0023_003DzBxpHhQ0_003D.IsPointer)
			{
				return false;
			}
			return _0023_003DzKhkB9_0024rX28FSnG8KONbzBBSPB2ZO(_0023_003Dz9jrlnWk_003D.GetElementType(), _0023_003DzBxpHhQ0_003D.GetElementType(), out _0023_003Dztgqm2r4_003D);
		}
		if (_0023_003DzBxpHhQ0_003D.IsPointer)
		{
			return false;
		}
		if (_0023_003Dz9jrlnWk_003D.IsArray)
		{
			if (!_0023_003DzBxpHhQ0_003D.IsArray)
			{
				return false;
			}
			if (_0023_003Dz9jrlnWk_003D.GetArrayRank() != _0023_003DzBxpHhQ0_003D.GetArrayRank())
			{
				return false;
			}
			return _0023_003DzKhkB9_0024rX28FSnG8KONbzBBSPB2ZO(_0023_003Dz9jrlnWk_003D.GetElementType(), _0023_003DzBxpHhQ0_003D.GetElementType(), out _0023_003Dztgqm2r4_003D);
		}
		if (_0023_003DzBxpHhQ0_003D.IsArray)
		{
			return false;
		}
		if (_0023_003Dz9jrlnWk_003D.IsGenericType != _0023_003DzBxpHhQ0_003D.IsGenericType)
		{
			return false;
		}
		if (_0023_003Dz9jrlnWk_003D.IsGenericType)
		{
			Type obj = (_0023_003Dz9jrlnWk_003D.IsGenericTypeDefinition ? _0023_003Dz9jrlnWk_003D : _0023_003Dz9jrlnWk_003D.GetGenericTypeDefinition());
			Type type = (_0023_003DzBxpHhQ0_003D.IsGenericTypeDefinition ? _0023_003DzBxpHhQ0_003D : _0023_003DzBxpHhQ0_003D.GetGenericTypeDefinition());
			if (obj != type)
			{
				return false;
			}
			Type[] genericArguments = _0023_003Dz9jrlnWk_003D.GetGenericArguments();
			Type[] genericArguments2 = _0023_003DzBxpHhQ0_003D.GetGenericArguments();
			if (genericArguments.Length != genericArguments2.Length)
			{
				return false;
			}
			for (int i = 0; i < genericArguments.Length; i++)
			{
				if (_0023_003DzKhkB9_0024rX28FSnG8KONbzBBSPB2ZO(genericArguments[i], genericArguments2[i], out var _0023_003Dztgqm2r4_003D2))
				{
					_0023_003Dztgqm2r4_003D += _0023_003Dztgqm2r4_003D2;
				}
			}
		}
		else if (_0023_003Dz9jrlnWk_003D != _0023_003DzBxpHhQ0_003D)
		{
			return false;
		}
		_0023_003Dztgqm2r4_003D++;
		return true;
	}
}
