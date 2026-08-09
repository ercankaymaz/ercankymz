using System;
using System.Collections.Generic;
using System.Linq;
using ACadSharp.Attributes;
using ACadSharp.Entities;
using ACadSharp.Tables;
using CSMath;

namespace ACadSharp.Objects;

[DxfName("LAYOUT")]
[DxfSubClass("AcDbLayout")]
public class Layout : PlotSettings
{
	public const string ModelLayoutName = "Model";

	public const string PaperLayoutName = "Layout1";

	private BlockRecord _blockRecord;

	private Viewport _lastViewport;

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 330 })]
	public BlockRecord AssociatedBlock
	{
		get
		{
			return _blockRecord;
		}
		internal set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			_blockRecord = value;
			_blockRecord.Layout = this;
		}
	}

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 346 })]
	public UCS BaseUCS { get; set; }

	[DxfCodeValue(new int[] { 146 })]
	public double Elevation { get; set; }

	[DxfCodeValue(new int[] { 12, 22, 32 })]
	public XYZ InsertionBasePoint { get; set; }

	public bool IsPaperSpace => !Name.Equals("Model", StringComparison.InvariantCultureIgnoreCase);

	[DxfCodeValue(new int[] { 70 })]
	public LayoutFlags LayoutFlags { get; set; }

	[DxfCodeValue(new int[] { 15, 25, 35 })]
	public XYZ MaxExtents { get; set; } = new XYZ(231.3, 175.5, 0.0);

	[DxfCodeValue(new int[] { 11, 21 })]
	public XY MaxLimits { get; set; } = new XY(277.0, 202.5);

	[DxfCodeValue(new int[] { 14, 24, 34 })]
	public XYZ MinExtents { get; set; } = new XYZ(25.7, 19.5, 0.0);

	[DxfCodeValue(new int[] { 10, 20 })]
	public XY MinLimits { get; set; } = new XY(-20.0, -7.5);

	[DxfCodeValue(new int[] { 1 })]
	public override string Name
	{
		get
		{
			return base.Name;
		}
		set
		{
			base.Name = value;
		}
	}

	public override string ObjectName => "LAYOUT";

	public override ObjectType ObjectType => ObjectType.LAYOUT;

	[DxfCodeValue(new int[] { 13, 23, 33 })]
	public XYZ Origin { get; set; } = XYZ.Zero;

	public override string SubclassMarker => "AcDbLayout";

	[DxfCodeValue(new int[] { 71 })]
	public int TabOrder { get; set; }

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 345 })]
	public UCS UCS { get; set; }

	[DxfCodeValue(new int[] { 76 })]
	public OrthographicType UcsOrthographicType { get; set; }

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 331 })]
	public Viewport Viewport
	{
		get
		{
			if (_lastViewport == null)
			{
				return Viewports?.FirstOrDefault();
			}
			return _lastViewport;
		}
		internal set
		{
			_lastViewport = value;
		}
	}

	public IEnumerable<Viewport> Viewports => AssociatedBlock?.Viewports;

	[DxfCodeValue(new int[] { 16, 26, 36 })]
	public XYZ XAxis { get; set; } = XYZ.AxisX;

	[DxfCodeValue(new int[] { 17, 27, 37 })]
	public XYZ YAxis { get; set; } = XYZ.AxisY;

	public Layout(string name)
		: this(name, name)
	{
	}

	public Layout(string name, string blockName)
	{
		Name = name;
		_blockRecord = new BlockRecord(blockName);
	}

	internal Layout()
	{
	}

	public override CadObject Clone()
	{
		Layout obj = (Layout)base.Clone();
		obj._blockRecord = (BlockRecord)(_blockRecord?.Clone());
		return obj;
	}

	public override string ToString()
	{
		return ObjectName + ":" + Name;
	}

	internal override void AssignDocument(CadDocument doc)
	{
		base.AssignDocument(doc);
		if (AssociatedBlock != null)
		{
			doc.BlockRecords.Add(AssociatedBlock);
			doc.BlockRecords.OnRemove += onRemoveBlockRecord;
		}
	}

	internal override void UnassignDocument()
	{
		base.Document.BlockRecords.OnRemove -= onRemoveBlockRecord;
		if (AssociatedBlock != null)
		{
			AssociatedBlock.Layout = null;
			base.Document.BlockRecords.OnRemove -= onRemoveBlockRecord;
			_blockRecord = (BlockRecord)(_blockRecord?.Clone());
		}
		base.UnassignDocument();
	}

	private void onRemoveBlockRecord(object sender, CollectionChangedEventArgs e)
	{
		if (AssociatedBlock.Equals(e.Item))
		{
			base.Document.Layouts.Remove(Name);
		}
	}
}
