﻿using Microsoft.AspNetCore.Mvc;

namespace CaterServ.ViewComponents.UILayout
{
    public class _UILayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
