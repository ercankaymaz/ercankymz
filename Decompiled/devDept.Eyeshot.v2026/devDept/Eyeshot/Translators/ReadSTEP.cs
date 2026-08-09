using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class ReadSTEP : ReadFileAsync
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D, bool> _0023_003Dz38_WZBhyB43pPpxcCQ_003D_003D;

		public static Func<SortedDictionary<int, Block>> _0023_003Dz_gQxC_0024JsqURHoyEgbQ_003D_003D;

		public static Func<SortedList<int, Entity[]>> _0023_003Dzva0mm4tTW6Ab8HpH_0024w_003D_003D;

		public static Func<SortedList<int, Entity[]>> _0023_003DzxztQPIgms8SlOKkz6g_003D_003D;

		public static Func<SortedList<int, Entity>> _0023_003DzfboZSHzYXYu8n06YCg_003D_003D;

		internal bool _0023_003DzTC__Jw3RJ8efm2y65qfOnZg_003D(_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D _0023_003DzgyYoHow_003D)
		{
			if (!_0023_003DzgyYoHow_003D._0023_003DzSxKSyExlVAOd())
			{
				return _0023_003DzgyYoHow_003D._0023_003DzyePFrIIHO6NHR_hL8Q_003D_003D().Count > 0;
			}
			return false;
		}

		internal SortedDictionary<int, Block> _0023_003DzL4fBN_00247hWJjkAvgmV17d6dc_003D()
		{
			return new SortedDictionary<int, Block>();
		}

		internal SortedList<int, Entity[]> _0023_003Dzfv_0024NGE5wyOuDlHMWol6_ifKX239CLmLZiw_003D_003D()
		{
			return new SortedList<int, Entity[]>();
		}

		internal SortedList<int, Entity[]> _0023_003DzQA70qW4gvm4HjXI7HKVHj36vPbeH()
		{
			return new SortedList<int, Entity[]>();
		}

		internal SortedList<int, Entity> _0023_003DzSGi5O1N_OoUc6eKqQc9kP9Q_003D()
		{
			return new SortedList<int, Entity>();
		}
	}

	private sealed class _0023_003DzTvLfVfgMMlGE7THlqihsW1c_003D
	{
		public IList<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003DzcHBkf2AI2x89v1_0024zYw_003D_003D;

		public ReadSTEP _0023_003DzopRx0_MBcTQs;

		public int _0023_003Dz9JZgoew_003D;

		public IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D;

		public CancellationToken _0023_003Dzjvn7P10_003D;

		public bool _0023_003Dz8If0AEk_003D;

		public SortedList<int, Entity[]> _0023_003DzWc9WmS8VMsuA;

		internal SortedList<int, Entity[]> _0023_003DzlHPDMplmkYh5VxRyz4gHbdQ_003D(int _0023_003Dz437_00244ak_003D, ParallelLoopState _0023_003DzLdZiL78_003D, SortedList<int, Entity[]> _0023_003DzifrLU2QXMnn0)
		{
			_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D2 = _0023_003DzcHBkf2AI2x89v1_0024zYw_003D_003D[_0023_003Dz437_00244ak_003D];
			StringBuilder stringBuilder = new StringBuilder();
			List<Mesh> list = _0023_003Dzh7GYg1aQoczeFVgORDu9DRj7xo8ThXX6cg_BxfE_003D(_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D2);
			foreach (Mesh item in list)
			{
				item.MaterialName = stringBuilder.ToString();
				if (_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D2._0023_003Dzwtld1NM_003D != null && _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D2._0023_003Dzwtld1NM_003D[0] != -1.0)
				{
					item.Color = Color.FromArgb((int)(_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D2._0023_003Dzwtld1NM_003D[0] * 255.0), (int)(_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D2._0023_003Dzwtld1NM_003D[1] * 255.0), (int)(_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D2._0023_003Dzwtld1NM_003D[2] * 255.0));
					item.ColorMethod = colorMethodType.byEntity;
				}
				item.TranslationID = new TranslationIdentifier(_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D2._0023_003DzkXQ_IWk_003D, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D2._0023_003DzS_00246o7tc_003D);
			}
			int _0023_003DzkXQ_IWk_003D = _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D2._0023_003DzkXQ_IWk_003D;
			Entity[] value = list.ToArray();
			_0023_003DzifrLU2QXMnn0.Add(_0023_003DzkXQ_IWk_003D, value);
			if (!_0023_003DzopRx0_MBcTQs.UpdateProgressAndCheckCancelledParallel(_0023_003Dz9JZgoew_003D, _0023_003DzopRx0_MBcTQs.ParsingText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
			{
				_0023_003Dz8If0AEk_003D = false;
				_0023_003DzLdZiL78_003D.Stop();
			}
			return _0023_003DzifrLU2QXMnn0;
		}

		internal void _0023_003Dzb0Ux2Cv18JEI5hC2PVxFPPo_003D(SortedList<int, Entity[]> _0023_003DzBJFJHwk_003D)
		{
			lock (_0023_003DzWc9WmS8VMsuA)
			{
				foreach (KeyValuePair<int, Entity[]> item in _0023_003DzBJFJHwk_003D)
				{
					_0023_003DzWc9WmS8VMsuA.Add(item.Key, item.Value);
					Entity[] value = item.Value;
					foreach (Entity entity in value)
					{
						_0023_003DzopRx0_MBcTQs.log.Append(entity.MaterialName);
						entity.MaterialName = null;
					}
				}
			}
		}
	}

	private sealed class _0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D
	{
		public IList<_0023_003DzbykJA36oCfUxYTgeaw_003D_003D> _0023_003DzEHqFVzMAt7Lc;

		public angularUnitsType _0023_003DzDSV3KvHUSDa4;

		public ReadSTEP _0023_003DzopRx0_MBcTQs;

		public int _0023_003Dz9JZgoew_003D;

		public IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D;

		public CancellationToken _0023_003Dzjvn7P10_003D;

		public bool _0023_003Dz8If0AEk_003D;

		public SortedList<int, Entity[]> _0023_003DzWc9WmS8VMsuA;

		internal SortedList<int, Entity[]> _0023_003DzyEi57kcmRM60UdJYDuvcXkFbXsNd(int _0023_003Dz437_00244ak_003D, ParallelLoopState _0023_003DzLdZiL78_003D, SortedList<int, Entity[]> _0023_003DzifrLU2QXMnn0)
		{
			_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2 = _0023_003DzEHqFVzMAt7Lc[_0023_003Dz437_00244ak_003D];
			StringBuilder stringBuilder = new StringBuilder();
			Entity[] array = _0023_003DzuTCwRvbXUrZU(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2, _0023_003DzDSV3KvHUSDa4, ReadFileAsync.DEFAULT_COLOR, _0023_003DzopRx0_MBcTQs._0023_003DzzwQaTmWKCeWkkbmQYg_003D_003D, stringBuilder);
			Entity[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].MaterialName = stringBuilder.ToString();
			}
			_0023_003DzifrLU2QXMnn0.Add(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003DzkXQ_IWk_003D, array);
			if (!_0023_003DzopRx0_MBcTQs.UpdateProgressAndCheckCancelledParallel(_0023_003Dz9JZgoew_003D, _0023_003DzopRx0_MBcTQs.ParsingText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
			{
				_0023_003Dz8If0AEk_003D = false;
				_0023_003DzLdZiL78_003D.Stop();
			}
			return _0023_003DzifrLU2QXMnn0;
		}

		internal void _0023_003DzjF3dgXo9NcBvpEYURwerOVlDtGDS(SortedList<int, Entity[]> _0023_003DzBJFJHwk_003D)
		{
			lock (_0023_003DzWc9WmS8VMsuA)
			{
				foreach (KeyValuePair<int, Entity[]> item in _0023_003DzBJFJHwk_003D)
				{
					_0023_003DzWc9WmS8VMsuA.Add(item.Key, item.Value);
					Entity[] value = item.Value;
					foreach (Entity entity in value)
					{
						_0023_003DzopRx0_MBcTQs.log.Append(entity.MaterialName);
						entity.MaterialName = null;
					}
				}
			}
		}
	}

	private sealed class _0023_003DzjANgI7bcnJif5klsA2e0VAM_003D
	{
		public IList<_0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D> _0023_003Dzj_0024u_SRdExhSa;

		public angularUnitsType _0023_003DzDSV3KvHUSDa4;

		public ReadSTEP _0023_003DzopRx0_MBcTQs;

		public int _0023_003Dz9JZgoew_003D;

		public IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D;

		public CancellationToken _0023_003Dzjvn7P10_003D;

		public bool _0023_003Dz8If0AEk_003D;

		public SortedList<int, Entity> _0023_003DzWc9WmS8VMsuA;

		internal SortedList<int, Entity> _0023_003DzGbhKYC4raWwrnxqYmePDmBw_003D(int _0023_003Dz437_00244ak_003D, ParallelLoopState _0023_003DzLdZiL78_003D, SortedList<int, Entity> _0023_003DzifrLU2QXMnn0)
		{
			_0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D _0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D2 = _0023_003Dzj_0024u_SRdExhSa[_0023_003Dz437_00244ak_003D];
			Color _0023_003Dz1MMYB1g_003D = ReadFileAsync.DEFAULT_COLOR;
			StringBuilder stringBuilder = new StringBuilder();
			Entity entity = _0023_003DztU91JDk_003D(null, _0023_003DzDSV3KvHUSDa4, _0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D2, ref _0023_003Dz1MMYB1g_003D, _0023_003DzopRx0_MBcTQs._0023_003DzzwQaTmWKCeWkkbmQYg_003D_003D, stringBuilder);
			if (entity != null)
			{
				entity.MaterialName = stringBuilder.ToString();
				entity.ColorMethod = colorMethodType.byEntity;
				if (_0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D2._0023_003Dzwtld1NM_003D != null && _0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D2._0023_003Dzwtld1NM_003D[0] != -1.0)
				{
					entity.Color = _0023_003Dz_8C3BH8_003D(_0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D2._0023_003Dzwtld1NM_003D);
				}
				else
				{
					entity.Color = _0023_003Dz1MMYB1g_003D;
				}
				_0023_003DzifrLU2QXMnn0.Add(_0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D2._0023_003DzkXQ_IWk_003D, entity);
			}
			else
			{
				stringBuilder.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011210), _0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D2._0023_003DzkXQ_IWk_003D));
				_0023_003DzopRx0_MBcTQs.log.Append(stringBuilder);
			}
			if (!_0023_003DzopRx0_MBcTQs.UpdateProgressAndCheckCancelledParallel(_0023_003Dz9JZgoew_003D, _0023_003DzopRx0_MBcTQs.ParsingText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
			{
				_0023_003Dz8If0AEk_003D = false;
				_0023_003DzLdZiL78_003D.Stop();
			}
			return _0023_003DzifrLU2QXMnn0;
		}

		internal void _0023_003DzVEQaN21uvmpmrIX0p92hDiI_003D(SortedList<int, Entity> _0023_003DzBJFJHwk_003D)
		{
			lock (_0023_003DzWc9WmS8VMsuA)
			{
				foreach (KeyValuePair<int, Entity> item in _0023_003DzBJFJHwk_003D)
				{
					_0023_003DzWc9WmS8VMsuA.Add(item.Key, item.Value);
					_0023_003DzopRx0_MBcTQs.log.Append(item.Value.MaterialName);
					item.Value.MaterialName = null;
				}
			}
		}
	}

	private sealed class _0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D
	{
		public IList<_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D> _0023_003DznAF4fNkMjAgi;

		public _0023_003DzfqmL8TzDtVBDf6_u_0024A_003D_003D _0023_003DzkKz7OWA_003D;

		public ReadSTEP _0023_003DzopRx0_MBcTQs;

		public int _0023_003Dz9JZgoew_003D;

		public IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D;

		public CancellationToken _0023_003Dzjvn7P10_003D;

		public bool _0023_003Dz8If0AEk_003D;

		public SortedList<int, Block> _0023_003DzUf8_iZ90pWPR;

		internal SortedDictionary<int, Block> _0023_003Dz_0024ubWUKd6lJsTSbkCVw_003D_003D(int _0023_003Dz437_00244ak_003D, ParallelLoopState _0023_003DzLdZiL78_003D, SortedDictionary<int, Block> _0023_003Dzk9kSx4ZKN3L3)
		{
			_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2 = _0023_003DznAF4fNkMjAgi[_0023_003Dz437_00244ak_003D];
			StringBuilder stringBuilder = new StringBuilder();
			Block block = _0023_003DzdV9Pg_0024iCjrqs(_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2, _0023_003DzkKz7OWA_003D._0023_003DzUgQenuNv91OE(), _0023_003DzopRx0_MBcTQs._0023_003DzzwQaTmWKCeWkkbmQYg_003D_003D, stringBuilder);
			block.Description = stringBuilder.ToString();
			_0023_003Dzk9kSx4ZKN3L3.Add(_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003DzkXQ_IWk_003D, block);
			if (!_0023_003DzopRx0_MBcTQs.UpdateProgressAndCheckCancelledParallel(_0023_003Dz9JZgoew_003D, _0023_003DzopRx0_MBcTQs.ParsingText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
			{
				_0023_003Dz8If0AEk_003D = false;
				_0023_003DzLdZiL78_003D.Stop();
			}
			return _0023_003Dzk9kSx4ZKN3L3;
		}

		internal void _0023_003Dz37Y9OZ7ptJscLcMqug_003D_003D(SortedDictionary<int, Block> _0023_003DzBJFJHwk_003D)
		{
			lock (_0023_003DzUf8_iZ90pWPR)
			{
				foreach (KeyValuePair<int, Block> item in _0023_003DzBJFJHwk_003D)
				{
					_0023_003DzUf8_iZ90pWPR.Add(item.Key, item.Value);
					_0023_003DzopRx0_MBcTQs.log.Append(item.Value.Description);
					item.Value.Description = string.Empty;
				}
			}
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzfqmL8TzDtVBDf6_u_0024A_003D_003D _0023_003DzFuePbj8_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IProgress<ProgressChangedEventArgs> _0023_003DzsWnj47U_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CancellationToken _0023_003DzEBehidw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzzwQaTmWKCeWkkbmQYg_003D_003D = true;

	public override supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.Inches | supportedLinearUnitsType.Feet | supportedLinearUnitsType.Miles | supportedLinearUnitsType.Millimeters | supportedLinearUnitsType.Centimeters | supportedLinearUnitsType.Meters | supportedLinearUnitsType.Kilometers;

	public bool Simplify
	{
		get
		{
			return _0023_003DzzwQaTmWKCeWkkbmQYg_003D_003D;
		}
		set
		{
			_0023_003DzzwQaTmWKCeWkkbmQYg_003D_003D = value;
		}
	}

	public ReadSTEP(Stream stream)
		: base(stream)
	{
	}

	public ReadSTEP(string filePath)
		: base(filePath)
	{
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		byte b = 3;
		object[] array = null;
		array = new object[3] { b, this, flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "$N9u(q\"acA", array);
		_0023_003DzsWnj47U_003D = progress;
		_0023_003DzEBehidw_003D = ct;
		_0023_003DzKfSsmwLRzer8(progress, ct);
	}

	private void _0023_003DzKfSsmwLRzer8(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		bool result = false;
		Stopwatch stopwatch = new Stopwatch();
		Stopwatch stopwatch2 = new Stopwatch();
		Stopwatch stopwatch3 = new Stopwatch();
		try
		{
			base.Units = linearUnitsType.Unitless;
			List<Entity> list = new List<Entity>();
			_0023_003DzFuePbj8_003D = new _0023_003DzfqmL8TzDtVBDf6_u_0024A_003D_003D();
			_0023_003DzFuePbj8_003D._0023_003DzgHO845XqWw4G(delegate(object _0023_003Dz9VjL5i0_003D, ProgressChangedEventArgs _0023_003DzbfrNXYE_003D)
			{
				if (!UpdateProgressAndCheckCancelled(_0023_003DzbfrNXYE_003D.Progress, 100.0, base.ReadingText, _0023_003DzsWnj47U_003D, _0023_003DzEBehidw_003D))
				{
					_0023_003DzFuePbj8_003D._0023_003DzBcvxv10_003D = true;
				}
			});
			stopwatch.Start();
			StringCollection _0023_003DzcxcrDhg_003D = _0023_003DziHPCStPfeCG0();
			stopwatch.Stop();
			_0023_003DzFuePbj8_003D._0023_003DzaziuZpKBVG0K(_0023_003DzcxcrDhg_003D, out var _0023_003DzQRmFkL41VtBq, out var _0023_003Dz3KxzwrNGMDEk, out var _0023_003DzP7FoWTPYiff, out var _0023_003DzxF_0024FM1Zg3jT7zfolB_0024FSGCE_003D, out var _0023_003DzbYQ6ImJ7Ebb_0024, out var _0023_003DzR4eGWVZhkltW);
			base.FileName = _0023_003DzQRmFkL41VtBq;
			base.Timestamp = _0023_003Dz3KxzwrNGMDEk;
			base.Author = _0023_003DzP7FoWTPYiff;
			base.Organization = _0023_003DzxF_0024FM1Zg3jT7zfolB_0024FSGCE_003D;
			base.PreProcessor = _0023_003DzbYQ6ImJ7Ebb_0024;
			base.OriginatingSystem = _0023_003DzR4eGWVZhkltW;
			stopwatch2.Start();
			bool num = _0023_003DzFuePbj8_003D._0023_003DzL1pv4BgVH0z3(_0023_003DzcxcrDhg_003D);
			stopwatch2.Stop();
			if (num)
			{
				base.Blocks.Clear();
				List<_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D> _0023_003Dzs_0024KWQ4WSnUa = _0023_003DzFuePbj8_003D._0023_003DzlxKBCJ2zobwv();
				_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D _0023_003DzM0hK0I8ZSshU = new _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D();
				_0023_003DzFuePbj8_003D._0023_003Dz0aNZGVr8fjLT(ref _0023_003DzM0hK0I8ZSshU, ref _0023_003Dzs_0024KWQ4WSnUa);
				stopwatch3.Start();
				bool flag;
				if (_0023_003DzM0hK0I8ZSshU._0023_003DzyePFrIIHO6NHR_hL8Q_003D_003D().Count > 0)
				{
					log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010900));
					SortedList<int, Block> sortedList = new SortedList<int, Block>();
					flag = _0023_003Dz9ZScR7PKQJdr(_0023_003DzFuePbj8_003D, _0023_003Dzs_0024KWQ4WSnUa, sortedList, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
					base.Blocks = new BlockKeyedCollection(sortedList.Values, StringComparer.CurrentCultureIgnoreCase);
					foreach (Block block3 in base.Blocks)
					{
						foreach (Entity entity in block3.Entities)
						{
							entity.LayerName = Layer.DefaultLayerName;
						}
					}
					int num2 = _0023_003Dzs_0024KWQ4WSnUa.Count(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzTC__Jw3RJ8efm2y65qfOnZg_003D);
					foreach (_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D item3 in _0023_003Dzs_0024KWQ4WSnUa)
					{
						_0023_003DzdV9Pg_0024iCjrqs(item3, base.Blocks);
						if (!item3._0023_003DzSxKSyExlVAOd())
						{
							if (num2 > 1)
							{
								list.Add(new BlockReference(0.0, 0.0, 0.0, item3._0023_003DzwKyKajk_003D(), 0.0));
							}
							else
							{
								_0023_003DzQA5Qm4bVRLLt(item3);
							}
						}
					}
				}
				else if ((_0023_003Dzs_0024KWQ4WSnUa != null && _0023_003Dzs_0024KWQ4WSnUa.Count > 0) || _0023_003DzFuePbj8_003D._0023_003DzbPNup9w_003D != null)
				{
					if (_0023_003DzFuePbj8_003D._0023_003DzbPNup9w_003D != null)
					{
						_0023_003DzmJCVjbsxglhj(_0023_003DzFuePbj8_003D._0023_003DzbPNup9w_003D);
					}
					foreach (_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D item4 in _0023_003Dzs_0024KWQ4WSnUa)
					{
						_0023_003DzmJCVjbsxglhj(item4);
					}
					SortedList<int, Block> sortedList2 = new SortedList<int, Block>();
					flag = _0023_003Dz9ZScR7PKQJdr(_0023_003DzFuePbj8_003D, _0023_003Dzs_0024KWQ4WSnUa, sortedList2, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
					base.Blocks = new BlockKeyedCollection(sortedList2.Values, StringComparer.CurrentCultureIgnoreCase);
					if (_0023_003DzFuePbj8_003D._0023_003DzbPNup9w_003D != null)
					{
						Block block = _0023_003DzdV9Pg_0024iCjrqs(_0023_003DzFuePbj8_003D._0023_003DzbPNup9w_003D, _0023_003DzFuePbj8_003D._0023_003DzUgQenuNv91OE(), _0023_003DzzwQaTmWKCeWkkbmQYg_003D_003D, log);
						if (_0023_003DzFuePbj8_003D._0023_003DzbPNup9w_003D._0023_003DzrtSjt7CQp1z9())
						{
							list.AddRange(block.Entities);
						}
						else
						{
							base.Blocks.Add(block);
							_0023_003DzQA5Qm4bVRLLt(_0023_003DzFuePbj8_003D._0023_003DzbPNup9w_003D);
						}
					}
					foreach (_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D item5 in _0023_003Dzs_0024KWQ4WSnUa)
					{
						Block block2 = base.Blocks[item5._0023_003DzwKyKajk_003D()];
						if (item5._0023_003DzyePFrIIHO6NHR_hL8Q_003D_003D().Count > 0 || (_0023_003Dzs_0024KWQ4WSnUa.Count == 1 && list.Count == 0 && base.Blocks.Count == _0023_003Dzs_0024KWQ4WSnUa.Count))
						{
							foreach (_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D item6 in item5._0023_003DzyePFrIIHO6NHR_hL8Q_003D_003D())
							{
								BlockReference item = new BlockReference(0.0, 0.0, 0.0, item6._0023_003Dz7dWp4YQ_003D(), 0.0);
								if (item5._0023_003DzrtSjt7CQp1z9())
								{
									list.Add(item);
								}
								else
								{
									block2.Entities.Add(item);
								}
							}
							if (!item5._0023_003DzrtSjt7CQp1z9())
							{
								_0023_003DzQA5Qm4bVRLLt(item5);
								if (_0023_003Dzs_0024KWQ4WSnUa.Count == 1)
								{
									continue;
								}
							}
						}
						if (!item5._0023_003DzSxKSyExlVAOd() && item5._0023_003DzyePFrIIHO6NHR_hL8Q_003D_003D().Count == 0)
						{
							if (_0023_003DzVDcNmfZ3BSUSx5imXQ_003D_003D(item5) || _0023_003Dzr_0024hOH5GNl08uCuRBhUR8Foc_003D(item5) || !item5._0023_003DzrtSjt7CQp1z9())
							{
								BlockReference item2 = new BlockReference(0.0, 0.0, 0.0, item5._0023_003DzwKyKajk_003D(), 0.0);
								list.Add(item2);
							}
							else
							{
								list.AddRange(block2.Entities);
								base.Blocks.Remove(item5._0023_003DzwKyKajk_003D());
							}
						}
					}
				}
				else
				{
					List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003DzRpG7MzWX9ONajaaI7Q_003D_003D = new List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>();
					_0023_003DzFuePbj8_003D._0023_003DzCi2ZprWO37C1(ref _0023_003DzRpG7MzWX9ONajaaI7Q_003D_003D);
					foreach (_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D item7 in _0023_003DzRpG7MzWX9ONajaaI7Q_003D_003D)
					{
						_0023_003DzCQrmp5g8vp6W(item7);
					}
					List<_0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D> _0023_003DzeVF1vQYm3s4MoAJT9Q_003D_003D = new List<_0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D>();
					_0023_003DzFuePbj8_003D._0023_003DzGbR9JPJ0aogC(ref _0023_003DzeVF1vQYm3s4MoAJT9Q_003D_003D);
					foreach (_0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D item8 in _0023_003DzeVF1vQYm3s4MoAJT9Q_003D_003D)
					{
						_0023_003DzCQrmp5g8vp6W(item8);
					}
					List<_0023_003DzbykJA36oCfUxYTgeaw_003D_003D> _0023_003DzyUxFNVpGo2KvYBxjbQ_003D_003D = new List<_0023_003DzbykJA36oCfUxYTgeaw_003D_003D>();
					_0023_003DzFuePbj8_003D._0023_003DzdXJzlEd7nY1RxMIi0g_003D_003D(ref _0023_003DzyUxFNVpGo2KvYBxjbQ_003D_003D);
					foreach (_0023_003DzbykJA36oCfUxYTgeaw_003D_003D item9 in _0023_003DzyUxFNVpGo2KvYBxjbQ_003D_003D)
					{
						_0023_003DzCQrmp5g8vp6W(item9);
					}
					List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003DztmmTsY1KYEGmCwEqcQ_003D_003D = new List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>();
					_0023_003DzFuePbj8_003D._0023_003Dz84CxaAf_fB5FNFVv3A_003D_003D(ref _0023_003DztmmTsY1KYEGmCwEqcQ_003D_003D);
					foreach (_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D item10 in _0023_003DztmmTsY1KYEGmCwEqcQ_003D_003D)
					{
						_0023_003DzCQrmp5g8vp6W(item10);
					}
					SortedList<int, Entity> sortedList3 = new SortedList<int, Entity>();
					SortedList<int, Entity[]> sortedList4 = new SortedList<int, Entity[]>();
					SortedList<int, Entity[]> sortedList5 = new SortedList<int, Entity[]>();
					flag = _0023_003Dzbj30ga1di1YE(_0023_003DzeVF1vQYm3s4MoAJT9Q_003D_003D, sortedList3, _0023_003DzFuePbj8_003D._0023_003DzUgQenuNv91OE(), _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
					flag &= _0023_003Dzg3ZmdZy8VZ_0024fU_XC_0024g_003D_003D(_0023_003DzyUxFNVpGo2KvYBxjbQ_003D_003D, sortedList4, _0023_003DzFuePbj8_003D._0023_003DzUgQenuNv91OE(), _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
					flag &= _0023_003DzJKrq_00245CS229AkQbeuA_003D_003D(_0023_003DzRpG7MzWX9ONajaaI7Q_003D_003D, sortedList5, _0023_003DzFuePbj8_003D._0023_003DzUgQenuNv91OE(), _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
					list.AddRange(sortedList3.Values);
					foreach (KeyValuePair<int, Entity[]> item11 in sortedList4)
					{
						list.AddRange(item11.Value);
					}
					foreach (KeyValuePair<int, Entity[]> item12 in sortedList5)
					{
						list.AddRange(item12.Value);
					}
					_0023_003DzfFve6xSqWrFIQ_TSuA_003D_003D(_0023_003DztmmTsY1KYEGmCwEqcQ_003D_003D, _0023_003DzFuePbj8_003D._0023_003DzUgQenuNv91OE(), list, _0023_003DzeN7PJhbg6omH: false, _0023_003DzzwQaTmWKCeWkkbmQYg_003D_003D, ReadFileAsync.DEFAULT_COLOR, log);
				}
				stopwatch3.Stop();
				if (!base.Blocks.hasRootBlock)
				{
					base.Blocks._0023_003Dz2tUjc04_003D();
					base.Units = _0023_003DzFuePbj8_003D._0023_003DzGdfaeVqs6Ch4();
				}
				if (flag)
				{
					base.Entities.AddRange(list);
					base.Entities.AddRange(_0023_003DzFuePbj8_003D._0023_003DzYdnRH2i7V2MYsWcTs0KLmYuxuw_u6nrQxQ_003D_003D(base.Blocks, base.Entities));
					result = true;
				}
			}
			log.AppendLine(_0023_003DzFuePbj8_003D._0023_003DzqmF8XJ0_003D.ToString());
		}
		catch (Exception ex)
		{
			log.AppendLine(ex.Message);
		}
		finally
		{
			CloseStream();
		}
		base.Result = result;
	}

	private void _0023_003DzQA5Qm4bVRLLt(_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D _0023_003DzgyYoHow_003D)
	{
		base.Blocks.SetRootBlock(_0023_003DzgyYoHow_003D._0023_003DzwKyKajk_003D());
		base.Units = _0023_003DzgyYoHow_003D._0023_003DzrdvTjeaFTRlY;
	}

	private void _0023_003DzmJCVjbsxglhj(_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D _0023_003DzvEK0wYGrwe47)
	{
		foreach (_0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D item in _0023_003DzvEK0wYGrwe47._0023_003Dz5bVmMWCNZpiUDgO8rg_003D_003D())
		{
			if (!string.IsNullOrEmpty(item._0023_003DzaROjBYA_003D))
			{
				_0023_003DzmJCVjbsxglhj(item._0023_003DzaROjBYA_003D);
			}
		}
		foreach (_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D item2 in _0023_003DzvEK0wYGrwe47._0023_003DzgqVFrJs0QtPIONrKBA_003D_003D())
		{
			if (!string.IsNullOrEmpty(item2._0023_003DzaROjBYA_003D))
			{
				_0023_003DzmJCVjbsxglhj(item2._0023_003DzaROjBYA_003D);
			}
		}
		foreach (_0023_003DzbykJA36oCfUxYTgeaw_003D_003D item3 in _0023_003DzvEK0wYGrwe47._0023_003Dzxx_002446o_8u86uTFn5zvF0vf4_003D())
		{
			if (!string.IsNullOrEmpty(item3._0023_003DzaROjBYA_003D))
			{
				_0023_003DzmJCVjbsxglhj(item3._0023_003DzaROjBYA_003D);
			}
		}
		foreach (_0023_003DzAI9YqCWKp0mYYODw1A_003D_003D item4 in _0023_003DzvEK0wYGrwe47._0023_003Dz8MhX3Upx2CLrK047OvWq8TopyPeP())
		{
			if (!string.IsNullOrEmpty(item4._0023_003DzaROjBYA_003D))
			{
				_0023_003DzmJCVjbsxglhj(item4._0023_003DzaROjBYA_003D);
			}
		}
		foreach (_0023_003Dzss6PgCjYIzY9kelPFc5_0024jiI_003D item5 in _0023_003DzvEK0wYGrwe47._0023_003Dz0Qlny0aPeP3aIzMwUJTIDhg_003D())
		{
			if (!string.IsNullOrEmpty(item5._0023_003DzaROjBYA_003D))
			{
				_0023_003DzmJCVjbsxglhj(item5._0023_003DzaROjBYA_003D);
			}
		}
		foreach (_0023_003DzvIQID_0024KC_OBm3i8fWRGKUyHCcX_7 item6 in _0023_003DzvEK0wYGrwe47._0023_003DzGTkZYpnBz8X7VQfs69384bQCzLiN())
		{
			if (!string.IsNullOrEmpty(item6._0023_003DzaROjBYA_003D))
			{
				_0023_003DzmJCVjbsxglhj(item6._0023_003DzaROjBYA_003D);
			}
		}
	}

	private bool _0023_003DzVDcNmfZ3BSUSx5imXQ_003D_003D(_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D _0023_003DzgyYoHow_003D)
	{
		if ((_0023_003DzgyYoHow_003D._0023_003Dz0Qlny0aPeP3aIzMwUJTIDhg_003D().Count > 0 || _0023_003DzgyYoHow_003D._0023_003DzGTkZYpnBz8X7VQfs69384bQCzLiN().Count > 0) && _0023_003DzgyYoHow_003D._0023_003Dz5bVmMWCNZpiUDgO8rg_003D_003D().Count == 0 && _0023_003DzgyYoHow_003D._0023_003Dzxx_002446o_8u86uTFn5zvF0vf4_003D().Count == 0 && _0023_003DzgyYoHow_003D._0023_003Dz8MhX3Upx2CLrK047OvWq8TopyPeP().Count == 0)
		{
			using (List<_0023_003Dzss6PgCjYIzY9kelPFc5_0024jiI_003D>.Enumerator enumerator = _0023_003DzgyYoHow_003D._0023_003Dz0Qlny0aPeP3aIzMwUJTIDhg_003D().GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					return enumerator.Current._0023_003DzWQCyvnY_003D.Count > 1;
				}
			}
			using List<_0023_003DzvIQID_0024KC_OBm3i8fWRGKUyHCcX_7>.Enumerator enumerator2 = _0023_003DzgyYoHow_003D._0023_003DzGTkZYpnBz8X7VQfs69384bQCzLiN().GetEnumerator();
			if (enumerator2.MoveNext())
			{
				return enumerator2.Current._0023_003DzWQCyvnY_003D.Count > 1;
			}
		}
		return false;
	}

	private bool _0023_003Dzr_0024hOH5GNl08uCuRBhUR8Foc_003D(_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D _0023_003DzgyYoHow_003D)
	{
		if (_0023_003DzgyYoHow_003D._0023_003Dz0Qlny0aPeP3aIzMwUJTIDhg_003D().Count == 0 && _0023_003DzgyYoHow_003D._0023_003DzGTkZYpnBz8X7VQfs69384bQCzLiN().Count == 0 && _0023_003DzgyYoHow_003D._0023_003Dz5bVmMWCNZpiUDgO8rg_003D_003D().Count == 0 && _0023_003DzgyYoHow_003D._0023_003Dzxx_002446o_8u86uTFn5zvF0vf4_003D().Count == 0)
		{
			return _0023_003DzgyYoHow_003D._0023_003Dz8MhX3Upx2CLrK047OvWq8TopyPeP().Count > 0;
		}
		return false;
	}

	private void _0023_003Dz1Dz7wB5x_0024rjg(object _0023_003Dz9VjL5i0_003D, ProgressChangedEventArgs _0023_003DzbfrNXYE_003D)
	{
		if (!UpdateProgressAndCheckCancelled(_0023_003DzbfrNXYE_003D.Progress, 100.0, base.ReadingText, _0023_003DzsWnj47U_003D, _0023_003DzEBehidw_003D))
		{
			_0023_003DzFuePbj8_003D._0023_003DzBcvxv10_003D = true;
		}
	}

	private StringCollection _0023_003DziHPCStPfeCG0()
	{
		StringCollection stringCollection = new StringCollection();
		TextReader textReader = new StreamReader(base.Stream, Encoding.ASCII);
		string value;
		while ((value = textReader.ReadLine()) != null)
		{
			stringCollection.Add(value);
		}
		return stringCollection;
	}

	private static void _0023_003DzGbivSLIUtN3a(List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003DzWQCyvnY_003D, SortedList<int, Entity> _0023_003DzWc9WmS8VMsuA, angularUnitsType _0023_003DzPtQTcKPKNs_Eyhu_nA_003D_003D, bool _0023_003DzeN7PJhbg6omH, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, Color _0023_003DzIhNtV_00248_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		foreach (_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D item in _0023_003DzWQCyvnY_003D)
		{
			Entity entity = _0023_003DzAGR5R0fXZIaU(item, _0023_003DzPtQTcKPKNs_Eyhu_nA_003D_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzeN7PJhbg6omH, _0023_003DzIhNtV_00248_003D, _0023_003DzqmF8XJ0_003D);
			if (entity != null)
			{
				_0023_003DzWc9WmS8VMsuA.Add(item._0023_003DzkXQ_IWk_003D, entity);
			}
		}
	}

	private static Entity _0023_003DzAGR5R0fXZIaU(_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D _0023_003Dzmx8Td5k_003D, angularUnitsType _0023_003DzPtQTcKPKNs_Eyhu_nA_003D_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, bool _0023_003DzeN7PJhbg6omH, Color _0023_003DzIhNtV_00248_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		Entity entity = null;
		double[] array = null;
		if (_0023_003Dzmx8Td5k_003D is _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu)
		{
			_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu2 = (_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu)_0023_003Dzmx8Td5k_003D;
			entity = new devDept.Eyeshot.Entities.Point(_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu2._0023_003Dzfj_WbJ59_mOa()[0], _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu2._0023_003Dzfj_WbJ59_mOa()[1], _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu2._0023_003Dzfj_WbJ59_mOa()[2], 4f);
			if (_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu2._0023_003Dzwtld1NM_003D != null)
			{
				array = _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu2._0023_003Dzwtld1NM_003D;
			}
		}
		else if (_0023_003Dzmx8Td5k_003D is _0023_003DzFT7Vc5dpUBYChSz4Hg_003D_003D)
		{
			_0023_003DzFT7Vc5dpUBYChSz4Hg_003D_003D _0023_003DzFT7Vc5dpUBYChSz4Hg_003D_003D2 = (_0023_003DzFT7Vc5dpUBYChSz4Hg_003D_003D)_0023_003Dzmx8Td5k_003D;
			entity = (Entity)_0023_003DzKttMWhHGVu_0024c(new _0023_003DzAesEZlpt4n5DGdrqIA_003D_003D(_0023_003DzFT7Vc5dpUBYChSz4Hg_003D_003D2), _0023_003DzPtQTcKPKNs_Eyhu_nA_003D_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D, _0023_003DzvFB_0024dbs_003D: false);
			if (entity != null && _0023_003DzFT7Vc5dpUBYChSz4Hg_003D_003D2._0023_003Dzwtld1NM_003D != null)
			{
				array = _0023_003DzFT7Vc5dpUBYChSz4Hg_003D_003D2._0023_003Dzwtld1NM_003D;
			}
		}
		else if (_0023_003Dzmx8Td5k_003D is _0023_003DzoN1h6yqJFVWj8ubhaEpBZ9c_003D)
		{
			_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2 = new _0023_003DzbykJA36oCfUxYTgeaw_003D_003D(_0023_003Dzmx8Td5k_003D);
			entity = _0023_003Dz8zHhNtYS2dWIWKY9CFsyqPc_003D(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2, new ICurve[0], _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D)[0];
			if (entity != null && _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003Dzwtld1NM_003D != null)
			{
				array = _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003Dzwtld1NM_003D;
			}
		}
		else if (_0023_003Dzmx8Td5k_003D is _0023_003DzNZxQKnVfs5Wq6nrJpw_003D_003D)
		{
			_0023_003DzNZxQKnVfs5Wq6nrJpw_003D_003D _0023_003DzNZxQKnVfs5Wq6nrJpw_003D_003D2 = (_0023_003DzNZxQKnVfs5Wq6nrJpw_003D_003D)_0023_003Dzmx8Td5k_003D;
			List<ICurve> list = new List<ICurve>();
			foreach (_0023_003Dz0PtOsx4SvG1pVHiJnQ_003D_003D item in _0023_003DzNZxQKnVfs5Wq6nrJpw_003D_003D2._0023_003Dz74aNC9BwBiJM)
			{
				_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D obj = new _0023_003DzAesEZlpt4n5DGdrqIA_003D_003D(item._0023_003DztRK2XbIlF_oN);
				obj._0023_003Dzbtz8t3g_003D(item._0023_003DztRK2XbIlF_oN._0023_003DzkXQ_IWk_003D);
				ICurve curve = _0023_003DzKttMWhHGVu_0024c(obj, _0023_003DzPtQTcKPKNs_Eyhu_nA_003D_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D, _0023_003DzvFB_0024dbs_003D: false);
				if (curve != null)
				{
					if (item._0023_003DzMMEwsYMQlmIf.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920531)))
					{
						curve.Reverse();
					}
					list.Add(curve);
				}
			}
			if (list.Count > 0)
			{
				if (_0023_003DzNZxQKnVfs5Wq6nrJpw_003D_003D2._0023_003Dzwtld1NM_003D != null)
				{
					array = _0023_003DzNZxQKnVfs5Wq6nrJpw_003D_003D2._0023_003Dzwtld1NM_003D;
				}
				entity = new CompositeCurve(list, sortAndOrient: false);
			}
		}
		else
		{
			_0023_003Dz5Jz5OGqW4jVrPMRtqmZyFNc_003D _0023_003Dz5Jz5OGqW4jVrPMRtqmZyFNc_003D2 = _0023_003Dzmx8Td5k_003D as _0023_003Dz5Jz5OGqW4jVrPMRtqmZyFNc_003D;
			entity = ((!(_0023_003Dz5Jz5OGqW4jVrPMRtqmZyFNc_003D2 != null && _0023_003DzeN7PJhbg6omH)) ? ((Entity)_0023_003DzZpSyWoKjbrWE(new _0023_003DzAesEZlpt4n5DGdrqIA_003D_003D(_0023_003Dzmx8Td5k_003D), _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D, _0023_003DzvFB_0024dbs_003D: false)) : _0023_003DzuTCwRvbXUrZU(new _0023_003DzbykJA36oCfUxYTgeaw_003D_003D(_0023_003Dz5Jz5OGqW4jVrPMRtqmZyFNc_003D2), _0023_003DzPtQTcKPKNs_Eyhu_nA_003D_003D, _0023_003DzIhNtV_00248_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D)[0]);
			if (entity != null && _0023_003Dzmx8Td5k_003D._0023_003Dzwtld1NM_003D != null && _0023_003Dzmx8Td5k_003D._0023_003Dzwtld1NM_003D[0] >= 0.0)
			{
				array = _0023_003Dzmx8Td5k_003D._0023_003Dzwtld1NM_003D;
			}
		}
		if (entity != null)
		{
			if (array != null)
			{
				entity.ColorMethod = colorMethodType.byEntity;
				entity.Color = Utility.DoubleArrayToColor(array);
			}
			if (_0023_003Dzmx8Td5k_003D._0023_003DztIaJjPw_003D != null && !_0023_003DzeN7PJhbg6omH)
			{
				entity.LayerName = _0023_003Dzmx8Td5k_003D._0023_003DzaROjBYA_003D;
			}
			return entity;
		}
		_0023_003DzqmF8XJ0_003D.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010891), _0023_003Dzmx8Td5k_003D._0023_003DzkXQ_IWk_003D));
		return null;
	}

	private static Block _0023_003DzdV9Pg_0024iCjrqs(_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D _0023_003DzvEK0wYGrwe47, angularUnitsType _0023_003DzDSV3KvHUSDa4, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		string text = _0023_003DzvEK0wYGrwe47._0023_003DzwKyKajk_003D();
		Block block = new Block(text);
		block.Units = _0023_003DzvEK0wYGrwe47._0023_003DzrdvTjeaFTRlY;
		Color color = _0023_003Dz_8C3BH8_003D(_0023_003DzvEK0wYGrwe47._0023_003Dzwtld1NM_003D);
		foreach (_0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D item in _0023_003DzvEK0wYGrwe47._0023_003Dz5bVmMWCNZpiUDgO8rg_003D_003D())
		{
			Color _0023_003Dz1MMYB1g_003D = color;
			if (item._0023_003Dzwtld1NM_003D != null && item._0023_003Dzwtld1NM_003D[0] != -1.0)
			{
				_0023_003Dz1MMYB1g_003D = Color.FromArgb((int)(item._0023_003Dzwtld1NM_003D[0] * 255.0), (int)(item._0023_003Dzwtld1NM_003D[1] * 255.0), (int)(item._0023_003Dzwtld1NM_003D[2] * 255.0));
			}
			Brep brep = _0023_003DztU91JDk_003D(_0023_003DzvEK0wYGrwe47, _0023_003DzDSV3KvHUSDa4, item, ref _0023_003Dz1MMYB1g_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D);
			if (brep != null)
			{
				brep.ColorMethod = colorMethodType.byEntity;
				brep.Color = _0023_003Dz1MMYB1g_003D;
				if (item._0023_003DzaROjBYA_003D != null)
				{
					brep.LayerName = item._0023_003DzaROjBYA_003D;
				}
				brep.TranslationID = new TranslationIdentifier(item._0023_003DzkXQ_IWk_003D, item._0023_003DzS_00246o7tc_003D);
				block.Entities.Add(brep);
			}
			else
			{
				_0023_003DzqmF8XJ0_003D.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010836), item._0023_003DzkXQ_IWk_003D, text));
			}
		}
		foreach (_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D item2 in _0023_003DzvEK0wYGrwe47._0023_003DzgqVFrJs0QtPIONrKBA_003D_003D())
		{
			Color color2 = color;
			if (item2._0023_003Dzwtld1NM_003D != null && item2._0023_003Dzwtld1NM_003D[0] != -1.0)
			{
				color2 = Color.FromArgb((int)(item2._0023_003Dzwtld1NM_003D[0] * 255.0), (int)(item2._0023_003Dzwtld1NM_003D[1] * 255.0), (int)(item2._0023_003Dzwtld1NM_003D[2] * 255.0));
			}
			foreach (Mesh item3 in _0023_003Dzh7GYg1aQoczeFVgORDu9DRj7xo8ThXX6cg_BxfE_003D(item2))
			{
				item3.ColorMethod = colorMethodType.byEntity;
				item3.Color = color2;
				if (item2._0023_003DzaROjBYA_003D != null)
				{
					item3.LayerName = item2._0023_003DzaROjBYA_003D;
				}
				item3.TranslationID = new TranslationIdentifier(item2._0023_003DzkXQ_IWk_003D, item2._0023_003DzS_00246o7tc_003D);
				block.Entities.Add(item3);
			}
		}
		SortedList<int, Entity[]> sortedList = new SortedList<int, Entity[]>();
		_0023_003Dzg3ZmdZy8VZ_0024fU_XC_0024g_003D_003D(_0023_003DzvEK0wYGrwe47._0023_003Dzxx_002446o_8u86uTFn5zvF0vf4_003D(), sortedList, _0023_003DzDSV3KvHUSDa4, color, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D);
		foreach (KeyValuePair<int, Entity[]> item4 in sortedList)
		{
			block.Entities.AddRange(item4.Value);
		}
		foreach (_0023_003DzAI9YqCWKp0mYYODw1A_003D_003D item5 in _0023_003DzvEK0wYGrwe47._0023_003Dz8MhX3Upx2CLrK047OvWq8TopyPeP())
		{
			SortedList<int, Entity[]> sortedList2 = new SortedList<int, Entity[]>();
			_0023_003Dzg3ZmdZy8VZ_0024fU_XC_0024g_003D_003D(item5._0023_003DzJ9shYljglKVu, sortedList2, _0023_003DzDSV3KvHUSDa4, color, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D);
			foreach (KeyValuePair<int, Entity[]> item6 in sortedList2)
			{
				Entity[] value = item6.Value;
				for (int i = 0; i < value.Length; i++)
				{
					_0023_003DzZUJ_Pfo8i0Hg(value[i], item5._0023_003Dzwtld1NM_003D);
				}
			}
			foreach (KeyValuePair<int, Entity[]> item7 in sortedList2)
			{
				block.Entities.AddRange(item7.Value);
			}
		}
		List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> list = new List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>();
		foreach (_0023_003Dzss6PgCjYIzY9kelPFc5_0024jiI_003D item8 in _0023_003DzvEK0wYGrwe47._0023_003Dzj3ms8um3cUs7ghjFng_003D_003D)
		{
			list.AddRange(item8._0023_003DzWQCyvnY_003D);
		}
		foreach (_0023_003DzvIQID_0024KC_OBm3i8fWRGKUyHCcX_7 item9 in _0023_003DzvEK0wYGrwe47._0023_003DzGTkZYpnBz8X7VQfs69384bQCzLiN())
		{
			list.AddRange(item9._0023_003DzWQCyvnY_003D);
		}
		_0023_003DzfFve6xSqWrFIQ_TSuA_003D_003D(list, _0023_003DzDSV3KvHUSDa4, block.Entities, _0023_003DzeN7PJhbg6omH: true, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, color, _0023_003DzqmF8XJ0_003D);
		return block;
	}

	private static void _0023_003DzfFve6xSqWrFIQ_TSuA_003D_003D(List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003DzU5EesyPOGtTt2try8Q_003D_003D, angularUnitsType _0023_003DzDSV3KvHUSDa4, IList<Entity> _0023_003DzWc9WmS8VMsuA, bool _0023_003DzeN7PJhbg6omH, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, Color _0023_003DzIhNtV_00248_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		SortedList<int, Entity> sortedList = new SortedList<int, Entity>();
		_0023_003DzGbivSLIUtN3a(_0023_003DzU5EesyPOGtTt2try8Q_003D_003D, sortedList, _0023_003DzDSV3KvHUSDa4, _0023_003DzeN7PJhbg6omH, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzIhNtV_00248_003D, _0023_003DzqmF8XJ0_003D);
		foreach (Entity value in sortedList.Values)
		{
			_0023_003DzWc9WmS8VMsuA.Add(value);
		}
	}

	private static void _0023_003Dzg3ZmdZy8VZ_0024fU_XC_0024g_003D_003D(IList<_0023_003DzbykJA36oCfUxYTgeaw_003D_003D> _0023_003DzEHqFVzMAt7Lc, SortedList<int, Entity[]> _0023_003DzrxLRsss3tg14, angularUnitsType _0023_003DzDSV3KvHUSDa4, Color _0023_003Dz1MMYB1g_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		int count = _0023_003DzEHqFVzMAt7Lc.Count;
		for (int i = 0; i < count; i++)
		{
			_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2 = _0023_003DzEHqFVzMAt7Lc[i];
			Entity[] value = _0023_003DzuTCwRvbXUrZU(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2, _0023_003DzDSV3KvHUSDa4, _0023_003Dz1MMYB1g_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D);
			_0023_003DzrxLRsss3tg14.Add(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003DzkXQ_IWk_003D, value);
		}
	}

	private static void _0023_003DzZUJ_Pfo8i0Hg(Entity _0023_003Dzs_0024uS8LA_003D, double[] _0023_003Dzwtld1NM_003D)
	{
		if (_0023_003Dzwtld1NM_003D != null && _0023_003Dzwtld1NM_003D[0] != -1.0)
		{
			_0023_003Dzs_0024uS8LA_003D.Color = Color.FromArgb((int)(_0023_003Dzwtld1NM_003D[0] * 255.0), (int)(_0023_003Dzwtld1NM_003D[1] * 255.0), (int)(_0023_003Dzwtld1NM_003D[2] * 255.0));
		}
	}

	private void _0023_003DzdV9Pg_0024iCjrqs(_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D _0023_003DzvEK0wYGrwe47, BlockKeyedCollection _0023_003DzJO1FWlQ_003D)
	{
		Block block = _0023_003DzJO1FWlQ_003D[_0023_003DzvEK0wYGrwe47._0023_003DzwKyKajk_003D()];
		if (_0023_003DzvEK0wYGrwe47._0023_003DzyePFrIIHO6NHR_hL8Q_003D_003D().Count <= 0)
		{
			return;
		}
		foreach (_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D item in _0023_003DzvEK0wYGrwe47._0023_003DzyePFrIIHO6NHR_hL8Q_003D_003D())
		{
			_0023_003DzgYYyKHHdTz0g(item, block.Entities, block.Units, _0023_003DzJO1FWlQ_003D);
		}
	}

	private static Color _0023_003Dz_8C3BH8_003D(double[] _0023_003Dzwtld1NM_003D)
	{
		Color result = ReadFileAsync.DEFAULT_COLOR;
		if (_0023_003Dzwtld1NM_003D[0] != -1.0)
		{
			int value = (int)(_0023_003Dzwtld1NM_003D[0] * 255.0);
			int value2 = (int)(_0023_003Dzwtld1NM_003D[1] * 255.0);
			int value3 = (int)(_0023_003Dzwtld1NM_003D[2] * 255.0);
			Utility.LimitRange(0, ref value, 255);
			Utility.LimitRange(0, ref value2, 255);
			Utility.LimitRange(0, ref value3, 255);
			result = Color.FromArgb(value, value2, value3);
		}
		return result;
	}

	private static Brep _0023_003DztU91JDk_003D(_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D _0023_003DzvEK0wYGrwe47, angularUnitsType _0023_003DzDSV3KvHUSDa4, _0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D _0023_003DzrtuC07k_003D, ref Color _0023_003Dz1MMYB1g_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		List<_0023_003DzbykJA36oCfUxYTgeaw_003D_003D> list = ((_0023_003DzrtuC07k_003D._0023_003Dz_SqBXz8_003D._0023_003DzhgFnmaGvC_0024XSiODxhcHkTrz5ZD6D().Count <= 0 && _0023_003DzrtuC07k_003D._0023_003Dzdo4hrfm6Vp4YCtMIhA_003D_003D().Count <= 0) ? _0023_003DzvEK0wYGrwe47._0023_003Dzxx_002446o_8u86uTFn5zvF0vf4_003D() : ((_0023_003DzrtuC07k_003D._0023_003Dz_SqBXz8_003D._0023_003DzhgFnmaGvC_0024XSiODxhcHkTrz5ZD6D().Count > 0) ? _0023_003DzrtuC07k_003D._0023_003Dz_SqBXz8_003D._0023_003DzhgFnmaGvC_0024XSiODxhcHkTrz5ZD6D() : _0023_003DzrtuC07k_003D._0023_003Dzdo4hrfm6Vp4YCtMIhA_003D_003D()));
		Brep.Face[] array = _0023_003DzYm_0024NZRCNgy0n(list, ref _0023_003Dz1MMYB1g_003D, _0023_003DzqmF8XJ0_003D);
		if (array.Length == 0)
		{
			_0023_003DzqmF8XJ0_003D.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011049), _0023_003DzrtuC07k_003D._0023_003DzkXQ_IWk_003D));
			return null;
		}
		Brep.Face[][] array2 = new Brep.Face[_0023_003DzrtuC07k_003D._0023_003DzWaFlkhfmYCja.Count][];
		for (int i = 0; i < _0023_003DzrtuC07k_003D._0023_003DzWaFlkhfmYCja.Count; i++)
		{
			_0023_003DzSO_l6Vl7Ap5t _0023_003DzSO_l6Vl7Ap5t2 = _0023_003DzrtuC07k_003D._0023_003DzWaFlkhfmYCja[i];
			Color _0023_003Dz1MMYB1g_003D2 = Color.Empty;
			array2[i] = _0023_003DzYm_0024NZRCNgy0n(_0023_003DzSO_l6Vl7Ap5t2._0023_003DzhgFnmaGvC_0024XSiODxhcHkTrz5ZD6D(), ref _0023_003Dz1MMYB1g_003D2, _0023_003DzqmF8XJ0_003D);
		}
		Brep.Edge[] _0023_003DzcFqhPo_0024Q_0024jYE = new Brep.Edge[_0023_003DzrtuC07k_003D._0023_003DzoUKdLJ07SqncwEpiY_J9evZ_0024S2M7().Count];
		int num = 0;
		SortedDictionary<int, _0023_003DzAesEZlpt4n5DGdrqIA_003D_003D> sortedDictionary = new SortedDictionary<int, _0023_003DzAesEZlpt4n5DGdrqIA_003D_003D>();
		foreach (DictionaryEntry item in _0023_003DzrtuC07k_003D._0023_003DzoUKdLJ07SqncwEpiY_J9evZ_0024S2M7())
		{
			sortedDictionary.Add((int)item.Key, (_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D)item.Value);
		}
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (KeyValuePair<int, _0023_003DzAesEZlpt4n5DGdrqIA_003D_003D> item2 in sortedDictionary)
		{
			ICurve curve = _0023_003DzKttMWhHGVu_0024c(item2.Value, _0023_003DzDSV3KvHUSDa4, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D, _0023_003DzvFB_0024dbs_003D: true);
			if (curve == null)
			{
				return null;
			}
			_0023_003DzcFqhPo_0024Q_0024jYE[num] = new Brep.Edge(curve, item2.Value._0023_003Dz6jhwFaVMbWdi[0], item2.Value._0023_003Dz6jhwFaVMbWdi[1]);
			if (!string.IsNullOrEmpty(item2.Value._0023_003DzvMpuALLjCnb5()))
			{
				_0023_003DzcFqhPo_0024Q_0024jYE[num].TranslationID = new TranslationIdentifier(item2.Value._0023_003DzvMpuALLjCnb5());
			}
			dictionary.Add(item2.Key, num);
			num++;
		}
		_0023_003DzgmXRCgEUmKOC(array, dictionary);
		Brep.Face[][] array3 = array2;
		for (int j = 0; j < array3.Length; j++)
		{
			_0023_003DzgmXRCgEUmKOC(array3[j], dictionary);
		}
		_0023_003DzcKLtULL1zfVM(0, list, array, _0023_003DzDSV3KvHUSDa4, _0023_003DzcFqhPo_0024Q_0024jYE, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D);
		if (array.Length == 1 && array[0].Loops.Length == 0)
		{
			if (array[0].Surface is SphericalSurf sphericalSurf)
			{
				Brep brep = Brep.CreateSphere(sphericalSurf.Radius);
				Align3D xform = new Align3D(Plane.XY, sphericalSurf.Plane);
				brep.TransformBy(xform);
				brep.Faces[0].FaceData = array[0].FaceData;
				return brep;
			}
			if (array[0].Surface is ToroidalSurf toroidalSurf)
			{
				Brep brep2 = Brep.CreateTorus(toroidalSurf.MajorRadius, toroidalSurf.MinorRadius);
				Align3D xform2 = new Align3D(Plane.XY, toroidalSurf.Plane);
				brep2.TransformBy(xform2);
				brep2.Faces[0].FaceData = array[0].FaceData;
				return brep2;
			}
		}
		for (int k = 0; k < array2.Length; k++)
		{
			_0023_003DzcKLtULL1zfVM(k + 1, _0023_003DzrtuC07k_003D._0023_003DzWaFlkhfmYCja[k]._0023_003DzhgFnmaGvC_0024XSiODxhcHkTrz5ZD6D(), array2[k], _0023_003DzDSV3KvHUSDa4, _0023_003DzcFqhPo_0024Q_0024jYE, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D);
		}
		_0023_003DzT8BrqTaQSUULmuCCgA_003D_003D(array, array2, ref _0023_003DzcFqhPo_0024Q_0024jYE);
		Point3D[] array4 = new Point3D[_0023_003DzrtuC07k_003D._0023_003Dzh9F04UKljiptfYUZsv3K5Yw67tP_().Count];
		num = 0;
		Dictionary<int, _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D> dictionary2 = new Dictionary<int, _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D>();
		foreach (DictionaryEntry item3 in _0023_003DzrtuC07k_003D._0023_003Dzh9F04UKljiptfYUZsv3K5Yw67tP_())
		{
			dictionary2.Add((int)item3.Key, (_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D)item3.Value);
		}
		dictionary.Clear();
		foreach (KeyValuePair<int, _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D> item4 in dictionary2)
		{
			Brep.Vertex vertex = new Brep.Vertex(item4.Value._0023_003Dzfj_WbJ59_mOa());
			array4[num] = vertex;
			dictionary.Add(item4.Key, num);
			num++;
		}
		List<int>[] array5 = new List<int>[num];
		for (int l = 0; l < array5.Length; l++)
		{
			array5[l] = new List<int>();
		}
		for (int m = 0; m < _0023_003DzcFqhPo_0024Q_0024jYE.Length; m++)
		{
			Brep.Edge edge = _0023_003DzcFqhPo_0024Q_0024jYE[m];
			edge.Curve.EdgeIndex = m;
			edge.StartPointIndex = dictionary[edge.StartPointIndex];
			array5[edge.StartPointIndex].Add(m);
			edge.EndPointIndex = dictionary[edge.EndPointIndex];
			if (edge.StartPointIndex != edge.EndPointIndex)
			{
				array5[edge.EndPointIndex].Add(m);
			}
		}
		for (int n = 0; n < array5.Length; n++)
		{
			((Brep.Vertex)array4[n]).Parents = array5[n].ToArray();
		}
		Brep brep3 = new Brep(array4, _0023_003DzcFqhPo_0024Q_0024jYE, array, _0023_003DzqMxdROkOZ2gG: false, array2, _0023_003DzPPoX8HETqTZN: true, _0023_003DzMcq9hcRIFsnaUZ3PgA_003D_003D: true, _0023_003DzqmF8XJ0_003D);
		brep3.TranslationID = new TranslationIdentifier(_0023_003DzrtuC07k_003D._0023_003DzkXQ_IWk_003D, _0023_003DzrtuC07k_003D._0023_003DzS_00246o7tc_003D);
		brep3.FixNormals();
		return brep3;
	}

	private static void _0023_003DzT8BrqTaQSUULmuCCgA_003D_003D(Brep.Face[] _0023_003DzEtn4dIEPKCsi, Brep.Face[][] _0023_003DzVLTh9isP_0024CHC4DKhuw_003D_003D, ref Brep.Edge[] _0023_003DzcFqhPo_0024Q_0024jYE)
	{
		int num = _0023_003DzcFqhPo_0024Q_0024jYE.Length;
		int _0023_003DzOLlPXUiTRICp = 0;
		bool[] array = new bool[num];
		_0023_003DzwbdcWBHTfdOY0n9DrJRAjJM_003D(_0023_003DzEtn4dIEPKCsi, array, ref _0023_003DzOLlPXUiTRICp);
		Brep.Face[][] array2 = _0023_003DzVLTh9isP_0024CHC4DKhuw_003D_003D;
		for (int i = 0; i < array2.Length; i++)
		{
			_0023_003DzwbdcWBHTfdOY0n9DrJRAjJM_003D(array2[i], array, ref _0023_003DzOLlPXUiTRICp);
		}
		int[] array3 = new int[num];
		int num2 = 0;
		for (int j = 0; j < num; j++)
		{
			if (array[j])
			{
				array3[j] = num2;
				num2++;
			}
			else
			{
				array3[j] = -1;
			}
		}
		Brep.Edge[] array4 = new Brep.Edge[_0023_003DzOLlPXUiTRICp];
		_0023_003Dzy_0024dxITXnfcEnWuFRERLgrqc_003D(_0023_003DzEtn4dIEPKCsi, array3);
		array2 = _0023_003DzVLTh9isP_0024CHC4DKhuw_003D_003D;
		for (int i = 0; i < array2.Length; i++)
		{
			_0023_003Dzy_0024dxITXnfcEnWuFRERLgrqc_003D(array2[i], array3);
		}
		num2 = 0;
		for (int k = 0; k < num; k++)
		{
			if (array[k])
			{
				array4[num2] = _0023_003DzcFqhPo_0024Q_0024jYE[k];
				num2++;
			}
		}
		_0023_003DzcFqhPo_0024Q_0024jYE = array4;
	}

	private static void _0023_003DzwbdcWBHTfdOY0n9DrJRAjJM_003D(Brep.Face[] _0023_003DzEtn4dIEPKCsi, bool[] _0023_003DzOdWUsPilVdS7, ref int _0023_003DzOLlPXUiTRICp)
	{
		for (int i = 0; i < _0023_003DzEtn4dIEPKCsi.Length; i++)
		{
			Brep.Loop[] loops = _0023_003DzEtn4dIEPKCsi[i].Loops;
			foreach (Brep.Loop loop in loops)
			{
				for (int k = 0; k < loop.Segments.Length; k++)
				{
					int curveIndex = loop.Segments[k].CurveIndex;
					if (!_0023_003DzOdWUsPilVdS7[curveIndex])
					{
						_0023_003DzOdWUsPilVdS7[curveIndex] = true;
						_0023_003DzOLlPXUiTRICp++;
					}
				}
			}
		}
	}

	private static void _0023_003Dzy_0024dxITXnfcEnWuFRERLgrqc_003D(Brep.Face[] _0023_003DzEtn4dIEPKCsi, int[] _0023_003DzCS02Bu0_003D)
	{
		for (int i = 0; i < _0023_003DzEtn4dIEPKCsi.Length; i++)
		{
			Brep.Loop[] loops = _0023_003DzEtn4dIEPKCsi[i].Loops;
			foreach (Brep.Loop loop in loops)
			{
				for (int k = 0; k < loop.Segments.Length; k++)
				{
					loop.Segments[k].CurveIndex = _0023_003DzCS02Bu0_003D[loop.Segments[k].CurveIndex];
				}
			}
		}
	}

	private static void _0023_003DzgmXRCgEUmKOC(Brep.Face[] _0023_003DzEtn4dIEPKCsi, Dictionary<int, int> _0023_003DzqAZX1x0_003D)
	{
		for (int i = 0; i < _0023_003DzEtn4dIEPKCsi.Length; i++)
		{
			Brep.Loop[] loops = _0023_003DzEtn4dIEPKCsi[i].Loops;
			foreach (Brep.Loop loop in loops)
			{
				for (int k = 0; k < loop.Segments.Length; k++)
				{
					loop.Segments[k].CurveIndex = _0023_003DzqAZX1x0_003D[loop.Segments[k].CurveIndex];
				}
			}
		}
	}

	private static Brep.Face[] _0023_003DzYm_0024NZRCNgy0n(List<_0023_003DzbykJA36oCfUxYTgeaw_003D_003D> _0023_003DzLyHaVrbp8D6U, ref Color _0023_003Dz1MMYB1g_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		int num = _0023_003DzLyHaVrbp8D6U.Count;
		List<Brep.Face> list = new List<Brep.Face>(num);
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2 = _0023_003DzLyHaVrbp8D6U[i];
			if (_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003DzyXmKbtw_003D == null)
			{
				_0023_003DzqmF8XJ0_003D.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011003), _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003DzkXQ_IWk_003D));
				_0023_003DzLyHaVrbp8D6U.RemoveAt(i);
				i--;
				num--;
				continue;
			}
			Brep.Face face = new Brep.Face(null, new Brep.Loop[0]);
			face.FaceData = _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003Dzh5UrnhhPGlo6;
			if (_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003Dzwtld1NM_003D[0] != -1.0)
			{
				face.Color = Utility.DoubleArrayToColor(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003Dzwtld1NM_003D);
				num2++;
			}
			face.Sense = _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003Dz3teLb_0024wWvlUs();
			List<List<_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D>> _0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D = new List<List<_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D>>();
			int num3 = _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003DzYfPyUC209Tqonw07hA_003D_003D(ref _0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D);
			int count = _0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D.Count;
			List<Brep.Loop> list2 = new List<Brep.Loop>(count);
			for (int j = 0; j < count; j++)
			{
				if (_0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D[j].Count == 0)
				{
					num3--;
					continue;
				}
				Brep.OrientedEdge[] array = new Brep.OrientedEdge[_0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D[j].Count];
				for (int k = 0; k < _0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D[j].Count; k++)
				{
					array[k] = new Brep.OrientedEdge(_0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D[j][k]._0023_003DzOq3xSxQ_003D(), _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003DzB5NG_d2je_2o[j][k]);
				}
				Brep.Loop item = new Brep.Loop(array, _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003DzXX_L3TtKXHeHo4YpYg_003D_003D[j]);
				list2.Add(item);
			}
			if (num3 > 0)
			{
				Brep.Loop value = list2[0];
				list2[0] = list2[num3];
				list2[num3] = value;
			}
			face.Loops = list2.ToArray();
			list.Add(face);
		}
		if (list.Count > 0)
		{
			if (num2 == num)
			{
				bool flag = true;
				Color value2 = list.First().Color.Value;
				foreach (Brep.Face item2 in list)
				{
					if (item2.Color != value2)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					foreach (Brep.Face item3 in list)
					{
						item3.Color = null;
					}
					_0023_003Dz1MMYB1g_003D = value2;
				}
			}
			else if (num2 > 0)
			{
				foreach (Brep.Face item4 in list)
				{
					if (item4.Color.HasValue && item4.Color.Value == _0023_003Dz1MMYB1g_003D)
					{
						item4.Color = null;
					}
				}
			}
		}
		return list.ToArray();
	}

	private static void _0023_003DzaEO_0024fS_0024moyNJ(Brep.Face _0023_003DzHEpjcdg2hk9U, Brep.Edge[] _0023_003DzU3hosSAzkxO7)
	{
		for (int num = _0023_003DzHEpjcdg2hk9U.Loops.Length - 1; num >= 0; num--)
		{
			Brep.Loop loop = _0023_003DzHEpjcdg2hk9U.Loops[num];
			if (loop.Segments.Length == 1)
			{
				Brep.OrientedEdge orientedEdge = loop.Segments[0];
				if (_0023_003DzU3hosSAzkxO7[orientedEdge.CurveIndex].Curve is Line)
				{
					List<Brep.Loop> list = new List<Brep.Loop>(_0023_003DzHEpjcdg2hk9U.Loops);
					list.RemoveAt(num);
					_0023_003DzHEpjcdg2hk9U.Loops = list.ToArray();
				}
			}
		}
	}

	private bool _0023_003Dz9ZScR7PKQJdr(_0023_003DzfqmL8TzDtVBDf6_u_0024A_003D_003D _0023_003DzkKz7OWA_003D, IList<_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D> _0023_003DznAF4fNkMjAgi, SortedList<int, Block> _0023_003DzUf8_iZ90pWPR, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		_0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D CS_0024_003C_003E8__locals23 = new _0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D();
		CS_0024_003C_003E8__locals23._0023_003DznAF4fNkMjAgi = _0023_003DznAF4fNkMjAgi;
		CS_0024_003C_003E8__locals23._0023_003DzkKz7OWA_003D = _0023_003DzkKz7OWA_003D;
		CS_0024_003C_003E8__locals23._0023_003DzopRx0_MBcTQs = this;
		CS_0024_003C_003E8__locals23._0023_003DzmHS7frs_003D = _0023_003DzmHS7frs_003D;
		CS_0024_003C_003E8__locals23._0023_003Dzjvn7P10_003D = _0023_003Dzjvn7P10_003D;
		CS_0024_003C_003E8__locals23._0023_003DzUf8_iZ90pWPR = _0023_003DzUf8_iZ90pWPR;
		CS_0024_003C_003E8__locals23._0023_003Dz8If0AEk_003D = true;
		CS_0024_003C_003E8__locals23._0023_003Dz9JZgoew_003D = CS_0024_003C_003E8__locals23._0023_003DznAF4fNkMjAgi.Count;
		ResetProgressParallel();
		Parallel.For(0, CS_0024_003C_003E8__locals23._0023_003Dz9JZgoew_003D, () => new SortedDictionary<int, Block>(), delegate(int _0023_003Dz437_00244ak_003D, ParallelLoopState _0023_003DzLdZiL78_003D, SortedDictionary<int, Block> _0023_003Dzk9kSx4ZKN3L3)
		{
			_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2 = CS_0024_003C_003E8__locals23._0023_003DznAF4fNkMjAgi[_0023_003Dz437_00244ak_003D];
			StringBuilder stringBuilder = new StringBuilder();
			Block block = _0023_003DzdV9Pg_0024iCjrqs(_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2, CS_0024_003C_003E8__locals23._0023_003DzkKz7OWA_003D._0023_003DzUgQenuNv91OE(), CS_0024_003C_003E8__locals23._0023_003DzopRx0_MBcTQs._0023_003DzzwQaTmWKCeWkkbmQYg_003D_003D, stringBuilder);
			block.Description = stringBuilder.ToString();
			_0023_003Dzk9kSx4ZKN3L3.Add(_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003DzkXQ_IWk_003D, block);
			if (!CS_0024_003C_003E8__locals23._0023_003DzopRx0_MBcTQs.UpdateProgressAndCheckCancelledParallel(CS_0024_003C_003E8__locals23._0023_003Dz9JZgoew_003D, CS_0024_003C_003E8__locals23._0023_003DzopRx0_MBcTQs.ParsingText, CS_0024_003C_003E8__locals23._0023_003DzmHS7frs_003D, CS_0024_003C_003E8__locals23._0023_003Dzjvn7P10_003D))
			{
				CS_0024_003C_003E8__locals23._0023_003Dz8If0AEk_003D = false;
				_0023_003DzLdZiL78_003D.Stop();
			}
			return _0023_003Dzk9kSx4ZKN3L3;
		}, CS_0024_003C_003E8__locals23._0023_003Dz37Y9OZ7ptJscLcMqug_003D_003D);
		if (CS_0024_003C_003E8__locals23._0023_003Dz8If0AEk_003D)
		{
			UpdateProgressTo100(base.ParsingText, CS_0024_003C_003E8__locals23._0023_003DzmHS7frs_003D);
		}
		return CS_0024_003C_003E8__locals23._0023_003Dz8If0AEk_003D;
	}

	private bool _0023_003Dzg3ZmdZy8VZ_0024fU_XC_0024g_003D_003D(IList<_0023_003DzbykJA36oCfUxYTgeaw_003D_003D> _0023_003DzEHqFVzMAt7Lc, SortedList<int, Entity[]> _0023_003DzWc9WmS8VMsuA, angularUnitsType _0023_003DzDSV3KvHUSDa4, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		_0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D _0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2 = new _0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D();
		_0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003DzEHqFVzMAt7Lc = _0023_003DzEHqFVzMAt7Lc;
		_0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003DzDSV3KvHUSDa4 = _0023_003DzDSV3KvHUSDa4;
		_0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003DzopRx0_MBcTQs = this;
		_0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003DzmHS7frs_003D = _0023_003DzmHS7frs_003D;
		_0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003Dzjvn7P10_003D = _0023_003Dzjvn7P10_003D;
		_0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003DzWc9WmS8VMsuA = _0023_003DzWc9WmS8VMsuA;
		_0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003Dz8If0AEk_003D = true;
		_0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003Dz9JZgoew_003D = _0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003DzEHqFVzMAt7Lc.Count;
		ResetProgressParallel();
		Parallel.For(0, _0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003Dz9JZgoew_003D, () => new SortedList<int, Entity[]>(), _0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003DzyEi57kcmRM60UdJYDuvcXkFbXsNd, _0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003DzjF3dgXo9NcBvpEYURwerOVlDtGDS);
		if (_0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003Dz8If0AEk_003D)
		{
			UpdateProgressTo100(base.ParsingText, _0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003DzmHS7frs_003D);
		}
		return _0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003Dz8If0AEk_003D;
	}

	private bool _0023_003DzJKrq_00245CS229AkQbeuA_003D_003D(IList<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003DzcHBkf2AI2x89v1_0024zYw_003D_003D, SortedList<int, Entity[]> _0023_003DzWc9WmS8VMsuA, angularUnitsType _0023_003DzDSV3KvHUSDa4, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		_0023_003DzTvLfVfgMMlGE7THlqihsW1c_003D _0023_003DzTvLfVfgMMlGE7THlqihsW1c_003D2 = new _0023_003DzTvLfVfgMMlGE7THlqihsW1c_003D();
		_0023_003DzTvLfVfgMMlGE7THlqihsW1c_003D2._0023_003DzcHBkf2AI2x89v1_0024zYw_003D_003D = _0023_003DzcHBkf2AI2x89v1_0024zYw_003D_003D;
		_0023_003DzTvLfVfgMMlGE7THlqihsW1c_003D2._0023_003DzopRx0_MBcTQs = this;
		_0023_003DzTvLfVfgMMlGE7THlqihsW1c_003D2._0023_003DzmHS7frs_003D = _0023_003DzmHS7frs_003D;
		_0023_003DzTvLfVfgMMlGE7THlqihsW1c_003D2._0023_003Dzjvn7P10_003D = _0023_003Dzjvn7P10_003D;
		_0023_003DzTvLfVfgMMlGE7THlqihsW1c_003D2._0023_003DzWc9WmS8VMsuA = _0023_003DzWc9WmS8VMsuA;
		_0023_003DzTvLfVfgMMlGE7THlqihsW1c_003D2._0023_003Dz8If0AEk_003D = true;
		_0023_003DzTvLfVfgMMlGE7THlqihsW1c_003D2._0023_003Dz9JZgoew_003D = _0023_003DzTvLfVfgMMlGE7THlqihsW1c_003D2._0023_003DzcHBkf2AI2x89v1_0024zYw_003D_003D.Count;
		ResetProgressParallel();
		Parallel.For(0, _0023_003DzTvLfVfgMMlGE7THlqihsW1c_003D2._0023_003Dz9JZgoew_003D, _0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzQA70qW4gvm4HjXI7HKVHj36vPbeH, _0023_003DzTvLfVfgMMlGE7THlqihsW1c_003D2._0023_003DzlHPDMplmkYh5VxRyz4gHbdQ_003D, _0023_003DzTvLfVfgMMlGE7THlqihsW1c_003D2._0023_003Dzb0Ux2Cv18JEI5hC2PVxFPPo_003D);
		if (_0023_003DzTvLfVfgMMlGE7THlqihsW1c_003D2._0023_003Dz8If0AEk_003D)
		{
			UpdateProgressTo100(base.ParsingText, _0023_003DzTvLfVfgMMlGE7THlqihsW1c_003D2._0023_003DzmHS7frs_003D);
		}
		return _0023_003DzTvLfVfgMMlGE7THlqihsW1c_003D2._0023_003Dz8If0AEk_003D;
	}

	private static List<Mesh> _0023_003Dzh7GYg1aQoczeFVgORDu9DRj7xo8ThXX6cg_BxfE_003D(_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D _0023_003DzGmhbLZBbMw7X)
	{
		List<Mesh> list = new List<Mesh>();
		if (!(_0023_003DzGmhbLZBbMw7X is _0023_003DzN9BqG4IwWDVpPJUxcEXXInohW0yZcAoPtA_003D_003D _0023_003DzN9BqG4IwWDVpPJUxcEXXInohW0yZcAoPtA_003D_003D2))
		{
			if (_0023_003DzGmhbLZBbMw7X is _0023_003DzMm8M_0024rptDOeEFLoF_Mik_v6MUyc3alaHVw_003D_003D _0023_003DzMm8M_0024rptDOeEFLoF_Mik_v6MUyc3alaHVw_003D_003D2)
			{
				_0023_003DzXXz8MxLlH6VTOkBvU1LuwkJY_0024oPJow3nGg_003D_003D[] array = _0023_003DzMm8M_0024rptDOeEFLoF_Mik_v6MUyc3alaHVw_003D_003D2._0023_003DzSEwn8FT_0024rx6yV9pJc2bKDIfLxQNDOs_FLA_003D_003D();
				foreach (_0023_003DzXXz8MxLlH6VTOkBvU1LuwkJY_0024oPJow3nGg_003D_003D _0023_003DzXXz8MxLlH6VTOkBvU1LuwkJY_0024oPJow3nGg_003D_003D2 in array)
				{
					list.Add(new Mesh(_0023_003DzXXz8MxLlH6VTOkBvU1LuwkJY_0024oPJow3nGg_003D_003D2._0023_003DzYNux6PWoz6TL(), _0023_003DzXXz8MxLlH6VTOkBvU1LuwkJY_0024oPJow3nGg_003D_003D2._0023_003DzPvyA_tju2mOECWmhiQ_003D_003D()));
				}
			}
		}
		else
		{
			Dictionary<Point3D, int> dictionary = new Dictionary<Point3D, int>();
			List<IndexTriangle> list2 = new List<IndexTriangle>();
			_0023_003DzXXz8MxLlH6VTOkBvU1LuwkJY_0024oPJow3nGg_003D_003D[] array = _0023_003DzN9BqG4IwWDVpPJUxcEXXInohW0yZcAoPtA_003D_003D2._0023_003DzSEwn8FT_0024rx6yV9pJc2bKDIfLxQNDOs_FLA_003D_003D();
			foreach (_0023_003DzXXz8MxLlH6VTOkBvU1LuwkJY_0024oPJow3nGg_003D_003D _0023_003DzXXz8MxLlH6VTOkBvU1LuwkJY_0024oPJow3nGg_003D_003D3 in array)
			{
				if (_0023_003DzXXz8MxLlH6VTOkBvU1LuwkJY_0024oPJow3nGg_003D_003D3 == null)
				{
					continue;
				}
				int[] array2 = new int[_0023_003DzXXz8MxLlH6VTOkBvU1LuwkJY_0024oPJow3nGg_003D_003D3._0023_003DzYNux6PWoz6TL().Length];
				for (int j = 0; j < _0023_003DzXXz8MxLlH6VTOkBvU1LuwkJY_0024oPJow3nGg_003D_003D3._0023_003DzYNux6PWoz6TL().Length; j++)
				{
					Point3D key = _0023_003DzXXz8MxLlH6VTOkBvU1LuwkJY_0024oPJow3nGg_003D_003D3._0023_003DzYNux6PWoz6TL()[j];
					if (dictionary.TryGetValue(key, out var value))
					{
						array2[j] = value;
						continue;
					}
					array2[j] = dictionary.Count;
					dictionary.Add(key, dictionary.Count);
				}
				foreach (IndexTriangle item in _0023_003DzXXz8MxLlH6VTOkBvU1LuwkJY_0024oPJow3nGg_003D_003D3._0023_003DzPvyA_tju2mOECWmhiQ_003D_003D())
				{
					item.V1 = array2[item.V1];
					item.V2 = array2[item.V2];
					item.V3 = array2[item.V3];
					list2.Add(item);
				}
			}
			if (dictionary.Count > 0 && list2.Count > 0)
			{
				list.Add(new Mesh(dictionary.Keys.ToArray(), list2));
			}
		}
		return list;
	}

	private bool _0023_003Dzbj30ga1di1YE(IList<_0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D> _0023_003Dzj_0024u_SRdExhSa, SortedList<int, Entity> _0023_003DzWc9WmS8VMsuA, angularUnitsType _0023_003DzDSV3KvHUSDa4, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		_0023_003DzjANgI7bcnJif5klsA2e0VAM_003D _0023_003DzjANgI7bcnJif5klsA2e0VAM_003D2 = new _0023_003DzjANgI7bcnJif5klsA2e0VAM_003D();
		_0023_003DzjANgI7bcnJif5klsA2e0VAM_003D2._0023_003Dzj_0024u_SRdExhSa = _0023_003Dzj_0024u_SRdExhSa;
		_0023_003DzjANgI7bcnJif5klsA2e0VAM_003D2._0023_003DzDSV3KvHUSDa4 = _0023_003DzDSV3KvHUSDa4;
		_0023_003DzjANgI7bcnJif5klsA2e0VAM_003D2._0023_003DzopRx0_MBcTQs = this;
		_0023_003DzjANgI7bcnJif5klsA2e0VAM_003D2._0023_003DzmHS7frs_003D = _0023_003DzmHS7frs_003D;
		_0023_003DzjANgI7bcnJif5klsA2e0VAM_003D2._0023_003Dzjvn7P10_003D = _0023_003Dzjvn7P10_003D;
		_0023_003DzjANgI7bcnJif5klsA2e0VAM_003D2._0023_003DzWc9WmS8VMsuA = _0023_003DzWc9WmS8VMsuA;
		_0023_003DzjANgI7bcnJif5klsA2e0VAM_003D2._0023_003Dz8If0AEk_003D = true;
		_0023_003DzjANgI7bcnJif5klsA2e0VAM_003D2._0023_003Dz9JZgoew_003D = _0023_003DzjANgI7bcnJif5klsA2e0VAM_003D2._0023_003Dzj_0024u_SRdExhSa.Count;
		ResetProgressParallel();
		Parallel.For(0, _0023_003DzjANgI7bcnJif5klsA2e0VAM_003D2._0023_003Dz9JZgoew_003D, _0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzSGi5O1N_OoUc6eKqQc9kP9Q_003D, _0023_003DzjANgI7bcnJif5klsA2e0VAM_003D2._0023_003DzGbhKYC4raWwrnxqYmePDmBw_003D, _0023_003DzjANgI7bcnJif5klsA2e0VAM_003D2._0023_003DzVEQaN21uvmpmrIX0p92hDiI_003D);
		if (_0023_003DzjANgI7bcnJif5klsA2e0VAM_003D2._0023_003Dz8If0AEk_003D)
		{
			UpdateProgressTo100(base.ParsingText, _0023_003DzjANgI7bcnJif5klsA2e0VAM_003D2._0023_003DzmHS7frs_003D);
		}
		return _0023_003DzjANgI7bcnJif5klsA2e0VAM_003D2._0023_003Dz8If0AEk_003D;
	}

	private static void _0023_003DzcKLtULL1zfVM(int _0023_003DzRLCcpW4_003D, IList<_0023_003DzbykJA36oCfUxYTgeaw_003D_003D> _0023_003DzEHqFVzMAt7Lc, IList<Brep.Face> _0023_003DzQ4yTlf3MMmGo, angularUnitsType _0023_003DzDSV3KvHUSDa4, Brep.Edge[] _0023_003DzU3hosSAzkxO7, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		int count = _0023_003DzEHqFVzMAt7Lc.Count;
		for (int i = 0; i < count; i++)
		{
			_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzQsK9PuIC8frb = _0023_003DzEHqFVzMAt7Lc[i];
			Brep.Face face = _0023_003DzQ4yTlf3MMmGo[i];
			List<ICurve> list = new List<ICurve>();
			_0023_003DzaEO_0024fS_0024moyNJ(face, _0023_003DzU3hosSAzkxO7);
			for (int j = 0; j < face.Loops.Length; j++)
			{
				Brep.Loop loop = face.Loops[j];
				ICurve[] array = new ICurve[loop.Segments.Length];
				for (int k = 0; k < loop.Segments.Length; k++)
				{
					Brep.OrientedEdge orientedEdge = loop.Segments[k];
					Brep.Edge edge = _0023_003DzU3hosSAzkxO7[orientedEdge.CurveIndex];
					edge.ShellIndex = _0023_003DzRLCcpW4_003D;
					array[k] = edge.Curve;
					if (edge.Parents == null)
					{
						edge.Parents = new int[1] { i };
					}
					else
					{
						int num = edge.Parents.Length;
						Array.Resize(ref edge.Parents, num + 1);
						edge.Parents[num] = i;
					}
				}
				if (loop.Segments.Length > 1)
				{
					list.Add(new CompositeCurve(array, sortAndOrient: false));
				}
				else if (loop.Segments.Length == 1)
				{
					list.Add(array[0]);
				}
			}
			AnalyticSurf analyticSurf = _0023_003Dz0SlujM_0024ENJMg(_0023_003DzDSV3KvHUSDa4, _0023_003DzQsK9PuIC8frb, list, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D, ref face.Sense);
			if (analyticSurf != null)
			{
				face.Surface = analyticSurf;
			}
		}
	}

	private static Entity[] _0023_003DzuTCwRvbXUrZU(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzQsK9PuIC8frb, angularUnitsType _0023_003DzPtQTcKPKNs_Eyhu_nA_003D_003D, Color _0023_003DzlPCFKgk_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		if (_0023_003DzQsK9PuIC8frb._0023_003Dz_0024yKZjQibhIEi() != 0)
		{
			Surface[] array = null;
			List<List<_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D>> _0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D = new List<List<_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D>>();
			int num = _0023_003DzQsK9PuIC8frb._0023_003DzYfPyUC209Tqonw07hA_003D_003D(ref _0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D);
			List<ICurve> list = new List<ICurve>(_0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D.Count);
			for (int i = 0; i < _0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D.Count; i++)
			{
				ICurve curve = _0023_003DzfszPGi1SYGRQ1qdQJQg1Ppk_003D(_0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D[i], _0023_003DzPtQTcKPKNs_Eyhu_nA_003D_003D, _0023_003DzQsK9PuIC8frb._0023_003DzB5NG_d2je_2o?[i], _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D);
				if (curve != null)
				{
					if (_0023_003DzQsK9PuIC8frb._0023_003DzXX_L3TtKXHeHo4YpYg_003D_003D != null && !_0023_003DzQsK9PuIC8frb._0023_003DzXX_L3TtKXHeHo4YpYg_003D_003D[i])
					{
						curve.Reverse();
					}
					list.Add(curve);
				}
			}
			if (num > -1 && num < list.Count)
			{
				_0023_003DzzOeKDf5VCnqZ(list, num);
			}
			switch (_0023_003DzQsK9PuIC8frb._0023_003Dz_0024yKZjQibhIEi())
			{
			case (_0023_003DzheRNgmFS6APNDKdLv2laLiE_003D)3:
				array = _0023_003DzNAY88qiufkhHRcJBbQ_003D_003D(_0023_003DzQsK9PuIC8frb, list, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D);
				break;
			case (_0023_003DzheRNgmFS6APNDKdLv2laLiE_003D)7:
				array = _0023_003DzeV1USXt5_0024jRL(_0023_003DzQsK9PuIC8frb, list, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D);
				break;
			case (_0023_003DzheRNgmFS6APNDKdLv2laLiE_003D)10:
				array = _0023_003Dz8zHhNtYS2dWIWKY9CFsyqPc_003D(_0023_003DzQsK9PuIC8frb, list, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D);
				break;
			case (_0023_003DzheRNgmFS6APNDKdLv2laLiE_003D)1:
				array = _0023_003DzH12smGQjbB0H8W3fVg_003D_003D(_0023_003DzQsK9PuIC8frb, list, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D);
				break;
			case (_0023_003DzheRNgmFS6APNDKdLv2laLiE_003D)2:
				array = _0023_003DzvDrI1_0024ezXFNdBZftuaKXwtHiSdrg(_0023_003DzQsK9PuIC8frb, list, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D);
				break;
			case (_0023_003DzheRNgmFS6APNDKdLv2laLiE_003D)4:
				array = _0023_003DzJBVjMNKiuvuZmxFOy1BNeeI_003D(_0023_003DzQsK9PuIC8frb, list, _0023_003DzPtQTcKPKNs_Eyhu_nA_003D_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D);
				break;
			case (_0023_003DzheRNgmFS6APNDKdLv2laLiE_003D)6:
				array = _0023_003DzzoUKHpqQiMXiFRcD_00240IcPbo_003D(_0023_003DzQsK9PuIC8frb, list, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D);
				break;
			case (_0023_003DzheRNgmFS6APNDKdLv2laLiE_003D)11:
				array = _0023_003Dz4pXn8U7bdbcXMkeD0cv9MP4X2X1fhfVW2hVI6f8_003D(_0023_003DzQsK9PuIC8frb, list, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D);
				break;
			case (_0023_003DzheRNgmFS6APNDKdLv2laLiE_003D)5:
				array = _0023_003DzSUh6Fyf5zWnYwWYFb0bYdmo_003D(_0023_003DzQsK9PuIC8frb, list, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D);
				break;
			case (_0023_003DzheRNgmFS6APNDKdLv2laLiE_003D)9:
				array = _0023_003DzYksWwO85xS36mEkhxPDER4XPDL6F(_0023_003DzQsK9PuIC8frb, list, _0023_003DzPtQTcKPKNs_Eyhu_nA_003D_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D);
				break;
			case (_0023_003DzheRNgmFS6APNDKdLv2laLiE_003D)8:
				array = _0023_003DzHg_UlBnT7qJq(_0023_003DzQsK9PuIC8frb, list, _0023_003DzPtQTcKPKNs_Eyhu_nA_003D_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D);
				break;
			case (_0023_003DzheRNgmFS6APNDKdLv2laLiE_003D)12:
				array = _0023_003Dzb9_00241shsIGtAJ(_0023_003DzQsK9PuIC8frb, list, _0023_003DzPtQTcKPKNs_Eyhu_nA_003D_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D);
				break;
			default:
				_0023_003DzqmF8XJ0_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010975) + _0023_003DzQsK9PuIC8frb._0023_003DzPNMPkgk_003D());
				array = null;
				break;
			}
			if (array != null)
			{
				Entity[] array2 = new Entity[array.Length];
				for (int j = 0; j < array.Length; j++)
				{
					Surface surface = array[j];
					if (surface != null)
					{
						surface.ColorMethod = colorMethodType.byEntity;
						surface.Color = _0023_003DzlPCFKgk_003D;
						_0023_003DzZUJ_Pfo8i0Hg(surface, _0023_003DzQsK9PuIC8frb._0023_003Dzwtld1NM_003D);
						surface.TranslationID = new TranslationIdentifier(_0023_003DzQsK9PuIC8frb._0023_003DzPNMPkgk_003D(), _0023_003DzQsK9PuIC8frb._0023_003DzS_00246o7tc_003D);
						surface.LayerName = _0023_003DzQsK9PuIC8frb._0023_003DzaROjBYA_003D;
						array2[j] = surface;
					}
				}
				return array2;
			}
		}
		return new Entity[0];
	}

	private static void _0023_003DzzOeKDf5VCnqZ(List<ICurve> _0023_003DzRTbTK_0024KwG32W, int _0023_003DzLFA2gNM_003D)
	{
		if (_0023_003DzRTbTK_0024KwG32W.Count > 0)
		{
			ICurve value = _0023_003DzRTbTK_0024KwG32W[0];
			_0023_003DzRTbTK_0024KwG32W[0] = _0023_003DzRTbTK_0024KwG32W[_0023_003DzLFA2gNM_003D];
			_0023_003DzRTbTK_0024KwG32W[_0023_003DzLFA2gNM_003D] = value;
		}
	}

	private void _0023_003DzCQrmp5g8vp6W(_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D _0023_003Dzmx8Td5k_003D)
	{
		if (!string.IsNullOrEmpty(_0023_003Dzmx8Td5k_003D._0023_003DzaROjBYA_003D))
		{
			_0023_003Dzmx8Td5k_003D._0023_003DzaROjBYA_003D = _0023_003DzmJCVjbsxglhj(_0023_003Dzmx8Td5k_003D._0023_003DzaROjBYA_003D);
		}
	}

	private string _0023_003DzmJCVjbsxglhj(string _0023_003DzS_00246o7tc_003D)
	{
		if (!base.Layers.Contains(_0023_003DzS_00246o7tc_003D))
		{
			Layer item = new Layer(_0023_003DzS_00246o7tc_003D);
			base.Layers.Add(item);
		}
		return _0023_003DzS_00246o7tc_003D;
	}

	private static AnalyticSurf _0023_003Dz0SlujM_0024ENJMg(angularUnitsType _0023_003DzDSV3KvHUSDa4, _0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzQsK9PuIC8frb, IList<ICurve> _0023_003DzRTbTK_0024KwG32W, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D, ref bool _0023_003DzClBtlvaHChzq)
	{
		AnalyticSurf result = null;
		switch (_0023_003DzQsK9PuIC8frb._0023_003Dz_0024yKZjQibhIEi())
		{
		case (_0023_003DzheRNgmFS6APNDKdLv2laLiE_003D)3:
			result = _0023_003DzCDczckvMg3jLm9E3xg_003D_003D(_0023_003DzQsK9PuIC8frb, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D);
			break;
		case (_0023_003DzheRNgmFS6APNDKdLv2laLiE_003D)7:
			result = _0023_003Dz94HA_bAG9Irn(_0023_003DzQsK9PuIC8frb, _0023_003DzRTbTK_0024KwG32W, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D, ref _0023_003DzClBtlvaHChzq);
			break;
		case (_0023_003DzheRNgmFS6APNDKdLv2laLiE_003D)10:
			result = _0023_003DzcBpLuKwuDkpV21gxjZTR_00247s_003D(_0023_003DzQsK9PuIC8frb, _0023_003DzRTbTK_0024KwG32W, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D);
			break;
		case (_0023_003DzheRNgmFS6APNDKdLv2laLiE_003D)1:
			result = _0023_003Dzk6DKb7IVwVU_Chh6pw_003D_003D(_0023_003DzQsK9PuIC8frb, _0023_003DzRTbTK_0024KwG32W, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D);
			break;
		case (_0023_003DzheRNgmFS6APNDKdLv2laLiE_003D)2:
			result = _0023_003DztTkjUlV3Mnf2qHatVHSlQ8U6_1Oc(_0023_003DzQsK9PuIC8frb, _0023_003DzRTbTK_0024KwG32W, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D);
			break;
		case (_0023_003DzheRNgmFS6APNDKdLv2laLiE_003D)4:
			result = _0023_003DzyHM_0024S7AWIrBLLb_0024a_00244I6sd4_003D(_0023_003DzQsK9PuIC8frb, _0023_003DzRTbTK_0024KwG32W, _0023_003DzDSV3KvHUSDa4, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D);
			break;
		case (_0023_003DzheRNgmFS6APNDKdLv2laLiE_003D)6:
			result = _0023_003DzjusK1Iu3wOku1J3c5i0jEWU_003D(_0023_003DzQsK9PuIC8frb, _0023_003DzRTbTK_0024KwG32W, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D);
			break;
		case (_0023_003DzheRNgmFS6APNDKdLv2laLiE_003D)11:
			result = _0023_003DzZZLvLbcK1UiVPv6COgXWCq8GPltBKLCqDBM3cQQ_003D(_0023_003DzQsK9PuIC8frb, _0023_003DzRTbTK_0024KwG32W, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D);
			break;
		case (_0023_003DzheRNgmFS6APNDKdLv2laLiE_003D)5:
			result = _0023_003Dz2KeG2nJ_0024_K5YLJ6eBRWgKF0_003D(_0023_003DzQsK9PuIC8frb, _0023_003DzRTbTK_0024KwG32W, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D);
			break;
		case (_0023_003DzheRNgmFS6APNDKdLv2laLiE_003D)9:
			result = _0023_003DzjydXZo2McR1JjBJVG4FxOEtKV_qN(_0023_003DzQsK9PuIC8frb, _0023_003DzDSV3KvHUSDa4, _0023_003DzRTbTK_0024KwG32W, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D);
			break;
		case (_0023_003DzheRNgmFS6APNDKdLv2laLiE_003D)8:
			result = _0023_003Dzj9k5Pwo_0024ZiRu(_0023_003DzQsK9PuIC8frb, _0023_003DzRTbTK_0024KwG32W, _0023_003DzDSV3KvHUSDa4, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D);
			break;
		case (_0023_003DzheRNgmFS6APNDKdLv2laLiE_003D)12:
			result = _0023_003Dz5GMCUmf_cOKs(_0023_003DzQsK9PuIC8frb, _0023_003DzRTbTK_0024KwG32W, _0023_003DzDSV3KvHUSDa4, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D);
			break;
		default:
			_0023_003DzqmF8XJ0_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011710) + _0023_003DzQsK9PuIC8frb._0023_003DzPNMPkgk_003D());
			break;
		}
		return result;
	}

	private static Surface[] _0023_003DzSUh6Fyf5zWnYwWYFb0bYdmo_003D(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzQsK9PuIC8frb, IList<ICurve> _0023_003DzRTbTK_0024KwG32W, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		double[] _0023_003DzbUvT9Pc_003D = new double[3];
		double[] _0023_003DzllaDaar0_dmzjAa84g_003D_003D = new double[3];
		double[] _0023_003DzwuLF2pkaJGph5CFTvQ_003D_003D = new double[3];
		double _0023_003DzEGKj_0024SNUUihi = 0.0;
		_0023_003DzQsK9PuIC8frb._0023_003DzCpDQH9HSQqz_DwE7hA_003D_003D(ref _0023_003DzbUvT9Pc_003D, ref _0023_003DzEGKj_0024SNUUihi, ref _0023_003DzllaDaar0_dmzjAa84g_003D_003D, ref _0023_003DzwuLF2pkaJGph5CFTvQ_003D_003D);
		_0023_003DzHSHKXzrIpn0Lc7MTmGsQzJk_003D(_0023_003DzllaDaar0_dmzjAa84g_003D_003D, _0023_003DzwuLF2pkaJGph5CFTvQ_003D_003D);
		return new SphericalSurf(new Point3D(_0023_003DzbUvT9Pc_003D), new Vector3D(_0023_003DzllaDaar0_dmzjAa84g_003D_003D), new Vector3D(_0023_003DzwuLF2pkaJGph5CFTvQ_003D_003D), _0023_003DzEGKj_0024SNUUihi, _0023_003DzQsK9PuIC8frb._0023_003DzPNMPkgk_003D()).GetSurface(_0023_003DzRTbTK_0024KwG32W, !_0023_003DzQsK9PuIC8frb._0023_003Dz3teLb_0024wWvlUs());
	}

	private static SphericalSurf _0023_003Dz2KeG2nJ_0024_K5YLJ6eBRWgKF0_003D(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzQsK9PuIC8frb, IList<ICurve> _0023_003DzRTbTK_0024KwG32W, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		double[] _0023_003DzbUvT9Pc_003D = new double[3];
		double[] _0023_003DzllaDaar0_dmzjAa84g_003D_003D = new double[3];
		double[] _0023_003DzwuLF2pkaJGph5CFTvQ_003D_003D = new double[3];
		double _0023_003DzEGKj_0024SNUUihi = 0.0;
		_0023_003DzQsK9PuIC8frb._0023_003DzCpDQH9HSQqz_DwE7hA_003D_003D(ref _0023_003DzbUvT9Pc_003D, ref _0023_003DzEGKj_0024SNUUihi, ref _0023_003DzllaDaar0_dmzjAa84g_003D_003D, ref _0023_003DzwuLF2pkaJGph5CFTvQ_003D_003D);
		_0023_003DzHSHKXzrIpn0Lc7MTmGsQzJk_003D(_0023_003DzllaDaar0_dmzjAa84g_003D_003D, _0023_003DzwuLF2pkaJGph5CFTvQ_003D_003D);
		return new SphericalSurf(new Point3D(_0023_003DzbUvT9Pc_003D), new Vector3D(_0023_003DzllaDaar0_dmzjAa84g_003D_003D), new Vector3D(_0023_003DzwuLF2pkaJGph5CFTvQ_003D_003D), _0023_003DzEGKj_0024SNUUihi, _0023_003DzQsK9PuIC8frb._0023_003DzPNMPkgk_003D());
	}

	private static void _0023_003DzHSHKXzrIpn0Lc7MTmGsQzJk_003D(double[] _0023_003DzZbOaTIM_003D, double[] _0023_003DzcgQS2OJJ2x_L)
	{
		if (_0023_003DzcgQS2OJJ2x_L[0] == 0.0 && _0023_003DzcgQS2OJJ2x_L[0] == 0.0 && _0023_003DzcgQS2OJJ2x_L[0] == 0.0)
		{
			_0023_003DzcgQS2OJJ2x_L[0] = 1.0;
		}
		if (_0023_003DzZbOaTIM_003D[0] == 0.0 && _0023_003DzZbOaTIM_003D[0] == 0.0 && _0023_003DzZbOaTIM_003D[0] == 0.0)
		{
			_0023_003DzZbOaTIM_003D[2] = 1.0;
		}
	}

	private static Surface[] _0023_003DzzoUKHpqQiMXiFRcD_00240IcPbo_003D(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzQsK9PuIC8frb, IList<ICurve> _0023_003DzRTbTK_0024KwG32W, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		double[] _0023_003DzbUvT9Pc_003D = new double[3];
		double[] _0023_003Dz1PT23mRCILtC_0024w5mng_003D_003D = new double[3];
		double[] _0023_003DzRdl_0024TDNix_0024p4_00240NlDg_003D_003D = new double[3];
		double _0023_003DzA_8ilLvuROi = 0.0;
		double _0023_003DzZonw8nQGtIca = 0.0;
		_0023_003DzQsK9PuIC8frb._0023_003DznM9ltUUl9KMk(ref _0023_003DzbUvT9Pc_003D, ref _0023_003DzA_8ilLvuROi, ref _0023_003DzZonw8nQGtIca, ref _0023_003Dz1PT23mRCILtC_0024w5mng_003D_003D, ref _0023_003DzRdl_0024TDNix_0024p4_00240NlDg_003D_003D);
		return new ToroidalSurf(new Point3D(_0023_003DzbUvT9Pc_003D), new Vector3D(_0023_003Dz1PT23mRCILtC_0024w5mng_003D_003D), new Vector3D(_0023_003DzRdl_0024TDNix_0024p4_00240NlDg_003D_003D), _0023_003DzA_8ilLvuROi, _0023_003DzZonw8nQGtIca, _0023_003DzQsK9PuIC8frb._0023_003DzPNMPkgk_003D()).GetSurface(_0023_003DzRTbTK_0024KwG32W, !_0023_003DzQsK9PuIC8frb._0023_003Dz3teLb_0024wWvlUs());
	}

	private static Rotation _0023_003DzG6K1nobgiShtNUK09A_003D_003D(IList<ICurve> _0023_003DzRTbTK_0024KwG32W, Point3D _0023_003DzeoY7iyo_003D, Vector3D _0023_003DzcgQS2OJJ2x_L, Vector3D _0023_003DzxuJqjrs_003D)
	{
		if (_0023_003DzRTbTK_0024KwG32W.Count > 0)
		{
			ICurve[] individualCurves = _0023_003DzRTbTK_0024KwG32W[0].GetIndividualCurves();
			double diagonal = Surface._0023_003DzWu3S5IPxj3tfF03Eyw_003D_003D(individualCurves).Diagonal;
			double tol = diagonal * Utility._0023_003DzxhnLabVjXjPg;
			foreach (ICurve item in (IEnumerable<ICurve>)individualCurves)
			{
				if (!item.IsPlanar(tol, out var plane))
				{
					continue;
				}
				Segment3D segment3D = new Segment3D(_0023_003DzeoY7iyo_003D, _0023_003DzeoY7iyo_003D + _0023_003DzcgQS2OJJ2x_L * diagonal);
				if (segment3D.IsInPlane(plane, tol))
				{
					Vector3D vector3D = new Vector3D(item.StartPoint.ProjectTo(segment3D), item.StartPoint);
					if (!vector3D.IsZero)
					{
						vector3D.Normalize();
						return new Rotation(Vector3D.AngleBetween(_0023_003DzcgQS2OJJ2x_L, vector3D), _0023_003DzxuJqjrs_003D, _0023_003DzeoY7iyo_003D);
					}
				}
			}
		}
		return null;
	}

	private static AnalyticSurf _0023_003DzjusK1Iu3wOku1J3c5i0jEWU_003D(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzQsK9PuIC8frb, IList<ICurve> _0023_003DzRTbTK_0024KwG32W, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		double[] _0023_003DzbUvT9Pc_003D = new double[3];
		double[] _0023_003Dz1PT23mRCILtC_0024w5mng_003D_003D = new double[3];
		double[] _0023_003DzRdl_0024TDNix_0024p4_00240NlDg_003D_003D = new double[3];
		double _0023_003DzA_8ilLvuROi = 0.0;
		double _0023_003DzZonw8nQGtIca = 0.0;
		_0023_003DzQsK9PuIC8frb._0023_003DznM9ltUUl9KMk(ref _0023_003DzbUvT9Pc_003D, ref _0023_003DzA_8ilLvuROi, ref _0023_003DzZonw8nQGtIca, ref _0023_003Dz1PT23mRCILtC_0024w5mng_003D_003D, ref _0023_003DzRdl_0024TDNix_0024p4_00240NlDg_003D_003D);
		Point3D point3D = new Point3D(_0023_003DzbUvT9Pc_003D);
		Vector3D vector3D = new Vector3D(_0023_003Dz1PT23mRCILtC_0024w5mng_003D_003D);
		Vector3D vector3D2 = new Vector3D(_0023_003DzRdl_0024TDNix_0024p4_00240NlDg_003D_003D);
		if (_0023_003DzRTbTK_0024KwG32W.Count > 0 && _0023_003DzTN8dr9bz5Y29N1qbNg_003D_003D(_0023_003DzRTbTK_0024KwG32W[0].GetIndividualCurves(), _0023_003DzZonw8nQGtIca + _0023_003DzA_8ilLvuROi, point3D, out var _0023_003Dz9ZIW2o5QYMUG))
		{
			Plane plane = new Plane(point3D + vector3D2 * _0023_003DzA_8ilLvuROi, vector3D2, vector3D);
			Arc generatrix = new Arc(plane, plane.Origin, _0023_003DzZonw8nQGtIca, _0023_003Dz9ZIW2o5QYMUG.StartPoint, _0023_003Dz9ZIW2o5QYMUG.StartPoint, flip: false);
			return new RevolvedSurf((Point3D)point3D.Clone(), (Vector3D)vector3D.Clone(), (Vector3D)vector3D2.Clone(), generatrix, _0023_003DzQsK9PuIC8frb._0023_003DzPNMPkgk_003D());
		}
		return new ToroidalSurf(point3D, vector3D, vector3D2, _0023_003DzA_8ilLvuROi, _0023_003DzZonw8nQGtIca, _0023_003DzQsK9PuIC8frb._0023_003DzPNMPkgk_003D());
	}

	private static bool _0023_003DzTN8dr9bz5Y29N1qbNg_003D_003D(IList<ICurve> _0023_003DzRTbTK_0024KwG32W, double _0023_003DzilIyr7lRgAr_0024, Point3D _0023_003DzbUvT9Pc_003D, out ICurve _0023_003Dz9ZIW2o5QYMUG)
	{
		_0023_003Dz9ZIW2o5QYMUG = null;
		for (int i = 0; i < _0023_003DzRTbTK_0024KwG32W.Count; i++)
		{
			ICurve curve = _0023_003DzRTbTK_0024KwG32W[i];
			for (int j = i + 1; j < _0023_003DzRTbTK_0024KwG32W.Count; j++)
			{
				ICurve second = _0023_003DzRTbTK_0024KwG32W[j];
				if (!Utility.AreCurvesEqualsOrOpposite(curve, second, checkOpposite: false, anyDir: true))
				{
					continue;
				}
				double num = _0023_003DzilIyr7lRgAr_0024 * _0023_003DzilIyr7lRgAr_0024;
				double num2 = Point3D.DistanceSquared(curve.StartPoint, _0023_003DzbUvT9Pc_003D);
				double num3 = (curve.IsClosed ? num2 : Point3D.DistanceSquared(curve.EndPoint, _0023_003DzbUvT9Pc_003D));
				if (Math.Abs(num2 - num3) < 1E-12)
				{
					_0023_003Dz9ZIW2o5QYMUG = curve;
					if (num2 < num)
					{
						return true;
					}
					return false;
				}
			}
		}
		return false;
	}

	private static Surface[] _0023_003Dz4pXn8U7bdbcXMkeD0cv9MP4X2X1fhfVW2hVI6f8_003D(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzQsK9PuIC8frb, IList<ICurve> _0023_003DzRTbTK_0024KwG32W, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		double[] _0023_003DzbUvT9Pc_003D = new double[3];
		double[] _0023_003DzRdl_0024TDNix_0024p4_00240NlDg_003D_003D = new double[3];
		double[] _0023_003Dz1PT23mRCILtC_0024w5mng_003D_003D = new double[3];
		double _0023_003DzA_8ilLvuROi = 0.0;
		double _0023_003DzZonw8nQGtIca = 0.0;
		bool _0023_003DzlZRyGoqAErWyKrgbFA_003D_003D = false;
		_0023_003DzQsK9PuIC8frb._0023_003DzUQhAEChv_0024_efb2OexqJFPsws3joL(ref _0023_003DzbUvT9Pc_003D, ref _0023_003DzA_8ilLvuROi, ref _0023_003DzZonw8nQGtIca, ref _0023_003Dz1PT23mRCILtC_0024w5mng_003D_003D, ref _0023_003DzRdl_0024TDNix_0024p4_00240NlDg_003D_003D, ref _0023_003DzlZRyGoqAErWyKrgbFA_003D_003D);
		if (_0023_003DzA_8ilLvuROi != _0023_003DzZonw8nQGtIca)
		{
			return _0023_003DzzinWfWRhrbI1w_6siuqaw9q1_49j(_0023_003DzbUvT9Pc_003D, _0023_003DzRdl_0024TDNix_0024p4_00240NlDg_003D_003D, _0023_003Dz1PT23mRCILtC_0024w5mng_003D_003D, _0023_003DzA_8ilLvuROi, _0023_003DzZonw8nQGtIca, _0023_003DzlZRyGoqAErWyKrgbFA_003D_003D).GetSurface(_0023_003DzRTbTK_0024KwG32W, !_0023_003DzQsK9PuIC8frb._0023_003Dz3teLb_0024wWvlUs());
		}
		return new SphericalSurf(new Point3D(_0023_003DzbUvT9Pc_003D), new Vector3D(_0023_003Dz1PT23mRCILtC_0024w5mng_003D_003D), new Vector3D(_0023_003DzRdl_0024TDNix_0024p4_00240NlDg_003D_003D), _0023_003DzZonw8nQGtIca, _0023_003DzQsK9PuIC8frb._0023_003DzPNMPkgk_003D()).GetSurface(_0023_003DzRTbTK_0024KwG32W, !_0023_003DzQsK9PuIC8frb._0023_003Dz3teLb_0024wWvlUs());
	}

	private static AnalyticSurf _0023_003DzzinWfWRhrbI1w_6siuqaw9q1_49j(double[] _0023_003DzbUvT9Pc_003D, double[] _0023_003Dztv6hMfw_003D, double[] _0023_003DzQqOWrmM_003D, double _0023_003Dzw2cdV10_003D, double _0023_003DzrGX1P9M_003D, bool _0023_003DzW1ZrxcoIjZgC)
	{
		Point3D p = new Point3D(_0023_003DzbUvT9Pc_003D);
		Vector3D vector3D = new Vector3D(_0023_003Dztv6hMfw_003D);
		Vector3D vector3D2 = new Vector3D(_0023_003DzQqOWrmM_003D);
		Plane plane = (vector3D.IsZero ? new Plane(p, vector3D2) : new Plane(p, vector3D, Vector3D.Cross(vector3D, vector3D2)));
		Plane arcPlane = new Plane(p, plane.AxisX, plane.AxisZ);
		double num = Math.Acos((0.0 - _0023_003Dzw2cdV10_003D) / _0023_003DzrGX1P9M_003D);
		Arc generatrix = new Arc(arcPlane, new Point2D(_0023_003Dzw2cdV10_003D, 0.0), _0023_003DzrGX1P9M_003D, num, Math.PI * 2.0 - num);
		if (_0023_003DzW1ZrxcoIjZgC)
		{
			generatrix = new Arc(arcPlane, new Point2D(_0023_003Dzw2cdV10_003D, 0.0), _0023_003DzrGX1P9M_003D, 0.0 - num, num);
		}
		Surface notRotated;
		return new RevolvedSurf(plane.Origin, plane.AxisZ, plane.AxisX, generatrix).GetUntrimmed(null, sense: true, out notRotated)._0023_003DzWTGiFlsuyM_0024wBdTI5w_003D_003D();
	}

	private static AnalyticSurf _0023_003DzZZLvLbcK1UiVPv6COgXWCq8GPltBKLCqDBM3cQQ_003D(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzQsK9PuIC8frb, IList<ICurve> _0023_003DzRTbTK_0024KwG32W, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		double[] _0023_003DzbUvT9Pc_003D = new double[3];
		double[] _0023_003DzRdl_0024TDNix_0024p4_00240NlDg_003D_003D = new double[3];
		double[] _0023_003Dz1PT23mRCILtC_0024w5mng_003D_003D = new double[3];
		double _0023_003DzA_8ilLvuROi = 0.0;
		double _0023_003DzZonw8nQGtIca = 0.0;
		bool _0023_003DzlZRyGoqAErWyKrgbFA_003D_003D = false;
		_0023_003DzQsK9PuIC8frb._0023_003DzUQhAEChv_0024_efb2OexqJFPsws3joL(ref _0023_003DzbUvT9Pc_003D, ref _0023_003DzA_8ilLvuROi, ref _0023_003DzZonw8nQGtIca, ref _0023_003Dz1PT23mRCILtC_0024w5mng_003D_003D, ref _0023_003DzRdl_0024TDNix_0024p4_00240NlDg_003D_003D, ref _0023_003DzlZRyGoqAErWyKrgbFA_003D_003D);
		if (_0023_003DzA_8ilLvuROi != _0023_003DzZonw8nQGtIca)
		{
			return _0023_003DzzinWfWRhrbI1w_6siuqaw9q1_49j(_0023_003DzbUvT9Pc_003D, _0023_003DzRdl_0024TDNix_0024p4_00240NlDg_003D_003D, _0023_003Dz1PT23mRCILtC_0024w5mng_003D_003D, _0023_003DzA_8ilLvuROi, _0023_003DzZonw8nQGtIca, _0023_003DzlZRyGoqAErWyKrgbFA_003D_003D);
		}
		return new SphericalSurf(new Point3D(_0023_003DzbUvT9Pc_003D), new Vector3D(_0023_003Dz1PT23mRCILtC_0024w5mng_003D_003D), new Vector3D(_0023_003DzRdl_0024TDNix_0024p4_00240NlDg_003D_003D), _0023_003DzZonw8nQGtIca, _0023_003DzQsK9PuIC8frb._0023_003DzPNMPkgk_003D());
	}

	private static Surface[] _0023_003DzvDrI1_0024ezXFNdBZftuaKXwtHiSdrg(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzQsK9PuIC8frb, IList<ICurve> _0023_003DzRTbTK_0024KwG32W, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		double[] _0023_003DzbUvT9Pc_003D = new double[3];
		double[] _0023_003Dztv6hMfw_003D = new double[3];
		double[] _0023_003DzQqOWrmM_003D = new double[3];
		double _0023_003DzEGKj_0024SNUUihi = 0.0;
		_0023_003DzQsK9PuIC8frb._0023_003DzOh_Ij1R7ex_h9U_xcQ_003D_003D(ref _0023_003DzbUvT9Pc_003D, ref _0023_003DzEGKj_0024SNUUihi, ref _0023_003Dztv6hMfw_003D, ref _0023_003DzQqOWrmM_003D);
		return new CylindricalSurf(new Point3D(_0023_003DzbUvT9Pc_003D), new Vector3D(_0023_003DzQqOWrmM_003D), new Vector3D(_0023_003Dztv6hMfw_003D), _0023_003DzEGKj_0024SNUUihi, _0023_003DzQsK9PuIC8frb._0023_003DzPNMPkgk_003D()).GetSurface(_0023_003DzRTbTK_0024KwG32W, !_0023_003DzQsK9PuIC8frb._0023_003Dz3teLb_0024wWvlUs());
	}

	private static CylindricalSurf _0023_003DztTkjUlV3Mnf2qHatVHSlQ8U6_1Oc(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzQsK9PuIC8frb, IList<ICurve> _0023_003DzRTbTK_0024KwG32W, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		double[] _0023_003DzbUvT9Pc_003D = new double[3];
		double[] _0023_003Dztv6hMfw_003D = new double[3];
		double[] _0023_003DzQqOWrmM_003D = new double[3];
		double _0023_003DzEGKj_0024SNUUihi = 0.0;
		_0023_003DzQsK9PuIC8frb._0023_003DzOh_Ij1R7ex_h9U_xcQ_003D_003D(ref _0023_003DzbUvT9Pc_003D, ref _0023_003DzEGKj_0024SNUUihi, ref _0023_003Dztv6hMfw_003D, ref _0023_003DzQqOWrmM_003D);
		return new CylindricalSurf(new Point3D(_0023_003DzbUvT9Pc_003D), new Vector3D(_0023_003DzQqOWrmM_003D), new Vector3D(_0023_003Dztv6hMfw_003D), _0023_003DzEGKj_0024SNUUihi, _0023_003DzQsK9PuIC8frb._0023_003DzPNMPkgk_003D());
	}

	private static Surface[] _0023_003DzJBVjMNKiuvuZmxFOy1BNeeI_003D(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzQsK9PuIC8frb, IList<ICurve> _0023_003DzRTbTK_0024KwG32W, angularUnitsType _0023_003DzDSV3KvHUSDa4, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		double[] _0023_003DzbUvT9Pc_003D = new double[3];
		double[] _0023_003Dztv6hMfw_003D = new double[3];
		double[] _0023_003DzQqOWrmM_003D = new double[3];
		double _0023_003DzEGKj_0024SNUUihi = 0.0;
		double _0023_003Dz6pajdGM_003D = 0.0;
		_0023_003DzQsK9PuIC8frb._0023_003DzSLm1FOVfHX_0024r(ref _0023_003DzbUvT9Pc_003D, ref _0023_003DzEGKj_0024SNUUihi, ref _0023_003Dztv6hMfw_003D, ref _0023_003DzQqOWrmM_003D, ref _0023_003Dz6pajdGM_003D);
		Point3D _0023_003DzMJ9Rv10_003D = new Point3D(_0023_003DzbUvT9Pc_003D);
		double num = ((_0023_003DzDSV3KvHUSDa4 == angularUnitsType.Degrees) ? Utility.DegToRad(_0023_003Dz6pajdGM_003D) : _0023_003Dz6pajdGM_003D);
		if (_0023_003DzEGKj_0024SNUUihi == 0.0)
		{
			_0023_003DzEGKj_0024SNUUihi = _0023_003DzfD3mXJhocp1pBqH0Tg_003D_003D(_0023_003DzRTbTK_0024KwG32W, new Vector3D(_0023_003DzQqOWrmM_003D), num, ref _0023_003DzMJ9Rv10_003D);
		}
		return new ConicalSurf(_0023_003DzMJ9Rv10_003D, new Vector3D(_0023_003DzQqOWrmM_003D), new Vector3D(_0023_003Dztv6hMfw_003D), _0023_003DzEGKj_0024SNUUihi, num, _0023_003DzQsK9PuIC8frb._0023_003DzPNMPkgk_003D()).GetSurface(_0023_003DzRTbTK_0024KwG32W, !_0023_003DzQsK9PuIC8frb._0023_003Dz3teLb_0024wWvlUs());
	}

	private static ConicalSurf _0023_003DzyHM_0024S7AWIrBLLb_0024a_00244I6sd4_003D(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzQsK9PuIC8frb, IList<ICurve> _0023_003DzRTbTK_0024KwG32W, angularUnitsType _0023_003DzDSV3KvHUSDa4, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		double[] _0023_003DzbUvT9Pc_003D = new double[3];
		double[] _0023_003Dztv6hMfw_003D = new double[3];
		double[] _0023_003DzQqOWrmM_003D = new double[3];
		double _0023_003DzEGKj_0024SNUUihi = 0.0;
		double _0023_003Dz6pajdGM_003D = 0.0;
		_0023_003DzQsK9PuIC8frb._0023_003DzSLm1FOVfHX_0024r(ref _0023_003DzbUvT9Pc_003D, ref _0023_003DzEGKj_0024SNUUihi, ref _0023_003Dztv6hMfw_003D, ref _0023_003DzQqOWrmM_003D, ref _0023_003Dz6pajdGM_003D);
		Point3D _0023_003DzMJ9Rv10_003D = new Point3D(_0023_003DzbUvT9Pc_003D);
		double num = ((_0023_003DzDSV3KvHUSDa4 == angularUnitsType.Degrees) ? Utility.DegToRad(_0023_003Dz6pajdGM_003D) : _0023_003Dz6pajdGM_003D);
		if (_0023_003DzEGKj_0024SNUUihi == 0.0)
		{
			_0023_003DzEGKj_0024SNUUihi = _0023_003DzfD3mXJhocp1pBqH0Tg_003D_003D(_0023_003DzRTbTK_0024KwG32W, new Vector3D(_0023_003DzQqOWrmM_003D), num, ref _0023_003DzMJ9Rv10_003D);
		}
		return new ConicalSurf(_0023_003DzMJ9Rv10_003D, new Vector3D(_0023_003DzQqOWrmM_003D), new Vector3D(_0023_003Dztv6hMfw_003D), _0023_003DzEGKj_0024SNUUihi, num, _0023_003DzQsK9PuIC8frb._0023_003DzPNMPkgk_003D());
	}

	private static double _0023_003DzfD3mXJhocp1pBqH0Tg_003D_003D(IList<ICurve> _0023_003DzRTbTK_0024KwG32W, Vector3D _0023_003DzId5C3LA_003D, double _0023_003DzPLfKsyhlAU5i, ref Point3D _0023_003DzMJ9Rv10_003D)
	{
		foreach (ICurve item in _0023_003DzRTbTK_0024KwG32W)
		{
			ICurve[] individualCurves = item.GetIndividualCurves();
			for (int i = 0; i < individualCurves.Length; i++)
			{
				if (individualCurves[i] is Circle circle)
				{
					Segment3D segment3D = new Segment3D(_0023_003DzMJ9Rv10_003D, _0023_003DzMJ9Rv10_003D + _0023_003DzId5C3LA_003D);
					Point3D center = circle.Center;
					double num = segment3D.Project(center);
					double num2 = Math.Tan(_0023_003DzPLfKsyhlAU5i);
					double num3 = circle.Radius + num2 * num;
					_0023_003DzMJ9Rv10_003D += _0023_003DzId5C3LA_003D * (num3 / num2);
					return num3;
				}
			}
		}
		return 0.0;
	}

	private static Surface[] _0023_003DzH12smGQjbB0H8W3fVg_003D_003D(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzQsK9PuIC8frb, IList<ICurve> _0023_003DzRTbTK_0024KwG32W, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		double[] _0023_003Dzm4vrwLJ_HIr = new double[3];
		double[] _0023_003Dzrw_q2yI_003D = new double[3];
		double[] _0023_003DzZbOaTIM_003D = new double[3];
		_0023_003DzQsK9PuIC8frb._0023_003DzgF24ETkS_YIG(ref _0023_003Dzm4vrwLJ_HIr, ref _0023_003Dzrw_q2yI_003D, ref _0023_003DzZbOaTIM_003D);
		List<ICurve> list = new List<ICurve>();
		if (_0023_003DzQsK9PuIC8frb._0023_003DznhtT_6FTylm7 != null && _0023_003DzQsK9PuIC8frb._0023_003DznhtT_6FTylm7.Count > 0 && _0023_003DzQsK9PuIC8frb._0023_003DznhtT_6FTylm7[0].Count > 0)
		{
			for (int i = 0; i < _0023_003DzQsK9PuIC8frb._0023_003DznhtT_6FTylm7.Count; i++)
			{
				int count = _0023_003DzQsK9PuIC8frb._0023_003DznhtT_6FTylm7[i].Count;
				Point3D[] array = new Point3D[count + 1];
				for (int j = 0; j < count; j++)
				{
					array[j] = new Point3D(_0023_003DzQsK9PuIC8frb._0023_003DznhtT_6FTylm7[i][j]._0023_003Dzfj_WbJ59_mOa());
				}
				array[count] = (Point3D)array[0].Clone();
				LinearPath item = new LinearPath(array);
				list.Add(item);
			}
		}
		else
		{
			list.AddRange(_0023_003DzRTbTK_0024KwG32W);
		}
		return new PlanarSurf(new Point3D(_0023_003Dzm4vrwLJ_HIr), new Vector3D(_0023_003DzZbOaTIM_003D), new Vector3D(_0023_003Dzrw_q2yI_003D), _0023_003DzQsK9PuIC8frb._0023_003DzPNMPkgk_003D()).GetSurface(list, !_0023_003DzQsK9PuIC8frb._0023_003Dz3teLb_0024wWvlUs());
	}

	private static PlanarSurf _0023_003Dzk6DKb7IVwVU_Chh6pw_003D_003D(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzQsK9PuIC8frb, IList<ICurve> _0023_003DzRTbTK_0024KwG32W, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		double[] _0023_003Dzm4vrwLJ_HIr = new double[3];
		double[] _0023_003Dzrw_q2yI_003D = new double[3];
		double[] _0023_003DzZbOaTIM_003D = new double[3];
		_0023_003DzQsK9PuIC8frb._0023_003DzgF24ETkS_YIG(ref _0023_003Dzm4vrwLJ_HIr, ref _0023_003Dzrw_q2yI_003D, ref _0023_003DzZbOaTIM_003D);
		return new PlanarSurf(new Point3D(_0023_003Dzm4vrwLJ_HIr), new Vector3D(_0023_003DzZbOaTIM_003D), new Vector3D(_0023_003Dzrw_q2yI_003D), _0023_003DzQsK9PuIC8frb._0023_003DzPNMPkgk_003D());
	}

	private static Surface[] _0023_003DzHg_UlBnT7qJq(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzQsK9PuIC8frb, IList<ICurve> _0023_003DzRTbTK_0024KwG32W, angularUnitsType _0023_003DzPtQTcKPKNs_Eyhu_nA_003D_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D _0023_003DzcX2HU0yGwowv = null;
		double _0023_003DzZNubB_0024cRfbTUejOA7Q_003D_003D = -1.0;
		double[] _0023_003DzbIIdMFuNXKsO = new double[3];
		_0023_003DzQsK9PuIC8frb._0023_003Dz0HjjS6RxuddA_0024WFXPLxwDuA_003D(ref _0023_003DzcX2HU0yGwowv, ref _0023_003DzZNubB_0024cRfbTUejOA7Q_003D_003D, ref _0023_003DzbIIdMFuNXKsO);
		ICurve curve = _0023_003DzKttMWhHGVu_0024c(_0023_003DzcX2HU0yGwowv, _0023_003DzPtQTcKPKNs_Eyhu_nA_003D_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D, _0023_003DzvFB_0024dbs_003D: false);
		Surface[] result = null;
		if (curve != null)
		{
			Vector3D vector3D = new Vector3D(_0023_003DzbIIdMFuNXKsO);
			if (!PlanarSurf._0023_003DzvyAuVZcDxArs6XmJHcj7N_00248_003D(_0023_003DzRTbTK_0024KwG32W, curve.GetNurbsForm(), vector3D, out var _0023_003Dz6Jdj4TI_003D, out var _, out var _0023_003Dz_EiucSU_003D))
			{
				return null;
			}
			Surface surface = curve.ExtrudeAsSurface((1.0 + _0023_003Dz_EiucSU_003D) * vector3D * _0023_003Dz6Jdj4TI_003D.Length)[0];
			surface.Translate(vector3D * (_0023_003Dz6Jdj4TI_003D.t0 - _0023_003Dz_EiucSU_003D * _0023_003Dz6Jdj4TI_003D.Length / 2.0));
			surface.TranslationID = new TranslationIdentifier(_0023_003DzQsK9PuIC8frb._0023_003DzPNMPkgk_003D(), _0023_003DzQsK9PuIC8frb._0023_003DzS_00246o7tc_003D);
			result = Surface.DropLoops(surface, _0023_003DzRTbTK_0024KwG32W);
		}
		return result;
	}

	private static AnalyticSurf _0023_003Dzj9k5Pwo_0024ZiRu(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzQsK9PuIC8frb, IList<ICurve> _0023_003DzRTbTK_0024KwG32W, angularUnitsType _0023_003DzPtQTcKPKNs_Eyhu_nA_003D_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D _0023_003DzcX2HU0yGwowv = null;
		double _0023_003DzZNubB_0024cRfbTUejOA7Q_003D_003D = -1.0;
		double[] _0023_003DzbIIdMFuNXKsO = new double[3];
		_0023_003DzQsK9PuIC8frb._0023_003Dz0HjjS6RxuddA_0024WFXPLxwDuA_003D(ref _0023_003DzcX2HU0yGwowv, ref _0023_003DzZNubB_0024cRfbTUejOA7Q_003D_003D, ref _0023_003DzbIIdMFuNXKsO);
		ICurve curve = _0023_003DzKttMWhHGVu_0024c(_0023_003DzcX2HU0yGwowv, _0023_003DzPtQTcKPKNs_Eyhu_nA_003D_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D, _0023_003DzvFB_0024dbs_003D: false);
		if (curve != null)
		{
			Vector3D generatrix = new Vector3D(_0023_003DzbIIdMFuNXKsO);
			return new TabulatedSurf(curve, generatrix, _0023_003DzQsK9PuIC8frb._0023_003DzPNMPkgk_003D());
		}
		return null;
	}

	private static Surface[] _0023_003DzYksWwO85xS36mEkhxPDER4XPDL6F(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzQsK9PuIC8frb, IList<ICurve> _0023_003DzRTbTK_0024KwG32W, angularUnitsType _0023_003DzPtQTcKPKNs_Eyhu_nA_003D_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D _0023_003DzcX2HU0yGwowv = null;
		double[] _0023_003Dzm4vrwLJ_HIr = new double[3];
		double[] _0023_003DzZbOaTIM_003D = new double[3];
		_0023_003DzQsK9PuIC8frb._0023_003Dz9HIsjTNTDrB9AQz1hJGhXrs_003D(ref _0023_003DzcX2HU0yGwowv, ref _0023_003Dzm4vrwLJ_HIr, ref _0023_003DzZbOaTIM_003D);
		ICurve _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D = _0023_003DzKttMWhHGVu_0024c(_0023_003DzcX2HU0yGwowv, _0023_003DzPtQTcKPKNs_Eyhu_nA_003D_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D, _0023_003DzvFB_0024dbs_003D: false);
		Surface[] result = null;
		if (_0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D != null)
		{
			Point3D point3D = new Point3D(_0023_003Dzm4vrwLJ_HIr);
			Vector3D vector3D = new Vector3D(_0023_003DzZbOaTIM_003D);
			Utility._0023_003Dz1zSJGNpo0_0024Y5ZWKOCw_003D_003D(point3D, vector3D, ref _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D, out var _0023_003DzcgQS2OJJ2x_L, out var _);
			_0023_003DzUVUNqiFNexM1FWzSIA_003D_003D(new Plane(point3D, _0023_003DzcgQS2OJJ2x_L, vector3D), ref _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D);
			Surface surface = _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D.RevolveAsSurface(0.0, Math.PI * 2.0, vector3D, point3D)[0];
			surface.TranslationID = new TranslationIdentifier(_0023_003DzQsK9PuIC8frb._0023_003DzPNMPkgk_003D(), _0023_003DzQsK9PuIC8frb._0023_003DzS_00246o7tc_003D);
			if (!_0023_003DzQsK9PuIC8frb._0023_003Dz3teLb_0024wWvlUs())
			{
				surface.ReverseU();
			}
			result = Surface.DropLoops(surface, _0023_003DzRTbTK_0024KwG32W);
		}
		return result;
	}

	private static RevolvedSurf _0023_003DzjydXZo2McR1JjBJVG4FxOEtKV_qN(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzQsK9PuIC8frb, angularUnitsType _0023_003DzPtQTcKPKNs_Eyhu_nA_003D_003D, IList<ICurve> _0023_003DzRTbTK_0024KwG32W, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D _0023_003DzcX2HU0yGwowv = null;
		double[] _0023_003Dzm4vrwLJ_HIr = new double[3];
		double[] _0023_003DzZbOaTIM_003D = new double[3];
		_0023_003DzQsK9PuIC8frb._0023_003Dz9HIsjTNTDrB9AQz1hJGhXrs_003D(ref _0023_003DzcX2HU0yGwowv, ref _0023_003Dzm4vrwLJ_HIr, ref _0023_003DzZbOaTIM_003D);
		ICurve _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D = _0023_003DzKttMWhHGVu_0024c(_0023_003DzcX2HU0yGwowv, _0023_003DzPtQTcKPKNs_Eyhu_nA_003D_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D, _0023_003DzvFB_0024dbs_003D: false);
		if (_0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D != null)
		{
			Point3D point3D = new Point3D(_0023_003Dzm4vrwLJ_HIr);
			Vector3D vector3D = new Vector3D(_0023_003DzZbOaTIM_003D);
			Utility._0023_003Dz1zSJGNpo0_0024Y5ZWKOCw_003D_003D(point3D, vector3D, ref _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D, out var _0023_003DzcgQS2OJJ2x_L, out var _0023_003DzU6QO949msgio);
			ICurve curve = (ICurve)_0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D.Clone();
			Plane plane = ((!_0023_003DzcgQS2OJJ2x_L.IsZero) ? new Plane(point3D, _0023_003DzcgQS2OJJ2x_L, Vector3D.Cross(vector3D, _0023_003DzcgQS2OJJ2x_L)) : new Plane(point3D, vector3D));
			if (Utility.IsLine(_0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D) && Vector3D.AreParallel(_0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D.StartTangent, plane.AxisZ))
			{
				PlanarSurf._0023_003DzHNhzuamBoympuHB_8w_003D_003D(plane, _0023_003DzRTbTK_0024KwG32W, out var _0023_003DzG0W_0024gTEMzheB);
				double num = _0023_003DzG0W_0024gTEMzheB.Length * 0.1;
				Point3D point = _0023_003DzU6QO949msgio.PointAt(_0023_003DzG0W_0024gTEMzheB.t0 - num);
				Point3D point2 = _0023_003DzU6QO949msgio.PointAt(_0023_003DzG0W_0024gTEMzheB.t1 + num);
				curve.Project(point, out var t);
				curve.Project(point2, out var t2);
				_0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D = new Line(curve.PointAt(t), curve.PointAt(t2));
				if (Vector3D.AreOpposite(curve.StartTangent, _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D.StartTangent))
				{
					_0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D.Reverse();
				}
			}
			_0023_003DzUVUNqiFNexM1FWzSIA_003D_003D(new Plane(point3D, _0023_003DzcgQS2OJJ2x_L, vector3D), ref _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D);
			return new RevolvedSurf(point3D, vector3D, _0023_003DzcgQS2OJJ2x_L, _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D)
			{
				TranslationID = new TranslationIdentifier(_0023_003DzQsK9PuIC8frb._0023_003DzPNMPkgk_003D(), _0023_003DzQsK9PuIC8frb._0023_003Dzh5UrnhhPGlo6)
			};
		}
		return null;
	}

	private static void _0023_003DzUVUNqiFNexM1FWzSIA_003D_003D(Plane _0023_003DzjDNJ3umjT6Lf, ref ICurve _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D)
	{
		if (!(_0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D is Circle circle) || !(Math.Abs(_0023_003DzjDNJ3umjT6Lf.Project(circle.Center).X) < 1E-12))
		{
			return;
		}
		Interval domain = circle.Domain;
		if (circle is Arc arc)
		{
			domain = arc.Domain;
		}
		if (domain.Length > 3.141592653590793)
		{
			if (Vector3D.AreCoincident(_0023_003DzjDNJ3umjT6Lf.AxisZ, circle.Plane.AxisZ))
			{
				_0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D = new Arc(_0023_003DzjDNJ3umjT6Lf, Point2D.Origin, circle.Radius, 4.71238898038469, 7.853981633974483);
			}
			else
			{
				_0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D = new Arc(_0023_003DzjDNJ3umjT6Lf, Point2D.Origin, circle.Radius, 7.853981633974483, 4.71238898038469);
			}
		}
	}

	private static Surface[] _0023_003DzNAY88qiufkhHRcJBbQ_003D_003D(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzQsK9PuIC8frb, IList<ICurve> _0023_003DzRTbTK_0024KwG32W, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		int _0023_003DzMNyEKNc_003D = 0;
		int _0023_003Dzo_0024bBi0E_003D = 0;
		List<double> _0023_003DzQuv3myvnehSV = new List<double>();
		List<double> _0023_003DzbTcvrXagsoun = new List<double>();
		List<List<_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D>> _0023_003DzTkPhA8X_2C3n = new List<List<_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D>>();
		_0023_003DzQsK9PuIC8frb._0023_003DzvCnXqSqe5J8i(ref _0023_003DzMNyEKNc_003D, ref _0023_003Dzo_0024bBi0E_003D, ref _0023_003DzQuv3myvnehSV, ref _0023_003DzbTcvrXagsoun, ref _0023_003DzTkPhA8X_2C3n);
		Point4D[,] array = new Point4D[_0023_003DzTkPhA8X_2C3n.Count, _0023_003DzTkPhA8X_2C3n[0].Count];
		for (int i = 0; i < array.GetLength(1); i++)
		{
			for (int j = 0; j < array.GetLength(0); j++)
			{
				_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D2 = _0023_003DzTkPhA8X_2C3n[j][i];
				array[j, i] = new Point4D(_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D2._0023_003Dzfj_WbJ59_mOa()[0], _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D2._0023_003Dzfj_WbJ59_mOa()[1], _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D2._0023_003Dzfj_WbJ59_mOa()[2], _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D2._0023_003Dzfj_WbJ59_mOa()[3]);
			}
		}
		Surface surface = new Surface(_0023_003DzMNyEKNc_003D, _0023_003DzQuv3myvnehSV.ToArray(), _0023_003Dzo_0024bBi0E_003D, _0023_003DzbTcvrXagsoun.ToArray(), array);
		if (_0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
		{
			Surface surface2 = surface.Promote();
			if (surface2 != null)
			{
				surface = surface2;
			}
		}
		if (!_0023_003DzQsK9PuIC8frb._0023_003Dz3teLb_0024wWvlUs())
		{
			surface.ReverseU();
		}
		surface.TranslationID = new TranslationIdentifier(_0023_003DzQsK9PuIC8frb._0023_003DzPNMPkgk_003D(), _0023_003DzQsK9PuIC8frb._0023_003DzS_00246o7tc_003D);
		return Surface.DropLoops(surface, _0023_003DzRTbTK_0024KwG32W);
	}

	private static AnalyticSurf _0023_003DzCDczckvMg3jLm9E3xg_003D_003D(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzQsK9PuIC8frb, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		int _0023_003DzMNyEKNc_003D = 0;
		int _0023_003Dzo_0024bBi0E_003D = 0;
		List<double> _0023_003DzQuv3myvnehSV = new List<double>();
		List<double> _0023_003DzbTcvrXagsoun = new List<double>();
		List<List<_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D>> _0023_003DzTkPhA8X_2C3n = new List<List<_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D>>();
		_0023_003DzQsK9PuIC8frb._0023_003DzvCnXqSqe5J8i(ref _0023_003DzMNyEKNc_003D, ref _0023_003Dzo_0024bBi0E_003D, ref _0023_003DzQuv3myvnehSV, ref _0023_003DzbTcvrXagsoun, ref _0023_003DzTkPhA8X_2C3n);
		Point4D[,] array = new Point4D[_0023_003DzTkPhA8X_2C3n.Count, _0023_003DzTkPhA8X_2C3n[0].Count];
		for (int i = 0; i < array.GetLength(1); i++)
		{
			for (int j = 0; j < array.GetLength(0); j++)
			{
				_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D2 = _0023_003DzTkPhA8X_2C3n[j][i];
				array[j, i] = new Point4D(_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D2._0023_003Dzfj_WbJ59_mOa()[0], _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D2._0023_003Dzfj_WbJ59_mOa()[1], _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D2._0023_003Dzfj_WbJ59_mOa()[2], _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D2._0023_003Dzfj_WbJ59_mOa()[3]);
			}
		}
		try
		{
			Surface surface = new Surface(_0023_003DzMNyEKNc_003D, _0023_003DzQuv3myvnehSV.ToArray(), _0023_003Dzo_0024bBi0E_003D, _0023_003DzbTcvrXagsoun.ToArray(), array);
			AnalyticSurf analyticSurf = new NurbsSurf(surface.DegreeU, surface.KnotVectorU, surface.DegreeV, surface.KnotVectorV, surface.ControlPoints);
			if (_0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
			{
				Surface notRotated;
				Surface surface2 = analyticSurf.GetUntrimmed(null, sense: true, out notRotated).Promote();
				if (surface2 != null)
				{
					analyticSurf = surface2._0023_003DzWTGiFlsuyM_0024wBdTI5w_003D_003D();
				}
			}
			analyticSurf.TranslationID = new TranslationIdentifier(_0023_003DzQsK9PuIC8frb._0023_003DzPNMPkgk_003D(), _0023_003DzQsK9PuIC8frb._0023_003Dzh5UrnhhPGlo6);
			return analyticSurf;
		}
		catch (Exception ex)
		{
			_0023_003DzqmF8XJ0_003D.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011672), ex.Message, _0023_003DzQsK9PuIC8frb._0023_003DzPNMPkgk_003D()));
			return null;
		}
	}

	private static Surface[] _0023_003Dz8zHhNtYS2dWIWKY9CFsyqPc_003D(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzQsK9PuIC8frb, IList<ICurve> _0023_003DzRTbTK_0024KwG32W, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		int _0023_003DzMNyEKNc_003D = 0;
		int _0023_003Dzo_0024bBi0E_003D = 0;
		List<List<_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D>> _0023_003DzTkPhA8X_2C3n = new List<List<_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D>>();
		_0023_003DzQsK9PuIC8frb._0023_003DzoYGXDANv9X_YGrpV5w_003D_003D(ref _0023_003DzMNyEKNc_003D, ref _0023_003Dzo_0024bBi0E_003D, ref _0023_003DzTkPhA8X_2C3n);
		Point4D[,] array = new Point4D[_0023_003DzTkPhA8X_2C3n.Count, _0023_003DzTkPhA8X_2C3n[0].Count];
		for (int i = 0; i < array.GetLength(1); i++)
		{
			for (int j = 0; j < array.GetLength(0); j++)
			{
				_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D2 = _0023_003DzTkPhA8X_2C3n[j][i];
				array[j, i] = new Point4D(_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D2._0023_003Dzfj_WbJ59_mOa()[0], _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D2._0023_003Dzfj_WbJ59_mOa()[1], _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D2._0023_003Dzfj_WbJ59_mOa()[2], _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D2._0023_003Dzfj_WbJ59_mOa()[3]);
			}
		}
		Surface surface = new Surface(_0023_003DzMNyEKNc_003D, NurbsBase.UniformKnotVector(_0023_003DzMNyEKNc_003D, array.GetLength(0)), _0023_003Dzo_0024bBi0E_003D, NurbsBase.UniformKnotVector(_0023_003Dzo_0024bBi0E_003D, array.GetLength(1)), array);
		if (_0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
		{
			Surface surface2 = surface.Promote();
			if (surface2 != null)
			{
				surface = surface2;
			}
		}
		if (!_0023_003DzQsK9PuIC8frb._0023_003Dz3teLb_0024wWvlUs())
		{
			surface.ReverseU();
		}
		surface.TranslationID = new TranslationIdentifier(_0023_003DzQsK9PuIC8frb._0023_003DzPNMPkgk_003D(), _0023_003DzQsK9PuIC8frb._0023_003DzS_00246o7tc_003D);
		return Surface.DropLoops(surface, _0023_003DzRTbTK_0024KwG32W);
	}

	private static AnalyticSurf _0023_003DzcBpLuKwuDkpV21gxjZTR_00247s_003D(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzQsK9PuIC8frb, IList<ICurve> _0023_003DzRTbTK_0024KwG32W, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		int _0023_003DzMNyEKNc_003D = 0;
		int _0023_003Dzo_0024bBi0E_003D = 0;
		List<List<_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D>> _0023_003DzTkPhA8X_2C3n = new List<List<_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D>>();
		_0023_003DzQsK9PuIC8frb._0023_003DzoYGXDANv9X_YGrpV5w_003D_003D(ref _0023_003DzMNyEKNc_003D, ref _0023_003Dzo_0024bBi0E_003D, ref _0023_003DzTkPhA8X_2C3n);
		Point4D[,] array = new Point4D[_0023_003DzTkPhA8X_2C3n.Count, _0023_003DzTkPhA8X_2C3n[0].Count];
		for (int i = 0; i < array.GetLength(1); i++)
		{
			for (int j = 0; j < array.GetLength(0); j++)
			{
				_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D2 = _0023_003DzTkPhA8X_2C3n[j][i];
				array[j, i] = new Point4D(_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D2._0023_003Dzfj_WbJ59_mOa()[0], _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D2._0023_003Dzfj_WbJ59_mOa()[1], _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D2._0023_003Dzfj_WbJ59_mOa()[2], _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D2._0023_003Dzfj_WbJ59_mOa()[3]);
			}
		}
		AnalyticSurf analyticSurf = new NurbsSurf(_0023_003DzMNyEKNc_003D, NurbsBase.UniformKnotVector(_0023_003DzMNyEKNc_003D, array.GetLength(0)), _0023_003Dzo_0024bBi0E_003D, NurbsBase.UniformKnotVector(_0023_003Dzo_0024bBi0E_003D, array.GetLength(1)), array);
		if (_0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
		{
			Surface notRotated;
			Surface surface = analyticSurf.GetUntrimmed(null, sense: true, out notRotated).Promote();
			if (surface != null)
			{
				analyticSurf = surface._0023_003DzWTGiFlsuyM_0024wBdTI5w_003D_003D();
			}
		}
		analyticSurf.TranslationID = new TranslationIdentifier(_0023_003DzQsK9PuIC8frb._0023_003DzPNMPkgk_003D(), _0023_003DzQsK9PuIC8frb._0023_003Dzh5UrnhhPGlo6);
		return analyticSurf;
	}

	private static Surface[] _0023_003DzeV1USXt5_0024jRL(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzQsK9PuIC8frb, IList<ICurve> _0023_003DzRTbTK_0024KwG32W, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		int _0023_003DzMNyEKNc_003D = 0;
		int _0023_003Dzo_0024bBi0E_003D = 0;
		List<double> _0023_003DzQuv3myvnehSV = new List<double>();
		List<double> _0023_003DzbTcvrXagsoun = new List<double>();
		List<List<_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D>> _0023_003DzTkPhA8X_2C3n = new List<List<_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D>>();
		_0023_003DzQsK9PuIC8frb._0023_003DzvCnXqSqe5J8i(ref _0023_003DzMNyEKNc_003D, ref _0023_003Dzo_0024bBi0E_003D, ref _0023_003DzQuv3myvnehSV, ref _0023_003DzbTcvrXagsoun, ref _0023_003DzTkPhA8X_2C3n);
		Point4D[,] array = new Point4D[_0023_003DzTkPhA8X_2C3n.Count, _0023_003DzTkPhA8X_2C3n[0].Count];
		int length = array.GetLength(0);
		int length2 = array.GetLength(1);
		for (int i = 0; i < length2; i++)
		{
			for (int j = 0; j < length; j++)
			{
				_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D2 = _0023_003DzTkPhA8X_2C3n[j][i];
				double num = _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D2._0023_003Dzfj_WbJ59_mOa()[3];
				array[j, i] = new Point4D(_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D2._0023_003Dzfj_WbJ59_mOa()[0] * num, _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D2._0023_003Dzfj_WbJ59_mOa()[1] * num, _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D2._0023_003Dzfj_WbJ59_mOa()[2] * num, num);
			}
		}
		Surface surface = ((_0023_003DzQuv3myvnehSV.Count != 0) ? new Surface(_0023_003DzMNyEKNc_003D, _0023_003DzQuv3myvnehSV.ToArray(), _0023_003Dzo_0024bBi0E_003D, _0023_003DzbTcvrXagsoun.ToArray(), array) : new Surface(_0023_003DzMNyEKNc_003D, NurbsBase.UniformKnotVector(_0023_003DzMNyEKNc_003D, length), _0023_003Dzo_0024bBi0E_003D, NurbsBase.UniformKnotVector(_0023_003Dzo_0024bBi0E_003D, length2), array));
		if (_0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
		{
			Surface surface2 = surface.Promote();
			if (surface2 != null)
			{
				surface = surface2;
			}
		}
		if (!_0023_003DzQsK9PuIC8frb._0023_003Dz3teLb_0024wWvlUs())
		{
			surface.ReverseU();
		}
		surface.TranslationID = new TranslationIdentifier(_0023_003DzQsK9PuIC8frb._0023_003DzPNMPkgk_003D(), _0023_003DzQsK9PuIC8frb._0023_003DzS_00246o7tc_003D);
		return Surface.DropLoops(surface, _0023_003DzRTbTK_0024KwG32W);
	}

	private static AnalyticSurf _0023_003Dz94HA_bAG9Irn(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzQsK9PuIC8frb, IList<ICurve> _0023_003DzRTbTK_0024KwG32W, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D, ref bool _0023_003DzClBtlvaHChzq)
	{
		int _0023_003DzMNyEKNc_003D = 0;
		int _0023_003Dzo_0024bBi0E_003D = 0;
		List<double> _0023_003DzQuv3myvnehSV = new List<double>();
		List<double> _0023_003DzbTcvrXagsoun = new List<double>();
		List<List<_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D>> _0023_003DzTkPhA8X_2C3n = new List<List<_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D>>();
		_0023_003DzQsK9PuIC8frb._0023_003DzvCnXqSqe5J8i(ref _0023_003DzMNyEKNc_003D, ref _0023_003Dzo_0024bBi0E_003D, ref _0023_003DzQuv3myvnehSV, ref _0023_003DzbTcvrXagsoun, ref _0023_003DzTkPhA8X_2C3n);
		Point4D[,] array = new Point4D[_0023_003DzTkPhA8X_2C3n.Count, _0023_003DzTkPhA8X_2C3n[0].Count];
		int length = array.GetLength(0);
		int length2 = array.GetLength(1);
		for (int i = 0; i < length2; i++)
		{
			for (int j = 0; j < length; j++)
			{
				_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D2 = _0023_003DzTkPhA8X_2C3n[j][i];
				double num = _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D2._0023_003Dzfj_WbJ59_mOa()[3];
				array[j, i] = new Point4D(_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D2._0023_003Dzfj_WbJ59_mOa()[0] * num, _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D2._0023_003Dzfj_WbJ59_mOa()[1] * num, _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D2._0023_003Dzfj_WbJ59_mOa()[2] * num, num);
			}
		}
		AnalyticSurf analyticSurf;
		if (_0023_003DzQuv3myvnehSV.Count == 0)
		{
			analyticSurf = new NurbsSurf(_0023_003DzMNyEKNc_003D, NurbsBase.UniformKnotVector(_0023_003DzMNyEKNc_003D, length), _0023_003Dzo_0024bBi0E_003D, NurbsBase.UniformKnotVector(_0023_003Dzo_0024bBi0E_003D, length2), array);
		}
		else
		{
			Surface surface = new Surface(_0023_003DzMNyEKNc_003D, _0023_003DzQuv3myvnehSV.ToArray(), _0023_003Dzo_0024bBi0E_003D, _0023_003DzbTcvrXagsoun.ToArray(), array);
			analyticSurf = new NurbsSurf(surface.DegreeU, surface.KnotVectorU, surface.DegreeV, surface.KnotVectorV, surface.ControlPoints);
		}
		if (_0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
		{
			Surface notRotated;
			Surface surface2 = analyticSurf.GetUntrimmed(null, sense: true, out notRotated).Promote();
			if (surface2 != null)
			{
				Utility.UpdateAnalyticSurfSense(surface2, ref _0023_003DzClBtlvaHChzq);
				analyticSurf = surface2._0023_003DzWTGiFlsuyM_0024wBdTI5w_003D_003D();
			}
		}
		analyticSurf.TranslationID = new TranslationIdentifier(_0023_003DzQsK9PuIC8frb._0023_003DzPNMPkgk_003D(), _0023_003DzQsK9PuIC8frb._0023_003Dzh5UrnhhPGlo6);
		return analyticSurf;
	}

	private static Surface[] _0023_003Dzb9_00241shsIGtAJ(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzQsK9PuIC8frb, IList<ICurve> _0023_003DzRTbTK_0024KwG32W, angularUnitsType _0023_003DzPtQTcKPKNs_Eyhu_nA_003D_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003Dz7lN2laB_oQwjmePUkg_003D_003D = new _0023_003DzbykJA36oCfUxYTgeaw_003D_003D();
		double _0023_003DzXMGjKnoZdqec = 0.0;
		_0023_003DzQsK9PuIC8frb._0023_003DzfcYa3t2I4XL_(ref _0023_003Dz7lN2laB_oQwjmePUkg_003D_003D, ref _0023_003DzXMGjKnoZdqec);
		Surface surface = (Surface)_0023_003DzuTCwRvbXUrZU(_0023_003Dz7lN2laB_oQwjmePUkg_003D_003D, _0023_003DzPtQTcKPKNs_Eyhu_nA_003D_003D, ReadFileAsync.DEFAULT_COLOR, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D)[0];
		double tol = surface.ControlBoundingBox().Diagonal * Utility._0023_003Dzjyaz_Vfaky9X;
		surface.Offset(_0023_003DzXMGjKnoZdqec, tol, out var offsetSurf);
		if (_0023_003DzRTbTK_0024KwG32W[0] is CompositeCurve compositeCurve)
		{
			Point3D startPoint = compositeCurve.CurveList[0].StartPoint;
			offsetSurf.Project(startPoint, Math.Abs(_0023_003DzXMGjKnoZdqec) / 10.0, allowOutside: false, out var proj);
			if (offsetSurf.PointAt(proj).DistanceTo(startPoint) > 3.0 * Math.Abs(_0023_003DzXMGjKnoZdqec) / 2.0)
			{
				surface.Offset(0.0 - _0023_003DzXMGjKnoZdqec, tol, out offsetSurf);
			}
		}
		if (!_0023_003DzQsK9PuIC8frb._0023_003Dz3teLb_0024wWvlUs())
		{
			offsetSurf.ReverseU();
		}
		offsetSurf.TranslationID = new TranslationIdentifier(_0023_003DzQsK9PuIC8frb._0023_003DzPNMPkgk_003D(), _0023_003DzQsK9PuIC8frb._0023_003DzS_00246o7tc_003D);
		return Surface.DropLoops(offsetSurf, _0023_003DzRTbTK_0024KwG32W);
	}

	private static NurbsSurf _0023_003Dz5GMCUmf_cOKs(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzQsK9PuIC8frb, IList<ICurve> _0023_003DzRTbTK_0024KwG32W, angularUnitsType _0023_003DzPtQTcKPKNs_Eyhu_nA_003D_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003Dz7lN2laB_oQwjmePUkg_003D_003D = new _0023_003DzbykJA36oCfUxYTgeaw_003D_003D();
		double _0023_003DzXMGjKnoZdqec = 0.0;
		_0023_003DzQsK9PuIC8frb._0023_003DzfcYa3t2I4XL_(ref _0023_003Dz7lN2laB_oQwjmePUkg_003D_003D, ref _0023_003DzXMGjKnoZdqec);
		bool _0023_003DzClBtlvaHChzq = true;
		Surface notRotated;
		Surface untrimmed = _0023_003Dz0SlujM_0024ENJMg(_0023_003DzPtQTcKPKNs_Eyhu_nA_003D_003D, _0023_003Dz7lN2laB_oQwjmePUkg_003D_003D, _0023_003DzRTbTK_0024KwG32W, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D, ref _0023_003DzClBtlvaHChzq).GetUntrimmed(_0023_003DzRTbTK_0024KwG32W, _0023_003DzXMGjKnoZdqec > 0.0, out notRotated);
		untrimmed.Offset(tol: untrimmed.ControlBoundingBox().Diagonal * Utility._0023_003Dzjyaz_Vfaky9X, amount: Math.Abs(_0023_003DzXMGjKnoZdqec), offsetSurf: out var offsetSurf);
		return new NurbsSurf(offsetSurf.DegreeU, offsetSurf.KnotVectorU, offsetSurf.DegreeV, offsetSurf.KnotVectorV, offsetSurf.ControlPoints)
		{
			TranslationID = new TranslationIdentifier(_0023_003DzQsK9PuIC8frb._0023_003DzPNMPkgk_003D(), _0023_003DzQsK9PuIC8frb._0023_003Dzh5UrnhhPGlo6)
		};
	}

	private static ICurve _0023_003DzfszPGi1SYGRQ1qdQJQg1Ppk_003D(List<_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D> _0023_003Dz_SqBXz8_003D, angularUnitsType _0023_003DzPtQTcKPKNs_Eyhu_nA_003D_003D, IList<bool> _0023_003Dz6hQ2Ons_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		List<ICurve> list = new List<ICurve>();
		for (int i = 0; i < _0023_003Dz_SqBXz8_003D.Count; i++)
		{
			ICurve curve = _0023_003DzKttMWhHGVu_0024c(_0023_003Dz_SqBXz8_003D[i], _0023_003DzPtQTcKPKNs_Eyhu_nA_003D_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D, _0023_003DzvFB_0024dbs_003D: true);
			if (curve != null)
			{
				if (_0023_003Dz6hQ2Ons_003D != null && _0023_003Dz6hQ2Ons_003D.Count > 0 && !_0023_003Dz6hQ2Ons_003D[i])
				{
					curve.Reverse();
				}
				list.Add(curve);
			}
		}
		return Utility.SmartAdd(list);
	}

	private static ICurve _0023_003DzKttMWhHGVu_0024c(_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D _0023_003DzcX2HU0yGwowv, angularUnitsType _0023_003DzPtQTcKPKNs_Eyhu_nA_003D_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D, bool _0023_003DzvFB_0024dbs_003D)
	{
		ICurve curve = null;
		Point3D _0023_003Dz7jzaWWU_003D;
		Point3D _0023_003DzJ4EY_H0_003D;
		ICurve sub;
		switch (_0023_003DzcX2HU0yGwowv._0023_003Dz_0024ttTvKKQ4wyB())
		{
		case (_0023_003DzERg3UXoyLz7qZsYsfajZhaw_003D)8:
		{
			double[] _0023_003DzrNyhm6g_003D = new double[3];
			double[] _0023_003DztY_anuo_003D = new double[3];
			double _0023_003Dzfsd_f2y5yave = 0.0;
			double _0023_003DzdsTiawhhXN8G = 0.0;
			bool _0023_003DznRGKF2T2ZsN6Flrnxw_003D_003D = false;
			_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D _0023_003DzcX2HU0yGwowv4 = new _0023_003DzAesEZlpt4n5DGdrqIA_003D_003D();
			if (_0023_003DzcX2HU0yGwowv._0023_003Dz_TvQAuPIiO_0024qYE1Lwb5nLPg_003D())
			{
				_0023_003DzcX2HU0yGwowv._0023_003DzFaRMyJYBB1h_0024(ref _0023_003DzcX2HU0yGwowv4, ref _0023_003DzrNyhm6g_003D, ref _0023_003DztY_anuo_003D, ref _0023_003DznRGKF2T2ZsN6Flrnxw_003D_003D);
				curve = _0023_003DzZpSyWoKjbrWE(_0023_003DzcX2HU0yGwowv4, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D, _0023_003DzvFB_0024dbs_003D);
				Point3D point3D = new Point3D(_0023_003DzrNyhm6g_003D);
				Point3D point3D2 = new Point3D(_0023_003DztY_anuo_003D);
				if (!_0023_003DzcX2HU0yGwowv4._0023_003DzGwuYzgEfSgJW)
				{
					curve.Reverse();
				}
				if (curve is Line _0023_003DzOGUeWbk_003D)
				{
					curve = _0023_003Dz_V8EbXcmZ8au(_0023_003DzOGUeWbk_003D, point3D, point3D2);
				}
				else if (curve.SubCurve(point3D, point3D2, out sub))
				{
					((Entity)sub).TranslationID = ((Entity)curve).TranslationID;
					curve = sub;
				}
				else
				{
					_0023_003DzZQK6w4U_003D(curve, _0023_003DzqmF8XJ0_003D);
				}
				break;
			}
			_0023_003DzcX2HU0yGwowv._0023_003DzFaRMyJYBB1h_0024(ref _0023_003DzcX2HU0yGwowv4, ref _0023_003Dzfsd_f2y5yave, ref _0023_003DzdsTiawhhXN8G, ref _0023_003DznRGKF2T2ZsN6Flrnxw_003D_003D);
			curve = _0023_003DzZpSyWoKjbrWE(_0023_003DzcX2HU0yGwowv4, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D, _0023_003DzvFB_0024dbs_003D);
			if (curve == null)
			{
				return null;
			}
			if (_0023_003DzcX2HU0yGwowv4._0023_003DzyXmKbtw_003D is _0023_003DzPuJOpHVsPzETHSf6D00_00247IE_003D)
			{
				double[] array = ((_0023_003DzPuJOpHVsPzETHSf6D00_00247IE_003D)_0023_003DzcX2HU0yGwowv4._0023_003DzyXmKbtw_003D)._0023_003DzjN7uSQk_003D._0023_003DzCGTSeY0_003D._0023_003Dzfj_WbJ59_mOa();
				Vector3D vector3D = new Vector3D(((_0023_003DzPuJOpHVsPzETHSf6D00_00247IE_003D)_0023_003DzcX2HU0yGwowv4._0023_003DzyXmKbtw_003D)._0023_003DzjN7uSQk_003D._0023_003DzHwk42AaBD9wG._0023_003DzqdOG1COev7La);
				Vector3D vector3D2 = Vector3D.Cross(new Vector3D(((_0023_003DzPuJOpHVsPzETHSf6D00_00247IE_003D)_0023_003DzcX2HU0yGwowv4._0023_003DzyXmKbtw_003D)._0023_003DzjN7uSQk_003D._0023_003Dz1_0024d_00248flwjiOW._0023_003DzqdOG1COev7La), vector3D);
				double _0023_003DzkGnm1Q7Mpi4H8JVYXQ_003D_003D = ((_0023_003DzPuJOpHVsPzETHSf6D00_00247IE_003D)_0023_003DzcX2HU0yGwowv4._0023_003DzyXmKbtw_003D)._0023_003DzkGnm1Q7Mpi4H8JVYXQ_003D_003D;
				Plane destinationFrame = new Plane(new Point3D(array[0], array[1], array[2]), new Vector3D(vector3D2[0], vector3D2[1], vector3D2[2]), new Vector3D(vector3D[0], vector3D[1], vector3D[2]));
				Align3D xform = new Align3D(Plane.YX, destinationFrame);
				double num3 = 0.0;
				double[] array2 = new double[3]
				{
					_0023_003Dzfsd_f2y5yave + num3,
					(_0023_003Dzfsd_f2y5yave + _0023_003DzdsTiawhhXN8G) / 2.0 + num3,
					_0023_003DzdsTiawhhXN8G + num3
				};
				Point3D[] array3 = new Point3D[3];
				Vector3D[] array4 = new Vector3D[3];
				for (int i = 0; i < 3; i++)
				{
					double num4 = array2[i];
					array3[i] = new Point3D(_0023_003DzkGnm1Q7Mpi4H8JVYXQ_003D_003D * num4 * num4, 2.0 * _0023_003DzkGnm1Q7Mpi4H8JVYXQ_003D_003D * num4);
					double x = 1.0 / (2.0 * _0023_003DzkGnm1Q7Mpi4H8JVYXQ_003D_003D) * array3[i].Y;
					array4[i] = new Vector3D(x, 1.0);
				}
				curve = new Curve(array3[0], array4[0], array3[2], array4[2], array3[1]);
				((Entity)curve).TranslationID = new TranslationIdentifier(_0023_003DzcX2HU0yGwowv4._0023_003DzOq3xSxQ_003D(), _0023_003DzcX2HU0yGwowv4._0023_003DzS_00246o7tc_003D);
				((Entity)curve).TransformBy(xform);
			}
			bool flag = curve is Circle || curve is Ellipse;
			if (flag && _0023_003DzPtQTcKPKNs_Eyhu_nA_003D_003D == angularUnitsType.Degrees)
			{
				_0023_003Dzfsd_f2y5yave = Utility.DegToRad(_0023_003Dzfsd_f2y5yave);
				_0023_003DzdsTiawhhXN8G = Utility.DegToRad(_0023_003DzdsTiawhhXN8G);
			}
			else if (!flag && !(curve is Curve))
			{
				_0023_003Dzfsd_f2y5yave *= curve.Length();
				_0023_003DzdsTiawhhXN8G *= curve.Length();
			}
			if (_0023_003DznRGKF2T2ZsN6Flrnxw_003D_003D)
			{
				break;
			}
			if (flag && _0023_003Dzfsd_f2y5yave > _0023_003DzdsTiawhhXN8G)
			{
				if (!_0023_003DzcX2HU0yGwowv4._0023_003DzGwuYzgEfSgJW)
				{
					Utility.Swap(ref _0023_003Dzfsd_f2y5yave, ref _0023_003DzdsTiawhhXN8G);
				}
				else
				{
					_0023_003DzdsTiawhhXN8G += Math.PI * 2.0;
				}
			}
			if (curve is Ellipse)
			{
				Ellipse ellipse2 = (Ellipse)curve;
				curve = new EllipticalArc(ellipse2.Plane, ellipse2.Plane.Origin, ellipse2.RadiusX, ellipse2.RadiusY, _0023_003Dzfsd_f2y5yave, _0023_003DzdsTiawhhXN8G, polarAngles: true);
				((Entity)curve).TranslationID = ellipse2.TranslationID;
			}
			else if (curve.SubCurve(_0023_003Dzfsd_f2y5yave, _0023_003DzdsTiawhhXN8G, out sub))
			{
				((Entity)sub).TranslationID = ((Entity)curve).TranslationID;
				curve = sub;
			}
			else
			{
				_0023_003DzZQK6w4U_003D(curve, _0023_003DzqmF8XJ0_003D);
			}
			break;
		}
		case (_0023_003DzERg3UXoyLz7qZsYsfajZhaw_003D)5:
			curve = _0023_003DzZpSyWoKjbrWE(_0023_003DzcX2HU0yGwowv, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D, _0023_003DzvFB_0024dbs_003D);
			if (_0023_003DzcX2HU0yGwowv._0023_003Dz5nHCn49fRiQA() != null)
			{
				_0023_003DzaTRuktlgQdbc(_0023_003DzcX2HU0yGwowv, out _0023_003Dz7jzaWWU_003D, out _0023_003DzJ4EY_H0_003D);
				if (curve.SubCurve(_0023_003Dz7jzaWWU_003D, _0023_003DzJ4EY_H0_003D, out sub))
				{
					((Entity)sub).TranslationID = ((Entity)curve).TranslationID;
					curve = sub;
				}
				else
				{
					_0023_003DzZQK6w4U_003D(curve, _0023_003DzqmF8XJ0_003D);
				}
			}
			break;
		case (_0023_003DzERg3UXoyLz7qZsYsfajZhaw_003D)4:
		{
			curve = _0023_003DzZpSyWoKjbrWE(_0023_003DzcX2HU0yGwowv, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D, _0023_003DzvFB_0024dbs_003D);
			if (_0023_003DzcX2HU0yGwowv._0023_003Dz5nHCn49fRiQA() == null)
			{
				break;
			}
			_0023_003DzaTRuktlgQdbc(_0023_003DzcX2HU0yGwowv, out _0023_003Dz7jzaWWU_003D, out _0023_003DzJ4EY_H0_003D);
			double num5 = Utility._0023_003DzxhnLabVjXjPg * ((Curve)curve).ControlLength() / (Math.PI * 2.0);
			if (_0023_003Dz7jzaWWU_003D.DistanceTo(_0023_003DzJ4EY_H0_003D) < num5)
			{
				if (curve.StartPoint.DistanceTo(_0023_003DzJ4EY_H0_003D) > num5 && curve.StartPoint.DistanceTo(_0023_003Dz7jzaWWU_003D) > num5 && curve.SplitBy(_0023_003Dz7jzaWWU_003D, out var lower, out var upper))
				{
					curve = Curve.Merge(upper, lower);
					((Entity)curve).TranslationID = new TranslationIdentifier(_0023_003DzcX2HU0yGwowv._0023_003DzOq3xSxQ_003D(), _0023_003DzcX2HU0yGwowv._0023_003DzS_00246o7tc_003D);
				}
				break;
			}
			curve.ClosestPointTo(_0023_003Dz7jzaWWU_003D, out var t);
			curve.ClosestPointTo(_0023_003DzJ4EY_H0_003D, out var t2);
			if (t > t2)
			{
				if (curve.IsClosed)
				{
					if (t == curve.Domain.High)
					{
						t = curve.Domain.Low;
					}
					else if (t2 == curve.Domain.Low)
					{
						t2 = curve.Domain.High;
					}
				}
				else if (t2 != curve.Domain.Low)
				{
					t = curve.Domain.Low;
				}
				else if (t != curve.Domain.High)
				{
					t2 = curve.Domain.High;
				}
			}
			if (curve.SubCurve(t, t2, out sub))
			{
				((Entity)sub).TranslationID = ((Entity)curve).TranslationID;
				curve = sub;
			}
			else
			{
				_0023_003DzZQK6w4U_003D(curve, _0023_003DzqmF8XJ0_003D);
			}
			break;
		}
		case (_0023_003DzERg3UXoyLz7qZsYsfajZhaw_003D)7:
		{
			_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D _0023_003DzcX2HU0yGwowv3 = new _0023_003DzAesEZlpt4n5DGdrqIA_003D_003D();
			_0023_003DzcX2HU0yGwowv._0023_003DzWXQZgo9zVt6N(ref _0023_003DzcX2HU0yGwowv3);
			curve = _0023_003DzZpSyWoKjbrWE(_0023_003DzcX2HU0yGwowv3, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D, _0023_003DzvFB_0024dbs_003D);
			break;
		}
		case (_0023_003DzERg3UXoyLz7qZsYsfajZhaw_003D)9:
		{
			_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D _0023_003DzcX2HU0yGwowv5 = new _0023_003DzAesEZlpt4n5DGdrqIA_003D_003D();
			List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003DzZdVMPLLyTc368DDKmQ_003D_003D2 = new List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>();
			_0023_003DzcX2HU0yGwowv._0023_003Dz8je7iDVZPcJ8(ref _0023_003DzcX2HU0yGwowv5, ref _0023_003DzZdVMPLLyTc368DDKmQ_003D_003D2);
			_0023_003DzcX2HU0yGwowv5._0023_003DzGwuYzgEfSgJW = _0023_003DzcX2HU0yGwowv._0023_003DzGwuYzgEfSgJW;
			curve = _0023_003DzKttMWhHGVu_0024c(_0023_003DzcX2HU0yGwowv5, _0023_003DzPtQTcKPKNs_Eyhu_nA_003D_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D, _0023_003DzvFB_0024dbs_003D);
			if (curve == null || _0023_003DzcX2HU0yGwowv._0023_003Dz5nHCn49fRiQA() == null)
			{
				break;
			}
			_0023_003DzaTRuktlgQdbc(_0023_003DzcX2HU0yGwowv, out _0023_003Dz7jzaWWU_003D, out _0023_003DzJ4EY_H0_003D);
			if (_0023_003Dz7jzaWWU_003D != _0023_003DzJ4EY_H0_003D)
			{
				if (_0023_003DzcX2HU0yGwowv5._0023_003DzyXmKbtw_003D is _0023_003DzYJKD_00247jb1sJL80sUSNwZIPbHHwK2)
				{
					curve = _0023_003Dzz_OiIk1X7_QTvJOgD941gAA_003D(_0023_003DzcX2HU0yGwowv5, _0023_003Dz7jzaWWU_003D, _0023_003DzJ4EY_H0_003D, curve);
				}
				else if (curve is Ellipse ellipse3)
				{
					sub = new EllipticalArc(ellipse3.Plane, ellipse3.Plane.Origin, ellipse3.RadiusX, ellipse3.RadiusY, _0023_003Dz7jzaWWU_003D, _0023_003DzJ4EY_H0_003D, flip: false);
					((Entity)sub).TranslationID = ((Entity)curve).TranslationID;
					curve = sub;
				}
				else if (curve is Line _0023_003DzOGUeWbk_003D2)
				{
					curve = _0023_003Dz_V8EbXcmZ8au(_0023_003DzOGUeWbk_003D2, _0023_003Dz7jzaWWU_003D, _0023_003DzJ4EY_H0_003D);
				}
				else if (curve.SubCurve(_0023_003Dz7jzaWWU_003D, _0023_003DzJ4EY_H0_003D, out sub))
				{
					((Entity)sub).TranslationID = ((Entity)curve).TranslationID;
					curve = sub;
				}
				else
				{
					_0023_003DzZQK6w4U_003D(curve, _0023_003DzqmF8XJ0_003D);
				}
			}
			break;
		}
		case (_0023_003DzERg3UXoyLz7qZsYsfajZhaw_003D)13:
		{
			_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D _0023_003DzcX2HU0yGwowv2 = new _0023_003DzAesEZlpt4n5DGdrqIA_003D_003D();
			List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003DzZdVMPLLyTc368DDKmQ_003D_003D = new List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>();
			_0023_003DzcX2HU0yGwowv._0023_003DzdanNFUwSHGUfDeBYYw_003D_003D(ref _0023_003DzcX2HU0yGwowv2, ref _0023_003DzZdVMPLLyTc368DDKmQ_003D_003D);
			_0023_003DzcX2HU0yGwowv2._0023_003DzGwuYzgEfSgJW = _0023_003DzcX2HU0yGwowv._0023_003DzGwuYzgEfSgJW;
			curve = _0023_003DzZpSyWoKjbrWE(_0023_003DzcX2HU0yGwowv2, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D, _0023_003DzvFB_0024dbs_003D);
			if (_0023_003DzcX2HU0yGwowv._0023_003Dz5nHCn49fRiQA() != null && curve != null)
			{
				_0023_003DzaTRuktlgQdbc(_0023_003DzcX2HU0yGwowv, out _0023_003Dz7jzaWWU_003D, out _0023_003DzJ4EY_H0_003D);
				if (curve.SubCurve(_0023_003Dz7jzaWWU_003D, _0023_003DzJ4EY_H0_003D, out sub))
				{
					((Entity)sub).TranslationID = ((Entity)curve).TranslationID;
					curve = sub;
				}
				else
				{
					_0023_003DzZQK6w4U_003D(curve, _0023_003DzqmF8XJ0_003D);
				}
			}
			break;
		}
		case (_0023_003DzERg3UXoyLz7qZsYsfajZhaw_003D)0:
			if (_0023_003DzcX2HU0yGwowv._0023_003DzyXmKbtw_003D is _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu)
			{
				curve = new devDept.Eyeshot.Entities.Point(new Point3D(((_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu)_0023_003DzcX2HU0yGwowv._0023_003DzyXmKbtw_003D)._0023_003Dzfj_WbJ59_mOa()));
				((Entity)curve).TranslationID = new TranslationIdentifier(_0023_003DzcX2HU0yGwowv._0023_003DzOq3xSxQ_003D(), _0023_003DzcX2HU0yGwowv._0023_003DzS_00246o7tc_003D);
			}
			else
			{
				_0023_003DzqmF8XJ0_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011647) + _0023_003DzcX2HU0yGwowv._0023_003DzOq3xSxQ_003D());
			}
			break;
		default:
			curve = _0023_003DzZpSyWoKjbrWE(_0023_003DzcX2HU0yGwowv, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzqmF8XJ0_003D, _0023_003DzvFB_0024dbs_003D);
			if (curve == null || _0023_003DzcX2HU0yGwowv._0023_003Dz5nHCn49fRiQA() == null)
			{
				break;
			}
			if (_0023_003DzcX2HU0yGwowv._0023_003DzyXmKbtw_003D is _0023_003DzYJKD_00247jb1sJL80sUSNwZIPbHHwK2)
			{
				_0023_003DzaTRuktlgQdbc(_0023_003DzcX2HU0yGwowv, out _0023_003Dz7jzaWWU_003D, out _0023_003DzJ4EY_H0_003D);
				curve = _0023_003Dzz_OiIk1X7_QTvJOgD941gAA_003D(_0023_003DzcX2HU0yGwowv, _0023_003Dz7jzaWWU_003D, _0023_003DzJ4EY_H0_003D, curve);
			}
			if (_0023_003DzcX2HU0yGwowv._0023_003DzyXmKbtw_003D is _0023_003DzPuJOpHVsPzETHSf6D00_00247IE_003D)
			{
				_0023_003DzaTRuktlgQdbc(_0023_003DzcX2HU0yGwowv, out _0023_003Dz7jzaWWU_003D, out _0023_003DzJ4EY_H0_003D);
				double num = Point3D.DistanceSquared(_0023_003Dz7jzaWWU_003D, _0023_003DzJ4EY_H0_003D) * Utility._0023_003DzxhnLabVjXjPg;
				if (curve.SubCurve(_0023_003Dz7jzaWWU_003D, _0023_003DzJ4EY_H0_003D, out sub) && Point3D.DistanceSquared(sub.StartPoint, _0023_003Dz7jzaWWU_003D) < num && Point3D.DistanceSquared(sub.EndPoint, _0023_003DzJ4EY_H0_003D) < num)
				{
					((Entity)sub).TranslationID = ((Entity)curve).TranslationID;
					curve = sub;
				}
				else
				{
					curve = null;
				}
			}
			else if (curve is Circle)
			{
				_0023_003DzaTRuktlgQdbc(_0023_003DzcX2HU0yGwowv, out _0023_003Dz7jzaWWU_003D, out _0023_003DzJ4EY_H0_003D);
				Circle circle = (Circle)curve;
				_0023_003DzQY_zRVuyAz4K(curve, _0023_003Dz7jzaWWU_003D, _0023_003DzJ4EY_H0_003D, out var _0023_003DzwZ1I1_0_003D, out var _0023_003DztSV8BY8_003D);
				curve = ((Utility.AreEqual(_0023_003DzwZ1I1_0_003D, _0023_003DztSV8BY8_003D, Math.PI * 2.0) || Utility.AreEqual(_0023_003DzwZ1I1_0_003D + Math.PI * 2.0, _0023_003DztSV8BY8_003D, Math.PI * 2.0)) ? new Arc(circle.Plane, Point2D.Origin, circle.Radius, _0023_003DzwZ1I1_0_003D, _0023_003DzwZ1I1_0_003D + Math.PI * 2.0)
				{
					TranslationID = new TranslationIdentifier(_0023_003DzcX2HU0yGwowv._0023_003DzOq3xSxQ_003D(), _0023_003DzcX2HU0yGwowv._0023_003DzS_00246o7tc_003D)
				} : new Arc(circle.Plane, circle.Center, circle.Radius, _0023_003DzwZ1I1_0_003D, _0023_003DztSV8BY8_003D)
				{
					TranslationID = new TranslationIdentifier(_0023_003DzcX2HU0yGwowv._0023_003DzOq3xSxQ_003D(), _0023_003DzcX2HU0yGwowv._0023_003DzS_00246o7tc_003D)
				});
			}
			else if (curve is Ellipse)
			{
				_0023_003DzaTRuktlgQdbc(_0023_003DzcX2HU0yGwowv, out _0023_003Dz7jzaWWU_003D, out _0023_003DzJ4EY_H0_003D);
				Ellipse ellipse = (Ellipse)curve;
				_0023_003DzQY_zRVuyAz4K(curve, _0023_003Dz7jzaWWU_003D, _0023_003DzJ4EY_H0_003D, out var _0023_003DzwZ1I1_0_003D2, out var _0023_003DztSV8BY8_003D2);
				double num2 = Utility._0023_003DzxhnLabVjXjPg * Math.Max(ellipse.RadiusX, ellipse.RadiusY);
				if (!Utility.AreEqual(_0023_003DzwZ1I1_0_003D2, _0023_003DztSV8BY8_003D2, Math.PI * 2.0) && !Utility.AreEqual(_0023_003DzwZ1I1_0_003D2 + Math.PI * 2.0, _0023_003DztSV8BY8_003D2, Math.PI * 2.0))
				{
					curve = new EllipticalArc(ellipse.Plane, ellipse.Center, ellipse.RadiusX, ellipse.RadiusY, _0023_003DzwZ1I1_0_003D2, _0023_003DztSV8BY8_003D2)
					{
						TranslationID = new TranslationIdentifier(_0023_003DzcX2HU0yGwowv._0023_003DzOq3xSxQ_003D(), _0023_003DzcX2HU0yGwowv._0023_003DzS_00246o7tc_003D)
					};
				}
				else if (ellipse.StartPoint.DistanceTo(_0023_003Dz7jzaWWU_003D) > num2 && ellipse.StartPoint.DistanceTo(_0023_003DzJ4EY_H0_003D) > num2)
				{
					curve = new EllipticalArc(ellipse.Plane, ellipse.RadiusX, ellipse.RadiusY, _0023_003DzwZ1I1_0_003D2, _0023_003DzwZ1I1_0_003D2 + Math.PI * 2.0)
					{
						TranslationID = new TranslationIdentifier(_0023_003DzcX2HU0yGwowv._0023_003DzOq3xSxQ_003D(), _0023_003DzcX2HU0yGwowv._0023_003DzS_00246o7tc_003D)
					};
				}
			}
			break;
		}
		return curve;
	}

	private static ICurve _0023_003Dz_V8EbXcmZ8au(Line _0023_003DzOGUeWbk_003D, Point3D _0023_003DzAqOpw0w_003D, Point3D _0023_003Dzk64JNOo_003D)
	{
		_0023_003DzOGUeWbk_003D.Project(_0023_003DzAqOpw0w_003D, out var t);
		_0023_003DzOGUeWbk_003D.Project(_0023_003Dzk64JNOo_003D, out var t2);
		return new Line(_0023_003DzOGUeWbk_003D.PointAt(t), _0023_003DzOGUeWbk_003D.PointAt(t2))
		{
			TranslationID = _0023_003DzOGUeWbk_003D.TranslationID
		};
	}

	private static void _0023_003DzZQK6w4U_003D(ICurve _0023_003Dz8fpRyMu9aKjE, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		_0023_003DzqmF8XJ0_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011612) + ((Entity)_0023_003Dz8fpRyMu9aKjE).TranslationID.Index);
	}

	private static ICurve _0023_003Dzz_OiIk1X7_QTvJOgD941gAA_003D(_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D _0023_003DzcX2HU0yGwowv, Point3D _0023_003Dz7jzaWWU_003D, Point3D _0023_003DzJ4EY_H0_003D, ICurve _0023_003Dz9Bu_NNI_003D)
	{
		double num = Point3D.DistanceSquared(_0023_003Dz7jzaWWU_003D, _0023_003DzJ4EY_H0_003D) * Utility._0023_003DzxhnLabVjXjPg;
		TranslationIdentifier translationID = ((Entity)_0023_003Dz9Bu_NNI_003D).TranslationID;
		if (_0023_003Dz9Bu_NNI_003D.SubCurve(_0023_003Dz7jzaWWU_003D, _0023_003DzJ4EY_H0_003D, out var sub) && Point3D.DistanceSquared(sub.StartPoint, _0023_003Dz7jzaWWU_003D) < num && Point3D.DistanceSquared(sub.EndPoint, _0023_003DzJ4EY_H0_003D) < num)
		{
			((Entity)sub).TranslationID = translationID;
			_0023_003Dz9Bu_NNI_003D = sub;
		}
		else
		{
			_0023_003Dz9Bu_NNI_003D = _0023_003Dz4W__M5Y4HLVgM9Vt27cJaNs_003D(_0023_003DzcX2HU0yGwowv, _0023_003Dz7jzaWWU_003D, _0023_003DzJ4EY_H0_003D);
			if (_0023_003Dz9Bu_NNI_003D.SubCurve(_0023_003Dz7jzaWWU_003D, _0023_003DzJ4EY_H0_003D, out sub))
			{
				((Entity)sub).TranslationID = translationID;
				_0023_003Dz9Bu_NNI_003D = sub;
			}
			else
			{
				_0023_003Dz9Bu_NNI_003D = new Line(_0023_003Dz7jzaWWU_003D, _0023_003DzJ4EY_H0_003D);
				((Entity)_0023_003Dz9Bu_NNI_003D).TranslationID = translationID;
			}
		}
		return _0023_003Dz9Bu_NNI_003D;
	}

	private static ICurve _0023_003Dz4W__M5Y4HLVgM9Vt27cJaNs_003D(_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D _0023_003DzibFOHyFZkeb_, Point3D _0023_003Dz7jzaWWU_003D, Point3D _0023_003DzJ4EY_H0_003D)
	{
		double[] array = ((_0023_003DzYJKD_00247jb1sJL80sUSNwZIPbHHwK2)_0023_003DzibFOHyFZkeb_._0023_003DzyXmKbtw_003D)._0023_003DzjN7uSQk_003D._0023_003DzCGTSeY0_003D._0023_003Dzfj_WbJ59_mOa();
		Vector3D vector3D = new Vector3D(((_0023_003DzYJKD_00247jb1sJL80sUSNwZIPbHHwK2)_0023_003DzibFOHyFZkeb_._0023_003DzyXmKbtw_003D)._0023_003DzjN7uSQk_003D._0023_003DzHwk42AaBD9wG._0023_003DzqdOG1COev7La);
		vector3D.Negate();
		Vector3D vector3D2 = Vector3D.Cross(new Vector3D(((_0023_003DzYJKD_00247jb1sJL80sUSNwZIPbHHwK2)_0023_003DzibFOHyFZkeb_._0023_003DzyXmKbtw_003D)._0023_003DzjN7uSQk_003D._0023_003Dz1_0024d_00248flwjiOW._0023_003DzqdOG1COev7La), vector3D);
		double _0023_003Dzpv54wEv31TWA = ((_0023_003DzYJKD_00247jb1sJL80sUSNwZIPbHHwK2)_0023_003DzibFOHyFZkeb_._0023_003DzyXmKbtw_003D)._0023_003Dzpv54wEv31TWA;
		double _0023_003DzPR92Baujr9D_qSF3xyljq7k_003D = ((_0023_003DzYJKD_00247jb1sJL80sUSNwZIPbHHwK2)_0023_003DzibFOHyFZkeb_._0023_003DzyXmKbtw_003D)._0023_003DzPR92Baujr9D_qSF3xyljq7k_003D;
		Point3D point3D = new Point3D(array[0], array[1], array[2]);
		Segment3D segment3D = new Segment3D(point3D, point3D + vector3D2);
		double num = segment3D.Project(_0023_003Dz7jzaWWU_003D);
		double num2 = segment3D.Project(_0023_003DzJ4EY_H0_003D);
		double num3 = Math.PI * -2.0;
		double num4 = Math.PI * 2.0;
		int num5 = 8;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		for (int i = 0; i < num5; i++)
		{
			Point3D pt = point3D - _0023_003Dzpv54wEv31TWA * Math.Cosh(num3) * vector3D - _0023_003DzPR92Baujr9D_qSF3xyljq7k_003D * Math.Sinh(num3) * vector3D2;
			double num6 = segment3D.Project(pt);
			if (num6 < num)
			{
				if (flag)
				{
					num3 -= Math.PI / 4.0;
					break;
				}
				flag2 = true;
				num3 -= Math.PI / 4.0;
			}
			else if (num6 > num)
			{
				if (flag2)
				{
					break;
				}
				flag = true;
				num3 += Math.PI / 4.0;
			}
		}
		for (int j = 0; j < num5; j++)
		{
			Point3D pt2 = point3D - _0023_003Dzpv54wEv31TWA * Math.Cosh(num4) * vector3D - _0023_003DzPR92Baujr9D_qSF3xyljq7k_003D * Math.Sinh(num4) * vector3D2;
			double num7 = segment3D.Project(pt2);
			if (num7 < num2)
			{
				if (flag3)
				{
					break;
				}
				flag4 = true;
				num4 -= Math.PI / 4.0;
			}
			else if (num7 > num2)
			{
				if (flag4)
				{
					num4 += Math.PI / 4.0;
					break;
				}
				flag3 = true;
				num4 += Math.PI / 4.0;
			}
		}
		double[] array2 = new double[3]
		{
			num3,
			(num3 + num4) / 2.0,
			num4
		};
		Point3D[] array3 = new Point3D[3];
		Vector3D[] array4 = new Vector3D[3];
		for (int k = 0; k < 3; k++)
		{
			double value = array2[k];
			array3[k] = point3D - _0023_003Dzpv54wEv31TWA * Math.Cosh(value) * vector3D - _0023_003DzPR92Baujr9D_qSF3xyljq7k_003D * Math.Sinh(value) * vector3D2;
			array4[k] = (0.0 - _0023_003Dzpv54wEv31TWA) * Math.Sinh(value) * vector3D - _0023_003DzPR92Baujr9D_qSF3xyljq7k_003D * Math.Cosh(value) * vector3D2;
		}
		return new Curve(array3[0], array4[0], array3[2], array4[2], array3[1]);
	}

	private static void _0023_003DzaTRuktlgQdbc(_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D _0023_003DzcX2HU0yGwowv, out Point3D _0023_003Dz7jzaWWU_003D, out Point3D _0023_003DzJ4EY_H0_003D)
	{
		_0023_003Dz7jzaWWU_003D = new Point3D(_0023_003DzcX2HU0yGwowv._0023_003Dz5nHCn49fRiQA()._0023_003Dzfj_WbJ59_mOa());
		_0023_003DzJ4EY_H0_003D = new Point3D(_0023_003DzcX2HU0yGwowv._0023_003DzQE5vZcsRDh6h()._0023_003Dzfj_WbJ59_mOa());
	}

	private static ICurve _0023_003DzZpSyWoKjbrWE(_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D _0023_003DzcX2HU0yGwowv, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D, bool _0023_003DzvFB_0024dbs_003D)
	{
		double[] _0023_003DzbUvT9Pc_003D = new double[3];
		double _0023_003DzEGKj_0024SNUUihi = 0.0;
		double _0023_003DzEuBWN00Nyfof = 0.0;
		double[] _0023_003Dztv6hMfw_003D = new double[3];
		double[] _0023_003Dztg84lvw_003D = new double[3];
		double[] _0023_003DzQqOWrmM_003D = new double[3];
		int _0023_003DzU7eDCS_XZhhv = 0;
		List<double> _0023_003DzyDECbrxjJOuB = new List<double>();
		List<_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D> _0023_003DzTkPhA8X_2C3n = new List<_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D>();
		ICurve curve = null;
		switch (_0023_003DzcX2HU0yGwowv._0023_003Dz_0024ttTvKKQ4wyB())
		{
		case (_0023_003DzERg3UXoyLz7qZsYsfajZhaw_003D)2:
		{
			_0023_003DzcX2HU0yGwowv._0023_003Dz7_0024Q82cYvLdmkcoghLQ_003D_003D(ref _0023_003DzbUvT9Pc_003D, ref _0023_003DzEGKj_0024SNUUihi, ref _0023_003Dztv6hMfw_003D, ref _0023_003Dztg84lvw_003D, ref _0023_003DzQqOWrmM_003D);
			Point3D point3D3 = new Point3D(_0023_003DzbUvT9Pc_003D);
			Plane ellipsePlane = _0023_003DzNY5YUv279_SW(point3D3, _0023_003Dztv6hMfw_003D, _0023_003Dztg84lvw_003D, _0023_003DzQqOWrmM_003D);
			curve = ((!(_0023_003DzEGKj_0024SNUUihi < 1E-12)) ? new Circle(ellipsePlane, point3D3, _0023_003DzEGKj_0024SNUUihi) : null);
			break;
		}
		case (_0023_003DzERg3UXoyLz7qZsYsfajZhaw_003D)3:
		{
			_0023_003DzcX2HU0yGwowv._0023_003DzY8I5D_00244BkSPE(ref _0023_003DzbUvT9Pc_003D, ref _0023_003DzEGKj_0024SNUUihi, ref _0023_003DzEuBWN00Nyfof, ref _0023_003Dztv6hMfw_003D, ref _0023_003Dztg84lvw_003D, ref _0023_003DzQqOWrmM_003D);
			Point3D point3D3 = new Point3D(_0023_003DzbUvT9Pc_003D);
			Plane ellipsePlane = _0023_003DzNY5YUv279_SW(point3D3, _0023_003Dztv6hMfw_003D, _0023_003Dztg84lvw_003D, _0023_003DzQqOWrmM_003D);
			Ellipse ellipse = new Ellipse(ellipsePlane, point3D3, _0023_003DzEGKj_0024SNUUihi, _0023_003DzEuBWN00Nyfof);
			curve = ellipse;
			if (_0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D && ellipse.IsCircle)
			{
				curve = new Circle(ellipse.Plane, Point2D.Origin, ellipse.RadiusX);
			}
			break;
		}
		case (_0023_003DzERg3UXoyLz7qZsYsfajZhaw_003D)1:
		{
			double[] _0023_003Dz3k5Uze_VdwnF = new double[3];
			Line line;
			if (_0023_003DzcX2HU0yGwowv._0023_003Dz5nHCn49fRiQA() != null && _0023_003DzcX2HU0yGwowv._0023_003DzQE5vZcsRDh6h() != null)
			{
				double[] _0023_003DzMnu3zKCWb6Kc = new double[3];
				_0023_003DzcX2HU0yGwowv._0023_003Dzm2rBmZk_003D(ref _0023_003Dz3k5Uze_VdwnF, ref _0023_003DzMnu3zKCWb6Kc);
				line = ((!_0023_003DzvFB_0024dbs_003D || !_0023_003DzcX2HU0yGwowv._0023_003DzGwuYzgEfSgJW) ? new Line(new Point3D(_0023_003DzMnu3zKCWb6Kc), new Point3D(_0023_003Dz3k5Uze_VdwnF)) : new Line(new Point3D(_0023_003Dz3k5Uze_VdwnF), new Point3D(_0023_003DzMnu3zKCWb6Kc)));
			}
			else
			{
				double _0023_003Dz_QIWZfz_FlrL_00243I_0024Yg_003D_003D = 0.0;
				double[] _0023_003Dz6u3psoE_003D = new double[3];
				_0023_003DzcX2HU0yGwowv._0023_003Dzm2rBmZk_003D(ref _0023_003Dz3k5Uze_VdwnF, ref _0023_003Dz_QIWZfz_FlrL_00243I_0024Yg_003D_003D, ref _0023_003Dz6u3psoE_003D);
				Point3D point3D2 = new Point3D(_0023_003Dz3k5Uze_VdwnF);
				line = new Line(point3D2, point3D2 + new Vector3D(_0023_003Dz6u3psoE_003D) * _0023_003Dz_QIWZfz_FlrL_00243I_0024Yg_003D_003D);
			}
			curve = line;
			break;
		}
		case (_0023_003DzERg3UXoyLz7qZsYsfajZhaw_003D)14:
		{
			List<_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu> _0023_003DzYUXDX15Gm_vS = new List<_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu>();
			_0023_003DzcX2HU0yGwowv._0023_003DzCydH8HQ4mbli(ref _0023_003DzYUXDX15Gm_vS);
			Point3D[] array5 = new Point3D[_0023_003DzYUXDX15Gm_vS.Count];
			for (int k = 0; k < _0023_003DzYUXDX15Gm_vS.Count; k++)
			{
				array5[k] = new Point3D(_0023_003DzYUXDX15Gm_vS[k]._0023_003Dzfj_WbJ59_mOa());
			}
			curve = new LinearPath(array5);
			break;
		}
		case (_0023_003DzERg3UXoyLz7qZsYsfajZhaw_003D)4:
		{
			_0023_003DzcX2HU0yGwowv._0023_003Dz0L2mYUNPGQ_0024S(ref _0023_003DzU7eDCS_XZhhv, ref _0023_003DzyDECbrxjJOuB, ref _0023_003DzTkPhA8X_2C3n);
			Point4D[] array4 = new Point4D[_0023_003DzTkPhA8X_2C3n.Count];
			for (int n = 0; n < _0023_003DzTkPhA8X_2C3n.Count; n++)
			{
				array4[n] = new Point4D(_0023_003DzTkPhA8X_2C3n[n]._0023_003Dzfj_WbJ59_mOa()[0], _0023_003DzTkPhA8X_2C3n[n]._0023_003Dzfj_WbJ59_mOa()[1], _0023_003DzTkPhA8X_2C3n[n]._0023_003Dzfj_WbJ59_mOa()[2], _0023_003DzTkPhA8X_2C3n[n]._0023_003Dzfj_WbJ59_mOa()[3]);
			}
			if (_0023_003DzyDECbrxjJOuB.Count == 2 * (_0023_003DzU7eDCS_XZhhv + 1) && _0023_003DzyDECbrxjJOuB[_0023_003DzU7eDCS_XZhhv + 1] == _0023_003DzyDECbrxjJOuB[0])
			{
				curve = new Curve(_0023_003DzU7eDCS_XZhhv, NurbsBase.UniformKnotVector(_0023_003DzU7eDCS_XZhhv, _0023_003DzTkPhA8X_2C3n.Count), array4);
			}
			else if (array4.Length > 1)
			{
				curve = new Curve(_0023_003DzU7eDCS_XZhhv, _0023_003DzyDECbrxjJOuB.ToArray(), array4);
			}
			break;
		}
		case (_0023_003DzERg3UXoyLz7qZsYsfajZhaw_003D)5:
		{
			_0023_003DzcX2HU0yGwowv._0023_003Dz0L2mYUNPGQ_0024S(ref _0023_003DzU7eDCS_XZhhv, ref _0023_003DzyDECbrxjJOuB, ref _0023_003DzTkPhA8X_2C3n);
			Point4D[] array4 = new Point4D[_0023_003DzTkPhA8X_2C3n.Count];
			for (int j = 0; j < _0023_003DzTkPhA8X_2C3n.Count; j++)
			{
				double num = _0023_003DzTkPhA8X_2C3n[j]._0023_003Dzfj_WbJ59_mOa()[3];
				array4[j] = new Point4D(_0023_003DzTkPhA8X_2C3n[j]._0023_003Dzfj_WbJ59_mOa()[0] * num, _0023_003DzTkPhA8X_2C3n[j]._0023_003Dzfj_WbJ59_mOa()[1] * num, _0023_003DzTkPhA8X_2C3n[j]._0023_003Dzfj_WbJ59_mOa()[2] * num, num);
			}
			curve = ((_0023_003DzyDECbrxjJOuB.Count <= 0) ? new Curve(_0023_003DzU7eDCS_XZhhv, NurbsBase.UniformKnotVector(_0023_003DzU7eDCS_XZhhv, _0023_003DzTkPhA8X_2C3n.Count), array4) : new Curve(_0023_003DzU7eDCS_XZhhv, _0023_003DzyDECbrxjJOuB.ToArray(), array4));
			break;
		}
		case (_0023_003DzERg3UXoyLz7qZsYsfajZhaw_003D)6:
		{
			_0023_003DzcX2HU0yGwowv._0023_003DzoYGXDANv9X_YGrpV5w_003D_003D(ref _0023_003DzU7eDCS_XZhhv, ref _0023_003DzTkPhA8X_2C3n);
			Point4D[] array4 = new Point4D[_0023_003DzTkPhA8X_2C3n.Count];
			for (int m = 0; m < _0023_003DzTkPhA8X_2C3n.Count; m++)
			{
				array4[m] = new Point4D(_0023_003DzTkPhA8X_2C3n[m]._0023_003Dzfj_WbJ59_mOa()[0], _0023_003DzTkPhA8X_2C3n[m]._0023_003Dzfj_WbJ59_mOa()[1], _0023_003DzTkPhA8X_2C3n[m]._0023_003Dzfj_WbJ59_mOa()[2]);
			}
			curve = new Curve(_0023_003DzU7eDCS_XZhhv, NurbsBase.UniformKnotVector(_0023_003DzU7eDCS_XZhhv, _0023_003DzTkPhA8X_2C3n.Count), array4);
			break;
		}
		case (_0023_003DzERg3UXoyLz7qZsYsfajZhaw_003D)10:
		{
			double _0023_003Dzp3yVmCaoGTYxNAeVBA_003D_003D = 0.0;
			_0023_003DzcX2HU0yGwowv._0023_003Dzb3bxLG2Qi0U8w_0024ZqBg_003D_003D(ref _0023_003DzbUvT9Pc_003D, ref _0023_003Dztv6hMfw_003D, ref _0023_003Dztg84lvw_003D, ref _0023_003Dzp3yVmCaoGTYxNAeVBA_003D_003D);
			Plane destinationFrame = new Plane(new Point3D(_0023_003DzbUvT9Pc_003D[0], _0023_003DzbUvT9Pc_003D[1], _0023_003DzbUvT9Pc_003D[2]), new Vector3D(_0023_003Dztg84lvw_003D[0], _0023_003Dztg84lvw_003D[1], _0023_003Dztg84lvw_003D[2]), new Vector3D(_0023_003Dztv6hMfw_003D[0], _0023_003Dztv6hMfw_003D[1], _0023_003Dztv6hMfw_003D[2]));
			Align3D xform = new Align3D(Plane.YX, destinationFrame);
			Point3D[] array6 = new Point3D[3];
			Vector3D[] array7 = new Vector3D[3];
			double[] array8 = new double[3] { -100.0, 0.0, 100.0 };
			for (int l = 0; l < 3; l++)
			{
				double num2 = array8[l];
				array6[l] = new Point3D(1.0 / (4.0 * _0023_003Dzp3yVmCaoGTYxNAeVBA_003D_003D) * num2 * num2, num2);
				double x = 1.0 / (2.0 * _0023_003Dzp3yVmCaoGTYxNAeVBA_003D_003D) * array6[l].Y;
				array7[l] = new Vector3D(x, 1.0);
			}
			curve = new Curve(array6[0], array7[0], array6[2], array7[2], array6[1]);
			((Entity)curve).TransformBy(xform);
			break;
		}
		case (_0023_003DzERg3UXoyLz7qZsYsfajZhaw_003D)11:
		{
			double _0023_003Dzpv54wEv31TWA = 0.0;
			double _0023_003DzPR92Baujr9D_qSF3xyljq7k_003D = 0.0;
			_0023_003DzcX2HU0yGwowv._0023_003DzDomPWEU2imRJt_swiQ_003D_003D(ref _0023_003DzbUvT9Pc_003D, ref _0023_003Dztv6hMfw_003D, ref _0023_003Dztg84lvw_003D, ref _0023_003Dzpv54wEv31TWA, ref _0023_003DzPR92Baujr9D_qSF3xyljq7k_003D);
			Point3D point3D = new Point3D(_0023_003DzbUvT9Pc_003D[0], _0023_003DzbUvT9Pc_003D[1], _0023_003DzbUvT9Pc_003D[2]);
			Vector3D vector3D = new Vector3D(_0023_003Dztg84lvw_003D[0], _0023_003Dztg84lvw_003D[1], _0023_003Dztg84lvw_003D[2]);
			Vector3D vector3D2 = new Vector3D(_0023_003Dztv6hMfw_003D[0], _0023_003Dztv6hMfw_003D[1], _0023_003Dztv6hMfw_003D[2]);
			Point3D[] array = new Point3D[3];
			Vector3D[] array2 = new Vector3D[3];
			double[] array3 = new double[3]
			{
				-Math.PI,
				0.0,
				Math.PI
			};
			for (int i = 0; i < 3; i++)
			{
				double value = array3[i];
				array[i] = point3D - _0023_003Dzpv54wEv31TWA * Math.Cosh(value) * vector3D2 - _0023_003DzPR92Baujr9D_qSF3xyljq7k_003D * Math.Sinh(value) * vector3D;
				array2[i] = (0.0 - _0023_003Dzpv54wEv31TWA) * Math.Sinh(value) * vector3D2 - _0023_003DzPR92Baujr9D_qSF3xyljq7k_003D * Math.Cosh(value) * vector3D;
			}
			curve = new Curve(array[0], array2[0], array[2], array2[2], array[1]);
			break;
		}
		case (_0023_003DzERg3UXoyLz7qZsYsfajZhaw_003D)0:
			_0023_003DzqmF8XJ0_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011647) + _0023_003DzcX2HU0yGwowv._0023_003DzOq3xSxQ_003D());
			break;
		}
		if (curve != null && _0023_003DzvFB_0024dbs_003D && !_0023_003DzcX2HU0yGwowv._0023_003DzGwuYzgEfSgJW)
		{
			curve.Reverse();
		}
		if (curve != null)
		{
			if (_0023_003DzcX2HU0yGwowv._0023_003DzOq3xSxQ_003D() != -1)
			{
				((Entity)curve).TranslationID = new TranslationIdentifier(_0023_003DzcX2HU0yGwowv._0023_003DzOq3xSxQ_003D(), _0023_003DzcX2HU0yGwowv._0023_003DzS_00246o7tc_003D);
			}
			else
			{
				((Entity)curve).TranslationID = new TranslationIdentifier(_0023_003DzcX2HU0yGwowv._0023_003DzyXmKbtw_003D._0023_003DzkXQ_IWk_003D, _0023_003DzcX2HU0yGwowv._0023_003DzyXmKbtw_003D._0023_003DzS_00246o7tc_003D);
			}
		}
		return curve;
	}

	private static void _0023_003DzQY_zRVuyAz4K(ICurve _0023_003Dzl8M2I3VOhFfS, Point3D _0023_003DzstAn7cw2vRC7, Point3D _0023_003DzA5kmIQrPan7q, out double _0023_003DzwZ1I1_0_003D, out double _0023_003DztSV8BY8_003D)
	{
		_0023_003Dzl8M2I3VOhFfS.ClosestPointTo(_0023_003DzstAn7cw2vRC7, out _0023_003DzwZ1I1_0_003D);
		_0023_003Dzl8M2I3VOhFfS.ClosestPointTo(_0023_003DzA5kmIQrPan7q, out _0023_003DztSV8BY8_003D);
		if (Utility.AreEqual(_0023_003DzwZ1I1_0_003D, Math.PI * 2.0, Math.PI * 2.0))
		{
			_0023_003DzwZ1I1_0_003D = 0.0;
		}
		if (Utility.AreEqual(_0023_003DztSV8BY8_003D, 0.0, Math.PI * 2.0))
		{
			_0023_003DztSV8BY8_003D = Math.PI * 2.0;
		}
		if (_0023_003DzwZ1I1_0_003D > _0023_003DztSV8BY8_003D)
		{
			_0023_003DztSV8BY8_003D += Math.PI * 2.0;
		}
	}

	internal static Plane _0023_003DzNY5YUv279_SW(Point3D _0023_003DzEebleSvLGrRJ, double[] _0023_003Dztv6hMfw_003D, double[] _0023_003Dztg84lvw_003D, double[] _0023_003DzQqOWrmM_003D)
	{
		Vector3D vector3D = new Vector3D(_0023_003Dztv6hMfw_003D);
		if (vector3D.IsZero)
		{
			Vector3D n = new Vector3D(_0023_003DzQqOWrmM_003D);
			return new Plane(_0023_003DzEebleSvLGrRJ, n);
		}
		return new Plane(_0023_003DzEebleSvLGrRJ, vector3D, new Vector3D(_0023_003Dztg84lvw_003D));
	}

	private void _0023_003DzgYYyKHHdTz0g(_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D _0023_003Dzcoe2_tewkWc6, IList<Entity> _0023_003DzWc9WmS8VMsuA, linearUnitsType _0023_003DzhwXT3JQJv5iT, BlockKeyedCollection _0023_003DzJO1FWlQ_003D)
	{
		string _0023_003DzS_00246o7tc_003D = null;
		double[] _0023_003Dzjy1uh4TCdHHF = new double[3];
		double[] _0023_003DzfG9rkLwrmfTR = new double[3];
		double[] _0023_003DzUDbSwhISwKOuj_0024eHVA_003D_003D = new double[3];
		double[] _0023_003Dzo3kcdDwWtwEn = new double[3];
		double[] _0023_003Dz12CiNIfV7C9X = new double[3];
		double[] _0023_003DzuXVeVS2NkhL7tMGh_0024Q_003D_003D = new double[3];
		_0023_003Dzcoe2_tewkWc6._0023_003DzEt7rVh0_003D(ref _0023_003DzS_00246o7tc_003D, ref _0023_003Dzo3kcdDwWtwEn, ref _0023_003Dz12CiNIfV7C9X, ref _0023_003DzuXVeVS2NkhL7tMGh_0024Q_003D_003D, ref _0023_003Dzjy1uh4TCdHHF, ref _0023_003DzfG9rkLwrmfTR, ref _0023_003DzUDbSwhISwKOuj_0024eHVA_003D_003D);
		Transformation transformation = new Identity();
		if (_0023_003Dzjy1uh4TCdHHF != null)
		{
			Point3D p = new Point3D(_0023_003Dzjy1uh4TCdHHF);
			Vector3D vector3D = new Vector3D(_0023_003DzfG9rkLwrmfTR);
			Vector3D vector3D2 = new Vector3D(_0023_003DzUDbSwhISwKOuj_0024eHVA_003D_003D);
			Point3D p2 = new Point3D(_0023_003Dzo3kcdDwWtwEn);
			Vector3D vector3D3 = new Vector3D(_0023_003Dz12CiNIfV7C9X);
			vector3D3.Normalize();
			Vector3D vector3D4 = new Vector3D(_0023_003DzuXVeVS2NkhL7tMGh_0024Q_003D_003D);
			vector3D4.Normalize();
			transformation = new Transformation();
			transformation.Rotation(p, vector3D2, Vector3D.Cross(vector3D, vector3D2), vector3D, p2, vector3D4, Vector3D.Cross(vector3D3, vector3D4), vector3D3);
		}
		string _0023_003Dz8oO_z_0024d8gNK = _0023_003Dzcoe2_tewkWc6._0023_003Dz8oO_z_0024d8gNK7;
		BlockReference blockReference = new BlockReference(transformation, _0023_003Dz8oO_z_0024d8gNK, _0023_003DzhwXT3JQJv5iT, _0023_003DzJO1FWlQ_003D);
		blockReference.TranslationID = new TranslationIdentifier((_0023_003Dzcoe2_tewkWc6._0023_003Dz4pmQ5h06_Snm() != string.Empty) ? _0023_003Dzcoe2_tewkWc6._0023_003Dz4pmQ5h06_Snm() : null);
		_0023_003DzWc9WmS8VMsuA.Add(blockReference);
	}
}
