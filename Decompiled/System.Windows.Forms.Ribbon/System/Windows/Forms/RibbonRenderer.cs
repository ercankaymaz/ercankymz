using System.Drawing;
using System.Drawing.Imaging;

namespace System.Windows.Forms;

public class RibbonRenderer
{
	private static ColorMatrix _disabledImageColorMatrix;

	private static ColorMatrix DisabledImageColorMatrix
	{
		get
		{
			if (_disabledImageColorMatrix == null)
			{
				_disabledImageColorMatrix = MultiplyColorMatrix(matrix2: new float[5][]
				{
					new float[5] { 0.2125f, 0.2125f, 0.2125f, 0f, 0f },
					new float[5] { 0.2577f, 0.2577f, 0.2577f, 0f, 0f },
					new float[5] { 0.0361f, 0.0361f, 0.0361f, 0f, 0f },
					new float[5] { 0f, 0f, 0f, 1f, 0f },
					new float[5] { 0.38f, 0.38f, 0.38f, 0f, 1f }
				}, matrix1: new float[5][]
				{
					new float[5] { 1f, 0f, 0f, 0f, 0f },
					new float[5] { 0f, 1f, 0f, 0f, 0f },
					new float[5] { 0f, 0f, 1f, 0f, 0f },
					new float[5] { 0f, 0f, 0f, 0.7f, 0f },
					new float[5]
				});
			}
			return _disabledImageColorMatrix;
		}
	}

	internal static ColorMatrix MultiplyColorMatrix(float[][] matrix1, float[][] matrix2)
	{
		int num = 5;
		float[][] array = new float[num][];
		for (int i = 0; i < num; i++)
		{
			array[i] = new float[num];
		}
		float[] array2 = new float[num];
		for (int j = 0; j < num; j++)
		{
			for (int k = 0; k < num; k++)
			{
				array2[k] = matrix1[k][j];
			}
			for (int l = 0; l < num; l++)
			{
				float[] array3 = matrix2[l];
				float num2 = 0f;
				for (int m = 0; m < num; m++)
				{
					num2 += array3[m] * array2[m];
				}
				array[l][j] = num2;
			}
		}
		return new ColorMatrix(array);
	}

	public static Image CreateDisabledImage(Image normalImage)
	{
		ImageAttributes imageAttributes = new ImageAttributes();
		imageAttributes.ClearColorKey();
		imageAttributes.SetColorMatrix(DisabledImageColorMatrix);
		Size size = normalImage.Size;
		Bitmap bitmap = new Bitmap(size.Width, size.Height);
		Graphics graphics = Graphics.FromImage(bitmap);
		graphics.DrawImage(normalImage, new Rectangle(0, 0, size.Width, size.Height), 0, 0, size.Width, size.Height, GraphicsUnit.Pixel, imageAttributes);
		graphics.Dispose();
		return bitmap;
	}

	public virtual void OnRenderOrbDropDownBackground(RibbonOrbDropDownEventArgs e)
	{
	}

	public virtual void OnRenderRibbonCaptionBar(RibbonRenderEventArgs e)
	{
	}

	public virtual void OnRenderRibbonOrb(RibbonRenderEventArgs e)
	{
	}

	public virtual void OnRenderRibbonQuickAccessToolbarBackground(RibbonRenderEventArgs e)
	{
	}

	public virtual void OnRenderRibbonBackground(RibbonRenderEventArgs e)
	{
	}

	public virtual void OnRenderRibbonTab(RibbonTabRenderEventArgs e)
	{
	}

	public virtual void OnRenderRibbonContext(RibbonContextRenderEventArgs e)
	{
	}

	public virtual void OnRenderRibbonItem(RibbonItemRenderEventArgs e)
	{
	}

	public virtual void OnRenderRibbonTabContentBackground(RibbonTabRenderEventArgs e)
	{
	}

	public virtual void OnRenderRibbonPanelBackground(RibbonPanelRenderEventArgs e)
	{
	}

	public virtual void OnRenderRibbonTabText(RibbonTabRenderEventArgs e)
	{
	}

	public virtual void OnRenderRibbonContextText(RibbonContextRenderEventArgs e)
	{
	}

	public virtual void OnRenderRibbonItemText(RibbonTextEventArgs e)
	{
	}

	public virtual void OnRenderRibbonItemBorder(RibbonItemRenderEventArgs e)
	{
	}

	public virtual void OnRenderRibbonItemImage(RibbonItemBoundsEventArgs e)
	{
	}

	public virtual void OnRenderRibbonPanelText(RibbonPanelRenderEventArgs e)
	{
	}

	public virtual void OnRenderDropDownBackground(RibbonCanvasEventArgs e)
	{
	}

	public virtual void OnRenderDropDownDropDownImageSeparator(RibbonItem item, RibbonCanvasEventArgs e)
	{
	}

	public virtual void OnRenderPanelPopupBackground(RibbonCanvasEventArgs e)
	{
	}

	public virtual void OnRenderTabScrollButtons(RibbonTabRenderEventArgs e)
	{
	}

	public virtual void OnRenderScrollbar(Graphics g, Control item, Ribbon ribbon)
	{
	}

	public virtual void OnRenderToolTipBackground(RibbonToolTipRenderEventArgs e)
	{
	}

	public virtual void OnRenderToolTipText(RibbonToolTipRenderEventArgs e)
	{
	}

	public virtual void OnRenderToolTipImage(RibbonToolTipRenderEventArgs e)
	{
	}
}
