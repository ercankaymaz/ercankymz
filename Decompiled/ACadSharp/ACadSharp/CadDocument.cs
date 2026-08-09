using System;
using System.Collections.Generic;
using System.Linq;
using ACadSharp.Classes;
using ACadSharp.Entities;
using ACadSharp.Header;
using ACadSharp.Objects;
using ACadSharp.Objects.Collections;
using ACadSharp.Tables;
using ACadSharp.Tables.Collections;

namespace ACadSharp;

public class CadDocument : IHandledCadObject
{
	private readonly Dictionary<ulong, IHandledCadObject> _cadObjects = new Dictionary<ulong, IHandledCadObject>();

	private CadDictionary _rootDictionary;

	public AppIdsTable AppIds { get; private set; }

	public BlockRecordsTable BlockRecords { get; private set; }

	public DxfClassCollection Classes { get; set; } = new DxfClassCollection();

	public ColorCollection Colors { get; private set; }

	public DictionaryVariableCollection DictionaryVariables { get; private set; }

	public DimensionStylesTable DimensionStyles { get; private set; }

	public CadObjectCollection<Entity> Entities => ModelSpace.Entities;

	public GroupCollection Groups { get; private set; }

	public ulong Handle => 0uL;

	public CadHeader Header { get; internal set; }

	public ImageDefinitionCollection ImageDefinitions { get; private set; }

	public LayersTable Layers { get; private set; }

	public LayoutCollection Layouts { get; private set; }

	public LineTypesTable LineTypes { get; private set; }

	public MaterialCollection Materials { get; private set; }

	public MLeaderStyleCollection MLeaderStyles { get; private set; }

	public MLineStyleCollection MLineStyles { get; private set; }

	public BlockRecord ModelSpace => BlockRecords["*Model_Space"];

	public BlockRecord PaperSpace => BlockRecords["*Paper_Space"];

	public PdfDefinitionCollection PdfDefinitions { get; private set; }

	public CadDictionary RootDictionary
	{
		get
		{
			return _rootDictionary;
		}
		internal set
		{
			_rootDictionary = value;
			_rootDictionary.Owner = this;
			RegisterCollection(_rootDictionary);
		}
	}

	public ScaleCollection Scales { get; private set; }

	public CadSummaryInfo SummaryInfo { get; set; }

	public TextStylesTable TextStyles { get; private set; }

	public UCSTable UCSs { get; private set; }

	public ViewsTable Views { get; private set; }

	public VPortsTable VPorts { get; private set; }

	internal ViewportEntityControl VEntityControl { get; set; }

	public CadDocument()
		: this(ACadVersion.AC1032)
	{
	}

	public CadDocument(ACadVersion version)
		: this(createDefaults: true)
	{
		Header.Version = version;
	}

	internal CadDocument(bool createDefaults)
	{
		_cadObjects.Add(Handle, this);
		if (createDefaults)
		{
			CreateDefaults();
		}
	}

	public void CreateDefaults()
	{
		DxfClassCollection.UpdateDxfClasses(this);
		if (Header == null)
		{
			Header = new CadHeader(this);
		}
		SummaryInfo = new CadSummaryInfo();
		if (BlockRecords == null)
		{
			BlockRecordsTable blockRecordsTable = (BlockRecords = new BlockRecordsTable(this));
		}
		if (Layers == null)
		{
			LayersTable layersTable = (Layers = new LayersTable(this));
		}
		if (DimensionStyles == null)
		{
			DimensionStylesTable dimensionStylesTable = (DimensionStyles = new DimensionStylesTable(this));
		}
		if (TextStyles == null)
		{
			TextStylesTable textStylesTable = (TextStyles = new TextStylesTable(this));
		}
		if (LineTypes == null)
		{
			LineTypesTable lineTypesTable = (LineTypes = new LineTypesTable(this));
		}
		if (Views == null)
		{
			ViewsTable viewsTable = (Views = new ViewsTable(this));
		}
		if (UCSs == null)
		{
			UCSTable uCSTable = (UCSs = new UCSTable(this));
		}
		if (VPorts == null)
		{
			VPortsTable vPortsTable = (VPorts = new VPortsTable(this));
		}
		if (AppIds == null)
		{
			AppIdsTable appIdsTable = (AppIds = new AppIdsTable(this));
		}
		if (RootDictionary == null)
		{
			RootDictionary = CadDictionary.CreateRoot();
		}
		else
		{
			CadDictionary.CreateDefaultEntries(RootDictionary);
		}
		UpdateCollections(createDictionaries: true, createDefaults: true);
		AppIds.CreateDefaultEntries();
		LineTypes.CreateDefaultEntries();
		Layers.CreateDefaultEntries();
		TextStyles.CreateDefaultEntries();
		DimensionStyles.CreateDefaultEntries();
		VPorts.CreateDefaultEntries();
		if (!BlockRecords.Contains("*Model_Space"))
		{
			BlockRecord modelSpace = BlockRecord.ModelSpace;
			Layouts.Add(modelSpace.Layout);
		}
		if (!BlockRecords.Contains("*Paper_Space"))
		{
			BlockRecord paperSpace = BlockRecord.PaperSpace;
			paperSpace.Layout.TabOrder = 1;
			Layouts.Add(paperSpace.Layout);
		}
	}

	public CadObject GetCadObject(ulong handle)
	{
		return GetCadObject<CadObject>(handle);
	}

	public T GetCadObject<T>(ulong handle) where T : CadObject
	{
		if (_cadObjects.TryGetValue(handle, out var value))
		{
			return value as T;
		}
		return null;
	}

	public T GetCurrent<T>() where T : CadObject, INamedCadObject
	{
		Type typeFromHandle = typeof(T);
		if ((object)typeFromHandle != null)
		{
			if (typeFromHandle.Equals(typeof(Layer)))
			{
				return Header.CurrentLayer as T;
			}
			if (typeFromHandle.Equals(typeof(LineType)))
			{
				return Header.CurrentLineType as T;
			}
			if (typeFromHandle.Equals(typeof(TextStyle)))
			{
				return Header.CurrentTextStyle as T;
			}
			if (typeFromHandle.Equals(typeof(DimensionStyle)))
			{
				return Header.CurrentDimensionStyle as T;
			}
			if (typeFromHandle.Equals(typeof(MLineStyle)))
			{
				return Header.CurrentMLineStyle as T;
			}
			if (typeFromHandle.Equals(typeof(MultiLeaderStyle)))
			{
				if (DictionaryVariables.TryGet("CMLEADERSTYLE", out var entry) && MLeaderStyles.TryGet(entry.Value, out var entry2))
				{
					return entry2 as T;
				}
				return null;
			}
		}
		throw new NotSupportedException($"The type {typeof(T)} is not a configurable type in the document.");
	}

	public void RestoreHandles()
	{
		List<IHandledCadObject> source = new List<IHandledCadObject>(_cadObjects.Values);
		_cadObjects.Clear();
		Header.HandleSeed = 0uL;
		_cadObjects.Add(Header.HandleSeed, this);
		ulong num = Header.HandleSeed + 1;
		foreach (IHandledCadObject item in source.Skip(1))
		{
			(item as CadObject).Handle = num;
			num++;
			_cadObjects.Add(item.Handle, item);
		}
		Header.HandleSeed = num;
	}

	public void SetCurrent<T>(T obj) where T : CadObject, INamedCadObject
	{
		if (!(obj is Layer item))
		{
			if (!(obj is LineType item2))
			{
				if (!(obj is TextStyle item3))
				{
					if (!(obj is DimensionStyle item4))
					{
						if (!(obj is MLineStyle item5))
						{
							if (!(obj is MultiLeaderStyle multiLeaderStyle))
							{
								throw new NotSupportedException($"The type {typeof(T)} is not a configurable type in the document.");
							}
							if (DictionaryVariables.TryGet("CMLEADERSTYLE", out var entry))
							{
								entry.Value = multiLeaderStyle.Name;
							}
							else
							{
								entry = new DictionaryVariable("CMLEADERSTYLE", multiLeaderStyle.Name);
								DictionaryVariables.Add(entry);
							}
							MLeaderStyles.TryAdd(multiLeaderStyle);
						}
						else
						{
							Header.CurrentMLineStyleName = MLineStyles.TryAdd(item5).Name;
						}
					}
					else
					{
						Header.CurrentDimensionStyleName = DimensionStyles.TryAdd(item4).Name;
					}
				}
				else
				{
					Header.CurrentTextStyleName = TextStyles.TryAdd(item3).Name;
				}
			}
			else
			{
				Header.CurrentLineTypeName = LineTypes.TryAdd(item2).Name;
			}
		}
		else
		{
			Header.CurrentLayerName = Layers.TryAdd(item).Name;
		}
	}

	public bool TryGetCadObject<T>(ulong handle, out T cadObject) where T : CadObject
	{
		cadObject = null;
		if (handle == Handle)
		{
			return false;
		}
		if (_cadObjects.TryGetValue(handle, out var value))
		{
			cadObject = value as T;
			return true;
		}
		return false;
	}

	public void UpdateCollections(bool createDictionaries, bool createDefaults)
	{
		if (createDictionaries && RootDictionary == null)
		{
			RootDictionary = CadDictionary.CreateRoot();
		}
		else if (RootDictionary == null)
		{
			return;
		}
		if (updateCollection("ACAD_LAYOUT", createDictionaries, out var dictionary))
		{
			Layouts = new LayoutCollection(dictionary);
		}
		if (updateCollection("ACAD_GROUP", createDictionaries, out var dictionary2))
		{
			Groups = new GroupCollection(dictionary2);
		}
		if (updateCollection("ACAD_SCALELIST", createDictionaries, out var dictionary3))
		{
			Scales = new ScaleCollection(dictionary3);
			if (createDefaults)
			{
				Scales.CreateDefaults();
			}
		}
		if (updateCollection("ACAD_MLINESTYLE", createDictionaries, out var dictionary4))
		{
			MLineStyles = new MLineStyleCollection(dictionary4);
			if (createDefaults)
			{
				MLineStyles.CreateDefaults();
			}
		}
		if (updateCollection("ACAD_MLEADERSTYLE", createDictionaries, out var dictionary5))
		{
			MLeaderStyles = new MLeaderStyleCollection(dictionary5);
			if (createDefaults)
			{
				MLeaderStyles.CreateDefaults();
			}
		}
		if (updateCollection("ACAD_IMAGE_DICT", createDictionaries, out var dictionary6))
		{
			ImageDefinitions = new ImageDefinitionCollection(dictionary6);
		}
		if (updateCollection("ACAD_PDFDEFINITIONS", createDictionaries, out var dictionary7))
		{
			PdfDefinitions = new PdfDefinitionCollection(dictionary7);
		}
		if (updateCollection("ACAD_COLOR", createDictionaries, out var dictionary8))
		{
			Colors = new ColorCollection(dictionary8);
		}
		if (updateCollection("AcDbVariableDictionary", createDictionaries, out var dictionary9))
		{
			DictionaryVariables = new DictionaryVariableCollection(dictionary9);
			if (createDefaults)
			{
				DictionaryVariables.CreateDefaults();
			}
		}
		if (updateCollection("ACAD_MATERIAL", createDictionaries, out var dictionary10))
		{
			Materials = new MaterialCollection(dictionary10);
			if (createDefaults)
			{
				Materials.CreateDefaults();
			}
		}
	}

	public void UpdateDxfClasses(bool reset)
	{
		if (reset)
		{
			Classes.Clear();
		}
		DxfClassCollection.UpdateDxfClasses(this);
		foreach (DxfClass item in Classes)
		{
			item.InstanceCount = (from c in _cadObjects.Values.OfType<CadObject>()
				where c.ObjectName == item.DxfName
				select c).Count();
		}
	}

	public void UpdateImageReactors()
	{
		foreach (ImageDefinitionReactor item in _cadObjects.Values.OfType<ImageDefinitionReactor>().ToList())
		{
			_cadObjects.Remove(item.Handle);
		}
		foreach (RasterImage item2 in _cadObjects.Values.OfType<RasterImage>().ToList())
		{
			item2.DefinitionReactor = new ImageDefinitionReactor(item2);
			addCadObject(item2.DefinitionReactor);
			item2.Definition.AddReactor(item2.DefinitionReactor);
		}
	}

	internal void RegisterCollection<T>(IObservableCadCollection<T> collection) where T : CadObject
	{
		if (!(collection is AppIdsTable))
		{
			if (!(collection is BlockRecordsTable))
			{
				if (!(collection is DimensionStylesTable))
				{
					if (!(collection is LayersTable))
					{
						if (!(collection is LineTypesTable))
						{
							if (!(collection is TextStylesTable))
							{
								if (!(collection is UCSTable))
								{
									if (!(collection is ViewsTable))
									{
										if (collection is VPortsTable)
										{
											VPorts = (VPortsTable)collection;
											VPorts.Owner = this;
										}
									}
									else
									{
										Views = (ViewsTable)collection;
										Views.Owner = this;
									}
								}
								else
								{
									UCSs = (UCSTable)collection;
									UCSs.Owner = this;
								}
							}
							else
							{
								TextStyles = (TextStylesTable)collection;
								TextStyles.Owner = this;
							}
						}
						else
						{
							LineTypes = (LineTypesTable)collection;
							LineTypes.Owner = this;
						}
					}
					else
					{
						Layers = (LayersTable)collection;
						Layers.Owner = this;
					}
				}
				else
				{
					DimensionStyles = (DimensionStylesTable)collection;
					DimensionStyles.Owner = this;
				}
			}
			else
			{
				BlockRecords = (BlockRecordsTable)collection;
				BlockRecords.Owner = this;
			}
		}
		else
		{
			AppIds = (AppIdsTable)collection;
			AppIds.Owner = this;
		}
		collection.OnAdd += onAdd;
		collection.OnRemove += onRemove;
		if (collection is CadObject cadObject)
		{
			addCadObject(cadObject);
		}
		if (collection is ISeqendCollection seqendCollection)
		{
			seqendCollection.OnSeqendAdded += onAdd;
			seqendCollection.OnSeqendRemoved += onRemove;
			if (seqendCollection.Seqend != null)
			{
				addCadObject(seqendCollection.Seqend);
			}
		}
		foreach (T item in collection)
		{
			if (item is CadDictionary collection2)
			{
				RegisterCollection(collection2);
			}
			else
			{
				addCadObject(item);
			}
		}
	}

	internal void UnregisterCollection<T>(IObservableCadCollection<T> collection) where T : CadObject
	{
		if (collection is AppIdsTable || collection is BlockRecordsTable || collection is DimensionStylesTable || collection is LayersTable || collection is LineTypesTable || collection is TextStylesTable || collection is UCSTable || collection is ViewsTable || collection is VPortsTable)
		{
			throw new InvalidOperationException($"The collection {collection.GetType()} cannot be removed from a document.");
		}
		collection.OnAdd -= onAdd;
		collection.OnRemove -= onRemove;
		if (collection is CadObject cadObject)
		{
			removeCadObject(cadObject);
		}
		if (collection is ISeqendCollection seqendCollection)
		{
			seqendCollection.OnSeqendAdded -= onAdd;
			seqendCollection.OnSeqendRemoved -= onRemove;
			if (seqendCollection.Seqend != null)
			{
				removeCadObject(seqendCollection.Seqend);
			}
		}
		foreach (T item in collection)
		{
			if (item is CadDictionary collection2)
			{
				UnregisterCollection(collection2);
			}
			else
			{
				removeCadObject(item);
			}
		}
	}

	private void addCadObject(CadObject cadObject)
	{
		if (cadObject.Document != null)
		{
			throw new ArgumentException($"The item with handle {cadObject.Handle} is already assigned to a document");
		}
		if (cadObject.Handle == 0L || _cadObjects.ContainsKey(cadObject.Handle))
		{
			ulong num = (cadObject.Handle = Header.HandleSeed);
			Header.HandleSeed = num + 1;
		}
		else if (cadObject.Handle >= Header.HandleSeed)
		{
			Header.HandleSeed = cadObject.Handle + 1;
		}
		_cadObjects.Add(cadObject.Handle, cadObject);
		if (cadObject is BlockRecord blockRecord)
		{
			addCadObject(blockRecord.BlockEntity);
			addCadObject(blockRecord.BlockEnd);
		}
		cadObject.AssignDocument(this);
	}

	private void onAdd(object sender, CollectionChangedEventArgs e)
	{
		if (e.Item is CadDictionary collection)
		{
			RegisterCollection(collection);
		}
		else
		{
			addCadObject(e.Item);
		}
	}

	private void onRemove(object sender, CollectionChangedEventArgs e)
	{
		if (e.Item is CadDictionary collection)
		{
			UnregisterCollection(collection);
		}
		else
		{
			removeCadObject(e.Item);
		}
	}

	private void removeCadObject(CadObject cadObject)
	{
		if (TryGetCadObject<CadObject>(cadObject.Handle, out var _) && _cadObjects.Remove(cadObject.Handle))
		{
			cadObject.UnassignDocument();
		}
	}

	private bool updateCollection(string dictName, bool createDictionary, out CadDictionary dictionary)
	{
		if (RootDictionary.TryGetEntry<CadDictionary>(dictName, out dictionary))
		{
			return true;
		}
		if (createDictionary)
		{
			dictionary = new CadDictionary(dictName);
			RootDictionary.Add(dictionary);
		}
		return dictionary != null;
	}
}
