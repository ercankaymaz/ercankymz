using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using devDept.Eyeshot;

internal static class _0023_003DzGiJuRymRy3WyGr7bXnnIqH3Q2C1m9f5QCQ_003D_003D
{
	private static readonly string[] _0023_003DzhqqFmMHveZ4K = new string[3]
	{
		_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997741),
		_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997724),
		_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997706)
	};

	private static readonly Regex _0023_003Dzmo9ocFsYiLP1 = new Regex(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997688) + string.Join(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942697), _0023_003DzhqqFmMHveZ4K) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997679));

	public static ShapeFile _0023_003DztXxuGPV1ZW2Y(string _0023_003DzxnkW884_003D, Stream _0023_003DzmSqDt_o_003D)
	{
		ShapeFile shapeFile = null;
		BinaryReader binaryReader = new BinaryReader(_0023_003DzmSqDt_o_003D);
		try
		{
			byte[] array = new byte[100];
			binaryReader.Read(array, 0, 100);
			string input = Encoding.ASCII.GetString(array);
			MatchCollection matchCollection = _0023_003Dzmo9ocFsYiLP1.Matches(input);
			if (matchCollection.Count == 0)
			{
				return null;
			}
			int i;
			for (i = 0; _0023_003DzhqqFmMHveZ4K[i] != matchCollection[0].Groups[1].Value; i++)
			{
			}
			shapeFile = new ShapeFile(_0023_003DzxnkW884_003D)
			{
				ShapeFileType = (ShapeFileType)i
			};
			_0023_003DzmSqDt_o_003D.Seek(matchCollection[0].Length + 3, SeekOrigin.Begin);
			switch (shapeFile.ShapeFileType)
			{
			case ShapeFileType.Unifont:
				_0023_003Dz93Y1Z1jLRU5iIvTD9A_003D_003D(_0023_003DzmSqDt_o_003D, binaryReader, shapeFile);
				break;
			case ShapeFileType.Shape:
				_0023_003DzJhqhqE_0024ACGYdnndWYg_003D_003D(_0023_003DzmSqDt_o_003D, binaryReader, shapeFile);
				break;
			case ShapeFileType.BigFont:
				throw new NotSupportedException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997664));
			}
		}
		finally
		{
			((IDisposable)binaryReader).Dispose();
		}
		return shapeFile;
	}

	private static void _0023_003DzJhqhqE_0024ACGYdnndWYg_003D_003D(Stream _0023_003DzmSqDt_o_003D, BinaryReader _0023_003DzKfoizDE_003D, ShapeFile _0023_003DzOLHnb2M_003D)
	{
		_0023_003DzKfoizDE_003D.ReadUInt16();
		_0023_003DzKfoizDE_003D.ReadUInt16();
		ushort num = _0023_003DzKfoizDE_003D.ReadUInt16();
		List<ShapeSymbol> list = new List<ShapeSymbol>();
		for (int i = 0; i < num; i++)
		{
			ushort aSymbol = _0023_003DzKfoizDE_003D.ReadUInt16();
			ushort aLengthInStream = _0023_003DzKfoizDE_003D.ReadUInt16();
			ShapeSymbol shapeSymbol = new ShapeSymbol(aSymbol, aLengthInStream, _0023_003DzOLHnb2M_003D);
			_0023_003DzOLHnb2M_003D.Add(shapeSymbol);
			list.Add(shapeSymbol);
		}
		foreach (ShapeSymbol item in list)
		{
			StringBuilder stringBuilder = new StringBuilder();
			long position = _0023_003DzmSqDt_o_003D.Position;
			int num2;
			do
			{
				num2 = _0023_003DzKfoizDE_003D.ReadByte();
				if (num2 != 0)
				{
					stringBuilder.Append((char)num2);
				}
			}
			while (num2 != 0);
			item.Name = stringBuilder.ToString();
			int _0023_003DzLOCmKqpg6fLn = (int)(item.LengthInStream - (_0023_003DzmSqDt_o_003D.Position - position));
			_0023_003DzaquIOFMHAuZx(_0023_003DzmSqDt_o_003D, _0023_003DzKfoizDE_003D, _0023_003DzLOCmKqpg6fLn, item, _0023_003Dzy6TVraqh4Rnt: false);
		}
	}

	private static void _0023_003Dz93Y1Z1jLRU5iIvTD9A_003D_003D(Stream _0023_003DzmSqDt_o_003D, BinaryReader _0023_003DzKfoizDE_003D, ShapeFile _0023_003DzOLHnb2M_003D)
	{
		_0023_003DzKfoizDE_003D.ReadUInt32();
		ushort num = _0023_003DzKfoizDE_003D.ReadUInt16();
		_0023_003DzmSqDt_o_003D.Seek(num - 6, SeekOrigin.Current);
		_0023_003DzKfoizDE_003D.ReadByte();
		_0023_003DzKfoizDE_003D.ReadByte();
		_0023_003DzKfoizDE_003D.ReadByte();
		_0023_003DzKfoizDE_003D.ReadByte();
		_0023_003DzKfoizDE_003D.ReadByte();
		_0023_003DzKfoizDE_003D.ReadByte();
		while (_0023_003DzmSqDt_o_003D.Position < _0023_003DzmSqDt_o_003D.Length)
		{
			ushort aSymbol = _0023_003DzKfoizDE_003D.ReadUInt16();
			int num2 = _0023_003DzKfoizDE_003D.ReadUInt16() - 1;
			_0023_003DzKfoizDE_003D.ReadByte();
			ShapeSymbol shapeSymbol = new ShapeSymbol(aSymbol, num2, _0023_003DzOLHnb2M_003D);
			_0023_003DzOLHnb2M_003D.Add(shapeSymbol);
			_0023_003DzaquIOFMHAuZx(_0023_003DzmSqDt_o_003D, _0023_003DzKfoizDE_003D, num2, shapeSymbol, _0023_003Dzy6TVraqh4Rnt: true);
		}
	}

	private static void _0023_003DzaquIOFMHAuZx(Stream _0023_003DzmSqDt_o_003D, BinaryReader _0023_003DzKfoizDE_003D, int _0023_003DzLOCmKqpg6fLn, ShapeSymbol _0023_003DzwaU_0024oWk_003D, bool _0023_003Dzy6TVraqh4Rnt)
	{
		long num = _0023_003DzmSqDt_o_003D.Position + _0023_003DzLOCmKqpg6fLn;
		while (_0023_003DzmSqDt_o_003D.Position < _0023_003DzmSqDt_o_003D.Length && _0023_003DzmSqDt_o_003D.Position < num)
		{
			byte b = _0023_003DzKfoizDE_003D.ReadByte();
			if (b > 15)
			{
				if (_0023_003DzwaU_0024oWk_003D.Items.Count != 0)
				{
					_0023_003DzwaU_0024oWk_003D.Items.Add(new ShapeSymbolRegularLine(b & 0xF, b >> 4));
				}
				continue;
			}
			ShapeCommand shapeCommand = (ShapeCommand)b;
			switch (shapeCommand)
			{
			case ShapeCommand.PenDown:
			case ShapeCommand.PenUp:
			case ShapeCommand.PushCurrentLocationOntoStack:
			case ShapeCommand.PopCurrentLocationFromStack:
			case ShapeCommand.ProcessNextCommandOnlyIfVerticalText:
				_0023_003DzwaU_0024oWk_003D.Items.Add(new ShapeSymbolComponent(shapeCommand));
				break;
			case ShapeCommand.DivideVectorLengths:
			case ShapeCommand.MultiplyVectorLengths:
				_0023_003DzwaU_0024oWk_003D.Items.Add(new ShapeSymbolComponentWithParams(shapeCommand, _0023_003DzmY4wLpw_003D(_0023_003DzKfoizDE_003D, 1)));
				break;
			case ShapeCommand.DrawSubshapeNumberGiven:
				if (_0023_003Dzy6TVraqh4Rnt)
				{
					byte[] array = _0023_003DzKfoizDE_003D.ReadBytes(2);
					Array.Reverse(array);
					int num2 = BitConverter.ToUInt16(array, 0);
					_0023_003DzwaU_0024oWk_003D.Items.Add(new ShapeSymbolComponentWithParams(shapeCommand, new int[1] { num2 }));
				}
				else
				{
					_0023_003DzwaU_0024oWk_003D.Items.Add(new ShapeSymbolComponentWithParams(shapeCommand, _0023_003DzmY4wLpw_003D(_0023_003DzKfoizDE_003D, 1)));
				}
				break;
			case ShapeCommand.XYDisplacement:
			case ShapeCommand.OctantArc:
				_0023_003DzwaU_0024oWk_003D.Items.Add(new ShapeSymbolComponentWithParams(shapeCommand, _0023_003DzmY4wLpw_003D(_0023_003DzKfoizDE_003D, 2)));
				break;
			case ShapeCommand.ArcDefinedByXYDisplacementAndBulge:
				_0023_003DzwaU_0024oWk_003D.Items.Add(new ShapeSymbolComponentWithParams(shapeCommand, _0023_003DzmY4wLpw_003D(_0023_003DzKfoizDE_003D, 3)));
				break;
			case ShapeCommand.FractionalArc:
				_0023_003DzwaU_0024oWk_003D.Items.Add(new ShapeSymbolComponentWithParams(shapeCommand, _0023_003DzmY4wLpw_003D(_0023_003DzKfoizDE_003D, 5)));
				break;
			case ShapeCommand.MultipleXYDisplacements:
				_0023_003DzwaU_0024oWk_003D.Items.Add(new ShapeSymbolComponentWithParams(shapeCommand, _0023_003Dza5zGCxU1jidXR7cbOQ_003D_003D(_0023_003DzKfoizDE_003D, 2)));
				break;
			case ShapeCommand.MultipleBulgeSpecifiedArcs:
				_0023_003DzwaU_0024oWk_003D.Items.Add(new ShapeSymbolComponentWithParams(shapeCommand, _0023_003Dza5zGCxU1jidXR7cbOQ_003D_003D(_0023_003DzKfoizDE_003D, 3)));
				break;
			default:
				throw new NotSupportedException();
			case ShapeCommand.EndOfShape:
				break;
			}
		}
	}

	private static int[] _0023_003DzmY4wLpw_003D(BinaryReader _0023_003DzKfoizDE_003D, int _0023_003DzTLyC4A4_003D)
	{
		int[] array = new int[_0023_003DzTLyC4A4_003D];
		for (int i = 0; i < _0023_003DzTLyC4A4_003D; i++)
		{
			array[i] = _0023_003DzKfoizDE_003D.ReadSByte();
		}
		return array;
	}

	private static int[] _0023_003Dza5zGCxU1jidXR7cbOQ_003D_003D(BinaryReader _0023_003DzKfoizDE_003D, int _0023_003DzTUs21xNPXYii)
	{
		List<int> list = new List<int>();
		bool flag;
		do
		{
			sbyte b = _0023_003DzKfoizDE_003D.ReadSByte();
			sbyte b2 = _0023_003DzKfoizDE_003D.ReadSByte();
			flag = b == 0 && b2 == 0;
			if (!flag)
			{
				list.Add(b);
				list.Add(b2);
				for (int i = 0; i < _0023_003DzTUs21xNPXYii - 2; i++)
				{
					list.Add(_0023_003DzKfoizDE_003D.ReadSByte());
				}
			}
		}
		while (!flag);
		return list.ToArray();
	}
}
