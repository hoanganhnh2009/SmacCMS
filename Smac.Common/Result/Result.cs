using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedu.Common.Result
{
    public enum ResultCode
    {
        SUCCESS = 200,
        FAIL = 400,
        NOT_FOUND = 401,
        EXISTED = 402,
        TIMEOUT=403,
        UNKNOWN=404,
        NOT_EXIST=405
    }
    public static class ResultMessage
    {
        public static string SUCCESS = "{0} thành công.";
        public static string FAIL = "{0} không thành công.";
        public static string UNKNOWN = "Lỗi không xác định.";
        public static string NOT_FOUND = "Không tìm thấy {0} nào.";
        public static string EXISTED = "{0} đã tồn tại.";
        public static string NOT_EXIST = "{0} chưa tồn tại.";
        public static string TIMEOUT = "Quá thời gian thực thi {0}.";
        public static string COUNT = "Có {0} {1} được tìm thấy.";
    }
    public class Result<T>
    {
        public ResultCode Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public Result(ResultCode code, string msg, T data)
        {
            this.Data = data;
            this.Code = code;
            this.Message = msg;
        }
        public Result() { }
    }
}
