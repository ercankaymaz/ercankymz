using System;
using System.Windows.Markup;
using System.Windows.Media.Imaging;

namespace Xceed.Wpf.Toolkit.Core;

[MarkupExtensionReturnType(typeof(BitmapImage))]
public class ImageUriExtension : PackUriExtension
{
	public ImageUriExtension()
		: base(UriKind.Absolute)
	{
	}

	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		return new BitmapImage((Uri)base.ProvideValue(serviceProvider));
	}
}
