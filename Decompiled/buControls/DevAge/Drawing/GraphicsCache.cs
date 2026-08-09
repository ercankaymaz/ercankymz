using System;
using System.Drawing;

namespace DevAge.Drawing;

public class GraphicsCache : IDisposable
{
	private Rectangle clipRectangle;

	private Graphics graphics;

	private PensCache pensCache_0;

	private BrushsCache brushsCache_0;

	public Rectangle ClipRectangle => clipRectangle;

	public Graphics Graphics => graphics;

	public PensCache PensCache => pensCache_0;

	public BrushsCache BrushsCache => brushsCache_0;

	public GraphicsCache(Graphics graphics)
	{
		this.graphics = graphics;
		clipRectangle = Rectangle.Empty;
		pensCache_0 = new PensCache(20);
		brushsCache_0 = new BrushsCache(20);
	}

	public GraphicsCache(Graphics graphics, Rectangle clipRectangle)
	{
		this.graphics = graphics;
		this.clipRectangle = clipRectangle;
		pensCache_0 = new PensCache(20);
		brushsCache_0 = new BrushsCache(20);
	}

	public GraphicsCache(Graphics graphics, Rectangle clipRectangle, int pensCapacity, int brushsCapacity)
	{
		this.graphics = graphics;
		this.clipRectangle = clipRectangle;
		pensCache_0 = new PensCache(pensCapacity);
		brushsCache_0 = new BrushsCache(brushsCapacity);
	}

	public void Dispose()
	{
		pensCache_0.Dispose();
		pensCache_0 = null;
		brushsCache_0.Dispose();
		brushsCache_0 = null;
		graphics = null;
	}
}
