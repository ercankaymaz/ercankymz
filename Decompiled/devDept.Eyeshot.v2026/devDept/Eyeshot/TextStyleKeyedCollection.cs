using System;
using System.Collections.Generic;
using System.IO;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

[Serializable]
public class TextStyleKeyedCollection : EyeshotKeyedCollection<TextStyle>, ICloneable
{
	public TextStyleKeyedCollection()
		: base((IEqualityComparer<string>)StringComparer.OrdinalIgnoreCase)
	{
	}

	public TextStyleKeyedCollection(TextStyle defaultTextStyle)
		: base((IEqualityComparer<string>)StringComparer.OrdinalIgnoreCase)
	{
		_0023_003DzPGvXmLk_003D(defaultTextStyle);
	}

	public TextStyleKeyedCollection(IEnumerable<TextStyle> collection)
		: base(collection, (IEqualityComparer<string>)StringComparer.OrdinalIgnoreCase)
	{
	}

	public TextStyleKeyedCollection(TextStyleKeyedCollection textStyles)
	{
		if (textStyles.Count > 0)
		{
			foreach (TextStyle textStyle in textStyles)
			{
				Add((TextStyle)textStyle.Clone());
			}
			return;
		}
		_0023_003DzPGvXmLk_003D(null);
	}

	internal TextStyleKeyedCollection(TextStyleKeyedCollection _0023_003Dzl_0024MIsC0_003D, Document _0023_003DzoPlwCJA_003D)
		: base((IEnumerable<TextStyle>)_0023_003Dzl_0024MIsC0_003D, (IEqualityComparer<string>)StringComparer.OrdinalIgnoreCase)
	{
		_0023_003DzOcZnt98_003D(_0023_003DzoPlwCJA_003D);
		_0023_003DzPGvXmLk_003D(null);
	}

	protected override string GetKeyForItem(TextStyle item)
	{
		return item.Name;
	}

	internal override void _0023_003DzOcZnt98_003D(Document _0023_003DzoPlwCJA_003D)
	{
		if (_0023_003DzoPlwCJA_003D != null)
		{
			_0023_003DzPGvXmLk_003D(null);
		}
		base._0023_003DzOcZnt98_003D(_0023_003DzoPlwCJA_003D);
	}

	internal string _0023_003Dz_I9l_0024rpzA7Cb()
	{
		if (base.Count <= 0)
		{
			return TextStyle._0023_003Dz4zXHKUEM3ZZu;
		}
		return this[0].Name;
	}

	internal void _0023_003DzPGvXmLk_003D(TextStyle _0023_003DzLFi3Jv1IMLTz)
	{
		if (base.Dictionary == null || !base.Dictionary.ContainsKey(TextStyle._0023_003Dz4zXHKUEM3ZZu))
		{
			TextStyle item = _0023_003DzLFi3Jv1IMLTz ?? new TextStyle(TextStyle._0023_003Dz4zXHKUEM3ZZu, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998133), fontStyle.Regular);
			Add(item);
		}
	}

	[Obsolete("Use the method that accepts the textStyle only instead.")]
	public void Add(string name, TextStyle textStyle)
	{
		textStyle.Name = name;
		Add(textStyle);
	}

	protected override void RemoveItem(int index)
	{
		if (base.Count == 1)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998116));
		}
		if (ItemCanBeRemoved(this[index]))
		{
			base.RemoveItem(index);
		}
	}

	public new void Clear()
	{
		ClearInternal();
	}

	public void Clear(bool addDefaultTextStyle)
	{
		ClearInternal(null, base.Document != null || addDefaultTextStyle);
	}

	public void Clear(TextStyle defaultTextStyle)
	{
		ClearInternal(defaultTextStyle);
	}

	internal void ClearInternal(TextStyle _0023_003DzLFi3Jv1IMLTz = null, bool _0023_003DzYFyd_0024fAZASKw = true)
	{
		using (IEnumerator<TextStyle> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				TextStyle current = enumerator.Current;
				ItemCanBeRemoved(current);
			}
		}
		base.Clear();
		if (_0023_003DzYFyd_0024fAZASKw)
		{
			_0023_003DzPGvXmLk_003D(_0023_003DzLFi3Jv1IMLTz);
		}
	}

	protected override bool AreEntitiesWith(HashSet<string> names, IList<Entity> entities)
	{
		foreach (Entity entity in entities)
		{
			if (entity is Text text)
			{
				foreach (string name in names)
				{
					if (EyeshotKeyedCollection<TextStyle>.AreEqualStrings(text.StyleName, name))
					{
						return true;
					}
				}
			}
			else
			{
				if (!(entity is Table table))
				{
					continue;
				}
				for (int i = 0; i < table.RowsNum; i++)
				{
					for (int j = 0; j < table.ColumnsNum; j++)
					{
						foreach (string name2 in names)
						{
							if (EyeshotKeyedCollection<TextStyle>.AreEqualStrings(table.GetStyleName(i, j), name2))
							{
								return true;
							}
						}
					}
				}
			}
		}
		return false;
	}

	internal override void _0023_003DzTwVWSL0_003D(TextStyle _0023_003DzUBZd570_003D, string _0023_003Dzf92bGaE_003D)
	{
		string name = _0023_003DzUBZd570_003D.Name;
		base._0023_003DzTwVWSL0_003D(_0023_003DzUBZd570_003D, _0023_003Dzf92bGaE_003D);
		if (base.Document == null)
		{
			return;
		}
		foreach (Block block in base.Document.Blocks)
		{
			_0023_003DzuHulo_0024fPObkV(block.Entities, _0023_003Dzf92bGaE_003D, name);
		}
	}

	protected internal override bool ChangeEntitiesRegenMode(IEnumerable<Entity> entities, string styleName)
	{
		if (entities == null)
		{
			return false;
		}
		bool result = false;
		foreach (Entity entity in entities)
		{
			if (entity is Text text)
			{
				if (EyeshotKeyedCollection<TextStyle>.AreEqualStrings(text.StyleName, styleName))
				{
					text.RegenMode = regenType.RegenAndCompile;
					result = true;
				}
			}
			else if (entity is Table table)
			{
				for (int i = 0; i < table.RowsNum; i++)
				{
					for (int j = 0; j < table.ColumnsNum; j++)
					{
						if (EyeshotKeyedCollection<TextStyle>.AreEqualStrings(table.GetStyleName(i, j), styleName))
						{
							table.cells[i, j].RegenMode = regenType.RegenAndCompile;
							if (table.RegenMode != regenType.RegenAndCompile)
							{
								table.RegenMode = regenType.RegenAndCompile;
							}
							result = true;
						}
					}
				}
			}
			else
			{
				if (!(entity is BlockReference blockReference))
				{
					continue;
				}
				foreach (KeyValuePair<string, AttributeReference> attribute in blockReference.Attributes)
				{
					AttributeReferenceData data = attribute.Value.Data;
					if (EyeshotKeyedCollection<TextStyle>.AreEqualStrings(data.StyleName, styleName))
					{
						data.RegenMode = regenType.RegenAndCompile;
						result = true;
					}
				}
			}
		}
		return result;
	}

	private static void _0023_003DzuHulo_0024fPObkV(IEnumerable<Entity> _0023_003Dzv7xH9gk_003D, string _0023_003Dzf92bGaE_003D, string _0023_003DzyriMxps_003D)
	{
		if (_0023_003Dzv7xH9gk_003D == null)
		{
			return;
		}
		foreach (Entity item in _0023_003Dzv7xH9gk_003D)
		{
			if (item is Text text)
			{
				if (!string.IsNullOrEmpty(text.StyleName) && EyeshotKeyedCollection<TextStyle>.AreEqualStrings(text.StyleName, _0023_003DzyriMxps_003D))
				{
					text.StyleName = _0023_003Dzf92bGaE_003D;
				}
			}
			else if (item is BlockReference blockReference)
			{
				foreach (KeyValuePair<string, AttributeReference> attribute in blockReference.Attributes)
				{
					string styleName = attribute.Value.StyleName;
					if (!string.IsNullOrEmpty(styleName) && EyeshotKeyedCollection<TextStyle>.AreEqualStrings(styleName, _0023_003DzyriMxps_003D))
					{
						attribute.Value.StyleName = _0023_003Dzf92bGaE_003D;
					}
				}
			}
			else
			{
				if (!(item is Table table))
				{
					continue;
				}
				double num = table.RowsNum;
				double num2 = table.ColumnsNum;
				for (int i = 0; (double)i < num; i++)
				{
					for (int j = 0; (double)j < num2; j++)
					{
						string styleName2 = table.GetStyleName(i, j);
						if (!string.IsNullOrEmpty(styleName2) && EyeshotKeyedCollection<TextStyle>.AreEqualStrings(styleName2, _0023_003DzyriMxps_003D))
						{
							table.SetStyleName(i, j, _0023_003Dzf92bGaE_003D);
						}
					}
				}
			}
		}
	}

	internal bool _0023_003DzOU5UUm8kRh6c()
	{
		return Contains(TextStyle._0023_003Dz4zXHKUEM3ZZu);
	}

	internal void _0023_003Dzzv3gdukD06Co7c8MLQ_003D_003D(Entity _0023_003Dz9j7EUB0_003D, bool? _0023_003DzTVRdP4rYcKkk)
	{
		Text text = _0023_003Dz9j7EUB0_003D as Text;
		if (text != null && string.IsNullOrEmpty(text.StyleName))
		{
			text.StyleName = TextStyle._0023_003Dz4zXHKUEM3ZZu;
		}
		if ((_0023_003DzTVRdP4rYcKkk.HasValue && _0023_003DzTVRdP4rYcKkk.Value) || (!_0023_003DzTVRdP4rYcKkk.HasValue && _0023_003DzOU5UUm8kRh6c()))
		{
			return;
		}
		if (text != null)
		{
			if (text.StyleName == TextStyle._0023_003Dz4zXHKUEM3ZZu)
			{
				text.StyleName = _0023_003Dz_I9l_0024rpzA7Cb();
			}
			return;
		}
		if (_0023_003Dz9j7EUB0_003D is BlockReference blockReference)
		{
			foreach (KeyValuePair<string, AttributeReference> attribute in blockReference.Attributes)
			{
				if (attribute.Value.StyleName == TextStyle._0023_003Dz4zXHKUEM3ZZu)
				{
					attribute.Value.StyleName = _0023_003Dz_I9l_0024rpzA7Cb();
				}
			}
		}
		if (!(_0023_003Dz9j7EUB0_003D is Table table))
		{
			return;
		}
		for (int i = 0; i < table.RowsNum; i++)
		{
			for (int j = 0; j < table.ColumnsNum; j++)
			{
				if (table.GetStyleName(i, j) == TextStyle._0023_003Dz4zXHKUEM3ZZu)
				{
					table.SetStyleName(i, j, _0023_003Dz_I9l_0024rpzA7Cb());
				}
			}
		}
	}

	public virtual object Clone()
	{
		return new TextStyleKeyedCollection(this);
	}

	public void LoadFont(string styleName, string filePath)
	{
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
		if (!Contains(styleName))
		{
			Add(new TextStyle(styleName));
		}
		TextStyle textStyle = this[styleName];
		textStyle.FontFamilyName = Path.GetFileNameWithoutExtension(filePath);
		textStyle._0023_003Dzl2Uiu_0024M_003D(filePath);
		base.Document.fontDefs.TryAdd(fileNameWithoutExtension, new FontData());
		ChangeEntitiesRegenMode(styleName);
	}
}
