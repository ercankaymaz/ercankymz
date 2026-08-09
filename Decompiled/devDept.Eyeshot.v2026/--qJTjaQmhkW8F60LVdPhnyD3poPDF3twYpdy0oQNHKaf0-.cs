using System;
using System.Collections.Generic;

internal sealed class _0023_003DqJTjaQmhkW8F60LVdPhnyD3poPDF3twYpdy0oQNHKaf0_003D
{
	private object _0023_003DziDLVpbY_003D = new object();

	private Dictionary<_0023_003Dqy79GaFqXfJyGRxADW8SzoVL2xZ0_0024kwo_HbErPO8MT0Y_003D, _0023_003DqBtO_Ln5vbudMbzVGmzEMIy5peuaUpGADidnrgN2dgH4_003D> _0023_003Dz5rQzobg_003D;

	internal _0023_003DqBtO_Ln5vbudMbzVGmzEMIy5peuaUpGADidnrgN2dgH4_003D _0023_003DzS2rD7MOKa6G_oZOXKeZ2sqqqNI73vRTeiDxjOWs_003D(_0023_003Dqy79GaFqXfJyGRxADW8SzoVL2xZ0_0024kwo_HbErPO8MT0Y_003D _0023_003DziDLVpbY_003D)
	{
		if (_0023_003DziDLVpbY_003D == null)
		{
			throw new ArgumentNullException();
		}
		lock (this._0023_003DziDLVpbY_003D)
		{
			if (_0023_003Dz5rQzobg_003D == null)
			{
				_0023_003Dz5rQzobg_003D = new Dictionary<_0023_003Dqy79GaFqXfJyGRxADW8SzoVL2xZ0_0024kwo_HbErPO8MT0Y_003D, _0023_003DqBtO_Ln5vbudMbzVGmzEMIy5peuaUpGADidnrgN2dgH4_003D>();
			}
			if (!_0023_003Dz5rQzobg_003D.TryGetValue(_0023_003DziDLVpbY_003D, out var value))
			{
				value = new _0023_003DqBtO_Ln5vbudMbzVGmzEMIy5peuaUpGADidnrgN2dgH4_003D(_0023_003DziDLVpbY_003D);
				_0023_003Dz5rQzobg_003D[_0023_003DziDLVpbY_003D] = value;
			}
			return value;
		}
	}
}
