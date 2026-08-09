using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ImageProcessor.Imaging;
using buClass;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_ImageToVector : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public string pathInit = Application.StartupPath;

	public Image imageOutput = null;

	public RasterToVectorVar Settings = new RasterToVectorVar();

	private string string_0 = "";

	private List<Color> list_0 = new List<Color>();

	private List<Color> list_1 = new List<Color>();

	private Image image_0 = null;

	private IContainer icontainer_0 = null;

	internal PictureBox pictureBox_0;

	internal PictureBox pictureBox_1;

	internal Button button_0;

	internal RadioButton radioButton_0;

	internal Panel panel_0;

	internal Label label_0;

	internal Label label_1;

	internal Label label_2;

	internal Label label_3;

	internal Label label_4;

	internal Label label_5;

	internal Label label_6;

	internal RadioButton radioButton_1;

	internal Label label_7;

	internal Button button_1;

	internal Button button_2;

	internal Button button_3;

	internal Label label_8;

	internal Label label_9;

	internal Label label_10;

	internal Label label_11;

	internal Label label_12;

	internal Label label_13;

	internal Label label_14;

	internal Label label_15;

	internal Label label_16;

	internal NumericUpDown numericUpDown_0;

	internal NumericUpDown numericUpDown_1;

	internal Label label_17;

	internal NumericUpDown numericUpDown_2;

	internal Label label_18;

	internal NumericUpDown numericUpDown_3;

	internal Label label_19;

	public F_ImageToVector()
	{
		Class186.smethod_85(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		numericUpDown_1.Value = Settings.DPI;
		numericUpDown_0.Value = Settings.ColorToBWThreshold;
		numericUpDown_3.Value = (decimal)Settings.SplineToleranca;
		numericUpDown_2.Value = (decimal)Settings.SimplifyTolerance;
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = false;
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (PropertiesForm.Result != DialogResult.OK)
		{
			e.Cancel = true;
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	public void LoadLanguage()
	{
		string callMethod = "NestSheetPart LoadLanguage";
		try
		{
			if (Captions.Count >= 33)
			{
				Text = Captions[0];
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
	}

	public void Apply()
	{
		if (string_0.Length <= 0)
		{
		}
		Settings.DPI = (int)numericUpDown_1.Value;
		Settings.ColorToBWThreshold = (int)numericUpDown_0.Value;
		Settings.SplineToleranca = (double)numericUpDown_3.Value;
		Settings.SimplifyTolerance = (double)numericUpDown_2.Value;
		if (image_0 != null)
		{
			pictureBox_1.Image = ConvertToBlackWhite(Color.White);
			imageOutput = ConvertToBlackWhite(Color.White);
		}
	}

	public Image ConvertToBlackWhite(Color BackColor)
	{
		FastBitmap fastBitmap = new FastBitmap(image_0);
		for (int i = 0; i < fastBitmap.Width; i++)
		{
			for (int j = 0; j < fastBitmap.Height; j++)
			{
				if (fastBitmap.GetPixel(i, j).ToArgb() != BackColor.ToArgb())
				{
					fastBitmap.SetPixel(i, j, Color.Black);
				}
			}
		}
		fastBitmap.UnlockBitmap();
		return fastBitmap;
	}

	public void GetColors(string FileName)
	{
		pictureBox_0.Image = Image.FromFile(FileName);
		list_0.Clear();
		FastBitmap fastBitmap = new FastBitmap(Image.FromFile(FileName));
		label_6.BackColor = Color.Gray;
		label_6.BorderStyle = BorderStyle.None;
		label_5.BackColor = Color.Gray;
		label_5.BorderStyle = BorderStyle.None;
		label_4.BackColor = Color.Gray;
		label_4.BorderStyle = BorderStyle.None;
		label_3.BackColor = Color.Gray;
		label_3.BorderStyle = BorderStyle.None;
		label_2.BackColor = Color.Gray;
		label_2.BorderStyle = BorderStyle.None;
		label_1.BackColor = Color.Gray;
		label_1.BorderStyle = BorderStyle.None;
		label_0.BackColor = Color.Gray;
		label_0.BorderStyle = BorderStyle.None;
		label_7.BackColor = Color.Gray;
		label_7.BorderStyle = BorderStyle.None;
		label_15.BackColor = Color.Gray;
		label_15.BorderStyle = BorderStyle.None;
		label_14.BackColor = Color.Gray;
		label_14.BorderStyle = BorderStyle.None;
		label_13.BackColor = Color.Gray;
		label_13.BorderStyle = BorderStyle.None;
		label_12.BackColor = Color.Gray;
		label_12.BorderStyle = BorderStyle.None;
		label_11.BackColor = Color.Gray;
		label_11.BorderStyle = BorderStyle.None;
		label_10.BackColor = Color.Gray;
		label_10.BorderStyle = BorderStyle.None;
		label_9.BackColor = Color.Gray;
		label_9.BorderStyle = BorderStyle.None;
		label_8.BackColor = Color.Gray;
		label_8.BorderStyle = BorderStyle.None;
		for (int i = 0; i < fastBitmap.Width; i++)
		{
			for (int j = 0; j < fastBitmap.Height; j++)
			{
				Color pixel = fastBitmap.GetPixel(i, j);
				if (list_0.Count != 0)
				{
					bool flag = false;
					for (int k = 0; k <= list_0.Count - 1; k++)
					{
						if (buImage5.isColorSimilar(list_0[k], pixel, 100.0))
						{
							flag = true;
							k = list_0.Count;
						}
					}
					if (!flag)
					{
						list_0.Add(pixel);
					}
				}
				else
				{
					list_0.Add(pixel);
				}
			}
		}
		for (int l = 0; l <= list_0.Count - 1; l++)
		{
			if (l == 0)
			{
				label_6.BackColor = list_0[0];
			}
			if (l == 1)
			{
				label_5.BackColor = list_0[1];
			}
			if (l == 2)
			{
				label_4.BackColor = list_0[2];
			}
			if (l == 3)
			{
				label_3.BackColor = list_0[3];
			}
			if (l == 4)
			{
				label_2.BackColor = list_0[4];
			}
			if (l == 5)
			{
				label_1.BackColor = list_0[5];
			}
			if (l == 6)
			{
				label_0.BackColor = list_0[6];
			}
			if (l == 7)
			{
				label_7.BackColor = list_0[7];
			}
			if (l == 8)
			{
				label_15.BackColor = list_0[8];
			}
			if (l == 9)
			{
				label_14.BackColor = list_0[9];
			}
			if (l == 10)
			{
				label_13.BackColor = list_0[10];
			}
			if (l == 11)
			{
				label_12.BackColor = list_0[11];
			}
			if (l == 12)
			{
				label_11.BackColor = list_0[12];
			}
			if (l == 13)
			{
				label_10.BackColor = list_0[13];
			}
			if (l == 14)
			{
				label_9.BackColor = list_0[14];
			}
			if (l == 15)
			{
				label_8.BackColor = list_0[15];
			}
		}
	}

	public void SetColor()
	{
		FastBitmap fastBitmap = new FastBitmap(Image.FromFile(string_0));
		if (list_1.Count > 0)
		{
			for (int i = 0; i < fastBitmap.Width; i++)
			{
				for (int j = 0; j < fastBitmap.Height; j++)
				{
					Color pixel = fastBitmap.GetPixel(i, j);
					bool flag = false;
					for (int k = 0; k <= list_1.Count - 1; k++)
					{
						if (buImage5.isColorSimilar(list_1[k], pixel, 50.0))
						{
							flag = true;
							k = list_1.Count;
						}
					}
					if (!flag)
					{
						fastBitmap.SetPixel(i, j, Color.White);
					}
				}
			}
		}
		fastBitmap.UnlockBitmap();
		pictureBox_1.Image = fastBitmap;
		image_0 = fastBitmap;
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		if ((sender.GetType() == typeof(Control)) | (sender.GetType() == typeof(Button)))
		{
			control = (Control)sender;
			_ = control.Name;
		}
		if (sender.GetType() == typeof(ToolStripMenuItem))
		{
			_ = ((ToolStripMenuItem)sender).Name;
		}
		if (control.Name == button_3.Name)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = pathInit;
			openFileDialog.Multiselect = false;
			openFileDialog.Filter = "All Image Files|*.bmp;*.png;*.jpg;*.jpeg;*.gif|Bmp Files (*.bmp)|*.bmp|Png Files (*.png)|*.png|Jpg Files (*.jpg)|*.jpg|Gif Files (*.gif)|*.gif";
			openFileDialog.FilterIndex = 1;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string_0 = openFileDialog.FileName;
				FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
				pathInit = fileInfo.DirectoryName;
				GetColors(string_0);
			}
		}
		if (control.Name == button_1.Name)
		{
			PropertiesForm.Result = DialogResult.OK;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (!(control.Name == button_2.Name))
		{
		}
		if (control.Name == button_0.Name)
		{
			Apply();
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == label_6.Name)
		{
			if (label_6.BorderStyle != BorderStyle.None)
			{
				label_6.BorderStyle = BorderStyle.None;
				for (int i = 0; i <= list_1.Count - 1; i++)
				{
					if (list_1[i] == label_6.BackColor)
					{
						list_1.RemoveAt(i);
						i = list_1.Count;
					}
					SetColor();
				}
			}
			else
			{
				bool flag = false;
				label_6.BorderStyle = BorderStyle.FixedSingle;
				for (int j = 0; j <= list_1.Count - 1; j++)
				{
					if (list_1[j] == label_6.BackColor)
					{
						flag = true;
					}
				}
				if (!flag)
				{
					list_1.Add(label_6.BackColor);
				}
				SetColor();
			}
		}
		if (control.Name == label_5.Name)
		{
			if (label_5.BorderStyle != BorderStyle.None)
			{
				label_5.BorderStyle = BorderStyle.None;
				for (int k = 0; k <= list_1.Count - 1; k++)
				{
					if (list_1[k] == label_5.BackColor)
					{
						list_1.RemoveAt(k);
						k = list_1.Count;
					}
				}
				SetColor();
			}
			else
			{
				bool flag2 = false;
				label_5.BorderStyle = BorderStyle.FixedSingle;
				for (int l = 0; l <= list_1.Count - 1; l++)
				{
					if (list_1[l] == label_5.BackColor)
					{
						flag2 = true;
					}
				}
				if (!flag2)
				{
					list_1.Add(label_5.BackColor);
				}
				SetColor();
			}
		}
		if (control.Name == label_4.Name)
		{
			if (label_4.BorderStyle != BorderStyle.None)
			{
				label_4.BorderStyle = BorderStyle.None;
				for (int m = 0; m <= list_1.Count - 1; m++)
				{
					if (list_1[m] == label_4.BackColor)
					{
						list_1.RemoveAt(m);
						m = list_1.Count;
					}
					SetColor();
				}
			}
			else
			{
				bool flag3 = false;
				label_4.BorderStyle = BorderStyle.FixedSingle;
				for (int n = 0; n <= list_1.Count - 1; n++)
				{
					if (list_1[n] == label_4.BackColor)
					{
						flag3 = true;
					}
				}
				if (!flag3)
				{
					list_1.Add(label_4.BackColor);
				}
				SetColor();
			}
		}
		if (control.Name == label_3.Name)
		{
			if (label_3.BorderStyle != BorderStyle.None)
			{
				label_3.BorderStyle = BorderStyle.None;
				for (int num = 0; num <= list_1.Count - 1; num++)
				{
					if (list_1[num] == label_3.BackColor)
					{
						list_1.RemoveAt(num);
						num = list_1.Count;
					}
				}
				SetColor();
			}
			else
			{
				bool flag4 = false;
				label_3.BorderStyle = BorderStyle.FixedSingle;
				for (int num2 = 0; num2 <= list_1.Count - 1; num2++)
				{
					if (list_1[num2] == label_3.BackColor)
					{
						flag4 = true;
					}
				}
				if (!flag4)
				{
					list_1.Add(label_3.BackColor);
				}
				SetColor();
			}
		}
		if (control.Name == label_2.Name)
		{
			if (label_2.BorderStyle != BorderStyle.None)
			{
				label_2.BorderStyle = BorderStyle.None;
				for (int num3 = 0; num3 <= list_1.Count - 1; num3++)
				{
					if (list_1[num3] == label_2.BackColor)
					{
						list_1.RemoveAt(num3);
						num3 = list_1.Count;
					}
					SetColor();
				}
			}
			else
			{
				bool flag5 = false;
				label_2.BorderStyle = BorderStyle.FixedSingle;
				for (int num4 = 0; num4 <= list_1.Count - 1; num4++)
				{
					if (list_1[num4] == label_2.BackColor)
					{
						flag5 = true;
					}
				}
				if (!flag5)
				{
					list_1.Add(label_2.BackColor);
				}
				SetColor();
			}
		}
		if (control.Name == label_1.Name)
		{
			if (label_1.BorderStyle != BorderStyle.None)
			{
				label_1.BorderStyle = BorderStyle.None;
				for (int num5 = 0; num5 <= list_1.Count - 1; num5++)
				{
					if (list_1[num5] == label_1.BackColor)
					{
						list_1.RemoveAt(num5);
						num5 = list_1.Count;
					}
				}
				SetColor();
			}
			else
			{
				bool flag6 = false;
				label_1.BorderStyle = BorderStyle.FixedSingle;
				for (int num6 = 0; num6 <= list_1.Count - 1; num6++)
				{
					if (list_1[num6] == label_1.BackColor)
					{
						flag6 = true;
					}
				}
				if (!flag6)
				{
					list_1.Add(label_1.BackColor);
				}
				SetColor();
			}
		}
		if (control.Name == label_0.Name)
		{
			if (label_0.BorderStyle != BorderStyle.None)
			{
				label_0.BorderStyle = BorderStyle.None;
				for (int num7 = 0; num7 <= list_1.Count - 1; num7++)
				{
					if (list_1[num7] == label_0.BackColor)
					{
						list_1.RemoveAt(num7);
						num7 = list_1.Count;
					}
					SetColor();
				}
			}
			else
			{
				bool flag7 = false;
				label_0.BorderStyle = BorderStyle.FixedSingle;
				for (int num8 = 0; num8 <= list_1.Count - 1; num8++)
				{
					if (list_1[num8] == label_0.BackColor)
					{
						flag7 = true;
					}
				}
				if (!flag7)
				{
					list_1.Add(label_0.BackColor);
				}
				SetColor();
			}
		}
		if (control.Name == label_7.Name)
		{
			if (label_7.BorderStyle != BorderStyle.None)
			{
				label_7.BorderStyle = BorderStyle.None;
				for (int num9 = 0; num9 <= list_1.Count - 1; num9++)
				{
					if (list_1[num9] == label_7.BackColor)
					{
						list_1.RemoveAt(num9);
						num9 = list_1.Count;
					}
				}
				SetColor();
			}
			else
			{
				bool flag8 = false;
				label_7.BorderStyle = BorderStyle.FixedSingle;
				for (int num10 = 0; num10 <= list_1.Count - 1; num10++)
				{
					if (list_1[num10] == label_7.BackColor)
					{
						flag8 = true;
					}
				}
				if (!flag8)
				{
					list_1.Add(label_7.BackColor);
				}
				SetColor();
			}
		}
		if (control.Name == label_15.Name)
		{
			if (label_15.BorderStyle != BorderStyle.None)
			{
				label_15.BorderStyle = BorderStyle.None;
				for (int num11 = 0; num11 <= list_1.Count - 1; num11++)
				{
					if (list_1[num11] == label_15.BackColor)
					{
						list_1.RemoveAt(num11);
						num11 = list_1.Count;
					}
					SetColor();
				}
			}
			else
			{
				bool flag9 = false;
				label_15.BorderStyle = BorderStyle.FixedSingle;
				for (int num12 = 0; num12 <= list_1.Count - 1; num12++)
				{
					if (list_1[num12] == label_15.BackColor)
					{
						flag9 = true;
					}
				}
				if (!flag9)
				{
					list_1.Add(label_15.BackColor);
				}
				SetColor();
			}
		}
		if (control.Name == label_14.Name)
		{
			if (label_14.BorderStyle != BorderStyle.None)
			{
				label_14.BorderStyle = BorderStyle.None;
				for (int num13 = 0; num13 <= list_1.Count - 1; num13++)
				{
					if (list_1[num13] == label_14.BackColor)
					{
						list_1.RemoveAt(num13);
						num13 = list_1.Count;
					}
				}
				SetColor();
			}
			else
			{
				bool flag10 = false;
				label_14.BorderStyle = BorderStyle.FixedSingle;
				for (int num14 = 0; num14 <= list_1.Count - 1; num14++)
				{
					if (list_1[num14] == label_14.BackColor)
					{
						flag10 = true;
					}
				}
				if (!flag10)
				{
					list_1.Add(label_14.BackColor);
				}
				SetColor();
			}
		}
		if (control.Name == label_13.Name)
		{
			if (label_13.BorderStyle != BorderStyle.None)
			{
				label_13.BorderStyle = BorderStyle.None;
				for (int num15 = 0; num15 <= list_1.Count - 1; num15++)
				{
					if (list_1[num15] == label_13.BackColor)
					{
						list_1.RemoveAt(num15);
						num15 = list_1.Count;
					}
					SetColor();
				}
			}
			else
			{
				bool flag11 = false;
				label_13.BorderStyle = BorderStyle.FixedSingle;
				for (int num16 = 0; num16 <= list_1.Count - 1; num16++)
				{
					if (list_1[num16] == label_13.BackColor)
					{
						flag11 = true;
					}
				}
				if (!flag11)
				{
					list_1.Add(label_13.BackColor);
				}
				SetColor();
			}
		}
		if (control.Name == label_12.Name)
		{
			if (label_12.BorderStyle != BorderStyle.None)
			{
				label_12.BorderStyle = BorderStyle.None;
				for (int num17 = 0; num17 <= list_1.Count - 1; num17++)
				{
					if (list_1[num17] == label_12.BackColor)
					{
						list_1.RemoveAt(num17);
						num17 = list_1.Count;
					}
				}
				SetColor();
			}
			else
			{
				bool flag12 = false;
				label_12.BorderStyle = BorderStyle.FixedSingle;
				for (int num18 = 0; num18 <= list_1.Count - 1; num18++)
				{
					if (list_1[num18] == label_12.BackColor)
					{
						flag12 = true;
					}
				}
				if (!flag12)
				{
					list_1.Add(label_12.BackColor);
				}
				SetColor();
			}
		}
		if (control.Name == label_11.Name)
		{
			if (label_11.BorderStyle != BorderStyle.None)
			{
				label_11.BorderStyle = BorderStyle.None;
				for (int num19 = 0; num19 <= list_1.Count - 1; num19++)
				{
					if (list_1[num19] == label_11.BackColor)
					{
						list_1.RemoveAt(num19);
						num19 = list_1.Count;
					}
					SetColor();
				}
			}
			else
			{
				bool flag13 = false;
				label_11.BorderStyle = BorderStyle.FixedSingle;
				for (int num20 = 0; num20 <= list_1.Count - 1; num20++)
				{
					if (list_1[num20] == label_11.BackColor)
					{
						flag13 = true;
					}
				}
				if (!flag13)
				{
					list_1.Add(label_11.BackColor);
				}
				SetColor();
			}
		}
		if (control.Name == label_10.Name)
		{
			if (label_10.BorderStyle != BorderStyle.None)
			{
				label_10.BorderStyle = BorderStyle.None;
				for (int num21 = 0; num21 <= list_1.Count - 1; num21++)
				{
					if (list_1[num21] == label_10.BackColor)
					{
						list_1.RemoveAt(num21);
						num21 = list_1.Count;
					}
				}
				SetColor();
			}
			else
			{
				bool flag14 = false;
				label_10.BorderStyle = BorderStyle.FixedSingle;
				for (int num22 = 0; num22 <= list_1.Count - 1; num22++)
				{
					if (list_1[num22] == label_10.BackColor)
					{
						flag14 = true;
					}
				}
				if (!flag14)
				{
					list_1.Add(label_10.BackColor);
				}
				SetColor();
			}
		}
		if (control.Name == label_9.Name)
		{
			if (label_9.BorderStyle != BorderStyle.None)
			{
				label_9.BorderStyle = BorderStyle.None;
				for (int num23 = 0; num23 <= list_1.Count - 1; num23++)
				{
					if (list_1[num23] == label_9.BackColor)
					{
						list_1.RemoveAt(num23);
						num23 = list_1.Count;
					}
					SetColor();
				}
			}
			else
			{
				bool flag15 = false;
				label_9.BorderStyle = BorderStyle.FixedSingle;
				for (int num24 = 0; num24 <= list_1.Count - 1; num24++)
				{
					if (list_1[num24] == label_9.BackColor)
					{
						flag15 = true;
					}
				}
				if (!flag15)
				{
					list_1.Add(label_9.BackColor);
				}
				SetColor();
			}
		}
		if (!(control.Name == label_8.Name))
		{
			return;
		}
		if (label_8.BorderStyle != BorderStyle.None)
		{
			label_8.BorderStyle = BorderStyle.None;
			for (int num25 = 0; num25 <= list_1.Count - 1; num25++)
			{
				if (list_1[num25] == label_8.BackColor)
				{
					list_1.RemoveAt(num25);
					num25 = list_1.Count;
				}
			}
			SetColor();
			return;
		}
		bool flag16 = false;
		label_8.BorderStyle = BorderStyle.FixedSingle;
		for (int num26 = 0; num26 <= list_1.Count - 1; num26++)
		{
			if (list_1[num26] == label_8.BackColor)
			{
				flag16 = true;
			}
		}
		if (!flag16)
		{
			list_1.Add(label_8.BackColor);
		}
		SetColor();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
