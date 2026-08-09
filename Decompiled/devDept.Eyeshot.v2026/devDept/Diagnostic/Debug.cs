using System;
using System.Diagnostics;

namespace devDept.Diagnostic;

internal sealed class Debug
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		internal Debug _0023_003Dz1sAfCMK4w7vO_0024wlTkvPth2M_003D()
		{
			return new Debug();
		}
	}

	public enum errorLevel
	{
		None,
		Warning,
		Error
	}

	private static readonly Lazy<Debug> _instance = new Lazy<Debug>(() => new Debug());

	public static Debug Instance => _instance.Value;

	public errorLevel ErrorLevel { get; set; } = errorLevel.Error;

	private Debug()
	{
	}

	[Conditional("DEBUG")]
	public void Assert(errorLevel errorLevel, bool condition, string message)
	{
	}

	[Conditional("DEBUG")]
	public void Assert(errorLevel errorLevel, bool condition)
	{
	}

	[Conditional("DEBUG")]
	public void Assert(bool condition)
	{
	}

	[Conditional("DEBUG")]
	public void Assert(bool condition, string message)
	{
	}
}
