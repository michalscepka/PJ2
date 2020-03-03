using System;

namespace MyAdt
{
	public interface IAdt<T>
	{
		bool IsEmpty();
		bool IsFull();
		void Clear();
	}

	public interface IFronta<T> : IAdt<T>
	{
		void Add(T x);
		T Get();
	}

	public interface IZasobnik<T> : IAdt<T>
	{
		void Push(T x);
		T Pop();
		T Top();
	}
}
