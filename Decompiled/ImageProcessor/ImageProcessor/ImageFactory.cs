using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using ImageProcessor.Common.Exceptions;
using ImageProcessor.Common.Extensions;
using ImageProcessor.Configuration;
using ImageProcessor.Imaging;
using ImageProcessor.Imaging.Filters.EdgeDetection;
using ImageProcessor.Imaging.Filters.Photo;
using ImageProcessor.Imaging.Formats;
using ImageProcessor.Imaging.MetaData;
using ImageProcessor.Processors;

namespace ImageProcessor;

public class ImageFactory : IDisposable
{
	private const int DefaultQuality = 90;

	private bool preserveExifData;

	private ISupportedImageFormat backupFormat;

	private ConcurrentDictionary<int, PropertyItem> backupExifPropertyItems;

	private bool isDisposed;

	public long CurrentBitDepth { get; internal set; }

	public string ImagePath { get; private set; }

	public bool ShouldProcess { get; private set; }

	public ISupportedImageFormat CurrentImageFormat { get; private set; }

	public MetaDataMode MetaDataMode { get; private set; }

	public bool PreserveExifData
	{
		get
		{
			return preserveExifData;
		}
		set
		{
			preserveExifData = value;
			MetaDataMode = (preserveExifData ? MetaDataMode.All : MetaDataMode.None);
		}
	}

	public bool FixGamma { get; set; }

	public float CurrentGamma { get; private set; }

	public ConcurrentDictionary<int, PropertyItem> ExifPropertyItems { get; set; }

	public Image Image { get; internal set; }

	public AnimationProcessMode AnimationProcessMode { get; set; }

	internal Stream InputStream { get; set; }

	public ImageFactory(bool preserveExifData = false)
		: this(preserveExifData, fixGamma: false)
	{
	}

	public ImageFactory(bool preserveExifData, bool fixGamma)
		: this(preserveExifData ? MetaDataMode.All : MetaDataMode.None, fixGamma)
	{
	}

	public ImageFactory(MetaDataMode metaDataMode)
		: this(metaDataMode, fixGamma: false)
	{
	}

	public ImageFactory(MetaDataMode metaDataMode, bool fixGamma)
	{
		PreserveExifData = metaDataMode != MetaDataMode.None;
		MetaDataMode = metaDataMode;
		ExifPropertyItems = new ConcurrentDictionary<int, PropertyItem>();
		backupExifPropertyItems = new ConcurrentDictionary<int, PropertyItem>();
		FixGamma = fixGamma;
	}

	~ImageFactory()
	{
		Dispose(disposing: false);
	}

	public ImageFactory Load(Stream stream)
	{
		MemoryStream memoryStream = new MemoryStream();
		stream.CopyTo(memoryStream);
		if (stream.CanSeek)
		{
			stream.Position = 0L;
		}
		ISupportedImageFormat format = FormatUtilities.GetFormat(memoryStream);
		if (format == null)
		{
			throw new ImageFormatException("Input stream is not a supported format.");
		}
		Image = format.Load(memoryStream);
		CurrentBitDepth = Image.GetPixelFormatSize(Image.PixelFormat);
		InputStream = memoryStream;
		format.Quality = 90;
		format.IsIndexed = FormatUtilities.IsIndexed(Image);
		backupFormat = format;
		CurrentImageFormat = format;
		int[] propertyIdList = Image.PropertyIdList;
		foreach (int num in propertyIdList)
		{
			ExifPropertyItems[num] = Image.GetPropertyItem(num);
		}
		if (CurrentImageFormat is IAnimatedImageFormat animatedImageFormat)
		{
			animatedImageFormat.AnimationProcessMode = AnimationProcessMode;
		}
		backupExifPropertyItems = new ConcurrentDictionary<int, PropertyItem>(ExifPropertyItems);
		Image image = Image.Copy(AnimationProcessMode);
		Image.Dispose();
		Image = image;
		ShouldProcess = true;
		return this;
	}

	public ImageFactory Load(string imagePath)
	{
		FileInfo fileInfo = new FileInfo(imagePath);
		if (fileInfo.Exists)
		{
			ImagePath = imagePath;
			using (FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
			{
				ISupportedImageFormat format = FormatUtilities.GetFormat(fileStream);
				if (format == null)
				{
					throw new ImageFormatException("Input stream is not a supported format.");
				}
				MemoryStream memoryStream = new MemoryStream();
				fileStream.CopyTo(memoryStream);
				memoryStream.Position = 0L;
				Image = format.Load(memoryStream);
				CurrentBitDepth = Image.GetPixelFormatSize(Image.PixelFormat);
				InputStream = memoryStream;
				format.Quality = 90;
				format.IsIndexed = FormatUtilities.IsIndexed(Image);
				backupFormat = format;
				CurrentImageFormat = format;
				PropertyItem[] propertyItems = Image.PropertyItems;
				foreach (PropertyItem propertyItem in propertyItems)
				{
					ExifPropertyItems[propertyItem.Id] = propertyItem;
				}
				backupExifPropertyItems = new ConcurrentDictionary<int, PropertyItem>(ExifPropertyItems);
				if (CurrentImageFormat is IAnimatedImageFormat animatedImageFormat)
				{
					animatedImageFormat.AnimationProcessMode = AnimationProcessMode;
				}
				Image image = Image.Copy(AnimationProcessMode);
				Image.Dispose();
				Image = image;
				ShouldProcess = true;
			}
			return this;
		}
		throw new FileNotFoundException(imagePath);
	}

	public ImageFactory Load(byte[] bytes)
	{
		MemoryStream memoryStream = new MemoryStream(bytes);
		ISupportedImageFormat format = FormatUtilities.GetFormat(memoryStream);
		if (format == null)
		{
			throw new ImageFormatException("Input stream is not a supported format.");
		}
		Image = format.Load(memoryStream);
		CurrentBitDepth = Image.GetPixelFormatSize(Image.PixelFormat);
		InputStream = memoryStream;
		format.Quality = 90;
		format.IsIndexed = FormatUtilities.IsIndexed(Image);
		backupFormat = format;
		CurrentImageFormat = format;
		int[] propertyIdList = Image.PropertyIdList;
		foreach (int num in propertyIdList)
		{
			ExifPropertyItems[num] = Image.GetPropertyItem(num);
		}
		if (CurrentImageFormat is IAnimatedImageFormat animatedImageFormat)
		{
			animatedImageFormat.AnimationProcessMode = AnimationProcessMode;
		}
		Image image = Image.Copy(AnimationProcessMode);
		Image.Dispose();
		Image = image;
		ShouldProcess = true;
		return this;
	}

	public ImageFactory Load(Image image)
	{
		MemoryStream memoryStream = new MemoryStream();
		ISupportedImageFormat supportedImageFormat = new BitmapFormat();
		try
		{
			image.Save(memoryStream, image.RawFormat);
			supportedImageFormat = ImageProcessorBootstrapper.Instance.SupportedImageFormats.First((ISupportedImageFormat f) => f.ImageFormat.Equals(image.RawFormat));
		}
		catch
		{
			image.Save(memoryStream, ImageFormat.Bmp);
		}
		if (supportedImageFormat is IAnimatedImageFormat animatedImageFormat)
		{
			animatedImageFormat.AnimationProcessMode = AnimationProcessMode;
		}
		Image = image.Copy(AnimationProcessMode);
		CurrentBitDepth = Image.GetPixelFormatSize(Image.PixelFormat);
		InputStream = memoryStream;
		supportedImageFormat.Quality = 90;
		supportedImageFormat.IsIndexed = FormatUtilities.IsIndexed(Image);
		backupFormat = supportedImageFormat;
		CurrentImageFormat = supportedImageFormat;
		int[] propertyIdList = Image.PropertyIdList;
		foreach (int num2 in propertyIdList)
		{
			ExifPropertyItems[num2] = Image.GetPropertyItem(num2);
		}
		ShouldProcess = true;
		return this;
	}

	public ImageFactory Reset()
	{
		if (ShouldProcess)
		{
			if (InputStream.CanSeek)
			{
				InputStream.Position = 0L;
			}
			CurrentImageFormat = backupFormat;
			ExifPropertyItems = new ConcurrentDictionary<int, PropertyItem>(backupExifPropertyItems);
			CurrentImageFormat.Quality = 90;
			Image image = backupFormat.Load(InputStream);
			Image image2 = image.Copy(AnimationProcessMode);
			image.Dispose();
			Image.Dispose();
			Image = image2;
		}
		return this;
	}

	public ImageFactory Alpha(int percentage)
	{
		if (ShouldProcess)
		{
			if (percentage < 0 || percentage > 99)
			{
				return this;
			}
			Alpha alpha = new Alpha
			{
				DynamicParameter = percentage
			};
			backupFormat.ApplyProcessor(alpha.ProcessImage, this);
		}
		return this;
	}

	public ImageFactory AutoRotate()
	{
		if (ShouldProcess)
		{
			AutoRotate autoRotate = new AutoRotate();
			backupFormat.ApplyProcessor(autoRotate.ProcessImage, this);
		}
		return this;
	}

	public ImageFactory BitDepth(long bitDepth)
	{
		if (bitDepth > 0 && ShouldProcess)
		{
			CurrentBitDepth = bitDepth;
		}
		return this;
	}

	public ImageFactory Brightness(int percentage)
	{
		if (ShouldProcess)
		{
			if (percentage > 100 || percentage < -100 || percentage == 0)
			{
				return this;
			}
			Brightness brightness = new Brightness
			{
				DynamicParameter = percentage
			};
			backupFormat.ApplyProcessor(brightness.ProcessImage, this);
		}
		return this;
	}

	public ImageFactory BackgroundColor(Color color)
	{
		if (ShouldProcess)
		{
			BackgroundColor backgroundColor = new BackgroundColor
			{
				DynamicParameter = color
			};
			backupFormat.ApplyProcessor(backgroundColor.ProcessImage, this);
		}
		return this;
	}

	public ImageFactory Constrain(Size size)
	{
		if (ShouldProcess)
		{
			ResizeLayer resizeLayer = new ResizeLayer(size, ResizeMode.Max);
			return Resize(resizeLayer);
		}
		return this;
	}

	public ImageFactory Contrast(int percentage)
	{
		if (ShouldProcess)
		{
			if (percentage > 100 || percentage < -100)
			{
				return this;
			}
			Contrast contrast = new Contrast
			{
				DynamicParameter = percentage
			};
			backupFormat.ApplyProcessor(contrast.ProcessImage, this);
		}
		return this;
	}

	public ImageFactory Crop(Rectangle rectangle)
	{
		if (ShouldProcess)
		{
			CropLayer cropLayer = new CropLayer(rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height, CropMode.Pixels);
			return Crop(cropLayer);
		}
		return this;
	}

	public ImageFactory Crop(CropLayer cropLayer)
	{
		if (ShouldProcess)
		{
			Crop crop = new Crop
			{
				DynamicParameter = cropLayer
			};
			backupFormat.ApplyProcessor(crop.ProcessImage, this);
		}
		return this;
	}

	public ImageFactory DetectEdges(IEdgeFilter filter, bool greyscale = true)
	{
		if (ShouldProcess)
		{
			DetectEdges detectEdges = new DetectEdges
			{
				DynamicParameter = new Tuple<IEdgeFilter, bool>(filter, greyscale)
			};
			backupFormat.ApplyProcessor(detectEdges.ProcessImage, this);
		}
		return this;
	}

	public ImageFactory Resolution(int horizontal, int vertical, PropertyTagResolutionUnit unit = PropertyTagResolutionUnit.Inch)
	{
		if (ShouldProcess)
		{
			if (horizontal < 0 || vertical < 0)
			{
				return this;
			}
			Tuple<int, int, PropertyTagResolutionUnit> dynamicParameter = new Tuple<int, int, PropertyTagResolutionUnit>(horizontal, vertical, unit);
			Resolution resolution = new Resolution
			{
				DynamicParameter = dynamicParameter
			};
			backupFormat.ApplyProcessor(resolution.ProcessImage, this);
		}
		return this;
	}

	public ImageFactory EntropyCrop(byte threshold = 128)
	{
		if (ShouldProcess)
		{
			EntropyCrop entropyCrop = new EntropyCrop
			{
				DynamicParameter = threshold
			};
			backupFormat.ApplyProcessor(entropyCrop.ProcessImage, this);
		}
		return this;
	}

	public ImageFactory Filter(IMatrixFilter matrixFilter)
	{
		if (ShouldProcess)
		{
			Filter filter = new Filter
			{
				DynamicParameter = matrixFilter
			};
			backupFormat.ApplyProcessor(filter.ProcessImage, this);
		}
		return this;
	}

	public ImageFactory Flip(bool flipVertically = false, bool flipBoth = false)
	{
		if (ShouldProcess)
		{
			RotateFlipType rotateFlipType = ((!flipBoth) ? (flipVertically ? RotateFlipType.Rotate180FlipX : RotateFlipType.RotateNoneFlipX) : RotateFlipType.Rotate180FlipNone);
			Flip flip = new Flip
			{
				DynamicParameter = rotateFlipType
			};
			backupFormat.ApplyProcessor(flip.ProcessImage, this);
		}
		return this;
	}

	public ImageFactory Format(ISupportedImageFormat format)
	{
		if (ShouldProcess)
		{
			CurrentImageFormat = format;
		}
		return this;
	}

	public ImageFactory Gamma(float value)
	{
		if (ShouldProcess)
		{
			if (value > 5f || (double)value < 0.1)
			{
				return this;
			}
			CurrentGamma = value;
			Gamma gamma = new Gamma
			{
				DynamicParameter = value
			};
			backupFormat.ApplyProcessor(gamma.ProcessImage, this);
		}
		return this;
	}

	public ImageFactory GaussianBlur(int size)
	{
		if (ShouldProcess && size > 0)
		{
			GaussianLayer gaussianLayer = new GaussianLayer(size);
			return GaussianBlur(gaussianLayer);
		}
		return this;
	}

	public ImageFactory GaussianBlur(GaussianLayer gaussianLayer)
	{
		if (ShouldProcess)
		{
			GaussianBlur gaussianBlur = new GaussianBlur
			{
				DynamicParameter = gaussianLayer
			};
			backupFormat.ApplyProcessor(gaussianBlur.ProcessImage, this);
		}
		return this;
	}

	public ImageFactory GaussianSharpen(int size)
	{
		if (ShouldProcess && size > 0)
		{
			GaussianLayer gaussianLayer = new GaussianLayer(size);
			return GaussianSharpen(gaussianLayer);
		}
		return this;
	}

	public ImageFactory GaussianSharpen(GaussianLayer gaussianLayer)
	{
		if (ShouldProcess)
		{
			GaussianSharpen gaussianSharpen = new GaussianSharpen
			{
				DynamicParameter = gaussianLayer
			};
			backupFormat.ApplyProcessor(gaussianSharpen.ProcessImage, this);
		}
		return this;
	}

	public ImageFactory Hue(int degrees, bool rotate = false)
	{
		if (degrees > 360 || degrees < 0 || (degrees == 0 && rotate))
		{
			return this;
		}
		if (ShouldProcess)
		{
			Hue hue = new Hue
			{
				DynamicParameter = new Tuple<int, bool>(degrees, rotate)
			};
			backupFormat.ApplyProcessor(hue.ProcessImage, this);
		}
		return this;
	}

	public ImageFactory Halftone(bool comicMode = false)
	{
		if (ShouldProcess)
		{
			Halftone halftone = new Halftone
			{
				DynamicParameter = comicMode
			};
			backupFormat.ApplyProcessor(halftone.ProcessImage, this);
		}
		return this;
	}

	public ImageFactory Mask(ImageLayer imageLayer)
	{
		if (ShouldProcess)
		{
			Mask mask = new Mask
			{
				DynamicParameter = imageLayer
			};
			backupFormat.ApplyProcessor(mask.ProcessImage, this);
		}
		return this;
	}

	public ImageFactory Overlay(ImageLayer imageLayer)
	{
		if (ShouldProcess)
		{
			Overlay overlay = new Overlay
			{
				DynamicParameter = imageLayer
			};
			backupFormat.ApplyProcessor(overlay.ProcessImage, this);
		}
		return this;
	}

	public ImageFactory Pixelate(int pixelSize, Rectangle? rectangle = null)
	{
		if (ShouldProcess && pixelSize > 0)
		{
			Pixelate pixelate = new Pixelate
			{
				DynamicParameter = new Tuple<int, Rectangle?>(pixelSize, rectangle)
			};
			backupFormat.ApplyProcessor(pixelate.ProcessImage, this);
		}
		return this;
	}

	public ImageFactory Quality(int percentage)
	{
		if (percentage <= 100 && percentage >= 0 && ShouldProcess)
		{
			CurrentImageFormat.Quality = percentage;
		}
		return this;
	}

	public ImageFactory ReplaceColor(Color target, Color replacement, int fuzziness = 0)
	{
		if (fuzziness < 0 || fuzziness > 128)
		{
			return this;
		}
		if (ShouldProcess && target != Color.Empty && replacement != Color.Empty)
		{
			ReplaceColor replaceColor = new ReplaceColor
			{
				DynamicParameter = new Tuple<Color, Color, int>(target, replacement, fuzziness)
			};
			backupFormat.ApplyProcessor(replaceColor.ProcessImage, this);
		}
		return this;
	}

	public ImageFactory Resize(Size size)
	{
		if (ShouldProcess)
		{
			int width = size.Width;
			int height = size.Height;
			ResizeLayer resizeLayer = new ResizeLayer(new Size(width, height));
			return Resize(resizeLayer);
		}
		return this;
	}

	public ImageFactory Resize(ResizeLayer resizeLayer)
	{
		if (ShouldProcess)
		{
			Dictionary<string, string> settings = new Dictionary<string, string>
			{
				{
					"MaxWidth",
					resizeLayer.Size.Width.ToString("G")
				},
				{
					"MaxHeight",
					resizeLayer.Size.Height.ToString("G")
				}
			};
			Resize resize = new Resize
			{
				DynamicParameter = resizeLayer,
				Settings = settings
			};
			backupFormat.ApplyProcessor(resize.ProcessImage, this);
		}
		return this;
	}

	public ImageFactory Rotate(float degrees)
	{
		if (ShouldProcess)
		{
			Rotate rotate = new Rotate
			{
				DynamicParameter = degrees
			};
			backupFormat.ApplyProcessor(rotate.ProcessImage, this);
		}
		return this;
	}

	public ImageFactory RotateBounded(float degrees, bool keepSize = false)
	{
		if (ShouldProcess)
		{
			RotateBounded rotateBounded = new RotateBounded
			{
				DynamicParameter = new Tuple<float, bool>(degrees, keepSize)
			};
			backupFormat.ApplyProcessor(rotateBounded.ProcessImage, this);
		}
		return this;
	}

	public ImageFactory RoundedCorners(int radius)
	{
		if (ShouldProcess)
		{
			if (radius < 0)
			{
				radius = 0;
			}
			RoundedCornerLayer dynamicParameter = new RoundedCornerLayer(radius);
			RoundedCorners roundedCorners = new RoundedCorners
			{
				DynamicParameter = dynamicParameter
			};
			backupFormat.ApplyProcessor(roundedCorners.ProcessImage, this);
		}
		return this;
	}

	public ImageFactory RoundedCorners(RoundedCornerLayer roundedCornerLayer)
	{
		if (ShouldProcess)
		{
			if (roundedCornerLayer.Radius < 0)
			{
				roundedCornerLayer.Radius = 0;
			}
			RoundedCorners roundedCorners = new RoundedCorners
			{
				DynamicParameter = roundedCornerLayer
			};
			backupFormat.ApplyProcessor(roundedCorners.ProcessImage, this);
		}
		return this;
	}

	public ImageFactory Saturation(int percentage)
	{
		if (ShouldProcess)
		{
			if (percentage > 100 || percentage < -100)
			{
				return this;
			}
			Saturation saturation = new Saturation
			{
				DynamicParameter = percentage
			};
			backupFormat.ApplyProcessor(saturation.ProcessImage, this);
		}
		return this;
	}

	public ImageFactory Tint(Color color)
	{
		if (ShouldProcess)
		{
			Tint tint = new Tint
			{
				DynamicParameter = color
			};
			backupFormat.ApplyProcessor(tint.ProcessImage, this);
		}
		return this;
	}

	public ImageFactory Vignette(Color? color = null)
	{
		if (ShouldProcess)
		{
			Vignette vignette = new Vignette
			{
				DynamicParameter = ((color.HasValue && !color.Equals(Color.Transparent)) ? color.Value : Color.Black)
			};
			backupFormat.ApplyProcessor(vignette.ProcessImage, this);
		}
		return this;
	}

	public ImageFactory Watermark(TextLayer textLayer)
	{
		if (ShouldProcess)
		{
			Watermark watermark = new Watermark
			{
				DynamicParameter = textLayer
			};
			backupFormat.ApplyProcessor(watermark.ProcessImage, this);
		}
		return this;
	}

	public ImageFactory Save(string filePath)
	{
		if (ShouldProcess)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(filePath));
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
			SetMetaData();
			Image = CurrentImageFormat.Save(filePath, Image, CurrentBitDepth);
		}
		return this;
	}

	public ImageFactory Save(Stream stream)
	{
		if (ShouldProcess)
		{
			if (stream.CanSeek)
			{
				stream.SetLength(0L);
			}
			SetMetaData();
			Image = CurrentImageFormat.Save(stream, Image, CurrentBitDepth);
			if (stream.CanSeek)
			{
				stream.Position = 0L;
			}
		}
		return this;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (isDisposed)
		{
			return;
		}
		if (disposing && Image != null)
		{
			if (InputStream != null)
			{
				InputStream.Dispose();
				InputStream = null;
			}
			Image.Dispose();
			Image = null;
		}
		isDisposed = true;
	}

	private void SetMetaData()
	{
		if (MetaDataMode == MetaDataMode.All)
		{
			foreach (KeyValuePair<int, PropertyItem> exifPropertyItem in ExifPropertyItems)
			{
				try
				{
					Image.SetPropertyItem(exifPropertyItem.Value);
				}
				catch
				{
				}
			}
			return;
		}
		ExifPropertyTag[] source = ExifPropertyTagConstants.RequiredPropertyItems;
		switch (MetaDataMode)
		{
		case MetaDataMode.Copyright:
			source = ExifPropertyTagConstants.CopyrightPropertyItems;
			break;
		case MetaDataMode.CopyrightAndGeolocation:
			source = ExifPropertyTagConstants.CopyrightAndGeolocationPropertyItems;
			break;
		}
		foreach (KeyValuePair<int, PropertyItem> exifPropertyItem2 in ExifPropertyItems)
		{
			try
			{
				if (source.Contains((ExifPropertyTag)exifPropertyItem2.Key))
				{
					Image.SetPropertyItem(exifPropertyItem2.Value);
				}
			}
			catch
			{
			}
		}
	}
}
