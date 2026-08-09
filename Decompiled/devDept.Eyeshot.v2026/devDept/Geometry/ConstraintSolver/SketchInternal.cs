using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
using System.Xml;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
internal sealed class SketchInternal : SketchBase
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<KeyValuePair<Id, Constraint>, Id> _0023_003Dz_oT3R3YLF01T8K0fjw_003D_003D;

		public static Func<KeyValuePair<Id, Constraint>, Constraint> _0023_003DzSgc5E_0024kO3AvySQ4LCg_003D_003D;

		public static Func<KeyValuePair<Id, Id>, Id> _0023_003Dz8lPgcijH_0024_STyeKo4w_003D_003D;

		public static Func<KeyValuePair<Id, Id>, Id> _0023_003DzeXmgS3gY9rLpX4z5TA_003D_003D;

		internal Id _0023_003DzqI9OWicSIkv4EDqvLQ_003D_003D(KeyValuePair<Id, Constraint> _0023_003Dz2uRRF4k_003D)
		{
			return _0023_003Dz2uRRF4k_003D.Key;
		}

		internal Constraint _0023_003DzltnjY5iLc074rVt0Ig_003D_003D(KeyValuePair<Id, Constraint> _0023_003Dz2uRRF4k_003D)
		{
			return _0023_003Dz2uRRF4k_003D.Value;
		}

		internal Id _0023_003Dze4gk8we49no5G18iKQ_003D_003D(KeyValuePair<Id, Id> _0023_003Dz2uRRF4k_003D)
		{
			return _0023_003Dz2uRRF4k_003D.Key;
		}

		internal Id _0023_003DzMactHWcONCMeWGddsA_003D_003D(KeyValuePair<Id, Id> _0023_003Dz2uRRF4k_003D)
		{
			return _0023_003Dz2uRRF4k_003D.Value;
		}
	}

	private sealed class _0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D
	{
		public SketchCurve _0023_003DzWh_kbmtGtUcbjPAmiQ_003D_003D;

		internal bool _0023_003DzCZfFYC_0024pQG3BXbpruA_003D_003D(KeyValuePair<Id, SketchCurve> _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.Key.value == _0023_003DzWh_kbmtGtUcbjPAmiQ_003D_003D._0023_003DzDQs07gDx7oDr().value;
		}
	}

	private sealed class _0023_003DzH01TB2R5MAeS : Comparer<Id>
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Dictionary<Id, int> _0023_003DzaoRZgFfnoVnX;

		public _0023_003DzH01TB2R5MAeS(Dictionary<Id, int> _0023_003Dz2AarSByzGO1e)
		{
			_0023_003DzaoRZgFfnoVnX = _0023_003Dz2AarSByzGO1e;
		}

		public override int Compare(Id _0023_003DzBJFJHwk_003D, Id _0023_003Dz40R7bAU_003D)
		{
			return _0023_003DzaoRZgFfnoVnX[_0023_003DzBJFJHwk_003D].CompareTo(_0023_003DzaoRZgFfnoVnX[_0023_003Dz40R7bAU_003D]);
		}
	}

	private sealed class _0023_003DzKon_0024MHsqE_0024l9Pan3G75hxD8_003D
	{
		public Constraint _0023_003Dz4wcRs5s_003D;

		public Func<Constraint, bool> _0023_003DzkqbsCVPMJ_0024g6;

		internal bool _0023_003DzYN5L1nwjcF7ar4uaNZJfqUI_DcXe(Constraint _0023_003DzV_0024oduG8_003D)
		{
			return _0023_003DzV_0024oduG8_003D != _0023_003Dz4wcRs5s_003D;
		}
	}

	internal List<Exp> dragExp = new List<Exp>();

	public int DOF;

	public int RankExcess;

	public Plane Plane = Plane.XY;

	private Dictionary<Id, SketchCurve> entities = new Dictionary<Id, SketchCurve>();

	private Dictionary<Id, Constraint> constraints = new Dictionary<Id, Constraint>();

	public _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D plane;

	public bool is3d;

	internal IdGenerator idGenerator = new IdGenerator();

	[CompilerGenerated]
	private Id _003Cguid_003Ek__BackingField;

	public Dictionary<Id, Id> idMapping;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static ConcurrentDictionary<int, Dictionary<Param, Param>> _0023_003Dz6JPAgTOPk4UIx7cxa37pQdEOfWO7 = new ConcurrentDictionary<int, Dictionary<Param, Param>>();

	public SketchInternal()
	{
	}

	protected SketchInternal(SketchInternal _0023_003DzySgeilxprQOK)
		: base(_0023_003DzySgeilxprQOK)
	{
		Dictionary<Constraint, Constraint> _0023_003DzSrg4qMj9Al_0024 = new Dictionary<Constraint, Constraint>();
		Dictionary<Id, int> dictionary = new Dictionary<Id, int>();
		int num = 0;
		foreach (KeyValuePair<Id, SketchCurve> entity in _0023_003DzySgeilxprQOK.entities)
		{
			dictionary[entity.Key] = num++;
		}
		entities = new Dictionary<Id, SketchCurve>(_0023_003DzySgeilxprQOK.entities.Count);
		constraints = new Dictionary<Id, Constraint>(_0023_003DzySgeilxprQOK.constraints.Count);
		foreach (KeyValuePair<Id, SketchCurve> entity2 in _0023_003DzySgeilxprQOK.entities)
		{
			Id key = entity2.Key;
			SketchCurve value = entity2.Value;
			if (value.ParentCurve != null)
			{
				continue;
			}
			entities[key] = (SketchCurve)value.Clone();
			entities[key]._0023_003Dz4rsUxOLl8ATWosrQiQ_003D_003D(this);
			List<Constraint> _0023_003DzGOv4wPIA4lza_bgf2No26H6OtwHb = _0023_003DzySgeilxprQOK._0023_003DzmhwHHfYvC_oJ().ToList();
			using (List<SketchCurve>.Enumerator enumerator2 = entities[key].children.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					_0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D CS_0024_003C_003E8__locals6 = new _0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D();
					CS_0024_003C_003E8__locals6._0023_003DzWh_kbmtGtUcbjPAmiQ_003D_003D = enumerator2.Current;
					CS_0024_003C_003E8__locals6._0023_003DzWh_kbmtGtUcbjPAmiQ_003D_003D._0023_003Dz4rsUxOLl8ATWosrQiQ_003D_003D(this);
					_0023_003DzRCrpdGA_003D(CS_0024_003C_003E8__locals6._0023_003DzWh_kbmtGtUcbjPAmiQ_003D_003D);
					KeyValuePair<Id, SketchCurve> keyValuePair = _0023_003DzySgeilxprQOK.entities.FirstOrDefault((KeyValuePair<Id, SketchCurve> _0023_003DzBJFJHwk_003D) => _0023_003DzBJFJHwk_003D.Key.value == CS_0024_003C_003E8__locals6._0023_003DzWh_kbmtGtUcbjPAmiQ_003D_003D._0023_003DzDQs07gDx7oDr().value);
					if (keyValuePair.Value != null)
					{
						_0023_003DzwMqkv5ZElkaSObnbVw_003D_003D(CS_0024_003C_003E8__locals6._0023_003DzWh_kbmtGtUcbjPAmiQ_003D_003D, _0023_003DzGOv4wPIA4lza_bgf2No26H6OtwHb, keyValuePair.Value.usedInConstraints, _0023_003DzSrg4qMj9Al_0024, dictionary);
						continue;
					}
					throw new EyeshotException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657492), CS_0024_003C_003E8__locals6._0023_003DzWh_kbmtGtUcbjPAmiQ_003D_003D._0023_003DzDQs07gDx7oDr().value));
				}
			}
			_0023_003DzwMqkv5ZElkaSObnbVw_003D_003D(entities[key], _0023_003DzGOv4wPIA4lza_bgf2No26H6OtwHb, value.usedInConstraints, _0023_003DzSrg4qMj9Al_0024, dictionary);
		}
		Dictionary<Id, SketchCurve> dictionary2 = new Dictionary<Id, SketchCurve>(_0023_003DzySgeilxprQOK.entities.Count);
		foreach (KeyValuePair<Id, SketchCurve> entity3 in _0023_003DzySgeilxprQOK.entities)
		{
			if (entities.ContainsKey(entity3.Key))
			{
				dictionary2[entity3.Key] = entities[entity3.Key];
			}
		}
		entities = dictionary2;
		SortedDictionary<Id, Constraint> source = new SortedDictionary<Id, Constraint>(constraints, new _0023_003DzH01TB2R5MAeS(dictionary));
		constraints = source.ToDictionary(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzqI9OWicSIkv4EDqvLQ_003D_003D, _0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzltnjY5iLc074rVt0Ig_003D_003D);
		if (_0023_003DzySgeilxprQOK.idMapping != null)
		{
			idMapping = _0023_003DzySgeilxprQOK.idMapping.ToDictionary(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dze4gk8we49no5G18iKQ_003D_003D, _0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzMactHWcONCMeWGddsA_003D_003D);
		}
		idGenerator._0023_003Dzuxxvjv8_003D = _0023_003DzySgeilxprQOK.idGenerator._0023_003Dzuxxvjv8_003D;
	}

	protected SketchInternal(SerializationInfo _0023_003Dz9lrNnXY_003D, StreamingContext _0023_003DzB8iS0QA_003D)
		: base(_0023_003Dz9lrNnXY_003D, _0023_003DzB8iS0QA_003D)
	{
		idMapping = (Dictionary<Id, Id>)_0023_003Dz9lrNnXY_003D.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657108), typeof(Dictionary<Id, Id>));
		entities = (Dictionary<Id, SketchCurve>)_0023_003Dz9lrNnXY_003D.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657120), typeof(Dictionary<Id, SketchCurve>));
		constraints = (Dictionary<Id, Constraint>)_0023_003Dz9lrNnXY_003D.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656698), typeof(Dictionary<Id, Constraint>));
		idGenerator._0023_003Dzuxxvjv8_003D = _0023_003Dz9lrNnXY_003D.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657101));
		Plane = (Plane)_0023_003Dz9lrNnXY_003D.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974845), typeof(Plane));
	}

	private void _0023_003DzwMqkv5ZElkaSObnbVw_003D_003D(SketchCurve _0023_003DzIpCXIf1GmttHQRSf8w_003D_003D, List<Constraint> _0023_003DzGOv4wPIA4lza_bgf2No26H6OtwHb, List<Constraint> _0023_003Dz1QG4L9d7ZQBX, Dictionary<Constraint, Constraint> _0023_003DzSrg4qMj9Al_00246, Dictionary<Id, int> _0023_003Dz2AarSByzGO1e)
	{
		_0023_003DzIpCXIf1GmttHQRSf8w_003D_003D.usedInConstraints.Clear();
		foreach (Constraint item in _0023_003Dz1QG4L9d7ZQBX)
		{
			if (!_0023_003DzSrg4qMj9Al_00246.ContainsKey(item))
			{
				_0023_003DzSrg4qMj9Al_00246[item] = (Constraint)item.Clone();
				constraints[item._0023_003DzDQs07gDx7oDr()] = _0023_003DzSrg4qMj9Al_00246[item];
				constraints[item._0023_003DzDQs07gDx7oDr()]._0023_003Dz4rsUxOLl8ATWosrQiQ_003D_003D(this);
				int value = _0023_003DzGOv4wPIA4lza_bgf2No26H6OtwHb.IndexOf(item);
				_0023_003Dz2AarSByzGO1e[_0023_003DzSrg4qMj9Al_00246[item]._0023_003DzDQs07gDx7oDr()] = value;
			}
			_0023_003DzIpCXIf1GmttHQRSf8w_003D_003D.usedInConstraints.Add(_0023_003DzSrg4qMj9Al_00246[item]);
		}
	}

	public List<SketchCurve> _0023_003DzW1wgPM78KxwE()
	{
		return entities.Values.ToList();
	}

	internal bool _0023_003DzlGXalEw_003D()
	{
		if (entities != null)
		{
			return constraints != null;
		}
		return false;
	}

	public IEnumerable<Constraint> _0023_003DzmhwHHfYvC_oJ()
	{
		return constraints.Values.AsEnumerable();
	}

	[SpecialName]
	[CompilerGenerated]
	internal override Id _0023_003DzDQs07gDx7oDr()
	{
		return _003Cguid_003Ek__BackingField;
	}

	[SpecialName]
	[CompilerGenerated]
	internal override void _0023_003DzxWZ7yqG65a6T(Id _0023_003DzPzO_0024GUk_003D)
	{
		_003Cguid_003Ek__BackingField = _0023_003DzPzO_0024GUk_003D;
	}

	[SpecialName]
	internal override SketchBase _0023_003DziNzzmPCarBGC()
	{
		return null;
	}

	public void _0023_003DzRCrpdGA_003D(SketchCurve _0023_003DzbfrNXYE_003D)
	{
		if (!entities.ContainsKey(_0023_003DzbfrNXYE_003D._0023_003DzDQs07gDx7oDr()))
		{
			entities.Add(_0023_003DzbfrNXYE_003D._0023_003DzDQs07gDx7oDr(), _0023_003DzbfrNXYE_003D);
		}
	}

	public SketchCurve _0023_003Dzjrbkyo8_003D(Id _0023_003DzG5EGDUs_003D)
	{
		SketchCurve value = null;
		entities.TryGetValue(_0023_003DzG5EGDUs_003D, out value);
		return value;
	}

	public Constraint _0023_003DzTLROap4_003D(Id _0023_003DzG5EGDUs_003D)
	{
		Constraint value = null;
		constraints.TryGetValue(_0023_003DzG5EGDUs_003D, out value);
		return value;
	}

	public void _0023_003Dz55vCXok_003D(Constraint _0023_003Dzt_m8zV0_003D)
	{
		if (!constraints.ContainsKey(_0023_003Dzt_m8zV0_003D._0023_003DzDQs07gDx7oDr()))
		{
			constraints.Add(_0023_003Dzt_m8zV0_003D._0023_003DzDQs07gDx7oDr(), _0023_003Dzt_m8zV0_003D);
		}
	}

	internal HashSet<SketchItem> _0023_003DzDNS_0024gnq0318I1_h2vg_003D_003D(_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D _0023_003DzTBw70ks_003D, Constraint _0023_003Dz4wcRs5s_003D, SketchItem _0023_003Dz0U_Pa5U_003D)
	{
		_0023_003DzKon_0024MHsqE_0024l9Pan3G75hxD8_003D _0023_003DzKon_0024MHsqE_0024l9Pan3G75hxD8_003D2 = new _0023_003DzKon_0024MHsqE_0024l9Pan3G75hxD8_003D();
		_0023_003DzKon_0024MHsqE_0024l9Pan3G75hxD8_003D2._0023_003Dz4wcRs5s_003D = _0023_003Dz4wcRs5s_003D;
		_0023_003DzTBw70ks_003D._0023_003DzSJnfST_p7FvhG2o4OQ_003D_003D(dragExp);
		HashSet<SketchItem> hashSet = null;
		if (_0023_003Dz0U_Pa5U_003D != null && !(_0023_003Dz0U_Pa5U_003D is SketchCurve { Fixed: not false }))
		{
			Stack<SketchItem> stack = new Stack<SketchItem>();
			hashSet = new HashSet<SketchItem>();
			stack.Push(_0023_003Dz0U_Pa5U_003D);
			hashSet.Add(_0023_003Dz0U_Pa5U_003D);
			foreach (SketchCurve value2 in entities.Values)
			{
				if (!value2.Fixed && value2._0023_003DzZ_ilKakl9sw5() != null && value2._0023_003DzZ_ilKakl9sw5().Selected && hashSet.Add(value2))
				{
					stack.Push(value2);
				}
			}
			while (stack.Count > 0)
			{
				SketchItem sketchItem = stack.Pop();
				if (!(sketchItem is SketchCurve { Fixed: not false }))
				{
					_0023_003DzTBw70ks_003D._0023_003DzIAHusRU_003D(sketchItem._0023_003DzGVWngirLnmOL());
					_0023_003DzTBw70ks_003D._0023_003DzSJnfST_p7FvhG2o4OQ_003D_003D(sketchItem._0023_003DzYi2k33SIk8bhOhY4gQ_003D_003D());
				}
				if (sketchItem is SketchCurve { Fixed: false } sketchCurve3)
				{
					if (sketchCurve3.ParentCurve != null && hashSet.Add(sketchCurve3.ParentCurve))
					{
						stack.Push(sketchCurve3.ParentCurve);
					}
					foreach (SketchPoint item3 in sketchCurve3._0023_003DzgJiUT1qDtKLT())
					{
						if (hashSet.Add(item3))
						{
							stack.Push(item3);
						}
					}
					Constraint[] array = sketchCurve3.Constraints;
					foreach (Constraint item in array)
					{
						if (hashSet.Add(item))
						{
							stack.Push(item);
						}
					}
				}
				else
				{
					if (!(sketchItem is Constraint constraint) || constraint == _0023_003DzKon_0024MHsqE_0024l9Pan3G75hxD8_003D2._0023_003Dz4wcRs5s_003D)
					{
						continue;
					}
					SketchCurve[] array2 = constraint.GetEntities();
					foreach (SketchCurve item2 in array2)
					{
						if (hashSet.Add(item2))
						{
							stack.Push(item2);
						}
					}
				}
			}
		}
		else
		{
			foreach (KeyValuePair<Id, SketchCurve> entity in entities)
			{
				SketchCurve value = entity.Value;
				if (!value.Fixed)
				{
					_0023_003DzTBw70ks_003D._0023_003DzIAHusRU_003D(value._0023_003DzGVWngirLnmOL());
					_0023_003DzTBw70ks_003D._0023_003DzSJnfST_p7FvhG2o4OQ_003D_003D(value._0023_003DzYi2k33SIk8bhOhY4gQ_003D_003D());
				}
			}
			foreach (Constraint item4 in constraints.Values.Where(_0023_003DzKon_0024MHsqE_0024l9Pan3G75hxD8_003D2._0023_003DzYN5L1nwjcF7ar4uaNZJfqUI_DcXe))
			{
				_0023_003DzTBw70ks_003D._0023_003DzIAHusRU_003D(item4._0023_003DzGVWngirLnmOL());
				_0023_003DzTBw70ks_003D._0023_003DzSJnfST_p7FvhG2o4OQ_003D_003D(item4._0023_003DzYi2k33SIk8bhOhY4gQ_003D_003D());
			}
		}
		return hashSet;
	}

	internal override ISketchBase _0023_003DzCzT7cK4_003D(Id _0023_003DzG5EGDUs_003D)
	{
		SketchCurve sketchCurve = _0023_003Dzjrbkyo8_003D(_0023_003DzG5EGDUs_003D);
		if (sketchCurve != null)
		{
			return sketchCurve;
		}
		return _0023_003DzTLROap4_003D(_0023_003DzG5EGDUs_003D);
	}

	public IEnumerable<Constraint> _0023_003DzcY5bzszfS2iK()
	{
		List<Constraint> list = new List<Constraint>();
		if (RankExcess <= 0)
		{
			return new List<Constraint>();
		}
		foreach (Constraint item in _0023_003DzmhwHHfYvC_oJ())
		{
			_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D _0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2 = new _0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D();
			_0023_003DzDNS_0024gnq0318I1_h2vg_003D_003D(_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2, item, null);
			_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2._0023_003DzOykoXtw_003D();
			if (RankExcess > _0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2._0023_003DzbZBxE_0024c_003D(out var _))
			{
				list.Add(item);
			}
		}
		return list;
	}

	internal bool _0023_003Dzqh_BTJs_003D(Constraint _0023_003Dz9EdxXqI_003D)
	{
		_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D _0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2 = new _0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D();
		_0023_003DzDNS_0024gnq0318I1_h2vg_003D_003D(_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2, null, null);
		solveFailureType solveFailureType2 = _0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2._0023_003DzOykoXtw_003D();
		if (solveFailureType2 == solveFailureType.Redundant || solveFailureType2 == solveFailureType.DidntConverge)
		{
			return false;
		}
		int _0023_003DzeaV2Z0o_003D;
		int num = _0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2._0023_003DzbZBxE_0024c_003D(out _0023_003DzeaV2Z0o_003D);
		_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2 = new _0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D();
		_0023_003DzDNS_0024gnq0318I1_h2vg_003D_003D(_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2, _0023_003Dz9EdxXqI_003D, null);
		_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2._0023_003DzOykoXtw_003D();
		if (num > _0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2._0023_003DzbZBxE_0024c_003D(out _0023_003DzeaV2Z0o_003D))
		{
			return false;
		}
		return true;
	}

	internal solveFailureType _0023_003DzOykoXtw_003D(out HashSet<SketchItem> _0023_003Dz5PjoC_vVvm2Y, SketchItem _0023_003Dz0U_Pa5U_003D)
	{
		_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D _0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2 = new _0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D();
		_0023_003Dz5PjoC_vVvm2Y = _0023_003DzDNS_0024gnq0318I1_h2vg_003D_003D(_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2, null, _0023_003Dz0U_Pa5U_003D);
		solveFailureType solveFailureType2 = _0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2._0023_003DzOykoXtw_003D();
		if (_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2._0023_003DzeuAWUmtyUODT() && solveFailureType2 == solveFailureType.Success && !_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2._0023_003Dz_rjtkYs_003D())
		{
			RankExcess = _0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2._0023_003DzbZBxE_0024c_003D(out DOF);
			if (RankExcess > 0)
			{
				solveFailureType2 = solveFailureType.Redundant;
			}
		}
		return solveFailureType2;
	}

	public void _0023_003Dzqx2DhVY_003D(XmlTextWriter _0023_003Dzzic3a9w_003D)
	{
		if (entities.Count > 0)
		{
			_0023_003Dzzic3a9w_003D.WriteStartElement(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657081));
			foreach (KeyValuePair<Id, SketchCurve> entity in entities)
			{
				SketchCurve value = entity.Value;
				if (value.ParentCurve == null)
				{
					value._0023_003Dzqx2DhVY_003D(_0023_003Dzzic3a9w_003D);
				}
			}
			_0023_003Dzzic3a9w_003D.WriteEndElement();
		}
		if (constraints.Count > 0)
		{
			_0023_003Dzzic3a9w_003D.WriteStartElement(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657066));
			foreach (Constraint value2 in constraints.Values)
			{
				value2._0023_003Dzqx2DhVY_003D(_0023_003Dzzic3a9w_003D);
			}
			_0023_003Dzzic3a9w_003D.WriteEndElement();
		}
		if (Plane != null)
		{
			_0023_003Dzzic3a9w_003D.WriteStartElement(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657052));
			_0023_003Dzzic3a9w_003D.WriteStartElement(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657032));
			_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302935446), Plane.Origin.X.ToString());
			_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655754), Plane.Origin.Y.ToString());
			_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655986), Plane.Origin.Z.ToString());
			_0023_003Dzzic3a9w_003D.WriteEndElement();
			_0023_003Dzzic3a9w_003D.WriteStartElement(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657267));
			_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302935446), Plane.AxisX.X.ToString());
			_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655754), Plane.AxisX.Y.ToString());
			_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655986), Plane.AxisX.Z.ToString());
			_0023_003Dzzic3a9w_003D.WriteEndElement();
			_0023_003Dzzic3a9w_003D.WriteStartElement(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657279));
			_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302935446), Plane.AxisY.X.ToString());
			_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655754), Plane.AxisY.Y.ToString());
			_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655986), Plane.AxisY.Z.ToString());
			_0023_003Dzzic3a9w_003D.WriteEndElement();
			_0023_003Dzzic3a9w_003D.WriteEndElement();
		}
		if (Plane != null)
		{
			_0023_003Dzzic3a9w_003D.WriteStartElement(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657052));
			_0023_003Dzzic3a9w_003D.WriteStartElement(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657032));
			_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302935446), Plane.Origin.X.ToString());
			_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655754), Plane.Origin.Y.ToString());
			_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655986), Plane.Origin.Z.ToString());
			_0023_003Dzzic3a9w_003D.WriteEndElement();
			_0023_003Dzzic3a9w_003D.WriteStartElement(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657267));
			_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302935446), Plane.AxisX.X.ToString());
			_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655754), Plane.AxisX.Y.ToString());
			_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655986), Plane.AxisX.Z.ToString());
			_0023_003Dzzic3a9w_003D.WriteEndElement();
			_0023_003Dzzic3a9w_003D.WriteStartElement(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657279));
			_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302935446), Plane.AxisY.X.ToString());
			_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655754), Plane.AxisY.Y.ToString());
			_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655986), Plane.AxisY.Z.ToString());
			_0023_003Dzzic3a9w_003D.WriteEndElement();
			_0023_003Dzzic3a9w_003D.WriteEndElement();
		}
	}

	public void _0023_003DzVemZ00E_003D(XmlNode _0023_003Dzzic3a9w_003D, bool _0023_003DzHFcgloE_003D)
	{
		if (_0023_003DzHFcgloE_003D)
		{
			idMapping = new Dictionary<Id, Id>();
		}
		foreach (XmlNode childNode in _0023_003Dzzic3a9w_003D.ChildNodes)
		{
			if (childNode.Name == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657081))
			{
				foreach (XmlNode childNode2 in childNode.ChildNodes)
				{
					if (!(childNode2.Name != _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655099)))
					{
						SketchCurve sketchCurve = SketchCurve._0023_003DzSfMvOM4_003D(childNode2.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655404)].Value, this);
						if (childNode2.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656670)] != null)
						{
							sketchCurve.Construction = bool.Parse(childNode2.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656670)].Value);
						}
						sketchCurve._0023_003DzVemZ00E_003D(childNode2);
					}
				}
				List<SketchCurve> list = entities.Values.ToList();
				entities.Clear();
				foreach (SketchCurve item in list)
				{
					entities.Add(item._0023_003DzDQs07gDx7oDr(), item);
				}
			}
			if (childNode.Name == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657066))
			{
				foreach (XmlNode childNode3 in childNode.ChildNodes)
				{
					if (!(childNode3.Name != _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655417)))
					{
						Constraint._0023_003DzSfMvOM4_003D(childNode3.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655404)].Value, this)._0023_003DzVemZ00E_003D(childNode3);
					}
				}
				List<Constraint> list2 = constraints.Values.ToList();
				constraints.Clear();
				foreach (Constraint item2 in list2)
				{
					constraints.Add(item2._0023_003DzDQs07gDx7oDr(), item2);
				}
			}
			if (!(childNode.Name == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657052)))
			{
				continue;
			}
			double _0023_003DzBJFJHwk_003D = 0.0;
			double _0023_003Dz40R7bAU_003D = 0.0;
			double _0023_003DzId5C3LA_003D = 0.0;
			double _0023_003DzBJFJHwk_003D2 = 1.0;
			double _0023_003Dz40R7bAU_003D2 = 0.0;
			double _0023_003DzId5C3LA_003D2 = 0.0;
			double _0023_003DzBJFJHwk_003D3 = 0.0;
			double _0023_003Dz40R7bAU_003D3 = 1.0;
			double _0023_003DzId5C3LA_003D3 = 0.0;
			foreach (XmlNode childNode4 in childNode.ChildNodes)
			{
				if (childNode4.Name == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657032))
				{
					_0023_003Dqlmii39LmpEKFiNuwVhWeIl1jUnHZZW5ZB8js1wwGKzw_003D(childNode4, out _0023_003DzBJFJHwk_003D, out _0023_003Dz40R7bAU_003D, out _0023_003DzId5C3LA_003D);
				}
				else if (childNode4.Name == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657267))
				{
					_0023_003Dqlmii39LmpEKFiNuwVhWeIl1jUnHZZW5ZB8js1wwGKzw_003D(childNode4, out _0023_003DzBJFJHwk_003D2, out _0023_003Dz40R7bAU_003D2, out _0023_003DzId5C3LA_003D2);
				}
				else if (childNode4.Name == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657279))
				{
					_0023_003Dqlmii39LmpEKFiNuwVhWeIl1jUnHZZW5ZB8js1wwGKzw_003D(childNode4, out _0023_003DzBJFJHwk_003D3, out _0023_003Dz40R7bAU_003D3, out _0023_003DzId5C3LA_003D3);
				}
			}
			Plane = new Plane(new Point3D(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, _0023_003DzId5C3LA_003D), new Vector3D(_0023_003DzBJFJHwk_003D2, _0023_003Dz40R7bAU_003D2, _0023_003DzId5C3LA_003D2), new Vector3D(_0023_003DzBJFJHwk_003D3, _0023_003Dz40R7bAU_003D3, _0023_003DzId5C3LA_003D3));
		}
	}

	public void _0023_003DzmSyvi00_003D(SketchItem _0023_003DzjswBDdk_003D)
	{
		if (_0023_003DzjswBDdk_003D._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D() != this)
		{
			return;
		}
		if (_0023_003DzjswBDdk_003D is Constraint)
		{
			Constraint constraint = _0023_003DzjswBDdk_003D as Constraint;
			if (constraints.Remove(constraint._0023_003DzDQs07gDx7oDr()))
			{
				constraint.Destroy();
			}
		}
		if (_0023_003DzjswBDdk_003D is SketchCurve)
		{
			SketchCurve sketchCurve = _0023_003DzjswBDdk_003D as SketchCurve;
			if (entities.Remove(sketchCurve._0023_003DzDQs07gDx7oDr()))
			{
				sketchCurve.Destroy();
			}
		}
	}

	public void _0023_003DztXK6GnE_003D()
	{
		while (entities.Count > 0)
		{
			entities.First().Value.Destroy();
		}
		while (constraints.Count > 0)
		{
			constraints.First().Value.Destroy();
		}
	}

	public override void GetObjectData(SerializationInfo _0023_003Dz9lrNnXY_003D, StreamingContext _0023_003DzB8iS0QA_003D)
	{
		base.GetObjectData(_0023_003Dz9lrNnXY_003D, _0023_003DzB8iS0QA_003D);
		_0023_003Dz9lrNnXY_003D.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657108), idMapping);
		_0023_003Dz9lrNnXY_003D.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657120), entities);
		_0023_003Dz9lrNnXY_003D.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656698), constraints);
		_0023_003Dz9lrNnXY_003D.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657101), idGenerator._0023_003Dzuxxvjv8_003D);
		_0023_003Dz9lrNnXY_003D.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974845), Plane);
	}

	[OnDeserialized]
	public void _0023_003DzrixpoRQ_003D(StreamingContext _0023_003DzB8iS0QA_003D)
	{
		entities.OnDeserialization(this);
		constraints.OnDeserialization(this);
	}

	internal static Param _0023_003DzqZwFarHnpOoH(Param _0023_003Dzji2VyXMG5RrL)
	{
		if (!_0023_003Dz6JPAgTOPk4UIx7cxa37pQdEOfWO7[Thread.CurrentThread.ManagedThreadId].TryGetValue(_0023_003Dzji2VyXMG5RrL, out var value))
		{
			value = new Param(_0023_003Dzji2VyXMG5RrL);
			_0023_003Dz6JPAgTOPk4UIx7cxa37pQdEOfWO7[Thread.CurrentThread.ManagedThreadId].Add(_0023_003Dzji2VyXMG5RrL, value);
		}
		return value;
	}

	public override object Clone()
	{
		_0023_003Dz6JPAgTOPk4UIx7cxa37pQdEOfWO7[Thread.CurrentThread.ManagedThreadId] = new Dictionary<Param, Param>();
		SketchInternal result = new SketchInternal(this);
		_0023_003Dz6JPAgTOPk4UIx7cxa37pQdEOfWO7[Thread.CurrentThread.ManagedThreadId].Clear();
		return result;
	}

	internal static void _0023_003Dqlmii39LmpEKFiNuwVhWeIl1jUnHZZW5ZB8js1wwGKzw_003D(XmlNode _0023_003Dz_4dSctI_003D, out double _0023_003DzBJFJHwk_003D, out double _0023_003Dz40R7bAU_003D, out double _0023_003DzId5C3LA_003D)
	{
		_0023_003DzBJFJHwk_003D = double.Parse(_0023_003Dz_4dSctI_003D.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302935446)].Value);
		_0023_003Dz40R7bAU_003D = double.Parse(_0023_003Dz_4dSctI_003D.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655754)].Value);
		_0023_003DzId5C3LA_003D = double.Parse(_0023_003Dz_4dSctI_003D.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655986)].Value);
	}
}
