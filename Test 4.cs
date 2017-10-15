// The algorithm runs through the entire file to get the total number of lines
// then it calculates random position using C# native pseudo random class
// It assumes there is enough memory to hold the file and so other algorithm
// like reservoir sampling were not used, as the below method would be faster
// which is required for the efficiency

public List<string> getRandomLines(int m)
{
  List<string> result = new List<string>();
  string* currentLine = reset();

  // 1. calculate the number of lines
  int totalLines = 0;
  while (currentLine.hasNext())
  {
    totalLines++;
    currentLine = currentLine.getNext();
  }

  // 2. get random number
  List<int> randomPosition = new List<int>();
  Random rnd = new Random();
  while (m > 0)
  {
    randomPosition.Add(rnd.Next(0, totalLines - 1));
    m--;
  }
  randomPosition.Sort();

  // 3. reset pointer and set position count
  currentLine = reset();
  int position = 0;

  // 4. get random lines
  while (currentLine.hasNext())
  {
    if (randomPosition.Contains(position))
    {
      result.Add(currentLine.getNext());
    }
    currentLine = currentLine.getNext();
  }
  return result;
}
