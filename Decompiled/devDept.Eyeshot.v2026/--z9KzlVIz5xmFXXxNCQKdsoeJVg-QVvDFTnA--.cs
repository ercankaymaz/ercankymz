using System.Collections.Generic;
using devDept.Geometry;

internal static class _0023_003Dz9KzlVIz5xmFXXxNCQKdsoeJVg_0024QVvDFTnA_003D_003D
{
	private static void _0023_003DzryMWepGxSdM5(_0023_003DzdtuF6DToO_HAYb_7C3OkTmdghgQf _0023_003DzTx2aqr8_003D, Dictionary<int, LinkedList<_0023_003DzdtuF6DToO_HAYb_7C3OkTmdghgQf>> _0023_003DzU3hosSAzkxO7)
	{
		if (!_0023_003DzU3hosSAzkxO7.ContainsKey(_0023_003DzTx2aqr8_003D.V1))
		{
			_0023_003DzU3hosSAzkxO7[_0023_003DzTx2aqr8_003D.V1] = new LinkedList<_0023_003DzdtuF6DToO_HAYb_7C3OkTmdghgQf>();
		}
		_0023_003DzU3hosSAzkxO7[_0023_003DzTx2aqr8_003D.V1].AddLast(_0023_003DzTx2aqr8_003D);
		if (!_0023_003DzU3hosSAzkxO7.ContainsKey(_0023_003DzTx2aqr8_003D.V2))
		{
			return;
		}
		_0023_003DzdtuF6DToO_HAYb_7C3OkTmdghgQf _0023_003DzdtuF6DToO_HAYb_7C3OkTmdghgQf2 = null;
		LinkedListNode<_0023_003DzdtuF6DToO_HAYb_7C3OkTmdghgQf> linkedListNode = _0023_003DzU3hosSAzkxO7[_0023_003DzTx2aqr8_003D.V2].First;
		while (_0023_003DzdtuF6DToO_HAYb_7C3OkTmdghgQf2 == null && linkedListNode != null)
		{
			if (linkedListNode.Value.V2 == _0023_003DzTx2aqr8_003D.V1)
			{
				_0023_003DzdtuF6DToO_HAYb_7C3OkTmdghgQf2 = linkedListNode.Value;
			}
			linkedListNode = linkedListNode.Next;
		}
		if (!(_0023_003DzdtuF6DToO_HAYb_7C3OkTmdghgQf2 == null))
		{
			_0023_003DzdtuF6DToO_HAYb_7C3OkTmdghgQf2._0023_003DzhcqQPsP1GAPe = _0023_003DzTx2aqr8_003D;
			_0023_003DzTx2aqr8_003D._0023_003DzhcqQPsP1GAPe = _0023_003DzdtuF6DToO_HAYb_7C3OkTmdghgQf2;
			_0023_003DzU3hosSAzkxO7[_0023_003DzTx2aqr8_003D.V1].Remove(_0023_003DzTx2aqr8_003D);
			_0023_003DzU3hosSAzkxO7[_0023_003DzTx2aqr8_003D.V2].Remove(_0023_003DzdtuF6DToO_HAYb_7C3OkTmdghgQf2);
		}
	}

	internal static _0023_003DznIxEYS4uE__0024ie2vUaKYuO8mxWKX6[] _0023_003DzZ4_EMwmky47mEQrs2A_003D_003D(IList<IndexTriangle> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D)
	{
		_0023_003DznIxEYS4uE__0024ie2vUaKYuO8mxWKX6[] array = new _0023_003DznIxEYS4uE__0024ie2vUaKYuO8mxWKX6[_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Count];
		Dictionary<int, LinkedList<_0023_003DzdtuF6DToO_HAYb_7C3OkTmdghgQf>> _0023_003DzU3hosSAzkxO = new Dictionary<int, LinkedList<_0023_003DzdtuF6DToO_HAYb_7C3OkTmdghgQf>>();
		for (int i = 0; i < _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Count; i++)
		{
			array[i] = new _0023_003DznIxEYS4uE__0024ie2vUaKYuO8mxWKX6(_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[i]);
			_0023_003DzryMWepGxSdM5(array[i]._0023_003DzDBy2B88_003D, _0023_003DzU3hosSAzkxO);
			_0023_003DzryMWepGxSdM5(array[i]._0023_003DzGZKh520_003D, _0023_003DzU3hosSAzkxO);
			_0023_003DzryMWepGxSdM5(array[i]._0023_003DzG2Q6_0024wA_003D, _0023_003DzU3hosSAzkxO);
		}
		return array;
	}
}
