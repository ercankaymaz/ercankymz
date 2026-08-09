using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using devDept.Diagnostic;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

internal class ParallelConveHull
{
	private sealed class _0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D
	{
		public CancellationTokenSource _0023_003DzTxL9ucy5HWC2;

		public IWorkspaceInternal _0023_003DzImQx0os_003D;

		internal void _0023_003DzyyPQ4NvyB05qsZ_0024JLg_003D_003D()
		{
			try
			{
				if (_0023_003DzTxL9ucy5HWC2 != null)
				{
					BuildConvexHulls(_0023_003DzImQx0os_003D, _0023_003DzTxL9ucy5HWC2.Token);
				}
			}
			catch (ObjectDisposedException)
			{
			}
		}
	}

	private static ParallelConveHull _instance;

	public static object Lock = new object();

	private static CancellationTokenSource cToken = new CancellationTokenSource();

	private static Thread _chBuilder;

	private static IWorkspaceInternal _currentWorkspace;

	public static ParallelConveHull Instance
	{
		get
		{
			if (_instance == null)
			{
				lock (Lock)
				{
					if (_instance == null)
					{
						_instance = new ParallelConveHull();
					}
				}
			}
			return _instance;
		}
	}

	internal static void BuildConvexHulls(object obj, object token)
	{
		IReadOnlyList<Block> readOnlyList = null;
		try
		{
			IWorkspaceInternal workspaceInternal = (IWorkspaceInternal)obj;
			if (_currentWorkspace != null)
			{
				readOnlyList = _currentWorkspace.Blocks.ToArray();
				BlockReference blockReference = workspaceInternal.BuildRootEntity();
				TraversalParams data = new TraversalParams(workspaceInternal);
				blockReference.GetAllVerticesParallel(data, token, out var vertices);
				if (vertices is List<float>)
				{
					vertices.Clear();
				}
			}
		}
		catch (Exception ex)
		{
			Logger.Instance.Warn(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996653), ex.Message, null);
		}
		finally
		{
			if (token != null && ((CancellationToken)token).IsCancellationRequested && _currentWorkspace != null && readOnlyList != null)
			{
				_currentWorkspace.ResetAllConvexHulls(readOnlyList, needStop: false);
			}
			_currentWorkspace = null;
		}
	}

	internal void CreateAndStart(IWorkspaceInternal workspace)
	{
		_0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D CS_0024_003C_003E8__locals6 = new _0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D();
		CS_0024_003C_003E8__locals6._0023_003DzImQx0os_003D = workspace;
		if (IsBusy())
		{
			return;
		}
		if (cToken != null)
		{
			cToken.Dispose();
			cToken = null;
		}
		cToken = new CancellationTokenSource();
		CS_0024_003C_003E8__locals6._0023_003DzTxL9ucy5HWC2 = cToken;
		_currentWorkspace = CS_0024_003C_003E8__locals6._0023_003DzImQx0os_003D;
		_chBuilder = new Thread((ThreadStart)delegate
		{
			try
			{
				if (CS_0024_003C_003E8__locals6._0023_003DzTxL9ucy5HWC2 != null)
				{
					BuildConvexHulls(CS_0024_003C_003E8__locals6._0023_003DzImQx0os_003D, CS_0024_003C_003E8__locals6._0023_003DzTxL9ucy5HWC2.Token);
				}
			}
			catch (ObjectDisposedException)
			{
			}
		});
		_chBuilder.IsBackground = true;
		_chBuilder.Start();
	}

	internal void Stop()
	{
		if (IsBusy())
		{
			cToken.Cancel();
		}
	}

	internal bool IsBusy()
	{
		if (_chBuilder != null)
		{
			return _chBuilder.IsAlive;
		}
		return false;
	}

	public void Dispose(IWorkspace workspace)
	{
		Stop();
		if (cToken != null)
		{
			cToken.Dispose();
			cToken = null;
		}
		_chBuilder = null;
		_currentWorkspace = null;
		_instance = null;
	}
}
