﻿using System;
using System.Collections;
using System.Collections.Generic;
using TrivialArchitecture.DAL.Entities;
using TrivialArchitecture.DAL.Interfaces;

namespace TrivialArchitecture.DAL.Base
{
	public class DbSet<T>: IList<T> where T : class, IBaseEntity<long>
	{
		private readonly DbContext dbContext;

		public DbSet(DbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		#region IList{T}

		public IEnumerator<T> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Add(T item)
		{
			throw new NotImplementedException();
		}

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public bool Contains(T item)
		{
			throw new NotImplementedException();
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		public bool Remove(T item)
		{
			throw new NotImplementedException();
		}

		public int Count { get; }
		public bool IsReadOnly { get; }
		public int IndexOf(T item)
		{
			throw new NotImplementedException();
		}

		public void Insert(int index, T item)
		{
			throw new NotImplementedException();
		}

		public void RemoveAt(int index)
		{
			throw new NotImplementedException();
		}

		public T this[int index]
		{
			get => throw new NotImplementedException();
			set => throw new NotImplementedException();
		}

		#endregion
	}
}
