using System;
using System.ComponentModel;
using System.Windows;

namespace Xceed.Wpf.Toolkit.Core;

public class ResourceDictionary : System.Windows.ResourceDictionary, ISupportInitialize
{
	private enum InitState
	{
		NotInitialized,
		Initializing,
		Initialized
	}

	private int _initializingCount;

	private string _assemblyName;

	private string _sourcePath;

	public string AssemblyName
	{
		get
		{
			return _assemblyName;
		}
		set
		{
			EnsureInitialization();
			_assemblyName = value;
		}
	}

	public string SourcePath
	{
		get
		{
			return _sourcePath;
		}
		set
		{
			EnsureInitialization();
			_sourcePath = value;
		}
	}

	public ResourceDictionary()
	{
	}

	public ResourceDictionary(string assemblyName, string sourcePath)
	{
		((ISupportInitialize)this).BeginInit();
		AssemblyName = assemblyName;
		SourcePath = sourcePath;
		((ISupportInitialize)this).EndInit();
	}

	protected virtual Uri BuildUri()
	{
		return new Uri(PackUriExtension.BuildRelativePackUriString(AssemblyName, SourcePath), UriKind.Relative);
	}

	private void EnsureInitialization()
	{
		if (_initializingCount <= 0)
		{
			throw new InvalidOperationException(GetType().Name + " properties can only be set while initializing.");
		}
	}

	void ISupportInitialize.BeginInit()
	{
		BeginInit();
		_initializingCount++;
	}

	void ISupportInitialize.EndInit()
	{
		_initializingCount--;
		if (_initializingCount <= 0)
		{
			if (base.Source != null)
			{
				throw new InvalidOperationException("Source property cannot be initialized on the " + GetType().Name);
			}
			if (string.IsNullOrEmpty(AssemblyName) || string.IsNullOrEmpty(SourcePath))
			{
				throw new InvalidOperationException("AssemblyName and SourcePath must be set during initialization");
			}
			Uri source = BuildUri();
			base.Source = source;
		}
		EndInit();
	}
}
