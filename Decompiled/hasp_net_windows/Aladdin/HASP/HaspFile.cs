using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Aladdin.HASP.Internal;

namespace Aladdin.HASP;

public sealed class HaspFile : ICloneable, IDisposable, IComparable<HaspFile>
{
	private Hasp parent;

	private int pIntId;

	private int ulFilePos;

	private bool isDisposed = false;

	private int handle => parent.key.handle;

	public int FilePos
	{
		get
		{
			return ulFilePos;
		}
		set
		{
			ulFilePos = value;
		}
	}

	public HaspFileId FileId
	{
		get
		{
			if (Enum.IsDefined(typeof(HaspFileId), (HaspFileId)pIntId))
			{
				return (HaspFileId)pIntId;
			}
			return HaspFileId.Custom;
		}
	}

	internal HaspFile()
	{
		init();
	}

	public HaspFile(HaspFileId fileId, Hasp other)
	{
		parent = other;
		init((int)fileId);
	}

	public HaspFile(int fileId, Hasp other)
	{
		parent = other;
		init(fileId);
	}

	public HaspFile(HaspFile other)
	{
		if (!(other == null))
		{
			parent = other.parent;
			init(other.getFileIdInt());
		}
	}

	~HaspFile()
	{
		Dispose(disposing: false);
	}

	public static implicit operator Hasp(HaspFile other)
	{
		if (other == null)
		{
			return null;
		}
		return other.parent;
	}

	public static bool CanWriteString(string value)
	{
		if (value == null)
		{
			return false;
		}
		return maxStringLength() >= value.Length;
	}

	private HaspFileId getFileId()
	{
		if (Enum.IsDefined(typeof(HaspFileId), (HaspFileId)pIntId))
		{
			return (HaspFileId)pIntId;
		}
		return HaspFileId.Custom;
	}

	private int getFileIdInt()
	{
		return pIntId;
	}

	public static int FilePosFromString(string value)
	{
		if (value == null)
		{
			return 0;
		}
		return CanWriteString(value) ? (value.Length + 2) : 0;
	}

	public HaspStatus FileSize(ref int size)
	{
		HaspStatus haspStatus = parent.Hasp_Prologue(parent.key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			size = 0;
			return haspStatus;
		}
		return ApiDisp.get_size(handle, pIntId, ref size);
	}

	private void init()
	{
		init(65524);
	}

	private void init(int fileId)
	{
		ulFilePos = 0;
		if (parent == null)
		{
			pIntId = 0;
			return;
		}
		pIntId = fileId;
		if (parent.Feature.IsProgNum)
		{
			switch ((HaspFileId)fileId)
			{
			case HaspFileId.ReadWrite:
			case HaspFileId.ReadOnly:
				pIntId = 0;
				break;
			}
			return;
		}
		switch ((HaspFileId)fileId)
		{
		case HaspFileId.Main:
		case HaspFileId.License:
			pIntId = 0;
			break;
		case (HaspFileId)65521:
			break;
		}
	}

	private static byte maxStringLength()
	{
		return byte.MaxValue;
	}

	public HaspFile Assign(HaspFile other)
	{
		if (other == null)
		{
			parent = null;
			init();
			return this;
		}
		parent = other.parent;
		init(other.getFileIdInt());
		return this;
	}

	public HaspStatus Read(ref bool value)
	{
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			value = false;
			return haspStatus;
		}
		return ApiDisp.read(handle, pIntId, ulFilePos, ref value);
	}

	public HaspStatus Read(ref byte value)
	{
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			value = 0;
			return haspStatus;
		}
		return ApiDisp.read(handle, pIntId, ulFilePos, ref value);
	}

	public HaspStatus Read(byte[] buffer, int index, int count)
	{
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		if (buffer == null)
		{
			return HaspStatus.InvalidParameter;
		}
		if (0 == count)
		{
			return HaspStatus.StatusOk;
		}
		if (index + count > buffer.Length)
		{
			return HaspStatus.InvalidParameter;
		}
		if (index == 0 && count == buffer.Length)
		{
			return ApiDisp.read(handle, pIntId, ulFilePos, buffer);
		}
		byte[] array = new byte[count];
		haspStatus = ApiDisp.read(handle, pIntId, ulFilePos, array);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		array.CopyTo(buffer, index);
		return haspStatus;
	}

	public HaspStatus Read(ref char value)
	{
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			value = '\0';
			return haspStatus;
		}
		return ApiDisp.read(handle, pIntId, ulFilePos, ref value);
	}

	public HaspStatus Read(ref double value)
	{
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			value = 0.0;
			return haspStatus;
		}
		return ApiDisp.read(handle, pIntId, ulFilePos, ref value);
	}

	public HaspStatus Read(ref short value)
	{
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			value = 0;
			return haspStatus;
		}
		return ApiDisp.read(handle, pIntId, ulFilePos, ref value);
	}

	public HaspStatus Read(ref int value)
	{
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			value = 0;
			return haspStatus;
		}
		return ApiDisp.read(handle, pIntId, ulFilePos, ref value);
	}

	public HaspStatus Read(ref long value)
	{
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			value = 0L;
			return haspStatus;
		}
		return ApiDisp.read(handle, pIntId, ulFilePos, ref value);
	}

	public HaspStatus Read(ref float value)
	{
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			value = 0f;
			return haspStatus;
		}
		return ApiDisp.read(handle, pIntId, ulFilePos, ref value);
	}

	public HaspStatus Read(ref string value)
	{
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			value = "";
			return haspStatus;
		}
		return ApiDisp.read(handle, pIntId, ulFilePos, ref value);
	}

	[CLSCompliant(false)]
	public HaspStatus Read(ref ushort value)
	{
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			value = 0;
			return haspStatus;
		}
		return ApiDisp.read(handle, pIntId, ulFilePos, ref value);
	}

	[CLSCompliant(false)]
	public HaspStatus Read(ref uint value)
	{
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			value = 0u;
			return haspStatus;
		}
		return ApiDisp.read(handle, pIntId, ulFilePos, ref value);
	}

	[CLSCompliant(false)]
	public HaspStatus Read(ref ulong value)
	{
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			value = 0uL;
			return haspStatus;
		}
		return ApiDisp.read(handle, pIntId, ulFilePos, ref value);
	}

	public override string ToString()
	{
		HaspFileId haspFileId = ((!Enum.IsDefined(typeof(HaspFileId), (HaspFileId)pIntId)) ? HaspFileId.Custom : ((HaspFileId)pIntId));
		return haspFileId.ToString();
	}

	public HaspStatus Write(bool value)
	{
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.write(handle, pIntId, ulFilePos, value);
	}

	public HaspStatus Write(byte value)
	{
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.write(handle, pIntId, ulFilePos, value);
	}

	public HaspStatus Write(byte[] buffer, int index, int count)
	{
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		if (buffer == null)
		{
			return HaspStatus.InvalidParameter;
		}
		if (index + count > buffer.Length)
		{
			return HaspStatus.InvalidParameter;
		}
		if (index == 0)
		{
			return ApiDisp.write(handle, pIntId, ulFilePos, buffer);
		}
		byte[] array = new byte[count];
		Array.Copy(buffer, index, array, 0, count);
		return ApiDisp.write(handle, pIntId, ulFilePos, array);
	}

	public HaspStatus Write(char value)
	{
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.write(handle, pIntId, ulFilePos, value);
	}

	public HaspStatus Write(double value)
	{
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.write(handle, pIntId, ulFilePos, value);
	}

	public HaspStatus Write(short value)
	{
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.write(handle, pIntId, ulFilePos, value);
	}

	public HaspStatus Write(int value)
	{
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.write(handle, pIntId, ulFilePos, value);
	}

	public HaspStatus Write(long value)
	{
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.write(handle, pIntId, ulFilePos, value);
	}

	public HaspStatus Write(float value)
	{
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.write(handle, pIntId, ulFilePos, value);
	}

	public HaspStatus Write(string value)
	{
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.write(handle, pIntId, ulFilePos, value);
	}

	[CLSCompliant(false)]
	public HaspStatus Write(ushort value)
	{
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.write(handle, pIntId, ulFilePos, value);
	}

	[CLSCompliant(false)]
	public HaspStatus Write(uint value)
	{
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.write(handle, pIntId, ulFilePos, value);
	}

	[CLSCompliant(false)]
	public HaspStatus Write(ulong value)
	{
		HaspStatus haspStatus = Hasp_Prologue();
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.write(handle, pIntId, ulFilePos, value);
	}

	[PermissionSet(SecurityAction.LinkDemand)]
	public static int TypeSize(Type type)
	{
		return Marshal.SizeOf(type);
	}

	public object Clone()
	{
		return new HaspFile(this);
	}

	private HaspStatus Hasp_Prologue()
	{
		return parent.Hasp_Prologue(parent.key);
	}

	public bool IsValid()
	{
		HaspFileId haspFileId = ((!Enum.IsDefined(typeof(HaspFileId), (HaspFileId)pIntId)) ? HaspFileId.Custom : ((HaspFileId)pIntId));
		return !isDisposed && parent.IsValid() && haspFileId != HaspFileId.None && (parent.key.IsLoggedIn || !parent.key.loggedOut);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	private void Dispose(bool disposing)
	{
		if (!isDisposed)
		{
			parent = null;
		}
		isDisposed = true;
	}

	public bool IsLoggedIn()
	{
		if (isDisposed)
		{
			return false;
		}
		return IsValid() && parent.IsLoggedIn();
	}

	public int CompareTo(HaspFile other)
	{
		if (other == null)
		{
			return 1;
		}
		if (parent == null)
		{
			return -1;
		}
		try
		{
			if (other.parent == null)
			{
				return 1;
			}
		}
		catch (NullReferenceException)
		{
			return 1;
		}
		int num = parent.CompareTo(other.parent);
		if (num != 0)
		{
			return num;
		}
		num = pIntId.CompareTo(other.pIntId);
		if (num != 0)
		{
			return num;
		}
		return ulFilePos.CompareTo(other.ulFilePos);
	}

	public int CompareTo(Hasp other)
	{
		if (other == null)
		{
			return 1;
		}
		return parent.CompareTo(other);
	}

	public override bool Equals(object obj)
	{
		return this == obj;
	}

	public static bool operator ==(HaspFile left, object right)
	{
		if ((object)left == null && right == null)
		{
			return true;
		}
		if ((object)left == null || right == null)
		{
			return false;
		}
		HaspFile haspFile = right as HaspFile;
		if (haspFile != null)
		{
			return left.CompareTo(haspFile) == 0;
		}
		Hasp hasp = right as Hasp;
		if (hasp != null)
		{
			return left.parent.CompareTo(hasp) == 0;
		}
		return false;
	}

	public static bool operator !=(HaspFile left, object right)
	{
		return !(left == right);
	}

	public override int GetHashCode()
	{
		return pIntId;
	}
}
