using System;
using System.Collections.Generic;
using System.Drawing;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

[Serializable]
public class LayerKeyedCollection : EyeshotDisposableKeyedCollection<Layer>
{
	public LayerKeyedCollection()
		: this(null, _0023_003DzX3fuM46FZoD8: false)
	{
	}

	public LayerKeyedCollection(Layer defaultLayer)
		: this(defaultLayer, _0023_003DzX3fuM46FZoD8: true)
	{
	}

	private LayerKeyedCollection(Layer _0023_003DzDENCECqOXtNX, bool _0023_003DzX3fuM46FZoD8)
		: base((IEqualityComparer<string>)StringComparer.OrdinalIgnoreCase)
	{
		ClearInternal(_0023_003DzDENCECqOXtNX, _0023_003DzX3fuM46FZoD8);
	}

	public LayerKeyedCollection(LayerKeyedCollection collection)
		: base((IEnumerable<Layer>)collection, (IEqualityComparer<string>)StringComparer.OrdinalIgnoreCase)
	{
	}

	protected override string GetKeyForItem(Layer item)
	{
		return item.Name;
	}

	public void TurnOn(string layerName)
	{
		CheckItemKey(layerName, throwEx: true);
		this[layerName].Visible = true;
	}

	public void TurnOn(int layerIndex)
	{
		CheckItemIndex(layerIndex, throwEx: true);
		TurnOn(this[layerIndex].Name);
	}

	public void TurnAllOn()
	{
		using IEnumerator<Layer> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.Visible = true;
		}
	}

	public void TurnOff(string layerName)
	{
		CheckItemKey(layerName, throwEx: true);
		this[layerName].Visible = false;
	}

	public void TurnOff(int layerIndex)
	{
		CheckItemIndex(layerIndex, throwEx: true);
		TurnOff(this[layerIndex].Name);
	}

	public void TurnAllOff()
	{
		using IEnumerator<Layer> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.Visible = false;
		}
	}

	public new void Remove(string layerName)
	{
		CheckItemKey(layerName, throwEx: true);
		if (base.Count == 1)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988201));
		}
		_0023_003Dzy_U_9AErvRNX(layerName);
		RemoveItem(IndexOf(this[layerName]));
		if (base.Document?.internalElementsLayerName == layerName)
		{
			_0023_003Dzo60vEkkaRGxX()?.UpdateLayerNameForInternalElements(this[0].Name);
		}
	}

	public new void Remove(Layer layer)
	{
		Remove(layer.Name);
	}

	public new void RemoveAt(int layerIndex)
	{
		CheckItemIndex(layerIndex, throwEx: true);
		Remove(this[layerIndex].Name);
	}

	private void _0023_003Dzy_U_9AErvRNX(string _0023_003DzaROjBYA_003D)
	{
		if (base.Document == null)
		{
			return;
		}
		if (base.Document.OpenBlock.Name != base.Document.Blocks.RootBlockName || _0023_003Dzo60vEkkaRGxX()?.CurrentBlockReference != null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988175));
		}
		Dictionary<string, Block> dictionary = base.Document.Blocks._0023_003DzJW4Y0uY_003D(_0023_003DzaROjBYA_003D);
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, Block> item in dictionary)
		{
			if (item.Value.Name != base.Document.Blocks.RootBlockName && item.Value.Entities.Count == 0)
			{
				list.Add(item.Key);
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			base.Document.Blocks.Remove(list[i]);
		}
		base.Document.Entities._0023_003DzJW4Y0uY_003D(_0023_003DzaROjBYA_003D);
	}

	public void Empty(string layerName)
	{
		CheckItemKey(layerName, throwEx: true);
		_0023_003Dzy_U_9AErvRNX(layerName);
	}

	public void Empty(int layerIndex)
	{
		CheckItemIndex(layerIndex, throwEx: true);
		Empty(this[layerIndex].Name);
	}

	public new void Clear()
	{
		ClearInternal();
	}

	public void Clear(bool addDefaultLayer)
	{
		ClearInternal(null, base.Document != null || addDefaultLayer);
	}

	public void Clear(Layer defaultLayer)
	{
		ClearInternal(defaultLayer);
	}

	internal void ClearInternal(Layer _0023_003DzDENCECqOXtNX = null, bool _0023_003DzX3fuM46FZoD8 = true)
	{
		if (base.Document != null)
		{
			IWorkspaceInternal workspaceInternal = _0023_003Dzo60vEkkaRGxX();
			if (workspaceInternal != null && workspaceInternal.OpenBlocksDataCount > 0)
			{
				base.Document.Entities.Clear();
			}
		}
		base.Clear();
		if (_0023_003DzX3fuM46FZoD8)
		{
			_0023_003DzPGvXmLk_003D(_0023_003DzDENCECqOXtNX);
		}
	}

	internal override void _0023_003DzOcZnt98_003D(Document _0023_003DzoPlwCJA_003D)
	{
		if (_0023_003DzoPlwCJA_003D == null)
		{
			_0023_003DzhM3qURBkRYYd();
		}
		if (_0023_003DzoPlwCJA_003D != null && base.Count == 0)
		{
			_0023_003DzPGvXmLk_003D(null);
		}
		base._0023_003DzOcZnt98_003D(_0023_003DzoPlwCJA_003D);
	}

	internal void _0023_003DzPGvXmLk_003D(Layer _0023_003DzDENCECqOXtNX)
	{
		string text = ((_0023_003DzDENCECqOXtNX == null) ? Layer.DefaultLayerName : _0023_003DzDENCECqOXtNX.Name);
		if (base.Dictionary != null && base.Dictionary.ContainsKey(Layer.DefaultLayerName))
		{
			return;
		}
		if (_0023_003DzDENCECqOXtNX != null)
		{
			Add(_0023_003DzDENCECqOXtNX);
			text = _0023_003DzDENCECqOXtNX.Name;
		}
		else
		{
			Add(text, Color.Black);
		}
		if (base.Document != null)
		{
			if (base.Document is DrawingDocument drawingDocument)
			{
				drawingDocument.AddDefaultLayersAndLineTypes();
			}
			_0023_003Dzo60vEkkaRGxX()?.UpdateLayerNameForInternalElements(text);
		}
	}

	internal string GetDefaultLayerName()
	{
		if (base.Count <= 0)
		{
			return Layer.DefaultLayerName;
		}
		return this[0].Name;
	}

	public virtual void AddRange(IList<Layer> layerList)
	{
		foreach (Layer layer in layerList)
		{
			Add(layer);
		}
	}

	private void _0023_003DzSTF_0024BjQOhtuV(Layer _0023_003DztIaJjPw_003D)
	{
		if (base.Document != null)
		{
			string lineTypeName = _0023_003DztIaJjPw_003D.LineTypeName;
			if (!string.IsNullOrEmpty(lineTypeName) && !base.Document.LineTypes.CheckItemKey(lineTypeName))
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983574) + lineTypeName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302987831) + _0023_003DztIaJjPw_003D.Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302987820));
			}
			string materialName = _0023_003DztIaJjPw_003D.MaterialName;
			if (!string.IsNullOrEmpty(materialName) && !base.Document.Materials.CheckItemKey(materialName))
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983193) + materialName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302987831) + _0023_003DztIaJjPw_003D.Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302987820));
			}
		}
	}

	private protected override void _0023_003DzXV3ITe3Ls_W9(Layer _0023_003DzUBZd570_003D)
	{
		((INotifyVisibleChanged)_0023_003DzUBZd570_003D).VisibleChanged += _0023_003DzdAVlEJKfQ0Ln;
		base._0023_003DzXV3ITe3Ls_W9(_0023_003DzUBZd570_003D);
	}

	private protected override void _0023_003Dzbvv_0024NENySF38(Layer _0023_003DzUBZd570_003D)
	{
		((INotifyVisibleChanged)_0023_003DzUBZd570_003D).VisibleChanged -= _0023_003DzdAVlEJKfQ0Ln;
		base._0023_003Dzbvv_0024NENySF38(_0023_003DzUBZd570_003D);
	}

	internal void _0023_003DzdAVlEJKfQ0Ln(object _0023_003Dz9VjL5i0_003D, VisibleChangedEventArgs _0023_003DzbfrNXYE_003D)
	{
		if (base.Document == null)
		{
			return;
		}
		ParallelConveHull.Instance.Stop();
		_0023_003Dzo60vEkkaRGxX()?.UpdateVisibleSelection();
		foreach (Block block in base.Document.Blocks)
		{
			bool flag = false;
			foreach (Entity entity in block.Entities)
			{
				if (entity.LayerName.Equals(((Layer)_0023_003Dz9VjL5i0_003D).Name))
				{
					block.zoomFitConvexHull = null;
					flag = true;
					break;
				}
			}
			if (!flag || block.referencesToMe.Count <= 0)
			{
				continue;
			}
			foreach (BlockReference item in block.referencesToMe)
			{
				item._0023_003DzoC5Ax2mpp_0024GS();
			}
		}
		_0023_003Dzo60vEkkaRGxX()?.DestroyFlattenedTree(clearFlattenRepresentation: true);
	}

	public virtual int Add(string layerName, Color color)
	{
		return Add(new Layer(layerName, color));
	}

	public virtual int Add(string layerName, Color color, string lineTypeName)
	{
		return Add(new Layer(layerName, color, lineTypeName));
	}

	public virtual int Add(string layerName, Color color, bool visible)
	{
		return Add(new Layer(layerName, color, visible));
	}

	public virtual int Add(string layerName, Color color, string materialName, string lineTypeName)
	{
		return Add(new Layer(layerName, color, lineTypeName, 0.5f, visible: true));
	}

	public virtual int Add(string layerName)
	{
		return Add(new Layer(layerName, Color.Black, visible: true));
	}

	protected override bool AreEntitiesWith(HashSet<string> names, IList<Entity> entities)
	{
		foreach (Entity entity in entities)
		{
			foreach (string name in names)
			{
				if (EyeshotKeyedCollection<Layer>.AreEqualStrings(entity.LayerName, name))
				{
					return true;
				}
			}
		}
		return false;
	}

	private void _0023_003DzcYu9xR5v26J8(string _0023_003DzyriMxps_003D, string _0023_003Dzf92bGaE_003D)
	{
		if (base.Document == null)
		{
			return;
		}
		foreach (Block block in base.Document.Blocks)
		{
			UpdateEntitiesLayerName(block.Entities, _0023_003Dzf92bGaE_003D, _0023_003DzyriMxps_003D);
		}
		_0023_003Dzo60vEkkaRGxX()?.UpdateLayerNameForInternalElements(_0023_003Dzf92bGaE_003D);
	}

	internal override void _0023_003DzTwVWSL0_003D(Layer _0023_003DzUBZd570_003D, string _0023_003Dzf92bGaE_003D)
	{
		string name = _0023_003DzUBZd570_003D.Name;
		base._0023_003DzTwVWSL0_003D(_0023_003DzUBZd570_003D, _0023_003Dzf92bGaE_003D);
		_0023_003DzcYu9xR5v26J8(name, _0023_003Dzf92bGaE_003D);
	}

	protected override void InsertItem(int index, Layer item)
	{
		_0023_003DzSTF_0024BjQOhtuV(item);
		base.InsertItem(index, item);
	}

	protected override void SetItem(int index, Layer item)
	{
		_0023_003DzSTF_0024BjQOhtuV(item);
		string name = this[index].Name;
		base.SetItem(index, item);
		_0023_003DzcYu9xR5v26J8(name, item.Name);
	}

	protected internal override bool ChangeEntitiesRegenMode(IEnumerable<Entity> entities, string layerName)
	{
		if (entities == null)
		{
			return false;
		}
		bool result = false;
		foreach (Entity entity in entities)
		{
			if (entity is ICurve && EyeshotKeyedCollection<Layer>.AreEqualStrings(entity.LayerName, layerName) && Entity._0023_003DznGg4zZpR1yr2ytDGOA_003D_003D(entity, colorMethodType.byLayer))
			{
				result = true;
			}
		}
		return result;
	}

	internal static void UpdateEntitiesLayerName(IEnumerable<Entity> _0023_003Dzv7xH9gk_003D, string _0023_003Dzf92bGaE_003D, string _0023_003DzyriMxps_003D = null)
	{
		if (_0023_003Dzv7xH9gk_003D == null)
		{
			return;
		}
		foreach (Entity item in _0023_003Dzv7xH9gk_003D)
		{
			UpdateEntitiesLayerName(item, _0023_003Dzf92bGaE_003D, _0023_003DzyriMxps_003D);
		}
	}

	internal static void UpdateEntitiesLayerName(Entity _0023_003Dz9j7EUB0_003D, string _0023_003Dzf92bGaE_003D, string _0023_003DzyriMxps_003D = null)
	{
		if (_0023_003Dz9j7EUB0_003D == null)
		{
			return;
		}
		if (_0023_003DzyriMxps_003D == null || EyeshotKeyedCollection<Layer>.AreEqualStrings(_0023_003Dz9j7EUB0_003D.LayerName, _0023_003DzyriMxps_003D))
		{
			_0023_003Dz9j7EUB0_003D.LayerName = _0023_003Dzf92bGaE_003D;
		}
		if (!(_0023_003Dz9j7EUB0_003D is BlockReference blockReference))
		{
			return;
		}
		foreach (KeyValuePair<string, AttributeReference> attribute in blockReference.Attributes)
		{
			if (_0023_003DzyriMxps_003D == null || EyeshotKeyedCollection<Layer>.AreEqualStrings(attribute.Value.LayerName, _0023_003DzyriMxps_003D))
			{
				attribute.Value.LayerName = _0023_003Dzf92bGaE_003D;
			}
		}
	}

	internal bool _0023_003DzswaTj8gEDyWc()
	{
		return Contains(Layer.DefaultLayerName);
	}

	internal void CheckAndFixDefaultLayerName(Entity _0023_003Dz9j7EUB0_003D, bool? _0023_003DzTVRdP4rYcKkk = null)
	{
		if (string.IsNullOrEmpty(_0023_003Dz9j7EUB0_003D.LayerName))
		{
			_0023_003Dz9j7EUB0_003D.LayerName = Layer.DefaultLayerName;
		}
		if ((_0023_003DzTVRdP4rYcKkk.HasValue && _0023_003DzTVRdP4rYcKkk.Value) || (!_0023_003DzTVRdP4rYcKkk.HasValue && _0023_003DzswaTj8gEDyWc()))
		{
			return;
		}
		if (_0023_003Dz9j7EUB0_003D.LayerName == Layer.DefaultLayerName)
		{
			_0023_003Dz9j7EUB0_003D.LayerName = GetDefaultLayerName();
		}
		if (!(_0023_003Dz9j7EUB0_003D is BlockReference blockReference))
		{
			return;
		}
		foreach (KeyValuePair<string, AttributeReference> attribute in blockReference.Attributes)
		{
			if (attribute.Value.LayerName == Layer.DefaultLayerName)
			{
				attribute.Value.LayerName = GetDefaultLayerName();
			}
		}
	}
}
