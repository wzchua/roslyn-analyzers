﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Analyzer.Utilities;
using Analyzer.Utilities.FlowAnalysis.Analysis.TaintedDataAnalysis;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.NetCore.Analyzers.Security.Helpers;

namespace Microsoft.NetCore.Analyzers.Security
{
    [DiagnosticAnalyzer(LanguageNames.CSharp, LanguageNames.VisualBasic)]
    public class DoNotHardCodeEncryptionKey : SourceTriggeredTaintedDataAnalyzerBase
    {
        internal static DiagnosticDescriptor Rule = SecurityHelpers.CreateDiagnosticDescriptor(
            "CA5390",
            typeof(SystemSecurityCryptographyResources),
            nameof(SystemSecurityCryptographyResources.DoNotHardCodeEncryptionKey),
            nameof(SystemSecurityCryptographyResources.DoNotHardCodeEncryptionKeyMessage),
            DiagnosticHelpers.EnabledByDefaultIfNotBuildingVSIX,
            helpLinkUri: null,
            descriptionResourceStringName: nameof(SystemSecurityCryptographyResources.DoNotHardCodeEncryptionKeyDescription),
            customTags: WellKnownDiagnosticTagsExtensions.DataflowAndTelemetry);

        protected override SinkKind SinkKind { get { return SinkKind.HardcodedEncryptionKey; } }

        protected override DiagnosticDescriptor TaintedDataEnteringSinkDescriptor { get { return Rule; } }
    }
}
