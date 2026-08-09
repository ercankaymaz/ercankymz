using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

internal sealed class _0023_003Dqv5jNEINgRiU3U0uL89SFazWZlPujI4XaQ4TJIxsu8VU_003D : _0023_003Dq_ibtQ1uSDbfMzR2aZwe8aJ_qUbgrdIrzp9AqqqgWLPs_003D
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ICryptoTransform _0023_003DzjYYAPCA_003D;

	public _0023_003Dqv5jNEINgRiU3U0uL89SFazWZlPujI4XaQ4TJIxsu8VU_003D(ICryptoTransform _0023_003DzjYYAPCA_003D)
	{
		this._0023_003DzjYYAPCA_003D = _0023_003DzjYYAPCA_003D;
	}

	public override void Dispose()
	{
		_0023_003DzjYYAPCA_003D.Dispose();
	}

	[SpecialName]
	public override bool _0023_003DzwVg92l3jEKWvzTQ5P3WeDuFoGy_yub2GxBkf97bqgUrR9XzjWk8QKqF8TyF2X8UHveh67pq3APt6_azuyKpjbWs_003D()
	{
		return _0023_003DzjYYAPCA_003D.CanReuseTransform;
	}

	[SpecialName]
	public override int _0023_003DzJNkN_de2QQgIBI4XbCB_0024P8F4MtNUZAY7CqNjIQO57dSP2LqLV6FZxYreevxfTEjmn9Ywbh7E7fbU9R2nFClkIfw_003D()
	{
		return _0023_003DzjYYAPCA_003D.InputBlockSize;
	}

	public override int _0023_003Dz74czmZ4f1GsTNvvJNv9jiT8M_721YRTBQmcyB4xja1pDEfpyc9V3v75lCehZfZ3Us_F0DCOTU_00247R(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D, byte[] _0023_003Dzf4Pqh9s_003D, int _0023_003DzTFNDoh0_003D)
	{
		return this._0023_003DzjYYAPCA_003D.TransformBlock(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D, _0023_003DzTFNDoh0_003D);
	}

	public override byte[] _0023_003DzFTKLZnfC69fNvmtoItd7HUBg1zCNQYN7oP0aUoCy1sXo2Y6Xk96zs9eXQBcZAAXA9w_003D_003D(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D)
	{
		return this._0023_003DzjYYAPCA_003D.TransformFinalBlock(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D);
	}
}
