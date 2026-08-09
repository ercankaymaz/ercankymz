using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using devDept.Eyeshot.Translators;
using devDept.Geometry;

internal sealed class _0023_003DzkeIyMnc67iU4m6G8J8MrWFnxFtQQ63NuY3ugKtQ_003D : _0023_003DzZblWR4M6qOLiy7U57TkX2pA_003D
{
	public string _0023_003DzkRQtkogvgG3ZUICd4fxLSvDYcOkG;

	public string _0023_003Dzp_0024d6xO0_003D;

	public string _0023_003DzefVLP4k43QcJ;

	public string _0023_003Dz74dsc2o_003D;

	public DateTime _0023_003DztqFjNres8Nni;

	public string _0023_003DzG44DSbY_003D;

	public string _0023_003DzhthqjT8_003D;

	public double _0023_003DzoDRCNszxm3z_;

	public linearUnitsType _0023_003DzkrKTEVA_003D;

	public List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003Dz618HlSI_003D;

	public bool _0023_003Dz3oKHAXp4p7vg(Stream _0023_003DzdLqTRfo_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		TextReader textReader = new StreamReader(_0023_003DzdLqTRfo_003D, Encoding.ASCII);
		int num = 0;
		int num2 = 0;
		while (textReader.ReadLine() != null)
		{
			num2++;
		}
		_0023_003DzdLqTRfo_003D.Position = 0L;
		_0023_003DzoDRCNszxm3z_ = 1.0;
		_0023_003DzkrKTEVA_003D = linearUnitsType.Unitless;
		_0023_003Dz618HlSI_003D = new List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D>();
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = false;
		string text;
		while ((text = textReader.ReadLine()) != null)
		{
			if (text.Length < 80)
			{
				continue;
			}
			switch (text[72])
			{
			case 'G':
				stringBuilder.Append(text, 0, 72);
				break;
			case 'D':
			{
				if (!flag)
				{
					List<string> list = new List<string>(stringBuilder.ToString().Split(','));
					for (int i = 0; i < list.Count - 1; i++)
					{
						if (list[i].Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302912989)))
						{
							int num5 = list[i].IndexOf('H');
							int num6 = _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGf_0024qVfKC_ZL(list[i].Substring(0, num5));
							while (list[i].Length - num5 - 1 < num6)
							{
								List<string> list2 = list;
								int index = i;
								list2[index] = list2[index] + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962) + list[i + 1];
								list.RemoveAt(i + 1);
							}
						}
					}
					if (list.Count > 12)
					{
						_0023_003DzkRQtkogvgG3ZUICd4fxLSvDYcOkG = _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGMG8A4_003D(list[2]);
						_0023_003Dzp_0024d6xO0_003D = _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGMG8A4_003D(list[3]);
						_0023_003DzefVLP4k43QcJ = _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGMG8A4_003D(list[4]);
						_0023_003Dz74dsc2o_003D = _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGMG8A4_003D(list[5]);
						string text3 = _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGMG8A4_003D(list[17]);
						try
						{
							int year = int.Parse(text3.Substring(0, 4));
							int month = int.Parse(text3.Substring(4, 2));
							int day = int.Parse(text3.Substring(6, 2));
							int hour = int.Parse(text3.Substring(9, 2));
							int minute = int.Parse(text3.Substring(11, 2));
							int second = int.Parse(text3.Substring(13, 2));
							_0023_003DztqFjNres8Nni = new DateTime(year, month, day, hour, minute, second);
						}
						catch (Exception)
						{
							try
							{
								int year2 = int.Parse(text3.Substring(0, 2));
								int month2 = int.Parse(text3.Substring(2, 2));
								int day2 = int.Parse(text3.Substring(4, 2));
								int hour2 = int.Parse(text3.Substring(7, 2));
								int minute2 = int.Parse(text3.Substring(9, 2));
								int second2 = int.Parse(text3.Substring(11, 2));
								_0023_003DztqFjNres8Nni = new DateTime(CultureInfo.InvariantCulture.Calendar.ToFourDigitYear(year2), month2, day2, hour2, minute2, second2);
							}
							catch (Exception)
							{
								_0023_003DzqmF8XJ0_003D.AppendLine(ReadFileAsync._0023_003DzZEKtB5M1I4vABrH53Opsgm4_003D);
							}
						}
						_0023_003DzoDRCNszxm3z_ = Utility.DoubleParse(list[12].Replace('D', 'E'));
						switch (_0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGf_0024qVfKC_ZL(list[13]))
						{
						case 1:
							_0023_003DzkrKTEVA_003D = linearUnitsType.Inches;
							break;
						case 2:
							_0023_003DzkrKTEVA_003D = linearUnitsType.Millimeters;
							break;
						case 4:
							_0023_003DzkrKTEVA_003D = linearUnitsType.Feet;
							break;
						case 5:
							_0023_003DzkrKTEVA_003D = linearUnitsType.Miles;
							break;
						case 6:
							_0023_003DzkrKTEVA_003D = linearUnitsType.Meters;
							break;
						case 7:
							_0023_003DzkrKTEVA_003D = linearUnitsType.Kilometers;
							break;
						case 8:
							_0023_003DzkrKTEVA_003D = linearUnitsType.Mils;
							break;
						case 9:
							_0023_003DzkrKTEVA_003D = linearUnitsType.Microns;
							break;
						case 10:
							_0023_003DzkrKTEVA_003D = linearUnitsType.Centimeters;
							break;
						case 11:
							_0023_003DzkrKTEVA_003D = linearUnitsType.Microinches;
							break;
						default:
							_0023_003DzkrKTEVA_003D = linearUnitsType.NotSupported;
							break;
						}
						if (list.Count > 21)
						{
							_0023_003DzG44DSbY_003D = _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGMG8A4_003D(list[20]);
							_0023_003DzhthqjT8_003D = _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGMG8A4_003D(list[21]);
						}
					}
					flag = true;
				}
				string text4 = text.Substring(32, 8);
				int _0023_003DzVruOeK_soNft = -1;
				if (text4 != _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302987052))
				{
					_0023_003DzVruOeK_soNft = _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGf_0024qVfKC_ZL(text4);
				}
				string text5 = text.Substring(48, 8);
				int _0023_003Dztfry3Xjye35X = -1;
				if (text5 != _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302987052) && text5 != _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302987033))
				{
					_0023_003Dztfry3Xjye35X = _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGf_0024qVfKC_ZL(text5);
				}
				bool _0023_003Dz0HpIYNA_003D = false;
				int.TryParse(text.Substring(64, 2), out var result);
				if (result == 0)
				{
					_0023_003Dz0HpIYNA_003D = true;
				}
				bool _0023_003DzGD9w0Nw_003D = false;
				int.TryParse(text.Substring(68, 2), out var _);
				int _0023_003DzWmSBQy2wUHb = _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGf_0024qVfKC_ZL(text.Substring(73, 7));
				string text6 = textReader.ReadLine();
				num++;
				int.TryParse(text6.Substring(16, 8), out var result3);
				int.TryParse(text6.Substring(32, 8), out var result4);
				string _0023_003DzPzO_0024GUk_003D = text6.Substring(56, 8);
				int num7 = _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGf_0024qVfKC_ZL(text.Substring(5, 3));
				_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2 = null;
				_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2 = num7 switch
				{
					100 => new _0023_003DzdPtvklPFzKqxMoTpEOXyeC1W53neVz2gTQ_003D_003D(_0023_003DzWmSBQy2wUHb, result3, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, result4), 
					102 => new _0023_003Dzz6JIJ4xNe1_0024dIMT88uFZydqQ_0024upBYSTqB05jKFc_003D(_0023_003DzWmSBQy2wUHb, result3, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, result4), 
					104 => new _0023_003Dzdqr8UI0Jipc_0024TuuKDhHIJvVq3Tj138M0mHUw_gY_003D(_0023_003DzWmSBQy2wUHb, result3, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, result4), 
					106 => new _0023_003DzCvMCt05pVvqGJGI368UlSvv09UP9pWWmRo3Qh0YGOXCU(_0023_003DzWmSBQy2wUHb, result3, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, result4), 
					108 => new _0023_003DzOK_wIuCG_0024L33RaVzjK4JLUKKO_p4pq_0024by5YYyrY_003D(_0023_003DzWmSBQy2wUHb, result3, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, result4), 
					110 => new _0023_003DzCDSdDaukKIfQIKuoRosZ3NAKyMQ1WGSxOA_003D_003D(_0023_003DzWmSBQy2wUHb, result3, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, result4), 
					112 => new _0023_003DzOKQiiYVsLKx6c65wwxfwYTu0ENOXS1pHlaJUbq8QGC1LOQs_0024LQ_003D_003D(_0023_003DzWmSBQy2wUHb, result3, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, result4), 
					114 => new _0023_003Dz3Zx4KFlYXhE6x5ocfLkICI9BSGRZVvqe1SYkVItmXGYVkWg25w_003D_003D(_0023_003DzWmSBQy2wUHb, result3, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, result4), 
					116 => new _0023_003Dz_Q4HKPwuFf6e2QQ1OJd0reHy3bQkmQVBhQ_003D_003D(_0023_003DzWmSBQy2wUHb, result3, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, result4), 
					118 => new _0023_003DzOKWbo7sUM8LpXGAfWbsy7u9_aoyf6rVNGlnjW9k_003D(_0023_003DzWmSBQy2wUHb, result3, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, result4), 
					120 => new _0023_003DzYkQVv2Lb0egyGZnzeO8ydkyFt0lDEhHA4uvG2TxpWX6vfM3gdg_003D_003D(_0023_003DzWmSBQy2wUHb, result3, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, result4), 
					122 => new _0023_003DzZXHZ8r_AKGbCsLnm7EUe1w_00244EG0i1nNAEdrGUvzdztgO(_0023_003DzWmSBQy2wUHb, result3, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, result4), 
					124 => new _0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D(_0023_003DzWmSBQy2wUHb, result3, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, result4), 
					126 => new _0023_003Dz9lwBHA7NoLh_0024_1EVuspU6hmh4G7BX3ZcrScNn8k_003D(_0023_003DzWmSBQy2wUHb, result3, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, result4), 
					128 => new _0023_003Dz_ZR_60g8KTZpV15NG_0024gJ1cZ3Q9yL1UXPtzY9x8s_003D(_0023_003DzWmSBQy2wUHb, result3, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, result4), 
					140 => new _0023_003DzfSAHMZkL2hJuTBQQ4L7dNUFzt0xFD2jPM7XhiwU_003D(_0023_003DzWmSBQy2wUHb, result3, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, result4), 
					141 => new _0023_003DzEKmPHSrtZpXBuvnSgWZRaBK5Mq11POCYUuKluiI_003D(_0023_003DzWmSBQy2wUHb, result3, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, result4), 
					142 => new _0023_003DzBJElHqxtPPtMLXcUwpVKUEHLvZ15nURMw0JZlFU3Avjs4D9aLQ_003D_003D(_0023_003DzWmSBQy2wUHb, result3, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, result4), 
					143 => new _0023_003Dz_00242iQD1FOOBMB8Ag0xLXT03IXG_IUm_Shn5BXiGI_003D(_0023_003DzWmSBQy2wUHb, result3, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, result4), 
					144 => new _0023_003DzOqrWHudzVp1v35H_vsK2gKOjnxqMkRli9ie5GLqoLH7QYRVcuQ_003D_003D(_0023_003DzWmSBQy2wUHb, result3, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, result4), 
					212 => new _0023_003Dz26Feb5E6SVtERAQBq_TBV8CmtN1UucNJlA_003D_003D(_0023_003DzWmSBQy2wUHb, result3, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, result4), 
					308 => new _0023_003Dz18IEgzJEVJEAtpayNrr9Mj_0024u2aTOeu3UMujTh86IKJMf(_0023_003DzWmSBQy2wUHb, result3, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, result4), 
					314 => new _0023_003DzoMowD04mt4vKC4cSDkFRUr_dj0yUGXqXlA_003D_003D(_0023_003DzWmSBQy2wUHb, result3, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, result4), 
					402 => new _0023_003DzzTCaZbrp3S0YNBiuIm4zwd7w9Q3Q0G6PLQ_003D_003D(_0023_003DzWmSBQy2wUHb, result3, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, result4), 
					406 => new _0023_003DzWPy7Mq_LyWeTazTXtajtCZ8FDawgWm5p_A_003D_003D(_0023_003DzWmSBQy2wUHb, result3, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, result4), 
					408 => new _0023_003Dz0wVdkDSyPiY38wDh_0024it2Wow5fuuPl7r8a8kaJfYypij3(_0023_003DzWmSBQy2wUHb, result3, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D: false, _0023_003Dz0HpIYNA_003D, result4), 
					410 => new _0023_003DzoSjmcwD_0024fMBWHjBBt3y6mwYu_DdokIPvAw_003D_003D(_0023_003DzWmSBQy2wUHb, result3, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D: false, _0023_003Dz0HpIYNA_003D, result4), 
					502 => new _0023_003DzzqQMnVz1u4B7Ao5VuLHfFnIEzCMKuUZ_0024gQ_003D_003D(_0023_003DzWmSBQy2wUHb, result4), 
					504 => new _0023_003Dzg9kdMKEMX5KRt9SgqKcmIBs4bF4zPzCU3g_003D_003D(_0023_003DzWmSBQy2wUHb, result4), 
					508 => new _0023_003DzEKmPHSrtZpXBuvnSgWZRaP_j0pyFE9wA6w_003D_003D(_0023_003DzWmSBQy2wUHb, result4), 
					510 => new _0023_003Dzy4DM0pk_0024TAdIhuL2pH9FIzCDKJadlZSRDQ_003D_003D(_0023_003DzWmSBQy2wUHb, result4, result3, _0023_003DzVruOeK_soNft), 
					514 => new _0023_003DzF5p_8NJ3PUm7nyvOOwDz4l_0024pwTFYmB_e_0024Q_003D_003D(_0023_003DzWmSBQy2wUHb, result3, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, result4), 
					186 => new _0023_003DzTsGSj5r0zhbKoPjk04Ctgt5hXkbDo26vk_YJJ_kCYeB4dIKQQQ_003D_003D(_0023_003DzWmSBQy2wUHb, result3, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, result4), 
					190 => new _0023_003Dz33gUjy3ocKE8GMVaXVlNH3IyyZmuwan0aTQv6YQ_003D(_0023_003DzWmSBQy2wUHb, result4), 
					192 => new _0023_003DzfDpAK59ydJjjoyL2Yh_q4HLkc9bx82zcUjw_9FsJK2JXGYdzuKEWaoI_003D(_0023_003DzWmSBQy2wUHb, result4), 
					194 => new _0023_003DzvRv2q7rL_0024ZnoPvAjrfwD6WnhKv4_00240RnC93FJKB2l87_0024PrYvxiw_003D_003D(_0023_003DzWmSBQy2wUHb, result4), 
					196 => new _0023_003DzzTCaZbrp3S0YNBiuIm4zwWRKyXGhqoSnJfApr9Zao2Py(_0023_003DzWmSBQy2wUHb, result4), 
					198 => new _0023_003DzgRGydxI0js4H2FiOzNOIWEvotJMyjEeDqqICnCrzpRPU(_0023_003DzWmSBQy2wUHb, result4), 
					123 => new _0023_003DzWaDC3cb0r3lI0VgI_0024kKEmG92hIMMgnulmw_003D_003D(_0023_003DzWmSBQy2wUHb, result4), 
					_ => new _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986247), _0023_003Dz_002418Nebs_KL8i: false, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909746), Color.Black), 
				};
				_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2._0023_003DzVzCS8i1Xxxfg(_0023_003DzPzO_0024GUk_003D);
				_0023_003Dz618HlSI_003D.Add(_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2);
				break;
			}
			case 'P':
			{
				int num3 = _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGf_0024qVfKC_ZL(text.Substring(64, 8));
				StringBuilder stringBuilder2 = new StringBuilder(1000);
				stringBuilder2.Append(text.Substring(0, 64).Trim());
				int num4 = text.IndexOf(';');
				while (num4 < 0)
				{
					text = textReader.ReadLine();
					num++;
					string text2 = text.Substring(0, 64).Trim();
					num4 = text2.LastIndexOf(';');
					if (num4 != -1 && num4 != text2.Length - 1)
					{
						num4 = -1;
					}
					stringBuilder2.Append(text2);
				}
				_0023_003Dz618HlSI_003D[num3 / 2]._0023_003Dzs4pJKQU_003D(stringBuilder2.ToString(), _0023_003Dz618HlSI_003D);
				break;
			}
			}
			if (!_0023_003DzI8SQX5cpoKsqrKUaAw_003D_003D(num, num2))
			{
				return false;
			}
			num++;
		}
		return true;
	}
}
