using devDept.Geometry;

internal static class _0023_003DztYj7lXShlEDHp7fu_FhTqXWy5fwN
{
	public static bool _0023_003DzXscMLpk_003D(this IndexTriangle _0023_003DznnnQx3RwjThsBRPB9w_003D_003D, int _0023_003DzkEYxO1SuR1Kw)
	{
		if (_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V1 != _0023_003DzkEYxO1SuR1Kw && _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V2 != _0023_003DzkEYxO1SuR1Kw)
		{
			return _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V3 == _0023_003DzkEYxO1SuR1Kw;
		}
		return true;
	}

	public static int _0023_003DzI2fnrdw_003D(this IndexTriangle _0023_003DznnnQx3RwjThsBRPB9w_003D_003D, int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D)
	{
		if (_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V1 != _0023_003DzffqPLNQ_003D && _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V1 != _0023_003Dz5Azd7L8_003D)
		{
			return _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V1;
		}
		if (_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V2 != _0023_003DzffqPLNQ_003D && _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V2 != _0023_003Dz5Azd7L8_003D)
		{
			return _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V2;
		}
		return _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V3;
	}

	public static (int, int) _0023_003DzI2fnrdw_003D(this IndexTriangle _0023_003DznnnQx3RwjThsBRPB9w_003D_003D, int _0023_003Dz77g161c_003D)
	{
		if (_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V1 != _0023_003Dz77g161c_003D)
		{
			if (_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V2 != _0023_003Dz77g161c_003D)
			{
				return (_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V1, _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V2);
			}
			return (_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V3, _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V1);
		}
		return (_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V2, _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V3);
	}

	public static (int, int) _0023_003DzQSvDYSY_003D(this IndexTriangle _0023_003DznnnQx3RwjThsBRPB9w_003D_003D, IndexTriangle _0023_003Dzl_0024MIsC0_003D)
	{
		if (_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V1 != _0023_003Dzl_0024MIsC0_003D.V1 && _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V1 != _0023_003Dzl_0024MIsC0_003D.V2 && _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V1 != _0023_003Dzl_0024MIsC0_003D.V3)
		{
			return (_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V2, _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V3);
		}
		if (_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V2 != _0023_003Dzl_0024MIsC0_003D.V1 && _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V2 != _0023_003Dzl_0024MIsC0_003D.V2 && _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V2 != _0023_003Dzl_0024MIsC0_003D.V3)
		{
			return (_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V3, _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V1);
		}
		return (_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V1, _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V2);
	}

	public static int _0023_003Dzg_0024_0024HtRw_003D(this IndexTriangle _0023_003DznnnQx3RwjThsBRPB9w_003D_003D, int _0023_003DzkEYxO1SuR1Kw)
	{
		if (_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V1 != _0023_003DzkEYxO1SuR1Kw)
		{
			if (_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V2 != _0023_003DzkEYxO1SuR1Kw)
			{
				return _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V1;
			}
			return _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V3;
		}
		return _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V2;
	}

	public static int _0023_003DzMqZZWVg_003D(this IndexTriangle _0023_003DznnnQx3RwjThsBRPB9w_003D_003D, int _0023_003DzkEYxO1SuR1Kw)
	{
		if (_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V1 != _0023_003DzkEYxO1SuR1Kw)
		{
			if (_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V2 != _0023_003DzkEYxO1SuR1Kw)
			{
				return _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V2;
			}
			return _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V1;
		}
		return _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V3;
	}

	public static void _0023_003DzhF_UisQ_003D(this IndexTriangle _0023_003DznnnQx3RwjThsBRPB9w_003D_003D, int _0023_003DzLCUhPaAzEMu7, int _0023_003DzCFEDsUh_0024Qzt7)
	{
		if (_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V1 == _0023_003DzLCUhPaAzEMu7)
		{
			_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V1 = _0023_003DzCFEDsUh_0024Qzt7;
		}
		if (_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V2 == _0023_003DzLCUhPaAzEMu7)
		{
			_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V2 = _0023_003DzCFEDsUh_0024Qzt7;
		}
		if (_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V3 == _0023_003DzLCUhPaAzEMu7)
		{
			_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V3 = _0023_003DzCFEDsUh_0024Qzt7;
		}
	}

	public static bool _0023_003DzhF_UisQ_003D(this SharedEdge _0023_003DzTx2aqr8_003D, int _0023_003DzLCUhPaAzEMu7, int _0023_003DzCFEDsUh_0024Qzt7)
	{
		if (_0023_003DzTx2aqr8_003D.Mum == _0023_003DzLCUhPaAzEMu7)
		{
			_0023_003DzTx2aqr8_003D.Mum = _0023_003DzCFEDsUh_0024Qzt7;
		}
		else
		{
			if (_0023_003DzTx2aqr8_003D.Dad != _0023_003DzLCUhPaAzEMu7)
			{
				return false;
			}
			_0023_003DzTx2aqr8_003D.Dad = _0023_003DzCFEDsUh_0024Qzt7;
		}
		return true;
	}

	public static bool _0023_003Dzl3Q_0024_0024QA_003D(this IndexTriangle _0023_003DznnnQx3RwjThsBRPB9w_003D_003D)
	{
		if (_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V1 != _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V2 && _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V1 != _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V3)
		{
			return _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V2 != _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V3;
		}
		return false;
	}
}
