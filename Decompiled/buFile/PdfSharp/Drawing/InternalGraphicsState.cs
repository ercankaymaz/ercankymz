namespace PdfSharp.Drawing;

internal class InternalGraphicsState
{
	private XMatrix _transform;

	public bool Invalid;

	private readonly XGraphics _gfx;

	internal XGraphicsState State;

	public XMatrix Transform
	{
		get
		{
			return _transform;
		}
		set
		{
			_transform = value;
		}
	}

	public InternalGraphicsState(XGraphics gfx)
	{
		_gfx = gfx;
	}

	public InternalGraphicsState(XGraphics gfx, XGraphicsState state)
	{
		_gfx = gfx;
		State = state;
		State.InternalState = this;
	}

	public InternalGraphicsState(XGraphics gfx, XGraphicsContainer container)
	{
		_gfx = gfx;
		container.InternalState = this;
	}

	public void Pushed()
	{
	}

	public void Popped()
	{
		Invalid = true;
	}
}
