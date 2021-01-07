namespace MyApp.Namespace
{
    using System.Collections.Generic;
    using HawkLab.Data.Core.Persistence;
    using HawkLab.Data.Core.Types;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Configuration;

    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IThreadRepository threadRepository;

        public ListModel(
            IConfiguration config,
            IThreadRepository threadRepository)
        {
            this.config = config;
            this.threadRepository = threadRepository;
        }

        public string Notice { get; set; }

        public IEnumerable<Thread> Threads { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public void OnGet()
        {
            Notice = config["Notice"];
            Threads = threadRepository.GetThreadsBySubject(SearchTerm);
        }
    }
}
