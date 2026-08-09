using System;
using Aladdin.HASP.Internal;

namespace Aladdin.HASP;

public sealed class HaspLegacy : Hasp
{
	public HaspLegacy(Hasp other)
		: base(other)
	{
	}

	public HaspLegacy(HaspLegacy other)
		: base(other)
	{
	}

	public new HaspStatus Decrypt(byte[] data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.legacy_decrypt(key.handle, data);
	}

	public new HaspStatus Decrypt(char[] data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.legacy_decrypt(key.handle, data);
	}

	public new HaspStatus Decrypt(double[] data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.legacy_decrypt(key.handle, data);
	}

	public new HaspStatus Decrypt(short[] data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.legacy_decrypt(key.handle, data);
	}

	public new HaspStatus Decrypt(int[] data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.legacy_decrypt(key.handle, data);
	}

	public new HaspStatus Decrypt(long[] data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.legacy_decrypt(key.handle, data);
	}

	public new HaspStatus Decrypt(float[] data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.legacy_decrypt(key.handle, data);
	}

	public new HaspStatus Decrypt(ref string data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.legacy_decrypt(key.handle, ref data);
	}

	public new HaspStatus Encrypt(byte[] data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.legacy_encrypt(key.handle, data);
	}

	public new HaspStatus Encrypt(char[] data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.legacy_encrypt(key.handle, data);
	}

	public new HaspStatus Encrypt(double[] data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.legacy_encrypt(key.handle, data);
	}

	public new HaspStatus Encrypt(short[] data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.legacy_encrypt(key.handle, data);
	}

	public new HaspStatus Encrypt(int[] data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.legacy_encrypt(key.handle, data);
	}

	public new HaspStatus Encrypt(long[] data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.legacy_encrypt(key.handle, data);
	}

	public new HaspStatus Encrypt(float[] data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.legacy_encrypt(key.handle, data);
	}

	public new HaspStatus Encrypt(ref string data)
	{
		if (data == null)
		{
			return HaspStatus.InvalidParameter;
		}
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.legacy_encrypt(key.handle, ref data);
	}

	public HaspStatus SetIdleTime(short idleTime)
	{
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		return ApiDisp.legacy_set_idletime(key.handle, idleTime);
	}

	public HaspStatus SetRtc(DateTime rtc)
	{
		HaspStatus haspStatus = Hasp_Prologue(key);
		if (haspStatus != HaspStatus.StatusOk)
		{
			return haspStatus;
		}
		DateTime dateTime = new DateTime(1970, 1, 1);
		return ApiDisp.legacy_set_rtc(key.handle, (rtc.Ticks - dateTime.Ticks) / 10 / 1000 / 1000);
	}

	public new bool IsValid()
	{
		return base.IsValid() && base.HasLegacy && (key.IsLoggedIn || !key.loggedOut);
	}

	public new object Clone()
	{
		return new HaspLegacy(this);
	}

	public new HaspLegacy Assign(Hasp other)
	{
		base.Assign(other);
		return this;
	}
}
