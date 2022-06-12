using AbstractLibrary.FormBuilder;
using BigPardakht.Model;

namespace BigPardakht.ViewModel.Gateway
{
    public class NewTransactionRequestViewModel
    {
        [ReadOnly] public string OrderId { get; set; }

        [ReadOnly] public decimal Amount { get; set; }

        [Text] public string Name { get; set; }
        [Text] public string Phone { get; set; }
        [Text] public string Mail { get; set; }
        [TextArea] public string Desc { get; set; }
        [Hidden] public string Callback { get; set; }

        [Hidden]
        public string Coin { get; set; }
        [Hidden] public string AcceptLanguage { get; set; }
    }
}