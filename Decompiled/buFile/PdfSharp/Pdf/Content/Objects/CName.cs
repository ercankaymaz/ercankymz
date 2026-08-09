using System;
using System.Diagnostics;

namespace PdfSharp.Pdf.Content.Objects;

[DebuggerDisplay("({Name})")]
public class CName : CObject
{
	private string _name;

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			if (string.IsNullOrEmpty(_name))
			{
				throw new ArgumentNullException("value");
			}
			if (_name[0] != '/')
			{
				throw new ArgumentException(PSSR.NameMustStartWithSlash);
			}
			_name = value;
		}
	}

	public CName()
	{
		_name = "/";
	}

	public CName(string name)
	{
		Name = name;
	}

	public new CName Clone()
	{
		return (CName)Copy();
	}

	protected override CObject Copy()
	{
		return base.Copy();
	}

	public override string ToString()
	{
		return _name;
	}

	internal override void WriteObject(ContentWriter writer)
	{
		writer.WriteRaw(ToString() + " ");
	}
}
