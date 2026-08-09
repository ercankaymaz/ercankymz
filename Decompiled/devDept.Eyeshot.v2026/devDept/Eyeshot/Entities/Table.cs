using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class Table : PlanarEntity
{
	[Serializable]
	internal sealed class Cell : MultilineText
	{
		[CompilerGenerated]
		private bool _003CIsMerged_003Ek__BackingField;

		[CompilerGenerated]
		private bool _003CIsFirst_003Ek__BackingField;

		[CompilerGenerated]
		private CellRange _003CMergeRange_003Ek__BackingField;

		[CompilerGenerated]
		private Point3D[] _003CCorners_003Ek__BackingField;

		public Cell(Plane _0023_003DzUIfgjLQNTcHz, string _0023_003DzlUfsUzo_003D, double _0023_003Dzl0AL_pTiGR4i, double _0023_003Dzx0bH0r8MZhkE, double _0023_003Dzz8hUs7th6PvS, alignmentType _0023_003Dz1pzzCsQ_003D, int _0023_003DzZNiXTYE_003D = 0, int _0023_003Dzd760Yew_003D = 0)
			: base(_0023_003DzUIfgjLQNTcHz, _0023_003DzlUfsUzo_003D, _0023_003Dzl0AL_pTiGR4i, _0023_003Dzx0bH0r8MZhkE, _0023_003Dzz8hUs7th6PvS, _0023_003Dz1pzzCsQ_003D)
		{
			_0023_003DzkkRJVPID18Hg(new CellRange(_0023_003DzZNiXTYE_003D, _0023_003Dzd760Yew_003D, _0023_003DzZNiXTYE_003D, _0023_003Dzd760Yew_003D));
			_0023_003Dz0_00243eMyFvKd4i(_0023_003DzPzO_0024GUk_003D: false);
		}

		public Cell(Cell _0023_003DzySgeilxprQOK)
			: base(_0023_003DzySgeilxprQOK)
		{
			_0023_003DzkkRJVPID18Hg((CellRange)_0023_003DzySgeilxprQOK._0023_003DzbXJI0GPjxGEH().Clone());
			if (_0023_003DzySgeilxprQOK._0023_003DzC8Y1qQ5FpzJd())
			{
				_0023_003Dz0_00243eMyFvKd4i(_0023_003DzPzO_0024GUk_003D: true);
				_0023_003DzH5ErvWC1OAsG(_0023_003DzySgeilxprQOK._0023_003DznlWCcYBgPxFJ());
			}
		}

		internal Cell(TableSurrogate.CellSurrogate _0023_003DzVQ2AkJ15rwlojYwouA_003D_003D)
			: this(_0023_003DzVQ2AkJ15rwlojYwouA_003D_003D.Plane, _0023_003DzVQ2AkJ15rwlojYwouA_003D_003D.TextString, _0023_003DzVQ2AkJ15rwlojYwouA_003D_003D.RectWidth, _0023_003DzVQ2AkJ15rwlojYwouA_003D_003D.Height, _0023_003DzVQ2AkJ15rwlojYwouA_003D_003D.LineSpaceDistance, (alignmentType)_0023_003DzVQ2AkJ15rwlojYwouA_003D_003D.Alignment)
		{
		}

		protected Cell(SerializationInfo _0023_003Dz9lrNnXY_003D, StreamingContext _0023_003DzB8iS0QA_003D)
			: base(_0023_003Dz9lrNnXY_003D, _0023_003DzB8iS0QA_003D)
		{
			_0023_003DzL6_00248z_0024m2KgCWo_0024VSbg_003D_003D((Point3D[])_0023_003Dz9lrNnXY_003D.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302980900), typeof(Point3D[])));
			_0023_003DzH5ErvWC1OAsG(_0023_003Dz9lrNnXY_003D.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302980882)));
			_0023_003Dz0_00243eMyFvKd4i(_0023_003Dz9lrNnXY_003D.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302980896)));
			_0023_003DzkkRJVPID18Hg((CellRange)_0023_003Dz9lrNnXY_003D.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302980877), typeof(CellRange)));
		}

		public override object Clone()
		{
			return new Cell(this);
		}

		public override void Regen(RegenParams _0023_003DzELu0Pss_003D)
		{
			Point2D point2D = base.Plane.Project(_0023_003DzFR_UvI_P_8hJ());
			_0023_003DzL6_00248z_0024m2KgCWo_0024VSbg_003D_003D(new Point3D[4]);
			_0023_003DzX28tBzOYu835xbgMXQ_003D_003D()[0] = _0023_003DzFR_UvI_P_8hJ();
			_0023_003DzX28tBzOYu835xbgMXQ_003D_003D()[1] = base.Plane.PointAt(point2D.X + base.RectWidth, point2D.Y);
			_0023_003DzX28tBzOYu835xbgMXQ_003D_003D()[2] = base.Plane.PointAt(point2D.X + base.RectWidth, point2D.Y + base.RectHeight);
			_0023_003DzX28tBzOYu835xbgMXQ_003D_003D()[3] = base.Plane.PointAt(point2D.X, point2D.Y + base.RectHeight);
			if (!_0023_003DzELu0Pss_003D.SkipTexts)
			{
				base.Regen(_0023_003DzELu0Pss_003D);
			}
		}

		private protected override void _0023_003Dzl_SRSHmkyuNv(Transformation _0023_003DzLS0sR0pzioXc)
		{
			Entity._0023_003Dz2ZUdIVU25dQGGvXHgQ_003D_003D(_0023_003DzX28tBzOYu835xbgMXQ_003D_003D(), _0023_003DzLS0sR0pzioXc);
			base._0023_003Dzl_SRSHmkyuNv(_0023_003DzLS0sR0pzioXc);
		}

		public bool _0023_003DzC8Y1qQ5FpzJd()
		{
			return _003CIsMerged_003Ek__BackingField;
		}

		internal void _0023_003Dz0_00243eMyFvKd4i(bool _0023_003DzPzO_0024GUk_003D)
		{
			_003CIsMerged_003Ek__BackingField = _0023_003DzPzO_0024GUk_003D;
		}

		public bool _0023_003DznlWCcYBgPxFJ()
		{
			return _003CIsFirst_003Ek__BackingField;
		}

		public void _0023_003DzH5ErvWC1OAsG(bool _0023_003DzPzO_0024GUk_003D)
		{
			_003CIsFirst_003Ek__BackingField = _0023_003DzPzO_0024GUk_003D;
		}

		public CellRange _0023_003DzbXJI0GPjxGEH()
		{
			return _003CMergeRange_003Ek__BackingField;
		}

		internal void _0023_003DzkkRJVPID18Hg(CellRange _0023_003DzPzO_0024GUk_003D)
		{
			_003CMergeRange_003Ek__BackingField = _0023_003DzPzO_0024GUk_003D;
		}

		public Point3D[] _0023_003DzX28tBzOYu835xbgMXQ_003D_003D()
		{
			return _003CCorners_003Ek__BackingField;
		}

		internal void _0023_003DzL6_00248z_0024m2KgCWo_0024VSbg_003D_003D(Point3D[] _0023_003DzPzO_0024GUk_003D)
		{
			_003CCorners_003Ek__BackingField = _0023_003DzPzO_0024GUk_003D;
		}

		public Point3D _0023_003DzE4mfvVc_003D()
		{
			return _0023_003DzFR_UvI_P_8hJ() + base.Plane.AxisX * base.RectWidth / 2.0 + base.Plane.AxisY * base.RectHeight / 2.0;
		}

		public void _0023_003DzgLmLM40_003D(CellRange _0023_003DzpA_0024IBV1HV8de, bool _0023_003DzPQ307aw_003D, double _0023_003DzEbcms_0024dw4Prt, double _0023_003DzM_eLFbJnknLs, flowDirection _0023_003Dz2_PvN3_ZV7va)
		{
			_0023_003Dz0_00243eMyFvKd4i(_0023_003DzPzO_0024GUk_003D: true);
			_0023_003DzkkRJVPID18Hg(_0023_003DzpA_0024IBV1HV8de);
			if (_0023_003DzPQ307aw_003D)
			{
				_0023_003DzH5ErvWC1OAsG(_0023_003DzPzO_0024GUk_003D: true);
				alignmentType alignmentType = alignment;
				if (_0023_003Dz2_PvN3_ZV7va == flowDirection.Down)
				{
					Alignment = alignmentType.TopLeft;
				}
				else
				{
					Alignment = alignmentType.BottomLeft;
				}
				base.RectWidth = _0023_003DzEbcms_0024dw4Prt;
				base.RectHeight = _0023_003DzM_eLFbJnknLs;
				Alignment = alignmentType;
			}
			else
			{
				_0023_003DzH5ErvWC1OAsG(_0023_003DzPzO_0024GUk_003D: false);
			}
		}

		[SpecialName]
		internal override bool _0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D()
		{
			if (base._0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D())
			{
				return _0023_003DzX28tBzOYu835xbgMXQ_003D_003D() != null;
			}
			return false;
		}

		public override EntitySurrogate ConvertToSurrogate()
		{
			return new TableSurrogate.CellSurrogate(this);
		}

		public override void GetObjectData(SerializationInfo _0023_003Dz9lrNnXY_003D, StreamingContext _0023_003DzB8iS0QA_003D)
		{
			base.GetObjectData(_0023_003Dz9lrNnXY_003D, _0023_003DzB8iS0QA_003D);
			_0023_003Dz9lrNnXY_003D.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302980900), _0023_003DzX28tBzOYu835xbgMXQ_003D_003D());
			_0023_003Dz9lrNnXY_003D.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302980882), _0023_003DznlWCcYBgPxFJ());
			_0023_003Dz9lrNnXY_003D.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302980896), _0023_003DzC8Y1qQ5FpzJd());
			_0023_003Dz9lrNnXY_003D.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302980877), _0023_003DzbXJI0GPjxGEH());
		}
	}

	[Serializable]
	internal sealed class CellRange : ISerializable, ICloneable
	{
		[CompilerGenerated]
		private int _003CMinRow_003Ek__BackingField;

		[CompilerGenerated]
		private int _003CMaxRow_003Ek__BackingField;

		[CompilerGenerated]
		private int _003CMinColumn_003Ek__BackingField;

		[CompilerGenerated]
		private int _003CMaxColumn_003Ek__BackingField;

		public CellRange(int _0023_003Dzq2ZkT9c_003D, int _0023_003DzxVepeqpLZ_00248c, int _0023_003DzdhbEPio_003D, int _0023_003DzkiL0CHujGy4c)
		{
			_0023_003Dz7q5QA8S5Iy3X(_0023_003Dzq2ZkT9c_003D);
			_0023_003DzfOmiWCqPfSSh(_0023_003DzxVepeqpLZ_00248c);
			_0023_003Dz9nzrvAMf95wi(_0023_003DzdhbEPio_003D);
			_0023_003DzVZEm9K2erksg(_0023_003DzkiL0CHujGy4c);
		}

		public CellRange(CellRange _0023_003DzySgeilxprQOK)
		{
			_0023_003Dz7q5QA8S5Iy3X(_0023_003DzySgeilxprQOK._0023_003DzOhnJ5sVkuMJp());
			_0023_003Dz9nzrvAMf95wi(_0023_003DzySgeilxprQOK._0023_003DzdIEC8nhYbOLX());
			_0023_003DzfOmiWCqPfSSh(_0023_003DzySgeilxprQOK._0023_003Dzuoqcx_Pl_iTG());
			_0023_003DzVZEm9K2erksg(_0023_003DzySgeilxprQOK._0023_003DzIQKzEF3iEvEG());
		}

		protected CellRange(SerializationInfo _0023_003Dz9lrNnXY_003D, StreamingContext _0023_003DzB8iS0QA_003D)
		{
			_0023_003Dz7q5QA8S5Iy3X(_0023_003Dz9lrNnXY_003D.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981120)));
			_0023_003Dz9nzrvAMf95wi(_0023_003Dz9lrNnXY_003D.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981099)));
			_0023_003DzfOmiWCqPfSSh(_0023_003Dz9lrNnXY_003D.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981082)));
			_0023_003DzVZEm9K2erksg(_0023_003Dz9lrNnXY_003D.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981066)));
		}

		public int _0023_003DzOhnJ5sVkuMJp()
		{
			return _003CMinRow_003Ek__BackingField;
		}

		public void _0023_003Dz7q5QA8S5Iy3X(int _0023_003DzPzO_0024GUk_003D)
		{
			_003CMinRow_003Ek__BackingField = _0023_003DzPzO_0024GUk_003D;
		}

		public int _0023_003DzdIEC8nhYbOLX()
		{
			return _003CMaxRow_003Ek__BackingField;
		}

		public void _0023_003Dz9nzrvAMf95wi(int _0023_003DzPzO_0024GUk_003D)
		{
			_003CMaxRow_003Ek__BackingField = _0023_003DzPzO_0024GUk_003D;
		}

		public int _0023_003Dzuoqcx_Pl_iTG()
		{
			return _003CMinColumn_003Ek__BackingField;
		}

		public void _0023_003DzfOmiWCqPfSSh(int _0023_003DzPzO_0024GUk_003D)
		{
			_003CMinColumn_003Ek__BackingField = _0023_003DzPzO_0024GUk_003D;
		}

		public int _0023_003DzIQKzEF3iEvEG()
		{
			return _003CMaxColumn_003Ek__BackingField;
		}

		public void _0023_003DzVZEm9K2erksg(int _0023_003DzPzO_0024GUk_003D)
		{
			_003CMaxColumn_003Ek__BackingField = _0023_003DzPzO_0024GUk_003D;
		}

		public bool _0023_003DzHRi2oS0_003D(int _0023_003Dzq2ZkT9c_003D, int _0023_003DzxVepeqpLZ_00248c, int _0023_003DzdhbEPio_003D, int _0023_003DzkiL0CHujGy4c)
		{
			if (_0023_003DzOhnJ5sVkuMJp() < _0023_003Dzq2ZkT9c_003D || _0023_003Dzuoqcx_Pl_iTG() < _0023_003DzxVepeqpLZ_00248c || _0023_003DzdIEC8nhYbOLX() > _0023_003DzdhbEPio_003D || _0023_003DzIQKzEF3iEvEG() > _0023_003DzkiL0CHujGy4c)
			{
				return false;
			}
			return true;
		}

		public object Clone()
		{
			return new CellRange(this);
		}

		public virtual TableSurrogate.CellRangeSurrogate _0023_003Dz_0024xHo97pGU7zE()
		{
			return new TableSurrogate.CellRangeSurrogate(this);
		}

		public void GetObjectData(SerializationInfo _0023_003Dz9lrNnXY_003D, StreamingContext _0023_003DzB8iS0QA_003D)
		{
			_0023_003Dz9lrNnXY_003D.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981120), _0023_003DzOhnJ5sVkuMJp());
			_0023_003Dz9lrNnXY_003D.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981099), _0023_003DzdIEC8nhYbOLX());
			_0023_003Dz9lrNnXY_003D.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981082), _0023_003Dzuoqcx_Pl_iTG());
			_0023_003Dz9lrNnXY_003D.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981066), _0023_003DzIQKzEF3iEvEG());
		}
	}

	public enum flowDirection
	{
		Down,
		Up
	}

	internal Cell[,] cells;

	public int RowsNum { get; }

	public int ColumnsNum { get; }

	public double[] RowsHeights { get; }

	public double[] ColumnsWidths { get; }

	public flowDirection Direction { get; }

	public double Width { get; }

	public double Height { get; }

	public double HorCellMargin { get; set; }

	public double VerCellMargin { get; set; }

	public Table(DataTable data, Plane tablePlane, double[] rowsHeights, double[] columnsWidths, double textHeight, flowDirection direction = flowDirection.Down)
		: this(tablePlane, data.Rows.Count, data.Columns.Count, rowsHeights, columnsWidths, textHeight, direction)
	{
		for (int i = 0; i < data.Rows.Count; i++)
		{
			DataRow dataRow = data.Rows[i];
			for (int j = 0; j < data.Columns.Count; j++)
			{
				SetAlignment(i, j, Text.alignmentType.MiddleCenter);
				SetTextString(i, j, dataRow[j].ToString());
			}
		}
	}

	public Table(Plane tablePlane, int rows, int columns, double rowsHeight, double columnsWidth, double textHeight, flowDirection direction = flowDirection.Down)
		: base(tablePlane)
	{
		RowsHeights = new double[rows];
		for (int i = 0; i < rows; i++)
		{
			RowsHeights[i] = rowsHeight;
		}
		ColumnsWidths = new double[columns];
		for (int j = 0; j < columns; j++)
		{
			ColumnsWidths[j] = columnsWidth;
		}
		_0023_003Dzuiqqh1Y_003D(rows, columns, textHeight, direction);
	}

	public Table(Plane tablePlane, int rows, int columns, double[] rowsHeights, double[] columnsWidths, double textHeight, flowDirection direction = flowDirection.Down)
		: base(tablePlane)
	{
		RowsHeights = rowsHeights;
		ColumnsWidths = columnsWidths;
		_0023_003Dzuiqqh1Y_003D(rows, columns, textHeight, direction);
	}

	protected Table(Table another)
		: base(another)
	{
		_0023_003Dz_vPvdgIHTxA_0024(another.RowsNum);
		_0023_003DzgHzweWF8RqF4(another.ColumnsNum);
		RowsHeights = new double[RowsNum];
		Array.Copy(another.RowsHeights, RowsHeights, RowsNum);
		ColumnsWidths = new double[ColumnsNum];
		Array.Copy(another.ColumnsWidths, ColumnsWidths, ColumnsNum);
		_0023_003DziH5fis1NuTLs(another.Direction);
		HorCellMargin = another.HorCellMargin;
		VerCellMargin = another.VerCellMargin;
		cells = new Cell[RowsNum, ColumnsNum];
		for (int i = 0; i < RowsNum; i++)
		{
			for (int j = 0; j < ColumnsNum; j++)
			{
				cells[i, j] = (Cell)another.cells[i, j].Clone();
			}
		}
	}

	protected internal Table(TableSurrogate surrogate)
		: this(surrogate._0023_003DzNY5YUv279_SW(), surrogate.RowsNum, surrogate.ColumnsNum, surrogate.RowsHeights, surrogate.ColumnsWidths, 1.0, surrogate.Direction)
	{
	}

	protected Table(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_0023_003Dz_vPvdgIHTxA_0024(info.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981050)));
		_0023_003DzgHzweWF8RqF4(info.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981032)));
		RowsHeights = (double[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981015), typeof(double[]));
		ColumnsWidths = (double[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981001), typeof(double[]));
		_0023_003DziH5fis1NuTLs((flowDirection)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953730), typeof(flowDirection)));
		HorCellMargin = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302980733));
		VerCellMargin = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302980689));
		_0023_003DzUBcyrssJEGAK(info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974266)));
		_0023_003DzBEcDMzq6J80l(info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974246)));
		cells = (Cell[,])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302980677), typeof(Cell[,]));
	}

	private void _0023_003Dzuiqqh1Y_003D(int _0023_003DzO_0024xvpvo_003D, int _0023_003DzRwzUIoU_003D, double _0023_003Dzx0bH0r8MZhkE, flowDirection _0023_003Dz6u3psoE_003D)
	{
		_0023_003Dz_vPvdgIHTxA_0024(_0023_003DzO_0024xvpvo_003D);
		_0023_003DzgHzweWF8RqF4(_0023_003DzRwzUIoU_003D);
		_0023_003DziH5fis1NuTLs(_0023_003Dz6u3psoE_003D);
		_0023_003DzHA4kMgqiUKyU(_0023_003Dzx0bH0r8MZhkE);
	}

	private void _0023_003DzHA4kMgqiUKyU(double _0023_003Dzx0bH0r8MZhkE)
	{
		double num = 0.0;
		double num2 = 0.0;
		int num3 = ((Direction != flowDirection.Down) ? 1 : (-1));
		Text.alignmentType _0023_003Dz1pzzCsQ_003D = ((Direction == flowDirection.Down) ? Text.alignmentType.TopLeft : Text.alignmentType.BottomLeft);
		cells = new Cell[RowsNum, ColumnsNum];
		for (int i = 0; i < RowsNum; i++)
		{
			for (int j = 0; j < ColumnsNum; j++)
			{
				Plane obj = (Plane)base.Plane.Clone();
				obj.Origin = obj.PointAt(num, (double)num3 * num2);
				string empty = string.Empty;
				Cell cell = new Cell(obj, empty, ColumnsWidths[j], _0023_003Dzx0bH0r8MZhkE, _0023_003Dzx0bH0r8MZhkE * 5.0 / 3.0, _0023_003Dz1pzzCsQ_003D, i, j);
				cell.RectHeight = RowsHeights[i];
				cell.Alignment = Text.alignmentType.MiddleCenter;
				cells[i, j] = cell;
				num += ColumnsWidths[j];
			}
			num = 0.0;
			num2 += RowsHeights[i];
		}
	}

	internal Translation _0023_003DzcqTF_00244zbp5OK(Text.alignmentType _0023_003Dz1pzzCsQ_003D, Plane _0023_003Dzrgqz890sj_0024X9)
	{
		double y;
		double x;
		switch (_0023_003Dz1pzzCsQ_003D)
		{
		case Text.alignmentType.BottomLeft:
			y = VerCellMargin;
			x = HorCellMargin;
			break;
		case Text.alignmentType.BottomCenter:
			y = VerCellMargin;
			x = 0.0;
			break;
		case Text.alignmentType.BottomRight:
			y = VerCellMargin;
			x = 0.0 - HorCellMargin;
			break;
		case Text.alignmentType.MiddleLeft:
			y = 0.0;
			x = HorCellMargin;
			break;
		case Text.alignmentType.MiddleCenter:
			y = 0.0;
			x = 0.0;
			break;
		case Text.alignmentType.MiddleRight:
			y = 0.0;
			x = 0.0 - HorCellMargin;
			break;
		case Text.alignmentType.TopLeft:
			y = 0.0 - VerCellMargin;
			x = HorCellMargin;
			break;
		case Text.alignmentType.TopCenter:
			y = 0.0 - VerCellMargin;
			x = 0.0;
			break;
		case Text.alignmentType.TopRight:
			y = 0.0 - VerCellMargin;
			x = 0.0 - HorCellMargin;
			break;
		default:
			x = (y = 0.0);
			break;
		}
		Vector3D vector3D = new Vector3D(x, y, 0.0);
		Align3D xform = new Align3D(Plane.XY, _0023_003Dzrgqz890sj_0024X9);
		vector3D.TransformBy(xform);
		return new Translation(vector3D);
	}

	private void _0023_003Dz_vPvdgIHTxA_0024(int _0023_003DzPzO_0024GUk_003D)
	{
		RowsNum = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003DzgHzweWF8RqF4(int _0023_003DzPzO_0024GUk_003D)
	{
		ColumnsNum = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003DziH5fis1NuTLs(flowDirection _0023_003DzPzO_0024GUk_003D)
	{
		Direction = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003DzUBcyrssJEGAK(double _0023_003DzPzO_0024GUk_003D)
	{
		Width = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003DzBEcDMzq6J80l(double _0023_003DzPzO_0024GUk_003D)
	{
		Height = _0023_003DzPzO_0024GUk_003D;
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new TableSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981050), RowsNum);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981032), ColumnsNum);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981015), RowsHeights);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981001), ColumnsWidths);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953730), Direction);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302980733), HorCellMargin);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302980689), VerCellMargin);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974266), Width);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974246), Height);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302980677), cells);
	}

	public override void Regen(RegenParams data)
	{
		if (!data.SkipTexts)
		{
			_0023_003DzAJ2wgzdeSgYt(data);
			RegenMode = regenType.CompileOnly;
		}
	}

	private void _0023_003DzAJ2wgzdeSgYt(RegenParams _0023_003DzELu0Pss_003D)
	{
		_0023_003DzUBcyrssJEGAK(0.0);
		double[] columnsWidths = ColumnsWidths;
		foreach (double num in columnsWidths)
		{
			_0023_003DzUBcyrssJEGAK(Width + num);
		}
		_0023_003DzBEcDMzq6J80l(0.0);
		columnsWidths = RowsHeights;
		foreach (double num2 in columnsWidths)
		{
			_0023_003DzBEcDMzq6J80l(Height + num2);
		}
		int num3 = ((Direction != flowDirection.Down) ? 1 : (-1));
		List<Point3D> list = new List<Point3D>();
		list.Add(new Point3D(0.0, 0.0, 0.0));
		list.Add(new Point3D(Width, 0.0, 0.0));
		list.Add(new Point3D(Width, (double)num3 * Height, 0.0));
		list.Add(new Point3D(0.0, (double)num3 * Height, 0.0));
		Transformation transformation = new Transformation(base.Plane.Origin, base.Plane.AxisX, base.Plane.AxisY, base.Plane.AxisZ);
		for (int j = 0; j < list.Count; j++)
		{
			list[j] = transformation * list[j];
		}
		for (int k = 0; k < RowsNum; k++)
		{
			for (int l = 0; l < ColumnsNum; l++)
			{
				Cell cell = cells[k, l];
				if (cell.RegenMode == regenType.RegenAndCompile)
				{
					cell.Regen(_0023_003DzELu0Pss_003D);
				}
			}
		}
		_vertices = list.ToArray();
		UpdateBoundingBox(_0023_003DzELu0Pss_003D);
	}

	public override void Regen(double deviation)
	{
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302980657));
	}

	public override void Compile(CompileParams data)
	{
		InitGraphicsData(data.RenderContext);
		for (int i = 0; i < RowsNum; i++)
		{
			for (int j = 0; j < ColumnsNum; j++)
			{
				Cell cell = cells[i, j];
				if (cell.RegenMode == regenType.CompileOnly)
				{
					cell.Compile(data);
				}
			}
		}
		RegenMode = regenType.NotNeeded;
	}

	public override Mesh ExtrudeAsMesh(double amount, double deviation, Mesh.natureType meshNature)
	{
		throw new NotImplementedException(string.Empty);
	}

	public override Surface ExtrudeAsSurface(double amount)
	{
		throw new NotImplementedException(string.Empty);
	}

	protected internal override void Draw(DrawParams data)
	{
		List<Cell> list = _0023_003DzcsMyxaYdPFqT();
		Point3D[] vertices = _0023_003DzAqQbug4_003D(list);
		RenderContextBase renderContext = data.RenderContext;
		renderContext.DrawLines(vertices);
		renderContext.EndDrawBufferedLines();
		ShaderParameters _0023_003Dzl_0024MIsC0_003D = data.ShaderParams.Clone();
		foreach (Cell item in list)
		{
			renderContext.PushModelView();
			renderContext.MultMatrixModelView(_0023_003DzcqTF_00244zbp5OK(item.Alignment, item.Plane));
			data.ShaderParams.PrepareForWireframe();
			data.ShaderParams.PrimitiveType = item.GetPrimitiveTypeForWireframe(data);
			item.SetShader(data);
			item.Draw(data);
			renderContext.PopModelView();
		}
		data.ShaderParams._0023_003Dzx7w5iaoKWbUL(_0023_003Dzl_0024MIsC0_003D);
	}

	private List<Cell> _0023_003DzcsMyxaYdPFqT()
	{
		List<Cell> list = new List<Cell>(cells.Length);
		for (int i = 0; i < RowsNum; i++)
		{
			for (int j = 0; j < ColumnsNum; j++)
			{
				Cell cell = cells[i, j];
				if (!cell._0023_003DzC8Y1qQ5FpzJd() || cell._0023_003DznlWCcYBgPxFJ())
				{
					list.Add(cell);
				}
			}
		}
		return list;
	}

	private Point3D[] _0023_003DzAqQbug4_003D(IList<Cell> _0023_003DznKwOAQk_003D)
	{
		List<Point3D> list = new List<Point3D>(_0023_003DznKwOAQk_003D.Count * 4);
		foreach (Cell item in _0023_003DznKwOAQk_003D)
		{
			CellRange cellRange = item._0023_003DzbXJI0GPjxGEH();
			list.AddRange(new Point3D[2]
			{
				item._0023_003DzX28tBzOYu835xbgMXQ_003D_003D()[0],
				item._0023_003DzX28tBzOYu835xbgMXQ_003D_003D()[3]
			});
			list.AddRange(new Point3D[2]
			{
				item._0023_003DzX28tBzOYu835xbgMXQ_003D_003D()[3],
				item._0023_003DzX28tBzOYu835xbgMXQ_003D_003D()[2]
			});
			if ((Direction == flowDirection.Up && cellRange._0023_003DzOhnJ5sVkuMJp() == 0) || (Direction == flowDirection.Down && cellRange._0023_003DzdIEC8nhYbOLX() == RowsNum - 1))
			{
				list.AddRange(new Point3D[2]
				{
					item._0023_003DzX28tBzOYu835xbgMXQ_003D_003D()[0],
					item._0023_003DzX28tBzOYu835xbgMXQ_003D_003D()[1]
				});
			}
			if (cellRange._0023_003DzIQKzEF3iEvEG() == ColumnsNum - 1)
			{
				list.AddRange(new Point3D[2]
				{
					item._0023_003DzX28tBzOYu835xbgMXQ_003D_003D()[1],
					item._0023_003DzX28tBzOYu835xbgMXQ_003D_003D()[2]
				});
			}
		}
		return list.ToArray();
	}

	protected override void DrawEntity(RenderContextBase context, object myParams)
	{
	}

	protected internal override void DrawForSelection(DrawForSelectionParams data)
	{
		Draw(data);
	}

	protected internal override bool ThroughTriangle(FrustumParams data)
	{
		if (Entity.ThroughTriangleQuad(data, _vertices))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool ThroughTriangleScreenPolygon(ScreenPolygonParams data)
	{
		if (Entity.ThroughTriangleScreenPolygonQuad(_vertices, data))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	public override void TransformBy(Transformation xform)
	{
		if (xform.HasScaling)
		{
			RegenMode = regenType.RegenAndCompile;
			double scaleFactor = xform.ScaleFactorX;
			if (xform.EqualScaleFactors() || xform.IsScaleFactorUniformForPlanar(base.Plane, ref scaleFactor))
			{
				for (int i = 0; i < ColumnsNum; i++)
				{
					ColumnsWidths[i] *= scaleFactor;
				}
				for (int j = 0; j < RowsNum; j++)
				{
					RowsHeights[j] *= scaleFactor;
				}
				_0023_003DzUBcyrssJEGAK(Width * scaleFactor);
				_0023_003DzBEcDMzq6J80l(Height * scaleFactor);
			}
		}
		Cell[,] array = cells;
		int upperBound = array.GetUpperBound(0);
		int upperBound2 = array.GetUpperBound(1);
		for (int k = array.GetLowerBound(0); k <= upperBound; k++)
		{
			for (int l = array.GetLowerBound(1); l <= upperBound2; l++)
			{
				array[k, l].TransformBy(xform);
			}
		}
		base.TransformBy(xform);
	}

	public override object Clone()
	{
		return new Table(this);
	}

	public override object CloneWithTessellation()
	{
		return Clone();
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnitsType.Unitless, massUnitsType.Unitless, (LayerKeyedCollection)null, (MaterialKeyedCollection)null, (BlockKeyedCollection)null));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974008) + Width);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973989) + Height);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971844) + Direction);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302980845) + RowsNum);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302980832) + ColumnsNum);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302980788) + HorCellMargin);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302980777) + VerCellMargin);
		return stringBuilder.ToString();
	}

	public override void Dispose()
	{
		base.Dispose();
		RegenMode = regenType.RegenAndCompile;
		Cell[,] array = cells;
		int upperBound = array.GetUpperBound(0);
		int upperBound2 = array.GetUpperBound(1);
		for (int i = array.GetLowerBound(0); i <= upperBound; i++)
		{
			for (int j = array.GetLowerBound(1); j <= upperBound2; j++)
			{
				array[i, j].Dispose();
			}
		}
	}

	public Entity[] Explode()
	{
		if (Vertices == null)
		{
			_0023_003DzAJ2wgzdeSgYt(new RegenParams(0.0)
			{
				SkipTexts = true
			});
		}
		List<Cell> list = _0023_003DzcsMyxaYdPFqT();
		Point3D[] array = _0023_003DzAqQbug4_003D(list);
		List<Entity> list2 = new List<Entity>(array.Length / 2);
		int num;
		for (num = 0; num < array.Length; num++)
		{
			Line line = new Line((Point3D)array[num].Clone(), (Point3D)array[++num].Clone());
			Entity.PropagateAttributes(this, line, force: true);
			list2.Add(line);
		}
		foreach (Cell item in list)
		{
			Translation xform = _0023_003DzcqTF_00244zbp5OK(item.Alignment, item.Plane);
			MultilineText multilineText = new MultilineText(item);
			multilineText.TransformBy(xform);
			Entity.PropagateAttributes(this, multilineText, force: true);
			list2.Add(multilineText);
		}
		return list2.ToArray();
	}

	internal void _0023_003DzAqQbug4_003D(double _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, IWorkspace _0023_003DzFM3KC0w_003D, bool _0023_003DzzGo2_Wb1L5us, out Point3D[] _0023_003DzyIUKu5w_003D, out Point3D[][] _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D)
	{
		List<Cell> list = _0023_003DzcsMyxaYdPFqT();
		_0023_003DzyIUKu5w_003D = _0023_003DzAqQbug4_003D(list);
		_0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D = new Point3D[0][];
		if (_0023_003DzzGo2_Wb1L5us)
		{
			return;
		}
		List<Point3D[]> list2 = new List<Point3D[]>();
		foreach (Cell item in list)
		{
			if (!_0023_003DzFM3KC0w_003D.TextStyles[item.StyleName].IsSHX())
			{
				continue;
			}
			Translation xform = _0023_003DzcqTF_00244zbp5OK(item.Alignment, item.Plane);
			Point3D[][] outlines = item.GetOutlines(_0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, _0023_003DzFM3KC0w_003D);
			for (int i = 0; i < outlines.Length; i++)
			{
				for (int j = 0; j < outlines[i].Length; j++)
				{
					outlines[i][j].TransformBy(xform);
				}
			}
			list2.AddRange(outlines);
		}
		if (list2.Count > 0)
		{
			_0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D = list2.ToArray();
		}
	}

	internal Point3D[][] _0023_003Dz37SpqHylDgPQodlpFQ_003D_003D(double _0023_003DzWArtMuor9L71fptjtg_003D_003D, IWorkspace _0023_003DzFM3KC0w_003D)
	{
		List<Point3D[]> list = new List<Point3D[]>();
		foreach (Cell item in _0023_003DzcsMyxaYdPFqT())
		{
			if (_0023_003DzFM3KC0w_003D.TextStyles[item.StyleName].IsSHX())
			{
				continue;
			}
			Point3D[][] triangles = item.GetTriangles(_0023_003DzWArtMuor9L71fptjtg_003D_003D, _0023_003DzFM3KC0w_003D);
			Translation xform = _0023_003DzcqTF_00244zbp5OK(item.Alignment, item.Plane);
			for (int i = 0; i < triangles.Length; i++)
			{
				for (int j = 0; j < triangles[i].Length; j++)
				{
					triangles[i][j].TransformBy(xform);
				}
			}
			list.AddRange(triangles);
		}
		return list.ToArray();
	}

	internal virtual Point3D[][] _0023_003DzvRwWWBffvmm7RAsSMMIldug_003D(out Cell[] _0023_003DzvWtAEHE_003D)
	{
		List<Point3D[]> list = new List<Point3D[]>();
		_0023_003DzvWtAEHE_003D = _0023_003DzcsMyxaYdPFqT().ToArray();
		Cell[] array = _0023_003DzvWtAEHE_003D;
		foreach (Cell cell in array)
		{
			Point3D[] array2 = new Point3D[cell.Vertices.Length];
			Translation xform = _0023_003DzcqTF_00244zbp5OK(cell.Alignment, cell.Plane);
			for (int j = 0; j < cell.Vertices.Length; j++)
			{
				Point3D point3D = (Point3D)cell.Vertices[j].Clone();
				point3D.TransformBy(xform);
				array2[j] = point3D;
			}
			list.Add(array2);
		}
		return list.ToArray();
	}

	public bool MergeCells(int minRow, int minCol, int maxRow, int maxCol)
	{
		double num = 0.0;
		double num2 = 0.0;
		for (int i = minRow; i <= maxRow; i++)
		{
			for (int j = minCol; j <= maxCol; j++)
			{
				Cell cell = cells[i, j];
				if (cell._0023_003DzC8Y1qQ5FpzJd())
				{
					if (!cell._0023_003DzbXJI0GPjxGEH()._0023_003DzHRi2oS0_003D(minRow, minCol, maxRow, maxCol))
					{
						return false;
					}
					if (!cell._0023_003DznlWCcYBgPxFJ())
					{
						continue;
					}
				}
				if (i == minRow)
				{
					num += cell.RectWidth;
				}
				if (j == minCol)
				{
					num2 += cell.RectHeight;
				}
			}
		}
		CellRange _0023_003DzpA_0024IBV1HV8de = new CellRange(minRow, minCol, maxRow, maxCol);
		bool _0023_003DzPQ307aw_003D = true;
		for (int k = minRow; k <= maxRow; k++)
		{
			for (int l = minCol; l <= maxCol; l++)
			{
				cells[k, l]._0023_003DzgLmLM40_003D(_0023_003DzpA_0024IBV1HV8de, _0023_003DzPQ307aw_003D, num, num2, Direction);
				_0023_003DzPQ307aw_003D = false;
			}
		}
		RegenMode = regenType.RegenAndCompile;
		return true;
	}

	public bool IsMerged(int row, int col)
	{
		return cells[row, col]._0023_003DzC8Y1qQ5FpzJd();
	}

	public void MergeRange(int row, int col, out int minRow, out int minCol, out int maxRow, out int maxCol)
	{
		Cell cell = cells[row, col];
		minRow = cell._0023_003DzbXJI0GPjxGEH()._0023_003DzOhnJ5sVkuMJp();
		maxRow = cell._0023_003DzbXJI0GPjxGEH()._0023_003DzdIEC8nhYbOLX();
		minCol = cell._0023_003DzbXJI0GPjxGEH()._0023_003Dzuoqcx_Pl_iTG();
		maxCol = cell._0023_003DzbXJI0GPjxGEH()._0023_003DzIQKzEF3iEvEG();
	}

	public string GetTextString(int row, int col)
	{
		return cells[row, col].TextString;
	}

	public void SetTextString(int row, int col, string text)
	{
		cells[row, col].TextString = text;
		RegenMode = regenType.RegenAndCompile;
	}

	public double GetTextHeight(int row, int col)
	{
		return cells[row, col].Height;
	}

	public void SetTextHeight(int row, int col, double height)
	{
		cells[row, col].Height = height;
		RegenMode = regenType.RegenAndCompile;
	}

	public string GetStyleName(int row, int col)
	{
		return cells[row, col].StyleName;
	}

	public void SetStyleName(int row, int col, string styleName)
	{
		cells[row, col].StyleName = styleName;
		RegenMode = regenType.RegenAndCompile;
	}

	public Text.alignmentType GetAlignment(int row, int col)
	{
		return cells[row, col].Alignment;
	}

	public void SetAlignment(int row, int col, Text.alignmentType alignment)
	{
		cells[row, col].Alignment = alignment;
		RegenMode = regenType.RegenAndCompile;
	}

	public double GetLineSpaceDistance(int row, int col)
	{
		return cells[row, col].LineSpaceDistance;
	}

	public void SetLineSpaceDistance(int row, int col, double value)
	{
		cells[row, col].LineSpaceDistance = value;
	}

	public bool GetWrap(int row, int col)
	{
		return cells[row, col].Wrap;
	}

	public void SetWrap(int row, int col, bool value)
	{
		cells[row, col].Wrap = value;
	}

	public Point3D GetBottomLeftCorner(int row, int col)
	{
		return cells[row, col]._0023_003DzFR_UvI_P_8hJ();
	}

	public Point3D GetCenter(int row, int col)
	{
		return cells[row, col]._0023_003DzE4mfvVc_003D();
	}

	public double GetRectWidth(int row, int col)
	{
		return cells[row, col].RectWidth;
	}

	public double GetRectHeight(int row, int col)
	{
		return cells[row, col].RectHeight;
	}
}
