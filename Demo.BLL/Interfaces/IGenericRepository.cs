﻿using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
	public interface IGenericRepository<T>
	{
		IEnumerable<T> GetAll();
		T GetById(int Id);
		void Add(T item);
		void Update(T item);
		void Delete(T item);
	}
}
