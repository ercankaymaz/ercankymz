using System;
using System.Runtime.InteropServices;
using System.Text;

internal static class _0023_003DzULmNwngiHoVZ1nTQwvVfjIU_003D
{
	[DllImport("kernel32.dll", EntryPoint = "GetSystemFirmwareTable", SetLastError = true)]
	private static extern uint _0023_003Dzmmo4vCFC7rmyrp7gKIeKs_c_003D(uint _0023_003DzXdvmbSoyy2IKN8SdrHZQYOc_003D, uint _0023_003Dze5fc2fnS1xynuXDgLQ_003D_003D, IntPtr _0023_003DzDcGdC_75J5LZjarA4RDyl88_003D, uint _0023_003DzODSmOzg_003D);

	public static string _0023_003DzMPEXwhJf9v8k()
	{
		if (!_0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzZ4RB3Lo_003D())
		{
			return string.Empty;
		}
		byte[] array = _0023_003DzYTwMGg75_0024fIxyjSnYg_003D_003D();
		if (array.Length == 0)
		{
			return string.Empty;
		}
		return _0023_003DzKNSeYnWQ3y6XRCpa2VvxyCU_003D(array);
	}

	public static string _0023_003DzIIjBNEpPQhLx()
	{
		if (!_0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzZ4RB3Lo_003D())
		{
			return string.Empty;
		}
		byte[] array = _0023_003DzYTwMGg75_0024fIxyjSnYg_003D_003D();
		if (array.Length == 0)
		{
			return string.Empty;
		}
		return _0023_003DzuKOo7bBUoWys5LzhUA_003D_003D(array, 8);
	}

	public static string _0023_003Dzb_CrOn1W_2ht()
	{
		if (!_0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzZ4RB3Lo_003D())
		{
			return string.Empty;
		}
		byte[] array = _0023_003DzYTwMGg75_0024fIxyjSnYg_003D_003D();
		if (array.Length == 0)
		{
			return string.Empty;
		}
		string text = _0023_003DzIErvNkPROVVVI697lA_003D_003D(array, 4);
		if (!string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		return _0023_003DzTbjitt8pJ14KGVkHgA_003D_003D(array, 4);
	}

	public static string _0023_003DzLAa0bZ4Sux1e()
	{
		if (!_0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzZ4RB3Lo_003D())
		{
			return string.Empty;
		}
		byte[] array = _0023_003DzYTwMGg75_0024fIxyjSnYg_003D_003D();
		if (array.Length == 0)
		{
			return string.Empty;
		}
		string text = _0023_003DzIErvNkPROVVVI697lA_003D_003D(array, 5);
		if (!string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		return _0023_003DzTbjitt8pJ14KGVkHgA_003D_003D(array, 5);
	}

	private static string _0023_003DzIErvNkPROVVVI697lA_003D_003D(byte[] _0023_003Dzac3_0024xV0_003D, int _0023_003DzsTjYcBVD8fzT)
	{
		int num = 8;
		while (num + 4 <= _0023_003Dzac3_0024xV0_003D.Length)
		{
			byte b = _0023_003Dzac3_0024xV0_003D[num];
			byte b2 = _0023_003Dzac3_0024xV0_003D[num + 1];
			if (b2 == 0)
			{
				return string.Empty;
			}
			if (b == 1)
			{
				if (b2 > _0023_003DzsTjYcBVD8fzT)
				{
					byte _0023_003DzfM0XgIc_003D = _0023_003Dzac3_0024xV0_003D[num + _0023_003DzsTjYcBVD8fzT];
					return _0023_003DzOGMG8A4_003D(_0023_003Dzac3_0024xV0_003D, num, b2, _0023_003DzfM0XgIc_003D);
				}
				return string.Empty;
			}
			num = _0023_003DzaUIsaArnEGUi(_0023_003Dzac3_0024xV0_003D, num, b2);
			if (num < 0)
			{
				break;
			}
		}
		return string.Empty;
	}

	private static string _0023_003DzTbjitt8pJ14KGVkHgA_003D_003D(byte[] _0023_003Dzac3_0024xV0_003D, int _0023_003DzsTjYcBVD8fzT)
	{
		int num = 8;
		while (num + 4 <= _0023_003Dzac3_0024xV0_003D.Length)
		{
			byte b = _0023_003Dzac3_0024xV0_003D[num];
			byte b2 = _0023_003Dzac3_0024xV0_003D[num + 1];
			if (b2 == 0)
			{
				return string.Empty;
			}
			if (b == 2)
			{
				if (b2 > _0023_003DzsTjYcBVD8fzT)
				{
					byte _0023_003DzfM0XgIc_003D = _0023_003Dzac3_0024xV0_003D[num + _0023_003DzsTjYcBVD8fzT];
					return _0023_003DzOGMG8A4_003D(_0023_003Dzac3_0024xV0_003D, num, b2, _0023_003DzfM0XgIc_003D);
				}
				return string.Empty;
			}
			num = _0023_003DzaUIsaArnEGUi(_0023_003Dzac3_0024xV0_003D, num, b2);
			if (num < 0)
			{
				break;
			}
		}
		return string.Empty;
	}

	private static byte[] _0023_003DzYTwMGg75_0024fIxyjSnYg_003D_003D()
	{
		uint num = _0023_003Dzmmo4vCFC7rmyrp7gKIeKs_c_003D(1381190978u, 0u, IntPtr.Zero, 0u);
		if (num == 0)
		{
			return Array.Empty<byte>();
		}
		IntPtr intPtr = Marshal.AllocHGlobal((int)num);
		try
		{
			uint num2 = _0023_003Dzmmo4vCFC7rmyrp7gKIeKs_c_003D(1381190978u, 0u, intPtr, num);
			if (num2 != num || num2 == 0)
			{
				return Array.Empty<byte>();
			}
			byte[] array = new byte[num];
			Marshal.Copy(intPtr, array, 0, (int)num);
			return array;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
	}

	private static string _0023_003DzKNSeYnWQ3y6XRCpa2VvxyCU_003D(byte[] _0023_003Dzac3_0024xV0_003D)
	{
		int num = 8;
		while (num + 4 <= _0023_003Dzac3_0024xV0_003D.Length)
		{
			byte b = _0023_003Dzac3_0024xV0_003D[num];
			byte b2 = _0023_003Dzac3_0024xV0_003D[num + 1];
			if (b2 == 0)
			{
				return string.Empty;
			}
			if (b == 1)
			{
				if (b2 > 7)
				{
					byte _0023_003DzfM0XgIc_003D = _0023_003Dzac3_0024xV0_003D[num + 7];
					return _0023_003DzOGMG8A4_003D(_0023_003Dzac3_0024xV0_003D, num, b2, _0023_003DzfM0XgIc_003D);
				}
				return string.Empty;
			}
			num = _0023_003DzaUIsaArnEGUi(_0023_003Dzac3_0024xV0_003D, num, b2);
			if (num < 0)
			{
				break;
			}
		}
		return string.Empty;
	}

	private static string _0023_003DzuKOo7bBUoWys5LzhUA_003D_003D(byte[] _0023_003Dzac3_0024xV0_003D, int _0023_003DzsTjYcBVD8fzT)
	{
		int num = 8;
		while (num + 4 <= _0023_003Dzac3_0024xV0_003D.Length)
		{
			byte b = _0023_003Dzac3_0024xV0_003D[num];
			byte b2 = _0023_003Dzac3_0024xV0_003D[num + 1];
			if (b2 == 0)
			{
				return string.Empty;
			}
			if (b == 0)
			{
				if (b2 > _0023_003DzsTjYcBVD8fzT)
				{
					byte _0023_003DzfM0XgIc_003D = _0023_003Dzac3_0024xV0_003D[num + _0023_003DzsTjYcBVD8fzT];
					return _0023_003DzOGMG8A4_003D(_0023_003Dzac3_0024xV0_003D, num, b2, _0023_003DzfM0XgIc_003D);
				}
				return string.Empty;
			}
			num = _0023_003DzaUIsaArnEGUi(_0023_003Dzac3_0024xV0_003D, num, b2);
			if (num < 0)
			{
				break;
			}
		}
		return string.Empty;
	}

	private static int _0023_003DzaUIsaArnEGUi(byte[] _0023_003Dzac3_0024xV0_003D, int _0023_003DzqeMFKXOYz9Hu, int _0023_003DzIgyjykCFlWnr)
	{
		for (int i = _0023_003DzqeMFKXOYz9Hu + _0023_003DzIgyjykCFlWnr; i < _0023_003Dzac3_0024xV0_003D.Length - 1; i++)
		{
			if (_0023_003Dzac3_0024xV0_003D[i] == 0 && _0023_003Dzac3_0024xV0_003D[i + 1] == 0)
			{
				return i + 2;
			}
		}
		return -1;
	}

	private static string _0023_003DzOGMG8A4_003D(byte[] _0023_003Dzac3_0024xV0_003D, int _0023_003DzqeMFKXOYz9Hu, int _0023_003DzIgyjykCFlWnr, byte _0023_003DzfM0XgIc_003D)
	{
		if (_0023_003DzfM0XgIc_003D == 0)
		{
			return string.Empty;
		}
		int i = _0023_003DzqeMFKXOYz9Hu + _0023_003DzIgyjykCFlWnr;
		int num = 1;
		while (i < _0023_003Dzac3_0024xV0_003D.Length)
		{
			int num2 = i;
			for (; i < _0023_003Dzac3_0024xV0_003D.Length && _0023_003Dzac3_0024xV0_003D[i] != 0; i++)
			{
			}
			if (num == _0023_003DzfM0XgIc_003D)
			{
				return Encoding.ASCII.GetString(_0023_003Dzac3_0024xV0_003D, num2, i - num2).Trim();
			}
			num++;
			i++;
			if (i < _0023_003Dzac3_0024xV0_003D.Length && _0023_003Dzac3_0024xV0_003D[i] == 0)
			{
				break;
			}
		}
		return string.Empty;
	}
}
