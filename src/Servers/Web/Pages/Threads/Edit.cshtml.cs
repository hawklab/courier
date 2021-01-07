namespace HawkLab.Courier.Servers.Web.Pages.Threads
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HawkLab.Data.Core.Persistence;
    using HawkLab.Data.Core.Types;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class EditModel : PageModel
    {
        private readonly IThreadRepository threadRepository;

        public EditModel(IThreadRepository threadRepository)
        {
            this.threadRepository = threadRepository;
        }

        [BindProperty]
        public Thread Thread { get; set; }

        public IActionResult OnGet(Guid? threadId)
        {
            if (threadId.HasValue)
            {
                Thread = threadRepository.GetById(threadId.Value);
            }
            else
            {
                Thread = new Thread();
            }

            if (Thread == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Thread.Id != Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                threadRepository.Update(Thread);
            }
            else
            {
                threadRepository.Add(Thread);
            }

            threadRepository.Commit();
            TempData["Notice"] = "Thread saved";
            return RedirectToPage("./Detail", new { threadId = Thread.Id });
        }
    }
}
