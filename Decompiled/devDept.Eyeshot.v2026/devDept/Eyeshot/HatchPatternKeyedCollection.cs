using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot;

public class HatchPatternKeyedCollection : EyeshotKeyedCollection<HatchPattern>
{
	public enum measurementType
	{
		Imperial,
		Metric
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private measurementType _0023_003DzugLlnMtHTDHcFvMvsA_003D_003D = ((!Utility.IsImperial(Block.DefaultUnits)) ? measurementType.Metric : measurementType.Imperial);

	public measurementType Measurement
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzugLlnMtHTDHcFvMvsA_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzugLlnMtHTDHcFvMvsA_003D_003D = value;
		}
	}

	public HatchPatternKeyedCollection()
		: base((IEqualityComparer<string>)StringComparer.OrdinalIgnoreCase)
	{
	}

	public HatchPatternKeyedCollection(IEnumerable<HatchPattern> collection)
		: base(collection, (IEqualityComparer<string>)StringComparer.OrdinalIgnoreCase)
	{
	}

	protected override string GetKeyForItem(HatchPattern item)
	{
		return item.Name;
	}

	public new virtual void Clear()
	{
		using (IEnumerator<HatchPattern> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				HatchPattern current = enumerator.Current;
				ItemCanBeRemoved(current);
			}
		}
		base.Clear();
		if (base.Document is DrawingDocument)
		{
			AddDefaultPattern();
		}
	}

	protected override void RemoveItem(int index)
	{
		if (ItemCanBeRemoved(this[index]))
		{
			base.RemoveItem(index);
		}
	}

	protected override bool AreEntitiesWith(HashSet<string> names, IList<Entity> entities)
	{
		foreach (Entity entity in entities)
		{
			foreach (string name in names)
			{
				if (entity is Hatch hatch && EyeshotKeyedCollection<HatchPattern>.AreEqualStrings(hatch.PatternName, name))
				{
					return true;
				}
			}
		}
		return false;
	}

	internal override void _0023_003DzTwVWSL0_003D(HatchPattern _0023_003DzUBZd570_003D, string _0023_003Dzf92bGaE_003D)
	{
		string name = _0023_003DzUBZd570_003D.Name;
		base._0023_003DzTwVWSL0_003D(_0023_003DzUBZd570_003D, _0023_003Dzf92bGaE_003D);
		if (base.Document == null)
		{
			return;
		}
		foreach (Block block in base.Document.Blocks)
		{
			_0023_003DzT_0024d12kaoxyMq(block.Entities, _0023_003Dzf92bGaE_003D, name);
		}
	}

	protected internal override bool ChangeEntitiesRegenMode(IEnumerable<Entity> entities, string patternName)
	{
		if (entities == null)
		{
			return false;
		}
		bool result = false;
		foreach (Entity entity in entities)
		{
			if (entity is Hatch hatch && EyeshotKeyedCollection<HatchPattern>.AreEqualStrings(hatch.PatternName, patternName))
			{
				if (hatch.RegenMode != regenType.RegenAndCompile)
				{
					hatch.RegenMode = regenType.RegenAndCompile;
				}
				result = true;
			}
		}
		return result;
	}

	private static void _0023_003DzT_0024d12kaoxyMq(IEnumerable<Entity> _0023_003Dzv7xH9gk_003D, string _0023_003Dzf92bGaE_003D, string _0023_003DzyriMxps_003D)
	{
		if (_0023_003Dzv7xH9gk_003D == null)
		{
			return;
		}
		foreach (Entity item in _0023_003Dzv7xH9gk_003D)
		{
			if (item is Hatch hatch && EyeshotKeyedCollection<HatchPattern>.AreEqualStrings(hatch.PatternName, _0023_003DzyriMxps_003D))
			{
				hatch.PatternName = _0023_003Dzf92bGaE_003D;
			}
		}
	}

	public string AddDefaultPattern()
	{
		string text = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985923);
		if (!Contains(text))
		{
			HatchPatternLine hatchPatternLine = new HatchPatternLine(Math.PI / 4.0, Point2D.Origin, 0.0, 0.125, new float[0]);
			Add(new HatchPattern(text, new HatchPatternLine[1] { hatchPatternLine }));
		}
		return text;
	}
}
