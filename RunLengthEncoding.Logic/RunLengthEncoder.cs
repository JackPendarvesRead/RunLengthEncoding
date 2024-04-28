using System.Security.Cryptography;
using System.Text;

namespace RunLengthEncoding.Logic
{
    public class RunLengthEncoder : IEncoder
    {
        public string Decode(string input)
        {
            var sb = new StringBuilder();

            char[] inputArray = input.ToCharArray();

            if(inputArray.Length % 2 != 0)
            {
                throw new InvalidOperationException("input string is in the wrong format");
            }

            int count = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (i % 2 == 0)
                {
                    count = int.Parse(inputArray[i].ToString());
                }
                else
                {
                    sb.Append(new string(inputArray[i], count));
                    count = 0;
                }
            }

            return sb.ToString();
        }

        public string Encode(string input)
        {
            var sb = new StringBuilder();
            int currentCount = 0;

            char[] inputArray = input.ToCharArray();
            char currentCharacter = input[0];

            for (int i = 0; i < inputArray.Length; i++)
            {
                char next = inputArray[i];
                if(currentCharacter == next)
                {
                    currentCount++;
                }
                else
                {
                    sb.Append($"{currentCount}{currentCharacter}");
                    currentCharacter = next;
                    currentCount = 1;
                }

                if(i == input.Length - 1)
                {
                    sb.Append($"{currentCount}{currentCharacter}");
                }
            }

            return sb.ToString();
        }
    }
}
