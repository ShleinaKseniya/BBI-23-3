using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;



namespace Variant_2
{
    public class Task3
    {
        public class Grep
        {
            private string _input;
            private string _output;

            public Grep(string text)
            {
                _input = text;
                if (!string.IsNullOrEmpty(text))
                {
                    _output = ProcessText();
                }
            }

            public string Input { get { return _input; } }
            public string Output { get { return _output; } }

            public override string ToString()
            {
                return Output;
            }

            private string ProcessText()
            {
                char mostFrequentLetter = _input.ToLower().GroupBy(c => c)
                                           .OrderByDescending(g => g.Count())
                                           .First()
                                           .Key;

                string[] words = _input.Split(' ');
                string output = string.Join(" ", words.Where(word => !word.ToLower().Contains(mostFrequentLetter)));

                return output;
            }
        } 
      
    }
}
