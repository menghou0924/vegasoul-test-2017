// The algorithm makes a list detailing the current position of each particle
// The animation will be made by going through all the particles and putting an X
// over where they are positioned
// There will be no problem with overlapping particles since they will just be
// marked in a multiple times
// It then calculates the next position and updates the list and repeat the process

static List<string> animate(int speed, string init)
{
  List<string> result = new List<string>();
  int initLength = init.Length;

  // 1. Create a list that stores the particle type and the position after each iteration
  // Format: "L(-1)/R(1)", position1, posiiton 2, ...
  List< List<int> > particlePosition = new List< List<int> >();
  for (int i = 0; i < initLength; i++)
  {
    if (init[i] == 'L') // L is stored as -1 for the usage of decreasing position
    {
      List<int> newParticle = new List<int>();
      newParticle.Add(-1);
      newParticle.Add(i);
      particlePosition.Add(newParticle);
    }
    if (init[i] == 'R') // R is on the reverse stored as 1
    {
      List<int> newParticle = new List<int>();
      newParticle.Add(1);
      newParticle.Add(i);
      particlePosition.Add(newParticle);
    }
  }

  // 2. Iterate while there are still particles in the chamber
  bool isContinue = true;
  while (isContinue)
  {
    isContinue = false;
    // 3. Build new animation
    StringBuilder newResult = new StringBuilder(new String('.', initLength));
    for (int i = 0; i < particlePosition.Count; i++)
    {
      if (particlePosition[i][particlePosition[i].Count - 1] != -2) // -2 means out of range
      {
        newResult[ particlePosition[i][ particlePosition[i].Count - 1] ] = 'X';
      }
    }
    if (newResult.ToString() != new String('.', initLength)) result.Add(newResult.ToString());

    // 4. Get next position
    for (int i = 0; i < particlePosition.Count; i++)
    {
      int currentPosition = particlePosition[i][ particlePosition[i].Count - 1 ];
      int calculatedPosition = currentPosition == -2 ? -2 : particlePosition[i][0] * speed + currentPosition; // -2 means the particle is no longer in the chamber
      int newPosition = calculatedPosition >= initLength ? -2 : (calculatedPosition < 0 ? -2 : calculatedPosition); // re-assess if it is out of the chamber
      particlePosition[i].Add(newPosition);
      if (newPosition != -2) isContinue = true;
    }
  }
  result.Add(new String('.', initLength));

  return result;
}
