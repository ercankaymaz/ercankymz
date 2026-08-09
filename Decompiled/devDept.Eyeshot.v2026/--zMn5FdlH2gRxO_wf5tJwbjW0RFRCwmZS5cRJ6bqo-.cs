using System.Collections.Generic;
using System.Diagnostics;

internal sealed class _0023_003DzMn5FdlH2gRxO_wf5tJwbjW0RFRCwmZS5cRJ6bqo_003D : IComparer<_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D _0023_003DzH5c4Uv8_003D;

	public _0023_003DzMn5FdlH2gRxO_wf5tJwbjW0RFRCwmZS5cRJ6bqo_003D(_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D _0023_003DzeoY7iyo_003D)
	{
		_0023_003DzH5c4Uv8_003D = _0023_003DzeoY7iyo_003D;
	}

	public int Compare(_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D _0023_003DzjbqS1qE_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D _0023_003Dz1v6oPQk_003D)
	{
		if (_0023_003DzH5c4Uv8_003D._0023_003Dz4KsvltgRTxkp(_0023_003DzjbqS1qE_003D) > _0023_003DzH5c4Uv8_003D._0023_003Dz4KsvltgRTxkp(_0023_003Dz1v6oPQk_003D))
		{
			return 1;
		}
		if (_0023_003DzH5c4Uv8_003D._0023_003Dz4KsvltgRTxkp(_0023_003DzjbqS1qE_003D) < _0023_003DzH5c4Uv8_003D._0023_003Dz4KsvltgRTxkp(_0023_003Dz1v6oPQk_003D))
		{
			return -1;
		}
		return 0;
	}
}
