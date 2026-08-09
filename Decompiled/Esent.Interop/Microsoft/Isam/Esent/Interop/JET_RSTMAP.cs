using System;
using System.Diagnostics;
using System.Globalization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public class JET_RSTMAP : IContentEquatable<JET_RSTMAP>, IDeepCloneable<JET_RSTMAP>
{
	private string databaseName;

	private string newDatabaseName;

	public string szDatabaseName
	{
		[DebuggerStepThrough]
		get
		{
			return databaseName;
		}
		set
		{
			databaseName = value;
		}
	}

	public string szNewDatabaseName
	{
		[DebuggerStepThrough]
		get
		{
			return newDatabaseName;
		}
		set
		{
			newDatabaseName = value;
		}
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_RSTINFO(szDatabaseName={0},szNewDatabaseName={1})", szDatabaseName, szNewDatabaseName);
	}

	public bool ContentEquals(JET_RSTMAP other)
	{
		if (other == null)
		{
			return false;
		}
		if (string.Equals(szDatabaseName, other.szDatabaseName, StringComparison.OrdinalIgnoreCase))
		{
			return string.Equals(szNewDatabaseName, other.szNewDatabaseName, StringComparison.OrdinalIgnoreCase);
		}
		return false;
	}

	public JET_RSTMAP DeepClone()
	{
		return (JET_RSTMAP)MemberwiseClone();
	}

	internal NATIVE_RSTMAP GetNativeRstmap()
	{
		return new NATIVE_RSTMAP
		{
			szDatabaseName = LibraryHelpers.MarshalStringToHGlobalUni(szDatabaseName),
			szNewDatabaseName = LibraryHelpers.MarshalStringToHGlobalUni(szNewDatabaseName)
		};
	}
}
