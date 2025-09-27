using System;

namespace GeneralSourceGenerators.Abstractions.AutoRegistration.AcrossCompilation
{
	/// <summary>
	///   Apply this attribute to a registry class to augment its static constructor to call Register() on all corresponding IRegistrant implementations in the assembly.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	public sealed class IsRegistryAttribute : Attribute
	{ }
}
