using System;
using ACadSharp.Attributes;

namespace ACadSharp.Objects;

[DxfSubClass("AcDbAnnotScaleObjectContextData")]
public abstract class AnnotScaleObjectContextData : ObjectContextData
{
	private Scale _scale = Scale.Default;

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 340 })]
	public Scale Scale
	{
		get
		{
			return _scale;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (base.Document != null)
			{
				_scale = CadObject.updateCollection(value, base.Document.Scales);
			}
			else
			{
				_scale = value;
			}
		}
	}

	public override string SubclassMarker => "AcDbAnnotScaleObjectContextData";

	public override CadObject Clone()
	{
		AnnotScaleObjectContextData obj = (AnnotScaleObjectContextData)base.Clone();
		obj._scale = (Scale)(_scale?.Clone());
		return obj;
	}

	internal override void AssignDocument(CadDocument doc)
	{
		base.AssignDocument(doc);
		_scale = CadObject.updateCollection(_scale, base.Document?.Scales);
		base.Document.Scales.OnRemove += tableOnRemove;
	}

	internal override void UnassignDocument()
	{
		base.Document.Scales.OnRemove -= tableOnRemove;
		base.UnassignDocument();
		_scale = (Scale)_scale.Clone();
	}

	private void tableOnRemove(object sender, CollectionChangedEventArgs e)
	{
		if (e.Item.Equals(_scale))
		{
			_scale = base.Document.Scales[Scale.Default.Name];
		}
	}
}
