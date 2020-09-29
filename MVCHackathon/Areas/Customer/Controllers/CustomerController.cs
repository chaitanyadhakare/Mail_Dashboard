using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCHackathon.Models;
using MVCHackathon.Services;
using System.Web.Mvc;
using MVCHackathon.Areas.Customer.Models;
using MVCHackathon.Areas.Customer.Services;
using MVCHackathon.utilities;
using MVCHackathon.Areas.Dashboard.Models;
using MVCHackathon.Areas.Dashboard.Services;

namespace MVCHackathon.Areas.Customer.Controllers
{
    public class CustomerController : SessionController
    {
        // GET: Customer/Customer
        public ActionResult Index()
        {
            setupSession();
            DashboardModel model = new DashboardModel();
            DashboardModel OutgoingExternalList = new DashboardModel();
            OutgoingExternalList.Daily = DashboardService.Instance.GetOutgoingToExternalCount("daily", "customer", UserSession);
            OutgoingExternalList.Weekly = DashboardService.Instance.GetOutgoingToExternalCount("weekly", "customer", UserSession);
            OutgoingExternalList.Monthly = DashboardService.Instance.GetOutgoingToExternalCount("monthly", "customer", UserSession);
            OutgoingExternalList.Yearly = DashboardService.Instance.GetOutgoingToExternalCount("yearly", "customer", UserSession);

            model.OutgoingExternalList.Add(OutgoingExternalList);

            DashboardModel OutgoingInternalList = new DashboardModel();
            OutgoingInternalList.Daily = DashboardService.Instance.GetOutgoingToInternalCount("daily", "customer", UserSession);
            OutgoingInternalList.Weekly = DashboardService.Instance.GetOutgoingToInternalCount("weekly", "customer", UserSession);
            OutgoingInternalList.Monthly = DashboardService.Instance.GetOutgoingToInternalCount("monthly", "customer", UserSession);
            OutgoingInternalList.Yearly = DashboardService.Instance.GetOutgoingToInternalCount("yearly", "customer", UserSession);
            model.OutgoingInternalList.Add(OutgoingInternalList);

            DashboardModel IncomingExternalList = new DashboardModel();
            IncomingExternalList.Daily = DashboardService.Instance.GetIncomingFromExternalCount("daily", "customer", UserSession);
            IncomingExternalList.Weekly = DashboardService.Instance.GetIncomingFromExternalCount("weekly", "customer", UserSession);
            IncomingExternalList.Monthly = DashboardService.Instance.GetIncomingFromExternalCount("monthly", "customer", UserSession);
            IncomingExternalList.Yearly = DashboardService.Instance.GetIncomingFromExternalCount("yearly", "customer", UserSession);
            model.IncomingExternalList.Add(IncomingExternalList);

            DashboardModel IncomingInternalList = new DashboardModel();
            IncomingInternalList.Daily = DashboardService.Instance.GetIncomingFromInternalCount("daily", "customer", UserSession);
            IncomingInternalList.Weekly = DashboardService.Instance.GetIncomingFromInternalCount("weekly", "customer", UserSession);
            IncomingInternalList.Monthly = DashboardService.Instance.GetIncomingFromInternalCount("monthly", "customer", UserSession);
            IncomingInternalList.Yearly = DashboardService.Instance.GetIncomingFromInternalCount("yearly", "customer", UserSession);
            model.IncomingInternalList.Add(IncomingInternalList);

            return View(model);
        }
        public ActionResult Register_user()
        {
            setupSession();
            CustomerModel model = new CustomerModel();
            return View(model);        
        }
         [HttpPost]
        [ButtonActionNameSelector(ButtonName = "Register")]
        public ActionResult Register_user(CustomerModel model)
        {
            setupSession();
            bool bretval = false;
            bretval = CustomerService.Instance.InsertRegister(model, UserSession);
            if (bretval)
            {
                ViewBag.Message = "Message has been sent succesfully.";
            }
            return RedirectToAction("ComposeMail");
        }
    }
}