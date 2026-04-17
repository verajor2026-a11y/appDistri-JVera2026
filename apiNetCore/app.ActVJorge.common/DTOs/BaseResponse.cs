using System;
using System.Collections.Generic;
using System.Text;

namespace app.ActVJorge.common.DTOs
{
    public class BaseResponse<TResult>
    {
        public bool Success { get; set; }

        public string? ErrorMessage { get; set; }

        public TResult? Result { get; set; }
    }
}
