using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Eyeshot.Triangulation;
using devDept.Eyeshot.Triangulation.Dicom;
using devDept.Geometry;
using devDept.Geometry.Blink;

namespace devDept.Eyeshot.Control;

public static class Extensions
{
	public static Picture CreatePicture(this Image image, Plane plane, double width, double height, bool tiling = false)
	{
		return new Picture(plane, width, height, UtilityEx.ConvertImageToBytes(image), tiling);
	}

	public static Material CreateMaterial(this Image image, string name)
	{
		return new Material(name, UtilityEx.ConvertImageToBytes(image));
	}

	public static Material CreateMaterial(this Image image, string name, Color ambient, Color specular, float shininess)
	{
		return new Material(name, ambient, specular, shininess, UtilityEx.ConvertImageToBytes(image));
	}

	public static MarchingSquares CreateMarchingSquares(this Bitmap original, int cellSizeInX = 1, int cellSizeInY = 1, bool makeGrayscale = false)
	{
		Bitmap bitmap = original;
		if (makeGrayscale)
		{
			bitmap = UtilityEx.MakeGrayscale(original);
		}
		LockBitmap lockBitmap = new LockBitmap(bitmap);
		lockBitmap.LockBits();
		PictureData<byte> pictureData = new PictureData<byte>(bitmap.Width, bitmap.Height);
		for (int i = 0; i < lockBitmap.Width; i++)
		{
			for (int j = 0; j < lockBitmap.Height; j++)
			{
				pictureData.Pixels[i, j] = lockBitmap.GetPixel(i, lockBitmap.Height - j - 1).R;
			}
		}
		lockBitmap.UnlockBits();
		if (makeGrayscale)
		{
			bitmap.Dispose();
		}
		return new MarchingSquares(pictureData, cellSizeInX, cellSizeInY);
	}

	public static byte[] ToByteArray(this Image image)
	{
		return UtilityEx.ConvertImageToBytes(image);
	}

	public static Bitmap GetThumbnail(this ReadFile readFile, int thumbnailSize = 256)
	{
		readFile.GetFileInfo();
		if (readFile.FileHeader?.Thumbnail == null)
		{
			return null;
		}
		Bitmap bitmap = UtilityEx.ConvertBytesToImage(readFile.FileHeader.Thumbnail);
		if (thumbnailSize < 256)
		{
			bitmap = UtilityEx._0023_003Dz3nqRsaSSSvFx(bitmap, Workspace._0023_003DzTRjGTao_003D(new Size(256, 256), thumbnailSize));
		}
		return bitmap;
	}

	public static Bitmap GetThumbnail(string filePath, int thumbnailSize = 256)
	{
		ReadMultiFile readMultiFile = new ReadMultiFile(filePath);
		try
		{
			return readMultiFile.GetThumbnail(thumbnailSize);
		}
		finally
		{
			((IDisposable)readMultiFile).Dispose();
		}
	}

	public static void AddViewPlaceHolder(this Sheet sheet, View view, Design design, Drawing drawing, string placeHolderText = null)
	{
		if (drawing.Blocks.Contains(view.BlockName))
		{
			return;
		}
		ViewBuilderEx viewBuilderEx = new ViewBuilderEx(design, drawing, view, sheet);
		if (!viewBuilderEx.InitializeCameraAndUpdateView(view, sheet))
		{
			throw new EyeshotException(viewBuilderEx.Log);
		}
		Block placeHolderBlock = view.GetPlaceHolderBlock(drawing.WiresLayerName, placeHolderText);
		drawing.Blocks.Add(placeHolderBlock);
		if (sheet == drawing.ActiveSheet)
		{
			if (!drawing.Entities.Contains(view))
			{
				drawing.Entities.Add(view);
			}
		}
		else if (!sheet.Entities.Contains(view))
		{
			sheet.Entities.Add(view);
		}
	}

	public static Block Rebuild(this RasterView rasterView, Design design, Sheet sheet, Drawing drawing, bool async = false)
	{
		ViewBuilderEx viewBuilderEx = new ViewBuilderEx(design, drawing, rasterView, sheet);
		Block result = null;
		if (async)
		{
			drawing.StartWork(viewBuilderEx);
		}
		else
		{
			viewBuilderEx.DoWork();
			result = viewBuilderEx.viewsBlocks[rasterView];
		}
		return result;
	}

	public static void Rebuild(this Sheet sheet, Design design, Drawing drawing, bool async = false, bool changedOnly = true)
	{
		List<View> list = new List<View>();
		foreach (Entity entity in sheet.Entities)
		{
			if (entity is View view && (view.HasChanged || !changedOnly))
			{
				list.Add(view);
			}
		}
		ViewBuilderEx viewBuilderEx = new ViewBuilderEx(design, drawing, new Dictionary<Sheet, IList<View>> { { sheet, list } });
		if (async)
		{
			drawing.StartWork(viewBuilderEx);
			return;
		}
		viewBuilderEx.DoWork();
		viewBuilderEx.AddTo(drawing.Document);
	}

	public static BlockReference BuildBillOfMaterials(this Sheet sheet, Design design, Point3D insertionPoint, string itemNumberText, string partNumberText, string descriptionText, string quantityText, out Block block, string blockName = null, bool partsOnly = false, Table.flowDirection flowDirection = Table.flowDirection.Down, int maxLevel = int.MaxValue)
	{
		return sheet.BuildBillOfMaterials(design.Document, insertionPoint, itemNumberText, partNumberText, descriptionText, quantityText, out block, blockName, partsOnly, flowDirection, maxLevel);
	}

	public static void Blink(this Bitmap bitmap)
	{
		Client.Blink(new Picture(Plane.XY, bitmap.Width, bitmap.Height, bitmap.ToByteArray())
		{
			Lighted = false,
			DrawEdge = false
		});
	}

	public static Bitmap GetBitmap(this IodElement iodElement)
	{
		return iodElement.GetBitmap(0, 0);
	}

	public static Bitmap GetBitmap(this IodElement iodElement, int brightness, int contrast)
	{
		return iodElement.SliceInfo.GetBitmap(brightness, contrast);
	}

	public static Bitmap GetBitmap(this CtSliceInfo ctSliceInfo, int windowCenter, int windowWidth)
	{
		if (windowCenter != ctSliceInfo.lastWindowCenter || windowWidth != ctSliceInfo.lastWindowWidth)
		{
			if (ctSliceInfo.bitmap != null)
			{
				ctSliceInfo.bitmap.Dispose();
			}
			ctSliceInfo.bitmap = null;
			ctSliceInfo.lastWindowCenter = windowCenter;
			ctSliceInfo.lastWindowWidth = windowWidth;
		}
		if (ctSliceInfo.bitmap == null)
		{
			byte[,] pixels = ctSliceInfo.GetPixels(windowCenter, windowWidth);
			byte[] array = new byte[ctSliceInfo.Rows * ctSliceInfo.Columns * 4];
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < ctSliceInfo.Rows; i++)
			{
				for (int j = 0; j < ctSliceInfo.Columns; j++)
				{
					byte b = pixels[i, j];
					array[num2++] = b;
					array[num2++] = b;
					array[num2++] = b;
					array[num2++] = byte.MaxValue;
					num++;
				}
			}
			ctSliceInfo.bitmap = new Bitmap(ctSliceInfo.Columns, ctSliceInfo.Rows, PixelFormat.Format32bppPArgb);
			Rectangle rect = new Rectangle(0, 0, ctSliceInfo.Columns, ctSliceInfo.Rows);
			BitmapData bitmapData = ctSliceInfo.bitmap.LockBits(rect, ImageLockMode.WriteOnly, ctSliceInfo.bitmap.PixelFormat);
			_ = ctSliceInfo.Columns;
			Marshal.Copy(array, 0, bitmapData.Scan0, array.Length);
			ctSliceInfo.bitmap.UnlockBits(bitmapData);
		}
		return ctSliceInfo.bitmap;
	}
}
