#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using PdfSharp.Drawing;

namespace PdfSharp.Pdf.Advanced;

internal sealed class PdfImageTable(PdfDocument document) : PdfResourceTable(document)
{
	public class ImageSelector
	{
		private string _path;

		public string Path
		{
			get
			{
				return _path;
			}
			set
			{
				_path = value;
			}
		}

		public ImageSelector(XImage image)
		{
			if (image._path == null)
			{
				image._path = "*" + Guid.NewGuid().ToString("B");
			}
			_path = image._path.ToLowerInvariant();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is ImageSelector imageSelector))
			{
				return false;
			}
			return _path == imageSelector._path;
		}

		public override int GetHashCode()
		{
			return _path.GetHashCode();
		}
	}

	private readonly Dictionary<ImageSelector, PdfImage> _images = new Dictionary<ImageSelector, PdfImage>();

	public PdfImage GetImage(XImage image)
	{
		ImageSelector imageSelector = image._selector;
		if (imageSelector == null)
		{
			imageSelector = (image._selector = new ImageSelector(image));
		}
		if (!_images.TryGetValue(imageSelector, out var value))
		{
			value = new PdfImage(base.Owner, image);
			Debug.Assert(value.Owner == base.Owner);
			_images[imageSelector] = value;
		}
		return value;
	}
}
