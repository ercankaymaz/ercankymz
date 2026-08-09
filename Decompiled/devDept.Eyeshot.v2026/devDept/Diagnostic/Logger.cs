using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using Microsoft.Win32;

namespace devDept.Diagnostic;

public class Logger
{
	public const string TraceSwitchName = "Eyeshot";

	internal ConcurrentStack<bool> stack = new ConcurrentStack<bool>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly object _0023_003DzBOqDR2I_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Timer _0023_003DzkXlmnO_cDtIy;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz8iYj2iqT3kfY = 1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzKj3W1hruFCrkxgTmyQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static bool _0023_003DzRDMY4H9IbJKH;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static string _0023_003DzNv6yypiVkkVx;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static Logger _0023_003DzIup502u0eoYJ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzcuttDEL8jIrAREduXQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzMAwxuaPlkGJ_BdB1Tg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextWriterTraceListener _0023_003Dz4ox0SqU1OIXYH1_WwvT3XOc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TraceSwitch _0023_003Dzk3SUY0QrzqZmR5EoAim31m0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzbPvzt_0024R_7nq2gCN0Oe9UUbo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzG7vPczRWJC2vSI2tsEBBLMk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DziCnG_0024t0XeSHRQsyv0i3tBL4_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dzb_T69QqF4a0iy7WeUfa7p0o_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dzwau2P9NUFLgyaTMonYhGrdqUlFe7ufFPVw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzTN7ut6NLAlW4 = Path.GetTempPath();

	public static string TargetFramework
	{
		get
		{
			if (string.IsNullOrEmpty(_0023_003DzNv6yypiVkkVx))
			{
				_0023_003DzNv6yypiVkkVx = _0023_003DzrAQqyBEtPDAm();
			}
			return _0023_003DzNv6yypiVkkVx;
		}
	}

	public static Logger Instance
	{
		get
		{
			if (_0023_003DzIup502u0eoYJ == null)
			{
				lock (_0023_003DzBOqDR2I_003D)
				{
					_0023_003DzIup502u0eoYJ = new Logger();
				}
			}
			return _0023_003DzIup502u0eoYJ;
		}
		set
		{
			_0023_003DzIup502u0eoYJ = value;
			_0023_003DzIup502u0eoYJ._0023_003DzITipwO3ayF1t();
		}
	}

	public string Id
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzcuttDEL8jIrAREduXQ_003D_003D;
		}
	}

	public string FilePath
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzMAwxuaPlkGJ_BdB1Tg_003D_003D;
		}
	}

	public TextWriterTraceListener TextWriterTraceListener
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz4ox0SqU1OIXYH1_WwvT3XOc_003D;
		}
	}

	public TraceLevel TraceLevel
	{
		get
		{
			return TraceSwitch.Level;
		}
		set
		{
			TraceSwitch.Level = value;
		}
	}

	public TraceSwitch TraceSwitch
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzk3SUY0QrzqZmR5EoAim31m0_003D;
		}
	}

	public bool AutoFlush
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzbPvzt_0024R_7nq2gCN0Oe9UUbo_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzbPvzt_0024R_7nq2gCN0Oe9UUbo_003D = value;
		}
	}

	public bool AddTraceLevel
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzG7vPczRWJC2vSI2tsEBBLMk_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzG7vPczRWJC2vSI2tsEBBLMk_003D = value;
		}
	}

	public bool AddThreadId
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DziCnG_0024t0XeSHRQsyv0i3tBL4_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DziCnG_0024t0XeSHRQsyv0i3tBL4_003D = value;
		}
	}

	public bool DisplayDiagnosticInfo
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzb_T69QqF4a0iy7WeUfa7p0o_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzb_T69QqF4a0iy7WeUfa7p0o_003D = value;
		}
	}

	public bool CaptureBackbufferImages
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzwau2P9NUFLgyaTMonYhGrdqUlFe7ufFPVw_003D_003D;
		}
	}

	internal static bool IsVirtualMachine => _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003Dzlm7c5zkiTFZY();

	protected Logger(string filePath = null)
	{
		_0023_003DzI0sNHiP50DLiKv1mVw_003D_003D();
		_0023_003DzF_0024uMrPo_003D(_0023_003DzqHAhL22g_0024Ro6());
		_0023_003DzITipwO3ayF1t();
		if (string.IsNullOrEmpty(filePath))
		{
			filePath = GetFullPath();
		}
		_0023_003Dzx2KzSAV_00249k6c(filePath);
		_0023_003DzO3bLyaDyuYn0PG_0024gyw_003D_003D(new TextWriterTraceListener(filePath));
	}

	protected Logger(TextWriterTraceListener traceListener)
	{
		_0023_003DzF_0024uMrPo_003D(_0023_003DzqHAhL22g_0024Ro6());
		_0023_003DzO3bLyaDyuYn0PG_0024gyw_003D_003D(traceListener);
	}

	static Logger()
	{
		_0023_003DzBOqDR2I_003D = new object();
		_0023_003DzRDMY4H9IbJKH = true;
		TraceLevel.Off.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942532));
		TraceLevel.Error.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302933314));
		TraceLevel.Warning.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942544));
		TraceLevel.Info.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942524));
		TraceLevel.Verbose.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942504));
	}

	[DllImport("kernel32.dll", EntryPoint = "CheckRemoteDebuggerPresent", ExactSpelling = true, SetLastError = true)]
	private static extern bool _0023_003Dzw3k1rs2fa8njP0nLLQ_003D_003D(IntPtr _0023_003Dz_0024V_0024IO70_003D, ref bool _0023_003DzWNyLoL7UU_AJ);

	private void _0023_003DzI0sNHiP50DLiKv1mVw_003D_003D()
	{
		if (_0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzZ4RB3Lo_003D() && _0023_003DzkXlmnO_cDtIy == null)
		{
			_0023_003DzKj3W1hruFCrkxgTmyQ_003D_003D = true;
			_0023_003DzkXlmnO_cDtIy = new Timer(_0023_003DzcOSgvcclIqq0M3zDIg_003D_003D, null, 0, new Random().Next(30000, 45000));
		}
	}

	private void _0023_003DzKJPSsjBwBZQ9hScRxg_003D_003D()
	{
		if (_0023_003Dz8iYj2iqT3kfY++ < 3)
		{
			return;
		}
		lock (_0023_003DzBOqDR2I_003D)
		{
			if (_0023_003DzkXlmnO_cDtIy != null)
			{
				_0023_003DzkXlmnO_cDtIy.Dispose();
				_0023_003DzkXlmnO_cDtIy = null;
			}
		}
	}

	private void _0023_003DzcOSgvcclIqq0M3zDIg_003D_003D(object _0023_003DzDVQ8830_003D)
	{
		if (_0023_003DzKj3W1hruFCrkxgTmyQ_003D_003D)
		{
			_0023_003DzKj3W1hruFCrkxgTmyQ_003D_003D = false;
			return;
		}
		bool _0023_003DzWNyLoL7UU_AJ = false;
		_0023_003Dzw3k1rs2fa8njP0nLLQ_003D_003D(Process.GetCurrentProcess().Handle, ref _0023_003DzWNyLoL7UU_AJ);
		if (!Debugger.IsAttached && _0023_003DzWNyLoL7UU_AJ)
		{
			string text = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942484);
			LicenseManager._0023_003Dzkbdl2RNkTQTU(text, TraceLevel.Error, null, _0023_003DzHmsOmLY94V0f: false, Array.Empty<object>());
			throw new InvalidProgramException(text);
		}
		_0023_003DzKJPSsjBwBZQ9hScRxg_003D_003D();
	}

	public virtual string GetSeparator()
	{
		return _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942697);
	}

	protected virtual string GetDateTimeStamp()
	{
		return DateTime.Now.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942673));
	}

	public void WriteHeader()
	{
		if (TraceLevel == TraceLevel.Off || !_0023_003DzRDMY4H9IbJKH)
		{
			return;
		}
		lock (_0023_003DzBOqDR2I_003D)
		{
			TextWriterTraceListener.WriteLine(GetHeader());
			if (AutoFlush)
			{
				TextWriterTraceListener.Flush();
			}
			_0023_003DzRDMY4H9IbJKH = false;
		}
	}

	protected virtual string GetHeader()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942671), Environment.NewLine);
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942635));
		stringBuilder.Append(Environment.NewLine);
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942602), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003Dza3BieSHRZK7Z(), Environment.NewLine);
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942309), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzbGvrdyt7by7T(), Environment.NewLine);
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942275), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzicLNfd33jEjb(), Environment.NewLine);
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942272), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003Dzlm7c5zkiTFZY(), Environment.NewLine);
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942239), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzeTIsp4Ooi8lL(), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzfbXOzDxH6Z_0024a(), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzMfKgRw7F1f2h(), Environment.NewLine);
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942418), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzTuk_iclLOM33(), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzyrqdQjli9uKcXInNBd66ApI_003D(), Environment.NewLine);
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942397), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003Dz4yWVTg1plnOc(), Environment.NewLine);
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942367), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzpGG_0024Ipk_003D(), Environment.NewLine);
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943100), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzFOoE2Be_Yg2w(), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzhL9h92JdQOi_0024(), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003Dz0ywXAPnoF8lOhG1o_A_003D_003D(), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003Dz3pCX6JkY44Lf(), Environment.NewLine);
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943047), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzWYJYcM4y_dd7(), Environment.NewLine);
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943038), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzSkIfvE5iHtmEVbByYQ_003D_003D(), Environment.NewLine);
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943005), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzxqZyt2yBlJt7Y7E6kA_003D_003D(), Environment.NewLine);
		stringBuilder.Append(Environment.NewLine);
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943231), Environment.NewLine);
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942635));
		stringBuilder.Append(Environment.NewLine);
		List<string> list = _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzoaVOmA4wI3ru();
		for (int i = 0; i < list.Count; i++)
		{
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943193), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzoaVOmA4wI3ru()[i], Environment.NewLine);
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943182), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003Dzzw_0024WpbQpVUwL()[i], Environment.NewLine);
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943143), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003Dzfpx0mEVA8L3N()[i], Environment.NewLine);
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943135), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzrDUVrUzVx5zN()[i], Environment.NewLine);
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942840), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzD2l7RWdyUv_u()[i], Environment.NewLine);
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942809), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzAk0PDG_p7OarWISZBg_003D_003D()[i], Environment.NewLine);
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942771), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003Dzl6O_00242t_ddMSb()[i], Environment.NewLine);
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943047), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzHpy4vdxlCEjF()[i], Environment.NewLine);
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942738), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzTxhd_mFqONca()[i], Environment.NewLine);
			stringBuilder.Append(Environment.NewLine);
		}
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942732), Environment.NewLine);
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942635));
		stringBuilder.Append(Environment.NewLine);
		List<string[]> list2 = _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzEtoW85hrfAy0();
		for (int j = 0; j < list2.Count; j++)
		{
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942952), list2[j][0], Environment.NewLine);
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943193), list2[j][1], Environment.NewLine);
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942738), list2[j][2], Environment.NewLine);
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942937), list2[j][3], Environment.NewLine);
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942899), list2[j][4], Environment.NewLine);
			stringBuilder.Append(Environment.NewLine);
		}
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942887), Environment.NewLine);
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942635));
		stringBuilder.Append(Environment.NewLine);
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942853), TargetFramework, Environment.NewLine);
		stringBuilder.Append(Environment.NewLine);
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943590), Environment.NewLine);
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942635));
		return stringBuilder.ToString();
	}

	private static string _0023_003DzrAQqyBEtPDAm()
	{
		try
		{
			object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(TargetFrameworkAttribute), inherit: false);
			if (customAttributes.Length != 0)
			{
				return ((TargetFrameworkAttribute)customAttributes[0]).FrameworkName;
			}
		}
		catch
		{
		}
		return string.Empty;
	}

	public virtual void Trace(string message, params object[] args)
	{
		_0023_003Dz_0024ph8454_003D(TraceLevel.Verbose, message, null, args);
	}

	public virtual void Info(string message, params object[] args)
	{
		_0023_003Dz_0024ph8454_003D(TraceLevel.Info, message, null, args);
	}

	public virtual void Warn(string message, Exception exception = null, params object[] args)
	{
		_0023_003Dz_0024ph8454_003D(TraceLevel.Warning, message, exception, args);
	}

	public virtual void Error(string message, Exception exception = null, params object[] args)
	{
		_0023_003Dz_0024ph8454_003D(TraceLevel.Error, message, exception, args);
	}

	public virtual void Stop()
	{
		TextWriterTraceListener.Close();
	}

	private void _0023_003DzITipwO3ayF1t()
	{
		AutoFlush = true;
		AddTraceLevel = true;
		AddThreadId = true;
		DisplayDiagnosticInfo = true;
		_0023_003Dzu_0024lkZJZENqgaZo5zUcRgMfHXSCX9(_0023_003DzPzO_0024GUk_003D: false);
		string text = string.Empty;
		int num = 0;
		foreach (object value in Enum.GetValues(typeof(TraceLevel)))
		{
			text = text + num.ToString(CultureInfo.InvariantCulture) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302928532) + value;
			num++;
		}
		_0023_003DzE7MLPYoNq9xQ(new TraceSwitch(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943569), text, 0.ToString()));
		if (_0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzZ4RB3Lo_003D() && !_0023_003DzSA8DrX2t5EJNagJKSQ_003D_003D(RegistryHive.LocalMachine))
		{
			_0023_003DzSA8DrX2t5EJNagJKSQ_003D_003D(RegistryHive.CurrentUser);
		}
	}

	private bool _0023_003DzSA8DrX2t5EJNagJKSQ_003D_003D(RegistryHive _0023_003DzsyJLfXn0mVGW)
	{
		try
		{
			using RegistryKey registryKey = RegistryKey.OpenBaseKey(_0023_003DzsyJLfXn0mVGW, RegistryView.Registry64);
			using RegistryKey registryKey2 = registryKey.OpenSubKey(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943583), writable: false);
			if (registryKey2 != null)
			{
				if (Convert.ToInt32(registryKey2.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943532), -1)) == 1)
				{
					TraceSwitch.Level = TraceLevel.Verbose;
				}
				string path = (string)registryKey2.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943514));
				if (Directory.Exists(path))
				{
					_0023_003DzTN7ut6NLAlW4 = path;
				}
				int num = Convert.ToInt32(registryKey2.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943500), -1));
				_0023_003Dzu_0024lkZJZENqgaZo5zUcRgMfHXSCX9(num == 1);
				return true;
			}
		}
		catch
		{
		}
		return false;
	}

	private void _0023_003DzF_0024uMrPo_003D(string _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzcuttDEL8jIrAREduXQ_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003Dzx2KzSAV_00249k6c(string _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzMAwxuaPlkGJ_BdB1Tg_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003DzO3bLyaDyuYn0PG_0024gyw_003D_003D(TextWriterTraceListener _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dz4ox0SqU1OIXYH1_WwvT3XOc_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003DzE7MLPYoNq9xQ(TraceSwitch _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dzk3SUY0QrzqZmR5EoAim31m0_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003Dzu_0024lkZJZENqgaZo5zUcRgMfHXSCX9(bool _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dzwau2P9NUFLgyaTMonYhGrdqUlFe7ufFPVw_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public string GetFullPath()
	{
		string path = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943722), Id) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943682);
		return Path.Combine(_0023_003DzTN7ut6NLAlW4, path);
	}

	private void _0023_003DzCAgMvDE_003D(ref string _0023_003DzuahRn9M_003D, string _0023_003Dz2QVVx8s_003D)
	{
		if (!string.IsNullOrEmpty(_0023_003Dz2QVVx8s_003D))
		{
			_0023_003DzuahRn9M_003D = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943691), _0023_003Dz2QVVx8s_003D, _0023_003DzuahRn9M_003D);
		}
	}

	public void Trace(string instanceId, string message, params object[] args)
	{
		_0023_003DzCAgMvDE_003D(ref message, instanceId);
		Trace(message, args);
	}

	public void Info(string instanceId, string message, params object[] args)
	{
		_0023_003DzCAgMvDE_003D(ref message, instanceId);
		Info(message, args);
	}

	public void Warn(string instanceId, string message, Exception exception = null, params object[] args)
	{
		_0023_003DzCAgMvDE_003D(ref message, instanceId);
		Warn(message, exception, args);
	}

	public void Error(string instanceId, string message, Exception exception = null, params object[] args)
	{
		_0023_003DzCAgMvDE_003D(ref message, instanceId);
		Error(message, exception, args);
	}

	private void _0023_003DzL_WT7sd23Mr1(ref string _0023_003DzuahRn9M_003D, string _0023_003Dz9lrNnXY_003D)
	{
		if (!string.IsNullOrEmpty(_0023_003Dz9lrNnXY_003D))
		{
			_0023_003DzuahRn9M_003D = _0023_003DzuahRn9M_003D + _0023_003Dz9lrNnXY_003D + GetSeparator();
		}
	}

	private void _0023_003Dz_0024ph8454_003D(TraceLevel _0023_003DzLC4gNyPZPfnJ, string _0023_003DzuahRn9M_003D, Exception _0023_003DzSQYc_0024aE_003D, object[] _0023_003Dz53Cncpw_003D)
	{
		if (_0023_003DzLC4gNyPZPfnJ switch
		{
			TraceLevel.Off => 0, 
			TraceLevel.Error => TraceSwitch.TraceError ? 1 : 0, 
			TraceLevel.Warning => TraceSwitch.TraceWarning ? 1 : 0, 
			TraceLevel.Info => TraceSwitch.TraceInfo ? 1 : 0, 
			TraceLevel.Verbose => TraceSwitch.TraceVerbose ? 1 : 0, 
			_ => throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943675), _0023_003DzLC4gNyPZPfnJ, null), 
		} == 0)
		{
			return;
		}
		string _0023_003DzuahRn9M_003D2 = string.Empty;
		_0023_003DzL_WT7sd23Mr1(ref _0023_003DzuahRn9M_003D2, GetDateTimeStamp());
		if (AddTraceLevel)
		{
			_0023_003DzL_WT7sd23Mr1(ref _0023_003DzuahRn9M_003D2, _0023_003DzLC4gNyPZPfnJ.GetDisplayName());
		}
		if (AddThreadId)
		{
			_0023_003DzL_WT7sd23Mr1(ref _0023_003DzuahRn9M_003D2, string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943656), Thread.CurrentThread.ManagedThreadId.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943639))));
		}
		_0023_003DzuahRn9M_003D2 += string.Format(_0023_003DzuahRn9M_003D, _0023_003Dz53Cncpw_003D);
		if (_0023_003DzSQYc_0024aE_003D != null)
		{
			_0023_003DzuahRn9M_003D2 += FormatExceptionDetails(_0023_003DzSQYc_0024aE_003D);
		}
		lock (_0023_003DzBOqDR2I_003D)
		{
			TextWriterTraceListener.WriteLine(_0023_003DzuahRn9M_003D2);
			if (AutoFlush)
			{
				TextWriterTraceListener.Flush();
			}
		}
	}

	public static string FormatExceptionDetails(Exception exception)
	{
		if (exception == null)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943618));
		stringBuilder.AppendLine();
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943353) + exception.Message);
		if (!string.IsNullOrEmpty(exception.StackTrace))
		{
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943337));
			stringBuilder.AppendLine(exception.StackTrace);
		}
		for (Exception innerException = exception.InnerException; innerException != null; innerException = innerException.InnerException)
		{
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943326));
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943353) + innerException.Message);
			if (!string.IsNullOrEmpty(innerException.StackTrace))
			{
				stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943337));
				stringBuilder.AppendLine(innerException.StackTrace);
			}
		}
		return stringBuilder.ToString();
	}

	internal void _0023_003DzFiehT2bxdiSS()
	{
		StringBuilder stringBuilder = new StringBuilder(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943283));
		stringBuilder.AppendLine();
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		foreach (Assembly assembly in assemblies)
		{
			stringBuilder.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943278), assembly.GetName().Name, assembly.GetName().Version));
		}
		Instance.Info(stringBuilder.ToString());
	}

	private static string _0023_003DzqHAhL22g_0024Ro6()
	{
		lock (_0023_003DzBOqDR2I_003D)
		{
			return Math.Abs(DateTime.Now.GetHashCode()).ToString(CultureInfo.InvariantCulture).PadLeft(10, '0')
				.Substring(0, 10);
		}
	}
}
