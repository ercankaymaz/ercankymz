using System.Collections.Generic;

namespace devDept.Geometry;

public class Equation
{
	public List<Coefficient> Coefficients;

	public Coefficient this[int pos]
	{
		get
		{
			Coefficient coefficient = new Coefficient(pos, 0.0);
			int num = Coefficients.IndexOf(coefficient);
			if (num == -1)
			{
				coefficient.Pos = -1;
				return coefficient;
			}
			return Coefficients[num];
		}
	}

	public Equation()
	{
	}

	public Equation(int size)
	{
		Coefficients = new List<Coefficient>(size);
	}

	public void Add(int pos, double val)
	{
		Coefficient item = new Coefficient(pos, val);
		int num = Coefficients.IndexOf(item);
		if (num == -1)
		{
			int count = Coefficients.Count;
			for (int i = 0; i < count; i++)
			{
				if (Coefficients[i].Pos > item.Pos)
				{
					Coefficients.Insert(i - 1, item);
				}
			}
			if (Coefficients.Count == count)
			{
				Coefficients.Add(item);
			}
		}
		else
		{
			Coefficients[num] = new Coefficient(item.Pos, Coefficients[num].Val + val);
		}
	}

	public void RemoveAt(int pos)
	{
		Coefficient item = new Coefficient(pos, 0.0);
		int num = Coefficients.IndexOf(item);
		if (num == -1)
		{
			if (Coefficients[0].Pos > pos)
			{
				for (int i = 0; i < Coefficients.Count; i++)
				{
					item = Coefficients[i];
					Coefficients[i] = new Coefficient(item.Pos - 1, item.Val);
				}
			}
			return;
		}
		for (int j = 0; j < Coefficients.Count; j++)
		{
			item = Coefficients[j];
			if (item.Pos > pos)
			{
				Coefficients[j] = new Coefficient(item.Pos - 1, item.Val);
			}
		}
		Coefficients.RemoveAt(num);
	}

	public double MultiplyBy(double[] x)
	{
		double num = 0.0;
		int count = Coefficients.Count;
		for (int i = 0; i < count; i++)
		{
			Coefficient coefficient = Coefficients[i];
			num += coefficient.Val * x[coefficient.Pos];
		}
		return num;
	}

	public double MultiplyBy(int rowIndex, int[] I, List<int> J, List<double> A, double[] x)
	{
		double num = 0.0;
		int num2 = I[rowIndex + 1] - I[rowIndex];
		for (int i = 0; i < num2; i++)
		{
			num += A[rowIndex + i] * x[J[rowIndex + i]];
		}
		return num;
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657725), Coefficients.Count);
	}
}
