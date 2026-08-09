using System;
using System.Collections.Generic;
using System.Linq;
using ACadSharp.Header;

namespace ACadSharp.IO;

public class DxfWriterConfiguration : CadWriterConfiguration
{
	public static readonly string[] Variables = new string[40]
	{
		"$ACADVER", "$DWGCODEPAGE", "$LASTSAVEDBY", "$HANDSEED", "$ANGBASE", "$ANGDIR", "$ATTMODE", "$AUNITS", "$AUPREC", "$CECOLOR",
		"$CELTSCALE", "$CELTYPE", "$CELWEIGHT", "$CLAYER", "$CMLJUST", "$CMLSCALE", "$CMLSTYLE", "$DIMSTYLE", "$TEXTSIZE", "$TEXTSTYLE",
		"$LUNITS", "$LUPREC", "$MIRRTEXT", "$EXTNAMES", "$INSBASE", "$INSUNITS", "$LTSCALE", "$LWDISPLAY", "$PDMODE", "$PDSIZE",
		"$PLINEGEN", "$PSLTSCALE", "$SPLINESEGS", "$SURFU", "$SURFV", "$TDCREATE", "$TDUCREATE", "$TDUPDATE", "$TDUUPDATE", "$TDINDWG"
	};

	private HashSet<string> _headerVariables;

	public bool WriteAllHeaderVariables { get; set; }

	public bool WriteOptionalValues { get; set; } = true;

	public IEnumerable<string> HeaderVariables => _headerVariables.AsEnumerable();

	public DxfWriterConfiguration()
	{
		_headerVariables = new HashSet<string>(Variables);
	}

	public void AddHeaderVariable(string name)
	{
		if (!CadHeader.GetHeaderMap().ContainsKey(name))
		{
			throw new ArgumentException("The variable " + name + " does not exist in the header", "name");
		}
		_headerVariables.Add(name);
	}

	public bool RemoveHeaderVariable(string name)
	{
		if (Variables.Select((string v) => v.ToLowerInvariant()).Contains(name.ToLowerInvariant()))
		{
			throw new ArgumentException("The variable " + name + " cannot be removed from the set", "name");
		}
		return _headerVariables.Remove(name);
	}
}
