using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Fem;

public class Equation : devDept.Geometry.Equation
{
	private sealed class _0023_003DzJ0wy9bhjemv3bnsTuw_003D_003D
	{
		public int _0023_003DzZNiXTYE_003D;

		internal bool _0023_003DzzZfjV_0024Ssqnno(int _0023_003DzoMNiNRw_003D)
		{
			return _0023_003DzoMNiNRw_003D < _0023_003DzZNiXTYE_003D;
		}
	}

	private sealed class _0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D
	{
		public int _0023_003DzZNiXTYE_003D;

		internal bool _0023_003DzzZfjV_0024Ssqnno(int _0023_003DzoMNiNRw_003D)
		{
			return _0023_003DzoMNiNRw_003D < _0023_003DzZNiXTYE_003D;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int[] _0023_003Dzj1308obu8RPq;

	public bool Restrained;

	public double FixedDispl;

	public LinkedList<int> elements;

	public Equation()
	{
		Restrained = false;
		elements = new LinkedList<int>();
		Coefficients = new List<Coefficient>();
	}

	public void Process(int rowIndex, int[] indicesMap, double[] rowValues, FemMesh mesh, int numberOfDimensions, bool freeMem, bool mass)
	{
		_0023_003DzJ0wy9bhjemv3bnsTuw_003D_003D CS_0024_003C_003E8__locals4 = new _0023_003DzJ0wy9bhjemv3bnsTuw_003D_003D();
		CS_0024_003C_003E8__locals4._0023_003DzZNiXTYE_003D = rowIndex;
		HashSet<int> hashSet = new HashSet<int>();
		_0023_003DztSKgP_s_003D(CS_0024_003C_003E8__locals4._0023_003DzZNiXTYE_003D, indicesMap, rowValues, mesh, numberOfDimensions, hashSet, freeMem, mass);
		if (Restrained)
		{
			foreach (int item in hashSet)
			{
				Coefficients.Add(new Coefficient(item, rowValues[item]));
			}
		}
		hashSet.RemoveWhere((int _0023_003DzoMNiNRw_003D) => _0023_003DzoMNiNRw_003D < CS_0024_003C_003E8__locals4._0023_003DzZNiXTYE_003D);
		int[] array = hashSet.ToArray();
		Array.Sort(array);
		int num = Array.IndexOf(array, CS_0024_003C_003E8__locals4._0023_003DzZNiXTYE_003D);
		_0023_003Dzj1308obu8RPq = new int[array.Length - num];
		array.CopyTo(_0023_003Dzj1308obu8RPq, num);
	}

	private void _0023_003DztSKgP_s_003D(int _0023_003DzZNiXTYE_003D, int[] _0023_003Dzq2Pn86ffSKxt, double[] _0023_003DzdT3hIFATMINs, FemMesh _0023_003DzGGJSiQk_003D, int _0023_003DzOJEzl_0024r9OZ5J, HashSet<int> _0023_003DzuOMylKfpuJP0, bool _0023_003Dz2EHtsgqPct3H, bool _0023_003DzZZ1x4JqOx404)
	{
		LinkedListNode<int> linkedListNode = elements.First;
		if (linkedListNode == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984824));
		}
		do
		{
			Element element = _0023_003DzGGJSiQk_003D.elements[linkedListNode.Value];
			int[] connection = element.Connection;
			int num = connection.Length;
			for (int i = 0; i < num; i++)
			{
				int num2 = connection[i];
				for (int j = 0; j < _0023_003DzOJEzl_0024r9OZ5J; j++)
				{
					if (num2 * _0023_003DzOJEzl_0024r9OZ5J + j != _0023_003DzZNiXTYE_003D)
					{
						continue;
					}
					for (int k = 0; k < num; k++)
					{
						for (int l = 0; l < _0023_003DzOJEzl_0024r9OZ5J; l++)
						{
							int num3 = connection[k] * _0023_003DzOJEzl_0024r9OZ5J + l;
							int num4 = _0023_003Dzq2Pn86ffSKxt[num3];
							if (num4 != -1)
							{
								_0023_003DzuOMylKfpuJP0.Add(num3);
								if (_0023_003DzZZ1x4JqOx404)
								{
									_0023_003DzdT3hIFATMINs[num4] += element.MassMatrix[i * _0023_003DzOJEzl_0024r9OZ5J + j, k * _0023_003DzOJEzl_0024r9OZ5J + l];
								}
								else
								{
									_0023_003DzdT3hIFATMINs[num4] += element.StiffnessMatrix[i * _0023_003DzOJEzl_0024r9OZ5J + j, k * _0023_003DzOJEzl_0024r9OZ5J + l];
								}
							}
						}
					}
				}
			}
			if (_0023_003Dz2EHtsgqPct3H && _0023_003DzZNiXTYE_003D >= element.maxConn * _0023_003DzOJEzl_0024r9OZ5J + _0023_003DzOJEzl_0024r9OZ5J - 1)
			{
				element._0023_003Dzxlnq6Q__3EAt();
			}
			linkedListNode = linkedListNode.Next;
		}
		while (linkedListNode != null);
		if (_0023_003DzZZ1x4JqOx404)
		{
			elements = null;
		}
	}

	public void Compress(int index, int[] indicesMap, double[] rowValues, List<int> J, List<double> A, Equation[] equations, double[] b, ref bool zeroOnDiagonal)
	{
		double num = rowValues[index];
		if (!zeroOnDiagonal && num == 0.0)
		{
			zeroOnDiagonal = true;
		}
		if (Restrained)
		{
			A.Add(num);
			J.Add(index);
			b[index] = num * FixedDispl;
			for (int i = 1; i < _0023_003Dzj1308obu8RPq.Length; i++)
			{
				int num2 = _0023_003Dzj1308obu8RPq[i];
				if (!equations[num2].Restrained)
				{
					b[num2] -= rowValues[num2] * FixedDispl;
				}
			}
		}
		else
		{
			int[] array = _0023_003Dzj1308obu8RPq;
			foreach (int num3 in array)
			{
				int num4 = indicesMap[num3];
				double item = rowValues[num4];
				A.Add(item);
				J.Add(num4);
			}
		}
		_0023_003Dzj1308obu8RPq = null;
	}

	public void Process(int rowIndex, double[] rowValues, FemMesh mesh, int numberOfDimensions, bool freeMem)
	{
		_0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D CS_0024_003C_003E8__locals4 = new _0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D();
		CS_0024_003C_003E8__locals4._0023_003DzZNiXTYE_003D = rowIndex;
		HashSet<int> hashSet = new HashSet<int>();
		_0023_003DztSKgP_s_003D(CS_0024_003C_003E8__locals4._0023_003DzZNiXTYE_003D, rowValues, mesh, numberOfDimensions, hashSet, freeMem);
		if (Restrained)
		{
			foreach (int item in hashSet)
			{
				Coefficients.Add(new Coefficient(item, rowValues[item]));
			}
		}
		hashSet.RemoveWhere((int _0023_003DzoMNiNRw_003D) => _0023_003DzoMNiNRw_003D < CS_0024_003C_003E8__locals4._0023_003DzZNiXTYE_003D);
		int[] array = hashSet.ToArray();
		Array.Sort(array);
		int num = Array.IndexOf(array, CS_0024_003C_003E8__locals4._0023_003DzZNiXTYE_003D);
		_0023_003Dzj1308obu8RPq = new int[array.Length - num];
		array.CopyTo(_0023_003Dzj1308obu8RPq, num);
	}

	private void _0023_003DzWfgABrg_003D(int _0023_003DzZNiXTYE_003D, double[] _0023_003DzdT3hIFATMINs, FemMesh _0023_003DzGGJSiQk_003D, int _0023_003DzOJEzl_0024r9OZ5J, Equation[] _0023_003DzXMVGBHVmumq2ImENew_003D_003D, bool _0023_003DzyQQl6GrmRVQG)
	{
		LinkedListNode<int> linkedListNode = elements.First;
		do
		{
			Element element = _0023_003DzGGJSiQk_003D.elements[linkedListNode.Value];
			int num = element.StiffnessMatrix.GetLength(0) / _0023_003DzOJEzl_0024r9OZ5J;
			int[] connection = element.Connection;
			for (int i = 0; i < num; i++)
			{
				int num2 = connection[i];
				for (int j = 0; j < _0023_003DzOJEzl_0024r9OZ5J; j++)
				{
					if (num2 * _0023_003DzOJEzl_0024r9OZ5J + j != _0023_003DzZNiXTYE_003D)
					{
						continue;
					}
					for (int k = 0; k < num; k++)
					{
						for (int l = 0; l < _0023_003DzOJEzl_0024r9OZ5J; l++)
						{
							int num3 = connection[k] * _0023_003DzOJEzl_0024r9OZ5J + l;
							_0023_003DzdT3hIFATMINs[num3] += element.StiffnessMatrix[i * _0023_003DzOJEzl_0024r9OZ5J + j, k * _0023_003DzOJEzl_0024r9OZ5J + l];
						}
					}
				}
			}
			linkedListNode = linkedListNode.Next;
		}
		while (linkedListNode != null);
	}

	private void _0023_003DztSKgP_s_003D(int _0023_003DzZNiXTYE_003D, double[] _0023_003DzdT3hIFATMINs, FemMesh _0023_003DzGGJSiQk_003D, int _0023_003DzOJEzl_0024r9OZ5J, HashSet<int> _0023_003DzuOMylKfpuJP0, bool _0023_003Dz2EHtsgqPct3H)
	{
		LinkedListNode<int> linkedListNode = elements.First;
		if (linkedListNode == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984824));
		}
		do
		{
			Element element = _0023_003DzGGJSiQk_003D.elements[linkedListNode.Value];
			int[] connection = element.Connection;
			int num = connection.Length;
			for (int i = 0; i < num; i++)
			{
				int num2 = connection[i];
				for (int j = 0; j < _0023_003DzOJEzl_0024r9OZ5J; j++)
				{
					if (num2 * _0023_003DzOJEzl_0024r9OZ5J + j != _0023_003DzZNiXTYE_003D)
					{
						continue;
					}
					for (int k = 0; k < num; k++)
					{
						for (int l = 0; l < _0023_003DzOJEzl_0024r9OZ5J; l++)
						{
							int num3 = connection[k] * _0023_003DzOJEzl_0024r9OZ5J + l;
							_0023_003DzuOMylKfpuJP0.Add(num3);
							_0023_003DzdT3hIFATMINs[num3] += element.StiffnessMatrix[i * _0023_003DzOJEzl_0024r9OZ5J + j, k * _0023_003DzOJEzl_0024r9OZ5J + l];
						}
					}
				}
			}
			if (_0023_003Dz2EHtsgqPct3H && _0023_003DzZNiXTYE_003D >= element.maxConn * _0023_003DzOJEzl_0024r9OZ5J + _0023_003DzOJEzl_0024r9OZ5J - 1)
			{
				element._0023_003Dzxlnq6Q__3EAt();
			}
			linkedListNode = linkedListNode.Next;
		}
		while (linkedListNode != null);
	}

	private void _0023_003DzgqLaSAoEU9wCTFbexg_003D_003D(int _0023_003DzZNiXTYE_003D, double[] _0023_003DzdT3hIFATMINs, Equation[] _0023_003DzXMVGBHVmumq2ImENew_003D_003D, double[] _0023_003Dz1v6oPQk_003D, bool _0023_003DzenInTiPm9TTaN4R5OQ_003D_003D)
	{
	}

	private bool _0023_003Dzrz_P2ug_003D(double[] _0023_003Dz90qRVXE_003D, out int[] _0023_003DzGhldIPw_003D, out double[] _0023_003DzHSO_00246A0_003D)
	{
		int num = 0;
		int num2 = _0023_003Dz90qRVXE_003D.Length;
		for (int i = 0; i < num2; i++)
		{
			if (_0023_003Dz90qRVXE_003D[i] != 0.0 && !Restrained)
			{
				num++;
			}
		}
		if (num == 0)
		{
			_0023_003DzGhldIPw_003D = null;
			_0023_003DzHSO_00246A0_003D = null;
			return false;
		}
		_0023_003DzHSO_00246A0_003D = new double[num];
		_0023_003DzGhldIPw_003D = new int[num];
		num = 0;
		int num3 = 0;
		for (int j = 0; j < num2; j++)
		{
			if (Restrained)
			{
				num3--;
			}
			if (_0023_003Dz90qRVXE_003D[j] != 0.0)
			{
				_0023_003DzHSO_00246A0_003D[num] = _0023_003Dz90qRVXE_003D[j];
				_0023_003DzGhldIPw_003D[num] = j + num3;
				num++;
			}
		}
		return true;
	}

	public void Compress(int index, double[] rowValues, List<int> J, List<double> A, Equation[] equations, double[] b, ref bool zeroOnDiagonal)
	{
		double num = rowValues[index];
		if (!zeroOnDiagonal && num == 0.0)
		{
			zeroOnDiagonal = true;
		}
		if (Restrained)
		{
			A.Add(num);
			J.Add(index);
			b[index] = num * FixedDispl;
			for (int i = 1; i < _0023_003Dzj1308obu8RPq.Length; i++)
			{
				int num2 = _0023_003Dzj1308obu8RPq[i];
				if (!equations[num2].Restrained)
				{
					b[num2] -= rowValues[num2] * FixedDispl;
				}
			}
		}
		else
		{
			int[] array = _0023_003Dzj1308obu8RPq;
			foreach (int num3 in array)
			{
				double num4 = rowValues[num3];
				Equation equation = equations[num3];
				if (equation.Restrained)
				{
					b[index] -= num4 * equation.FixedDispl;
					continue;
				}
				A.Add(num4);
				J.Add(num3);
			}
		}
		_0023_003Dzj1308obu8RPq = null;
	}
}
