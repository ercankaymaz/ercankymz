using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class PublishedDataSetState : BaseObjectState
{
	private const string DataSetClassId_InitializationString = "//////////8VYIkKAgAAAAAADgAAAERhdGFTZXRDbGFzc0lkAQB3QQAuAER3QQAAAA7/////AQH/////AAAAAA==";

	private const string ExtensionFields_InitializationString = "//////////8EYIAKAQAAAAAADwAAAEV4dGVuc2lvbkZpZWxkcwEAeTwALwEAgTx5PAAA/////wIAAAAEYYIKBAAAAAAAEQAAAEFkZEV4dGVuc2lvbkZpZWxkAQB6PAAvAQCDPHo8AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAezwALgBEezwAAJYCAAAAAQAqAQEYAAAACQAAAEZpZWxkTmFtZQAU/////wAAAAAAAQAqAQEZAAAACgAAAEZpZWxkVmFsdWUAGP7///8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAHw8AC4ARHw8AACWAQAAAAEAKgEBFgAAAAcAAABGaWVsZElkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAUAAAAUmVtb3ZlRXh0ZW5zaW9uRmllbGQBAH08AC8BAIY8fTwAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQB+PAAuAER+PAAAlgEAAAABACoBARYAAAAHAAAARmllbGRJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private const string InitializationString = "//////////8EYIACAQAAAAAAHAAAAFB1Ymxpc2hlZERhdGFTZXRUeXBlSW5zdGFuY2UBAK04AQCtOK04AAD/////BAAAABVgiQoCAAAAAAAUAAAAQ29uZmlndXJhdGlvblZlcnNpb24BALc4AC4ARLc4AAABAAE5/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAERhdGFTZXRNZXRhRGF0YQEAfTsALgBEfTsAAAEAuzj/////AQH/////AAAAABVgiQoCAAAAAAAOAAAARGF0YVNldENsYXNzSWQBAHdBAC4ARHdBAAAADv////8BAf////8AAAAABGCACgEAAAAAAA8AAABFeHRlbnNpb25GaWVsZHMBAHk8AC8BAIE8eTwAAP////8CAAAABGGCCgQAAAAAABEAAABBZGRFeHRlbnNpb25GaWVsZAEAejwALwEAgzx6PAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAHs8AC4ARHs8AACWAgAAAAEAKgEBGAAAAAkAAABGaWVsZE5hbWUAFP////8AAAAAAAEAKgEBGQAAAAoAAABGaWVsZFZhbHVlABj+////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQB8PAAuAER8PAAAlgEAAAABACoBARYAAAAHAAAARmllbGRJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAAFAAAAFJlbW92ZUV4dGVuc2lvbkZpZWxkAQB9PAAvAQCGPH08AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAfjwALgBEfjwAAJYBAAAAAQAqAQEWAAAABwAAAEZpZWxkSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	private PropertyState<ConfigurationVersionDataType> m_configurationVersion;

	private PropertyState<DataSetMetaDataType> m_dataSetMetaData;

	private PropertyState<Guid> m_dataSetClassId;

	private ExtensionFieldsState m_extensionFields;

	public PropertyState<ConfigurationVersionDataType> ConfigurationVersion
	{
		get
		{
			return m_configurationVersion;
		}
		set
		{
			if (m_configurationVersion != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_configurationVersion = value;
		}
	}

	public PropertyState<DataSetMetaDataType> DataSetMetaData
	{
		get
		{
			return m_dataSetMetaData;
		}
		set
		{
			if (m_dataSetMetaData != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_dataSetMetaData = value;
		}
	}

	public PropertyState<Guid> DataSetClassId
	{
		get
		{
			return m_dataSetClassId;
		}
		set
		{
			if (m_dataSetClassId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_dataSetClassId = value;
		}
	}

	public ExtensionFieldsState ExtensionFields
	{
		get
		{
			return m_extensionFields;
		}
		set
		{
			if (m_extensionFields != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_extensionFields = value;
		}
	}

	public PublishedDataSetState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(14509u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAHAAAAFB1Ymxpc2hlZERhdGFTZXRUeXBlSW5zdGFuY2UBAK04AQCtOK04AAD/////BAAAABVgiQoCAAAAAAAUAAAAQ29uZmlndXJhdGlvblZlcnNpb24BALc4AC4ARLc4AAABAAE5/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAERhdGFTZXRNZXRhRGF0YQEAfTsALgBEfTsAAAEAuzj/////AQH/////AAAAABVgiQoCAAAAAAAOAAAARGF0YVNldENsYXNzSWQBAHdBAC4ARHdBAAAADv////8BAf////8AAAAABGCACgEAAAAAAA8AAABFeHRlbnNpb25GaWVsZHMBAHk8AC8BAIE8eTwAAP////8CAAAABGGCCgQAAAAAABEAAABBZGRFeHRlbnNpb25GaWVsZAEAejwALwEAgzx6PAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAHs8AC4ARHs8AACWAgAAAAEAKgEBGAAAAAkAAABGaWVsZE5hbWUAFP////8AAAAAAAEAKgEBGQAAAAoAAABGaWVsZFZhbHVlABj+////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQB8PAAuAER8PAAAlgEAAAABACoBARYAAAAHAAAARmllbGRJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAAFAAAAFJlbW92ZUV4dGVuc2lvbkZpZWxkAQB9PAAvAQCGPH08AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAfjwALgBEfjwAAJYBAAAAAQAqAQEWAAAABwAAAEZpZWxkSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
		InitializeOptionalChildren(context);
	}

	protected override void Initialize(ISystemContext context, NodeState source)
	{
		InitializeOptionalChildren(context);
		base.Initialize(context, source);
	}

	protected override void InitializeOptionalChildren(ISystemContext context)
	{
		base.InitializeOptionalChildren(context);
		if (DataSetClassId != null)
		{
			DataSetClassId.Initialize(context, "//////////8VYIkKAgAAAAAADgAAAERhdGFTZXRDbGFzc0lkAQB3QQAuAER3QQAAAA7/////AQH/////AAAAAA==");
		}
		if (ExtensionFields != null)
		{
			ExtensionFields.Initialize(context, "//////////8EYIAKAQAAAAAADwAAAEV4dGVuc2lvbkZpZWxkcwEAeTwALwEAgTx5PAAA/////wIAAAAEYYIKBAAAAAAAEQAAAEFkZEV4dGVuc2lvbkZpZWxkAQB6PAAvAQCDPHo8AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAezwALgBEezwAAJYCAAAAAQAqAQEYAAAACQAAAEZpZWxkTmFtZQAU/////wAAAAAAAQAqAQEZAAAACgAAAEZpZWxkVmFsdWUAGP7///8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAHw8AC4ARHw8AACWAQAAAAEAKgEBFgAAAAcAAABGaWVsZElkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAUAAAAUmVtb3ZlRXh0ZW5zaW9uRmllbGQBAH08AC8BAIY8fTwAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQB+PAAuAER+PAAAlgEAAAABACoBARYAAAAHAAAARmllbGRJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_configurationVersion != null)
		{
			children.Add(m_configurationVersion);
		}
		if (m_dataSetMetaData != null)
		{
			children.Add(m_dataSetMetaData);
		}
		if (m_dataSetClassId != null)
		{
			children.Add(m_dataSetClassId);
		}
		if (m_extensionFields != null)
		{
			children.Add(m_extensionFields);
		}
		base.GetChildren(context, children);
	}

	protected override BaseInstanceState FindChild(ISystemContext context, QualifiedName browseName, bool createOrReplace, BaseInstanceState replacement)
	{
		if (QualifiedName.IsNull(browseName))
		{
			return null;
		}
		BaseInstanceState baseInstanceState = null;
		switch (browseName.Name)
		{
		case "ConfigurationVersion":
			if (createOrReplace && ConfigurationVersion == null)
			{
				if (replacement == null)
				{
					ConfigurationVersion = new PropertyState<ConfigurationVersionDataType>(this);
				}
				else
				{
					ConfigurationVersion = (PropertyState<ConfigurationVersionDataType>)replacement;
				}
			}
			baseInstanceState = ConfigurationVersion;
			break;
		case "DataSetMetaData":
			if (createOrReplace && DataSetMetaData == null)
			{
				if (replacement == null)
				{
					DataSetMetaData = new PropertyState<DataSetMetaDataType>(this);
				}
				else
				{
					DataSetMetaData = (PropertyState<DataSetMetaDataType>)replacement;
				}
			}
			baseInstanceState = DataSetMetaData;
			break;
		case "DataSetClassId":
			if (createOrReplace && DataSetClassId == null)
			{
				if (replacement == null)
				{
					DataSetClassId = new PropertyState<Guid>(this);
				}
				else
				{
					DataSetClassId = (PropertyState<Guid>)replacement;
				}
			}
			baseInstanceState = DataSetClassId;
			break;
		case "ExtensionFields":
			if (createOrReplace && ExtensionFields == null)
			{
				if (replacement == null)
				{
					ExtensionFields = new ExtensionFieldsState(this);
				}
				else
				{
					ExtensionFields = (ExtensionFieldsState)replacement;
				}
			}
			baseInstanceState = ExtensionFields;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
