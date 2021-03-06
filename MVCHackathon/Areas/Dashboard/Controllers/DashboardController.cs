﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCHackathon.utilities;
using MVCHackathon.Areas.Dashboard.Models;
using MVCHackathon.Areas.Mailbox.Models;
using MVCHackathon.Areas.Dashboard.Services;
using MVCHackathon.utilities;

namespace MVCHackathon.Areas.Dashboard.Controllers
{
    public class DashboardController : SessionController
    {
        // GET: Dashboard/Dashboard
        public ActionResult Index()
        {
            setupSession();
            DashboardModel model = new DashboardModel();
            DashboardModel OutgoingExternalList = new DashboardModel();
            OutgoingExternalList.Daily = DashboardService.Instance.GetOutgoingToExternalCount("daily", "admin", UserSession);
            OutgoingExternalList.Weekly = DashboardService.Instance.GetOutgoingToExternalCount("weekly", "admin", UserSession);
            OutgoingExternalList.Monthly = DashboardService.Instance.GetOutgoingToExternalCount("monthly", "admin", UserSession);
            OutgoingExternalList.Yearly = DashboardService.Instance.GetOutgoingToExternalCount("yearly", "admin", UserSession);

            model.OutgoingExternalList.Add(OutgoingExternalList);

            DashboardModel OutgoingInternalList = new DashboardModel();
            OutgoingInternalList.Daily = DashboardService.Instance.GetOutgoingToInternalCount("daily", "admin", UserSession);
            OutgoingInternalList.Weekly = DashboardService.Instance.GetOutgoingToInternalCount("weekly", "admin", UserSession);
            OutgoingInternalList.Monthly = DashboardService.Instance.GetOutgoingToInternalCount("monthly", "admin", UserSession);
            OutgoingInternalList.Yearly = DashboardService.Instance.GetOutgoingToInternalCount("yearly", "admin", UserSession);
            model.OutgoingInternalList.Add(OutgoingInternalList);

            DashboardModel IncomingExternalList = new DashboardModel();
            IncomingExternalList.Daily = DashboardService.Instance.GetIncomingFromExternalCount("daily", "admin", UserSession);
            IncomingExternalList.Weekly = DashboardService.Instance.GetIncomingFromExternalCount("weekly", "admin", UserSession);
            IncomingExternalList.Monthly = DashboardService.Instance.GetIncomingFromExternalCount("monthly", "admin", UserSession);
            IncomingExternalList.Yearly = DashboardService.Instance.GetIncomingFromExternalCount("yearly", "admin", UserSession);
            model.IncomingExternalList.Add(IncomingExternalList);

            DashboardModel IncomingInternalList = new DashboardModel();
            IncomingInternalList.Daily = DashboardService.Instance.GetIncomingFromInternalCount("daily", "admin", UserSession);
            IncomingInternalList.Weekly = DashboardService.Instance.GetIncomingFromInternalCount("weekly", "admin", UserSession);
            IncomingInternalList.Monthly = DashboardService.Instance.GetIncomingFromInternalCount("monthly", "admin", UserSession);
            IncomingInternalList.Yearly = DashboardService.Instance.GetIncomingFromInternalCount("yearly", "admin", UserSession);
            model.IncomingInternalList.Add(IncomingInternalList);

            return View(model);
        }

        public ActionResult OutgoingInternalReport()
        {
            setupSession();
            DashboardModel model = new DashboardModel();
            model.DailyList = DashboardService.Instance.GetOutgoingInternalTop10List("daily", UserSession);
            model.WeeklyList = DashboardService.Instance.GetOutgoingInternalTop10List("weekly", UserSession);
            model.MonthlyList = DashboardService.Instance.GetOutgoingInternalTop10List("monthly", UserSession);
            model.YearlyList = DashboardService.Instance.GetOutgoingInternalTop10List("yearly", UserSession);
            return View(model);
        }

        public ActionResult OutgoingExternalReport()
        {
            setupSession();
            DashboardModel model = new DashboardModel();
            model.DailyList = DashboardService.Instance.GetOutgoingExternalTop10List("daily", UserSession);
            model.WeeklyList = DashboardService.Instance.GetOutgoingExternalTop10List("weekly", UserSession);
            model.MonthlyList = DashboardService.Instance.GetOutgoingExternalTop10List("monthly", UserSession);
            model.YearlyList = DashboardService.Instance.GetOutgoingExternalTop10List("yearly", UserSession);
            return View(model);
        }

        public ActionResult IncomingInternalReport()
        {
            setupSession();
            DashboardModel model = new DashboardModel();
            model.DailyList = DashboardService.Instance.GetIncomingInternalTop10List("daily", UserSession);
            model.WeeklyList = DashboardService.Instance.GetIncomingInternalTop10List("weekly", UserSession);
            model.MonthlyList = DashboardService.Instance.GetIncomingInternalTop10List("monthly", UserSession);
            model.YearlyList = DashboardService.Instance.GetIncomingInternalTop10List("yearly", UserSession);
            return View(model);
        }

        public ActionResult IncomingExternalReport()
        {
            setupSession();
            DashboardModel model = new DashboardModel();
            model.DailyList = DashboardService.Instance.GetIncomingExternalTop10List("daily", UserSession);
            model.WeeklyList = DashboardService.Instance.GetIncomingExternalTop10List("weekly", UserSession);
            model.MonthlyList = DashboardService.Instance.GetIncomingExternalTop10List("monthly", UserSession);
            model.YearlyList = DashboardService.Instance.GetIncomingExternalTop10List("yearly", UserSession);
            return View(model);
        }

        public ActionResult OutgoingInternalTop10Ids()
        {
            setupSession();
            DashboardModel model = new DashboardModel();
            model.DailySenderList = DashboardService.Instance.GetOutgoingInternalTop10IdsList("daily", "sender", UserSession);
            model.DailyReceiverList = DashboardService.Instance.GetOutgoingInternalTop10IdsList("daily","receiver", UserSession);

            model.WeeklySenderList = DashboardService.Instance.GetOutgoingInternalTop10IdsList("weekly", "sender", UserSession);
            model.WeeklyReceiverList = DashboardService.Instance.GetOutgoingInternalTop10IdsList("weekly", "receiver", UserSession);

            model.MonthlySenderList = DashboardService.Instance.GetOutgoingInternalTop10IdsList("monthly", "sender", UserSession);
            model.MonthlyReceiverList = DashboardService.Instance.GetOutgoingInternalTop10IdsList("monthly", "receiver", UserSession);

            model.YearlySenderList = DashboardService.Instance.GetOutgoingInternalTop10IdsList("yearly", "sender", UserSession);
            model.YearlyReceiverList = DashboardService.Instance.GetOutgoingInternalTop10IdsList("yearly", "receiver", UserSession);

            return View(model);
        }

        public ActionResult OutgoingExternalTop10Ids()
        {
            setupSession();
            DashboardModel model = new DashboardModel();
            model.DailySenderList = DashboardService.Instance.GetOutgoingExternalTop10IdsList("daily", "sender", UserSession);
            model.DailyReceiverList = DashboardService.Instance.GetOutgoingExternalTop10IdsList("daily", "receiver", UserSession);

            model.WeeklySenderList = DashboardService.Instance.GetOutgoingExternalTop10IdsList("weekly", "sender", UserSession);
            model.WeeklyReceiverList = DashboardService.Instance.GetOutgoingExternalTop10IdsList("weekly", "receiver", UserSession);

            model.MonthlySenderList = DashboardService.Instance.GetOutgoingExternalTop10IdsList("monthly", "sender", UserSession);
            model.MonthlyReceiverList = DashboardService.Instance.GetOutgoingExternalTop10IdsList("monthly", "receiver", UserSession);

            model.YearlySenderList = DashboardService.Instance.GetOutgoingExternalTop10IdsList("yearly", "sender", UserSession);
            model.YearlyReceiverList = DashboardService.Instance.GetOutgoingExternalTop10IdsList("yearly", "receiver", UserSession);

            return View(model);
        }

        public ActionResult IncomingInternalTop10Ids()
        {
            setupSession();
            DashboardModel model = new DashboardModel();
            model.DailySenderList = DashboardService.Instance.GetIncomingInternalTop10IdsList("daily", "sender", UserSession);
            model.DailyReceiverList = DashboardService.Instance.GetIncomingInternalTop10IdsList("daily", "receiver", UserSession);

            model.WeeklySenderList = DashboardService.Instance.GetIncomingInternalTop10IdsList("weekly", "sender", UserSession);
            model.WeeklyReceiverList = DashboardService.Instance.GetIncomingInternalTop10IdsList("weekly", "receiver", UserSession);

            model.MonthlySenderList = DashboardService.Instance.GetIncomingInternalTop10IdsList("monthly", "sender", UserSession);
            model.MonthlyReceiverList = DashboardService.Instance.GetIncomingInternalTop10IdsList("monthly", "receiver", UserSession);

            model.YearlySenderList = DashboardService.Instance.GetIncomingInternalTop10IdsList("yearly", "sender", UserSession);
            model.YearlyReceiverList = DashboardService.Instance.GetIncomingInternalTop10IdsList("yearly", "receiver", UserSession);

            return View(model);
        }

        public ActionResult IncomingExternalTop10Ids()
        {
            setupSession();
            DashboardModel model = new DashboardModel();
            model.DailySenderList = DashboardService.Instance.GetIncomingExternalTop10IdsList("daily", "sender", UserSession);
            model.DailyReceiverList = DashboardService.Instance.GetIncomingExternalTop10IdsList("daily", "receiver", UserSession);

            model.WeeklySenderList = DashboardService.Instance.GetIncomingExternalTop10IdsList("weekly", "sender", UserSession);
            model.WeeklyReceiverList = DashboardService.Instance.GetIncomingExternalTop10IdsList("weekly", "receiver", UserSession);

            model.MonthlySenderList = DashboardService.Instance.GetIncomingExternalTop10IdsList("monthly", "sender", UserSession);
            model.MonthlyReceiverList = DashboardService.Instance.GetIncomingExternalTop10IdsList("monthly", "receiver", UserSession);

            model.YearlySenderList = DashboardService.Instance.GetIncomingExternalTop10IdsList("yearly", "sender", UserSession);
            model.YearlyReceiverList = DashboardService.Instance.GetIncomingExternalTop10IdsList("yearly", "receiver", UserSession);

            return View(model);
        }


        public ActionResult OutgoingInternalAttachmentSize()
        {
            setupSession();
            DashboardModel model = new DashboardModel();
            model.DailySenderList = DashboardService.Instance.GetOutgoingInternalTopAttachementList("daily", "sender", UserSession);
            model.DailyReceiverList = DashboardService.Instance.GetOutgoingInternalTopAttachementList("daily", "receiver", UserSession);

            model.WeeklySenderList = DashboardService.Instance.GetOutgoingInternalTopAttachementList("weekly", "sender", UserSession);
            model.WeeklyReceiverList = DashboardService.Instance.GetOutgoingInternalTopAttachementList("weekly", "receiver", UserSession);

            model.MonthlySenderList = DashboardService.Instance.GetOutgoingInternalTopAttachementList("monthly", "sender", UserSession);
            model.MonthlyReceiverList = DashboardService.Instance.GetOutgoingInternalTopAttachementList("monthly", "receiver", UserSession);

            model.YearlySenderList = DashboardService.Instance.GetOutgoingInternalTopAttachementList("yearly", "sender", UserSession);
            model.YearlyReceiverList = DashboardService.Instance.GetOutgoingInternalTopAttachementList("yearly", "receiver", UserSession);

            return View(model);
        }

        public ActionResult OutgoingExternalAttachmentSize()
        {
            setupSession();
            DashboardModel model = new DashboardModel();
            model.DailySenderList = DashboardService.Instance.GetOutgoingExternalTopAttachementList("daily", "sender", UserSession);
            model.DailyReceiverList = DashboardService.Instance.GetOutgoingExternalTopAttachementList("daily", "receiver", UserSession);

            model.WeeklySenderList = DashboardService.Instance.GetOutgoingExternalTopAttachementList("weekly", "sender", UserSession);
            model.WeeklyReceiverList = DashboardService.Instance.GetOutgoingExternalTopAttachementList("weekly", "receiver", UserSession);

            model.MonthlySenderList = DashboardService.Instance.GetOutgoingExternalTopAttachementList("monthly", "sender", UserSession);
            model.MonthlyReceiverList = DashboardService.Instance.GetOutgoingExternalTopAttachementList("monthly", "receiver", UserSession);

            model.YearlySenderList = DashboardService.Instance.GetOutgoingExternalTopAttachementList("yearly", "sender", UserSession);
            model.YearlyReceiverList = DashboardService.Instance.GetOutgoingExternalTopAttachementList("yearly", "receiver", UserSession);

            return View(model);
        }

        public ActionResult IncomingInternalAttachmentSize()
        {
            setupSession();
            DashboardModel model = new DashboardModel();
            model.DailySenderList = DashboardService.Instance.GetIncomingInternalTopAttachementList("daily", "sender", UserSession);
            model.DailyReceiverList = DashboardService.Instance.GetIncomingInternalTopAttachementList("daily", "receiver", UserSession);

            model.WeeklySenderList = DashboardService.Instance.GetIncomingInternalTopAttachementList("weekly", "sender", UserSession);
            model.WeeklyReceiverList = DashboardService.Instance.GetIncomingInternalTopAttachementList("weekly", "receiver", UserSession);

            model.MonthlySenderList = DashboardService.Instance.GetIncomingInternalTopAttachementList("monthly", "sender", UserSession);
            model.MonthlyReceiverList = DashboardService.Instance.GetIncomingInternalTopAttachementList("monthly", "receiver", UserSession);

            model.YearlySenderList = DashboardService.Instance.GetIncomingInternalTopAttachementList("yearly", "sender", UserSession);
            model.YearlyReceiverList = DashboardService.Instance.GetIncomingInternalTopAttachementList("yearly", "receiver", UserSession);

            return View(model);
        }

        public ActionResult IncomingExternalAttachmentSize()
        {
            setupSession();
            DashboardModel model = new DashboardModel();
            model.DailySenderList = DashboardService.Instance.GetIncomingExternalTopAttachementList("daily", "sender", UserSession);
            model.DailyReceiverList = DashboardService.Instance.GetIncomingExternalTopAttachementList("daily", "receiver", UserSession);

            model.WeeklySenderList = DashboardService.Instance.GetIncomingExternalTopAttachementList("weekly", "sender", UserSession);
            model.WeeklyReceiverList = DashboardService.Instance.GetIncomingExternalTopAttachementList("weekly", "receiver", UserSession);

            model.MonthlySenderList = DashboardService.Instance.GetIncomingExternalTopAttachementList("monthly", "sender", UserSession);
            model.MonthlyReceiverList = DashboardService.Instance.GetIncomingExternalTopAttachementList("monthly", "receiver", UserSession);

            model.YearlySenderList = DashboardService.Instance.GetIncomingExternalTopAttachementList("yearly", "sender", UserSession);
            model.YearlyReceiverList = DashboardService.Instance.GetIncomingExternalTopAttachementList("yearly", "receiver", UserSession);

            return View(model);
        }
    }
}