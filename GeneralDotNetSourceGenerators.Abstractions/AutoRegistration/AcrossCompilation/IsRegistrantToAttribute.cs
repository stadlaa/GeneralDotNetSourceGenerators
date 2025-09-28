using System;

namespace GeneralDotNetSourceGenerators.Abstractions.AutoRegistration.AcrossCompilation
{
	/// <summary>
	///   Apply this attribute to a registrant class to be registered to the registry type.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	public sealed class IsRegistrantToAttribute : Attribute
	{
		public IsRegistrantToAttribute(Type registryType)
		{
			RegistryType = registryType;
		}

		public Type RegistryType;
	}
}