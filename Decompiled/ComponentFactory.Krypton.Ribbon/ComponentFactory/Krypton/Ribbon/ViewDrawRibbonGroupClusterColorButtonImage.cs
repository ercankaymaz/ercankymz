#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupClusterColorButtonImage : ViewDrawRibbonGroupImageBase
{
	private static readonly Size _smallSize = new Size(16, 16);

	private KryptonRibbonGroupClusterColorButton _ribbonColorButton;

	private Image _compositeImage;

	private Color _selectedColor;

	private Color _emptyBorderColor;

	private Rectangle _selectedRect;

	protected override Size DrawSize => _smallSize;

	protected override Image DrawImage
	{
		get
		{
			Image image = null;
			image = ((_ribbonColorButton.KryptonCommand == null) ? _ribbonColorButton.ImageSmall : _ribbonColorButton.KryptonCommand.ImageSmall);
			if (image != null && _compositeImage == null)
			{
				Bitmap bitmap = new Bitmap(image);
				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					if (_selectedColor.Equals(Color.Empty))
					{
						using Pen pen = new Pen(_emptyBorderColor);
						graphics.DrawRectangle(pen, new Rectangle(_selectedRect.X, _selectedRect.Y, _selectedRect.Width - 1, _selectedRect.Height - 1));
					}
					else
					{
						using SolidBrush brush = new SolidBrush(_selectedColor);
						graphics.FillRectangle(brush, _selectedRect);
					}
				}
				_compositeImage = bitmap;
			}
			return _compositeImage;
		}
	}

	public ViewDrawRibbonGroupClusterColorButtonImage(KryptonRibbon ribbon, KryptonRibbonGroupClusterColorButton ribbonColorButton)
		: base(ribbon)
	{
		Debug.Assert(ribbonColorButton != null);
		_ribbonColorButton = ribbonColorButton;
		_selectedColor = ribbonColorButton.SelectedColor;
		_emptyBorderColor = ribbonColorButton.EmptyBorderColor;
		_selectedRect = ribbonColorButton.SelectedRect;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupClusterColorButtonImage:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		SelectedColorRectChanged();
		base.Dispose(disposing);
	}

	public void SelectedColorRectChanged()
	{
		if (_compositeImage != null)
		{
			_compositeImage.Dispose();
			_compositeImage = null;
		}
		_emptyBorderColor = _ribbonColorButton.EmptyBorderColor;
		_selectedColor = _ribbonColorButton.SelectedColor;
		_selectedRect = _ribbonColorButton.SelectedRect;
	}
}
