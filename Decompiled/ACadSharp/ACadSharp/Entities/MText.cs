using System;
using System.Collections.Generic;
using ACadSharp.Attributes;
using ACadSharp.Tables;
using ACadSharp.Text;
using CSMath;

namespace ACadSharp.Entities;

[DxfName("MTEXT")]
[DxfSubClass("AcDbMText")]
public class MText : Entity, IText, IEntity, IHandledCadObject, IGeometricEntity
{
	public class TextColumn
	{
		[DxfCodeValue(new int[] { 75 })]
		public ColumnType ColumnType { get; set; }

		[DxfCodeValue(new int[] { 76 })]
		public int ColumnCount => ColumnHeights.Count;

		[DxfCodeValue(new int[] { 78 })]
		public bool ColumnFlowReversed { get; set; }

		[DxfCodeValue(new int[] { 79 })]
		public bool ColumnAutoHeight { get; set; }

		[DxfCodeValue(new int[] { 48 })]
		public double ColumnWidth { get; set; }

		[DxfCodeValue(new int[] { 49 })]
		public double ColumnGutter { get; set; }

		[DxfCodeValue(new int[] { 50 })]
		public List<double> ColumnHeights { get; } = new List<double>();

		public TextColumn Clone()
		{
			return MemberwiseClone() as TextColumn;
		}
	}

	private double _height = 1.0;

	private TextStyle _style = TextStyle.Default;

	[DxfCodeValue(new int[] { 11, 21, 31 })]
	public XYZ AlignmentPoint { get; set; } = XYZ.AxisX;

	[DxfCodeValue(new int[] { 71 })]
	public AttachmentPointType AttachmentPoint { get; set; } = AttachmentPointType.TopLeft;

	[DxfCodeValue(new int[] { 63, 421, 430 })]
	public Color BackgroundColor { get; set; }

	[DxfCodeValue(new int[] { 90 })]
	public BackgroundFillFlags BackgroundFillFlags { get; set; }

	[DxfCodeValue(new int[] { 45 })]
	public double BackgroundScale { get; set; } = 1.5;

	[DxfCodeValue(new int[] { 441 })]
	public Transparency BackgroundTransparency { get; set; }

	public TextColumn Column { get; set; } = new TextColumn();

	[DxfCodeValue(new int[] { 72 })]
	public DrawingDirectionType DrawingDirection { get; set; } = DrawingDirectionType.LeftToRight;

	[DxfCodeValue(new int[] { 40 })]
	public double Height
	{
		get
		{
			return _height;
		}
		set
		{
			if (value <= 0.0)
			{
				throw new ArgumentOutOfRangeException("value", value, "The MText height must be greater than zero.");
			}
			_height = value;
		}
	}

	[DxfCodeValue(DxfReferenceType.Ignored, new int[] { 42 })]
	public double HorizontalWidth { get; set; } = 0.9;

	[DxfCodeValue(new int[] { 10, 20, 30 })]
	public XYZ InsertPoint { get; set; } = XYZ.Zero;

	public bool IsAnnotative { get; set; }

	[DxfCodeValue(new int[] { 44 })]
	public double LineSpacing { get; set; } = 1.0;

	[DxfCodeValue(new int[] { 73 })]
	public LineSpacingStyleType LineSpacingStyle { get; set; }

	[DxfCodeValue(new int[] { 210, 220, 230 })]
	public XYZ Normal { get; set; } = XYZ.AxisZ;

	public override string ObjectName => "MTEXT";

	public override ObjectType ObjectType => ObjectType.MTEXT;

	public string PlainText
	{
		get
		{
			List<string> groups;
			return TextProcessor.Parse(Value, out groups);
		}
	}

	[DxfCodeValue(new int[] { 46 })]
	public double RectangleHeight { get; set; }

	[DxfCodeValue(new int[] { 41 })]
	public double RectangleWidth { get; set; }

	[DxfCodeValue(DxfReferenceType.Ignored | DxfReferenceType.IsAngle, new int[] { 50 })]
	public double Rotation => new XY(AlignmentPoint.X, AlignmentPoint.Y).GetAngle();

	[DxfCodeValue(DxfReferenceType.Name | DxfReferenceType.Optional, new int[] { 7 })]
	public TextStyle Style
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
				_style = CadObject.updateCollection(value, base.Document.TextStyles);
			}
			else
			{
				_style = value;
			}
		}
	}

	public override string SubclassMarker => "AcDbMText";

	[DxfCodeValue(new int[] { 1 })]
	public string Value { get; set; } = string.Empty;

	[DxfCodeValue(DxfReferenceType.Ignored, new int[] { 43 })]
	public double VerticalHeight { get; set; } = 0.2;

	public MText()
	{
	}

	public MText(string value)
	{
		Value = value;
	}

	public override void ApplyTransform(Transform transform)
	{
		XYZ insertPoint = transform.ApplyTransform(InsertPoint);
		XYZ xYZ = transformNormal(transform, Normal);
		Matrix3 transOW;
		Matrix3 transWO;
		Matrix3 worldMatrix = getWorldMatrix(transform, Normal, xYZ, out transOW, out transWO);
		transWO = transWO.Transpose();
		List<XY> list = applyRotation(new XY[2]
		{
			XY.AxisX,
			XY.AxisY
		}, Rotation);
		XYZ xYZ2 = transOW * new XYZ(list[0].X, list[0].Y, 0.0);
		xYZ2 = worldMatrix * xYZ2;
		xYZ2 = transWO * xYZ2;
		XY xY = new XY(xYZ2.X, xYZ2.Y);
		double length = xY.GetLength();
		xYZ2 = transOW * new XYZ(list[1].X, list[1].Y, 0.0);
		xYZ2 = worldMatrix * xYZ2;
		xYZ2 = transWO * xYZ2;
		XY xy = new XY(xYZ2.X, xYZ2.Y);
		double angle = xY.GetAngle();
		if (XY.Cross(xY, xy) < 0.0)
		{
			if (xY.Dot(list[0]) < 0.0)
			{
				angle += 180.0;
				switch (AttachmentPoint)
				{
				case AttachmentPointType.TopLeft:
					AttachmentPoint = AttachmentPointType.TopRight;
					break;
				case AttachmentPointType.TopRight:
					AttachmentPoint = AttachmentPointType.TopLeft;
					break;
				case AttachmentPointType.MiddleLeft:
					AttachmentPoint = AttachmentPointType.MiddleRight;
					break;
				case AttachmentPointType.MiddleRight:
					AttachmentPoint = AttachmentPointType.MiddleLeft;
					break;
				case AttachmentPointType.BottomLeft:
					AttachmentPoint = AttachmentPointType.BottomRight;
					break;
				case AttachmentPointType.BottomRight:
					AttachmentPoint = AttachmentPointType.BottomLeft;
					break;
				}
			}
			else
			{
				switch (AttachmentPoint)
				{
				case AttachmentPointType.TopLeft:
					AttachmentPoint = AttachmentPointType.BottomLeft;
					break;
				case AttachmentPointType.TopCenter:
					AttachmentPoint = AttachmentPointType.BottomCenter;
					break;
				case AttachmentPointType.TopRight:
					AttachmentPoint = AttachmentPointType.BottomRight;
					break;
				case AttachmentPointType.BottomLeft:
					AttachmentPoint = AttachmentPointType.TopLeft;
					break;
				case AttachmentPointType.BottomCenter:
					AttachmentPoint = AttachmentPointType.TopCenter;
					break;
				case AttachmentPointType.BottomRight:
					AttachmentPoint = AttachmentPointType.TopRight;
					break;
				}
			}
		}
		double num = Height * length;
		num = (MathHelper.IsZero(num) ? 1E-12 : num);
		InsertPoint = insertPoint;
		Normal = xYZ;
		Height = num;
		RectangleWidth *= length;
	}

	public override CadObject Clone()
	{
		MText obj = (MText)base.Clone();
		obj.Style = (TextStyle)(Style?.Clone());
		obj.Column = Column?.Clone();
		return obj;
	}

	public override BoundingBox GetBoundingBox()
	{
		return new BoundingBox(InsertPoint);
	}

	public string[] GetPlainTextLines()
	{
		return PlainText.Split(new string[4] { "\r\n", "\r", "\n", "\\P" }, StringSplitOptions.None);
	}

	public string[] GetTextLines()
	{
		return Value.Split(new string[4] { "\r\n", "\r", "\n", "\\P" }, StringSplitOptions.None);
	}

	internal override void AssignDocument(CadDocument doc)
	{
		base.AssignDocument(doc);
		_style = CadObject.updateCollection(Style, doc.TextStyles);
		doc.DimensionStyles.OnRemove += tableOnRemove;
	}

	internal override void UnassignDocument()
	{
		base.Document.DimensionStyles.OnRemove -= tableOnRemove;
		base.UnassignDocument();
		Style = (TextStyle)Style.Clone();
	}

	protected override void tableOnRemove(object sender, CollectionChangedEventArgs e)
	{
		base.tableOnRemove(sender, e);
		if (e.Item.Equals(Style))
		{
			Style = base.Document.TextStyles["Standard"];
		}
	}
}
