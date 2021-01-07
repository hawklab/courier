namespace MyApp.Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HawkLab.Data.Core.Persistence;
    using HawkLab.Data.Core.Types;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.SignalR;

    public class DetailModel : PageModel
    {
        private readonly IThreadRepository threadRepository;
        private readonly IMessageRepository messageRepository;

        public DetailModel(IThreadRepository threadRepository, IMessageRepository messageRepository)
        {
            this.threadRepository = threadRepository;
            this.messageRepository = messageRepository;
        }

        [TempData]
        public string Notice { get; set; }

        public Thread Thread { get; set; }

        [BindProperty]
        public Message Message { get; set; }

        public IActionResult OnGet(Guid threadId)
        {
            Thread = threadRepository.GetById(threadId);
            if (Thread == null)
            {
                return RedirectToPage("./NotFound");
            }

            Message = new Message();
            return Page();
        }

        public IActionResult OnPost(Guid threadId)
        {
            Thread = threadRepository.GetById(threadId);
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Message.Id != Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                messageRepository.Update(Message);
            }
            else
            {
                messageRepository.Add(Message, Thread);
            }

            messageRepository.Commit();
            TempData["Notice"] = "Message saved";
            return RedirectToPage("./Detail", new { threadId });
        }
    }
}
