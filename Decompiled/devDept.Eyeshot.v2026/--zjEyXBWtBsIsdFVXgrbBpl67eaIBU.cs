using System.Collections.Generic;
using devDept;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;

internal sealed class _0023_003DzjEyXBWtBsIsdFVXgrbBpl67eaIBU
{
	private readonly double[] _0023_003DzOy7x6nKmJG_0024PzP1zikqcql_pFqjr;

	private AssemblyLeaf _0023_003Dzb3MhDz4Bd9HW2MU5HQ_003D_003D;

	private readonly bool _0023_003Dzh1W5iDd8_0024MXUCpuAS8YXAzOR_UXg;

	private readonly GfxAttributesWire _0023_003DzhhcoHBO6BxHF7oEESg_003D_003D;

	private readonly string _0023_003DzBJq7RJjsbuGoQhmH_0024Q_003D_003D;

	private readonly string _0023_003DzRuk14_0024Wg4j8Smbxb2g_003D_003D;

	private readonly fontStyle _0023_003DzIpPwz3OekvZuNfjfbGZAMoc_003D;

	internal _0023_003DzjEyXBWtBsIsdFVXgrbBpl67eaIBU()
	{
	}

	internal _0023_003DzjEyXBWtBsIsdFVXgrbBpl67eaIBU(double[,] _0023_003DzxA0ELu0Iq0JewZHAxg_003D_003D, GfxAttributesWire _0023_003DzqP5lTto_003D, AssemblyLeaf _0023_003Dzq0Mt9hYROxWQ, TextStyle _0023_003Dzgkctzk6d2IIh, int _0023_003DzjytgLpM_003D = 0)
	{
		if (_0023_003DzxA0ELu0Iq0JewZHAxg_003D_003D.GetLength(0) != 4)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997490));
		}
		_0023_003DzOy7x6nKmJG_0024PzP1zikqcql_pFqjr = new double[12]
		{
			_0023_003DzxA0ELu0Iq0JewZHAxg_003D_003D[0, 0],
			_0023_003DzxA0ELu0Iq0JewZHAxg_003D_003D[0, 1],
			_0023_003DzxA0ELu0Iq0JewZHAxg_003D_003D[0, 2],
			_0023_003DzxA0ELu0Iq0JewZHAxg_003D_003D[1, 0],
			_0023_003DzxA0ELu0Iq0JewZHAxg_003D_003D[1, 1],
			_0023_003DzxA0ELu0Iq0JewZHAxg_003D_003D[1, 2],
			_0023_003DzxA0ELu0Iq0JewZHAxg_003D_003D[2, 0],
			_0023_003DzxA0ELu0Iq0JewZHAxg_003D_003D[2, 1],
			_0023_003DzxA0ELu0Iq0JewZHAxg_003D_003D[2, 2],
			_0023_003DzxA0ELu0Iq0JewZHAxg_003D_003D[3, 0],
			_0023_003DzxA0ELu0Iq0JewZHAxg_003D_003D[3, 1],
			_0023_003DzxA0ELu0Iq0JewZHAxg_003D_003D[3, 2]
		};
		_0023_003DzhhcoHBO6BxHF7oEESg_003D_003D = _0023_003DzqP5lTto_003D;
		_0023_003Dz75L0A54W2Egc(_0023_003Dzq0Mt9hYROxWQ);
		_0023_003DzRuk14_0024Wg4j8Smbxb2g_003D_003D = _0023_003Dzgkctzk6d2IIh.FontFamilyName;
		_0023_003DzIpPwz3OekvZuNfjfbGZAMoc_003D = _0023_003Dzgkctzk6d2IIh.Style;
		if (_0023_003Dz0tIOZG5ZfcAY().Entity is MultilineText multilineText)
		{
			_0023_003DzBJq7RJjsbuGoQhmH_0024Q_003D_003D = multilineText.textLines[_0023_003DzjytgLpM_003D];
		}
		else if (_0023_003Dz0tIOZG5ZfcAY().Entity is Dimension dimension)
		{
			_0023_003DzBJq7RJjsbuGoQhmH_0024Q_003D_003D = dimension.textLines[_0023_003DzjytgLpM_003D];
			_0023_003Dzh1W5iDd8_0024MXUCpuAS8YXAzOR_UXg = dimension.textFlipped;
		}
		else
		{
			_0023_003DzBJq7RJjsbuGoQhmH_0024Q_003D_003D = ((Text)_0023_003Dz0tIOZG5ZfcAY().Entity).TextString;
		}
	}

	public double[] _0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()
	{
		return _0023_003DzOy7x6nKmJG_0024PzP1zikqcql_pFqjr;
	}

	public List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> _0023_003DzqPk52tIIDIJe()
	{
		List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> list = new List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT>();
		list.Add(new _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT
		{
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new double[6]
			{
				_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[0],
				_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[1],
				_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[2],
				_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[3],
				_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[4],
				_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[5]
			}
		});
		list.Add(new _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT
		{
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new double[6]
			{
				_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[3],
				_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[4],
				_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[5],
				_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[6],
				_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[7],
				_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[8]
			}
		});
		list.Add(new _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT
		{
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new double[6]
			{
				_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[6],
				_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[7],
				_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[8],
				_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[9],
				_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[10],
				_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[11]
			}
		});
		list.Add(new _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT
		{
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new double[6]
			{
				_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[9],
				_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[10],
				_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[11],
				_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[0],
				_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[1],
				_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[2]
			}
		});
		return list;
	}

	internal AssemblyLeaf _0023_003Dz0tIOZG5ZfcAY()
	{
		return _0023_003Dzb3MhDz4Bd9HW2MU5HQ_003D_003D;
	}

	private void _0023_003Dz75L0A54W2Egc(AssemblyLeaf _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dzb3MhDz4Bd9HW2MU5HQ_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public bool _0023_003DzrCyY1TVDe4xioci3zg_003D_003D()
	{
		return _0023_003Dzh1W5iDd8_0024MXUCpuAS8YXAzOR_UXg;
	}

	public GfxAttributesWire _0023_003DzHptl2yRuV4Y_0024()
	{
		return _0023_003DzhhcoHBO6BxHF7oEESg_003D_003D;
	}

	public string _0023_003Dztfs771XhsCDR()
	{
		return _0023_003DzBJq7RJjsbuGoQhmH_0024Q_003D_003D;
	}

	public string _0023_003DzonppTMzbco4i()
	{
		return _0023_003DzRuk14_0024Wg4j8Smbxb2g_003D_003D;
	}

	public fontStyle _0023_003DzcMHHHXFgK3x9()
	{
		return _0023_003DzIpPwz3OekvZuNfjfbGZAMoc_003D;
	}
}
