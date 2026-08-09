using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Serialization;

namespace Opc.Ua.Export;

[Serializable]
[GeneratedCode("xsd", "4.8.3928.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://opcfoundation.org/UA/2011/03/UANodeSet.xsd")]
[ComVisible(true)]
public class UAVariable : UAInstance
{
	private XmlElement valueField;

	private TranslationType[] translationField;

	private string dataTypeField;

	private int valueRankField;

	private string arrayDimensionsField;

	private uint accessLevelField;

	private uint userAccessLevelField;

	private double minimumSamplingIntervalField;

	private bool historizingField;

	public XmlElement Value
	{
		get
		{
			return valueField;
		}
		set
		{
			valueField = value;
		}
	}

	[XmlElement("Translation")]
	public TranslationType[] Translation
	{
		get
		{
			return translationField;
		}
		set
		{
			translationField = value;
		}
	}

	[XmlAttribute]
	[DefaultValue("i=24")]
	public string DataType
	{
		get
		{
			return dataTypeField;
		}
		set
		{
			dataTypeField = value;
		}
	}

	[XmlAttribute]
	[DefaultValue(-1)]
	public int ValueRank
	{
		get
		{
			return valueRankField;
		}
		set
		{
			valueRankField = value;
		}
	}

	[XmlAttribute(DataType = "token")]
	[DefaultValue("")]
	public string ArrayDimensions
	{
		get
		{
			return arrayDimensionsField;
		}
		set
		{
			arrayDimensionsField = value;
		}
	}

	[XmlAttribute]
	[DefaultValue(typeof(uint), "1")]
	public uint AccessLevel
	{
		get
		{
			return accessLevelField;
		}
		set
		{
			accessLevelField = value;
		}
	}

	[XmlAttribute]
	[DefaultValue(typeof(uint), "1")]
	public uint UserAccessLevel
	{
		get
		{
			return userAccessLevelField;
		}
		set
		{
			userAccessLevelField = value;
		}
	}

	[XmlAttribute]
	[DefaultValue(0.0)]
	public double MinimumSamplingInterval
	{
		get
		{
			return minimumSamplingIntervalField;
		}
		set
		{
			minimumSamplingIntervalField = value;
		}
	}

	[XmlAttribute]
	[DefaultValue(false)]
	public bool Historizing
	{
		get
		{
			return historizingField;
		}
		set
		{
			historizingField = value;
		}
	}

	public UAVariable()
	{
		dataTypeField = "i=24";
		valueRankField = -1;
		arrayDimensionsField = "";
		accessLevelField = 1u;
		userAccessLevelField = 1u;
		minimumSamplingIntervalField = 0.0;
		historizingField = false;
	}
}
