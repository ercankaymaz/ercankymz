using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Logging;
using QUT.Gppg;
using Xbim.Common;
using Xbim.Common.Configuration;
using Xbim.Common.Exceptions;
using Xbim.Common.Step21;
using Xbim.IO.Parser;
using Xbim.IO.Step21.Parser;

namespace Xbim.IO.Step21;

public class XbimP21Parser : P21Parser
{
	private readonly Stack<Part21Entity> _processStack = new Stack<Part21Entity>();

	protected int ListNestLevel = -1;

	protected Part21Entity CurrentInstance;

	private readonly Dictionary<long, IPersist> _entities;

	protected PropertyValue PropertyValue;

	private readonly List<DeferredReference> _deferredReferences;

	private readonly double _streamSize = -1.0;

	public static int MaxErrorCount = 200;

	private int _percentageParsed;

	private bool _deferListItems;

	public bool Cancel;

	private readonly List<int> _nestedIndex = new List<int>();

	protected ILogger Logger { get; private set; }

	public int[] NestedIndex
	{
		get
		{
			if (ListNestLevel <= 0)
			{
				return null;
			}
			return _nestedIndex.ToArray();
		}
	}

	public int ErrorCount { get; protected set; }

	public LexLocation CurrentPosition => base.Scanner.yylloc;

	public Dictionary<long, IPersist> Entities => _entities;

	public event ReportProgressDelegate ProgressStatus;

	public event CreateEntityEventHandler EntityCreate;

	public XbimP21Parser(Stream strm, long streamSize, ILoggerFactory loggerFactory)
		: base(strm, loggerFactory)
	{
		loggerFactory = loggerFactory ?? XbimServices.Current.GetLoggerFactory();
		Logger = loggerFactory.CreateLogger<XbimP21Parser>();
		int num = 5000;
		if (streamSize > 0)
		{
			_streamSize = streamSize;
			num = Convert.ToInt32(_streamSize / 50.0);
		}
		_entities = new Dictionary<long, IPersist>(num);
		_deferredReferences = new List<DeferredReference>(num / 2);
		ErrorCount = 0;
	}

	protected XbimP21Parser(ILoggerFactory loggerFactory)
		: base(loggerFactory)
	{
		loggerFactory = loggerFactory ?? XbimServices.Current.GetLoggerFactory();
		Logger = loggerFactory.CreateLogger<XbimP21Parser>();
		_entities = new Dictionary<long, IPersist>(5000);
		_deferredReferences = new List<DeferredReference>(2500);
		ErrorCount = 0;
	}

	protected override void SetErrorMessage()
	{
	}

	protected override void CharacterError()
	{
		Logger?.LogWarning("Error parsing IFC File, illegal character found");
	}

	protected override void BeginParse()
	{
	}

	protected override void EndParse()
	{
		foreach (DeferredReference deferredReference in _deferredReferences)
		{
			if (!TrySetObjectValue(deferredReference.HostEntity, deferredReference.ParameterIndex, deferredReference.ReferenceId, deferredReference.NestedIndex))
			{
				Logger?.LogWarning("Entity #{0,-5} is referenced but could not be instantiated", deferredReference.ReferenceId);
			}
		}
		_deferredReferences.Clear();
	}

	protected override void BeginHeader()
	{
	}

	protected override void EndHeader()
	{
	}

	protected override void BeginScope()
	{
	}

	protected override void EndScope()
	{
	}

	protected override void EndSec()
	{
	}

	protected override void BeginList()
	{
		Part21Entity part21Entity = _processStack.Peek();
		if (part21Entity.CurrentParamIndex == -1)
		{
			part21Entity.CurrentParamIndex++;
		}
		ListNestLevel++;
		if (ListNestLevel >= 2)
		{
			if (ListNestLevel - 1 > _nestedIndex.Count)
			{
				_nestedIndex.Add(0);
			}
			else
			{
				_nestedIndex[ListNestLevel - 2]++;
			}
		}
	}

	protected override void EndList()
	{
		ListNestLevel--;
		if (ListNestLevel == 0)
		{
			CurrentInstance.CurrentParamIndex++;
			_deferListItems = false;
		}
		if (ListNestLevel <= 0)
		{
			_nestedIndex.Clear();
		}
	}

	protected override void BeginComplex()
	{
	}

	protected override void EndComplex()
	{
	}

	protected override void NewEntity(string entityLabel)
	{
		CurrentInstance = new Part21Entity(entityLabel);
		_processStack.Push(CurrentInstance);
		if (_streamSize == -1.0 || this.ProgressStatus == null)
		{
			return;
		}
		int num = Convert.ToInt32((double)((Scanner)base.Scanner).Buffer.Pos / _streamSize * 100.0);
		if (num > _percentageParsed)
		{
			_percentageParsed = num;
			this.ProgressStatus(_percentageParsed, "Parsing");
			if (Cancel)
			{
				ShiftReduceParser<Xbim.IO.Parser.ValueType, LexLocation>.YYAccept();
			}
		}
	}

	protected override void SetType(string entityTypeName)
	{
		if (InHeader)
		{
			int[] i;
			IPersist ent = this.EntityCreate(entityTypeName, null, InHeader, out i);
			CurrentInstance = new Part21Entity(ent);
			if (CurrentInstance != null)
			{
				_processStack.Push(CurrentInstance);
			}
		}
		else
		{
			Part21Entity part21Entity = _processStack.Peek();
			part21Entity.Entity = this.EntityCreate(entityTypeName, part21Entity.EntityLabel, InHeader, out var _);
		}
		if (Cancel)
		{
			ShiftReduceParser<Xbim.IO.Parser.ValueType, LexLocation>.YYAccept();
		}
	}

	protected override void EndEntity()
	{
		if (_processStack.Count == 0)
		{
			Logger.LogError("Stack is empty");
			return;
		}
		Part21Entity part21Entity = _processStack.Pop();
		CurrentInstance = null;
		if (part21Entity.Entity == null)
		{
			return;
		}
		try
		{
			_entities.Add(part21Entity.EntityLabel, part21Entity.Entity);
		}
		catch (Exception ex)
		{
			string message = $"Duplicate entity label: #{part21Entity.EntityLabel}";
			Logger?.LogError(message, ex);
		}
	}

	protected override void EndHeaderEntity()
	{
		_processStack.Pop();
		CurrentInstance = null;
	}

	protected override void SetIntegerValue(string value)
	{
		PropertyValue.Init(value, StepParserType.Integer);
		SetEntityParameter(value);
	}

	protected override void SetHexValue(string value)
	{
		PropertyValue.Init(value, StepParserType.HexaDecimal);
		SetEntityParameter(value);
	}

	protected override void SetFloatValue(string value)
	{
		PropertyValue.Init(value, StepParserType.Real);
		SetEntityParameter(value);
	}

	protected override void SetStringValue(string value)
	{
		PropertyValue.Init(value, StepParserType.String);
		SetEntityParameter(value);
	}

	protected override void SetInvalidStringValue(string value)
	{
		PropertyValue.Init(value, StepParserType.String);
		SetEntityParameter(value);
	}

	protected override void SetEnumValue(string value)
	{
		PropertyValue.Init(value.Trim(new char[1] { '.' }), StepParserType.Enum);
		SetEntityParameter(value);
	}

	protected override void SetBooleanValue(string value)
	{
		PropertyValue.Init(value, StepParserType.Boolean);
		SetEntityParameter(value);
	}

	protected override void SetNonDefinedValue()
	{
		if (ListNestLevel == 0)
		{
			CurrentInstance.CurrentParamIndex++;
			_deferListItems = false;
		}
	}

	protected override void SetOverrideValue()
	{
		if (ListNestLevel == 0)
		{
			CurrentInstance.CurrentParamIndex++;
			_deferListItems = false;
		}
	}

	protected override void SetObjectValue(string value)
	{
		int refId = Convert.ToInt32(value.TrimStart(new char[1] { '#' }));
		if (!TrySetObjectValue(CurrentInstance.Entity, CurrentInstance.CurrentParamIndex, refId, NestedIndex))
		{
			_deferredReferences.Add(new DeferredReference(CurrentInstance.CurrentParamIndex, CurrentInstance.Entity, refId, NestedIndex));
			if (ListNestLevel != 0)
			{
				_deferListItems = true;
			}
		}
		if (ListNestLevel == 0)
		{
			CurrentInstance.CurrentParamIndex++;
			_deferListItems = false;
		}
	}

	protected override void EndNestedType(string value)
	{
		try
		{
			PropertyValue.Init(_processStack.Pop().Entity);
			CurrentInstance = _processStack.Peek();
			if (CurrentInstance.Entity != null)
			{
				CurrentInstance.Entity.Parse(CurrentInstance.CurrentParamIndex, PropertyValue, NestedIndex);
			}
		}
		catch (Exception)
		{
			if (ErrorCount > MaxErrorCount)
			{
				throw new XbimParserException("Too many errors in file, parser execution terminated");
			}
			ErrorCount++;
			Part21Entity part21Entity = _processStack.Last();
			if (part21Entity != null)
			{
				Logger?.LogWarning("Entity #{0,-5} {1}, error at parameter {2} value = {4}", part21Entity.EntityLabel, part21Entity.Entity.GetType().Name.ToUpper(), part21Entity.CurrentParamIndex + 1, value);
			}
			else
			{
				Logger?.LogWarning("Unhandled Parser error, in Parser.cs EndNestedType");
			}
		}
		if (ListNestLevel == 0)
		{
			CurrentInstance.CurrentParamIndex++;
			_deferListItems = false;
		}
	}

	protected override void BeginNestedType(string value)
	{
		if (this.EntityCreate != null)
		{
			CurrentInstance = new Part21Entity(this.EntityCreate(value, null, InHeader, out var _));
		}
		_processStack.Push(CurrentInstance);
		if (Cancel)
		{
			ShiftReduceParser<Xbim.IO.Parser.ValueType, LexLocation>.YYAccept();
		}
	}

	private void SetEntityParameter(string value)
	{
		try
		{
			if (CurrentInstance.Entity != null)
			{
				CurrentInstance.Entity.Parse(CurrentInstance.CurrentParamIndex, PropertyValue, NestedIndex);
			}
		}
		catch (Exception)
		{
			if (ErrorCount > MaxErrorCount)
			{
				throw new XbimParserException("Too many errors in file, parser execution terminated");
			}
			ErrorCount++;
			Part21Entity part21Entity = _processStack.Last();
			if (part21Entity != null)
			{
				Logger?.LogWarning("Entity #{0,-5} {1}, error at parameter {2} value = {3}", part21Entity.EntityLabel, part21Entity.Entity.GetType().Name.ToUpper(), part21Entity.CurrentParamIndex + 1, value);
			}
			else
			{
				Logger?.LogWarning("Unhandled Parser error, in Parser.cs SetEntityParameter");
			}
		}
		if (ListNestLevel == 0)
		{
			CurrentInstance.CurrentParamIndex++;
			_deferListItems = false;
		}
	}

	internal bool TrySetObjectValue(IPersist host, int paramIndex, int refId, int[] listNextLevel)
	{
		if (_deferListItems)
		{
			return false;
		}
		try
		{
			if (host != null && _entities.TryGetValue(refId, out var value))
			{
				PropertyValue.Init(value);
				host.Parse(paramIndex, PropertyValue, listNextLevel);
				return true;
			}
		}
		catch (Exception)
		{
			if (ErrorCount > MaxErrorCount)
			{
				throw new XbimParserException("Too many errors in file, parser execution terminated");
			}
			ErrorCount++;
			Logger?.LogWarning("Entity #{0,-5} {1}, error at parameter {2}", refId, host.GetType().Name.ToUpper(), paramIndex + 1);
			return true;
		}
		return false;
	}
}
