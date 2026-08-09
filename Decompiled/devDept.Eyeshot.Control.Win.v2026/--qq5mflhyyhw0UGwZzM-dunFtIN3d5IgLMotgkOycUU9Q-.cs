using System;

internal static class _0023_003Dqq5mflhyyhw0UGwZzM_0024dunFtIN3d5IgLMotgkOycUU9Q_003D
{
	public static bool _0023_003Dz8_0024_kJPbmHmAID6UEFyvxzkV3vw8p(Type _0023_003DzjYYAPCA_003D, Type _0023_003DzVC9FBdo_003D, out int _0023_003DzwBouG0w_003D)
	{
		_0023_003DzwBouG0w_003D = 0;
		if (_0023_003DzjYYAPCA_003D == _0023_003DzVC9FBdo_003D)
		{
			_0023_003DzwBouG0w_003D = 1;
			return true;
		}
		if (_0023_003DzjYYAPCA_003D == null || _0023_003DzVC9FBdo_003D == null)
		{
			return false;
		}
		if (_0023_003DzjYYAPCA_003D.IsByRef)
		{
			if (!_0023_003DzVC9FBdo_003D.IsByRef)
			{
				return false;
			}
			return _0023_003Dz8_0024_kJPbmHmAID6UEFyvxzkV3vw8p(_0023_003DzjYYAPCA_003D.GetElementType(), _0023_003DzVC9FBdo_003D.GetElementType(), out _0023_003DzwBouG0w_003D);
		}
		if (_0023_003DzVC9FBdo_003D.IsByRef)
		{
			return false;
		}
		if (_0023_003DzjYYAPCA_003D.IsPointer)
		{
			if (!_0023_003DzVC9FBdo_003D.IsPointer)
			{
				return false;
			}
			return _0023_003Dz8_0024_kJPbmHmAID6UEFyvxzkV3vw8p(_0023_003DzjYYAPCA_003D.GetElementType(), _0023_003DzVC9FBdo_003D.GetElementType(), out _0023_003DzwBouG0w_003D);
		}
		if (_0023_003DzVC9FBdo_003D.IsPointer)
		{
			return false;
		}
		if (_0023_003DzjYYAPCA_003D.IsArray)
		{
			if (!_0023_003DzVC9FBdo_003D.IsArray)
			{
				return false;
			}
			if (_0023_003DzjYYAPCA_003D.GetArrayRank() != _0023_003DzVC9FBdo_003D.GetArrayRank())
			{
				return false;
			}
			return _0023_003Dz8_0024_kJPbmHmAID6UEFyvxzkV3vw8p(_0023_003DzjYYAPCA_003D.GetElementType(), _0023_003DzVC9FBdo_003D.GetElementType(), out _0023_003DzwBouG0w_003D);
		}
		if (_0023_003DzVC9FBdo_003D.IsArray)
		{
			return false;
		}
		if (_0023_003DzjYYAPCA_003D.IsGenericType != _0023_003DzVC9FBdo_003D.IsGenericType)
		{
			return false;
		}
		if (_0023_003DzjYYAPCA_003D.IsGenericType)
		{
			Type obj = (_0023_003DzjYYAPCA_003D.IsGenericTypeDefinition ? _0023_003DzjYYAPCA_003D : _0023_003DzjYYAPCA_003D.GetGenericTypeDefinition());
			Type type = (_0023_003DzVC9FBdo_003D.IsGenericTypeDefinition ? _0023_003DzVC9FBdo_003D : _0023_003DzVC9FBdo_003D.GetGenericTypeDefinition());
			if (obj != type)
			{
				return false;
			}
			Type[] genericArguments = _0023_003DzjYYAPCA_003D.GetGenericArguments();
			Type[] genericArguments2 = _0023_003DzVC9FBdo_003D.GetGenericArguments();
			if (genericArguments.Length != genericArguments2.Length)
			{
				return false;
			}
			for (int i = 0; i < genericArguments.Length; i++)
			{
				if (_0023_003Dz8_0024_kJPbmHmAID6UEFyvxzkV3vw8p(genericArguments[i], genericArguments2[i], out var _0023_003DzwBouG0w_003D2))
				{
					_0023_003DzwBouG0w_003D += _0023_003DzwBouG0w_003D2;
				}
			}
		}
		else if (_0023_003DzjYYAPCA_003D != _0023_003DzVC9FBdo_003D)
		{
			return false;
		}
		_0023_003DzwBouG0w_003D++;
		return true;
	}
}
