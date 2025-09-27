using Microsoft.CodeAnalysis;

namespace GeneralSourceGenerators.Shared.Helpers;

public static class HintNameHelper
{
	public static string UniqueHintNamePerType(INamedTypeSymbol symbol) => UniqueHintNamePerType((ITypeSymbol)symbol);

	public static string UniqueHintNamePerType(ITypeSymbol symbol) =>
		symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)
			.Replace("global::", "")
			.Replace(".", "_")
			.Replace(":", "_")
			.Replace("<", "_")
			.Replace(">", "_");
}