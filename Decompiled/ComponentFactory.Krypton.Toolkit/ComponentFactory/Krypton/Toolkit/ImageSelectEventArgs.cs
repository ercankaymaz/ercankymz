using System;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ImageSelectEventArgs : EventArgs
{
	private ImageList _imageList;

	private int _imageIndex;

	public ImageList ImageList => _imageList;

	public int ImageIndex => _imageIndex;

	public ImageSelectEventArgs(ImageList imageList, int imageIndex)
	{
		_imageList = imageList;
		_imageIndex = imageIndex;
	}
}
