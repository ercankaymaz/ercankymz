using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class ReadGCode : ReadFileAsync
{
	private sealed class _0023_003Dz1g4Hn6j2QFrc
	{
		private List<_0023_003Dz64E_gingnyNO> _0023_003DzbyMW1lc_003D = new List<_0023_003Dz64E_gingnyNO>();

		public _0023_003Dz64E_gingnyNO _0023_003Dz_MS_Clw_003D;

		public string _0023_003DzicLNfd33jEjb()
		{
			return _0023_003Dz_MS_Clw_003D._0023_003Dz2tLFTBU_003D;
		}

		public void _0023_003DzF7YPEOksJKFh(string _0023_003DzPzO_0024GUk_003D)
		{
			foreach (_0023_003Dz64E_gingnyNO item in _0023_003DzbyMW1lc_003D)
			{
				if (string.Compare(_0023_003DzPzO_0024GUk_003D, item._0023_003Dz2tLFTBU_003D, ignoreCase: true) == 0)
				{
					_0023_003Dz_MS_Clw_003D = item;
				}
			}
		}

		public void _0023_003Dz3bzltNQ_003D(string _0023_003DzS_00246o7tc_003D)
		{
			_0023_003DzbyMW1lc_003D.Remove(_0023_003Dz_MS_Clw_003D);
		}

		public void _0023_003DzMalZVzQ_003D(_0023_003Dz64E_gingnyNO _0023_003DzkKfJheA_003D)
		{
			_0023_003DzbyMW1lc_003D.Add(_0023_003DzkKfJheA_003D);
			_0023_003Dz_MS_Clw_003D = _0023_003DzkKfJheA_003D;
		}

		public void _0023_003Dz7NU3mw3_ywOc()
		{
			_0023_003DzbyMW1lc_003D.Clear();
			_0023_003DzWdikzLoFPQLE();
			_0023_003Dz_MS_Clw_003D = _0023_003DzbyMW1lc_003D[0];
		}

		private void _0023_003DzWdikzLoFPQLE()
		{
			_0023_003Dz64E_gingnyNO _0023_003Dz64E_gingnyNO2 = new _0023_003Dz64E_gingnyNO();
			_0023_003Dz64E_gingnyNO2._0023_003Dz2tLFTBU_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004948);
			_0023_003Dz64E_gingnyNO2._0023_003DzAYWvRJA_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004957);
			_0023_003Dz64E_gingnyNO2._0023_003Dz2a1ZisxSVBU2 = false;
			_0023_003Dz64E_gingnyNO2._0023_003DzZf7gmGze_00249X9 = false;
			_0023_003Dz64E_gingnyNO2._0023_003DzkMjeYZDbwgvg = false;
			_0023_003Dz64E_gingnyNO2._0023_003DzUc_0024aHii4fiHT = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302919787);
			_0023_003Dz64E_gingnyNO2._0023_003Dzd_0024kBzeg_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005169);
			_0023_003Dz64E_gingnyNO2._0023_003DzOThU2PllH_0024Ge = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005179);
			_0023_003Dz64E_gingnyNO2._0023_003DzLL2cgQ0_003D = (_0023_003DzLL2cgQ0_003D)2;
			_0023_003Dz64E_gingnyNO2._0023_003DzXeIVO7S2FlGY_Hg3uw_003D_003D = (_0023_003Dz_afi8gY_003D)2;
			_0023_003Dz64E_gingnyNO2._0023_003DzK5N9H3Qo0fTIS3EaXA_003D_003D = (_0023_003DzvW8bT_0024omzJb3rPr53A_003D_003D)(-1);
			_0023_003Dz64E_gingnyNO2._0023_003DzxHFEkIE_003D = 4;
			_0023_003Dz64E_gingnyNO2._0023_003DzECRIVYU_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005157);
			_0023_003Dz64E_gingnyNO2._0023_003Dz_1z71sNt09K7 = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005167);
			_0023_003Dz64E_gingnyNO2._0023_003DzwdxHnEP_c5cV = 4;
			_0023_003Dz64E_gingnyNO2._0023_003DzXECcuRkJyd_U = (_0023_003DzILN1e7bv_WZLFSFuAg_003D_003D)1;
			_0023_003Dz64E_gingnyNO2._0023_003Dzelho2YIEXp4oXxREWErauBw_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004948);
			_0023_003Dz64E_gingnyNO2._0023_003Dzdb_XWiY_003D[0] = 315f;
			_0023_003Dz64E_gingnyNO2._0023_003Dzdb_XWiY_003D[1] = 0f;
			_0023_003Dz64E_gingnyNO2._0023_003Dzdb_XWiY_003D[2] = 315f;
			_0023_003Dz64E_gingnyNO2._0023_003DzNNLdNHE_003D[0] = 0f;
			_0023_003Dz64E_gingnyNO2._0023_003DzNNLdNHE_003D[1] = 0f;
			_0023_003Dz64E_gingnyNO2._0023_003DzNNLdNHE_003D[2] = 0f;
			_0023_003Dz64E_gingnyNO2._0023_003DzecG31vQ_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005145);
			_0023_003Dz64E_gingnyNO2._0023_003DzPz4IFE0_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005123);
			_0023_003Dz64E_gingnyNO2._0023_003DzOIu5sNcxtK2E = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005133);
			_0023_003Dz64E_gingnyNO2._0023_003DzP8hgGoi7BVGX = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005111);
			_0023_003Dz64E_gingnyNO2._0023_003DzBQ_0024C9A_0024ALep_Np5thA_003D_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911028);
			_0023_003Dz64E_gingnyNO2._0023_003Dz16az_pPmbkSo[0] = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005089);
			_0023_003Dz64E_gingnyNO2._0023_003Dz16az_pPmbkSo[1] = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005099);
			_0023_003Dz64E_gingnyNO2._0023_003Dz16az_pPmbkSo[2] = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005077);
			_0023_003Dz64E_gingnyNO2._0023_003Dz16az_pPmbkSo[3] = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005087);
			_0023_003Dz64E_gingnyNO2._0023_003Dz16az_pPmbkSo[4] = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005065);
			_0023_003Dz64E_gingnyNO2._0023_003Dz16az_pPmbkSo[5] = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004787);
			_0023_003Dz64E_gingnyNO2._0023_003Dz16az_pPmbkSo[6] = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004797);
			_0023_003Dz64E_gingnyNO2._0023_003Dz16az_pPmbkSo[7] = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004775);
			_0023_003Dz64E_gingnyNO2._0023_003Dz16az_pPmbkSo[8] = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004753);
			_0023_003Dz64E_gingnyNO2._0023_003Dz16az_pPmbkSo[9] = string.Empty;
			_0023_003Dz64E_gingnyNO2._0023_003Dz2WiriP8_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004763);
			_0023_003Dz64E_gingnyNO2._0023_003Dzw3nErG_0024A4f04 = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004741);
			_0023_003Dz64E_gingnyNO2._0023_003Dz702tHHl5K_0024ot[0] = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004751);
			_0023_003Dz64E_gingnyNO2._0023_003Dz702tHHl5K_0024ot[1] = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004729);
			_0023_003Dz64E_gingnyNO2._0023_003DzKcCkxONUkjOe = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911084);
			_0023_003Dz64E_gingnyNO2._0023_003DzrAuQpI1_0024FCEU = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004707);
			_0023_003Dz64E_gingnyNO2._0023_003DztM04wvRG3luT = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004717);
			_0023_003Dz64E_gingnyNO2._0023_003Dz5pe_00241dGDezfX = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004695);
			_0023_003Dz64E_gingnyNO2._0023_003Dzn2xdhL0J_ARY = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004673);
			_0023_003Dz64E_gingnyNO2._0023_003DzVBdBAe7FDIWDpPGvLw_003D_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911431);
			_0023_003DzbyMW1lc_003D.Add(_0023_003Dz64E_gingnyNO2);
		}

		public void _0023_003DzXmKHDVbUjvGd(string _0023_003Dzi6DTzI0_00249qkVnJCZ5w_003D_003D)
		{
			int num = 0;
			StringBuilder stringBuilder = new StringBuilder();
			string text = null;
			StreamReader streamReader = null;
			if (_0023_003DzbyMW1lc_003D.Count == 0)
			{
				_0023_003Dz_MS_Clw_003D = null;
				return;
			}
			streamReader = new StreamReader(_0023_003Dzi6DTzI0_00249qkVnJCZ5w_003D_003D);
			while (streamReader.Peek() >= 0 && num < 50)
			{
				stringBuilder.Append(streamReader.ReadLine());
				num++;
			}
			streamReader.Close();
			text = stringBuilder.ToString();
			foreach (_0023_003Dz64E_gingnyNO item in _0023_003DzbyMW1lc_003D)
			{
				if (text.Contains(item._0023_003Dzelho2YIEXp4oXxREWErauBw_003D))
				{
					_0023_003Dz_MS_Clw_003D = item;
					break;
				}
			}
		}
	}

	private struct _0023_003Dz3fSQ06k_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private char _0023_003Dz7FYqVoM_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public float _0023_003Dz1uR5EQk_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string _0023_003Dz1wTaPJQ_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003DzC44p11HKZacA.letters _0023_003DzUYd_00240tw_003D;

		public char _0023_003Dz8F8_002454umdoK7()
		{
			return _0023_003Dz7FYqVoM_003D;
		}

		public void _0023_003DzebfWBK1CW3R8(char _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003Dz7FYqVoM_003D = _0023_003DzPzO_0024GUk_003D;
			_0023_003DzUYd_00240tw_003D = (_0023_003DzC44p11HKZacA.letters)Enum.Parse(typeof(_0023_003DzC44p11HKZacA.letters), _0023_003Dz7FYqVoM_003D.ToString());
		}

		public bool _0023_003DzyeHNkIA_003D(_0023_003Dz3fSQ06k_003D _0023_003DzjbqS1qE_003D)
		{
			return (_0023_003DzjbqS1qE_003D._0023_003DzUYd_00240tw_003D == _0023_003DzUYd_00240tw_003D) & (_0023_003DzjbqS1qE_003D._0023_003Dz1uR5EQk_003D == _0023_003Dz1uR5EQk_003D);
		}
	}

	private sealed class _0023_003Dz64E_gingnyNO
	{
		public string _0023_003Dz2tLFTBU_003D;

		public string _0023_003DzAYWvRJA_003D;

		public string _0023_003DzECRIVYU_003D;

		public string _0023_003Dzn2xdhL0J_ARY;

		public string _0023_003DzVBdBAe7FDIWDpPGvLw_003D_003D;

		public string _0023_003Dz_1z71sNt09K7;

		public string _0023_003DzOThU2PllH_0024Ge;

		public string _0023_003DzUc_0024aHii4fiHT;

		public string _0023_003Dzd_0024kBzeg_003D;

		public _0023_003DzLL2cgQ0_003D _0023_003DzLL2cgQ0_003D;

		public bool _0023_003DzZf7gmGze_00249X9;

		public bool _0023_003DzkMjeYZDbwgvg;

		public bool _0023_003Dz2a1ZisxSVBU2;

		public int _0023_003DzxHFEkIE_003D;

		public string _0023_003Dzelho2YIEXp4oXxREWErauBw_003D;

		public string[] _0023_003Dz16az_pPmbkSo = new string[10];

		public string[] _0023_003Dz702tHHl5K_0024ot = new string[2];

		public string _0023_003DzBQ_0024C9A_0024ALep_Np5thA_003D_003D;

		public string _0023_003Dzw3nErG_0024A4f04;

		public string _0023_003Dz2WiriP8_003D;

		public string _0023_003DzOIu5sNcxtK2E;

		public string _0023_003DzP8hgGoi7BVGX;

		public string _0023_003DzPz4IFE0_003D;

		public string _0023_003DzecG31vQ_003D;

		public string _0023_003DzrAuQpI1_0024FCEU;

		public string _0023_003DztM04wvRG3luT;

		public string _0023_003Dz5pe_00241dGDezfX;

		public float[] _0023_003Dzdb_XWiY_003D = new float[3];

		public string _0023_003DzKcCkxONUkjOe;

		public _0023_003DzvW8bT_0024omzJb3rPr53A_003D_003D _0023_003DzK5N9H3Qo0fTIS3EaXA_003D_003D;

		public _0023_003Dz_afi8gY_003D _0023_003DzXeIVO7S2FlGY_Hg3uw_003D_003D;

		public _0023_003DzILN1e7bv_WZLFSFuAg_003D_003D _0023_003DzXECcuRkJyd_U;

		public int _0023_003DzwdxHnEP_c5cV;

		public float[] _0023_003DzNNLdNHE_003D = new float[3];

		public _0023_003Dz64E_gingnyNO(string _0023_003DzS_00246o7tc_003D)
		{
			_0023_003Dz2tLFTBU_003D = _0023_003DzS_00246o7tc_003D;
		}

		public _0023_003Dz64E_gingnyNO()
		{
		}
	}

	private sealed class _0023_003DzC44p11HKZacA
	{
		public delegate void _0023_003Dz2M3yg9H_46UJ(int _0023_003DzPzO_0024GUk_003D, int _0023_003Dz8dK2uhU_003D);

		private sealed class _0023_003DzuOyA7bZFNcKW
		{
			public bool _0023_003Dz2ftjAZo_003D;

			public string _0023_003Dz0bmOVLA_003D;

			public int _0023_003Dz1uR5EQk_003D;

			public int _0023_003DznN5ttMs_003D;

			public string _0023_003Dz9lcE6YI_003D;

			public int _0023_003DzXuitCzoOP1_w;
		}

		public delegate void _0023_003Dzvi5DFSHM4qYv(float _0023_003DzdgoGdiQ_003D);

		public enum letters
		{
			A,
			B,
			C,
			D,
			E,
			F,
			G,
			H,
			I,
			J,
			K,
			L,
			M,
			N,
			O,
			P,
			Q,
			R,
			S,
			T,
			U,
			V,
			W,
			X,
			Y,
			Z,
			ANY
		}

		private int[] _0023_003DzCGyigQAUD7r8 = new int[16]
		{
			-16777216, -8388608, -16744448, -8355840, -16777088, -8388480, -16744320, -4144960, -8355712, -65536,
			-16711936, -256, -16776961, -12525360, -65281, -1
		};

		private Regex _0023_003Dz66IZ6pMDZeBM;

		private Regex _0023_003DzLZCrENcM5thx;

		private _0023_003DzYVYPPCI_003D _0023_003DzQe8eSNbYVs9i;

		private float _0023_003DzD0fwfgIbEEyEad_8JQ_003D_003D;

		private int _0023_003DznwKf5XE_003D;

		private StringCollection _0023_003DzHGAGE6UTebA_0024 = new StringCollection();

		private float _0023_003DzgEXqWf0xlZDNQou2gA_003D_003D;

		private string _0023_003DzZgShS2Pe49NONEBl4g_003D_003D;

		private string _0023_003Dz8ERvYJ0hEiJSqbZH0Q_003D_003D;

		private string _0023_003Dz1k2dTG2d0NEnzzv2TA_003D_003D;

		private int _0023_003DzdbVIV_00246FfvRN;

		private string _0023_003DzljQok4_0024LPUff;

		private float _0023_003DzG8X_9L1X8OFJ;

		private float _0023_003DzvI3ntrNGc1ht;

		private float _0023_003DzEX2Yzn1X7u9N;

		private float _0023_003DzEhCPbjSxUEFl;

		private float _0023_003DzUqHZsiku2Lqh;

		private float _0023_003Dz7KCJxN3I8rSU;

		private float _0023_003DzaUWHqwI_003D;

		private float _0023_003Dz4e4UlS0_003D;

		private float _0023_003DzcUxvs7U_003D;

		private float _0023_003Dz12pqMdboiZ0k;

		private float _0023_003DzV38nvnWFozap;

		private float _0023_003Dz4AMQMQg2a5O7;

		private float _0023_003DzhSDNMqM03urE;

		private float _0023_003DzbX4BT1chxt_L;

		private float _0023_003DzHK3k8kBxuCq7;

		private float _0023_003Dzq2z8lKA8CCnZ;

		private float _0023_003Dzn6QTw5DxLz_e;

		private int _0023_003DzxwEafCVdOlzS;

		private bool _0023_003DzMhusNNUUyvPcgJDrKg_003D_003D;

		private float _0023_003DzvqE0GnVXu5jL;

		private _0023_003DzYVYPPCI_003D _0023_003DzjhoL4vTxQzUyiU_NIQ_003D_003D;

		private float _0023_003DziFKqhasXYTk_0024;

		private float _0023_003Dzj0_0024nAIs_003D;

		private float _0023_003DzSPtjGA4_003D;

		private float _0023_003Dz5nJ37AY_003D;

		private float _0023_003DzMQbgk6RJCqn5;

		private _0023_003DzYVYPPCI_003D _0023_003DzzoCVsMU_003D;

		private bool _0023_003DzXe75em8_003D;

		private string _0023_003DzL6fpvMU_003D;

		private int _0023_003DzLzYI_00242kx8t4y;

		private int _0023_003DzIfSUtGNa3D7Gslk_gA_003D_003D;

		private _0023_003DzLti7fXsWFlKZ _0023_003DzHREGA_A_003D = new _0023_003DzLti7fXsWFlKZ();

		private _0023_003Dz3fSQ06k_003D _0023_003Dzw9kQHPTBtZ24;

		private bool _0023_003DzZlh4YmvSStn8;

		private _0023_003DztxU5K3xQ8Jm7 _0023_003DzdqF9KXIGDdRr;

		private List<_0023_003DzoMakzhUSJWLx> _0023_003DzmgNuWE5X_ir0;

		private _0023_003DzoMakzhUSJWLx _0023_003Dz_OFOuIr0XJ2V;

		public _0023_003Dz64E_gingnyNO _0023_003Dz7vwMw7qCj147;

		private bool[] _0023_003Dz655_MN3PqsPc = new bool[27];

		private _0023_003Dz2M3yg9H_46UJ _0023_003Dzl_00242Ga_0024vUcFnE;

		private _0023_003Dzvi5DFSHM4qYv _0023_003DzNVSp0orHFRAA;

		private List<_0023_003DzuOyA7bZFNcKW> _0023_003DztNyr_9lrhZYDIwrz0w_003D_003D = new List<_0023_003DzuOyA7bZFNcKW>();

		private Random _0023_003DzRwuGkGzIKt6_0024 = new Random(5);

		private static _0023_003DzYVYPPCI_003D _0023_003Dz6aowVOH3q9QX2eAg1R7kC_i9KOKE;

		public void _0023_003Dzss3zqLX1s6wu(_0023_003Dz2M3yg9H_46UJ _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003Dz2M3yg9H_46UJ _0023_003Dz2M3yg9H_46UJ2 = _0023_003Dzl_00242Ga_0024vUcFnE;
			_0023_003Dz2M3yg9H_46UJ _0023_003Dz2M3yg9H_46UJ3;
			do
			{
				_0023_003Dz2M3yg9H_46UJ3 = _0023_003Dz2M3yg9H_46UJ2;
				_0023_003Dz2M3yg9H_46UJ value = (_0023_003Dz2M3yg9H_46UJ)Delegate.Combine(_0023_003Dz2M3yg9H_46UJ3, _0023_003DzPzO_0024GUk_003D);
				_0023_003Dz2M3yg9H_46UJ2 = Interlocked.CompareExchange(ref _0023_003Dzl_00242Ga_0024vUcFnE, value, _0023_003Dz2M3yg9H_46UJ3);
			}
			while ((object)_0023_003Dz2M3yg9H_46UJ2 != _0023_003Dz2M3yg9H_46UJ3);
		}

		public void _0023_003DzgNVr4WfyLxEL(_0023_003Dz2M3yg9H_46UJ _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003Dz2M3yg9H_46UJ _0023_003Dz2M3yg9H_46UJ2 = _0023_003Dzl_00242Ga_0024vUcFnE;
			_0023_003Dz2M3yg9H_46UJ _0023_003Dz2M3yg9H_46UJ3;
			do
			{
				_0023_003Dz2M3yg9H_46UJ3 = _0023_003Dz2M3yg9H_46UJ2;
				_0023_003Dz2M3yg9H_46UJ value = (_0023_003Dz2M3yg9H_46UJ)Delegate.Remove(_0023_003Dz2M3yg9H_46UJ3, _0023_003DzPzO_0024GUk_003D);
				_0023_003Dz2M3yg9H_46UJ2 = Interlocked.CompareExchange(ref _0023_003Dzl_00242Ga_0024vUcFnE, value, _0023_003Dz2M3yg9H_46UJ3);
			}
			while ((object)_0023_003Dz2M3yg9H_46UJ2 != _0023_003Dz2M3yg9H_46UJ3);
		}

		public void _0023_003DzSOgbWkAUwc3q(_0023_003Dzvi5DFSHM4qYv _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003Dzvi5DFSHM4qYv _0023_003Dzvi5DFSHM4qYv2 = _0023_003DzNVSp0orHFRAA;
			_0023_003Dzvi5DFSHM4qYv _0023_003Dzvi5DFSHM4qYv3;
			do
			{
				_0023_003Dzvi5DFSHM4qYv3 = _0023_003Dzvi5DFSHM4qYv2;
				_0023_003Dzvi5DFSHM4qYv value = (_0023_003Dzvi5DFSHM4qYv)Delegate.Combine(_0023_003Dzvi5DFSHM4qYv3, _0023_003DzPzO_0024GUk_003D);
				_0023_003Dzvi5DFSHM4qYv2 = Interlocked.CompareExchange(ref _0023_003DzNVSp0orHFRAA, value, _0023_003Dzvi5DFSHM4qYv3);
			}
			while ((object)_0023_003Dzvi5DFSHM4qYv2 != _0023_003Dzvi5DFSHM4qYv3);
		}

		public void _0023_003Dzvqddus__0024rWWb(_0023_003Dzvi5DFSHM4qYv _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003Dzvi5DFSHM4qYv _0023_003Dzvi5DFSHM4qYv2 = _0023_003DzNVSp0orHFRAA;
			_0023_003Dzvi5DFSHM4qYv _0023_003Dzvi5DFSHM4qYv3;
			do
			{
				_0023_003Dzvi5DFSHM4qYv3 = _0023_003Dzvi5DFSHM4qYv2;
				_0023_003Dzvi5DFSHM4qYv value = (_0023_003Dzvi5DFSHM4qYv)Delegate.Remove(_0023_003Dzvi5DFSHM4qYv3, _0023_003DzPzO_0024GUk_003D);
				_0023_003Dzvi5DFSHM4qYv2 = Interlocked.CompareExchange(ref _0023_003DzNVSp0orHFRAA, value, _0023_003Dzvi5DFSHM4qYv3);
			}
			while ((object)_0023_003Dzvi5DFSHM4qYv2 != _0023_003Dzvi5DFSHM4qYv3);
		}

		private void _0023_003Dzi0Zscs_0024viAGD()
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 0f;
			switch (_0023_003DzQe8eSNbYVs9i)
			{
			case (_0023_003DzYVYPPCI_003D)0:
				if (_0023_003Dz655_MN3PqsPc[17] & (_0023_003DzzoCVsMU_003D > (_0023_003DzYVYPPCI_003D)1))
				{
					num5 = (float)Math.PI / 2f;
					if (_0023_003DziFKqhasXYTk_0024 < 0f)
					{
						num5 = 0f - num5;
					}
					if ((_0023_003DzbX4BT1chxt_L == _0023_003DzV38nvnWFozap) & (_0023_003DzhSDNMqM03urE == _0023_003Dz12pqMdboiZ0k))
					{
						num5 = 0f;
					}
					_0023_003DzvI3ntrNGc1ht = Math.Abs(_0023_003DziFKqhasXYTk_0024);
					num = (float)Math.Abs(Math.Pow(_0023_003DzvI3ntrNGc1ht, 2.0) - Math.Pow(_0023_003DzximEtuur1sXu8JnDuA_003D_003D._0023_003Dz6v2QDv_9AGbc(_0023_003DzbX4BT1chxt_L, _0023_003DzhSDNMqM03urE, 0f, _0023_003DzV38nvnWFozap, _0023_003Dz12pqMdboiZ0k, 0f) / 2f, 2.0));
					num = (float)Math.Sqrt(num);
					num2 = (_0023_003DzbX4BT1chxt_L + _0023_003DzV38nvnWFozap) / 2f;
					num3 = (_0023_003DzhSDNMqM03urE + _0023_003Dz12pqMdboiZ0k) / 2f;
					if (_0023_003DzzoCVsMU_003D == (_0023_003DzYVYPPCI_003D)3)
					{
						num4 = _0023_003DzximEtuur1sXu8JnDuA_003D_003D._0023_003DzmT7CQCHQhPi0(_0023_003DzV38nvnWFozap - _0023_003DzbX4BT1chxt_L, _0023_003Dz12pqMdboiZ0k - _0023_003DzhSDNMqM03urE, _0023_003DzbU0rLpQ_003D: false) - num5;
						if (num4 < 0f)
						{
							num4 = (float)Math.PI * 2f + num4;
						}
					}
					if (_0023_003DzzoCVsMU_003D == (_0023_003DzYVYPPCI_003D)2)
					{
						num4 = _0023_003DzximEtuur1sXu8JnDuA_003D_003D._0023_003DzmT7CQCHQhPi0(_0023_003DzV38nvnWFozap - _0023_003DzbX4BT1chxt_L, _0023_003Dz12pqMdboiZ0k - _0023_003DzhSDNMqM03urE, _0023_003DzbU0rLpQ_003D: false) + num5;
						if (num4 > (float)Math.PI * 2f)
						{
							num4 -= (float)Math.PI * 2f;
						}
					}
					_0023_003DzUqHZsiku2Lqh = (float)((double)num2 - (double)num * Math.Cos(num4));
					_0023_003DzEhCPbjSxUEFl = (float)((double)num3 - (double)num * Math.Sin(num4));
					_0023_003DzG8X_9L1X8OFJ = _0023_003DzximEtuur1sXu8JnDuA_003D_003D._0023_003DzmT7CQCHQhPi0(_0023_003DzbX4BT1chxt_L - _0023_003DzUqHZsiku2Lqh, _0023_003DzhSDNMqM03urE - _0023_003DzEhCPbjSxUEFl, _0023_003DzbU0rLpQ_003D: false);
					_0023_003DzEX2Yzn1X7u9N = _0023_003DzximEtuur1sXu8JnDuA_003D_003D._0023_003DzmT7CQCHQhPi0(_0023_003DzV38nvnWFozap - _0023_003DzUqHZsiku2Lqh, _0023_003Dz12pqMdboiZ0k - _0023_003DzEhCPbjSxUEFl, _0023_003DzbU0rLpQ_003D: false);
				}
				else
				{
					if (_0023_003Dz7vwMw7qCj147._0023_003Dz2a1ZisxSVBU2)
					{
						_0023_003Dz4e4UlS0_003D -= _0023_003DzbX4BT1chxt_L;
						_0023_003DzaUWHqwI_003D -= _0023_003DzhSDNMqM03urE;
					}
					_0023_003DzvI3ntrNGc1ht = (float)Math.Sqrt(Math.Pow(_0023_003Dz4e4UlS0_003D, 2.0) + Math.Pow(_0023_003DzaUWHqwI_003D, 2.0));
					_0023_003DzUqHZsiku2Lqh = _0023_003DzbX4BT1chxt_L + _0023_003Dz4e4UlS0_003D;
					_0023_003DzEhCPbjSxUEFl = _0023_003DzhSDNMqM03urE + _0023_003DzaUWHqwI_003D;
					_0023_003Dz7KCJxN3I8rSU = _0023_003DzHK3k8kBxuCq7 + _0023_003DzcUxvs7U_003D;
					_0023_003DzG8X_9L1X8OFJ = _0023_003DzximEtuur1sXu8JnDuA_003D_003D._0023_003DzmT7CQCHQhPi0(_0023_003DzbX4BT1chxt_L - _0023_003DzUqHZsiku2Lqh, _0023_003DzhSDNMqM03urE - _0023_003DzEhCPbjSxUEFl, _0023_003DzbU0rLpQ_003D: false);
					_0023_003DzEX2Yzn1X7u9N = _0023_003DzximEtuur1sXu8JnDuA_003D_003D._0023_003DzmT7CQCHQhPi0(_0023_003DzV38nvnWFozap - _0023_003DzUqHZsiku2Lqh, _0023_003Dz12pqMdboiZ0k - _0023_003DzEhCPbjSxUEFl, _0023_003DzbU0rLpQ_003D: false);
				}
				break;
			case (_0023_003DzYVYPPCI_003D)1:
				if (_0023_003Dz655_MN3PqsPc[17] & (_0023_003DzzoCVsMU_003D > (_0023_003DzYVYPPCI_003D)1))
				{
					num5 = (float)Math.PI / 2f;
					if (_0023_003DziFKqhasXYTk_0024 < 0f)
					{
						num5 = 0f - num5;
					}
					if ((_0023_003DzbX4BT1chxt_L == _0023_003DzV38nvnWFozap) & (_0023_003DzHK3k8kBxuCq7 == _0023_003Dz4AMQMQg2a5O7))
					{
						num5 = 0f;
					}
					_0023_003DzvI3ntrNGc1ht = Math.Abs(_0023_003DziFKqhasXYTk_0024);
					num = (float)Math.Abs(Math.Pow(_0023_003DzvI3ntrNGc1ht, 2.0) - Math.Pow(_0023_003DzximEtuur1sXu8JnDuA_003D_003D._0023_003Dz6v2QDv_9AGbc(_0023_003DzbX4BT1chxt_L, _0023_003DzHK3k8kBxuCq7, 0f, _0023_003DzV38nvnWFozap, _0023_003Dz4AMQMQg2a5O7, 0f) / 2f, 2.0));
					num = (float)Math.Sqrt(num);
					num2 = (_0023_003DzbX4BT1chxt_L + _0023_003DzV38nvnWFozap) / 2f;
					num3 = (_0023_003DzHK3k8kBxuCq7 + _0023_003Dz4AMQMQg2a5O7) / 2f;
					if (_0023_003DzzoCVsMU_003D == (_0023_003DzYVYPPCI_003D)3)
					{
						num4 = _0023_003DzximEtuur1sXu8JnDuA_003D_003D._0023_003DzmT7CQCHQhPi0(_0023_003DzV38nvnWFozap - _0023_003DzbX4BT1chxt_L, _0023_003Dz4AMQMQg2a5O7 - _0023_003DzHK3k8kBxuCq7, _0023_003DzbU0rLpQ_003D: false) - num5;
						if (num4 < 0f)
						{
							num4 = (float)Math.PI * 2f + num4;
						}
					}
					if (_0023_003DzzoCVsMU_003D == (_0023_003DzYVYPPCI_003D)2)
					{
						num4 = _0023_003DzximEtuur1sXu8JnDuA_003D_003D._0023_003DzmT7CQCHQhPi0(_0023_003DzV38nvnWFozap - _0023_003DzbX4BT1chxt_L, _0023_003Dz4AMQMQg2a5O7 - _0023_003DzHK3k8kBxuCq7, _0023_003DzbU0rLpQ_003D: false) + num5;
						if (num4 > (float)Math.PI * 2f)
						{
							num4 -= (float)Math.PI * 2f;
						}
					}
					_0023_003DzUqHZsiku2Lqh = (float)((double)num2 - (double)num * Math.Cos(num4));
					_0023_003Dz7KCJxN3I8rSU = (float)((double)num3 - (double)num * Math.Sin(num4));
					_0023_003DzG8X_9L1X8OFJ = _0023_003DzximEtuur1sXu8JnDuA_003D_003D._0023_003DzmT7CQCHQhPi0(_0023_003DzbX4BT1chxt_L - _0023_003DzUqHZsiku2Lqh, _0023_003DzHK3k8kBxuCq7 - _0023_003Dz7KCJxN3I8rSU, _0023_003DzbU0rLpQ_003D: false);
					_0023_003DzEX2Yzn1X7u9N = _0023_003DzximEtuur1sXu8JnDuA_003D_003D._0023_003DzmT7CQCHQhPi0(_0023_003DzV38nvnWFozap - _0023_003DzUqHZsiku2Lqh, _0023_003Dz4AMQMQg2a5O7 - _0023_003Dz7KCJxN3I8rSU, _0023_003DzbU0rLpQ_003D: false);
				}
				else
				{
					if (_0023_003Dz7vwMw7qCj147._0023_003Dz2a1ZisxSVBU2)
					{
						_0023_003Dz4e4UlS0_003D -= _0023_003DzbX4BT1chxt_L;
						_0023_003DzcUxvs7U_003D -= _0023_003DzHK3k8kBxuCq7;
					}
					_0023_003DzvI3ntrNGc1ht = (float)Math.Sqrt(Math.Pow(_0023_003Dz4e4UlS0_003D, 2.0) + Math.Pow(_0023_003DzcUxvs7U_003D, 2.0));
					_0023_003DzUqHZsiku2Lqh = _0023_003DzbX4BT1chxt_L + _0023_003Dz4e4UlS0_003D;
					_0023_003DzEhCPbjSxUEFl = _0023_003DzhSDNMqM03urE + _0023_003DzaUWHqwI_003D;
					_0023_003Dz7KCJxN3I8rSU = _0023_003DzHK3k8kBxuCq7 + _0023_003DzcUxvs7U_003D;
					_0023_003DzG8X_9L1X8OFJ = _0023_003DzximEtuur1sXu8JnDuA_003D_003D._0023_003DzmT7CQCHQhPi0(_0023_003DzbX4BT1chxt_L - _0023_003DzUqHZsiku2Lqh, _0023_003DzHK3k8kBxuCq7 - _0023_003Dz7KCJxN3I8rSU, _0023_003DzbU0rLpQ_003D: false);
					_0023_003DzEX2Yzn1X7u9N = _0023_003DzximEtuur1sXu8JnDuA_003D_003D._0023_003DzmT7CQCHQhPi0(_0023_003DzV38nvnWFozap - _0023_003DzUqHZsiku2Lqh, _0023_003Dz4AMQMQg2a5O7 - _0023_003Dz7KCJxN3I8rSU, _0023_003DzbU0rLpQ_003D: false);
				}
				break;
			case (_0023_003DzYVYPPCI_003D)2:
				if (_0023_003Dz655_MN3PqsPc[17] & (_0023_003DzzoCVsMU_003D > (_0023_003DzYVYPPCI_003D)1))
				{
					num5 = (float)Math.PI / 2f;
					if (_0023_003DziFKqhasXYTk_0024 < 0f)
					{
						num5 = 0f - num5;
					}
					if ((_0023_003DzhSDNMqM03urE == _0023_003Dz12pqMdboiZ0k) & (_0023_003DzHK3k8kBxuCq7 == _0023_003Dz4AMQMQg2a5O7))
					{
						num5 = 0f;
					}
					_0023_003DzvI3ntrNGc1ht = Math.Abs(_0023_003DziFKqhasXYTk_0024);
					num = (float)Math.Abs(Math.Pow(_0023_003DzvI3ntrNGc1ht, 2.0) - Math.Pow(_0023_003DzximEtuur1sXu8JnDuA_003D_003D._0023_003Dz6v2QDv_9AGbc(_0023_003DzhSDNMqM03urE, _0023_003DzHK3k8kBxuCq7, 0f, _0023_003Dz12pqMdboiZ0k, _0023_003Dz4AMQMQg2a5O7, 0f) / 2f, 2.0));
					num = (float)Math.Sqrt(num);
					num2 = (_0023_003DzhSDNMqM03urE + _0023_003Dz12pqMdboiZ0k) / 2f;
					num3 = (_0023_003DzHK3k8kBxuCq7 + _0023_003Dz4AMQMQg2a5O7) / 2f;
					if (_0023_003DzzoCVsMU_003D == (_0023_003DzYVYPPCI_003D)3)
					{
						num4 = _0023_003DzximEtuur1sXu8JnDuA_003D_003D._0023_003DzmT7CQCHQhPi0(_0023_003Dz12pqMdboiZ0k - _0023_003DzhSDNMqM03urE, _0023_003Dz4AMQMQg2a5O7 - _0023_003DzHK3k8kBxuCq7, _0023_003DzbU0rLpQ_003D: false) - num5;
						if (num4 < 0f)
						{
							num4 = (float)Math.PI * 2f + num4;
						}
					}
					if (_0023_003DzzoCVsMU_003D == (_0023_003DzYVYPPCI_003D)2)
					{
						num4 = _0023_003DzximEtuur1sXu8JnDuA_003D_003D._0023_003DzmT7CQCHQhPi0(_0023_003Dz12pqMdboiZ0k - _0023_003DzhSDNMqM03urE, _0023_003Dz4AMQMQg2a5O7 - _0023_003DzHK3k8kBxuCq7, _0023_003DzbU0rLpQ_003D: false) + num5;
						if (num4 > (float)Math.PI * 2f)
						{
							num4 -= (float)Math.PI * 2f;
						}
					}
					_0023_003DzEhCPbjSxUEFl = (float)((double)num2 - (double)num * Math.Cos(num4));
					_0023_003Dz7KCJxN3I8rSU = (float)((double)num3 - (double)num * Math.Sin(num4));
					_0023_003DzG8X_9L1X8OFJ = _0023_003DzximEtuur1sXu8JnDuA_003D_003D._0023_003DzmT7CQCHQhPi0(_0023_003DzhSDNMqM03urE - _0023_003DzEhCPbjSxUEFl, _0023_003DzHK3k8kBxuCq7 - _0023_003Dz7KCJxN3I8rSU, _0023_003DzbU0rLpQ_003D: false);
					_0023_003DzEX2Yzn1X7u9N = _0023_003DzximEtuur1sXu8JnDuA_003D_003D._0023_003DzmT7CQCHQhPi0(_0023_003Dz12pqMdboiZ0k - _0023_003DzEhCPbjSxUEFl, _0023_003Dz4AMQMQg2a5O7 - _0023_003Dz7KCJxN3I8rSU, _0023_003DzbU0rLpQ_003D: false);
				}
				else
				{
					if (_0023_003Dz7vwMw7qCj147._0023_003Dz2a1ZisxSVBU2)
					{
						_0023_003DzaUWHqwI_003D -= _0023_003DzhSDNMqM03urE;
						_0023_003DzcUxvs7U_003D -= _0023_003DzHK3k8kBxuCq7;
					}
					_0023_003DzvI3ntrNGc1ht = (float)Math.Sqrt(Math.Pow(_0023_003DzaUWHqwI_003D, 2.0) + Math.Pow(_0023_003DzcUxvs7U_003D, 2.0));
					_0023_003DzUqHZsiku2Lqh = _0023_003DzbX4BT1chxt_L + _0023_003Dz4e4UlS0_003D;
					_0023_003DzEhCPbjSxUEFl = _0023_003DzhSDNMqM03urE + _0023_003DzaUWHqwI_003D;
					_0023_003Dz7KCJxN3I8rSU = _0023_003DzHK3k8kBxuCq7 + _0023_003DzcUxvs7U_003D;
					_0023_003DzG8X_9L1X8OFJ = _0023_003DzximEtuur1sXu8JnDuA_003D_003D._0023_003DzmT7CQCHQhPi0(_0023_003DzhSDNMqM03urE - _0023_003DzEhCPbjSxUEFl, _0023_003DzHK3k8kBxuCq7 - _0023_003Dz7KCJxN3I8rSU, _0023_003DzbU0rLpQ_003D: false);
					_0023_003DzEX2Yzn1X7u9N = _0023_003DzximEtuur1sXu8JnDuA_003D_003D._0023_003DzmT7CQCHQhPi0(_0023_003Dz12pqMdboiZ0k - _0023_003DzEhCPbjSxUEFl, _0023_003Dz4AMQMQg2a5O7 - _0023_003Dz7KCJxN3I8rSU, _0023_003DzbU0rLpQ_003D: false);
				}
				break;
			}
		}

		private void _0023_003Dzs_00248BHAda_6IF(IList<string> _0023_003DzQMmDdR5o0f_V)
		{
			_0023_003DzdqF9KXIGDdRr = new _0023_003DztxU5K3xQ8Jm7();
			_0023_003DzdqF9KXIGDdRr._0023_003DzlJGQisU_003D = _0023_003DzZlh4YmvSStn8;
			_0023_003DzdqF9KXIGDdRr._0023_003Dz0Ugxr7RdRfLDX6xHfw_003D_003D = (int)_0023_003DzQe8eSNbYVs9i;
			_0023_003DzdqF9KXIGDdRr._0023_003Dz8877ePc_003D = _0023_003Dz5nJ37AY_003D;
			_0023_003DzdqF9KXIGDdRr._0023_003Dz3ibXxthBA0Uu = Utility.GetRandomColor(_0023_003DzRwuGkGzIKt6_0024);
			_0023_003DzdqF9KXIGDdRr._0023_003Dzt8_7Loo0bHkF = _0023_003DzhSDNMqM03urE + _0023_003Dz7vwMw7qCj147._0023_003DzNNLdNHE_003D[1];
			_0023_003DzdqF9KXIGDdRr._0023_003DzoXnr52KfBCwO = _0023_003DzEhCPbjSxUEFl + _0023_003Dz7vwMw7qCj147._0023_003DzNNLdNHE_003D[1];
			_0023_003DzdqF9KXIGDdRr._0023_003Dz6V6sfnY0FTCS = _0023_003Dz12pqMdboiZ0k + _0023_003Dz7vwMw7qCj147._0023_003DzNNLdNHE_003D[1];
			_0023_003DzdqF9KXIGDdRr._0023_003DzAl0E1HHyrr2_0024s4zHVw_003D_003D = _0023_003DzL6fpvMU_003D;
			_0023_003DzQMmDdR5o0f_V.Add(_0023_003DzL6fpvMU_003D);
			_0023_003DzdqF9KXIGDdRr._0023_003DzpaKED88_003D = _0023_003DzzoCVsMU_003D;
			_0023_003DzdqF9KXIGDdRr._0023_003DzkWzDlmX8jN5X = _0023_003DzvqE0GnVXu5jL + _0023_003Dz7vwMw7qCj147._0023_003DzNNLdNHE_003D[2];
			_0023_003DzdqF9KXIGDdRr._0023_003DzmLdPfS23L3Qn = _0023_003DzD0fwfgIbEEyEad_8JQ_003D_003D;
			_0023_003DzdqF9KXIGDdRr._0023_003DzYqHhzKLkolNr = _0023_003DzbX4BT1chxt_L + _0023_003Dz7vwMw7qCj147._0023_003DzNNLdNHE_003D[0];
			_0023_003DzdqF9KXIGDdRr._0023_003Dzvd_0024Klif2IMz9 = _0023_003DzV38nvnWFozap + _0023_003Dz7vwMw7qCj147._0023_003DzNNLdNHE_003D[0];
			_0023_003DzdqF9KXIGDdRr._0023_003DzIPYeNoo_003D = _0023_003DzvI3ntrNGc1ht;
			_0023_003DzdqF9KXIGDdRr._0023_003Dz7BMokyu_YQCB = _0023_003DzUqHZsiku2Lqh + _0023_003Dz7vwMw7qCj147._0023_003DzNNLdNHE_003D[0];
			_0023_003DzdqF9KXIGDdRr._0023_003DzKk93HwAcNQZd = _0023_003DzHK3k8kBxuCq7 + _0023_003Dz7vwMw7qCj147._0023_003DzNNLdNHE_003D[2];
			_0023_003DzdqF9KXIGDdRr._0023_003DzIESXlCcuK6tN = _0023_003Dz4AMQMQg2a5O7 + _0023_003Dz7vwMw7qCj147._0023_003DzNNLdNHE_003D[2];
			_0023_003DzdqF9KXIGDdRr._0023_003DzevYy2NHiONCn = _0023_003Dz7KCJxN3I8rSU + _0023_003Dz7vwMw7qCj147._0023_003DzNNLdNHE_003D[2];
			_0023_003DzdqF9KXIGDdRr._0023_003Dz6dFS2Jo_003D = _0023_003DzMhusNNUUyvPcgJDrKg_003D_003D;
			_0023_003DzdqF9KXIGDdRr._0023_003DzBW1C409Qjt730k4skA_003D_003D = _0023_003Dzn6QTw5DxLz_e;
			_0023_003DzdqF9KXIGDdRr._0023_003DzA7wKTEvWrlXfg6w7BQ_003D_003D = _0023_003Dzq2z8lKA8CCnZ;
			_0023_003DzdqF9KXIGDdRr._0023_003DzK5N9H3Qo0fTIS3EaXA_003D_003D = _0023_003DzxwEafCVdOlzS;
			_0023_003DzdqF9KXIGDdRr._0023_003Dz8SPNReA_003D = _0023_003DzSPtjGA4_003D;
			_0023_003DzdqF9KXIGDdRr._0023_003Dz6wqgVzE_003D = _0023_003Dzj0_0024nAIs_003D;
			_0023_003DzdqF9KXIGDdRr._0023_003DzT4FKHOb3L3Vt = _0023_003DzG8X_9L1X8OFJ;
			_0023_003DzdqF9KXIGDdRr._0023_003Dz6Cg9P2oWT3Wd = _0023_003DzEX2Yzn1X7u9N;
			_0023_003Dz_OFOuIr0XJ2V._0023_003Dz740S2KAHIoLc.Add(_0023_003DzdqF9KXIGDdRr);
		}

		private float _0023_003DzfEfNN4s_003D(string _0023_003DznI_N5hw_003D, int _0023_003DzgyaA9s0_003D)
		{
			if (_0023_003DznI_N5hw_003D.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290)))
			{
				return Utility.FloatParse(_0023_003DznI_N5hw_003D);
			}
			return (float)((double)Utility.FloatParse(_0023_003DznI_N5hw_003D) * Math.Pow(10.0, -_0023_003DzgyaA9s0_003D));
		}

		public void _0023_003DzrF7uw_00240_003D(TextReader _0023_003DzmtnRkLzT_GrN, List<_0023_003DzoMakzhUSJWLx> _0023_003DzvsgBx5hytj4y, IList<string> _0023_003DzQMmDdR5o0f_V)
		{
			_0023_003DzmgNuWE5X_ir0 = _0023_003DzvsgBx5hytj4y;
			_0023_003DzHREGA_A_003D._0023_003DzRAqdbrtybxeh._0023_003DzebfWBK1CW3R8(_0023_003Dz7vwMw7qCj147._0023_003Dzn2xdhL0J_ARY[0]);
			_0023_003DzHREGA_A_003D._0023_003DzRAqdbrtybxeh._0023_003Dz1uR5EQk_003D = int.Parse(_0023_003Dz7vwMw7qCj147._0023_003Dzn2xdhL0J_ARY.Substring(1));
			_0023_003DzHREGA_A_003D._0023_003Dz_1z71sNt09K7._0023_003DzebfWBK1CW3R8(_0023_003Dz7vwMw7qCj147._0023_003Dz_1z71sNt09K7[0]);
			_0023_003DzHREGA_A_003D._0023_003Dz_1z71sNt09K7._0023_003Dz1uR5EQk_003D = int.Parse(_0023_003Dz7vwMw7qCj147._0023_003Dz_1z71sNt09K7.Substring(1));
			_0023_003DzHREGA_A_003D._0023_003Dz0v89Hn0_003D._0023_003DzebfWBK1CW3R8(_0023_003Dz7vwMw7qCj147._0023_003DzecG31vQ_003D[0]);
			_0023_003DzHREGA_A_003D._0023_003Dz0v89Hn0_003D._0023_003Dz1uR5EQk_003D = int.Parse(_0023_003Dz7vwMw7qCj147._0023_003DzecG31vQ_003D.Substring(1));
			_0023_003DzHREGA_A_003D._0023_003DzOIu5sNcxtK2E._0023_003DzebfWBK1CW3R8(_0023_003Dz7vwMw7qCj147._0023_003DzOIu5sNcxtK2E[0]);
			_0023_003DzHREGA_A_003D._0023_003DzOIu5sNcxtK2E._0023_003Dz1uR5EQk_003D = int.Parse(_0023_003Dz7vwMw7qCj147._0023_003DzOIu5sNcxtK2E.Substring(1));
			_0023_003DzHREGA_A_003D._0023_003DzP8hgGoi7BVGX._0023_003DzebfWBK1CW3R8(_0023_003Dz7vwMw7qCj147._0023_003DzP8hgGoi7BVGX[0]);
			_0023_003DzHREGA_A_003D._0023_003DzP8hgGoi7BVGX._0023_003Dz1uR5EQk_003D = int.Parse(_0023_003Dz7vwMw7qCj147._0023_003DzP8hgGoi7BVGX.Substring(1));
			_0023_003DzHREGA_A_003D._0023_003DzBlDrELk_003D._0023_003DzebfWBK1CW3R8(_0023_003Dz7vwMw7qCj147._0023_003DzPz4IFE0_003D[0]);
			_0023_003DzHREGA_A_003D._0023_003DzBlDrELk_003D._0023_003Dz1uR5EQk_003D = int.Parse(_0023_003Dz7vwMw7qCj147._0023_003DzPz4IFE0_003D.Substring(1));
			_0023_003DzHREGA_A_003D._0023_003Dz2WiriP8_003D._0023_003DzebfWBK1CW3R8(_0023_003Dz7vwMw7qCj147._0023_003Dz2WiriP8_003D[0]);
			_0023_003DzHREGA_A_003D._0023_003Dz2WiriP8_003D._0023_003Dz1uR5EQk_003D = int.Parse(_0023_003Dz7vwMw7qCj147._0023_003Dz2WiriP8_003D.Substring(1));
			_0023_003DzHREGA_A_003D._0023_003Dzw3nErG_0024A4f04._0023_003DzebfWBK1CW3R8(_0023_003Dz7vwMw7qCj147._0023_003Dzw3nErG_0024A4f04[0]);
			_0023_003DzHREGA_A_003D._0023_003Dzw3nErG_0024A4f04._0023_003Dz1uR5EQk_003D = int.Parse(_0023_003Dz7vwMw7qCj147._0023_003Dzw3nErG_0024A4f04.Substring(1));
			_0023_003DzHREGA_A_003D._0023_003DzKcCkxONUkjOe._0023_003DzebfWBK1CW3R8(_0023_003Dz7vwMw7qCj147._0023_003DzKcCkxONUkjOe[0]);
			_0023_003DzHREGA_A_003D._0023_003DzKcCkxONUkjOe._0023_003Dz1uR5EQk_003D = 0f;
			_0023_003DzHREGA_A_003D._0023_003DzBQ_0024C9A_0024ALep_Np5thA_003D_003D._0023_003DzebfWBK1CW3R8(_0023_003Dz7vwMw7qCj147._0023_003DzBQ_0024C9A_0024ALep_Np5thA_003D_003D[0]);
			_0023_003DzHREGA_A_003D._0023_003DzBQ_0024C9A_0024ALep_Np5thA_003D_003D._0023_003Dz1uR5EQk_003D = 0f;
			_0023_003DzHREGA_A_003D._0023_003DzXCecWa6CYPEG[0]._0023_003DzebfWBK1CW3R8(_0023_003Dz7vwMw7qCj147._0023_003DzrAuQpI1_0024FCEU[0]);
			_0023_003DzHREGA_A_003D._0023_003DzXCecWa6CYPEG[0]._0023_003Dz1uR5EQk_003D = int.Parse(_0023_003Dz7vwMw7qCj147._0023_003DzrAuQpI1_0024FCEU.Substring(1));
			_0023_003DzHREGA_A_003D._0023_003DzXCecWa6CYPEG[1]._0023_003DzebfWBK1CW3R8(_0023_003Dz7vwMw7qCj147._0023_003DztM04wvRG3luT[0]);
			_0023_003DzHREGA_A_003D._0023_003DzXCecWa6CYPEG[1]._0023_003Dz1uR5EQk_003D = int.Parse(_0023_003Dz7vwMw7qCj147._0023_003DztM04wvRG3luT.Substring(1));
			_0023_003DzHREGA_A_003D._0023_003DzXCecWa6CYPEG[2]._0023_003DzebfWBK1CW3R8(_0023_003Dz7vwMw7qCj147._0023_003Dz5pe_00241dGDezfX[0]);
			_0023_003DzHREGA_A_003D._0023_003DzXCecWa6CYPEG[2]._0023_003Dz1uR5EQk_003D = int.Parse(_0023_003Dz7vwMw7qCj147._0023_003Dz5pe_00241dGDezfX.Substring(1));
			_0023_003DzHREGA_A_003D._0023_003Dz702tHHl5K_0024ot[0]._0023_003DzebfWBK1CW3R8(_0023_003Dz7vwMw7qCj147._0023_003Dz702tHHl5K_0024ot[0][0]);
			_0023_003DzHREGA_A_003D._0023_003Dz702tHHl5K_0024ot[0]._0023_003Dz1uR5EQk_003D = int.Parse(_0023_003Dz7vwMw7qCj147._0023_003Dz702tHHl5K_0024ot[0].Substring(1));
			_0023_003DzHREGA_A_003D._0023_003Dz702tHHl5K_0024ot[1]._0023_003DzebfWBK1CW3R8(_0023_003Dz7vwMw7qCj147._0023_003Dz702tHHl5K_0024ot[1][0]);
			_0023_003DzHREGA_A_003D._0023_003Dz702tHHl5K_0024ot[1]._0023_003Dz1uR5EQk_003D = int.Parse(_0023_003Dz7vwMw7qCj147._0023_003Dz702tHHl5K_0024ot[1].Substring(1));
			for (int i = 0; i <= _0023_003DzHREGA_A_003D._0023_003Dz16az_pPmbkSo.Length - 1; i++)
			{
				if (_0023_003Dz7vwMw7qCj147._0023_003Dz16az_pPmbkSo[i].Length > 2)
				{
					_0023_003DzHREGA_A_003D._0023_003Dz16az_pPmbkSo[i]._0023_003DzebfWBK1CW3R8(_0023_003Dz7vwMw7qCj147._0023_003Dz16az_pPmbkSo[i][0]);
					_0023_003DzHREGA_A_003D._0023_003Dz16az_pPmbkSo[i]._0023_003Dz1uR5EQk_003D = int.Parse(_0023_003Dz7vwMw7qCj147._0023_003Dz16az_pPmbkSo[i].Substring(1));
				}
			}
			_0023_003DzmgNuWE5X_ir0.Clear();
			_0023_003DznwKf5XE_003D = 0;
			_0023_003DzMQbgk6RJCqn5 = -1f;
			_0023_003DzV38nvnWFozap = 0f;
			_0023_003Dz12pqMdboiZ0k = 0f;
			_0023_003Dz4AMQMQg2a5O7 = 0f;
			_0023_003DzbX4BT1chxt_L = 0f;
			_0023_003DzhSDNMqM03urE = 0f;
			_0023_003DzHK3k8kBxuCq7 = 0f;
			_0023_003Dzq2z8lKA8CCnZ = 0f;
			_0023_003Dzn6QTw5DxLz_e = 0f;
			_0023_003DzvqE0GnVXu5jL = 0f;
			_0023_003DzSPtjGA4_003D = 0f;
			_0023_003Dzj0_0024nAIs_003D = 0f;
			_0023_003DzD0fwfgIbEEyEad_8JQ_003D_003D = 0f;
			_0023_003DzgEXqWf0xlZDNQou2gA_003D_003D = 0f;
			_0023_003DzxwEafCVdOlzS = 1;
			_0023_003DzXe75em8_003D = true;
			_0023_003DzzoCVsMU_003D = (_0023_003DzYVYPPCI_003D)0;
			_0023_003DzjhoL4vTxQzUyiU_NIQ_003D_003D = (_0023_003DzYVYPPCI_003D)0;
			if (_0023_003Dz7vwMw7qCj147._0023_003DzLL2cgQ0_003D == (_0023_003DzLL2cgQ0_003D)2)
			{
				_0023_003DzQe8eSNbYVs9i = (_0023_003DzYVYPPCI_003D)0;
			}
			else
			{
				_0023_003DzQe8eSNbYVs9i = (_0023_003DzYVYPPCI_003D)1;
			}
			_0023_003DzZgShS2Pe49NONEBl4g_003D_003D = _0023_003Dz7vwMw7qCj147._0023_003DzOThU2PllH_0024Ge.Trim();
			_0023_003Dz8ERvYJ0hEiJSqbZH0Q_003D_003D = _0023_003Dz7vwMw7qCj147._0023_003Dzn2xdhL0J_ARY.Trim();
			_0023_003Dz1k2dTG2d0NEnzzv2TA_003D_003D = _0023_003Dz7vwMw7qCj147._0023_003DzVBdBAe7FDIWDpPGvLw_003D_003D.Trim();
			string text = _0023_003Dz8yg8L53AZB5N(_0023_003DzmtnRkLzT_GrN.ReadToEnd());
			_0023_003DztNyr_9lrhZYDIwrz0w_003D_003D.Clear();
			int num = -1;
			int num2 = -1;
			_0023_003DzuOyA7bZFNcKW _0023_003DzuOyA7bZFNcKW2 = null;
			foreach (Match item in _0023_003Dz66IZ6pMDZeBM.Matches(text))
			{
				if (!_0023_003Dz7vwMw7qCj147._0023_003DzECRIVYU_003D.Contains(item.Value[0].ToString()))
				{
					continue;
				}
				num2 = item.Index;
				if (num > -1)
				{
					_0023_003DztNyr_9lrhZYDIwrz0w_003D_003D[_0023_003DztNyr_9lrhZYDIwrz0w_003D_003D.Count - 1]._0023_003Dz9lcE6YI_003D = text.Substring(num, num2 - num).TrimEnd();
					if (_0023_003DztNyr_9lrhZYDIwrz0w_003D_003D[_0023_003DztNyr_9lrhZYDIwrz0w_003D_003D.Count - 1]._0023_003Dz9lcE6YI_003D.Contains(_0023_003Dz7vwMw7qCj147._0023_003DzOThU2PllH_0024Ge))
					{
						_0023_003DztNyr_9lrhZYDIwrz0w_003D_003D[_0023_003DztNyr_9lrhZYDIwrz0w_003D_003D.Count - 1]._0023_003Dz2ftjAZo_003D = true;
					}
				}
				_0023_003DzuOyA7bZFNcKW2 = new _0023_003DzuOyA7bZFNcKW();
				_0023_003DzuOyA7bZFNcKW2._0023_003Dz2ftjAZo_003D = false;
				_0023_003DzuOyA7bZFNcKW2._0023_003DznN5ttMs_003D = num2;
				_0023_003DzuOyA7bZFNcKW2._0023_003Dz0bmOVLA_003D = char.ToUpper(item.Value[0]).ToString();
				_0023_003DzuOyA7bZFNcKW2._0023_003Dz1uR5EQk_003D = int.Parse(item.Groups[1].Value);
				_0023_003DztNyr_9lrhZYDIwrz0w_003D_003D.Add(_0023_003DzuOyA7bZFNcKW2);
				num = item.Index;
			}
			_0023_003DzLzYI_00242kx8t4y = 1;
			if (_0023_003DztNyr_9lrhZYDIwrz0w_003D_003D.Count == 0)
			{
				_0023_003DzuOyA7bZFNcKW2 = new _0023_003DzuOyA7bZFNcKW();
				_0023_003DzuOyA7bZFNcKW2._0023_003Dz2ftjAZo_003D = true;
				_0023_003DzuOyA7bZFNcKW2._0023_003DznN5ttMs_003D = 0;
				_0023_003DzuOyA7bZFNcKW2._0023_003Dz0bmOVLA_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004218);
				_0023_003DzuOyA7bZFNcKW2._0023_003Dz1uR5EQk_003D = 0;
				_0023_003DzuOyA7bZFNcKW2._0023_003Dz9lcE6YI_003D = text;
				_0023_003DztNyr_9lrhZYDIwrz0w_003D_003D.Add(_0023_003DzuOyA7bZFNcKW2);
				_0023_003DzIfSUtGNa3D7Gslk_gA_003D_003D = text.Length;
				_0023_003DzkK8HfSyRXUXi(_0023_003DzuOyA7bZFNcKW2, _0023_003DzQMmDdR5o0f_V);
				return;
			}
			_0023_003DztNyr_9lrhZYDIwrz0w_003D_003D[_0023_003DztNyr_9lrhZYDIwrz0w_003D_003D.Count - 1]._0023_003Dz9lcE6YI_003D = text.Substring(num).TrimEnd();
			if (_0023_003DztNyr_9lrhZYDIwrz0w_003D_003D[_0023_003DztNyr_9lrhZYDIwrz0w_003D_003D.Count - 1]._0023_003Dz9lcE6YI_003D.Contains(_0023_003Dz7vwMw7qCj147._0023_003DzOThU2PllH_0024Ge))
			{
				_0023_003DztNyr_9lrhZYDIwrz0w_003D_003D[_0023_003DztNyr_9lrhZYDIwrz0w_003D_003D.Count - 1]._0023_003Dz2ftjAZo_003D = true;
			}
			foreach (_0023_003DzuOyA7bZFNcKW item2 in _0023_003DztNyr_9lrhZYDIwrz0w_003D_003D)
			{
				_0023_003DzIfSUtGNa3D7Gslk_gA_003D_003D = item2._0023_003Dz9lcE6YI_003D.Length;
				_0023_003DzkK8HfSyRXUXi(item2, _0023_003DzQMmDdR5o0f_V);
			}
		}

		private _0023_003DzuOyA7bZFNcKW _0023_003DzRqWoMN5r4cP3(int _0023_003DzXULhp_00248_003D)
		{
			foreach (_0023_003DzuOyA7bZFNcKW item in _0023_003DztNyr_9lrhZYDIwrz0w_003D_003D)
			{
				if (item._0023_003Dz1uR5EQk_003D == _0023_003DzXULhp_00248_003D)
				{
					return item;
				}
			}
			return null;
		}

		private void _0023_003DzkK8HfSyRXUXi(_0023_003DzuOyA7bZFNcKW _0023_003DzB68dg9Q_003D, IList<string> _0023_003DzQMmDdR5o0f_V)
		{
			_0023_003DzB68dg9Q_003D._0023_003DzXuitCzoOP1_w++;
			int num = 0;
			foreach (Match item in _0023_003DzLZCrENcM5thx.Matches(_0023_003DzB68dg9Q_003D._0023_003Dz9lcE6YI_003D))
			{
				if (item.Value == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302915165))
				{
					_0023_003DzLzYI_00242kx8t4y++;
					_0023_003DzL6fpvMU_003D = _0023_003DzB68dg9Q_003D._0023_003Dz9lcE6YI_003D.Substring(num, item.Index - num - 1);
					_0023_003DzIXrKtO1ZDkMmXHCf2A_003D_003D(_0023_003DzQMmDdR5o0f_V);
					if (_0023_003Dzl_00242Ga_0024vUcFnE != null)
					{
						_0023_003Dzl_00242Ga_0024vUcFnE(item.Index, _0023_003DzIfSUtGNa3D7Gslk_gA_003D_003D);
					}
					Array.Clear(_0023_003Dz655_MN3PqsPc, 0, 27);
					num = item.Index + 1;
					continue;
				}
				if (_0023_003DzyPKf40kXnIaL(item))
				{
					_0023_003DzLzYI_00242kx8t4y += item.Value.Split('\n').Length - 1;
					continue;
				}
				if (_0023_003Dz7vwMw7qCj147._0023_003DzUc_0024aHii4fiHT.Contains(item.Value[0].ToString()))
				{
					_0023_003DzLzYI_00242kx8t4y++;
					continue;
				}
				_0023_003Dzw9kQHPTBtZ24._0023_003DzebfWBK1CW3R8(char.ToUpper(item.Value[0]));
				_0023_003Dzw9kQHPTBtZ24._0023_003Dz1wTaPJQ_003D = item.Groups[1].Value;
				if (!string.IsNullOrEmpty(_0023_003Dzw9kQHPTBtZ24._0023_003Dz1wTaPJQ_003D))
				{
					_0023_003Dzw9kQHPTBtZ24._0023_003Dz1uR5EQk_003D = Utility.FloatParse(item.Groups[1].Value);
				}
				if (_0023_003Dzw9kQHPTBtZ24._0023_003DzyeHNkIA_003D(_0023_003DzHREGA_A_003D._0023_003DzRAqdbrtybxeh))
				{
					_0023_003DzuOyA7bZFNcKW _0023_003DzuOyA7bZFNcKW2 = _0023_003DzRqWoMN5r4cP3(int.Parse(item.NextMatch().Groups[1].Value));
					if (_0023_003DzuOyA7bZFNcKW2 != null)
					{
						if (_0023_003DzuOyA7bZFNcKW2._0023_003DzXuitCzoOP1_w > 100)
						{
							break;
						}
						_0023_003DzkK8HfSyRXUXi(_0023_003DzuOyA7bZFNcKW2, _0023_003DzQMmDdR5o0f_V);
					}
				}
				else
				{
					_0023_003DzNO_0024_0024l2m5sMMx();
				}
			}
		}

		private void _0023_003DzIXrKtO1ZDkMmXHCf2A_003D_003D(IList<string> _0023_003DzQMmDdR5o0f_V)
		{
			if (!_0023_003Dz655_MN3PqsPc[26])
			{
				return;
			}
			if (_0023_003Dz655_MN3PqsPc[23])
			{
				if (!_0023_003DzXe75em8_003D)
				{
					_0023_003DzV38nvnWFozap += _0023_003DzbX4BT1chxt_L;
				}
				if (_0023_003Dz7vwMw7qCj147._0023_003DzLL2cgQ0_003D == (_0023_003DzLL2cgQ0_003D)0)
				{
					_0023_003DzV38nvnWFozap /= 2f;
				}
			}
			if (_0023_003Dz655_MN3PqsPc[24] && !_0023_003DzXe75em8_003D)
			{
				_0023_003Dz12pqMdboiZ0k += _0023_003DzhSDNMqM03urE;
			}
			if (_0023_003Dz655_MN3PqsPc[25] && !_0023_003DzXe75em8_003D)
			{
				_0023_003Dz4AMQMQg2a5O7 += _0023_003DzHK3k8kBxuCq7;
			}
			if (_0023_003Dz655_MN3PqsPc[(int)_0023_003DzHREGA_A_003D._0023_003DzKcCkxONUkjOe._0023_003DzUYd_00240tw_003D])
			{
				_0023_003DzMhusNNUUyvPcgJDrKg_003D_003D = true;
				if (_0023_003Dz7vwMw7qCj147._0023_003DzXECcuRkJyd_U == (_0023_003DzILN1e7bv_WZLFSFuAg_003D_003D)0)
				{
					if (!_0023_003DzXe75em8_003D)
					{
						_0023_003Dzn6QTw5DxLz_e += _0023_003Dzq2z8lKA8CCnZ;
					}
				}
				else if (!_0023_003DzXe75em8_003D)
				{
					_0023_003DzxwEafCVdOlzS = Math.Sign(_0023_003Dzn6QTw5DxLz_e);
					_0023_003Dzn6QTw5DxLz_e += _0023_003Dzq2z8lKA8CCnZ;
				}
				else
				{
					if ((double)Math.Abs(_0023_003Dzn6QTw5DxLz_e % ((float)Math.PI * 2f)) > Math.PI && (double)Math.Abs(_0023_003Dzq2z8lKA8CCnZ % ((float)Math.PI * 2f)) < Math.PI)
					{
						_0023_003Dzq2z8lKA8CCnZ += (float)Math.PI * 2f;
					}
					else if ((double)Math.Abs(_0023_003Dzn6QTw5DxLz_e % ((float)Math.PI * 2f)) < Math.PI && (double)Math.Abs(_0023_003Dzq2z8lKA8CCnZ % ((float)Math.PI * 2f)) > Math.PI)
					{
						_0023_003Dzq2z8lKA8CCnZ -= (float)Math.PI * 2f;
					}
					if (_0023_003Dzn6QTw5DxLz_e < _0023_003Dzq2z8lKA8CCnZ)
					{
						_0023_003DzxwEafCVdOlzS = -1;
					}
					else
					{
						_0023_003DzxwEafCVdOlzS = 1;
					}
				}
			}
			if (_0023_003DzzoCVsMU_003D == (_0023_003DzYVYPPCI_003D)2)
			{
				_0023_003Dzi0Zscs_0024viAGD();
				if (_0023_003DzG8X_9L1X8OFJ <= _0023_003DzEX2Yzn1X7u9N)
				{
					_0023_003DzG8X_9L1X8OFJ += (float)Math.PI * 2f;
				}
				if ((_0023_003DzcUxvs7U_003D > 0f) & (_0023_003DzQe8eSNbYVs9i == (_0023_003DzYVYPPCI_003D)0))
				{
					if (_0023_003DzG8X_9L1X8OFJ == _0023_003DzEX2Yzn1X7u9N)
					{
						_0023_003Dz4AMQMQg2a5O7 += _0023_003DzcUxvs7U_003D;
					}
					else
					{
						_0023_003Dz4AMQMQg2a5O7 += _0023_003DzcUxvs7U_003D * Math.Abs(_0023_003DzG8X_9L1X8OFJ - _0023_003DzEX2Yzn1X7u9N) / ((float)Math.PI * 2f);
					}
				}
			}
			if (_0023_003DzzoCVsMU_003D == (_0023_003DzYVYPPCI_003D)3)
			{
				_0023_003Dzi0Zscs_0024viAGD();
				if (_0023_003DzEX2Yzn1X7u9N <= _0023_003DzG8X_9L1X8OFJ)
				{
					_0023_003DzEX2Yzn1X7u9N += (float)Math.PI * 2f;
				}
				if ((_0023_003DzcUxvs7U_003D > 0f) & (_0023_003DzQe8eSNbYVs9i == (_0023_003DzYVYPPCI_003D)0))
				{
					if (_0023_003DzG8X_9L1X8OFJ == _0023_003DzEX2Yzn1X7u9N)
					{
						_0023_003Dz4AMQMQg2a5O7 += _0023_003DzcUxvs7U_003D;
					}
					else
					{
						_0023_003Dz4AMQMQg2a5O7 += _0023_003DzcUxvs7U_003D * Math.Abs(_0023_003DzG8X_9L1X8OFJ - _0023_003DzEX2Yzn1X7u9N) / ((float)Math.PI * 2f);
					}
				}
			}
			if (_0023_003DzMQbgk6RJCqn5 != _0023_003Dz5nJ37AY_003D)
			{
				_0023_003Dz_OFOuIr0XJ2V = new _0023_003DzoMakzhUSJWLx(_0023_003Dz5nJ37AY_003D);
				_0023_003DzmgNuWE5X_ir0.Add(_0023_003Dz_OFOuIr0XJ2V);
				_0023_003DzZlh4YmvSStn8 = true;
				if (_0023_003DznwKf5XE_003D == 0)
				{
					_0023_003DznwKf5XE_003D = 9;
				}
				_0023_003DznwKf5XE_003D++;
				if (_0023_003DznwKf5XE_003D > 15)
				{
					_0023_003DznwKf5XE_003D = 1;
				}
				if (_0023_003DzNVSp0orHFRAA != null)
				{
					_0023_003DzNVSp0orHFRAA(_0023_003Dz5nJ37AY_003D);
				}
			}
			if (((_0023_003Dz6aowVOH3q9QX2eAg1R7kC_i9KOKE == (_0023_003DzYVYPPCI_003D)0) & (_0023_003DzzoCVsMU_003D > (_0023_003DzYVYPPCI_003D)0)) | ((_0023_003Dz6aowVOH3q9QX2eAg1R7kC_i9KOKE > (_0023_003DzYVYPPCI_003D)0) & (_0023_003DzzoCVsMU_003D == (_0023_003DzYVYPPCI_003D)0)))
			{
				_0023_003DzZlh4YmvSStn8 = true;
			}
			if (_0023_003DzzoCVsMU_003D > (_0023_003DzYVYPPCI_003D)0)
			{
				_0023_003DzgEXqWf0xlZDNQou2gA_003D_003D = _0023_003Dz4AMQMQg2a5O7;
			}
			_0023_003Dzs_00248BHAda_6IF(_0023_003DzQMmDdR5o0f_V);
			_0023_003Dz6aowVOH3q9QX2eAg1R7kC_i9KOKE = (_0023_003DzYVYPPCI_003D)0;
			_0023_003DzMQbgk6RJCqn5 = _0023_003Dz5nJ37AY_003D;
			_0023_003DzMhusNNUUyvPcgJDrKg_003D_003D = false;
			_0023_003Dzq2z8lKA8CCnZ = _0023_003Dzn6QTw5DxLz_e;
			_0023_003Dz4e4UlS0_003D = 0f;
			_0023_003DzaUWHqwI_003D = 0f;
			_0023_003DzcUxvs7U_003D = 0f;
			_0023_003DzbX4BT1chxt_L = _0023_003DzV38nvnWFozap;
			_0023_003DzhSDNMqM03urE = _0023_003Dz12pqMdboiZ0k;
			_0023_003DzHK3k8kBxuCq7 = _0023_003Dz4AMQMQg2a5O7;
		}

		private void _0023_003DzNO_0024_0024l2m5sMMx()
		{
			if (string.IsNullOrEmpty(_0023_003Dzw9kQHPTBtZ24._0023_003Dz1wTaPJQ_003D))
			{
				return;
			}
			int num = 0;
			_0023_003Dz655_MN3PqsPc[(int)_0023_003Dzw9kQHPTBtZ24._0023_003DzUYd_00240tw_003D] = true;
			switch (_0023_003Dzw9kQHPTBtZ24._0023_003DzUYd_00240tw_003D)
			{
			case letters.X:
				_0023_003Dz655_MN3PqsPc[26] = true;
				_0023_003DzV38nvnWFozap = _0023_003DzfEfNN4s_003D(_0023_003Dzw9kQHPTBtZ24._0023_003Dz1wTaPJQ_003D, _0023_003Dz7vwMw7qCj147._0023_003DzxHFEkIE_003D);
				return;
			case letters.Y:
				_0023_003Dz655_MN3PqsPc[26] = true;
				_0023_003Dz12pqMdboiZ0k = _0023_003DzfEfNN4s_003D(_0023_003Dzw9kQHPTBtZ24._0023_003Dz1wTaPJQ_003D, _0023_003Dz7vwMw7qCj147._0023_003DzxHFEkIE_003D);
				return;
			case letters.Z:
				_0023_003Dz655_MN3PqsPc[26] = true;
				_0023_003Dz4AMQMQg2a5O7 = _0023_003DzfEfNN4s_003D(_0023_003Dzw9kQHPTBtZ24._0023_003Dz1wTaPJQ_003D, _0023_003Dz7vwMw7qCj147._0023_003DzxHFEkIE_003D);
				return;
			case letters.I:
				_0023_003Dz655_MN3PqsPc[26] = true;
				_0023_003Dz4e4UlS0_003D = _0023_003DzfEfNN4s_003D(_0023_003Dzw9kQHPTBtZ24._0023_003Dz1wTaPJQ_003D, _0023_003Dz7vwMw7qCj147._0023_003DzxHFEkIE_003D);
				if (_0023_003Dz7vwMw7qCj147._0023_003DzLL2cgQ0_003D == (_0023_003DzLL2cgQ0_003D)0 && _0023_003Dz7vwMw7qCj147._0023_003Dz2a1ZisxSVBU2)
				{
					_0023_003Dz4e4UlS0_003D /= 2f;
				}
				return;
			case letters.J:
				_0023_003Dz655_MN3PqsPc[26] = true;
				_0023_003DzaUWHqwI_003D = _0023_003DzfEfNN4s_003D(_0023_003Dzw9kQHPTBtZ24._0023_003Dz1wTaPJQ_003D, _0023_003Dz7vwMw7qCj147._0023_003DzxHFEkIE_003D);
				return;
			case letters.K:
				_0023_003Dz655_MN3PqsPc[26] = true;
				_0023_003DzcUxvs7U_003D = _0023_003DzfEfNN4s_003D(_0023_003Dzw9kQHPTBtZ24._0023_003Dz1wTaPJQ_003D, _0023_003Dz7vwMw7qCj147._0023_003DzxHFEkIE_003D);
				return;
			case letters.R:
				_0023_003Dz655_MN3PqsPc[26] = true;
				_0023_003DzvqE0GnVXu5jL = _0023_003DzfEfNN4s_003D(_0023_003Dzw9kQHPTBtZ24._0023_003Dz1wTaPJQ_003D, _0023_003Dz7vwMw7qCj147._0023_003DzxHFEkIE_003D);
				_0023_003DziFKqhasXYTk_0024 = _0023_003DzvqE0GnVXu5jL;
				return;
			case letters.S:
				_0023_003Dz655_MN3PqsPc[26] = true;
				_0023_003DzSPtjGA4_003D = _0023_003Dzw9kQHPTBtZ24._0023_003Dz1uR5EQk_003D;
				return;
			case letters.F:
				_0023_003Dz655_MN3PqsPc[26] = true;
				_0023_003Dzj0_0024nAIs_003D = _0023_003Dzw9kQHPTBtZ24._0023_003Dz1uR5EQk_003D;
				return;
			case letters.T:
				_0023_003Dz655_MN3PqsPc[26] = true;
				_0023_003Dz5nJ37AY_003D = _0023_003Dzw9kQHPTBtZ24._0023_003Dz1uR5EQk_003D;
				return;
			}
			if (_0023_003Dz655_MN3PqsPc[(int)_0023_003DzHREGA_A_003D._0023_003DzKcCkxONUkjOe._0023_003DzUYd_00240tw_003D])
			{
				_0023_003Dz655_MN3PqsPc[26] = true;
				_0023_003Dzn6QTw5DxLz_e = (float)Utility.DegToRad(_0023_003DzfEfNN4s_003D(_0023_003Dzw9kQHPTBtZ24._0023_003Dz1wTaPJQ_003D, _0023_003Dz7vwMw7qCj147._0023_003DzwdxHnEP_c5cV));
				if (_0023_003Dzw9kQHPTBtZ24._0023_003Dz1wTaPJQ_003D.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302915752)))
				{
					_0023_003DzxwEafCVdOlzS = -1;
				}
				return;
			}
			if (_0023_003Dzw9kQHPTBtZ24._0023_003DzyeHNkIA_003D(_0023_003DzHREGA_A_003D._0023_003Dz0v89Hn0_003D))
			{
				_0023_003Dz655_MN3PqsPc[26] = true;
				_0023_003DzXe75em8_003D = true;
				return;
			}
			if (_0023_003Dzw9kQHPTBtZ24._0023_003DzyeHNkIA_003D(_0023_003DzHREGA_A_003D._0023_003DzBlDrELk_003D))
			{
				_0023_003Dz655_MN3PqsPc[26] = true;
				_0023_003DzXe75em8_003D = false;
				return;
			}
			if (_0023_003Dzw9kQHPTBtZ24._0023_003DzyeHNkIA_003D(_0023_003DzHREGA_A_003D._0023_003Dzw3nErG_0024A4f04))
			{
				_0023_003Dz655_MN3PqsPc[26] = true;
				_0023_003DzzoCVsMU_003D = (_0023_003DzYVYPPCI_003D)0;
				return;
			}
			if (_0023_003Dzw9kQHPTBtZ24._0023_003DzyeHNkIA_003D(_0023_003DzHREGA_A_003D._0023_003Dz2WiriP8_003D))
			{
				_0023_003Dz655_MN3PqsPc[26] = true;
				_0023_003DzzoCVsMU_003D = (_0023_003DzYVYPPCI_003D)1;
				return;
			}
			if (_0023_003Dzw9kQHPTBtZ24._0023_003DzyeHNkIA_003D(_0023_003DzHREGA_A_003D._0023_003DzP8hgGoi7BVGX))
			{
				_0023_003Dz655_MN3PqsPc[26] = true;
				if (_0023_003DzQe8eSNbYVs9i == (_0023_003DzYVYPPCI_003D)1)
				{
					_0023_003DzzoCVsMU_003D = (_0023_003DzYVYPPCI_003D)3;
				}
				else
				{
					_0023_003DzzoCVsMU_003D = (_0023_003DzYVYPPCI_003D)2;
				}
				return;
			}
			if (_0023_003Dzw9kQHPTBtZ24._0023_003DzyeHNkIA_003D(_0023_003DzHREGA_A_003D._0023_003DzOIu5sNcxtK2E))
			{
				_0023_003Dz655_MN3PqsPc[26] = true;
				if (_0023_003DzQe8eSNbYVs9i == (_0023_003DzYVYPPCI_003D)1)
				{
					_0023_003DzzoCVsMU_003D = (_0023_003DzYVYPPCI_003D)2;
				}
				else
				{
					_0023_003DzzoCVsMU_003D = (_0023_003DzYVYPPCI_003D)3;
				}
				return;
			}
			if (_0023_003Dzw9kQHPTBtZ24._0023_003DzyeHNkIA_003D(_0023_003DzHREGA_A_003D._0023_003Dz16az_pPmbkSo[0]))
			{
				_0023_003Dz655_MN3PqsPc[26] = true;
				_0023_003DzzoCVsMU_003D = (_0023_003DzYVYPPCI_003D)0;
				if (_0023_003DzjhoL4vTxQzUyiU_NIQ_003D_003D == (_0023_003DzYVYPPCI_003D)0)
				{
					_0023_003Dz4AMQMQg2a5O7 = _0023_003DzgEXqWf0xlZDNQou2gA_003D_003D;
				}
				else
				{
					_0023_003Dz4AMQMQg2a5O7 = _0023_003DzvqE0GnVXu5jL;
				}
				return;
			}
			if (_0023_003Dzw9kQHPTBtZ24._0023_003DzyeHNkIA_003D(_0023_003DzHREGA_A_003D._0023_003Dz702tHHl5K_0024ot[0]))
			{
				_0023_003Dz655_MN3PqsPc[26] = true;
				_0023_003DzjhoL4vTxQzUyiU_NIQ_003D_003D = (_0023_003DzYVYPPCI_003D)0;
				if (_0023_003DzzoCVsMU_003D > (_0023_003DzYVYPPCI_003D)3)
				{
					_0023_003DzzoCVsMU_003D = 4 + _0023_003DzjhoL4vTxQzUyiU_NIQ_003D_003D;
				}
				return;
			}
			if (_0023_003Dzw9kQHPTBtZ24._0023_003DzyeHNkIA_003D(_0023_003DzHREGA_A_003D._0023_003Dz702tHHl5K_0024ot[1]))
			{
				_0023_003Dz655_MN3PqsPc[26] = true;
				_0023_003DzjhoL4vTxQzUyiU_NIQ_003D_003D = (_0023_003DzYVYPPCI_003D)1;
				if (_0023_003DzzoCVsMU_003D > (_0023_003DzYVYPPCI_003D)3)
				{
					_0023_003DzzoCVsMU_003D = 4 + _0023_003DzjhoL4vTxQzUyiU_NIQ_003D_003D;
				}
				return;
			}
			if (_0023_003Dzw9kQHPTBtZ24._0023_003DzyeHNkIA_003D(_0023_003DzHREGA_A_003D._0023_003DzXCecWa6CYPEG[0]))
			{
				_0023_003Dz655_MN3PqsPc[26] = true;
				_0023_003DzQe8eSNbYVs9i = (_0023_003DzYVYPPCI_003D)0;
				return;
			}
			if (_0023_003Dzw9kQHPTBtZ24._0023_003DzyeHNkIA_003D(_0023_003DzHREGA_A_003D._0023_003DzXCecWa6CYPEG[1]))
			{
				_0023_003Dz655_MN3PqsPc[26] = true;
				_0023_003DzQe8eSNbYVs9i = (_0023_003DzYVYPPCI_003D)1;
				return;
			}
			if (_0023_003Dzw9kQHPTBtZ24._0023_003DzyeHNkIA_003D(_0023_003DzHREGA_A_003D._0023_003DzXCecWa6CYPEG[2]))
			{
				_0023_003DzQe8eSNbYVs9i = (_0023_003DzYVYPPCI_003D)2;
				_0023_003Dz655_MN3PqsPc[26] = true;
				return;
			}
			for (num = 1; num <= _0023_003DzHREGA_A_003D._0023_003Dz16az_pPmbkSo.Length - 1; num++)
			{
				if (_0023_003DzHREGA_A_003D._0023_003Dz16az_pPmbkSo[num]._0023_003Dz1uR5EQk_003D != 0f && _0023_003Dzw9kQHPTBtZ24._0023_003DzyeHNkIA_003D(_0023_003DzHREGA_A_003D._0023_003Dz16az_pPmbkSo[num]))
				{
					_0023_003DzzoCVsMU_003D = 4 + _0023_003DzjhoL4vTxQzUyiU_NIQ_003D_003D;
					if (_0023_003DzzoCVsMU_003D == (_0023_003DzYVYPPCI_003D)4)
					{
						_0023_003DzD0fwfgIbEEyEad_8JQ_003D_003D = _0023_003DzgEXqWf0xlZDNQou2gA_003D_003D;
					}
					if (_0023_003DzzoCVsMU_003D == (_0023_003DzYVYPPCI_003D)5)
					{
						_0023_003DzD0fwfgIbEEyEad_8JQ_003D_003D = _0023_003DzvqE0GnVXu5jL;
					}
					_0023_003Dz655_MN3PqsPc[26] = true;
					break;
				}
			}
		}

		internal bool _0023_003DzyPKf40kXnIaL(Match _0023_003DzkKfJheA_003D)
		{
			return _0023_003DzkKfJheA_003D.Groups[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302934159)].Success;
		}

		public void _0023_003DztGdcVOA_003D(_0023_003Dz64E_gingnyNO _0023_003DzoavOZPlc9daH)
		{
			_0023_003Dz7vwMw7qCj147 = _0023_003DzoavOZPlc9daH;
			if (_0023_003DzoavOZPlc9daH != null)
			{
				string text = string.Empty;
				char[] array = _0023_003Dz7vwMw7qCj147._0023_003DzUc_0024aHii4fiHT.ToCharArray();
				foreach (char c in array)
				{
					text += Regex.Escape(c.ToString());
				}
				_0023_003DzA4Q5mCiMMyY_0024();
				_0023_003DzLZCrENcM5thx = new Regex(_0023_003DzrzW9r_U1XUHJ_Tiqpg_003D_003D() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004195) + text + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004203), RegexOptions.IgnoreCase | RegexOptions.Compiled);
				string text2 = Regex.Escape(_0023_003Dz7vwMw7qCj147._0023_003DzECRIVYU_003D);
				_0023_003Dz66IZ6pMDZeBM = new Regex(_0023_003DzrzW9r_U1XUHJ_Tiqpg_003D_003D() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004195) + text2 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004411), RegexOptions.Compiled);
			}
		}

		private string _0023_003DzrzW9r_U1XUHJ_Tiqpg_003D_003D()
		{
			if (_0023_003DzljQok4_0024LPUff.Length > 0)
			{
				return _0023_003DzljQok4_0024LPUff + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942697);
			}
			return string.Empty;
		}

		private void _0023_003DzA4Q5mCiMMyY_0024()
		{
			string text = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004395);
			_0023_003DzljQok4_0024LPUff = string.Empty;
			string _0023_003Dzd_0024kBzeg_003D = _0023_003Dz7vwMw7qCj147._0023_003Dzd_0024kBzeg_003D;
			if (_0023_003Dzd_0024kBzeg_003D.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004374)) | _0023_003Dzd_0024kBzeg_003D.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004384)))
			{
				_0023_003DzljQok4_0024LPUff = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004359);
			}
			if (_0023_003Dzd_0024kBzeg_003D.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004346)))
			{
				if (_0023_003DzljQok4_0024LPUff.Length > 0)
				{
					_0023_003DzljQok4_0024LPUff += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942697);
				}
				_0023_003DzljQok4_0024LPUff += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004321);
			}
			if (_0023_003Dzd_0024kBzeg_003D.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909691)))
			{
				if (_0023_003DzljQok4_0024LPUff.Length > 0)
				{
					_0023_003DzljQok4_0024LPUff += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942697);
				}
				_0023_003DzljQok4_0024LPUff += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004306);
			}
			if (_0023_003Dzd_0024kBzeg_003D.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966001)))
			{
				if (_0023_003DzljQok4_0024LPUff.Length > 0)
				{
					_0023_003DzljQok4_0024LPUff += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942697);
				}
				_0023_003DzljQok4_0024LPUff += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004290);
			}
			if (_0023_003Dzd_0024kBzeg_003D.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005042)))
			{
				if (_0023_003DzljQok4_0024LPUff.Length > 0)
				{
					_0023_003DzljQok4_0024LPUff += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942697);
				}
				_0023_003DzljQok4_0024LPUff += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005049);
			}
			if (_0023_003Dzd_0024kBzeg_003D.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966581)))
			{
				if (_0023_003DzljQok4_0024LPUff.Length > 0)
				{
					_0023_003DzljQok4_0024LPUff += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942697);
				}
				_0023_003DzljQok4_0024LPUff = _0023_003DzljQok4_0024LPUff + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005030) + text;
			}
			if (_0023_003Dzd_0024kBzeg_003D.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302926862)))
			{
				if (_0023_003DzljQok4_0024LPUff.Length > 0)
				{
					_0023_003DzljQok4_0024LPUff += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942697);
				}
				_0023_003DzljQok4_0024LPUff = _0023_003DzljQok4_0024LPUff + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005040) + text;
			}
			if (_0023_003Dzd_0024kBzeg_003D.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907930)))
			{
				if (_0023_003DzljQok4_0024LPUff.Length > 0)
				{
					_0023_003DzljQok4_0024LPUff += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942697);
				}
				_0023_003DzljQok4_0024LPUff = _0023_003DzljQok4_0024LPUff + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005018) + text;
			}
			if (_0023_003DzljQok4_0024LPUff.Length > 0)
			{
				_0023_003DzljQok4_0024LPUff = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004996) + _0023_003DzljQok4_0024LPUff + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091);
			}
		}

		public string _0023_003Dz8yg8L53AZB5N(string _0023_003DzuDxC7P0_003D)
		{
			return Regex.Replace(_0023_003DzuDxC7P0_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004982), string.Empty, RegexOptions.Compiled);
		}

		private Color _0023_003Dz7RYGXJw_003D(int _0023_003Dz437_00244ak_003D)
		{
			return Color.FromArgb(_0023_003DzCGyigQAUD7r8[_0023_003Dz437_00244ak_003D]);
		}
	}

	private enum _0023_003DzILN1e7bv_WZLFSFuAg_003D_003D
	{

	}

	private enum _0023_003DzLL2cgQ0_003D
	{

	}

	private sealed class _0023_003DzLti7fXsWFlKZ
	{
		public _0023_003Dz3fSQ06k_003D[] _0023_003Dz16az_pPmbkSo = new _0023_003Dz3fSQ06k_003D[10];

		public _0023_003Dz3fSQ06k_003D[] _0023_003Dz702tHHl5K_0024ot = new _0023_003Dz3fSQ06k_003D[2];

		public _0023_003Dz3fSQ06k_003D _0023_003DzBQ_0024C9A_0024ALep_Np5thA_003D_003D;

		public _0023_003Dz3fSQ06k_003D _0023_003Dzw3nErG_0024A4f04;

		public _0023_003Dz3fSQ06k_003D _0023_003Dz2WiriP8_003D;

		public _0023_003Dz3fSQ06k_003D _0023_003DzOIu5sNcxtK2E;

		public _0023_003Dz3fSQ06k_003D _0023_003DzP8hgGoi7BVGX;

		public _0023_003Dz3fSQ06k_003D _0023_003DzBlDrELk_003D;

		public _0023_003Dz3fSQ06k_003D _0023_003Dz0v89Hn0_003D;

		public _0023_003Dz3fSQ06k_003D[] _0023_003DzXCecWa6CYPEG = new _0023_003Dz3fSQ06k_003D[3];

		public _0023_003Dz3fSQ06k_003D _0023_003DzKcCkxONUkjOe;

		public _0023_003Dz3fSQ06k_003D _0023_003DzRAqdbrtybxeh;

		public _0023_003Dz3fSQ06k_003D _0023_003Dz_1z71sNt09K7;
	}

	private enum _0023_003DzYVYPPCI_003D
	{

	}

	private enum _0023_003Dz_afi8gY_003D
	{

	}

	private sealed class _0023_003DzoMakzhUSJWLx
	{
		public float _0023_003Dz8877ePc_003D;

		public List<_0023_003DztxU5K3xQ8Jm7> _0023_003Dz740S2KAHIoLc;

		public _0023_003DzoMakzhUSJWLx(float _0023_003DzdgoGdiQ_003D)
		{
			_0023_003Dz8877ePc_003D = _0023_003DzdgoGdiQ_003D;
			_0023_003Dz740S2KAHIoLc = new List<_0023_003DztxU5K3xQ8Jm7>();
		}
	}

	private sealed class _0023_003DztxU5K3xQ8Jm7
	{
		public string _0023_003DzAl0E1HHyrr2_0024s4zHVw_003D_003D;

		public _0023_003DzYVYPPCI_003D _0023_003DzpaKED88_003D;

		public int _0023_003DzjQ0BQGlfn3hC7JSquQ_003D_003D;

		public float _0023_003DzYqHhzKLkolNr;

		public float _0023_003Dzt8_7Loo0bHkF;

		public float _0023_003DzKk93HwAcNQZd;

		public float _0023_003Dzvd_0024Klif2IMz9;

		public float _0023_003Dz6V6sfnY0FTCS;

		public float _0023_003DzIESXlCcuK6tN;

		public float _0023_003DzkWzDlmX8jN5X;

		public float _0023_003DzIPYeNoo_003D;

		public float _0023_003DzT4FKHOb3L3Vt;

		public float _0023_003Dz6Cg9P2oWT3Wd;

		public float _0023_003Dz7BMokyu_YQCB;

		public float _0023_003DzoXnr52KfBCwO;

		public float _0023_003DzevYy2NHiONCn;

		public Color _0023_003Dz3ibXxthBA0Uu;

		public float _0023_003Dz8877ePc_003D;

		public float _0023_003Dz8SPNReA_003D;

		public float _0023_003Dz6wqgVzE_003D;

		public bool _0023_003DzlJGQisU_003D;

		public bool _0023_003Dz6dFS2Jo_003D;

		public float _0023_003DzA7wKTEvWrlXfg6w7BQ_003D_003D;

		public float _0023_003DzBW1C409Qjt730k4skA_003D_003D;

		public int _0023_003DzK5N9H3Qo0fTIS3EaXA_003D_003D;

		public int _0023_003Dz0Ugxr7RdRfLDX6xHfw_003D_003D;

		public float _0023_003DzmLdPfS23L3Qn;

		public bool _0023_003DzY7Yl1_ajQLHL;
	}

	private enum _0023_003DzvW8bT_0024omzJb3rPr53A_003D_003D
	{

	}

	private sealed class _0023_003DzximEtuur1sXu8JnDuA_003D_003D
	{
		public static float _0023_003Dz6v2QDv_9AGbc(float _0023_003DzXyvs_uA_003D, float _0023_003Dzzsuixt4_003D, float _0023_003DzCDfHxb8_003D, float _0023_003DzRFb1SGo_003D, float _0023_003Dz8qV981c_003D, float _0023_003DzAu2sxoQ_003D)
		{
			return (float)Math.Sqrt(Math.Pow(_0023_003DzXyvs_uA_003D - _0023_003DzRFb1SGo_003D, 2.0) + Math.Pow(_0023_003Dzzsuixt4_003D - _0023_003Dz8qV981c_003D, 2.0) + Math.Pow(_0023_003DzCDfHxb8_003D - _0023_003DzAu2sxoQ_003D, 2.0));
		}

		public static float _0023_003DzmT7CQCHQhPi0(float _0023_003DzBJFJHwk_003D, float _0023_003Dz40R7bAU_003D, bool _0023_003DzbU0rLpQ_003D)
		{
			float num = 0f;
			if (_0023_003DzBJFJHwk_003D > 0f && _0023_003Dz40R7bAU_003D > 0f)
			{
				num = (float)Math.Atan(_0023_003Dz40R7bAU_003D / _0023_003DzBJFJHwk_003D);
			}
			else if (_0023_003DzBJFJHwk_003D < 0f && _0023_003Dz40R7bAU_003D > 0f)
			{
				num = (float)(Math.Atan(_0023_003Dz40R7bAU_003D / _0023_003DzBJFJHwk_003D) + Math.PI);
			}
			else if (_0023_003DzBJFJHwk_003D < 0f && _0023_003Dz40R7bAU_003D < 0f)
			{
				num = (float)(Math.Atan(_0023_003Dz40R7bAU_003D / _0023_003DzBJFJHwk_003D) + Math.PI);
			}
			else if (_0023_003DzBJFJHwk_003D > 0f && _0023_003Dz40R7bAU_003D < 0f)
			{
				num = (float)(Math.Atan(_0023_003Dz40R7bAU_003D / _0023_003DzBJFJHwk_003D) + Math.PI * 2.0);
			}
			if (_0023_003DzBJFJHwk_003D > 0f && _0023_003Dz40R7bAU_003D == 0f)
			{
				num = 0f;
			}
			else if (_0023_003DzBJFJHwk_003D == 0f && _0023_003Dz40R7bAU_003D > 0f)
			{
				num = (float)Math.PI / 2f;
			}
			else if (_0023_003DzBJFJHwk_003D < 0f && _0023_003Dz40R7bAU_003D == 0f)
			{
				num = (float)Math.PI;
			}
			else if (_0023_003DzBJFJHwk_003D == 0f && _0023_003Dz40R7bAU_003D < 0f)
			{
				num = 4.712389f;
			}
			if (_0023_003DzbU0rLpQ_003D)
			{
				num = (float)((double)num * (180.0 / Math.PI));
			}
			return num;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dzng4DxJPaZunH;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003Dz1g4Hn6j2QFrc _0023_003Dz9xZrKUE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<string> _0023_003Dz_0024_ydENQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly float _0023_003DzSHdX3HLnpOCc_yxScQ_003D_003D = 2f;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static float _0023_003DzAlvBzwurHvj0 = (float)Math.PI / 8f;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private motionType _0023_003Dz1BPEjBg_003D;

	public override supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.Unitless;

	public new string[] Blocks => _0023_003Dz_0024_ydENQ_003D.ToArray();

	[Description("Sets the quality of arcs. >=16 AND <=720")]
	[Category("Custom")]
	[DefaultValue(16)]
	private static int _0023_003DzbSw6tNJHLQDR
	{
		set
		{
			if (value < 16)
			{
				value = 16;
			}
			if (value > 720)
			{
				value = 720;
			}
			_0023_003DzAlvBzwurHvj0 = (float)Math.PI * 2f / (float)value;
		}
	}

	public ReadGCode(string filePath, bool dogLeg = true)
		: base(filePath)
	{
		_0023_003Dzng4DxJPaZunH = dogLeg;
	}

	public ReadGCode(Stream stream, bool dogLeg = true)
		: base(stream)
	{
		_0023_003Dzng4DxJPaZunH = dogLeg;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "%fQD,q\"ac>", array);
		_0023_003DzxhnITtwVskwf(progress, ct);
	}

	private void _0023_003DzxhnITtwVskwf(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		bool result = false;
		try
		{
			_0023_003Dz_0024_ydENQ_003D = new List<string>();
			List<Entity> list = new List<Entity>();
			_0023_003DzC44p11HKZacA obj = new _0023_003DzC44p11HKZacA();
			_0023_003Dz9xZrKUE_003D = new _0023_003Dz1g4Hn6j2QFrc();
			_0023_003Dz9xZrKUE_003D._0023_003Dz7NU3mw3_ywOc();
			obj._0023_003DztGdcVOA_003D(_0023_003Dz9xZrKUE_003D._0023_003Dz_MS_Clw_003D);
			List<_0023_003DzoMakzhUSJWLx> list2 = new List<_0023_003DzoMakzhUSJWLx>();
			obj._0023_003DzrF7uw_00240_003D(new StreamReader(base.Stream), list2, _0023_003Dz_0024_ydENQ_003D);
			bool flag = false;
			int count = list2.Count;
			for (int i = 0; i < count; i++)
			{
				_0023_003DzoMakzhUSJWLx _0023_003DzoMakzhUSJWLx2 = list2[i];
				Entity entity = _0023_003Dzj1kOY6upI79aBy22Dg_003D_003D(_0023_003DzoMakzhUSJWLx2._0023_003Dz740S2KAHIoLc);
				if (entity != null)
				{
					entity.EntityData = _0023_003DzoMakzhUSJWLx2._0023_003Dz8877ePc_003D;
					list.Add(entity);
				}
				if (!UpdateProgressAndCheckCancelled(i, count, base.ParsingText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				base.Entities.AddRange(list);
				result = true;
			}
		}
		catch (Exception ex)
		{
			log.AppendLine(ex.Message);
			log.AppendLine();
		}
		finally
		{
			CloseStream();
		}
		base.Result = result;
	}

	private Entity _0023_003Dzj1kOY6upI79aBy22Dg_003D_003D(List<_0023_003DztxU5K3xQ8Jm7> _0023_003DzzF0HA1IaMpzg)
	{
		Entity entity = null;
		List<Toolpath.Motion> list = new List<Toolpath.Motion>(_0023_003DzzF0HA1IaMpzg.Count);
		foreach (_0023_003DztxU5K3xQ8Jm7 item in _0023_003DzzF0HA1IaMpzg)
		{
			ICurve curve = _0023_003DzOQ3_dlK_0024B66Z(item);
			if (curve is Line line)
			{
				list.Add(new Toolpath.LinearMotion(line.StartPoint, line.EndPoint, _0023_003DzgfKn3ZI_003D(item), item._0023_003Dz8SPNReA_003D, item._0023_003Dz6wqgVzE_003D, item._0023_003DzAl0E1HHyrr2_0024s4zHVw_003D_003D));
			}
			else if (curve is Arc arc)
			{
				Toolpath.CircularMotion circularMotion = new Toolpath.CircularMotion(arc.Plane, arc.Radius, arc.Domain, _0023_003DzgfKn3ZI_003D(item), item._0023_003Dz8SPNReA_003D, item._0023_003Dz6wqgVzE_003D, item._0023_003DzAl0E1HHyrr2_0024s4zHVw_003D_003D);
				if (arc.EntityData != null)
				{
					circularMotion.Depth = Convert.ToDouble(arc.EntityData);
				}
				list.Add(circularMotion);
			}
			else if (curve is LinearPath linearPath)
			{
				for (int i = 0; i < linearPath.Vertices.Length - 1; i++)
				{
					Point3D point3D = linearPath.Vertices[i].Clone() as Point3D;
					Point3D to = linearPath.Vertices[i + 1];
					list.Add(new Toolpath.LinearMotion(point3D, to, _0023_003DzgfKn3ZI_003D(item), item._0023_003Dz8SPNReA_003D, item._0023_003Dz6wqgVzE_003D, item._0023_003DzAl0E1HHyrr2_0024s4zHVw_003D_003D));
				}
			}
		}
		Toolpath toolpath = new Toolpath(list, (int)_0023_003DzzF0HA1IaMpzg[0]._0023_003Dz8877ePc_003D);
		if (list.Count > 0)
		{
			entity = toolpath;
		}
		if (entity != null)
		{
			entity.ColorMethod = colorMethodType.byEntity;
			entity.Color = _0023_003DzzF0HA1IaMpzg[0]._0023_003Dz3ibXxthBA0Uu;
		}
		return entity;
	}

	private motionType _0023_003DzgfKn3ZI_003D(_0023_003DztxU5K3xQ8Jm7 _0023_003DzFAH4xII_003D)
	{
		int num = _0023_003DzIxX_0024Lbs_003D(_0023_003DzFAH4xII_003D._0023_003DzAl0E1HHyrr2_0024s4zHVw_003D_003D);
		motionType result = _0023_003Dz1BPEjBg_003D;
		switch (num)
		{
		case 0:
			result = motionType.G00;
			break;
		case 1:
			result = motionType.G01;
			break;
		case 2:
			result = motionType.G02;
			break;
		case 3:
			result = motionType.G03;
			break;
		case 81:
			result = motionType.G81;
			break;
		case 82:
			result = motionType.G82;
			break;
		case 83:
			result = motionType.G83;
			break;
		case 84:
			result = motionType.G84;
			break;
		}
		_0023_003Dz1BPEjBg_003D = result;
		return result;
	}

	private int _0023_003DzIxX_0024Lbs_003D(string _0023_003Dz8FGsy5FejU6Ss4ng3A_003D_003D)
	{
		string[] array = _0023_003Dz8FGsy5FejU6Ss4ng3A_003D_003D.Split(' ');
		foreach (string text in array)
		{
			if (!text.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911374)))
			{
				continue;
			}
			int num = 0;
			for (int j = 1; j < text.Length; j++)
			{
				if (!char.IsDigit(text[j]))
				{
					num = j - 1;
					break;
				}
			}
			if (num == 0)
			{
				num = text.Length - 1;
			}
			int num2 = int.Parse(text.Substring(1, num));
			if (num2 == 0 || num2 == 1 || num2 == 2 || num2 == 3 || num2 == 81 || num2 == 82 || num2 == 83 || num2 == 84)
			{
				return num2;
			}
		}
		return -1;
	}

	private ICurve _0023_003DzOQ3_dlK_0024B66Z(_0023_003DztxU5K3xQ8Jm7 _0023_003DzdoW7ToAWvN60)
	{
		if (_0023_003DzdoW7ToAWvN60._0023_003DzpaKED88_003D == (_0023_003DzYVYPPCI_003D)0 && _0023_003DzdoW7ToAWvN60._0023_003DzYqHhzKLkolNr == _0023_003DzdoW7ToAWvN60._0023_003Dzvd_0024Klif2IMz9 && _0023_003DzdoW7ToAWvN60._0023_003Dzt8_7Loo0bHkF == _0023_003DzdoW7ToAWvN60._0023_003Dz6V6sfnY0FTCS && _0023_003DzdoW7ToAWvN60._0023_003DzKk93HwAcNQZd == _0023_003DzdoW7ToAWvN60._0023_003DzIESXlCcuK6tN)
		{
			return null;
		}
		ICurve curve = null;
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		float num7 = 0f;
		float num8 = 0f;
		float num9 = 0f;
		float num10 = 0f;
		float num11 = 0f;
		float num12 = 0f;
		switch (_0023_003DzdoW7ToAWvN60._0023_003DzpaKED88_003D)
		{
		case (_0023_003DzYVYPPCI_003D)0:
			if (_0023_003DzdoW7ToAWvN60._0023_003Dz6dFS2Jo_003D)
			{
				curve = _0023_003Dzpn7WFKHEwMZbhBBA_0024UNACNw_003D(_0023_003DzdoW7ToAWvN60._0023_003Dzvd_0024Klif2IMz9, _0023_003DzdoW7ToAWvN60._0023_003DzYqHhzKLkolNr, _0023_003DzdoW7ToAWvN60._0023_003Dz6V6sfnY0FTCS, _0023_003DzdoW7ToAWvN60._0023_003Dzt8_7Loo0bHkF, _0023_003DzdoW7ToAWvN60._0023_003DzIESXlCcuK6tN, _0023_003DzdoW7ToAWvN60._0023_003DzKk93HwAcNQZd, _0023_003DzdoW7ToAWvN60._0023_003DzA7wKTEvWrlXfg6w7BQ_003D_003D, _0023_003DzdoW7ToAWvN60._0023_003DzBW1C409Qjt730k4skA_003D_003D, _0023_003DzdoW7ToAWvN60._0023_003DzK5N9H3Qo0fTIS3EaXA_003D_003D, _0023_003DzdoW7ToAWvN60._0023_003DzAl0E1HHyrr2_0024s4zHVw_003D_003D);
			}
			else if (_0023_003Dzng4DxJPaZunH)
			{
				num4 = Math.Sign(_0023_003DzdoW7ToAWvN60._0023_003Dzvd_0024Klif2IMz9 - _0023_003DzdoW7ToAWvN60._0023_003DzYqHhzKLkolNr);
				num5 = Math.Sign(_0023_003DzdoW7ToAWvN60._0023_003Dz6V6sfnY0FTCS - _0023_003DzdoW7ToAWvN60._0023_003Dzt8_7Loo0bHkF);
				num6 = Math.Sign(_0023_003DzdoW7ToAWvN60._0023_003DzIESXlCcuK6tN - _0023_003DzdoW7ToAWvN60._0023_003DzKk93HwAcNQZd);
				num = Math.Abs(_0023_003DzdoW7ToAWvN60._0023_003Dzvd_0024Klif2IMz9 - _0023_003DzdoW7ToAWvN60._0023_003DzYqHhzKLkolNr);
				num2 = Math.Abs(_0023_003DzdoW7ToAWvN60._0023_003Dz6V6sfnY0FTCS - _0023_003DzdoW7ToAWvN60._0023_003Dzt8_7Loo0bHkF);
				num3 = Math.Abs(_0023_003DzdoW7ToAWvN60._0023_003DzIESXlCcuK6tN - _0023_003DzdoW7ToAWvN60._0023_003DzKk93HwAcNQZd);
				if (num <= num2 && num2 <= num3)
				{
					num7 = _0023_003DzdoW7ToAWvN60._0023_003Dzvd_0024Klif2IMz9;
					num8 = _0023_003DzdoW7ToAWvN60._0023_003Dzt8_7Loo0bHkF + num * (float)num5;
					num9 = _0023_003DzdoW7ToAWvN60._0023_003DzKk93HwAcNQZd + num * (float)num6;
					num10 = _0023_003DzdoW7ToAWvN60._0023_003Dzvd_0024Klif2IMz9;
					num11 = _0023_003DzdoW7ToAWvN60._0023_003Dz6V6sfnY0FTCS;
					num12 = _0023_003DzdoW7ToAWvN60._0023_003DzKk93HwAcNQZd + num2 * (float)num6;
				}
				else if (num <= num3 && num3 <= num2)
				{
					num7 = _0023_003DzdoW7ToAWvN60._0023_003Dzvd_0024Klif2IMz9;
					num8 = _0023_003DzdoW7ToAWvN60._0023_003Dzt8_7Loo0bHkF + num * (float)num5;
					num9 = _0023_003DzdoW7ToAWvN60._0023_003DzKk93HwAcNQZd + num * (float)num6;
					num10 = _0023_003DzdoW7ToAWvN60._0023_003Dzvd_0024Klif2IMz9;
					num11 = _0023_003DzdoW7ToAWvN60._0023_003Dzt8_7Loo0bHkF + num3 * (float)num5;
					num12 = _0023_003DzdoW7ToAWvN60._0023_003DzIESXlCcuK6tN;
				}
				else if (num3 <= num2 && num2 <= num)
				{
					num7 = _0023_003DzdoW7ToAWvN60._0023_003DzYqHhzKLkolNr + num3 * (float)num4;
					num8 = _0023_003DzdoW7ToAWvN60._0023_003Dzt8_7Loo0bHkF + num3 * (float)num5;
					num9 = _0023_003DzdoW7ToAWvN60._0023_003DzIESXlCcuK6tN;
					num10 = _0023_003DzdoW7ToAWvN60._0023_003DzYqHhzKLkolNr + num2 * (float)num4;
					num11 = _0023_003DzdoW7ToAWvN60._0023_003Dz6V6sfnY0FTCS;
					num12 = _0023_003DzdoW7ToAWvN60._0023_003DzIESXlCcuK6tN;
				}
				else if (num3 <= num && num <= num2)
				{
					num7 = _0023_003DzdoW7ToAWvN60._0023_003DzYqHhzKLkolNr + num3 * (float)num4;
					num8 = _0023_003DzdoW7ToAWvN60._0023_003Dzt8_7Loo0bHkF + num3 * (float)num5;
					num9 = _0023_003DzdoW7ToAWvN60._0023_003DzIESXlCcuK6tN;
					num10 = _0023_003DzdoW7ToAWvN60._0023_003Dzvd_0024Klif2IMz9;
					num11 = _0023_003DzdoW7ToAWvN60._0023_003Dzt8_7Loo0bHkF + num * (float)num5;
					num12 = _0023_003DzdoW7ToAWvN60._0023_003DzIESXlCcuK6tN;
				}
				else if (num2 <= num3 && num3 <= num)
				{
					num7 = _0023_003DzdoW7ToAWvN60._0023_003DzYqHhzKLkolNr + num2 * (float)num4;
					num8 = _0023_003DzdoW7ToAWvN60._0023_003Dz6V6sfnY0FTCS;
					num9 = _0023_003DzdoW7ToAWvN60._0023_003DzKk93HwAcNQZd + num2 * (float)num6;
					num10 = _0023_003DzdoW7ToAWvN60._0023_003DzYqHhzKLkolNr + num3 * (float)num4;
					num11 = _0023_003DzdoW7ToAWvN60._0023_003Dz6V6sfnY0FTCS;
					num12 = _0023_003DzdoW7ToAWvN60._0023_003DzIESXlCcuK6tN;
				}
				else if (num2 <= num && num <= num3)
				{
					num7 = _0023_003DzdoW7ToAWvN60._0023_003DzYqHhzKLkolNr + num2 * (float)num4;
					num8 = _0023_003DzdoW7ToAWvN60._0023_003Dz6V6sfnY0FTCS;
					num9 = _0023_003DzdoW7ToAWvN60._0023_003DzKk93HwAcNQZd + num2 * (float)num6;
					num10 = _0023_003DzdoW7ToAWvN60._0023_003Dzvd_0024Klif2IMz9;
					num11 = _0023_003DzdoW7ToAWvN60._0023_003Dz6V6sfnY0FTCS;
					num12 = _0023_003DzdoW7ToAWvN60._0023_003DzKk93HwAcNQZd + num * (float)num6;
				}
				curve = new LinearPath(new Point3D(_0023_003DzdoW7ToAWvN60._0023_003DzYqHhzKLkolNr, _0023_003DzdoW7ToAWvN60._0023_003Dzt8_7Loo0bHkF, _0023_003DzdoW7ToAWvN60._0023_003DzKk93HwAcNQZd), new Point3D(num7, num8, num9), new Point3D(num10, num11, num12), new Point3D(_0023_003DzdoW7ToAWvN60._0023_003Dzvd_0024Klif2IMz9, _0023_003DzdoW7ToAWvN60._0023_003Dz6V6sfnY0FTCS, _0023_003DzdoW7ToAWvN60._0023_003DzIESXlCcuK6tN));
			}
			else
			{
				curve = new Line(new Point3D(_0023_003DzdoW7ToAWvN60._0023_003DzYqHhzKLkolNr, _0023_003DzdoW7ToAWvN60._0023_003Dzt8_7Loo0bHkF, _0023_003DzdoW7ToAWvN60._0023_003DzKk93HwAcNQZd), new Point3D(_0023_003DzdoW7ToAWvN60._0023_003Dzvd_0024Klif2IMz9, _0023_003DzdoW7ToAWvN60._0023_003Dz6V6sfnY0FTCS, _0023_003DzdoW7ToAWvN60._0023_003DzIESXlCcuK6tN));
			}
			break;
		case (_0023_003DzYVYPPCI_003D)4:
		case (_0023_003DzYVYPPCI_003D)5:
		{
			List<Point3D> list = new List<Point3D>();
			num4 = Math.Sign(_0023_003DzdoW7ToAWvN60._0023_003Dzvd_0024Klif2IMz9 - _0023_003DzdoW7ToAWvN60._0023_003DzYqHhzKLkolNr);
			num5 = Math.Sign(_0023_003DzdoW7ToAWvN60._0023_003Dz6V6sfnY0FTCS - _0023_003DzdoW7ToAWvN60._0023_003Dzt8_7Loo0bHkF);
			num = Math.Abs(_0023_003DzdoW7ToAWvN60._0023_003Dzvd_0024Klif2IMz9 - _0023_003DzdoW7ToAWvN60._0023_003DzYqHhzKLkolNr);
			num2 = Math.Abs(_0023_003DzdoW7ToAWvN60._0023_003Dz6V6sfnY0FTCS - _0023_003DzdoW7ToAWvN60._0023_003Dzt8_7Loo0bHkF);
			if (_0023_003DzdoW7ToAWvN60._0023_003Dz6dFS2Jo_003D)
			{
				LinearPath linearPath = ((_0023_003DzdoW7ToAWvN60._0023_003DzpaKED88_003D != (_0023_003DzYVYPPCI_003D)4) ? ((LinearPath)_0023_003Dzpn7WFKHEwMZbhBBA_0024UNACNw_003D(_0023_003DzdoW7ToAWvN60._0023_003Dzvd_0024Klif2IMz9, _0023_003DzdoW7ToAWvN60._0023_003DzYqHhzKLkolNr, _0023_003DzdoW7ToAWvN60._0023_003Dz6V6sfnY0FTCS, _0023_003DzdoW7ToAWvN60._0023_003Dzt8_7Loo0bHkF, _0023_003DzdoW7ToAWvN60._0023_003DzkWzDlmX8jN5X, _0023_003DzdoW7ToAWvN60._0023_003DzkWzDlmX8jN5X, _0023_003DzdoW7ToAWvN60._0023_003DzA7wKTEvWrlXfg6w7BQ_003D_003D, _0023_003DzdoW7ToAWvN60._0023_003DzBW1C409Qjt730k4skA_003D_003D, _0023_003DzdoW7ToAWvN60._0023_003DzK5N9H3Qo0fTIS3EaXA_003D_003D, _0023_003DzdoW7ToAWvN60._0023_003DzAl0E1HHyrr2_0024s4zHVw_003D_003D)) : ((LinearPath)_0023_003Dzpn7WFKHEwMZbhBBA_0024UNACNw_003D(_0023_003DzdoW7ToAWvN60._0023_003Dzvd_0024Klif2IMz9, _0023_003DzdoW7ToAWvN60._0023_003DzYqHhzKLkolNr, _0023_003DzdoW7ToAWvN60._0023_003Dz6V6sfnY0FTCS, _0023_003DzdoW7ToAWvN60._0023_003Dzt8_7Loo0bHkF, _0023_003DzdoW7ToAWvN60._0023_003DzmLdPfS23L3Qn, _0023_003DzdoW7ToAWvN60._0023_003DzmLdPfS23L3Qn, _0023_003DzdoW7ToAWvN60._0023_003DzA7wKTEvWrlXfg6w7BQ_003D_003D, _0023_003DzdoW7ToAWvN60._0023_003DzBW1C409Qjt730k4skA_003D_003D, _0023_003DzdoW7ToAWvN60._0023_003DzK5N9H3Qo0fTIS3EaXA_003D_003D, _0023_003DzdoW7ToAWvN60._0023_003DzAl0E1HHyrr2_0024s4zHVw_003D_003D)));
				list.AddRange(linearPath.Vertices);
				list.Add(new Point3D(_0023_003DzdoW7ToAWvN60._0023_003Dzvd_0024Klif2IMz9, _0023_003DzdoW7ToAWvN60._0023_003Dz6V6sfnY0FTCS, _0023_003DzdoW7ToAWvN60._0023_003DzkWzDlmX8jN5X));
			}
			else
			{
				if (num <= num2)
				{
					num7 = _0023_003DzdoW7ToAWvN60._0023_003DzYqHhzKLkolNr + num * (float)num4;
					num8 = _0023_003DzdoW7ToAWvN60._0023_003Dzt8_7Loo0bHkF + num * (float)num5;
				}
				if (num >= num2)
				{
					num7 = _0023_003DzdoW7ToAWvN60._0023_003DzYqHhzKLkolNr + num2 * (float)num4;
					num8 = _0023_003DzdoW7ToAWvN60._0023_003Dzt8_7Loo0bHkF + num2 * (float)num5;
				}
				if (_0023_003DzdoW7ToAWvN60._0023_003DzpaKED88_003D == (_0023_003DzYVYPPCI_003D)4)
				{
					list.Add(new Point3D(_0023_003DzdoW7ToAWvN60._0023_003DzYqHhzKLkolNr, _0023_003DzdoW7ToAWvN60._0023_003Dzt8_7Loo0bHkF, _0023_003DzdoW7ToAWvN60._0023_003DzmLdPfS23L3Qn));
					list.Add(new Point3D(num7, num8, _0023_003DzdoW7ToAWvN60._0023_003DzmLdPfS23L3Qn));
					list.Add(new Point3D(_0023_003DzdoW7ToAWvN60._0023_003Dzvd_0024Klif2IMz9, _0023_003DzdoW7ToAWvN60._0023_003Dz6V6sfnY0FTCS, _0023_003DzdoW7ToAWvN60._0023_003DzmLdPfS23L3Qn));
					list.Add(new Point3D(_0023_003DzdoW7ToAWvN60._0023_003Dzvd_0024Klif2IMz9, _0023_003DzdoW7ToAWvN60._0023_003Dz6V6sfnY0FTCS, _0023_003DzdoW7ToAWvN60._0023_003DzkWzDlmX8jN5X));
				}
				else
				{
					list.Add(new Point3D(_0023_003DzdoW7ToAWvN60._0023_003DzYqHhzKLkolNr, _0023_003DzdoW7ToAWvN60._0023_003Dzt8_7Loo0bHkF, _0023_003DzdoW7ToAWvN60._0023_003DzKk93HwAcNQZd));
					list.Add(new Point3D(_0023_003DzdoW7ToAWvN60._0023_003DzYqHhzKLkolNr, _0023_003DzdoW7ToAWvN60._0023_003Dzt8_7Loo0bHkF, _0023_003DzdoW7ToAWvN60._0023_003DzkWzDlmX8jN5X));
					list.Add(new Point3D(num7, num8, _0023_003DzdoW7ToAWvN60._0023_003DzkWzDlmX8jN5X));
					list.Add(new Point3D(_0023_003DzdoW7ToAWvN60._0023_003Dzvd_0024Klif2IMz9, _0023_003DzdoW7ToAWvN60._0023_003Dz6V6sfnY0FTCS, _0023_003DzdoW7ToAWvN60._0023_003DzkWzDlmX8jN5X));
				}
			}
			list.Add(new Point3D(_0023_003DzdoW7ToAWvN60._0023_003Dzvd_0024Klif2IMz9, _0023_003DzdoW7ToAWvN60._0023_003Dz6V6sfnY0FTCS, _0023_003DzdoW7ToAWvN60._0023_003DzIESXlCcuK6tN));
			curve = new LinearPath(list);
			break;
		}
		case (_0023_003DzYVYPPCI_003D)1:
			curve = ((!_0023_003DzdoW7ToAWvN60._0023_003Dz6dFS2Jo_003D) ? new Line(new Point3D(_0023_003DzdoW7ToAWvN60._0023_003DzYqHhzKLkolNr, _0023_003DzdoW7ToAWvN60._0023_003Dzt8_7Loo0bHkF, _0023_003DzdoW7ToAWvN60._0023_003DzKk93HwAcNQZd), new Point3D(_0023_003DzdoW7ToAWvN60._0023_003Dzvd_0024Klif2IMz9, _0023_003DzdoW7ToAWvN60._0023_003Dz6V6sfnY0FTCS, _0023_003DzdoW7ToAWvN60._0023_003DzIESXlCcuK6tN)) : _0023_003Dzpn7WFKHEwMZbhBBA_0024UNACNw_003D(_0023_003DzdoW7ToAWvN60._0023_003Dzvd_0024Klif2IMz9, _0023_003DzdoW7ToAWvN60._0023_003DzYqHhzKLkolNr, _0023_003DzdoW7ToAWvN60._0023_003Dz6V6sfnY0FTCS, _0023_003DzdoW7ToAWvN60._0023_003Dzt8_7Loo0bHkF, _0023_003DzdoW7ToAWvN60._0023_003DzIESXlCcuK6tN, _0023_003DzdoW7ToAWvN60._0023_003DzKk93HwAcNQZd, _0023_003DzdoW7ToAWvN60._0023_003DzA7wKTEvWrlXfg6w7BQ_003D_003D, _0023_003DzdoW7ToAWvN60._0023_003DzBW1C409Qjt730k4skA_003D_003D, _0023_003DzdoW7ToAWvN60._0023_003DzK5N9H3Qo0fTIS3EaXA_003D_003D, _0023_003DzdoW7ToAWvN60._0023_003DzAl0E1HHyrr2_0024s4zHVw_003D_003D));
			break;
		case (_0023_003DzYVYPPCI_003D)3:
			_0023_003DzbSw6tNJHLQDR = (int)(_0023_003DzdoW7ToAWvN60._0023_003DzIPYeNoo_003D / _0023_003DzSHdX3HLnpOCc_yxScQ_003D_003D * 360f);
			curve = _0023_003DzTbn8pkAZSxbZbOq_bA_003D_003D(_0023_003DzdoW7ToAWvN60._0023_003Dz7BMokyu_YQCB, _0023_003DzdoW7ToAWvN60._0023_003DzoXnr52KfBCwO, _0023_003DzdoW7ToAWvN60._0023_003DzevYy2NHiONCn, _0023_003DzdoW7ToAWvN60._0023_003Dzvd_0024Klif2IMz9, _0023_003DzdoW7ToAWvN60._0023_003DzYqHhzKLkolNr, _0023_003DzdoW7ToAWvN60._0023_003Dz6V6sfnY0FTCS, _0023_003DzdoW7ToAWvN60._0023_003Dzt8_7Loo0bHkF, _0023_003DzdoW7ToAWvN60._0023_003DzIESXlCcuK6tN, _0023_003DzdoW7ToAWvN60._0023_003DzKk93HwAcNQZd, _0023_003DzdoW7ToAWvN60._0023_003DzIPYeNoo_003D, _0023_003DzdoW7ToAWvN60._0023_003DzT4FKHOb3L3Vt, _0023_003DzdoW7ToAWvN60._0023_003Dz6Cg9P2oWT3Wd, 1, (_0023_003DzYVYPPCI_003D)_0023_003DzdoW7ToAWvN60._0023_003Dz0Ugxr7RdRfLDX6xHfw_003D_003D);
			break;
		case (_0023_003DzYVYPPCI_003D)2:
			_0023_003DzbSw6tNJHLQDR = (int)(_0023_003DzdoW7ToAWvN60._0023_003DzIPYeNoo_003D / _0023_003DzSHdX3HLnpOCc_yxScQ_003D_003D * 360f);
			curve = _0023_003DzTbn8pkAZSxbZbOq_bA_003D_003D(_0023_003DzdoW7ToAWvN60._0023_003Dz7BMokyu_YQCB, _0023_003DzdoW7ToAWvN60._0023_003DzoXnr52KfBCwO, _0023_003DzdoW7ToAWvN60._0023_003DzevYy2NHiONCn, _0023_003DzdoW7ToAWvN60._0023_003Dzvd_0024Klif2IMz9, _0023_003DzdoW7ToAWvN60._0023_003DzYqHhzKLkolNr, _0023_003DzdoW7ToAWvN60._0023_003Dz6V6sfnY0FTCS, _0023_003DzdoW7ToAWvN60._0023_003Dzt8_7Loo0bHkF, _0023_003DzdoW7ToAWvN60._0023_003DzIESXlCcuK6tN, _0023_003DzdoW7ToAWvN60._0023_003DzKk93HwAcNQZd, _0023_003DzdoW7ToAWvN60._0023_003DzIPYeNoo_003D, _0023_003DzdoW7ToAWvN60._0023_003DzT4FKHOb3L3Vt, _0023_003DzdoW7ToAWvN60._0023_003Dz6Cg9P2oWT3Wd, -1, (_0023_003DzYVYPPCI_003D)_0023_003DzdoW7ToAWvN60._0023_003Dz0Ugxr7RdRfLDX6xHfw_003D_003D);
			break;
		}
		if (curve != null)
		{
			((Entity)curve).ColorMethod = colorMethodType.byEntity;
			((Entity)curve).Color = _0023_003DzdoW7ToAWvN60._0023_003Dz3ibXxthBA0Uu;
		}
		return curve;
	}

	private ICurve _0023_003DzTbn8pkAZSxbZbOq_bA_003D_003D(float _0023_003Dz05pimnheMxCZ, float _0023_003Dz5zHCmjfFTiYl, float _0023_003DzlbuuDlYv38pL, float _0023_003DzAQxxIMs_003D, float _0023_003Dzj_0024GXFnE_003D, float _0023_003Dz4wXiP7Q_003D, float _0023_003DzNo7tHpA_003D, float _0023_003DzCeb6f9A_003D, float _0023_003DzOlqdKrs_003D, float _0023_003DzRpXgovo_003D, float _0023_003DzUsjaK3MTvHlhe1Druw_003D_003D, float _0023_003DzU6x3FiEtVN_h, int _0023_003Dzl88gYL5fXMwi, _0023_003DzYVYPPCI_003D _0023_003DzvgoxfwFdrs_0024e)
	{
		if (_0023_003DzRpXgovo_003D == 0f)
		{
			return null;
		}
		switch (_0023_003DzvgoxfwFdrs_0024e)
		{
		case (_0023_003DzYVYPPCI_003D)0:
			_0023_003DzlbuuDlYv38pL = _0023_003DzOlqdKrs_003D;
			break;
		case (_0023_003DzYVYPPCI_003D)1:
			_0023_003Dz5zHCmjfFTiYl = _0023_003DzNo7tHpA_003D;
			break;
		case (_0023_003DzYVYPPCI_003D)2:
			_0023_003Dz05pimnheMxCZ = _0023_003Dzj_0024GXFnE_003D;
			break;
		}
		float num = Math.Abs(_0023_003DzUsjaK3MTvHlhe1Druw_003D_003D - _0023_003DzU6x3FiEtVN_h);
		if ((double)Math.Abs(num) < Math.PI * 2.0 + Utility._0023_003DzxhnLabVjXjPg)
		{
			Point3D center = new Point3D(_0023_003Dz05pimnheMxCZ, _0023_003Dz5zHCmjfFTiYl, _0023_003DzlbuuDlYv38pL);
			Point3D point = new Point3D(_0023_003Dzj_0024GXFnE_003D, _0023_003DzNo7tHpA_003D, _0023_003DzOlqdKrs_003D);
			Point3D point2 = new Point3D(_0023_003DzAQxxIMs_003D, _0023_003Dz4wXiP7Q_003D, _0023_003DzCeb6f9A_003D);
			Arc arc = new Arc(_0023_003DzvgoxfwFdrs_0024e switch
			{
				(_0023_003DzYVYPPCI_003D)0 => Plane.XY, 
				(_0023_003DzYVYPPCI_003D)1 => Plane.XZ, 
				_ => Plane.YZ, 
			}, center, _0023_003DzRpXgovo_003D, 0.0, Math.PI * 2.0);
			arc.Project(point, out var t);
			arc.Project(point2, out var t2);
			if (Utility.AreEqual(t, Math.PI * 2.0, Math.PI * 2.0))
			{
				t = 0.0;
			}
			if (Utility.AreEqual(t2, 0.0, Math.PI * 2.0))
			{
				t2 = Math.PI * 2.0;
			}
			if (_0023_003Dzl88gYL5fXMwi < 0)
			{
				Utility.Swap(ref t, ref t2);
			}
			arc.Domain = new Interval(t, t2);
			if (_0023_003Dzl88gYL5fXMwi < 0)
			{
				arc.Reverse();
			}
			switch (_0023_003DzvgoxfwFdrs_0024e)
			{
			case (_0023_003DzYVYPPCI_003D)0:
				arc.EntityData = _0023_003DzCeb6f9A_003D - _0023_003DzOlqdKrs_003D;
				break;
			case (_0023_003DzYVYPPCI_003D)1:
				arc.EntityData = _0023_003Dz4wXiP7Q_003D - _0023_003DzNo7tHpA_003D;
				break;
			default:
				arc.EntityData = _0023_003DzAQxxIMs_003D - _0023_003Dzj_0024GXFnE_003D;
				break;
			}
			return arc;
		}
		int num2 = 0;
		int num3 = 0;
		float num4 = 0f;
		float num5 = 0f;
		num3 = (int)(num / _0023_003DzAlvBzwurHvj0);
		num5 = (float)_0023_003Dzl88gYL5fXMwi * (num / (float)num3);
		Point3D[] array = new Point3D[num3 + 2];
		array[0] = new Point3D(_0023_003Dzj_0024GXFnE_003D, _0023_003DzNo7tHpA_003D, _0023_003DzOlqdKrs_003D);
		switch (_0023_003DzvgoxfwFdrs_0024e)
		{
		case (_0023_003DzYVYPPCI_003D)0:
			num4 = (_0023_003DzCeb6f9A_003D - _0023_003DzOlqdKrs_003D) / (float)num3;
			for (num2 = 1; num2 <= num3; num2++)
			{
				array[num2] = new Point3D(_0023_003Dz05pimnheMxCZ + (float)((double)_0023_003DzRpXgovo_003D * Math.Cos((float)num2 * num5 + _0023_003DzUsjaK3MTvHlhe1Druw_003D_003D)), _0023_003Dz5zHCmjfFTiYl + (float)((double)_0023_003DzRpXgovo_003D * Math.Sin((float)num2 * num5 + _0023_003DzUsjaK3MTvHlhe1Druw_003D_003D)), _0023_003DzOlqdKrs_003D + num4 * (float)num2);
			}
			break;
		case (_0023_003DzYVYPPCI_003D)1:
			num4 = (_0023_003Dz4wXiP7Q_003D - _0023_003DzNo7tHpA_003D) / (float)num3;
			for (num2 = 1; num2 <= num3; num2++)
			{
				array[num2] = new Point3D(_0023_003Dz05pimnheMxCZ + (float)((double)_0023_003DzRpXgovo_003D * Math.Cos((float)num2 * num5 + _0023_003DzUsjaK3MTvHlhe1Druw_003D_003D)), _0023_003DzNo7tHpA_003D + num4 * (float)num2, _0023_003DzlbuuDlYv38pL + (float)((double)_0023_003DzRpXgovo_003D * Math.Sin((float)num2 * num5 + _0023_003DzUsjaK3MTvHlhe1Druw_003D_003D)));
			}
			break;
		case (_0023_003DzYVYPPCI_003D)2:
			num4 = (_0023_003DzAQxxIMs_003D - _0023_003Dzj_0024GXFnE_003D) / (float)num3;
			for (num2 = 1; num2 <= num3; num2++)
			{
				array[num2] = new Point3D(_0023_003Dzj_0024GXFnE_003D + num4 * (float)num2, _0023_003Dz5zHCmjfFTiYl + (float)((double)_0023_003DzRpXgovo_003D * Math.Cos((float)num2 * num5 + _0023_003DzUsjaK3MTvHlhe1Druw_003D_003D)), _0023_003DzlbuuDlYv38pL + (float)((double)_0023_003DzRpXgovo_003D * Math.Sin((float)num2 * num5 + _0023_003DzUsjaK3MTvHlhe1Druw_003D_003D)));
			}
			break;
		}
		array[^1] = new Point3D(_0023_003DzAQxxIMs_003D, _0023_003Dz4wXiP7Q_003D, _0023_003DzCeb6f9A_003D);
		return new LinearPath(array);
	}

	private ICurve _0023_003Dzpn7WFKHEwMZbhBBA_0024UNACNw_003D(float _0023_003DzAQxxIMs_003D, float _0023_003Dzj_0024GXFnE_003D, float _0023_003Dz4wXiP7Q_003D, float _0023_003DzNo7tHpA_003D, float _0023_003DzCeb6f9A_003D, float _0023_003DzOlqdKrs_003D, float _0023_003DzUsjaK3MTvHlhe1Druw_003D_003D, float _0023_003DzU6x3FiEtVN_h, float _0023_003Dzl88gYL5fXMwi, string _0023_003DzyN1Jqbs_003D)
	{
		int num = 0;
		int num2 = 0;
		float num3 = 0f;
		float num4 = 0f;
		float num5 = 0f;
		float num6 = 0f;
		float num7 = 0f;
		if (_0023_003Dz9xZrKUE_003D._0023_003Dz_MS_Clw_003D._0023_003DzXECcuRkJyd_U == (_0023_003DzILN1e7bv_WZLFSFuAg_003D_003D)0)
		{
			if (_0023_003Dzl88gYL5fXMwi == -1f)
			{
				_0023_003DzU6x3FiEtVN_h -= (float)Math.PI * 2f;
			}
			else if (_0023_003Dzl88gYL5fXMwi == 1f && _0023_003DzU6x3FiEtVN_h < _0023_003DzUsjaK3MTvHlhe1Druw_003D_003D)
			{
				_0023_003DzU6x3FiEtVN_h = (float)Math.PI * 2f + _0023_003DzU6x3FiEtVN_h;
			}
		}
		num6 = _0023_003DzU6x3FiEtVN_h - _0023_003DzUsjaK3MTvHlhe1Druw_003D_003D;
		num2 = (int)Math.Abs(num6 / _0023_003DzAlvBzwurHvj0);
		Point3D[] array = new Point3D[num2 + 1];
		array[0] = new Point3D(_0023_003Dzj_0024GXFnE_003D, _0023_003DzNo7tHpA_003D, _0023_003DzOlqdKrs_003D);
		int num8 = -1;
		switch (_0023_003Dz9xZrKUE_003D._0023_003Dz_MS_Clw_003D._0023_003DzXeIVO7S2FlGY_Hg3uw_003D_003D)
		{
		case (_0023_003Dz_afi8gY_003D)2:
			_0023_003DzUsjaK3MTvHlhe1Druw_003D_003D = (_0023_003DzUsjaK3MTvHlhe1Druw_003D_003D + _0023_003DzximEtuur1sXu8JnDuA_003D_003D._0023_003DzmT7CQCHQhPi0(_0023_003DzOlqdKrs_003D, _0023_003DzNo7tHpA_003D, _0023_003DzbU0rLpQ_003D: false) * (float)num8) * (float)num8;
			num5 = num6 / (float)num2 * (float)num8;
			num3 = (_0023_003DzAQxxIMs_003D - _0023_003Dzj_0024GXFnE_003D) / (float)num2;
			num4 = (_0023_003DzCeb6f9A_003D - _0023_003DzOlqdKrs_003D) / (float)num2;
			for (num = 1; num <= num2; num++)
			{
				num7 = _0023_003DzximEtuur1sXu8JnDuA_003D_003D._0023_003Dz6v2QDv_9AGbc(0f, _0023_003DzNo7tHpA_003D, _0023_003DzOlqdKrs_003D + num4 * (float)num, 0f, 0f, 0f);
				array[num] = new Point3D(_0023_003Dzj_0024GXFnE_003D + num3 * (float)num, (float)((double)num7 * Math.Sin((float)num * num5 + _0023_003DzUsjaK3MTvHlhe1Druw_003D_003D)), (float)((double)num7 * Math.Cos((float)num * num5 + _0023_003DzUsjaK3MTvHlhe1Druw_003D_003D)));
			}
			break;
		case (_0023_003Dz_afi8gY_003D)1:
			_0023_003DzUsjaK3MTvHlhe1Druw_003D_003D = (_0023_003DzUsjaK3MTvHlhe1Druw_003D_003D - _0023_003DzximEtuur1sXu8JnDuA_003D_003D._0023_003DzmT7CQCHQhPi0(_0023_003DzOlqdKrs_003D, _0023_003Dzj_0024GXFnE_003D, _0023_003DzbU0rLpQ_003D: false) * (float)num8) * (float)(-num8);
			num5 = num6 / (float)num2 * (float)(-num8);
			num3 = (_0023_003Dz4wXiP7Q_003D - _0023_003DzNo7tHpA_003D) / (float)num2;
			num4 = (_0023_003DzCeb6f9A_003D - _0023_003DzOlqdKrs_003D) / (float)num2;
			for (num = 1; num <= num2; num++)
			{
				num7 = _0023_003DzximEtuur1sXu8JnDuA_003D_003D._0023_003Dz6v2QDv_9AGbc(_0023_003Dzj_0024GXFnE_003D, 0f, _0023_003DzOlqdKrs_003D + num4 * (float)num, 0f, 0f, 0f);
				array[num] = new Point3D((float)((double)num7 * Math.Sin((float)num * num5 + _0023_003DzUsjaK3MTvHlhe1Druw_003D_003D)), _0023_003DzNo7tHpA_003D + num3 * (float)num, (float)((double)num7 * Math.Cos((float)num * num5 + _0023_003DzUsjaK3MTvHlhe1Druw_003D_003D)));
			}
			break;
		}
		return new LinearPath(array);
	}
}
