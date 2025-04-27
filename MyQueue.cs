using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐỒ_ÁN_NHÓM_1.Objects
{
	public class Node
	{
		public object data { get; set; }
		public Node Prev { get; set; }
		public Node Next { get; set; }
	}
	public class MyQueue
	{

		private Node rear;
		private Node front;

		public void Enqueue(object ele)
		{
			Node n = new Node();
			n.data = ele;
			if (rear == null)
			{
				rear = n;
				front = n;
			}
			else
			{
				rear.Prev = n;
				n.Next = rear;
				rear = n;
			}
		}

		public Node Dequeue()
		{
			if (front == null) return null;
			Node d = front;
			front = front.Prev;
			if (front == null) { rear = null; }
			else { front.Next = null; }
			return d;
		}
		public bool isEmpty()
		{
			return rear == null || front == null;
		}
		public int Count()
		{
			if (isEmpty()) return 0;

			int count = 0;
			Node current = front;

			while (current != null)
			{
				count++;
				current = current.Prev;
			}

			return count;
		}
		public Node GetNode(int index)
		{
			if (index < 0 || index >= Count())
				throw new IndexOutOfRangeException();

			Node current = front;
			int currentIndex = 0;

			while (currentIndex < index)
			{
				current = current.Prev;
				currentIndex++;
			}

			return current;
		}
		public Node Peek()
		{
			if (rear == null)
				throw new InvalidOperationException("Hàng đợi rỗng");
			return rear;
		}
	}
}



