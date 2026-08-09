using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DataSetReaderTypeCreateTargetVariablesMethodState : MethodState
{
	private const string InitializationString = "//////////8EYYIKBAAAAAAAMAAAAERhdGFTZXRSZWFkZXJUeXBlQ3JlYXRlVGFyZ2V0VmFyaWFibGVzTWV0aG9kVHlwZQEA8EMALwEA8EPwQwAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAPFDAC4ARPFDAACWAgAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASkAAAAUAAAAVGFyZ2V0VmFyaWFibGVzVG9BZGQBAJg5AQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAPJDAC4ARPJDAACWAQAAAAEAKgEBHQAAAAoAAABBZGRSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	public DataSetReaderTypeCreateTargetVariablesMethodStateMethodCallHandler OnCall;

	public DataSetReaderTypeCreateTargetVariablesMethodState(NodeState parent)
		: base(parent)
	{
	}

	public new static NodeState Construct(NodeState parent)
	{
		return new DataSetReaderTypeCreateTargetVariablesMethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYYIKBAAAAAAAMAAAAERhdGFTZXRSZWFkZXJUeXBlQ3JlYXRlVGFyZ2V0VmFyaWFibGVzTWV0aG9kVHlwZQEA8EMALwEA8EPwQwAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAPFDAC4ARPFDAACWAgAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASkAAAAUAAAAVGFyZ2V0VmFyaWFibGVzVG9BZGQBAJg5AQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAPJDAC4ARPJDAACWAQAAAAEAKgEBHQAAAAoAAABBZGRSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
		InitializeOptionalChildren(context);
	}

	protected override void InitializeOptionalChildren(ISystemContext context)
	{
		base.InitializeOptionalChildren(context);
	}

	protected override ServiceResult Call(ISystemContext _context, NodeId _objectId, IList<object> _inputArguments, IList<object> _outputArguments)
	{
		if (OnCall == null)
		{
			return base.Call(_context, _objectId, _inputArguments, _outputArguments);
		}
		ServiceResult result = null;
		ConfigurationVersionDataType configurationVersion = (ConfigurationVersionDataType)ExtensionObject.ToEncodeable((ExtensionObject)_inputArguments[0]);
		FieldTargetDataType[] targetVariablesToAdd = (FieldTargetDataType[])ExtensionObject.ToArray(_inputArguments[1], typeof(FieldTargetDataType));
		StatusCode[] addResults = (StatusCode[])_outputArguments[0];
		if (OnCall != null)
		{
			result = OnCall(_context, this, _objectId, configurationVersion, targetVariablesToAdd, ref addResults);
		}
		_outputArguments[0] = addResults;
		return result;
	}
}
