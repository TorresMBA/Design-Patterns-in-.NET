using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Generator
{
    public class GeneratorDirector
    {
        private IBuilderGenerate _generate;

        public GeneratorDirector(IBuilderGenerate generate)
        {
            _generate = generate;
        }

        public void SetBuilder(IBuilderGenerate generate) => _generate = generate;
        
        public void CreateSimpleJsonGenerator(List<string> content, string path)
        {
            _generate.Reset();
            _generate.SetContent(content);
            _generate.SetPath(path);
            _generate.SetFormat(TypeFormat.Json);
        }

        public void CreateSimplePipeGenerator(List<string> content, string path)
        {
            _generate.Reset();
            _generate.SetContent(content);
            _generate.SetPath(path);
            _generate.SetFormat(TypeFormat.Pipes);
            _generate.SetCharacter(TypeCharacter.Uppercase);
        }
    }
}
