using Microsoft.CodeAnalysis;

namespace GeneralDotNetSourceGenerators.Shared.Logging;

public class GeneratorLogging
{
	public static void ReportInfo(SourceProductionContext context, string message, params object[] args)
	{
		var descriptor = new DiagnosticDescriptor(
			id: "GEN001",
			title: "Generator Info",
			messageFormat: message,
			category: "SourceGenerator",
			DiagnosticSeverity.Info,
			isEnabledByDefault: true
		);
		context.ReportDiagnostic(Diagnostic.Create(descriptor, Location.None, args));
	}

	public static void ReportError(SourceProductionContext context, string message, params object[] args)
	{
		var descriptor = new DiagnosticDescriptor(
			id: "GEN001",
			title: "Generator Error",
			messageFormat: message,
			category: "SourceGenerator",
			DiagnosticSeverity.Error,
			isEnabledByDefault: true
		);
		context.ReportDiagnostic(Diagnostic.Create(descriptor, Location.None, args));
	}

	public static void ReportHidden(SourceProductionContext context, string message, params object[] args)
	{
		var descriptor = new DiagnosticDescriptor(
			id: "GEN001",
			title: "Generator Hidden Report",
			messageFormat: message,
			category: "SourceGenerator",
			DiagnosticSeverity.Hidden,
			isEnabledByDefault: true
		);
		context.ReportDiagnostic(Diagnostic.Create(descriptor, Location.None, args));
	}

	public static void ReportWarning(SourceProductionContext context, string message, params object[] args)
	{
		var descriptor = new DiagnosticDescriptor(
			id: "GEN001",
			title: "Generator Warning",
			messageFormat: message,
			category: "SourceGenerator",
			DiagnosticSeverity.Warning,
			isEnabledByDefault: true
		);
		context.ReportDiagnostic(Diagnostic.Create(descriptor, Location.None, args));
	}
}
