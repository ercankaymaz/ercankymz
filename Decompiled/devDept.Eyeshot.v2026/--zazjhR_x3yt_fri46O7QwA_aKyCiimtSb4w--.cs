using System.Collections.Generic;

internal class _0023_003DzazjhR_x3yt_fri46O7QwA_aKyCiimtSb4w_003D_003D
{
	protected _0023_003DzazjhR_x3yt_fri46O7QwA_aKyCiimtSb4w_003D_003D[] _0023_003Dz7qgjasQ_003D;

	internal _0023_003DzazjhR_x3yt_fri46O7QwA_aKyCiimtSb4w_003D_003D _0023_003Dzdaq5UoE_003D(List<int> _0023_003DzE3POwBw_003D)
	{
		_0023_003DzazjhR_x3yt_fri46O7QwA_aKyCiimtSb4w_003D_003D _0023_003DzazjhR_x3yt_fri46O7QwA_aKyCiimtSb4w_003D_003D2 = this;
		for (int i = 0; i < _0023_003DzE3POwBw_003D.Count; i++)
		{
			_0023_003DzazjhR_x3yt_fri46O7QwA_aKyCiimtSb4w_003D_003D2 = _0023_003DzazjhR_x3yt_fri46O7QwA_aKyCiimtSb4w_003D_003D2._0023_003Dz7qgjasQ_003D[_0023_003DzE3POwBw_003D[i]];
		}
		return _0023_003DzazjhR_x3yt_fri46O7QwA_aKyCiimtSb4w_003D_003D2;
	}

	internal _0023_003DzazjhR_x3yt_fri46O7QwA_aKyCiimtSb4w_003D_003D _0023_003Dzdaq5UoE_003D(LinkedList<int> _0023_003DzE3POwBw_003D)
	{
		LinkedListNode<int> linkedListNode = _0023_003DzE3POwBw_003D.First;
		_0023_003DzazjhR_x3yt_fri46O7QwA_aKyCiimtSb4w_003D_003D _0023_003DzazjhR_x3yt_fri46O7QwA_aKyCiimtSb4w_003D_003D2;
		if (linkedListNode != null)
		{
			_0023_003DzazjhR_x3yt_fri46O7QwA_aKyCiimtSb4w_003D_003D2 = _0023_003Dz7qgjasQ_003D[linkedListNode.Value];
			while (linkedListNode.Next != null)
			{
				linkedListNode = linkedListNode.Next;
				_0023_003DzazjhR_x3yt_fri46O7QwA_aKyCiimtSb4w_003D_003D2 = _0023_003DzazjhR_x3yt_fri46O7QwA_aKyCiimtSb4w_003D_003D2._0023_003Dz7qgjasQ_003D[linkedListNode.Value];
			}
		}
		else
		{
			_0023_003DzazjhR_x3yt_fri46O7QwA_aKyCiimtSb4w_003D_003D2 = this;
		}
		return _0023_003DzazjhR_x3yt_fri46O7QwA_aKyCiimtSb4w_003D_003D2;
	}
}
