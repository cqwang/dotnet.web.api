using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.Net_MVC_Demo.ViewModels
{
    public class FileUploadViewModel : BaseViewModel
    {
        public HttpPostedFileBase fileUpload { get; set; }
    }
}