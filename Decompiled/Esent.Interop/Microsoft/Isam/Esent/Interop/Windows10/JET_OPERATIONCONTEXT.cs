using System;
using System.Globalization;

namespace Microsoft.Isam.Esent.Interop.Windows10;

public struct JET_OPERATIONCONTEXT : IEquatable<JET_OPERATIONCONTEXT>
{
	public int UserID { get; set; }

	public byte OperationID { get; set; }

	public byte OperationType { get; set; }

	public byte ClientType { get; set; }

	public byte Flags { get; set; }

	internal JET_OPERATIONCONTEXT(ref NATIVE_OPERATIONCONTEXT native)
	{
		this = default(JET_OPERATIONCONTEXT);
		UserID = native.ulUserID;
		OperationID = native.nOperationID;
		OperationType = native.nOperationType;
		ClientType = native.nClientType;
		Flags = native.fFlags;
	}

	public static bool operator ==(JET_OPERATIONCONTEXT lhs, JET_OPERATIONCONTEXT rhs)
	{
		return lhs.Equals(rhs);
	}

	public static bool operator !=(JET_OPERATIONCONTEXT lhs, JET_OPERATIONCONTEXT rhs)
	{
		return !(lhs == rhs);
	}

	public override bool Equals(object obj)
	{
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		return Equals((JET_OPERATIONCONTEXT)obj);
	}

	public override int GetHashCode()
	{
		return UserID.GetHashCode() ^ OperationID.GetHashCode() ^ OperationType.GetHashCode() ^ ClientType.GetHashCode() ^ Flags.GetHashCode();
	}

	public bool Equals(JET_OPERATIONCONTEXT other)
	{
		if (UserID == other.UserID && OperationID == other.OperationID && OperationType == other.OperationType && ClientType == other.ClientType)
		{
			return Flags == other.Flags;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_OPERATIONCONTEXT({0}:{1}:{2}:{3}:0x{4:x2})", UserID, OperationID, OperationType, ClientType, Flags);
	}

	internal NATIVE_OPERATIONCONTEXT GetNativeOperationContext()
	{
		return new NATIVE_OPERATIONCONTEXT
		{
			ulUserID = UserID,
			nOperationID = OperationID,
			nOperationType = OperationType,
			nClientType = ClientType,
			fFlags = Flags
		};
	}
}
