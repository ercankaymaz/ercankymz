using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot;

public class Regeneration : WorkUnit
{
	private sealed class _0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D
	{
		public List<Entity> _0023_003Dzq7HZWkdv9sgCkIodqQ_003D_003D;

		public IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D;

		public Regeneration _0023_003DzopRx0_MBcTQs;

		public int _0023_003Dz9JZgoew_003D;

		public CancellationToken _0023_003Dzjvn7P10_003D;

		internal void _0023_003DznNIpgRawjSAVJ7V0bQ_003D_003D(int _0023_003Dz437_00244ak_003D, ParallelLoopState _0023_003DzLdZiL78_003D)
		{
			Entity entity = _0023_003Dzq7HZWkdv9sgCkIodqQ_003D_003D[_0023_003Dz437_00244ak_003D];
			if (_0023_003DzmHS7frs_003D != null)
			{
				entity.RegenMode = regenType.RegenAndCompile;
			}
			entity.Regen(_0023_003DzopRx0_MBcTQs.RegenParams);
			if (_0023_003DzopRx0_MBcTQs._0023_003DzBCV2iPmzMc0k4nI7TA_003D_003D)
			{
				entity.silhoData = entity._0023_003DzOQ9MbnSofHiL_xtPyyGkf6ozeVZJ(new PreProcessSilhouettesParams());
			}
			_0023_003DzopRx0_MBcTQs._0023_003DzKltRkW4_003D++;
			if (!_0023_003DzopRx0_MBcTQs.UpdateProgressAndCheckCancelledParallel(_0023_003Dz9JZgoew_003D, _0023_003DzopRx0_MBcTQs._0023_003DzpxW3PVv5YfK7, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
			{
				_0023_003DzLdZiL78_003D.Stop();
			}
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly List<Entity> _0023_003DzirHP2g6iDbM7YBocSw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly RegenParams _0023_003Dz4getBLNDeQi17zdgzf_Pmdw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzKltRkW4_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _0023_003DzlvcTzRDO3KSlmsnRkDxEK40P0DoCz3avhw_003D_003D _0023_003Dz6u8_0024MaEVtXJN;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly bool _0023_003DzlBTnqu2ycbP5xEU95A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly BlockKeyedCollection _0023_003Dz_0024_ydENQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly BlockKeyedCollection _0023_003DzxVzk1_0024t02Kf9;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly bool _0023_003DzBCV2iPmzMc0k4nI7TA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003DzfLWi5gm8Uxya;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly string _0023_003DzpxW3PVv5YfK7;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Block _0023_003Dzimj5NR_zLwfo;

	public List<Entity> Entities
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzirHP2g6iDbM7YBocSw_003D_003D;
		}
	}

	public RegenParams RegenParams
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz4getBLNDeQi17zdgzf_Pmdw_003D;
		}
	}

	public int Count => _0023_003DzKltRkW4_003D;

	internal Regeneration(IEnumerable<Entity> _0023_003Dzw3_zM5Q_003D, Block _0023_003Dz8O9WEppYBXsu, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, BlockKeyedCollection _0023_003DzibJx_aY_e1oq, RegenParams _0023_003DzkY6mqyuPEDLn, bool _0023_003DzbPbTyJBgBacq0wSHVA_003D_003D)
		: this(_0023_003Dzw3_zM5Q_003D, _0023_003Dz8O9WEppYBXsu, _0023_003DzJO1FWlQ_003D, _0023_003DzibJx_aY_e1oq, _0023_003DzkY6mqyuPEDLn, string.Empty, _0023_003Dz7zFCQ_0024TTjaPUy5JI9w_003D_003D: false, _0023_003DzbPbTyJBgBacq0wSHVA_003D_003D)
	{
	}

	internal Regeneration(IEnumerable<Entity> _0023_003Dzw3_zM5Q_003D, Block _0023_003Dz8O9WEppYBXsu, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, BlockKeyedCollection _0023_003DzibJx_aY_e1oq, RegenParams _0023_003DzkY6mqyuPEDLn, string _0023_003Dz3lURioVh8358, bool _0023_003Dz7zFCQ_0024TTjaPUy5JI9w_003D_003D, bool _0023_003DzbPbTyJBgBacq0wSHVA_003D_003D, _0023_003DzlvcTzRDO3KSlmsnRkDxEK40P0DoCz3avhw_003D_003D _0023_003DzToHGjyY_003D = (_0023_003DzlvcTzRDO3KSlmsnRkDxEK40P0DoCz3avhw_003D_003D)0, int _0023_003Dzjhyg1Go_003D = 0)
	{
		_0023_003DzirHP2g6iDbM7YBocSw_003D_003D = new List<Entity>(_0023_003Dzw3_zM5Q_003D);
		_0023_003Dzimj5NR_zLwfo = _0023_003Dz8O9WEppYBXsu;
		_0023_003Dz4getBLNDeQi17zdgzf_Pmdw_003D = _0023_003DzkY6mqyuPEDLn;
		_0023_003Dz_0024_ydENQ_003D = _0023_003DzJO1FWlQ_003D;
		_0023_003DzxVzk1_0024t02Kf9 = _0023_003DzibJx_aY_e1oq;
		_0023_003Dz6u8_0024MaEVtXJN = _0023_003DzToHGjyY_003D;
		_0023_003DzBCV2iPmzMc0k4nI7TA_003D_003D = _0023_003Dz7zFCQ_0024TTjaPUy5JI9w_003D_003D;
		_0023_003DzlBTnqu2ycbP5xEU95A_003D_003D = _0023_003DzbPbTyJBgBacq0wSHVA_003D_003D;
		_0023_003DzfLWi5gm8Uxya = _0023_003Dzjhyg1Go_003D;
		_0023_003DzpxW3PVv5YfK7 = _0023_003Dz3lURioVh8358;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		_0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D _0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D2 = new _0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D();
		_0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D2._0023_003DzmHS7frs_003D = progress;
		_0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D2._0023_003DzopRx0_MBcTQs = this;
		_0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D2._0023_003Dzjvn7P10_003D = ct;
		_0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D2._0023_003Dzq7HZWkdv9sgCkIodqQ_003D_003D = new List<Entity>();
		if (_0023_003Dz_0024_ydENQ_003D != null)
		{
			HashSet<string> referencedBlocksNames = Utility.GetReferencedBlocksNames(Entities, _0023_003Dz_0024_ydENQ_003D.BaseDictionary, _0023_003DzxVzk1_0024t02Kf9?.BaseDictionary);
			foreach (Block item in _0023_003Dz_0024_ydENQ_003D)
			{
				if (!referencedBlocksNames.Contains(item.Name))
				{
					continue;
				}
				for (int i = 0; i < item.Entities.Count; i++)
				{
					Entity entity = item.Entities[i];
					if (!(entity is BlockReference) && (entity.RegenMode == regenType.RegenAndCompile || (_0023_003DzlBTnqu2ycbP5xEU95A_003D_003D && entity.IsCurved())))
					{
						_0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D2._0023_003Dzq7HZWkdv9sgCkIodqQ_003D_003D.Add(entity);
					}
				}
			}
		}
		foreach (Entity entity2 in Entities)
		{
			if (!(entity2 is BlockReference) && (entity2.RegenMode == regenType.RegenAndCompile || (_0023_003DzlBTnqu2ycbP5xEU95A_003D_003D && entity2.IsCurved())))
			{
				_0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D2._0023_003Dzq7HZWkdv9sgCkIodqQ_003D_003D.Add(entity2);
			}
		}
		_0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D2._0023_003Dz9JZgoew_003D = _0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D2._0023_003Dzq7HZWkdv9sgCkIodqQ_003D_003D.Count;
		_0023_003DzspExml1j72mr_FI04NKW780_003D _0023_003DzspExml1j72mr_FI04NKW780_003D2 = new _0023_003DzspExml1j72mr_FI04NKW780_003D();
		try
		{
			RegenParams._0023_003DzlVfkB344HnlGhuCmUA_003D_003D = true;
			ResetProgressParallel();
			Parallel.For(0, _0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D2._0023_003Dz9JZgoew_003D, _0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D2._0023_003DznNIpgRawjSAVJ7V0bQ_003D_003D);
			RegenParams._0023_003DzlVfkB344HnlGhuCmUA_003D_003D = false;
		}
		finally
		{
			((IDisposable)_0023_003DzspExml1j72mr_FI04NKW780_003D2).Dispose();
		}
		UpdateProgressTo100(_0023_003DzpxW3PVv5YfK7, _0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D2._0023_003DzmHS7frs_003D);
	}

	public override void WorkCompleted(object sender)
	{
		_0023_003DzspExml1j72mr_FI04NKW780_003D _0023_003DzspExml1j72mr_FI04NKW780_003D2 = new _0023_003DzspExml1j72mr_FI04NKW780_003D();
		try
		{
			IWorkspace workspace;
			Document document = GetDocument(sender, out workspace);
			IWorkspaceInternal workspaceInternal = (IWorkspaceInternal)workspace;
			ICursorContainer prev = workspaceInternal?.SetWaitCursor();
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			foreach (Entity entity in Entities)
			{
				if (entity is BlockReference)
				{
					entity.Regen(RegenParams);
				}
			}
			stopwatch.Stop();
			List<Entity> list = new List<Entity>(Entities.Count);
			if (workspaceInternal != null)
			{
				if (workspaceInternal.IsRenderingContextValid())
				{
					workspaceInternal.RenderContext.MakeCurrent();
					CompileParams compileParams = new CompileParams(workspaceInternal)
					{
						Units = _0023_003Dzimj5NR_zLwfo.Units
					};
					foreach (Entity entity2 in Entities)
					{
						if (entity2.RegenMode != regenType.NotNeeded || entity2 is BlockReference)
						{
							compileParams.UpdateLineType(entity2);
							entity2.Compile(compileParams);
							entity2.RegenMode = regenType.NotNeeded;
							list.Add(entity2);
						}
					}
					_0023_003DzXFE1V5dt6zic(workspaceInternal);
				}
				workspaceInternal.RestoreCursor(prev);
				document.isBoundingBoxDirty = true;
			}
			_0023_003Dz5jHG_0024pW1ExeQ();
			_0023_003Dzimj5NR_zLwfo._0023_003DzfRP9c1V6cvLS(list);
			document.Entities.regenTime += base.ExecutionTime + stopwatch.ElapsedMilliseconds;
		}
		finally
		{
			((IDisposable)_0023_003DzspExml1j72mr_FI04NKW780_003D2).Dispose();
		}
	}

	private void _0023_003DzXFE1V5dt6zic(IWorkspaceInternal _0023_003DzImQx0os_003D)
	{
		if (!_0023_003DzImQx0os_003D.RenderContext.CheckOutOfMemory())
		{
			return;
		}
		foreach (Entity entity in Entities)
		{
			if (entity is Picture)
			{
				((Picture)entity)._0023_003DzhM3qURBkRYYd();
			}
		}
		foreach (Block allBlock in _0023_003DzImQx0os_003D.GetAllBlocks())
		{
			foreach (Entity entity2 in allBlock.Entities)
			{
				if (entity2 is Picture)
				{
					((Picture)entity2)._0023_003DzhM3qURBkRYYd();
				}
			}
		}
	}

	private void _0023_003Dz5jHG_0024pW1ExeQ()
	{
		switch (_0023_003Dz6u8_0024MaEVtXJN)
		{
		case (_0023_003DzlvcTzRDO3KSlmsnRkDxEK40P0DoCz3avhw_003D_003D)1:
			_0023_003Dzimj5NR_zLwfo.Entities.baseList.AddRange(Entities);
			break;
		case (_0023_003DzlvcTzRDO3KSlmsnRkDxEK40P0DoCz3avhw_003D_003D)2:
			_0023_003Dzimj5NR_zLwfo.Entities.baseList.InsertRange(_0023_003DzfLWi5gm8Uxya, Entities);
			break;
		case (_0023_003DzlvcTzRDO3KSlmsnRkDxEK40P0DoCz3avhw_003D_003D)3:
			RegenParams.Document.Blocks._0023_003DzgS08WmH_P7At(_0023_003DzfLWi5gm8Uxya, _0023_003Dzimj5NR_zLwfo);
			break;
		}
	}

	internal static bool _0023_003Dz6HH5XmGI_ZT8oAhODOuRNLk_003D(IEnumerable<Entity> _0023_003DzyIjeB1Bf2138, BlockKeyedCollection _0023_003DzJO1FWlQ_003D)
	{
		bool result = false;
		foreach (Entity item in _0023_003DzyIjeB1Bf2138)
		{
			if (item.IsCurved() && item.RegenMode == regenType.RegenAndCompile)
			{
				result = true;
				break;
			}
			if (item is BlockReference blockReference && _0023_003Dz6HH5XmGI_ZT8oAhODOuRNLk_003D(blockReference.GetEntities(_0023_003DzJO1FWlQ_003D), _0023_003DzJO1FWlQ_003D))
			{
				result = true;
				break;
			}
		}
		return result;
	}
}
