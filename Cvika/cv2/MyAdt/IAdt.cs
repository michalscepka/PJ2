using System;

namespace MyAdt
{
	public interface IAdt
	{
		bool IsEmpty();
		bool IsFull();
		void Clear();
	}

	public interface IFronta : IAdt
	{
		void Add(int x);
		int Get();
	}

	public interface IZasobnik : IAdt
	{
		void Push(int x);
		int Pop();
		int Top();
	}
}
