// The algorithm calculates the n and i by using shifting and masking
// after the calculation the setting of data is straight forward

static int getLength (byte x) // n
{
  return (x >> 4) & 15;
}

static int getOffset (byte x) // i
{
  return (x >> 0) & 15;
}

static void setDest (byte[] dest, int position, byte data)
{
  dest[position] = data;
}

static void unpack(byte[] src, byte[] dest)
{
  int currentPosition = 0;
  while (getLength(src[currentPosition]) != 0 && currentPosition < src.Count())
  {
    int n = getLength(src[currentPosition]);
    int i = getOffset(src[currentPosition]);
    Array.Copy(src, currentPosition + 1, dest, i, n);

    currentPosition += n + 1;
  }
}
