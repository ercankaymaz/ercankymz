using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using devDept.Diagnostic;
using devDept.Eyeshot;
using devDept.Eyeshot.Translators;

namespace devDept;

public abstract class WorkUnit
{
	private sealed class _0023_003DzU7XLWnOqvQmgH9KjAOtFPZU_003D
	{
		public WorkUnit _0023_003DzopRx0_MBcTQs;

		public IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D;

		public CancellationToken _0023_003Dzjvn7P10_003D;

		internal void _0023_003Dz6w2_0024wKGhtFt8_GeHHA_003D_003D()
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			try
			{
				_0023_003DzopRx0_MBcTQs.DoWork(_0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
				_0023_003Dzjvn7P10_003D.ThrowIfCancellationRequested();
			}
			finally
			{
				stopwatch.Stop();
				_0023_003DzopRx0_MBcTQs.ExecutionTime = stopwatch.ElapsedMilliseconds;
			}
		}
	}

	public class ProgressChangedEventArgs : EventArgs
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly int _0023_003DzrKZuMRhiThdyhY0wrA_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly string _0023_003Dz18SZ2wIYdiPeUxfV1A_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly bool _0023_003DzD0o53mu2jEWqXkLQlA_003D_003D;

		public int Progress
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzrKZuMRhiThdyhY0wrA_003D_003D;
			}
		}

		public string Text
		{
			[CompilerGenerated]
			get
			{
				return _0023_003Dz18SZ2wIYdiPeUxfV1A_003D_003D;
			}
		}

		public bool Continuous
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzD0o53mu2jEWqXkLQlA_003D_003D;
			}
		}

		public ProgressChangedEventArgs(int progress)
			: this(progress, string.Empty)
		{
		}

		public ProgressChangedEventArgs(int progress, string text)
			: this(progress, text ?? string.Empty, continuous: false)
		{
		}

		public ProgressChangedEventArgs(int progress, string text, bool continuous)
		{
			_0023_003DzrKZuMRhiThdyhY0wrA_003D_003D = progress;
			_0023_003Dz18SZ2wIYdiPeUxfV1A_003D_003D = text ?? string.Empty;
			_0023_003DzD0o53mu2jEWqXkLQlA_003D_003D = continuous;
		}
	}

	public delegate void ProgressChangedEventHandler(object sender, ProgressChangedEventArgs e);

	public delegate void WorkCancelledEventHandler(object sender, WorkUnitEventArgs e);

	public delegate void WorkCompletedEventHandler(object sender, WorkCompletedEventArgs e);

	public delegate void WorkFailedEventHandler(object sender, WorkFailedEventArgs e);

	protected internal readonly StringBuilder log = new StringBuilder();

	public const int HighestNumberOfTicks = 32;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private workUnitStatus _0023_003DzfNYog74CXZibVCAj4A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private long _0023_003Dz_0024ZukcP24GWNO78zfjA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ProgressChangedEventHandler _0023_003DzVNCWkQY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DziWg05X5joI_m;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzlFwho03b5EoSOfdm6w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly object _0023_003DzI4Ll7sdKBG9hYkzz2UCY_Us_003D = new object();

	public string Log => log.ToString();

	public workUnitStatus Status
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzfNYog74CXZibVCAj4A_003D_003D;
		}
		[CompilerGenerated]
		internal set
		{
			_0023_003DzfNYog74CXZibVCAj4A_003D_003D = value;
		}
	}

	public long ExecutionTime
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz_0024ZukcP24GWNO78zfjA_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz_0024ZukcP24GWNO78zfjA_003D_003D = value;
		}
	}

	[Obsolete("Legacy event-based progress notification. Prefer IProgress<ProgressChangedEventArgs> (e.g., WorkUnit.DoWorkAsync(IProgress<ProgressChangedEventArgs>, CancellationToken) or Workspace.DoWorkAsync(Progress<ProgressChangedEventArgs>, ...)).")]
	public event ProgressChangedEventHandler ProgressChanged
	{
		[CompilerGenerated]
		add
		{
			ProgressChangedEventHandler progressChangedEventHandler = _0023_003DzVNCWkQY_003D;
			ProgressChangedEventHandler progressChangedEventHandler2;
			do
			{
				progressChangedEventHandler2 = progressChangedEventHandler;
				ProgressChangedEventHandler value2 = (ProgressChangedEventHandler)Delegate.Combine(progressChangedEventHandler2, value);
				progressChangedEventHandler = Interlocked.CompareExchange(ref _0023_003DzVNCWkQY_003D, value2, progressChangedEventHandler2);
			}
			while ((object)progressChangedEventHandler != progressChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ProgressChangedEventHandler progressChangedEventHandler = _0023_003DzVNCWkQY_003D;
			ProgressChangedEventHandler progressChangedEventHandler2;
			do
			{
				progressChangedEventHandler2 = progressChangedEventHandler;
				ProgressChangedEventHandler value2 = (ProgressChangedEventHandler)Delegate.Remove(progressChangedEventHandler2, value);
				progressChangedEventHandler = Interlocked.CompareExchange(ref _0023_003DzVNCWkQY_003D, value2, progressChangedEventHandler2);
			}
			while ((object)progressChangedEventHandler != progressChangedEventHandler2);
		}
	}

	static WorkUnit()
	{
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "U](2lq\"ab4", null);
	}

	public void AppendToLog(string message)
	{
		log.AppendLine(message);
	}

	private void _0023_003Dzny5USPGkEnbq()
	{
		if (!(this is Regeneration))
		{
			Telemetry.moduleType _0023_003DzEKSHIVc_003D = ((this is ReadFileAsync || this is WriteFileAsync) ? Telemetry.moduleType.Translators : Telemetry.moduleType.WorkUnit);
			Telemetry.Instance.AddUsage(this, _0023_003DzEKSHIVc_003D);
		}
	}

	public virtual void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
	}

	public void DoWork()
	{
		_0023_003Dzny5USPGkEnbq();
		Stopwatch stopwatch = Stopwatch.StartNew();
		try
		{
			DoWork(null, CancellationToken.None);
		}
		finally
		{
			stopwatch.Stop();
			ExecutionTime = stopwatch.ElapsedMilliseconds;
		}
	}

	public Task DoWorkAsync(IProgress<ProgressChangedEventArgs> progress = null, CancellationToken ct = default(CancellationToken))
	{
		_0023_003DzU7XLWnOqvQmgH9KjAOtFPZU_003D CS_0024_003C_003E8__locals9 = new _0023_003DzU7XLWnOqvQmgH9KjAOtFPZU_003D();
		CS_0024_003C_003E8__locals9._0023_003DzopRx0_MBcTQs = this;
		CS_0024_003C_003E8__locals9._0023_003DzmHS7frs_003D = progress;
		CS_0024_003C_003E8__locals9._0023_003Dzjvn7P10_003D = ct;
		_0023_003Dzny5USPGkEnbq();
		return Task.Run(delegate
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			try
			{
				CS_0024_003C_003E8__locals9._0023_003DzopRx0_MBcTQs.DoWork(CS_0024_003C_003E8__locals9._0023_003DzmHS7frs_003D, CS_0024_003C_003E8__locals9._0023_003Dzjvn7P10_003D);
				CS_0024_003C_003E8__locals9._0023_003Dzjvn7P10_003D.ThrowIfCancellationRequested();
			}
			finally
			{
				stopwatch.Stop();
				CS_0024_003C_003E8__locals9._0023_003DzopRx0_MBcTQs.ExecutionTime = stopwatch.ElapsedMilliseconds;
			}
		}, CS_0024_003C_003E8__locals9._0023_003Dzjvn7P10_003D);
	}

	protected Document GetDocument(object sender, out IWorkspace workspace)
	{
		Document result;
		if (sender is Document document)
		{
			result = document;
			workspace = document.workspace;
		}
		else
		{
			if (!(sender is IWorkspace workspace2))
			{
				throw new EyeshotException(sender.GetType().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996547));
			}
			result = workspace2.Document;
			workspace = workspace2;
		}
		return result;
	}

	public virtual void WorkCompleted(object sender)
	{
	}

	public virtual void WorkCancelled(object sender)
	{
	}

	public virtual void WorkFailed(object sender)
	{
	}

	public bool UpdateProgressAndCheckCancelled(double current, double total, string text, IProgress<ProgressChangedEventArgs> progress, CancellationToken ct, params string[] args)
	{
		if (total > 0.0)
		{
			UpdateProgress(current, total, text, progress, args);
		}
		return !Cancelled(ct);
	}

	public void UpdateProgress(double current, double total, string text, IProgress<ProgressChangedEventArgs> progress, params string[] args)
	{
		if (total <= 0.0)
		{
			return;
		}
		int num = Math.Max(0, Math.Min(100, (int)(100.0 * current / total)));
		if (num == _0023_003DziWg05X5joI_m)
		{
			return;
		}
		_0023_003DziWg05X5joI_m = num;
		string text2 = _0023_003DzKs_U_XqFUbbj(text, args);
		ProgressChangedEventArgs e = new ProgressChangedEventArgs(num, text2);
		try
		{
			if (progress != null)
			{
				progress.Report(e);
			}
			else
			{
				_0023_003DzVNCWkQY_003D?.Invoke(this, e);
			}
		}
		catch
		{
		}
	}

	private static string _0023_003DzKs_U_XqFUbbj(string _0023_003DzwyYng5o_003D, string[] _0023_003Dz53Cncpw_003D)
	{
		if (_0023_003Dz53Cncpw_003D != null && _0023_003Dz53Cncpw_003D.Length != 0)
		{
			return string.Format(_0023_003DzwyYng5o_003D, _0023_003Dz53Cncpw_003D);
		}
		return Regex.Replace(_0023_003DzwyYng5o_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302673856), string.Empty);
	}

	protected internal void StartContinuousAnimation(string text, IProgress<ProgressChangedEventArgs> progress, params string[] args)
	{
		progress?.Report(new ProgressChangedEventArgs(0, _0023_003DzKs_U_XqFUbbj(text, args), continuous: true));
	}

	protected internal void StopContinuousAnimation(IProgress<ProgressChangedEventArgs> progress)
	{
		progress?.Report(new ProgressChangedEventArgs(0, string.Empty, continuous: true));
	}

	protected internal void UpdateProgressTo100(string text, IProgress<ProgressChangedEventArgs> progress, params string[] args)
	{
		UpdateProgress(100.0, 100.0, text, progress, args);
	}

	public void ResetProgress()
	{
		_0023_003DziWg05X5joI_m = -1;
	}

	protected internal void UpdateProgressParallel(double total, string text, IProgress<ProgressChangedEventArgs> progress, params string[] args)
	{
		lock (_0023_003DzI4Ll7sdKBG9hYkzz2UCY_Us_003D)
		{
			_0023_003DzlFwho03b5EoSOfdm6w_003D_003D++;
			UpdateProgress(_0023_003DzlFwho03b5EoSOfdm6w_003D_003D, total, text, progress, args);
		}
	}

	public bool UpdateProgressAndCheckCancelledParallel(double total, string text, IProgress<ProgressChangedEventArgs> progress, CancellationToken ct, params string[] args)
	{
		UpdateProgressParallel(total, text, progress, args);
		return !Cancelled(ct);
	}

	protected internal void ResetProgressParallel(int startIndex = 0)
	{
		_0023_003DzlFwho03b5EoSOfdm6w_003D_003D = startIndex;
	}

	public bool Cancelled(CancellationToken ct)
	{
		return ct.IsCancellationRequested;
	}
}
