using System;
using ACadSharp.Attributes;
using ACadSharp.Entities;
using ACadSharp.Tables;
using CSMath;

namespace ACadSharp.Objects;

[DxfName("MLEADERSTYLE")]
[DxfSubClass("AcDbMLeaderStyle")]
public class MultiLeaderStyle : NonGraphicalObject
{
	public const string DefaultName = "Standard";

	private BlockRecord _arrowhead;

	private BlockRecord _blockContent;

	private XYZ _blockContentScale = new XYZ(1.0);

	private LineType _leaderLineType = LineType.ByLayer;

	private TextStyle _textStyle = TextStyle.Default;

	public static MultiLeaderStyle Default => new MultiLeaderStyle("Standard");

	[DxfCodeValue(new int[] { 46 })]
	public double AlignSpace { get; set; }

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 341 })]
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

	[DxfCodeValue(new int[] { 44 })]
	public double ArrowheadSize { get; set; } = 0.18;

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 343 })]
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

	[DxfCodeValue(new int[] { 94 })]
	public Color BlockContentColor { get; set; } = Color.ByBlock;

	[DxfCodeValue(new int[] { 177 })]
	public BlockContentConnectionType BlockContentConnection { get; set; }

	[DxfCodeValue(DxfReferenceType.IsAngle, new int[] { 141 })]
	public double BlockContentRotation { get; set; }

	public XYZ BlockContentScale
	{
		get
		{
			return _blockContentScale;
		}
		set
		{
			_blockContentScale = value;
		}
	}

	[DxfCodeValue(new int[] { 47 })]
	public double BlockContentScaleX
	{
		get
		{
			return _blockContentScale.X;
		}
		set
		{
			_blockContentScale.X = value;
		}
	}

	[DxfCodeValue(new int[] { 49 })]
	public double BlockContentScaleY
	{
		get
		{
			return _blockContentScale.Y;
		}
		set
		{
			_blockContentScale.Y = value;
		}
	}

	[DxfCodeValue(new int[] { 140 })]
	public double BlockContentScaleZ
	{
		get
		{
			return _blockContentScale.Z;
		}
		set
		{
			_blockContentScale.Z = value;
		}
	}

	[DxfCodeValue(new int[] { 143 })]
	public double BreakGapSize { get; set; } = 0.125;

	[DxfCodeValue(new int[] { 170 })]
	public LeaderContentType ContentType { get; set; } = LeaderContentType.MText;

	[DxfCodeValue(new int[] { 300 })]
	public string DefaultTextContents { get; set; } = string.Empty;

	[DxfCodeValue(new int[] { 3 })]
	public string Description { get; set; } = string.Empty;

	[DxfCodeValue(new int[] { 294 })]
	public bool EnableBlockContentRotation { get; set; }

	[DxfCodeValue(new int[] { 293 })]
	public bool EnableBlockContentScale { get; set; }

	[DxfCodeValue(new int[] { 291 })]
	public bool EnableDogleg { get; set; } = true;

	[DxfCodeValue(new int[] { 290 })]
	public bool EnableLanding { get; set; } = true;

	[DxfCodeValue(new int[] { 40 })]
	public double FirstSegmentAngleConstraint { get; set; }

	[DxfCodeValue(new int[] { 296 })]
	public bool IsAnnotative { get; set; }

	[DxfCodeValue(new int[] { 43 })]
	public double LandingDistance { get; set; } = 0.36;

	[DxfCodeValue(new int[] { 42 })]
	public double LandingGap { get; set; } = 0.09;

	[DxfCodeValue(new int[] { 172 })]
	public LeaderDrawOrderType LeaderDrawOrder { get; set; }

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 340 })]
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

	[DxfCodeValue(new int[] { 92 })]
	public LineWeightType LeaderLineWeight { get; set; } = LineWeightType.ByBlock;

	[DxfCodeValue(new int[] { 91 })]
	public Color LineColor { get; set; }

	[DxfCodeValue(new int[] { 90 })]
	public int MaxLeaderSegmentsPoints { get; set; } = 2;

	[DxfCodeValue(new int[] { 171 })]
	public MultiLeaderDrawOrderType MultiLeaderDrawOrder { get; set; }

	public override string ObjectName => "MLEADERSTYLE";

	public override ObjectType ObjectType => ObjectType.UNLISTED;

	[DxfCodeValue(new int[] { 295 })]
	public bool OverwritePropertyValue { get; set; }

	[DxfCodeValue(new int[] { 173 })]
	public MultiLeaderPathType PathType { get; set; }

	[DxfCodeValue(new int[] { 142 })]
	public double ScaleFactor { get; set; } = 1.0;

	[DxfCodeValue(new int[] { 41 })]
	public double SecondSegmentAngleConstraint { get; set; }

	public override string SubclassMarker => "AcDbMLeaderStyle";

	[DxfCodeValue(new int[] { 297 })]
	public bool TextAlignAlwaysLeft { get; set; }

	[DxfCodeValue(new int[] { 176 })]
	public TextAlignmentType TextAlignment { get; set; }

	[DxfCodeValue(new int[] { 175 })]
	public TextAngleType TextAngle { get; set; } = TextAngleType.Horizontal;

	[DxfCodeValue(new int[] { 271 })]
	public TextAttachmentDirectionType TextAttachmentDirection { get; set; }

	[DxfCodeValue(new int[] { 272 })]
	public TextAttachmentType TextBottomAttachment { get; set; }

	[DxfCodeValue(new int[] { 93 })]
	public Color TextColor { get; set; } = Color.ByBlock;

	[DxfCodeValue(new int[] { 292 })]
	public bool TextFrame { get; set; }

	[DxfCodeValue(new int[] { 45 })]
	public double TextHeight { get; set; } = 0.18;

	[DxfCodeValue(new int[] { 174 })]
	public TextAttachmentType TextLeftAttachment { get; set; }

	[DxfCodeValue(new int[] { 178 })]
	public TextAttachmentType TextRightAttachment { get; set; }

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 342 })]
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

	[DxfCodeValue(new int[] { 273 })]
	public TextAttachmentType TextTopAttachment { get; set; }

	[DxfCodeValue(new int[] { 298 })]
	public bool UnknownFlag298 { get; set; }

	public MultiLeaderStyle()
		: this(string.Empty)
	{
	}

	public MultiLeaderStyle(string name)
	{
		Name = name;
	}

	public override CadObject Clone()
	{
		MultiLeaderStyle obj = (MultiLeaderStyle)base.Clone();
		obj.TextStyle = (TextStyle)_textStyle.Clone();
		obj.LeaderLineType = (LineType)_leaderLineType.Clone();
		obj.Arrowhead = (BlockRecord)(_arrowhead?.Clone());
		obj.BlockContent = (BlockRecord)(_blockContent?.Clone());
		return obj;
	}

	internal override void AssignDocument(CadDocument doc)
	{
		base.AssignDocument(doc);
		_textStyle = CadObject.updateCollection(_textStyle, doc.TextStyles);
		_leaderLineType = CadObject.updateCollection(_leaderLineType, doc.LineTypes);
		_arrowhead = CadObject.updateCollection(_arrowhead, doc.BlockRecords);
		_blockContent = CadObject.updateCollection(_blockContent, doc.BlockRecords);
		doc.TextStyles.OnRemove += tableOnRemove;
		doc.LineTypes.OnRemove += tableOnRemove;
		doc.BlockRecords.OnRemove += tableOnRemove;
	}

	internal override void UnassignDocument()
	{
		base.Document.TextStyles.OnRemove -= tableOnRemove;
		base.Document.LineTypes.OnRemove -= tableOnRemove;
		base.Document.BlockRecords.OnRemove -= tableOnRemove;
		base.UnassignDocument();
		_textStyle = (TextStyle)_textStyle.Clone();
		_leaderLineType = (LineType)_leaderLineType.Clone();
		_arrowhead = (BlockRecord)(_arrowhead?.Clone());
		_blockContent = (BlockRecord)(_blockContent?.Clone());
	}

	protected virtual void tableOnRemove(object sender, CollectionChangedEventArgs e)
	{
		if (e.Item.Equals(_textStyle))
		{
			_textStyle = base.Document.TextStyles["0"];
		}
		if (e.Item.Equals(_leaderLineType))
		{
			_leaderLineType = base.Document.LineTypes["ByLayer"];
		}
		if (e.Item.Equals(Arrowhead))
		{
			_arrowhead = null;
		}
		if (e.Item.Equals(BlockContent))
		{
			_blockContent = null;
		}
	}
}
