using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

public class buMatrix5
{
	private readonly double[,] double_0;

	public int Height => double_0.GetLength(0);

	public int Width => double_0.GetLength(1);

	public double this[int x, int y]
	{
		get
		{
			return double_0[x, y];
		}
		set
		{
			double_0[x, y] = value;
		}
	}

	public buMatrix5()
	{
		if (!buVector5.smethod_0("buMatrix"))
		{
			throw new RegisterException("buMatrix");
		}
	}

	public buMatrix5(int dim1, int dim2)
	{
		double_0 = new double[dim1, dim2];
	}

	public static buMatrix5 CreatMatrix4x4(double m11, double m12, double m13, double m14, double m21, double m22, double m23, double m24, double m31, double m32, double m33, double m34, double m41, double m42, double m43, double m44)
	{
		try
		{
			buMatrix5 buMatrix6 = new buMatrix5(4, 4);
			buMatrix6[0, 0] = m11;
			buMatrix6[0, 1] = m12;
			buMatrix6[0, 2] = m13;
			buMatrix6[0, 3] = m14;
			buMatrix6[1, 0] = m21;
			buMatrix6[1, 1] = m22;
			buMatrix6[1, 2] = m23;
			buMatrix6[1, 3] = m24;
			buMatrix6[2, 0] = m31;
			buMatrix6[2, 1] = m32;
			buMatrix6[2, 2] = m33;
			buMatrix6[2, 3] = m34;
			buMatrix6[3, 0] = m41;
			buMatrix6[3, 1] = m42;
			buMatrix6[3, 2] = m43;
			buMatrix6[3, 3] = m44;
			return buMatrix6;
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return new buMatrix5();
		}
	}

	public static buMatrix5 CreatMatrix4x1(double m11, double m21, double m31, double m41)
	{
		try
		{
			buMatrix5 buMatrix6 = new buMatrix5(4, 1);
			buMatrix6[0, 0] = m11;
			buMatrix6[1, 0] = m21;
			buMatrix6[2, 0] = m31;
			buMatrix6[3, 0] = m41;
			return buMatrix6;
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return new buMatrix5();
		}
	}

	public static void Copy(buMatrix5 refMatrix, ref buMatrix5 copiedMatrix)
	{
		try
		{
			copiedMatrix = new buMatrix5(refMatrix.Width, refMatrix.Height);
			for (int i = 0; i <= refMatrix.Width - 1; i++)
			{
				for (int j = 0; j <= refMatrix.Width - 1; j++)
				{
					copiedMatrix[i, j] = refMatrix[i, j];
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static buMatrix5 Multiply(buMatrix5 m1, buMatrix5 m2)
	{
		try
		{
			buMatrix5 buMatrix6 = new buMatrix5(m1.Height, m2.Width);
			for (int i = 0; i < buMatrix6.Height; i++)
			{
				for (int j = 0; j < buMatrix6.Width; j++)
				{
					buMatrix6[i, j] = 0.0;
					for (int k = 0; k < m1.Width; k++)
					{
						buMatrix6[i, j] += m1[i, k] * m2[k, j];
					}
				}
			}
			return buMatrix6;
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return new buMatrix5();
		}
	}

	public static void SwapRowsColumns(ref buMatrix5 m1)
	{
		try
		{
			buMatrix5 buMatrix6 = new buMatrix5(m1.Height, m1.Width);
			for (int i = 0; i < m1.Width; i++)
			{
				for (int j = 0; j < m1.Height; j++)
				{
					double value = m1[i, j];
					buMatrix6[j, i] = value;
				}
			}
			Copy(buMatrix6, ref m1);
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public override string ToString()
	{
		return "m11" + Environment.NewLine + "m22";
	}
}
