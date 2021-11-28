﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterServices
    {
        readonly IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            this._writerDal = writerDal;
        }

        public void WriterAdd(Writer writer)
        {
            _writerDal.Insert(writer);
        }
    }
}