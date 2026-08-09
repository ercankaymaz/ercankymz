using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using devDept.Geometry;

internal sealed class _0023_003Dz0BIiPaQQVQlEmfNHWAB8wZCPSu5xlcuer20izNs_003D : _0023_003DzZblWR4M6qOLiy7U57TkX2pA_003D
{
	private TextWriter _0023_003DzzvTcRNc_003D;

	public _0023_003Dz0BIiPaQQVQlEmfNHWAB8wZCPSu5xlcuer20izNs_003D(TextWriter _0023_003DzvAxJOUiyruao)
	{
		_0023_003DzzvTcRNc_003D = _0023_003DzvAxJOUiyruao;
	}

	public void _0023_003Dz1NWs_aZC9Efm(List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003Dza_SABTbwi5q2, string _0023_003Dzg5oC_Hs_003D, string _0023_003DzsnJ8FOw_003D, string _0023_003DzdHmwPwj6z79_0024444NQW7KBrs_003D, string _0023_003DzeT1_0024G8_MC2gY, string _0023_003DzQ3hPewo_003D, linearUnitsType _0023_003DzsAi4oSk_003D, double _0023_003Dzgfxbk3apRWkCxbrhIg_003D_003D)
	{
		_0023_003DzzvTcRNc_003D.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302987018));
		_0023_003DzzvTcRNc_003D.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302987199));
		_0023_003DzzvTcRNc_003D.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986840));
		_0023_003DzzvTcRNc_003D.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986803));
		string text = _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzHmj4S4kpLcz56MAA1A_003D_003D(_0023_003Dzg5oC_Hs_003D) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962);
		int num;
		if (text.Length <= 72)
		{
			num = 1;
			_0023_003DzzvTcRNc_003D.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986773), text);
		}
		else
		{
			num = (int)Math.Ceiling((double)text.Length / 72.0);
			for (int i = 0; i < num; i++)
			{
				int num2 = 72 * i;
				int length = ((num2 + 72 < text.Length) ? 72 : (text.Length - num2));
				_0023_003DzzvTcRNc_003D.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986763), text.Substring(num2, length), 2 + i);
			}
		}
		string _0023_003DzwyYng5o_003D = ((_0023_003DzeT1_0024G8_MC2gY.Length > 68) ? _0023_003DzeT1_0024G8_MC2gY.Substring(0, 68) : _0023_003DzeT1_0024G8_MC2gY);
		_0023_003DzzvTcRNc_003D.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986763), _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzHmj4S4kpLcz56MAA1A_003D_003D(_0023_003DzwyYng5o_003D) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962), 2 + num);
		_0023_003DzzvTcRNc_003D.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986763), _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzHmj4S4kpLcz56MAA1A_003D_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302987007) + _0023_003DzQ3hPewo_003D) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962), 3 + num);
		_0023_003DzzvTcRNc_003D.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986992), 4 + num);
		_0023_003DzzvTcRNc_003D.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986883), 5 + num);
		int num3 = 0;
		string empty = string.Empty;
		switch (_0023_003DzsAi4oSk_003D)
		{
		case linearUnitsType.Inches:
			num3 = 1;
			empty = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302987648);
			break;
		case linearUnitsType.Millimeters:
			num3 = 2;
			empty = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302930031);
			break;
		case linearUnitsType.Feet:
			num3 = 4;
			empty = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302987623);
			break;
		case linearUnitsType.Miles:
			num3 = 5;
			empty = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302987602);
			break;
		case linearUnitsType.Meters:
			num3 = 6;
			empty = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911366);
			break;
		case linearUnitsType.Kilometers:
			num3 = 7;
			empty = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302987609);
			break;
		case linearUnitsType.Mils:
			num3 = 8;
			empty = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302987588);
			break;
		case linearUnitsType.Microns:
			num3 = 9;
			empty = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911455);
			break;
		case linearUnitsType.Centimeters:
			num3 = 10;
			empty = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302930010);
			break;
		case linearUnitsType.Microinches:
			num3 = 11;
			empty = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302987598);
			break;
		default:
			throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302925401) + _0023_003DzsAi4oSk_003D);
		}
		string arg = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302987576), num3, _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzHmj4S4kpLcz56MAA1A_003D_003D(empty), DateTime.Now);
		_0023_003DzzvTcRNc_003D.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986763), arg, 6 + num);
		_0023_003DzzvTcRNc_003D.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986763), 1E-08.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962), 7 + num);
		_0023_003DzzvTcRNc_003D.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986763), _0023_003Dzgfxbk3apRWkCxbrhIg_003D_003D.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962), 8 + num);
		string _0023_003DzwyYng5o_003D2 = ((_0023_003DzsnJ8FOw_003D.Length > 68) ? _0023_003DzsnJ8FOw_003D.Substring(0, 68) : _0023_003DzsnJ8FOw_003D);
		_0023_003DzzvTcRNc_003D.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986763), _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzHmj4S4kpLcz56MAA1A_003D_003D(_0023_003DzwyYng5o_003D2) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962), 9 + num);
		string _0023_003DzwyYng5o_003D3 = ((_0023_003DzdHmwPwj6z79_0024444NQW7KBrs_003D.Length > 68) ? _0023_003DzdHmwPwj6z79_0024444NQW7KBrs_003D.Substring(0, 68) : _0023_003DzdHmwPwj6z79_0024444NQW7KBrs_003D);
		_0023_003DzzvTcRNc_003D.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986763), _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzHmj4S4kpLcz56MAA1A_003D_003D(_0023_003DzwyYng5o_003D3) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962), 10 + num);
		_0023_003DzzvTcRNc_003D.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302987531), 11 + num);
		int _0023_003DzXrBIpWM_003D = 1;
		int _0023_003DzXrBIpWM_003D2 = 1;
		int count = _0023_003Dza_SABTbwi5q2.Count;
		int _0023_003Dz13KtlVg_003D = count * 2;
		for (int j = 0; j < count; j++)
		{
			_0023_003Dza_SABTbwi5q2[j]._0023_003DzwnHyM_uvlOeZ(_0023_003DzzvTcRNc_003D, ref _0023_003DzXrBIpWM_003D);
			if (!_0023_003DzI8SQX5cpoKsqrKUaAw_003D_003D(j + 1, _0023_003Dz13KtlVg_003D))
			{
				_0023_003DzzvTcRNc_003D.Close();
				return;
			}
		}
		for (int k = 0; k < count; k++)
		{
			_0023_003Dza_SABTbwi5q2[k]._0023_003DziYGQdIE_003D(_0023_003DzzvTcRNc_003D, ref _0023_003DzXrBIpWM_003D2);
			if (!_0023_003DzI8SQX5cpoKsqrKUaAw_003D_003D(count + k + 1, _0023_003Dz13KtlVg_003D))
			{
				_0023_003DzzvTcRNc_003D.Close();
				return;
			}
		}
		_0023_003DzzvTcRNc_003D.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302987751), 11 + num, _0023_003DzXrBIpWM_003D - 1, _0023_003DzXrBIpWM_003D2 - 1);
	}
}
