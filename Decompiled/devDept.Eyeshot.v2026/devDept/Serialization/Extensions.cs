using System;
using System.Collections.Generic;
using System.Linq;

namespace devDept.Serialization;

public static class Extensions
{
	private sealed class _0023_003Dz2uQK1U0NkDHFlFJZJVknN4E_003D<_0023_003DzWWgGxds_003D>
	{
		public Array _0023_003DzOLHnb2M_003D;

		public ProtoArray<_0023_003DzWWgGxds_003D> _0023_003DzePnDVv2aYEOZ;

		public int _0023_003DzN6G05Lg_003D;

		internal void _0023_003DzHfHrD3Tmo4yIRrnBTQ_003D_003D(int[] _0023_003DzDPPdnUk_003D)
		{
			_0023_003DzOLHnb2M_003D.SetValue(_0023_003DzePnDVv2aYEOZ.Data[_0023_003DzN6G05Lg_003D++], _0023_003DzDPPdnUk_003D);
		}
	}

	[Serializable]
	private sealed class _0023_003DzScqzFYoOfk3xFQwc_0024A_003D_003D<_0023_003DzWWgGxds_003D>
	{
		public static readonly _0023_003DzScqzFYoOfk3xFQwc_0024A_003D_003D<_0023_003DzWWgGxds_003D> _0023_003DzJ5g3Rwo_003D = new _0023_003DzScqzFYoOfk3xFQwc_0024A_003D_003D<_0023_003DzWWgGxds_003D>();

		public static Func<ProtoJaggedArray<_0023_003DzWWgGxds_003D>, _0023_003DzWWgGxds_003D[]> _0023_003Dz7_WZ05dEvqdpEzItLA_003D_003D;

		internal _0023_003DzWWgGxds_003D[] _0023_003DzsieOeG3_goiTpMq1qzeaMNI_003D(ProtoJaggedArray<_0023_003DzWWgGxds_003D> _0023_003DzB68dg9Q_003D)
		{
			return _0023_003DzB68dg9Q_003D.Array;
		}
	}

	[Serializable]
	private sealed class _0023_003DzW55WhQrmOk0oQfHdJg_003D_003D<_0023_003DzWWgGxds_003D>
	{
		public static readonly _0023_003DzW55WhQrmOk0oQfHdJg_003D_003D<_0023_003DzWWgGxds_003D> _0023_003DzJ5g3Rwo_003D = new _0023_003DzW55WhQrmOk0oQfHdJg_003D_003D<_0023_003DzWWgGxds_003D>();

		public static Func<LinkedList<_0023_003DzWWgGxds_003D>, ProtoJaggedArray<_0023_003DzWWgGxds_003D>> _0023_003Dzb1k3XlgLXpaOl9ZXog_003D_003D;

		internal ProtoJaggedArray<_0023_003DzWWgGxds_003D> _0023_003Dzz0_0024jpLbpRoVDJij31cqfbQvFAb1d(LinkedList<_0023_003DzWWgGxds_003D> _0023_003DzB68dg9Q_003D)
		{
			return new ProtoJaggedArray<_0023_003DzWWgGxds_003D>(_0023_003DzB68dg9Q_003D.ToArray());
		}
	}

	[Serializable]
	private sealed class _0023_003DzbOeTd8Htt30a5jtudw_003D_003D<_0023_003DzWWgGxds_003D>
	{
		public static readonly _0023_003DzbOeTd8Htt30a5jtudw_003D_003D<_0023_003DzWWgGxds_003D> _0023_003DzJ5g3Rwo_003D = new _0023_003DzbOeTd8Htt30a5jtudw_003D_003D<_0023_003DzWWgGxds_003D>();

		public static Func<ProtoJaggedArray<_0023_003DzWWgGxds_003D>, LinkedList<_0023_003DzWWgGxds_003D>> _0023_003Dz_oT3R3YLF01T8K0fjw_003D_003D;

		internal LinkedList<_0023_003DzWWgGxds_003D> _0023_003DzfF_0024ugLDvrniw7MMx4D0viz8_003D(ProtoJaggedArray<_0023_003DzWWgGxds_003D> _0023_003DzB68dg9Q_003D)
		{
			return new LinkedList<_0023_003DzWWgGxds_003D>((_0023_003DzB68dg9Q_003D.Array == null) ? Array.Empty<_0023_003DzWWgGxds_003D>() : _0023_003DzB68dg9Q_003D.Array);
		}
	}

	private sealed class _0023_003DzgLWyeix2_0024l7Qwju77Jg_0024U6c_003D<_0023_003DzWWgGxds_003D>
	{
		public _0023_003DzWWgGxds_003D[] _0023_003DzELu0Pss_003D;

		public int _0023_003DzN6G05Lg_003D;

		public Array _0023_003DzTbDlaOM_003D;

		internal void _0023_003DzSN4NxRS0r30eflXOvDooP1c_003D(int[] _0023_003DzDPPdnUk_003D)
		{
			_0023_003DzELu0Pss_003D[_0023_003DzN6G05Lg_003D++] = (_0023_003DzWWgGxds_003D)_0023_003DzTbDlaOM_003D.GetValue(_0023_003DzDPPdnUk_003D);
		}
	}

	[Serializable]
	private sealed class _0023_003DzwOZee4dlgtLa3cpGZQ_003D_003D<_0023_003DzWWgGxds_003D>
	{
		public static readonly _0023_003DzwOZee4dlgtLa3cpGZQ_003D_003D<_0023_003DzWWgGxds_003D> _0023_003DzJ5g3Rwo_003D = new _0023_003DzwOZee4dlgtLa3cpGZQ_003D_003D<_0023_003DzWWgGxds_003D>();

		public static Func<_0023_003DzWWgGxds_003D[], ProtoJaggedArray<_0023_003DzWWgGxds_003D>> _0023_003Dz1_0024Aj5hrJaAa4ofcrCw_003D_003D;

		internal ProtoJaggedArray<_0023_003DzWWgGxds_003D> _0023_003DzZFUP_0024ZVeZCbJ1vNhuaFyCjUuuJrc(_0023_003DzWWgGxds_003D[] _0023_003DzB68dg9Q_003D)
		{
			return new ProtoJaggedArray<_0023_003DzWWgGxds_003D>(_0023_003DzB68dg9Q_003D);
		}
	}

	public static ProtoArray<T> ToProtoArray<T>(this Array array)
	{
		_0023_003DzgLWyeix2_0024l7Qwju77Jg_0024U6c_003D<T> _0023_003DzgLWyeix2_0024l7Qwju77Jg_0024U6c_003D2 = new _0023_003DzgLWyeix2_0024l7Qwju77Jg_0024U6c_003D<T>();
		_0023_003DzgLWyeix2_0024l7Qwju77Jg_0024U6c_003D2._0023_003DzTbDlaOM_003D = array;
		int[] array2 = new int[_0023_003DzgLWyeix2_0024l7Qwju77Jg_0024U6c_003D2._0023_003DzTbDlaOM_003D.Rank];
		for (int i = 0; i < _0023_003DzgLWyeix2_0024l7Qwju77Jg_0024U6c_003D2._0023_003DzTbDlaOM_003D.Rank; i++)
		{
			array2[i] = _0023_003DzgLWyeix2_0024l7Qwju77Jg_0024U6c_003D2._0023_003DzTbDlaOM_003D.GetLength(i);
		}
		_0023_003DzgLWyeix2_0024l7Qwju77Jg_0024U6c_003D2._0023_003DzELu0Pss_003D = new T[_0023_003DzgLWyeix2_0024l7Qwju77Jg_0024U6c_003D2._0023_003DzTbDlaOM_003D.Length];
		_0023_003DzgLWyeix2_0024l7Qwju77Jg_0024U6c_003D2._0023_003DzN6G05Lg_003D = 0;
		_0023_003DzgLWyeix2_0024l7Qwju77Jg_0024U6c_003D2._0023_003DzTbDlaOM_003D.MultiLoop(_0023_003DzgLWyeix2_0024l7Qwju77Jg_0024U6c_003D2._0023_003DzSN4NxRS0r30eflXOvDooP1c_003D);
		return new ProtoArray<T>
		{
			Dimensions = array2,
			Data = _0023_003DzgLWyeix2_0024l7Qwju77Jg_0024U6c_003D2._0023_003DzELu0Pss_003D
		};
	}

	public static Array ToArray<T>(this ProtoArray<T> protoArray)
	{
		_0023_003Dz2uQK1U0NkDHFlFJZJVknN4E_003D<T> _0023_003Dz2uQK1U0NkDHFlFJZJVknN4E_003D2 = new _0023_003Dz2uQK1U0NkDHFlFJZJVknN4E_003D<T>();
		_0023_003Dz2uQK1U0NkDHFlFJZJVknN4E_003D2._0023_003DzePnDVv2aYEOZ = protoArray;
		_0023_003Dz2uQK1U0NkDHFlFJZJVknN4E_003D2._0023_003DzOLHnb2M_003D = Array.CreateInstance(typeof(T), _0023_003Dz2uQK1U0NkDHFlFJZJVknN4E_003D2._0023_003DzePnDVv2aYEOZ.Dimensions);
		_0023_003Dz2uQK1U0NkDHFlFJZJVknN4E_003D2._0023_003DzN6G05Lg_003D = 0;
		_0023_003Dz2uQK1U0NkDHFlFJZJVknN4E_003D2._0023_003DzOLHnb2M_003D.MultiLoop(_0023_003Dz2uQK1U0NkDHFlFJZJVknN4E_003D2._0023_003DzHfHrD3Tmo4yIRrnBTQ_003D_003D);
		return _0023_003Dz2uQK1U0NkDHFlFJZJVknN4E_003D2._0023_003DzOLHnb2M_003D;
	}

	public static List<ProtoJaggedArray<T>> ToProtoJaggedArrayList<T>(this T[][] array)
	{
		return array.Select((T[] _0023_003DzB68dg9Q_003D) => new ProtoJaggedArray<T>(_0023_003DzB68dg9Q_003D)).ToList();
	}

	public static List<ProtoJaggedArray<T>> ToProtoJaggedArrayList<T>(this LinkedList<T>[] array)
	{
		return array.Select((LinkedList<T> _0023_003DzB68dg9Q_003D) => new ProtoJaggedArray<T>(_0023_003DzB68dg9Q_003D.ToArray())).ToList();
	}

	public static List<KeyValuePair<T, ProtoJaggedArray<V>>> ToProtoJaggedArrayKeyValueList<T, V>(this Dictionary<T, LinkedList<V>> array)
	{
		List<KeyValuePair<T, ProtoJaggedArray<V>>> list = new List<KeyValuePair<T, ProtoJaggedArray<V>>>();
		foreach (KeyValuePair<T, LinkedList<V>> item in array)
		{
			list.Add(new KeyValuePair<T, ProtoJaggedArray<V>>(item.Key, new ProtoJaggedArray<V>(item.Value.ToArray())));
		}
		return list;
	}

	public static T[][] ToJaggedArray<T>(this List<ProtoJaggedArray<T>> protoJaggedArrayList)
	{
		return protoJaggedArrayList.Select(_0023_003DzScqzFYoOfk3xFQwc_0024A_003D_003D<T>._0023_003DzJ5g3Rwo_003D._0023_003DzsieOeG3_goiTpMq1qzeaMNI_003D).ToList().ToArray();
	}

	public static LinkedList<T>[] ToJaggedLinkedList<T>(this List<ProtoJaggedArray<T>> protoJaggedArrayList)
	{
		return protoJaggedArrayList?.Select((ProtoJaggedArray<T> _0023_003DzB68dg9Q_003D) => new LinkedList<T>((_0023_003DzB68dg9Q_003D.Array == null) ? Array.Empty<T>() : _0023_003DzB68dg9Q_003D.Array)).ToArray();
	}

	public static Dictionary<T, LinkedList<V>> ToDictionary<T, V>(this List<KeyValuePair<T, ProtoJaggedArray<V>>> protoJaggedArrayList)
	{
		Dictionary<T, LinkedList<V>> dictionary = new Dictionary<T, LinkedList<V>>();
		if (protoJaggedArrayList != null)
		{
			foreach (KeyValuePair<T, ProtoJaggedArray<V>> protoJaggedArray in protoJaggedArrayList)
			{
				dictionary[protoJaggedArray.Key] = new LinkedList<V>((protoJaggedArray.Value.Array == null) ? Array.Empty<V>() : protoJaggedArray.Value.Array);
			}
		}
		return dictionary;
	}

	public static void MultiLoop(this Array array, Action<int[]> action)
	{
		array._0023_003Dzggg_0024qb09nMDP(0, new int[array.Rank], action);
	}

	private static void _0023_003Dzggg_0024qb09nMDP(this Array _0023_003DzTbDlaOM_003D, int _0023_003DzfNi7d4A_003D, int[] _0023_003DzDPPdnUk_003D, Action<int[]> _0023_003DzaPWY5KY_003D)
	{
		if (_0023_003DzfNi7d4A_003D == _0023_003DzTbDlaOM_003D.Rank)
		{
			_0023_003DzaPWY5KY_003D(_0023_003DzDPPdnUk_003D);
			return;
		}
		_0023_003DzDPPdnUk_003D[_0023_003DzfNi7d4A_003D] = 0;
		while (_0023_003DzDPPdnUk_003D[_0023_003DzfNi7d4A_003D] < _0023_003DzTbDlaOM_003D.GetLength(_0023_003DzfNi7d4A_003D))
		{
			_0023_003DzTbDlaOM_003D._0023_003Dzggg_0024qb09nMDP(_0023_003DzfNi7d4A_003D + 1, _0023_003DzDPPdnUk_003D, _0023_003DzaPWY5KY_003D);
			_0023_003DzDPPdnUk_003D[_0023_003DzfNi7d4A_003D]++;
		}
	}
}
