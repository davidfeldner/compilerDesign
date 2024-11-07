The mistake in the queue is in the get function 
public synchronized int get() {
    if (head.next == null) 
      return -999;
    Node first = head;
    head = first.next;
    return head.item;
  }

We do not explicitly set first.next to be null. Doing this will ensure that when an item is is popped of the stack, it can be garbage collected from the list.

public synchronized int get() {
  if (head.next == null) 
    return -999;
  Node first = head;
  head = first.next;
  first.next = null;  // edit
  return head.item;
}
