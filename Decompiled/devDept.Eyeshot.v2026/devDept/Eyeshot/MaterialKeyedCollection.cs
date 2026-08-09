using System;
using System.Collections.Generic;
using System.Drawing;
using devDept.Eyeshot.Entities;
using devDept.Graphics;

namespace devDept.Eyeshot;

[Serializable]
public class MaterialKeyedCollection : EyeshotDisposableKeyedCollection<Material>
{
	public MaterialKeyedCollection()
		: base((IEqualityComparer<string>)StringComparer.OrdinalIgnoreCase)
	{
	}

	public MaterialKeyedCollection(IEnumerable<Material> collection)
		: base(collection, (IEqualityComparer<string>)StringComparer.OrdinalIgnoreCase)
	{
	}

	internal RenderContextBase _0023_003DzS1c2DBtqRnrg96IXUROj_00249c_003D()
	{
		return _0023_003Dzo60vEkkaRGxX()?.RenderContext;
	}

	protected override string GetKeyForItem(Material item)
	{
		return item.Name;
	}

	[Obsolete("Use the method that accepts the material only instead.")]
	public void Add(string name, Material material)
	{
		material.Name = name;
		Add(material);
	}

	public void Add(string name, byte[] texture)
	{
		Material item = new Material(name, texture);
		Add(item);
	}

	public void Add(string name, Color ambient, Color diffuse, Color specular, float shininess)
	{
		Add(new Material(name, ambient, diffuse, specular, shininess));
	}

	public void Add(string name, Color ambient, Color specular, float shininess, byte[] texture = null)
	{
		Add(new Material(name, ambient, specular, shininess, texture));
	}

	public void Add(string name, Color diffuse, double young, double poisson, double yield, double density, double coeffOfThermalExp)
	{
		Add(new Material(name, diffuse, young, poisson, yield, density, coeffOfThermalExp));
	}

	public override bool ReplaceItem(Material newMaterial)
	{
		bool flag = _0023_003Dzo60vEkkaRGxX() != null && _0023_003Dzo60vEkkaRGxX().IsRenderingContextValid(_0023_003DzS1c2DBtqRnrg96IXUROj_00249c_003D());
		if (flag)
		{
			_0023_003DzS1c2DBtqRnrg96IXUROj_00249c_003D().MakeCurrent();
			newMaterial.LoadTexture(_0023_003DzS1c2DBtqRnrg96IXUROj_00249c_003D());
		}
		bool result = base.ReplaceItem(newMaterial);
		if (flag)
		{
			_0023_003DzXFE1V5dt6zic();
		}
		return result;
	}

	protected override void InsertItem(int index, Material item)
	{
		int num;
		if (_0023_003Dzo60vEkkaRGxX() != null)
		{
			num = (_0023_003Dzo60vEkkaRGxX().IsRenderingContextValid(_0023_003DzS1c2DBtqRnrg96IXUROj_00249c_003D()) ? 1 : 0);
			if (num != 0)
			{
				_0023_003DzS1c2DBtqRnrg96IXUROj_00249c_003D().MakeCurrent();
				item.LoadTexture(_0023_003DzS1c2DBtqRnrg96IXUROj_00249c_003D());
			}
		}
		else
		{
			num = 0;
		}
		base.InsertItem(index, item);
		if (num != 0)
		{
			_0023_003DzXFE1V5dt6zic();
		}
	}

	private void _0023_003DzXFE1V5dt6zic()
	{
		if (!_0023_003DzS1c2DBtqRnrg96IXUROj_00249c_003D().CheckOutOfMemory())
		{
			return;
		}
		using IEnumerator<Material> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.FreeResources();
		}
	}

	protected override void RemoveItem(int index)
	{
		if (ItemCanBeRemoved(this[index]))
		{
			base.RemoveItem(index);
		}
	}

	public new virtual void Clear()
	{
		using (IEnumerator<Material> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Material current = enumerator.Current;
				ItemCanBeRemoved(current);
			}
		}
		base.Clear();
	}

	internal override void _0023_003DzOcZnt98_003D(Document _0023_003DzoPlwCJA_003D)
	{
		if (_0023_003DzoPlwCJA_003D == null)
		{
			_0023_003DzhM3qURBkRYYd();
		}
		base._0023_003DzOcZnt98_003D(_0023_003DzoPlwCJA_003D);
	}

	internal void InitializeGraphicsResources()
	{
		if (_0023_003Dzo60vEkkaRGxX() == null || !_0023_003Dzo60vEkkaRGxX().IsRenderingContextValid())
		{
			return;
		}
		using (IEnumerator<Material> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current.LoadTexture(_0023_003DzS1c2DBtqRnrg96IXUROj_00249c_003D());
			}
		}
		_0023_003DzXFE1V5dt6zic();
	}

	protected override bool AreEntitiesWith(HashSet<string> names, IList<Entity> entities)
	{
		foreach (Entity entity in entities)
		{
			foreach (string name in names)
			{
				if (EyeshotKeyedCollection<Material>.AreEqualStrings(entity.MaterialName, name))
				{
					return true;
				}
			}
		}
		return false;
	}

	internal override void _0023_003DzTwVWSL0_003D(Material _0023_003DzUBZd570_003D, string _0023_003Dzf92bGaE_003D)
	{
		string name = _0023_003DzUBZd570_003D.Name;
		base._0023_003DzTwVWSL0_003D(_0023_003DzUBZd570_003D, _0023_003Dzf92bGaE_003D);
		if (base.Document == null)
		{
			return;
		}
		foreach (Block block in base.Document.Blocks)
		{
			_0023_003Dzgk_0024_XePE4TPVD7DKwSUvk30_003D(block.Entities, _0023_003Dzf92bGaE_003D, name);
		}
		foreach (Layer layer in base.Document.Layers)
		{
			if (!string.IsNullOrEmpty(layer.MaterialName) && EyeshotKeyedCollection<Material>.AreEqualStrings(layer.MaterialName, name))
			{
				layer.MaterialName = _0023_003Dzf92bGaE_003D;
			}
		}
	}

	private static void _0023_003Dzgk_0024_XePE4TPVD7DKwSUvk30_003D(IEnumerable<Entity> _0023_003Dzv7xH9gk_003D, string _0023_003Dzf92bGaE_003D, string _0023_003DzyriMxps_003D)
	{
		if (_0023_003Dzv7xH9gk_003D == null)
		{
			return;
		}
		foreach (Entity item in _0023_003Dzv7xH9gk_003D)
		{
			if (!(item is ICurve) && !(item is Text) && !string.IsNullOrEmpty(item.MaterialName) && item.MaterialName.Equals(_0023_003DzyriMxps_003D))
			{
				item.MaterialName = _0023_003Dzf92bGaE_003D;
			}
		}
	}
}
