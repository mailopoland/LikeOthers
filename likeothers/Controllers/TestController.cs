namespace likeothers.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using likeothers.Models.Business;
    using likeothers.Models.Data;
    using likeothers.Models;

    public class TestController : Controller
    {
        private IRepository _repository;
        private IAction _action;

        public TestController()
        {
            _repository = new EFRepository();
            _action = new TestMethods();
        }

        public TestController(IRepository repository)
        {
            _repository = repository;
        }
        public TestController(IAction action)
        {
            _action = action;
        }

        [HttpGet]
        public ActionResult Question()
        {
            return Redirect("/"); //home
        }
        [HttpPost]
        public ActionResult Question(int id, int selOp = -1)
        {
            //add selected options to session list
            if (selOp != -1)
            {
                List<int> list = (List<int>)Session["allSelOp"];
                list.Add(selOp);
                Session["allSelOp"] = list;
            }

            int amount = _repository.GetQuestCount();
            if (id > amount) 
            {
                return RedirectToAction("Result");
            }
            List<Option> options = _repository.FindQuestions(id);

            return View(options);
        }

        public ActionResult Result()
        {
            if (Session["allSelOp"] == null || ((List<int>)Session["allSelOp"]).Count == 0) return Redirect("/");

            List<int> listResult = (List<int>)Session["allSelOp"];

            //get data from database
            var allPeople = _action.GetAllPeople();
            var sameAns = _action.GetSameAns(listResult);

            //count user stats
            int result = _action.CountUserStat(allPeople, sameAns);

            //get from db text for user
            var resultText = _action.GetResultText(result);

            //save to viewbag
            ViewBag.ResultText = resultText;
            ViewBag.ResultPoints = result;

            //send to db results
            _action.SendResult(listResult);

            return View();
        }
    }
}
