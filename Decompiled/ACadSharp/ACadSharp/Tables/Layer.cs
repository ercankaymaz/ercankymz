using System;
using ACadSharp.Attributes;
using ACadSharp.Objects;

namespace ACadSharp.Tables;

[DxfName("LAYER")]
[DxfSubClass("AcDbLayerTableRecord")]
public class Layer : TableEntry
{
	public const string DefaultName = "0";

	public const string DefpointsName = "defpoints";

	private Color _color = new Color(7);

	private LineType _lineType = LineType.Continuous;

	private bool _plotFlag = true;

	public static Layer Default => new Layer("0");

	public static Layer Defpoints => new Layer("defpoints")
	{
		PlotFlag = false
	};

	[DxfCodeValue(new int[] { 62, 420, 430 })]
	public Color Color
	{
		get
		{
			return _color;
		}
		set
		{
			if (value.IsByLayer || value.IsByBlock)
			{
				throw new ArgumentException("The layer color cannot be ByLayer or ByBlock", "value");
			}
			_color = value;
		}
	}

	public new LayerFlags Flags
	{
		get
		{
			return (LayerFlags)base.Flags;
		}
		set
		{
			base.Flags = (StandardFlags)value;
		}
	}

	public bool IsOn { get; set; } = true;

	[DxfCodeValue(DxfReferenceType.Name, new int[] { 6 })]
	public LineType LineType
	{
		get
		{
			return _lineType;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (base.Document != null)
			{
				_lineType = CadObject.updateCollection(value, base.Document.LineTypes);
			}
			else
			{
				_lineType = value;
			}
		}
	}

	[DxfCodeValue(new int[] { 370 })]
	public LineWeightType LineWeight { get; set; } = LineWeightType.Default;

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 347 })]
	public Material Material { get; set; }

	public override string ObjectName => "LAYER";

	public override ObjectType ObjectType => ObjectType.LAYER;

	[DxfCodeValue(new int[] { 290 })]
	public bool PlotFlag
	{
		get
		{
			if (name.Equals("defpoints", StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}
			return _plotFlag;
		}
		set
		{
			_plotFlag = value;
		}
	}

	[DxfCodeValue(DxfReferenceType.Unprocess, new int[] { 390 })]
	public ulong PlotStyleName { get; internal set; }

	public override string SubclassMarker => "AcDbLayerTableRecord";

	public Layer(string name)
		: base(name)
	{
	}

	internal Layer()
	{
	}

	public override CadObject Clone()
	{
		Layer obj = (Layer)base.Clone();
		obj.LineType = (LineType)LineType.Clone();
		obj.Material = (Material)(Material?.Clone());
		return obj;
	}

	internal override void AssignDocument(CadDocument doc)
	{
		base.AssignDocument(doc);
		_lineType = CadObject.updateCollection(LineType, doc.LineTypes);
		doc.LineTypes.OnRemove += tableOnRemove;
	}

	internal override void UnassignDocument()
	{
		base.Document.LineTypes.OnRemove -= tableOnRemove;
		base.UnassignDocument();
		LineType = (LineType)LineType.Clone();
	}

	protected virtual void tableOnRemove(object sender, CollectionChangedEventArgs e)
	{
		if (e.Item.Equals(LineType))
		{
			LineType = base.Document.LineTypes["Continuous"];
		}
	}
}
