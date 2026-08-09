using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Xml;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
public class IdPath
{
	public List<Id> path = new List<Id>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly char[] _0023_003DzMlZa_rgNruGW = new char[1] { '/' };

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly char[] _0023_003DzVbFsxeywijuY = new char[1] { ':' };

	internal IdPath()
	{
	}

	public bool Empty()
	{
		return path.Count == 0;
	}

	public void Parse(string str)
	{
		string[] array = str.Split(_0023_003DzMlZa_rgNruGW, StringSplitOptions.RemoveEmptyEntries);
		path.Clear();
		for (int i = 0; i < array.Length; i++)
		{
			string[] array2 = array[i].Split(_0023_003DzVbFsxeywijuY);
			int num = ((array2[0][0] != '-') ? 1 : (-1));
			if (num < 0)
			{
				array2[0] = array2[0].Remove(0, 1);
			}
			long _0023_003Dz77g161c_003D = num * long.Parse(array2[0], NumberStyles.HexNumber);
			long _0023_003DzuwH5j5s_003D = 0L;
			if (array2.Length > 1)
			{
				int num2 = ((array2[1][0] != '-') ? 1 : (-1));
				if (num2 < 0)
				{
					array2[1] = array2[1].Remove(0, 1);
				}
				_0023_003DzuwH5j5s_003D = num2 * long.Parse(array2[1], NumberStyles.HexNumber);
			}
			path.Add(new Id(_0023_003Dz77g161c_003D, _0023_003DzuwH5j5s_003D));
		}
	}

	public IdPath Clone()
	{
		return new IdPath
		{
			path = new List<Id>(path)
		};
	}

	public IdPath With(Id id)
	{
		IdPath idPath = Clone();
		idPath.path.Add(id);
		return idPath;
	}

	public static IdPath From(string str)
	{
		IdPath idPath = new IdPath();
		idPath.Parse(str);
		return idPath;
	}

	public override string ToString()
	{
		string text = string.Empty;
		for (int i = 0; i < path.Count; i++)
		{
			if (i != 0)
			{
				text += _0023_003DzMlZa_rgNruGW[0];
			}
			if (path[i].value < 0)
			{
				text += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302915752);
			}
			text += Math.Abs(path[i].value).ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981817));
			if (path[i].second != 0L)
			{
				text += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302926862);
				if (path[i].second < 0)
				{
					text += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302915752);
				}
				text += Math.Abs(path[i].second).ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981817));
			}
		}
		return text;
	}

	public void Write(XmlTextWriter xml, string name)
	{
		string text = ToString();
		if (!(text == string.Empty))
		{
			xml.WriteStartElement(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656140));
			xml.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302927346), name);
			xml.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655090), text);
			xml.WriteEndElement();
		}
	}

	public void Read(XmlNode xml)
	{
		path.Clear();
		Parse(xml.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655090)].Value);
	}

	public static bool operator ==(IdPath a, IdPath b)
	{
		if (a.path.Count != b.path.Count)
		{
			return false;
		}
		for (int i = 0; i < a.path.Count; i++)
		{
			if (a.path[i] != b.path[i])
			{
				return false;
			}
		}
		return true;
	}

	public static bool operator !=(IdPath a, IdPath b)
	{
		return !(a == b);
	}

	public override int GetHashCode()
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < path.Count; i++)
		{
			num2 = (num2 + 11) % 21;
			num ^= (int)path[i].value + 1024 << num2;
		}
		return num;
	}

	public override bool Equals(object obj)
	{
		return this == obj as IdPath;
	}

	public virtual IdPathSurrogate ConvertToSurrogate()
	{
		return new IdPathSurrogate(this);
	}
}
