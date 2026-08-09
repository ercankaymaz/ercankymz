using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
[StructLayout(LayoutKind.Auto)]
public struct JET_SIGNATURE : IEquatable<JET_SIGNATURE>
{
	internal readonly uint ulRandom;

	internal readonly JET_LOGTIME logtimeCreate;

	private readonly string szComputerName;

	public JET_SIGNATURE(byte[] bytes)
	{
		NATIVE_SIGNATURE nATIVE_SIGNATURE = default(NATIVE_SIGNATURE);
		IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(nATIVE_SIGNATURE));
		Marshal.Copy(bytes, 0, intPtr, Marshal.SizeOf(nATIVE_SIGNATURE));
		for (int i = bytes.Length; i < Marshal.SizeOf(nATIVE_SIGNATURE); i = checked(i + 1))
		{
			Marshal.WriteByte(intPtr, i, 0);
		}
		nATIVE_SIGNATURE = (NATIVE_SIGNATURE)Marshal.PtrToStructure(intPtr, nATIVE_SIGNATURE.GetType());
		Marshal.FreeHGlobal(intPtr);
		ulRandom = nATIVE_SIGNATURE.ulRandom;
		logtimeCreate = nATIVE_SIGNATURE.logtimeCreate;
		szComputerName = nATIVE_SIGNATURE.szComputerName;
	}

	internal JET_SIGNATURE(int random, DateTime? time, string computerName)
	{
		ulRandom = (uint)random;
		logtimeCreate = (time.HasValue ? new JET_LOGTIME(time.Value) : default(JET_LOGTIME));
		szComputerName = computerName;
	}

	internal JET_SIGNATURE(NATIVE_SIGNATURE native)
	{
		ulRandom = native.ulRandom;
		logtimeCreate = native.logtimeCreate;
		szComputerName = native.szComputerName;
	}

	public static bool operator ==(JET_SIGNATURE lhs, JET_SIGNATURE rhs)
	{
		return lhs.Equals(rhs);
	}

	public static bool operator !=(JET_SIGNATURE lhs, JET_SIGNATURE rhs)
	{
		return !(lhs == rhs);
	}

	public override string ToString()
	{
		string arg = string.Empty;
		DateTime? dateTime = logtimeCreate.ToDateTime();
		if (dateTime.HasValue)
		{
			arg = dateTime.Value.ToString("o", CultureInfo.InvariantCulture);
		}
		return string.Format(CultureInfo.InvariantCulture, "JET_SIGNATURE({0}:{1}:{2})", ulRandom, arg, szComputerName);
	}

	public byte[] ToBytes()
	{
		NATIVE_SIGNATURE nativeSignature = GetNativeSignature();
		IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(nativeSignature));
		Marshal.StructureToPtr(nativeSignature, intPtr, fDeleteOld: false);
		byte[] array = new byte[Marshal.SizeOf(nativeSignature)];
		Marshal.Copy(intPtr, array, 0, Marshal.SizeOf(nativeSignature));
		Marshal.FreeHGlobal(intPtr);
		return array;
	}

	public override bool Equals(object obj)
	{
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		return Equals((JET_SIGNATURE)obj);
	}

	public override int GetHashCode()
	{
		uint num = ulRandom;
		return num.GetHashCode() ^ logtimeCreate.GetHashCode() ^ ((szComputerName == null) ? (-1) : szComputerName.GetHashCode());
	}

	public bool Equals(JET_SIGNATURE other)
	{
		if (((string.IsNullOrEmpty(szComputerName) && string.IsNullOrEmpty(other.szComputerName)) || (!string.IsNullOrEmpty(szComputerName) && !string.IsNullOrEmpty(other.szComputerName) && szComputerName == other.szComputerName)) && ulRandom == other.ulRandom)
		{
			return logtimeCreate == other.logtimeCreate;
		}
		return false;
	}

	internal NATIVE_SIGNATURE GetNativeSignature()
	{
		return new NATIVE_SIGNATURE
		{
			ulRandom = ulRandom,
			szComputerName = szComputerName,
			logtimeCreate = logtimeCreate
		};
	}
}
