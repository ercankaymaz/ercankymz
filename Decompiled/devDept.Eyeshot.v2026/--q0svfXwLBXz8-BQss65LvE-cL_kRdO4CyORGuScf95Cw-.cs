using System;

internal sealed class _0023_003Dq0svfXwLBXz8_0024BQss65LvE_0024cL_kRdO4CyORGuScf95Cw_003D : _0023_003DqpJzGvS9BBRbFYdUqQrKHOE18bcoZMb86GgAobmFLd5A_003D
{
	public _0023_003Dq0svfXwLBXz8_0024BQss65LvE_0024cL_kRdO4CyORGuScf95Cw_003D(byte[] _0023_003DziDLVpbY_003D, long _0023_003Dz5rQzobg_003D)
		: base(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D)
	{
	}

	public byte[] _0023_003DzkV_0024NPHJtkeR5aZj4lW5jyPw059xj(_0023_003DqgLKG65nYMoFTixsWbeZ91eF4pfF8y0U6Kcm9bS84M8A_003D _0023_003DziDLVpbY_003D, _0023_003Dq1eZmN4_0024GSvLD2ByEbZhhvk4xDKGIEPcerL7ZZm1g_0024ds_003D _0023_003Dz5rQzobg_003D)
	{
		byte[] array = new byte[4];
		_0023_003DzRKe0NKxdiCWATrIbXQ_003D_003D(_0023_003DziDLVpbY_003D, array, 0, array.Length);
		int num = _0023_003DqpJzGvS9BBRbFYdUqQrKHOE18bcoZMb86GgAobmFLd5A_003D._0023_003DzWAwCHLeE7K6SG0xdk_0024BqNkOvS4rbLrPZmw_003D_003D(_0023_003DzCMZJGTujzHLQeuSVipqhrDv6DjxHipJmfA1rDn2gfZFi(array, _0023_003Dz5rQzobg_003D: false), 0);
		int num2 = _0023_003DqpJzGvS9BBRbFYdUqQrKHOE18bcoZMb86GgAobmFLd5A_003D._0023_003DzDBXut6tCvgc0S1YNOJSraJU_003D(num);
		int value = num2 - 4;
		byte[] array2 = new byte[num2];
		_0023_003DzRKe0NKxdiCWATrIbXQ_003D_003D(_0023_003DziDLVpbY_003D, array2, 4, value);
		Buffer.BlockCopy(array, 0, array2, 0, 4);
		byte[] src = _0023_003DzCMZJGTujzHLQeuSVipqhrDv6DjxHipJmfA1rDn2gfZFi(array2, _0023_003Dz5rQzobg_003D: false);
		byte[] array3 = new byte[num];
		Buffer.BlockCopy(src, 4, array3, 0, num);
		return array3;
	}

	public byte[] _0023_003DzfIPVSquqk2UYGJyE0sDtUEJ9q_tN(byte[] _0023_003DziDLVpbY_003D)
	{
		byte[] src = _0023_003DzCMZJGTujzHLQeuSVipqhrDv6DjxHipJmfA1rDn2gfZFi(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D: false);
		int num = _0023_003DqpJzGvS9BBRbFYdUqQrKHOE18bcoZMb86GgAobmFLd5A_003D._0023_003DzWAwCHLeE7K6SG0xdk_0024BqNkOvS4rbLrPZmw_003D_003D(src, 0);
		byte[] array = new byte[num];
		Buffer.BlockCopy(src, 4, array, 0, num);
		return array;
	}

	private static void _0023_003DzRKe0NKxdiCWATrIbXQ_003D_003D(_0023_003DqgLKG65nYMoFTixsWbeZ91eF4pfF8y0U6Kcm9bS84M8A_003D _0023_003DziDLVpbY_003D, byte[] _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D, int? _0023_003DzR58imxw_003D)
	{
		int num = _0023_003DzR58imxw_003D ?? (_0023_003Dz5rQzobg_003D.Length - _0023_003DzAvn2b38_003D);
		int num2;
		while ((num2 = _0023_003DziDLVpbY_003D._0023_003Dzu_0024wz50Gq3LJ8xd5lgsToLbHhVCfptTZN7NjjPuQ1kWJGK38M7lFOyzt0sHhCoqpa_0024W_0024ZkwQgzp275i1d_A_003D_003D(_0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D, num)) > 0)
		{
			_0023_003DzAvn2b38_003D += num2;
			num -= num2;
		}
	}
}
