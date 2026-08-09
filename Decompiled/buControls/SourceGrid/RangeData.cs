using System;
using System.Text;
using System.Windows.Forms;
using SourceGrid.Cells;
using ns27;

namespace SourceGrid;

[Serializable]
public class RangeData
{
	public const string RANGEDATA_FORMAT = "SourceGrid.RangeData";

	[Obsolete]
	private Position mStartDragPosition;

	private Range mSourceRange;

	private object[,] mSourceValues;

	[NonSerialized]
	private GridVirtual mSourceGrid;

	[Obsolete]
	private CutMode mCutMode = CutMode.None;

	[NonSerialized]
	private DataObject dataObject_0 = null;

	public Range SourceRange => mSourceRange;

	public object[,] SourceValues => mSourceValues;

	[Obsolete]
	public Position StartDragPosition => mStartDragPosition;

	public GridVirtual SourceGrid => mSourceGrid;

	[Obsolete]
	public CutMode CutMode => mCutMode;

	static RangeData()
	{
		DataFormats.GetFormat("SourceGrid.RangeData");
	}

	public RangeData()
	{
	}

	public RangeData(GridVirtual mSourceGrid)
		: this()
	{
		this.mSourceGrid = mSourceGrid;
	}

	[Obsolete("Use LoadData method without startDragPosition")]
	public void LoadData(GridVirtual sourceGrid, Range sourceRange, Position startDragPosition, CutMode cutMode)
	{
		LoadData(sourceGrid, sourceRange, Position.Empty, cutMode);
	}

	public static RangeData LoadData(GridVirtual sourceGrid, Range sourceRange, CutMode cutMode)
	{
		RangeData rangeData = new RangeData(sourceGrid);
		rangeData.mSourceRange = sourceRange;
		rangeData.mSourceValues = new object[sourceRange.RowsCount, Class76.smethod_237(sourceRange, sourceGrid)];
		int num = 0;
		int num2 = sourceRange.Start.Row;
		while (num2 <= sourceRange.End.Row)
		{
			int num3 = 0;
			for (int i = sourceRange.Start.Column; i <= sourceRange.End.Column; i++)
			{
				if (sourceGrid.Columns.IsColumnVisible(i))
				{
					Position position = new Position(num2, i);
					ICellVirtual cell = sourceGrid.GetCell(position);
					CellContext cellContext = new CellContext(sourceGrid, position, cell);
					if (cell != null)
					{
						rangeData.mSourceValues[num, num3] = cellContext.Value;
					}
					num3++;
				}
			}
			num2++;
			num++;
		}
		if (cutMode == CutMode.CutImmediately)
		{
			sourceGrid?.ClearValues(new RangeRegion(sourceRange));
		}
		rangeData.dataObject_0 = new DataObject();
		rangeData.dataObject_0.SetData("SourceGrid.RangeData", rangeData);
		string[,] values = DataToStringArray(sourceGrid, rangeData.mSourceRange);
		rangeData.dataObject_0.SetData(typeof(string), StringArrayToString(values));
		return rangeData;
	}

	public void LoadData(string data)
	{
		mSourceGrid = null;
		StringToData(data, out mSourceRange, out mSourceValues);
		dataObject_0 = new DataObject();
		dataObject_0.SetData("SourceGrid.RangeData", this);
		dataObject_0.SetData(typeof(string), StringArrayToString(mSourceValues as string[,]));
	}

	public void WriteData(GridVirtual sourceGrid, Position destinationPosition)
	{
		int upperBound = SourceValues.GetUpperBound(0);
		int upperBound2 = SourceValues.GetUpperBound(1);
		int num = 0;
		for (int i = destinationPosition.Row; i <= destinationPosition.Row + upperBound; i++)
		{
			int num2 = 0;
			for (int j = destinationPosition.Column; j <= destinationPosition.Column + upperBound2; j++)
			{
				Position position = new Position(i, j);
				ICellVirtual cell = sourceGrid.GetCell(position);
				CellContext cellContext = new CellContext(sourceGrid, position, cell);
				if (cell != null && cell.Editor != null && mSourceValues[num, num2] != null)
				{
					cell.Editor.SetCellValue(cellContext, mSourceValues[num, num2]);
				}
				num2++;
			}
			num++;
		}
	}

	protected virtual void StringToData(string data, out Range range, out object[,] values)
	{
		data = data.Replace("\r\n", "\n");
		string[] array = data.Split('\n', '\r');
		int num = array.Length;
		if (num > 0 && (array[num - 1] == null || array[num - 1].Length == 0))
		{
			num--;
		}
		if (num != 0)
		{
			string[] array2 = array[0].Split('\t');
			int num2 = array2.Length;
			range = new Range(0, 0, num - 1, num2 - 1);
			object[,] array3 = new string[num, num2];
			values = array3;
			int num3 = 0;
			int num4 = range.Start.Row;
			while (num4 < range.Start.Row + num)
			{
				string text = array[num3];
				string[] array4 = text.Split('\t');
				int num5 = 0;
				int num6 = range.Start.Column;
				while (num6 <= range.End.Column)
				{
					if (num5 >= array4.Length)
					{
						values[num3, num5] = "";
					}
					else
					{
						values[num3, num5] = array4[num5];
					}
					num6++;
					num5++;
				}
				num4++;
				num3++;
			}
		}
		else
		{
			range = Range.Empty;
			object[,] array3 = new string[0, 0];
			values = array3;
		}
	}

	protected static string StringArrayToString(string[,] values)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int length = values.GetLength(0);
		int length2 = values.GetLength(1);
		for (int i = 0; i < length; i++)
		{
			for (int j = 0; j < length2; j++)
			{
				stringBuilder.Append(values[i, j]);
				if (j != length - 1)
				{
					stringBuilder.Append('\t');
				}
			}
			if (i != length - 1)
			{
				stringBuilder.Append("\r\n");
			}
		}
		return stringBuilder.ToString();
	}

	protected static string[,] DataToStringArray(GridVirtual sourceGrid, Range range)
	{
		int num = range.End.Row - range.Start.Row + 1;
		int num2 = range.End.Column - range.Start.Column + 1;
		string[,] array = new string[num, num2];
		int num3 = 0;
		int num4 = range.Start.Row;
		while (num4 <= range.End.Row)
		{
			int num5 = 0;
			int num6 = range.Start.Column;
			while (num6 <= range.End.Column)
			{
				Position position = new Position(num4, num6);
				ICellVirtual cell = sourceGrid.GetCell(position);
				CellContext cellContext = new CellContext(sourceGrid, position, cell);
				if (cell == null || cell.Editor == null || !cell.Editor.IsStringConversionSupported())
				{
					if (cell != null)
					{
						array[num3, num5] = cellContext.DisplayText;
					}
				}
				else
				{
					array[num3, num5] = cell.Editor.ValueToString(cell.Model.ValueModel.GetValue(cellContext));
				}
				num6++;
				num5++;
			}
			num4++;
			num3++;
		}
		return array;
	}

	[Obsolete("Completely not used. Will be removed in future versions")]
	public Range FindDestinationRange(GridVirtual destinationGrid, Position dropDestination)
	{
		if (!dropDestination.IsEmpty())
		{
			Position p_Position = new Position(dropDestination.Row + (mSourceRange.Start.Row - mStartDragPosition.Row), dropDestination.Column + (mSourceRange.Start.Column - mStartDragPosition.Column));
			p_Position = Position.Max(p_Position, new Position(0, 0));
			Range range = mSourceRange;
			range.MoveTo(p_Position);
			return range.Intersect(destinationGrid.CompleteRange);
		}
		return Range.Empty;
	}

	public static void ClipboardSetData(RangeData rangeData)
	{
		if (rangeData.dataObject_0 == null)
		{
			throw new SourceGridException("No data loaded, use the LoadData method");
		}
		Clipboard.SetDataObject(rangeData.dataObject_0);
	}

	public static RangeData ClipboardGetData()
	{
		IDataObject dataObject = Clipboard.GetDataObject();
		RangeData rangeData = null;
		if (dataObject.GetDataPresent("SourceGrid.RangeData"))
		{
			rangeData = (RangeData)dataObject.GetData("SourceGrid.RangeData");
		}
		if (rangeData == null && dataObject.GetDataPresent(DataFormats.UnicodeText, autoConvert: true))
		{
			string data = (string)dataObject.GetData(DataFormats.UnicodeText, autoConvert: true);
			rangeData = new RangeData();
			rangeData.LoadData(data);
		}
		return rangeData;
	}
}
