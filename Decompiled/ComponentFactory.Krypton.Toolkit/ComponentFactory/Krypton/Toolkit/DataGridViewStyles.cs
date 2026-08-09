#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class DataGridViewStyles : Storage
{
	private KryptonDataGridView _dataGridView;

	private DataGridViewStyle _gridStyle;

	private GridStyle _columnStyle;

	private GridStyle _rowStyle;

	private GridStyle _dataCellStyle;

	private PaletteBackStyle _backgroundStyle;

	public override bool IsDefault => _gridStyle == DataGridViewStyle.List;

	[Category("Visuals")]
	[Description("Overall grid style.")]
	[RefreshProperties(RefreshProperties.All)]
	public DataGridViewStyle Style
	{
		get
		{
			return _gridStyle;
		}
		set
		{
			if (_gridStyle != value)
			{
				_gridStyle = value;
				switch (_gridStyle)
				{
				case DataGridViewStyle.List:
					_columnStyle = GridStyle.List;
					_rowStyle = GridStyle.List;
					_dataCellStyle = GridStyle.List;
					_backgroundStyle = PaletteBackStyle.GridBackgroundList;
					break;
				case DataGridViewStyle.Sheet:
					_columnStyle = GridStyle.Sheet;
					_rowStyle = GridStyle.Sheet;
					_dataCellStyle = GridStyle.Sheet;
					_backgroundStyle = PaletteBackStyle.GridBackgroundSheet;
					break;
				case DataGridViewStyle.Custom1:
					_columnStyle = GridStyle.Custom1;
					_rowStyle = GridStyle.Custom1;
					_dataCellStyle = GridStyle.Custom1;
					_backgroundStyle = PaletteBackStyle.GridBackgroundCustom1;
					break;
				}
				_dataGridView.SyncStyles();
				_dataGridView.PerformNeedPaint(needLayout: false);
			}
		}
	}

	[Category("Visuals")]
	[Description("Style of the header columns.")]
	[RefreshProperties(RefreshProperties.All)]
	public GridStyle StyleColumn
	{
		get
		{
			return _columnStyle;
		}
		set
		{
			if (_columnStyle == value)
			{
				return;
			}
			_columnStyle = value;
			_gridStyle = DataGridViewStyle.Mixed;
			switch (_columnStyle)
			{
			case GridStyle.List:
				if (_rowStyle == GridStyle.List && _dataCellStyle == GridStyle.List && _backgroundStyle == PaletteBackStyle.GridBackgroundList)
				{
					_gridStyle = DataGridViewStyle.List;
				}
				break;
			case GridStyle.Sheet:
				if (_rowStyle == GridStyle.Sheet && _dataCellStyle == GridStyle.Sheet && _backgroundStyle == PaletteBackStyle.GridBackgroundSheet)
				{
					_gridStyle = DataGridViewStyle.Sheet;
				}
				break;
			case GridStyle.Custom1:
				if (_rowStyle == GridStyle.Custom1 && _dataCellStyle == GridStyle.Custom1 && _backgroundStyle == PaletteBackStyle.GridBackgroundCustom1)
				{
					_gridStyle = DataGridViewStyle.Custom1;
				}
				break;
			}
			_dataGridView.SyncStyles();
			_dataGridView.PerformNeedPaint(needLayout: false);
		}
	}

	[Category("Visuals")]
	[Description("Style of the header rows.")]
	[RefreshProperties(RefreshProperties.All)]
	public GridStyle StyleRow
	{
		get
		{
			return _rowStyle;
		}
		set
		{
			if (_rowStyle == value)
			{
				return;
			}
			_rowStyle = value;
			_gridStyle = DataGridViewStyle.Mixed;
			switch (_columnStyle)
			{
			case GridStyle.List:
				if (_columnStyle == GridStyle.List && _dataCellStyle == GridStyle.List && _backgroundStyle == PaletteBackStyle.GridBackgroundList)
				{
					_gridStyle = DataGridViewStyle.List;
				}
				break;
			case GridStyle.Sheet:
				if (_columnStyle == GridStyle.Sheet && _dataCellStyle == GridStyle.Sheet && _backgroundStyle == PaletteBackStyle.GridBackgroundSheet)
				{
					_gridStyle = DataGridViewStyle.Sheet;
				}
				break;
			case GridStyle.Custom1:
				if (_columnStyle == GridStyle.Custom1 && _dataCellStyle == GridStyle.Custom1 && _backgroundStyle == PaletteBackStyle.GridBackgroundCustom1)
				{
					_gridStyle = DataGridViewStyle.Custom1;
				}
				break;
			}
			_dataGridView.SyncStyles();
			_dataGridView.PerformNeedPaint(needLayout: false);
		}
	}

	[Category("Visuals")]
	[Description("Style of the data cells.")]
	[RefreshProperties(RefreshProperties.All)]
	public GridStyle StyleDataCells
	{
		get
		{
			return _dataCellStyle;
		}
		set
		{
			if (_dataCellStyle == value)
			{
				return;
			}
			_dataCellStyle = value;
			_gridStyle = DataGridViewStyle.Mixed;
			switch (_columnStyle)
			{
			case GridStyle.List:
				if (_columnStyle == GridStyle.List && _rowStyle == GridStyle.List && _backgroundStyle == PaletteBackStyle.GridBackgroundList)
				{
					_gridStyle = DataGridViewStyle.List;
				}
				break;
			case GridStyle.Sheet:
				if (_columnStyle == GridStyle.Sheet && _rowStyle == GridStyle.Sheet && _backgroundStyle == PaletteBackStyle.GridBackgroundSheet)
				{
					_gridStyle = DataGridViewStyle.Sheet;
				}
				break;
			case GridStyle.Custom1:
				if (_columnStyle == GridStyle.Custom1 && _rowStyle == GridStyle.Custom1 && _backgroundStyle == PaletteBackStyle.GridBackgroundCustom1)
				{
					_gridStyle = DataGridViewStyle.Custom1;
				}
				break;
			}
			_dataGridView.SyncStyles();
			_dataGridView.PerformNeedPaint(needLayout: false);
		}
	}

	[Category("Visuals")]
	[Description("Style of the data cells.")]
	[RefreshProperties(RefreshProperties.All)]
	public PaletteBackStyle StyleBackground
	{
		get
		{
			return _backgroundStyle;
		}
		set
		{
			if (_backgroundStyle != value)
			{
				_backgroundStyle = value;
				_gridStyle = DataGridViewStyle.Mixed;
				if (_backgroundStyle == PaletteBackStyle.GridBackgroundList && _columnStyle == GridStyle.List && _rowStyle == GridStyle.List && _dataCellStyle == GridStyle.List)
				{
					_gridStyle = DataGridViewStyle.List;
				}
				else if (_backgroundStyle == PaletteBackStyle.GridBackgroundSheet && _columnStyle == GridStyle.Sheet && _rowStyle == GridStyle.Sheet && _dataCellStyle == GridStyle.Sheet)
				{
					_gridStyle = DataGridViewStyle.Sheet;
				}
				else if (_backgroundStyle == PaletteBackStyle.GridBackgroundCustom1 && _columnStyle == GridStyle.Custom1 && _rowStyle == GridStyle.Custom1 && _dataCellStyle == GridStyle.Custom1)
				{
					_gridStyle = DataGridViewStyle.Custom1;
				}
				_dataGridView.SyncStyles();
				_dataGridView.PerformNeedPaint(needLayout: false);
			}
		}
	}

	public DataGridViewStyles(KryptonDataGridView dataGridView)
	{
		Debug.Assert(dataGridView != null);
		_dataGridView = dataGridView;
		_gridStyle = DataGridViewStyle.List;
		_columnStyle = GridStyle.List;
		_rowStyle = GridStyle.List;
		_dataCellStyle = GridStyle.List;
		_backgroundStyle = PaletteBackStyle.GridBackgroundList;
	}

	private bool ShouldSerializeStyle()
	{
		return Style != DataGridViewStyle.List;
	}

	private void ResetStyle()
	{
		Style = DataGridViewStyle.List;
	}

	private bool ShouldSerializeStyleColumn()
	{
		return StyleColumn != GridStyle.List;
	}

	private void ResetStyleColumn()
	{
		StyleColumn = GridStyle.List;
	}

	private bool ShouldSerializeStyleRow()
	{
		return StyleRow != GridStyle.List;
	}

	private void ResetStyleRow()
	{
		StyleRow = GridStyle.List;
	}

	private bool ShouldSerializeStyleDataCells()
	{
		return StyleDataCells != GridStyle.List;
	}

	private void ResetStyleDataCells()
	{
		StyleDataCells = GridStyle.List;
	}

	private bool ShouldSerializeStyleBackground()
	{
		return StyleBackground != PaletteBackStyle.GridBackgroundList;
	}

	private void ResetStyleBackground()
	{
		StyleBackground = PaletteBackStyle.GridBackgroundList;
	}
}
