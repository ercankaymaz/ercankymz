using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class ReadJT : ReadFileAsync
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzGbvkIgC5zcwBXCSsRl_2yY0GoNwL _0023_003DzFuePbj8_003D;

	public override supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.Unitless;

	public ReadJT(string filePath)
		: base(filePath)
	{
	}

	public ReadJT(Stream stream)
		: base(stream)
	{
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "%fQD,q\"ac>", array);
		_0023_003DzD_00245l26lXPC6h(progress);
	}

	private void _0023_003DzD_00245l26lXPC6h(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D)
	{
		try
		{
			base.Blocks.Clear();
			_0023_003DzFuePbj8_003D = new _0023_003DzGbvkIgC5zcwBXCSsRl_2yY0GoNwL();
			StartContinuousAnimation(base.ReadingText, _0023_003DzmHS7frs_003D);
			bool flag = _0023_003DzFuePbj8_003D._0023_003DzYR6DOdw_003D(base.Stream, base.FilePath ?? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008294));
			foreach (string[] item in _0023_003DzFuePbj8_003D._0023_003DztKH2uPCgKGxg())
			{
				log.AppendLine(item[0] + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008275) + item[1]);
			}
			if (flag)
			{
				_0023_003DzuPVN6ohfX6JX(_0023_003DzFuePbj8_003D._0023_003Dz8cYdvkQBHm93().Values.ToArray());
				base.Blocks.SetRootBlock(_0023_003DzFuePbj8_003D._0023_003DzQ9hZ4ANTOhYJ()._0023_003DzRcuz4cVtApX8());
				base.Result = true;
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
			StopContinuousAnimation(_0023_003DzmHS7frs_003D);
		}
	}

	private void _0023_003DzuPVN6ohfX6JX(IList<_0023_003Dzhveo1JvXmr3kvNv0Nfm2LWN6yHZ1E8OGuw_003D_003D> _0023_003DzhYSMffZkteST)
	{
		foreach (_0023_003Dzhveo1JvXmr3kvNv0Nfm2LWN6yHZ1E8OGuw_003D_003D item in _0023_003DzhYSMffZkteST)
		{
			Block block = new Block(item._0023_003DzwKyKajk_003D());
			base.Blocks.Add(block);
			foreach (_0023_003DzfdKPARIiXAOR9i6c4vbr9xuEf_0024Re item2 in item._0023_003DzbVza_OTGw_QHBOv_2g_003D_003D())
			{
				block.Entities.Add(_0023_003DzK3H_0024OyqmXBVX(item2));
			}
			foreach (_0023_003DzxYSdOmYPaND74FG8nz54qdvrfKzQ item3 in item._0023_003Dz6Kki30ewh_0024dZ())
			{
				block.Entities.Add(new BlockReference(item3._0023_003DzxdqexKR7jogJ(), item3._0023_003DzRcuz4cVtApX8()));
			}
		}
	}

	private Mesh _0023_003DzK3H_0024OyqmXBVX(_0023_003DzfdKPARIiXAOR9i6c4vbr9xuEf_0024Re _0023_003DzVM8JW3W13dTR)
	{
		return new Mesh(_0023_003DzVM8JW3W13dTR._0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D().ToList(), _0023_003DzVM8JW3W13dTR._0023_003DzPvyA_tju2mOECWmhiQ_003D_003D().ToList())
		{
			ColorMethod = colorMethodType.byEntity,
			Color = _0023_003DzVM8JW3W13dTR._0023_003DzXiRgY5w_003D()
		};
	}
}
