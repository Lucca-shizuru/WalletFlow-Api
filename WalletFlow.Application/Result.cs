using System;
using System.Collections.Generic;
using System.Text;

namespace WalletFlow.Application
{
    public class Result
    {
        public bool IsSuccess { get; private set; }
        public string Error { get; private set; }

        protected Result (bool Success, string error)
        {
            this.IsSuccess = Success;
            Error = error;
        }

        public static Result success () => new Result(true, null);
        public static Result failure (string error) => new Result(false, error);
    }
}
