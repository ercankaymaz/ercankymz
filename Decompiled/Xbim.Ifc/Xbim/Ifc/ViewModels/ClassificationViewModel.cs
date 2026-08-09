using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xbim.Common;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc.ViewModels;

[DebuggerDisplay("ClassificationVM: {Name}: {Children}")]
public class ClassificationViewModel
{
	private readonly IIfcClassificationReference _classification;

	private readonly IModel _model;

	private ObservableCollection<ClassificationViewModel> _subClassifications;

	public string Name
	{
		get
		{
			if (_classification.Name.HasValue)
			{
				IfcLabel? name = _classification.Name;
				if (!name.HasValue)
				{
					return null;
				}
				return name.GetValueOrDefault();
			}
			if (_classification.Identification.HasValue)
			{
				IfcIdentifier? identification = _classification.Identification;
				if (!identification.HasValue)
				{
					return null;
				}
				return identification.GetValueOrDefault();
			}
			if (_classification.Description.HasValue)
			{
				IfcText? description = _classification.Description;
				if (!description.HasValue)
				{
					return null;
				}
				return description.GetValueOrDefault();
			}
			return "";
		}
	}

	public ObservableCollection<ClassificationViewModel> SubClassifications
	{
		get
		{
			if (_subClassifications == null)
			{
				_subClassifications = new ObservableCollection<ClassificationViewModel>();
				foreach (IIfcClassificationReference hasReference in _classification.HasReferences)
				{
					_subClassifications.Add(new ClassificationViewModel(hasReference));
				}
			}
			return _subClassifications;
		}
	}

	public ClassificationViewModel(IIfcClassificationReference classification)
	{
		if (classification == null)
		{
			throw new ArgumentNullException("classification");
		}
		_classification = classification;
		_model = classification.Model;
	}
}
