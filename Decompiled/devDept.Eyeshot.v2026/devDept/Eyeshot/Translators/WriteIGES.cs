using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class WriteIGES : WriteFileAsyncWithUnits
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Comparison<_0023_003Dzrl2THactnebx> _0023_003DzctmtDKLXaeFxoDNAVA_003D_003D;

		internal int _0023_003Dzw2xRFJQN_p_0024gs0wYO5l4FYE_003D(_0023_003Dzrl2THactnebx _0023_003Dzjum1AIM_003D, _0023_003Dzrl2THactnebx _0023_003Dzh8og4go_003D)
		{
			return _0023_003Dzjum1AIM_003D._0023_003Dzq6E6aZ9ium1i().CompareTo(_0023_003Dzh8og4go_003D._0023_003Dzq6E6aZ9ium1i());
		}
	}

	private sealed class _0023_003Dzrl2THactnebx
	{
		private int _0023_003DzYSvp1XthFV7zWDjwpg_003D_003D;

		private Block _0023_003DzqXbS8dNvfyi3WVX1Bg_003D_003D;

		public int _0023_003Dzq6E6aZ9ium1i()
		{
			return _0023_003DzYSvp1XthFV7zWDjwpg_003D_003D;
		}

		public void _0023_003Dz3k6H7_ShzOCw(int _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzYSvp1XthFV7zWDjwpg_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}

		public Block _0023_003DzUgsjpnHlBCfc()
		{
			return _0023_003DzqXbS8dNvfyi3WVX1Bg_003D_003D;
		}

		public void _0023_003DzXb1Eps4LO66_(Block _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzqXbS8dNvfyi3WVX1Bg_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003Dz0BIiPaQQVQlEmfNHWAB8wZCPSu5xlcuer20izNs_003D _0023_003DzFSa8eGE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IProgress<ProgressChangedEventArgs> _0023_003DzsWnj47U_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CancellationToken _0023_003DzEBehidw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly List<_0023_003Dzrl2THactnebx> _0023_003DzN0OJGoxPazf_0024 = new List<_0023_003Dzrl2THactnebx>();

	public static supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.Inches | supportedLinearUnitsType.Feet | supportedLinearUnitsType.Miles | supportedLinearUnitsType.Millimeters | supportedLinearUnitsType.Centimeters | supportedLinearUnitsType.Meters | supportedLinearUnitsType.Kilometers | supportedLinearUnitsType.Microinches | supportedLinearUnitsType.Mils | supportedLinearUnitsType.Microns;

	public WriteIGES(IWorkspace workspace, string filePath, bool selectedOnly = false)
		: this(workspace.Document, filePath, selectedOnly)
	{
	}

	public WriteIGES(Document document, string filePath, bool selectedOnly = false)
		: this(new WriteParamsWithUnits(document, selectedOnly), filePath)
	{
	}

	public WriteIGES(IWorkspace workspace, Stream stream, bool selectedOnly = false)
		: this(workspace.Document, stream, selectedOnly)
	{
	}

	public WriteIGES(Document document, Stream stream, bool selectedOnly = false)
		: this(new WriteParamsWithUnits(document, selectedOnly), stream)
	{
	}

	public WriteIGES(IWorkspace workspace, string filePath, string author, string organization, string originatingSystem, bool selectedOnly = false)
		: this(workspace.Document, filePath, author, organization, originatingSystem, selectedOnly)
	{
	}

	public WriteIGES(Document document, string filePath, string author, string organization, string originatingSystem, bool selectedOnly = false)
		: this(new WriteParamsWithUnits(document, selectedOnly)
		{
			Author = author,
			Organization = organization,
			OriginatingSystem = originatingSystem
		}, filePath)
	{
	}

	public WriteIGES(IWorkspace workspace, Stream stream, string author, string organization, string originatingSystem, bool selectedOnly = false)
		: this(workspace.Document, stream, author, organization, originatingSystem, selectedOnly)
	{
	}

	public WriteIGES(Document document, Stream stream, string author, string organization, string originatingSystem, bool selectedOnly = false)
		: this(new WriteParamsWithUnits(document, selectedOnly)
		{
			Author = author,
			Organization = organization,
			OriginatingSystem = originatingSystem
		}, stream)
	{
	}

	public WriteIGES(WriteParamsWithUnits writeParams, string filePath)
		: base(writeParams, filePath)
	{
		_0023_003DzrtB0QILXyS1kXboL7g_003D_003D();
	}

	public WriteIGES(WriteParamsWithUnits writeParams, Stream stream)
		: base(writeParams, stream)
	{
		_0023_003DzrtB0QILXyS1kXboL7g_003D_003D();
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	public WriteIGES(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, string filePath, linearUnitsType units, bool selectedOnly = false)
		: base(entList, layerList, blockDict, filePath, units)
	{
		base.selectedOnly = selectedOnly;
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	public WriteIGES(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, Stream stream, linearUnitsType units, bool selectedOnly = false)
		: base(entList, layerList, blockDict, stream, units)
	{
		base.selectedOnly = selectedOnly;
	}

	[Obsolete("Use the constructor that accepts the document and header as parameters instead.")]
	public WriteIGES(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, string filePath, linearUnitsType units, string author, string organization, string originatingSystem, bool selectedOnly = false)
		: base(entList, layerList, blockDict, filePath, units)
	{
		base.selectedOnly = selectedOnly;
		base.author = author;
		base.organization = organization;
		base.originatingSystem = originatingSystem;
	}

	[Obsolete("Use the constructor that accepts the document and header as parameters instead.")]
	public WriteIGES(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, Stream stream, linearUnitsType units, string author, string organization, string originatingSystem, bool selectedOnly = false)
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
		foreach (Block block in blocks)
		{
			int _0023_003DzfNi7d4A_003D = 0;
			EntityList entityList = block.Entities;
			if (entityList.Count != 0 && !block.Name.Equals(blocks.RootBlockName))
			{
				int _0023_003DzPzO_0024GUk_003D = _0023_003Dz9aNiWoT_Znz8(entityList, blocks, ref _0023_003DzfNi7d4A_003D);
				List<_0023_003Dzrl2THactnebx> list = _0023_003DzN0OJGoxPazf_0024;
				_0023_003Dzrl2THactnebx obj = new _0023_003Dzrl2THactnebx();
				obj._0023_003Dz3k6H7_ShzOCw(_0023_003DzPzO_0024GUk_003D);
				obj._0023_003DzXb1Eps4LO66_(block);
				list.Add(obj);
			}
		}
		_0023_003DzN0OJGoxPazf_0024.Sort((_0023_003Dzrl2THactnebx _0023_003Dzjum1AIM_003D, _0023_003Dzrl2THactnebx _0023_003Dzh8og4go_003D) => _0023_003Dzjum1AIM_003D._0023_003Dzq6E6aZ9ium1i().CompareTo(_0023_003Dzh8og4go_003D._0023_003Dzq6E6aZ9ium1i()));
		_0023_003Dz1NWs_aZC9Efm(progress, ct);
	}

	private void _0023_003Dz1NWs_aZC9Efm(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		try
		{
			TextWriter textWriter = new StreamWriter(base.Stream ?? File.Open(base.FilePath, FileMode.Create, FileAccess.Write), Encoding.ASCII);
			SetWriter(textWriter);
			ComputeBoundingBox(out var min, out var max);
			double[] obj = new double[6]
			{
				Math.Abs(min.X),
				Math.Abs(min.Y),
				Math.Abs(min.Z),
				Math.Abs(max.X),
				Math.Abs(max.Y),
				Math.Abs(max.Z)
			};
			Array.Sort(obj);
			double _0023_003Dzgfxbk3apRWkCxbrhIg_003D_003D = obj[5];
			_0023_003DzFSa8eGE_003D = new _0023_003Dz0BIiPaQQVQlEmfNHWAB8wZCPSu5xlcuer20izNs_003D(textWriter);
			_0023_003DzFSa8eGE_003D._0023_003DzgHO845XqWw4G(_0023_003Dz3M6ES3WEuAb3);
			IList<Entity> list = GetEntities();
			List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> list2 = new List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D>(list.Count);
			int _0023_003DzyzK8swU_003D = 1;
			if (layers.Count > 0)
			{
				for (int i = 0; i < layers.Count; i++)
				{
					Layer layer = layers[i];
					_0023_003DzEKmPHSrtZpXBuvnSgWZRaAA3O3fTJRRWog_003D_003D obj2 = new _0023_003DzEKmPHSrtZpXBuvnSgWZRaAA3O3fTJRRWog_003D_003D(i, layer.Name, layer.Color);
					obj2._0023_003DzqkDCo38_003D(ref _0023_003DzyzK8swU_003D, layer.Name);
					obj2._0023_003DzsxCTpik_003D(ref _0023_003DzyzK8swU_003D);
					obj2._0023_003DztC4gkYE_003D = i;
					obj2._0023_003Dzu9FtIMXgxSrQ(list2);
				}
				Dictionary<string, int> dictionary = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
				for (int j = 0; j < _0023_003DzN0OJGoxPazf_0024.Count; j++)
				{
					_0023_003Dzrl2THactnebx _0023_003Dzrl2THactnebx2 = _0023_003DzN0OJGoxPazf_0024[j];
					_0023_003Dzrl2THactnebx2._0023_003DzUgsjpnHlBCfc()._0023_003Dz3z8yNhyUFswq(_0023_003Dzrl2THactnebx2._0023_003DzUgsjpnHlBCfc().Name, j, list2, layers, blocks, ref _0023_003DzyzK8swU_003D);
					dictionary.Add(_0023_003Dzrl2THactnebx2._0023_003DzUgsjpnHlBCfc().Name, _0023_003DzyzK8swU_003D - 2);
				}
				int count = list2.Count;
				for (int k = 0; k < list.Count; k++)
				{
					Entity entity = list[k];
					if (entity.Visible && (!selectedOnly || entity.Selected) && layers.TryGetValue(entity.LayerName, out var value) && value.Visible)
					{
						entity._0023_003Dz_0024_0024rGbexgW9YV(list2, blocks, ref _0023_003DzyzK8swU_003D);
					}
					if (!UpdateProgressAndCheckCancelled(k + 1, list.Count, base.ComposingEntitiesText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
					{
						textWriter.Close();
						return;
					}
				}
				for (int l = count; l < list2.Count; l++)
				{
					if (list2[l]._0023_003DzaROjBYA_003D == Layer.DefaultLayerName)
					{
						list2[l]._0023_003DztC4gkYE_003D = 0;
					}
					else
					{
						list2[l]._0023_003DztC4gkYE_003D = layers.IndexOf(layers[list2[l]._0023_003DzaROjBYA_003D]);
					}
				}
				foreach (_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D item in list2)
				{
					item._0023_003DzcVkKHrQ_003D(dictionary);
				}
				_0023_003DzyzK8swU_003D = 1;
				foreach (_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D item2 in list2)
				{
					item2._0023_003Dz2nl0wJAilHFx(ref _0023_003DzyzK8swU_003D);
				}
			}
			LicenseManager._0023_003DzNrvBEfk_003D(out var _, out var _, out var _, out var _0023_003DzQ3hPewo_003D, out var _, out var _);
			string _0023_003DzQ3hPewo_003D2 = _0023_003DzQ3hPewo_003D.Major + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290) + _0023_003DzQ3hPewo_003D.Minor + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290) + _0023_003DzQ3hPewo_003D.Build;
			_0023_003DzFSa8eGE_003D._0023_003Dz1NWs_aZC9Efm(list2, base.FilePath, author, organization, originatingSystem, _0023_003DzQ3hPewo_003D2, units, _0023_003Dzgfxbk3apRWkCxbrhIg_003D_003D);
			UpdateProgressTo100(base.WritingText, _0023_003DzmHS7frs_003D);
		}
		catch (Exception ex)
		{
			string message = ex.Message;
			log.AppendLine(message);
			throw new EyeshotException(message, ex);
		}
		finally
		{
			CloseStream();
		}
	}

	private int _0023_003Dz9aNiWoT_Znz8(IList<Entity> _0023_003DzWc9WmS8VMsuA, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, ref int _0023_003DzfNi7d4A_003D)
	{
		int num = 0;
		foreach (Entity item in _0023_003DzWc9WmS8VMsuA)
		{
			if (item is BlockReference)
			{
				BlockReference blockReference = (BlockReference)item;
				_0023_003Dz9aNiWoT_Znz8(_0023_003DzJO1FWlQ_003D[blockReference.BlockName].Entities, _0023_003DzJO1FWlQ_003D, ref _0023_003DzfNi7d4A_003D);
				_0023_003DzfNi7d4A_003D++;
			}
			if (_0023_003DzfNi7d4A_003D > num)
			{
				num = _0023_003DzfNi7d4A_003D;
			}
		}
		return num;
	}

	private void _0023_003Dz3M6ES3WEuAb3(object _0023_003Dz9VjL5i0_003D, ProgressChangedEventArgs _0023_003DzbfrNXYE_003D)
	{
		if (!UpdateProgressAndCheckCancelled(_0023_003DzbfrNXYE_003D.Progress, 100.0, base.WritingText, _0023_003DzsWnj47U_003D, _0023_003DzEBehidw_003D))
		{
			_0023_003DzFSa8eGE_003D._0023_003DzBcvxv10_003D = true;
		}
	}
}
