﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Interfaces
{
    public interface ICRUD<T>
    {
        void Insert(T t);
        void Update(T t);
        void Delete(T t);
        IEnumerable<T> GetAll();
        T GetOneByID(int id);
    }
}
