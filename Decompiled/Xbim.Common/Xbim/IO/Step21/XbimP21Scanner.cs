using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;
using QUT.Gppg;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Configuration;
using Xbim.Common.Exceptions;
using Xbim.Common.Step21;
using Xbim.IO.Parser;
using Xbim.IO.Step21.Parser;

namespace Xbim.IO.Step21;

public class XbimP21Scanner : IDisposable
{
	private List<ReportProgressDelegate> _progressStatusEvents = new List<ReportProgressDelegate>();

	private readonly Stack<Part21Entity> _processStack = new Stack<Part21Entity>();

	protected int ListNestLevel = -1;

	protected Part21Entity CurrentInstance;

	public CreateEntityDelegate EntityCreate;

	protected PropertyValue PropertyValue;

	private List<DeferredReference> _deferredReferences;

	private double _streamSize = -1.0;

	public static int MaxErrorCount = 200;

	private bool _deferListItems;

	private readonly List<int> _nestedIndex = new List<int>();

	private readonly ParserErrorRegistry _errors = new ParserErrorRegistry();

	public bool Cancel;

	private Scanner _scanner;

	private bool _inHeader;

	private int _errorCount;

	private int _reportEntityCount;

	private static readonly int[] magnitudes = new int[10] { 1, 10, 100, 1000, 10000, 100000, 1000000, 10000000, 100000000, 1000000000 };

	private bool _isInNestedType;

	protected ILogger Logger { get; private set; }

	public bool AllowMissingReferences { get; set; }

	public HashSet<string> SkipTypes { get; } = new HashSet<string>();

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

	public int ErrorCount
	{
		get
		{
			return _errorCount;
		}
		protected set
		{
			_errorCount = value;
			if (_errorCount > MaxErrorCount)
			{
				throw new XbimParserException($"Too many errors in the input file ({_errorCount})");
			}
		}
	}

	public LexLocation CurrentPosition => _scanner.yylloc;

	public IDictionary<int, IPersist> Entities { get; private set; }

	private event ReportProgressDelegate _progressStatus;

	public event ReportProgressDelegate ProgressStatus
	{
		add
		{
			_progressStatus += value;
			_progressStatusEvents.Add(value);
		}
		remove
		{
			_progressStatus += value;
			_progressStatusEvents.Remove(value);
		}
	}

	public XbimP21Scanner(Stream strm, long streamSize, ILoggerFactory loggerFactory, IEnumerable<string> ignoreTypes = null)
	{
		loggerFactory = loggerFactory ?? XbimServices.Current.GetLoggerFactory();
		Logger = loggerFactory.CreateLogger<XbimP21Scanner>();
		_scanner = new Scanner(strm, loggerFactory);
		if (ignoreTypes != null)
		{
			SkipTypes = new HashSet<string>(ignoreTypes);
		}
		int num = 50000;
		if (streamSize > 0)
		{
			_streamSize = streamSize;
			num = Convert.ToInt32(_streamSize / 50.0);
		}
		if (SkipTypes.Any())
		{
			double num2 = 1.0 - (double)SkipTypes.Count / 600.0;
			if (num2 < 0.0)
			{
				num2 = 0.0;
			}
			num = (int)((double)num * num2);
		}
		if (num < 1)
		{
			num = 4;
		}
		int num3 = 100000000;
		IDictionary<int, IPersist> entities;
		if (num <= num3)
		{
			IDictionary<int, IPersist> dictionary = new Dictionary<int, IPersist>(num);
			entities = dictionary;
		}
		else
		{
			IDictionary<int, IPersist> dictionary = new ChunkedDictionary<int, IPersist>(num, num3);
			entities = dictionary;
		}
		Entities = entities;
		_deferredReferences = new List<DeferredReference>(num / 4);
	}

	public XbimP21Scanner(string data, ILoggerFactory loggerFactory, IEnumerable<string> ignoreTypes = null)
	{
		loggerFactory = loggerFactory ?? XbimServices.Current.GetLoggerFactory();
		Logger = loggerFactory.CreateLogger<XbimP21Scanner>();
		_scanner = new Scanner(loggerFactory);
		_scanner.SetSource(data, 0);
		_streamSize = data.Length;
		if (ignoreTypes != null)
		{
			SkipTypes = new HashSet<string>(ignoreTypes);
		}
		int num = (int)_streamSize / 50;
		if (SkipTypes.Any())
		{
			double num2 = 1.0 - (double)SkipTypes.Count / 560.0;
			num = (int)((double)num * num2);
		}
		Entities = new Dictionary<int, IPersist>(num);
		_deferredReferences = new List<DeferredReference>(num / 4);
	}

	public bool Parse(bool onlyHeader = false)
	{
		bool flag = SkipTypes.Any();
		int num = 64;
		int num2 = _scanner.yylex();
		int num3 = 59;
		while (num2 != num && !Cancel)
		{
			try
			{
				if (num2 >= 63)
				{
					Tokens tokens = (Tokens)num2;
					switch (tokens)
					{
					case Tokens.HEADER:
						BeginHeader();
						break;
					case Tokens.ENDSEC:
						if (_inHeader && onlyHeader)
						{
							return true;
						}
						EndSec();
						break;
					case Tokens.DATA:
						BeginData();
						break;
					case Tokens.ENTITY:
						NewEntity(_scanner.yylval.strVal);
						break;
					case Tokens.TYPE:
					{
						string strVal = _scanner.yylval.strVal;
						if (flag && SkipTypes.Contains(strVal))
						{
							_processStack.Pop();
							while (num2 != num3 && num2 != num)
							{
								num2 = _scanner.yylex();
							}
						}
						else if (!SetType(strVal))
						{
							while (num2 != num3 && num2 != num)
							{
								num2 = _scanner.yylex();
							}
						}
						break;
					}
					case Tokens.INTEGER:
						SetIntegerValue(_scanner.yylval.strVal);
						break;
					case Tokens.FLOAT:
						SetFloatValue(_scanner.yylval.strVal);
						break;
					case Tokens.STRING:
						SetStringValue(_scanner.yylval.strVal);
						break;
					case Tokens.MLSTRING:
						SetStringValue(_scanner.yylval.strVal);
						break;
					case Tokens.INVALIDSTRING:
					{
						Part21Entity lastEntity = GetLastEntity();
						Logger.LogWarning("Incorrectly escaped string found on #{entityId}={entity} at Line {line} Col {pos} : {string}", lastEntity.EntityLabel, lastEntity.Entity.GetType().Name.ToUpperInvariant(), _scanner.yylloc.StartLine, _scanner.yylloc.StartColumn, _scanner.yylval.strVal);
						SetStringValue(_scanner.yylval.strVal);
						break;
					}
					case Tokens.BOOLEAN:
						SetBooleanValue(_scanner.yylval.strVal);
						break;
					case Tokens.IDENTITY:
						SetObjectValue(_scanner.yylval.strVal);
						break;
					case Tokens.HEXA:
						SetHexValue(_scanner.yylval.strVal);
						break;
					case Tokens.ENUM:
						SetEnumValue(_scanner.yylval.strVal);
						break;
					case Tokens.NONDEF:
						SetNonDefinedValue();
						break;
					case Tokens.OVERRIDE:
						SetOverrideValue();
						break;
					case Tokens.error:
					case Tokens.TEXT:
					case Tokens.ILLEGALCHAR:
						throw new XbimParserException($"Unexpected scanner token {tokens.ToString()}, line {_scanner.yylloc.StartLine}, column {_scanner.yylloc.StartColumn}");
					}
				}
				else
				{
					switch ((char)(ushort)num2)
					{
					case '(':
						BeginList();
						break;
					case ')':
						EndList();
						break;
					case ';':
						EndEntity();
						break;
					}
				}
				num2 = _scanner.yylex();
			}
			catch (XbimParserException ex)
			{
				Logger?.LogError(LogEventIds.ParserFailure, ex, ex.Message);
				return false;
			}
			catch (Exception ex2)
			{
				Logger?.LogError(LogEventIds.FailedEntity, ex2, ex2.Message);
				ErrorCount++;
				_processStack.Clear();
				int num4 = 72;
				num2 = _scanner.yylex();
				while (num2 != num && num2 != num4)
				{
					num2 = _scanner.yylex();
				}
			}
		}
		EndParse();
		return ErrorCount == 0;
	}

	protected void EndParse()
	{
		bool flag = SkipTypes.Any();
		foreach (DeferredReference deferredReference in _deferredReferences)
		{
			if (!TrySetObjectValue(deferredReference.HostEntity, deferredReference.ParameterIndex, deferredReference.ReferenceId, deferredReference.NestedIndex) && !flag && !AllowMissingReferences)
			{
				Logger?.LogWarning("Entity #{0,-5} is referenced but could not be instantiated", deferredReference.ReferenceId);
			}
		}
		_deferredReferences.Clear();
		if (_errors.Any)
		{
			Logger?.LogWarning(_errors.Summary);
		}
		this._progressStatus?.Invoke(100, "Parsing finished.");
	}

	protected void BeginHeader()
	{
		_inHeader = true;
	}

	protected void BeginData()
	{
		if (_inHeader)
		{
			_inHeader = false;
		}
	}

	protected void EndSec()
	{
		if (_inHeader)
		{
			_inHeader = false;
		}
	}

	protected void BeginList()
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

	protected void EndList()
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
		if (_isInNestedType)
		{
			EndNestedType();
		}
	}

	protected void NewEntity(string entityLabel)
	{
		if (_processStack.Count > 0)
		{
			Part21Entity lastEntity = GetLastEntity();
			Logger.LogError(LogEventIds.FailedEntity, "Entity #{entityId}={entityType} was not fully parsed.", lastEntity.EntityLabel, lastEntity.Entity?.GetType().Name.ToUpperInvariant());
			_processStack.Clear();
			ErrorCount++;
		}
		int label = GetLabel(entityLabel);
		NewEntity(label);
	}

	protected Part21Entity GetLastEntity()
	{
		return _processStack.FirstOrDefault((Part21Entity e) => e.EntityLabel > 0) ?? _processStack.Peek();
	}

	private void NewEntity(int entityLabel)
	{
		CurrentInstance = new Part21Entity(entityLabel);
		_processStack.Push(CurrentInstance);
		if (!(_streamSize < 0.0) && this._progressStatus != null && _reportEntityCount++ >= 500)
		{
			int percentProgress = Convert.ToInt32((double)_scanner.Buffer.Pos / _streamSize * 100.0);
			_reportEntityCount = 0;
			this._progressStatus?.Invoke(percentProgress, "Parsing");
		}
	}

	protected bool SetType(string entityTypeName)
	{
		try
		{
			if (_inHeader)
			{
				IPersist ent = EntityCreate(entityTypeName, null, _inHeader);
				CurrentInstance = new Part21Entity(ent);
				if (CurrentInstance != null)
				{
					_processStack.Push(CurrentInstance);
				}
			}
			else if (ListNestLevel == -1)
			{
				Part21Entity part21Entity = _processStack.Peek();
				part21Entity.Entity = EntityCreate(entityTypeName, part21Entity.EntityLabel, _inHeader);
			}
			else
			{
				BeginNestedType(entityTypeName);
			}
			return true;
		}
		catch (Exception exception)
		{
			if (_errors.AddTypeNotCreated(entityTypeName))
			{
				Logger?.LogError(LogEventIds.FailedEntity, exception, "Could not create type " + entityTypeName);
				ErrorCount++;
			}
			return false;
		}
	}

	protected void EndEntity()
	{
		Part21Entity part21Entity = _processStack.Pop();
		CurrentInstance = null;
		if (_inHeader || part21Entity.Entity == null)
		{
			return;
		}
		try
		{
			Entities.Add(part21Entity.EntityLabel, part21Entity.Entity);
		}
		catch (ArgumentException)
		{
			string text = Entities[part21Entity.EntityLabel].GetType().Name.ToUpperInvariant();
			string text2 = part21Entity.Entity.GetType().Name.ToUpperInvariant();
			if (!string.Equals(text, text2, StringComparison.Ordinal))
			{
				Logger?.LogError(LogEventIds.FailedEntity, $"Duplicate entity label #{part21Entity.EntityLabel} with different types: ({text}/{text2})");
				ErrorCount++;
			}
			else
			{
				Logger?.LogWarning(LogEventIds.FailedEntity, $"Duplicate entity label #{part21Entity.EntityLabel}={text}");
			}
		}
	}

	protected void SetIntegerValue(string value)
	{
		PropertyValue.Init(value, StepParserType.Integer);
		SetEntityParameter(value);
	}

	protected void SetHexValue(string value)
	{
		PropertyValue.Init(value, StepParserType.HexaDecimal);
		SetEntityParameter(value);
	}

	protected void SetFloatValue(string value)
	{
		PropertyValue.Init(value, StepParserType.Real);
		SetEntityParameter(value);
	}

	protected void SetStringValue(string value)
	{
		PropertyValue.Init(value, StepParserType.String);
		SetEntityParameter(value);
	}

	protected void SetInvalidStringValue(string value)
	{
		PropertyValue.Init(value, StepParserType.String);
		SetEntityParameter(value);
	}

	protected void SetEnumValue(string value)
	{
		PropertyValue.Init(value.Trim(new char[1] { '.' }), StepParserType.Enum);
		SetEntityParameter(value);
	}

	protected void SetBooleanValue(string value)
	{
		PropertyValue.Init(value, StepParserType.Boolean);
		SetEntityParameter(value);
	}

	protected void SetNonDefinedValue()
	{
		if (ListNestLevel == 0)
		{
			CurrentInstance.CurrentParamIndex++;
			_deferListItems = false;
		}
	}

	protected void SetOverrideValue()
	{
		if (ListNestLevel == 0)
		{
			CurrentInstance.CurrentParamIndex++;
			_deferListItems = false;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private int GetLabel(string value)
	{
		int num = 0;
		int num2 = 0;
		for (int num3 = value.Length - 1; num3 > 0; num3--)
		{
			int num4 = value[num3] - 48;
			if (num4 >= 0 && num4 <= 9)
			{
				if (num2 > magnitudes.Length - 1)
				{
					throw new Exception("Entity label #" + value + " is bigger than Int32.MaxValue");
				}
				num += num4 * magnitudes[num2++];
			}
		}
		return num;
	}

	protected void SetObjectValue(string value)
	{
		int label = GetLabel(value);
		SetObjectValue(label);
	}

	protected void SetObjectValue(int value)
	{
		if (!TrySetObjectValue(CurrentInstance.Entity, CurrentInstance.CurrentParamIndex, value, NestedIndex))
		{
			_deferredReferences.Add(new DeferredReference(CurrentInstance.CurrentParamIndex, CurrentInstance.Entity, value, NestedIndex));
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

	protected void EndNestedType()
	{
		_isInNestedType = false;
		try
		{
			Part21Entity part21Entity = _processStack.Pop();
			if (part21Entity.Entity != null)
			{
				PropertyValue.Init(part21Entity.Entity);
			}
			CurrentInstance = _processStack.Peek();
			if (CurrentInstance.Entity != null)
			{
				CurrentInstance.Entity.Parse(CurrentInstance.CurrentParamIndex, PropertyValue, NestedIndex);
			}
		}
		catch (Exception exception)
		{
			if (!_errors.AddPropertyNotSet(CurrentInstance.Entity, CurrentInstance.CurrentParamIndex, PropertyValue, exception))
			{
				return;
			}
			Part21Entity part21Entity2 = _processStack.Last();
			if (part21Entity2 != null)
			{
				Logger?.LogError(LogEventIds.FailedEntity, exception, "Entity #{0,-5} {1}, error at parameter {2}", part21Entity2.EntityLabel, part21Entity2.Entity.GetType().Name.ToUpper(), part21Entity2.CurrentParamIndex + 1);
			}
			else
			{
				Logger?.LogError(LogEventIds.FailedEntity, exception, "Unhandled Parser error, in Parser.cs EndNestedType");
			}
			ErrorCount++;
		}
		if (ListNestLevel == 0)
		{
			CurrentInstance.CurrentParamIndex++;
			_deferListItems = false;
		}
	}

	protected void BeginNestedType(string value)
	{
		if (EntityCreate != null)
		{
			CurrentInstance = new Part21Entity(EntityCreate(value, null, _inHeader));
		}
		_processStack.Push(CurrentInstance);
		_isInNestedType = true;
	}

	private bool IsExtendedParameter()
	{
		if (!(CurrentInstance.Entity is IPersistEntity persistEntity))
		{
			return false;
		}
		int count = persistEntity.ExpressType.Properties.Count;
		return CurrentInstance.CurrentParamIndex >= count;
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
		catch (Exception exception)
		{
			if (IsExtendedParameter())
			{
				Logger?.LogWarning("Entity #{entityLabel}={entityType} uses extended parameter at index {paramIndex}. This data will be lost.", CurrentInstance.EntityLabel, CurrentInstance.Entity.GetType().Name, CurrentInstance.CurrentParamIndex);
				return;
			}
			if (!_errors.AddPropertyNotSet(CurrentInstance.Entity, CurrentInstance.CurrentParamIndex, PropertyValue, exception))
			{
				return;
			}
			Part21Entity part21Entity = _processStack.Last();
			if (part21Entity != null)
			{
				Logger?.LogError(LogEventIds.FailedPropertySetter, exception, "Entity #{0,-5} {1}, error at parameter {2} value = {3}", part21Entity.EntityLabel, part21Entity.Entity.GetType().Name.ToUpper(), part21Entity.CurrentParamIndex + 1, value);
			}
			else
			{
				Logger?.LogError(LogEventIds.FailedPropertySetter, exception, "Unhandled Parser error, in Parser.cs SetEntityParameter");
			}
			ErrorCount++;
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
			if (host != null && Entities.TryGetValue(refId, out var value))
			{
				PropertyValue.Init(value);
				host.Parse(paramIndex, PropertyValue, listNextLevel);
				return true;
			}
		}
		catch (Exception exception)
		{
			if (_errors.AddPropertyNotSet(host, paramIndex, PropertyValue, exception))
			{
				Logger?.LogError(LogEventIds.FailedPropertySetter, exception, "Entity #{0,-5} {1}, error at parameter {2}", refId, host.GetType().Name.ToUpper(), paramIndex + 1);
				ErrorCount++;
			}
		}
		return false;
	}

	public void Dispose()
	{
		if (Entities.Count > 0)
		{
			Entities.Clear();
		}
		if (_progressStatusEvents.Count > 0)
		{
			_progressStatusEvents.ForEach(delegate(ReportProgressDelegate e)
			{
				_progressStatus -= e;
			});
			_progressStatusEvents.Clear();
		}
	}
}
