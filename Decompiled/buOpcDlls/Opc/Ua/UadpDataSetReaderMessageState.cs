using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class UadpDataSetReaderMessageState : DataSetReaderMessageState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAJAAAAFVhZHBEYXRhU2V0UmVhZGVyTWVzc2FnZVR5cGVJbnN0YW5jZQEAfFIBAHxSfFIAAP////8JAAAAFWCJCgIAAAAAAAwAAABHcm91cFZlcnNpb24BAH1SAC4ARH1SAAABAAZS/////wEB/////wAAAAAVYIkKAgAAAAAAFAAAAE5ldHdvcmtNZXNzYWdlTnVtYmVyAQB/UgAuAER/UgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAANAAAARGF0YVNldE9mZnNldAEARUQALgBERUQAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAERhdGFTZXRDbGFzc0lkAQCAUgAuAESAUgAAAA7/////AQH/////AAAAABVgiQoCAAAAAAAZAAAATmV0d29ya01lc3NhZ2VDb250ZW50TWFzawEAgVIALgBEgVIAAAEAGj3/////AQH/////AAAAABVgiQoCAAAAAAAZAAAARGF0YVNldE1lc3NhZ2VDb250ZW50TWFzawEAglIALgBEglIAAAEAHj3/////AQH/////AAAAABVgiQoCAAAAAAASAAAAUHVibGlzaGluZ0ludGVydmFsAQCDUgAuAESDUgAAAQAiAf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABQcm9jZXNzaW5nT2Zmc2V0AQCEUgAuAESEUgAAAQAiAf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABSZWNlaXZlT2Zmc2V0AQCFUgAuAESFUgAAAQAiAf////8BAf////8AAAAA";

	private PropertyState<uint> m_groupVersion;

	private PropertyState<ushort> m_networkMessageNumber;

	private PropertyState<ushort> m_dataSetOffset;

	private PropertyState<Guid> m_dataSetClassId;

	private PropertyState<uint> m_networkMessageContentMask;

	private PropertyState<uint> m_dataSetMessageContentMask;

	private PropertyState<double> m_publishingInterval;

	private PropertyState<double> m_processingOffset;

	private PropertyState<double> m_receiveOffset;

	public PropertyState<uint> GroupVersion
	{
		get
		{
			return m_groupVersion;
		}
		set
		{
			if (m_groupVersion != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_groupVersion = value;
		}
	}

	public PropertyState<ushort> NetworkMessageNumber
	{
		get
		{
			return m_networkMessageNumber;
		}
		set
		{
			if (m_networkMessageNumber != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_networkMessageNumber = value;
		}
	}

	public PropertyState<ushort> DataSetOffset
	{
		get
		{
			return m_dataSetOffset;
		}
		set
		{
			if (m_dataSetOffset != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_dataSetOffset = value;
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

	public PropertyState<uint> NetworkMessageContentMask
	{
		get
		{
			return m_networkMessageContentMask;
		}
		set
		{
			if (m_networkMessageContentMask != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_networkMessageContentMask = value;
		}
	}

	public PropertyState<uint> DataSetMessageContentMask
	{
		get
		{
			return m_dataSetMessageContentMask;
		}
		set
		{
			if (m_dataSetMessageContentMask != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_dataSetMessageContentMask = value;
		}
	}

	public PropertyState<double> PublishingInterval
	{
		get
		{
			return m_publishingInterval;
		}
		set
		{
			if (m_publishingInterval != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_publishingInterval = value;
		}
	}

	public PropertyState<double> ProcessingOffset
	{
		get
		{
			return m_processingOffset;
		}
		set
		{
			if (m_processingOffset != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_processingOffset = value;
		}
	}

	public PropertyState<double> ReceiveOffset
	{
		get
		{
			return m_receiveOffset;
		}
		set
		{
			if (m_receiveOffset != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_receiveOffset = value;
		}
	}

	public UadpDataSetReaderMessageState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(21116u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAJAAAAFVhZHBEYXRhU2V0UmVhZGVyTWVzc2FnZVR5cGVJbnN0YW5jZQEAfFIBAHxSfFIAAP////8JAAAAFWCJCgIAAAAAAAwAAABHcm91cFZlcnNpb24BAH1SAC4ARH1SAAABAAZS/////wEB/////wAAAAAVYIkKAgAAAAAAFAAAAE5ldHdvcmtNZXNzYWdlTnVtYmVyAQB/UgAuAER/UgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAANAAAARGF0YVNldE9mZnNldAEARUQALgBERUQAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAERhdGFTZXRDbGFzc0lkAQCAUgAuAESAUgAAAA7/////AQH/////AAAAABVgiQoCAAAAAAAZAAAATmV0d29ya01lc3NhZ2VDb250ZW50TWFzawEAgVIALgBEgVIAAAEAGj3/////AQH/////AAAAABVgiQoCAAAAAAAZAAAARGF0YVNldE1lc3NhZ2VDb250ZW50TWFzawEAglIALgBEglIAAAEAHj3/////AQH/////AAAAABVgiQoCAAAAAAASAAAAUHVibGlzaGluZ0ludGVydmFsAQCDUgAuAESDUgAAAQAiAf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABQcm9jZXNzaW5nT2Zmc2V0AQCEUgAuAESEUgAAAQAiAf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABSZWNlaXZlT2Zmc2V0AQCFUgAuAESFUgAAAQAiAf////8BAf////8AAAAA");
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
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_groupVersion != null)
		{
			children.Add(m_groupVersion);
		}
		if (m_networkMessageNumber != null)
		{
			children.Add(m_networkMessageNumber);
		}
		if (m_dataSetOffset != null)
		{
			children.Add(m_dataSetOffset);
		}
		if (m_dataSetClassId != null)
		{
			children.Add(m_dataSetClassId);
		}
		if (m_networkMessageContentMask != null)
		{
			children.Add(m_networkMessageContentMask);
		}
		if (m_dataSetMessageContentMask != null)
		{
			children.Add(m_dataSetMessageContentMask);
		}
		if (m_publishingInterval != null)
		{
			children.Add(m_publishingInterval);
		}
		if (m_processingOffset != null)
		{
			children.Add(m_processingOffset);
		}
		if (m_receiveOffset != null)
		{
			children.Add(m_receiveOffset);
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
		case "GroupVersion":
			if (createOrReplace && GroupVersion == null)
			{
				if (replacement == null)
				{
					GroupVersion = new PropertyState<uint>(this);
				}
				else
				{
					GroupVersion = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = GroupVersion;
			break;
		case "NetworkMessageNumber":
			if (createOrReplace && NetworkMessageNumber == null)
			{
				if (replacement == null)
				{
					NetworkMessageNumber = new PropertyState<ushort>(this);
				}
				else
				{
					NetworkMessageNumber = (PropertyState<ushort>)replacement;
				}
			}
			baseInstanceState = NetworkMessageNumber;
			break;
		case "DataSetOffset":
			if (createOrReplace && DataSetOffset == null)
			{
				if (replacement == null)
				{
					DataSetOffset = new PropertyState<ushort>(this);
				}
				else
				{
					DataSetOffset = (PropertyState<ushort>)replacement;
				}
			}
			baseInstanceState = DataSetOffset;
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
		case "NetworkMessageContentMask":
			if (createOrReplace && NetworkMessageContentMask == null)
			{
				if (replacement == null)
				{
					NetworkMessageContentMask = new PropertyState<uint>(this);
				}
				else
				{
					NetworkMessageContentMask = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = NetworkMessageContentMask;
			break;
		case "DataSetMessageContentMask":
			if (createOrReplace && DataSetMessageContentMask == null)
			{
				if (replacement == null)
				{
					DataSetMessageContentMask = new PropertyState<uint>(this);
				}
				else
				{
					DataSetMessageContentMask = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = DataSetMessageContentMask;
			break;
		case "PublishingInterval":
			if (createOrReplace && PublishingInterval == null)
			{
				if (replacement == null)
				{
					PublishingInterval = new PropertyState<double>(this);
				}
				else
				{
					PublishingInterval = (PropertyState<double>)replacement;
				}
			}
			baseInstanceState = PublishingInterval;
			break;
		case "ProcessingOffset":
			if (createOrReplace && ProcessingOffset == null)
			{
				if (replacement == null)
				{
					ProcessingOffset = new PropertyState<double>(this);
				}
				else
				{
					ProcessingOffset = (PropertyState<double>)replacement;
				}
			}
			baseInstanceState = ProcessingOffset;
			break;
		case "ReceiveOffset":
			if (createOrReplace && ReceiveOffset == null)
			{
				if (replacement == null)
				{
					ReceiveOffset = new PropertyState<double>(this);
				}
				else
				{
					ReceiveOffset = (PropertyState<double>)replacement;
				}
			}
			baseInstanceState = ReceiveOffset;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
