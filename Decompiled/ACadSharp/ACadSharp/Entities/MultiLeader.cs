using System;
using System.Collections.Generic;
using ACadSharp.Attributes;
using ACadSharp.Objects;
using ACadSharp.Tables;
using CSMath;

namespace ACadSharp.Entities;

[DxfName("MULTILEADER")]
[DxfSubClass("AcDbMLeader")]
public class MultiLeader : Entity
{
	public class BlockAttribute : ICloneable
	{
		[DxfCodeValue(new int[] { 330 })]
		public AttributeDefinition AttributeDefinition { get; set; }

		[DxfCodeValue(new int[] { 177 })]
		public short Index { get; set; }

		[DxfCodeValue(new int[] { 44 })]
		public double Width { get; set; }

		[DxfCodeValue(new int[] { 302 })]
		public string Text { get; set; }

		public object Clone()
		{
			return MemberwiseClone();
		}
	}

	private BlockRecord _arrowhead;

	private BlockRecord _blockContent;

	private MultiLeaderObjectContextData _contextData = new MultiLeaderObjectContextData();

	private LineType _leaderLineType = LineType.ByLayer;

	private MultiLeaderStyle _style = MultiLeaderStyle.Default;

	private TextStyle _textStyle = TextStyle.Default;

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 342 })]
	public BlockRecord Arrowhead
	{
		get
		{
			return _arrowhead;
		}
		set
		{
			_arrowhead = CadObject.updateCollection(value, base.Document?.BlockRecords);
		}
	}

	[DxfCodeValue(new int[] { 42 })]
	public double ArrowheadSize { get; set; }

	public IList<BlockAttribute> BlockAttributes { get; private set; } = new List<BlockAttribute>();

	[DxfCodeValue(new int[] { 172 })]
	public LeaderContentType ContentType { get; set; }

	public MultiLeaderObjectContextData ContextData => _contextData;

	[DxfCodeValue(new int[] { 293 })]
	public bool EnableAnnotationScale { get; set; }

	[DxfCodeValue(new int[] { 291 })]
	public bool EnableDogleg { get; set; }

	[DxfCodeValue(new int[] { 290 })]
	public bool EnableLanding { get; set; }

	[DxfCodeValue(new int[] { 295 })]
	public bool ExtendedToText { get; set; }

	[DxfCodeValue(new int[] { 41 })]
	public double LandingDistance { get; set; }

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 341 })]
	public LineType LeaderLineType
	{
		get
		{
			return _leaderLineType;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (base.Document != null)
			{
				_leaderLineType = CadObject.updateCollection(value, base.Document.LineTypes);
			}
			else
			{
				_leaderLineType = value;
			}
		}
	}

	[DxfCodeValue(new int[] { 171 })]
	public LineWeightType LeaderLineWeight { get; set; }

	[DxfCodeValue(new int[] { 91 })]
	public Color LineColor { get; set; }

	public override string ObjectName => "MULTILEADER";

	public override ObjectType ObjectType => ObjectType.UNLISTED;

	[DxfCodeValue(new int[] { 170 })]
	public MultiLeaderPathType PathType { get; set; }

	[DxfCodeValue(new int[] { 90 })]
	public MultiLeaderPropertyOverrideFlags PropertyOverrideFlags { get; set; }

	[DxfCodeValue(new int[] { 45 })]
	public double ScaleFactor { get; set; }

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 340 })]
	public MultiLeaderStyle Style
	{
		get
		{
			return _style;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (base.Document != null)
			{
				_style = CadObject.updateCollection(value, base.Document.MLeaderStyles);
			}
			else
			{
				_style = value;
			}
		}
	}

	public override string SubclassMarker => "AcDbMLeader";

	[DxfCodeValue(new int[] { 178 })]
	public short TextAligninIPE { get; set; }

	[DxfCodeValue(new int[] { 271 })]
	public TextAttachmentDirectionType TextAttachmentDirection { get; set; }

	[DxfCodeValue(new int[] { 179 })]
	public TextAttachmentPointType TextAttachmentPoint { get; set; }

	[DxfCodeValue(new int[] { 272 })]
	public TextAttachmentType TextBottomAttachment { get; set; }

	[DxfCodeValue(new int[] { 294 })]
	public bool TextDirectionNegative { get; set; }

	[DxfCodeValue(new int[] { 273 })]
	public TextAttachmentType TextTopAttachment { get; set; }

	[DxfCodeValue(new int[] { 175 })]
	public TextAlignmentType TextAlignment { get; set; }

	[DxfCodeValue(new int[] { 174 })]
	public TextAngleType TextAngle { get; set; }

	[DxfCodeValue(new int[] { 92 })]
	public Color TextColor { get; set; }

	[DxfCodeValue(new int[] { 292 })]
	public bool TextFrame { get; set; }

	[DxfCodeValue(new int[] { 173 })]
	public TextAttachmentType TextLeftAttachment { get; set; }

	[DxfCodeValue(new int[] { 95 })]
	public TextAttachmentType TextRightAttachment { get; set; }

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 343 })]
	public TextStyle TextStyle
	{
		get
		{
			return _textStyle;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (base.Document != null)
			{
				_textStyle = CadObject.updateCollection(value, base.Document.TextStyles);
			}
			else
			{
				_textStyle = value;
			}
		}
	}

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 344 })]
	public BlockRecord BlockContent
	{
		get
		{
			return _blockContent;
		}
		set
		{
			_blockContent = CadObject.updateCollection(value, base.Document?.BlockRecords);
		}
	}

	[DxfCodeValue(new int[] { 93 })]
	public Color BlockContentColor { get; set; }

	[DxfCodeValue(new int[] { 176 })]
	public BlockContentConnectionType BlockContentConnection { get; set; }

	[DxfCodeValue(DxfReferenceType.IsAngle, new int[] { 43 })]
	public double BlockContentRotation { get; set; }

	[DxfCodeValue(new int[] { 10, 20, 30 })]
	public XYZ BlockContentScale { get; set; }

	public override void ApplyTransform(Transform transform)
	{
	}

	public override CadObject Clone()
	{
		MultiLeader multiLeader = (MultiLeader)base.Clone();
		multiLeader._contextData = (MultiLeaderObjectContextData)_contextData.Clone();
		multiLeader.BlockAttributes = new List<BlockAttribute>();
		foreach (BlockAttribute blockAttribute in BlockAttributes)
		{
			multiLeader.BlockAttributes.Add((BlockAttribute)blockAttribute.Clone());
		}
		multiLeader._style = (MultiLeaderStyle)_style.Clone();
		multiLeader._textStyle = (TextStyle)_textStyle.Clone();
		multiLeader._leaderLineType = (LineType)_leaderLineType.Clone();
		multiLeader._arrowhead = (BlockRecord)(_arrowhead?.Clone());
		multiLeader._blockContent = (BlockRecord)(_blockContent?.Clone());
		return multiLeader;
	}

	public override BoundingBox GetBoundingBox()
	{
		return BoundingBox.Null;
	}

	internal override void AssignDocument(CadDocument doc)
	{
		base.AssignDocument(doc);
		_style = CadObject.updateCollection(_style, doc.MLeaderStyles);
		_textStyle = CadObject.updateCollection(_textStyle, doc.TextStyles);
		_leaderLineType = CadObject.updateCollection(_leaderLineType, doc.LineTypes);
		_arrowhead = CadObject.updateCollection(_arrowhead, doc.BlockRecords);
		_blockContent = CadObject.updateCollection(_blockContent, doc.BlockRecords);
		ContextData.AssignDocument(doc);
		doc.LineTypes.OnRemove += tableOnRemove;
		doc.TextStyles.OnRemove += tableOnRemove;
		doc.MLeaderStyles.OnRemove += tableOnRemove;
		doc.BlockRecords.OnRemove += tableOnRemove;
	}

	internal override void UnassignDocument()
	{
		base.Document.LineTypes.OnRemove -= tableOnRemove;
		base.Document.TextStyles.OnRemove -= tableOnRemove;
		base.Document.MLeaderStyles.OnRemove -= tableOnRemove;
		base.Document.BlockRecords.OnRemove -= tableOnRemove;
		ContextData.UnassignDocument();
		base.UnassignDocument();
		_leaderLineType = (LineType)_leaderLineType.Clone();
		_textStyle = (TextStyle)_textStyle.Clone();
		_style = (MultiLeaderStyle)_style.Clone();
		_arrowhead = (BlockRecord)(_arrowhead?.Clone());
		_blockContent = (BlockRecord)(_blockContent?.Clone());
	}

	protected override void tableOnRemove(object sender, CollectionChangedEventArgs e)
	{
		base.tableOnRemove(sender, e);
		if (e.Item.Equals(_style))
		{
			_style = base.Document.MLeaderStyles["Standard"];
		}
		if (e.Item.Equals(_leaderLineType))
		{
			_leaderLineType = base.Document.LineTypes["ByLayer"];
		}
		if (e.Item.Equals(_textStyle))
		{
			_textStyle = base.Document.TextStyles["Standard"];
		}
		if (e.Item == _arrowhead)
		{
			_arrowhead = null;
		}
		if (e.Item == _blockContent)
		{
			_blockContent = null;
		}
	}
}
