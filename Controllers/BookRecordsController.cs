using BookRecordApp.Data;
using BookRecordApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookRecordApp.Controllers
{
	public class BookRecordsController : Controller
	{
		private readonly AppDbContext _context;

		public BookRecordsController(AppDbContext context)
		{
			_context = context;
		}

		//GET: /BookRecords
		public async Task<IActionResult> Index()
		{
			var records = await _context.BookRecords.ToListAsync();
			return View(records);
		}

		//GET: /BookRecords/Create
		public IActionResult Create()
		{
			return View();
		}

		//POST: /BookRecords/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(BookRecord record)
		{
			if (ModelState.IsValid)
			{
				_context.BookRecords.Add(record);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View();
		}

		//GET: /BookRecords/Edit/5

		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null) return NotFound();

			var record = await _context.BookRecords.FindAsync(id);
			if (record == null) return NotFound();

			return View(record);
		}

		//GET: /BookRecords/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, BookRecord record)
		{
			if (id != record.Id) return NotFound();

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(record);
					await _context.SaveChangesAsync();
					return RedirectToAction(nameof(Index));
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!_context.BookRecords.Any(e => e.Id == record.Id))
						return NotFound();
					else throw;
				}
			}
			return View(record);
		}

		//GET: /BookRecords/Delete/5

		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null) return NotFound();

			var record = await _context.BookRecords.FirstOrDefaultAsync(m => m.Id == id);
			if (record == null) return NotFound();

			return View(record);
		}

		//POST: /BookRecords/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]

		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var record = await _context.BookRecords.FindAsync(id);
			if (record != null)
			{
				_context.BookRecords.Remove(record);
				await _context.SaveChangesAsync();
			}
			return RedirectToAction(nameof(Index));
		}
		//GET: /BookRecords/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null) return NotFound();

			var record = await _context.BookRecords.FirstOrDefaultAsync(m => m.Id == id);
			if (record == null) return NotFound();

			return View(record);
		}
	}

}
