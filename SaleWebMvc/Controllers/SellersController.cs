﻿using Microsoft.AspNetCore.Mvc;
using SaleWebMvc.Models;
using SaleWebMvc.Models.ViewModels;
using SaleWebMvc.Services;
using SaleWebMvc.Services.Exceptions;
using System.Diagnostics;

namespace SaleWebMvc.Controllers
{
    public class SellersController : Controller
    {

        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _sellerService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller)
        {
            /*if (!ModelState.IsValid)
            {
                List<Department> departments = await _departmentService.FindAllAsync();
                SellerFormViewModel viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }*/

            await _sellerService.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            var obj = await _sellerService.FindByIdAsync(id);
            if (obj == null) return RedirectToAction(nameof(Error), new { message = "Id not found" });

            List<Department> departments = await _departmentService.FindAllAsync();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seller seller)
        {
            /*if (!ModelState.IsValid)
            {
                List<Department> departments = await _departmentService.FindAllAsync();
                SellerFormViewModel viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }*/

            if (id != seller.Id) return RedirectToAction(nameof(Error), new { message = "Id mismatch" });

            try
            {
                await _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Error), new { message = "Id not provided" });

            var obj = await _sellerService.FindByIdAsync(id);

            if (obj == null) return RedirectToAction(nameof(Error), new { message = "Id not found" });

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _sellerService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var seller = await _sellerService.FindByIdAsync(id);
            if (seller == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(seller);
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
