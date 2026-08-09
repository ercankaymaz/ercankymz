using System;
using DevAge.Drawing;

namespace SourceGrid;

public class RangePaintEventArgs : EventArgs
{
	private GridVirtual grid;

	private GraphicsCache graphicsCache;

	private Range drawingRange;

	public GridVirtual Grid => grid;

	public GraphicsCache GraphicsCache
	{
		get
		{
			return graphicsCache;
		}
		set
		{
			graphicsCache = value;
		}
	}

	public Range DrawingRange
	{
		get
		{
			return drawingRange;
		}
		set
		{
			drawingRange = value;
		}
	}

	public RangePaintEventArgs(GridVirtual grid, GraphicsCache graphicsCache, Range drawingRange)
	{
		this.grid = grid;
		this.graphicsCache = graphicsCache;
		this.drawingRange = drawingRange;
	}
}
