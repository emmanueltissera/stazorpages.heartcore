using System;
using Microsoft.AspNetCore.Mvc;
using StazorPages.Constants;
using StazorPages.Heartcore.Models;
using StazorPages.Heartcore.Services;
using StazorPages.Models;
using StazorPages.Services;
using StazorPages.StazorFile;

namespace StazorPages.Heartcore.Controllers
{
    [ApiController]
    [Route("api/contentupdate")]
    public class ContentUpdateNotificationController : ControllerBase
    {
        private readonly IContentService _contentService;
        public ContentUpdateNotificationController(IContentService contentService)
        {
            _contentService = contentService;
        }

        [HttpPost]
        public NotificationResult Post([FromBody] HeadlessNotification notification)
        {
            var pagePath = GetPagePath(notification.Id);
            StazorFileManagementService.DeletePage(pagePath);
            return new NotificationResult { Status = NotificationStatus.Success, Message = "Stazor page deleted successfully." };
        }

        private string GetPagePath(Guid id)
        {
            var item = _contentService.GetContentById(id).Result;
            var url = item.Url;
            return PageUrlTranslator.TranslateToStazorPath(url);
        }
    }
}
