using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

[TypeConverter(typeof(ExpandableObjectConverter))]
public class GlobalStrings : GlobalId
{
	private static readonly string DEFAULT_OK = "OK";

	private static readonly string DEFAULT_CANCEL = "Cancel";

	private static readonly string DEFAULT_YES = "Yes";

	private static readonly string DEFAULT_NO = "No";

	private static readonly string DEFAULT_ABORT = "Abort";

	private static readonly string DEFAULT_RETRY = "Retry";

	private static readonly string DEFAULT_IGNORE = "Ignore";

	private static readonly string DEFAULT_CLOSE = "Close";

	private static readonly string DEFAULT_TODAY = "Today";

	private string _ok;

	private string _cancel;

	private string _yes;

	private string _no;

	private string _abort;

	private string _retry;

	private string _ignore;

	private string _close;

	private string _today;

	[Browsable(false)]
	public bool IsDefault => _ok.Equals(DEFAULT_OK) && _cancel.Equals(DEFAULT_CANCEL) && _yes.Equals(DEFAULT_YES) && _no.Equals(DEFAULT_NO) && _abort.Equals(DEFAULT_ABORT) && _retry.Equals(DEFAULT_RETRY) && _ignore.Equals(DEFAULT_IGNORE) && _close.Equals(DEFAULT_CLOSE) && _today.Equals(DEFAULT_CLOSE);

	[Localizable(true)]
	[Category("Visuals")]
	[Description("OK string used for message box buttons.")]
	[DefaultValue("OK")]
	[RefreshProperties(RefreshProperties.All)]
	public string OK
	{
		get
		{
			return _ok;
		}
		set
		{
			_ok = value;
		}
	}

	[Localizable(true)]
	[Category("Visuals")]
	[Description("Cancel string used for message box buttons.")]
	[DefaultValue("Cancel")]
	[RefreshProperties(RefreshProperties.All)]
	public string Cancel
	{
		get
		{
			return _cancel;
		}
		set
		{
			_cancel = value;
		}
	}

	[Localizable(true)]
	[Category("Visuals")]
	[Description("Yes string used for message box buttons.")]
	[DefaultValue("Yes")]
	[RefreshProperties(RefreshProperties.All)]
	public string Yes
	{
		get
		{
			return _yes;
		}
		set
		{
			_yes = value;
		}
	}

	[Localizable(true)]
	[Category("Visuals")]
	[Description("No string used for message box buttons.")]
	[DefaultValue("No")]
	[RefreshProperties(RefreshProperties.All)]
	public string No
	{
		get
		{
			return _no;
		}
		set
		{
			_no = value;
		}
	}

	[Localizable(true)]
	[Category("Visuals")]
	[Description("Abort string used for message box buttons.")]
	[DefaultValue("Abort")]
	[RefreshProperties(RefreshProperties.All)]
	public string Abort
	{
		get
		{
			return _abort;
		}
		set
		{
			_abort = value;
		}
	}

	[Localizable(true)]
	[Category("Visuals")]
	[Description("Retry string used for message box buttons.")]
	[DefaultValue("Retry")]
	[RefreshProperties(RefreshProperties.All)]
	public string Retry
	{
		get
		{
			return _retry;
		}
		set
		{
			_retry = value;
		}
	}

	[Localizable(true)]
	[Category("Visuals")]
	[Description("Ignore string used for message box buttons.")]
	[DefaultValue("Ignore")]
	[RefreshProperties(RefreshProperties.All)]
	public string Ignore
	{
		get
		{
			return _ignore;
		}
		set
		{
			_ignore = value;
		}
	}

	[Localizable(true)]
	[Category("Visuals")]
	[Description("Close string used for message box buttons.")]
	[DefaultValue("Close")]
	[RefreshProperties(RefreshProperties.All)]
	public string Close
	{
		get
		{
			return _close;
		}
		set
		{
			_close = value;
		}
	}

	[Localizable(true)]
	[Category("Visuals")]
	[Description("Today string used for calendars.")]
	[DefaultValue("Today")]
	[RefreshProperties(RefreshProperties.All)]
	public string Today
	{
		get
		{
			return _today;
		}
		set
		{
			_today = value;
		}
	}

	public GlobalStrings()
	{
		Reset();
	}

	public override string ToString()
	{
		if (!IsDefault)
		{
			return "Modified";
		}
		return string.Empty;
	}

	public void Reset()
	{
		_ok = DEFAULT_OK;
		_cancel = DEFAULT_CANCEL;
		_yes = DEFAULT_YES;
		_no = DEFAULT_NO;
		_abort = DEFAULT_ABORT;
		_retry = DEFAULT_RETRY;
		_ignore = DEFAULT_IGNORE;
		_close = DEFAULT_CLOSE;
		_today = DEFAULT_TODAY;
	}
}
