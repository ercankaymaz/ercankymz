using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class WriteSTEP : WriteFileAsyncWithUnits
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<Entity, bool> _0023_003DzHakk9KKVJNaTquf_0024Bg_003D_003D;

		internal bool _0023_003DzThhR0AKTbyxsryJC9o5ehns_003D(Entity _0023_003Dz9j7EUB0_003D)
		{
			if (!(_0023_003Dz9j7EUB0_003D is Mesh) && !(_0023_003Dz9j7EUB0_003D is Solid) && !(_0023_003Dz9j7EUB0_003D is Surface) && !(_0023_003Dz9j7EUB0_003D is Brep))
			{
				return _0023_003Dz9j7EUB0_003D is BlockReference;
			}
			return true;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzccZz_2h5nX81BJCYyQ_003D_003D _0023_003DzFSa8eGE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IProgress<ProgressChangedEventArgs> _0023_003DzsWnj47U_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CancellationToken _0023_003DzEBehidw_003D;

	public static supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.Inches | supportedLinearUnitsType.Feet | supportedLinearUnitsType.Miles | supportedLinearUnitsType.Millimeters | supportedLinearUnitsType.Centimeters | supportedLinearUnitsType.Meters | supportedLinearUnitsType.Kilometers;

	public WriteSTEP(IWorkspace workspace, string filePath, bool selectedOnly = false)
		: this(workspace.Document, filePath, selectedOnly)
	{
	}

	public WriteSTEP(Document document, string filePath, bool selectedOnly = false)
		: this(new WriteParamsWithUnits(document, selectedOnly), filePath)
	{
	}

	public WriteSTEP(IWorkspace workspace, Stream stream, bool selectedOnly = false)
		: this(workspace.Document, stream, selectedOnly)
	{
	}

	public WriteSTEP(Document document, Stream stream, bool selectedOnly = false)
		: this(new WriteParamsWithUnits(document, selectedOnly), stream)
	{
	}

	public WriteSTEP(IWorkspace workspace, string filePath, string author, string organization, string originatingSystem, bool selectedOnly = false)
		: this(workspace.Document, filePath, author, organization, originatingSystem, selectedOnly)
	{
	}

	public WriteSTEP(Document document, string filePath, string author, string organization, string originatingSystem, bool selectedOnly = false)
		: this(new WriteParamsWithUnits(document, selectedOnly)
		{
			Author = author,
			Organization = organization,
			OriginatingSystem = originatingSystem
		}, filePath)
	{
	}

	public WriteSTEP(Document document, Stream stream, string author, string organization, string originatingSystem, bool selectedOnly = false)
		: this(new WriteParamsWithUnits(document, selectedOnly)
		{
			Author = author,
			Organization = organization,
			OriginatingSystem = originatingSystem
		}, stream)
	{
	}

	public WriteSTEP(WriteParamsWithUnits writeParams, string filePath)
		: base(writeParams, filePath)
	{
		_0023_003DzrtB0QILXyS1kXboL7g_003D_003D();
	}

	public WriteSTEP(WriteParamsWithUnits writeParams, Stream stream)
		: base(writeParams, stream)
	{
		_0023_003DzrtB0QILXyS1kXboL7g_003D_003D();
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	public WriteSTEP(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, string filePath, linearUnitsType units, bool selectedOnly = false)
		: base(entList, layerList, blockDict, filePath, units)
	{
		base.selectedOnly = selectedOnly;
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	public WriteSTEP(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, Stream stream, linearUnitsType units, bool selectedOnly = false)
		: base(entList, layerList, blockDict, stream, units)
	{
		base.selectedOnly = selectedOnly;
	}

	[Obsolete("Use the constructor that accepts the document and header as parameters instead.")]
	public WriteSTEP(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, string filePath, linearUnitsType units, string author, string organization, string originatingSystem, bool selectedOnly = false)
		: base(entList, layerList, blockDict, filePath, units)
	{
		base.selectedOnly = selectedOnly;
		base.author = author;
		base.organization = organization;
		base.originatingSystem = originatingSystem;
	}

	[Obsolete("Use the constructor that accepts the document and header as parameters instead.")]
	public WriteSTEP(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, Stream stream, linearUnitsType units, string author, string organization, string originatingSystem, bool selectedOnly = false)
		: base(entList, layerList, blockDict, stream, units)
	{
		base.selectedOnly = selectedOnly;
		base.author = author;
		base.organization = organization;
		base.originatingSystem = originatingSystem;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		byte b = 3;
		object[] array = null;
		array = new object[3] { b, this, flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "$N9u(q\"acA", array);
		if (!SupportedLinearUnitsType.HasFlag(Utility.GetSupportedLinearUnits(units)))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302925401) + units);
		}
		_0023_003DzsWnj47U_003D = progress;
		_0023_003DzEBehidw_003D = ct;
		_0023_003Dzcc3RpE4A1jNL(progress, ct);
	}

	internal static string _0023_003DzS0Pr1Qk_003D(string _0023_003Dz4wZe_0024Xg_003D)
	{
		return _0023_003Dz4wZe_0024Xg_003D.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907930), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302930888));
	}

	private void _0023_003Dzcc3RpE4A1jNL(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		StreamWriter streamWriter = new StreamWriter(base.Stream ?? File.Open(base.FilePath, FileMode.Create, FileAccess.Write), Encoding.ASCII);
		SetWriter(streamWriter);
		_0023_003DzFSa8eGE_003D = new _0023_003DzccZz_2h5nX81BJCYyQ_003D_003D(base.FilePath, streamWriter);
		_0023_003DzFSa8eGE_003D._0023_003DzgHO845XqWw4G(_0023_003Dz3M6ES3WEuAb3);
		List<_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D> list = new List<_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D>();
		IList<Entity> list2 = (from _0023_003Dzs_0024uS8LA_003D in GetEntities()
			where layers.CheckItemKey(_0023_003Dzs_0024uS8LA_003D.LayerName) && layers[_0023_003Dzs_0024uS8LA_003D.LayerName].Exportable && (!selectedOnly || _0023_003Dzs_0024uS8LA_003D.Selected)
			select _0023_003Dzs_0024uS8LA_003D).ToList();
		HashSet<string> referencedBlocksNames = Utility.GetReferencedBlocksNames(list2, blocks.BaseDictionary);
		bool num = referencedBlocksNames.Count > 0;
		HashSet<string> hashSet = new HashSet<string>();
		HashSet<string> hashSet2 = new HashSet<string>();
		if (num)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010900));
			foreach (Block block in blocks)
			{
				bool flag = blocks._0023_003Dzm6dsCMpMVy24(block);
				if (referencedBlocksNames.Contains(block.Name) || flag)
				{
					_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2 = new _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D();
					_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003DzyZFnD3E_003D(_0023_003DzS0Pr1Qk_003D(block.Name));
					_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003DzrdvTjeaFTRlY = ((block.Units != linearUnitsType.Unitless) ? block.Units : units);
					_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003DzszASiwEOY4IH(_0023_003DzPzO_0024GUk_003D: true);
					if (block.Entities.Count > 0)
					{
						_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003Dzwtld1NM_003D = Utility.ColorToDoubleArray(block.Entities[0].Color);
					}
					IList<Entity> _0023_003DzWc9WmS8VMsuA;
					if (!flag)
					{
						IList<Entity> list3 = block.Entities;
						_0023_003DzWc9WmS8VMsuA = list3;
					}
					else
					{
						_0023_003DzWc9WmS8VMsuA = list2;
					}
					_0023_003DzZFls9qs38hOd(_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2, _0023_003DzWc9WmS8VMsuA, units, blocks, log, hashSet, hashSet2, layers);
					if (!hashSet2.Contains(_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003DzwKyKajk_003D()) || hashSet.Contains(_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003DzwKyKajk_003D()))
					{
						list.Add(_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2);
					}
				}
			}
			foreach (_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D item in list)
			{
				if (!hashSet.Contains(item._0023_003DzwKyKajk_003D()))
				{
					item._0023_003DzszASiwEOY4IH(_0023_003DzPzO_0024GUk_003D: false);
				}
			}
			_0023_003DzFSa8eGE_003D._0023_003DzJj915pKKvHcf(list);
		}
		else
		{
			Dictionary<string, List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>> dictionary = new Dictionary<string, List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>>(StringComparer.OrdinalIgnoreCase);
			foreach (Layer layer in layers)
			{
				dictionary.Add(layer.Name, new List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>());
			}
			if (layers.Count > 0)
			{
				for (int num2 = 0; num2 < list2.Count; num2++)
				{
					Entity entity = list2[num2];
					if (entity.Visible && (!selectedOnly || entity.Selected) && layers.TryGetValue(entity.LayerName, out var value) && value.Visible)
					{
						entity._0023_003DzAKDLnmImamFN(entity.GetColor(layers), dictionary, units);
					}
				}
			}
			_0023_003DzFSa8eGE_003D._0023_003DzJj915pKKvHcf(list);
			List<_0023_003DzzoqZ7r6_g11JF2TbYw_003D_003D> list4 = new List<_0023_003DzzoqZ7r6_g11JF2TbYw_003D_003D>();
			foreach (KeyValuePair<string, List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>> item2 in dictionary)
			{
				if (item2.Value.Count > 0)
				{
					list4.Add(new _0023_003DzzoqZ7r6_g11JF2TbYw_003D_003D(item2.Value, item2.Key, string.Empty));
				}
			}
			_0023_003DzFSa8eGE_003D._0023_003DzbMI8BdI_003D(list4);
		}
		LicenseManager._0023_003DzNrvBEfk_003D(out var _, out var _, out var _, out var _0023_003DzQ3hPewo_003D, out var _, out var _);
		string _0023_003DzQ3hPewo_003D2 = _0023_003DzQ3hPewo_003D.Major + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290) + _0023_003DzQ3hPewo_003D.Minor + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290) + _0023_003DzQ3hPewo_003D.Build;
		try
		{
			_0023_003DzFSa8eGE_003D._0023_003Dzcc3RpE4A1jNL(author, organization, originatingSystem, _0023_003DzQ3hPewo_003D2, units, angularUnitsType.Radians);
		}
		catch (Exception ex)
		{
			string message = ex.Message;
			log.AppendLine(message);
		}
		finally
		{
			CloseStream();
		}
	}

	private void _0023_003Dz3M6ES3WEuAb3(object _0023_003Dz9VjL5i0_003D, ProgressChangedEventArgs _0023_003DzbfrNXYE_003D)
	{
		if (!UpdateProgressAndCheckCancelled(_0023_003DzbfrNXYE_003D.Progress, 100.0, base.WritingText, _0023_003DzsWnj47U_003D, _0023_003DzEBehidw_003D))
		{
			_0023_003DzFSa8eGE_003D._0023_003DzBcvxv10_003D = true;
		}
	}

	private static void _0023_003DzZFls9qs38hOd(_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D _0023_003DzgyYoHow_003D, IEnumerable<Entity> _0023_003DzWc9WmS8VMsuA, linearUnitsType _0023_003DzsAi4oSk_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, StringBuilder _0023_003DzqmF8XJ0_003D, HashSet<string> _0023_003Dzgn9F5G0_003D, HashSet<string> _0023_003DzXp_00244k0956YsO, LayerKeyedCollection _0023_003DzeWJg3NJnk3WA)
	{
		foreach (Entity item in _0023_003DzWc9WmS8VMsuA)
		{
			if (item is BlockReference blockReference)
			{
				double linearUnitsConversionFactor = Utility.GetLinearUnitsConversionFactor(_0023_003DzgyYoHow_003D._0023_003DzrdvTjeaFTRlY, _0023_003DzJO1FWlQ_003D[blockReference.BlockName].Units);
				if (!_0023_003DzkvBaJ0rkF_aBFbTCeA_003D_003D(blockReference, linearUnitsConversionFactor) && blockReference.Transformation.HasScaling)
				{
					_0023_003DzqmF8XJ0_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015153) + blockReference.BlockName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015146));
					_0023_003DzXp_00244k0956YsO.Add(blockReference.BlockName);
					Entity[] _0023_003DzWc9WmS8VMsuA2 = blockReference.Explode(_0023_003DzJO1FWlQ_003D);
					_0023_003DzZFls9qs38hOd(_0023_003DzgyYoHow_003D, _0023_003DzWc9WmS8VMsuA2, _0023_003DzsAi4oSk_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzqmF8XJ0_003D, _0023_003Dzgn9F5G0_003D, _0023_003DzXp_00244k0956YsO, _0023_003DzeWJg3NJnk3WA);
				}
				else if (_0023_003DzJO1FWlQ_003D[blockReference.BlockName].Entities.Count > 0 && _0023_003DzJO1FWlQ_003D[blockReference.BlockName].Entities.Any(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzThhR0AKTbyxsryJC9o5ehns_003D))
				{
					_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D _0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2 = blockReference._0023_003Dzc_0024xt7GEbkJyS(_0023_003DzJO1FWlQ_003D, null, _0023_003DzXNaz2CIaoHiD: true);
					_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2._0023_003DzrdvTjeaFTRlY = _0023_003DzJO1FWlQ_003D[blockReference.BlockName].Units;
					_0023_003DzgyYoHow_003D._0023_003DzyePFrIIHO6NHR_hL8Q_003D_003D().Add(_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2);
					_0023_003Dzgn9F5G0_003D.Add(blockReference.BlockName);
				}
				continue;
			}
			Color color = item.GetColor(_0023_003DzeWJg3NJnk3WA);
			if (!(item is Brep brep))
			{
				if (!(item is Mesh mesh))
				{
					if (!(item is Surface current2))
					{
						if (!(item is Joint joint))
						{
							if (!(item is Bar bar))
							{
								if (item is Solid solid)
								{
									_0023_003DzgyYoHow_003D._0023_003Dz8MhX3Upx2CLrK047OvWq8TopyPeP().Add((_0023_003DzAI9YqCWKp0mYYODw1A_003D_003D)solid._0023_003DzAKDLnmImamFN(color, null, _0023_003DzsAi4oSk_003D)[0]);
								}
								else
								{
									_0023_003DzqmF8XJ0_003D.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303015101), item.GetType()));
								}
							}
							else
							{
								Brep brep2 = bar.ConvertToSurface().ConvertToBrep();
								_0023_003DzgyYoHow_003D._0023_003Dz5bVmMWCNZpiUDgO8rg_003D_003D().Add(brep2._0023_003DzpxaK_etP8mGw(color));
							}
						}
						else
						{
							Brep brep3 = joint.ConvertToSurface().ConvertToBrep();
							_0023_003DzgyYoHow_003D._0023_003Dz5bVmMWCNZpiUDgO8rg_003D_003D().Add(brep3._0023_003DzpxaK_etP8mGw(color));
						}
					}
					else
					{
						Surface[] individualSurfaces = Surface.GetIndividualSurfaces(current2);
						for (int i = 0; i < individualSurfaces.Length; i++)
						{
							Brep brep4 = individualSurfaces[i].ConvertToBrep();
							_0023_003DzgyYoHow_003D._0023_003Dz5bVmMWCNZpiUDgO8rg_003D_003D().Add(brep4._0023_003DzpxaK_etP8mGw(color));
						}
					}
				}
				else
				{
					_0023_003DzgyYoHow_003D._0023_003Dz8MhX3Upx2CLrK047OvWq8TopyPeP().Add((_0023_003DzAI9YqCWKp0mYYODw1A_003D_003D)mesh._0023_003DzAKDLnmImamFN(color, null, _0023_003DzsAi4oSk_003D)[0]);
				}
			}
			else
			{
				_0023_003DzgyYoHow_003D._0023_003Dz5bVmMWCNZpiUDgO8rg_003D_003D().Add(brep._0023_003DzpxaK_etP8mGw(color));
			}
		}
	}

	private static bool _0023_003DzkvBaJ0rkF_aBFbTCeA_003D_003D(BlockReference _0023_003Dz5I3b_GM_003D, double _0023_003Dzfq0O9T9IwvWM)
	{
		if (_0023_003Dz5I3b_GM_003D.Transformation.IsScaleFactorUniform())
		{
			if (!(Math.Abs(_0023_003Dzfq0O9T9IwvWM - _0023_003Dz5I3b_GM_003D.GetScaleFactorX()) < 0.001))
			{
				return Math.Abs(_0023_003Dzfq0O9T9IwvWM - 1.0 / _0023_003Dz5I3b_GM_003D.GetScaleFactorX()) < 0.001;
			}
			return true;
		}
		return false;
	}

	private bool _0023_003DzR2_yZKzO1yGz5_0024lSKPzcq7s_003D(Entity _0023_003Dzs_0024uS8LA_003D)
	{
		if (layers.CheckItemKey(_0023_003Dzs_0024uS8LA_003D.LayerName) && layers[_0023_003Dzs_0024uS8LA_003D.LayerName].Exportable)
		{
			if (selectedOnly)
			{
				return _0023_003Dzs_0024uS8LA_003D.Selected;
			}
			return true;
		}
		return false;
	}
}
