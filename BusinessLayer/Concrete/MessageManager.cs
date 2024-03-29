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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;
        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetByID(int id)
        {
            return _messageDal.Get(x => x.MessageId == id);
        }

        public List<Message> ListInbox()
        {
            return _messageDal.List(x => x.SenderMail == "admin@gmail.com");
        }

        public List<Message> GetListDrafts()
        {
            return _messageDal.List(x => x.SenderMail == "kavirabiaa@gmail.com");
        }

        public List<Message> GetListInbox(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p);
        }
        public List<Message> GetListSendbox(string p)
        {
            return _messageDal.List(x => x.SenderMail == p);
        }

        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            _messageDal.Delete(message);
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }

        public List<Message> ListSendBox()
        {
            return _messageDal.List(x => x.ReceiverMail == "admin@gmail.com");
        }

        //public List<Message> GetListWriterInbox(int id)
        //{
        //    return _messageDal.List(x=>x.ReceiverMail==)
        //}

        //public List<Message> GetListWriterSendbox(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
