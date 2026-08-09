using System;
using System.Reflection;
using buClass;

namespace buCore;

public class buMatrix
{
	private static string string_0;

	private static string string_1;

	private static string string_2;

	private static string string_3;

	private static double double_0;

	private static double double_1;

	private readonly double[,] double_2;

	public int Height => double_2.GetLength(0);

	public int Width => double_2.GetLength(1);

	public double this[int x, int y]
	{
		get
		{
			return double_2[x, y];
		}
		set
		{
			double_2[x, y] = value;
		}
	}

	public buMatrix()
	{
		if (!buVector.smethod_0("buMatrix"))
		{
			throw new RegisterException("buMatrix");
		}
	}

	public buMatrix(int dim1, int dim2)
	{
		double_2 = new double[dim1, dim2];
	}

	public static buMatrix CreatMatrix4x4(double m11, double m12, double m13, double m14, double m21, double m22, double m23, double m24, double m31, double m32, double m33, double m34, double m41, double m42, double m43, double m44)
	{
		try
		{
			buMatrix buMatrix2 = new buMatrix(4, 4);
			buMatrix2[0, 0] = m11;
			buMatrix2[0, 1] = m12;
			buMatrix2[0, 2] = m13;
			buMatrix2[0, 3] = m14;
			buMatrix2[1, 0] = m21;
			buMatrix2[1, 1] = m22;
			buMatrix2[1, 2] = m23;
			buMatrix2[1, 3] = m24;
			buMatrix2[2, 0] = m31;
			buMatrix2[2, 1] = m32;
			buMatrix2[2, 2] = m33;
			buMatrix2[2, 3] = m34;
			buMatrix2[3, 0] = m41;
			buMatrix2[3, 1] = m42;
			buMatrix2[3, 2] = m43;
			buMatrix2[3, 3] = m44;
			return buMatrix2;
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return new buMatrix();
		}
	}

	public static buMatrix CreatMatrix4x1(double m11, double m21, double m31, double m41)
	{
		try
		{
			buMatrix buMatrix2 = new buMatrix(4, 1);
			buMatrix2[0, 0] = m11;
			buMatrix2[1, 0] = m21;
			buMatrix2[2, 0] = m31;
			buMatrix2[3, 0] = m41;
			return buMatrix2;
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return new buMatrix();
		}
	}

	public static void Copy(buMatrix refMatrix, ref buMatrix copiedMatrix)
	{
		try
		{
			copiedMatrix = new buMatrix(refMatrix.Height, refMatrix.Width);
			for (int i = 0; i <= refMatrix.Height - 1; i++)
			{
				for (int j = 0; j <= refMatrix.Width - 1; j++)
				{
					copiedMatrix[i, j] = refMatrix[i, j];
				}
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	public static buMatrix Multiply(buMatrix m1, buMatrix m2)
	{
		try
		{
			buMatrix buMatrix2 = new buMatrix(m1.Height, m2.Width);
			for (int i = 0; i < buMatrix2.Height; i++)
			{
				for (int j = 0; j < buMatrix2.Width; j++)
				{
					buMatrix2[i, j] = 0.0;
					for (int k = 0; k < m1.Width; k++)
					{
						buMatrix2[i, j] += m1[i, k] * m2[k, j];
					}
				}
			}
			return buMatrix2;
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return new buMatrix();
		}
	}

	public static void SwapRowsColumns(ref buMatrix m1)
	{
		try
		{
			buMatrix buMatrix2 = new buMatrix(m1.Height, m1.Width);
			for (int i = 0; i < m1.Width; i++)
			{
				for (int j = 0; j < m1.Height; j++)
				{
					double value = m1[i, j];
					buMatrix2[j, i] = value;
				}
			}
			Copy(buMatrix2, ref m1);
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

	static buMatrix()
	{
		string_0 = "fduyfuFDSGERTHSAF-*05435/&%(hgfdhgfHGFHGFHvxcvcvTREQWEFVFDNB gR E%YT%E";
		string_1 = "QWEFGHLJHGFhjklopoıuygtfc-*098h?=)(/TFDERTYUI)OKNBVFDRErd345678uhgfdXCVBHJ/&%RDW^+%&/()=)(/TRFCVBNYTrEDSX";
		string_2 = "";
		string_3 = "";
		double_0 = 0.0;
		double_1 = 0.0;
	}
}
