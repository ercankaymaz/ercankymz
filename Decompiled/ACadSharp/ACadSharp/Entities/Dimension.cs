using System;
using System.Collections.Generic;
using System.Linq;
using ACadSharp.Attributes;
using ACadSharp.Extensions;
using ACadSharp.Tables;
using ACadSharp.Types.Units;
using ACadSharp.XData;
using CSMath;
using CSUtilities.Extensions;

namespace ACadSharp.Entities;

[DxfName("DIMENSION")]
[DxfSubClass("AcDbDimension")]
public abstract class Dimension : Entity
{
	protected BlockRecord _block;

	protected DimensionType _flags;

	private DimensionStyle _style = DimensionStyle.Default;

	[DxfCodeValue(new int[] { 71 })]
	public AttachmentPointType AttachmentPoint { get; set; }

	[DxfCodeValue(DxfReferenceType.Name, new int[] { 2 })]
	public BlockRecord Block
	{
		get
		{
			return _block;
		}
		set
		{
			_block = CadObject.updateCollection(value, base.Document?.BlockRecords);
		}
	}

	[DxfCodeValue(new int[] { 10, 20, 30 })]
	public XYZ DefinitionPoint { get; set; }

	[DxfCodeValue(new int[] { 70 })]
	public DimensionType Flags
	{
		get
		{
			return _flags;
		}
		internal set
		{
			_flags = value;
		}
	}

	[DxfCodeValue(new int[] { 74 })]
	public bool FlipArrow1 { get; set; }

	[DxfCodeValue(new int[] { 75 })]
	public bool FlipArrow2 { get; set; }

	public bool HasStyleOverride
	{
		get
		{
			if (base.ExtendedData.TryGet("ACAD", out var value))
			{
				if (!(value.Records.FirstOrDefault() is ExtendedDataString extendedDataString) || extendedDataString.Value != "DSTYLE")
				{
					return false;
				}
				return true;
			}
			return false;
		}
	}

	[DxfCodeValue(DxfReferenceType.Optional | DxfReferenceType.IsAngle, new int[] { 51 })]
	public double HorizontalDirection { get; set; }

	[DxfCodeValue(new int[] { 12, 22, 32 })]
	public XYZ InsertionPoint { get; set; }

	public bool IsAngular
	{
		get
		{
			if (!Flags.HasFlag(DimensionType.Angular3Point))
			{
				return Flags.HasFlag(DimensionType.Angular);
			}
			return true;
		}
	}

	public bool IsTextUserDefinedLocation
	{
		get
		{
			return _flags.HasFlag(DimensionType.TextUserDefinedLocation);
		}
		set
		{
			if (value)
			{
				_flags.AddFlag(DimensionType.TextUserDefinedLocation);
			}
			else
			{
				_flags.RemoveFlag(DimensionType.TextUserDefinedLocation);
			}
		}
	}

	[DxfCodeValue(DxfReferenceType.Optional, new int[] { 41 })]
	public double LineSpacingFactor { get; set; }

	[DxfCodeValue(DxfReferenceType.Optional, new int[] { 72 })]
	public LineSpacingStyleType LineSpacingStyle { get; set; }

	[DxfCodeValue(DxfReferenceType.Optional, new int[] { 42 })]
	public abstract double Measurement { get; }

	[DxfCodeValue(new int[] { 210, 220, 230 })]
	public XYZ Normal { get; set; } = XYZ.AxisZ;

	[DxfCodeValue(DxfReferenceType.Name, new int[] { 3 })]
	public DimensionStyle Style
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
			_style = CadObject.updateCollection(value, base.Document?.DimensionStyles);
		}
	}

	public override string SubclassMarker => "AcDbDimension";

	[DxfCodeValue(DxfReferenceType.Optional, new int[] { 1 })]
	public string Text { get; set; }

	[DxfCodeValue(new int[] { 11, 21, 31 })]
	public XYZ TextMiddlePoint { get; set; }

	[DxfCodeValue(DxfReferenceType.Optional | DxfReferenceType.IsAngle, new int[] { 53 })]
	public double TextRotation { get; set; }

	[DxfCodeValue(new int[] { 280 })]
	public byte Version { get; set; }

	protected Dimension(DimensionType type)
	{
		_flags = type;
		_flags |= DimensionType.BlockReference;
	}

	public override void ApplyTransform(Transform transform)
	{
		XYZ xYZ = transformNormal(transform, Normal);
		getWorldMatrix(transform, Normal, xYZ, out var transOW, out var transWO);
		DefinitionPoint = applyWorldMatrix(DefinitionPoint, transform, transOW, transWO);
		if (IsTextUserDefinedLocation)
		{
			TextMiddlePoint = applyWorldMatrix(TextMiddlePoint, transform, transOW, transWO);
		}
		Normal = xYZ;
	}

	public override CadObject Clone()
	{
		Dimension obj = (Dimension)base.Clone();
		obj.Style = Style.CloneTyped();
		obj.Block = Block?.CloneTyped();
		return obj;
	}

	public DimensionStyle GetActiveDimensionStyle()
	{
		if (!HasStyleOverride)
		{
			return Style;
		}
		DimensionStyle dimensionStyle = Style.CloneTyped();
		dimensionStyle.Name = "override";
		DxfClassMap dxfClassMap = DxfClassMap.Create(Style);
		foreach (KeyValuePair<int, DxfProperty> dxfProperty2 in GetStyleOverrideMap().DxfProperties)
		{
			DxfProperty dxfProperty = dxfClassMap.DxfProperties[dxfProperty2.Key];
			if (dxfProperty.StoredValue != dxfProperty2.Value.StoredValue)
			{
				dxfProperty.SetValue(dimensionStyle, dxfProperty2.Value.StoredValue);
			}
		}
		return dimensionStyle;
	}

	public string GetMeasurementText()
	{
		return GetMeasurementText(Style);
	}

	public string GetMeasurementText(DimensionStyle style)
	{
		if (!string.IsNullOrEmpty(Text))
		{
			return Text;
		}
		string empty = string.Empty;
		double num = style.ApplyRounding(Measurement);
		UnitStyleFormat unitStyleFormat = style.GetUnitStyleFormat();
		empty = (IsAngular ? (style.AngularUnit switch
		{
			AngularUnitFormat.DegreesMinutesSeconds => unitStyleFormat.ToDegreesMinutesSeconds(num), 
			AngularUnitFormat.Gradians => unitStyleFormat.ToGradians(num), 
			AngularUnitFormat.Radians => unitStyleFormat.ToRadians(num), 
			_ => unitStyleFormat.ToDecimal(num, isAngular: true), 
		}) : (style.LinearUnitFormat switch
		{
			LinearUnitFormat.Scientific => unitStyleFormat.ToScientific(num), 
			LinearUnitFormat.Engineering => unitStyleFormat.ToEngineering(num), 
			LinearUnitFormat.Architectural => unitStyleFormat.ToArchitectural(num), 
			LinearUnitFormat.Fractional => unitStyleFormat.ToFractional(num), 
			_ => unitStyleFormat.ToDecimal(num), 
		}));
		string empty2 = string.Empty;
		return Flags switch
		{
			DimensionType.Diameter => string.IsNullOrEmpty(style.Prefix) ? "Ø" : style.Prefix, 
			DimensionType.Radius => string.IsNullOrEmpty(style.Prefix) ? "R" : style.Prefix, 
			_ => string.IsNullOrEmpty(style.Prefix) ? string.Empty : style.Prefix, 
		} + empty + style.Suffix;
	}

	public DxfClassMap GetStyleOverrideMap()
	{
		if (!base.ExtendedData.TryGet("ACAD", out var value))
		{
			return null;
		}
		if (!(value.Records.FirstOrDefault() is ExtendedDataString extendedDataString) || extendedDataString.Value != "DSTYLE")
		{
			return null;
		}
		DxfClassMap dxfClassMap = DxfClassMap.Create<DimensionStyle>();
		DxfClassMap dxfClassMap2 = new DxfClassMap();
		dxfClassMap2.Name = extendedDataString.Value;
		ExtendedDataRecord[] array = value.Records.SkipWhile((ExtendedDataRecord c) => !(c is ExtendedDataControlString)).Skip(1).TakeWhile((ExtendedDataRecord c) => !(c is ExtendedDataControlString))
			.ToArray();
		if (array.Length % 2 != 0)
		{
			return null;
		}
		int num;
		for (num = 0; num < array.Length; num++)
		{
			ExtendedDataInteger16 extendedDataInteger = array[num] as ExtendedDataInteger16;
			num++;
			ExtendedDataRecord extendedDataRecord = array[num];
			DxfProperty dxfProperty = dxfClassMap.DxfProperties[extendedDataInteger.Value];
			dxfProperty.StoredValue = extendedDataRecord.RawValue;
			dxfClassMap2.DxfProperties.Add(extendedDataInteger.Value, dxfProperty);
		}
		return dxfClassMap2;
	}

	public void SetDimensionOverride(DimensionStyle styleOverride)
	{
		DxfClassMap dxfClassMap = DxfClassMap.Create<DimensionStyle>();
		dxfClassMap.DxfProperties.Remove(2);
		dxfClassMap.DxfProperties.Remove(70);
		DxfClassMap dxfClassMap2 = new DxfClassMap();
		foreach (KeyValuePair<int, DxfProperty> dxfProperty in dxfClassMap.DxfProperties)
		{
			object rawValue = dxfProperty.Value.GetRawValue(Style);
			object rawValue2 = dxfProperty.Value.GetRawValue(styleOverride);
			if (rawValue != null && rawValue2 != null && !rawValue.Equals(rawValue2))
			{
				dxfProperty.Value.StoredValue = rawValue2;
				dxfClassMap2.DxfProperties.Add(dxfProperty.Key, dxfProperty.Value);
			}
		}
		SetStyleOverrideMap(dxfClassMap2);
	}

	public void SetStyleOverrideMap(DxfClassMap map)
	{
		ExtendedData extendedData = base.ExtendedData.TryAdd("ACAD", new ExtendedData());
		extendedData.Records.Clear();
		extendedData.Records.Add(new ExtendedDataString("DSTYLE"));
		extendedData.Records.Add(new ExtendedDataControlString(isClosing: false));
		foreach (DxfProperty value in map.DxfProperties.Values)
		{
			extendedData.Records.AddRange(value.ToXDataRecords());
		}
		extendedData.Records.Add(new ExtendedDataControlString(isClosing: true));
	}

	public virtual void UpdateBlock()
	{
		createBlock();
	}

	internal override void AssignDocument(CadDocument doc)
	{
		base.AssignDocument(doc);
		_style = CadObject.updateCollection(Style, doc.DimensionStyles);
		_block = CadObject.updateCollection(Block, doc.BlockRecords);
		if (_block != null)
		{
			_block.Name = generateBlockName();
		}
		_block = CadObject.updateCollection(Block, base.Document.BlockRecords);
		doc.DimensionStyles.OnRemove += tableOnRemove;
		doc.BlockRecords.OnRemove += tableOnRemove;
	}

	internal override void UnassignDocument()
	{
		base.Document.DimensionStyles.OnRemove -= tableOnRemove;
		base.Document.BlockRecords.OnRemove -= tableOnRemove;
		base.UnassignDocument();
		Style = (DimensionStyle)(Style?.Clone());
		Block = (BlockRecord)(Block?.Clone());
	}

	protected static Entity dimensionLine(XYZ start, XYZ end, DimensionStyle style)
	{
		return new Line(start, end)
		{
			Color = style.DimensionLineColor,
			LineType = (style.LineType ?? LineType.ByLayer),
			LineWeight = style.DimensionLineWeight
		};
	}

	protected static Line extensionLine(XYZ start, XYZ end, DimensionStyle style, LineType linetype)
	{
		return new Line(start, end)
		{
			Color = style.ExtensionLineColor,
			LineType = (linetype ?? LineType.ByLayer),
			LineWeight = style.ExtensionLineWeight
		};
	}

	protected void angularBlock(double radius, XY centerRef, XY ref1, double minOffset, bool drawRef2)
	{
		double num = DefinitionPoint.DistanceFrom(TextMiddlePoint);
		XY xY = DefinitionPoint.Convert<XY>();
		double angle = centerRef.GetAngle(ref1);
		short num2;
		if (num >= radius && num <= radius + minOffset)
		{
			num = radius + minOffset;
			num2 = -1;
		}
		else if (!(num >= radius - minOffset) || !(num <= radius))
		{
			num2 = (short)((!(num > radius)) ? 1 : (-1));
		}
		else
		{
			num = radius - minOffset;
			num2 = 1;
		}
		XY xY2 = XY.Polar(centerRef, num - Style.DimensionLineGap * Style.ScaleFactor, angle);
		Layer defpoints = Layer.Defpoints;
		_block.Entities.Add(new Point(ref1.Convert<XYZ>())
		{
			Layer = defpoints
		});
		if (!Style.SuppressFirstDimensionLine && !Style.SuppressSecondDimensionLine)
		{
			if (num2 > 0)
			{
				_block.Entities.Add(dimensionRadialLine(xY2, ref1, angle, num2));
			}
			else
			{
				_block.Entities.Add(new Line(xY, ref1)
				{
					Color = Style.DimensionLineColor,
					LineType = (Style.LineType ?? LineType.ByLayer),
					LineWeight = Style.DimensionLineWeight
				});
				_block.Entities.Add(dimensionRadialLine(xY2, ref1, angle, num2));
				if (drawRef2)
				{
					XY start = XY.Polar(centerRef, radius + minOffset - Style.DimensionLineGap * Style.ScaleFactor, Math.PI + angle);
					_block.Entities.Add(dimensionRadialLine(start, xY, Math.PI + angle, num2));
				}
			}
		}
		if (!MathHelper.IsZero(Style.CenterMarkSize))
		{
			_block.Entities.AddRange(centerCross(centerRef.Convert<XYZ>(), radius, Style));
		}
		string measurementText = GetMeasurementText();
		double num3 = angle;
		short num4 = 1;
		if (num3 > Math.PI / 2.0 && num3 <= 4.71238898038469)
		{
			num3 += Math.PI;
			num4 = -1;
		}
		if (!IsTextUserDefinedLocation)
		{
			XY xY3 = XY.Polar(xY2, (double)(-num4 * num2) * Style.DimensionLineGap * Style.ScaleFactor, num3);
			TextMiddlePoint = xY3.Convert<XYZ>();
		}
		AttachmentPointType attachmentPoint = ((num4 * num2 < 0) ? AttachmentPointType.MiddleLeft : AttachmentPointType.MiddleRight);
		MText mText = createTextEntity(TextMiddlePoint, measurementText);
		mText.AttachmentPoint = attachmentPoint;
		_block.Entities.Add(mText);
	}

	protected List<Entity> centerCross(XYZ center, double radius, DimensionStyle style)
	{
		List<Entity> list = new List<Entity>();
		if (MathHelper.IsZero(style.CenterMarkSize))
		{
			return list;
		}
		double num = Math.Abs(style.CenterMarkSize * style.ScaleFactor);
		XYZ start = new XYZ(0.0, 0.0 - num, 0.0) + center;
		XYZ end = new XYZ(0.0, num, 0.0) + center;
		list.Add(new Line(start, end)
		{
			Color = style.ExtensionLineColor,
			LineWeight = style.ExtensionLineWeight
		});
		start = new XYZ(0.0 - num, 0.0, 0.0) + center;
		end = new XYZ(num, 0.0, 0.0) + center;
		list.Add(new Line(start, end)
		{
			Color = style.ExtensionLineColor,
			LineWeight = style.ExtensionLineWeight
		});
		if (style.CenterMarkSize < 0.0)
		{
			start = new XYZ(2.0 * num, 0.0, 0.0) + center;
			end = new XYZ(radius + num, 0.0, 0.0) + center;
			list.Add(new Line(start, end)
			{
				Color = style.ExtensionLineColor,
				LineWeight = style.ExtensionLineWeight
			});
			start = new XYZ(-2.0 * num, 0.0, 0.0) + center;
			end = new XYZ(0.0 - radius - num, 0.0, 0.0) + center;
			list.Add(new Line(start, end)
			{
				Color = style.ExtensionLineColor,
				LineWeight = style.ExtensionLineWeight
			});
			start = new XYZ(0.0, 2.0 * num, 0.0) + center;
			end = new XYZ(0.0, radius + num, 0.0) + center;
			list.Add(new Line(start, end)
			{
				Color = style.ExtensionLineColor,
				LineWeight = style.ExtensionLineWeight
			});
			start = new XYZ(0.0, -2.0 * num, 0.0) + center;
			end = new XYZ(0.0, 0.0 - radius - num, 0.0) + center;
			list.Add(new Line(start, end)
			{
				Color = style.ExtensionLineColor,
				LineWeight = style.ExtensionLineWeight
			});
		}
		return list;
	}

	protected void createBlock()
	{
		if (_block == null)
		{
			_block = new BlockRecord(generateBlockName());
			_block.IsAnonymous = true;
		}
		if (base.Document != null)
		{
			_block = CadObject.updateCollection(_block, base.Document.BlockRecords);
		}
		_block.Entities.Clear();
	}

	protected Point createDefinitionPoint(XYZ location)
	{
		return new Point(location)
		{
			Layer = Layer.Defpoints
		};
	}

	protected MText createTextEntity(XYZ insertPoint, string text)
	{
		return new MText
		{
			Value = text,
			AttachmentPoint = AttachmentPointType.MiddleCenter,
			InsertPoint = insertPoint,
			Height = Style.TextHeight
		};
	}

	protected Entity dimensionArrow(XYZ insertPoint, XYZ dir, DimensionStyle style, BlockRecord record)
	{
		double num = style.ArrowSize * style.ScaleFactor;
		double rotation = Math.Atan2(dir.Y, dir.X);
		if (record == null)
		{
			XYZ xYZ = XYZ.Cross(Normal, dir).Normalize();
			Solid obj = new Solid
			{
				FirstCorner = insertPoint,
				SecondCorner = insertPoint - num * dir - num / 6.0 * xYZ,
				ThirdCorner = insertPoint - num * dir + num / 6.0 * xYZ
			};
			obj.FourthCorner = obj.ThirdCorner;
			return obj;
		}
		return new Insert(record)
		{
			InsertPoint = insertPoint,
			Color = style.DimensionLineColor,
			XScale = num,
			YScale = num,
			ZScale = num,
			Rotation = rotation,
			LineWeight = style.DimensionLineWeight,
			Normal = Normal
		};
	}

	protected Line dimensionRadialLine(XY start, XY end, double rotation, short reversed)
	{
		DimensionStyle style = Style;
		double num = (0.0 - style.ArrowSize) * style.ScaleFactor;
		end = XY.Polar(end, (double)reversed * num, rotation);
		return new Line(start, end)
		{
			Color = style.DimensionLineColor,
			LineType = (style.LineType ?? LineType.ByLayer),
			LineWeight = style.DimensionLineWeight
		};
	}

	protected override void tableOnRemove(object sender, CollectionChangedEventArgs e)
	{
		base.tableOnRemove(sender, e);
		if (e.Item.Equals(Style))
		{
			Style = base.Document.DimensionStyles["Standard"];
		}
		if (e.Item.Equals(Block))
		{
			_block = null;
		}
	}

	private string generateBlockName()
	{
		return $"*D{base.Handle}";
	}
}
