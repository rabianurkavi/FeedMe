﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeedMe.Controllers
{
    public class MessageController : Controller
    {
        MessageValidator messageValidator = new MessageValidator();
        MessageManager messageManager = new MessageManager(new EfMessageDal());

        // GET: Message
        //[Authorize]
        public ActionResult Inbox()
        {
            string p = (string)Session["AdminMail"];
            var messagelist = messageManager.GetListInbox(p);
            return View(messagelist);
        }
        public ActionResult Sendbox()
        {
            string p = (string)Session["AdminMail"];
            var messagelist = messageManager.GetListSendbox(p);
            return View(messagelist);
        }
        public ActionResult GetInboxDetails(int id)
        {
            var messageValue = messageManager.GetByID(id);
            return View(messageValue);
        }
        public ActionResult GetSendboxDetails(int id)
        {
            var messageValue = messageManager.GetByID(id);
            return View(messageValue);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {

            ValidationResult results = messageValidator.Validate(message);
            if (results.IsValid)
            {
                message.SenderMail = "kavirabiaa@gmail.com";
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.MessageAdd(message);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult DeleteMessage(int id)
        {
            var messageValue = messageManager.GetByID(id);
            messageManager.MessageDelete(messageValue);
            return RedirectToAction("Inbox");
        }
        public ActionResult InDrafts()
        {

            var messageList = messageManager.GetListDrafts();
            return View(messageList);
        }
    }
}