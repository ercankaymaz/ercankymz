using System;
using System.Collections.Generic;
using System.Linq;
using ACadSharp.Attributes;
using ACadSharp.Objects;
using ACadSharp.Tables;
using CSMath;

namespace ACadSharp.Entities;

[DxfName("ACAD_TABLE")]
[DxfSubClass("AcDbTable")]
public class TableEntity : Insert
{
	public enum BorderType : short
	{
		Single = 1,
		Double
	}

	internal class BreakData
	{
		internal struct BreakHeight
		{
			public XYZ Position { get; internal set; }

			public double Height { get; internal set; }
		}

		public BreakOptionFlags Flags { get; internal set; }

		public BreakFlowDirection FlowDirection { get; internal set; }

		public double BreakSpacing { get; internal set; }

		public List<BreakHeight> Heights { get; internal set; } = new List<BreakHeight>();
	}

	public enum BreakFlowDirection
	{
		Right = 1,
		Vertical = 2,
		Left = 4
	}

	[Flags]
	public enum BreakOptionFlags
	{
		None = 0,
		EnableBreaks = 1,
		RepeatTopLabels = 2,
		RepeatBottomLabels = 4,
		AllowManualPositions = 8,
		AllowManualHeights = 0x10
	}

	internal class BreakRowRange
	{
		public XYZ Position { get; internal set; }

		public int StartRowIndex { get; internal set; }

		public int EndRowIndex { get; internal set; }
	}

	public class Cell
	{
		[Flags]
		internal enum OverrideFlags
		{
			None = 0,
			CellAlignment = 1,
			BackgroundFillNone = 2,
			BackgroundColor = 4,
			ContentColor = 8,
			TextStyle = 0x10,
			TextHeight = 0x20,
			TopGridColor = 0x40,
			TopGridLineWeight = 0x400,
			TopVisibility = 0x4000,
			RightGridColor = 0x80,
			RightGridLineWeight = 0x800,
			RightVisibility = 0x8000,
			BottomGridColor = 0x100,
			BottomGridLineWeight = 0x1000,
			BottomVisibility = 0x10000,
			LeftGridColor = 0x200,
			LeftGridLineWeight = 0x2000,
			LeftVisibility = 0x20000
		}

		[Flags]
		public enum VirtualEdgeFlags
		{
			None = 0,
			Top = 1,
			Right = 2,
			Bottom = 4,
			Left = 8
		}

		public enum CellAlignment
		{
			None,
			TopLeft,
			TopCenter,
			TopRight,
			MiddleLeft,
			MiddleCenter,
			MiddleRight,
			BottomLeft,
			BottomCenter,
			BottomRight
		}

		[DxfCodeValue(new int[] { 174 })]
		public bool AutoFit { get; set; }

		[DxfCodeValue(new int[] { 176 })]
		public int BorderHeight { get; set; }

		[DxfCodeValue(new int[] { 175 })]
		public int BorderWidth { get; set; }

		public CellContent Content
		{
			get
			{
				if (Contents == null || HasMultipleContent)
				{
					return null;
				}
				return Contents.FirstOrDefault();
			}
		}

		public List<CellContent> Contents { get; } = new List<CellContent>();

		[DxfCodeValue(new int[] { 91 })]
		public int CustomData { get; set; }

		public List<CustomDataEntry> CustomDataCollection { get; set; } = new List<CustomDataEntry>();

		[DxfCodeValue(new int[] { 172 })]
		public short EdgeFlags { get; set; }

		public CellContentGeometry Geometry { get; set; }

		[DxfCodeValue(new int[] { 92 })]
		public bool HasLinkedData { get; set; }

		public bool HasMultipleContent
		{
			get
			{
				if (Contents == null)
				{
					return false;
				}
				return Contents.Count > 1;
			}
		}

		[DxfCodeValue(new int[] { 173 })]
		public short MergedValue { get; set; }

		[DxfCodeValue(new int[] { 145 })]
		public double Rotation { get; set; }

		[DxfCodeValue(new int[] { 144 })]
		public double BlockScale { get; set; }

		[DxfCodeValue(new int[] { 90 })]
		public TableCellStateFlags StateFlags { get; set; }

		public CellStyle StyleOverride { get; set; } = new CellStyle();

		[DxfCodeValue(new int[] { 300 })]
		public string ToolTip { get; set; }

		[DxfCodeValue(new int[] { 171 })]
		public CellType Type { get; set; }

		[DxfCodeValue(new int[] { 178 })]
		public short VirtualEdgeFlag { get; set; }
	}

	public class CellBorder
	{
		[DxfCodeValue(new int[] { 62 })]
		public Color Color { get; set; }

		[DxfCodeValue(new int[] { 40 })]
		public double DoubleLineSpacing { get; set; }

		[DxfCodeValue(new int[] { 95 })]
		public CellEdgeFlags EdgeFlags { get; }

		[DxfCodeValue(new int[] { 93 })]
		public bool IsInvisible { get; set; }

		[DxfCodeValue(new int[] { 92 })]
		public LineWeightType LineWeight { get; set; }

		[DxfCodeValue(new int[] { 90 })]
		public TableBorderPropertyFlags PropertyOverrideFlags { get; set; }

		[DxfCodeValue(new int[] { 91 })]
		public BorderType Type { get; set; }

		public CellBorder(CellEdgeFlags edgeFlags)
		{
			EdgeFlags = edgeFlags;
		}
	}

	public class CellContent
	{
		[DxfCodeValue(new int[] { 90 })]
		public TableCellContentType ContentType { get; set; }

		public ContentFormat Format { get; } = new ContentFormat();

		public CellValue Value { get; } = new CellValue();
	}

	public class CellContentGeometry
	{
		public XYZ DistanceTopLeft { get; set; }

		public XYZ DistanceCenter { get; set; }

		public double ContentWidth { get; set; }

		public double ContentHeight { get; set; }

		public double Width { get; set; }

		public double Height { get; set; }

		public int Flags { get; set; }
	}

	[Flags]
	public enum CellEdgeFlags
	{
		Unknown = 0,
		Top = 1,
		Right = 2,
		Bottom = 4,
		Left = 8,
		InsideVertical = 0x10,
		InsideHorizontal = 0x20
	}

	public class CellRange
	{
		[DxfCodeValue(new int[] { 93 })]
		public int BottomRowIndex { get; set; }

		[DxfCodeValue(new int[] { 92 })]
		public int LeftColumnIndex { get; set; }

		[DxfCodeValue(new int[] { 94 })]
		public int RightColumnIndex { get; set; }

		[DxfCodeValue(new int[] { 91 })]
		public int TopRowIndex { get; set; }
	}

	public class CellStyle : ContentFormat
	{
		[DxfCodeValue(new int[] { 63 })]
		public Color BackgroundColor { get; set; }

		[Obsolete("use oriented base borders")]
		public List<CellBorder> Borders { get; set; } = new List<CellBorder>();

		public CellBorder BottomBorder { get; set; } = new CellBorder(CellEdgeFlags.Bottom);

		public double BottomMargin { get; set; }

		[DxfCodeValue(new int[] { 64 })]
		public Color ContentColor { get; internal set; }

		public TableCellContentLayoutFlags ContentLayoutFlags { get; set; }

		public double HorizontalMargin { get; set; }

		[DxfCodeValue(new int[] { 283 })]
		public bool IsFillColorOn { get; set; }

		public CellBorder LeftBorder { get; set; } = new CellBorder(CellEdgeFlags.Left);

		public double MarginHorizontalSpacing { get; set; }

		[DxfCodeValue(new int[] { 171 })]
		public MarginFlags MarginOverrideFlags { get; set; }

		public double MarginVerticalSpacing { get; set; }

		public CellBorder RightBorder { get; set; } = new CellBorder(CellEdgeFlags.Right);

		public double RightMargin { get; set; }

		[DxfCodeValue(new int[] { 92 })]
		public TableCellStylePropertyFlags TableCellStylePropertyFlags { get; set; }

		public CellBorder TopBorder { get; set; } = new CellBorder(CellEdgeFlags.Right);

		[DxfCodeValue(new int[] { 90 })]
		public CellStyleTypeType Type { get; set; }

		public double VerticalMargin { get; set; }

		[DxfCodeValue(new int[] { 170 })]
		public Cell.CellAlignment CellAlignment { get; set; }
	}

	public enum CellStyleTypeType
	{
		Cell = 1,
		Row,
		Column,
		FormattedTableData,
		Table
	}

	public enum CellType
	{
		Text = 1,
		Block
	}

	public class CellValue
	{
		[DxfCodeValue(new int[] { 90 })]
		public CellValueType ValueType { get; set; }

		[DxfCodeValue(new int[] { 94 })]
		public ValueUnitType Units { get; set; }

		[DxfCodeValue(new int[] { 93 })]
		public int Flags { get; set; }

		public bool IsEmpty
		{
			get
			{
				return (Flags & 1) != 0;
			}
			set
			{
				if (value)
				{
					Flags |= 1;
				}
				else
				{
					Flags &= -2;
				}
			}
		}

		[DxfCodeValue(new int[] { 1 })]
		public string Text { get; set; }

		[DxfCodeValue(new int[] { 300 })]
		public string Format { get; set; }

		[DxfCodeValue(new int[] { 302 })]
		public string FormattedValue { get; set; }

		public object Value { get; set; }

		public override string ToString()
		{
			return Value.ToString();
		}
	}

	public enum CellValueType
	{
		Unknown = 0,
		Long = 1,
		Double = 2,
		String = 4,
		Date = 8,
		Point2D = 0x10,
		Point3D = 0x20,
		Handle = 0x40,
		Buffer = 0x80,
		ResultBuffer = 0x100,
		General = 0x200
	}

	public class Column
	{
		[DxfCodeValue(new int[] { 300 })]
		public string Name { get; set; }

		[DxfCodeValue(new int[] { 142 })]
		public double Width { get; set; }

		[DxfCodeValue(new int[] { 91 })]
		public int CustomData { get; set; }

		public CellStyle CellStyleOverride { get; set; } = new CellStyle();

		public List<CustomDataEntry> CustomDataCollection { get; internal set; }
	}

	public class ContentFormat
	{
		[DxfCodeValue(new int[] { 94 })]
		public int Alignment { get; set; }

		[DxfCodeValue(new int[] { 62 })]
		public Color Color { get; set; }

		[DxfCodeValue(new int[] { 170 })]
		public bool HasData { get; set; }

		[DxfCodeValue(new int[] { 90 })]
		public int PropertyFlags { get; set; }

		[DxfCodeValue(new int[] { 91 })]
		public TableCellStylePropertyFlags PropertyOverrideFlags { get; set; }

		[DxfCodeValue(DxfReferenceType.IsAngle, new int[] { 40 })]
		public double Rotation { get; set; }

		[DxfCodeValue(new int[] { 144 })]
		public double Scale { get; set; }

		[DxfCodeValue(new int[] { 140 })]
		public double TextHeight { get; set; }

		[DxfCodeValue(new int[] { 340 })]
		public TextStyle TextStyle { get; set; }

		[DxfCodeValue(new int[] { 92 })]
		public int ValueDataType { get; set; }

		[DxfCodeValue(new int[] { 300 })]
		public string ValueFormatString { get; set; }

		[DxfCodeValue(new int[] { 93 })]
		public int ValueUnitType { get; set; }
	}

	[Flags]
	internal enum BorderOverrideFlags
	{
		None = 0,
		TitleHorizontalTop = 1,
		TitleHorizontalInsert = 2,
		TitleHorizontalBottom = 4,
		TitleVerticalLeft = 8,
		TitleVerticalInsert = 0x10,
		TitleVerticalRight = 0x20,
		HeaderHorizontalTop = 0x40,
		HeaderHorizontalInsert = 0x80,
		HeaderHorizontalBottom = 0x100,
		HeaderVerticalLeft = 0x200,
		HeaderVerticalInsert = 0x400,
		HeaderVerticalRight = 0x800,
		DataHorizontalTop = 0x1000,
		DataHorizontalInsert = 0x2000,
		DataHorizontalBottom = 0x4000,
		DataVerticalLeft = 0x8000,
		DataVerticalInsert = 0x10000,
		DataVerticalRight = 0x20000
	}

	[Flags]
	internal enum TableOverrideFlags
	{
		None = 0,
		TitleSuppressed = 1,
		HeaderSuppressed = 2,
		FlowDirection = 4,
		HorizontalCellMargin = 8,
		VerticalCellMargin = 0x10,
		TitleRowColor = 0x20,
		HeaderRowColor = 0x40,
		DataRowColor = 0x80,
		TitleRowFillNone = 0x100,
		HeaderRowFillNone = 0x200,
		DataRowFillNone = 0x400,
		TitleRowFillColor = 0x800,
		HeaderRowFillColor = 0x1000,
		DataRowFillColor = 0x2000,
		TitleRowAlign = 0x4000,
		HeaderRowAlign = 0x8000,
		DataRowAlign = 0x10000,
		TitleTextStyle = 0x20000,
		HeaderTextStyle = 0x40000,
		DataTextStyle = 0x80000,
		TitleRowHeight = 0x100000,
		HeaderRowHeight = 0x200000,
		DataRowHeight = 0x400000
	}

	public class CustomDataEntry
	{
		public string Name { get; set; }

		public CellValue Value { get; set; } = new CellValue();
	}

	[Flags]
	public enum MarginFlags
	{
		None = 0,
		Override = 1
	}

	public class Row
	{
		[DxfCodeValue(new int[] { 141 })]
		public double Height { get; set; }

		[DxfCodeValue(new int[] { 90 })]
		public int CustomData { get; set; }

		public CellStyle CellStyleOverride { get; set; } = new CellStyle();

		public List<Cell> Cells { get; set; } = new List<Cell>();

		public List<CustomDataEntry> CustomDataCollection { get; internal set; }
	}

	public class TableAttribute
	{
		public string Value { get; set; }
	}

	[Flags]
	public enum TableBorderPropertyFlags
	{
		None = 0,
		BorderType = 1,
		LineWeight = 2,
		LineType = 4,
		Color = 8,
		Invisibility = 0x10,
		DoubleLineSpacing = 0x20,
		All = 0x3F
	}

	[Flags]
	public enum TableCellContentLayoutFlags
	{
		None = 0,
		Flow = 1,
		StackedHorizontal = 2,
		StackedVertical = 4
	}

	public enum TableCellContentType
	{
		Unknown = 0,
		Value = 1,
		Field = 2,
		Block = 4
	}

	[Flags]
	public enum TableCellStateFlags
	{
		None = 0,
		ContentLocked = 1,
		ContentReadOnly = 2,
		Linked = 4,
		ContentModifiedAfterUpdate = 8,
		FormatLocked = 0x10,
		FormatReadOnly = 0x20,
		FormatModifiedAfterUpdate = 0x40
	}

	[Flags]
	public enum TableCellStylePropertyFlags
	{
		None = 0,
		DataType = 1,
		DataFormat = 2,
		Rotation = 4,
		BlockScale = 8,
		Alignment = 0x10,
		ContentColor = 0x20,
		TextStyle = 0x40,
		TextHeight = 0x80,
		AutoScale = 0x100,
		BackgroundColor = 0x200,
		MarginLeft = 0x400,
		MarginTop = 0x800,
		MarginRight = 0x1000,
		MarginBottom = 0x2000,
		ContentLayout = 0x4000,
		MarginHorizontalSpacing = 0x20000,
		MarginVerticalSpacing = 0x40000,
		MergeAll = 0x8000,
		FlowDirectionBottomToTop = 0x10000
	}

	public enum ValueUnitType
	{
		NoUnits = 0,
		Distance = 1,
		Angle = 2,
		Area = 4,
		Volume = 8,
		Currency = 0x10,
		Percentage = 0x20
	}

	[DxfCodeValue(DxfReferenceType.Count, new int[] { 92 })]
	public List<Column> Columns => Content.Columns;

	[DxfCodeValue(new int[] { 11, 21, 31 })]
	public XYZ HorizontalDirection { get; set; }

	public override string ObjectName => "ACAD_TABLE";

	public override ObjectType ObjectType => ObjectType.UNLISTED;

	[DxfCodeValue(new int[] { 94 })]
	public bool OverrideBorderColor { get; set; }

	[DxfCodeValue(new int[] { 95 })]
	public bool OverrideBorderLineWeight { get; set; }

	[DxfCodeValue(new int[] { 96 })]
	public bool OverrideBorderVisibility { get; set; }

	[DxfCodeValue(new int[] { 93 })]
	public bool OverrideFlag { get; set; }

	[DxfCodeValue(DxfReferenceType.Count, new int[] { 91 })]
	public List<Row> Rows => Content.Rows;

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 342 })]
	public TableStyle Style
	{
		get
		{
			return Content.Style;
		}
		set
		{
			Content.Style = value;
		}
	}

	public override string SubclassMarker => "AcDbTable";

	[DxfCodeValue(new int[] { 90 })]
	public int ValueFlag { get; set; }

	[DxfCodeValue(new int[] { 280 })]
	public short Version { get; set; }

	internal List<BreakRowRange> BreakRowRanges { get; set; } = new List<BreakRowRange>();

	internal TableContent Content { get; set; } = new TableContent();

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 343 })]
	internal BlockRecord TableBlock => base.Block;

	internal BreakData TableBreakData { get; set; } = new BreakData();

	public override CadObject Clone()
	{
		return base.Clone();
	}

	public override BoundingBox GetBoundingBox()
	{
		return BoundingBox.Null;
	}

	public Cell GetCell(int row, int column)
	{
		return Rows[row].Cells[column];
	}
}
