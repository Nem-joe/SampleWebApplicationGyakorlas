using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleWebApplication1.Models;
using Services;

namespace SampleWebApplication1.Controllers
{
    public class NoticesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly NoticeService _noticeService;

        public NoticesController(AppDbContext context, NoticeService noticeService)
        {
            _context = context;
            _noticeService = noticeService;
        }

        // GET: Notices
        public async Task<IActionResult> Index()
        {
            return View(await _context.notices.ToListAsync());
        }

        // GET: Notices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var notice = _noticeService;
            return View(notice);
        }

        // GET: Notices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NoticeViewModel notice)
        {
            if (ModelState.IsValid)
            {
                await _noticeService.CreateAsync(notice);
                return RedirectToAction(nameof(Index));
            }
            return View(notice);
        }

        // GET: Notices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var notice = await _noticeService.DetailsAsync(id);
            return View(notice);
        }

        // POST: Notices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  NoticeViewModel notice)
        {
            if (id != notice.Id)  //BIZTONSAGI ELLENORZES
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _noticeService.UpdateAsync(notice);
                return RedirectToAction(nameof(Index));
            }
            return View(notice);
        }

        // GET: Notices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var notice = await _noticeService.DetailsAsync(id);           

            return View(notice);
        }

        // POST: Notices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           

            await _noticeService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> NoticeExists(int id)
        {
            if (await _noticeService.DetailsAsync(id) is null)
            {
                return false;
            }
            return true;
        }
    }
}
