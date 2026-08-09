using System;
using System.Collections.Generic;
using ACadSharp.Attributes;
using ACadSharp.Tables;
using CSMath;
using CSUtilities.Extensions;

namespace ACadSharp.Entities;

[DxfName("TEXT")]
[DxfSubClass("AcDbText")]
public class TextEntity : Entity, IText, IEntity, IHandledCadObject, IGeometricEntity
{
	private double _height = 1.0;

	private TextMirrorFlag _mirror;

	private TextStyle _style = TextStyle.Default;

	private string _value = string.Empty;

	[DxfCodeValue(DxfReferenceType.Optional, new int[] { 11, 21, 31 })]
	public XYZ AlignmentPoint { get; set; }

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
				throw new ArgumentOutOfRangeException("value", value, "The Text height must be greater than zero.");
			}
			_height = value;
		}
	}

	[DxfCodeValue(new int[] { 72 })]
	public TextHorizontalAlignment HorizontalAlignment { get; set; }

	[DxfCodeValue(new int[] { 10, 20, 30 })]
	public XYZ InsertPoint { get; set; } = XYZ.Zero;

	[DxfCodeValue(new int[] { 71 })]
	public TextMirrorFlag Mirror
	{
		get
		{
			return _mirror;
		}
		set
		{
			_mirror = value;
		}
	}

	[DxfCodeValue(new int[] { 210, 220, 230 })]
	public XYZ Normal { get; set; } = XYZ.AxisZ;

	public override string ObjectName => "TEXT";

	public override ObjectType ObjectType => ObjectType.TEXT;

	[DxfCodeValue(DxfReferenceType.IsAngle, new int[] { 51 })]
	public double ObliqueAngle { get; set; }

	[DxfCodeValue(DxfReferenceType.IsAngle, new int[] { 50 })]
	public double Rotation { get; set; }

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

	public override string SubclassMarker => "AcDbText";

	[DxfCodeValue(new int[] { 39 })]
	public double Thickness { get; set; }

	[DxfCodeValue(new int[] { 1 })]
	public string Value
	{
		get
		{
			return _value;
		}
		set
		{
			if (value.Length > 256)
			{
				throw new ArgumentException($"Text length cannot be supiror than 256, current: {value.Length}");
			}
			_value = value;
		}
	}

	[DxfCodeValue(DxfReferenceType.Optional, new int[] { 73 })]
	public virtual TextVerticalAlignmentType VerticalAlignment { get; set; }

	[DxfCodeValue(DxfReferenceType.Optional, new int[] { 41 })]
	public double WidthFactor { get; set; } = 1.0;

	public override void ApplyTransform(Transform transform)
	{
		bool flag = Mirror.HasFlag(TextMirrorFlag.Backward);
		XYZ insertPoint = transform.ApplyTransform(InsertPoint);
		XYZ xYZ = transformNormal(transform, Normal);
		Matrix3 transOW;
		Matrix3 transWO;
		Matrix3 worldMatrix = getWorldMatrix(transform, Normal, xYZ, out transOW, out transWO);
		List<XY> list = applyRotation(new XY[2]
		{
			WidthFactor * Height * XY.AxisX,
			new XY(Height * Math.Tan(ObliqueAngle), Height)
		}, Rotation);
		XYZ xYZ2 = transOW * new XYZ(list[0].X, list[0].Y, 0.0);
		xYZ2 = worldMatrix * xYZ2;
		xYZ2 = transWO * xYZ2;
		XY xY = new XY(xYZ2.X, xYZ2.Y);
		xYZ2 = transOW * new XYZ(list[1].X, list[1].Y, 0.0);
		xYZ2 = worldMatrix * xYZ2;
		xYZ2 = transWO * xYZ2;
		XY xY2 = new XY(xYZ2.X, xYZ2.Y);
		double num = xY.GetAngle();
		double angle = xY2.GetAngle();
		if (flag)
		{
			if (XY.Cross(xY, xY2) < 0.0)
			{
				angle = Math.PI / 2.0 - (num - angle);
				if (!HorizontalAlignment.HasFlag(TextHorizontalAlignment.Fit) && !HorizontalAlignment.HasFlag(TextHorizontalAlignment.Aligned))
				{
					num += Math.PI;
				}
				_mirror.RemoveFlag(TextMirrorFlag.Backward);
			}
			else
			{
				angle = Math.PI / 2.0 + (num - angle);
			}
		}
		else if (XY.Cross(xY, xY2) < 0.0)
		{
			angle = Math.PI / 2.0 - (num - angle);
			if (xY.Dot(list[0]) < 0.0)
			{
				num += Math.PI;
				switch (HorizontalAlignment)
				{
				case TextHorizontalAlignment.Left:
					HorizontalAlignment = TextHorizontalAlignment.Right;
					break;
				case TextHorizontalAlignment.Right:
					HorizontalAlignment = TextHorizontalAlignment.Left;
					break;
				}
			}
			else
			{
				switch (VerticalAlignment)
				{
				case TextVerticalAlignmentType.Top:
					VerticalAlignment = TextVerticalAlignmentType.Bottom;
					break;
				case TextVerticalAlignmentType.Bottom:
					VerticalAlignment = TextVerticalAlignmentType.Top;
					break;
				}
			}
		}
		else
		{
			angle = Math.PI / 2.0 + (num - angle);
		}
		double num2 = MathHelper.DegToRad(85.0);
		double num3 = 0.0 - num2;
		if (angle > Math.PI)
		{
			angle = Math.PI - angle;
		}
		if (angle < num3)
		{
			angle = num3;
		}
		else if (angle > num2)
		{
			angle = num2;
		}
		double num4 = xY2.GetLength() * Math.Cos(angle);
		num4 = (MathHelper.IsZero(num4) ? 1E-12 : num4);
		double num5 = xY.GetLength() / num4;
		if (num5 < 0.01)
		{
			num5 = 0.01;
		}
		else if (num5 > 100.0)
		{
			num5 = 100.0;
		}
		InsertPoint = insertPoint;
		Normal = xYZ;
		Rotation = num;
		Height = num4;
		WidthFactor = num5;
		ObliqueAngle = angle;
	}

	public override CadObject Clone()
	{
		TextEntity obj = (TextEntity)base.Clone();
		obj.Style = (TextStyle)Style.Clone();
		return obj;
	}

	public override BoundingBox GetBoundingBox()
	{
		return new BoundingBox(InsertPoint);
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
