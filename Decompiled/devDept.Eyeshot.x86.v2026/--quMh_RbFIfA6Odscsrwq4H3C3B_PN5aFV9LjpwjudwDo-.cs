using System;

internal static class _0023_003DquMh_RbFIfA6Odscsrwq4H3C3B_PN5aFV9LjpwjudwDo_003D
{
	public static bool _0023_003Dz8Yz0iugz2KNfUBsFAIB8ZltgiORJ(Type _0023_003Dzq80RbjQ_003D, Type _0023_003DzZzVr6_0024U_003D, out int _0023_003Dz7hRN5Rg_003D)
	{
		_0023_003Dz7hRN5Rg_003D = 0;
		if (_0023_003Dzq80RbjQ_003D == _0023_003DzZzVr6_0024U_003D)
		{
			_0023_003Dz7hRN5Rg_003D = 1;
			return true;
		}
		if (_0023_003Dzq80RbjQ_003D == null || _0023_003DzZzVr6_0024U_003D == null)
		{
			return false;
		}
		if (_0023_003Dzq80RbjQ_003D.IsByRef)
		{
			if (!_0023_003DzZzVr6_0024U_003D.IsByRef)
			{
				return false;
			}
			return _0023_003Dz8Yz0iugz2KNfUBsFAIB8ZltgiORJ(_0023_003Dzq80RbjQ_003D.GetElementType(), _0023_003DzZzVr6_0024U_003D.GetElementType(), out _0023_003Dz7hRN5Rg_003D);
		}
		if (_0023_003DzZzVr6_0024U_003D.IsByRef)
		{
			return false;
		}
		if (_0023_003Dzq80RbjQ_003D.IsPointer)
		{
			if (!_0023_003DzZzVr6_0024U_003D.IsPointer)
			{
				return false;
			}
			return _0023_003Dz8Yz0iugz2KNfUBsFAIB8ZltgiORJ(_0023_003Dzq80RbjQ_003D.GetElementType(), _0023_003DzZzVr6_0024U_003D.GetElementType(), out _0023_003Dz7hRN5Rg_003D);
		}
		if (_0023_003DzZzVr6_0024U_003D.IsPointer)
		{
			return false;
		}
		if (_0023_003Dzq80RbjQ_003D.IsArray)
		{
			if (!_0023_003DzZzVr6_0024U_003D.IsArray)
			{
				return false;
			}
			if (_0023_003Dzq80RbjQ_003D.GetArrayRank() != _0023_003DzZzVr6_0024U_003D.GetArrayRank())
			{
				return false;
			}
			return _0023_003Dz8Yz0iugz2KNfUBsFAIB8ZltgiORJ(_0023_003Dzq80RbjQ_003D.GetElementType(), _0023_003DzZzVr6_0024U_003D.GetElementType(), out _0023_003Dz7hRN5Rg_003D);
		}
		if (_0023_003DzZzVr6_0024U_003D.IsArray)
		{
			return false;
		}
		if (_0023_003Dzq80RbjQ_003D.IsGenericType != _0023_003DzZzVr6_0024U_003D.IsGenericType)
		{
			return false;
		}
		if (_0023_003Dzq80RbjQ_003D.IsGenericType)
		{
			Type obj = (_0023_003Dzq80RbjQ_003D.IsGenericTypeDefinition ? _0023_003Dzq80RbjQ_003D : _0023_003Dzq80RbjQ_003D.GetGenericTypeDefinition());
			Type type = (_0023_003DzZzVr6_0024U_003D.IsGenericTypeDefinition ? _0023_003DzZzVr6_0024U_003D : _0023_003DzZzVr6_0024U_003D.GetGenericTypeDefinition());
			if (obj != type)
			{
				return false;
			}
			Type[] genericArguments = _0023_003Dzq80RbjQ_003D.GetGenericArguments();
			Type[] genericArguments2 = _0023_003DzZzVr6_0024U_003D.GetGenericArguments();
			if (genericArguments.Length != genericArguments2.Length)
			{
				return false;
			}
			for (int i = 0; i < genericArguments.Length; i++)
			{
				if (_0023_003Dz8Yz0iugz2KNfUBsFAIB8ZltgiORJ(genericArguments[i], genericArguments2[i], out var _0023_003Dz7hRN5Rg_003D2))
				{
					_0023_003Dz7hRN5Rg_003D += _0023_003Dz7hRN5Rg_003D2;
				}
			}
		}
		else if (_0023_003Dzq80RbjQ_003D != _0023_003DzZzVr6_0024U_003D)
		{
			return false;
		}
		_0023_003Dz7hRN5Rg_003D++;
		return true;
	}
}
