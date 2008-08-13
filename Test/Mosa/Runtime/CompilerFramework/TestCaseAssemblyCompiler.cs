﻿/*
 * (c) 2008 MOSA - The Managed Operating System Alliance
 *
 * Licensed under the terms of the New BSD License.
 *
 * Authors:
 *  Michael Ruck (<mailto:sharpos@michaelruck.de>)
 */

using System;
using System.Collections.Generic;
using System.Text;

using Mosa.Runtime.CompilerFramework;
using x86 = Mosa.Platforms.x86;
using Mosa.Runtime.Loader;
using Mosa.Runtime.Vm;

namespace Test.Mosa.Runtime.CompilerFramework
{
    class TestCaseAssemblyCompiler : AssemblyCompiler
    {
        private TestCaseAssemblyCompiler(IArchitecture architecture, IMetadataModule module) :
            base(architecture, module)
        {
            // Build the assembly compiler pipeline
            CompilerPipeline<IAssemblyCompilerStage> pipeline = this.Pipeline;
            pipeline.AddRange(new IAssemblyCompilerStage[] {
                new TypeLayoutStage(),
                new MethodCompilerBuilderStage(),
            });
            architecture.ExtendAssemblyCompilerPipeline(pipeline);
        }

        public static void Compile(IMetadataModule module)
        {

            IArchitecture architecture = x86.Architecture.CreateArchitecture(module.Metadata, x86.ArchitectureFeatureFlags.AutoDetect);
            new TestCaseAssemblyCompiler(architecture, module).Compile();
        }

        public override MethodCompilerBase CreateMethodCompiler(RuntimeType type, RuntimeMethod method)
        {
            IArchitecture arch = this.Architecture;
            MethodCompilerBase mc = new TestCaseMethodCompiler(this.Architecture, this.Assembly, type, method);
            arch.ExtendMethodCompilerPipeline(mc.Pipeline);
            return mc;
        }
    }
}
