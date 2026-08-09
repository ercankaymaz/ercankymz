namespace ACadSharp.Objects.Collections;

public class ScaleCollection : ObjectDictionaryCollection<Scale>
{
	public ScaleCollection(CadDictionary dictionary)
		: base(dictionary)
	{
	}

	public void CreateDefaults()
	{
		_dictionary.TryAdd(new Scale
		{
			Name = "1:1",
			PaperUnits = 1.0,
			DrawingUnits = 1.0,
			IsUnitScale = true
		});
		_dictionary.TryAdd(new Scale
		{
			Name = "1:2",
			PaperUnits = 1.0,
			DrawingUnits = 2.0,
			IsUnitScale = false
		});
		_dictionary.TryAdd(new Scale
		{
			Name = "1:4",
			PaperUnits = 1.0,
			DrawingUnits = 4.0,
			IsUnitScale = false
		});
		_dictionary.TryAdd(new Scale
		{
			Name = "1:5",
			PaperUnits = 1.0,
			DrawingUnits = 5.0,
			IsUnitScale = false
		});
		_dictionary.TryAdd(new Scale
		{
			Name = "1:8",
			PaperUnits = 1.0,
			DrawingUnits = 8.0,
			IsUnitScale = false
		});
		_dictionary.TryAdd(new Scale
		{
			Name = "1:10",
			PaperUnits = 1.0,
			DrawingUnits = 10.0,
			IsUnitScale = false
		});
		_dictionary.TryAdd(new Scale
		{
			Name = "1:16",
			PaperUnits = 1.0,
			DrawingUnits = 16.0,
			IsUnitScale = false
		});
		_dictionary.TryAdd(new Scale
		{
			Name = "1:20",
			PaperUnits = 1.0,
			DrawingUnits = 20.0,
			IsUnitScale = false
		});
		_dictionary.TryAdd(new Scale
		{
			Name = "1:30",
			PaperUnits = 1.0,
			DrawingUnits = 30.0,
			IsUnitScale = false
		});
		_dictionary.TryAdd(new Scale
		{
			Name = "1:40",
			PaperUnits = 1.0,
			DrawingUnits = 40.0,
			IsUnitScale = false
		});
		_dictionary.TryAdd(new Scale
		{
			Name = "1:50",
			PaperUnits = 1.0,
			DrawingUnits = 50.0,
			IsUnitScale = false
		});
		_dictionary.TryAdd(new Scale
		{
			Name = "1:100",
			PaperUnits = 1.0,
			DrawingUnits = 100.0,
			IsUnitScale = false
		});
		_dictionary.TryAdd(new Scale
		{
			Name = "2:1",
			PaperUnits = 2.0,
			DrawingUnits = 1.0,
			IsUnitScale = false
		});
		_dictionary.TryAdd(new Scale
		{
			Name = "4:1",
			PaperUnits = 4.0,
			DrawingUnits = 1.0,
			IsUnitScale = false
		});
		_dictionary.TryAdd(new Scale
		{
			Name = "8:1",
			PaperUnits = 8.0,
			DrawingUnits = 1.0,
			IsUnitScale = false
		});
		_dictionary.TryAdd(new Scale
		{
			Name = "10:1",
			PaperUnits = 10.0,
			DrawingUnits = 1.0,
			IsUnitScale = false
		});
		_dictionary.TryAdd(new Scale
		{
			Name = "100:1",
			PaperUnits = 100.0,
			DrawingUnits = 1.0,
			IsUnitScale = false
		});
	}
}
