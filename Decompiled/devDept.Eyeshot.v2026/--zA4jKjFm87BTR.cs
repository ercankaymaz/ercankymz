using System;

internal sealed class _0023_003DzA4jKjFm87BTR
{
	private bool _0023_003DzYVDIcYzAKAZM;

	private bool _0023_003DzuI5Ekdc_003D;

	private bool _0023_003DzIKmU1ds3FdSH;

	private bool _0023_003DzvxU96L_71I8e;

	private bool _0023_003DzN_E8wnbG9kgHSpqfPw_003D_003D;

	private bool _0023_003DzwCHwXboZRmzq = true;

	private bool _0023_003DzwkSlNHVudNcL;

	private bool _0023_003DzKFtkvYsvV7yQL2323g_003D_003D;

	private Func<_0023_003Dz8HH5LuV8BsqKJ6xMrg_003D_003D, double, bool> _0023_003DzcgjEMgdVF4TqbgLIgg_003D_003D;

	private int _0023_003DzF8BxCr8fcKGUvZep4A_003D_003D;

	private double _0023_003DzJZgKl_0024PuDaYi;

	private double _0023_003Dz0mZ4_0024fFWxsTX;

	private double _0023_003DzlXBDHvbkBEvg = -1.0;

	internal bool _0023_003Dz2dhKsLD92y4t;

	internal bool _0023_003Dz2jb9Gj5NrfF4 = true;

	internal bool _0023_003DzFQPEJZmceeVt;

	internal double _0023_003DzvD5yyKfc_0024dji;

	internal double _0023_003DzOONwEmosvk7_;

	internal double _0023_003DzaHRy8egh2CCzzzI2jQ_003D_003D;

	private static bool _0023_003DzOWC6dXo0MGyUVpJszQ_003D_003D;

	public _0023_003DzA4jKjFm87BTR(bool _0023_003DzuI5Ekdc_003D = false, double _0023_003DzJZgKl_0024PuDaYi = 20.0)
	{
		if (_0023_003DzuI5Ekdc_003D)
		{
			this._0023_003DzuI5Ekdc_003D = true;
			this._0023_003DzJZgKl_0024PuDaYi = _0023_003DzJZgKl_0024PuDaYi;
			_0023_003DzIvyN59Q_003D();
		}
	}

	private void _0023_003DzIvyN59Q_003D()
	{
		_0023_003DzuI5Ekdc_003D = true;
		if (_0023_003DzJZgKl_0024PuDaYi < 0.0 || _0023_003DzJZgKl_0024PuDaYi > 60.0)
		{
			_0023_003DzJZgKl_0024PuDaYi = 0.0;
			_0023_003DzuI5Ekdc_003D = false;
			_0023_003DzFssxjLXQIoCN._0023_003DzNQeUxi0_003D()._0023_003Dz6jbnvgs_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302936989), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302936683));
		}
		if (_0023_003Dz0mZ4_0024fFWxsTX != 0.0 && (_0023_003Dz0mZ4_0024fFWxsTX < 60.0 || _0023_003Dz0mZ4_0024fFWxsTX > 180.0))
		{
			_0023_003Dz0mZ4_0024fFWxsTX = 0.0;
			_0023_003DzuI5Ekdc_003D = false;
			_0023_003DzFssxjLXQIoCN._0023_003DzNQeUxi0_003D()._0023_003Dz6jbnvgs_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302936671), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302936683));
		}
		_0023_003Dz2jb9Gj5NrfF4 = _0023_003DzTfaXcH30SWah() || _0023_003DzKbrmgoi36V62() || _0023_003DznhqojWFfoPS87AUE_0024A_003D_003D();
		_0023_003DzvD5yyKfc_0024dji = Math.Cos(_0023_003Dz3mqNGzgw8UYE() * Math.PI / 180.0);
		_0023_003DzOONwEmosvk7_ = Math.Cos(_0023_003DzwsOi2JzsgdaJ() * Math.PI / 180.0);
		if (_0023_003DzvD5yyKfc_0024dji == 1.0)
		{
			_0023_003DzaHRy8egh2CCzzzI2jQ_003D_003D = 0.0;
		}
		else
		{
			_0023_003DzaHRy8egh2CCzzzI2jQ_003D_003D = 0.475 * Math.Sqrt((1.0 + _0023_003DzvD5yyKfc_0024dji) / (1.0 - _0023_003DzvD5yyKfc_0024dji));
		}
		_0023_003DzvD5yyKfc_0024dji *= _0023_003DzvD5yyKfc_0024dji;
	}

	public static bool _0023_003DzhpldGc0j_0024tq4()
	{
		return _0023_003DzOWC6dXo0MGyUVpJszQ_003D_003D;
	}

	public static void _0023_003Dzs6rXsTbSvevS(bool _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzOWC6dXo0MGyUVpJszQ_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public bool _0023_003DzKbrmgoi36V62()
	{
		return _0023_003DzuI5Ekdc_003D;
	}

	public void _0023_003Dz0u_Mg_0024fyqAzg(bool _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzuI5Ekdc_003D = _0023_003DzPzO_0024GUk_003D;
		if (_0023_003DzuI5Ekdc_003D)
		{
			_0023_003DzIvyN59Q_003D();
		}
	}

	public double _0023_003Dz3mqNGzgw8UYE()
	{
		return _0023_003DzJZgKl_0024PuDaYi;
	}

	public void _0023_003DzLoplaAoWdff_0024(double _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzJZgKl_0024PuDaYi = _0023_003DzPzO_0024GUk_003D;
		_0023_003DzIvyN59Q_003D();
	}

	public double _0023_003DzwsOi2JzsgdaJ()
	{
		return _0023_003Dz0mZ4_0024fFWxsTX;
	}

	public void _0023_003DzxM0_Rlif4PP_0024(double _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dz0mZ4_0024fFWxsTX = _0023_003DzPzO_0024GUk_003D;
		_0023_003DzIvyN59Q_003D();
	}

	public double _0023_003Dzj878vwo0Ligh()
	{
		return _0023_003DzlXBDHvbkBEvg;
	}

	public void _0023_003Dz3VDAxJbEy1jq(double _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzlXBDHvbkBEvg = _0023_003DzPzO_0024GUk_003D;
		_0023_003Dz2dhKsLD92y4t = _0023_003DzPzO_0024GUk_003D > 0.0;
	}

	public bool _0023_003DzqWzgfTbx7pR3()
	{
		return _0023_003DzIKmU1ds3FdSH;
	}

	public void _0023_003DzmxzWcCjEDGMi(bool _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzIKmU1ds3FdSH = _0023_003DzPzO_0024GUk_003D;
	}

	public bool _0023_003DzTfaXcH30SWah()
	{
		return _0023_003DzYVDIcYzAKAZM;
	}

	public void _0023_003DziKBRFr118LZN(bool _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzYVDIcYzAKAZM = _0023_003DzPzO_0024GUk_003D;
	}

	public Func<_0023_003Dz8HH5LuV8BsqKJ6xMrg_003D_003D, double, bool> _0023_003DzK4fQJwE1A25u()
	{
		return _0023_003DzcgjEMgdVF4TqbgLIgg_003D_003D;
	}

	public void _0023_003DzR0M2bUfXlzpv(Func<_0023_003Dz8HH5LuV8BsqKJ6xMrg_003D_003D, double, bool> _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzcgjEMgdVF4TqbgLIgg_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public bool _0023_003DznhqojWFfoPS87AUE_0024A_003D_003D()
	{
		return _0023_003DzvxU96L_71I8e;
	}

	public void _0023_003Dz5Tf62worMJ5AZ1hKiw_003D_003D(bool _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzvxU96L_71I8e = _0023_003DzPzO_0024GUk_003D;
	}

	public bool _0023_003DzgLtaBJ_0024oRB_00244dNVq35fpnAVeuGZ1PKoiXQ_003D_003D()
	{
		return _0023_003DzKFtkvYsvV7yQL2323g_003D_003D;
	}

	public void _0023_003DzKEviZKBCKAT1tG8_0024zNAFHSf8_HeXqjzq1A_003D_003D(bool _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzKFtkvYsvV7yQL2323g_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public int _0023_003DzDiyYlALNKwzo8bBXjw_003D_003D()
	{
		return _0023_003DzF8BxCr8fcKGUvZep4A_003D_003D;
	}

	public void _0023_003DzJlKbuAYYLQuUtapl9w_003D_003D(int _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzF8BxCr8fcKGUvZep4A_003D_003D = _0023_003DzPzO_0024GUk_003D;
		if (_0023_003DzF8BxCr8fcKGUvZep4A_003D_003D < 0 || _0023_003DzF8BxCr8fcKGUvZep4A_003D_003D > 2)
		{
			_0023_003DzF8BxCr8fcKGUvZep4A_003D_003D = 0;
		}
	}

	public bool _0023_003DzSJxyhrPXjH2qHRnc4A_003D_003D()
	{
		return _0023_003DzwCHwXboZRmzq;
	}

	public void _0023_003Dze2_0024dEELSOyF20pdR1A_003D_003D(bool _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzwCHwXboZRmzq = _0023_003DzPzO_0024GUk_003D;
	}

	public bool _0023_003DzK7oj7yke9nmqcPG3tA_003D_003D()
	{
		return _0023_003DzwkSlNHVudNcL;
	}

	public void _0023_003Dz0t_u04XteLUROowygQ_003D_003D(bool _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzwkSlNHVudNcL = _0023_003DzPzO_0024GUk_003D;
	}

	public bool _0023_003DzN3jubl9gtsIxCf_0024pmw_003D_003D()
	{
		return _0023_003DzN_E8wnbG9kgHSpqfPw_003D_003D;
	}

	public void _0023_003DzPcIL_0024u32ptMhUaILqg_003D_003D(bool _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzN_E8wnbG9kgHSpqfPw_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}
}
