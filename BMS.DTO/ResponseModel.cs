using System;

namespace BMS.DTO
{
    public class ResponseModel
    {

        public ResponseModel()
        {
            this.MessageType = 0;
            this.Message = string.Empty;
        }

        public int MessageType { get; set; }

        public string Message { get; set; }
    }
}
