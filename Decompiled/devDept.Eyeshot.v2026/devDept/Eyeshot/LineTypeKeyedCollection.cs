using System;
using System.Collections.Generic;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

[Serializable]
public class LineTypeKeyedCollection : EyeshotKeyedCollection<LineType>
{
	public LineTypeKeyedCollection()
		: base((IEqualityComparer<string>)StringComparer.OrdinalIgnoreCase)
	{
	}

	public LineTypeKeyedCollection(IEnumerable<LineType> collection)
		: base(collection, (IEqualityComparer<string>)StringComparer.OrdinalIgnoreCase)
	{
	}

	protected override string GetKeyForItem(LineType item)
	{
		return item.Name;
	}

	public new virtual void Clear()
	{
		using (IEnumerator<LineType> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				LineType current = enumerator.Current;
				ItemCanBeRemoved(current);
			}
		}
		base.Clear();
		if (base.Document is DrawingDocument drawingDocument)
		{
			drawingDocument.AddDefaultLineTypes();
		}
	}

	public void Add(string name, float[] pattern)
	{
		Add(new LineType(name, pattern));
	}

	public static bool IsReservedName(string name)
	{
		if (!name.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988767), StringComparison.InvariantCultureIgnoreCase) && !name.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988749), StringComparison.InvariantCultureIgnoreCase))
		{
			return name.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988731), StringComparison.InvariantCultureIgnoreCase);
		}
		return true;
	}

	protected override void InsertItem(int index, LineType type)
	{
		if (IsReservedName(type.Name))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988718));
		}
		base.InsertItem(index, type);
	}

	[Obsolete("Use the method that accepts the type only instead.")]
	public void Add(string name, LineType type)
	{
		type.Name = name;
		Add(type);
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
				if (entity is ICurve && EyeshotKeyedCollection<LineType>.AreEqualStrings(entity.LineTypeName, name))
				{
					return true;
				}
			}
		}
		return false;
	}

	internal override void _0023_003DzTwVWSL0_003D(LineType _0023_003DzUBZd570_003D, string _0023_003Dzf92bGaE_003D)
	{
		string name = _0023_003DzUBZd570_003D.Name;
		base._0023_003DzTwVWSL0_003D(_0023_003DzUBZd570_003D, _0023_003Dzf92bGaE_003D);
		if (base.Document == null)
		{
			return;
		}
		foreach (Block block in base.Document.Blocks)
		{
			_0023_003DzOZ4tzTpeNGf9(block.Entities, _0023_003Dzf92bGaE_003D, name);
		}
		foreach (Layer layer in base.Document.Layers)
		{
			if (!string.IsNullOrEmpty(layer.LineTypeName) && EyeshotKeyedCollection<LineType>.AreEqualStrings(layer.LineTypeName, name))
			{
				layer.LineTypeName = _0023_003Dzf92bGaE_003D;
			}
		}
	}

	protected internal override bool ChangeEntitiesRegenMode(string lineTypeName)
	{
		bool result = base.ChangeEntitiesRegenMode(lineTypeName);
		if (base.Document != null)
		{
			foreach (Layer layer in base.Document.Layers)
			{
				if (!string.IsNullOrEmpty(layer.LineTypeName) && EyeshotKeyedCollection<LineType>.AreEqualStrings(layer.LineTypeName, lineTypeName))
				{
					layer.LineTypeName = lineTypeName;
					if (base.Document.Layers.ChangeEntitiesRegenMode(layer.Name))
					{
						result = true;
					}
				}
			}
		}
		return result;
	}

	protected internal override bool ChangeEntitiesRegenMode(IEnumerable<Entity> entities, string lineTypeName)
	{
		if (entities == null)
		{
			return false;
		}
		bool result = false;
		foreach (Entity entity in entities)
		{
			if (entity is ICurve && !string.IsNullOrEmpty(entity.LineTypeName) && EyeshotKeyedCollection<LineType>.AreEqualStrings(entity.LineTypeName, lineTypeName) && Entity._0023_003DznGg4zZpR1yr2ytDGOA_003D_003D(entity, colorMethodType.byEntity))
			{
				result = true;
			}
		}
		return result;
	}

	private static void _0023_003DzOZ4tzTpeNGf9(IEnumerable<Entity> _0023_003Dzv7xH9gk_003D, string _0023_003Dzf92bGaE_003D, string _0023_003DzyriMxps_003D)
	{
		if (_0023_003Dzv7xH9gk_003D == null)
		{
			return;
		}
		foreach (Entity item in _0023_003Dzv7xH9gk_003D)
		{
			if (item is ICurve && !string.IsNullOrEmpty(item.LineTypeName) && EyeshotKeyedCollection<LineType>.AreEqualStrings(item.LineTypeName, _0023_003DzyriMxps_003D))
			{
				item.LineTypeName = _0023_003Dzf92bGaE_003D;
			}
		}
	}

	public string AddDefaultLineType()
	{
		string text = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988376);
		if (!Contains(text))
		{
			Add(new LineType(text, new float[4] { 12f, -3f, 0f, -3f }));
		}
		return text;
	}
}
