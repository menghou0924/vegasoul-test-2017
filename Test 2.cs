// The algorithm utilize a queue and breath first search
// each time it just get all the childs from all the nodes in the last level
// and print them all out if it is in the right level
// and the process is repeated to get to the required level
static void print_tree_level(Node root, int depth)
{
  if (root == null) return;

  Queue<Node> q = new Queue<Node>();
  int currentDepth = 0;

  q.Enqueue(root);
  while(q.Count > 0)
  {
    int queueSize = q.Count;
    while (queueSize > 0)
    {
      Node newNode = q.Dequeue();
      if (currentDepth == depth) Console.Write(" " + newNode.data);
      if (newNode.left_child != null) q.Enqueue(newNode.left_child);
      if (newNode.right_child != null) q.Enqueue(newNode.right_child);
      queueSize--;
    }
    currentDepth++;
  }
}
