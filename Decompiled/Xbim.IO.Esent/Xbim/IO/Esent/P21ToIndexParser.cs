using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Metadata;
using Xbim.Common.Step21;
using Xbim.IO.Parser;
using Xbim.IO.Step21;
using Xbim.IO.Step21.Parser;

namespace Xbim.IO.Esent;

public class P21ToIndexParser : P21Parser, IDisposable
{
	private int _percentageParsed;

	private readonly long _streamSize = -1L;

	private BlockingCollection<Tuple<int, Type, byte[]>> _toProcess;

	private BlockingCollection<Tuple<int, short, List<int>, byte[], bool>> _toStore;

	private Task _cacheProcessor;

	private Task _storeProcessor;

	private BinaryWriter _binaryWriter;

	private int _currentLabel;

	private string _currentType;

	private IList<int> _indexKeys;

	private readonly List<int> _indexKeyValues = new List<int>();

	private Part21Entity _currentInstance;

	private readonly Stack<Part21Entity> _processStack = new Stack<Part21Entity>();

	private PropertyValue _propertyValue;

	private int _listNestLevel = -1;

	private readonly StepFileHeader _header = new StepFileHeader(StepFileHeader.HeaderCreationMode.LeaveEmpty, new EsentModel());

	private readonly ILogger _logger;

	private readonly EsentEntityCursor _table;

	private readonly PersistedEntityInstanceCache _modelCache;

	private const int TransactionBatchSize = 100;

	private int _entityCount;

	private readonly int _codePageOverride = -1;

	private readonly List<int> _nestedIndex = new List<int>();

	public StepFileHeader Header => _header;

	public int EntityCount => _entityCount;

	public int[] NestedIndex
	{
		get
		{
			if (_listNestLevel <= 0)
			{
				return null;
			}
			return _nestedIndex.ToArray();
		}
	}

	public event ReportProgressDelegate ProgressStatus;

	internal P21ToIndexParser(Stream inputP21, long streamSize, EsentEntityCursor table, PersistedEntityInstanceCache cache, int codePageOverride = -1, ILoggerFactory loggerFactory = null)
		: base(inputP21, loggerFactory)
	{
		_table = table;
		_modelCache = cache;
		_entityCount = 0;
		_streamSize = streamSize;
		_codePageOverride = codePageOverride;
		_logger = loggerFactory.CreateLogger<P21ToIndexParser>();
	}

	protected override void SetErrorMessage()
	{
		_logger.LogWarning("Parse Error at [{line}, {col}-{endCol}] on #{entityId}={entityType} : {value}", base.Scanner.yylloc.StartLine, base.Scanner.yylloc.StartColumn, base.Scanner.yylloc.EndColumn, _currentLabel, _currentType, base.Scanner.yylval.strVal);
	}

	protected override void CharacterError()
	{
		_logger?.LogWarning("Error parsing IFC File, illegal character found");
	}

	protected override void BeginParse()
	{
		_binaryWriter = new BinaryWriter(new MemoryStream(32767));
		_toStore = new BlockingCollection<Tuple<int, short, List<int>, byte[], bool>>(512);
		if (_modelCache.IsCaching)
		{
			_toProcess = new BlockingCollection<Tuple<int, Type, byte[]>>();
			_cacheProcessor = Task.Factory.StartNew(delegate
			{
				try
				{
					while (!_toProcess.IsCompleted)
					{
						if (_toProcess.TryTake(out var item))
						{
							_modelCache.GetOrCreateInstanceFromCache(item.Item1, item.Item2, item.Item3);
						}
					}
				}
				catch (InvalidOperationException)
				{
				}
			});
		}
		_storeProcessor = Task.Factory.StartNew(delegate
		{
			using EsentLazyDBTransaction value = _table.BeginLazyTransaction();
			while (!_toStore.IsCompleted)
			{
				try
				{
					if (_toStore.TryTake(out var item))
					{
						_table.AddEntity(item.Item1, item.Item2, item.Item3, item.Item4, item.Item5, value);
						if (_toStore.IsCompleted)
						{
							_table.WriteHeader(Header);
						}
						if ((long)(_entityCount % 100) == 99)
						{
							value.Commit();
							value.Begin();
						}
					}
				}
				catch (SystemException)
				{
				}
			}
			value.Commit();
		});
	}

	protected override void EndParse()
	{
		_toStore.CompleteAdding();
		_storeProcessor.Wait();
		if (_modelCache.IsCaching)
		{
			_toProcess.CompleteAdding();
			_cacheProcessor.Wait();
			_cacheProcessor.Dispose();
			_cacheProcessor = null;
			while (_modelCache.ForwardReferences.Count > 0)
			{
				if (_modelCache.ForwardReferences.TryTake(out var item))
				{
					item.Resolve(_modelCache.Read, _modelCache.Model.Metadata);
				}
			}
		}
		_storeProcessor.Dispose();
		_storeProcessor = null;
		Dispose();
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
		_listNestLevel++;
		if (!InHeader)
		{
			_binaryWriter.Write((byte)0);
		}
		if (_listNestLevel >= 2)
		{
			if (_listNestLevel - 1 > _nestedIndex.Count)
			{
				_nestedIndex.Add(0);
			}
			else
			{
				_nestedIndex[_listNestLevel - 2]++;
			}
		}
	}

	protected override void EndList()
	{
		_listNestLevel--;
		if (_listNestLevel == 0)
		{
			_currentInstance.CurrentParamIndex++;
		}
		if (!InHeader)
		{
			_binaryWriter.Write((byte)1);
		}
		if (_listNestLevel <= 0)
		{
			_nestedIndex.Clear();
		}
	}

	protected override void BeginComplex()
	{
		_binaryWriter.Write((byte)2);
	}

	protected override void EndComplex()
	{
		_binaryWriter.Write((byte)3);
	}

	protected override void NewEntity(string entityLabel)
	{
		_currentInstance = new Part21Entity(entityLabel);
		_processStack.Push(_currentInstance);
		_entityCount++;
		_indexKeyValues.Clear();
		_currentLabel = Convert.ToInt32(entityLabel.TrimStart(new char[1] { '#' }));
		if (_binaryWriter.BaseStream is MemoryStream memoryStream)
		{
			memoryStream.SetLength(0L);
		}
		if (_streamSize != -1 && this.ProgressStatus != null)
		{
			int num = Convert.ToInt32((double)((Scanner)base.Scanner).Buffer.Pos / (double)_streamSize * 100.0);
			if (num > _percentageParsed)
			{
				_percentageParsed = num;
				this.ProgressStatus(_percentageParsed, "Parsing");
			}
		}
	}

	protected override void SetType(string entityTypeName)
	{
		if (InHeader)
		{
			_currentInstance = new Part21Entity(entityTypeName switch
			{
				"FILE_DESCRIPTION" => _header.FileDescription, 
				"FILE_NAME" => _header.FileName, 
				"FILE_SCHEMA" => _header.FileSchema, 
				_ => throw new ArgumentException($"Invalid Header entity type {entityTypeName}"), 
			});
			_processStack.Push(_currentInstance);
			return;
		}
		_currentType = entityTypeName;
		ExpressType expressType = _modelCache.Model.Metadata.ExpressType(_currentType);
		if (expressType == null)
		{
			throw new ArgumentException($"Invalid entity type {_currentType}");
		}
		_indexKeys = expressType.IndexedValues;
	}

	protected override void EndEntity()
	{
		_processStack.Pop();
		_currentInstance = null;
		if (_currentType != null)
		{
			_binaryWriter.Write((byte)14);
			ExpressType expressType = _modelCache.Model.Metadata.ExpressType(_currentType);
			byte[] array = (_binaryWriter.BaseStream as MemoryStream).ToArray();
			List<int> item = new List<int>(_indexKeyValues);
			_toStore.Add(new Tuple<int, short, List<int>, byte[], bool>(_currentLabel, expressType.TypeId, item, array, expressType.IndexedClass));
			if (_modelCache.IsCaching)
			{
				_toProcess.Add(new Tuple<int, Type, byte[]>(_currentLabel, expressType.Type, array));
			}
		}
	}

	protected override void EndHeaderEntity()
	{
		_processStack.Pop();
		_currentInstance = null;
	}

	protected override void SetIntegerValue(string value)
	{
		if (InHeader)
		{
			_propertyValue.Init(value, StepParserType.Integer);
			if (_currentInstance.Entity != null)
			{
				_currentInstance.Entity.Parse(_currentInstance.CurrentParamIndex, _propertyValue, NestedIndex);
			}
		}
		else
		{
			_binaryWriter.Write((byte)4);
			_binaryWriter.Write(Convert.ToInt64(value));
		}
		if (_listNestLevel == 0)
		{
			_currentInstance.CurrentParamIndex++;
		}
	}

	protected override void SetHexValue(string value)
	{
		if (InHeader)
		{
			_propertyValue.Init(value, StepParserType.HexaDecimal);
			if (_currentInstance.Entity != null)
			{
				_currentInstance.Entity.Parse(_currentInstance.CurrentParamIndex, _propertyValue, NestedIndex);
			}
		}
		else
		{
			_binaryWriter.Write((byte)5);
			string text = value.Substring(1, value.Length - 2);
			if (string.IsNullOrWhiteSpace(text))
			{
				_binaryWriter.Write(0);
			}
			else
			{
				string text2 = text.Substring(1);
				int length = text2.Length;
				byte[] array = new byte[length / 2];
				for (int i = 0; i < length; i += 2)
				{
					array[i / 2] = Convert.ToByte(text2.Substring(i, 2), 16);
				}
				_binaryWriter.Write(array.Length);
				_binaryWriter.Write(array);
			}
		}
		if (_listNestLevel == 0)
		{
			_currentInstance.CurrentParamIndex++;
		}
	}

	protected override void SetFloatValue(string value)
	{
		if (InHeader)
		{
			_propertyValue.Init(value, StepParserType.Real);
			if (_currentInstance.Entity != null)
			{
				_currentInstance.Entity.Parse(_currentInstance.CurrentParamIndex, _propertyValue, NestedIndex);
			}
		}
		else
		{
			_binaryWriter.Write((byte)6);
			_binaryWriter.Write(Convert.ToDouble(value, CultureInfo.InvariantCulture));
		}
		if (_listNestLevel == 0)
		{
			_currentInstance.CurrentParamIndex++;
		}
	}

	protected override void SetStringValue(string value)
	{
		if (InHeader)
		{
			_propertyValue.Init(value, StepParserType.String);
			if (_currentInstance.Entity != null)
			{
				_currentInstance.Entity.Parse(_currentInstance.CurrentParamIndex, _propertyValue, NestedIndex);
			}
		}
		else
		{
			_binaryWriter.Write((byte)7);
			string text = value.Substring(1, value.Length - 2);
			if (text.Contains("\\") || text.Contains("'"))
			{
				text = new XbimP21StringDecoder().Unescape(text, _codePageOverride);
			}
			_binaryWriter.Write(text);
		}
		if (_listNestLevel == 0)
		{
			_currentInstance.CurrentParamIndex++;
		}
	}

	protected override void SetInvalidStringValue(string value)
	{
		Part21Entity lastEntity = GetLastEntity();
		_logger.LogWarning("Incorrectly escaped string found on #{entityId}={entity} at Line {line} Col {pos} : {string}", lastEntity.EntityLabel, lastEntity.Entity.GetType().Name.ToUpperInvariant(), base.Scanner.yylloc.StartLine, base.Scanner.yylloc.StartColumn, base.Scanner.yylval.strVal);
		SetStringValue(value);
	}

	protected Part21Entity GetLastEntity()
	{
		return _processStack.FirstOrDefault((Part21Entity e) => e.EntityLabel > 0) ?? _processStack.Peek();
	}

	protected override void SetEnumValue(string value)
	{
		if (InHeader)
		{
			_propertyValue.Init(value, StepParserType.Enum);
			if (_currentInstance.Entity != null)
			{
				_currentInstance.Entity.Parse(_currentInstance.CurrentParamIndex, _propertyValue, NestedIndex);
			}
		}
		else
		{
			_binaryWriter.Write((byte)8);
			_binaryWriter.Write(value.Trim(new char[1] { '.' }));
		}
		if (_listNestLevel == 0)
		{
			_currentInstance.CurrentParamIndex++;
		}
	}

	protected override void SetBooleanValue(string value)
	{
		if (InHeader)
		{
			_propertyValue.Init(value, StepParserType.Boolean);
			if (_currentInstance.Entity != null)
			{
				_currentInstance.Entity.Parse(_currentInstance.CurrentParamIndex, _propertyValue, NestedIndex);
			}
		}
		else
		{
			_binaryWriter.Write((byte)9);
			_binaryWriter.Write(value == ".T.");
		}
		if (_listNestLevel == 0)
		{
			_currentInstance.CurrentParamIndex++;
		}
	}

	protected override void SetNonDefinedValue()
	{
		if (_listNestLevel == 0)
		{
			_currentInstance.CurrentParamIndex++;
		}
		_binaryWriter.Write((byte)10);
	}

	protected override void SetOverrideValue()
	{
		if (_listNestLevel == 0)
		{
			_currentInstance.CurrentParamIndex++;
		}
		_binaryWriter.Write((byte)11);
	}

	protected override void SetObjectValue(string value)
	{
		int num = Convert.ToInt32(value.TrimStart(new char[1] { '#' }));
		if (_indexKeys != null && _indexKeys.Contains(_currentInstance.CurrentParamIndex + 1))
		{
			_indexKeyValues.Add(num);
		}
		if (_listNestLevel == 0)
		{
			_currentInstance.CurrentParamIndex++;
		}
		if (num <= 32767)
		{
			_binaryWriter.Write((byte)16);
			_binaryWriter.Write(Convert.ToUInt16(num));
			return;
		}
		if (num <= int.MaxValue)
		{
			_binaryWriter.Write((byte)17);
			_binaryWriter.Write(Convert.ToInt32(num));
			return;
		}
		throw new Exception("Entity Label exceeds maximim value for a long number, it is greater than an int32");
	}

	protected override void EndNestedType(string value)
	{
		_binaryWriter.Write((byte)13);
		if (_listNestLevel == 0)
		{
			_currentInstance.CurrentParamIndex++;
		}
	}

	protected override void BeginNestedType(string value)
	{
		_binaryWriter.Write((byte)12);
		_binaryWriter.Write(value);
	}

	public void Dispose()
	{
		if (_binaryWriter != null)
		{
			_binaryWriter.Close();
		}
		_binaryWriter = null;
	}
}
