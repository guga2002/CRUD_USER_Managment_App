using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.User.Source.ResponseAndRequest.Response
{
    public class AlbumResponse
    {
        public string Title { get; set; }
        public List<PhotoResponse> photos { get; set; } = new List<PhotoResponse>();
    }
}
