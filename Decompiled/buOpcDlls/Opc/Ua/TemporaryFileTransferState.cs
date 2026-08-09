using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class TemporaryFileTransferState : BaseObjectState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAIQAAAFRlbXBvcmFyeUZpbGVUcmFuc2ZlclR5cGVJbnN0YW5jZQEAgD0BAIA9gD0AAP////8EAAAAFWCJCgIAAAAAABcAAABDbGllbnRQcm9jZXNzaW5nVGltZW91dAEAgT0ALgBEgT0AAAEAIgH/////AQH/////AAAAAARhggoEAAAAAAATAAAAR2VuZXJhdGVGaWxlRm9yUmVhZAEAgj0ALwEAgj2CPQAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAIM9AC4ARIM9AACWAQAAAAEAKgEBHgAAAA8AAABHZW5lcmF0ZU9wdGlvbnMAGP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAIQ9AC4ARIQ9AACWAwAAAAEAKgEBGQAAAAoAAABGaWxlTm9kZUlkABH/////AAAAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAqAQElAAAAFgAAAENvbXBsZXRpb25TdGF0ZU1hY2hpbmUAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAABQAAABHZW5lcmF0ZUZpbGVGb3JXcml0ZQEAhT0ALwEAhT2FPQAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAOc/AC4AROc/AACWAQAAAAEAKgEBHgAAAA8AAABHZW5lcmF0ZU9wdGlvbnMAGP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAIY9AC4ARIY9AACWAgAAAAEAKgEBGQAAAAoAAABGaWxlTm9kZUlkABH/////AAAAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAADgAAAENsb3NlQW5kQ29tbWl0AQCHPQAvAQCHPYc9AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAiD0ALgBEiD0AAJYBAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAIk9AC4ARIk9AACWAQAAAAEAKgEBJQAAABYAAABDb21wbGV0aW9uU3RhdGVNYWNoaW5lABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	private PropertyState<double> m_clientProcessingTimeout;

	private GenerateFileForReadMethodState m_generateFileForReadMethod;

	private GenerateFileForWriteMethodState m_generateFileForWriteMethod;

	private CloseAndCommitMethodState m_closeAndCommitMethod;

	public PropertyState<double> ClientProcessingTimeout
	{
		get
		{
			return m_clientProcessingTimeout;
		}
		set
		{
			if (m_clientProcessingTimeout != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_clientProcessingTimeout = value;
		}
	}

	public GenerateFileForReadMethodState GenerateFileForRead
	{
		get
		{
			return m_generateFileForReadMethod;
		}
		set
		{
			if (m_generateFileForReadMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_generateFileForReadMethod = value;
		}
	}

	public GenerateFileForWriteMethodState GenerateFileForWrite
	{
		get
		{
			return m_generateFileForWriteMethod;
		}
		set
		{
			if (m_generateFileForWriteMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_generateFileForWriteMethod = value;
		}
	}

	public CloseAndCommitMethodState CloseAndCommit
	{
		get
		{
			return m_closeAndCommitMethod;
		}
		set
		{
			if (m_closeAndCommitMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_closeAndCommitMethod = value;
		}
	}

	public TemporaryFileTransferState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(15744u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIQAAAFRlbXBvcmFyeUZpbGVUcmFuc2ZlclR5cGVJbnN0YW5jZQEAgD0BAIA9gD0AAP////8EAAAAFWCJCgIAAAAAABcAAABDbGllbnRQcm9jZXNzaW5nVGltZW91dAEAgT0ALgBEgT0AAAEAIgH/////AQH/////AAAAAARhggoEAAAAAAATAAAAR2VuZXJhdGVGaWxlRm9yUmVhZAEAgj0ALwEAgj2CPQAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAIM9AC4ARIM9AACWAQAAAAEAKgEBHgAAAA8AAABHZW5lcmF0ZU9wdGlvbnMAGP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAIQ9AC4ARIQ9AACWAwAAAAEAKgEBGQAAAAoAAABGaWxlTm9kZUlkABH/////AAAAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAqAQElAAAAFgAAAENvbXBsZXRpb25TdGF0ZU1hY2hpbmUAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAABQAAABHZW5lcmF0ZUZpbGVGb3JXcml0ZQEAhT0ALwEAhT2FPQAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAOc/AC4AROc/AACWAQAAAAEAKgEBHgAAAA8AAABHZW5lcmF0ZU9wdGlvbnMAGP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAIY9AC4ARIY9AACWAgAAAAEAKgEBGQAAAAoAAABGaWxlTm9kZUlkABH/////AAAAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAADgAAAENsb3NlQW5kQ29tbWl0AQCHPQAvAQCHPYc9AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAiD0ALgBEiD0AAJYBAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAIk9AC4ARIk9AACWAQAAAAEAKgEBJQAAABYAAABDb21wbGV0aW9uU3RhdGVNYWNoaW5lABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
		if (m_clientProcessingTimeout != null)
		{
			children.Add(m_clientProcessingTimeout);
		}
		if (m_generateFileForReadMethod != null)
		{
			children.Add(m_generateFileForReadMethod);
		}
		if (m_generateFileForWriteMethod != null)
		{
			children.Add(m_generateFileForWriteMethod);
		}
		if (m_closeAndCommitMethod != null)
		{
			children.Add(m_closeAndCommitMethod);
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
		case "ClientProcessingTimeout":
			if (createOrReplace && ClientProcessingTimeout == null)
			{
				if (replacement == null)
				{
					ClientProcessingTimeout = new PropertyState<double>(this);
				}
				else
				{
					ClientProcessingTimeout = (PropertyState<double>)replacement;
				}
			}
			baseInstanceState = ClientProcessingTimeout;
			break;
		case "GenerateFileForRead":
			if (createOrReplace && GenerateFileForRead == null)
			{
				if (replacement == null)
				{
					GenerateFileForRead = new GenerateFileForReadMethodState(this);
				}
				else
				{
					GenerateFileForRead = (GenerateFileForReadMethodState)replacement;
				}
			}
			baseInstanceState = GenerateFileForRead;
			break;
		case "GenerateFileForWrite":
			if (createOrReplace && GenerateFileForWrite == null)
			{
				if (replacement == null)
				{
					GenerateFileForWrite = new GenerateFileForWriteMethodState(this);
				}
				else
				{
					GenerateFileForWrite = (GenerateFileForWriteMethodState)replacement;
				}
			}
			baseInstanceState = GenerateFileForWrite;
			break;
		case "CloseAndCommit":
			if (createOrReplace && CloseAndCommit == null)
			{
				if (replacement == null)
				{
					CloseAndCommit = new CloseAndCommitMethodState(this);
				}
				else
				{
					CloseAndCommit = (CloseAndCommitMethodState)replacement;
				}
			}
			baseInstanceState = CloseAndCommit;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
