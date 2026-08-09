using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class ReadIGES : ReadFileAsync
{
	private static class _0023_003DzQm9ltrs_003D
	{
		public static Func<char, bool> _0023_003DzCtHbp2uM88NXbcZZIg_003D_003D;
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzkeIyMnc67iU4m6G8J8MrWFnxFtQQ63NuY3ugKtQ_003D _0023_003DzFuePbj8_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IProgress<ProgressChangedEventArgs> _0023_003DzsWnj47U_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CancellationToken _0023_003DzEBehidw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzamnnTh8_0024jUtZ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzEwvvISSWsBmP;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzzwQaTmWKCeWkkbmQYg_003D_003D = true;

	public override supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.Inches | supportedLinearUnitsType.Feet | supportedLinearUnitsType.Miles | supportedLinearUnitsType.Millimeters | supportedLinearUnitsType.Centimeters | supportedLinearUnitsType.Meters | supportedLinearUnitsType.Kilometers | supportedLinearUnitsType.Microinches | supportedLinearUnitsType.Mils | supportedLinearUnitsType.Microns;

	public double ModelSpaceScale => _0023_003DzEwvvISSWsBmP;

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

	public ReadIGES(string filePath, bool applyScaling = false)
		: base(filePath)
	{
		_0023_003DzamnnTh8_0024jUtZ = applyScaling;
	}

	public ReadIGES(Stream stream, bool applyScaling = false)
		: base(stream)
	{
		_0023_003DzamnnTh8_0024jUtZ = applyScaling;
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
		_0023_003Dz3oKHAXp4p7vg(progress, ct);
	}

	private void _0023_003Dz3oKHAXp4p7vg(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		bool flag = false;
		try
		{
			base.Units = linearUnitsType.Unitless;
			_0023_003DzFuePbj8_003D = new _0023_003DzkeIyMnc67iU4m6G8J8MrWFnxFtQQ63NuY3ugKtQ_003D();
			_0023_003DzFuePbj8_003D._0023_003DzgHO845XqWw4G(delegate(object _0023_003Dz9VjL5i0_003D, ProgressChangedEventArgs _0023_003DzbfrNXYE_003D)
			{
				if (!UpdateProgressAndCheckCancelled(_0023_003DzbfrNXYE_003D.Progress, 100.0, base.ReadingText, _0023_003DzsWnj47U_003D, _0023_003DzEBehidw_003D))
				{
					_0023_003DzFuePbj8_003D._0023_003DzBcvxv10_003D = true;
				}
			});
			flag = _0023_003DzFuePbj8_003D._0023_003Dz3oKHAXp4p7vg(base.Stream, log);
			if (flag)
			{
				_0023_003DzEwvvISSWsBmP = _0023_003DzFuePbj8_003D._0023_003DzoDRCNszxm3z_;
				base.Units = _0023_003DzFuePbj8_003D._0023_003DzkrKTEVA_003D;
				base.Author = _0023_003DzFuePbj8_003D._0023_003DzG44DSbY_003D;
				base.Organization = _0023_003DzFuePbj8_003D._0023_003DzhthqjT8_003D;
				base.OriginatingSystem = _0023_003DzFuePbj8_003D._0023_003DzefVLP4k43QcJ;
				base.FileName = _0023_003DzFuePbj8_003D._0023_003Dzp_0024d6xO0_003D;
				base.Timestamp = _0023_003DzFuePbj8_003D._0023_003DztqFjNres8Nni;
				base.PreProcessor = _0023_003DzFuePbj8_003D._0023_003Dz74dsc2o_003D;
				List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003Dz618HlSI_003D = _0023_003DzFuePbj8_003D._0023_003Dz618HlSI_003D;
				List<Entity> list = new List<Entity>();
				SortedDictionary<int, Layer> sortedDictionary = new SortedDictionary<int, Layer>();
				bool flag2 = false;
				int num = 1;
				for (int num2 = 0; num2 < _0023_003Dz618HlSI_003D.Count; num2++)
				{
					_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2 = _0023_003Dz618HlSI_003D[num2];
					if (_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2 is _0023_003DzWPy7Mq_LyWeTazTXtajtCZ8FDawgWm5p_A_003D_003D _0023_003DzqoHxF0k_003D && _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2._0023_003DzgeIy8kQSNZ64() == 3)
					{
						int _0023_003DzyzK8swU_003D;
						Layer layer = _0023_003Dzgmai7CQ_003D(_0023_003DzqoHxF0k_003D, _0023_003Dz618HlSI_003D, out _0023_003DzyzK8swU_003D);
						if (sortedDictionary.Count == 1 && _0023_003DzyzK8swU_003D == 0)
						{
							flag2 = true;
						}
						if (layer != null && !sortedDictionary.ContainsValue(layer))
						{
							sortedDictionary.Add(flag2 ? num++ : _0023_003DzyzK8swU_003D, layer);
						}
					}
				}
				base.Layers.AddRange(sortedDictionary.Values);
				if (base.Layers.Count == 0)
				{
					for (int num3 = 0; num3 < _0023_003Dz618HlSI_003D.Count; num3++)
					{
						_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D3 = _0023_003Dz618HlSI_003D[num3];
						if (!_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D3._0023_003Dz0zC9kwiO_0024qo7() || _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D3 is _0023_003DzoMowD04mt4vKC4cSDkFRUr_dj0yUGXqXlA_003D_003D || _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D3 is _0023_003DzWPy7Mq_LyWeTazTXtajtCZ8FDawgWm5p_A_003D_003D || _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D3 is _0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D || _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D3 is _0023_003Dz18IEgzJEVJEAtpayNrr9Mj_0024u2aTOeu3UMujTh86IKJMf)
						{
							continue;
						}
						Color color;
						if (_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D3._0023_003Dz7Hj3HvFG5jpL() < 0)
						{
							color = Color.Black;
							if (_0023_003Dz618HlSI_003D[-_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D3._0023_003Dz7Hj3HvFG5jpL() / 2] is _0023_003DzoMowD04mt4vKC4cSDkFRUr_dj0yUGXqXlA_003D_003D)
							{
								color = ((_0023_003DzoMowD04mt4vKC4cSDkFRUr_dj0yUGXqXlA_003D_003D)_0023_003Dz618HlSI_003D[-_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D3._0023_003Dz7Hj3HvFG5jpL() / 2])._0023_003Dz_8C3BH8_003D();
							}
						}
						else
						{
							color = _0023_003Dz_0024tVWMRkiQvqh(_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D3._0023_003Dz7Hj3HvFG5jpL());
						}
						if (!_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D3._0023_003Dz2FP2wGYnvfXe() && _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D3._0023_003DzY22p5l0ZvUrF() != -1 && !base.Layers.Contains(new Layer(_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D3._0023_003DzY22p5l0ZvUrF().ToString())))
						{
							Layer item = new Layer(_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D3._0023_003DzY22p5l0ZvUrF().ToString(), color, visible: true);
							base.Layers.Add(item);
						}
					}
				}
				int num4 = 0;
				foreach (_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D item4 in _0023_003Dz618HlSI_003D)
				{
					if (item4 is _0023_003Dz18IEgzJEVJEAtpayNrr9Mj_0024u2aTOeu3UMujTh86IKJMf)
					{
						num4++;
					}
				}
				for (int num5 = _0023_003Dz618HlSI_003D.Count - 1; num5 > -1; num5--)
				{
					_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D4 = _0023_003Dz618HlSI_003D[num5];
					if (_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D4 is _0023_003Dz18IEgzJEVJEAtpayNrr9Mj_0024u2aTOeu3UMujTh86IKJMf)
					{
						_0023_003Dz18IEgzJEVJEAtpayNrr9Mj_0024u2aTOeu3UMujTh86IKJMf _0023_003Dz18IEgzJEVJEAtpayNrr9Mj_0024u2aTOeu3UMujTh86IKJMf2 = (_0023_003Dz18IEgzJEVJEAtpayNrr9Mj_0024u2aTOeu3UMujTh86IKJMf)_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D4;
						Block block = new Block(_0023_003Dz18IEgzJEVJEAtpayNrr9Mj_0024u2aTOeu3UMujTh86IKJMf2._0023_003Dz5sR_By0gsufq().ToString(CultureInfo.InvariantCulture));
						block._0023_003DzCcbOFGI_003D = _0023_003Dz18IEgzJEVJEAtpayNrr9Mj_0024u2aTOeu3UMujTh86IKJMf2._0023_003DzwKyKajk_003D();
						for (int num6 = 0; num6 < _0023_003Dz18IEgzJEVJEAtpayNrr9Mj_0024u2aTOeu3UMujTh86IKJMf2._0023_003DzkXjAbBM_0024zgT_0024().Count; num6++)
						{
							_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D5 = _0023_003Dz618HlSI_003D[_0023_003Dz18IEgzJEVJEAtpayNrr9Mj_0024u2aTOeu3UMujTh86IKJMf2._0023_003DzkXjAbBM_0024zgT_0024()[num6] / 2];
							if (!_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D5._0023_003Dz2FP2wGYnvfXe())
							{
								Entity entity = _0023_003Dz3u_0Ozo_003D(_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D5, _0023_003Dz618HlSI_003D, base.Blocks, _0023_003DzzwQaTmWKCeWkkbmQYg_003D_003D);
								if (entity != null)
								{
									_0023_003DzHW0izpM_003D(_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D5, entity, _0023_003Dz618HlSI_003D);
									entity.TranslationID = new TranslationIdentifier(_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D5._0023_003Dz5sR_By0gsufq(), _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D5._0023_003DzI9gVPKCnM319());
									entity.Visible = true;
									block.Units = base.Units;
									block.Entities.Add(entity);
								}
							}
						}
						base.Blocks.Add(block);
						if (!UpdateProgressAndCheckCancelled(base.Blocks.Count, num4, base.ParsingBlocksText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
						{
							flag = false;
							break;
						}
					}
				}
				UpdateProgressTo100(base.ParsingBlocksText, _0023_003DzmHS7frs_003D);
				if (flag)
				{
					List<Tuple<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D, Entity>> list2 = new List<Tuple<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D, Entity>>(_0023_003Dz618HlSI_003D.Count);
					int count = _0023_003Dz618HlSI_003D.Count;
					for (int num7 = 0; num7 < count; num7++)
					{
						_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D6 = _0023_003Dz618HlSI_003D[num7];
						if (!(_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D6 is _0023_003DzoMowD04mt4vKC4cSDkFRUr_dj0yUGXqXlA_003D_003D) && !(_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D6 is _0023_003DzWPy7Mq_LyWeTazTXtajtCZ8FDawgWm5p_A_003D_003D) && !(_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D6 is _0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D) && !(_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D6 is _0023_003Dz18IEgzJEVJEAtpayNrr9Mj_0024u2aTOeu3UMujTh86IKJMf))
						{
							Entity entity2 = _0023_003Dz3u_0Ozo_003D(_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D6, _0023_003Dz618HlSI_003D, base.Blocks, _0023_003DzzwQaTmWKCeWkkbmQYg_003D_003D);
							if (entity2 == null)
							{
								continue;
							}
							_0023_003DzHW0izpM_003D(_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D6, entity2, _0023_003Dz618HlSI_003D);
							list2.Add(new Tuple<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D, Entity>(_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D6, entity2));
						}
						if (!UpdateProgressAndCheckCancelled(num7, count, base.ParsingEntitiesText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
						{
							flag = false;
							break;
						}
					}
					UpdateProgressTo100(base.ParsingEntitiesText, _0023_003DzmHS7frs_003D);
					foreach (Tuple<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D, Entity> item5 in list2)
					{
						_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D item2 = item5.Item1;
						if (!item2._0023_003DzLTIWwMMYq_NXYi3uAw_003D_003D() && !item2._0023_003Dz2FP2wGYnvfXe())
						{
							Entity item3 = item5.Item2;
							item3.TranslationID = new TranslationIdentifier(item2._0023_003Dz5sR_By0gsufq(), item2._0023_003DzI9gVPKCnM319());
							item3.Visible = true;
							list.Add(item3);
						}
					}
				}
				if (flag)
				{
					_0023_003DzsHquVhKYrLm2(list);
					if (_0023_003DzamnnTh8_0024jUtZ && _0023_003DzEwvvISSWsBmP != 1.0)
					{
						foreach (Entity item6 in list)
						{
							double num8 = 1.0 / _0023_003DzEwvvISSWsBmP;
							item6.Scale(num8, num8, num8);
						}
					}
					base.Entities.AddRange(list);
					foreach (Layer layer2 in base.Layers)
					{
						layer2.Name = _0023_003DzVqtDnIIHRHeqfPtPSQ_003D_003D(layer2.Name);
					}
				}
			}
		}
		catch (Exception ex)
		{
			flag = false;
			log.AppendLine(ex.Message);
		}
		finally
		{
			CloseStream();
		}
		base.Result = flag;
	}

	private void _0023_003Dz1Dz7wB5x_0024rjg(object _0023_003Dz9VjL5i0_003D, ProgressChangedEventArgs _0023_003DzbfrNXYE_003D)
	{
		if (!UpdateProgressAndCheckCancelled(_0023_003DzbfrNXYE_003D.Progress, 100.0, base.ReadingText, _0023_003DzsWnj47U_003D, _0023_003DzEBehidw_003D))
		{
			_0023_003DzFuePbj8_003D._0023_003DzBcvxv10_003D = true;
		}
	}

	private string _0023_003DzVqtDnIIHRHeqfPtPSQ_003D_003D(string _0023_003DzaROjBYA_003D)
	{
		string result = _0023_003DzaROjBYA_003D;
		if (int.TryParse(_0023_003DzaROjBYA_003D, out var result2))
		{
			result = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008308) + result2;
		}
		return result;
	}

	private void _0023_003DzsHquVhKYrLm2(IList<Entity> _0023_003DzOHpyMcKw0SXo)
	{
		if (_0023_003Dz57GlVMqRhGpe())
		{
			return;
		}
		foreach (Block block in base.Blocks)
		{
			if (string.IsNullOrEmpty(block._0023_003DzCcbOFGI_003D))
			{
				continue;
			}
			foreach (Entity item in _0023_003DzOHpyMcKw0SXo)
			{
				if (item is BlockReference)
				{
					BlockReference blockReference = (BlockReference)item;
					if (blockReference.BlockName == block.Name)
					{
						blockReference.BlockName = block._0023_003DzCcbOFGI_003D;
					}
				}
			}
			foreach (Block block2 in base.Blocks)
			{
				if (!(block2.Name != block.Name))
				{
					continue;
				}
				foreach (Entity entity in block2.Entities)
				{
					if (entity is BlockReference)
					{
						BlockReference blockReference2 = (BlockReference)entity;
						if (blockReference2.BlockName == block.Name)
						{
							blockReference2.BlockName = block._0023_003DzCcbOFGI_003D;
						}
					}
				}
			}
			block.Name = block._0023_003DzCcbOFGI_003D;
		}
	}

	private bool _0023_003Dz57GlVMqRhGpe()
	{
		HashSet<string> hashSet = new HashSet<string>();
		foreach (Block block in base.Blocks)
		{
			if (hashSet.Contains(block._0023_003DzCcbOFGI_003D))
			{
				return true;
			}
			hashSet.Add(block._0023_003DzCcbOFGI_003D);
		}
		return false;
	}

	private void _0023_003DzHW0izpM_003D(_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D _0023_003DzXgwfWtYr8tE_0024, Entity _0023_003DzTb8sVfuysOroSa7Xag_003D_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzuAKPwfU_003D)
	{
		Color color = Color.Black;
		_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.Visible = _0023_003DzXgwfWtYr8tE_0024._0023_003Dz0zC9kwiO_0024qo7();
		if (_0023_003DzXgwfWtYr8tE_0024._0023_003Dz7Hj3HvFG5jpL() < 0)
		{
			if (_0023_003DzuAKPwfU_003D[-_0023_003DzXgwfWtYr8tE_0024._0023_003Dz7Hj3HvFG5jpL() / 2] is _0023_003DzoMowD04mt4vKC4cSDkFRUr_dj0yUGXqXlA_003D_003D)
			{
				color = ((_0023_003DzoMowD04mt4vKC4cSDkFRUr_dj0yUGXqXlA_003D_003D)_0023_003DzuAKPwfU_003D[-_0023_003DzXgwfWtYr8tE_0024._0023_003Dz7Hj3HvFG5jpL() / 2])._0023_003Dz_8C3BH8_003D();
			}
		}
		else if (_0023_003DzXgwfWtYr8tE_0024._0023_003Dz7Hj3HvFG5jpL() > 0)
		{
			color = _0023_003Dz_0024tVWMRkiQvqh(_0023_003DzXgwfWtYr8tE_0024._0023_003Dz7Hj3HvFG5jpL());
		}
		_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.Color = color;
		string text = _0023_003DzXgwfWtYr8tE_0024._0023_003DzY22p5l0ZvUrF().ToString();
		int num = base.Layers.IndexOf(new Layer(text));
		if (num != -1)
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LayerName = _0023_003DzVqtDnIIHRHeqfPtPSQ_003D_003D(text);
		}
		else if (_0023_003DzXgwfWtYr8tE_0024._0023_003DzY22p5l0ZvUrF() > 0 && base.Layers.Count > _0023_003DzXgwfWtYr8tE_0024._0023_003DzY22p5l0ZvUrF() - 1)
		{
			text = base.Layers[_0023_003DzXgwfWtYr8tE_0024._0023_003DzY22p5l0ZvUrF() - 1].Name;
			num = base.Layers.IndexOf(new Layer(text));
			if (num != -1)
			{
				_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LayerName = _0023_003DzVqtDnIIHRHeqfPtPSQ_003D_003D(text);
			}
		}
		else
		{
			if (base.Layers.Count > 0 && !base.Layers._0023_003DzswaTj8gEDyWc())
			{
				_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LayerName = _0023_003DzVqtDnIIHRHeqfPtPSQ_003D_003D(base.Layers[0].Name);
			}
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.ColorMethod = colorMethodType.byEntity;
		}
		Color color2 = Color.Black;
		if (base.Layers.Count > 0)
		{
			if (num != -1)
			{
				color2 = base.Layers[num].Color;
			}
			else if (base.Layers._0023_003DzswaTj8gEDyWc())
			{
				color2 = base.Layers[_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.LayerName].Color;
			}
		}
		if (_0023_003DzXgwfWtYr8tE_0024._0023_003Dz7Hj3HvFG5jpL() == 0 || (color2.R == color.R && color2.G == color.G && color2.B == color.B))
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.ColorMethod = colorMethodType.byLayer;
		}
		else
		{
			_0023_003DzTb8sVfuysOroSa7Xag_003D_003D.ColorMethod = colorMethodType.byEntity;
		}
	}

	private static Color _0023_003Dz_0024tVWMRkiQvqh(int _0023_003DzOPC4q6w_003D)
	{
		return _0023_003DzOPC4q6w_003D switch
		{
			1 => Color.Black, 
			2 => Color.Red, 
			3 => Color.Green, 
			4 => Color.Blue, 
			5 => Color.Yellow, 
			6 => Color.Magenta, 
			7 => Color.Cyan, 
			8 => Color.White, 
			_ => Color.Black, 
		};
	}

	private Entity _0023_003Dz3u_0Ozo_003D(_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D _0023_003DzXgwfWtYr8tE_0024, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
	{
		Entity result = null;
		if (!(_0023_003DzXgwfWtYr8tE_0024 is _0023_003DzdPtvklPFzKqxMoTpEOXyeC1W53neVz2gTQ_003D_003D _0023_003DzZSYhEk_cVLUx))
		{
			if (!(_0023_003DzXgwfWtYr8tE_0024 is _0023_003DzEKmPHSrtZpXBuvnSgWZRaBK5Mq11POCYUuKluiI_003D _0023_003Dzr7J4i2RY3FDU4in8eA_003D_003D))
			{
				if (!(_0023_003DzXgwfWtYr8tE_0024 is _0023_003Dz_00242iQD1FOOBMB8Ag0xLXT03IXG_IUm_Shn5BXiGI_003D _0023_003DzbowHg5tQnNQ9MzOqyw_003D_003D))
				{
					if (!(_0023_003DzXgwfWtYr8tE_0024 is _0023_003Dzz6JIJ4xNe1_0024dIMT88uFZydqQ_0024upBYSTqB05jKFc_003D _0023_003DzRHnPVNkghFAs))
					{
						if (!(_0023_003DzXgwfWtYr8tE_0024 is _0023_003Dzdqr8UI0Jipc_0024TuuKDhHIJvVq3Tj138M0mHUw_gY_003D _0023_003DzVNc46A90XH1QddMG3A_003D_003D))
						{
							if (!(_0023_003DzXgwfWtYr8tE_0024 is _0023_003DzCDSdDaukKIfQIKuoRosZ3NAKyMQ1WGSxOA_003D_003D _0023_003Dzai52pbTwii_b))
							{
								if (!(_0023_003DzXgwfWtYr8tE_0024 is _0023_003DzfSAHMZkL2hJuTBQQ4L7dNUFzt0xFD2jPM7XhiwU_003D _0023_003Dz6P7ZdNYd79JO))
								{
									if (!(_0023_003DzXgwfWtYr8tE_0024 is _0023_003DzTsGSj5r0zhbKoPjk04Ctgt5hXkbDo26vk_YJJ_kCYeB4dIKQQQ_003D_003D _0023_003Dz4LODXENqUAL2SV7d2A_003D_003D))
									{
										if (!(_0023_003DzXgwfWtYr8tE_0024 is _0023_003DzOKQiiYVsLKx6c65wwxfwYTu0ENOXS1pHlaJUbq8QGC1LOQs_0024LQ_003D_003D _0023_003DzndgQYaKOzL4PELsQLg_003D_003D))
										{
											if (!(_0023_003DzXgwfWtYr8tE_0024 is _0023_003Dz3Zx4KFlYXhE6x5ocfLkICI9BSGRZVvqe1SYkVItmXGYVkWg25w_003D_003D _0023_003DzVrJ2wtLTlBcEUy9Luw_003D_003D))
											{
												if (!(_0023_003DzXgwfWtYr8tE_0024 is _0023_003Dz9lwBHA7NoLh_0024_1EVuspU6hmh4G7BX3ZcrScNn8k_003D _0023_003DzndgQYaKOzL4PELsQLg_003D_003D2))
												{
													if (!(_0023_003DzXgwfWtYr8tE_0024 is _0023_003Dz_ZR_60g8KTZpV15NG_0024gJ1cZ3Q9yL1UXPtzY9x8s_003D _0023_003DzVrJ2wtLTlBcEUy9Luw_003D_003D2))
													{
														if (!(_0023_003DzXgwfWtYr8tE_0024 is _0023_003DzOKWbo7sUM8LpXGAfWbsy7u9_aoyf6rVNGlnjW9k_003D _0023_003Dzja3lgRPKmEukz9k6WQ_003D_003D))
														{
															if (!(_0023_003DzXgwfWtYr8tE_0024 is _0023_003DzF5p_8NJ3PUm7nyvOOwDz4l_0024pwTFYmB_e_0024Q_003D_003D _0023_003DzIamx_OpEEKK))
															{
																if (!(_0023_003DzXgwfWtYr8tE_0024 is _0023_003DzYkQVv2Lb0egyGZnzeO8ydkyFt0lDEhHA4uvG2TxpWX6vfM3gdg_003D_003D _0023_003DzXoiDdkk_003D))
																{
																	if (!(_0023_003DzXgwfWtYr8tE_0024 is _0023_003DzZXHZ8r_AKGbCsLnm7EUe1w_00244EG0i1nNAEdrGUvzdztgO _0023_003DzPrZ0njs5O8eq))
																	{
																		if (!(_0023_003DzXgwfWtYr8tE_0024 is _0023_003DzOqrWHudzVp1v35H_vsK2gKOjnxqMkRli9ie5GLqoLH7QYRVcuQ_003D_003D _0023_003DzJ9ODgxjHN5qS))
																		{
																			if (!(_0023_003DzXgwfWtYr8tE_0024 is _0023_003Dz0wVdkDSyPiY38wDh_0024it2Wow5fuuPl7r8a8kaJfYypij3 _0023_003DzhitlgVA_003D))
																			{
																				if (!(_0023_003DzXgwfWtYr8tE_0024 is _0023_003Dz_Q4HKPwuFf6e2QQ1OJd0reHy3bQkmQVBhQ_003D_003D _0023_003DzbJPraLv4V_0024bL))
																				{
																					if (!(_0023_003DzXgwfWtYr8tE_0024 is _0023_003DzOK_wIuCG_0024L33RaVzjK4JLUKKO_p4pq_0024by5YYyrY_003D _0023_003DzDzSF2oQdE9O8IsEUOA_003D_003D))
																					{
																						if (!(_0023_003DzXgwfWtYr8tE_0024 is _0023_003DzCvMCt05pVvqGJGI368UlSvv09UP9pWWmRo3Qh0YGOXCU _0023_003DzPs16gVsjjx8sBRfHlRQ7Cf8_003D))
																						{
																							if (_0023_003DzXgwfWtYr8tE_0024 is _0023_003Dz26Feb5E6SVtERAQBq_TBV8CmtN1UucNJlA_003D_003D _0023_003DzwqfuKforsy8L)
																							{
																								result = _0023_003Dzfpt8uoA_003D(_0023_003DzwqfuKforsy8L, _0023_003DzPx2oAYw_003D);
																							}
																						}
																						else
																						{
																							result = _0023_003DzsV3zf01sWNBIneDahw_003D_003D(_0023_003DzPs16gVsjjx8sBRfHlRQ7Cf8_003D, _0023_003DzPx2oAYw_003D);
																						}
																					}
																					else
																					{
																						result = _0023_003DztIc79mb2zQ0f(_0023_003DzDzSF2oQdE9O8IsEUOA_003D_003D, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
																					}
																				}
																				else
																				{
																					result = _0023_003DzYW8_fbk_003D(_0023_003DzbJPraLv4V_0024bL, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
																				}
																			}
																			else
																			{
																				result = _0023_003DznSL46BtA1AMK9lvtvQ_003D_003D(_0023_003DzhitlgVA_003D, _0023_003DzPx2oAYw_003D);
																			}
																		}
																		else
																		{
																			result = _0023_003Dz7GUtagUMsPmy2lyWGHToiio_003D(_0023_003DzJ9ODgxjHN5qS, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
																		}
																	}
																	else
																	{
																		result = _0023_003DzTn1Io6bUTPbREAlvaQ_0024Qpxg_003D(_0023_003DzPrZ0njs5O8eq, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
																	}
																}
																else
																{
																	result = _0023_003Dz7KE37xnABuyx49gW6Kge05M_003D(_0023_003DzXoiDdkk_003D, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
																}
															}
															else
															{
																result = _0023_003DzB0jfGh4_003D(_0023_003DzIamx_OpEEKK, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
															}
														}
														else
														{
															result = _0023_003Dz2DUNGblME139WCKkIg_003D_003D(_0023_003Dzja3lgRPKmEukz9k6WQ_003D_003D, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
														}
													}
													else
													{
														result = _0023_003Dzw1MXR6bwhEwbx8GL2A_003D_003D(_0023_003DzVrJ2wtLTlBcEUy9Luw_003D_003D2, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
													}
												}
												else
												{
													result = _0023_003DzxA_O8FPlnPZiA0oSyw_003D_003D(_0023_003DzndgQYaKOzL4PELsQLg_003D_003D2, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
												}
											}
											else
											{
												result = _0023_003Dz82Xl2kzzoDOv5FfvGviVg5s_003D(_0023_003DzVrJ2wtLTlBcEUy9Luw_003D_003D, _0023_003DzPx2oAYw_003D);
											}
										}
										else
										{
											result = _0023_003DzwSe2pbzs4m_FEnsmX9mjyfU_003D(_0023_003DzndgQYaKOzL4PELsQLg_003D_003D, _0023_003DzPx2oAYw_003D);
										}
									}
									else
									{
										result = _0023_003DzcmOZw5bMqv52wB7MGRz30pWb2Kw6(_0023_003Dz4LODXENqUAL2SV7d2A_003D_003D, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
									}
								}
								else
								{
									result = _0023_003Dzj3FaN9YUcumw(_0023_003Dz6P7ZdNYd79JO, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
								}
							}
							else
							{
								result = _0023_003DzcvG8EU4_003D(_0023_003Dzai52pbTwii_b);
							}
						}
						else
						{
							result = _0023_003DzZ9PhOYHqIAeqKNXDIg_003D_003D(_0023_003DzVNc46A90XH1QddMG3A_003D_003D, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
						}
					}
					else
					{
						result = _0023_003Dzi45OB0EABVYJ(_0023_003DzRHnPVNkghFAs, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
					}
				}
				else
				{
					result = _0023_003Dzjmkx8rZdRJuB(_0023_003DzbowHg5tQnNQ9MzOqyw_003D_003D, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
				}
			}
			else
			{
				result = _0023_003DzuGoPMJG0Wc_7(_0023_003Dzr7J4i2RY3FDU4in8eA_003D_003D, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
			}
		}
		else
		{
			result = _0023_003DzNc2BB00_003D(_0023_003DzZSYhEk_cVLUx, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
		}
		return result;
	}

	private ICurve _0023_003Dz4qecmD8_003D(int _0023_003DzyzK8swU_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
	{
		ICurve curve = _0023_003Dz3u_0Ozo_003D(_0023_003DzPx2oAYw_003D[_0023_003DzyzK8swU_003D], _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D) as ICurve;
		if (curve != null && (!curve.StartPoint.IsValid() || !curve.EndPoint.IsValid()))
		{
			return null;
		}
		if (_0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D && curve is Curve { Degree: 1 } curve2 && curve2.ControlPoints.Length > 2 && curve.IsLinear(Utility._0023_003DzxhnLabVjXjPg, out var line))
		{
			curve = new Line(line.P0, line.P1).GetNurbsForm();
		}
		return curve;
	}

	private Surface _0023_003DzvO6aDbs_003D(int _0023_003DzKDWMe_WBuLKZ, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, int _0023_003DzWmSBQy2wUHb8, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
	{
		Surface surface = null;
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2 = _0023_003DzPx2oAYw_003D[_0023_003DzKDWMe_WBuLKZ];
		if (!(_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2 is _0023_003Dz_ZR_60g8KTZpV15NG_0024gJ1cZ3Q9yL1UXPtzY9x8s_003D _0023_003DzVrJ2wtLTlBcEUy9Luw_003D_003D))
		{
			if (!(_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2 is _0023_003DzYkQVv2Lb0egyGZnzeO8ydkyFt0lDEhHA4uvG2TxpWX6vfM3gdg_003D_003D _0023_003DzXoiDdkk_003D))
			{
				if (!(_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2 is _0023_003DzOKWbo7sUM8LpXGAfWbsy7u9_aoyf6rVNGlnjW9k_003D _0023_003Dzja3lgRPKmEukz9k6WQ_003D_003D))
				{
					if (!(_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2 is _0023_003DzZXHZ8r_AKGbCsLnm7EUe1w_00244EG0i1nNAEdrGUvzdztgO _0023_003DzPrZ0njs5O8eq))
					{
						if (!(_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2 is _0023_003DzfSAHMZkL2hJuTBQQ4L7dNUFzt0xFD2jPM7XhiwU_003D _0023_003Dz6P7ZdNYd79JO))
						{
							if (_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2 is _0023_003Dz3Zx4KFlYXhE6x5ocfLkICI9BSGRZVvqe1SYkVItmXGYVkWg25w_003D_003D _0023_003DzVrJ2wtLTlBcEUy9Luw_003D_003D2)
							{
								surface = (Surface)_0023_003Dz82Xl2kzzoDOv5FfvGviVg5s_003D(_0023_003DzVrJ2wtLTlBcEUy9Luw_003D_003D2, _0023_003DzPx2oAYw_003D);
							}
						}
						else
						{
							surface = (Surface)_0023_003Dzj3FaN9YUcumw(_0023_003Dz6P7ZdNYd79JO, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
						}
					}
					else
					{
						surface = (Surface)_0023_003DzTn1Io6bUTPbREAlvaQ_0024Qpxg_003D(_0023_003DzPrZ0njs5O8eq, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
					}
				}
				else
				{
					surface = (Surface)_0023_003Dz2DUNGblME139WCKkIg_003D_003D(_0023_003Dzja3lgRPKmEukz9k6WQ_003D_003D, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
				}
			}
			else
			{
				surface = (Surface)_0023_003Dz7KE37xnABuyx49gW6Kge05M_003D(_0023_003DzXoiDdkk_003D, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
			}
		}
		else
		{
			surface = (Surface)_0023_003Dzw1MXR6bwhEwbx8GL2A_003D_003D(_0023_003DzVrJ2wtLTlBcEUy9Luw_003D_003D, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
		}
		if (surface != null)
		{
			surface.TranslationID = new TranslationIdentifier(_0023_003DzWmSBQy2wUHb8);
		}
		return surface;
	}

	private Entity _0023_003DzNc2BB00_003D(_0023_003DzdPtvklPFzKqxMoTpEOXyeC1W53neVz2gTQ_003D_003D _0023_003DzZSYhEk_cVLUx, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
	{
		_0023_003DzZSYhEk_cVLUx._0023_003DzEt7rVh0_003D(out var _0023_003DzbUvT9Pc_003D, out var _0023_003DzEGKj_0024SNUUihi, out var _0023_003Dzgr_0024O76nUF_0024ci9bPCCg_003D_003D, out var _0023_003DzhJzfM5qiU6WZUQ8a7Q_003D_003D);
		Circle circle = null;
		double num = _0023_003DzhJzfM5qiU6WZUQ8a7Q_003D_003D - _0023_003Dzgr_0024O76nUF_0024ci9bPCCg_003D_003D;
		if (_0023_003DzEGKj_0024SNUUihi > 1E-12 && Math.Abs(num) > 1E-12)
		{
			circle = new Arc(_0023_003DzbUvT9Pc_003D, _0023_003DzEGKj_0024SNUUihi, _0023_003Dzgr_0024O76nUF_0024ci9bPCCg_003D_003D, _0023_003DzhJzfM5qiU6WZUQ8a7Q_003D_003D);
			if (Math.Abs(num - Math.PI * 2.0) < 1E-12)
			{
				circle = new Circle(circle.Plane, _0023_003DzEGKj_0024SNUUihi);
			}
			if (_0023_003DzZSYhEk_cVLUx._0023_003Dztfry3Xjye35X != -1)
			{
				_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D _0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D2 = (_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D)_0023_003DzPx2oAYw_003D[_0023_003DzZSYhEk_cVLUx._0023_003Dztfry3Xjye35X / 2];
				circle.TransformBy(_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D2._0023_003DzKJgErG0_003D());
			}
		}
		return circle;
	}

	private Entity _0023_003DzuGoPMJG0Wc_7(_0023_003DzEKmPHSrtZpXBuvnSgWZRaBK5Mq11POCYUuKluiI_003D _0023_003Dzr7J4i2RY3FDU4in8eA_003D_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
	{
		Surface surface = _0023_003DzvO6aDbs_003D(_0023_003Dzr7J4i2RY3FDU4in8eA_003D_003D._0023_003DzpT6ZqTI_003D / 2, _0023_003DzPx2oAYw_003D, _0023_003Dzr7J4i2RY3FDU4in8eA_003D_003D._0023_003Dz5sR_By0gsufq(), _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
		if (surface == null)
		{
			if (_0023_003DzPx2oAYw_003D[_0023_003Dzr7J4i2RY3FDU4in8eA_003D_003D._0023_003DzpT6ZqTI_003D / 2].GetType() == typeof(_0023_003Dz33gUjy3ocKE8GMVaXVlNH3IyyZmuwan0aTQv6YQ_003D))
			{
				_0023_003Dzr7J4i2RY3FDU4in8eA_003D_003D._0023_003Dz8zY9BC8xZ2uB(_0023_003Dzr7J4i2RY3FDU4in8eA_003D_003D._0023_003DzpT6ZqTI_003D, _0023_003DzPx2oAYw_003D);
				ICurve[] array = new ICurve[_0023_003Dzr7J4i2RY3FDU4in8eA_003D_003D._0023_003DzrMhKXb9bxSMURrmrR3P9LsQ_003D().Length];
				for (int i = 0; i < _0023_003Dzr7J4i2RY3FDU4in8eA_003D_003D._0023_003DzrMhKXb9bxSMURrmrR3P9LsQ_003D().Length; i++)
				{
					array[i] = _0023_003Dz4qecmD8_003D(_0023_003Dzr7J4i2RY3FDU4in8eA_003D_003D._0023_003DzrMhKXb9bxSMURrmrR3P9LsQ_003D()[i] / 2, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
				}
				_0023_003Dz33gUjy3ocKE8GMVaXVlNH3IyyZmuwan0aTQv6YQ_003D _0023_003Dzd2Xq33m9lJH = (_0023_003Dz33gUjy3ocKE8GMVaXVlNH3IyyZmuwan0aTQv6YQ_003D)_0023_003DzPx2oAYw_003D[_0023_003Dzr7J4i2RY3FDU4in8eA_003D_003D._0023_003DzpT6ZqTI_003D / 2];
				return _0023_003DzOjMB_0024_0024ObznX9uoGt4A_003D_003D(_0023_003Dzd2Xq33m9lJH, _0023_003DzPx2oAYw_003D, array);
			}
			return null;
		}
		_0023_003Dzr7J4i2RY3FDU4in8eA_003D_003D._0023_003Dz8zY9BC8xZ2uB(_0023_003Dzr7J4i2RY3FDU4in8eA_003D_003D._0023_003DzpT6ZqTI_003D, _0023_003DzPx2oAYw_003D);
		int num = _0023_003Dzr7J4i2RY3FDU4in8eA_003D_003D._0023_003DzA_0024JrkRYx9jr19MhibNkqCnh7PwJh().Length;
		if (num > 0)
		{
			List<ICurve> list = new List<ICurve>(num);
			Size3D size3D = surface.ControlBoundingBox();
			for (int j = 0; j < num; j++)
			{
				int _0023_003DzyzK8swU_003D = _0023_003Dzr7J4i2RY3FDU4in8eA_003D_003D._0023_003DzA_0024JrkRYx9jr19MhibNkqCnh7PwJh()[j] / 2;
				int _0023_003DzyzK8swU_003D2 = _0023_003Dzr7J4i2RY3FDU4in8eA_003D_003D._0023_003DzrMhKXb9bxSMURrmrR3P9LsQ_003D()[j] / 2;
				Curve nurbsForm = _0023_003Dz4qecmD8_003D(_0023_003DzyzK8swU_003D, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D).GetNurbsForm();
				if (!nurbsForm.IsPoint)
				{
					ICurve curve = _0023_003Dz4qecmD8_003D(_0023_003DzyzK8swU_003D2, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
					if (curve == null)
					{
						curve = surface.LiftCurve(nurbsForm, size3D.Diagonal * Utility._0023_003Dzjyaz_Vfaky9X);
					}
					if (_0023_003Dzr7J4i2RY3FDU4in8eA_003D_003D._0023_003DzfOilApVmFlBsn96CxA_003D_003D()[j] == 1)
					{
						curve.Reverse();
					}
					TrimCurve item = nurbsForm._0023_003DzmGgqdRaHiXdg(curve);
					list.Add(item);
				}
			}
			if (num > 1)
			{
				surface.Trimming = new devDept.Eyeshot.Entities.Region(new CompositeCurve(list), Plane.XY, true);
			}
			else
			{
				surface.Trimming = new devDept.Eyeshot.Entities.Region(list, Plane.XY, sortAndOrient: false);
			}
		}
		else
		{
			ICurve[] array2 = new ICurve[_0023_003Dzr7J4i2RY3FDU4in8eA_003D_003D._0023_003DzrMhKXb9bxSMURrmrR3P9LsQ_003D().Length];
			for (int k = 0; k < _0023_003Dzr7J4i2RY3FDU4in8eA_003D_003D._0023_003DzrMhKXb9bxSMURrmrR3P9LsQ_003D().Length; k++)
			{
				array2[k] = _0023_003Dz4qecmD8_003D(_0023_003Dzr7J4i2RY3FDU4in8eA_003D_003D._0023_003DzrMhKXb9bxSMURrmrR3P9LsQ_003D()[k] / 2, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
			}
			if (_0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
			{
				Surface surface2 = surface.Promote();
				if (surface2 != null)
				{
					surface = surface2;
				}
			}
			Surface[] array3 = Surface.DropLoops(surface, array2);
			if (array3 != null && array3.Length != 0)
			{
				return array3[0];
			}
		}
		return surface;
	}

	private Entity _0023_003Dzjmkx8rZdRJuB(_0023_003Dz_00242iQD1FOOBMB8Ag0xLXT03IXG_IUm_Shn5BXiGI_003D _0023_003DzbowHg5tQnNQ9MzOqyw_003D_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
	{
		Surface surface = _0023_003DzvO6aDbs_003D(_0023_003DzbowHg5tQnNQ9MzOqyw_003D_003D._0023_003DzpT6ZqTI_003D / 2, _0023_003DzPx2oAYw_003D, _0023_003DzbowHg5tQnNQ9MzOqyw_003D_003D._0023_003Dz5sR_By0gsufq(), _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
		List<ICurve> list = new List<ICurve>();
		if (surface == null)
		{
			if (_0023_003DzPx2oAYw_003D[_0023_003DzbowHg5tQnNQ9MzOqyw_003D_003D._0023_003DzpT6ZqTI_003D / 2].GetType() == typeof(_0023_003Dz33gUjy3ocKE8GMVaXVlNH3IyyZmuwan0aTQv6YQ_003D))
			{
				for (int i = 0; i < _0023_003DzbowHg5tQnNQ9MzOqyw_003D_003D._0023_003DzE7Mb5CQuRmf4.Length; i++)
				{
					_0023_003DzEKmPHSrtZpXBuvnSgWZRaBK5Mq11POCYUuKluiI_003D _0023_003DzeeNvtZQ_003D = (_0023_003DzEKmPHSrtZpXBuvnSgWZRaBK5Mq11POCYUuKluiI_003D)_0023_003DzPx2oAYw_003D[_0023_003DzbowHg5tQnNQ9MzOqyw_003D_003D._0023_003DzE7Mb5CQuRmf4[i] / 2];
					ICurve curve = _0023_003Dzmnvbw8XwPCRrYDl84w_003D_003D(_0023_003DzbowHg5tQnNQ9MzOqyw_003D_003D, _0023_003DzeeNvtZQ_003D, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
					if (curve != null)
					{
						list.Add(curve);
					}
				}
				_0023_003Dz33gUjy3ocKE8GMVaXVlNH3IyyZmuwan0aTQv6YQ_003D _0023_003Dzd2Xq33m9lJH = (_0023_003Dz33gUjy3ocKE8GMVaXVlNH3IyyZmuwan0aTQv6YQ_003D)_0023_003DzPx2oAYw_003D[_0023_003DzbowHg5tQnNQ9MzOqyw_003D_003D._0023_003DzpT6ZqTI_003D / 2];
				return _0023_003DzOjMB_0024_0024ObznX9uoGt4A_003D_003D(_0023_003Dzd2Xq33m9lJH, _0023_003DzPx2oAYw_003D, list.ToArray());
			}
			if (_0023_003DzPx2oAYw_003D[_0023_003DzbowHg5tQnNQ9MzOqyw_003D_003D._0023_003DzpT6ZqTI_003D / 2].GetType() == typeof(_0023_003DzOK_wIuCG_0024L33RaVzjK4JLUKKO_p4pq_0024by5YYyrY_003D))
			{
				for (int j = 0; j < _0023_003DzbowHg5tQnNQ9MzOqyw_003D_003D._0023_003DzE7Mb5CQuRmf4.Length; j++)
				{
					_0023_003DzEKmPHSrtZpXBuvnSgWZRaBK5Mq11POCYUuKluiI_003D _0023_003DzeeNvtZQ_003D2 = (_0023_003DzEKmPHSrtZpXBuvnSgWZRaBK5Mq11POCYUuKluiI_003D)_0023_003DzPx2oAYw_003D[_0023_003DzbowHg5tQnNQ9MzOqyw_003D_003D._0023_003DzE7Mb5CQuRmf4[j] / 2];
					ICurve curve2 = _0023_003Dzmnvbw8XwPCRrYDl84w_003D_003D(_0023_003DzbowHg5tQnNQ9MzOqyw_003D_003D, _0023_003DzeeNvtZQ_003D2, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
					if (curve2 != null)
					{
						list.Add(curve2);
					}
				}
				_0023_003DzOK_wIuCG_0024L33RaVzjK4JLUKKO_p4pq_0024by5YYyrY_003D _0023_003Dzd2Xq33m9lJH2 = (_0023_003DzOK_wIuCG_0024L33RaVzjK4JLUKKO_p4pq_0024by5YYyrY_003D)_0023_003DzPx2oAYw_003D[_0023_003DzbowHg5tQnNQ9MzOqyw_003D_003D._0023_003DzpT6ZqTI_003D / 2];
				return _0023_003DzOjMB_0024_0024ObznX9uoGt4A_003D_003D(_0023_003Dzd2Xq33m9lJH2, _0023_003DzPx2oAYw_003D, list.ToArray(), null);
			}
			return null;
		}
		int num = ((_0023_003DzEKmPHSrtZpXBuvnSgWZRaBK5Mq11POCYUuKluiI_003D)_0023_003DzPx2oAYw_003D[_0023_003DzbowHg5tQnNQ9MzOqyw_003D_003D._0023_003DzE7Mb5CQuRmf4[0] / 2])._0023_003DzA_0024JrkRYx9jr19MhibNkqCnh7PwJh().Length;
		int num2 = _0023_003DzbowHg5tQnNQ9MzOqyw_003D_003D._0023_003DzE7Mb5CQuRmf4.Length;
		bool _0023_003DzWSpuNLIjS7dl = num2 == 0;
		if (num > 0)
		{
			for (int k = 0; k < num2; k++)
			{
				_0023_003DzEKmPHSrtZpXBuvnSgWZRaBK5Mq11POCYUuKluiI_003D _0023_003DzeeNvtZQ_003D3 = (_0023_003DzEKmPHSrtZpXBuvnSgWZRaBK5Mq11POCYUuKluiI_003D)_0023_003DzPx2oAYw_003D[_0023_003DzbowHg5tQnNQ9MzOqyw_003D_003D._0023_003DzE7Mb5CQuRmf4[k] / 2];
				ICurve curve3 = _0023_003DzLbPRCZnEKZBJ(_0023_003DzeeNvtZQ_003D3, surface, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzWSpuNLIjS7dl);
				if (curve3 == null)
				{
					return surface;
				}
				list.Add(curve3);
			}
			surface.Trimming = new devDept.Eyeshot.Entities.Region(list, Plane.XY, sortAndOrient: true);
		}
		else
		{
			for (int l = 0; l < num2; l++)
			{
				_0023_003DzEKmPHSrtZpXBuvnSgWZRaBK5Mq11POCYUuKluiI_003D _0023_003DzeeNvtZQ_003D4 = (_0023_003DzEKmPHSrtZpXBuvnSgWZRaBK5Mq11POCYUuKluiI_003D)_0023_003DzPx2oAYw_003D[_0023_003DzbowHg5tQnNQ9MzOqyw_003D_003D._0023_003DzE7Mb5CQuRmf4[l] / 2];
				ICurve curve4 = _0023_003Dzmnvbw8XwPCRrYDl84w_003D_003D(_0023_003DzbowHg5tQnNQ9MzOqyw_003D_003D, _0023_003DzeeNvtZQ_003D4, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
				if (curve4 != null)
				{
					list.Add(curve4);
				}
			}
			if (_0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
			{
				Surface surface2 = surface.Promote();
				if (surface2 != null)
				{
					surface = surface2;
				}
			}
			if (surface is PlanarSurface)
			{
				return Surface._0023_003DzCaJhR_0024Jdhxn_0024lcMUgA_003D_003D(((PlanarSurface)surface).Plane, list).ConvertToSurface();
			}
			Surface[] array = Surface.DropLoops(surface, list);
			if (array != null && array.Length != 0)
			{
				return array[0];
			}
		}
		return surface;
	}

	private ICurve _0023_003DzLbPRCZnEKZBJ(_0023_003DzEKmPHSrtZpXBuvnSgWZRaBK5Mq11POCYUuKluiI_003D _0023_003DzeeNvtZQ_003D, Surface _0023_003Dz_0024KKopL9T7nzT, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, bool _0023_003DzWSpuNLIjS7dl)
	{
		int num = _0023_003DzeeNvtZQ_003D._0023_003DzA_0024JrkRYx9jr19MhibNkqCnh7PwJh().Length;
		List<ICurve> list = new List<ICurve>(num);
		bool flag = false;
		for (int i = 0; i < num; i++)
		{
			int _0023_003DzyzK8swU_003D = _0023_003DzeeNvtZQ_003D._0023_003DzA_0024JrkRYx9jr19MhibNkqCnh7PwJh()[i] / 2;
			Curve nurbsForm = _0023_003Dz4qecmD8_003D(_0023_003DzyzK8swU_003D, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D).GetNurbsForm();
			if (!nurbsForm.IsPoint)
			{
				ICurve[] array = nurbsForm.SplitAtDiscontinuities(speedChange: false);
				ICurve[] array2 = array;
				if (array2.Length > 1)
				{
					flag = true;
					list.AddRange(array2);
				}
				else
				{
					list.Add(nurbsForm);
				}
			}
		}
		if (_0023_003DzWSpuNLIjS7dl && _0023_003Dz7bMUILkfG8P9W9cWvF5ZIz8_003D(_0023_003Dz_0024KKopL9T7nzT, list))
		{
			return null;
		}
		List<TrimCurve> list2 = new List<TrimCurve>(num);
		double num2 = _0023_003Dz_0024KKopL9T7nzT.ControlBoundingBox().Diagonal * Utility._0023_003Dzjyaz_Vfaky9X;
		num = list.Count;
		if (flag)
		{
			num = list.Count;
			for (int j = 0; j < num; j++)
			{
				Curve curve = (Curve)list[j];
				ICurve _0023_003DzTx2aqr8_003D = _0023_003Dz_0024KKopL9T7nzT.LiftCurve(curve, num2);
				TrimCurve trimCurve = curve._0023_003DzmGgqdRaHiXdg(_0023_003DzTx2aqr8_003D);
				if (trimCurve._0023_003Dz736ekIs_003D() > _0023_003Dz_0024KKopL9T7nzT._0023_003DzVx1luJEZaaC7().Min * 1E-06)
				{
					list2.Add(trimCurve);
				}
			}
		}
		else
		{
			for (int k = 0; k < num; k++)
			{
				int _0023_003DzyzK8swU_003D2 = _0023_003DzeeNvtZQ_003D._0023_003DzrMhKXb9bxSMURrmrR3P9LsQ_003D()[k] / 2;
				Curve curve2 = (Curve)list[k];
				ICurve curve3 = _0023_003Dz4qecmD8_003D(_0023_003DzyzK8swU_003D2, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
				if (curve3 != null && _0023_003DzeeNvtZQ_003D._0023_003DzfOilApVmFlBsn96CxA_003D_003D()[k] == 2)
				{
					curve3.Reverse();
				}
				if (curve3 == null || _0023_003Dz_0024KKopL9T7nzT.PointAt(curve2.StartPoint).DistanceTo(curve3.StartPoint) > num2)
				{
					curve3 = _0023_003Dz_0024KKopL9T7nzT.LiftCurve(curve2, num2);
				}
				TrimCurve trimCurve2 = curve2._0023_003DzmGgqdRaHiXdg(curve3);
				if (trimCurve2._0023_003Dz736ekIs_003D() > _0023_003Dz_0024KKopL9T7nzT._0023_003DzVx1luJEZaaC7().Min * 1E-06)
				{
					list2.Add(trimCurve2);
				}
			}
		}
		if (list2.Count > 1)
		{
			CompositeCurve compositeCurve = new CompositeCurve();
			compositeCurve.CurveList.AddRange(list2);
			return compositeCurve;
		}
		return list2[0];
	}

	private ICurve _0023_003Dzmnvbw8XwPCRrYDl84w_003D_003D(_0023_003Dz_00242iQD1FOOBMB8Ag0xLXT03IXG_IUm_Shn5BXiGI_003D _0023_003DzbowHg5tQnNQ9MzOqyw_003D_003D, _0023_003DzEKmPHSrtZpXBuvnSgWZRaBK5Mq11POCYUuKluiI_003D _0023_003DzeeNvtZQ_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
	{
		int num = _0023_003DzeeNvtZQ_003D._0023_003DzrMhKXb9bxSMURrmrR3P9LsQ_003D().Length;
		if (num == 0)
		{
			return null;
		}
		ICurve[] array = new ICurve[num];
		for (int i = 0; i < num; i++)
		{
			int _0023_003DzyzK8swU_003D = _0023_003DzeeNvtZQ_003D._0023_003DzrMhKXb9bxSMURrmrR3P9LsQ_003D()[i] / 2;
			_0023_003DzbowHg5tQnNQ9MzOqyw_003D_003D._0023_003Dz8zY9BC8xZ2uB(_0023_003DzeeNvtZQ_003D._0023_003DzrMhKXb9bxSMURrmrR3P9LsQ_003D()[i], _0023_003DzPx2oAYw_003D);
			ICurve curve = _0023_003Dz4qecmD8_003D(_0023_003DzyzK8swU_003D, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
			if (_0023_003DzeeNvtZQ_003D._0023_003DzfOilApVmFlBsn96CxA_003D_003D()[i] == 2)
			{
				curve.Reverse();
			}
			array[i] = curve;
		}
		if (array.Length > 1)
		{
			CompositeCurve compositeCurve = new CompositeCurve();
			compositeCurve.CurveList.AddRange(array);
			return compositeCurve;
		}
		return array[0];
	}

	private Entity _0023_003Dzi45OB0EABVYJ(_0023_003Dzz6JIJ4xNe1_0024dIMT88uFZydqQ_0024upBYSTqB05jKFc_003D _0023_003DzRHnPVNkghFAs, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
	{
		CompositeCurve compositeCurve = new CompositeCurve();
		int[] _0023_003DzoIzGcV9HDusy = _0023_003DzRHnPVNkghFAs._0023_003DzoIzGcV9HDusy;
		foreach (int num in _0023_003DzoIzGcV9HDusy)
		{
			_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D _0023_003DzXgwfWtYr8tE_0024 = _0023_003DzPx2oAYw_003D[num / 2];
			Entity entity = _0023_003Dz3u_0Ozo_003D(_0023_003DzXgwfWtYr8tE_0024, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
			if (entity != null)
			{
				compositeCurve.CurveList.Add((ICurve)entity);
			}
		}
		compositeCurve.SortAndOrient();
		return compositeCurve;
	}

	private Entity _0023_003DzZ9PhOYHqIAeqKNXDIg_003D_003D(_0023_003Dzdqr8UI0Jipc_0024TuuKDhHIJvVq3Tj138M0mHUw_gY_003D _0023_003DzVNc46A90XH1QddMG3A_003D_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
	{
		_0023_003DzVNc46A90XH1QddMG3A_003D_003D._0023_003DzmCI7Tzo_003D(out var _0023_003DzE8QrneA_003D, out var _0023_003DzshZYG54_003D, out var _0023_003DzHit7vU4_003D, out var _0023_003Dza7VMr8U_003D, out var _0023_003Dzk8kWavc_003D, out var _0023_003Dzc_0024dH8eA_003D, out var _0023_003DzdV1szTs_003D, out var _0023_003DzDHgNxvo_003D);
		Entity entity = null;
		switch (_0023_003DzVNc46A90XH1QddMG3A_003D_003D._0023_003Dz5_b6Y9YeDZSU())
		{
		case (_0023_003Dzdqr8UI0Jipc_0024TuuKDhHIJvVq3Tj138M0mHUw_gY_003D._0023_003Dz41YmlqEGCK_Y)1:
		{
			double num = Math.Sqrt((0.0 - _0023_003DzHit7vU4_003D) / _0023_003DzE8QrneA_003D);
			double num2 = Math.Sqrt((0.0 - _0023_003DzHit7vU4_003D) / _0023_003DzshZYG54_003D);
			double num3 = Utility.ArcTanProblem(_0023_003Dzk8kWavc_003D, _0023_003Dzc_0024dH8eA_003D);
			double endAngle = Utility.ArcTanProblem(_0023_003DzdV1szTs_003D, _0023_003DzDHgNxvo_003D);
			Utility.FixEndAngle(num3, ref endAngle);
			if (num > 1E-12 && num2 > 1E-12 && Math.Abs(endAngle - num3) > 1E-12)
			{
				Ellipse ellipse = new EllipticalArc(new Point3D(0.0, 0.0, _0023_003Dza7VMr8U_003D), num, num2, num3, endAngle, polarAngles: true);
				entity = ellipse;
				if (_0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D && ellipse.IsCircle)
				{
					entity = new Arc(ellipse.Plane, Point2D.Origin, ellipse.RadiusX, ellipse.Domain.Low, ellipse.Domain.High);
				}
			}
			break;
		}
		case (_0023_003Dzdqr8UI0Jipc_0024TuuKDhHIJvVq3Tj138M0mHUw_gY_003D._0023_003Dz41YmlqEGCK_Y)2:
			entity = new Line(_0023_003Dzk8kWavc_003D, _0023_003Dzc_0024dH8eA_003D, _0023_003Dza7VMr8U_003D, _0023_003DzdV1szTs_003D, _0023_003DzDHgNxvo_003D, _0023_003Dza7VMr8U_003D);
			break;
		case (_0023_003Dzdqr8UI0Jipc_0024TuuKDhHIJvVq3Tj138M0mHUw_gY_003D._0023_003Dz41YmlqEGCK_Y)3:
			entity = new Line(_0023_003Dzk8kWavc_003D, _0023_003Dzc_0024dH8eA_003D, _0023_003Dza7VMr8U_003D, _0023_003DzdV1szTs_003D, _0023_003DzDHgNxvo_003D, _0023_003Dza7VMr8U_003D);
			break;
		}
		if (entity != null && _0023_003DzVNc46A90XH1QddMG3A_003D_003D._0023_003Dztfry3Xjye35X != -1)
		{
			_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D _0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D2 = (_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D)_0023_003DzPx2oAYw_003D[_0023_003DzVNc46A90XH1QddMG3A_003D_003D._0023_003Dztfry3Xjye35X / 2];
			entity.TransformBy(_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D2._0023_003DzKJgErG0_003D());
		}
		return entity;
	}

	private Entity _0023_003DzsV3zf01sWNBIneDahw_003D_003D(_0023_003DzCvMCt05pVvqGJGI368UlSvv09UP9pWWmRo3Qh0YGOXCU _0023_003DzPs16gVsjjx8sBRfHlRQ7Cf8_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D)
	{
		if (_0023_003DzPs16gVsjjx8sBRfHlRQ7Cf8_003D._0023_003DzrdSL0CI_003D == null)
		{
			return null;
		}
		if (_0023_003DzPs16gVsjjx8sBRfHlRQ7Cf8_003D._0023_003DzrdSL0CI_003D.Length == 1)
		{
			return new PointCloud(_0023_003DzPs16gVsjjx8sBRfHlRQ7Cf8_003D._0023_003DzrdSL0CI_003D, 4f);
		}
		LinearPath linearPath = new LinearPath(_0023_003DzPs16gVsjjx8sBRfHlRQ7Cf8_003D._0023_003DzrdSL0CI_003D);
		if (_0023_003DzPs16gVsjjx8sBRfHlRQ7Cf8_003D._0023_003Dztfry3Xjye35X != -1)
		{
			_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D _0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D2 = (_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D)_0023_003DzPx2oAYw_003D[_0023_003DzPs16gVsjjx8sBRfHlRQ7Cf8_003D._0023_003Dztfry3Xjye35X / 2];
			linearPath.TransformBy(_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D2._0023_003DzKJgErG0_003D());
		}
		return linearPath;
	}

	private Entity _0023_003DzcvG8EU4_003D(_0023_003DzCDSdDaukKIfQIKuoRosZ3NAKyMQ1WGSxOA_003D_003D _0023_003Dzai52pbTwii_b)
	{
		return new Line(_0023_003Dzai52pbTwii_b._0023_003DzAqOpw0w_003D, _0023_003Dzai52pbTwii_b._0023_003Dzk64JNOo_003D);
	}

	private Entity _0023_003DzcmOZw5bMqv52wB7MGRz30pWb2Kw6(_0023_003DzTsGSj5r0zhbKoPjk04Ctgt5hXkbDo26vk_YJJ_kCYeB4dIKQQQ_003D_003D _0023_003Dz4LODXENqUAL2SV7d2A_003D_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
	{
		Brep.Face[] _0023_003DzpPOEJqcAh7Lr = null;
		Brep.Face[][] array = new Brep.Face[_0023_003Dz4LODXENqUAL2SV7d2A_003D_003D._0023_003DzRPM5wMvHmKSQ.Length - 1][];
		List<Point3D> list = new List<Point3D>();
		List<Brep.Edge> list2 = new List<Brep.Edge>();
		Dictionary<KeyValuePair<int, int>, int> _0023_003DzJy4cO6zhkT9q = new Dictionary<KeyValuePair<int, int>, int>();
		Dictionary<KeyValuePair<int, int>, int> _0023_003DzEpQ1TCYZhfGc = new Dictionary<KeyValuePair<int, int>, int>();
		for (int i = 0; i < _0023_003Dz4LODXENqUAL2SV7d2A_003D_003D._0023_003DzRPM5wMvHmKSQ.Length; i++)
		{
			int num = _0023_003Dz4LODXENqUAL2SV7d2A_003D_003D._0023_003DzRPM5wMvHmKSQ[i];
			_0023_003DzF5p_8NJ3PUm7nyvOOwDz4l_0024pwTFYmB_e_0024Q_003D_003D _0023_003DzF5p_8NJ3PUm7nyvOOwDz4l_0024pwTFYmB_e_0024Q_003D_003D2 = (_0023_003DzF5p_8NJ3PUm7nyvOOwDz4l_0024pwTFYmB_e_0024Q_003D_003D)_0023_003DzPx2oAYw_003D[num / 2];
			_0023_003DzF5p_8NJ3PUm7nyvOOwDz4l_0024pwTFYmB_e_0024Q_003D_003D2._0023_003Dz8zY9BC8xZ2uB(num, _0023_003DzPx2oAYw_003D);
			Brep.Face[] array2 = _0023_003DzQtScsQY_003D(_0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzF5p_8NJ3PUm7nyvOOwDz4l_0024pwTFYmB_e_0024Q_003D_003D2, _0023_003DzEpQ1TCYZhfGc, list2, i, _0023_003DzJy4cO6zhkT9q, list);
			if (i == 0)
			{
				_0023_003DzpPOEJqcAh7Lr = array2;
			}
			else
			{
				array[i - 1] = array2;
			}
		}
		Brep brep = new Brep(list.ToArray(), list2.ToArray(), _0023_003DzpPOEJqcAh7Lr, _0023_003DzqMxdROkOZ2gG: false, array, _0023_003DzPPoX8HETqTZN: true, _0023_003DzMcq9hcRIFsnaUZ3PgA_003D_003D: true, log);
		if (!_0023_003Dz4LODXENqUAL2SV7d2A_003D_003D._0023_003DzfpA0rmAAHeB4[0])
		{
			_0023_003Dz3jeSWxABmWS4(brep.Faces);
		}
		for (int j = 1; j < _0023_003Dz4LODXENqUAL2SV7d2A_003D_003D._0023_003DzfpA0rmAAHeB4.Length; j++)
		{
			if (!_0023_003Dz4LODXENqUAL2SV7d2A_003D_003D._0023_003DzfpA0rmAAHeB4[j])
			{
				_0023_003Dz3jeSWxABmWS4(brep.Inners[j - 1]);
			}
		}
		brep.FixNormals();
		return brep;
	}

	private void _0023_003Dz3jeSWxABmWS4(Brep.Face[] _0023_003DzEtn4dIEPKCsi)
	{
		for (int i = 0; i < _0023_003DzEtn4dIEPKCsi.Length; i++)
		{
			_0023_003DzEtn4dIEPKCsi[i].Flip();
		}
	}

	private Brep.Face[] _0023_003DzQtScsQY_003D(List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzF5p_8NJ3PUm7nyvOOwDz4l_0024pwTFYmB_e_0024Q_003D_003D _0023_003DzxKZRqpY_003D, Dictionary<KeyValuePair<int, int>, int> _0023_003DzEpQ1TCYZhfGc, List<Brep.Edge> _0023_003DzcFqhPo_0024Q_0024jYE, int _0023_003DzuwH5j5s_003D, Dictionary<KeyValuePair<int, int>, int> _0023_003DzJy4cO6zhkT9q, List<Point3D> _0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D)
	{
		Brep.Face[] array = new Brep.Face[_0023_003DzxKZRqpY_003D._0023_003DzzsWvP_3BfrPS.Length];
		for (int i = 0; i < _0023_003DzxKZRqpY_003D._0023_003DzzsWvP_3BfrPS.Length; i++)
		{
			int num = _0023_003DzxKZRqpY_003D._0023_003DzzsWvP_3BfrPS[i];
			bool flag = _0023_003DzxKZRqpY_003D._0023_003DzGInQsaa5ZW2U60JXbg_003D_003D[i];
			_0023_003Dzy4DM0pk_0024TAdIhuL2pH9FIzCDKJadlZSRDQ_003D_003D _0023_003Dzy4DM0pk_0024TAdIhuL2pH9FIzCDKJadlZSRDQ_003D_003D2 = (_0023_003Dzy4DM0pk_0024TAdIhuL2pH9FIzCDKJadlZSRDQ_003D_003D)_0023_003DzPx2oAYw_003D[num / 2];
			Brep.Loop[] array2 = new Brep.Loop[_0023_003Dzy4DM0pk_0024TAdIhuL2pH9FIzCDKJadlZSRDQ_003D_003D2._0023_003Dz2YUWT82LAa_U.Length];
			for (int j = 0; j < _0023_003Dzy4DM0pk_0024TAdIhuL2pH9FIzCDKJadlZSRDQ_003D_003D2._0023_003Dz2YUWT82LAa_U.Length; j++)
			{
				_0023_003DzEKmPHSrtZpXBuvnSgWZRaP_j0pyFE9wA6w_003D_003D _0023_003DzEKmPHSrtZpXBuvnSgWZRaP_j0pyFE9wA6w_003D_003D2 = (_0023_003DzEKmPHSrtZpXBuvnSgWZRaP_j0pyFE9wA6w_003D_003D)_0023_003DzPx2oAYw_003D[_0023_003Dzy4DM0pk_0024TAdIhuL2pH9FIzCDKJadlZSRDQ_003D_003D2._0023_003Dz2YUWT82LAa_U[j] / 2];
				Brep.OrientedEdge[] array3 = new Brep.OrientedEdge[_0023_003DzEKmPHSrtZpXBuvnSgWZRaP_j0pyFE9wA6w_003D_003D2._0023_003DzOfbk2Fc_003D.Length];
				for (int k = 0; k < _0023_003DzEKmPHSrtZpXBuvnSgWZRaP_j0pyFE9wA6w_003D_003D2._0023_003DzOfbk2Fc_003D.Length; k++)
				{
					_0023_003DzKYRxuYwyt6i6S31w4RfQLz_sEGsBO92VbTkQi6E_003D _0023_003DzKYRxuYwyt6i6S31w4RfQLz_sEGsBO92VbTkQi6E_003D2 = _0023_003DzEKmPHSrtZpXBuvnSgWZRaP_j0pyFE9wA6w_003D_003D2._0023_003DzOfbk2Fc_003D[k];
					if (_0023_003DzKYRxuYwyt6i6S31w4RfQLz_sEGsBO92VbTkQi6E_003D2._0023_003DzEKSHIVc_003D == 1)
					{
						continue;
					}
					int _0023_003DzyzK8swU_003D = _0023_003DzKYRxuYwyt6i6S31w4RfQLz_sEGsBO92VbTkQi6E_003D2._0023_003DzyzK8swU_003D;
					KeyValuePair<int, int> key = new KeyValuePair<int, int>(_0023_003DzKYRxuYwyt6i6S31w4RfQLz_sEGsBO92VbTkQi6E_003D2._0023_003DzgirOqRvfIooH, _0023_003DzyzK8swU_003D);
					if (_0023_003DzEpQ1TCYZhfGc.ContainsKey(key))
					{
						_0023_003DzyzK8swU_003D = _0023_003DzEpQ1TCYZhfGc[key];
						_0023_003DzcFqhPo_0024Q_0024jYE[_0023_003DzyzK8swU_003D].ShellIndex = _0023_003DzuwH5j5s_003D;
						int num2 = _0023_003DzcFqhPo_0024Q_0024jYE[_0023_003DzyzK8swU_003D].Parents.Length;
						Array.Resize(ref _0023_003DzcFqhPo_0024Q_0024jYE[_0023_003DzyzK8swU_003D].Parents, num2 + 1);
						_0023_003DzcFqhPo_0024Q_0024jYE[_0023_003DzyzK8swU_003D].Parents[num2] = i;
					}
					else
					{
						int count = _0023_003DzcFqhPo_0024Q_0024jYE.Count;
						_0023_003Dz38od8vOHDENlXGsAjsoZ8Zt6_0024YR8MrUxug_003D_003D _0023_003DzTx2aqr8_003D = ((_0023_003Dzg9kdMKEMX5KRt9SgqKcmIBs4bF4zPzCU3g_003D_003D)_0023_003DzPx2oAYw_003D[_0023_003DzKYRxuYwyt6i6S31w4RfQLz_sEGsBO92VbTkQi6E_003D2._0023_003DzgirOqRvfIooH / 2])._0023_003DzU3hosSAzkxO7[_0023_003DzyzK8swU_003D];
						ICurve curve = _0023_003DzrPcHWr0_003D(_0023_003DzTx2aqr8_003D, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
						int num3 = _0023_003DzTx2aqr8_003D._0023_003Dz0mpLUaQHQBW0 - 1;
						KeyValuePair<int, int> key2 = new KeyValuePair<int, int>(_0023_003DzTx2aqr8_003D._0023_003Dz7BqtNM297tDO, num3);
						if (_0023_003DzJy4cO6zhkT9q.TryGetValue(key2, out var value))
						{
							num3 = value;
						}
						else
						{
							int count2 = _0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D.Count;
							Point3D point3D = ((_0023_003DzzqQMnVz1u4B7Ao5VuLHfFnIEzCMKuUZ_0024gQ_003D_003D)_0023_003DzPx2oAYw_003D[_0023_003DzTx2aqr8_003D._0023_003Dz7BqtNM297tDO / 2])._0023_003DzFsatqHw_003D[num3];
							num3 = count2;
							_0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D.Add(new Brep.Vertex(point3D.X, point3D.Y, point3D.Z));
							_0023_003DzJy4cO6zhkT9q.Add(key2, count2);
						}
						int num4 = _0023_003DzTx2aqr8_003D._0023_003DzTwQpWzBy3CGU - 1;
						key2 = new KeyValuePair<int, int>(_0023_003DzTx2aqr8_003D._0023_003DzI3ES_wnQu_00248F, num4);
						if (_0023_003DzJy4cO6zhkT9q.TryGetValue(key2, out var value2))
						{
							num4 = value2;
						}
						else
						{
							int count3 = _0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D.Count;
							Point3D point3D2 = ((_0023_003DzzqQMnVz1u4B7Ao5VuLHfFnIEzCMKuUZ_0024gQ_003D_003D)_0023_003DzPx2oAYw_003D[_0023_003DzTx2aqr8_003D._0023_003DzI3ES_wnQu_00248F / 2])._0023_003DzFsatqHw_003D[num4];
							num4 = count3;
							_0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D.Add(new Brep.Vertex(point3D2.X, point3D2.Y, point3D2.Z));
							_0023_003DzJy4cO6zhkT9q.Add(key2, count3);
						}
						Brep.Edge edge = new Brep.Edge(curve, num3, num4);
						edge.ShellIndex = _0023_003DzuwH5j5s_003D;
						edge.Parents = new int[1] { i };
						_0023_003DzyzK8swU_003D = count;
						if (((Brep.Vertex)_0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D[num3]).Parents == null)
						{
							((Brep.Vertex)_0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D[num3]).Parents = new int[1] { _0023_003DzyzK8swU_003D };
						}
						else if (!((Brep.Vertex)_0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D[num3]).Parents.Contains(_0023_003DzyzK8swU_003D))
						{
							int num5 = ((Brep.Vertex)_0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D[num3]).Parents.Length;
							Array.Resize(ref ((Brep.Vertex)_0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D[num3]).Parents, num5 + 1);
							((Brep.Vertex)_0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D[num3]).Parents[num5] = _0023_003DzyzK8swU_003D;
						}
						if (((Brep.Vertex)_0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D[num4]).Parents == null)
						{
							((Brep.Vertex)_0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D[num4]).Parents = new int[1] { _0023_003DzyzK8swU_003D };
						}
						else if (!((Brep.Vertex)_0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D[num4]).Parents.Contains(_0023_003DzyzK8swU_003D))
						{
							int num6 = ((Brep.Vertex)_0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D[num4]).Parents.Length;
							Array.Resize(ref ((Brep.Vertex)_0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D[num4]).Parents, num6 + 1);
							((Brep.Vertex)_0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D[num4]).Parents[num6] = _0023_003DzyzK8swU_003D;
						}
						_0023_003DzcFqhPo_0024Q_0024jYE.Add(edge);
						_0023_003DzEpQ1TCYZhfGc.Add(key, count);
					}
					Brep.OrientedEdge orientedEdge = new Brep.OrientedEdge(_0023_003DzyzK8swU_003D, _0023_003DzKYRxuYwyt6i6S31w4RfQLz_sEGsBO92VbTkQi6E_003D2._0023_003Dzx3pYiE0_003D);
					array3[k] = orientedEdge;
				}
				array2[j] = new Brep.Loop(array3);
			}
			List<ICurve> list = new List<ICurve>(array2.Length);
			Brep.Loop[] array4 = array2;
			for (int l = 0; l < array4.Length; l++)
			{
				Brep.OrientedEdge[] segments = array4[l].Segments;
				for (int m = 0; m < segments.Length; m++)
				{
					Brep.OrientedEdge orientedEdge2 = segments[m];
					list.Add(_0023_003DzcFqhPo_0024Q_0024jYE[orientedEdge2.CurveIndex].Curve);
				}
			}
			bool _0023_003DzClBtlvaHChzq = flag;
			AnalyticSurf surface = _0023_003DzPyFIK4f0xBPL57vY_VK6SO0_003D(_0023_003Dzy4DM0pk_0024TAdIhuL2pH9FIzCDKJadlZSRDQ_003D_003D2, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, ref _0023_003DzClBtlvaHChzq);
			if (!flag)
			{
				array4 = array2;
				foreach (Brep.Loop loop in array4)
				{
					loop.Sense = !loop.Sense;
				}
			}
			Brep.Face face = new Brep.Face(surface, array2, _0023_003DzClBtlvaHChzq);
			if (_0023_003Dzy4DM0pk_0024TAdIhuL2pH9FIzCDKJadlZSRDQ_003D_003D2._0023_003Dz7Hj3HvFG5jpL() < 0 && _0023_003DzPx2oAYw_003D[-_0023_003Dzy4DM0pk_0024TAdIhuL2pH9FIzCDKJadlZSRDQ_003D_003D2._0023_003Dz7Hj3HvFG5jpL() / 2] is _0023_003DzoMowD04mt4vKC4cSDkFRUr_dj0yUGXqXlA_003D_003D _0023_003DzoMowD04mt4vKC4cSDkFRUr_dj0yUGXqXlA_003D_003D2)
			{
				face.Color = _0023_003DzoMowD04mt4vKC4cSDkFRUr_dj0yUGXqXlA_003D_003D2._0023_003Dz_8C3BH8_003D();
			}
			array[i] = face;
		}
		return array;
	}

	private ICurve _0023_003DzrPcHWr0_003D(_0023_003Dz38od8vOHDENlXGsAjsoZ8Zt6_0024YR8MrUxug_003D_003D _0023_003DzTx2aqr8_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
	{
		ICurve curve = _0023_003Dz4qecmD8_003D(_0023_003DzTx2aqr8_003D._0023_003DzxyO_0024eRmpEgLo / 2, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
		((Entity)curve).TranslationID = new TranslationIdentifier(_0023_003DzTx2aqr8_003D._0023_003DzxyO_0024eRmpEgLo);
		return curve;
	}

	private AnalyticSurf _0023_003DzPyFIK4f0xBPL57vY_VK6SO0_003D(_0023_003Dzy4DM0pk_0024TAdIhuL2pH9FIzCDKJadlZSRDQ_003D_003D _0023_003DzRvt6sMuksW0E, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, ref bool _0023_003DzClBtlvaHChzq)
	{
		AnalyticSurf analyticSurf = null;
		int index = _0023_003DzRvt6sMuksW0E._0023_003DzaX0ZjLs_003D / 2;
		if (_0023_003DzPx2oAYw_003D[index] is _0023_003Dz_ZR_60g8KTZpV15NG_0024gJ1cZ3Q9yL1UXPtzY9x8s_003D _0023_003DzVrJ2wtLTlBcEUy9Luw_003D_003D)
		{
			Surface surface = (Surface)_0023_003Dzw1MXR6bwhEwbx8GL2A_003D_003D(_0023_003DzVrJ2wtLTlBcEUy9Luw_003D_003D, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
			if (_0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
			{
				Surface surface2 = surface.Promote();
				if (surface2 != null)
				{
					Utility.UpdateAnalyticSurfSense(surface2, ref _0023_003DzClBtlvaHChzq);
					analyticSurf = surface2._0023_003DzWTGiFlsuyM_0024wBdTI5w_003D_003D();
				}
			}
			if (analyticSurf == null)
			{
				analyticSurf = surface._0023_003DzWTGiFlsuyM_0024wBdTI5w_003D_003D();
			}
		}
		else if (_0023_003DzPx2oAYw_003D[index] is _0023_003DzYkQVv2Lb0egyGZnzeO8ydkyFt0lDEhHA4uvG2TxpWX6vfM3gdg_003D_003D _0023_003DzXoiDdkk_003D)
		{
			analyticSurf = _0023_003Dzr9aYUeg2qPMPZLtxPfTkGQhsLNsD(_0023_003DzXoiDdkk_003D, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
		}
		else if (_0023_003DzPx2oAYw_003D[index] is _0023_003DzOKWbo7sUM8LpXGAfWbsy7u9_aoyf6rVNGlnjW9k_003D _0023_003Dzja3lgRPKmEukz9k6WQ_003D_003D)
		{
			analyticSurf = ((Surface)_0023_003Dz2DUNGblME139WCKkIg_003D_003D(_0023_003Dzja3lgRPKmEukz9k6WQ_003D_003D, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D))._0023_003DzWTGiFlsuyM_0024wBdTI5w_003D_003D();
		}
		else if (_0023_003DzPx2oAYw_003D[index] is _0023_003DzZXHZ8r_AKGbCsLnm7EUe1w_00244EG0i1nNAEdrGUvzdztgO _0023_003DzSiZudnyXU7Mi)
		{
			analyticSurf = _0023_003DzBg6w7EQVRtkIDANkZYN9EriDhAtu(_0023_003DzSiZudnyXU7Mi, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
		}
		else if (_0023_003DzPx2oAYw_003D[index] is _0023_003Dz33gUjy3ocKE8GMVaXVlNH3IyyZmuwan0aTQv6YQ_003D _0023_003Dzd2Xq33m9lJH)
		{
			analyticSurf = _0023_003DzsoFK58B3HjgYT3zQ2RQf2N4_003D(_0023_003Dzd2Xq33m9lJH, _0023_003DzPx2oAYw_003D);
		}
		else if (_0023_003DzPx2oAYw_003D[index] is _0023_003DzfDpAK59ydJjjoyL2Yh_q4HLkc9bx82zcUjw_9FsJK2JXGYdzuKEWaoI_003D _0023_003Dzly3gky7Zyz3c)
		{
			analyticSurf = _0023_003Dz1bQWO_0024LpHypWghiDoArTGPqRVIJZrEd2OA_003D_003D(_0023_003Dzly3gky7Zyz3c, _0023_003DzPx2oAYw_003D);
		}
		else if (_0023_003DzPx2oAYw_003D[index] is _0023_003DzvRv2q7rL_0024ZnoPvAjrfwD6WnhKv4_00240RnC93FJKB2l87_0024PrYvxiw_003D_003D _0023_003Dz3wbIzZl6AuEd)
		{
			analyticSurf = _0023_003DzNTXd6oZNjDX7UvvsSjMjy7hXwLzm(_0023_003Dz3wbIzZl6AuEd, _0023_003DzPx2oAYw_003D);
		}
		else if (_0023_003DzPx2oAYw_003D[index] is _0023_003DzgRGydxI0js4H2FiOzNOIWEvotJMyjEeDqqICnCrzpRPU _0023_003DzY6dQ0sDLaAwi)
		{
			analyticSurf = _0023_003DzM39uPsJ4jIZ5MaemPd6va53xELtO(_0023_003DzY6dQ0sDLaAwi, _0023_003DzPx2oAYw_003D);
		}
		else if (_0023_003DzPx2oAYw_003D[index] is _0023_003DzzTCaZbrp3S0YNBiuIm4zwWRKyXGhqoSnJfApr9Zao2Py _0023_003DzM7F_TYhUOc5cKKxqKQ_003D_003D)
		{
			analyticSurf = _0023_003DzpBvXdCxk_J2AWWgxPWiJqkfxqGGe(_0023_003DzM7F_TYhUOc5cKKxqKQ_003D_003D, _0023_003DzPx2oAYw_003D);
		}
		else if (_0023_003DzPx2oAYw_003D[index] is _0023_003DzfSAHMZkL2hJuTBQQ4L7dNUFzt0xFD2jPM7XhiwU_003D _0023_003Dz6P7ZdNYd79JO)
		{
			analyticSurf = _0023_003DzZ5pZzkT8owVq5u947eawanY_003D(_0023_003Dz6P7ZdNYd79JO, _0023_003DzPx2oAYw_003D);
		}
		if (analyticSurf != null)
		{
			analyticSurf.TranslationID = new TranslationIdentifier(_0023_003DzRvt6sMuksW0E._0023_003Dz5sR_By0gsufq());
		}
		return analyticSurf;
	}

	private AnalyticSurf _0023_003Dzr9aYUeg2qPMPZLtxPfTkGQhsLNsD(_0023_003DzYkQVv2Lb0egyGZnzeO8ydkyFt0lDEhHA4uvG2TxpWX6vfM3gdg_003D_003D _0023_003DzXoiDdkk_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
	{
		_0023_003DzCDSdDaukKIfQIKuoRosZ3NAKyMQ1WGSxOA_003D_003D _0023_003Dzai52pbTwii_b = (_0023_003DzCDSdDaukKIfQIKuoRosZ3NAKyMQ1WGSxOA_003D_003D)_0023_003DzPx2oAYw_003D[_0023_003DzXoiDdkk_003D._0023_003Dzj8HzIw4_003D / 2];
		ICurve curve = (ICurve)_0023_003DzcvG8EU4_003D(_0023_003Dzai52pbTwii_b);
		ICurve _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D = _0023_003Dz4qecmD8_003D(_0023_003DzXoiDdkk_003D._0023_003DzpxrNf4Rfmd8jofaeIA_003D_003D / 2, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
		RevolvedSurf result = null;
		if (_0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D != null)
		{
			Vector3D vector3D = new Vector3D(curve.StartPoint, curve.EndPoint);
			vector3D.Normalize();
			Utility._0023_003Dz1zSJGNpo0_0024Y5ZWKOCw_003D_003D(curve.StartPoint, vector3D, ref _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D, out var _0023_003DzcgQS2OJJ2x_L, out var _);
			result = new RevolvedSurf(curve.StartPoint, vector3D, _0023_003DzcgQS2OJJ2x_L, _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D);
		}
		return result;
	}

	private AnalyticSurf _0023_003DzBg6w7EQVRtkIDANkZYN9EriDhAtu(_0023_003DzZXHZ8r_AKGbCsLnm7EUe1w_00244EG0i1nNAEdrGUvzdztgO _0023_003DzSiZudnyXU7Mi, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
	{
		_0023_003DzPx2oAYw_003D[_0023_003DzSiZudnyXU7Mi._0023_003Dz_1B0u_0024QGxn8N4MzzCQ_003D_003D / 2]._0023_003Dzpn1mgp22lvip(_0023_003DzPzO_0024GUk_003D: false);
		ICurve curve = _0023_003Dz4qecmD8_003D(_0023_003DzSiZudnyXU7Mi._0023_003Dz_1B0u_0024QGxn8N4MzzCQ_003D_003D / 2, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
		if (curve != null)
		{
			Vector3D vector3D = Vector3D.Subtract(_0023_003DzSiZudnyXU7Mi._0023_003DzvGsrDggBwGw4LNH_a5ILYSI_003D, curve.StartPoint);
			if (vector3D.IsZero)
			{
				vector3D = Vector3D.AxisZ;
			}
			return new TabulatedSurf(curve, vector3D);
		}
		return null;
	}

	private AnalyticSurf _0023_003DzsoFK58B3HjgYT3zQ2RQf2N4_003D(_0023_003Dz33gUjy3ocKE8GMVaXVlNH3IyyZmuwan0aTQv6YQ_003D _0023_003Dzd2Xq33m9lJH5, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D)
	{
		Plane plane = _0023_003Dzd2Xq33m9lJH5._0023_003DzNY5YUv279_SW(_0023_003DzPx2oAYw_003D);
		return new PlanarSurf(plane.Origin, plane.AxisZ, plane.AxisX, _0023_003Dzd2Xq33m9lJH5._0023_003Dz5sR_By0gsufq());
	}

	private Surface _0023_003DzOjMB_0024_0024ObznX9uoGt4A_003D_003D(_0023_003Dz33gUjy3ocKE8GMVaXVlNH3IyyZmuwan0aTQv6YQ_003D _0023_003Dzd2Xq33m9lJH5, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, ICurve[] _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D)
	{
		Plane pln = _0023_003Dzd2Xq33m9lJH5._0023_003DzNY5YUv279_SW(_0023_003DzPx2oAYw_003D);
		return new devDept.Eyeshot.Entities.Region(_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D, pln, sortAndOrient: true).ConvertToSurface();
	}

	private Surface _0023_003DzOjMB_0024_0024ObznX9uoGt4A_003D_003D(_0023_003DzOK_wIuCG_0024L33RaVzjK4JLUKKO_p4pq_0024by5YYyrY_003D _0023_003Dzd2Xq33m9lJH5, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, IList<ICurve> _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D, Point3D _0023_003DzeoY7iyo_003D)
	{
		Plane plane = _0023_003Dzd2Xq33m9lJH5._0023_003DzNY5YUv279_SW();
		if (_0023_003DzeoY7iyo_003D != null)
		{
			plane.Origin = _0023_003DzeoY7iyo_003D;
		}
		else
		{
			Point2D pt = plane.Project(_0023_003Dzd2Xq33m9lJH5._0023_003Dzc5c05Yz8iyPS);
			plane.Origin = plane.PointAt(pt);
		}
		return new devDept.Eyeshot.Entities.Region(_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D, plane, sortAndOrient: true).ConvertToSurface();
	}

	private AnalyticSurf _0023_003Dz1bQWO_0024LpHypWghiDoArTGPqRVIJZrEd2OA_003D_003D(_0023_003DzfDpAK59ydJjjoyL2Yh_q4HLkc9bx82zcUjw_9FsJK2JXGYdzuKEWaoI_003D _0023_003Dzly3gky7Zyz3c, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D)
	{
		if (_0023_003Dzly3gky7Zyz3c._0023_003DzgeIy8kQSNZ64() == 1)
		{
			_0023_003Dzly3gky7Zyz3c._0023_003DzEt7rVh0_003D(_0023_003DzPx2oAYw_003D, out var _0023_003DzCGTSeY0_003D, out var _0023_003DzxuJqjrs_003D, out var _0023_003DzcgQS2OJJ2x_L, out var _0023_003DzEGKj_0024SNUUihi);
			return new CylindricalSurf(_0023_003DzCGTSeY0_003D, _0023_003DzxuJqjrs_003D, _0023_003DzcgQS2OJJ2x_L, _0023_003DzEGKj_0024SNUUihi, _0023_003Dzly3gky7Zyz3c._0023_003Dz5sR_By0gsufq());
		}
		return null;
	}

	private AnalyticSurf _0023_003DzNTXd6oZNjDX7UvvsSjMjy7hXwLzm(_0023_003DzvRv2q7rL_0024ZnoPvAjrfwD6WnhKv4_00240RnC93FJKB2l87_0024PrYvxiw_003D_003D _0023_003Dz3wbIzZl6AuEd, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D)
	{
		if (_0023_003Dz3wbIzZl6AuEd._0023_003DzgeIy8kQSNZ64() == 1)
		{
			_0023_003Dz3wbIzZl6AuEd._0023_003DzEt7rVh0_003D(_0023_003DzPx2oAYw_003D, out var _0023_003DzCGTSeY0_003D, out var _0023_003DzxuJqjrs_003D, out var _0023_003DzcgQS2OJJ2x_L, out var _0023_003DzEGKj_0024SNUUihi, out var _0023_003DzRirVIphRT_mQ);
			return new ConicalSurf(_0023_003DzCGTSeY0_003D, _0023_003DzxuJqjrs_003D, _0023_003DzcgQS2OJJ2x_L, _0023_003DzEGKj_0024SNUUihi, _0023_003DzRirVIphRT_mQ, _0023_003Dz3wbIzZl6AuEd._0023_003Dz5sR_By0gsufq());
		}
		return null;
	}

	private AnalyticSurf _0023_003DzM39uPsJ4jIZ5MaemPd6va53xELtO(_0023_003DzgRGydxI0js4H2FiOzNOIWEvotJMyjEeDqqICnCrzpRPU _0023_003DzY6dQ0sDLaAwi, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D)
	{
		if (_0023_003DzY6dQ0sDLaAwi._0023_003DzgeIy8kQSNZ64() == 1)
		{
			_0023_003DzY6dQ0sDLaAwi._0023_003DzEt7rVh0_003D(_0023_003DzPx2oAYw_003D, out var _0023_003DzCGTSeY0_003D, out var _0023_003DzxuJqjrs_003D, out var _0023_003DzcgQS2OJJ2x_L, out var _0023_003DzA_8ilLvuROi, out var _0023_003DzZonw8nQGtIca);
			return new ToroidalSurf(_0023_003DzCGTSeY0_003D, _0023_003DzxuJqjrs_003D, _0023_003DzcgQS2OJJ2x_L, _0023_003DzA_8ilLvuROi, _0023_003DzZonw8nQGtIca, _0023_003DzY6dQ0sDLaAwi._0023_003Dz5sR_By0gsufq());
		}
		return null;
	}

	private AnalyticSurf _0023_003DzpBvXdCxk_J2AWWgxPWiJqkfxqGGe(_0023_003DzzTCaZbrp3S0YNBiuIm4zwWRKyXGhqoSnJfApr9Zao2Py _0023_003DzM7F_TYhUOc5cKKxqKQ_003D_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D)
	{
		if (_0023_003DzM7F_TYhUOc5cKKxqKQ_003D_003D._0023_003DzgeIy8kQSNZ64() == 1)
		{
			_0023_003DzM7F_TYhUOc5cKKxqKQ_003D_003D._0023_003DzEt7rVh0_003D(_0023_003DzPx2oAYw_003D, out var _0023_003DzCGTSeY0_003D, out var _0023_003DzxuJqjrs_003D, out var _0023_003DzcgQS2OJJ2x_L, out var _0023_003DzEGKj_0024SNUUihi);
			return new SphericalSurf(_0023_003DzCGTSeY0_003D, _0023_003DzxuJqjrs_003D, _0023_003DzcgQS2OJJ2x_L, _0023_003DzEGKj_0024SNUUihi, _0023_003DzM7F_TYhUOc5cKKxqKQ_003D_003D._0023_003Dz5sR_By0gsufq());
		}
		return null;
	}

	private AnalyticSurf _0023_003DzZ5pZzkT8owVq5u947eawanY_003D(_0023_003DzfSAHMZkL2hJuTBQQ4L7dNUFzt0xFD2jPM7XhiwU_003D _0023_003Dz6P7ZdNYd79JO, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D)
	{
		Surface surface = (Surface)_0023_003Dzj3FaN9YUcumw(_0023_003Dz6P7ZdNYd79JO, _0023_003DzPx2oAYw_003D, null, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D: false);
		return new NurbsSurf(surface.DegreeU, surface.KnotVectorU, surface.DegreeV, surface.KnotVectorV, surface.ControlPoints, _0023_003Dz6P7ZdNYd79JO._0023_003Dz5sR_By0gsufq());
	}

	private Entity _0023_003Dzj3FaN9YUcumw(_0023_003DzfSAHMZkL2hJuTBQQ4L7dNUFzt0xFD2jPM7XhiwU_003D _0023_003Dz6P7ZdNYd79JO, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
	{
		Surface surface = (Surface)_0023_003Dz3u_0Ozo_003D(_0023_003DzPx2oAYw_003D[_0023_003Dz6P7ZdNYd79JO._0023_003DzpT6ZqTI_003D / 2], _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
		Vector3D u = surface.NormalAt(surface.DomainU.Mid, surface.DomainV.Mid);
		double num = -1.0;
		if (Vector3D.AreCoincident(u, _0023_003Dz6P7ZdNYd79JO._0023_003Dzeu3WOZp7_rqZ, 0.1))
		{
			num = 1.0;
		}
		else if (Vector3D.AreCoincident(surface.NormalAt(0.0, 0.0), _0023_003Dz6P7ZdNYd79JO._0023_003Dzeu3WOZp7_rqZ, 0.1))
		{
			num = 1.0;
		}
		double tol = surface.ControlBoundingBox().Diagonal * Utility._0023_003Dzjyaz_Vfaky9X;
		surface.Offset(_0023_003Dz6P7ZdNYd79JO._0023_003DzYUMqwZQ_003D * num, tol, out var offsetSurf);
		return offsetSurf;
	}

	private Entity _0023_003DzwSe2pbzs4m_FEnsmX9mjyfU_003D(_0023_003DzOKQiiYVsLKx6c65wwxfwYTu0ENOXS1pHlaJUbq8QGC1LOQs_0024LQ_003D_003D _0023_003DzndgQYaKOzL4PELsQLg_003D_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D)
	{
		_0023_003DzndgQYaKOzL4PELsQLg_003D_003D._0023_003DzEt7rVh0_003D(out var _0023_003DzEKSHIVc_003D, out var _0023_003DzNDQ_E88_003D, out var _0023_003Dz1v6oPQk_003D);
		if (_0023_003DzEKSHIVc_003D != 3)
		{
			return null;
		}
		ICurve[] array = new ICurve[_0023_003Dz1v6oPQk_003D.Length];
		for (int i = 0; i < _0023_003Dz1v6oPQk_003D.Length; i++)
		{
			array[i] = new Curve(_0023_003DzEKSHIVc_003D, _0023_003DzNDQ_E88_003D[i + 1] - _0023_003DzNDQ_E88_003D[i], _0023_003Dz1v6oPQk_003D[i]);
		}
		Curve curve = Curve.Merge(array, clean: false);
		if (_0023_003DzndgQYaKOzL4PELsQLg_003D_003D._0023_003Dztfry3Xjye35X != -1)
		{
			_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D _0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D2 = (_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D)_0023_003DzPx2oAYw_003D[_0023_003DzndgQYaKOzL4PELsQLg_003D_003D._0023_003Dztfry3Xjye35X / 2];
			curve.TransformBy(_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D2._0023_003DzKJgErG0_003D());
		}
		return curve;
	}

	private Entity _0023_003Dz82Xl2kzzoDOv5FfvGviVg5s_003D(_0023_003Dz3Zx4KFlYXhE6x5ocfLkICI9BSGRZVvqe1SYkVItmXGYVkWg25w_003D_003D _0023_003DzVrJ2wtLTlBcEUy9Luw_003D_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D)
	{
		_0023_003DzVrJ2wtLTlBcEUy9Luw_003D_003D._0023_003DzEt7rVh0_003D(out var _0023_003DzEKSHIVc_003D, out var _0023_003Dze_Mokvc_003D, out var _0023_003DzH_9cnwY_003D, out var _0023_003Dz1v6oPQk_003D);
		if (_0023_003DzEKSHIVc_003D != 3)
		{
			return null;
		}
		Surface[] array = new Surface[_0023_003Dz1v6oPQk_003D.GetLength(0)];
		for (int i = 0; i < array.Length; i++)
		{
			Surface[] array2 = new Surface[_0023_003Dz1v6oPQk_003D.GetLength(1)];
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = new Surface(_0023_003DzEKSHIVc_003D, _0023_003Dze_Mokvc_003D[i + 1] - _0023_003Dze_Mokvc_003D[i], _0023_003DzH_9cnwY_003D[j + 1] - _0023_003DzH_9cnwY_003D[j], _0023_003Dz1v6oPQk_003D[i, j]);
				array2[j].KnotVectorU.Offset(_0023_003Dze_Mokvc_003D[i]);
				array2[j].KnotVectorV.Offset(_0023_003DzH_9cnwY_003D[j]);
			}
			if (array2[0] != null)
			{
				array[i] = Surface._0023_003DzY82zMQY_003D(array2);
			}
		}
		Surface surface = Surface._0023_003DzjzHI9A4_003D(array);
		if (_0023_003DzVrJ2wtLTlBcEUy9Luw_003D_003D._0023_003Dztfry3Xjye35X != -1)
		{
			_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D _0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D2 = (_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D)_0023_003DzPx2oAYw_003D[_0023_003DzVrJ2wtLTlBcEUy9Luw_003D_003D._0023_003Dztfry3Xjye35X / 2];
			surface.TransformBy(_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D2._0023_003DzKJgErG0_003D());
		}
		return surface;
	}

	private Entity _0023_003DztIc79mb2zQ0f(_0023_003DzOK_wIuCG_0024L33RaVzjK4JLUKKO_p4pq_0024by5YYyrY_003D _0023_003DzDzSF2oQdE9O8IsEUOA_003D_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
	{
		_0023_003DzDzSF2oQdE9O8IsEUOA_003D_003D._0023_003Dz_oTa5etYnxbmzrLwqRFtndA_003D(out var _0023_003DzjbqS1qE_003D, out var _0023_003Dz1v6oPQk_003D, out var _0023_003Dzt_m8zV0_003D, out var _0023_003DzXrexKjY_003D);
		Plane plane;
		try
		{
			plane = new Plane(new double[4]
			{
				_0023_003DzjbqS1qE_003D,
				_0023_003Dz1v6oPQk_003D,
				_0023_003Dzt_m8zV0_003D,
				0.0 - _0023_003DzXrexKjY_003D
			});
		}
		catch (Exception)
		{
			return null;
		}
		Point2D pt = plane.Project(_0023_003DzDzSF2oQdE9O8IsEUOA_003D_003D._0023_003Dzc5c05Yz8iyPS);
		plane.Origin = plane.PointAt(pt);
		if (_0023_003DzDzSF2oQdE9O8IsEUOA_003D_003D._0023_003DzfSYnO55OkU6S > 0)
		{
			ICurve _0023_003Dz_SqBXz8_003D = (ICurve)_0023_003Dz3u_0Ozo_003D(_0023_003DzPx2oAYw_003D[_0023_003DzDzSF2oQdE9O8IsEUOA_003D_003D._0023_003DzfSYnO55OkU6S / 2], _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
			_0023_003DzDzSF2oQdE9O8IsEUOA_003D_003D._0023_003Dz8zY9BC8xZ2uB(_0023_003DzDzSF2oQdE9O8IsEUOA_003D_003D._0023_003DzfSYnO55OkU6S, _0023_003DzPx2oAYw_003D);
			PlanarSurface planarSurface = Surface._0023_003Dz7Bh67pM_003D(plane, _0023_003Dz_SqBXz8_003D, null, _0023_003DzeyKgREVnRl_0024T8dZhnQ_003D_003D: true);
			if (planarSurface != null)
			{
				return planarSurface;
			}
			return null;
		}
		return new PlanarEntity(plane)
		{
			SymbolSize = ((_0023_003DzDzSF2oQdE9O8IsEUOA_003D_003D._0023_003DzYNYzg64_003D > 0f) ? _0023_003DzDzSF2oQdE9O8IsEUOA_003D_003D._0023_003DzYNYzg64_003D : 10f)
		};
	}

	private Entity _0023_003DzYW8_fbk_003D(_0023_003Dz_Q4HKPwuFf6e2QQ1OJd0reHy3bQkmQVBhQ_003D_003D _0023_003DzbJPraLv4V_0024bL, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
	{
		return new devDept.Eyeshot.Entities.Point(_0023_003DzbJPraLv4V_0024bL._0023_003DzmsFOmgLmb_0024Md(), 4f);
	}

	private Layer _0023_003Dzgmai7CQ_003D(_0023_003DzWPy7Mq_LyWeTazTXtajtCZ8FDawgWm5p_A_003D_003D _0023_003DzqoHxF0k_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, out int _0023_003DzyzK8swU_003D)
	{
		_0023_003DzyzK8swU_003D = 0;
		if (_0023_003DzqoHxF0k_003D._0023_003Dzd4U12fI_003D == null)
		{
			return null;
		}
		string text = (string)_0023_003DzqoHxF0k_003D._0023_003Dzd4U12fI_003D[0];
		if (!string.IsNullOrEmpty(text) && text.All(char.IsDigit))
		{
			_0023_003DzyzK8swU_003D = Convert.ToInt32(text);
		}
		if (_0023_003DzqoHxF0k_003D._0023_003DzpsRKBgeDZGw4 != 0 && _0023_003DzPx2oAYw_003D[-_0023_003DzqoHxF0k_003D._0023_003DzpsRKBgeDZGw4 / 2] is _0023_003DzoMowD04mt4vKC4cSDkFRUr_dj0yUGXqXlA_003D_003D)
		{
			_0023_003DzoMowD04mt4vKC4cSDkFRUr_dj0yUGXqXlA_003D_003D _0023_003DzoMowD04mt4vKC4cSDkFRUr_dj0yUGXqXlA_003D_003D2 = (_0023_003DzoMowD04mt4vKC4cSDkFRUr_dj0yUGXqXlA_003D_003D)_0023_003DzPx2oAYw_003D[-_0023_003DzqoHxF0k_003D._0023_003DzpsRKBgeDZGw4 / 2];
			return new Layer((string)_0023_003DzqoHxF0k_003D._0023_003Dzd4U12fI_003D[1], _0023_003DzoMowD04mt4vKC4cSDkFRUr_dj0yUGXqXlA_003D_003D2._0023_003Dz_8C3BH8_003D(), visible: true);
		}
		return new Layer((string)_0023_003DzqoHxF0k_003D._0023_003Dzd4U12fI_003D[1]);
	}

	private Entity _0023_003DzxA_O8FPlnPZiA0oSyw_003D_003D(_0023_003Dz9lwBHA7NoLh_0024_1EVuspU6hmh4G7BX3ZcrScNn8k_003D _0023_003DzndgQYaKOzL4PELsQLg_003D_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
	{
		_0023_003DzndgQYaKOzL4PELsQLg_003D_003D._0023_003DzxrFLKhzDBBuS(out var _0023_003DzU7eDCS_XZhhv, out var _0023_003Dzr7tgnwG7XK6N, out var _0023_003DzR6JvypoMiEFQ, out var _0023_003Dzuoh5ls4_003D, out var _0023_003DzeCrT36Y_003D);
		Curve curve;
		try
		{
			if (_0023_003DzU7eDCS_XZhhv == 1)
			{
				List<Point4D> _0023_003DzVd4T4pWAPybG;
				List<double> _0023_003Dz7rPmi3kL47vx1byWP4uEEf0_003D;
				bool flag = _0023_003Dz9lwBHA7NoLh_0024_1EVuspU6hmh4G7BX3ZcrScNn8k_003D._0023_003DzOq_CSAk_003D(_0023_003DzR6JvypoMiEFQ, out _0023_003DzVd4T4pWAPybG, out _0023_003Dz7rPmi3kL47vx1byWP4uEEf0_003D);
				if (_0023_003DzVd4T4pWAPybG.Count == 1)
				{
					return new devDept.Eyeshot.Entities.Point(_0023_003DzVd4T4pWAPybG[0]);
				}
				curve = ((!flag) ? new Curve(_0023_003DzU7eDCS_XZhhv, _0023_003Dzr7tgnwG7XK6N, _0023_003DzR6JvypoMiEFQ) : new Curve(_0023_003DzU7eDCS_XZhhv, _0023_003Dz7rPmi3kL47vx1byWP4uEEf0_003D.ToArray(), _0023_003DzVd4T4pWAPybG.ToArray()));
			}
			else
			{
				int num = _0023_003Dzr7tgnwG7XK6N.Length;
				int num2 = _0023_003DzR6JvypoMiEFQ.Length;
				if (_0023_003Dzr7tgnwG7XK6N != null && _0023_003DzR6JvypoMiEFQ != null && num2 + _0023_003DzU7eDCS_XZhhv + 1 == num)
				{
					_0023_003DzndgQYaKOzL4PELsQLg_003D_003D._0023_003DzmbHlV_Dx_0024WKM5n0f6Cpt3SY_003D(_0023_003DzU7eDCS_XZhhv, ref _0023_003Dzr7tgnwG7XK6N, ref _0023_003DzR6JvypoMiEFQ);
					num = _0023_003Dzr7tgnwG7XK6N.Length;
					num2 = _0023_003DzR6JvypoMiEFQ.Length;
				}
				double[] array = new double[num];
				Array.Copy(_0023_003Dzr7tgnwG7XK6N, array, num);
				Point4D[] array2 = new Point4D[num2];
				Array.Copy(_0023_003DzR6JvypoMiEFQ, array2, num2);
				curve = new Curve(_0023_003DzU7eDCS_XZhhv, array, array2);
			}
		}
		catch (Exception)
		{
			return null;
		}
		if (curve.SubCurve(_0023_003Dzuoh5ls4_003D, _0023_003DzeCrT36Y_003D, out var sub))
		{
			curve = (Curve)sub;
		}
		if (_0023_003DzndgQYaKOzL4PELsQLg_003D_003D._0023_003Dztfry3Xjye35X != -1)
		{
			_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D _0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D2 = (_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D)_0023_003DzPx2oAYw_003D[_0023_003DzndgQYaKOzL4PELsQLg_003D_003D._0023_003Dztfry3Xjye35X / 2];
			curve.TransformBy(_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D2._0023_003DzKJgErG0_003D());
		}
		return curve;
	}

	private Entity _0023_003Dzw1MXR6bwhEwbx8GL2A_003D_003D(_0023_003Dz_ZR_60g8KTZpV15NG_0024gJ1cZ3Q9yL1UXPtzY9x8s_003D _0023_003DzVrJ2wtLTlBcEUy9Luw_003D_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
	{
		_0023_003DzVrJ2wtLTlBcEUy9Luw_003D_003D._0023_003DzxrFLKhzDBBuS(out var _0023_003DzQuv3myvnehSV, out var _0023_003DzbTcvrXagsoun, out var _0023_003DzMNyEKNc_003D, out var _0023_003Dzo_0024bBi0E_003D, out var _0023_003DzR6JvypoMiEFQ);
		if (!_0023_003DzQuv3myvnehSV.IsValid(_0023_003DzMNyEKNc_003D))
		{
			for (int i = 1; i < _0023_003DzMNyEKNc_003D + 1; i++)
			{
				_0023_003DzQuv3myvnehSV[i] = _0023_003DzQuv3myvnehSV[0];
			}
			int num = _0023_003DzQuv3myvnehSV.Length;
			for (int j = 1; j < _0023_003DzMNyEKNc_003D + 1; j++)
			{
				_0023_003DzQuv3myvnehSV[num - 1 - j] = _0023_003DzQuv3myvnehSV[num - 1];
			}
		}
		if (!_0023_003DzbTcvrXagsoun.IsValid(_0023_003Dzo_0024bBi0E_003D))
		{
			for (int k = 1; k < _0023_003Dzo_0024bBi0E_003D + 1; k++)
			{
				_0023_003DzbTcvrXagsoun[k] = _0023_003DzbTcvrXagsoun[0];
			}
			int num2 = _0023_003DzbTcvrXagsoun.Length;
			for (int l = 1; l < _0023_003Dzo_0024bBi0E_003D + 1; l++)
			{
				_0023_003DzbTcvrXagsoun[num2 - 1 - l] = _0023_003DzbTcvrXagsoun[num2 - 1];
			}
		}
		Surface surface = new Surface(_0023_003DzMNyEKNc_003D, _0023_003DzQuv3myvnehSV, _0023_003Dzo_0024bBi0E_003D, _0023_003DzbTcvrXagsoun, _0023_003DzR6JvypoMiEFQ);
		if (_0023_003DzVrJ2wtLTlBcEUy9Luw_003D_003D._0023_003Dztfry3Xjye35X != -1)
		{
			_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D _0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D2 = _0023_003DzPx2oAYw_003D[_0023_003DzVrJ2wtLTlBcEUy9Luw_003D_003D._0023_003Dztfry3Xjye35X / 2] as _0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D;
			surface.TransformBy(_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D2._0023_003DzKJgErG0_003D());
		}
		return surface;
	}

	private Entity _0023_003DzB0jfGh4_003D(_0023_003DzF5p_8NJ3PUm7nyvOOwDz4l_0024pwTFYmB_e_0024Q_003D_003D _0023_003DzIamx_OpEEKK1, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
	{
		Brep.Face[] array = null;
		List<Point3D> list = new List<Point3D>();
		List<Brep.Edge> list2 = new List<Brep.Edge>();
		Dictionary<KeyValuePair<int, int>, int> _0023_003DzJy4cO6zhkT9q = new Dictionary<KeyValuePair<int, int>, int>();
		Dictionary<KeyValuePair<int, int>, int> _0023_003DzEpQ1TCYZhfGc = new Dictionary<KeyValuePair<int, int>, int>();
		array = _0023_003DzQtScsQY_003D(_0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzIamx_OpEEKK1, _0023_003DzEpQ1TCYZhfGc, list2, 0, _0023_003DzJy4cO6zhkT9q, list);
		return new Brep(list.ToArray(), list2.ToArray(), array, _0023_003DzqMxdROkOZ2gG: false, null, _0023_003DzPPoX8HETqTZN: true, _0023_003DzMcq9hcRIFsnaUZ3PgA_003D_003D: true, log);
	}

	private Entity _0023_003Dz7KE37xnABuyx49gW6Kge05M_003D(_0023_003DzYkQVv2Lb0egyGZnzeO8ydkyFt0lDEhHA4uvG2TxpWX6vfM3gdg_003D_003D _0023_003DzXoiDdkk_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
	{
		_0023_003DzCDSdDaukKIfQIKuoRosZ3NAKyMQ1WGSxOA_003D_003D _0023_003Dzai52pbTwii_b = (_0023_003DzCDSdDaukKIfQIKuoRosZ3NAKyMQ1WGSxOA_003D_003D)_0023_003DzPx2oAYw_003D[_0023_003DzXoiDdkk_003D._0023_003Dzj8HzIw4_003D / 2];
		ICurve curve = (ICurve)_0023_003DzcvG8EU4_003D(_0023_003Dzai52pbTwii_b);
		ICurve curve2 = _0023_003Dz4qecmD8_003D(_0023_003DzXoiDdkk_003D._0023_003DzpxrNf4Rfmd8jofaeIA_003D_003D / 2, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
		Surface surface = null;
		if (curve2 != null && !curve.IsPoint && !curve2.IsPoint)
		{
			double num = _0023_003DzXoiDdkk_003D._0023_003DzAaNmsgPUUEpl - _0023_003DzXoiDdkk_003D._0023_003Dz3veEI49c6b6Q;
			if (num < Utility._0023_003DzxhnLabVjXjPg)
			{
				return null;
			}
			surface = curve2.RevolveAsSurface(_0023_003DzXoiDdkk_003D._0023_003Dz3veEI49c6b6Q, num, curve.StartPoint, curve.EndPoint)[0];
			if (num < 0.0)
			{
				surface.ReverseU();
			}
			_0023_003Dz_WsQhfBtykCB(curve2, curve, surface);
		}
		if (surface != null && _0023_003DzXoiDdkk_003D._0023_003Dztfry3Xjye35X != -1)
		{
			_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D _0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D2 = (_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D)_0023_003DzPx2oAYw_003D[_0023_003DzXoiDdkk_003D._0023_003Dztfry3Xjye35X / 2];
			surface.TransformBy(_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D2._0023_003DzKJgErG0_003D());
		}
		return surface;
	}

	private static void _0023_003Dz_WsQhfBtykCB(ICurve _0023_003DzhyZURwQ_003D, ICurve _0023_003DzxuJqjrs_003D, Surface _0023_003DzAI_Szwk_003D)
	{
		if (_0023_003DzhyZURwQ_003D is Circle circle && _0023_003DzhyZURwQ_003D.IsClosed)
		{
			Segment3D seg = new Segment3D(_0023_003DzxuJqjrs_003D.StartPoint, _0023_003DzxuJqjrs_003D.EndPoint);
			Point3D point3D = circle.Center.ProjectTo(seg);
			if (point3D != circle.Center)
			{
				Plane _0023_003Dzrgqz890sj_0024X = new Plane(_0023_003DzxuJqjrs_003D.StartPoint, _0023_003DzxuJqjrs_003D.TangentAt(0.0), new Vector3D(point3D, circle.Center));
				if (!Utility._0023_003DzinOQp4_qBUm4opZWpg_003D_003D(_0023_003DzhyZURwQ_003D, _0023_003Dzrgqz890sj_0024X))
				{
					_0023_003DzAI_Szwk_003D.ReverseU();
				}
			}
		}
		else if (_0023_003DzhyZURwQ_003D is Line line && Vector3D.AngleBetween(_0023_003DzxuJqjrs_003D.TangentAt(0.0), line.TangentAt(0.0)) > Math.PI / 2.0)
		{
			_0023_003DzAI_Szwk_003D.ReverseU();
		}
	}

	private Entity _0023_003Dz2DUNGblME139WCKkIg_003D_003D(_0023_003DzOKWbo7sUM8LpXGAfWbsy7u9_aoyf6rVNGlnjW9k_003D _0023_003Dzja3lgRPKmEukz9k6WQ_003D_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
	{
		Curve nurbsForm = _0023_003Dz4qecmD8_003D(_0023_003Dzja3lgRPKmEukz9k6WQ_003D_003D._0023_003DzYDUscu7y3FIv / 2, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D).GetNurbsForm();
		Curve nurbsForm2 = _0023_003Dz4qecmD8_003D(_0023_003Dzja3lgRPKmEukz9k6WQ_003D_003D._0023_003DzdxiNoIc0m7h4 / 2, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D).GetNurbsForm();
		Surface surface = null;
		if (nurbsForm != null && nurbsForm2 != null)
		{
			surface = Surface.Ruled(nurbsForm, nurbsForm2);
		}
		if (_0023_003Dzja3lgRPKmEukz9k6WQ_003D_003D._0023_003Dztfry3Xjye35X != -1)
		{
			_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D _0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D2 = _0023_003DzPx2oAYw_003D[_0023_003Dzja3lgRPKmEukz9k6WQ_003D_003D._0023_003Dztfry3Xjye35X / 2] as _0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D;
			surface.TransformBy(_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D2._0023_003DzKJgErG0_003D());
		}
		return surface;
	}

	private Entity _0023_003DzTn1Io6bUTPbREAlvaQ_0024Qpxg_003D(_0023_003DzZXHZ8r_AKGbCsLnm7EUe1w_00244EG0i1nNAEdrGUvzdztgO _0023_003DzPrZ0njs5O8eq, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
	{
		Entity entity = (Entity)_0023_003Dz4qecmD8_003D(_0023_003DzPrZ0njs5O8eq._0023_003Dz_1B0u_0024QGxn8N4MzzCQ_003D_003D / 2, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
		Surface surface = null;
		if (entity != null)
		{
			ICurve curve = (ICurve)entity;
			Vector3D vector3D = Vector3D.Subtract(_0023_003DzPrZ0njs5O8eq._0023_003DzvGsrDggBwGw4LNH_a5ILYSI_003D, curve.StartPoint);
			if (vector3D.IsZero)
			{
				vector3D = Vector3D.AxisZ;
			}
			surface = curve.ExtrudeAsSurface(vector3D)[0];
		}
		if (_0023_003DzPrZ0njs5O8eq._0023_003Dztfry3Xjye35X != -1 && surface != null)
		{
			_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D _0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D2 = _0023_003DzPx2oAYw_003D[_0023_003DzPrZ0njs5O8eq._0023_003Dztfry3Xjye35X / 2] as _0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D;
			surface.TransformBy(_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D2._0023_003DzKJgErG0_003D());
		}
		return surface;
	}

	private Entity _0023_003Dz7GUtagUMsPmy2lyWGHToiio_003D(_0023_003DzOqrWHudzVp1v35H_vsK2gKOjnxqMkRli9ie5GLqoLH7QYRVcuQ_003D_003D _0023_003DzJ9ODgxjHN5qS, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
	{
		bool _0023_003Dz2QdpsV0_003D = false;
		Surface surface = _0023_003DzvO6aDbs_003D(_0023_003DzJ9ODgxjHN5qS._0023_003DzWuk5xhU5RfkzNR16ug_003D_003D / 2, _0023_003DzPx2oAYw_003D, _0023_003DzJ9ODgxjHN5qS._0023_003Dz5sR_By0gsufq(), _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
		if (surface != null)
		{
			Transformation _0023_003DzNDQ_E88_003D = null;
			if (_0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
			{
				Surface surface2 = surface._0023_003Dzp0FRH6E_003D(out _0023_003DzNDQ_E88_003D);
				if (surface2 != null)
				{
					surface = surface2;
				}
			}
			if (!_0023_003DzJ9ODgxjHN5qS._0023_003DzR9TO1Ls_003D)
			{
				return surface;
			}
			if (_0023_003DzJ9ODgxjHN5qS._0023_003DzHKMFfVMLflQgtot0kKM1pZVfFzLx > 0)
			{
				_0023_003DzBJElHqxtPPtMLXcUwpVKUEHLvZ15nURMw0JZlFU3Avjs4D9aLQ_003D_003D _0023_003DzBJElHqxtPPtMLXcUwpVKUEHLvZ15nURMw0JZlFU3Avjs4D9aLQ_003D_003D2 = (_0023_003DzBJElHqxtPPtMLXcUwpVKUEHLvZ15nURMw0JZlFU3Avjs4D9aLQ_003D_003D)_0023_003DzPx2oAYw_003D[_0023_003DzJ9ODgxjHN5qS._0023_003DzHKMFfVMLflQgtot0kKM1pZVfFzLx / 2];
				bool num = _0023_003DzBJElHqxtPPtMLXcUwpVKUEHLvZ15nURMw0JZlFU3Avjs4D9aLQ_003D_003D2._0023_003DzTu1d2PRuGw_0024QdS8_0024ocrlvvRUNKyp() == 0 && _0023_003DzBJElHqxtPPtMLXcUwpVKUEHLvZ15nURMw0JZlFU3Avjs4D9aLQ_003D_003D2._0023_003DzeuE1ByNmTKjpKEdw99BPgrk_003D() > 0;
				bool flag = _0023_003DzBJElHqxtPPtMLXcUwpVKUEHLvZ15nURMw0JZlFU3Avjs4D9aLQ_003D_003D2._0023_003DzeuE1ByNmTKjpKEdw99BPgrk_003D() > 0 && (surface is RevolvedSurface || surface is PlanarSurface || _0023_003DzPx2oAYw_003D[_0023_003DzJ9ODgxjHN5qS._0023_003DzWuk5xhU5RfkzNR16ug_003D_003D / 2] is _0023_003DzfSAHMZkL2hJuTBQQ4L7dNUFzt0xFD2jPM7XhiwU_003D);
				if (num || flag)
				{
					surface = _0023_003DzaoSRddSYV0_0024qlhevuw_003D_003D(_0023_003DzJ9ODgxjHN5qS, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzBJElHqxtPPtMLXcUwpVKUEHLvZ15nURMw0JZlFU3Avjs4D9aLQ_003D_003D2, surface, _0023_003Dz2QdpsV0_003D);
				}
				else
				{
					double diagonal = surface.ControlBoundingBox().Diagonal;
					_0023_003DzJ9ODgxjHN5qS._0023_003Dz8zY9BC8xZ2uB(_0023_003DzBJElHqxtPPtMLXcUwpVKUEHLvZ15nURMw0JZlFU3Avjs4D9aLQ_003D_003D2._0023_003DzTu1d2PRuGw_0024QdS8_0024ocrlvvRUNKyp(), _0023_003DzPx2oAYw_003D);
					ICurve curve = _0023_003DzI4DCMZY_003D(_0023_003DzBJElHqxtPPtMLXcUwpVKUEHLvZ15nURMw0JZlFU3Avjs4D9aLQ_003D_003D2._0023_003DzTu1d2PRuGw_0024QdS8_0024ocrlvvRUNKyp() / 2, _0023_003DzBJElHqxtPPtMLXcUwpVKUEHLvZ15nURMw0JZlFU3Avjs4D9aLQ_003D_003D2._0023_003DzeuE1ByNmTKjpKEdw99BPgrk_003D() / 2, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, surface, diagonal, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzNDQ_E88_003D);
					if (curve == null)
					{
						return null;
					}
					ICurve[] individualCurves = curve.GetIndividualCurves();
					if (individualCurves.Length == 0 || (_0023_003DzJ9ODgxjHN5qS._0023_003DzY2U_3leQ5kSw.Length == 0 && _0023_003Dz7bMUILkfG8P9W9cWvF5ZIz8_003D(surface, individualCurves)))
					{
						return surface;
					}
					bool flag2 = false;
					double _0023_003DzX0qX_IwWxysi = diagonal * Utility._0023_003Dzjyaz_Vfaky9X;
					if (surface is TabulatedSurface)
					{
						TrimCurve _0023_003DzRVoDPs0_003D = (TrimCurve)individualCurves[0];
						if (_0023_003DzLynpSIA_003D(_0023_003DzRVoDPs0_003D, surface, _0023_003DzX0qX_IwWxysi, individualCurves, out var _0023_003Dz13KtlVg_003D) != _0023_003Dz13KtlVg_003D)
						{
							TabulatedSurface tabulatedSurface = (TabulatedSurface)surface.Clone();
							tabulatedSurface.KnotVectorU.Scale(1.0 / tabulatedSurface.DomainU.Length);
							tabulatedSurface.KnotVectorU.Offset(0.0 - tabulatedSurface.DomainU.Low);
							tabulatedSurface.KnotVectorV.Scale(1.0 / tabulatedSurface.DomainV.Length);
							tabulatedSurface.KnotVectorV.Offset(0.0 - tabulatedSurface.DomainV.Low);
							if (_0023_003DzLynpSIA_003D(_0023_003DzRVoDPs0_003D, surface, _0023_003DzX0qX_IwWxysi, individualCurves, out _0023_003Dz13KtlVg_003D) != _0023_003Dz13KtlVg_003D)
							{
								surface = _0023_003DzaoSRddSYV0_0024qlhevuw_003D_003D(_0023_003DzJ9ODgxjHN5qS, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzBJElHqxtPPtMLXcUwpVKUEHLvZ15nURMw0JZlFU3Avjs4D9aLQ_003D_003D2, surface, _0023_003Dz2QdpsV0_003D);
								flag2 = true;
							}
							else
							{
								surface = tabulatedSurface;
							}
						}
					}
					if (!flag2)
					{
						List<ICurve> list = new List<ICurve>();
						if (curve != null)
						{
							list.Add(curve);
						}
						for (int i = 0; i < _0023_003DzJ9ODgxjHN5qS._0023_003DzY2U_3leQ5kSw.Length; i++)
						{
							int num2 = _0023_003DzJ9ODgxjHN5qS._0023_003DzY2U_3leQ5kSw[i];
							_0023_003DzBJElHqxtPPtMLXcUwpVKUEHLvZ15nURMw0JZlFU3Avjs4D9aLQ_003D_003D2 = (_0023_003DzBJElHqxtPPtMLXcUwpVKUEHLvZ15nURMw0JZlFU3Avjs4D9aLQ_003D_003D)_0023_003DzPx2oAYw_003D[num2 / 2];
							ICurve curve2 = _0023_003DzI4DCMZY_003D(_0023_003DzBJElHqxtPPtMLXcUwpVKUEHLvZ15nURMw0JZlFU3Avjs4D9aLQ_003D_003D2._0023_003DzTu1d2PRuGw_0024QdS8_0024ocrlvvRUNKyp() / 2, _0023_003DzBJElHqxtPPtMLXcUwpVKUEHLvZ15nURMw0JZlFU3Avjs4D9aLQ_003D_003D2._0023_003DzeuE1ByNmTKjpKEdw99BPgrk_003D() / 2, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, surface, diagonal, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzNDQ_E88_003D);
							if (curve2 != null)
							{
								list.Add(curve2);
							}
						}
						surface.Trimming = new devDept.Eyeshot.Entities.Region(list, Plane.XY, sortAndOrient: true);
						double num3 = diagonal * Utility._0023_003Dzjyaz_Vfaky9X;
						double num4 = num3 * num3;
						foreach (ICurve contour in surface.Trimming.ContourList)
						{
							ICurve[] individualCurves2 = contour.GetIndividualCurves();
							for (int j = 0; j < individualCurves2.Length; j++)
							{
								TrimCurve trimCurve = (TrimCurve)individualCurves2[j];
								if (trimCurve.Edge != null && !(trimCurve.Edge is devDept.Eyeshot.Entities.Point))
								{
									Point3D startPoint = trimCurve.StartPoint;
									Point3D endPoint = trimCurve.EndPoint;
									Point3D a = surface.Evaluate(startPoint.X, startPoint.Y);
									Point3D a2 = surface.Evaluate(endPoint.X, endPoint.Y);
									Point3D startPoint2 = trimCurve.Edge.StartPoint;
									Point3D endPoint2 = trimCurve.Edge.EndPoint;
									bool isClosed = trimCurve.Edge.IsClosed;
									if (Point3D.DistanceSquared(a, startPoint2) > num4 || Point3D.DistanceSquared(a2, endPoint2) > num4)
									{
										trimCurve.Edge = surface.LiftCurve(trimCurve, num3);
									}
									else if (isClosed)
									{
										double u = trimCurve.Domain.ParameterAt(1.0 / 3.0);
										Point3D point = surface.Evaluate(trimCurve.PointAt(u));
										trimCurve.Edge.Project(point, out var t);
										double u2 = trimCurve.Domain.ParameterAt(2.0 / 3.0);
										Point3D point2 = surface.Evaluate(trimCurve.PointAt(u2));
										trimCurve.Edge.Project(point2, out var t2);
										if (t > t2)
										{
											trimCurve.Edge.Reverse();
										}
									}
								}
								else
								{
									trimCurve.Edge = surface.LiftCurve(trimCurve, num3);
								}
							}
						}
					}
					if (!(surface is PlanarSurface))
					{
					}
				}
			}
		}
		else
		{
			if (!(_0023_003DzPx2oAYw_003D[_0023_003DzJ9ODgxjHN5qS._0023_003DzWuk5xhU5RfkzNR16ug_003D_003D / 2] is _0023_003DzOK_wIuCG_0024L33RaVzjK4JLUKKO_p4pq_0024by5YYyrY_003D _0023_003DzOK_wIuCG_0024L33RaVzjK4JLUKKO_p4pq_0024by5YYyrY_003D2))
			{
				return null;
			}
			_0023_003DzOK_wIuCG_0024L33RaVzjK4JLUKKO_p4pq_0024by5YYyrY_003D2._0023_003Dzpn1mgp22lvip(_0023_003DzPzO_0024GUk_003D: false);
			_0023_003DzBJElHqxtPPtMLXcUwpVKUEHLvZ15nURMw0JZlFU3Avjs4D9aLQ_003D_003D _0023_003DzBJElHqxtPPtMLXcUwpVKUEHLvZ15nURMw0JZlFU3Avjs4D9aLQ_003D_003D2 = (_0023_003DzBJElHqxtPPtMLXcUwpVKUEHLvZ15nURMw0JZlFU3Avjs4D9aLQ_003D_003D)_0023_003DzPx2oAYw_003D[_0023_003DzJ9ODgxjHN5qS._0023_003DzHKMFfVMLflQgtot0kKM1pZVfFzLx / 2];
			List<ICurve> list2 = new List<ICurve>(_0023_003DzJ9ODgxjHN5qS._0023_003DzY2U_3leQ5kSw.Length + 1);
			list2.Add(_0023_003DzEN300LZAEnsa(_0023_003DzBJElHqxtPPtMLXcUwpVKUEHLvZ15nURMw0JZlFU3Avjs4D9aLQ_003D_003D2._0023_003DzeuE1ByNmTKjpKEdw99BPgrk_003D() / 2, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003Dzjcx0hV4_003D: false, 0, null));
			for (int k = 0; k < _0023_003DzJ9ODgxjHN5qS._0023_003DzY2U_3leQ5kSw.Length; k++)
			{
				int num5 = _0023_003DzJ9ODgxjHN5qS._0023_003DzY2U_3leQ5kSw[k];
				_0023_003DzBJElHqxtPPtMLXcUwpVKUEHLvZ15nURMw0JZlFU3Avjs4D9aLQ_003D_003D2 = (_0023_003DzBJElHqxtPPtMLXcUwpVKUEHLvZ15nURMw0JZlFU3Avjs4D9aLQ_003D_003D)_0023_003DzPx2oAYw_003D[num5 / 2];
				ICurve curve3 = _0023_003DzEN300LZAEnsa(_0023_003DzBJElHqxtPPtMLXcUwpVKUEHLvZ15nURMw0JZlFU3Avjs4D9aLQ_003D_003D2._0023_003DzeuE1ByNmTKjpKEdw99BPgrk_003D() / 2, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003Dzjcx0hV4_003D: false, 0, null);
				if (curve3 != null)
				{
					list2.Add(curve3);
				}
			}
			foreach (ICurve item in list2)
			{
				if (item == null)
				{
					return null;
				}
			}
			surface = _0023_003DzOjMB_0024_0024ObznX9uoGt4A_003D_003D(_0023_003DzOK_wIuCG_0024L33RaVzjK4JLUKKO_p4pq_0024by5YYyrY_003D2, _0023_003DzPx2oAYw_003D, list2.ToArray(), list2[0].StartPoint);
		}
		return surface;
	}

	private Surface _0023_003DzaoSRddSYV0_0024qlhevuw_003D_003D(_0023_003DzOqrWHudzVp1v35H_vsK2gKOjnxqMkRli9ie5GLqoLH7QYRVcuQ_003D_003D _0023_003DzJ9ODgxjHN5qS, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003DzBJElHqxtPPtMLXcUwpVKUEHLvZ15nURMw0JZlFU3Avjs4D9aLQ_003D_003D _0023_003DzMTAUtkHhOPoO, Surface _0023_003DzAI_Szwk_003D, bool _0023_003Dz2QdpsV0_003D)
	{
		List<ICurve> list = new List<ICurve>();
		_0023_003DzJ9ODgxjHN5qS._0023_003Dz8zY9BC8xZ2uB(_0023_003DzMTAUtkHhOPoO._0023_003DzeuE1ByNmTKjpKEdw99BPgrk_003D(), _0023_003DzPx2oAYw_003D);
		bool _0023_003Dzjcx0hV4_003D = _0023_003DzAI_Szwk_003D is RevolvedSurface;
		ICurve curve = _0023_003DzEN300LZAEnsa(_0023_003DzMTAUtkHhOPoO._0023_003DzeuE1ByNmTKjpKEdw99BPgrk_003D() / 2, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003Dzjcx0hV4_003D, _0023_003DzMTAUtkHhOPoO._0023_003DzTu1d2PRuGw_0024QdS8_0024ocrlvvRUNKyp() / 2, _0023_003DzAI_Szwk_003D);
		if (curve != null)
		{
			list.Add(curve);
		}
		for (int i = 0; i < _0023_003DzJ9ODgxjHN5qS._0023_003DzY2U_3leQ5kSw.Length; i++)
		{
			int num = _0023_003DzJ9ODgxjHN5qS._0023_003DzY2U_3leQ5kSw[i];
			_0023_003DzMTAUtkHhOPoO = (_0023_003DzBJElHqxtPPtMLXcUwpVKUEHLvZ15nURMw0JZlFU3Avjs4D9aLQ_003D_003D)_0023_003DzPx2oAYw_003D[num / 2];
			ICurve curve2 = _0023_003DzEN300LZAEnsa(_0023_003DzMTAUtkHhOPoO._0023_003DzeuE1ByNmTKjpKEdw99BPgrk_003D() / 2, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, _0023_003Dzjcx0hV4_003D, _0023_003DzMTAUtkHhOPoO._0023_003DzTu1d2PRuGw_0024QdS8_0024ocrlvvRUNKyp() / 2, _0023_003DzAI_Szwk_003D);
			if (curve2 != null)
			{
				list.Add(curve2);
			}
		}
		Surface[] array;
		if (_0023_003DzAI_Szwk_003D is PlanarSurface)
		{
			devDept.Eyeshot.Entities.Region region = Surface._0023_003DzCaJhR_0024Jdhxn_0024lcMUgA_003D_003D(((PlanarSurface)_0023_003DzAI_Szwk_003D).Plane, list.ToArray());
			array = new Surface[1] { region.ConvertToSurface() };
		}
		else
		{
			if (_0023_003DzAI_Szwk_003D is RevolvedSurface)
			{
				RevolvedSurface revolvedSurface = (RevolvedSurface)_0023_003DzAI_Szwk_003D;
				if (Math.Abs(Math.PI * 2.0 - revolvedSurface.Angle.Length) < Utility._0023_003DzxhnLabVjXjPg && Utility._0023_003Dzci5nLHpbsxCiqme1Bg_003D_003D(revolvedSurface.Plane, list, revolvedSurface, out var _0023_003Dz6pajdGM_003D))
				{
					_0023_003DzAI_Szwk_003D.Rotate(_0023_003Dz6pajdGM_003D, revolvedSurface.Plane.AxisZ, revolvedSurface.Plane.Origin);
				}
			}
			array = Surface.DropLoops(_0023_003DzAI_Szwk_003D, list.ToArray(), log);
		}
		if (array != null && array.Length != 0)
		{
			_0023_003DzAI_Szwk_003D = array[0];
		}
		return _0023_003DzAI_Szwk_003D;
	}

	private ICurve _0023_003DzEN300LZAEnsa(int _0023_003DzaXtWw_0024E7gfA1VEcsMzSBB9E_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, bool _0023_003Dzjcx0hV4_003D, int _0023_003DzFH90AANUyIY75msvr3Mnapw_003D, Surface _0023_003Dz_0024KKopL9T7nzT)
	{
		if (!(_0023_003DzPx2oAYw_003D[_0023_003DzaXtWw_0024E7gfA1VEcsMzSBB9E_003D].GetType() == typeof(_0023_003Dzz6JIJ4xNe1_0024dIMT88uFZydqQ_0024upBYSTqB05jKFc_003D)))
		{
			if (_0023_003DzFH90AANUyIY75msvr3Mnapw_003D > 0)
			{
				_ = _0023_003DzPx2oAYw_003D[_0023_003DzFH90AANUyIY75msvr3Mnapw_003D];
			}
			ICurve curve = _0023_003Dz4qecmD8_003D(_0023_003DzaXtWw_0024E7gfA1VEcsMzSBB9E_003D, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
			if (curve is Curve)
			{
				ICurve[] array = ((Curve)curve).SplitAtDiscontinuities(speedChange: false);
				ICurve[] array2 = array;
				if (array2.Length > 1)
				{
					return new CompositeCurve(array2, sortAndOrient: false);
				}
			}
			return curve;
		}
		_0023_003Dzz6JIJ4xNe1_0024dIMT88uFZydqQ_0024upBYSTqB05jKFc_003D _0023_003Dzz6JIJ4xNe1_0024dIMT88uFZydqQ_0024upBYSTqB05jKFc_003D2 = (_0023_003Dzz6JIJ4xNe1_0024dIMT88uFZydqQ_0024upBYSTqB05jKFc_003D)_0023_003DzPx2oAYw_003D[_0023_003DzaXtWw_0024E7gfA1VEcsMzSBB9E_003D];
		if (_0023_003DzFH90AANUyIY75msvr3Mnapw_003D > 0)
		{
			_ = (_0023_003Dzz6JIJ4xNe1_0024dIMT88uFZydqQ_0024upBYSTqB05jKFc_003D)_0023_003DzPx2oAYw_003D[_0023_003DzFH90AANUyIY75msvr3Mnapw_003D];
		}
		int num = _0023_003Dzz6JIJ4xNe1_0024dIMT88uFZydqQ_0024upBYSTqB05jKFc_003D2._0023_003DzSBFamoYvOcVi().Length;
		ICurve[] array3 = new ICurve[num];
		for (int i = 0; i < num; i++)
		{
			array3[i] = _0023_003Dz4qecmD8_003D(_0023_003Dzz6JIJ4xNe1_0024dIMT88uFZydqQ_0024upBYSTqB05jKFc_003D2._0023_003DzSBFamoYvOcVi()[i] / 2, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
			if (array3[i] == null)
			{
				return null;
			}
		}
		if (num > 1)
		{
			return new CompositeCurve(array3, sortAndOrient: false);
		}
		return array3[0];
	}

	private ICurve _0023_003DzI4DCMZY_003D(int _0023_003DzFfwLVup7QWyS_0024l26KY8TTfw_003D, int _0023_003DzaXtWw_0024E7gfA1VEcsMzSBB9E_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, Surface _0023_003Dz_0024KKopL9T7nzT, double _0023_003DzccAR5G0_003D, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D, Transformation _0023_003Dz63vmKM0_003D)
	{
		if (_0023_003DzFfwLVup7QWyS_0024l26KY8TTfw_003D > _0023_003DzPx2oAYw_003D.Count - 1)
		{
			return null;
		}
		if (!(_0023_003DzPx2oAYw_003D[_0023_003DzFfwLVup7QWyS_0024l26KY8TTfw_003D].GetType() == typeof(_0023_003Dzz6JIJ4xNe1_0024dIMT88uFZydqQ_0024upBYSTqB05jKFc_003D)))
		{
			TrimCurve trimCurve = _0023_003DzmGgqdRaHiXdg(_0023_003DzFfwLVup7QWyS_0024l26KY8TTfw_003D, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003Dz_0024KKopL9T7nzT, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
			if (trimCurve == null)
			{
				return null;
			}
			if (_0023_003Dz63vmKM0_003D != null)
			{
				trimCurve.TransformBy(_0023_003Dz63vmKM0_003D);
			}
			ICurve[] array = trimCurve.SplitAtDiscontinuities(speedChange: false);
			ICurve[] array2 = array;
			if (array2.Length == 1)
			{
				trimCurve.Edge = _0023_003Dz4qecmD8_003D(_0023_003DzaXtWw_0024E7gfA1VEcsMzSBB9E_003D, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
				return trimCurve;
			}
			CompositeCurve compositeCurve = new CompositeCurve();
			for (int i = 0; i < array2.Length; i++)
			{
				if (array2[i].Length() > 1E-06)
				{
					TrimCurve item = ((Curve)array2[i])._0023_003DzmGgqdRaHiXdg(_0023_003Dz_0024KKopL9T7nzT.LiftCurve((Curve)array2[i], _0023_003DzccAR5G0_003D * Utility._0023_003Dzjyaz_Vfaky9X));
					compositeCurve.CurveList.Add(item);
				}
			}
			return compositeCurve;
		}
		_0023_003Dzz6JIJ4xNe1_0024dIMT88uFZydqQ_0024upBYSTqB05jKFc_003D _0023_003Dzz6JIJ4xNe1_0024dIMT88uFZydqQ_0024upBYSTqB05jKFc_003D2 = (_0023_003Dzz6JIJ4xNe1_0024dIMT88uFZydqQ_0024upBYSTqB05jKFc_003D)_0023_003DzPx2oAYw_003D[_0023_003DzFfwLVup7QWyS_0024l26KY8TTfw_003D];
		int num = _0023_003Dzz6JIJ4xNe1_0024dIMT88uFZydqQ_0024upBYSTqB05jKFc_003D2._0023_003DzSBFamoYvOcVi().Length;
		CompositeCurve compositeCurve2 = new CompositeCurve();
		for (int j = 0; j < num; j++)
		{
			TrimCurve trimCurve2 = _0023_003DzmGgqdRaHiXdg(_0023_003Dzz6JIJ4xNe1_0024dIMT88uFZydqQ_0024upBYSTqB05jKFc_003D2._0023_003DzSBFamoYvOcVi()[j] / 2, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003Dz_0024KKopL9T7nzT, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
			if (trimCurve2 == null)
			{
				return null;
			}
			if (_0023_003Dz63vmKM0_003D != null)
			{
				trimCurve2.TransformBy(_0023_003Dz63vmKM0_003D);
			}
			compositeCurve2.CurveList.Add(trimCurve2);
		}
		int num2 = 0;
		_0023_003Dzz6JIJ4xNe1_0024dIMT88uFZydqQ_0024upBYSTqB05jKFc_003D _0023_003Dzz6JIJ4xNe1_0024dIMT88uFZydqQ_0024upBYSTqB05jKFc_003D3 = null;
		if (_0023_003DzaXtWw_0024E7gfA1VEcsMzSBB9E_003D > 0)
		{
			if (!(_0023_003DzPx2oAYw_003D[_0023_003DzaXtWw_0024E7gfA1VEcsMzSBB9E_003D] is _0023_003Dzz6JIJ4xNe1_0024dIMT88uFZydqQ_0024upBYSTqB05jKFc_003D))
			{
				return null;
			}
			_0023_003Dzz6JIJ4xNe1_0024dIMT88uFZydqQ_0024upBYSTqB05jKFc_003D3 = (_0023_003Dzz6JIJ4xNe1_0024dIMT88uFZydqQ_0024upBYSTqB05jKFc_003D)_0023_003DzPx2oAYw_003D[_0023_003DzaXtWw_0024E7gfA1VEcsMzSBB9E_003D];
			num2 = _0023_003Dzz6JIJ4xNe1_0024dIMT88uFZydqQ_0024upBYSTqB05jKFc_003D3._0023_003DzSBFamoYvOcVi().Length;
		}
		if (num2 > 0 && num2 == num)
		{
			for (int k = 0; k < num2; k++)
			{
				((TrimCurve)compositeCurve2.CurveList[k]).Edge = _0023_003Dz4qecmD8_003D(_0023_003Dzz6JIJ4xNe1_0024dIMT88uFZydqQ_0024upBYSTqB05jKFc_003D3._0023_003DzSBFamoYvOcVi()[k] / 2, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D);
			}
		}
		else
		{
			List<ICurve> list = new List<ICurve>();
			for (int l = 0; l < num; l++)
			{
				ICurve[] array = ((Curve)compositeCurve2.CurveList[l]).SplitAtDiscontinuities(speedChange: true);
				ICurve[] collection = array;
				list.AddRange(collection);
			}
			compositeCurve2.CurveList = new List<ICurve>(list);
			for (int m = 0; m < compositeCurve2.CurveList.Count; m++)
			{
				((TrimCurve)compositeCurve2.CurveList[m]).Edge = _0023_003Dz_0024KKopL9T7nzT.LiftCurve((Curve)list[m], _0023_003DzccAR5G0_003D * Utility._0023_003Dzjyaz_Vfaky9X);
			}
		}
		List<ICurve> list2 = new List<ICurve>();
		double diagonal = new Size2D(_0023_003Dz_0024KKopL9T7nzT.DomainU.Length, _0023_003Dz_0024KKopL9T7nzT.DomainV.Length).Diagonal;
		foreach (ICurve curve in compositeCurve2.CurveList)
		{
			if (curve.Length() > diagonal * Utility._0023_003DzxhnLabVjXjPg)
			{
				list2.Add(curve);
			}
		}
		compositeCurve2.CurveList = list2;
		compositeCurve2.SortAndOrient();
		return compositeCurve2;
	}

	internal TrimCurve _0023_003DzmGgqdRaHiXdg(int _0023_003DzHnC76LY_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, Surface _0023_003Dz_0024KKopL9T7nzT, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
	{
		return (_0023_003Dz4qecmD8_003D(_0023_003DzHnC76LY_003D, _0023_003DzPx2oAYw_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)?.GetNurbsForm())?.GetTrimCurve();
	}

	private static int _0023_003DzLynpSIA_003D(TrimCurve _0023_003DzRVoDPs0_003D, Surface _0023_003DzAI_Szwk_003D, double _0023_003DzX0qX_IwWxysi, ICurve[] _0023_003DzVx45wsu_FPhfkE8WU93SX1N_0024Umue, out int _0023_003Dz13KtlVg_003D)
	{
		_0023_003Dz13KtlVg_003D = 0;
		int num = 0;
		if (_0023_003DzRVoDPs0_003D.IsClosed && _0023_003DzRVoDPs0_003D.Degree == 1)
		{
			if (_0023_003DzRVoDPs0_003D.Edge is Curve)
			{
				_0023_003Dz13KtlVg_003D = _0023_003DzRVoDPs0_003D.ControlPoints.Length;
				Curve curve = (Curve)_0023_003DzRVoDPs0_003D.Edge;
				if (_0023_003DzAI_Szwk_003D.DegreeU == 1)
				{
					for (int i = 0; i < _0023_003Dz13KtlVg_003D; i++)
					{
						if (_0023_003DzAI_Szwk_003D.PointAt(_0023_003DzRVoDPs0_003D.ControlPoints[i]).DistanceTo(curve.ControlPoints[i]) < _0023_003DzX0qX_IwWxysi)
						{
							num++;
						}
					}
				}
			}
			else if (_0023_003DzRVoDPs0_003D.Edge is CompositeCurve)
			{
				_0023_003Dz13KtlVg_003D = _0023_003DzRVoDPs0_003D.ControlPoints.Length - 1;
				CompositeCurve compositeCurve = (CompositeCurve)_0023_003DzRVoDPs0_003D.Edge;
				if (compositeCurve.CurveList.Count == _0023_003Dz13KtlVg_003D)
				{
					for (int j = 0; j < _0023_003Dz13KtlVg_003D; j++)
					{
						Point4D pt = _0023_003DzRVoDPs0_003D.ControlPoints[j];
						if (_0023_003DzAI_Szwk_003D.PointAt(pt).DistanceTo(compositeCurve.CurveList[j].StartPoint) < _0023_003DzX0qX_IwWxysi)
						{
							num++;
						}
					}
				}
			}
		}
		else
		{
			_0023_003Dz13KtlVg_003D = _0023_003DzVx45wsu_FPhfkE8WU93SX1N_0024Umue.Length;
			for (int k = 0; k < _0023_003DzVx45wsu_FPhfkE8WU93SX1N_0024Umue.Length; k++)
			{
				TrimCurve trimCurve = (TrimCurve)_0023_003DzVx45wsu_FPhfkE8WU93SX1N_0024Umue[k];
				if (_0023_003DzAI_Szwk_003D.PointAt(trimCurve.StartPoint).DistanceTo(trimCurve.Edge.StartPoint) < _0023_003DzX0qX_IwWxysi)
				{
					num++;
				}
			}
		}
		return num;
	}

	internal static bool _0023_003Dz7bMUILkfG8P9W9cWvF5ZIz8_003D(Surface _0023_003Dz_0024KKopL9T7nzT, IList<ICurve> _0023_003DzpIZC_0024x5EiUBN)
	{
		int _0023_003DzOBpaPt4_003D = 0;
		int count = _0023_003DzpIZC_0024x5EiUBN.Count;
		if ((count == 2 || count == 3 || count == 4) && _0023_003DzutKjyYG5tgoNSpCMvQ_003D_003D(_0023_003Dz_0024KKopL9T7nzT, _0023_003DzpIZC_0024x5EiUBN, count, _0023_003DzOBpaPt4_003D))
		{
			return true;
		}
		return false;
	}

	private static bool _0023_003DzutKjyYG5tgoNSpCMvQ_003D_003D(Surface _0023_003Dz_0024KKopL9T7nzT, IList<ICurve> _0023_003DzpIZC_0024x5EiUBN, int _0023_003DzGIF1_0024xycNqse, int _0023_003DzOBpaPt4_003D)
	{
		_0023_003DzCCk7Fmw_003D(_0023_003Dz_0024KKopL9T7nzT, out var _0023_003Dzr5kBHUPFJ_t91EvMIg_003D_003D, out var _0023_003DzpwDmCvjmf1eb, out var _0023_003DzXTNXdYU_003D);
		for (int i = 0; i < _0023_003DzGIF1_0024xycNqse; i++)
		{
			Curve _0023_003DzjbqS1qE_003D = (Curve)_0023_003DzpIZC_0024x5EiUBN[i];
			for (int j = 0; j < 4; j++)
			{
				if (!_0023_003DzXTNXdYU_003D[j])
				{
					Curve _0023_003Dz1v6oPQk_003D = (Curve)((CompositeCurve)_0023_003Dzr5kBHUPFJ_t91EvMIg_003D_003D.ContourList[0]).CurveList[j];
					if (_0023_003Dze7z3WPCvTX7q(_0023_003DzjbqS1qE_003D, _0023_003Dz1v6oPQk_003D, _0023_003DzpwDmCvjmf1eb))
					{
						_0023_003DzOBpaPt4_003D++;
						_0023_003DzXTNXdYU_003D[j] = true;
					}
				}
			}
		}
		if (_0023_003DzOBpaPt4_003D == _0023_003DzGIF1_0024xycNqse)
		{
			return true;
		}
		return false;
	}

	private static void _0023_003DzCCk7Fmw_003D(Surface _0023_003Dz_0024KKopL9T7nzT, out devDept.Eyeshot.Entities.Region _0023_003Dzr5kBHUPFJ_t91EvMIg_003D_003D, out double _0023_003DzpwDmCvjmf1eb, out bool[] _0023_003DzXTNXdYU_003D)
	{
		_0023_003DzXTNXdYU_003D = new bool[4];
		_0023_003Dzr5kBHUPFJ_t91EvMIg_003D_003D = _0023_003Dz_0024KKopL9T7nzT._0023_003Dzrkte6ryoSSy1((Surface._0023_003DzQAHUODcCipZscKjjuw_003D_003D)0);
		double num = new Size2D(_0023_003Dz_0024KKopL9T7nzT.DomainU.Length, _0023_003Dz_0024KKopL9T7nzT.DomainV.Length).Diagonal * Utility._0023_003Dzjyaz_Vfaky9X;
		_0023_003DzpwDmCvjmf1eb = num * num;
	}

	private static bool _0023_003Dze7z3WPCvTX7q(Curve _0023_003DzjbqS1qE_003D, Curve _0023_003Dz1v6oPQk_003D, double _0023_003DzpwDmCvjmf1eb)
	{
		Point3D startPoint = _0023_003DzjbqS1qE_003D.StartPoint;
		Point3D endPoint = _0023_003DzjbqS1qE_003D.EndPoint;
		Point3D startPoint2 = _0023_003Dz1v6oPQk_003D.StartPoint;
		Point3D endPoint2 = _0023_003Dz1v6oPQk_003D.EndPoint;
		Vector3D startTangent = _0023_003DzjbqS1qE_003D.StartTangent;
		Vector3D endTangent = _0023_003DzjbqS1qE_003D.EndTangent;
		Vector3D startTangent2 = _0023_003Dz1v6oPQk_003D.StartTangent;
		Vector3D endTangent2 = _0023_003Dz1v6oPQk_003D.EndTangent;
		if (((Point3D.DistanceSquared(startPoint, startPoint2) < _0023_003DzpwDmCvjmf1eb && Point3D.DistanceSquared(endPoint, endPoint2) < _0023_003DzpwDmCvjmf1eb) || (Point3D.DistanceSquared(startPoint, endPoint2) < _0023_003DzpwDmCvjmf1eb && Point3D.DistanceSquared(endPoint, startPoint2) < _0023_003DzpwDmCvjmf1eb)) && Vector3D.AreParallel(startTangent, startTangent2) && Vector3D.AreParallel(endTangent, endTangent2))
		{
			return true;
		}
		return false;
	}

	private Entity _0023_003Dzfpt8uoA_003D(_0023_003Dz26Feb5E6SVtERAQBq_TBV8CmtN1UucNJlA_003D_003D _0023_003DzwqfuKforsy8L, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D)
	{
		_0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D _0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D2 = _0023_003DzwqfuKforsy8L._0023_003DzRE_Y7daquMq7[0];
		Entity entity = new Text(0.0, 0.0, 0.0, _0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D2._0023_003DzwyYng5o_003D, _0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D2._0023_003DzIgncvKxbPTEd);
		if (_0023_003DzwqfuKforsy8L._0023_003DzRE_Y7daquMq7.Count > 1)
		{
			StringBuilder stringBuilder = new StringBuilder(_0023_003DzwqfuKforsy8L._0023_003DzRE_Y7daquMq7[0]._0023_003DzwyYng5o_003D + Environment.NewLine);
			for (int i = 1; i < _0023_003DzwqfuKforsy8L._0023_003DzRE_Y7daquMq7.Count; i++)
			{
				stringBuilder.Append(_0023_003DzwqfuKforsy8L._0023_003DzRE_Y7daquMq7[i]._0023_003DzwyYng5o_003D + Environment.NewLine);
			}
			entity = new MultilineText(0.0, 0.0, 0.0, stringBuilder.ToString(), _0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D2._0023_003Dz52DtAfOW3JcG, _0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D2._0023_003DzIgncvKxbPTEd, _0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D2._0023_003DzIgncvKxbPTEd * 1.5, Text.alignmentType.BaselineLeft, null);
		}
		entity.Rotate(_0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D2._0023_003DzphuopNr1cMwyXJRT7Q_003D_003D, Vector3D.AxisZ);
		entity.Translate(_0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D2._0023_003DzJPR4E5ZNOD6H.X, _0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D2._0023_003DzJPR4E5ZNOD6H.Y, _0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D2._0023_003DzJPR4E5ZNOD6H.Z);
		if (_0023_003DzwqfuKforsy8L._0023_003Dztfry3Xjye35X != -1)
		{
			_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D _0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D2 = (_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D)_0023_003DzPx2oAYw_003D[_0023_003DzwqfuKforsy8L._0023_003Dztfry3Xjye35X / 2];
			entity.TransformBy(_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D2._0023_003DzKJgErG0_003D());
		}
		return entity;
	}

	private Entity _0023_003DznSL46BtA1AMK9lvtvQ_003D_003D(_0023_003Dz0wVdkDSyPiY38wDh_0024it2Wow5fuuPl7r8a8kaJfYypij3 _0023_003DzhitlgVA_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzPx2oAYw_003D)
	{
		double _0023_003Dz_0024ZWRvrW9NEUw5CyGuw_003D_003D = _0023_003DzhitlgVA_003D._0023_003Dz_0024ZWRvrW9NEUw5CyGuw_003D_003D;
		BlockReference blockReference = new BlockReference(_0023_003DzhitlgVA_003D._0023_003DzaQ_y9PQ_003D, _0023_003DzhitlgVA_003D._0023_003DzD47R4_0_003D, _0023_003DzhitlgVA_003D._0023_003DzLpcnctI_003D, _0023_003DzhitlgVA_003D._0023_003Dzbr9JwG74s_Cc.ToString(CultureInfo.InvariantCulture), _0023_003Dz_0024ZWRvrW9NEUw5CyGuw_003D_003D, _0023_003Dz_0024ZWRvrW9NEUw5CyGuw_003D_003D, _0023_003Dz_0024ZWRvrW9NEUw5CyGuw_003D_003D, 0.0);
		if (_0023_003DzhitlgVA_003D._0023_003Dztfry3Xjye35X != -1)
		{
			_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D _0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D2 = (_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D)_0023_003DzPx2oAYw_003D[_0023_003DzhitlgVA_003D._0023_003Dztfry3Xjye35X / 2];
			blockReference.TransformBy(_0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D2._0023_003DzKJgErG0_003D());
		}
		return blockReference;
	}
}
