using ĐỒ_ÁN_NHÓM_1.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Doan.Form1;

namespace Doan
{
	public class DSFileHTML
	{
		public MyQueue dsFile = new MyQueue();
		public MyQueue DSFile { get => dsFile; set => dsFile = value; }

		public DSFileHTML DSFileHTML1
		{
			get => default;
			set
			{
			}
		}

		public DSFileHTML() { }
		public void enqueueDS(FileHTML file)
		{
			if (!daTonTai(file.url))
			{
				dsFile.Enqueue(file);
			}
		}
		public FileHTML dequeueDS()
		{
			return (FileHTML)DSFile.Dequeue().data;
		}
		public int demDS()
		{
			return DSFile.Count();
		}
		public Node layNode(int index)
		{
			return DSFile.GetNode(index);
		}
		public bool daTonTai(string url)
		{
			for (int i = 0; i < demDS(); i++)
			{
				FileHTML file = (FileHTML)layNode(i).data;
				if (file.url.Equals(url, StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
			return false;
		}
	}
}

