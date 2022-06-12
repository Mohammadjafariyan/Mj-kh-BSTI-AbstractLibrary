using System;
using NBitcoin;

namespace BigPardakht.Model
{
    public class CoinWrongException : Exception
    {
        public CoinWrongException(string msg = null) : base(msg ?? "")
        {
        }
    }

    public class HaventAnyCoinException : Exception
    {
    }

    public class BitCoinAddressWrongException : Exception
    {
    }

    public class TransactionNotConfirmedException : Exception
    {
        public TransactionNotConfirmedException(uint256 operationTransactionId) : base(
            string.Format("تراکنش {0} تایید نشده است", operationTransactionId))
        {
        }
    }
    public class TransactionBroadCastException : Exception
    {
        public TransactionBroadCastException(string errorErrorCode):base(errorErrorCode)
        {
        }
    }
    public class CurrencyTypeIsWrongException : Exception
    {
    }
    public class InvalidWIFException : Exception
    {
    }

    public class RequestedTransferAmountIsGreaterThanStokOrNotConfirmedExeption : Exception
    {
    }
}