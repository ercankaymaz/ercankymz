using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace devDept.Eyeshot.Triangulation.Dicom;

public class DicomElement
{
	public enum dicomNodeType
	{
		Unknown,
		Patient,
		SopClass,
		Study,
		Series,
		Instance,
		Tag
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzWK2AcfIao3SGfq2PBA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private dicomNodeType _0023_003Dz9wrEy7PCLqf6o94BWDfgf1c_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<DicomElement> _0023_003DzyBU2Gv8_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DicomElement _0023_003Dz5CP9OJq_002414veMFtz0w_003D_003D;

	public string Header
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzWK2AcfIao3SGfq2PBA_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzWK2AcfIao3SGfq2PBA_003D_003D = value;
		}
	}

	public dicomNodeType DicomNode
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz9wrEy7PCLqf6o94BWDfgf1c_003D;
		}
	}

	public virtual List<DicomElement> Elements
	{
		get
		{
			return _0023_003DzyBU2Gv8_003D;
		}
		set
		{
			_0023_003DzyBU2Gv8_003D = value;
		}
	}

	public DicomElement Parent
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz5CP9OJq_002414veMFtz0w_003D_003D;
		}
	}

	internal DicomElement(string _0023_003Dz8Vwa6Pc_003D, DicomElement _0023_003Dzalvl9z8_003D = null)
		: this(_0023_003Dz8Vwa6Pc_003D, dicomNodeType.Unknown, _0023_003Dzalvl9z8_003D)
	{
	}

	public DicomElement(string header, dicomNodeType dicomNode, DicomElement parent = null)
	{
		Header = header;
		_0023_003DzgXaxgZUkSvb1VBtgkw_003D_003D(dicomNode);
		_0023_003Dz4lPRWNA_003D(parent);
		_0023_003DzyBU2Gv8_003D = new List<DicomElement>();
	}

	private void _0023_003DzgXaxgZUkSvb1VBtgkw_003D_003D(dicomNodeType _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dz9wrEy7PCLqf6o94BWDfgf1c_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003Dz4lPRWNA_003D(DicomElement _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dz5CP9OJq_002414veMFtz0w_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public override string ToString()
	{
		return Header;
	}
}
