using System;
using _0005;
using _0006;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;

namespace Opaline2Cs;

public class Opaline : IDisposable
{
	internal readonly Session _0001 = null;

	private UpdateFunction _0001 = null;

	internal bool _0001 = false;

	[NonSerialized]
	internal static GetString _009A;

	public static string GetDllName()
	{
		return _009A(107396731);
	}

	public void SetSoftwareLicenseFile(string license_key_filepath)
	{
		_0005._0003._0001(this._0001.__Ptr, license_key_filepath);
	}

	public LicenseType GetLicenseType()
	{
		return (LicenseType)_0005._0003._0001(this._0001.__Ptr);
	}

	public void SetLogFile(string file)
	{
		_0005._0003._0001(file);
	}

	public Block CreateBlock(double x, double y, double z, double cost, uint nbBlocks)
	{
		IntPtr ptr = _0005._0003._0001(this._0001.__Ptr, x, y, z, cost, nbBlocks);
		return Wrappable.Create(ptr, new Block());
	}

	public void SetBlockPriority(Block block, int priority)
	{
		_0005._0003._0001(this._0001.__Ptr, block.__Ptr, priority);
	}

	public Part CreatePart(uint minQuantity, uint maxQuantity, double price)
	{
		IntPtr ptr;
		do
		{
			if (false)
			{
				continue;
			}
			IntPtr intPtr = this._0001.__Ptr;
			do
			{
				if (0 == 0)
				{
					intPtr = _0005._0003._0001(intPtr, minQuantity, maxQuantity, price);
				}
			}
			while (4 == 0);
			ptr = intPtr;
		}
		while (5 == 0);
		return Wrappable.Create(ptr, new Part());
	}

	public void SetPartPriority(Part part, int priority)
	{
		_0005._0003._0001(this._0001.__Ptr, part.__Ptr, priority);
	}

	public OpalineModule CreateSimpleModule(Part part, uint nbParts, double x, double y, double z)
	{
		IntPtr ptr = default(IntPtr);
		OpalineModule result = default(OpalineModule);
		do
		{
			if (2u != 0)
			{
				if (0 == 0)
				{
					IntPtr intPtr = _0005._0003._0001(this._0001.__Ptr, part.__Ptr, nbParts, x, y, z);
					if (0 == 0)
					{
						ptr = intPtr;
					}
				}
				continue;
			}
			return result;
		}
		while (7 == 0);
		return Wrappable.Create(ptr, new OpalineModule());
	}

	public OpalineModule CreateMonoModule(Part part, uint nbParts, double lx, double dx, uint minx, uint maxx, double ly, double dy, uint miny, uint maxy, double lz, double dz, uint minz, uint maxz)
	{
		while (true)
		{
			IntPtr intPtr = this._0001.__Ptr;
			while (true)
			{
				intPtr = _0005._0003._0001(intPtr, part.__Ptr, nbParts, lx, dx, minx, maxx, ly, dy, miny, maxy, lz, dz, minz, maxz);
				while (0 == 0)
				{
					IntPtr intPtr2 = intPtr;
					if (2 == 0)
					{
						goto end_IL_005b;
					}
					intPtr = intPtr2;
					if (6u != 0)
					{
						if (4 == 0)
						{
							break;
						}
						OpalineModule opalineModule = Wrappable.Create(intPtr, new OpalineModule());
						OpalineModule result = opalineModule;
						if (0 == 0)
						{
						}
						return result;
					}
				}
				continue;
				end_IL_005b:
				break;
			}
		}
	}

	public void GetBlock(Block block, out double x, out double y, out double z, out double cost, out uint nbBlocks)
	{
		if (4u != 0)
		{
			_0005._0003._0001(this._0001.__Ptr, block.__Ptr, out x, out y, out z, out cost, out nbBlocks);
		}
	}

	public void GetPart(Part part, out uint minQuantity, out uint maxQuantity, out double price)
	{
		if (0 == 0)
		{
		}
		do
		{
			IL_0004:
			if (6u != 0)
			{
				_0005._0003._0001(this._0001.__Ptr, part.__Ptr, out minQuantity, out maxQuantity, out price);
				if (false)
				{
					goto IL_0004;
				}
			}
		}
		while (false);
	}

	public uint GetNbPavementElement(OpalineModule module)
	{
		if (true)
		{
			if (false)
			{
			}
			goto IL_0007;
		}
		goto IL_0023;
		IL_0023:
		uint result;
		if (8u != 0)
		{
			return result;
		}
		goto IL_0007;
		IL_0007:
		if (3u != 0)
		{
			result = _0005._0003._0001(this._0001.__Ptr, module.__Ptr);
		}
		goto IL_0023;
	}

	public void GetPavementElement(OpalineModule module, uint index, Part part, out double px, out double py, out double pz, out double sx, out double sy, out double sz)
	{
		if (2u != 0)
		{
			goto IL_0004;
		}
		goto IL_0035;
		IL_0004:
		if (0 == 0)
		{
			_0005._0003._0001(this._0001.__Ptr, module.__Ptr, index, part.__Ptr, out px, out py, out pz, out sx, out sy, out sz);
		}
		goto IL_0035;
		IL_0035:
		if (0 == 0)
		{
			return;
		}
		goto IL_0004;
	}

	public void GetModuleInfo(OpalineModule module, out double lx, out double dx, out uint minx, out uint maxx, out double ly, out double dy, out uint miny, out uint maxy, out double lz, out double dz, out uint minz, out uint maxz)
	{
		while (true)
		{
			if (-1 == 0)
			{
				goto IL_0038;
			}
			goto IL_003c;
			IL_0038:
			if (false)
			{
				goto IL_003c;
			}
			break;
			IL_003c:
			_0005._0003._0001(this._0001.__Ptr, module.__Ptr, out lx, out dx, out minx, out maxx, out ly, out dy, out miny, out maxy, out lz, out dz, out minz, out maxz);
			if (5 == 0)
			{
				continue;
			}
			goto IL_0038;
		}
	}

	public void SetSessionUserData(int userData)
	{
		_0005._0003._0001(this._0001.__Ptr, userData);
	}

	public void SetBlockUserData(Block block, int userData)
	{
		_0005._0003._0001(this._0001.__Ptr, block.__Ptr, userData);
	}

	public void SetPartUserData(Part part, int userData)
	{
		_0005._0003._0001(this._0001.__Ptr, part.__Ptr, userData);
	}

	public void SetModuleUserData(OpalineModule module, int userData)
	{
		_0005._0003._0001(this._0001.__Ptr, module.__Ptr, userData);
	}

	public int GetSessionUserData()
	{
		return _0005._0003._0001(this._0001.__Ptr);
	}

	public int GetBlockUserData(Block block)
	{
		if (true)
		{
			if (false)
			{
			}
			goto IL_0007;
		}
		goto IL_0023;
		IL_0023:
		int result;
		if (8u != 0)
		{
			return result;
		}
		goto IL_0007;
		IL_0007:
		if (3u != 0)
		{
			result = _0005._0003._0001(this._0001.__Ptr, block.__Ptr);
		}
		goto IL_0023;
	}

	public int GetPartUserData(Part part)
	{
		if (true)
		{
			if (false)
			{
			}
			goto IL_0007;
		}
		goto IL_0023;
		IL_0023:
		int result;
		if (8u != 0)
		{
			return result;
		}
		goto IL_0007;
		IL_0007:
		if (3u != 0)
		{
			result = _0005._0003._0001(this._0001.__Ptr, part.__Ptr);
		}
		goto IL_0023;
	}

	public int GetModuleUserData(OpalineModule module)
	{
		if (true)
		{
			if (false)
			{
			}
			goto IL_0007;
		}
		goto IL_0023;
		IL_0023:
		int result;
		if (8u != 0)
		{
			return result;
		}
		goto IL_0007;
		IL_0007:
		if (3u != 0)
		{
			result = _0005._0003._0001(this._0001.__Ptr, module.__Ptr);
		}
		goto IL_0023;
	}

	public void SetDefaultMargins(double x1, double x2, double y1, double y2, double z1, double z2)
	{
		while (true)
		{
			if (uint.MaxValue != 0)
			{
				goto IL_0004;
			}
			goto IL_0021;
			IL_0021:
			if (false)
			{
				continue;
			}
			if (0 == 0)
			{
				break;
			}
			goto IL_0004;
			IL_0004:
			if (false)
			{
				continue;
			}
			_0005._0003._0001(this._0001.__Ptr, x1, x2, y1, y2, z1, z2);
			goto IL_0021;
		}
	}

	public void SetSpecificMargins(Block block, double x1, double x2, double y1, double y2, double z1, double z2)
	{
		_0005._0003._0001(this._0001.__Ptr, block.__Ptr, x1, x2, y1, y2, z1, z2);
	}

	public void SetCuttingLimits(double xMax, double yMax, double zMax)
	{
		_0005._0003._0001(this._0001.__Ptr, xMax, yMax, zMax);
	}

	public void SetSawingDistance(double distance)
	{
		_0005._0003._0001(this._0001.__Ptr, distance);
	}

	public void SetMinInterSawingDistance(double distance)
	{
		_0005._0003._0001(this._0001.__Ptr, distance);
	}

	public void SetMaximumDepth(int maxDepth)
	{
		_0005._0003._0001(this._0001.__Ptr, maxDepth);
	}

	public Node MonoOptimize(Block block, double maxTime, UpdateFunction updateFunction = null)
	{
		while (true)
		{
			this._0001 = updateFunction;
			if (false)
			{
				continue;
			}
			IntPtr intPtr = _0005._0003._0001(this._0001.__Ptr, block.__Ptr, maxTime, (_0006._0001)null);
			while (true)
			{
				IntPtr intPtr2 = intPtr;
				if (6 == 0)
				{
					break;
				}
				intPtr = intPtr2;
				if (3 == 0)
				{
					continue;
				}
				Node result = Wrappable.Create(intPtr, new Node());
				if (0 == 0)
				{
					return result;
				}
				Node result2;
				return result2;
			}
		}
	}

	public uint Optimize(double maxTime, UpdateFunction updateFunction = null)
	{
		uint result = default(uint);
		while (4u != 0)
		{
			this._0001 = updateFunction;
			result = _0005._0003._0001(this._0001.__Ptr, maxTime, (_0006._0001)null);
			if (0 == 0)
			{
				break;
			}
		}
		return result;
	}

	public OptimizationStatus GetOptimizationStatus()
	{
		return (OptimizationStatus)_0005._0003._0001(this._0001.__Ptr);
	}

	public int GetOptimizationDimension()
	{
		return _0005._0003._0001(this._0001.__Ptr);
	}

	public void GetNestingInfo(uint indexNesting, out uint multiplicity, out Node root, out Block block)
	{
		IntPtr ptr = default(IntPtr);
		IntPtr ptr2 = default(IntPtr);
		if (0 == 0)
		{
			IntPtr _Ptr = this._0001.__Ptr;
			if (0 == 0)
			{
				_0005._0003._0001(_Ptr, indexNesting, out multiplicity, out ptr, out ptr2);
			}
		}
		do
		{
			root = Wrappable.Create(ptr, new Node());
			block = Wrappable.Create(ptr2, new Block());
		}
		while (false ? true : false);
	}

	public void GetNestingsStatistics(out int final, out double fillRatio, out double profitability)
	{
		_0005._0003._0001(this._0001.__Ptr, out final, out fillRatio, out profitability);
	}

	public uint GetNestingMultiplicity(uint indexNesting)
	{
		return _0005._0003._0001(this._0001.__Ptr, indexNesting);
	}

	public Node GetNestingRoot(uint indexNesting)
	{
		Node result2;
		if (uint.MaxValue != 0 && 8u != 0)
		{
			if (7 == 0)
			{
				Node result = default(Node);
				return result;
			}
			IntPtr intPtr = _0005._0003._0001(this._0001.__Ptr, indexNesting);
			if (0 == 0)
			{
				IntPtr intPtr2 = intPtr;
				intPtr = intPtr2;
			}
			result2 = Wrappable.Create(intPtr, new Node());
		}
		return result2;
	}

	public Block GetNestingBlock(uint indexNesting)
	{
		Block result2;
		if (uint.MaxValue != 0 && 8u != 0)
		{
			if (7 == 0)
			{
				Block result = default(Block);
				return result;
			}
			IntPtr intPtr = _0005._0003._0001(this._0001.__Ptr, indexNesting);
			if (0 == 0)
			{
				IntPtr intPtr2 = intPtr;
				intPtr = intPtr2;
			}
			result2 = Wrappable.Create(intPtr, new Block());
		}
		return result2;
	}

	public Rectangles GetNestingRectangles(uint indexNesting)
	{
		Rectangles result2;
		if (uint.MaxValue != 0 && 8u != 0)
		{
			if (7 == 0)
			{
				Rectangles result = default(Rectangles);
				return result;
			}
			IntPtr intPtr = _0005._0003._0001(this._0001.__Ptr, indexNesting);
			if (0 == 0)
			{
				IntPtr intPtr2 = intPtr;
				intPtr = intPtr2;
			}
			result2 = Wrappable.Create(intPtr, new Rectangles());
		}
		return result2;
	}

	public uint GetNbRectangles(Rectangles rectangles)
	{
		if (true)
		{
			if (false)
			{
			}
			goto IL_0007;
		}
		goto IL_0023;
		IL_0023:
		uint result;
		if (8u != 0)
		{
			return result;
		}
		goto IL_0007;
		IL_0007:
		if (3u != 0)
		{
			result = _0005._0003._0001(this._0001.__Ptr, rectangles.__Ptr);
		}
		goto IL_0023;
	}

	public void GetRectangleInfo(Rectangles rectangles, uint indexRectangle, out Node node, out double x, out double y, out double z)
	{
		while (true)
		{
			_0005._0003._0001(this._0001.__Ptr, rectangles.__Ptr, indexRectangle, out IntPtr ptr, out x, out y, out z);
			if (0 == 0 && true && 0 == 0)
			{
				node = Wrappable.Create(ptr, new Node());
				if (0 == 0)
				{
					break;
				}
			}
		}
	}

	public double GetRectanglePosition(Rectangles rectangles, uint indexRectangle, Direction direction)
	{
		double num;
		while (true)
		{
			if (0 == 0)
			{
				num = _0005._0003._0001(this._0001.__Ptr, rectangles.__Ptr, indexRectangle, (int)direction);
				if (-1 == 0)
				{
					break;
				}
				double num2;
				if (4u != 0)
				{
					num2 = num;
				}
				if (0 == 0 && 2u != 0)
				{
					num = num2;
					break;
				}
			}
		}
		return num;
	}

	public Node GetRectangleNode(Rectangles rectangles, uint indexRectangle)
	{
		IntPtr ptr;
		do
		{
			if (false)
			{
				continue;
			}
			IntPtr intPtr = this._0001.__Ptr;
			do
			{
				if (0 == 0)
				{
					intPtr = _0005._0003._0001(intPtr, rectangles.__Ptr, indexRectangle);
				}
			}
			while (4 == 0);
			ptr = intPtr;
		}
		while (5 == 0);
		return Wrappable.Create(ptr, new Node());
	}

	public void GetNodeDimension(Node node, out double x, out double y, out double z)
	{
		if (0 == 0)
		{
		}
		do
		{
			IL_0004:
			if (6u != 0)
			{
				_0005._0003._0001(this._0001.__Ptr, node.__Ptr, out x, out y, out z);
				if (false)
				{
					goto IL_0004;
				}
			}
		}
		while (false);
	}

	public double GetNodeDimensionAux(Node node, Direction direction)
	{
		if (0 == 0)
		{
		}
		double num = _0005._0003._0001(this._0001.__Ptr, node.__Ptr, (int)direction);
		do
		{
			if (7u != 0 && 8u != 0)
			{
				double num2 = num;
				num = num2;
			}
		}
		while (false);
		return num;
	}

	public NodeType GetNodeType(Node node)
	{
		if (true)
		{
			if (false)
			{
			}
			goto IL_0007;
		}
		goto IL_0023;
		IL_0023:
		NodeType result;
		if (8u != 0)
		{
			return result;
		}
		goto IL_0007;
		IL_0007:
		if (3u != 0)
		{
			result = (NodeType)_0005._0003._0001(this._0001.__Ptr, node.__Ptr);
		}
		goto IL_0023;
	}

	public void GetAssemblyInfo(Node node, out Direction direction, out uint nbSubNodes)
	{
		if (4u != 0)
		{
			_0005._0003._0001(this._0001.__Ptr, node.__Ptr, out int num, out nbSubNodes);
			direction = (Direction)num;
		}
	}

	public Direction GetAssemblyDirection(Node node)
	{
		if (true)
		{
			if (false)
			{
			}
			goto IL_0007;
		}
		goto IL_0023;
		IL_0023:
		Direction result;
		if (8u != 0)
		{
			return result;
		}
		goto IL_0007;
		IL_0007:
		if (3u != 0)
		{
			result = (Direction)_0005._0003._0001(this._0001.__Ptr, node.__Ptr);
		}
		goto IL_0023;
	}

	public uint GetAssemblyNbSubNodes(Node node)
	{
		if (true)
		{
			if (false)
			{
			}
			goto IL_0007;
		}
		goto IL_0023;
		IL_0023:
		uint result;
		if (8u != 0)
		{
			return result;
		}
		goto IL_0007;
		IL_0007:
		if (3u != 0)
		{
			result = _0005._0003._0001(this._0001.__Ptr, node.__Ptr);
		}
		goto IL_0023;
	}

	public Node GetAssemblySubNode(Node node, uint indexSubNode)
	{
		IntPtr ptr;
		do
		{
			if (false)
			{
				continue;
			}
			IntPtr intPtr = this._0001.__Ptr;
			do
			{
				if (0 == 0)
				{
					intPtr = _0005._0003._0001(intPtr, node.__Ptr, indexSubNode);
				}
			}
			while (4 == 0);
			ptr = intPtr;
		}
		while (5 == 0);
		return Wrappable.Create(ptr, new Node());
	}

	public void GetModuleNodeInfo(Node node, out OpalineModule module, out uint nx, out uint ny, out uint nz)
	{
		if (2u != 0)
		{
			goto IL_0004;
		}
		goto IL_0031;
		IL_0004:
		IntPtr ptr;
		if (0 == 0)
		{
			_0005._0003._0001(this._0001.__Ptr, node.__Ptr, out ptr, out nx, out ny, out nz);
		}
		module = Wrappable.Create(ptr, new OpalineModule());
		goto IL_0031;
		IL_0031:
		if (0 == 0)
		{
			return;
		}
		goto IL_0004;
	}

	public OpalineModule GetModuleNodeModule(Node node)
	{
		IntPtr ptr = _0005._0003._0001(this._0001.__Ptr, node.__Ptr);
		return Wrappable.Create(ptr, new OpalineModule());
	}

	public uint GetModuleNodeQuantity(Node node, Direction direction)
	{
		if (0 == 0)
		{
		}
		uint num = _0005._0003._0001(this._0001.__Ptr, node.__Ptr, (int)direction);
		do
		{
			if (7u != 0 && 8u != 0)
			{
				uint num2 = num;
				num = num2;
			}
		}
		while (false);
		return num;
	}

	public void SetMaximumDepthIncludingTrim(int maximum_depth)
	{
		_0005._0003._0001(this._0001.__Ptr, maximum_depth);
	}

	public Opaline()
	{
		this._0001 = _0005._0003._0001(this);
	}

	public Opaline(int seed)
	{
		this._0001 = _0005._0003._0001(seed, this);
	}

	public Opaline(string logFile)
	{
		SetLogFile(logFile);
		this._0001 = _0005._0003._0001(this);
	}

	public Opaline(int seed, string logFile)
	{
		SetLogFile(logFile);
		this._0001 = _0005._0003._0001(seed, this);
	}

	public void Dispose()
	{
		_0005._0003._0001(this, true);
		_0010._0014(this);
	}

	~Opaline()
	{
		if (8 == 0)
		{
			return;
		}
		try
		{
			do
			{
				_0005._0003._0001(this, false);
			}
			while (2 == 0);
		}
		finally
		{
			if (5u != 0 && 0 == 0)
			{
				global::_0006._0007(this);
			}
		}
	}

	static Opaline()
	{
		Strings.CreateGetStringDelegate(typeof(Opaline));
	}
}
