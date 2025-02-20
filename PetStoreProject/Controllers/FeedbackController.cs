﻿using Microsoft.AspNetCore.Mvc;
using PetStoreProject.Models;
using PetStoreProject.ViewModels;

namespace PetStoreProject.Controllers
{
	public class FeedbackController : Controller
	{
		private readonly PetStoreDBContext _context;

		public FeedbackController(PetStoreDBContext context)
		{
			_context = context;
		}

		[HttpPost]
		public IActionResult Submit()
		{
			int pid = Int32.Parse(Request.Form["pid"]);
			Feedback feedback = new Feedback();
			feedback.ProductId = pid;
			feedback.Name = Request.Form["FullName"];
			feedback.Phone = Request.Form["PhoneNumber"];
			feedback.Email = Request.Form["Email"];
			feedback.Rating = Int32.Parse(Request.Form["rating"]);
			feedback.Content = Request.Form["Content"];
            feedback.Status = false;
            feedback.DateCreated = DateTime.Now;
			_context.Feedbacks.Add(feedback);
			_context.SaveChanges();
			return RedirectToAction("Detail", "Product", new { productId = Request.Form["pid"] });
		}

		[HttpPost]
		public JsonResult CheckOrderProduct(string phoneNumber, int pid)
		{
			var listProductOptionIdOrder = (from o in _context.Orders
											where o.Phone == phoneNumber
											join ot in _context.OrderItems on o.OrderId equals ot.OrderId
											select ot.ProductOptionId);

			var listPOId = _context.ProductOptions
								   .Where(po => po.ProductId == pid)
								   .Select(po => po.ProductOptionId);

			bool haveOrdered = listProductOptionIdOrder.Any(i => listPOId.Contains(i));

			//bool phoneNumberExistsOrder = _context.Orders.Any(o => o.Phone == phoneNumber);

			if (haveOrdered)
				return Json(new { status = "success" });
			else
				return Json(new { status = "error", message = "Bạn không thể comment vì bạn chưa mua hàng." });
		}
	}
}
