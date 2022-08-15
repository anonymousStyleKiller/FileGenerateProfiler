namespace Profiling;

public sealed class Generator
{
    private readonly Random _random = new();
    private string[] _words;
    public Generator()
    {

        _words = Enumerable.Range(0, 1000)
            .Select(_ =>
            {
                var range = Enumerable.Range(0, _random.Next(20, 100));
                var chars = range.Select(x => (char)_random.Next('A', 'Z')).ToArray();
                return new string(chars);
            }).ToArray();
    }

    public void Generate(int linesCount)
    {
       var fileName = "L" + linesCount + ".txt";
       using (var writer = new StreamWriter(fileName))
       {
           for (int i = 0; i < linesCount; i++)
           {
               writer.WriteLine(GenerateNumber()+ "."+ GenerateString());
           }
       }
    }

    private string GenerateString() => _words[_random.Next(0, _words.Length)];

    private string GenerateNumber() => _random.Next(0, 10000).ToString();
}