using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiGordao.Application.Model
{
    public class FileUploadModel
    {
        public string FileName { get; set; }
        public byte[] Data { get; set; }
    }
}
