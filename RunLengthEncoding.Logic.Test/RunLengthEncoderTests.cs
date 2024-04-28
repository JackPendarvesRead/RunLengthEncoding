using FluentAssertions;

namespace RunLengthEncoding.Logic.Test
{
    public class RunLengthEncoderTests
    {
        [Theory]
        [InlineData("AAABBBCCC", "3A3B3C")]
        [InlineData("ABCDEFG", "1A1B1C1D1E1F1G")]
        [InlineData("AaBbCc", "1A1a1B1b1C1c")]
        [InlineData("AAddDDDccc", "2A2d3D3c")]
        public void Encode_should_return_expected_output(string input, string expectedOutput)
        {
            var encoder = new RunLengthEncoder();

            var output = encoder.Encode(input);

            output.Should().Be(expectedOutput);
        }

        [Theory]
        [InlineData("3A3B3C", "AAABBBCCC")]
        [InlineData("1A1B1C1D1E1F1G", "ABCDEFG")]
        [InlineData("1A1a1B1b1C1c", "AaBbCc")]
        [InlineData("2A2d3D3c", "AAddDDDccc")]
        public void Decode_should_return_expected_output(string input, string expectedOutput)
        {
            var encoder = new RunLengthEncoder();

            var output = encoder.Decode(input);

            output.Should().Be(expectedOutput);
        }

        [Fact]
        public void Decode_should_throw_exception_on_invalid_input()
        {
            var encoder = new RunLengthEncoder();

            Action action = () => encoder.Decode("This is an invalid string");

            action.Should().Throw<InvalidOperationException>();
        }
    }
}