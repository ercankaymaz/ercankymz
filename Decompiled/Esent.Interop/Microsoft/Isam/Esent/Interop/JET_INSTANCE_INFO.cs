using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Microsoft.Isam.Esent.Interop;

public class JET_INSTANCE_INFO : IEquatable<JET_INSTANCE_INFO>
{
	private ReadOnlyCollection<string> databases;

	public JET_INSTANCE hInstanceId { get; private set; }

	public string szInstanceName { get; private set; }

	public int cDatabases { get; private set; }

	public IList<string> szDatabaseFileName => databases;

	internal JET_INSTANCE_INFO()
	{
	}

	internal JET_INSTANCE_INFO(JET_INSTANCE instance, string instanceName, string[] databases)
	{
		hInstanceId = instance;
		szInstanceName = instanceName;
		if (databases == null)
		{
			cDatabases = 0;
			this.databases = null;
		}
		else
		{
			cDatabases = databases.Length;
			this.databases = new ReadOnlyCollection<string>(databases);
		}
	}

	public override bool Equals(object obj)
	{
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		return Equals((JET_INSTANCE_INFO)obj);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_INSTANCE_INFO({0})", szInstanceName);
	}

	public override int GetHashCode()
	{
		int num = hInstanceId.GetHashCode() ^ (szInstanceName ?? string.Empty).GetHashCode() ^ (cDatabases << 20);
		for (int i = 0; i < cDatabases; i = checked(i + 1))
		{
			num ^= szDatabaseFileName[i].GetHashCode();
		}
		return num;
	}

	public bool Equals(JET_INSTANCE_INFO other)
	{
		if (other == null)
		{
			return false;
		}
		if (hInstanceId != other.hInstanceId || szInstanceName != other.szInstanceName || cDatabases != other.cDatabases)
		{
			return false;
		}
		for (int i = 0; i < cDatabases; i = checked(i + 1))
		{
			if (szDatabaseFileName[i] != other.szDatabaseFileName[i])
			{
				return false;
			}
		}
		return true;
	}

	internal unsafe void SetFromNativeAscii(NATIVE_INSTANCE_INFO native)
	{
		hInstanceId = new JET_INSTANCE
		{
			Value = native.hInstanceId
		};
		szInstanceName = Marshal.PtrToStringAnsi(native.szInstanceName);
		cDatabases = (int)native.cDatabases;
		string[] array = new string[cDatabases];
		for (int i = 0; i < cDatabases; i = checked(i + 1))
		{
			array[i] = Marshal.PtrToStringAnsi(*(IntPtr*)((byte*)native.szDatabaseFileName + checked(unchecked((nint)i) * unchecked((nint)sizeof(IntPtr)))));
		}
		databases = new ReadOnlyCollection<string>(array);
	}

	internal unsafe void SetFromNativeUnicode(NATIVE_INSTANCE_INFO native)
	{
		hInstanceId = new JET_INSTANCE
		{
			Value = native.hInstanceId
		};
		szInstanceName = Marshal.PtrToStringUni(native.szInstanceName);
		cDatabases = (int)native.cDatabases;
		string[] array = new string[cDatabases];
		for (int i = 0; i < cDatabases; i = checked(i + 1))
		{
			array[i] = Marshal.PtrToStringUni(*(IntPtr*)((byte*)native.szDatabaseFileName + checked(unchecked((nint)i) * unchecked((nint)sizeof(IntPtr)))));
		}
		databases = new ReadOnlyCollection<string>(array);
	}
}
