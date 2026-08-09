using System.Reflection;
using System.Runtime.CompilerServices;

internal sealed class _0023_003DzW_CBdIoyK4efExpnRlC_OpDV9CLkuKGWlA_003D_003D
{
	[DefaultMember("Item")]
	public sealed class _0023_003DzrG3AHMmMhsjX
	{
		private _0023_003DzW_CBdIoyK4efExpnRlC_OpDV9CLkuKGWlA_003D_003D _0023_003DzcaiUy5Q_003D;

		private uint _0023_003DzmoxC_00244E_003D;

		private uint _0023_003DztHIQcAc_003D;

		public _0023_003DzrG3AHMmMhsjX(_0023_003DzW_CBdIoyK4efExpnRlC_OpDV9CLkuKGWlA_003D_003D _0023_003DzE8QrneA_003D, uint _0023_003DzTSeNR8Q_003D)
		{
			_0023_003DzcaiUy5Q_003D = _0023_003DzE8QrneA_003D;
			_0023_003DzmoxC_00244E_003D = _0023_003DzTSeNR8Q_003D * _0023_003DzE8QrneA_003D._0023_003DzDtqAooE_003D;
			_0023_003DztHIQcAc_003D = _0023_003DzTSeNR8Q_003D;
		}

		public uint _0023_003Dz14lzA48_003D()
		{
			return _0023_003DzcaiUy5Q_003D._0023_003DzDtqAooE_003D;
		}

		public bool _0023_003DzqRJnPHc_003D()
		{
			return _0023_003DzcaiUy5Q_003D._0023_003DzDtqAooE_003D * _0023_003DzcaiUy5Q_003D._0023_003DzpGjKR04_003D == 0;
		}

		public uint _0023_003Dzz9oPww0_003D()
		{
			return _0023_003DzcaiUy5Q_003D._0023_003DzXrexKjY_003D[_0023_003DzmoxC_00244E_003D];
		}

		public uint _0023_003Dzw0AXpOM_003D()
		{
			return _0023_003DzcaiUy5Q_003D._0023_003DzXrexKjY_003D[_0023_003DzmoxC_00244E_003D + _0023_003DzcaiUy5Q_003D._0023_003DzDtqAooE_003D - 1];
		}

		public uint _0023_003DzAxYMWRU_003D(uint _0023_003Dz437_00244ak_003D)
		{
			return _0023_003DzcaiUy5Q_003D._0023_003DzXrexKjY_003D[_0023_003DzmoxC_00244E_003D + _0023_003Dz437_00244ak_003D];
		}
	}

	private uint[] _0023_003DzXrexKjY_003D;

	private uint _0023_003DzDtqAooE_003D;

	private uint _0023_003DzpGjKR04_003D;

	[IndexerName("#=z4kro5ZU=")]
	public uint this[uint _0023_003Dz437_00244ak_003D]
	{
		get
		{
			return _0023_003DzXrexKjY_003D[_0023_003Dz437_00244ak_003D];
		}
		set
		{
			_0023_003DzXrexKjY_003D[_0023_003Dz437_00244ak_003D] = value;
		}
	}

	public _0023_003DzW_CBdIoyK4efExpnRlC_OpDV9CLkuKGWlA_003D_003D(uint _0023_003DzO_0024xvpvo_003D, uint _0023_003DzmVsXTy4_003D)
	{
		_0023_003DzXrexKjY_003D = new uint[_0023_003DzO_0024xvpvo_003D * _0023_003DzmVsXTy4_003D];
		_0023_003DzDtqAooE_003D = _0023_003DzO_0024xvpvo_003D;
		_0023_003DzpGjKR04_003D = _0023_003DzmVsXTy4_003D;
	}

	public _0023_003DzW_CBdIoyK4efExpnRlC_OpDV9CLkuKGWlA_003D_003D(uint _0023_003DzXULhp_00248_003D, uint _0023_003DzO_0024xvpvo_003D, uint _0023_003DzmVsXTy4_003D)
	{
		_0023_003DzXrexKjY_003D = new uint[_0023_003DzO_0024xvpvo_003D * _0023_003DzmVsXTy4_003D];
		_0023_003DzWrlwfh7FsOZcM_0024LfR64hwptEhMBFqxqluw_003D_003D._0023_003Dzo6KAXJQ_003D(_0023_003DzXrexKjY_003D, _0023_003DzXULhp_00248_003D);
		_0023_003DzDtqAooE_003D = _0023_003DzO_0024xvpvo_003D;
		_0023_003DzpGjKR04_003D = _0023_003DzmVsXTy4_003D;
	}

	public _0023_003DzW_CBdIoyK4efExpnRlC_OpDV9CLkuKGWlA_003D_003D _0023_003Dz_0024xXJldw_003D(_0023_003DzW_CBdIoyK4efExpnRlC_OpDV9CLkuKGWlA_003D_003D _0023_003DzBJFJHwk_003D)
	{
		_0023_003Dz6lGncTjN6Lvoy8Z4ebbI5fd5YT7n3USMLZ8_8WVYRfPlDeGSxIXlVlFDcAOn._0023_003DzrR7yhtbUeWb_0024(0u, _0023_003DzBJFJHwk_003D, 0u, this, _0023_003DzDtqAooE_003D * _0023_003DzpGjKR04_003D);
		return this;
	}

	public uint _0023_003DzO_0024xvpvo_003D()
	{
		return _0023_003DzDtqAooE_003D;
	}

	public uint _0023_003DzmVsXTy4_003D()
	{
		return _0023_003DzpGjKR04_003D;
	}

	public _0023_003DzrG3AHMmMhsjX _0023_003DzFDJdA7A_003D(uint _0023_003DzTSeNR8Q_003D)
	{
		return new _0023_003DzrG3AHMmMhsjX(this, _0023_003DzTSeNR8Q_003D);
	}

	public uint _0023_003DzYlRpapy_b5uM(uint _0023_003DzTSeNR8Q_003D)
	{
		return _0023_003DzTSeNR8Q_003D * _0023_003DzDtqAooE_003D;
	}

	public uint _0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(uint _0023_003Dz437_00244ak_003D, uint _0023_003DzTSeNR8Q_003D)
	{
		return _0023_003DzXrexKjY_003D[_0023_003Dz437_00244ak_003D + _0023_003DzTSeNR8Q_003D * _0023_003DzDtqAooE_003D];
	}

	public void _0023_003DzQmya_mnFMQ1t(uint _0023_003Dz437_00244ak_003D, uint _0023_003DzTSeNR8Q_003D, uint _0023_003DzXULhp_00248_003D)
	{
		_0023_003DzXrexKjY_003D[_0023_003Dz437_00244ak_003D + _0023_003DzTSeNR8Q_003D * _0023_003DzDtqAooE_003D] = _0023_003DzXULhp_00248_003D;
	}

	public uint _0023_003Dz14lzA48_003D()
	{
		return (uint)_0023_003DzXrexKjY_003D.Length;
	}

	public bool _0023_003DzqRJnPHc_003D()
	{
		return _0023_003DzXrexKjY_003D.Length == 0;
	}
}
