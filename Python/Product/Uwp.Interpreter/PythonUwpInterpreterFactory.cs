// Python Tools for Visual Studio
// Copyright(c) Microsoft Corporation
// All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the License); you may not use
// this file except in compliance with the License. You may obtain a copy of the
// License at http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED ON AN  *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY
// IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
//
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.

using Microsoft.PythonTools.Interpreter;
using System.IO;

namespace Microsoft.PythonTools.Uwp.Interpreter {
    class PythonUwpInterpreterFactory : PythonInterpreterFactoryWithDatabase {
        private static readonly InterpreterFactoryCreationOptions CreationOptions = new InterpreterFactoryCreationOptions {
            PackageManager = BuiltInPackageManagers.Pip,
            WatchFileSystem = true
        };

        public PythonUwpInterpreterFactory(InterpreterConfiguration configuration) 
            : base(configuration, new InterpreterFactoryCreationOptions {
                PackageManager = BuiltInPackageManagers.Pip,
                DatabasePath = Path.Combine(configuration.PrefixPath, "completionDB"),
                WatchFileSystem = true
            }) {
        }

        public override IPythonInterpreter MakeInterpreter(PythonInterpreterFactoryWithDatabase factory) {
            return new PythonUwpInterpreter(factory);
        }
    }
}
