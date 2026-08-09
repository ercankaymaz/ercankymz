using System;
using System.Collections.Generic;
using ACadSharp.Attributes;
using ACadSharp.Entities;
using ACadSharp.Tables;
using CSMath;

namespace ACadSharp.Objects;

[DxfName("ACDB_MLEADEROBJECTCONTEXTDATA_CLASS")]
[DxfSubClass("AcDbMLeaderObjectContextData")]
public class MultiLeaderObjectContextData : AnnotScaleObjectContextData
{
	public class LeaderLine : ICloneable
	{
		private LineType _lineType;

		[DxfCodeValue(DxfReferenceType.Handle, new int[] { 341 })]
		public BlockRecord Arrowhead { get; set; }

		[DxfCodeValue(new int[] { 40 })]
		public double ArrowheadSize { get; set; }

		public int BreakInfoCount { get; set; }

		[DxfCodeValue(new int[] { 91 })]
		public int Index { get; set; }

		[DxfCodeValue(new int[] { 92 })]
		public Color LineColor { get; set; }

		[DxfCodeValue(DxfReferenceType.Handle, new int[] { 340 })]
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
					_lineType = null;
				}
				else if (Document != null)
				{
					if (Document.LineTypes.TryGetValue(value.Name, out var item))
					{
						_lineType = item;
						return;
					}
					_lineType = value;
					Document.LineTypes.Add(_lineType);
				}
			}
		}

		[DxfCodeValue(new int[] { 171 })]
		public LineWeightType LineWeight { get; set; }

		[DxfCodeValue(new int[] { 93 })]
		public LeaderLinePropertOverrideFlags OverrideFlags { get; set; }

		[DxfCodeValue(new int[] { 170 })]
		public MultiLeaderPathType PathType { get; set; }

		public IList<XYZ> Points { get; private set; } = new List<XYZ>();

		[DxfCodeValue(new int[] { 90 })]
		public int SegmentIndex { get; set; }

		public IList<StartEndPointPair> StartEndPoints { get; private set; } = new List<StartEndPointPair>();

		internal CadDocument Document { get; set; }

		public void AssignDocument(CadDocument doc)
		{
			Document = doc;
			if (_lineType != null)
			{
				if (doc.LineTypes.TryGetValue(_lineType.Name, out var item))
				{
					_lineType = item;
				}
				else
				{
					doc.LineTypes.Add(_lineType);
				}
			}
			doc.LineTypes.OnRemove += tableOnRemove;
		}

		public object Clone()
		{
			LeaderLine leaderLine = (LeaderLine)MemberwiseClone();
			leaderLine.LineType = (LineType)(LineType?.Clone());
			leaderLine.Arrowhead = (BlockRecord)(Arrowhead?.Clone());
			leaderLine.Points = new List<XYZ>();
			foreach (XYZ point in Points)
			{
				leaderLine.Points.Add(point);
			}
			leaderLine.StartEndPoints = new List<StartEndPointPair>();
			foreach (StartEndPointPair startEndPoint in StartEndPoints)
			{
				leaderLine.StartEndPoints.Add((StartEndPointPair)startEndPoint.Clone());
			}
			return leaderLine;
		}

		public void UassignDocument()
		{
			Document.LineTypes.OnRemove -= tableOnRemove;
			Document = null;
			_lineType = (LineType)(_lineType?.Clone());
		}

		private void tableOnRemove(object sender, CollectionChangedEventArgs e)
		{
			if (e.Item.Equals(_lineType))
			{
				_lineType = null;
			}
		}
	}

	public class LeaderRoot : ICloneable
	{
		public IList<StartEndPointPair> BreakStartEndPointsPairs { get; private set; } = new List<StartEndPointPair>();

		[DxfCodeValue(new int[] { 10, 20, 30 })]
		public XYZ ConnectionPoint { get; set; }

		[DxfCodeValue(new int[] { 290 })]
		public bool ContentValid { get; set; }

		[DxfCodeValue(new int[] { 11, 21, 31 })]
		public XYZ Direction { get; set; }

		[DxfCodeValue(new int[] { 40 })]
		public double LandingDistance { get; set; }

		[DxfCodeValue(new int[] { 90 })]
		public int LeaderIndex { get; set; }

		public IList<LeaderLine> Lines { get; private set; } = new List<LeaderLine>();

		[DxfCodeValue(new int[] { 271 })]
		public TextAttachmentDirectionType TextAttachmentDirection { get; set; }

		[DxfCodeValue(new int[] { 291 })]
		public bool Unknown { get; set; }

		public object Clone()
		{
			LeaderRoot leaderRoot = (LeaderRoot)MemberwiseClone();
			leaderRoot.BreakStartEndPointsPairs = new List<StartEndPointPair>();
			foreach (StartEndPointPair breakStartEndPointsPair in BreakStartEndPointsPairs)
			{
				leaderRoot.BreakStartEndPointsPairs.Add((StartEndPointPair)breakStartEndPointsPair.Clone());
			}
			leaderRoot.Lines = new List<LeaderLine>();
			foreach (LeaderLine line in Lines)
			{
				leaderRoot.Lines.Add((LeaderLine)line.Clone());
			}
			return leaderRoot;
		}
	}

	public struct StartEndPointPair(XYZ startPoint, XYZ endPoint) : ICloneable
	{
		[DxfCodeValue(new int[] { 12, 22, 32 })]
		public XYZ StartPoint { get; private set; } = startPoint;

		[DxfCodeValue(new int[] { 13, 23, 33 })]
		public XYZ EndPoint { get; private set; } = endPoint;

		public object Clone()
		{
			return MemberwiseClone();
		}
	}

	private BlockRecord _blockContent;

	private TextStyle _textStyle = TextStyle.Default;

	[DxfCodeValue(new int[] { 140 })]
	public double ArrowheadSize { get; set; }

	[DxfCodeValue(new int[] { 91 })]
	public Color BackgroundFillColor { get; set; }

	[DxfCodeValue(new int[] { 291 })]
	public bool BackgroundFillEnabled { get; set; }

	[DxfCodeValue(new int[] { 292 })]
	public bool BackgroundMaskFillOn { get; set; }

	[DxfCodeValue(new int[] { 141 })]
	public double BackgroundScaleFactor { get; set; }

	[DxfCodeValue(new int[] { 92 })]
	public int BackgroundTransparency { get; set; }

	[DxfCodeValue(new int[] { 111, 121, 131 })]
	public XYZ BaseDirection { get; set; }

	[DxfCodeValue(new int[] { 110, 120, 130 })]
	public XYZ BasePoint { get; set; }

	[DxfCodeValue(new int[] { 112, 122, 132 })]
	public XYZ BaseVertical { get; set; }

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 341 })]
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

	public Color BlockContentColor { get; set; }

	[DxfCodeValue(new int[] { 177 })]
	public BlockContentConnectionType BlockContentConnection { get; set; }

	[DxfCodeValue(new int[] { 15, 25, 35 })]
	public XYZ BlockContentLocation { get; set; }

	[DxfCodeValue(new int[] { 14, 24, 34 })]
	public XYZ BlockContentNormal { get; set; }

	[DxfCodeValue(DxfReferenceType.IsAngle, new int[] { 46 })]
	public double BlockContentRotation { get; set; }

	[DxfCodeValue(new int[] { 16, 26, 36 })]
	public XYZ BlockContentScale { get; set; }

	[DxfCodeValue(new int[] { 44 })]
	public double BoundaryHeight { get; set; }

	[DxfCodeValue(new int[] { 43 })]
	public double BoundaryWidth { get; set; }

	[DxfCodeValue(new int[] { 294 })]
	public bool ColumnFlowReversed { get; set; }

	[DxfCodeValue(new int[] { 143 })]
	public double ColumnGutter { get; set; }

	[DxfCodeValue(new int[] { 144 })]
	public IList<double> ColumnSizes { get; } = new List<double>();

	[DxfCodeValue(new int[] { 173 })]
	public short ColumnType { get; set; }

	[DxfCodeValue(new int[] { 142 })]
	public double ColumnWidth { get; set; }

	[DxfCodeValue(new int[] { 10, 20, 30 })]
	public XYZ ContentBasePoint { get; set; }

	[DxfCodeValue(new int[] { 13, 23, 33 })]
	public XYZ Direction { get; set; }

	[DxfCodeValue(new int[] { 172 })]
	public FlowDirectionType FlowDirection { get; set; }

	[DxfCodeValue(new int[] { 296 })]
	public bool HasContentsBlock { get; set; }

	[DxfCodeValue(new int[] { 290 })]
	public bool HasTextContents { get; set; }

	[DxfCodeValue(new int[] { 145 })]
	public double LandingGap { get; set; }

	public IList<LeaderRoot> LeaderRoots { get; private set; } = new List<LeaderRoot>();

	[DxfCodeValue(new int[] { 170 })]
	public LineSpacingStyle LineSpacing { get; set; }

	[DxfCodeValue(new int[] { 45 })]
	public double LineSpacingFactor { get; set; }

	[DxfCodeValue(new int[] { 297 })]
	public bool NormalReversed { get; set; }

	public override string ObjectName => "ACDB_MLEADEROBJECTCONTEXTDATA_CLASS";

	public override ObjectType ObjectType => ObjectType.UNLISTED;

	[DxfCodeValue(new int[] { 40 })]
	public double ScaleFactor { get; set; }

	public override string SubclassMarker => "AcDbMLeaderObjectContextData";

	[DxfCodeValue(new int[] { 176 })]
	public TextAlignmentType TextAlignment { get; set; }

	[DxfCodeValue(new int[] { 171 })]
	public TextAttachmentPointType TextAttachmentPoint { get; set; }

	[DxfCodeValue(new int[] { 272 })]
	public TextAttachmentType TextBottomAttachment { get; set; }

	[DxfCodeValue(new int[] { 90 })]
	public Color TextColor { get; set; }

	[DxfCodeValue(new int[] { 41 })]
	public double TextHeight { get; set; }

	[DxfCodeValue(new int[] { 293 })]
	public bool TextHeightAutomatic { get; set; }

	[DxfCodeValue(new int[] { 304 })]
	public string TextLabel { get; set; }

	[DxfCodeValue(new int[] { 174 })]
	public TextAttachmentType TextLeftAttachment { get; set; }

	[DxfCodeValue(new int[] { 12, 22, 32 })]
	public XYZ TextLocation { get; set; }

	[DxfCodeValue(new int[] { 11, 21, 31 })]
	public XYZ TextNormal { get; set; }

	[DxfCodeValue(new int[] { 175 })]
	public TextAttachmentType TextRightAttachment { get; set; }

	[DxfCodeValue(DxfReferenceType.IsAngle, new int[] { 42 })]
	public double TextRotation { get; set; }

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 340 })]
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

	public Matrix4 TransformationMatrix { get; set; }

	[DxfCodeValue(new int[] { 295 })]
	public bool WordBreak { get; set; }

	public override CadObject Clone()
	{
		MultiLeaderObjectContextData multiLeaderObjectContextData = (MultiLeaderObjectContextData)base.Clone();
		multiLeaderObjectContextData._textStyle = (TextStyle)_textStyle.Clone();
		multiLeaderObjectContextData._blockContent = (BlockRecord)(_blockContent?.Clone());
		multiLeaderObjectContextData.LeaderRoots = new List<LeaderRoot>();
		foreach (LeaderRoot leaderRoot in LeaderRoots)
		{
			multiLeaderObjectContextData.LeaderRoots.Add((LeaderRoot)leaderRoot.Clone());
		}
		return multiLeaderObjectContextData;
	}

	internal override void AssignDocument(CadDocument doc)
	{
		base.AssignDocument(doc);
		_textStyle = CadObject.updateCollection(_textStyle, doc.TextStyles);
		_blockContent = CadObject.updateCollection(_blockContent, doc.BlockRecords);
		foreach (LeaderRoot leaderRoot in LeaderRoots)
		{
			foreach (LeaderLine line in leaderRoot.Lines)
			{
				line.AssignDocument(doc);
			}
		}
		base.Document.TextStyles.OnRemove += tableOnRemove;
		base.Document.BlockRecords.OnRemove += tableOnRemove;
	}

	internal override void UnassignDocument()
	{
		base.Document.TextStyles.OnRemove -= tableOnRemove;
		base.Document.BlockRecords.OnRemove -= tableOnRemove;
		base.UnassignDocument();
		_textStyle = (TextStyle)_textStyle.Clone();
		_blockContent = (BlockRecord)(_blockContent?.Clone());
		foreach (LeaderRoot leaderRoot in LeaderRoots)
		{
			foreach (LeaderLine line in leaderRoot.Lines)
			{
				line.UassignDocument();
			}
		}
	}

	private void tableOnRemove(object sender, CollectionChangedEventArgs e)
	{
		if (e.Item.Equals(_textStyle))
		{
			_textStyle = base.Document.TextStyles["Standard"];
		}
		if (e.Item == _blockContent)
		{
			_blockContent = null;
		}
	}
}
