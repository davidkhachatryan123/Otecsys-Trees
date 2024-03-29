namespace Trees.Generator;

public class Shared
{
  public static string RandomString(int length, Random random)
  {
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    return new string(Enumerable.Repeat(chars, length)
      .Select(s => s[random.Next(s.Length)]).ToArray());
  }
}