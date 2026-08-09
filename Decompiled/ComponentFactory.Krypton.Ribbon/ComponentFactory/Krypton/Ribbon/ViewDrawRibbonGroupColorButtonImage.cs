#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupColorButtonImage : ViewDrawRibbonGroupImageBase
{
	private static readonly Size _smallSize = new Size(16, 16);

	private static readonly Size _largeSize = new Size(32, 32);

	private KryptonRibbonGroupColorButton _ribbonColorButton;

	private bool _large;

	private Image _compositeImage;

	private Color _selectedColor;

	private Color _emptyBorderColor;

	private Rectangle _selectedRectSmall;

	private Rectangle _selectedRectLarge;

	protected override Size DrawSize
	{
		get
		{
			if (_large)
			{
				return _largeSize;
			}
			return _smallSize;
		}
	}

	protected override Image DrawImage
	{
		get
		{
			Image image = null;
			image = ((_ribbonColorButton.KryptonCommand != null) ? ((!_large) ? _ribbonColorButton.KryptonCommand.ImageSmall : _ribbonColorButton.KryptonCommand.ImageLarge) : ((!_large) ? _ribbonColorButton.ImageSmall : _ribbonColorButton.ImageLarge));
			if (image != null && _compositeImage == null)
			{
				Bitmap bitmap = new Bitmap(image);
				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					Rectangle rect = (_large ? _selectedRectLarge : _selectedRectSmall);
					if (_selectedColor.Equals(Color.Empty))
					{
						using Pen pen = new Pen(_emptyBorderColor);
						graphics.DrawRectangle(pen, new Rectangle(rect.X, rect.Y, rect.Width - 1, rect.Height - 1));
					}
					else
					{
						using SolidBrush brush = new SolidBrush(_selectedColor);
						graphics.FillRectangle(brush, rect);
					}
				}
				_compositeImage = bitmap;
			}
			return _compositeImage;
		}
	}

	public ViewDrawRibbonGroupColorButtonImage(KryptonRibbon ribbon, KryptonRibbonGroupColorButton ribbonColorButton, bool large)
		: base(ribbon)
	{
		Debug.Assert(ribbonColorButton != null);
		_ribbonColorButton = ribbonColorButton;
		_selectedColor = ribbonColorButton.SelectedColor;
		_emptyBorderColor = ribbonColorButton.EmptyBorderColor;
		_selectedRectSmall = ribbonColorButton.SelectedRectSmall;
		_selectedRectLarge = ribbonColorButton.SelectedRectLarge;
		_large = large;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupColorButtonImage:" + base.Id;
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
		_selectedRectSmall = _ribbonColorButton.SelectedRectSmall;
		_selectedRectLarge = _ribbonColorButton.SelectedRectLarge;
	}
}
