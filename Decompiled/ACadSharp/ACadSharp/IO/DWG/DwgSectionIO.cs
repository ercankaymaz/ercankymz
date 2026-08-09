using System;

namespace ACadSharp.IO.DWG;

internal abstract class DwgSectionIO
{
	protected bool R13_14Only;

	protected bool R13_15Only;

	protected bool R2000Plus;

	protected bool R2004Pre;

	protected bool R2007Pre;

	protected bool R2004Plus;

	protected bool R2007Plus;

	protected bool R2010Plus;

	protected bool R2013Plus;

	protected bool R2018Plus;

	protected readonly ACadVersion _version;

	public abstract string SectionName { get; }

	public event NotificationEventHandler OnNotification;

	public DwgSectionIO(ACadVersion version)
	{
		_version = version;
		R13_14Only = version == ACadVersion.AC1014 || version == ACadVersion.AC1012;
		R13_15Only = version >= ACadVersion.AC1012 && version <= ACadVersion.AC1015;
		R2000Plus = version >= ACadVersion.AC1015;
		R2004Pre = version < ACadVersion.AC1018;
		R2007Pre = version <= ACadVersion.AC1021;
		R2004Plus = version >= ACadVersion.AC1018;
		R2007Plus = version >= ACadVersion.AC1021;
		R2010Plus = version >= ACadVersion.AC1024;
		R2013Plus = version >= ACadVersion.AC1027;
		R2018Plus = version >= ACadVersion.AC1032;
	}

	public static bool CheckSentinel(byte[] actual, byte[] expected)
	{
		if (expected.Length != actual.Length)
		{
			return false;
		}
		for (int i = 0; i < expected.Length; i++)
		{
			if (actual[i] != expected[i])
			{
				return false;
			}
		}
		return true;
	}

	protected void checkSentinel(IDwgStreamReader sreader, byte[] expected)
	{
		if (!CheckSentinel(sreader.ReadSentinel(), expected))
		{
			notify("Invalid section sentinel found in " + SectionName, NotificationType.Warning);
		}
	}

	protected void notify(string message, NotificationType type, Exception ex = null)
	{
		this.OnNotification?.Invoke(this, new NotificationEventArgs(message, type, ex));
	}
}
