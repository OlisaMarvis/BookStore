using Marvis.BookStore.Models;
using Marvis.BookStore.Repository;
using Marvis.BookStore.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace Marvis.BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly NewBookAlertConfig _newBookAlertconfiguration;
        private readonly NewBookAlertConfig _thirdPartyBookconfiguration;
        private readonly IOptionsSnapshot<NewBookAlertConfig> newBookAlertconfiguration;
        private readonly IMessageRepository _messageRepository;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public HomeController(IOptionsSnapshot<NewBookAlertConfig> newBookAlertconfiguration, 
            IMessageRepository messageRepository, 
            IUserService userService,
            IEmailService emailService)
        {
            _newBookAlertconfiguration = newBookAlertconfiguration.Get("InternalBook");
            _thirdPartyBookconfiguration = newBookAlertconfiguration.Get("ThirdPartyBook");
            this.newBookAlertconfiguration = newBookAlertconfiguration;
            _messageRepository = messageRepository;
            _userService = userService;
            _emailService = emailService;
        }
        //[ViewData]
        //public string CustomProperty { get; set; }
        //[ViewData]
        //public string Title { get; set; }
        //[ViewData]
        //public BookModel Book { get; set; }
        public async Task<ViewResult> Index()
        {

            //UserEmailOptions options = new UserEmailOptions()
            //{
            //    ToEmails = new List<string>() { "olisamarvis@gmail.com" },
            //    PlaceHolders = new List<KeyValuePair<string, string>>()
            //    {
            //        new KeyValuePair<string, string>("{{UserName}}", "Olisa")
            //    }
            //};
            //await _emailService.SendTestEmail(options);

            //Title = "Home page from controller";
            //CustomProperty = "Custom value";
            //Book = new BookModel() { Id = 1, Title = "Asp.Net Core Tutorial" };

            var userId = _userService.GetUserId();
            var isLoggedIn = _userService.IsAuthenticated();
            bool isDisplay = _newBookAlertconfiguration.DisplayNewBookAlert;
            bool isDisplay1 = _thirdPartyBookconfiguration.DisplayNewBookAlert;

            //var value = _messageRepository.GetName();

            //multiple lines
            //var newBook = newBookAlertconfiguration.GetSection("NewBookAlert");
            //var result = newBookAlertconfiguration.GetValue<bool>("DisplayNewBookAlert");
            //var bookName = newBookAlertconfiguration.GetValue<string>("BookName");

            //To write it in one line
            //var newBook = newBookAlertconfiguration.GetSection("NewBookAlert").GetValue<bool>("DisplayNewBookAlert");


            //var newBook = newBookAlertconfiguration.GetSection("NewBookAlert");
            //var result = newBookAlertconfiguration.GetValue<bool>("DisplayNewBookAlert");
            //var bookName = newBookAlertconfiguration.GetValue<string>("BookName");


            //var result = newBookAlertconfiguration["AppName"];
            //var key1 = newBookAlertconfiguration["infoObj:key1"];
            //var key2 = newBookAlertconfiguration["infoObj:key2"];
            //var key3 = newBookAlertconfiguration["infoObj:key3:key3obj1"];
            return View();
            //return View("TempView/MarvisTemp.cshtml");
        }

        public ViewResult AboutUs()
        {
            //Title = "About page from controller";

            return View();
        }

        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
