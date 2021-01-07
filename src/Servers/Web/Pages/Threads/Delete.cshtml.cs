namespace MyApp.Namespace
{
    using System;
    using HawkLab.Data.Core.Persistence;
    using HawkLab.Data.Core.Types;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class DeleteModel : PageModel
    {
        private readonly IThreadRepository threadRepository;

        public DeleteModel(IThreadRepository threadRepository)
        {
            this.threadRepository = threadRepository;
        }

        [TempData]
        public string Notice { get; set; }

        public Thread Thread { get; set; }

        public IActionResult OnPost(Guid threadId)
        {
            Thread = threadRepository.GetById(threadId);
            if (Thread != null)
            {
                threadRepository.Delete(Thread);
            }

            return RedirectToPage("./List");
        }
    }
}
