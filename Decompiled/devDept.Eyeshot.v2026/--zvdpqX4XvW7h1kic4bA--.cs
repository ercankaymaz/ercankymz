using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Schema;

internal sealed class _0023_003DzvdpqX4XvW7h1kic4bA_003D_003D
{
	private struct _0023_003DzvEynWQU_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003DzmoXaE7LRujYk _0023_003Dz_0024YLysSA_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public long _0023_003Dz1ltWTOc_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public long _0023_003DzsUYguL0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzoMBKEgY_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzfBEBL_o_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003Dz6zJlTnWVwHWB2xe30Q_003D_003D _0023_003DzgyaA9s0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzW_0024vcp6RO4JKm;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DztXNl1TCzKZ1t;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public long _0023_003DzZug38hG7GOm_;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public long _0023_003Dz736ekIs_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003Dz21GtMc_0024gZS5fxCqxwSeQBYhr0RqN;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public long _0023_003Dz7tIMWlw_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string _0023_003DzuhjYLAk_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003DzVbNDMkfrndgH _0023_003DzQ0xMNiM1PwJg;
	}

	private _0023_003Dzx3stKwWHA6u8Y67B_g_003D_003D _0023_003Dz6BlkOglxUnPX;

	public XmlReader _0023_003Dz1a1AvOU1T8u5;

	public Dictionary<string, string> _0023_003Dz31SK59PQMpMu = new Dictionary<string, string>();

	private Stack<_0023_003DzvEynWQU_003D> _0023_003Dzh77O8lc_003D;

	public _0023_003DzvdpqX4XvW7h1kic4bA_003D_003D(_0023_003Dzx3stKwWHA6u8Y67B_g_003D_003D _0023_003DzwaocUQk_003D)
	{
		_0023_003Dz6BlkOglxUnPX = _0023_003DzwaocUQk_003D;
		_0023_003Dz1a1AvOU1T8u5 = null;
	}

	public void _0023_003DzMkd41wQ_003D()
	{
		_0023_003Dz1a1AvOU1T8u5 = _0023_003DzFgvtamiZYsD0();
		if (_0023_003Dz1a1AvOU1T8u5 == null)
		{
			throw new Exception();
		}
	}

	private XmlReader _0023_003DzFgvtamiZYsD0()
	{
		if (_0023_003Dz6BlkOglxUnPX == null)
		{
			throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743897));
		}
		string text = new _0023_003DzA3Z1dYVi2EXQAqU5KlA_FRQ_003D(_0023_003Dz6BlkOglxUnPX._0023_003DzsnOOAHE_003D, _0023_003Dz6BlkOglxUnPX._0023_003DzzitoAAO7OMsF, _0023_003Dz6BlkOglxUnPX._0023_003DzEVaLeFlXvBPz)._0023_003DzaZ5ER5LKHj3n();
		if (string.IsNullOrWhiteSpace(text))
		{
			throw new InvalidOperationException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743852));
		}
		XmlReaderSettings xmlReaderSettings = new XmlReaderSettings
		{
			IgnoreWhitespace = true,
			IgnoreComments = true,
			IgnoreProcessingInstructions = true,
			DtdProcessing = DtdProcessing.Ignore,
			ValidationType = ValidationType.Schema
		};
		xmlReaderSettings.ValidationFlags |= XmlSchemaValidationFlags.ProcessIdentityConstraints;
		xmlReaderSettings.ValidationEventHandler += _0023_003DzvsSXcMZe9fiL;
		return XmlReader.Create(new StringReader(text.Trim(default(char))), xmlReaderSettings);
	}

	private void _0023_003DzvsSXcMZe9fiL(object _0023_003Dz9VjL5i0_003D, ValidationEventArgs _0023_003DzbfrNXYE_003D)
	{
	}

	public void _0023_003DzDFLLvIM_003D()
	{
		_0023_003DzVcifV9WRDr_gO4TtTA_003D_003D._0023_003DzNQeUxi0_003D();
		if (_0023_003Dz1a1AvOU1T8u5 == null)
		{
			throw new InvalidOperationException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302744059));
		}
		while (_0023_003Dz1a1AvOU1T8u5.Read())
		{
			if (_0023_003Dz1a1AvOU1T8u5.NodeType == XmlNodeType.Element)
			{
				_0023_003Dz1a1AvOU1T8u5.GetAttribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655404));
				_0023_003DzN9yvS5Q_003D(_0023_003Dz1a1AvOU1T8u5);
				if (_0023_003Dz1a1AvOU1T8u5.IsEmptyElement)
				{
					_0023_003DzAMlEafU_003D(_0023_003Dz1a1AvOU1T8u5);
				}
			}
			else if (_0023_003Dz1a1AvOU1T8u5.NodeType == XmlNodeType.Text)
			{
				_0023_003DzjMNcuqDNGwde(_0023_003Dz1a1AvOU1T8u5);
			}
			else if (_0023_003Dz1a1AvOU1T8u5.NodeType == XmlNodeType.EndElement)
			{
				_0023_003DzAMlEafU_003D(_0023_003Dz1a1AvOU1T8u5);
			}
			else if (_0023_003Dz1a1AvOU1T8u5.NodeType == XmlNodeType.CDATA)
			{
				_0023_003DzmBUkAmxTlsed(_0023_003Dz1a1AvOU1T8u5);
			}
		}
	}

	public void _0023_003DzjMNcuqDNGwde(XmlReader _0023_003Dz1a1AvOU1T8u5)
	{
		_0023_003DzvEynWQU_003D item = _0023_003Dzh77O8lc_003D.Pop();
		_0023_003DzmoXaE7LRujYk _0023_003Dz_0024YLysSA_003D = item._0023_003Dz_0024YLysSA_003D;
		if ((uint)(_0023_003Dz_0024YLysSA_003D - 1) <= 2u || _0023_003Dz_0024YLysSA_003D == (_0023_003DzmoXaE7LRujYk)8)
		{
			if (_0023_003Dz1a1AvOU1T8u5.Value.Trim().Length > 0)
			{
				throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743988) + _0023_003Dz1a1AvOU1T8u5.Value);
			}
		}
		else
		{
			item._0023_003DzuhjYLAk_003D += _0023_003Dz1a1AvOU1T8u5.Value;
		}
		_0023_003Dzh77O8lc_003D.Push(item);
	}

	public void _0023_003DzAMlEafU_003D(XmlReader _0023_003Dz1a1AvOU1T8u5)
	{
		_0023_003DzVbNDMkfrndgH _0023_003DzVbNDMkfrndgH2 = null;
		_0023_003DzvEynWQU_003D _0023_003DzvEynWQU_003D2 = _0023_003Dzh77O8lc_003D.Peek();
		_0023_003Dzh77O8lc_003D.Pop();
		switch (_0023_003DzvEynWQU_003D2._0023_003Dz_0024YLysSA_003D)
		{
		case (_0023_003DzmoXaE7LRujYk)1:
		case (_0023_003DzmoXaE7LRujYk)2:
			_0023_003DzVbNDMkfrndgH2 = _0023_003DzvEynWQU_003D2._0023_003DzQ0xMNiM1PwJg;
			break;
		case (_0023_003DzmoXaE7LRujYk)7:
			_0023_003DzVbNDMkfrndgH2 = new _0023_003DzKqMLsNpW4Ni9LqAo0Q_003D_003D(_0023_003Dz6BlkOglxUnPX, _0023_003DzvEynWQU_003D2._0023_003DzuhjYLAk_003D);
			break;
		case (_0023_003DzmoXaE7LRujYk)4:
		{
			long _0023_003DzPzO_0024GUk_003D2 = 0L;
			bool flag2 = false;
			if (_0023_003DzvEynWQU_003D2._0023_003DzuhjYLAk_003D == null)
			{
				_0023_003DzvEynWQU_003D2._0023_003DzuhjYLAk_003D = string.Empty;
			}
			if (_0023_003DzvEynWQU_003D2._0023_003DzuhjYLAk_003D.Length > 0)
			{
				_0023_003DzPzO_0024GUk_003D2 = _0023_003DzYdiz1ZJ6Hugt(_0023_003DzvEynWQU_003D2._0023_003DzuhjYLAk_003D);
				flag2 = true;
			}
			_0023_003Dzz6JxknZjh2z7MQAo3A_003D_003D _0023_003Dzz6JxknZjh2z7MQAo3A_003D_003D2 = new _0023_003Dzz6JxknZjh2z7MQAo3A_003D_003D(_0023_003Dz6BlkOglxUnPX, _0023_003DzPzO_0024GUk_003D2, _0023_003DzvEynWQU_003D2._0023_003Dz1ltWTOc_003D, _0023_003DzvEynWQU_003D2._0023_003DzsUYguL0_003D);
			if (flag2)
			{
				_0023_003Dzz6JxknZjh2z7MQAo3A_003D_003D2._0023_003DzviuWryw_003D();
			}
			_0023_003DzVbNDMkfrndgH2 = _0023_003Dzz6JxknZjh2z7MQAo3A_003D_003D2;
			break;
		}
		case (_0023_003DzmoXaE7LRujYk)6:
		{
			double _0023_003DzPzO_0024GUk_003D = 0.0;
			bool flag2 = false;
			if (_0023_003DzvEynWQU_003D2._0023_003DzuhjYLAk_003D == null)
			{
				_0023_003DzvEynWQU_003D2._0023_003DzuhjYLAk_003D = string.Empty;
			}
			if (_0023_003DzvEynWQU_003D2._0023_003DzuhjYLAk_003D.Length > 0)
			{
				_0023_003DzPzO_0024GUk_003D = _0023_003Dz_npNuWqzX6oH(_0023_003DzvEynWQU_003D2._0023_003DzuhjYLAk_003D);
				flag2 = true;
			}
			_0023_003DzV_0024ZlxURV8mxIBGCNuA_003D_003D _0023_003DzV_0024ZlxURV8mxIBGCNuA_003D_003D2 = new _0023_003DzV_0024ZlxURV8mxIBGCNuA_003D_003D(_0023_003Dz6BlkOglxUnPX, _0023_003DzPzO_0024GUk_003D, _0023_003DzvEynWQU_003D2._0023_003DzgyaA9s0_003D, _0023_003DzvEynWQU_003D2._0023_003DzW_0024vcp6RO4JKm, _0023_003DzvEynWQU_003D2._0023_003DztXNl1TCzKZ1t);
			if (flag2)
			{
				_0023_003DzV_0024ZlxURV8mxIBGCNuA_003D_003D2._0023_003DzviuWryw_003D();
			}
			_0023_003DzVbNDMkfrndgH2 = _0023_003DzV_0024ZlxURV8mxIBGCNuA_003D_003D2;
			break;
		}
		case (_0023_003DzmoXaE7LRujYk)3:
			_0023_003DzVbNDMkfrndgH2 = _0023_003DzvEynWQU_003D2._0023_003DzQ0xMNiM1PwJg;
			break;
		case (_0023_003DzmoXaE7LRujYk)5:
		{
			long _0023_003Dz1uR7DbA_003D = 0L;
			bool flag = false;
			if (_0023_003DzvEynWQU_003D2._0023_003DzuhjYLAk_003D == null)
			{
				_0023_003DzvEynWQU_003D2._0023_003DzuhjYLAk_003D = string.Empty;
			}
			if (_0023_003DzvEynWQU_003D2._0023_003DzuhjYLAk_003D.Length > 0)
			{
				_0023_003Dz1uR7DbA_003D = _0023_003DzYdiz1ZJ6Hugt(_0023_003DzvEynWQU_003D2._0023_003DzuhjYLAk_003D);
				flag = true;
			}
			_0023_003DzZL_2neIdSiX9s0ymQQ_003D_003D _0023_003DzZL_2neIdSiX9s0ymQQ_003D_003D2 = new _0023_003DzZL_2neIdSiX9s0ymQQ_003D_003D(_0023_003Dz6BlkOglxUnPX, _0023_003Dz1uR7DbA_003D, _0023_003DzvEynWQU_003D2._0023_003Dz1ltWTOc_003D, _0023_003DzvEynWQU_003D2._0023_003DzsUYguL0_003D, _0023_003DzvEynWQU_003D2._0023_003DzoMBKEgY_003D, _0023_003DzvEynWQU_003D2._0023_003DzfBEBL_o_003D);
			if (flag)
			{
				_0023_003DzZL_2neIdSiX9s0ymQQ_003D_003D2._0023_003DzviuWryw_003D();
			}
			_0023_003DzVbNDMkfrndgH2 = _0023_003DzZL_2neIdSiX9s0ymQQ_003D_003D2;
			break;
		}
		case (_0023_003DzmoXaE7LRujYk)8:
			_0023_003DzVbNDMkfrndgH2 = new _0023_003Dzu1ZvE9NpYSXvxEF2Lw_003D_003D(_0023_003Dz6BlkOglxUnPX, _0023_003DzvEynWQU_003D2._0023_003DzZug38hG7GOm_, _0023_003DzvEynWQU_003D2._0023_003Dz736ekIs_003D);
			break;
		}
		if (_0023_003Dzh77O8lc_003D.Count == 0)
		{
			if (_0023_003DzVbNDMkfrndgH2._0023_003DzEKSHIVc_003D() != (_0023_003DzmoXaE7LRujYk)1)
			{
				throw new Exception();
			}
			_0023_003DzlkD20ogXGOONz6B7gQ_003D_003D _0023_003DzcY_ZZvw_003D = _0023_003Dz6BlkOglxUnPX._0023_003DzcY_ZZvw_003D;
			_0023_003DzcY_ZZvw_003D = _0023_003DzVbNDMkfrndgH2 as _0023_003DzlkD20ogXGOONz6B7gQ_003D_003D;
			_0023_003Dz6BlkOglxUnPX._0023_003DzcY_ZZvw_003D = _0023_003DzcY_ZZvw_003D;
			return;
		}
		_0023_003DzVbNDMkfrndgH _0023_003DzQ0xMNiM1PwJg = _0023_003Dzh77O8lc_003D.Peek()._0023_003DzQ0xMNiM1PwJg;
		if (_0023_003DzQ0xMNiM1PwJg == null)
		{
			throw new Exception();
		}
		switch (_0023_003DzQ0xMNiM1PwJg._0023_003DzEKSHIVc_003D())
		{
		case (_0023_003DzmoXaE7LRujYk)1:
			(_0023_003DzQ0xMNiM1PwJg as _0023_003DzlkD20ogXGOONz6B7gQ_003D_003D)._0023_003DzOnQC6_0024o_003D(_0023_003Dz1a1AvOU1T8u5.Name, _0023_003DzVbNDMkfrndgH2, _0023_003Dz_ck61Xg9EgoH: false);
			break;
		case (_0023_003DzmoXaE7LRujYk)3:
		{
			_0023_003Dzy7rvizke3oX84gLhZQ_003D_003D _0023_003Dzy7rvizke3oX84gLhZQ_003D_003D2 = _0023_003DzQ0xMNiM1PwJg as _0023_003Dzy7rvizke3oX84gLhZQ_003D_003D;
			string name = _0023_003Dz1a1AvOU1T8u5.Name;
			if (name == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743999))
			{
				_0023_003Dzy7rvizke3oX84gLhZQ_003D_003D2._0023_003DzW8jIErs_003D(_0023_003DzVbNDMkfrndgH2);
				break;
			}
			if (name == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743983))
			{
				if (_0023_003DzVbNDMkfrndgH2._0023_003DzEKSHIVc_003D() != (_0023_003DzmoXaE7LRujYk)2)
				{
					throw new Exception();
				}
				_0023_003DzYRXhdtZl_0024rwD6mdd1A_003D_003D _0023_003DzYRXhdtZl_0024rwD6mdd1A_003D_003D2 = _0023_003DzVbNDMkfrndgH2 as _0023_003DzYRXhdtZl_0024rwD6mdd1A_003D_003D;
				if (!_0023_003DzYRXhdtZl_0024rwD6mdd1A_003D_003D2._0023_003DzjF_SJxZxo24hHLsGjw_003D_003D())
				{
					throw new Exception();
				}
				_0023_003Dzy7rvizke3oX84gLhZQ_003D_003D2._0023_003Dz_0024_Iedx1P5yXe(_0023_003DzYRXhdtZl_0024rwD6mdd1A_003D_003D2);
				break;
			}
			throw new Exception();
		}
		case (_0023_003DzmoXaE7LRujYk)2:
			(_0023_003DzQ0xMNiM1PwJg as _0023_003DzYRXhdtZl_0024rwD6mdd1A_003D_003D)._0023_003DzGkfwiw0_003D(_0023_003DzVbNDMkfrndgH2);
			break;
		}
	}

	public long _0023_003DzYdiz1ZJ6Hugt(string _0023_003DzMWdLb44uNVku)
	{
		if (long.TryParse(_0023_003DzMWdLb44uNVku, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
		{
			return result;
		}
		throw new FormatException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743966) + _0023_003DzMWdLb44uNVku);
	}

	public double _0023_003Dz_npNuWqzX6oH(string _0023_003DzMWdLb44uNVku)
	{
		if (double.TryParse(_0023_003DzMWdLb44uNVku, NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
		{
			return result;
		}
		throw new FormatException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743650) + _0023_003DzMWdLb44uNVku);
	}

	private void _0023_003DzmBUkAmxTlsed(XmlReader _0023_003Dz1a1AvOU1T8u5)
	{
		_0023_003DzvEynWQU_003D item = _0023_003Dzh77O8lc_003D.Pop();
		_0023_003DzmoXaE7LRujYk _0023_003Dz_0024YLysSA_003D = item._0023_003Dz_0024YLysSA_003D;
		if ((uint)(_0023_003Dz_0024YLysSA_003D - 1) <= 2u || _0023_003Dz_0024YLysSA_003D == (_0023_003DzmoXaE7LRujYk)8)
		{
			if (_0023_003Dz1a1AvOU1T8u5.Value.Trim().Length > 0)
			{
				throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743988) + _0023_003Dz1a1AvOU1T8u5.Value);
			}
		}
		else
		{
			item._0023_003DzuhjYLAk_003D += _0023_003Dz1a1AvOU1T8u5.Value;
		}
		_0023_003Dzh77O8lc_003D.Push(item);
	}

	public void _0023_003DzN9yvS5Q_003D(XmlReader _0023_003DzkKz7OWA_003D)
	{
		string localName = _0023_003DzkKz7OWA_003D.LocalName;
		_ = _0023_003DzkKz7OWA_003D.Name;
		string attribute = _0023_003DzkKz7OWA_003D.GetAttribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655404));
		_0023_003DzvEynWQU_003D item = default(_0023_003DzvEynWQU_003D);
		if (attribute == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743648))
		{
			item._0023_003Dz_0024YLysSA_003D = (_0023_003DzmoXaE7LRujYk)4;
			string attribute2 = _0023_003DzkKz7OWA_003D.GetAttribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743630));
			if (!string.IsNullOrEmpty(attribute2))
			{
				long _0023_003Dz1ltWTOc_003D = long.Parse(attribute2);
				item._0023_003Dz1ltWTOc_003D = _0023_003Dz1ltWTOc_003D;
			}
			else
			{
				item._0023_003Dz1ltWTOc_003D = long.MinValue;
			}
			string attribute3 = _0023_003DzkKz7OWA_003D.GetAttribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743612));
			if (!string.IsNullOrEmpty(attribute3))
			{
				long _0023_003DzsUYguL0_003D = long.Parse(attribute3);
				item._0023_003DzsUYguL0_003D = _0023_003DzsUYguL0_003D;
			}
			else
			{
				item._0023_003DzsUYguL0_003D = long.MaxValue;
			}
			_0023_003Dzh77O8lc_003D.Push(item);
		}
		else if (attribute == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743594))
		{
			item._0023_003Dz_0024YLysSA_003D = (_0023_003DzmoXaE7LRujYk)1;
			if (localName == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743578))
			{
				bool flag = false;
				while (_0023_003DzkKz7OWA_003D.MoveToNextAttribute())
				{
					if (_0023_003DzkKz7OWA_003D.Name == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743560))
					{
						_0023_003Dz6BlkOglxUnPX._0023_003Dzrad9exQ_003D(string.Empty, _0023_003DzkKz7OWA_003D.Value);
						flag = true;
					}
					else if (_0023_003DzkKz7OWA_003D.Prefix == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743560))
					{
						_0023_003Dz6BlkOglxUnPX._0023_003Dzrad9exQ_003D(_0023_003DzkKz7OWA_003D.LocalName, _0023_003DzkKz7OWA_003D.Value);
					}
				}
				if (!flag)
				{
					throw new Exception();
				}
			}
			_0023_003DzlkD20ogXGOONz6B7gQ_003D_003D _0023_003DzlkD20ogXGOONz6B7gQ_003D_003D2 = new _0023_003DzlkD20ogXGOONz6B7gQ_003D_003D(_0023_003Dz6BlkOglxUnPX);
			_0023_003DzVbNDMkfrndgH _0023_003DzQ0xMNiM1PwJg = _0023_003DzlkD20ogXGOONz6B7gQ_003D_003D2;
			item._0023_003DzQ0xMNiM1PwJg = _0023_003DzQ0xMNiM1PwJg;
			if (localName == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743578))
			{
				_0023_003DzlkD20ogXGOONz6B7gQ_003D_003D2._0023_003DzCD4XrHXr8HgF();
			}
			if (_0023_003Dzh77O8lc_003D == null)
			{
				_0023_003Dzh77O8lc_003D = new Stack<_0023_003DzvEynWQU_003D>();
			}
			_0023_003Dzh77O8lc_003D.Push(item);
		}
		else if (attribute == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743796))
		{
			item._0023_003Dz_0024YLysSA_003D = (_0023_003DzmoXaE7LRujYk)7;
			if (_0023_003Dzh77O8lc_003D == null)
			{
				_0023_003Dzh77O8lc_003D = new Stack<_0023_003DzvEynWQU_003D>();
			}
			_0023_003Dzh77O8lc_003D.Push(item);
		}
		else if (attribute == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986399))
		{
			item._0023_003Dz_0024YLysSA_003D = (_0023_003DzmoXaE7LRujYk)2;
			string attribute4 = _0023_003DzkKz7OWA_003D.GetAttribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743807));
			if (!string.IsNullOrEmpty(attribute4))
			{
				if (!long.TryParse(attribute4, out var result))
				{
					throw new Exception();
				}
				item._0023_003Dz21GtMc_0024gZS5fxCqxwSeQBYhr0RqN = result == 1;
			}
			else
			{
				item._0023_003Dz21GtMc_0024gZS5fxCqxwSeQBYhr0RqN = false;
			}
			_0023_003DzYRXhdtZl_0024rwD6mdd1A_003D_003D _0023_003DzQ0xMNiM1PwJg2 = new _0023_003DzYRXhdtZl_0024rwD6mdd1A_003D_003D(_0023_003Dz6BlkOglxUnPX, item._0023_003Dz21GtMc_0024gZS5fxCqxwSeQBYhr0RqN);
			item._0023_003DzQ0xMNiM1PwJg = _0023_003DzQ0xMNiM1PwJg2;
			_0023_003Dzh77O8lc_003D.Push(item);
		}
		else if (attribute == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743746))
		{
			item._0023_003Dz_0024YLysSA_003D = (_0023_003DzmoXaE7LRujYk)3;
			item._0023_003DzZug38hG7GOm_ = long.Parse(_0023_003DzkKz7OWA_003D.GetAttribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743735)));
			item._0023_003Dz7tIMWlw_003D = long.Parse(_0023_003DzkKz7OWA_003D.GetAttribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743722)));
			_0023_003Dzy7rvizke3oX84gLhZQ_003D_003D obj = new _0023_003Dzy7rvizke3oX84gLhZQ_003D_003D(_0023_003Dz6BlkOglxUnPX);
			obj._0023_003DzT7rkFWYfP7Ui(item._0023_003Dz7tIMWlw_003D);
			obj._0023_003DzjQPuj6vQB2ct5VAg9w_003D_003D(_0023_003Dz6BlkOglxUnPX._0023_003DzsnOOAHE_003D._0023_003DzVz5VrVqTZjrL((ulong)item._0023_003DzZug38hG7GOm_));
			_0023_003DzVbNDMkfrndgH _0023_003DzQ0xMNiM1PwJg3 = obj;
			item._0023_003DzQ0xMNiM1PwJg = _0023_003DzQ0xMNiM1PwJg3;
			_0023_003Dzh77O8lc_003D.Push(item);
		}
		else if (attribute == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743708))
		{
			item._0023_003Dz_0024YLysSA_003D = (_0023_003DzmoXaE7LRujYk)6;
			string attribute5 = _0023_003DzkKz7OWA_003D.GetAttribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743688));
			if (!string.IsNullOrEmpty(attribute5))
			{
				if (attribute5 == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302744440))
				{
					item._0023_003DzgyaA9s0_003D = (_0023_003Dz6zJlTnWVwHWB2xe30Q_003D_003D)1;
				}
				else
				{
					if (!(attribute5 == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302744419)))
					{
						throw new Exception();
					}
					item._0023_003DzgyaA9s0_003D = (_0023_003Dz6zJlTnWVwHWB2xe30Q_003D_003D)2;
				}
			}
			else
			{
				item._0023_003DzgyaA9s0_003D = (_0023_003Dz6zJlTnWVwHWB2xe30Q_003D_003D)2;
			}
			if (_0023_003DzkKz7OWA_003D.GetAttribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743630)) != null)
			{
				item._0023_003DzW_0024vcp6RO4JKm = double.Parse(_0023_003DzkKz7OWA_003D.GetAttribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743630)), NumberStyles.Float, CultureInfo.InvariantCulture);
			}
			if (item._0023_003DzW_0024vcp6RO4JKm == 0.0)
			{
				if (item._0023_003DzgyaA9s0_003D == (_0023_003Dz6zJlTnWVwHWB2xe30Q_003D_003D)1)
				{
					item._0023_003DzW_0024vcp6RO4JKm = -3.4028234663852886E+38;
				}
				else
				{
					item._0023_003DzW_0024vcp6RO4JKm = double.MinValue;
				}
			}
			if (_0023_003DzkKz7OWA_003D.GetAttribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743612)) != null)
			{
				item._0023_003DztXNl1TCzKZ1t = double.Parse(_0023_003DzkKz7OWA_003D.GetAttribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743612)), NumberStyles.Float, CultureInfo.InvariantCulture);
			}
			if (item._0023_003DztXNl1TCzKZ1t == 0.0)
			{
				if (item._0023_003DzgyaA9s0_003D == (_0023_003Dz6zJlTnWVwHWB2xe30Q_003D_003D)1)
				{
					item._0023_003DztXNl1TCzKZ1t = 3.4028234663852886E+38;
				}
				else
				{
					item._0023_003DztXNl1TCzKZ1t = double.MaxValue;
				}
			}
			_0023_003Dzh77O8lc_003D.Push(item);
		}
		else if (attribute == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302744402))
		{
			item._0023_003Dz_0024YLysSA_003D = (_0023_003DzmoXaE7LRujYk)5;
			if (_0023_003DzkKz7OWA_003D.GetAttribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743630)) != null)
			{
				item._0023_003Dz1ltWTOc_003D = long.Parse(_0023_003DzkKz7OWA_003D.GetAttribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743630)));
			}
			else if (item._0023_003Dz1ltWTOc_003D == 0L)
			{
				item._0023_003Dz1ltWTOc_003D = long.MinValue;
			}
			if (_0023_003DzkKz7OWA_003D.GetAttribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743612)) != null)
			{
				item._0023_003DzsUYguL0_003D = long.Parse(_0023_003DzkKz7OWA_003D.GetAttribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743612)));
			}
			else if (item._0023_003DzsUYguL0_003D == 0L)
			{
				item._0023_003DzsUYguL0_003D = long.MaxValue;
			}
			if (_0023_003DzkKz7OWA_003D.GetAttribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302696897)) != null)
			{
				item._0023_003DzoMBKEgY_003D = double.Parse(_0023_003DzkKz7OWA_003D.GetAttribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302696897)), NumberStyles.Float, CultureInfo.InvariantCulture);
			}
			else if (item._0023_003DzoMBKEgY_003D == 0.0)
			{
				item._0023_003DzoMBKEgY_003D = 0.0;
			}
			if (_0023_003DzkKz7OWA_003D.GetAttribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302675485)) != null)
			{
				item._0023_003DzfBEBL_o_003D = double.Parse(_0023_003DzkKz7OWA_003D.GetAttribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302675485)), NumberStyles.Float, CultureInfo.InvariantCulture);
			}
			else if (item._0023_003DzfBEBL_o_003D == 0.0)
			{
				item._0023_003DzfBEBL_o_003D = 0.0;
			}
			_0023_003Dzh77O8lc_003D.Push(item);
		}
		else
		{
			if (!(attribute == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302744390)))
			{
				throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302744399));
			}
			item._0023_003Dz_0024YLysSA_003D = (_0023_003DzmoXaE7LRujYk)8;
			if (_0023_003DzkKz7OWA_003D.GetAttribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743735)) != null)
			{
				item._0023_003DzZug38hG7GOm_ = long.Parse(_0023_003DzkKz7OWA_003D.GetAttribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743735)));
			}
			else
			{
				item._0023_003DzZug38hG7GOm_ = 0L;
			}
			if (_0023_003DzkKz7OWA_003D.GetAttribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302696724)) != null)
			{
				item._0023_003Dz736ekIs_003D = long.Parse(_0023_003DzkKz7OWA_003D.GetAttribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302696724)));
			}
			else
			{
				item._0023_003Dz736ekIs_003D = 0L;
			}
			_0023_003Dzh77O8lc_003D.Push(item);
		}
	}
}
